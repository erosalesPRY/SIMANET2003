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
using SIMA.Controladoras.GestionComercial;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;

namespace SIMA.SimaNetWeb.GestionComercial.Promotores
{
	/// <summary>
	/// Summary description for AdministrarPromotores.
	/// </summary>
	public class AdministrarPromotores : System.Web.UI.Page,IPaginaBase
	{

		#region Controles
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblNombre;
		protected System.Web.UI.WebControls.TextBox txtNombre;
		protected System.Web.UI.WebControls.ImageButton ibtnConsultar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminarFiltroConsulta;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltro;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminarFiltro;
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label lblCantClientes;
		protected System.Web.UI.WebControls.TextBox txtCantPromotores;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPaginaSort;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnFiltrarSeleccion;
		#endregion Controles
		
		#region Constantes
		//Ordenamiento
		const string COLORDENAMIENTO = "IdPromotor";

		//Nombres de Controles
		const string CONTROLINK = "hlkId";
		const string CONTROCHECKBOX = "cbxEliminar";
		
		//Paginas
		const string URLDETALLE = "DetallePromotores.aspx?";
		const string URLDETALLEREPRESENTANTE = "PopupDetallesRepresentantePromotor.aspx?";
		const string URLIMPRESION = "PopupImpresionConsultarPromotoresPorVentas.aspx";
				
		//Key Session y QueryString
		const string KEYQID = "Id";
		const string KEYQIDPROMOTOR = "Id";

