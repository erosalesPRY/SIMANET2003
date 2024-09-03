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

namespace SIMA.SimaNetWeb.GestionFinanciera.PresupuestoVarios
{
	public class AdministrarTipodePresupuesto : System.Web.UI.Page,IPaginaBase
	{
		#region Constantes
			const string GRILLAVACIA ="No existe ningún Registro.";  
			const string KEYIDTIPOPRESUPUESTO ="idTipoPresupuesto";
			const string KEYIDNOMBRETIPOPRESUPUESTO ="NombreTipoPresupuesto";
			const string KEYIDPERIODO ="periodo";
  			const string KEYIDMES ="idMes";
			const string KEYIDNOMBREMES ="NombreMes";
			const string URLPRESUPUESTOCUENTA ="AdministrarTipodePresupuestoCuentas.aspx?";
			const string URLPRESUPUESTOCUENTAGRUPO ="AdministrarTipodePresupuestoCuentasGruposCC.aspx?";
			const string URLPRESUPUESTOFINAICIAMIENTO="AdministrarPresupuestodeFinanciamiento.aspx?";
			
			const string LBLPPTO="lblPresupuesto";
			const string LBLREAL="lblReal";
			const string LBLSALDO="lblSaldo";

		//Otros
		const string SESSIONFINPPTOCO ="finPPTOCO";

		//DataGrid and DataTable
		const string COLUMNAIDTIPOPTO ="idTipoPresupuesto";
		const string COLUMNANOMBRE ="Nombre";
		const string COLUMNAMONTOPTO ="MontoPresupuesto";
		const string COLUMNAMONTOREAL ="MontoReal";
		const string COLUMNASALDO ="Saldo";
 
		
		#endregion
		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DropDownList ddlbPeriodo;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.DropDownList dddblMes;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPaginaSort;
		protected System.Web.UI.WebControls.ImageButton imgbtnImportar;
		protected System.Web.UI.WebControls.ImageButton imgbtnImportarP;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion
		private void Page_Load(object sender, System.EventArgs e)
		{
			this.grid.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(Utilitario.Helper.FooterSpan);
			Session[SESSIONFINPPTOCO] =null;

			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					this.LlenarJScript();
					Helper.ReiniciarSession();
					this.LlenarCombos();
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Auditoria",this.ToString(),"Se consultó las Acciones Correctivas.",Enumerados.NivelesErrorLog.I.ToString()));
					this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Convert.ToInt32(this.hGridPagina.Value));
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
					ltlMensaje.Text = Helper.MsgdbErrMostrarMesaje(true,oSIMAExcepcionDominio.Error.ToString());					
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
			this.ddlbPeriodo.SelectedIndexChanged += new System.EventHandler(this.ddlbPeriodo_SelectedIndexChanged);
			this.dddblMes.SelectedIndexChanged += new System.EventHandler(this.dddblMes_SelectedIndexChanged);
			this.imgbtnImportarP.Click += new System.Web.UI.ImageClickEventHandler(this.imgbtnImportarP_Click);
			this.imgbtnImportar.Click += new System.Web.UI.ImageClickEventHandler(this.imgbtnImportar_Click);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add AdministrarTipodePresupuesto.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarTipodePresupuesto.LlenarGrillaOrdenamiento implementation
		}

