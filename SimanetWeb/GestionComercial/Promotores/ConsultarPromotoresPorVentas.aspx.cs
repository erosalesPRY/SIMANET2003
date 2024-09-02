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

namespace SIMA.SimaNetWeb.GestionComercial.Promotores
{
	/// <summary>
	/// Summary description for ConsultarPromotoresPorVentas.
	/// </summary>
	public class ConsultarPromotoresPorVentas : System.Web.UI.Page,IPaginaBase
	{
		#region Controles

		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary DomValidationSummary1;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminarFiltro;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
		#endregion Controles

		#region Constantes
		//Ordenamiento
		const string COLORDENAMIENTO = "IDPROMOTOR";

		//Columnas DataTable

		//Nombres de Controles
		
		//Paginas
		const string URLIMPRESION = "PopupImpresionConsultarPromotoresPorVentas.aspx";
		const string URLCONSULTARHISTORICOPROMOTORES = "ConsultarHistoricoPromotores.aspx?";

		const string URLPOPUPDETALLEVENTASPROMOTOR = "PopupDetalleVentasPromotores.aspx?";
		const string URLPOPUPCONTRATOSPROMOTOR = "PopupHistoricoContratosPromotor.aspx?";
		const string URLPOPUPDETALLEREPRESENTANTE = "PopupDetallesRepresentantePromotor.aspx?";
		const string URLDETALLECONTRATOHISTORICOPROMOTOR = "PopupHistoricoContratosPromotor.aspx?";
		const string URLDETALLEPROMOTOR = "DetallePromotores.aspx?";
	
		//Key Session y QueryString
		
		const string KEYQIDPROMOTOR = "Id";
		const string KEYQDESCRIPCION = "Promotor";

		//Otros
		const string GRILLAVACIA ="No existe ningún Promotor.";
		const string TEXTOFOOTERTOTAL = "Total:";
		const int POSICIONFOOTERTOTAL = 1;
		const int POSICIONFOOTERTOTALMONTO = 5;
		const int POSICIONFOOTERTOTALRETRIBUCION = 6;

		const int POSICIONNUMERACION = 0;
		const int POSICIONNROCONTRATO = 3;

		const string CONTROLIMG = "img";
		const string PROMOTORVIGENTE = "Promotor Vigente";
		protected System.Web.UI.WebControls.Label lblTipoContrato;
		protected System.Web.UI.WebControls.DropDownList ddlbEstado;
		const string HISTORICOCONTRATOS = "Histórico de Contratos";

		#endregion Constantes
		
		#region Variables
		
		#endregion Variables

