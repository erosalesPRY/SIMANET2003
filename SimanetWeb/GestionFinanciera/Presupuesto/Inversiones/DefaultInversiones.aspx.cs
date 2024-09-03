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
using SIMA.SimaNetWeb.InterfacesIU;
using SIMA.Controladoras.General;
using SIMA.Controladoras.GestionFinanciera;
using SIMA.EntidadesNegocio.GestionFinanciera;
using SIMA.Utilitario;
using NetAccessControl;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using System.IO;

namespace SIMA.SimaNetWeb.GestionFinanciera.Presupuesto.Inversiones
{
	/// <summary>
	/// Summary description for DefaultInversiones.
	/// </summary>
	public class DefaultInversiones : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblCentroOperativo;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label lblNombreGrupoCC;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label lblPeriodo;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label lblMes;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.HtmlControls.HtmlTableCell tdHeader;
		protected System.Web.UI.HtmlControls.HtmlTableCell tdMenu;
		protected System.Web.UI.HtmlControls.HtmlTableCell tdCentro;
		protected System.Web.UI.HtmlControls.HtmlTableCell tdCentro1;
		protected System.Web.UI.WebControls.TextBox txtPeriodo;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label lblMesactual;
		protected System.Web.UI.WebControls.HyperLink HyperLink1;
		protected System.Web.UI.HtmlControls.HtmlTableRow trPeriodo;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			this.txtPeriodo.Text = DateTime.Now.Year.ToString();
			this.lblMesactual.Text= Helper.ObtenerNombreMes(DateTime.Now.Month,Utilitario.Enumerados.TipoDatoMes.NombreCompleto).ToUpper();
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
