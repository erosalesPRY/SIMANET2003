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
using SIMA.Controladoras.GestionControlInstitucional;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using NullableTypes;
using MetaBuilders.WebControls;

namespace SIMA.SimaNetWeb.GestionControlInstitucional
{
	/// <summary>
	/// Summary description for AdministracionDePoderes.
	/// </summary>
	public class AdministracionDocumentosAuditoria : System.Web.UI.Page,IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Literal ltlMensaje;  
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.ImageButton btnFiltrar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminarFiltro;
		protected System.Web.UI.WebControls.ImageButton ibtnAgregar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminar;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblSituacion;
		protected System.Web.UI.WebControls.TextBox txtSituacion;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hOrdenGrilla;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hDescripcion;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.ImageButton ibtnAcciones;
		#endregion Controles	

		#region Constantes
		
		//Ordenamiento
		const string COLORDENAMIENTO = "FechaInicio";
	
		//Paginas
		const string URLPRINCIPAL = "..\\Default.aspx";
		const string URLDETALLE = "DetalleDocumentosAuditoria.aspx?";
		const string URLIMPRESION="PoppupImpresionDocumentosAuditoria.aspx?";
		const string URLOBSERVACIONES = "AdministracionObservacionesAuditoria.aspx?";	
		const string URLORGANISMOS = "AdministrarOrganismoAccionSubAccion.aspx?";	
		const string URLASOCIACIONES = "AdministrarAsociacionOrganismoAccionSubAccion.aspx?";	
		

		//Key Session y QueryString
		const string KEYQIDDOCUMENTOAUDITORIA = "IdDocumentoAuditoria";
		const string KEYQDESCRIPCION = "Descripcion";
		const string KEYQIDSITUACION = "IdSituacion";
		const string KEYQIDORGANISMO = "IdOrganismo";
		const string KEYQIDCENTROOPERATIVO = "IdCentroOperativo";
		const string KEYQIDPERIODO = "IdPeriodo";
		const string KEYQIDTIPOSEGUIMIENTO ="IdTipoSeguimiento";
			const string KEYQTIPOCONSULTA="TipoConsulta";
		int IDSITUACION;
		int IDORGANISMO;
		int IDCENTROOPERATIVO;
		int IDPERIODO;

