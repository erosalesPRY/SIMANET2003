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
using SIMA.Controladoras;
using SIMA.Controladoras.General;
using SIMA.Controladoras.GestionFinanciera;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;
using System.Drawing.Printing;
namespace SIMA.SimaNetWeb.GestionFinanciera.Presupuesto
{
	/// <summary>
	/// Summary description for FlitrosReportePresupuesto.
	/// </summary>
	public class FlitrosReportePresupuesto : System.Web.UI.Page,IPaginaBase
	{
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.DropDownList ddlbCentroOperativo;
		protected System.Web.UI.WebControls.DropDownList ddlbTipoPPto;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hPeriodo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hTipoPresupuesto;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdCentroOperativo;
		protected System.Web.UI.WebControls.DropDownList ddlbPeriodo;
		protected System.Web.UI.WebControls.DataGrid grid;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdCentroCosto;
		protected System.Web.UI.HtmlControls.HtmlInputHidden Hidden1;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;
		protected System.Web.UI.WebControls.DataGrid gridGRP;
		protected System.Web.UI.HtmlControls.HtmlInputText objLstChkGRP;
			protected System.Web.UI.WebControls.Literal ltlMensaje;


		string InfoReal{
			get{return Page.Request.Params["Real"];}
		}
		public int Periodo
		{
			get{return Convert.ToInt32(ddlbPeriodo.SelectedValue); }
		}
		public int TipoPresupuesto
		{
			get{return Convert.ToInt32(ddlbTipoPPto.SelectedValue); }
		}
		public int IdCentroOperativo
		{
			get{
				string []IdCODigCta = this.hIdCentroOperativo.Value.ToString().Split(',');  
				return Convert.ToInt32(IdCODigCta[0]); 
				}
		}
		public string DigCta
		{
			get
			{
				string []IdCODigCta = this.hIdCentroOperativo.Value.ToString().Split(',');  
				return IdCODigCta[1].ToString(); 
			}
		}

		public string LstGrupoCC
		{
			get{
				return ((objLstChkGRP.Value.EndsWith(";"))?objLstChkGRP.Value.Substring(0,objLstChkGRP.Value.Length-1):"0");
			}
		}
		public string LstGrupoCCIn
		{
			get
			{
				return ((objLstChkGRP.Value.EndsWith(";"))?objLstChkGRP.Value.Replace(";","','"):"0");
			}
		}

		public string LstCC
		{
			get
			{
				return ((objLstChkCC.Value.EndsWith(";"))?objLstChkCC.Value.Substring(0,objLstChkCC.Value.Length-1):"0");
			}
		}
		public string LstCCIn
		{
			get
			{
				return ((objLstChkCC.Value.EndsWith(";"))?objLstChkCC.Value.Replace(";","','"):"0");
			}
		}

		
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Button btnLstCC;
		protected System.Web.UI.WebControls.DataGrid gridCC;

