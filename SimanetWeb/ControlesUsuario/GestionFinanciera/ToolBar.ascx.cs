namespace SIMA.SimaNetWeb.ControlesUsuario.GestionFinanciera
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using SIMA.Utilitario;

	/// <summary>
	///		Summary description for ToolBar.
	/// </summary>
	public class ToolBar : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.ImageButton Imagebutton1;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltar;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
		}
		
		public void CargarDialogoFiltrar(System.Web.UI.Page Pagina,DataTable dt, string PaginaFiltro,params object []Campos)
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
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.ibtnFiltar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnFiltar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void ibtnFiltar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{

		}
	}
}
