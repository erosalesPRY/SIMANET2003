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
using SIMA.EntidadesNegocio.GestionFinanciera;

namespace SIMA.SimaNetWeb.GestionFinanciera.CartasFianza
{
	/// <summary>
	/// Summary description for DetalleCargosPorFianza.
	/// </summary>
	public class DetalleCargosPorFianza : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		#region Constantes
			const string KEYIDDETCF = "idDetCF";
			const string KEYIDCARTAFZA = "idCartaFza";
			const string KEYIDPERIODO = "Periodo";
		#endregion

		#region Controles
			protected System.Web.UI.WebControls.Label Label2;
			protected System.Web.UI.WebControls.Label Label3;
			protected System.Web.UI.WebControls.Label Label4;
			protected System.Web.UI.WebControls.Label Label5;
			protected System.Web.UI.WebControls.TextBox txtNroFianza;
			protected System.Web.UI.WebControls.TextBox txtCentroOperativo;
			protected System.Web.UI.WebControls.TextBox txtBanco;
			protected System.Web.UI.WebControls.TextBox txtBeneficiario;
			protected System.Web.UI.WebControls.Label Label6;
			protected System.Web.UI.WebControls.Label Label8;
			protected System.Web.UI.WebControls.Label Label9;
			protected System.Web.UI.WebControls.Label Label12;
			protected System.Web.UI.WebControls.TextBox txtDiasTranscurridos;
			protected System.Web.UI.WebControls.Label Label16;
			protected eWorld.UI.NumericBox nMontoCargo;
			protected eWorld.UI.CalendarPopup CalFechaInicio;
			protected eWorld.UI.CalendarPopup CalFechaRenovacion;
			protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected eWorld.UI.CalendarPopup CalFechaVencimiento;
		protected System.Web.UI.WebControls.Label Label10;
		protected eWorld.UI.CalendarPopup CalFechaActual;
		protected System.Web.UI.WebControls.TextBox nMontoFza;
		protected System.Web.UI.WebControls.TextBox txtMoneda;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.Label Label15;
		protected System.Web.UI.WebControls.Label Label13;
		protected System.Web.UI.WebControls.TextBox txtDiasporVencer;
			protected System.Web.UI.WebControls.Label Label1;
		#endregion	

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarJScript();
					this.LlenarCombos();
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
					ltlMensaje.Text = Helper.MsgdbErrMostrarMesaje(true,oSIMAExcepcionDominio.Error.ToString());					
				}
				catch(Exception oException)
				{
					string debug = oException.Message.ToString();
					SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),SIMA.Utilitario.Constantes.CODIGOERRORGENERICO,oException.Message);
					Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
				}
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
			// TODO:  Add DetalleCargosPorFianza.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetalleCargosPorFianza.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetalleCargosPorFianza.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add DetalleCargosPorFianza.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add DetalleCargosPorFianza.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			this.txtDiasTranscurridos.Style[Utilitario.Constantes.ALINEAMIENTOTEXTO] = TextAlign.Right.ToString();
			this.txtDiasporVencer.Style[Utilitario.Constantes.ALINEAMIENTOTEXTO] = TextAlign.Right.ToString();
			this.nMontoCargo.Style[Utilitario.Constantes.ALINEAMIENTOTEXTO] = TextAlign.Right.ToString();
			this.nMontoFza.Style[Utilitario.Constantes.ALINEAMIENTOTEXTO] = TextAlign.Right.ToString();


		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetalleCargosPorFianza.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetalleCargosPorFianza.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetalleCargosPorFianza.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			if(CNetAccessControl.FindPage(Page.Request.Url.AbsolutePath.ToString()))
			{CNetAccessControl.LoadControls(this);}
			else
			{CNetAccessControl.RedirectPageError();}						
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add DetalleCargosPorFianza.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			// TODO:  Add DetalleCargosPorFianza.Agregar implementation
		}

		public void Modificar()
		{
			// TODO:  Add DetalleCargosPorFianza.Modificar implementation
		}

		public void Eliminar()
		{
			// TODO:  Add DetalleCargosPorFianza.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.Params[Utilitario.Constantes.KEYMODOPAGINA].ToString()) ;
			switch (oModoPagina)
			{
				case Enumerados.ModoPagina.N:
					this.CargarModoNuevo();
					break;
				case Enumerados.ModoPagina.M:
					this.CargarModoModificar();
					break;
				case Enumerados.ModoPagina.C:
					this.CargarModoModificar();
					Helper.BloquearControles(this);
					break;
			}			
			// TODO:  Add DetalleCargosPorFianza.CargarModoPagina implementation
		}

		public void CargarModoNuevo()
		{
			// TODO:  Add DetalleCargosPorFianza.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			CCartaFianza oCCartaFianza = new CCartaFianza();
			CartaFianzaBE oCartaFianzaBE = (CartaFianzaBE) oCCartaFianza.ConsultarDetalleCartaFianzayNotadeCargo(Convert.ToInt32(Page.Request.Params[KEYIDDETCF].ToString()),
																												Convert.ToInt32(Page.Request.Params[KEYIDCARTAFZA].ToString()),
																												Convert.ToInt32(Page.Request.Params[KEYIDPERIODO].ToString()));
			//CartaFianzaBE oCartaFianzaBE = (CartaFianzaBE) oCCartaFianza.ConsultarDetalleCartaFianzayNotadeCargo(Page.Request.Params[KEYIDDETCF].ToString(),Page.Request.Params[KEYIDCARTAFZA].ToString(),Page.Request.Params[KEYIDPERIODO].ToString());
			
			this.txtNroFianza.Text = oCartaFianzaBE.NroFianza.ToString();
			this.txtCentroOperativo.Text = oCartaFianzaBE.Centro.ToString();
			this.txtBanco.Text = oCartaFianzaBE.NombreEntidadFinanciera.ToString();
			this.txtBeneficiario.Text = oCartaFianzaBE.NombreBeneficiario.ToString();
			this.txtMoneda.Text = oCartaFianzaBE.Moneda.ToString();
			this.nMontoFza.Text = Convert.ToDouble(oCartaFianzaBE.MontoCartaFza).ToString(Utilitario.Constantes.FORMATODECIMAL4);

			this.nMontoCargo.Text = oCartaFianzaBE.MontoNota.ToString();
			this.CalFechaInicio.SelectedDate = Convert.ToDateTime(oCartaFianzaBE.FechaInicio);
			this.CalFechaRenovacion.SelectedDate = Convert.ToDateTime(oCartaFianzaBE.FechaApertura);
			this.CalFechaActual.SelectedDate = DateTime.Now.Date;
			this.CalFechaVencimiento.SelectedDate = Convert.ToDateTime(oCartaFianzaBE.FechaVencimiento);
			this.txtDiasTranscurridos.Text= oCartaFianzaBE.NroDiasTranscurridos.ToString();
			//this.txtDiasFaltantes.Text=oCartaFianzaBE.NroDiasFaltantes;
			this.txtDiasporVencer.Text=oCartaFianzaBE.NroDiasFaltantes.ToString();


			
			// TODO:  Add DetalleCargosPorFianza.CargarModoModificar implementation
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add DetalleCargosPorFianza.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add DetalleCargosPorFianza.ValidarCampos implementation
			return false;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add DetalleCargosPorFianza.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add DetalleCargosPorFianza.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion
	}
}
