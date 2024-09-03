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
using NetAccessControl;
using SIMA.ManejadorExcepcion;
using SIMA.Log;

namespace SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancieros
{
	/// <summary>
	/// Summary description for ConsultarFormatoRubroMovimiento.
	/// </summary>
	public class ConsultarFormatoRubroMovimiento : System.Web.UI.Page,IPaginaBase
	{
		#region Constantes
		const string KEYQVERIQUITOS ="Ver";
		const string KEYQNOMBRERUBRO ="NRubro";
		const string KEYQIDFORMATO = "IdFormato";
		const string KEYQIDRUBRO = "IdRubro";
		const string KEYQIDFECHA = "efFecha";
		const string KEYQIDIDTIPOINFORMACION ="idTipoInfo";

		const string KEYQIDINTERFAZ = "interfaz";

		const string TEXTOTOTAL = "Total";
			
		const string CAMPO1 ="lblCallao";
		const string CAMPO2 ="lblChimbote";
		const string CAMPO3 = "lblTotalSP";

		const string FCAMPO1 = "lblFooterCallao";
		const string FCAMPO2 = "lblFooterChimbote";
		const string FCAMPO3 = "lblFooterTotalSP"; 

		const string CONTROLSP = "lblHPeru";
		const string CONTROLSC = "lblHCallao";
		const string CONTROLSCH = "lblHChimbote";

		

		//Nuevos Key Session y QueryString
		const string KEYQOBSCALLAO = "ObsCallao";
		const string KEYQOBSCHIMBOTE = "ObsChimbote";
		const string KEYQOBSIQUITOS = "ObsIquitos";
		const string KEYQOBSPERU = "ObsPeru";

		//Columnas Grilla y DataTable
		const string COLUMNAORDEN ="Orden";
		const string COLUMNADESCRIPCION="descripcion";
		const string COLUMNATOTALSP = "";
		const string COLUMNASIMACALLAO="SimaCallao";
		const string COLUMNASIMACHIMBOTE="SimaChimbote";
		const string COLUMNASIMAIQUITOS="SimaIquitos";

		//Columnas GRILLA ORDEN
		const int ORDCOLUMNACONCEPTO = 0;
		const int ORDCOLUMNATOTALSP = 1;
		const int ORDCOLUMNASP = 1;
		const int ORDCOLUMNASI = 2;
		
			
		
		
		
		DateTime FechaPeriodo;
		#endregion

		#region Variables
		double totalSP=0.0;
		double totalSC=0.0;
		double totalSCH =0.0;
		double totalSI = 0.0;
		#endregion Variables

		#region Controles

