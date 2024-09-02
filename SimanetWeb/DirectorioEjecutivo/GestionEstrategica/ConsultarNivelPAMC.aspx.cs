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
	public class ConsultarNivelPAMC : System.Web.UI.Page,IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Label lblResultadoProyectos;
		protected System.Web.UI.WebControls.Label lblResultadoDocumentos;
		protected projDataGridWeb.DataGridWeb gridDocumentos;
		protected projDataGridWeb.DataGridWeb gridProyectos;
		protected System.Web.UI.WebControls.Label lblTituloDocumentos;
		protected System.Web.UI.WebControls.Label lblProyectos;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hNombre;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminaFiltro;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;
		#endregion
	
		#region Constantes
		const string URLFILTRO="../../Filtros.aspx?";
		const string DETALLE = "ConsultarAgrupacionPAMC.aspx?";
		const string KEYPAMCNIVEL="KEYPAMCNIVEL";
		const string KEYPAMCNOMBRENIVEL="KEYPAMCNOMBRENIVEL";
		const string COLORDENAMIENTO="nombre";
		const string GRILLAVACIA="No existen Registros";
		const string KEYPAMCAGRUPACION="KEYPAMCAGRUPACION";
		const int idTablaTipoDocumento=404;
		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO,true),Helper.ObtenerIndicePagina());
					this.LlenarGrillaOrdenamientoPaginacionDocumentos(COLORDENAMIENTO,0);
					this.LlenarGrillaOrdenamientoPaginacionProyectos(COLORDENAMIENTO,0);
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Utilitario.Enumerados.NombresdeModulo.GestiónComercial.ToString(),this.ToString(),"Se ingreso a la Consulta de Nivel PAMC",Enumerados.NivelesErrorLog.I.ToString()));			
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

		
		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			
		}

		public DataTable ObtenerDatos()
		{
			CMantenimientos oCMantenimientos =  new CMantenimientos();
			return oCMantenimientos.ListarTodosGrilla(Enumerados.ClasesNTAD.PAMCNivelNTAD.ToString());
		}
		public void LlenarGrillaOrdenamientoPaginacionProyectos(string columnaOrdenar,int indicePagina)
		{
			CPAMCDocumentosNivel oCPAMCDocumentosNivel = new CPAMCDocumentosNivel();
			DataTable dtNivel = oCPAMCDocumentosNivel.ListarTodosGrilla(1,1,idTablaTipoDocumento);
			
			if(dtNivel!=null)
			{
				DataView dwNivel = dtNivel.DefaultView;
				dwNivel.Sort = columnaOrdenar ;
				dwNivel.RowFilter = Helper.ObtenerFiltro(this);
				if(dwNivel.Count>0)
				{
					gridProyectos.DataSource = dwNivel;
					gridProyectos.CurrentPageIndex = indicePagina;
					gridProyectos.Columns[Utilitario.Constantes.POSICIONINDEXUNO].FooterText = dwNivel.Count.ToString();
					this.lblResultadoProyectos.Visible = false;
				}
				else
				{
					gridProyectos.DataSource = null;
					lblResultadoProyectos.Visible = true;
					lblResultadoProyectos.Text = GRILLAVACIA;
				}
			}
			else
			{
				gridProyectos.DataSource = dtNivel;
				lblResultadoProyectos.Text = GRILLAVACIA;
			}
			
			try
			{
				gridProyectos.DataBind();
			}
			catch	
			{
				gridProyectos.CurrentPageIndex = Utilitario.Constantes.ValorConstanteCero;
				gridProyectos.DataBind();
			}
		}

		public void LlenarGrillaOrdenamientoPaginacionDocumentos(string columnaOrdenar,int indicePagina)
		{
			CPAMCDocumentosNivel oCPAMCDocumentosNivel = new CPAMCDocumentosNivel();
			DataTable dtNivel = oCPAMCDocumentosNivel.ListarTodosGrilla(1,0,idTablaTipoDocumento);
			
			
			if(dtNivel!=null)
			{
				DataView dwNivel = dtNivel.DefaultView;
				dwNivel.Sort = columnaOrdenar ;
				dwNivel.RowFilter = Helper.ObtenerFiltro(this);
				if(dwNivel.Count>0)
				{
					gridDocumentos.DataSource = dwNivel;
					gridDocumentos.CurrentPageIndex = indicePagina;
					gridDocumentos.Columns[Utilitario.Constantes.POSICIONINDEXUNO].FooterText = dwNivel.Count.ToString();
					this.lblResultadoDocumentos.Visible = false;
				}
				else
				{
					gridDocumentos.DataSource = null;
					lblResultadoDocumentos.Visible = true;
					lblResultadoDocumentos.Text = GRILLAVACIA;
				}
			}
			else
			{
				gridDocumentos.DataSource = dtNivel;
				lblResultadoDocumentos.Text = GRILLAVACIA;
			}
			
			try
			{
				gridDocumentos.DataBind();
			}
			catch	
			{
				gridDocumentos.CurrentPageIndex = Utilitario.Constantes.ValorConstanteCero;
				gridDocumentos.DataBind();
			}
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
		{
			DataTable dtNivel = this.ObtenerDatos();
			
			if(dtNivel!=null)
			{
				DataView dwNivel = dtNivel.DefaultView;
				dwNivel.Sort = columnaOrdenar ;
				dwNivel.RowFilter = Helper.ObtenerFiltro(this);
				if(dwNivel.Count>0)
				{
					grid.DataSource = dwNivel;
					grid.CurrentPageIndex = indicePagina;
					grid.Columns[Utilitario.Constantes.POSICIONINDEXUNO].FooterText = dwNivel.Count.ToString();
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
				grid.DataSource = dtNivel;
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
		}

		public void LlenarDatos()
		{
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
			this.ibtnFiltrar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnFiltrar_Click);
			this.ibtnEliminaFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminaFiltro_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.gridDocumentos.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.gridDocumentos_ItemDataBound);
			this.gridProyectos.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.gridProyectos_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				e.Item.Cells[0].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);

				e.Item.Cells[0].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
						Helper.MostrarVentana(DETALLE,KEYPAMCNIVEL + Utilitario.Constantes.SIGNOIGUAL + 
						dr["idNivelPAMC"].ToString() +  
						Utilitario.Constantes.SIGNOAMPERSON + Utilitario.Constantes.KEYMODOPAGINA +
						Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.C.ToString()+
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYPAMCNOMBRENIVEL + Utilitario.Constantes.SIGNOIGUAL +
						dr["nombre"].ToString() +
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYPAMCAGRUPACION + Utilitario.Constantes.SIGNOIGUAL +
						Utilitario.Constantes.ValorConstanteCero
						));

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,
					Utilitario.Helper.MostrarDatosEnCajaTexto(hCodigo.ID,
					dr["idNivelPAMC"].ToString()),
					Utilitario.Helper.MostrarDatosEnCajaTexto(hNombre.ID,
					dr["NOMBRE"].ToString())
					);

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

		private void gridDocumentos_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
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

		private void gridProyectos_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
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
	}
}
