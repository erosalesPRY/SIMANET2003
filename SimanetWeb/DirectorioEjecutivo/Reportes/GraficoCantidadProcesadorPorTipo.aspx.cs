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

namespace SIMA.SimaNetWeb.DirectorioEjecutivo.Reportes
{
	/// <summary>
	/// Summary description for GraficoCantidadProcesadorPorTipo.
	/// </summary>
	public class GraficoCantidadProcesadorPorTipo : System.Web.UI.Page, IPaginaBase
	{
		#region Constantes

		//Paginas
		const string URLGENERADORGRAFICOS = "../../GestionComercial/Reportes/ChartGenerator.aspx?";
		const string URLIMPRESION = "PopupImpresionGraficoVentasPresupuestadasporCOSinCompararVentas.aspx";

		//Otros
		const string TituloConstanteInventario = "CANTIDAD DE COMPUTADORAS POR TIPO DE PROCESADOR";
		const string TituloVacioInventario = "No existen Valores";
		const string RutaInventario = "Grafico de Cantidad de Computadoras por Tipo de Procesadores";
		const string Version = "Version";
		const string VALORESX = "xValues";
		const string VALORESY = "yValues";
		const string VALORTIPOGRAFICO = "ChartType";
		const string TIPOGRAFICOBARRA = "bar";
		const string KEYANCHO = "ancho";
		const int Cantidad = 2;
		const int ancho = 800;


		//Key Session y QueryString
		const string KEYQIDVERSION = "IdVersion";
		const string KEYQANO = "Ano";
		#endregion

		#region Controles

		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
		protected System.Web.UI.WebControls.Image ChartImage;
		protected System.Web.UI.WebControls.Label lblResultado;
	
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
			this.ibtnImprimir.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnImprimir_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add GraficoCantidadProcesadorPorTipo.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add GraficoCantidadProcesadorPorTipo.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add GraficoCantidadProcesadorPorTipo.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add GraficoCantidadProcesadorPorTipo.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			try
			{
				CGraficoTorta oCGraficoTorta = new CGraficoTorta();
				StringBuilder [] Coordenadas = new StringBuilder[Cantidad];
						
				this.LlenarEtiquetasInventario();
				Coordenadas = oCGraficoTorta.ConsultarPorcentajeProcesadorPorTipos();
			
				if(Coordenadas != null)
				{
					ChartImage.ImageUrl = URLGENERADORGRAFICOS + 
						VALORESX + Constantes.SIGNOIGUAL + Coordenadas[Constantes.POSICIONCONTADOR].ToString() + Constantes.SIGNOAMPERSON +
						VALORESY + Constantes.SIGNOIGUAL + Coordenadas[Constantes.POSICIONCONTADOR+1].ToString()+ Constantes.SIGNOAMPERSON +
						KEYANCHO + Constantes.SIGNOIGUAL + ancho.ToString();
			
					ChartImage.Visible = true;
					ChartImage.Attributes.Clear();

					CImpresion oCImpresion = new CImpresion();
					oCImpresion.GuardarCoordenadasImprimir(Coordenadas,this.lblTitulo.Text);
				}
				else
				{
					ChartImage.ImageUrl = null;
					ChartImage.Visible = false;
					ChartImage.Attributes.Clear();
					this.lblResultado.Visible = true;
					this.ibtnImprimir.Visible = false;

					this.lblResultado.Text = TituloVacioInventario;
				}					
			}
			catch(Exception ex)
			{
				string a = ex.Message;
			}
		}

		public void LlenarJScript()
		{
			// TODO:  Add GraficoCantidadProcesadorPorTipo.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add GraficoCantidadProcesadorPorTipo.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// ltlMensaje.Text = Helper.PopupImpresion(URLIMPRESION,780,500,false,false,false,true,true);
		}

		public void Exportar()
		{
			// TODO:  Add GraficoCantidadProcesadorPorTipo.Exportar implementation
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
			// TODO:  Add GraficoCantidadProcesadorPorTipo.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void ibtnImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Imprimir();
		}

		public void LlenarEtiquetasInventario()
		{
			this.lblTitulo.Text = TituloConstanteInventario;
			this.lblPagina.Text = RutaInventario;
		}
	}
}
