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
	public class AdministrarObjetivoEspecifico : System.Web.UI.Page, IPaginaBase
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
			this.ibtnAtrasPersonalizado.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAtrasPersonalizado_Click);
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
		
		private void LlenarTitulos()
		{
			this.lblTitulo.Text = TEXTOTITULOPLANDIRECTOR;

			int origen = Convert.ToInt32(Page.Request.QueryString[Utilitario.Enumerados.OpcionModuloGestionEstrategica.PlanEstrategico.ToString()]);

			if(origen == Convert.ToInt32(Utilitario.Enumerados.OpcionModuloGestionEstrategica.PlanEstrategico))
			{	
				//Plan Director
				this.lblProceso.Text = Convert.ToString(Page.Request.QueryString[Utilitario.Enumerados.ColumnasProceso.CodigoProceso.ToString()]).ToUpper();
				this.lblNombreProceso.Text = Convert.ToString(Page.Request.QueryString[Utilitario.Enumerados.ColumnasProceso.NombreProceso.ToString()]).ToUpper();
				this.lblSubProceso.Text = Convert.ToString(Page.Request.QueryString[Utilitario.Enumerados.ColumnasSubProceso.CodigoSubproceso.ToString()]).ToUpper();
				this.lblNombreSubProceso.Text = Convert.ToString(Page.Request.QueryString[Utilitario.Enumerados.ColumnasSubProceso.Descripcion.ToString()]).ToUpper();
			}
		}
		
		//Plan Director
		public void LlenarGrillaOrdenamientoPaginacionPlanDirector(string columnaOrdenar,int indicePagina)
		{
			int idSubProceso = Convert.ToInt32(Page.Request.QueryString[Utilitario.Enumerados.ColumnasSubProceso.IdSubProceso.ToString()]);

			CPlanGestion oCPlanGestion =  new CPlanGestion();
			DataTable dtOEspecificos =  oCPlanGestion.ListarObjetivoEspecificoPlanGestion(idSubProceso);
			
			if(dtOEspecificos!=null)
			{
				DataView dwOEspecificos = dtOEspecificos.DefaultView;
				dwOEspecificos.RowFilter = Helper.ObtenerFiltro(this);

				if(dwOEspecificos.Count>0)
				{
					grid.DataSource = dwOEspecificos;
					grid.Columns[PosicionFooterTotal].FooterText = dwOEspecificos.Count.ToString();
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
				grid.DataSource = dtOEspecificos;
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

		//Plan Estrategico
		public void LlenarGrillaOrdenamientoPaginacionPlanEstrategico(string columnaOrdenar,int indicePagina)
		{
			lblProceso.Text =  "OG " + Page.Request.QueryString[KEYCODIGOGENERADO];
			lblNombreProceso.Text = Page.Request.Params[Utilitario.Enumerados.ColumnasObjetivosGenerales.DESCRIPCION.ToString()];
			
			int idOGenerales = Convert.ToInt32(Page.Request.Params[Utilitario.Enumerados.ColumnasObjetivosGenerales.IDOGENERALES.ToString()]);

			CPlanGestion oCPlanGestion =  new CPlanGestion();
			DataTable dtOEspecificos =  oCPlanGestion.ListarObjetivoEspecificoProcesoEstrategico(idOGenerales,Convert.ToInt32(Page.Request.QueryString[KEYQFILTRO]));
			
			if(dtOEspecificos!=null)
			{
				DataView dwOEspecificos = dtOEspecificos.DefaultView;
				dwOEspecificos.RowFilter = Helper.ObtenerFiltro(this);

				if(dwOEspecificos.Count>0)
				{
					grid.DataSource = dwOEspecificos;
					grid.PageSize = Helper.ObtenerCantidadRegistrosPorGrilla();
					grid.Columns[PosicionFooterTotal].FooterText = dwOEspecificos.Count.ToString();
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
				grid.DataSource = dtOEspecificos;
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
			if(Page.Request.QueryString[KEYIDVERSION] != null)
			{
				ibtnAtrasPersonalizado.Visible = true;
				ibtnAtras.Visible = false;
			}
		}

		public void RegistrarJScript()
		{
		}

		public void Imprimir()
		{}

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
			ibtnAgregar.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			ibtnEliminar.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,JSVERIFICARELIMINAR);
		}

		#endregion
		#region Constantes
		//Ordenamiento
		const string COLORDENAMIENTO = "IdOEspecificos";
		
		//Paginas
		const string KEYIDVERSION = "KEYIDVERSION";
		const string URLIMPRESION = "PopupImpresionAdministracionArticulosRelacionesPublicas.aspx";
		const string URLMODIFICAR = "DetalleObjetivoEspecifico.aspx?";
		const string URLACCION = "AdministrarAccion.aspx?";
		const string URLADMINISTRACION= "../GestionEstrategica/AdministrarPlanEstrategicoObjetivosGenerales.aspx?";
		
		//Titulos
		const string TEXTOTITULOPLANDIRECTOR = "ADMINISTRACION DE OBJETIVOS ESPECIFICOS DEL PLAN DIRECTOR";
		const string TEXTOTITULOPLANESTRATEGICO = "ADMINISTRACION DE OBJETIVOS ESPECIFICOS DEL PLAN ESTRATEGICO";
		
		//Otros
		const int COLUMNAACCION = 0;
		const int COLUMNAMODIFICAR = 1;
		const string COLUMNAACERCADE = "Acerca de: ";
		const string COLUMNAVERACCION = "Ver Accion: ";
				
		//Key Session y QueryString
		const string KEYQIDOGENERAL = "IDOGENERALES";
		const string KEYOGENERALTEXTO = "DESCRIPCION";
		const string KEYIDOESPECIFICO = "IdOEspecificos";
		const string NOMBREOE = "NombreOEspecificos";
		const string PE = "PlanEstrategico";
		const string KEYQFILTRO = "IDVISIBILIDAD";
		const string KEYQID = "Id";
		const string KEYIDOGENERAL = "IdOGenerales";
		const string DESCRIPCIONOGENERAL = "DESCRIPCION";
		const string KEYIDPROCESO = "IdProceso";
		const string KEYIDSUBPROCESO = "IdSubProceso";
		const string CODIGOPROCESO = "CodigoProceso";
		const string NOMBREPROCESO = "NombreProceso";
		const string CODIGOSUBPROCESO = "CodigoSubproceso";
		const string NOMBRESUBPROCESO = "Descripcion";
		const string CODIGOOE = "CodigoOEspecificos";
		const string KEYCODIGOGENERADO="KEYCODIGOGENERADO";
		
		//Mensajes
		const string MENSAJEELIMINAR="Se elimino la objeetivo especifico Nro. ";
		const string MENSAJESELECCIONAR="Tiene que seleccionar un registro";
		
		//JScript
		string JSVERIFICARELIMINAR = "return verificarEliminarRb('hcodigo','" + Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO)+"','"+Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJEPREGUNTAELIMINACIONREGISTRO)+"');";
			
		//Otros
		const string GRILLAVACIA ="No existe ningun Objetivo Especifico.";
		const string OBJETIVOGENERAL = "OG";
		const int PosicionFooterTotal = 1;
		#endregion Constantes
		#region Controles
		protected System.Web.UI.WebControls.Label lblProceso;
		protected System.Web.UI.WebControls.Label lblNombreProceso;
		protected System.Web.UI.WebControls.Label lblSubProceso;
		protected System.Web.UI.WebControls.Label lblNombreSubProceso;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellNombreSubProceso;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellSubProceso;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminar;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.ImageButton ibtnAgregar;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.ImageButton ibtnAtrasPersonalizado;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidCargoLider;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdAreaLider;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdPersonalLider;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hNombreLider;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnAtras;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.HtmlControls.HtmlTable Table5;
		#endregion Controles
		#region Variables
		#endregion Variables
		#region Eventos
		private void ibtnAtrasPersonalizado_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if(Page.Request.QueryString[KEYIDVERSION]==null)
				Response.Redirect(URLADMINISTRACION + KEYQFILTRO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQFILTRO] +
					Utilitario.Constantes.SIGNOAMPERSON 
					+ PE +
					Utilitario.Constantes.SIGNOIGUAL +
					Page.Request.QueryString[PE]);
			else
				Response.Redirect(URLADMINISTRACION + KEYQFILTRO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQFILTRO] +
					Utilitario.Constantes.SIGNOAMPERSON +
					KEYIDVERSION + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYIDVERSION]);
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
		
		private void Eliminar()
		{
			if(hCodigo.Value.Length==Utilitario.Constantes.ValorConstanteCero)
			{
				ltlMensaje.Text = Helper.MensajeAlert(MENSAJESELECCIONAR);
			}
			else
			{
				CMantenimientos oCMantenimientos = new CMantenimientos();

				if(oCMantenimientos.Eliminar(Convert.ToInt32(hCodigo.Value),CNetAccessControl.GetIdUser(),Utilitario.Enumerados.ClasesTAD.ObjetivoEspecificoTAD.ToString())>Utilitario.Constantes.ValorConstanteCero)
				{
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Utilitario.Enumerados.NombresdeModulo.GestionEstratégica.ToString(),this.ToString(),MENSAJEELIMINAR + hCodigo.Value + Utilitario.Constantes.SIMBOLOPUNTO,Enumerados.NivelesErrorLog.I.ToString()));
					ltlMensaje.Text = Helper.MensajeAlert("Se elimino el registro");
					VerificarOrigen();
				}
			}
		}
	
		private void VerificarOrigen()
		{
			int origen = Convert.ToInt32(Page.Request.QueryString[Utilitario.Enumerados.OpcionModuloGestionEstrategica.PlanEstrategico.ToString()]);

			if(origen != Convert.ToInt32(Utilitario.Enumerados.OpcionModuloGestionEstrategica.PlanEstrategico))
			{	
				//Plan Director
				this.LlenarTitulos();
				this.LlenarGrillaOrdenamientoPaginacionPlanDirector(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO),Utilitario.Constantes.INDICEPAGINADEFAULT);
			}
			else
			{
				//Plan Estrategico
				this.CellSubProceso.Visible = false;
				this.CellNombreSubProceso.Visible = false;
				this.ibtnAtras.Visible = false;
				this.ibtnAtrasPersonalizado.Visible = true;
				this.lblTitulo.Text = TEXTOTITULOPLANESTRATEGICO;
				this.LlenarGrillaOrdenamientoPaginacionPlanEstrategico(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO),Utilitario.Constantes.INDICEPAGINADEFAULT);
			}
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				int origen = Convert.ToInt32(Page.Request.QueryString[Utilitario.Enumerados.OpcionModuloGestionEstrategica.PlanEstrategico.ToString()]);

				if(origen != Convert.ToInt32(Utilitario.Enumerados.OpcionModuloGestionEstrategica.PlanEstrategico))
				{	
					#region PlanDirector
					DataRowView drv = (DataRowView)e.Item.DataItem;
					DataRow dr = drv.Row;
					//e.Item.Cells[COLUMNAMODIFICAR].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
					e.Item.Cells[COLUMNAMODIFICAR].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.HISTORIALADELANTE + ";" +
						Helper.MostrarVentana(URLMODIFICAR,
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
						//idOEspecifico
						KEYIDOESPECIFICO +
						Utilitario.Constantes.SIGNOIGUAL + 
						Convert.ToString(dr[Utilitario.Enumerados.ColumnasObjetivosEspecificos.IDOESPECIFICOS.ToString()]) +  
						Utilitario.Constantes.SIGNOAMPERSON + 
						//Codigo Proceso
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
						//Nombre SubProceso
						NOMBRESUBPROCESO +
						Utilitario.Constantes.SIGNOIGUAL +
						Page.Request.QueryString[Utilitario.Enumerados.ColumnasSubProceso.Descripcion.ToString()] +
						Utilitario.Constantes.SIGNOAMPERSON +
						//Plan Estrategico
						PE +
						Utilitario.Constantes.SIGNOIGUAL +
						Convert.ToInt32(Page.Request.QueryString[Utilitario.Enumerados.OpcionModuloGestionEstrategica.PlanEstrategico.ToString()]) +
						Utilitario.Constantes.SIGNOAMPERSON +
						//					//Nombre OE
						//					NOMBREOE +
						//					Utilitario.Constantes.SIGNOIGUAL +
						//					Convert.ToString(dr[Utilitario.Enumerados.ColumnasSubProceso.Descripcion.ToString()]) +									
						//					Utilitario.Constantes.SIGNOAMPERSON +
						//ModoPagina
						Utilitario.Constantes.KEYMODOPAGINA +
						Utilitario.Constantes.SIGNOIGUAL + 
						Enumerados.ModoPagina.M.ToString()));
					e.Item.Cells[COLUMNAMODIFICAR].Font.Underline=true;
					e.Item.Cells[COLUMNAMODIFICAR].ToolTip = COLUMNAACERCADE;

					e.Item.Cells[COLUMNAACCION].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.HISTORIALADELANTE + ";" +
						Helper.MostrarVentana(URLACCION,
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
						//idOEspecifico
						KEYIDOESPECIFICO +
						Utilitario.Constantes.SIGNOIGUAL + 
						Convert.ToString(dr[Utilitario.Enumerados.ColumnasObjetivosEspecificos.IDOESPECIFICOS.ToString()])+
						Utilitario.Constantes.SIGNOAMPERSON + 
						//Codigo Proceso
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
						Convert.ToString(dr[Utilitario.Enumerados.ColumnasObjetivosEspecificos.CODIGOOESPECIFICOS.ToString()]) +
						Utilitario.Constantes.SIGNOAMPERSON +
						//Nombre OE
						NOMBREOE +
						Utilitario.Constantes.SIGNOIGUAL +
						Convert.ToString(dr[Utilitario.Enumerados.ColumnasObjetivosEspecificos.NOMBREOESPECIFICOS.ToString()])
						));

					e.Item.Cells[COLUMNAACCION].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
					e.Item.Cells[COLUMNAACCION].Font.Underline=true;
					e.Item.Cells[COLUMNAACCION].ForeColor= System.Drawing.Color.Blue;
					e.Item.Cells[COLUMNAACCION].ToolTip = COLUMNAVERACCION;

					Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
					Helper.FiltroporSeleccionConfiguraColumna(e,grid);
					#endregion
				}
				else
				{
					#region PlanEstrategico
					DataRowView drv = (DataRowView)e.Item.DataItem;
					DataRow dr = drv.Row;
					
					e.Item.Cells[0].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
					e.Item.Cells[0].Font.Underline=true;
					e.Item.Cells[0].ForeColor= System.Drawing.Color.Blue;
					e.Item.Cells[0].ToolTip = COLUMNAVERACCION;

					e.Item.Cells[1].Font.Underline=true;
					e.Item.Cells[1].ToolTip = COLUMNAACERCADE;
					e.Item.Cells[1].ForeColor= System.Drawing.Color.Blue;
					e.Item.Cells[1].Text = "OE " + Page.Request.QueryString[KEYCODIGOGENERADO] + Utilitario.Constantes.SIMBOLOPUNTO + e.Item.Cells[0].Text;
					
					e.Item.Cells[COLUMNAMODIFICAR].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.HISTORIALADELANTE + ";" +
						Helper.MostrarVentana(URLMODIFICAR,
						KEYIDOGENERAL +
						Utilitario.Constantes.SIGNOIGUAL + 
						Page.Request.Params[KEYQIDOGENERAL] +
						Utilitario.Constantes.SIGNOAMPERSON + 
						KEYOGENERALTEXTO  +
						Utilitario.Constantes.SIGNOIGUAL + 
						Page.Request.Params[KEYOGENERALTEXTO] +
						Utilitario.Constantes.SIGNOAMPERSON + 
						KEYIDOESPECIFICO +
						Utilitario.Constantes.SIGNOIGUAL + 
						Convert.ToString(dr[Utilitario.Enumerados.ColumnasObjetivosEspecificos.IDOESPECIFICOS.ToString()]) +  
						Utilitario.Constantes.SIGNOAMPERSON + 
						PE +
						Utilitario.Constantes.SIGNOIGUAL +
						Page.Request.QueryString[PE] +
						Utilitario.Constantes.SIGNOAMPERSON +
						Utilitario.Constantes.KEYMODOPAGINA +
						Utilitario.Constantes.SIGNOIGUAL + 
						Enumerados.ModoPagina.M.ToString() +
						Utilitario.Constantes.SIGNOAMPERSON + 
						KEYQFILTRO + Utilitario.Constantes.SIGNOIGUAL +
						Page.Request.QueryString[KEYQFILTRO]));

					
					e.Item.Cells[COLUMNAACCION].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.HISTORIALADELANTE + ";" +
						Helper.MostrarVentana(URLACCION,
						KEYIDOGENERAL +
						Utilitario.Constantes.SIGNOIGUAL + 
						Page.Request.QueryString[KEYIDOGENERAL] +
						Utilitario.Constantes.SIGNOAMPERSON + 
						KEYOGENERALTEXTO +
						Utilitario.Constantes.SIGNOIGUAL + 
						Page.Request.QueryString[KEYOGENERALTEXTO] +
						Utilitario.Constantes.SIGNOAMPERSON + 
						KEYIDOESPECIFICO +
						Utilitario.Constantes.SIGNOIGUAL + 
						Convert.ToString(dr[Utilitario.Enumerados.ColumnasObjetivosEspecificos.IDOESPECIFICOS.ToString()])+
						Utilitario.Constantes.SIGNOAMPERSON + 
						NOMBREOE +
						Utilitario.Constantes.SIGNOIGUAL +
						Convert.ToString(dr[Utilitario.Enumerados.ColumnasObjetivosEspecificos.NOMBREOESPECIFICOS.ToString()]) +
						Utilitario.Constantes.SIGNOAMPERSON +
						PE +
						Utilitario.Constantes.SIGNOIGUAL +
						Page.Request.QueryString[PE] +
						Utilitario.Constantes.SIGNOAMPERSON +
						CODIGOOE +
						Utilitario.Constantes.SIGNOIGUAL +
						Convert.ToString(dr[Utilitario.Enumerados.ColumnasObjetivosEspecificos.CODIGOOESPECIFICOS.ToString()]) +
						Utilitario.Constantes.SIGNOAMPERSON + 
						KEYQFILTRO +
						Utilitario.Constantes.SIGNOIGUAL + 
						Page.Request.QueryString[KEYQFILTRO] + 
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYCODIGOGENERADO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYCODIGOGENERADO] + Utilitario.Constantes.SIMBOLOPUNTO + e.Item.Cells[0].Text
						));

						Helper.SeleccionarItemGrillaOnClickMoverRaton(e,
						(Helper.MostrarDatosEnCajaTexto
						(hCodigo.ID,
						dr[Utilitario.Enumerados.ColumnasObjetivosEspecificos.IDOESPECIFICOS.ToString()].ToString())));

					Helper.FiltroporSeleccionConfiguraColumna(e,grid);
					#endregion
				}
			}
			
		}

		private void redireccionaPaginaAgregar()
		{
			int origen = Convert.ToInt32(Page.Request.QueryString[Utilitario.Enumerados.OpcionModuloGestionEstrategica.PlanEstrategico.ToString()]);

			if(origen != Convert.ToInt32(Utilitario.Enumerados.OpcionModuloGestionEstrategica.PlanEstrategico))
			{	
				//Plan Director
				//Graba en el Log la acción ejecutada
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
					//Codigo Proceso
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
					Page.Request.QueryString[Utilitario.Enumerados.ColumnasSubProceso.Descripcion.ToString()] 
					);
			}
			else
			{
				//Plan Estrategico
				//Graba en el Log la acción ejecutada
				Page.Response.Redirect(URLMODIFICAR + 
					Utilitario.Constantes.KEYMODOPAGINA + 
					Utilitario.Constantes.SIGNOIGUAL + 
					Enumerados.ModoPagina.N.ToString() +
					Utilitario.Constantes.SIGNOAMPERSON + 
					//IdOGenerales
					KEYIDOGENERAL +
					Utilitario.Constantes.SIGNOIGUAL + 
					Page.Request.Params[Utilitario.Enumerados.ColumnasObjetivosGenerales.IDOGENERALES.ToString()] +
					Utilitario.Constantes.SIGNOAMPERSON + 
					//Descripcion OGenerales
					DESCRIPCIONOGENERAL +
					Utilitario.Constantes.SIGNOIGUAL + 
					Page.Request.Params[Utilitario.Enumerados.ColumnasObjetivosGenerales.DESCRIPCION.ToString()] +
					Utilitario.Constantes.SIGNOAMPERSON +
					PE +
					Utilitario.Constantes.SIGNOIGUAL +
					Page.Request.QueryString[Utilitario.Enumerados.OpcionModuloGestionEstrategica.PlanEstrategico.ToString()] 
					);
		
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

		private void ibtnImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{				
					this.LlenarDatos();
					this.ConfigurarAccesoControles();
					this.LlenarJScript();
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

		#endregion
	}
}
