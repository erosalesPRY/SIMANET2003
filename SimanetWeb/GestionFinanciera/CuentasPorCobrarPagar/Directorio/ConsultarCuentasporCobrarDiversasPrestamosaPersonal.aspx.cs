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
using NetAccessControl;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using SIMA.Controladoras.GestionFinanciera;

namespace SIMA.SimaNetWeb.GestionFinanciera.CuentasPorCobrarPagar.Directorio
{
	/// <summary>
	/// Summary description for ConsultarCuentasporCobrarDiversasPrestamosaPersonal.
	/// </summary>
	public class ConsultarCuentasporCobrarDiversasPrestamosaPersonal : System.Web.UI.Page, IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblPrimario;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminarFiltro;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hOrdenGrilla;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion Controles

		#region Constantes
		//Key Session y QueryString
		const string KEYQIDTIPOCUENTA = "IdTipoCuenta";
		const string KEYQIDCUENTAPORCOBRARPAGAR = "IdCuenta";
		const string KEYQIDSUBCUENTAPORCOBRARPAGAR = "IdSubCuenta";
		const string KEYQIDCENTROOPERATIVO= "IdCentroOperativo";
		const string KEYQDESCRIPCION = "Descripcion";
		const string KEYQDESCRIPCIONCUENTA = "Cuenta";
		const string KEYQDESCRIPCIONSUBCUENTA = "SubCuenta";
		const string KEYQFLAGDIRECTORIO= "FlagDirectorio";
		const string URLDETALLEXCEL="ExportarDetalleExcelCtasCobrarPrestamosAPersonal.aspx";
		const int IDENTIDAD = 4;
		//Otros
		const string GRILLAVACIA ="No existen Cuentas por Cobrar de Prestamos a Personal";  
		
		#endregion

