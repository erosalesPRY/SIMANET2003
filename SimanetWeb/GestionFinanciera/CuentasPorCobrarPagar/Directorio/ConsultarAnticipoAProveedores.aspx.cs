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
using NetAccessControl;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using SIMA.Controladoras.GestionFinanciera;


namespace SIMA.SimaNetWeb.GestionFinanciera.CuentasPorCobrarPagar.Directorio
{
	/// <summary>
	/// Summary description for ConsultarAnticipoAProveedores.
	/// </summary>
	public class ConsultarAnticipoAProveedores : System.Web.UI.Page,IPaginaBase
	{
		#region Constantes
			const string KEYQIDTIPOCUENTA = "IdTipoCuenta";
			const string KEYQIDCUENTAPORCOBRARPAGAR = "IdCuenta";
			const string KEYQIDSUBCUENTAPORCOBRARPAGAR = "IdSubCuenta";
			const string KEYQIDCENTROOPERATIVO= "IdCentroOperativo";
			const string KEYQDESCRIPCION = "Descripcion";
			const string KEYQDESCRIPCIONCUENTA = "Cuenta";
			const string KEYQDESCRIPCIONSUBCUENTA = "SubCuenta";
			const string KEYQFLAGDIRECTORIO= "FlagDirectorio";
			const string URLDETALLEXCEL="ExportarDetalleExcelAnticiposProveedores.aspx?";
			const int IDANTICIPOPROVEEDOR = 3;


			/*Parametros para la Pagina de detalle*/
			const string KEYQENTIDAD = "idEntidad";
			const string KEYQRAZONSOCIAL="Rsocial";
			const string KEYQNRODOCUMENTO = "Ndoc";
			const string URLPAGINADETALLE = "ConsultarDetalleCuentasPorCobraryPagar.aspx?";
			const string KEYQIDAJUSTE = "idAjuste";



			//Otros
			const string GRILLAVACIA ="No existe ninguna SubCuenta";  
			const string TXTOBSERVACION ="txtConcepto";  
			const string TOTALIZA ="Totaliza";
		#endregion
		#region Atributos
			protected int idCentroOperativo{get{return Convert.ToInt32(Page.Request.Params[KEYQIDCENTROOPERATIVO]);}}
			protected int idTipodeCuenta{get{return Convert.ToInt32(Page.Request.Params[KEYQIDTIPOCUENTA]);}}
			protected int idCuentaPosCobrarPagar{get{return Convert.ToInt32(Page.Request.Params[KEYQIDCUENTAPORCOBRARPAGAR]);}}
			protected int idSubCuentaPosCobrarPagar{get{return Convert.ToInt32(Page.Request.Params[KEYQIDSUBCUENTAPORCOBRARPAGAR]);}}
			protected string Descripcion{get{return Page.Request.Params[KEYQDESCRIPCION].ToString();}}
		#endregion

