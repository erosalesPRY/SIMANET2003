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
	/// Summary description for ExportarDetalleExcelCtasCobrarDiversasOtros.
	/// </summary>
	public class ExportarDetalleExcelCtasCobrarDiversasOtros : System.Web.UI.Page,IPaginaBase
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

		//Otros
		const string GRILLAVACIA ="No existen Cuentas por Cobrar de Otras Cuentas Diversas - Otros";  
		
		#endregion
		#region Variables
		double TotImporte;
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
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
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
			// TODO:  Add ExportarDetalleExcelCtasCobrarDiversasOtros.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add ExportarDetalleExcelCtasCobrarDiversasOtros.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add ExportarDetalleExcelCtasCobrarDiversasOtros.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add ExportarDetalleExcelCtasCobrarDiversasOtros.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add ExportarDetalleExcelCtasCobrarDiversasOtros.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ExportarDetalleExcelCtasCobrarDiversasOtros.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ExportarDetalleExcelCtasCobrarDiversasOtros.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ExportarDetalleExcelCtasCobrarDiversasOtros.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add ExportarDetalleExcelCtasCobrarDiversasOtros.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ExportarDetalleExcelCtasCobrarDiversasOtros.ValidarFiltros implementation
			return false;
		}

		#endregion
		private void Totalizar(DataView dwTotales)
		{
			if (dwTotales !=null)
			{
				double[] aArreglo = Helper.TotalizarDataView(dwTotales,Enumerados.FINColumnaCuentaporCobrarDiversasOtros.Importe.ToString());
				TotImporte = aArreglo[0];

				aArreglo = Helper.TotalizarDataView(dwTotales,Enumerados.FINColumnaCuentaporCobrarDiversasOtros.Saldo.ToString());
				TotSaldo = aArreglo[0];

			}
		}

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
				e.Item.Cells[5].Text = TotSaldo.ToString(Constantes.FORMATODECIMAL4);
			}		
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void ibtnAbrir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.GenerarExcelCompleto(this,grid);
		}
	}
}
