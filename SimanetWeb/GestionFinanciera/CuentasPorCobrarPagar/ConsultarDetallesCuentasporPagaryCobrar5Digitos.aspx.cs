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
	/// Summary description for ConsultarDetallesCuentasporPagaryCobrar5Digitos.
	/// </summary>
	public class ConsultarDetallesCuentasporPagaryCobrar5Digitos : System.Web.UI.Page,IPaginaBase
	{
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblNombreConcepto;
		#region Constantes	
			const string PERIODO="Periodo";
			const string MES="Mes";
			const string PROCESO ="idProceso";
			const string DIGCTA = "DigCta";
			const string NOMBRECUENTA = "NombreCta";
			const string CUENTACONTABLE = "CuentaContable";
			const string NOMBRECUENTACONTABLE = "NCuentaContable";


			const string VARIABLETOTALIZA ="Totaliza";
			const string URLDETALLE  ="ConsultarDetalleOtrosDocumentosporPagaryRHO.aspx?";
			const string IDCENTROOPERATIVO ="idCentro";
			const string CUENTAA ="46916";
			const string CUENTAB ="46917";
			
			/***********************************************************************************/
			const string JSMOSTRARVENTANA = "MostrarVentana";
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
					this.LlenarGrillaOrdenamientoPaginacion("",0);
					
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
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add ConsultarDetallesCuentasporPagaryCobrar5Digitos.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarDetallesCuentasporPagaryCobrar5Digitos.LlenarGrillaOrdenamiento implementation
		}

		private DataTable ObtenerDatos(int idTipoCuenta,string DigCuenta,int pPeriodo,int pMes)
		{
			return ((CCuentasporPagar) new CCuentasporPagar()).ConsultarCuentasporPagarCobrar5Digitos(idTipoCuenta,DigCuenta,pPeriodo,pMes);
		}


		private void Totalizar(DataTable dtOrigen)
		{
			if (dtOrigen !=null)
			{
				ArrayList arrTotal = new ArrayList();
				arrTotal.Add(Helper.TotalizarDataView(dtOrigen.DefaultView,"SimaCallao")[0]);//0
				Session[VARIABLETOTALIZA] = arrTotal;
			}
		}


		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dt = this.ObtenerDatos(Convert.ToInt32(Page.Request.Params[PROCESO]),Page.Request.Params[DIGCTA].ToString(),Convert.ToInt32(Page.Request.Params[PERIODO]),Convert.ToInt32(Page.Request.Params[MES]));
			this.Totalizar(dt);
			if(dt!=null)
			{
				DataView dw = dt.DefaultView;
				dw.RowFilter = Helper.ObtenerFiltro();
				//grid.Columns[Utilitario.Constantes.POSICIONFOOTERTOTAL].FooterText = Utilitario.Constantes.TEXTOFOOTERTOTAL + Utilitario.Constantes.ESPACIO + dw.Count.ToString();
				dw.Sort = columnaOrdenar ;
				grid.DataSource = dw;
				/*grid.CurrentPageIndex =indicePagina;*/
			}
			else
			{
				grid.DataSource = null;
				lblResultado.Text = "No existen Documentos por Pagar";
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
			// TODO:  Add ConsultarDetallesCuentasporPagaryCobrar5Digitos.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			this.lblNombreConcepto.Text = Page.Request.Params[NOMBRECUENTA].ToString();
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarDetallesCuentasporPagaryCobrar5Digitos.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarDetallesCuentasporPagaryCobrar5Digitos.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarDetallesCuentasporPagaryCobrar5Digitos.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarDetallesCuentasporPagaryCobrar5Digitos.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add ConsultarDetallesCuentasporPagaryCobrar5Digitos.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ConsultarDetallesCuentasporPagaryCobrar5Digitos.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				if (dr["CuentaContable"].ToString()==CUENTAA || dr["CuentaContable"].ToString()==CUENTAB)
				{
					string Parametros = IDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[IDCENTROOPERATIVO].ToString()
										+ Utilitario.Constantes.SIGNOAMPERSON 
										+ NOMBRECUENTA + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[NOMBRECUENTA].ToString()
										+ Utilitario.Constantes.SIGNOAMPERSON 
										+ CUENTACONTABLE + Utilitario.Constantes.SIGNOIGUAL + dr["CuentaContable"].ToString()
										+ Utilitario.Constantes.SIGNOAMPERSON 
										+ NOMBRECUENTACONTABLE + Utilitario.Constantes.SIGNOIGUAL + dr["NombreCuenta"].ToString();

					string strVentana= JSMOSTRARVENTANA  + Utilitario.Constantes.SIGNOABREPARANTESIS + Utilitario.Constantes.SIGNOCOMILLASIMPLE 
																		+ URLDETALLE + Utilitario.Constantes.SIGNOCOMILLASIMPLE + Utilitario.Constantes.SIGNOCOMA 
																		+ Utilitario.Constantes.SIGNOCOMILLASIMPLE +  Parametros + Utilitario.Constantes.SIGNOCOMILLASIMPLE 
																		+ Utilitario.Constantes.SIGNOCIERRAPARANTESIS;

					Helper.ConfiguraColumnaHyperLink(e.Item.Cells[0],grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex,strVentana);
				}
				else
				{
					Helper.ConfiguraColumnaHyperLink(e.Item.Cells[0],grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				}

				e.Item.Cells[3].Text = Convert.ToDouble(e.Item.Cells[3].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
			}

			if(e.Item.ItemType == ListItemType.Footer)
			{
				Utilitario.Helper.FooterSpan(sender,e,0,2,3);
				e.Item.Cells[0].Text ="TOTAL :";
				ArrayList arrTotal = (ArrayList)Session[VARIABLETOTALIZA];
				e.Item.Cells[3].Text = Convert.ToDouble(arrTotal[0]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				Session[VARIABLETOTALIZA] = null;
			}



		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			/*hGridPaginaSort.Value = e.SortExpression.ToString();
			this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Convert.ToInt32(this.hGridPagina.Value));	*/

		}
	}
}
