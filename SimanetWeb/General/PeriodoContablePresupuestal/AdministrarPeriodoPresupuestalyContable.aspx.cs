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
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using NullableTypes;
using MetaBuilders.WebControls;
using System.Diagnostics; 


namespace SIMA.SimaNetWeb.General.PeriodoContablePresupuestal
{
	/// <summary>
	/// Summary description for AdministrarPeriodoPresupuestalyContable.
	/// </summary>
	public class AdministrarPeriodoPresupuestalyContable : System.Web.UI.Page,IPaginaBase
	{
		const string URLDETALLE= "DetallePeriodoPresupuestalyContable.aspx";
		const string KEYQPERIODO= "Periodo";

		protected System.Web.UI.WebControls.ImageButton ibtnAgregar;
		protected projDataGridWeb.DataGridWeb grid;
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					this.LlenarJScript();
					Helper.ReiniciarSession();
					this.LlenarCombos();
					Helper.ReestablecerPagina(this);
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionFinanciera",this.ToString(),"Se consultó Carta de Crédito.",Enumerados.NivelesErrorLog.I.ToString()));
					this.LlenarGrilla();
				}
				catch(SIMAExcepcionLog oSIMAExcepcionLog)
				{
					//ltlMensaje.Text = Helper.MensajeAlert(oSIMAExcepcionLog.Mensaje);					
					Helper.MsgBox(oSIMAExcepcionLog.Mensaje);
				}
				catch(SIMAExcepcionIU oSIMAExcepcionIU)
				{
					//ltlMensaje.Text = Helper.MensajeAlert(oSIMAExcepcionIU.Mensaje);
					Helper.MsgBox(oSIMAExcepcionIU.Mensaje);
				}
				catch(SIMAExcepcionDominio oSIMAExcepcionDominio)
				{
					//ltlMensaje.Text = Helper.MensajeAlert(oSIMAExcepcionDominio.Mensaje);
					Helper.MsgBox(oSIMAExcepcionDominio.Mensaje);
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
			this.ibtnAgregar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAgregar_Click);
			this.grid.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemCreated);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		private DataTable ObtenerDatos(){
			return (new CPeriodo()).ListarTodosGrilla();	
		}

		public void LlenarGrilla()
		{
			DataTable dt = this.ObtenerDatos();
			if(dt!=null)
			{
				grid.DataSource = dt;
			}
			try
			{
				grid.DataBind();
			}
			catch	
			{
				grid.CurrentPageIndex = 0;
				grid.DataBind();
			}
		}


		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarPeriodoPresupuestalyContable.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add AdministrarPeriodoPresupuestalyContable.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add AdministrarPeriodoPresupuestalyContable.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add AdministrarPeriodoPresupuestalyContable.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			this.ibtnAgregar.Attributes[Utilitario.Enumerados.EventosJavaScript.OnClick.ToString()] = Helper.HistorialIrAdelantePersonalizado("");
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarPeriodoPresupuestalyContable.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministrarPeriodoPresupuestalyContable.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarPeriodoPresupuestalyContable.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add AdministrarPeriodoPresupuestalyContable.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add AdministrarPeriodoPresupuestalyContable.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType==ListItemType.Header)
			{
				
				DataGridItem di = new DataGridItem(e.Item.ItemIndex-1,0,ListItemType.Header);
				for(int i=0;i<=grid.Columns.Count-1;i++)
				{
					TableCell tc = new TableCell();
					if((i==0)||(i==1))
					{
						tc.RowSpan=2;
						//tc.Style.Add("width","25%");
						string Titulo = ((i==0)?"NRO":"PERIODO");
						tc.Controls.Add(new LiteralControl(Titulo));
					}
					else if(i==2)
					{
						tc.Text="REFERENCIA";
						tc.ColumnSpan=2;
					}
					else if(i==3)
					{
						tc.Visible=false;
					}
					di.Cells.Add(tc);
				}
				DataGrid dg = (DataGrid)sender;
				Table t = (Table)dg.Controls[0];
				t.Rows.Add(di);		
			}
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType==ListItemType.Header)
			{
				e.Item.Cells[0].Visible=false;
				e.Item.Cells[1].Visible=false;

			}
			else if((e.Item.ItemType==ListItemType.Item)||(e.Item.ItemType==ListItemType.AlternatingItem)){
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				Helper.ConfiguraColumnaHyperLink(e.Item.Cells[0],grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex,
					Helper.HistorialIrAdelantePersonalizado(""),
					Helper.MostrarVentana(URLDETALLE+ Utilitario.Constantes.SIGNOINTERROGACION
					+ KEYQPERIODO +  Utilitario.Constantes.SIGNOIGUAL +  dr["Periodo"].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON 
					+ Utilitario.Constantes.KEYMODOPAGINA +  Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.M.ToString()
					));


				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);

			}
		}

		private void ibtnAgregar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Page.Response.Redirect(URLDETALLE+ Utilitario.Constantes.SIGNOINTERROGACION + Utilitario.Constantes.KEYMODOPAGINA +  Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.N.ToString());
		}
	}
}
