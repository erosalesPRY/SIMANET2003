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
	/// Summary description for GraficoVentasPresupuestadasContribucionLN.
	/// </summary>
	public class GraficoVentasPresupuestadasContribucionLN : System.Web.UI.Page, IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion

		#region Constantes

		//Paginas
		const string URLGENERADORGRAFICOS = "ChartGenerator.aspx?";
		const string URLIMPRESION = "PopupImpresionGraficoVentasPresupuestadasContribucionLN.aspx";

		//Otros
		const string TituloConstanteVentaPresupuestada = "VENTAS PRESUPUESTADAS CONTRIBUCION POR LINEA DE NEGOCIO";
		const string TituloConstanteVentaEjecutada = "VENTAS EJECUTADAS CONTRIBUCION POR LINEA DE NEGOCIO";
		const string RutaVentaPresupuestada = "Grafico de Ventas Presupuestadas Contribucion por Linea de Negocio";
		const string RutaVentaEjecutada = "Grafico de Ventas Ejecutadas Contribucion por Linea de Negocio";
		const string TituloVacioVentaPresupuestada = "No existen Ventas Presupuestadas";
		const string TituloVacioVentaEjecutada = "No existen Ventas Ejecutadas";
		const string Version = "Version";
		const int alto = 118;
		const int cantidadglosas = 4;
		const int Cantidad = 2;
		const string TipoSectorPrivado = "PRIV";
		const string TipoSectorMarina = "MGP";
		const string TipoAcumulado = "ACUMULADO";

		//Key Session y QueryString
		const string VALORESX = "xValues";
		const string VALORESY = "yValues";
		const string KEYQIDVERSION = "IdVersion";
		const string KEYQIDTIPO = "IdTipo";
		const string KEYQANO = "Ano";
		const string VALORTIPOGRAFICO = "ChartType";
		const string TIPOGRAFICOBARRA = "bar";
		const string KEYALTO = "alto";
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.DropDownList ddlbTipo;
		protected System.Web.UI.WebControls.Label lblTipo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden RutaArchivo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden NombreArchivoConfig;
		protected System.Web.UI.HtmlControls.HtmlInputHidden NombreArchivoData;
		const string KEYCANTIDADGLOSAS = "cantidadglosas";

		#endregion
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				this.ConfigurarAccesoControles();
				Helper.ReiniciarSession();
				this.LlenarCombos();
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se consulto el grafico de Ventas Presupuestadas Contribucion por Linea de Negocio",Enumerados.NivelesErrorLog.I.ToString()));
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
			this.ibtnImprimir.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnImprimir_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add GraficoVentasPresupuestadasContribucionLN.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add GraficoVentasPresupuestadasContribucionLN.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add GraficoVentasPresupuestadasContribucionLN.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			this.ddlbTipo.Items.Insert(Utilitario.Constantes.POSICIONINDEXCERO,TipoAcumulado);
			this.ddlbTipo.Items.Insert(Utilitario.Constantes.POSICIONINDEXUNO,TipoSectorPrivado);
			this.ddlbTipo.Items.Insert(Utilitario.Constantes.POSICIONINDEXDOS,TipoSectorMarina);
		}

		public void LlenarDatos()
		{
			string Titulo=TituloConstanteVentaPresupuestada;
			string Año=Page.Request.QueryString[KEYQANO].ToString();


			CGraficoTorta oCGraficoTorta = new CGraficoTorta();
			//StringBuilder [] Coordenadas = new StringBuilder[3];
			StringBuilder [] Coordenadas;
			//this.lblAno.Text = Page.Request.QueryString[KEYQANO];

			if( Convert.ToInt32(Page.Request.QueryString[KEYQANO]) >= DateTime.Today.Year)
			{
				this.lblPagina.Text = RutaVentaPresupuestada;
				//this.lblTitulo.Text = TituloConstanteVentaPresupuestada;
				Año= Año + Utilitario.Constantes.ESPACIO + Utilitario.Constantes.LINEA + Utilitario.Constantes.ESPACIO + Version  + Utilitario.Constantes.ESPACIO +  Page.Request.QueryString[KEYQIDVERSION] ;
				
				if(this.ddlbTipo.SelectedItem.Text == TipoAcumulado)
				{
					Coordenadas = oCGraficoTorta.ConsultarPorcentajeVentasPresupuestadasContribucionLN(Convert.ToInt32(Page.Request.QueryString[KEYQIDVERSION]),Convert.ToInt32(Page.Request.QueryString[KEYQANO]),Utilitario.Constantes.POSICIONINDEXCERO);
				}
				else if(this.ddlbTipo.SelectedItem.Text == TipoSectorPrivado)
				{
					Coordenadas = oCGraficoTorta.ConsultarPorcentajeVentasPresupuestadasContribucionLN(Convert.ToInt32(Page.Request.QueryString[KEYQIDVERSION]),Convert.ToInt32(Page.Request.QueryString[KEYQANO]),Utilitario.Constantes.POSICIONINDEXUNO);
				}
				else
				{
					Coordenadas = oCGraficoTorta.ConsultarPorcentajeVentasPresupuestadasContribucionLN(Convert.ToInt32(Page.Request.QueryString[KEYQIDVERSION]),Convert.ToInt32(Page.Request.QueryString[KEYQANO]),Utilitario.Constantes.POSICIONINDEXDOS);
				}
			}
			else
			{
				this.lblPagina.Text = RutaVentaEjecutada;
				Titulo = TituloConstanteVentaEjecutada;

				if(this.ddlbTipo.SelectedItem.Text == TipoAcumulado)
				{
					Coordenadas = oCGraficoTorta.ConsultarPorcentajeVentasEjecutadasContribucionLN(Convert.ToInt32(Page.Request.QueryString[KEYQANO]),Utilitario.Constantes.POSICIONINDEXCERO);
				}
				else if(this.ddlbTipo.SelectedItem.Text == TipoSectorPrivado)
				{
					Coordenadas = oCGraficoTorta.ConsultarPorcentajeVentasEjecutadasContribucionLN(Convert.ToInt32(Page.Request.QueryString[KEYQANO]),Utilitario.Constantes.POSICIONINDEXUNO);
				}
				else
				{
					Coordenadas = oCGraficoTorta.ConsultarPorcentajeVentasEjecutadasContribucionLN(Convert.ToInt32(Page.Request.QueryString[KEYQANO]),Utilitario.Constantes.POSICIONINDEXDOS);
				}

			}
			Coordenadas = Helper.EstablecerColorLineaNegocio(Coordenadas);

			if(Coordenadas != null)
			{
				int Radio = ((Helper.ObtenerAltodePantalla()>600)?240:150);
				int TopLeg = (Helper.ObtenerAltodePantalla() -300);
				string []Parametros = new string[3];
				Parametros = Helper.Graph(Utilitario.Enumerados.TiposGraficoEstadistico.Pie,Utilitario.Enumerados.LibreriaGraph.Version2,Titulo + "<br>" + Año,12,Radio,0,TopLeg,"#FFFFFF","#696969",Coordenadas);
				RutaArchivo.Value=Parametros[0].ToString();
				NombreArchivoConfig.Value=Parametros[1].ToString();
				NombreArchivoData.Value=Parametros[2].ToString();

				CImpresion oCImpresion = new CImpresion();
				oCImpresion.GuardarCoordenadasImprimir(Coordenadas,TituloConstanteVentaPresupuestada,Año);
			}
			else
			{
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
			// TODO:  Add GraficoVentasPresupuestadasContribucionLN.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add GraficoVentasPresupuestadasContribucionLN.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			ltlMensaje.Text = Helper.PopupImpresion(URLIMPRESION,780,500,false,false,false,true,true);
		}

		public void Exportar()
		{
			// TODO:  Add GraficoVentasPresupuestadasContribucionLN.Exportar implementation
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
			// TODO:  Add GraficoVentasPresupuestadasContribucionLN.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void ibtnImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Imprimir();
		}

		private void ddlbTipo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se consulto el grafico comparativo por linea de negocio de forma" + this.ddlbTipo.SelectedItem.Text,Enumerados.NivelesErrorLog.I.ToString()));

			this.LlenarDatos();
		}
	}
}
