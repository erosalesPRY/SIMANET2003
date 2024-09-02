using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using SIMA.UtilGraph;
using SIMA.SimaNetWeb.InterfacesIU;
using NetAccessControl;
using SIMA.Utilitario;

namespace SIMA.SimaNetWeb.GestionComercial.Reportes
{
	/// <summary>
	/// Summary description for ChartGenerator.
	/// </summary>
	public class ChartGenerator : System.Web.UI.Page,IPaginaBase
	{
		//Key Session y QueryString
		const string VALORESX = "xValues";
		const string VALORESY = "yValues";
		const string VALORTIPOGRAFICO = "ChartType";
		const string TIPOGRAFICOBARRA = "bar";
		const string VALORIMPRESION = "Print";
		const string KEYALTO = "alto";
		const string KEYANCHO = "ancho";
		const string KEYCANTIDADGLOSAS = "cantidadglosas";
		const string KEYGRAFICOGRANDE = "grafico";
		const string FORMATODECIMAL5 = "FormatoDecimal5";
		const string FLGFORMATO = "1";

		private void Page_Load(object sender, System.EventArgs e)
		{
				this.ConfigurarAccesoControles();
			
				// set return type to png image format
				Response.ContentType = "image/png";

				string xValues, yValues, chartType, print;
				bool boolPrint;

				// Get input parameters from query string
				chartType = Request.QueryString[VALORTIPOGRAFICO];
				xValues = Request.QueryString[VALORESX];
				yValues = Request.QueryString[VALORESY];
				print = Request.QueryString[VALORIMPRESION];

				if (chartType == null)
					chartType = "";

				// check for printing option 
				if (print == null)
					boolPrint = false;
				else
				{
					try
					{
						boolPrint = Convert.ToBoolean(print);
					}
					catch
					{
						boolPrint = false;
					}
				}

				if (xValues != null && yValues != null)
				{
					Color bgColor;

					if (boolPrint)
						bgColor = Color.White;
					else
						//bgColor = Color.FromArgb(255,253,244);
						bgColor = Color.FromArgb(99,155,211);

					Bitmap StockBitMap;
					MemoryStream memStream = new MemoryStream();

					switch (chartType)
					{
						case "bar":
							BarGraph bar = new BarGraph(bgColor);
					
							bar.VerticalLabel = "S/.";
							if(Request.QueryString[KEYCANTIDADGLOSAS]!=null)
							{
								bar.VerticalTickCount = Convert.ToInt32(Request.QueryString[KEYCANTIDADGLOSAS]);
							}
							else
							{
								bar.VerticalTickCount = 10;
							}
							bar.ShowLegend = true;
							bar.ShowData = true;

							if(Request.QueryString[KEYALTO]!=null)
							{
								bar.Height = Convert.ToInt32(Request.QueryString[KEYALTO]);
							}
							else
							{
								bar.Height = 380;
							}

							if(Request.QueryString[KEYANCHO]!=null)
							{
								bar.Width = Convert.ToInt32(Request.QueryString[KEYANCHO]);
							}
							else
							{
								bar.Width = 740;
							}

							if(Request.QueryString[KEYGRAFICOGRANDE]!=null)
							{
								bar.LegendFontSize = 5;
								bar.LegendRectangleSize = 4F;
								bar.Spacer = 0.5F;
							}
					
							bar.CollectDataPoints(xValues.Split("|".ToCharArray()), yValues.Split("|".ToCharArray()));
							if(Request.QueryString[FORMATODECIMAL5] == FLGFORMATO)
							{
								bar.FormatoDecimal = Utilitario.Constantes.FORMATODECIMAL5;
							}
							StockBitMap = bar.Draw();
							break;
						default:
							PieChart pc = new PieChart(bgColor);

							pc.CollectDataPoints(xValues.Split("|".ToCharArray()),yValues.Split("|".ToCharArray()));

							StockBitMap = pc.Draw();

							break;
					}
					// Render BitMap Stream Back To Client
					StockBitMap.Save(memStream, ImageFormat.Png);
					memStream.WriteTo(Response.OutputStream);
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
			// TODO:  Add ChartGenerator.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ChartGenerator.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add ChartGenerator.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add ChartGenerator.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add ChartGenerator.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add ChartGenerator.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ChartGenerator.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ChartGenerator.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ChartGenerator.Exportar implementation
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
			// TODO:  Add ChartGenerator.ValidarFiltros implementation
			return false;
		}

		#endregion
	}
}