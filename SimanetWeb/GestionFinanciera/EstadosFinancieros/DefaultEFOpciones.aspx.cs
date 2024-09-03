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


namespace SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancieros
{
	/// <summary>
	/// Summary description for DefaultEFOpciones.
	/// </summary>
	public class DefaultEFOpciones : System.Web.UI.Page,IPaginaBase
	{
		#region Constantes
		const string KEYQIDEMPRESA = "idEmp";
		const string KEYIDCENTRO ="IdCentro";
		const string NOMBRECENTRO ="NombreCentro";
		const string KEYQESOBSERVACION="Observacion";
		const string KEYQIDFORMATO = "IdFormato";
		const string KEYQIDNOMBREFORMATO = "NFormato";
		const string KEYQIDREPORTE = "IdReporte";
		const string KEYQIDACUMULADO = "Acumulado";
		const string KEYQIDNIVELEXPANDE = "NivelExp";
		const string KEYQIDCLASIFICACIONRUBRO = "RubroClasf";	
		const string KEYQFLAGDIRECTORIO= "FlagDirectorio";

		const string KEYQNUEVOSSOLES = "MILNS";
		const string NOVERMILES = "NO";
		const string MONTOMILES = "ESTADOS FINANCIEROS (En miles de NS)";
		const string MONTONOMILES = "ESTADOS FINANCIEROS (En NS)";

		const string KEYQIDFECHA = "efFecha";
		const string KEYQIDNOMBREMES = "NombreMes";

		//Tipo de Opcion Contable o Presupuestal
		const string KEYIDTIPOOPCION ="idOpcion";
		const string NOMBRETIPOOPCION ="NombreOpcion";

		//Cuentas para el presupuesto
		const string CUENTASCC = "ctaGrpCC";
		const string NOMBREPRESUPUESTO = "NomPresup";

		//const string URLESTADOSFINANCIEROSCUENTASPORLIQUIDARPROVISIONAR="../ProyectosPorProvisionarLiquidar/ConsultarProyectosGeneral.aspx?";
		const string URLESTADOSFINANCIEROSCUENTASPORLIQUIDARPROVISIONAR="Directorio/DefaultLiquidados.aspx?";

		const string URLESTADOSFINANCIEROSCONTABLES="EstadosFinancierosCorporativo.aspx?";
		const string URLESTADOSFINANCIEROSCONTABLESDIRECORIO="Directorio/Default.aspx?";
		const string URLADMINITRACIONOBSERVACIONESCTASCOBRARPAGAR="../CuentasPorCobrarPagar/Directorio/DefaultAdministrarObservacionesCtasCobrarPagar.aspx?";
		const string URLADMINITRACIONCONCEPTOSEEFF="../EstadosFinancieros/Directorio/DefaultConcepto.aspx";

		//const string URLESTADOSFINANCIEROSCTASPORCOBRARPAGAR = "../CuentasPorCobrarPagar/ConsultarCuentasporCobraryPagarResumen.aspx?";
		const string URLESTADOSFINANCIEROSCTASPORCOBRARPAGAR = "../CuentasPorCobrarPagar/Directorio/ConsultarCuentasPorCobrarPagarResumen.aspx?";
		//Gastos de Administracion
		const string URLEVALUACIONGASTOSDEADMINISTRACION="../PresupuestoAdministrativo/ConsultarPresupuesto.aspx?";

		//TIPOS DE PRESUPUESTO
		const string KEYQIDTIPOPRESUPUESTO = "TipoPreupuesto";
		const string URLPRESUPUESTO="../PresupuestovARIOS/DefaultPresupuesto.aspx?";
		
		//Pagina de Gastos de Personal
		const string URLGASTOSDEPERSONAL="../PresupuestoVarios/ConsultarPresupuestodePersonal.aspx?";
		DateTime FechaPeriodo;

