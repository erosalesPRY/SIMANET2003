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
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using NullableTypes;
using MetaBuilders.WebControls;


namespace SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancieros.Directorio
{
	/// <summary>
	/// Summary description for DefaultObservaciones.
	/// </summary>
	public class DefaultObservaciones : System.Web.UI.Page,IPaginaBase
	{
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label lblCuentaRubro;
		protected System.Web.UI.WebControls.Label lblTipoPersona;
		protected System.Web.UI.WebControls.ImageButton btnComsultar;
		protected System.Web.UI.WebControls.DropDownList ddblAno;
		protected System.Web.UI.WebControls.DropDownList ddblMes;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPaginaSort;
		protected System.Web.UI.WebControls.Literal ltlMensaje;

		const string VALORPERIODO ="Periodo";

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					//this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					//this.LlenarDatos();
					this.LlenarCombos();
					this.LlenarJScript();
					//this.VerificaLinksParaDirectorio();
					//this.VerificarCheckBox();
	
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
			// TODO:  Add DefaultObservaciones.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DefaultObservaciones.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DefaultObservaciones.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			this.LlenarPeriodoContable();
		}

		public void LlenarDatos()
		{
			// TODO:  Add DefaultObservaciones.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add DefaultObservaciones.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DefaultObservaciones.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DefaultObservaciones.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DefaultObservaciones.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add DefaultObservaciones.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add DefaultObservaciones.ValidarFiltros implementation
			return false;
		}

		#endregion
		private void LlenarPeriodoContable()
		{
			CPeriodoContable oCPeriodoContable = new CPeriodoContable();
			ddblAno.DataSource = oCPeriodoContable.ListarPeriodo();
			ddblAno.DataValueField=VALORPERIODO;
			ddblAno.DataTextField=VALORPERIODO;
			ddblAno.DataBind();
			if((Page.Request.Params[Utilitario.Constantes.KeyQPaginaValorInicial] != null)  && Page.Request.Params[Utilitario.Constantes.KeyQPaginaValorInicial].ToString() == Utilitario.Constantes.KeyQPaginaValor)
			{
				ListItem item;
				item = ddblAno.Items.FindByText(SIMA.Utilitario.Helper.FechaSimanet.ObtenerFechaSesion().Year.ToString());
				if (item !=null){item.Selected = true;}

				item = ddblMes.Items.FindByValue(SIMA.Utilitario.Helper.FechaSimanet.ObtenerFechaSesion().Month.ToString());
				if (item !=null){item.Selected = true;}
			}	
			else
			{
				Helper.SeleccionarItemCombos(this);
			}
				
		}
	}
}
