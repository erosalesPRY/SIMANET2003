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
	/// Summary description for EstadosFinancierosPorEmpresa.
	/// </summary>
	public class EstadosFinancierosPorEmpresa : System.Web.UI.Page,IPaginaBase
	{
		#region Constantes
		//Key Session y QueryString
		const string KEYQIDEMPRESA = "idEmp";
		const string KEYIDCENTRO ="IdCentro";
		const string NOMBRECENTRO ="NombreCentro";
		const string NOMBRETIPOOPCION ="NombreOpcion";
		const string KEYQIDNOMBREFORMATO = "NFormato";
		const string KEYQIDFECHA = "efFecha";
		const string KEYQIDNOMBREMES = "NombreMes";

		const string GRAFICO_PERU= "EGyP_SIMAP.pps";
		const string GRAFICO_IQUI= "EGyP_SIMAI.pps";
		const string GRAFICO_CALLAO= "EGyP_SIMAC.pps";
		const string GRAFICO_CHIMBOTE= "EGyP_SIMACH.pps";

		const string KEYQIDFORMATO = "IdFormato";
		const string KEYQIDREPORTE = "IdReporte";
		const string KEYQIDRUBRO = "IdRubro";
		const string KEYQIDACUMULADO = "Acumulado";
		const string KEYQIDNIVELEXPANDE = "NivelExp";
		const string KEYQIDCLASIFICACIONRUBRO = "RubroClasf";	

		const string KEYQNRODIGITOS ="NroDig";
		const string KEYQDIGCUENTA = "DigCuenta";

		const string KEYQNUEVOSSOLES = "MILNS";

		const string CAMPOH1="lblTitEmpresa";
		const string CAMPOH2="lblTitEjecutado";
		const string CAMPOH3="lblPresupuestoH";
		const string CAMPOH4="lblTotalHE";
		const string CAMPOH5="lblSaldoH";

		//Nuevos Key Session y QueryString
		const string KEYQOBSCALLAO = "ObsCallao";
		const string KEYQOBSCHIMBOTE = "ObsChimbote";
		const string KEYQOBSIQUITOS = "ObsIquitos";


		const int NRODIGINI = 2;
		const int DIGCTA = 0;
			

		const string CONTROLIMAGE = "imgVerDetalle";
		const string GRILLAVACIA="No exiets";
		const string URLPRINCIPAL = "../../Default.aspx";
		const string URLCOMPARATIVO = "EstadoFinancieroAcumuladoComparativo.aspx?";
		const string URLPERIODO = "EstadoFinancierodelPeriodo.aspx?";
		const string URLANTERIORPERU = "/SimaNetWeb/DirectorioEjecutivo/FinancieroPeru.aspx?";
		const string URLANTERIORIQUITOS = "/SimaNetWeb/DirectorioEjecutivo/FinancieroIquitos.aspx?";
		const string URLIMPRESION = "/SimanetWeb/GestionFinanciera/EstadosFinancieros/PopupImpresionEstadosFinancierosPorEmpresa.aspx";

		//Controles 
		const string CTRLCELLMPTO ="CellMPresupuesto";
		const string CTRLCELLTOTALEJECTDO ="CellTotalEjecutado";
		const string CTRLMSALDO ="CellMSaldo";
		const string CTRLCELLM ="CellM";

		//Columnas DataGrid y DataTable
		const string COLUMNATOTALPTO ="TotalPresupuesto";
		const string COLUMNATOTALEJECUTADO ="TotalEjecutado";
		const string COLUMNASALDOMES ="SaldoAlMes";
		const string COLUMNAIDRUBRO ="IdRubro";
		
		//Otros
		const string CLASS ="class";
		const string ITEMGRILLA ="itemgrilla";
		const string MENSAJEOCULTARMESES ="OcultarMeses();";
		//const string MENSAJEOCULTARMESES ="";
	

		//Variables
		
		#endregion

		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.HtmlControls.HtmlTable grid;
		protected System.Web.UI.WebControls.Label lblCentro;
		protected System.Web.UI.WebControls.Label lblMes;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label lblPeriodo;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
		protected System.Web.UI.WebControls.HyperLink lnkGrafico;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion
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
					this.LlenarGrilla();
					this.CargarGrafico();
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
			this.ibtnImprimir.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnImprimir_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members
		public void LlenarGrilla()
		{
			CEstadosFinancieros oCEstadosFinancieros = new  CEstadosFinancieros();
			DataTable dtEstadoFinanciero = oCEstadosFinancieros.ConsultarEstadosFinancierosPorEmpresaSA(Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA])
																										,Convert.ToInt32(Page.Request.Params[KEYQIDEMPRESA])
																										,Convert.ToInt32(Page.Request.Params[KEYIDCENTRO])
																										,Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO])
																										,Convert.ToInt32(Page.Request.Params[KEYQIDREPORTE])
																										,Utilitario.Constantes.IDDEFAULT
																										,Convert.ToInt32(Page.Request.Params[KEYQIDNIVELEXPANDE])
																										,Convert.ToInt32(Page.Request.Params[KEYQIDCLASIFICACIONRUBRO])
																										,Convert.ToInt32(Page.Request.Params[KEYQIDACUMULADO])
																										);
			

			if(dtEstadoFinanciero!=null)
			{
				#region Impresion
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

				#endregion Impresion

				this.ItemDataBound(dtEstadoFinanciero);
			}
			else
			{
				//lblResultado.Text = GRILLAVACIA;
			}
			// TODO:  Add EstadosFinancierosPorEmpresa.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add EstadosFinancierosPorEmpresa.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add EstadosFinancierosPorEmpresa.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add EstadosFinancierosPorEmpresa.LlenarCombos implementation
		}
		public void LlenarDatos()
		{
			lblPagina.Text = Page.Request.Params[KEYQIDNOMBREFORMATO].ToString().ToUpper();
			lblCentro.Text = Page.Request.Params[NOMBRECENTRO].ToString().ToUpper();
			lblPeriodo.Text = Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA]).Year.ToString();
			lblMes.Text = Page.Request.Params[KEYQIDNOMBREMES].ToString();
		}

		public void LlenarJScript()
		{
			// TODO:  Add EstadosFinancierosPorEmpresa.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add EstadosFinancierosPorEmpresa.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			ltlMensaje.Text = Helper.PopupImpresion(URLIMPRESION,650,700,false,false,false,true,true);					
			
		}

		public void Exportar()
		{
			// TODO:  Add EstadosFinancierosPorEmpresa.Exportar implementation
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
			// TODO:  Add EstadosFinancierosPorEmpresa.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			//Oculta las Columnas de Parametros
			e.Item.Cells[1].Style.Add(Utilitario.Constantes.DISPLAY,Utilitario.Constantes.NONE);
			e.Item.Cells[2].Style.Add(Utilitario.Constantes.DISPLAY,Utilitario.Constantes.NONE);
			e.Item.Cells[3].Style.Add(Utilitario.Constantes.DISPLAY,Utilitario.Constantes.NONE);
			e.Item.Cells[4].Style.Add(Utilitario.Constantes.DISPLAY,Utilitario.Constantes.NONE);

			DateTime Fecha = Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA]);
			HtmlTableCell Celda;
			string []NombreCelda = {"Ene","Feb","Mar","Abr","May","Jun","Jul","Ago","Seti","Oct","Nov","Dic"};
			
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				Utilitario.Helper.ConfiguraNodosTreeview(e,2,Convert.ToInt32(Page.Request.Params[KEYQIDNIVELEXPANDE]),dr,Utilitario.Constantes.VACIO);
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				//Presupuesto
				Celda = (HtmlTableCell) e.Item.Cells[5].FindControl(CTRLCELLMPTO);
				Celda.InnerText = Convert.ToDouble(dr[COLUMNATOTALPTO]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				//Total Ejecutado
				Celda = (HtmlTableCell) e.Item.Cells[5].FindControl(CTRLCELLTOTALEJECTDO);
				Celda.InnerText = Convert.ToDouble(dr[COLUMNATOTALEJECUTADO]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				//Saldo
				Celda = (HtmlTableCell) e.Item.Cells[5].FindControl(CTRLMSALDO);
				Celda.InnerText = Convert.ToDouble(dr[COLUMNASALDOMES]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

				//Oculta Columna que no se evaluan
				for (int i =0;i<= 11;i++)
				{
					Celda = (HtmlTableCell) e.Item.Cells[5].FindControl(CTRLCELLM + NombreCelda[i].ToString());
					Celda.Style.Add(Utilitario.Constantes.DISPLAY,((i>=(Fecha.Month-1))? Utilitario.Constantes.NONE:Utilitario.Constantes.BLOCK));
					Celda.InnerText = Convert.ToDouble(dr[NombreCelda[i].ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				}
				
			}
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void Button1_Click(object sender, System.EventArgs e)
		{

		}
		private void ItemDataBound(DataTable dt)
		{
			
			#region Cabecera
				//configura Columnas de Titulos
//				Label lbl;
//				lbl = (Label) e.Item.Cells[5].FindControl(CAMPOH1);
//				lbl.Text = Page.Request.Params[NOMBRECENTRO].ToString().ToUpper();
//				lbl.Font.Size=14;
//				lbl.Font.Bold = true;
//
//				//Titulo de Ejecucion
//				lbl = (Label) e.Item.Cells[5].FindControl(CAMPOH2);
//				lbl.Text = "EJECUTADO AL " + Fecha.ToShortDateString();
//				lbl.Font.Size=12;
//				lbl.Font.Bold = true;
//
//				//Columna de Presupuesto
//				lbl = (Label) e.Item.Cells[5].FindControl(CAMPOH3);
//				lbl.Text = "PRESU <BR> PUESTO <BR> DEL <BR> PERIODO <BR>";
//				lbl.Font.Size=7;
//				lbl.Font.Bold = true;
//
//				//Columna de Total Ejecutado
//				lbl = (Label) e.Item.Cells[5].FindControl(CAMPOH4);
//				lbl.Text = "TOTAL <BR> ENE/" + NombreCelda[((Fecha.Month==1)?0:(Fecha.Month-1))].ToString().ToUpper() +   "<BR>";
//				//Columna de Saldo
//				lbl = (Label) e.Item.Cells[5].FindControl(CAMPOH5);
//				lbl.Text = "SALDO";
//				
//				for (int i = Fecha.Month;i<= NombreCelda.Length-1;i++)
//				{
//					Celda = (HtmlTableCell) e.Item.Cells[5].FindControl("Cell" + NombreCelda[i].ToString());
//					Celda.Style.Add("display","none");
//				}
			#endregion
			
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
						if(Session[KEYQNUEVOSSOLES] ==null)
						{
							tblCell.InnerText = Convert.ToDouble(Convert.ToDouble(tblCell.InnerText) / Utilitario.Constantes.MILES).ToString(Utilitario.Constantes.FORMATODECIMAL5);
						}
						else
						{
							if (Session[KEYQNUEVOSSOLES].ToString() == Utilitario.Constantes.SIVERMILES)
							{
								tblCell.InnerText = Convert.ToDouble(Convert.ToDouble(tblCell.InnerText) / Utilitario.Constantes.MILES).ToString(Utilitario.Constantes.FORMATODECIMAL5);
							}
							else
							{
								tblCell.InnerText = Convert.ToDouble(tblCell.InnerText).ToString(Utilitario.Constantes.FORMATODECIMAL4);
							}
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
				if ((Convert.ToInt32(dr[COLUMNAIDRUBRO])==8) && (Convert.ToDouble(Page.Request.Params[KEYQIDFORMATO]) ==Utilitario.Constantes.KEYIDFORMATOFLUJODECAJA))
				{
					tblrow.Cells[tblrow.Cells.Count-2].InnerText = tblrow.Cells[6].InnerText;
				}
				else if ((Convert.ToInt32(dr[COLUMNAIDRUBRO])==9) && (Convert.ToDouble(Page.Request.Params[KEYQIDFORMATO]) ==Utilitario.Constantes.KEYIDFORMATOFLUJODECAJA))					
				{
					tblrow.Cells[tblrow.Cells.Count-2].InnerText = tblrow.Cells[5 + Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA]).Month].InnerText;
				}

				tblrow.Attributes.Add(CLASS,(((nroFila % 2)==0)?"Alternateitemgrilla":ITEMGRILLA));
				grid.Rows.Add(tblrow);
				
				Helper.ConfiguraNodosTreeview(tblrow,3,nroFila,Convert.ToInt32(Page.Request.Params[KEYQIDNIVELEXPANDE]),dr,Utilitario.Constantes.VACIO);
				Helper.SeleccionarItemGrillaOnClickMoverRaton(tblrow);

			}
			ltlMensaje.Text=MENSAJEOCULTARMESES;
			for (int Fila =3;Fila <= grid.Rows.Count-1;Fila++)
			{
				int ini=Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA]).Month +6;
				for(int i=ini;i<=17;i++)
				{
					grid.Rows[Fila].Cells[i].InnerText=Utilitario.Constantes.VACIO;
					grid.Rows[Fila].Cells[18].Style.Add(Utilitario.Constantes.DISPLAY,((Convert.ToInt32(Page.Request.QueryString[KEYQIDACUMULADO])==1)?Utilitario.Constantes.NONE:Utilitario.Constantes.DISPLAY));
					grid.Rows[Fila].Cells[19].Style.Add(Utilitario.Constantes.DISPLAY,((Convert.ToInt32(Page.Request.QueryString[KEYQIDACUMULADO])==1)?Utilitario.Constantes.NONE:Utilitario.Constantes.DISPLAY));
				}
				
			}
			grid.Rows[1].Cells[grid.Rows[1].Cells.Count-1].Style.Add(Utilitario.Constantes.DISPLAY,((Convert.ToInt32(Page.Request.QueryString[KEYQIDACUMULADO])==1)?Utilitario.Constantes.NONE:Utilitario.Constantes.DISPLAY));
			grid.Rows[1].Cells[grid.Rows[1].Cells.Count-2].Style.Add(Utilitario.Constantes.DISPLAY,((Convert.ToInt32(Page.Request.QueryString[KEYQIDACUMULADO])==1)?Utilitario.Constantes.NONE:Utilitario.Constantes.DISPLAY));

		}

		private void ibtnImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.ReiniciarSession();
			this.LlenarJScript();
			this.LlenarCombos();
			this.LlenarDatos();
			this.LlenarGrilla();
			this.Imprimir();
		}

		private void CargarGrafico()
		{
			switch(Convert.ToInt32(Page.Request.Params[KEYIDCENTRO]))
			{
				case (int)Utilitario.Enumerados.IdCentroOperativo.SimaPeru:
				{
					lnkGrafico.NavigateUrl = System.Configuration.ConfigurationSettings.AppSettings[
						Utilitario.Constantes.RUTADOCUMENTOSDIRECTORIO2] +
						Utilitario.Constantes.RUTADIRECTORIOFINANCIERADOCSGANANCIASPERDIDAS +
						GRAFICO_PERU;
					break;
				}
				case (int)Utilitario.Enumerados.IdCentroOperativo.SimaIquitos:
				{
					lnkGrafico.NavigateUrl =System.Configuration.ConfigurationSettings.AppSettings[
						Utilitario.Constantes.RUTADOCUMENTOSDIRECTORIO2] +
						Utilitario.Constantes.RUTADIRECTORIOFINANCIERADOCSGANANCIASPERDIDAS +
						GRAFICO_IQUI;
					break;
				}
				case (int)Utilitario.Enumerados.IdCentroOperativo.SimaChimbote:
				{
					lnkGrafico.NavigateUrl =System.Configuration.ConfigurationSettings.AppSettings[
						Utilitario.Constantes.RUTADOCUMENTOSDIRECTORIO2] +
						Utilitario.Constantes.RUTADIRECTORIOFINANCIERADOCSGANANCIASPERDIDAS +
						GRAFICO_CHIMBOTE;
					break;
				}
				case (int)Utilitario.Enumerados.IdCentroOperativo.SimaCallao:
				{
					lnkGrafico.NavigateUrl =System.Configuration.ConfigurationSettings.AppSettings[
						Utilitario.Constantes.RUTADOCUMENTOSDIRECTORIO2] +
						Utilitario.Constantes.RUTADIRECTORIOFINANCIERADOCSGANANCIASPERDIDAS +
						GRAFICO_CALLAO;
					break;
				}
			}
		}
	}
}
