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
using SIMA.Controladoras.GestionEstrategica;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using SIMA.Controladoras;
using SIMA.Controladoras.General;
using SIMA.ManejadorTransaccion;

namespace SIMA.SimaNetWeb.DirectorioEjecutivo.GestionEstrategica
{
	/// <summary>
	/// Summary description for ConsultarResumenInventarioPC.
	/// </summary>
	public class ConsultarResumenInventarioPC : System.Web.UI.Page,IPaginaBase
	{
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Literal ltlMensaje;

		const string URLDETALLE="ConsultarInventarioPC.aspx?";
		const string GRILLAVACIA="No existen registros";
		const string KEYQPROCESADOR ="IDPROCESADOR";
		const string KEYQCO ="IDCENTROOPERATIVO";
		const string CUATRO86 ="7";
		const string PENTIUMI ="5";
		const string PENTIUMMMX ="4";
		const string PENTIUMII ="3";
		const string PENTIUMIII ="2";
		const string PENTIUMIV ="1";
		const string CELERON ="6";
		const string OTROS ="8";
		double sp, sc,sch,si,total,coNO;

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					this.LlenarJScript();
					Helper.ReiniciarSession();

					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Estrategica",this.ToString(),"Se consultó Gestion Estrategica.",Enumerados.NivelesErrorLog.I.ToString()));
					this.LlenarGrilla();
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
					SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
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
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			CInventarioPC oCInventarioPC = new CInventarioPC();
			DataTable dtInventario = oCInventarioPC.ListarResumenInventarioXCO();
	
			if(dtInventario!=null)
			{
				DataView dwInventario = dtInventario.DefaultView;
				dwInventario.RowFilter = Helper.ObtenerFiltro(this);
				if(dwInventario.Count>0)
				{
					grid.DataSource = dwInventario;
					this.lblResultado.Visible = false;
				}
				else
				{
					grid.DataSource = null;
					lblResultado.Visible = true;
					lblResultado.Text = GRILLAVACIA;
				}
				
			}
			else
			{
				grid.DataSource = dtInventario;
				lblResultado.Text = GRILLAVACIA;
			}
			
			try
			{
				grid.DataBind();
			}
			catch(Exception oException)
			{
				string error = oException.Message.ToString();
				grid.CurrentPageIndex = Utilitario.Constantes.ValorConstanteCero;
				grid.DataBind();
			}
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarResumenInventarioPC.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add ConsultarResumenInventarioPC.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add ConsultarResumenInventarioPC.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add ConsultarResumenInventarioPC.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarResumenInventarioPC.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarResumenInventarioPC.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarResumenInventarioPC.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarResumenInventarioPC.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add ConsultarResumenInventarioPC.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ConsultarResumenInventarioPC.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.Header)
			{
				if(e.Item.Cells[1].Text=="SIMA PERU")
				{
						e.Item.Cells[1].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);	
					e.Item.Cells[1].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					 Helper.MostrarVentana(URLDETALLE,KEYQCO + Utilitario.Constantes.SIGNOIGUAL + 
					 "1" + Utilitario.Constantes.SIGNOAMPERSON + KEYQPROCESADOR + Utilitario.Constantes.SIGNOIGUAL + "-1"));
					e.Item.Cells[1].Font.Underline=true;
					
