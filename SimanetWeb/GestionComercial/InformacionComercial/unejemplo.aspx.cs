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
using SIMA.Controladoras.GestionComercial;
using SIMA.Controladoras.General;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;

namespace SIMA.SimaNetWeb.GestionComercial.InformacionComercial
{
	/// <summary>
	/// Summary description for unejemplo.
	/// </summary>
	public class unejemplo : System.Web.UI.Page, IPaginaBase
	{
		private void Page_Load(object sender, System.EventArgs e)
		{
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		public void LlenarGrilla()
		{
//			return null;
		}		
		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
//			return null;
		}
		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
		{
//			return null;
		}
		public void LlenarCombos()
		{
//			return null;
		}
		public void LlenarDatos()
		{
//			return null;
		}
		public void LlenarJScript()
		{
//			return null;
		}
		public void RegistrarJScript()
		{
//			return null;
		}
		public void Imprimir()
		{
//			return null;
		}
		public void Exportar()
		{
//			return null;
		}
		public void ConfigurarAccesoControles()
		{
//			return null;
		}
		public bool ValidarFiltros()
		{
			return true;
		}

	}
}
