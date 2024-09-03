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
	/// Summary description for ConsultarGastosMensualPorCentrodeCosto.
	/// </summary>
	public class ConsultarGastosMensualPorCentrodeCosto : System.Web.UI.Page,IPaginaBase
	{
		#region constantes
		const string GRILLAVACIA="No existe Datos";
		const string PROCESO ="idProceso";//Indicador de Proceso 
		const string KEYQTIPOPRESUPUESTO ="idtp";
		const string KEYQIDCENTROOPERATIVO="idCentro";
		const string KEYQIDCENTROOPERATIVOP="idcop";//CentroOPerativo de la pagina de Procesos
		const string KEYQCENTROOPERATIVONOMBRE = "NombreCentro";
		const string KEYQIDGRUPOCC = "idGrpCC";
		const string KEYQIDCENTROCOSTO ="idCC";	
		const string KEYQPERIODO ="Periodo";
		const string KEYQMES ="Mes";
		const string VISTAPPTOPRINCIPAL="Principales";
		const string KEYQPPTO = "VISTAPPTO";
		const string KEYQUIENLLAMA = "QLlama";
		const string KEYTIPOINFORMACION = "TipoInfo";//Sirve para mostrar la informacion mensualizada del presupuesto o real
		//
		const string LBLMONTOPPTO = "lblPrespuesto";
		const string LBLMONTOEJECUTADO = "lblEjecutado";
		const string LBLMONTOSALDO = "lblSaldo";
		const string LBLCENTRO = "lblEmpresa";

		
		const string SESSTOTALIZA = "Totaliza";
		#endregion

		protected System.Web.UI.WebControls.Label lblPagina;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hListadePersonal;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hPathFotos;
		protected System.Web.UI.WebControls.Literal ltlMensaje;

		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				this.ConfigurarAccesoControles();
				Helper.ReiniciarSession();
				Helper.ReestablecerPagina(this);
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
			// TODO:  Add ConsultarGastosMensualPorCentrodeCosto.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarGastosMensualPorCentrodeCosto.LlenarGrillaOrdenamiento implementation
		}
		private DataTable ObtenerDatos()
		{
			if (Page.Request.Params[KEYQPPTO].ToString()==VISTAPPTOPRINCIPAL)
			{
				return ((CPresupuesto)new  CPresupuesto()).ConsultarEvaluacionMensualPorCentrosdeCosto3Dig(
																										Page.Request.Params[KEYQTIPOPRESUPUESTO].ToString()
																										,Convert.ToInt32(Page.Request.Params[KEYQIDCENTROOPERATIVO])
																										,Convert.ToInt32(Page.Request.Params[KEYQIDGRUPOCC])
																										,Convert.ToInt32(Page.Request.Params[KEYQIDCENTROCOSTO])
																										,Convert.ToInt32(Page.Request.Params[KEYQPERIODO])
																										);
			}
			else
			{
				return ((CPresupuesto)new  CPresupuesto()).ConsultarEvaluacionMensualPorCentrosdeCosto3DigAuxiliar(
																											Page.Request.Params[KEYQTIPOPRESUPUESTO].ToString()
																											,Convert.ToInt32(Page.Request.Params[KEYQIDCENTROOPERATIVO])
																											,Convert.ToInt32(Page.Request.Params[KEYQIDGRUPOCC])
																											,Convert.ToInt32(Page.Request.Params[KEYQIDCENTROCOSTO])
																											,Convert.ToInt32(Page.Request.Params[KEYQPERIODO]));

			}
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dtGeneral = this.ObtenerDatos();
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

		public void LlenarCombos()
		{
			// TODO:  Add ConsultarGastosMensualPorCentrodeCosto.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add ConsultarGastosMensualPorCentrodeCosto.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarGastosMensualPorCentrodeCosto.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarGastosMensualPorCentrodeCosto.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarGastosMensualPorCentrodeCosto.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarGastosMensualPorCentrodeCosto.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add ConsultarGastosMensualPorCentrodeCosto.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ConsultarGastosMensualPorCentrodeCosto.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				e.Item.Attributes.Add("CuentaContable3Dig",dr["CuentaContable3Dig"].ToString());
				e.Item.Cells[0].Controls.Add(Helper.CrearNodoRaiz(e,dr["CuentaContableGrupo"].ToString() + "-" + e.Item.Cells[0].Text,"NodeItem_OnClick" ,true));
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				for(int i=1;i<=12;i++){
					e.Item.Cells[i].Text= Convert.ToDouble(e.Item.Cells[i].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				}

			}		
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
