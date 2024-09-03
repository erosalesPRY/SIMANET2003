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

namespace SIMA.SimaNetWeb.GestionFinanciera.LineasdeCredito
{
	/// <summary>
	/// Summary description for AdminsitraciondeLineadeCredito.
	/// </summary>
	public class AdminsitraciondeLineadeCredito : System.Web.UI.Page,IPaginaBase
	{
		#region Constantes
		
		const string  GRILLAVACIA="No existe";
		const string OBJPARAMETROCONTABLE = "ParamCtaBco";
		//Ordenamiento
		const string COLORDENAMIENTO = "id";

		//Nombres de Controles
		const string CONTROLINK = "hlkNroID";
		const string COLUMNACODIGO = "CODIGO";
		const string COLUMNADESCRIPCION = "DESCRIPCION";

		//Paginas
		const string URLDETALLE = "DetalledeLineadeCredito.aspx";
		const string URLPRINCIPAL="../../Default.aspx";
		
		//Key Session y QueryString
		const string KEYQID = "idLinea";
		const string KEYQPERIODO = "Periodo";
		const string KEYQIDESTADO= "IdEstado";

		#endregion

		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.ImageButton ibtnAgregar;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPaginaSort;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminaFiltro;
		protected System.Web.UI.WebControls.DropDownList ddlbEstadoLineaCredito;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion

