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
using System.Configuration;
namespace SIMA.SimaNetWeb.GestionEstrategica.Proyecto
{
	/// <summary>
	/// Summary description for IMGVistaPrevia.
	/// </summary>
	public class IMGVistaPrevia : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Image imgPrevio;
		private string HTTPPathFilePIP
		{
			get{return ConfigurationSettings.AppSettings["RutaHTTPProyectoInversion"].ToString();}
		}
		private string ArchivoImg
		{
			get{return Page.Request.Params["imgPrevio"].ToString();}
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			this.imgPrevio.ImageUrl = this.HTTPPathFilePIP + this.ArchivoImg;
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
