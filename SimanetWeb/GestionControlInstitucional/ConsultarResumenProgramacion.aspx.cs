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
	public class ConsultarResumenProgramacion : System.Web.UI.Page,IPaginaBase
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
		const string URLDETALLE = "ConsultarProgramacionActividades.aspx?";

		//Key Session y QueryString
		const string KEYQIDORGANISMO = "IdOrganismo";
		const string KEYQIDSITUACION = "IdSituacion";
		const string KEYQIDCENTROOPERATIVO = "IdCentroOperativo";

		const int SUPERADO = 0;
		const int PROCESO = 1;

		//Controles
		const string CONTROLPROCESOSP = "lblProcesoSP";
		const string CONTROLSUPERADASP= "lblSuperadoSP";
		const string CONTROLPROCESOSC = "lblProcesoSC";
		const string CONTROLSUPERADASC = "lblSuperadoSC";
		const string CONTROLPROCESOSCH = "lblProcesoSCH";
		const string CONTROLSUPERADASCH = "lblSuperadoSCH";
		const string CONTROLPROCESOSI = "lblProcesoSI";
		const string CONTROLSUPERADASI = "lblSuperadoSI";
		const string CONTROLTOTALPROCESO = "lblTotalProceso";
		const string CONTROLTOTALSUPERADO = "lblTotalSuperado";

		const string CONTROLSP = "lblSP";
		const string CONTROLSC = "lblSC";
		const string CONTROLSCH= "lblSCH";
		const string CONTROLSI = "lblSI";

		const string CONTROLPROCESOSPT = "lblTProcesoSP";
		const string CONTROLSUPERADASPT= "lblTSuperadoSP";
		const string CONTROLPROCESOSCT = "lblTProcesoSC";
		const string CONTROLSUPERADASCT = "lblTSuperadoSC";
		const string CONTROLPROCESOSCHT = "lblTProcesoSCH";
		const string CONTROLSUPERADASCHT = "lblTSuperadoSCH";
		const string CONTROLPROCESOSIT = "lblTProcesoSI";
		const string CONTROLSUPERADASIT = "lblTSuperadoSI";
		const string CONTROLTTOTALPROCESO = "lblTTotalProceso";
		const string CONTROLTTOTALSUPERADO = "lblTTotalSuperado";

		//JScript
		string JSVERIFICARELIMINAR = "return verificarEliminar(this.form,'cbxEliminar','" + Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO)+"','"+Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJEPREGUNTAELIMINACIONREGISTRO)+"');";
			
		//Otros
		const string GRILLAVACIA ="No existe ninguna Programación";

		#endregion Constantes

		#region Variables
		double acumProcesoSP = 0;
		double acumSuperadaSP = 0;
		double acumProcesoSC = 0;
		double acumSuperadaSC= 0;
		double acumProcesoSCH = 0;
		double acumSuperadaSCH= 0;
		double acumProcesoSI = 0;
		double acumSuperadaSI= 0;
		double acumTotalProceso = 0;
		double acumTotalSuperada= 0;
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
			CProgramacionInspecciones oCProgramacionInspecciones=  new CProgramacionInspecciones();
			DataTable dtResumenProgramacion =  oCProgramacionInspecciones.ConsultarResumenProgramacionesInspecciones();
			
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
			// TODO:  Add ConsultaDeCartasFianzas.LlenarCombos implementation
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
			//ltlMensaje.Text = Helper.PopupImpresion(URLIMPRESION,650,700,false,false,false,true,true);
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
				Label ControlSP=(Label)e.Item.Cells[2].FindControl(CONTROLSP);	
				ControlSP.Font.Underline=true;
				ControlSP.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.MostrarVentana(URLDETALLE,KEYQIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.SIMAPERU
					));
				ControlSP.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado("hGridPagina","hOrdenGrilla"));

				Label ControlSC=(Label)e.Item.Cells[3].FindControl(CONTROLSC);	
				ControlSC.Font.Underline=true;
				ControlSC.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.MostrarVentana(URLDETALLE,KEYQIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.SIMACALLAO
					));
				ControlSC.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado("hGridPagina","hOrdenGrilla"));

				Label ControlSCH=(Label)e.Item.Cells[4].FindControl(CONTROLSCH);	
				ControlSCH.Font.Underline=true;
				ControlSCH.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.MostrarVentana(URLDETALLE,KEYQIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.SIMACHIMBOTE
					));
				ControlSCH.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado("hGridPagina","hOrdenGrilla"));
			
				Label ControlSI=(Label)e.Item.Cells[5].FindControl(CONTROLSI);	
				ControlSI.Font.Underline=true;
				ControlSI.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.MostrarVentana(URLDETALLE,KEYQIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.SIMAIQUITOS
					));
				ControlSI.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado("hGridPagina","hOrdenGrilla"));
			}

			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				
				e.Item.Cells[0].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);

				e.Item.Cells[1].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.MostrarVentana(URLDETALLE,KEYQIDORGANISMO + Utilitario.Constantes.SIGNOIGUAL + 
					dr[Enumerados.ColumnasProgramacionInspecciones.IdOrganismo.ToString()] +
					Utilitario.Constantes.SIGNOAMPERSON +  Utilitario.Constantes.KEYMODOPAGINA +  
					Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.C.ToString()));
				e.Item.Cells[1].Font.Underline=true;
				e.Item.Cells[1].ForeColor= System.Drawing.Color.Blue;
				e.Item.Cells[1].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado("hGridPagina","hOrdenGrilla"));

				Label Control1=(Label)e.Item.Cells[2].FindControl(CONTROLPROCESOSP);	
				Control1.Text = Convert.ToInt32(dr[Enumerados.ColumnasProgramacionInspecciones.ProcesoSP.ToString()]).ToString();
				if (Convert.ToInt32(dr[Enumerados.ColumnasProgramacionInspecciones.ProcesoSP.ToString()].ToString())>0)
				{
					Control1.Font.Underline=true;
					Control1.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
						Helper.MostrarVentana(URLDETALLE,KEYQIDORGANISMO + Utilitario.Constantes.SIGNOIGUAL + 
						dr[Enumerados.ColumnasProgramacionInspecciones.IdOrganismo.ToString()] +
						Utilitario.Constantes.SIGNOAMPERSON +  Utilitario.Constantes.KEYMODOPAGINA +  
						Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.C.ToString() + Utilitario.Constantes.SIGNOAMPERSON +
						KEYQIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.SIMAPERU + Utilitario.Constantes.SIGNOAMPERSON +
						KEYQIDSITUACION + Utilitario.Constantes.SIGNOIGUAL + PROCESO
						));
					Control1.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado("hGridPagina","hOrdenGrilla"));
				}
				
				Label Control2=(Label)e.Item.Cells[2].FindControl(CONTROLSUPERADASP);	
				Control2.Text = Convert.ToInt32(dr[Enumerados.ColumnasProgramacionInspecciones.SuperadoSP.ToString()]).ToString();
				if (Convert.ToInt32(dr[Enumerados.ColumnasProgramacionInspecciones.SuperadoSP.ToString()].ToString())>0)
				{
					Control2.Font.Underline=true;
					Control2.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
						Helper.MostrarVentana(URLDETALLE,KEYQIDORGANISMO + Utilitario.Constantes.SIGNOIGUAL + 
						dr[Enumerados.ColumnasProgramacionInspecciones.IdOrganismo.ToString()] +
						Utilitario.Constantes.SIGNOAMPERSON +  Utilitario.Constantes.KEYMODOPAGINA +  
						Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.C.ToString() + Utilitario.Constantes.SIGNOAMPERSON +
						KEYQIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.SIMAPERU + Utilitario.Constantes.SIGNOAMPERSON +
						KEYQIDSITUACION + Utilitario.Constantes.SIGNOIGUAL + SUPERADO
						));
					Control2.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado("hGridPagina","hOrdenGrilla"));
				}

				Label Control3=(Label)e.Item.Cells[3].FindControl(CONTROLPROCESOSC);	
				Control3.Text = Convert.ToInt32(dr[Enumerados.ColumnasProgramacionInspecciones.ProcesoSC.ToString()]).ToString();
				if (Convert.ToInt32(dr[Enumerados.ColumnasProgramacionInspecciones.ProcesoSC.ToString()].ToString())>0)
				{
					Control3.Font.Underline=true;
					Control3.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
						Helper.MostrarVentana(URLDETALLE,KEYQIDORGANISMO + Utilitario.Constantes.SIGNOIGUAL + 
						dr[Enumerados.ColumnasProgramacionInspecciones.IdOrganismo.ToString()] +
						Utilitario.Constantes.SIGNOAMPERSON +  Utilitario.Constantes.KEYMODOPAGINA +  
						Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.C.ToString() + Utilitario.Constantes.SIGNOAMPERSON +
						KEYQIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.SIMACALLAO + Utilitario.Constantes.SIGNOAMPERSON +
						KEYQIDSITUACION + Utilitario.Constantes.SIGNOIGUAL + PROCESO
						));
					Control3.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado("hGridPagina","hOrdenGrilla"));
				}

				Label Control4=(Label)e.Item.Cells[3].FindControl(CONTROLSUPERADASC);	
				Control4.Text = Convert.ToInt32(dr[Enumerados.ColumnasProgramacionInspecciones.SuperadoSC.ToString()]).ToString();
				if (Convert.ToInt32(dr[Enumerados.ColumnasProgramacionInspecciones.SuperadoSC.ToString()].ToString())>0)
				{
					Control4.Font.Underline=true;
					Control4.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
						Helper.MostrarVentana(URLDETALLE,KEYQIDORGANISMO + Utilitario.Constantes.SIGNOIGUAL + 
						dr[Enumerados.ColumnasProgramacionInspecciones.IdOrganismo.ToString()] +
						Utilitario.Constantes.SIGNOAMPERSON +  Utilitario.Constantes.KEYMODOPAGINA +  
						Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.C.ToString() + Utilitario.Constantes.SIGNOAMPERSON +
						KEYQIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.SIMACALLAO + Utilitario.Constantes.SIGNOAMPERSON +
						KEYQIDSITUACION + Utilitario.Constantes.SIGNOIGUAL + SUPERADO
						));
					Control4.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado("hGridPagina","hOrdenGrilla"));
				}

				Label Control5=(Label)e.Item.Cells[4].FindControl(CONTROLPROCESOSCH);	
				Control5.Text = Convert.ToInt32(dr[Enumerados.ColumnasProgramacionInspecciones.ProcesoSCH.ToString()]).ToString();
				if (Convert.ToInt32(dr[Enumerados.ColumnasProgramacionInspecciones.ProcesoSCH.ToString()].ToString())>0)
				{
					Control5.Font.Underline=true;
					Control5.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
						Helper.MostrarVentana(URLDETALLE,KEYQIDORGANISMO + Utilitario.Constantes.SIGNOIGUAL + 
						dr[Enumerados.ColumnasProgramacionInspecciones.IdOrganismo.ToString()] +
						Utilitario.Constantes.SIGNOAMPERSON +  Utilitario.Constantes.KEYMODOPAGINA +  
						Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.C.ToString() + Utilitario.Constantes.SIGNOAMPERSON +
						KEYQIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.SIMACHIMBOTE + Utilitario.Constantes.SIGNOAMPERSON +
						KEYQIDSITUACION + Utilitario.Constantes.SIGNOIGUAL + PROCESO
						));
					Control5.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado("hGridPagina","hOrdenGrilla"));
				}

				Label Control6=(Label)e.Item.Cells[4].FindControl(CONTROLSUPERADASCH);	
				Control6.Text = Convert.ToInt32(dr[Enumerados.ColumnasProgramacionInspecciones.SuperadoSCH.ToString()]).ToString();
				if (Convert.ToInt32(dr[Enumerados.ColumnasProgramacionInspecciones.SuperadoSCH.ToString()].ToString())>0)
				{
					Control6.Font.Underline=true;
					Control6.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
						Helper.MostrarVentana(URLDETALLE,KEYQIDORGANISMO + Utilitario.Constantes.SIGNOIGUAL + 
						dr[Enumerados.ColumnasProgramacionInspecciones.IdOrganismo.ToString()] +
						Utilitario.Constantes.SIGNOAMPERSON +  Utilitario.Constantes.KEYMODOPAGINA +  
						Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.C.ToString() + Utilitario.Constantes.SIGNOAMPERSON +
						KEYQIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.SIMACHIMBOTE + Utilitario.Constantes.SIGNOAMPERSON +
						KEYQIDSITUACION + Utilitario.Constantes.SIGNOIGUAL + SUPERADO
						));
					Control6.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado("hGridPagina","hOrdenGrilla"));
				}

				Label Control7=(Label)e.Item.Cells[5].FindControl(CONTROLPROCESOSI);	
				Control7.Text = Convert.ToInt32(dr[Enumerados.ColumnasProgramacionInspecciones.ProcesoSI.ToString()]).ToString();
				if (Convert.ToInt32(dr[Enumerados.ColumnasProgramacionInspecciones.ProcesoSI.ToString()].ToString())>0)
				{
					Control7.Font.Underline=true;
					Control7.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
						Helper.MostrarVentana(URLDETALLE,KEYQIDORGANISMO + Utilitario.Constantes.SIGNOIGUAL + 
						dr[Enumerados.ColumnasProgramacionInspecciones.IdOrganismo.ToString()] +
						Utilitario.Constantes.SIGNOAMPERSON +  Utilitario.Constantes.KEYMODOPAGINA +  
						Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.C.ToString() + Utilitario.Constantes.SIGNOAMPERSON +
						KEYQIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.SIMAIQUITOS + Utilitario.Constantes.SIGNOAMPERSON +
						KEYQIDSITUACION + Utilitario.Constantes.SIGNOIGUAL + PROCESO
						));
					Control7.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado("hGridPagina","hOrdenGrilla"));
				}

				Label Control8=(Label)e.Item.Cells[5].FindControl(CONTROLSUPERADASI);	
				Control8.Text = Convert.ToInt32(dr[Enumerados.ColumnasProgramacionInspecciones.SuperadoSI.ToString()]).ToString();
				if (Convert.ToInt32(dr[Enumerados.ColumnasProgramacionInspecciones.SuperadoSI.ToString()].ToString())>0)
				{
					Control8.Font.Underline=true;
					Control8.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
						Helper.MostrarVentana(URLDETALLE,KEYQIDORGANISMO + Utilitario.Constantes.SIGNOIGUAL + 
						dr[Enumerados.ColumnasProgramacionInspecciones.IdOrganismo.ToString()] +
						Utilitario.Constantes.SIGNOAMPERSON +  Utilitario.Constantes.KEYMODOPAGINA +  
						Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.C.ToString() + Utilitario.Constantes.SIGNOAMPERSON +
						KEYQIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.SIMAIQUITOS + Utilitario.Constantes.SIGNOAMPERSON +
						KEYQIDSITUACION + Utilitario.Constantes.SIGNOIGUAL + SUPERADO
						));
					Control8.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado("hGridPagina","hOrdenGrilla"));
				}

				Label Control9=(Label)e.Item.Cells[6].FindControl(CONTROLTOTALPROCESO);	
				Control9.Text = Convert.ToInt32(dr[Enumerados.ColumnasProgramacionInspecciones.TotalProceso.ToString()]).ToString();
				if (Convert.ToInt32(dr[Enumerados.ColumnasProgramacionInspecciones.TotalProceso.ToString()].ToString())>0)
				{
					Control9.Font.Underline=true;
					Control9.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
						Helper.MostrarVentana(URLDETALLE,KEYQIDORGANISMO + Utilitario.Constantes.SIGNOIGUAL + 
						dr[Enumerados.ColumnasProgramacionInspecciones.IdOrganismo.ToString()] +
						Utilitario.Constantes.SIGNOAMPERSON +  Utilitario.Constantes.KEYMODOPAGINA +  
						Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.C.ToString() + Utilitario.Constantes.SIGNOAMPERSON +
						KEYQIDSITUACION + Utilitario.Constantes.SIGNOIGUAL + PROCESO
						));
					Control9.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado("hGridPagina","hOrdenGrilla"));
				}

				Label Control10=(Label)e.Item.Cells[6].FindControl(CONTROLTOTALSUPERADO);	
				Control10.Text = Convert.ToInt32(dr[Enumerados.ColumnasProgramacionInspecciones.TotalSuperado.ToString()]).ToString();
				if (Convert.ToInt32(dr[Enumerados.ColumnasProgramacionInspecciones.TotalSuperado.ToString()].ToString())>0)
				{
					Control10.Font.Underline=true;
					Control10.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
						Helper.MostrarVentana(URLDETALLE,KEYQIDORGANISMO + Utilitario.Constantes.SIGNOIGUAL + 
						dr[Enumerados.ColumnasProgramacionInspecciones.IdOrganismo.ToString()] +
						Utilitario.Constantes.SIGNOAMPERSON +  Utilitario.Constantes.KEYMODOPAGINA +  
						Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.C.ToString() + Utilitario.Constantes.SIGNOAMPERSON +
						KEYQIDSITUACION + Utilitario.Constantes.SIGNOIGUAL + SUPERADO
						));
					Control10.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado("hGridPagina","hOrdenGrilla"));
				}
				Helper.FiltroporSeleccionConfiguraColumna(e,grid);	

				acumProcesoSP+= Convert.ToDouble(dr[Enumerados.ColumnasProgramacionInspecciones.ProcesoSP.ToString()]);
				acumSuperadaSP+= Convert.ToDouble(dr[Enumerados.ColumnasProgramacionInspecciones.SuperadoSP.ToString()]);
				acumProcesoSC+= Convert.ToDouble(dr[Enumerados.ColumnasProgramacionInspecciones.ProcesoSC.ToString()]);
				acumSuperadaSC+= Convert.ToDouble(dr[Enumerados.ColumnasProgramacionInspecciones.SuperadoSC.ToString()]);
				acumProcesoSCH+= Convert.ToDouble(dr[Enumerados.ColumnasProgramacionInspecciones.ProcesoSCH.ToString()]);
				acumSuperadaSCH+= Convert.ToDouble(dr[Enumerados.ColumnasProgramacionInspecciones.SuperadoSCH.ToString()]);
				acumProcesoSI+= Convert.ToDouble(dr[Enumerados.ColumnasProgramacionInspecciones.ProcesoSI.ToString()]);
				acumSuperadaSI+= Convert.ToDouble(dr[Enumerados.ColumnasProgramacionInspecciones.SuperadoSI.ToString()]);
				acumTotalProceso+= Convert.ToDouble(dr[Enumerados.ColumnasProgramacionInspecciones.TotalProceso.ToString()]);
				acumTotalSuperada+= Convert.ToDouble(dr[Enumerados.ColumnasProgramacionInspecciones.TotalSuperado.ToString()]);
			}

			if(e.Item.ItemType == ListItemType.Footer)
			{
				Label Control11=(Label)e.Item.Cells[2].FindControl(CONTROLPROCESOSPT);	
				Control11.Text = Convert.ToInt32(acumProcesoSP).ToString();

				Label Control12=(Label)e.Item.Cells[2].FindControl(CONTROLSUPERADASPT);	
				Control12.Text = Convert.ToInt32(acumSuperadaSP).ToString();

				Label Control13=(Label)e.Item.Cells[3].FindControl(CONTROLPROCESOSCT);	
				Control13.Text = Convert.ToInt32(acumProcesoSC).ToString();

				Label Control14=(Label)e.Item.Cells[3].FindControl(CONTROLSUPERADASCT);	
				Control14.Text = Convert.ToInt32(acumSuperadaSC).ToString();

				Label Control15=(Label)e.Item.Cells[4].FindControl(CONTROLPROCESOSCHT);	
				Control15.Text = Convert.ToInt32(acumProcesoSCH).ToString();
			
				Label Control16=(Label)e.Item.Cells[4].FindControl(CONTROLSUPERADASCHT);	
				Control16.Text = Convert.ToInt32(acumSuperadaSCH).ToString();

				Label Control17=(Label)e.Item.Cells[5].FindControl(CONTROLPROCESOSIT);	
				Control17.Text = Convert.ToInt32(acumProcesoSI).ToString();

				Label Control18=(Label)e.Item.Cells[5].FindControl(CONTROLSUPERADASIT);	
				Control18.Text = Convert.ToInt32(acumSuperadaSI).ToString();

				Label Control19=(Label)e.Item.Cells[6].FindControl(CONTROLTTOTALPROCESO);	
				Control19.Text = Convert.ToInt32(acumTotalProceso).ToString();

				Label Control20=(Label)e.Item.Cells[6].FindControl(CONTROLTTOTALSUPERADO);	
				Control20.Text = Convert.ToInt32(acumTotalSuperada).ToString();			
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

	}
}