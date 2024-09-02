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
	/// Summary description for AdministrarCostoManoObra.
	/// </summary>
	public class AdministrarCostoManoObra : System.Web.UI.Page,IPaginaBase
	{
		#region Controles

		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary DomValidationSummary1;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo1;
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminar;
		protected System.Web.UI.WebControls.ImageButton ibtnAgregar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminaFiltro;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;
		#endregion Controles

		#region Constantes
		// PIE DE PAGINA
		const int PosicionFooterTotal = 3;


		//Paginas
		const string URLDETALLE   = "DetalleCostoManoObra.aspx?";
		const string URLIMPRESION = "PopupImpresionCostoManoObra.aspx";

		//Key Session y QueryString
		const string KEYQID  = "IdManoObra";
		const string KEYQID1 = "IdCentroOperativo";

		//JScript
		string JSVERIFICARELIMINAR = "return verificarEliminarRb('hCodigo','" + Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO)+"','"+Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJEPREGUNTAELIMINACIONREGISTRO)+"');";

		//Otros
		const string GRILLAVACIA       = "No existe ningún Costo de Mano Obra";
		const string DESCRIPCION       = "Descripción";
		const string TIPO              = "Tipo";
		const string COSTO             = "Costo";
		const string CENTROOPERACIONES = "Centro de Operaciones";
		const string MONEDA            = "Moneda";
		#endregion Constantes

		private void eliminar()
		{
			if(hCodigo.Value.Length==0 || hCodigo1.Value.Length==0)
			{
				ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO));
			}
			else
			{
				CCostoManoObra oCCostoManoObra = new CCostoManoObra();
				if (oCCostoManoObra.EliminarCostManoObra(Convert.ToInt32(this.hCodigo.Value.ToString()),Convert.ToInt32(this.hCodigo1.Value.ToString()))>0)
				{
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(), "Gestión Comercial:Inf. Comercial", this.ToString(), "Se eliminó el Costo Mano de Obra " + this.hCodigo.ToString() + Utilitario.Constantes.SEPARADOR + this.hCodigo1.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString())); 
					this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),Helper.ObtenerIndicePagina());
					ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONELIMINACIONREGISTRO));
				}
			}
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

					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial: Inf. Comercial",this.ToString(),"Se consultó los Costos de Mano de Obra",Enumerados.NivelesErrorLog.I.ToString()));

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
			this.ibtnAgregar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAgregar_Click);
			this.ibtnEliminar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminar_Click);
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
			// TODO:  Add AdministrarCostoManoObra.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarCostoManoObra.LlenarGrillaOrdenamiento implementation
		}

		public DataTable ObtenerDatos()
		{
			CMantenimientos oCMantenimientos =  new CMantenimientos();
			return (oCMantenimientos.ListarTodosGrilla(Enumerados.ClasesNTAD.CostoManoObraNTAD.ToString()));
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
		{
			DataTable dtCostoManoObra = this.ObtenerDatos();

			if(dtCostoManoObra!=null)
			{
				DataView dwCostoManoObra = dtCostoManoObra.DefaultView;
				dwCostoManoObra.Sort = columnaOrdenar ;
				dwCostoManoObra.RowFilter= Utilitario.Helper.ObtenerFiltro(this);

				if(dwCostoManoObra.Count>0)
				{
					grid.DataSource = dwCostoManoObra;
					grid.Columns[PosicionFooterTotal].FooterText = dwCostoManoObra.Count.ToString();
					this.lblResultado.Visible = false;

					CImpresion oCImpresion = new CImpresion();
					oCImpresion.GuardarDataImprimirExportar(dtCostoManoObra,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGOTITULOREPORTECOSTOMANOOBRA),columnaOrdenar,indicePagina);
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
				grid.DataSource = dtCostoManoObra;
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
			// TODO:  Add AdministrarCostoManoObra.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add AdministrarCostoManoObra.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			ibtnEliminar.Attributes.Add(Constantes.EVENTOCLICK,JSVERIFICARELIMINAR);
			ibtnAgregar.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN, Utilitario.Constantes.HISTORIALADELANTE);
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarCostoManoObra.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			ltlMensaje.Text = Helper.PopupImpresion(URLIMPRESION,650,700,false,false,false,true,true);
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarCostoManoObra.Exportar implementation
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

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				e.Item.Cells[Constantes.POSICIONCONTADOR].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
				e.Item.Cells[Constantes.POSICIONCONTADOR].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.MostrarVentana(URLDETALLE,KEYQID+ Utilitario.Constantes.SIGNOIGUAL + 
					Convert.ToString(dr[Enumerados.ColumnasCostoManoObra.IdManoObra.ToString()]) + 
					Utilitario.Constantes.SIGNOAMPERSON + KEYQID1+ Utilitario.Constantes.SIGNOIGUAL + 
					Convert.ToString(dr[Enumerados.ColumnasCostoManoObra.IdCentroOperativo.ToString()])  +  
					Utilitario.Constantes.SIGNOAMPERSON + Utilitario.Constantes.KEYMODOPAGINA +  Utilitario.Constantes.SIGNOIGUAL + 
					Enumerados.ModoPagina.M.ToString()));

				e.Item.Cells[Constantes.POSICIONCONTADOR].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				e.Item.Cells[Utilitario.Constantes.POSICIONCONTADOR].ForeColor = System.Drawing.Color.Blue;
				e.Item.Cells[Constantes.POSICIONCONTADOR].Font.Underline=true;

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,
					Helper.MostrarDatosEnCajaTexto("hCodigo",dr[Enumerados.ColumnasCostoManoObra.IdManoObra.ToString()].ToString()),
					Helper.MostrarDatosEnCajaTexto("hCodigo1",dr[Enumerados.ColumnasCostoManoObra.IdCentroOperativo.ToString()].ToString())
					);
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
			ltlMensaje.Text= Utilitario.Helper.ElaborarFiltro(this.ObtenerDatos()
				,Utilitario.Enumerados.ColumnasCostoManoObra.Descripcion.ToString()+ Utilitario.Constantes.SIGNOPUNTOYCOMA + DESCRIPCION 
				,Utilitario.Constantes.SIGNOASTERISCO  + Utilitario.Enumerados.ColumnasCostoManoObra.Tipo.ToString()+ Utilitario.Constantes.SIGNOPUNTOYCOMA + TIPO
				,Utilitario.Enumerados.ColumnasCostoManoObra.Costo.ToString()+ Utilitario.Constantes.SIGNOPUNTOYCOMA + COSTO
				,Utilitario.Constantes.SIGNOASTERISCO + Utilitario.Enumerados.ColumnasCostoManoObra.CO.ToString()+ Utilitario.Constantes.SIGNOPUNTOYCOMA + CENTROOPERACIONES
				,Utilitario.Constantes.SIGNOASTERISCO + Utilitario.Enumerados.ColumnasCostoManoObra.MONEDA.ToString()+ Utilitario.Constantes.SIGNOPUNTOYCOMA + MONEDA);
		}

		private void ibtnAgregar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Page.Response.Redirect(URLDETALLE + Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.N.ToString());
		}

		private void ibtnEliminaFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}

		private void ibtnEliminar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				if(Page.IsValid)
				{
					this.eliminar();
				}
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

		private void ibtnImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Imprimir();
		}
	}
}