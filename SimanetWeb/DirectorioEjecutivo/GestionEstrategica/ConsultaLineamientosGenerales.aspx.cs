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
	/// Summary description for ConsultaLineamientosGenerales.
	/// </summary>
	public class ConsultaLineamientosGenerales : System.Web.UI.Page,IPaginaBase
	{
		#region Controles
		protected System.Web.UI.HtmlControls.HtmlImage ibtnCongemar;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnJemgemar;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnComiteEvaluacion;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnFuerzasNavales;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnDireccionEjecutiva;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnRequerimientosElaboracion;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion Controles		
		
		#region	Constantes Diagramna
		string ENCONSTRUCCION = Helper.MensajeAlert("EN CONSTRUCCIÓN");
		const string TEXTOTITULO = "LINEAMIENTOS GENERALES";
		
		const string JEMGEMAR = "01.03.02 LINEAMIENTOS JEMGEMAR.pdf";
		const string COMITEEVALUACION = "01.03.03 LINEAMIENTOS COMITE REVISION.pdf";
		const string FUERZASNAVALES = "01.03.04 LINEAMIENTOS DE LAS FFNN.pdf";
		const string DIRECCIONEJECUTIVA = "01.03.05 LINEAMIENTOS DEL DIRSIMA.doc";
		const string REQUERIMIENTOSELABORACION= "01.03.06 REQUERIMIENTOS DE MGP.pdf";
		#endregion
		
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
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionEstrategica",this.ToString(),"",Enumerados.NivelesErrorLog.I.ToString()));
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
			// TODO:  Add ConsultaLineamientosGenerales.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultaLineamientosGenerales.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add ConsultaLineamientosGenerales.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add ConsultaLineamientosGenerales.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			lblTitulo.Text = TEXTOTITULO;
		}

		public void LlenarJScript()
		{
			ibtnCongemar.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			ibtnCongemar.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,ENCONSTRUCCION);

			ibtnJemgemar.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			ibtnJemgemar.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.PopupMostrarArchivos(Utilitario.Constantes.RUTASIMANETESTRATEGICOLINEAMIENTO + JEMGEMAR));

			ibtnComiteEvaluacion.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			ibtnComiteEvaluacion.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.PopupMostrarArchivos(Utilitario.Constantes.RUTASIMANETESTRATEGICOLINEAMIENTO + COMITEEVALUACION));

			ibtnFuerzasNavales.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			ibtnFuerzasNavales.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.PopupMostrarArchivos(Utilitario.Constantes.RUTASIMANETESTRATEGICOLINEAMIENTO + FUERZASNAVALES));

			ibtnDireccionEjecutiva.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			ibtnDireccionEjecutiva.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.PopupMostrarArchivos(Utilitario.Constantes.RUTASIMANETESTRATEGICOLINEAMIENTO + DIRECCIONEJECUTIVA));

			ibtnRequerimientosElaboracion.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			ibtnRequerimientosElaboracion.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.PopupMostrarArchivos(Utilitario.Constantes.RUTASIMANETESTRATEGICOLINEAMIENTO + REQUERIMIENTOSELABORACION));
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultaLineamientosGenerales.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultaLineamientosGenerales.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultaLineamientosGenerales.Exportar implementation
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
			// TODO:  Add ConsultaLineamientosGenerales.ValidarFiltros implementation
			return false;
		}

		#endregion
	}
}