		private void Page_Load(object sender, System.EventArgs e)
		{	
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();

					Helper.ReiniciarSession();
					this.LlenarJScript();
					//Graba en el Log la acción ejecutada
					HttpContext.Current.Session[Constantes.KEYSSORT] = COLORDENAMIENTO;
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionComercial",this.ToString(),"Se consultaron Promotores por venta.",Enumerados.NivelesErrorLog.I.ToString()));
					Helper.SeleccionarItemCombos(this);
					this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),Helper.ObtenerIndicePagina());
					
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
			this.ibtnEliminarFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminarFiltro_Click);
			this.ddlbEstado.SelectedIndexChanged += new System.EventHandler(this.ddlbEstado_SelectedIndexChanged);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add ConsultarPromotoresPorVentas.LlenarGrilla implementation
		}

		
		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarPromotoresPorVentas.LlenarGrillaOrdenamiento implementation
		}

		public DataTable ObtenerDatos()
		{
			CVentasReales oCVentasReales=  new CVentasReales();
			return oCVentasReales.ConsultarVentasRealesPromotores();
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
		{
			DataTable dt=  this.ObtenerDatos();
			
			if(dt!=null)
			{
				DataView dw = dt.DefaultView;
				dw.Sort = columnaOrdenar;
				dw.RowFilter = Enumerados.ColumnasVentasReales.Vigencia + "='" + ddlbEstado.SelectedValue.ToString() + "'";
				//dw.RowFilter = Helper.ObtenerFiltro(this);
				grid.DataSource = dw;

				if (dw.Count == 0)
				{
					grid.DataSource = null; 
					lblResultado.Text = GRILLAVACIA;
					lblResultado.Visible = true;
				}
				else
				{
					grid.DataSource = dw;
					grid.Columns[0].FooterText = TEXTOFOOTERTOTAL;
					grid.Columns[POSICIONFOOTERTOTAL].FooterText = dw.Count.ToString();
					grid.Columns[POSICIONFOOTERTOTALMONTO].FooterText = Helper.TotalizarDataView(
						dw, 
						Enumerados.ColumnasVentasReales.TOTALVENTAS.ToString(),
						Enumerados.ColumnasVentasReales.Vigencia.ToString(),
						ddlbEstado.SelectedValue)[0].ToString(Utilitario.Constantes.FORMATODECIMAL4);

					grid.Columns[POSICIONFOOTERTOTALRETRIBUCION].FooterText = Helper.TotalizarDataView(
						dw, 
						Enumerados.ColumnasVentasReales.RETRIBUCION.ToString(),
						Enumerados.ColumnasVentasReales.Vigencia.ToString(),
						ddlbEstado.SelectedValue)[0].ToString(Utilitario.Constantes.FORMATODECIMAL4);

					lblResultado.Visible = false;
				}
				/*CImpresion oCImpresion = new CImpresion();
				oCImpresion.GuardarDataImprimirExportar(dw.Table,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGODETALLEVENTASPRESUPUESTADAS),columnaOrdenar,indicePagina);*/
			}
			else
			{
				grid.DataSource = dt;
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
				grid.CurrentPageIndex = 0;
				grid.DataBind();
			}
			
		}

		public void LlenarCombos()
		{
		}

		public void LlenarDatos()
		{
		}

		public void LlenarJScript()
		{
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarPromotoresPorVentas.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			ltlMensaje.Text = Helper.PopupImpresion(URLIMPRESION,650,780,false,false,false,true,true);
		}

		public void Exportar()
		{
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

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(e.SortExpression),Helper.ObtenerIndicePagina());
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			grid.CurrentPageIndex=e.NewPageIndex;
			HttpContext.Current.Session[Constantes.KEYSINDICEPAGINA] = e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);
		}

		private void ibtnImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Imprimir();
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

			   
				e.Item.Cells[POSICIONNUMERACION].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				e.Item.Cells[POSICIONNUMERACION].Attributes.Add(Utilitario.Constantes.EVENTOCLICK, Utilitario.Constantes.POPUPDEESPERA +
					Helper.MostrarVentana(URLDETALLEPROMOTOR,Utilitario.Constantes.KEYMODOPAGINA +  
					Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.C.ToString() +
					Utilitario.Constantes.SIGNOAMPERSON + KEYQIDPROMOTOR +  
					Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr[Enumerados.ColumnasPromotor.IdPromotor.ToString()])));
				e.Item.Cells[POSICIONNUMERACION].Font.Underline=true;
				e.Item.Cells[POSICIONNUMERACION].ForeColor= System.Drawing.Color.Blue;
				e.Item.Cells[POSICIONNUMERACION].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado("ddlbEstado"));

				e.Item.Cells[POSICIONNROCONTRATO].Attributes.Add(Utilitario.Constantes.EVENTOCLICK, Utilitario.Constantes.POPUPDEESPERA +
					Helper.MostrarVentana(URLCONSULTARHISTORICOPROMOTORES,KEYQIDPROMOTOR +  
					Utilitario.Constantes.SIGNOIGUAL + dr[Enumerados.ColumnasPromotor.IdPromotor.ToString()].ToString() +
					Utilitario.Constantes.SIGNOAMPERSON + KEYQDESCRIPCION +  
					Utilitario.Constantes.SIGNOIGUAL + dr[Enumerados.ColumnasPromotor.Promotor.ToString()].ToString()));
				e.Item.Cells[POSICIONNROCONTRATO].Font.Underline=true;
				e.Item.Cells[POSICIONNROCONTRATO].ToolTip = HISTORICOCONTRATOS;
				e.Item.Cells[POSICIONNROCONTRATO].ForeColor= System.Drawing.Color.Blue;
				e.Item.Cells[POSICIONNROCONTRATO].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEUP,Helper.HistorialIrAdelantePersonalizado("ddlbEstado"));

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e); 
				//Helper.FiltroporSeleccionConfiguraColumna(e,grid);

			}
		}

		private void ibtnFiltrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			ltlMensaje.Text= Utilitario.Helper.ElaborarFiltro(this,this.ObtenerDatos(),"../../Filtros.aspx"
				,Utilitario.Enumerados.ColumnasPromotor.Promotor.ToString()+ ";Promotor"
				,Utilitario.Enumerados.ColumnasPromotor.RepresentanteLegal.ToString()+ ";Representante Legal"
				,Utilitario.Enumerados.ColumnasPromotor.TotalVentas.ToString()+ ";Total Ventas"
				);
		}

		private void ibtnEliminarFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}

		private void ddlbEstado_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),Helper.ObtenerIndicePagina());		
		}
	}
}

