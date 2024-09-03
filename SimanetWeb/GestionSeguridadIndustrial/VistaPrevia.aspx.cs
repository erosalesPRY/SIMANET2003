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
using SIMA.Utilitario;
using NetAccessControl;

namespace SIMA.SimaNetWeb.GestionSeguridadIndustrial
{
	/// <summary>
	/// Summary description for VistaPrevia.
	/// </summary>
	public class VistaPrevia : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Image imgPrevio;
		private string ArchivoImg
		{
			get{return Page.Request.Params["imgPrevio"].ToString();}
		}
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			this.imgPrevio.ImageUrl = Helper.Configuracion.SeguridadIndustrial.Antecedentes.HttpDirFile + this.ArchivoImg;
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
