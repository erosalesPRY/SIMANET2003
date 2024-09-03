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
using SIMA.Controladoras.GestionFinanciera;
using SIMA.SimaNetWeb.InterfacesIU;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;


namespace SIMA.SimaNetWeb.GestionFinanciera.CuentasPorCobrarPagar
{
	/// <summary>
	/// Summary description for ExportarDetalleExcelCtasPorCobrarJudiciales.
	/// </summary>
	public class ExportarDetalleExcelCtasPorCobrarJudiciales : System.Web.UI.Page,IPaginaBase
	{
		protected System.Web.UI.WebControls.Label lblResultado;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.ImageButton ibtnAbrir;
		protected System.Web.UI.WebControls.Literal ltlMensaje;

		#region constantes
		const string KEYQIDTIPOCUENTA = "IdTipoCuenta";
		const string KEYQIDCUENTAPORCOBRARPAGAR = "IdCuenta";//
		const string KEYQIDSUBCUENTAPORCOBRARPAGAR = "IdSubCuenta";
		const string KEYQIDCENTROOPERATIVO = "IdCentroOperativo";//
		const string KEYQID2 = "Id2";//
		//		const string KEYQDESCRIPCIONTIPOCUENTA = "TipoCuenta";
		//	const string KEYQDESCRIPCION = "TipoCuenta";
		const string KEYQDESCRIPCION = "Descripcion";//
		const string KEYQFLAGDIRECTORIO= "FlagDirectorio";
		const string URLDETALLEXCEL="ExportarDetalleExcelCtasPorCobrarJudiciales.aspx?";
		//const string KEYQDESCRIPCIONSUBCUENTA = "SubCuenta";


		
		double total=0;
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			if(((DataTable)Session["EXPORTAREXCEL"])!=null)
			{
					
				grid.DataSource=((DataTable)Session["EXPORTAREXCEL"]);
				grid.Columns[1].FooterText=((DataTable)Session["EXPORTAREXCEL"]).Rows.Count.ToString();
				foreach(DataRow dr in  ((DataTable)Session["EXPORTAREXCEL"]).Rows)
				{
					total+= Convert.ToDouble(dr["saldo"]);
				}
				grid.Columns[6].FooterText=total.ToString(Utilitario.Constantes.FORMATODECIMAL4);

				grid.DataBind();
				

			}
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ExportarDetalleExcelCtasPorCobrarJudiciales.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add ExportarDetalleExcelCtasPorCobrarJudiciales.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add ExportarDetalleExcelCtasPorCobrarJudiciales.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add ExportarDetalleExcelCtasPorCobrarJudiciales.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add ExportarDetalleExcelCtasPorCobrarJudiciales.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ExportarDetalleExcelCtasPorCobrarJudiciales.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ExportarDetalleExcelCtasPorCobrarJudiciales.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ExportarDetalleExcelCtasPorCobrarJudiciales.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add ExportarDetalleExcelCtasPorCobrarJudiciales.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ExportarDetalleExcelCtasPorCobrarJudiciales.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.Header)
			{
				e.Item.Cells[3].ToolTip="Identificacion";
			}
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				
				e.Item.Cells[6].Text=Convert.ToDouble(dr["saldo"]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[0].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				e.Item.Cells[0].ForeColor= System.Drawing.Color.Blue;
				
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				
			}
		}

		private void ibtnAbrir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.GenerarExcelCompleto(this,grid);
		}
	}
}
