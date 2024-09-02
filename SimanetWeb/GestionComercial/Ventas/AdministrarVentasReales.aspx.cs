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
using SIMA.Controladoras.GestionFinanciera;
using SIMA.EntidadesNegocio.Proyectos;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;

namespace SIMA.SimaNetWeb.GestionComercial.Ventas
{
	/// <summary>
	/// Summary description for AdministrarVentasReales.
	/// </summary>
	public class AdministrarVentasReales: System.Web.UI.Page,IPaginaBase
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
		protected System.Web.UI.WebControls.ImageButton ibtnObservaciones;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltro;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminarFiltro;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.WebControls.ImageButton ibtnProyectosEnCartera;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblAño;
		protected System.Web.UI.WebControls.DropDownList ddlbAño;
		protected System.Web.UI.WebControls.ImageButton ibtnExportar;
		protected System.Web.UI.WebControls.DataGrid gridReporte;

		#endregion

		#region Constantes
		
		//Ordenamiento
		const string COLORDENAMIENTO = "IDVENTAREAL";
		const int POSICIONINICIALCOMBO = 0;
		const string CONTROLINK = "hlkId";

		//JScript
		string JSVERIFICARELIMINAR = "return verificarEliminarRb('hCodigo','" + Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO)+"','"+Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJEPREGUNTAELIMINACIONREGISTRO)+"');";

		//Columnas DataTable

		//Nombres de Controles
		
		//Paginas
		const string URLDETALLE = "DetalleVentasReales.aspx?";
		const string URLIMPRESION = "PopupImpresionAdministrarVentasReales.aspx";
		const string URLOBSERVACIONESVENTAS = "AdministrarObservacionesVentas.aspx?";
		const string URLPROYECTOSENCARTERA = "../../Proyectos/AdministrarProyectoCarteraPorSectorPorCentroOperativo.aspx";
	
		//Key Session y QueryString
		const string KEYQID = "Id";
		const string KEYTIPOOBSERVACION="TipoObervacion";
		const string KEYQPOSICIONCOMBO = "KEYPOSICIONCOMBO";
		const string KEYQPOSICIONCOMBOANO = "KEYPOSICIONCOMBOANO";
	
		//Otros
		const string GRILLAVACIA ="No existe ninguna Venta Ejecutada con los filtros seleccionados.";
		
		const int PosicionFooterTotal = 2;
		const int PosicionFooterCantidadTotal = 3;
		const int PosicionFooterMontoTotal = 7;
		const string COMBOANO = "ddlbAño";
		const string CO = "ddlbCentroOperativo";
		

		#endregion Constantes
		
		#region Variables

	    private ListItem item;
		private ListItem  lItem ;
		private ListItem  lItem1 ;
		protected System.Web.UI.WebControls.ImageButton Imagebutton1;
		protected System.Web.UI.WebControls.ImageButton IbtnCierre;
		protected System.Web.UI.WebControls.Image BtnActivado;		
		const int FlagSeleccionCO = 0;

		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try

				{ 
					this.validacierreventas();
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarJScript();
					this.LlenarCombos();
					this.RestablecerPagina();
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se consultaron las Ventas Presupuestadas del Centro Operativo" + this.ddlbCentroOperativo.SelectedItem.Text+ ".",Enumerados.NivelesErrorLog.I.ToString()));
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
					string c = oException.Message.ToString();
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
			this.ddlbAño.SelectedIndexChanged += new System.EventHandler(this.ddlbAño_SelectedIndexChanged);
			this.IbtnCierre.Click += new System.Web.UI.ImageClickEventHandler(this.IbtnCierre_Click);
			this.ibtnFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnFiltro_Click);
			this.ibtnEliminarFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminarFiltro_Click);
			this.ibtnExportar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnExportar_Click);
			this.ibtnAgregar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAgregar_Click);
			this.ibtnEliminar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminar_Click);
			this.ibtnProyectosEnCartera.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnProyectosEnCartera_Click);
			this.ibtnObservaciones.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnObservaciones_Click);
			this.ibtnImprimir.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnImprimir_Click);
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
			// TODO:  Add AdministrarVentasReales.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarVentasReales.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dtVentas = this.VentasReales();
					
			if(dtVentas!=null)
			{
				DataView dwVentas = dtVentas.DefaultView;
				dwVentas.Sort = columnaOrdenar ;
				dwVentas.RowFilter = Utilitario.Helper.ObtenerFiltro();

				if(dwVentas.Count > POSICIONINICIALCOMBO)
				{
					grid.DataSource = dwVentas;
					lblResultado.Visible = false;
					grid.Columns[PosicionFooterCantidadTotal].FooterText = dwVentas.Count.ToString();
					DataTable Suma = Helper.DataViewTODataTable(dwVentas);
					grid.Columns[PosicionFooterMontoTotal].FooterText = Helper.TotalizarDataView(Suma.DefaultView,Enumerados.ColumnasVentasReales.MONTOPRECIOVENTASOLES.ToString())[Constantes.POSICIONCONTADOR].ToString(Constantes.FORMATODECIMAL4);
				}
				else
				{
					grid.DataSource = null;
					lblResultado.Visible = true;
					lblResultado.Text = GRILLAVACIA;
				}
				CImpresion oCImpresion = new CImpresion();
				oCImpresion.GuardarDataImprimirExportar(dwVentas.Table,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGOTITULOREPORTEVENTASREALES),columnaOrdenar,indicePagina);
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
			this.llenarAnos();
		}

		public void LlenarDatos()
		{
			// TODO:  Add AdministrarVentasReales.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			ibtnEliminar.Attributes.Add(Constantes.EVENTOCLICK,JSVERIFICARELIMINAR);
			this.ibtnProyectosEnCartera.Attributes.Add(Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			this.ibtnObservaciones.Attributes.Add(Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			this.ibtnAgregar.Attributes.Add(Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			//this.ibtnExportar.Attributes.Add(Constantes.EVENTOCLICK, Utilitario.Constantes.ABRIREXCEL );
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarVentasReales.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			ltlMensaje.Text = Helper.PopupImpresion(URLIMPRESION,750,500,false,false,false,true,true);
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarVentasReales.Exportar implementation
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

		private void validacierreventas()
			//{ if (Convert.ToInt32(CNetAccessControl.GetUserIdGrupodeCentrodeCosto() )== 70)
		{
			if (Convert.ToInt32(CNetAccessControl.GetUserIdGrupodeCentrodeCosto() )== 680) 
				//|| (Convert.ToInt32(CNetAccessControl.GetUserIdGrupodeCentrodeCosto() ) == 405))
			//if (Convert.ToInt32(CNetAccessControl.GetUserIdGrupodeCentrodeCosto() )== 13 || (Convert.ToInt32(CNetAccessControl.GetUserIdGrupodeCentrodeCosto() ) == 70))
			
					{ 
					//	this.IbtnCierre.Visible = true;
                     
	                     
				 //int Mes = Convert.ToInt32(DateTime.Now.Month)-1 ; 
				//int Año = Convert.ToInt32(DateTime.Now.Year);

 


			int Mes = ((DateTime.Now.Month==1)? 12:DateTime.Now.Month-1); 
			int Año = ((DateTime.Now.Month==1)? DateTime.Now.Year-1:DateTime.Now.Year);

						CVentasReales oCVentasReales = new CVentasReales();

						DataTable dt =  oCVentasReales.ConsultarVentasRealesCierreDirectorio(Mes,Año);
						if(dt!=null)
						{
							DataRow dr = dt.Rows[0];
                         	if ((Convert.ToInt32(dr["Mes"]) == Mes) && (Convert.ToInt32(dr["Año"]) == Año))
							//	if ((Convert.ToInt32(dr["Mes"]) == Mes) && (Convert.ToInt32(dr["Año"]) == Año))
							{ 
								this.BtnActivado.Visible =  true;	
								this.IbtnCierre.Visible = true;
								}
								else
								{ 
								 this.BtnActivado.Visible = false;	
								 this.IbtnCierre.Visible = true;
								}
							}
						}
				}

		
		/// <summary>
		/// Llena el combo de Centros Operativos
		/// </summary>
		private void llenarCentrosOperativos()
		{
			bool eliminado = true;
			CCentroOperativo oCCentroOperativo =  new CCentroOperativo();
			//DataTable dtCO = oCCentroOperativo.ListarCentroOperativoAccesoSegunPrivilegioUsuario(CNetAccessControl.GetIdUser(), Convert.ToInt32(Enumerados.TablasTabla.EstadosVentasReales));
			DataTable dtCO = oCCentroOperativo.ListarCentroOperativoAccesoSegunPrivilegioUsuario(CNetAccessControl.GetIdUser());
			DataView dwCO = dtCO.DefaultView;
			while(eliminado)
			{
				foreach(DataRowView dr in dwCO)
				{
					if(dr[Enumerados.ColumnasCentroOperativo.IdCentroOperativo.ToString()].ToString().Trim() ==
						((int)Utilitario.Enumerados.IdCentroOperativo.SimaPeru).ToString())
					{
						dr.Delete();
						eliminado = true;
						break;
					}
					eliminado = false;
				}
			}
			ddlbCentroOperativo.DataSource = dwCO;
			ddlbCentroOperativo.DataValueField=Enumerados.ColumnasCentroOperativo.IdCentroOperativo.ToString();
			ddlbCentroOperativo.DataTextField=Enumerados.ColumnasCentroOperativo.Sigla1.ToString();
			ddlbCentroOperativo.DataBind();
			
			if(dwCO.Count > 1)
			{
				lItem1 = new ListItem(Utilitario.Constantes.TEXTOTODOS,Utilitario.Constantes.VALORTODOS);
				ddlbCentroOperativo.Items.Insert(0,lItem1);
			}
		}

		private void llenarAnos()
		{
			#region Obtener años de la tabla de	PeriodoContable
			//CPeriodoContable oCPeriodoContable = new CPeriodoContable();
			//ddlbAño.DataSource = oCPeriodoContable.ListarTodosPeriodo();
			//ddlbAño.DataValueField="Periodo";
			//ddlbAño.DataTextField="Periodo";
			//ddlbAño.DataBind();
			#endregion
			
			int indice = 0;
			for(int i = 1997; i <= DateTime.Today.Year; i++)
			{
				ddlbAño.Items.Insert(indice,i.ToString());
				indice++;
			}
			
			lItem = new ListItem(Utilitario.Constantes.TEXTOTODOS,Utilitario.Constantes.VALORTODOS);
			this.ddlbAño.Items.Insert(Utilitario.Constantes.POSICIONCONTADOR,lItem); 

			if(HttpContext.Current.Session[KEYQPOSICIONCOMBOANO] == null)
			{
				item = ddlbAño.Items.FindByText(Helper.FechaSimanet.ObtenerFechaSesion().Year.ToString());
				if (item !=null){item.Selected = true;}
			}

		}

		private void RestablecerPagina()
		{
			if(HttpContext.Current.Session[KEYQPOSICIONCOMBO] != null)
			{
				this.ddlbCentroOperativo.Items.FindByValue(HttpContext.Current.Session[KEYQPOSICIONCOMBO].ToString()).Selected = true;
			}
			if(HttpContext.Current.Session[KEYQPOSICIONCOMBOANO] != null)
			{
				this.ddlbAño.Items.FindByValue(HttpContext.Current.Session[KEYQPOSICIONCOMBOANO].ToString()).Selected = true;		
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
				e.Item.Cells[Constantes.POSICIONCONTADOR].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado(COMBOANO,CO) + Utilitario.Constantes.POPUPDEESPERA);

				e.Item.Cells[Constantes.POSICIONCONTADOR].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.MostrarVentana(URLDETALLE,KEYQID + Utilitario.Constantes.SIGNOIGUAL + 
																																			Convert.ToString(dr[Enumerados.ColumnasVentasReales.IDVENTAREAL.ToString()]) +  
																																			Utilitario.Constantes.SIGNOAMPERSON + Utilitario.Constantes.KEYMODOPAGINA +  
																																			Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.M.ToString()));
					
				e.Item.Cells[Constantes.POSICIONCONTADOR].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				e.Item.Cells[Constantes.POSICIONCONTADOR].Font.Underline=true;
				e.Item.Cells[Constantes.POSICIONCONTADOR].ForeColor = System.Drawing.Color.Blue;

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,Utilitario.Helper.MostrarDatosEnCajaTexto("hCodigo",dr[Enumerados.ColumnasVentasReales.IDVENTAREAL.ToString()].ToString()));
				Helper.FiltroporSeleccionConfiguraColumna(e,grid);
			}
		}

		
		private void ddlbCentroOperativo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Session[KEYQPOSICIONCOMBO] = this.ddlbCentroOperativo.SelectedValue;
			Session[KEYQPOSICIONCOMBOANO] = this.ddlbAño.SelectedValue;
			
			Helper.EliminarFiltro();

			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se consultaron las Ventas Reales del Centro Operativo" + this.ddlbCentroOperativo.SelectedItem.Text + Utilitario.Constantes.SEPARADOR + this.ddlbAño.SelectedItem.Text + ".",Enumerados.NivelesErrorLog.I.ToString()));
			this.RestablecerPagina();
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO),Utilitario.Constantes.INDICEPAGINADEFAULT);
		}

		private void ddlbAño_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Session[KEYQPOSICIONCOMBO] = this.ddlbCentroOperativo.SelectedValue;
			Session[KEYQPOSICIONCOMBOANO] = this.ddlbAño.SelectedValue;

			Helper.EliminarFiltro();

			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se consultaron las Ventas Reales del Centro Operativo" + this.ddlbCentroOperativo.SelectedItem.Text + Utilitario.Constantes.SEPARADOR + this.ddlbAño.SelectedItem.Text + ".",Enumerados.NivelesErrorLog.I.ToString()));
			this.RestablecerPagina();
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO),Utilitario.Constantes.INDICEPAGINADEFAULT);
		}

		private void ibtnFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			ltlMensaje.Text= Utilitario.Helper.ElaborarFiltro(this.VentasReales()
				,Constantes.SIGNOASTERISCO + Utilitario.Enumerados.ColumnasVentasReales.CENTROOPERATIVO.ToString()+";Centro Operativo"
				,Constantes.SIGNOASTERISCO + Utilitario.Enumerados.ColumnasVentasReales.LINEANEGOCIO.ToString()+ ";Linea de Negocio"
				,Constantes.SIGNOASTERISCO + Utilitario.Enumerados.ColumnasVentasReales.SECTOR.ToString()+ ";Sector"
				,Utilitario.Enumerados.ColumnasVentasReales.RAZONSOCIAL.ToString()+ ";Razon Social"
				,Utilitario.Enumerados.ColumnasVentasReales.DESCRIPCION.ToString()+ ";Descripcion del Proyecto"
				,Utilitario.Enumerados.ColumnasVentasReales.MONTOPRECIOVENTASOLES.ToString()+ ";Monto"
				,Utilitario.Enumerados.ColumnasVentasReales.FECHA.ToString()+ ";Fecha");
		}

		private void ibtnEliminarFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}

		private void ibtnImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Imprimir();
		}

		private void ibtnAgregar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.redireccionaPaginaAgregar();
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

				if(oCMantenimientos.Eliminar(Convert.ToInt32(hCodigo.Value),CNetAccessControl.GetIdUser(),Enumerados.ClasesTAD.VentasRealesTAD.ToString())>0)
				{
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se eliminó la Venta Real Nro. " + hCodigo.Value +"." ,Enumerados.NivelesErrorLog.I.ToString()));
					this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),Helper.ObtenerIndicePagina());
					ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONELIMINACIONREGISTRO));
				}
			}
		}

		private void ibtnProyectosEnCartera_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Page.Response.Redirect(URLPROYECTOSENCARTERA);
		}

		private void ibtnObservaciones_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Page.Response.Redirect(URLOBSERVACIONESVENTAS + KEYTIPOOBSERVACION + Utilitario.Constantes.SIGNOIGUAL + "MENSUAL");
		}

		private void redireccionaPaginaAgregar()
		{
			Page.Response.Redirect(URLDETALLE + 
				Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.N.ToString());
		}

		private DataTable VentasReales()
		{
			CVentasReales oCVentasReales = new CVentasReales();

			if(this.ddlbCentroOperativo.SelectedValue == Utilitario.Constantes.VALORTODOS && this.ddlbAño.SelectedValue == Utilitario.Constantes.VALORTODOS)
			{
				return oCVentasReales.ConsultarVentasRealesPorCentroOperativo(Utilitario.Constantes.TODASLASVENTASREALES,Utilitario.Constantes.TODASLASVENTASREALES);
			}
			else
			{
				if(this.ddlbCentroOperativo.SelectedValue == Utilitario.Constantes.VALORTODOS && this.ddlbAño.SelectedValue != Utilitario.Constantes.VALORTODOS)
				{
					return  oCVentasReales.ConsultarVentasRealesPorCentroOperativo(Utilitario.Constantes.TODASLASVENTASREALES,Convert.ToInt32(this.ddlbAño.SelectedValue));
				}
				else if (this.ddlbCentroOperativo.SelectedValue != Utilitario.Constantes.VALORTODOS && this.ddlbAño.SelectedValue == Utilitario.Constantes.VALORTODOS )
				{
					return  oCVentasReales.ConsultarVentasRealesPorCentroOperativo(Convert.ToInt32(this.ddlbCentroOperativo.SelectedValue),Utilitario.Constantes.TODASLASVENTASREALES);
				}
				else
				{
					return  oCVentasReales.ConsultarVentasRealesPorCentroOperativo(Convert.ToInt32(this.ddlbCentroOperativo.SelectedValue),Convert.ToInt32(this.ddlbAño.SelectedValue));
				}
			}
		}

		private void ibtnExportar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			CVentasReales oCVentasReales = new CVentasReales();
			DataTable dtVentasReporte = oCVentasReales.ConsultarMontoVentasRealaesTotalesAcumuladas();
			
			if(dtVentasReporte != null)
			{
				DataView dwVentasReporte = dtVentasReporte.DefaultView;
				this.gridReporte.DataSource = dwVentasReporte;

				try
				{
					this.gridReporte.DataBind();
				}
				catch(Exception a)
				{
					string b = a.Message.ToString();
					this.gridReporte.DataBind();
				}

				Helper.GenerarExcelCompleto(this, this.gridReporte);
			}
			else
			{
				this.gridReporte.DataSource = dtVentasReporte;
			}

		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void IbtnCierre_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			//this.IbtnCierre.Visible = true;		

			ProyectoTrabajoBE oProyectoTrabajoBE = new ProyectoTrabajoBE();
			oProyectoTrabajoBE.FechaBuenaPro = DateTime.Now;
			CCierreDirectorio oCCierreDirectorio = new CCierreDirectorio();
			oCCierreDirectorio.ProyectoTrabajo(oProyectoTrabajoBE);
			this.IbtnCierre.Visible = true;		
			this.BtnActivado.Visible = true;


		}

	}
}