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



namespace SIMA.SimaNetWeb.General.Formato
{
	/// <summary>
	/// Summary description for AdministrarPrivilegiosAFormatos.
	/// </summary>
	public class AdministrarPrivilegiosAFormatos : System.Web.UI.Page,IPaginaBase
	{
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.DropDownList ddlCentroOperativo;

		const string KEYQIDFORMATO="idFormato";

		public int IdFormato{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO]);}
		}
	
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
				Helper.MsgBox(oSIMAExcepcionDominio.Mensaje);					
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		public DataTable ObtenerDatos()
		{
			return null;
		}
		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			DataTable dt=new DataTable();
			dt.Columns.Add(new DataColumn("Descripcion",System.Type.GetType("System.String")));
			object[] array = new object[1];
			array[0]="";
			dt.Rows.Add(array);

			if(dt!=null)
			{
				grid.DataSource =  dt;
			}
			else
			{
				grid.DataSource = dt;
			}
			grid.DataBind();		
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarPrivilegiosAFormatos.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add AdministrarPrivilegiosAFormatos.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			this.ddlCentroOperativo.DataSource=(new CCentroOperativo()).ListarTodosCombo();
			this.ddlCentroOperativo.DataTextField="Nombre";
			this.ddlCentroOperativo.DataValueField="IdCentroOperativo";
			this.ddlCentroOperativo.DataBind();
		}

		public void LlenarDatos()
		{
			// TODO:  Add AdministrarPrivilegiosAFormatos.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			this.ddlCentroOperativo.Attributes[Utilitario.Enumerados.EventosJavaScript.OnChange.ToString()]="CargarTipoInformacion(Page.Request.Params[KEYQIDFORMATO],Page.Request.Params[KEYQIDUSUARIO]);";
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarPrivilegiosAFormatos.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministrarPrivilegiosAFormatos.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarPrivilegiosAFormatos.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add AdministrarPrivilegiosAFormatos.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add AdministrarPrivilegiosAFormatos.ValidarFiltros implementation
			return false;
		}

		#endregion
	}
}
