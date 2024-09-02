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
	/// Summary description for AdministrarPlanEstrategicoBase.
	/// </summary>
	public class AdministrarPlanEstrategicoBase : System.Web.UI.Page,IPaginaBase
	{
		#region Constante
			const string GRILLAVACIA="No Existen datos Plan Estrategico";
			const string KEYQIDPLANESTRATEGICO="idPLEstr";
			const string KEYQPLANESTRATEGICONOMBRE="PLEstrNombre";
			const string URLDETALLE="DetallePlanEstrategicoBase.aspx";
			const string URLADMOBJETIVOGENERAL="AdministrarPlanEstrategicoObjetivoGeneral.aspx";
		//JScript
		string JSVERIFICARELIMINAR = "return verificarEliminarRb('hCodigo','" + Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO)+"','"+Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJEPREGUNTAELIMINACIONREGISTRO)+"');";
		#endregion
		#region Controles
			protected System.Web.UI.WebControls.Label lblRutaPagina;
			protected System.Web.UI.WebControls.Label lblPagina;
			protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;
			protected System.Web.UI.WebControls.ImageButton ibtnEliminaFiltro;
			protected System.Web.UI.WebControls.Label Label3;
			protected System.Web.UI.WebControls.ImageButton ibtnAgregar;
			protected projDataGridWeb.DataGridWeb grid;
			protected System.Web.UI.WebControls.Label lblResultado;
			protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
			protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
			protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPaginaSort;
			protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion	
		private void Page_Load(object sender, System.EventArgs e)
		{
			this.grid.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(Utilitario.Helper.FooterSpan);
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					this.LlenarJScript();
					Helper.ReiniciarSession();
					this.LlenarCombos();
					Helper.ReestablecerPagina(this);
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionFinanciera",this.ToString(),"Se consultó Carta de Crédito.",Enumerados.NivelesErrorLog.I.ToString()));
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
			this.ibtnFiltrar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnFiltrar_Click);
			this.ibtnEliminaFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminaFiltro_Click);
			this.ibtnAgregar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAgregar_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{

				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				Helper.ConfiguraColumnaHyperLink(e.Item.Cells[0],grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex,
					Helper.HistorialIrAdelantePersonalizado("hGridPagina","hGridPaginaSort"),
					Helper.MostrarVentana(URLDETALLE+ Utilitario.Constantes.SIGNOINTERROGACION,KEYQIDPLANESTRATEGICO + Utilitario.Constantes.SIGNOIGUAL + dr["IDPLANESTRATEGICO"].ToString()
											+ Utilitario.Constantes.SIGNOAMPERSON
											+ Utilitario.Constantes.KEYMODOPAGINA +  Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.M.ToString()));
						
				
				
				Helper.ConfiguraColumnaHyperLink(Enumerados.EventosJavaScript.OnClick,e.Item.Cells[1]
					,Helper.HistorialIrAdelantePersonalizado("hGridPagina","hGridPaginaSort")
					,Helper.MostrarVentana(URLADMOBJETIVOGENERAL + Utilitario.Constantes.SIGNOINTERROGACION,KEYQIDPLANESTRATEGICO + Utilitario.Constantes.SIGNOIGUAL + dr["IDPLANESTRATEGICO"].ToString()
																 + Utilitario.Constantes.SIGNOAMPERSON
																 + KEYQPLANESTRATEGICONOMBRE + Utilitario.Constantes.SIGNOIGUAL + dr["Descripcion"].ToString()));
				
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				Helper.FiltroporSeleccionConfiguraColumna(e,grid,true,"txtBuscar");
			}					
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add AdministrarPlanEstrategicoBase.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarPlanEstrategicoBase.LlenarGrillaOrdenamiento implementation
		}
		private DataTable ObtenerDatos()
		{
			return (new CPEBase()).ListarTodosGrilla(Utilitario.Constantes.FLAGDEFAULT);
		}
		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dt = this.ObtenerDatos();
			if(dt!=null)
			{
				DataView dw = dt.DefaultView;
				dw.RowFilter = Helper.ObtenerFiltro();
				dw.Sort = columnaOrdenar ;
				grid.Columns[Utilitario.Constantes.POSICIONFOOTERTOTAL].FooterText = Utilitario.Constantes.TEXTOFOOTERTOTAL + Utilitario.Constantes.ESPACIO + dw.Count.ToString();
				grid.DataSource = dw;
				grid.CurrentPageIndex = Convert.ToInt32(this.hGridPagina.Value);
				lblResultado.Visible = false;

			}
			else
			{
				grid.DataSource = dt;
				lblResultado.Visible = true;
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
			// TODO:  Add AdministrarPlanEstrategicoBase.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add AdministrarPlanEstrategicoBase.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			ibtnAgregar.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.POPUPDEESPERA + Helper.HistorialIrAdelantePersonalizado("hGridPagina","hGridPaginaSort"));
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarPlanEstrategicoBase.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministrarPlanEstrategicoBase.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarPlanEstrategicoBase.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add AdministrarPlanEstrategicoBase.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add AdministrarPlanEstrategicoBase.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void ibtnAgregar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Page.Response.Redirect(URLDETALLE + Utilitario.Constantes.SIGNOINTERROGACION + Utilitario.Constantes.KEYMODOPAGINA +  Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.N.ToString());
		}

		private void ibtnEliminaFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}

		private void ibtnFiltrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			ltlMensaje.Text = Helper.ElaborarFiltro(this.ObtenerDatos(),"Descripcion;Descripcion");
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.hGridPagina.Value=e.NewPageIndex.ToString();
			grid.CurrentPageIndex=Convert.ToInt32(this.hGridPagina.Value);
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);	

		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			hGridPaginaSort.Value=Helper.GenerarExpresionOrdenamiento(e.SortExpression);
			this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Helper.ObtenerIndicePagina());
		}
	}
}
