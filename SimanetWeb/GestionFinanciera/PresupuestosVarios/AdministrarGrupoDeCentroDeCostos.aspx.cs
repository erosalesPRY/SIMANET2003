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
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using SIMA.Controladoras.General;
using SIMA.Controladoras.GestionFinanciera;

namespace SIMA.SimaNetWeb.GestionFinanciera
{
	/// <summary>
	/// Summary description for AdministrarGrupoDeCentroDeCostos.
	/// </summary>
	public class AdministrarGrupoDeCentroDeCostos : System.Web.UI.Page,IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminar;
		protected projDataGridWeb.DataGridWeb dgGrupoCentroCostos;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.WebControls.ImageButton ibtnAgregar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminaFiltro;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hNombre;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hNroGrupoCC;
			protected System.Web.UI.WebControls.ImageButton ibtnCentroCosto;
		#endregion

		#region Constantes

		//FOOTER
		const string TEXTOFOOTERTOTAL = "Total : ";
		const int    POSICIONFOOTERTOTAL = 1;
		
		//Ordenamiento
		const string COLORDENAMIENTO = "nombre";

		//Paginas
		const string URLPRINCIPAL= "../Default.aspx";
		const string URLDETALLE = "DetalleAdministrarGrupoDeCentroDeCostos.aspx?";
		const string URLADMINISTRACION = "AdministrarGrupoDeCentroDeCostos.aspx";
		const string URLADMINISTRACIONCENTROCOSTO = "AdministrarCentroDeCostos.aspx?";
				
