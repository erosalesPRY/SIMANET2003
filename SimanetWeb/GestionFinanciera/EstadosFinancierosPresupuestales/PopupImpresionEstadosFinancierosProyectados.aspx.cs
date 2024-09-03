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

namespace SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancierosPresupuestales
{
	/// <summary>
	/// Summary description for PopupImpresionEstadosFinancierosProyectados.
	/// </summary>
	public class PopupImpresionEstadosFinancierosProyectados : System.Web.UI.Page, IPaginaBase
	{
		#region Controles		
		protected System.Web.UI.HtmlControls.HtmlTableCell CellHPTotal;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellHREne;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellHRFeb;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellHRMar;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellHRAbr;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellHRMay;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellHRJun;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellHRJul;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellHRAgo;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellHRSeti;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellHROct;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellHRNov;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellHRDic;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellHRTotal;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellHPEne;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellHPFeb;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellHPMar;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellHPAbr;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellHPMay;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellHPJun;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellHPJul;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellHPAgo;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellHPSeti;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellHPOct;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellHPNov;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellHPDic;
		protected System.Web.UI.HtmlControls.HtmlTable grid;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblPeriodo;
		protected System.Web.UI.WebControls.Label lblMes;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.HtmlControls.HtmlTableCell lblEmpresa;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.HtmlControls.HtmlTableCell ColumnaTotal;
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion Controles
	
		#region Constantes
		//Key Session y QueryString
		const string KEYQIDEMPRESA = "idEmp";
		const string KEYQIDCENTRO ="IdCentro";
		const string NOMBRECENTRO ="NombreCentro";
		const string NOMBRETIPOOPCION ="NombreOpcion";
		const string KEYQIDNOMBREFORMATO = "NFormato";
		const string KEYQIDFECHA = "efFecha";
		const string KEYQIDNOMBREMES = "NombreMes";
		const string KEYQIDACUMULADO = "Acumulado";

		const string KEYQIDFORMATO = "IdFormato";
		const string KEYQIDREPORTE = "IdReporte";
		const string KEYQIDRUBRO = "IdRubro";
		const string KEYQIDNIVELEXPANDE = "NivelExp";
		const string KEYQIDCLASIFICACIONRUBRO = "RubroClasf";	

		const string KEYQNRODIGITOS ="NroDig";
		const string KEYQDIGCUENTA = "DigCuenta";

		const string KEYQNUEVOSSOLES = "MILNS";

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

		//const string URLANTERIORPERU = "/SimaNetWeb/DirectorioEjecutivo/FinancieroPeru.aspx?";
		//const string URLANTERIORIQUITOS = "/SimaNetWeb/DirectorioEjecutivo/FinancieroIquitos.aspx?";

		const string URLPRESUPUESTO="../EstadosFinancierosPresupuestales/EstadosFinancierosFormulacion.aspx?";
		const string URLEJECUCIONREAL="EstadosFinancierosPorEmpresa.aspx?";
		const string URLEJECUCIONREALPORCENTRO="EstadosFinancierosPorCentroOperativo.aspx?";		

		const string COLUMNAIDRUBRO ="IdRubro";

		//Variables
		
		private ASPNetDatagridDecorator m_add = new ASPNetDatagridDecorator();
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
			if(dtImpresion != null)
			{	
				this.ItemDataBound(dtImpresion);
			}
			grid.DataBind();
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add PopupImpresionEstadosFinancierosProyectados.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add PopupImpresionEstadosFinancierosProyectados.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add PopupImpresionEstadosFinancierosProyectados.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			this.lblTitulo.Text = CImpresion.ObtenerTituloReporteEstadosFinancieros();			
			lblEmpresa.InnerText = Convert.ToString(HttpContext.Current.Session[KEYQIDACUMULADO]).ToUpper();

			this.lblPeriodo.Text = Convert.ToDateTime(HttpContext.Current.Session[KEYQIDFECHA]).Year.ToString();
			this.lblMes.Text = Convert.ToString(HttpContext.Current.Session[KEYQIDNOMBREMES]);
		}

		public void LlenarJScript()
		{
			// TODO:  Add PopupImpresionEstadosFinancierosProyectados.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add PopupImpresionEstadosFinancierosProyectados.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			ltlMensaje.Text = Helper.Imprimir();
		}

