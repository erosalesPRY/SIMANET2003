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
using SIMA.Controladoras.GestionComercial;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using System.IO;
using SIMA.EntidadesNegocio;
using MetaBuilders.WebControls;

namespace SIMA.SimaNetWeb.GestionComercial.Ventas
{
	///	<summary>
	///	Summary	description	for	ConsultarDetalleVentasPresupuestadas.
	///	</summary>
	public class ConsultarDetalleVentasPresupuestadas: System.Web.UI.Page, IPaginaBase
	{
		#region	Controles

		protected System.Web.UI.WebControls.Label lblFiltros;
		protected System.Web.UI.WebControls.DropDownList ddlbTipoObsequio;
		protected System.Web.UI.WebControls.Label lblTipoObsequio;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DropDownList ddlbTipoPersona;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label lblObservaciones;
		protected System.Web.UI.WebControls.TextBox	txtObservaciones;
		protected System.Web.UI.WebControls.Button btnPresentesFamiliares;
		protected System.Web.UI.WebControls.Literal	ltlMensaje;
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminarFiltro;
		protected System.Web.UI.WebControls.Label lblCentroOperativo;
		protected System.Web.UI.WebControls.Label lblAno;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPaginaSort;

		#endregion Controles

		#region	Constantes
		
		//Ordenamiento
		const string COLORDENAMIENTO = "IDVENTA";
		
		//Nombres de Controles
		const string CONTROLINK	= "hlkProyecto";
		
		//Paginas
		const string URLDETALLE	= "DetalleVentasPresupuestadas.aspx?";
		const string URLDETALLEREAL	= "DetalleVentasReales.aspx?";
		const string URLIMPRESION	= "PopupImpresionConsultarDetalleVentasPresupuestadas.aspx";
				
		//Key Session y	QueryString
		const string KEYQID = "Id";
		const string KEYQIDCENTROOPERATIVO = "IdCentroOperativo";
		const string KEYQIDLINEANEGOCIO = "IdLineaNegocio";
		const string CENTROOPERATIVO = "CO";
		const string KEYQANO = "Ano";
		const string KEYQIDVERSION = "IdVersion";
		const string KEYSINDICEMES = "indiceMes";
		const string KEYQNOMBRE = "NombreMes";
		const string KEYQNOMBREMES = "NombreMes";

		//Monedas
		const int EUROS	= 0;
		const int SOLES	= 1;
		const int DOLARES =	2;

