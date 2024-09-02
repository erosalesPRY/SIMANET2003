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
using System.Reflection;

namespace SIMA.SimaNetWeb.GestionFinanciera.CartasFianza
{
	/// <summary>
	/// Summary description for ConsultarCartaFianzaDetalleRenovacionyGasto.
	/// </summary>
	public class ConsultarCartaFianzaDetalleRenovacionyGasto : System.Web.UI.Page,IPaginaBase
	{
		#region Constantes
			
		#endregion
		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.Label Label13;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox txtCentroOperativo;
		protected System.Web.UI.WebControls.TextBox txtProyecto;
		protected System.Web.UI.WebControls.TextBox txtTipo;
		protected System.Web.UI.WebControls.TextBox txtBeneficiario;
		protected System.Web.UI.WebControls.TextBox txtConcepto;
		protected System.Web.UI.WebControls.TextBox txtBanco;
		protected projDataGridWeb.DataGridWeb gridRenovaciones;
		protected projDataGridWeb.DataGridWeb gridCargos;
		protected System.Web.UI.WebControls.TextBox txtBuscarFZA;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtNroCartaFianza;
		protected System.Web.UI.WebControls.Button ibtnDatos;
		protected System.Web.UI.WebControls.ImageButton ImgImprimir;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hPeriodo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidCFza;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidCentroOperativo;
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
					this.LlenarGrilla();
					Helper.ReestablecerPagina();
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
					ltlMensaje.Text = Helper.MsgdbErrMostrarMesaje(true,oSIMAExcepcionDominio.Error.ToString());					
				}
				catch(Exception oException)
				{
					SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Utilitario.Constantes.CODIGOERRORGENERICO,oException.Message);
					Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
				}
			}				
		}

		DataTable Renovaciones(){
			DataTable dt = new  DataTable();
			dt.Columns.Add("Col1");
			dt.Columns.Add("Col2");
			dt.Columns.Add("Col3");
			dt.Columns.Add("Col4");
			dt.Columns.Add("Col5");
			object []Data={"","","","",""};
			dt.Rows.Add(Data);
			return dt;
		}
		DataTable Cargos()
		{
			DataTable dt = new  DataTable();
			dt.Columns.Add("Col1");
			dt.Columns.Add("Col2");
			dt.Columns.Add("Col3");
			dt.Columns.Add("Col4");
			dt.Columns.Add("Col5");
			dt.Columns.Add("Col6");
			dt.Columns.Add("Col7");
			object []Data={"","","","","","",""};
			dt.Rows.Add(Data);
			return dt;
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
			this.ImgImprimir.Click += new System.Web.UI.ImageClickEventHandler(this.ImgImprimir_Click);
			this.gridRenovaciones.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.gridRenovaciones_ItemDataBound);
			this.gridCargos.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.gridCargos_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrillaRenovacion()
		{
			DataTable dtCartaFianza = this.Renovaciones();

			if(dtCartaFianza!=null)
			{
				DataView dwCartaFianza = dtCartaFianza.DefaultView;
				gridRenovaciones.DataSource = dwCartaFianza;
			}
			else
			{
				gridRenovaciones.DataSource = dtCartaFianza;
			}
			try
			{
				gridRenovaciones.DataBind();
			}
			catch	
			{
				gridRenovaciones.CurrentPageIndex = 0;
				gridRenovaciones.DataBind();
			}
		}
		public void LlenarGrillaCargos()
		{
			DataTable dtCartaFianza = this.Cargos();

			if(dtCartaFianza!=null)
			{
				DataView dwCartaFianza = dtCartaFianza.DefaultView;
				gridCargos.DataSource = dwCartaFianza;
			}
			else
			{
				gridCargos.DataSource = dtCartaFianza;
			}
			try
			{
				gridCargos.DataBind();
			}
			catch	
			{
				gridCargos.CurrentPageIndex = 0;
				gridCargos.DataBind();
			}
		}

		public void LlenarGrilla()
		{
			LlenarGrillaRenovacion();
			LlenarGrillaCargos();
		}
		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarCartaFianzaDetalleRenovacionyGasto.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add ConsultarCartaFianzaDetalleRenovacionyGasto.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add ConsultarCartaFianzaDetalleRenovacionyGasto.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add ConsultarCartaFianzaDetalleRenovacionyGasto.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			this.ImgImprimir.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.HistorialIrAdelantePersonalizado("txtBuscarFZA","txtCentroOperativo","txtBanco","txtBeneficiario","txtTipo","txtProyecto","txtConcepto","txtNroCartaFianza","hidCFza","hPeriodo","hidCentroOperativo")+Helper.PopupDeEspera());
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarCartaFianzaDetalleRenovacionyGasto.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarCartaFianzaDetalleRenovacionyGasto.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarCartaFianzaDetalleRenovacionyGasto.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add ConsultarCartaFianzaDetalleRenovacionyGasto.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ConsultarCartaFianzaDetalleRenovacionyGasto.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void gridRenovaciones_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				e.Item.Style.Add("display","none");
			}
		}

		private void gridCargos_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				e.Item.Style.Add("display","none");
			}
		}

		private void ImgImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			
			DataSet ds = new DataSet("sw");
			DataTable dt1 =  Helper.DataViewTODataTable((new CCartaFianza()).ConsultarCartaFianzaDetallePorNro("nrocartafianza",txtNroCartaFianza.Text,1).DefaultView);
			dt1.TableName="FINuspNTADConsultarCartaFianzaDetallePorNro;1";
			ds.Tables.Add(dt1);

			DataTable dt2 = Helper.DataViewTODataTable((new CCartaFianza()).ConsultarRenovacionCartaFianza(Convert.ToInt32(this.hidCFza.Value),Convert.ToInt32(this.hPeriodo.Value),1).DefaultView);
			if(dt2!=null)
			{
				dt2.TableName="FINuspNTADConsultaCartaFianzaRenovacion;1";
				ds.Tables.Add(dt2);
			}

			DataTable dt3 = (new CCartaFianza()).ConsultarCartaFianzaNotadeCargo(Convert.ToInt32(this.hidCentroOperativo.Value)
							,0
							,Convert.ToInt32(this.hidCFza.Value)
							,Convert.ToInt32(this.hPeriodo.Value));
			if(dt3!=null)
			{
				dt3.TableName="FINuspNTADConsultaCartaFianzaNota;1";
				ds.Tables.Add(Helper.DataViewTODataTable(dt3.DefaultView));
			}
			else{

				dt3  = new DataTable("FINuspNTADConsultaCartaFianzaNota;1");
				ds.Tables.Add(dt3);

			}

			Helper.EjecutarReporte(@"C:\SimanetReportes\GestionFinanciera\OperacionesFinancieras\","ReporteCartaFianzaDetalle.rpt",ds,false);

		}

	}
}
