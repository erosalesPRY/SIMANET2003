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
	/// Summary description for ConsultarRelaciondeOrdenesdeCompraPorProveedor.
	/// </summary>
	public class ConsultarRelaciondeOrdenesdeCompraPorProveedor : System.Web.UI.Page,IPaginaBase
	{
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPaginaSort;
		protected System.Web.UI.WebControls.Literal ltlMensaje;


		#region Constantes	
			const string PERIODO="Periodo";
			const string MES="Mes";
			const string DIGCTA = "DigCta";
			const string NOMBRECUENTA = "NombreCta";
			const string IDCENTROOPERATIVO = "idCentro";
			const string DATOSPROVEEDOR = "dtProv";
			const string IDPROVEEDOR = "idPrv";
			const string TIPOCAMBIO = "tc";
			const string IDTIPORECURSO = "idTipRecurso";
		
			const string CUENTACONTABLE = "Cuentacontable";

			/*DEFINICION DE LAS COLUMNAS DE DATOS*/
			const string RUCPROVEEDOR = "NroProveedor";
			const string RAZONSOCIAL = "RazonSocial";
			const string NROFACTURAS = "CantFacturas";
			const string MONTOMATERIALES ="MontoMateriales";
			const string MONTOSERVICIO ="MontoServicios";
			const string VARIABLETOTALIZA ="Totaliza";

		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label lblProveedor;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label lblConcepto;
		protected System.Web.UI.WebControls.Label lblFecha;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminaFiltro;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnFiltrarSeleccion;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label lblRUC;
			const string MONTOOTROS="MontoOtros";
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add ConsultarRelaciondeOrdenesdeCompraPorProveedor.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarRelaciondeOrdenesdeCompraPorProveedor.LlenarGrillaOrdenamiento implementation
		}
		private DataTable ObtenerDatos()
		{
			/*FINuspNTADConsultarRelacionOrdenesdeCompraOServicioPorProveedorContabilidadAnalitica*/
			return ((CCuentasporPagar) new CCuentasporPagar()).ConsultarRelacionOrdendeCompraOdeServicioporProveedor(Convert.ToInt32(Page.Request.Params[IDCENTROOPERATIVO])
																													,Convert.ToInt32(Page.Request.Params[IDPROVEEDOR])
																													,Page.Request.Params[CUENTACONTABLE].ToString());
		}

		private void Totalizar(DataTable dtOrigen)
		{
			if (dtOrigen !=null)
			{
				ArrayList arrTotal = new ArrayList();
				arrTotal.Add(Helper.TotalizarDataView(dtOrigen.DefaultView,"TotalEnSoles")[0]);
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
			// TODO:  Add ConsultarRelaciondeOrdenesdeCompraPorProveedor.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			lblFecha.Text ="AL DIA :"  + DateTime.Now.AddDays(-1).ToShortDateString();
			this.lblConcepto.Text = Page.Request.Params[NOMBRECUENTA].ToString();
			this.lblProveedor.Text = Page.Request.Params[RAZONSOCIAL].ToString();
			this.lblRUC.Text = Page.Request.Params[RUCPROVEEDOR].ToString();
			
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarRelaciondeOrdenesdeCompraPorProveedor.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarRelaciondeOrdenesdeCompraPorProveedor.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarRelaciondeOrdenesdeCompraPorProveedor.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarRelaciondeOrdenesdeCompraPorProveedor.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add ConsultarRelaciondeOrdenesdeCompraPorProveedor.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ConsultarRelaciondeOrdenesdeCompraPorProveedor.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				Helper.FiltroporSeleccionConfiguraColumna(e,grid,false);
				Helper.ConfiguraColumnaHyperLink(e.Item.Cells[0],grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				e.Item.Cells[5].Text = Convert.ToDouble(e.Item.Cells[5].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				if (dr["FechaEmision"].ToString().Length==0)
				{
					DataTable dt = ObtenerDatosDetalleRegsitroConsolidado(e.Item.Cells[1].Text);
					foreach(DataRow drDet in dt.Rows)
					{
						e.Item.Cells[2].Controls.Add(CrearTablaDetalleCol(drDet["FechaAsto"].ToString(),"center"));
						e.Item.Cells[3].Controls.Add(CrearTablaDetalleCol(drDet["SubDiario"].ToString(),"right"));
						e.Item.Cells[4].Controls.Add(CrearTablaDetalle(drDet["Descripcion"].ToString(),drDet["SaldoSoles"].ToString()));
					}
				}
			}
			if(e.Item.ItemType == ListItemType.Footer)
			{
				Utilitario.Helper.FooterSpan(sender,e,0,4,5);
				ArrayList arrTotal = (ArrayList)Session[VARIABLETOTALIZA];
				e.Item.Cells[5].Text = Convert.ToDouble(arrTotal[0]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				Session[VARIABLETOTALIZA] = null;
			}

		}
		private HtmlTable CrearTablaDetalle(string Descripcion,string Monto)
		{
			HtmlTable oHtmlTable = new HtmlTable();
			oHtmlTable.Border=0;
			oHtmlTable.Width = "100%";
			HtmlTableRow oHtmlTableRow = new HtmlTableRow();
			HtmlTableCell oHtmlTableCell;
				oHtmlTableCell = new HtmlTableCell();
				oHtmlTableCell.InnerText = Descripcion;
				oHtmlTableCell.Style.Add("Width","50%");
				oHtmlTableCell.Attributes.Add("class","ItemgrillaSincolor");
				oHtmlTableRow.Cells.Add(oHtmlTableCell);
				

				oHtmlTableCell = new HtmlTableCell();
				oHtmlTableCell.InnerText = Monto;
				oHtmlTableCell.Style.Add("Width","25%");
				oHtmlTableCell.Align = "right";
				oHtmlTableCell.Attributes.Add("class","ItemgrillaSincolor");
				oHtmlTableRow.Cells.Add(oHtmlTableCell);


				oHtmlTableCell = new HtmlTableCell();
				oHtmlTableCell.InnerText = "   ";
				oHtmlTableCell.Style.Add("Width","25%");
				oHtmlTableCell.Align = "right";
				oHtmlTableCell.Attributes.Add("class","ItemgrillaSincolor");
				oHtmlTableRow.Cells.Add(oHtmlTableCell);
			
			oHtmlTable.Attributes.Add("style","BORDER-BOTTOM: #999999 1px solid");
			oHtmlTable.Rows.Add(oHtmlTableRow);

			return oHtmlTable;
		}

		private HtmlTable CrearTablaDetalleCol(string strValor,string Alineacion)
		{
			HtmlTable oHtmlTable = new HtmlTable();
			oHtmlTable.Border=0;
			oHtmlTable.CellSpacing=0;
			oHtmlTable.CellPadding=0;
			oHtmlTable.Width = "100%";
			HtmlTableRow oHtmlTableRow = new HtmlTableRow();
			HtmlTableCell oHtmlTableCell;
			oHtmlTableCell = new HtmlTableCell();
			oHtmlTableCell.InnerText = strValor;
			oHtmlTableCell.Align = Alineacion;
			
			oHtmlTableCell.Attributes.Add("class","ItemgrillaSincolor");
			oHtmlTableRow.Cells.Add(oHtmlTableCell);
				
			oHtmlTable.Rows.Add(oHtmlTableRow);

			return oHtmlTable;
		}

		private DataTable ObtenerDatosDetalleRegsitroConsolidado(string NroDocumentoAnalitico)
		{
			/*FINuspNTADConsultarRelacionOrdenesdeCompraOServicioPorProveedorContabilidadAnalitica*/
			return ((CCuentasporPagar) new CCuentasporPagar()).ObtenerDetalledeRegistroConsolidadoCuentasAnaliticas(
																Convert.ToInt32(Page.Request.Params[IDCENTROOPERATIVO])
																,Convert.ToInt32(Page.Request.Params[IDPROVEEDOR])
																,Page.Request.Params[CUENTACONTABLE].ToString()
																,NroDocumentoAnalitico);
		}



		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
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

		private void ibtnFiltrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			ltlMensaje.Text= Utilitario.Helper.ElaborarFiltro("Num_Doc_Ana; Nro documento"
															,"Num_Doc_Ana; Nro documento"
															,"FechaEmision;Fecha de Emision"
															,"Descripcion;Descripcion"
															,"TotalEnSoles;Monto a pagar"
																			);
			
		
		}

		private void ibtnEliminaFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}

	}
}
