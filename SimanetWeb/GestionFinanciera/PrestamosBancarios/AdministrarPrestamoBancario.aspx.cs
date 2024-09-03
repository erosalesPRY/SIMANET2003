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
using SIMA.Controladoras.GestionFinanciera;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using NullableTypes;
using MetaBuilders.WebControls;


namespace SIMA.SimaNetWeb.GestionFinanciera.PrestamosBancarios
{
	/// <summary>
	/// Summary description for AdministrarPrestamoBancario.
	/// </summary>
	public class AdministrarPrestamoBancario : System.Web.UI.Page,IPaginaBase
	{
		#region Constantes
		const string OBJPARAMETROCONTABLE="ParametroPrestamos";
		const string GRILLAVACIA ="No existe ningún Registro.";  
		const string CONTROLINK="hlkNroPrestamo";
		const string CMPMONTOPTM="lblMontoPrestamo";
		const string CMPMONTOAMT="lblMontoAmortizado";
		const string CMPMONTOSAL="lblMontoSaldo";

		const string CMPFECHA1="lblFechaInicio";
		const string CMPFECHA2="lblFechaVence";

		

		//const string URLDETALLE="DetallePrestamoBancario.aspx?";
		const string URLDETALLE="AdministrarCronogramadePago.aspx?";
		const string URLPRINCIPAL="DetallePrestamoBancario.aspx?";
		const string COLORDENAMIENTO = "NroPrestamo";
		const string KEYIDPRESTAMO = "idPTM";
		const string KEYIDPERIODO ="Periodo";
		const string KEYIDCENTRO ="IdCentro";
		const string KEYIDENTIDADFINANCIERA ="IdEntidadFin";
		const string KEYIDSITUACION ="Estado";

		//DataTable and DataGrid
		const string TOOLTIPCENTROOP ="Centro de Operaciones";
		const string TOOLTIPNRODIASXVENCER ="Nro de dias por vencer";
		const string TOOLTIPTASAEFECTIVAANUAL ="Tasa Efectiva Anual";
		const string TOOLTIPMONEDA ="Moneda";

		//Otros
		const string SESSIONFINPTMO ="finPTMO";
		const string CTRLBUSCAR ="txtBuscar";

