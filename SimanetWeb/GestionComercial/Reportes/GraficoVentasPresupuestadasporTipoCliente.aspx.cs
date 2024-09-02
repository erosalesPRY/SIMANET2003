using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using SIMA.SimaNetWeb.InterfacesIU;
using System.Text;
using SIMA.Utilitario;
using SIMA.EntidadesNegocio.GestionComercial;
using SIMA.Controladoras.GestionComercial;
using NetAccessControl;
using SIMA.Controladoras.General;
using SIMA.Log;
using System.Data;
using MetaBuilders.WebControls;


namespace SIMA.SimaNetWeb.GestionComercial.Reportes
{
	/// <summary>
	/// Summary description for GraficoVentasPresupuestadasporTipoCliente.
	/// </summary>
	public class GraficoVentasPresupuestadasporTipoCliente : System.Web.UI.Page, IPaginaBase
	{
		#region Controles

		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label lblVentasPresupuestadasIquitos;
		protected System.Web.UI.WebControls.HyperLink hlkbIquitos;
		protected System.Web.UI.WebControls.Label lblVentasPresupuestadasChimbote;
		protected System.Web.UI.WebControls.HyperLink hlkbChimbote;
		protected System.Web.UI.WebControls.Label lblVentasPresupuestadasCallao;
		protected System.Web.UI.WebControls.HyperLink hlkbCallao;
		protected projDataGridWeb.DataGridWeb dgConsulta;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion

		#region Constantes
		//Paginas
		const string URLGENERADORGRAFICOS = "ChartGenerator.aspx?";
		const string URLIMPRESION = "PopupImpresionGraficoVentasPresupuestadasporTipoCliente.aspx";

		//Otros
		const string TituloConstanteVentaPresupuestada = "VENTAS PRESUPUESTADAS POR TIPO DE SECTOR";
		const string TituloConstanteVentaEjecutada = "VENTAS EJECUTADAS POR TIPO DE SECTOR";
		const string RutaVentaPresupuestada = "Grafico de Ventas Presupuestadas Por Tipo de Sector";
		const string RutaVentaEjecutada = "Grafico de Ventas Ejecutadas Por Tipo de Sector";
		const string TituloVacioVentaPresupuestada = "No existen Ventas Presupuestadas";
		const string TituloVacioVentaEjecutada = "No existen Ventas Ejecutadas";
		const string Version = "Version";
		const int Cantidad = 2;
		const int alto = 300;
		const int cantidadglosas = 4;
		const int POSICIONINICIALCOMBO = 0;
		
		//Key Session y QueryString
		const string KEYQIDVERSION = "IdVersion";
		const string KEYQANO = "Ano";
		const string VALORESX = "xValues";
		const string VALORESY = "yValues";
		const string VALORTIPOGRAFICO = "ChartType";
		const string TIPOGRAFICOBARRA = "bar";
		const string KEYALTO = "alto";
		const string KEYCANTIDADGLOSAS = "cantidadglosas";
		protected System.Web.UI.HtmlControls.HtmlInputHidden RutaArchivo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden NombreArchivoTXT;
		const string KEYGRAFICOGRANDE = "grafico";
		#endregion
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				this.ConfigurarAccesoControles();
				Helper.ReiniciarSession();
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se consulto el grafico Comparativo de Ventas Reales por Periodos",Enumerados.NivelesErrorLog.I.ToString()));
				this.LlenarGrilla();
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
			this.dgConsulta.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgConsulta_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members
		string Titulo="";
		string PeriodoVersion="";
		public void LlenarGrilla()
		{
			DataTable dtImprimir = new DataTable();
			DataTable dtVentas = new DataTable();
			PeriodoVersion = Page.Request.QueryString[KEYQANO]; 
			
			if( Convert.ToInt32(Page.Request.QueryString[KEYQANO]) >= DateTime.Today.Year)
			{
				Titulo= TituloConstanteVentaPresupuestada;
				this.lblPagina.Text = RutaVentaPresupuestada;
				PeriodoVersion = PeriodoVersion + Utilitario.Constantes.SEPARADORLINEA + Version + Utilitario.Constantes.ESPACIO + Page.Request.QueryString[KEYQIDVERSION] ;
				CVentasPresupuestadas oCVentasPresupuestadas = new CVentasPresupuestadas();
				dtVentas =  oCVentasPresupuestadas.ListarPorcentajePorTipoCliente(Convert.ToInt32(Page.Request.QueryString[KEYQIDVERSION]),Convert.ToInt32(Page.Request.QueryString[KEYQANO]));
			}
			else
			{
				Titulo= TituloConstanteVentaEjecutada;
				this.lblPagina.Text = RutaVentaEjecutada;
				CVentasReales oCVentasReales = new CVentasReales();
				dtVentas =  oCVentasReales.ListarPorcentajeVentaEjecutadaPorTipoCliente(Convert.ToInt32(Page.Request.QueryString[KEYQANO]));
			}

			if(dtVentas!= null)
			{
				dtImprimir = dtVentas.Copy();
				DataView dwVentas =	dtVentas.DefaultView;
								
				if(dwVentas.Count > POSICIONINICIALCOMBO)
				{
					dgConsulta.DataSource = dwVentas;								
				}
				else
				{
					dgConsulta.DataSource	= null;
				}			
			}
			else
			{
				dgConsulta.DataSource	= dtVentas;
			}
			
			try
			{
				dgConsulta.DataBind();
				CImpresion oCImpresion = new CImpresion();
				if( Convert.ToInt32(Page.Request.QueryString[KEYQANO]) >= DateTime.Today.Year)
				{
					oCImpresion.GuardarDataImprimirExportar(dtImprimir,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGOTITULOREPORTEVENTASPRESUPUESTADAS),PeriodoVersion);
				}
				else
				{
					oCImpresion.GuardarDataImprimirExportar(dtImprimir,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGOTITULOREPORTEVENTASEJECUTADAS),PeriodoVersion);
				}
			}
			catch(Exception	ex)
			{
				string a = ex.Message;
				dgConsulta.CurrentPageIndex = 0;
				dgConsulta.DataBind();
			}	
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add GraficoVentasPresupuestadasporTipoCliente.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add GraficoVentasPresupuestadasporTipoCliente.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add GraficoVentasPresupuestadasporTipoCliente.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			CGraficoBarra oCGraficoBarra= new CGraficoBarra();
			CImpresion oCImpresion = new CImpresion();
			StringBuilder [] Coordenadas = new StringBuilder[Cantidad];
			StringBuilder [] CoordenadasImpresion = new StringBuilder[Cantidad];

