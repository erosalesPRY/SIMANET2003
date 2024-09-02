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
using NetAccessControl;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using SIMA.Controladoras.GestionFinanciera;
using SIMA.Controladoras.General;
using NullableTypes;

namespace SIMA.SimaNetWeb.GestionFinanciera.CuentasPorCobrarPagar.Directorio
{
	/// <summary>
	/// Summary description for ExportarDetalleExcel.
	/// </summary>
	public class ExportarDetalleExcel : System.Web.UI.Page,IPaginaBase
	{
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.ImageButton ibtnAbrir;
		const string CONTROLTEXTO="txtDescripcion";
		const string NRORUC="Ruc. : ";
		NullableDouble acumCantidadTotal;
		const string KEYQDESCRIPCION = "Descripcion";
		const string KEYQIDTIPOCUENTA = "IdTipoCuenta";
		const string CUENTAPORCOBRAR="0";
		const string KEYQIDSUBCUENTAPORCOBRARPAGAR = "IdSubCuenta";
		const int IDANTICIPOPROVEEDOR = 3;
		const string PROVEEDOR="PROVEEDOR";  
		const string CLIENTE ="CLIENTE";
	
		const string GRILLAVACIA ="No existe ninguna SubCuenta";  
		const string KEYQIDLETRACAMBIO = "IdLetraCambio";
		const string KEYQFLAGDIRECTORIO= "FlagDirectorio";
		protected System.Web.UI.WebControls.Literal ltlMensaje;

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					

					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"CuentasPorPagar",this.ToString(),"Se consultó la Cuentas Por Pagar",Enumerados.NivelesErrorLog.I.ToString()));
										
					this.LlenarGrilla();
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
			this.ibtnAbrir.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAbrir_Click);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			if(Page.Request.QueryString[KEYQIDTIPOCUENTA] == CUENTAPORCOBRAR)
			{
				grid.Columns[1].HeaderText = Convert.ToInt32(Page.Request.Params[KEYQIDSUBCUENTAPORCOBRARPAGAR])==IDANTICIPOPROVEEDOR? PROVEEDOR:CLIENTE;
			}
			else
			{grid.Columns[1].HeaderText = PROVEEDOR;}

			if(Page.Request.QueryString[KEYQIDLETRACAMBIO] != null)
			{
				grid.Columns[2].HeaderText = "NRO. LETRA";
				grid.Columns[3].HeaderText = "FECHA GIRO";
				grid.Columns[5].Visible =true;
			}

			if(((DataTable)Session["EXPORTAREXCEL"])!=null)
			{
				this.Totalizar(((DataTable)Session["EXPORTAREXCEL"]).DefaultView);				
				grid.DataSource=((DataTable)Session["EXPORTAREXCEL"]);
				grid.Columns[0].FooterText=((DataTable)Session["EXPORTAREXCEL"]).Rows.Count.ToString();
				grid.DataBind();

			}
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ExportarDetalleExcel.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add ExportarDetalleExcel.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add ExportarDetalleExcel.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add ExportarDetalleExcel.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add ExportarDetalleExcel.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ExportarDetalleExcel.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ExportarDetalleExcel.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ExportarDetalleExcel.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add ExportarDetalleExcel.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ExportarDetalleExcel.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void ibtnAbrir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.GenerarExcelCompleto(this,grid);
		}

		
		private void Totalizar(DataView dwTotales)
		{
			if (dwTotales !=null)
			{
				CFuncionesEspeciales oCFuncionesEspeciales=new CFuncionesEspeciales();
				acumCantidadTotal = NullableDouble.Parse(oCFuncionesEspeciales.CalcularMontosTotalesDataFile(dwTotales,Enumerados.FINColumnaResumenCuentasPorPagar.TotalEnSoles.ToString()));
			}
		}
		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				e.Item.Cells[Utilitario.Constantes.POSICIONCONTADOR].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				e.Item.ToolTip = dr[Enumerados.FINColumnaResumenCuentasPorPagar.NroRuc.ToString()].ToString();

				TextBox txt=(TextBox)e.Item.Cells[6].FindControl(CONTROLTEXTO);	
				txt.Text = NRORUC + dr[Enumerados.FINColumnaResumenCuentasPorPagar.Descripcion.ToString()].ToString();

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
			}
			if(e.Item.ItemType == ListItemType.Footer)
			{
				double monto = NullableIsNull.IsNullDouble(acumCantidadTotal,Utilitario.Constantes.POSICIONINDEXCERO);
				e.Item.Cells[4].Text = monto.ToString(Utilitario.Constantes.FORMATODECIMAL4);
			}		
		}
	}
}
