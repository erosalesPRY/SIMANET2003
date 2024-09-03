using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using SIMA.SimaNetWeb.InterfacesIU;
using SIMA.Controladoras.GestionIntegrada;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;

namespace SIMA.SimaNetWeb.GestionIntegrada
{
	/// <summary>
	/// Summary description for AdministrarCorreoDeConocimientoDeAccion.
	/// </summary>
	public class AdministrarCorreoDeConocimientoDeAccion : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid gridLst;
		//protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.CheckBox chkSelect;

		const string KEYQIDAREA= "IdArea";
		const string KEYQIDSAM="IdSAM";


	    private void Page_Load(object sender, System.EventArgs e)
		{
		if(!Page.IsPostBack)
		{
			try
			{
				this.LlenarGrilla();
			}
			catch(SIMAExcepcionLog oSIMAExcepcionLog)
			{
				Helper.MsgBox(oSIMAExcepcionLog.Mensaje);					
			}
			catch(SIMAExcepcionIU oSIMAExcepcionIU)
			{
				Helper.MsgBox(oSIMAExcepcionIU.Mensaje);					
			}
			catch(SIMAExcepcionDominio oSIMAExcepcionDominio)
			{
				Helper.MsgBox(oSIMAExcepcionDominio.Mensaje);					
			}
			catch(Exception oException)
			{
				string msg = oException.Message.ToString();
				SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Utilitario.Constantes.CODIGOERRORGENERICO,oException.Message);
				Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
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
			this.gridLst.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.gridLst_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		public void LlenarGrilla()
		{
			CSolicituddeAcciondeMejora oCSolicituddeAcciondeMejora = new CSolicituddeAcciondeMejora();
			DataTable dtLista = oCSolicituddeAcciondeMejora.ListarResponsables(Convert.ToInt32(Page.Request.Params[KEYQIDAREA]), Page.Request.Params[KEYQIDSAM].ToString());
			gridLst.DataSource=dtLista;
			gridLst.DataBind();
		}

		public void ConfigurarAccesoControles()
		{}

		private void gridLst_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				e.Item.Attributes["EMail"]=dr["EMail"].ToString();
				e.Item.Attributes["IDPERSONAL"]=dr["idPersonal"].ToString();
			}
		}
	}
}
