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
	/// Summary description for ExportarDetalleExcelCtasPagarOtros.
	/// </summary>
	public class ExportarDetalleExcelCtasPagarOtros : System.Web.UI.Page,IPaginaBase
	{
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.ImageButton ibtnAbrir;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
			protected System.Web.UI.WebControls.Literal ltlMensaje;
	
		#region Variables
		#endregion
		#region Constantes
		//Query String
		private const string KEYIDSUBCUENTA = "IdCuenta";
		private const string KEYIDCUENTA = "KEYIDCUENTA"; 
		private const string KEYIDCENTROOPERATIVO ="KEYIDCENTROOPERATIVO";
		private const string KEYQFLAGDIRECTORIO= "FlagDirectorio";
		
		//Mensajes
		private const string GRILLAVACIA="No existen registros";
		private const string MENSAJECONSULTAR="Se Consulto el Detalle de Cuentas Por Pagar Otros";
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
				//this.Totalizar(((DataTable)Session["EXPORTAREXCEL"]).DefaultView);	
				double total=0;
				foreach(DataRow dr in ((DataTable)Session["EXPORTAREXCEL"]).Rows)
					total+= Convert.ToDouble(dr["TotalEnSoles"].ToString());
				grid.DataSource=((DataTable)Session["EXPORTAREXCEL"]);
				grid.Columns[1].FooterText=((DataTable)Session["EXPORTAREXCEL"]).Rows.Count.ToString();
				grid.Columns[2].FooterText=total.ToString();
				//this.Totalizar(((DataTable)Session["EXPORTAREXCEL"]).DefaultView);

				grid.DataBind();
				

			}

		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ExportarDetalleExcelCtasPagarOtros.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add ExportarDetalleExcelCtasPagarOtros.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add ExportarDetalleExcelCtasPagarOtros.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add ExportarDetalleExcelCtasPagarOtros.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add ExportarDetalleExcelCtasPagarOtros.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ExportarDetalleExcelCtasPagarOtros.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ExportarDetalleExcelCtasPagarOtros.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ExportarDetalleExcelCtasPagarOtros.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add ExportarDetalleExcelCtasPagarOtros.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ExportarDetalleExcelCtasPagarOtros.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				e.Item.Cells[Constantes.POSICIONCONTADOR].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);

				
				Helper.FiltroporSeleccionConfiguraColumna(e,grid);

				if(Page.Request.QueryString[KEYIDCUENTA] == "14" && Page.Request.QueryString[KEYIDSUBCUENTA] == "5")
				{
					e.Item.Cells[1].Text = String.Empty;
				}
				else if(Page.Request.QueryString[KEYIDCUENTA] == "15" && Page.Request.QueryString[KEYIDSUBCUENTA] == "5")
				{
					e.Item.Cells[1].Text = String.Empty;
				}
			}
		}

		private void ibtnAbrir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.GenerarExcelCompleto(this,grid);
		}
	}
}
