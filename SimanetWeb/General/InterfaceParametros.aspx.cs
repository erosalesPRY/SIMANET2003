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
using System.Reflection;

namespace SIMA.SimaNetWeb.General
{
	/// <summary>
	/// Summary description for InterfaceParametros.
	/// </summary>
	public class InterfaceParametros : System.Web.UI.Page,IPaginaBase
	{
		protected System.Web.UI.HtmlControls.HtmlTable tblParametros;
		protected System.Web.UI.WebControls.Label lbl;
		const string KEYQNOMBRESP="QNomSP";

		private void Page_Load(object sender, System.EventArgs e)
		{

			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Interface",this.ToString(),"Se consultó interfaces.",Enumerados.NivelesErrorLog.I.ToString()));
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
					Helper.MsgBox(oSIMAExcepcionDominio.Error.ToString());					
				}
				catch(Exception oException)
				{
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

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			string NomSP = Page.Request.Params[KEYQNOMBRESP].ToString();
			lbl.Text ="sp :" + NomSP;
			DataTable dt= (new CSIMA_Interfaces()).ListarParametrosInterface(NomSP);
			int f=0;
			if(dt!=null)
			{
				foreach(DataRow dr in dt.Rows)
				{
					Label olblParam = new Label();
					olblParam.Text=dr["ParameterName"].ToString();
					//TipoDato//Tamano
					if(f!=0)
					{
						HtmlTableRow tr = new HtmlTableRow();
						HtmlTableCell tc = new HtmlTableCell();
						tr.Controls.Add(tc);
						HtmlTableCell tcCtrl = new HtmlTableCell();
						tr.Controls.Add(tcCtrl);
						tblParametros.Rows.Add(tr);
						//eWorld.UI.CalendarPopup
					}

					System.Web.UI.WebControls.TextBox tb = new TextBox();
					tb.ID = "ctrl_"+ dr["ParameterName"].ToString().Replace("@","");
					tblParametros.Rows[f].Cells[1].Controls.Add(tb);
					/*
					//Crea el tipo de control segun el tipo de datos
					if(dr["TipoDato"].ToString()=="varchar")
					{
						System.Web.UI.WebControls.TextBox tb = new TextBox();
						tb.ID = "ctrl_"+ dr["ParameterName"].ToString().Replace("@","");
						tblParametros.Rows[f].Cells[1].Controls.Add(tb);
					}
					else if(dr["TipoDato"].ToString()=="int")
					{
						eWorld.UI.NumericBox nb = new eWorld.UI.NumericBox();
						nb.ID = "ctrl_"+ dr["ParameterName"].ToString().Replace("@","");
						tblParametros.Rows[f].Cells[1].Controls.Add(nb);
					}
					else if(dr["TipoDato"].ToString()=="datetime")
					{
						eWorld.UI.CalendarPopup cb = new eWorld.UI.CalendarPopup();
						cb.ID = "ctrl_"+ dr["ParameterName"].ToString().Replace("@","");
						tblParametros.Rows[f].Cells[1].Controls.Add(cb);
					}
					else if(dr["TipoDato"].ToString()=="numeric")
					{
						System.Web.UI.WebControls.TextBox tnb = new TextBox();
						tnb.ID = "ctrl_"+ dr["ParameterName"].ToString().Replace("@","");
						tblParametros.Rows[f].Cells[1].Controls.Add(tnb);
					}
					*/

					tblParametros.Rows[f].Cells[0].Controls.Add(olblParam);
					f++;
				}
			}
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add InterfaceParametros.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add InterfaceParametros.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add InterfaceParametros.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add InterfaceParametros.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add InterfaceParametros.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add InterfaceParametros.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add InterfaceParametros.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add InterfaceParametros.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add InterfaceParametros.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add InterfaceParametros.ValidarFiltros implementation
			return false;
		}

		#endregion
	}
}
