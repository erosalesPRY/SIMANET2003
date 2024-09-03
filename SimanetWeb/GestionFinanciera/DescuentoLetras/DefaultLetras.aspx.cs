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


namespace SIMA.SimaNetWeb.GestionFinanciera.DescuentoLetras
{
	/// <summary>
	/// Summary description for DefaultLetras.
	/// </summary>
	public class DefaultLetras : System.Web.UI.Page,IPaginaBase
	{
		#region Constantes
			const string URLPAGINALETRAS = "AdministrarLetras.aspx?";
			const string KEYIDTIPOLETRA = "TipoLetra";
			const string KEYNOMBRETIPOLETRA = "NombreTipoLetra";
			const string KEYIDLETRAPORPAGAR = "1";
			const string KEYDESCRIPCIONLETRAPORPAGAR = "Letras por Pagar";
			const string KEYIDLETRAPORCOBRAR = "0";
			const string KEYDESCRIPCIONLETRAPORCOBRAR = "Letras por Cobrar";

		#endregion

		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Image ibtnLetrasporCobrar;
		protected System.Web.UI.WebControls.Image ibtnLetrasporPagar;
		protected System.Web.UI.HtmlControls.HtmlTable tblAtras;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion Controles

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					this.LlenarJScript();
					Helper.ReiniciarSession();
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionFinanciera",this.ToString(),"Se consultó Carta de Crédito.",Enumerados.NivelesErrorLog.I.ToString()));
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
			// TODO:  Add DefaultLetras.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DefaultLetras.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DefaultLetras.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add DefaultLetras.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			
		}

		public void LlenarJScript()
		{
			string URLPAGINALETRAS1 = "/simanetWeb/GestionFinanciera/LetrasdeCambio/AdministrarLetrasdeCambio.aspx?";
			this.ibtnLetrasporPagar.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
				Utilitario.Constantes.POPUPDEESPERA +
				Helper.HistorialIrAdelantePersonalizado(Utilitario.Constantes.VACIO) 
				+ Utilitario.Constantes.SIGNOPUNTOYCOMA 
				+ Helper.MostrarVentana(URLPAGINALETRAS1,
					KEYIDTIPOLETRA + Utilitario.Constantes.SIGNOIGUAL + KEYIDLETRAPORPAGAR
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYNOMBRETIPOLETRA + Utilitario.Constantes.SIGNOIGUAL +  KEYDESCRIPCIONLETRAPORPAGAR));

			
			this.ibtnLetrasporCobrar.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
				Utilitario.Constantes.POPUPDEESPERA +
				Helper.HistorialIrAdelantePersonalizado(Utilitario.Constantes.VACIO) 
				+ Utilitario.Constantes.SIGNOPUNTOYCOMA 
				+ Helper.MostrarVentana(URLPAGINALETRAS1,
					KEYIDTIPOLETRA + Utilitario.Constantes.SIGNOIGUAL + KEYIDLETRAPORCOBRAR
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYNOMBRETIPOLETRA + Utilitario.Constantes.SIGNOIGUAL +  KEYDESCRIPCIONLETRAPORCOBRAR));

		}

		public void RegistrarJScript()
		{
			// TODO:  Add DefaultLetras.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DefaultLetras.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DefaultLetras.Exportar implementation
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
			// TODO:  Add DefaultLetras.ValidarFiltros implementation
			return false;
		}

		#endregion
	}
}
