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
using SIMA.Controladoras.GestionFinanciera;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;

namespace SIMA.SimaNetWeb.GestionFinanciera.CuentasPorCobrarPagar.Directorio
{
	public class ConsultarDetalleCuentasPorPagarOtros : System.Web.UI.Page, IPaginaBase
	{
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
			this.ibtnFiltrar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnFiltrar_Click);
			this.ibtnEliminarFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminarFiltro_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		protected System.Web.UI.WebControls.ImageButton ImageButton1;
		protected projDataGridWeb.DataGridWeb grid;
		const string URLDETALLEXCEL="ExportarDetalleExcelCtasPagarOtros.aspx?";
		#region IPaginaBase Members
		public void LlenarGrilla()
		{
			
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			
		}

		public DataTable ObtenerDatos()
		{
			CCuentasPorCobrarPagar oCCuentasPorCobrarPagar =  new CCuentasPorCobrarPagar();
			if (Convert.ToInt32(Page.Request.QueryString[KEYQFLAGDIRECTORIO].ToString()) == Constantes.POSICIONINDEXUNO)
			{
				return oCCuentasPorCobrarPagar.ConsultarDetalleSubCuentaPorCobrarPagarAlCierre(
					Convert.ToInt32(Page.Request.QueryString[KEYIDCENTROOPERATIVO]),
					1 ,  
					Convert.ToInt32(Page.Request.QueryString[KEYIDSUBCUENTA]) , 
					Convert.ToInt32(Page.Request.QueryString[KEYIDCUENTA]));
			}
			else
			{
				return oCCuentasPorCobrarPagar.ConsultarDetalleSubCuentaPorCobrarPagar(
					Convert.ToInt32(Page.Request.QueryString[KEYIDCENTROOPERATIVO]),
					1 ,  
					Convert.ToInt32(Page.Request.QueryString[KEYIDSUBCUENTA]) , 
					Convert.ToInt32(Page.Request.QueryString[KEYIDCUENTA]));
			}
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
		{
			DataTable dtProyectos =  ObtenerDatos();
			
			if(dtProyectos!=null)
			{
				dtProyectos = Helper.TablePersonalizado(dtProyectos,"fechaEmision");

				DataView dwProyectos = dtProyectos.DefaultView;
				dwProyectos.Sort = columnaOrdenar ;
				dwProyectos.RowFilter = Helper.ObtenerFiltro(this);
				if(dwProyectos.Count>0)
				{
					Session["EXPORTAREXCEL"]=dtProyectos;
					grid.CurrentPageIndex = indicePagina;
					grid.DataSource = dwProyectos;
					grid.PageSize = Helper.ObtenerCantidadRegistrosPorGrilla();
					
					this.lblResultado.Visible = false;

					double total=0;
					foreach(DataRow dr in dtProyectos.Rows)
						total+= Convert.ToDouble(dr["TotalEnSoles"].ToString());

					grid.Columns[1].FooterText = dwProyectos.Count.ToString();
					grid.Columns[2].FooterText = total.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				}
				else
				{
					Session["EXPORTAREXCEL"]=null;
					grid.DataSource = null;
					lblResultado.Visible = true;
					lblResultado.Text = GRILLAVACIA;
				}
				
			}
			else
			{
				Session["EXPORTAREXCEL"]=null;
				grid.DataSource = dtProyectos;
				lblResultado.Text = GRILLAVACIA;
			}
			
			try
			{
				grid.DataBind();
			}
			catch	
			{
				grid.CurrentPageIndex = Utilitario.Constantes.ValorConstanteCero;
				grid.DataBind();
			}
		}

		public void LlenarCombos()
		{
		}

		public void LlenarDatos()
		{
		}

		public void LlenarJScript()
		{
			string parametos=KEYIDCUENTA +Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYIDCUENTA].ToString() + 
							Utilitario.Constantes.SIGNOAMPERSON + KEYIDSUBCUENTA + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYIDSUBCUENTA].ToString();
				           

			if(((DataTable)Session["EXPORTAREXCEL"])!=null)
				ibtnAbrir.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.PopupBusqueda(URLDETALLEXCEL+parametos,780,640));
			else
				ibtnAbrir.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,"window.alert('No existen datos a exportar')");
		}

		public void RegistrarJScript()
		{
	

		}

		public void Imprimir()
		{
		}

		public void Exportar()
		{
			
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
			return true;
		}

		#endregion
		#region Constantes
		//Query String
		private const string KEYIDSUBCUENTA = "IdCuenta";
		private const string KEYIDCUENTA = "KEYIDCUENTA"; 
		private const string KEYIDCENTROOPERATIVO ="KEYIDCENTROOPERATIVO";
		private const string KEYQFLAGDIRECTORIO= "FlagDirectorio";
		
		//Mensajes
		private const string GRILLAVACIA="No existen registros";
		private const string MENSAJECONSULTAR="Se Consulto el Detalle de Cuentas Por Pagar Otros";
		#endregion
		#region Controles
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminarFiltro;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;
		protected System.Web.UI.WebControls.TextBox txtObservaciones;
		protected System.Web.UI.WebControls.Label lblObservaciones;
		protected System.Web.UI.WebControls.ImageButton ibtnAbrir;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		#endregion
		#region Variables
		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),Helper.ObtenerIndicePagina());
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Utilitario.Enumerados.NombresdeModulo.GestiónComercial.ToString(),this.ToString(),MENSAJECONSULTAR,Enumerados.NivelesErrorLog.I.ToString()));			
					this.LlenarJScript();
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


		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.grid.CurrentPageIndex=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(e.SortExpression),Helper.ObtenerIndicePagina());
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.Header)
			{e.Item.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.POPUPDEESPERA);}

			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				e.Item.Cells[Constantes.POSICIONCONTADOR].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,Utilitario.Helper.MostrarDatosEnCajaTexto(txtObservaciones.ID,dr["Observacion"].ToString()));
				Helper.FiltroporSeleccionConfiguraColumna(e,grid);

				if(Page.Request.QueryString[KEYIDCUENTA] == "14" && Page.Request.QueryString[KEYIDSUBCUENTA] == "5")
				{
					e.Item.Cells[1].Text = String.Empty;
				}
				else if(Page.Request.QueryString[KEYIDCUENTA] == "15" && Page.Request.QueryString[KEYIDSUBCUENTA] == "5")
				{
					e.Item.Cells[1].Text = String.Empty;
				}
			}
		}

		private void ibtnEliminarFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}

		private void ibtnFiltrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			ltlMensaje.Text = Utilitario.Helper.ElaborarFiltro(ObtenerDatos()
				,"RazonSocial" + ";ACREEDOR"
				,"Saldo" + ";IMPORTE"
				,"Fecha"+ ";FECHA"
				);
		}
	}
}
