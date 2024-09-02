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
using SIMA.Controladoras.GestionComercial;
using SIMA.Controladoras.General;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;

namespace SIMA.SimaNetWeb.GestionComercial.Ventas
{
	/// <summary>
	/// Summary description for ConsultarVentasRealesPorPeriodosVsVentasPresupuestadasActual.
	/// </summary>
	public class ConsultarVentasRealesPorPeriodosVsVentasPresupuestadasActual: System.Web.UI.Page,IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
		protected projDataGridWeb.DataGridWeb dgConsulta;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion

		#region Constantes
		
		//Ordenamiento
		const string COLORDENAMIENTO = "centrooperativo";

		//JScript

		//Columnas DataTable

		//Nombres de Controles
		const string PERIODO4 = "lblMontoPeriodo4";
		const string PERIODO3 = "lblMontoPeriodo3";
		const string PERIODO2 = "lblMontoPeriodo2";
		const string PERIODO1 = "lblMontoPeriodo1";
		const string PERIODOACTUAL = "lblMontoPeriodoActual";

		//Paginas
		const string URLIMPRESION = "PopupImpresionConsultarVentasRealesPorPeriodosVsVentasPresupuestadasActual.aspx";
	
		//Key Session y QueryString
				
		//Otros
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
					
					Helper.ReiniciarSession();

					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se consultaron las Ventas Reales por Periodos vs Ventas Presupuestadas Actual",Enumerados.NivelesErrorLog.I.ToString()));

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
			this.ibtnImprimir.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnImprimir_Click);
			this.dgConsulta.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgConsulta_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add ConsultarVentasRealesPorPeriodosVsVentasPresupuestadasActual.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarVentasRealesPorPeriodosVsVentasPresupuestadasActual.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			CVentasReales oCVentasReales =  new CVentasReales();
			DataTable dtVentas =  oCVentasReales.ConsultarVentasRealesPorPeriodosVsVentaPresupuestadaActual();
			
			if(dtVentas!=null)
			{
				DataView dwVentas = dtVentas.DefaultView;
				dgConsulta.DataSource = dwVentas;
				lblResultado.Visible = false;

				CImpresion oCImpresion = new CImpresion();
				oCImpresion.GuardarDataImprimirExportar(dwVentas.Table,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGOTITULOREPORTEVENTASREALESPORPERIODOSVSVENTAPRESUPUESTADAACTUAL),columnaOrdenar,indicePagina);
			}
			else
			{
				dgConsulta.DataSource = dtVentas;
				lblResultado.Visible = true;
				lblResultado.Text = GRILLAVACIA;
			}
			
			try
			{
				dgConsulta.DataBind();
			}
			catch(Exception ex)
			{
				string a = ex.Message;
				dgConsulta.CurrentPageIndex = 0;
				dgConsulta.DataBind();
			}
		}

		public void LlenarCombos()
		{
			// TODO:  Add ConsultarVentasRealesPorPeriodosVsVentasPresupuestadasActual.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add ConsultarVentasRealesPorPeriodosVsVentasPresupuestadasActual.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarVentasRealesPorPeriodosVsVentasPresupuestadasActual.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarVentasRealesPorPeriodosVsVentasPresupuestadasActual.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			ltlMensaje.Text = Helper.PopupImpresion(URLIMPRESION,750,500,false,false,false,true,true);
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarVentasRealesPorPeriodosVsVentasPresupuestadasActual.Exportar implementation
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
			return false;
		}

		#endregion

		private void dgConsulta_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				
				Label lbl1 = (Label)e.Item.Cells[PosicionPeriodo4].FindControl(PERIODO4);
				lbl1.Text = Convert.ToDouble(dr[Enumerados.ColumnasVentasReales.anio4.ToString()]).ToString(Constantes.FORMATODECIMAL4).ToString();
				montoPeriodo4 += Convert.ToDouble(dr[Enumerados.ColumnasVentasReales.anio4.ToString()]);

				Label lbl2 = (Label)e.Item.Cells[PosicionPeriodo3].FindControl(PERIODO3);
				lbl2.Text = Convert.ToDouble(dr[Enumerados.ColumnasVentasReales.anio3.ToString()]).ToString(Constantes.FORMATODECIMAL4).ToString();
				montoPeriodo3 += Convert.ToDouble(dr[Enumerados.ColumnasVentasReales.anio3.ToString()]);

				Label lbl3 = (Label)e.Item.Cells[PosicionPeriodo2].FindControl(PERIODO2);
				lbl3.Text = Convert.ToDouble(dr[Enumerados.ColumnasVentasReales.anio2.ToString()]).ToString(Constantes.FORMATODECIMAL4).ToString();
				montoPeriodo2 += Convert.ToDouble(dr[Enumerados.ColumnasVentasReales.anio2.ToString()]);

				Label lbl4 = (Label)e.Item.Cells[PosicionPeriodo1].FindControl(PERIODO1);
				lbl4.Text = Convert.ToDouble(dr[Enumerados.ColumnasVentasReales.anio1.ToString()]).ToString(Constantes.FORMATODECIMAL4).ToString();
				montoPeriodo1 += Convert.ToDouble(dr[Enumerados.ColumnasVentasReales.anio1.ToString()]);

				Label lbl5 = (Label)e.Item.Cells[PosicionPeriodoActual].FindControl(PERIODOACTUAL);
				lbl5.Text = Convert.ToDouble(dr[Enumerados.ColumnasVentasReales.anio0.ToString()]).ToString(Constantes.FORMATODECIMAL4).ToString();
				montoPeriodoActual += Convert.ToDouble(dr[Enumerados.ColumnasVentasReales.anio0.ToString()]);

				e.Item.Cells[PosicionPeriodoTotal].Text = Convert.ToDouble(e.Item.Cells[PosicionPeriodoTotal].Text).ToString(Constantes.FORMATODECIMAL4);
				montoPeriodoTotal += Convert.ToDouble(dr[Enumerados.ColumnasVentasReales.total.ToString()]);

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
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

		private void ibtnImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Imprimir();
		}
	}
}