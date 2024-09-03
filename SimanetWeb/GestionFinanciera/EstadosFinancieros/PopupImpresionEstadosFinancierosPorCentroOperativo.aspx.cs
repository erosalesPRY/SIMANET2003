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
	/// Summary description for PopupImpresionEstadosFinancierosPorCentroOperativo.
	/// </summary>
	public class PopupImpresionEstadosFinancierosPorCentroOperativo : System.Web.UI.Page, IPaginaBase
	{
		#region Controles
		private ASPNetDatagridDecorator m_add = new ASPNetDatagridDecorator();
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label lblPeriodo;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label lblMes;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion Controles


		#region Constantes
		//Key Session y QueryString
		const string KEYQIDEMPRESA = "idEmp";
		const string KEYIDCENTRO ="IdCentro";
		const string NOMBRECENTRO ="NombreCentro";
		const string NOMBRETIPOOPCION ="NombreOpcion";
		const string KEYQIDNOMBREFORMATO = "NFormato";
		const string KEYQIDFECHA = "efFecha";
		const string KEYQIDNOMBREMES = "NombreMes";


		const string KEYQIDINTERFAZ = "interfaz";

		const string KEYQIDFORMATO = "IdFormato";
		const string KEYQIDREPORTE = "IdReporte";
		const string KEYQIDRUBRO = "IdRubro";
		const string KEYQIDACUMULADO = "Acumulado";
		const string KEYQIDNIVELEXPANDE = "NivelExp";
		const string KEYQIDCLASIFICACIONRUBRO = "RubroClasf";	

		const string KEYQIDIDTIPOINFORMACION ="idTipoInfo";
		const string KEYQVERIQUITOS ="Ver";
		const string KEYQNOMBRERUBRO ="NRubro";


		const string KEYQNRODIGITOS ="NroDig";
		const string KEYQDIGCUENTA = "DigCuenta";

		const string KEYQNUEVOSSOLES = "MILNS";

		//*********Campos Cabeceras****************
		//Sima Callao
		const string CAMPOHC1 = "lblPresupuestoHC";
		const string CAMPOHC2 = "lblEjecutadoHC";
		const string CAMPOHC3 = "lblSaldoHC";
		const string CAMPOHC4 = "lblProyectadoHC";
		//Sima Iquitos
		const string CAMPOHCH1 = "lblPresupuestoHCH";
		const string CAMPOHCH2 = "lblEjecutadoHCH";
		const string CAMPOHCH3 = "lblSaldoHCH";
		const string CAMPOHCH4 = "lblProyectadoHCH";


		const int NRODIGINI = 2;
		const int DIGCTA = 0;
			

		const string GRILLAVACIA="No existen";

		//URL
		const string URLPRESUPUESTO="../EstadosFinancierosPresupuestales/EstadosFinancierosFormulacion.aspx?";
		const string URLEJECUCIONREAL="EstadosFinancierosPorEmpresa.aspx?";
		const string URLPROYECTADO="../EstadosFinancierosPresupuestales/EstadosFinancierosProyectados.aspx?";
		const string URLDETALLE="EstadosFinancierosPorCentroOperativoDetalle.aspx?";
		const string URLDETALLEPERSONALIZADO="EstadosFinancierosCorporativoDetallePersonalizado.aspx?";
		const string URLFORMATORUBROMOVIMIENTOVCV ="ConsultarFormatoRubroMovimientoVCV.aspx?";
		const string URLFORMATORUBROMOVIMIENTO ="ConsultarFormatoRubroMovimiento.aspx?";

		//Datos DataGrid y DataTable
		const string TITULOCONCEPTO ="CONCEPTO";
		const string TITULOSIMACALLAO="SIMA-CALLAO";
		const string TITULOSIMACHIMBOTE ="SIMA-CHIMBOTE";
		const string TITULOPTO ="PPTO";
		const string TITULOACUMULADO ="ACUM";
		const string TITULOPROYECTADO="PROY";

		const string TITULOAL ="Al";
		const string TITULODEL ="Del";
		const string TITULOMES =" Mes de ";
		const string TITULOPTOPERIODO ="Presupuesto Periodo ";
		const string TITULOACUMULADOMES ="Acumulado al Mes de ";
		const string TITULOPROYPERIODO ="Proyección Periodo ";

		//DataGrid and DataTable
		const string COLUMNACONCEPTO ="CONCEPTO";
		const string COLUMNAIDRUBRO ="idRubro";


		//Variables
		
		#endregion	
		

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

		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				if(!Page.IsPostBack)
				{
					this.ConfigurarAccesoControles();					
					this.LlenarJScript();
					this.LlenarCombos();
					this.LlenarDatos();
					this.ColspanRowspanHeader();
					this.LlenarGrilla();
					this.Imprimir();
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
		}

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			CImpresion oCImpresion =  new CImpresion();
			DataTable dtImpresion =  oCImpresion.ObtenerDataImprimir();

			if(dtImpresion != null)
			{	
				grid.DataSource = dtImpresion;
			}
			grid.DataBind();
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add PopupImpresionEstadosFinancierosPorCentroOperativo.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add PopupImpresionEstadosFinancierosPorCentroOperativo.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add PopupImpresionEstadosFinancierosPorCentroOperativo.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			this.lblTitulo.Text = CImpresion.ObtenerTituloReporteEstadosFinancieros();
			this.lblPeriodo.Text = Convert.ToDateTime(HttpContext.Current.Session[KEYQIDFECHA]).Year.ToString();
			this.lblMes.Text = Convert.ToString(HttpContext.Current.Session[KEYQIDNOMBREMES]).ToUpper();
		}

		public void LlenarJScript()
		{
			// TODO:  Add PopupImpresionEstadosFinancierosPorCentroOperativo.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add PopupImpresionEstadosFinancierosPorCentroOperativo.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			ltlMensaje.Text=Helper.Imprimir();
		}

		public void Exportar()
		{
			// TODO:  Add PopupImpresionEstadosFinancierosPorCentroOperativo.Exportar implementation
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
			// TODO:  Add PopupImpresionEstadosFinancierosPorCentroOperativo.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void ColspanRowspanHeader()
		{			
			int NroColaMostrar = ((Convert.ToInt32(HttpContext.Current.Session[KEYQIDACUMULADO]) == Utilitario.Constantes.ValorConstanteUno)?
				(Convert.ToInt32(HttpContext.Current.Session[KEYQIDFORMATO]) == Utilitario.Constantes.KEYIDFORMATOCUENTASPORCOBRAR)?2:3
				:5);
			//DateTime Fecha = Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA]);
			TableCell cell = null;
			m_add.DatagridToDecorate = grid;
			ArrayList header = new ArrayList();


			cell = new TableCell();
			cell.Text = TITULOCONCEPTO;
			cell.RowSpan = 2;
			cell.VerticalAlign = VerticalAlign.Middle;
			header.Add(cell);

			cell = new TableCell();
			cell.Text = TITULOSIMACALLAO;
			cell.Font.Size = 10;
			cell.ColumnSpan = NroColaMostrar;//((Convert.ToInt32(Page.Request.Params[KEYQIDACUMULADO]) == 1)?3:5);
			cell.HorizontalAlign = HorizontalAlign.Center;
			header.Add(cell);

			cell = new TableCell();
			cell.Text = TITULOSIMACHIMBOTE;
			cell.Font.Size = 10;
			cell.ColumnSpan = NroColaMostrar;//((Convert.ToInt32(Page.Request.Params[KEYQIDACUMULADO]) == 1)?3:5);
			cell.HorizontalAlign = HorizontalAlign.Center;
			header.Add(cell);
			m_add.AddMergeHeader(header);
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			DateTime Fecha = Convert.ToDateTime(HttpContext.Current.Session[KEYQIDFECHA]);
			if (Convert.ToInt32(HttpContext.Current.Session[KEYQIDACUMULADO]) == 1)
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
				e.Item.Cells[0].Style.Add("width","17%");//Cambia el Ancho de la Columna de conceptos
			}
			#region Query Principal
			//Parametros de Url Para Sima Peru y SIma Iquitos
			string urlGeneral = Utilitario.Constantes.SIGNOAMPERSON
				+ KEYQIDEMPRESA + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.IDDEFAULT.ToString()
				+ Utilitario.Constantes.SIGNOAMPERSON
				+ KEYQIDFECHA + Utilitario.Constantes.SIGNOIGUAL + Fecha.ToShortDateString()
				+ Utilitario.Constantes.SIGNOAMPERSON
				+ KEYQIDNOMBREMES + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(HttpContext.Current.Session[KEYQIDNOMBREMES])
				+ Utilitario.Constantes.SIGNOAMPERSON
				+ KEYQIDFORMATO + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(HttpContext.Current.Session[KEYQIDFORMATO])
				+ Utilitario.Constantes.SIGNOAMPERSON
				+ KEYQIDNOMBREFORMATO + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(HttpContext.Current.Session[KEYQIDNOMBREFORMATO])
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

			#endregion
			
			if(e.Item.ItemType == ListItemType.Header)
			{
				string Prefijo = (Convert.ToInt32(HttpContext.Current.Session[KEYQIDACUMULADO]) == Utilitario.Constantes.ValorConstanteUno)?TITULOAL:TITULODEL;
				
				#region Query Principal
				//Parametros de Url Para Sima Peru y SIma Iquitos
				//url = ((url.Length > 0)?url: this.QueryPrincipal());
				#endregion

				#region Columnas de Datos de Ejecucion Sima Peru / Sima Iquitos
				//Datos de  Ejecucion
				//Mes Anterior
				string NombreMesAnterior = ((Fecha.Month==1)?Convert.ToString(Fecha.Year-1) + "<br>":Utilitario.Constantes.VACIO) +  Helper.ObtenerNombreMes(((Fecha.Month==1)?12: Fecha.Month-1) ,Utilitario.Enumerados.TipoDatoMes.Abreviatura).ToUpper();
				#region Sima Callao Mes Anterior
				e.Item.Cells[1].Text =  NombreMesAnterior;
				e.Item.Cells[1].ToolTip = Prefijo + NombreMesAnterior.Replace("<br>",Utilitario.Constantes.ESPACIO);
				e.Item.Cells[1].Font.Size=7;
				#endregion
				#region Sima Iquitos Mes Anterior
				e.Item.Cells[6].Text = NombreMesAnterior;
				e.Item.Cells[6].ToolTip = Prefijo + NombreMesAnterior.Replace("<br>",Utilitario.Constantes.ESPACIO);
				e.Item.Cells[6].Font.Size=7;
				#endregion
				
				//Mes Actual
				#region Sima Callao Mes Actual
				//e.Item.Cells[2].Text = Prefijo + " MES<br>DE<br>" + Helper.ObtenerNombreMes(Fecha.Month,Utilitario.Enumerados.TipoDatoMes.NombreCompleto).ToUpper();
				e.Item.Cells[2].Text = Helper.ObtenerNombreMes(Fecha.Month,Utilitario.Enumerados.TipoDatoMes.NombreCompleto).ToUpper().Substring(0,3);
				e.Item.Cells[2].ToolTip = Prefijo + TITULOMES + Helper.ObtenerNombreMes(Fecha.Month,Utilitario.Enumerados.TipoDatoMes.NombreCompleto);
				e.Item.Cells[2].Font.Size=7;
				if ((Convert.ToInt32(HttpContext.Current.Session[KEYQIDACUMULADO]) == Utilitario.Constantes.ValorConstanteUno))
				{
					//e.Item.Cells[2].Font.Underline=true;
					//e.Item.Cells[2].Style.Add(Utilitario.Constantes.CURSOR,Utilitario.Constantes.TIPOCURSORMANO);
					//e.Item.Cells[2].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado(""));
//					e.Item.Cells[2].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.POPUPDEESPERA + Helper.MostrarVentana(URLEJECUCIONREAL,
//						KEYIDCENTRO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.KEYIDCENTROCALLAO.ToString() 
//						+ Utilitario.Constantes.SIGNOAMPERSON
//						+ NOMBRECENTRO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.KEYIDNOMBRECENTROCALLAO.ToString() + urlGeneral));
				}
				#endregion
				#region Sima Chimbote Mes Actual
				//e.Item.Cells[7].Text = Prefijo + " MES<br>DE<br>" + Helper.ObtenerNombreMes(Fecha.Month,Utilitario.Enumerados.TipoDatoMes.NombreCompleto).ToUpper();
				e.Item.Cells[7].Text = Helper.ObtenerNombreMes(Fecha.Month,Utilitario.Enumerados.TipoDatoMes.NombreCompleto).ToUpper().Substring(0,3);
				e.Item.Cells[7].ToolTip = Prefijo + TITULOMES + Helper.ObtenerNombreMes(Fecha.Month,Utilitario.Enumerados.TipoDatoMes.NombreCompleto);
				e.Item.Cells[7].Font.Size=7;
				if ((Convert.ToInt32(HttpContext.Current.Session[KEYQIDACUMULADO]) == Utilitario.Constantes.ValorConstanteUno))
				{
					//e.Item.Cells[7].Font.Underline=true;
					//e.Item.Cells[7].Style.Add(Utilitario.Constantes.CURSOR,Utilitario.Constantes.TIPOCURSORMANO);
					//e.Item.Cells[7].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado(""));
//					e.Item.Cells[7].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.POPUPDEESPERA + Helper.MostrarVentana(URLEJECUCIONREAL,
//						KEYIDCENTRO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.KEYIDCENTROCALLAO.ToString() 
//						+ Utilitario.Constantes.SIGNOAMPERSON
//						+ NOMBRECENTRO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.KEYIDNOMBRECENTROCALLAO.ToString() + urlGeneral));
				}
				#endregion
				#endregion

				#region Columna de Datos de Presupuesto
				//Datos de Presupuesto
				#region Presupuesto Sima Callao
				//e.Item.Cells[4].Text = "PRESU-<BR>PUESTO";
				e.Item.Cells[4].Text = TITULOPTO;
				e.Item.Cells[4].ToolTip =TITULOPTOPERIODO + Fecha.Year.ToString();
				e.Item.Cells[4].Font.Size=7;
				//e.Item.Cells[4].Font.Underline=true;
				//e.Item.Cells[4].Style.Add(Utilitario.Constantes.CURSOR,Utilitario.Constantes.TIPOCURSORMANO);
				//e.Item.Cells[4].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado(""));
//				e.Item.Cells[4].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.POPUPDEESPERA + Helper.MostrarVentana(URLPRESUPUESTO,
//					KEYIDCENTRO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.KEYIDCENTROCALLAO.ToString() 
//					+ Utilitario.Constantes.SIGNOAMPERSON
//					+ NOMBRECENTRO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.KEYIDNOMBRECENTROCALLAO.ToString() + urlGeneral));



				#endregion

				#region Sima - Chimbote
				//e.Item.Cells[9].Text = "PRESU-<BR>PUESTO";
				e.Item.Cells[9].Text = TITULOPTO;
				e.Item.Cells[9].ToolTip =TITULOPTOPERIODO + Fecha.Year.ToString();
				e.Item.Cells[9].Font.Size=7;
				//e.Item.Cells[9].Font.Underline=true;
				//e.Item.Cells[9].Style.Add(Utilitario.Constantes.CURSOR,Utilitario.Constantes.TIPOCURSORMANO);
				//e.Item.Cells[9].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado(""));
//				e.Item.Cells[9].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.POPUPDEESPERA + Helper.MostrarVentana(URLPRESUPUESTO,
//					KEYIDCENTRO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.KEYIDCENTROCHIMBOTE.ToString() 
//					+ Utilitario.Constantes.SIGNOAMPERSON
//					+ NOMBRECENTRO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.KEYIDNOMBRECENTROCHIMBOTE.ToString() + urlGeneral));
				#endregion
				#endregion

				#region Columna de Acumulado Sima Peru / Sima Iquitos
				#region Sima Callao
				//e.Item.Cells[3].Text = "ACU-<BR>MULADO";
				e.Item.Cells[3].Text = TITULOACUMULADO;
				e.Item.Cells[3].ToolTip = TITULOACUMULADOMES + Helper.ObtenerNombreMes(Fecha.Month,Utilitario.Enumerados.TipoDatoMes.NombreCompleto) +  Utilitario.Constantes.ESPACIO +  Fecha.Year.ToString() ;
				e.Item.Cells[3].Font.Size=7;
				if ((Convert.ToInt32(HttpContext.Current.Session[KEYQIDACUMULADO]) == Utilitario.Constantes.ValorConstanteCero))
				{
					//e.Item.Cells[3].Font.Underline=true;
					//e.Item.Cells[3].Style.Add(Utilitario.Constantes.CURSOR,Utilitario.Constantes.TIPOCURSORMANO);
					//e.Item.Cells[3].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado(""));
//					e.Item.Cells[3].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.POPUPDEESPERA + Helper.MostrarVentana(URLEJECUCIONREAL,
//						KEYIDCENTRO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.KEYIDCENTROCALLAO.ToString() 
//						+ Utilitario.Constantes.SIGNOAMPERSON
//						+ NOMBRECENTRO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.KEYIDNOMBRECENTROCALLAO.ToString() + urlGeneral));

				}
				#endregion
				#region Sima Chimbote
				//e.Item.Cells[8].Text = "ACU-<BR>MULADO";
				e.Item.Cells[8].Text = TITULOACUMULADO;
				e.Item.Cells[8].ToolTip = TITULOACUMULADOMES + Helper.ObtenerNombreMes(Fecha.Month,Utilitario.Enumerados.TipoDatoMes.NombreCompleto) + Utilitario.Constantes.ESPACIO + Fecha.Year.ToString() ;
				e.Item.Cells[8].Font.Size=7;
				if ((Convert.ToInt32(HttpContext.Current.Session[KEYQIDACUMULADO]) == Utilitario.Constantes.ValorConstanteCero))
				{
					//e.Item.Cells[8].Font.Underline=true;
					//e.Item.Cells[8].Style.Add(Utilitario.Constantes.CURSOR,Utilitario.Constantes.TIPOCURSORMANO);
					//e.Item.Cells[8].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado(""));
//					e.Item.Cells[8].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.POPUPDEESPERA + Helper.MostrarVentana(URLEJECUCIONREAL,
//						KEYIDCENTRO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.KEYIDCENTROCHIMBOTE.ToString() 
//						+ Utilitario.Constantes.SIGNOAMPERSON
//						+ NOMBRECENTRO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.KEYIDNOMBRECENTROCHIMBOTE.ToString() + urlGeneral));

				}
				#endregion

				#endregion

				#region Columnas de Proyeccion Sima Callao / Sima Chimbote
				#region Sima Callao
				//e.Item.Cells[5].Text = "PROYE-<BR>CCIÓN";
				e.Item.Cells[5].Text = TITULOPROYECTADO;
				e.Item.Cells[5].ToolTip = TITULOPROYPERIODO + Fecha.Year.ToString();
				e.Item.Cells[5].Font.Size=7;
				//e.Item.Cells[5].Font.Underline=true;
				//e.Item.Cells[5].Style.Add(Utilitario.Constantes.CURSOR,Utilitario.Constantes.TIPOCURSORMANO);
				//e.Item.Cells[5].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado(""));
//				e.Item.Cells[5].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.POPUPDEESPERA + Helper.MostrarVentana(URLPROYECTADO,
//					KEYIDCENTRO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.KEYIDCENTROCALLAO.ToString() 
//					+ Utilitario.Constantes.SIGNOAMPERSON
//					+ NOMBRECENTRO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.KEYIDNOMBRECENTROCALLAO.ToString() + urlGeneral));
				#endregion

				#region Sima Chimbote
				//e.Item.Cells[5].Text = "PROYE-<BR>CCIÓN";
				e.Item.Cells[10].Text = TITULOPROYECTADO;
				e.Item.Cells[10].ToolTip = TITULOPROYPERIODO + Fecha.Year.ToString();
				e.Item.Cells[10].Font.Size=7;
				//e.Item.Cells[10].Font.Underline=true;
				//e.Item.Cells[10].Style.Add(Utilitario.Constantes.CURSOR,Utilitario.Constantes.TIPOCURSORMANO);
				//e.Item.Cells[10].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado(""));
//				e.Item.Cells[10].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.POPUPDEESPERA + Helper.MostrarVentana(URLPROYECTADO,
//					KEYIDCENTRO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.KEYIDCENTROCHIMBOTE.ToString() 
//					+ Utilitario.Constantes.SIGNOAMPERSON
//					+ NOMBRECENTRO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.KEYIDNOMBRECENTROCHIMBOTE.ToString() + urlGeneral));
				#endregion
				#endregion
			
			}

			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				bool VerMonto = ((Convert.ToInt32(dr[Enumerados.ColumnasFormato.FlgVerMonto.ToString()]) != Utilitario.Constantes.ValorConstanteCero)? true:false);
				for(int i = 1;i<=10;i++)
				{
					if(Session[KEYQNUEVOSSOLES] ==null)
					{
						e.Item.Cells[i].Text = (VerMonto == false)? Utilitario.Constantes.VACIO:Convert.ToDouble(Convert.ToDouble(e.Item.Cells[i].Text) / Utilitario.Constantes.MILES).ToString(Utilitario.Constantes.FORMATODECIMAL5); 
					}
					else
					{
						if (Session[KEYQNUEVOSSOLES].ToString() == Utilitario.Constantes.SIVERMILES)
						{
							e.Item.Cells[i].Text = (VerMonto == false)? Utilitario.Constantes.VACIO:Convert.ToDouble(Convert.ToDouble(e.Item.Cells[i].Text) / Utilitario.Constantes.MILES).ToString(Utilitario.Constantes.FORMATODECIMAL5); 
						}
						else
						{
							e.Item.Cells[i].Text = (VerMonto == false)? "":Convert.ToDouble(e.Item.Cells[i].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4); 
						}
					}					
				}

				string strQuery = KEYQVERIQUITOS  + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.ValorConstanteCero.ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYQNOMBRERUBRO + Utilitario.Constantes.SIGNOIGUAL + dr[COLUMNACONCEPTO].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYQIDFORMATO + Utilitario.Constantes.SIGNOIGUAL +  Convert.ToString(HttpContext.Current.Session[KEYQIDFORMATO])
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYQIDRUBRO + Utilitario.Constantes.SIGNOIGUAL + dr[COLUMNAIDRUBRO].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYQIDFECHA  + Utilitario.Constantes.SIGNOIGUAL +   Convert.ToDateTime(HttpContext.Current.Session[KEYQIDFECHA]).ToShortDateString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYQIDIDTIPOINFORMACION + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.ValorConstanteCero.ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYQIDINTERFAZ + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.ValorConstanteCero.ToString();				

				string Pagina = String.Empty;
				string sVentana=String.Empty;
				if (Convert.ToInt32(HttpContext.Current.Session[KEYQIDFORMATO])== Utilitario.Constantes.KEYIDFORMATOESTADODEGANACIASYPERDIDAS &&
					Convert.ToInt32(dr[COLUMNAIDRUBRO]) == 10 ||
					Convert.ToInt32(dr[COLUMNAIDRUBRO]) == 11 ||
					Convert.ToInt32(dr[COLUMNAIDRUBRO]) == 12 ||
					Convert.ToInt32(dr[COLUMNAIDRUBRO]) == 13 ||
					Convert.ToInt32(dr[COLUMNAIDRUBRO]) == 14 ||
					Convert.ToInt32(dr[COLUMNAIDRUBRO]) == 15 ||
					Convert.ToInt32(dr[COLUMNAIDRUBRO]) == 16 ||
					Convert.ToInt32(dr[COLUMNAIDRUBRO]) == 17 ||
					Convert.ToInt32(dr[COLUMNAIDRUBRO]) == 18 ||
					Convert.ToInt32(dr[COLUMNAIDRUBRO]) == 19 ||
					Convert.ToInt32(dr[COLUMNAIDRUBRO]) == 20 ||
					Convert.ToInt32(dr[COLUMNAIDRUBRO]) == 21 ||
					Convert.ToInt32(dr[COLUMNAIDRUBRO]) == 22 ||
					Convert.ToInt32(dr[COLUMNAIDRUBRO]) == 23 )
				{
					Pagina = URLFORMATORUBROMOVIMIENTOVCV + strQuery ;
					sVentana=Helper.PopupDialogoModal(Pagina,800,300,false);
				}
				else
				{
					Pagina = URLFORMATORUBROMOVIMIENTO + strQuery ;
					sVentana=Helper.PopupDialogoModal(Pagina,600,300,false);
				}

				Utilitario.Helper.ConfiguraNodosTreeview(e,
														2,
														5/*Convert.ToInt32(Page.Request.Params[KEYQIDNIVELEXPANDE])*/,
														dr,
														Helper.HistorialIrAdelantePersonalizado(Utilitario.Constantes.VACIO),
														sVentana);



				if (Convert.ToInt32(dr[Enumerados.ColumnasFormato.IdTipoLinea.ToString()]) != Utilitario.Constantes.ValorConstanteCero)
				{
					//e.Item.Font.Size = 8;
					e.Item.Font.Bold = true;
				}
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
			}		
		}
	}
}
