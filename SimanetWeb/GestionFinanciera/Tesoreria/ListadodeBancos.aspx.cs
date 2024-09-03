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


namespace SIMA.SimaNetWeb.GestionFinanciera.Tesoreria
{
	/// <summary>
	/// Summary description for ListadodeBancos.
	/// </summary>
	public class ListadodeBancos : System.Web.UI.Page,IPaginaBase
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox txtPeriodo;
		protected System.Web.UI.WebControls.DropDownList ddlEntidadFinancieraConfig;
		protected System.Web.UI.WebControls.DropDownList ddlEntidadFinanciera;
	
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
					Helper.MsgBox(oException.Message.ToString());
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
			// TODO:  Add ListadodeBancos.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ListadodeBancos.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add ListadodeBancos.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			//this.ddlEntidadFinanciera.DataSource = (new CTesoreria()).ListarEntidadesFiancieras();
			DataTable dt = (new CEntidadFinanciera()).ListarTodosCombo();
			this.ddlEntidadFinanciera.DataSource = dt;
			this.ddlEntidadFinanciera.DataTextField="RazonSocial";
			this.ddlEntidadFinanciera.DataValueField="NroEntidadFinanciera";
			this.ddlEntidadFinanciera.DataBind();
			//Carga Datos de Configuracion
			this.ddlEntidadFinancieraConfig .DataSource = dt;
			this.ddlEntidadFinancieraConfig.DataTextField="PuntosInicio";
			this.ddlEntidadFinancieraConfig.DataValueField="KeyAltoCheque";
			this.ddlEntidadFinancieraConfig.DataBind();
		}

		public void LlenarDatos()
		{
			txtPeriodo.Text = DateTime.Now.Year.ToString();
		}

		public void LlenarJScript()
		{
			this.ddlEntidadFinanciera.Attributes[Enumerados.EventosJavaScript.OnChange.ToString()]="AlCambiarSeleccionEntidadFinanciera()";
			this.ddlEntidadFinancieraConfig.Style["display"]="none";
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ListadodeBancos.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ListadodeBancos.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ListadodeBancos.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add ListadodeBancos.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ListadodeBancos.ValidarFiltros implementation
			return false;
		}

		#endregion
	}
}
