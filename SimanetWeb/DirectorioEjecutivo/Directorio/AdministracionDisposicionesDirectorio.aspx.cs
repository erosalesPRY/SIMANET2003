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
using SIMA.Controladoras.General;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using NullableTypes;
using MetaBuilders.WebControls;
using SIMA.Controladoras.Secretaria.Directorio;

namespace SIMA.SimaNetWeb.DirectorioEjecutivo.Directorio
  {
	/// <summary>
	/// Summary description for RequerimientosAsignados.
	/// </summary>
	public class AdministracionDisposicionesDirectorio : System.Web.UI.Page,IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminarFiltro;
		protected System.Web.UI.WebControls.ImageButton ibtnAgregar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminar;
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
		protected System.Web.UI.WebControls.ImageButton ibtnGestiones;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnSesiones;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden Hidden1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hDescripcion;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion Controles
	

		#region Constantes
	
		//Ordenamiento
		const string COLORDENAMIENTO = "IdDisposicion";

		//Nombres de Controles
		const string CONTROLINK = "hlkId";
		const string CONTROCHECKBOX = "cbxEliminar";
	
		//Paginas
		const string URLDETALLE = "DetalleDisposicionesDirectorio.aspx?";
//		const string URLIMPRESION = "PopupImpresionAdministracionDisposicionesDirectorio.aspx";
		const string URLSESIONES = "ConsultaSesionDirectorio.aspx";
		const string URLGESTIONES = "AdministracionGestionesDirectorio.aspx?";				
		//Key Session y QueryString
	
		const string KEYQIDSESIONDIRECTORIO = "IdSesionDirectorio";
		const string KEYQID = "Id";
		const string KEYQIDTIPODISPOSICION = "IdTipoDisposicion";
		const string KEYQIDACUERDO = "IdAcuerdo";
		const string KEYQDESCRIPCION = "Descripcion";
		const string KEYQIDTIPOINFORME = "IdTipoInforme";
		//JScript
		string JSVERIFICARELIMINAR = "return verificarEliminarRb('hCodigo','" + Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO)+"','"+Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJEPREGUNTAELIMINACIONREGISTRO)+"');";
		
		//Otros
		const string GRILLAVACIA ="No existe ninguna Disposición del Directorio";  
		const string ACUERDOS ="Acuerdos Permanentes";  
		const string DISPOSICIONES ="Disposiciones Generales";  

		const string ACUERDO ="ACUERDO";  
		const string ASUNTO ="ASUNTO";  

		const int PERMANENTES = 0;
		protected System.Web.UI.WebControls.DropDownList ddlbSituacion;
		protected System.Web.UI.WebControls.Label Label2;
		const int GENERALES = 1;

		#endregion Constantes

		#region Variables
		#endregion Variables
	
	
		/// <summary>
		/// Elimina los Informes seleccionados
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

				if(oCMantenimientos.Eliminar(Convert.ToInt32(hCodigo.Value),CNetAccessControl.GetIdUser(),Enumerados.ClasesTAD.DisposicionesDirectorioTAD.ToString())>0)
				{
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Directorio",this.ToString(),"Se eliminó la Disposición de Directorio Nro. " + hCodigo.Value +"." ,Enumerados.NivelesErrorLog.I.ToString()));
			
					this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),Helper.ObtenerIndicePagina());
					
					ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONELIMINACIONREGISTRO));
				}
			}										
		}

		/// <summary>
		/// Limpia los valores ocultos
		/// </summary>
		private void reiniciarCampos()
		{
			//this.hCodigo.Value = "";

		}


		private void Page_Load(object sender, System.EventArgs e)
		{
		

			if(!Page.IsPostBack)
			{
				try
				{
				
					this.ConfigurarAccesoControles();
				
					this.LlenarJScript();
					this.VerificarSesionDefault();

					Helper.ReiniciarSession();

					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Secretaria - Directorio",this.ToString(),"Se consultó los Informes de Sesión de Directorio.",Enumerados.NivelesErrorLog.I.ToString()));

					this.LlenarCombos();
					Helper.SeleccionarItemCombos(this);

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

			this.reiniciarCampos();
		}

		private void VerificarSesionDefault()
		{
			CSesionDirectorio oCSesionDirectorio = new CSesionDirectorio();
			DataTable dt = oCSesionDirectorio.ConsultarUltimaSesionDirectorio();

			if (HttpContext.Current.Session[Utilitario.Constantes.KEYSIDSESIONDIRECTORIO] == null && dt != null)
			{
				Helper.GeneraSessionParaDirectorio(dt.Rows[0][Utilitario.Constantes.IDSESIONDIRECTORIO].ToString());
			}
			else
			{
				this.AsignarSession();
			}

			if (Convert.ToInt32(Page.Request.QueryString[KEYQIDTIPODISPOSICION]) == PERMANENTES)
			{
				lblPagina.Text = ACUERDOS;
				grid.Columns[4].HeaderText = ACUERDO;
			}
			else
			{
				lblPagina.Text = DISPOSICIONES;
				grid.Columns[4].HeaderText = ASUNTO;
				grid.Columns[5].Visible=true;
			}
		}
		private void AsignarSession()
		{
			if (Page.Request.QueryString[KEYQIDSESIONDIRECTORIO] != null)
			{
				Helper.GeneraSessionParaDirectorio(Page.Request.QueryString[KEYQIDSESIONDIRECTORIO].ToString());
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
			this.ibtnEliminarFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminarFiltro_Click);
			this.ddlbSituacion.SelectedIndexChanged += new System.EventHandler(this.ddlbSituacion_SelectedIndexChanged);
			this.ibtnAgregar.Click += new System.Web.UI.ImageClickEventHandler(this.imgAgregar_Click);
			this.ibtnEliminar.Click += new System.Web.UI.ImageClickEventHandler(this.imgEliminar_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
		
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
		
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
		{
			CDisposicionesDirectorio oCDisposicionesDirectorio=  new CDisposicionesDirectorio();
			DataTable dtDisposicionesDirectorio =  oCDisposicionesDirectorio.ConsultarDisposicionesPorSituacion
				(//Convert.ToInt32(Helper.RetornaSessionParaDirectorio()),
				Convert.ToInt32(Enumerados.TablasTabla.SecretariaDirectorioTablaTipoDisposicion),
				Convert.ToInt32(Page.Request.QueryString[KEYQIDTIPODISPOSICION]),
				//Utilitario.Constantes.IDDEFAULT
				Convert.ToInt32(ddlbSituacion.SelectedValue));
		
			if(dtDisposicionesDirectorio!=null)
			{
				DataView dwDisposicionesDirectorio = dtDisposicionesDirectorio.DefaultView;
				dwDisposicionesDirectorio.Sort = columnaOrdenar ;
				dwDisposicionesDirectorio.RowFilter= Utilitario.Helper.ObtenerFiltro();
				grid.DataSource = dwDisposicionesDirectorio;
			
				grid.Columns[0].FooterText = Utilitario.Constantes.TEXTOFOOTERTOTAL;
				grid.Columns[Utilitario.Constantes.POSICIONTOTAL].FooterText = dwDisposicionesDirectorio.Count.ToString();

//				CImpresion oCImpresion = new CImpresion();
//				oCImpresion.GuardarDataImprimirExportar(dtDisposicionesDirectorio,"REPORTE DE DISPOSICIONES",columnaOrdenar,indicePagina);
				lblResultado.Visible = false;
			
			}
			else
			{
				grid.DataSource = dtDisposicionesDirectorio;
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
			this.llenarSituacion();
		}

		private void llenarSituacion()
		{
			CTablaTablas oCTablaTablas =  new CTablaTablas();
			ddlbSituacion.DataSource = oCTablaTablas.ListarTodosComboDirectorio(Convert.ToInt32(Enumerados.TablasTabla.SecretariaDirectorioTablaSituacionPedidos));
			ddlbSituacion.DataValueField=Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbSituacion.DataTextField=Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbSituacion.DataBind();
		}

		public void LlenarDatos()
		{
			// TODO:  Add ConsultaDeCartasFianzas.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultaDeCartasFianzas.LlenarJScript implementation
			ibtnAgregar.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado("ddlbSituacion"));
			ibtnEliminar.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,JSVERIFICARELIMINAR);

			ibtnSesiones.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado("ddlbSituacion"));
			ibtnSesiones.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.MostrarVentana(URLSESIONES,""));
		}

		public void RegistrarJScript()
		{


		}

		public void Imprimir()
		{
			//ltlMensaje.Text = Helper.PopupImpresion(URLIMPRESION,650,700,false,false,false,true,true);
		}

		public void Exportar()
		{
		
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

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,
					Utilitario.Helper.MostrarDatosEnCajaTexto("hCodigo",dr[Enumerados.ColumnasDisposicionesDirectorio.IdDisposicion.ToString()].ToString()),
					Utilitario.Helper.MostrarDatosEnCajaTexto("hDescripcion",dr[Enumerados.ColumnasDisposicionesDirectorio.Disposicion.ToString()].ToString())
					);

				e.Item.Cells[0].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.MostrarVentana(URLDETALLE,KEYQID + Utilitario.Constantes.SIGNOIGUAL + 
					Convert.ToString(dr[Enumerados.ColumnasDisposicionesDirectorio.IdDisposicion.ToString()]) +  
					Utilitario.Constantes.SIGNOAMPERSON + Utilitario.Constantes.KEYMODOPAGINA +  Utilitario.Constantes.SIGNOIGUAL + 
					Enumerados.ModoPagina.M.ToString() +
					Utilitario.Constantes.SIGNOAMPERSON + KEYQIDTIPODISPOSICION +  Utilitario.Constantes.SIGNOIGUAL + 
					Page.Request.QueryString[KEYQIDTIPODISPOSICION].ToString()));
				e.Item.Cells[0].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				e.Item.Cells[0].Font.Underline=true;
				e.Item.Cells[0].ForeColor= System.Drawing.Color.Blue;
				e.Item.Cells[0].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN, Helper.HistorialIrAdelantePersonalizado("ddlbSituacion"));

				Helper.FiltroporSeleccionConfiguraColumna(e,grid);			
			}	
		
		}

		/// <summary>
		/// Abre la Pagina para Agregar una Cuenta Bancaria
		/// </summary>
		private void redireccionaPaginaAgregar()
		{
			Page.Response.Redirect(URLDETALLE+ Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + 
				Enumerados.ModoPagina.N.ToString() + 
				Utilitario.Constantes.SIGNOAMPERSON + KEYQIDTIPODISPOSICION +  Utilitario.Constantes.SIGNOIGUAL + 
				Page.Request.QueryString[KEYQIDTIPODISPOSICION].ToString());
		}

		private void imgAgregar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.redireccionaPaginaAgregar();
		}

		private void imgImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Imprimir();
		}

	
		private void imgExportarExcel_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Exportar();
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

		private void ibtnEliminarFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();																
		}

		private void ibtnGestiones_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if(hCodigo.Value.Length==0)
			{
				ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO));
			}
			else
			{
				if(Convert.ToInt32(Page.Request.QueryString[KEYQIDTIPODISPOSICION]) == PERMANENTES)
				{
					Page.Response.Redirect(URLGESTIONES + KEYQIDACUERDO +  Utilitario.Constantes.SIGNOIGUAL + 
						hCodigo.Value +
						Utilitario.Constantes.SIGNOAMPERSON + KEYQDESCRIPCION + Utilitario.Constantes.SIGNOIGUAL + 
						hDescripcion.Value.ToString() +
						Utilitario.Constantes.SIGNOAMPERSON + KEYQIDTIPOINFORME + Utilitario.Constantes.SIGNOIGUAL + 
						Convert.ToInt32(Enumerados.TiposDeInforme.AcuerdoPermanentes));
				}
				else
				{
					Page.Response.Redirect(URLGESTIONES + KEYQIDACUERDO +  Utilitario.Constantes.SIGNOIGUAL + 
						hCodigo.Value +
						Utilitario.Constantes.SIGNOAMPERSON + KEYQDESCRIPCION + Utilitario.Constantes.SIGNOIGUAL + 
						hDescripcion.Value.ToString() +
						Utilitario.Constantes.SIGNOAMPERSON + KEYQIDTIPOINFORME + Utilitario.Constantes.SIGNOIGUAL + 
						Convert.ToInt32(Enumerados.TiposDeInforme.DisposicionesGenerales));
				}
			}		
		}

		private void ddlbSituacion_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO),Utilitario.Constantes.INDICEPAGINADEFAULT);		
		}	
	}
}

