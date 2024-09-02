using System;
using System.Web.UI.WebControls;
using System.Text;
using SIMA.Utilitario;
using SIMA.EntidadesNegocio.GestionComercial;
using SIMA.Controladoras.GestionComercial;
using SIMA.SimaNetWeb.InterfacesIU;
using NetAccessControl;
using SIMA.Controladoras.General;
using SIMA.Log;
using System.Data;

namespace SIMA.SimaNetWeb.GestionComercial.Reportes
{
	/// <summary>
	/// Summary description for PopupImpresionGraficoVentasPresupuestadasContribucionLN.
	/// </summary>
	public class PopupImpresionGraficoVentasPresupuestadasContribucionLN : System.Web.UI.Page, IPaginaBase
	{
		#region controles
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Image ChartImage;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion

		#region Constantes
		//Paginas
		const string URLGENERADORGRAFICOS = "ChartGenerator.aspx?";

		//Otros
		const string VALORTIPOGRAFICO = "ChartType";
		const string KEYALTO = "alto";
		const string KEYANCHO = "ancho";
		const string KEYCANTIDADGLOSAS = "cantidadglosas";
		const string VALORESX = "xValues";
		const string VALORESY = "yValues";
		const string VALORIMPRESION = "Print";

		const string TIPOGRAFICOBARRA = "bar";
		const int alto = 118;
		const int ancho = 730;
		const int cantidadglosas = 4;
		protected System.Web.UI.WebControls.Label lblSubTitulo;
		const int Cantidad = 2;

		#endregion
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			this.ConfigurarAccesoControles();
			this.LlenarDatos();
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
			// TODO:  Add PopupImpresionGraficoVentasPresupuestadasContribucionLN.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add PopupImpresionGraficoVentasPresupuestadasContribucionLN.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add PopupImpresionGraficoVentasPresupuestadasContribucionLN.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add PopupImpresionGraficoVentasPresupuestadasContribucionLN.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			lblTitulo.Text = CImpresion.ObtenerTituloReporte();
			lblSubTitulo.Text = CImpresion.ObtenerSubTituloReporte();

			CImpresion oCImpresion =  new CImpresion();
			StringBuilder [] Coordenadas = oCImpresion.ObtenerCoordenadasImprimir();

			ChartImage.ImageUrl = URLGENERADORGRAFICOS + 
				VALORESX + Constantes.SIGNOIGUAL + Coordenadas[Constantes.POSICIONCONTADOR].ToString() + Constantes.SIGNOAMPERSON +
				VALORESY + Constantes.SIGNOIGUAL + Coordenadas[Constantes.POSICIONCONTADOR+1].ToString() + Constantes.SIGNOAMPERSON +
				VALORIMPRESION + Constantes.SIGNOIGUAL + Boolean.TrueString;
			
			ChartImage.Visible = true;
			ChartImage.Attributes.Clear();
		}

		public void LlenarJScript()
		{
			// TODO:  Add PopupImpresionGraficoVentasPresupuestadasContribucionLN.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add PopupImpresionGraficoVentasPresupuestadasContribucionLN.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			ltlMensaje.Text = Helper.Imprimir();
		}

		public void Exportar()
		{
			// TODO:  Add PopupImpresionGraficoVentasPresupuestadasContribucionLN.Exportar implementation
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
			// TODO:  Add PopupImpresionGraficoVentasPresupuestadasContribucionLN.ValidarFiltros implementation
			return false;
		}

		#endregion
	}
}
