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
using SIMA.Controladoras.GestionEstrategica;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using SIMA.Controladoras;
using SIMA.Controladoras.General;

namespace SIMA.SimaNetWeb.DirectorioEjecutivo.GestionEstrategica
{
	public class ConsultarPlanEstrategicoObjetivosGenerales : System.Web.UI.Page, IPaginaBase
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
			this.dllVisibilidad.SelectedIndexChanged += new System.EventHandler(this.dllVisibilidad_SelectedIndexChanged);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		#region IPaginaBase Members

		public void ConfigurarAccesoControles()
		{
			if(CNetAccessControl.FindPage(Page.Request.Url.AbsolutePath.ToString()))
			{
				CNetAccessControl.LoadControls(this);
			}
			else
			{
				
				CNetAccessControl.RedirectPageError();
				
			}
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
		{
			CObjetivoGeneral oCObjetivoGeneral =  new CObjetivoGeneral();
			DataTable dtOGeneral;
			
			const string KEYIDVERSION  = "KEYIDVERSION";
			
			int idVersion = Convert.ToInt32(Page.Request.QueryString[KEYIDVERSION]);

			if(Page.Request.QueryString[KEYIDPLANOPERATIVO] != null)
			{
				dtOGeneral =  oCObjetivoGeneral.ListarObjetivoGeneralesPlanEstrategico(Convert.ToInt32(dllVisibilidad.SelectedValue.ToString()),Convert.ToInt32(Utilitario.Helper.FechaSimanet.ObtenerFechaSesion().Year));
			}
			else
			{
				if (Page.Request.QueryString[KEYQFILTRO] == null)
				{
					lblTituloPrincipal.Text = "DESPLIEGUE DEL PLAN ESTRATEGICO";
					dtOGeneral =  oCObjetivoGeneral.ListarObjetivoGeneralesPlanEstrategico(Convert.ToInt32(dllVisibilidad.SelectedValue.ToString()),idVersion);
				}
				else
					dllVisibilidad.SelectedValue = Page.Request.QueryString[KEYQFILTRO];
				dtOGeneral =  oCObjetivoGeneral.ListarObjetivoGeneralesPlanEstrategico(Convert.ToInt32(Page.Request.QueryString[KEYQFILTRO]),idVersion);
			}

			if(dtOGeneral!=null)
			{
				DataView dwOGeneral = dtOGeneral.DefaultView;
				grid.DataSource = dwOGeneral;
				dwOGeneral.RowFilter = Helper.ObtenerFiltro(this);

				if (dwOGeneral.Count == 0)
				{
					grid.DataSource = null; 
				}
				else
				{
					grid.DataSource = dwOGeneral;
					grid.Columns[0].FooterText = TEXTOFOOTERTOTAL;
					grid.Columns[POSICIONFOOTERTOTAL].FooterText = dwOGeneral.Count.ToString();
				}
			}
			else
			{
				lblresul.Visible = true;
				lblresul.Text = GRILLAVACIA +  Convert.ToInt32(Utilitario.Helper.FechaSimanet.ObtenerFechaSesion().Year).ToString();
				grid.DataSource = dtOGeneral;
			}
			
			try
			{
				grid.DataBind();
			}
			catch(Exception ex)
			{
				string a = ex.Message;
				grid.CurrentPageIndex = 0;
				grid.DataBind();
			}
			
		}

		public void LlenarGrilla()
		{
			// TODO:  Add ConsultarPlanEstrategicoObjetivosGenerales.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarPlanEstrategicoObjetivosGenerales.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarCombos()
		{
			CTablaTablas oCTablaTablas =  new CTablaTablas();		
			dllVisibilidad.DataSource = oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Enumerados.TablasTabla.NivelesVisibilidad));
			dllVisibilidad.DataValueField = Enumerados.ColumnasTablasTablas.Codigo.ToString();
			dllVisibilidad.DataTextField = Enumerados.ColumnasTablasTablas.Descripcion.ToString();
			dllVisibilidad.DataBind();
		}

		public void LlenarDatos()
		{
			// TODO:  Add ConsultarPlanEstrategicoObjetivosGenerales.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarPlanEstrategicoObjetivosGenerales.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarPlanEstrategicoObjetivosGenerales.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarPlanEstrategicoObjetivosGenerales.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarPlanEstrategicoObjetivosGenerales.Exportar implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ConsultarPlanEstrategicoObjetivosGenerales.ValidarFiltros implementation
			return false;
		}

		#endregion
		#region Constantes
		//ODERNAMIENTO
		const int COLUMNANUMERACION = 0;
		const int COLUMNADETALLEOGENERALES= 1;
		
		//URLS
		const string URLPLANESTRATEGICOOBJETIVOSESPECIFICOS = "ConsultarPlanEstrategicoObjetivoEspecifico.aspx?";
		const string URLADMINISTRACIONESTRATEGICOOBJETIVOSESPECIFICOS = "../PlanGestion/AdministrarObjetivoEspecifico.aspx?";
		const string URLDETALLE = "DetallePlanEstrategicoObjetivosGenerales.aspx?";

