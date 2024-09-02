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
using MetaBuilders.WebControls;

namespace SIMA.SimaNetWeb.DirectorioEjecutivo.PlanGestion
{
	/// <summary>
	/// Summary description for AdministrarSubProceso.
	/// </summary>
	public class AdministrarSubProceso : System.Web.UI.Page, IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblNombreProceso;
		protected System.Web.UI.WebControls.Label lblProceso;
		protected System.Web.UI.WebControls.ImageButton ibtnAgregar;
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
		#endregion Controles

		#region Constantes
		
		//Ordenamiento
		const string COLORDENAMIENTO = "IdProceso";
		
		//Paginas
		const string URLIMPRESION = "PopupImpresionAdministracionArticulosRelacionesPublicas.aspx";
		const string URLMODIFICAR = "DetalleSubProceso.aspx?";
		const string URLOBJETIVOSESPECIFICO = "AdministrarObjetivoEspecifico.aspx?";
		const int COLUMNASUBPROCESO = 0;
		const int COLUMNAMODIFICAR = 1;
				
		//Key Session y QueryString
		const string KEYQID = "Id";
		const string KEYIDPROCESO = "IdProceso";
		const string KEYIDSUBPROCESO = "IdSubProceso";
		const string CODIGOPROCESO = "CodigoProceso";
		const string NOMBREPROCESO = "NombreProceso";
		const string CODIGOSUBPROCESO = "CodigoSubProceso";
		const string NOMBRESUBPROCESO = "Descripcion";

