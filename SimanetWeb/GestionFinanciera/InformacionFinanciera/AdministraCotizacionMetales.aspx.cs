using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using SIMA.SimaNetWeb.InterfacesIU;
using SIMA.Controladoras.General;
using SIMA.Controladoras.GestionFinanciera;
using SIMA.EntidadesNegocio.GestionFinanciera;
using SIMA.Utilitario;
using NetAccessControl;
using SIMA.ManejadorExcepcion;
using SIMA.Log;

namespace SIMA.SimaNetWeb.GestionFinanciera.InformacionFinanciera
{
	/// <summary>
	/// Summary description for AdministraCotizacionMetales.
	/// </summary>
	public class AdministraCotizacionMetales : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		#region Constantes
		const string GRILLAVACIA ="No existe ningún Registro.";  
		const string CONTROLINK="hlkEntidad";
		const string URLDETALLE="DetalleCotizacionMetales.aspx?";
		const string COLORDENAMIENTO = "descripcion";

		const string KEYIDFECHA = "Fecha";
		
		const string KEYIDMETAL = "idMetal";
		const string KEYMETALDESCRIPCION = "Metaldescrip";
		const string KEYIDMERCADO = "idMercado";
		const string KEYMERCADODESCRIPCION = "Mercadodescrip";


		const string CAMPO1 ="hlkNewYork";
		const string CAMPO2 ="hlkLondres";
		const string CAMPO3 ="hlkZurich";

		//Otros
		const string SESSIONCOTIZA ="Cotiza";
		const string COLUMNAMODO ="Modo";