		//Key Session y QueryString
		const string KEYQID = "Id";
		const string KEYQNOMBRE = "Nombre";
		const string KEYQIDGRUPOCC = "IdGrupoCC";
		const string KEYQNROGRUPOCC = "NroGrupoCC";
	
		
		//JScript
		string JSVERIFICARELIMINAR = "return verificarEliminarRb('hCodigo','" + Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO)+"','"+Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJEPREGUNTAELIMINACIONREGISTRO)+"');";
		string JSVERIFICARSELECCION = "return verificarSeleccionRb('hCodigo','" + Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO) + "');";		
		//Otros
		const string GRILLAVACIA ="No existe ningun Grupo de Centro de Costos";
	
		
		
		const int PosicionFooterTotal = 2;
		
		
		#endregion Constantes
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					this.LlenarJScript();
				
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Documentaria",this.ToString(),"Se consultó Registro de Grupo de Centro de Costos.",Enumerados.NivelesErrorLog.I.ToString()));
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
			this.ibtnEliminaFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminaFiltro_Click);
			this.ibtnAgregar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAgregar_Click);
			this.ibtnEliminar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminar_Click);
			this.ibtnCentroCosto.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnCentroCosto_Click);
			this.dgGrupoCentroCostos.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.dgGrupoCentroCostos_SortCommand);
			this.dgGrupoCentroCostos.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgGrupoCentroCostos_PageIndexChanged);
			this.dgGrupoCentroCostos.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgGrupoCentroCostos_ItemDataBound);
			this.dgGrupoCentroCostos.SelectedIndexChanged += new System.EventHandler(this.dgGrupoCentroCostos_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add AdministrarGrupoDeCentroDeCostos.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarGrupoDeCentroDeCostos.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			CGrupoCentroCosto oCGrupoCentroCosto = new CGrupoCentroCosto();
			DataTable dtGrupoCentroCosto = oCGrupoCentroCosto.ListarTodosGrilla(NetAccessControl.CNetAccessControl.GetIdUser());
			
			if(dtGrupoCentroCosto!=null)
			{
				DataView dwGrupoCentroCosto = dtGrupoCentroCosto.DefaultView;
				dwGrupoCentroCosto.Sort = columnaOrdenar ;
				dwGrupoCentroCosto.RowFilter = Helper.ObtenerFiltro(this);

				if(dwGrupoCentroCosto.Count> Utilitario.Constantes.ValorConstanteCero)
				{
					this.dgGrupoCentroCostos.DataSource = dwGrupoCentroCosto;
					this.dgGrupoCentroCostos.Columns[PosicionFooterTotal].FooterText = dwGrupoCentroCosto.Count.ToString();
					this.lblResultado.Visible = false;
				}
				else
				{
					this.dgGrupoCentroCostos.DataSource = null;
					lblResultado.Visible = true;
					lblResultado.Text = GRILLAVACIA;
				}
//				CImpresion oCImpresion = new CImpresion();
//				oCImpresion.GuardarDataImprimirExportar(dwDependenciaNavales.Table,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGOTITULOREPORTEDEPENDENCIANAVALES),columnaOrdenar,indicePagina);
			}
			else
			{
				this.dgGrupoCentroCostos.DataSource = dtGrupoCentroCosto;
				this.lblResultado.Visible = true;
				lblResultado.Text = GRILLAVACIA;
			}
			
			try
			{
				this.dgGrupoCentroCostos.DataBind();
			}
			catch	
			{
				this.dgGrupoCentroCostos.CurrentPageIndex = 0;
				this.dgGrupoCentroCostos.DataBind();
			}

		}

		public void LlenarCombos()
		{
			
		}

		public void LlenarDatos()
		{
			// TODO:  Add AdministrarGrupoDeCentroDeCostos.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			ibtnEliminar.Attributes.Add(Constantes.EVENTOCLICK,JSVERIFICARELIMINAR);
			this.ibtnCentroCosto.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,JSVERIFICARSELECCION);		
			
			ibtnCentroCosto.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado(Utilitario.Constantes.VACIO));
		    this.ibtnAgregar.Attributes.Add(Utilitario.Constantes.EVENTOONCHANGE,Utilitario.Constantes.POPUPDEESPERA);
			this.ibtnCentroCosto.Attributes.Add(Utilitario.Constantes.EVENTOONCHANGE,Utilitario.Constantes.POPUPDEESPERA);
		
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarGrupoDeCentroDeCostos.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministrarGrupoDeCentroDeCostos.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarGrupoDeCentroDeCostos.Exportar implementation
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
			// TODO:  Add AdministrarGrupoDeCentroDeCostos.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void ibtnFiltrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			CGrupoCentroCosto oCGrupoCentroCosto = new CGrupoCentroCosto();
			DataTable dtGrupoCentroCosto = oCGrupoCentroCosto.ListarTodosGrilla(NetAccessControl.CNetAccessControl.GetIdUser());

			ltlMensaje.Text= Utilitario.Helper.ElaborarFiltro(dtGrupoCentroCosto
				,Utilitario.Enumerados.ColumnaGrupoCentroCosto.nroGrupoCC.ToString()+";NroGrupoCC"
				,Utilitario.Enumerados.ColumnaGrupoCentroCosto.nombre.ToString()+ ";Nombre");
		}

		private void ibtnEliminaFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}

		private void ibtnAgregar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.redireccionaPaginaAgregar();
		}
		private void redireccionaPaginaAgregar()
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

		private void eliminar()
		{			
			if(hCodigo.Value.Length== Utilitario.Constantes.ValorConstanteCero)
			{
				ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO));
			}
			else
			{
				CMantenimientos oCMantenimientos = new CMantenimientos();

				if(oCMantenimientos.Eliminar(Convert.ToInt32(hCodigo.Value),CNetAccessControl.GetIdUser(),Enumerados.ClasesTAD.GrupoCentroCostoTAD.ToString())> Utilitario.Constantes.ValorConstanteCero)
				{
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Documentaria",this.ToString(),"Se eliminó el Grupo de Centro de Costo Nro. " + hCodigo.Value +"." ,Enumerados.NivelesErrorLog.I.ToString()));
					this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),Helper.ObtenerIndicePagina());
					ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJEELIMINACIONMOFICACIONOCC), URLADMINISTRACION);									
				}
			}
		}

		private void dgGrupoCentroCostos_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void dgGrupoCentroCostos_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
		
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				e.Item.Cells[Constantes.POSICIONCONTADOR].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.MostrarVentana(URLDETALLE,KEYQID + Utilitario.Constantes.SIGNOIGUAL + 
					Convert.ToString(dr[Enumerados.ColumnaGrupoCentroCosto.idGrupoCC.ToString()]) +  
					Utilitario.Constantes.SIGNOAMPERSON + Utilitario.Constantes.KEYMODOPAGINA +
					Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.M.ToString()));
	
				e.Item.Cells[Constantes.POSICIONCONTADOR].Text = Helper.ObtenerIndicedeRegistro(this.dgGrupoCentroCostos.CurrentPageIndex,this.dgGrupoCentroCostos.PageSize,e.Item.ItemIndex);
				e.Item.Cells[Constantes.POSICIONCONTADOR].ForeColor=Color.Blue;
				e.Item.Cells[Constantes.POSICIONCONTADOR].Font.Underline=true;

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,Utilitario.Helper.MostrarDatosEnCajaTexto("hCodigo",dr[Enumerados.ColumnaGrupoCentroCosto.idGrupoCC.ToString()].ToString()),
																Utilitario.Helper.MostrarDatosEnCajaTexto("hNombre",dr[Enumerados.ColumnaGrupoCentroCosto.nombre.ToString()].ToString()),
																Utilitario.Helper.MostrarDatosEnCajaTexto("hNroGrupoCC",dr[Enumerados.ColumnaGrupoCentroCosto.nroGrupoCC.ToString()].ToString()));
				
				Helper.FiltroporSeleccionConfiguraColumna(e,this.dgGrupoCentroCostos);
			}

		}

		private void dgGrupoCentroCostos_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.dgGrupoCentroCostos.CurrentPageIndex=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);
		}

		private void dgGrupoCentroCostos_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
		this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(e.SortExpression),Helper.ObtenerIndicePagina());
		}

		private void ibtnCentroCosto_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.redireccionaPaginaCentroCosto();
        }

		private void redireccionaPaginaCentroCosto()
		{
			if(this.hNombre.Value.Length==0 && this.hNombre.Value.Length == 0)
			{
				ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO));
			}
			else
			{
				Page.Response.Redirect(URLADMINISTRACIONCENTROCOSTO +
					KEYQIDGRUPOCC + Constantes.SIGNOIGUAL + this.hCodigo.Value + Constantes.SIGNOAMPERSON + 
					KEYQNOMBRE + Constantes.SIGNOIGUAL + this.hNombre.Value + Constantes.SIGNOAMPERSON +
					KEYQNROGRUPOCC + Constantes.SIGNOIGUAL + this.hNroGrupoCC.Value);
			}

		}

	}
}
