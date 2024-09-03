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
	/// Summary description for ConsultarPrestamosporBancoDetalle.
	/// </summary>
	public class ConsultarPrestamosporBancoDetalle : System.Web.UI.Page,IPaginaBase
	{
		#region Constantes
		//const int IDTABLAESTADOCARTAFIANZA=5;
		const string GRILLAVACIA ="No existe ningún Registro.";  
		const string CONTROLINK="hlkCentro";
		const string URLPRINCIPAL="ConsultarPrestamosporBanco.aspx";

		const string URLANTERIOR = "ConsultarPrestamosporBanco.aspx?";
		const string URLDETALLEAMORTIZA= "DetallePrestamoBancario.aspx?";
		
		const string COLORDENAMIENTO = "NombreCentro";

		const string KEYIDESTADO = "idEstado";
		const string KEYIDENTIDADFINANCIERA = "idEF";
		const string KEYIDCENTRO = "idCentro";
		const string NOMBREENTIDAD = "Nombre";

		const string CAMPO1 = "lblMontoPtmo";
		const string CAMPO2 = "lblMontoAmortiza";
		const string CAMPO3 = "lblMontoSaldo";

		const string CAMPOFECHA1 = "lblFechaInicio";
		const string CAMPOFECHA2 = "lblFechaVence";


		const string CAMPODB1 = "MontoPtmo";
		const string CAMPODB2 = "MontoAmortiza";
		const string CAMPODB3 = "MontoSaldo";
		const string CAMPODBFECHA1 = "FechaInicio";
		const string CAMPODBFECHA2 = "FechaTermino";

/*DETALLE DE PRESTAMO YAMORTIZACION*/
		const string KEYIDAMORTIZA = "idAMTZ";
		const string KEYIDPRESTAMO = "idPTM";
		const string KEYIDPERIODO ="Periodo";
		const string KEYIDSITUACION ="Estado";

		//const string KEYIDCENTRO ="IdCentro";
		//const string KEYIDENTIDADFINANCIERA2 ="IdEntidadFin";

		//Otros
		const string TITULOBANCO ="BANCO  :";

		//Controles
		const string CTRLLBLMONTOAUTORIZADO ="lblMontoAutorizado";
		const string CTRLLBLMONTOAMORTIZADO ="lblMontoAmortizado";

		//ToolTip
		const string TOOLTIPCENTROOPER ="Centro de Operaciones";
		const string TOOLTIPNRODIASXVENCER ="Nro de días por vencer";
		const string TOOLTIPTASAEFECTIVAANUAL ="Tasa Efectiva Anual";
		const string TOOLTIPMONEDA ="Moneda";
		const string TOOLTIPMONTOAUTORIZADO ="Monto Autorizado";
		const string TOOLTIPMONTOAMORTIZADO ="Monto Amortizado";

		//Filtro
		const string CENTROOPERATIVO ="NombreCentro";
		const string FECHAINICIO ="FechaInicio";
		const string FECHAVENCIMIENTO ="FechaTermino";
		const string MONEDA ="Moneda";
		const string MONTOPRESTAMO ="MontoPtmo";
		const string MONTOAMORTIZADO ="MontoAmortiza";
		const string MONTOSALDO ="MontoSaldo";


		#endregion
		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblBanco;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected projDataGridWeb.DataGridWeb gridResumen;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminaFiltro;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnFiltrarSeleccion;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPaginaSort;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					this.LlenarJScript();
					Helper.ReiniciarSession();
					this.LlenarCombos();
					this.LlenarDatos();
					Helper.ReestablecerPagina(this);
					//Graba en el Log la acción ejecutada
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
			this.ibtnFiltrar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnFiltrar_Click);
			this.ibtnEliminaFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminaFiltro_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.gridResumen.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.gridResumen_ItemDataBound);
			this.gridResumen.SelectedIndexChanged += new System.EventHandler(this.gridResumen_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add ConsultarPrestamosporBancoDetalle.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarPrestamosporBancoDetalle.LlenarGrillaOrdenamiento implementation
		}

		private void GenerarResumen(DataView dv)
		{
			if (dv!=null)
			{
				int NroResumen	 = 7;
				CResumenItem oCResumenItem = new CResumenItem();
				DataTable dtFinal1= Helper.Resumen(oCResumenItem.ObtenerConfiDataResumen(NroResumen),dv);
				gridResumen.DataSource =dtFinal1;
			}
			else
			{
				gridResumen.DataSource =dv;
			}
			gridResumen.DataBind();
		}

		public DataTable ObtenerDatos()
		{
			int idBanco =((Page.Request.Params[KEYIDENTIDADFINANCIERA]==null)? Utilitario.Constantes.IDDEFAULT: Convert.ToInt32(Page.Request.Params[KEYIDENTIDADFINANCIERA]));
			int idCentro =((Page.Request.Params[KEYIDCENTRO]==null)? Utilitario.Constantes.IDDEFAULT: Convert.ToInt32(Page.Request.Params[KEYIDCENTRO]));
			grid.Columns[2].Visible = (idBanco ==Utilitario.Constantes.IDDEFAULT);
			grid.Columns[1].Visible = (idCentro ==Utilitario.Constantes.IDDEFAULT);

			//string [] ParametrosValor={idBanco.ToString(),idCentro.ToString() ,Page.Request.Params[KEYIDESTADO].ToString()};
			DataTable dtGeneral = ((CPrestamoBancario)new CPrestamoBancario()).ConsultaPrestamosporBancoDetalle(idBanco,idCentro,Convert.ToInt32(Page.Request.Params[KEYIDESTADO]) /*ParametrosValor*/);
			return dtGeneral;
		}
		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			this.grid.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(Utilitario.Helper.FooterSpan);
			DataTable dtGeneral = this.ObtenerDatos();
			if(dtGeneral!=null)
			{
				DataView dwGeneral = dtGeneral.DefaultView;
				dwGeneral.RowFilter = Helper.ObtenerFiltro();
				this.GenerarResumen(dwGeneral);
				dwGeneral.Sort = columnaOrdenar ;
				grid.Columns[Utilitario.Constantes.POSICIONFOOTERTOTAL].FooterText = Utilitario.Constantes.TEXTOFOOTERTOTAL + Utilitario.Constantes.ESPACIO + dwGeneral.Count.ToString();;
				grid.DataSource = dwGeneral;
				grid.CurrentPageIndex = indicePagina;
				lblResultado.Visible = false;

			}
			else
			{
//				if(dtGeneral!=null)
//				{
//					this.GenerarResumen(dtGeneral.DefaultView);
//				}
				grid.DataSource = dtGeneral;
				lblResultado.Visible = true;
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
			// TODO:  Add ConsultarPrestamosporBancoDetalle.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add ConsultarPrestamosporBancoDetalle.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			this.lblBanco.Text = TITULOBANCO + Page.Request.Params[NOMBREENTIDAD].ToString();
			// TODO:  Add ConsultarPrestamosporBancoDetalle.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarPrestamosporBancoDetalle.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarPrestamosporBancoDetalle.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarPrestamosporBancoDetalle.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarPrestamosporBancoDetalle.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			if(CNetAccessControl.FindPage(Page.Request.Url.AbsolutePath.ToString()))
			{CNetAccessControl.LoadControls(this);}
			else
			{CNetAccessControl.RedirectPageError();}
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ConsultarPrestamosporBancoDetalle.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			#region Header
			if(e.Item.ItemType == ListItemType.Header)
			{
				e.Item.Cells[1].ToolTip=TOOLTIPCENTROOPER;
				e.Item.Cells[5].ToolTip=TOOLTIPNRODIASXVENCER;
				e.Item.Cells[6].ToolTip=TOOLTIPTASAEFECTIVAANUAL;
				e.Item.Cells[7].ToolTip=TOOLTIPMONEDA;
				((Label) e.Item.Cells[8].FindControl(CTRLLBLMONTOAUTORIZADO)).ToolTip =TOOLTIPMONTOAUTORIZADO;
				((Label) e.Item.Cells[8].FindControl(CTRLLBLMONTOAMORTIZADO)).ToolTip =TOOLTIPMONTOAMORTIZADO;
			}
			#endregion

			#region ITEM
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				Label lbl;
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				Helper.ConfiguraColumnaHyperLink(e.Item.Cells[0],grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex,
					Helper.HistorialIrAdelantePersonalizado("hGridPagina","hGridPaginaSort"),
					Helper.MostrarVentana(URLDETALLEAMORTIZA,KEYIDPRESTAMO.ToString() + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr[Enumerados.FinColumnaPrestamoBancario.idprestamo.ToString()]) 
															+ Utilitario.Constantes.SIGNOAMPERSON 
															+ KEYIDPERIODO  +  Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr[Enumerados.FinColumnaPrestamoBancario.periodo.ToString()])
															+ Utilitario.Constantes.SIGNOAMPERSON 
															+ KEYIDSITUACION +  Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr[Enumerados.FinColumnaPrestamoBancario.idestado.ToString()])
															+ Utilitario.Constantes.SIGNOAMPERSON 
															+ Utilitario.Constantes.KEYMODOPAGINA +  Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.C.ToString()
															+ Utilitario.Constantes.SIGNOAMPERSON 
															+ Utilitario.Constantes.KEYMODULOCONSULTA + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[Utilitario.Constantes.KEYMODULOCONSULTA].ToString()
											));
				
				
				
				if (Convert.ToInt32(e.Item.Cells[5].Text) <= 5)
				{
					e.Item.Cells[5].ForeColor = Color.Red;
				}

				//Fecha del prestamo y vencimiento
				((Label)e.Item.Cells[4].FindControl(CAMPOFECHA1)).Text= dr[CAMPODBFECHA1].ToString();
				((Label)e.Item.Cells[4].FindControl(CAMPOFECHA2)).Text= dr[CAMPODBFECHA2].ToString();

				((Label)e.Item.Cells[8].FindControl(CAMPO1)).Text= Convert.ToString(Convert.ToDouble(dr[CAMPODB1]).ToString(Utilitario.Constantes.FORMATODECIMAL4));
				((Label)e.Item.Cells[8].FindControl(CAMPO2)).Text= Convert.ToString( Convert.ToDouble(dr[CAMPODB2]).ToString(Utilitario.Constantes.FORMATODECIMAL4));

				lbl = (Label)e.Item.Cells[8].FindControl(CAMPO3);
				lbl.Text= Convert.ToString(Convert.ToDouble(dr[CAMPODB3]).ToString(Utilitario.Constantes.FORMATODECIMAL4));
				lbl.Text=Helper.FormateaNumeroNegativo(lbl.Text,lbl);

				#region Helpers
					Helper.FiltroporSeleccionConfiguraColumna(e,grid);
					Helper.SeleccionarItemGrillaOnClickMoverRaton(e,Helper.MostrarDatosEnCajaTexto("txtDescripcion",dr["Concepto"].ToString()));
					e.Item.Cells[0].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
				#endregion
			}
			#endregion

		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void gridResumen_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.Header)
			{
				e.Item.Cells[0].ToolTip=TOOLTIPMONEDA;
			}
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				Label lbl;
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				string lbl1 = CAMPO1+"2";
				string lbl2	= CAMPO2+"2"; 
				string lbl3 = CAMPO3+"2";

				lbl = (Label)e.Item.Cells[1].FindControl(lbl1);
				lbl.Text = Convert.ToString(Convert.ToDouble(dr[Utilitario.Enumerados.FinColumnaPrestamoBancario.montoptmo.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4));				

				lbl = (Label)e.Item.Cells[1].FindControl(lbl2);
				lbl.Text = Convert.ToString(Convert.ToDouble(dr[Utilitario.Enumerados.FinColumnaPrestamoBancario.montoAmortiza.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4));						

				lbl = (Label)e.Item.Cells[1].FindControl(lbl3);
				lbl.Text = Convert.ToString(Convert.ToDouble(dr[Utilitario.Enumerados.FinColumnaPrestamoBancario.montoSaldo.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4));						

				lbl.Text =Helper.FormateaNumeroNegativo(lbl.Text,lbl);
			}
		}

		private void ibtnFiltrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			ltlMensaje.Text= Utilitario.Helper.ElaborarFiltro(this.ObtenerDatos(),Utilitario.Constantes.SIGNOASTERISCO + CENTROOPERATIVO + ";Centro Operativo"
																				,FECHAINICIO + ";Fecha de Inicio"
																				,FECHAVENCIMIENTO + ";Fecha de Vencimiento"
																				,Utilitario.Constantes.SIGNOASTERISCO + MONEDA + ";Moneda"
																				,MONTOPRESTAMO + ";Monto del Préstamo"
																				,MONTOAMORTIZADO + ";Monto Amortizado"
																				,MONTOSALDO + ";Monto del Saldo");
		}

		private void ibtnEliminaFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}

		private void gridResumen_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			hGridPaginaSort.Value = Helper.GenerarExpresionOrdenamiento(e.SortExpression);
			this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Helper.ObtenerIndicePagina());
		
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.hGridPagina.Value = e.NewPageIndex.ToString();
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);		
		}
	}
}
