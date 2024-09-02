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
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using SIMA.Interfaces;

namespace SIMA.SimaNetWeb.DirectorioEjecutivo.Gestion_Estrategica
{
	/// <summary>
	/// Summary description for ConsultaProcesoEstrategico.
	/// </summary>
	public class ConsultaProcesoEstrategico20072011 : System.Web.UI.Page, IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion
		
		#region	Constantes Diagramna
		const string TEXTOTITULO = "ANALISIS ESTRATEGICO";
		const string OBJETOSOCIAL = "01.01.01OBJETOSOCIALSIMA-PERU.pdf";
		const string MISION = "01.01.02MISIONSIMA-PERU.pdf";
		const string VISION = "01.01.03VISIONSIMA-PERU.pdf";
		const string VALORES = "01.01.04VALORESSIMA-PERU.pdf";
		const string DIRECTIVAMEF = "01.09.01DirectivaFormulaciónPlanes.pdf";
		#endregion

		#region	Constantes Generales
		string ENCONSTRUCCION = Helper.MensajeAlert("EN CONSTRUCCIÓN");
		const string OGENERALES = "ConsultaObjetivoGeneral.aspx";
		const string DIAGNOSTICOSITUACIONAL = "ConsultaDiagnosticoSituacional.aspx";
		const string RETROALIMENTACION = "ConsultaRetroAlimentacion.aspx";
		const string MARCOLEGAL = "/SimaNetWeb/Legal/ConsultarDecretosYLeyes.aspx?";
		const string KEYMARCOLEGAL = "IdArea";
		const string POLITICASGENERALES = "ConsultaPoliticasGenerales.aspx";
		const string ALINEAMIENTO = "ConsultaAlineamientoEstrategico.aspx";		
		const string IDENTIDAD = "ConsultaIdentidad.aspx";
		const string IMPLEMENTACIONESTRATEGICA = "ConsultaImplementacionEstrategica.aspx";
		protected System.Web.UI.HtmlControls.HtmlImage btnFilosofiaEmpresarial;
		protected System.Web.UI.HtmlControls.HtmlImage btnDiagnosticoSituacional;
		protected System.Web.UI.HtmlControls.HtmlImage btnFormulacionEstrategica;
		protected System.Web.UI.HtmlControls.HtmlImage btnPlaneamientoProgramatico;
		protected System.Web.UI.HtmlControls.HtmlImage btnImplementacionOperacional;
		protected System.Web.UI.HtmlControls.HtmlImage btnObjetoSocial;
		protected System.Web.UI.HtmlControls.HtmlImage btnMision;
		protected System.Web.UI.HtmlControls.HtmlImage btnVision;
		protected System.Web.UI.HtmlControls.HtmlImage btnValores;
		protected System.Web.UI.HtmlControls.HtmlImage btnIdentidad;
		protected System.Web.UI.HtmlControls.HtmlImage btnSeguimientoyEvaluacionEstrategica;
		protected System.Web.UI.HtmlControls.HtmlImage btnMatrizDeDiagnostico;
		protected System.Web.UI.HtmlControls.HtmlImage btnAnalisisNormativo;
		protected System.Web.UI.HtmlControls.HtmlImage btnLineamientosEstrategicos;
		protected System.Web.UI.HtmlControls.HtmlImage btnApreciacionEstrategica;
		protected System.Web.UI.HtmlControls.HtmlImage btnMacroEntorno;
		protected System.Web.UI.HtmlControls.HtmlImage btnMicroEntorno;
		protected System.Web.UI.HtmlControls.HtmlImage btnEntornoEspecifico;
		protected System.Web.UI.HtmlControls.HtmlImage btnIdentificacionyPriorizacionDeOportunidades;
		protected System.Web.UI.HtmlControls.HtmlImage btnFactoresClavesDeExito;
		protected System.Web.UI.HtmlControls.HtmlImage btnAnalisisFODA;
		protected System.Web.UI.HtmlControls.HtmlImage btnMatrizDeEstrategias;
		protected System.Web.UI.HtmlControls.HtmlImage btnEstablecerTemasEstrategicos;
		protected System.Web.UI.HtmlControls.HtmlImage btnFormularObjetivosGenerales;
		protected System.Web.UI.HtmlControls.HtmlImage btnAlineamientoEstrategico;
		protected System.Web.UI.HtmlControls.HtmlImage btnEstablecerObjetivosEspecificos;
		protected System.Web.UI.HtmlControls.HtmlImage btnEstablecerAcciones;
		protected System.Web.UI.HtmlControls.HtmlImage btnEstablecerActividades;
		protected System.Web.UI.HtmlControls.HtmlImage btnEstablecerMetodoSeguimiento;
		protected System.Web.UI.HtmlControls.HtmlImage btnEstablecerMetas;
		protected System.Web.UI.HtmlControls.HtmlImage btnEstablecerIndicadoresDeGestion;
		protected System.Web.UI.HtmlControls.HtmlImage btnEstablecerElTableroDeMando;
		protected System.Web.UI.HtmlControls.HtmlImage btnPresupuestoEstrategico;
		protected System.Web.UI.HtmlControls.HtmlImage btnFormulacionPlanOperativo;
		protected System.Web.UI.HtmlControls.HtmlImage btnFormulacionPresupuestoAnual;
		protected System.Web.UI.HtmlControls.HtmlImage btnRetroalimentacionyActualizacion;
		protected System.Web.UI.HtmlControls.HtmlImage btnTableroDeMando;
		protected System.Web.UI.HtmlControls.HtmlImage btnAvanceDelPlanOperativo;
		protected System.Web.UI.HtmlControls.HtmlImage btnAvancePresupuesto;
		protected System.Web.UI.HtmlControls.HtmlImage btnAvanceDelPlanEstrategico;
		const string LINEAMIENTOSGENERALES = "ConsultaLineamientoGeneral.aspx";
		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					this.LlenarJScript();
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionEstrategica",this.ToString(),"Se consulto el Proceso Estrategico.",Enumerados.NivelesErrorLog.I.ToString()));
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
			// TODO:  Add ConsultaProcesoEstrategico.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultaProcesoEstrategico.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add ConsultaProcesoEstrategico.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add ConsultaProcesoEstrategico.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			
		}

		public void LlenarJScript()
		{
//			imgObjetoSocial.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
//			imgObjetoSocial.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.PopupMostrarArchivos(Helper.ObtenerRutaPDFs(Utilitario.Constantes.RUTAPDFS) + Utilitario.Constantes.RUTASIMANETESTRATEGICOGENERALIDADES + OBJETOSOCIAL));

			btnFilosofiaEmpresarial.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, ENCONSTRUCCION);
			btnDiagnosticoSituacional.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, ENCONSTRUCCION);
			btnFormulacionEstrategica.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, ENCONSTRUCCION);
			btnPlaneamientoProgramatico.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, ENCONSTRUCCION);
			btnImplementacionOperacional.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, ENCONSTRUCCION);
			btnSeguimientoyEvaluacionEstrategica.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, ENCONSTRUCCION);
			btnObjetoSocial.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, ENCONSTRUCCION);
			btnMision.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, ENCONSTRUCCION);
			btnVision.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, ENCONSTRUCCION);
			btnValores.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, ENCONSTRUCCION);
			btnIdentidad.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, ENCONSTRUCCION);
			btnMatrizDeDiagnostico.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, ENCONSTRUCCION);
			btnAnalisisNormativo.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, ENCONSTRUCCION);
			btnLineamientosEstrategicos.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, ENCONSTRUCCION);
			btnApreciacionEstrategica.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, ENCONSTRUCCION);
			btnMacroEntorno.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, ENCONSTRUCCION);
			btnMicroEntorno.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, ENCONSTRUCCION);
			btnEntornoEspecifico.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, ENCONSTRUCCION);
			btnIdentificacionyPriorizacionDeOportunidades.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, ENCONSTRUCCION);
			btnFactoresClavesDeExito.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, ENCONSTRUCCION);
			btnAnalisisFODA.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, ENCONSTRUCCION);
			btnMatrizDeEstrategias.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, ENCONSTRUCCION);
			btnEstablecerTemasEstrategicos.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, ENCONSTRUCCION);
			btnFormularObjetivosGenerales.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, ENCONSTRUCCION);
			btnAlineamientoEstrategico.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, ENCONSTRUCCION);
			btnEstablecerObjetivosEspecificos.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, ENCONSTRUCCION);
			btnEstablecerAcciones.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, ENCONSTRUCCION);
			btnEstablecerActividades.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, ENCONSTRUCCION);
			btnEstablecerMetodoSeguimiento.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, ENCONSTRUCCION);
			btnEstablecerMetas.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, ENCONSTRUCCION);
			btnEstablecerIndicadoresDeGestion.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, ENCONSTRUCCION);
			btnEstablecerElTableroDeMando.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, ENCONSTRUCCION);
			btnPresupuestoEstrategico.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, ENCONSTRUCCION);
			btnFormulacionPlanOperativo.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, ENCONSTRUCCION);
			btnFormulacionPresupuestoAnual.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, ENCONSTRUCCION);
			btnRetroalimentacionyActualizacion.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, ENCONSTRUCCION);
			btnTableroDeMando.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, ENCONSTRUCCION);
			btnAvanceDelPlanOperativo.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, ENCONSTRUCCION);
			btnAvancePresupuesto.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, ENCONSTRUCCION);
			btnAvanceDelPlanEstrategico.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, ENCONSTRUCCION);
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultaProcesoEstrategico.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultaProcesoEstrategico.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultaProcesoEstrategico.Exportar implementation
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
			// TODO:  Add ConsultaProcesoEstrategico.ValidarFiltros implementation
			return false;
		}

		#endregion
	}
}