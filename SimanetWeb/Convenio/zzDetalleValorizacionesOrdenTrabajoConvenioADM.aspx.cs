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
namespace SIMA.SimaNetWeb.Convenio
{
	/// <summary>
	/// Summary description for RequerimientosAsignados.
	/// </summary>
	public class DetalleValorizacionesOrdenTrabajoConvenioADM: System.Web.UI.Page	
	{
		protected System.Web.UI.WebControls.Label lblProyecto;
		protected System.Web.UI.WebControls.TextBox txtNroValorizacion;
		protected System.Web.UI.WebControls.Label lblPorcAvanceFisico;
		protected eWorld.UI.NumericBox nbPorcAvanceFisico;
		protected System.Web.UI.WebControls.Label lblNroValorizacion;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.TextBox txtProyecto;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.ImageButton ibtnCancelar;
		protected System.Web.UI.WebControls.Label lblTexto;
		
					
				
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			
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

		
	}
}

