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
using SIMA.Controladoras.Convenio;
using SIMA.Controladoras.General;
using SIMA.Controladoras;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using NullableTypes;
namespace SIMA.SimaNetWeb.Convenio
{
	/// <summary>
	/// Summary description for RequerimientosAsignados.
	/// </summary>
	public class CronogramaPagosConvenioSimaMgp: System.Web.UI.Page	,IPaginaBase
	{
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
		protected projDataGridWeb.DataGridWeb dgPagoProgramado;
		protected System.Web.UI.WebControls.Label lblResultado1;
		protected projDataGridWeb.DataGridWeb dgPagoNoProgramado;
		protected System.Web.UI.WebControls.Label lblResultado2;
		protected System.Web.UI.WebControls.Label lblSaldoConvenio;
		protected System.Web.UI.WebControls.Label lblTotalRecibido;
		protected System.Web.UI.WebControls.Label lblDbTotalRecibido;
		protected System.Web.UI.WebControls.Label lblSubtitulo2;
		protected System.Web.UI.WebControls.Label lblSubtitulo1;
		protected System.Web.UI.WebControls.Label lblDbSaldoConvenio;
		protected System.Web.UI.HtmlControls.HtmlForm Form2;
		
					
				
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();

					Helper.ReiniciarSession();

					this.LlenarDatos();
					this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO,true),Utilitario.Constantes.INDICEPAGINADEFAULT);
					this.LlenarGrilla();
					this.LlenarTotalMontoLabel();
					
				}
				catch(SIMAExcepcionLog oSIMAExcepcionLog)
				{
					ltlMensaje.Text = Helper.MensajeAlert(oSIMAExcepcionLog.Mensaje);
				}
				catch(SIMAExcepcionIU oSIMAExcepcionIU)
				{
					ltlMensaje.Text = Helper.MensajeAlert(oSIMAExcepcionIU.Mensaje);			
				}
				catch(SIMAExcepcion oSIMAExcepcion)
				{
					ltlMensaje.Text = Helper.MensajeAlert(oSIMAExcepcion.Mensaje);				
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
			this.ibtnImprimir.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnImprimir_Click);
			this.dgPagoNoProgramado.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgPagoNoProgramado_ItemDataBound);
			this.dgPagoProgramado.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.dgPagoProgramado_SortCommand);
			this.dgPagoProgramado.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgPagoProgramado_PageIndexChanged);
			this.dgPagoProgramado.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgPagoProgramado_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region Constantes
		// KEY y Sesion
		const string KEYIDCONVENIOSIMAMGP="IdConvenioSimaMgp";

		//Otros
		const string GRILLAVACIAPAGOPROGRAMADO="No Hay Programa de Pagos Establecido";
		const string GRILLAVACIAPAGONOPROGRAMADO="No existen pagos efectuados fuera del programa de pagos";
		const string COLORDENAMIENTO="Orden";
		const string KEYQTITULOPRINCIPAL="TituloPrincipal";

		const string CONTROLIMAGENOBSPG="imgObs";

		const string URLPRINCIPAL="ConsultarProyectosConvenioSimaMgp.aspx?";


		#endregion Constantes

		#region Variables
		// PagoProgramado
		static double acumMontoRecibido=0;
		static double acumMontoProgramado=0;
		static double acumMontoPendiente=0;

		// Pago No Programado
		static double npacumMontoRecibido=0;

		#endregion Variables

		private void LlenarTotalMontoLabel()
		{ 
			double TotalRecibido=0;
			double TotalSaldoConvenio=0;
			TotalRecibido=(acumMontoRecibido + npacumMontoRecibido);
			TotalSaldoConvenio=(acumMontoProgramado - (acumMontoRecibido + npacumMontoRecibido));

			lblDbTotalRecibido.Text = TotalRecibido.ToString(Utilitario.Constantes.FORMATODECIMAL4);
			lblDbSaldoConvenio.Text = TotalSaldoConvenio.ToString(Utilitario.Constantes.FORMATODECIMAL4);
		}


		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			CConvenioSimaMgp oConvenioSimaMgp=new CConvenioSimaMgp();
			DataTable dtPagoNoProgramado=oConvenioSimaMgp.ConsultarPagosPendientesFueraDelProgramaDePagos(Convert.ToInt32(Page.Request.Params[KEYIDCONVENIOSIMAMGP]));

			if(dtPagoNoProgramado!=null)
			{
				dgPagoNoProgramado.DataSource = dtPagoNoProgramado;
				NullableDouble[] Montos;
				string[] Columnas=new string[] {Enumerados.ColumnasProgramaPagosConvenio.MontoRecibido.ToString()};
				CFuncionesEspeciales oCFuncionesEspeciales=new CFuncionesEspeciales();
				Montos=oCFuncionesEspeciales.CalcularMontosTotalesDataFile(dtPagoNoProgramado.DefaultView,Columnas);
				npacumMontoRecibido=NullableIsNull.IsNullDouble(Montos[0],0);

				dgPagoNoProgramado.Columns[2].FooterText = dtPagoNoProgramado.Rows.Count.ToString();
				lblResultado2.Visible = false;

			}
			else
			{
				dgPagoNoProgramado.DataSource = dtPagoNoProgramado;
				lblResultado2.Visible = true;
				lblResultado2.Text = GRILLAVACIAPAGONOPROGRAMADO;
			}
			try
			{
				dgPagoNoProgramado.DataBind();
			}
			catch	
			{
				dgPagoNoProgramado.CurrentPageIndex = 0;
				dgPagoNoProgramado.DataBind();
			}
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			////****////
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			CConvenioSimaMgp oConvenioSimaMgp=new CConvenioSimaMgp();
			DataTable dtPagoProgramado=oConvenioSimaMgp.ConsultarPagosYCronogramaDePagosDeUnConvenio(Convert.ToInt32(Page.Request.Params[KEYIDCONVENIOSIMAMGP]));

			if(dtPagoProgramado!=null)
			{
				DataView dwPagoProgramado = dtPagoProgramado.DefaultView;
				dwPagoProgramado.Sort = columnaOrdenar;
				dgPagoProgramado.DataSource = dwPagoProgramado;
				
				string[] Columnas=new string[] {
												   Enumerados.ColumnasProgramaPagosConvenio.MontoProgramado.ToString(),
												   Enumerados.ColumnasProgramaPagosConvenio.MontoRecibido.ToString(),
												   Enumerados.ColumnasProgramaPagosConvenio.MontoPendiente.ToString()
											   };
				NullableDouble[] Montos;
				CFuncionesEspeciales oCFuncionesEspeciales=new CFuncionesEspeciales();

				Montos=oCFuncionesEspeciales.CalcularMontosTotalesDataFile(dwPagoProgramado,Columnas);
				
				acumMontoProgramado=NullableIsNull.IsNullDouble(Montos[0],0);
				acumMontoRecibido=NullableIsNull.IsNullDouble(Montos[1],0);
				acumMontoPendiente=NullableIsNull.IsNullDouble(Montos[2],0);

				
				CImpresion oCImpresion = new CImpresion();
				oCImpresion.GuardarDataImprimirExportar(dtPagoProgramado,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGOTITULOREPORTEACCIONCONTROLNOPROGRAMADA),columnaOrdenar,Utilitario.Constantes.INDICEPAGINADEFAULT);
				//ibtnImprimir.Visible = true;
				lblResultado1.Visible = false;

				dgPagoNoProgramado.Columns[2].FooterText = dwPagoProgramado.Count.ToString();

			}
			else
			{
				dgPagoProgramado.DataSource = dtPagoProgramado;
				lblResultado1.Visible = true;
				lblResultado1.Text = GRILLAVACIAPAGOPROGRAMADO;
				//ibtnImprimir.Visible = false;
			}
			try
			{
				dgPagoProgramado.DataBind();
			}
			catch	
			{
				dgPagoProgramado.CurrentPageIndex = 0;
				dgPagoProgramado.DataBind();
			}
		}

		public void LlenarCombos()
		{
			// TODO:  Add CronogramaPagosConvenioSimaMgp.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			lblTitulo.Text="CRONOGRAMA DE PAGOS DEL CONVENIO SIMA - MGP " +  Page.Request.Params[KEYQTITULOPRINCIPAL].ToString();
		}

		public void LlenarJScript()
		{
			
		}

		public void RegistrarJScript()
		{
			// TODO:  Add CronogramaPagosConvenioSimaMgp.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add CronogramaPagosConvenioSimaMgp.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add CronogramaPagosConvenioSimaMgp.Exportar implementation
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
			// TODO:  Add CronogramaPagosConvenioSimaMgp.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void dgPagoProgramado_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(e.SortExpression),Helper.ObtenerIndicePagina());
		}

		private void dgPagoProgramado_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				
