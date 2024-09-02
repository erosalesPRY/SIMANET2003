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
using SIMA.Controladoras.GestionEstrategica.Proyecto;
using SIMA.Controladoras.General;
using SIMA.Controladoras;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using NullableTypes;
using MetaBuilders.WebControls;


namespace SIMA.SimaNetWeb.GestionEstrategica.Proyecto
{
	/// <summary>
	/// Summary description for AdministrarComponentes.
	/// </summary>
	public class AdministrarComponentes : System.Web.UI.Page,IPaginaBase
	{
		protected System.Web.UI.WebControls.DataGrid gridComponente;
		const string KEYQIDPROYECTOPERFIL="IdProyPerf";

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
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
			this.gridComponente.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.gridComponente_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members
		private DataTable ObtenerDatos()
		{
			return (new CProyectoPerfilComponente()).ListarTodosGrilla(Page.Request.Params[KEYQIDPROYECTOPERFIL].ToString());
		}

		public void LlenarGrilla()
		{
			DataTable dt=this.ObtenerDatos();

			if(dt!=null)
			{
				gridComponente.DataSource = dt;
			}
			try
			{
				gridComponente.DataBind();
			}
			catch	
			{
				gridComponente.CurrentPageIndex = 0;
				gridComponente.DataBind();
			}		
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarComponentes.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add AdministrarComponentes.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add AdministrarComponentes.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add AdministrarComponentes.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add AdministrarComponentes.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarComponentes.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministrarComponentes.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarComponentes.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add AdministrarComponentes.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add AdministrarComponentes.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void gridComponente_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				TextBox tb = (TextBox) e.Item.Cells[0].FindControl("txtDescripcion");
				tb.Text =dr["Descripcion"].ToString();
				e.Item.Attributes["NMODO"]=dr["IdReg"].ToString();
				e.Item.Attributes["IDCOMPONENTE"]=dr["IdComponente"].ToString();
				e.Item.Attributes["IDPROYECTOPERFIL"]=Page.Request.Params[KEYQIDPROYECTOPERFIL].ToString();
				e.Item.Attributes["DESCRIPCION"]=dr["Descripcion"].ToString();

			}
		
		}
	}
}
