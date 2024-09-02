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
	/// Summary description for ConsultarSubprocesoObjetivoEspecifico.
	/// </summary>
	public class ConsultarSubprocesoObjetivoEspecifico : System.Web.UI.Page, IPaginaBase
	{
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblNombreProceso;
		protected System.Web.UI.WebControls.Label lblProceso;
		protected System.Web.UI.WebControls.Label lblSubProceso;
		protected System.Web.UI.WebControls.Label lblNombreSubProceso;
		protected System.Web.UI.WebControls.Label lblResultado;

		#region Controles
		
		const string COLORDENAMIENTO = "IdOEspecificos";
		const int COLUMNAACCION = 0;
		const int POSICIONFOOTERTOTAL = 1;
		const string TEXTOFOOTERTOTAL = "Total:";
		const string GRILLAVACIA = "No hay Objetivos Especificos asignados";

		const string URLACCIONPLANGESTION = "ConsultarSubprocesoObjEspAccion.aspx?";
		const string KEYIDOESPECIFICOS = "IdOEspecificos";
		const string CODIGOPROCESO = "CodigoProceso";
		const string DESCRIPCIONPROCESO = "NombreProceso";
		const string CODIGOSUBPROCESO = "CodigoSubproceso";
		const string DESCRIPCIONSUBPROCESO = "Descripcion";
		const string CODIGOOESPECIFICOS = "CodigoOEspecificos";
		protected System.Web.UI.WebControls.Image Image1;
		protected System.Web.UI.WebControls.Image Image2;
		const string DESCRIPCIONOESPECIFICOS = "NombreOEspecificos";
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

					this.LlenarTitulos();

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
		
				e.Item.Cells[COLUMNAACCION].Attributes.Add(Utilitario.Constantes.EVENTOCLICK, Utilitario.Constantes.HISTORIALADELANTE + ";" +
							Helper.MostrarVentana(URLACCIONPLANGESTION, 
							KEYIDOESPECIFICOS + Utilitario.Constantes.SIGNOIGUAL + 
							Convert.ToString(dr[Utilitario.Enumerados.ColumnasObjetivosEspecificos.IDOESPECIFICOS.ToString()]) +
							Utilitario.Constantes.SIGNOAMPERSON + 
							CODIGOPROCESO + Utilitario.Constantes.SIGNOIGUAL +
							Page.Request.QueryString[Utilitario.Enumerados.ColumnasProceso.CodigoProceso.ToString()] +
							Utilitario.Constantes.SIGNOAMPERSON + 
							DESCRIPCIONPROCESO + Utilitario.Constantes.SIGNOIGUAL +
							Page.Request.QueryString[Utilitario.Enumerados.ColumnasProceso.NombreProceso.ToString()] +
							Utilitario.Constantes.SIGNOAMPERSON + 
							CODIGOSUBPROCESO + Utilitario.Constantes.SIGNOIGUAL +
							Page.Request.QueryString[Utilitario.Enumerados.ColumnasSubProceso.CodigoSubproceso.ToString()] +
							Utilitario.Constantes.SIGNOAMPERSON + 
							DESCRIPCIONSUBPROCESO + Utilitario.Constantes.SIGNOIGUAL +
							Page.Request.QueryString[Utilitario.Enumerados.ColumnasSubProceso.Descripcion.ToString()] +
							Utilitario.Constantes.SIGNOAMPERSON + 
							CODIGOOESPECIFICOS + Utilitario.Constantes.SIGNOIGUAL +
							Convert.ToString(dr[Utilitario.Enumerados.ColumnasObjetivosEspecificos.CODIGOOESPECIFICOS.ToString()] +
							Utilitario.Constantes.SIGNOAMPERSON + 
							DESCRIPCIONOESPECIFICOS + Utilitario.Constantes.SIGNOIGUAL +
							Convert.ToString(dr[Utilitario.Enumerados.ColumnasObjetivosEspecificos.NOMBREOESPECIFICOS.ToString()])))
					);

				#region Helpers
				e.Item.Cells[0].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				e.Item.Cells[COLUMNAACCION].Font.Underline = true;
				e.Item.Cells[COLUMNAACCION].ForeColor= System.Drawing.Color.Blue;
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
			this.lblProceso.Text = Page.Request.QueryString[Utilitario.Enumerados.ColumnasProceso.CodigoProceso.ToString()];
			this.lblNombreProceso.Text = Page.Request.QueryString[Utilitario.Enumerados.ColumnasProceso.NombreProceso.ToString()];
			this.lblSubProceso.Text = Page.Request.QueryString[Utilitario.Enumerados.ColumnasSubProceso.CodigoSubproceso.ToString()];
			this.lblNombreSubProceso.Text = Page.Request.QueryString[Utilitario.Enumerados.ColumnasSubProceso.Descripcion.ToString()];
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
		{
			int idSubProceso = Convert.ToInt32(Page.Request.QueryString[Utilitario.Enumerados.ColumnasSubProceso.IdSubProceso.ToString()]);
			CPlanGestion oCPlanGestion =  new CPlanGestion();
			DataTable dtOE =  oCPlanGestion.ListarObjetivoEspecificoPlanGestion(idSubProceso);
			
			if(dtOE!=null)
			{
				DataView dwOE = dtOE.DefaultView;
				//dwOE.Sort = columnaOrdenar;
				grid.DataSource = dwOE;
				dwOE.RowFilter = Helper.ObtenerFiltro(this);

				if (dwOE.Count == 0)
				{
					grid.DataSource = null; 
					lblResultado.Text = GRILLAVACIA;
					//txtObjeto.Text = "";
					lblResultado.Visible = true;
				}
				else
				{
					grid.DataSource = dwOE;
					grid.Columns[0].FooterText = TEXTOFOOTERTOTAL;
					grid.Columns[POSICIONFOOTERTOTAL].FooterText = dwOE.Count.ToString();
				}
			}
			else
			{
				grid.DataSource = dtOE;
				lblResultado.Text = GRILLAVACIA;
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
			// TODO:  Add ConsultarSubprocesoObjetivoEspecifico.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarSubprocesoObjetivoEspecifico.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add ConsultarSubprocesoObjetivoEspecifico.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add ConsultarSubprocesoObjetivoEspecifico.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarSubprocesoObjetivoEspecifico.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarSubprocesoObjetivoEspecifico.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarSubprocesoObjetivoEspecifico.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarSubprocesoObjetivoEspecifico.Exportar implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ConsultarSubprocesoObjetivoEspecifico.ValidarFiltros implementation
			return false;
		}

		#endregion
	}
}
