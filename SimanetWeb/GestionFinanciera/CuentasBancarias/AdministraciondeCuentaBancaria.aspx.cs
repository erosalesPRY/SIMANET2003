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
using SIMA.Controladoras;
using SIMA.Controladoras.General;
using SIMA.Controladoras.GestionFinanciera;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;

namespace SIMA.SimaNetWeb.GestionFinanciera.CuentasBancarias
{
	/// <summary>
	/// Summary description for AdministraciondeCuentaBancaria.
	/// </summary>
	public class AdministraciondeCuentaBancaria : System.Web.UI.Page,IPaginaBase
	{
		#region Constantes
		//Ordenamiento
		const string COLORDENAMIENTO = "Moneda";

		//Nombres de Controles
		const string CONTROLINK = "hlkCuentaBancaria";
		const string CONTROCHECKBOX = "cbxEliminar";
		
		//Paginas
		const int VALORDEFAULT =0;
		const string URLDETALLE = "DetalledeCuentaBancaria.aspx";
		const string URLPRINCIPAL ="../../Default.aspx";  
		//Key Session y QueryString
		const string KEYQIDENTIDAD = "idEntidad";
		const string KEYQIDENTIDADNOMBRE = "Nombre";
		const string KEYQIDCTABCO = "idCtaBco";

		//Otros
		const string GRILLAVACIA ="No existe ninguna Cuenta Bancaria.";  

		//Filtro
		const string NROCUENTABANCARIA = "NroCuentaBancaria";
		const string TIPODECUENTA = "TipoCtaBco";
		const string MONEDA ="Moneda";
		const string ESTADO = "Situacion";
		
		
		#endregion Constantes

		#region Controles
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.ImageButton ibtnAgregar;
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.HtmlControls.HtmlTable TblTabs;
		protected System.Web.UI.WebControls.DropDownList ddlbEntidadFinanciera;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminaFiltro;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminar;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCuenta;
		private   ListItem item =  new ListItem();
		#endregion
		private void Page_Load(object sender, System.EventArgs e)
		{
			this.grid.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(Utilitario.Helper.FooterSpan);
			if(!Page.IsPostBack)
			{
				try
				{
					this.LlenarJScript();
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarCombos();
					this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO),Constantes.INDICEPAGINADEFAULT);
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
			// Put user code to initialize the page here
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
			this.ddlbEntidadFinanciera.SelectedIndexChanged += new System.EventHandler(this.ddlbEntidadFinanciera_SelectedIndexChanged);
			this.ibtnFiltar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnFiltar_Click);
			this.ibtnEliminaFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminaFiltro_Click);
			this.ibtnAgregar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAgregar_Click);
			this.ibtnEliminar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminar_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		private void CargarEntidadFinanciera()
		{
			CEntidadFinanciera oCEntidadFinanciera = new CEntidadFinanciera();
			ddlbEntidadFinanciera.DataSource = oCEntidadFinanciera.ListarTodosCombo();
			ddlbEntidadFinanciera.DataValueField= Enumerados.ColumnasEntidadFinanciera.IdEntidadFinanciera.ToString();
			ddlbEntidadFinanciera.DataTextField=Enumerados.ColumnasEntidadFinanciera.RazonSocial.ToString();
			ddlbEntidadFinanciera.DataBind();
			if(Page.Request.Params[KEYQIDENTIDAD]!= null)
			{
				item = this.ddlbEntidadFinanciera.Items.FindByValue(Page.Request.Params[KEYQIDENTIDAD].ToString());
				if(item!=null)
				{item.Selected = true;}
			}
		}

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add AdministraciondeCuentaBancaria.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministraciondeCuentaBancaria.LlenarGrillaOrdenamiento implementation
		}
		private DataTable ObtenerDatos()
		{
			CCuentaBancaria oCCuentaBancaria = new CCuentaBancaria();
			return oCCuentaBancaria.AdministrarCuentaBancaria(Convert.ToInt32(this.ddlbEntidadFinanciera.SelectedValue),Utilitario.Constantes.IDDEFAULT);
		}
		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dtCuentasBancarias = this.ObtenerDatos();
			if(dtCuentasBancarias!=null)
			{
				DataView dwCuentasBancarias = dtCuentasBancarias.DefaultView;
				dwCuentasBancarias.RowFilter = Helper.ObtenerFiltro();
				grid.Columns[Utilitario.Constantes.POSICIONFOOTERTOTAL].FooterText = Utilitario.Constantes.TEXTOFOOTERTOTAL + " " + dwCuentasBancarias.Count.ToString();
				dwCuentasBancarias.Sort = columnaOrdenar ;
				grid.DataSource = dwCuentasBancarias;
				CImpresion oCImpresion = new CImpresion();
				oCImpresion.GuardarDataImprimirExportar(dtCuentasBancarias,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGOTITULOREPORTECUENTASBANCARIAS),Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGONOMBREARCHIVOREPORTECUENTASBANCARIAS),columnaOrdenar,indicePagina);
			}
			else
			{
				grid.DataSource = dtCuentasBancarias;
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
			// TODO:  Add AdministraciondeCuentaBancaria.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			this.CargarEntidadFinanciera();
			// TODO:  Add AdministraciondeCuentaBancaria.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add AdministraciondeCuentaBancaria.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			ibtnAgregar.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.HistorialIrAdelantePersonalizado(Utilitario.Constantes.VACIO));
			//ibtnAgregar.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnClick.ToString(),Helper.HistorialIrAdelantePersonalizado(""));
			ibtnEliminar.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.ConfirmaEliminacion("hCodigo"));
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministraciondeCuentaBancaria.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministraciondeCuentaBancaria.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministraciondeCuentaBancaria.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			if(CNetAccessControl.FindPage(Page.Request.Url.AbsolutePath.ToString()))
			{CNetAccessControl.LoadControls(this);}
			else
			{CNetAccessControl.RedirectPageError();}
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add AdministraciondeCuentaBancaria.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				Helper.ConfiguraColumnaHyperLink(Utilitario.Enumerados.EventosJavaScript.OnClick,e.Item.Cells[0],grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex,
						Helper.HistorialIrAdelantePersonalizado("ddlbEntidadFinanciera"),
						Helper.MostrarVentana(URLDETALLE + Utilitario.Constantes.SIGNOINTERROGACION ,
												KEYQIDENTIDAD + Constantes.SIGNOIGUAL + Convert.ToString(dr[Enumerados.FINColumnaCuentaBancaria.identidadfinanciera.ToString()]) 
												+ Constantes.SIGNOAMPERSON 
												+ KEYQIDCTABCO + Constantes.SIGNOIGUAL + Convert.ToString(dr[Enumerados.FINColumnaCuentaBancaria.idcuentabancaria.ToString()]) 
												+ Constantes.SIGNOAMPERSON  
												+ KEYQIDENTIDADNOMBRE + Constantes.SIGNOIGUAL  + this.ddlbEntidadFinanciera.SelectedItem.Text.ToString()
												+  Constantes.SIGNOAMPERSON + 
												Constantes.KEYMODOPAGINA +  Constantes.SIGNOIGUAL + Enumerados.ModoPagina.M.ToString()));

				HyperLink hlk = (HyperLink)e.Item.Cells[0].FindControl(CONTROLINK);
				hlk.Text = Convert.ToString(dr[Enumerados.FINColumnaCuentaBancariaSaldo.NroCuentaBancaria.ToString()]);

				HtmlInputRadioButton rb = (HtmlInputRadioButton)e.Item.Cells[6].Controls[0];
