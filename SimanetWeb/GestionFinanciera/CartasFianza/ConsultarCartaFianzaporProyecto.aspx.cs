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

namespace SIMA.SimaNetWeb.GestionFinanciera.CartasFianza
{
	public class ConsultarCartaFianzaporProyecto : System.Web.UI.Page,IPaginaBase
	{
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
			this.ddlbModalidadCartaFianza.SelectedIndexChanged += new System.EventHandler(this.ddlbModalidadCartaFianza_SelectedIndexChanged);
			this.ddlbEstadoCartaFianza.SelectedIndexChanged += new System.EventHandler(this.ddlbEstadoCartaFianza_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		#region Controles
		protected System.Web.UI.WebControls.Panel Panel1;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.DropDownList ddlbModalidadCartaFianza;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.DropDownList ddlbEstadoCartaFianza;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblTiutlo;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		#endregion

		#region Constantes 
			const string COLCODPADRE ="codPadre";
			const string COLDESPADRE ="desPadre";
			const string COLORDENAMIENTO="";


			const string KEYIDTIPOFZA = "TipoFza";
			const string KEYESTADOFIANZAP = "EstadoFianzaP";
			const string KEYSUBESTADOFIANZAP = "SubEstadoFianzaP";
			const string KEYESTADOPROY = "EstProy";


		#endregion

		private const string SESIONESTADOCARTAFIANZA="SESIONESTADOCARTAFIANZA";
		private const string SESIONMODALIDADCARTAFIANZA="SESIONMODALIDADCARTAFIANZA";


		private void CargarCombos()
		{
			if(Session[SESIONESTADOCARTAFIANZA] == null)
				Session[SESIONESTADOCARTAFIANZA] = 0;
		
			if(Session[SESIONMODALIDADCARTAFIANZA] == null)
				Session[SESIONESTADOCARTAFIANZA] = 0;

			ddlbEstadoCartaFianza.SelectedIndex = Convert.ToInt32(Session[SESIONESTADOCARTAFIANZA].ToString());
			ddlbModalidadCartaFianza.SelectedIndex = Convert.ToInt32(Session[SESIONESTADOCARTAFIANZA].ToString());
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					//this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarJScript();
					this.LlenarDatos();
					this.LlenarCombos();
					CargarCombos();
					LlenarGrillaOrdenamientoPaginacion("",0);
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Enumerados.NombresdeModulo.GestionFinanciera.ToString(),this.ToString(),"Se consultó las Cartas fianzas Por Proyecto.",Enumerados.NivelesErrorLog.I.ToString()));
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

		
		#region IPaginaBase Members
		public void LlenarGrilla()
		{
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
		}
		
		private void ObtenerDatos()
		{
			CCartaFianza oCCartaFianza =  new CCartaFianza();	
			SimaNetWeb.ControlesUsuario.GestionFinanciera.TablaDinamica td = new SIMA.SimaNetWeb.ControlesUsuario.GestionFinanciera.TablaDinamica();
			td.Datasource = oCCartaFianza.ConsultarCartaFianzaPorProyecto(44,Convert.ToInt32(ddlbModalidadCartaFianza.SelectedValue),Convert.ToInt32(ddlbEstadoCartaFianza.SelectedValue));
			
			if(td.Datasource == null)
				lblResultado.Visible = true;
			else
			{
				Panel1.Controls.Add(td);
				lblResultado.Visible = false;
			}
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			ObtenerDatos();
		}

		public void LlenarCombos()
		{
			LlenarFianzas();
			LlenarEstadoCartaFianza();
		}

		public void LlenarFianzas()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			ddlbModalidadCartaFianza.DataSource= oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Enumerados.TablasTabla.FinancieraModalidaddeFianza));
			ddlbModalidadCartaFianza.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbModalidadCartaFianza.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbModalidadCartaFianza.DataBind();
			
		}

		public void LlenarEstadoCartaFianza()
		{
			CCartaFianza oCCartaFianza = new CCartaFianza();
			ddlbEstadoCartaFianza.DataSource = oCCartaFianza.ListarOpcionesCartaFianza();
			ddlbEstadoCartaFianza.DataValueField = COLCODPADRE;
			ddlbEstadoCartaFianza.DataTextField = COLDESPADRE;
			ddlbEstadoCartaFianza.DataBind();
			
			ddlbEstadoCartaFianza.Items.FindByValue("1");
		}

		public void LlenarDatos()
		{
		}

		public void LlenarJScript()
		{
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
			if(CNetAccessControl.FindPage(Page.Request.Url.AbsolutePath.ToString()))
				CNetAccessControl.LoadControls(this);
			else
				CNetAccessControl.RedirectPageError();
		}

		public bool ValidarFiltros()
		{
			return false;
		}

		#endregion

		private void ddlbModalidadCartaFianza_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Session[SESIONMODALIDADCARTAFIANZA] = ddlbModalidadCartaFianza.SelectedIndex;
			LlenarGrillaOrdenamientoPaginacion("",0);
		}

		private void ddlbEstadoCartaFianza_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Session[SESIONESTADOCARTAFIANZA] = ddlbEstadoCartaFianza.SelectedIndex;
			LlenarGrillaOrdenamientoPaginacion("",0);
		}
	}
}
