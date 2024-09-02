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
using SIMA.Controladoras.GestionEstrategica.Inventario;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using NullableTypes;
using MetaBuilders.WebControls;
using System.Reflection;

namespace SIMA.SimaNetWeb.GestionEstrategica.Inventario
{
	/// <summary>
	/// Summary description for ConsultarActivoPorArea.
	/// </summary>
	public class ConsultarActivoPorArea : System.Web.UI.Page,IPaginaBase
	{
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.ImageButton ImgImprimir;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.TextBox txtBuscarArea;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdArea;
		protected System.Web.UI.HtmlControls.HtmlInputFile FUFile;
		protected System.Web.UI.WebControls.Button btnSubir;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hNombreArchivoUP;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hPatFile;
		protected System.Web.UI.WebControls.Label lblLinkFile;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
	
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


		DataTable DataTabla()
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
			this.btnSubir.Click += new System.EventHandler(this.btnSubir_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			DataTable dt= this.DataTabla();
			if(dt!=null)
			{
				DataView dw = dt.DefaultView;
				grid.DataSource = dw;
			}
			else
			{
				grid.DataSource = dt;
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

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarActivoPorArea.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add ConsultarActivoPorArea.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add ConsultarActivoPorArea.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add ConsultarActivoPorArea.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			this.ImgImprimir.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.HistorialIrAdelantePersonalizado("hIdArea","txtBuscarArea")+Helper.PopupDeEspera());
			btnSubir.Style["display"]="none";
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarActivoPorArea.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarActivoPorArea.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarActivoPorArea.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add ConsultarActivoPorArea.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ConsultarActivoPorArea.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void ImgImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EjecutarReporte(@"C:\SimanetReportes\GestionEstrategica\","InventarioPorAreaRC.rpt",(new CActivoFijoyCtaOrden()).ListarAFPorArea(Convert.ToInt32(this.hIdArea.Value)),false,false,".xls");
		}


		private void btnSubir_Click(object sender, System.EventArgs e)
		{
			string RutaLocalEstrategica = @"C:\SIMANETCOMPLEMENTOS\Estrategica\";
			string []arrNombre = this.hNombreArchivoUP.Value.ToString().Split('.');
			string Ext =arrNombre[arrNombre.Length-1];
			string SoloNombre = this.hNombreArchivoUP.Value.ToString().Substring(0,this.hNombreArchivoUP.Value.ToString().Length-(Ext.Length+1));
			string NombreArchivo = SoloNombre;
			Helper.SubirArchivo(this.FUFile,RutaLocalEstrategica,"SustentoInversion");
		}
	}
}
