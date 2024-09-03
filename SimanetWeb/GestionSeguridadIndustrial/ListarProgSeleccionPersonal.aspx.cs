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
using SIMA.Controladoras.General;
using SIMA.EntidadesNegocio;
using SIMA.EntidadesNegocio.Personal;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;
using System.Configuration;

namespace SIMA.SimaNetWeb.GestionSeguridadIndustrial
{
	public class ListarProgSeleccionPersonal : System.Web.UI.Page,IPaginaBase
	{

		
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtBuscar;
		protected projDataGridWeb.DataGridWeb gridLst;
		const string KEYQSELECCION = "IdSelec";
		const string KEYQPERIODO = "Periodo";
		const string KEYQIDPROGCAP = "IdProg";
		const string KEYQPERODOPROGCAP = "PeriodoProg";
		const string KEYQREQEVA = "ReqEva";

		public int Periodo
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQPERIODO]);}
		}
		public int IdSeleccion
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQSELECCION]);}
		}
	
		public int IdProgCap
		{
			get
			{
				return Convert.ToInt32(Page.Request.Params[KEYQIDPROGCAP]);
			}
		}
		public int PeriodoProgCap
		{
			get
			{
				return Convert.ToInt32(Page.Request.Params[KEYQPERODOPROGCAP]);
			}
		}

		public int RequiereEvaluacion
		{
			get
			{
				return Convert.ToInt32(Page.Request.Params[KEYQREQEVA]);
			}
		}




		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				if(!Page.IsPostBack)
				{
					this.ConfigurarAccesoControles();
					this.LlenarJScript();
					this.LlenarDatos();
					this.LlenarGrilla();

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
			this.gridLst.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.gridLst_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		public DataTable ObtenerDatos(){
			return (new CCCTT_Capacitacion_Prog_Lst_Per()).ListarTodosGrilla(this.Periodo,this.IdSeleccion,this.PeriodoProgCap,this.IdProgCap);
		}

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			DataTable dt = this.ObtenerDatos();
			if (dt!=null)
			{
				gridLst.DataSource = dt;
				
			}
			else
			{
				gridLst.DataSource = dt;
			}
			
			try
			{
				gridLst.DataBind();
			}
			catch (Exception exception)
			{
				string mensaje = exception.Message.ToString();
				gridLst.CurrentPageIndex = 0;
				gridLst.DataBind();
			}				
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ListarProgSeleccionPersonal.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add ListarProgSeleccionPersonal.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add ListarProgSeleccionPersonal.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add ListarProgSeleccionPersonal.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			this.txtBuscar.Attributes.Add(SIMA.Utilitario.Enumerados.EventosJavaScript.OnKeyup.ToString(),"doSearch()");
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ListarProgSeleccionPersonal.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ListarProgSeleccionPersonal.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ListarProgSeleccionPersonal.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add ListarProgSeleccionPersonal.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ListarProgSeleccionPersonal.ValidarFiltros implementation
			return false;
		}

		#endregion

		
		private void gridLst_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
			 	  
				//Asistencia a la capacitacion
				HtmlImage imgA =(HtmlImage)e.Item.Cells[6].FindControl("imgAsistencia");
				imgA.Src= "../imagenes/Filtro/Aprobar.gif";
				imgA.Style.Add("display",((dr["IdEstado"].ToString()=="1")?"block":"none"));

				HtmlTable ohtmlTable = Helper.CrearHtmlTabla(1,1);
				
				ohtmlTable.Rows[0].Cells[0].Controls.Add(HtmlImgPersonal(dr["NroDNI"].ToString(),((e.Item.ItemType == ListItemType.Item)?"EfectCircularItem.gif":"EfectCircularAlter.gif")));
				e.Item.Cells[1].Controls.Add(ohtmlTable);

				TextBox otxt = (TextBox) e.Item.Cells[6].FindControl("txtNota");
				otxt.Text = dr["Nota"].ToString();
				otxt.Style.Add("display",((this.RequiereEvaluacion==1)?"block":"none"));
				otxt.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnKeydown.ToString(),"AdminsitrarProgramacionCapacitacionIIUI.RegistrarAsistenciaOnKeyDown('" + dr["IdLstProgAsisCap"].ToString() + "','" + dr["IdPersonal"].ToString() + "','" + this.IdProgCap.ToString() +"','" + this.PeriodoProgCap.ToString() +"',jNet.get('" + imgA.ClientID + "'),jNet.get('" + otxt.ClientID + "'));");

				e.Item.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.Ondblclick.ToString(),"AdminsitrarProgramacionCapacitacionIIUI.RegistrarAsistencia('" + dr["IdLstProgAsisCap"].ToString() + "','" + dr["IdPersonal"].ToString() + "','" + this.IdProgCap.ToString() +"','" + this.PeriodoProgCap.ToString() +"',jNet.get('" + imgA.ClientID + "'),jNet.get('" + otxt.ClientID + "'));");

				Helper.ConfiguraColumnaHyperLink(e.Item.Cells[0],gridLst.CurrentPageIndex,gridLst.PageSize,e.Item.ItemIndex,Helper.MostrarDatosEnCajaTexto("hIdPersonal",dr["IdPersonal"].ToString()));
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
			}
		}
		public System.Web.UI.LiteralControl HtmlImgPersonal(string NroDNI,string Efecto)
		{
			return 	HtmlImgPersonal(NroDNI,Efecto,48,48);
		}
		public System.Web.UI.LiteralControl HtmlImgPersonal(string NroDNI,string Efecto,int Ancho,int Alto){
			string ImgCirc="<img id='" + NroDNI +"' style='WIDTH: " + Ancho.ToString() + "px; HEIGHT: " + Alto.ToString() + "px' class='imgCirc' src='/SimaNetWeb/imagenes/Navegador/" + Efecto + "'>";
			string HtmlImg = "<div class='ContextImg'> " + ImgCirc + "<img  src='" + Helper.ObtenerFotoPersonal(NroDNI) +"'  style='WIDTH: "+ (Ancho-2).ToString() + "px; HEIGHT: " + (Alto-2).ToString() + "px'  onerror=ErrorLoadImg(this,'"  + Helper.ObtenerFotoPersonal(NroDNI) + "'); /></div>";
			return 	(new LiteralControl(HtmlImg));
		}
	}
}
