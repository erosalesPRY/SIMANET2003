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
using SIMA.Controladoras.Convenio;
using SIMA.Controladoras;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using NullableTypes;




namespace SIMA.SimaNetWeb.Convenio
{
	/// <summary>
	/// Summary description for ConsultarPeriodoUnidadesApoyo.
	/// </summary>
	public class ConsultarActividadesConvenio : System.Web.UI.Page, IPaginaBase
	{

		#region Controles
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblDescripcion;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.Label lblObservaciones;
		protected System.Web.UI.WebControls.DataGrid gridReporte;
	
		#endregion Controles

		#region Constantes

		//Columnas
		const string COLORDENAMIENTO="Periodo";

		//URL
		const string URLIMPRESION="";
		const string URLEXPORTAREXCEL="";
		const string URLCONSULTARACTIVIDADESCONVENIO="ConsultarActividadesConvenio.aspx?";
		const string URLCONSULTARORDENTRABAJOUNIDADAPOYO="ConsultarOrdenTrabajoUnidadApoyo.aspx?";
		const string URLPRINCIPAL="ConsultarConvenioSimaMgpUnidadesApoyo.aspx";
		const string URLANTERIOR="ConsultarConvenioSimaMgpUnidadesApoyo.aspx?";
		
		// KEYID
		const string KEYIDPERIODOUNIDADESAPOYO="IdPeriodoUnidadesApoyo";
		const string KEYQPERIODO="Periodo";
		const string KEYACTIVIDAD="act";

		//OTROS
		const string GRILLAVACIA="NO HAY PERIODOS DE UNIDADES DE APOYO";

		//Controles
		const string CONTROLINK="hlkID";

		#endregion Constantes

		#region variables
		double acumMontoAsignado=0;
		//double acumMontoAprovado=0;
		double acumMontoEjecutado=0;
		double acumMontoEnEjecucion=0;
		protected System.Web.UI.WebControls.TextBox txtObservaciones;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminaFiltro;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltro;
		protected System.Web.UI.WebControls.ImageButton ibtnExportar;
		//double acumMontoComprometido=0;
		double acumMontoSaldo=0;
		
		#endregion variables

		private string SeleccionPeriodoInicial(int pPeriodoInicial)
		{
			int SeleccionPeriodoInicial;
			if((DateTime.Now.Year-4)<=pPeriodoInicial)
			{
				SeleccionPeriodoInicial=pPeriodoInicial;
			}
			else
			{
				SeleccionPeriodoInicial=DateTime.Now.Year-4;
			}

			return SeleccionPeriodoInicial.ToString();
		}

		private void LlenarPeriodos()
		{
		}



		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarJScript();
					this.LlenarCombos();

