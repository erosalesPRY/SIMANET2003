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
	/// Summary description for PopupImpresionEstadosFinancierosPorEmpresa.
	/// </summary>
	public class PopupImpresionEstadosFinancierosPorEmpresa : System.Web.UI.Page, IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label lblPeriodo;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label lblMes;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label lblCentro;
		protected System.Web.UI.HtmlControls.HtmlTable grid;
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


		const string KEYQIDFORMATO = "IdFormato";
		const string KEYQIDREPORTE = "IdReporte";
		const string KEYQIDRUBRO = "IdRubro";
		const string KEYQIDACUMULADO = "Acumulado";
		const string KEYQIDNIVELEXPANDE = "NivelExp";
		const string KEYQIDCLASIFICACIONRUBRO = "RubroClasf";	

		const string KEYQNUEVOSSOLES = "MILNS";

		const string KEYQNRODIGITOS ="NroDig";
		const string KEYQDIGCUENTA = "DigCuenta";

		const string CAMPOH1="lblTitEmpresa";
		const string CAMPOH2="lblTitEjecutado";
		const string CAMPOH3="lblPresupuestoH";
		const string CAMPOH4="lblTotalHE";
		const string CAMPOH5="lblSaldoH";


		const int NRODIGINI = 2;
		const int DIGCTA = 0;
			

		const string CONTROLIMAGE = "imgVerDetalle";
		const string GRILLAVACIA="No exiets";
		const string URLPRINCIPAL = "../../Default.aspx";
		const string URLCOMPARATIVO = "EstadoFinancieroAcumuladoComparativo.aspx?";
		const string URLPERIODO = "EstadoFinancierodelPeriodo.aspx?";
		const string URLANTERIORPERU = "/SimaNetWeb/DirectorioEjecutivo/FinancieroPeru.aspx?";
		const string URLANTERIORIQUITOS = "/SimaNetWeb/DirectorioEjecutivo/FinancieroIquitos.aspx?";

		//Controles
		const string CTRLCELLMPTO ="CellMPresupuesto";
		const string CTRLTOTALPTO ="TotalPresupuesto";
		const string CTRLCELLTOTALEJECUTADO ="CellTotalEjecutado";
		const string CTRLTOTALEJECUTADO ="TotalEjecutado";
		const string CTRLCELMSALDO="CellMSaldo";
		const string CTRLSALDOMES ="SaldoAlMes";
		const string CTRLCELLM ="CellM";

		//DataGrid and DataTable
		const string COLUMNAIDRUBRO ="IdRubro";

		//Otros
		const string METODOOCULTARMESES ="OcultarMeses();";

		//Variables
		DateTime FechaPeriodo;
		#endregion
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				if(!Page.IsPostBack)
				{
					this.ConfigurarAccesoControles();				
					this.LlenarJScript();					
					this.LlenarDatos();
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
			CImpresion oCImpresion =  new CImpresion();
			DataTable dtImpresion =  oCImpresion.ObtenerDataImprimir();
			if(dtImpresion!=null)
			{				
				this.ItemDataBound(dtImpresion);
			}
			//grid.DataBind();
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add PopupImpresionEstadosFinancierosPorEmpresa.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add PopupImpresionEstadosFinancierosPorEmpresa.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add PopupImpresionEstadosFinancierosPorEmpresa.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			this.GeneraFecha();
			lblTitulo.Text = CImpresion.ObtenerTituloReporteEstadosFinancieros();
			lblCentro.Text = CImpresion.ObtenerTituloReporteEstadosFinancieros();	
			lblPeriodo.Text = FechaPeriodo.Year.ToString();
			lblMes.Text = Convert.ToString(HttpContext.Current.Session[KEYQIDNOMBREMES]).ToUpper();

		}

		public void LlenarJScript()
		{
			// TODO:  Add PopupImpresionEstadosFinancierosPorEmpresa.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add PopupImpresionEstadosFinancierosPorEmpresa.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			ltlMensaje.Text=Helper.Imprimir();
		}

		public void Exportar()
		{
			// TODO:  Add PopupImpresionEstadosFinancierosPorEmpresa.Exportar implementation
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
			// TODO:  Add PopupImpresionEstadosFinancierosPorEmpresa.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void GeneraFecha()
		{
			FechaPeriodo =  
				Convert.ToDateTime(DateTime.DaysInMonth(Convert.ToDateTime(HttpContext.Current.Session[KEYQIDFECHA]).Year,Convert.ToDateTime(HttpContext.Current.Session[KEYQIDFECHA]).Month) 
				+ Utilitario.Constantes.SEPARADORFECHA 
				+ Convert.ToDateTime(HttpContext.Current.Session[KEYQIDFECHA]).Month.ToString().PadLeft(2,'0') 
				+ Utilitario.Constantes.SEPARADORFECHA 
				+ Convert.ToDateTime(HttpContext.Current.Session[KEYQIDFECHA]).Year.ToString());
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			//Oculta las Columnas de Parametros
			e.Item.Cells[1].Style.Add(Utilitario.Constantes.DISPLAY,Utilitario.Constantes.NONE);
			e.Item.Cells[2].Style.Add(Utilitario.Constantes.DISPLAY,Utilitario.Constantes.NONE);
			e.Item.Cells[3].Style.Add(Utilitario.Constantes.DISPLAY,Utilitario.Constantes.NONE);
			e.Item.Cells[4].Style.Add(Utilitario.Constantes.DISPLAY,Utilitario.Constantes.NONE);

			DateTime Fecha = Convert.ToDateTime(HttpContext.Current.Session[KEYQIDFECHA]);
			HtmlTableCell Celda;
			string []NombreCelda = {"Ene","Feb","Mar","Abr","May","Jun","Jul","Ago","Seti","Oct","Nov","Dic"};
			
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				Utilitario.Helper.ConfiguraNodosTreeview(e,
														2,
														5/*Convert.ToInt32(Page.Request.Params[KEYQIDNIVELEXPANDE])*/,
														dr,
														String.Empty);
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				//Presupuesto
				Celda = (HtmlTableCell) e.Item.Cells[5].FindControl(CTRLCELLMPTO);
				Celda.InnerText = Convert.ToDouble(dr[CTRLTOTALPTO]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				//Total Ejecutado
				Celda = (HtmlTableCell) e.Item.Cells[5].FindControl(CTRLCELLTOTALEJECUTADO);
				Celda.InnerText = Convert.ToDouble(dr[CTRLTOTALEJECUTADO]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				//Saldo
				Celda = (HtmlTableCell) e.Item.Cells[5].FindControl(CTRLCELMSALDO);
				Celda.InnerText = Convert.ToDouble(dr[CTRLSALDOMES]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

				//Oculta Columna que no se evaluan
				for (int i =0;i<= 11;i++)
				{
					Celda = (HtmlTableCell) e.Item.Cells[5].FindControl(CTRLCELLM + NombreCelda[i].ToString());
					Celda.Style.Add(Utilitario.Constantes.DISPLAY,((i>=(Fecha.Month-1))? Utilitario.Constantes.NONE:Utilitario.Constantes.BLOCK));
					Celda.InnerText = Convert.ToDouble(dr[NombreCelda[i].ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				}				
			}
		}

		private void ItemDataBound(DataTable dt)
		{
			int nroFila=0;
			string []NombreCol = {"CONCEPTO","NroNivel","idNivel","NroHijos","","TotalPresupuesto","Ene","Feb","Mar","Abr","May","Jun","Jul","Ago","Seti","Oct","Nov","Dic","TotalEjecutado","SaldoAlMes"};

			foreach(DataRow dr in dt.Rows)
			{
				HtmlTableRow tblrow = new HtmlTableRow();
				for(int i=0;i<=NombreCol.Length-1;i++)
				{
					HtmlTableCell tblCell = new HtmlTableCell();	
					tblCell.InnerText =  ((i>0 && i!=4)? dr[NombreCol[i].ToString()].ToString():Utilitario.Constantes.VACIO);
					if (i>4)
					{
						tblCell.NoWrap = true;

						if (Session[KEYQNUEVOSSOLES].ToString() == Utilitario.Constantes.SIVERMILES)
						{
							tblCell.InnerText = Convert.ToDouble(Convert.ToDouble(tblCell.InnerText) / Utilitario.Constantes.MILES).ToString(Utilitario.Constantes.FORMATODECIMAL5);
						}
						else
						{
							tblCell.InnerText = Convert.ToDouble(tblCell.InnerText).ToString(Utilitario.Constantes.FORMATODECIMAL4);
						}
						/*
						if (System.Configuration.ConfigurationSettings.AppSettings[Utilitario.Constantes.KEYVERMILESNUEVOSSOLES] == Utilitario.Constantes.SIVERMILES)
						{
							tblCell.InnerText = Convert.ToDouble(Convert.ToDouble(tblCell.InnerText) / Utilitario.Constantes.MILES).ToString(Utilitario.Constantes.FORMATODECIMAL5);
						}
						else
						{
							tblCell.InnerText = Convert.ToDouble(tblCell.InnerText).ToString(Utilitario.Constantes.FORMATODECIMAL4);
						}
						*/
					}

					tblCell.Style.Add(Utilitario.Constantes.DISPLAY,((i>0 && i<=4)?Utilitario.Constantes.NONE:Utilitario.Constantes.BLOCK));

					tblCell.Align=Utilitario.Constantes.RIGHT;
					tblCell.VAlign=Utilitario.Constantes.MIDDLE;
					tblrow.Cells.Add(tblCell);	
				}
				nroFila++;

				//Exepciones del Flujo de Caja
				if ((Convert.ToInt32(dr[COLUMNAIDRUBRO])==8) && (Convert.ToDouble(HttpContext.Current.Session[KEYQIDFORMATO]) ==Utilitario.Constantes.KEYIDFORMATOFLUJODECAJA))
				{
					tblrow.Cells[tblrow.Cells.Count-2].InnerText = tblrow.Cells[6].InnerText;
				}
				else if ((Convert.ToInt32(dr[COLUMNAIDRUBRO])==9) && (Convert.ToDouble(HttpContext.Current.Session[KEYQIDFORMATO]) ==Utilitario.Constantes.KEYIDFORMATOFLUJODECAJA))					
				{
					tblrow.Cells[tblrow.Cells.Count-2].InnerText = tblrow.Cells[5 + Convert.ToDateTime(HttpContext.Current.Session[KEYQIDFECHA]).Month].InnerText;
				}

				tblrow.Attributes.Add("class",(((nroFila % 2)==0)?"Alternateitemgrilla":"itemgrilla"));
				grid.Rows.Add(tblrow);
				
				Helper.ConfiguraNodosTreeview(tblrow,
												3,
												nroFila,
												5/*Convert.ToInt32(Page.Request.Params[KEYQIDNIVELEXPANDE])*/,
												dr,
												String.Empty);
				Helper.SeleccionarItemGrillaOnClickMoverRaton(tblrow);

			}
			ltlMensaje.Text=METODOOCULTARMESES;
			for (int Fila =3;Fila <= grid.Rows.Count-1;Fila++)
			{
				int ini=Convert.ToDateTime(HttpContext.Current.Session[KEYQIDFECHA]).Month +6;
				for(int i=ini;i<=17;i++)
				{
					grid.Rows[Fila].Cells[i].InnerText=String.Empty;
					grid.Rows[Fila].Cells[18].Style.Add(Utilitario.Constantes.DISPLAY,((Convert.ToInt32(HttpContext.Current.Session[KEYQIDACUMULADO])==1)?Utilitario.Constantes.NONE:Utilitario.Constantes.DISPLAY));
					grid.Rows[Fila].Cells[19].Style.Add(Utilitario.Constantes.DISPLAY,((Convert.ToInt32(HttpContext.Current.Session[KEYQIDACUMULADO])==1)?Utilitario.Constantes.NONE:Utilitario.Constantes.DISPLAY));
				}
				
			}
			grid.Rows[1].Cells[grid.Rows[1].Cells.Count-1].Style.Add(Utilitario.Constantes.DISPLAY,((Convert.ToInt32(HttpContext.Current.Session[KEYQIDACUMULADO])==1)?Utilitario.Constantes.NONE:Utilitario.Constantes.DISPLAY));
			grid.Rows[1].Cells[grid.Rows[1].Cells.Count-2].Style.Add(Utilitario.Constantes.DISPLAY,((Convert.ToInt32(HttpContext.Current.Session[KEYQIDACUMULADO])==1)?Utilitario.Constantes.NONE:Utilitario.Constantes.DISPLAY));
		}
	}
}
