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

namespace SIMA.SimaNetWeb.GestionComercial.Cliente
{
	/// <summary>
	/// Summary description for PopupImpresionConsultarDetalleMontoCliente.
	/// </summary>
	public class PopupImpresionConsultarDetalleMontoCliente : System.Web.UI.Page
	{
		#region Controles
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblNombreRazonSocial;
		#endregion
	
		#region Constantes
		//Key Session y QueryString
		
		//Otros
		const string KEYQNOMBRE = "RazonSocial";
		const int CantidadCero = 0;
		const string GRILLAVACIA ="No existe ninguna Detalle de Monto de Cliente";  
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

				if(dwImpresion.Count > CantidadCero)
				{
					grid.DataSource = dwImpresion;
					lblResultado.Visible = false;
					grid.CurrentPageIndex = oCImpresion.ObtenerIndicePagina();
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
				grid.DataSource = dtImpresion;
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
			}
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add PopupImpresionConsultarCliente.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
		{
			// TODO:  Add PopupImpresionConsultarCliente.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add PopupImpresionConsultarCliente.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			lblTitulo.Text = CImpresion.ObtenerTituloReporte();
			lblNombreRazonSocial.Text = Convert.ToString(Page.Request.QueryString[KEYQNOMBRE]);
		}

		public void LlenarJScript()
		{
			// TODO:  Add PopupImpresionConsultarCliente.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add PopupImpresionConsultarCliente.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			ltlMensaje.Text=Helper.Imprimir();
		}

		public void Exportar()
		{
			// TODO:  Add PopupImpresionConsultarCliente.Exportar implementation
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

	}
}
