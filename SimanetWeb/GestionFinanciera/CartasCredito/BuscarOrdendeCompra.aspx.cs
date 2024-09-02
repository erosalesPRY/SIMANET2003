using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using SIMA.SimaNetWeb.InterfacesIU;
using SIMA.Controladoras.General;
using SIMA.Controladoras.GestionFinanciera;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using NullableTypes;
using MetaBuilders.WebControls;

namespace SIMA.SimaNetWeb.GestionFinanciera.CartasCredito
{

	public class BuscarOrdendeCompra : System.Web.UI.Page,IPaginaBase
	{
		#region Constantes
			const string OBJPARAMETROCONTABLE="ParametroCartaCredito";
			const string GRILLAVACIA ="No existe ningún Registro.";  
			const string CONTROLINK="hlkNroCartaCredito";
			const string URLDETALLE="DetalleCartadeCredito.aspx";
			const string URLDETALLEGASTOS="AdministrarCartaCreditoNotadeCargo.aspx?";
			const string URLPRINCIPAL="../../Default.aspx";
			const string COLORDENAMIENTO = "NroCDI";

			const string KEYIDCARTACREDITO = "idCC";
			const string KEYIDPERIODO ="Periodo";
			const string KEYIDSITUACION ="Estado";
			const string KEYIDCENTRO ="IdCentro";
		#endregion
		#region Controles
			protected System.Web.UI.WebControls.Label lblRutaPagina;
			protected System.Web.UI.WebControls.Label lblPagina;
			protected projDataGridWeb.DataGridWeb grid;
			protected System.Web.UI.WebControls.Label lblResultado;
			protected System.Web.UI.WebControls.Label Label3;
			protected System.Web.UI.WebControls.ImageButton ibtnEliminaFiltro;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
			protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			this.grid.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(Utilitario.Helper.FooterSpan);
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					this.LlenarJScript();
					Helper.ReiniciarSession();
					this.LlenarCombos();
					Helper.ReestablecerPagina(this);
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionFinanciera",this.ToString(),"Se Buscó la Orden de Compra.",Enumerados.NivelesErrorLog.I.ToString()));
					this.LlenarGrillaOrdenamientoPaginacion(Utilitario.Constantes.VACIO,Utilitario.Constantes.ValorConstanteCero);
				}
				catch(SIMAExcepcionLog oSIMAExcepcionLog)
				{
					ltlMensaje.Text = Helper.MensajeAlert(oSIMAExcepcionLog.Mensaje);					
				}
				catch(SIMAExcepcionIU oSIMAExcepcionIU)
				{
					ltlMensaje.Text = Helper.MensajeAlert(oSIMAExcepcionIU.Mensaje);					
				}
				catch(SIMAExcepcionDominio oSIMAExcepcionDominio)
				{
					ltlMensaje.Text = Helper.MensajeAlert(oSIMAExcepcionDominio.Mensaje);					
				}
				catch(Exception oException)
				{
					SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Utilitario.Constantes.CODIGOERRORGENERICO,oException.Message);
					Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
				}
			}		

		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.ibtnEliminaFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminaFiltro_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add BuscarOrdendeCompra.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add BuscarOrdendeCompra.LlenarGrillaOrdenamiento implementation
		}
		private DataTable ObtenerDatos()
		{
			CCartaCredito oCCartaCredito = new CCartaCredito();
			return oCCartaCredito.ListarOrdendeCompra(Utilitario.Constantes.IDDEFAULT,Utilitario.Constantes.IDDEFAULT.ToString(),CNetAccessControl.GetIdUser());
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dtOrdenCompra = this.ObtenerDatos();
			if(dtOrdenCompra!=null)
			{
				DataView dwOrdenCompra = dtOrdenCompra.DefaultView;
				dwOrdenCompra.RowFilter = Helper.ObtenerFiltro();
				dwOrdenCompra.Sort = columnaOrdenar ;
				grid.Columns[Utilitario.Constantes.POSICIONFOOTERTOTAL].FooterText = Utilitario.Constantes.TEXTOFOOTERTOTAL + Utilitario.Constantes.ESPACIO + dwOrdenCompra.Count.ToString();
				grid.DataSource = dwOrdenCompra;
				grid.CurrentPageIndex = indicePagina;
				lblResultado.Visible = false;

			}
			else
			{
				grid.DataSource = dtOrdenCompra;
				lblResultado.Visible = true;
				lblResultado.Text = GRILLAVACIA;
			}
			try
			{
				grid.DataBind();
			}
			catch	
			{
				grid.CurrentPageIndex = 0;
				grid.DataBind();
			}
		}

		public void LlenarCombos()
		{
			// TODO:  Add BuscarOrdendeCompra.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add BuscarOrdendeCompra.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add BuscarOrdendeCompra.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add BuscarOrdendeCompra.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add BuscarOrdendeCompra.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add BuscarOrdendeCompra.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			if(CNetAccessControl.FindPage(Page.Request.Url.AbsolutePath.ToString()))
			{CNetAccessControl.LoadControls(this);}
			else
			{CNetAccessControl.RedirectPageError();}	
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add BuscarOrdendeCompra.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void ibtnEliminaFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				Helper.ConfiguraColumnaHyperLink(e.Item.Cells[0],grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex,Utilitario.Constantes.VACIO);
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,
							"AsignarDatos('"+ dr["Periodo"].ToString() 
							+ "','"
							+ dr["NroOrdenCompra"].ToString() 
							+ "','"
							+ dr["OrdenCompra"].ToString() 
							+ "','" 
							+ dr["Moneda"].ToString() 
							+ "','" 
							+ dr["NProveedor"].ToString() 
							+ "','" 
							+ dr["NombreCentroOperativo"].ToString() 
							+ "','" 
							+ dr["idCentroOperativo"].ToString() 
							+ "','" 
							+ dr["Descripcion"].ToString() 
							+ "','" 
							+ dr["MontoOC"].ToString() 
							+ "','" 
							+ dr["MontoGastoOC"].ToString() 
							+ "','0')");
				Helper.FiltroporSeleccionConfiguraColumna(e,grid,true,"txtBuscar");
			}			
		
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			grid.CurrentPageIndex=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(e.SortExpression),Helper.ObtenerIndicePagina());		
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
