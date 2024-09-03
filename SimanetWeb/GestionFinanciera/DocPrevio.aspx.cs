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
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using NullableTypes;
using MetaBuilders.WebControls;



namespace SIMA.SimaNetWeb.GestionFinanciera
{
	/// <summary>
	/// Summary description for DocPrevio.
	/// </summary>
	public class DocPrevio : System.Web.UI.Page,IPaginaBase
	{
		#region Constantes
			const string KEYQIDREPORTE = "IDREP";
			const string KEYQIDITEM = "IDITEM";
			const string KEYQTOP ="TOP";
			
		//DataGrid and DataTable 
		const string COLUMNAIDITEM ="iditem";
		const string COLUMNAVALOR ="valor";
		const string COLUMNAESTILO ="ESTILO";

			private const string URLDETALLE="DocPrevioObjPropiedad.aspx";
		#endregion

		#region Controles
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion Controles
		private void Page_Load(object sender, System.EventArgs e)
		{
			this.LlenarDatos();
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					this.LlenarJScript();
					Helper.ReiniciarSession();
					
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionFinanciera",this.ToString(),"Se consultó Carta de Crédito.",Enumerados.NivelesErrorLog.I.ToString()));
				}
				catch(SIMAExcepcionLog oSIMAExcepcionLog)
				{
					ltlMensaje.Text = Helper.MensajeAlert(oSIMAExcepcionLog.Mensaje);					
				}
				catch(SIMAExcepcionIU oSIMAExcepcionIU)
				{
					ltlMensaje.Text = Helper.MensajeAlert(oSIMAExcepcionIU.Mensaje);					
				}
				catch(SIMAExcepcionDominio oSIMAExcepcionDominio)
				{
					ltlMensaje.Text = Helper.MensajeAlert(oSIMAExcepcionDominio.Mensaje);					
				}
				catch(Exception oException)
				{
					SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Utilitario.Constantes.CODIGOERRORGENERICO,oException.Message);
					Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
				}
			}		
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
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add DocPrevio.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DocPrevio.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DocPrevio.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add DocPrevio.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			CDocPrevioItem oCDocPrevioItem= new CDocPrevioItem();
			DataTable dtGeneral = oCDocPrevioItem.ListarItemsdeReporte(
																		Convert.ToInt32(Page.Request.Params[KEYQIDREPORTE])
																		,Utilitario.Constantes.IDDEFAULT);
			if(dtGeneral!=null)
			{
				foreach(DataRow dr in dtGeneral.Rows)
				{
					char Comilla = '"';
					string strDefDiv = Utilitario.Constantes.DEFOBJDIV.ToString().Replace("NOMBRE","DIV" + Page.Request.Params[KEYQIDREPORTE]+ Utilitario.Constantes.SIGNOARROBA + dr[COLUMNAIDITEM].ToString()).Replace("EVENTO","onmousedown='dragstart(this);' EVENTO").Replace("VALOR",dr[COLUMNAVALOR].ToString()).Replace("ESTILO","style=" + Comilla + dr[COLUMNAESTILO].ToString() + Comilla );
					string ObjDiv=strDefDiv.ToString().Replace("EVENTO","ondblclick=" + Comilla + "Propiedades('" + Page.Request.Params[KEYQIDREPORTE].ToString() + "','" + dr[COLUMNAIDITEM].ToString() + "');" + Comilla );
					Page.Response.Write(ObjDiv);
				}
			}
			// TODO:  Add DocPrevio.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add DocPrevio.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DocPrevio.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DocPrevio.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DocPrevio.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			if(CNetAccessControl.FindPage(Page.Request.Url.AbsolutePath.ToString()))
			{
				CNetAccessControl.LoadControls(this);
			}
			else
			{				
				CNetAccessControl.RedirectPageError();				
			}
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add DocPrevio.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void Button1_Click(object sender, System.EventArgs e)
		{
			this.RedireccionaPaginaDetalle();
		}
		private void RedireccionaPaginaDetalle()
		{
			string url = URLDETALLE + Utilitario.Constantes.SIGNOINTERROGACION + Utilitario.Constantes.KEYMODOPAGINA +  Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.N.ToString() 
				+ Utilitario.Constantes.SIGNOAMPERSON 
				+ KEYQIDREPORTE + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYQIDREPORTE].ToString() 
				+ Utilitario.Constantes.SIGNOAMPERSON
				+ KEYQIDITEM + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.ValorConstanteCero.ToString() 
				+ Utilitario.Constantes.SIGNOAMPERSON
				+ KEYQTOP + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.ValorConstanteCero.ToString();
			ltlMensaje.Text=Utilitario.Helper.PopupBusqueda(url,380,470,false);
			
		}
	}
}