//				string fcScript = Helper.MostrarDatosEnCajaTexto("hCodigo",Convert.ToString(dr[Enumerados.FINColumnaCuentaBancaria.idcuentabancaria.ToString()])) + ";" + Helper.MostrarDatosEnCajaTexto("hCuenta",e.Item.Cells[1].Text.ToString());
//				rb.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
//									fcScript);
				rb.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
								Helper.MostrarDatosEnCajaTexto("hCodigo",Convert.ToString(dr[Enumerados.FINColumnaCuentaBancaria.idcuentabancaria.ToString()])) 
								+ Utilitario.Constantes.SIGNOPUNTOYCOMA 
								+ Helper.MostrarDatosEnCajaTexto("hCuenta",e.Item.Cells[1].Text.ToString())
								);
				//Helper.SeleccionarItemGrillaOnClickMoverRaton(e,fcScript);
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,
																Helper.MostrarDatosEnCajaTexto("hCodigo",Convert.ToString(dr[Enumerados.FINColumnaCuentaBancaria.idcuentabancaria.ToString()])) 
																+ Utilitario.Constantes.SIGNOPUNTOYCOMA 
																+ Helper.MostrarDatosEnCajaTexto("hCuenta",e.Item.Cells[1].Text.ToString())
															);
				Helper.FiltroporSeleccionConfiguraColumna(e,grid);
			}			
		}

		private void ibtnAgregar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.redireccionaPaginaAgregar();
		}
		private void redireccionaPaginaAgregar()
		{
			
			Page.Response.Redirect
				(
				URLDETALLE + Utilitario.Constantes.SIGNOINTERROGACION 
				+ Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.N.ToString()
				+ Utilitario.Constantes.SIGNOAMPERSON + 
				KEYQIDENTIDAD + Constantes.SIGNOIGUAL + this.ddlbEntidadFinanciera.SelectedValue.ToString()
				+ Utilitario.Constantes.SIGNOAMPERSON  
				+ KEYQIDENTIDADNOMBRE + Constantes.SIGNOIGUAL  + this.ddlbEntidadFinanciera.SelectedItem.Text.ToString()
				);
			
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			grid.CurrentPageIndex=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(e.SortExpression),Helper.ObtenerIndicePagina());
		}

		private void ibtnEliminaFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}

		private void ibtnFiltar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			ltlMensaje.Text= Utilitario.Helper.ElaborarFiltro(this.ObtenerDatos(),NROCUENTABANCARIA
																				 ,Utilitario.Constantes.SIGNOASTERISCO + TIPODECUENTA + "; Tipo de Cuenta"
																				 ,Utilitario.Constantes.SIGNOASTERISCO + MONEDA + ";Moneda"
																				 ,Utilitario.Constantes.SIGNOASTERISCO + ESTADO + ";Estado");
		
		}

		private void ibtnEliminar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				if(Page.IsValid)
				{
					this.Eliminar();
				}
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

		private void Eliminar()
		{
			RowSelectorColumn rSel = RowSelectorColumn.FindColumn(grid);
			
			if(rSel.SelectedIndexes.Length==Utilitario.Constantes.ValorConstanteCero)
			{
				ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO));
			}
			else
			{
				CCuentaBancaria oCCuentaBancaria = new CCuentaBancaria();
				if(oCCuentaBancaria.Eliminar(Convert.ToInt32(this.hCodigo.Value.ToString()),CNetAccessControl.GetIdUser())>0)
				{
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"CuentaBancaria",this.ToString(),"Se eliminó la Cuenta Nro. " + this.hCuenta.Value.ToString() + Utilitario.Constantes.SIMBOLOPUNTO ,Enumerados.NivelesErrorLog.I.ToString()));
					this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),Helper.ObtenerIndicePagina());
					ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONELIMINACIONREGISTRO));
				}
			}
		}

		private void ddlbEntidadFinanciera_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO),Constantes.INDICEPAGINADEFAULT);
		}

	}
}
