using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using SIMA.SimaNetWeb.InterfacesIU;
using SIMA.Controladoras.GestionLogistica;
using SIMA.Controladoras.General;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;
using System.Configuration;

namespace SIMA.SimaNetWeb.GestionLogistica
{
	/// <summary>
	/// Summary description for ResumenPorProveedorOCompraOServicio.
	/// </summary>
	public class ResumenPorProveedorOCompraOServicio : System.Web.UI.Page, IPaginaBase
	{
		protected projDataGridWeb.DataGridWeb grid;
		
		const string KEYIDDOCUMENTO="Documento";
		const string KEYIDESTADO="Estado";
		const string KEYIDPERIODO="Periodo";
		const string KEYIDMES="Mes";
		const string KEYIDMONEDA="Moneda";
		const string KEYIDRUC="Ruc";
		const string KEYIDTITULO="Titulo";
		const string KEYIDRAZONSOCIAL="Razon";
		const string KEYIDIMPORTE="Importe";
		const string KEYIDTOTALMONEDA="TotalMoneda";

		const string URLDETALLE ="ListadoOCompraOServicioDeProveedor.aspx?";


		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label LblMoneda;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label LblEstado;
		protected System.Web.UI.WebControls.Label Lbl;
		protected System.Web.UI.WebControls.Label LblAño;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label LblMes;
		protected System.Web.UI.WebControls.Label LblDocumento;
		protected System.Web.UI.WebControls.Button btnOk;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label LblImporte;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.ImageButton ImgImprimir;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hNroRUC;
		protected System.Web.UI.WebControls.Label Label2;


		
		private string Documento
		{
			get{return (Page.Request.Params[KEYIDDOCUMENTO]); }
		}
		private string Estado
		{
			get{return (Page.Request.Params[KEYIDESTADO]); }
		}
		private int Periodo
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYIDPERIODO]); }
		}
		private int Mes
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYIDMES]); }
		}
		private string Moneda
		{
			get{return (Page.Request.Params[KEYIDMONEDA]); }
		}
		private string Ruc
		{
			get{return ((this.hNroRUC.Value.Length==0)?Page.Request.Params[KEYIDRUC]:this.hNroRUC.Value); }
		}
		private string Titulo
		{
			get{return (Page.Request.Params[KEYIDTITULO]); }
		}
		private string TotalMoneda
		{
			get{return (Page.Request.Params[KEYIDTOTALMONEDA]); }
		}
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();	
					Helper.ReiniciarSession();
					this.LlenarJScript();
					this.LlenarCombos();
					this.LlenarDatos();
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(), "Gestión de Personal: Administrar Becados", this.ToString(),"Se consultó El Listado de las Capacitaciones en el Extranjero.",Enumerados.NivelesErrorLog.I.ToString()));
					Helper.ReestablecerPagina();
					this.LlenarGrilla();
				}
				catch(SIMAExcepcionLog oSIMAExcepcionLog)
				{
					Helper.MsgBox(oSIMAExcepcionLog.Mensaje);					
				}
				catch(SIMAExcepcionIU oSIMAExcepcionIU)
				{
					Helper.MsgBox(oSIMAExcepcionIU.Mensaje);					
				}
				catch(SIMAExcepcionDominio oSIMAExcepcionDominio)
				{
					Helper.MsgBox(oSIMAExcepcionDominio.Mensaje);					
				}
				catch(Exception oException)
				{
					string msg = oException.Message.ToString();
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
			this.ImgImprimir.Click += new System.Web.UI.ImageClickEventHandler(this.ImgImprimir_Click);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			CResumenOCompraOServicio oCResumenOCompraOServicio = new CResumenOCompraOServicio();
			DataTable dtResumen = oCResumenOCompraOServicio.ListarResumenProveedor(this.Documento,this.Estado,this.Periodo,this.Mes,this.Moneda,this.Ruc);

			if(dtResumen!=null)
			{
				grid.DataSource = dtResumen;

			}
			else
			{
				grid.DataSource = dtResumen;
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
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ResumenPorProveedorOCompraOServicio.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add ResumenPorProveedorOCompraOServicio.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add ResumenPorProveedorOCompraOServicio.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			this.LblDocumento.Text=this.Titulo;
			this.LblMoneda.Text=this.Moneda;
			this.LblEstado.Text=this.Estado;
			this.LblAño.Text=this.Periodo.ToString();
			this.LblMes.Text= Helper.ObtenerNombreMes(this.Mes,SIMA.Utilitario.Enumerados.TipoDatoMes.NombreCompleto);
			this.LblImporte.Text=this.TotalMoneda;
			this.hNroRUC.Value = this.Ruc;
		}

		public void LlenarJScript()
		{
			this.ImgImprimir.Attributes[Utilitario.Enumerados.EventosJavaScript.OnClick.ToString()]="ObtenerSeleccionados()";
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ResumenPorProveedorOCompraOServicio.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			DataTable dt = (new CResumenOCompraOServicio()).ListarDocumentos(this.Documento,this.Estado,this.Periodo,this.Mes,this.Moneda,this.hNroRUC.Value);
			Helper.EjecutarReporte(@"C:\SimanetReportes\Logistica\","Listado-OC-OS.rpt",dt,false);		
		
		}

		public void Exportar()
		{
			// TODO:  Add ResumenPorProveedorOCompraOServicio.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add ResumenPorProveedorOCompraOServicio.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ResumenPorProveedorOCompraOServicio.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				string ImporteProv = Convert.ToDouble(((this.Moneda=="SOLES")?dr["SOLES"].ToString():dr["DOLARES"].ToString())).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				string Historial = Helper.HistorialIrAdelantePersonalizado("");

				string parametros =  KEYIDPERIODO + Utilitario.Constantes.SIGNOIGUAL +this.Periodo.ToString() 
									+ Utilitario.Constantes.SIGNOAMPERSON
									+ KEYIDMES + Utilitario.Constantes.SIGNOIGUAL + this.Mes.ToString()
									+ Utilitario.Constantes.SIGNOAMPERSON
									+ KEYIDRUC  +  Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr["ruc"]) 
									+ Utilitario.Constantes.SIGNOAMPERSON
									+ KEYIDDOCUMENTO + Utilitario.Constantes.SIGNOIGUAL + this.Documento 
									+ Utilitario.Constantes.SIGNOAMPERSON
									+ KEYIDMONEDA + Utilitario.Constantes.SIGNOIGUAL + this.Moneda
									+ Utilitario.Constantes.SIGNOAMPERSON
									+ KEYIDESTADO + Utilitario.Constantes.SIGNOIGUAL + this.Estado
								    + Utilitario.Constantes.SIGNOAMPERSON
									+ KEYIDRAZONSOCIAL + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr["PROVEEDOR"]).Replace("&" , "[A]")
									+ Utilitario.Constantes.SIGNOAMPERSON
									+ KEYIDIMPORTE + Utilitario.Constantes.SIGNOIGUAL + ImporteProv
									+ Utilitario.Constantes.SIGNOAMPERSON
									+ KEYIDTOTALMONEDA + Utilitario.Constantes.SIGNOIGUAL + this.TotalMoneda
									+ Utilitario.Constantes.SIGNOAMPERSON
									+ KEYIDTITULO+ Utilitario.Constantes.SIGNOIGUAL + this.Titulo;

				Label lbl = (Label)e.Item.Cells[0].FindControl("LblRuc");
				lbl.Text =dr["RUC"].ToString();
				Helper.ConfiguraColumnaHyperLink(Enumerados.EventosJavaScript.OnClick,lbl,"Nro de RUC"
					,Historial
					,Helper.MostrarVentana(URLDETALLE,parametros));	

				e.Item.Cells[3].Text=ImporteProv;
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);

			}
		}

		private void ImgImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Imprimir();
		}

	}
}
