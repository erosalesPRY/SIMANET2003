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
	public class AdministracionObservacionesAuditoria : System.Web.UI.Page,IPaginaBase
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
		const string URLDETALLE = "DetalleObservacionesAuditoria.aspx?";
		const string URLACCIONES = "AdministracionAccionesControl.aspx?";				
		const string URLIMPRESION="PopupImpresionAdministracionObservacionesAuditoria.aspx?";

		const string URLRECOMENDACION="AdministrarRecomendacionesPorObservaciones.aspx?";


		//Key Session y QueryString
		const string KEYQID = "Id";
		const string KEYQDESCRIPCIONDOC = "DesDoc";

		const string KEYQIDOBSERVACION = "IdObservacion";
		const string KEYQIDDOCUMENTOAUDITORIA = "IdDocumentoAuditoria";
		const string KEYQDESCRIPCION = "Descripcion";
		const string KEYQIDSITUACION = "IdSituacion";
		const string KEYQIDORGANISMO = "IdOrganismo";
		const string KEYQIDCENTROOPERATIVO = "IdCentroOperativo";
		const string KEYQIDPERIODO = "IdPeriodo";
		const string KEYQIDTIPOSEGUIMIENTO ="IdTipoSeguimiento";

		int IDSITUACION;
		int IDORGANISMO;
		int IDCENTROOPERATIVO;
		int IDPERIODO;

		//JScript
		string JSVERIFICARELIMINAR = "return verificarEliminarRb('hCodigo','" + Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO)+"','"+Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJEPREGUNTAELIMINACIONREGISTRO)+"');";
		string JSVERIFICARSELECCION = "return verificarSeleccionRb('hCodigo','" + Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO) + "');";

		//Otros
		const string GRILLAVACIA ="No existe ninguna Observación de Auditoría.";
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
		protected System.Web.UI.WebControls.ImageButton ibtnRecomendaciones;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdObservacion;  
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
			this.btnFiltrar.Click += new System.Web.UI.ImageClickEventHandler(this.btnFiltrar_Click);
			this.ibtnEliminarFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminarFiltro_Click);
			this.ibtnAgregar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAgregar_Click);
			this.ibtnEliminar.Click += new System.Web.UI.ImageClickEventHandler(this.imgEliminar_Click);
			this.ibtnAcciones.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAcciones_Click);
			this.ibtnRecomendaciones.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnRecomendaciones_Click);
			this.ibtnImprimir.Click += new System.Web.UI.ImageClickEventHandler(this.imgImprimir_Click);
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

				if(oCMantenimientos.Eliminar(Convert.ToInt32(hCodigo.Value),CNetAccessControl.GetIdUser(),Enumerados.ClasesTAD.ObservacionesAuditoriaTAD.ToString())>0)

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
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Legal",this.ToString(),"Se consultó los ObservacionesAuditoria Embargados.",Enumerados.NivelesErrorLog.I.ToString()));

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
			lblTitulo.Text = Page.Request.QueryString[KEYQDESCRIPCION];

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

			CObservacionesAuditoria oCObservacionesAuditoria=  new CObservacionesAuditoria();
			DataTable dtObservacionesAuditoria =  oCObservacionesAuditoria.ConsultarObservacionesAuditoria
						(Convert.ToInt32(Page.Request.QueryString[KEYQIDDOCUMENTOAUDITORIA]), IDSITUACION, IDORGANISMO, IDCENTROOPERATIVO, IDPERIODO,Convert.ToInt32(Page.Request.QueryString[KEYQIDTIPOSEGUIMIENTO]));

			if(dtObservacionesAuditoria!=null)
			{
				DataView dwObservacionesAuditoria = dtObservacionesAuditoria.DefaultView;
				dwObservacionesAuditoria.Sort = columnaOrdenar ;
				dwObservacionesAuditoria.RowFilter= Utilitario.Helper.ObtenerFiltro(this);
				grid.DataSource = dwObservacionesAuditoria;
				grid.CurrentPageIndex =indicePagina;

				/*CImpresion oCImpresion = new CImpresion();
				oCImpresion.GuardarDataImprimirExportar(dtObservacionesAuditoria,
					Page.Request.QueryString[KEYQDESCRIPCION],"");*/

				grid.Columns[Utilitario.Constantes.POSICIONFOOTERTOTAL].FooterText = Utilitario.Constantes.TEXTOFOOTERTOTAL;
				grid.Columns[Utilitario.Constantes.POSICIONTOTAL].FooterText = dwObservacionesAuditoria.Count.ToString();
			}
			else
			{
				grid.DataSource = dtObservacionesAuditoria;
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
			// TODO:  Add AdministracionDePoderes.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add AdministracionDePoderes.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			ibtnEliminar.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,JSVERIFICARELIMINAR);
			//ibtnAcciones.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,JSVERIFICARSELECCION);
			//ibtnRecomendaciones.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,JSVERIFICARSELECCION);

			ibtnAgregar.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado("hGridPagina","hOrdenGrilla"));
			ibtnAcciones.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado("hGridPagina","hOrdenGrilla"));
			ibtnRecomendaciones.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado("hGridPagina","hOrdenGrilla"));
			ibtnAcciones.Style.Add("display","none");
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministracionDePoderes.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			ltlMensaje.Text = Helper.PopupImpresion(URLIMPRESION + 
				KEYQIDDOCUMENTOAUDITORIA + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQIDDOCUMENTOAUDITORIA]+
			Utilitario.Constantes.SIGNOAMPERSON + KEYQDESCRIPCION + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQDESCRIPCION] + 
				Utilitario.Constantes.SIGNOAMPERSON + KEYQIDTIPOSEGUIMIENTO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQIDTIPOSEGUIMIENTO]
			,780,400,false,false,false,true,true);
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
				Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.N.ToString() + Utilitario.Constantes.SIGNOAMPERSON +
				KEYQIDDOCUMENTOAUDITORIA + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQIDDOCUMENTOAUDITORIA]
				);
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

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,Utilitario.Helper.MostrarDatosEnCajaTexto("hCodigo",dr[Enumerados.ColumnasObservacionesAuditoria.IdObservacionAuditoria.ToString()].ToString())
																,Utilitario.Helper.MostrarDatosEnCajaTexto("hDescripcion",dr[Enumerados.ColumnasObservacionesAuditoria.Observacion.ToString()].ToString())
															  );
				
				e.Item.Cells[0].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.MostrarVentana(URLDETALLE,KEYQIDOBSERVACION + Utilitario.Constantes.SIGNOIGUAL + 
					Convert.ToString(dr[Enumerados.ColumnasObservacionesAuditoria.IdObservacionAuditoria.ToString()]) +  
					Utilitario.Constantes.SIGNOAMPERSON + Utilitario.Constantes.KEYMODOPAGINA +  
					Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.M.ToString()
					));
				e.Item.Cells[0].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				e.Item.Cells[0].Font.Underline=true;
				e.Item.Cells[0].ForeColor= System.Drawing.Color.Blue;
				e.Item.Cells[0].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado("hGridPagina","hOrdenGrilla"));

				//Helper.SeleccionarItemGrillaOnClickMoverRaton(e,Helper.MostrarDatosEnCajaTexto("hIdObservacion",Convert.ToString(dr["IdObservacionAuditoria"])));

				Image ibtn1=(Image)e.Item.Cells[5].FindControl(CONTROLIMGBUTTON);	
				if (Convert.ToString(dr[Enumerados.ColumnasObservacionesAuditoria.Vigencia.ToString()])!= String.Empty)
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

			CObservacionesAuditoria oCObservacionesAuditoria=  new CObservacionesAuditoria();
			DataTable dtObservacionesAuditoria =  oCObservacionesAuditoria.ConsultarObservacionesAuditoria
				(Convert.ToInt32(Page.Request.QueryString[KEYQIDDOCUMENTOAUDITORIA]),IDSITUACION, IDORGANISMO, IDCENTROOPERATIVO, IDPERIODO,3);

			ltlMensaje.Text= Utilitario.Helper.ElaborarFiltro(this,dtObservacionesAuditoria,"../Filtros.aspx"
				,Utilitario.Enumerados.ColumnasObservacionesAuditoria.Observacion.ToString()+";Observacion"
				,"*" + Utilitario.Enumerados.ColumnasObservacionesAuditoria.CentroOperativo.ToString()+";Centro Operativo"
				,Utilitario.Enumerados.ColumnasObservacionesAuditoria.FechaTermino.ToString()+";Fecha Término"
				,Utilitario.Enumerados.ColumnasObservacionesAuditoria.Situacion.ToString()+";Situacion"
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
				//ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO));
				Helper.MsgBox("ACCIONES",Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO),Utilitario.Enumerados.Ext.MessageBox.Button.OK,Utilitario.Enumerados.Ext.MessageBox.Icon.ERROR);

			}
			else
			{
				Page.Response.Redirect(URLACCIONES + KEYQIDOBSERVACION + Utilitario.Constantes.SIGNOIGUAL + hCodigo.Value 
													+ Utilitario.Constantes.SIGNOAMPERSON 
													+ KEYQDESCRIPCION + Utilitario.Constantes.SIGNOIGUAL + hDescripcion.Value 
													+ Utilitario.Constantes.SIGNOAMPERSON 
													+ KEYQIDTIPOSEGUIMIENTO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQIDTIPOSEGUIMIENTO].ToString());
			}		
		}

		private void ibtnRecomendaciones_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if(hCodigo.Value.Length==0)
			{
				Helper.MsgBox("RECOMENDACIONES","No se ha seleccionado registro de observacion!!...Por favor seleccione uno",Utilitario.Enumerados.Ext.MessageBox.Button.OK,Utilitario.Enumerados.Ext.MessageBox.Icon.ERROR);
			}
			else
			{
				Page.Response.Redirect(URLRECOMENDACION + KEYQIDOBSERVACION + Utilitario.Constantes.SIGNOIGUAL +  hCodigo.Value
										+ Utilitario.Constantes.SIGNOAMPERSON 
										+ KEYQDESCRIPCION + Utilitario.Constantes.SIGNOIGUAL + hDescripcion.Value
										+ Utilitario.Constantes.SIGNOAMPERSON 
										+ KEYQDESCRIPCIONDOC + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQDESCRIPCION].Replace("\"","")
										);
			}		
		}
	}
}
