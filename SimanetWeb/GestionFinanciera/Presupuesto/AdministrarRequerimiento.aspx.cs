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
	/// Summary description for AdministrarRequerimiento.
	/// </summary>
	public class AdministrarRequerimiento : System.Web.UI.Page,IPaginaBase
	{
		#region Constantes
			const string GRILLAVACIA="No existe Datos";
			const string URLPAGINA="DetalledeRequerimiento.aspx?";
			const string URLPAGINADEFAULTTRASNFERENCIA="DefaultTransferencia.aspx?";
			
			


			const string KEYIDLBLMONTOREQUERIDO="lblMontoRequerido";
			const string KEYIDLBLMONTOAPROBADO="lblMontoAprobado";


			//PARAMETROS QUE SERAN UTILIZADOS E LA TRANSFERENCIA
			const string KEYIDREQUERIMIENTO="idrqr";

			const string KEYQTIPOPRESUPUESTO="idTP";
			const string KEYQIDCENTROOPERATIVO="idCentro";
			const string KEYQIDGRUPOCC="idGrupoCC";
			const string KEYQIDCENTROCOSTO="idCC";
			const string KEYQPERIODO="Periodo";
			const string KEYQMES="idMes";
			
			const string KEYQNRODOC="NDoc";
			const string KEYQMOTIVO="Motivo";
			//const string KEYQIDTRANSFERENCIA="idTransf";

		#endregion

		#region Controles
			protected System.Web.UI.WebControls.Label lblPagina;
			protected projDataGridWeb.DataGridWeb grid;
			protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPaginaSort;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		protected System.Web.UI.WebControls.ImageButton imgbtnImportar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminaFiltro;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnFiltrarSeleccion;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.ImageButton ibtnAgregar;
		protected System.Web.UI.WebControls.ImageButton ibtnAutorizar;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hperiodo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden idTipoPPto;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidRQR;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidTransf;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hNroDoc;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hDescripcion;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hMotivo;
		protected System.Web.UI.HtmlControls.HtmlTable tblToolBar;
			protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					Helper.ReestablecerPagina(this);
					this.LlenarJScript();
					this.LlenarDatos();
					this.LlenarCombos();
					this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Convert.ToInt32(this.hGridPagina.Value));	
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
					Helper.ControlarErrorIU(this,msgb);
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
			this.ibtnEliminaFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminaFiltro_Click);
			this.ibtnAutorizar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAutorizar_Click);
			this.ibtnAgregar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAgregar_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add AdministrarRequerimiento.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarRequerimiento.LlenarGrillaOrdenamiento implementation
		}

		private DataTable ObtenerDatos(){
			return (new CPresupuestoRequerimiento()).ConsultarRequerimientos(CNetAccessControl.GetIdUser());
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dt = this.ObtenerDatos();
			if(dt!=null)
			{
				DataView dv = dt.DefaultView;
				dv.RowFilter = Helper.ObtenerFiltro();
				grid.DataSource = dv;
				grid.CurrentPageIndex =indicePagina;
				lblResultado.Visible = false;
			}
			else
			{
				this.tblToolBar.Style.Add(Utilitario.Constantes.DISPLAY,Utilitario.Constantes.NONE);
				grid.DataSource = dt;
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
			// TODO:  Add AdministrarRequerimiento.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add AdministrarRequerimiento.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			ibtnAgregar.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.POPUPDEESPERA + Helper.HistorialIrAdelantePersonalizado("hGridPagina","hGridPaginaSort"));
			ibtnAutorizar.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.POPUPDEESPERA + Helper.HistorialIrAdelantePersonalizado("hGridPagina","hGridPaginaSort"));
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarRequerimiento.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministrarRequerimiento.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarRequerimiento.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add AdministrarRequerimiento.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add AdministrarRequerimiento.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				string parametros = KEYIDREQUERIMIENTO + Utilitario.Constantes.SIGNOIGUAL + dr[Utilitario.Enumerados.FinColumnaPresupuestoRequerimiento.idRequerimiento.ToString()].ToString()
									+ Utilitario.Constantes.SIGNOAMPERSON 
									+ Utilitario.Constantes.KEYMODOPAGINA +  Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.M.ToString();

				Helper.ConfiguraColumnaHyperLink(e.Item.Cells[0],grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex,
					Helper.HistorialIrAdelantePersonalizado("hGridPagina","hGridPaginaSort")
					,Helper.MostrarVentana(URLPAGINA,parametros));


				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,Helper.MostrarDatosEnCajaTexto("hidRQR",dr["idRequerimiento"].ToString())
																,Helper.MostrarDatosEnCajaTexto("hperiodo",dr["Periodo"].ToString())
																,Helper.MostrarDatosEnCajaTexto("idTipoPPto",dr["idTipoPresupuesto"].ToString())
																,Helper.MostrarDatosEnCajaTexto("hNroDoc",dr["NroDocumento"].ToString())
																,Helper.MostrarDatosEnCajaTexto("hMotivo",dr["Motivo"].ToString())
															 );

				Label lblMonto = (Label)e.Item.Cells[0].FindControl(KEYIDLBLMONTOREQUERIDO);
				lblMonto.Text = Convert.ToDouble(dr["Monto"].ToString()).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				lblMonto = (Label)e.Item.Cells[0].FindControl(KEYIDLBLMONTOAPROBADO);
				lblMonto.Text = Convert.ToDouble(dr["MontoAprobado"].ToString()).ToString(Utilitario.Constantes.FORMATODECIMAL4);

				Helper.FiltroporSeleccionConfiguraColumna(e,grid,true,"txtBuscar");
			}
		
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void ibtnEliminaFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}

		private void ibtnAgregar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Page.Response.Redirect(URLPAGINA + Utilitario.Constantes.KEYMODOPAGINA +  Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.N.ToString());
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.hGridPagina.Value=e.NewPageIndex.ToString();
			grid.CurrentPageIndex=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);			
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			hGridPaginaSort.Value=Helper.GenerarExpresionOrdenamiento(e.SortExpression);
			this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Helper.ObtenerIndicePagina());		
		}

		private void ibtnAutorizar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Page.Response.Redirect(URLPAGINADEFAULTTRASNFERENCIA 
									+ KEYIDREQUERIMIENTO + Utilitario.Constantes.SIGNOIGUAL + this.hidRQR.Value 
									+ Utilitario.Constantes.SIGNOAMPERSON
									+ KEYQPERIODO + Utilitario.Constantes.SIGNOIGUAL + this.hperiodo.Value
									+ Utilitario.Constantes.SIGNOAMPERSON
									+ KEYQTIPOPRESUPUESTO + Utilitario.Constantes.SIGNOIGUAL + this.idTipoPPto.Value
									+ Utilitario.Constantes.SIGNOAMPERSON
									+ KEYQNRODOC + Utilitario.Constantes.SIGNOIGUAL + this.hNroDoc.Value
									+ Utilitario.Constantes.SIGNOAMPERSON
									+ KEYQMOTIVO + Utilitario.Constantes.SIGNOIGUAL + this.hMotivo.Value
									);
		}
	}
}
