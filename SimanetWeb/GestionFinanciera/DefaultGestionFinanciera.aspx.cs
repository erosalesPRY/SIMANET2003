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
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
namespace SIMA.SimaNetWeb
{
	/// <summary>
	/// Summary description for RequerimientosAsignados.
	/// </summary>
	public class DefaultGestionFinanciera: System.Web.UI.Page,IPaginaBase	
	{
		protected System.Web.UI.WebControls.Label lblTexto;
		
					
				
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				this.ConfigurarAccesoControles();
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

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add Default.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add Default.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add Default.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add Default.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add Default.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add Default.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add Default.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			//ltlMensaje.Text = Helper.PopupImpresion(URLIMPRESION,650,700,false,false,false,true,true);
			// TODO:  Add Default.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add Default.Exportar implementation
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
			// TODO:  Add Default.ValidarFiltros implementation
			return false;
		}

		#endregion
	}
}

