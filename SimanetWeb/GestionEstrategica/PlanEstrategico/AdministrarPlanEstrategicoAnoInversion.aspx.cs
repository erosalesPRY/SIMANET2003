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
using SIMA.Controladoras.GestionEstrategica.PlanEstrategico;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;

namespace SIMA.SimaNetWeb.GestionEstrategica.PlanEstrategico
{
	/// <summary>
	/// Summary description for AdministrarPlanEstrategicoAnoInversion.
	/// </summary>
	public class AdministrarPlanEstrategicoAnoInversion : System.Web.UI.Page, IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hDescripcionActividad;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigoActividad;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hNro;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPlanBase;
		protected System.Web.UI.WebControls.Label lblNombrePlanBase;
		protected System.Web.UI.WebControls.Label lblObjGral;
		protected System.Web.UI.WebControls.Label lblNombreObjGral;
		protected System.Web.UI.WebControls.Label lblObjEsp;
		protected System.Web.UI.WebControls.Label lblNombreObjEsp;
		protected System.Web.UI.WebControls.Label lblAccion;
		protected System.Web.UI.WebControls.Label lblNombreAccion;
		protected System.Web.UI.WebControls.Label lblActividad;
		protected System.Web.UI.WebControls.Label lblNombreActividad;
		protected System.Web.UI.WebControls.ImageButton ibtnAgregar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminar;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminaFiltro;
		protected System.Web.UI.WebControls.Label Label1;
		#endregion

		#region Constantes
		const string COLORDENAMIENTO = "IdAnoInversion";

		const int COLUMNANUMERACION = 0;
		const int COLUMNAMODIFICAR = 1;

		const string URLMODIFICAR = "DetallePlanEstrategicoAnoInversion.aspx?";

		const string TEXTOFOOTERTOTAL = "Total:";
		const string GRILLAVACIA = "No hay Datos";
		const int POSICIONFOOTERTOTAL = 1;
		const string OBJETIVOGENERAL = "OG";
		const string TITULOVERACTIVIDAD = "Ver Actividad: ";

		const string MENSAJEELIMINAR="Se elimino la actividad Nro. ";
		const string MENSAJESELECCIONAR="Tiene que seleccionar un registro";

		// new
		const string NOMBREPLANBASE  = "PLEstrNombre";
		const string NOMBREOBJGRAL   = "ObjGenNombre";
		const string NOMBREOBJESP    = "idObjEspNombre";
		const string NOMBREACCION    = "ACCION";
		const string NOMBREACTIVIDAD = "ACTIVIDAD";

		const string KEYIDOBJGRAL   = "idObjGen";
		const string KEYIDOBJESP    = "idObjEsp";
		const string KEYIDACCION    = "IdAccion";
		const string KEYIDACTIVIDAD = "IdActividad";
		const string KEYIDANOINV    = "IdAnoInversion";
		const string KEYIDGRUPOCC   = "IdGrupoCC";

		const string KEYCODOBJGRAL   = "CodObjGen";
		const string KEYCODOBJESP    = "CodObjEsp";
		const string KEYCODACCION    = "CodAccion";
		const string KEYCODACTIVIDAD = "CodActividad";


		#endregion

