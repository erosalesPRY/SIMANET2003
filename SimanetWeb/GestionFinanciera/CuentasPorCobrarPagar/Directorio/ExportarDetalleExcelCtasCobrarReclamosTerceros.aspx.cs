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

namespace SIMA.SimaNetWeb.GestionFinanciera.CuentasPorCobrarPagar.Directorio
{
	/// <summary>
	/// Summary description for ExportarDetalleExcelCtasCobrarReclamosTerceros.
	/// </summary>
	public class ExportarDetalleExcelCtasCobrarReclamosTerceros : System.Web.UI.Page,IPaginaBase
	{
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.ImageButton ibtnAbrir;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#region Constantes
		//Key Session y QueryString
		const string KEYQIDTIPOCUENTA = "IdTipoCuenta";
		const string KEYQIDCUENTAPORCOBRARPAGAR = "IdCuenta";
		const string KEYQIDSUBCUENTAPORCOBRARPAGAR = "IdSubCuenta";
		const string KEYQIDCENTROOPERATIVO= "IdCentroOperativo";
		const string KEYQDESCRIPCION = "Descripcion";
		const string KEYQDESCRIPCIONCUENTA = "Cuenta";
		const string KEYQDESCRIPCIONSUBCUENTA = "SubCuenta";
		const string KEYQFLAGDIRECTORIO= "FlagDirectorio";
		const string URLDETALLEXCEL="ExportarDetalleExcelCtasCobrarReclamosTerceros.aspx";
		//Otros
		const string GRILLAVACIA = "No existen Cuentas por Cobrar de Otras Cuentas Diversas - Reclamos a Terceros";  
		
		#endregion
		#region Variables
		double TotImporte;
		double TotAmortizado;
		
		double TotSaldo;
		#endregion
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
		private void Totalizar(DataView dwTotales)
		{
			if (dwTotales !=null)
			{
				double[] aArreglo = Helper.TotalizarDataView(dwTotales,Enumerados.FINColumnaCuentaporCobrarDiversasReclamosaTerceros.Importe.ToString());
				TotImporte = aArreglo[0];

				aArreglo = Helper.TotalizarDataView(dwTotales,Enumerados.FINColumnaCuentaporCobrarDiversasReclamosaTerceros.Amortizado.ToString());
				TotAmortizado = aArreglo[0];

				aArreglo = Helper.TotalizarDataView(dwTotales,Enumerados.FINColumnaCuentaporCobrarDiversasReclamosaTerceros.Saldo.ToString());
				TotSaldo = aArreglo[0];

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

		public void LlenarGrilla()
		{
			if(((DataTable)Session["EXPORTAREXCEL"])!=null)
			{
				this.Totalizar(((DataTable)Session["EXPORTAREXCEL"]).DefaultView);				
				grid.DataSource=((DataTable)Session["EXPORTAREXCEL"]);
				grid.Columns[1].FooterText=((DataTable)Session["EXPORTAREXCEL"]).Rows.Count.ToString();
				this.Totalizar(((DataTable)Session["EXPORTAREXCEL"]).DefaultView);

				grid.DataBind();
				

			}
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ExportarDetalleExcelCtasCobrarReclamosTerceros.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add ExportarDetalleExcelCtasCobrarReclamosTerceros.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add ExportarDetalleExcelCtasCobrarReclamosTerceros.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add ExportarDetalleExcelCtasCobrarReclamosTerceros.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add ExportarDetalleExcelCtasCobrarReclamosTerceros.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ExportarDetalleExcelCtasCobrarReclamosTerceros.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ExportarDetalleExcelCtasCobrarReclamosTerceros.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ExportarDetalleExcelCtasCobrarReclamosTerceros.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add ExportarDetalleExcelCtasCobrarReclamosTerceros.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ExportarDetalleExcelCtasCobrarReclamosTerceros.ValidarFiltros implementation
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
				e.Item.Cells[Constantes.POSICIONCONTADOR].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				Helper.FiltroporSeleccionConfiguraColumna(e,grid);
			}

			if(e.Item.ItemType == ListItemType.Footer)
			{
				e.Item.Cells[4].Text = TotImporte.ToString(Constantes.FORMATODECIMAL4);
				e.Item.Cells[5].Text = TotAmortizado.ToString(Constantes.FORMATODECIMAL4);
				e.Item.Cells[6].Text = TotSaldo.ToString(Constantes.FORMATODECIMAL4);
			}		
		}
	}
}
