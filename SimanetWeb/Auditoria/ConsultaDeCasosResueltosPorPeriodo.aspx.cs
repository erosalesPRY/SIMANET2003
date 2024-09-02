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
using SIMA.EntidadesNegocio.Auditoria;

namespace SIMA.SimaNetWeb.Auditoria
{
	/// <summary>
	/// Summary description for RequerimientosAsignados.
	/// </summary>
	public class ConsultaDeCasosResueltosPorPeriodo : System.Web.UI.Page,IPaginaBase
	{
		#region Controles

		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblTexto;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
		protected System.Web.UI.WebControls.Label lblInformeEmitidoData;
		protected System.Web.UI.WebControls.Label lblCentroOperativoData;
		protected System.Web.UI.WebControls.Label lblAreaData;
		protected System.Web.UI.WebControls.Label lblDescripcionData;
		protected System.Web.UI.WebControls.Label lblObservacionData;
		protected System.Web.UI.WebControls.Label lblPorcentajeAvanceData;
		protected System.Web.UI.WebControls.Label lblFechaInicioData;
		protected System.Web.UI.WebControls.Label lblFechaFinData;
		protected System.Web.UI.WebControls.Label lblFechaFin;
		protected System.Web.UI.WebControls.Label lblFechaInicio;
		protected System.Web.UI.WebControls.Label lblPorcentajeAvance;
		protected System.Web.UI.WebControls.Label lblObservacion;
		protected System.Web.UI.WebControls.Label lblDescripcion;
		protected System.Web.UI.WebControls.Label lblArea;
		protected System.Web.UI.WebControls.Label lblCentroOperativo;
		protected System.Web.UI.WebControls.Label lblInformeEmitido;
		protected System.Web.UI.HtmlControls.HtmlTable tDetalle;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected projDataGridWeb.DataGridWeb DataGridWeb1;
		protected System.Web.UI.WebControls.Button Button1;
		protected eWorld.UI.CalendarPopup CalFechaFin;
		protected eWorld.UI.CalendarPopup CalFechaInicio;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblPeriodo;
		protected System.Web.UI.WebControls.DropDownList ddlbPeriodo;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvPeriodo;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;
		protected System.Web.UI.WebControls.ImageButton ibtnAtras;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminaFiltro;
		private   ListItem item =  new ListItem();

		#endregion Controles

		#region Constantes
		//Pies
		const string TEXTOFOOTERTOTAL = "Total :";
		const int    POSICIONFOOTERTOTAL = 2;
		
		//Ordenamiento
		const string COLORDENAMIENTO = "IdAccionCorrectiva";
		const string KEYQID = "Id";
		//Columnas DataTable
	
		

		//Nombres de Controles
		const string CONTROLINK = "hlkId";
		
		
		
		//Paginas
		const string URLPRINCIPAL= "../Default.aspx";
		const string URLIMPRESION = "PopupImpresionConsultaDeCasosResueltosPorPeriodo.aspx";
	
		//Key Session y QueryString
		
		//Otros
		const string GRILLAVACIA ="No existe ningún Caso Resuelto.";  

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
					
					this.LlenarJScript();
					
					this.LlenarCombos();
					
					tDetalle.Visible = false;

					if (Session["Periodo"]==null)
						Session["Periodo"] = DateTime.Now.Year.ToString();
					else
					{
						//ddlbPeriodo.SelectedItem.Text = Session["Periodo"].ToString();
						//this.ddlbPeriodo.Items.FindByText(Session["Periodo"].ToString());
						item = this.ddlbPeriodo.Items.FindByText(Session["Periodo"].ToString());
						if(item!=null)
						{item.Selected = true;}

					}


					if(this.ValidarFiltros())
					{
						//Graba en el Log la acción ejecutada
						LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Auditoria",this.ToString(),"Se consultó los Casos Resueltos del Periodo " + ddlbPeriodo.SelectedValue + ".",Enumerados.NivelesErrorLog.I.ToString()));

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

		/// <summary>
		/// Llena el combo de Periodos
		/// </summary>
		private void llenarPeriodos()
		{
			ListItem lItem = new ListItem(Constantes.TEXTOSSELECCIONAR,Constantes.VALORSELECCIONAR);
			ddlbPeriodo.DataSource = Helper.ObtenerPeriodos(DateTime.Now.Year - 5,DateTime.Now.Year);
			ddlbPeriodo.DataBind();
			//ddlbPeriodo.Items.Insert(0,lItem);
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
			this.ddlbPeriodo.SelectedIndexChanged += new System.EventHandler(this.ddlbPeriodo_SelectedIndexChanged);
			this.ibtnFiltrar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnFiltrar_Click);
			this.ibtnEliminaFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminaFiltro_Click);
			this.ibtnImprimir.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnImprimir_Click);
			this.grid.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.grid_EditCommand);
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
			CAccionCorrectiva oCAccionCorrectiva =  new CAccionCorrectiva();
