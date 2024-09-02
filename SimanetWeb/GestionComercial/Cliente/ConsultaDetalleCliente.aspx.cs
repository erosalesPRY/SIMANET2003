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
using SIMA.Controladoras.GestionComercial;
using SIMA.Controladoras.General;
using SIMA.EntidadesNegocio.General;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;

namespace SIMA.SimaNetWeb.GestionComercial.Cliente
{
	/// <summary>
	/// Summary description for ConsultaDetalleCliente.
	/// </summary>
	public class ConsultaDetalleCliente : System.Web.UI.Page, IPaginaBase, IPaginaMantenimento
	{
		#region Controles
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblPromotor;
		protected System.Web.UI.WebControls.TextBox txtObservaciones;
		protected System.Web.UI.WebControls.Label lblObservaciones;
		protected System.Web.UI.WebControls.DropDownList ddlbTipoActividad;
		protected System.Web.UI.WebControls.Label lblTipoActividad;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvTipoCliente;
		protected System.Web.UI.WebControls.DropDownList ddlbTipoCliente;
		protected System.Web.UI.WebControls.Label lblTipoCliente;
		protected System.Web.UI.WebControls.TextBox txtNroFax;
		protected System.Web.UI.WebControls.Label lblNroFax;
		protected System.Web.UI.WebControls.TextBox txtCelular;
		protected System.Web.UI.WebControls.Label lblCelular;
		protected System.Web.UI.WebControls.TextBox txtTelefono;
		protected System.Web.UI.WebControls.Label lblTelefono;
		protected System.Web.UI.WebControls.TextBox txtCorreoElectronico;
		protected System.Web.UI.WebControls.Label lblCorreoElectronico;
		protected System.Web.UI.WebControls.ImageButton ibtnDetalleContacto;
		protected System.Web.UI.WebControls.TextBox txtContacto;
		protected System.Web.UI.WebControls.Label lblContacto;
		protected System.Web.UI.WebControls.ImageButton ibtnDetalleRepresentante;
		protected System.Web.UI.WebControls.TextBox txtRepresentante;
		protected System.Web.UI.WebControls.Label lblRepresentante;
		protected System.Web.UI.WebControls.TextBox txtDireccion;
		protected System.Web.UI.WebControls.Label lblDireccion;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvDistrito;
		protected System.Web.UI.WebControls.TextBox txtDistrito;
		protected System.Web.UI.WebControls.DropDownList ddlbDistrito;
		protected System.Web.UI.WebControls.Label lblDistrito;
		protected System.Web.UI.WebControls.TextBox txtProvincia;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvProvincia;
		protected System.Web.UI.WebControls.DropDownList ddlbProvincia;
		protected System.Web.UI.WebControls.Label lblProvincia;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvDepartamento;
		protected System.Web.UI.WebControls.DropDownList ddlbDepartamento;
		protected System.Web.UI.WebControls.TextBox txtDepartamento;
		protected System.Web.UI.WebControls.Label lblDepartamento;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvPais;
		protected System.Web.UI.WebControls.DropDownList ddlbPais;
		protected System.Web.UI.WebControls.TextBox txtPais;
		protected System.Web.UI.WebControls.Label lblPais;
		protected System.Web.UI.WebControls.DropDownList ddlbClasifcacion;
		protected System.Web.UI.WebControls.Label lblClasificacion;
		protected System.Web.UI.WebControls.Label lblRuc;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvApellidoMaterno;
		protected System.Web.UI.WebControls.TextBox txtApellidoMaterno;
		protected System.Web.UI.WebControls.Label lblApellidoMaterno;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvApellidoPaterno;
		protected System.Web.UI.WebControls.TextBox txtApellidoPaterno;
		protected System.Web.UI.WebControls.Label lblApellidoPaterno;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvNombre;
		protected System.Web.UI.WebControls.TextBox txtNombre;
		protected System.Web.UI.WebControls.Label lblRazonSocial;
		protected System.Web.UI.WebControls.Label lblNombre;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvTipoClienteLegal;
		protected System.Web.UI.WebControls.TextBox txtTipoClienteLegal;
		protected System.Web.UI.WebControls.RadioButtonList rblTipoClienteLegal;
		protected System.Web.UI.WebControls.Label lblTipoClienteLegal;
		protected System.Web.UI.WebControls.TextBox txtNacionalidad;
		protected System.Web.UI.WebControls.RadioButtonList rblNacionalidad;
		protected System.Web.UI.WebControls.Label lblNacionalidad;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellApellidoPaternolbl;
		protected System.Web.UI.HtmlControls.HtmlTableCell cellApellidoPaterno;
		protected System.Web.UI.HtmlControls.HtmlTableCell cellApellidoMaternolbl;
		protected System.Web.UI.HtmlControls.HtmlTableCell cellApellidoMaterno;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlbClasifcacion;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlbPais;
		protected System.Web.UI.HtmlControls.HtmlTableCell cellddlbDepartamento;
		protected System.Web.UI.HtmlControls.HtmlTableCell cellProvincialbl;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlbProvincia;
		protected System.Web.UI.HtmlControls.HtmlTableCell cellDistritolbl;
		protected System.Web.UI.HtmlControls.HtmlTableCell cellddlbDistrito;
		protected System.Web.UI.HtmlControls.HtmlTableCell cellRepresentantelbl;
		protected System.Web.UI.HtmlControls.HtmlTableCell cellRepresentante;
		protected System.Web.UI.HtmlControls.HtmlTableCell cellContactolbl;
		protected System.Web.UI.HtmlControls.HtmlTableCell cellContacto;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlbTipoCliente;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlbTipoActividad;					
		protected System.Web.UI.HtmlControls.HtmlTableCell TdCeldaCancelar;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdCliente;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnCancelar;
		protected System.Web.UI.WebControls.Label lblMensaje;
		protected System.Web.UI.WebControls.ValidationSummary vSum;
		protected eWorld.UI.NumericBox txtRUC;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvRuc;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.RadioButton rbtSI;
		protected System.Web.UI.WebControls.RadioButton rbtNO;
		protected System.Web.UI.WebControls.TextBox txtClienteComercial;
		#endregion

		#region Constantes
		//Titulos
		const string TITULOMODONUEVO = "NUEVO CLIENTE";
		const string TITULOMODOMODIFICAR = "CLIENTE";
		const string TITULOMODOCONSULTA = "DETALLES DEL CLIENTE";

		//Key Session y QueryString

		const string KEYQIDCLIENTE = "IdCliente";
		const string FLAG = "Flag";
		const string REPRESENTANTECONTACTO = "RepresentanteContacto";

		//Paginas
		const string URLPRINCIPAL = "AdministrarCliente.aspx?";
		const string URLREPRESETACIONCONTACTO = "PopupListaRepresentanteContacto.aspx?";

		//Otros
		const string NOMBRE = "nombre";
		const int ClienteJuridico = 0;
		const int ClienteNatural = 1;
		const string NACIONALIDAD = "";
		const string TIPOCLIENTELEGAL = "";
		const string NOMBRECLIENTE = "";
		const string APELLIDOPATERNO = "";
		const string APELLIDOMATERNO = "";
		const string RUC = "";
		const string PAIS = "";
		const string DEPARTAMENTO = "";
		const string PROVINCIA = "";
		const string DISTRITO = "";
		const string CORREO = "";
		const string TELEFONO = "";
		const string CELULAR = "";
		const string NROFAX = "";
		const string TIPOCLIENTE = "";
		const string TIPOACTIVIDAD = "";
		const string TIPOCLASIFICACION = "";
		const string OBSERVACION = "";
		const string INDICEPAGINA = "hGridPagina";
		const string PAGINASORT = "hGridPaginaSort";
		const string TIPOOPCION = "hopcion";

