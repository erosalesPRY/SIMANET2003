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
using SIMA.Controladoras.GestionEstrategica.PlanEstrategico;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using NullableTypes;
using MetaBuilders.WebControls;
using System.Diagnostics; 

namespace SIMA.SimaNetWeb.GestionEstrategica.PlanEstrategico
{
	/// <summary>
	/// Summary description for ConsultarObjetivoGeneralDetalleparaProcesoEstrategico.
	/// </summary>
	public class ConsultarObjetivoGeneralDetalleparaProcesoEstrategico : System.Web.UI.Page, IPaginaBase
	{
		#region Constante
		const string GRILLAVACIA="No Existen datos Plan Estrategico";
		const string KEYQIDPLANESTRATEGICO="idPLEstr";
		const string KEYQPLANESTRATEGICONOMBRE="PLEstrNombre";
		const string KEYQIDOBJETIVOGENERAL="idObjGen";
		const string KEYQCODDOBJETIVOGENERAL="CodObjGen";
		const string KEYQOBJETIVOGENERALNOMBRE="ObjGenNombre";
		const string KEYQFUNDAMENTO="Fundamento";
		const string KEYQREQUERIMIENTO="Requerimiento";

		const string URLDETALLE="ConsultarObjetivoGeneralDetalleparaProcesoEstrategico.aspx";
		#endregion

		int idObjetivoGeneral
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDOBJETIVOGENERAL]); }
		}

		int idPlanEstrategico
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDPLANESTRATEGICO]); }
		}
		string CodigoObjetivoGeneral
		{
			get{return Page.Request.QueryString[KEYQCODDOBJETIVOGENERAL].ToString();}
		}
		string NombreObjetivoGeneral
		{
			get{return Page.Request.QueryString[KEYQOBJETIVOGENERALNOMBRE].ToString();}
		}

		string PlanEstrategicoNombre
		{
			get{return Page.Request.Params[KEYQPLANESTRATEGICONOMBRE].ToString();}
		}
		string Fundamento
		{
			get{return Page.Request.Params[KEYQFUNDAMENTO].ToString();}
		}

		string Requerimiento
		{
			get{return Page.Request.Params[KEYQREQUERIMIENTO].ToString();}
		}

		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblMensaje;
		protected System.Web.UI.WebControls.Label lblCodigoObjGeneral;
		protected System.Web.UI.WebControls.Label lblContenidoObjGeneral;
		protected System.Web.UI.WebControls.Image Image3;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtFundamento;
		protected System.Web.UI.WebControls.Image Image4;
		protected System.Web.UI.WebControls.Image Image5;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.TextBox txtRequerimientos;
		protected System.Web.UI.HtmlControls.HtmlTable Table2;
		protected System.Web.UI.WebControls.Label lblPlanEstrategico;
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
					Helper.ReestablecerPagina(this);
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Estratégica",this.ToString(),"Se consultó Objetivo General.",Enumerados.NivelesErrorLog.I.ToString()));

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
			// TODO:  Add ConsultarObjetivoGeneralDetalleparaProcesoEstrategico.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarObjetivoGeneralDetalleparaProcesoEstrategico.LlenarGrillaOrdenamiento implementation
		}


		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add ConsultarObjetivoGeneralDetalleparaProcesoEstrategico.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add ConsultarObjetivoGeneralDetalleparaProcesoEstrategico.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarDatos()
		{
			this.lblPlanEstrategico.Text     = this.PlanEstrategicoNombre.ToString();
			this.lblCodigoObjGeneral.Text    = this.CodigoObjetivoGeneral.ToString();
			this.lblContenidoObjGeneral.Text = this.NombreObjetivoGeneral.ToString();
			this.txtFundamento.Text          = this.Fundamento.ToString();
			this.txtRequerimientos.Text      = this.Requerimiento.ToString().Replace("  ", "\r\n");
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarObjetivoGeneralDetalleparaProcesoEstrategico.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarObjetivoGeneralDetalleparaProcesoEstrategico.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarObjetivoGeneralDetalleparaProcesoEstrategico.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarObjetivoGeneralDetalleparaProcesoEstrategico.Exportar implementation
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
			// TODO:  Add ConsultarObjetivoGeneralDetalleparaProcesoEstrategico.ValidarFiltros implementation
			return false;
		}

		#endregion
	}
}
	