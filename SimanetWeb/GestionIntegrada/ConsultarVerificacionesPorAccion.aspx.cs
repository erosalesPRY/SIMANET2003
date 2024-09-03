using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using SIMA.SimaNetWeb.InterfacesIU;
using SIMA.Controladoras.GestionIntegrada;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;

namespace SIMA.SimaNetWeb.GestionIntegrada
{
	/// <summary>
	/// Summary description for ConsultarVerificacionesPorAccion.
	/// </summary>
	public class ConsultarVerificacionesPorAccion : System.Web.UI.Page,IPaginaBase
	{
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdDestino;
	
		const string GRILLAVACIA="No existen datos";
		const string KEYQIDACCION="IdAccion";
		const string KEYQGRPACCIONVERIFICA = "IdGRPAV";

		private string IdAccion
		{
			get{return Page.Request.Params[KEYQIDACCION];}
		}
		private string IdGrupoAccionVerificacion
		{
			get{return Page.Request.Params[KEYQGRPACCIONVERIFICA];}
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();	
					Helper.ReiniciarSession();
					this.LlenarJScript();
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(), "Gestión Integrada: Listado de Verificacioones", this.ToString(),"Se ha consultado las verificaciones por cada Acción Correctiva i/o Preventiva.",Enumerados.NivelesErrorLog.I.ToString()));
					this.LlenarGrilla();

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
					Helper.MsgBox(oSIMAExcepcionDominio.Mensaje);					
				}
				catch(Exception oException)
				{
					string msg = oException.Message.ToString();
					SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Utilitario.Constantes.CODIGOERRORGENERICO,oException.Message);
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
			DataTable dt = this.ObtenerDatos();

			if (dt!=null)
			{
				grid.DataSource = dt;
				this.lblResultado.Visible = false;
			}
			else
			{
				grid.DataSource = dt;
				this.lblResultado.Visible = true;
				this.lblResultado.Text    = GRILLAVACIA;
			}
			
			try
			{
				grid.DataBind();
			}
			catch (Exception exception)
			{
				string mensaje = exception.Message.ToString();
				grid.DataBind();
			}		
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarVerificacionesPorAccion.LlenarGrillaOrdenamiento implementation
		}
		private DataTable ObtenerDatos()
		{
			return (new CSAMVerificacion()).ListarTodosGrilla(this.IdGrupoAccionVerificacion);
		}
		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
		}

		public void LlenarCombos()
		{
			// TODO:  Add ConsultarVerificacionesPorAccion.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add ConsultarVerificacionesPorAccion.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarVerificacionesPorAccion.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarVerificacionesPorAccion.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarVerificacionesPorAccion.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarVerificacionesPorAccion.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add ConsultarVerificacionesPorAccion.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ConsultarVerificacionesPorAccion.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				Helper.UIControls.DataGrid.CHiperLink((DataGrid)sender, e.Item.Cells[0],"");
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
			}
		}
	}
}
