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


namespace SIMA.SimaNetWeb.GestionComercial.ComunicacionImagen
{
	/// <summary>
	/// Summary description for AdministracionBuques.
	/// </summary>
	public class AdministracionBuques : System.Web.UI.Page,IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblPosicionRegistro;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;
		protected System.Web.UI.WebControls.ImageButton ibtnAgregar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminar;
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminarFiltro;
		protected System.Web.UI.WebControls.ImageButton ibtnFoto;
		protected System.Web.UI.WebControls.ImageButton ibtnVideo;
		protected System.Web.UI.WebControls.Label lblLugar;
		protected System.Web.UI.WebControls.DropDownList ddlbLugar;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hDescripcion;
		#endregion Controles

		#region Constantes
		//Ordenamiento
		const string COLORDENAMIENTO = "IdBuque";

		//Nombres de Controles
		const string CONTROLIMAGENENSIMA = "imgEnSima";
		const string CONTROLIMAGENFOTO = "imgFoto";
		const string CONTROLIMAGENVIDEO = "imgVideo";
		
		//Paginas
		const string URLDETALLE = "DetalleBuques.aspx?";
		const string URLIMPRESION = "PopupImpresionAdministracionArticulosRelacionesPublicas.aspx";
		const string URLADMINISTRACIONFOTOS = "AdministracionFotos.aspx?";
		const string URLADMINISTRACIONVIDEOS = "AdministracionVideos.aspx?";
				
		//Key Session y QueryString
		const string KEYQID = "Id";
		const string KEYQPOSICIONCOMBO = "PosicionCombo";
		const string KEYQDESCRIPCION = "Descripcion";
		const string KEYTIPO = "Tipo";

