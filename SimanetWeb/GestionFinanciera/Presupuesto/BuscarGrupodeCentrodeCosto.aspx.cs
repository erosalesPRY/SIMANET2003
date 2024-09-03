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

	public class BuscarGrupodeCentrodeCosto : System.Web.UI.Page,IPaginaBase
	{
		const string GRILLAVACIA="No existe Datos";
		#region Controles
			protected System.Web.UI.WebControls.Label Label1;
			protected System.Web.UI.WebControls.Label Label2;
			protected System.Web.UI.WebControls.Label lblEmpresa;
			protected System.Web.UI.WebControls.Label lblHPPTO;
			protected System.Web.UI.WebControls.Label lblHEjecutado;
			protected System.Web.UI.WebControls.Label lblHSaldo;
			protected System.Web.UI.WebControls.Label lblPrespuesto;
			protected System.Web.UI.WebControls.Label lblEjecutado;
			protected System.Web.UI.WebControls.Label lblSaldo;
			protected System.Web.UI.WebControls.Label lblPrespuestoF;
			protected System.Web.UI.WebControls.Label lblEjecutadoF;
			protected System.Web.UI.WebControls.Label lblSaldoF;
			protected System.Web.UI.WebControls.DropDownList ddlCentroOperativo;
			protected System.Web.UI.WebControls.TextBox txtBuscar;
			protected projDataGridWeb.DataGridWeb grid;
			protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Image imgCancelar;
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
			this.ddlCentroOperativo.SelectedIndexChanged += new System.EventHandler(this.ddlCentroOperativo_SelectedIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		DataTable ObtenerDatos()
		{
			//return (new CGrupoCentroCosto()).ListarGrupoCCPorCentroOperativo(Convert.ToInt32(this.ddlCentroOperativo.SelectedValue));
				DataTable dtTMP = new DataTable();
				dtTMP.Columns.Add(new DataColumn("idGrupoCC", typeof(int)));
				dtTMP.Columns.Add(new DataColumn("Nombre", typeof(string)));
				DataRow dr;
				dr = dtTMP.NewRow();
				dr["idGrupoCC"] = 1;
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
			// TODO:  Add BuscarGrupodeCentrodeCosto.LlenarGrillaOrdenamiento implementation
		}
		
		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
		}
		private void CargarCentroOperativo()
		{
			this.ddlCentroOperativo.DataSource = (new CCentroOperativo()).ListarCentroOperativoAccesoSegunPrivilegioUsuario(CNetAccessControl.GetIdUser(),Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraPresupuestoRequerimiento));
			this.ddlCentroOperativo.DataValueField=Enumerados.ColumnasCentroOperativo.IdCentroOperativo.ToString();
			this.ddlCentroOperativo.DataTextField=Enumerados.ColumnasCentroOperativo.Nombre.ToString();
			this.ddlCentroOperativo.DataBind();
		}

		public void LlenarCombos()
		{
			this.CargarCentroOperativo();
		}

		public void LlenarDatos()
		{
			// TODO:  Add BuscarGrupodeCentrodeCosto.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			this.ddlCentroOperativo.Attributes.Add(Utilitario.Constantes.EVENTOONCHANGE,"CargarDatos();");
			this.txtBuscar.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,"ConsultarGruposdeCentrosdeCostos()");
		}

		public void RegistrarJScript()
		{
			// TODO:  Add BuscarGrupodeCentrodeCosto.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add BuscarGrupodeCentrodeCosto.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add BuscarGrupodeCentrodeCosto.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add BuscarGrupodeCentrodeCosto.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add BuscarGrupodeCentrodeCosto.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void ddlCentroOperativo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.LlenarGrilla();
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				Helper.ConfiguraColumnaHyperLink(e.Item.Cells[0],grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
			}		
		}
	}
}