		//INDICES
		const string KEYIDPLANOPERATIVO= "KEYIDPLANOPERATIVO";
		const string KEYQFILTRO = "IDVISIBILIDAD";
		const string KEYQIDOGENERAL = "IDOGENERALES";
		const string KEYOGENERALTEXTO = "DESCRIPCION";
		const string PE = "PlanEstrategico";
		const string KEYIDVERSION="KEYIDVERSION";
		const string KEYCODIGOGENERADO="KEYCODIGOGENERADO";

		//OTROS
		const string TEXTOFOOTERTOTAL = "Total:";
		const string GRILLAVACIA= "No existen actividades asociadas al año ";
		const string COLORDENAMIENTO = "IDOGENERALES";
		const int POSICIONFOOTERTOTAL = 1;
		#endregion
		#region Controles
		protected System.Web.UI.WebControls.Label lblTituloPrincipal;
		protected System.Web.UI.WebControls.Label lblresul;
		protected System.Web.UI.WebControls.Label lblPeriodo;
		protected System.Web.UI.WebControls.DropDownList dllVisibilidad;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		#endregion Controles
		#region Eventos
		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina, int idVisibilidad)
		{
			CObjetivoGeneral oCObjetivoGeneral =  new CObjetivoGeneral();
			
			DataTable dtOGeneral;
			const string KEYQIDVERSION="KEYQIDVERSION";
			int idVersion = Convert.ToInt32(Page.Request.QueryString[KEYQIDVERSION]);

			if(Page.Request.QueryString[KEYIDPLANOPERATIVO] != null)
			{
				lblTituloPrincipal.Text = "DESPLIEGUE DE PLAN OPERATIVO";
				dtOGeneral =  oCObjetivoGeneral.ListarObjetivoGeneralesPlanEstrategico(idVisibilidad, Convert.ToInt32(Utilitario.Helper.FechaSimanet.ObtenerFechaSesion().Year));
			}
			else
				dtOGeneral =  oCObjetivoGeneral.ListarObjetivoGeneralesPlanEstrategico(idVisibilidad,idVersion);
			
			if(dtOGeneral!=null)
			{
				DataView dwOGeneral = dtOGeneral.DefaultView;
				grid.DataSource = dwOGeneral;
				grid.PageSize = Helper.ObtenerCantidadRegistrosPorGrilla();
				dwOGeneral.RowFilter = Helper.ObtenerFiltro(this);

				if (dwOGeneral.Count == 0)
					grid.DataSource = null; 
				else
				{
					grid.DataSource = dwOGeneral;
					grid.Columns[0].FooterText = TEXTOFOOTERTOTAL;
					grid.Columns[POSICIONFOOTERTOTAL].FooterText = dwOGeneral.Count.ToString();
				}
			}
			else
			{
				lblresul.Visible = true;
				lblresul.Text = GRILLAVACIA +  Convert.ToInt32(Utilitario.Helper.FechaSimanet.ObtenerFechaSesion().AddYears(1).Year).ToString();
				grid.DataSource = dtOGeneral;
			}

			try
			{
				grid.DataBind();
			}
			catch(Exception ex)
			{
				string a = ex.Message;
				grid.CurrentPageIndex = 0;
				grid.DataBind();
			}

		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				int origen = Convert.ToInt32(Page.Request.QueryString[Utilitario.Enumerados.OpcionModuloGestionEstrategica.PlanEstrategico.ToString()]);

				e.Item.Cells[COLUMNANUMERACION].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
				e.Item.Cells[COLUMNANUMERACION].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				e.Item.Cells[COLUMNANUMERACION].Font.Underline = true;
				e.Item.Cells[COLUMNANUMERACION].ForeColor= System.Drawing.Color.Blue;

				e.Item.Cells[COLUMNADETALLEOGENERALES].Text = "OG" + e.Item.Cells[COLUMNANUMERACION].Text;

				if(origen != Convert.ToInt32(Utilitario.Enumerados.OpcionModuloGestionEstrategica.PlanEstrategico))
				{	
					#region Plan Director
					
					if (Page.Request.QueryString[KEYIDPLANOPERATIVO] != null)
					{
						e.Item.Cells[COLUMNANUMERACION].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
							Helper.MostrarVentana(URLPLANESTRATEGICOOBJETIVOSESPECIFICOS, 
							KEYQIDOGENERAL + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr[Utilitario.Enumerados.ColumnasObjetivosGenerales.IDOGENERALES.ToString()]) +
							Utilitario.Constantes.SIGNOAMPERSON +
							KEYOGENERALTEXTO + Utilitario.Constantes.SIGNOIGUAL +Convert.ToString(dr[Utilitario.Enumerados.ColumnasObjetivosGenerales.DESCRIPCION.ToString()]) + 
							Utilitario.Constantes.SIGNOAMPERSON + 
							KEYQFILTRO+ Utilitario.Constantes.SIGNOIGUAL + dllVisibilidad.SelectedValue.ToString()+
							Utilitario.Constantes.SIGNOAMPERSON +
							KEYIDPLANOPERATIVO + Utilitario.Constantes.SIGNOIGUAL +	Page.Request.QueryString[KEYIDPLANOPERATIVO] +
							Utilitario.Constantes.SIGNOAMPERSON +
							KEYCODIGOGENERADO + Utilitario.Constantes.SIGNOIGUAL + e.Item.Cells[COLUMNANUMERACION].Text 
							));
					}
					else
					{
						if(Page.Request.QueryString[KEYIDVERSION] == null)
							e.Item.Cells[COLUMNANUMERACION].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
								Helper.MostrarVentana(URLPLANESTRATEGICOOBJETIVOSESPECIFICOS, 
								KEYQIDOGENERAL + Utilitario.Constantes.SIGNOIGUAL + 
								Convert.ToString(dr[Utilitario.Enumerados.ColumnasObjetivosGenerales.IDOGENERALES.ToString()]) +
								Utilitario.Constantes.SIGNOAMPERSON +
								KEYOGENERALTEXTO + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr[Utilitario.Enumerados.ColumnasObjetivosGenerales.DESCRIPCION.ToString()])
								+ Utilitario.Constantes.SIGNOAMPERSON + 
								KEYQFILTRO+ Utilitario.Constantes.SIGNOIGUAL + dllVisibilidad.SelectedValue.ToString() +
								Utilitario.Constantes.SIGNOAMPERSON +
								KEYCODIGOGENERADO + Utilitario.Constantes.SIGNOIGUAL + e.Item.Cells[COLUMNANUMERACION].Text 
								));
						else
							e.Item.Cells[COLUMNANUMERACION].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
								Helper.MostrarVentana(URLPLANESTRATEGICOOBJETIVOSESPECIFICOS, 
								KEYQIDOGENERAL + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr[Utilitario.Enumerados.ColumnasObjetivosGenerales.IDOGENERALES.ToString()]) +
								Utilitario.Constantes.SIGNOAMPERSON +
								KEYOGENERALTEXTO + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr[Utilitario.Enumerados.ColumnasObjetivosGenerales.DESCRIPCION.ToString()])
								+ Utilitario.Constantes.SIGNOAMPERSON +
								KEYQFILTRO+ Utilitario.Constantes.SIGNOIGUAL + dllVisibilidad.SelectedValue.ToString() +
								Utilitario.Constantes.SIGNOAMPERSON +
								KEYIDVERSION + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYIDVERSION] +
								Utilitario.Constantes.SIGNOAMPERSON +
								KEYCODIGOGENERADO + Utilitario.Constantes.SIGNOIGUAL + e.Item.Cells[COLUMNANUMERACION].Text 
								));
					}		
					#endregion	
				}
				else
				{
					#region Plan Estrategico
					e.Item.Cells[COLUMNANUMERACION].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
						Helper.MostrarVentana(URLADMINISTRACIONESTRATEGICOOBJETIVOSESPECIFICOS, 
						KEYQIDOGENERAL + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr[Utilitario.Enumerados.ColumnasObjetivosGenerales.IDOGENERALES.ToString()]) +
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYOGENERALTEXTO + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr[Utilitario.Enumerados.ColumnasObjetivosGenerales.DESCRIPCION.ToString()]) +
						Utilitario.Constantes.SIGNOAMPERSON +
						PE + Utilitario.Constantes.SIGNOIGUAL +	Convert.ToInt32(Page.Request.QueryString[Utilitario.Enumerados.OpcionModuloGestionEstrategica.PlanEstrategico.ToString()]) + 
						Utilitario.Constantes.SIGNOAMPERSON + 
						KEYQFILTRO + Utilitario.Constantes.SIGNOIGUAL +	dllVisibilidad.SelectedValue.ToString() +
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYCODIGOGENERADO + Utilitario.Constantes.SIGNOIGUAL + e.Item.Cells[COLUMNANUMERACION].Text
						));
					#endregion
				}

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);	
				Helper.FiltroporSeleccionConfiguraColumna(e,grid);
			}
		}
		
		private void dllVisibilidad_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(COLORDENAMIENTO,Constantes.INDICEPAGINADEFAULT,Convert.ToInt32(dllVisibilidad.SelectedValue.ToString()));
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.LlenarCombos();
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionEstrategica",this.ToString(),"Se consulto el Modulo Gestion Estrategico.",Enumerados.NivelesErrorLog.I.ToString()));
					this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO),Utilitario.Constantes.INDICEPAGINADEFAULT);
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
					SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
					Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
				}
			}
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(e.SortExpression),Helper.ObtenerIndicePagina());
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			grid.CurrentPageIndex=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);
		}
		#endregion
	}
}