//
//				if(!NullableDouble.Parse(dr[Enumerados.ColumnasProgramaPagosConvenio.MontoProgramado.ToString()]).IsNull)
//				{
//					acumMontoProgramado = acumMontoProgramado + Convert.ToDouble(dr[Enumerados.ColumnasProgramaPagosConvenio.MontoProgramado.ToString()]);
//				}
//
//				if(!NullableDouble.Parse(dr[Enumerados.ColumnasProgramaPagosConvenio.MontoRecibido.ToString()]).IsNull)
//				{
//					acumMontoRecibido = acumMontoRecibido + Convert.ToDouble(dr[Enumerados.ColumnasProgramaPagosConvenio.MontoRecibido.ToString()]);
//				}
//
//				if(!NullableDouble.Parse(dr[Enumerados.ColumnasProgramaPagosConvenio.MontoPendiente.ToString()]).IsNull)
//				{
//					acumMontoPendiente = acumMontoPendiente + Convert.ToDouble(dr[Enumerados.ColumnasProgramaPagosConvenio.MontoPendiente.ToString()]);
//				}

				//e.Item.Attributes.Add("onclick","MostrarObservaciones('txtObservacionesPagoProgramado','" + Convert.ToString(dr[Enumerados.ColumnasProgramaPagosConvenio.Observaciones.ToString()]) +"')");

			    System.Web.UI.WebControls.ImageButton img =(System.Web.UI.WebControls.ImageButton)e.Item.Cells[6].FindControl(CONTROLIMAGENOBSPG);
				
			    img.Attributes.Add("onClick",Utilitario.Helper.MostrarVentaModalTextoHTML("Observaciones",dr[Enumerados.ColumnasProgramaPagosConvenio.Observaciones.ToString()].ToString(),520,400));
				
				Utilitario.Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				e.Item.Cells[0].Text = Helper.ObtenerIndicedeRegistro(dgPagoProgramado.CurrentPageIndex,dgPagoProgramado.PageSize,e.Item.ItemIndex);
				
			}	
			else if(e.Item.ItemType == ListItemType.Footer)
			{
				//e.Item.Cells[2].Text =Utilitario.Constantes.TEXTOTOTAL;
				e.Item.Cells[3].Text = acumMontoProgramado.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[4].Text = acumMontoRecibido.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[5].Text = acumMontoPendiente.ToString(Utilitario.Constantes.FORMATODECIMAL4);
			}
		}

		private void dgPagoNoProgramado_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				
