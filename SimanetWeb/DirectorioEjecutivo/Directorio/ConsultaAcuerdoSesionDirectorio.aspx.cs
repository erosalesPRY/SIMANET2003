using System;
using System.Collections;
using System.ComponentModel;
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
using SIMA.EntidadesNegocio.Secretaria.Directorio;
using System.Data;

namespace SIMA.SimaNetWeb.DirectorioEjecutivo.Directorio
{
	/// <summary>
	/// Summary description for RequerimientosAsignados.
	/// </summary>
	public class ConsultaAcuerdoSesionDirectorio : System.Web.UI.Page,IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Label lblSituacion;
		protected System.Web.UI.WebControls.TextBox txtAcuerdo;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminarFiltro;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnSesiones;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hOrdenGrilla;  
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblPosicionRegistro;
		protected System.Web.UI.WebControls.DropDownList ddlbSituacion;
		protected System.Web.UI.WebControls.ImageButton ibtnSituacion;
		#endregion Controles
		
		#region Constantes
		
		//Ordenamiento
		const string COLORDENAMIENTO = "FechaAcuerdo";

		//Nombres de Controles
		const string CONTROLINK = "hlkId";
		const string CONTROCHECKBOX = "cbxEliminar";
		
		//Paginas
		const string URLDETALLE = "ConsultarDetalleAcuerdoSesionDirectorio.aspx?";
		const string URLIMPRESION = "PopupImpresionAdministracionAcuerdoSesionDirectorio.aspx";
		const string URLSESIONES = "ConsultaSesionDirectorio.aspx";
		//Key Session y QueryString
		
		const string KEYQIDSESIONDIRECTORIO = "IdSesionDirectorio";
		const string KEYQIDCENTROOPERATIVO = "IdCentroOperativo";
		const string KEYQID = "Id";
		const string KEYQIDTIPOINFORME= "IdTipoInforme";

