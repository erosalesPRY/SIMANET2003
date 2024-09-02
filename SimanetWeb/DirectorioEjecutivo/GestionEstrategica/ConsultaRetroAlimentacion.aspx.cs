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
using SIMA.Interfaces;

namespace SIMA.SimaNetWeb.DirectorioEjecutivo.Gestion_Estrategica
{
	/// <summary>
	/// Summary description for ConsultaRetroAlimentacion.
	/// </summary>
	public class ConsultaRetroAlimentacion : System.Web.UI.Page, IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnIndicadoresGestion;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnBalanceScorecard;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnDescripcionGrafica;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnActasReunion;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnAcuerdosReunion;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnCursoProcesos;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion		
		
		#region Constantes
		const string TEXTOTITULO = "RETROALIMENTACION";
		string ENCONSTRUCCION = Utilitario.Helper.MensajeAlert("EN CONSTRUCCIÓN");
		const string INDICADORGESTION = "";
		const string BALANCESCORECARD = "";
		const string DESCRIPCIONGRAFICA = "";
		const string ACTASREUNION = "";
		const string ACUERDOSREUNION = "";		
		const string CURSOPROCESOS = "";
		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					//this.ConfigurarAccesoControles();
					
					this.LlenarJScript();

					this.LlenarDatos();
					

					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionEstrategica",this.ToString(),"Se consulto la Retroalimentación.",Enumerados.NivelesErrorLog.I.ToString()));
						
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
			// TODO:  Add ConsultaRetroAlimentacion.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultaRetroAlimentacion.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add ConsultaRetroAlimentacion.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add ConsultaRetroAlimentacion.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			lblTitulo.Text = TEXTOTITULO;			
		}

		public void LlenarJScript()
		{
			ibtnIndicadoresGestion.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			ibtnIndicadoresGestion.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,ENCONSTRUCCION);
	
			ibtnBalanceScorecard.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			ibtnBalanceScorecard.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,ENCONSTRUCCION);

			ibtnDescripcionGrafica.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			ibtnDescripcionGrafica.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,ENCONSTRUCCION);

			ibtnActasReunion.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			ibtnActasReunion.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,ENCONSTRUCCION);

			ibtnAcuerdosReunion.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			ibtnAcuerdosReunion.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,ENCONSTRUCCION);

			ibtnCursoProcesos.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			ibtnCursoProcesos.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,ENCONSTRUCCION);
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultaRetroAlimentacion.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultaRetroAlimentacion.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultaRetroAlimentacion.Exportar implementation
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
			// TODO:  Add ConsultaRetroAlimentacion.ValidarFiltros implementation
			return false;
		}

		#endregion
	}
}