//				if(!NullableDouble.Parse(dr[Enumerados.ColumnasProgramaPagosConvenio.MontoRecibido.ToString()]).IsNull)
//				{
//					npacumMontoRecibido = npacumMontoRecibido + Convert.ToDouble(dr[Enumerados.ColumnasProgramaPagosConvenio.MontoRecibido.ToString()]);
//				}

				//e.Item.Attributes.Add("onclick","MostrarObservaciones('txtObservacionesPagoNoprogramado','" + Convert.ToString(dr[Enumerados.ColumnasProgramaPagosConvenio.Observaciones.ToString()]) +"')");
				System.Web.UI.WebControls.ImageButton img =(System.Web.UI.WebControls.ImageButton)e.Item.Cells[5].FindControl(CONTROLIMAGENOBSPG);
				img.Attributes.Add("onClick",Utilitario.Helper.MostrarVentaModalTextoHTML("OBSERVACIONES:",dr[Enumerados.ColumnasProgramaPagosConvenio.Observaciones.ToString()].ToString(),520,400));

				e.Item.Cells[0].Text = Helper.ObtenerIndicedeRegistro(dgPagoNoProgramado.CurrentPageIndex,dgPagoNoProgramado.PageSize,e.Item.ItemIndex);
				Utilitario.Helper.SeleccionarItemGrillaOnClickMoverRaton(e);

			}	
			else if(e.Item.ItemType == ListItemType.Footer)
			{
				//e.Item.Cells[3].Text =Utilitario.Constantes.TEXTOTOTAL;
				e.Item.Cells[4].Text = npacumMontoRecibido.ToString(Utilitario.Constantes.FORMATODECIMAL4);
			}
		}

		private void ibtnImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Imprimir();
		}

		private void RedireccionarPaginaPrevia()
		{
			this.Page.Response.Redirect(URLPRINCIPAL + KEYIDCONVENIOSIMAMGP + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYIDCONVENIOSIMAMGP]);
		}

		private void dgPagoProgramado_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.dgPagoProgramado.CurrentPageIndex=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);
		}

	}
}

