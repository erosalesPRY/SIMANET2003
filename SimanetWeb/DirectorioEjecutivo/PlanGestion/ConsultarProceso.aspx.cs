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

namespace SIMA.SimaNetWeb.DirectorioEjecutivo.PlanGestion
{
	/// <summary>
	/// Summary description for ConsultarProceso.
	/// </summary>
	public class ConsultarProceso : System.Web.UI.Page, IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnSubproceso;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.TextBox txtParticipante;
		protected System.Web.UI.WebControls.Label lblParticipantes;
		protected System.Web.UI.WebControls.TextBox txtLider;
		protected System.Web.UI.WebControls.Label lblLider;
		protected System.Web.UI.WebControls.TextBox txtResponsable;
		protected System.Web.UI.WebControls.Label lblResponsable;
		protected System.Web.UI.WebControls.TextBox txtAlcance;
		protected System.Web.UI.WebControls.Label lblAlcance;
		protected System.Web.UI.WebControls.TextBox txtDefinicion;
		protected System.Web.UI.WebControls.Label lblDefinicion;
		protected System.Web.UI.WebControls.Label lblNombreProceso;
		protected System.Web.UI.WebControls.Label lblProceso;
		protected System.Web.UI.HtmlControls.HtmlTable Table2;
		protected System.Web.UI.WebControls.Label lblResultado;
		#endregion
		protected System.Web.UI.WebControls.Image Image1;
		protected System.Web.UI.WebControls.Image Image2;
		protected System.Web.UI.WebControls.Label lblCO;
		protected System.Web.UI.WebControls.TextBox txtCentroOperativo;
		

		const string URLCONSULTARSUBPROCESO = "ConsultarSubproceso.aspx?";

	
		private void Page_Load(object sender, System.EventArgs e)
		{

			ibtnSubproceso.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			ibtnSubproceso.Attributes.Add("onclick", Convert.ToString(Helper.MostrarVentana(
								URLCONSULTARSUBPROCESO, 
								Utilitario.Enumerados.ColumnasProceso.IdProceso.ToString() + 
								Utilitario.Constantes.SIGNOIGUAL + 
								Convert.ToInt32(Page.Request.QueryString[Utilitario.Enumerados.ColumnasProceso.IdProceso.ToString()]))));
			
			// Put user code to initialize the page here
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();

					Helper.ReiniciarSession();
				
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionComercial",this.ToString(),"Se consultaron Promotores por venta.",Enumerados.NivelesErrorLog.I.ToString()));

					this.DetalleProcesoPlanGestion();
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

		public void LlenarGrilla()
		{
			// TODO:  Add ConsultarProceso.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarProceso.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add ConsultarProceso.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add ConsultarProceso.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add ConsultarProceso.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarProceso.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarProceso.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarProceso.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarProceso.Exportar implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ConsultarProceso.ValidarFiltros implementation
			return false;
		}

		public void DetalleProcesoPlanGestion()
		{
			int idProceso = Convert.ToInt32(Page.Request.QueryString[Utilitario.Enumerados.ColumnasProceso.IdProceso.ToString()]);
			CPlanGestion oCPlanGestion =  new CPlanGestion();
			DataRow drProceso =  oCPlanGestion.ListarProcesoPlanGestion(idProceso);
			
			if(drProceso != null)
			{
				this.lblProceso.Text = "P" + idProceso;
				this.lblNombreProceso.Text = drProceso[Convert.ToString(Utilitario.Enumerados.ColumnasProceso.NombreProceso)].ToString().ToUpper();
				this.txtDefinicion.Text = drProceso[Convert.ToString(Utilitario.Enumerados.ColumnasProceso.Definicion)].ToString().ToUpper();
				this.txtAlcance.Text = drProceso[Convert.ToString(Utilitario.Enumerados.ColumnasProceso.Alcance)].ToString().ToUpper();
				this.txtResponsable.Text = drProceso[Convert.ToString(Utilitario.Enumerados.ColumnasProceso.Responsable)].ToString().ToUpper();
				this.txtLider.Text = drProceso[Convert.ToString(Utilitario.Enumerados.ColumnasProceso.Lider)].ToString().ToUpper();
				this.txtParticipante.Text = drProceso[Convert.ToString(Utilitario.Enumerados.ColumnasProceso.Participantes)].ToString().ToUpper();
				this.txtCentroOperativo.Text = drProceso[Convert.ToString(Utilitario.Enumerados.ColumnasProceso.CO)].ToString().ToUpper();
			}
			else
			{
				this.Table2.Visible = false;
				this.ibtnSubproceso.Visible = false;
				this.lblResultado.Text = "-- SIN DATOS --";
			}
		}
		#endregion
	}
}
