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
	/// Summary description for ConsultarRelaciondeFacturasPorPagar.
	/// </summary>
	public class ConsultarRelaciondeFacturasPorPagar : System.Web.UI.Page,IPaginaBase
	{
		#region Controles
			protected System.Web.UI.WebControls.Label lblRutaPagina;
			protected System.Web.UI.WebControls.Label lblPagina;
			protected System.Web.UI.WebControls.Label lblResultado;
			protected projDataGridWeb.DataGridWeb grid;
			protected System.Web.UI.WebControls.Literal ltlMensaje;
			protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;
			protected System.Web.UI.WebControls.ImageButton ibtnEliminaFiltro;
			protected System.Web.UI.WebControls.Label Label2;
			protected System.Web.UI.HtmlControls.HtmlImage ibtnFiltrarSeleccion;
			protected System.Web.UI.WebControls.TextBox txtTCVenta;
			protected System.Web.UI.WebControls.Label Label5;
			protected System.Web.UI.WebControls.Button btnActualizar;

		#endregion
		#region Constantes	
			const string PERIODO="Periodo";
			const string MES="Mes";
			const string DIGCTA = "DigCta";
			const string NOMBRECUENTA = "NombreCta";
			const string IDCENTROOPERATIVO = "idCentro";
			const string DATOSPROVEEDOR = "dtProv";
			const string TIPOCAMBIO = "tc";
			const string IDTIPORECURSO = "idTipRecurso";
			/*DEFINICION DE LAS COLUMNAS DE DATOS*/
			const string IDPROVEEDOR = "idPrv";
			const string RUCPROVEEDOR = "NroProveedor";
			const string RAZONSOCIAL= "RazonSocial";
			const string NROFACTURAS = "CantFacturas";
			const string CUENTACONTABLE = "Cuentacontable";
		
			const string FACTxPAGAR_LOC = "42101";
			const string FACTxRECIBIROC_LOC = "42102";
			const string FACTXRECIBIROS_LOC = "42103";
			const string FACTxPAGAR_IMP = "42105";
			const string FACTxRECIBIR_IMP = "42106";

			const string DIG_LETxPAGAR = "423";

			const string VARIABLETOTALIZA ="Totaliza";

		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPaginaSort;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label lblConcepto;
		protected System.Web.UI.WebControls.Label lblFecha;
			/*Pagina de Refernecia*/
			const string URLPAGINADETALLE = "ConsultarRelaciondeOrdenesdeCompraPorProveedor.aspx?";
		#endregion


		#region Variables
			
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
			this.ibtnFiltrar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnFiltrar_Click);
			this.ibtnEliminaFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminaFiltro_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add ConsultarRelaciondeFacturasPorPagar.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarRelaciondeFacturasPorPagar.LlenarGrillaOrdenamiento implementation
		}
		private DataTable ObtenerDatos()
		{
			return ((CCuentasporPagar) new CCuentasporPagar()).ConsultarRelaciondeProveedoresFacturasporPagarContabilizada(
																												Convert.ToInt32(Page.Request.Params[IDCENTROOPERATIVO])
																												,Page.Request.Params[DIGCTA].ToString() );
		}
		private void Totalizar(DataTable dtOrigen)
		{
			if (dtOrigen !=null)
			{
				ArrayList arrTotal = new ArrayList();
				arrTotal.Add(Helper.TotalizarDataView(dtOrigen.DefaultView,Enumerados.FINColumnaProveedorFacturasporPagar.CantFacturas.ToString())[0]);
				arrTotal.Add(Helper.TotalizarDataView(dtOrigen.DefaultView,Enumerados.FINColumnaProveedorFacturasporPagar.MontoPorPagar.ToString())[0]);
				arrTotal.Add(Helper.TotalizarDataView(dtOrigen.DefaultView,Enumerados.FINColumnaProveedorFacturasporPagar.MontoOCLocalporRecibir.ToString())[0]);
				arrTotal.Add(Helper.TotalizarDataView(dtOrigen.DefaultView,Enumerados.FINColumnaProveedorFacturasporPagar.MontoOSLocalporRecibir.ToString())[0]);
				arrTotal.Add(Helper.TotalizarDataView(dtOrigen.DefaultView,Enumerados.FINColumnaProveedorFacturasporPagar.MontoOCExteriorpoPagar.ToString())[0]);
				arrTotal.Add(Helper.TotalizarDataView(dtOrigen.DefaultView,Enumerados.FINColumnaProveedorFacturasporPagar.MontoOCExteriorporRecibir.ToString())[0]);
				arrTotal.Add(Helper.TotalizarDataView(dtOrigen.DefaultView,Enumerados.FINColumnaProveedorFacturasporPagar.MontoTotalporPagar.ToString())[0]);
				arrTotal.Add(Helper.TotalizarDataView(dtOrigen.DefaultView,Enumerados.FINColumnaProveedorFacturasporPagar.MontoLetrasxPagar.ToString())[0]);
				
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
		}

		public void LlenarDatos()
		{
			txtTCVenta.Text = Page.Request.Params[TIPOCAMBIO].ToString();
			this.lblFecha.Text = "Al DIA:" + DateTime.Now.ToShortDateString();
			this.lblConcepto.Text = Page.Request.Params[NOMBRECUENTA].ToString();
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarRelaciondeFacturasPorPagar.LlenarJScript implementation
			bool Visible;

			Visible  = (Page.Request.Params[DIGCTA].ToString() == DIG_LETxPAGAR)? false:true;
			for(int i=3;i<=8;i++)
			{
				grid.Columns[i].Visible = Visible;
			}
			grid.Columns[9].Visible = !grid.Columns[8].Visible;

		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarRelaciondeFacturasPorPagar.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarRelaciondeFacturasPorPagar.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarRelaciondeFacturasPorPagar.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add ConsultarRelaciondeFacturasPorPagar.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ConsultarRelaciondeFacturasPorPagar.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.Header)
			{
				e.Item.Cells[3].ToolTip = "Facturas por pagar (42101)";
				e.Item.Cells[4].ToolTip = "Facturas por recibir orden de compra (42102)";
				e.Item.Cells[5].ToolTip = "Facturas por recibir orden de servicio (42103)";
				e.Item.Cells[6].ToolTip = "Facturas por pagar mercado exterior (42105)";
				e.Item.Cells[7].ToolTip = "Facturas por recibir mercado exterior (42106)";
				e.Item.Cells[9].ToolTip = "Letras por pagar (42301)";
			}
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				Helper.FiltroporSeleccionConfiguraColumna(e,grid,true,"txtBuscar");

				e.Item.Cells[1].ToolTip = "RUC :" + dr["NroProveedor"].ToString();


				/*Enlaza los evento de detalle por columna*/

				
				string Parametros  = IDCENTROOPERATIVO  + Utilitario.Constantes.SIGNOIGUAL +  Page.Request.Params[IDCENTROOPERATIVO].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ NOMBRECUENTA + Utilitario.Constantes.SIGNOIGUAL +  Page.Request.Params[NOMBRECUENTA].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ IDPROVEEDOR + Utilitario.Constantes.SIGNOIGUAL +  dr["idProveedor"].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ TIPOCAMBIO + Utilitario.Constantes.SIGNOIGUAL +  Page.Request.Params[TIPOCAMBIO].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ RUCPROVEEDOR + Utilitario.Constantes.SIGNOIGUAL + dr["NroProveedor"].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ RAZONSOCIAL + Utilitario.Constantes.SIGNOIGUAL + e.Item.Cells[1].Text
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ CUENTACONTABLE + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[DIGCTA].ToString();
					

				string UrlDetalle = Helper.HistorialIrAdelantePersonalizado("hGridPaginaSort","hGridPagina") + Helper.MostrarVentana(URLPAGINADETALLE,Parametros);
				
				Helper.ConfiguraColumnaHyperLink(e.Item.Cells[0],grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex,UrlDetalle);

				/*Formatea las columnas numericas*/
				e.Item.Cells[3].Text = Convert.ToDouble(e.Item.Cells[3].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[4].Text = Convert.ToDouble(e.Item.Cells[4].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[5].Text = Convert.ToDouble(e.Item.Cells[5].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[6].Text = Convert.ToDouble(e.Item.Cells[6].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[7].Text = Convert.ToDouble(e.Item.Cells[7].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[8].Text = Convert.ToDouble(e.Item.Cells[8].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				/*Letra por pagar*/
				e.Item.Cells[9].Text = Convert.ToDouble(e.Item.Cells[9].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);

				
				
			}
			if(e.Item.ItemType == ListItemType.Footer)
			{
				Utilitario.Helper.FooterSpan(sender,e,0,1,2);

				ArrayList arrTotal = (ArrayList)Session[VARIABLETOTALIZA];
				e.Item.Cells[2].Text = Convert.ToDouble(arrTotal[0]).ToString();
				e.Item.Cells[3].Text = Convert.ToDouble(arrTotal[1]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[4].Text = Convert.ToDouble(arrTotal[2]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[5].Text = Convert.ToDouble(arrTotal[3]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[6].Text = Convert.ToDouble(arrTotal[4]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[7].Text = Convert.ToDouble(arrTotal[5]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[8].Text = Convert.ToDouble(arrTotal[6]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				/*Letra por Pagar*/
				e.Item.Cells[9].Text = Convert.ToDouble(arrTotal[7]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				
				Session[VARIABLETOTALIZA] = null;
			}
		}

		private void ibtnFiltrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			ltlMensaje.Text= Utilitario.Helper.ElaborarFiltro(RUCPROVEEDOR + ";Nro de Ruc"
															,RUCPROVEEDOR + ";Nro de Ruc"
															,RAZONSOCIAL + ";Razon social"
															,NROFACTURAS + ";Cantidad de facturas"
															,"MontoTotalporPagar" + ";Monto total");
			



		}

		private void ibtnEliminaFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.hGridPagina.Value = e.NewPageIndex.ToString();
			this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Convert.ToInt32(this.hGridPagina.Value));
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.hGridPaginaSort.Value = Helper.GenerarExpresionOrdenamiento(e.SortExpression);
			this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Convert.ToInt32(this.hGridPagina.Value));
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void btnActualizar_Click(object sender, System.EventArgs e)
		{
			if (Helper.IsNumeric(this.txtTCVenta.Text.ToString()))
			{
				ObtenerDatos();
			}
			else
			{
				ltlMensaje.Text =Helper.MensajeAlert("No se ha ingresado un tipo de cambio correcto");
			}
		}


	}
}