		//JScript
		string JSVERIFICARELIMINAR = "return verificarEliminarRb('hCodigo','" + Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO)+"','"+Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJEPREGUNTAELIMINACIONREGISTRO)+"');";
						
		//Otros
		const string GRILLAVACIA ="No existe ningun Promotor.";
		const string FLAGFILTRO = "1"; 
		const int POSICIONINICIALCOMBO = 0;
		const int PosicionFooterTotal = 4;
		const string INDICEPAGINA = "hGridPagina";
		const string PAGINASORT = "hGridPaginaSort";
		const string TIPOOPCION = "hCodigo";

		const int PosicionNumeracion = 0;
		const int PosicionPromotor = 2;
		const int PosicionRepresentante = 3;
		const int PosicionRepresentanteEnTabla = 2;
		const int PosicionVentasTotal = 3;
		const int PosicionGanancia = 4;
		
		const string SINREPRESENTANTE = "Sin Asignar";
		protected System.Web.UI.WebControls.ImageButton ibtnAgregar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminar;
		const string TEXTOTOTAL = "TotalVentas";

		#endregion Constantes

		#region Variables
		#endregion Variables
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{					
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarJScript();
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se consultaron los Clientes",Enumerados.NivelesErrorLog.I.ToString()));
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
			this.ibtnFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnFiltro_Click);
			this.ibtnEliminarFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminarFiltro_Click);
			this.ibtnAgregar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAgregar_Click);
			this.ibtnEliminar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminar_Click);
			this.ibtnImprimir.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnImprimir_Click);
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
			// TODO:  Add AdministrarPromotores.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarPromotores.LlenarGrillaOrdenamiento implementation
		}

		public DataTable ObtenerDatos()
		{
			if(this.hCodigo.Value == FLAGFILTRO)
			{
				CPromotores oCPromotores =  new CPromotores();
				return oCPromotores.BuscarPromotoresSegunRazonSocial(this.txtNombre.Text.Trim());
			}
			else
			{
				CMantenimientos oCMantenimientos = new CMantenimientos();
				return oCMantenimientos.ListarTodosGrilla(Enumerados.ClasesNTAD.PromotorNTAD.ToString());
			}
			//return null;
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
		{
			DataTable dtPromotores = this.ObtenerDatos();

			if(dtPromotores != null)					
			{
				DataView dwPromotor = dtPromotores.DefaultView;
				dwPromotor.Sort = columnaOrdenar;
				dwPromotor.RowFilter = Utilitario.Helper.ObtenerFiltro();

				if(dwPromotor.Count > POSICIONINICIALCOMBO)
				{
					grid.DataSource = dwPromotor;
					grid.CurrentPageIndex = indicePagina;
					txtCantPromotores.Text = dwPromotor.Count.ToString();
					txtCantPromotores.Style[Utilitario.Constantes.ALINEAMIENTOTEXTO] = TextAlign.Right.ToString();
					lblResultado.Visible = false; 
					ibtnImprimir.Visible = true;
					Double [] x =  Helper.TotalizarDataView(dwPromotor,TEXTOTOTAL);
					grid.Columns[PosicionFooterTotal].FooterText = x[Utilitario.Constantes.POSICIONCONTADOR].ToString(Utilitario.Constantes.FORMATODECIMAL4);;					
				}
				else
				{
					grid.DataSource = null; 
					lblResultado.Text = GRILLAVACIA;
					txtCantPromotores.Text = Utilitario.Constantes.VACIO;
					lblResultado.Visible = true;
					ibtnImprimir.Visible = false;
				}
				CImpresion oCImpresion = new CImpresion();
				oCImpresion.GuardarDataImprimirExportar(dwPromotor.Table,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGOTITULOREPORTELISTARTODOSPROMOTORES),columnaOrdenar,indicePagina);
			}
			else
			{
				grid.DataSource = dtPromotores;
				lblResultado.Text = GRILLAVACIA;
				txtCantPromotores.Text = Utilitario.Constantes.VACIO;
				lblResultado.Visible = true;
				ibtnImprimir.Visible = false;
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

		public void LlenarCombos()
		{
			// TODO:  Add AdministrarPromotores.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add AdministrarPromotores.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarPromotores.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			ltlMensaje.Text = Helper.PopupImpresion(URLIMPRESION,650,700,false,false,false,true,true);
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarPromotores.Exportar implementation
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
			if(this.txtNombre.Text.Trim()== String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJECLIENTECAMPOREQUERIDONOMBRECLIENTE));
				return false;
			}
			else
			{
				return true;
			}
		}
		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,Utilitario.Helper.MostrarDatosEnCajaTexto("hCodigo",dr[Enumerados.ColumnasPromotor.IdPromotor.ToString()].ToString()));

				e.Item.Cells[PosicionNumeracion].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);

				e.Item.Cells[PosicionPromotor].Attributes.Add(Utilitario.Constantes.EVENTOCLICK, Helper.HistorialIrAdelantePersonalizado(INDICEPAGINA,PAGINASORT,TIPOOPCION) + Utilitario.Constantes.POPUPDEESPERA +
															  Helper.MostrarVentana(URLDETALLE , 
																					KEYQIDPROMOTOR + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr[Enumerados.ColumnasPromotor.IdPromotor.ToString()]) + Utilitario.Constantes.SIGNOAMPERSON + 
																					Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.M.ToString()));
				
				e.Item.Cells[PosicionPromotor].Font.Underline=true;
				e.Item.Cells[PosicionPromotor].ForeColor = System.Drawing.Color.Blue;

				if(dr[PosicionRepresentanteEnTabla].ToString()== Utilitario.Constantes.VACIO)
				{
					e.Item.Cells[PosicionRepresentante].Text = SINREPRESENTANTE.ToString();
				}
				//e.Item.Cells[PosicionVentasTotal].Text = Convert.ToDouble(e.Item.Cells[PosicionVentasTotal].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				//e.Item.Cells[PosicionGanancia].Text = Convert.ToDouble(e.Item.Cells[PosicionGanancia].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				Helper.FiltroporSeleccionConfiguraColumna(e,grid);
			}	
			
		}

		private void imgImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Imprimir();
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			grid.CurrentPageIndex=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.hGridPaginaSort.Value = Helper.GenerarExpresionOrdenamiento(e.SortExpression);
			this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Helper.ObtenerIndicePagina());
		}

		private void ibtnFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			ltlMensaje.Text= Utilitario.Helper.ElaborarFiltro(this.ObtenerDatos()
																,Enumerados.ColumnasPromotor.RazonSocial.ToString() + ";Razon Social"
																,Enumerados.ColumnasPromotor.RepresentanteLegal.ToString() + ";Representante Legal");
		}

		private void ibtnEliminarFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}

		private void ibtnAgregar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.hCodigo.Value = "";
			this.hGridPagina.Value = "0";
			this.hGridPaginaSort.Value = "";

			Page.Response.Redirect(URLDETALLE + Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.N.ToString());
		}

		private void ibtnEliminar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				if(Page.IsValid)
				{
					this.eliminar();
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

		private void eliminar()
		{
			if(hCodigo.Value.Length == 0)
			{
				ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO));
			}
			else
			{								
				CMantenimientos oCMantenimientos = new CMantenimientos();

				if(oCMantenimientos.Eliminar(Convert.ToInt32(hCodigo.Value),CNetAccessControl.GetIdUser(),Enumerados.ClasesTAD.PromotorTAD.ToString())> 0)
				{
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se eliminó el promotor nro. " + hCodigo.Value +"." ,Enumerados.NivelesErrorLog.I.ToString()));
					this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),Helper.ObtenerIndicePagina());
					ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONELIMINACIONREGISTRO));
				}
			}
		}

		private void ibtnAgregarRepresentante_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			CPromotores oCPromotores =  new CPromotores();

			if(oCPromotores.VerificarTipoPromotor(Convert.ToInt32(hCodigo.Value)))
			{
				if(hCodigo.Value.Length==0)
				{
					ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO));
				}
				else
				{
					CRepresentantePromotor oCCRepresentantePromotor = new CRepresentantePromotor();
					bool repre = oCCRepresentantePromotor.ValidarExistenciaRepresentante(hCodigo.Value);

					if(repre)
					{
						//Modificar
						Page.Response.Redirect(URLDETALLEREPRESENTANTE  + KEYQID + Utilitario.Constantes.SIGNOIGUAL + hCodigo.Value.ToString() + Utilitario.Constantes.SIGNOAMPERSON +
							Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.M.ToString());
					}
					else
					{
						//Nuevo
						Page.Response.Redirect(URLDETALLEREPRESENTANTE + KEYQID + Utilitario.Constantes.SIGNOIGUAL + hCodigo.Value.ToString() + Utilitario.Constantes.SIGNOAMPERSON + 
							Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.N.ToString());
					}
				}
			}
		}

		private void ibtnEliminarRepresentante_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				if(Page.IsValid)
				{
					this.eliminarrepresentante();
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

		private void eliminarrepresentante()
		{
			CPromotores oCPromotores =  new CPromotores();
				{								
					CMantenimientos oCMantenimientos = new CMantenimientos();

					if(oCMantenimientos.Eliminar(Convert.ToInt32(hCodigo.Value),CNetAccessControl.GetIdUser(),Enumerados.ClasesTAD.RepresentantePromotorTAD.ToString())> 0)
					{
						//Graba en el Log la acción ejecutada
						LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se eliminó el represenante promotor nro. " + hCodigo.Value +"." ,Enumerados.NivelesErrorLog.I.ToString()));
						this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),Helper.ObtenerIndicePagina());
						ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionComercial.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONELIMINACIONREGISTROREPRESENTANTEPROMOTOR));
					}
				}
		}

		private void ibtnImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Imprimir();
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

	}
}