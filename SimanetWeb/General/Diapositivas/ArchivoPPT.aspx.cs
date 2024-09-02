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
using SIMA.EntidadesNegocio.General;

using SIMA.Utilitario;
using NetAccessControl;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using System.IO;

namespace SIMA.SimaNetWeb.General.Diapositivas
{
	/// <summary>
	/// Summary description for ArchivoPPT.
	/// </summary>
	public class ArchivoPPT : System.Web.UI.Page,IPaginaBase
	{
		protected System.Web.UI.WebControls.PlaceHolder phContexto;
		protected System.Web.UI.WebControls.PlaceHolder phControls;
		protected System.Web.UI.HtmlControls.HtmlTableCell ToolPag;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hPPTActive;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hNroGrupoyPag;

		int IdPagNro=0;
		string strHTML="";
		string cmll= "\"";
		string KEYQIDPRESENTACION="idPresent";
		protected System.Web.UI.HtmlControls.HtmlInputHidden hLibJs;
	
		string strHTMLIndice="";

		int IdPresentacion
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDPRESENTACION].ToString());}
		}
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				if(!Page.IsPostBack)
				{
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarJScript();
					this.LlenarDatos();
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(), "Gestión Financiera: Administrar Formatos Financieros mensualizados", this.ToString(),"Se consultó Listado de formtatos financieros",Enumerados.NivelesErrorLog.I.ToString()));
					
				}
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
				string debug = oException.Message.ToString();
				SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
				Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
			}							
		}


		
		int Orden=0;
	
		void LstControles(int IdObjeto,int IdGrupo)
		{
			DataTable dt = (new CDiapositiva()).Listar(this.IdPresentacion,IdObjeto);
			if(dt!=null)
			{
				foreach(DataRow dr in dt.Rows)
				{
					
					int IdObjetoAct = Convert.ToInt32(dr["IdObjeto"].ToString());

					string Titulo =((Convert.ToInt32(dr["IdTipoObjeto"].ToString())==2)?"": dr["Titulo"].ToString());
					string Id = " id=" + cmll + "Obj" + IdObjetoAct.ToString() + cmll;
					string Class = ((dr["Clase"].ToString().Length>0)?" class=" + cmll + dr["Clase"].ToString()+ cmll:"");
					string Style= ((dr["Style"].ToString().Length>0)? " style=" + cmll + dr["Style"].ToString()+ cmll :"");
					string Data=((dr["Data"].ToString().Length>0)? " " + dr["Data"].ToString() :"");
					string Grupo = ((dr["IdTipoObjeto"].ToString().Equals("2"))? " GRP=" + cmll + IdGrupo.ToString() + cmll:"");

					//SIMA.Utilitario.Helper.General.ObtenerPathApp() + '/imagenes/Tabs/cargando.gif')
					if(Convert.ToInt32(dr["Indice"].ToString())==1)
					{
						NroPags=NroPags + IdObjetoAct.ToString() +";";
						IdPagNro++;
					}
					string Params = (new InvocaControladora()).GetParametrosInURL(IdObjetoAct);

					string WebPartURL=dr["UrlContenido"].ToString()+ "&" + Params + "IdObj="+ IdObjetoAct.ToString();

					string Tag2 = "<" +dr["TagName"].ToString() + Id + Style + Class + Data +" TIPOCRTL=" + cmll + dr["IdTipoObjeto"].ToString() + cmll + "  INITLOAD = " + cmll + dr["InitLoadUrl"].ToString()  + cmll + " CARGADO=0 URL=" + cmll + WebPartURL + cmll  + Grupo + ">" + Titulo;
					strHTML +=Tag2;

					LstControles(IdObjetoAct,IdGrupo);
					
					strHTML +="</" +dr["TagName"].ToString()+">";

					Orden++;
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

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add ArchivoPPT.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ArchivoPPT.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add ArchivoPPT.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add ArchivoPPT.LlenarCombos implementation
		}

		string NroPags="";
		public void LlenarDatos()
		{
			DataTable dtgrp = (new CDispositivaGrupo()).Listar(this.IdPresentacion);
			if(dtgrp!=null)
			{
				//Registra Libreria JavaScript
				DataTable dtUrlJs =  Utilitario.Helper.SelectDistinct(dtgrp,"UrlLibJs");
				if(dtUrlJs.Rows.Count>0){
					this.hLibJs.Value = dtUrlJs.Rows[0]["UrlLibJs"].ToString();
				}

				foreach(DataRow drg in dtgrp.Rows)
				{
					strHTML="";
					IdPagNro=1;
					int NroGrupo=Convert.ToInt32(drg["IdGrupo"]);
					NroPags="";
					LstControles(Convert.ToInt32(drg["IdObjeto"]),NroGrupo);

					string HiddenGrp = "<INPUT id=" + cmll + "GrpH" + NroGrupo + cmll + "  type=" + cmll +  "hidden" + cmll+ "  value=" + cmll+  ((NroPags.Length>0)?NroPags.Substring(0,NroPags.Length-1):"") + cmll+ ">";
					phControls.Controls.Add(new LiteralControl(HiddenGrp));
					phContexto.Controls.Add(new LiteralControl(strHTML));
				}
			}
		}

		public void LlenarJScript()
		{
			// TODO:  Add ArchivoPPT.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ArchivoPPT.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ArchivoPPT.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ArchivoPPT.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add ArchivoPPT.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ArchivoPPT.ValidarFiltros implementation
			return false;
		}

		#endregion
	}
}
