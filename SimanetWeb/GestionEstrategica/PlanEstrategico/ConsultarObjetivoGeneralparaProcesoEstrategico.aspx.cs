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
using SIMA.Controladoras.GestionEstrategica.PlanEstrategico;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using NullableTypes;
using MetaBuilders.WebControls;
using System.Diagnostics; 

namespace SIMA.SimaNetWeb.GestionEstrategica.PlanEstrategico
{
	/// <summary>
	/// Summary description for ConsultarObjetivoGeneralparaProcesoEstrategico.
	/// </summary>
	public class ConsultarObjetivoGeneralparaProcesoEstrategico : System.Web.UI.Page, IPaginaBase
	{
		#region Constante
		const string GRILLAVACIA="No Existen datos Plan Estrategico";
		const string KEYQIDPLANESTRATEGICO="idPLEstr";
		const string KEYQPLANESTRATEGICONOMBRE="PLEstrNombre";
		const string KEYQIDOBJETIVOGENERAL="idObjGen";
		const string KEYQCODDOBJETIVOGENERAL="CodObjGen";
		const string KEYQOBJETIVOGENERALNOMBRE="ObjGenNombre";
		const string KEYQFUNDAMENTO="Fundamento";
		const string KEYQREQUERIMIENTO="Requerimiento";

		const string URLDETALLE="ConsultarObjetivoGeneralDetalleparaProcesoEstrategico.aspx";
		#endregion

		#region Variables
		int periodo = 0;
		int idtipinf = 0;
		int idtiprcs = 0;
		int idniv = 0;
		#endregion

		int idPlanEstrategico
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDPLANESTRATEGICO]); }
		}
		string PlanEstrategicoNombre
		{
			get{return Page.Request.Params[KEYQPLANESTRATEGICONOMBRE].ToString();}
		}

		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPaginaSort;
		protected System.Web.UI.WebControls.Label lblPlanEstrategico;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					this.LlenarJScript();
					Helper.ReiniciarSession();
					this.LlenarCombos();
					this.LlenarDatos();
					Helper.ReestablecerPagina(this);
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Estratégica",this.ToString(),"Se consultó Objetivo General.",Enumerados.NivelesErrorLog.I.ToString()));
					this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Convert.ToInt32(this.hGridPagina.Value));
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
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add ConsultarObjetivoGeneralparaProcesoEstrategico.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarObjetivoGeneralparaProcesoEstrategico.LlenarGrillaOrdenamiento implementation
		}

		private DataTable ObtenerDatos(int per, int tipo, int rcs, int nivel)
		{
			return null;
			//return (new CPEObjetivoGeneral()).ListarTodosGrilla(this.idPlanEstrategico,Utilitario.Constantes.FLAGDEFAULT, per, tipo, rcs, nivel);
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dt= this.ObtenerDatos(periodo, idtipinf, idtiprcs, idniv);
			if(dt!=null)
			{
				DataView dw= dt.DefaultView;
				dw.RowFilter = Helper.ObtenerFiltro();
				dw.Sort = columnaOrdenar ;
				grid.Columns[Utilitario.Constantes.POSICIONFOOTERTOTAL].FooterText = Utilitario.Constantes.TEXTOFOOTERTOTAL + Utilitario.Constantes.ESPACIO + dw.Count.ToString();
				grid.DataSource = dw;
				grid.CurrentPageIndex = Convert.ToInt32(this.hGridPagina.Value);
				lblResultado.Visible = false;

			}
			else
			{
				grid.DataSource = dt;
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
			// TODO:  Add ConsultarObjetivoGeneralparaProcesoEstrategico.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			this.lblPlanEstrategico.Text = this.PlanEstrategicoNombre.ToString();
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarObjetivoGeneralparaProcesoEstrategico.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarObjetivoGeneralparaProcesoEstrategico.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarObjetivoGeneralparaProcesoEstrategico.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarObjetivoGeneralparaProcesoEstrategico.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add ConsultarObjetivoGeneralparaProcesoEstrategico.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ConsultarObjetivoGeneralparaProcesoEstrategico.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				Helper.ConfiguraColumnaHyperLink(Utilitario.Enumerados.EventosJavaScript.OnClick,e.Item.Cells[0],
					Helper.HistorialIrAdelantePersonalizado("hGridPagina","hGridPaginaSort"),
					Helper.MostrarVentana(URLDETALLE+ Utilitario.Constantes.SIGNOINTERROGACION,
					KEYQIDOBJETIVOGENERAL + Utilitario.Constantes.SIGNOIGUAL + dr["idObjetivoGeneral"].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYQIDPLANESTRATEGICO + Utilitario.Constantes.SIGNOIGUAL + this.idPlanEstrategico.ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYQPLANESTRATEGICONOMBRE + Utilitario.Constantes.SIGNOIGUAL + this.PlanEstrategicoNombre
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYQCODDOBJETIVOGENERAL + Utilitario.Constantes.SIGNOIGUAL + dr["CODIGO"].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYQOBJETIVOGENERALNOMBRE + Utilitario.Constantes.SIGNOIGUAL + Helper.LimpiarTexto(dr["DESCRIPCION"].ToString())
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYQFUNDAMENTO + Utilitario.Constantes.SIGNOIGUAL + Helper.LimpiarTexto(dr["FUNDAMENTO"].ToString())
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYQREQUERIMIENTO + Utilitario.Constantes.SIGNOIGUAL + Helper.LimpiarTexto(dr["REQUERIMIENTO"].ToString().Replace("\r\n", "  "))
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.C.ToString()));
						
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
			}					
		}

		private void ibtnEliminaFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}

		private void ibtnFiltrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			ltlMensaje.Text = Helper.ElaborarFiltro(this.ObtenerDatos(periodo, idtipinf, idtiprcs, idniv),"Codigo;Codigo","Descripcion;Descripcion","Fundamento;Fundamento","Requerimiento;Requerimiento");
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.hGridPagina.Value=e.NewPageIndex.ToString();
			grid.CurrentPageIndex=Convert.ToInt32(this.hGridPagina.Value);
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			hGridPaginaSort.Value=Helper.GenerarExpresionOrdenamiento(e.SortExpression);
			this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Helper.ObtenerIndicePagina());
		}

	}
}
