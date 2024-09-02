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

namespace SIMA.SimaNetWeb.GestionComercial.ComunicacionImagen
{
	/// <summary>
	/// Summary description for RequerimientosAsignados.
	/// </summary>
	public class PopupImpresionConsultarGastosDirectorio : System.Web.UI.Page,IPaginaBase
	{
		#region Controles

		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.DataGrid dgResumen;
		protected System.Web.UI.WebControls.DataGrid grid;

		#endregion Controles

		#region Constantes
		
		//Key Session y QueryString
		const string KEYQID = "Id";
		const int POSICIONREGISTROTOTAL = 0;
		const string GRILLAVACIA ="No existe ningun Gasto del Directorio.";
		const int PosicionResumen = 10;

		#endregion Constantes

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					this.LlenarDatos();
					this.LlenarGrilla();
					this.Imprimir();
				}
				catch(SIMAExcepcionLog oSIMAExcepcionLog)
				{
					ltlMensaje.Text = Helper.MensajeAlert(oSIMAExcepcionLog.Mensaje);					
				}
				catch(SIMAExcepcionIU oSIMAExcepcionIU)
				{
					ltlMensaje.Text = Helper.MensajeAlert(oSIMAExcepcionIU.Mensaje);					
				}
				catch(SIMAExcepcion oSIMAExcepcion)
				{
					ltlMensaje.Text = Helper.MensajeAlert(oSIMAExcepcion.Mensaje);					
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			CImpresion oCImpresion =  new CImpresion();
			DataTable dtImpresion =  oCImpresion.ObtenerDataImprimir();
			
			if(dtImpresion!=null)
			{
				DataView dwImpresion = dtImpresion.DefaultView;
				dwImpresion.Sort = oCImpresion.ObtenerColumnaOrdenamiento();

				if(dwImpresion.Count > 0)
				{
					grid.DataSource = dwImpresion;
					this.GenerarResumen(dwImpresion);
					grid.CurrentPageIndex = oCImpresion.ObtenerIndicePagina();
					lblResultado.Visible = false;
				}
				else
				{
					grid.DataSource = null;
					dgResumen.DataSource = null;
					lblResultado.Visible = true;
					lblResultado.Text = GRILLAVACIA;
				}
			}
			else
			{
				lblResultado.Text = GRILLAVACIA;
			}
			grid.DataBind();
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add PopupImpresionConsultarGastosDirectorio.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
		{
			// TODO:  Add PopupImpresionConsultarGastosDirectorio.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add PopupImpresionConsultarGastosDirectorio.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			lblTitulo.Text = CImpresion.ObtenerTituloReporte();
		}

		public void LlenarJScript()
		{
			// TODO:  Add PopupImpresionConsultarGastosDirectorio.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add PopupImpresionConsultarGastosDirectorio.RegistrandoJScript implementation
		}

		public void Imprimir()
		{
		 	ltlMensaje.Text=Helper.Imprimir();
		}

		public void Exportar()
		{
			// TODO:  Add PopupImpresionConsultarGastosDirectorio.Exportar implementation
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
	}
}