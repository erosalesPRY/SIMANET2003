using System;
using System.Text;
using System.Web.UI.WebControls;
using SIMA.Utilitario;
using SIMA.EntidadesNegocio.GestionComercial;
using SIMA.Controladoras.GestionComercial;
using SIMA.SimaNetWeb.InterfacesIU;
using NetAccessControl;
using SIMA.Controladoras.General;
using SIMA.Log;

namespace SIMA.SimaNetWeb.GestionComercial.Reportes
{
	/// <summary>
	/// Summary description for GraficoVentasPresupuestadasporCOSinCompararConVentas.
	/// </summary>
	public class GraficoVentasPresupuestadasporCOSinCompararConVentas : System.Web.UI.Page, IPaginaBase
	{
		#region controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblResultado;
		#endregion
		string Titulo="";
		string Año="";
		#region Constantes

		//Paginas
		const string URLGENERADORGRAFICOS = "ChartGenerator.aspx?";
		const string URLIMPRESION = "PopupImpresionGraficoVentasPresupuestadasporCOSinCompararVentas.aspx";

		//Otros
		const string TituloConstanteVentaPresupuestada = "VENTAS PRESUPUESTADAS POR CENTRO DE OPERACION";
		const string RutaVentaPresupuestada = "Grafico de Ventas Presupuestadas Por Centro de Operacion";
		const string TituloVacioVentaPresupuestada = "No existen Ventas Presupuestadas";

		const string TituloConstanteVentaEjecutadas = "VENTAS EJECUTADAS POR CENTRO DE OPERACION";
		const string RutaVentaEjecutada = "Grafico de Ventas Ejecutadas Por Centro de Operacion";
		const string TituloVacioVentaEjecutada = "No existen Ventas Ejecutadas";
		const string Version = "Version";
		const string VALORESX = "xValues";
		const string VALORESY = "yValues";
		const string VALORTIPOGRAFICO = "ChartType";
		const string TIPOGRAFICOBARRA = "bar";
		const string KEYANCHO = "ancho";
		const int Cantidad = 2;
		const int ancho = 720;


		//Key Session y QueryString
		const string KEYQIDVERSION = "IdVersion";
		protected System.Web.UI.HtmlControls.HtmlInputHidden RutaArchivo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden NombreArchivoConfig;
		protected System.Web.UI.HtmlControls.HtmlInputHidden NombreArchivoData;
		const string KEYQANO = "Ano";
		#endregion
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				this.ConfigurarAccesoControles();
				Helper.ReiniciarSession();
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se consulto el grafico de Ventas Presupuestadas por Centro Operativo",Enumerados.NivelesErrorLog.I.ToString()));
				this.LlenarDatos();
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
			// TODO:  Add GraficoVentasPresupuestadasporCOSinCompararConVentas.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add GraficoVentasPresupuestadasporCOSinCompararConVentas.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add GraficoVentasPresupuestadasporCOSinCompararConVentas.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add GraficoVentasPresupuestadasporCOSinCompararConVentas.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			CGraficoTorta oCGraficoTorta = new CGraficoTorta();
			StringBuilder [] Coordenadas = new StringBuilder[Cantidad];

			Titulo=TituloConstanteVentaPresupuestada;
			Año=Page.Request.QueryString[KEYQANO].ToString();

			if( Convert.ToInt32(Page.Request.QueryString[KEYQANO]) >= DateTime.Today.Year)
			{
				this.LlenarEtiquetasVentasPresupuestadas();
				Coordenadas = oCGraficoTorta.ConsultarPorcentajeVentasPresupuestadasPorCOSinCompararVentas(Convert.ToInt32(Page.Request.QueryString[KEYQIDVERSION]),Convert.ToInt32(Page.Request.QueryString[KEYQANO]));
			}
			else
			{
				this.LlenarEtiquetasVentasReales();
				Coordenadas = oCGraficoTorta.ConsultarPorcentajeVentasEjecutadasPorCO(Convert.ToInt32(Page.Request.QueryString[KEYQANO]));
			}

			if(Coordenadas != null)
			{
				Coordenadas = EstablecerColorCentroOperativo(Coordenadas);

				int Radio = ((Helper.ObtenerAltodePantalla()>600)?240:150);
				int TopLeg = (Helper.ObtenerAltodePantalla() -300);
				string []Parametros = new string[3];
				Parametros = Helper.Graph(Utilitario.Enumerados.TiposGraficoEstadistico.Pie,Utilitario.Enumerados.LibreriaGraph.Version2,Titulo + "<br>" + Año,12,Radio,0,TopLeg,"#FFFFFF","#696969",Coordenadas);
				RutaArchivo.Value=Parametros[0].ToString();
				NombreArchivoConfig.Value=Parametros[1].ToString();
				NombreArchivoData.Value=Parametros[2].ToString();
			}
			else
			{
				this.lblResultado.Visible = true;
				//this.ibtnImprimir.Visible = false;

				this.lblResultado.Text = TituloVacioVentaPresupuestada;
			}

		}
		public StringBuilder []EstablecerColorCentroOperativo(StringBuilder []Coordenadas)
		{
			string []sbTitulo = Coordenadas[0].ToString().Split('|');
			StringBuilder sbColor = new StringBuilder();
			for(int i=0;i<= sbTitulo.Length-1;i++)
			{
				switch(sbTitulo[i])
				{
					case "SIMAI":
						sbColor.Append(Helper.ObtenerColorCentroOperativo(sbTitulo[i].ToString()) + "|");
						break;
					case "SIMACH":
						sbColor.Append(Helper.ObtenerColorCentroOperativo(sbTitulo[i].ToString()) +"|");
						break;
					case "SIMAC":
						sbColor.Append(Helper.ObtenerColorCentroOperativo(sbTitulo[i].ToString()) +"|");
						break;
				}
			}
			Coordenadas = Helper.SBRedimensionar(Coordenadas,3);
			Coordenadas[2] = sbColor;
			return Coordenadas;
		}


		public void LlenarJScript()
		{
			// TODO:  Add GraficoVentasPresupuestadasporCOSinCompararConVentas.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add GraficoVentasPresupuestadasporCOSinCompararConVentas.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add GraficoVentasPresupuestadasporCOSinCompararConVentas.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add GraficoVentasPresupuestadasporCOSinCompararConVentas.Exportar implementation
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
			// TODO:  Add GraficoVentasPresupuestadasporCOSinCompararConVentas.ValidarFiltros implementation
			return false;
		}

		#endregion

		public void LlenarEtiquetasVentasPresupuestadas()
		{
			Titulo = TituloConstanteVentaPresupuestada;
			this.lblPagina.Text = RutaVentaPresupuestada;
			Año = Año + Utilitario.Constantes.ESPACIO + Utilitario.Constantes.LINEA + Utilitario.Constantes.ESPACIO + Version + Utilitario.Constantes.ESPACIO + Page.Request.QueryString[KEYQIDVERSION] ;
		}


		public void LlenarEtiquetasVentasReales()
		{
			Titulo = TituloConstanteVentaEjecutadas;
			this.lblPagina.Text = RutaVentaEjecutada;
		}

	}
}
