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
using SIMA.Controladoras.GestionFinanciera;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using NullableTypes;
using MetaBuilders.WebControls;
using System.Reflection;


namespace SIMA.SimaNetWeb.GestionFinanciera.PresupuestoVarios
{
	public class AdministrarTipodePresupuestoCuentas : System.Web.UI.Page,IPaginaBase
	{
		#region Constantes
			const string GRILLAVACIA ="No existe ningún Registro.";  
			const string KEYIDTIPOPRESUPUESTO ="idTipoPresupuesto";  
			const string KEYIDNOMBRETIPOPRESUPUESTO ="NombreTipoPresupuesto";
			
			const string KEYIDCENTROOPERATIVO ="centro";  
			const string KEYIDTIPOPRESUPUESTOCUENTA ="idTipoPresupuestoCta";  
			const string KEYIDPERIODO ="periodo";
			const string KEYIDMES ="idMes";
			const string KEYIDNOMBREMES ="NombreMes";

			const string URLPRESUPUESTOCUENTAGRUPOCC ="AdministrarTipodePresupuestoCuentasGruposCC.aspx?";

		//DataGrid and DataTable
		const string COLUMNAIDTIPOPTOCTA ="idTipoPresupuestoCuenta";
		const string COLUMNAIDCENTROOPERATIVO ="idCentroOperativo";

		
		#endregion

		#region Controles
			protected System.Web.UI.WebControls.Label lblRutaPagina;
			protected System.Web.UI.WebControls.Label lblPagina;
			protected System.Web.UI.WebControls.Label Label1;
			protected System.Web.UI.WebControls.Label Label2;
			protected projDataGridWeb.DataGridWeb grid;
			protected System.Web.UI.WebControls.Label lblResultado;
			protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
			protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPaginaSort;
			protected System.Web.UI.WebControls.Label lblPeriodo;
			protected System.Web.UI.WebControls.Label lblTipoPresupuesto;
			protected System.Web.UI.WebControls.Label lblMes;
			protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion
		private void Page_Load(object sender, System.EventArgs e)
		{
			this.grid.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(Utilitario.Helper.FooterSpan);
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					this.LlenarJScript();
					Helper.ReiniciarSession();
					this.LlenarDatos();
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Auditoria",this.ToString(),"Se consultó las Acciones Correctivas.",Enumerados.NivelesErrorLog.I.ToString()));
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
					ltlMensaje.Text = Helper.MsgdbErrMostrarMesaje(true,oSIMAExcepcionDominio.Error.ToString());					
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

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add AdministrarTipodePresupuestoCuentas.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarTipodePresupuestoCuentas.LlenarGrillaOrdenamiento implementation
		}
		private DataTable ObtenerDatos()
		{
			return ((CTipoPresupuestoCuenta)new CTipoPresupuestoCuenta()).AdministrarDetalleTiposdePresupuestoCuenta(
																													Convert.ToInt32(Page.Request.Params[KEYIDTIPOPRESUPUESTO])
																													,CNetAccessControl.GetIdUser()
																													,Convert.ToInt32(Page.Request.Params[KEYIDPERIODO])
																													,Convert.ToInt32(Page.Request.Params[KEYIDMES]));
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dt = this.ObtenerDatos();

			if(dt!=null)
			{
				DataView dw = dt.DefaultView;
				dw.Sort = columnaOrdenar ;
				dw.RowFilter= Utilitario.Helper.ObtenerFiltro();
				grid.Columns[Utilitario.Constantes.POSICIONFOOTERTOTAL].FooterText = Utilitario.Constantes.TEXTOFOOTERTOTAL + Utilitario.Constantes.ESPACIO + dw.Count.ToString();
				grid.DataSource = dw;
				grid.CurrentPageIndex =indicePagina;
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
			catch	
			{
				grid.CurrentPageIndex = 0;
				grid.DataBind();
			}
		}

		public void LlenarCombos()
		{
			// TODO:  Add AdministrarTipodePresupuestoCuentas.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			this.lblPeriodo.Text = Page.Request.Params[KEYIDPERIODO].ToString();
			this.lblMes.Text = Page.Request.Params[KEYIDNOMBREMES].ToString();
			this.lblTipoPresupuesto.Text = Page.Request.Params[KEYIDNOMBRETIPOPRESUPUESTO].ToString();
		}

		public void LlenarJScript()
		{
			// TODO:  Add AdministrarTipodePresupuestoCuentas.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarTipodePresupuestoCuentas.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministrarTipodePresupuestoCuentas.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarTipodePresupuestoCuentas.Exportar implementation
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
			// TODO:  Add AdministrarTipodePresupuestoCuentas.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);

				string parametros = KEYIDTIPOPRESUPUESTOCUENTA + Utilitario.Constantes.SIGNOIGUAL + dr[COLUMNAIDTIPOPTOCTA].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYIDNOMBRETIPOPRESUPUESTO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDNOMBRETIPOPRESUPUESTO].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + dr[COLUMNAIDCENTROOPERATIVO].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYIDPERIODO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDPERIODO].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYIDMES + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDMES].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYIDNOMBREMES + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDNOMBREMES].ToString();

				Helper.ConfiguraColumnaHyperLink(e.Item.Cells[0],grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex,
					Helper.HistorialIrAdelantePersonalizado(String.Empty),
					Helper.MostrarVentana(URLPRESUPUESTOCUENTAGRUPOCC,parametros));
			}			
		
		}
	}
}

