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
using SIMA.Controladoras.General;
using SIMA.Controladoras.GestionEstrategica.PlanEstrategico;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using NullableTypes;
using MetaBuilders.WebControls;
using System.Diagnostics; 

namespace SIMA.SimaNetWeb.GestionEstrategica.PlanEstrategico
{
	public class ConsultarPlanOperativo : System.Web.UI.Page, IPaginaBase
	{
		#region Constante

		const string CONTROLGRILLAINDICADORES ="gridIndicadores";
		const string CONTROLGRILLAOBJETIVOSESPECIFICOS ="gridObjetivosEspecificos1";

		const string GRILLAVACIA="No Existen datos Plan Estrategico";
		const string TITULO = "Consultar Plan Operativo SIMA-PERU S.A. ";
		const string TITULOSECUNDARIO = "Visión de la Entidad: Ser reconocido como el mejor Astillero Naval en Latinoamérica, orgullo de la Industria Nacional";

		#endregion
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPaginaSort;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#region Controles
		#endregion	
	
		int FlagTotalVisible = 0;
		const int VER = 1;

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					this.LlenarJScript();
					this.LlenarTitulos();
					Helper.ReiniciarSession();

					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionFinanciera",this.ToString(),"Se consultó Carta de Crédito.",Enumerados.NivelesErrorLog.I.ToString()));
					this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Convert.ToInt32(this.hGridPagina.Value));
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
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.Header)
			{
				Label lbl=(Label) e.Item.Cells[3].FindControl("lblTotal");
				lbl.Text = "Total " + Convert.ToString(DateTime.Now.Year + 1);

				Label lbl1=(Label) e.Item.Cells[3].FindControl("lblMetas");
				lbl1.Text = "Metas para el Año " + Convert.ToString(DateTime.Now.Year + 1);
			}

			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				projDataGridWeb.DataGridWeb gridObjetivosEspecificos =(projDataGridWeb.DataGridWeb)e.Item.Cells[3].FindControl(CONTROLGRILLAOBJETIVOSESPECIFICOS);	
				DataTable dt = (new CPEObjetivoEspecifico()).ConsultarObjetivosEspecificos(
					Convert.ToInt32(e.Item.Cells[0].Text));

				gridObjetivosEspecificos.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.gridObjetivosEspecificos_ItemDataBound);
				gridObjetivosEspecificos.DataSource = dt;
				gridObjetivosEspecificos.DataBind();
			}					
		}

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
		}

		private DataTable ObtenerDatos()
		{
			return (new CPEObjetivoGeneral()).ConsultarObjetivosGenerales();
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dt = this.ObtenerDatos();
			if(dt!=null)
			{
				DataView dw = dt.DefaultView;
				dw.RowFilter = Helper.ObtenerFiltro();
				grid.DataSource = dw;
				lblResultado.Visible = false;
			}
			else
			{
				grid.DataSource = dt;
				lblResultado.Visible = true;
				lblResultado.Text = GRILLAVACIA;
			}
			try
			{
				grid.DataBind();
			}
			catch(Exception ex)
			{
				string x = ex.Message;
				grid.DataBind();
			}
		}

		public void LlenarCombos()
		{
			// TODO:  Add ConsultarPlanEstrategicoBase.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add ConsultarPlanEstrategicoBase.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarPlanEstrategicoBase.LlenarJScript implementation
		}

		public void LlenarTitulos()
		{
			lblPagina.Text = TITULO + Convert.ToString(DateTime.Now.Year + 1);
			lblTitulo.Text = TITULOSECUNDARIO;
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarPlanEstrategicoBase.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarPlanEstrategicoBase.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarPlanEstrategicoBase.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			if(CNetAccessControl.FindPage(Page.Request.Url.AbsolutePath.ToString()))
			{CNetAccessControl.LoadControls(this);}
			else
			{CNetAccessControl.RedirectPageError();}
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ConsultarPlanEstrategicoBase.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void ibtnEliminaFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}

		private void ibtnFiltrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			ltlMensaje.Text = Helper.ElaborarFiltro(this.ObtenerDatos(),"Descripcion;Descripcion");
		}

		private void gridObjetivosEspecificos_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				FlagTotalVisible = Convert.ToInt32(dr[Enumerados.PlanEstrategicoColumnas.FlagTotalVisible.ToString()]);

				projDataGridWeb.DataGridWeb gridInd =(projDataGridWeb.DataGridWeb)e.Item.Cells[3].FindControl(CONTROLGRILLAINDICADORES);	
				DataTable dt = (new CPEIndicador()).ConsultarIndicadoresPlanOperativo(
					Convert.ToInt32(e.Item.Cells[0].Text));

				gridInd.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.gridIndicadores_ItemDataBound);
				gridInd.Columns[0].ItemStyle.Width = 100;
				gridInd.Columns[1].ItemStyle.Width = 50;
				gridInd.Columns[2].ItemStyle.Width = 50;
				gridInd.Columns[3].ItemStyle.Width = 50;
				gridInd.Columns[4].ItemStyle.Width = 50;
				gridInd.Columns[5].ItemStyle.Width = 50;
				gridInd.Columns[6].ItemStyle.Width = 50;
				gridInd.DataSource = dt;
				gridInd.DataBind();
			}						
		}

		private void gridIndicadores_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				double Monto=0;

				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				if (FlagTotalVisible == VER)
				{
					Monto = Convert.ToDouble(dr[Enumerados.PlanEstrategicoColumnas.Trimestre1.ToString()]) +
						Convert.ToDouble(dr[Enumerados.PlanEstrategicoColumnas.Trimestre2.ToString()]) +
						Convert.ToDouble(dr[Enumerados.PlanEstrategicoColumnas.Trimestre3.ToString()]) +
						Convert.ToDouble(dr[Enumerados.PlanEstrategicoColumnas.Trimestre4.ToString()]);

					/*if (Enumerados.TipoDatosColumnas.DOUBLE.ToString() == dr[Enumerados.PlanEstrategicoColumnas.Var2.ToString()].ToString())
					{e.Item.Cells[1].Text = Monto.ToString(Utilitario.Constantes.FORMATODECIMAL4);}
					else
					{*/e.Item.Cells[2].Text = Monto.ToString(Utilitario.Constantes.FORMATODECIMAL0);//}
				}
			}								
		}
	}
}
