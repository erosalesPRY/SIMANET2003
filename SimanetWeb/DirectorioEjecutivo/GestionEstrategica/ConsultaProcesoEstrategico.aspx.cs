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
	public class ConsultaProcesoEstrategico : System.Web.UI.Page, IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.HtmlControls.HtmlImage imgObjetoSocial;
		protected System.Web.UI.HtmlControls.HtmlImage imgMision;
		protected System.Web.UI.HtmlControls.HtmlImage imgVision;
		protected System.Web.UI.HtmlControls.HtmlImage imgValores;
		protected System.Web.UI.HtmlControls.HtmlImage imgOGenerales;
		protected System.Web.UI.HtmlControls.HtmlImage imgDiagnosticoSituacional;
		protected System.Web.UI.HtmlControls.HtmlImage imgIdentidad;
		protected System.Web.UI.HtmlControls.HtmlImage imgMarcoLegal;
		protected System.Web.UI.HtmlControls.HtmlImage imgPoliticasGenerales;
		protected System.Web.UI.HtmlControls.HtmlImage imgAlineamiento;
		protected System.Web.UI.HtmlControls.HtmlImage imgLineamientosGenerales;
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
//		const string OGENERALES = "ConsultaObjetivoGeneral.aspx";
		const string OGENERALES = "../../GestionEstrategica/PlanEstrategico/ConsultarObjetivoGeneralparaProcesoEstrategico.aspx";
		const string DIAGNOSTICOSITUACIONAL = "ConsultaDiagnosticoSituacional.aspx";
		const string RETROALIMENTACION = "ConsultaRetroAlimentacion.aspx";
		const string MARCOLEGAL = "/SimaNetWeb/Legal/ConsultarDecretosYLeyes.aspx?";
		const string KEYMARCOLEGAL = "IdArea";
		const string POLITICASGENERALES = "ConsultaPoliticasGenerales.aspx";
		const string ALINEAMIENTO = "ConsultaAlineamientoEstrategico.aspx";		
		const string IDENTIDAD = "ConsultaIdentidad.aspx";
		const string IMPLEMENTACIONESTRATEGICA = "ConsultaImplementacionEstrategica.aspx";
		const string LINEAMIENTOSGENERALES = "ConsultaLineamientoGeneral.aspx";
		const string KEYQIDPLANESTRATEGICO="idPLEstr";
		const string KEYQPLANESTRATEGICONOMBRE="PLEstrNombre";
		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					
					this.LlenarJScript();

					this.LlenarDatos();
					

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
			lblTitulo.Text = TEXTOTITULO;
		}

		public void LlenarJScript()
		{
			#region Diagrama
			imgObjetoSocial.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			imgObjetoSocial.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.PopupMostrarArchivos(Helper.ObtenerRutaPDFs(Utilitario.Constantes.RUTAPDFS) + Utilitario.Constantes.RUTASIMANETESTRATEGICOGENERALIDADES + OBJETOSOCIAL));

			imgMision.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			imgMision.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.PopupMostrarArchivos(Helper.ObtenerRutaPDFs(Utilitario.Constantes.RUTAPDFS) + Utilitario.Constantes.RUTASIMANETESTRATEGICOGENERALIDADES + MISION));

			imgVision.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			imgVision.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.PopupMostrarArchivos(Helper.ObtenerRutaPDFs(Utilitario.Constantes.RUTAPDFS) + Utilitario.Constantes.RUTASIMANETESTRATEGICOGENERALIDADES + VISION));

			imgValores.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			imgValores.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.PopupMostrarArchivos(Helper.ObtenerRutaPDFs(Utilitario.Constantes.RUTAPDFS) + Utilitario.Constantes.RUTASIMANETESTRATEGICOGENERALIDADES + VALORES));

			//imgDirectivaMEF.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			//imgDirectivaMEF.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.PopupMostrarArchivos(Helper.ObtenerRutaPDFs(Utilitario.Constantes.RUTAPDFS) + Utilitario.Constantes.RUTASIMANETESTRATEGICOPROCESO + DIRECTIVAMEF));

			#endregion

			imgOGenerales.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			imgOGenerales.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, 
				Helper.MostrarVentana(OGENERALES + Utilitario.Constantes.SIGNOINTERROGACION
					+ KEYQIDPLANESTRATEGICO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQIDPLANESTRATEGICO]
					+ Utilitario.Constantes.SIGNOAMPERSON 
					+ KEYQPLANESTRATEGICONOMBRE + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQPLANESTRATEGICONOMBRE]));

			imgDiagnosticoSituacional.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			imgDiagnosticoSituacional.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.MostrarVentana(DIAGNOSTICOSITUACIONAL));

			imgMarcoLegal.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			imgMarcoLegal.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, Helper.MostrarVentana(MARCOLEGAL, KEYMARCOLEGAL));

			imgPoliticasGenerales.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			imgPoliticasGenerales.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, Helper.MostrarVentana(POLITICASGENERALES));

			imgAlineamiento.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			imgAlineamiento.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, Helper.MostrarVentana(ALINEAMIENTO));

			imgIdentidad.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			imgIdentidad.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, Helper.MostrarVentana(IDENTIDAD));

			imgLineamientosGenerales.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			imgLineamientosGenerales.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, Helper.MostrarVentana(LINEAMIENTOSGENERALES));
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
