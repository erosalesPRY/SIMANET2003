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
	/// Summary description for PPTListarPaginacion.
	/// </summary>
	public class PPTListarPaginacion : System.Web.UI.Page,IPaginaBase	
	{
		const string KEYQIDPRESENTACION="idPresent";
		const string KEYQIDOBJETO="IdObjeto";
		public int IdPresentacion{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDPRESENTACION]);}
		}
		public int IdObjeto
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDOBJETO]);}
		}

		protected System.Web.UI.WebControls.PlaceHolder phContexto;
		string cmll= "\"";
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
			// TODO:  Add PPTListarPaginacion.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add PPTListarPaginacion.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add PPTListarPaginacion.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add PPTListarPaginacion.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			LstControles(this.IdObjeto);
		}


		void LstControles(int IdObjeto)
		{
			DataTable dt = (new CDiapositiva()).Listar(this.IdPresentacion, IdObjeto);
			if(dt!=null)
			{
				foreach(DataRow dr in dt.Rows)
				{
					if((Convert.ToInt32(dr["Indice"].ToString())==1)&&(Convert.ToInt32(dr["IdTipoObjeto"].ToString())==2))
					{
						string NombreObj="Obj"+dr["IdObjeto"].ToString();

						HtmlTable _Table = Helper.CrearTabla(1,1);
						_Table.ID="tbl"+ dr["IdObjeto"].ToString();
						_Table.Attributes.Add("class","ItemPPT");
						_Table.Style.Add("MARGIN-LEFT","5px");

						_Table.Rows[0].Cells[0].InnerText = dr["Titulo"].ToString();
						_Table.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnClick.ToString(),"snPoint.ActivarPPT(this,'" + NombreObj + "');");
						phContexto.Controls.Add(_Table);
						
					}
				}
			}
		}

		public void LlenarJScript()
		{
			// TODO:  Add PPTListarPaginacion.LlenarJScript implementation
		}

	
	
		


		public void RegistrarJScript()
		{
			// TODO:  Add PPTListarPaginacion.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add PPTListarPaginacion.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add PPTListarPaginacion.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add PPTListarPaginacion.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add PPTListarPaginacion.ValidarFiltros implementation
			return false;
		}

		#endregion
	}
}
