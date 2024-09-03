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

namespace SIMA.SimaNetWeb.GestionFinanciera.Presupuesto.Control
{
	/// <summary>
	/// Summary description for ConsultarSaldoPorCentrodeCosto.
	/// </summary>
	public class ConsultarSaldoPorCentrodeCosto : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		#region Control
		const string GRILLAVACIA="No existe Datos";
		#endregion
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.TextBox txtBuscar;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DropDownList DropDownList1;
		protected System.Web.UI.WebControls.DropDownList ddlCentroOperativo;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hNroCentroCosto;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
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
					this.LlenarGrillaOrdenamientoPaginacion(String.Empty,Constantes.INDICEPAGINADEFAULT);	
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
			this.ddlCentroOperativo.SelectedIndexChanged += new System.EventHandler(this.ddlCentroOperativo_SelectedIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add ConsultarSaldoPorCentrodeCosto.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarSaldoPorCentrodeCosto.LlenarGrillaOrdenamiento implementation
		}
		DataTable ObtenerDatos(){
				//return (new CPresupuestoControl()).ConsultarPresupuestal();
			DataTable dt = new  DataTable();
			dt.Columns.Add("Col1");
			dt.Columns.Add("Col2");
			dt.Columns.Add("Col3");
			dt.Columns.Add("Col4");
			dt.Columns.Add("Col5");
			dt.Columns.Add("Col6");
			dt.Columns.Add("Col7");
			dt.Columns.Add("Col8");
			dt.Columns.Add("Col9");
			dt.Columns.Add("Col10");
			dt.Columns.Add("Col11");
			dt.Columns.Add("Col12");
			object []Data={"","","","","","","","","","","",""};
			dt.Rows.Add(Data);
			return dt;
		}
		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dtGeneral = this.ObtenerDatos();
			if(dtGeneral!=null)
			{
				grid.DataSource = dtGeneral;
				lblResultado.Visible = false;
			}
			else
			{
				grid.DataSource = dtGeneral;
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

		public void LlenarCombos()
		{
			LlenarCentroOPerativo();
		}
		void LlenarCentroOPerativo(){
			this.ddlCentroOperativo.DataSource = (new CCentroOperativo()).ListarTodosCombo();
			this.ddlCentroOperativo.DataValueField = "idcentrooperativo";
			this.ddlCentroOperativo.DataTextField = "Nombre";
			this.ddlCentroOperativo.DataBind();
			ListItem item = ddlCentroOperativo.Items.FindByValue(CNetAccessControl.GetUserIdCentrodeCosto().ToString());
			if(item!=null)
			{item.Selected = true;}

		}
		public void LlenarDatos()
		{
			this.hNroCentroCosto.Value = CNetAccessControl.GetUserNrodeCentrodeCosto();
			this.txtBuscar.Text = CNetAccessControl.GetUserNombredeCentrodeCosto();
		}

		public void LlenarJScript()
		{
			this.ddlCentroOperativo.Attributes.Add(Utilitario.Constantes.EVENTOONCHANGE,"ActualizarParametros();$O('txtBuscar').value='';");
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarSaldoPorCentrodeCosto.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarSaldoPorCentrodeCosto.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarSaldoPorCentrodeCosto.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add ConsultarSaldoPorCentrodeCosto.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ConsultarSaldoPorCentrodeCosto.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			// TODO:  Add ConsultarSaldoPorCentrodeCosto.Agregar implementation
		}

		public void Modificar()
		{
			// TODO:  Add ConsultarSaldoPorCentrodeCosto.Modificar implementation
		}

		public void Eliminar()
		{
			// TODO:  Add ConsultarSaldoPorCentrodeCosto.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			// TODO:  Add ConsultarSaldoPorCentrodeCosto.CargarModoPagina implementation
		}

		public void CargarModoNuevo()
		{
			// TODO:  Add ConsultarSaldoPorCentrodeCosto.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			// TODO:  Add ConsultarSaldoPorCentrodeCosto.CargarModoModificar implementation
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add ConsultarSaldoPorCentrodeCosto.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add ConsultarSaldoPorCentrodeCosto.ValidarCampos implementation
			return false;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add ConsultarSaldoPorCentrodeCosto.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add ConsultarSaldoPorCentrodeCosto.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				e.Item.Style.Add("display","none");
			}
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void ddlCentroOperativo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