		ListItem lItem;
		private void Page_Load(object sender, System.EventArgs e)
		{
			this.grid.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(Utilitario.Helper.FooterSpan);

			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarJScript();
					this.LlenarCombos();
					this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO),Constantes.INDICEPAGINADEFAULT);
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
			// Put user code to initialize the page here
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
			this.ddlbEstadoLineaCredito.SelectedIndexChanged += new System.EventHandler(this.ddlbEstadoLineaCredito_SelectedIndexChanged);
			this.ibtnEliminaFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminaFiltro_Click);
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
			// TODO:  Add AdminsitraciondeLineadeCredito.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdminsitraciondeLineadeCredito.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			CLineaCredito oCLineaCredito = new CLineaCredito();
			//DataTable dtGeneral = oCLineaCredito.AdministrarDetalleLineadeCredito(Utilitario.Constantes.IDDEFAULT.ToString(),Utilitario.Constantes.IDDEFAULT.ToString(),Utilitario.Constantes.IDDEFAULT.ToString());
			DataTable dtGeneral = oCLineaCredito.AdministrarDetalleLineadeCredito(Utilitario.Constantes.IDDEFAULT
																					,Utilitario.Constantes.IDDEFAULT
																					,Convert.ToInt32(this.ddlbEstadoLineaCredito.SelectedValue));
			if(dtGeneral!=null)
			{
				DataView dwGeneral = dtGeneral.DefaultView;
				
				dwGeneral.Sort = columnaOrdenar ;
				dwGeneral.RowFilter = Helper.ObtenerFiltro();
				grid.Columns[Utilitario.Constantes.POSICIONFOOTERTOTAL].FooterText = Utilitario.Constantes.TEXTOFOOTERTOTAL + Utilitario.Constantes.ESPACIO + dwGeneral.Count.ToString();
				grid.DataSource = dwGeneral;
				CImpresion oCImpresion = new CImpresion();
				oCImpresion.GuardarDataImprimirExportar(dtGeneral,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGOTITULOREPORTEACCIONCONTROLNOPROGRAMADA),columnaOrdenar,indicePagina);
				lblResultado.Visible = false;
			}
			else
			{
				grid.DataSource = dtGeneral;
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
			// TODO:  Add AdminsitraciondeLineadeCredito.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			this.LlenarEstadosLineasDeCredito();
		}

		public void LlenarDatos()
		{
			// TODO:  Add AdminsitraciondeLineadeCredito.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			this.ibtnAgregar.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado(Utilitario.Constantes.VACIO));
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdminsitraciondeLineadeCredito.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdminsitraciondeLineadeCredito.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdminsitraciondeLineadeCredito.Exportar implementation
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
			// TODO:  Add AdminsitraciondeLineadeCredito.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{				
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				HyperLink hlk = (HyperLink)e.Item.Cells[1].FindControl(CONTROLINK);
				hlk.Text = Convert.ToString(dr[Utilitario.Enumerados.FinColumnaLineaCredito.id.ToString()]);
				hlk.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado(Utilitario.Constantes.VACIO));
				hlk.NavigateUrl = URLDETALLE + Utilitario.Constantes.SIGNOINTERROGACION
						+  KEYQID + Utilitario.Constantes.SIGNOIGUAL + dr[Utilitario.Enumerados.FinColumnaLineaCredito.idlineacredito.ToString()].ToString()
						+  Utilitario.Constantes.SIGNOAMPERSON
						+  KEYQPERIODO + Utilitario.Constantes.SIGNOIGUAL + dr[Utilitario.Enumerados.FinColumnaLineaCredito.periodo.ToString()].ToString()
						+  Utilitario.Constantes.SIGNOAMPERSON
						+  KEYQIDESTADO + Utilitario.Constantes.SIGNOIGUAL + dr[Utilitario.Enumerados.FinColumnaLineaCredito.idestado.ToString()].ToString()
						+  Utilitario.Constantes.SIGNOAMPERSON
						+ Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL  + Enumerados.ModoPagina.M.ToString();

				e.Item.Cells[6].Text=Convert.ToDouble(e.Item.Cells[6].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4.ToString());

				e.Item.Cells[0].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				//e.Item.Cells[1].ForeColor = Color.Blue;
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
			}		
	
				Helper.FiltroporSeleccionConfiguraColumna(e,grid);
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		}

		private void ibtnAgregar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.RedirecionaPaginaPrincipal();
		}
		private void RedirecionaPaginaPrincipal()
		{
			Page.Response.Redirect(URLDETALLE + Utilitario.Constantes.SIGNOINTERROGACION + Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL  + Enumerados.ModoPagina.N.ToString());
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

		private void ibtnEliminaFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}

		private void LlenarEstadosLineasDeCredito()
		{
			CLineaCredito oCLineaCredito  = new CLineaCredito();
            DataTable dtEstadoLineaCredito = oCLineaCredito.ListarEstadosLineaCredito();
			if(dtEstadoLineaCredito != null)
			{
				this.ddlbEstadoLineaCredito.DataSource = dtEstadoLineaCredito;
				this.ddlbEstadoLineaCredito.DataValueField = dtEstadoLineaCredito.Columns[COLUMNACODIGO].ToString();
				this.ddlbEstadoLineaCredito.DataTextField = dtEstadoLineaCredito.Columns[COLUMNADESCRIPCION].ToString();			
			}
			else
			{
				lItem = new ListItem(Utilitario.Constantes.TEXTOSINVALOR ,Utilitario.Constantes.VALORSELECCIONAR);
				this.ddlbEstadoLineaCredito.Items.Insert(Utilitario.Constantes.ValorConstanteCero, lItem);
				this.ddlbEstadoLineaCredito.Enabled=false;
			}
			try
			{
				this.ddlbEstadoLineaCredito.DataBind();
				this.ddlbEstadoLineaCredito.Items.FindByValue(Utilitario.Constantes.ValorConstanteUno.ToString()).Selected = true;
			}
			catch(Exception e)
			{	
				string a = e.Message;
				lItem = new ListItem(Utilitario.Constantes.TEXTOSINVALOR,Utilitario.Constantes.VALORSELECCIONAR);
				this.ddlbEstadoLineaCredito.Items.Insert(Utilitario.Constantes.ValorConstanteCero, lItem);
				this.ddlbEstadoLineaCredito.Enabled=false;				
				this.ddlbEstadoLineaCredito.DataBind();
			}
		}

		private void ddlbEstadoLineaCredito_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO),Constantes.INDICEPAGINADEFAULT);
		}
	}
}
