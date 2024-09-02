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
	public class GraficoVentasRealesCorporativas : System.Web.UI.Page, IPaginaBase
	{
		#region Controles

		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTipo;
		protected System.Web.UI.WebControls.DropDownList ddlbTipo;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Literal ltlMensaje;

		#endregion
		
		#region Constantes

		//Paginas
		const string URLPRINCIPAL = "../Ventas/ConsultarMontoVentasReales.aspx";
		const string URLGENERADORGRAFICOS = "ChartGenerator.aspx?";
		const string URLIMPRESION = "PopupImpresionGraficoVentasRealesCorporativas.aspx";

		//Otros
		const string TipoMensual = "Mensual";
		const string TipoAcumulado = "Acumulado";
		const string TituloConstante = "VENTAS COLOCADAS CORPORATIVA CORRESPONDIENTE";
		const string TituloMensual = "AL MES DE";
		const string TituloAcumulado = "A LOS MESES DE ";
		const string VALORESX = "xValues";
		const string VALORESY = "yValues";
		const int Cantidad = 2;
		protected System.Web.UI.HtmlControls.HtmlInputHidden NombreArchivoConfig;
		protected System.Web.UI.HtmlControls.HtmlInputHidden RutaArchivo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden NombreArchivoData;
		const string GRILLAVACIA ="No existe ninguna Venta Ejecutada.";

		#endregion
		public string Titulo="";
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				this.ConfigurarAccesoControles();

				Helper.ReiniciarSession();

				this.LlenarJScript();

				this.LlenarCombos();

				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se consulto el grafico de Ventas Reales Corporativa de forma" + this.ddlbTipo.SelectedItem.Text,Enumerados.NivelesErrorLog.I.ToString()));

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
			this.ddlbTipo.SelectedIndexChanged += new System.EventHandler(this.ddlbTipo_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void ibtnAtras_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Page.Response.Redirect(URLPRINCIPAL);
		}

		private void ibtnImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			ltlMensaje.Text = Helper.PopupImpresion(URLIMPRESION,750,500,false,false,false,true,true);
		}

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add GraficoVentasRealesCorporativas.LlenarGrilla implementation
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
			this.ddlbTipo.Items.Insert(Constantes.POSICIONCONTADOR,TipoMensual);
			this.ddlbTipo.Items.Insert(Constantes.POSICIONCONTADOR+1,TipoAcumulado);
		}

		public void LlenarDatos()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			DataView dw = oCTablaTablas.ListaSegunCriterioFiltro(Convert.ToInt32(Enumerados.TablasTabla.Mes),Enumerados.ColumnasTablaTablas.Codigo + Constantes.SIGNOIGUAL + (Helper.FechaSimanet.ObtenerFechaSesion().Month).ToString());
			
			if(this.ddlbTipo.SelectedItem.Text == TipoMensual)
			{
				Titulo = TituloConstante + Constantes.ESPACIO + TituloMensual +"<br>"+ Constantes.ESPACIO + dw[Convert.ToInt32(Constantes.POSICIONCONTADOR)][Enumerados.ColumnasTablaTablas.Descripcion.ToString()].ToString().ToUpper();
			}
			else
			{
				Titulo = TituloConstante + Constantes.ESPACIO + TituloAcumulado +"<br>ENERO -"+ Constantes.ESPACIO + dw[Convert.ToInt32(Constantes.POSICIONCONTADOR)][Enumerados.ColumnasTablaTablas.Descripcion.ToString()].ToString().ToUpper();
			}

			CGraficoTorta oCGraficoTorta = new CGraficoTorta();
			StringBuilder [] Coordenadas;

			
			if(this.ddlbTipo.SelectedItem.Text == TipoMensual)
			{
				Coordenadas = oCGraficoTorta.ConsultarPorcentajeVentasRealesCorporativoMensual(Helper.FechaSimanet.ObtenerFechaSesion());
			}
			else
			{
				Coordenadas = oCGraficoTorta.ConsultarPorcentajeVentasRealesCorporativoAcumulado(Helper.FechaSimanet.ObtenerFechaSesion());
			}

			if(Coordenadas != null)
			{
				this.GraficarPie(Coordenadas);
			}
			else
			{
				this.lblResultado.Visible = true;
				this.lblResultado.Text = GRILLAVACIA;
			}
		}
		private void GraficarPie(StringBuilder [] Coordenadas)
		{
			Coordenadas = Helper.EstablecerColorCentroOperativo(Coordenadas);
			int Radio = ((Helper.ObtenerAltodePantalla()>600)?240:150);
			int TopLeg = (Helper.ObtenerAltodePantalla() -300);
			string []Parametros = new string[3];
			Parametros = Helper.Graph(Utilitario.Enumerados.TiposGraficoEstadistico.Pie,Utilitario.Enumerados.LibreriaGraph.Version2,Titulo,12,Radio,0,TopLeg,"#FFFFFF","#696969",Coordenadas);
			RutaArchivo.Value=Parametros[0].ToString();
			NombreArchivoConfig.Value=Parametros[1].ToString();
			NombreArchivoData.Value=Parametros[2].ToString();

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
			// TODO:  Add GraficoVentasRealesCorporativas.Imprimir implementation
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

		private void ddlbTipo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se consulto el grafico de Ventas Reales Corporativa de forma" + this.ddlbTipo.SelectedItem.Text,Enumerados.NivelesErrorLog.I.ToString()));

			this.LlenarDatos();
		}
	}
}