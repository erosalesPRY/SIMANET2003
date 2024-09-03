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

namespace SIMA.SimaNetWeb.GestionFinanciera.CuentasPorCobrarPagar
{
	/// <summary>
	/// Summary description for ConsultarRelaciondeFacturasPorCobrar.
	/// </summary>
	public class ConsultarRelaciondeFacturasPorCobrar : System.Web.UI.Page,IPaginaBase
	{
		#region Constroles
			protected System.Web.UI.WebControls.Label lblRutaPagina;
			protected System.Web.UI.WebControls.Label lblPagina;
			protected projDataGridWeb.DataGridWeb grid;
			protected System.Web.UI.WebControls.Label Label5;
			protected System.Web.UI.WebControls.TextBox txtTCVenta;
			protected System.Web.UI.WebControls.Label lblResultado;
			protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
			protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPaginaSort;
			protected System.Web.UI.WebControls.Literal ltlMensaje;
			protected System.Web.UI.WebControls.Label Label2;
			protected System.Web.UI.HtmlControls.HtmlImage ibtnFiltrarSeleccion;
			protected System.Web.UI.WebControls.Label lblConcepto;
			protected System.Web.UI.WebControls.Label Label4;
			protected System.Web.UI.WebControls.ImageButton ibtnEliminaFiltro;
			protected System.Web.UI.WebControls.TextBox txtBuscar;
		#endregion
		#region Constantes
			const string PERIODO="Periodo";
			const string MES="Mes";
			const string DIGCTA = "DigCta";
			const string NOMBRECUENTA = "NombreCta";
			const string IDCENTROOPERATIVO = "idCentro";
			const string TIPOCAMBIO = "tc";

		/*DATOS DEL CLIENTE*/
			const string IDCLIENTE = "idCliente";
			const string RAZONSOCIAL= "RazonSocial";
		/*URLDetalle*/
			const string URLPAGINADETALLE = "ConsultarRelaciondeFacturasaCobrarPorCliente.aspx?";
		/*Objeto label de la cabecra*/
			const string LBLCN = "lblCN";
			const string LBLRN = "lblRN";
			const string LBLMM = "lblMM";
			const string LBLAE = "lblAE";
			const string LBLRI = "lblRI";
			const string LBLME = "lblMerc";
			const string LBLMS = "lblServ";
			
		/*Controles de la Grilla*/
			const string LBLMONTOCN = "lblMontoCNa";
			const string LBLMONTORN = "lblMontoRNa";
			const string LBLMONTOMM = "lblMontoMMa";
			const string LBLMONTOAE = "lblMontoAEa";
			const string LBLMONTORI = "lblMontoRIa";
			const string LBLMONTOME = "lblMontoMEa";
			const string LBLMONTOMS = "lblMontoMSa";
			const string PREFFOOTHER = "F";
		protected System.Web.UI.WebControls.Label lblFecha;
			const string VARIABLETOTALIZA ="Totaliza";
			const string LINEANEGOCIOCN = "Construcciones Navales";
			const string LINEANEGOCIORN = "Construcciones Navales";
			const string LINEANEGOCIOMM = "Construcciones Navales";
			const string LINEANEGOCIOAE = "Armas Electrónicas";
			const string LINEANEGOCIORI = "Reparación Inductrial";
			const string LINEANEGOCIOMERC = "Mercadería";
		protected System.Web.UI.WebControls.Button ibtnAceptar;
			
			const string LINEANEGOCIOSERV = "Servicio";

		#endregion
		