		#region Variables
		private string JSVERIFICARELIMINAR = "return verificarEliminarRb('hCodigo','" + Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO)+"','"+Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJEPREGUNTAELIMINACIONREGISTRO)+"');";
		#endregion
	
		private void Eliminar()
		{

			if(hCodigo.Value.Length==Utilitario.Constantes.ValorConstanteCero)
			{
				ltlMensaje.Text = Helper.MensajeAlert(MENSAJESELECCIONAR);
			}
			else
			{
				CMantenimientos oCMantenimientos = new CMantenimientos();

				if(oCMantenimientos.Eliminar(Convert.ToInt32(hCodigo.Value),CNetAccessControl.GetIdUser(),Utilitario.Enumerados.ClasesTAD.PEAnoInversionTAD.ToString())>Utilitario.Constantes.ValorConstanteCero)
				{
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Utilitario.Enumerados.NombresdeModulo.GestionEstratégica.ToString(),this.ToString(),MENSAJEELIMINAR + hCodigo.Value + Utilitario.Constantes.SIMBOLOPUNTO,Enumerados.NivelesErrorLog.I.ToString()));
					ltlMensaje.Text = Helper.MensajeAlert("Se elimino el registro");
					this.LlenarGrillaOrdenamientoPaginacion("",Helper.ObtenerIndicePagina());
				}
			}
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack )
			{
				try
				{
					//this.ConfigurarAccesoControles();
					this.LlenarJScript();
					Helper.ReiniciarSession();
					this.LlenarTitulos();
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionEstrategica",this.ToString(),"Se consulto el Modulo Gestion Estrategico.",Enumerados.NivelesErrorLog.I.ToString()));
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
					SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
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
			this.ibtnAgregar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAgregar_Click);
			this.ibtnEliminar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminar_Click);
			this.ibtnFiltrar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnFiltrar_Click);
			this.ibtnEliminaFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminaFiltro_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add AdministrarPlanEstrategicoAnoInversion.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarPlanEstrategicoAnoInversion.LlenarGrillaOrdenamiento implementation
		}

		public DataTable ObtenerDatos()
		{
			int id = Convert.ToInt32(Page.Request.QueryString[KEYIDACTIVIDAD]);
			CPEAnoInversion oCPEAnoInversion = new CPEAnoInversion();
			return oCPEAnoInversion.ListarPEAnoInversion(id);

		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dt = this.ObtenerDatos();
			
			if(dt!=null)
			{
				DataView dw = dt.DefaultView;
				grid.DataSource = dw;
				dw.RowFilter = Helper.ObtenerFiltro();

				if (dw.Count == 0)
				{
					grid.DataSource = null; 
					lblResultado.Text = GRILLAVACIA;
					lblResultado.Visible = true;
				}
				else
				{
					grid.DataSource = dw;
					grid.PageSize = Helper.ObtenerCantidadRegistrosPorGrilla();
					grid.Columns[0].FooterText = TEXTOFOOTERTOTAL;
					grid.Columns[POSICIONFOOTERTOTAL].FooterText = dw.Count.ToString();
				}
			}
			else
			{
				grid.DataSource = dt;
				lblResultado.Text = GRILLAVACIA;
				lblResultado.Visible = true;
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
			// TODO:  Add AdministrarPlanEstrategicoAnoInversion.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add AdministrarPlanEstrategicoAnoInversion.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			ibtnEliminar.Attributes.Add(Utilitario.Constantes.EVENTOCLICK ,JSVERIFICARELIMINAR);
			ibtnAgregar.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarPlanEstrategicoAnoInversion.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministrarPlanEstrategicoAnoInversion.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarPlanEstrategicoAnoInversion.Exportar implementation
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
			// TODO:  Add AdministrarPlanEstrategicoAnoInversion.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				
				e.Item.Cells[0].Font.Underline=true;
				e.Item.Cells[0].ToolTip = "Modificar Año de Inversión:";
				e.Item.Cells[0].ForeColor= System.Drawing.Color.Blue;
				e.Item.Cells[0].Text =  Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);


				e.Item.Cells[COLUMNANUMERACION].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.HISTORIALADELANTE + ";" +
					Helper.MostrarVentana(URLMODIFICAR,
					NOMBREPLANBASE + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[NOMBREPLANBASE] + Utilitario.Constantes.SIGNOAMPERSON 
					+ NOMBREOBJGRAL  + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[NOMBREOBJGRAL] + Utilitario.Constantes.SIGNOAMPERSON
					+ NOMBREOBJESP + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[NOMBREOBJESP] + Utilitario.Constantes.SIGNOAMPERSON 
					+ NOMBREACCION + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[NOMBREACCION] + Utilitario.Constantes.SIGNOAMPERSON 
					+ NOMBREACTIVIDAD + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[NOMBREACTIVIDAD] + Utilitario.Constantes.SIGNOAMPERSON 
					+ KEYIDOBJGRAL + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYIDOBJGRAL] + Utilitario.Constantes.SIGNOAMPERSON
					+ KEYIDOBJESP + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYIDOBJESP] +  Utilitario.Constantes.SIGNOAMPERSON  
					+ KEYIDACCION + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYIDACCION] + Utilitario.Constantes.SIGNOAMPERSON  
					+ KEYIDACTIVIDAD + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt32(dr["IDACTIVIDAD"]) + Utilitario.Constantes.SIGNOAMPERSON  
					+ KEYIDANOINV + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt32(dr["IDANOINVERSION"]) + Utilitario.Constantes.SIGNOAMPERSON  
					+ KEYIDGRUPOCC + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYIDGRUPOCC] + Utilitario.Constantes.SIGNOAMPERSON  
					+ KEYCODOBJGRAL + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYCODOBJGRAL] + Utilitario.Constantes.SIGNOAMPERSON 				
					+ KEYCODOBJESP + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYCODOBJESP] + Utilitario.Constantes.SIGNOAMPERSON 
					+ KEYCODACCION + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYCODACCION] + Utilitario.Constantes.SIGNOAMPERSON 
					+ KEYCODACTIVIDAD + Utilitario.Constantes.SIGNOIGUAL +  Page.Request.QueryString[KEYCODACTIVIDAD] + Utilitario.Constantes.SIGNOAMPERSON 
					+ Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.M.ToString() 
					));										

				e.Item.Cells[COLUMNANUMERACION].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e
					,Utilitario.Helper.MostrarDatosEnCajaTexto("hCodigo",dr["IDANOINVERSION"].ToString()));

				Helper.FiltroporSeleccionConfiguraColumna(e,grid,true,"txtBuscar");

			}
		}

		private void ibtnAgregar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.redireccionaPaginaAgregar();
		}

		private void redireccionaPaginaAgregar()
		{
			Page.Response.Redirect(URLMODIFICAR + 
				Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.N.ToString() + Utilitario.Constantes.SIGNOAMPERSON
				+ NOMBREPLANBASE + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[NOMBREPLANBASE]+ Utilitario.Constantes.SIGNOAMPERSON
				+ NOMBREOBJGRAL + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[NOMBREOBJGRAL] + Utilitario.Constantes.SIGNOAMPERSON 
				+ NOMBREOBJESP + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[NOMBREOBJESP] + Utilitario.Constantes.SIGNOAMPERSON
				+ NOMBREACCION + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[NOMBREACCION] + Utilitario.Constantes.SIGNOAMPERSON 	
				+ NOMBREACTIVIDAD + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[NOMBREACTIVIDAD] + Utilitario.Constantes.SIGNOAMPERSON 	
				+ KEYIDOBJGRAL + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDOBJGRAL] +	Utilitario.Constantes.SIGNOAMPERSON 
				+ KEYIDOBJESP + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYIDOBJESP] + Utilitario.Constantes.SIGNOAMPERSON 
				+ KEYIDACCION + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYIDACCION] + Utilitario.Constantes.SIGNOAMPERSON 
				+ KEYIDACTIVIDAD + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYIDACTIVIDAD] + Utilitario.Constantes.SIGNOAMPERSON 
				+ KEYIDGRUPOCC + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYIDGRUPOCC] + Utilitario.Constantes.SIGNOAMPERSON 
				+ KEYCODOBJGRAL + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYCODOBJGRAL] + Utilitario.Constantes.SIGNOAMPERSON 				
				+ KEYCODOBJESP + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYCODOBJESP] + Utilitario.Constantes.SIGNOAMPERSON 				
				+ KEYCODACCION + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYCODACCION] + Utilitario.Constantes.SIGNOAMPERSON 	
				+ KEYCODACTIVIDAD + Utilitario.Constantes.SIGNOIGUAL +  Page.Request.QueryString[KEYCODACTIVIDAD]
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

		private void ibtnEliminar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				if(Page.IsValid)
				{
					this.Eliminar();
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

		private void LlenarTitulos()
		{
			this.lblObjGral.Text   = Page.Request.QueryString[KEYCODOBJGRAL];
			this.lblObjEsp.Text    = Page.Request.QueryString[KEYCODOBJESP];
			this.lblAccion.Text    = Page.Request.QueryString[KEYCODACCION];
			this.lblActividad.Text = Page.Request.QueryString[KEYCODACTIVIDAD];

			this.lblNombrePlanBase.Text  = Page.Request.QueryString[NOMBREPLANBASE];
			this.lblNombreObjGral.Text   = Page.Request.QueryString[NOMBREOBJGRAL];
			this.lblNombreObjEsp.Text    = Page.Request.QueryString[NOMBREOBJESP];
			this.lblNombreAccion.Text    = Page.Request.QueryString[NOMBREACCION];
			this.lblNombreActividad.Text = Page.Request.QueryString[NOMBREACTIVIDAD];
		}

		private void ibtnFiltrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			ltlMensaje.Text = Helper.ElaborarFiltro(this.ObtenerDatos()
				,"Inversion;Inversionº"
				,"Ano;Año");
		}

		private void ibtnEliminaFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}

	}
}
