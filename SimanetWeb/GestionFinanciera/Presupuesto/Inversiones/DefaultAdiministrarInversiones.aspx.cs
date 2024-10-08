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

namespace SIMA.SimaNetWeb.GestionFinanciera.Presupuesto.Inversiones
{
	/// <summary>
	/// Summary description for DefaultAdiministrarInversiones.
	/// </summary>
	public class DefaultAdiministrarInversiones : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.HtmlControls.HtmlTableCell tdHeader;
		protected System.Web.UI.HtmlControls.HtmlTableCell tdMenu;
		protected System.Web.UI.HtmlControls.HtmlTableCell tdCentro;
		protected System.Web.UI.HtmlControls.HtmlTableCell tdCentro1;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox txtPeriodo;
		protected System.Web.UI.WebControls.DropDownList ddlCentroOperativo;
		protected System.Web.UI.WebControls.DropDownList ddlGrupoCC;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.DropDownList ddlTipoInformacion;
		protected System.Web.UI.HtmlControls.HtmlTableRow trPeriodo;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
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
