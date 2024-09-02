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
using SIMA.EntidadesNegocio.GestionControlInstitucional;
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
	public class ConsultarObservacionesAuditoria : System.Web.UI.Page,IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Literal ltlMensaje;  
		#endregion Controles	

		#region Constantes
		
		//Ordenamiento
		const string COLORDENAMIENTO = "FechaTermino";
		const string CONTROLIMGBUTTON = "imgCaducidad";
	
		//Paginas
		const string URLPRINCIPAL = "..\\Default.aspx";
		//const string URLIMPRESION="PoppupImpresionObservacionesAuditoria.aspx?";		
		const string URLIMPRESION="PopupImpresionAdministracionObservacionesAuditoria.aspx?";				
		const string URLDETALLE = "ConsultarDetalleObservacionAuditoria.aspx?";

		//Key Session y QueryString
		const string KEYQID = "Id";
		const string KEYQIDDOCUMENTOAUDITORIA = "IdDocumentoAuditoria";
		const string KEYQDESCRIPCION = "Descripcion";
		const string KEYQIDORGANISMO = "IdOrganismo";
		const string KEYQIDSITUACION = "IdSituacion";
		const string KEYQIDCENTROOPERATIVO = "IdCentroOperativo";
		const string KEYQIDPERIODO = "IdPeriodo";
		const string KEYQIDTIPOSEGUIMIENTO ="IdTipoSeguimiento";

		int IDORGANISMO;
		int IDSITUACION;
		int IDCENTROOPERATIVO;
		int IDPERIODO;

		//JScript
		string JSVERIFICARELIMINAR = "return verificarEliminarRb('hCodigo','" + Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO)+"','"+Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJEPREGUNTAELIMINACIONREGISTRO)+"');";
		string JSVERIFICARSELECCION = "return verificarSeleccionRb('hCodigo','" + Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO) + "');";
		protected System.Web.UI.WebControls.Label lblResultado;

		//Otros
		const string GRILLAVACIA ="No existe ninguna Observación.";
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.DropDownList ddlbTipoJuicio;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtOrganismo;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label lblFecha;
		protected System.Web.UI.WebControls.TextBox txtPeriodo;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.TextBox txtFechaDocumento;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.TextBox txtFechaInicio;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.TextBox txtFechaTermino;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox txtCentroOperativo;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.TextBox txtSituacion;
		protected System.Web.UI.WebControls.Label lblConcepto;
		protected System.Web.UI.WebControls.TextBox txtObservaciones;
		protected System.Web.UI.WebControls.ImageButton btnFiltrar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminarFiltro;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hOrdenGrilla;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hDescripcion;
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdTipoSeguimiento;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.TextBox txtSubOrganismo;
		protected System.Web.UI.WebControls.TextBox txtAccionControl;  

		const int DOCUMENTOSVIGENTES = 0;

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
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"OCI",this.ToString(),"Se consultó las Programaciones de Inspecciones.",Enumerados.NivelesErrorLog.I.ToString()));

					Helper.SeleccionarItemCombos(this);

					this.CargarDetalleDocumentoAuditoria();
				
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

		public void CargarDetalleDocumentoAuditoria()
		{
			CMantenimientos	oCMantenimientos = new CMantenimientos();
			DocumentosAuditoriaBE oDocumentosAuditoriaBE = (DocumentosAuditoriaBE)oCMantenimientos.ListarDetalle(
				Convert.ToInt32(Page.Request.QueryString[KEYQIDDOCUMENTOAUDITORIA]),
				Enumerados.ClasesNTAD.DocumentosAuditoriaNTAD.ToString());

			if(oDocumentosAuditoriaBE!=null)
			{
				txtOrganismo.Text = oDocumentosAuditoriaBE.Organismo.ToString();
				txtSubOrganismo.Text=oDocumentosAuditoriaBE.SubOrganismo.ToString();
				txtAccionControl.Text = oDocumentosAuditoriaBE.Actividad.ToString();
				txtPeriodo.Text = oDocumentosAuditoriaBE.Periodo.ToString();
				txtFechaDocumento.Text = Convert.ToDateTime(oDocumentosAuditoriaBE.FechaDocumento).ToString(Utilitario.Constantes.FORMATOFECHA4);
				txtFechaInicio.Text = Convert.ToDateTime(oDocumentosAuditoriaBE.FechaInicio).ToString(Utilitario.Constantes.FORMATOFECHA4);
				if(oDocumentosAuditoriaBE.FechaTermino.ToString() != Utilitario.Constantes.FECHAVALORENBLANCO)
				{
					try
					{
						txtFechaTermino.Text = Convert.ToDateTime(oDocumentosAuditoriaBE.FechaTermino.ToString()).ToString(Utilitario.Constantes.FORMATOFECHA4);
					}
					catch(Exception e)
					{
						string a = e.Message;
						txtFechaTermino.Text = Utilitario.Constantes.VACIO;
					}
				}
				else
				{
					txtFechaTermino.Text = Utilitario.Constantes.VACIO;
				}

				txtCentroOperativo.Text = oDocumentosAuditoriaBE.CentroOperativo.ToString();
				if( Page.Request.QueryString[KEYQIDSITUACION].ToString()=="1")
				{
					txtSituacion.Text ="EN PROCESO";
				}
				else if( Page.Request.QueryString[KEYQIDSITUACION].ToString()=="0")
				{
					txtSituacion.Text ="IMPLEMENTADO";
				}
				else if( Page.Request.QueryString[KEYQIDSITUACION].ToString()=="2")
				{
					txtSituacion.Text ="PENDIENTE";
				}
				else
				{
					txtSituacion.Text ="INFORMADO";
				}
			
						//txtSituacion.Text = oDocumentosAuditoriaBE.Situacion.ToString();
						//txtPersonal.Text = oDocumentosAuditoriaBE.Personal.ToString();
				txtObservaciones.Text  = oDocumentosAuditoriaBE.Observacion.ToString();

				this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO),Utilitario.Constantes.INDICEPAGINADEFAULT);
			}
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
				string  A = Page.Request.QueryString[KEYQIDSITUACION].ToString();
				IDSITUACION = Convert.ToInt32(Page.Request.QueryString[KEYQIDSITUACION]);
			}
			else
			{
				IDSITUACION = 	Convert.ToInt32(Page.Request.QueryString[KEYQIDSITUACION]);
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
				(Convert.ToInt32(Page.Request.QueryString[KEYQIDDOCUMENTOAUDITORIA]),IDSITUACION, 
				IDORGANISMO, IDCENTROOPERATIVO, IDPERIODO, Convert.ToInt32(Page.Request.QueryString[KEYQIDTIPOSEGUIMIENTO]));

			if(dtObservacionesAuditoria!=null)
			{
				DataView dwObservacionesAuditoria = dtObservacionesAuditoria.DefaultView;
				dwObservacionesAuditoria.Sort = columnaOrdenar ;
				dwObservacionesAuditoria.RowFilter= Utilitario.Helper.ObtenerFiltro(this);
				grid.DataSource = dwObservacionesAuditoria;
				grid.CurrentPageIndex =indicePagina;

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
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministracionDePoderes.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			
			ltlMensaje.Text = Helper.PopupImpresion(URLIMPRESION + 
				KEYQIDDOCUMENTOAUDITORIA + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQIDDOCUMENTOAUDITORIA]+
				Utilitario.Constantes.SIGNOAMPERSON + KEYQIDTIPOSEGUIMIENTO + Utilitario.Constantes.SIGNOIGUAL + (Page.Request.QueryString[KEYQIDTIPOSEGUIMIENTO])+
				Utilitario.Constantes.SIGNOAMPERSON + KEYQDESCRIPCION + Utilitario.Constantes.SIGNOIGUAL + 
				Utilitario.Constantes.SIGNOAMPERSON + KEYQIDSITUACION + Page.Request.QueryString[KEYQIDSITUACION].ToString() +  Utilitario.Constantes.ESPACIO
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
					//Utilitario.Helper.MostrarDatosEnCajaTexto("txtSituacion",Convert.ToString(dr[Enumerados.ColumnasObservacionesAuditoria.SituacionActual.ToString()])),
					Utilitario.Helper.MostrarDatosEnCajaTexto("hDescripcion",dr[Enumerados.ColumnasObservacionesAuditoria.Observacion.ToString()].ToString()),
					Utilitario.Helper.MostrarDatosEnCajaTexto("hCodigo",dr[Enumerados.ColumnasObservacionesAuditoria.IdObservacionAuditoria.ToString()].ToString()));
				
				e.Item.Cells[0].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.MostrarVentana(URLDETALLE,KEYQID + Utilitario.Constantes.SIGNOIGUAL + 
					Convert.ToString(dr[Enumerados.ColumnasObservacionesAuditoria.IdObservacionAuditoria.ToString()]) +  
					Utilitario.Constantes.SIGNOAMPERSON + 
				    KEYQIDTIPOSEGUIMIENTO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQIDTIPOSEGUIMIENTO].ToString() + Utilitario.Constantes.SIGNOAMPERSON +
					Utilitario.Constantes.KEYMODOPAGINA +  
					Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.C.ToString()));
				e.Item.Cells[0].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				e.Item.Cells[0].Font.Underline=true;
				e.Item.Cells[0].ForeColor= System.Drawing.Color.Blue;
				e.Item.Cells[0].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado("hGridPagina","hOrdenGrilla"));

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

			CObservacionesAuditoria oCObservacionesAuditoria=  new CObservacionesAuditoria();
			DataTable dtObservacionesAuditoria =  oCObservacionesAuditoria.ConsultarObservacionesAuditoria
				(1,IDSITUACION, IDORGANISMO, IDCENTROOPERATIVO, IDPERIODO,Convert.ToInt32(Page.Request.QueryString[KEYQIDTIPOSEGUIMIENTO]));

			ltlMensaje.Text= Utilitario.Helper.ElaborarFiltro(this,dtObservacionesAuditoria,"../Filtros.aspx"
				,Utilitario.Enumerados.ColumnasObservacionesAuditoria.Observacion.ToString()+";Observacion"
				,"*" + Utilitario.Enumerados.ColumnasObservacionesAuditoria.CentroOperativo.ToString()+";Centro Operativo"
				,Utilitario.Enumerados.ColumnasObservacionesAuditoria.Situacion.ToString()+ ";Situacion"
				,Utilitario.Enumerados.ColumnasObservacionesAuditoria.FechaTermino.ToString()+";Fecha Término");
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

		private void ibtnImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Imprimir();
		}

	}
}
