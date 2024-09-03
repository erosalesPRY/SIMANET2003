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
using System.IO;

namespace SIMA.SimaNetWeb.GestionFinanciera.Presupuesto
{
	/// <summary>
	/// Summary description for AdministrarPresupuestoItemDetallePorCC.
	/// </summary>
	public class AdministrarPresupuestoItemDetallePorCC :BaseGestionFinanciera,IPaginaBase
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label LblPartida;
		protected projDataGridWeb.DataGridWeb grid;
		const string KEYQNOMBRECUENTA ="NombreCuenta";
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				if(!Page.IsPostBack)
				{
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarJScript();
					this.LlenarCombos();
					this.LlenarDatos();
					this.LlenarGrilla();
					
				}
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
				Helper.MsgBox(oSIMAExcepcionDominio.Error);					
			}
			catch(Exception oException)
			{
				string debug = oException.Message.ToString();
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
			DataTable dt = (new CPresupuestoItemDetalleRequerimientos()).ListarItemDetalle(this.Periodo,this.IdMes,this.NroCentroCosto,this.CuentaContable);
			grid.DataSource =  dt;
			grid.DataBind();
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarPresupuestoItemDetallePorCC.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add AdministrarPresupuestoItemDetallePorCC.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add AdministrarPresupuestoItemDetallePorCC.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			this.LblPartida.Text = Page.Request.Params[KEYQNOMBRECUENTA].ToString();
		}

		public void LlenarJScript()
		{
			// TODO:  Add AdministrarPresupuestoItemDetallePorCC.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarPresupuestoItemDetallePorCC.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministrarPresupuestoItemDetallePorCC.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarPresupuestoItemDetallePorCC.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add AdministrarPresupuestoItemDetallePorCC.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add AdministrarPresupuestoItemDetallePorCC.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.Header)
			{}
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				Helper.ConfiguraColumnaHyperLink(SIMA.Utilitario.Enumerados.EventosJavaScript.OnClick,e.Item.Cells[0],"MostrarDetalleRqr(this);");

				
				e.Item.Attributes["NROREQ"] = dr["NRO_REQ"].ToString();
				e.Item.Attributes["CODRCS"] = dr["COD_RCS"].ToString();
				e.Item.Attributes["CODCEO"] = dr["COD_CEO"].ToString();
				

				DropDownList ddlUM = (DropDownList) e.Item.Cells[2].FindControl("ddlUnidadMedida");
				ddlUM.DataSource = (new CPresupuestoItemDetalleRequerimientos()).ListarUnidaddeMedida();
				ddlUM.DataTextField = "des_umd";
				ddlUM.DataValueField = "und_med";
				ddlUM.DataBind();
				ddlUM.Items.Insert(0,(new ListItem("[Seleccionar...]","0")));
				ListItem LItem =  ddlUM.Items.FindByValue(dr["UND_MED"].ToString());
				ddlUM.Attributes["OldValue"] = dr["UND_MED"].ToString();
				if(LItem!=null){LItem.Selected=true;}
				

				TextBox tb =(TextBox) e.Item.Cells[3].FindControl("txtDMA");
				tb.Text = Convert.ToInt32(dr["CNT_DMA_AJU"].ToString()).ToString(); 
				tb.Attributes["OldValue"] = tb.Text;

				tb =(TextBox) e.Item.Cells[4].FindControl("txtDML");
				tb.Text = Convert.ToInt32(dr["CNT_DML_AJU"].ToString()).ToString(); 
				tb.Attributes["OldValue"] = tb.Text;
				

				tb =(TextBox) e.Item.Cells[5].FindControl("txtCantidad");
				tb.Text = Convert.ToInt32(dr["CNT_REQ_AJU"].ToString()).ToString(); 
				tb.Attributes["OldValue"] = tb.Text;

				tb =(TextBox) e.Item.Cells[6].FindControl("txtPU");
				//tb.Text = Convert.ToInt32(dr["PRC_UNT_AJU"].ToString().Trim()).ToString(); 
				tb.Text = dr["PRC_UNT_AJU"].ToString().Trim(); 
				tb.Attributes["OldValue"] = tb.Text;

				e.Item.Cells[8].Text =Convert.ToDouble(dr["TOT_AJU"].ToString().Trim()).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[9].Text =Convert.ToInt32(dr["CNT_EQU_AJU"].ToString().Trim()).ToString();

				e.Item.Cells[10].Text =dr["EST_ATL"].ToString();

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,"ObtenerIdRow(this);");
			}
		}
	}
}
