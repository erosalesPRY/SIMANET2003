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
using NetAccessControl;

namespace SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancieros
{
	/// <summary>
	/// Summary description for PopupImpresionEstadosFinancieros.
	/// </summary>
	public class PopupImpresionEstadosFinancieros : System.Web.UI.Page, IPaginaBase
	{
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
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		#region Constantes
		const string KEYQIDFECHA = "efFecha";
		const string KEYQIDACUMULADO = "Acumulado";
		const string KEYQIDFORMATO = "IdFormato";	
		const string KEYQIDREPORTE = "IdReporte";
		const string KEYQIDNOMBREMES = "NombreMes";
		const string KEYQIDNOMBREFORMATO = "NFormato";
		const string KEYIDCENTRO ="IdCentro";


		const string KEYQIDEMPRESA = "idEmp";
		const string NOMBRECENTRO ="NombreCentro";
		const string NOMBRETIPOOPCION ="NombreOpcion";		
		const string KEYQIDRUBRO = "IdRubro";
		const string KEYQIDCLASIFICACIONRUBRO = "RubroClasf";
	
		const string KEYQIDNIVELEXPANDE = "NivelExp";

		const string KEYQIDIDTIPOINFORMACION ="idTipoInfo";
		const string KEYQVERIQUITOS ="Ver";
		const string KEYQNOMBRERUBRO ="NRubro";

		const string KEYQIDINTERFAZ = "interfaz";

		const string KEYQNUEVOSSOLES = "MILNS";
		

		const string URLPRESUPUESTO="../EstadosFinancierosPresupuestales/EstadosFinancierosFormulacion.aspx?";
		const string URLEJECUCIONREAL="EstadosFinancierosPorEmpresa.aspx?";
		const string URLEJECUCIONREALPORCENTRO="EstadosFinancierosPorCentroOperativo.aspx?";
		const string URLPRROYECCION="../EstadosFinancierosPresupuestales/EstadosFinancierosProyectados.aspx?";
		
		//Columnas DataGrid y DataTable
		const string COLUMNAPERUEJECUCIONREALMESANTERIOR ="PeruEjecucionRealDelmesAnterior";
		const string COLUMNAPERUEJECUCIONREALMESACTUAL ="PeruEjecucionRealDelmesActual";
		const string COLUMNAPERUPTOANUAL ="PeruPresupuestoAnual";

		const string COLUMNAIQUITOSEJECUCIONREALMESANTERIOR ="IquitosEjecucionRealDelmesAnterior";
		const string COLUMNAIQUITOSEJECUCIONREALMESACTUAL ="IquitosEjecucionRealDelmesActual";
		const string COLUMNAIQUITOSPTOANUAL ="IquitosPresupuestoAnual";

		//Otros
		const string TITULOCONCEPTO ="CONCEPTO";
		const string TITULOSIMAPERU ="SIMA-PERU S.A.";
		const string TITULOSIMAIQUITOS ="SIMA-IQUITOS S.R.Ltda";
		const string TITULOVERDETALLE ="Ver detalle ";
		const string UNION = " y ";
		const string TITULOAL ="Al";
		const string TITULODEL ="Del";
		const string TITULOMES =" Mes de ";
		const string TITULOPTO ="PPTO";
		const string TITULOACUMULADO ="ACUM";
		const string TITULOPROYECTADO ="PROY";
		const string TITULOPTOPERIODO ="Presupuesto Periodo ";
		const string TITULOACUMULADOMES ="Acumulado al Mes de ";
		const string TITULOACUMULADODEL =" del ";



		//Variables
		DateTime FechaPeriodo;
		private ASPNetDatagridDecorator m_add = new ASPNetDatagridDecorator();

		#endregion Constantes		