					this.LlenarGrillaOrdenamientoPaginacion(COLORDENAMIENTO,Utilitario.Constantes.INDICEPAGINADEFAULT);

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
			this.ibtnFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnFiltro_Click);
			this.ibtnEliminaFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminaFiltro_Click);
			this.ibtnExportar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnExportar_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.txtDescripcion.TextChanged += new System.EventHandler(this.txtDescripcion_TextChanged);
			this.txtObservaciones.TextChanged += new System.EventHandler(this.txtObservaciones_TextChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add ConsultarPeriodoUnidadesApoyo.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarPeriodoUnidadesApoyo.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			CPeriodoUnidadesApoyo oCPeriodoUnidadesApoyo=new CPeriodoUnidadesApoyo();
			DataTable dtUnidadesApoyo = oCPeriodoUnidadesApoyo.ConsultarMontoUnidadesDeApoyoAgrupadoPorPeriodos(2000,DateTime.Now.Year);
         	txtDescripcion.Text="";
			txtObservaciones.Text="";

			if(dtUnidadesApoyo!=null)
			{
				DataView dwUnidadesApoyo = dtUnidadesApoyo.DefaultView;
				dwUnidadesApoyo.RowFilter=Helper.ObtenerFiltro();
				dwUnidadesApoyo.Sort = columnaOrdenar;
				grid.DataSource = dwUnidadesApoyo;
				CImpresion oCImpresion = new CImpresion();
				oCImpresion.GuardarDataImprimirExportar(dtUnidadesApoyo,"REPORTE DE ORDENES DE TRABAJO",columnaOrdenar,indicePagina);
				lblResultado.Visible = false;
				indicePagina=Helper.ValidarIndicePaginacionGrilla(dwUnidadesApoyo.Count,grid.PageSize,indicePagina);
				grid.Columns[2].FooterText = dwUnidadesApoyo.Count.ToString();
			}
			else
			{
				grid.DataSource = dtUnidadesApoyo;
				lblResultado.Visible = true;
				lblResultado.Text = GRILLAVACIA;
			
			}
			try
			{
				grid.CurrentPageIndex=indicePagina;
				grid.DataBind();
			}
			catch
			{
				//string a =da.Message.ToString();
				grid.CurrentPageIndex = 0;
				grid.DataBind();
			}
		}

		public void LlenarCombos()
		{
			this.LlenarPeriodos();
			if(!NullableString.ParseEmptyToNull(this.Page.Request.Params[Utilitario.Constantes.KeyQPaginaValorInicial]).IsNull)
			{
				Helper.SeleccionarItemCombos(this);
			}
		}

		public void LlenarDatos()
		{
			// TODO:  Add ConsultarPeriodoUnidadesApoyo.LlenarDatos implementation
		}

		public void LlenarJScript()
		{


		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarPeriodoUnidadesApoyo.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			//ltlMensaje.Text = Helper.PopupImpresion(URLIMPRESION,700,700,false,false,false,true,true);

		}

		public void Exportar()
		{

			// TODO:  Add ConsultarPeriodoUnidadesApoyo.Exportar implementation
		}

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

		public bool ValidarFiltros()
		{
			// TODO:  Add ConsultarPeriodoUnidadesApoyo.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void ibtnImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Imprimir();
		}

		private void ibtnExportar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			///CActividadesConvenio oCActividadesConvenio = new CActividadesConvenio();
			
			///DataTable dtActividadesConvenio = oCActividadesConvenio.ActividadesConvenio(act);
				
			
			///if(dtActividadesConvenio != null)
			///{
			///	DataView dwActividadesConvenio = dtActividadesConvenio.DefaultView;
			///	this.gridReporte.DataSource = dwActividadesConvenio;

			///	try
			///	{
			///		this.gridReporte.DataBind();
			///	}
			///	catch(Exception a)
			///	{
			///		string b = a.Message.ToString();
			///		this.gridReporte.DataBind();
			///	}

			///	Helper.GenerarExcelCompleto(this, this.gridReporte);
			///}
			///else
			///{
			///	this.gridReporte.DataSource = dtActividadesConvenio;
			///}

		
			}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				
				e.Item.Cells[1].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
				e.Item.Cells[1].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				string sUrl=Helper.MostrarVentana(URLCONSULTARACTIVIDADESCONVENIO,KEYACTIVIDAD +
					Utilitario.Constantes.SIGNOIGUAL +
					Convert.ToString(dr[Enumerados.ColumnasActividadesConvenio.act.ToString()]) + 
					Utilitario.Constantes.SIGNOAMPERSON + KEYACTIVIDAD + Utilitario.Constantes.SIGNOIGUAL + 
					Convert.ToString(dr[Enumerados.ColumnasActividadesConvenio.descripcion.ToString()]) + Utilitario.Constantes.SIGNOPUNTOYCOMA +
					Utilitario.Constantes.POPUPDEESPERA);
				e.Item.Cells[1].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,sUrl);
				e.Item.Cells[1].Font.Underline=true;
				e.Item.Cells[1].ForeColor=Color.Blue;

				string Cadena="";

				if(!NullableDouble.Parse(dr[Enumerados.ColumnasPeriodoUnidadesApoyo.MontoAsignado.ToString()]).IsNull)
				{
					acumMontoAsignado = acumMontoAsignado + Convert.ToDouble(dr[Enumerados.ColumnasPeriodoUnidadesApoyo.MontoAsignado.ToString()]);
				}


				if(!NullableDouble.Parse(dr[Enumerados.ColumnasPeriodoUnidadesApoyo.MontoEjecutado.ToString()]).IsNull)
				{
					acumMontoEjecutado = acumMontoEjecutado + Convert.ToDouble(dr[Enumerados.ColumnasPeriodoUnidadesApoyo.MontoEjecutado.ToString()]);
				}

				if(!NullableDouble.Parse(dr[Enumerados.ColumnasPeriodoUnidadesApoyo.MontoEnEjecucion.ToString()]).IsNull)
				{
					acumMontoEnEjecucion = acumMontoEnEjecucion + Convert.ToDouble(dr[Enumerados.ColumnasPeriodoUnidadesApoyo.MontoEnEjecucion.ToString()]);
				}

				if(!NullableDouble.Parse(dr[Enumerados.ColumnasPeriodoUnidadesApoyo.MontoSaldo.ToString()]).IsNull)
				{
					acumMontoSaldo = acumMontoSaldo + Convert.ToDouble(dr[Enumerados.ColumnasPeriodoUnidadesApoyo.MontoSaldo.ToString()]);
				}

				Cadena="MostrarDescripcionObservaciones('txtDescripcion','txtObservaciones','" + Helper.LimpiarTexto(Convert.ToString(dr[Enumerados.ColumnasPeriodoUnidadesApoyo.Descripcion.ToString()])) + "','" + Helper.LimpiarTexto(Convert.ToString(dr[Enumerados.ColumnasPeriodoUnidadesApoyo.Observaciones.ToString()])) +"'); ";

				Utilitario.Helper.SeleccionarItemGrillaOnClickMoverRaton(e,Cadena);
				Helper.FiltroporSeleccionConfiguraColumna(e,this.grid);
				

			}
			else if(e.Item.ItemType == ListItemType.Footer)
			{
				e.Item.Cells[2].Text =Utilitario.Constantes.TEXTOTOTAL;
				e.Item.Cells[3].Text = acumMontoAsignado.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[4].Text = acumMontoEjecutado.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[5].Text = acumMontoEnEjecucion.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[6].Text = acumMontoSaldo.ToString(Utilitario.Constantes.FORMATODECIMAL4);
			}
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(e.SortExpression),Helper.ObtenerIndicePagina());
		}

		private void RedireccionarPaginaPrevia()
		{
			this.Page.Response.Redirect(URLPRINCIPAL);
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.grid.CurrentPageIndex=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex); //Helper.ObtenerColumnaOrdenamiento()
		}

		private void ibtnEliminaFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}

		private void ibtnFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			object[] campos={"PERIODO;PERIODO","MontoAsignado;ASIGNADO","MontoEjecutado;EJECUTADO","MontoEnEjecucion;EN EJECUCION","MontoSaldo;SALDO","Descripcion;DESCRIPCION"};
			string CamposFiltro=Utilitario.Helper.ElaborarFiltro(campos);

			this.ltlMensaje.Text=CamposFiltro;
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void txtDescripcion_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void txtObservaciones_TextChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
