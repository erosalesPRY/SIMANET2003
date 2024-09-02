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
	/// Summary description for PoppupImpresionDocumentosAuditoria.
	/// </summary>
	public class PoppupImpresionDocumentosAuditoria : System.Web.UI.Page, IPaginaBase
	{
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
		protected System.Web.UI.WebControls.Literal ltlMensaje; 
	
		const string KEYQIDDOCUMENTOAUDITORIA = "IdDocumentoAuditoria";
		const string KEYQDESCRIPCION = "Descripcion";
		const string KEYQIDSITUACION = "IdSituacion";
		const string KEYQIDORGANISMO = "IdOrganismo";
		const string KEYQIDCENTROOPERATIVO = "IdCentroOperativo";
		const string KEYQIDPERIODO = "IdPeriodo";
		const string KEYQIDTIPOSEGUIMIENTO ="IdTipoSeguimiento";
		int IDSITUACION;
		int IDORGANISMO;
		int IDCENTROOPERATIVO;
		int IDPERIODO;
		protected projDataGridWeb.DataGridWeb grid;
		string GRILLAVACIA="No existen Registros";
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					
					this.ConfigurarAccesoControles();
					
					this.LlenarJScript();

					Helper.ReiniciarSession();

					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Legal",this.ToString(),"Se consultó los DocumentosAuditoria Embargados.",Enumerados.NivelesErrorLog.I.ToString()));

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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			lblTitulo.Text="REPORTE DE DOCUMENTOS DE AUDITORIA";
			
				IDSITUACION = -1;
			
				IDORGANISMO = -1;
			
				IDCENTROOPERATIVO= -1;
			
				IDPERIODO= -1;
			
			CDocumentosAuditoria oCDocumentosAuditoria=  new CDocumentosAuditoria();
			DataTable dtDocumentosAuditoria =  oCDocumentosAuditoria.ConsultarDocumentosAuditoria
				(IDSITUACION, IDORGANISMO, IDCENTROOPERATIVO, IDPERIODO,Convert.ToInt32(Page.Request.QueryString[KEYQIDTIPOSEGUIMIENTO]));

			if(dtDocumentosAuditoria!=null)
			{
				DataView dwDocumentosAuditoria = dtDocumentosAuditoria.DefaultView;
				dwDocumentosAuditoria.Sort = "Organismo" ;
				//dwDocumentosAuditoria.RowFilter= Utilitario.Helper.ObtenerFiltro(this);
				grid.DataSource = dwDocumentosAuditoria;
				//grid.CurrentPageIndex =indicePagina;

				grid.Columns[Utilitario.Constantes.POSICIONFOOTERTOTAL].FooterText = Utilitario.Constantes.TEXTOFOOTERTOTAL;
				grid.Columns[Utilitario.Constantes.POSICIONTOTAL].FooterText = dwDocumentosAuditoria.Count.ToString();
			}
			else
			{
				grid.DataSource = dtDocumentosAuditoria;
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
			// TODO:  Add PoppupImpresionDocumentosAuditoria.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add PoppupImpresionDocumentosAuditoria.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add PoppupImpresionDocumentosAuditoria.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add PoppupImpresionDocumentosAuditoria.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add PoppupImpresionDocumentosAuditoria.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add PoppupImpresionDocumentosAuditoria.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			ltlMensaje.Text=Helper.Imprimir();
		}

		public void Exportar()
		{
			// TODO:  Add PoppupImpresionDocumentosAuditoria.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add PoppupImpresionDocumentosAuditoria.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add PoppupImpresionDocumentosAuditoria.ValidarFiltros implementation
			return false;
		}

		#endregion
	}
}
