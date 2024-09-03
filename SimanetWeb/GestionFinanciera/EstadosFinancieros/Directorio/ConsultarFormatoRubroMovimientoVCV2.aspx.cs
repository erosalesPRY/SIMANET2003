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
using System.Configuration;
using SIMA.Utilitario;
using NetAccessControl;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using ControlGridScroll;

namespace SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancieros.Directorio
{
	/// <summary>
	/// Summary description for ConsultarFormatoRubroMovimientoVCV.
	/// </summary>
	public class ConsultarFormatoRubroMovimientoVCV2 : System.Web.UI.Page,IPaginaBase
	{
		#region Constantes
		const string KEYQVERIQUITOS ="Ver";
		const string KEYQNOMBRERUBRO ="NRubro";
		const string KEYQIDFORMATO = "IdFormato";
		const string KEYQIDRUBRO = "IdRubro";
		const string KEYQIDFECHA = "efFecha";
		const string KEYQIDCENTROOPERATIVO = "IdCentroOperativo";
		const string KEYQIDIDTIPOINFORMACION ="idTipoInfo";

		const string KEYQIDINTERFAZ = "interfaz";

		const string TEXTOTOTAL = "Total";
			
		const string CAMPO1 ="lblCallaoV";
		const string CAMPO2 ="lblCallaoC";
		const string CAMPO3 ="lblChimboteV";
		const string CAMPO4 ="lblChimboteC";
		const string CAMPO5 ="lblIquitosV";
		const string CAMPO6 ="lblIquitosC";
		const string CAMPO7 = "lblTotalPV";
		const string CAMPO8 = "lblTotalPC";

		//Footer
		const string FCAMPO1 = "lblFooterTotalSCV";
		const string FCAMPO2 = "lblFooterTotalSCC";
		const string FCAMPO3 = "lblFooterTotalSCHV";
		const string FCAMPO4 = "lblFooterTotalSCHC";
		const string FCAMPO5 = "lblFooterTotalSIV";
		const string FCAMPO6 = "lblFooterTotalSIC";
		const string FCAMPO7 = "lblFooterTotalSPV";
		const string FCAMPO8 = "lblFooterTotalSPC";

		const string CONTROLTSP = "lblHTSP"; 
		const string CONTROLSP = "lblHSP";
		const string CONTROLSC = "lblHSC";
		const string CONTROLSCH = "lblHSCH";
		const string CONTROLSI = "lblHSI";

		//Nuevos Key Session y QueryString
		const string KEYQOBSPERU = "ObsPeru";
		const string KEYQOBSCALLAO = "ObsCallao";
		const string KEYQOBSCHIMBOTE = "ObsChimbote";
		const string KEYQOBSIQUITOS = "ObsIquitos";

		//Columnas Grilla y DataTable
		const string DESCRIPCION ="DESCRIPCION";
		const string COLUMNASCVENTAS ="SimaCallaoVentas";
		const string COLUMNASCCOSTOVENTAS ="SimaCallaoCostoVentas";
		const string COLUMNASCHVENTAS ="SimaChimboteVentas";
		const string COLUMNASCHCOSTOVENTAS ="SimaChimboteCostoVentas";
		const string COLUMNASIVENTAS ="SimaIquitosVentas";
		const string COLUMNASICOSTOVENTAS="SimaIquitosCostoVentas";		

		#region Variables
		double totalSPV = 0.0;
		double totalSPC = 0.0;
		double totalSCV = 0.0;
		double totalSCC = 0.0;
		double totalSCHV = 0.0;
		double totalSCHC = 0.0;
		double totalSIV = 0.0;
		double totalSIC = 0.0;
		#endregion Variables

		#endregion

		#region Controles
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblRubro;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.HtmlControls.HtmlTextArea campo1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hObsCallao;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hObsChimbote;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hObsIquitos;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hObsPeru;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Literal ltlMensaje;