		double TotalNat =0;
		double TotalGrp =0;
		protected System.Web.UI.WebControls.Button btnActNat;
		protected System.Web.UI.HtmlControls.HtmlInputText objLstChkCC;
		protected System.Web.UI.WebControls.ImageButton imgXLS;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Button btnPosGrupoCC;
		protected System.Web.UI.WebControls.Button btnPosNaturaleza;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.HtmlControls.HtmlTable tblBtns;
		double TotalCC =0;

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
				
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarJScript();
					this.LlenarDatos();
					this.LlenarCombos();
					Utilitario.Helper.ReestablecerPagina();
					if(this.hTipoPresupuesto.Value.Length>0)
					{
						this.LlenarCentroOperativo(Convert.ToInt32(this.hTipoPresupuesto.Value));
						if(this.hIdCentroOperativo.Value.Length>0)
						{
							ListItem item =  this.ddlbCentroOperativo.Items.FindByValue(this.hIdCentroOperativo.Value);
							if(item!=null){item.Selected=true;}
							this.LlenarGrilla();
						}
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
					string msgb =oException.Message.ToString();
					SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
					Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
				}
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
			this.ddlbTipoPPto.SelectedIndexChanged += new System.EventHandler(this.ddlbTipoPPto_SelectedIndexChanged);
			this.ddlbCentroOperativo.SelectedIndexChanged += new System.EventHandler(this.ddlbCentroOperativo_SelectedIndexChanged);
			this.btnLstCC.Click += new System.EventHandler(this.btnLstCC_Click);
			this.btnActNat.Click += new System.EventHandler(this.btnActNat_Click);
			this.btnPosGrupoCC.Click += new System.EventHandler(this.btnPosGrupoCC_Click);
			this.btnPosNaturaleza.Click += new System.EventHandler(this.btnPosNaturaleza_Click);
			this.imgXLS.Click += new System.Web.UI.ImageClickEventHandler(this.imgXLS_Click);
			this.gridGRP.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.gridGRP_ItemDataBound);
			this.gridGRP.SelectedIndexChanged += new System.EventHandler(this.gridGRP_SelectedIndexChanged);
			this.gridCC.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.gridCC_ItemDataBound);
			this.gridCC.SelectedIndexChanged += new System.EventHandler(this.gridCC_SelectedIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members
		//string DigCta="";
		public void LlenarGrilla()
		{
			objLstChkGRP.Value="";
			objLstChkCC.Value="";
				
			this.SoloNaturalezaGasto();

			//Llenar Grupos de CC
			DataTable dtg = (new CPresupuestoxGrupoCC()).ListarOperaciones(this.Periodo,this.IdCentroOperativo,this.DigCta,this.LstGrupoCC,this.InfoReal);
			if(dtg!=null && dtg.Rows.Count>0)
			{
				string []lstGrp= new string[3]{"IdGrupoCentroCosto","NroGrupoCentroCosto","NombreGrupoCentroCosto"};
				string []lstFieldTot= new string[1]{"Total"};
				DataTable dtResumen= Utilitario.Helper.Data.GroupBy(dtg,lstGrp,lstFieldTot);
				gridGRP.DataSource = dtResumen;
				gridGRP.DataBind();
			}
			else{
				gridGRP.DataSource = null;
				gridGRP.DataBind();
			}
		}

		void SoloNaturalezaGasto(){
			DataTable dt =  (new CPresupuesto()).CargarReportePorTipoCentroDeCostos(Convert.ToInt32(ddlbPeriodo.SelectedValue),this.IdCentroOperativo,this.DigCta,this.LstCC,this.InfoReal);

			string []lstNat= new string[2]{"NatCta","NaturalezaGasto"};
			string []lstTotNat= new string[1]{"pptoActual"};

			DataTable dtNat= Utilitario.Helper.Data.GroupBy(dt,lstNat,lstTotNat);
			this.grid.DataSource = dtNat;
			this.grid.DataBind();
		}

		/*DataTable GenerarRegistroResumen(DataTable dt)
		{
			if(dt!=null)
			{
				string []Monto={"MontoPresupuesto"};
				DataRow myDataRow = dt.NewRow();
				myDataRow["NombreCuenta"]="TOTAL"; 
				foreach(string Mont in Monto)
				{
					myDataRow[Mont] = (Helper.TotalizarDataView(dt.DefaultView,Mont))[0];
				}
				dt.Rows.Add(myDataRow);
				dt.AcceptChanges();
			}
			return dt;
		}*/

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add FlitrosReportePresupuesto.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add FlitrosReportePresupuesto.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			this.LlenarPeriodoContable();
			this.LlenarTipoPresupuesto();
		}
		public void LlenarPeriodoContable()
		{
			CPeriodoContable oCPeriodoContable = new CPeriodoContable();
			ddlbPeriodo.DataSource = oCPeriodoContable.ListarPeriodo();
			ddlbPeriodo.DataValueField="Periodo";
			ddlbPeriodo.DataTextField="Periodo";
			ddlbPeriodo.DataBind();
			ListItem item;
			item = ddlbPeriodo.Items.FindByText(DateTime.Now.Year.ToString());
			if (item !=null){item.Selected = true;}
			this.hPeriodo.Value = item.Value;

		}
		public void LlenarTipoPresupuesto()
		{

			this.ddlbTipoPPto.DataSource = (new CPresupuesto()).CargarComboTipoPresupuesto();
			this.ddlbTipoPPto.DataTextField = "Nombre";
			this.ddlbTipoPPto.DataValueField = "idTipoPresupuesto";
			this.ddlbTipoPPto.DataBind();
			ListItem item = new ListItem("[SELECCIONAR]","-1");
			ddlbTipoPPto.Items.Insert(0,item);
			
		}
		public void LlenarCentroOperativo(int idTipoPresupuesto)
		{
			this.ddlbCentroOperativo.DataSource = (new CPresupuesto()).CargarCOPorTipoPresupuesto(idTipoPresupuesto);
			this.ddlbCentroOperativo.DataTextField = "Descripcion";
			this.ddlbCentroOperativo.DataValueField = "IdCODigCta";
			this.ddlbCentroOperativo.DataBind();
			ListItem item = new ListItem("[SELECCIONAR]","-1");
			ddlbCentroOperativo.Items.Insert(0,item);
		}

		public void LlenarDatos()
		{
			Label6.Text = Page.Request.Params["OPNombre"].ToString().ToUpper();
		}

		public void LlenarJScript()
		{
			//this.ibtnFiltrar.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.PopupDeEspera() + Helper.HistorialIrAdelantePersonalizado("hIdCentroCosto","hPeriodo","hIdCentroOperativo","ddlbCentroCosto","ddlbCentroOperativo","hTipoPresupuesto","ddlbTipoPPto","ddlbPeriodo"));
			string []lstCtrl = new string[8]{"objLstChkGRP","objLstChkCC","hIdCentroCosto","hPeriodo","hIdCentroOperativo","hTipoPresupuesto","ddlbTipoPPto","ddlbPeriodo"};
			//this.ddlbCentroOperativo.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.PopupDeEspera());
			btnPosGrupoCC.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.PopupDeEspera() + Helper.HistorialIrAdelantePersonalizado(lstCtrl));
			btnPosNaturaleza.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.PopupDeEspera() + Helper.HistorialIrAdelantePersonalizado(lstCtrl));
			imgXLS.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.PopupDeEspera() + Helper.HistorialIrAdelantePersonalizado(lstCtrl));

			ddlbTipoPPto.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnChange.ToString(),Helper.PopupDeEspera());
			this.ddlbCentroOperativo.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnChange.ToString(),Helper.PopupDeEspera());
		}

		public void RegistrarJScript()
		{
			// TODO:  Add FlitrosReportePresupuesto.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add FlitrosReportePresupuesto.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add FlitrosReportePresupuesto.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add FlitrosReportePresupuesto.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add FlitrosReportePresupuesto.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void ddlbPeriodo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(this.ddlbPeriodo.SelectedIndex !=-1)
			{
				this.hPeriodo.Value = this.ddlbPeriodo.SelectedValue;
				this.LlenarTipoPresupuesto();
			}
		
		}

		private void ddlbTipoPPto_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			objLstChkGRP.Value="";
			objLstChkCC.Value="";
			if(this.ddlbTipoPPto.SelectedIndex !=-1)
			{
				this.hTipoPresupuesto.Value = this.ddlbTipoPPto.SelectedValue;
				this.LlenarCentroOperativo(Convert.ToInt32(this.hTipoPresupuesto.Value));
				
			}
		}

		private void ddlbCentroOperativo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
				if(this.ddlbCentroOperativo.SelectedIndex !=-1)
				{
					this.hIdCentroOperativo.Value = this.ddlbCentroOperativo.SelectedValue;
					this.LlenarGrilla();
					tblBtns.Style.Add("Display","block");
				 }
		
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				e.Item.Cells[2].Text = Convert.ToDouble(e.Item.Cells[2].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				/*if(e.Item.Cells[1].Text == "TOTAL")
				{
					e.Item.CssClass="FooterGrilla";
					e.Item.Height=30;
				}*/
				Utilitario.Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				TotalNat += Convert.ToDouble(dr["pptoActual"]);
			}
			if(e.Item.ItemType == ListItemType.Footer)
			{
				e.Item.CssClass="FooterGrilla";
				e.Item.Height=30;
				e.Item.Cells[1].Text = "TOTAL:";
				e.Item.Cells[2].Text = TotalNat.ToString(Utilitario.Constantes.FORMATODECIMAL4);

			}

		}

		private void ibtnFiltrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			string Cadena = ObtenerCadenaFiltro();
			string []IdCODigCta = this.hIdCentroOperativo.Value.ToString().Split(',');  
			string DigCta = IdCODigCta[1].ToString();

			DataTable dt = (new CPresupuesto()).ResumenPPtalPorCentroCostos(Convert.ToInt32(hPeriodo.Value),DigCta,Convert.ToInt32(hIdCentroCosto.Value),this.InfoReal);
			DataView dv = dt.DefaultView;
			if(Cadena !=""){dv.RowFilter = "NatCta in ("+ Cadena +")";}
			

			Helper.EjecutarReporte(@"C:\SimanetReportes\GestionFinanciera\Presupuesto\Meses\"
				,"RelacionResumenMontoPresupuestalAño.rpt"
				, Helper.DataViewTODataTable(dv)
				,true);

		}
		string ObtenerCadenaFiltro()
		{
			string Cad="";
			foreach(DataGridItem dgItem in grid.Items )
			{
				CheckBox cbx =(CheckBox)dgItem.Cells[3].FindControl("chkCuenta");

				if(cbx.Checked ==true)
				{
					Cad = Cad+"'"+dgItem.Cells[0].Text+"',";
				}
			}

			if(Cad.EndsWith(",")){
				int num = Cad.Length-1;
				Cad = Cad.Substring(0,num);
			}
			return Cad;

		}

		

		private void Imagebutton1_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			
		
		}

		private void imgXLS_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if((this.ddlbTipoPPto.SelectedValue!="-1")&&(this.ddlbCentroOperativo.SelectedValue!="-1"))
			{
				string []Valores = ddlbCentroOperativo.SelectedValue.ToString().Split(',');
				DataTable dt =  (new CPresupuesto()).CargarReportePorTipoCentroDeCostos(Convert.ToInt32(ddlbPeriodo.SelectedValue),Convert.ToInt32(Valores[0]),Valores[1],this.LstCC,this.InfoReal);
				string LstDigCta = ObtenerCadenaFiltro();
				string CadFiltro="";
				if(LstDigCta.Length>0){CadFiltro="NatCta in ("+ LstDigCta +")"; }
				DataView dv = dt.DefaultView;
				dv.RowFilter=CadFiltro;

				Helper.EjecutarReporte(@"C:\SimanetReportes\GestionFinanciera\Presupuesto\Meses\"
					,"ResumenPresupuestalPorTipoCentroCostoXLS.rpt"
					,Helper.DataViewTODataTable(dv)
					,false,false,".xls");
			}
			else{
				Helper.MsgBox("Parámetros","No se ha seleccionado los parámetros necesarios para generar el reporte",SIMA.Utilitario.Enumerados.Ext.MessageBox.Button.OK,SIMA.Utilitario.Enumerados.Ext.MessageBox.Icon.ERROR);
			}
		
		}

		private void gridGRP_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			e.Item.Cells[4].Style.Add("display","none");
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				e.Item.Cells[2].Text = Convert.ToDouble(e.Item.Cells[2].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				if(e.Item.Cells[1].Text == "TOTAL")
				{
					e.Item.CssClass="FooterGrilla";
					e.Item.Height=30;
				}
				CheckBox chk = (CheckBox)e.Item.Cells[3].FindControl("chkGrp"); 
				chk.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnClick.ToString(),"ElaboraSTRGrupoCC();"+ Helper.PopupDeEspera());
				Utilitario.Helper.SeleccionarItemGrillaOnClickMoverRaton(e);

				TotalGrp += Convert.ToDouble(dr["Total"].ToString());
			
			}
			if(e.Item.ItemType == ListItemType.Footer)
			{
				e.Item.CssClass="FooterGrilla";
				e.Item.Height=30;
				e.Item.Cells[1].Text="TOTAL:";
				e.Item.Cells[2].Text=TotalGrp.ToString(Utilitario.Constantes.FORMATODECIMAL4);
			}
		}

		private void gridGRP_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void btnLstCC_Click(object sender, System.EventArgs e)
		{
			ListarCentrosdeCostoxGrupo();
		}
		void ListarCentrosdeCostoxGrupo(){
			TotalCC=0;
			if(this.LstCC.Length>0)
			{
				DataTable dtg = (new CPresupuestoxGrupoCC()).ListarOperaciones(this.Periodo,this.IdCentroOperativo,this.DigCta,this.LstGrupoCC,this.InfoReal);
				if(dtg!=null&&dtg.Rows.Count>0)
				{
					string []lstCC= new string[4]{"IdGrupoCentroCosto","IdCentroCosto","NroCentroCosto","NombreCentroCosto"};
					string []lstFieldTot= new string[1]{"Total"};
					string inStr = this.LstGrupoCCIn +"9'";
					string srtWhere = " IdGrupoCentroCosto in ('" +inStr+")";
					DataTable dtResumen= Utilitario.Helper.Data.GroupBy(dtg,srtWhere,lstCC,lstFieldTot);
					gridCC.DataSource = dtResumen;
					gridCC.DataBind();
				}
				else{
					gridCC.DataSource = null;
					gridCC.DataBind();
				}
			}
		}

		private void gridCC_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			e.Item.Cells[4].Style.Add("display","none");
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				e.Item.Cells[2].Text = Convert.ToDouble(e.Item.Cells[2].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				CheckBox chk = (CheckBox)e.Item.Cells[3].FindControl("chkGrp"); 
				chk.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnClick.ToString(),"ElaboraLstCC();"+ Helper.PopupDeEspera());
				Utilitario.Helper.SeleccionarItemGrillaOnClickMoverRaton(e);

				TotalCC += Convert.ToDouble(dr["Total"].ToString());
			
			}
			if(e.Item.ItemType == ListItemType.Footer)
			{
				e.Item.CssClass="FooterGrilla";
				e.Item.Height=30;
				e.Item.Cells[1].Text="TOTAL:";
				e.Item.Cells[2].Text=TotalCC.ToString(Utilitario.Constantes.FORMATODECIMAL4);
			}
		
		}

		private void btnActNat_Click(object sender, System.EventArgs e)
		{
			SoloNaturalezaGasto();
		}

		private void gridCC_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void btnPosNaturaleza_Click(object sender, System.EventArgs e)
		{
			if((this.ddlbTipoPPto.SelectedValue!="-1")&&(this.ddlbCentroOperativo.SelectedValue!="-1"))
			{
				DataTable dt =  (new CPresupuesto()).CargarReportePorTipoCentroDeCostos(Convert.ToInt32(ddlbPeriodo.SelectedValue),this.IdCentroOperativo,this.DigCta,this.LstCC,this.InfoReal);
				string LstDigCta = ObtenerCadenaFiltro();
				string CadFiltro="";
				if(LstDigCta.Length>0){CadFiltro="NatCta in ("+ LstDigCta +")"; }
				DataView dv = dt.DefaultView;
				dv.RowFilter=CadFiltro;

				Helper.EjecutarReporte(@"C:\SimanetReportes\GestionFinanciera\Presupuesto\Meses\"
					,"ResumenPresupuestalPorTipoCentroCosto.rpt"
					,Helper.DataViewTODataTable(dv)
					,true);
			}
			else
			{
				Helper.MsgBox("Parámetros","No se ha seleccionado los parámetros necesarios para generar el reporte",SIMA.Utilitario.Enumerados.Ext.MessageBox.Button.OK,SIMA.Utilitario.Enumerados.Ext.MessageBox.Icon.ERROR);
			}

		}

		private void btnPosGrupoCC_Click(object sender, System.EventArgs e)
		{
			//Llenar Grupos de CC
			if((this.ddlbTipoPPto.SelectedValue!="-1")&&(this.ddlbCentroOperativo.SelectedValue!="-1"))
			{
				DataTable dt = (new CPresupuestoxGrupoCC()).ListarOperaciones(this.Periodo,this.IdCentroOperativo,this.DigCta,this.LstGrupoCC,this.InfoReal);
				Helper.EjecutarReporte(@"C:\SimanetReportes\GestionFinanciera\Presupuesto\"
					,"FormulacionEvaluacionPorGrupoCC.rpt"
					,dt
					,true);
			}
			else{
					Helper.MsgBox("Parámetros","No se ha seleccionado los parámetros necesarios para generar el reporte",SIMA.Utilitario.Enumerados.Ext.MessageBox.Button.OK,SIMA.Utilitario.Enumerados.Ext.MessageBox.Icon.ERROR);
			}

		}

		
	}
}