			protected System.Web.UI.WebControls.Label Label1;
			protected projDataGridWeb.DataGridWeb grid;
			protected System.Web.UI.WebControls.Label lblResultado;
			protected System.Web.UI.WebControls.Label lblRubro;
			protected System.Web.UI.HtmlControls.HtmlInputHidden hObsCallao;
			protected System.Web.UI.HtmlControls.HtmlInputHidden hObsChimbote;
			protected System.Web.UI.HtmlControls.HtmlInputHidden hObsIquitos;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hObsPeru;
		protected System.Web.UI.HtmlControls.HtmlTextArea campo1;
		protected System.Web.UI.HtmlControls.HtmlTextArea campo4;
		protected System.Web.UI.HtmlControls.HtmlTextArea campo2;
		protected System.Web.UI.HtmlControls.HtmlTextArea campo3;
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
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members
		private void GeneraFecha()
		{FechaPeriodo =  Convert.ToDateTime(DateTime.DaysInMonth(Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA]).Year,Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA]).Month) + Utilitario.Constantes.SEPARADORFECHA + Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA]).Month.ToString().PadLeft(2,'0') + Utilitario.Constantes.SEPARADORFECHA  + Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA]).Year.ToString());}

		private DataTable  ObtenerDatos()
		{
			this.GeneraFecha();
			return ((CFormatoRubroDetalleMovimiento) new CFormatoRubroDetalleMovimiento())
				.ConsultarFormatoRubroDetalleMovimientoCorporativoYCentro
				(Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO])
				,Convert.ToInt32(Page.Request.Params[KEYQIDRUBRO])
				,Convert.ToInt32(Page.Request.Params[KEYQIDIDTIPOINFORMACION])
				,Convert.ToInt32(FechaPeriodo.Year.ToString())
				,Convert.ToInt32(FechaPeriodo.Month.ToString())
				,Convert.ToInt32(Page.Request.Params[KEYQIDINTERFAZ]));
		}

		public void LlenarGrilla()
		{
			grid.Columns[ORDCOLUMNASI].Visible  = (Convert.ToInt32(Page.Request.Params[KEYQVERIQUITOS])==0)?false:true;
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
			// TODO:  Add ConsultarFormatoRubroMovimiento.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add ConsultarFormatoRubroMovimiento.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add ConsultarFormatoRubroMovimiento.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			this.lblRubro.Text = Page.Request.Params[KEYQNOMBRERUBRO].ToString().ToUpper();
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarFormatoRubroMovimiento.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarFormatoRubroMovimiento.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarFormatoRubroMovimiento.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarFormatoRubroMovimiento.Exportar implementation
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
			// TODO:  Add ConsultarFormatoRubroMovimiento.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{			
			if(e.Item.ItemType == ListItemType.Header)
			{	/*
				if((Page.Request.Params[KEYQIDFORMATO].ToString() == "21") &&  (Page.Request.Params[KEYQIDRUBRO].ToString()=="26"))
				*/				
					
					Label ControlSP = (Label)e.Item.Cells[ORDCOLUMNASP].FindControl(CONTROLSP);
					//vartemp = ControlSP.ClientID.ToString();	//Codigo utilizado para obtener el nombre del control desde el lado de html
					ControlSP.Font.Underline = true;
					ControlSP.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,"OcultarMostrarFila(1)," + Utilitario.Constantes.CAMBIARCOLORSELECCIONGRILLAPOPUP);	
					ControlSP.Style.Add(Utilitario.Constantes.CURSOR,Utilitario.Constantes.TIPOCURSORMANO);
							
					Label ControlSC = (Label)e.Item.Cells[ORDCOLUMNASP].FindControl(CONTROLSC);
					ControlSC.Font.Underline = true;
					ControlSC.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,"OcultarMostrarFila(2)," + Utilitario.Constantes.CAMBIARCOLORSELECCIONGRILLAPOPUP);
					ControlSC.Style.Add(Utilitario.Constantes.CURSOR,Utilitario.Constantes.TIPOCURSORMANO);

					Label ControlSCH = (Label)e.Item.Cells[ORDCOLUMNASP].FindControl(CONTROLSCH);
					ControlSCH.Font.Underline = true;
					ControlSCH.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,"OcultarMostrarFila(3)," + Utilitario.Constantes.CAMBIARCOLORSELECCIONGRILLAPOPUP);
					ControlSCH.Style.Add(Utilitario.Constantes.CURSOR,Utilitario.Constantes.TIPOCURSORMANO);

					e.Item.Cells[ORDCOLUMNASI].Font.Underline=true;
					e.Item.Cells[ORDCOLUMNASI].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,"OcultarMostrarFila(4)," + Utilitario.Constantes.CAMBIARCOLORSELECCIONGRILLAPOPUP);
					e.Item.Cells[ORDCOLUMNASI].Style.Add(Utilitario.Constantes.CURSOR,Utilitario.Constantes.TIPOCURSORMANO);
				

			}
			if((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;				
					((Label) e.Item.Cells[ORDCOLUMNATOTALSP].FindControl(CAMPO3)).Text = Convert.ToDouble(Convert.ToDouble(Convert.ToDouble(dr[COLUMNASIMACALLAO]) / Utilitario.Constantes.MILES) + Convert.ToDouble(Convert.ToDouble(dr[COLUMNASIMACHIMBOTE])/ Utilitario.Constantes.MILES)).ToString(Utilitario.Constantes.FORMATODECIMAL5);					
					((Label) e.Item.Cells[ORDCOLUMNASP].FindControl(CAMPO1)).Text = Convert.ToDouble(Convert.ToDouble(dr[COLUMNASIMACALLAO]) / Utilitario.Constantes.MILES).ToString(Utilitario.Constantes.FORMATODECIMAL5);
					((Label) e.Item.Cells[ORDCOLUMNASP].FindControl(CAMPO2)).Text = Convert.ToDouble(Convert.ToDouble(dr[COLUMNASIMACHIMBOTE])/ Utilitario.Constantes.MILES).ToString(Utilitario.Constantes.FORMATODECIMAL5);					
					e.Item.Cells[ORDCOLUMNASI].Text = Convert.ToDouble(Convert.ToDouble(dr[COLUMNASIMAIQUITOS])/ Utilitario.Constantes.MILES).ToString(Utilitario.Constantes.FORMATODECIMAL5);

					totalSP += Convert.ToDouble(Convert.ToDouble(dr[COLUMNASIMACALLAO]) / Utilitario.Constantes.MILES) + Convert.ToDouble(Convert.ToDouble(dr[COLUMNASIMACHIMBOTE])/ Utilitario.Constantes.MILES);
					totalSC += Convert.ToDouble(dr[COLUMNASIMACALLAO]) / Utilitario.Constantes.MILES;
					totalSCH += Convert.ToDouble(dr[COLUMNASIMACHIMBOTE])/ Utilitario.Constantes.MILES;
					totalSI += Convert.ToDouble(dr[COLUMNASIMAIQUITOS])/ Utilitario.Constantes.MILES;

				/*
				if((Page.Request.Params[KEYQIDFORMATO].ToString() == "21") &&  (Page.Request.Params[KEYQIDRUBRO].ToString()=="26"))
				*/				
				
					Helper.SeleccionarItemGrillaOnClickMoverRaton(e);				
			}
			if(e.Item.ItemType == ListItemType.Footer)
			{
				e.Item.Cells[0].Text = TEXTOTOTAL;

				((Label)e.Item.Cells[ORDCOLUMNATOTALSP].FindControl(FCAMPO3)).Text = totalSP.ToString(Utilitario.Constantes.FORMATODECIMAL5);
				((Label)e.Item.Cells[ORDCOLUMNASP].FindControl(FCAMPO1)).Text = totalSC.ToString(Utilitario.Constantes.FORMATODECIMAL5);
				((Label)e.Item.Cells[ORDCOLUMNASP].FindControl(FCAMPO2)).Text = totalSCH.ToString(Utilitario.Constantes.FORMATODECIMAL5);				
				e.Item.Cells[ORDCOLUMNASI].Text = totalSI.ToString(Utilitario.Constantes.FORMATODECIMAL5);

				if(totalSP == Utilitario.Constantes.ValorConstanteCero)
				{
					e.Item.Cells[0].Visible =false;
					e.Item.Cells[ORDCOLUMNATOTALSP].Visible=false;
					e.Item.Cells[ORDCOLUMNASP].Visible=false;
					e.Item.Cells[ORDCOLUMNASI].Visible=false;					
				}
				else
				{				
					e.Item.Cells[0].Visible =true;					
					e.Item.Cells[ORDCOLUMNATOTALSP].Visible=true;
					e.Item.Cells[ORDCOLUMNASP].Visible=true;
					e.Item.Cells[ORDCOLUMNASI].Visible=true;
					
				}
			}
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
		private DataTable DataTableVacio()
		{
			DataTable dt = new DataTable();
			dt.Columns.Add(COLUMNAORDEN);
			dt.Columns.Add(COLUMNADESCRIPCION);
			dt.Columns.Add(COLUMNASIMACALLAO);
			dt.Columns.Add(COLUMNASIMACHIMBOTE);
			dt.Columns.Add(COLUMNASIMAIQUITOS);

			//Asignamos una fila vacia al DataTable
			DataRow dr = dt.NewRow();
			dr.ItemArray = new object[5]{
											Utilitario.Constantes.ValorConstanteCero,
											Utilitario.Constantes.VACIO,
											Utilitario.Constantes.ValorConstanteCero,
											Utilitario.Constantes.ValorConstanteCero,
											Utilitario.Constantes.ValorConstanteCero
										};
			dt.Rows.Add(dr);
			return dt;
		}
	}
}