		#region Controles
			protected System.Web.UI.WebControls.Label lblRutaPagina;
			protected System.Web.UI.WebControls.Label lblPagina;
			protected System.Web.UI.WebControls.Label lblPrimario;
			protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;
			protected System.Web.UI.WebControls.ImageButton ibtnEliminarFiltro;
			protected projDataGridWeb.DataGridWeb grid;
			protected System.Web.UI.WebControls.Label lblResultado;
			protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
			protected System.Web.UI.HtmlControls.HtmlInputHidden hOrdenGrilla;
			protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.WebControls.ImageButton ibtnAbrir;
			protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();

					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"CuentasPorPagar",this.ToString(),"Se consultó la Cuentas Por Pagar",Enumerados.NivelesErrorLog.I.ToString()));
					Helper.SeleccionarItemCombos(this);
					this.LlenarJScript();
					
					this.LlenarGrillaOrdenamientoPaginacion(this.hOrdenGrilla.Value,Convert.ToInt32(this.hGridPagina.Value));				
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
			this.ibtnFiltrar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnFiltrar_Click);
			this.ibtnEliminarFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminarFiltro_Click);
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
			// TODO:  Add ConsultarAnticipoAProveedores.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarAnticipoAProveedores.LlenarGrillaOrdenamiento implementation
		}

		protected DataTable ObtenerDatos
		{
			get
			{
				if (Convert.ToInt32(Page.Request.QueryString[KEYQFLAGDIRECTORIO]) == Constantes.POSICIONINDEXUNO)
				{
					return ((CCuentasPorCobrarPagar) new CCuentasPorCobrarPagar()).ConsultarDetalleSubCuentaPorCobrarPagarAlCierre(
						this.idCentroOperativo,
						this.idTipodeCuenta,
						this.idCuentaPosCobrarPagar,
						this.idSubCuentaPosCobrarPagar);
				}
				else
				{
					return ((CCuentasPorCobrarPagar) new CCuentasPorCobrarPagar()).ConsultarDetalleSubCuentaPorCobrarPagar(
						this.idCentroOperativo,
						this.idTipodeCuenta,
						this.idCuentaPosCobrarPagar,
						this.idSubCuentaPosCobrarPagar);
				}				
			}
		}

		private void Totalizar(DataTable dtOrigen)
		{
			ArrayList arrTotal = new ArrayList();
			double TotalEnSoles = Helper.TotalizarDataView(dtOrigen.DefaultView,"TotalEnSoles")[0];
			Session[TOTALIZA] = TotalEnSoles;
		}


		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			this.lblPrimario.Text= this.Descripcion;

			DataTable dtCuentasPorPagar = this.ObtenerDatos;
			if(dtCuentasPorPagar!=null)
			{
				dtCuentasPorPagar = Helper.TablePersonalizado(dtCuentasPorPagar, "FechaEmision");

				this.Totalizar(dtCuentasPorPagar);

				DataView dwCuentasPorPagar = dtCuentasPorPagar.DefaultView;
				dwCuentasPorPagar.Sort = columnaOrdenar ;
				dwCuentasPorPagar.RowFilter = Utilitario.Helper.ObtenerFiltro();

				if (dwCuentasPorPagar.Count == 0)
				{
					grid.DataSource = null; 
					lblResultado.Text = GRILLAVACIA;
					lblResultado.Visible = true;
				}
				else
				{
					Session["EXPORTAREXCEL"]=dtCuentasPorPagar;
					grid.DataSource = dwCuentasPorPagar;
					grid.CurrentPageIndex =indicePagina;
					grid.PageSize = Helper.ObtenerCantidadRegistrosPorGrilla(7,12,18);
					grid.Columns[Constantes.POSICIONTOTAL].FooterText = dwCuentasPorPagar.Count.ToString();
					lblResultado.Visible = false;
				}
			}
			else
			{
				grid.DataSource = dtCuentasPorPagar;
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
			// TODO:  Add ConsultarAnticipoAProveedores.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add ConsultarAnticipoAProveedores.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			
			
			ibtnAbrir.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.PopupBusqueda(URLDETALLEXCEL,780,640));
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarAnticipoAProveedores.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarAnticipoAProveedores.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarAnticipoAProveedores.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add ConsultarAnticipoAProveedores.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ConsultarAnticipoAProveedores.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.Header)
			{e.Item.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.POPUPDEESPERA);}

			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				e.Item.Cells[1].ToolTip = "R.U.C: " + dr[Enumerados.FINColumnaResumenCuentasPorPagar.NroRuc.ToString()].ToString();
				//e.Item.Cells[Constantes.POSICIONCONTADOR].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);

				string Parametros  = KEYQIDCENTROOPERATIVO  + Utilitario.Constantes.SIGNOIGUAL +  Page.Request.Params[KEYQIDCENTROOPERATIVO].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYQRAZONSOCIAL + Utilitario.Constantes.SIGNOIGUAL + e.Item.Cells[1].Text
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYQIDTIPOCUENTA  + Utilitario.Constantes.SIGNOIGUAL +  Page.Request.Params[KEYQIDTIPOCUENTA].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYQIDCUENTAPORCOBRARPAGAR  + Utilitario.Constantes.SIGNOIGUAL +  Page.Request.Params[KEYQIDCUENTAPORCOBRARPAGAR].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYQIDSUBCUENTAPORCOBRARPAGAR  + Utilitario.Constantes.SIGNOIGUAL +  Page.Request.Params[KEYQIDSUBCUENTAPORCOBRARPAGAR].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYQENTIDAD + Utilitario.Constantes.SIGNOIGUAL +  dr["idEntidad"].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYQNRODOCUMENTO + Utilitario.Constantes.SIGNOIGUAL +  dr["num_doc_ana"].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYQDESCRIPCION + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYQDESCRIPCION].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYQIDAJUSTE + Utilitario.Constantes.SIGNOIGUAL + dr["idAjuste"].ToString();

				
				Helper.ConfiguraColumnaHyperLink(e.Item.Cells[0],grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex,Helper.PopupDialogoModal(URLPAGINADETALLE + Parametros ,700,300,false));





				TextBox txt  = (TextBox) e.Item.Cells[5].FindControl(TXTOBSERVACION);
				txt.Text = dr[Enumerados.FINColumnaResumenCuentasPorPagar.Descripcion.ToString()].ToString();
				Helper.FiltroporSeleccionConfiguraColumna(e,grid);
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
			}
			if(e.Item.ItemType == ListItemType.Footer)
			{
				e.Item.Cells[2].Text = Convert.ToDouble(Session[TOTALIZA]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
			}
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void ibtnEliminarFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.hGridPagina.Value = e.NewPageIndex.ToString();
			this.LlenarGrillaOrdenamientoPaginacion(this.hOrdenGrilla.Value,e.NewPageIndex);
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.hOrdenGrilla.Value = Helper.GenerarExpresionOrdenamiento(e.SortExpression);
			this.LlenarGrillaOrdenamientoPaginacion(this.hOrdenGrilla.Value,Helper.ObtenerIndicePagina());
		}

		private void ibtnFiltrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			ltlMensaje.Text= Utilitario.Helper.ElaborarFiltro(this.ObtenerDatos,"../../../Filtros.aspx"
				,Enumerados.FINColumnaResumenCuentasPorPagar.RazonSocial.ToString() + ";Cliente"
				,Enumerados.FINColumnaResumenCuentasPorPagar.NroRuc.ToString() + ";Nro. Ruc"
				,Enumerados.FINColumnaResumenCuentasPorPagar.Num_Doc_Ana.ToString() + ";Factura"
				,Enumerados.FINColumnaResumenCuentasPorPagar.FechaEmision.ToString() + ";Fecha"
				,Enumerados.FINColumnaResumenCuentasPorPagar.TotalEnSoles.ToString() + ";Saldo"
				,Enumerados.FINColumnaResumenCuentasPorPagar.Descripcion.ToString()+ ";Concepto");
		
		}
	}
}
