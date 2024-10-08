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
using SIMA.Controladoras.GestionEstrategica;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;


namespace SIMA.SimaNetWeb.DirectorioEjecutivo.GestionEstrategica
{
	public class ConsultarDocumentosNivelPAMC : System.Web.UI.Page, IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblTipoDocumento;
		protected System.Web.UI.WebControls.DropDownList ddlTipoDocumento;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.WebControls.Label lblSeguimiento;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminaFiltro;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;
		#endregion

		#region Constantes
		const string KEYPAMCNIVEL="KEYPAMCNIVEL";
		const string KEYPAMCNOMBRENIVEL="KEYPAMCNOMBRENIVEL";
		const string COLORDENAMIENTO="nombre";
		const string GRILLAVACIA="No existen Registros";

		const int idTablaTipoDocumento=404;
		#endregion
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				if(!Page.IsPostBack)
				{
					ConfigurarAccesoControles();
					LlenarDatos();
					LlenarCombos();
					this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO,true),Helper.ObtenerIndicePagina());
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Utilitario.Enumerados.NombresdeModulo.GestiónComercial.ToString(),this.ToString(),"Se ingreso a la Consulta de Bitacora PAMC",Enumerados.NivelesErrorLog.I.ToString()));			
				}
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
	
		#region IPaginaBase Members
		public void LlenarGrilla()
		{
			
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			
		}

		public DataTable ObtenerDatos()
		{
			CPAMCDocumentosNivel oCPAMCDocumentosNivel = new CPAMCDocumentosNivel();
			return oCPAMCDocumentosNivel.ListarTodosGrilla(
				Convert.ToInt32(Page.Request.QueryString[KEYPAMCNIVEL]),
				Convert.ToInt32(ddlTipoDocumento.SelectedValue),
				idTablaTipoDocumento				
				);
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
		{
			DataTable dtDocumentos =  this.ObtenerDatos();
			
			if(dtDocumentos!=null)
			{
				DataView dwDocumentos = dtDocumentos.DefaultView;
				dwDocumentos.RowFilter = Helper.ObtenerFiltro(this);
				dwDocumentos.Sort = columnaOrdenar ;
				if(dwDocumentos.Count>0)
				{
					
					grid.DataSource = dwDocumentos;
					grid.CurrentPageIndex = indicePagina;
					grid.Columns[Utilitario.Constantes.POSICIONINDEXUNO].FooterText = dwDocumentos.Count.ToString();
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
				grid.DataSource = dtDocumentos;
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
		}

		public void LlenarCombos()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			ddlTipoDocumento.DataSource = oCTablaTablas.ListaTodosCombo(404);
			ddlTipoDocumento.DataTextField = Enumerados.ColumnasTablasTablas.Descripcion.ToString();
			ddlTipoDocumento.DataValueField = Enumerados.ColumnasTablasTablas.Codigo.ToString();
			ddlTipoDocumento.DataBind();
		}

		public void LlenarDatos()
		{
			this.lblSeguimiento.Text = Page.Request.QueryString[KEYPAMCNOMBRENIVEL];
		}

		public void LlenarJScript()
		{

		}

		public void RegistrarJScript()
		{
	

		}

		public void Imprimir()
		{
		}

		public void Exportar()
		{
			
		}

		public void ConfigurarAccesoControles()
		{
			if(CNetAccessControl.FindPage(Page.Request.Url.AbsolutePath.ToString()))
			{
				CNetAccessControl.LoadControls(this);
			}
			else
			{
				
				CNetAccessControl.RedirectPageError();
				
			}
		}

		public bool ValidarFiltros()
		{
			return true;
		}

		#endregion

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
			this.ddlTipoDocumento.SelectedIndexChanged += new System.EventHandler(this.ddlTipoDocumento_SelectedIndexChanged);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.ibtnEliminaFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminaFiltro_Click);
			this.ibtnFiltrar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnFiltrar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void ddlTipoDocumento_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),Helper.ObtenerIndicePagina());
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;


				System.Web.UI.WebControls.Image ibtnImagen =
					(System.Web.UI.WebControls.Image)e.Item.Cells[2].FindControl("Img");	

				ibtnImagen.ImageUrl = "../../imagenes/ley1.gif";

				ibtnImagen.Attributes.Add(Utilitario.Constantes.EVENTOCLICK.ToString(),
					Helper.PopupMostrarArchivos(
					Helper.ObtenerRutaPDFs ( Utilitario.Constantes.RUTASERVERARCHIVOSPROYECTOAMC) +
					dr["ruta"].ToString()
					));


				e.Item.Cells[Constantes.POSICIONCONTADOR].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				e.Item.Cells[Constantes.POSICIONCONTADOR].Font.Underline=true;
				e.Item.Cells[Constantes.POSICIONCONTADOR].ForeColor=Color.Blue;

							Helper.FiltroporSeleccionConfiguraColumna(e,grid);
				
			}
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			grid.CurrentPageIndex=e.NewPageIndex;
			HttpContext.Current.Session[Constantes.KEYSINDICEPAGINA]=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(e.SortExpression),Helper.ObtenerIndicePagina());
		}

		private void ibtnEliminaFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}

		private void ibtnFiltrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			ltlMensaje.Text = Utilitario.Helper.ElaborarFiltro(this.ObtenerDatos()
				,"nombre"+";Nombre"
				);
		}
	}
}
