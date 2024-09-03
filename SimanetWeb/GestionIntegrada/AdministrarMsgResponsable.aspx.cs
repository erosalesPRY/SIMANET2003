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
using SIMA.Controladoras.General;
using SIMA.EntidadesNegocio;
using SIMA.EntidadesNegocio.GestionIntegrada;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;
using System.Configuration;


namespace SIMA.SimaNetWeb.GestionIntegrada
{
	/// <summary>
	/// Summary description for AdministrarMsgResponsable.
	/// </summary>
	public class AdministrarMsgResponsable : System.Web.UI.Page,IPaginaBase
	{
		protected System.Web.UI.HtmlControls.HtmlGenericControl friends;
		protected System.Web.UI.HtmlControls.HtmlGenericControl chatmessages;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hRutaFoto;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hNroPersonalSEND;

		const string KEYQIDSAMISO = "IdSamISO";
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdUsuarioRegistro;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hEmailUsrSelected;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hNombreNormaISO;
		const string KEYQIDTIPONORMA = "TNorma";

		public string IdSamISO
		{
			get{return Page.Request.Params[KEYQIDSAMISO].ToString();}
		}
		public int IdTipoNorma
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDTIPONORMA].ToString());}
		}


	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();	
					Helper.ReiniciarSession();
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(), "Gestión de Personal: Administrar Becados", this.ToString(),"Se consultó El Listado de las Capacitaciones en el Extranjero.",Enumerados.NivelesErrorLog.I.ToString()));
					this.LlenarDatos();
					this.LlenarGrilla();
					this.LlenarJScript();

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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private DataTable ObtenerDatos()
		{
			return (new CSAMNota()).ListarResponsableMSG(this.IdSamISO);
		}

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			int NroFila=0;
			DataTable dt = this.ObtenerDatos();
			if (dt!=null)
			{
				foreach(DataRow dr in dt.Rows)
				{

					string UrlFoto = Helper.ObtenerFotoPersonal(dr["NroDocDNI"].ToString());
					/*string TagUser = "<div class=" + Utilitario.Constantes.SIGNOCOMILLADOBLE + "friend" + Utilitario.Constantes.SIGNOCOMILLADOBLE + ">"
						+ "		<IMG IDUSUARIORESP='" + dr["IdUsuario"].ToString()+ "' src=" + Utilitario.Constantes.SIGNOCOMILLADOBLE +  UrlFoto + Utilitario.Constantes.SIGNOCOMILLADOBLE + ">"
						+ "		<p>"
						+"			<strong>" + dr["ApellidosyNombres"].ToString() + "</strong><br>"
						+"			<span>" + dr["EMailResponsable"].ToString() + "</span><br>"
						+ "			<label>" + dr["Abrev"].ToString() + "</label>"
						+ "		</p>"
						+ "		<div class=" + Utilitario.Constantes.SIGNOCOMILLADOBLE + "status away" + Utilitario.Constantes.SIGNOCOMILLADOBLE + "></div>"
						+ "</div>";*/

					string TagUser = "<div class=" + Utilitario.Constantes.SIGNOCOMILLADOBLE + "friend" + Utilitario.Constantes.SIGNOCOMILLADOBLE + ">"
						+ "		<IMG NORMAISO='"  + dr["Abrev"].ToString() + "' EMAIL='" + dr["EMailResponsable"].ToString() + "' IDUSUARIORESP='" + dr["IdUsuario"].ToString()+ "' src=" + Utilitario.Constantes.SIGNOCOMILLADOBLE +  UrlFoto + Utilitario.Constantes.SIGNOCOMILLADOBLE + ">"
						+ "		<p>"
						+"			<strong>" + dr["ApellidosyNombres"].ToString() + "</strong><br>"
						+"			<span>" + dr["EMailResponsable"].ToString() + "</span><br>"
						+ "			<label>" + dr["Abrev"].ToString() + "</label>"
						+ "		</p>"
						+ "		<div class=" + Utilitario.Constantes.SIGNOCOMILLADOBLE + "status away" + Utilitario.Constantes.SIGNOCOMILLADOBLE + "></div>"
						+ "</div>";


					this.friends.Controls.Add(new LiteralControl(TagUser));
					NroFila++;
				}
				if(NroFila==1)
				{
					//Page.RegisterClientScriptBlock("ContacUnico","<script>$('.friend').click();</script>");
				}
			}		
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarMsgResponsable.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add AdministrarMsgResponsable.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add AdministrarMsgResponsable.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			hRutaFoto.Value = Helper.ObtenerRutaFotoPersonal();
			hIdUsuarioRegistro.Value=CNetAccessControl.GetIdUser().ToString();
			//hNroPersonalSEND.Value = CNetAccessControl.GetUserNroPersonal();
			hNroPersonalSEND.Value = CNetAccessControl.GetUserNroDocIdent();
		}

		public void LlenarJScript()
		{
			// TODO:  Add AdministrarMsgResponsable.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarMsgResponsable.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministrarMsgResponsable.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarMsgResponsable.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add AdministrarMsgResponsable.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add AdministrarMsgResponsable.ValidarFiltros implementation
			return false;
		}

		#endregion
	}
}
