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
using SIMA.Controladoras;
using SIMA.Controladoras.General;
using SIMA.Controladoras.GestionFinanciera;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;

namespace SIMA.SimaNetWeb.GestionFinanciera.CuentasPorCobrarPagar
{
	
	public class ConsultarCuentaPorCobrarPagarContador : System.Web.UI.Page,IPaginaBase
	{
		#region "Constantes"
		const string IDTIPOCUENTANAME = "IDTIPOCUENTA";
		const string IDFLAGDIRECTORIO = "FlagDirectorio";
		const string AÑOASCIENTO = "AÑOASCIENTO";
		const string AÑOSNAME = "AÑOS";
		const string MESESNAME = "MESES";

		const string CONTROLLABELCCALLAO = "lblCCallao";
		const string CONTROLLABELMCALLAO = "lblMCallao";
		const string CONTROLLABELCCHIMBOTE = "lblCChimbote";
		const string CONTROLLABELMCHIMBOTE = "lblMChimbote";
		const string CONTROLLABELCPERU = "lblCPeru";
		const string CONTROLLABELMPERU = "lblMPeru";
		const string CONTROLLABELCIQUITOS = "lblCIquitos"; 
		const string CONTROLLABELMIQUITOS = "lblMIquitos";
		const string CONTROLLABELCTOTALP = "lblTCantidadP";
		const string CONTROLLABELMTOTALP = "lblTMontoP";
		const string CONTROLLABELTCCALLAO = "lblTCCallao";
		const string CONTROLLABELTMCALLAO = "lblTMCallao";
		const string CONTROLLABELTCCHIMBOTE = "lblTCChimbote";
		const string CONTROLLABELTMCHIMBOTE = "lblTMChimbote";
		const string CONTROLLABELTCPERU = "lblTCPeru";
		const string CONTROLLABELTMPERU = "lblTMPeru";
		const string CONTROLLABELTCIQUITOS = "lblTCIquitos";
		const string CONTROLLABELTMIQUITOS = "lblTMIquitos";
		const string CONTROLLABELTCANTIDAD = "lblTCantidad";
		const string CONTROLLABELTMONTO = "lblTMonto";
		#endregion
		#region "Controles y variables globales"
		protected System.Web.UI.WebControls.DataGrid dgDatosResumen;
		protected System.Web.UI.WebControls.Literal ltlMensaje;

		private Label lblCantidadTotalCallao;
		private Label lblMontoTotalCallao;
		private Label lblCantidadTotalChimbote;
		private Label lblMontoTotalChimbote;
		private Label lblCantidadTotalPeru;
		private Label lblMontoTotalPeru;
		private Label lblCantidadTotalIquitos;
		private Label lblMontoTotalIquitos;
		private Label lblCantidadTotal;
		private Label lblMontoTotal;

		private string añoConsulta = String.Empty;

		private bool flagConsultaPorAño = false;

		private long sumaCantidadPorPeriodoCallao = 0;
		private long sumaCantidadPorPeriodoChimbote = 0;
		private long sumaCantidadPorPeriodoPeru = 0;
		private long sumaCantidadPorPeriodoIquitos = 0;
		private long sumaCantidadPorPeriodoTotal = 0;

