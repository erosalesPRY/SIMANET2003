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
	/// Summary description for PPTDisplay.
	/// </summary>
	public class PPTDisplay : System.Web.UI.Page,IPaginaBase
	{

		int IdPagNro=0;
		string strHTML="";
		string cmll= "\"";
		protected System.Web.UI.HtmlControls.HtmlInputHidden hPPTActive;
		protected System.Web.UI.HtmlControls.HtmlTableCell ToolPag;
		protected System.Web.UI.HtmlControls.HtmlTableCell GrpPPT;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hNroGrupoyPag;
		protected System.Web.UI.WebControls.PlaceHolder phControls;
		protected System.Web.UI.WebControls.PlaceHolder phContexto;

		string KEYQIDPRESENTACION="idPresent";
	
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
			// TODO:  Add PPTDisplay.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add PPTDisplay.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add PPTDisplay.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add PPTDisplay.LlenarCombos implementation
		}
		void CargarGruposPPT(){
				
			DataTable dt = (new CDispositivaGrupo()).Listar(1);
			if((dt!=null)&&(dt.Rows.Count!=0)){
				//for(int p=0;p<=9;p++)
				{
					foreach(DataRow dr in dt.Rows)
					{
						HtmlTable tblGRP = Helper.CrearHtmlTabla(1,1);
						tblGRP.Attributes.Add("class","BaseItemInGrid");
						tblGRP.Attributes.Add("IDGRUPO",dr["IdGrupo"].ToString());
						tblGRP.Rows[0].Cells[0].InnerHtml = dr["NombreGrupo"].ToString();
						tblGRP.Rows[0].Cells[0].Attributes.Add(Utilitario.Constantes.EVENTOCLICK.ToString(),"CargarPaginacion('" + dr["IdGrupo"].ToString() + "');");
						this.GrpPPT.Controls.Add(tblGRP);
					}
				}
			}
		}
		

		string NroPags="";
		public void LlenarDatos()
		{
			//CargarGruposPPT();
			//this.hNroPag.Value="2";			
			//return;
			
			DataTable dtgrp = (new CDispositivaGrupo()).Listar(this.IdPresentacion);
			if(dtgrp!=null)
			{
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
			//this.IdPag.Controls.Add( new LiteralControl("<A class='page' href=" + cmll + "#" + "secc0" + cmll + ">Fist</A>"));
			/*strHTMLIndice= ((strHTMLIndice.Length>0)?"<table border='0' cellSpacing='0' cellPadding='0' ><tr>" + strHTMLIndice +" </tr></table>":"No Dispositivas");
			this.ToolPag.Controls.Add( new LiteralControl(strHTMLIndice));*/
			//this.IdPag.Controls.Add( new LiteralControl("<A class='page' href=" + cmll + "#" + "secc99" + cmll + ">Last</A>"));
		}
		int Orden=0;
	
		void LstControles(int IdObjeto,int IdGrupo)
		{
			DataTable dt = (new CDiapositiva()).Listar(1,IdObjeto);
			if(dt!=null)
			{
				foreach(DataRow dr in dt.Rows)
				{
					
					string Titulo =dr["Titulo"].ToString();
					string Id = " id=" + cmll + "Obj" + dr["IdObjeto"].ToString() + cmll;
					string Class = ((dr["Clase"].ToString().Length>0)?" class=" + cmll + dr["Clase"].ToString()+ cmll:"");
					string Style= ((dr["Style"].ToString().Length>0)? " style=" + cmll + dr["Style"].ToString()+ cmll :"");
					string Data=((dr["Data"].ToString().Length>0)? " " + dr["Data"].ToString() :"");
					string Grupo = ((dr["IdTipoObjeto"].ToString().Equals("2"))? " GRP=" + cmll + IdGrupo.ToString() + cmll:"");

					
					if(Convert.ToInt32(dr["Indice"].ToString())==1)
					{
						NroPags=NroPags + dr["IdObjeto"].ToString() +";";
						IdPagNro++;
					}

					string Tag = "<" +dr["TagName"].ToString() + Id + Style + Class + Data +" TIPOCRTL=" + cmll + dr["IdTipoObjeto"].ToString() + cmll + "  INITLOAD = " + cmll + dr["InitLoadUrl"].ToString()  + cmll + " URL=" + cmll + dr["UrlContenido"].ToString() + cmll  + Grupo + ">" + Titulo;
					strHTML +=Tag;
					LstControles(Convert.ToInt32(dr["IdObjeto"].ToString()),IdGrupo);
					
					strHTML +="</" +dr["TagName"].ToString()+">";

					Orden++;
				}
			}
		}

		public void LlenarJScript()
		{
			// TODO:  Add PPTDisplay.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add PPTDisplay.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add PPTDisplay.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add PPTDisplay.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add PPTDisplay.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add PPTDisplay.ValidarFiltros implementation
			return false;
		}

		#endregion
	}
}
