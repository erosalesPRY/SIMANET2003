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
	/// Summary description for ListarResponsableSAMs.
	/// </summary>
	public class ListarResponsableSAMs : System.Web.UI.Page,IPaginaBase
	{
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();	
					this.LlenarJScript();
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(), "Gestión de Personal: Administrar Becados", this.ToString(),"Se consultó El Listado de las Capacitaciones en el Extranjero.",Enumerados.NivelesErrorLog.I.ToString()));
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

		private DataTable ObtenerDatos()
		{
			return (new CSAMResponsable()).ListarTodosporJefatura();
		}

		public void LlenarGrilla()
		{
			DataTable dt = this.ObtenerDatos();

			if (dt!=null)
			{
				grid.DataSource = dt;

			}
			else
			{
				grid.DataSource = dt;
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
			// TODO:  Add ListarResponsableSAMs.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add ListarResponsableSAMs.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add ListarResponsableSAMs.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add ListarResponsableSAMs.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add ListarResponsableSAMs.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ListarResponsableSAMs.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ListarResponsableSAMs.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ListarResponsableSAMs.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add ListarResponsableSAMs.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ListarResponsableSAMs.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				Helper.UIControls.DataGrid.CHiperLink((DataGrid)sender, e.Item.Cells[0]);
				Image imgF = (Image) e.Item.Cells[1].FindControl("imgFoto");
				imgF.CssClass="imgCircular";

				imgF.ImageUrl=Helper.ObtenerFotoPersonal(dr["NroPersonal"].ToString());
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);

				

			}		
		}
	}
}
