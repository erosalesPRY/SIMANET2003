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
using SIMA.Controladoras.GestionControlInstitucional;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using NullableTypes;
using System.IO;
using SIMA.EntidadesNegocio;

namespace SIMA.SimaNetWeb.Legal
{
	/// <summary>
	/// Summary description for RequerimientosAsignados.
	/// </summary>
	public class ConsultarResumenObservacionesAuditoria : System.Web.UI.Page,IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hOrdenGrilla;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;		
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdTipoSeguimiento;
		#endregion Controles

		#region Constantes
		//Numero de Registro
		const string TEXTOFOOTERTOTAL = "Total:";
		const int POSICIONFOOTERTOTAL = 1;
		const int POSICIONINICIALCOMBO = 0;

		//Ordenamiento
		const string COLORDENAMIENTO = "IdOrganismo";

		//Nombres de Controles
		const string CONTROLINK = "hlkId";
		int sumaProceso	= 0;
		int sumaSuperados	= 0;
		int sumaInformados	= 0;
		int sumaPendientes	= 0;
		int sumaTOTAL= 0;
		//Paginas
		const string URLDETALLE = "ConsultarObservacionesAuditoria.aspx?";
		const string URLIMPRESION="PoppupImpresionResumenObservacionesAuditoria.aspx?";

		//Key Session y QueryString
		const string KEYQIDACTIVIDAD= "IdActividad";
		const string KEYQIDORGANISMO = "IdOrganismo";
		const string KEYQIDSITUACION = "IdSituacion";
		const string KEYQIDCENTROOPERATIVO = "IdCentroOperativo";
		const string KEYQIDPERIODO = "IdPeriodo";
		const string KEYQDESCRIPCION= "Descripcion";
		const string KEYQIDDOCUMENTOAUDITORIA = "IdDocumentoAuditoria";
		const string KEYQIDTIPOSEGUIMIENTO ="IdTipoSeguimiento";	
		const string KEYQIDSUBORGANISMO="IdSubOrganismo";
		const string KEYQIDTIPOORGANISMO ="IdTipoOrganismo";
		//Controles

