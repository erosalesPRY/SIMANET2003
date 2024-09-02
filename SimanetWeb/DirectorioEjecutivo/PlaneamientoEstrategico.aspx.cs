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
	/// Summary description for PlaneamientoEstrategico.
	/// </summary>
	public class PlaneamientoEstrategico : System.Web.UI.Page,IPaginaBase
	{
		#region Controles
		protected System.Web.UI.HtmlControls.HtmlImage imgProcesoEstrategico;
		protected System.Web.UI.HtmlControls.HtmlImage imgPlanEstrategico;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion Controles
		
		#region Constantes
		const string PROCESOESTRATEGICO = "GestionEstrategica/ConsultaProcesoEstrategico.aspx";
		const string PLANESTRATEGICO = "GestionEstrategica/ConsultarPlanEstrategicoObjetivosGenerales.aspx";
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
						this.ToString(),"Se consultó el Planeamiento Estrategico.",Enumerados.NivelesErrorLog.I.ToString()));
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
			// TODO:  Add PlaneamientoEstrategico.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add PlaneamientoEstrategico.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add PlaneamientoEstrategico.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add PlaneamientoEstrategico.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add PlaneamientoEstrategico.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			imgProcesoEstrategico.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			imgProcesoEstrategico.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.MostrarVentana(PROCESOESTRATEGICO,"")
				+ Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.POPUPDEESPERA);
			
			imgPlanEstrategico.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			imgPlanEstrategico.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.MostrarVentana(PLANESTRATEGICO,"")
				+ Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.POPUPDEESPERA);
		}

		public void RegistrarJScript()
		{
			// TODO:  Add PlaneamientoEstrategico.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add PlaneamientoEstrategico.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add PlaneamientoEstrategico.Exportar implementation
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
			// TODO:  Add PlaneamientoEstrategico.ValidarFiltros implementation
			return false;
		}

		#endregion
	}
}
