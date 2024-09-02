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
	/// Summary description for BuscarDependenciaCliente.
	/// </summary>
	public class BuscarDependenciaCliente : System.Web.UI.Page, IPaginaBase
	{
		#region Constantes
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.ImageButton btnBuscar;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Image imgCancelar;
		protected System.Web.UI.WebControls.Label lblPalabraBusqueda;
		protected System.Web.UI.WebControls.Label lblCliente;
		protected System.Web.UI.WebControls.TextBox txtPalabraClave;
		protected System.Web.UI.WebControls.Label lblNumeroCoincidencias;
		protected System.Web.UI.WebControls.Label lblDblNumeroCoincidencias;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hNombreUnidad;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdCliente;
		protected System.Web.UI.WebControls.Label lblNombreCliente;
		#endregion Constantes

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

		#region Constantes
			const string KEYIDCLIENTE="IdCliente";
			const string KEYIDUNIDADDEPENDENCIACLIENTE="IdUnidadDependenciaCliente";
			const string KEQNOMBREUNIDADDEPENDENCIA="Nombre";
			
			const string COLUMNAORDENAMIENTO="Nombre";

			const string GRILLAVACIA="No se encontro Dependencia con la Palabra Clave Especificada";

		#endregion Constantes

		#region Variables
		//string JSVERIFICARSELECCIONFILA="return verificarSeleccionRb1('hCodigo','"+ Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO) + "');";
				
		#endregion Variables

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add BuscarDependenciaCliente.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add BuscarDependenciaCliente.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			CUnidadDependenciaCliente oCUnidadDependenciaCliente=new CUnidadDependenciaCliente();

			DataTable dt=oCUnidadDependenciaCliente.ListarDependenciaCliente(Convert.ToInt32(this.Page.Request[KEYIDCLIENTE]),this.txtPalabraClave.Text);

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
			}
		}

		public void LlenarCombos()
		{
			// TODO:  Add BuscarDependenciaCliente.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			this.LlenarNombreCliente();
		}

		public void LlenarJScript()
		{

		}

		public void RegistrarJScript()
		{
			// TODO:  Add BuscarDependenciaCliente.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add BuscarDependenciaCliente.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add BuscarDependenciaCliente.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add BuscarDependenciaCliente.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add BuscarDependenciaCliente.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void btnBuscar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLUMNAORDENAMIENTO,true) ,Utilitario.Constantes.INDICEPAGINADEFAULT);
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				string Cadena="AccionSeleccionFilaDosValores('hCodigo','" + Convert.ToString(dr[Utilitario.Enumerados.GeneralUnidadDependenciaCliente.IdUnidadDependenciaCliente.ToString()])+ "','hNombreUnidad','" + dr[Utilitario.Enumerados.GeneralUnidadDependenciaCliente.Nombre.ToString()].ToString() + "'); ";
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,Cadena);
				e.Item.Cells[1].Text = Utilitario.Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);	
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

		private void LlenarNombreCliente()
		{
			CCliente oCCliente=new CCliente();
			int IdCliente;
			IdCliente=Convert.ToInt32(this.Page.Request.Params[KEYIDCLIENTE]);
			this.hIdCliente.Value=IdCliente.ToString();
			DataTable dt=oCCliente.DetalleCliente(IdCliente);
			this.lblNombreCliente.Text=dt.Rows[0][Utilitario.Enumerados.GeneralCliente.RazonSocial.ToString()].ToString();
		}

	}
}