		#endregion Controles

		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				if(!Page.IsPostBack)
				{
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarJScript();
					this.LlenarDatos();
					this.LlenarGrilla();
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
				ltlMensaje.Text = Helper.MensajeAlert(oSIMAExcepcionDominio.Mensaje);					
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
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		private DataTable  ObtenerDatos()
		{
			return ((CFormatoRubroDetalleMovimiento) new CFormatoRubroDetalleMovimiento())
				.ConsultarFormatoRubroDetalleMovimientoCorporativoYCentroVCV
				(Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO])
				,Convert.ToInt32(Page.Request.Params[KEYQIDRUBRO])
				,Convert.ToInt32(Page.Request.Params[KEYQIDIDTIPOINFORMACION])
				,Convert.ToInt32(Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA]).Year)
				,Convert.ToInt32(Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA]).Month)
				,Convert.ToInt32(Page.Request.Params[KEYQIDINTERFAZ]));
		}


		public void LlenarGrilla()
		{
			//grid.Columns[2].Visible  = (Convert.ToInt32(Page.Request.Params[KEYQVERIQUITOS])==0)?false:true;
			DataTable dt = this.ObtenerDatos();
			if (dt !=null)
			{
				this.grid.DataSource=dt;
			}
			else
			{
				//this.grid.DataSource=dt;
				this.grid.DataSource = this.DataTableVacio();
			}
			this.grid.DataBind();			
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarFormatoRubroMovimientoVCV.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add ConsultarFormatoRubroMovimientoVCV.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add ConsultarFormatoRubroMovimientoVCV.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			this.lblRubro.Text = Page.Request.Params[KEYQNOMBRERUBRO].ToString().ToUpper();
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarFormatoRubroMovimientoVCV.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarFormatoRubroMovimientoVCV.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarFormatoRubroMovimientoVCV.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarFormatoRubroMovimientoVCV.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
//			if(CNetAccessControl.FindPage(Page.Request.Url.AbsolutePath.ToString()))
//			{CNetAccessControl.LoadControls(this);}
//			else
//			{CNetAccessControl.RedirectPageError();}		
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ConsultarFormatoRubroMovimientoVCV.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.Header)
			{
				string varTemp = String.Empty;
					Label Control = (Label)e.Item.Cells[2].FindControl(CONTROLSI);
				if(Page.Request.QueryString[KEYQIDCENTROOPERATIVO].ToString()=="1")
				{
					//Label ControlSI = (Label)e.Item.Cells[2].FindControl(CONTROLSI);
					varTemp = Control.ClientID.ToString();//Variable utilizada para obtener el nombre del control desde el lado del cliente
					Control.Text="SIMA PERU";
					Control.Font.Underline = true;
					Control.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,"MostrarValor(1);");
					Control.Style.Add(Utilitario.Constantes.CURSOR,Utilitario.Constantes.TIPOCURSORMANO);				
					//ControlSP.BackColor=Color.LightBlue;
				}
				else if(Page.Request.QueryString[KEYQIDCENTROOPERATIVO].ToString()=="2")
				{
					//Label ControlSC = (Label)e.Item.Cells[1].FindControl(CONTROLSC);
					
					Control.Text="SIMA CALLAO";
					Control.Font.Underline = true;
					Control.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,"MostrarValor(2);");
					Control.Style.Add(Utilitario.Constantes.CURSOR,Utilitario.Constantes.TIPOCURSORMANO);
				}
					//#afcdd8
				else if(Page.Request.QueryString[KEYQIDCENTROOPERATIVO].ToString()=="3")
				{
					//Label ControlSCH = (Label)e.Item.Cells[1].FindControl(CONTROLSCH);
					Control.Text="SIMA CHIMBOTE";
					Control.Font.Underline = true;
					Control.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,"MostrarValor(3);");
					Control.Style.Add(Utilitario.Constantes.CURSOR,Utilitario.Constantes.TIPOCURSORMANO);
				}
				else
				{
					//Label ControlSI = (Label)e.Item.Cells[2].FindControl(CONTROLSI);
					Control.Text="SIMA IQUITOS";
					Control.Font.Underline = true;
					Control.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,"MostrarValor(4);");
					Control.Style.Add(Utilitario.Constantes.CURSOR,Utilitario.Constantes.TIPOCURSORMANO);
				}
			}

			if((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;				
				/*TotalPeru*/	
				if(Page.Request.QueryString[KEYQIDCENTROOPERATIVO].ToString()=="1")
				{
					((Label) e.Item.Cells[1].FindControl(CAMPO5)).Text = Convert.ToDouble(Convert.ToDouble(Convert.ToDouble(dr[COLUMNASCVENTAS]) / Utilitario.Constantes.MILES) + Convert.ToDouble(Convert.ToDouble(dr[COLUMNASCHVENTAS]) / Utilitario.Constantes.MILES)).ToString(Utilitario.Constantes.FORMATODECIMAL5);
					((Label) e.Item.Cells[1].FindControl(CAMPO6)).Text = Convert.ToDouble(Convert.ToDouble(Convert.ToDouble(dr[COLUMNASCCOSTOVENTAS]) / Utilitario.Constantes.MILES) + Convert.ToDouble(Convert.ToDouble(dr[COLUMNASCHCOSTOVENTAS]) / Utilitario.Constantes.MILES)).ToString(Utilitario.Constantes.FORMATODECIMAL5);	
				}
				else if(Page.Request.QueryString[KEYQIDCENTROOPERATIVO].ToString()=="2")
				{
					/*TotalCallao*/	
					((Label) e.Item.Cells[1].FindControl(CAMPO5)).Text = Convert.ToDouble(Convert.ToDouble(dr[COLUMNASCVENTAS]) / Utilitario.Constantes.MILES).ToString(Utilitario.Constantes.FORMATODECIMAL5);
					((Label) e.Item.Cells[1].FindControl(CAMPO6)).Text = Convert.ToDouble(Convert.ToDouble(dr[COLUMNASCCOSTOVENTAS])/ Utilitario.Constantes.MILES).ToString(Utilitario.Constantes.FORMATODECIMAL5);
				}
					/*TotalChimbote*/	
				else if(Page.Request.QueryString[KEYQIDCENTROOPERATIVO].ToString()=="3")
				{
					((Label) e.Item.Cells[1].FindControl(CAMPO5)).Text = Convert.ToDouble(Convert.ToDouble(dr[COLUMNASCHVENTAS]) / Utilitario.Constantes.MILES).ToString(Utilitario.Constantes.FORMATODECIMAL5);
					((Label) e.Item.Cells[1].FindControl(CAMPO6)).Text = Convert.ToDouble(Convert.ToDouble(dr[COLUMNASCHCOSTOVENTAS])/ Utilitario.Constantes.MILES).ToString(Utilitario.Constantes.FORMATODECIMAL5);
				}
					/*TotalIquitos*/	
				else 
				{
					((Label) e.Item.Cells[1].FindControl(CAMPO5)).Text = Convert.ToDouble(Convert.ToDouble(dr[COLUMNASIVENTAS]) / Utilitario.Constantes.MILES).ToString(Utilitario.Constantes.FORMATODECIMAL5);
					((Label) e.Item.Cells[1].FindControl(CAMPO6)).Text = Convert.ToDouble(Convert.ToDouble(dr[COLUMNASICOSTOVENTAS])/ Utilitario.Constantes.MILES).ToString(Utilitario.Constantes.FORMATODECIMAL5);
				}

				//Totales
				totalSPV += Convert.ToDouble(Convert.ToDouble(dr[COLUMNASCVENTAS]) / Utilitario.Constantes.MILES) + Convert.ToDouble(Convert.ToDouble(dr[COLUMNASCHVENTAS]) / Utilitario.Constantes.MILES);
				totalSPC += Convert.ToDouble(Convert.ToDouble(dr[COLUMNASCCOSTOVENTAS]) / Utilitario.Constantes.MILES) + Convert.ToDouble(Convert.ToDouble(dr[COLUMNASCHCOSTOVENTAS]) / Utilitario.Constantes.MILES);
				totalSCV += Convert.ToDouble(dr[COLUMNASCVENTAS]) / Utilitario.Constantes.MILES;
				totalSCC += Convert.ToDouble(dr[COLUMNASCCOSTOVENTAS]) / Utilitario.Constantes.MILES;
				totalSCHV += Convert.ToDouble(dr[COLUMNASCHVENTAS]) / Utilitario.Constantes.MILES;
				totalSCHC += Convert.ToDouble(dr[COLUMNASCHCOSTOVENTAS]) / Utilitario.Constantes.MILES;
				totalSIV += Convert.ToDouble(dr[COLUMNASIVENTAS]) / Utilitario.Constantes.MILES;
				totalSIC += Convert.ToDouble(dr[COLUMNASICOSTOVENTAS]) / Utilitario.Constantes.MILES;

				//e.Item.Cells[2].Text = Convert.ToDouble(Convert.ToDouble(e.Item.Cells[2].Text)/ Utilitario.Constantes.MILES).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);								
			}
			if(e.Item.ItemType == ListItemType.Footer)
			{
				e.Item.Cells[0].Text = TEXTOTOTAL;
				if(Page.Request.QueryString[KEYQIDCENTROOPERATIVO].ToString()=="1")
				{
					((Label) e.Item.Cells[1].FindControl(FCAMPO5)).Text = totalSPV.ToString(Utilitario.Constantes.FORMATODECIMAL5);
					((Label) e.Item.Cells[1].FindControl(FCAMPO6)).Text = totalSPC.ToString(Utilitario.Constantes.FORMATODECIMAL5);
				}
				else if(Page.Request.QueryString[KEYQIDCENTROOPERATIVO].ToString()=="2")
				{
					((Label) e.Item.Cells[1].FindControl(FCAMPO5)).Text = totalSCV.ToString(Utilitario.Constantes.FORMATODECIMAL5);
					((Label) e.Item.Cells[1].FindControl(FCAMPO6)).Text = totalSCC.ToString(Utilitario.Constantes.FORMATODECIMAL5);
				}
				else if(Page.Request.QueryString[KEYQIDCENTROOPERATIVO].ToString()=="3")
				{
					((Label) e.Item.Cells[1].FindControl(FCAMPO5)).Text = totalSCHV.ToString(Utilitario.Constantes.FORMATODECIMAL5);
					((Label) e.Item.Cells[1].FindControl(FCAMPO6)).Text = totalSCHC.ToString(Utilitario.Constantes.FORMATODECIMAL5);

				}
				else 
				{
					((Label) e.Item.Cells[2].FindControl(FCAMPO5)).Text = totalSIV.ToString(Utilitario.Constantes.FORMATODECIMAL5);
					((Label) e.Item.Cells[2].FindControl(FCAMPO6)).Text = totalSIC.ToString(Utilitario.Constantes.FORMATODECIMAL5);
				}
				/*Artificio = Solo la suma de Ambos me dira que verdaderamente no hay nada de montos por ningun lado*/
				if((totalSPV + totalSPC + totalSIV + totalSIC) == Utilitario.Constantes.ValorConstanteCero)
				{
					e.Item.Cells[0].Visible=false;
					e.Item.Cells[1].Visible=false;
					//e.Item.Cells[2].Visible=false;
					//e.Item.Cells[3].Visible=false;
				}
				else
				{
					e.Item.Cells[0].Visible=true;
					e.Item.Cells[1].Visible=true;
					//e.Item.Cells[2].Visible=true;
					//e.Item.Cells[3].Visible=true;
				}
			}
		}

		private DataTable DataTableVacio()
		{
			DataTable dt = new DataTable();
			dt.Columns.Add(DESCRIPCION);
			dt.Columns.Add(COLUMNASCVENTAS);
			dt.Columns.Add(COLUMNASCCOSTOVENTAS);
			dt.Columns.Add(COLUMNASCHVENTAS);
			dt.Columns.Add(COLUMNASCHCOSTOVENTAS);
			dt.Columns.Add(COLUMNASIVENTAS);
			dt.Columns.Add(COLUMNASICOSTOVENTAS);

			//Asignamos una fila vacia al DataTable
			DataRow dr = dt.NewRow();
			dr.ItemArray = new object[7]{
											Utilitario.Constantes.VACIO,
											Utilitario.Constantes.ValorConstanteCero,
											Utilitario.Constantes.ValorConstanteCero,
											Utilitario.Constantes.ValorConstanteCero,
											Utilitario.Constantes.ValorConstanteCero,
											Utilitario.Constantes.ValorConstanteCero,
											Utilitario.Constantes.ValorConstanteCero
										};
			dt.Rows.Add(dr);
			return dt;
		}
	}
}
