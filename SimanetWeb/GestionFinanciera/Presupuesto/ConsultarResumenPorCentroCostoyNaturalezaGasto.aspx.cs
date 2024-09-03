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
	/// Summary description for ConsultarResumenPorCentroCostoyNaturalezaGasto.
	/// </summary>
	public class ConsultarResumenPorCentroCostoyNaturalezaGasto : System.Web.UI.Page,IPaginaBase
	{

		const string KEYTIPOINFORMACION = "TipoInfo";
		const string GRILLAVACIA="No existe Datos";
		const string PERIODO = "Periodo";
        const string KEYQTIPOOPCION = "Opcion";
		const string KEYQTIPOPRESUPUESTO = "idtp";
		const string KEYQIDCENTROOPERATIVO = "idCentro";
		string Valor = "";
		string Cta = "";	

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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			
		}
		private DataTable ObtenerDatos()
		{
			
			switch(Page.Request.Params[KEYQTIPOPRESUPUESTO].ToString())
			{
				case "1":if(Page.Request.Params[KEYQIDCENTROOPERATIVO].ToString()=="1"){ Cta="96";}else {Cta="97";} 
					break;
				case "2":Cta = "92";
					break;

			}
			if (Page.Request.Params[KEYTIPOINFORMACION].ToString()=="ppto") /////SI es Presupuestado
			{

				return ((CPresupuesto) new  CPresupuesto()).ConsultarResumenPresupuestoPorCentroDeCostos(
					Convert.ToInt32(Page.Request.Params[PERIODO])
					,Cta);
			}
			else /// SI es REAL
			{
				return ((CPresupuesto) new  CPresupuesto()).ConsultarResumenGastosPorCentroDeCostos(
					Convert.ToInt32(Page.Request.Params[PERIODO])
					,Cta);
			}
		}
		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dtGeneral = this.ObtenerDatos();
			if(dtGeneral!=null)
			{				
				grid.DataSource = GenerarRegistroResumen(this.Filtrar(dtGeneral));
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
		public DataTable Filtrar(DataTable dt)
		{
			Valor = Cta + Page.Request.Params[KEYQTIPOOPCION].ToString();
			
			DataView dv = dt.DefaultView;
			dv.RowFilter = "Natcta ='"+Valor+"'";
			return Helper.DataViewTODataTable(dv);
			
		}
		DataTable GenerarRegistroResumen(DataTable dt)
		{
			if(dt!=null)
			{
				string []Meses={"Enero","Febrero","Marzo","Abril","Mayo","Junio","Julio","Agosto","Setiembre","Octubre","Noviembre","Diciembre"};
				DataRow myDataRow = dt.NewRow();
				myDataRow["Nombrecuenta"]="TOTAL"; 
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
			
		}

		public void LlenarDatos()
		{
			
		}

		public void LlenarJScript()
		{
			
		}

		public void RegistrarJScript()
		{
			
		}

		public void Imprimir()
		{
			
		}

		public void Exportar()
		{
			
		}

		public void ConfigurarAccesoControles()
		{
			
		}

		public bool ValidarFiltros()
		{
			
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				for(int i=1;i<=12;i++)
				{
					e.Item.Cells[i+1].Text = Convert.ToDouble(e.Item.Cells[i+1].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);					
				}
				e.Item.Height=20;
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				if(e.Item.Cells[1].Text == "TOTAL")
				{
					e.Item.CssClass="FooterGrilla";
					e.Item.Height=25;
				}	
			}
		}
	}
}
