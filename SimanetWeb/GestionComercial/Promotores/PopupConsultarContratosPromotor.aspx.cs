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
using SIMA.Controladoras.GestionComercial;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using NullableTypes;
using System.IO;
using SIMA.EntidadesNegocio.GestionComercial;
using MetaBuilders.WebControls;

namespace SIMA.SimaNetWeb.GestionComercial.Promotores
{
	/// <summary>
	/// Summary description for PopupConsultarContratosPromotor.
	/// </summary>
	public class PopupConsultarContratosPromotor : System.Web.UI.Page, IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label lblNombre;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblTitulo;
		#endregion

		#region Constantes

		//Key Session y QueryString
		const string KEYQID = "IdPromotor";

		//Otros
		const string GRILLAVACIA = "No existe ningun contrato del Promotor";
		const int POSICIONFOOTERNOMBRETOTAL = 0;
		const string TEXTOFOOTERTOTAL = "TOTAL";
		const int POSICIONFOOTERTOTAL = 2;

		#endregion
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarJScript();
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionComercial",this.ToString(),"Se consultaron los contratos del Promotor.",Enumerados.NivelesErrorLog.I.ToString()));
					this.LlenarGrilla();
					
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			CPromotores oCPromotores =  new CPromotores();

			lblNombre.Text = oCPromotores.ObtenerNombrePromotor(Convert.ToInt32(Page.Request.QueryString[KEYQID]));
			
			DataTable dtPromotores =  oCPromotores.ListarContratosPromotor(Convert.ToInt32(Page.Request.QueryString[KEYQID]));
			
			if(dtPromotores!=null)
			{
				DataView dwPromotores = dtPromotores.DefaultView;
				grid.DataSource = dwPromotores;
				dwPromotores.RowFilter = Helper.ObtenerFiltro(this);

				if (dwPromotores.Count == 0)
				{
					grid.DataSource = null; 
					lblResultado.Text = GRILLAVACIA;
					lblResultado.Visible = true;
				}
				else
				{
					grid.DataSource = dwPromotores;
					grid.Columns[POSICIONFOOTERNOMBRETOTAL].FooterText = TEXTOFOOTERTOTAL;
					grid.Columns[POSICIONFOOTERTOTAL].FooterText = dwPromotores.Count.ToString();
					lblResultado.Visible = false;
				}

				CImpresion oCImpresion = new CImpresion();
				oCImpresion.GuardarDataImprimirExportar(dwPromotores.Table,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGOTITULOREPORTELISTARTODOSCONTRATOSPROMOTORES));
			}
			else
			{
				grid.DataSource = dtPromotores;
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
				grid.CurrentPageIndex = 0;
				grid.DataBind();
			}
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add PopupConsultarContratosPromotor.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add PopupConsultarContratosPromotor.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add PopupConsultarContratosPromotor.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add PopupConsultarContratosPromotor.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add PopupConsultarContratosPromotor.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add PopupConsultarContratosPromotor.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add PopupConsultarContratosPromotor.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add PopupConsultarContratosPromotor.Exportar implementation
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
			// TODO:  Add PopupConsultarContratosPromotor.ValidarFiltros implementation
			return false;
		}

		#endregion
	}
}
