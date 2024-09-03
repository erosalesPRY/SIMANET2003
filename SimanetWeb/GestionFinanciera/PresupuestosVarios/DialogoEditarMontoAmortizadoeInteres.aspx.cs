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
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using SIMA.EntidadesNegocio.GestionFinanciera;
using NetAccessControl;

namespace SIMA.SimaNetWeb.GestionFinanciera.PresupuestoVarios
{
	/// <summary>
	/// Summary description for DialogoEditarMontoAmortizadoeInteres.
	/// </summary>
	public class DialogoEditarMontoAmortizadoeInteres : System.Web.UI.Page, IPaginaBase
	{
		#region Constantes
		const string  KEYMONTOAMORTIZA ="ma";
		const string KEYMONTOINTERES ="mi";
		const string KEYNOMBREBANCO ="nb";
		const string KEYOCULTAR ="Ocultar";
		#endregion Constantes

		#region Controles
		protected System.Web.UI.WebControls.Label lblInformeEmitido;
		protected System.Web.UI.WebControls.Label Label1;
		protected eWorld.UI.NumericBox nMontoAmortiza;
		protected eWorld.UI.NumericBox nMontoInteres;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label lblEntidad;
		protected System.Web.UI.HtmlControls.HtmlTable tblToolbar;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion Controles
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					this.nMontoAmortiza.Text = Page.Request.Params[KEYMONTOAMORTIZA].ToString();
					this.nMontoInteres.Text = Page.Request.Params[KEYMONTOINTERES].ToString();
					this.lblEntidad.Text =Page.Request.Params[KEYNOMBREBANCO].ToString();
					if (Page.Request.Params[KEYOCULTAR]!=null)
					{
						this.tblToolbar.Style.Add(Utilitario.Constantes.DISPLAY,Utilitario.Constantes.NONE);
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
			// TODO:  Add DialogoEditarMontoAmortizadoeInteres.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DialogoEditarMontoAmortizadoeInteres.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DialogoEditarMontoAmortizadoeInteres.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add DialogoEditarMontoAmortizadoeInteres.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add DialogoEditarMontoAmortizadoeInteres.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add DialogoEditarMontoAmortizadoeInteres.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DialogoEditarMontoAmortizadoeInteres.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DialogoEditarMontoAmortizadoeInteres.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DialogoEditarMontoAmortizadoeInteres.Exportar implementation
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
			// TODO:  Add DialogoEditarMontoAmortizadoeInteres.ValidarFiltros implementation
			return false;
		}

		#endregion
	}
}
