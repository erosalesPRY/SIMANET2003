using System;
using System.Collections;
using  System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using SIMA.SimaNetWeb.InterfacesIU;
using SIMA.Controladoras.GestionComercial;
using SIMA.Controladoras.General;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using System.Text;

namespace SIMA.SimaNetWeb.GestionComercial.Reportes
{
	/// <summary>
	/// Summary description for GraficoVentasAcumuladasporLineadeNegocio.
	/// </summary>
	public class GraficoVentasAcumuladasporLineadeNegocio : System.Web.UI.Page,IPaginaBase
	{
		const string GRILLAVACIA ="No existe ninguna Venta Real.";


		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.HtmlControls.HtmlInputHidden RutaArchivo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden NombreArchivoConfig;
		protected System.Web.UI.HtmlControls.HtmlInputHidden NombreArchivoData;
	
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
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add GraficoVentasAcumuladasporLineadeNegocio.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add GraficoVentasAcumuladasporLineadeNegocio.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add GraficoVentasAcumuladasporLineadeNegocio.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			CVentasReales oCVentasReales = new CVentasReales();
			DataTable dtVentas =  oCVentasReales.ConsultarMontoVentasRealesPorLineaNegocio(Helper.FechaSimanet.ObtenerFechaSesion());
		
			if(dtVentas!=null)
			{
				StringBuilder [] Coordenadas = ObtenerCoordenadas(dtVentas);
				Coordenadas = Helper.EstablecerColorLineaNegocio(Coordenadas);
				int Radio = ((Helper.ObtenerAltodePantalla()>600)?240:150);
				int TopLeg = (Helper.ObtenerAltodePantalla() -300);
				string []Parametros = new string[3];
				Parametros = Helper.Graph(Utilitario.Enumerados.TiposGraficoEstadistico.Pie,Utilitario.Enumerados.LibreriaGraph.Version2,"VENTAS ACUMULADAS CORPORATIVO  <BR> POR LINEA DE NEGOCIO",12,Radio,0,TopLeg,"#FFFFFF","#696969",Coordenadas);
				RutaArchivo.Value=Parametros[0].ToString();
				NombreArchivoConfig.Value=Parametros[1].ToString();
				NombreArchivoData.Value=Parametros[2].ToString();

				lblResultado.Visible = false;

			}
			else
			{
				//dgConsultaMensual.DataSource = dtVentas;
				lblResultado.Visible = true;
				lblResultado.Text = GRILLAVACIA;
			}
		}
		private StringBuilder []ObtenerCoordenadas(DataTable dt)
		{
			
			StringBuilder Titulo = new StringBuilder();
			StringBuilder Valores = new StringBuilder();
			int i=0;
			foreach(DataRow dr in dt.Rows)
			{
				string Separador = (((dt.Rows.Count-1)==i)?"":"|");
				Titulo.Append(dr["Abreviatura"].ToString() + Separador);
				double Monto = Math.Round(Convert.ToDouble(dr["total"].ToString()),0) ;
				Valores.Append(Monto.ToString() + Separador);
				i++;
			}
			StringBuilder [] Coordenadas = new StringBuilder[2];
			Coordenadas[0]=Titulo;
			Coordenadas[1]=Valores;
			return Coordenadas;
		}

		public void LlenarJScript()
		{
			// TODO:  Add GraficoVentasAcumuladasporLineadeNegocio.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add GraficoVentasAcumuladasporLineadeNegocio.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add GraficoVentasAcumuladasporLineadeNegocio.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add GraficoVentasAcumuladasporLineadeNegocio.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add GraficoVentasAcumuladasporLineadeNegocio.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add GraficoVentasAcumuladasporLineadeNegocio.ValidarFiltros implementation
			return false;
		}

		#endregion
	}
}
