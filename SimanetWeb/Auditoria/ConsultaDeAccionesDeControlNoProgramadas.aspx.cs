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
using SIMA.Controladoras.Auditoria;
using SIMA.Controladoras.General;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
namespace SIMA.SimaNetWeb.Auditoria
{
	/// <summary>
	/// Summary description for RequerimientosAsignados.
	/// </summary>
	public class ConsultaDeAccionesDeControlNoProgramadas : System.Web.UI.Page,IPaginaBase
	{
		#region Controles

		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Button btnConsultar;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
		protected System.Web.UI.WebControls.Label lblFechaInicio;
		protected eWorld.UI.CalendarPopup CalFechaInicio;
		protected System.Web.UI.WebControls.Label lblFechaFin;
		protected eWorld.UI.CalendarPopup CalFechaFin;
		#endregion Controles

		#region Constantes
		//Pies
		const string TEXTOFOOTERTOTAL = "Total :";
		const int    POSICIONFOOTERTOTAL = 1;
		
		//Ordenamiento
		const string URLPRINCIPAL    = "../Default.aspx";
		const string COLORDENAMIENTO = "IdAccionControlNoProgramada";

		//Columnas DataTable
	
		

		//Nombres de Controles
		
		
		
		
		//Paginas                    
		const string URLIMPRESION = "PopupImpresionConsultaDeAccionesDeControlNoProgramadas.aspx";
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltro;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;
		protected System.Web.UI.WebControls.ImageButton ibtnAtras;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminaFiltro;
	
		//Key Session y QueryString
		
		//Otros
		const string GRILLAVACIA ="No existe ninguna Acción de Control NoProgramada.";  

		#endregion Constantes

		#region Variables

		
		#endregion Variables


		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();

					Helper.ReiniciarSession();
					
					this.LlenarCombos();

					if (Session["AccCtrlNoProgFechaIni"]==null)
						Session["AccCtrlNoProgFechaIni"] = Helper.ObtenerFechaInicioBusqueda();
					else
						CalFechaInicio.SelectedDate = Convert.ToDateTime(Session["AccCtrlNoProgFechaIni"]);

					if (Session["AccCtrlNoProgFechaFin"]==null)
						Session["AccCtrlNoProgFechaFin"] = DateTime.Now.ToShortDateString();
					else
						CalFechaFin.SelectedDate    = Convert.ToDateTime(Session["AccCtrlNoProgFechaFin"]);

