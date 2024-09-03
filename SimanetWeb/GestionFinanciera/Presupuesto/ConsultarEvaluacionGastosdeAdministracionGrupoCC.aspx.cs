using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using SIMA.SimaNetWeb.InterfacesIU;
using SIMA.Controladoras;
using SIMA.Controladoras.General;
using SIMA.Controladoras.GestionFinanciera;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;
using System.Drawing.Printing;


namespace SIMA.SimaNetWeb.GestionFinanciera.Presupuesto
{

	public class ConsultarEvaluacionGastosdeAdministracion : System.Web.UI.Page,IPaginaBase
	{
		#region Constantes
			const string URLCENTROSDECOSTO="DefaultCentrosdeCosto.aspx?";

			const string GRILLAVACIA="No existe Datos";
			const string KEYQTIPOPRESUPUESTO ="idtp";
			const string CENTROOPERATIVO = "idCentro";
			const string KEYQCENTROOPERATIVONOMBRE = "NombreCentro";
			const string PERIODO = "Periodo";
			const string MES = "Mes";
			const string DIGCTA = "digCta";
			const string KEYQMODO = "Modo";
			const string VISTAPPTOPRINCIPAL="Principales";
			const string KEYQPPTO = "VISTAPPTO";
			const string KEYQVISTA="Vista";

			const int EVALUACIONPRESPUESTALLISTARCENTROSDECOSTO=7;
			const string KEYQIDGRUPOCC = "idGrpCC";
			const string KEYQNOMBREGRUPOCC = "NombreGrpCC";
			const string KEYQTIPOOPCION = "Opcion";

			const string KEYQUIENLLAMA = "QLlama";
			const string KEYTIPOINFORMACION = "TipoInfo";

			//Nombre de controles lbl 
			const string LBLHPRESUPUESTO= "lblHPPTO";
			const string LBLHEJECUTADO= "lblHEjecutado";

			const string LBLPRESUPUESTO= "lblPrespuesto";
			const string LBLEJECUTADO= "lblEjecutado";
			const string LBLSALDO= "lblSaldo";
			
			string Cta="";
			const string SESSTOTALIZA = "Totaliza";

			const string URLPAGINAEVALUACIONMENSUAL="ConsultarGastosMensualPorGrupodeCC.aspx?";
	#endregion
		#region Controles

