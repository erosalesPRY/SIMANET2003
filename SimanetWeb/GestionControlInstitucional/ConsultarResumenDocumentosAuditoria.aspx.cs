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
	public class ConsultarResumenDocumentosAuditoria : System.Web.UI.Page,IPaginaBase
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
		protected System.Web.UI.WebControls.DropDownList ddlbSituacion;
		protected System.Web.UI.WebControls.Label Label9;		
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminarFiltro;
		protected System.Web.UI.WebControls.ImageButton btnFiltrar;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DropDownList ddblObsSinSeguimiento;
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

		//Paginas
		const string URLDETALLE = "ConsultarResumenObservacionesAuditoria.aspx?";
		const string URLIMPRESION="PoppupImpresionResumenObservacionesAuditoria.aspx?";

		//Key Session y QueryString
		const string KEYQIDACTIVIDAD= "IdActividad";
		const string KEYQIDORGANISMO = "IdOrganismo";
		const string KEYQIDSITUACION = "IdSituacion";
		const string KEYQIDCENTROOPERATIVO = "IdCentroOperativo";
		const string KEYQIDPERIODO = "IdPeriodo";
		const string KEYQIDDOCUMENTOAUDITORIA = "IdDocumentoAuditoria";
		const string KEYQDESCRIPCION= "Descripcion";
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
		int acumProcesoSP = 0;
		int acumProcesoSC = 0;
		int acumProcesoSCH = 0;
		int acumProcesoSI = 0;
		int acumTotalProceso = 0;
		
		int sumaC=0, sumaP=0, sumaCH=0,	sumaI=0,sumaTotal=0;

		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.DropDownList ddblOrganismo;
		protected projDataGridWeb.DataGridWeb gridResumen;

		
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
			this.ddblOrganismo.SelectedIndexChanged += new System.EventHandler(this.ddblOrganismo_SelectedIndexChanged);
			this.ddlbSituacion.SelectedIndexChanged += new System.EventHandler(this.ddlbSituacion_SelectedIndexChanged);
			this.ddblObsSinSeguimiento.SelectedIndexChanged += new System.EventHandler(this.ddblObsSinSeguimiento_SelectedIndexChanged);
			this.btnFiltrar.Click += new System.Web.UI.ImageClickEventHandler(this.btnFiltrar_Click);
			this.ibtnEliminarFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminarFiltro_Click);
			this.ibtnImprimir.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnImprimir_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.gridResumen.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.gridResumen_ItemDataBound);
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
			CObservacionesAuditoria oCObservacionesAuditoria=  new CObservacionesAuditoria();
			dtResumenProgramacion =  oCObservacionesAuditoria.ConsultarResumenObservacionesAuditoriaPorSituacion(
				Convert.ToInt32(ddlbSituacion.SelectedValue),Convert.ToInt32(ddblObsSinSeguimiento.SelectedValue),ddblOrganismo.SelectedIndex!=0?Convert.ToInt32(ddblOrganismo.SelectedValue):0);
			DataTable dtResumen = oCObservacionesAuditoria.ConsultarResumenSituacionXCentroOperativo();
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
					
					if(ddblOrganismo.SelectedIndex==0)
					{
						grid.Columns[1].Visible=true;
						grid.Columns[Utilitario.Constantes.POSICIONTOTAL].FooterText = dwResumenProgramacion.Count.ToString();
					}
					else
					{
						grid.Columns[1].Visible=false;
					}

					foreach(DataRow dr in dtResumenProgramacion.Rows)
					{
						acumProcesoSP+=Convert.ToInt32(dr["sp"]);
						acumProcesoSC+=Convert.ToInt32(dr["sc"]);
						acumProcesoSCH+=Convert.ToInt32(dr["sch"]);
						acumProcesoSI+=Convert.ToInt32(dr["si"]);
						acumTotalProceso+=Convert.ToInt32(dr["total"]);
					}
					grid.DataSource = dwResumenProgramacion;
					grid.CurrentPageIndex =indicePagina;
					grid.Columns[Utilitario.Constantes.POSICIONFOOTERTOTAL].FooterText = Utilitario.Constantes.TEXTOFOOTERTOTAL;
					//grid.Columns[Utilitario.Constantes.POSICIONTOTAL].FooterText = dwResumenProgramacion.Count.ToString();
					gridResumen.DataSource=dtResumen;
					lblResultado.Visible = false;
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
				gridResumen.DataBind();
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
			this.llenarTipoSituacion();
		}

		private void llenarTipoSituacion()
		{
				
			CTablaTablas oCTablasTablas2 = new CTablaTablas();
			ddblOrganismo.DataSource= oCTablasTablas2.ListaTodosCombo(316);
			ddblOrganismo.DataTextField= Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddblOrganismo.DataValueField=Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddblOrganismo.DataBind();
			ddblOrganismo.Items.Insert(0,"Todos");

			if (ddblOrganismo.Items.Count>0)
			{
				ddblOrganismo.SelectedIndex=1;
			}
			
			
			CTablaTablas oCTablasTablas = new CTablaTablas();
						
			ddlbSituacion.DataSource= oCTablasTablas.ListaTodosCombo(Convert.ToInt32(Enumerados.TablasTabla.TipoSituacionObservacion));
			ddlbSituacion.DataTextField= Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbSituacion.DataValueField=Enumerados.ColumnasTablaTablas.Codigo.ToString ();
			ddlbSituacion.DataBind();

			if (ddlbSituacion.Items.Count>0)
			{
				ddlbSituacion.SelectedIndex=0;
			}

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
			// TODO:  Add ConsultaDeCartasFianzas.LlenarDatos implementation
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
			if(ddblOrganismo.SelectedIndex!=0)
			{
				ltlMensaje.Text = Helper.PopupImpresion(URLIMPRESION + KEYQIDPERIODO +
					Utilitario.Constantes.SIGNOIGUAL + ddlbSituacion.SelectedValue +
					Utilitario.Constantes.SIGNOAMPERSON + KEYQIDTIPOSEGUIMIENTO + Utilitario.Constantes.SIGNOIGUAL + ddblObsSinSeguimiento.SelectedValue +
					Utilitario.Constantes.SIGNOAMPERSON + KEYQIDTIPOORGANISMO + Utilitario.Constantes.SIGNOIGUAL + ddblOrganismo.SelectedValue.ToString(),780,400,false,false,false,true,true);
			}
			else
			{
				ltlMensaje.Text = Helper.PopupImpresion(URLIMPRESION + KEYQIDPERIODO +
					Utilitario.Constantes.SIGNOIGUAL + ddlbSituacion.SelectedValue +
					Utilitario.Constantes.SIGNOAMPERSON + KEYQIDTIPOSEGUIMIENTO + Utilitario.Constantes.SIGNOIGUAL + ddblObsSinSeguimiento.SelectedValue +
					Utilitario.Constantes.SIGNOAMPERSON + KEYQIDTIPOORGANISMO + Utilitario.Constantes.SIGNOIGUAL + "0",780,400,false,false,false,true,true);
			}
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
			if(e.Item.ItemType == ListItemType.Header)
			{
				e.Item.Cells[2].Font.Underline=true;
				e.Item.Cells[2].Style.Add("cursor","hand");
				e.Item.Cells[2].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.MostrarVentana(URLDETALLE,Utilitario.Constantes.KEYMODOPAGINA +  
					Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.C.ToString() + 
					Utilitario.Constantes.SIGNOAMPERSON + KEYQIDSITUACION + Utilitario.Constantes.SIGNOIGUAL + 
					ddlbSituacion.SelectedValue  +
					Utilitario.Constantes.SIGNOAMPERSON + KEYQIDTIPOSEGUIMIENTO + Utilitario.Constantes.SIGNOIGUAL + ddblObsSinSeguimiento.SelectedValue +
					Utilitario.Constantes.SIGNOAMPERSON + KEYQIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + 
					Utilitario.Constantes.SIMAPERU));
				e.Item.Cells[2].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado("hGridPagina","hOrdenGrilla","ddlbSituacion","ddblObsSinSeguimiento"));

				e.Item.Cells[3].Font.Underline=true;
				e.Item.Cells[3].Style.Add("cursor","hand");
				e.Item.Cells[3].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.MostrarVentana(URLDETALLE,Utilitario.Constantes.KEYMODOPAGINA +  
					Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.C.ToString() + 
					Utilitario.Constantes.SIGNOAMPERSON + KEYQIDSITUACION + Utilitario.Constantes.SIGNOIGUAL + 
					ddlbSituacion.SelectedValue  +
					Utilitario.Constantes.SIGNOAMPERSON + KEYQIDTIPOSEGUIMIENTO + Utilitario.Constantes.SIGNOIGUAL + ddblObsSinSeguimiento.SelectedValue.ToString() +
					Utilitario.Constantes.SIGNOAMPERSON + KEYQIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + 
					Utilitario.Constantes.SIMACALLAO));
				e.Item.Cells[3].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado("hGridPagina","hOrdenGrilla","ddlbSituacion","ddblObsSinSeguimiento"));
			
				e.Item.Cells[4].Font.Underline=true;
				e.Item.Cells[4].Style.Add("cursor","hand");
				e.Item.Cells[4].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.MostrarVentana(URLDETALLE,Utilitario.Constantes.KEYMODOPAGINA +  
					Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.C.ToString() + 
					Utilitario.Constantes.SIGNOAMPERSON + KEYQIDSITUACION + Utilitario.Constantes.SIGNOIGUAL + 
					ddlbSituacion.SelectedValue  +
					Utilitario.Constantes.SIGNOAMPERSON + KEYQIDTIPOSEGUIMIENTO + Utilitario.Constantes.SIGNOIGUAL + ddblObsSinSeguimiento.SelectedValue +
					Utilitario.Constantes.SIGNOAMPERSON + KEYQIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + 
					Utilitario.Constantes.SIMACHIMBOTE));
				e.Item.Cells[4].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado("hGridPagina","hOrdenGrilla","ddlbSituacion","ddblObsSinSeguimiento"));

				e.Item.Cells[5].Font.Underline=true;
				e.Item.Cells[5].Style.Add("cursor","hand");
				e.Item.Cells[5].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.MostrarVentana(URLDETALLE,Utilitario.Constantes.KEYMODOPAGINA +  
					Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.C.ToString() + 
					Utilitario.Constantes.SIGNOAMPERSON + KEYQIDSITUACION + Utilitario.Constantes.SIGNOIGUAL + 
					ddlbSituacion.SelectedValue  +
					Utilitario.Constantes.SIGNOAMPERSON + KEYQIDTIPOSEGUIMIENTO + Utilitario.Constantes.SIGNOIGUAL + ddblObsSinSeguimiento.SelectedValue.ToString() +
					Utilitario.Constantes.SIGNOAMPERSON + KEYQIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + 
					Utilitario.Constantes.SIMAIQUITOS));
				e.Item.Cells[5].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado("hGridPagina","hOrdenGrilla","ddlbSituacion","ddblObsSinSeguimiento"));
			}

			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				Helper.FiltroporSeleccionConfiguraColumna(e,grid);	

				e.Item.Cells[0].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				if(ddblOrganismo.SelectedIndex!=0)
				{
					e.Item.Cells[0].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
						Helper.MostrarVentana(URLDETALLE,Utilitario.Constantes.KEYMODOPAGINA +  
						Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.C.ToString() +
						Utilitario.Constantes.SIGNOAMPERSON +  KEYQIDORGANISMO + Utilitario.Constantes.SIGNOIGUAL + 
						dr[Enumerados.ColumnasObservacionesAuditoria.IdOrganismo.ToString()] +
						Utilitario.Constantes.SIGNOAMPERSON + KEYQIDACTIVIDAD + Utilitario.Constantes.SIGNOIGUAL + 
						dr[Enumerados.ColumnasObservacionesAuditoria.IdActividad.ToString()] +
						Utilitario.Constantes.SIGNOAMPERSON + KEYQIDSITUACION + Utilitario.Constantes.SIGNOIGUAL + 
						ddlbSituacion.SelectedValue  + Utilitario.Constantes.SIGNOAMPERSON + KEYQIDSUBORGANISMO +
						Utilitario.Constantes.SIGNOIGUAL + dr["IdSubOrganismo"].ToString()+
						Utilitario.Constantes.SIGNOAMPERSON + KEYQIDTIPOORGANISMO + Utilitario.Constantes.SIGNOIGUAL + 
						ddblOrganismo.SelectedValue.ToString() +
						Utilitario.Constantes.SIGNOAMPERSON + 
						KEYQIDTIPOSEGUIMIENTO + Utilitario.Constantes.SIGNOIGUAL + ddblObsSinSeguimiento.SelectedValue +
						Utilitario.Constantes.SIGNOAMPERSON + KEYQDESCRIPCION + Utilitario.Constantes.SIGNOIGUAL + 
						dr[Enumerados.ColumnasObservacionesAuditoria.Organismo.ToString()]  + Utilitario.Constantes.SIGNOMENOS + 
						dr[Enumerados.ColumnasObservacionesAuditoria.Actividad.ToString()]  + Utilitario.Constantes.SIGNOMENOS + 
						dr[Enumerados.ColumnasObservacionesAuditoria.Periodo.ToString()] +
						Utilitario.Constantes.SIGNOAMPERSON +  KEYQIDPERIODO + Utilitario.Constantes.SIGNOIGUAL + 
						dr[Enumerados.ColumnasObservacionesAuditoria.Periodo.ToString()]));
					e.Item.Cells[0].Font.Underline=true;
					e.Item.Cells[0].ForeColor= System.Drawing.Color.Blue;
					e.Item.Cells[0].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado("hGridPagina","hOrdenGrilla","ddlbSituacion","ddblObsSinSeguimiento","ddblOrganismo"));
				}
				else
				{
					e.Item.Cells[0].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
						Helper.MostrarVentana(URLDETALLE,Utilitario.Constantes.KEYMODOPAGINA +  
						Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.C.ToString() +
						Utilitario.Constantes.SIGNOAMPERSON +  KEYQIDORGANISMO + Utilitario.Constantes.SIGNOIGUAL + 
						dr[Enumerados.ColumnasObservacionesAuditoria.IdOrganismo.ToString()] +
						Utilitario.Constantes.SIGNOAMPERSON + KEYQIDACTIVIDAD + Utilitario.Constantes.SIGNOIGUAL + 
						dr[Enumerados.ColumnasObservacionesAuditoria.IdActividad.ToString()] +
						Utilitario.Constantes.SIGNOAMPERSON + KEYQIDSITUACION + Utilitario.Constantes.SIGNOIGUAL + 
						ddlbSituacion.SelectedValue  + Utilitario.Constantes.SIGNOAMPERSON + KEYQIDSUBORGANISMO +
						Utilitario.Constantes.SIGNOIGUAL + dr["IdSubOrganismo"].ToString()+
						Utilitario.Constantes.SIGNOAMPERSON + KEYQIDTIPOORGANISMO + Utilitario.Constantes.SIGNOIGUAL + 
						"0" +
						Utilitario.Constantes.SIGNOAMPERSON + 
						KEYQIDTIPOSEGUIMIENTO + Utilitario.Constantes.SIGNOIGUAL + ddblObsSinSeguimiento.SelectedValue +
						Utilitario.Constantes.SIGNOAMPERSON + KEYQDESCRIPCION + Utilitario.Constantes.SIGNOIGUAL + 
						dr[Enumerados.ColumnasObservacionesAuditoria.Organismo.ToString()]  + Utilitario.Constantes.SIGNOMENOS + 
						dr[Enumerados.ColumnasObservacionesAuditoria.Actividad.ToString()]  + Utilitario.Constantes.SIGNOMENOS + 
						dr[Enumerados.ColumnasObservacionesAuditoria.Periodo.ToString()] +
						Utilitario.Constantes.SIGNOAMPERSON +  KEYQIDPERIODO + Utilitario.Constantes.SIGNOIGUAL + 
						dr[Enumerados.ColumnasObservacionesAuditoria.Periodo.ToString()]));
					e.Item.Cells[0].Font.Underline=true;
					e.Item.Cells[0].ForeColor= System.Drawing.Color.Blue;
					e.Item.Cells[0].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado("hGridPagina","hOrdenGrilla","ddlbSituacion","ddblObsSinSeguimiento","ddblOrganismo"));
				}

			
			}
			if(e.Item.ItemType == ListItemType.Footer)
			{
				e.Item.Cells[5].Text = acumProcesoSP.ToString();
				e.Item.Cells[6].Text = acumProcesoSC.ToString();
				e.Item.Cells[7].Text = acumProcesoSCH.ToString();
				e.Item.Cells[8].Text = acumProcesoSI.ToString();
				e.Item.Cells[9].Text = acumTotalProceso.ToString();
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

		private void Button1_Click(object sender, System.EventArgs e)
		{
		
		}

		private void ibtnImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Imprimir();
		}

		private void btnFiltrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			CObservacionesAuditoria oCObservacionesAuditoria=  new CObservacionesAuditoria();
			dtResumenProgramacion =  oCObservacionesAuditoria.ConsultarResumenObservacionesAuditoriaPorSituacion(
				Convert.ToInt32(ddlbSituacion.SelectedValue),Convert.ToInt32(ddblObsSinSeguimiento.SelectedValue),ddblOrganismo.SelectedIndex!=0?Convert.ToInt32(ddblOrganismo.SelectedValue):0);

			ltlMensaje.Text= Utilitario.Helper.ElaborarFiltro(this,dtResumenProgramacion,"../Filtros.aspx"
				,Utilitario.Enumerados.ColumnasObservacionesAuditoria.Organismo.ToString()+";Organismo"
				,Utilitario.Enumerados.ColumnasObservacionesAuditoria.Actividad.ToString()+";Accion de Control"
				,"*" + Utilitario.Enumerados.ColumnasObservacionesAuditoria.Periodo.ToString()+";Periodo"
				);
		}

		private void ibtnEliminarFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();	
		}

		private void ddblObsSinSeguimiento_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(this.hOrdenGrilla.Value,Convert.ToInt32(this.hGridPagina.Value));
		}

		private void ddblOrganismo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(this.hOrdenGrilla.Value,Convert.ToInt32(this.hGridPagina.Value));
		}

		private void gridResumen_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.Header)
			{
				
				e.Item.Cells[1].ToolTip="SIMA PERU";
				e.Item.Cells[2].ToolTip="SIMA CALLAO";
				e.Item.Cells[3].ToolTip="SIMA CHIMBOTE";
				e.Item.Cells[4].ToolTip="SIMA IQUITOS";
			}
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				sumaC= sumaC+ Convert.ToInt32(dr["SC"]);
				sumaP= sumaP+ Convert.ToInt32(dr["SP"]);
				sumaCH= sumaCH+ Convert.ToInt32(dr["SCH"]);
				sumaI= sumaI+ Convert.ToInt32(dr["SI"]);
				sumaTotal=sumaTotal + Convert.ToInt32(dr["total"]);

			}
			if(e.Item.ItemType == ListItemType.Footer)
			{
				e.Item.Cells[1].Text = sumaP.ToString();
				e.Item.Cells[2].Text = sumaC.ToString();
				e.Item.Cells[3].Text = sumaCH.ToString();
				e.Item.Cells[4].Text = sumaI.ToString();
				e.Item.Cells[5].Text = sumaTotal.ToString();
			}
		}

	}
}