		//JScript
		string JSVERIFICARELIMINAR = "return verificarEliminarRb('hCodigo','" + Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO)+"','"+Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJEPREGUNTAELIMINACIONREGISTRO)+"');";
		string JSVERIFICARSELECCION = "return verificarSeleccionRb('hCodigo','" + Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO) + "');";

		//Otros
		const string GRILLAVACIA ="No existe ningún Documento de Auditoría.";
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
		protected System.Web.UI.WebControls.DropDownList ddblObsSinSeguimiento;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.ImageButton btnOrganismos;
		protected System.Web.UI.WebControls.ImageButton btnAcciones;
		protected System.Web.UI.WebControls.ImageButton btnSubAcciones;
		protected System.Web.UI.WebControls.ImageButton btnAsociar;  
		const string CONTROLIMGBUTTON = "imgCaducidad";

		#endregion Constantes

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
			this.ddblObsSinSeguimiento.SelectedIndexChanged += new System.EventHandler(this.ddblObsSinSeguimiento_SelectedIndexChanged);
			this.btnOrganismos.Click += new System.Web.UI.ImageClickEventHandler(this.btnOrganismos_Click);
			this.btnSubAcciones.Click += new System.Web.UI.ImageClickEventHandler(this.btnSubAcciones_Click);
			this.btnAcciones.Click += new System.Web.UI.ImageClickEventHandler(this.btnAcciones_Click);
			this.btnAsociar.Click += new System.Web.UI.ImageClickEventHandler(this.btnAsociar_Click);
			this.btnFiltrar.Click += new System.Web.UI.ImageClickEventHandler(this.btnFiltrar_Click);
			this.ibtnEliminarFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminarFiltro_Click);
			this.ibtnAgregar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAgregar_Click);
			this.ibtnEliminar.Click += new System.Web.UI.ImageClickEventHandler(this.imgEliminar_Click);
			this.ibtnAcciones.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAcciones_Click);
			this.ibtnImprimir.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnImprimir_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// Elimina los Poderes Asignados
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

				if(oCMantenimientos.Eliminar(Convert.ToInt32(hCodigo.Value),CNetAccessControl.GetIdUser(),Enumerados.ClasesTAD.DocumentosAuditoriaTAD.ToString())>0)

				{
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"OCI",this.ToString(),"Se eliminó la Observación Nro. " + hCodigo.Value +"." ,Enumerados.NivelesErrorLog.I.ToString()));
				
					this.LlenarGrillaOrdenamientoPaginacion(this.hOrdenGrilla.Value,Convert.ToInt32(this.hGridPagina.Value));
						
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
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Legal",this.ToString(),"Se consultó los DocumentosAuditoria Embargados.",Enumerados.NivelesErrorLog.I.ToString()));
					this.LlenarCombos();
					Helper.SeleccionarItemCombos(this);
					this.LlenarGrillaOrdenamientoPaginacion(this.hOrdenGrilla.Value,Convert.ToInt32(this.hGridPagina.Value));
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

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add AdministracionDePoderes.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministracionDePoderes.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			if (Page.Request.QueryString[KEYQIDSITUACION] !=null)
			{
				IDSITUACION = Convert.ToInt32(Page.Request.QueryString[KEYQIDSITUACION]);
			}
			else
			{
				IDSITUACION = -1;
			}

			if (Page.Request.QueryString[KEYQIDORGANISMO] !=null)
			{
				IDORGANISMO = Convert.ToInt32(Page.Request.QueryString[KEYQIDORGANISMO]);
			}
			else
			{
				IDORGANISMO = -1;
			}

			if (Page.Request.QueryString[KEYQIDCENTROOPERATIVO] !=null)
			{
				IDCENTROOPERATIVO = Convert.ToInt32(Page.Request.QueryString[KEYQIDCENTROOPERATIVO]);
			}
			else
			{
				IDCENTROOPERATIVO= -1;
			}

			if (Page.Request.QueryString[KEYQIDPERIODO] !=null)
			{
				IDPERIODO = Convert.ToInt32(Page.Request.QueryString[KEYQIDPERIODO]);
			}
			else
			{
				IDPERIODO= -1;
			}

			CDocumentosAuditoria oCDocumentosAuditoria=  new CDocumentosAuditoria();
			DataTable dtDocumentosAuditoria =  oCDocumentosAuditoria.ConsultarDocumentosAuditoria
				(IDSITUACION, IDORGANISMO, IDCENTROOPERATIVO, IDPERIODO, Convert.ToInt32(ddblObsSinSeguimiento.SelectedValue));

			if(dtDocumentosAuditoria!=null)
			{
				DataView dwDocumentosAuditoria = dtDocumentosAuditoria.DefaultView;
				dwDocumentosAuditoria.Sort = columnaOrdenar ;
				dwDocumentosAuditoria.RowFilter= Utilitario.Helper.ObtenerFiltro(this);
				grid.DataSource = dwDocumentosAuditoria;
				grid.CurrentPageIndex =indicePagina;

				grid.Columns[Utilitario.Constantes.POSICIONFOOTERTOTAL].FooterText = Utilitario.Constantes.TEXTOFOOTERTOTAL;
				grid.Columns[Utilitario.Constantes.POSICIONTOTAL].FooterText = dwDocumentosAuditoria.Count.ToString();
				lblResultado.Visible=false;
			}
			else
			{
				
				grid.DataSource = dtDocumentosAuditoria;
				lblResultado.Visible=true;
				lblResultado.Text = GRILLAVACIA;
			}
			
			try
			{
				grid.DataBind();
			}
			catch (Exception a)
			{
				string b = a.Message.ToString();
				grid.CurrentPageIndex = 0;
				grid.DataBind();
			}
		}

		public void LlenarCombos()
		{
			
			CTablaTablas oCTablasTablas1 = new CTablaTablas();
			ddblObsSinSeguimiento.DataSource= oCTablasTablas1.ListaTodosCombo(336);
			ddblObsSinSeguimiento.DataTextField= Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddblObsSinSeguimiento.DataValueField=Enumerados.ColumnasTablaTablas.Codigo.ToString ();
			ddblObsSinSeguimiento.DataBind();

			if (ddblObsSinSeguimiento.Items.Count>0)
			{
				ddblObsSinSeguimiento.SelectedIndex=3;
			}

		}

		public void LlenarDatos()
		{
			// TODO:  Add AdministracionDePoderes.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			ibtnEliminar.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,JSVERIFICARELIMINAR);
			ibtnAcciones.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,JSVERIFICARSELECCION);			

			ibtnAgregar.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado("hGridPagina","hOrdenGrilla"));
			ibtnAcciones.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado("hGridPagina","hOrdenGrilla"));
			btnAcciones.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado("hGridPagina","hOrdenGrilla"));
			btnAsociar.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado("hGridPagina","hOrdenGrilla"));
			btnOrganismos.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado("hGridPagina","hOrdenGrilla"));
			btnSubAcciones.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado("hGridPagina","hOrdenGrilla"));
			btnAcciones.Style.Add("display","none");
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministracionDePoderes.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			ltlMensaje.Text = Helper.PopupImpresion(URLIMPRESION + KEYQIDTIPOSEGUIMIENTO + Utilitario.Constantes.SIGNOIGUAL + 
					ddblObsSinSeguimiento.SelectedValue,780,400,false,false,false,true,true);
		}

		public void Exportar()
		{
			// TODO:  Add AdministracionDePoderes.Exportar implementation
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

		

		private void redireccionaPaginaAgregar()
		{
			Page.Response.Redirect(URLDETALLE + Utilitario.Constantes.KEYMODOPAGINA + 
				Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.N.ToString());
		}

		private void imgImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Imprimir();
		}

		
		private void imgExportarExcel_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Exportar();
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.hOrdenGrilla.Value = Helper.GenerarExpresionOrdenamiento(e.SortExpression);
			this.LlenarGrillaOrdenamientoPaginacion(this.hOrdenGrilla.Value,Helper.ObtenerIndicePagina());
		}


		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.hGridPagina.Value = e.NewPageIndex.ToString();
			this.LlenarGrillaOrdenamientoPaginacion(this.hOrdenGrilla.Value,e.NewPageIndex);		
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

		private void ibtnAgregar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.redireccionaPaginaAgregar();	
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,
					Utilitario.Helper.MostrarDatosEnCajaTexto("txtSituacion",Convert.ToString(dr[Enumerados.ColumnasDocumentosAuditoria.SituacionActual.ToString()])),
					Utilitario.Helper.MostrarDatosEnCajaTexto("hDescripcion",dr[Enumerados.ColumnasDocumentosAuditoria.Observacion.ToString()].ToString()),
					Utilitario.Helper.MostrarDatosEnCajaTexto("hCodigo",dr[Enumerados.ColumnasDocumentosAuditoria.IdDocumentoAuditoria.ToString()].ToString()));
				
				e.Item.Cells[0].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.MostrarVentana(URLDETALLE,KEYQIDDOCUMENTOAUDITORIA + Utilitario.Constantes.SIGNOIGUAL + 
					Convert.ToString(dr[Enumerados.ColumnasDocumentosAuditoria.IdDocumentoAuditoria.ToString()]) +  
					Utilitario.Constantes.SIGNOAMPERSON + Utilitario.Constantes.KEYMODOPAGINA +  
					Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.M.ToString()));
				e.Item.Cells[0].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				e.Item.Cells[0].Font.Underline=true; 
				e.Item.Cells[0].ForeColor= System.Drawing.Color.Blue;
				e.Item.Cells[0].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado("hGridPagina","hOrdenGrilla","ddblObsSinSeguimiento"));

				Image ibtn1=(Image)e.Item.Cells[7].FindControl(CONTROLIMGBUTTON);	
				if (Convert.ToString(dr[Enumerados.ColumnasDocumentosAuditoria.Vigencia.ToString()])!= String.Empty)
				{
					ibtn1.ImageUrl = "../imagenes/alert.gif";
				}
				else
				{
					ibtn1.Visible = false;
				}

				Helper.FiltroporSeleccionConfiguraColumna(e,grid);
			}	
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void reiniciarCampos()
		{
			//this.hCodigo.Value = "";

		}

		private void btnFiltrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if (Page.Request.QueryString[KEYQIDSITUACION] !=null)
			{
				IDSITUACION = Convert.ToInt32(Page.Request.QueryString[KEYQIDSITUACION]);
			}
			else
			{
				IDSITUACION = -1;
			}

			if (Page.Request.QueryString[KEYQIDORGANISMO] !=null)
			{
				IDORGANISMO = Convert.ToInt32(Page.Request.QueryString[KEYQIDORGANISMO]);
			}
			else
			{
				IDORGANISMO = -1;
			}

			if (Page.Request.QueryString[KEYQIDCENTROOPERATIVO] !=null)
			{
				IDCENTROOPERATIVO = Convert.ToInt32(Page.Request.QueryString[KEYQIDCENTROOPERATIVO]);
			}
			else
			{
				IDCENTROOPERATIVO= -1;
			}

			if (Page.Request.QueryString[KEYQIDPERIODO] !=null)
			{
				IDPERIODO = Convert.ToInt32(Page.Request.QueryString[KEYQIDPERIODO]);
			}
			else
			{
				IDPERIODO= -1;
			}

			CDocumentosAuditoria oCDocumentosAuditoria=  new CDocumentosAuditoria();
			DataTable dtDocumentosAuditoria =  oCDocumentosAuditoria.ConsultarDocumentosAuditoria
				(IDSITUACION, IDORGANISMO, IDCENTROOPERATIVO, IDPERIODO,Convert.ToInt32(ddblObsSinSeguimiento.SelectedValue));

			ltlMensaje.Text= Utilitario.Helper.ElaborarFiltro(this,dtDocumentosAuditoria,"../Filtros.aspx"
				,Utilitario.Enumerados.ColumnasDocumentosAuditoria.Observacion.ToString()+";Observacion"
				,"*" + Utilitario.Enumerados.ColumnasDocumentosAuditoria.Organismo.ToString()+";Organismo"
				,"*" + "Suborganismo"+";Sub-Organismo"
				,"*" + Utilitario.Enumerados.ColumnasDocumentosAuditoria.Actividad.ToString()+";Accion de Control"
				,"*" + Utilitario.Enumerados.ColumnasDocumentosAuditoria.CentroOperativo.ToString()+";Centro Operativo"
				,Utilitario.Enumerados.ColumnasDocumentosAuditoria.FechaInicio.ToString()+";Fecha Inicio"
				,Utilitario.Enumerados.ColumnasDocumentosAuditoria.FechaTermino.ToString()+";Fecha Término"
				,"*" + Utilitario.Enumerados.ColumnasDocumentosAuditoria.Situacion.ToString()+";Situacion"
				);
		}

		private void redireccionaPaginaPrincipal()
		{
			Page.Response.Redirect(URLPRINCIPAL);
		}

		private void ibtnAtras_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.redireccionaPaginaPrincipal();						
		}

		private void ibtnEliminarFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();								
		}

		private void ibtnAcciones_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if(hCodigo.Value.Length==0)
			{
				ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO));
			}
			else
			{
				Page.Response.Redirect(URLOBSERVACIONES + KEYQIDDOCUMENTOAUDITORIA + Utilitario.Constantes.SIGNOIGUAL + 
					hCodigo.Value + Utilitario.Constantes.SIGNOAMPERSON + KEYQDESCRIPCION + 
					Utilitario.Constantes.SIGNOIGUAL +  hDescripcion.Value + Utilitario.Constantes.SIGNOAMPERSON + KEYQIDTIPOSEGUIMIENTO + 
					Utilitario.Constantes.SIGNOIGUAL +  ddblObsSinSeguimiento.SelectedValue);
			}		
		}

		private void ibtnImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Imprimir();
		}

		private void ddblObsSinSeguimiento_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(this.hOrdenGrilla.Value,Convert.ToInt32(this.hGridPagina.Value));
		}

		private void btnOrganismos_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Page.Response.Redirect(URLORGANISMOS + KEYQTIPOCONSULTA + Utilitario.Constantes.SIGNOIGUAL + 
				"316");
		}

		private void btnAcciones_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Page.Response.Redirect(URLORGANISMOS + KEYQTIPOCONSULTA + Utilitario.Constantes.SIGNOIGUAL + 
				"391");
		}

		private void btnSubAcciones_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Page.Response.Redirect(URLORGANISMOS + KEYQTIPOCONSULTA + Utilitario.Constantes.SIGNOIGUAL + 
				"390");
		}

		private void btnAsociar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Page.Response.Redirect(URLASOCIACIONES);
		}
	}
}
