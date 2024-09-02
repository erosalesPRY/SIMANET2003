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
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;
using SIMA.Controladoras.GestionComercial;

namespace SIMA.SimaNetWeb.GestionComercial.ComunicacionImagen
{
	/// <summary>
	/// Summary description for ConsultarGastosDirectorio.
	/// </summary>
	public class ConsultarGastosDirectorio : System.Web.UI.Page,IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblPosicionRegistro;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminarFiltro;
		protected projDataGridWeb.DataGridWeb dgResumen;
		#endregion Controles		

		#region Constantes
		//Ordenamiento
		const string COLORDENAMIENTO = "IdGastoDirectorio";
		const int POSICIONREGISTROTOTAL = 0;
		
		//Paginas
		const string URLIMPRESION = "PopupImpresionConsultarGastosDirectorio.aspx";
		
		//Otros
		const string GRILLAVACIA ="No existe ningun Gasto del Directorio.";
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
					
					this.LlenarJScript();

					Helper.ReiniciarSession();

					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionComercial",this.ToString(),"Se consultaron los gastos del Directorio.",Enumerados.NivelesErrorLog.I.ToString()));

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
			// TODO:  Add ConsultarGastosDirectorio.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarGastosDirectorio.LlenarGrillaOrdenamiento implementation
		}

		public DataTable ObtenerDatos()
		{
			CGastoDirectorio oCGastoDirectorio = new CGastoDirectorio();
			return oCGastoDirectorio.ConsultarGastosDirectorio();
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
		{
			DataTable dtGastoDirectorio = this.ObtenerDatos();

			if(dtGastoDirectorio!=null)
			{
				DataView dwGastoDirectorio = dtGastoDirectorio.DefaultView;
				dwGastoDirectorio.Sort = columnaOrdenar;
				dwGastoDirectorio.RowFilter = Helper.ObtenerFiltro(this);
				
				if(dwGastoDirectorio.Count>0)
				{
					grid.DataSource = dwGastoDirectorio;
					this.GenerarResumen(dwGastoDirectorio);
					grid.Columns[PosicionFooterTotal].FooterText = dwGastoDirectorio.Count.ToString();
					this.lblResultado.Visible = false;
				}
				else
				{
					grid.DataSource = null;
					lblResultado.Visible = true;
					lblResultado.Text = GRILLAVACIA;
				}
				
				CImpresion oCImpresion = new CImpresion();
				oCImpresion.GuardarDataImprimirExportar(dtGastoDirectorio,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGOTITULOREPORTEGASTODIRECTORIO),columnaOrdenar,indicePagina);	
			}
			else
			{
				grid.DataSource = dtGastoDirectorio;
				lblResultado.Text = GRILLAVACIA;
			}
			
			try
			{
				grid.DataBind();
			}
			catch	
			{
				grid.CurrentPageIndex = 0;
				grid.DataBind();
			}
		}

		public void LlenarCombos()
		{
			// TODO:  Add ConsultarGastosDirectorio.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add ConsultarGastosDirectorio.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarGastosDirectorio.LlenarJScript implementation			
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarGastosDirectorio.RegistrarJScript implementation			
		}

		public void Imprimir()
		{
			ltlMensaje.Text = Helper.PopupImpresion(URLIMPRESION,750,500,false,false,false,true,true);
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarGastosDirectorio.Exportar implementation			
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add ConsultarGastosDirectorio.ConfigurarAccesoControles implementation

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

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			grid.CurrentPageIndex=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(e.SortExpression),Helper.ObtenerIndicePagina());
		}

		private void ibtnImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Imprimir();
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
			ltlMensaje.Text= Utilitario.Helper.ElaborarFiltro(this.ObtenerDatos()
				,Utilitario.Enumerados.ColumnasGastosDirectorio.NroDocumento.ToString()+";Nro de Documento"
				,Utilitario.Enumerados.ColumnasGastosDirectorio.Descripcion.ToString()+ ";Descripcion"
				,Utilitario.Enumerados.ColumnasGastosDirectorio.Lugar.ToString()+ ";Lugar"
				,Constantes.SIGNOASTERISCO + Utilitario.Enumerados.ColumnasGastosDirectorio.Nombre.ToString()+ ";Centro de Costo"
				,Utilitario.Enumerados.ColumnasGastosDirectorio.Monto.ToString()+ ";Monto"
				,Constantes.SIGNOASTERISCO + Utilitario.Enumerados.ColumnasGastosDirectorio.Moneda.ToString()+ ";Moneda"
				,Utilitario.Enumerados.ColumnasGastosDirectorio.FechaGasto.ToString()+ ";Fecha de Gasto"
				);
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