			if( Convert.ToInt32(Page.Request.QueryString[KEYQANO]) >= DateTime.Today.Year)
			{
				Coordenadas = oCGraficoBarra.ConsultarPorcentajeVentasPresupuestadaspPorTipoCliente(Convert.ToInt32(Page.Request.QueryString[KEYQIDVERSION]),Convert.ToInt32(Page.Request.QueryString[KEYQANO]));
			}
			else
			{
				Coordenadas = oCGraficoBarra.ConsultarPorcentajeVentasEjecutadasPorTipoCliente(Convert.ToInt32(Convert.ToInt32(Page.Request.QueryString[KEYQANO])));
			}

			if(Coordenadas != null)
			{

					this.GraficarBarra(Coordenadas);
			}
			else
			{
				lblResultado.Visible = true;
				
				if( Convert.ToInt32(Page.Request.QueryString[KEYQANO]) >= DateTime.Today.Year)
				{
					lblResultado.Text = TituloVacioVentaPresupuestada; 
				}
				else
				{
					lblResultado.Text = TituloVacioVentaEjecutada; 
				}
			}
		}

		private void GraficarBarra(StringBuilder [] Coordenadas)
		{
			string []Datos=Coordenadas[0].ToString().Split('|');
			int LngArr =Datos.Length;

			string []Barras=new string[LngArr];
			string []BarrasValores=Coordenadas[1].ToString().Split('|');

			string []EtiquetaValores=  new string[1]{Page.Request.QueryString[KEYQANO].ToString()};
			
			for(int i=0;i<=LngArr-1;i++)
			{
				Barras[i] = Helper.ObtenerColorSector(Datos[i].ToString()) + "," + Datos[i].ToString();
			}

			string []Leyenda=new string[]{"","","PERIODO " + PeriodoVersion};
			string []ArchivoyRuta = Helper.Graph(Utilitario.Enumerados.TiposGraficoEstadistico.Barra,Titulo,Leyenda,EtiquetaValores,Barras,BarrasValores);
			this.RutaArchivo.Value= ArchivoyRuta[0].ToString();
			this.NombreArchivoTXT.Value= ArchivoyRuta[1].ToString();
			
		}
		public void LlenarJScript()
		{
			// TODO:  Add GraficoVentasPresupuestadasporTipoCliente.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add GraficoVentasPresupuestadasporTipoCliente.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			ltlMensaje.Text = Helper.PopupImpresion(URLIMPRESION,790,500,false,false,false,true,true);
		}

		public void Exportar()
		{
			// TODO:  Add GraficoVentasPresupuestadasporTipoCliente.Exportar implementation
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
			// TODO:  Add GraficoVentasPresupuestadasporTipoCliente.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void ibtnImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Imprimir();
			
		}

		private void dgConsulta_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
			}
		}

	}
}
