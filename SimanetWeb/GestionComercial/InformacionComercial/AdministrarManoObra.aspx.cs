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
	/// Summary description for AdministrarManoObra.
	/// </summary>
	public class AdministrarManoObra : System.Web.UI.Page, IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;
		protected System.Web.UI.WebControls.ImageButton ibtnAgregar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminar;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminaFiltro;
		#endregion Controles

		#region Constantes

		// PIE DE PAGINA
		const string TEXTOFOOTERTOTAL    = "Total :";
		const int    POSICIONFOOTERTOTAL = 1;
		const int    POSICIONIDENTIFICADOR = 2;

		//Nombres de Controles
		const string CONTROLINK     = "hlkId";
		const string CONTROCHECKBOX = "cbxEliminar";
 
		//Paginas
		const string URLDETALLE   = "DetalleManoObra.aspx?";
		const string URLIMPRESION = "PopupImpresionAdministracionManoObra.aspx";

		//Key Session y QueryString
		const string KEYQID = "Id";

		//JScript
		string JSVERIFICARELIMINAR = "return verificarEliminarRb('hCodigo','" + Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO)+"','"+Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJEPREGUNTAELIMINACIONREGISTRO)+"');";

		//Otros
		const string GRILLAVACIA = "No existe ningun ManoObra.";
		const string DESCRIPCION = "DESCRIPCION";
		const string TIPO        = "TIPO";
		#endregion

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
			this.ibtnAgregar.Click += new System.Web.UI.ImageClickEventHandler(this.imgAgregar_Click);
			this.ibtnEliminar.Click += new System.Web.UI.ImageClickEventHandler(this.imgEliminar_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void eliminar()
		{
			if(hCodigo.Value.Length==0)
				ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO));
			else
			{
				CMantenimientos oCMantenimientos = new CMantenimientos();
				if (oCMantenimientos.Eliminar(Convert.ToInt32(this.hCodigo.Value.ToString()),CNetAccessControl.GetIdUser(), Enumerados.ClasesTAD.ManoObraTAD.ToString())>0)
				{
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(), "Gestión Comercial:Inf. Comercial", this.ToString(), "Se eliminó el ManoObra Nro. " + this.hCodigo.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString())); 

					this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),Helper.ObtenerIndicePagina());
					ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONELIMINACIONREGISTRO));
				}
			}
		}

		private void reiniciarCampos()
		{
			this.hCodigo.Value = "";
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					
					this.LlenarJScript();

					Helper.ReiniciarSession();

					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestión Comercial:Inf. Comercial",this.ToString(),"Se consultó los ManoObraes.",Enumerados.NivelesErrorLog.I.ToString()));
					
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

			this.reiniciarCampos();
		}

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add AdministrarManoObra.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarManoObra.LlenarGrillaOrdenamiento implementation
		}

		public DataTable ObtenerDatos()
		{
			CMantenimientos oCMantenimientos =  new CMantenimientos();
			return (oCMantenimientos.ListarTodosGrilla(Enumerados.ClasesNTAD.ManoObraNTAD.ToString()));

		}
		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
		{

			DataTable dtManoObra = this.ObtenerDatos();

			if(dtManoObra!=null)
			{
				DataView dwManoObra = dtManoObra.DefaultView;
				dwManoObra.Sort = columnaOrdenar ;
				dwManoObra.RowFilter= Utilitario.Helper.ObtenerFiltro(this);
				grid.DataSource = dwManoObra;
				CImpresion oCImpresion = new CImpresion();
				oCImpresion.GuardarDataImprimirExportar(dtManoObra,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGOTITULOREPORTEACCIONCORRECTIVA),columnaOrdenar,indicePagina);
				lblResultado.Visible = false;
				grid.Columns[POSICIONFOOTERTOTAL-1].FooterText = TEXTOFOOTERTOTAL;
				grid.Columns[POSICIONFOOTERTOTAL].FooterText = dwManoObra.Count.ToString();

			}
			else
			{
				grid.DataSource = dtManoObra;
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
			// TODO:  Add AdministrarManoObra.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add AdministrarManoObra.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			ibtnEliminar.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, JSVERIFICARELIMINAR);
			ibtnAgregar.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN, Utilitario.Constantes.HISTORIALADELANTE);
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarManoObra.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			ltlMensaje.Text = Helper.PopupImpresion(URLIMPRESION,650,700,false,false,false,true,true);
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarManoObra.Exportar implementation
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

				e.Item.Cells[Utilitario.Constantes.POSICIONCONTADOR].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
				e.Item.Cells[Utilitario.Constantes.POSICIONCONTADOR].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.MostrarVentana(URLDETALLE, KEYQID + 
						Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr[Enumerados.ColumnasManoObra.IdManoObra.ToString()]) +  
						Utilitario.Constantes.SIGNOAMPERSON + Utilitario.Constantes.KEYMODOPAGINA +  Utilitario.Constantes.SIGNOIGUAL + 
						Enumerados.ModoPagina.M.ToString()));

				e.Item.Cells[Utilitario.Constantes.POSICIONCONTADOR].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				e.Item.Cells[Utilitario.Constantes.POSICIONCONTADOR].ForeColor = System.Drawing.Color.Blue;
				e.Item.Cells[Utilitario.Constantes.POSICIONCONTADOR].Font.Underline=true;

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,
					Utilitario.Helper.MostrarDatosEnCajaTexto("hCodigo",dr[Enumerados.ColumnasManoObra.IdManoObra.ToString()].ToString()));
			}	
			
		}

		private void redireccionaPaginaAgregar()
		{
			Page.Response.Redirect(URLDETALLE + Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.N.ToString());
		}

		private void imgAgregar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.redireccionaPaginaAgregar();
		}

		private void imgImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Imprimir();
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

		private void imgEliminar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
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

		
		private void ibtnFiltrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			ltlMensaje.Text = Helper.ElaborarFiltro( this.ObtenerDatos()
				,Utilitario.Enumerados.ColumnasManoObra.Descripcion + Utilitario.Constantes.SIGNOPUNTOYCOMA + DESCRIPCION
				,Utilitario.Constantes.SIGNOASTERISCO + TIPO + Utilitario.Constantes.SIGNOPUNTOYCOMA + TIPO );
		}

		private void ibtnEliminaFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}
	}
}