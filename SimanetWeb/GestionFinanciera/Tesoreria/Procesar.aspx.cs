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
using SIMA.Controladoras;
using SIMA.Controladoras.General;
using SIMA.Controladoras.GestionFinanciera;
using SIMA.Controladoras.Legal;
using SIMA.EntidadesNegocio.GestionFinanciera;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;
using System.Runtime.InteropServices;


namespace SIMA.SimaNetWeb.GestionFinanciera.Tesoreria
{
	/// <summary>
	/// Summary description for Procesar.
	/// </summary>
	public class Procesar : System.Web.UI.Page
	{
		const string PROCESO ="idProceso";
		const int KEYQPRCCONSULTARCTACTE =174;
		const int KEYQPRCLISTARPAGOS =175;
		const int KEYQPRCACTESTADOCHEQUE =176;

		const int KEYQPRCLISTADISEÑOCHEQUE =178;
		const int KEYQPRCCHEQUEACTBENEFICIARIO =179;



		const string KEYQCODENTIDAD ="CodEnt";
		const string KEYQCUENTACORRIENTE="CtaCte";
		const string KEYQMONEDA="Moneda";
		const string KEYQNROCHEQUE="NroCheque";
		const string KEYQNROFOLIO="NroFolio";
		const string KEYQYYMMDD="yymmdd";
		const string KEYQIDESTADO="Est";
		const string KEYQBENEFICIARIO="Benef";

		const string KEYQPERIODO = "Periodo";
		const string KEYQTIPOPAGO="TipPago";


		//Para la impresion de cheques
		const string  KEYQIDFORMATOCHEQUE="FmtCheque";


		


		const string KEYQLSTCHEQUES="LstCheques";
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				if (Page.Request.Params[PROCESO]!=null)
				{
					if(Convert.ToInt32(Page.Request.Params[PROCESO])==KEYQPRCCONSULTARCTACTE)
					{
						Helper.GenerarEsquemaXMLNTAD((new CTesoreria().ListarCtaCtePorEntidadesFinanciera(Page.Request.Params[KEYQCODENTIDAD].ToString(),Page.Request.Params[KEYQMONEDA].ToString())));
					}
					else if(Convert.ToInt32(Page.Request.Params[PROCESO])==KEYQPRCLISTARPAGOS)
					{
						Helper.GenerarEsquemaXMLNTAD((new CTesoreria().ListadodePagos(Page.Request.Params[KEYQMONEDA].ToString(),Page.Request.Params[KEYQPERIODO].ToString(),Page.Request.Params[KEYQCODENTIDAD].ToString(),Page.Request.Params[KEYQCUENTACORRIENTE].ToString(),Convert.ToInt32(Page.Request.Params[KEYQTIPOPAGO].ToString()))));
					}
					else if(Convert.ToInt32(Page.Request.Params[PROCESO])==KEYQPRCACTESTADOCHEQUE )
					{
						BancoCtaCteChequeBE oBancoCtaCteChequeBE = new  BancoCtaCteChequeBE();
						oBancoCtaCteChequeBE.CodigoBanco = Page.Request.Params[KEYQCODENTIDAD].ToString();
						oBancoCtaCteChequeBE.CodigoCtaCte = Page.Request.Params[KEYQCUENTACORRIENTE].ToString();
						oBancoCtaCteChequeBE.NroCheque = Page.Request.Params[KEYQNROCHEQUE].ToString();
						oBancoCtaCteChequeBE.NroFolio = Page.Request.Params[KEYQNROFOLIO].ToString();
						oBancoCtaCteChequeBE.Moneda = Page.Request.Params[KEYQMONEDA].ToString();
						oBancoCtaCteChequeBE.Yymmdd = Page.Request.Params[KEYQYYMMDD].ToString();
						oBancoCtaCteChequeBE.IdImpreso = Convert.ToInt32( Page.Request.Params[KEYQIDESTADO].ToString());
						Helper.GenerarEsquemaXMLTAD((new CTesoreria()).Modificar(oBancoCtaCteChequeBE));
					}
					else if(Convert.ToInt32(Page.Request.Params[PROCESO])==KEYQPRCLISTADISEÑOCHEQUE )
					{
						DataTable dt = (new CTesoreria()).ListarDiseñoCheque(Convert.ToInt32(Page.Request.Params[KEYQIDFORMATOCHEQUE]));
						if(dt!=null)
						{
							Helper.GenerarEsquemaXMLNTAD(dt);
						}

					}
					else if(Convert.ToInt32(Page.Request.Params[PROCESO])==KEYQPRCCHEQUEACTBENEFICIARIO )
					{
						BancoCtaCteChequeBE oBancoCtaCteChequeBE = new  BancoCtaCteChequeBE();
						oBancoCtaCteChequeBE.Año = Convert.ToInt32(Page.Request.Params[KEYQYYMMDD].ToString());
						oBancoCtaCteChequeBE.CodigoBanco = Page.Request.Params[KEYQCODENTIDAD].ToString();
						oBancoCtaCteChequeBE.NroFolio = Page.Request.Params[KEYQNROFOLIO].ToString();
						oBancoCtaCteChequeBE.Moneda = Page.Request.Params[KEYQMONEDA].ToString();
						oBancoCtaCteChequeBE.Beneficiario =  Helper.HttpUtility.HtmlDecode(Page.Request.Params[KEYQBENEFICIARIO].ToString());
						oBancoCtaCteChequeBE.CodigoCtaCte = Page.Request.Params[KEYQCUENTACORRIENTE].ToString();
						Helper.GenerarEsquemaXMLTAD((new CTesoreria()).ModificarBeneficiario(oBancoCtaCteChequeBE));
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
