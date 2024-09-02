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

namespace SIMA.SimaNetWeb.GestionComercial.Ventas
{
	/// <summary>
	/// Summary description for AdministrarVentasPresupuestadas.
	/// </summary>
	public class AdministrarVentasPresupuestadas: System.Web.UI.Page, IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblCentroOperativo;
		protected System.Web.UI.WebControls.ImageButton ibtnAgregar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminar;
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.DropDownList ddlbCentroOperativo;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltro;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminarFiltro;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblVersion;
		protected System.Web.UI.WebControls.DropDownList ddlbVersion;
		#endregion Controles

		#region Constantes
		
		//Ordenamiento
		const string COLORDENAMIENTO = "IDVENTAPRESUPUESTADA";
		const int POSICIONINICIALCOMBO = 0;
		const string CONTROLINK = "hlkId";

		//JScript
		string JSVERIFICARELIMINAR = "return verificarEliminarRb('hCodigo','" + Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO)+"','"+Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJEPREGUNTAELIMINACIONREGISTRO)+"');";

		//Columnas DataTable

		//Nombres de Controles
		
		//Paginas
		const string URLDETALLE = "DetalleVentasPresupuestadas.aspx?";
		const string URLIMPRESION = "PopupImpresionAdministrarVentasPresupuestadas.aspx";
	
		//Key Session y QueryString
		const string KEYQID = "Id";
		const string KEYQPOSICIONCOMBO = "PosicionComboCentroOperativo";
		const string KEYQPOSICIONCOMBOVERSION = "PosicionComboVersion";
		
		//Otros
		const string GRILLAVACIA ="No existe ninguna Venta Presupuestada con los filtros seleccionados.";
		const int PosicionFooterTotal = 2;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DropDownList ddblAño;
		const int PosicionFooterMontoTotal = 7;

		#endregion Constantes
		ListItem item;
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
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se consultaron las Ventas Presupuestadas del Centro Operativo",Enumerados.NivelesErrorLog.I.ToString()));

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
			this.ddlbCentroOperativo.SelectedIndexChanged += new System.EventHandler(this.ddlbCentroOperativo_SelectedIndexChanged);
			this.ddblAño.SelectedIndexChanged += new System.EventHandler(this.ddblAño_SelectedIndexChanged);
			this.ddlbVersion.SelectedIndexChanged += new System.EventHandler(this.ddlbVersion_SelectedIndexChanged);
			this.ibtnFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnFiltro_Click);
			this.ibtnEliminarFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminarFiltro_Click);
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
			// TODO:  Add AdministrarVentasPresupuestadas.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarVentasPresupuestadas.LlenarGrillaOrdenamiento implementation
		}

		public DataTable ObtenerDatos()
		{
			CVentasPresupuestadas oCVentasPresupuestadas = new CVentasPresupuestadas();
			
			if(CNetAccessControl.GetIdUser() == Utilitario.Constantes.USUARIOCOMERCIAL)
			{
				if(ddlbCentroOperativo.SelectedValue == Utilitario.Constantes.TEXTOTODOS)
					return oCVentasPresupuestadas.ConsultarVentasPresupuestadasTodosCentroOperativo(Convert.ToInt32(this.ddlbVersion.SelectedValue),Convert.ToInt32(this.ddblAño.SelectedValue));
				else
					return oCVentasPresupuestadas.ConsultarVentasPresupuestadasPorCentroOperativo(Convert.ToInt32(this.ddlbCentroOperativo.SelectedValue),Convert.ToInt32(this.ddlbVersion.SelectedValue),Convert.ToInt32(this.ddblAño.SelectedValue));
			}
			else
					return oCVentasPresupuestadas.ConsultarVentasPresupuestadasPorCentroOperativo(Convert.ToInt32(this.ddlbCentroOperativo.SelectedValue),Convert.ToInt32(this.ddlbVersion.SelectedValue),Convert.ToInt32(this.ddblAño.SelectedValue));
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dtVentas =  this.ObtenerDatos();
			
			if(dtVentas!=null)
			{
				DataView dwVentas = dtVentas.DefaultView;
				dwVentas.Sort = columnaOrdenar ;
				dwVentas.RowFilter = Utilitario.Helper.ObtenerFiltro(this);

				if(dwVentas.Count > POSICIONINICIALCOMBO)
				{
					grid.DataSource = dwVentas;
					lblResultado.Visible = false;
					grid.Columns[PosicionFooterTotal].FooterText = dwVentas.Count.ToString();
					DataTable Suma = Helper.DataViewTODataTable(dwVentas);
					grid.Columns[PosicionFooterMontoTotal].FooterText = Helper.TotalizarDataView(Suma.DefaultView,Enumerados.ColumnasVentasPresupuestadas.MONTO.ToString())[Constantes.POSICIONCONTADOR].ToString(Constantes.FORMATODECIMAL4);
				}
				else
				{
					grid.DataSource = null;
					lblResultado.Visible = true;
					lblResultado.Text = GRILLAVACIA;
				}
				CImpresion oCImpresion = new CImpresion();
				oCImpresion.GuardarDataImprimirExportar(dwVentas.Table,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGOTITULOREPORTEVENTASPRESUPUESTADAS),columnaOrdenar,indicePagina);
			}
			else
			{
				grid.DataSource = dtVentas;
				lblResultado.Visible = true;
				lblResultado.Text = GRILLAVACIA;
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

		public void LlenarCombos()
		{
			this.llenarCentrosOperativos();
			this.llenarVersiones();
			llenarAnos();
		
		}

		private void llenarAnos()
		{
			/*ddblAño.DataSource= ObtenerPeriodo();
			ddblAño.DataBind();
			//Helper.ObtenerPeriodos(2005,Helper.FechaSimanet.ObtenerFechaSesion().Year);

			if(HttpContext.Current.Session["PosicionComboAno"] != null)
			{
				this.ddblAño.Items.FindByValue(HttpContext.Current.Session["PosicionComboAno"].ToString()).Selected = true;
			}
			else
			{
				this.ddblAño.Items.FindByValue(DateTime.Now.Year.ToString()).Selected = true;
			}
			*/
				int indice = 0;
				for(int i = Utilitario.Constantes.ANOMINIMA; i <= DateTime.Today.Year + 5; i++)
				{
					ddblAño.Items.Insert(indice,i.ToString());
					indice++;
				}
				string ItemBuscar = ((HttpContext.Current.Session["PosicionComboAno"] != null)?HttpContext.Current.Session["PosicionComboAno"].ToString():Helper.FechaSimanet.ObtenerFechaSesion().Year.ToString());

				item = ddblAño.Items.FindByText(ItemBuscar);
				if (item !=null){item.Selected = true;}
		}
		private ArrayList ObtenerPeriodo()
		{
			ArrayList arr = new ArrayList();
			for(int i=DateTime.Now.Year+1;i>=DateTime.Now.Year-2;i--)
			{
				arr.Add(i);
			}
			return arr;
			
		}
		public void LlenarDatos()
		{
			// TODO:  Add AdministrarVentasPresupuestadas.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			ibtnEliminar.Attributes.Add(Constantes.EVENTOCLICK,JSVERIFICARELIMINAR);
			this.ibtnAgregar.Attributes.Add(Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarVentasPresupuestadas.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			ltlMensaje.Text = Helper.PopupImpresion(URLIMPRESION,750,500,false,false,false,true,true);
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarVentasPresupuestadas.Exportar implementation
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

		/// <summary>
		/// Llena el combo de Centros Operativos
		/// </summary>
		private void llenarCentrosOperativos()
		{
			CCentroOperativo oCCentroOperativo =  new CCentroOperativo();
			ddlbCentroOperativo.DataSource = oCCentroOperativo.ListarCentroOperativoAccesoSegunPrivilegioUsuario(CNetAccessControl.GetIdUser(), Convert.ToInt32(Enumerados.TablasTabla.EstadosVentasPresupuestadas));
			ddlbCentroOperativo.DataValueField=Enumerados.ColumnasCentroOperativo.IdCentroOperativo.ToString();
			ddlbCentroOperativo.DataTextField=Enumerados.ColumnasCentroOperativo.Sigla1.ToString();
			ddlbCentroOperativo.DataBind();
			//ddlbCentroOperativo.Items.RemoveAt(POSICIONINICIALCOMBO);
		

			if(CNetAccessControl.GetIdUser() == Utilitario.Constantes.USUARIOCOMERCIAL)
			{
				ListItem oListItem=new ListItem(Utilitario.Constantes.TEXTOTODOS,Utilitario.Constantes.TEXTOTODOS);
				ddlbCentroOperativo.Items.Insert(0,oListItem);
			}

			if(HttpContext.Current.Session[KEYQPOSICIONCOMBO] != null)
			{
				this.ddlbCentroOperativo.Items.FindByValue(HttpContext.Current.Session[KEYQPOSICIONCOMBO].ToString()).Selected = true;
			}
		}

		/// <summary>
		/// Llena el combo de Versiones
		/// </summary>
		private void llenarVersiones()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			ddlbVersion.DataSource = oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Enumerados.TablasTabla.VersionesVentasPresupuestadas));
			ddlbVersion.DataValueField =Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbVersion.DataTextField =Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbVersion.DataBind();
			if(HttpContext.Current.Session[KEYQPOSICIONCOMBO] != null)
			{
				this.ddlbVersion.Items.FindByValue(HttpContext.Current.Session[KEYQPOSICIONCOMBOVERSION].ToString()).Selected = true;
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

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				e.Item.Cells[Constantes.POSICIONCONTADOR].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
				e.Item.Cells[Constantes.POSICIONCONTADOR].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.MostrarVentana(URLDETALLE,KEYQID + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr[Enumerados.ColumnasVentasPresupuestadas.IDVENTAPRESUPUESTADA.ToString()]) +  Utilitario.Constantes.SIGNOAMPERSON + 
					Utilitario.Constantes.KEYMODOPAGINA +  Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.M.ToString()));
				
				e.Item.Cells[Constantes.POSICIONCONTADOR].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				e.Item.Cells[Constantes.POSICIONCONTADOR].Font.Underline=true;
				e.Item.Cells[Constantes.POSICIONCONTADOR].ForeColor = System.Drawing.Color.Blue;

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,Utilitario.Helper.MostrarDatosEnCajaTexto("hCodigo",dr[Enumerados.ColumnasVentasPresupuestadas.IDVENTAPRESUPUESTADA.ToString()].ToString()));
				Helper.FiltroporSeleccionConfiguraColumna(e,grid);
			}
		}

		private void ibtnAgregar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Page.Response.Redirect(URLDETALLE + 
				Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.N.ToString());
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

		private void eliminar()
		{
			if(hCodigo.Value.Length==0)
			{
				ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO));
			}
			else
			{
				CMantenimientos oCMantenimientos = new CMantenimientos();

				if(oCMantenimientos.Eliminar(Convert.ToInt32(hCodigo.Value),CNetAccessControl.GetIdUser(),Enumerados.ClasesTAD.VentaPresupuestadaTAD.ToString())>0)
				{
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se eliminó la Venta Presupuestada Nro. " + hCodigo.Value +"." ,Enumerados.NivelesErrorLog.I.ToString()));
					this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),Helper.ObtenerIndicePagina());
					ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONELIMINACIONREGISTRO));
				}
			}
		}

		private void ddlbCentroOperativo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Session[KEYQPOSICIONCOMBO] = this.ddlbCentroOperativo.SelectedValue;
			Session[KEYQPOSICIONCOMBOVERSION] = this.ddlbVersion.SelectedValue;
			Session["PosicionComboAno"] = this.ddblAño.SelectedValue;

			Helper.EliminarFiltro();

			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se consultaron las Ventas Presupuestadas del Centro Operativo" + this.ddlbCentroOperativo.SelectedItem.Text+ ".",Enumerados.NivelesErrorLog.I.ToString()));

			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO),Utilitario.Constantes.INDICEPAGINADEFAULT);
		}

		private void ibtnFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			ltlMensaje.Text= Utilitario.Helper.ElaborarFiltro(this.ObtenerDatos()
				,Constantes.SIGNOASTERISCO + Utilitario.Enumerados.ColumnasVentasPresupuestadas.centrooperativo.ToString()+";Centro Operativo"
				,Constantes.SIGNOASTERISCO + Utilitario.Enumerados.ColumnasVentasPresupuestadas.sector.ToString()+ ";Sector"
				,Utilitario.Enumerados.ColumnasVentasPresupuestadas.RAZONSOCIAL.ToString()+ ";Cliente"
				,Utilitario.Enumerados.ColumnasVentasPresupuestadas.DESCRIPCIONPROYECTO.ToString()+ ";Descripcion del Proyecto"
				,Utilitario.Enumerados.ColumnasVentasPresupuestadas.MONTO.ToString()+ ";Monto"
				,Constantes.SIGNOASTERISCO + Utilitario.Enumerados.ColumnasVentasPresupuestadas.Moneda.ToString()+ ";Moneda"
				,Utilitario.Enumerados.ColumnasVentasPresupuestadas.FECHAPRESUPUESTO.ToString()+ ";Fecha del Presupuesto"
				,Constantes.SIGNOASTERISCO + Utilitario.Enumerados.ColumnasVentasPresupuestadas.VERSION.ToString()+ ";Version del Presupuesto");
		}

		private void ibtnEliminarFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}

		private void ibtnImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Imprimir();
		}

		private void ddlbVersion_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Session[KEYQPOSICIONCOMBO] = this.ddlbCentroOperativo.SelectedValue;
			Session[KEYQPOSICIONCOMBOVERSION] = this.ddlbVersion.SelectedValue;
			Session["PosicionComboAno"] = this.ddblAño.SelectedValue;
			Helper.EliminarFiltro();

			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se consultaron las Ventas Presupuestadas del Centro Operativo" + this.ddlbCentroOperativo.SelectedItem.Text+ ".",Enumerados.NivelesErrorLog.I.ToString()));

			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO),Utilitario.Constantes.INDICEPAGINADEFAULT);
		}

		private void ddblAño_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Session[KEYQPOSICIONCOMBO] = this.ddlbCentroOperativo.SelectedValue;
			Session[KEYQPOSICIONCOMBOVERSION] = this.ddlbVersion.SelectedValue;
			Session["PosicionComboAno"] = this.ddblAño.SelectedValue;

			Helper.EliminarFiltro();
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO),Utilitario.Constantes.INDICEPAGINADEFAULT);
		}
	}
}