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


namespace SIMA.SimaNetWeb.GestionFinanciera.OrdendeCompra
{
	public class AdministrarOrdendeCompra : System.Web.UI.Page,IPaginaBase
	{
		#region Constantes
			const string GRILLAVACIA ="No existe ningún Registro.";  
			const string URLDETALLE="DetalleOrdendeCompra.aspx?";

			const string  KEYIDNROORDENCOMPRA="NroOC";
			const string  KEYIDPERIODO="Periodo";

		//Otros
		const string CTRLBUSCAR ="txtBuscar";		
		
		#endregion
		#region Controles
			protected System.Web.UI.WebControls.Label lblRutaPagina;
			protected System.Web.UI.WebControls.Label lblPagina;
			protected System.Web.UI.WebControls.ImageButton ibtnEliminaFiltro;
			protected System.Web.UI.WebControls.Label Label3;
			protected System.Web.UI.WebControls.ImageButton imgbtnImportarP;
			protected System.Web.UI.WebControls.ImageButton imgbtnImportar;
			protected projDataGridWeb.DataGridWeb grid;
			protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPaginaSort;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		protected System.Web.UI.WebControls.ImageButton ibtnAgregar;
			protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			this.grid.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(Utilitario.Helper.FooterSpan);
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
			this.ibtnEliminaFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminaFiltro_Click);
			this.imgbtnImportarP.Click += new System.Web.UI.ImageClickEventHandler(this.imgbtnImportarP_Click);
			this.imgbtnImportar.Click += new System.Web.UI.ImageClickEventHandler(this.imgbtnImportar_Click);
			this.ibtnAgregar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAgregar_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add AdministrarOrdendeCompra.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarOrdendeCompra.LlenarGrillaOrdenamiento implementation
		}
		private DataTable ObtenerDatos()
		{
			return ((COrdendeCompra) new COrdendeCompra()).AdministrarDetalledeOrdendeCompra(Utilitario.Constantes.IDDEFAULT,Utilitario.Constantes.IDDEFAULT.ToString(),CNetAccessControl.GetIdUser());
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dtOrdenCompra = this.ObtenerDatos();
			if(dtOrdenCompra!=null)
			{
				DataView dwOrdenCompra = dtOrdenCompra.DefaultView;
				dwOrdenCompra.RowFilter = Helper.ObtenerFiltro();
				dwOrdenCompra.Sort = columnaOrdenar ;
				grid.Columns[Utilitario.Constantes.POSICIONFOOTERTOTAL].FooterText = Utilitario.Constantes.TEXTOFOOTERTOTAL + Utilitario.Constantes.ESPACIO + dwOrdenCompra.Count.ToString();
				grid.DataSource = dwOrdenCompra;
				grid.CurrentPageIndex = indicePagina;
				lblResultado.Visible = false;

			}
			else
			{
				grid.DataSource = dtOrdenCompra;
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

		public void LlenarCombos()
		{
			// TODO:  Add AdministrarOrdendeCompra.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add AdministrarOrdendeCompra.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			ibtnAgregar.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnMouseDown.ToString(),Helper.HistorialIrAdelantePersonalizado(String.Empty));
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarOrdendeCompra.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministrarOrdendeCompra.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarOrdendeCompra.Exportar implementation
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
			// TODO:  Add AdministrarOrdendeCompra.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				Helper.ConfiguraColumnaHyperLink(e.Item.Cells[0],grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex,
									Helper.HistorialIrAdelantePersonalizado("hGridPaginaSort","hGridPagina"),
									Helper.MostrarVentana(URLDETALLE,KEYIDNROORDENCOMPRA + Utilitario.Constantes.SIGNOIGUAL + dr[Utilitario.Enumerados.FinColumnaOrdendeCompra.NroOrdenCompra.ToString()].ToString()
																	+ Utilitario.Constantes.SIGNOAMPERSON
																	+ KEYIDPERIODO + Utilitario.Constantes.SIGNOIGUAL + dr[Utilitario.Enumerados.FinColumnaOrdendeCompra.Periodo.ToString()].ToString()
																	+ Utilitario.Constantes.SIGNOAMPERSON
																	+ Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Enumerados.ModoPagina.M.ToString()));

				Helper.FiltroporSeleccionConfiguraColumna(e,grid,true,CTRLBUSCAR);
				
				e.Item.Cells[5].Text = Convert.ToDouble(e.Item.Cells[5].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
			}			
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.hGridPagina.Value=e.NewPageIndex.ToString();
			grid.CurrentPageIndex=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);	
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			hGridPaginaSort.Value=Helper.GenerarExpresionOrdenamiento(e.SortExpression);
			this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Helper.ObtenerIndicePagina());
		}

		private void ibtnEliminaFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}

		private void imgbtnImportarP_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				int i = ((CProveedor) new CProveedor()).ImportarProveedor();
				ASPNetUtilitario.MessageBox.Show(Utilitario.Helper.ObtenerValorString(Utilitario.Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionFinanciera.ToString(), Utilitario.Mensajes.CODIGOMENSAJECONFIRMACIONORDENDECOMPRAIMPORTACION)  /*"Importación termino con exito.."*/);
				this.LlenarGrillaOrdenamientoPaginacion(String.Empty,Utilitario.Constantes.ValorConstanteCero);
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
				int i = ((CCartaCredito) new CCartaCredito()).ImportarOrdendeCompra();
				ASPNetUtilitario.MessageBox.Show(Utilitario.Helper.ObtenerValorString(Utilitario.Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionFinanciera.ToString(), Utilitario.Mensajes.CODIGOMENSAJECONFIRMACIONORDENDECOMPRAIMPORTACION)  /*"Importación termino con exito.."*/);
				this.LlenarGrillaOrdenamientoPaginacion(String.Empty,Utilitario.Constantes.ValorConstanteCero);
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

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void ibtnAgregar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Page.Response.Redirect(URLDETALLE + Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Enumerados.ModoPagina.N.ToString());
		}
	}
}
