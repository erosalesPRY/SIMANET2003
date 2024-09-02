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
using SIMA.EntidadesNegocio.Secretaria.Directorio;
using SIMA.Controladoras.Secretaria.Directorio;
using SIMA.SimaNetWeb.InterfacesIU;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using NullableTypes;

namespace SIMA.SimaNetWeb.DirectorioEjecutivo
{
	/// <summary>
	/// Summary description for EstadosFinancieros.
	/// </summary>
	public class EstadosFinancieros : System.Web.UI.Page, IPaginaBase
	{
		#region Controles
		protected System.Web.UI.HtmlControls.HtmlImage ibtnGananciasyPerdidas;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnCartasFianzas;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnFlujoCaja;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnPrestamosBancarios;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnBalanceGeneral;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnCuentasCobrarPagar;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnProyectosProvisionarLiquidar;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion Controles

		#region constantes

		string ENCONSTRUCCION = Helper.MensajeAlert("EN CONSTRUCCIÓN");
		
		const string URLESTADOSFINANCIEROSCONTABLES="../GestionFinanciera/EstadosFinancieros/EstadosFinancierosCorporativo.aspx?";

		const string ESTADOSFINANCIEROS = "../GestionFinanciera/EstadosFinancieros/Directorio/Default.aspx?";
		const string CARTASCREDITO ="../GestionFinanciera/CartasCredito/ConsultarCartasdeCreditoporBanco.aspx";
		const string CARTASFIANZAS ="../GestionFinanciera/CartasFianza/ConsultarCartaFianzaporBanco.aspx?";
		const string PRESTAMOS ="../GestionFinanciera/PrestamosBancarios/ConsultarPrestamosporBanco.aspx";
		const string LETRASCAMBIO ="../GestionFinanciera/DescuentoLetras/ConsultarResumedeLetrasporTipo.aspx?";
		const string URLESTADOSFINANCIEROSCUENTASPORLIQUIDARPROVISIONAR = "../GestionFinanciera/EstadosFinancieros/Directorio/DefaultLiquidados.aspx?";

		const string KEYQFLAGDIRECTORIO= "FlagDirectorio";
		const string KEYQMOSTRARTODO = "MostrarTodo";
		const string VALORSI = "SI";
		const string KEYQIDUSUARIO = "IdUsuario";
		const string KEYQNUEVOSSOLES = "MILNS";

		DateTime FechaSesion;
		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();

					this.CapturaFechaCierre();

					this.LlenarJScript();                    
					this.LlenarDatos();
					Helper.ReiniciarSession();

