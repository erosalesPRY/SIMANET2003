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
	/// Summary description for AdministracionFotos.
	/// </summary>
	public class AdministracionFotos : System.Web.UI.Page,IPaginaBase
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

		#endregion Controles

		#region Constantes
		//Ordenamiento
		const string COLORDENAMIENTO = "IdCodigoFoto";

		//Nombres de Controles
		const string CONTROLIMAGENDIGITALIZADO = "imgDigitalizado";
		
		//Paginas
		const string URLDETALLE = "DetalleFotos.aspx?";
		const string URLIMPRESION = "PopupImpresionAdministracionArticulosRelacionesPublicas.aspx";
				
		//Key Session y QueryString
		const string KEYQID = "Id";
		const string KEYQDESCRIPCION = "Descripcion";
		const string KEYTIPO = "Tipo";
		const string KEYQIDFOTO = "IdFoto";

		//JScript
		string JSVERIFICARELIMINAR = "return verificarEliminarRb('hCodigo','" + Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO)+"','"+Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJEPREGUNTAELIMINACIONREGISTRO)+"');";
			
		//Otros
		const string GRILLAVACIA ="No existe ninguna Foto.";
		  
		const int PosicionFooterTotal = 2;
		const string TituloConstante ="ADMINISTRACION DE FOTOS";
		const int PosicionImagenDigitalizado = 6;
		const string ImagenDigitalizadoSi = "../../imagenes/CheckYes.png";
		const string ImagenDigitalizadoNo = "../../imagenes/CheckNo.png";
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

				if(oCMantenimientos.Eliminar(Convert.ToInt32(hCodigo.Value),CNetAccessControl.GetIdUser(),Enumerados.ClasesTAD.FotoTAD.ToString())>0)
				{
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se eliminó La Foto Nro. " + hCodigo.Value +"." ,Enumerados.NivelesErrorLog.I.ToString()));
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

					Helper.ReiniciarSession();

					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se consultaron las Fotos del Buque o Visita "+Page.Request.QueryString[KEYQID],Enumerados.NivelesErrorLog.I.ToString()));

					this.LlenarDatos();

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
			this.ibtnFiltrar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnFiltrar_Click);
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
			// TODO:  Add AdministracionFotos.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministracionFotos.LlenarGrillaOrdenamiento implementation
		}

		public DataTable ObtenerDatos()
		{
			if(Page.Request.QueryString[KEYTIPO] == Enumerados.TipoEntidadConFoto.Buque.ToString())
			{
				CFoto oCFoto = new CFoto();
				return (oCFoto.ConsultarFotosPorBuque(Convert.ToInt32(Page.Request.QueryString[KEYQID])));
			}
			else if(Page.Request.QueryString[KEYTIPO] == Enumerados.TipoEntidadConFoto.Visita.ToString())
			{
				CFoto oCFoto = new CFoto();
				return(oCFoto.ConsultarFotosPorVisitas(Convert.ToInt32(Page.Request.QueryString[KEYQID])));
			}
		return null;
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
		{
			DataTable dtFotos = this.ObtenerDatos();

			if(dtFotos!=null)
			{
				DataView dwFotos = dtFotos.DefaultView;
				dwFotos.Sort = columnaOrdenar ;
				dwFotos.RowFilter = Helper.ObtenerFiltro(this);

				if(dwFotos.Count>0)
				{
					grid.DataSource = dwFotos;
					grid.Columns[PosicionFooterTotal].FooterText = dwFotos.Count.ToString();
					this.lblResultado.Visible = false;
				}
				else
				{
					grid.DataSource = null;
					lblResultado.Visible = true;
					lblResultado.Text = GRILLAVACIA;
				}
				CImpresion oCImpresion = new CImpresion();
				oCImpresion.GuardarDataImprimirExportar(dwFotos.Table,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGOTITULOREPORTEPRESENTES),columnaOrdenar,indicePagina);
			}
			else
			{
				grid.DataSource = dtFotos;
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
			// TODO:  Add AdministracionFotos.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			if(Page.Request.QueryString[KEYTIPO] == Enumerados.TipoEntidadConFoto.Buque.ToString())
				this.lblTitulo.Text = TituloConstante+Constantes.ESPACIO+Constantes.LINEA+Constantes.ESPACIO+Enumerados.TipoEntidadConFoto.Buque.ToString().ToUpper()+Constantes.ESPACIO+Constantes.LINEA+Constantes.ESPACIO+Page.Request.QueryString[KEYQDESCRIPCION];

			else if(Page.Request.QueryString[KEYTIPO] == Enumerados.TipoEntidadConFoto.Visita.ToString())
				this.lblTitulo.Text = TituloConstante+Constantes.ESPACIO+Constantes.LINEA+Constantes.ESPACIO+Enumerados.TipoEntidadConFoto.Visita.ToString().ToUpper()+Constantes.ESPACIO+Constantes.LINEA+Constantes.ESPACIO+Page.Request.QueryString[KEYQDESCRIPCION];

		}

		public void LlenarJScript()
		{
			ibtnEliminar.Attributes.Add(Constantes.EVENTOCLICK,JSVERIFICARELIMINAR);
			ibtnAgregar.Attributes.Add(Constantes.EVENTOMOUSEDOWN, Helper.HistorialIrAdelantePersonalizado(Utilitario.Constantes.VACIO));
			ibtnAgregar.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, Utilitario.Constantes.POPUPDEESPERA);
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministracionFotos.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			ltlMensaje.Text = Helper.PopupImpresion(URLIMPRESION,750,500,false,false,false,true,true);
		}

		public void Exportar()
		{
			// TODO:  Add AdministracionFotos.Exportar implementation
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
					Helper.MostrarVentana(URLDETALLE,
					KEYQID + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQID] +  Utilitario.Constantes.SIGNOAMPERSON +
					Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.M.ToString() +  Utilitario.Constantes.SIGNOAMPERSON +
					KEYQDESCRIPCION + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQDESCRIPCION] +  Utilitario.Constantes.SIGNOAMPERSON +
					KEYTIPO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYTIPO] +  Utilitario.Constantes.SIGNOAMPERSON +
					KEYQIDFOTO + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr[Enumerados.ColumnasFoto.IdCodigoFoto.ToString()])
					));
	
				if(Convert.ToInt32(dr[Enumerados.ColumnasFoto.FlgDigitalizado.ToString()]) == Constantes.POSICIONCONTADOR)
				{
					Image img1 = (Image)e.Item.Cells[PosicionImagenDigitalizado].FindControl(CONTROLIMAGENDIGITALIZADO);
					img1.ImageUrl = ImagenDigitalizadoNo;
				}
				else
				{
					Image img1 = (Image)e.Item.Cells[PosicionImagenDigitalizado].FindControl(CONTROLIMAGENDIGITALIZADO);
					img1.ImageUrl = ImagenDigitalizadoSi;
				}

				e.Item.Cells[Constantes.POSICIONCONTADOR].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				e.Item.Cells[Constantes.POSICIONCONTADOR].Font.Underline=true;
				e.Item.Cells[Constantes.POSICIONCONTADOR].ForeColor = System.Drawing.Color.Blue;

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,Utilitario.Helper.MostrarDatosEnCajaTexto("hCodigo",dr[Enumerados.ColumnasFoto.IdCodigoFoto.ToString()].ToString()));
				Helper.FiltroporSeleccionConfiguraColumna(e,grid);
			}
		}

		private void redireccionaPaginaAgregar()
		{
			Page.Response.Redirect(URLDETALLE + 
				Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.N.ToString() +  Utilitario.Constantes.SIGNOAMPERSON +
				KEYQID + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt32(Page.Request.QueryString[KEYQID]) +  Utilitario.Constantes.SIGNOAMPERSON +
				KEYQDESCRIPCION + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQDESCRIPCION] +  Utilitario.Constantes.SIGNOAMPERSON +
				KEYTIPO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYTIPO]
				);
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
			//this.Imprimir();
		}

		private void ibtnFiltrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			ltlMensaje.Text= Utilitario.Helper.ElaborarFiltro(this.ObtenerDatos()
					,Utilitario.Enumerados.ColumnasFoto.CodigoCaja.ToString() + ";Codigo de Caja"
					,Utilitario.Enumerados.ColumnasFoto.RutaFisica.ToString() + ";Ruta Fisica"
					,Constantes.SIGNOASTERISCO + Utilitario.Enumerados.ColumnasFoto.IdFormato.ToString() + ";Formato"
					,Utilitario.Enumerados.ColumnasFoto.CantidadFotos.ToString() + ";Cantidad de Fotos"
					,Utilitario.Enumerados.ColumnasFoto.PorcentajeAvance.ToString() + ";Porcentaje de Avance"
					);
		}

		private void ibtnEliminarFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}
	}
}