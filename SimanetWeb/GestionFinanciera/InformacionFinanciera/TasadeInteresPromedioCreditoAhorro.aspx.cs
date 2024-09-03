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
using SIMA.EntidadesNegocio.GestionFinanciera;
using SIMA.Utilitario;
using NetAccessControl;
using SIMA.ManejadorExcepcion;
using SIMA.Log;

namespace SIMA.SimaNetWeb.GestionFinanciera.InformacionFinanciera
{
	/// <summary>
	/// Summary description for TasadeInteresPromedioCreditoAhorro.
	/// </summary>
	public class TasadeInteresPromedioCreditoAhorro : System.Web.UI.Page, IPaginaBase
	{
		#region Constantes
		const string URLPRINCIPAL="../../Default.aspx";
		const string URLTIPO="tipoURL";
		
		//Otros
		const string ATRIBUTOSRC ="src";

		#endregion Constantes

		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.ImageButton ibtnCancelar;
		protected System.Web.UI.HtmlControls.HtmlGenericControl myContent;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion Controles
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					this.RedirecionarPagina();
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
					string debug = oException.Message.ToString();
					SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
					Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
				}
			}
			// Put user code to initialize the page here
		}
		private void RedirecionarPagina()
		{
			 switch(Page.Request.QueryString[URLTIPO].ToString().ToUpper())
				{
				case "1":
					myContent.Attributes[ATRIBUTOSRC] = "http://www.sbs.gob.pe/portalsbs/TipoTasa/tasainteres_bm_idbk.asp";
					break;
				case "2": //Bolsa de valores
					myContent.Attributes[ATRIBUTOSRC] = "http://www.bvl.com.pe";
					break;
				 case "3": //Tipos de cambio
					 myContent.Attributes[ATRIBUTOSRC] = "http://es.finance.yahoo.com/m3";
					 break;
				}

			myContent.Attributes["Height"]="380";
			myContent.Attributes["Width"]="600";
			myContent.DataBind();
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
			this.ibtnCancelar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnCancelar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void ibtnCancelar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Page.Response.Redirect(URLPRINCIPAL);
		}
		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add TasadeInteresPromedioCreditoAhorro.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add TasadeInteresPromedioCreditoAhorro.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add TasadeInteresPromedioCreditoAhorro.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add TasadeInteresPromedioCreditoAhorro.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add TasadeInteresPromedioCreditoAhorro.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add TasadeInteresPromedioCreditoAhorro.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add TasadeInteresPromedioCreditoAhorro.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add TasadeInteresPromedioCreditoAhorro.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add TasadeInteresPromedioCreditoAhorro.Exportar implementation
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
			// TODO:  Add TasadeInteresPromedioCreditoAhorro.ValidarFiltros implementation
			return false;
		}

		#endregion
	}
}