		//JScript
		string JSVERIFICARELIMINAR = "return verificarEliminarRb('hCodigo','" + Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO)+"','"+Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJEPREGUNTAELIMINACIONREGISTRO)+"');";
				
			
		//Otros
		const string GRILLAVACIA ="No existe ningún Acuerdo de Sesión de Directorio.";
		const string ESTILO = "FONT-WEIGHT: bold; TEXT-DECORATION: underline; COLOR: red; FONT-SIZE: x-small";
		const string CONTROLIMGBUTTON = "imgActa";
		const string INDICEPAGINA = "hGridPagina";

		const int TERMINADO = 2;
		const int ANULADO = 3;

		#endregion Constantes

		#region Variables
		#endregion Variables
		
		
		/// <summary>
		/// Elimina los Acuerdos seleccionados
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

				if(oCMantenimientos.Eliminar(Convert.ToInt32(hCodigo.Value),CNetAccessControl.GetIdUser(),Enumerados.ClasesTAD.AcuerdoSesionDirectorioTAD.ToString())>0)
				{
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Legal",this.ToString(),"Se eliminó el Acuerdo de Sesión de Directorio Nro. " + hCodigo.Value +"." ,Enumerados.NivelesErrorLog.I.ToString()));
				
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

		}	
	
		private void VerificarPerfil()
		{
			if (CNetAccessControl.GetUserName()== Helper.ObtenerValorWebConfig(Utilitario.Constantes.USUARIODIRECTOREJECUTIVO))
			{
				ibtnSituacion.Visible= false;
			}
		}

		private void llenarTiposDeSituacion()
		{
			CTablaTablas oCTablaTablas =  new CTablaTablas();
			ddlbSituacion.DataSource = oCTablaTablas.ListarTodosComboDirectorio(Convert.ToInt32(Enumerados.TablasTabla.SecretariaDirectorioSituacionAcuerdoSesionDirectorio));
			ddlbSituacion.DataValueField=Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbSituacion.DataTextField=Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbSituacion.DataBind();
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


					Helper.SeleccionarItemCombos(this);

					this.LlenarDatos();	

					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Secretaria - Directorio",this.ToString(),"Se consultó los Acuerdos de Sesión de Directorio.",Enumerados.NivelesErrorLog.I.ToString()));
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
			this.ibtnSituacion.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnSituacion_Click);
			this.ddlbSituacion.SelectedIndexChanged += new System.EventHandler(this.ddlbSituacion_SelectedIndexChanged);
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
			CAcuerdoSesionDirectorio oCAcuerdoSesionDirectorio =  new CAcuerdoSesionDirectorio();			
			DataTable dtAcuerdoSesionDirectorio ;
			
			//if (CNetAccessControl.GetUserName()== Helper.ObtenerValorWebConfig(Utilitario.Constantes.USUARIODIRECTOREJECUTIVO))
			//{
				dtAcuerdoSesionDirectorio =  oCAcuerdoSesionDirectorio.ConsultarAcuerdosPorCentroOperativoPorSesionDirectorioPorSituacion(
					Convert.ToInt32(Page.Request.QueryString[KEYQIDCENTROOPERATIVO]),
					Convert.ToInt32(Helper.RetornaSessionParaDirectorio()),
					Convert.ToInt32(ddlbSituacion.SelectedValue));				
			/*}
			else
			{
				dtAcuerdoSesionDirectorio =  oCAcuerdoSesionDirectorio.ConsultarAcuerdosPorCentroOperativoPorSesionDirectorio(Convert.ToInt32(Page.Request.QueryString[KEYQIDCENTROOPERATIVO]),Convert.ToInt32(Helper.RetornaSessionParaDirectorio()) );
			}*/		

			if(dtAcuerdoSesionDirectorio!=null)
			{
				DataView dwAcuerdoSesionDirectorio = dtAcuerdoSesionDirectorio.DefaultView;
				dwAcuerdoSesionDirectorio.Sort = columnaOrdenar ;
				dwAcuerdoSesionDirectorio.RowFilter= Utilitario.Helper.ObtenerFiltro();
				grid.DataSource = dwAcuerdoSesionDirectorio;
				grid.CurrentPageIndex =indicePagina;

				grid.Columns[0].FooterText = Utilitario.Constantes.TEXTOFOOTERTOTAL;
				grid.Columns[Utilitario.Constantes.POSICIONTOTAL].FooterText = dwAcuerdoSesionDirectorio.Count.ToString();

				//CImpresion oCImpresion = new CImpresion();
				//oCImpresion.GuardarDataImprimirExportar(dtAcuerdoSesionDirectorio,"REPORTE DE ACUERDO DE DIRECTORIO",columnaOrdenar,indicePagina);//Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGOTITULOREPORTEACCIONCORRECTIVA),columnaOrdenar,indicePagina);
				lblResultado.Visible = false;
				
			}
			else
			{
				grid.DataSource = dtAcuerdoSesionDirectorio;
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
			this.llenarTiposDeSituacion();
		}

		public void LlenarDatos()
		{
			this.AsignarSession();
			this.VerificarPerfil();
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultaDeCartasFianzas.LlenarJScript implementation
			ibtnSesiones.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado(INDICEPAGINA));
			ibtnSesiones.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.MostrarVentana(URLSESIONES,Utilitario.Constantes.VACIO));
		}

		public void RegistrarJScript()
		{
	

		}

		public void Imprimir()
		{
			ltlMensaje.Text = Helper.PopupImpresion(URLIMPRESION,650,700,false,false,false,true,true);
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

//				ImageButton img=(ImageButton)e.Item.Cells[4].FindControl("ibtnAcuerdo");
//				img.Attributes.Add("onClick",Helper.MostrarVentaModalTextoHTML("ACUERDO",
//					"<p style=¿" + ESTILO + "¿>" +
//					Convert.ToString(dr[Enumerados.ColumnasAcuerdoSesionDirectorio.Acuerdo.ToString()]).ToUpper() +
//					"</p><br>" + Convert.ToString(dr[Enumerados.ColumnasAcuerdoSesionDirectorio.Detalle.ToString()]) 
//					,500,400,0,400));
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,
					Utilitario.Helper.MostrarDatosEnCajaTexto("hCodigo",dr[Enumerados.ColumnasAcuerdoSesionDirectorio.IdAcuerdoSesionDirectorio.ToString()].ToString()),
					Utilitario.Helper.MostrarDatosEnCajaTexto("txtAcuerdo",dr[Enumerados.ColumnasAcuerdoSesionDirectorio.Gestion.ToString()].ToString()));

				e.Item.Cells[0].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.MostrarVentana(URLDETALLE,KEYQID + Utilitario.Constantes.SIGNOIGUAL + 
					Convert.ToString(dr[Enumerados.ColumnasAcuerdoSesionDirectorio.IdAcuerdoSesionDirectorio.ToString()]) +  
					Utilitario.Constantes.SIGNOAMPERSON + KEYQIDTIPOINFORME +  
					Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQIDTIPOINFORME] +
					Utilitario.Constantes.SIGNOAMPERSON + Utilitario.Constantes.KEYMODOPAGINA +  
					Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.C.ToString()));
				e.Item.Cells[0].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				e.Item.Cells[0].Font.Underline=true;
				e.Item.Cells[0].ForeColor= System.Drawing.Color.Blue;
				e.Item.Cells[0].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado("ddlbSituacion","hGridPagina","hOrdenGrilla"));

				//e.Item.Cells[3].Text = Convert.ToString(dr[Enumerados.ColumnasAcuerdoSesionDirectorio.Acuerdo.ToString()]).ToUpper();

				Helper.FiltroporSeleccionConfiguraColumna(e,grid);			
			}	
		}

		/// <summary>
		/// Abre la Pagina para Agregar un Acuerdo
		/// </summary>
		private void redireccionaPaginaAgregar()
		{
		}

		private void imgAgregar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
		}

		private void imgImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Imprimir();
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

		private void ibtnEliminarFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();												
		}

		private void ibtnCambiarSituacion_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if(hCodigo.Value.Length==0)
			{
				ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO));
			}
			else
			{
				AcuerdoSesionDirectorioBE oAcuerdoSesionDirectorioBE = new AcuerdoSesionDirectorioBE();
				oAcuerdoSesionDirectorioBE.IdAcuerdoSesionDirectorio = Convert.ToInt32(hCodigo.Value);
				oAcuerdoSesionDirectorioBE.IdSituacion = TERMINADO;
				oAcuerdoSesionDirectorioBE.IdUsuarioActualizacion = CNetAccessControl.GetIdUser();

				CAcuerdoSesionDirectorio oCAcuerdoSesionDirectorio = new CAcuerdoSesionDirectorio();				
				
				if(oCAcuerdoSesionDirectorio.ActualizarSituacionAcuerdo(oAcuerdoSesionDirectorioBE) > 0)
				{
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Acuerdos",this.ToString(),"Se actualizó el Acuerdo Nro. " + hCodigo.Value +"." ,Enumerados.NivelesErrorLog.I.ToString()));

					ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionDirectorio.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONMODIFICACIONACUERDOSESIONDIRECTORIO));
					this.LlenarGrillaOrdenamientoPaginacion(this.hOrdenGrilla.Value,Convert.ToInt32(this.hGridPagina.Value));
				}
			}	
		}

		private void ddlbSituacion_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(this.hOrdenGrilla.Value,Convert.ToInt32(this.hGridPagina.Value));
		}

		private void ibtnSituacion_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if(hCodigo.Value.Length==0)
			{
				ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO));
			}
			else
			{
				AcuerdoSesionDirectorioBE oAcuerdoSesionDirectorioBE = new AcuerdoSesionDirectorioBE();
				oAcuerdoSesionDirectorioBE.IdAcuerdoSesionDirectorio = Convert.ToInt32(hCodigo.Value);
				oAcuerdoSesionDirectorioBE.IdSituacion = Convert.ToInt32(ddlbSituacion.SelectedValue);
				oAcuerdoSesionDirectorioBE.IdUsuarioActualizacion = CNetAccessControl.GetIdUser();

				CAcuerdoSesionDirectorio oCAcuerdoSesionDirectorio = new CAcuerdoSesionDirectorio();
				
				if(oCAcuerdoSesionDirectorio.ActualizarSituacionAcuerdo(oAcuerdoSesionDirectorioBE) > 0)
				{
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Acuerdos",this.ToString(),"Se actualizó el Acuerdo Nro. " + hCodigo.Value +"." ,Enumerados.NivelesErrorLog.I.ToString()));

					ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionDirectorio.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONMODIFICACIONACUERDOSESIONDIRECTORIO));
					this.LlenarGrillaOrdenamientoPaginacion(this.hOrdenGrilla.Value,Convert.ToInt32(this.hGridPagina.Value));
				}
			}	
		}	
	}
}