					e.Item.Cells[1].Style.Add("cursor","hand");
					
				}
				if(e.Item.Cells[2].Text=="SIMA CALLAO")
				{
					e.Item.Cells[2].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);		
					e.Item.Cells[2].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
						Helper.MostrarVentana(URLDETALLE,KEYQCO + Utilitario.Constantes.SIGNOIGUAL + 
						"2" + Utilitario.Constantes.SIGNOAMPERSON + KEYQPROCESADOR + Utilitario.Constantes.SIGNOIGUAL + "-1"));
					e.Item.Cells[2].Font.Underline=true;
				
					e.Item.Cells[2].Style.Add("cursor","hand");
					
				}

				if(e.Item.Cells[3].Text=="SIMA CHIMBOTE")
				{
						e.Item.Cells[3].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);	
						e.Item.Cells[3].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
							Helper.MostrarVentana(URLDETALLE,KEYQCO + Utilitario.Constantes.SIGNOIGUAL + 
							"3" + Utilitario.Constantes.SIGNOAMPERSON + KEYQPROCESADOR + Utilitario.Constantes.SIGNOIGUAL + "-1"));
					e.Item.Cells[3].Font.Underline=true;
				
					e.Item.Cells[3].Style.Add("cursor","hand");
					
				}
				if(e.Item.Cells[4].Text=="SIMA IQUITOS")
				{
					e.Item.Cells[4].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);		
					e.Item.Cells[4].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
						Helper.MostrarVentana(URLDETALLE,KEYQCO + Utilitario.Constantes.SIGNOIGUAL + 
						"4" + Utilitario.Constantes.SIGNOAMPERSON + KEYQPROCESADOR + Utilitario.Constantes.SIGNOIGUAL + "-1"));
					e.Item.Cells[4].Font.Underline=true;
					
					e.Item.Cells[4].Style.Add("cursor","hand");
					
				}
				if(e.Item.Cells[5].Text=="C.O NO ASIGNADO")
				{
					e.Item.Cells[5].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);		
					e.Item.Cells[5].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
						Helper.MostrarVentana(URLDETALLE,KEYQCO + Utilitario.Constantes.SIGNOIGUAL + 
						"0" + Utilitario.Constantes.SIGNOAMPERSON + KEYQPROCESADOR + Utilitario.Constantes.SIGNOIGUAL + "-1"));
					e.Item.Cells[5].Font.Underline=true;
					
					e.Item.Cells[5].Style.Add("cursor","hand");
					
				}
				
				
			}
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				e.Item.Cells[0].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
				e.Item.Cells[0].Font.Underline=true;
				e.Item.Cells[0].ForeColor=Color.Blue;
				e.Item.Cells[0].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.MostrarVentana(URLDETALLE,KEYQPROCESADOR + Utilitario.Constantes.SIGNOIGUAL + 
					dr["codigogrupo"].ToString()+ Utilitario.Constantes.SIGNOAMPERSON + KEYQCO + Utilitario.Constantes.SIGNOIGUAL + "-1"));
			
				if(dr["SIMA PERU"].ToString()!="0")
				{
						e.Item.Cells[1].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
					e.Item.Cells[1].Font.Underline=true;
					e.Item.Cells[1].ForeColor=Color.Blue;
					e.Item.Cells[1].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
						Helper.MostrarVentana(URLDETALLE,KEYQCO + Utilitario.Constantes.SIGNOIGUAL + 
						"1" + Utilitario.Constantes.SIGNOAMPERSON + KEYQPROCESADOR +Utilitario.Constantes.SIGNOIGUAL + 
						dr["codigogrupo"].ToString()));
					sp=sp+Convert.ToInt32(dr["SIMA PERU"]);
				}
				
				if(dr["SIMA CALLAO"].ToString()!="0")
				{
					e.Item.Cells[2].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
					e.Item.Cells[2].Font.Underline=true;
					e.Item.Cells[2].ForeColor=Color.Blue;
					e.Item.Cells[2].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
						Helper.MostrarVentana(URLDETALLE,KEYQCO + Utilitario.Constantes.SIGNOIGUAL + 
						"2" + Utilitario.Constantes.SIGNOAMPERSON + KEYQPROCESADOR +Utilitario.Constantes.SIGNOIGUAL + 
						dr["codigogrupo"].ToString()));
					sc=sc+Convert.ToInt32(dr["SIMA CALLAO"]);
				}
				
				if(dr["SIMA CHIMBOTE"].ToString()!="0")
				{
					e.Item.Cells[3].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
					e.Item.Cells[3].Font.Underline=true;
					e.Item.Cells[3].ForeColor=Color.Blue;
					e.Item.Cells[3].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
						Helper.MostrarVentana(URLDETALLE,KEYQCO + Utilitario.Constantes.SIGNOIGUAL + 
						"3" + Utilitario.Constantes.SIGNOAMPERSON + KEYQPROCESADOR +Utilitario.Constantes.SIGNOIGUAL + 
						dr["codigogrupo"].ToString()));
					sch=sch+Convert.ToInt32(dr["SIMA CHIMBOTE"]);
				}
				
				if(dr["SIMA IQUITOS"].ToString()!="0")
				{
					e.Item.Cells[4].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
					e.Item.Cells[4].Font.Underline=true;
					e.Item.Cells[4].ForeColor=Color.Blue;
					e.Item.Cells[4].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
						Helper.MostrarVentana(URLDETALLE,KEYQCO + Utilitario.Constantes.SIGNOIGUAL + 
						"4" + Utilitario.Constantes.SIGNOAMPERSON + KEYQPROCESADOR +Utilitario.Constantes.SIGNOIGUAL + 
						dr["codigogrupo"].ToString()));
					si=si+Convert.ToInt32(dr["SIMA IQUITOS"]);
				}
				if(dr["CONOASIGNADO"].ToString()!="0")
				{
					e.Item.Cells[5].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
					e.Item.Cells[5].Font.Underline=true;
					e.Item.Cells[5].ForeColor=Color.Blue;
					e.Item.Cells[5].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
						Helper.MostrarVentana(URLDETALLE,KEYQCO + Utilitario.Constantes.SIGNOIGUAL + 
						"0" + Utilitario.Constantes.SIGNOAMPERSON + KEYQPROCESADOR +Utilitario.Constantes.SIGNOIGUAL + 
						dr["codigogrupo"].ToString()));
					coNO=coNO+Convert.ToInt32(dr["CONOASIGNADO"]);
				}

				total=total+Convert.ToInt32(dr["total"]);
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);				
			}
			if(e.Item.ItemType == ListItemType.Footer)
			{
				e.Item.Cells[1].Text=sp.ToString();
				e.Item.Cells[2].Text=sc.ToString();
				e.Item.Cells[3].Text=sch.ToString();
				e.Item.Cells[4].Text=si.ToString();
				e.Item.Cells[5].Text=coNO.ToString();
				e.Item.Cells[6].Text=total.ToString();

			}
		}
	}
}
