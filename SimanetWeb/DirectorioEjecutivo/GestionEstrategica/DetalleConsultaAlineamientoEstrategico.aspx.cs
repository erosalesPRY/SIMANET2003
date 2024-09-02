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
using SIMA.Controladoras.GestionEstrategica;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;

namespace SIMA.SimaNetWeb.DirectorioEjecutivo.Gestion_Estrategica
{
	/// <summary>
	/// Summary description for DetalleConsultaAlineamientoEstrategico.
	/// </summary>
	public class DetalleConsultaAlineamientoEstrategico : System.Web.UI.Page,IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Label lblContenidoObjGeneral;
		protected System.Web.UI.WebControls.Label lblCodigoObjGeneral;
		protected System.Web.UI.WebControls.Label Label1;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblTituloPagina;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Image Image2;
		protected System.Web.UI.WebControls.Image Image1;
		protected System.Web.UI.WebControls.TextBox txtObjeto;
		protected System.Web.UI.WebControls.Label lblObjeto;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion Controles
		
		#region Constantes

		//Ordenamiento
		const string COLORDENAMIENTO = "IDALINEAMIENTOESTRATEGICO";
		const int COLUMNANUMERACION = 0;
		const int OGENERAL = 1;

		//URLS
		const string URLACERCAOBJETIVOGENERAL = "ConsultaAcercaObjetivoGeneral.aspx?";

		//INDICES
		const string KEYQIDOGENERAL = "IDOGENERALES";


		//OTROS
		const string TITULO = "DETALLE ALINEAMIENTO ESTRATEGICO";
		const string TEXTOFOOTERTOTAL = "Total:";
		const string OBJETIVOGENERAL = "OG";
		
		const int POSICIONFOOTERTOTAL = 1;
		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();

					Helper.ReiniciarSession();

					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionEstrategica",this.ToString(),"Se consulto el Modulo Gestion Estrategico.",Enumerados.NivelesErrorLog.I.ToString()));

					this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO),Utilitario.Constantes.INDICEPAGINADEFAULT);					
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
					SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
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
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(e.SortExpression),Helper.ObtenerIndicePagina());
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			grid.CurrentPageIndex=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,
					Utilitario.Helper.MostrarDatosEnCajaTexto("txtObjeto",dr[Enumerados.ColumnasAlineamientoEstrategico.DESCRIPCION.ToString()].ToString().ToUpper()));
				//
				//				e.Item.Cells[0].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
				//					Helper.MostrarVentana(URLDETALLE,Utilitario.Constantes.KEYMODOPAGINA +  
				//					Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.C.ToString() + 
				//					Utilitario.Constantes.SIGNOAMPERSON + KEYQID + Utilitario.Constantes.SIGNOIGUAL + 
				//					Convert.ToString(dr[Enumerados.ColumnasAdquisicionesPropias.IdAdquisicionPropia.ToString()])));
				//
				e.Item.Cells[0].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				e.Item.Cells[0].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado("hGridPagina","hOrdenGrilla"));
			}
		}
		#region IPaginaBase Members

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

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
		{
			lblTituloPagina.Text = TITULO;
			
			//Busqueda en base al codigo del objetivo general
			int idOGeneral = Convert.ToInt32(Page.Request.QueryString[Utilitario.Enumerados.ColumnasObjetivosGenerales.IDOGENERALES.ToString()]);
			string OGeneralTexto = Convert.ToString(Page.Request.QueryString[Utilitario.Enumerados.ColumnasObjetivosGenerales.DESCRIPCION.ToString()]);

			CAlineamientoEstrategico oCAlineamientoEstrategico =  new CAlineamientoEstrategico();
			DataTable dtAEstrategico =  oCAlineamientoEstrategico.DetalleAlineamientoEstrategico(idOGeneral);
			
			if(dtAEstrategico!=null)
			{
				DataView dwAEstrategico = dtAEstrategico.DefaultView;
				//dwAEstrategico.Sort = columnaOrdenar;
				grid.DataSource = dwAEstrategico;
				dwAEstrategico.RowFilter = Helper.ObtenerFiltro(this);

				if (dwAEstrategico.Count == 0)
				{
					grid.DataSource = null; 
					//lblResultado.Text = GRILLAVACIA;
					//txtObjeto.Text = "";
					//lblResultado.Visible = true;
				}
				else
				{
					this.lblCodigoObjGeneral.Text = OBJETIVOGENERAL + idOGeneral;
					this.lblContenidoObjGeneral.Text = OGeneralTexto;
					grid.DataSource = dwAEstrategico;
					grid.Columns[0].FooterText = TEXTOFOOTERTOTAL;
					grid.Columns[POSICIONFOOTERTOTAL].FooterText = dwAEstrategico.Count.ToString();
				}
				//CImpresion oCImpresion = new CImpresion();
				//oCImpresion.GuardarDataImprimirExportar(dwAEstrategico.Table,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGODETALLEVENTASPRESUPUESTADAS),columnaOrdenar,indicePagina);
				//oCImpresion.GuardarDataImprimirExportar(Helper.DataViewTODataTable(dwAEstrategico),Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGODETALLEVENTASPRESUPUESTADAS),columnaOrdenar,indicePagina);
			}
			else
			{
				grid.DataSource = dtAEstrategico;
				//lblResultado.Text = GRILLAVACIA;
				//txtObjeto.Text ="";
				//lblResultado.Visible = true;
			}

			//			if(indicePagina==0)
			//			{
			//				REGISTROACTUAL=0;
			//			}
			//			else
			//			{
			//				REGISTROACTUAL=(indicePagina * grid.PageSize);
			//			}

			try
			{
				grid.DataBind();
			}
			catch(Exception ex)
			{
				string a = ex.Message;
				grid.CurrentPageIndex = 0;
				grid.DataBind();
			}
			
		}

		public void LlenarGrilla()
		{
			// TODO:  Add DetalleConsultaAlineamientoEstrategico.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetalleConsultaAlineamientoEstrategico.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add DetalleConsultaAlineamientoEstrategico.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add DetalleConsultaAlineamientoEstrategico.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add DetalleConsultaAlineamientoEstrategico.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetalleConsultaAlineamientoEstrategico.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetalleConsultaAlineamientoEstrategico.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetalleConsultaAlineamientoEstrategico.Exportar implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add DetalleConsultaAlineamientoEstrategico.ValidarFiltros implementation
			return false;
		}

		#endregion
	}
}
