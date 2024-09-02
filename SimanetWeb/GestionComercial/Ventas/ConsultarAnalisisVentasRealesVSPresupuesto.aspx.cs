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
using SIMA.Controladoras.General;
using SIMA.Controladoras.GestionComercial;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;

namespace SIMA.SimaNetWeb.GestionComercial.Ventas
{
	/// <summary>
	/// Summary description for ConsultarAnalisisVentasRealesVSPresupuesto.
	/// </summary>
	public class ConsultarAnalisisVentasRealesVSPresupuesto : System.Web.UI.Page,IPaginaBase
	{
		const string KEYOPTIONGRAFICO="OPGRAPH";
		const string VERSION = "IdVersion";
		const string ANO = "Ano";
		const string URLREPORTEPRESUPUESTOVSVENTASPORPERIODO= "DefaultGraficosVentasPresupuesto.aspx?";
		const string URLREPORTEPRESUPUESTOVSVENTASPORPERIODO1= "../Reportes/GraficoPresupuestoIniciaYFinalYVentasPorPeriodo.aspx?";

		const string GRILLAVACIA ="No existe registros a mostrar";

		int Periodo
		{
			get{return Convert.ToInt32(Page.Request.Params[ANO]);}
		}
		int IdVersion
		{
			get{return Convert.ToInt32(Page.Request.Params[VERSION]);}
		}
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.ImageButton ibtnGraficoBarraVentasVSPPTO;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.ImageButton ibtnGraficoBarra2;
		protected System.Web.UI.WebControls.Literal ltlMensaje;

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarJScript();
					this.LlenarCombos();
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se consultaron las Ventas Presupuestadas del Centro Operativo",Enumerados.NivelesErrorLog.I.ToString()));

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
			this.ibtnGraficoBarraVentasVSPPTO.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnGraficoBarraVentasVSPPTO_Click);
			this.ibtnGraficoBarra2.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnGraficoBarra2_Click);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members
		DataTable ObtenerDatos(){
			CVentasPresupuestadas oCVentasPresupuestadas = new CVentasPresupuestadas();
			return oCVentasPresupuestadas.ConsultarAnalisisVentasRealesVSPresupuesto(this.Periodo);
		}
		
		public void LlenarGrilla()
		{
			DataTable dt =  this.ObtenerDatos();
			if(dt!=null)
			{
				grid.DataSource = dt;
				lblResultado.Visible = false;
			}
			else
			{
				lblResultado.Visible = true;
				lblResultado.Text = GRILLAVACIA;
			}
			
			try
			{
				grid.DataBind();
			}
			catch(Exception ex)
			{
				string a = ex.Message;
				grid.CurrentPageIndex = 0;
				grid.DataBind();
			}
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarAnalisisVentasRealesVSPresupuesto.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
		}

		public void LlenarCombos()
		{
			// TODO:  Add ConsultarAnalisisVentasRealesVSPresupuesto.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add ConsultarAnalisisVentasRealesVSPresupuesto.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			this.ibtnGraficoBarraVentasVSPPTO.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			this.ibtnGraficoBarra2.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarAnalisisVentasRealesVSPresupuesto.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarAnalisisVentasRealesVSPresupuesto.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarAnalisisVentasRealesVSPresupuesto.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add ConsultarAnalisisVentasRealesVSPresupuesto.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ConsultarAnalisisVentasRealesVSPresupuesto.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			e.Item.Cells[0].Attributes.Add("class","locked");
			e.Item.Cells[1].Attributes.Add("class","locked");

			e.Item.Cells[1].Attributes.Add("nowrap","");
			e.Item.Cells[1].Attributes.Add("align","left");

			if(e.Item.ItemType == ListItemType.Header)
			{
				e.Item.Cells[0].Text = "NRO";
				for(int i=1;i<=e.Item.Cells.Count-1;i++)
				{
					e.Item.Cells[i].Attributes.Add("nowrap","");
					e.Item.Cells[i].Text = e.Item.Cells[i].Text.Replace("PER","");
					if(e.Item.Cells[i].Text.Substring(0,3)=="DIF"){
						e.Item.Cells[i].Text = "DIF. %";
					}
					
				}

			}
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				
				for(int i=2;i<=e.Item.Cells.Count-1;i++)
				{
					e.Item.Cells[i].Attributes.Add("nowrap","");
					e.Item.Cells[i].Attributes.Add("align","right");
					e.Item.Cells[i].Text = Convert.ToDouble(e.Item.Cells[i].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4) + ((dr.Table.Columns[i].ColumnName.IndexOf("DIF")==-1)?"":" %");
					if((Convert.ToInt32(dr["Orden"].ToString())==3)||(Convert.ToInt32(dr["Orden"].ToString())==5)){
						if(Convert.ToDouble(dr[i].ToString())!= 0)
						{
							if(Convert.ToDouble(dr[i].ToString()).Equals(100.0))
							{
								e.Item.Cells[i].Text = Convert.ToDouble(dr[i].ToString()).ToString(Utilitario.Constantes.FORMATODECIMAL0) + " %";
							}
							else
							{
								e.Item.Cells[i].Text = Convert.ToDouble(dr[i].ToString()).ToString(Utilitario.Constantes.FORMATODECIMAL4) + " %";
							}
						}
						else
						{
							e.Item.Cells[i].Text = "---";
						}
					}
					
				}

			}		
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void ibtnGraficoBarraVentasVSPPTO_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Page.Response.Redirect(URLREPORTEPRESUPUESTOVSVENTASPORPERIODO1 + KEYOPTIONGRAFICO + Utilitario.Constantes.SIGNOIGUAL + "1"
										+ Utilitario.Constantes.SIGNOAMPERSON 
										+ VERSION + Utilitario.Constantes.SIGNOIGUAL + this.IdVersion.ToString()
										+ Utilitario.Constantes.SIGNOAMPERSON 
										+ ANO + Utilitario.Constantes.SIGNOIGUAL + this.Periodo.ToString());		
		}

		private void ibtnGraficoBarra2_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Page.Response.Redirect(URLREPORTEPRESUPUESTOVSVENTASPORPERIODO + KEYOPTIONGRAFICO + Utilitario.Constantes.SIGNOIGUAL + "2"
																			+ Utilitario.Constantes.SIGNOAMPERSON 
																			+ VERSION + Utilitario.Constantes.SIGNOIGUAL + this.IdVersion.ToString()
																			+ Utilitario.Constantes.SIGNOAMPERSON 
																			+ ANO + Utilitario.Constantes.SIGNOIGUAL + this.Periodo.ToString());		
		
		}

	}
}
