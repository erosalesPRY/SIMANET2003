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

namespace SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancieros
{
	/// <summary>
	/// Summary description for EstadosFinancierosCorporativo.
	/// </summary>
	public class EstadosFinancierosCorporativo : System.Web.UI.Page,IPaginaBase
	{
		#region Constantes
		const string HISTORICO_PERU= "HIST_bg_SIMAP.pps";
		const string HISTORICO_IQUI= "HIST_BG_SIMAI.pps";

		//Key Session y QueryString
		const string KEYQIDEMPRESA = "idEmp";
		const string KEYIDCENTRO ="IdCentro";
		const string NOMBRECENTRO ="NombreCentro";
		const string NOMBRETIPOOPCION ="NombreOpcion";
		const string KEYQIDNOMBREFORMATO = "NFormato";
		const string KEYQIDFECHA = "efFecha";
		const string KEYQIDNOMBREMES = "NombreMes";


		const string KEYQIDINTERFAZ = "interfaz";

		const string KEYQIDIDTIPOINFORMACION ="idTipoInfo";
		const string KEYQVERIQUITOS ="Ver";
		const string KEYQNOMBRERUBRO ="NRubro";

		const string KEYQFLAGDIRECTORIO= "FlagDirectorio";

		const string KEYQIDFORMATO = "IdFormato";
		const string KEYQIDREPORTE = "IdReporte";
		const string KEYQIDRUBRO = "IdRubro";
		const string KEYQIDACUMULADO = "Acumulado";
		const string KEYQIDNIVELEXPANDE = "NivelExp";
		const string KEYQIDCLASIFICACIONRUBRO = "RubroClasf";	
		const string KEYQIDTIPOCUENTA ="IdTipoCuenta";
		const string KEYQDESCRIPCIONCUENTA="Descripcion";
		const string KEYIDSIT="KEYIDSIT";
		const string URLPAGINAPROYPORLIQUIDAR="../ProyectosPorProvisionarLiquidar/ConsultarProyectoPorLiquidarProvisionar.aspx?";
		const string URLPAGINACTASPORPAGAR="../../GestionFinanciera/CuentasPorCobrarPagar/Directorio/ConsultarCuentasPorCobrarPagar.aspx?";
		const string URLESTADOSFINANCIEROSCUENTASPORLIQUIDARPROVISIONAR = "Directorio/DefaultLiquidados.aspx?";
		const string URLESTADOSFINANCIEROSCTASPORCOBRARPAGAR = "../CuentasPorCobrarPagar/Directorio/ConsultarCuentasPorCobrarPagarResumen.aspx?";

		const string KEYQNRODIGITOS ="NroDig";
		const string KEYQDIGCUENTA = "DigCuenta";

		const string KEYQNUEVOSSOLES = "MILNS";

		//Nuevos Key Session y QueryString
		const string KEYQOBSCALLAO = "ObsCallao";
		const string KEYQOBSCHIMBOTE = "ObsChimbote";
		const string KEYQOBSIQUITOS = "ObsIquitos";
		const string KEYQOBSPERU = "ObsPeru";

		//*********Campos Cabeceras****************
		//Sima Peru
		const string CAMPOHSP ="lblSimaPeru";
		const string CAMPOHP1 = "lblPresupuestoHP";
		const string CAMPOHP2 = "lblEjecutadoHP";
		const string CAMPOHP3 = "lblSaldoHP";
		const string CAMPOHP4 = "lblProyectadoHP";
		//Sima Iquitos
		const string CAMPOHSI ="lblSimaIquitos";
		const string CAMPOHI1 = "lblPresupuestoHI";
		const string CAMPOHI2 = "lblEjecutadoHI";
		const string CAMPOHI3 = "lblSaldoHI";
		const string CAMPOHI4 = "lblProyectadoHI";


		//**************Campos de talle ************
		//Columnas de Montos Sima Peru
		const string CAMPOP1 = "lblPresupuestoP";
		const string CAMPOP2 = "lblEjecutadoP";
		const string CAMPOP3 = "lblSaldoP";
		const string CAMPOP4 = "lblProyectadoP";
		//Columnas de Montos Sima Iquitos
		const string CAMPOI1 = "lblPresupuestoI";
		const string CAMPOI2 = "lblEjecutadoI";
		const string CAMPOI3 = "lblSaldoI";
		const string CAMPOI4 = "lblProyectadoI";

		const int NRODIGINI = 2;
		const int DIGCTA = 0;
			

		const string GRILLAVACIA="No existe";

		//Paginas
		const string URLPRESUPUESTO="../EstadosFinancierosPresupuestales/EstadosFinancierosFormulacion.aspx?";
		const string URLEJECUCIONREAL="EstadosFinancierosPorEmpresa.aspx?";
		const string URLEJECUCIONREALPORCENTRO="EstadosFinancierosPorCentroOperativo.aspx?";
		const string URLPRROYECCION="../EstadosFinancierosPresupuestales/EstadosFinancierosProyectados.aspx?";
		const string URLDETALLE="EstadosFinancierosCorporativoDetalle.aspx?";
		const string URLDETALLEPERSONALIZADO="EstadosFinancierosCorporativoDetallePersonalizado.aspx?";
		const string URLIMPRESION = "PopupImpresionEstadosFinancieros.aspx";
		const string URLFORMATORUBROMOVIMIENTOVCV ="ConsultarFormatoRubroMovimientoVCV.aspx?";
		const string URLFORMATORUBROMOVIMIENTO ="ConsultarFormatoRubroMovimiento.aspx?";
		const string URLFORMATORUBROMOVIMIENTODES ="ConsultarFormatoRubroMovimientoDES.aspx?";
		
		const string KEYWCINDICADORES="FileXLSInd";		
		
		//Variables
		DateTime FechaPeriodo;
		private ASPNetDatagridDecorator m_add = new ASPNetDatagridDecorator();		

		string MENSAJESSINDESCRIPCION = Utilitario.Constantes.VACIO; //"Sin explicación";

		//Otros
		const string TEXTOCONCEPTO ="CONCEPTO";
		const string TEXTOSIMAPERU ="SIMA-PERU S.A.";
		const string TEXTOVERDETALLE ="Ver detalle ";
		const string TEXTOSIMAIQUITOS ="SIMA-IQUITOS S.R.Ltda";
		const string UNION =" y ";
		const string TITULOAL= "Al";
		const string TITULODEL ="Del";
		const string TITULOMES =" Mes de ";
		const string TITULOPTO ="PPTO";
		const string TITULOPTOPERIODO ="Presupuesto Periodo ";
		const string TITULOACUM ="ACUM";
		const string TITULOACUMMES ="Acumulado al Mes de ";
		const string RANGO =" del ";
		const string TITULOPROYECTADO ="PROY";
		const string TITULOPROYPERIODO ="Proyección Periodo ";


		//Columnas Grilla y DataTable
		//PERU
		const string PERUEJECUCIONREALDELMESANTERIOR ="PeruEjecucionRealDelmesAnterior";
		const string PERUEJECUCIONREALDELMESACTUAL ="PeruEjecucionRealDelmesActual";
		const string PERUPTOANUAL ="PeruPresupuestoAnual";

