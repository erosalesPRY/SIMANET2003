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
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using NullableTypes;
using SIMA.SimaNetWeb.InterfacesIU;

namespace SIMA.SimaNetWeb.DirectorioEjecutivo.Gestion_Estrategica
{
	/// <summary>
	/// Summary description for ConsultaIdentidad.
	/// </summary>
	public class ConsultaIdentidad : System.Web.UI.Page, IPaginaBase
	{
		#region Constantes
		const string TEXTOTITULO = "IDENTIDAD";
		#endregion Constantes
				
		#region	Constantes Diagramna
		private const string RUTAENTIDAD ="IDENTIDAD/";
		const string ESCUDO = "PE.I.1 ESCUDO SIMA-PERU.pdf";
		const string SLOGAN = "1.10 SLOGAN SIMA-PERU S.A..pdf";
		const string RESEÑAHISTORICA= "PE.I.4 RESEÑA SIMA-PERU.pdf";
		const string CADENAVALOR = "PE.I.11 Cadena de Valor.pdf";
		const string LEMA = "PE.I.2 LEMA SIMA-PERU.pdf";
		const string HIMNO = "PE.I.5 HIMNO SIMA-PERU.pdf";
		const string VIDEO = "VideoSima.avi";
		const string DIAGRAMAINFLUENCIA = "PE.I.10 Diagrama de Influencia.pdf";
		const string LINEASNEGOCIO = "PE.I.8 LINEAS DE NEGOCIO.pdf";
		const string LOGOTIPO = "PE.I.3 LOGOTIPO SIMA-PERU.pdf";
		const string POLKA = "PE.I.6 POLKA SIMA-PERU.pdf";
		const string ITERACCIONPROCESOS = "PE.I.12 Interaccion Procesos.pdf";
		const string ALCANCECERTIFICACION = "PE.I.9 Alcance de Certificacion ISO.pdf";
				
		#endregion

		#region Controles
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnEscudo;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnLema;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnLogotipo;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnReseña;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnHimno;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnPolka;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnLineasNegocio;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnAlcanceCertificacion;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnDiagramaInfluencia;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnCadenaValor;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnIteraccionProcesos;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion Controles
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					//this.ConfigurarAccesoControles();

					Helper.ReiniciarSession();

					this.LlenarJScript();

					this.LlenarDatos();


					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionEstrategica",this.ToString(),"Se consultó la identidad.",Enumerados.NivelesErrorLog.I.ToString()));
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
					SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Utilitario.Constantes.CODIGOERRORGENERICO,oException.Message);
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
			// TODO:  Add ConsultaIdentidad.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultaIdentidad.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add ConsultaIdentidad.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add ConsultaIdentidad.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			lblTitulo.Text = TEXTOTITULO;
		}
		

		public void LlenarJScript()
		{
			ibtnEscudo.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			ibtnEscudo.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.PopupMostrarArchivos(Helper.ObtenerRutaPDFs(Utilitario.Constantes.RUTAPDFS)+ RUTAENTIDAD +  ESCUDO));

			ibtnLema.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			ibtnLema.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.PopupMostrarArchivos(Helper.ObtenerRutaPDFs(Utilitario.Constantes.RUTAPDFS) +  RUTAENTIDAD + LEMA));

			ibtnLogotipo.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			ibtnLogotipo.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.PopupMostrarArchivos(Helper.ObtenerRutaPDFs(Utilitario.Constantes.RUTAPDFS) +  RUTAENTIDAD + LOGOTIPO));

			ibtnReseña.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			ibtnReseña.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.PopupMostrarArchivos(Helper.ObtenerRutaPDFs(Utilitario.Constantes.RUTAPDFS) +  RUTAENTIDAD + RESEÑAHISTORICA));

			ibtnHimno.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			ibtnHimno.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.PopupMostrarArchivos(Helper.ObtenerRutaPDFs(Utilitario.Constantes.RUTAPDFS) +  RUTAENTIDAD + HIMNO));

			ibtnPolka.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			ibtnPolka.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.PopupMostrarArchivos(Helper.ObtenerRutaPDFs(Utilitario.Constantes.RUTAPDFS) +  RUTAENTIDAD + POLKA));

			ibtnLineasNegocio.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			ibtnLineasNegocio.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.PopupMostrarArchivos(Helper.ObtenerRutaPDFs(Utilitario.Constantes.RUTAPDFS) +  RUTAENTIDAD + LINEASNEGOCIO));			

			ibtnAlcanceCertificacion.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			ibtnAlcanceCertificacion.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.PopupMostrarArchivos(Helper.ObtenerRutaPDFs(Utilitario.Constantes.RUTAPDFS) +  RUTAENTIDAD + ALCANCECERTIFICACION));

			ibtnDiagramaInfluencia.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			ibtnDiagramaInfluencia.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.PopupMostrarArchivos(Helper.ObtenerRutaPDFs(Utilitario.Constantes.RUTAPDFS) +  RUTAENTIDAD + DIAGRAMAINFLUENCIA));

			ibtnCadenaValor.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			ibtnCadenaValor.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.PopupMostrarArchivos(Helper.ObtenerRutaPDFs(Utilitario.Constantes.RUTAPDFS) +  RUTAENTIDAD + CADENAVALOR));

			ibtnIteraccionProcesos.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			ibtnIteraccionProcesos.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.PopupMostrarArchivos(Helper.ObtenerRutaPDFs(Utilitario.Constantes.RUTAPDFS) +  RUTAENTIDAD + ITERACCIONPROCESOS));
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultaIdentidad.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultaIdentidad.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultaIdentidad.Exportar implementation
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
			// TODO:  Add ConsultaIdentidad.ValidarFiltros implementation
			return false;
		}

		#endregion
	}
}
