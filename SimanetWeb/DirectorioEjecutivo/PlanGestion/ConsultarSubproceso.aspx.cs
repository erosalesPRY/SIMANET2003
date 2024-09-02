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
	/// Summary description for ConsultarSubproceso.
	/// </summary>
	public class ConsultarSubproceso : System.Web.UI.Page,IPaginaBase
	{
		protected System.Web.UI.WebControls.Label lblPagina;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblResultado;

		#region Constantes
		const string COLORDENAMIENTO = "IdSubProceso";
		const int COLUMNAOBJETIVOESPECIFICO = 0;
		const int POSICIONFOOTERTOTAL = 1;
		const string TEXTOFOOTERTOTAL = "Total:";
		protected System.Web.UI.WebControls.Label lblTitulo;
		const string URLOBJETIVOESPECIFICOPLANGESTION = "ConsultarSubprocesoObjetivoEspecifico.aspx?";
		protected System.Web.UI.WebControls.Label lblProceso;
		protected System.Web.UI.WebControls.Label lblNombreProceso;
		protected System.Web.UI.WebControls.Image Image1;
		protected System.Web.UI.WebControls.Image Image2;
		const string GRILLAVACIA = "No hay Subprocesos asignados";
		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
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
		
				
				e.Item.Cells[COLUMNAOBJETIVOESPECIFICO].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.HISTORIALADELANTE + ";" +
					Helper.MostrarVentana(URLOBJETIVOESPECIFICOPLANGESTION, 
					//IdSubProceso
					Utilitario.Enumerados.ColumnasSubProceso.IdSubProceso.ToString() + 
					Utilitario.Constantes.SIGNOIGUAL + 
					Convert.ToInt16(dr[Utilitario.Enumerados.ColumnasSubProceso.IdSubProceso.ToString()]) +
					Utilitario.Constantes.SIGNOAMPERSON +

					//CodigoProceso
					Utilitario.Enumerados.ColumnasProceso.CodigoProceso.ToString() +
					Utilitario.Constantes.SIGNOIGUAL + 
					Convert.ToString(dr[Utilitario.Enumerados.ColumnasProceso.CodigoProceso.ToString()]) +
					Utilitario.Constantes.SIGNOAMPERSON +

					//NombreProceso
					Utilitario.Enumerados.ColumnasProceso.NombreProceso.ToString() + 
					Utilitario.Constantes.SIGNOIGUAL + 
					Convert.ToString(dr[Utilitario.Enumerados.ColumnasProceso.NombreProceso.ToString()]) +
					Utilitario.Constantes.SIGNOAMPERSON +

					//CodigoSubProceso
					Utilitario.Enumerados.ColumnasSubProceso.CodigoSubproceso.ToString() +
					Utilitario.Constantes.SIGNOIGUAL + 
					Convert.ToString(dr[Utilitario.Enumerados.ColumnasSubProceso.CodigoSubproceso.ToString()]) +
					Utilitario.Constantes.SIGNOAMPERSON +

					//NombreSubProceso
					Utilitario.Enumerados.ColumnasSubProceso.Descripcion.ToString() +
					Utilitario.Constantes.SIGNOIGUAL + 
					Convert.ToString(dr[Utilitario.Enumerados.ColumnasSubProceso.Descripcion.ToString()])));

				#region Helpers
				e.Item.Cells[0].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				e.Item.Cells[COLUMNAOBJETIVOESPECIFICO].Font.Underline = true;
				e.Item.Cells[COLUMNAOBJETIVOESPECIFICO].ForeColor= System.Drawing.Color.Blue;
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);	
				Helper.FiltroporSeleccionConfiguraColumna(e,grid);

				//e.Item.Cells[COLUMNANUMERACION].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN, Utilitario.Constantes.HISTORIALADELANTE);
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
			
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
		{
			int idProceso = Convert.ToInt32(Page.Request.QueryString[Utilitario.Enumerados.ColumnasProceso.IdProceso.ToString()]);
			
			CPlanGestion oCPlanGestion =  new CPlanGestion();
			DataTable dtSubProceso =  oCPlanGestion.ListarSubProcesoPlanGestion(idProceso);
		
			if(dtSubProceso!=null)
			{
				DataView dwSubProceso = dtSubProceso.DefaultView;
				//dwSubProceso.Sort = columnaOrdenar;
				grid.DataSource = dwSubProceso;
				dwSubProceso.RowFilter = Helper.ObtenerFiltro(this);

				if (dwSubProceso.Count == 0)
				{
					grid.DataSource = null; 
					
					this.lblProceso.Text = "P" + idProceso;
					this.lblNombreProceso.Text = Convert.ToString(dtSubProceso.Rows[1][Convert.ToString(Utilitario.Enumerados.ColumnasProceso.NombreProceso)].ToString().ToUpper());
					grid.Columns[0].FooterText = TEXTOFOOTERTOTAL;
					grid.Columns[POSICIONFOOTERTOTAL].FooterText = dwSubProceso.Count.ToString();
				}
			}
			else
			{
				grid.DataSource = dtSubProceso;
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
			// TODO:  Add ConsultarSubproceso.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarSubproceso.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add ConsultarSubproceso.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add ConsultarSubproceso.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarSubproceso.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarSubproceso.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarSubproceso.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarSubproceso.Exportar implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ConsultarSubproceso.ValidarFiltros implementation
			return false;
		}

		#endregion
	}
}