		//IQUITOS
		const string IQUITOSEJECUCIONREALMESANTERIOR ="IquitosEjecucionRealDelmesAnterior";
		const string IQUITOSEJECUCIONREALMESACTUAL ="IquitosEjecucionRealDelmesActual";
		const string IQUITOSPTOANUAL ="IquitosPresupuestoAnual";

		const string COLUMNACONCEPTO = "CONCEPTO";
		const string COLUMNAIDRUBRO ="idRubro";

		const string TEXTOVERMILES ="EN MILES DE NUEVOS SOLES";
		const string TEXTONOVERMILES ="EN NUEVOS SOLES";
		
		#endregion

		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected projDataGridWeb.DataGridWeb gridHeader;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblLiquidezMesAnteriorP;
		protected System.Web.UI.WebControls.Label lblLiquidezDelMesP;
		protected System.Web.UI.WebControls.Label lblLiquidezPresupuestoP;
		protected System.Web.UI.WebControls.Label lblLiquidezMesAnteriorI;
		protected System.Web.UI.WebControls.Label lblLiquidezDelMesI;
		protected System.Web.UI.WebControls.Label lblLiquidezPresupuestoI;
		protected System.Web.UI.WebControls.Label lblSolvenciaMesAnteriorP;
		protected System.Web.UI.WebControls.Label lblSolvenciaDelMesP;
		protected System.Web.UI.WebControls.Label lblSolvenciaPresupuestoP;
		protected System.Web.UI.WebControls.Label lblSolvenciaMesAnteriorI;
		protected System.Web.UI.WebControls.Label lblSolvenciaDelMesI;
		protected System.Web.UI.WebControls.Label lblSolvenciaPresupuestoI;
		protected System.Web.UI.HtmlControls.HtmlTable lblSollvenciaLiquidez;
		protected System.Web.UI.WebControls.Label lblLiquidez;
		protected System.Web.UI.WebControls.Label lblSolvencia;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label lblPeriodo;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label lblMes;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hObsCallao;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hObsChimbote;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hObsIquitos;
		#endregion			
		protected System.Web.UI.HtmlControls.HtmlInputHidden hObsPeru;
		protected System.Web.UI.WebControls.ImageButton btnVentasCostos;
		protected System.Web.UI.WebControls.ImageButton btnGO;
		protected System.Web.UI.WebControls.ImageButton ibtnCtasPorCobrar;
		protected System.Web.UI.WebControls.ImageButton ibtnProyPorLiquidar;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnIndicadores;
		protected System.Web.UI.WebControls.HyperLink lnkHistPeru;
		protected System.Web.UI.WebControls.HyperLink lnkHistorIquitos;
		
		string url=String.Empty;
		private void Page_Load(object sender, System.EventArgs e)
		{
		
			try
			{
				if(!Page.IsPostBack)
				{
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarJScript();
					this.LlenarCombos();
					this.LlenarDatos();
					this.ColspanRowspanHeader();
					this.LlenarGrilla();
					this.CargarHistoricos();
					
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
		private void ColspanRowspanHeader()
		{			
			int NroColaMostrar = ((Convert.ToInt32(Page.Request.Params[KEYQIDACUMULADO]) == Utilitario.Constantes.ValorConstanteUno)?
				(Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO]) == Utilitario.Constantes.KEYIDFORMATOCUENTASPORCOBRAR || Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO]) == Utilitario.Constantes.KEYIDFORMATOCUENTASPORPAGAR)?2:3
				:5);

			//DateTime Fecha = Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA]);
			TableCell cell = null;
			m_add.DatagridToDecorate = grid;
			ArrayList header = new ArrayList();


			cell = new TableCell();
			cell.Text = TEXTOCONCEPTO;
			cell.RowSpan = 2;
			cell.VerticalAlign = VerticalAlign.Middle;
			header.Add(cell);

			cell = new TableCell();
			cell.Text = TEXTOSIMAPERU;
			cell.ToolTip= TEXTOVERDETALLE + Utilitario.Constantes.SIGNOABREPARANTESIS + Utilitario.Constantes.KEYIDNOMBRECENTROCALLAO.ToString() + UNION + Utilitario.Constantes.KEYIDNOMBRECENTROCHIMBOTE.ToString() + Utilitario.Constantes.SIGNOCIERRAPARANTESIS;
			cell.Font.Size = 11;
			cell.Font.Underline=true;
			cell.Font.Bold=true;
			cell.Style.Add(Utilitario.Constantes.CURSOR,Utilitario.Constantes.TIPOCURSORMANO);
			cell.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado(Utilitario.Constantes.VACIO));
			
			url = this.QueryPrincipal();

