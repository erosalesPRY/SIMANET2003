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
	public class GraficoComparativoPorLineaNegocio : System.Web.UI.Page,IPaginaBase
	{
		#region Controles

		protected System.Web.UI.WebControls.DropDownList ddlbVista;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblVista;
		protected System.Web.UI.WebControls.Label lblTipo;
		protected System.Web.UI.WebControls.DropDownList ddlbTipo;
		protected System.Web.UI.WebControls.Image imgCallao;
		protected System.Web.UI.WebControls.Image imgIquitos;
		protected System.Web.UI.WebControls.Literal ltlMensaje;

		#endregion

		#region Constantes

		//Paginas
		const string URLGENERADORGRAFICOS = "ChartGenerator.aspx?";
		const string URLIMPRESION = "PopupImpresionGraficoComparativoPorLineaNegocio.aspx?";

		//Key Session y QueryString
		const string VALORESX = "xValues";
		const string VALORESY = "yValues";
		const string VALORTIPOGRAFICO = "ChartType";
		const string TIPOGRAFICOBARRA = "bar";
		const string KEYALTO = "alto";
		const string KEYCANTIDADGLOSAS = "cantidadglosas";
		const string KEYGRAFICOGRANDE = "grafico";
		const string KEYTIPOVISTA = "tipoVista";
		const string FORMATODECIMAL5 = "FormatoDecimal5";
		const string FLGFORMATO = "1";

		//Otros
		const int Cantidad = 2;
		const int CantidadImpresion = 6;
		
		const int altocallaoindividual = 170;
		const int altochimboteindividual = 125;

		const int alto = 118;
		const int altocallao = 160;


		const int cantidadglosas = 4;
		const int flgGraficoGrande = 17;
		const string TITULOCONSTANTE = "GRAFICO COMPARATIVO DE VENTAS COLOCADAS POR LINEA DE NEGOCIO";
		const string TITULOCALLAO = "SIMA-CALLAO";
		const string TITULOCHIMBOTE = "SIMA-CHIMBOTE";
		const string TITULOIQUITOS = "SIMA-IQUITOS S.R.LTDA.";
		const string TITULOCALLAOVACIO = "No existen Ventas Ejecutadas en SIMA-CALLAO";
		const string TITULOCHIMBOTEVACIO = "No existen Ventas Ejecutadas en SIMA-CHIMBOTE";
		const string TITULOIQUITOSVACIO = "No existen Ventas Ejecutadas en SIMA-IQUITOS S.R.LTDA.";
		const string TITULOPERU = "SIMA-PERÚ (EN MILES DE SOLES)";
		const string TITULOPERUVACIO = "No existen Ventas Ejecutadas en SIMA-PERÚ";

		const string TipoMensual = "Mensual";
		const string TipoAcumulado = "Acumulada";
		const string VistaIndividual = "Por Centro";
		const string VistaAgrupada = "SIMA-PERÚ";
		protected System.Web.UI.WebControls.Image Image2;
		protected System.Web.UI.WebControls.Image Image1;
		protected System.Web.UI.WebControls.Image Image7;
		protected System.Web.UI.WebControls.Image Image4;
		protected System.Web.UI.HtmlControls.HtmlInputHidden RutaArchivo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden NombreArchivoTXTCallao;
		protected System.Web.UI.HtmlControls.HtmlInputHidden NombreArchivoTXTChimbote;
		protected System.Web.UI.HtmlControls.HtmlInputHidden NombreArchivoTXTIquitos;
		protected System.Web.UI.HtmlControls.HtmlInputHidden NombreArchivoTXTPeru;
		const string GRILLAVACIA ="No existe ninguna Venta Ejecutada.";

		#endregion
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				this.ConfigurarAccesoControles();

				Helper.ReiniciarSession();

				this.LlenarJScript();

				this.LlenarCombos();

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
			this.ddlbVista.SelectedIndexChanged += new System.EventHandler(this.ddlbVista_SelectedIndexChanged);
			this.ddlbTipo.SelectedIndexChanged += new System.EventHandler(this.ddlbTipo_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		private void ibtnImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			ltlMensaje.Text = Helper.PopupImpresion(URLIMPRESION+KEYTIPOVISTA+Constantes.SIGNOIGUAL+this.ddlbVista.SelectedItem.Text,750,500,false,false,false,true,true);
		}
		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add GraficoComparativoPorLineaNegocio.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add GraficoComparativoPorLineaNegocio.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add GraficoComparativoPorLineaNegocio.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			this.llenarVistas();
			this.llenarTipos();
		}

		public void LlenarDatos()
		{
			this.lblTitulo.Text = TITULOCONSTANTE + Constantes.ESPACIO + Constantes.LINEA + Constantes.ESPACIO + this.ddlbTipo.SelectedItem.Text.ToUpper() + Constantes.ESPACIO + Constantes.LINEA + Constantes.ESPACIO + this.ddlbVista.SelectedItem.Text.ToUpper();

			if(this.ddlbVista.SelectedItem.Text == VistaIndividual)
			{
				CGraficoBarra oCGraficoBarra = new CGraficoBarra();
				StringBuilder [] CoordenadasCallao = new StringBuilder[Cantidad];

				CImpresion oCImpresion = new CImpresion();
				StringBuilder [] CoordenadasImpresion = new StringBuilder[CantidadImpresion];

				if(this.ddlbTipo.SelectedItem.Text == TipoMensual)
				{
					CoordenadasCallao = oCGraficoBarra.ConsultarVentasRealesComparativasPorLineaNegocio(Convert.ToInt32(Enumerados.IdCentroOperativo.SimaCallao), Helper.FechaSimanet.ObtenerFechaSesion());
					DataTable dt = (new CGraficoBarra()).ConsultarVentasRealesComparativasPorLineaNegocio_D(Convert.ToInt32(Enumerados.IdCentroOperativo.SimaCallao), Helper.FechaSimanet.ObtenerFechaSesion());
					this.GraficarBarrar(dt,Convert.ToInt32(Enumerados.IdCentroOperativo.SimaCallao));
				}
				else
				{
					CoordenadasCallao = oCGraficoBarra.ConsultarVentasRealesComparativasPorLineaNegocioAcumulada(Convert.ToInt32(Enumerados.IdCentroOperativo.SimaCallao), Helper.FechaSimanet.ObtenerFechaSesion());
					DataTable dt = (new CGraficoBarra()).ConsultarVentasRealesComparativasPorLineaNegocioAcumulada_D(Convert.ToInt32(Enumerados.IdCentroOperativo.SimaCallao), Helper.FechaSimanet.ObtenerFechaSesion());
					this.GraficarBarrar(dt,Convert.ToInt32(Enumerados.IdCentroOperativo.SimaCallao));
				}

				#region CoordenadasCallao
				if(CoordenadasCallao != null)
				{
					imgCallao.ImageUrl = URLGENERADORGRAFICOS + 
						VALORESX + Constantes.SIGNOIGUAL + CoordenadasCallao[Constantes.POSICIONCONTADOR].ToString() + Constantes.SIGNOAMPERSON +
						VALORESY + Constantes.SIGNOIGUAL + CoordenadasCallao[Constantes.POSICIONCONTADOR+1].ToString() + Constantes.SIGNOAMPERSON +
						VALORTIPOGRAFICO + Constantes.SIGNOIGUAL + TIPOGRAFICOBARRA + Constantes.SIGNOAMPERSON +
						KEYALTO + Constantes.SIGNOIGUAL + altocallaoindividual.ToString() + Constantes.SIGNOAMPERSON +
						KEYCANTIDADGLOSAS + Constantes.SIGNOIGUAL + cantidadglosas.ToString() + Constantes.SIGNOAMPERSON +
						FORMATODECIMAL5 + Constantes.SIGNOIGUAL + FLGFORMATO;
			
					imgCallao.Visible = true;
					imgCallao.Attributes.Clear();

					CoordenadasImpresion[Constantes.POSICIONCONTADOR] = CoordenadasCallao[Constantes.POSICIONCONTADOR];
					CoordenadasImpresion[Constantes.POSICIONCONTADOR+1] = CoordenadasCallao[Constantes.POSICIONCONTADOR+1];
				}
				else
				{
					imgCallao.ImageUrl = null;
					imgCallao.Visible = false;
					imgCallao.Attributes.Clear();
				}
				#endregion

				oCGraficoBarra = new CGraficoBarra();
				StringBuilder [] CoordenadasChimbote = new StringBuilder[Cantidad];

				if(this.ddlbTipo.SelectedItem.Text == TipoMensual)
				{
					CoordenadasChimbote = oCGraficoBarra.ConsultarVentasRealesComparativasPorLineaNegocio(Convert.ToInt32(Enumerados.IdCentroOperativo.SimaChimbote), Helper.FechaSimanet.ObtenerFechaSesion());
					DataTable dt = (new CGraficoBarra()).ConsultarVentasRealesComparativasPorLineaNegocio_D(Convert.ToInt32(Enumerados.IdCentroOperativo.SimaChimbote), Helper.FechaSimanet.ObtenerFechaSesion());
					this.GraficarBarrar(dt,Convert.ToInt32(Enumerados.IdCentroOperativo.SimaChimbote));

				}
				else
				{
					CoordenadasChimbote = oCGraficoBarra.ConsultarVentasRealesComparativasPorLineaNegocioAcumulada(Convert.ToInt32(Enumerados.IdCentroOperativo.SimaChimbote), Helper.FechaSimanet.ObtenerFechaSesion());
					DataTable dt = (new CGraficoBarra()).ConsultarVentasRealesComparativasPorLineaNegocioAcumulada_D(Convert.ToInt32(Enumerados.IdCentroOperativo.SimaChimbote), Helper.FechaSimanet.ObtenerFechaSesion());
					this.GraficarBarrar(dt,Convert.ToInt32(Enumerados.IdCentroOperativo.SimaChimbote));
				}

				#region CoordenadasChimbote
				if(CoordenadasChimbote != null)
				{
					/*imgChimbote.ImageUrl = URLGENERADORGRAFICOS + 
						VALORESX + Constantes.SIGNOIGUAL + CoordenadasChimbote[Constantes.POSICIONCONTADOR].ToString() + Constantes.SIGNOAMPERSON +
						VALORESY + Constantes.SIGNOIGUAL + CoordenadasChimbote[Constantes.POSICIONCONTADOR+1].ToString() + Constantes.SIGNOAMPERSON +
						VALORTIPOGRAFICO + Constantes.SIGNOIGUAL + TIPOGRAFICOBARRA + Constantes.SIGNOAMPERSON +
						KEYALTO + Constantes.SIGNOIGUAL + altochimboteindividual.ToString() + Constantes.SIGNOAMPERSON +
						KEYCANTIDADGLOSAS + Constantes.SIGNOIGUAL + cantidadglosas.ToString()+ Constantes.SIGNOAMPERSON +
						FORMATODECIMAL5 + Constantes.SIGNOIGUAL + FLGFORMATO;*/
			
					CoordenadasImpresion[Constantes.POSICIONCONTADOR+2] = CoordenadasChimbote[Constantes.POSICIONCONTADOR];
					CoordenadasImpresion[Constantes.POSICIONCONTADOR+3] = CoordenadasChimbote[Constantes.POSICIONCONTADOR+1];
				}
				else
				{
				}
				#endregion

				oCGraficoBarra = new CGraficoBarra();
				StringBuilder [] CoordenadasIquitos = new StringBuilder[Cantidad];

				if(this.ddlbTipo.SelectedItem.Text == TipoMensual)
				{
					CoordenadasIquitos = oCGraficoBarra.ConsultarVentasRealesComparativasPorLineaNegocio(Convert.ToInt32(Enumerados.IdCentroOperativo.SimaIquitos), Helper.FechaSimanet.ObtenerFechaSesion());
					DataTable dt = (new CGraficoBarra()).ConsultarVentasRealesComparativasPorLineaNegocio_D(Convert.ToInt32(Enumerados.IdCentroOperativo.SimaIquitos), Helper.FechaSimanet.ObtenerFechaSesion());
					this.GraficarBarrar(dt,Convert.ToInt32(Enumerados.IdCentroOperativo.SimaIquitos));
				}
				else
				{
					CoordenadasIquitos = oCGraficoBarra.ConsultarVentasRealesComparativasPorLineaNegocioAcumulada(Convert.ToInt32(Enumerados.IdCentroOperativo.SimaIquitos), Helper.FechaSimanet.ObtenerFechaSesion());
					DataTable dt = (new CGraficoBarra()).ConsultarVentasRealesComparativasPorLineaNegocioAcumulada_D(Convert.ToInt32(Enumerados.IdCentroOperativo.SimaIquitos), Helper.FechaSimanet.ObtenerFechaSesion());
					this.GraficarBarrar(dt,Convert.ToInt32(Enumerados.IdCentroOperativo.SimaIquitos));
				}
				
				#region CoordenadasIquitos
				if(CoordenadasIquitos != null)
				{
					imgIquitos.ImageUrl = URLGENERADORGRAFICOS + 
						VALORESX + Constantes.SIGNOIGUAL + CoordenadasIquitos[Constantes.POSICIONCONTADOR].ToString() + Constantes.SIGNOAMPERSON +
						VALORESY + Constantes.SIGNOIGUAL + CoordenadasIquitos[Constantes.POSICIONCONTADOR+1].ToString() + Constantes.SIGNOAMPERSON +
						VALORTIPOGRAFICO + Constantes.SIGNOIGUAL + TIPOGRAFICOBARRA + Constantes.SIGNOAMPERSON +
						KEYALTO + Constantes.SIGNOIGUAL + alto.ToString() + Constantes.SIGNOAMPERSON +
						KEYCANTIDADGLOSAS + Constantes.SIGNOIGUAL + cantidadglosas.ToString()+ Constantes.SIGNOAMPERSON +
						FORMATODECIMAL5 + Constantes.SIGNOIGUAL + FLGFORMATO;
			
					imgIquitos.Visible = true;
					imgIquitos.Attributes.Clear();
					CoordenadasImpresion[Constantes.POSICIONCONTADOR+4] = CoordenadasIquitos[Constantes.POSICIONCONTADOR];
					CoordenadasImpresion[Constantes.POSICIONCONTADOR+5] = CoordenadasIquitos[Constantes.POSICIONCONTADOR+1];
				}
				else
				{
					imgIquitos.ImageUrl = null;
					imgIquitos.Visible = false;
					imgIquitos.Attributes.Clear();
				}
				#endregion
				
				oCImpresion.GuardarCoordenadasImprimir(CoordenadasImpresion,this.lblTitulo.Text);
			}
			else
			{
				CGraficoBarra oCGraficoBarra = new CGraficoBarra();
				StringBuilder [] Coordenadas = new StringBuilder[Cantidad];

				CImpresion oCImpresion = new CImpresion();
				StringBuilder [] CoordenadasImpresion = new StringBuilder[Cantidad];

				if(this.ddlbTipo.SelectedItem.Text == TipoMensual)
				{
					Coordenadas = oCGraficoBarra.ConsultarVentasRealesComparativasPorLineaNegocioAgrupada(Helper.FechaSimanet.ObtenerFechaSesion());
				}
				else
				{
					Coordenadas = oCGraficoBarra.ConsultarVentasRealesComparativasPorLineaNegocioAgrupadaAcumulada(Helper.FechaSimanet.ObtenerFechaSesion());
				}

				if(Coordenadas != null)
				{
					if(Coordenadas[Constantes.POSICIONCONTADOR].ToString().Split(Constantes.SIGNOLINEAVERTICAL.ToCharArray()).Length > flgGraficoGrande)
					{
						imgCallao.ImageUrl = URLGENERADORGRAFICOS + 
							VALORESX + Constantes.SIGNOIGUAL + Coordenadas[Constantes.POSICIONCONTADOR].ToString() + Constantes.SIGNOAMPERSON +
							VALORESY + Constantes.SIGNOIGUAL + Coordenadas[Constantes.POSICIONCONTADOR+1].ToString() + Constantes.SIGNOAMPERSON +
							VALORTIPOGRAFICO + Constantes.SIGNOIGUAL + TIPOGRAFICOBARRA + Constantes.SIGNOAMPERSON +
							KEYGRAFICOGRANDE + Constantes.SIGNOIGUAL + flgGraficoGrande.ToString()+ Constantes.SIGNOAMPERSON +
							FORMATODECIMAL5 + Constantes.SIGNOIGUAL + FLGFORMATO;
					}
					else
					{
						imgCallao.ImageUrl = URLGENERADORGRAFICOS + 
							VALORESX + Constantes.SIGNOIGUAL + Coordenadas[Constantes.POSICIONCONTADOR].ToString() + Constantes.SIGNOAMPERSON +
							VALORESY + Constantes.SIGNOIGUAL + Coordenadas[Constantes.POSICIONCONTADOR+1].ToString() + Constantes.SIGNOAMPERSON +
							VALORTIPOGRAFICO + Constantes.SIGNOIGUAL + TIPOGRAFICOBARRA + Constantes.SIGNOAMPERSON +
							FORMATODECIMAL5 + Constantes.SIGNOIGUAL + FLGFORMATO	;
					}
			
					imgCallao.Visible = true;
					imgCallao.Attributes.Clear();
					this.VisualizacionTipoAcumulado();

					CoordenadasImpresion[Constantes.POSICIONCONTADOR] = Coordenadas[Constantes.POSICIONCONTADOR];
					CoordenadasImpresion[Constantes.POSICIONCONTADOR+1] = Coordenadas[Constantes.POSICIONCONTADOR+1];
				}
				else
				{
					imgCallao.ImageUrl = null;
					imgCallao.Visible = false;
					imgCallao.Attributes.Clear();
					this.VisualizacionTipoAcumulado();
				}

				oCImpresion.GuardarCoordenadasImprimir(CoordenadasImpresion,this.lblTitulo.Text);
			}
		}
		public void GraficarBarrar(DataTable dt,int IdCentroOperativo){
			DataTable dtSector = Helper.SelectDistinct(dt,"Sector");
			string []Barras=new string[dtSector.Rows.Count];
			string []BarrasValores=new string[dtSector.Rows.Count];
			
			DataTable dtLN = Helper.SelectDistinct(dt,"LineaNegocio");
			string []EtiquetaValores=new string[dtLN.Rows.Count];

			int idx=0;
			int nMax  = 0;
			int idxln =0;
			foreach(DataRow dr in dtSector.Rows)
			{
				Barras[idx] = Helper.ObtenerColorSector(dr["Sector"].ToString()) + "," + dr["Sector"].ToString();
				DataRow []adr = dt.Select("Sector ='" + dr["Sector"].ToString() + "'");
				if(adr.Length>nMax)	nMax=adr.Length;
				string Valores="";

				foreach(DataRow dr2 in adr)
				{
					Valores=Valores + dr2["Valor"].ToString() + ",";
					if(BuscarLineNegocio(EtiquetaValores,dr2["LineaNegocio"].ToString())==false)
					{
						EtiquetaValores[idxln]=dr2["LineaNegocio"].ToString();
						idxln++;
					}
				}
				BarrasValores[idx] =Valores.Substring(0,Valores.Length-1);
				idx++;
				

			}
			/*for(int i=0;i<=Barras.Length-1;i++){
				string []arrData  = BarrasValores[i].ToString().Split(',');
				if(arrData.Length<nMax)
				{
					string Valores=""; 
					for(int v=0;v<=nMax-1;v++)
					{
						try
						{
							Valores=Valores + arrData[v].ToString() + ",";
						}
						catch(Exception ex){
							Valores=Valores + "0,";
						}
					}
					BarrasValores[i]=Valores.Substring(0,Valores.Length-1);
				}
			}*/
			string Titulo = ((IdCentroOperativo==2)?"SIMA-CALLAO":((IdCentroOperativo==3)?"SIMA-CHIMBOTE":"SIMA-IQUITOS S.R.LTDA"));
			string []Leyenda=new string[]{"","","LINEA DE NEGOCIO"};
			string []ArchivoyRuta =Helper.Graph(SIMA.Utilitario.Enumerados.TiposGraficoEstadistico.Barra,Titulo,Leyenda,EtiquetaValores,Barras,BarrasValores);
			this.RutaArchivo.Value= ArchivoyRuta[0].ToString();
			switch(IdCentroOperativo)
			{
				case 2:
					this.NombreArchivoTXTCallao.Value= ArchivoyRuta[1].ToString();
					break;
				case 3:
					this.NombreArchivoTXTChimbote.Value= ArchivoyRuta[1].ToString();
					break;
				case 4:
					this.NombreArchivoTXTIquitos.Value= ArchivoyRuta[1].ToString();
					break;
			}
		}
		bool BuscarLineNegocio(string[] EtiquetaValores,string LineaNegocio)
		{
			for(int l=0;l<=EtiquetaValores.Length-1;l++)if((EtiquetaValores[l]!=null)&&(EtiquetaValores[l].ToString()==LineaNegocio))return true;
			return false;
		}
		public void LlenarJScript()
		{
			// TODO:  Add GraficoComparativoPorLineaNegocio.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add GraficoComparativoPorLineaNegocio.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add GraficoComparativoPorLineaNegocio.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add GraficoComparativoPorLineaNegocio.Exportar implementation
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
			// TODO:  Add GraficoComparativoPorLineaNegocio.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void llenarVistas()
		{
			this.ddlbVista.Items.Insert(Constantes.POSICIONCONTADOR,VistaIndividual);
			this.ddlbVista.Items.Insert(Constantes.POSICIONCONTADOR+1,VistaAgrupada);
		}

		private void llenarTipos()
		{
			this.ddlbTipo.Items.Insert(Constantes.POSICIONCONTADOR,TipoMensual);
			this.ddlbTipo.Items.Insert(Constantes.POSICIONCONTADOR+1,TipoAcumulado);
		}

		private void ddlbVista_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se consultaron las Ventas Reales Desagregadas " + this.ddlbTipo.SelectedItem.Text,Enumerados.NivelesErrorLog.I.ToString()));

			this.LlenarDatos();
		}

		private void ddlbTipo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se consultaron las Ventas Reales Desagregadas " + this.ddlbTipo.SelectedItem.Text,Enumerados.NivelesErrorLog.I.ToString()));

			this.LlenarDatos();
		}

		private void VisualizacionTipoAcumulado()
		{
			this.imgIquitos.ImageUrl = null;
			this.imgIquitos.Visible = false;
		}
	}
}