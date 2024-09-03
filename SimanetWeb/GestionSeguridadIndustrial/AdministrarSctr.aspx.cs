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
using SIMA.Controladoras.Personal;
using SIMA.Controladoras.GestionSeguridadIndustrial;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;


namespace SIMA.SimaNetWeb.GestionSeguridadIndustrial
{
	/// <summary>
	/// Summary description for AdministrarSctr.
	/// </summary>
	public class AdministrarSctr : System.Web.UI.Page,IPaginaBase
	{

		const string URLDETALLE = "DetalleSctr.aspx?";
		const string URLPROGRAMACIONTRABAJADORES="AdministrarSctrTrabajadores.aspx?";

		//const string KEYQIDPROG ="NroProg";
		//const string KEYQPROG ="Prog";
		//const string KEYQPERIODO ="Periodo";
		//const string KEYQIDUSUARIOREG="idUsu";


		const string KEYQNRORUC ="NroRuc";
		const string KEYQRAZONSOCIAL ="RSocial";
		//const string KEYQFECHAINICIO ="FInicio";
		//const string KEYQFECHATERMINO ="FTermino";

		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPaginaSort;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo2;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hRazonSocial;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hNroRuc;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hFInicio;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hFTermino;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hModo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidUsuarioRegistro;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminaFiltro;
		protected System.Web.UI.WebControls.ImageButton ibtnProgramacionTrabajadores;
		protected System.Web.UI.WebControls.ImageButton ibtnAgregar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminar;
		protected System.Web.UI.WebControls.ImageButton imgBtnLstEquipos;

		#region Controles
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
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