		//JScript
		string JSVERIFICARELIMINAR = "return verificarEliminar(this.form,'cbxEliminar','" + Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO)+"','"+Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJEPREGUNTAELIMINACIONREGISTRO)+"');";
			
		//Otros
		const string GRILLAVACIA ="No existe ninguna Observación";

		#endregion Constantes

		#region Variables
		int acumProceso = 0;
		int acumSuperadas = 0;
		int acumInformado = 0;
		int acumPendientes = 0;
		int acumTotal= 0;		
		DataTable dtResumenProgramacion;

		#endregion Variables
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();

					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"OCI",this.ToString(),"Se consultó la Programación.",Enumerados.NivelesErrorLog.I.ToString()));
					this.LlenarDatos();
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
			lblTitulo.Text = Page.Request.QueryString[KEYQDESCRIPCION];

			CObservacionesAuditoria oCObservacionesAuditoria=  new CObservacionesAuditoria();
			dtResumenProgramacion =  oCObservacionesAuditoria.ConsultarObservacionesAuditoriaPorOrganismo(
				Convert.ToInt32(Page.Request.QueryString[KEYQIDORGANISMO]),
				Convert.ToInt32(Page.Request.QueryString[KEYQIDACTIVIDAD]),
				Convert.ToInt32(Page.Request.QueryString[KEYQIDPERIODO]),
				Convert.ToInt32(Page.Request.QueryString[KEYQIDSITUACION]),
				Convert.ToInt32(Page.Request.QueryString[KEYQIDTIPOSEGUIMIENTO]),
				Convert.ToInt32(Page.Request.QueryString[KEYQIDSUBORGANISMO]),
				Convert.ToInt32(Page.Request.QueryString[KEYQIDTIPOORGANISMO]));
			
			if(dtResumenProgramacion!=null)
			{
				DataView dwResumenProgramacion = dtResumenProgramacion.DefaultView;
				dwResumenProgramacion.Sort = columnaOrdenar ;
				dwResumenProgramacion.RowFilter = Utilitario.Helper.ObtenerFiltro();

				if (dwResumenProgramacion.Count == 0)
				{
					grid.DataSource = null; 
					lblResultado.Text = GRILLAVACIA;
					lblResultado.Visible = true;
				}
				else
				{
					grid.DataSource = dwResumenProgramacion;
					grid.CurrentPageIndex =indicePagina;
					grid.Columns[Utilitario.Constantes.POSICIONFOOTERTOTAL].FooterText = Utilitario.Constantes.TEXTOFOOTERTOTAL;
					grid.Columns[Utilitario.Constantes.POSICIONTOTAL].FooterText = dwResumenProgramacion.Count.ToString();

					lblResultado.Visible = false;
				
					foreach(DataRow dr in dtResumenProgramacion.Rows)
					{
						sumaProceso +=	Convert.ToInt32(dr[Enumerados.ColumnasObservacionesAuditoria.Superados.ToString()]);
						sumaSuperados +=	Convert.ToInt32(dr[Enumerados.ColumnasObservacionesAuditoria.Proceso.ToString()]);
						sumaInformados +=	Convert.ToInt32(dr["informado"]);
						sumaPendientes +=	Convert.ToInt32(dr["pendientes"]);
						sumaTOTAL+= Convert.ToInt32(dr[Enumerados.ColumnasObservacionesAuditoria.Total.ToString()]);
					}
				
					acumProceso = sumaProceso;
					acumSuperadas = sumaSuperados;
					acumInformado=sumaInformados;
					acumPendientes=sumaPendientes;
					acumTotal = sumaTOTAL;
				
				
				}
			}
			else
			{
				grid.DataSource = dtResumenProgramacion;
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
		}

		public void LlenarDatos()
		{
				//Session["IDSITUACION"] = Page.Request.QueryString[KEYQIDSITUACION].ToString();
		}

		public void LlenarJScript()
		{

		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultaDeCartasFianzas.RegistrandoJScript implementation
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

		#endregion


		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				Helper.FiltroporSeleccionConfiguraColumna(e,grid);	

				e.Item.Cells[0].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);

				e.Item.Cells[0].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.MostrarVentana(URLDETALLE,Utilitario.Constantes.KEYMODOPAGINA +  
					Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.C.ToString() +
					Utilitario.Constantes.SIGNOAMPERSON  + KEYQIDSITUACION + Utilitario.Constantes.SIGNOIGUAL +Page.Request.QueryString[KEYQIDSITUACION].ToString() +
					Utilitario.Constantes.SIGNOAMPERSON  + KEYQIDTIPOSEGUIMIENTO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQIDTIPOSEGUIMIENTO]+
					Utilitario.Constantes.SIGNOAMPERSON + KEYQIDDOCUMENTOAUDITORIA + Utilitario.Constantes.SIGNOIGUAL + 
					dr[Enumerados.ColumnasObservacionesAuditoria.IdDocumentoAuditoria.ToString()]));
				e.Item.Cells[0].Font.Underline=true;
				e.Item.Cells[0].ForeColor= System.Drawing.Color.Blue;
				e.Item.Cells[0].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado("hGridPagina","hOrdenGrilla"));

				

				
					
			}
			if(e.Item.ItemType == ListItemType.Footer)
			{
				

				e.Item.Cells[5].Text = acumProceso.ToString();
				e.Item.Cells[7].Text = acumSuperadas.ToString();
				e.Item.Cells[4].Text = sumaPendientes.ToString();
				e.Item.Cells[6].Text = sumaInformados.ToString();
				e.Item.Cells[8].Text = acumTotal.ToString();
			}
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.hGridPagina.Value = e.NewPageIndex.ToString();
			this.LlenarGrillaOrdenamientoPaginacion(this.hOrdenGrilla.Value,e.NewPageIndex);		
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.hOrdenGrilla.Value = Helper.GenerarExpresionOrdenamiento(e.SortExpression);
			this.LlenarGrillaOrdenamientoPaginacion(this.hOrdenGrilla.Value,Helper.ObtenerIndicePagina());
		}

		private void ddlbSituacion_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(this.hOrdenGrilla.Value,Convert.ToInt32(this.hGridPagina.Value));
		}
	}
}