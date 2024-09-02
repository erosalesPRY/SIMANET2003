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

namespace SIMA.SimaNetWeb.GestionComercial.Cliente
{
	/// <summary>
	/// Summary description for PopupListaRepresentanteContacto.
	/// </summary>
	public class PopupListaRepresentanteContacto : System.Web.UI.Page, IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.ImageButton ibtnAgregar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminar;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.WebControls.ImageButton ibtnConsultar;
		protected System.Web.UI.WebControls.TextBox txtNombre;
		protected System.Web.UI.WebControls.Label lblNombre;
		protected System.Web.UI.WebControls.Label lblApellidopaterno;
		protected System.Web.UI.WebControls.TextBox txtApellidoPaterno;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminarFiltro;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltro;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnFiltrarSeleccion;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblTituloPrincipal;
		#endregion

		#region Constantes

		//JScript
		string JSVERIFICARELIMINAR = "return verificarEliminarRb('hCodigo','" + Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO)+"','"+Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJEPREGUNTAELIMINACIONREGISTRO)+"');";

		//Key Session y QueryString
		const string KEYQIDCLIENTE = "IdCliente";
		const string KEYQIDREPRECONT = "IdRepreCont";
		const string titulorepresenatante = " REPRESENTANTES";
		const string titulocontacto = " CONTACTOS";
		const string paginarepresenatante = " Representantes";
		const string paginacontacto = " Contactos";
		const string IdRepresentanteContacto = "Id";
		
		const string FLAG = "Flag";
		const string REPRESENTANTECONTACTO = "RepresentanteContacto";


		//Paginas
		const string URLDETALLEREPRESENTANTECONTACTO = "PopupDetalleRepresentanteoContacto.aspx?";

		#endregion

		#region Variables
		private int administrar = 0;
		private int consulta = 1;

		private int representante = 0;
		private int contacto = 1;
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
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se consulto la lista Contacto o Representante del Cliente",Enumerados.NivelesErrorLog.I.ToString()));
					this.LlenarDatos();
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
			this.ibtnConsultar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnConsultar_Click);
			this.ibtnAgregar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAgregar_Click);
			this.ibtnEliminar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminar_Click);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			if(Page.Request.QueryString[REPRESENTANTECONTACTO] == representante.ToString())
			{
				lblTituloPrincipal.Text = lblTituloPrincipal.Text + titulorepresenatante;
				lblPagina.Text = lblPagina.Text + paginarepresenatante;

				CRepresentanteCliente oCRepresentanteCliente = new CRepresentanteCliente();
				DataTable dt = oCRepresentanteCliente.ListarTodosRepresentanteGrilla(Convert.ToInt32(Page.Request.QueryString[KEYQIDCLIENTE]));
				
				if(dt != null)
				{
					DataView dwListarTodosRepresentante = dt.DefaultView;
					grid.DataSource = dwListarTodosRepresentante;
				}
				else
				{
					grid.DataSource = dt; 
				}

				try
				{
					grid.DataBind();
				}
				catch(Exception ex)
				{
					string a = ex.Message;
					grid.DataBind();
				}
			}
			else
			{
				lblTituloPrincipal.Text = lblTituloPrincipal.Text + titulocontacto;
				lblPagina.Text = lblPagina.Text + paginacontacto;

				CContactoCliente oCContactoCliente = new CContactoCliente();
				DataTable dt = oCContactoCliente.ListarTodosContactoGrilla(Convert.ToInt32(Page.Request.QueryString[KEYQIDCLIENTE]));
				
				if(dt != null)
				{
					DataView dwListarTodosContacto = dt.DefaultView;
					grid.DataSource = dwListarTodosContacto;
				}
				else
				{
					grid.DataSource = dt; 
				}

				try
				{
					grid.DataBind();
				}
				catch(Exception ex)
				{
					string a = ex.Message;
					grid.DataBind();
				}

			}
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add PopupListaRepresentanteContacto.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add PopupListaRepresentanteContacto.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add PopupListaRepresentanteContacto.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			this.LlenarGrilla();
			if(Page.Request.QueryString[FLAG] == administrar.ToString())
			{
				this.ibtnAgregar.Visible = true;
				this.ibtnEliminar.Visible = true;
			}
			else
			{
				this.ibtnFiltro.Visible = false;
				this.ibtnFiltrarSeleccion.Visible = false;
				this.ibtnEliminarFiltro.Visible = false;
				this.ibtnAgregar.Visible = false;
				this.ibtnEliminar.Visible = false;
			}
		}

		public void LlenarJScript()
		{
			this.ibtnAgregar.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.POPUPDEESPERA);
			this.ibtnAgregar.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.HISTORIALADELANTE);
			this.ibtnEliminar.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,JSVERIFICARELIMINAR);
		}

		public void RegistrarJScript()
		{
			// TODO:  Add PopupListaRepresentanteContacto.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add PopupListaRepresentanteContacto.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add PopupListaRepresentanteContacto.Exportar implementation
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
			if(this.txtNombre.Text == String.Empty && this.txtApellidoPaterno.Text == String.Empty )
			{
					ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEREPRESENTANTECLIENTECAMPOREQUERIDOSCONSULTA));
					return false;
			}
			return true;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,Utilitario.Helper.MostrarDatosEnCajaTexto("hCodigo",dr[IdRepresentanteContacto].ToString()));
			
				//Administrar
				if(Page.Request.QueryString[FLAG] == administrar.ToString())
				{
					e.Item.Cells[Utilitario.Constantes.POSICIONCONTADOR].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);

					if(Page.Request.QueryString[REPRESENTANTECONTACTO] == representante.ToString())
					{	
						e.Item.Cells[Utilitario.Constantes.POSICIONCONTADOR].Attributes.Add(Utilitario.Constantes.EVENTOCLICK, 
																							Helper.MostrarVentana(URLDETALLEREPRESENTANTECONTACTO ,
																												  Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.M.ToString()+ Utilitario.Constantes.SIGNOAMPERSON +
																												  KEYQIDREPRECONT + Utilitario.Constantes.SIGNOIGUAL + dr[IdRepresentanteContacto].ToString() + Utilitario.Constantes.SIGNOAMPERSON +					
																												  REPRESENTANTECONTACTO + Utilitario.Constantes.SIGNOIGUAL + representante.ToString()+ Utilitario.Constantes.SIGNOAMPERSON +
																												  FLAG + Utilitario.Constantes.SIGNOIGUAL + administrar.ToString()));
																										   
					}
					else
					{
						e.Item.Cells[Utilitario.Constantes.POSICIONCONTADOR].Attributes.Add(Utilitario.Constantes.EVENTOCLICK, 
																							Helper.MostrarVentana(URLDETALLEREPRESENTANTECONTACTO,
																												  Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.M.ToString()+ Utilitario.Constantes.SIGNOAMPERSON +
																												  KEYQIDREPRECONT + Utilitario.Constantes.SIGNOIGUAL + dr[IdRepresentanteContacto].ToString() + Utilitario.Constantes.SIGNOAMPERSON +					
																												  REPRESENTANTECONTACTO + Utilitario.Constantes.SIGNOIGUAL + contacto.ToString()+ Utilitario.Constantes.SIGNOAMPERSON +
																												  FLAG + Utilitario.Constantes.SIGNOIGUAL + administrar.ToString()));
						
					}

				}
				//Consulta
				else
				{
					if(Page.Request.QueryString[REPRESENTANTECONTACTO] == representante.ToString())
					{	
						e.Item.Cells[Utilitario.Constantes.POSICIONCONTADOR].Attributes.Add(Utilitario.Constantes.EVENTOCLICK, 
																						    Helper.MostrarVentana(URLDETALLEREPRESENTANTECONTACTO,
																												  Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.C.ToString()+ Utilitario.Constantes.SIGNOAMPERSON +
																											      KEYQIDREPRECONT + Utilitario.Constantes.SIGNOIGUAL + dr[IdRepresentanteContacto].ToString()  + Utilitario.Constantes.SIGNOAMPERSON +					
																												  REPRESENTANTECONTACTO + Utilitario.Constantes.SIGNOIGUAL + representante.ToString()+ Utilitario.Constantes.SIGNOAMPERSON +
																												  FLAG + Utilitario.Constantes.SIGNOIGUAL + consulta.ToString()));
																										   
					}
					else
					{
						e.Item.Cells[Utilitario.Constantes.POSICIONCONTADOR].Attributes.Add(Utilitario.Constantes.EVENTOCLICK, 
																							Helper.MostrarVentana(URLDETALLEREPRESENTANTECONTACTO ,
																												  Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.C.ToString()+ Utilitario.Constantes.SIGNOAMPERSON +
																												  KEYQIDREPRECONT + Utilitario.Constantes.SIGNOIGUAL + dr[IdRepresentanteContacto].ToString() + Utilitario.Constantes.SIGNOAMPERSON +					
																												  REPRESENTANTECONTACTO + Utilitario.Constantes.SIGNOIGUAL + contacto.ToString()+ Utilitario.Constantes.SIGNOAMPERSON +
																												  FLAG + Utilitario.Constantes.SIGNOIGUAL + consulta.ToString()));
						
					}

				}
				e.Item.Cells[Utilitario.Constantes.POSICIONCONTADOR].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				e.Item.Cells[Utilitario.Constantes.POSICIONCONTADOR].Font.Underline = true;
				e.Item.Cells[Utilitario.Constantes.POSICIONCONTADOR].ForeColor = System.Drawing.Color.Blue;
				
				Helper.FiltroporSeleccionConfiguraColumna(e,grid);
			}
		}


		private void LLenarGrillaConsulta()
		{
			if(Convert.ToInt32(Page.Request.QueryString[REPRESENTANTECONTACTO]) == representante)
			{
				lblTituloPrincipal.Text = lblTituloPrincipal.Text + titulorepresenatante;
				lblPagina.Text = lblPagina.Text + paginarepresenatante;
			}
			else
			{
				lblTituloPrincipal.Text = lblTituloPrincipal.Text + titulocontacto;
				lblPagina.Text = lblPagina.Text + paginacontacto;
			}
		}


		private void ibtnConsultar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if(this.ValidarFiltros())
			{
				if(Page.Request.QueryString[REPRESENTANTECONTACTO] == representante.ToString())
				{
					CRepresentanteCliente oCRepresentanteCliente = new CRepresentanteCliente();
					DataTable dt = oCRepresentanteCliente.ObtenerRepresantantesPorFiltro(Convert.ToInt32(Page.Request.QueryString[KEYQIDCLIENTE]), this.txtNombre.Text, this.txtApellidoPaterno.Text);

					if(dt != null)
					{
						DataView dwListarRepresentantePorFiltro = dt.DefaultView;
						grid.DataSource = dwListarRepresentantePorFiltro;
					}
					else
					{
						grid.DataSource = dt; 
					}

					try
					{
						grid.DataBind();
					}
					catch(Exception ex)
					{
						string a = ex.Message;
						grid.DataBind();
					}

				}
				else
				{
					CContactoCliente oCContactoCliente = new CContactoCliente();
					DataTable dt = oCContactoCliente.ObtenerContactoPorFiltro(Convert.ToInt32(Page.Request.QueryString[KEYQIDCLIENTE]), this.txtNombre.Text, this.txtApellidoPaterno.Text);

					if(dt != null)
					{
						DataView dwListarContactoPorFiltro = dt.DefaultView;
						grid.DataSource = dwListarContactoPorFiltro;
					}
					else
					{
						grid.DataSource = dt; 
					}

					try
					{
						grid.DataBind();
					}
					catch(Exception ex)
					{
						string a = ex.Message;
						grid.DataBind();
					}
				}
			}
		}


		private void ibtnAgregar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if(Page.Request.QueryString[REPRESENTANTECONTACTO] == representante.ToString())
			{
				Page.Response.Redirect(URLDETALLEREPRESENTANTECONTACTO + Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.N.ToString()+ Utilitario.Constantes.SIGNOAMPERSON + 
					KEYQIDCLIENTE + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQIDCLIENTE] + Utilitario.Constantes.SIGNOAMPERSON +
					REPRESENTANTECONTACTO + Utilitario.Constantes.SIGNOIGUAL + representante.ToString() + Utilitario.Constantes.SIGNOAMPERSON +
					FLAG + Utilitario.Constantes.SIGNOIGUAL + administrar.ToString() );

			}
			else
			{
				Page.Response.Redirect(URLDETALLEREPRESENTANTECONTACTO + Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.N.ToString()+ Utilitario.Constantes.SIGNOAMPERSON + 
					KEYQIDCLIENTE + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQIDCLIENTE] + Utilitario.Constantes.SIGNOAMPERSON +
					REPRESENTANTECONTACTO + Utilitario.Constantes.SIGNOIGUAL + contacto.ToString() + Utilitario.Constantes.SIGNOAMPERSON +
					FLAG + Utilitario.Constantes.SIGNOIGUAL + administrar.ToString());

			}
			
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

				if(Page.Request.QueryString[REPRESENTANTECONTACTO] == representante.ToString())
				{
					if(oCMantenimientos.Eliminar(Convert.ToInt32(hCodigo.Value),CNetAccessControl.GetIdUser(),Enumerados.ClasesTAD.RepresentanteClienteTAD.ToString()) > 0)
					{
						//Graba en el Log la acción ejecutada
						LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se eliminó el representante nro. " + hCodigo.Value +"." ,Enumerados.NivelesErrorLog.I.ToString()));
						this.LlenarDatos();
						ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONELIMINACIONREGISTRO));
					}
				}
				else
				{
					if(oCMantenimientos.Eliminar(Convert.ToInt32(hCodigo.Value),CNetAccessControl.GetIdUser(),Enumerados.ClasesTAD.ContactoClienteTAD.ToString()) > 0)
					{
						//Graba en el Log la acción ejecutada
						LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se eliminó el contacto nro. " + hCodigo.Value +"." ,Enumerados.NivelesErrorLog.I.ToString()));
						this.LlenarDatos(); 
						ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONELIMINACIONREGISTRO));
					}
				}
			}
		}
	}
}
