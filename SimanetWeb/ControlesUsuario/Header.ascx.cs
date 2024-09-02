using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using NetAccessControl; 


namespace SIMA.SimaNetWeb.ControlesUsuario
{
	/// <summary>
	///		Summary description for Header.
	/// </summary>
	public class Header : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.Image Image1;
	
		protected System.Web.UI.WebControls.Label lblUsuario;
		
				
		//string separador = Utilitario.Utilitario.SeparadorPalabras();


		
					
		private void Page_Load(object sender, System.EventArgs e)
		{
			//lblUsuario.Text=Convethis.cargarMenu();
		
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
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		
	}
}
