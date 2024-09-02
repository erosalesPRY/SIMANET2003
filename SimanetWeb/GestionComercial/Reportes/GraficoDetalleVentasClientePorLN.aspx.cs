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


namespace SIMA.SimaNetWeb.GestionComercial.Reportes
{
	/// <summary>
	/// Summary description for GraficoDetalleVentasCientePorLN.
	/// </summary>
	public class GraficoDetalleVentasClientePorLN : System.Web.UI.Page, IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion

		#region constantes
		const string URLGENERADORGRAFICOS = "ChartGenerator.aspx?";
		const string URLIMPRESION = "PopupImpresionDetalleVentasClientePorLN.aspx";

		//Otros
		const string VALORESX = "xValues";
		const string VALORESY = "yValues";
		const string VALORTIPOGRAFICO = "ChartType";
		const string TIPOGRAFICOBARRA = "bar";
		const int Cantidad = 2;
		

		//Key Session y QueryString
		const string KEYQID = "IdCliente";
		const string FECHAINICIAL = "FechaInicial";
		const string FECHAFINAL = "FechaFinal";
		protected System.Web.UI.WebControls.Image Image1;
		protected System.Web.UI.WebControls.Image ChartImage;
		protected System.Web.UI.WebControls.Image Image2;
		const string TituloConstante = "DETALLE VENTAS CLIENTES POR LINEA DE NEGOCIO";
		#endregion
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			this.ConfigurarAccesoControles();

			Helper.ReiniciarSession();

			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se consulto el grafico Comparativo de Ventas Reales por Periodos",Enumerados.NivelesErrorLog.I.ToString()));

			this.LlenarDatos();
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
			// TODO:  Add GraficoDetalleVentasClientePorLN.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add GraficoDetalleVentasClientePorLN.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add GraficoDetalleVentasClientePorLN.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add GraficoDetalleVentasClientePorLN.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			this.lblTitulo.Text = TituloConstante;
			CGraficoBarra oCGraficoBarra = new CGraficoBarra();

			CImpresion oCImpresion = new CImpresion();
			StringBuilder [] CoordenadasImpresion = new StringBuilder[Cantidad];

			StringBuilder [] Coordenadas = oCGraficoBarra.ConsultarDetalleMontoClientePorLineaNegocio(Convert.ToInt32(Page.Request.QueryString[KEYQID]), Convert.ToDateTime(Page.Request.QueryString[FECHAINICIAL]),Convert.ToDateTime(Page.Request.QueryString[FECHAFINAL]));

			if(Coordenadas != null)
			{
				ChartImage.ImageUrl = URLGENERADORGRAFICOS + 
					VALORESX + Constantes.SIGNOIGUAL + Coordenadas[Constantes.POSICIONCONTADOR].ToString() + Constantes.SIGNOAMPERSON +
					VALORESY + Constantes.SIGNOIGUAL + Coordenadas[Constantes.POSICIONCONTADOR+1].ToString() + Constantes.SIGNOAMPERSON +
					VALORTIPOGRAFICO + Constantes.SIGNOIGUAL + TIPOGRAFICOBARRA;
			
				ChartImage.Visible = true;
				ChartImage.Attributes.Clear();

				CoordenadasImpresion[Constantes.POSICIONCONTADOR] = Coordenadas[Constantes.POSICIONCONTADOR];
				CoordenadasImpresion[Constantes.POSICIONCONTADOR+1] = Coordenadas[Constantes.POSICIONCONTADOR+1];

				oCImpresion.GuardarCoordenadasImprimir(CoordenadasImpresion,this.lblTitulo.Text);
			}
		}

		public void LlenarJScript()
		{
			// TODO:  Add GraficoDetalleVentasClientePorLN.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add GraficoDetalleVentasClientePorLN.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			ltlMensaje.Text = Helper.PopupImpresion(URLIMPRESION,750,500,false,false,false,true,true);
		}

		public void Exportar()
		{
			// TODO:  Add GraficoDetalleVentasClientePorLN.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add GraficoDetalleVentasClientePorLN.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add GraficoDetalleVentasClientePorLN.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void ibtnImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Imprimir();
		}
	}
}
