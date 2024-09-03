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

namespace SIMA.SimaNetWeb.GestionFinanciera.DescuentoLetras
{
	public class ConsultarDescuentodeLetras : System.Web.UI.Page,IPaginaBase
	{
		#region Constantes
		const string GRILLAVACIA ="No existe ningún Registro de Letras.";  

		const string KEYIDENTIDADFINANCIERA = "idEF";
		const string KEYIDTIPOLETRA = "TipoLetra";
		const string KEYNOMBRETIPOLETRA = "NombreTipoLetra";
		
		//decuento de letras
		const string KEYIDTIPOLETRADESC = "TipoDLetra";
		const string KEYIDNOMBRETIPODESC ="NomTipo";



		const string KEYIDDOCDESCLET ="idDocdescLetra";

		const string URLPAGINADETALLE = "DetalleDescuento.aspx?";
		const string URLPAGINALETRASDESCUENTO = "AdministrarPaquetedeLetras.aspx?";

		const string CAMPOTOTAL1 = "lblMontoDesembolso";
		const string CAMPOTOTAL2 = "lblMontoDescuento";
		const string CAMPOTOTAL3 = "lblMontoLetras";
		const string CAMPOTOTAL4 = "lblMontoAmortizado";
		const string CAMPOTOTAL5= "lblMontoSaldo";
				
		#endregion

		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminaFiltro;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnFiltrarSeleccion;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPaginaSort;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidDescuento;
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
					this.LlenarDatos();
					this.LlenarCombos();
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionFinanciera",this.ToString(),"Se consultó Carta de Crédito.",Enumerados.NivelesErrorLog.I.ToString()));
					Helper.ReestablecerPagina(this);
					this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value ,Convert.ToInt32(hGridPagina.Value));
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
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add ConsultarDescuentodeLetras.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarDescuentodeLetras.LlenarGrillaOrdenamiento implementation
		}
		private DataTable ObtenerDatos()
		{			
			return ((CDescuento) new CDescuento()).AdministrarDetalleDescuento(
				Utilitario.Constantes.IDDEFAULT.ToString()
				,Convert.ToInt32(Page.Request.Params[KEYIDTIPOLETRA])
				,Convert.ToInt32(Page.Request.Params[KEYIDENTIDADFINANCIERA]==null? Utilitario.Constantes.IDDEFAULT.ToString():Page.Request.Params[KEYIDENTIDADFINANCIERA]) ) ;
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			this.grid.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(Utilitario.Helper.FooterSpan);
			DataTable dtLetras=this.ObtenerDatos();
			if(dtLetras!=null)
			{
				DataView dwLetras= dtLetras.DefaultView;
				dwLetras.RowFilter = Helper.ObtenerFiltro();
				grid.Columns[Utilitario.Constantes.POSICIONFOOTERTOTAL].FooterText = Utilitario.Constantes.TEXTOFOOTERTOTAL + Utilitario.Constantes.ESPACIO + dwLetras.Count.ToString();
				dwLetras.Sort = columnaOrdenar ;
				grid.DataSource = dwLetras;
				grid.CurrentPageIndex = indicePagina;
				lblResultado.Visible = false;
			}
			else
			{
				grid.DataSource = dtLetras;
				lblResultado.Visible = true;
				lblResultado.Text = GRILLAVACIA;
				//ibtnImprimir.Visible = false;
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
			// TODO:  Add ConsultarDescuentodeLetras.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add ConsultarDescuentodeLetras.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarDescuentodeLetras.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarDescuentodeLetras.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarDescuentodeLetras.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarDescuentodeLetras.Exportar implementation
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
			// TODO:  Add ConsultarDescuentodeLetras.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;				

//				Helper.ConfiguraColumnaHyperLink(Utilitario.Enumerados.EventosJavaScript.OnClick,e.Item.Cells[0],grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex,
//						Helper.HistorialIrAdelantePersonalizado(Utilitario.Constantes.VACIO),
//						Helper.MostrarVentana(URLPAGINADETALLE,KEYIDDOCDESCLET + Utilitario.Constantes.SIGNOIGUAL + dr[Utilitario.Enumerados.FinColumnaDescuento.idDescuento.ToString()].ToString()
//															+ Utilitario.Constantes.SIGNOAMPERSON
//															+ KEYIDTIPOLETRA + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDTIPOLETRA].ToString()
//															+ Utilitario.Constantes.SIGNOAMPERSON
//															+ KEYNOMBRETIPOLETRA + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYNOMBRETIPOLETRA].ToString()
//															+ Utilitario.Constantes.SIGNOAMPERSON
//															+ Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Enumerados.ModoPagina.M.ToString()));


				Helper.ConfiguraColumnaHyperLink(Utilitario.Enumerados.EventosJavaScript.OnClick,e.Item.Cells[0],grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex,
					Helper.HistorialIrAdelantePersonalizado(Utilitario.Constantes.VACIO),
					Helper.MostrarVentana(URLPAGINADETALLE,KEYIDDOCDESCLET + Utilitario.Constantes.SIGNOIGUAL + dr[Utilitario.Enumerados.FinColumnaDescuento.idDescuento.ToString()].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYIDTIPOLETRA + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDTIPOLETRADESC].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYNOMBRETIPOLETRA + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDNOMBRETIPODESC].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Enumerados.ModoPagina.C.ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYIDENTIDADFINANCIERA + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDENTIDADFINANCIERA].ToString()
					));


				((Label)e.Item.Cells[7].FindControl(CAMPOTOTAL1)).Text = Convert.ToDouble(dr[Utilitario.Enumerados.FinColumnaDescuento.MontoDesembolso.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				((Label)e.Item.Cells[7].FindControl(CAMPOTOTAL2)).Text = Convert.ToDouble(dr[Utilitario.Enumerados.FinColumnaDescuento.MontoInteresCobradoBCO.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				((Label)e.Item.Cells[7].FindControl(CAMPOTOTAL3)).Text = Convert.ToDouble(dr[Utilitario.Enumerados.FinColumnaDescuento.MontoLetras.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				((Label)e.Item.Cells[7].FindControl(CAMPOTOTAL4)).Text = Convert.ToDouble(dr[Utilitario.Enumerados.FinColumnaDescuento.MontoAmortiza.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				((Label)e.Item.Cells[7].FindControl(CAMPOTOTAL5)).Text = Convert.ToDouble(dr[Utilitario.Enumerados.FinColumnaDescuento.SaldoLetra.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,Helper.MostrarDatosEnCajaTexto("hidDescuento",dr[Utilitario.Enumerados.FinColumnaDescuento.idDescuento.ToString()].ToString()));
				Helper.FiltroporSeleccionConfiguraColumna(e,grid);

			}		
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
		}

}
