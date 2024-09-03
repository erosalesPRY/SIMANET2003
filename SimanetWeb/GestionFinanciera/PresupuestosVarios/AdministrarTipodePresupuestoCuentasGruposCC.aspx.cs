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
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using NullableTypes;
using MetaBuilders.WebControls;
using System.Reflection;


namespace SIMA.SimaNetWeb.GestionFinanciera.PresupuestoVarios
{
	public class AdministrarTipodePresupuestoCuentasGruposCC : System.Web.UI.Page,IPaginaBase
	{
		#region Constantes
		const string GRILLAVACIA ="No existe ningún Registro.";  
		const string KEYIDCENTROOPERATIVO ="centro";  
		
		const string KEYIDTIPOPRESUPUESTOCUENTA ="idTipoPresupuestoCta";  
		const string KEYIDPRESUPUESTOCUENTA ="Cta";  
		const string KEYIDTIPOPRESUPUESTO ="idTipoPresupuesto";
		
		const string KEYIDNOMBRETIPOPRESUPUESTO ="NombreTipoPresupuesto";

		const string KEYIDGRUPOCC ="idGrpCC";
		const string KEYIDNOMBREGRUPOCC ="NombreGrpCC";
		const string KEYIDPERIODO ="periodo";
		const string KEYIDMES ="idMes";
		const string KEYIDNOMBREMES ="NombreMes";

		const string URLPRESUPUESTOCUENTA ="AdministrarTipodePresupuestoCuentasGruposCC.aspx?";
		const string URLPRESUPUESTOCUENTAGRUPOCCMOV ="AdministrarTipodePresupuestoCuentasGruposCCCentrodeCosto.aspx?";
		const string URLADMINISTRACIONGRUPOCC ="AdministrarGrupoDeCentroDeCostos.aspx";
		const string LBLPPTO="lblPresupuesto";
		const string LBLREAL="lblReal";
		const string LBLSALDO="lblSaldo";
		
		const string LBLPPTOF="lblPresupuestoF";
		const string LBLREALF="lblRealF";
		const string LBLSALDOF="lblSaldoF";

		//DataGrid and DataColumn
		const string COLUMNAMONTOPTO ="MontoPresupuesto";
		const string COLUMNAMONTOREAL ="MontoReal";
		const string COLUMNASALDO ="Saldo";
		const string COLUMNAIDTIPOPTOCTA ="idTipoPresupuestoCuenta";
		const string COLUMNADESCRIPCION ="Descripcion";
		const string COLUMNAIDCENTROOPERATIVO ="idCentroOperativo";
		const string COLUMNADIGCTA ="digCta";
		const string COLUMNAIDGRUPOCC ="idGrupoCC";
		const string COLUMNANROGRUPOCC ="NroGrupoCC";
		const string COLUMNANOMBRE ="Nombre";

		//Otros
		const string SESSIONTOTALIZA ="Totaliza";
		const string SESSIONFINPPTOCO ="finPPTOCO";

        const string TITULOTOTAL ="TOTAL :";

		//Controles
		const string CTRLBUSCAR ="txtBuscar";
		

		#endregion

