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
	/// Summary description for GraficoCantidadLicenciatura.
	/// </summary>
	public class GraficoCantidadLicenciatura : System.Web.UI.Page, IPaginaBase
	{
		#region Constantes

		//Paginas
		const string URLGENERADORGRAFICOS = "../../GestionComercial/Reportes/ChartGenerator.aspx?";
		const string URLIMPRESION = "PopupImpresionGraficoVentasPresupuestadasporCOSinCompararVentas.aspx";

		//Otros
		const string TituloConstanteInventario = "CANTIDAD DE LICENCIATURA POR TIPO";
		const string TituloVacioInventario = "No existen Valores";
		const string RutaInventario = "Grafico de Cantidad de Licenciatura por Tipo";
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add GraficoCantidadLicenciatura.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add GraficoCantidadLicenciatura.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add GraficoCantidadLicenciatura.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add GraficoCantidadLicenciatura.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			try
			{
				CGraficoTorta oCGraficoTorta = new CGraficoTorta();
				StringBuilder [] Coordenadas = new StringBuilder[Cantidad];
						
				this.LlenarEtiquetasInventario();
				Coordenadas = oCGraficoTorta.ConsultarPorcentajesLicenciatura();
			
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
			// TODO:  Add GraficoCantidadLicenciatura.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add GraficoCantidadLicenciatura.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add GraficoCantidadLicenciatura.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add GraficoCantidadLicenciatura.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add GraficoCantidadLicenciatura.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add GraficoCantidadLicenciatura.ValidarFiltros implementation
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
