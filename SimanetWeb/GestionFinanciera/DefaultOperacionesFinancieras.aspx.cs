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
using SIMA.Controladoras.General;
using SIMA.Controladoras.GestionFinanciera;

using SIMA.Utilitario;
using NetAccessControl;
using SIMA.ManejadorExcepcion;
using SIMA.Log;

namespace SIMA.SimaNetWeb.GestionFinanciera
{
	/// <summary>
	/// Summary description for DefaultOperacionesFinancieras.
	/// </summary>
	public class DefaultOperacionesFinancieras : System.Web.UI.Page,IPaginaBase
	{
		#region Constantes y variables
		
		const string PAGLINEACREDITO ="LineasdeCredito/ConsultarLineasdeCredito.aspx";
		const string PAGCARTAFIANZA ="CartasFianza/ConsultarCartaFianzaporBanco.aspx";
		const string PAGCARTACREDITO ="CartasCredito/ConsultarCartasdeCreditoporBanco.aspx";

		const string PAGPRESTAMOS ="PrestamosBancarios/ConsultarPrestamosporBanco.aspx";
		const string PAGLETRAS ="DescuentoLetras/ConsultarResumedeLetrasporTipo.aspx?";
		const string PAGCUENTASBANCARIAS ="CuentasBancarias/ConsultarSaldodeCuentaBancariaporCentro.aspx?";
		//QUERYSTRING
		const string KEYIDNOMBRETIPO ="NomTipo";

		const string MENSAJEDSCTO ="DESCUENTO DE LETRAS";
		
		#endregion

		#region Controles
			protected System.Web.UI.WebControls.Label lblRutaPagina;
			protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnCartasCredito;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnCartasFianzas;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnPrestamosBancarios;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnLetrasCambio;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.HtmlControls.HtmlImage btnCuentasBancarias;
		protected System.Web.UI.HtmlControls.HtmlImage btnValores;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnLeneadeCredito;
			protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				if(!Page.IsPostBack)
				{
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarJScript();
				}				
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
				ltlMensaje.Text = Helper.MsgdbErrMostrarMesaje(true,oSIMAExcepcionDominio.Error.ToString());					
			}
			catch(Exception oException)
			{
				string debug = oException.Message.ToString();
				SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
				Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
			}
			// Put user code to initialize the page here
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
			// TODO:  Add DefaultOperacionesFinancieras.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DefaultOperacionesFinancieras.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DefaultOperacionesFinancieras.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add DefaultOperacionesFinancieras.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add DefaultOperacionesFinancieras.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			///this.hlkLineadeCredito.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			//this.hlkLineadeCredito.NavigateUrl = PAGLINEACREDITO;
			this.ibtnLeneadeCredito.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.HISTORIALADELANTE + Helper.MostrarVentana(PAGLINEACREDITO,Utilitario.Constantes.VACIO));
			this.ibtnLeneadeCredito.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN, Utilitario.Constantes.POPUPDEESPERA);
			this.ibtnCartasCredito.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.HISTORIALADELANTE + Helper.MostrarVentana(PAGCARTACREDITO,Utilitario.Constantes.VACIO));
			this.ibtnCartasCredito.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN, Utilitario.Constantes.POPUPDEESPERA);
			this.ibtnCartasFianzas.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.HISTORIALADELANTE + Helper.MostrarVentana(PAGCARTAFIANZA,Utilitario.Constantes.VACIO));
			this.ibtnCartasFianzas.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN, Utilitario.Constantes.POPUPDEESPERA);
			//this.ibtnLetrasCambio.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.HISTORIALADELANTE +  Helper.MostrarVentana(PAGLETRAS,KEYIDNOMBRETIPO + Utilitario.Constantes.SIGNOIGUAL + "DESCUENTO DE LETRAS"));
			this.ibtnLetrasCambio.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.HISTORIALADELANTE +  Helper.MostrarVentana(PAGLETRAS,KEYIDNOMBRETIPO + Utilitario.Constantes.SIGNOIGUAL + MENSAJEDSCTO));
			this.ibtnLetrasCambio.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN, Utilitario.Constantes.POPUPDEESPERA);
			
			this.ibtnPrestamosBancarios.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.HISTORIALADELANTE + Helper.MostrarVentana(PAGPRESTAMOS,Utilitario.Constantes.VACIO));
			this.ibtnPrestamosBancarios.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN, Utilitario.Constantes.POPUPDEESPERA);
			this.btnCuentasBancarias.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.HISTORIALADELANTE + Helper.MostrarVentana(PAGCUENTASBANCARIAS,Utilitario.Constantes.VACIO));
			this.btnCuentasBancarias.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN, Utilitario.Constantes.POPUPDEESPERA);
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DefaultOperacionesFinancieras.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DefaultOperacionesFinancieras.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DefaultOperacionesFinancieras.Exportar implementation
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
			// TODO:  Add DefaultOperacionesFinancieras.ValidarFiltros implementation
			return false;
		}

		#endregion
	}
}
