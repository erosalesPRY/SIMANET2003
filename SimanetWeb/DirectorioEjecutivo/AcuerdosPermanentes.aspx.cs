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
	public class AcuerdosPermanentes : System.Web.UI.Page,IPaginaBase
	{
		#region Controles
		protected System.Web.UI.HtmlControls.HtmlImage ibtnSimaPeru;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnSimaIquitos;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion Controles

		#region Constantes
		const string KEYQIDSESIONDIRECTORIO = "IdSesionDirectorio";
		const string KEYQIDTIPODISPOSICION = "IdTipoDisposicion";
		const string KEYQIDCENTROOPERATIVO = "IdCentroOperativo";
		const string KEYQIDTIPOINFORME = "IdTipoInforme";

		const string DISPOSICIONESGENERALES = "Directorio/ConsultarDisposicionesDirectorio.aspx?";
		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					//this.ConfigurarAccesoControles();

					this.LlenarJScript();                    

					Helper.ReiniciarSession();

					LogAplicativo.GrabarLogAplicativoArchivo(
						new LogAplicativo(CNetAccessControl.GetUserName(),"Directorio Ejecutivo",
						this.ToString(),"Se consultó los Acuerdos Permanentes.",Enumerados.NivelesErrorLog.I.ToString()));
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
			// TODO:  Add AcuerdosPermanentes.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AcuerdosPermanentes.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add AcuerdosPermanentes.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add AcuerdosPermanentes.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add AcuerdosPermanentes.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			ibtnSimaPeru.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			ibtnSimaPeru.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.MostrarVentana(DISPOSICIONESGENERALES,
				"IdCentroOperativo=1" + Utilitario.Constantes.SIGNOAMPERSON + KEYQIDTIPODISPOSICION + 
				Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQIDTIPODISPOSICION] +
				Utilitario.Constantes.SIGNOAMPERSON + KEYQIDTIPOINFORME + Utilitario.Constantes.SIGNOIGUAL + 
				Page.Request.QueryString[KEYQIDTIPOINFORME])
				+ Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.POPUPDEESPERA);

			ibtnSimaIquitos.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			ibtnSimaIquitos.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.MostrarVentana(DISPOSICIONESGENERALES,
				"IdCentroOperativo=4" + Utilitario.Constantes.SIGNOAMPERSON + KEYQIDTIPODISPOSICION + 
				Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQIDTIPODISPOSICION] +
				Utilitario.Constantes.SIGNOAMPERSON + KEYQIDTIPOINFORME + Utilitario.Constantes.SIGNOIGUAL + 
				Page.Request.QueryString[KEYQIDTIPOINFORME])
				+ Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.POPUPDEESPERA);
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AcuerdosPermanentes.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AcuerdosPermanentes.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AcuerdosPermanentes.Exportar implementation
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
			// TODO:  Add AcuerdosPermanentes.ValidarFiltros implementation
			return false;
		}

		#endregion
	}
}
