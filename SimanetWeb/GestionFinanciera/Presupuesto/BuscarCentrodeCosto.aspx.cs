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
using SIMA.Controladoras.Personal;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;

namespace SIMA.SimaNetWeb.GestionFinanciera.Presupuesto
{
	/// <summary>
	/// Summary description for BuscarCentrodeCosto.
	/// </summary>
	public class BuscarCentrodeCosto : System.Web.UI.Page,IPaginaBase
	{
		const string GRILLAVACIA="No existe Datos";
		#region Controles
			protected System.Web.UI.WebControls.Label Label3;
			protected System.Web.UI.WebControls.Label Label1;
			protected System.Web.UI.WebControls.Label Label2;
			protected System.Web.UI.WebControls.TextBox txtBuscar;
			protected projDataGridWeb.DataGridWeb grid;
			protected System.Web.UI.WebControls.Image imgCancelar;
			protected System.Web.UI.WebControls.Label lblResultado;
			protected System.Web.UI.WebControls.Label lblGrupoCC;
			protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{

			try
			{
				this.ConfigurarAccesoControles();
				Helper.ReiniciarSession();
				Helper.ReestablecerPagina(this);
				this.LlenarJScript();
				this.LlenarDatos();
				this.LlenarCombos();
				this.LlenarGrilla();
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


		DataTable ObtenerDatos()
		{
			DataTable dtTMP = new DataTable();
			dtTMP.Columns.Add(new DataColumn("idCentroCosto", typeof(int)));
			dtTMP.Columns.Add(new DataColumn("Nombre", typeof(string)));
			DataRow dr;
			dr = dtTMP.NewRow();
			dr["idCentroCosto"] = 1;
			dr["Nombre"] = " ";
			dtTMP.Rows.Add(dr);
			dtTMP.AcceptChanges();
			return dtTMP;
		}

		public void LlenarGrilla()
		{
			DataTable dtGeneral = this.ObtenerDatos();
			DataView dv = dtGeneral.DefaultView;
			if(dv!=null)
			{
				dv.RowFilter = ((this.txtBuscar.Text.Length==0)? "":"Nombre='" + this.txtBuscar.Text + "'");
				grid.DataSource = dv;
				lblResultado.Visible = false;
			}
			else
			{
				grid.DataSource = dv;
				lblResultado.Text = GRILLAVACIA;
			}
			try
			{
				grid.DataBind();
			}
			catch	
			{
				grid.CurrentPageIndex = 0;
				grid.DataBind();
			}
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add BuscarCentrodeCosto.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add BuscarCentrodeCosto.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add BuscarCentrodeCosto.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add BuscarCentrodeCosto.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			this.txtBuscar.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,"ConsultarCentrosdeCostos()");
		}

		public void RegistrarJScript()
		{
			// TODO:  Add BuscarCentrodeCosto.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add BuscarCentrodeCosto.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add BuscarCentrodeCosto.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add BuscarCentrodeCosto.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add BuscarCentrodeCosto.ValidarFiltros implementation
			return false;
		}

		#endregion
	}
}
