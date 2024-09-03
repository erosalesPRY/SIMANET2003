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

namespace SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancieros
{
	/// <summary>
	/// Summary description for GlosaEstadosFinancieros.
	/// </summary>
	public class GlosaEstadosFinancieros : System.Web.UI.Page,IPaginaBase
	{
		#region Constantes
		
		const string KEYIDCENTRO ="IdCentro";
		const string NOMBRECENTRO ="NombreCentro";

		const string NOMBRETIPOOPCION ="NombreOpcion";
		const string KEYQIDFORMATO = "IdFormato";
		const string KEYQIDNOMBREFORMATO = "NFormato";


		const string KEYQIDREPORTE = "IdReporte";
		const string KEYQIDRUBRO = "IdRubro";
		const string KEYQNOMBRERUBRO = "NRubro";

		const string GRILLAVACIA="No exiets";
		const string OBJPARAMETROCONTABLE="ParametroContable";
			
		const string KEYQNRODIGITOSCABECERA ="NroDigCab";
		const string KEYDIGCUENTACONTABLE = "Cuenta";
		const string KEYIDEMPRESA ="idEmp";
		//Otros
		const int IDTABLAGLOSAESTADOSFINACIEROS =11;
		#endregion
		protected System.Web.UI.HtmlControls.HtmlTextArea campo1;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblConcepto;

		#region Controles

		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					//this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarDatos();
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
			// TODO:  Add GlosaEstadosFinancieros.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add GlosaEstadosFinancieros.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add GlosaEstadosFinancieros.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add GlosaEstadosFinancieros.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			this.lblConcepto.Text = Page.Request.Params[KEYQNOMBRERUBRO].ToString();
		}

		public void LlenarJScript()
		{
			// TODO:  Add GlosaEstadosFinancieros.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add GlosaEstadosFinancieros.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add GlosaEstadosFinancieros.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add GlosaEstadosFinancieros.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			if(CNetAccessControl.FindPage(Page.Request.Url.AbsolutePath.ToString()))
			{CNetAccessControl.LoadControls(this);}
			else
			{CNetAccessControl.RedirectPageError();}
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add GlosaEstadosFinancieros.ValidarFiltros implementation
			return false;
		}

		#endregion

	}
}