		const int CLIENTETIPOCOMERCIAL   = 1;
		const int CLIENTETIPONOCOMERCIAL = 2;

		const string VALORSI = "SI";
		const string VALORNO = "NO";
			
		#endregion

		#region Variables
		private int nroregistros = 0;
		ListItem item;
		//private int administrar = 0;
		private int consulta = 1;
		private int representante = 0;
		private int contacto = 1;
		private int i = 0;
		#endregion
	
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
			this.rblNacionalidad.SelectedIndexChanged += new System.EventHandler(this.rblNacionalidad_SelectedIndexChanged);
			this.rblTipoClienteLegal.SelectedIndexChanged += new System.EventHandler(this.rblTipoClienteLegal_SelectedIndexChanged);
			this.rbtSI.CheckedChanged += new System.EventHandler(this.rbtSI_CheckedChanged);
			this.rbtNO.CheckedChanged += new System.EventHandler(this.rbtNO_CheckedChanged);
			this.ddlbPais.SelectedIndexChanged += new System.EventHandler(this.ddlbPais_SelectedIndexChanged);
			this.ddlbDepartamento.SelectedIndexChanged += new System.EventHandler(this.ddlbDepartamento_SelectedIndexChanged);
			this.ddlbProvincia.SelectedIndexChanged += new System.EventHandler(this.ddlbProvincia_SelectedIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.ibtnAceptar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAceptar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.CargarModoPagina();	
					
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


		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add ConsultarDetalleCliente.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarDetalleCliente.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add ConsultarDetalleCliente.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			item = new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,Utilitario.Constantes.VALORSELECCIONAR);

			this.LlenarPais();
			this.LlenarCombosConsulta();

			this.ddlbPais.Items.Insert(0,item);
			this.ddlbTipoCliente.Items.Insert(0,item);
			this.ddlbTipoActividad.Items.Insert(0,item);
			this.ddlbClasifcacion.Items.Insert(0,item);

		}

		public void LlenarCombosConsulta()
		{
			this.LlenarTipoCliente();
			this.LlenarActividad();
			this.LlenarClasificacion();
		}

