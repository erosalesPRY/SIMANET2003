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

using SIMA.Utilitario;
using NetAccessControl;
using SIMA.ManejadorExcepcion;
using SIMA.Log;

namespace SIMA.SimaNetWeb.GestionFinanciera.PresupuestoVarios
{
	/// <summary>
	/// Summary description for ConsultarPresupuestodePersonal.
	/// </summary>
	public class ConsultarPresupuestodePersonal : System.Web.UI.Page,IPaginaBase
	{
		#region Constantes
			const string KEYQIDEMPRESA = "idEmp";
			const string KEYQIDCENTRO = "idCentro";
			const string NOMBRECENTRO ="NombreCentro";
			//Tipo de Opcion Contable o Presupuestal
			const string KEYIDTIPOOPCION ="idOpcion";
			const string NOMBRETIPOOPCION ="NombreOpcion";
			const string KEYQIDFECHA = "efFecha";

			const string KEYQIDFORMATO = "IdFormato";
			const string KEYQIDNOMBREFORMATO = "NFormato";
			const string KEYQIDREPORTE = "IdReporte";
			const string KEYQIDRUBRO = "IdRubro";
			const string KEYQIDPERIDO = "Periodo";
			const string KEYQIDMES = "Mes";
			const string KEYQIDNOMBREMES = "NombreMes";

		//DataGrid and DataTable
		const string COLUMNAPERIODO ="Periodo";

		#endregion
		#region Controles
			protected System.Web.UI.WebControls.Label lblRutaPagina;
			protected System.Web.UI.WebControls.Label lblPagina;
			protected System.Web.UI.WebControls.Label Label3;
			protected System.Web.UI.WebControls.DropDownList ddlbPeriodo;
			protected System.Web.UI.WebControls.Label Label2;
			protected System.Web.UI.WebControls.DropDownList dddblMes;
			protected projDataGridWeb.DataGridWeb grid;
			protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion
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
				ltlMensaje.Text = Helper.MensajeAlert(oSIMAExcepcionLog.Mensaje);					
			}
			catch(SIMAExcepcionIU oSIMAExcepcionIU)
			{
				ltlMensaje.Text = Helper.MensajeAlert(oSIMAExcepcionIU.Mensaje);					
			}
			catch(SIMAExcepcionDominio oSIMAExcepcionDominio)
			{
				ltlMensaje.Text = Helper.MsgdbErrMostrarMesaje(true,oSIMAExcepcionDominio.Error.ToString());					
			}
			catch(Exception oException)
			{
				string debug = oException.Message.ToString();
				SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
				Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
			}
			// Put user code to initialize the page here
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
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			DateTime Fecha = Convert.ToDateTime(DateTime.DaysInMonth(Convert.ToInt32(this.ddlbPeriodo.SelectedValue),Convert.ToInt32(this.dddblMes.SelectedValue)) + Utilitario.Constantes.SEPARADORFECHA + this.dddblMes.SelectedValue + Utilitario.Constantes.SEPARADORFECHA + this.ddlbPeriodo.SelectedValue);
			CPresupuesto oCPresupuesto = new CPresupuesto();

//			DataTable dtEstadoFinanciero = oCPresupuesto.ConsultarPresupuestoGastosdePersonal(
//														Fecha.ToShortDateString()
//														,Page.Request.Params[KEYQIDEMPRESA]
//														,Page.Request.Params[KEYQIDCENTRO]
//														,Utilitario.Constantes.KEYIDFORMATOINGRESOSYEGRESOS
//														,Page.Request.Params[KEYQIDREPORTE]
//														,Utilitario.Constantes.IDDEFAULT);

			DataTable dtEstadoFinanciero = oCPresupuesto.ConsultarPresupuestoGastosdePersonal(
				Fecha
				,Convert.ToInt32(Page.Request.Params[KEYQIDEMPRESA])
				,Convert.ToInt32(Page.Request.Params[KEYQIDCENTRO])
				,Utilitario.Constantes.KEYIDFORMATOINGRESOSYEGRESOS
				,Convert.ToInt32(Page.Request.Params[KEYQIDREPORTE])
				,Utilitario.Constantes.IDDEFAULT);
			
			if(dtEstadoFinanciero!=null)
			{
				grid.DataSource = dtEstadoFinanciero;
			}
			else
			{
				grid.DataSource = dtEstadoFinanciero;
			}
			grid.DataBind();			
			// TODO:  Add ConsultarPresupuestodePersonal.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarPresupuestodePersonal.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add ConsultarPresupuestodePersonal.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			this.LlenarPeriodoContable();
			// TODO:  Add ConsultarPresupuestodePersonal.LlenarCombos implementation
		}
		private void LlenarPeriodoContable()
		{
			CPeriodoContable oCPeriodoContable = new CPeriodoContable();
			ddlbPeriodo.DataSource = oCPeriodoContable.ListarPeriodo();
			ddlbPeriodo.DataValueField=COLUMNAPERIODO;
			ddlbPeriodo.DataTextField=COLUMNAPERIODO;
			ddlbPeriodo.DataBind();
			if((Page.Request.Params[Utilitario.Constantes.KeyQPaginaValorInicial] != null)  && Page.Request.Params[Utilitario.Constantes.KeyQPaginaValorInicial].ToString() == Utilitario.Constantes.KeyQPaginaValor)
			{
				ListItem item;
				item = ddlbPeriodo.Items.FindByText(DateTime.Now.Year.ToString());
				if (item !=null){item.Selected = true;}

				item = dddblMes.Items.FindByValue(DateTime.Now.Month.ToString());
				if (item !=null){item.Selected = true;}
			}	
			else
			{
				Helper.SeleccionarItemCombos(this);
			}
			
		}

		public void LlenarDatos()
		{
			// TODO:  Add ConsultarPresupuestodePersonal.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarPresupuestodePersonal.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarPresupuestodePersonal.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarPresupuestodePersonal.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarPresupuestodePersonal.Exportar implementation
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
			// TODO:  Add ConsultarPresupuestodePersonal.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				if(Convert.ToInt32(dr[Enumerados.ColumnasFormato.FlgVerMonto.ToString()]) == Utilitario.Constantes.ValorConstanteCero ) 
				{
					//e.Item.Cells[1].Text = "";e.Item.Cells[2].Text = "";e.Item.Cells[3].Text = "";e.Item.Cells[4].Text = "";e.Item.Cells[5].Text = "";e.Item.Cells[6].Text = "";
				}
				else
				{

				}
				
				if (Convert.ToInt32(dr[Enumerados.ColumnasFormato.IdTipoLinea.ToString()]) != Utilitario.Constantes.ValorConstanteCero)
				{
					e.Item.BackColor = Color.LightYellow;
					e.Item.Font.Bold = true;
				}
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
			}
		}
	}
}
