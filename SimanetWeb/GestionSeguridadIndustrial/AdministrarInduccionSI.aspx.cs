using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using SIMA.SimaNetWeb.InterfacesIU;
using SIMA.Controladoras.Personal;
using SIMA.Controladoras.GestionSeguridadIndustrial;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;


namespace SIMA.SimaNetWeb.GestionSeguridadIndustrial
{
	/// <summary>
	/// Summary description for AdministrarInduccionSI.
	/// </summary>
	public class AdministrarInduccionSI : System.Web.UI.Page,IPaginaBase
	{
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminaFiltro;
		protected System.Web.UI.WebControls.ImageButton ibtnAgregar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminar;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPaginaSort;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;

		const string KEYQDNI ="NroDNI";
		const string KEYQNOMTRAB ="NomTrab";
		const string KEYQPERIODOEM ="PeriodoEM";
		const string KEYQIDEXAMENEM ="idExaEM";
		
		const string URLDETALLEHST = "AdministrarHistorialInduccionSI.aspx?";
		const string URLDETALLE = "DetalleEvaluacionInduccionSI.aspx?";
		protected System.Web.UI.WebControls.HyperLink HyperLink1;
		
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
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(), "Gestión de Personal: Administrar Programación Personal Contratista", this.ToString(),"Se consultó El Listado de las programaciones de los contratistas",Enumerados.NivelesErrorLog.I.ToString()));
					Helper.ReestablecerPagina();
					this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value, Convert.ToInt32(hGridPagina.Value));

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
					string msg = oException.Message.ToString();
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
			this.grid.PreRender += new System.EventHandler(this.grid_PreRender);
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

				string parametros =KEYQDNI+ Utilitario.Constantes.SIGNOIGUAL + dr["NroDNI"].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYQNOMTRAB + Utilitario.Constantes.SIGNOIGUAL +  dr["ApellidosyNombres"].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYQPERIODOEM + Utilitario.Constantes.SIGNOIGUAL +  dr["Periodo"].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYQIDEXAMENEM + Utilitario.Constantes.SIGNOIGUAL +  dr["IdEvaluacion"].ToString();

				Helper.ConfiguraColumnaHyperLink(e.Item.Cells[0],grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex,
					Helper.HistorialIrAdelantePersonalizado(this.hGridPagina.ID.ToString(),this.hGridPaginaSort.ID.ToString())
					,Helper.MostrarVentana(URLDETALLEHST,parametros));

				Label lbl = (Label)e.Item.Cells[3].FindControl("lblFechaInicio");
				lbl.Text = dr["FechaInicio"].ToString();

				lbl = (Label)e.Item.Cells[3].FindControl("lblFechaVence");
				lbl.Text = dr["FechaVencimiento"].ToString();

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				Helper.FiltroporSeleccionConfiguraColumna(e,grid);

			}
		}
		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add AdministrarInduccionSI.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarInduccionSI.LlenarGrillaOrdenamiento implementation
		}
		DataTable ObtenerDatos()
		{
			return(new CCCTT_InduccionEvaluacion()).ListarTodosGrilla();
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dt = this.ObtenerDatos();
			if (dt!=null)
			{
				DataView dv     = dt.DefaultView;
				dv.Sort         = columnaOrdenar;
				dv.RowFilter    = Utilitario.Helper.ObtenerFiltro();
				grid.DataSource = dv;
				grid.CurrentPageIndex = indicePagina;
			}
			else
			{
				grid.DataSource = dt;
			}
			
			try
			{
				grid.DataBind();
			}
			catch (Exception exception)
			{
				string mensaje = exception.Message.ToString();
				grid.CurrentPageIndex = 0;
				grid.DataBind();
			}		
		}

		public void LlenarCombos()
		{
			// TODO:  Add AdministrarInduccionSI.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add AdministrarInduccionSI.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			this.ibtnAgregar.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado("hGridPaginaSort","hGridPagina"));
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarInduccionSI.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministrarInduccionSI.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarInduccionSI.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add AdministrarInduccionSI.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add AdministrarInduccionSI.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void ibtnAgregar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			string Parametros = Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.N.ToString();
			Page.Response.Redirect(URLDETALLE+ Parametros,false);
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void ibtnFiltrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			ltlMensaje.Text = Helper.ElaborarFiltro(this.ObtenerDatos(),"NroDNI;Nro documento"
												,"ApellidosyNombres;Apellidos y Nombres"
												,"*Disponible;Disponibilidad"
												,"*Aprobado;Aprobado");
		}

		private void ibtnEliminaFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}

		private void grid_PreRender(object sender, System.EventArgs e)
		{
		
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			hGridPagina.Value=e.NewPageIndex.ToString();
			this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value, Convert.ToInt32(hGridPagina.Value));
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			hGridPaginaSort.Value=e.SortExpression;
			this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value, Convert.ToInt32(hGridPagina.Value));
		}
	}
}
