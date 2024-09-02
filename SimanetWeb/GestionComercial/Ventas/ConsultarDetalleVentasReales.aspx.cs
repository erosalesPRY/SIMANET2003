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
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using SIMA.Controladoras.General;

namespace SIMA.SimaNetWeb.GestionComercial.Ventas
{
	/// <summary>
	/// Summary description for ConsultarDetalleVentasReales
	/// </summary>
	public class ConsultarDetalleVentasReales: System.Web.UI.Page,IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label lblObservaciones;
		protected projDataGridWeb.DataGridWeb dgObservaciones;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltro;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminarFiltro;
		protected System.Web.UI.WebControls.Label lblResultadoObservaciones;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion

		#region Constantes
		
		//Ordenamiento
		const string COLORDENAMIENTO = "IDVENTAREAL";

		//JScript

		//Columnas DataTable

		//Nombres de Controles
		const string CONTROLINK = "hlkProyecto";
		const string CAJATEXTOOBSERVACIONES = "txtObservaciones";
		
		//Paginas
		const string URLDETALLE = "DetalleVentasReales.aspx?";
		const string URLIMPRESION = "PopupImpresionConsultarDetalleVentasReales.aspx?";
	
		//Key Session y QueryString
		const string KEYQIDCENTROOPERATIVO = "IdCentroOperativo";
		const string KEYQNOMBRE = "Nombre";
		const string KEYQIDMES = "IdMes";
		const string KEYQNOMBREMES = "NombreMes";
		const string KEYQID = "Id";
		const string KEYQSUBTITULOREPORTE = "Subtitulo";
		
		//Otros
		const int POSICIONFOOTERTOTAL = 2;
		const int POSICIONFOOTERMONTOTOTAL = 6;
		const int POSICIONCONTROL = 5;
		const int POSICIONCONTADOR = 0;
		const string GRILLAVACIA ="No existe ninguna Venta Ejecutada.";
		const string GRILLAOBSERVACIONESVACIA ="No existe ninguna Observacion en el Mes.";
		const string TablaImpresion0 = "VentaRealDetallada";
		const string TablaImpresion1 = "ObservacionesMensuales";
		#endregion
		
		#region Variables
	
		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();

					this.LlenarDatos();
					
