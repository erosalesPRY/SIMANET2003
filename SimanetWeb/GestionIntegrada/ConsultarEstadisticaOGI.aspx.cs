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

namespace SIMA.SimaNetWeb.GestionIntegrada
{
	/// <summary>
	/// Summary description for ConsultarEstadisticaOGI.
	/// </summary>
	public class ConsultarEstadisticaOGI : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox txtCodigo;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.DropDownList ddlTipoAuditoria;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.DropDownList ddlCentroOperativo;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox CalFechaDesde;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.TextBox CalFechaHasta;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.TextBox txtArea;
		protected System.Web.UI.WebControls.Label Label13;
		protected eWorld.UI.CalendarPopup CalFechaInicio;
		protected eWorld.UI.TimePicker tmHoraInicio;
		protected System.Web.UI.WebControls.Label Label18;
		protected eWorld.UI.CalendarPopup CalFechaTermino;
		protected eWorld.UI.TimePicker tmHoraTermino;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.HtmlControls.HtmlTableRow fHorario;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidArea;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hFechaTermino;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hFechaInicio;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hFechaActual;
		protected System.Web.UI.HtmlControls.HtmlImage btnAceptar;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnCancelar;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
	
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
