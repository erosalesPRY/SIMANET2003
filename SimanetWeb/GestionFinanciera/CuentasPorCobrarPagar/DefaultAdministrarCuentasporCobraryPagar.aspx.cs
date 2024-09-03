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

namespace SIMA.SimaNetWeb.GestionFinanciera.CuentasPorCobrarPagar
{
	/// <summary>
	/// Summary description for DefaultAdministrarCuentasporCobraryPagar.
	/// </summary>
	public class DefaultAdministrarCuentasporCobraryPagar : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Panel Panel;
		protected System.Web.UI.WebControls.Button btnConsultar;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.HtmlControls.HtmlTable TblTabs;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPaginaSort;
	
		#region Constantes
			const string OBJPARAMETRO="ParamCtaCobrarPagar";
			const string URLCONTROLUSUARIOPARAMETROCONTABLE = "../../ControlesUsuario/GestionFinanciera/ParametroContable.ascx";
		#endregion
		private void Page_Load(object sender, System.EventArgs e)
		{
			this.CargarControl();
		}
		private void CargarControl()
		{			
			if (Session[OBJPARAMETRO]==null)
			{
				ControlesUsuario.GestionFinanciera.ParametroContable usc_ParametroContable = (ControlesUsuario.GestionFinanciera.ParametroContable)LoadControl(URLCONTROLUSUARIOPARAMETROCONTABLE);
				usc_ParametroContable.VerCentroOperativoPorPrivilegiosEnGeneral = true;
				usc_ParametroContable.VerPeriodo = true;
				usc_ParametroContable.VerMes = true;
				usc_ParametroContable.VerTipoInformacion = false;
				usc_ParametroContable.VerEntidadFinanciera=false;
				Panel.Controls.Clear();
				Panel.Controls.Add(usc_ParametroContable);
				Session[OBJPARAMETRO] = usc_ParametroContable;
			}
			else
			{
				ControlesUsuario.GestionFinanciera.ParametroContable usc_ParametroContable = (ControlesUsuario.GestionFinanciera.ParametroContable)Session[OBJPARAMETRO];
				usc_ParametroContable.VerCentroOperativoPorPrivilegiosEnGeneral = true;
				usc_ParametroContable.EnabledPeriodo=true;
				usc_ParametroContable.EnabledMes =true;				
				usc_ParametroContable.EnabledTipoInformacion=false;

				Panel.Controls.Clear();
				Panel.Controls.Add(usc_ParametroContable);
				Session[OBJPARAMETRO] = usc_ParametroContable;
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
