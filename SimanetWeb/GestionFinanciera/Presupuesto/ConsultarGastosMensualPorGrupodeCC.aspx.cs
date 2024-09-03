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
	/// <summary>
	/// Summary description for ConsultarGastosMensualPorGrupodeCC.
	/// </summary>
	public class ConsultarGastosMensualPorGrupodeCC : System.Web.UI.Page,IPaginaBase
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

			const string KEYQMODODETALLE = "MODODETALLE";


			const int EVALUACIONPRESPUESTALLISTARCENTROSDECOSTO=7;
			const string KEYQIDGRUPOCC = "idGrpCC";
			const string KEYQNOMBREGRUPOCC = "NombreGrpCC";
			const string KEYQTIPOOPCION = "Opcion";
			const string KEYTIPOINFORMACION = "TipoInfo";//Sirve para mostrar la informacion mensualizada del presupuesto o real

			const string KEYQUIENLLAMA = "QLlama";

			const string SESSTOTALIZA = "Totaliza";
		#endregion


		protected System.Web.UI.WebControls.Label lblPagina;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Literal ltlMensaje;

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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add ConsultarGastosMensualPorGrupodeCC.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarGastosMensualPorGrupodeCC.LlenarGrillaOrdenamiento implementation
		}

		private DataTable ObtenerDatos()
		{
			if (Page.Request.Params[KEYQPPTO].ToString()==VISTAPPTOPRINCIPAL)
			{
				return ((CPresupuesto) new  CPresupuesto()).ConsultarEvaluacionPrespuestalMensualPorGruposdeCentrosdeCosto(Page.Request.Params[KEYQTIPOPRESUPUESTO].ToString()
																															,Convert.ToInt32(Page.Request.Params[CENTROOPERATIVO])
																															,Convert.ToInt32(Page.Request.Params[PERIODO])
																															,Convert.ToInt32(Page.Request.Params[KEYQTIPOOPCION])
																															,Page.Request.Params[KEYTIPOINFORMACION].ToString());
			}
			else
			{
				return ((CPresupuesto) new  CPresupuesto()).ConsultarEvaluacionMensualPorGruposdeCetrosdeCostoAuxiliar(Page.Request.Params[KEYQTIPOPRESUPUESTO].ToString()
																														,Convert.ToInt32(Page.Request.Params[CENTROOPERATIVO])
																														,Convert.ToInt32(Page.Request.Params[PERIODO])
																														,Convert.ToInt32(Page.Request.Params[KEYQTIPOOPCION])
																														,Page.Request.Params[KEYTIPOINFORMACION].ToString());
			}
		}


		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dtGeneral = GenerarRegistroResumen(this.ObtenerDatos());

			if(dtGeneral!=null)
			{
				//this.TotalPresupuesto(dtGeneral);
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

		DataTable GenerarRegistroResumen(DataTable dt){
			if(dt!=null)
			{
				string []Meses={"Enero","Febrero","Marzo","Abril","Mayo","Junio","Julio","Agosto","Setiembre","Octubre","Noviembre","Diciembre"};
				DataRow myDataRow = dt.NewRow();
				myDataRow["NombreGrupo"]="TOTAL"; 
				foreach(string mes in Meses)
				{
					myDataRow[mes] = (Helper.TotalizarDataView(dt.DefaultView,mes))[0];
				}
				dt.Rows.Add(myDataRow);
				dt.AcceptChanges();
			}
			return dt;
		}



		public void LlenarCombos()
		{
			// TODO:  Add ConsultarGastosMensualPorGrupodeCC.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add ConsultarGastosMensualPorGrupodeCC.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
	
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarGastosMensualPorGrupodeCC.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarGastosMensualPorGrupodeCC.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarGastosMensualPorGrupodeCC.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add ConsultarGastosMensualPorGrupodeCC.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ConsultarGastosMensualPorGrupodeCC.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				string CadParaEEGGPP = ((Page.Request.Params[KEYQUIENLLAMA]!=null)?KEYQUIENLLAMA + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYQUIENLLAMA].ToString():"");
				
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
					+ KEYTIPOINFORMACION + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYTIPOINFORMACION].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYQMODO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYQMODO].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYQMODODETALLE + Utilitario.Constantes.SIGNOIGUAL + "Mensual";

				int idModo = ((Page.Request.Params[KEYQUIENLLAMA]!=null)?1:2);
				Label lbl = (Label) e.Item.Cells[0].FindControl("lblCod");
				lbl.Text = dr["NroGrupoCC"].ToString();
				
				
				for(int i=1;i<=12;i++){
					e.Item.Cells[i+1].Text = Convert.ToDouble(e.Item.Cells[i+1].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);					
				}
				e.Item.Height=25;
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				if(e.Item.Cells[1].Text == "TOTAL")
				{
					e.Item.CssClass="FooterGrilla";
					e.Item.Height=30;
				}
				else{
					Helper.ConfiguraColumnaHyperLink(Utilitario.Enumerados.EventosJavaScript.OnClick,lbl,"Grupo",Helper.HistorialIrAdelantePersonalizado("") + Helper.MostrarVentana(URLCENTROSDECOSTO,Parametros,idModo));
				}

			}
		
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

	
	}
}
