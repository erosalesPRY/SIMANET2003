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

namespace SIMA.SimaNetWeb.Editor
{
	/// <summary>
	/// Summary description for Editor.
	/// </summary>
	public class Editor : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlTextArea campo1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (Page.Request.Params[Utilitario.Constantes.KEYEDITORNOMBREOBJDESCRIPCION] !=null)
			{
				//this.campo1.InnerText = Page.Request.Params[Utilitario.Constantes.KEYEDITORNOMBREOBJDESCRIPCION].ToString();
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