		//Nivel de Resume del Presupuesto
		const string KEYQIDNIVELRESUMEN = "NivelResumen";
		const string INGRESOSYEGRESOS = "IngEgr";

		//Constantes para el Directorio
		const string GANANCIASYPERDIDAS ="0";
		const string FLUJOCAJA ="1";
		const string BALANCEGENERAL ="2";

		//Otros
		const string GLOSA ="Glosa";
		const string VALORPERIODO ="Periodo";

		#endregion

		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.DropDownList dddblMes;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.DropDownList ddlbPeriodo;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.CheckBox chbxFlag;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hValorChbx;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnProyectosProvisionarLiquidar;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnGananciasyPerdidas;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnBalanceGeneral;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnFlujoCaja;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnCtasPorCobraryPagar;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnIngresosyEgresos;
		protected System.Web.UI.HtmlControls.HtmlImage imgAdmConceptos;
		protected System.Web.UI.WebControls.HyperLink HyperLink1;		
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarDatos();
					this.LlenarCombos();
					this.LlenarJScript();
					//this.VerificaLinksParaDirectorio();
					this.VerificarCheckBox();
	
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionFinanciera",this.ToString(),"Se consultó Carta de Crédito.",Enumerados.NivelesErrorLog.I.ToString()));
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
			// Put user code to initialize the page here
		}
		/*
		
				private void VerificaLinksParaDirectorio()
				{
					if(Page.Request.Params[INGRESOSYEGRESOS] != null)  
					{
						FilaIngresosEgresos.Style.Add("display","none");
											
						if(Page.Request.Params[INGRESOSYEGRESOS] == GANANCIASYPERDIDAS)  
						{
							FilaFlujoCaja.Style.Add("display","none");
							FilaBalanceGeneral.Style.Add("display","none");
						}

						if(Page.Request.Params[INGRESOSYEGRESOS] == FLUJOCAJA)  
						{
											FilaGananciasYPerdidas.Style.Add("display","none");
							FilaBalanceGeneral.Style.Add("display","none");
						}

						if(Page.Request.Params[INGRESOSYEGRESOS] == BALANCEGENERAL)  
						{
							FilaFlujoCaja.Style.Add("display","none");
							FilaGananciasYPerdidas.Style.Add("display","none");
						}
					}
				}
		*/
		private void GeneraFecha()
		{FechaPeriodo = Convert.ToDateTime(DateTime.DaysInMonth(Convert.ToInt32(this.ddlbPeriodo.SelectedValue),Convert.ToInt32(this.dddblMes.SelectedValue)) + Utilitario.Constantes.SEPARADORFECHA + this.dddblMes.SelectedValue.PadLeft(2,'0') + Utilitario.Constantes.SEPARADORFECHA + this.ddlbPeriodo.SelectedValue.ToString());}

		private string ObtenerGlosaSituacionFormato(int idFormato,int idCentroOperativo,int Periodo,int mes)
		{
			CFormatoDetalleEjercicio oCFormatoDetalleEjercicio = new CFormatoDetalleEjercicio();
			DataTable dt = oCFormatoDetalleEjercicio.ConsultarFormatoDetalleEjercicio(idFormato,idCentroOperativo,Periodo,mes);
			if (dt !=null)
			{
				return dt.Rows[0][GLOSA].ToString();
			}
			else
			{
				return String.Empty;
			}
		}

