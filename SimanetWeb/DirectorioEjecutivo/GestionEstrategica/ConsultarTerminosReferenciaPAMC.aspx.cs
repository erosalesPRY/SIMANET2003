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
using SIMA.Controladoras.GestionEstrategica;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;


namespace SIMA.SimaNetWeb.DirectorioEjecutivo.GestionEstrategica
{
	
	public class ConsultarTerminosReferenciaPAMC : System.Web.UI.Page,IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.ImageButton btnActividad;
		protected projDataGridWeb.DataGridWeb gridActividades;
		protected System.Web.UI.WebControls.Label lblTituloActividad;
		protected System.Web.UI.HtmlControls.HtmlTable tblActividades;
		protected System.Web.UI.WebControls.Label ltlResultadoActividad;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblSeguimiento;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminaFiltro;
		#endregion

		#region Constantes
		private string JSVERIFICARSELECCIONFILA="return verificarSeleccionRb('hCodigo','"+ Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO) + "');";
		const string ANTERIOR = "ConsultarDetalleAgrupacionPAMC.aspx?";
		const string DETALLE = "ConsultaConsultorPAMC.aspx?";
		const string GRILLAVACIA="No existen Registros";
		const string KEYPAMCNIVEL="KEYPAMCNIVEL";
		const string KEYPAMCNOMBRENIVEL="KEYPAMCNOMBRENIVEL";
		const string KEYPAMCAGRUPACION="KEYPAMCAGRUPACION";
		const string KEYPAMCDETALLEAGRUPACION = "KEYPAMCDETALLEAGRUPACION";
		const string KEYPAMCTERMINOREFERENCIA="KEYPAMCTERMINOREFERENCIA";
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hNombre;
		const string COLORDENAMIENTO="Nombre";
		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					tblActividades.Visible = false;
					this.LlenarJScript();
					this.LlenarDatos();
					
					this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO,true),Helper.ObtenerIndicePagina());
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Utilitario.Enumerados.NombresdeModulo.GestiónComercial.ToString(),this.ToString(),"Se ingreso a la Consulta de Nivel Agrupamiento",Enumerados.NivelesErrorLog.I.ToString()));			
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

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			
		}

		public DataTable ObtenerDatos()
		{
			CPAMCTerminoReferencia oCPAMCTerminoReferencia = new CPAMCTerminoReferencia();
			return oCPAMCTerminoReferencia.ListarTodosGrilla(
				Convert.ToInt32(Page.Request.QueryString[KEYPAMCDETALLEAGRUPACION]));
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
		{
			DataTable dtAgrupacion =  this.ObtenerDatos();
			
			if(dtAgrupacion!=null)
			{
				DataView dwAgrupacion = dtAgrupacion.DefaultView;
				//dwAgrupacion.Sort = columnaOrdenar ;
				dwAgrupacion.RowFilter = Helper.ObtenerFiltro(this);
				if(dwAgrupacion.Count>0)
				{
					grid.DataSource = dwAgrupacion;
					grid.Columns[Utilitario.Constantes.POSICIONINDEXUNO].FooterText = dwAgrupacion.Count.ToString();
					this.lblResultado.Visible = false;
				}
				else
				{
					grid.DataSource = null;
					lblResultado.Visible = true;
					lblResultado.Text = GRILLAVACIA;
				}
				
			}
			else
			{
				grid.DataSource = dtAgrupacion;
				lblResultado.Text = GRILLAVACIA;
			}
			
			try
			{
				grid.DataBind();
			}
			catch	
			{
				grid.CurrentPageIndex = Utilitario.Constantes.ValorConstanteCero;
				grid.DataBind();
			}
		}

		public void LlenarCombos()
		{
		}

		public void LlenarDatos()
		{
			lblSeguimiento.Text = Page.Request.QueryString[KEYPAMCNOMBRENIVEL].ToUpper(); 
		}

		public void LlenarJScript()
		{
			btnActividad.Attributes.Add(Utilitario.Constantes.EVENTOCLICK ,JSVERIFICARSELECCIONFILA);
		}

		public void RegistrarJScript()
		{}

		public void Imprimir()
		{}

		public void Exportar()
		{}

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
			this.ibtnEliminaFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminaFiltro_Click);
			this.btnActividad.Click += new System.Web.UI.ImageClickEventHandler(this.btnActividad_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.gridActividades.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.gridActividades_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				e.Item.Cells[0].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.HISTORIALADELANTE + ";" +
					Helper.MostrarVentana(DETALLE,KEYPAMCDETALLEAGRUPACION + Utilitario.Constantes.SIGNOIGUAL + 
					Convert.ToString(dr["IDTERMINOREFERENCIAPAMC"].ToString()) +  
					Utilitario.Constantes.SIGNOAMPERSON +
						KEYPAMCNIVEL + 
							Utilitario.Constantes.SIGNOIGUAL +
								dr["Nombre"].ToString() +
					Utilitario.Constantes.SIGNOAMPERSON +
						KEYPAMCAGRUPACION + 
							Utilitario.Constantes.SIGNOIGUAL +
							Page.Request.QueryString[KEYPAMCAGRUPACION] + 
					Utilitario.Constantes.SIGNOAMPERSON +
						KEYPAMCTERMINOREFERENCIA +
							Utilitario.Constantes.SIGNOIGUAL +
								dr["IDTERMINOREFERENCIAPAMC"].ToString()
					));
				
				e.Item.Cells[Constantes.POSICIONCONTADOR].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				e.Item.Cells[Constantes.POSICIONCONTADOR].Font.Underline=true;
				e.Item.Cells[Constantes.POSICIONCONTADOR].ForeColor=Color.Blue;

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,
					Utilitario.Helper.MostrarDatosEnCajaTexto(hCodigo.ID,
					dr["IDTERMINOREFERENCIAPAMC"].ToString()),
					Utilitario.Helper.MostrarDatosEnCajaTexto(hNombre.ID,
					dr["Nombre"].ToString())
					);
				
				Helper.FiltroporSeleccionConfiguraColumna(e,grid);
			}
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			grid.CurrentPageIndex=e.NewPageIndex;
			HttpContext.Current.Session[Constantes.KEYSINDICEPAGINA]=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(e.SortExpression),Helper.ObtenerIndicePagina());
		}

		private void ibtnEliminaFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}

		private void ibtnFiltrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			ltlMensaje.Text = Utilitario.Helper.ElaborarFiltro(this.ObtenerDatos()
				,"nombre"+";nombre",
				"avance"+";avance"
				);
		}

		public void LlenarGrillaOrdenamientoPaginacionActividad(string columnaOrdenar,int indicePagina)
		{
			CPAMCActividad oCPAMCActividad  = new  CPAMCActividad ();
			DataTable dtNivel = oCPAMCActividad.ListarTodosGrilla(Convert.ToInt32(hCodigo.Value));

			if(dtNivel!=null)
			{
				DataView dwNivel = dtNivel.DefaultView;
				dwNivel.Sort = columnaOrdenar ;
				dwNivel.RowFilter = Helper.ObtenerFiltro(this);
				if(dwNivel.Count>0)
				{
					
					gridActividades.DataSource = dwNivel;
					gridActividades.CurrentPageIndex = indicePagina;
					gridActividades.Columns[Utilitario.Constantes.POSICIONINDEXUNO].FooterText = dwNivel.Count.ToString();
					this.lblTituloActividad.Text = "ACTIVIDADES DE " + hNombre.Value;
				}
				else
				{
					gridActividades.DataSource = null;
					lblTituloActividad.Visible = true;
					lblTituloActividad.Text = GRILLAVACIA;
					this.lblTituloActividad.Visible = false;
				}
				
			}
			else
			{
				gridActividades.DataSource = dtNivel;
				lblTituloActividad.Text = GRILLAVACIA;
			}
			
			try
			{
				gridActividades.DataBind();
			}
			catch	
			{
				gridActividades.CurrentPageIndex = Utilitario.Constantes.ValorConstanteCero;
				gridActividades.DataBind();
			}
		}

		private void gridActividades_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);

				e.Item.Cells[Constantes.POSICIONCONTADOR].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				e.Item.Cells[Constantes.POSICIONCONTADOR].Font.Underline=true;
				e.Item.Cells[Constantes.POSICIONCONTADOR].ForeColor=Color.Blue;
	
			}
		}

		private void btnActividad_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			tblActividades.Visible = true;
			LlenarGrillaOrdenamientoPaginacionActividad("Nombre",0);
		}
	}
}
