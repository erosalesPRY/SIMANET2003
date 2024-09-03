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
	/// Summary description for DetallePresupuestoVentas.
	/// </summary>
	public class DetallePresupuestoVentas : System.Web.UI.Page, IPaginaBase, IPaginaMantenimento
	{
		#region Controles
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion Controles

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					this.LlenarJScript();					
					this.CargarModoPagina();	
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
			// TODO:  Add DetallePresupuestoVentas.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetallePresupuestoVentas.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetallePresupuestoVentas.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add DetallePresupuestoVentas.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add DetallePresupuestoVentas.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add DetallePresupuestoVentas.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetallePresupuestoVentas.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetallePresupuestoVentas.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetallePresupuestoVentas.Exportar implementation
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
			// TODO:  Add DetallePresupuestoVentas.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			// TODO:  Add DetallePresupuestoVentas.Agregar implementation
		}

		public void Modificar()
		{
			// TODO:  Add DetallePresupuestoVentas.Modificar implementation
		}

		public void Eliminar()
		{
			// TODO:  Add DetallePresupuestoVentas.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			// TODO:  Add DetallePresupuestoVentas.CargarModoPagina implementation
		}

		public void CargarModoNuevo()
		{
			// TODO:  Add DetallePresupuestoVentas.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			// TODO:  Add DetallePresupuestoVentas.CargarModoModificar implementation
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add DetallePresupuestoVentas.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add DetallePresupuestoVentas.ValidarCampos implementation
			return false;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add DetallePresupuestoVentas.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add DetallePresupuestoVentas.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion
	}
}
