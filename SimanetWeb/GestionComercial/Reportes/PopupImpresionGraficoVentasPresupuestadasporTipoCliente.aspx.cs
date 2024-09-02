using System;
using System.Data;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;
using NetAccessControl;
using SIMA.SimaNetWeb.InterfacesIU;
using SIMA.EntidadesNegocio.GestionComercial;
using SIMA.Controladoras.General;
using SIMA.Controladoras.GestionComercial;
using SIMA.Utilitario;
using SIMA.Log;


namespace SIMA.SimaNetWeb.GestionComercial.Reportes
{
	/// <summary>
	/// Summary description for PopupImpresionGraficoVentasPresupuestadasporTipoCliente.
	/// </summary>
	public class PopupImpresionGraficoVentasPresupuestadasporTipoCliente : System.Web.UI.Page, IPaginaBase
	{
		#region controles
		protected System.Web.UI.WebControls.Label lblSubTitulo;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Image imgTipoCliente;
		protected projDataGridWeb.DataGridWeb dgConsulta;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion

		#region constantes
		
		const string URLGENERADORGRAFICOS = "ChartGenerator.aspx?";

		//Otros
		const string KEYALTO = "alto";
		const string KEYANCHO = "ancho";
		const string KEYCANTIDADGLOSAS = "cantidadglosas";
		const string VALORESX = "xValues";
		const string VALORESY = "yValues";
		const string VALORIMPRESION = "Print";
		const string VALORTIPOGRAFICO = "ChartType";
		const string TIPOGRAFICOBARRA = "bar";
		const string KEYGRAFICOGRANDE = "grafico";
		const int alto = 300;
		const int ancho = 650;
		const int cantidadglosas = 4;
		const int flgGraficoGrande = 17;
		const int Cantidad = 2;

		#endregion
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			this.ConfigurarAccesoControles();
			this.LlenarDatos();
			this.LlenarGrilla();
			this.Imprimir();	
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			CImpresion oCImpresion =  new CImpresion();
			DataTable dtImpresion =  oCImpresion.ObtenerDataImprimir();
			
			if(dtImpresion.Rows.Count > 0)
			{
				DataView dwImpresion0 = dtImpresion.DefaultView;
				dgConsulta.DataSource = dwImpresion0;
			}
			else
			{
				dgConsulta.DataSource = null;
			}
			try
			{
				dgConsulta.DataBind();
			}
			catch(Exception ex)
			{
				string a = ex.Message;
			}
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add PopupImpresionGraficoVentasPresupuestadasporTipoCliente.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add PopupImpresionGraficoVentasPresupuestadasporTipoCliente.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add PopupImpresionGraficoVentasPresupuestadasporTipoCliente.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			lblTitulo.Text = CImpresion.ObtenerTituloReporte();
			lblSubTitulo.Text = CImpresion.ObtenerSubTituloReporte();

			CImpresion oCImpresion =  new CImpresion();
			StringBuilder [] Coordenadas = oCImpresion.ObtenerCoordenadaImprimir();

			if(Coordenadas[Constantes.POSICIONCONTADOR] != null && Coordenadas[Constantes.POSICIONCONTADOR+1] != null)
			{
				imgTipoCliente.ImageUrl = URLGENERADORGRAFICOS + 
					VALORESX + Constantes.SIGNOIGUAL + Coordenadas[Constantes.POSICIONCONTADOR].ToString() + Constantes.SIGNOAMPERSON +
					VALORESY + Constantes.SIGNOIGUAL + Coordenadas[Constantes.POSICIONCONTADOR+1].ToString() + Constantes.SIGNOAMPERSON +
					VALORTIPOGRAFICO + Constantes.SIGNOIGUAL + TIPOGRAFICOBARRA + Constantes.SIGNOAMPERSON +
					KEYALTO + Constantes.SIGNOIGUAL + alto + Constantes.SIGNOAMPERSON +
					KEYANCHO + Constantes.SIGNOIGUAL + ancho + Constantes.SIGNOAMPERSON +
					VALORIMPRESION + Constantes.SIGNOIGUAL + Boolean.TrueString;;
			
				imgTipoCliente.Visible = true;
				imgTipoCliente.Attributes.Clear();
				this.lblTitulo.Visible = true;
			}
			else
			{
				imgTipoCliente.ImageUrl = null;
				imgTipoCliente.Visible = false;
				imgTipoCliente.Attributes.Clear();
				this.lblTitulo.Visible = true;
			}

			
		}
		public void LlenarJScript()
		{
			// TODO:  Add PopupImpresionGraficoVentasPresupuestadasporTipoCliente.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add PopupImpresionGraficoVentasPresupuestadasporTipoCliente.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			ltlMensaje.Text  = Helper.Imprimir();
		}

		public void Exportar()
		{
			// TODO:  Add PopupImpresionGraficoVentasPresupuestadasporTipoCliente.Exportar implementation
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
			// TODO:  Add PopupImpresionGraficoVentasPresupuestadasporTipoCliente.ValidarFiltros implementation
			return false;
		}

		#endregion
	}
}
