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
using NetAccessControl;

namespace SIMA.SimaNetWeb.GestionFinanciera
{
	/// <summary>
	/// Summary description for AdministrarPrivilegiosPorCentrosdeCosto.
	/// </summary>
	public class AdministrarPrivilegiosPorCentrosdeCosto : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.TextBox txtBuscar;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.TextBox txtBuscarTipoInformacion;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hPathFotos;
		protected System.Web.UI.WebControls.TextBox txtGrupoCentroCosto;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellContext;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnAtras;
		protected System.Web.UI.WebControls.DropDownList ddlCentroOperativo;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			hPathFotos.Value=  System.Configuration.ConfigurationSettings.AppSettings[Utilitario.Constantes.RUTAFOTOS];
			
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
			this.txtGrupoCentroCosto.TextChanged += new System.EventHandler(this.txtGrupoCentroCosto_TextChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void ddlGrupoCC_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void txtGrupoCentroCosto_TextChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
