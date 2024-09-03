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
	/// <summary>
	/// Summary description for ConsultarClientesdeCtaxCobrarLPyCobranzaDudosa.
	/// </summary>
	public class ConsultarClientesdeCtaxCobrarLPyCobranzaDudosa : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento	
	{
		#region Constantes
			const string IDCENTROOPERATIVO = "idCentro";
			const string PERIODO="Periodo";
			const string MES="Mes";
			const string DIGCTA = "DigCta";
			const string NOMBRECUENTA = "NombreCta";
			const string VARIABLETOTALIZA ="Totaliza";
			const string RUBROS ="idRubros";
			const string URLPAGINADETALLE ="ConsultarRelaciondeFacturasaCobrarPorCliente.aspx?";

			const string IDCLIENTE = "idCliente";
			const string RAZONSOCIAL= "RazonSocial";

		#endregion

		#region Controles
			protected System.Web.UI.WebControls.Label lblRutaPagina;
			protected System.Web.UI.WebControls.Label lblPagina;
			protected System.Web.UI.WebControls.Label lblFecha;
			protected System.Web.UI.WebControls.Label Label4;
			protected System.Web.UI.WebControls.Label lblConcepto;
			protected System.Web.UI.WebControls.Label Label1;
			protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;
			protected System.Web.UI.WebControls.ImageButton ibtnEliminaFiltro;
			protected projDataGridWeb.DataGridWeb grid;
			protected System.Web.UI.WebControls.Label lblResultado;
			protected System.Web.UI.HtmlControls.HtmlImage ibtnFiltrarSeleccion;
			protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
			protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPaginaSort;
			protected System.Web.UI.WebControls.Literal ltlMensaje;
			protected System.Web.UI.WebControls.Label lblRazonSocial;
			protected System.Web.UI.WebControls.Label Label2;
		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.LlenarJScript();
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarDatos();
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionFinanciera",this.ToString(),"Se consultó las Facturas por Pagar.",Enumerados.NivelesErrorLog.I.ToString()));
					Helper.ReestablecerPagina(this);
					this.LlenarGrillaOrdenamientoPaginacion(this.hGridPaginaSort.Value,Convert.ToInt32(this.hGridPagina.Value));
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
			this.ibtnEliminaFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminaFiltro_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add ConsultarClientesdeCtaxCobrarLPyCobranzaDudosa.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarClientesdeCtaxCobrarLPyCobranzaDudosa.LlenarGrillaOrdenamiento implementation
		}


		private DataTable ObtenerDatos()
		{
			return ((CCuentasporCobrar) new CCuentasporCobrar()).ConsultarClientesdeCtasporCobrarvarias(Convert.ToInt32(Page.Request.Params[IDCENTROOPERATIVO])
																										,Page.Request.Params[DIGCTA].ToString()
																										,Page.Request.Params[RUBROS].ToString());
			
		}

		private void Totalizar(DataTable dtOrigen)
		{
			if (dtOrigen !=null)
			{
				ArrayList arrTotal = new ArrayList();
				arrTotal.Add(Helper.TotalizarDataView(dtOrigen.DefaultView,"SaldoSoles")[0]);
				Session[VARIABLETOTALIZA] = arrTotal;
			}

		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dt = this.ObtenerDatos();
			this.Totalizar(dt);
			if(dt!=null)
			{
				DataView dw = dt.DefaultView;
				dw.RowFilter = Helper.ObtenerFiltro();
				grid.Columns[Utilitario.Constantes.POSICIONFOOTERTOTAL].FooterText = Utilitario.Constantes.TEXTOFOOTERTOTAL + Utilitario.Constantes.ESPACIO + dw.Count.ToString();
				dw.Sort = columnaOrdenar ;
				grid.DataSource = dt;
				grid.CurrentPageIndex =indicePagina;
			}
			else
			{
				grid.DataSource = null;
				lblResultado.Text = "No existen Datos..";
			}
			try
			{
				grid.DataBind();
			}
			catch	
			{
				grid.CurrentPageIndex = 0;
				grid.DataBind();
				Page.DataBind();
			}					
		}

		public void LlenarCombos()
		{
			// TODO:  Add ConsultarClientesdeCtaxCobrarLPyCobranzaDudosa.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			lblFecha.Text = "AL DIA :" + DateTime.Now.AddDays(-1).ToShortDateString();
			this.lblConcepto.Text = Page.Request.Params[NOMBRECUENTA].ToString();
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarClientesdeCtaxCobrarLPyCobranzaDudosa.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarClientesdeCtaxCobrarLPyCobranzaDudosa.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarClientesdeCtaxCobrarLPyCobranzaDudosa.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarClientesdeCtaxCobrarLPyCobranzaDudosa.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add ConsultarClientesdeCtaxCobrarLPyCobranzaDudosa.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ConsultarClientesdeCtaxCobrarLPyCobranzaDudosa.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			// TODO:  Add ConsultarClientesdeCtaxCobrarLPyCobranzaDudosa.Agregar implementation
		}

		public void Modificar()
		{
			// TODO:  Add ConsultarClientesdeCtaxCobrarLPyCobranzaDudosa.Modificar implementation
		}

		public void Eliminar()
		{
			// TODO:  Add ConsultarClientesdeCtaxCobrarLPyCobranzaDudosa.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			// TODO:  Add ConsultarClientesdeCtaxCobrarLPyCobranzaDudosa.CargarModoPagina implementation
		}

		public void CargarModoNuevo()
		{
			// TODO:  Add ConsultarClientesdeCtaxCobrarLPyCobranzaDudosa.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			// TODO:  Add ConsultarClientesdeCtaxCobrarLPyCobranzaDudosa.CargarModoModificar implementation
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add ConsultarClientesdeCtaxCobrarLPyCobranzaDudosa.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add ConsultarClientesdeCtaxCobrarLPyCobranzaDudosa.ValidarCampos implementation
			return false;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add ConsultarClientesdeCtaxCobrarLPyCobranzaDudosa.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add ConsultarClientesdeCtaxCobrarLPyCobranzaDudosa.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				Helper.FiltroporSeleccionConfiguraColumna(e,grid,true,"txtBuscar");
				
				string Parametros  = IDCENTROOPERATIVO  + Utilitario.Constantes.SIGNOIGUAL +  Page.Request.Params[IDCENTROOPERATIVO].ToString()
														+ Utilitario.Constantes.SIGNOAMPERSON
														+ PERIODO + Utilitario.Constantes.SIGNOIGUAL +  Page.Request.Params[PERIODO].ToString()
														+ Utilitario.Constantes.SIGNOAMPERSON
														+ MES + Utilitario.Constantes.SIGNOIGUAL +  Page.Request.Params[MES].ToString()
														+ Utilitario.Constantes.SIGNOAMPERSON
														+ NOMBRECUENTA + Utilitario.Constantes.SIGNOIGUAL +  Page.Request.Params[NOMBRECUENTA].ToString()
														+ Utilitario.Constantes.SIGNOAMPERSON
														+ IDCLIENTE + Utilitario.Constantes.SIGNOIGUAL +  dr[Enumerados.FinColumnaFacturasporCobrar.idCliente.ToString()].ToString()
														+ Utilitario.Constantes.SIGNOAMPERSON
														+ RAZONSOCIAL + Utilitario.Constantes.SIGNOIGUAL + e.Item.Cells[1].Text
														+ Utilitario.Constantes.SIGNOAMPERSON
														+ DIGCTA + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[DIGCTA].ToString();

				Helper.ConfiguraColumnaHyperLink(e.Item.Cells[0],grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex,Helper.HistorialIrAdelantePersonalizado("hGridPaginaSort","hGridPagina"),Helper.MostrarVentana(URLPAGINADETALLE,Parametros));

				e.Item.Cells[2].Text = Convert.ToDouble(e.Item.Cells[2].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
			}

			if(e.Item.ItemType == ListItemType.Footer)
			{
				Utilitario.Helper.FooterSpan(sender,e,0,1,2);
				ArrayList arrTotal = (ArrayList)Session[VARIABLETOTALIZA];
				e.Item.Cells[2].Text = Convert.ToDouble(arrTotal[0]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				Session[VARIABLETOTALIZA] = null;
			}

		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.hGridPaginaSort.Value = Helper.GenerarExpresionOrdenamiento(e.SortExpression);
			this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Convert.ToInt32(this.hGridPagina.Value));
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.hGridPagina.Value = e.NewPageIndex.ToString();
			this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Convert.ToInt32(this.hGridPagina.Value));
		}

		private void ibtnEliminaFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();		
		}

	}
}
