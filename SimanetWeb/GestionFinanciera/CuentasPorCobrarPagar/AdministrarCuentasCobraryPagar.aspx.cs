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

namespace SIMA.SimaNetWeb.GestionFinanciera.CuentasPorCobrarPagar
{
	/// <summary>
	/// Summary description for AdministrarCuentasCobraryPagar.
	/// </summary>
	public class AdministrarCuentasCobraryPagar : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		#region Constants
			const string KEYQIDCENTRO="idCentro";
			const string KEYQPERIODO="Periodo";
			const string KEYQMES="Mes";
			const string KEYQTIPOFINFORMACION="idTipoInfo";
			const string KEYQDIGCUENTA="DigCta";

			const string CTRLNMONTO="nMonto";
			const string CAMPOCHIMBOTE = "SimaChimbote";
			const string CAMPOIQUITOS = "SimaIquitos";

			const string COLUMNAMODOEDITARCHIMBOTE ="ModoEdicionChimbote";
			const string COLUMNAMODOEDITARIQUITOS ="ModoEdicionIquitos";
			
			const string NOMBREOPCION ="NombreOP";
		#endregion
		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPaginaSort;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.LlenarJScript();
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarJScript();
					this.LlenarDatos();
					this.LlenarGrillaOrdenamientoPaginacion(this.hGridPaginaSort.Value,Convert.ToInt32(this.hGridPagina.Value));
					
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
					ltlMensaje.Text = Helper.MensajeAlert(oSIMAExcepcionDominio.Mensaje);					
				}
				catch(Exception oException)
				{
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
			// TODO:  Add AdministrarCuentasCobraryPagar.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarCuentasCobraryPagar.LlenarGrillaOrdenamiento implementation
		}

		private DataTable ObtenerDatos()
		{
			DataTable dt =  ((CCuentasporPagar) new CCuentasporPagar()).ConsultarCuentasporPagarCobrar3Digitos
				(Convert.ToInt32(Page.Request.Params[KEYQTIPOFINFORMACION])
				,Convert.ToInt32(Page.Request.Params[KEYQPERIODO])
				,Convert.ToInt32(Page.Request.Params[KEYQMES])
				,Page.Request.Params[KEYQDIGCUENTA].ToString()
				);
			return dt;
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dt = this.ObtenerDatos();

			if(dt!=null)
			{
				//this.Totalizar(dt);
				DataView dw = dt.DefaultView;
				
				dw.RowFilter = Helper.ObtenerFiltro();
				dw.Sort = columnaOrdenar ;
				grid.DataSource = dw;
				grid.CurrentPageIndex =indicePagina;
				/*resumen*/
				this.grid.DataSource = dw;
			}
			else
			{
				grid.DataSource = null;
				grid.DataSource = null;
				lblResultado.Text = "No existen Documentos por Pagar";
			}
			try
			{
				grid.DataBind();
				grid.DataBind();
			}
			catch	
			{
				grid.CurrentPageIndex = 0;
				grid.DataBind();
				grid.DataBind();
			}			
		}

		public void LlenarCombos()
		{
			// TODO:  Add AdministrarCuentasCobraryPagar.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			this.lblPagina.Text = "Administrar saldos de " + Page.Request.Params[NOMBREOPCION].ToString();
		}

		public void LlenarJScript()
		{
			// TODO:  Add AdministrarCuentasCobraryPagar.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarCuentasCobraryPagar.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministrarCuentasCobraryPagar.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarCuentasCobraryPagar.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			if(CNetAccessControl.FindPage(Page.Request.Url.AbsolutePath.ToString()))
			{
				CNetAccessControl.LoadControls(this);
			}
			else
			{
				string Mensaje = "Ud. no Cuenta son los privilegios necesarios para acceder a esta pagina \n por favor comunicarse con la persona responsable del modulo \n o llama a Anexo 1557 Oficina de Sistemas";
				//CNetAccessControl.RedirectPageError();
				Page.Response.Redirect("../../Error.aspx?" + Constantes.KEYQMENSAJEPAGINAERRROR + Utilitario.Constantes.SIGNOIGUAL + Mensaje);
			}
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add AdministrarCuentasCobraryPagar.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			// TODO:  Add AdministrarCuentasCobraryPagar.Agregar implementation
		}

		public void Modificar()
		{
			// TODO:  Add AdministrarCuentasCobraryPagar.Modificar implementation
		}

		public void Eliminar()
		{
			// TODO:  Add AdministrarCuentasCobraryPagar.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			// TODO:  Add AdministrarCuentasCobraryPagar.CargarModoPagina implementation
		}

		public void CargarModoNuevo()
		{
			// TODO:  Add AdministrarCuentasCobraryPagar.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			// TODO:  Add AdministrarCuentasCobraryPagar.CargarModoModificar implementation
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add AdministrarCuentasCobraryPagar.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add AdministrarCuentasCobraryPagar.ValidarCampos implementation
			return false;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add AdministrarCuentasCobraryPagar.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add AdministrarCuentasCobraryPagar.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				string COLUMNAMONTO = (Page.Request.Params[KEYQIDCENTRO].ToString()== Constantes.KEYIDCENTROCHIMBOTE.ToString())? CAMPOCHIMBOTE:CAMPOIQUITOS;
				string COLUMNAMODO = (Page.Request.Params[KEYQIDCENTRO].ToString()== Constantes.KEYIDCENTROCHIMBOTE.ToString())? COLUMNAMODOEDITARCHIMBOTE:COLUMNAMODOEDITARIQUITOS;

				e.Item.Attributes.Add("Modo",dr[COLUMNAMODO].ToString());
				e.Item.Attributes.Add("Monto",dr[COLUMNAMONTO].ToString());

				((eWorld.UI.NumericBox) e.Item.Cells[3].FindControl(CTRLNMONTO)).Text = Convert.ToDouble(dr[COLUMNAMONTO]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				((eWorld.UI.NumericBox) e.Item.Cells[3].FindControl(CTRLNMONTO)).Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnKeydown.ToString(),"EnfocarSiguienteCelda(this)");

				Helper.ConfiguraColumnaHyperLink(e.Item.Cells[0],grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
			}		
		}
	}
}
