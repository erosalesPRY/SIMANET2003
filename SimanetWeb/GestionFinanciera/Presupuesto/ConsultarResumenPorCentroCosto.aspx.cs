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
using SIMA.Controladoras;
using SIMA.Controladoras.General;
using SIMA.Controladoras.GestionFinanciera;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;

namespace SIMA.SimaNetWeb.GestionFinanciera.Presupuesto
{
	/// <summary>
	/// Summary description for ConsultarResumenPorCentroCosto.
	/// </summary>
	public class ConsultarResumenPorCentroCosto : System.Web.UI.Page,IPaginaBase
	{
		const string KEYQCENTROOPERATIVONOMBRE = "NombreCentro";
		const string PERIODO = "Periodo";
		const string KEYTIPOINFORMACION = "TipoInfo";
		const string KEYQTIPOPRESUPUESTO = "idtp";
		const string KEYQIDCENTROOPERATIVO = "idCentro";
		const string MES = "Mes";

		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblCentroOperativo;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label lblPeriodo;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label lblMes;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.ImageButton ibtnResumen;
		protected System.Web.UI.HtmlControls.HtmlTable tblResumen;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarJScript();
					this.LlenarDatos();
					this.LlenarCombos();
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
					ltlMensaje.Text = Helper.MensajeAlert(oSIMAExcepcionDominio.Error);					
				}
				catch(Exception oException)
				{
					string msgb =oException.Message.ToString();
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
			this.ibtnResumen.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnResumen_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			
		}

		public void LlenarCombos()
		{
			
		}

		public void LlenarDatos()
		{
			this.lblCentroOperativo.Text = Page.Request.Params[KEYQCENTROOPERATIVONOMBRE].ToString();
			lblPeriodo.Text = Page.Request.Params[PERIODO].ToString();
			lblMes.Text = Helper.ObtenerNombreMes(Convert.ToInt32(Page.Request.Params[MES]),Utilitario.Enumerados.TipoDatoMes.NombreCompleto).ToUpper();
		}

		public void LlenarJScript()
		{
			this.ibtnResumen.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.PopupDeEspera() + Helper.HistorialIrAdelantePersonalizado(this.lblCentroOperativo.ID.ToString()));
		}

		public void RegistrarJScript()
		{
			
		}

		public void Imprimir()
		{
			
		}

		public void Exportar()
		{
			
		}

		public void ConfigurarAccesoControles()
		{
		
		}

		public bool ValidarFiltros()
		{
			
			return false;
		}

		#endregion

		private void ibtnResumen_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			string Cta = "";
			switch(Page.Request.Params[KEYQTIPOPRESUPUESTO].ToString())
			{
				case "1":if(Page.Request.Params[KEYQIDCENTROOPERATIVO].ToString()=="1"){ Cta="96";}
						 else {Cta="97";} 
					break;
				case "2":Cta = "92";
					break;

			}
			if (Page.Request.Params[KEYTIPOINFORMACION].ToString()=="ppto") /////SI es Presupuestado
			{

				Helper.EjecutarReporte(@"C:\SimanetReportes\GestionFinanciera\Presupuesto\Meses\"
					,"ResumenDePresupuestoPorCentroDeCostos.rpt"
					,(new CPresupuesto()).ConsultarResumenPresupuestoPorCentroDeCostos(Convert.ToInt32(Page.Request.Params[PERIODO]),Cta)
					,false);
					
			}
			else /// SI es REAL
			{
				Helper.EjecutarReporte(@"C:\SimanetReportes\GestionFinanciera\Presupuesto\Meses\"
					,"ResumenDeGastosPorCentroDeCostos.rpt"
					,(new CPresupuesto()).ConsultarResumenGastosPorCentroDeCostos(Convert.ToInt32(Page.Request.Params[PERIODO]),Cta)
					,false);
			}
		}
	}
}
