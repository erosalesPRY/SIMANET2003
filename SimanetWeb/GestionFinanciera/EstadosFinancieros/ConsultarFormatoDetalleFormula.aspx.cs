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
using SIMA.Controladoras.General;
using SIMA.Controladoras.GestionFinanciera;
using SIMA.EntidadesNegocio.GestionFinanciera;
using SIMA.Utilitario;
using NetAccessControl;
using SIMA.ManejadorExcepcion;
using SIMA.Log;


namespace SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancieros
{
	/// <summary>
	/// Summary description for ConsultarFormatoDetalleFormula.
	/// </summary>
	public class ConsultarFormatoDetalleFormula : System.Web.UI.Page,IPaginaBase
	{
		#region Constantes
			//Key Session y QueryString
			const string KEYQIDFORMATO = "IdFormato";
			const string KEYQIDREPORTE = "IdReporte";
			const string KEYQIDCENTRO = "IdCentro";
			const string KEYQIDRUBRO = "IdRubro";
			const string KEYQRUBRONOMBRE= "RubroNombre";
			const string KEYQIDTIPOINFO= "idTipoInfo";
			const string KEYQPERIODO = "Periodo";
			const string KEYQMES = "idMes";
		#endregion
		#region Propiedades
			public int IdFormato
			{
				get{return Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO].ToString());}
			}
			public int IdRubro
			{
				get{return Convert.ToInt32(Page.Request.Params[KEYQIDRUBRO].ToString());}
			}
			public int IdCentroOperativo
			{
				get{return Convert.ToInt32(Page.Request.Params[KEYQIDCENTRO].ToString());}
			}
			public int Periodo
			{
				get{return Convert.ToInt32(Page.Request.Params[KEYQPERIODO].ToString());}
			}
			public int IdMes
			{
				get{return Convert.ToInt32(Page.Request.Params[KEYQMES].ToString());}
			}
			public int IdTipoInformacion
			{
				get{return Convert.ToInt32(Page.Request.Params[KEYQIDTIPOINFO].ToString());}
			}
		#endregion
		protected projDataGridWeb.DataGridWeb grid;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarGrillaOrdenamientoPaginacion(Utilitario.Constantes.VACIO,Utilitario.Constantes.INDICEPAGINADEFAULT);
				}
				catch(SIMAExcepcionLog oSIMAExcepcionLog)
				{
					Helper.MsgBox(oSIMAExcepcionLog.Mensaje);					
				}
				catch(SIMAExcepcionIU oSIMAExcepcionIU)
				{
					Helper.MsgBox(oSIMAExcepcionIU.Mensaje);					
				}
				catch(SIMAExcepcionDominio oSIMAExcepcionDominio)
				{
					Helper.MsgBox(oSIMAExcepcionDominio.Error.ToString());
				}
				catch(Exception oException)
				{
					string mensaje = oException.Message.ToString();
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
			// TODO:  Add ConsultarFormatoDetalleFormula.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarFormatoDetalleFormula.LlenarGrillaOrdenamiento implementation
		}
		DataTable ObtenerDatos(){
			return (new CEstadosFinancieros()).ConsultarMovimientoFormatoFormula(this.IdFormato,this.IdRubro,this.IdCentroOperativo,this.Periodo,this.IdMes,this.IdTipoInformacion);
		}

		double []DTTotal;
		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dt = this.ObtenerDatos();
			grid.DataSource = dt;
			if(dt!=null){
				DTTotal = Helper.TotalizarDataView(dt.DefaultView,"MontoMes");
			}
			try
			{
				grid.DataBind();
			}
			catch(Exception ex)
			{
				Helper.JavaScript.MsgBox("PRESUPUESTO",ex.Message.ToString());
			}			
		}

		public void LlenarCombos()
		{
			// TODO:  Add ConsultarFormatoDetalleFormula.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add ConsultarFormatoDetalleFormula.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarFormatoDetalleFormula.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarFormatoDetalleFormula.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarFormatoDetalleFormula.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarFormatoDetalleFormula.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add ConsultarFormatoDetalleFormula.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ConsultarFormatoDetalleFormula.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;			
				e.Item.Cells[2].Text =  Convert.ToDouble(e.Item.Cells[2].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);

			}
			else if(e.Item.ItemType == ListItemType.Footer){
				e.Item.Cells[1].Text ="TOTAL GENERAL:";
				e.Item.Cells[2].Text = DTTotal[0].ToString(Utilitario.Constantes.FORMATODECIMAL4);
				
			}
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