//			DataTable dtAccionCorrectiva =  oCAccionCorrectiva.ConsultarCasosResueltosPorPeriodo(ddlbPeriodo.SelectedValue);
			DataTable dtAccionCorrectiva =  oCAccionCorrectiva.ConsultarCasosResueltosPorPeriodo(Session["Periodo"].ToString());

			tDetalle.Visible = false;
			if(dtAccionCorrectiva!=null)
			{
				DataView dwAccionCorrectiva = dtAccionCorrectiva.DefaultView;
				dwAccionCorrectiva.Sort = columnaOrdenar ;
				dwAccionCorrectiva.RowFilter= Utilitario.Helper.ObtenerFiltro(this);

				grid.DataSource = dwAccionCorrectiva;
				CImpresion oCImpresion = new CImpresion();
				oCImpresion.GuardarDataImprimirExportar(dtAccionCorrectiva,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGOTITULOREPORTEOBSERVACIONESLEVANTADAS),columnaOrdenar,indicePagina);
				lblResultado.Visible = false;
				grid.Columns[1].FooterText = TEXTOFOOTERTOTAL;
				grid.Columns[POSICIONFOOTERTOTAL].FooterText = dwAccionCorrectiva.Count.ToString();
				
			}
			else
			{
				grid.DataSource = dtAccionCorrectiva;
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
			
			this.llenarPeriodos();

		}

		public void LlenarDatos()
		{
			CMantenimientos	oCMantenimientos = new CMantenimientos();
			AccionCorrectivaBE oAccionCorrectivaBE = (AccionCorrectivaBE)oCMantenimientos.ListarDetalleDescripcion(Convert.ToInt32(ViewState[KEYQID]),Enumerados.ClasesNTAD.AccionCorrectivaNTAD.ToString());
			
			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Auditoria",this.ToString(),"Se consultó el Detalle del Caso Resuelto Nro. " + ViewState[KEYQID].ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));

			if(oAccionCorrectivaBE!=null)
			{

				lblDescripcionData.Text = oAccionCorrectivaBE.Descripcion;
				lblInformeEmitidoData.Text = oAccionCorrectivaBE.InformeEmitido;

				if(!oAccionCorrectivaBE.Observacion.IsNull)
				{
					lblObservacionData.Text = oAccionCorrectivaBE.Observacion.Value;
				}
				lblFechaInicioData.Text = oAccionCorrectivaBE.FechaInicio.ToString(Constantes.FORMATOFECHA3);

				if(!oAccionCorrectivaBE.FechaFin.IsNull)
				{
					lblFechaFinData.Text = oAccionCorrectivaBE.FechaFin.Value.ToString(Constantes.FORMATOFECHA3);
				
				}

				lblPorcentajeAvanceData.Text = oAccionCorrectivaBE.PorcentajeAvance.ToString(Constantes.FORMATODECIMAL2);
			
				lblAreaData.Text = oAccionCorrectivaBE.Area;
				lblCentroOperativoData.Text = oAccionCorrectivaBE.CentroOperativo;
			}
			else
			{
				lblDescripcionData.Text      = "";
				lblInformeEmitidoData.Text   = "";
				lblObservacionData.Text      = "";
				lblFechaInicioData.Text      = "";
				lblFechaFinData.Text         = "";
				lblPorcentajeAvanceData.Text = "";
				lblAreaData.Text             = "";
				lblCentroOperativoData.Text  = "";
			}
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultaDeCartasFianzas.LlenarJScript implementation
			string mensaje = Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEPERIODO);
			rfvPeriodo.ErrorMessage = mensaje;
			rfvPeriodo.ToolTip = mensaje;
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
			if(ddlbPeriodo.SelectedItem.Text == Constantes.TEXTOSSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEPERIODO));
				return false;	
			}

			return true;
			
		}

		#endregion

		

		
		

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(e.SortExpression),Helper.ObtenerIndicePagina());
		}

		private void btnConsultar_Click(object sender, System.EventArgs e)
		{
			Session["Periodo"] = this.ddlbPeriodo.SelectedValue;
			
			try
			{
				Helper.ReiniciarSession();

				if(this.ValidarFiltros())
				{
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Auditoria",this.ToString(),"Se consultó los Casos Resueltos del Periodo " + ddlbPeriodo.SelectedValue + ".",Enumerados.NivelesErrorLog.I.ToString()));

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

				e.Item.Cells[4].Text = e.Item.Cells[4].Text.ToUpper();

				LinkButton hlk = (LinkButton)e.Item.Cells[1].FindControl(CONTROLINK);
				e.Item.Cells[1].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				hlk.Text = Convert.ToString(dr[Enumerados.ColumnasAccionCorrectiva.Descripcion.ToString()].ToString().ToUpper());

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);

			}	
		}

		private void grid_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try
			{
				
				if(ViewState[KEYQID]==null)
				{
					tDetalle.Visible = true;
					ViewState[KEYQID] = Convert.ToInt32(e.Item.Cells[0].Text);
					this.LlenarDatos();
				}
				else if(Convert.ToInt32(ViewState[KEYQID]) != Convert.ToInt32(e.Item.Cells[0].Text))
				{
					tDetalle.Visible = true;
					ViewState[KEYQID] = Convert.ToInt32(e.Item.Cells[0].Text);
					this.LlenarDatos();
				}
				else
				{

					ViewState[KEYQID] = null;
					tDetalle.Visible = false;
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


		private void ddlbPeriodo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Session["Periodo"] = this.ddlbPeriodo.SelectedValue;
			
			try
			{
				Helper.ReiniciarSession();

				if(this.ValidarFiltros())
				{
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Auditoria",this.ToString(),"Se consultó los Casos Resueltos del Periodo " + ddlbPeriodo.SelectedValue + ".",Enumerados.NivelesErrorLog.I.ToString()));

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

		private void ibtnFiltrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			CAccionCorrectiva oCAccionCorrectiva =  new CAccionCorrectiva();
			DataTable dtAccionCorrectiva =  oCAccionCorrectiva.ConsultarCasosResueltosPorPeriodo(Session["Periodo"].ToString());

			ltlMensaje.Text= Utilitario.Helper.ElaborarFiltro(this, dtAccionCorrectiva, "../Filtros.aspx","Descripcion;ACCION CORRECTIVA","InformeEmitido;INFORME","*CentroOperativo;CO","*Area;AREA","FechaInicio;FI","FechaFin;FF","PorcAvance;%");
		}

		private void ibtnEliminaFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}

		private void ibtnAtras_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Page.Response.Redirect(URLPRINCIPAL);
		}
	}
}

