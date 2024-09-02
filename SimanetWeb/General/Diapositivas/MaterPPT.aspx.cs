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
	/// Summary description for MaterPPT.
	/// </summary>
	public class MaterPPT : System.Web.UI.Page,IPaginaBase
	{
		protected System.Web.UI.WebControls.PlaceHolder phContexto;
		protected System.Web.UI.WebControls.Image Image1;


		string strHTML="";
		protected System.Web.UI.HtmlControls.HtmlGenericControl Navegador;
		string strHTMLIndice="";

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
			// TODO:  Add MaterPPT.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add MaterPPT.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add MaterPPT.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add MaterPPT.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			
			LstControles(1);
			phContexto.Controls.Add(new LiteralControl(strHTML));
			this.Navegador.Controls.Add( new LiteralControl(strHTMLIndice));
		}
		
		void LstControles(int IdObjeto)
		{
			DataTable dt = (new CDiapositiva()).Listar(1,IdObjeto);
			if(dt!=null)
			{
				foreach(DataRow dr in dt.Rows)
				{
					string cmll= "\"";
					string Titulo =dr["Titulo"].ToString();
					string Id = " id=" + cmll + "secc" + dr["IdObjeto"].ToString() + cmll;
					string Class = " class=" + cmll + dr["Clase"].ToString()+ cmll;
					
					if(Convert.ToInt32(dr["Indice"].ToString())==1)
					{
						strHTMLIndice +="<li><A href=" + cmll + "#" + "secc" + dr["IdObjeto"].ToString() + cmll + ">"+ dr["IdObjeto"].ToString() + "</A></li>";
					}
						
					string Tag = "<" +dr["TagName"].ToString() + Id + Class +" TIPOCRTL=" + cmll + dr["IdTipoObjeto"].ToString() + cmll + "  INITLOAD = " + cmll + dr["InitLoadUrl"].ToString()  + cmll + " URL=" + cmll + dr["UrlContenido"].ToString() + cmll  + ">" + Titulo;
						strHTML +=Tag;
						LstControles(Convert.ToInt32(dr["IdObjeto"].ToString()));
					
					strHTML +="<" +dr["TagName"].ToString()+"/>";
				}
			}
		}

		public void LlenarJScript()
		{
			// TODO:  Add MaterPPT.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add MaterPPT.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add MaterPPT.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add MaterPPT.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add MaterPPT.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add MaterPPT.ValidarFiltros implementation
			return false;
		}

		#endregion
	}
}
