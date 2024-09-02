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


namespace SIMA.SimaNetWeb.GestionFinanciera.CuentasBancarias
{
	/// <summary>
	/// Summary description for ConsultarSaldodeCuentaBancariaporCentroDetalle.
	/// </summary>
	public class ConsultarSaldodeCuentaBancariaporCentroDetalle : System.Web.UI.Page,IPaginaBase
	{
		#region Constantes
		//const int IDTABLAESTADOCARTAFIANZA=5;
		const string GRILLAVACIA ="No existe ningún Registro.";  
		const string CONTROLINK="hlkBanco";
		const string KEYIDCENTRO = "idCentro";
		const string KEYIDFECHA= "Fecha";
		const string NOMBRECENTRO = "Nombre";
		
		
		const string URLPRINCIPAL="ConsultarSaldodeCuentaBancariaporCentro.aspx";
		const string COLORDENAMIENTO = "razonsocial";
		const string CAMPO1 = "lblMontoSaldo";

		//Otros
		const string ETIQUETAFECHA ="FECHA : ";
		const string ETIQUETACENTROOPERATIVO ="CENTRO OPERATIVO :";

		//Filtro
		const string BANCO = "razonsocial";
		const string CTABANCARIA ="nrocuentabancaria";
		const string MONEDA ="Moneda";

		//Columnas Grilla
		const string SALDO ="Saldo";

		#endregion

		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblFecha;
		protected System.Web.UI.WebControls.Label LblCentro;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminaFiltro;
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label Label1;
		protected projDataGridWeb.DataGridWeb gridResumen;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					this.LlenarJScript();
					Helper.ReiniciarSession();
					this.LlenarDatos();
					this.LlenarCombos();
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Auditoria",this.ToString(),"Se consultó las Acciones Correctivas.",Enumerados.NivelesErrorLog.I.ToString()));
					this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO),Utilitario.Constantes.INDICEPAGINADEFAULT);
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
					SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Utilitario.Constantes.CODIGOERRORGENERICO,oException.Message);
					Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
				}
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
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.gridResumen.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.gridResumen_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarSaldodeCuentaBancariaporCentroDetalle.LlenarGrillaOrdenamiento implementation
		}
		private DataTable ObtenerDatos()
		{
			CCuentaBancariaSaldo oCCuentaBancariaSaldo = new CCuentaBancariaSaldo();
			//return oCCuentaBancariaSaldo.ConsultarDetalledeSaldosdeCuentasBancariasporCentro(Page.Request.Params[KEYIDCENTRO].ToString(),Page.Request.Params[KEYIDFECHA].ToString());
			return oCCuentaBancariaSaldo.ConsultarDetalledeSaldosdeCuentasBancariasporCentro(Convert.ToInt32(Page.Request.Params[KEYIDCENTRO]),Convert.ToDateTime(Page.Request.Params[KEYIDFECHA]));
		}
		private void GenerarResumen(DataView dv)
		{
			if (dv!=null)
			{
				int NroResumen = 30;
				DataTable dtFinal= Helper.Resumen(((CResumenItem)new CResumenItem()).ObtenerConfiDataResumen(NroResumen),dv);
				gridResumen.DataSource =dtFinal;
				
			}
			else
			{
				gridResumen.DataSource =dv;
			}
			gridResumen.DataBind();
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dtGeneral =this.ObtenerDatos();
			if(dtGeneral!=null)
			{
				DataView dwGeneral = dtGeneral.DefaultView;
				dwGeneral.Sort = columnaOrdenar ;
				grid.DataSource = dwGeneral;
				this.GenerarResumen(dwGeneral);

				CImpresion oCImpresion = new CImpresion();
				oCImpresion.GuardarDataImprimirExportar(dtGeneral,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGOTITULOREPORTEACCIONCONTROLNOPROGRAMADA),columnaOrdenar,indicePagina);
				ibtnImprimir.Visible = true;
				lblResultado.Visible = false;

			}
			else
			{
				grid.DataSource = dtGeneral;
				lblResultado.Visible = true;
				lblResultado.Text = GRILLAVACIA;
				ibtnImprimir.Visible = false;
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
			// TODO:  Add ConsultarSaldodeCuentaBancariaporCentroDetalle.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add ConsultarSaldodeCuentaBancariaporCentroDetalle.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			this.lblFecha.Text=ETIQUETAFECHA + Page.Request.Params[KEYIDFECHA].ToString().Replace(Utilitario.Constantes.SEPARADORFECHA,Utilitario.Constantes.LINEA);
			this.LblCentro.Text = ETIQUETACENTROOPERATIVO + Page.Request.Params[NOMBRECENTRO].ToString();
			// TODO:  Add ConsultarSaldodeCuentaBancariaporCentroDetalle.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarSaldodeCuentaBancariaporCentroDetalle.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarSaldodeCuentaBancariaporCentroDetalle.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarSaldodeCuentaBancariaporCentroDetalle.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarSaldodeCuentaBancariaporCentroDetalle.Exportar implementation
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
			// TODO:  Add ConsultarSaldodeCuentaBancariaporCentroDetalle.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{				
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				Helper.ConfiguraColumnaHyperLink(e.Item.Cells[0],grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				e.Item.Cells[4].Text = Convert.ToDouble(e.Item.Cells[4].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[4].Text =Helper.FormateaNumeroNegativo(4,e.Item);
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
			}		

		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
		private void ibtnFiltar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			ltlMensaje.Text = Helper.ElaborarFiltro(this.ObtenerDatos(),BANCO + ";Banco"
																		,CTABANCARIA + ";Cuenta Bancaria"
																		,Utilitario.Constantes.SIGNOASTERISCO + MONEDA + ";Moneda");
		}

		private void ibtnEliminaFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(e.SortExpression),Helper.ObtenerIndicePagina());
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			grid.CurrentPageIndex=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);		
		}
		private void gridResumen_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				Label lbl;
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				lbl = (Label) e.Item.Cells[1].FindControl("lblMontoSaldo");
				lbl.Text =  Convert.ToDouble(dr[SALDO]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				lbl.Text =Helper.FormateaNumeroNegativo(lbl.Text,lbl);
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
			}				
		}
	}
}