		//JScript
		string JSVERIFICARELIMINAR = "return verificarEliminar(this.form,'cbxEliminar','" +	Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO)+"','"+Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJEPREGUNTAELIMINACIONREGISTRO)+"');";
			
		//Otros
		const string VENTASPRESUPUESTADAS = "CONSULTA DETALLADA DE VENTAS PRESUPUESTADAS TOTALES EN SOLES";
		const string VENTASREALES = "CONSULTA DETALLADA DE VENTAS EJECUTADAS TOTALES EN SOLES";
		const string GRILLAVACIAVENTAPRESUPUESTADA ="No existe ningún detalle de las Ventas Presupuestadas.";
		const string GRILLAVACIAVENTAREAL = "No existe ningún detalle de las Ventas Ejecutadas.";
		const string NOMBRERUTAVENTAPRESUPUESTADA = "Presupuestadas Totales > Mensual > Detalle "; 
		const string NOMBRERUTAVENTAREAL = "Ejecutadas Totales > Mensual > Detalle";
		const string IDVENTA = "IdVenta";
		const string PROYECTO = "Proyecto";
		const string FECHA = "Fecha";
		const string LINEANEGOCIO = "LN";
		const string INDICEPAGINA = "hGridPagina";
		const string PAGINASORT = "hGridPaginaSort";
		const string VERSION = "Version";
		const string TEXTOFOOTERTOTAL =	"Total:";
		const int POSICIONCONTADOR = 0;
		const int POSICIONFOOTERTOTAL =	2;
		const int POSICIONFOOTERTOTALMONTO = 6;
		const string KEYQIDTIPO = "IdTipo";
		
		#endregion Constantes

		#region	Variables
		const string KEYQDESCRIPCIONTIPO = "Tipo";

		#endregion Variables

		private	void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.PonerTitulo();
					this.EstadoControles();
					//Graba	en el Log la acción	ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Ventas",this.ToString(),"Se	consultó las Ventas	Presupuestadas.",Enumerados.NivelesErrorLog.I.ToString()));				
					this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Convert.ToInt32(this.hGridPagina.Value));
				}
				catch(SIMAExcepcionLog oSIMAExcepcionLog)
				{
					ltlMensaje.Text	= Helper.MensajeAlert(oSIMAExcepcionLog.Mensaje);					
				}
				catch(SIMAExcepcionIU oSIMAExcepcionIU)
				{
					ltlMensaje.Text	= Helper.MensajeAlert(oSIMAExcepcionIU.Mensaje);					
				}
				catch(SIMAExcepcionDominio oSIMAExcepcionDominio)
				{
					ltlMensaje.Text	= Helper.MensajeAlert(oSIMAExcepcionDominio.Mensaje);					
				}
				catch(Exception	oException)
				{
					SIMAExcepcionIU	oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Utilitario.Constantes.CODIGOERRORGENERICO,oException.Message);
					Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
				}
			}
		}

		#region	Web	Form Designer generated	code
		override protected void	OnInit(EventArgs e)
		{
			//
			// CODEGEN:	This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		///	<summary>
		///	Required method	for	Designer support - do not modify
		///	the	contents of	this method	with the code editor.
		///	</summary>
		private	void InitializeComponent()
		{	 
			this.ibtnFiltrar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnFiltrar_Click);
			this.ibtnEliminarFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminarFiltro_Click);
			this.ibtnImprimir.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnImprimir_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members
		public void LlenarGrilla()
		{
			// TODO:  Add ConsultarDetalleVentasPresupuestadas.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarDetalleVentasPresupuestadas.LlenarGrillaOrdenamiento implementation
		}

		public DataTable ObtenerDatos()
		{
			DataTable dtVentas = new DataTable();
			CVentasPresupuestadas oCVentasPresupuestadas = new CVentasPresupuestadas();
			CVentasReales oCVentasReales = new CVentasReales();

			if(Convert.ToInt32(Page.Request.QueryString[KEYQANO])>= DateTime.Now.Year)
			{
				return oCVentasPresupuestadas.ListarTodosGrillaMensualVentasPresupuestadas(Convert.ToInt32(Page.Request.QueryString[KEYQANO]),Convert.ToInt32(Page.Request.QueryString[KEYSINDICEMES]),Convert.ToInt32(Page.Request.QueryString[KEYQIDVERSION]),Convert.ToInt32(Page.Request.QueryString[KEYQIDCENTROOPERATIVO]));
			}
			else
			{
				return oCVentasReales.ListarTodosGrillaMensualVentasEjecutadas(Convert.ToInt32(Page.Request.QueryString[KEYQANO]),Convert.ToInt32(Page.Request.QueryString[KEYSINDICEMES]),Convert.ToInt32(Page.Request.QueryString[KEYQIDCENTROOPERATIVO]));
			}
		}
		public void	LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dtVentas = this.ObtenerDatos();

			if(dtVentas!=null)
			{
				DataView dwVentas =	dtVentas.DefaultView;
				dwVentas.Sort =	columnaOrdenar;
				dwVentas.RowFilter = Helper.ObtenerFiltro(this);

				if(dwVentas.Count == 0)
				{
					grid.DataSource = null;
					lblResultado.Visible = true;
					ibtnImprimir.Visible = false;
					
					if(Convert.ToInt32(Page.Request.QueryString[KEYQANO])>= DateTime.Now.Year)
					{
						lblResultado.Text = GRILLAVACIAVENTAPRESUPUESTADA;
					}
					else
					{
						lblResultado.Text = GRILLAVACIAVENTAREAL;
					}					
				}
				else
				{
					grid.DataSource	= dwVentas;
					grid.CurrentPageIndex = indicePagina;
					grid.Columns[POSICIONFOOTERTOTAL].FooterText = dwVentas.Count.ToString();
					grid.Columns[POSICIONFOOTERTOTALMONTO].FooterText = Helper.TotalizarDataView(dwVentas,Enumerados.ColumnasVentasPresupuestadas.MONTO.ToString())[0].ToString(Utilitario.Constantes.FORMATODECIMAL4);
					lblResultado.Visible = false;
				}

				CImpresion oCImpresion = new CImpresion();
				if(Convert.ToInt32(Page.Request.QueryString[KEYQANO])>= DateTime.Now.Year)
				{
					oCImpresion.GuardarDataImprimirExportar(dwVentas.Table,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGODETALLEVENTASPRESUPUESTADAS),columnaOrdenar,indicePagina);
				}
				else
				{
					oCImpresion.GuardarDataImprimirExportar(dwVentas.Table,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGODETALLEVENTASEJECUTADAS),columnaOrdenar,indicePagina);
				}
			}
			else
			{
				grid.DataSource	= dtVentas;
				lblResultado.Visible = true;
				ibtnImprimir.Visible = false;
				
				if(Convert.ToInt32(Page.Request.QueryString[KEYQANO])>= DateTime.Now.Year)
				{
					lblResultado.Text =	GRILLAVACIAVENTAPRESUPUESTADA;
				}
				else
				{
					lblResultado.Text =	GRILLAVACIAVENTAREAL;
				}
			}
			try
			{
				grid.DataBind();
			}
			catch(Exception	ex)
			{
				string a = ex.Message;
				grid.CurrentPageIndex =	0;
				grid.DataBind();
			}
		}
		public void LlenarCombos()
		{
			// TODO:  Add ConsultarDetalleVentasPresupuestadas.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add ConsultarDetalleVentasPresupuestadas.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarDetalleVentasPresupuestadas.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarDetalleVentasPresupuestadas.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			ltlMensaje.Text = Helper.PopupImpresion(URLIMPRESION,770,500,false,false,false,true,true);
		}
		public void Exportar()
		{
			// TODO:  Add ConsultarDetalleVentasPresupuestadas.Exportar implementation
		}

		public void	ConfigurarAccesoControles()
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

		public bool	ValidarFiltros()
		{
			return true;
		}

		#endregion

		
		public void PonerTitulo()
		{  
			this.lblCentroOperativo.Text = Page.Request.QueryString[CENTROOPERATIVO];

			if(Convert.ToInt32(Page.Request.QueryString[KEYQANO])>= DateTime.Now.Year)
			{
				this.lblPagina.Text = NOMBRERUTAVENTAPRESUPUESTADA;	
				this.lblTitulo.Text = VENTASPRESUPUESTADAS;
				this.lblAno.Text = Page.Request.QueryString[KEYQNOMBREMES]+ Utilitario.Constantes.ESPACIO + Utilitario.Constantes.LINEA + Utilitario.Constantes.ESPACIO + 
								   Page.Request.QueryString[KEYQANO] + Utilitario.Constantes.ESPACIO + Utilitario.Constantes.SEPARADORFECHA + 
								   VERSION + Utilitario.Constantes.ESPACIO +
					               Page.Request.QueryString[KEYQIDVERSION];
			}
			else
			{
				this.lblPagina.Text = NOMBRERUTAVENTAPRESUPUESTADA;
				this.lblTitulo.Text = VENTASREALES;
				this.lblAno.Text = Page.Request.QueryString[KEYQNOMBREMES]+ Utilitario.Constantes.ESPACIO + Utilitario.Constantes.LINEA + Utilitario.Constantes.ESPACIO + Page.Request.QueryString[KEYQANO];
			}			
		}

		public void EstadoControles()
		{
			Helper.ReestablecerPagina(this);
		}
		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
		
				if(Convert.ToInt32(Page.Request.QueryString[KEYQANO]) >= DateTime.Today.Year)
				{
					e.Item.Cells[POSICIONCONTADOR].Attributes.Add(Utilitario.Constantes.EVENTOCLICK, Helper.HistorialIrAdelantePersonalizado(INDICEPAGINA,PAGINASORT) + Utilitario.Constantes.SIGNOPUNTOYCOMA +  
																  Helper.MostrarVentana(URLDETALLE, KEYQID+ Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr[IDVENTA]) + Utilitario.Constantes.SIGNOAMPERSON +
																						Utilitario.Constantes.KEYMODOPAGINA +  Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.C.ToString()));
				}
				else
				{
					e.Item.Cells[POSICIONCONTADOR].Attributes.Add(Utilitario.Constantes.EVENTOCLICK, Helper.HistorialIrAdelantePersonalizado(INDICEPAGINA,PAGINASORT) + Utilitario.Constantes.SIGNOPUNTOYCOMA + 
																  Helper.MostrarVentana(URLDETALLEREAL, KEYQID + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr[IDVENTA]) + Utilitario.Constantes.SIGNOAMPERSON +
																						Utilitario.Constantes.KEYMODOPAGINA +  Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.C.ToString()));
				}

				e.Item.Cells[POSICIONCONTADOR].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				e.Item.Cells[POSICIONCONTADOR].Font.Underline=true;
				e.Item.Cells[POSICIONCONTADOR].ForeColor = System.Drawing.Color.Blue;

				e.Item.Cells[POSICIONFOOTERTOTALMONTO].Text= Convert.ToDouble(e.Item.Cells[POSICIONFOOTERTOTALMONTO].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				Helper.FiltroporSeleccionConfiguraColumna(e,grid); 
			}	

		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.hGridPagina.Value = e.NewPageIndex.ToString();
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.hGridPaginaSort.Value = Helper.GenerarExpresionOrdenamiento(e.SortExpression);
			this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Helper.ObtenerIndicePagina());
		}

		private void ibtnFiltrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			ltlMensaje.Text= Utilitario.Helper.ElaborarFiltro(this.ObtenerDatos()
				,Constantes.SIGNOASTERISCO + Utilitario.Enumerados.ColumnasVentasPresupuestadas.SECTOR.ToString()+ ";Sector"
				,Constantes.SIGNOASTERISCO + LINEANEGOCIO + ";Linea de Negocio"
 				,Utilitario.Enumerados.ColumnasVentasPresupuestadas.RAZONSOCIAL.ToString()+ "; Cliente"
				,PROYECTO + ";Proyecto"
				,Utilitario.Enumerados.ColumnasVentasPresupuestadas.MONTO.ToString()+ ";Monto"
				,FECHA+ ";Fecha");
	
		}

		private void ibtnEliminarFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}

		private	void ibtnImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{	
			this.Imprimir();
		}
	}
}
	