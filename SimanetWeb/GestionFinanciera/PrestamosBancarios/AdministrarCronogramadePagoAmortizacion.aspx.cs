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
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using NullableTypes;
using MetaBuilders.WebControls;

namespace SIMA.SimaNetWeb.GestionFinanciera.PrestamosBancarios
{
	/// <summary>
	/// Summary description for AdministrarCronogramadePagoAmortizacion.
	/// </summary>
	public class AdministrarCronogramadePagoAmortizacion : System.Web.UI.Page, IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion Controles

		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				this.ConfigurarAccesoControles();
				this.LlenarJScript();
				Helper.ReiniciarSession();
				this.LlenarCombos();
				this.LlenarDatos();
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionFinanciera",this.ToString(),"Se consultó Administración Cronograma de Pago Amortización",Enumerados.NivelesErrorLog.I.ToString()));				
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
				ltlMensaje.Text = Helper.MsgdbErrMostrarMesaje(true,oSIMAExcepcionIU.Error.ToString());
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
			// TODO:  Add AdministrarCronogramadePagoAmortizacion.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarCronogramadePagoAmortizacion.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add AdministrarCronogramadePagoAmortizacion.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add AdministrarCronogramadePagoAmortizacion.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add AdministrarCronogramadePagoAmortizacion.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add AdministrarCronogramadePagoAmortizacion.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarCronogramadePagoAmortizacion.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministrarCronogramadePagoAmortizacion.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarCronogramadePagoAmortizacion.Exportar implementation
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
			// TODO:  Add AdministrarCronogramadePagoAmortizacion.ValidarFiltros implementation
			return false;
		}

		#endregion
	}
}
