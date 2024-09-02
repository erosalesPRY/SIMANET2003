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
	/// Summary description for PopupImpresionGraficoVentasPresupuestadasporCOSinCompararVentas.
	/// </summary>
	public class PopupImpresionGraficoVentasPresupuestadasporCOSinCompararVentas : System.Web.UI.Page, IPaginaBase
	{
		#region controles
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblSubTitulo;
		protected System.Web.UI.WebControls.Image ChartImage;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion

		#region Constantes
		//Paginas
		const string URLGENERADORGRAFICOS = "ChartGenerator.aspx?";

		//Otros
		const string TipoMensual = "Mensual";
		const string TipoAcumulado = "Acumulado";
		const string VALORESX = "xValues";
		const string VALORESY = "yValues";
		const string VALORIMPRESION = "Print";
			
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
			// TODO:  Add PopupImpresionGraficoVentasPresupuestadasporCOSinCompararVentas.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add PopupImpresionGraficoVentasPresupuestadasporCOSinCompararVentas.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add PopupImpresionGraficoVentasPresupuestadasporCOSinCompararVentas.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add PopupImpresionGraficoVentasPresupuestadasporCOSinCompararVentas.LlenarCombos implementation
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
			// TODO:  Add PopupImpresionGraficoVentasPresupuestadasporCOSinCompararVentas.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add PopupImpresionGraficoVentasPresupuestadasporCOSinCompararVentas.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			ltlMensaje.Text = Helper.Imprimir();
		}

		public void Exportar()
		{
			// TODO:  Add PopupImpresionGraficoVentasPresupuestadasporCOSinCompararVentas.Exportar implementation
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
			// TODO:  Add PopupImpresionGraficoVentasPresupuestadasporCOSinCompararVentas.ValidarFiltros implementation
			return false;
		}

		#endregion
	}
}
