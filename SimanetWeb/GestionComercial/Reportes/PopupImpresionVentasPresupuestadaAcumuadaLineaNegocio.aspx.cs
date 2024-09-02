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
	/// Summary description for PopupImpresionVentasPresupuestadaAcumuadaLineaNegocio.
	/// </summary>
	public class PopupImpresionVentasPresupuestadaAcumuadaLineaNegocio : System.Web.UI.Page, IPaginaBase
	{
		#region controles
		protected System.Web.UI.WebControls.Label lblTitulo1;
		protected System.Web.UI.WebControls.Image ChartImage;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion

		#region Constantes
		//Paginas
		const string URLGENERADORGRAFICOS = "ChartGenerator.aspx?";

		//Otros
		const string TITULOVACIO = "No existen Ventas por Linea de Negocio";
		const string TituloConstante = "GRAFICO COMPARATIVO DEL SECTOR MARINA POR LINEA DE NEGOCIO";
		const string KEYALTO = "alto";
		const string KEYANCHO = "ancho";
		const string KEYCANTIDADGLOSAS = "cantidadglosas";
		const string VALORESX = "xValues";
		const string VALORESY = "yValues";
		const string VALORIMPRESION = "Print";
		const string VALORTIPOGRAFICO = "ChartType";
		const string TIPOGRAFICOBARRA = "bar";
		const string KEYGRAFICOGRANDE = "grafico";
		const int alto = 118;
		const int ancho = 710;
		const int cantidadglosas = 4;
		const int flgGraficoGrande = 17;
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
			
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add PopupImpresionVentasPresupuestadaAcumuadaLineaNegocio.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add PopupImpresionVentasPresupuestadaAcumuadaLineaNegocio.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add PopupImpresionVentasPresupuestadaAcumuadaLineaNegocio.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			lblTitulo.Text = CImpresion.ObtenerTituloReporte();
			this.lblTitulo1.Text = Convert.ToString(DateTime.Today.Year - 1) + Utilitario.Constantes.LINEA + DateTime.Today.Year.ToString();

			CImpresion oCImpresion =  new CImpresion();
			StringBuilder [] Coordenadas = oCImpresion.ObtenerCoordenadasImprimir();

			if(Coordenadas[Constantes.POSICIONCONTADOR] != null && Coordenadas[Constantes.POSICIONCONTADOR+1] != null)
			{

				if(Coordenadas[Constantes.POSICIONCONTADOR].ToString().Split(Constantes.SIGNOLINEAVERTICAL.ToCharArray()).Length > flgGraficoGrande)
				{
					ChartImage.ImageUrl = URLGENERADORGRAFICOS + 
						VALORESX + Constantes.SIGNOIGUAL + Coordenadas[Constantes.POSICIONCONTADOR].ToString() + Constantes.SIGNOAMPERSON +
						VALORESY + Constantes.SIGNOIGUAL + Coordenadas[Constantes.POSICIONCONTADOR+1].ToString() + Constantes.SIGNOAMPERSON +
						VALORTIPOGRAFICO + Constantes.SIGNOIGUAL + TIPOGRAFICOBARRA + Constantes.SIGNOAMPERSON +
						KEYANCHO + Constantes.SIGNOIGUAL + ancho.ToString() + Constantes.SIGNOAMPERSON +
						KEYGRAFICOGRANDE + Constantes.SIGNOIGUAL + flgGraficoGrande.ToString() + Constantes.SIGNOAMPERSON +
						VALORIMPRESION + Constantes.SIGNOIGUAL + Boolean.TrueString;
			
				}
				else
				{
					ChartImage.ImageUrl = URLGENERADORGRAFICOS + 
						VALORESX + Constantes.SIGNOIGUAL + Coordenadas[Constantes.POSICIONCONTADOR].ToString() + Constantes.SIGNOAMPERSON +
						VALORESY + Constantes.SIGNOIGUAL + Coordenadas[Constantes.POSICIONCONTADOR+1].ToString() + Constantes.SIGNOAMPERSON +
						VALORTIPOGRAFICO + Constantes.SIGNOIGUAL + TIPOGRAFICOBARRA + Constantes.SIGNOAMPERSON +
						KEYANCHO + Constantes.SIGNOIGUAL + ancho.ToString() + Constantes.SIGNOAMPERSON +
						VALORIMPRESION + Constantes.SIGNOIGUAL + Boolean.TrueString;
				}

				ChartImage.Visible = true;
				ChartImage.Attributes.Clear();
				this.lblTitulo.Visible = true;
				this.lblTitulo.Text = TituloConstante;
			}
			else
			{
				ChartImage.ImageUrl = null;
				ChartImage.Visible = false;
				ChartImage.Attributes.Clear();
				this.lblTitulo.Visible = true;
				this.lblTitulo.Text = TITULOVACIO;
			}
		}

		public void LlenarJScript()
		{
			// TODO:  Add PopupImpresionVentasPresupuestadaAcumuadaLineaNegocio.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add PopupImpresionVentasPresupuestadaAcumuadaLineaNegocio.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			ltlMensaje.Text  = Helper.Imprimir();
		}

		public void Exportar()
		{
			// TODO:  Add PopupImpresionVentasPresupuestadaAcumuadaLineaNegocio.Exportar implementation
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
			// TODO:  Add PopupImpresionVentasPresupuestadaAcumuadaLineaNegocio.ValidarFiltros implementation
			return false;
		}

		#endregion
	}
}
