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


namespace SIMA.SimaNetWeb.GestionFinanciera.PrestamosBancarios
{
	public class AdministrarCronogramadePago : System.Web.UI.Page,IPaginaBase
	{
		#region Constantes
			const string KEYIDPRESTAMO = "idPTM";
			const string KEYIDPERIODO ="Periodo";
			const string GRILLAVACIA ="No existe ningún Registro.";  
		#endregion
		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminaFiltro;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.ImageButton ibtnAgregar;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnFiltrarSeleccion;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPaginaSort;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
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
					this.LlenarCombos();
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
					ltlMensaje.Text = Helper.MsgdbErrMostrarMesaje(true,oSIMAExcepcionIU.Error.ToString());
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
			// TODO:  Add AdministrarCronogramadePago.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarCronogramadePago.LlenarGrillaOrdenamiento implementation
		}

		private DataTable ObtenerDatos()
		{
			return ((CPrestamoCronogramaPago) new CPrestamoCronogramaPago()).AdministrarDetallePrestamoCronogramaPago(Convert.ToInt32(Page.Request.Params[KEYIDPERIODO])
																														,Convert.ToInt32(Page.Request.Params[KEYIDPRESTAMO])
																														,Utilitario.Constantes.IDDEFAULT.ToString());
		}


		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dt= this.ObtenerDatos();
			if(dt!=null)
			{
				DataView dw= dt.DefaultView;
				dw.RowFilter = Helper.ObtenerFiltro();
				dw.Sort = columnaOrdenar ;
				grid.Columns[Utilitario.Constantes.POSICIONFOOTERTOTAL].FooterText = Utilitario.Constantes.TEXTOFOOTERTOTAL + Utilitario.Constantes.ESPACIO + dw.Count.ToString();
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
			catch	
			{
				grid.CurrentPageIndex = 0;
				grid.DataBind();
			}			
		}

		public void LlenarCombos()
		{
			// TODO:  Add AdministrarCronogramadePago.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add AdministrarCronogramadePago.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add AdministrarCronogramadePago.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarCronogramadePago.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministrarCronogramadePago.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarCronogramadePago.Exportar implementation
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
			// TODO:  Add AdministrarCronogramadePago.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
		
		}
	}
}
