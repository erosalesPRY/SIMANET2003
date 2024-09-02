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
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using SIMA.Controladoras.GestionComercial;
using SIMA.Controladoras.General;


namespace SIMA.SimaNetWeb.GestionComercial.Promotores
{
	/// <summary>
	/// Summary description for ConsultarHistoricoPromotores.
	/// </summary>
	public class ConsultarHistoricoPromotores : System.Web.UI.Page, IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		#endregion
		
		#region Constantes

		//Ordenamiento
		const string COLORDENAMIENTO = "IdPromotor";
		
		//Otros
		const int POSICIONNRO = 0;
		const int POSICIONFOOTERNOMBRETOTAL = 0;
		const int POSICIONFOOTERTOTALVENTAS = 4;
		const int POSICIONFOOTERTOTALRETRIBUCION = 5;

		const int POSICIONNROCONTRATO = 1;
		const int POSICIONFECHAINICIO = 2;
		const int POSICIONFECHATERMINO = 3;

		const string DETALLEVENTAS = "Detalle de Ventas";
		const string TOTALVENTAS = "TOTALVENTAS";
		const string TEXTOFOOTERTOTAL = "TOTAL";
		
		const string GRILLAVACIA = "No existe ningun Promotor";

		//Paginas
		protected System.Web.UI.WebControls.ImageButton ibtnFiltro;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminarFiltro;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hOrdenGrilla;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hDescripcion;
		protected projDataGridWeb.DataGridWeb gridProyectos;
	
		//Key Session y QueryString
		const string KEYQID = "Id";
		protected projDataGridWeb.DataGridWeb gridContratos;
		protected System.Web.UI.WebControls.Label lblSubtitulo;
		const string KEYQDESCRIPCION = "Promotor";

		#endregion
		
