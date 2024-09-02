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
using SIMA.Controladoras.GestionEstrategica;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;

namespace SIMA.SimaNetWeb.DirectorioEjecutivo.PlanGestion
{
	public class AdministrarAccion : System.Web.UI.Page, IPaginaBase
	{
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

		private void LlenarTitulosPlanDirector()
		{
			this.lblProceso.Text = Convert.ToString(Page.Request.QueryString[Utilitario.Enumerados.ColumnasProceso.CodigoProceso.ToString()]).ToUpper();
			this.lblNombreProceso.Text = Convert.ToString(Page.Request.QueryString[Utilitario.Enumerados.ColumnasProceso.NombreProceso.ToString()]).ToUpper();
			this.lblSubProceso.Text = Convert.ToString(Page.Request.QueryString[Utilitario.Enumerados.ColumnasSubProceso.CodigoSubproceso.ToString()]).ToUpper();
			this.lblNombreSubProceso.Text = Convert.ToString(Page.Request.QueryString[Utilitario.Enumerados.ColumnasSubProceso.Descripcion.ToString()]).ToUpper();
			this.lblOEspecifico.Text = Convert.ToString(Page.Request.QueryString[Utilitario.Enumerados.ColumnasObjetivosEspecificos.CODIGOOESPECIFICOS.ToString()]).ToUpper();
			this.lblNombreOEspecifico.Text = Convert.ToString(Page.Request.QueryString[Utilitario.Enumerados.ColumnasObjetivosEspecificos.NOMBREOESPECIFICOS.ToString()]).ToUpper();
		}

		private void LlenarTitulosPlanEstrategico()
		{

			this.lblSubProceso.Text = "OG " + Page.Request.QueryString[KEYCODIGOGENERADO].Split('.').GetValue(0); //OBJETIVOGENERAL + Page.Request.QueryString[KEYQIDOGENERAL].ToUpper();
			this.lblNombreSubProceso.Text = Page.Request.QueryString[KEYOGENERALTEXTO].ToUpper();
			this.lblOEspecifico.Text = "OE " + Page.Request.QueryString[KEYCODIGOGENERADO];
			this.lblNombreOEspecifico.Text = Page.Request.QueryString[NOMBREOE].ToUpper();
		}

