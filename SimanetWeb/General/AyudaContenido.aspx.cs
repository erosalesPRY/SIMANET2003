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
using SIMA.Controladoras;
using SIMA.Controladoras.General;
using SIMA.EntidadesNegocio;
using SIMA.EntidadesNegocio.General;
using  SIMA.Utilitario;
namespace SIMA.SimaNetWeb.General
{
	/// <summary>
	/// Summary description for AyudaContenido.
	/// </summary>
	public class AyudaContenido : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlInputHidden hPaginaPath;
		const string KEYQIDAYUDA= "IDHELP";
		protected System.Web.UI.WebControls.PlaceHolder PlaceHolder1;
		const string KEYQIDITEM= "IDITEM";

		private void Page_Load(object sender, System.EventArgs e)
		{
			TablaTablas oTablaTablasBE = (TablaTablas) (new CTablaTablas()).ListarDetalle(Convert.ToInt32(Page.Request.Params[KEYQIDAYUDA].ToString()),Convert.ToInt32(Page.Request.Params[KEYQIDITEM].ToString()));
			//hPaginaPath.Value=oTablaTablasBE.Observaciones;
			System.Web.UI.HtmlControls.HtmlGenericControl oIframe = new System.Web.UI.HtmlControls.HtmlGenericControl("iframe"); 
			oIframe.Attributes["id"]="of" + Page.Request.Params[KEYQIDITEM].ToString();
			oIframe.Attributes["src"]=oTablaTablasBE.Observaciones;
			oIframe.Attributes["frameborder"] = "0"; 
			oIframe.Attributes["scrolling"] = "auto"; 
			oIframe.Attributes["height"]="100%";
			oIframe.Attributes["width"]="100%";
			this.PlaceHolder1.Controls.Add(oIframe);
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
