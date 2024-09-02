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
using SIMA.Controladoras.GestionFinanciera;
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
	public class ConsultarProgramacionActividades : System.Web.UI.Page,IPaginaBase
	{
		string PathArchivoReferencia="";
		#region Controles
		protected System.Web.UI.WebControls.ImageButton ibtnEliminar;
		protected System.Web.UI.WebControls.ImageButton ibtnObservaciones;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.ImageButton btnFiltrar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminarFiltro;
		protected System.Web.UI.WebControls.ImageButton ibtnAgregar;
		protected System.Web.UI.WebControls.Label lblSituacion;
		protected System.Web.UI.WebControls.TextBox txtSituacion;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hOrdenGrilla;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hDescripcion;
		protected System.Web.UI.WebControls.Literal ltlMensaje;  
		#endregion Controles	

		#region Constantes
		
		//Ordenamiento
		const string COLORDENAMIENTO = "FechaDocumento";
	
		//Paginas
		const string URLPRINCIPAL = "..\\Default.aspx";
		const string URLDETALLE = "ConsultarDetalleProgramacionActividades.aspx?";
		const string URLIMPRESION ="PoppupImpresionProgramacionActividades.aspx?";

		//Key Session y QueryString
		const string KEYQID = "Id";
		const string KEYQDESCRIPCION = "Descripcion";
		const string KEYQIDORGANISMO = "IdOrganismo";
		const string KEYQIDSITUACION = "IdSituacion";
		const string KEYQIDCENTROOPERATIVO = "IdCentroOperativo";
		const string KEYQPERIODO = "Validacion";
		//JScript
		string JSVERIFICARELIMINAR = "return verificarEliminarRb('hCodigo','" + Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO)+"','"+Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJEPREGUNTAELIMINACIONREGISTRO)+"');";
		string JSVERIFICARSELECCION = "return verificarSeleccionRb('hCodigo','" + Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO) + "');";
		protected System.Web.UI.WebControls.Label lblResultado;

		//Otros
		const string GRILLAVACIA ="No existe ninguna Programación.";  
		const string CONTROLIMGBUTTON = "imgCaducidad";
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.DropDownList ddlbPeriodo;
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
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
			this.ddlbPeriodo.SelectedIndexChanged += new System.EventHandler(this.ddlbPeriodo_SelectedIndexChanged);
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
					this.LlenarCombos();
					Helper.ReiniciarSession();
					Helper.SeleccionarItemCombos(this);
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"OCI",this.ToString(),"Se consultó las Programaciones de Inspecciones.",Enumerados.NivelesErrorLog.I.ToString()));
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
			/*if (Page.Request.QueryString[KEYQIDORGANISMO] !=null)
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
				IDCENTROOPERATIVO = -1;
			}

			if (Page.Request.QueryString[KEYQIDSITUACION] !=null)
			{
				IDSITUACION = Convert.ToInt32(Page.Request.QueryString[KEYQIDSITUACION]);
			}
			else
			{
				IDSITUACION= -1;
			}*/

			CProgramacionInspecciones oCProgramacionInspecciones=  new CProgramacionInspecciones();
			DataTable dtProgramacionInspecciones =  oCProgramacionInspecciones.ConsultarProgramacionesInspeccionesPorPeriodo(
				Convert.ToInt32(ddlbPeriodo.SelectedValue));

			if(dtProgramacionInspecciones!=null)
			{
				DataView dwProgramacionInspecciones = dtProgramacionInspecciones.DefaultView;
				dwProgramacionInspecciones.Sort = columnaOrdenar ;
				dwProgramacionInspecciones.RowFilter= Utilitario.Helper.ObtenerFiltro(this);
				grid.DataSource = dwProgramacionInspecciones;
				grid.CurrentPageIndex =indicePagina;

				grid.Columns[Utilitario.Constantes.POSICIONFOOTERTOTAL].FooterText = Utilitario.Constantes.TEXTOFOOTERTOTAL;
				grid.Columns[Utilitario.Constantes.POSICIONTOTAL].FooterText = dwProgramacionInspecciones.Count.ToString();

				lblResultado.Visible = false;
			}
			else
			{
				grid.DataSource = dtProgramacionInspecciones;
				lblResultado.Text = GRILLAVACIA;
				lblResultado.Visible = true;
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

		private void LlenarPeriodoContable()
		{
			CPeriodoContable oCPeriodoContable = new CPeriodoContable();
			ddlbPeriodo.DataSource = oCPeriodoContable.ListarPeriodo();
			ddlbPeriodo.DataValueField="Periodo";
			ddlbPeriodo.DataTextField="Periodo";
			ddlbPeriodo.DataBind();


			ListItem item;
			item = ddlbPeriodo.Items.FindByText(DateTime.Now.Year.ToString());
			if (item !=null){item.Selected = true;}
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
			ltlMensaje.Text = Helper.PopupImpresion(URLIMPRESION + KEYQPERIODO +
						Utilitario.Constantes.SIGNOIGUAL + ddlbPeriodo.SelectedValue.ToString(),780,400,false,false,false,true,true);
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

		
		public void LlenarCombos()
		{
			this.LlenarPeriodoContable();
		}

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
					Utilitario.Helper.MostrarDatosEnCajaTexto("txtSituacion",Convert.ToString(dr[Enumerados.ColumnasProgramacionInspecciones.ObservacionDocumento.ToString()])),
					Utilitario.Helper.MostrarDatosEnCajaTexto("hDescripcion",dr[Enumerados.ColumnasProgramacionInspecciones.AsuntoDocumento.ToString()].ToString()),
					Utilitario.Helper.MostrarDatosEnCajaTexto("hCodigo",dr[Enumerados.ColumnasProgramacionInspecciones.IdProgramacion.ToString()].ToString()));
				
				e.Item.Cells[0].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.MostrarVentana(URLDETALLE,KEYQID + Utilitario.Constantes.SIGNOIGUAL + 
					Convert.ToString(dr[Enumerados.ColumnasProgramacionInspecciones.IdProgramacion.ToString()]) +  
					Utilitario.Constantes.SIGNOAMPERSON + Utilitario.Constantes.KEYMODOPAGINA +  
					Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.C.ToString()));
				e.Item.Cells[0].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				e.Item.Cells[0].Font.Underline=true;
				e.Item.Cells[0].ForeColor= System.Drawing.Color.Blue;
				e.Item.Cells[0].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado("hGridPagina","hOrdenGrilla","ddlbPeriodo"));

				Image ibtn1=(Image)e.Item.Cells[7].FindControl(CONTROLIMGBUTTON);	
				if (Convert.ToString(dr[Enumerados.ColumnasProgramacionInspecciones.Vigencia.ToString()])!= String.Empty)
				{
					ibtn1.ImageUrl = "../imagenes/alert.gif";
				}
				else
				{
					ibtn1.Visible = false;
				}

				PathArchivoReferencia = System.Configuration.ConfigurationSettings.AppSettings[Utilitario.Constantes.RUTAUPLOADSERVER].ToString() + "OCI_" + dr[Enumerados.ColumnasProgramacionInspecciones.IdProgramacion.ToString()].ToString() + dr["ExtFile"].ToString(); 
				//PathArchivoReferencia = System.Configuration.ConfigurationSettings.AppSettings["RutaServerDocumentosDirectorio"].ToString() + "articulo 6 ley 27073.pdf";
				
				HtmlImage oImage = (HtmlImage) e.Item.Cells[e.Item.Cells.Count-1].FindControl("imgFile");
				oImage.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnClick.ToString(),Helper.AbrirArchivo(PathArchivoReferencia));
				oImage.Alt="Archivo de referencia";
				oImage.Style.Add(Utilitario.Constantes.DISPLAY,((dr["ExtFile"].ToString().Length>0)?Utilitario.Constantes.BLOCK:Utilitario.Constantes.NONE));

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
			CProgramacionInspecciones oCProgramacionInspecciones=  new CProgramacionInspecciones();
			DataTable dtProgramacionInspecciones =  oCProgramacionInspecciones.ConsultarProgramacionesInspeccionesPorPeriodo(
				Convert.ToInt32(ddlbPeriodo.SelectedValue));

			/*CProgramacionInspecciones oCProgramacionInspecciones=  new CProgramacionInspecciones();
			DataTable dtProgramacionInspecciones =  oCProgramacionInspecciones.ConsultarProgramacionesInspecciones(DOCUMENTOSVIGENTES);*/

			ltlMensaje.Text= Utilitario.Helper.ElaborarFiltro(this,dtProgramacionInspecciones,"../Filtros.aspx"
				,Utilitario.Enumerados.ColumnasProgramacionInspecciones.Organismo.ToString()+";Organismo"
				,Utilitario.Enumerados.ColumnasProgramacionInspecciones.AsuntoDocumento.ToString()+";Asunto"
				,"*" + Utilitario.Enumerados.ColumnasProgramacionInspecciones.CentroOperativo.ToString()+";Centro Operativo"
				,"*" + Utilitario.Enumerados.ColumnasProgramacionInspecciones.Situacion.ToString()+ ";Situacion"
				,Utilitario.Enumerados.ColumnasProgramacionInspecciones.FechaInicio.ToString()+";Fecha Inicio"
				,Utilitario.Enumerados.ColumnasProgramacionInspecciones.FechaTermino.ToString()+";Fecha Término");
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

		private void ddlbPeriodo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO),Utilitario.Constantes.INDICEPAGINADEFAULT);
		}

		private void ibtnImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Imprimir();
		}

		/*public void GuardaSessionPeriodo(int Periodo)
		{
			HttpContext.Current.Session[KEYQPERIODO]=Periodo;
		}
		public void RetornaSessionPeriodo()
		{
			if(HttpContext.Current.Session[KEYQPERIODO]!=null)
			{
				ListItem lItem;
				lItem = ddlbPeriodo.Items.FindByValue(HttpContext.Current.Session[KEYQPERIODO].ToString());
				if(lItem!=null)
				{lItem.Selected = true;}
			}
		}*/
	}
}