					Helper.ReiniciarSession();

					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se consultaron las Ventas Reales Detallada del CentroOperativo: "+Page.Request.QueryString[KEYQNOMBRE]+" del Mes: "+Page.Request.QueryString[KEYQNOMBREMES],Enumerados.NivelesErrorLog.I.ToString()));

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
			this.ibtnFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnFiltro_Click);
			this.ibtnEliminarFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminarFiltro_Click);
			this.ibtnImprimir.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnImprimir_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.dgObservaciones.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgObservaciones_PageIndexChanged);
			this.dgObservaciones.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgObservaciones_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add ConsultarDetalleVentasReales.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarDetalleVentasReales.LlenarGrillaOrdenamiento implementation
		}

		public DataTable ObtenerDatos()
		{
			CVentasReales oCVentasReales =  new CVentasReales();
			return oCVentasReales.ConsultarVentasRealesDetalladaMensualPorCentroOperativo(Convert.ToInt32(Page.Request.QueryString[KEYQIDMES]),Convert.ToInt32(Page.Request.QueryString[KEYQIDCENTROOPERATIVO]), Helper.FechaSimanet.ObtenerFechaSesion().Year);
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			CVentasReales oCVentasReales =  new CVentasReales();
			DataSet dsImprimir = new DataSet();
			DataTable dtVentas = this.ObtenerDatos();
			
			if(dtVentas!=null)
			{
				DataView dwVentas = dtVentas.DefaultView;
				dwVentas.Sort = columnaOrdenar;
				dwVentas.RowFilter = Utilitario.Helper.ObtenerFiltro();

				DataTable dtImpresion =  Helper.DataViewTODataTable(dwVentas);
				dtImpresion.TableName = TablaImpresion0;

				if(dwVentas.Count > 0)
				{
					DataTable dt = Helper.DataViewTODataTable(dwVentas);
					grid.Columns[POSICIONFOOTERMONTOTOTAL].FooterText = Helper.TotalizarDataView(dt.DefaultView,Enumerados.ColumnasVentasReales.MONTOPRECIOVENTASOLES.ToString())[Constantes.POSICIONCONTADOR].ToString(Constantes.FORMATODECIMAL4);
					grid.DataSource = dwVentas;
					lblResultado.Visible = false;
					grid.Columns[POSICIONFOOTERTOTAL].FooterText = dwVentas.Count.ToString();
				}
				else
				{
					grid.DataSource = null;
					lblResultado.Visible = true;
					lblResultado.Text = GRILLAVACIA;
				}
				dsImprimir.Tables.Add(dtImpresion);
			}
			else
			{
				grid.DataSource = dtVentas;
				lblResultado.Visible = true;
				lblResultado.Text = GRILLAVACIA;
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

			if(this.grid.DataSource != null)
			{
				//Grilla Observaciones
				DataTable dtObservacionesVentas =  oCVentasReales.ConsultarObservacionesVentasRealesPorMesPorCentroOperativo(Convert.ToInt32(Page.Request.QueryString[KEYQIDMES]),Convert.ToInt32(Page.Request.QueryString[KEYQIDCENTROOPERATIVO]), Helper.FechaSimanet.ObtenerFechaSesion().Year,1);
			
				if(dtObservacionesVentas!=null)
				{
					DataTable dtImpresion1 = dtObservacionesVentas.Copy();
					dtImpresion1.TableName = TablaImpresion1;

					DataView dwObservacionesVentas = dtObservacionesVentas.DefaultView;
					dgObservaciones.DataSource = dwObservacionesVentas;
					lblResultadoObservaciones.Visible = false;

					dgObservaciones.Columns[POSICIONFOOTERTOTAL].FooterText = dwObservacionesVentas.Count.ToString();
					dsImprimir.Tables.Add(dtImpresion1);
				}
				else
				{
					dgObservaciones.DataSource = dtObservacionesVentas;
					lblResultadoObservaciones.Visible = true;
					lblResultadoObservaciones.Text = GRILLAOBSERVACIONESVACIA;
				}
			
				try
				{
					dgObservaciones.DataBind();
				}
				catch(Exception ex)
				{
					string a = ex.Message;
					dgObservaciones.CurrentPageIndex = 0;
					dgObservaciones.DataBind();
				}
			}
			else
			{
				dgObservaciones.DataSource = null;
				lblResultadoObservaciones.Visible = true;
				lblResultadoObservaciones.Text = GRILLAOBSERVACIONESVACIA;
			}
			CImpresion oCImpresion = new CImpresion();
			oCImpresion.GuardarDataImprimirExportar(dsImprimir, Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGOTITULOREPORTEVENTASRELAESDETALLADO), columnaOrdenar, indicePagina);
		}

		public void LlenarCombos()
		{
			// TODO:  Add ConsultarDetalleVentasReales.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			this.lblTitulo.Text += Constantes.ESPACIO + Constantes.LINEA + Constantes.ESPACIO + Page.Request.QueryString[KEYQNOMBRE] + Constantes.ESPACIO + Constantes.LINEA + Constantes.ESPACIO + Page.Request.QueryString[KEYQNOMBREMES];
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarDetalleVentasReales.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarDetalleVentasReales.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			ltlMensaje.Text = Helper.PopupImpresion(URLIMPRESION+KEYQSUBTITULOREPORTE+Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQNOMBRE] + Constantes.ESPACIO + Constantes.LINEA + Constantes.ESPACIO + Page.Request.QueryString[KEYQNOMBREMES],750,500,false,false,false,true,true);
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarDetalleVentasReales.Exportar implementation
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
			// TODO:  Add ConsultarDetalleVentasReales.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				e.Item.Cells[POSICIONFOOTERMONTOTOTAL].Text = Convert.ToDouble(e.Item.Cells[POSICIONFOOTERMONTOTOTAL].Text).ToString(Constantes.FORMATODECIMAL4);

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);

				e.Item.Cells[POSICIONCONTADOR].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);

				e.Item.Cells[POSICIONCONTADOR].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.MostrarVentana(URLDETALLE,KEYQID + Utilitario.Constantes.SIGNOIGUAL + 
					Convert.ToString(dr[Enumerados.ColumnasVentasReales.IDVENTAREAL.ToString()]) +  
					Utilitario.Constantes.SIGNOAMPERSON + Utilitario.Constantes.KEYMODOPAGINA +  
					Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.C.ToString()) + Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.POPUPDEESPERA);
				
				e.Item.Cells[POSICIONCONTADOR].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				e.Item.Cells[POSICIONCONTADOR].Font.Underline=true;
				e.Item.Cells[POSICIONCONTADOR].ForeColor = System.Drawing.Color.Blue;

				Helper.FiltroporSeleccionConfiguraColumna(e,grid);
			}
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			grid.CurrentPageIndex=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(e.SortExpression),Helper.ObtenerIndicePagina());
		}

		private void dgObservaciones_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				e.Item.Cells[POSICIONCONTADOR].Text = Helper.ObtenerIndicedeRegistro(dgObservaciones.CurrentPageIndex,dgObservaciones.PageSize,e.Item.ItemIndex);
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
			}
		}

		private void dgObservaciones_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			dgObservaciones.CurrentPageIndex=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);
		}

		private void ibtnFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			ltlMensaje.Text= Utilitario.Helper.ElaborarFiltro(this.ObtenerDatos()
				,Constantes.SIGNOASTERISCO + Utilitario.Enumerados.ColumnasVentasReales.SECTOR.ToString()+";Sector"
				,Constantes.SIGNOASTERISCO + Utilitario.Enumerados.ColumnasVentasReales.LINEANEGOCIO.ToString()+ ";Linea de Negocio"
				,Utilitario.Enumerados.ColumnasVentasReales.cliente.ToString()+ ";Cliente"
				,Utilitario.Enumerados.ColumnasVentasReales.proyecto.ToString()+ ";Descripcion del Proyecto"
				,Utilitario.Enumerados.ColumnasVentasReales.MONTOPRECIOVENTASOLES.ToString()+ ";Monto");
		}

		private void ibtnEliminarFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}

		private void ibtnImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Imprimir();
		}
	}
}