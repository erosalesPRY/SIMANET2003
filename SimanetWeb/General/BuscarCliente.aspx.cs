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
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using NullableTypes;
using MetaBuilders.WebControls;

namespace SIMA.SimaNetWeb.General
{
	/// <summary>
	/// Summary description for BuscarCliente.
	/// </summary>
	public class BuscarCliente : System.Web.UI.Page, IPaginaBase
	{
		#region controles
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblPalabraBusqueda;
		protected System.Web.UI.WebControls.TextBox txtPalabraClave;
		protected System.Web.UI.WebControls.ImageButton btnBuscar;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label lblNumeroCoincidencias;
		protected System.Web.UI.WebControls.Label lblDblNumeroCoincidencias;
		protected System.Web.UI.WebControls.Image imgCancelar;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hNombreCliente;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		#endregion

		#region Constantes
		const string KEYIDCLIENTE="IdCliente";
		const string KEQNOMBRECLIENTE="RazonSocial";
			
		const string COLUMNAORDENAMIENTO="RazonSocial";
		protected System.Web.UI.HtmlControls.HtmlInputHidden hOrdenGrilla;

		const string GRILLAVACIA="No se encontro Dependencia con la Palabra Clave Especificada";

		#endregion Constantes
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					//this.ConfigurarAccesoControles();
					
					this.LlenarJScript();
					this.LlenarCombos();
					this.LlenarDatos();

					Helper.ReiniciarSession();
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
			this.btnBuscar.Click += new System.Web.UI.ImageClickEventHandler(this.btnBuscar_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add BuscarCliente.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add BuscarCliente.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			CCliente oCCliente=new CCliente();

			DataTable dt=oCCliente.BuscarClientesSegunPalabraClave(this.txtPalabraClave.Text);

			if(dt!=null)
			{
				DataView dw = dt.DefaultView;
				dw.Sort = columnaOrdenar ;
				dw.RowFilter = Helper.ObtenerFiltro(this);
				if(dw.Count>0)
				{
					grid.DataSource = dw;
					grid.Columns[Utilitario.Constantes.POSICIONFOOTERTOTAL].FooterText = "Total";
					grid.Columns[Utilitario.Constantes.POSICIONFOOTERTOTAL + 1].FooterText = dw.Count.ToString();
					this.lblResultado.Visible = false;
				}
				else
				{
					grid.DataSource = null;
					lblResultado.Visible = true;
					lblResultado.Text = GRILLAVACIA;
				}
				
			}
			else
			{
				grid.DataSource = dt;
				lblResultado.Text = GRILLAVACIA;
			}
			
			try
			{
				grid.DataBind();
			}
			catch	
			{
				grid.CurrentPageIndex = Utilitario.Constantes.ValorConstanteCero;
				grid.DataBind();
			}

			/*
			if(dt!=null)
			{
				DataView dw = dt.DefaultView;
				dw.Sort = columnaOrdenar ;
				this.grid.DataSource=dw;
				this.lblDblNumeroCoincidencias.Text=dt.Rows.Count.ToString(Utilitario.Constantes.FORMATODECIMAL4);
			}
			else
			{
				grid.DataSource = dt;
				lblResultado.Text = GRILLAVACIA;
				this.lblDblNumeroCoincidencias.Text="0.00";

			}
			
			try
			{
				grid.DataBind();
			}

			catch (Exception e)
			{
				string a = e.Message;
				grid.CurrentPageIndex = 0;
				grid.DataBind();
			}*/
		}

		public void LlenarCombos()
		{
			// TODO:  Add BuscarCliente.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add BuscarCliente.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			this.btnBuscar.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,"ValidarPalabraClave();");
		}

		public void RegistrarJScript()
		{
			// TODO:  Add BuscarCliente.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add BuscarCliente.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add BuscarCliente.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add BuscarCliente.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add BuscarCliente.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				e.Item.Cells[Utilitario.Constantes.POSICIONINDEXCERO].Text=Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex); 
				e.Item.Cells[Utilitario.Constantes.POSICIONINDEXCERO].Font.Underline= Utilitario.Constantes.VALORCHECKEDBOOL;

				//HtmlInputRadioButton rb = (HtmlInputRadioButton)e.Item.Cells[3].Controls[0];
				//rb.Value = Convert.ToString(dr[Utilitario.Enumerados.GeneralCliente.IdCliente.ToString()]);
				//rb.Attributes.Add("onclick","AccionSeleccionFilaDosValores('hCodigo','" + Convert.ToString(dr[Utilitario.Enumerados.GeneralCliente.IdCliente.ToString()])+ "','hNombreCliente','" + dr[Utilitario.Enumerados.GeneralCliente.RazonSocial.ToString()].ToString() + "');");
				
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e
					,Utilitario.Helper.MostrarDatosEnCajaTexto
					(hCodigo.ID,
					dr[Enumerados.GeneralCliente.IdCliente.ToString()].ToString()),
					Utilitario.Helper.MostrarDatosEnCajaTexto
					(hNombreCliente.ID,
					dr[Enumerados.GeneralCliente.RazonSocial.ToString()].ToString())
					);

				//e.Item.Cells[1].Text = Utilitario.Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				//Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
			}
		}

		private void btnBuscar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if(this.txtPalabraClave.Text!=Utilitario.Constantes.VACIO)
			{
				this.LlenarGrillaOrdenamientoPaginacion(COLUMNAORDENAMIENTO,Utilitario.Constantes.INDICEPAGINADEFAULT);
			}
			else
			{
				this.ltlMensaje.Text=Helper.MensajeAlert("Debe de especificar una Palabra Clave de Busqueda");
			}
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			//this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(e.SortExpression),Helper.ObtenerIndicePagina());
			//this.LlenarGrillaOrdenamientoPaginacion("RazonSocial",Helper.ObtenerIndicePagina());
			this.hOrdenGrilla.Value = Helper.GenerarExpresionOrdenamiento(e.SortExpression);
			this.LlenarGrillaOrdenamientoPaginacion(this.hOrdenGrilla.Value,Helper.ObtenerIndicePagina());
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			grid.CurrentPageIndex=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);
		}
	}
}
