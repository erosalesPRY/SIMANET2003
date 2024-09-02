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
	/// Summary description for GraficoHistoricoVentasEjecutadasPorCOyLN.
	/// </summary>
	public class GraficoHistoricoVentasEjecutadasPorCOyLN : System.Web.UI.Page , IPaginaBase
	{
		#region controles
		protected System.Web.UI.WebControls.Label lblTitulo1;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
		protected System.Web.UI.WebControls.Image ChartImage;
		#endregion

		#region Constantes
		//Paginas
		const string URLGENERADORGRAFICOS = "ChartGenerator.aspx?";
		//Otros
		//const string TipoSectorPrivado = "PRIV";
		//const string TipoSectorMarina = "MGP";
		//const string TipoAcumulado = "ACUMULADO";
		const string VALORESX = "xValues";
		const string VALORESY = "yValues";
		const string VALORTIPOGRAFICO = "ChartType";
		const string TIPOGRAFICOBARRA = "bar";
		const string FORMATODECIMAL5 = "FormatoDecimal5";
		const string FLGFORMATO = "1";
		const int Cantidad = 2;
		
		//Titulo
		const string TituloConstante = "GRAFICO HISTORICO DE VENTAS EJECUTADAS DE SIMA-PERU";
		protected System.Web.UI.WebControls.Image Image2;
		protected System.Web.UI.WebControls.Image Image1;
		const string TituloConstante1 = "(MILES DE SOLES)";
		#endregion
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				this.ConfigurarAccesoControles();
				Helper.ReiniciarSession();
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se consulto el grafico historico de Ventas Reales por centro de operacion y linea de negocio",Enumerados.NivelesErrorLog.I.ToString()));
				this.LlenarCombos();
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
			// TODO:  Add GraficoHistoricoVentasEjecutadasPorCOyLN.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add GraficoHistoricoVentasEjecutadasPorCOyLN.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add GraficoHistoricoVentasEjecutadasPorCOyLN.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			//this.ddlbTipo.Items.Insert(Utilitario.Constantes.POSICIONINDEXCERO,TipoAcumulado);
			//this.ddlbTipo.Items.Insert(Utilitario.Constantes.POSICIONINDEXUNO,TipoSectorPrivado);
			//this.ddlbTipo.Items.Insert(Utilitario.Constantes.POSICIONINDEXDOS,TipoSectorMarina);
		}

		public void LlenarDatos()
		{
			this.lblTitulo.Text = TituloConstante;
			this.lblTitulo1.Text = TituloConstante1;
			
			CGraficoBarra oCGraficoBarra = new CGraficoBarra();

			CImpresion oCImpresion = new CImpresion();
			StringBuilder [] CoordenadasImpresion = new StringBuilder[Cantidad];
			StringBuilder [] Coordenadas;

			Coordenadas = oCGraficoBarra.ConsultarHistoricoVentasEjecutadasPorCoyLineaNegocio(Helper.FechaSimanet.ObtenerFechaSesion().Year );

//			if(this.ddlbTipo.SelectedItem.Text == TipoAcumulado)
//			{
//				Coordenadas = oCGraficoBarra.ConsultarHistoricoVentasEjecutadasPorCoyLineaNegocio(Utilitario.Constantes.POSICIONINDEXCERO);
//			}
//			else if(this.ddlbTipo.SelectedItem.Text == TipoSectorPrivado)
//			{
//				Coordenadas = oCGraficoBarra.ConsultarHistoricoVentasEjecutadasPorCoyLineaNegocio(Utilitario.Constantes.POSICIONINDEXUNO);
//			}
//			else
//			{
//				Coordenadas = oCGraficoBarra.ConsultarHistoricoVentasEjecutadasPorCoyLineaNegocio(Utilitario.Constantes.POSICIONINDEXDOS);
//			}
			

			if(Coordenadas != null)
			{
				ChartImage.ImageUrl = URLGENERADORGRAFICOS + 
					VALORESX + Constantes.SIGNOIGUAL + Coordenadas[Constantes.POSICIONCONTADOR].ToString() + Constantes.SIGNOAMPERSON +
					VALORESY + Constantes.SIGNOIGUAL + Coordenadas[Constantes.POSICIONCONTADOR+1].ToString() + Constantes.SIGNOAMPERSON +
					VALORTIPOGRAFICO + Constantes.SIGNOIGUAL + TIPOGRAFICOBARRA + Constantes.SIGNOAMPERSON +
					FORMATODECIMAL5 + Constantes.SIGNOIGUAL + FLGFORMATO;
			
				ChartImage.Visible = true;
				ChartImage.Attributes.Clear();

				CoordenadasImpresion[Constantes.POSICIONCONTADOR] = Coordenadas[Constantes.POSICIONCONTADOR];
				CoordenadasImpresion[Constantes.POSICIONCONTADOR+1] = Coordenadas[Constantes.POSICIONCONTADOR+1];

				oCImpresion.GuardarCoordenadasImprimir(CoordenadasImpresion,this.lblTitulo.Text);
			}
			else
			{
				this.ibtnImprimir.Visible = false;
			}
		}

		public void LlenarJScript()
		{
			// TODO:  Add GraficoHistoricoVentasEjecutadasPorCOyLN.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add GraficoHistoricoVentasEjecutadasPorCOyLN.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add GraficoHistoricoVentasEjecutadasPorCOyLN.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add GraficoHistoricoVentasEjecutadasPorCOyLN.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add GraficoHistoricoVentasEjecutadasPorCOyLN.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add GraficoHistoricoVentasEjecutadasPorCOyLN.ValidarFiltros implementation
			return false;
		}

		#endregion
	}
}
