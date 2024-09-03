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


namespace SIMA.SimaNetWeb.GestionFinanciera.Presupuesto
{
	/// <summary>
	/// Summary description for ConsultarEvaluacionPresupuestalPorCentrodeCosto.
	/// </summary>
	public class ConsultarEvaluacionPresupuestalPorCentrodeCosto : System.Web.UI.Page,IPaginaBase
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
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidMes;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
	
		private void Page_Load(object sender, System.EventArgs e)
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add ConsultarEvaluacionPresupuestalPorCentrodeCosto.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarEvaluacionPresupuestalPorCentrodeCosto.LlenarGrillaOrdenamiento implementation
		}

		private DataTable ObtenerDatos()
		{
			CPresupuesto oCPresupuesto = new  CPresupuesto();
			DataTable tblResultado =oCPresupuesto.ConsultarEvaluacionPrespuestalPorCentrosdeCosto3Dig(
				Page.Request.Params[KEYQTIPOPRESUPUESTO].ToString()
				,Convert.ToInt32(Page.Request.Params[KEYQIDCENTROOPERATIVO])
				,Convert.ToInt32(Page.Request.Params[KEYQIDGRUPOCC])
				,Convert.ToInt32(Page.Request.Params[KEYQIDCENTROCOSTO])
				,Convert.ToInt32(Page.Request.Params[KEYQPERIODO])
				,Convert.ToInt32(Page.Request.Params[KEYQMES])
				);
			return tblResultado;
		}
		private void TotalPresupuesto(DataTable dt)
		{
			ArrayList arrTotal = new ArrayList();
			arrTotal.Add((Helper.TotalizarDataView(dt.DefaultView,"MontoPresupuestado"))[0]);
			arrTotal.Add((Helper.TotalizarDataView(dt.DefaultView,"MontoEjecutado"))[0]);
			arrTotal.Add((Helper.TotalizarDataView(dt.DefaultView,"MontoSaldo"))[0]);
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
			// TODO:  Add ConsultarEvaluacionPresupuestalPorCentrodeCosto.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			int idMes;
			idMes = DateTime.Now.Month <6?6:DateTime.Now.Month;
			this.hidMes.Value = idMes.ToString();//Convert.ToInt32(SIMA.Utilitario.Helper.FechaSimanet.ObtenerFechaSesion().Month.ToString());
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarEvaluacionPresupuestalPorCentrodeCosto.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarEvaluacionPresupuestalPorCentrodeCosto.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarEvaluacionPresupuestalPorCentrodeCosto.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarEvaluacionPresupuestalPorCentrodeCosto.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add ConsultarEvaluacionPresupuestalPorCentrodeCosto.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ConsultarEvaluacionPresupuestalPorCentrodeCosto.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			int idMes = Convert.ToInt32(this.hidMes.Value);
			if (idMes >=7)
			{
				int NroColOcultar =  (idMes -6);
				for(int i=3;i<= NroColOcultar;i++)
				{
					e.Item.Cells[i].Style.Add("display","none");
				}
				
				if (idMes<12)
				{
					for(int i=(idMes+1);i<=12;i++)
					{
						e.Item.Cells[i].Style.Add("display","none");
					}
				}
			}
			else
			{
				for(int i=7+3;i<=12+3;i++)
				{
					e.Item.Cells[i].Style.Add("display","none");
				}
			}


			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				e.Item.Attributes.Add("CuentaContable3Dig",dr["CuentaContable3Dig"].ToString());
				e.Item.Cells[0].Controls.Add(Helper.CrearNodoRaiz(e,dr["CuentaContableGrupo"].ToString() + "-" + e.Item.Cells[0].Text,"ObtenerDetalleaNiveldeCuenta5Dig" ,true));

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				/*for(int i=1;i<=12;i++)
				{
					e.Item.Cells[i].Text = Convert.ToDouble(e.Item.Cells[i].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				}
				e.Item.Cells[13].Text = Convert.ToDouble(e.Item.Cells[13].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				*/
			}		
			if(e.Item.ItemType == ListItemType.Footer)
			{
				/*string []ArrTitleFooter = new string[] {"NATURALEZA DE GASTO", "ENERO", "FEBRERO","MARZO","ABRIL","MAYO","JUNIO","JULIO","AGOSTO","SETIEMBRE","OCTUBRE","NOVIEMBRE","DICIEMBRE","TOTAL"};
				for(int i=0;i<=ArrTitleFooter.Length-1;i++)
				{
					e.Item.Cells[i].Text =ArrTitleFooter[i].ToString();
				}*/
			}
		
		}
	}
}