			cell.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.POPUPDEESPERA + Helper.MostrarVentana(URLEJECUCIONREALPORCENTRO,
				KEYQIDEMPRESA + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.IDEMPRESASIMAPERU.ToString()
				+ Utilitario.Constantes.SIGNOAMPERSON
				+ NOMBRECENTRO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.KEYIDNOMBRECENTROPERU.ToString()+ url));

			cell.ColumnSpan = NroColaMostrar;//((Convert.ToInt32(Page.Request.Params[KEYQIDACUMULADO]) == 1)?3:5);
			cell.HorizontalAlign = HorizontalAlign.Center;
			header.Add(cell);

			cell = new TableCell();
			cell.Text = TEXTOSIMAIQUITOS;
			cell.Font.Size = 11;
			cell.Font.Bold=true;
			cell.ColumnSpan = NroColaMostrar;//((Convert.ToInt32(Page.Request.Params[KEYQIDACUMULADO]) == 1)?3:5);
			cell.HorizontalAlign = HorizontalAlign.Center;
			header.Add(cell);
			m_add.AddMergeHeader(header);
			lblSollvenciaLiquidez.Visible = ((Convert.ToInt32(Page.Request.Params[KEYQIDACUMULADO]) == Utilitario.Constantes.ValorConstanteUno && Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO])== Utilitario.Constantes.KEYIDFORMATOBALANCEGENERAL)?true:false);
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
			this.btnGO.Click += new System.Web.UI.ImageClickEventHandler(this.btnGO_Click);
			this.btnVentasCostos.Click += new System.Web.UI.ImageClickEventHandler(this.btnVentasCostos_Click);
			this.ibtnImprimir.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnImprimir_Click);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.ibtnProyPorLiquidar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnProyPorLiquidar_Click);
			this.ibtnCtasPorCobrar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnCtasPorCobrar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members
		private void GeneraFecha()
		{
			FechaPeriodo =  
				Convert.ToDateTime(DateTime.DaysInMonth(Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA]).Year,Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA]).Month) + Utilitario.Constantes.SEPARADORFECHA + Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA]).Month.ToString().PadLeft(2,'0') + Utilitario.Constantes.SEPARADORFECHA + Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA]).Year.ToString());
		}
		
		public void LlenarGrilla()
		{
			this.GeneraFecha();
			CEstadosFinancieros oCEstadosFinancieros = new  CEstadosFinancieros();
			DataTable dtEstadoFinanciero = oCEstadosFinancieros.ConsultarEstadosFinancierosCorporativo(FechaPeriodo
				,Convert.ToInt32(Page.Request.QueryString[KEYQIDFORMATO])
				,Convert.ToInt32(Page.Request.QueryString[KEYQIDREPORTE])
				,Utilitario.Constantes.IDDEFAULT
				,Convert.ToInt32(Page.Request.QueryString[KEYQIDNIVELEXPANDE])
				,Convert.ToInt32(Page.Request.QueryString[KEYQIDCLASIFICACIONRUBRO])
				,Convert.ToInt32(Page.Request.QueryString[KEYQIDACUMULADO])
				);			
			
			if(dtEstadoFinanciero!=null)
			{
				grid.DataSource = dtEstadoFinanciero;
				//Determina el Liquidez y La Solvencia del Balance
				if (Convert.ToInt32(Page.Request.QueryString[KEYQIDFORMATO])== Convert.ToInt32(Utilitario.Constantes.KEYIDFORMATOBALANCEGENERAL))
				{
					this.CalculodeSolvenciayLiquidez(dtEstadoFinanciero.Select("idRubro = '55' or idRubro = '59'"," idRubro asc"),
						dtEstadoFinanciero.Select("idRubro = '61' or idRubro = '68'"," idRubro asc"));

				}
				#region Impresion
				/******************************Metodo introducido para realizar la impresion***********************/
				CImpresion oCImpresion = new CImpresion();
				oCImpresion.GuardarDataImprimirExportar(dtEstadoFinanciero,				
															Convert.ToString(Page.Request.Params[KEYQIDFORMATO]),
															Convert.ToString(Page.Request.Params[KEYQIDREPORTE]),
															Convert.ToString(Page.Request.Params[KEYQIDNIVELEXPANDE]),
															Convert.ToString(Page.Request.Params[KEYQIDCLASIFICACIONRUBRO]),
															Convert.ToString(Page.Request.Params[KEYQIDACUMULADO]),
															Convert.ToString(Page.Request.Params[KEYQIDFECHA]),
															Convert.ToString(Page.Request.Params[KEYQIDNOMBREMES]),
															Convert.ToString(Page.Request.Params[KEYQIDNOMBREFORMATO]));
				/**************************************************************************************************/
				#endregion Impresion
			}
			else
			{
				grid.DataSource = dtEstadoFinanciero;
				//lblResultado.Text = GRILLAVACIA;

			}
			grid.DataBind();
			// TODO:  Add EstadosFinancierosCorporativo.LlenarGrilla implementation
		}
		private void CalculodeSolvenciayLiquidez(DataRow []drLiquidez,DataRow []drSolvencia)
		{
			if (drLiquidez !=null && drLiquidez.Length==2)//idrubro 55/59
			{
				#region Peru
				if (Convert.ToDouble(drLiquidez[1][PERUEJECUCIONREALDELMESANTERIOR]) >0) {lblLiquidezMesAnteriorP.Text =  (Convert.ToDouble(drLiquidez[0][PERUEJECUCIONREALDELMESANTERIOR]) / Convert.ToDouble(drLiquidez[1][PERUEJECUCIONREALDELMESANTERIOR])).ToString(Utilitario.Constantes.FORMATODECIMAL2);}
				if (Convert.ToDouble(drLiquidez[1][PERUEJECUCIONREALDELMESACTUAL]) >0) {lblLiquidezDelMesP.Text =  (Convert.ToDouble(drLiquidez[0][PERUEJECUCIONREALDELMESACTUAL]) / Convert.ToDouble(drLiquidez[1][PERUEJECUCIONREALDELMESACTUAL])).ToString(Utilitario.Constantes.FORMATODECIMAL2);}
				if (Convert.ToDouble(drLiquidez[1][PERUPTOANUAL]) >0) {lblLiquidezPresupuestoP.Text =  Convert.ToDecimal((Convert.ToDouble(drLiquidez[0][PERUPTOANUAL]) / Convert.ToDouble(drLiquidez[1][PERUPTOANUAL])).ToString()).ToString(Utilitario.Constantes.FORMATODECIMAL2);}
				#endregion
				#region Iquitos
				if (Convert.ToDouble(drLiquidez[1][IQUITOSEJECUCIONREALMESANTERIOR]) >0) {lblLiquidezMesAnteriorI.Text =  (Convert.ToDouble(drLiquidez[0][IQUITOSEJECUCIONREALMESANTERIOR]) / Convert.ToDouble(drLiquidez[1][IQUITOSEJECUCIONREALMESANTERIOR])).ToString(Utilitario.Constantes.FORMATODECIMAL2);}
				if (Convert.ToDouble(drLiquidez[1][IQUITOSEJECUCIONREALMESACTUAL]) >0) {lblLiquidezDelMesI.Text =  (Convert.ToDouble(drLiquidez[0][IQUITOSEJECUCIONREALMESACTUAL]) / Convert.ToDouble(drLiquidez[1][IQUITOSEJECUCIONREALMESACTUAL])).ToString(Utilitario.Constantes.FORMATODECIMAL2);}
				if (Convert.ToDouble(drLiquidez[1][IQUITOSPTOANUAL]) >0) {lblLiquidezPresupuestoI.Text =  (Convert.ToDouble(drLiquidez[0][IQUITOSPTOANUAL]) / Convert.ToDouble(drLiquidez[1][IQUITOSPTOANUAL])).ToString(Utilitario.Constantes.FORMATODECIMAL2);}
				#endregion
			}
			if (drSolvencia!=null && drSolvencia.Length==2)//idrubro 61/68
			{
				#region Peru
				if (Convert.ToDouble(drSolvencia[1][PERUEJECUCIONREALDELMESANTERIOR]) >0) {lblSolvenciaMesAnteriorP.Text =  Convert.ToDouble((Convert.ToDouble(drSolvencia[0][PERUEJECUCIONREALDELMESANTERIOR]) / Convert.ToDouble(drSolvencia[1][PERUEJECUCIONREALDELMESANTERIOR]))*100).ToString(Utilitario.Constantes.FORMATODECIMAL2) + Utilitario.Constantes.SIGNOPORCENTAJE;}
				if (Convert.ToDouble(drSolvencia[1][PERUEJECUCIONREALDELMESACTUAL]) >0) {lblSolvenciaDelMesP.Text =  Convert.ToDouble((Convert.ToDouble(drSolvencia[0][PERUEJECUCIONREALDELMESACTUAL]) / Convert.ToDouble(drSolvencia[1][PERUEJECUCIONREALDELMESACTUAL]))*100).ToString(Utilitario.Constantes.FORMATODECIMAL2)+ Utilitario.Constantes.SIGNOPORCENTAJE;}
				if (Convert.ToDouble(drSolvencia[1][PERUPTOANUAL]) >0) {lblSolvenciaPresupuestoP.Text =  Convert.ToDouble((Convert.ToDouble(drSolvencia[0][PERUPTOANUAL]) / Convert.ToDouble(drSolvencia[1][PERUPTOANUAL]))*100).ToString(Utilitario.Constantes.FORMATODECIMAL2)+ Utilitario.Constantes.SIGNOPORCENTAJE;}
				#endregion
				#region Iquitos
				if (Convert.ToDouble(drSolvencia[1][IQUITOSEJECUCIONREALMESANTERIOR]) >0) {lblSolvenciaMesAnteriorI.Text =  Convert.ToDouble((Convert.ToDouble(drSolvencia[0][IQUITOSEJECUCIONREALMESANTERIOR]) / Convert.ToDouble(drSolvencia[1][IQUITOSEJECUCIONREALMESANTERIOR])) *100).ToString(Utilitario.Constantes.FORMATODECIMAL2)+ Utilitario.Constantes.SIGNOPORCENTAJE;}
				if (Convert.ToDouble(drSolvencia[1][IQUITOSEJECUCIONREALMESACTUAL]) >0) {lblSolvenciaDelMesI.Text =  Convert.ToDouble((Convert.ToDouble(drSolvencia[0][IQUITOSEJECUCIONREALMESACTUAL]) / Convert.ToDouble(drSolvencia[1][IQUITOSEJECUCIONREALMESACTUAL]))*100).ToString(Utilitario.Constantes.FORMATODECIMAL2)+ Utilitario.Constantes.SIGNOPORCENTAJE;}
				if (Convert.ToDouble(drSolvencia[1][IQUITOSPTOANUAL]) >0) {lblSolvenciaPresupuestoI.Text =  Convert.ToDouble((Convert.ToDouble(drSolvencia[0][IQUITOSPTOANUAL]) / Convert.ToDouble(drSolvencia[1][IQUITOSPTOANUAL]))*100).ToString(Utilitario.Constantes.FORMATODECIMAL2)+ Utilitario.Constantes.SIGNOPORCENTAJE;}

				#endregion
			}

		}


		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add EstadosFinancierosCorporativo.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add EstadosFinancierosCorporativo.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
		}

		public void LlenarDatos()
		{
			this.GeneraFecha();
			lblPagina.Text = Page.Request.Params[KEYQIDNOMBREFORMATO].ToString().ToUpper();
			lblPeriodo.Text = FechaPeriodo.Year.ToString();
			lblMes.Text =Page.Request.Params[KEYQIDNOMBREMES].ToString().ToUpper();
			if(Page.Request.QueryString["MOSTRARBOTON"]!=null)
			{
				string a = Page.Request.QueryString["MOSTRARBOTON"].ToString();
				if(Page.Request.QueryString["MOSTRARBOTON"].ToString()=="NOPaginaValorIncial=ValorInicial")
				{
					btnGO.Visible=false;
					btnVentasCostos.Visible=false;
				}
				else if(Page.Request.QueryString["MOSTRARBOTON"].ToString()=="SIPaginaValorInicial=")
				{
					btnGO.Visible=false;
					btnVentasCostos.Visible=false;
				}
			}
			else
			{
				btnGO.Visible=false;
				btnVentasCostos.Visible=false;
			}
			if(Convert.ToInt32(Page.Request.QueryString[KEYQIDFORMATO])==20)
			{
				/*ibtnCtasPorCobrar.Visible=true;
				ibtnProyPorLiquidar.Visible=true;*/
			}
		}

		public void LlenarJScript()
		{
			//lblLiquidez.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,"showPopupSolvenciaLiquidez(1)");
			lblLiquidez.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,"ShowPopupLS(1)");
			lblLiquidez.Font.Underline=true;
			lblLiquidez.Style.Add(Utilitario.Constantes.CURSOR,Utilitario.Constantes.TIPOCURSORMANO);

			//lblSolvencia.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,"showPopupSolvenciaLiquidez(2)");
			lblSolvencia.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,"ShowPopupLS(0)");
			lblSolvencia.Font.Underline=true;
			lblSolvencia.Style.Add(Utilitario.Constantes.CURSOR,Utilitario.Constantes.TIPOCURSORMANO);


			//this.ibtnCtasPorPagar.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.POPUPDEESPERA + Utilitario.Constantes.HISTORIALADELANTE);
			this.ibtnCtasPorCobrar.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.POPUPDEESPERA + Utilitario.Constantes.HISTORIALADELANTE);
			this.ibtnProyPorLiquidar.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.POPUPDEESPERA + Utilitario.Constantes.HISTORIALADELANTE);



			//Indicadores 
			if (Convert.ToInt32(Page.Request.QueryString[KEYQIDFORMATO])!= Convert.ToInt32(Utilitario.Constantes.KEYIDFORMATOBALANCEGENERAL))
			{
				this.ibtnIndicadores.Style.Add("display","none");
			}
			
			//string PathXLSIndicadores =@"\\SIMCALDEROSALES\archivo\Book1"; //Helper.ObtenerRutaArchivosExcel(Utilitario.Constantes.EstadosFinancierosRutaCarpetaAbrirArchivoXLS);
			//this.ibtnIndicadores.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnClick.ToString(),"MostrarIndicadores('" + PathXLSIndicadores + "')");
			string PathXLSIndicadores =Helper.ObtenerRutaArchivosExcel(Utilitario.Constantes.EstadosFinancierosRutaCarpetaAbrirArchivoXLS);
			this.ibtnIndicadores.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnClick.ToString(),"MostrarIndicadores('" + PathXLSIndicadores + Utilitario.Constantes.NombreArchivoIndicadorFinanciero + "')");

			//Cuentas por Cobrar y Pagar
			/*string Query ="Periodo=" + FechaPeriodo.Year.ToString() + "&Mes=" + 
				Page.Request.Params[KEYQIDNOMBREMES].ToString().ToUpper() + Utilitario.Constantes.SIGNOAMPERSON +
				KEYQFLAGDIRECTORIO +  Utilitario.Constantes.SIGNOIGUAL + 
				Utilitario.Constantes.POSICIONINDEXUNO;
			this.ibtnCtasPorCobrar.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.POPUPDEESPERA + Helper.MostrarVentana(URLESTADOSFINANCIEROSCTASPORCOBRARPAGAR,Query));
			this.ibtnCtasPorPagar.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.POPUPDEESPERA + Helper.MostrarVentana(URLESTADOSFINANCIEROSCTASPORCOBRARPAGAR,Query));*/

			/*this.ibtnProyPorLiquidar.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
				Utilitario.Constantes.POPUPDEESPERA + 
				Helper.MostrarVentana(
					URLESTADOSFINANCIEROSCUENTASPORLIQUIDARPROVISIONAR,
				Helper.EstadosFinancierosQuery(Convert.ToDateTime(Page.Request.QueryString[KEYQIDFECHA]),
							Utilitario.Enumerados.EstadosFinancieros.idFormatoFlujodeCaja,
							Utilitario.Enumerados.EstadosFinancierosAcumulado.AcumuladoNo,
							Utilitario.Enumerados.EstadosFinancierosNivelExpande.Nivel0)));*/
		}

		public void RegistrarJScript()
		{
			// TODO:  Add EstadosFinancierosCorporativo.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			ltlMensaje.Text = Helper.PopupImpresion(URLIMPRESION,650,700,false,false,false,true,true);
		}

		public void Exportar()
		{
			// TODO:  Add EstadosFinancierosCorporativo.Exportar implementation
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
			// TODO:  Add EstadosFinancierosCorporativo.ValidarFiltros implementation
			return false;
		}

		#endregion
		private string QueryPrincipal()
		{
			this.GeneraFecha();
			string url = Utilitario.Constantes.SIGNOAMPERSON
				+ KEYIDCENTRO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.IDDEFAULT.ToString()
				+ Utilitario.Constantes.SIGNOAMPERSON
				+ KEYQIDFECHA + Utilitario.Constantes.SIGNOIGUAL + FechaPeriodo.ToShortDateString()
				+ Utilitario.Constantes.SIGNOAMPERSON
				+ KEYQIDNOMBREMES + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYQIDNOMBREMES].ToString().ToUpper()
				+ Utilitario.Constantes.SIGNOAMPERSON
				+ KEYQIDFORMATO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQIDFORMATO]
				+ Utilitario.Constantes.SIGNOAMPERSON
				+ KEYQIDNOMBREFORMATO + Utilitario.Constantes.SIGNOIGUAL +  Page.Request.QueryString[KEYQIDNOMBREFORMATO]
				+ Utilitario.Constantes.SIGNOAMPERSON
				+ KEYQIDREPORTE + Utilitario.Constantes.SIGNOIGUAL +  Page.Request.QueryString[KEYQIDREPORTE]
				+ Utilitario.Constantes.SIGNOAMPERSON
				+ KEYQIDRUBRO + Utilitario.Constantes.SIGNOIGUAL +  Utilitario.Constantes.IDDEFAULT
				+ Utilitario.Constantes.SIGNOAMPERSON
				+ KEYQIDNIVELEXPANDE + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYQIDNIVELEXPANDE].ToString()
				+ Utilitario.Constantes.SIGNOAMPERSON
				+ KEYQIDCLASIFICACIONRUBRO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYQIDCLASIFICACIONRUBRO].ToString()
				+ Utilitario.Constantes.SIGNOAMPERSON
				+ KEYQIDACUMULADO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYQIDACUMULADO].ToString();
			return url;
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if (Convert.ToInt32(Page.Request.Params[KEYQIDACUMULADO]) == Utilitario.Constantes.ValorConstanteUno)
			{	
				e.Item.Cells[0].Style.Add("width","20%");//Cambia el Ancho de la Columna de conceptos
				e.Item.Cells[3].Style.Add(Utilitario.Constantes.DISPLAY,Utilitario.Constantes.NONE);
				e.Item.Cells[5].Style.Add(Utilitario.Constantes.DISPLAY,Utilitario.Constantes.NONE);
				e.Item.Cells[8].Style.Add(Utilitario.Constantes.DISPLAY,Utilitario.Constantes.NONE);
				e.Item.Cells[10].Style.Add(Utilitario.Constantes.DISPLAY,Utilitario.Constantes.NONE);

				string visible = (Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO]) == Utilitario.Constantes.KEYIDFORMATOCUENTASPORCOBRAR || Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO]) == Utilitario.Constantes.KEYIDFORMATOCUENTASPORPAGAR)? Utilitario.Constantes.NONE:"block";
				e.Item.Cells[4].Style.Add(Utilitario.Constantes.DISPLAY,visible);
				e.Item.Cells[9].Style.Add(Utilitario.Constantes.DISPLAY,visible);

			}
			else
			{
				e.Item.Cells[0].Style.Add("width","22%");//Cambia el Ancho de la Columna de conceptos
			}
			//e.Item.Cells[4].Style.Add("display","none");
			this.GeneraFecha();
			//DateTime Fecha = Convert.ToDateTime(DateTime.DaysInMonth(Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA]).Year,Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA]).Month) + "/" + Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA]).Month.ToString().PadLeft(2,'0') + "/"  + Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA]).Year.ToString());

			if(e.Item.ItemType == ListItemType.Header)
			{
				string Prefijo = (Convert.ToInt32(Page.Request.Params[KEYQIDACUMULADO]) == Utilitario.Constantes.ValorConstanteUno)?TITULOAL:TITULODEL;

				#region Query Principal
				//Parametros de Url Para Sima Peru y SIma Iquitos
				url = ((url.Length > 0)?url: this.QueryPrincipal());
				#endregion

				#region Columnas de Datos de Ejecucion Sima Peru / Sima Iquitos
				//Datos de  Ejecucion
				//Mes Anterior
				//if (FechaPeriodo.Month > 1)
			{
				//Nombre de Mes Anterior
				string NombreMesAnterior = ((FechaPeriodo.Month==1)?Convert.ToString(FechaPeriodo.Year-1) + "<br>":Utilitario.Constantes.VACIO) +  Helper.ObtenerNombreMes(((FechaPeriodo.Month==1)?12: FechaPeriodo.Month-1) ,Utilitario.Enumerados.TipoDatoMes.Abreviatura).ToUpper();
				#region Sima Peru Mes Anterior
				e.Item.Cells[1].Text = NombreMesAnterior;
				e.Item.Cells[1].ToolTip= Prefijo + TITULOMES + Helper.ObtenerNombreMes(((FechaPeriodo.Month==1)?12: FechaPeriodo.Month-1),Utilitario.Enumerados.TipoDatoMes.NombreCompleto);
				e.Item.Cells[1].Font.Size=7;
				#endregion
				#region Sima Iquitos Mes Anterior
				e.Item.Cells[6].Text = NombreMesAnterior;
				e.Item.Cells[6].ToolTip= Prefijo + TITULOMES + Helper.ObtenerNombreMes(((FechaPeriodo.Month==1)?12: FechaPeriodo.Month-1),Utilitario.Enumerados.TipoDatoMes.NombreCompleto);
				e.Item.Cells[6].Font.Size=7;
				#endregion
			}
				//Mes Actual
				#region Sima Peru Mes Actual
				//e.Item.Cells[2].Text = Prefijo + " MES<br>DE<br>" + Helper.ObtenerNombreMes(FechaPeriodo.Month,Utilitario.Enumerados.TipoDatoMes.NombreCompleto).ToUpper();
				e.Item.Cells[2].Text = Helper.ObtenerNombreMes(FechaPeriodo.Month,Utilitario.Enumerados.TipoDatoMes.NombreCompleto).ToUpper().Substring(0,3);
				e.Item.Cells[2].ToolTip = Prefijo + TITULOMES + Helper.ObtenerNombreMes(FechaPeriodo.Month,Utilitario.Enumerados.TipoDatoMes.NombreCompleto);
				e.Item.Cells[2].Font.Size=7;
				if ((Convert.ToInt32(Page.Request.Params[KEYQIDACUMULADO]) ==1))
				{
					e.Item.Cells[2].Font.Underline=true;
					e.Item.Cells[2].Style.Add(Utilitario.Constantes.CURSOR,Utilitario.Constantes.TIPOCURSORMANO);
					e.Item.Cells[2].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado(Utilitario.Constantes.VACIO));
					e.Item.Cells[2].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.POPUPDEESPERA + Helper.MostrarVentana(URLEJECUCIONREAL,
						KEYQIDEMPRESA + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.IDEMPRESASIMAPERU.ToString() 
						+ Utilitario.Constantes.SIGNOAMPERSON
						+ NOMBRECENTRO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.KEYIDNOMBRECENTROPERU.ToString()+ url));
				}
				#endregion
				#region Sima Iquitos Mes Actual
				//e.Item.Cells[7].Text = Prefijo + " MES<br>DE<br>" + Helper.ObtenerNombreMes(FechaPeriodo.Month,Utilitario.Enumerados.TipoDatoMes.NombreCompleto).ToUpper();
				e.Item.Cells[7].Text = Helper.ObtenerNombreMes(FechaPeriodo.Month,Utilitario.Enumerados.TipoDatoMes.NombreCompleto).ToUpper().Substring(0,3);
				e.Item.Cells[7].ToolTip = Prefijo + TITULOMES + Helper.ObtenerNombreMes(FechaPeriodo.Month,Utilitario.Enumerados.TipoDatoMes.NombreCompleto);
				e.Item.Cells[7].Font.Size=7;
				if ((Convert.ToInt32(Page.Request.Params[KEYQIDACUMULADO]) ==1))
				{
					e.Item.Cells[7].Font.Underline=true;
					e.Item.Cells[7].Style.Add(Utilitario.Constantes.CURSOR,Utilitario.Constantes.TIPOCURSORMANO);
					e.Item.Cells[7].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado(Utilitario.Constantes.VACIO));
					e.Item.Cells[7].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.POPUPDEESPERA +Helper.MostrarVentana(URLEJECUCIONREAL,
						KEYQIDEMPRESA + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.IDEMPRESASIMAIQUITOS.ToString() 
						+ Utilitario.Constantes.SIGNOAMPERSON
						+ NOMBRECENTRO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.KEYIDNOMBRECENTROIQUITOS.ToString()+ url));
				}
				#endregion
				#endregion

				#region Columna de Datos de Presupuesto
				//Datos de Presupuesto
				#region Presupuesto Sima Peru
				//e.Item.Cells[4].Text = "PRESU-<BR>PUESTO";
				e.Item.Cells[4].Text = TITULOPTO;
				e.Item.Cells[4].ToolTip=TITULOPTOPERIODO + FechaPeriodo.Year.ToString();
				e.Item.Cells[4].Font.Size=7;
				e.Item.Cells[4].Font.Underline=true;
				e.Item.Cells[4].Style.Add(Utilitario.Constantes.CURSOR,Utilitario.Constantes.TIPOCURSORMANO);
				e.Item.Cells[4].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado(Utilitario.Constantes.VACIO));

				e.Item.Cells[4].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.POPUPDEESPERA +Helper.MostrarVentana(URLPRESUPUESTO,
					KEYQIDEMPRESA + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.IDEMPRESASIMAPERU.ToString() 
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ NOMBRECENTRO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.KEYIDNOMBRECENTROPERU.ToString()+ url));
				#endregion

				#region Sima - Iquitos
				//e.Item.Cells[9].Text = "PRESU-<BR>PUESTO";
				e.Item.Cells[9].Text = TITULOPTO;
				e.Item.Cells[9].ToolTip=TITULOPTOPERIODO + FechaPeriodo.Year.ToString();
				e.Item.Cells[9].Font.Size=7;
				e.Item.Cells[9].Font.Underline=true;
				e.Item.Cells[9].Style.Add(Utilitario.Constantes.CURSOR,Utilitario.Constantes.TIPOCURSORMANO);
				e.Item.Cells[9].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado(Utilitario.Constantes.VACIO));

				e.Item.Cells[9].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.POPUPDEESPERA +Helper.MostrarVentana(URLPRESUPUESTO,
					KEYQIDEMPRESA + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.IDEMPRESASIMAIQUITOS.ToString() 
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ NOMBRECENTRO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.KEYIDNOMBRECENTROIQUITOS.ToString()+ url));
				#endregion
				#endregion

				#region Columna de Acumulado Sima Peru / Sima Iquitos
				#region Sima Peru
				//e.Item.Cells[3].Text = "ACU-<BR>MULADO";
				e.Item.Cells[3].Text = TITULOACUM;
				e.Item.Cells[3].ToolTip =TITULOACUMMES + Helper.ObtenerNombreMes(FechaPeriodo.Month,Utilitario.Enumerados.TipoDatoMes.NombreCompleto) + RANGO + FechaPeriodo.Year.ToString();
				e.Item.Cells[3].Font.Size=7;
				if ((Convert.ToInt32(Page.Request.Params[KEYQIDACUMULADO]) ==0))
				{
					e.Item.Cells[3].Font.Underline= true;
					e.Item.Cells[3].Style.Add(Utilitario.Constantes.CURSOR,Utilitario.Constantes.TIPOCURSORMANO);
					e.Item.Cells[3].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado(Utilitario.Constantes.VACIO));
					e.Item.Cells[3].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.POPUPDEESPERA +Helper.MostrarVentana(URLEJECUCIONREAL,
						KEYQIDEMPRESA + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.IDEMPRESASIMAPERU.ToString() 
						+ Utilitario.Constantes.SIGNOAMPERSON
						+ NOMBRECENTRO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.KEYIDNOMBRECENTROPERU.ToString()+ url));
				}
				#endregion
				#region Sima Iquitos
				//e.Item.Cells[8].Text = "ACU-<BR>MULADO";
				e.Item.Cells[8].Text = TITULOACUM;
				e.Item.Cells[8].ToolTip =TITULOACUMMES + Helper.ObtenerNombreMes(FechaPeriodo.Month,Utilitario.Enumerados.TipoDatoMes.NombreCompleto) + RANGO + FechaPeriodo.Year.ToString();
				e.Item.Cells[8].Font.Size=7;
				if ((Convert.ToInt32(Page.Request.Params[KEYQIDACUMULADO]) ==0))
				{
					e.Item.Cells[8].Font.Underline=true;
					e.Item.Cells[8].Style.Add(Utilitario.Constantes.CURSOR,Utilitario.Constantes.TIPOCURSORMANO);
					e.Item.Cells[8].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado(Utilitario.Constantes.VACIO));
					e.Item.Cells[8].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.POPUPDEESPERA +Helper.MostrarVentana(URLEJECUCIONREAL,
						KEYQIDEMPRESA + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.IDEMPRESASIMAIQUITOS.ToString() 
						+ Utilitario.Constantes.SIGNOAMPERSON
						+ NOMBRECENTRO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.KEYIDNOMBRECENTROIQUITOS.ToString()+ url));
				}
				#endregion
				#endregion

				#region Columnas de Proyeccion Sima Peru / SIma Iquitos
				#region Sima Peru
				//e.Item.Cells[5].Text = "PROYEC-<BR>TADO";
				e.Item.Cells[5].Text = TITULOPROYECTADO;
				e.Item.Cells[5].ToolTip=TITULOPROYPERIODO + FechaPeriodo.Year.ToString();
				e.Item.Cells[5].Font.Size=7;
				e.Item.Cells[5].Font.Underline=true;
				e.Item.Cells[5].Style.Add(Utilitario.Constantes.CURSOR,Utilitario.Constantes.TIPOCURSORMANO);
				e.Item.Cells[5].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado(Utilitario.Constantes.VACIO));
				e.Item.Cells[5].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.POPUPDEESPERA +Helper.MostrarVentana(URLPRROYECCION,
					KEYQIDEMPRESA + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.IDEMPRESASIMAPERU.ToString() 
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ NOMBRECENTRO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.KEYIDNOMBRECENTROPERU.ToString()+ url));

				#endregion

				#region Sima Iquitos
				//e.Item.Cells[10].Text = "PROYEC-<BR>TADO";
				e.Item.Cells[10].Text = TITULOPROYECTADO;
				e.Item.Cells[10].ToolTip=TITULOPROYPERIODO + FechaPeriodo.Year.ToString();
				e.Item.Cells[10].Font.Size=7;
				e.Item.Cells[10].Font.Underline=true;
				e.Item.Cells[10].Style.Add(Utilitario.Constantes.CURSOR,Utilitario.Constantes.TIPOCURSORMANO);
				e.Item.Cells[10].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado(Utilitario.Constantes.VACIO));
				e.Item.Cells[10].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.POPUPDEESPERA + Helper.MostrarVentana(URLPRROYECCION,
					KEYQIDEMPRESA + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.IDEMPRESASIMAIQUITOS.ToString() 
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ NOMBRECENTRO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.KEYIDNOMBRECENTROIQUITOS.ToString()+ url));
				#endregion

				#endregion
			
			}
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				
				//Para el Rubro de Gastos de Administracion del Formato de Estado de Gancias y Perdias se Mostrara un Detalle Personalizado
				//string Pagina = (Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO])== Utilitario.Constantes.KEYIDFORMATOESTADODEGANACIASYPERDIDAS && Convert.ToInt32(dr["idRubro"])== 24)? URLDETALLEPERSONALIZADO:URLDETALLE;
				//string Pagina = URLDETALLE;


				
				string strQuery = KEYQVERIQUITOS  + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(Utilitario.Constantes.ValorConstanteUno)
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYQNOMBRERUBRO + Utilitario.Constantes.SIGNOIGUAL + dr[COLUMNACONCEPTO].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYQIDFORMATO + Utilitario.Constantes.SIGNOIGUAL +  Page.Request.Params[KEYQIDFORMATO].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYQIDRUBRO + Utilitario.Constantes.SIGNOIGUAL + dr[COLUMNAIDRUBRO].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYQIDFECHA  + Utilitario.Constantes.SIGNOIGUAL +   FechaPeriodo.ToShortDateString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYQIDIDTIPOINFORMACION + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(Utilitario.Constantes.ValorConstanteCero)
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYQIDINTERFAZ + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(Utilitario.Constantes.ValorConstanteUno);


				//Mostrar Parametros de centros				

				string DescCallao = MENSAJESSINDESCRIPCION;
				string DescChimbote = MENSAJESSINDESCRIPCION;
				string DescIquitos = MENSAJESSINDESCRIPCION;
				string DescPeru = MENSAJESSINDESCRIPCION;
				
				if(dr[KEYQOBSCALLAO].ToString() != String.Empty)
				{
					DescCallao = dr[KEYQOBSCALLAO].ToString();//Helper.ReemplazarValoresEditorJS(dr[KEYQOBSCALLAO].ToString());
				}

				if(dr[KEYQOBSCHIMBOTE].ToString() != String.Empty)
				{
					DescChimbote = dr[KEYQOBSCHIMBOTE].ToString();//Helper.ReemplazarValoresEditorJS(dr[KEYQOBSCHIMBOTE].ToString());
				}
					
				if(dr[KEYQOBSIQUITOS].ToString() != String.Empty)
				{
					DescIquitos = dr[KEYQOBSIQUITOS].ToString();//Helper.ReemplazarValoresEditorJS(dr[KEYQOBSIQUITOS].ToString());
				}

				if(dr[KEYQOBSPERU].ToString() != String.Empty)
				{
					DescPeru = dr[KEYQOBSPERU].ToString();//Helper.ReemplazarValoresEditorJS(dr[KEYQOBSPERU].ToString());
				}
	
				/*string MetodoMostrar = Helper.MostrarDatosEnCajaTexto("hObsCallao",Helper.EncodeText(DescCallao))+ 
					Helper.MostrarDatosEnCajaTexto("hObsChimbote",Helper.EncodeText(DescChimbote)) +
					Helper.MostrarDatosEnCajaTexto("hObsIquitos",Helper.EncodeText(DescIquitos)) + 
					Helper.MostrarDatosEnCajaTexto("hObsPeru",Helper.EncodeText(DescPeru));
				*/
				string MetodoMostrar = Helper.MostrarDatosEnCajaTexto("hObsCallao",DescCallao)+ 
					Helper.MostrarDatosEnCajaTexto("hObsChimbote",DescChimbote) +
					Helper.MostrarDatosEnCajaTexto("hObsIquitos",DescIquitos) + 
					Helper.MostrarDatosEnCajaTexto("hObsPeru",DescPeru);
				


				string Pagina = String.Empty;
				string sVentana = String.Empty;
				int valorFormato = Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO]);
				int valorRUBRO = Convert.ToInt32(dr[COLUMNAIDRUBRO]);
				if (Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO])== Utilitario.Constantes.KEYIDFORMATOESTADODEGANACIASYPERDIDAS &&
					(
					Convert.ToInt32(dr[COLUMNAIDRUBRO]) == 17 ||
					Convert.ToInt32(dr[COLUMNAIDRUBRO]) == 18 ||
					Convert.ToInt32(dr[COLUMNAIDRUBRO]) == 19 ||
					Convert.ToInt32(dr[COLUMNAIDRUBRO]) == 20 ||
					Convert.ToInt32(dr[COLUMNAIDRUBRO]) == 21 ||
					Convert.ToInt32(dr[COLUMNAIDRUBRO]) == 22 ||
					Convert.ToInt32(dr[COLUMNAIDRUBRO]) == 23 ))
				{
					Pagina = URLFORMATORUBROMOVIMIENTOVCV + strQuery ;
					sVentana = MetodoMostrar + "AsignarValor();" +  
						Helper.PopupDialogoModal(Pagina,800,600,false);
				}
				else
				{
					if((valorFormato == 21) && (Convert.ToInt32(dr[COLUMNAIDRUBRO])== 26))
					{
						Pagina = URLFORMATORUBROMOVIMIENTODES + strQuery ;
						sVentana = MetodoMostrar + "AsignarValor();" + 
							Helper.PopupDialogoModal(Pagina,800,600,false);
					}
					else 
					{
						Pagina = URLFORMATORUBROMOVIMIENTO + strQuery ;
						sVentana = MetodoMostrar + "AsignarValor();" + 
							Helper.PopupDialogoModal(Pagina,800,600,false);
					}
				
				}
				
				Utilitario.Helper.ConfiguraNodosTreeview(e,2,Convert.ToInt32(Page.Request.Params[KEYQIDNIVELEXPANDE]),dr,Utilitario.Constantes.POPUPDEESPERA,Helper.HistorialIrAdelantePersonalizado(Utilitario.Constantes.VACIO),sVentana);
				e.Item.Cells[0].Attributes.Add(Constantes.EVENTODBLCLICK,sVentana);
				CEstadosFinancieros oCEstadosFinancieros = new CEstadosFinancieros();
				DataRow drConcepto= oCEstadosFinancieros.ConsultarConceptoDeEstadosFinancierosPorFormatoyRubro(Convert.ToInt32(dr["idformato"]),Convert.ToInt32(dr["idrubro"]) );
				if(drConcepto!=null)
					//e.Item.Cells[0].ToolTip=drConcepto["concepto"].ToString().Replace("?","").ToUpper();
					e.Item.Cells[0].Attributes["CONCEPTO"]=drConcepto["concepto"].ToString().Replace("?","").ToUpper();
					e.Item.Cells[0].ID="cellText";
					e.Item.Cells[0].Attributes["TITULO"]= dr["CONCEPTO"].ToString();

				if(Convert.ToInt32(dr[Enumerados.ColumnasFormato.FlgVerMonto.ToString()]) == 0 ) 
				{
					//Sima Peru
					e.Item.Cells[1].Text=String.Empty;
					e.Item.Cells[2].Text=String.Empty;
					e.Item.Cells[3].Text=String.Empty;
					e.Item.Cells[4].Text=String.Empty;
					e.Item.Cells[5].Text=String.Empty;
					//Sima Iquitos
					e.Item.Cells[6].Text=String.Empty;
					e.Item.Cells[7].Text=String.Empty;
					e.Item.Cells[8].Text=String.Empty;
					e.Item.Cells[9].Text=String.Empty;
					e.Item.Cells[10].Text=String.Empty;
				}
				else
				{
					//Sima Peru
					for(int Indice=1;Indice<=10;Indice++)
					{
						if(Session[KEYQNUEVOSSOLES] ==null)
						{
							e.Item.Cells[Indice].Text= Convert.ToDouble(Convert.ToDouble(e.Item.Cells[Indice].Text) /Utilitario.Constantes.MILES).ToString(Utilitario.Constantes.FORMATODECIMAL5);
							this.Label1.Text = TEXTOVERMILES;
						}
						else
						{
							if (Session[KEYQNUEVOSSOLES].ToString() == Utilitario.Constantes.SIVERMILES)
							{
								e.Item.Cells[Indice].Text= Convert.ToDouble(Convert.ToDouble(e.Item.Cells[Indice].Text) /Utilitario.Constantes.MILES).ToString(Utilitario.Constantes.FORMATODECIMAL5);
								this.Label1.Text = TEXTOVERMILES;
							}
							else
							{
								e.Item.Cells[Indice].Text= Convert.ToDouble(e.Item.Cells[Indice].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
								this.Label1.Text = TEXTONOVERMILES;
							}
						}
					}
				}
				if (Convert.ToInt32(dr[Enumerados.ColumnasFormato.IdTipoLinea.ToString()]) != 0 )
				{
					//e.Item.Font.Size = 7;
					//e.Item.Style.Add("font-size","11");
					e.Item.Font.Bold = true;
				}
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
			}		

		}

		private void gridHeader_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				e.Item.Visible=false;
			}
		}

		private void ddlbPeriodo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.LlenarGrilla();
		}

		private void dddblMes_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.LlenarGrilla();
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void ibtnImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.ReiniciarSession();
			this.LlenarJScript();
			this.LlenarCombos();
			this.LlenarDatos();
			this.ColspanRowspanHeader();
			this.LlenarGrilla();
			this.Imprimir();
		}

		private void btnGO_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("../../EnContruccion.aspx");
		}

		private void btnVentasCostos_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("../../EnContruccion.aspx");
		}

		private void ibtnProyPorLiquidar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			//Response.Redirect(URLPAGINAPROYPORLIQUIDAR + KEYIDSIT +Utilitario.Constantes.SIGNOIGUAL+"CON");
			Response.Redirect(URLESTADOSFINANCIEROSCUENTASPORLIQUIDARPROVISIONAR + 
				Helper.EstadosFinancierosQuery(Convert.ToDateTime(Page.Request.QueryString[KEYQIDFECHA]),
				Utilitario.Enumerados.EstadosFinancieros.idFormatoFlujodeCaja,
				Utilitario.Enumerados.EstadosFinancierosAcumulado.AcumuladoNo,
				Utilitario.Enumerados.EstadosFinancierosNivelExpande.Nivel0) +
				Utilitario.Constantes.SIGNOAMPERSON + KEYQFLAGDIRECTORIO +  Utilitario.Constantes.SIGNOIGUAL + 
				Utilitario.Constantes.POSICIONINDEXUNO);

		}

		private void ibtnCtasPorCobrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			string Query ="Periodo=" + Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA]).Year + "&Mes=" + 
				Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA]).Month + Utilitario.Constantes.SIGNOAMPERSON +
				KEYQFLAGDIRECTORIO +  Utilitario.Constantes.SIGNOIGUAL + 
				Utilitario.Constantes.POSICIONINDEXUNO;

			Response.Redirect(URLESTADOSFINANCIEROSCTASPORCOBRARPAGAR + Query);	
		}
		private void CargarHistoricos()
		{
			if(Page.Request.QueryString[KEYQIDNOMBREFORMATO].Trim() ==
				"Balance General")
			{
				lnkHistPeru.Visible = true;
				lnkHistorIquitos.Visible = true;
				CargarHistoricoIquitos();
				CargarHistoricoPeru();
			}
			else
			{
				lnkHistPeru.Visible = false;
				lnkHistorIquitos.Visible = false;
			}
		}
		private void CargarHistoricoPeru()
		{
			lnkHistPeru.NavigateUrl = System.Configuration.ConfigurationSettings.AppSettings[
				Utilitario.Constantes.RUTADOCUMENTOSDIRECTORIO2] +
				Utilitario.Constantes.RUTADIRECTORIOFINANCIERADOCSHISTORICOS +
				HISTORICO_PERU;
		}

		private void CargarHistoricoIquitos()
		{
			lnkHistorIquitos.NavigateUrl = System.Configuration.ConfigurationSettings.AppSettings[
				Utilitario.Constantes.RUTADOCUMENTOSDIRECTORIO2] +
				Utilitario.Constantes.RUTADIRECTORIOFINANCIERADOCSHISTORICOS +
				HISTORICO_IQUI;
		}	

	}
}