		#region Variables
		double TotImporte;
		double TotAmortizado;
		protected System.Web.UI.WebControls.ImageButton ibtnAbrir;
		double TotSaldo;
		#endregion

	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					lblPrimario.Text = Page.Request.Params[KEYQDESCRIPCION].ToString();

					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"CuentasPorPagar",this.ToString(),"Se consultó la Cuentas Por Pagar",Enumerados.NivelesErrorLog.I.ToString()));
					Helper.SeleccionarItemCombos(this);
					
					this.LlenarGrillaOrdenamientoPaginacion(this.hOrdenGrilla.Value,Convert.ToInt32(this.hGridPagina.Value));				
					this.LlenarJScript();
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

		private void Totalizar(DataView dwTotales)
		{
			if (dwTotales !=null)
			{
				double[] aArreglo = Helper.TotalizarDataView(dwTotales,Enumerados.FINColumnaCuentaporCobrarDiversasPrestamosaPersonal.Importe.ToString());
				TotImporte = aArreglo[0];

				aArreglo = Helper.TotalizarDataView(dwTotales,Enumerados.FINColumnaCuentaporCobrarDiversasPrestamosaPersonal.Amortizado.ToString());
				TotAmortizado = aArreglo[0];

				aArreglo = Helper.TotalizarDataView(dwTotales,Enumerados.FINColumnaCuentaporCobrarDiversasPrestamosaPersonal.Saldo.ToString());
				TotSaldo = aArreglo[0];

			}
		}

		public void LlenarGrilla()
		{
			// TODO:  Add ConsultarCuentasporCobrarDiversasPrestamosaPersonal.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarCuentasporCobrarDiversasPrestamosaPersonal.LlenarGrillaOrdenamiento implementation
		}

		private DataTable ObtenerDatos()
		{
			if (Convert.ToInt32(Page.Request.QueryString[KEYQFLAGDIRECTORIO].ToString()) == Constantes.POSICIONINDEXUNO)
			{
				return ((CCuentasPorCobrarPagar) new CCuentasPorCobrarPagar()).ConsultarCuentasDiversasPrestamosaPersonalAlCierre(
					IDENTIDAD,
					Convert.ToInt32(Page.Request.Params[KEYQIDCENTROOPERATIVO]),
					Convert.ToInt32(Page.Request.Params[KEYQIDCUENTAPORCOBRARPAGAR]),
					Convert.ToInt32(Page.Request.Params[KEYQIDSUBCUENTAPORCOBRARPAGAR]));
			}
			else
			{
				return ((CCuentasPorCobrarPagar) new CCuentasPorCobrarPagar()).ConsultarCuentasDiversasPrestamosaPersonal(
					IDENTIDAD,
					Convert.ToInt32(Page.Request.Params[KEYQIDCENTROOPERATIVO]),
					Convert.ToInt32(Page.Request.Params[KEYQIDCUENTAPORCOBRARPAGAR]),
					Convert.ToInt32(Page.Request.Params[KEYQIDSUBCUENTAPORCOBRARPAGAR]));
			}
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dt = this.ObtenerDatos();
			if(dt!=null)
			{
				dt = Helper.TablePersonalizado(dt,"Fecha");

				DataView dw = dt.DefaultView;
				dw.RowFilter = Helper.ObtenerFiltro();
				grid.PageSize = Helper.ObtenerCantidadRegistrosPorGrilla(7,14,21);
				grid.Columns[Utilitario.Constantes.POSICIONFOOTERTOTAL].FooterText = Utilitario.Constantes.TEXTOFOOTERTOTAL + Utilitario.Constantes.ESPACIO + dw.Count.ToString();
				dw.Sort = columnaOrdenar ;
				if (dw.Count==0)
				{
					grid.DataSource = null;
					lblResultado.Text = GRILLAVACIA;
					lblResultado.Visible = true;
				}
				else
				{
					Session["EXPORTAREXCEL"]=dt;
					grid.DataSource = dt;
					grid.CurrentPageIndex =indicePagina;
					grid.Columns[Constantes.POSICIONFOOTERTOTAL].FooterText = Constantes.TEXTOFOOTERTOTAL;
					grid.Columns[Constantes.POSICIONTOTAL].FooterText = dw.Count.ToString();

					this.Totalizar(dw);

					lblResultado.Visible = false;
				}
			}
			else
			{
				grid.DataSource = null;
				lblResultado.Text = GRILLAVACIA;
				lblResultado.Visible = true;
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
			// TODO:  Add ConsultarCuentasporCobrarDiversasPrestamosaPersonal.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add ConsultarCuentasporCobrarDiversasPrestamosaPersonal.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			if(((DataTable)Session["EXPORTAREXCEL"])!=null)
				ibtnAbrir.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.PopupBusqueda(URLDETALLEXCEL,780,640));
			else
				ibtnAbrir.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,"window.alert('No existen datos a exportar')");
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarCuentasporCobrarDiversasPrestamosaPersonal.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarCuentasporCobrarDiversasPrestamosaPersonal.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarCuentasporCobrarDiversasPrestamosaPersonal.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add ConsultarCuentasporCobrarDiversasPrestamosaPersonal.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ConsultarCuentasporCobrarDiversasPrestamosaPersonal.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void ibtnFiltrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			ltlMensaje.Text = Utilitario.Helper.ElaborarFiltro(this.ObtenerDatos(),
				Utilitario.Enumerados.FINColumnaCuentaporCobrarDiversasPrestamosaPersonal.ApellidosNombres,
				Utilitario.Enumerados.FINColumnaCuentaporCobrarDiversasPrestamosaPersonal.Fecha,
				Utilitario.Enumerados.FINColumnaCuentaporCobrarDiversasPrestamosaPersonal.Importe,
				Utilitario.Enumerados.FINColumnaCuentaporCobrarDiversasPrestamosaPersonal.Amortizado,
				Utilitario.Enumerados.FINColumnaCuentaporCobrarDiversasPrestamosaPersonal.Saldo,
				Utilitario.Enumerados.FINColumnaCuentaporCobrarDiversasPrestamosaPersonal.Fecha);
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.Header)
			{e.Item.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.POPUPDEESPERA);}

			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{				
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				e.Item.Cells[Constantes.POSICIONCONTADOR].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				Helper.FiltroporSeleccionConfiguraColumna(e,grid);
				e.Item.ToolTip = "CUENTA CONTABLE : " +dr["descripcioncuenta"].ToString();

			}

			if(e.Item.ItemType == ListItemType.Footer)
			{
				e.Item.Cells[5].Text = TotImporte.ToString(Constantes.FORMATODECIMAL4);
				e.Item.Cells[6].Text = TotAmortizado.ToString(Constantes.FORMATODECIMAL4);
				e.Item.Cells[7].Text = TotSaldo.ToString(Constantes.FORMATODECIMAL4);
			}		
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			hGridPagina.Value = e.NewPageIndex.ToString();
			grid.CurrentPageIndex = e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(hOrdenGrilla.Value,e.NewPageIndex);

		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.hOrdenGrilla.Value = Helper.GenerarExpresionOrdenamiento(e.SortExpression);
			this.LlenarGrillaOrdenamientoPaginacion(hOrdenGrilla.Value, Helper.ObtenerIndicePagina());

		}

		private void ibtnEliminarFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();						
		}
	}
}