		//JScript
		string JSVERIFICARELIMINAR = "return verificarEliminarRb('hCodigo','" + Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO)+"','"+Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJEPREGUNTAELIMINACIONREGISTRO)+"');";
			
		//Otros
		const string GRILLAVACIA ="No existe ningun Buque.";
		const int PosicionFooterTotal = 2;
		const int PosicionImagenEnSima = 4;
		const int PosicionImageFoto = 9;
		const int PosicionImagenVideo = 10;
		const string TiposVistaGeneral = "GENERAL";
		const string TiposVistaEnSIMA = "EN SIMA";
		const int ValorTiposVistaGeneral = 1;
		const int ValorTiposVistaEnSIMA = 2;
		const string ImagenEnSimaNo = "../../imagenes/CheckNo.png";
		const string ImagenEnSimaSi = "../../imagenes/CheckYes.png";
		const string ImagenFotoSi = "../../imagenes/Foto.jpg";
		const string ImagenFotoNo = "../../imagenes/FotoBW.jpg";
		const string ImagenVideoSi = "../../imagenes/Video.jpg";
		const string ImagenVideoNo = "../../imagenes/VideoBW.jpg";
		#endregion Constantes

		#region Variables
		#endregion Variables
		
		/// <summary>
		/// Elimina el Articulo destinado a Relaciones Publicas seleccionado
		/// </summary>
		private void eliminar()
		{			
			if(hCodigo.Value.Length==0)
			{
				ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO));
			}
			else
			{
				CMantenimientos oCMantenimientos = new CMantenimientos();

				if(oCMantenimientos.Eliminar(Convert.ToInt32(hCodigo.Value),CNetAccessControl.GetIdUser(),Enumerados.ClasesTAD.BuqueTAD.ToString())>0)
				{
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se eliminó el Buque Nro. " + hCodigo.Value +"." ,Enumerados.NivelesErrorLog.I.ToString()));
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
					
					this.LlenarJScript();

					this.LlenarCombos();

					Helper.ReiniciarSession();

					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se consultaron los Buques.",Enumerados.NivelesErrorLog.I.ToString()));

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
			this.ddlbLugar.SelectedIndexChanged += new System.EventHandler(this.ddlbLugar_SelectedIndexChanged);
			this.ibtnFiltrar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnFiltrar_Click);
			this.ibtnEliminarFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminarFiltro_Click);
			this.ibtnFoto.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnFoto_Click);
			this.ibtnVideo.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnVideo_Click);
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
			// TODO:  Add AdministracionBuques.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministracionBuques.LlenarGrillaOrdenamiento implementation
		}

		public DataTable ObtenerDatos()
		{
			if(this.ddlbLugar.SelectedValue == ValorTiposVistaGeneral.ToString())
			{
				CMantenimientos oCMantenimientos =  new CMantenimientos();
				return (oCMantenimientos.ListarTodosGrilla(Enumerados.ClasesNTAD.BuqueNTAD.ToString()));
			}
			else if(this.ddlbLugar.SelectedValue == ValorTiposVistaEnSIMA.ToString())
			{
				CBuque oCBuque =  new CBuque();
				return(oCBuque.ListarBuquesEnTrabajo());
			}
			return null;
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
		{
			DataTable dtBuques = this.ObtenerDatos();

			if(dtBuques!=null)
			{
				DataView dwBuques = dtBuques.DefaultView;
				dwBuques.Sort = columnaOrdenar ;
				dwBuques.RowFilter = Helper.ObtenerFiltro(this);

				if(dwBuques.Count>0)
				{
					grid.DataSource = dwBuques;
					grid.Columns[PosicionFooterTotal].FooterText = dwBuques.Count.ToString();
					this.lblResultado.Visible = false;
				}
				else
				{
					grid.DataSource = null;
					lblResultado.Visible = true;
					lblResultado.Text = GRILLAVACIA;
				}
				CImpresion oCImpresion = new CImpresion();
				oCImpresion.GuardarDataImprimirExportar(dwBuques.Table,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGOTITULOREPORTEPRESENTES),columnaOrdenar,indicePagina);
			}
			else
			{
				grid.DataSource = dtBuques;
				this.lblResultado.Visible = true;
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
			this.llenarTiposVista();
		}

		public void LlenarDatos()
		{
			// TODO:  Add AdministracionBuques.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			ibtnEliminar.Attributes.Add(Constantes.EVENTOCLICK,JSVERIFICARELIMINAR);

			ibtnFoto.Attributes.Add(Constantes.EVENTOMOUSEDOWN, Helper.HistorialIrAdelantePersonalizado(Utilitario.Constantes.VACIO));
			ibtnFoto.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, Utilitario.Constantes.POPUPDEESPERA);

			ibtnVideo.Attributes.Add(Constantes.EVENTOMOUSEDOWN, Helper.HistorialIrAdelantePersonalizado(Utilitario.Constantes.VACIO));
			ibtnVideo.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, Utilitario.Constantes.POPUPDEESPERA);

		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministracionBuques.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			ltlMensaje.Text = Helper.PopupImpresion(URLIMPRESION,750,500,false,false,false,true,true);
		}

		public void Exportar()
		{
			// TODO:  Add AdministracionBuques.Exportar implementation
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
					Helper.MostrarVentana(URLDETALLE,KEYQID + Utilitario.Constantes.SIGNOIGUAL + 
					Convert.ToString(dr[Enumerados.ColumnasBuque.IdBuque.ToString()]) +  
					Utilitario.Constantes.SIGNOAMPERSON + Utilitario.Constantes.KEYMODOPAGINA +
					Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.M.ToString()));

				if(Convert.ToInt32(dr[Enumerados.ColumnasBuque.flgEnTrabajos.ToString()]) == Constantes.POSICIONCONTADOR)
				{
					Image img1 = (Image)e.Item.Cells[PosicionImagenEnSima].FindControl(CONTROLIMAGENENSIMA);
					img1.ImageUrl = ImagenEnSimaNo;
				}
				else
				{
					Image img1 = (Image)e.Item.Cells[PosicionImagenEnSima].FindControl(CONTROLIMAGENENSIMA);
					img1.ImageUrl = ImagenEnSimaSi;
				}

				if(Convert.ToInt32(dr[Enumerados.ColumnasFoto.IdCodigoFoto.ToString()]) == Constantes.POSICIONCONTADOR)
				{
					Image img1 = (Image)e.Item.Cells[PosicionImageFoto].FindControl(CONTROLIMAGENFOTO);
					img1.ImageUrl = ImagenFotoNo;
				}
				else
				{
					Image img1 = (Image)e.Item.Cells[PosicionImageFoto].FindControl(CONTROLIMAGENFOTO);
					img1.ImageUrl = ImagenFotoSi;
				}

				if(Convert.ToInt32(dr[Enumerados.ColumnasVideo.IdCodigoVideo.ToString()]) == Constantes.POSICIONCONTADOR)
				{
					Image img1 = (Image)e.Item.Cells[PosicionImagenVideo].FindControl(CONTROLIMAGENVIDEO);
					img1.ImageUrl = ImagenVideoNo;
				}
				else
				{
					Image img1 = (Image)e.Item.Cells[PosicionImagenVideo].FindControl(CONTROLIMAGENVIDEO);
					img1.ImageUrl = ImagenVideoSi;
				}
	
				e.Item.Cells[Constantes.POSICIONCONTADOR].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				e.Item.Cells[Constantes.POSICIONCONTADOR].Font.Underline=true;
				e.Item.Cells[Constantes.POSICIONCONTADOR].ForeColor = System.Drawing.Color.Blue;

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,
					Utilitario.Helper.MostrarDatosEnCajaTexto("hCodigo",dr[Enumerados.ColumnasBuque.IdBuque.ToString()].ToString()),
					Utilitario.Helper.MostrarDatosEnCajaTexto("hDescripcion",dr[Enumerados.ColumnasBuque.NombreBuque.ToString()].ToString()));
				Helper.FiltroporSeleccionConfiguraColumna(e,grid);
			}
		}

		/// <summary>
		/// Abre la Pagina para Agregar un Buque
		/// </summary>
		private void redireccionaPaginaAgregar()
		{
			Page.Response.Redirect(URLDETALLE + Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.N.ToString());
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

		private void ibtnImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			// TODO:  Add AdministracionBuques.ibtnImprimir_Click implementation
		}

		private void ibtnFiltrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			ltlMensaje.Text= Utilitario.Helper.ElaborarFiltro(this.ObtenerDatos()
				,Constantes.SIGNOASTERISCO + Utilitario.Enumerados.ColumnasBuque.IdLineaNegocio.ToString()+";Linea Negocio"
				,Utilitario.Enumerados.ColumnasBuque.NombreBuque.ToString()+ ";Nombre de Buque"
				,Utilitario.Enumerados.ColumnasBuque.PosicionBuque.ToString()+ ";Posicion"
				,Utilitario.Enumerados.ColumnasBuque.IdTrabajoActual.ToString()+ ";Trabajo Actual"
				,Utilitario.Enumerados.ColumnasBuque.NombreOficialMando.ToString()+ ";Nombre de Oficial al Mando"
				,Constantes.SIGNOASTERISCO + Utilitario.Enumerados.ColumnasBuque.IdGrado.ToString()+ ";Grado"
				);
		}

		private void ibtnEliminarFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}

		private void llenarTiposVista()
		{
			ListItem lItem1 = new ListItem(TiposVistaGeneral,ValorTiposVistaGeneral.ToString());
			ListItem lItem2 = new ListItem(TiposVistaEnSIMA,ValorTiposVistaEnSIMA.ToString());
			ddlbLugar.Items.Insert(Constantes.POSICIONCONTADOR,lItem1);
			ddlbLugar.Items.Insert(Constantes.POSICIONCONTADOR+1,lItem2);
			ddlbLugar.DataBind();
			if(HttpContext.Current.Session[KEYQPOSICIONCOMBO] != null)
			{
				this.ddlbLugar.Items.FindByValue(HttpContext.Current.Session[KEYQPOSICIONCOMBO].ToString()).Selected = true;
			}
		}

		private void ddlbLugar_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Session[KEYQPOSICIONCOMBO] = this.ddlbLugar.SelectedValue;

			Helper.EliminarFiltro();

			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se consultaron los Buques por Lugar del Tipo de Persona " + this.ddlbLugar.SelectedItem.Text+ ".",Enumerados.NivelesErrorLog.I.ToString()));

			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO),Utilitario.Constantes.INDICEPAGINADEFAULT);
		}

		private void ibtnFoto_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if(this.hCodigo.Value.Length==0)
			{
				ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO));
			}
			else
			{
				Page.Response.Redirect(URLADMINISTRACIONFOTOS+
					KEYQID+Constantes.SIGNOIGUAL+this.hCodigo.Value+Constantes.SIGNOAMPERSON+
					KEYQDESCRIPCION+Constantes.SIGNOIGUAL+this.hDescripcion.Value+Constantes.SIGNOAMPERSON+
					KEYTIPO+Constantes.SIGNOIGUAL+Enumerados.TipoEntidadConFoto.Buque.ToString());
			}
		}

		private void ibtnVideo_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if(this.hCodigo.Value.Length==0)
			{
				ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO));
			}
			else
			{
				Page.Response.Redirect(URLADMINISTRACIONVIDEOS+
					KEYQID+Constantes.SIGNOIGUAL+this.hCodigo.Value+Constantes.SIGNOAMPERSON+
					KEYQDESCRIPCION+Constantes.SIGNOIGUAL+this.hDescripcion.Value+Constantes.SIGNOAMPERSON+
					KEYTIPO+Constantes.SIGNOIGUAL+Enumerados.TipoEntidadConFoto.Buque.ToString());
			}
		}
	}
}