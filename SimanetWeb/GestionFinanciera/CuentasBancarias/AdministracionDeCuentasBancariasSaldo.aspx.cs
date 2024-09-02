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
	/// Summary description for RequerimientosAsignados.
	/// </summary>
	public class AdministracionDeCuentasBancariasSaldo : System.Web.UI.Page,IPaginaBase
	{
		#region Controles

		protected System.Web.UI.WebControls.Literal ltlMensaje;

		#endregion Controles

		#region Constantes
		
		const string OBJPARAMETROCONTABLE = "ParamCtaBco";
		const string SFECHACTABCO = "FechaSaldoCtaBco";

		//Ordenamiento
		const string COLORDENAMIENTO = "Moneda";

		//Nombres de Controles
		const string CONTROLINK = "hlkCuentaBancaria";
		const string CONTROCHECKBOX = "cbxEliminar";
		
		//Paginas
		const int VALORDEFAULT =0;
		const string URLDETALLE = "DetalleCuentaBancariaSaldo.aspx?";
		const string URLPRINCIPAL= "../../Default.aspx?";
		const string URLDETALLE1="ConsultarSaldodeCuentaBancariaporCentroDetalle.aspx?";
		const string URLDETALLE2="ConsultarSaldodeCtaySubCtaBancariaporCentroDetalle.aspx?";


		const string URLIMPRESION = "PopupImpresion.aspx";
		const string URLEXPORTAREXCEL = "PopupExportarExcel.aspx";
		
		//Key Session y QueryString
		const string KEYQID = "idCtaBco";
		const string KEYQFECHA = "Fecha";
		const string KEYIDCENTRO = "idCentro";
		const string NOMBRECENTRO = "Nombre";

		const string  CMPSOLES = "lblSoles";
		const string  CMPDOLAR = "lblDolares";

		//JScript
		string JSVERIFICARELIMINAR = "return verificarEliminarRb('hCodigo','" + Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO)+"','"+Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJEPREGUNTAELIMINACIONREGISTRO)+"');";
		//Otros
		const string GRILLAVACIA ="No existe ninguna Cuenta Bancaria."; 
		const string VALORTOTAL = "TOTAL";
		const string COLUMNAMODO = "Modo";

		//Filtro
		const string CUENTABANCARIA ="NroCuentaBancaria";
		const string CENTROOPERACIONES ="Centro";
		const string ENTIDADFINANCIERA ="RazonSocial";
		const string TIPOCTABANCARIA ="TipoCtaBco";
		const string MONEDA ="Moneda";
		const string SALDO ="MontoSaldo";

		const string MSGCONFIRMACIONIMPORT ="Importación termino con exito..";

		#endregion

		#region Controles

		protected System.Web.UI.WebControls.Label Label1;
		protected eWorld.UI.CalendarPopup CalFecha;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Literal Literal1;
		protected System.Web.UI.HtmlControls.HtmlTable TblTabs;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminaFiltro;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminar;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.DropDownList ddlbCentroOperativo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hModo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPaginaSort;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.ImageButton imgbtnImportar;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCuenta;
		#endregion 

		#region Variables
		#endregion Variables
		
		
		/// <summary>
		/// Elimina las Cuentas Bancarias seleccionadas
		/// </summary>
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					this.LlenarJScript();
					Helper.ReiniciarSession();
					this.LlenarDatos();					
					this.LlenarCombos();
					Helper.ReestablecerPagina(this);
					this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Convert.ToInt32(this.hGridPagina.Value));
					Helper.CalendarioControlStyle(this.CalFecha);
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
			this.CalFecha.DateChanged += new eWorld.UI.DateChangedEventHandler(this.CalFecha_DateChanged);
			this.ddlbCentroOperativo.SelectedIndexChanged += new System.EventHandler(this.ddlbCentroOperativo_SelectedIndexChanged);
			this.ibtnFiltrar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnFiltrar_Click);
			this.ibtnEliminaFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminaFiltro_Click);
			this.ibtnEliminar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminar_Click);
			this.imgbtnImportar.Click += new System.Web.UI.ImageClickEventHandler(this.imgbtnImportar_Click);
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
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			
		}
		private DataTable ObtenerDatos()
		{
			CCuentaBancariaSaldo oCCuentaBancariaSaldo = new CCuentaBancariaSaldo();
			//return oCCuentaBancariaSaldo.AdministrarCuentaBancariaSaldo(this.CalFecha.SelectedDate.ToShortDateString(),VALORDEFAULT,this.ddlbCentroOperativo.SelectedValue.ToString());
			return oCCuentaBancariaSaldo.AdministrarCuentaBancariaSaldo(this.CalFecha.SelectedDate,VALORDEFAULT,Convert.ToInt32(this.ddlbCentroOperativo.SelectedValue));
		}
		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
		{
			this.grid.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(Utilitario.Helper.FooterSpan);
			DataTable dtCuentasBancariasSaldo = ObtenerDatos();
			if(dtCuentasBancariasSaldo!=null)
			{
				DataView dwCuentasBancariasSaldo = dtCuentasBancariasSaldo.DefaultView;
				dwCuentasBancariasSaldo.RowFilter = Helper.ObtenerFiltro();
				dwCuentasBancariasSaldo.Sort = columnaOrdenar ;
				grid.Columns[Utilitario.Constantes.POSICIONFOOTERTOTAL].FooterText = Utilitario.Constantes.TEXTOFOOTERTOTAL + Utilitario.Constantes.ESPACIO + dwCuentasBancariasSaldo.Count.ToString();
				grid.DataSource = dwCuentasBancariasSaldo;
				grid.CurrentPageIndex = indicePagina;

				CImpresion oCImpresion = new CImpresion();
				oCImpresion.GuardarDataImprimirExportar(dtCuentasBancariasSaldo
					,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString()
												,Utilitario.Constantes.CODIGOTITULOREPORTECUENTASBANCARIAS)
												,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString()
																			,Utilitario.Constantes.CODIGONOMBREARCHIVOREPORTECUENTASBANCARIAS)
												,columnaOrdenar,indicePagina);
				lblResultado.Visible = false;
			}
			else
			{
				grid.DataSource = dtCuentasBancariasSaldo;
				lblResultado.Text = GRILLAVACIA;
				lblResultado.Visible = true;
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
			this.CargarCentroOperativo();
		}
		private void CargarCentroOperativo()
		{
			CCentroOperativo oCCentroOperativo =   new  CCentroOperativo();
			ddlbCentroOperativo.DataSource = oCCentroOperativo.ListarCentroOperativoAccesoSegunPrivilegioUsuario(CNetAccessControl.GetIdUser(),Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraEstadodeSaldosdeCuentasBancarias));
			ddlbCentroOperativo.DataValueField=Enumerados.ColumnasCentroOperativo.IdCentroOperativo.ToString();
			ddlbCentroOperativo.DataTextField=Enumerados.ColumnasCentroOperativo.Nombre.ToString();
			ddlbCentroOperativo.DataBind();
		}

		public void LlenarDatos()
		{
			if (Session[SFECHACTABCO]==null)
			{
				Session[SFECHACTABCO] = DateTime.Now.ToShortDateString();
			}
			this.CalFecha.SelectedDate = Convert.ToDateTime(Session[SFECHACTABCO]);
		}

		public void LlenarJScript()
		{
			//imgbtnImportar.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnMouseDown.ToString(),Utilitario.Constantes.FORMATODECIMAL4);
			imgbtnImportar.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.FORMATODECIMAL4);

			ibtnEliminar.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.ConfirmaEliminacion("hCodigo"));
			ddlbCentroOperativo.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnChange.ToString(),Utilitario.Constantes.POPUPDEESPERA + Helper.HistorialIrAdelantePersonalizado("CalFecha","hGridPaginaSort","hGridPagina") + Utilitario.Constantes.SIGNOPUNTOYCOMA);
			this.CalFecha.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnChange.ToString(),Utilitario.Constantes.POPUPDEESPERA);
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultaDeCartasFianzas.RegistrandoJScript implementation
		}

		public void Imprimir()
		{
			ltlMensaje.Text = Helper.PopupImpresion(URLIMPRESION,650,700,false,false,false,true,true);
		}

		public void Exportar()
		{
			ltlMensaje.Text = Helper.PopupImpresion(URLEXPORTAREXCEL,650,700,false,false,false,true,true);
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
			return true;
		}

		#endregion

		private void imgImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Imprimir();
		}

		
		private void imgExportarExcel_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Exportar();
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.hGridPagina.Value = e.NewPageIndex.ToString();
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);		
		}

		private void btnMostrarSaldos_Click(object sender, System.EventArgs e)
		{
		}

		private void GridResumen_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				
				Label lblS = (Label)e.Item.Cells[2].FindControl(CMPSOLES);
				lblS.Text = Helper.FormateaNumeroNegativo(Convert.ToDouble(dr[Enumerados.FINColumnaResumenCuentaBancariaSaldo.MontoResumenSoles.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4) ,lblS);

				Label lblD = (Label)e.Item.Cells[2].FindControl(CMPDOLAR);
				lblD.Text = Helper.FormateaNumeroNegativo(Convert.ToDouble(dr[Enumerados.FINColumnaResumenCuentaBancariaSaldo.MontoResumenDolares.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4),lblD);
				
				if (e.Item.Cells[0].Text == VALORTOTAL)
				{
					e.Item.Font.Bold=true;
					lblS.Font.Bold = true;
					lblD.Font.Bold = true;
					lblS.ForeColor = Color.White;
					lblD.ForeColor = Color.White;
				}
			}
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
				if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
				{
					DataRowView drv = (DataRowView)e.Item.DataItem;
					DataRow dr = drv.Row;

					Helper.ConfiguraColumnaHyperLink(Utilitario.Enumerados.EventosJavaScript.OnClick,e.Item.Cells[0],grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex,
								Helper.HistorialIrAdelantePersonalizado("hGridPagina","hGridPaginaSort","CalFecha","ddlbCentroOperativo"),
								Helper.MostrarVentana(URLDETALLE,KEYQID + Constantes.SIGNOIGUAL + Convert.ToString(dr[Enumerados.FINColumnaCuentaBancariaSaldo.IdCuentaBancariaCentro.ToString()]) 
														+ Constantes.SIGNOAMPERSON  
														+ KEYQFECHA + Constantes.SIGNOIGUAL + this.CalFecha.SelectedDate.ToShortDateString()
														+ Constantes.SIGNOAMPERSON  
														+ Constantes.KEYMODOPAGINA +  Constantes.SIGNOIGUAL + dr["Modo"].ToString()
														+ Constantes.SIGNOAMPERSON  
														+ KEYIDCENTRO +  Constantes.SIGNOIGUAL + this.ddlbCentroOperativo.SelectedValue.ToString()
														));

					e.Item.Cells[6].Text = Convert.ToDouble(e.Item.Cells[6].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
					e.Item.Cells[6].Text= Helper.FormateaNumeroNegativo(6,e.Item);

//					string fcScript = Helper.MostrarDatosEnCajaTexto("hCodigo",Convert.ToString(dr[Enumerados.FINColumnaCuentaBancariaSaldo.IdCuentaBancariaCentro.ToString()])) 
//										+ Utilitario.Constantes.SIGNOPUNTOYCOMA 
//										+ Helper.MostrarDatosEnCajaTexto("hModo",dr[COLUMNAMODO].ToString());
					
//					Helper.SeleccionarItemGrillaOnClickMoverRaton(e,fcScript);
					Helper.SeleccionarItemGrillaOnClickMoverRaton(e,
																	Helper.MostrarDatosEnCajaTexto("hCodigo",Convert.ToString(dr[Enumerados.FINColumnaCuentaBancariaSaldo.IdCuentaBancariaCentro.ToString()])) 
																	+ Utilitario.Constantes.SIGNOPUNTOYCOMA 
																	+ Helper.MostrarDatosEnCajaTexto("hModo",dr[COLUMNAMODO].ToString()));
					
					Helper.FiltroporSeleccionConfiguraColumna(e,grid,true,"txtBuscar");
				}	
		}
		
	

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			hGridPaginaSort.Value = Helper.GenerarExpresionOrdenamiento(e.SortExpression);
			this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Helper.ObtenerIndicePagina());			
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void ibtnFiltrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			ltlMensaje.Text = Helper.ElaborarFiltro(this,ObtenerDatos(),CUENTABANCARIA + ";Cuenta Bancaria"
																		,Utilitario.Constantes.SIGNOASTERISCO + CENTROOPERACIONES + "; Centro de Operaciones"
																		,Utilitario.Constantes.SIGNOASTERISCO + ENTIDADFINANCIERA + "; Entidad Financiera"
																		,Utilitario.Constantes.SIGNOASTERISCO + TIPOCTABANCARIA + ";Tipo de Cuenta Bancaria"
																		,Utilitario.Constantes.SIGNOASTERISCO + MONEDA + ";Moneda"
																		,SALDO + ";Saldo");
		}


		private void ibtnEliminar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				if(Page.IsValid)
				{
					if (this.hModo.Value.ToString()!= Utilitario.Enumerados.ModoPagina.C.ToString())
					{
						this.Eliminar();
					}
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
			if (this.hCodigo.Value.Length >0)
			{
				CCuentaBancariaSaldo oCCuentaBancariaSaldo = new CCuentaBancariaSaldo();
				if(oCCuentaBancariaSaldo.Eliminar(this.CalFecha.SelectedDate, Convert.ToInt32(this.hCodigo.Value.ToString()))>0)
				{
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"CuentaBancariaSaldos",this.ToString(),"Se eliminó la Cuenta Nro. " + this.hCuenta.Value.ToString() + Utilitario.Constantes.SIMBOLOPUNTO,Enumerados.NivelesErrorLog.I.ToString()));
					this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),Helper.ObtenerIndicePagina());
					//ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONELIMINACIONREGISTRO));
				}
			}
			else
			{
				ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO));
			}

		}

		private void ibtnEliminaFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}

		private void GridResumen_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void CalFecha_DateChanged(object sender, System.EventArgs e)
		{
			Session[SFECHACTABCO] = this.CalFecha.SelectedDate;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO),Constantes.INDICEPAGINADEFAULT);
		}

		private void ddlbCentroOperativo_SelectedIndexChanged(object sender, System.EventArgs e)
		{

			Session[SFECHACTABCO] = this.CalFecha.SelectedDate;
			if(Convert.ToInt32(this.ddlbCentroOperativo.SelectedValue.ToString())==Convert.ToInt32(Utilitario.Constantes.KEYIDCENTROCALLAO.ToString()))
			{
				Page.Response.Redirect(URLDETALLE2 + KEYIDCENTRO + Utilitario.Constantes.SIGNOIGUAL + this.ddlbCentroOperativo.SelectedValue.ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYQFECHA + Utilitario.Constantes.SIGNOIGUAL + this.CalFecha.SelectedDate.ToShortDateString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ NOMBRECENTRO + Utilitario.Constantes.SIGNOIGUAL + this.ddlbCentroOperativo.SelectedItem.Text.ToUpper());
			}
			else
			{
				this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO),Constantes.INDICEPAGINADEFAULT);

			}
		}

		private void imgbtnImportar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				int i = ((CCuentaBancariaSaldo) new CCuentaBancariaSaldo()).ImportarSaldodeCuentasBacarias(Convert.ToInt32(CalFecha.SelectedDate.Year)
																											,Convert.ToInt32(CalFecha.SelectedDate.Month));
				ASPNetUtilitario.MessageBox.Show(MSGCONFIRMACIONIMPORT);
				this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Convert.ToInt32(this.hGridPagina.Value));
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

