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
	/// Summary description for ConsultarCuentasporCobrarDiversasIntereses.
	/// </summary>
	public class ConsultarCuentasporCobrarDiversasIntereses : System.Web.UI.Page, IPaginaBase
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
		const string URLDETALLEXCEL="ExportarDetalleExcelCtasCobrarDiversasIntereses.aspx?";
		const string URLPAGINADETALLE = "ConsultarDetalleCuentasPorCobraryPagar.aspx?";
		const string KEYQNRORUC="ruc";
		const string KEYQRAZONSOCIAL="Rsocial";
		const string KEYQIDTIPOCONSULTA="tipoConsulta";
		const string KEYQNRODOCUMENTO = "Ndoc";
		//Otros
		const string GRILLAVACIA = "No existen Cuentas por Cobrar de Otras Cuentas Diversas - Intereses por Cobrar";  
		
		#endregion

		#region Variables
		double TotImporte;
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
				double[] aArreglo = Helper.TotalizarDataView(dwTotales,Enumerados.FINColumnaCuentaporCobrarDiversasOtros.Importe.ToString());
				TotImporte = aArreglo[0];

				aArreglo = Helper.TotalizarDataView(dwTotales,Enumerados.FINColumnaCuentaporCobrarDiversasOtros.Saldo.ToString());
				TotSaldo = aArreglo[0];

			}
		}

		public void LlenarGrilla()
		{
			// TODO:  Add ConsultarCuentasporCobrarDiversasIntereses.LlenarGrilla implementation
		}

		private DataTable ObtenerDatos()
		{
			if (Convert.ToInt32(Page.Request.QueryString[KEYQFLAGDIRECTORIO].ToString()) == Constantes.POSICIONINDEXUNO)
			{
				return ((CCuentasPorCobrarPagar) new CCuentasPorCobrarPagar()).ConsultarCuentasDiversasInteresesAlCierre(
					Convert.ToInt32(Page.Request.Params[KEYQIDTIPOCUENTA]),
					Convert.ToInt32(Page.Request.Params[KEYQIDCENTROOPERATIVO]),
					Convert.ToInt32(Page.Request.Params[KEYQIDCUENTAPORCOBRARPAGAR]),
					Convert.ToInt32(Page.Request.Params[KEYQIDSUBCUENTAPORCOBRARPAGAR]));
			}
			else
			{
				return ((CCuentasPorCobrarPagar) new CCuentasPorCobrarPagar()).ConsultarCuentasDiversasIntereses(
					Convert.ToInt32(Page.Request.Params[KEYQIDTIPOCUENTA]),
					Convert.ToInt32(Page.Request.Params[KEYQIDCENTROOPERATIVO]),
					Convert.ToInt32(Page.Request.Params[KEYQIDCUENTAPORCOBRARPAGAR]),
					Convert.ToInt32(Page.Request.Params[KEYQIDSUBCUENTAPORCOBRARPAGAR]));
			}
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarCuentasporCobrarDiversasIntereses.LlenarGrillaOrdenamiento implementation
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
			// TODO:  Add ConsultarCuentasporCobrarDiversasIntereses.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add ConsultarCuentasporCobrarDiversasIntereses.LlenarDatos implementation
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
			// TODO:  Add ConsultarCuentasporCobrarDiversasIntereses.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarCuentasporCobrarDiversasIntereses.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarCuentasporCobrarDiversasIntereses.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add ConsultarCuentasporCobrarDiversasIntereses.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ConsultarCuentasporCobrarDiversasIntereses.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void ibtnFiltrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			ltlMensaje.Text = Utilitario.Helper.ElaborarFiltro(this.ObtenerDatos(),
				Utilitario.Enumerados.FINColumnaCuentaporCobrarDiversasIntereses.Empresa,
				Utilitario.Enumerados.FINColumnaCuentaporCobrarDiversasIntereses.Ruc,
				Utilitario.Enumerados.FINColumnaCuentaporCobrarDiversasIntereses.Fecha,
				Utilitario.Enumerados.FINColumnaCuentaporCobrarDiversasIntereses.Importe,
				Utilitario.Enumerados.FINColumnaCuentaporCobrarDiversasIntereses.Saldo,
				Utilitario.Enumerados.FINColumnaCuentaporCobrarDiversasIntereses.Referencia,
				Utilitario.Enumerados.FINColumnaCuentaporCobrarDiversasIntereses.Concepto,
				Utilitario.Enumerados.FINColumnaCuentaporCobrarDiversasIntereses.Observaciones);
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
				//e.Item.Cells[Constantes.POSICIONCONTADOR].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				string Parametros  = KEYQIDCENTROOPERATIVO  + Utilitario.Constantes.SIGNOIGUAL +  Page.Request.Params[KEYQIDCENTROOPERATIVO].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYQRAZONSOCIAL + Utilitario.Constantes.SIGNOIGUAL + e.Item.Cells[1].Text
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYQIDTIPOCUENTA  + Utilitario.Constantes.SIGNOIGUAL +  Page.Request.Params[KEYQIDTIPOCUENTA].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYQIDCUENTAPORCOBRARPAGAR  + Utilitario.Constantes.SIGNOIGUAL +  Page.Request.Params[KEYQIDCUENTAPORCOBRARPAGAR].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYQIDSUBCUENTAPORCOBRARPAGAR  + Utilitario.Constantes.SIGNOIGUAL +  Page.Request.Params[KEYQIDSUBCUENTAPORCOBRARPAGAR].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYQNRORUC + Utilitario.Constantes.SIGNOIGUAL +  dr["ruc"].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYQIDTIPOCONSULTA + Utilitario.Constantes.SIGNOIGUAL +  "1"
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYQDESCRIPCION + Utilitario.Constantes.SIGNOIGUAL +  lblPrimario.Text 
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYQNRODOCUMENTO + Utilitario.Constantes.SIGNOIGUAL +  dr["ruc"].ToString();
					


				Helper.ConfiguraColumnaHyperLink(e.Item.Cells[0],grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex,Helper.PopupDialogoModal(URLPAGINADETALLE + Parametros ,750,500,true));
				Helper.FiltroporSeleccionConfiguraColumna(e,grid);
			}

			if(e.Item.ItemType == ListItemType.Footer)
			{
				e.Item.Cells[4].Text = TotImporte.ToString(Constantes.FORMATODECIMAL4);
				e.Item.Cells[5].Text = TotSaldo.ToString(Constantes.FORMATODECIMAL4);
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
