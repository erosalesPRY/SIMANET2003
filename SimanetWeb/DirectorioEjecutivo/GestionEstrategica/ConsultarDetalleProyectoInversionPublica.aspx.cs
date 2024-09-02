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
using SIMA.SimaNetWeb.InterfacesIU;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using SIMA.Interfaces;

namespace SIMA.SimaNetWeb.DirectorioEjecutivo.GestionEstrategica
{
	/// <summary>
	/// Summary description for ConsultarDetalleProyectoInversionPublica.
	/// </summary>
	public class ConsultarDetalleProyectoInversionPublica : System.Web.UI.Page, IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblCodigoProyecto;
		protected System.Web.UI.WebControls.TextBox txtCodigoProyecto;
		protected System.Web.UI.WebControls.Label lblDescripcionAbreviada;
		protected System.Web.UI.WebControls.TextBox txtDescripcionAbreviada;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator RqdvDescripcionAbreviada;
		protected System.Web.UI.WebControls.Label lblNombreArea;
		protected System.Web.UI.WebControls.DropDownList ddldArea;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator RqdvArea;
		protected System.Web.UI.WebControls.Label lblMontoAsignado;
		protected System.Web.UI.WebControls.TextBox txtMontoAsignado;
		protected eWorld.UI.NumericBox nbMontoAsignado;
		protected System.Web.UI.WebControls.Label lblMoneda;
		protected System.Web.UI.WebControls.DropDownList ddlbMoneda;
		protected System.Web.UI.WebControls.Label lblTipoCambio;
		protected System.Web.UI.WebControls.TextBox txtTipoCambio;
		protected System.Web.UI.WebControls.Label lblMontoAsignadoSoles;
		protected System.Web.UI.WebControls.TextBox txtMontoAsignadoSoles;
		protected System.Web.UI.WebControls.Label lblFinanciamiento;
		protected System.Web.UI.WebControls.DropDownList ddlbFuenteFinanciamiento;
		protected System.Web.UI.WebControls.Label lblFechaInicio;
		protected System.Web.UI.WebControls.TextBox txtFechaInicio;
		protected eWorld.UI.CalendarPopup CalFechaInicio;
		protected System.Web.UI.WebControls.Label lblFechaTermino;
		protected System.Web.UI.WebControls.TextBox txtFechaTermino;
		protected eWorld.UI.CalendarPopup CalFechaTermino;
		protected System.Web.UI.WebControls.Label lblEstado;
		protected System.Web.UI.WebControls.DropDownList ddlbEstado;
		protected System.Web.UI.WebControls.Label lblAvanceFisicoUltimoDirectorio;
		protected System.Web.UI.WebControls.TextBox txtAvanceFisicoUltimoDirectorio;
		protected eWorld.UI.NumericBox nbAvanceFisicoAnterior;
		protected System.Web.UI.WebControls.Label lblSignoPorcentaje1;
		protected System.Web.UI.WebControls.DomValidators.RangeDomValidator rrdvAvanceFisicoAnterior;
		protected System.Web.UI.WebControls.Label lblAvanceFisicoActual;
		protected System.Web.UI.WebControls.TextBox txtAvanceFisicoActual;
		protected eWorld.UI.NumericBox nbAvanceFisicoActual;
		protected System.Web.UI.WebControls.Label lblSignoPorcentaje2;
		protected System.Web.UI.WebControls.DomValidators.RangeDomValidator rrdvAvanceFisicoActual;
		protected System.Web.UI.WebControls.Label lblRutaImagen;
		protected System.Web.UI.WebControls.Image imgProyecto;
		protected System.Web.UI.WebControls.Label lblDescripcion;
		protected System.Web.UI.WebControls.TextBox txtDescripcionDetallada;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary DomValidationSummary1;
		protected System.Web.UI.HtmlControls.HtmlTableRow ControlTablaFilaFechaTermino;
		protected System.Web.UI.HtmlControls.HtmlTableRow ControlTablaFilaEstado;
		protected System.Web.UI.HtmlControls.HtmlTableRow ControlTablaFilaAvanceFisicoUltimo;
		protected System.Web.UI.HtmlControls.HtmlTableRow ControlTablaFilaAvanceFisicoActual;
		protected System.Web.UI.HtmlControls.HtmlTableRow ControlTablaFilaRutaImagen;
		protected System.Web.UI.HtmlControls.HtmlInputFile filMyFile;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hImagen;
		protected System.Web.UI.WebControls.Literal ltlMensaje;

		#endregion Controles
	
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
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionEstrategica",this.ToString(),"Se consulto el Detalle del Proyecto de Inversión Pública.",Enumerados.NivelesErrorLog.I.ToString()));
						
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
			// TODO:  Add ConsultarDetalleProyectoInversionPublica.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarDetalleProyectoInversionPublica.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add ConsultarDetalleProyectoInversionPublica.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add ConsultarDetalleProyectoInversionPublica.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add ConsultarDetalleProyectoInversionPublica.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarDetalleProyectoInversionPublica.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarDetalleProyectoInversionPublica.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarDetalleProyectoInversionPublica.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarDetalleProyectoInversionPublica.Exportar implementation
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
			// TODO:  Add ConsultarDetalleProyectoInversionPublica.ValidarFiltros implementation
			return false;
		}

		#endregion
	}
}