		#region Controles
			protected System.Web.UI.WebControls.Label lblRutaPagina;
			protected System.Web.UI.WebControls.Label lblPagina;
			protected System.Web.UI.WebControls.Label Label1;
			protected System.Web.UI.WebControls.Label lblPeriodo;
			protected System.Web.UI.WebControls.Label Label2;
			protected System.Web.UI.WebControls.Label lblMes;
			protected System.Web.UI.WebControls.Label lblTipoPresupuesto;
			protected projDataGridWeb.DataGridWeb grid;
			protected System.Web.UI.WebControls.Label lblResultado;
			protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
			protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPaginaSort;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.DropDownList ddldPresupuestoCuenta;
		protected System.Web.UI.WebControls.DropDownList ddldCentroOperativo;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminaFiltro;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnFiltrarSeleccion;
		protected System.Web.UI.WebControls.Label Label4;
			protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion
		private void Page_Load(object sender, System.EventArgs e)
		{
			//this.grid.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(Utilitario.Helper.FooterSpan);
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					this.LlenarJScript();
					Helper.ReiniciarSession();
					this.LlenarCombos();
					this.LlenarDatos();
					Helper.ReestablecerPagina(this);
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Auditoria",this.ToString(),"Se consultó las Acciones Correctivas.",Enumerados.NivelesErrorLog.I.ToString()));
					this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Convert.ToInt32(this.hGridPagina.Value));
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
					SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Utilitario.Constantes.CODIGOERRORGENERICO,oException.Message);
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
			this.ddldPresupuestoCuenta.SelectedIndexChanged += new System.EventHandler(this.ddldPresupuestoCuenta_SelectedIndexChanged);
			this.ibtnEliminaFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminaFiltro_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add AdministrarTipodePresupuestoCuentasGruposCC.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarTipodePresupuestoCuentasGruposCC.LlenarGrillaOrdenamiento implementation
		}

		private DataTable ObtenerDatos()
		{
			return ((CTipoPresupuestoCuentaGrupoCC)new CTipoPresupuestoCuentaGrupoCC()).AdministrarDetalleTiposdePresupuestoCuentaGrupoCC(
																																			Convert.ToInt32(ddldPresupuestoCuenta.SelectedValue)
																																			,Convert.ToInt32(ddldCentroOperativo.SelectedValue)
																																			,CNetAccessControl.GetIdUser()
																																			,Convert.ToInt32(Page.Request.Params[KEYIDPERIODO])
																																			,Convert.ToInt32(Page.Request.Params[KEYIDMES]));
		}

		private void Totalizar(DataView dtv)
		{
			if (dtv !=null)
			{
				ArrayList arrTotal = new ArrayList();
				arrTotal.Add(Helper.TotalizarDataView(dtv,COLUMNAMONTOPTO)[0]);	
				arrTotal.Add(Helper.TotalizarDataView(dtv,COLUMNAMONTOREAL)[0]);	
				arrTotal.Add(Helper.TotalizarDataView(dtv,COLUMNASALDO)[0]);	
				Session[SESSIONTOTALIZA] = arrTotal;
			}
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dt = this.ObtenerDatos();

			if(dt!=null)
			{
				DataView dw = dt.DefaultView;
				dw.Sort = columnaOrdenar ;
				dw.RowFilter= Utilitario.Helper.ObtenerFiltro();
				this.Totalizar(dw);
				grid.Columns[Utilitario.Constantes.POSICIONFOOTERTOTAL].FooterText = Utilitario.Constantes.TEXTOFOOTERTOTAL + Utilitario.Constantes.ESPACIO + dw.Count.ToString();
				grid.DataSource = dw;
				grid.CurrentPageIndex =indicePagina;

				lblResultado.Visible = false;

			}
			else
			{
				grid.DataSource = dt;
				lblResultado.Visible = true;
				lblResultado.Text = GRILLAVACIA;
			}
			try
			{
				grid.DataBind();
			}
			catch	
			{
				grid.CurrentPageIndex = 0;
				grid.DataBind();
			}
		}

		public void LlenarCombos()
		{
			this.LlenarTipoPresupuestoCuenta();
		}
		private void LlenarTipoPresupuestoCuenta()
		{
			ddldPresupuestoCuenta.DataSource =((CTipoPresupuestoCuenta)new CTipoPresupuestoCuenta()).AdministrarDetalleTiposdePresupuestoCuenta(
																																				Convert.ToInt32(Page.Request.Params[KEYIDTIPOPRESUPUESTO])
																																				,CNetAccessControl.GetIdUser()
																																				,Convert.ToInt32(Page.Request.Params[KEYIDPERIODO])
																																				,Convert.ToInt32(Page.Request.Params[KEYIDMES]));
			ddldPresupuestoCuenta.DataValueField=COLUMNAIDTIPOPTOCTA;
			ddldPresupuestoCuenta.DataTextField=COLUMNADESCRIPCION;
			ddldPresupuestoCuenta.DataBind();

			
			ddldCentroOperativo.DataSource =((CTipoPresupuestoCuenta)new CTipoPresupuestoCuenta()).AdministrarDetalleTiposdePresupuestoCuenta(
																																				Convert.ToInt32(Page.Request.Params[KEYIDTIPOPRESUPUESTO])
																																				,CNetAccessControl.GetIdUser()
																																				,Convert.ToInt32(Page.Request.Params[KEYIDPERIODO])
																																				,Convert.ToInt32(Page.Request.Params[KEYIDMES]));
			ddldCentroOperativo.DataValueField=COLUMNAIDCENTROOPERATIVO;
			ddldCentroOperativo.DataTextField=COLUMNADIGCTA;
			ddldCentroOperativo.DataBind();

			//Seelccionar Item
			if (Session[SESSIONFINPPTOCO] !=  null)
			{
				ddldPresupuestoCuenta.SelectedIndex=Convert.ToInt32(Session[SESSIONFINPPTOCO]);
				ddldCentroOperativo.SelectedIndex=Convert.ToInt32(Session[SESSIONFINPPTOCO]);
			}
			this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Convert.ToInt32(this.hGridPagina.Value));
		}
		public void LlenarDatos()
		{
			this.lblPeriodo.Text = Page.Request.Params[KEYIDPERIODO].ToString();
			this.lblMes.Text = Page.Request.Params[KEYIDNOMBREMES].ToString().ToUpper();
			this.lblTipoPresupuesto.Text = Page.Request.Params[KEYIDNOMBRETIPOPRESUPUESTO].ToString();
		}

		public void LlenarJScript()
		{
			ddldCentroOperativo.Style.Add(Utilitario.Constantes.DISPLAY,Utilitario.Constantes.NONE);
			//this.ibtnAgregar.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado(Utilitario.Constantes.VACIO));
			
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarTipodePresupuestoCuentasGruposCC.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministrarTipodePresupuestoCuentasGruposCC.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarTipodePresupuestoCuentasGruposCC.Exportar implementation
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
			// TODO:  Add AdministrarTipodePresupuestoCuentasGruposCC.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);

				string parametros = KEYIDPRESUPUESTOCUENTA + Utilitario.Constantes.SIGNOIGUAL + this.ddldCentroOperativo.SelectedItem.Text.ToUpper()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYIDNOMBRETIPOPRESUPUESTO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDNOMBRETIPOPRESUPUESTO].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + this.ddldCentroOperativo.SelectedValue.ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYIDPERIODO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDPERIODO].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYIDMES + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDMES].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYIDNOMBREMES + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDNOMBREMES].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYIDGRUPOCC + Utilitario.Constantes.SIGNOIGUAL + dr[COLUMNAIDGRUPOCC].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYIDNOMBREGRUPOCC + Utilitario.Constantes.SIGNOIGUAL + dr[COLUMNANROGRUPOCC].ToString() + Utilitario.Constantes.ESPACIO +  dr[COLUMNANOMBRE].ToString();

				Helper.ConfiguraColumnaHyperLink(e.Item.Cells[0],grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex,
					Helper.HistorialIrAdelantePersonalizado("hGridPaginaSort","hGridPagina"),
					Helper.MostrarVentana(URLPRESUPUESTOCUENTAGRUPOCCMOV,parametros));

				((Label) e.Item.Cells[3].FindControl(LBLPPTO)).Text = Convert.ToDouble( dr[COLUMNAMONTOPTO]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				((Label) e.Item.Cells[3].FindControl(LBLREAL)).Text = Convert.ToDouble( dr[COLUMNAMONTOREAL]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				((Label) e.Item.Cells[3].FindControl(LBLSALDO)).Text = Convert.ToDouble( dr[COLUMNASALDO]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
			}
			if(e.Item.ItemType == ListItemType.Footer)
			{
				e.Item.Cells[0].ColumnSpan=3;
				e.Item.Cells[0].Text = TITULOTOTAL;
				e.Item.Cells[1].Visible = false;
				e.Item.Cells[2].Visible = false;

				ArrayList arrTotal = (ArrayList)Session[SESSIONTOTALIZA];
				((Label) e.Item.Cells[3].FindControl(LBLPPTOF)).Text = Convert.ToDouble(arrTotal[0]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				((Label) e.Item.Cells[3].FindControl(LBLPPTOF)).Font.Bold=true;
				((Label) e.Item.Cells[3].FindControl(LBLPPTOF)).Font.Size=8;
				((Label) e.Item.Cells[3].FindControl(LBLREALF)).Text = Convert.ToDouble(arrTotal[1]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				((Label) e.Item.Cells[3].FindControl(LBLREALF)).Font.Bold=true;
				((Label) e.Item.Cells[3].FindControl(LBLREALF)).Font.Size=8;
				((Label) e.Item.Cells[3].FindControl(LBLSALDOF)).Text = Convert.ToDouble(arrTotal[2]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				((Label) e.Item.Cells[3].FindControl(LBLSALDOF)).Font.Bold=true;
				((Label) e.Item.Cells[3].FindControl(LBLSALDOF)).Font.Size=8;
			}
			Helper.FiltroporSeleccionConfiguraColumna(e,grid,true,CTRLBUSCAR);
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void ddldPresupuestoCuenta_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				Session[SESSIONFINPPTOCO] = ddldPresupuestoCuenta.SelectedIndex;
				ddldCentroOperativo.SelectedIndex = ddldPresupuestoCuenta.SelectedIndex;
			}
			catch(Exception oException)
			{
				string a = oException.Message;
			}
			this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Convert.ToInt32(this.hGridPagina.Value));
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.hGridPagina.Value=e.NewPageIndex.ToString();
			grid.CurrentPageIndex=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);	

		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			hGridPaginaSort.Value=Helper.GenerarExpresionOrdenamiento(e.SortExpression);
			this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Helper.ObtenerIndicePagina());		
		}

		private void ibtnEliminaFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}

		private void ibtnAgregar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			
		}
	}
}