		#endregion
		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label Label1;
		protected eWorld.UI.CalendarPopup CalFecha;
		protected System.Web.UI.WebControls.Button btnMostrar;
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.HtmlControls.HtmlTable TblTabs;
		protected System.Web.UI.WebControls.DropDownList ddlbMercado;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hModo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidMetal;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					if (Session[SESSIONCOTIZA]==null )
					{
						Session[SESSIONCOTIZA]= DateTime.Now.ToShortDateString();
					}
					this.CalFecha.SelectedDate = Convert.ToDateTime(Session[SESSIONCOTIZA]);
					this.ConfigurarAccesoControles();
					this.LlenarJScript();
					this.LlenarCombos();
					Helper.ReiniciarSession();
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionFinanciera",this.ToString(),"Se consultó Administración de Cotización de Metales.",Enumerados.NivelesErrorLog.I.ToString()));
					Helper.CalendarioControlStyle(this.CalFecha);
					this.LlenarGrillaOrdenamientoPaginacion(Utilitario.Constantes.VACIO,Utilitario.Constantes.INDICEPAGINADEFAULT);

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
			// Put user code to initialize the page here
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
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.btnMostrar.Click += new System.EventHandler(this.btnMostrar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add AdministraCotizacionMetales.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministraCotizacionMetales.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			CCotizaMetales oCCotizaMetales = new CCotizaMetales();

//			DataTable dtGeneral = 
//				oCCotizaMetales.AdministrarCotizaciondeMetales(
//										this.ddlbMercado.SelectedValue
//										,this.CalFecha.SelectedDate.ToShortDateString());

			DataTable dtGeneral = 
				oCCotizaMetales.AdministrarCotizaciondeMetales(
				Convert.ToInt32(this.ddlbMercado.SelectedValue)
				,Convert.ToDateTime(this.CalFecha.SelectedDate.ToShortDateString()));
			
			if(dtGeneral!=null)
			{
				DataView dwGeneral = dtGeneral.DefaultView;
				dwGeneral.Sort = columnaOrdenar ;
				//this.LlenarDatos(dwGeneral);
				dwGeneral.RowFilter = Helper.ObtenerFiltro(this);
				grid.DataSource = dwGeneral;
				CImpresion oCImpresion = new CImpresion();
				lblResultado.Visible = false;

			}
			else
			{
				grid.DataSource = dtGeneral;
				lblResultado.Visible = true;
				lblResultado.Text = GRILLAVACIA;
				ibtnImprimir.Visible = false;
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
			// TODO:  Add AdministraCotizacionMetales.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			this.CargarMercados();
		}
		private void CargarMercados()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			this.ddlbMercado.DataSource= oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraMercados));
			ddlbMercado.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbMercado.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbMercado.DataBind();			
		}


		public void LlenarDatos()
		{
			// TODO:  Add AdministraCotizacionMetales.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add AdministraCotizacionMetales.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministraCotizacionMetales.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministraCotizacionMetales.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministraCotizacionMetales.Exportar implementation
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
			// TODO:  Add AdministraCotizacionMetales.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			// TODO:  Add AdministraCotizacionMetales.Agregar implementation
		}

		public void Modificar()
		{
			// TODO:  Add AdministraCotizacionMetales.Modificar implementation
		}

		public void Eliminar()
		{
			// TODO:  Add AdministraCotizacionMetales.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			// TODO:  Add AdministraCotizacionMetales.CargarModoPagina implementation
		}

		public void CargarModoNuevo()
		{
			// TODO:  Add AdministraCotizacionMetales.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			// TODO:  Add AdministraCotizacionMetales.CargarModoModificar implementation
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add AdministraCotizacionMetales.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add AdministraCotizacionMetales.ValidarCampos implementation
			return false;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add AdministraCotizacionMetales.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add AdministraCotizacionMetales.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{				
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,Helper.MostrarDatosEnCajaTexto("hModo",dr[COLUMNAMODO].ToString()));

				e.Item.Cells[0].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				e.Item.Cells[0].Style.Add(Utilitario.Constantes.CURSOR,Utilitario.Constantes.TIPOCURSORMANO);
				e.Item.Cells[0].ForeColor=Color.Blue;
				e.Item.Cells[0].Font.Underline=true;
				e.Item.Cells[0].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.HistorialIrAdelantePersonalizado("CalFecha","ddlbMercado") + Utilitario.Constantes.SIGNOPUNTOYCOMA +
					Helper.MostrarVentana(URLDETALLE,
						KEYIDFECHA + Utilitario.Constantes.SIGNOIGUAL  + this.CalFecha.SelectedDate.ToShortDateString()
						+ Utilitario.Constantes.SIGNOAMPERSON 
						+ KEYIDMERCADO + Utilitario.Constantes.SIGNOIGUAL  + this.ddlbMercado.SelectedValue.ToString()
						+ Utilitario.Constantes.SIGNOAMPERSON 
						+ KEYIDMETAL + Utilitario.Constantes.SIGNOIGUAL  + dr[Utilitario.Enumerados.FinColumnaCotizaMetales.Idmetal.ToString()].ToString()
						+ Utilitario.Constantes.SIGNOAMPERSON 
						+ Utilitario.Constantes.KEYMODOPAGINA +  Utilitario.Constantes.SIGNOIGUAL + dr[COLUMNAMODO].ToString()
						+ Utilitario.Constantes.SIGNOAMPERSON 
						+ KEYMETALDESCRIPCION + Utilitario.Constantes.SIGNOIGUAL  + e.Item.Cells[1].Text
						+ Utilitario.Constantes.SIGNOAMPERSON 
						+ KEYMERCADODESCRIPCION + Utilitario.Constantes.SIGNOIGUAL  + this.ddlbMercado.SelectedItem.Text
					));

				e.Item.Cells[2].Text = Convert.ToDouble(e.Item.Cells[2].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);

			}							
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void btnMostrar_Click(object sender, System.EventArgs e)
		{
			Session[SESSIONCOTIZA]=this.CalFecha.SelectedDate.ToShortDateString();
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO),Utilitario.Constantes.INDICEPAGINADEFAULT);
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

	}
}
