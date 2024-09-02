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
using SIMA.EntidadesNegocio.General;
using SIMA.Controladoras.GestionFinanciera;
using SIMA.EntidadesNegocio.GestionFinanciera;
using SIMA.Utilitario;
using NetAccessControl;
using SIMA.ManejadorExcepcion;
using SIMA.Log;

namespace SIMA.SimaNetWeb.General.Formato
{
	/// <summary>
	/// Summary description for DefaultFormatos.
	/// </summary>
	public class DefaultFormatos : System.Web.UI.Page,IPaginaBase
	{
		const string KEYQIDGRUPOFORMATO="IdGrupoFormato";

		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hTabSeleccionado;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigoFormato;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hPeriodo;
		protected System.Web.UI.WebControls.Label lblGrupoFormato;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdReporte;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPaginaSort;
		#endregion
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				if(!Page.IsPostBack)
				{
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarDatos();
					
				}
			}
			catch(SIMAExcepcionLog oSIMAExcepcionLog)
			{
				Helper.MsgBox(oSIMAExcepcionLog.Mensaje);					
			}
			catch(SIMAExcepcionIU oSIMAExcepcionIU)
			{
				Helper.MsgBox(oSIMAExcepcionIU.Mensaje);					
			}
			catch(SIMAExcepcionDominio oSIMAExcepcionDominio)
			{
				Helper.MsgBox(oSIMAExcepcionDominio.Mensaje);					
			}
			catch(Exception oException)
			{
				string debug = oException.Message.ToString();
				SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
				Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
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
			// TODO:  Add DefaultFormatos.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DefaultFormatos.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DefaultFormatos.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add DefaultFormatos.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			TablaTablas oTablaTablas = (TablaTablas)(new  CTablaTablas()).ListarDetalle(Convert.ToInt32(Enumerados.TablasTabla.GrupodeFormatos),Convert.ToInt32(Page.Request.Params[KEYQIDGRUPOFORMATO]));
			this.lblGrupoFormato.Text = oTablaTablas.Descripcion;
			this.hPeriodo.Value = DateTime.Now.Year.ToString();
		}

		public void LlenarJScript()
		{
			// TODO:  Add DefaultFormatos.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DefaultFormatos.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DefaultFormatos.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DefaultFormatos.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add DefaultFormatos.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add DefaultFormatos.ValidarFiltros implementation
			return false;
		}

		#endregion
	}
}