		protected System.Web.UI.WebControls.Label lblSimaPeru;
		protected System.Web.UI.WebControls.Label lblPresupuestoP;
		protected System.Web.UI.WebControls.Label lblEjecutadoP;
		protected System.Web.UI.WebControls.Label lblSaldoP;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label lblPresupuestoI;
		protected System.Web.UI.WebControls.Label lblEjecutadoI;
		protected System.Web.UI.WebControls.Label lblSaldoI;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.ImageButton imgResumen;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarJScript();
					this.LlenarDatos();
					this.LlenarCombos();
					this.LlenarGrillaOrdenamientoPaginacion(String.Empty,Constantes.INDICEPAGINADEFAULT);	
				}
				catch(SIMAExcepcionLog oSIMAExcepcionLog)
				{
					ltlMensaje.Text = Helper.MensajeAlert(oSIMAExcepcionLog.Mensaje);					
				}
				catch(SIMAExcepcionIU oSIMAExcepcionIU)
				{
					ltlMensaje.Text = Helper.MensajeAlert(oSIMAExcepcionIU.Mensaje);					
				}
				catch(SIMAExcepcionDominio oSIMAExcepcionDominio)
				{
					ltlMensaje.Text = Helper.MensajeAlert(oSIMAExcepcionDominio.Error);					
				}
				catch(Exception oException)
				{
					string msgb =oException.Message.ToString();
					SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
					Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
				}
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
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.imgResumen.Click += new System.Web.UI.ImageClickEventHandler(this.imgResumen_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add ConsultarEvaluacionGastosdeAdministracion.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarEvaluacionGastosdeAdministracion.LlenarGrillaOrdenamiento implementation
		}
		private DataTable ObtenerDatos()
		{
			if (Page.Request.Params[KEYQPPTO].ToString()==VISTAPPTOPRINCIPAL)
			{
				return ((CPresupuesto) new  CPresupuesto()).ConsultarEvaluacionPrespuestalPorGruposdeCentrosdeCosto(Page.Request.Params[KEYQTIPOPRESUPUESTO].ToString()
																												,Convert.ToInt32(Page.Request.Params[CENTROOPERATIVO])
																												,Convert.ToInt32(Page.Request.Params[PERIODO])
																												,Convert.ToInt32(Page.Request.Params[MES])
																												,Convert.ToInt32(Page.Request.Params[KEYQTIPOOPCION]));
			}
			else
			{

				return ((CPresupuesto) new  CPresupuesto()).ConsultarEvaluacionPrespuestalPorGruposdeCentrosdeCostoAuxiliar(Page.Request.Params[KEYQTIPOPRESUPUESTO].ToString()
																														,Convert.ToInt32(Page.Request.Params[CENTROOPERATIVO])
																														,Convert.ToInt32(Page.Request.Params[PERIODO])
																														,Convert.ToInt32(Page.Request.Params[MES])
																														,Convert.ToInt32(Page.Request.Params[KEYQTIPOOPCION]));			
			}
		}
		private void TotalPresupuesto(DataTable dt)
		{
			ArrayList arrTotal = new ArrayList();
			if (Page.Request.Params[KEYQUIENLLAMA]!=null)
			{
				arrTotal.Add((Helper.TotalizarDataView(dt.DefaultView,"MontoPresupuestadoMes"))[0]);
				arrTotal.Add((Helper.TotalizarDataView(dt.DefaultView,"MontoEjecutadoMes"))[0]);
				arrTotal.Add((Helper.TotalizarDataView(dt.DefaultView,"MontoSaldoMes"))[0]);
			}
			else
			{
				arrTotal.Add((Helper.TotalizarDataView(dt.DefaultView,"MontoPresupuestado"))[0]);
				arrTotal.Add((Helper.TotalizarDataView(dt.DefaultView,"MontoEjecutado"))[0]);
				arrTotal.Add((Helper.TotalizarDataView(dt.DefaultView,"MontoSaldo"))[0]);
			}
			Session[SESSTOTALIZA]=arrTotal;
		}


		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dtGeneral = this.ObtenerDatos();
			if(dtGeneral!=null)
			{
				this.TotalPresupuesto(dtGeneral);
				grid.DataSource = dtGeneral;
				lblResultado.Visible = false;
			}
			else
			{
				grid.DataSource = dtGeneral;
				lblResultado.Text = GRILLAVACIA;
			}
			try
			{
				grid.DataBind();
			}
			catch	
			{
				grid.CurrentPageIndex = 0;
				grid.DataBind();
			}
		}

		public void LlenarCombos()
		{
			// TODO:  Add ConsultarEvaluacionGastosdeAdministracion.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
		}

		public void LlenarJScript()
		{
			//this.imgResumen.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,"LLamarPaginaProcesar();"+ Helper.HistorialIrAdelantePersonalizado(this.grid.ID.ToString()));
			this.imgResumen.Attributes[Utilitario.Constantes.EVENTOCLICK]= "LLamarPaginaProcesar()";
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarEvaluacionGastosdeAdministracion.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarEvaluacionGastosdeAdministracion.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarEvaluacionGastosdeAdministracion.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add ConsultarEvaluacionGastosdeAdministracion.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ConsultarEvaluacionGastosdeAdministracion.ValidarFiltros implementation
			return false;
		}

		#endregion

	

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			string CadParaEEGGPP = ((Page.Request.Params[KEYQUIENLLAMA]!=null)?KEYQUIENLLAMA + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYQUIENLLAMA].ToString():"");

			if(e.Item.ItemType == ListItemType.Header)
			{
				Label lblHPPTO = (Label)e.Item.Cells[2].FindControl(LBLHPRESUPUESTO);
				lblHPPTO.Font.Size=8;
				lblHPPTO.Style.Add(Utilitario.Constantes.CURSOR,Utilitario.Constantes.TIPOCURSORMANO);
				lblHPPTO.Font.Underline=true;
				lblHPPTO.Font.Bold = true;

				Label lbl = (Label)e.Item.Cells[2].FindControl(LBLHEJECUTADO);
				lbl.Font.Size=8;
				lbl.Style.Add(Utilitario.Constantes.CURSOR,Utilitario.Constantes.TIPOCURSORMANO);
				lbl.Font.Underline=true;
				lbl.Font.Bold = true;
				string PARAMETROS = CadParaEEGGPP
									+ KEYQTIPOPRESUPUESTO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYQTIPOPRESUPUESTO].ToString()
									+ Utilitario.Constantes.SIGNOAMPERSON
									+ CENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[CENTROOPERATIVO].ToString()
									+ Utilitario.Constantes.SIGNOAMPERSON
									+ KEYQCENTROOPERATIVONOMBRE + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYQCENTROOPERATIVONOMBRE].ToString()
									+ Utilitario.Constantes.SIGNOAMPERSON
									+ PERIODO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[PERIODO].ToString()
									+ Utilitario.Constantes.SIGNOAMPERSON
									+ MES + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[MES].ToString()
									+ Utilitario.Constantes.SIGNOAMPERSON
									+ KEYQTIPOOPCION + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYQTIPOOPCION].ToString()
									+ Utilitario.Constantes.SIGNOAMPERSON
									+ KEYQPPTO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYQPPTO].ToString()
									+ Utilitario.Constantes.SIGNOAMPERSON
									+ KEYQMODO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYQMODO].ToString()
									+ Utilitario.Constantes.SIGNOAMPERSON;


				lbl.Attributes.Add(Utilitario.Constantes.EVENTOCLICK.ToString(),Helper.MostrarVentana(URLPAGINAEVALUACIONMENSUAL,PARAMETROS + KEYTIPOINFORMACION + Utilitario.Constantes.SIGNOIGUAL +"real"));

				lblHPPTO.Attributes.Add(Utilitario.Constantes.EVENTOCLICK.ToString(),Helper.MostrarVentana(URLPAGINAEVALUACIONMENSUAL,PARAMETROS + KEYTIPOINFORMACION + Utilitario.Constantes.SIGNOIGUAL +"ppto"));

			}
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				
				Label lbl;
				lbl = (Label) e.Item.Cells[2].FindControl(LBLPRESUPUESTO);
				lbl.Text = ((Page.Request.Params[KEYQUIENLLAMA]!=null)? 
						Convert.ToDouble(dr["MontoPresupuestadoMes"].ToString()).ToString(Utilitario.Constantes.FORMATODECIMAL4) 
						:Convert.ToDouble(dr["MontoPresupuestado"].ToString()).ToString(Utilitario.Constantes.FORMATODECIMAL4));
				lbl = (Label) e.Item.Cells[2].FindControl(LBLEJECUTADO);
				lbl.Text = ((Page.Request.Params[KEYQUIENLLAMA]!=null)? 
						Convert.ToDouble(dr["MontoEjecutadoMes"].ToString()).ToString(Utilitario.Constantes.FORMATODECIMAL4)
						:Convert.ToDouble(dr["MontoEjecutado"].ToString()).ToString(Utilitario.Constantes.FORMATODECIMAL4));
				lbl = (Label) e.Item.Cells[2].FindControl(LBLSALDO);
				lbl.Text = ((Page.Request.Params[KEYQUIENLLAMA]!=null)? 
						Convert.ToDouble(dr["MontoSaldoMes"].ToString()).ToString(Utilitario.Constantes.FORMATODECIMAL4)
						:Convert.ToDouble(dr["MontoSaldo"].ToString()).ToString(Utilitario.Constantes.FORMATODECIMAL4));

				string Parametros = CadParaEEGGPP
					                + Utilitario.Constantes.SIGNOAMPERSON
									+ KEYQTIPOPRESUPUESTO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYQTIPOPRESUPUESTO].ToString()
									+ Utilitario.Constantes.SIGNOAMPERSON
									+ KEYQPPTO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYQPPTO].ToString()
									+ Utilitario.Constantes.SIGNOAMPERSON
									+ CENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[CENTROOPERATIVO].ToString()
									+ Utilitario.Constantes.SIGNOAMPERSON
									+ KEYQCENTROOPERATIVONOMBRE + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYQCENTROOPERATIVONOMBRE].ToString()
									+ Utilitario.Constantes.SIGNOAMPERSON
									+ KEYQIDGRUPOCC + Utilitario.Constantes.SIGNOIGUAL + dr["idGrupoCC"].ToString()
									+ Utilitario.Constantes.SIGNOAMPERSON
									+ KEYQNOMBREGRUPOCC + Utilitario.Constantes.SIGNOIGUAL + dr["NombreGrupo"].ToString()
									+ Utilitario.Constantes.SIGNOAMPERSON
									+ KEYQTIPOOPCION + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYQTIPOOPCION].ToString()
									+ Utilitario.Constantes.SIGNOAMPERSON
									+ PERIODO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[PERIODO].ToString()
									+ Utilitario.Constantes.SIGNOAMPERSON
									+ MES + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[MES].ToString()
									+ Utilitario.Constantes.SIGNOAMPERSON
									+ KEYQMODO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYQMODO].ToString()
									+ Utilitario.Constantes.SIGNOAMPERSON
									+ KEYQVISTA + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYQVISTA].ToString();

				int idModo = ((Page.Request.Params[KEYQUIENLLAMA]!=null)?1:2);
				lbl = (Label) e.Item.Cells[0].FindControl("LblCod");
				lbl.Text = dr["NroGrupoCC"].ToString();
				Helper.ConfiguraColumnaHyperLink(Utilitario.Enumerados.EventosJavaScript.OnClick,lbl,"Grupo",Helper.HistorialIrAdelantePersonalizado("") + Helper.MostrarVentana(URLCENTROSDECOSTO,Parametros,idModo));
				

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);

			}
			if(e.Item.ItemType == ListItemType.Footer)
			{
				Utilitario.Helper.FooterSpan(sender,e,0,2,3);
				e.Item.Cells[0].Text="TOTAL";
				ArrayList arrTotal = (ArrayList)Session[SESSTOTALIZA];
				Label lbl;
				lbl = (Label)e.Item.Cells[2].FindControl(LBLPRESUPUESTO+"F");
				lbl.Text = Convert.ToDouble(arrTotal[0]).ToString(Constantes.FORMATODECIMAL4);
				lbl = (Label)e.Item.Cells[2].FindControl(LBLEJECUTADO+"F");
				lbl.Text = Convert.ToDouble(arrTotal[1]).ToString(Constantes.FORMATODECIMAL4);
				lbl = (Label)e.Item.Cells[2].FindControl(LBLSALDO+"F");
				lbl.Text = Convert.ToDouble(arrTotal[2]).ToString(Constantes.FORMATODECIMAL4);
				Session[SESSTOTALIZA]=null;
			}
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void imgResumen_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			/*switch(Page.Request.Params[KEYQTIPOPRESUPUESTO].ToString())
			{
				case "1":if(Page.Request.Params[CENTROOPERATIVO].ToString()=="1"){ Cta="96";}
						 else {Cta="97";} 
					break;
				case "2":Cta = "92";
					break;

			}
			
			Helper.EjecutarReporte(@"C:\SimanetReportes\GestionFinanciera\Presupuesto\Meses\"
				,"ResumenEvaluacionPptal_PorNaturaleza.rpt"
				,(new CPresupuesto()).ConsultarResumenEvaluacionPresupuestalPorNaturaleza(Convert.ToInt32(Page.Request.Params[PERIODO]),Cta)
				,false);*/
		}
	}
}
