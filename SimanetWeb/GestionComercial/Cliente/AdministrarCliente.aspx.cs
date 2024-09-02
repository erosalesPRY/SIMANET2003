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

namespace SIMA.SimaNetWeb.GestionComercial.Cliente
{
	/// <summary>
	/// Summary description for AdministrarCliente.
	/// </summary>
	public class AdministrarCliente : System.Web.UI.Page, IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPaginaSort;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.ImageButton ibtnConsultar;
		protected System.Web.UI.WebControls.TextBox txtNombre;
		protected System.Web.UI.WebControls.Label lblNombre;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblCantClientes;
		protected System.Web.UI.WebControls.TextBox txtCantClientes;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.ImageButton ibtnRepresentante;
		protected System.Web.UI.WebControls.ImageButton ibtnContacto;
		protected System.Web.UI.WebControls.ImageButton ibtnAgregar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminar;
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminarFiltroConsulta;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hpagina;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminarFiltro;
		protected System.Web.UI.WebControls.CheckBox chkTipoComercial;		
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion

		#region Constantes

		//JScript
		string JSVERIFICARELIMINAR = "return verificarEliminarRb('hCodigo','" + Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO)+"','"+Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJEPREGUNTAELIMINACIONREGISTRO)+"');";

		//Otros
		const string TEXTOTOTAL = "Monto";
		const int POSICIONINICIALCOMBO = 0;
		const int PosicionFooterTotal = 3;
		const int PosicionClasificacion = 4;
		const int PosicionMonto = 3;
		const string GRILLAVACIA ="No existe ningun Cliente.";
		const string FLAGFILTRO = "1"; 
		const string CLASIFICACION = "Sin Clasificar";
		const string CAJATEXTORAZONSOCIAL = "txtNombre";
		const string INDICEPAGINA = "hGridPagina";
		const string PAGINASORT = "hGridPaginaSort";
		const string TIPOOPCION = "hCodigo";

		//Key Session y QueryString
		const string KEYQID = "IdCliente";
		const string FLAG = "Flag";
		const string REPRESENTANTECONTACTO = "RepresentanteContacto";

		//Paginas
		const string URLDETALLE = "ConsultaDetalleCliente.aspx?";
		const string URLIMPRESION = "PopupImpresionConsultarCliente.aspx";
		const string URLLISTAREPRESENTANTECONTACTO = "PopupListaRepresentanteContacto.aspx?";

		#endregion
	
		#region Variables		
		private int ValorDefault = -1;
		private int administrar = 0;		
		private int representante = 0;
		private int contacto = 1;
		private string FechaDefault = "01/01/1996";
		#endregion
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarJScript();
					//Graba en el Log la acción ejecutada
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
			this.chkTipoComercial.CheckedChanged += new System.EventHandler(this.chkTipoComercial_CheckedChanged);
			this.ibtnConsultar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnConsultar_Click);
			this.ibtnEliminarFiltroConsulta.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminarFiltroConsulta_Click);
			this.ibtnFiltrar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnFiltrar_Click);
			this.ibtnEliminarFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminarFiltro_Click);
			this.ibtnRepresentante.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnRepresentante_Click);
			this.ibtnContacto.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnContacto_Click);
			this.ibtnAgregar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAgregar_Click);
			this.ibtnEliminar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminar_Click);
			this.ibtnImprimir.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnImprimir_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members
		public void LlenarGrilla()
		{
			// TODO:  Add AdministrarCliente.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarCliente.LlenarGrillaOrdenamiento implementation
		}

		public DataTable ObtenerDatos()
		{
			CCliente oCCliente = new CCliente();
			if(this.hCodigo.Value == FLAGFILTRO)
				return oCCliente.BuscarClientesSegunRazonSocial(this.txtNombre.Text.Trim());
			else
				return oCCliente.ObtenerClientesPorCriterioFiltros(ValorDefault,ValorDefault,ValorDefault,ValorDefault,Convert.ToDateTime(FechaDefault),
					Convert.ToDateTime(FechaDefault),ValorDefault,ValorDefault,ValorDefault,ValorDefault,ValorDefault,ValorDefault,ValorDefault,ValorDefault,ValorDefault,Utilitario.Constantes.VACIO);
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dtClientes = this.ObtenerDatos();
			if(dtClientes!=null)
			{
				DataView dwCliente = dtClientes.DefaultView;
				dwCliente.Sort = columnaOrdenar;
				dwCliente.RowFilter = Utilitario.Helper.ObtenerFiltro();

				if(dwCliente.Count > POSICIONINICIALCOMBO)
				{
					grid.DataSource = dwCliente;
					grid.CurrentPageIndex = indicePagina;
					txtCantClientes.Text = dwCliente.Count.ToString();
					txtCantClientes.Style[Constantes.ALINEAMIENTOTEXTO] = TextAlign.Right.ToString();
					lblResultado.Visible = false;
					ibtnImprimir.Visible = true;
					Double [] x =  Helper.TotalizarDataView(dwCliente,TEXTOTOTAL);
					grid.Columns[PosicionFooterTotal].FooterText = x[Constantes.POSICIONCONTADOR].ToString(Utilitario.Constantes.FORMATODECIMAL4);					
					grid.Columns[2].FooterText=dwCliente.Count.ToString();
				}
				else
				{
					grid.DataSource = null; 
					lblResultado.Text = GRILLAVACIA;
					txtCantClientes.Text = Utilitario.Constantes.VACIO;
					lblResultado.Visible = true;
					ibtnImprimir.Visible = false;
				}
				CImpresion oCImpresion = new CImpresion();
				oCImpresion.GuardarDataImprimirExportar(dwCliente.Table,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGOTITULOREPORTELISTARTODOSCLIENTES),columnaOrdenar,indicePagina);
			}
			else
			{
				grid.DataSource = dtClientes;
				lblResultado.Text = GRILLAVACIA;
				txtCantClientes.Text = Utilitario.Constantes.VACIO;
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
			// TODO:  Add AdministrarCliente.LlenarCombos implementation	
		}
		public void LlenarDatos()
		{
			// TODO:  Add AdministrarCliente.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			this.ibtnEliminar.Attributes.Add(Constantes.EVENTOCLICK,JSVERIFICARELIMINAR);

			this.ibtnRepresentante.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado(Utilitario.Constantes.VACIO));
			this.ibtnRepresentante.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, Utilitario.Constantes.POPUPDEESPERA);

			this.ibtnContacto.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado(Utilitario.Constantes.VACIO));
			this.ibtnContacto.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, Utilitario.Constantes.POPUPDEESPERA);

			this.ibtnAgregar.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado(Utilitario.Constantes.VACIO));
			this.ibtnAgregar.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.POPUPDEESPERA);

		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarCliente.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			ltlMensaje.Text = Helper.PopupImpresion(URLIMPRESION,780,700,false,false,false,true,true);
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarCliente.Exportar implementation
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

		private void ibtnConsultar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
				try
				{
					if(this.ValidarFiltros())
					{
						//Graba en el Log la acción ejecutada
						LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Comercial",this.ToString(),"Se consultó a los clientes segun criterio de nombre.",Enumerados.NivelesErrorLog.I.ToString()));
						this.hCodigo.Value = FLAGFILTRO;
						this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Convert.ToInt32(this.hGridPagina.Value));
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
					SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
					Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
				}
		}

		private void ibtnEliminarFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}

		private void ibtnAgregar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
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
				CCliente oCCliente = new CCliente();

				if(oCCliente.EliminarCliente(Convert.ToInt32(hCodigo.Value),CNetAccessControl.GetIdUser())> 0)
				{
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se eliminó el cliente nro. " + hCodigo.Value +"." ,Enumerados.NivelesErrorLog.I.ToString()));
					this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),Helper.ObtenerIndicePagina());
					ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONELIMINACIONREGISTRO));
					this.txtNombre.Text = Utilitario.Constantes.VACIO;
				}
			}
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{

			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,Utilitario.Helper.MostrarDatosEnCajaTexto("hCodigo",dr[Enumerados.ColumnasCliente.IdCliente.ToString()].ToString()));

				e.Item.Cells[Constantes.POSICIONCONTADOR].Attributes.Add(Utilitario.Constantes.EVENTOCLICK, Helper.HistorialIrAdelantePersonalizado(INDICEPAGINA,PAGINASORT,TIPOOPCION)+ Utilitario.Constantes.POPUPDEESPERA +
																											Helper.MostrarVentana(URLDETALLE,
																																  KEYQID + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr[Enumerados.ColumnasCliente.IdCliente.ToString()]) +  Utilitario.Constantes.SIGNOAMPERSON + 
																																  Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.M.ToString()));

				e.Item.Cells[Constantes.POSICIONCONTADOR].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				e.Item.Cells[Constantes.POSICIONCONTADOR].Font.Underline=true;
				e.Item.Cells[Utilitario.Constantes.POSICIONCONTADOR].ForeColor = System.Drawing.Color.Blue;

				e.Item.Cells[PosicionMonto].Text = Convert.ToDouble(e.Item.Cells[PosicionMonto].Text).ToString(Constantes.FORMATODECIMAL4);

				if(dr[PosicionClasificacion].ToString()== Utilitario.Constantes.VACIO)
				{
					e.Item.Cells[PosicionClasificacion].Text = CLASIFICACION.ToString();
				}
				Helper.FiltroporSeleccionConfiguraColumna(e,grid);
			}
		
		}

	
		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.hGridPaginaSort.Value = Helper.GenerarExpresionOrdenamiento(e.SortExpression);


			if(chkTipoComercial.Checked==true)
			{
				LlenarGrillaPorTipoComercial(Helper.ObtenerColumnaOrdenamiento(),Helper.ObtenerIndicePagina());
			}
			else
			{	
				this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),Helper.ObtenerIndicePagina());
			}
			
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{


			this.hGridPagina.Value = e.NewPageIndex.ToString();

			if(chkTipoComercial.Checked==true)
			{
				LlenarGrillaPorTipoComercial(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);
			}
			else
			{	
				this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);
			}

		}

		private void ibtnRepresentante_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if(hCodigo.Value.Length==0)
			{
				ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO));
			}
			else
			{
				Page.Response.Redirect(URLLISTAREPRESENTANTECONTACTO + KEYQID + Utilitario.Constantes.SIGNOIGUAL + hCodigo.Value.ToString() + Utilitario.Constantes.SIGNOAMPERSON +
																	   REPRESENTANTECONTACTO + Utilitario.Constantes.SIGNOIGUAL + representante.ToString() + Utilitario.Constantes.SIGNOAMPERSON + 
																	   FLAG + Utilitario.Constantes.SIGNOIGUAL + administrar.ToString());

			}

		}

		private void ibtnContacto_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if(hCodigo.Value.Length==0)
			{
				ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO));
			}
			else
			{
				Page.Response.Redirect(URLLISTAREPRESENTANTECONTACTO + KEYQID + Utilitario.Constantes.SIGNOIGUAL + hCodigo.Value.ToString() + Utilitario.Constantes.SIGNOAMPERSON +
																	   REPRESENTANTECONTACTO + Utilitario.Constantes.SIGNOIGUAL + contacto.ToString() + Utilitario.Constantes.SIGNOAMPERSON + 
																	   FLAG + Utilitario.Constantes.SIGNOIGUAL + administrar.ToString());
			}
			
		}

		private void ibtnEliminarFiltroConsulta_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.EliminarFiltro();
		}
		
		private void EliminarFiltro()
		{
			this.hGridPagina.Value = Utilitario.Constantes.POSICIONCONTADOR.ToString();
			this.hGridPaginaSort.Value = Utilitario.Constantes.VACIO;
			this.hCodigo.Value = Utilitario.Constantes.VACIO;
			this.txtNombre.Text = Utilitario.Constantes.VACIO;

			this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Convert.ToInt32(this.hGridPagina.Value));
		}

		private void ibtnFiltrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			ltlMensaje.Text= Utilitario.Helper.ElaborarFiltro(this.ObtenerDatos(),
						Enumerados.GeneralCliente.RazonSocial.ToString()        + ";" + Enumerados.GeneralCliente.RazonSocial.ToString(),
						Enumerados.GeneralCliente.Monto.ToString()              + ";" + Enumerados.GeneralCliente.Monto.ToString(),
						"*" + Enumerados.GeneralCliente.Clasificacion.ToString()+ ";" + Enumerados.GeneralCliente.Clasificacion.ToString());

		}

		private void chkTipoComercial_CheckedChanged(object sender, System.EventArgs e)
		{
			if(chkTipoComercial.Checked==true)
			{
				LlenarGrillaPorTipoComercial(Helper.ObtenerColumnaOrdenamiento(),Helper.ObtenerIndicePagina());
			}
			else
			{	
				this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),Helper.ObtenerIndicePagina());
			}
		}


		private void LlenarGrillaPorTipoComercial(string columnaOrdenar, int indicePagina)
		{
			CCliente oCCliente = new CCliente();
			DataTable dt = new DataTable();

			dt = oCCliente.ObtenerClientesPorTipoComercial();
			if(dt!=null)
			{
				DataView dwCliente = dt.DefaultView;
				dwCliente.Sort = columnaOrdenar;
				dwCliente.RowFilter = Utilitario.Helper.ObtenerFiltro();

				if(dwCliente.Count > POSICIONINICIALCOMBO)
				{
					grid.DataSource = dwCliente;
					grid.CurrentPageIndex = indicePagina;
					txtCantClientes.Text = dwCliente.Count.ToString();
					txtCantClientes.Style[Constantes.ALINEAMIENTOTEXTO] = TextAlign.Right.ToString();
					lblResultado.Visible = false;
					ibtnImprimir.Visible = true;
					Double [] x =  Helper.TotalizarDataView(dwCliente,TEXTOTOTAL);
					grid.Columns[PosicionFooterTotal].FooterText = x[Constantes.POSICIONCONTADOR].ToString(Utilitario.Constantes.FORMATODECIMAL4);					
				}
				else
				{
					grid.DataSource = null; 
					lblResultado.Text = GRILLAVACIA;
					txtCantClientes.Text = Utilitario.Constantes.VACIO;
					lblResultado.Visible = true;
					ibtnImprimir.Visible = false;
				}
				CImpresion oCImpresion = new CImpresion();
				oCImpresion.GuardarDataImprimirExportar(dwCliente.Table,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGOTITULOREPORTELISTARTODOSCLIENTES),columnaOrdenar,indicePagina);
			}
			else
			{
				grid.DataSource = dt;
				lblResultado.Text = GRILLAVACIA;
				txtCantClientes.Text = Utilitario.Constantes.VACIO;
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

		private void ibtnImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Imprimir();
		}

	}
}
