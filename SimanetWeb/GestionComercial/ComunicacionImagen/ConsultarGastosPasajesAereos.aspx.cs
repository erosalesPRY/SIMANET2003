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
using SIMA.Controladoras.GestionComercial;
using SIMA.Controladoras.General;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;

namespace SIMA.SimaNetWeb.GestionComercial.ComunicacionImagen
{
	/// <summary>
	/// Summary description for ConsultarGastosPasajesAereos.
	/// </summary>
	public class ConsultarGastosPasajesAereos : System.Web.UI.Page,IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblFechaInicio;
		protected System.Web.UI.WebControls.Label lblFechaFin;
		protected eWorld.UI.CalendarPopup CalFechaInicio;
		protected eWorld.UI.CalendarPopup CalFechaFin;
		protected System.Web.UI.WebControls.DomValidators.CompareDomValidator cvFechas;
		protected System.Web.UI.WebControls.ImageButton ibtnConsultar;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminarFiltro;
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected projDataGridWeb.DataGridWeb dgResumen;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary vSum;
		#endregion Controles

		#region Constantes
		//Ordenamiento
		const string COLORDENAMIENTO = "NombreCentroOperativo";
		const int CantidadCero = 0;

		//Paginas
		const string URLIMPRESION = "PopupImpresionConsultarGastosPasajesAereos.aspx";
		
		//Key Session y QueryString
		
		//Otros
		const string GRILLAVACIA ="No existe ningun Gasto de Pasaje Aereo con los filtros seleccionados.";
		const int PosicionFooterTotal = 1;
		const int PosicionResumen = 15;
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

					this.LlenarCombos();

