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
	/// Summary description for GraficoVentasPresupuestadasporCO.
	/// </summary>
	public class GraficoVentasPresupuestadasporCO : System.Web.UI.Page, IPaginaBase
	{

		#region Controles
		protected System.Web.UI.WebControls.Label lblAno;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
		protected System.Web.UI.WebControls.Image ChartImage;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion

		#region Constantes

		//Paginas
		const string URLGENERADORGRAFICOS = "ChartGenerator.aspx?";
		const string URLIMPRESION = "PopupImpresionGraficoVentasPresupuestadasporCO.aspx";

		//Otros
		const string TituloConstanteVentaPresupuestada = "VENTAS PRESUPUESTADAS POR CENTRO DE OPERACION";
		const string TituloConstanteVentaEjecutada = "VENTAS EJECUTADAS POR CENTRO DE OPERACION";
		const string RutaVentaPresupuestada = "Grafico de Ventas Presupuestadas Por Centro de Operacion";
		const string RutaVentaEjecutada = "Grafico de Ventas Ejecutadas Por Centro de Operacion";
		const string TituloVacioVentaPresupuestada = "No existen Ventas Presupuestadas";
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
		const string KEYQANO = "Ano";
		#endregion

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
			this.ibtnImprimir.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnImprimir_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
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

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add GraficoVentasPresupuestadasporCO.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add GraficoVentasPresupuestadasporCO.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add GraficoVentasPresupuestadasporCO.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add GraficoVentasPresupuestadasporCO.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			
			CGraficoTorta oCGraficoTorta = new CGraficoTorta();
			StringBuilder [] Coordenadas = new StringBuilder[Cantidad];
			this.lblAno.Text = Page.Request.QueryString[KEYQANO];

			if( Convert.ToInt32(Page.Request.QueryString[KEYQANO]) >= DateTime.Today.Year)
			{
				this.lblTitulo.Text = TituloConstanteVentaPresupuestada;
				this.lblPagina.Text = RutaVentaPresupuestada;
				this.lblAno.Text = lblAno.Text + Utilitario.Constantes.ESPACIO + Utilitario.Constantes.LINEA + Utilitario.Constantes.ESPACIO + Version + Utilitario.Constantes.ESPACIO + Page.Request.QueryString[KEYQIDVERSION] ;
				Coordenadas = oCGraficoTorta.ConsultarPorcentajeVentasPresupuestadasPorCO(Convert.ToInt32(Page.Request.QueryString[KEYQIDVERSION]),Convert.ToInt32(Page.Request.QueryString[KEYQANO]));
			}
			else
			{
				this.lblTitulo.Text = TituloConstanteVentaEjecutada;
				this.lblPagina.Text = RutaVentaEjecutada;
				Coordenadas = oCGraficoTorta.ConsultarPorcentajeVentasEjecutadasPorCO(Convert.ToInt32(Page.Request.QueryString[KEYQANO]));
			}

			if(Coordenadas != null)
			{
				ChartImage.ImageUrl = URLGENERADORGRAFICOS + 
					VALORESX + Constantes.SIGNOIGUAL + Coordenadas[Constantes.POSICIONCONTADOR].ToString() + Constantes.SIGNOAMPERSON +
					VALORESY + Constantes.SIGNOIGUAL + Coordenadas[Constantes.POSICIONCONTADOR+1].ToString()+ Constantes.SIGNOAMPERSON +
					KEYANCHO + Constantes.SIGNOIGUAL + ancho.ToString();
			
				ChartImage.Visible = true;
				ChartImage.Attributes.Clear();

				CImpresion oCImpresion = new CImpresion();
				oCImpresion.GuardarCoordenadasImprimir(Coordenadas,this.lblTitulo.Text,this.lblAno.Text);
			}
			else
			{
				ChartImage.ImageUrl = null;
				ChartImage.Visible = false;
				ChartImage.Attributes.Clear();
				this.lblResultado.Visible = true;
				this.ibtnImprimir.Visible = false;

				if( Convert.ToInt32(Page.Request.QueryString[KEYQANO]) >= DateTime.Today.Year)
				{
					this.lblResultado.Text = TituloVacioVentaPresupuestada;
				}
				else
				{
					this.lblResultado.Text = TituloVacioVentaEjecutada;
				}
			}

		}

		public void LlenarJScript()
		{
			// TODO:  Add GraficoVentasPresupuestadasporCO.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add GraficoVentasPresupuestadasporCO.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			ltlMensaje.Text = Helper.PopupImpresion(URLIMPRESION,780,500,false,false,false,true,true);
		}

		public void Exportar()
		{
			// TODO:  Add GraficoVentasPresupuestadasporCO.Exportar implementation
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
			// TODO:  Add GraficoVentasPresupuestadasporCO.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void ibtnImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Imprimir();
		}
	}
}
