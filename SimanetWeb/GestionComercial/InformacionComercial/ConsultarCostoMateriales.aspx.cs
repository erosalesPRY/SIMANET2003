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
using SIMA.Controladoras.General;
using SIMA.Controladoras.GestionComercial;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;

namespace SIMA.SimaNetWeb.GestionComercial.InformacionComercial
{
	/// <summary>
	/// Summary description for ConsultarCostoMateriales.
	/// </summary>
	public class ConsultarCostoMateriales : System.Web.UI.Page,IPaginaBase
	{
		#region Controles

		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary DomValidationSummary1;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.ImageButton ibtnAtras;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo2;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminaFiltro;
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
		#endregion Controles

		#region Constantes
		// PIE DE PAGINA
		const string TEXTOFOOTERTOTAL    = "Total :";
		const int    POSICIONFOOTERTOTAL = 0;

		//Paginas
		const string URLDETALLE   = "DetalleCostoMateriales.aspx?";
		const string URLIMPRESION = "PopupImpresionCostoMateriales.aspx";

		//Key Session y QueryString
		const string KEYQID  = "IdMaterial";
		const string KEYQID1 = "IdCentroOperativo";
		const string KEYQID2 = "IdUbigeo";

		//Otros
		const string GRILLAVACIA = "No existe ningun Costo.Material";
		const string DESCRIPCION = "DESCRIPCION";
		const string UNIDAMEDIDA = "UM";
		const string COSTO       = "COSTO";
		const string MONEDA      = "M";
		const string MATERIAL    = "MATERIAL";
		const string CO          = "CO";
		#endregion Constantes

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
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial: Inf. Comercial",this.ToString(),"Se consultó los Costos de Material",Enumerados.NivelesErrorLog.I.ToString()));

					this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(), Utilitario.Constantes.INDICEPAGINADEFAULT);
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
			this.ibtnImprimir.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnImprimir_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add ConsultarCostoMateriales.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarCostoMateriales.LlenarGrillaOrdenamiento implementation
		}

		public DataTable ObtenerDatos()
		{
			CMantenimientos oCMantenimientos =  new CMantenimientos();
			return (oCMantenimientos.ListarTodosGrilla(Enumerados.ClasesNTAD.CostoMaterialesNTAD.ToString()));
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
		{
			DataTable dtCostoMaterial = this.ObtenerDatos();

			if(dtCostoMaterial!=null)
			{
				DataView dwCostoMaterial = dtCostoMaterial.DefaultView;
				dwCostoMaterial.Sort = columnaOrdenar ;
				dwCostoMaterial.RowFilter= Utilitario.Helper.ObtenerFiltro(this);

				if(dwCostoMaterial.Count>0)
				{
					grid.DataSource = dwCostoMaterial;
					grid.Columns[POSICIONFOOTERTOTAL].FooterText = TEXTOFOOTERTOTAL;
					grid.Columns[POSICIONFOOTERTOTAL+1].FooterText = dwCostoMaterial.Count.ToString();
					this.lblResultado.Visible = false;

					CImpresion oCImpresion = new CImpresion();
					oCImpresion.GuardarDataImprimirExportar(dtCostoMaterial,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGOTITULOREPORTECOSTOMATERIAL),columnaOrdenar,indicePagina);
				}
				else
				{
					grid.DataSource = null;
					lblResultado.Visible = true;
					lblResultado.Text = GRILLAVACIA;
				}
			}
			else
			{
				grid.DataSource = dtCostoMaterial;
				lblResultado.Visible = true;
				lblResultado.Text = GRILLAVACIA;
				ibtnImprimir.Visible = false;
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
			// TODO:  Add ConsultarCostoMateriales.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add ConsultarCostoMateriales.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarCostoMateriales.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarCostoMateriales.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			ltlMensaje.Text = Helper.PopupImpresion(URLIMPRESION,650,700,false,false,false,true,true);
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarCostoMateriales.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add ConsultaDeCartasFianzas.ConfigurarAccesoControles implementation

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
			return true;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				e.Item.Cells[Constantes.POSICIONCONTADOR].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);

				e.Item.Cells[Constantes.POSICIONCONTADOR].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.MostrarVentana(URLDETALLE,
					KEYQID + Utilitario.Constantes.SIGNOIGUAL + 
					Convert.ToString(dr[Enumerados.ColumnasCostoMaterial.IdMaterial.ToString()]) + 
					Utilitario.Constantes.SIGNOAMPERSON + KEYQID1+ Utilitario.Constantes.SIGNOIGUAL + 
					Convert.ToString(dr[Enumerados.ColumnasCostoMaterial.IdCentroOperativo.ToString()])  +  
					Utilitario.Constantes.SIGNOAMPERSON + KEYQID2+ Utilitario.Constantes.SIGNOIGUAL + 
					Convert.ToString(dr[Enumerados.ColumnasCostoMaterial.IdUbigeo.ToString()])  +  
					Utilitario.Constantes.SIGNOAMPERSON + Utilitario.Constantes.KEYMODOPAGINA +  Utilitario.Constantes.SIGNOIGUAL + 
					Enumerados.ModoPagina.C.ToString()
					));
	
				e.Item.Cells[Constantes.POSICIONCONTADOR].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				e.Item.Cells[Utilitario.Constantes.POSICIONCONTADOR].ForeColor = System.Drawing.Color.Blue;
				e.Item.Cells[Constantes.POSICIONCONTADOR].Font.Underline=true;

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				Helper.FiltroporSeleccionConfiguraColumna(e,grid);
			}	
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			grid.CurrentPageIndex=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(e.SortExpression),Helper.ObtenerIndicePagina());
		}

		private void ibtnFiltrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			ltlMensaje.Text = Helper.ElaborarFiltro(this.ObtenerDatos()
				, Utilitario.Enumerados.ColumnasCostoMaterial.Descripcion + Utilitario.Constantes.SIGNOPUNTOYCOMA + DESCRIPCION
				, Utilitario.Enumerados.ColumnasCostoMaterial.Costo  + Utilitario.Constantes.SIGNOPUNTOYCOMA + COSTO
				, Utilitario.Constantes.SIGNOASTERISCO + Utilitario.Enumerados.ColumnasCostoMaterial.Moneda + Utilitario.Constantes.SIGNOPUNTOYCOMA + MONEDA
				, Utilitario.Constantes.SIGNOASTERISCO + Utilitario.Enumerados.ColumnasCostoMaterial.TipoMaterial + Utilitario.Constantes.SIGNOPUNTOYCOMA + MATERIAL
				, Utilitario.Enumerados.ColumnasCostoMaterial.CO + Utilitario.Constantes.SIGNOPUNTOYCOMA + CO
				, Utilitario.Constantes.SIGNOASTERISCO + Utilitario.Enumerados.ColumnasCostoMaterial.Descripcion + Utilitario.Constantes.SIGNOPUNTOYCOMA + DESCRIPCION );
		}

		private void ibtnEliminaFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}

		private void ibtnImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Imprimir();
		}
	}
}