					if(this.ValidarFiltros())
					{
						//Graba en el Log la acci�n ejecutada
						LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se consultaron los Gastos de Pasajes Aereos con Fechas entre el " + CalFechaInicio.SelectedDate.ToString() + " y el " + CalFechaFin.SelectedDate.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));
					
						this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO),Utilitario.Constantes.INDICEPAGINADEFAULT);
					}
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
			this.ibtnConsultar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnConsultar_Click);
			this.ibtnFiltrar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnFiltrar_Click);
			this.ibtnEliminarFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminarFiltro_Click);
			this.ibtnImprimir.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnImprimir_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.dgResumen.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgResumen_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add ConsultarGastosPasajesAereos.LlenarGrilla implementation
		}

		
		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarGastosPasajesAereos.LlenarGrillaOrdenamiento implementation
		}

		public DataTable ObtenerDatos()
		{
			CGastoPasajeAereo oCGastoPasajeAereo =  new CGastoPasajeAereo();
			return oCGastoPasajeAereo.ConsultarGastosPasajesAereosPorFecha(CalFechaInicio.SelectedDate,CalFechaFin.SelectedDate);
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
		{
			DataTable dtGastoPasajeAereo = this.ObtenerDatos();
			
			if(dtGastoPasajeAereo!=null)
			{
				DataView dwGastoPasajeAereo = dtGastoPasajeAereo.DefaultView;
				dwGastoPasajeAereo.Sort = columnaOrdenar ;
				dwGastoPasajeAereo.RowFilter = Helper.ObtenerFiltro(this);

				if(dwGastoPasajeAereo.Count > CantidadCero)
				{
					grid.DataSource = dwGastoPasajeAereo;
					this.GenerarResumen(dwGastoPasajeAereo);
					grid.Columns[PosicionFooterTotal].FooterText = dwGastoPasajeAereo.Count.ToString();
					lblResultado.Visible = false;
				}
				else
				{
					grid.DataSource = null;
					dgResumen.DataSource = null;
					lblResultado.Visible = true;
					lblResultado.Text = GRILLAVACIA;
				}

				CImpresion oCImpresion = new CImpresion();
				oCImpresion.GuardarDataImprimirExportar(dwGastoPasajeAereo.Table,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGOTITULOREPORTEGASTOPASAJES),columnaOrdenar,indicePagina);
			}
			else
			{
				grid.DataSource = dtGastoPasajeAereo;
				lblResultado.Visible = true;
				lblResultado.Text = GRILLAVACIA;
			}
			try
			{
				grid.DataBind();
			}
			catch(Exception ex)
			{
				string a = ex.ToString();
				grid.CurrentPageIndex = 0;
				grid.DataBind();
			}
		}

		public void LlenarCombos()
		{
			CalFechaInicio.SelectedDate = Helper.ObtenerFechaInicioBusqueda();
		}

		public void LlenarDatos()
		{
			// TODO:  Add ConsultarGastosPasajesAereos.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			cvFechas.ErrorMessage = Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJERANGOFECHAS);
			cvFechas.ToolTip = Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJERANGOFECHAS);	
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarGastosPasajesAereos.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			ltlMensaje.Text = Helper.PopupImpresion(URLIMPRESION,750,500,false,false,false,true,true);
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarGastosPasajesAereos.Exportar implementation
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
			if(!Helper.ValidarRangoFechas(CalFechaInicio.SelectedDate,CalFechaFin.SelectedDate))
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJERANGOFECHAS));
				return false;
			}
			else
			{
				return true;
			}
		}

		#endregion

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(e.SortExpression),Helper.ObtenerIndicePagina());
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			grid.CurrentPageIndex=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);
		}

		private void ibtnImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Imprimir();
		}

		private void ibtnConsultar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				Helper.ReiniciarSession();

				if(this.ValidarFiltros())
				{
					//Graba en el Log la acci�n ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se consultaron los Gastos de Pasajes Aereos con Fechas entre el " + CalFechaInicio.SelectedDate.ToString() + " y el " + CalFechaFin.SelectedDate.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));
					
					this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO),Utilitario.Constantes.INDICEPAGINADEFAULT);
				}
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

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				e.Item.Cells[0].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				Helper.FiltroporSeleccionConfiguraColumna(e,grid);
			}
		}

		private void ibtnFiltrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if(this.ValidarFiltros())
			{
				ltlMensaje.Text= Utilitario.Helper.ElaborarFiltro(this.ObtenerDatos()
					,Constantes.SIGNOASTERISCO + Utilitario.Enumerados.ColumnasGastosPasajesAereos.NombreCentroOperativo.ToString()+";Centro Operativo"
					,Utilitario.Enumerados.ColumnasGastosPasajesAereos.NroDocumento.ToString()+ ";Nro de Documento"
					,Utilitario.Enumerados.ColumnasGastosPasajesAereos.NombrePersonal.ToString()+ ";Nombre de Personal"
					,Constantes.SIGNOASTERISCO + Utilitario.Enumerados.ColumnasGastosPasajesAereos.NombreAerolinea.ToString()+ ";Aerolinea"
					,Constantes.SIGNOASTERISCO + Utilitario.Enumerados.ColumnasGastosPasajesAereos.Ruta.ToString()+ ";Ruta"
					,Constantes.SIGNOASTERISCO + Utilitario.Enumerados.ColumnasGastosPasajesAereos.NombreCentroCosto.ToString()+ ";Centro Costo"
					,Utilitario.Enumerados.ColumnasGastosPasajesAereos.Monto.ToString()+ ";Monto"
					,Constantes.SIGNOASTERISCO + Utilitario.Enumerados.ColumnasGastosPasajesAereos.Moneda.ToString()+ ";Moneda"
					,Utilitario.Enumerados.ColumnasGastosPasajesAereos.FechaGasto.ToString()+ ";Fecha de Gasto"
					);
			}
		}

		private void ibtnEliminarFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}

		private void GenerarResumen(DataView dt)
		{
			if (dt!=null)
			{
				int NroResumen1	 = PosicionResumen;
				CResumenItem oCResumenItem1 = new CResumenItem();
				DataTable dtFinal1 = Helper.Resumen(oCResumenItem1.ObtenerConfiDataResumen(NroResumen1),dt);
				dgResumen.DataSource =dtFinal1;
			}
			else
			{
				dgResumen.DataSource =dt;
			}
			try
			{
				dgResumen.DataBind();
			}
			catch(Exception ex)
			{
				string a = ex.Message;
			}
		}

		private void dgResumen_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				Helper.FiltroporSeleccionConfiguraColumna(e,dgResumen);
			}
		}
	}
}