		private void LlenarJScrtiptEstadosFinancierosContables()
		{
			this.GeneraFecha();
			#region Estados Financieros

			string Query ="Periodo=" + this.ddlbPeriodo.SelectedValue.ToString() + "&Mes=" + 
				this.dddblMes.SelectedValue.ToString() + Utilitario.Constantes.SIGNOAMPERSON +
				KEYQFLAGDIRECTORIO +  Utilitario.Constantes.SIGNOIGUAL + 
				Utilitario.Constantes.POSICIONINDEXCERO;
			string QueryEEFF =KEYQESOBSERVACION + Utilitario.Constantes.SIGNOIGUAL+ Page.Request.QueryString[KEYQESOBSERVACION].ToString() + Utilitario.Constantes.SIGNOAMPERSON ;

			this.ibtnGananciasyPerdidas.Style.Add(Utilitario.Constantes.CURSOR,Utilitario.Constantes.TIPOCURSORMANO);
			//this.ibtnGananciasyPerdidas.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.POPUPDEESPERA + Helper.HistorialIrAdelantePersonalizado("ddlbPeriodo","dddblMes") + ";" + Helper.MostrarVentana(URLESTADOSFINANCIEROSCONTABLES+"MOSTRARBOTON"+Utilitario.Constantes.SIGNOIGUAL+"NO",Helper.EstadosFinancierosQuery(FechaPeriodo,Utilitario.Enumerados.EstadosFinancieros.idFormatoEstadodeGananciasyPerdidas,Utilitario.Enumerados.EstadosFinancierosAcumulado.AcumuladoNo,Utilitario.Enumerados.EstadosFinancierosNivelExpande.Nivel0)));
			this.ibtnGananciasyPerdidas.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.POPUPDEESPERA + Helper.HistorialIrAdelantePersonalizado("ddlbPeriodo","dddblMes") + ";" + Helper.MostrarVentana(URLESTADOSFINANCIEROSCONTABLESDIRECORIO+"MOSTRARBOTON"+Utilitario.Constantes.SIGNOIGUAL+"NO"+Utilitario.Constantes.SIGNOAMPERSON+QueryEEFF,Helper.EstadosFinancierosQuery(FechaPeriodo,Utilitario.Enumerados.EstadosFinancieros.idFormatoEstadodeGananciasyPerdidas,Utilitario.Enumerados.EstadosFinancierosAcumulado.AcumuladoNo,Utilitario.Enumerados.EstadosFinancierosNivelExpande.Nivel0)));


