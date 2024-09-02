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
	/// Summary description for AdministrarTarifasBuquesEmbarcaciones.
	/// </summary>
	public class AdministrarTarifasBuquesEmbarcaciones : System.Web.UI.Page,IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary DomValidationSummary1;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.WebControls.Label lblClasifEmbarcacion;
		protected System.Web.UI.WebControls.DropDownList ddlbClasificacionEmbarcacion;
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminar;
		protected System.Web.UI.WebControls.ImageButton ibtnAgregar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminaFiltro;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;
		private   ListItem Item =  new ListItem();
		#endregion Controles

		#region Constantes
		// PIE DE PAGINA
		const string TEXTOFOOTERTOTAL    = "Total :";
		const int    POSICIONFOOTERTOTAL = 0;

		//Nombres de Controles
		const string CONTROLINK     = "hlkId";
		const string CONTROCHECKBOX = "cbxEliminar";
 
		//Paginas
		const string URLDETALLE   = "DetalleTarifasBuquesEmbarcaciones.aspx?";
		const string URLIMPRESION = "PopupImpresionTarifaEmbarcacion.aspx";

		//Key Session y QueryString
		const string KEYQID   = "Id";
		const string KEYQFLAG = "Flag";
		//JScript
		string JSVERIFICARELIMINAR = "return verificarEliminarRb('hCodigo','" + Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO)+"','"+Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJEPREGUNTAELIMINACIONREGISTRO)+"');";

		//Otros
		const string GRILLAVACIA = "No existe ninguna Tarifa.";
		const string DESCRIPCION = "DESCRIPCION";
		const string DETALLE     = "DETALLE";
		const string EMBARCACION = "EMBARCACION";
		const string COSTO       = "COSTO";
		const string MONEDA      = "MONEDA";

		#endregion Constantes

		private void llenarClasificacionEmbarcacion()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			this.ddlbClasificacionEmbarcacion.DataSource = oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Utilitario.Enumerados.TablasTabla.ClasificacionEmbarcaciones));
			ddlbClasificacionEmbarcacion.DataValueField  = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbClasificacionEmbarcacion.DataTextField   = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbClasificacionEmbarcacion.DataBind();	
			Item = new ListItem(Utilitario.Constantes.TEXTOTODOS,Utilitario.Constantes.VALORTODOS);
			ddlbClasificacionEmbarcacion.Items.Insert(0,Item);
		}

		private void eliminar()
		{
			RowSelectorColumn rSel = RowSelectorColumn.FindColumn(grid);

			if (hCodigo.Value.Length==0)
				ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO));
			else
			{
				CMantenimientos oCMantenimientos = new CMantenimientos();
				if (oCMantenimientos.Eliminar(Convert.ToInt32(hCodigo.Value.ToString()),CNetAccessControl.GetIdUser(), Enumerados.ClasesTAD.TarifaEmbarcacionTAD.ToString())>0)
				{
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(), "Gestión Comercial:Inf. Comercial", this.ToString(), "Se eliminó la Tarifa Embarcacion Nro. " + hCodigo.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString())); 

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
					Helper.ReiniciarSession();
					this.LlenarJScript();
					this.LlenarCombos();

					if (Session[KEYQFLAG]==null)
					{
						Session[KEYQFLAG] = Utilitario.Constantes.LISTARTARIFAEMBARCACIONTODAS.ToString();
						Session[KEYQID]   = Utilitario.Constantes.LISTARTARIFAEMBARCACIONTODAS.ToString();
					}
					else
					{
						ddlbClasificacionEmbarcacion.Items.FindByValue(Session[KEYQID].ToString()).Selected = true;
					}

					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial: Inf. Comercial",this.ToString(),"Se consultó las Tarifas Embarcaciones",Enumerados.NivelesErrorLog.I.ToString()));
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
			this.ddlbClasificacionEmbarcacion.SelectedIndexChanged += new System.EventHandler(this.ddlbClasificacionEmbarcacion_SelectedIndexChanged);
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
			// TODO:  Add AdministrarTarifasBuquesEmbarcaciones.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarTarifasBuquesEmbarcaciones.LlenarGrillaOrdenamiento implementation
		}

		public DataTable ObtenerDatos()
		{
			CTarifaEmbarcacion oCTarifaEmbarcacion = new CTarifaEmbarcacion();
			return (oCTarifaEmbarcacion.ConsultarTarifaEmbarcacion(Convert.ToInt32(Session[KEYQFLAG]), Convert.ToInt32(Session[KEYQID])));
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
		{
			DataTable dtTarifaEmbarcacion = this.ObtenerDatos();

			if(dtTarifaEmbarcacion!=null)
			{
				DataView dwTarifaEmbarcacion = dtTarifaEmbarcacion.DefaultView;
				dwTarifaEmbarcacion.Sort = columnaOrdenar ;
				dwTarifaEmbarcacion.RowFilter= Utilitario.Helper.ObtenerFiltro(this);
				grid.DataSource = dwTarifaEmbarcacion;
				CImpresion oCImpresion = new CImpresion();
				oCImpresion.GuardarDataImprimirExportar(dtTarifaEmbarcacion,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGOTITULOREPORTETARIFAEMBARCACION),columnaOrdenar,indicePagina);
				ibtnImprimir.Visible = true;
				lblResultado.Visible = false;
				grid.Columns[POSICIONFOOTERTOTAL].FooterText = TEXTOFOOTERTOTAL;
				grid.Columns[POSICIONFOOTERTOTAL+1].FooterText = dwTarifaEmbarcacion.Count.ToString();

			}
			else
			{
				grid.DataSource = dtTarifaEmbarcacion;
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
			this.llenarClasificacionEmbarcacion();
		}

		public void LlenarDatos()
		{
			// TODO:  Add AdministrarTarifasBuquesEmbarcaciones.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			ibtnEliminar.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, JSVERIFICARELIMINAR);
			ibtnAgregar.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN, Utilitario.Constantes.HISTORIALADELANTE);
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarTarifasBuquesEmbarcaciones.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			ltlMensaje.Text = Helper.PopupImpresion(URLIMPRESION,650,700,false,false,false,true,true);
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarTarifasBuquesEmbarcaciones.Exportar implementation
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
					Helper.MostrarVentana(URLDETALLE, 
					KEYQID + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr[Enumerados.ColumnasTarifaEmbarcacion.IdTarifaEmbarcacion.ToString()]) +  Utilitario.Constantes.SIGNOAMPERSON + 
					Utilitario.Constantes.KEYMODOPAGINA +  Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.M.ToString()));

				e.Item.Cells[Utilitario.Constantes.POSICIONCONTADOR].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				e.Item.Cells[Utilitario.Constantes.POSICIONCONTADOR].ForeColor = System.Drawing.Color.Blue;
				e.Item.Cells[Utilitario.Constantes.POSICIONCONTADOR].Font.Underline = true;

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e, Utilitario.Helper.MostrarDatosEnCajaTexto("hCodigo",dr[Enumerados.ColumnasTarifaEmbarcacion.IdTarifaEmbarcacion.ToString()].ToString()));
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
				, Utilitario.Enumerados.ColumnasTarifaEmbarcacion.DescripcionTrabajo + Utilitario.Constantes.SIGNOPUNTOYCOMA + DESCRIPCION 
				, Utilitario.Enumerados.ColumnasTarifaEmbarcacion.Descripcion + Utilitario.Constantes.SIGNOPUNTOYCOMA + DETALLE
				, Utilitario.Constantes.SIGNOASTERISCO + EMBARCACION + Utilitario.Constantes.SIGNOPUNTOYCOMA + EMBARCACION
				, COSTO + Utilitario.Constantes.SIGNOPUNTOYCOMA + COSTO
				, Utilitario.Constantes.SIGNOASTERISCO + MONEDA + Utilitario.Constantes.SIGNOPUNTOYCOMA + MONEDA );
		}

		private void ddlbClasificacionEmbarcacion_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(ddlbClasificacionEmbarcacion.SelectedItem.Text == Utilitario.Constantes.TEXTOTODOS)
			{
				Session[KEYQFLAG] = Utilitario.Constantes.LISTARTARIFAEMBARCACIONTODAS.ToString();
				Session[KEYQID]   = Utilitario.Constantes.LISTARTARIFAEMBARCACIONTODAS.ToString();
			}
			else
			{
				Session[KEYQFLAG] = Utilitario.Constantes.LISTARTARIFAEMBARCACIONFILTRADO.ToString();
				Session[KEYQID]   = ddlbClasificacionEmbarcacion.SelectedValue.ToString();
			}

			try
			{
				Helper.ReiniciarSession();

				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(), "Gestión Comercial:Inf. Comercial", this.ToString(),"Se consultó las Tarifas Embarcaciones",Enumerados.NivelesErrorLog.I.ToString()));
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

		private void ibtnEliminaFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}

		private void ibtnAgregar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Page.Response.Redirect(URLDETALLE + Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.N.ToString());
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