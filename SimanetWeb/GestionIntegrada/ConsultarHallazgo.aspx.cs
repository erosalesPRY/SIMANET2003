using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using SIMA.SimaNetWeb.InterfacesIU;
using SIMA.Controladoras.General;
using SIMA.Controladoras.GestionIntegrada;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using SIMA.EntidadesNegocio.GestionIntegrada;
using NetAccessControl;
using System.Configuration;

namespace SIMA.SimaNetWeb.GestionIntegrada
{
	/// <summary>
	/// Summary description for ConsultarHallazgo.
	/// </summary>
	public class ConsultarHallazgo : System.Web.UI.Page,IPaginaBase
	{
		protected System.Web.UI.WebControls.TextBox txtHallazgo;
	
		const string KEYQIDSAM = "IdSAM";

		string IDSolicitudAccionMejora
		{
			get{return ((Page.Request.Params[KEYQIDSAM]!=null)?Page.Request.Params[KEYQIDSAM].ToString():"0");}
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{

					Session["Grabando"]="0";
					this.ConfigurarAccesoControles();
					this.LlenarJScript();
					this.LlenarDatos();
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
					Helper.MsgBox(oSIMAExcepcionDominio.Mensaje.ToString());					
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
			// TODO:  Add ConsultarHallazgo.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarHallazgo.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add ConsultarHallazgo.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add ConsultarHallazgo.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			SolicitudAccionMejoraBE oSolicitudAccionMejoraBE = (SolicitudAccionMejoraBE) (new CSolicituddeAcciondeMejora()).ListarDetalle(this.IDSolicitudAccionMejora,0);
			txtHallazgo.Text = oSolicitudAccionMejoraBE.DescripcionHallazgo;
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarHallazgo.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarHallazgo.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarHallazgo.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarHallazgo.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add ConsultarHallazgo.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ConsultarHallazgo.ValidarFiltros implementation
			return false;
		}

		#endregion
	}
}
