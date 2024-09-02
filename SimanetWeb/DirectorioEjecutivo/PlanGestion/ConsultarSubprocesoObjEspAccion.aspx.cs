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

namespace SIMA.SimaNetWeb.DirectorioEjecutivo.PlanGestion
{
	/// <summary>
	/// Summary description for ConsultarSubprocesoObjEspAccion.
	/// </summary>
	public class ConsultarSubprocesoObjEspAccion : System.Web.UI.Page, IPaginaBase
	{
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblNombreSubProceso;
		protected System.Web.UI.WebControls.Label lblSubProceso;
		protected System.Web.UI.WebControls.Label lblNombreProceso;
		protected System.Web.UI.WebControls.Label lblProceso;
		protected System.Web.UI.WebControls.Label lblObjetivoEspecifico;
		protected System.Web.UI.WebControls.Label lblNombreObjetivoEspecifico;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
	
		#region Controles
		
		const string COLORDENAMIENTO = "IdAccion";
		const int COLUMNANUMERACION = 1;
		const int POSICIONFOOTERTOTAL = 1;
		const string TEXTOFOOTERTOTAL = "Total:";
		const string GRILLAVACIA = "No hay Acciones asignadas";

		const string URLACCIONPLANGESTION = "ConsultarSubprocesoObjEspAccion.aspx?";
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Image Image1;
		protected System.Web.UI.WebControls.Image Image2;
		const string KEYIDOESPECIFICOS = "IdOEspecificos";
		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();

					Helper.ReiniciarSession();

					LlenarTitulos();
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
				#region Helpers
				e.Item.Cells[0].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);	
				Helper.FiltroporSeleccionConfiguraColumna(e,grid);
				#endregion
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
		
		public void LlenarTitulos()
		{
			this.lblProceso.Text = Convert.ToString(Page.Request.QueryString[Utilitario.Enumerados.ColumnasProceso.CodigoProceso.ToString()]).ToUpper();
			this.lblNombreProceso.Text = Convert.ToString(Page.Request.QueryString[Utilitario.Enumerados.ColumnasProceso.NombreProceso.ToString()]).ToUpper();

			this.lblSubProceso.Text = Convert.ToString(Page.Request.QueryString[Utilitario.Enumerados.ColumnasSubProceso.CodigoSubproceso.ToString()]).ToUpper();
			this.lblNombreSubProceso.Text = Convert.ToString(Page.Request.QueryString[Utilitario.Enumerados.ColumnasSubProceso.Descripcion.ToString()]).ToUpper();

			this.lblObjetivoEspecifico.Text = Convert.ToString(Page.Request.QueryString[Utilitario.Enumerados.ColumnasObjetivosEspecificos.CODIGOOESPECIFICOS.ToString()]).ToUpper();
			this.lblNombreObjetivoEspecifico.Text = Convert.ToString(Page.Request.QueryString[Utilitario.Enumerados.ColumnasObjetivosEspecificos.NOMBREOESPECIFICOS.ToString()]).ToUpper();
		}
		

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
		{
			int IdOEspecificos = Convert.ToInt32(Page.Request.QueryString[Utilitario.Enumerados.ColumnasObjetivosEspecificos.IDOESPECIFICOS.ToString()]);
			CPlanGestion oCPlanGestion =  new CPlanGestion();
			DataTable dtAccion =  oCPlanGestion.ListarAccionPlanGestion(IdOEspecificos);
			
			if(dtAccion!=null)
			{
				DataView dwAccion = dtAccion.DefaultView;
				//dwAccion.Sort = columnaOrdenar;
				grid.DataSource = dwAccion;
				dwAccion.RowFilter = Helper.ObtenerFiltro(this);

				if (dwAccion.Count == 0)
				{
					grid.DataSource = null; 
					lblResultado.Text = GRILLAVACIA;
					//txtObjeto.Text = "";
					lblResultado.Visible = true;
				}
				else
				{				
					grid.DataSource = dwAccion;
					grid.Columns[0].FooterText = TEXTOFOOTERTOTAL;
					grid.Columns[POSICIONFOOTERTOTAL].FooterText = dwAccion.Count.ToString();
				}
			}
			else
			{
				grid.DataSource = dtAccion;
				lblResultado.Text = GRILLAVACIA;
				//txtObjeto.Text ="";
				lblResultado.Visible = true;
			}

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
			// TODO:  Add ConsultarSubprocesoObjEspAccion.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarSubprocesoObjEspAccion.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add ConsultarSubprocesoObjEspAccion.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add ConsultarSubprocesoObjEspAccion.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarSubprocesoObjEspAccion.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarSubprocesoObjEspAccion.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarSubprocesoObjEspAccion.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarSubprocesoObjEspAccion.Exportar implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ConsultarSubprocesoObjEspAccion.ValidarFiltros implementation
			return false;
		}

		#endregion
	}
}