		private void Page_Load(object sender, System.EventArgs e)
		{
			//this.grid.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(Utilitario.Helper.FooterSpan);
			if(!Page.IsPostBack)
			{
				try
				{
					this.LlenarJScript();
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarDatos();
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionFinanciera",this.ToString(),"Se consultó las Facturas por Pagar.",Enumerados.NivelesErrorLog.I.ToString()));
					Helper.ReestablecerPagina(this);
					this.LlenarGrillaOrdenamientoPaginacion(this.hGridPaginaSort.Value,Convert.ToInt32(this.hGridPagina.Value));
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
			this.ibtnAceptar.Click += new System.EventHandler(this.ibtnAceptar_Click);
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
			// TODO:  Add ConsultarRelaciondeFacturasPorCobrar.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarRelaciondeFacturasPorCobrar.LlenarGrillaOrdenamiento implementation
		}

		private DataTable ObtenerDatos()
		{
			return ((CCuentasporCobrar) new CCuentasporCobrar()).ConsultarResumenporClientedeFacturasporCobrar(
																									Convert.ToInt32(Page.Request.Params[IDCENTROOPERATIVO])
																									,Page.Request.Params[DIGCTA].ToString()
																									,txtBuscar.Text);
		}
		private void Totalizar(DataTable dtOrigen)
		{
			if (dtOrigen !=null)
			{
				ArrayList arrTotal = new ArrayList();
				arrTotal.Add(Helper.TotalizarDataView(dtOrigen.DefaultView,Enumerados.FinColumnaFacturasporCobrar.MontoCN.ToString())[0]);//0
				arrTotal.Add(Helper.TotalizarDataView(dtOrigen.DefaultView,Enumerados.FinColumnaFacturasporCobrar.MontoRN.ToString())[0]);//1
				arrTotal.Add(Helper.TotalizarDataView(dtOrigen.DefaultView,Enumerados.FinColumnaFacturasporCobrar.MontoMM.ToString())[0]);//2
				arrTotal.Add(Helper.TotalizarDataView(dtOrigen.DefaultView,Enumerados.FinColumnaFacturasporCobrar.MontoAE.ToString())[0]);//3
				arrTotal.Add(Helper.TotalizarDataView(dtOrigen.DefaultView,Enumerados.FinColumnaFacturasporCobrar.MontoRI.ToString())[0]);//4
				arrTotal.Add(Helper.TotalizarDataView(dtOrigen.DefaultView,Enumerados.FinColumnaFacturasporCobrar.MontoOME.ToString())[0]);//5
				arrTotal.Add(Helper.TotalizarDataView(dtOrigen.DefaultView,Enumerados.FinColumnaFacturasporCobrar.MontoOMS.ToString())[0]);//6
				arrTotal.Add(Helper.TotalizarDataView(dtOrigen.DefaultView,"MontoTotal")[0]);
				
				Session[VARIABLETOTALIZA] = arrTotal;
			}

		}


		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dt = this.ObtenerDatos();
			this.Totalizar(dt);
			if(dt!=null)
			{
				DataView dw = dt.DefaultView;
				dw.RowFilter = Helper.ObtenerFiltro();
				grid.Columns[Utilitario.Constantes.POSICIONFOOTERTOTAL].FooterText = Utilitario.Constantes.TEXTOFOOTERTOTAL + Utilitario.Constantes.ESPACIO + dw.Count.ToString();
				dw.Sort = columnaOrdenar ;
				grid.DataSource = dt;
				grid.CurrentPageIndex =indicePagina;
			}
			else
			{
				grid.DataSource = null;
				lblResultado.Text = "No existen Documentos por Pagar";
			}
			try
			{
				grid.DataBind();
			}
			catch	
			{
				grid.CurrentPageIndex = 0;
				grid.DataBind();
				Page.DataBind();
			}			
		}

		public void LlenarCombos()
		{
			// TODO:  Add ConsultarRelaciondeFacturasPorCobrar.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			txtTCVenta.Text = Page.Request.Params[TIPOCAMBIO].ToString();
			/*this.lblPeriodo.Text = Page.Request.Params[PERIODO].ToString();
			this.lblMes.Text = Helper.ObtenerNombreMes(Convert.ToInt32(Page.Request.Params[MES].ToString()),Enumerados.TipoDatoMes.NombreCompleto).ToUpper();
			*/
			lblFecha.Text = "AL DIA :" + DateTime.Now.ToShortDateString();
			this.lblConcepto.Text = Page.Request.Params[NOMBRECUENTA].ToString();
		}

		public void LlenarJScript()
		{
			this.ibtnAceptar.Style.Add(Utilitario.Constantes.DISPLAY,Utilitario.Constantes.NONE);
			this.txtBuscar.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,"AsignaEventoKeyDown('ibtnAceptar')");
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarRelaciondeFacturasPorCobrar.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarRelaciondeFacturasPorCobrar.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarRelaciondeFacturasPorCobrar.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add ConsultarRelaciondeFacturasPorCobrar.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ConsultarRelaciondeFacturasPorCobrar.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.Header)
			{
				string pDigCta = Page.Request.Params[DIGCTA].ToString();
				Label lblHeader;
				((Label) e.Item.Cells[2].FindControl(LBLCN)).ToolTip =  LINEANEGOCIOCN + " "  + Utilitario.Constantes.SIGNOABREPARANTESIS + pDigCta + "01" + Utilitario.Constantes.SIGNOCIERRAPARANTESIS ;

				lblHeader = (Label) e.Item.Cells[2].FindControl(LBLCN);
				
				lblHeader.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,"Ordenar('"  + lblHeader.ClientID.ToString() + "','MontoCN')");