		#region Controles
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected projDataGridWeb.DataGridWeb gridHeader;
		protected System.Web.UI.WebControls.Label lblSolvenciaPresupuestoI;
		protected System.Web.UI.WebControls.Label lblSolvenciaDelMesI;
		protected System.Web.UI.WebControls.Label lblSolvenciaMesAnteriorI;
		protected System.Web.UI.WebControls.Label lblSolvenciaPresupuestoP;
		protected System.Web.UI.WebControls.Label lblSolvenciaDelMesP;
		protected System.Web.UI.WebControls.Label lblSolvenciaMesAnteriorP;
		protected System.Web.UI.WebControls.Label lblSolvencia;
		protected System.Web.UI.WebControls.Label lblLiquidezPresupuestoI;
		protected System.Web.UI.WebControls.Label lblLiquidezDelMesI;
		protected System.Web.UI.WebControls.Label lblLiquidezMesAnteriorI;
		protected System.Web.UI.WebControls.Label lblLiquidezPresupuestoP;
		protected System.Web.UI.WebControls.Label lblLiquidezDelMesP;
		protected System.Web.UI.WebControls.Label lblLiquidezMesAnteriorP;
		protected System.Web.UI.WebControls.Label lblLiquidez;
		protected System.Web.UI.HtmlControls.HtmlTable lblSollvenciaLiquidez;		
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label lblPeriodo;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label lblMes;
		protected System.Web.UI.WebControls.Label Label1;
		protected projDataGridWeb.DataGridWeb grid;
		#endregion Controles

