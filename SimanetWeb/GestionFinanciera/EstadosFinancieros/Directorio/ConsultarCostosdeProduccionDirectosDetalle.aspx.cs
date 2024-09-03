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
using SIMA.Controladoras.GestionFinanciera;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;

namespace SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancieros.Directorio
{
	/// <summary>
	/// Summary description for ConsultarCostosdeProduccionDirectosDetalle.
	/// </summary>
	public class ConsultarCostosdeProduccionDirectosDetalle : System.Web.UI.Page,IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label lblPeriodo;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label lblMes;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblLN;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label lblCliente;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label lblServicio;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label lblDescripcionCosto;		
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion
	
		#region Constantes
		private const string GRILLAVACIA="No existen registros";
		private const string MENSAJECONSULTAR="Se consulto el Detalle de Cuentas por Provisionar/Liquidar";
		private const string KEYID="KEYID";
		private const string KEYIDPERIODO="KEYIDPERIODO";
		private const string KEYIDMES="KEYIDMES";
		private const string KEYCONCEPTO="KEYCONCEPTO";
		
		const string KEYMATSERMOB ="KEYMATSERMOB";
		const string KEYTIPOCOSTO ="KEYTIPOCOSTO";
		const string KEYIDCENTRO ="IdCentro";
		const string KEYLN ="LN";
		const string KEYCOD_DIV = "KEYCOD_DIV";
		const string KEYNRO_VAL = "NRO_VAL";
		const string KEYNRO_OTS = "NRO_OTS";
		const string KEYCLIENTE = "KEYCLIENTE";
		const string KEYSERVICIO = "KEYSERVICIO";
		const string KEYFECHA = "KEYFECHA";

		const string KEYQNUEVOSSOLES = "MILNS";

		//********
		//Para Proyecto Liquidado
		private const string KEYIDLIQUIDADO="IdProyectoLiquidado";
		//********

		#endregion

