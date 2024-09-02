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
using SIMA.Utilitario;
using SIMA.SimaNetWeb.InterfacesIU;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using NullableTypes;

namespace SIMA.SimaNetWeb.DirectorioEjecutivo
{
	/// <summary>
	/// Summary description for AcuerdoDirectorio.
	/// </summary>
	public class AcuerdoDirectorio : System.Web.UI.Page, IPaginaBase
	{
		#region Controles

		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion Controles

		#region Constantes
		const string URLPRINCIPAL = "InformeDirectorio.aspx";
		const string KEYQIDSESIONDIRECTORIO = "IdSesionDirectorio";
		const string KEYQIDTIPODISPOSICION = "IdTipoDisposicion";
		const string KEYQIDTIPOINFORME = "IdTipoInforme";

		const string PERMANENTES = "0";
		const string GENERALES = "1";

		const string SIMAPERU = "Directorio/ConsultaAcuerdoSesionDirectorio.aspx?";
		const string SIMAIQUITOS = "Directorio/ConsultaAcuerdoSesionDirectorio.aspx?";
		//const string DISPOSICIONESGENERALES = "AcuerdosPermanentes.aspx?";
		const string DISPOSICIONESGENERALES = "Directorio/ConsultarDisposicionesDirectorio.aspx?";
		protected System.Web.UI.HtmlControls.HtmlImage ibtnSimaPeru;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnSimaIquitos;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnPermanentes;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnTemas;
		const string TEMAS = "Directorio/ConsultarTemasDirectorio.aspx";

		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.LlenarJScript();                    

					Helper.ReiniciarSession();

					LogAplicativo.GrabarLogAplicativoArchivo(
						new LogAplicativo(CNetAccessControl.GetUserName(),"Directorio Ejecutivo",
						this.ToString(),"Se consultó los Acuerdos de Directorio.",Enumerados.NivelesErrorLog.I.ToString()));
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
					SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),SIMA.Utilitario.Constantes.CODIGOERRORGENERICO,oException.Message);
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
			// TODO:  Add AcuerdoDirectorio.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AcuerdoDirectorio.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add AcuerdoDirectorio.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add AcuerdoDirectorio.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add AcuerdoDirectorio.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			ibtnSimaPeru.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			ibtnSimaPeru.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.MostrarVentana(SIMAPERU,
				"IdCentroOperativo=1" + Utilitario.Constantes.SIGNOAMPERSON + KEYQIDTIPOINFORME + Utilitario.Constantes.SIGNOIGUAL + 
				Convert.ToInt32(Enumerados.TiposDeInforme.Acuerdos))
				+ Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.POPUPDEESPERA);

			ibtnSimaIquitos.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			ibtnSimaIquitos.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.MostrarVentana(SIMAIQUITOS,
				"IdCentroOperativo=4" + Utilitario.Constantes.SIGNOAMPERSON + KEYQIDTIPOINFORME + Utilitario.Constantes.SIGNOIGUAL + 
				Convert.ToInt32(Enumerados.TiposDeInforme.Acuerdos))
				+ Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.POPUPDEESPERA);			

			ibtnPermanentes.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			ibtnPermanentes.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.MostrarVentana(DISPOSICIONESGENERALES,
				KEYQIDTIPODISPOSICION + Utilitario.Constantes.SIGNOIGUAL + PERMANENTES +
				Utilitario.Constantes.SIGNOAMPERSON + KEYQIDTIPOINFORME + Utilitario.Constantes.SIGNOIGUAL + 
				Convert.ToInt32(Enumerados.TiposDeInforme.AcuerdoPermanentes))
				+ Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.POPUPDEESPERA);

			/*ibtnDisposicionesGenerales.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			ibtnDisposicionesGenerales.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.MostrarVentana(DISPOSICIONESGENERALES,
				KEYQIDTIPODISPOSICION + Utilitario.Constantes.SIGNOIGUAL + GENERALES + 
				Utilitario.Constantes.SIGNOAMPERSON + KEYQIDTIPOINFORME + Utilitario.Constantes.SIGNOIGUAL + 
				Convert.ToInt32(Enumerados.TiposDeInforme.DisposicionesGenerales))
				+ Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.POPUPDEESPERA);
			*/
			ibtnTemas.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			ibtnTemas.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.MostrarVentana(TEMAS,"")
				+ Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.POPUPDEESPERA);
			//ibtnTemas.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, ENCONSTRUCCION);
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AcuerdoDirectorio.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AcuerdoDirectorio.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AcuerdoDirectorio.Exportar implementation
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
			// TODO:  Add AcuerdoDirectorio.ValidarFiltros implementation
			return false;
		}

		#endregion
	}
}