		//JScript
		string JSVERIFICARELIMINAR = "return verificarEliminarRb('hCodigo','" + Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO)+"','"+Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJEPREGUNTAELIMINACIONREGISTRO)+"');";
			
		//Otros
		const string GRILLAVACIA ="No existe ningun SubProceso.";
		const int PosicionFooterTotal = 1;
		const string TITULOACERCADE = "Acerca de: ";
		const string TITULOVEROBJETIVOSESPECIFICOS = "Ver Objetivos Especificos: ";

		#endregion Constantes

		#region Variables
		#endregion Variables

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					
					this.LlenarTitulos();

					Helper.ReiniciarSession();

					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se consultaron los Articulos destinados a Relaciones Publicas.",Enumerados.NivelesErrorLog.I.ToString()));

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
			this.ibtnAgregar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAgregar_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				//e.Item.Cells[COLUMNAMODIFICAR].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
				e.Item.Cells[COLUMNAMODIFICAR].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.HISTORIALADELANTE + ";" +
					Helper.MostrarVentana(URLMODIFICAR,
					//idProceso
					KEYIDPROCESO +
					Utilitario.Constantes.SIGNOIGUAL + 
					Page.Request.QueryString[Utilitario.Enumerados.ColumnasProceso.IdProceso.ToString()] +
					Utilitario.Constantes.SIGNOAMPERSON + 
					//idSubProceso
					KEYIDSUBPROCESO +	
					Utilitario.Constantes.SIGNOIGUAL + 
					Convert.ToString(dr[Utilitario.Enumerados.ColumnasSubProceso.IdSubProceso.ToString()]) +  
					Utilitario.Constantes.SIGNOAMPERSON + 
					//CodigoProceso
					CODIGOPROCESO +
					Utilitario.Constantes.SIGNOIGUAL + 
					Convert.ToString(Page.Request.QueryString[Utilitario.Enumerados.ColumnasProceso.CodigoProceso.ToString()]).ToUpper() +
					Utilitario.Constantes.SIGNOAMPERSON + 
					//NombreProceso
					NOMBREPROCESO +
					Utilitario.Constantes.SIGNOIGUAL + 
					Convert.ToString(Page.Request.QueryString[Utilitario.Enumerados.ColumnasProceso.NombreProceso.ToString()]).ToUpper() + 
					Utilitario.Constantes.SIGNOAMPERSON + 
					//CodigoSubProceso
					CODIGOSUBPROCESO +
					Utilitario.Constantes.SIGNOIGUAL + 
					Convert.ToString(dr[Utilitario.Enumerados.ColumnasSubProceso.CodigoSubproceso.ToString()]).ToUpper() +
					Utilitario.Constantes.SIGNOAMPERSON + 
					//NombreSubproceso
					NOMBRESUBPROCESO +
					Utilitario.Constantes.SIGNOIGUAL + 
					Convert.ToString(dr[Utilitario.Enumerados.ColumnasSubProceso.Descripcion.ToString()]).ToUpper() +
					Utilitario.Constantes.SIGNOAMPERSON + 
					//ModoPagina
					Utilitario.Constantes.KEYMODOPAGINA +
					Utilitario.Constantes.SIGNOIGUAL + 
					Enumerados.ModoPagina.M.ToString()));
				e.Item.Cells[COLUMNAMODIFICAR].Font.Underline=true;
				e.Item.Cells[COLUMNAMODIFICAR].ToolTip = TITULOACERCADE;

				e.Item.Cells[COLUMNASUBPROCESO].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.HISTORIALADELANTE + ";" +
					Helper.MostrarVentana(URLOBJETIVOSESPECIFICO,
					//idProceso
					KEYIDPROCESO +
					Utilitario.Constantes.SIGNOIGUAL + 
					Page.Request.QueryString[Utilitario.Enumerados.ColumnasProceso.IdProceso.ToString()] +
					Utilitario.Constantes.SIGNOAMPERSON + 
					//idSubProceso
					KEYIDSUBPROCESO + 
					Utilitario.Constantes.SIGNOIGUAL + 
					Convert.ToString(dr[Utilitario.Enumerados.ColumnasSubProceso.IdSubProceso.ToString()]) +
					Utilitario.Constantes.SIGNOAMPERSON + 
					//CodigoProceso
					CODIGOPROCESO +
					Utilitario.Constantes.SIGNOIGUAL + 
					Convert.ToString(Page.Request.QueryString[Utilitario.Enumerados.ColumnasProceso.CodigoProceso.ToString()]).ToUpper() +
					Utilitario.Constantes.SIGNOAMPERSON + 
					//NombreProceso
					NOMBREPROCESO +
					Utilitario.Constantes.SIGNOIGUAL + 
					Convert.ToString(Page.Request.QueryString[Utilitario.Enumerados.ColumnasProceso.NombreProceso.ToString()]).ToUpper() + 
					Utilitario.Constantes.SIGNOAMPERSON + 
					//CodigoSubProceso
					CODIGOSUBPROCESO +
					Utilitario.Constantes.SIGNOIGUAL + 
					Convert.ToString(dr[Utilitario.Enumerados.ColumnasSubProceso.CodigoSubproceso.ToString()]).ToUpper() +
					Utilitario.Constantes.SIGNOAMPERSON + 
					//NombreSubproceso
					NOMBRESUBPROCESO +
					Utilitario.Constantes.SIGNOIGUAL + 
					Convert.ToString(dr[Utilitario.Enumerados.ColumnasSubProceso.Descripcion.ToString()]).ToUpper()
					));

				e.Item.Cells[COLUMNASUBPROCESO].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				e.Item.Cells[COLUMNASUBPROCESO].Font.Underline=true;
				e.Item.Cells[COLUMNASUBPROCESO].ForeColor= System.Drawing.Color.Blue;
				e.Item.Cells[COLUMNASUBPROCESO].ToolTip = TITULOVEROBJETIVOSESPECIFICOS;

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				Helper.FiltroporSeleccionConfiguraColumna(e,grid);
			}
		}

		/// <summary>
		/// Abre la Pagina para Agregar un SubProceso Nuevo
		/// </summary>
		private void redireccionaPaginaAgregar()
		{
			Page.Response.Redirect(URLMODIFICAR + 
				Utilitario.Constantes.KEYMODOPAGINA + 
				Utilitario.Constantes.SIGNOIGUAL + 
				Enumerados.ModoPagina.N.ToString() +
				Utilitario.Constantes.SIGNOAMPERSON + 
				KEYIDPROCESO +
				Utilitario.Constantes.SIGNOIGUAL + 
				Page.Request.QueryString[Utilitario.Enumerados.ColumnasProceso.IdProceso.ToString()] +
				Utilitario.Constantes.SIGNOAMPERSON + 
				//idSubProceso
				KEYIDSUBPROCESO + 
				Utilitario.Constantes.SIGNOIGUAL + 
				Page.Request.QueryString[Utilitario.Enumerados.ColumnasSubProceso.IdSubProceso.ToString()] +
				Utilitario.Constantes.SIGNOAMPERSON + 
				//CodigoProceso
				CODIGOPROCESO +
				Utilitario.Constantes.SIGNOIGUAL + 
				Convert.ToString(Page.Request.QueryString[Utilitario.Enumerados.ColumnasProceso.CodigoProceso.ToString()]).ToUpper() +
				Utilitario.Constantes.SIGNOAMPERSON + 
				//NombreProceso
				NOMBREPROCESO +
				Utilitario.Constantes.SIGNOIGUAL + 
				Convert.ToString(Page.Request.QueryString[Utilitario.Enumerados.ColumnasProceso.NombreProceso.ToString()]).ToUpper()
				);
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

		private void ibtnAgregar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.redireccionaPaginaAgregar();
		}

		private void ibtnImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			//this.Imprimir();
		}

		#region IPaginaBase Members
		public void LlenarGrilla()
		{
			
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			
		}
		public void LlenarTitulos()
		{
			this.lblProceso.Text = Convert.ToString(Page.Request.QueryString[Utilitario.Enumerados.ColumnasProceso.CodigoProceso.ToString()]).ToUpper();
			this.lblNombreProceso.Text = Convert.ToString(Page.Request.QueryString[Utilitario.Enumerados.ColumnasProceso.NombreProceso.ToString()]).ToUpper();
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
		{
			int idProceso = Convert.ToInt32(Page.Request.QueryString[Utilitario.Enumerados.ColumnasProceso.IdProceso.ToString()]);

			CPlanGestion oCPlanGestion =  new CPlanGestion();
			DataTable dtSubProcesos =  oCPlanGestion.ListarSubProcesoPlanGestion(idProceso);
			
			if(dtSubProcesos!=null)
			{
				DataView dwSubProcesos = dtSubProcesos.DefaultView;
				//dwSubProcesos.Sort = columnaOrdenar ;
				dwSubProcesos.RowFilter = Helper.ObtenerFiltro(this);

				if(dwSubProcesos.Count>0)
				{
					grid.DataSource = dwSubProcesos;
					grid.Columns[PosicionFooterTotal].FooterText = dwSubProcesos.Count.ToString();
					this.lblResultado.Visible = false;
				}
				else
				{
					grid.DataSource = null;
					lblResultado.Visible = true;
					lblResultado.Text = GRILLAVACIA;
				}
				//				CImpresion oCImpresion = new CImpresion();
				//				oCImpresion.GuardarDataImprimirExportar(dwSubProcesos.Table,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGOTITULOREPORTEPRESENTES),columnaOrdenar,indicePagina);
			}
			else
			{
				grid.DataSource = dtSubProcesos;
				this.lblResultado.Visible = true;
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
			// TODO:  Add ConsultaDeCartasFianzas.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add ConsultaDeCartasFianzas.LlenarDatos implementation
		}

		//		public void LlenarJScript()
		//		{
		//			ibtnEliminar.Attributes.Add("onclick",JSVERIFICARELIMINAR);	
		//		}

		public void RegistrarJScript()
		{

		}

		public void Imprimir()
		{
			//ltlMensaje.Text = Helper.PopupImpresion(URLIMPRESION,750,500,false,false,false,true,true);
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


		public void LlenarJScript()
		{
			// TODO:  Add AdministrarSubProceso.LlenarJScript implementation
		}

		#endregion
	}
}