		public void LlenarDatos()
		{
			// TODO:  Add ConsultarDetalleCliente.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.QueryString[Constantes.KEYMODOPAGINA]) ;

			switch (oModoPagina)
			{
				case Enumerados.ModoPagina.N:
					 break;
				case Enumerados.ModoPagina.M:
					 break;
				case Enumerados.ModoPagina.C:
					 this.ibtnDetalleRepresentante.Attributes.Add(Utilitario.Constantes.EVENTOCLICK ,Utilitario.Constantes.POPUPDEESPERA +
																  Helper.MostrarVentana(URLREPRESETACIONCONTACTO, 
																  KEYQIDCLIENTE +  Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQIDCLIENTE]+ Utilitario.Constantes.SIGNOAMPERSON + 
														          FLAG + Utilitario.Constantes.SIGNOIGUAL + consulta.ToString()+ Utilitario.Constantes.SIGNOAMPERSON +
						                                          REPRESENTANTECONTACTO + Utilitario.Constantes.SIGNOIGUAL + representante.ToString()));
					this.ibtnDetalleContacto.Attributes.Add(Utilitario.Constantes.EVENTOCLICK , Utilitario.Constantes.POPUPDEESPERA + 
																 Helper.MostrarVentana(URLREPRESETACIONCONTACTO, 
																 KEYQIDCLIENTE +  Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQIDCLIENTE]+ Utilitario.Constantes.SIGNOAMPERSON + 
																 FLAG + Utilitario.Constantes.SIGNOIGUAL + consulta.ToString()+ Utilitario.Constantes.SIGNOAMPERSON +
																 REPRESENTANTECONTACTO + Utilitario.Constantes.SIGNOIGUAL + contacto.ToString()));
					break;
			}

			this.rfvTipoClienteLegal.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECLIENTECAMPOREQUERIDOTIPOCLIENTELEGAL);
			this.rfvTipoClienteLegal.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECLIENTECAMPOREQUERIDOTIPOCLIENTELEGAL);

			this.rfvNombre.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECLIENTECAMPOREQUERIDONOMBRE);
			this.rfvNombre.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECLIENTECAMPOREQUERIDONOMBRE);

			this.rfvApellidoPaterno.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECLIENTECAMPOREQUERIDOAPELLIDOPATERNO);
			this.rfvApellidoPaterno.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECLIENTECAMPOREQUERIDOAPELLIDOPATERNO);

			this.rfvApellidoMaterno.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECLIENTECAMPOREQUERIDOAPELLIDOMATERNO);
			this.rfvApellidoMaterno.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECLIENTECAMPOREQUERIDOAPELLIDOMATERNO);

			this.rfvRuc.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECLIENTECAMPOREQUERIDODOCIDENTIDADRUC);
			this.rfvRuc.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECLIENTECAMPOREQUERIDODOCIDENTIDADRUC);

			this.rfvPais.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECLIENTECAMPOREQUERIDOPAIS);
			this.rfvPais.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECLIENTECAMPOREQUERIDOPAIS);

			this.rfvDepartamento.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECLIENTECAMPOREQUERIDODEPARTAMENTO);
			this.rfvDepartamento.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECLIENTECAMPOREQUERIDODEPARTAMENTO);

			this.rfvProvincia.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECLIENTECAMPOREQUERIDOPROVINCIA);
			this.rfvProvincia.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECLIENTECAMPOREQUERIDOPROVINCIA);

			this.rfvDistrito.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECLIENTECAMPOREQUERIDODISTRITO);
			this.rfvDistrito.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECLIENTECAMPOREQUERIDODISTRITO);

			this.rfvTipoCliente.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECLIENTECAMPOREQUERIDOTIPOCLIENTE);
			this.rfvTipoCliente.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECLIENTECAMPOREQUERIDOTIPOCLIENTE);

		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarDetalleCliente.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarDetalleCliente.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarDetalleCliente.Exportar implementation
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
			// TODO:  Add ConsultarDetalleCliente.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			/*
			CLIENTEBE oCLIENTEBE = new CLIENTEBE();
			
			if(rbtSI.Checked==true)
			{
				oCLIENTEBE.TipoComercial = CLIENTETIPOCOMERCIAL; 
			}
			else
			{
				oCLIENTEBE.TipoComercial = CLIENTETIPONOCOMERCIAL; 
			}

			if(this.rblNacionalidad.SelectedValue == Utilitario.Constantes.NACIONAL.ToString())
			{
				oCLIENTEBE.IDTABLATIPOLEGALCLIENTE = Convert.ToInt32(Enumerados.TablasTabla.TablaTipoLegalCliente);
				oCLIENTEBE.IDTIPOLEGALCLIENTE = Convert.ToInt32(rblTipoClienteLegal.SelectedValue);	

				if(this.rblTipoClienteLegal.SelectedValue == ClienteJuridico.ToString())
				{
					oCLIENTEBE.RAZONSOCIAL = this.txtNombre.Text.ToUpper();
				}

				if(this.rblTipoClienteLegal.SelectedValue == ClienteNatural.ToString())
				{
					oCLIENTEBE.NOMBRES = this.txtNombre.Text.ToUpper();
					oCLIENTEBE.APELLIDOPATERNO = txtApellidoPaterno.Text.ToUpper();
					oCLIENTEBE.APELLIDOMATERNO = txtApellidoMaterno.Text.ToUpper();
				}

				oCLIENTEBE.RUC = Convert.ToInt64(this.txtRUC.Text);
			}
			else
			{
				oCLIENTEBE.RAZONSOCIAL = this.txtNombre.Text.ToUpper();
			}
			
			CUbigeo oCUbigeo = new CUbigeo();

			if(Convert.ToInt32(this.ddlbPais.SelectedValue) == Utilitario.Constantes.PERU)
			{
				oCLIENTEBE.IDUBIGEO = oCUbigeo.ObtenerIdUbigeo(this.ddlbDepartamento.SelectedValue, this.ddlbProvincia.SelectedValue, this.ddlbDistrito.SelectedValue);
			}
			else
			{
				oCLIENTEBE.IDUBIGEO = oCUbigeo.ObtenerIdUbigeo(this.ddlbPais.SelectedItem.Text, this.ddlbDepartamento.SelectedValue);
			}

			if(this.txtDireccion.Text.Trim() != String.Empty)
			{
				oCLIENTEBE.DIRECCION = this.txtDireccion.Text;
			}

			if(this.txtCorreoElectronico.Text.Trim() != String.Empty)
			{
				oCLIENTEBE.CORREOELECTRONICO = this.txtCorreoElectronico.Text;
			}
			if(this.txtTelefono.Text.Trim() != String.Empty)
			{
				oCLIENTEBE.TELEFONO1 = this.txtTelefono.Text;
			}
			if(this.txtCelular.Text.Trim() != String.Empty)
			{
				oCLIENTEBE.TELEFONO2 = this.txtCelular.Text;
			}
			if(this.txtNroFax.Text.Trim() != String.Empty)
			{
				oCLIENTEBE.FAX1 = this.txtNroFax.Text;
			}

			oCLIENTEBE.IDTABLATIPOCLIENTE = Convert.ToInt32(Enumerados.TablasTabla.TipoCliente);
			oCLIENTEBE.IDTIPOCLIENTE = Convert.ToInt32(ddlbTipoCliente.SelectedValue);

			if(ddlbTipoActividad.SelectedValue != Utilitario.Constantes.VALORSELECCIONAR)
			{
				oCLIENTEBE.IDTABLATIPOACTIVIDAD = Convert.ToInt32(Enumerados.TablasTabla.TablaActividadCliente);
				oCLIENTEBE.IDTIPOACTIVIDAD = Convert.ToInt32(ddlbTipoActividad.SelectedValue);
			}

			if(ddlbClasifcacion.SelectedValue != Utilitario.Constantes.VALORSELECCIONAR)
			{
				oCLIENTEBE.IDTABLATIPOCLASIFICACION = Convert.ToInt32(Enumerados.TablasTabla.TablaClasificacionCliente);
				oCLIENTEBE.IDTIPOCLASIFICACION = Convert.ToInt32(ddlbTipoActividad.SelectedValue);
			}

			if(this.txtObservaciones.Text != String.Empty)
			{
				oCLIENTEBE.OBSERVACIONES = this.txtObservaciones.Text;
			}

			oCLIENTEBE.IDUSUARIOREGISTRO =  CNetAccessControl.GetIdUser();

			CMantenimientos oCMantenimientos = new CMantenimientos();
			int retorno = oCMantenimientos.Insertar(oCLIENTEBE);

			if(retorno>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se registró al cliente. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));
				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionComercial.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONREGISTROCLIENTES));
			}*/

		}

		public void Modificar()
		{
			CLIENTEBE oCLIENTEBE = new CLIENTEBE();

			oCLIENTEBE.IDCLIENTE = Convert.ToInt32(Page.Request.QueryString[KEYQIDCLIENTE]);

			#region Administrado por Unysis
			/*
				CUbigeo oCUbigeo = new CUbigeo();

				if(Convert.ToInt32(this.ddlbPais.SelectedValue) == Utilitario.Constantes.PERU)
				{
					oCLIENTEBE.IDUBIGEO = oCUbigeo.ObtenerIdUbigeo(this.ddlbDepartamento.SelectedValue, this.ddlbProvincia.SelectedValue, this.ddlbDistrito.SelectedValue);
				}
				else
				{
					oCLIENTEBE.IDUBIGEO = oCUbigeo.ObtenerIdUbigeo(this.ddlbPais.SelectedItem.Text, this.ddlbDepartamento.SelectedValue);
				}*/
				
				/*
				if(this.rblTipoClienteLegal.SelectedValue == ClienteJuridico.ToString())
				{
					oCLIENTEBE.RAZONSOCIAL = this.txtNombre.Text.ToUpper();
				}

				if(this.rblTipoClienteLegal.SelectedValue == ClienteNatural.ToString())
				{
					oCLIENTEBE.NOMBRES = this.txtNombre.Text.ToUpper();
					oCLIENTEBE.APELLIDOPATERNO = txtApellidoPaterno.Text.ToUpper();
					oCLIENTEBE.APELLIDOMATERNO = txtApellidoMaterno.Text.ToUpper();
				}
				if(this.rblNacionalidad.SelectedValue == Utilitario.Constantes.NACIONAL.ToString())
				{
					oCLIENTEBE.IDTABLATIPOLEGALCLIENTE = Convert.ToInt32(Enumerados.TablasTabla.TablaTipoLegalCliente);
					oCLIENTEBE.IDTIPOLEGALCLIENTE = Convert.ToInt32(rblTipoClienteLegal.SelectedValue);	
					oCLIENTEBE.RUC = Convert.ToInt64(this.txtRUC.Text);
				}
				else
				{
					oCLIENTEBE.RAZONSOCIAL = this.txtNombre.Text.ToUpper();
				}
				if(this.txtDireccion.Text.Trim() != String.Empty)
				{
					oCLIENTEBE.DIRECCION = this.txtDireccion.Text;
				}
				if(this.txtTelefono.Text.Trim() != String.Empty)
				{
					oCLIENTEBE.TELEFONO1 = this.txtTelefono.Text;
				}
				if(this.txtCelular.Text.Trim() != String.Empty)
				{
					oCLIENTEBE.TELEFONO2 = this.txtCelular.Text;
				}
				if(this.txtNroFax.Text.Trim() != String.Empty)
				{
					oCLIENTEBE.FAX1 = this.txtNroFax.Text;
				}
				oCLIENTEBE.IDTABLATIPOCLIENTE = Convert.ToInt32(Enumerados.TablasTabla.TipoCliente);
				oCLIENTEBE.IDTIPOCLIENTE = Convert.ToInt32(ddlbTipoCliente.SelectedValue);	
				*/


			#endregion


			if(rbtSI.Checked==true)
			{
				oCLIENTEBE.TipoComercial = CLIENTETIPOCOMERCIAL; 
			}
			else
			{
				oCLIENTEBE.TipoComercial = CLIENTETIPONOCOMERCIAL; 
			}	
			
			if(this.txtCorreoElectronico.Text.Trim() != String.Empty)
			{
				oCLIENTEBE.CORREOELECTRONICO = this.txtCorreoElectronico.Text;
			}

			if(ddlbTipoActividad.SelectedValue != Utilitario.Constantes.VALORSELECCIONAR)
			{
				oCLIENTEBE.IDTABLATIPOACTIVIDAD = Convert.ToInt32(Enumerados.TablasTabla.TablaActividadCliente);
				oCLIENTEBE.IDTIPOACTIVIDAD = Convert.ToInt32(ddlbTipoActividad.SelectedValue);
			}

			if(ddlbClasifcacion.SelectedValue != Utilitario.Constantes.VALORSELECCIONAR)
			{
				oCLIENTEBE.IDTABLATIPOCLASIFICACION = Convert.ToInt32(Enumerados.TablasTabla.TablaClasificacionCliente);
				oCLIENTEBE.IDTIPOCLASIFICACION = Convert.ToInt32(ddlbTipoActividad.SelectedValue);
			}

			if(this.txtObservaciones.Text != String.Empty)
			{
				oCLIENTEBE.OBSERVACIONES = this.txtObservaciones.Text;
			}

			oCLIENTEBE.IDUSUARIOACTUALIZACION =  CNetAccessControl.GetIdUser();

			CMantenimientos oCMantenimientos = new CMantenimientos();
			int retorno = oCMantenimientos.Modificar(oCLIENTEBE);

			if(retorno>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se Modifico al cliente. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));
				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionComercial.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONMODIFICACIONCLIENTES));
			}
			
		}

		public void Eliminar()
		{
			// TODO:  Add ConsultarDetalleCliente.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.QueryString[Constantes.KEYMODOPAGINA]) ;

			switch (oModoPagina)
			{
				case Enumerados.ModoPagina.N:
					this.CargarModoNuevo();
					break;
				case Enumerados.ModoPagina.M:
					this.CargarModoModificar();
					break;
				case Enumerados.ModoPagina.C:
					this.CargarModoConsulta();
					break;
			}
		}

		public void CargarModoNuevo()
		{
			this.LlenarJScript();
			rbtSI.Checked=true;
			this.TdCeldaCancelar.Visible = false;
			this.lblTitulo.Text = TITULOMODONUEVO;
			this.lblPromotor.Visible = false;
			this.grid.Visible = false;

			this.cellApellidoPaterno.Visible = false;
			this.CellApellidoPaternolbl.Visible = false;
			this.cellApellidoMaterno.Visible = false;
			this.cellApellidoMaternolbl.Visible = false;

			this.cellRepresentante.Visible = false;
			this.cellRepresentantelbl.Visible = false;
			this.cellContacto.Visible = false;
			this.cellContactolbl.Visible = false;

			this.LlenarCombos();
			item = ddlbPais.Items.FindByValue(Utilitario.Constantes.PERU.ToString());
			if (item !=null){item.Selected = true;}
			this.ddlbPais.Enabled = false;
			
			this.LlenarDepartamentoNacional();
		}

		public void CargarModoModificar()
		{
			this.LlenarJScript();
			this.TdCeldaCancelar.Visible = false;

			this.cellRepresentante.Visible = false;
			this.cellRepresentantelbl.Visible = false;
			this.cellContacto.Visible = false;
			this.cellContactolbl.Visible = false;

			this.lblPromotor.Visible = false;
			this.grid.Visible = false;
			lblTitulo.Text = TITULOMODOMODIFICAR;
			this.LlenarCombos();

			//DataTable dtnombres;
			CMantenimientos	oCMantenimientos = new CMantenimientos();
			CLIENTEBE oClienteBE = (CLIENTEBE)oCMantenimientos.ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYQIDCLIENTE]),Enumerados.ClasesNTAD.ClienteNTAD.ToString());

			
			if(oClienteBE != null)
			{

			//	this.txtObservaciones.Text = oClienteBE.OBSERVACIONES.ToString();
				this.hIdCliente.Value = oClienteBE.IDCLIENTE.ToString();
				
				if(oClienteBE.TipoComercial==CLIENTETIPOCOMERCIAL)
				{
					rbtSI.Checked=true;
				}
				else
				{
					rbtNO.Checked=true;
				}


				if(Convert.ToInt32(oClienteBE.IDUBIGEO.ToString()) < Utilitario.Constantes.NACIONALPERU)
				{
					this.rblNacionalidad.SelectedIndex = Utilitario.Constantes.POSICIONCONTADOR;

					//Cliente Juridico
					if(oClienteBE.IDTABLATIPOLEGALCLIENTE == Convert.ToInt32(Enumerados.TablasTabla.TablaTipoLegalCliente) && oClienteBE.IDTIPOLEGALCLIENTE == Convert.ToInt32(Enumerados.TipoLegalCliente.juridico))
					{
						this.DesabilitarControlesClienteJuridico();
						this.rblTipoClienteLegal.SelectedIndex = Convert.ToInt32(oClienteBE.IDTIPOLEGALCLIENTE.Value);
	
						if(!oClienteBE.RAZONSOCIAL.IsNull)
						{
							this.txtNombre.Text = oClienteBE.RAZONSOCIAL.ToString().ToUpper();
						}
					}
					//Cliente Natural
					if(oClienteBE.IDTABLATIPOLEGALCLIENTE == Convert.ToInt32(Enumerados.TablasTabla.TablaTipoLegalCliente) && oClienteBE.IDTIPOLEGALCLIENTE == Convert.ToInt32(Enumerados.TipoLegalCliente.natural))
					{
						this.DesabilitarControlesClienteNatural();
						this.HabilitarControlesClienteNatural();
						this.rblTipoClienteLegal.SelectedIndex = Convert.ToInt32(oClienteBE.IDTIPOLEGALCLIENTE.Value);
					
						if(!oClienteBE.NOMBRES.IsNull)
						{
							this.txtNombre.Text = oClienteBE.NOMBRES.Value;	
						}
						if(!oClienteBE.APELLIDOPATERNO.IsNull)
						{
							this.txtApellidoPaterno.Text = oClienteBE.APELLIDOPATERNO.Value;
						}
						if(!oClienteBE.APELLIDOMATERNO.IsNull)
						{
							this.txtApellidoMaterno.Text = oClienteBE.APELLIDOMATERNO.Value;
						}
					}
					if(!oClienteBE.RUC.IsNull)
					{
						txtRUC.Text = oClienteBE.RUC.ToString().ToUpper();
					}
				}
				else
				{
					this.rblNacionalidad.SelectedIndex = Utilitario.Constantes.POSICIONDEFAULT;
					if(!oClienteBE.RAZONSOCIAL.IsNull)
					{
						this.txtNombre.Text = oClienteBE.RAZONSOCIAL.ToString().ToUpper();
					}

					this.lblTipoClienteLegal.Visible = false;
					this.rblTipoClienteLegal.Visible = false;
					this.rfvTipoClienteLegal.Visible = false;
					this.lblNombre.Visible = false;
					this.lblRuc.Visible = true;
					this.txtRUC.ReadOnly = true;
					this.rfvRuc.Visible = false;

					this.cellApellidoPaterno.Visible = false;		
					this.CellApellidoPaternolbl.Visible = false;
					this.rfvApellidoPaterno.Visible = false;
					this.cellApellidoMaterno.Visible = false;
					this.cellApellidoMaternolbl.Visible = false;
					this.rfvApellidoMaterno.Visible = false;

					this.cellProvincialbl.Visible = false;
					this.CellddlbProvincia.Visible = false;
					this.rfvProvincia.Visible = false;
					this.cellDistritolbl.Visible = false;
					this.cellddlbDistrito.Visible = false;
					this.rfvDistrito.Visible = false;

				}

				//Datos Comunes
				if(oClienteBE.IDUBIGEO > 0)
				{
					CUbigeo oCUbigeo = new CUbigeo(); 
					DataRow drUbigeo = oCUbigeo.ObtenerNombreUbigeo(Convert.ToInt32(oClienteBE.IDUBIGEO.ToString()));

					if(Convert.ToInt32(drUbigeo[Utilitario.Constantes.POSICIONCONTADOR].ToString()) < Utilitario.Constantes.NACIONALPERU) 
					{
						item = ddlbPais.Items.FindByValue(Utilitario.Constantes.PERU.ToString());
						if (item !=null){item.Selected = true;}

						this.LlenarDepartamentoNacional();
						item = ddlbDepartamento.Items.FindByText(drUbigeo[Utilitario.Constantes.POSICIONDEPARTAMENTO].ToString());
						if (item !=null){item.Selected = true;}

						this.LlenarProvincia(drUbigeo[Utilitario.Constantes.POSICIONDEPARTAMENTO].ToString());
						item = ddlbProvincia.Items.FindByText(drUbigeo[Utilitario.Constantes.POSICIONPROVINCIA].ToString());
						if (item !=null){item.Selected = true;}

						this.LlenarDistrito(drUbigeo[Utilitario.Constantes.POSICIONPROVINCIA].ToString());
						item = ddlbDistrito.Items.FindByText(drUbigeo[Utilitario.Constantes.POSICIONDISTRITO].ToString());
						if (item !=null){item.Selected = true;}

					}
					else
					{
						item = ddlbPais.Items.FindByText(drUbigeo[Utilitario.Constantes.POSICIONPAIS].ToString());
						if (item !=null){item.Selected = true;}
						
						this.LlenarDepartamentoExt(drUbigeo[Utilitario.Constantes.POSICIONPAIS].ToString());
						item = ddlbDepartamento.Items.FindByText(drUbigeo[Utilitario.Constantes.POSICIONCIUDAD].ToString());
						if (item !=null){item.Selected = true;}
					}
				}

				if(!oClienteBE.DIRECCION.IsNull)
				{
					txtDireccion.Text = oClienteBE.DIRECCION.ToString().ToUpper();
				}

				if(!oClienteBE.CORREOELECTRONICO.IsNull)
				{
					txtCorreoElectronico.Text = oClienteBE.CORREOELECTRONICO.ToString();
				}

				if(!oClienteBE.TELEFONO1.IsNull)
				{
					txtTelefono.Text = oClienteBE.TELEFONO1.ToString().ToUpper();
				}
				if(!oClienteBE.TELEFONO2.IsNull)
				{
					txtCelular.Text = oClienteBE.TELEFONO2.ToString().ToUpper();
				}
				if(!oClienteBE.FAX1.IsNull)
				{
					txtNroFax.Text = oClienteBE.FAX1.ToString().ToUpper();
				}

				item = ddlbTipoCliente.Items.FindByValue(oClienteBE.IDTIPOCLIENTE.ToString());
				if (item !=null){item.Selected = true;}

						
				if(!oClienteBE.IDTIPOACTIVIDAD.IsNull)
				{
					item = ddlbTipoActividad.Items.FindByValue(oClienteBE.IDTIPOACTIVIDAD.ToString());
					item.Selected = true;
					
				}

				if(!oClienteBE.IDTIPOCLASIFICACION.IsNull)
				{
					item = ddlbClasifcacion.Items.FindByValue(oClienteBE.IDTIPOCLASIFICACION.ToString());
					item.Selected = true;
				
				}
				if(!oClienteBE.OBSERVACIONES.IsNull)
				{
					txtObservaciones.Text = oClienteBE.OBSERVACIONES.ToString().ToUpper();
				}
				
			}

		}

		public void CargarModoConsulta()
		{
			this.LlenarCombosConsulta();
			rbtSI.Visible=false;
			rbtNO.Visible=false;
			this.DesabilitarControlesUbigeo();
			this.lblTitulo.Text = TITULOMODOCONSULTA;
			this.ibtnAceptar.Visible = false;
			this.ibtnCancelar.Visible = false;
			this.lblRepresentante.Visible = true;
			this.txtRepresentante.Visible = true;
			this.lblContacto.Visible = true;
			this.txtContacto.Visible = true;
			this.ibtnDetalleRepresentante.Visible = true;  //Boton de representante = true; --Todavia no
			this.ibtnDetalleContacto.Visible = true;       //Boton de contacto = true; --Todavia no
			this.txtPais.Visible = true;
			this.txtDepartamento.Visible = true;
			this.rblNacionalidad.Visible = false;
			this.rblTipoClienteLegal.Visible = false;
			this.txtNacionalidad.Visible = true;
			this.txtTipoClienteLegal.Visible = true;

			CCliente oCCliente = new CCliente();

			DataTable dtnombres;
			CMantenimientos	oCMantenimientos = new CMantenimientos();
			CLIENTEBE oClienteBE = (CLIENTEBE)oCMantenimientos.ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYQIDCLIENTE]),Enumerados.ClasesNTAD.ClienteNTAD.ToString());


			if(oClienteBE != null)
			{
				this.hIdCliente.Value = oClienteBE.IDCLIENTE.ToString();

					
				if(oClienteBE.TipoComercial==CLIENTETIPOCOMERCIAL)
				{
					txtClienteComercial.Visible=true;
					txtClienteComercial.Text = VALORSI;
				}
				else
				{
					txtClienteComercial.Visible=true;
					txtClienteComercial.Text = VALORNO;
				}

				if(Convert.ToInt32(oClienteBE.IDUBIGEO.ToString()) < Utilitario.Constantes.NACIONALPERU)
				{
					this.txtNacionalidad.Text = Utilitario.Constantes.NACIONALIDADNACIONAL.ToUpper(); 

					#region Tipo de cliente Legal - Juridico
					if(oClienteBE.IDTABLATIPOLEGALCLIENTE == Convert.ToInt32(Enumerados.TablasTabla.TablaTipoLegalCliente) && oClienteBE.IDTIPOLEGALCLIENTE == Convert.ToInt32(Enumerados.TipoLegalCliente.juridico))
					{	
						this.DesabilitarControlesClienteJuridico();
						this.txtTipoClienteLegal.Text = Utilitario.Constantes.CLIENTEJURIDICO.ToUpper(); 
	
						if(!oClienteBE.RAZONSOCIAL.IsNull)
						{
							txtNombre.Text = oClienteBE.RAZONSOCIAL.ToString().ToUpper();
						}

						//Hacer una consulta para traer el nombre del representante
						CRepresentanteCliente oCRepresentanteCliente = new CRepresentanteCliente();
						dtnombres = oCRepresentanteCliente.ObtenerNombreRepresentante(Convert.ToInt32(Convert.ToInt32(Page.Request.QueryString[KEYQIDCLIENTE])));

						if(dtnombres != null)
						{
							nroregistros = dtnombres.Rows.Count;
							i = 1;
							foreach(DataRow dr in dtnombres.Rows )
							{
								if(i < nroregistros)
								{
									this.txtRepresentante.Text = this.txtRepresentante.Text + dr[NOMBRE].ToString().ToUpper() + ", ";
								}
								else
								{
									this.txtRepresentante.Text = this.txtRepresentante.Text + dr[NOMBRE].ToString().ToUpper();
								}
								i++;
							}						 
						}
						else
						{
							ibtnDetalleRepresentante.Visible = false;
						}
					 
						//Hacer una consulta para traer el nombre del contacto
						CContactoCliente oCContactoCliente = new CContactoCliente();
						dtnombres = oCContactoCliente.ObtenerNombreContacto(Convert.ToInt32(Convert.ToInt32(Page.Request.QueryString[KEYQIDCLIENTE])));
				
						if(dtnombres != null)
						{
							nroregistros = dtnombres.Rows.Count;
							i = 1;
							foreach(DataRow dr1 in dtnombres.Rows )
							{
								if(i < nroregistros)
								{
									this.txtContacto.Text = this.txtContacto.Text + dr1[NOMBRE].ToString().ToUpper() + ", ";
								}
								else
								{
									this.txtContacto.Text = this.txtContacto.Text + dr1[NOMBRE].ToString().ToUpper();
								}
								i++;
							}
						}
						else
						{
							ibtnDetalleContacto.Visible = false;
						}
					}
					#endregion 
					
					#region Tipo de cliente Legal - Natural
					if(oClienteBE.IDTABLATIPOLEGALCLIENTE == Convert.ToInt32(Enumerados.TablasTabla.TablaTipoLegalCliente) && oClienteBE.IDTIPOLEGALCLIENTE == Convert.ToInt32(Enumerados.TipoLegalCliente.natural))
					{
						this.DesabilitarControlesClienteNatural();
						this.HabilitarControlesClienteNatural();

						this.cellRepresentante.Visible = false;
						this.cellRepresentantelbl.Visible = false;
						this.cellContacto.Visible = false;
						this.cellContactolbl.Visible = false;

						this.txtTipoClienteLegal.Text = Utilitario.Constantes.CLIENTENATURAL.ToUpper();
					
						if(!oClienteBE.NOMBRES.IsNull)
						{
							this.txtNombre.Text = oClienteBE.NOMBRES.Value;
						}
						if(!oClienteBE.APELLIDOPATERNO.IsNull)
						{
							this.txtApellidoPaterno.Text = oClienteBE.APELLIDOPATERNO.Value;
						}
						if(!oClienteBE.APELLIDOMATERNO.IsNull)
						{
							this.txtApellidoMaterno.Text = oClienteBE.APELLIDOMATERNO.Value;
						}
						
					}
					#endregion

					if(!oClienteBE.RUC.IsNull)
					{
						txtRUC.Text = oClienteBE.RUC.ToString().ToUpper();
					}		
				}
				else
				{
					this.txtNacionalidad.Text = Utilitario.Constantes.NACIONALIDADEXTRANJERO.ToUpper(); 
					this.rblTipoClienteLegal.Visible = false;
					this.lblTipoClienteLegal.Visible = false;
					this.lblNombre.Visible = false;
					this.lblRazonSocial.Visible = true;
			
					this.cellProvincialbl.Visible = false;
					this.CellddlbProvincia.Visible = false;
					this.cellDistritolbl.Visible = false;
					this.CellddlbProvincia.Visible = false;
					
				}

				//Datos Comunes
				CUbigeo oCUbigeo = new CUbigeo(); 
				DataRow drUbigeo = oCUbigeo.ObtenerNombreUbigeo(Convert.ToInt32(oClienteBE.IDUBIGEO.ToString()));

				if(Convert.ToInt32(drUbigeo[0].ToString()) < Utilitario.Constantes.NACIONALPERU ) 
				{
					this.HabilitarControlesUbigeoNacional();
					txtPais.Text = Utilitario.Constantes.NOMBREPERU.ToUpper();
					txtDepartamento.Text = drUbigeo[Utilitario.Constantes.POSICIONDEPARTAMENTO].ToString(); 
					txtProvincia.Text = drUbigeo[Utilitario.Constantes.POSICIONPROVINCIA].ToString();
					txtDistrito.Text = drUbigeo[Utilitario.Constantes.POSICIONDISTRITO].ToString();		
				}
				else
				{
					txtPais.Text = drUbigeo[Utilitario.Constantes.POSICIONPAIS].ToString();
					txtDepartamento.Text = drUbigeo[Utilitario.Constantes.POSICIONCIUDAD].ToString();
				}

				if(!oClienteBE.DIRECCION.IsNull)
				{
					txtDireccion.Text = oClienteBE.DIRECCION.ToString().ToUpper();
				}

				if(!oClienteBE.CORREOELECTRONICO.IsNull)
				{
					txtCorreoElectronico.Text = oClienteBE.CORREOELECTRONICO.ToString();
				}

				if(!oClienteBE.TELEFONO1.IsNull)
				{
					txtTelefono.Text = oClienteBE.TELEFONO1.ToString().ToUpper();
				}
				if(!oClienteBE.TELEFONO2.IsNull)
				{
					txtCelular.Text = oClienteBE.TELEFONO2.ToString().ToUpper();
				}
				if(!oClienteBE.FAX1.IsNull)
				{
					txtNroFax.Text = oClienteBE.FAX1.ToString().ToUpper();
				}

				item = ddlbTipoCliente.Items.FindByValue(oClienteBE.IDTIPOCLIENTE.ToString());
				if (item !=null){item.Selected = true;}
										
				if(!oClienteBE.IDTIPOACTIVIDAD.IsNull)
				{
					item = ddlbTipoActividad.Items.FindByValue(oClienteBE.IDTIPOACTIVIDAD.ToString());
					item.Selected = true;
				}

				if(!oClienteBE.IDTIPOCLASIFICACION.IsNull)
				{
					item = ddlbClasifcacion.Items.FindByValue(oClienteBE.IDTIPOCLASIFICACION.ToString());
					item.Selected = true;
				}
			
				if(!oClienteBE.OBSERVACIONES.IsNull)
				{
					txtObservaciones.Text = oClienteBE.OBSERVACIONES.ToString().ToUpper();
				}
			
				DataTable dtListaPromotores = oCCliente.ObtenerListaPromotores(Convert.ToInt32(Page.Request.QueryString[KEYQIDCLIENTE]));

				if(dtListaPromotores != null)
				{
					DataView dwListaPromotores = dtListaPromotores.DefaultView;

					if(dwListaPromotores.Count > Constantes.POSICIONCONTADOR)
					{
						grid.DataSource = dwListaPromotores;
					}
					else
					{
						grid.DataSource = null;
					}		
				}
				else
				{
					grid.DataSource = dtListaPromotores; 
				}
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

			Helper.BloquearControles(this);
		}


		public bool ValidarCampos()
		{
			return this.ValidarCamposRequeridos();
		}

		public bool ValidarCamposRequeridos()
		{
			if(this.rblNacionalidad.SelectedValue == Utilitario.Constantes.NACIONAL.ToString())
			{
				if(this.rblTipoClienteLegal.SelectedIndex < 0)
				{
					ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECLIENTECAMPOREQUERIDOTIPOCLIENTELEGAL));
					return false;
				}

				if(this.txtRUC.Text.Trim()== String.Empty)
				{
					ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECLIENTECAMPOREQUERIDODOCIDENTIDADRUC));
					return false;
				}

				//Si es un cliente natural
				if(rblTipoClienteLegal.SelectedValue == ClienteNatural.ToString())
				{
					if(txtApellidoPaterno.Text.Trim() == String.Empty)
					{
						ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECLIENTECAMPOREQUERIDOAPELLIDOPATERNO));
						return false;
					}

					if(txtApellidoMaterno.Text.Trim() == String.Empty)
					{
						ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECLIENTECAMPOREQUERIDOAPELLIDOMATERNO));
						return false;
					}
				}
			}
			
			if(this.txtNombre.Text.Trim()== String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECLIENTECAMPOREQUERIDONOMBRE));
				return false;
			}
			
			if(this.ddlbPais.SelectedValue == Utilitario.Constantes.VALORSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECLIENTECAMPOREQUERIDOPAIS));
				return false;
			}

			if(this.ddlbDepartamento.SelectedIndex < 0 || this.ddlbDepartamento.SelectedValue == Utilitario.Constantes.VALORSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECLIENTECAMPOREQUERIDODEPARTAMENTO));
				return false;
			}

			if(Convert.ToInt32(ddlbPais.SelectedValue) == Utilitario.Constantes.PERU)
			{
				if(this.ddlbProvincia.SelectedIndex < 0 || this.ddlbProvincia.SelectedValue == Utilitario.Constantes.VALORSELECCIONAR)
				{
					ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECLIENTECAMPOREQUERIDOPROVINCIA));
					return false;
				}

				if(this.ddlbDistrito.SelectedIndex < 0 || this.ddlbDistrito.SelectedValue == Utilitario.Constantes.VALORSELECCIONAR)
				{
					ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECLIENTECAMPOREQUERIDODISTRITO));
					return false;
				}
			}
			if(this.ddlbTipoCliente.SelectedValue == Utilitario.Constantes.VALORSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECLIENTECAMPOREQUERIDOTIPOCLIENTE));
				return false;
			}

			return true;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add ConsultarDetalleCliente.ValidarExpresionesRegulares implementation
			return false;
		}


		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			e.Item.Cells[Utilitario.Constantes.POSICIONCONTADOR].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);

			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{		
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				Helper.FiltroporSeleccionConfiguraColumna(e,grid);
			}
		}


		private void DesbloquerPersonalizado()
		{
			this.ibtnDetalleRepresentante.Visible = true;
			this.ibtnDetalleContacto.Visible = true;
			this.LlenarJScript();
		}


		private void DesabilitarControlesUbigeo()
		{
			this.ddlbPais.Visible = false;
			this.ddlbDepartamento.Visible = false;
			this.ddlbProvincia.Visible = false;
			this.ddlbDistrito.Visible = false;
		}

		private void HabilitarControlesUbigeoNacional()
		{
			this.txtProvincia.Visible = true;
			this.txtDistrito.Visible = true;
		}

		private void DesabilitarControlesClienteJuridico()
		{
			this.lblNombre.Visible = false;
			this.CellApellidoPaternolbl.Visible = false;
			this.cellApellidoPaterno.Visible = false;
			this.rfvApellidoPaterno.Visible = false;
			this.cellApellidoMaternolbl.Visible = false;
			this.cellApellidoMaterno.Visible = false;
			this.rfvApellidoMaterno.Visible = false;
		}


		private void HabilitarControlesClienteJuridico()
		{
			this.lblRazonSocial.Visible = true;
		}


		private void DesabilitarControlesClienteNatural()
		{
			this.lblRazonSocial.Visible = false;
		}


		private void HabilitarControlesClienteNatural()
		{
			this.lblNombre.Visible = true;

			this.CellApellidoPaternolbl.Visible = true;
			this.lblApellidoPaterno.Visible = true;
			this.cellApellidoPaterno.Visible = true;
			this.txtApellidoPaterno.Visible = true;
			this.rfvApellidoPaterno.Visible = true;

			this.cellApellidoMaternolbl.Visible = true;
			this.lblApellidoMaterno.Visible = true;
			this.cellApellidoMaterno.Visible = true;
			this.txtApellidoMaterno.Visible = true;
			this.rfvApellidoMaterno.Visible = true;
		}


		#region LlenarPais
		private void LlenarPais()
		{
			CUbigeo oCUbigeo = new CUbigeo();
			ddlbPais.DataSource = oCUbigeo.ListaTodosCombo();
			ddlbPais.DataValueField = Enumerados.ColumnasUbigeo.IdUbigeo.ToString();
			ddlbPais.DataTextField =Enumerados.ColumnasUbigeo.NombreProvincia.ToString();
			ddlbPais.DataBind();
		}

		#endregion

		#region LlenarTipoCliente
		private void LlenarTipoCliente()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			ddlbTipoCliente.DataSource = oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Enumerados.TablasTabla.TipoCliente));
			ddlbTipoCliente.DataValueField =  Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbTipoCliente.DataTextField = Enumerados.ColumnasTablaTablas.Var2.ToString();
			ddlbTipoCliente.DataBind();
		}


		#endregion

		#region LlenarActividad
		private void LlenarActividad()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			ddlbTipoActividad.DataSource = oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Enumerados.TablasTabla.TablaActividadCliente));
			ddlbTipoActividad.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbTipoActividad.DataTextField  = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbTipoActividad.DataBind();
		}
		#endregion

		#region LlenarClasificacion
		private void LlenarClasificacion ()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			ddlbClasifcacion.DataSource = oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Enumerados.TablasTabla.TablaClasificacionCliente));
			ddlbClasifcacion.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbClasifcacion.DataTextField  = Enumerados.ColumnasTablaTablas.Var1.ToString();
			ddlbClasifcacion.DataBind();
		}
		#endregion

		private void ibtnAceptar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				if(Page.IsValid)
				{
					if(this.ValidarCampos())
					{
						Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.QueryString[Constantes.KEYMODOPAGINA]) ;

						switch (oModoPagina)
						{
							case Enumerados.ModoPagina.M:
								this.Modificar();
								break;
						}
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
				SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
				Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
			}
			}

		private void rblTipoClienteLegal_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(rblTipoClienteLegal.SelectedValue == ClienteNatural.ToString())
			{
				this.lblNombre.Visible = true;
				this.lblRazonSocial.Visible = false;

				this.lblApellidoPaterno.Visible = true;
				this.txtApellidoPaterno.Visible = true;
				this.rfvApellidoPaterno.Visible = true;
				
				this.lblApellidoMaterno.Visible = true;
				this.txtApellidoMaterno.Visible = true;
				this.rfvApellidoMaterno.Visible = true;
                 
				this.CellApellidoPaternolbl.Visible = true;
				this.cellApellidoPaterno.Visible = true;
				this.cellApellidoMaternolbl.Visible = true;
				this.cellApellidoMaterno.Visible = true;
				
														   
			}
			else
			{
				this.lblNombre.Visible = false;
				this.lblRazonSocial.Visible = true;

				this.lblApellidoPaterno.Visible = false;
				this.txtApellidoPaterno.Visible = false;
				this.rfvApellidoPaterno.Visible = false;
				
				this.lblApellidoMaterno.Visible = false;
				this.txtApellidoMaterno.Visible = false;
				this.rfvApellidoMaterno.Visible = false;

				this.CellApellidoPaternolbl.Visible = false;
				this.cellApellidoPaterno.Visible = false;
				this.cellApellidoMaternolbl.Visible = false;
				this.cellApellidoMaterno.Visible = false;
				
			}
		}

		
		private void LlenarDepartamentoNacional()
		{
			item = new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,Utilitario.Constantes.VALORSELECCIONAR);

			CUbigeo oCUbigeo = new CUbigeo();
			ddlbDepartamento.DataSource = oCUbigeo.ListaDepartamentosNacional();
			ddlbDepartamento.DataTextField =Enumerados.ColumnasUbigeo.NombreDepartamento.ToString();
			ddlbDepartamento.DataBind();

			this.ddlbDepartamento.Items.Insert(0,item);
		}

		private void LlenarProvincia(string departemento)
		{
			item = new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,Utilitario.Constantes.VALORSELECCIONAR);

			CUbigeo oCUbigeo = new CUbigeo();
			ddlbProvincia.DataSource = oCUbigeo.LlenarProvincia(departemento);
			ddlbProvincia.DataTextField =Enumerados.ColumnasUbigeo.NombreProvincia.ToString();
			ddlbProvincia.DataBind();

			this.ddlbProvincia.Items.Insert(0,item);
		
		}

		private void LlenarDistrito(string provincia)
		{
			
			item = new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,Utilitario.Constantes.VALORSELECCIONAR);
			
			CUbigeo oCUbigeo = new CUbigeo();
			ddlbDistrito.DataSource = oCUbigeo.LlenarDistrito(provincia);
			ddlbDistrito.DataTextField =Enumerados.ColumnasUbigeo.NombreDistrito.ToString();
			ddlbDistrito.DataBind();

			this.ddlbDistrito.Items.Insert(0,item);
			
		}

		private void LlenarDepartamentoExt(string provincia)
		{
			
			item = new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,Utilitario.Constantes.VALORSELECCIONAR);
			
			CUbigeo oCUbigeo = new CUbigeo();
			ddlbDepartamento.DataSource = oCUbigeo.LlenarDistrito(provincia);
			ddlbDepartamento.DataTextField =Enumerados.ColumnasUbigeo.NombreDistrito.ToString();
			ddlbDepartamento.DataBind();

			this.ddlbDistrito.Items.Insert(0,item);
			
		}

		private void LlenarDepartamentoExtranjero(int IdUbigeoExtranjero)
		{
			item = new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,Utilitario.Constantes.VALORSELECCIONAR);
		
			CUbigeo oCUbigeo = new CUbigeo();
			ddlbDepartamento.DataSource = oCUbigeo.LlenarDepartamentoExtranjero(IdUbigeoExtranjero);
			ddlbDepartamento.DataTextField =Enumerados.ColumnasUbigeo.NombreDistrito.ToString();
			ddlbDepartamento.DataBind();

			this.ddlbDepartamento.Items.Insert(0,item);
		
		}


		private void ddlbPais_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(ddlbPais.SelectedIndex > -1)
			{
				if(rblNacionalidad.SelectedValue == Utilitario.Constantes.NACIONAL.ToString())
				{
					if(Convert.ToInt32(ddlbPais.SelectedValue) == Utilitario.Constantes.PERU)
					{
						this.LlenarDepartamentoNacional();
						this.HabilitarCombos();
					}
					else
					{
						ddlbPais.SelectedItem.Text = Utilitario.Constantes.NOMBREPERU;
					}
				}

				if(rblNacionalidad.SelectedValue == Utilitario.Constantes.EXTRANJERO.ToString())
				{
					if(Convert.ToInt32(ddlbPais.SelectedValue) != Utilitario.Constantes.PERU)
					{
						this.LlenarDepartamentoExtranjero(Convert.ToInt32(ddlbPais.SelectedValue));
						this.DesabilitarCombos();

					}
					else
					{
						ddlbPais.SelectedIndex = 0;
					}
				}
				
			}
		}

		private void ddlbDepartamento_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(rblNacionalidad.SelectedValue == Utilitario.Constantes.NACIONAL.ToString())
			{
				if(ddlbDepartamento.SelectedIndex > -1)
				{
					if(Convert.ToInt32(ddlbPais.SelectedValue) == Utilitario.Constantes.PERU)
					{
						this.LlenarProvincia(ddlbDepartamento.SelectedValue);
					}
				}

			}
			
		}

		private void ddlbProvincia_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(ddlbProvincia.SelectedIndex > -1)
			{
				if(Convert.ToInt32(ddlbPais.SelectedValue) == Utilitario.Constantes.PERU)
				{
					this.LlenarDistrito(ddlbProvincia.SelectedValue);
				}
			}
		}
 		

		private void HabilitarCombos()
		{
			this.lblProvincia.Visible = true;
			this.ddlbProvincia.Visible = true;

			this.lblDistrito.Visible = true;
			this.ddlbDistrito.Visible = true;
		}

		private void DesabilitarCombos()
		{
			this.lblProvincia.Visible = false;
			this.ddlbProvincia.Visible = false;

			this.lblDistrito.Visible = false;
			this.ddlbDistrito.Visible = false;
		}


		private void rblNacionalidad_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(this.rblNacionalidad.SelectedValue == Utilitario.Constantes.EXTRANJERO.ToString())
			{
				this.lblTipoClienteLegal.Visible = false;
				this.rblTipoClienteLegal.Visible = false;
				this.rfvTipoClienteLegal.Visible = false;
				this.lblNombre.Visible  = false;

				this.cellApellidoPaterno.Visible = false;
				this.CellApellidoPaternolbl.Visible = false;
				this.rfvApellidoPaterno.Visible = false;
				this.cellApellidoMaterno.Visible = false;
				this.cellApellidoMaternolbl.Visible = false;
				this.rfvApellidoMaterno.Visible = false;

				this.CellddlbProvincia.Visible = false;
				this.cellProvincialbl.Visible = false;
				this.rfvProvincia.Visible = false;
				this.cellddlbDistrito.Visible = false;
				this.cellDistritolbl.Visible = false;
				this.rfvDistrito.Visible = false;

				this.lblRazonSocial.Visible = true;
				this.txtRUC.ReadOnly = true;
				this.rfvRuc.Visible = false;
				this.ddlbPais.Enabled = true;

				item = new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,Utilitario.Constantes.VALORSELECCIONAR);
				this.LlenarPais();
				this.ddlbPais.Items.Insert(0,item);

				this.ddlbDepartamento.DataSource = null;
				this.ddlbDepartamento.Items.Clear();
				this.ddlbDepartamento.DataBind();
				
				this.ddlbProvincia.DataSource = null;
				this.ddlbProvincia.Items.Clear();
				this.ddlbProvincia.DataBind();

				this.ddlbDistrito.DataSource = null;
				this.ddlbDistrito.Items.Clear();
				this.ddlbDistrito.DataBind();
			}
			else
			{
				this.lblTipoClienteLegal.Visible = true;
				this.rblTipoClienteLegal.Visible = true;
				this.rfvTipoClienteLegal.Visible = true;
				this.lblRuc.Visible = true;
				this.txtRUC.Visible = true;
				this.txtRUC.ReadOnly = false;
				this.rfvRuc.Visible = true;
				this.LlenarPais();
				item = ddlbPais.Items.FindByValue(Utilitario.Constantes.PERU.ToString());
				if (item !=null){item.Selected = true;}
				this.ddlbPais.Enabled = false;
				this.LlenarDepartamentoNacional();


				if(this.rblTipoClienteLegal.SelectedValue == ClienteNatural.ToString())
				{
					this.lblRazonSocial.Visible = false;
					this.lblNombre.Visible  = true;
					this.lblApellidoPaterno.Visible = true;
					this.txtApellidoPaterno.Visible = true;
					this.rfvApellidoPaterno.Visible = true;
					this.lblApellidoMaterno.Visible = true;
					this.txtApellidoMaterno.Visible = true;
					this.rfvApellidoMaterno.Visible = true;

					this.cellApellidoPaterno.Visible = true;
					this.CellApellidoPaternolbl.Visible = true;
					this.cellApellidoMaterno.Visible = true;
					this.cellApellidoMaternolbl.Visible = true;

				}
				else
				{
					this.lblRazonSocial.Visible = true;
					this.lblNombre.Visible  = false;

					this.cellApellidoPaterno.Visible = false;
					this.CellApellidoPaternolbl.Visible = false;
					this.rfvApellidoPaterno.Visible = false;
					this.cellApellidoMaterno.Visible = false;
					this.cellApellidoMaternolbl.Visible = false;
					this.rfvApellidoMaterno.Visible = false;

				}
				
				this.lblProvincia.Visible = true;
				this.ddlbProvincia.Visible = true;
				this.rfvProvincia.Visible = true;

				this.lblDistrito.Visible = true;
				this.ddlbDistrito.Visible = true;
				this.rfvDistrito.Visible = true;

				this.CellddlbProvincia.Visible = true;
				this.cellProvincialbl.Visible = true;
				this.cellddlbDistrito.Visible = true;
				this.cellDistritolbl.Visible = true;

			}
		}

		private void rbtSI_CheckedChanged(object sender, System.EventArgs e)
		{
			if(rbtSI.Checked==true)
			{
				rbtNO.Checked=false;
			}
		}

		private void rbtNO_CheckedChanged(object sender, System.EventArgs e)
		{
			if(rbtNO.Checked==true)
			{
				rbtSI.Checked=false;
			}
		}

	}
}
