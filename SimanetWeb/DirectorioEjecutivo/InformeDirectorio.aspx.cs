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
	/// Summary description for InformeDirectorio.
	/// </summary>
	public class InformeDirectorio : System.Web.UI.Page, IPaginaBase
	{
	
	#region controles
		protected System.Web.UI.HtmlControls.HtmlImage IMG1;
		protected System.Web.UI.HtmlControls.HtmlImage IMG2;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnTemas;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
	#endregion


	#region constantes
		string ENCONSTRUCCION = Helper.MensajeAlert("EN CONSTRUCCIÓN");
		
		const string ACUERDOS = "AcuerdoDirectorio.aspx";
		const string GESTIONPROYECTOS = "InformeProyectos.aspx";
		const string GESTIONCOMERCIAL = "Ventas.aspx";
		const string GESTIONFINANCIERA = "EstadosFinancieros.aspx";
		const string GESTIONLEGAL = "InformeLegal.aspx";
		const string GESTIONPERSONAL = "../Personal/ConsultarPersonal.aspx";
		const string GESTIONESTRATEGICA = "PlaneamientoEstrategico.aspx";
		const string GESTIONLOGISTICA = "InformeLogistica.aspx";
		const string INFORMEVARIOS = "Directorio/ConsultaInformeVariosSesionDirectorio.aspx";
		const string TEMAS = "Directorio/ConsultarTemasDirectorio.aspx";
		protected System.Web.UI.HtmlControls.HtmlImage ibtnAcuerdos;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnGestionProyectos;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnGestionComercial;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnGestionFinanciera;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnGestionLegal;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnVarios;
		const string KEYQIDSESIONDIRECTORIO = "IdSesionDirectorio";
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

					LogAplicativo.GrabarLogAplicativoArchivo(
						new LogAplicativo(CNetAccessControl.GetUserName(),"Directorio Ejecutivo",
						this.ToString(),"Se consultó el Informe de Directorio.",Enumerados.NivelesErrorLog.I.ToString()));
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
			// TODO:  Add InformeDirectorio.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add InformeDirectorio.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add InformeDirectorio.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add InformeDirectorio.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add InformeDirectorio.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			ibtnAcuerdos.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			ibtnAcuerdos.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.MostrarVentana(ACUERDOS,"")
				+ Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.POPUPDEESPERA);

			ibtnGestionProyectos.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			ibtnGestionProyectos.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.MostrarVentana(GESTIONPROYECTOS,"")
				+ Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.POPUPDEESPERA);

			ibtnGestionComercial.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			ibtnGestionComercial.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.MostrarVentana(GESTIONCOMERCIAL,"")
				+ Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.POPUPDEESPERA);

			ibtnGestionFinanciera.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			ibtnGestionFinanciera.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.MostrarVentana(GESTIONFINANCIERA,"")
				+ Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.POPUPDEESPERA);

			ibtnGestionLegal.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			ibtnGestionLegal.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.MostrarVentana(GESTIONLEGAL,"")
				+ Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.POPUPDEESPERA);

			ibtnVarios.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			ibtnVarios.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.MostrarVentana(INFORMEVARIOS,"")
				+ Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.POPUPDEESPERA);
		}

		public void RegistrarJScript()
		{
			// TODO:  Add InformeDirectorio.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add InformeDirectorio.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add InformeDirectorio.Exportar implementation
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
			// TODO:  Add InformeDirectorio.ValidarFiltros implementation
			return false;
		}

		#endregion
	}
}