			this.ibtnBalanceGeneral.Style.Add(Utilitario.Constantes.CURSOR,Utilitario.Constantes.TIPOCURSORMANO);
			this.imgAdmConceptos.Style.Add(Utilitario.Constantes.CURSOR,Utilitario.Constantes.TIPOCURSORMANO);
			//this.ibtnBalanceGeneral.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado("ddlbPeriodo","dddblMes"));
			this.imgAdmConceptos.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.POPUPDEESPERA + Helper.MostrarVentana(URLADMINITRACIONCONCEPTOSEEFF)+Utilitario.Constantes.HISTORIALADELANTE);

			this.ibtnFlujoCaja.Style.Add(Utilitario.Constantes.CURSOR,Utilitario.Constantes.TIPOCURSORMANO);
			if(Convert.ToInt32(Page.Request.Params[KEYQESOBSERVACION])==1)
			{
//				this.ibtnBalanceGeneral.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
//					Utilitario.Constantes.POPUPDEESPERA + 
//					Helper.HistorialIrAdelantePersonalizado("ddlbPeriodo","dddblMes") + ";" + 
//					Helper.MostrarVentana(URLESTADOSFINANCIEROSCUENTASPORLIQUIDARPROVISIONAR,
//					Helper.EstadosFinancierosQuery(FechaPeriodo,
//					Utilitario.Enumerados.EstadosFinancieros.idFormatoFlujodeCaja,
//					Utilitario.Enumerados.EstadosFinancierosAcumulado.AcumuladoNo,
//					Utilitario.Enumerados.EstadosFinancierosNivelExpande.Nivel0) +
//					Utilitario.Constantes.SIGNOAMPERSON + KEYQFLAGDIRECTORIO +  Utilitario.Constantes.SIGNOIGUAL + 
//					Utilitario.Constantes.POSICIONINDEXCERO
//					));
				this.ibtnFlujoCaja.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.POPUPDEESPERA + Helper.MostrarVentana(URLADMINITRACIONOBSERVACIONESCTASCOBRARPAGAR,QueryEEFF + "&" + Query));
			}
			else
			{
				//this.ibtnFlujoCaja.Style.Add(Utilitario.Constantes.CURSOR,Utilitario.Constantes.TIPOCURSORMANO);
				//this.ibtnFlujoCaja.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado("ddlbPeriodo","dddblMes"));
				this.ibtnFlujoCaja.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.POPUPDEESPERA + Helper.HistorialIrAdelantePersonalizado("ddlbPeriodo","dddblMes") + ";" + Helper.MostrarVentana(URLESTADOSFINANCIEROSCONTABLES+QueryEEFF,Helper.EstadosFinancierosQuery(FechaPeriodo,Utilitario.Enumerados.EstadosFinancieros.idFormatoFlujodeCaja,Utilitario.Enumerados.EstadosFinancierosAcumulado.AcumuladoNo,Utilitario.Enumerados.EstadosFinancierosNivelExpande.Nivel0)));
				this.ibtnBalanceGeneral.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.POPUPDEESPERA + Helper.HistorialIrAdelantePersonalizado("ddlbPeriodo","dddblMes") + ";" + Helper.MostrarVentana(URLESTADOSFINANCIEROSCONTABLES+QueryEEFF,Helper.EstadosFinancierosQuery(FechaPeriodo,Utilitario.Enumerados.EstadosFinancieros.idFormatoBalanceGeneral,Utilitario.Enumerados.EstadosFinancierosAcumulado.AcumuladoSi,Utilitario.Enumerados.EstadosFinancierosNivelExpande.Nivel0)));
			}
			//Estado Ingresos y Egresos
			this.ibtnIngresosyEgresos.Style.Add(Utilitario.Constantes.CURSOR,Utilitario.Constantes.TIPOCURSORMANO);
			this.ibtnIngresosyEgresos.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN, Helper.HistorialIrAdelantePersonalizado("ddlbPeriodo","dddblMes"));
			this.ibtnIngresosyEgresos.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.POPUPDEESPERA + Helper.MostrarVentana(URLESTADOSFINANCIEROSCONTABLES+QueryEEFF,Helper.EstadosFinancierosQuery(FechaPeriodo,Utilitario.Enumerados.EstadosFinancieros.idFormatoIngresosyEgresos,Utilitario.Enumerados.EstadosFinancierosAcumulado.AcumuladoNo,Utilitario.Enumerados.EstadosFinancierosNivelExpande.Nivel0)));

			//Cuentas por Cobrar y Pagar
			

			this.ibtnCtasPorCobraryPagar.Style.Add(Utilitario.Constantes.CURSOR,Utilitario.Constantes.TIPOCURSORMANO);
			this.ibtnCtasPorCobraryPagar.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado("ddlbPeriodo","dddblMes"));
			if(Convert.ToInt32(Page.Request.QueryString[KEYQESOBSERVACION])==1)
				this.ibtnCtasPorCobraryPagar.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.POPUPDEESPERA + Helper.MostrarVentana(URLADMINITRACIONOBSERVACIONESCTASCOBRARPAGAR,QueryEEFF + "&" + Query));
			else
				this.ibtnCtasPorCobraryPagar.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.POPUPDEESPERA + Helper.MostrarVentana(URLESTADOSFINANCIEROSCTASPORCOBRARPAGAR,Query));

			this.ibtnProyectosProvisionarLiquidar.Style.Add(Utilitario.Constantes.CURSOR,Utilitario.Constantes.TIPOCURSORMANO);
			//this.ibtnFlujoCaja.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado("ddlbPeriodo","dddblMes"));
			this.ibtnProyectosProvisionarLiquidar.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
				Utilitario.Constantes.POPUPDEESPERA + 
				Helper.HistorialIrAdelantePersonalizado("ddlbPeriodo","dddblMes") + ";" + 
				Helper.MostrarVentana(URLESTADOSFINANCIEROSCUENTASPORLIQUIDARPROVISIONAR,
							Helper.EstadosFinancierosQuery(FechaPeriodo,
													Utilitario.Enumerados.EstadosFinancieros.idFormatoFlujodeCaja,
													Utilitario.Enumerados.EstadosFinancierosAcumulado.AcumuladoNo,
													Utilitario.Enumerados.EstadosFinancierosNivelExpande.Nivel0) +
							Utilitario.Constantes.SIGNOAMPERSON + KEYQFLAGDIRECTORIO +  Utilitario.Constantes.SIGNOIGUAL + 
							Utilitario.Constantes.POSICIONINDEXCERO
				));
			
			/*
 * 
 * 
 * 
			//Muestra La Glosa del Balance
			this.txtBGGlosaCallao.Text = ObtenerGlosaSituacionFormato(Convert.ToInt32(Utilitario.Constantes.KEYIDFORMATOBALANCEGENERAL),Convert.ToInt32(Utilitario.Constantes.KEYIDCENTROCALLAO),FechaPeriodo.Year,FechaPeriodo.Month);
			this.txtBGGlosaChimbote.Text = ObtenerGlosaSituacionFormato(Convert.ToInt32(Utilitario.Constantes.KEYIDFORMATOBALANCEGENERAL),Convert.ToInt32(Utilitario.Constantes.KEYIDCENTROCHIMBOTE),FechaPeriodo.Year,FechaPeriodo.Month);
			this.txtBGGlosaIquitos.Text = ObtenerGlosaSituacionFormato(Convert.ToInt32(Utilitario.Constantes.KEYIDFORMATOBALANCEGENERAL),Convert.ToInt32(Utilitario.Constantes.KEYIDCENTROIQUITOS),FechaPeriodo.Year,FechaPeriodo.Month);

			//Muestra La Glosa Estado de Ganacias y Perdidas
			this.txtEGPGlosaCallao.Text = ObtenerGlosaSituacionFormato(Convert.ToInt32(Utilitario.Constantes.KEYIDFORMATOESTADODEGANACIASYPERDIDAS),Convert.ToInt32(Utilitario.Constantes.KEYIDCENTROCALLAO),FechaPeriodo.Year,FechaPeriodo.Month);
			this.txtEGPGlosaChimbote.Text = ObtenerGlosaSituacionFormato(Convert.ToInt32(Utilitario.Constantes.KEYIDFORMATOESTADODEGANACIASYPERDIDAS),Convert.ToInt32(Utilitario.Constantes.KEYIDCENTROCHIMBOTE),FechaPeriodo.Year,FechaPeriodo.Month);
			this.txtEGPGlosaIquitos.Text = ObtenerGlosaSituacionFormato(Convert.ToInt32(Utilitario.Constantes.KEYIDFORMATOESTADODEGANACIASYPERDIDAS),Convert.ToInt32(Utilitario.Constantes.KEYIDCENTROIQUITOS),FechaPeriodo.Year,FechaPeriodo.Month);

			//Muestra La Glosa Flujo de Caja
			this.txtFCGlosaCallao.Text = ObtenerGlosaSituacionFormato(Convert.ToInt32(Utilitario.Constantes.KEYIDFORMATOFLUJODECAJA),Convert.ToInt32(Utilitario.Constantes.KEYIDCENTROCALLAO),FechaPeriodo.Year,FechaPeriodo.Month);
			this.txtFCGlosaChimbote.Text = ObtenerGlosaSituacionFormato(Convert.ToInt32(Utilitario.Constantes.KEYIDFORMATOFLUJODECAJA),Convert.ToInt32(Utilitario.Constantes.KEYIDCENTROCHIMBOTE),FechaPeriodo.Year,FechaPeriodo.Month);
			this.txtFCGlosaIquitos.Text = ObtenerGlosaSituacionFormato(Convert.ToInt32(Utilitario.Constantes.KEYIDFORMATOFLUJODECAJA),Convert.ToInt32(Utilitario.Constantes.KEYIDCENTROIQUITOS),FechaPeriodo.Year,FechaPeriodo.Month);

			//Estado Ingresos y Egresos
			this.hlkIE.Style.Add(Utilitario.Constantes.CURSOR,Utilitario.Constantes.TIPOCURSORMANO);
			this.hlkIE.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado("ddlbPeriodo","dddblMes"));
			this.hlkIE.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.MostrarVentana(URLESTADOSFINANCIEROSCONTABLES,Helper.EstadosFinancierosQuery(FechaPeriodo,Utilitario.Enumerados.EstadosFinancieros.idFormatoIngresosyEgresos,Utilitario.Enumerados.EstadosFinancierosAcumulado.AcumuladoNo,Utilitario.Enumerados.EstadosFinancierosNivelExpande.Nivel0)));
*/
			#endregion
			
			#region Cuentas por Cobrar y Pagar
			/*				
							//Cuentas por Cobrar
							this.hlkCC.Style.Add(Utilitario.Constantes.CURSOR,Utilitario.Constantes.TIPOCURSORMANO);
							this.hlkCC.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado("ddlbPeriodo","dddblMes"));
							this.hlkCC.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.POPUPDEESPERA + Helper.MostrarVentana(URLESTADOSFINANCIEROSCONTABLES,Helper.EstadosFinancierosQuery(FechaPeriodo,Utilitario.Enumerados.EstadosFinancieros.idFormatoCuentasporCobrar,Utilitario.Enumerados.EstadosFinancierosAcumulado.AcumuladoSi ,Utilitario.Enumerados.EstadosFinancierosNivelExpande.Nivel0)));

							//Cuentas por Pagar
							this.hlkCxP.Style.Add(Utilitario.Constantes.CURSOR,Utilitario.Constantes.TIPOCURSORMANO);
							this.hlkCxP.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado("ddlbPeriodo","dddblMes"));
							this.hlkCxP.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.POPUPDEESPERA + Helper.MostrarVentana(URLESTADOSFINANCIEROSCONTABLES,Helper.EstadosFinancierosQuery(FechaPeriodo,Utilitario.Enumerados.EstadosFinancieros.idFormatoCuentasporPagar,Utilitario.Enumerados.EstadosFinancierosAcumulado.AcumuladoSi,Utilitario.Enumerados.EstadosFinancierosNivelExpande.Nivel0)));
			*/				
			#endregion

			#region Gastos de Personal
			/*
						this.hlkGP.Style.Add(Utilitario.Constantes.CURSOR,Utilitario.Constantes.TIPOCURSORMANO);
						this.hlkGP.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado("ddlbPeriodo","dddblMes"));
						//this.hlkGP.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.MostrarVentana(URLESTADOSFINANCIEROSCONTABLES,qrAbsoluto + qrRelativo));
						this.hlkGP.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.POPUPDEESPERA + Helper.MostrarVentana(URLPRESUPUESTO,KEYQIDTIPOPRESUPUESTO + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt32(Utilitario.Enumerados.TipodePresupuesto.PresupuestoGastosdePersonal).ToString()
							+ Utilitario.Constantes.SIGNOAMPERSON 
							+ KEYQIDFECHA + Utilitario.Constantes.SIGNOIGUAL + FechaPeriodo.ToShortDateString() 
							+ Utilitario.Constantes.SIGNOAMPERSON 
							+ KEYQIDNOMBREMES + Utilitario.Constantes.SIGNOIGUAL + this.dddblMes.SelectedItem.Text 
							+ Utilitario.Constantes.SIGNOAMPERSON 
							+ NOMBREPRESUPUESTO + Utilitario.Constantes.SIGNOIGUAL + "Gasto de Administración"));
			*/				
			#endregion

		}
		private void LlenarJScrtiptEstadosFinancierosPresupuestales()
		{
			/*
			#region Gastos de Adminsitracion
			this.hlkADM.Style.Add(Utilitario.Constantes.CURSOR,Utilitario.Constantes.TIPOCURSORMANO);
			this.hlkADM.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado("ddlbPeriodo","dddblMes"));
			this.hlkADM.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.POPUPDEESPERA + Helper.MostrarVentana(URLPRESUPUESTO,KEYQIDTIPOPRESUPUESTO + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt32(Utilitario.Enumerados.TipodePresupuesto.PresupuestoGastosdeAdministracion).ToString()
				+ Utilitario.Constantes.SIGNOAMPERSON 
				+ KEYQIDFECHA + Utilitario.Constantes.SIGNOIGUAL + FechaPeriodo.ToShortDateString() 
				+ Utilitario.Constantes.SIGNOAMPERSON 
				+ KEYQIDNOMBREMES + Utilitario.Constantes.SIGNOIGUAL + this.dddblMes.SelectedItem.Text 
				+ Utilitario.Constantes.SIGNOAMPERSON 
				+ NOMBREPRESUPUESTO + Utilitario.Constantes.SIGNOIGUAL + "Gasto de Administración"));
			#endregion

			#region Costo de Produccion
			this.hlkCP.Style.Add(Utilitario.Constantes.CURSOR,Utilitario.Constantes.TIPOCURSORMANO);
			this.hlkCP.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado("ddlbPeriodo","dddblMes"));
			this.hlkCP.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.POPUPDEESPERA + Helper.MostrarVentana(URLPRESUPUESTO,KEYQIDTIPOPRESUPUESTO + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt32(Utilitario.Enumerados.TipodePresupuesto.PresupuestoGastosdeProduccion).ToString()
							+ Utilitario.Constantes.SIGNOAMPERSON 
							+ KEYQIDFECHA + Utilitario.Constantes.SIGNOIGUAL + FechaPeriodo.ToShortDateString() 
							+ Utilitario.Constantes.SIGNOAMPERSON 
							+ KEYQIDNOMBREMES + Utilitario.Constantes.SIGNOIGUAL + this.dddblMes.SelectedItem.Text 
							+ Utilitario.Constantes.SIGNOAMPERSON 
							+ NOMBREPRESUPUESTO + Utilitario.Constantes.SIGNOIGUAL + "Gasto de Administración"));
			#endregion
			*/
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
			this.ddlbPeriodo.SelectedIndexChanged += new System.EventHandler(this.ddlbPeriodo_SelectedIndexChanged);
			this.dddblMes.SelectedIndexChanged += new System.EventHandler(this.dddblMes_SelectedIndexChanged);
			this.chbxFlag.CheckedChanged += new System.EventHandler(this.chbxFlag_CheckedChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add DefaultEFOpciones.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DefaultEFOpciones.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DefaultEFOpciones.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			this.LlenarPeriodoContable();
			// TODO:  Add DefaultEFOpciones.LlenarCombos implementation
		}
		private void LlenarPeriodoContable()
		{
			CPeriodoContable oCPeriodoContable = new CPeriodoContable();
			ddlbPeriodo.DataSource = oCPeriodoContable.ListarPeriodo();
			ddlbPeriodo.DataValueField=VALORPERIODO;
			ddlbPeriodo.DataTextField=VALORPERIODO;
			ddlbPeriodo.DataBind();
			if((Page.Request.Params[Utilitario.Constantes.KeyQPaginaValorInicial] != null)  && Page.Request.Params[Utilitario.Constantes.KeyQPaginaValorInicial].ToString() == Utilitario.Constantes.KeyQPaginaValor)
			{
				ListItem item;
				item = ddlbPeriodo.Items.FindByText(SIMA.Utilitario.Helper.FechaSimanet.ObtenerFechaSesion().Year.ToString());
				if (item !=null){item.Selected = true;}

				item = dddblMes.Items.FindByValue(SIMA.Utilitario.Helper.FechaSimanet.ObtenerFechaSesion().Month.ToString());
				if (item !=null){item.Selected = true;}
			}	
			else
			{
				Helper.SeleccionarItemCombos(this);
			}
				
		}


		public void LlenarDatos()
		{
			// TODO:  Add DefaultEFOpciones.LlenarDatos implementation
			Session["PROYECTOPORLIQUIDAR"]=null;
			if(Convert.ToInt32(Page.Request.Params[KEYQESOBSERVACION])==1)
			{
				//ibtnProyectosProvisionarLiquidar.Visible=false;
				Label1.Text="ADMINISTRACION DE OBSERVACIONES DE LOS ESTADOS FINANCIEROS";
				Session["OBSERVACION"]=1;
				OcultarCambiarBotones();

			}
			else
			{
				Session["OBSERVACION"]=0;
				imgAdmConceptos.Visible=false;
			}
		}
		private void OcultarCambiarBotones()
		{
				//ibtnFlujoCaja.Src=ibtnCtasPorCobraryPagar.Src;
				//ibtnCtasPorCobraryPagar.Visible=false;
				

				
				ibtnFlujoCaja.Visible=false;
				ibtnBalanceGeneral.Src=ibtnProyectosProvisionarLiquidar.Src;
				ibtnIngresosyEgresos.Visible=false;
				ibtnBalanceGeneral.Visible=false;
			imgAdmConceptos.Visible=true;
				//ibtnProyectosProvisionarLiquidar.Visible=false;
				
		}

		public void LlenarJScript()
		{
			this.LlenarJScrtiptEstadosFinancierosContables();
			this.LlenarJScrtiptEstadosFinancierosPresupuestales();
			// TODO:  Add DefaultEFOpciones.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DefaultEFOpciones.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DefaultEFOpciones.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DefaultEFOpciones.Exportar implementation
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
			// TODO:  Add DefaultEFOpciones.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void dddblMes_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.LlenarJScript();
		}

		private void ddlbPeriodo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.LlenarJScript();
		}

		private void chbxFlag_CheckedChanged(object sender, System.EventArgs e)
		{
			if(this.chbxFlag.Checked == true) //Nuevos Soles
			{
				Session[KEYQNUEVOSSOLES]= NOVERMILES;
				this.Label1.Text = MONTONOMILES;
			}
			else	//Miles de Nuevos Soles
			{
				Session[KEYQNUEVOSSOLES]= Utilitario.Constantes.SIVERMILES;
				this.Label1.Text = MONTOMILES;
			}
		}

		private void VerificarCheckBox()
		{
			if(Session[KEYQNUEVOSSOLES]== null)	
			{
				Session[KEYQNUEVOSSOLES] = Utilitario.Constantes.SIVERMILES;	//SI
				this.Label1.Text = MONTOMILES;
				this.chbxFlag.Checked = false;	//Miles de Nuevos Soles
			}
			else
			{
				if(Session[KEYQNUEVOSSOLES].ToString() == Utilitario.Constantes.SIVERMILES)	//Viene con valor SI
				{
					//Session[KEYQNUEVOSSOLES] = Utilitario.Constantes.SIVERMILES;
					this.Label1.Text = MONTOMILES;
					this.chbxFlag.Checked = false; //Nuevos Soles
				}
				else	//CASO NO
				{
					Session[KEYQNUEVOSSOLES] = NOVERMILES;
					this.chbxFlag.Checked = true; //Miles de Nuevos Soles
					this.Label1.Text = MONTONOMILES;
				}
			}
			//			if(this.hValorChbx.Value.Length == Utilitario.Constantes.ValorConstanteCero)			
			//			{
			//				Session[KEYQNUEVOSSOLES] = String.Empty;
			//				this.chbxFlag.Checked = false;
			//			}			
		}
	}
}