					if(this.ValidarFiltros())
					{
						//Graba en el Log la acción ejecutada
						LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Auditoria",this.ToString(),"Se consultó las Acciones de Control No Programadas en un Rango de Fechas entre el " + CalFechaInicio.SelectedDate.ToString() + " y el " + CalFechaFin.SelectedDate.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));

						this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO),Utilitario.Constantes.INDICEPAGINADEFAULT);
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
			this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
			this.ibtnFiltrar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnFiltrar_Click);
			this.ibtnEliminaFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminaFiltro_Click);
			this.ibtnImprimir.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnImprimir_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.ibtnAtras.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAtras_Click);
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
			CAccionControlNoProgramada oCAccionControlNoProgramada =  new CAccionControlNoProgramada();
			//DataTable dtAccionControlNoProgramada =  oCAccionControlNoProgramada.ConsultarAccionControlNoProgramada(CalFechaInicio.SelectedDate,CalFechaFin.SelectedDate);
			DataTable dtAccionControlNoProgramada =  oCAccionControlNoProgramada.ConsultarAccionControlNoProgramada(Convert.ToDateTime(Session["AccCtrlNoProgFechaIni"]),Convert.ToDateTime(Session["AccCtrlNoProgFechaFin"]));

			this.LlenarDatos();

			if(dtAccionControlNoProgramada!=null)
			{
				DataView dwAccionControlNoProgramada = dtAccionControlNoProgramada.DefaultView;
				dwAccionControlNoProgramada.Sort = columnaOrdenar ;
				dwAccionControlNoProgramada.RowFilter= Utilitario.Helper.ObtenerFiltro(this);

				grid.DataSource = dwAccionControlNoProgramada;
				CImpresion oCImpresion = new CImpresion();
				oCImpresion.GuardarDataImprimirExportar(dtAccionControlNoProgramada,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGOTITULOREPORTEACCIONCONTROLNOPROGRAMADA),columnaOrdenar,indicePagina);
				lblResultado.Visible = false;
				grid.Columns[0].FooterText = TEXTOFOOTERTOTAL;
				grid.Columns[POSICIONFOOTERTOTAL].FooterText = dwAccionControlNoProgramada.Count.ToString();
				
			}
			else
			{
				grid.DataSource = dtAccionControlNoProgramada;
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
			// TODO:  Add ConsultaDeCartasFianzas.LlenarCombos implementation
			DateTime fechaInicioBusqueda = Helper.ObtenerFechaInicioBusqueda();
			CalFechaInicio.SelectedDate = fechaInicioBusqueda;
			CalFechaInicio.VisibleDate = fechaInicioBusqueda;
		
		}

		public void LlenarDatos()
		{
		
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultaDeCartasFianzas.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultaDeCartasFianzas.RegistrandoJScript implementation
		}

		public void Imprimir()
		{
			ltlMensaje.Text = Helper.PopupImpresion(URLIMPRESION,650,700,false,false,false,true,true);
		}

		public void Exportar()
		{
			// TODO:  Add ConsultaDeCartasFianzas.Exportar implementation
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
			if(!Helper.ValidarRangoFechas(CalFechaInicio.SelectedDate,CalFechaFin.SelectedDate))
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJERANGOFECHAS));
				return false;
			}
			else
			{
				return true;
			}
		}

		#endregion

		

		
		

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(e.SortExpression),Helper.ObtenerIndicePagina());
		}

		private void btnConsultar_Click(object sender, System.EventArgs e)
		{
			
			Session["AccCtrlNoProgFechaIni"] = this.CalFechaInicio.SelectedDate;
			Session["AccCtrlNoProgFechaFin"] = this.CalFechaFin.SelectedDate;

			try
			{
				Helper.ReiniciarSession();

				if(this.ValidarFiltros())
				{
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Auditoria",this.ToString(),"Se consultó las Acciones de Control No Programadas en un Rango de Fechas entre el " + CalFechaInicio.SelectedDate.ToString() + " y el " + CalFechaFin.SelectedDate.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));

					this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO),Utilitario.Constantes.INDICEPAGINADEFAULT);
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
				SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
				Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
			}
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			grid.CurrentPageIndex=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);
		}

		private void ibtnImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Imprimir();
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				e.Item.Cells[1].Text = e.Item.Cells[1].Text.ToUpper();
				e.Item.Cells[2].Text = e.Item.Cells[2].Text.ToUpper();

				ImageButton img=(ImageButton)e.Item.Cells[9].FindControl("ibtnObservacion");
				img.Attributes.Add("Onclick",Helper.MostrarVentaModalTextoHTML("ACCION DE CONTROL NO PROGRAMADA: " + dr[Enumerados.ColumnasAccionControlNoProgramada.Descripcion.ToString()].ToString().ToUpper(), dr[Enumerados.ColumnasAccionControlNoProgramada.Observacion.ToString()].ToString().ToUpper(),400,600));

				e.Item.Cells[0].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
			}
		
		}

		private void ibtnFiltrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			CAccionControlNoProgramada oCAccionControlNoProgramada =  new CAccionControlNoProgramada();
			DataTable dtAccionControlNoProgramada =  oCAccionControlNoProgramada.ConsultarAccionControlNoProgramada(Convert.ToDateTime(Session["AccCtrlNoProgFechaIni"]),Convert.ToDateTime(Session["AccCtrlNoProgFechaFin"]));

			ltlMensaje.Text= Utilitario.Helper.ElaborarFiltro(this, dtAccionControlNoProgramada,"../Filtros.aspx","Descripcion;ACCION CORRECTIVA","*Solicitante;SOLICITANTE","*CentroOperativo;CO","*Area;AREA","FechaInicio;FI","FechaFin;FF","PorcAvance;%");
		}

		private void ibtnAtras_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Page.Response.Redirect(URLPRINCIPAL);
		}

		private void ibtnEliminaFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}
	}
}