		public void LlenarGrillaOrdenamientoPaginacionPlanDirector(string columnaOrdenar,int indicePagina)
		{
			int idAccion = Convert.ToInt32(Page.Request.QueryString[Utilitario.Enumerados.ColumnasObjetivosEspecificos.IDOESPECIFICOS.ToString()]);

			CPlanGestion oCPlanGestion =  new CPlanGestion();
			DataTable dtAccion =  oCPlanGestion.ListarAccionPlanGestion(idAccion);
			
			if(dtAccion!=null)
			{
				DataView dwAccion = dtAccion.DefaultView;
				dwAccion.RowFilter = Helper.ObtenerFiltro(this);

				if(dwAccion.Count>0)
				{
					grid.DataSource = dwAccion;
					grid.Columns[PosicionFooterTotal].FooterText = dwAccion.Count.ToString();
					this.lblResultado.Visible = false;
				}
				else
				{
					grid.DataSource = null;
					lblResultado.Visible = true;
					lblResultado.Text = GRILLAVACIA;
				}
			}
			else
			{
				grid.DataSource = dtAccion;
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

		public void LlenarGrillaOrdenamientoPaginacionPlanEstrategico(string columnaOrdenar,int indicePagina)
		{
			int idAccion = Convert.ToInt32(Page.Request.Params[Utilitario.Enumerados.ColumnasObjetivosEspecificos.IDOESPECIFICOS.ToString()]);

			CPlanGestion oCPlanGestion =  new CPlanGestion();
			DataTable dtAccion =  oCPlanGestion.ListarAccionPlanEstrategico(idAccion,Convert.ToInt32(Page.Request.QueryString[KEYQFILTRO]));
			
			if(dtAccion!=null)
			{
				DataView dwAccion = dtAccion.DefaultView;
				dwAccion.RowFilter = Helper.ObtenerFiltro(this);

				if(dwAccion.Count>0)
				{
					grid.DataSource = dwAccion;
					grid.PageSize = Helper.ObtenerCantidadRegistrosPorGrilla();
					grid.Columns[PosicionFooterTotal].FooterText = dwAccion.Count.ToString();
					this.lblResultado.Visible = false;
				}
				else
				{
					grid.DataSource = null;
					lblResultado.Visible = true;
					lblResultado.Text = GRILLAVACIA;
				}
			}
			else
			{
				grid.DataSource = dtAccion;
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
		}

		public void LlenarDatos()
		{
		}

		public void RegistrarJScript()
		{

		}

		public void Imprimir()
		{
		}

		public void Exportar()
		{
			
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


		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
		}

		public void LlenarJScript()
		{
			this.ibtnAgregar.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			this.ibtnEliminar.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,JSVERIFICARELIMINAR);
		}

		#endregion
		#region Constantes
		
		//Ordenamiento
		const string COLORDENAMIENTO = "IdOEspecificos";
		
		//Paginas
		const string URLIMPRESION = "PopupImpresionAdministracionArticulosRelacionesPublicas.aspx";
		const string URLMODIFICAR = "DetalleAccion.aspx?";
		const string URLACTIVIDAD = "AdministrarActividad.aspx?";
		const int COLUMNANUMERACION = 0;
		const int COLUMNAMODIFICAR = 1;
				
		//Key Session y QueryString
		
		const string KEYQIDOGENERAL = "IDOGENERALES";
		const string KEYOGENERALTEXTO = "DESCRIPCION";

		const string KEYQFILTRO = "IDVISIBILIDAD";
		const string KEYQID = "Id";
		const string KEYIDPROCESO = "IdProceso";
		const string KEYIDSUBPROCESO = "IdSubProceso";
		const string KEYIDOESPECIFICO = "IdOEspecificos";
		const string KEYIDACCION = "IdAccion";
		const string KEYIDOGENERAL = "IdOGenerales";
		const string DESCRIPCIONOGENERAL = "DESCRIPCION";
		const string CODIGOPROCESO = "CodigoProceso";
		const string NOMBREPROCESO = "NombreProceso";
		const string CODIGOSUBPROCESO = "CodigoSubproceso";
		const string NOMBRESUBPROCESO = "Descripcion";
		const string CODIGOOE = "CodigoOEspecificos";
		const string NOMBREOE = "NombreOEspecificos";
		const string CODIGOACCION = "CodigoAccion";
		const string DESCRIPCIONACCION = "DescripcionAccion";
		const string PE = "PlanEstrategico";
		const string KEYCODIGOGENERADO="KEYCODIGOGENERADO";

		//Otros
		const string MENSAJEELIMINAR="Se elimino la accion Nro. ";
		const string MENSAJESELECCIONAR="Tiene que seleccionar un registro";
		const string GRILLAVACIA ="No existe ninguna Acción asignada.";
		const string TEXTOTITULOPLANESTRATEGICO = "ADMINISTRACION DE ACCIONES DEL PLAN ESTRATEGICO";
		const int PosicionFooterTotal = 1;
		const string OBJETIVOGENERAL = "OG";
		protected System.Web.UI.WebControls.Label lblProceso;
		protected System.Web.UI.WebControls.Label lblNombreProceso;
		protected System.Web.UI.WebControls.Label lblSubProceso;
		protected System.Web.UI.WebControls.Label lblNombreSubProceso;
		protected System.Web.UI.WebControls.Label lblOEspecifico;
		protected System.Web.UI.WebControls.Label lblNombreOEspecifico;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminar;
		const string TITULOACERCADE = "Acerca de: ";

		#endregion Constantes
		#region Variables
		private string JSVERIFICARELIMINAR = "return verificarEliminarRb('hCodigo','" + Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO)+"','"+Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJEPREGUNTAELIMINACIONREGISTRO)+"');";
		#endregion Variables
		#region Controles
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.ImageButton Imagebutton1;
		protected System.Web.UI.WebControls.ImageButton ibtnAgregar;

