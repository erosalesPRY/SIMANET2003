using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using SIMA.SimaNetWeb.InterfacesIU;
using SIMA.Controladoras.General;
using SIMA.Controladoras.GestionControlInstitucional;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using NullableTypes;
using MetaBuilders.WebControls;

namespace SIMA.SimaNetWeb.GestionControlInstitucional
{
	/// <summary>
	/// Summary description for PoppupImpresionResumenObservacionesAuditoria.
	/// </summary>
	public class PoppupImpresionResumenObservacionesAuditoria : System.Web.UI.Page,IPaginaBase
	{
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
		protected System.Web.UI.WebControls.Literal ltlMensaje;  
		
		
		const string GRILLAVACIA="No existe Registros";
		protected System.Web.UI.WebControls.Label lblResultado;
		const string KEYQIDPERIODO = "IdPeriodo";
		const string KEYQIDTIPOSEGUIMIENTO ="IdTipoSeguimiento";
		const string KEYQIDTIPOORGANISMO ="IdTipoOrganismo";

		DataTable dtResumenProgramacion;
		int acumProcesoSP = 0;
		int acumProcesoSC = 0;
		int acumProcesoSCH = 0;
		int acumProcesoSI = 0;
		protected projDataGridWeb.DataGridWeb grid;
		int acumTotalProceso = 0;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();

					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"OCI",this.ToString(),"Se consultó la Programación.",Enumerados.NivelesErrorLog.I.ToString()));

					this.LlenarCombos();
					//Helper.SeleccionarItemCombos(this);
					
					this.LlenarGrilla();
					this.Imprimir();
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
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			CObservacionesAuditoria oCObservacionesAuditoria=  new CObservacionesAuditoria();
			dtResumenProgramacion =  oCObservacionesAuditoria.ConsultarResumenObservacionesAuditoriaPorSituacion(
				Convert.ToInt32(Page.Request.QueryString[KEYQIDPERIODO]),Convert.ToInt32(Page.Request.QueryString[KEYQIDTIPOSEGUIMIENTO]),Convert.ToInt32(Page.Request.QueryString[KEYQIDTIPOORGANISMO]));

			lblTitulo.Text="REPORTE RESUMEN DE OBSERVACIONES DE AUDITORIA";
			if(dtResumenProgramacion!=null)
			{
				DataView dwResumenProgramacion = dtResumenProgramacion.DefaultView;
				dwResumenProgramacion.Sort = "Organismo" ;

				if (dwResumenProgramacion.Count == 0)
				{
					grid.DataSource = null; 
					lblResultado.Text = GRILLAVACIA;
					lblResultado.Visible = true;
				}
				else
				{
					grid.DataSource = dwResumenProgramacion;
					lblResultado.Visible = false;
				}
			}
			else
			{
				grid.DataSource = dtResumenProgramacion;
				lblResultado.Text = GRILLAVACIA;
			}
			
			try
			{
				grid.DataBind();
			}
			catch (Exception a)
			{
				string b = a.Message.ToString();
				grid.CurrentPageIndex = 0;
				grid.DataBind();
			}
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add PoppupImpresionResumenObservacionesAuditoria.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add PoppupImpresionResumenObservacionesAuditoria.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add PoppupImpresionResumenObservacionesAuditoria.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add PoppupImpresionResumenObservacionesAuditoria.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add PoppupImpresionResumenObservacionesAuditoria.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add PoppupImpresionResumenObservacionesAuditoria.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			ltlMensaje.Text=Helper.Imprimir();
		}

		public void Exportar()
		{
			// TODO:  Add PoppupImpresionResumenObservacionesAuditoria.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add PoppupImpresionResumenObservacionesAuditoria.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add PoppupImpresionResumenObservacionesAuditoria.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				
				acumProcesoSP+=	Convert.ToInt32(dr[Enumerados.ColumnasObservacionesAuditoria.SP.ToString()]);
				acumProcesoSC+=	Convert.ToInt32(dr[Enumerados.ColumnasObservacionesAuditoria.SC.ToString()]);
				acumProcesoSCH+=	Convert.ToInt32(dr[Enumerados.ColumnasObservacionesAuditoria.SCH.ToString()]);
				acumProcesoSI+=	Convert.ToInt32(dr[Enumerados.ColumnasObservacionesAuditoria.SI.ToString()]);
				acumTotalProceso+= Convert.ToInt32(dr[Enumerados.ColumnasObservacionesAuditoria.Total.ToString()]);		
			}
			if(e.Item.ItemType == ListItemType.Footer)
			{
				e.Item.Cells[4].Text = acumProcesoSP.ToString();
				e.Item.Cells[5].Text = acumProcesoSC.ToString();
				e.Item.Cells[6].Text = acumProcesoSCH.ToString();
				e.Item.Cells[7].Text = acumProcesoSI.ToString();
				e.Item.Cells[8].Text = acumTotalProceso.ToString();
			}
		}
	}
}