		private DataTable ObtenerDatos()
		{
			return ((CTipoPresupuesto)new CTipoPresupuesto()).AdministrarDetalleTiposdePresupuesto(
																									Utilitario.Constantes.IDDEFAULT
																									,Convert.ToInt32(this.ddlbPeriodo.SelectedValue)
																									,Convert.ToInt32(this.dddblMes.SelectedValue));
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			
			DataTable dt = this.ObtenerDatos();

			if(dt!=null)
			{
				DataView dw = dt.DefaultView;
				dw.Sort = columnaOrdenar ;
				dw.RowFilter= Utilitario.Helper.ObtenerFiltro();
				grid.Columns[Utilitario.Constantes.POSICIONFOOTERTOTAL].FooterText = Utilitario.Constantes.TEXTOFOOTERTOTAL + Utilitario.Constantes.ESPACIO + dw.Count.ToString();
				grid.DataSource = dw;
				grid.CurrentPageIndex =indicePagina;
				lblResultado.Visible = false;

			}
			else
			{
				grid.DataSource = dt;
				lblResultado.Visible = true;
				lblResultado.Text = GRILLAVACIA;
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

		private void llenarMes()
		{
			dddblMes.DataSource = ((CPeriodoContable)new CPeriodoContable()).ListarMes();
			dddblMes.DataValueField=Enumerados.Mes.idMes.ToString();
			dddblMes.DataTextField=Enumerados.Mes.NombreMes.ToString();
			dddblMes.DataBind();
			int idmes = DateTime.Now.Month;
			ListItem item = dddblMes.Items.FindByValue(idmes.ToString());
			if(item!=null)
			{item.Selected = true;}
		}
		private void llenarPeriodo()
		{
			ddlbPeriodo.DataSource = ((CPeriodoContable)new CPeriodoContable()).ListarPeriodo();
			ddlbPeriodo.DataValueField="Periodo";
			ddlbPeriodo.DataTextField="Periodo";
			ddlbPeriodo.DataBind();
			int idAnio = DateTime.Now.Year;
			ListItem item = ddlbPeriodo.Items.FindByValue(idAnio.ToString());
			if(item!=null)
			{item.Selected = true;}
		}
		public void LlenarCombos()
		{
			this.llenarMes();
			this.llenarPeriodo();
		}

		public void LlenarDatos()
		{
			// TODO:  Add AdministrarTipodePresupuesto.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add AdministrarTipodePresupuesto.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarTipodePresupuesto.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministrarTipodePresupuesto.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarTipodePresupuesto.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			if(CNetAccessControl.FindPage(Page.Request.Url.AbsolutePath.ToString()))
			{
				CNetAccessControl.LoadControls(this);
			}
			else
			{
				CNetAccessControl.RedirectPageError();
			}
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add AdministrarTipodePresupuesto.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);

				string parametros = KEYIDTIPOPRESUPUESTO + Utilitario.Constantes.SIGNOIGUAL + dr[COLUMNAIDTIPOPTO].ToString()
									+ Utilitario.Constantes.SIGNOAMPERSON
									+ KEYIDNOMBRETIPOPRESUPUESTO + Utilitario.Constantes.SIGNOIGUAL + dr[COLUMNANOMBRE].ToString()
									+ Utilitario.Constantes.SIGNOAMPERSON
									+ KEYIDPERIODO + Utilitario.Constantes.SIGNOIGUAL + this.ddlbPeriodo.SelectedValue.ToString()
									+ Utilitario.Constantes.SIGNOAMPERSON
									+ KEYIDMES + Utilitario.Constantes.SIGNOIGUAL + this.dddblMes.SelectedValue.ToString()
									+ Utilitario.Constantes.SIGNOAMPERSON
									+ KEYIDNOMBREMES + Utilitario.Constantes.SIGNOIGUAL + this.dddblMes.SelectedItem.Text.ToString();

				Helper.ConfiguraColumnaHyperLink(e.Item.Cells[0],grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex,
					Helper.HistorialIrAdelantePersonalizado(this.ddlbPeriodo.ID.ToString(),this.dddblMes.ID.ToString()),
					Helper.MostrarVentana(((Convert.ToInt32(dr[COLUMNAIDTIPOPTO])==5)?URLPRESUPUESTOFINAICIAMIENTO: URLPRESUPUESTOCUENTAGRUPO) ,parametros));

				((Label) e.Item.Cells[2].FindControl(LBLPPTO)).Text = Convert.ToDouble( dr[COLUMNAMONTOPTO]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				((Label) e.Item.Cells[2].FindControl(LBLREAL)).Text = Convert.ToDouble( dr[COLUMNAMONTOREAL]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				((Label) e.Item.Cells[2].FindControl(LBLSALDO)).Text = Convert.ToDouble( dr[COLUMNASALDO]).ToString(Utilitario.Constantes.FORMATODECIMAL4);


			}			
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void ddlbPeriodo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Convert.ToInt32(this.hGridPagina.Value));
		}

		private void dddblMes_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Convert.ToInt32(this.hGridPagina.Value));
		}

		private void imgbtnImportarP_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				int i = ((CPresupuesto) new CPresupuesto()).ImportarPresupuesto(Convert.ToInt32(this.ddlbPeriodo.SelectedValue));
				//ASPNetUtilitario.MessageBox.Show("Importación termino con exito..");
				ASPNetUtilitario.MessageBox.Show(Utilitario.Helper.ObtenerValorString(Utilitario.Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionFinanciera.ToString(), Utilitario.Mensajes.CODIGOMENSAJECONFIRMACIONPTOVARIOSIMPORTACION));
				this.LlenarGrillaOrdenamientoPaginacion(String.Empty, Utilitario.Constantes.ValorConstanteCero);
				this.grid.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(Utilitario.Helper.FooterSpan);
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
				ltlMensaje.Text = Helper.MsgdbErrMostrarMesaje(true,oSIMAExcepcionDominio.Error.ToString());					
			}
			catch(Exception oException)
			{
				ASPNetUtilitario.MessageBox.Show(oException.Message.ToString());
				SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Utilitario.Constantes.CODIGOERRORGENERICO,oException.Message);
				Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
			}
			

		}

		private void imgbtnImportar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				int i = ((CPresupuesto) new CPresupuesto()).ImportarSaldosContables(Convert.ToInt32(this.ddlbPeriodo.SelectedValue),Convert.ToInt32(this.dddblMes.SelectedValue));
				//ASPNetUtilitario.MessageBox.Show("Importación termino con exito..");
				ASPNetUtilitario.MessageBox.Show(Utilitario.Helper.ObtenerValorString(Utilitario.Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionFinanciera.ToString(), Utilitario.Mensajes.CODIGOMENSAJECONFIRMACIONPTOVARIOSIMPORTACION));
				this.LlenarGrillaOrdenamientoPaginacion(String.Empty, Utilitario.Constantes.ValorConstanteCero);
				this.grid.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(Utilitario.Helper.FooterSpan);
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
				ltlMensaje.Text = Helper.MsgdbErrMostrarMesaje(true,oSIMAExcepcionDominio.Error.ToString());					
			}
			catch(Exception oException)
			{
				ASPNetUtilitario.MessageBox.Show(oException.Message.ToString());
				SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Utilitario.Constantes.CODIGOERRORGENERICO,oException.Message);
				Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
			}
		
		}
	}
}