		#endregion Controles
		#region Eventos
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

		private void Eliminar()
		{
			if(hCodigo.Value.Length==Utilitario.Constantes.ValorConstanteCero)
			{
				ltlMensaje.Text = Helper.MensajeAlert(MENSAJESELECCIONAR);
			}
			else
			{
				CMantenimientos oCMantenimientos = new CMantenimientos();

				if(oCMantenimientos.Eliminar(Convert.ToInt32(hCodigo.Value),CNetAccessControl.GetIdUser(),Utilitario.Enumerados.ClasesTAD.AccionTAD.ToString())>Utilitario.Constantes.ValorConstanteCero)
				{
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Utilitario.Enumerados.NombresdeModulo.GestionEstratégica.ToString(),this.ToString(),MENSAJEELIMINAR + hCodigo.Value + Utilitario.Constantes.SIMBOLOPUNTO,Enumerados.NivelesErrorLog.I.ToString()));
					ltlMensaje.Text = Helper.MensajeAlert("Se elimino el registro");
					VerificarOrigen();
				}
			}
		}
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.LlenarJScript();
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se consultaron los Articulos destinados a Relaciones Publicas.",Enumerados.NivelesErrorLog.I.ToString()));
					VerificarOrigen();
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

		private void VerificarOrigen()
		{
			int origen = Convert.ToInt32(Page.Request.QueryString[Utilitario.Enumerados.OpcionModuloGestionEstrategica.PlanEstrategico.ToString()]);

			if(origen != Convert.ToInt32(Utilitario.Enumerados.OpcionModuloGestionEstrategica.PlanEstrategico))
			{	
				//Plan Director
				this.LlenarTitulosPlanDirector();
				this.LlenarGrillaOrdenamientoPaginacionPlanDirector(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO),Utilitario.Constantes.INDICEPAGINADEFAULT);
			}
			else
			{
				//Plan Estrategico
				this.lblTitulo.Text = TEXTOTITULOPLANESTRATEGICO;
				this.LlenarTitulosPlanEstrategico();
				this.LlenarGrillaOrdenamientoPaginacionPlanEstrategico(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO),Utilitario.Constantes.INDICEPAGINADEFAULT);
			}
		}

		private void redireccionaPaginaAgregar()
		{
			int origen = Convert.ToInt32(Page.Request.QueryString[Utilitario.Enumerados.OpcionModuloGestionEstrategica.PlanEstrategico.ToString()]);

			if(origen != Convert.ToInt32(Utilitario.Enumerados.OpcionModuloGestionEstrategica.PlanEstrategico))
			{	
				#region Plan Director
				Page.Response.Redirect(URLMODIFICAR + 
					Utilitario.Constantes.KEYMODOPAGINA + 
					Utilitario.Constantes.SIGNOIGUAL + 
					Enumerados.ModoPagina.N.ToString() +
					Utilitario.Constantes.SIGNOAMPERSON + 
					//idProceso
					KEYIDPROCESO +
					Utilitario.Constantes.SIGNOIGUAL + 
					Page.Request.QueryString[Utilitario.Enumerados.ColumnasProceso.IdProceso.ToString()] +
					Utilitario.Constantes.SIGNOAMPERSON + 
					//idSubProceso
					KEYIDSUBPROCESO + 
					Utilitario.Constantes.SIGNOIGUAL + 
					Page.Request.QueryString[Utilitario.Enumerados.ColumnasSubProceso.IdSubProceso.ToString()] +
					Utilitario.Constantes.SIGNOAMPERSON + 
					KEYIDOESPECIFICO +
					Utilitario.Constantes.SIGNOIGUAL + 
					Page.Request.QueryString[Utilitario.Enumerados.ColumnasObjetivosEspecificos.IDOESPECIFICOS.ToString()] +
					Utilitario.Constantes.SIGNOAMPERSON + 
					CODIGOPROCESO +
					Utilitario.Constantes.SIGNOIGUAL +
					Page.Request.QueryString[Utilitario.Enumerados.ColumnasProceso.CodigoProceso.ToString()] +
					Utilitario.Constantes.SIGNOAMPERSON +
					//Nombre Proceso
					NOMBREPROCESO +
					Utilitario.Constantes.SIGNOIGUAL +
					Page.Request.QueryString[Utilitario.Enumerados.ColumnasProceso.NombreProceso.ToString()] +
					Utilitario.Constantes.SIGNOAMPERSON +
					//Codigo SubProceso
					CODIGOSUBPROCESO +
					Utilitario.Constantes.SIGNOIGUAL +
					Page.Request.QueryString[Utilitario.Enumerados.ColumnasSubProceso.CodigoSubproceso.ToString()] +
					Utilitario.Constantes.SIGNOAMPERSON +
					//Nombre SubProces
					NOMBRESUBPROCESO +
					Utilitario.Constantes.SIGNOIGUAL +
					Page.Request.QueryString[Utilitario.Enumerados.ColumnasSubProceso.Descripcion.ToString()] +
					Utilitario.Constantes.SIGNOAMPERSON +
					//Codigo OE
					CODIGOOE +
					Utilitario.Constantes.SIGNOIGUAL +
					Page.Request.QueryString[Utilitario.Enumerados.ColumnasObjetivosEspecificos.CODIGOOESPECIFICOS.ToString()] +
					Utilitario.Constantes.SIGNOAMPERSON +
					//Nombre OE
					NOMBREOE +
					Utilitario.Constantes.SIGNOIGUAL +
					Page.Request.QueryString[Utilitario.Enumerados.ColumnasObjetivosEspecificos.NOMBREOESPECIFICOS.ToString()]
					);
				#endregion
			}
			else
			{
				#region Plan Estrategico
				Page.Response.Redirect(URLMODIFICAR + 
					Utilitario.Constantes.KEYMODOPAGINA + 
					Utilitario.Constantes.SIGNOIGUAL + 
					Enumerados.ModoPagina.N.ToString() +
					Utilitario.Constantes.SIGNOAMPERSON + 
					KEYIDOGENERAL +
					Utilitario.Constantes.SIGNOIGUAL + 
					Page.Request.Params[Utilitario.Enumerados.ColumnasObjetivosGenerales.IDOGENERALES.ToString()] +
					Utilitario.Constantes.SIGNOAMPERSON + 
					DESCRIPCIONOGENERAL +
					Utilitario.Constantes.SIGNOIGUAL + 
					Page.Request.Params[Utilitario.Enumerados.ColumnasObjetivosGenerales.DESCRIPCION.ToString().ToUpper()] +
					Utilitario.Constantes.SIGNOAMPERSON + 
					KEYIDOESPECIFICO +
					Utilitario.Constantes.SIGNOIGUAL + 
					Page.Request.QueryString[Utilitario.Enumerados.ColumnasObjetivosEspecificos.IDOESPECIFICOS.ToString()] +
					Utilitario.Constantes.SIGNOAMPERSON + 
					//Codigo OE
					CODIGOOE +
					Utilitario.Constantes.SIGNOIGUAL +
					Page.Request.QueryString[Utilitario.Enumerados.ColumnasObjetivosEspecificos.CODIGOOESPECIFICOS.ToString()] +
					Utilitario.Constantes.SIGNOAMPERSON +
					//Nombre OE
					NOMBREOE +
					Utilitario.Constantes.SIGNOIGUAL +
					Page.Request.QueryString[Utilitario.Enumerados.ColumnasObjetivosEspecificos.NOMBREOESPECIFICOS.ToString()] +
					Utilitario.Constantes.SIGNOAMPERSON +
					PE +
					Utilitario.Constantes.SIGNOIGUAL +
					Page.Request.QueryString[Utilitario.Enumerados.OpcionModuloGestionEstrategica.PlanEstrategico.ToString()] 
					);
				#endregion
			}
			
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			int origen = Convert.ToInt32(Page.Request.QueryString[Utilitario.Enumerados.OpcionModuloGestionEstrategica.PlanEstrategico.ToString()]);

			if(origen != Convert.ToInt32(Utilitario.Enumerados.OpcionModuloGestionEstrategica.PlanEstrategico))
			{				
				grid.CurrentPageIndex=e.NewPageIndex;
				this.LlenarGrillaOrdenamientoPaginacionPlanDirector(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);
			}
			else
			{
				grid.CurrentPageIndex=e.NewPageIndex;
				this.LlenarGrillaOrdenamientoPaginacionPlanEstrategico(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);
			}
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			int origen = Convert.ToInt32(Page.Request.QueryString[Utilitario.Enumerados.OpcionModuloGestionEstrategica.PlanEstrategico.ToString()]);

			if(origen != Convert.ToInt32(Utilitario.Enumerados.OpcionModuloGestionEstrategica.PlanEstrategico))
			{				
				this.LlenarGrillaOrdenamientoPaginacionPlanDirector(Helper.GenerarExpresionOrdenamiento(e.SortExpression),Helper.ObtenerIndicePagina());
			}
			else
			{
				this.LlenarGrillaOrdenamientoPaginacionPlanEstrategico(Helper.GenerarExpresionOrdenamiento(e.SortExpression),Helper.ObtenerIndicePagina());
			}
		}

		private void ibtnAgregar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.redireccionaPaginaAgregar();
		}

	

		private void ibtnEliminarFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}
		#endregion 

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				int origen = Convert.ToInt32(Page.Request.QueryString[Utilitario.Enumerados.OpcionModuloGestionEstrategica.PlanEstrategico.ToString()]);

				if(origen != Convert.ToInt32(Utilitario.Enumerados.OpcionModuloGestionEstrategica.PlanEstrategico))
				{	
					#region Plan Director
					DataRowView drv = (DataRowView)e.Item.DataItem;
					DataRow dr = drv.Row;
					
					e.Item.Cells[COLUMNAMODIFICAR].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.HISTORIALADELANTE + ";" +
					Helper.MostrarVentana(URLMODIFICAR,
					KEYIDPROCESO +
					Utilitario.Constantes.SIGNOIGUAL + 
					Page.Request.QueryString[Utilitario.Enumerados.ColumnasProceso.IdProceso.ToString()] +
					Utilitario.Constantes.SIGNOAMPERSON + 
					//idSubProceso
					KEYIDSUBPROCESO +	
					Utilitario.Constantes.SIGNOIGUAL + 
					Page.Request.QueryString[Utilitario.Enumerados.ColumnasSubProceso.IdSubProceso.ToString()] +  
					Utilitario.Constantes.SIGNOAMPERSON + 
					//idOEspecifico
					KEYIDOESPECIFICO +
					Utilitario.Constantes.SIGNOIGUAL + 
					Page.Request.QueryString[Utilitario.Enumerados.ColumnasObjetivosEspecificos.IDOESPECIFICOS.ToString()] +  
					Utilitario.Constantes.SIGNOAMPERSON + 
					//idAccion
					KEYIDACCION +
                    Utilitario.Constantes.SIGNOIGUAL + 
					Convert.ToString(dr[Utilitario.Enumerados.ColumnasAccion.idAccion.ToString()]) +
					Utilitario.Constantes.SIGNOAMPERSON + 
					//CodigoAcceso
					CODIGOPROCESO +
					Utilitario.Constantes.SIGNOIGUAL +
					Page.Request.QueryString[Utilitario.Enumerados.ColumnasProceso.CodigoProceso.ToString()] +
					Utilitario.Constantes.SIGNOAMPERSON +
					//Nombre Proceso
					NOMBREPROCESO +
					Utilitario.Constantes.SIGNOIGUAL +
					Page.Request.QueryString[Utilitario.Enumerados.ColumnasProceso.NombreProceso.ToString()] +
					Utilitario.Constantes.SIGNOAMPERSON +
					//Codigo SubProceso
					CODIGOSUBPROCESO +
					Utilitario.Constantes.SIGNOIGUAL +
					Page.Request.QueryString[Utilitario.Enumerados.ColumnasSubProceso.CodigoSubproceso.ToString()] +
					Utilitario.Constantes.SIGNOAMPERSON +
					//Nombre SubProces
					NOMBRESUBPROCESO +
					Utilitario.Constantes.SIGNOIGUAL +
					Page.Request.QueryString[Utilitario.Enumerados.ColumnasSubProceso.Descripcion.ToString()] +
					Utilitario.Constantes.SIGNOAMPERSON +
					//Codigo OE
					CODIGOOE +
					Utilitario.Constantes.SIGNOIGUAL +
					Page.Request.QueryString[Utilitario.Enumerados.ColumnasObjetivosEspecificos.CODIGOOESPECIFICOS.ToString()] +
					Utilitario.Constantes.SIGNOAMPERSON +
					//Nombre OE
					NOMBREOE +
					Utilitario.Constantes.SIGNOIGUAL +
					Page.Request.QueryString[Utilitario.Enumerados.ColumnasObjetivosEspecificos.NOMBREOESPECIFICOS.ToString()] +
					Utilitario.Constantes.SIGNOAMPERSON +
					//ModoPagina
					Utilitario.Constantes.KEYMODOPAGINA +
					Utilitario.Constantes.SIGNOIGUAL + 
					Enumerados.ModoPagina.M.ToString()));
				
					e.Item.Cells[COLUMNAMODIFICAR].Font.Underline=true;
				e.Item.Cells[COLUMNAMODIFICAR].ToolTip = TITULOACERCADE;
				e.Item.Cells[COLUMNANUMERACION].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
	
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				Helper.FiltroporSeleccionConfiguraColumna(e,grid);
				#endregion
				}
				else
				{
				
					#region Plan Estrategico
					DataRowView drv = (DataRowView)e.Item.DataItem;
					DataRow dr = drv.Row;
					
					e.Item.Cells[0].Font.Underline=true;
					e.Item.Cells[0].ToolTip = TITULOACERCADE;
					e.Item.Cells[0].ForeColor= System.Drawing.Color.Blue;
					e.Item.Cells[0].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
						
					e.Item.Cells[1].Font.Underline=true;
					e.Item.Cells[1].ForeColor = Color.Blue;
					e.Item.Cells[1].ToolTip = TITULOACERCADE;
					e.Item.Cells[1].Text = "AC " + Page.Request.QueryString[KEYCODIGOGENERADO] + Utilitario.Constantes.SIMBOLOPUNTO + e.Item.Cells[0].Text;

					e.Item.Cells[COLUMNAMODIFICAR].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.HISTORIALADELANTE + ";" +
					Helper.MostrarVentana(URLMODIFICAR,
					KEYQIDOGENERAL + 
					Utilitario.Constantes.SIGNOIGUAL + 
					Page.Request.QueryString[KEYQIDOGENERAL] +
					Utilitario.Constantes.SIGNOAMPERSON + 
					KEYOGENERALTEXTO + 
					Utilitario.Constantes.SIGNOIGUAL +
					Page.Request.QueryString[KEYOGENERALTEXTO] +
					Utilitario.Constantes.SIGNOAMPERSON + 
					KEYIDOESPECIFICO +
					Utilitario.Constantes.SIGNOIGUAL + 
					Page.Request.QueryString[KEYIDOESPECIFICO] +  
					Utilitario.Constantes.SIGNOAMPERSON + 
					NOMBREOE +
					Utilitario.Constantes.SIGNOIGUAL +
					Page.Request.QueryString[NOMBREOE] +
					Utilitario.Constantes.SIGNOAMPERSON +
					KEYIDACCION +
					Utilitario.Constantes.SIGNOIGUAL + 
					Convert.ToString(dr[Utilitario.Enumerados.ColumnasAccion.idAccion.ToString()]) +
					Utilitario.Constantes.SIGNOAMPERSON + 
					CODIGOOE +
					Utilitario.Constantes.SIGNOIGUAL +
					Page.Request.QueryString[CODIGOOE] +
					Utilitario.Constantes.SIGNOAMPERSON +
					PE +
					Utilitario.Constantes.SIGNOIGUAL +
					Page.Request.QueryString[PE] +
					Utilitario.Constantes.SIGNOAMPERSON + 
					KEYQFILTRO  +
					Utilitario.Constantes.SIGNOIGUAL + 
					Page.Request.QueryString[KEYQFILTRO] +
					Utilitario.Constantes.SIGNOAMPERSON +
					Utilitario.Constantes.KEYMODOPAGINA +
					Utilitario.Constantes.SIGNOIGUAL + 
					Enumerados.ModoPagina.M.ToString()));
			
					e.Item.Cells[COLUMNANUMERACION].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.HISTORIALADELANTE + ";" +
						Helper.MostrarVentana(URLACTIVIDAD,
						KEYQIDOGENERAL + 
						Utilitario.Constantes.SIGNOIGUAL + 
						Page.Request.QueryString[KEYQIDOGENERAL] +
						Utilitario.Constantes.SIGNOAMPERSON + 
						KEYOGENERALTEXTO + 
						Utilitario.Constantes.SIGNOIGUAL +
						Page.Request.QueryString[KEYOGENERALTEXTO] +
						Utilitario.Constantes.SIGNOAMPERSON + 
						KEYIDOESPECIFICO +
						Utilitario.Constantes.SIGNOIGUAL + 
						Page.Request.QueryString[KEYIDOESPECIFICO] +  
						Utilitario.Constantes.SIGNOAMPERSON + 
						NOMBREOE +
						Utilitario.Constantes.SIGNOIGUAL +
						Page.Request.QueryString[NOMBREOE] +
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYIDACCION +
						Utilitario.Constantes.SIGNOIGUAL + 
						Convert.ToString(dr[Utilitario.Enumerados.ColumnasAccion.idAccion.ToString()]) +
						Utilitario.Constantes.SIGNOAMPERSON + 
						DESCRIPCIONACCION + 
						Utilitario.Constantes.SIGNOIGUAL + 
						Convert.ToString(dr[Utilitario.Enumerados.ColumnasAccion.Descripcion.ToString()]) +
						Utilitario.Constantes.SIGNOAMPERSON + 
						CODIGOOE +
						Utilitario.Constantes.SIGNOIGUAL +
						Page.Request.QueryString[CODIGOOE] +
						Utilitario.Constantes.SIGNOAMPERSON +
						PE +
						Utilitario.Constantes.SIGNOIGUAL +
						Page.Request.QueryString[PE] +
						Utilitario.Constantes.SIGNOAMPERSON + 
						KEYQFILTRO  +
						Utilitario.Constantes.SIGNOIGUAL + 
						Page.Request.QueryString[KEYQFILTRO] +
						Utilitario.Constantes.SIGNOAMPERSON +
						CODIGOACCION +
						Utilitario.Constantes.SIGNOIGUAL + 
						Convert.ToString(dr[Utilitario.Enumerados.ColumnasAccion.CodigoAccion.ToString()]) +
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYCODIGOGENERADO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYCODIGOGENERADO] + Utilitario.Constantes.SIMBOLOPUNTO + e.Item.Cells[0].Text
						));		
	
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,
						(Helper.MostrarDatosEnCajaTexto
						(hCodigo.ID,
						dr[Utilitario.Enumerados.ColumnasAccion.idAccion.ToString()].ToString())));

				Helper.FiltroporSeleccionConfiguraColumna(e,grid);

				#endregion
				}
			}
		}
	}
}