		#endregion
		#region Controles

		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DropDownList ddlbSituacion;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminaFiltro;
		protected System.Web.UI.WebControls.ImageButton ibtnAgregar;
		protected System.Web.UI.WebControls.ImageButton ibtnAmortizar;
		protected projDataGridWeb.DataGridWeb grid;
		protected projDataGridWeb.DataGridWeb gridResumen1;
		protected projDataGridWeb.DataGridWeb gridResumen2;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.HtmlControls.HtmlTable TblTabs;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.Label Label12;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox txtConcepto;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnFiltrarSeleccion;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPaginaSort;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		private   ListItem item =  new ListItem();
		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			this.grid.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(Utilitario.Helper.FooterSpan);
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					this.LlenarJScript();
					Helper.ReiniciarSession();
					this.LlenarCombos();
					//Graba en el Log la acción ejecutada
					Helper.ReestablecerPagina(this);
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionFinanciera",this.ToString(),"Se consultó Carta de Crédito.",Enumerados.NivelesErrorLog.I.ToString()));
					this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Convert.ToInt32(this.hGridPagina.Value));
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
					ltlMensaje.Text = Helper.MsgdbErrMostrarMesaje(true,oSIMAExcepcionIU.Error.ToString());
				}
			}		
			// Put user code to initialize the page here
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
			this.ddlbSituacion.SelectedIndexChanged += new System.EventHandler(this.ddlbSituacion_SelectedIndexChanged);
			this.ibtnFiltrar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnFiltrar_Click);
			this.ibtnEliminaFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminaFiltro_Click);
			this.ibtnAgregar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAgregar_Click);
			this.ibtnAmortizar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAmortizar_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.gridResumen1.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.gridResumen1_ItemDataBound);
			this.gridResumen1.SelectedIndexChanged += new System.EventHandler(this.gridResumen1_SelectedIndexChanged);
			this.gridResumen2.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.gridResumen2_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void grid_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
		}
		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add AdministrarPrestamoBancario.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarPrestamoBancario.LlenarGrillaOrdenamiento implementation
		}

		private void GenerarResumen(DataTable dt)
		{
			if (dt!=null)
			{
				int NroResumen1	 = 4;
				CResumenItem oCResumenItem1 = new CResumenItem();
				DataTable dtFinal1= Helper.Resumen(oCResumenItem1.ObtenerConfiDataResumen(NroResumen1),dt);
				gridResumen1.DataSource =dtFinal1;

				int NroResumen2 = 5;
				CResumenItem oCResumenItem2 = new CResumenItem();
				DataTable dtFinal2= Helper.Resumen(oCResumenItem2.ObtenerConfiDataResumen(NroResumen2),dt);
				gridResumen2.DataSource =dtFinal2;
			}
			else
			{
				gridResumen1.DataSource =dt;
				gridResumen2.DataSource =dt;
			}
			gridResumen1.DataBind();
			gridResumen2.DataBind();
		}
		private void GenerarResumen(DataView dt)
		{
			if (dt!=null)
			{
				int NroResumen1	 = 4;
				CResumenItem oCResumenItem1 = new CResumenItem();
				DataTable dtFinal1= Helper.Resumen(oCResumenItem1.ObtenerConfiDataResumen(NroResumen1),dt);
				gridResumen1.DataSource =dtFinal1;

				int NroResumen2 = 5;
				CResumenItem oCResumenItem2 = new CResumenItem();
				DataTable dtFinal2= Helper.Resumen(oCResumenItem2.ObtenerConfiDataResumen(NroResumen2),dt);
				gridResumen2.DataSource =dtFinal2;
			}
			else
			{
				gridResumen1.DataSource =dt;
				gridResumen2.DataSource =dt;
			}
			gridResumen1.DataBind();
			gridResumen2.DataBind();
		}
		private DataTable ObtenerDatos()
		{
			CPrestamoBancario oCPrestamoBancario = new CPrestamoBancario();
			ControlesUsuario.GestionFinanciera.ParametroContable usc_ParametroContable =(ControlesUsuario.GestionFinanciera.ParametroContable)Session[OBJPARAMETROCONTABLE];
			return oCPrestamoBancario.AdministrarPrestamosBancarios(Convert.ToInt32(this.ddlbSituacion.SelectedValue),
																	Utilitario.Constantes.IDDEFAULT,
																	Utilitario.Constantes.IDDEFAULT,
																	CNetAccessControl.GetIdUser());
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			
			this.txtConcepto.Text=String.Empty;
			DataTable dtPrestamoBancario = this.ObtenerDatos();
			DataView dwPrestamoBancario = new DataView();
			if(dtPrestamoBancario!=null)
			{
				dwPrestamoBancario = dtPrestamoBancario.DefaultView;
				dwPrestamoBancario.RowFilter = Helper.ObtenerFiltro();
				dwPrestamoBancario.Sort = columnaOrdenar;
				this.GenerarResumen(dwPrestamoBancario);
				grid.Columns[Utilitario.Constantes.POSICIONFOOTERTOTAL].FooterText = Utilitario.Constantes.TEXTOFOOTERTOTAL + Utilitario.Constantes.ESPACIO + dwPrestamoBancario.Count.ToString();
				grid.DataSource = dwPrestamoBancario;
				grid.CurrentPageIndex = indicePagina;

				lblResultado.Visible = false;


			}
			else
			{
				dwPrestamoBancario = null;
				this.GenerarResumen(dwPrestamoBancario);
				grid.DataSource = dtPrestamoBancario;
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
			// TODO:  Add AdministrarPrestamoBancario.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			this.ddlbSituacion.DataSource= oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Enumerados.TablasTabla.FinancieraEstadoPrestamoBancario));
			ddlbSituacion.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbSituacion.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbSituacion.DataBind();	
			if (Session[SESSIONFINPTMO] !=null)
			{
				this.ddlbSituacion.SelectedIndex=Convert.ToInt32(Session[SESSIONFINPTMO]);
			}
		}
		public void LlenarDatos()
		{
		}
		

		public void LlenarJScript()
		{
			this.ddlbSituacion.Attributes.Add(Utilitario.Constantes.EVENTOONCHANGE,Utilitario.Constantes.POPUPDEESPERA);
			this.ibtnAgregar.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.POPUPDEESPERA + Helper.HistorialIrAdelantePersonalizado("hGridPaginaSort","hGridPagina"));
			this.ibtnAmortizar.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.POPUPDEESPERA + Helper.HistorialIrAdelantePersonalizado("hGridPaginaSort","hGridPagina"));
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarPrestamoBancario.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministrarPrestamoBancario.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarPrestamoBancario.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			if(CNetAccessControl.FindPage(Page.Request.Url.AbsolutePath.ToString()))
			{CNetAccessControl.LoadControls(this);}
			else
			{CNetAccessControl.RedirectPageError();}									
			// TODO:  Add AdministrarPrestamoBancario.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add AdministrarPrestamoBancario.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			
		}

		private void btnMostrar_Click(object sender, System.EventArgs e)
		{
			
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.Header)
			{
				e.Item.Cells[1].ToolTip=TOOLTIPCENTROOP;
				e.Item.Cells[5].ToolTip=TOOLTIPNRODIASXVENCER;
				e.Item.Cells[6].ToolTip=TOOLTIPTASAEFECTIVAANUAL;
				e.Item.Cells[7].ToolTip=TOOLTIPMONEDA;
			}
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				Label lbl;
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				Helper.ConfiguraColumnaHyperLink(e.Item.Cells[0],grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex,
						Helper.HistorialIrAdelantePersonalizado("hGridPaginaSort","hGridPagina"),
						Helper.MostrarVentana(URLPRINCIPAL,KEYIDPRESTAMO.ToString() + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr[Enumerados.FinColumnaPrestamoBancario.idprestamo.ToString()]) 
																			+ Utilitario.Constantes.SIGNOAMPERSON 
																			+ KEYIDPERIODO  +  Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr[Enumerados.FinColumnaPrestamoBancario.periodo.ToString()])
																			+ Utilitario.Constantes.SIGNOAMPERSON 
																			+ KEYIDSITUACION +  Utilitario.Constantes.SIGNOIGUAL + this.ddlbSituacion.SelectedValue.ToString()
																			+ Utilitario.Constantes.SIGNOAMPERSON 
																			+ Utilitario.Constantes.KEYMODOPAGINA +  Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.M.ToString()
																			+ Utilitario.Constantes.SIGNOAMPERSON 
																			+ Utilitario.Constantes.KEYMODULOCONSULTA +  Utilitario.Constantes.SIGNOIGUAL + Utilitario.Enumerados.ModuloConsulta.No.ToString()
																			)); 



				((Label)e.Item.Cells[4].FindControl(CMPFECHA1)).Text = dr[Utilitario.Enumerados.FinColumnaPrestamoBancario.fechainicio.ToString()].ToString();
				((Label)e.Item.Cells[4].FindControl(CMPFECHA2)).Text = dr[Utilitario.Enumerados.FinColumnaPrestamoBancario.fechatermino.ToString()].ToString();
				 
			


				lbl = (Label)e.Item.Cells[8].FindControl(CMPMONTOPTM);
	            lbl.Text = Convert.ToString(Convert.ToDouble(dr[Utilitario.Enumerados.FinColumnaPrestamoBancario.montoptmo.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4));
				Helper.FiltroporSeleccionConfiguraColumna(lbl,Utilitario.Enumerados.FinColumnaPrestamoBancario.montoptmo.ToString());

				lbl = (Label)e.Item.Cells[8].FindControl(CMPMONTOAMT);
		        lbl.Text = Convert.ToString(Convert.ToDouble(dr[Utilitario.Enumerados.FinColumnaPrestamoBancario.montoAmortiza.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4));
				Helper.FiltroporSeleccionConfiguraColumna(lbl,Utilitario.Enumerados.FinColumnaPrestamoBancario.montoAmortiza.ToString());
				
				
				lbl = (Label)e.Item.Cells[8].FindControl(CMPMONTOSAL);
				lbl.Text = Convert.ToString(Convert.ToDouble(dr[Utilitario.Enumerados.FinColumnaPrestamoBancario.montoSaldo.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4));
				Helper.FiltroporSeleccionConfiguraColumna(lbl,Utilitario.Enumerados.FinColumnaPrestamoBancario.montoSaldo.ToString());

				lbl.Text =Helper.FormateaNumeroNegativo(lbl.Text,lbl);

				e.Item.Cells[9].Text = Convert.ToDouble(e.Item.Cells[9].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				
				Helper.FiltroporSeleccionConfiguraColumna(e,grid);
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,Utilitario.Helper.MostrarDatosEnCajaTexto("txtConcepto",dr[Utilitario.Enumerados.FinColumnaPrestamoBancario.concepto.ToString()].ToString())
															   ,Utilitario.Helper.MostrarDatosEnCajaTexto("hCodigo",Convert.ToString(dr[Utilitario.Enumerados.FinColumnaPrestamoBancario.idprestamo.ToString()]) 
																+ Utilitario.Constantes.SIGNOPUNTOYCOMA + Convert.ToString(dr[Utilitario.Enumerados.FinColumnaPrestamoBancario.periodo.ToString()])));
				Helper.FiltroporSeleccionConfiguraColumna(e,grid,true,CTRLBUSCAR);
			}			
		
		}
		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.hGridPagina.Value=e.NewPageIndex.ToString();
			grid.CurrentPageIndex=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);	
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			hGridPaginaSort.Value=Helper.GenerarExpresionOrdenamiento(e.SortExpression);
			this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Helper.ObtenerIndicePagina());
		}

		private void ibtnAgregar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.redireccionaPaginaAgregar();
		}
		private void redireccionaPaginaAgregar()
		{
			
			Page.Response.Redirect
				(
				URLPRINCIPAL + Utilitario.Constantes.KEYMODOPAGINA +  Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.N.ToString()
				+ Utilitario.Constantes.SIGNOAMPERSON 
				+ KEYIDSITUACION +  Utilitario.Constantes.SIGNOIGUAL + this.ddlbSituacion.SelectedValue.ToString()
				+ Utilitario.Constantes.SIGNOAMPERSON 
				+ Utilitario.Constantes.KEYMODULOCONSULTA +  Utilitario.Constantes.SIGNOIGUAL +  Utilitario.Enumerados.ModuloConsulta.No.ToString()
				);
			
		}
		private void redireccionaPaginaAmortizar()
		{
			if (this.hCodigo.Value.Length > Utilitario.Constantes.ValorConstanteCero)
			{
				string [] Parametro = this.hCodigo.Value.ToString().Split(';');
				Page.Response.Redirect
					(URLPRINCIPAL + KEYIDSITUACION + Utilitario.Constantes.SIGNOIGUAL + this.ddlbSituacion.SelectedValue.ToString()
								+ Utilitario.Constantes.SIGNOAMPERSON 
								+ KEYIDPRESTAMO.ToString() + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(Parametro[0]) 
								+ Utilitario.Constantes.SIGNOAMPERSON 
								+ KEYIDPERIODO  +  Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(Parametro[1])
								+ Utilitario.Constantes.SIGNOAMPERSON 
								+ Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Enumerados.ModoPagina.C.ToString()
								+ Utilitario.Constantes.SIGNOAMPERSON 
								+ Utilitario.Constantes.KEYMODULOCONSULTA + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Enumerados.ModuloConsulta.No.ToString());
			}
			else
			{
				ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO));
			}

		}

		private void ibtnAmortizar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.redireccionaPaginaAmortizar();
		}

		private void ibtnFiltrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			ltlMensaje.Text= Utilitario.Helper.ElaborarFiltro(this.ObtenerDatos(),
																					"*" + "Centro;Centro de Operaciones" 
																					,"*" + Utilitario.Enumerados.FinColumnaPrestamoBancario.nroprestamo.ToString()+ ";Nro de Préstamo"
																					,Utilitario.Enumerados.FinColumnaPrestamoBancario.fechainicio.ToString()+ ";Fecha de Inicio"
																					,Utilitario.Enumerados.FinColumnaPrestamoBancario.fechatermino.ToString()+ ";Fecha de Vencimiento"
																					,Utilitario.Enumerados.FinColumnaPrestamoBancario.tasainteres.ToString()+ ";Tasa de Interés"
																					,"*" + Utilitario.Enumerados.FinColumnaPrestamoBancario.moneda.ToString()+ ";Moneda"
																					,Utilitario.Enumerados.FinColumnaPrestamoBancario.montoInteres.ToString()+ ";Monto de Interés"
																					,Utilitario.Enumerados.FinColumnaPrestamoBancario.montoptmo.ToString()+ ";Monto de Préstamo"
																					,Utilitario.Enumerados.FinColumnaPrestamoBancario.montoAmortiza.ToString()+ ";Monto amortizado"
																					,Utilitario.Enumerados.FinColumnaPrestamoBancario.montoSaldo.ToString()+ ";Saldo");
		}

		private void ibtnEliminaFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}

		private void gridResumen1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.Header)
			{
				e.Item.Cells[1].ToolTip=TOOLTIPCENTROOP;
				e.Item.Cells[2].ToolTip=TOOLTIPMONEDA;
			}
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				Label lbl;
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				lbl = (Label)e.Item.Cells[2].FindControl(CMPMONTOPTM);
                lbl.Text = Convert.ToString(Convert.ToDouble(dr[Utilitario.Enumerados.FinColumnaPrestamoBancario.montoptmo.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4));
	  	  

				lbl = (Label)e.Item.Cells[2].FindControl(CMPMONTOAMT);
				lbl.Text = Convert.ToString(Convert.ToDouble(dr[Utilitario.Enumerados.FinColumnaPrestamoBancario.montoAmortiza.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4));

				lbl = (Label)e.Item.Cells[2].FindControl(CMPMONTOSAL);
				lbl.Text = Convert.ToString(Convert.ToDouble(dr[Utilitario.Enumerados.FinColumnaPrestamoBancario.montoSaldo.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4));				

				lbl.Text =Helper.FormateaNumeroNegativo(lbl.Text,lbl);
				
				e.Item.Height=20;
			}

		}

		private void gridResumen2_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.Header)
			{
				e.Item.Cells[1].ToolTip=TOOLTIPMONEDA;
			}

			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				Label lbl;
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;


				string lbl1 = CMPMONTOPTM+"2";
				string lbl2	= CMPMONTOAMT+"2"; 
				string lbl3 = CMPMONTOSAL+"2";

				lbl = (Label)e.Item.Cells[2].FindControl(lbl1);
				lbl.Text = Convert.ToString(Convert.ToDouble(dr[Utilitario.Enumerados.FinColumnaPrestamoBancario.montoptmo.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4));				

				lbl = (Label)e.Item.Cells[2].FindControl(lbl2);
				lbl.Text = Convert.ToString(Convert.ToDouble(dr[Utilitario.Enumerados.FinColumnaPrestamoBancario.montoAmortiza.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4));						

				lbl = (Label)e.Item.Cells[2].FindControl(lbl3);
				lbl.Text = Convert.ToString(Convert.ToDouble(dr[Utilitario.Enumerados.FinColumnaPrestamoBancario.montoSaldo.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4));						

                lbl.Text =Helper.FormateaNumeroNegativo(lbl.Text,lbl);

				e.Item.Height=20;	
			}

		}

		private void gridResumen1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void gridResumen2_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void ddlbSituacion_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Session[SESSIONFINPTMO] = this.ddlbSituacion.SelectedIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO),Utilitario.Constantes.INDICEPAGINADEFAULT);
		}

	}
}
