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
	/// Summary description for InformeProyectos.
	/// </summary>
	public class InformeProyectos : System.Web.UI.Page, IPaginaBase
	{
		#region Controles

		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion Controles
		
		#region Constantes
		string ENCONSTRUCCION = Helper.MensajeAlert("EN CONSTRUCCIÓN");

		const string ENEJECUCION = "../Proyectos/ConsultarProyectoPorLineaDeNegocioResumen.aspx?";		
		const string ENINVESTIGACION="../Proyectos/ConsultaProyectosInvestigacionDesarrollo.aspx?";
		const string ENINVERSIONPUBLICA="../Proyectos/ConsultarProyectosInversionPublica.aspx";
		//const string CONVENIOSMGP = "../Convenio/ConsultarConvenioSimaMgpUnidadesApoyo.aspx?";
		const string CONVENIOSMGP = "../Convenio/ConsultarConveniosDirectorio.aspx?";

		const string NOMBRETIPOPROYECTO = "NombreTipoProyecto";
		const string PROYECTOENEJECUCION = "PROYECTOS EN EJECUCION";
		const string EXPODIRECTORIO = "ExpoDirectorio";
		
		const string KEYIDTIPOPROYECTO = "idTipoProyecto";
		protected System.Web.UI.HtmlControls.HtmlImage ibtnEnEjecucion;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnConveniosMGP;
		const string IDTIPOPROYECTO = "1";

		const string KEYIDMGP="KEYIDMGP";
		#endregion Constantes		
		
		private void Page_Load(object sender, System.EventArgs e)
		{

			if(!Page.IsPostBack)
			{
				try
				{
					this.LlenarJScript();                    
					Helper.ReiniciarSession();
					/*Medoto que elimina eliminina las variables de Sesion del Formulario 
					* de proyectos del Investigacion y desarrollo */
					Helper.ProyectosPaginaConsultaProyectosInvestigacionDesarrollo.Clear();

					LogAplicativo.GrabarLogAplicativoArchivo(
						new LogAplicativo(CNetAccessControl.GetUserName(),"Directorio Ejecutivo",
						this.ToString(),"Se consultó el Informe de Proyectos.",Enumerados.NivelesErrorLog.I.ToString()));
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
			// TODO:  Add InformeProyectos.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add InformeProyectos.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add InformeProyectos.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add InformeProyectos.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add InformeProyectos.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			ibtnEnEjecucion.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			ibtnEnEjecucion.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.MostrarVentana(ENEJECUCION,
				KEYIDMGP + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.IDCLIENTEMARINA.ToString()+
				Utilitario.Constantes.SIGNOAMPERSON + NOMBRETIPOPROYECTO + Utilitario.Constantes.SIGNOIGUAL + PROYECTOENEJECUCION +
				Utilitario.Constantes.SIGNOAMPERSON + KEYIDTIPOPROYECTO + Utilitario.Constantes.SIGNOIGUAL + IDTIPOPROYECTO + 
				Utilitario.Constantes.SIGNOAMPERSON + EXPODIRECTORIO + Utilitario.Constantes.SIGNOIGUAL + EXPODIRECTORIO)
				+ Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.POPUPDEESPERA);

			ibtnConveniosMGP.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			ibtnConveniosMGP.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.MostrarVentana(CONVENIOSMGP,"indicePagina=ID&Directorio=1")
				+ Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.POPUPDEESPERA);
			
		}

		public void RegistrarJScript()
		{
			// TODO:  Add InformeProyectos.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add InformeProyectos.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add InformeProyectos.Exportar implementation
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
			// TODO:  Add InformeProyectos.ValidarFiltros implementation
			return false;
		}

		#endregion
	}
}