		#region Variables
		double TotMonto = 0;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminarFiltro;
		double TotCantidad = 0;

		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.LlenarDatos();
					Helper.ReiniciarSession();
					this.ConfigurarAccesoControles();
					this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),Helper.ObtenerIndicePagina());
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Utilitario.Enumerados.NombresdeModulo.GestiónComercial.ToString(),this.ToString(),MENSAJECONSULTAR,Enumerados.NivelesErrorLog.I.ToString()));			
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
			this.ibtnFiltrar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnFiltrar_Click);
			this.ibtnEliminarFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminarFiltro_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public DataTable ObtenerDatos()
		{
			CEstadosFinancieros oCEstadosFinancieros = new CEstadosFinancieros();
			DataTable dt = new DataTable();
			switch (Page.Request.Params[KEYMATSERMOB])
			{
				case "MAT": 
					dt = oCEstadosFinancieros.ConsultarCostoProduccionDirectoMateriales(Convert.ToInt32(Page.Request.Params[KEYIDCENTRO]),Page.Request.QueryString[KEYCOD_DIV].ToString(), Page.Request.QueryString[KEYNRO_VAL].ToString());
					break;
				case "SER": 
					dt = oCEstadosFinancieros.ConsultarCostoProduccionDirectoServicios(Convert.ToInt32(Page.Request.Params[KEYIDCENTRO]),Page.Request.QueryString[KEYCOD_DIV].ToString(), Page.Request.QueryString[KEYNRO_VAL].ToString());
					break;
				case "MOB": 
					dt = oCEstadosFinancieros.ConsultarCostoProduccionDirectoManoObra(Convert.ToInt32(Page.Request.Params[KEYIDCENTRO]),Page.Request.QueryString[KEYCOD_DIV].ToString(), Page.Request.QueryString[KEYNRO_VAL].ToString());
					break;
				case "LNOTROSSERVICIOS":
					dt = oCEstadosFinancieros.ConsultarDetalleVentaLNServicios(Convert.ToInt32(Page.Request.Params[KEYIDCENTRO]),Page.Request.QueryString[KEYCOD_DIV].ToString(), Page.Request.QueryString[KEYNRO_VAL].ToString());
					break;

			}
			return dt;

		}

		public void Totalizar (DataView dwTotales)
		{
			if (dwTotales != null)
			{
				double [] aArreglo = Helper.TotalizarDataView(dwTotales,"monto");
				TotMonto = aArreglo[0];
				aArreglo = Helper.TotalizarDataView(dwTotales,"cantidad");
				TotCantidad = aArreglo[0];
			}
		}

		public void LlenarGrilla()
		{
			// TODO:  Add ConsultarCostosdeProduccionDirectosDetalle.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarCostosdeProduccionDirectosDetalle.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dt = this.ObtenerDatos();
			
			if(dt!=null)
			{
				DataView dw1 = dt.DefaultView;
				dw1.Sort = columnaOrdenar;
				dw1.RowFilter = Helper.ObtenerFiltro(this);

				DataTable dt1 = Helper.DataViewTODataTable(dw1);

				DataView dw = dt1.DefaultView;
				this.Totalizar(dw);

				if(dw.Count>0)
				{
					grid.CurrentPageIndex = indicePagina;
					grid.PageSize = Helper.ObtenerCantidadRegistrosPorGrilla(7,12,18);
					grid.DataSource = dw;
					grid.Columns[0].FooterText = Constantes.TEXTOFOOTERTOTAL;
					grid.Columns[1].FooterText = dw.Count.ToString() + " de " + dt.Rows.Count.ToString();;
					this.lblResultado.Visible = false;
				}
				else
				{
					grid.DataSource = null;
					lblResultado.Visible = true;
					lblResultado.Text = GRILLAVACIA;
				}
			}
			else
			{
				grid.DataSource = dt;
				lblResultado.Text = GRILLAVACIA;
			}
			
			try
			{
				grid.DataBind();
			}
			catch	
			{
				grid.CurrentPageIndex = Utilitario.Constantes.ValorConstanteCero;
				grid.DataBind();
			}
		}

		public void LlenarCombos()
		{
			// TODO:  Add ConsultarCostosdeProduccionDirectosDetalle.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			lblLN.Text = Page.Request.QueryString[KEYCONCEPTO].ToString();
			lblPeriodo.Text = Page.Request.QueryString[KEYIDPERIODO].ToString();
			lblMes.Text = Helper.ObtenerNombreMes(Convert.ToInt32(Page.Request.QueryString[KEYIDMES].ToString()),SIMA.Utilitario.Enumerados.TipoDatoMes.NombreCompleto).ToUpper();
			lblCliente.Text = Page.Request.QueryString[KEYCLIENTE].ToString();
			string OToFAC ="";
			if (Page.Request.Params[KEYMATSERMOB]=="LNOTROSSERVICIOS")
				OToFAC="NRO. FACTURA :";
			else
				OToFAC="OTS NRO : ";

			lblServicio.Text = OToFAC + Page.Request.QueryString[KEYNRO_OTS].ToString() + 
				" DEL :" + Convert.ToDateTime(Page.Request.QueryString[KEYFECHA].ToString()).ToString(Utilitario.Constantes.FORMATOFECHA4) + 
				Utilitario.Constantes.SEPARADORLINEA + Page.Request.QueryString[KEYSERVICIO].ToString();
			lblDescripcionCosto.Text = Page.Request.QueryString[KEYTIPOCOSTO].ToString();

			if(Page.Request.QueryString[KEYIDLIQUIDADO]!=null)
			{
				Label3.Visible=false;
				lblPeriodo.Visible=false;
				Label2.Visible=false;
				lblMes.Visible=false;
			}
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarCostosdeProduccionDirectosDetalle.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarCostosdeProduccionDirectosDetalle.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarCostosdeProduccionDirectosDetalle.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarCostosdeProduccionDirectosDetalle.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add ConsultarCostosdeProduccionDirectosDetalle.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ConsultarCostosdeProduccionDirectosDetalle.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if (Page.Request.Params[KEYMATSERMOB]!="MAT")
			{
				e.Item.Cells[3].Style.Add("display","none");
			}
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				e.Item.Cells[Constantes.POSICIONCONTADOR].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				e.Item.Cells[3].Text = (Convert.ToDouble((dr["monto"].ToString()))/Convert.ToDouble((dr["cantidad"].ToString()))).ToString(Constantes.FORMATODECIMAL4);
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				Helper.FiltroporSeleccionConfiguraColumna(e,grid);

			}
			if(e.Item.ItemType == ListItemType.Footer)
			{
				if (Page.Request.Params[KEYMATSERMOB]=="MOB") 
					e.Item.Cells[2].Text = TotCantidad.ToString(Utilitario.Constantes.FORMATODECIMAL4);

				e.Item.Cells[5].Text = TotMonto.ToString(Utilitario.Constantes.FORMATODECIMAL4);
			}
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.grid.CurrentPageIndex=e.NewPageIndex;
			HttpContext.Current.Session[Constantes.KEYSINDICEPAGINA] = e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(e.SortExpression),Helper.ObtenerIndicePagina());
		}

		private void ibtnFiltrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			ltlMensaje.Text = Utilitario.Helper.ElaborarFiltro(this.ObtenerDatos()
				,"descripcion"
				,"cantidad"
				,"unidad"
				,"monto"
				);

		}

		private void ibtnEliminarFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}


	}
}
