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
	/// Summary description for ConsultarCostoEmbarcacion.
	/// </summary>
	public class ConsultarCostoEmbarcacion : System.Web.UI.Page,IPaginaBase
	{
		#region Controles

		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary DomValidationSummary1;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.ImageButton ibtnAgregar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminar;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo1;
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminaFiltro;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;

		#endregion Controles

		#region Constantes
		// PIE DE PAGINA
		const string TEXTOFOOTERTOTAL    = "Total :";
		const int    POSICIONFOOTERTOTAL = 0;

		//Paginas
		const string URLDETALLE   = "DetalleCostoEmbarcacion.aspx?";
		const string URLIMPRESION = "PopupImpresionCostoEmbarcacion.aspx";

		//Key Session y QueryString
		const string KEYQID  = "IdProductoEmbarcacion";
		const string KEYQID1 = "IdCentroOperativo";

		//Otros
		const string GRILLAVACIA        = "No existe ningun Costo de Embarcacion.";
		const string DESCRIPCION        = "Descripcion";
		const string ASTILLERO          = "Astillero Constructor";
		const string MONEDA             = "Moneda";
		const string COSTOXKG           = "Costo x Kg";
		const string COSTOAPROX         = "Costo Aproximado";
		const string FECHAACTUALIZACION = "Fecha de Actualizacion";
		#endregion Constantes

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();

					Helper.ReiniciarSession();

					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial: Inf. Comercial",this.ToString(),"Se consultó los Costos de  Embarcaciones",Enumerados.NivelesErrorLog.I.ToString()));

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
			// TODO:  Add ConsultarCostoEmbarcacion.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarCostoEmbarcacion.LlenarGrillaOrdenamiento implementation
		}

		public DataTable ObtenerDatos()
		{
			CMantenimientos oCMantenimientos =  new CMantenimientos();
			return (oCMantenimientos.ListarTodosGrilla(Enumerados.ClasesNTAD.CostoEmbarcacionNTAD.ToString()));
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
		{
			DataTable dtCostoEmbarcacion = this.ObtenerDatos();

			if(dtCostoEmbarcacion!=null)
			{
				DataView dwCostoEmbarcacion = dtCostoEmbarcacion.DefaultView;
				dwCostoEmbarcacion.Sort = columnaOrdenar ;
				dwCostoEmbarcacion.RowFilter= Utilitario.Helper.ObtenerFiltro(this);

				if(dwCostoEmbarcacion.Count>0)
				{
					grid.DataSource = dwCostoEmbarcacion;
					grid.Columns[POSICIONFOOTERTOTAL].FooterText   = TEXTOFOOTERTOTAL;
					grid.Columns[POSICIONFOOTERTOTAL+1].FooterText = dwCostoEmbarcacion.Count.ToString();
					this.lblResultado.Visible = false;

					CImpresion oCImpresion = new CImpresion();
					oCImpresion.GuardarDataImprimirExportar(dtCostoEmbarcacion,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGOTITULOREPORTECOSTOEMBARCACION),columnaOrdenar,indicePagina);
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
				grid.DataSource = dtCostoEmbarcacion;
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
			// TODO:  Add ConsultarCostoEmbarcacion.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add ConsultarCostoEmbarcacion.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarCostoEmbarcacion.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarCostoEmbarcacion.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			ltlMensaje.Text = Helper.PopupImpresion(URLIMPRESION,650,700,false,false,false,true,true);
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarCostoEmbarcacion.Exportar implementation
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
			return true;
		}

		#endregion

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(e.SortExpression),Helper.ObtenerIndicePagina());
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			grid.CurrentPageIndex=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);
		}

		private void ibtnImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Imprimir();
		}
		
		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				e.Item.Cells[Constantes.POSICIONCONTADOR].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);

				e.Item.Cells[Constantes.POSICIONCONTADOR].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.MostrarVentana(URLDETALLE,
					KEYQID+ Utilitario.Constantes.SIGNOIGUAL + 
					Convert.ToString(dr[Enumerados.ColumnasCostoEmbarcacion.IdProductoEmbarcacion.ToString()]) + 
					Utilitario.Constantes.SIGNOAMPERSON + KEYQID1+ Utilitario.Constantes.SIGNOIGUAL + 
					Convert.ToString(dr[Enumerados.ColumnasCostoEmbarcacion.IdCentroOperativo.ToString()])  +  
					Utilitario.Constantes.SIGNOAMPERSON + Utilitario.Constantes.KEYMODOPAGINA +  Utilitario.Constantes.SIGNOIGUAL + 
					Enumerados.ModoPagina.C.ToString()
					));
	
				e.Item.Cells[Constantes.POSICIONCONTADOR].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				e.Item.Cells[Utilitario.Constantes.POSICIONCONTADOR].ForeColor = System.Drawing.Color.Blue;
				e.Item.Cells[Constantes.POSICIONCONTADOR].Font.Underline=true;

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,
					Utilitario.Helper.MostrarDatosEnCajaTexto("hCodigo",dr[Enumerados.ColumnasCostoEmbarcacion.IdProductoEmbarcacion.ToString()].ToString()),
					Helper.MostrarDatosEnCajaTexto("hCodigo1",dr[Enumerados.ColumnasCostoEmbarcacion.IdCentroOperativo.ToString()].ToString())
					);
				Helper.FiltroporSeleccionConfiguraColumna(e,grid);
			}	
		}

		private void imgImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Imprimir();
		}

		private void ibtnFiltrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			CMantenimientos oCMantenimientos =  new CMantenimientos();
			DataTable dtCostoEmbarcacion = oCMantenimientos.ListarTodosGrilla(Enumerados.ClasesNTAD.CostoEmbarcacionNTAD.ToString());

			ltlMensaje.Text= Utilitario.Helper.ElaborarFiltro(this.ObtenerDatos()
				,Utilitario.Enumerados.ColumnasCostoEmbarcacion.Descripcion.ToString() + Utilitario.Constantes.SIGNOPUNTOYCOMA + DESCRIPCION
				,Utilitario.Constantes.SIGNOASTERISCO + Utilitario.Enumerados.ColumnasCostoEmbarcacion.CO.ToString() + Utilitario.Constantes.SIGNOPUNTOYCOMA + ASTILLERO
				,Utilitario.Constantes.SIGNOASTERISCO + Utilitario.Enumerados.ColumnasCostoEmbarcacion.MONEDA.ToString() + Utilitario.Constantes.SIGNOPUNTOYCOMA + MONEDA
				,Utilitario.Enumerados.ColumnasCostoEmbarcacion.COSTO.ToString() + Utilitario.Constantes.SIGNOPUNTOYCOMA + COSTOXKG
				,Utilitario.Enumerados.ColumnasCostoEmbarcacion.CostoAproximado.ToString() + Utilitario.Constantes.SIGNOPUNTOYCOMA + COSTOAPROX
				,Utilitario.Enumerados.ColumnasCostoEmbarcacion.FechaActualizacion.ToString() + Utilitario.Constantes.SIGNOPUNTOYCOMA + FECHAACTUALIZACION );
		}

		private void ibtnEliminaFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}
	}
}