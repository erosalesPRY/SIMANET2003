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
	/// Summary description for GraficoPresupuestoIniciaYFinalYVentasPorPeriodo.
	/// </summary>
	public class GraficoPresupuestoIniciaYFinalYVentasPorPeriodo : System.Web.UI.Page,IPaginaBase
	{
		#region Constantes
			
		//Key Session y QueryString
		const string KEYQIDVERSION = "IdVersion";
		const string KEYQANO = "Ano";
		const string GRILLAVACIA="no existen datos";
		const string KEYOPTIONGRAFICO="OPGRAPH";

		#endregion
		private int Periodo
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQANO]);}
		}
		private int idVersion
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDVERSION]);}
		}
		#region Controles
			protected System.Web.UI.WebControls.Label lblResultado;
			protected System.Web.UI.HtmlControls.HtmlInputHidden RutaArchivo;
			protected System.Web.UI.WebControls.Label lblRutaPagina;
			protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hPPTOColor;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hVentaColor;
			protected System.Web.UI.HtmlControls.HtmlInputHidden NombreArchivoTXT;
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
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se consulto el grafico de Ventas Reales Corporativa de forma" ,Enumerados.NivelesErrorLog.I.ToString()));
				this.LlenarDatos();
			}
		}

		private void GraficarOpcion1(DataTable dt)
		{
			
			string []Barras=new string[]{hPPTOColor.Value + ",PRESUPUESTO APROBADO",hVentaColor.Value +",VENTAS"};
			string []BarrasValores=new string[2];
			string strValoresPPTO="";
			string strValoresVTA="";
			string []EtiquetaValores=new string[6];
			int idx=0;
			foreach(DataRow dr in dt.Rows)
			{
				strValoresPPTO = strValoresPPTO + dr["PPTO"].ToString() + ",";
				strValoresVTA = strValoresVTA + dr["VTA"].ToString() + ",";

				EtiquetaValores[idx] = dr["Periodo"].ToString();
				idx++;
			}
			string []Leyenda=new string[]{"","","PERIODO " + EtiquetaValores[0].ToString() + " - " + EtiquetaValores[EtiquetaValores.Length-1].ToString() };

			BarrasValores[0]=strValoresPPTO.Substring(0,strValoresPPTO.Length-1);
			BarrasValores[1]=strValoresVTA.Substring(0,strValoresVTA.Length-1);

			//Helper.Graph(Page,"ANALISIS VENTAS REALES VS. PRESUPUESTO",Leyenda,EtiquetaValores,Barras,BarrasValores);
			string []ArchivoyRuta = Helper.Graph(Utilitario.Enumerados.TiposGraficoEstadistico.Barra,"ANALISIS VENTAS REALES VS. PRESUPUESTO",Leyenda,EtiquetaValores,Barras,BarrasValores);
			this.RutaArchivo.Value= ArchivoyRuta[0].ToString();
			this.NombreArchivoTXT.Value= ArchivoyRuta[1].ToString();
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
			// TODO:  Add GraficoPresupuestoIniciaYFinalYVentasPorPeriodo.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add GraficoPresupuestoIniciaYFinalYVentasPorPeriodo.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add GraficoPresupuestoIniciaYFinalYVentasPorPeriodo.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add GraficoPresupuestoIniciaYFinalYVentasPorPeriodo.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			DataTable dt = new DataTable();
			dt =  (new CVentasPresupuestadas()).ConsultarPresupuestoVSVentasporPeriodo(this.Periodo,this.idVersion);
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

		public void LlenarJScript()
		{
			// TODO:  Add GraficoPresupuestoIniciaYFinalYVentasPorPeriodo.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add GraficoPresupuestoIniciaYFinalYVentasPorPeriodo.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add GraficoPresupuestoIniciaYFinalYVentasPorPeriodo.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add GraficoPresupuestoIniciaYFinalYVentasPorPeriodo.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add GraficoPresupuestoIniciaYFinalYVentasPorPeriodo.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add GraficoPresupuestoIniciaYFinalYVentasPorPeriodo.ValidarFiltros implementation
			return false;
		}

		#endregion
	}
}
