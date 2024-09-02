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
	/// Summary description for Ventas.
	/// </summary>

	public class Ventas : System.Web.UI.Page, IPaginaBase
	{
	
		#region Controles

		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion Controles

		#region constantes
			const string VENTASPRESUPUESTADAS = "../GestionComercial/Ventas/ConsultarMontoVentasPresupuestadasGeneral.aspx?";
			const string VENTASEJECUTADAS = "../GestionComercial/Ventas/ConsultarMontoVentasReales.aspx?";
			const string PROYECTOSENCARTERA = "../Proyectos/ConsultarProyectoPorLineaDeNegocioResumen.aspx?";
			const string PROYECTOSTERMINADOS = "../Proyectos/ConsultarProyectoPorLineaDeNegocioResumen.aspx?";

			const string NOMBRETIPOPROYECTO = "NombreTipoProyecto";
			const string PROYECTOENCARTERA = "PROYECTOS EN CARTERA";
			const string PROYECTOTERMINADO = "PROYECTOS TERMINADOS";
			const string EXPODIRECTORIO = "ExpoDirectorio";
			
			const string KEYIDTIPOPROYECTO = "idTipoProyecto";
			const string IDTIPOPROYECTO = "0";
		protected System.Web.UI.HtmlControls.HtmlImage ibtnVentasPresupuestadas;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnVentasEjecutadas;
		
			const string IDTIPOPROYECTOTERMINADO = "2";

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
						this.ToString(),"Se consultaron las Ventas .",Enumerados.NivelesErrorLog.I.ToString()));
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
			// TODO:  Add Ventas.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add Ventas.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add Ventas.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add Ventas.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add Ventas.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			ibtnVentasPresupuestadas.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			ibtnVentasPresupuestadas.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.MostrarVentana(VENTASPRESUPUESTADAS,"indicePagina=V")
				+ Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.POPUPDEESPERA);

			ibtnVentasEjecutadas.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			ibtnVentasEjecutadas.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.MostrarVentana(VENTASEJECUTADAS,"indicePagina=V")
				+ Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.POPUPDEESPERA);

//			ibtnProyectosEnCartera.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
//			ibtnProyectosEnCartera.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.MostrarVentana(PROYECTOSENCARTERA,
//				NOMBRETIPOPROYECTO + Utilitario.Constantes.SIGNOIGUAL + PROYECTOENCARTERA +
//				Utilitario.Constantes.SIGNOAMPERSON + KEYIDTIPOPROYECTO + Utilitario.Constantes.SIGNOIGUAL + IDTIPOPROYECTO +
//				Utilitario.Constantes.SIGNOAMPERSON + EXPODIRECTORIO + Utilitario.Constantes.SIGNOIGUAL + EXPODIRECTORIO)
//				+ Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.POPUPDEESPERA);
//
//			ibtnProyectosTerminados.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
//			ibtnProyectosTerminados.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.MostrarVentana(PROYECTOSENCARTERA,
//				NOMBRETIPOPROYECTO + Utilitario.Constantes.SIGNOIGUAL + PROYECTOTERMINADO +
//				Utilitario.Constantes.SIGNOAMPERSON + KEYIDTIPOPROYECTO + Utilitario.Constantes.SIGNOIGUAL + IDTIPOPROYECTOTERMINADO +
//				Utilitario.Constantes.SIGNOAMPERSON + EXPODIRECTORIO + Utilitario.Constantes.SIGNOIGUAL + EXPODIRECTORIO + 
//				Utilitario.Constantes.SIGNOAMPERSON + "TipoInicioProyecto" + Utilitario.Constantes.SIGNOIGUAL + "0")
//				+ Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.POPUPDEESPERA + " return false;");
		}

		public void RegistrarJScript()
		{
			// TODO:  Add Ventas.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add Ventas.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add Ventas.Exportar implementation
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
			// TODO:  Add Ventas.ValidarFiltros implementation
			return false;
		}

		#endregion
	}
}
