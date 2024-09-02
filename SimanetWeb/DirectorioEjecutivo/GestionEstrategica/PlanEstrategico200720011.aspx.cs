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

namespace SIMA.SimaNetWeb.DirectorioEjecutivo.GestionEstrategica
{
	/// <summary>
	/// Summary description for PlanEstrategico200720011.
	/// </summary>
	public class PlanEstrategico200720011 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.Button Button2;
		protected System.Web.UI.WebControls.Button Button3;
		protected System.Web.UI.WebControls.Button Button4;
		protected System.Web.UI.WebControls.Button Button5;
		protected System.Web.UI.WebControls.Button Button6;
		protected System.Web.UI.WebControls.Button Button7;
		protected System.Web.UI.WebControls.Button Button8;
		protected System.Web.UI.WebControls.Button Button9;
		protected System.Web.UI.WebControls.Button Button10;
		protected System.Web.UI.WebControls.Button Button11;
		protected System.Web.UI.WebControls.Button Button12;
		protected System.Web.UI.WebControls.Button Button13;
		protected System.Web.UI.WebControls.Button Button14;
		protected System.Web.UI.WebControls.Button Button15;
		protected System.Web.UI.WebControls.Button Button16;
		protected System.Web.UI.WebControls.Button Button17;
		protected System.Web.UI.WebControls.Button Button18;
		protected System.Web.UI.WebControls.Button Button19;
		protected System.Web.UI.WebControls.Button Button20;
		protected System.Web.UI.WebControls.Button Button22;
		protected System.Web.UI.WebControls.Button Button23;
		protected System.Web.UI.WebControls.Button Button24;
		protected System.Web.UI.WebControls.Button Button25;
		protected System.Web.UI.WebControls.Button Button26;
		protected System.Web.UI.WebControls.Button Button27;
		protected System.Web.UI.WebControls.Button Button28;
		protected System.Web.UI.WebControls.Button Button29;
		protected System.Web.UI.WebControls.Button Button30;
		protected System.Web.UI.WebControls.Button Button31;
		protected System.Web.UI.WebControls.Button Button32;
		protected System.Web.UI.WebControls.Button Button33;
		protected System.Web.UI.WebControls.Button Button34;
		protected System.Web.UI.WebControls.Button Button35;
		protected System.Web.UI.WebControls.Button Button36;
		protected System.Web.UI.WebControls.Button Button37;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Button Button38;
		protected System.Web.UI.WebControls.Button Button21;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!IsPostBack)
			{
					foreach (Control ctrl in Page.Controls)
			 {
				 if (ctrl is TextBox)
				 {
					 ((TextBox)(ctrl)).Attributes.Add("onclick","window.alert('Pagina en construccion')");
					
				 }	
			 }
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
			this.Button18.Click += new System.EventHandler(this.Button18_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Button18_Click(object sender, System.EventArgs e)
		{
		
		}
	}
}
