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
	public class PopupImpresionGraficoComparativoPorLineaNegocio : System.Web.UI.Page, IPaginaBase
	{
		#region Controles

		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblCallao;
		protected System.Web.UI.WebControls.Label lblChimbote;
		protected System.Web.UI.WebControls.Label lblIquitos;
		protected System.Web.UI.WebControls.Image imgCallao;
		protected System.Web.UI.WebControls.Image imgChimbote;
		protected System.Web.UI.WebControls.Image imgIquitos;
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
		const string VALORTIPOGRAFICO = "ChartType";
		const string TIPOGRAFICOBARRA = "bar";
		const int alto = 118;
		const int altocallao = 160;
		const int ancho = 730;
		const int cantidadglosas = 4;
		const int flgGraficoGrande = 17;
		const int Cantidad = 2;
		const string TITULOCALLAO = "SIMA CALLAO";
		const string TITULOCHIMBOTE = "SIMA CHIMBOTE";
		const string TITULOIQUITOS = "SIMA IQUITOS";
		const string TITULOCALLAOVACIO = "No existen Ventas Reales en Callao";
		const string TITULOCHIMBOTEVACIO = "No existen Ventas Reales en Chimbote";
		const string TITULOIQUITOSVACIO = "No existen Ventas Reales en Iquitos";
		const string TITULOPERU = "SIMA PERÚ";
		const string TITULOPERUVACIO = "No existen Ventas Reales en PERÚ";
		const string KEYALTO = "alto";
		const string KEYANCHO = "ancho";
		const string KEYCANTIDADGLOSAS = "cantidadglosas";
		const string KEYGRAFICOGRANDE = "grafico";
		const string KEYTIPOVISTA = "tipoVista";
		const string VistaIndividual = "Por Centro";
		const string VistaAgrupada = "SIMA-PERÚ";

		#endregion
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				this.ConfigurarAccesoControles();
				this.LlenarDatos();
				this.LlenarGrilla();
				this.Imprimir();
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			CImpresion oCImpresion =  new CImpresion();
			StringBuilder [] Coordenadas = oCImpresion.ObtenerCoordenadasImprimir();

			if(Page.Request.QueryString[KEYTIPOVISTA].ToString() == VistaIndividual)
			{
				if(Coordenadas[Constantes.POSICIONCONTADOR] != null && Coordenadas[Constantes.POSICIONCONTADOR+1] != null)
				{
					imgCallao.ImageUrl = URLGENERADORGRAFICOS + 
						VALORESX + Constantes.SIGNOIGUAL + Coordenadas[Constantes.POSICIONCONTADOR].ToString() + Constantes.SIGNOAMPERSON +
						VALORESY + Constantes.SIGNOIGUAL + Coordenadas[Constantes.POSICIONCONTADOR+1].ToString() + Constantes.SIGNOAMPERSON +
						VALORTIPOGRAFICO + Constantes.SIGNOIGUAL + TIPOGRAFICOBARRA + Constantes.SIGNOAMPERSON +
						KEYANCHO + Constantes.SIGNOIGUAL + ancho.ToString() + Constantes.SIGNOAMPERSON +
						KEYALTO + Constantes.SIGNOIGUAL + altocallao.ToString() + Constantes.SIGNOAMPERSON +
						KEYCANTIDADGLOSAS + Constantes.SIGNOIGUAL + cantidadglosas.ToString() + Constantes.SIGNOAMPERSON +
						VALORIMPRESION + Constantes.SIGNOIGUAL + Boolean.TrueString;;
			
					imgCallao.Visible = true;
					imgCallao.Attributes.Clear();
					this.lblCallao.Visible = true;
					this.lblCallao.Text = TITULOCALLAO;
				}
				else
				{
					imgCallao.ImageUrl = null;
					imgCallao.Visible = false;
					imgCallao.Attributes.Clear();
					this.lblCallao.Visible = true;
					this.lblCallao.Text = TITULOCALLAOVACIO;
				}

				if(Coordenadas[Constantes.POSICIONCONTADOR+2] != null && Coordenadas[Constantes.POSICIONCONTADOR+3] != null)
				{
					imgChimbote.ImageUrl = URLGENERADORGRAFICOS + 
						VALORESX + Constantes.SIGNOIGUAL + Coordenadas[Constantes.POSICIONCONTADOR+2].ToString() + Constantes.SIGNOAMPERSON +
						VALORESY + Constantes.SIGNOIGUAL + Coordenadas[Constantes.POSICIONCONTADOR+3].ToString() + Constantes.SIGNOAMPERSON +
						VALORTIPOGRAFICO + Constantes.SIGNOIGUAL + TIPOGRAFICOBARRA + Constantes.SIGNOAMPERSON +
						KEYANCHO + Constantes.SIGNOIGUAL + ancho.ToString() + Constantes.SIGNOAMPERSON +
						KEYALTO + Constantes.SIGNOIGUAL + alto.ToString() + Constantes.SIGNOAMPERSON +
						KEYCANTIDADGLOSAS + Constantes.SIGNOIGUAL + cantidadglosas.ToString() + Constantes.SIGNOAMPERSON +
						VALORIMPRESION + Constantes.SIGNOIGUAL + Boolean.TrueString;;
		
					imgChimbote.Visible = true;
					imgChimbote.Attributes.Clear();
					this.lblChimbote.Visible = true;
					this.lblChimbote.Text = TITULOCHIMBOTE;
				}
				else
				{
					imgChimbote.ImageUrl = null;
					imgChimbote.Visible = false;
					imgChimbote.Attributes.Clear();
					this.lblChimbote.Visible = true;
					this.lblChimbote.Text = TITULOCHIMBOTEVACIO;
				}

				if(Coordenadas[Constantes.POSICIONCONTADOR+4] != null && Coordenadas[Constantes.POSICIONCONTADOR+5] != null)
				{
					imgIquitos.ImageUrl = URLGENERADORGRAFICOS + 
						VALORESX + Constantes.SIGNOIGUAL + Coordenadas[Constantes.POSICIONCONTADOR+4].ToString() + Constantes.SIGNOAMPERSON +
						VALORESY + Constantes.SIGNOIGUAL + Coordenadas[Constantes.POSICIONCONTADOR+5].ToString() + Constantes.SIGNOAMPERSON +
						VALORTIPOGRAFICO + Constantes.SIGNOIGUAL + TIPOGRAFICOBARRA + Constantes.SIGNOAMPERSON +
						KEYANCHO + Constantes.SIGNOIGUAL + ancho.ToString() + Constantes.SIGNOAMPERSON +
						KEYALTO + Constantes.SIGNOIGUAL + alto.ToString() + Constantes.SIGNOAMPERSON +
						KEYCANTIDADGLOSAS + Constantes.SIGNOIGUAL + cantidadglosas.ToString() + Constantes.SIGNOAMPERSON +
						VALORIMPRESION + Constantes.SIGNOIGUAL + Boolean.TrueString;;
			
					imgIquitos.Visible = true;
					imgIquitos.Attributes.Clear();
					this.lblIquitos.Visible = true;
					this.lblIquitos.Text = TITULOIQUITOS;
				}
				else
				{
					imgIquitos.ImageUrl = null;
					imgIquitos.Visible = false;
					imgIquitos.Attributes.Clear();
					this.lblIquitos.Visible = true;
					this.lblIquitos.Text = TITULOIQUITOSVACIO;
				}
			}
			else if(Page.Request.QueryString[KEYTIPOVISTA].ToString() == VistaAgrupada)
			{
				if(Coordenadas[Constantes.POSICIONCONTADOR] != null && Coordenadas[Constantes.POSICIONCONTADOR+1] != null)
				{
					if(Coordenadas[Constantes.POSICIONCONTADOR].ToString().Split(Constantes.SIGNOLINEAVERTICAL.ToCharArray()).Length > flgGraficoGrande)
					{
						imgCallao.ImageUrl = URLGENERADORGRAFICOS + 
							VALORESX + Constantes.SIGNOIGUAL + Coordenadas[Constantes.POSICIONCONTADOR].ToString() + Constantes.SIGNOAMPERSON +
							VALORESY + Constantes.SIGNOIGUAL + Coordenadas[Constantes.POSICIONCONTADOR+1].ToString() + Constantes.SIGNOAMPERSON +
							VALORTIPOGRAFICO + Constantes.SIGNOIGUAL + TIPOGRAFICOBARRA + Constantes.SIGNOAMPERSON +
							KEYANCHO + Constantes.SIGNOIGUAL + ancho.ToString() + Constantes.SIGNOAMPERSON +
							KEYGRAFICOGRANDE + Constantes.SIGNOIGUAL + flgGraficoGrande.ToString() + Constantes.SIGNOAMPERSON +
							VALORIMPRESION + Constantes.SIGNOIGUAL + Boolean.TrueString;
					}
					else
					{
						imgCallao.ImageUrl = URLGENERADORGRAFICOS + 
							VALORESX + Constantes.SIGNOIGUAL + Coordenadas[Constantes.POSICIONCONTADOR].ToString() + Constantes.SIGNOAMPERSON +
							VALORESY + Constantes.SIGNOIGUAL + Coordenadas[Constantes.POSICIONCONTADOR+1].ToString() + Constantes.SIGNOAMPERSON +
							VALORTIPOGRAFICO + Constantes.SIGNOIGUAL + TIPOGRAFICOBARRA + Constantes.SIGNOAMPERSON +
							KEYANCHO + Constantes.SIGNOIGUAL + ancho.ToString() + Constantes.SIGNOAMPERSON +
							VALORIMPRESION + Constantes.SIGNOIGUAL + Boolean.TrueString;
					}
			
					imgCallao.Visible = true;
					imgCallao.Attributes.Clear();
					this.lblCallao.Text = TITULOPERU;
					this.VisualizacionTipoAcumulado();
				}
				else
				{
					imgCallao.ImageUrl = null;
					imgCallao.Visible = false;
					imgCallao.Attributes.Clear();
					this.lblCallao.Text = TITULOPERUVACIO;
					this.VisualizacionTipoAcumulado();
				}
			}
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add GraficoVentasRealesCorporativas.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add GraficoVentasRealesCorporativas.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			
		}

		public void LlenarDatos()
		{
			lblTitulo.Text = CImpresion.ObtenerTituloReporte();
		}

		public void LlenarJScript()
		{
			// TODO:  Add GraficoVentasRealesCorporativas.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add GraficoVentasRealesCorporativas.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			ltlMensaje.Text = Helper.Imprimir();
		}

		public void Exportar()
		{
			// TODO:  Add GraficoVentasRealesCorporativas.Exportar implementation
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
			// TODO:  Add GraficoVentasRealesCorporativas.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void VisualizacionTipoAcumulado()
		{
			this.lblChimbote.Visible = false;
			this.lblIquitos.Visible = false;
			this.imgChimbote.ImageUrl = null;
			this.imgIquitos.ImageUrl = null;
			this.imgChimbote.Visible = false;
			this.imgIquitos.Visible = false;
		}
	}
}