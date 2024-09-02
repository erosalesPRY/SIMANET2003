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
	/// Summary description for EstadosFinancieros.
	/// </summary>
	public class InformeLegal : System.Web.UI.Page,IPaginaBase
	{

		#region Controles

		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion Controles
		
		#region constantes

		string ENCONSTRUCCION = Helper.MensajeAlert("EN CONSTRUCCIÓN");
		const string KEYQDTIPOCONSULTA = "TipoConsulta";

		const string CASOSLEGALES = "../Legal/ConsultarResumenProyectosEnLegal.aspx";
		const string INMUEBLES = "../Legal/ConsultarProyectosInmuebles.aspx";
		const string ESPECIALES = "../Legal/ConsultarResumenProyectosEspeciales.aspx?";
		protected System.Web.UI.HtmlControls.HtmlImage ibtnCasosLegales;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnRegistroInmuebles;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnEspeciales;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnContratos;
		const string CONTRATOS = "../Legal/ConsultarResumenContratos.aspx";

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
						this.ToString(),"Se consultó el Informe Legal.",Enumerados.NivelesErrorLog.I.ToString()));
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
			// TODO:  Add InformeLegal.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add InformeLegal.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add InformeLegal.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add InformeLegal.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add InformeLegal.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			ibtnCasosLegales.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			ibtnCasosLegales.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.MostrarVentana(CASOSLEGALES,"")
				+ Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.POPUPDEESPERA);

			ibtnRegistroInmuebles.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			ibtnRegistroInmuebles.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.MostrarVentana(INMUEBLES,"")
				+ Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.POPUPDEESPERA);

			
			ibtnEspeciales.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			ibtnEspeciales.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.MostrarVentana(ESPECIALES + KEYQDTIPOCONSULTA + 
				Utilitario.Constantes.SIGNOIGUAL + "0","")
				+ Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.POPUPDEESPERA);

			ibtnContratos.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			ibtnContratos.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.MostrarVentana(CONTRATOS,"")
				+ Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.POPUPDEESPERA);

		}

		public void RegistrarJScript()
		{
			// TODO:  Add InformeLegal.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add InformeLegal.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add InformeLegal.Exportar implementation
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
			// TODO:  Add InformeLegal.ValidarFiltros implementation
			return false;
		}

		#endregion
	}
}
