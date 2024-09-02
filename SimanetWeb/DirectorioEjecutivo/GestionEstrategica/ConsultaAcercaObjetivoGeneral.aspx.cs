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
using SIMA.Controladoras.GestionEstrategica;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;


namespace SIMA.SimaNetWeb.DirectorioEjecutivo.GestionEstrategica
{
	/// <summary>
	/// Summary description for ConsultaAcercaObjetivoGeneral.
	/// </summary>
	public class ConsultaAcercaObjetivoGeneral : System.Web.UI.Page,IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblMensaje;
		protected System.Web.UI.WebControls.Label lblCodigoObjGeneral;
		protected System.Web.UI.WebControls.Label lblContenidoObjGeneral;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtFundamento;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox txtInvolucrados;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.TextBox txtRequerimientos;
		protected System.Web.UI.HtmlControls.HtmlTable Table2;
		protected System.Web.UI.WebControls.Image Image1;
		protected System.Web.UI.WebControls.Image Image2;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Image Image3;
		protected System.Web.UI.WebControls.Image Image4;
		protected System.Web.UI.WebControls.Image Image5;
		#endregion

		#region Constantes
		const int DESCRIPCION = 0;
		const int FUNDAMENTOS = 1;
		const int INVOLUCRADOS = 2;
		const string SIGLAOBJETIVOGENERAL = "OG";
		const int REQUERIMIENTOS = 3;
		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();

					Helper.ReiniciarSession();

					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionComercial",this.ToString(),"Se consultaron Promotores por venta.",Enumerados.NivelesErrorLog.I.ToString()));
					
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
			// TODO:  Add ConsultaAcercaObjetivoGeneral.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultaAcercaObjetivoGeneral.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add ConsultaAcercaObjetivoGeneral.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add ConsultaAcercaObjetivoGeneral.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			
			try
			{
				int idOGeneral = Convert.ToInt32(Page.Request.QueryString[Utilitario.Enumerados.ColumnasObjetivosGenerales.IDOGENERALES.ToString()]);
				CObjetivoGeneral oCObjetivoGeneral =  new CObjetivoGeneral();
				DataRow drOGeneral =  oCObjetivoGeneral.ListarAcercaObjetivoGeneral(idOGeneral);

				if(drOGeneral != null)
				{
					this.lblCodigoObjGeneral.Text = SIGLAOBJETIVOGENERAL + idOGeneral;
					this.lblContenidoObjGeneral.Text = drOGeneral[DESCRIPCION].ToString();
					this.txtFundamento.Text = drOGeneral[FUNDAMENTOS].ToString().ToUpper();
					this.txtInvolucrados.Text = drOGeneral[INVOLUCRADOS].ToString().ToUpper();
					this.txtRequerimientos.Text = drOGeneral[REQUERIMIENTOS].ToString().ToUpper();
				}
				else
				{
					this.Table2.Visible = false;
					this.lblMensaje.Text = "-- SIN DATOS --";
				}
			}
			catch(Exception oException)
			{
				SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
				Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
			}
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultaAcercaObjetivoGeneral.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultaAcercaObjetivoGeneral.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultaAcercaObjetivoGeneral.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultaAcercaObjetivoGeneral.Exportar implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ConsultaAcercaObjetivoGeneral.ValidarFiltros implementation
			return false;
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
		#endregion		
	}
}
