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
	/// Summary description for GraficoVentasVSPresupuestoPorPeriodo.
	/// </summary>
	public class GraficoVentasVSPresupuestoPorPeriodo : System.Web.UI.Page,IPaginaBase
	{
		#region Constantes
			
			//Key Session y QueryString
			const string KEYQIDVERSION = "IdVersion";
			const string KEYQANO = "Ano";
			const string GRILLAVACIA="no existen datos";
			const string KEYOPTIONGRAFICO="OPGRAPH";

		#endregion
		private int Periodo{
			get{return Convert.ToInt32(Page.Request.Params[KEYQANO]);}
		}
		private int idVersion
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDVERSION]);}
		}

		#region Controles

		protected System.Web.UI.HtmlControls.HtmlInputHidden NombreArchivoTXT;
		protected System.Web.UI.HtmlControls.HtmlInputHidden RutaArchivo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hVentaColor;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hPPTOAPRColor;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hPPTOColor;
				protected System.Web.UI.WebControls.Label lblResultado;
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
		private void GraficarOpcion1(DataTable dt){
			
			string []Barras=new string[]{"#CDCE29,PRESUPUESTO APROBADO","#3334AD,VENTAS"};
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
		private void GraficarBarrarOLinea(DataTable dt,Utilitario.Enumerados.TiposGraficoEstadistico TipoGrafico)
		{
			string []Barras=new string[]{this.hPPTOColor.Value + ",PRESUPUESTO APERTURA",this.hPPTOAPRColor.Value + ",PRESUPUESTO APROBADO", this.hVentaColor.Value + ",VENTAS COLOCADAS"};
			string []BarrasValores=new string[3];
			string strValoresPPTOINI="";
			string strValoresPPTOAPRB="";
			string strValoresVTA="";
			string []EtiquetaValores=new string[5];

			foreach(DataRow dr in dt.Rows)
			{
				switch (Convert.ToInt32(dr["TIPOINFO"]))
				{
					case 1:
						strValoresPPTOINI = strValoresPPTOINI + dr["MONTO"].ToString() + ",";
						break;
					case 2:
						strValoresPPTOAPRB=strValoresPPTOAPRB + dr["MONTO"].ToString() + ",";
						break;
					case 4:
						strValoresVTA=strValoresVTA + dr["MONTO"].ToString() + ",";
						break;
				}
			}
			int idx=0;
			DataTable dtDistinct = Helper.SelectDistinct(dt,"PERIODO");
			foreach(DataRow dr in dtDistinct.Rows)
			{
				EtiquetaValores[idx] = dr["Periodo"].ToString();
				idx++;
			}
			string []Leyenda=new string[]{"","","PERIODO " + EtiquetaValores[0].ToString() + " - " + EtiquetaValores[EtiquetaValores.Length-1].ToString() };
			BarrasValores[0]=strValoresPPTOINI.Substring(0,strValoresPPTOINI.Length-1);
			BarrasValores[1]=strValoresPPTOAPRB.Substring(0,strValoresPPTOAPRB.Length-1);
			BarrasValores[2]=strValoresVTA.Substring(0,strValoresVTA.Length-1);

			string []ArchivoyRuta =Helper.Graph(TipoGrafico,"ANALISIS VENTAS REALES VS. PRESUPUESTO",Leyenda,EtiquetaValores,Barras,BarrasValores);
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
			// TODO:  Add GraficoVentasVSPresupuestoPorPeriodo.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add GraficoVentasVSPresupuestoPorPeriodo.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add GraficoVentasVSPresupuestoPorPeriodo.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add GraficoVentasVSPresupuestoPorPeriodo.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			DataTable dt = new DataTable();
			if(Convert.ToInt32(Page.Request.Params[KEYOPTIONGRAFICO])==1)
			{
				dt =  (new CVentasPresupuestadas()).ConsultarPresupuestoVSVentasporPeriodo(this.Periodo,this.idVersion);
			}
			if((Convert.ToInt32(Page.Request.Params[KEYOPTIONGRAFICO])==2)||(Convert.ToInt32(Page.Request.Params[KEYOPTIONGRAFICO])==3))
			{
				dt =  (new CVentasPresupuestadas()).ConsultarAnalisisVentasRealesVSPresupuestoPorPeriodo(this.Periodo);
			}

			if(dt != null)
			{
				if(Convert.ToInt32(Page.Request.Params[KEYOPTIONGRAFICO])==1)
				{
					this.GraficarOpcion1(dt);
				}
				if(Convert.ToInt32(Page.Request.Params[KEYOPTIONGRAFICO])==2)
				{
					this.GraficarBarrarOLinea(dt,Utilitario.Enumerados.TiposGraficoEstadistico.Barra);	
				}
				if(Convert.ToInt32(Page.Request.Params[KEYOPTIONGRAFICO])==3)
				{
					this.GraficarBarrarOLinea(dt,Utilitario.Enumerados.TiposGraficoEstadistico.Linea);	
				}
				
			}
			else
			{
				this.lblResultado.Visible = true;
				this.lblResultado.Text = GRILLAVACIA;
			}

		}

		public void LlenarJScript()
		{
			// TODO:  Add GraficoVentasVSPresupuestoPorPeriodo.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add GraficoVentasVSPresupuestoPorPeriodo.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add GraficoVentasVSPresupuestoPorPeriodo.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add GraficoVentasVSPresupuestoPorPeriodo.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add GraficoVentasVSPresupuestoPorPeriodo.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add GraficoVentasVSPresupuestoPorPeriodo.ValidarFiltros implementation
			return false;
		}

		#endregion
	}
}
