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
using SIMA.EntidadesNegocio.GestionFinanciera;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using NullableTypes;
using MetaBuilders.WebControls;


namespace SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancierosPresupuestales
{
	/// <summary>
	/// Summary description for DefaultPresupuestoVarios.
	/// </summary>
	public class DefaultPresupuestoVarios : System.Web.UI.Page, IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.DropDownList ddlbPeriodo;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.DropDownList dddblMes;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnGananciasyPerdidas;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnFlujoCaja;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnBalanceGeneral;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnIngresosyEgresos;
		protected System.Web.UI.WebControls.Label ltlMensaje;
		#endregion Controles
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarCombos();					
					this.LlenarJScript();
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionFinanciera",this.ToString(),"Se consultó el Default de Presupuestos Varios.",Enumerados.NivelesErrorLog.I.ToString()));

					//this.LlenarGrillaOrdenamientoPaginacion(Utilitario.Constantes.VACIO,Utilitario.Constantes.INDICEPAGINADEFAULT);
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
			// TODO:  Add DefaultPresupuestoVarios.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DefaultPresupuestoVarios.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DefaultPresupuestoVarios.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add DefaultPresupuestoVarios.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add DefaultPresupuestoVarios.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add DefaultPresupuestoVarios.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DefaultPresupuestoVarios.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DefaultPresupuestoVarios.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DefaultPresupuestoVarios.Exportar implementation
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
			// TODO:  Add DefaultPresupuestoVarios.ValidarFiltros implementation
			return false;
		}

		#endregion
	}
}