		#region variables
		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarJScript();
					this.LlenarCombos();
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionComercial",this.ToString(),"Se consultaron Promotores por venta.",Enumerados.NivelesErrorLog.I.ToString()));
					this.LlenarGrillaOrdenamientoPaginacion(hOrdenGrilla.Value,Convert.ToInt32(this.hGridPagina.Value));
					
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
			this.gridContratos.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.gridContratos_SortCommand);
			this.gridContratos.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.gridContratos_PageIndexChanged);
			this.gridContratos.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.gridContratos_ItemDataBound);
			this.gridContratos.SelectedIndexChanged += new System.EventHandler(this.gridContratos_SelectedIndexChanged);
			this.gridProyectos.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.gridProyectos_PageIndexChanged);
			this.gridProyectos.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.gridProyectos_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			CVentasReales oCVentasReales=  new CVentasReales();
			DataTable dt =  oCVentasReales.ConsultarVentasRealesPorPromotor(Convert.ToInt32(Page.Request[KEYQID]));
			
			if(dt!=null)
			{
				DataView dw = dt.DefaultView;
				dw.Sort = columnaOrdenar;
				gridContratos.DataSource = dw;
				dw.RowFilter = Helper.ObtenerFiltro(this);

				if (dw.Count == 0)
				{
					gridContratos.DataSource = null; 
					lblResultado.Text = GRILLAVACIA;
					lblResultado.Visible = true;
				}
				else
				{
					gridContratos.DataSource = dw;
					gridContratos.Columns[POSICIONFOOTERNOMBRETOTAL].FooterText = TEXTOFOOTERTOTAL;
					gridContratos.Columns[1].FooterText = dw.Count.ToString();
					gridContratos.Columns[POSICIONFOOTERTOTALVENTAS].FooterText = Helper.TotalizarDataView(dw,
						Enumerados.ColumnasVentasReales.TOTALVENTAS.ToString())[0].ToString(Utilitario.Constantes.FORMATODECIMAL4);

					gridContratos.Columns[POSICIONFOOTERTOTALRETRIBUCION].FooterText = Helper.TotalizarDataView(dw,
						Enumerados.ColumnasVentasReales.RETRIBUCION.ToString())[0].ToString(Utilitario.Constantes.FORMATODECIMAL4);

					lblResultado.Visible = false;
				}

				/*CImpresion oCImpresion = new CImpresion();
				oCImpresion.GuardarDataImprimirExportar(dwPromotores.Table,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGOTITULOREPORTELISTARTODOSPROMOTORES),columnaOrdenar,indicePagina);*/
			}
			else
			{
				gridContratos.DataSource = dt;
				lblResultado.Text = GRILLAVACIA;
				lblResultado.Visible = true;
			}
			try
			{
				gridContratos.DataBind();
			}
			catch(Exception ex)
			{
				//string a = ex.Message;
				gridContratos.CurrentPageIndex = 0;
				gridContratos.DataBind();
			}
		}

		public void LlenarCombos()
		{
			lblTitulo.Text = Page.Request[KEYQDESCRIPCION].ToString();
			lblSubtitulo.Text = DETALLEVENTAS;
		}

		public void LlenarDatos()
		{
			// TODO:  Add ConsultarHistoricoPromotores.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarHistoricoPromotores.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarHistoricoPromotores.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarHistoricoPromotores.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarHistoricoPromotores.Exportar implementation
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

		private void gridContratos_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			gridContratos.CurrentPageIndex=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);	
		}

		private void gridContratos_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.hOrdenGrilla.Value = Helper.GenerarExpresionOrdenamiento(e.SortExpression);
			this.LlenarGrillaOrdenamientoPaginacion(hOrdenGrilla.Value,Helper.ObtenerIndicePagina());	
		}

		public void LlenarProyectos(int Pagina)
		{
			CVentasReales oCVentasReales= new CVentasReales();
			DataTable dt = oCVentasReales.ConsultarVentasRealesProyectosPorPromotor(
				Convert.ToInt32(Page.Request[KEYQID]),
				Convert.ToDateTime(gridContratos.Items[gridContratos.SelectedIndex].Cells[POSICIONFECHAINICIO].Text).ToString(Constantes.FORMATOFECHA2),
				Convert.ToDateTime(gridContratos.Items[gridContratos.SelectedIndex].Cells[POSICIONFECHATERMINO].Text).ToString(Constantes.FORMATOFECHA2));

			if (dt !=null)
			{
				DataView dv = dt.DefaultView;
				this.gridProyectos.DataSource=dv;
				gridProyectos.CurrentPageIndex = Pagina;
				gridProyectos.Columns[POSICIONFOOTERNOMBRETOTAL].FooterText = TEXTOFOOTERTOTAL;
				gridProyectos.Columns[1].FooterText = dv.Count.ToString();
			}
			else
			{
				this.gridProyectos.DataSource=dt;
			}
			this.gridProyectos.DataBind();
		}

		private void gridContratos_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				e.Item.Cells[POSICIONNRO].Text = Helper.ObtenerIndicedeRegistro(gridContratos.CurrentPageIndex,
					gridContratos.PageSize,e.Item.ItemIndex);

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
			}		
		}

		private void gridContratos_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.LlenarProyectos(Constantes.POSICIONINDEXCERO);
			
			lblSubtitulo.Text = DETALLEVENTAS + Constantes.ESPACIO + Constantes.SIGNOMENOS + 
				gridContratos.Items[gridContratos.SelectedIndex].Cells[1].Text.ToUpper();
		}

		private void gridProyectos_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				e.Item.Cells[POSICIONNRO].Text = Helper.ObtenerIndicedeRegistro(gridProyectos.CurrentPageIndex,
					gridProyectos.PageSize,e.Item.ItemIndex);
			}		
		}

		private void gridProyectos_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			gridProyectos.CurrentPageIndex=e.NewPageIndex;
			this.LlenarProyectos(e.NewPageIndex);			
		}
	}
}