		string url=String.Empty;
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					//Helper.ReiniciarSession();
					this.LlenarJScript();
					this.LlenarDatos();
					this.ColspanRowspanHeader();
					this.LlenarGrilla();
					this.Imprimir();
					
				}
				catch(SIMAExcepcionLog oSIMAExcepcionLog)
				{
					ltlMensaje.Text = Helper.MensajeAlert(oSIMAExcepcionLog.Mensaje);					
				}
				catch(SIMAExcepcionIU oSIMAExcepcionIU)
				{
					ltlMensaje.Text = Helper.MensajeAlert(oSIMAExcepcionIU.Mensaje);					
				}
				catch(SIMAExcepcion oSIMAExcepcion)
				{
					ltlMensaje.Text = Helper.MensajeAlert(oSIMAExcepcion.Mensaje);					
				}
				catch(Exception oException)
				{
					SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
					Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
				}
			}
		}
		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			CImpresion oCImpresion =  new CImpresion();
			DataTable dtImpresion =  oCImpresion.ObtenerDataImprimir();
			
			if(dtImpresion!=null)
			{				
				grid.DataSource = dtImpresion;
				//Determina el Liquidez y La Solvencia del Balance
				if (Convert.ToInt32(HttpContext.Current.Session[KEYQIDFORMATO])== Convert.ToInt32(Utilitario.Constantes.KEYIDFORMATOBALANCEGENERAL))
				{
					this.CalculodeSolvenciayLiquidez(dtImpresion.Select("idRubro = '55' or idRubro = '59'"," idRubro asc"),
						dtImpresion.Select("idRubro = '61' or idRubro = '68'"," idRubro asc"));
				}				
			}
			else
			{
				grid.DataSource = dtImpresion;
				//lblResultado.Text = GRILLAVACIA;				
			}
			grid.DataBind();
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add PopupImpresionEstadosFinancieros.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add PopupImpresionEstadosFinancieros.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add PopupImpresionEstadosFinancieros.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			this.GeneraFecha();
			lblTitulo.Text = CImpresion.ObtenerTituloReporteEstadosFinancieros();
			lblPeriodo.Text = FechaPeriodo.Year.ToString();
			//lblMes.Text = HttpContext.Current.Session[KEYQIDNOMBREMES].ToString().ToUpper();
			lblMes.Text = Convert.ToString(HttpContext.Current.Session[KEYQIDNOMBREMES]).ToUpper();
		}

		public void LlenarJScript()
		{
			lblLiquidez.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,"ShowPopupLS(1)");
			lblLiquidez.Font.Underline=true;
			lblLiquidez.Style.Add(Utilitario.Constantes.CURSOR,Utilitario.Constantes.TIPOCURSORMANO);

			lblSolvencia.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,"ShowPopupLS(0)");
			lblSolvencia.Font.Underline=true;
			lblSolvencia.Style.Add(Utilitario.Constantes.CURSOR,Utilitario.Constantes.TIPOCURSORMANO);
		}

		public void RegistrarJScript()
		{
			// TODO:  Add PopupImpresionEstadosFinancieros.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			ltlMensaje.Text=Helper.Imprimir();
		}

		public void Exportar()
		{
			// TODO:  Add PopupImpresionEstadosFinancieros.Exportar implementation
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
			// TODO:  Add PopupImpresionEstadosFinancieros.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void GeneraFecha()
		{
			FechaPeriodo =  
				Convert.ToDateTime(DateTime.DaysInMonth(Convert.ToDateTime(HttpContext.Current.Session[KEYQIDFECHA]).Year,Convert.ToDateTime(HttpContext.Current.Session[KEYQIDFECHA]).Month) 
				+ Utilitario.Constantes.SEPARADORFECHA + 
				Convert.ToDateTime(HttpContext.Current.Session[KEYQIDFECHA]).Month.ToString().PadLeft(2,'0') 
				+ Utilitario.Constantes.SEPARADORFECHA + 
				Convert.ToDateTime(HttpContext.Current.Session[KEYQIDFECHA]).Year.ToString());
		}

		private void CalculodeSolvenciayLiquidez(DataRow []drLiquidez,DataRow []drSolvencia)
		{
			if (drLiquidez !=null && drLiquidez.Length==2)//idrubro 55/59
			{
				#region Peru
				if (Convert.ToDouble(drLiquidez[1][COLUMNAPERUEJECUCIONREALMESANTERIOR]) >0) {lblLiquidezMesAnteriorP.Text =  (Convert.ToDouble(drLiquidez[0][COLUMNAPERUEJECUCIONREALMESANTERIOR]) / Convert.ToDouble(drLiquidez[1][COLUMNAPERUEJECUCIONREALMESANTERIOR])).ToString(Utilitario.Constantes.FORMATODECIMAL2);}
				if (Convert.ToDouble(drLiquidez[1][COLUMNAPERUEJECUCIONREALMESACTUAL]) >0) {lblLiquidezDelMesP.Text =  (Convert.ToDouble(drLiquidez[0][COLUMNAPERUEJECUCIONREALMESACTUAL]) / Convert.ToDouble(drLiquidez[1][COLUMNAPERUEJECUCIONREALMESACTUAL])).ToString(Utilitario.Constantes.FORMATODECIMAL2);}
				if (Convert.ToDouble(drLiquidez[1][COLUMNAPERUPTOANUAL]) >0) {lblLiquidezPresupuestoP.Text =  Convert.ToDecimal((Convert.ToDouble(drLiquidez[0][COLUMNAPERUPTOANUAL]) / Convert.ToDouble(drLiquidez[1][COLUMNAPERUPTOANUAL])).ToString()).ToString(Utilitario.Constantes.FORMATODECIMAL2);}
				#endregion
				#region Iquitos
				if (Convert.ToDouble(drLiquidez[1][COLUMNAIQUITOSEJECUCIONREALMESANTERIOR]) >0) {lblLiquidezMesAnteriorI.Text =  (Convert.ToDouble(drLiquidez[0][COLUMNAIQUITOSEJECUCIONREALMESANTERIOR]) / Convert.ToDouble(drLiquidez[1][COLUMNAIQUITOSEJECUCIONREALMESANTERIOR])).ToString(Utilitario.Constantes.FORMATODECIMAL2);}
				if (Convert.ToDouble(drLiquidez[1][COLUMNAIQUITOSEJECUCIONREALMESACTUAL]) >0) {lblLiquidezDelMesI.Text =  (Convert.ToDouble(drLiquidez[0][COLUMNAIQUITOSEJECUCIONREALMESACTUAL]) / Convert.ToDouble(drLiquidez[1][COLUMNAIQUITOSEJECUCIONREALMESACTUAL])).ToString(Utilitario.Constantes.FORMATODECIMAL2);}
				if (Convert.ToDouble(drLiquidez[1][COLUMNAIQUITOSPTOANUAL]) >0) {lblLiquidezPresupuestoI.Text =  (Convert.ToDouble(drLiquidez[0][COLUMNAIQUITOSPTOANUAL]) / Convert.ToDouble(drLiquidez[1][COLUMNAIQUITOSPTOANUAL])).ToString(Utilitario.Constantes.FORMATODECIMAL2);}
				#endregion
			}
			if (drSolvencia!=null && drSolvencia.Length==2)//idrubro 61/68
			{
				#region Peru
				if (Convert.ToDouble(drSolvencia[1][COLUMNAPERUEJECUCIONREALMESANTERIOR]) >0) {lblSolvenciaMesAnteriorP.Text =  Convert.ToDouble((Convert.ToDouble(drSolvencia[0][COLUMNAPERUEJECUCIONREALMESANTERIOR]) / Convert.ToDouble(drSolvencia[1][COLUMNAPERUEJECUCIONREALMESANTERIOR]))*100).ToString(Utilitario.Constantes.FORMATODECIMAL2) + Utilitario.Constantes.SIGNOPORCENTAJE;}
				if (Convert.ToDouble(drSolvencia[1][COLUMNAPERUEJECUCIONREALMESACTUAL]) >0) {lblSolvenciaDelMesP.Text =  Convert.ToDouble((Convert.ToDouble(drSolvencia[0][COLUMNAPERUEJECUCIONREALMESACTUAL]) / Convert.ToDouble(drSolvencia[1][COLUMNAPERUEJECUCIONREALMESACTUAL]))*100).ToString(Utilitario.Constantes.FORMATODECIMAL2)+ Utilitario.Constantes.SIGNOPORCENTAJE;}
				if (Convert.ToDouble(drSolvencia[1][COLUMNAPERUPTOANUAL]) >0) {lblSolvenciaPresupuestoP.Text =  Convert.ToDouble((Convert.ToDouble(drSolvencia[0][COLUMNAPERUPTOANUAL]) / Convert.ToDouble(drSolvencia[1][COLUMNAPERUPTOANUAL]))*100).ToString(Utilitario.Constantes.FORMATODECIMAL2)+ Utilitario.Constantes.SIGNOPORCENTAJE;}
				#endregion
				#region Iquitos
				if (Convert.ToDouble(drSolvencia[1][COLUMNAIQUITOSEJECUCIONREALMESANTERIOR]) >0) {lblSolvenciaMesAnteriorI.Text =  Convert.ToDouble((Convert.ToDouble(drSolvencia[0][COLUMNAIQUITOSEJECUCIONREALMESANTERIOR]) / Convert.ToDouble(drSolvencia[1][COLUMNAIQUITOSEJECUCIONREALMESANTERIOR])) *100).ToString(Utilitario.Constantes.FORMATODECIMAL2)+ Utilitario.Constantes.SIGNOPORCENTAJE;}
				if (Convert.ToDouble(drSolvencia[1][COLUMNAIQUITOSEJECUCIONREALMESACTUAL]) >0) {lblSolvenciaDelMesI.Text =  Convert.ToDouble((Convert.ToDouble(drSolvencia[0][COLUMNAIQUITOSEJECUCIONREALMESACTUAL]) / Convert.ToDouble(drSolvencia[1][COLUMNAIQUITOSEJECUCIONREALMESACTUAL]))*100).ToString(Utilitario.Constantes.FORMATODECIMAL2)+ Utilitario.Constantes.SIGNOPORCENTAJE;}
				if (Convert.ToDouble(drSolvencia[1][COLUMNAIQUITOSPTOANUAL]) >0) {lblSolvenciaPresupuestoI.Text =  Convert.ToDouble((Convert.ToDouble(drSolvencia[0][COLUMNAIQUITOSPTOANUAL]) / Convert.ToDouble(drSolvencia[1][COLUMNAIQUITOSPTOANUAL]))*100).ToString(Utilitario.Constantes.FORMATODECIMAL2)+ Utilitario.Constantes.SIGNOPORCENTAJE;}

				#endregion
			}
		}

		private void ColspanRowspanHeader()
		{			
			int NroColaMostrar = ((Convert.ToInt32(HttpContext.Current.Session[KEYQIDACUMULADO]) == Utilitario.Constantes.ValorConstanteUno)?
				(Convert.ToInt32(HttpContext.Current.Session[KEYQIDFORMATO]) == Utilitario.Constantes.KEYIDFORMATOCUENTASPORCOBRAR || Convert.ToInt32(HttpContext.Current.Session[KEYQIDFORMATO]) == Utilitario.Constantes.KEYIDFORMATOCUENTASPORPAGAR)?2:3
				:5);
			
			TableCell cell = null;
			m_add.DatagridToDecorate = grid;
			ArrayList header = new ArrayList();


			cell = new TableCell();
			cell.Text = TITULOCONCEPTO;
			cell.RowSpan = 2;
			cell.VerticalAlign = VerticalAlign.Middle;
			header.Add(cell);

			cell = new TableCell();
			cell.Text = TITULOSIMAPERU;
			cell.ToolTip=TITULOVERDETALLE + Utilitario.Constantes.SIGNOABREPARANTESIS + Utilitario.Constantes.KEYIDNOMBRECENTROCALLAO.ToString() + UNION + Utilitario.Constantes.KEYIDNOMBRECENTROCHIMBOTE.ToString() + Utilitario.Constantes.SIGNOCIERRAPARANTESIS;
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
			cell.Text = TITULOSIMAIQUITOS;
			cell.Font.Size = 11;
			cell.Font.Bold=true;
			cell.ColumnSpan = NroColaMostrar;//((Convert.ToInt32(Page.Request.Params[KEYQIDACUMULADO]) == 1)?3:5);
			cell.HorizontalAlign = HorizontalAlign.Center;
			header.Add(cell);
			m_add.AddMergeHeader(header);
			lblSollvenciaLiquidez.Visible = ((Convert.ToInt32(HttpContext.Current.Session[KEYQIDACUMULADO]) == Utilitario.Constantes.ValorConstanteUno && Convert.ToInt32(HttpContext.Current.Session[KEYQIDFORMATO])== Utilitario.Constantes.KEYIDFORMATOBALANCEGENERAL)?true:false);
		}

		private string QueryPrincipal()
		{
			this.GeneraFecha();
			string url = Utilitario.Constantes.SIGNOAMPERSON
				+ KEYIDCENTRO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.IDDEFAULT.ToString()
				+ Utilitario.Constantes.SIGNOAMPERSON
				+ KEYQIDFECHA + Utilitario.Constantes.SIGNOIGUAL + FechaPeriodo.ToShortDateString()
				+ Utilitario.Constantes.SIGNOAMPERSON
				+ KEYQIDNOMBREMES + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(HttpContext.Current.Session[KEYQIDNOMBREMES]).ToUpper()
				+ Utilitario.Constantes.SIGNOAMPERSON
				+ KEYQIDFORMATO + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(HttpContext.Current.Session[KEYQIDFORMATO])
				+ Utilitario.Constantes.SIGNOAMPERSON
				+ KEYQIDNOMBREFORMATO + Utilitario.Constantes.SIGNOIGUAL +  Convert.ToString(HttpContext.Current.Session[KEYQIDNOMBREFORMATO])
				+ Utilitario.Constantes.SIGNOAMPERSON
				+ KEYQIDREPORTE + Utilitario.Constantes.SIGNOIGUAL +  Convert.ToString(HttpContext.Current.Session[KEYQIDREPORTE])
				+ Utilitario.Constantes.SIGNOAMPERSON
				+ KEYQIDRUBRO + Utilitario.Constantes.SIGNOIGUAL +  Utilitario.Constantes.IDDEFAULT
				+ Utilitario.Constantes.SIGNOAMPERSON
				+ KEYQIDNIVELEXPANDE + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(HttpContext.Current.Session[KEYQIDNIVELEXPANDE])
				+ Utilitario.Constantes.SIGNOAMPERSON
				+ KEYQIDCLASIFICACIONRUBRO + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(HttpContext.Current.Session[KEYQIDCLASIFICACIONRUBRO])
				+ Utilitario.Constantes.SIGNOAMPERSON
				+ KEYQIDACUMULADO + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(HttpContext.Current.Session[KEYQIDACUMULADO]);
			return url;
		}	
	
		private void gridHeader_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				e.Item.Visible=false;
			}
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{	
			if (Convert.ToInt32(HttpContext.Current.Session[KEYQIDACUMULADO]) == Utilitario.Constantes.ValorConstanteUno)
			{	
				e.Item.Cells[0].Style.Add("width","20%");//Cambia el Ancho de la Columna de conceptos
				e.Item.Cells[3].Style.Add(Utilitario.Constantes.DISPLAY,Utilitario.Constantes.NONE);
				e.Item.Cells[5].Style.Add(Utilitario.Constantes.DISPLAY,Utilitario.Constantes.NONE);
				e.Item.Cells[8].Style.Add(Utilitario.Constantes.DISPLAY,Utilitario.Constantes.NONE);
				e.Item.Cells[10].Style.Add(Utilitario.Constantes.DISPLAY,Utilitario.Constantes.NONE);

				string visible = (Convert.ToInt32(HttpContext.Current.Session[KEYQIDFORMATO]) == Utilitario.Constantes.KEYIDFORMATOCUENTASPORCOBRAR || Convert.ToInt32(HttpContext.Current.Session[KEYQIDFORMATO]) == Utilitario.Constantes.KEYIDFORMATOCUENTASPORPAGAR)? Utilitario.Constantes.NONE:Utilitario.Constantes.BLOCK;
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
				string Prefijo = (Convert.ToInt32(HttpContext.Current.Session[KEYQIDACUMULADO]) == 1)?TITULOAL:TITULODEL;

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
				if ((Convert.ToInt32(HttpContext.Current.Session[KEYQIDACUMULADO]) == Utilitario.Constantes.ValorConstanteUno))
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
				if ((Convert.ToInt32(HttpContext.Current.Session[KEYQIDACUMULADO]) == Utilitario.Constantes.ValorConstanteUno))
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
				e.Item.Cells[9].ToolTip="Presupuesto Periodo " + FechaPeriodo.Year.ToString();
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
				e.Item.Cells[3].Text = TITULOACUMULADO;
				e.Item.Cells[3].ToolTip =TITULOACUMULADOMES + Helper.ObtenerNombreMes(FechaPeriodo.Month,Utilitario.Enumerados.TipoDatoMes.NombreCompleto) + TITULOACUMULADODEL + FechaPeriodo.Year.ToString();
				e.Item.Cells[3].Font.Size=7;
				if ((Convert.ToInt32(HttpContext.Current.Session[KEYQIDACUMULADO]) ==0))
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
				e.Item.Cells[8].Text = TITULOACUMULADO;
				e.Item.Cells[8].ToolTip =TITULOACUMULADOMES + Helper.ObtenerNombreMes(FechaPeriodo.Month,Utilitario.Enumerados.TipoDatoMes.NombreCompleto) + TITULOACUMULADODEL + FechaPeriodo.Year.ToString();
				e.Item.Cells[8].Font.Size=7;
				if ((Convert.ToInt32(HttpContext.Current.Session[KEYQIDACUMULADO]) ==0))
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
				e.Item.Cells[5].ToolTip="Proyección Periodo " + FechaPeriodo.Year.ToString();
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
				e.Item.Cells[10].ToolTip="Proyección Periodo " + FechaPeriodo.Year.ToString();
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


				
				/*string strQuery = KEYQVERIQUITOS  + Utilitario.Constantes.SIGNOIGUAL + "1"
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYQNOMBRERUBRO + Utilitario.Constantes.SIGNOIGUAL + dr["CONCEPTO"].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYQIDFORMATO + Utilitario.Constantes.SIGNOIGUAL +  Convert.ToString(HttpContext.Current.Session[KEYQIDFORMATO])
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYQIDRUBRO + Utilitario.Constantes.SIGNOIGUAL + dr["idRubro"].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYQIDFECHA  + Utilitario.Constantes.SIGNOIGUAL +   FechaPeriodo.ToShortDateString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYQIDIDTIPOINFORMACION + Utilitario.Constantes.SIGNOIGUAL + "0"
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYQIDINTERFAZ + Utilitario.Constantes.SIGNOIGUAL + "1";

				string Pagina = "";
				string sVentana="";
				if (Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO])== Utilitario.Constantes.KEYIDFORMATOESTADODEGANACIASYPERDIDAS &&
					Convert.ToInt32(dr["idRubro"]) == 10 ||
					Convert.ToInt32(dr["idRubro"]) == 11 ||
					Convert.ToInt32(dr["idRubro"]) == 12 ||
					Convert.ToInt32(dr["idRubro"]) == 13 ||
					Convert.ToInt32(dr["idRubro"]) == 14 ||
					Convert.ToInt32(dr["idRubro"]) == 15 ||
					Convert.ToInt32(dr["idRubro"]) == 16 ||
					Convert.ToInt32(dr["idRubro"]) == 17 ||
					Convert.ToInt32(dr["idRubro"]) == 18 ||
					Convert.ToInt32(dr["idRubro"]) == 19 ||
					Convert.ToInt32(dr["idRubro"]) == 20 ||
					Convert.ToInt32(dr["idRubro"]) == 21 ||
					Convert.ToInt32(dr["idRubro"]) == 22 ||
					Convert.ToInt32(dr["idRubro"]) == 23 )
				{
					Pagina = "ConsultarFormatoRubroMovimientoVCV.aspx?" + strQuery ;
					sVentana=Helper.PopupDialogoModal(Pagina,800,300,false);
				}
				else
				{
					Pagina = "ConsultarFormatoRubroMovimiento.aspx?" + strQuery ;
					sVentana=Helper.PopupDialogoModal(Pagina,600,300,false);
				}
*/
				Utilitario.Helper.ConfiguraNodosTreeview(e,
															2,
															5,/*Convert.ToInt32(HttpContext.Current.Session[KEYQIDNIVELEXPANDE]),*/
															dr,
															Utilitario.Constantes.POPUPDEESPERA,
															Helper.HistorialIrAdelantePersonalizado(Utilitario.Constantes.VACIO),
															String.Empty);

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
						}
						else
						{						
							if (Session[KEYQNUEVOSSOLES].ToString() == Utilitario.Constantes.SIVERMILES)
							{
								e.Item.Cells[Indice].Text= Convert.ToDouble(Convert.ToDouble(e.Item.Cells[Indice].Text) /Utilitario.Constantes.MILES).ToString(Utilitario.Constantes.FORMATODECIMAL5);
							}
							else
							{
								e.Item.Cells[Indice].Text= Convert.ToDouble(e.Item.Cells[Indice].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
							}
						}
						/*
						if (System.Configuration.ConfigurationSettings.AppSettings[Utilitario.Constantes.KEYVERMILESNUEVOSSOLES] == Utilitario.Constantes.SIVERMILES)
						{
							e.Item.Cells[Indice].Text= Convert.ToDouble(Convert.ToDouble(e.Item.Cells[Indice].Text) /Utilitario.Constantes.MILES).ToString(Utilitario.Constantes.FORMATODECIMAL5);
						}
						else
						{
							e.Item.Cells[Indice].Text= Convert.ToDouble(e.Item.Cells[Indice].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
						}
						*/
					}
				}
				if (Convert.ToInt32(dr[Enumerados.ColumnasFormato.IdTipoLinea.ToString()]) != Utilitario.Constantes.ValorConstanteCero)
				{
					//e.Item.Font.Size = 7;
					//e.Item.Style.Add("font-size","11");
					e.Item.Font.Bold = true;
				}
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
			}	
		}		
	}
}
