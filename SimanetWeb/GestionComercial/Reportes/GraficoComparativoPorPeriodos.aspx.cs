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
	public class GraficoComparativoPorPeriodos : System.Web.UI.Page,IPaginaBase
	{
		#region Controles

		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Literal ltlMensaje;

		#endregion

		#region Constantes

		//Paginas
		const string URLPRINCIPAL = "../Ventas/ConsultarMontoVentasReales.aspx";
		const string URLGENERADORGRAFICOS = "ChartGenerator.aspx?";
		const string URLIMPRESION = "PopupImpresionGraficoComparativoPorPeriodos.aspx";

		//Otros
		const string VALORESX = "xValues";
		const string VALORESY = "yValues";
		const string VALORTIPOGRAFICO = "ChartType";
		const string TIPOGRAFICOBARRA = "bar";
		const string FORMATODECIMAL5 = "FormatoDecimal5";
		const string FLGFORMATO = "1";
		const int Cantidad = 2;
		const string KEYALTO = "alto";
		const string alto= "350";
		protected System.Web.UI.HtmlControls.HtmlInputHidden RutaArchivo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden NombreArchivoData;
		protected System.Web.UI.HtmlControls.HtmlInputHidden NombreArchivoTXT;
		const string GRILLAVACIA ="No existe ninguna Venta Ejecutada.";

		#endregion
		string Titulo =" GRAFICO COMPARATIVO DE VENTAS COLOCADAS";
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				this.ConfigurarAccesoControles();

				Helper.ReiniciarSession();

				this.LlenarJScript();

				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se consulto el grafico Comparativo de Ventas Reales por Periodos",Enumerados.NivelesErrorLog.I.ToString()));

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

		private void ibtnAtras_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Page.Response.Redirect(URLPRINCIPAL);
		}
		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add GraficoComparativoPorPeriodos.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add GraficoComparativoPorPeriodos.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add GraficoComparativoPorPeriodos.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add GraficoComparativoPorPeriodos.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			Titulo += Constantes.ESPACIO + Constantes.SIGNOABREPARANTESIS + DateTime.Now.Year.ToString() + Constantes.LINEA + (DateTime.Now.Year-1).ToString() + Constantes.SIGNOCIERRAPARANTESIS;
			DataTable dt = (new CGraficoBarra()).ConsultarVentasRealesComparativasPorPeriodo_D(Helper.FechaSimanet.ObtenerFechaSesion());
			if(dt != null)
			{
				this.GraficarOpcion1(dt);
			}
			else
			{
				this.lblResultado.Visible = true;
				this.lblResultado.Text = GRILLAVACIA;
			}
		}
		private void GraficarOpcion1(DataTable dt)
		{
			string []Barras=new string[3];
			string []BarrasValores=new string[3];
			string []EtiquetaValores=new string[3];
			int idx=0;
			string sQuiebre="";
			foreach(DataRow dr in dt.Rows)
			{
				Barras[idx]= Helper.ObtenerColorTipoInformacion(dr["Abreviatura"].ToString()) + ","+ dr["Abreviatura"].ToString() + " " + dr["Periodo"].ToString();
				BarrasValores[idx] = dr["valor"].ToString();
				EtiquetaValores[idx]= "PPTO - PROY  - REAL";
				sQuiebre=dr["valor"].ToString();
				idx++;
			}
			string []Leyenda=new string[]{"","",""};
			string []ArchivoyRuta = Helper.Graph(Utilitario.Enumerados.TiposGraficoEstadistico.Barra,Titulo,Leyenda,EtiquetaValores,Barras,BarrasValores);
			this.RutaArchivo.Value= ArchivoyRuta[0].ToString();
			this.NombreArchivoTXT.Value= ArchivoyRuta[1].ToString();
		}


		public void LlenarJScript()
		{
			// TODO:  Add GraficoComparativoPorPeriodos.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add GraficoComparativoPorPeriodos.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add GraficoComparativoPorPeriodos.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add GraficoComparativoPorPeriodos.Exportar implementation
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
			// TODO:  Add GraficoComparativoPorPeriodos.ValidarFiltros implementation
			return false;
		}

		#endregion
	}
}