				((Label) e.Item.Cells[2].FindControl(LBLRN)).ToolTip =  LINEANEGOCIORN + " " + Utilitario.Constantes.SIGNOABREPARANTESIS + pDigCta + "05," + pDigCta + "10" + Utilitario.Constantes.SIGNOCIERRAPARANTESIS;
				((Label) e.Item.Cells[2].FindControl(LBLMM)).ToolTip =  LINEANEGOCIOMM + " " + Utilitario.Constantes.SIGNOABREPARANTESIS + pDigCta + "15," + pDigCta + "16" + Utilitario.Constantes.SIGNOCIERRAPARANTESIS;
				((Label) e.Item.Cells[2].FindControl(LBLAE)).ToolTip =  LINEANEGOCIOAE + " " + Utilitario.Constantes.SIGNOABREPARANTESIS + pDigCta + "30" + Utilitario.Constantes.SIGNOCIERRAPARANTESIS;
				((Label) e.Item.Cells[2].FindControl(LBLRI)).ToolTip =  LINEANEGOCIORI + " " + Utilitario.Constantes.SIGNOABREPARANTESIS + pDigCta + "20" + Utilitario.Constantes.SIGNOCIERRAPARANTESIS;
				((Label) e.Item.Cells[3].FindControl(LBLME)).ToolTip =  LINEANEGOCIOMERC + " " + Utilitario.Constantes.SIGNOABREPARANTESIS + pDigCta + "35" + Utilitario.Constantes.SIGNOCIERRAPARANTESIS;
				((Label) e.Item.Cells[3].FindControl(LBLMS)).ToolTip =  LINEANEGOCIOSERV + " " + Utilitario.Constantes.SIGNOABREPARANTESIS + pDigCta + "40" + Utilitario.Constantes.SIGNOCIERRAPARANTESIS;
			}

			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				/*Oculta aquellos datos que fueron repuesto y que ya no deberan de ser cobrados*/
				//e.Item.Style.Add("display", (Convert.ToDouble(e.Item.Cells[4].Text) <=0)? "none":"block");

				string Parametros  = IDCENTROOPERATIVO  + Utilitario.Constantes.SIGNOIGUAL +  Page.Request.Params[IDCENTROOPERATIVO].ToString()
														+ Utilitario.Constantes.SIGNOAMPERSON
														+ PERIODO + Utilitario.Constantes.SIGNOIGUAL +  Page.Request.Params[PERIODO].ToString()
														+ Utilitario.Constantes.SIGNOAMPERSON
														+ MES + Utilitario.Constantes.SIGNOIGUAL +  Page.Request.Params[MES].ToString()
														+ Utilitario.Constantes.SIGNOAMPERSON
														+ NOMBRECUENTA + Utilitario.Constantes.SIGNOIGUAL +  Page.Request.Params[NOMBRECUENTA].ToString()
														+ Utilitario.Constantes.SIGNOAMPERSON
														+ TIPOCAMBIO + Utilitario.Constantes.SIGNOIGUAL +  Page.Request.Params[TIPOCAMBIO].ToString()
														+ Utilitario.Constantes.SIGNOAMPERSON
														+ IDCLIENTE + Utilitario.Constantes.SIGNOIGUAL +  dr[Enumerados.FinColumnaFacturasporCobrar.idCliente.ToString()].ToString()
														+ Utilitario.Constantes.SIGNOAMPERSON
														+ RAZONSOCIAL + Utilitario.Constantes.SIGNOIGUAL + e.Item.Cells[1].Text
														+ Utilitario.Constantes.SIGNOAMPERSON
														+ DIGCTA + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[DIGCTA].ToString();