		private double sumaMontoPorPeriodoCallao = 0;
		private double sumaMontoPorPeriodoChimbote = 0;
		private double sumaMontoPorPeriodoPeru = 0;
		private double sumaMontoPorPeriodoIquitos = 0;
		protected System.Web.UI.WebControls.ImageButton ImageButton1;
		private double sumaMontoPorPeriodoTotal = 0;
		#endregion
		#region "Eventos de Pagina"
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(Request.QueryString[AÑOASCIENTO] != null)
			{
				flagConsultaPorAño = true;
				añoConsulta = Request.QueryString[AÑOASCIENTO].ToString();
			}
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					ImageButton1.Attributes.Add("onclick", Constantes.POPUPDEESPERA);
					Helper.ReiniciarSession();
					this.LlenarDatos();
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionFinanciera",this.ToString(),"Se consultó la cantidad de registros por tipo de cuentas.",Enumerados.NivelesErrorLog.I.ToString()));
					Helper.ReestablecerPagina(this);
					
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
			this.dgDatosResumen.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgDatosResumen_ItemCommand);
			this.dgDatosResumen.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgDatosResumen_ItemDataBound);
			this.ImageButton1.Click += new System.Web.UI.ImageClickEventHandler(this.ImageButton1_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		#endregion
		#region "Eventos de Controles"
		private void dgDatosResumen_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			
			long sumaCantidadPorPeriodo = 0;
			long cantidadCallao = 0;
			long cantidadChimbote = 0;
			long cantidadPeru = 0;
			long cantidadIquitos = 0;

			double sumaMontoPorPeriodo = 0;
			double montoCallao = 0;
			double montoChimbote = 0;
			double montoPeru = 0;
			double montoIquitos = 0;

			Label lblCantidadCallao;
			Label lblMontoCallao;
			Label lblCantidadChimbote;
			Label lblMontoChimbote;
			Label lblCantidadPeru;
			Label lblMontoPeru;
			Label lblCantidadIquitos;
			Label lblMontoIquitos;
			Label lblCantidadTotalP;
			Label lblMontoTotalP;
			//Validando Cabecera
			if(e.Item.ItemType == ListItemType.Header)
			{
				if(flagConsultaPorAño)
				{
					e.Item.Cells[0].Text = MESESNAME;
				}
				else
				{
					e.Item.Cells[0].Text = AÑOSNAME;
				}
			}
			//Validando
			if(e.Item.ItemType == ListItemType.Item
				|| e.Item.ItemType == ListItemType.AlternatingItem)
			{
				//Colocando los eventos a la grilla
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				//Sumando por periodo
				lblCantidadCallao = (Label)e.Item.FindControl(CONTROLLABELCCALLAO);
				lblMontoCallao = (Label)e.Item.FindControl(CONTROLLABELMCALLAO);
				cantidadCallao = long.Parse(lblCantidadCallao.Text);
				montoCallao = double.Parse(lblMontoCallao.Text.Replace(" ",String.Empty));

				lblCantidadChimbote = (Label)e.Item.FindControl(CONTROLLABELCCHIMBOTE);
				lblMontoChimbote = (Label)e.Item.FindControl(CONTROLLABELMCHIMBOTE);
				cantidadChimbote = long.Parse(lblCantidadChimbote.Text);
				montoChimbote = double.Parse(lblMontoChimbote.Text.Replace(" ",String.Empty));

				lblCantidadPeru = (Label)e.Item.FindControl(CONTROLLABELCPERU);
				lblMontoPeru = (Label)e.Item.FindControl(CONTROLLABELMPERU);
				cantidadPeru = long.Parse(lblCantidadPeru.Text);
				montoPeru = double.Parse(lblMontoPeru.Text.Replace(" ",String.Empty));

				lblCantidadIquitos = (Label)e.Item.FindControl(CONTROLLABELCIQUITOS);
				lblMontoIquitos = (Label)e.Item.FindControl(CONTROLLABELMIQUITOS);
				cantidadIquitos = long.Parse(lblCantidadIquitos.Text);
				montoIquitos = double.Parse(lblMontoIquitos.Text.Replace(" ",String.Empty));

				sumaCantidadPorPeriodo = cantidadCallao + cantidadChimbote + cantidadIquitos ;
				sumaMontoPorPeriodo = montoCallao + montoChimbote  + montoIquitos;
				//Asignando valor a la columna Total por periodo
				lblCantidadTotalP = (Label)e.Item.FindControl(CONTROLLABELCTOTALP);
				lblMontoTotalP = (Label)e.Item.FindControl(CONTROLLABELMTOTALP);

				lblCantidadTotalP.Text = sumaCantidadPorPeriodo.ToString();
				lblMontoTotalP.Text = sumaMontoPorPeriodo.ToString(Constantes.FORMATODECIMAL4);
				//Sumarizando los totales por centro operativo
				sumaCantidadPorPeriodoCallao += long.Parse(lblCantidadCallao.Text);
				sumaCantidadPorPeriodoChimbote += long.Parse(lblCantidadChimbote.Text);
				sumaCantidadPorPeriodoPeru += long.Parse(lblCantidadPeru.Text);
				sumaCantidadPorPeriodoIquitos += long.Parse(lblCantidadIquitos.Text);
				sumaCantidadPorPeriodoTotal += long.Parse(lblCantidadTotalP.Text);

				sumaMontoPorPeriodoCallao += double.Parse(lblMontoCallao.Text.Replace(" ",String.Empty));
				sumaMontoPorPeriodoChimbote += double.Parse(lblMontoChimbote.Text.Replace(" ",String.Empty));
				sumaMontoPorPeriodoPeru += double.Parse(lblMontoPeru.Text.Replace(" ",String.Empty));
				sumaMontoPorPeriodoIquitos += double.Parse(lblMontoIquitos.Text.Replace(" ",String.Empty));
				sumaMontoPorPeriodoTotal += double.Parse(lblMontoTotalP.Text.Replace(" ",String.Empty));
				//Si la consulta es por el detalle de meses
				if(!flagConsultaPorAño)
				{
					e.Item.Cells[0].Attributes.Add( Constantes.EVENTOCLICK, "location.href='" + 
						Request.Path.Split('/').GetValue(Request.Path.Split('/').Length - 1).ToString() + 
						Constantes.SIGNOINTERROGACION + IDTIPOCUENTANAME + Constantes.SIGNOIGUAL +  
						Request.QueryString[IDTIPOCUENTANAME].ToString() + Constantes.SIGNOAMPERSON +
						AÑOASCIENTO + Constantes.SIGNOIGUAL +  e.Item.Cells[0].Text + 
						Constantes.SIGNOAMPERSON + IDFLAGDIRECTORIO + Constantes.SIGNOIGUAL + 
						Request.QueryString[IDFLAGDIRECTORIO].ToString() + "';" +  Constantes.POPUPDEESPERA);
					e.Item.Cells[0].ForeColor = System.Drawing.Color.Blue;
					e.Item.Cells[0].Font.Underline = true;
				}
				//Dandole estilo al campo periodo
				e.Item.Cells[0].HorizontalAlign = HorizontalAlign.Left;
			}
			//En el footer
			if(e.Item.ItemType == ListItemType.Footer)
			{
				lblCantidadTotalCallao = (Label)e.Item.FindControl(CONTROLLABELTCCALLAO);
				lblMontoTotalCallao = (Label)e.Item.FindControl(CONTROLLABELTMCALLAO);

				lblCantidadTotalChimbote = (Label)e.Item.FindControl(CONTROLLABELTCCHIMBOTE);
				lblMontoTotalChimbote = (Label)e.Item.FindControl(CONTROLLABELTMCHIMBOTE);

				lblCantidadTotalPeru = (Label)e.Item.FindControl(CONTROLLABELTCPERU);
				lblMontoTotalPeru = (Label)e.Item.FindControl(CONTROLLABELTMPERU);

				lblCantidadTotalIquitos = (Label)e.Item.FindControl(CONTROLLABELTCIQUITOS);
				lblMontoTotalIquitos = (Label)e.Item.FindControl(CONTROLLABELTMIQUITOS);

				lblCantidadTotal  = (Label)e.Item.FindControl(CONTROLLABELTCANTIDAD);
				lblMontoTotal = (Label)e.Item.FindControl(CONTROLLABELTMONTO);

				//Asignando Sumatorias
				lblCantidadTotalCallao.Text = sumaCantidadPorPeriodoCallao.ToString();
				lblMontoTotalCallao.Text = sumaMontoPorPeriodoCallao.ToString(Constantes.FORMATODECIMAL4);

				lblCantidadTotalIquitos.Text = sumaCantidadPorPeriodoIquitos.ToString();
				lblMontoTotalIquitos.Text = sumaMontoPorPeriodoIquitos.ToString(Constantes.FORMATODECIMAL4);

				lblCantidadTotalChimbote.Text = sumaCantidadPorPeriodoChimbote.ToString();
				lblMontoTotalChimbote.Text = sumaMontoPorPeriodoChimbote.ToString(Constantes.FORMATODECIMAL4);

				lblCantidadTotalPeru.Text = sumaCantidadPorPeriodoPeru.ToString();
				lblMontoTotalPeru.Text = sumaMontoPorPeriodoPeru.ToString(Constantes.FORMATODECIMAL4);

				lblCantidadTotal.Text = sumaCantidadPorPeriodoTotal.ToString();
				lblMontoTotal.Text = sumaMontoPorPeriodoTotal.ToString(Constantes.FORMATODECIMAL4);
			}
		}
		private void lnkVolverPrincipal_Click(object sender, System.EventArgs e)
		{
			Response.Redirect(Request.Path.Split('/').GetValue(Request.Path.Split('/').Length - 1).ToString() + 
						Constantes.SIGNOINTERROGACION + IDTIPOCUENTANAME + Constantes.SIGNOIGUAL +  
						Request.QueryString[IDTIPOCUENTANAME].ToString());
		}
		#endregion
		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add ConsultarRelaciondeOrdenesdeCompraPorProveedor.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarRelaciondeOrdenesdeCompraPorProveedor.LlenarGrillaOrdenamiento implementation
		}
		private DataTable ObtenerDatos()
		{
			return null;
		}

		private void Totalizar(DataTable dtOrigen)
		{
			
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
		}

		public void LlenarCombos()
		{
			// TODO:  Add ConsultarRelaciondeOrdenesdeCompraPorProveedor.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			string idTipoCuenta = Request.QueryString[IDTIPOCUENTANAME].ToString();
			string idFlagCierre = Request.QueryString[IDFLAGDIRECTORIO].ToString();
			if(flagConsultaPorAño)
			{
				dgDatosResumen.DataSource = new CCuentasPorCobrarPagar().ObtenerDatosContadorPorCobrarPagarMensual
					(idTipoCuenta, añoConsulta,idFlagCierre);
				dgDatosResumen.DataBind();
				ImageButton1.Visible = true;
			}
			else
			{
				dgDatosResumen.DataSource = new CCuentasPorCobrarPagar().ObtenerDatosContadorPorCobrarPagarAnual
					(idTipoCuenta,idFlagCierre);
				dgDatosResumen.DataBind();
				ImageButton1.Visible = false;
			}
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarRelaciondeOrdenesdeCompraPorProveedor.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarRelaciondeOrdenesdeCompraPorProveedor.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarRelaciondeOrdenesdeCompraPorProveedor.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarRelaciondeOrdenesdeCompraPorProveedor.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add ConsultarRelaciondeOrdenesdeCompraPorProveedor.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ConsultarRelaciondeOrdenesdeCompraPorProveedor.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void ImageButton1_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect(Request.Path.Split('/').GetValue(Request.Path.Split('/').Length - 1).ToString() + 
				Constantes.SIGNOINTERROGACION + IDTIPOCUENTANAME + Constantes.SIGNOIGUAL +  
				Request.QueryString[IDTIPOCUENTANAME].ToString() + Constantes.SIGNOAMPERSON +
				IDFLAGDIRECTORIO + Constantes.SIGNOIGUAL + Request.QueryString[IDFLAGDIRECTORIO].ToString());
		}

		private void dgDatosResumen_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			
		}

		
	}
}
