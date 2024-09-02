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
using SIMA.EntidadesNegocio;
using SIMA.EntidadesNegocio.General;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using NullableTypes;
using MetaBuilders.WebControls;
using DayPilot.Web.Ui;
using System.Globalization;
using System.Threading;

namespace SIMA.SimaNetWeb.General
{
	/// <summary>
	/// Summary description for AdministrarDetalleAgenda.
	/// </summary>
	public class AdministrarDetalleAgenda : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{

		protected System.Web.UI.WebControls.Image Image1;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtPortaRetrato;
		protected System.Web.UI.WebControls.TextBox txtApellidos;
		protected System.Web.UI.WebControls.TextBox txtCargo;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Literal ltlMensaje;

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					this.LlenarJScript();
					Helper.ReiniciarSession();
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"General",this.ToString(),"Se consultó Agenda.",Enumerados.NivelesErrorLog.I.ToString()));
					this.LlenarDatos();

					this.LlenarGrillaOrdenamientoPaginacion("",Utilitario.Constantes.INDICEPAGINADEFAULT);
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
					ltlMensaje.Text = Helper.MsgdbErrMostrarMesaje (true,oSIMAExcepcionDominio.Error.ToString());					
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
			// TODO:  Add AdministrarDetalleAgenda.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarDetalleAgenda.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add AdministrarDetalleAgenda.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add AdministrarDetalleAgenda.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
				
			UsuarioBE oUsuarioBE = (UsuarioBE) ((CAgenda) new CAgenda()).ConsultarFichadeDatos(CNetAccessControl.GetIdUser());
			this.txtPortaRetrato.Text = oUsuarioBE.NroPersonal.ToString();
			this.txtApellidos.Text = oUsuarioBE.AppellidosNombres.ToString();
		}

		public void LlenarJScript()
		{
			// TODO:  Add AdministrarDetalleAgenda.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarDetalleAgenda.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministrarDetalleAgenda.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarDetalleAgenda.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add AdministrarDetalleAgenda.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add AdministrarDetalleAgenda.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			// TODO:  Add AdministrarDetalleAgenda.Agregar implementation
		}

		public void Modificar()
		{
			// TODO:  Add AdministrarDetalleAgenda.Modificar implementation
		}

		public void Eliminar()
		{
			// TODO:  Add AdministrarDetalleAgenda.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			// TODO:  Add AdministrarDetalleAgenda.CargarModoPagina implementation
		}

		public void CargarModoNuevo()
		{
			// TODO:  Add AdministrarDetalleAgenda.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			// TODO:  Add AdministrarDetalleAgenda.CargarModoModificar implementation
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add AdministrarDetalleAgenda.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add AdministrarDetalleAgenda.ValidarCampos implementation
			return false;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add AdministrarDetalleAgenda.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add AdministrarDetalleAgenda.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion
	}
}
