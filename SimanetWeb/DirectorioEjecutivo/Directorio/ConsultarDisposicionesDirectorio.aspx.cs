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
	public class ConsultarDisposicionesDirectorio : System.Web.UI.Page,IPaginaBase
	{
		#region Controles

		protected System.Web.UI.WebControls.Label lblPagina;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblPosicionRegistro;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminarFiltro;
		#endregion Controles
	

		#region Constantes
	
		//Ordenamiento
		const string COLORDENAMIENTO = "IdDisposicion";

		//Nombres de Controles
		const string CONTROLINK = "hlkId";
		const string CONTROCHECKBOX = "cbxEliminar";
	
		//Paginas
		const string URLDETALLE = "ConsultarDetalleDisposicionesDirectorio.aspx?";
		const string URLSESIONES = "ConsultaSesionDirectorio.aspx";
		//Key Session y QueryString
	
		const string KEYQIDSESIONDIRECTORIO = "IdSesionDirectorio";
		const string KEYQID = "Id";
		const string KEYQIDTIPOINFORME = "IdTipoInforme";
		const string KEYQIDTIPODISPOSICION = "IdTipoDisposicion";
		const string KEYQIDCENTROOPERATIVO= "IdCentroOperativo";
		//JScript
		string JSVERIFICARELIMINAR = "return verificarEliminarRb('hCodigo','" + Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO)+"','"+Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJEPREGUNTAELIMINACIONREGISTRO)+"');";
		
		//Otros
		const string GRILLAVACIA ="No existe ninguna Disposición del Directorio";  
		const string ACUERDOS ="Acuerdos Permanentes";  
		const string ASUNTO ="ASUNTO";  

		const string PERMANENTES = "0";
		protected System.Web.UI.WebControls.DropDownList ddlbSituacion;
		protected System.Web.UI.WebControls.Label lblSituacion;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected projDataGridWeb.DataGridWeb gridGenerales;
		protected System.Web.UI.WebControls.Label lblResultado;
		const string GENERALES = "1";

		#endregion Constantes

		#region Variables
		#endregion Variables
	
	
		/// <summary>
		/// Elimina los Informes seleccionados
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
					this.LlenarDatos();				
					this.LlenarCombos();

					Helper.ReiniciarSession();

					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Secretaria - Directorio",this.ToString(),"Se consultó los Informes de Sesión de Directorio.",Enumerados.NivelesErrorLog.I.ToString()));
				

					this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO),Utilitario.Constantes.INDICEPAGINADEFAULT);
					this.LlenarGrillaOrdenamientoPaginacionGenerales(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO),Utilitario.Constantes.INDICEPAGINADEFAULT);
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

		private void AsignarSession()
		{
			if (Page.Request.QueryString[KEYQIDSESIONDIRECTORIO] != null) 
			{
				if (Page.Request.QueryString[KEYQIDSESIONDIRECTORIO].ToString() != HttpContext.Current.Session[Utilitario.Constantes.KEYSIDSESIONDIRECTORIO].ToString())
				{
					Helper.GeneraSessionParaDirectorio(Page.Request.QueryString[KEYQIDSESIONDIRECTORIO].ToString());
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
			this.ibtnEliminarFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminarFiltro_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.ddlbSituacion.SelectedIndexChanged += new System.EventHandler(this.ddlbSituacion_SelectedIndexChanged);
			this.gridGenerales.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.gridGenerales_SortCommand);
			this.gridGenerales.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.gridGenerales_PageIndexChanged);
			this.gridGenerales.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.gridGenerales_ItemDataBound);
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

		public void LlenarGrillaOrdenamientoPaginacionGenerales(string columnaOrdenar,int indicePagina)
		{
			CDisposicionesDirectorio oCDisposicionesDirectorio=  new CDisposicionesDirectorio();
			DataTable dtDisposicionesDirectorio;

			dtDisposicionesDirectorio =  oCDisposicionesDirectorio.ConsultarDisposicionesPorSituacion
				(
				Convert.ToInt32(Enumerados.TablasTabla.SecretariaDirectorioTablaTipoDisposicion),
				1,
				Convert.ToInt32(ddlbSituacion.SelectedValue)
				);

			if(dtDisposicionesDirectorio!=null)
			{
				DataView dwDisposicionesDirectorio = dtDisposicionesDirectorio.DefaultView;
				dwDisposicionesDirectorio.Sort = columnaOrdenar ;
				dwDisposicionesDirectorio.RowFilter= Utilitario.Helper.ObtenerFiltro();
				gridGenerales.DataSource = dwDisposicionesDirectorio;
			
				gridGenerales.Columns[0].FooterText = Utilitario.Constantes.TEXTOFOOTERTOTAL;
				gridGenerales.Columns[Utilitario.Constantes.POSICIONTOTAL].FooterText = dwDisposicionesDirectorio.Count.ToString();
			}
			else
			{
				gridGenerales.DataSource = dtDisposicionesDirectorio;
			}

			try
			{
				gridGenerales.DataBind();
			}
			catch	
			{
				gridGenerales.CurrentPageIndex = 0;
				gridGenerales.DataBind();
			}
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
		{
			CDisposicionesDirectorio oCDisposicionesDirectorio=  new CDisposicionesDirectorio();
			DataTable dtDisposicionesDirectorio;

			dtDisposicionesDirectorio =  oCDisposicionesDirectorio.ConsultarDisposicionesPorSituacion
				(
				Convert.ToInt32(Enumerados.TablasTabla.SecretariaDirectorioTablaTipoDisposicion),
				0,
				Utilitario.Constantes.POSICIONINDEXUNO
				);

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

		private void llenarSituacion()
		{
			CTablaTablas oCTablaTablas =  new CTablaTablas();
			ddlbSituacion.DataSource = oCTablaTablas.ListarTodosComboDirectorio(Convert.ToInt32(Enumerados.TablasTabla.SecretariaDirectorioTablaSituacionPedidos));
			ddlbSituacion.DataValueField=Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbSituacion.DataTextField=Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbSituacion.DataBind();
		}

		public void LlenarCombos()
		{
			this.llenarSituacion();
		}

		public void LlenarDatos()
		{
			this.AsignarSession();

			lblPagina.Text = ACUERDOS;
			/*lblSituacion.Visible= false;
			ddlbSituacion.Visible=false;*/
			grid.Columns[3].Visible = false;

			//grid.Columns[2].Visible = false;
			gridGenerales.Columns[4].HeaderText = ASUNTO;
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultaDeCartasFianzas.LlenarJScript implementation
			/*ibtnSesiones.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN, Utilitario.Constantes.HISTORIALADELANTE);
			ibtnSesiones.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.MostrarVentana(URLSESIONES,""));*/
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
					Utilitario.Helper.MostrarDatosEnCajaTexto("hCodigo",dr[Enumerados.ColumnasDisposicionesDirectorio.IdDisposicion.ToString()].ToString()));

				e.Item.Cells[0].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);

				e.Item.Cells[4].Text = Convert.ToString(dr[Enumerados.ColumnasDisposicionesDirectorio.Disposicion.ToString()]).ToUpper();

				ImageButton img=(ImageButton)e.Item.Cells[5].FindControl("ibtnDisposicion");
				img.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.MostrarVentaModalTextoHTML("",
					Convert.ToString(dr[Enumerados.ColumnasDisposicionesDirectorio.ObservacionDisposicion.ToString()]),500,400,0,400));

				Helper.FiltroporSeleccionConfiguraColumna(e,grid);			
			}		
		}

		/// <summary>
		/// Abre la Pagina para Agregar una Cuenta Bancaria
		/// </summary>
		private void redireccionaPaginaAgregar()
		{
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

		private void ibtnEliminarFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();																
		}

		private void ddlbSituacion_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacionGenerales(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO),Utilitario.Constantes.INDICEPAGINADEFAULT);				
		}

		private void gridGenerales_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,
					Utilitario.Helper.MostrarDatosEnCajaTexto("hCodigo",dr[Enumerados.ColumnasDisposicionesDirectorio.IdDisposicion.ToString()].ToString()));

				e.Item.Cells[0].Text = Helper.ObtenerIndicedeRegistro(gridGenerales.CurrentPageIndex,gridGenerales.PageSize,e.Item.ItemIndex);
				e.Item.Cells[4].Text = Convert.ToString(dr[Enumerados.ColumnasDisposicionesDirectorio.Disposicion.ToString()]).ToUpper();

				ImageButton img=(ImageButton)e.Item.Cells[5].FindControl("ibtnDisposicion");
				img.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.MostrarVentaModalTextoHTML("",
					Convert.ToString(dr[Enumerados.ColumnasDisposicionesDirectorio.ObservacionDisposicion.ToString()]),500,400,0,400));

				Helper.FiltroporSeleccionConfiguraColumna(e,gridGenerales);			
			}			
		}

		private void gridGenerales_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			gridGenerales.CurrentPageIndex=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacionGenerales(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);		
		}

		private void gridGenerales_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacionGenerales(Helper.GenerarExpresionOrdenamiento(e.SortExpression),Helper.ObtenerIndicePagina());		
		}	
	}
}

