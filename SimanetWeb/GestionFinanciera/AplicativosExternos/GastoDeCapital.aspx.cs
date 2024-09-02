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
using SIMA.Log;
using SIMA.Utilitario;
using SIMA.Controladoras.Secretaria.Directorio;

namespace SIMA.SimaNetWeb.GestionFinanciera.AplicativosExternos
{
	/// <summary>
	/// Summary description for GastoDeCapital.
	/// </summary>
	public class GastoDeCapital : System.Web.UI.Page
	{
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			//string url= Request.QueryString["url"];
			//Response.Write("<script>window.open('http://10.32.0.252:8090/','_blank');</script>");
			//Response.Write("<script>window.history.back();</script>");
			
			if (Request.QueryString["url"] != null)
			{
				string url= Request.QueryString["url"];
				Response.Write("<script>window.open(url,'_blank');</script>");
				Response.Write("<script>window.history.back();</script>");
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

	}
}
