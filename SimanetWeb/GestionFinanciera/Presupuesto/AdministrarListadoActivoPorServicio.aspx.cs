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
using NetAccessControl;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using System.IO;

namespace SIMA.SimaNetWeb.GestionFinanciera.Presupuesto
{
	/// <summary>
	/// Summary description for AdministrarListadoActivoPorServicio.
	/// </summary>
	public class AdministrarListadoActivoPorServicio : BaseGestionFinanciera,IPaginaBase
	{
		protected System.Web.UI.WebControls.TextBox txtPU;
		protected System.Web.UI.WebControls.TextBox txtCantidad;
		protected System.Web.UI.WebControls.TextBox txtDML;
		protected System.Web.UI.WebControls.TextBox txtDMA;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DropDownList ddlUnidadMedida;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				if(!Page.IsPostBack)
				{
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarJScript();
					this.LlenarCombos();
					this.LlenarDatos();
					this.LlenarGrilla();
					
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
				Helper.MsgBox(oSIMAExcepcionDominio.Error);					
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
			DataTable dt = (new CPresupuestoActivoPorServicio()).ListarTodosGrilla(this.NroCentroOperativo,this.NroRequerimiento);
			grid.DataSource =  dt;
			grid.DataBind();
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarListadoActivoPorServicio.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add AdministrarListadoActivoPorServicio.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add AdministrarListadoActivoPorServicio.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add AdministrarListadoActivoPorServicio.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add AdministrarListadoActivoPorServicio.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarListadoActivoPorServicio.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministrarListadoActivoPorServicio.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarListadoActivoPorServicio.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add AdministrarListadoActivoPorServicio.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add AdministrarListadoActivoPorServicio.ValidarFiltros implementation
			return false;
		}

		#endregion
	}
}
