using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using SIMA.SimaNetWeb.InterfacesIU;
using SIMA.Controladoras.General;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;

namespace SIMA.SimaNetWeb.GestionComercial.Ventas
{
	/// <summary>
	/// Summary description for PopupImpresionConsultarVentasRealesPorPeriodosVsVentasPresupuestadasActual.
	/// </summary>
	public class PopupImpresionConsultarVentasRealesPorPeriodosVsVentasPresupuestadasActual : System.Web.UI.Page,IPaginaBase
	{
		#region Controles

		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.DataGrid grid;
		protected System.Web.UI.WebControls.DataGrid gridMensual;
		protected System.Web.UI.WebControls.DataGrid gridAnual;

		#endregion Controles

		#region Constantes
		
		//Key Session y QueryString
		const int CantidadCero = 0;
		const string GRILLAVACIA ="No existe ninguna Venta Ejecutada y ninguna Venta Presupuestada.";
		const int PosicionPeriodo4 = 1;
		const int PosicionPeriodo3 = 2;
		const int PosicionPeriodo2 = 3;
		const int PosicionPeriodo1 = 4;
		const int PosicionPeriodoActual = 5;
		const int PosicionPeriodoTotal = 6;

		#endregion Constantes

		#region Variables

		double montoPeriodo4 = 0;
		double montoPeriodo3 = 0;
		double montoPeriodo2 = 0;
		double montoPeriodo1 = 0;
		double montoPeriodoActual = 0;
		double montoPeriodoTotal = 0;

		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					this.LlenarDatos();
					this.LlenarGrilla();
					this.Imprimir();
				}
				catch(SIMAExcepcionLog oSIMAExcepcionLog)
				{
					ltlMensaje.Text = Helper.MensajeAlert(oSIMAExcepcionLog.Mensaje);					
				}
				catch(SIMAExcepcionIU oSIMAExcepcionIU)
				{
					ltlMensaje.Text = Helper.MensajeAlert(oSIMAExcepcionIU.Mensaje);					
				}
				catch(SIMAExcepcion oSIMAExcepcion)
				{
					ltlMensaje.Text = Helper.MensajeAlert(oSIMAExcepcion.Mensaje);					
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
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			CImpresion oCImpresion =  new CImpresion();
			DataTable dtImpresion =  oCImpresion.ObtenerDataImprimir();
			
			if(dtImpresion!=null)
			{
				DataView dwImpresion = dtImpresion.DefaultView;
				grid.DataSource = dwImpresion;
				lblResultado.Visible = false;
				grid.CurrentPageIndex = oCImpresion.ObtenerIndicePagina();
			}
			else
			{
				grid.DataSource = dtImpresion;
				lblResultado.Text = GRILLAVACIA;
				lblResultado.Visible = true;
			}
			try
			{
				grid.DataBind();
			}
			catch(Exception ex)
			{
				string a = ex.Message;
			}
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add PopupImpresionConsultarVentasRealesPorPeriodosVsVentasPresupuestadasActual.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
		{
			// TODO:  Add PopupImpresionConsultarVentasRealesPorPeriodosVsVentasPresupuestadasActual.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add PopupImpresionConsultarVentasRealesPorPeriodosVsVentasPresupuestadasActual.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			lblTitulo.Text = CImpresion.ObtenerTituloReporte();
		}

		public void LlenarJScript()
		{
			// TODO:  Add PopupImpresionConsultarVentasRealesPorPeriodosVsVentasPresupuestadasActual.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add PopupImpresionConsultarVentasRealesPorPeriodosVsVentasPresupuestadasActual.RegistrandoJScript implementation
		}

		public void Imprimir()
		{
		 	ltlMensaje.Text=Helper.Imprimir();
		}

		public void Exportar()
		{
			// TODO:  Add PopupImpresionConsultarVentasRealesPorPeriodosVsVentasPresupuestadasActual.Exportar implementation
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
			return true;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				
				montoPeriodo4 += Convert.ToDouble(dr[Enumerados.ColumnasVentasReales.anio4.ToString()]);

				montoPeriodo3 += Convert.ToDouble(dr[Enumerados.ColumnasVentasReales.anio3.ToString()]);

				montoPeriodo2 += Convert.ToDouble(dr[Enumerados.ColumnasVentasReales.anio2.ToString()]);

				montoPeriodo1 += Convert.ToDouble(dr[Enumerados.ColumnasVentasReales.anio1.ToString()]);

				montoPeriodoActual += Convert.ToDouble(dr[Enumerados.ColumnasVentasReales.anio0.ToString()]);

				montoPeriodoTotal += Convert.ToDouble(dr[Enumerados.ColumnasVentasReales.total.ToString()]);
			}

			if (e.Item.ItemType == ListItemType.Header)
			{
				e.Item.Cells[PosicionPeriodo4].Text = (DateTime.Today.Year-4).ToString();
				e.Item.Cells[PosicionPeriodo3].Text = (DateTime.Today.Year-3).ToString();
				e.Item.Cells[PosicionPeriodo2].Text = (DateTime.Today.Year-2).ToString();
				e.Item.Cells[PosicionPeriodo1].Text = (DateTime.Today.Year-1).ToString();
				e.Item.Cells[PosicionPeriodoActual].Text = DateTime.Today.Year.ToString();
			}

			if (e.Item.ItemType == ListItemType.Footer)
			{
				e.Item.Cells[PosicionPeriodo4].Text = montoPeriodo4.ToString(Constantes.FORMATODECIMAL4);
				e.Item.Cells[PosicionPeriodo3].Text = montoPeriodo3.ToString(Constantes.FORMATODECIMAL4);
				e.Item.Cells[PosicionPeriodo2].Text = montoPeriodo2.ToString(Constantes.FORMATODECIMAL4);
				e.Item.Cells[PosicionPeriodo1].Text = montoPeriodo1.ToString(Constantes.FORMATODECIMAL4);
				e.Item.Cells[PosicionPeriodoActual].Text = montoPeriodoActual.ToString(Constantes.FORMATODECIMAL4);
				e.Item.Cells[PosicionPeriodoTotal].Text = montoPeriodoTotal.ToString(Constantes.FORMATODECIMAL4);
			}
		}
	}
}