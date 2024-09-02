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
using SIMA.EntidadesNegocio.General;

using SIMA.Utilitario;
using NetAccessControl;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using System.IO;


namespace SIMA.SimaNetWeb.General.Formato
{
	/// <summary>
	/// Summary description for AdministrarRelacionFormatoRubroNotaContab.
	/// </summary>
	public class AdministrarRelacionFormatoRubroNotaContab : System.Web.UI.Page,IPaginaBase
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.TextBox txtBuscarNota;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				if(!Page.IsPostBack)
				{
					this.ConfigurarAccesoControles();
					this.LlenarJScript();
					this.LlenarCombos();
					//this.CargarModoPagina();
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
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			DataTable dt=new DataTable();
			dt.Columns.Add(new DataColumn("Codigo",System.Type.GetType("System.String")));
			dt.Columns.Add(new DataColumn("Descripcion",System.Type.GetType("System.String")));
		//	dt.Columns.Add(new DataColumn("Descripcion",System.Type.GetType("System.String")));
			object[] array = new object[2];
			array[0]="";
			array[1]="";
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
			// TODO:  Add AdministrarRelacionFormatoRubroNotaContab.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add AdministrarRelacionFormatoRubroNotaContab.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add AdministrarRelacionFormatoRubroNotaContab.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add AdministrarRelacionFormatoRubroNotaContab.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add AdministrarRelacionFormatoRubroNotaContab.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarRelacionFormatoRubroNotaContab.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministrarRelacionFormatoRubroNotaContab.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarRelacionFormatoRubroNotaContab.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add AdministrarRelacionFormatoRubroNotaContab.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add AdministrarRelacionFormatoRubroNotaContab.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
