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
	/// <summary>
	/// Summary description for VentasPresupuestadaAcumuadaLineaNegocio.
	/// </summary>
	public class VentasPresupuestadaAcumuadaLineaNegocio : System.Web.UI.Page, IPaginaBase
	{
		#region controles
		protected System.Web.UI.WebControls.Label lblTituloAno1;
		protected System.Web.UI.WebControls.Label lblTituloAno;
		protected System.Web.UI.WebControls.DropDownList ddlbTipo;
		protected System.Web.UI.WebControls.Label lblTipo;
		protected System.Web.UI.WebControls.Image ChartImage;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Literal ltlMensaje;

		#endregion

		#region constantes
		//Paginas
		const string URLGENERADORGRAFICOS = "ChartGenerator.aspx?";
		const string URLIMPRESION = "PopupImpresionVentasPresupuestadaAcumuadaLineaNegocio.aspx";

		//Otros
		const string TipoSectorPrivado = "PRIV";
		const string TipoSectorMarina = "MGP";
		const string TipoAcumulado = "ACUMULADO";
		const string VALORESX = "xValues";
		const string VALORESY = "yValues";
		const string VALORTIPOGRAFICO = "ChartType";
		const string TIPOGRAFICOBARRA = "bar";
		const string KEYALTO = "alto";
		const int Cantidad = 2;
		

		//Key Session y QueryString
		const string KEYQIDVERSION = "IdVersion";
		const string ANO = "Ano";
		const string TituloConstante = "GRAFICO COMPARATIVO POR LINEA DE NEGOCIO";
		const string TituloVentaPresupuestada = "Venta Presupuestada";
		protected System.Web.UI.WebControls.Image Image1;
		protected System.Web.UI.WebControls.Image Image2;
		protected System.Web.UI.HtmlControls.HtmlInputHidden RutaArchivo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden NombreArchivoTXT;
		const string TituloVentaEjecutada = "Venta Ejecutada";
		#endregion

		string SubTitulo="";
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				this.ConfigurarAccesoControles();
				Helper.ReiniciarSession();
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se consulto el grafico Comparativo de Ventas Reales por Periodos",Enumerados.NivelesErrorLog.I.ToString()));
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
			this.ddlbTipo.SelectedIndexChanged += new System.EventHandler(this.ddlbTipo_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members


		public void LlenarGrilla()
		{
			// TODO:  Add VentasPresupuestadaAcumuadaLineaNegocio.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add VentasPresupuestadaAcumuadaLineaNegocio.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add VentasPresupuestadaAcumuadaLineaNegocio.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			this.ddlbTipo.Items.Insert(Utilitario.Constantes.POSICIONINDEXCERO,TipoAcumulado);
			this.ddlbTipo.Items.Insert(Utilitario.Constantes.POSICIONINDEXUNO,TipoSectorPrivado);
			this.ddlbTipo.Items.Insert(Utilitario.Constantes.POSICIONINDEXDOS,TipoSectorMarina);
		}

		public void LlenarDatos()
		{
			this.LlenarComentarios();
			
			//this.lblTituloAno.Text = Convert.ToString(Page.Request.QueryString[ANO]);
			//this.lblTituloAno1.Text = Convert.ToString(Convert.ToInt32(Page.Request.QueryString[ANO]) - 1) + Utilitario.Constantes.LINEA;
			SubTitulo = Convert.ToString(Convert.ToInt32(Page.Request.QueryString[ANO]) - 1) + Utilitario.Constantes.LINEA + Convert.ToString(Page.Request.QueryString[ANO]);

			CGraficoBarra oCGraficoBarra = new CGraficoBarra();

			CImpresion oCImpresion = new CImpresion();
			StringBuilder [] CoordenadasImpresion = new StringBuilder[Cantidad];
			StringBuilder [] Coordenadas;

			if(this.ddlbTipo.SelectedItem.Text == TipoAcumulado)
			{
				Coordenadas = oCGraficoBarra.ConsultarVentasPresupuestadasAcumuladaLineaNegocio(Convert.ToInt32(Page.Request.QueryString[KEYQIDVERSION]),Convert.ToInt32(Page.Request.QueryString[ANO]), Utilitario.Constantes.POSICIONINDEXCERO);
			}
			else if(this.ddlbTipo.SelectedItem.Text == TipoSectorPrivado)
			{
				Coordenadas = oCGraficoBarra.ConsultarVentasPresupuestadasAcumuladaLineaNegocio(Convert.ToInt32(Page.Request.QueryString[KEYQIDVERSION]),Convert.ToInt32(Page.Request.QueryString[ANO]), Utilitario.Constantes.POSICIONINDEXUNO);
			}
			else
			{
				Coordenadas = oCGraficoBarra.ConsultarVentasPresupuestadasAcumuladaLineaNegocio(Convert.ToInt32(Page.Request.QueryString[KEYQIDVERSION]),Convert.ToInt32(Page.Request.QueryString[ANO]), Utilitario.Constantes.POSICIONINDEXDOS);
			}
			

			if(Coordenadas != null)
			{
				/*
				ChartImage.ImageUrl = URLGENERADORGRAFICOS + 
					VALORESX + Constantes.SIGNOIGUAL + Coordenadas[Constantes.POSICIONCONTADOR].ToString() + Constantes.SIGNOAMPERSON +
					VALORESY + Constantes.SIGNOIGUAL + Coordenadas[Constantes.POSICIONCONTADOR+1].ToString() + Constantes.SIGNOAMPERSON +
					VALORTIPOGRAFICO + Constantes.SIGNOIGUAL + TIPOGRAFICOBARRA + Constantes.SIGNOAMPERSON +
					KEYALTO + Constantes.SIGNOIGUAL + "350";
			
				ChartImage.Visible = true;
				ChartImage.Attributes.Clear();

				CoordenadasImpresion[Constantes.POSICIONCONTADOR] = Coordenadas[Constantes.POSICIONCONTADOR];
				CoordenadasImpresion[Constantes.POSICIONCONTADOR+1] = Coordenadas[Constantes.POSICIONCONTADOR+1];

				oCImpresion.GuardarCoordenadasImprimir(CoordenadasImpresion,this.lblTitulo.Text);
				*/

				Array ArrDatos =this.Distinc(Coordenadas);
				StringBuilder sb = new StringBuilder();
				for(int i=0;i<=ArrDatos.Length-1;i++)
				{
					string Delimitador = ((i==(ArrDatos.Length-1))?"":"|");
					sb.Append(Helper.ObtenerColoresPorPeriodo(Convert.ToInt32(ArrDatos.GetValue(i).ToString())) + "," + ArrDatos.GetValue(i).ToString() + Delimitador);
				}
				Coordenadas = Helper.SBRedimensionar(Coordenadas,3);
				Coordenadas[2] = sb;
				GraficarBarrar(Coordenadas);

			}
			else
			{
				//this.ibtnImprimir.Visible = false;
			}
		}

		string [] ArrPeriodo;
		string [] ArrLineaNegocio;
		int idx=0;
		private Array Distinc(StringBuilder [] Coordenadas)
		{
			
			string []aPeriodo = Coordenadas[0].ToString().Replace("CN","")
														.Replace("RN","")
														.Replace("AE","")
														.Replace("MM","")
														.Replace("SV","")
														.Replace(" ","")
														.Split('|');
			ArrPeriodo = new string[aPeriodo.Length];
			for(int i=0;i<= aPeriodo.Length-1;i++)
			{
				string Valor = aPeriodo[i].ToString();
				if(BuscarPeriodo(Convert.ToInt32(Valor))==false)
				{
					ArrPeriodo[idx]=Valor;
					idx++;		
				}
			}
			Array DistinctPeriodo = Helper.ArrayRedimendionar(ArrPeriodo,idx);
			/*-----------------------------------------------------------------------------*/
			string strLineaN=Coordenadas[0].ToString();
			for(int i=0;i<= idx-1;i++)
			{
				strLineaN = strLineaN.Replace(ArrPeriodo[i].ToString(),"").Replace(" ","");
			}

			idx=0;
			string []aLineaNegocio =  strLineaN.Split('|');
			ArrLineaNegocio = new string[aLineaNegocio.Length];
			for(int i=0;i<= aLineaNegocio.Length-1;i++)
			{
				string Valor = aLineaNegocio[i].ToString();
				if(BuscarLineadeNegocio(Valor)==false)
				{
					ArrLineaNegocio[idx]=Valor;
					idx++;		
				}
			}
			Array aLN = Helper.ArrayRedimendionar(ArrLineaNegocio,idx);
			StringBuilder sb = new StringBuilder();
			for(int i=0;i<=aLN.Length-1;i++)
			{
				string Delimitador = ((i==(aLN.Length-1))?"":"|");
				sb.Append(aLN.GetValue(i).ToString() + Delimitador);
			}
			Coordenadas[0]= sb;
			return DistinctPeriodo;
		}
		


		private bool BuscarPeriodo(int Periodo)
		{
			if(ArrPeriodo.Length>0)
			{
				for(int i=0;i<=ArrPeriodo.Length-1;i++)
				{
					if(Convert.ToInt32(ArrPeriodo[i])==Periodo)
					{
						return  true;
					}
				}
			}
			return false;
		}
		private bool BuscarLineadeNegocio(string LineadeNegocio)
		{
			if(ArrLineaNegocio.Length>0)
			{
				for(int i=0;i<=ArrLineaNegocio.Length-1;i++)
				{
					if((ArrLineaNegocio[i]!=null)&&(ArrLineaNegocio[i].ToString()==LineadeNegocio))
					{
						return  true;
					}
				}
			}
			return false;
		}

		private void GraficarBarrar(StringBuilder []Coordenadas)
		{
			string []Barras=Coordenadas[2].ToString().Split('|');
			string []BarrasValores=new string[2];
			string strValores1="";
			string strValores2="";
			int i=0;
			foreach(string Dato in Coordenadas[1].ToString().Split('|'))
			{
				switch ((i%2))
				{
					case 0:
						strValores1 = strValores1 + Dato + ",";
						break;
					default:
						strValores2 = strValores2 + Dato + ",";
						break;
				}
				i++;
			}
			string []EtiquetaValores = Coordenadas[0].ToString().Split('|');
			string []Leyenda=new string[]{"","","PERIODO "};
			
			BarrasValores[0]=strValores1.Substring(0,strValores1.Length-1);
			BarrasValores[1]=strValores2.Substring(0,strValores2.Length-1);

			string []ArchivoyRuta =Helper.Graph(Enumerados.TiposGraficoEstadistico.Barra,"GRAFICO CORPORATIVO POR LINE DE NEGOCIO " + SubTitulo ,Leyenda,EtiquetaValores,Barras,BarrasValores);
			this.RutaArchivo.Value= ArchivoyRuta[0].ToString();
			this.NombreArchivoTXT.Value= ArchivoyRuta[1].ToString();
		}



		public void LlenarJScript()
		{
			// TODO:  Add VentasPresupuestadaAcumuadaLineaNegocio.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add VentasPresupuestadaAcumuadaLineaNegocio.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			ltlMensaje.Text = Helper.PopupImpresion(URLIMPRESION,800,500,false,false,false,true,true);
		}

		public void Exportar()
		{
			// TODO:  Add VentasPresupuestadaAcumuadaLineaNegocio.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add VentasPresupuestadaAcumuadaLineaNegocio.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add VentasPresupuestadaAcumuadaLineaNegocio.ValidarFiltros implementation
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


		private void LlenarComentarios()
		{
			if(Convert.ToInt32(Page.Request.QueryString[ANO]) >= DateTime.Today.Year)
			{
				if(Convert.ToString(Page.Request.QueryString[ANO]) == Convert.ToString(DateTime.Today.Year))
				{
					this.lblTituloAno.ToolTip = TituloVentaPresupuestada;
					this.lblTituloAno1.ToolTip = TituloVentaEjecutada;
				}
				else
				{
					this.lblTituloAno.ToolTip = TituloVentaPresupuestada;
					this.lblTituloAno1.ToolTip = TituloVentaPresupuestada;
				}
			}
			else
			{
				this.lblTituloAno.ToolTip = TituloVentaEjecutada;
				this.lblTituloAno1.ToolTip = TituloVentaEjecutada;
			}
		}

	}
}
