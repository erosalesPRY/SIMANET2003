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


namespace SIMA.SimaNetWeb.General
{
	/// <summary>
	/// Summary description for MostrarURLaspx.
	/// </summary>
	public class MostrarURLaspx : System.Web.UI.Page
	{
		#region controles

		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.ImageButton ibtnAtras;
		protected System.Web.UI.HtmlControls.HtmlGenericControl myContent;

		#endregion
	
		#region constantes

		//Key Session y QueryString
		
		const string URLPRINCIPAL= "../Default.aspx";
		const string URLRUTA="rutaURL";

		const string TITRUTAPAGINA = "tituloRUTAPAGINA";
		const string TITPAGINA = "tituloPAGINA";


		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				this.RedirecionarPagina();
			}
			// Put user code to initialize the page here
		}

		private void RedirecionarPagina()
		{
			lblRutaPagina.Text = Page.Request.QueryString[TITRUTAPAGINA].ToString();
			lblPagina.Text = Page.Request.QueryString[TITPAGINA].ToString();

			myContent.Attributes["src"] = Page.Request.QueryString[URLRUTA].ToString().ToUpper();
			myContent.Attributes["Height"]="380";
			myContent.Attributes["Width"]="600";
			myContent.DataBind();
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
			this.ibtnAtras.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAtras_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void ibtnAtras_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{

			this.redireccionaPaginaPrincipal();			
		}

		private void redireccionaPaginaPrincipal()
		{
			Page.Response.Redirect(URLPRINCIPAL);
		}

	}
}
