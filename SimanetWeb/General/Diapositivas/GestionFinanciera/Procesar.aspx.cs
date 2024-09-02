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

using SIMA.Controladoras.General;
using SIMA.Controladoras.GestionFinanciera;
using SIMA.EntidadesNegocio.GestionFinanciera;
using SIMA.EntidadesNegocio.General;

namespace SIMA.SimaNetWeb.General.Diapositivas.GestionFinanciera
{
	/// <summary>
	/// Summary description for Procesar.
	/// </summary>
	public class Procesar : System.Web.UI.Page
	{
		#region Constantes de Procesos
			const int PRC_OBTENERRESUMENGASTO=310;
		#endregion
		/*const string KEYQLSTCONCEPTO="LstCon";
		public string ListConceptos {
			get{return Page.Request.Params[KEYQLSTCONCEPTO].ToString();}
		}*/
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(Utilitario.Helper.General.Params.IdProceso==PRC_OBTENERRESUMENGASTO){
					
				string strIn  ="(" + Utilitario.Helper.GestionFinanciera.Params.ListaConceptosIn + ")";
				DataTable dt = (new  CEstadosFinancierosDirectorio()).ListarFormatoAnual(Utilitario.Helper.GestionFinanciera.Params.IdFormato,Utilitario.Helper.GestionFinanciera.Params.IdReporte, Utilitario.Helper.GestionFinanciera.Params.IdCentroOperativo ,Utilitario.Helper.GestionFinanciera.Params.Periodo,Utilitario.Helper.GestionFinanciera.Params.IdMes,Utilitario.Helper.GestionFinanciera.Params.IdTipoInformacion);
				if(dt!=null)
				{
					DataView dv = dt.DefaultView;
					dv.RowFilter="IdRubro in" + strIn ;

					Utilitario.Helper.GenerarEsquemaXMLNTAD(Utilitario.Helper.DataViewTODataTable(dv));
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
