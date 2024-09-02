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
using SIMA.EntidadesNegocio.GestionControlInstitucional;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using NullableTypes;
using MetaBuilders.WebControls;

namespace SIMA.SimaNetWeb.GestionControlInstitucional
{
	/// <summary>
	/// Summary description for PoppupImpresionObservacionesAuditoria.
	/// </summary>
	public class PoppupImpresionObservacionesAuditoria : System.Web.UI.Page,IPaginaBase
	{
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Literal ltlMensaje;  
		
		int IDORGANISMO;
		int IDSITUACION;
		int IDCENTROOPERATIVO;
		int IDPERIODO;
		
		const string GRILLAVACIA ="No existe ninguna Observación.";

		const string KEYQID = "Id";
		const string KEYQIDDOCUMENTOAUDITORIA = "IdDocumentoAuditoria";
		const string KEYQDESCRIPCION = "Descripcion";
		const string KEYQIDORGANISMO = "IdOrganismo";
		const string KEYQIDSITUACION = "IdSituacion";
		const string KEYQIDCENTROOPERATIVO = "IdCentroOperativo";
		const string KEYQIDTIPOSEGUIMIENTO ="IdTipoSeguimiento";
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtOrganismo;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label lblFecha;
		protected System.Web.UI.WebControls.TextBox txtPeriodo;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.TextBox txtFechaDocumento;
		protected System.Web.UI.WebControls.TextBox txtCentroOperativo;
		protected System.Web.UI.WebControls.TextBox txtSituacion;
		protected System.Web.UI.WebControls.Label lblConcepto;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.TextBox txtFechaInicio;
		protected System.Web.UI.WebControls.TextBox txtFechaTermino;
		protected System.Web.UI.WebControls.Label lblContenidoObservaciones;
		protected System.Web.UI.WebControls.Label lblAccionControl;
		const string KEYQIDPERIODO = "IdPeriodo";
	
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
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"OCI",this.ToString(),"Se consultó las Programaciones de Inspecciones.",Enumerados.NivelesErrorLog.I.ToString()));
					this.LlenarDatos();
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
			lblTitulo.Text=" REPORTE DE OBSERVACIONES DE AUDITORIA";
			
			IDSITUACION = Convert.ToInt32(Page.Request.QueryString[KEYQIDSITUACION]);
			IDORGANISMO = Convert.ToInt32(Page.Request.QueryString[KEYQIDORGANISMO]);
			IDCENTROOPERATIVO = Convert.ToInt32(Page.Request.QueryString[KEYQIDCENTROOPERATIVO]);
			IDPERIODO = Convert.ToInt32(Page.Request.QueryString[KEYQIDPERIODO]);

			CObservacionesAuditoria oCObservacionesAuditoria=  new CObservacionesAuditoria();
			DataTable dtObservacionesAuditoria =  oCObservacionesAuditoria.ConsultarObservacionesAuditoria
				(Convert.ToInt32(Page.Request.QueryString[KEYQIDDOCUMENTOAUDITORIA]),IDSITUACION, 
				IDORGANISMO, IDCENTROOPERATIVO, IDPERIODO,Convert.ToInt32(Page.Request.QueryString[KEYQIDTIPOSEGUIMIENTO]));

			if(dtObservacionesAuditoria!=null)
			{
				DataView dwObservacionesAuditoria = dtObservacionesAuditoria.DefaultView;
				dwObservacionesAuditoria.Sort = "Observacion" ;
				dwObservacionesAuditoria.RowFilter= Utilitario.Helper.ObtenerFiltro(this);
				grid.DataSource = dwObservacionesAuditoria;
				//grid.CurrentPageIndex =indicePagina;

				grid.Columns[Utilitario.Constantes.POSICIONFOOTERTOTAL].FooterText = Utilitario.Constantes.TEXTOFOOTERTOTAL;
				grid.Columns[Utilitario.Constantes.POSICIONTOTAL].FooterText = dwObservacionesAuditoria.Count.ToString();
			}
			else
			{
				grid.DataSource = dtObservacionesAuditoria;
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
			// TODO:  Add PoppupImpresionObservacionesAuditoria.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add PoppupImpresionObservacionesAuditoria.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add PoppupImpresionObservacionesAuditoria.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			CMantenimientos	oCMantenimientos = new CMantenimientos();
			DocumentosAuditoriaBE oDocumentosAuditoriaBE = (DocumentosAuditoriaBE)oCMantenimientos.ListarDetalle(
				Convert.ToInt32(Page.Request.QueryString[KEYQIDDOCUMENTOAUDITORIA]),
				Enumerados.ClasesNTAD.DocumentosAuditoriaNTAD.ToString());

			if(oDocumentosAuditoriaBE!=null)
			{
				txtOrganismo.Text = oDocumentosAuditoriaBE.Organismo.ToString();
				lblAccionControl.Text = oDocumentosAuditoriaBE.Actividad.ToString();
				txtPeriodo.Text = oDocumentosAuditoriaBE.Periodo.ToString();
				txtFechaDocumento.Text = Convert.ToDateTime(oDocumentosAuditoriaBE.FechaDocumento).ToString(Utilitario.Constantes.FORMATOFECHA4);
				txtFechaInicio.Text = Convert.ToDateTime(oDocumentosAuditoriaBE.FechaInicio).ToString(Utilitario.Constantes.FORMATOFECHA4);
				if(oDocumentosAuditoriaBE.FechaTermino.ToString() != Utilitario.Constantes.FECHAVALORENBLANCO)
				{
					try
					{
						txtFechaTermino.Text = Convert.ToDateTime(oDocumentosAuditoriaBE.FechaTermino.ToString()).ToString(Utilitario.Constantes.FORMATOFECHA4);
					}
					catch(Exception e)
					{
						string a = e.Message;
						txtFechaTermino.Text = Utilitario.Constantes.VACIO;
					}
				}
				else
				{
					txtFechaTermino.Text = Utilitario.Constantes.VACIO;
				}

				txtCentroOperativo.Text = oDocumentosAuditoriaBE.CentroOperativo.ToString();		
				txtSituacion.Text = oDocumentosAuditoriaBE.Situacion.ToString();
				//txtPersonal.Text = oDocumentosAuditoriaBE.Personal.ToString();
				lblContenidoObservaciones.Text  = oDocumentosAuditoriaBE.Observacion.ToString();

				
			}
			


		}

		public void LlenarJScript()
		{
			// TODO:  Add PoppupImpresionObservacionesAuditoria.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add PoppupImpresionObservacionesAuditoria.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			ltlMensaje.Text=Helper.Imprimir();
		}

		public void Exportar()
		{
			// TODO:  Add PoppupImpresionObservacionesAuditoria.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add PoppupImpresionObservacionesAuditoria.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add PoppupImpresionObservacionesAuditoria.ValidarFiltros implementation
			return false;
		}

		#endregion
	}
}