				Helper.ConfiguraColumnaHyperLink(e.Item.Cells[0],grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex,Helper.HistorialIrAdelantePersonalizado("hGridPaginaSort","hGridPagina"),Helper.MostrarVentana(URLPAGINADETALLE,Parametros));
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				Helper.FiltroporSeleccionConfiguraColumna(e,grid,false,"txtBuscar");

				((Label) e.Item.Cells[2].FindControl(LBLMONTOCN)).Text = Convert.ToDouble(dr[Enumerados.FinColumnaFacturasporCobrar.MontoCN.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				((Label) e.Item.Cells[2].FindControl(LBLMONTORN)).Text = Convert.ToDouble(dr[Enumerados.FinColumnaFacturasporCobrar.MontoRN.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				((Label) e.Item.Cells[2].FindControl(LBLMONTOMM)).Text = Convert.ToDouble(dr[Enumerados.FinColumnaFacturasporCobrar.MontoMM.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				((Label) e.Item.Cells[2].FindControl(LBLMONTOAE)).Text = Convert.ToDouble(dr[Enumerados.FinColumnaFacturasporCobrar.MontoAE.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				((Label) e.Item.Cells[2].FindControl(LBLMONTORI)).Text = Convert.ToDouble(dr[Enumerados.FinColumnaFacturasporCobrar.MontoRI.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

				((Label) e.Item.Cells[3].FindControl(LBLMONTOME)).Text = Convert.ToDouble(dr[Enumerados.FinColumnaFacturasporCobrar.MontoOME.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				((Label) e.Item.Cells[3].FindControl(LBLMONTOMS)).Text = Convert.ToDouble(dr[Enumerados.FinColumnaFacturasporCobrar.MontoOMS.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				
				e.Item.Cells[4].Text = Convert.ToDouble(e.Item.Cells[4].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				
			}
			if(e.Item.ItemType == ListItemType.Footer)
			{
				Utilitario.Helper.FooterSpan(sender,e,0,1,2);

				ArrayList arrTotal = (ArrayList)Session[VARIABLETOTALIZA];

				((Label) e.Item.Cells[2].FindControl(LBLMONTOCN+PREFFOOTHER)).Text = Convert.ToDouble(arrTotal[0]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				((Label) e.Item.Cells[2].FindControl(LBLMONTORN+PREFFOOTHER)).Text = Convert.ToDouble(arrTotal[1]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				((Label) e.Item.Cells[2].FindControl(LBLMONTOMM+PREFFOOTHER)).Text = Convert.ToDouble(arrTotal[2]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				((Label) e.Item.Cells[2].FindControl(LBLMONTOAE+PREFFOOTHER)).Text = Convert.ToDouble(arrTotal[3]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				((Label) e.Item.Cells[2].FindControl(LBLMONTORI+PREFFOOTHER)).Text = Convert.ToDouble(arrTotal[4]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

				((Label) e.Item.Cells[3].FindControl(LBLMONTOME+PREFFOOTHER)).Text = Convert.ToDouble(arrTotal[5]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				((Label) e.Item.Cells[3].FindControl(LBLMONTOMS+PREFFOOTHER)).Text = Convert.ToDouble(arrTotal[6]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

				e.Item.Cells[4].Text = Convert.ToDouble(arrTotal[7]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

				Session[VARIABLETOTALIZA] = null;
			}

		}

		private void ibtnEliminaFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.hGridPaginaSort.Value = Helper.GenerarExpresionOrdenamiento(e.SortExpression);
			this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Convert.ToInt32(this.hGridPagina.Value));
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.hGridPagina.Value = e.NewPageIndex.ToString();
			this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Convert.ToInt32(this.hGridPagina.Value));		
		}

		private void ibtnAceptar_Click(object sender, System.EventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(this.hGridPaginaSort.Value,Convert.ToInt32(this.hGridPagina.Value));
		}
	}
}