					LogAplicativo.GrabarLogAplicativoArchivo(
						new LogAplicativo(CNetAccessControl.GetUserName(),"Directorio Ejecutivo",
						this.ToString(),"Se consultó los estados financieros.",Enumerados.NivelesErrorLog.I.ToString()));

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
					SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),SIMA.Utilitario.Constantes.CODIGOERRORGENERICO,oException.Message);
					Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
				}
			}			
		}

		private void CapturaFechaCierre()
		{			
			FechaSesion = Helper.FechaSimanet.ObtenerFechaSesion();
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
			// TODO:  Add EstadosFinancieros.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add EstadosFinancieros.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add EstadosFinancieros.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add EstadosFinancieros.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			ibtnCuentasCobrarPagar.Visible = false;
			ibtnProyectosProvisionarLiquidar.Visible = false;
			if(Session[KEYQNUEVOSSOLES]== null)	
			{
				Session[KEYQNUEVOSSOLES] = Utilitario.Constantes.SIVERMILES;	
			}
		}

		public void LlenarJScript()
		{
			ibtnGananciasyPerdidas.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			ibtnGananciasyPerdidas.Attributes.Add(
				Utilitario.Constantes.EVENTOCLICK,
				Helper.MostrarVentana(ESTADOSFINANCIEROS+"MOSTRARBOTON"+Utilitario.Constantes.SIGNOIGUAL+"NO",
				Helper.EstadosFinancierosQuery(FechaSesion,Utilitario.Enumerados.EstadosFinancieros.idFormatoEstadodeGananciasyPerdidas,Utilitario.Enumerados.EstadosFinancierosAcumulado.AcumuladoNo,Utilitario.Enumerados.EstadosFinancierosNivelExpande.Nivel0))
				+ Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.POPUPDEESPERA);
		
			this.ibtnFlujoCaja.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
				Utilitario.Constantes.POPUPDEESPERA + 
				Utilitario.Constantes.HISTORIALADELANTE + Utilitario.Constantes.SIGNOPUNTOYCOMA + 
				Helper.MostrarVentana(URLESTADOSFINANCIEROSCONTABLES,
										Helper.EstadosFinancierosQuery(
												FechaSesion,
												Utilitario.Enumerados.EstadosFinancieros.idFormatoFlujodeCaja,
												Utilitario.Enumerados.EstadosFinancierosAcumulado.AcumuladoNo,
												Utilitario.Enumerados.EstadosFinancierosNivelExpande.Nivel0)));

			//ibtnFlujoCaja.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			/*ibtnFlujoCaja.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.MostrarVentana(ESTADOSFINANCIEROS,
				Helper.EstadosFinancierosQuery(FechaSesion,Utilitario.Enumerados.EstadosFinancieros.idFormatoFlujodeCaja,Utilitario.Enumerados.EstadosFinancierosAcumulado.AcumuladoNo,Utilitario.Enumerados.EstadosFinancierosNivelExpande.Nivel0))
				+ Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.POPUPDEESPERA);*/
      

			this.ibtnBalanceGeneral.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
				Helper.MostrarVentana(URLESTADOSFINANCIEROSCONTABLES,
										Helper.EstadosFinancierosQuery(FechaSesion,
										Utilitario.Enumerados.EstadosFinancieros.idFormatoBalanceGeneral,
										Utilitario.Enumerados.EstadosFinancierosAcumulado.AcumuladoSi,
										Utilitario.Enumerados.EstadosFinancierosNivelExpande.Nivel0)));
			
			ibtnBalanceGeneral.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.POPUPDEESPERA + Helper.HistorialIrAdelantePersonalizado(""));

			/*ibtnBalanceGeneral.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.MostrarVentana(ESTADOSFINANCIEROS,
				Helper.EstadosFinancierosQuery(FechaSesion,Utilitario.Enumerados.EstadosFinancieros.idFormatoBalanceGeneral,Utilitario.Enumerados.EstadosFinancierosAcumulado.AcumuladoSi,Utilitario.Enumerados.EstadosFinancierosNivelExpande.Nivel0))
				+ Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.POPUPDEESPERA);
				demo
				*/

			ibtnCuentasCobrarPagar.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			string Query ="Periodo=" + Helper.FechaSimanet.ObtenerFechaSesion().Year.ToString() + 
							"&Mes=" + Helper.FechaSimanet.ObtenerFechaSesion().Month.ToString() +
							Utilitario.Constantes.SIGNOAMPERSON + KEYQFLAGDIRECTORIO + Utilitario.Constantes.POSICIONINDEXUNO;
			this.ibtnCuentasCobrarPagar.Attributes.Add
				(
				Utilitario.Constantes.EVENTOCLICK,
				Utilitario.Constantes.POPUPDEESPERA + 
				Helper.MostrarVentana("../GestionFinanciera/CuentasPorCobrarPagar/Directorio/ConsultarCuentasPorCobrarPagarResumen.aspx?",Query));

			ibtnCartasFianzas.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			ibtnCartasFianzas.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.MostrarVentana(CARTASFIANZAS,
				KEYQMOSTRARTODO
				+ Utilitario.Constantes.SIGNOIGUAL
				+ VALORSI
				+ Utilitario.Constantes.SIGNOAMPERSON
				+ KEYQIDUSUARIO
				+ Utilitario.Constantes.SIGNOIGUAL
				+ CNetAccessControl.GetIdUser().ToString()
				)
				+ Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.POPUPDEESPERA);

			ibtnPrestamosBancarios.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			ibtnPrestamosBancarios.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.MostrarVentana(PRESTAMOS,"")
				+ Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.POPUPDEESPERA);

			ibtnProyectosProvisionarLiquidar.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			ibtnProyectosProvisionarLiquidar.Attributes.Add(
				Utilitario.Constantes.EVENTOCLICK,Helper.MostrarVentana(
				"../GestionFinanciera/ProyectosPorProvisionarLiquidar/ConsultarProyectosGeneral.aspx",""));

			/*ibtnProyectosProvisionarLiquidar.Attributes.Add(
				Utilitario.Constantes.EVENTOCLICK,Helper.MostrarVentana(
					URLESTADOSFINANCIEROSCUENTASPORLIQUIDARPROVISIONAR,
					Helper.EstadosFinancierosQuery(FechaPeriodo,Utilitario.Enumerados.EstadosFinancieros.idFormatoFlujodeCaja,
					Utilitario.Enumerados.EstadosFinancierosAcumulado.AcumuladoNo,Utilitario.Enumerados.EstadosFinancierosNivelExpande.Nivel0)));*/
		}

		public void RegistrarJScript()
		{
			// TODO:  Add EstadosFinancieros.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add EstadosFinancieros.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add EstadosFinancieros.Exportar implementation
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
			// TODO:  Add EstadosFinancieros.ValidarFiltros implementation
			return false;
		}

		#endregion
	}
}