		public void Exportar()
		{
			// TODO:  Add PopupImpresionEstadosFinancierosProyectados.Exportar implementation
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
			// TODO:  Add PopupImpresionEstadosFinancierosProyectados.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void ItemDataBound(DataTable dt)
		{
			DateTime Fecha = Convert.ToDateTime(HttpContext.Current.Session[KEYQIDFECHA]);
			string mes = Fecha.Month.ToString();

			string []Display = {Utilitario.Constantes.BLOCK
								   ,Utilitario.Constantes.NONE
								   ,Utilitario.Constantes.NONE
								   ,Utilitario.Constantes.NONE
								   ,Utilitario.Constantes.NONE
								   ,Utilitario.Constantes.BLOCK
								   ,Utilitario.Constantes.BLOCK
								   ,Utilitario.Constantes.BLOCK
								   ,Utilitario.Constantes.BLOCK
								   ,Utilitario.Constantes.BLOCK
								   ,Utilitario.Constantes.BLOCK
								   ,Utilitario.Constantes.BLOCK
								   ,Utilitario.Constantes.BLOCK
								   ,Utilitario.Constantes.BLOCK
								   ,Utilitario.Constantes.BLOCK
								   ,Utilitario.Constantes.BLOCK
								   ,Utilitario.Constantes.BLOCK};

			string ColumnaPrincipal = "CONCEPTO,NroNivel,idNivel,NroHijos,";
			string []Meses = {"Ene","Feb","Mar","Abr","May","Jun","Jul","Ago","Seti","Oct","Nov","Dic"};
			string strListaMeses=String.Empty;
			string strListaMesesH=String.Empty;
			for (int i=0;i<=Meses.Length-1;i++)
			{
				strListaMeses += Utilitario.Constantes.SIGNOCOMA + ((i==(Fecha.Month) && Fecha.Month <12)? "Rtotal,P" + Meses[Fecha.Month].ToString() :((i<=(Fecha.Month-1))? "R":"P") + Meses[i].ToString()) + ((i==(Meses.Length-1))? ",PTotal":String.Empty);
				strListaMesesH += ((i==0)?String.Empty:Utilitario.Constantes.SIGNOCOMA) +((i==(Fecha.Month) && Fecha.Month <12)? "ACUM," + Meses[Fecha.Month].ToString().Substring(0,3) :Meses[i].ToString().Substring(0,3)) + ((i==(Meses.Length-1))? ",Total":String.Empty);
			}
			int nroFila=0;
			string []ListaColumnas=Convert.ToString(ColumnaPrincipal + strListaMeses).Split(',');;
			foreach(DataRow dr in dt.Rows)
			{
				HtmlTableRow tblrow = new HtmlTableRow();
				for(int i=0;i<=ListaColumnas.Length-1;i++)
				{
					HtmlTableCell tblCell = new HtmlTableCell();	
					tblCell.InnerText =  ((i>0 && i!=4)? dr[ListaColumnas[i].ToString()].ToString():String.Empty);
					tblCell.NoWrap=true;
					if (i>4)
					{
						if (Session[KEYQNUEVOSSOLES].ToString() == Utilitario.Constantes.SIVERMILES)
						{
							tblCell.InnerText = Convert.ToDouble(Convert.ToDouble(tblCell.InnerText)/Utilitario.Constantes.MILES).ToString(Utilitario.Constantes.FORMATODECIMAL5);
						}
						else
						{
							tblCell.InnerText = Convert.ToDouble(tblCell.InnerText).ToString(Utilitario.Constantes.FORMATODECIMAL4);
						}
						/*
						if (System.Configuration.ConfigurationSettings.AppSettings[Utilitario.Constantes.KEYVERMILESNUEVOSSOLES] == Utilitario.Constantes.SIVERMILES)
						{
							tblCell.InnerText = Convert.ToDouble(Convert.ToDouble(tblCell.InnerText)/Utilitario.Constantes.MILES).ToString(Utilitario.Constantes.FORMATODECIMAL5);
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
					tblCell.NoWrap=true;
					tblrow.Cells.Add(tblCell);	
				}

				//Exepciones del Flujo de Caja
				if ((Convert.ToInt32(dr[COLUMNAIDRUBRO])==8) && (Convert.ToDouble(HttpContext.Current.Session[KEYQIDFORMATO]) ==Utilitario.Constantes.KEYIDFORMATOFLUJODECAJA))
				{
					tblrow.Cells[tblrow.Cells.Count-1].InnerText = tblrow.Cells[5].InnerText;
				}
				else if ((Convert.ToInt32(dr[COLUMNAIDRUBRO])==9) && (Convert.ToDouble(HttpContext.Current.Session[KEYQIDFORMATO]) ==Utilitario.Constantes.KEYIDFORMATOFLUJODECAJA))					
				{
					tblrow.Cells[tblrow.Cells.Count-1].InnerText = tblrow.Cells[tblrow.Cells.Count-2].InnerText;
				}
				


				nroFila++;
				tblrow.Attributes.Add("class",(((nroFila % 2)==0)?"Alternateitemgrilla":"itemgrilla"));

				if(Convert.ToInt32(mes)==12)
				{
					tblrow.Cells[17].Visible=false;
					
				}
				grid.Rows.Add(tblrow);
				Helper.ConfiguraNodosTreeview(tblrow,
												3,
												nroFila,
												5/*Convert.ToInt32(HttpContext.Current.Session[KEYQIDNIVELEXPANDE])*/,
												dr,
												String.Empty);
				Helper.SeleccionarItemGrillaOnClickMoverRaton(tblrow);
			}
			//Configura Cabecera
			int Cols = 13;
			int ColReal =(Fecha.Month+1);
			int Colproy = (Cols-ColReal);
			grid.Rows[1].Cells[4].ColSpan = ColReal;
			grid.Rows[1].Cells[5].ColSpan = Colproy; //OJO: Ocultar proyectado para cuando sea diciembre
			
			string []ListaColumnasH=strListaMesesH.ToUpper().Split(',');
			int CelIni = 4;
			for(int i=0;i<=ListaColumnasH.Length-2;i++)
			{
				grid.Rows[2].Cells[CelIni+i].InnerText = ListaColumnasH[i].ToString();
				if(CelIni+i==17 &&  Convert.ToInt32(mes)==12)
				{
					grid.Rows[2].Cells[CelIni+i].Visible=false;
					//grid.Rows[2].Cells[12].Visible = false;					
				}
			}

			if (Convert.ToInt32(mes)==12)
			{
				grid.Rows[1].Cells[5].Visible=false;
				grid.Rows[2].Cells[16].Visible = false;
				ColumnaTotal.Visible=false;				
			}

		}
	}
}
