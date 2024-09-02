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
using MetaBuilders.WebControls;
using SIMA.EntidadesNegocio.General;


namespace SIMA.SimaNetWeb.GestionComercial.Cliente
{
	/// <summary>
	/// Summary description for PopupDetalleRepresentanteoContacto.
	/// </summary>
	public class PopupDetalleRepresentanteoContacto : System.Web.UI.Page,IPaginaBase, IPaginaMantenimento
	{
		#region Controles
		protected eWorld.UI.CalendarPopup CalOnomastico;
		protected System.Web.UI.WebControls.TextBox txtNombre;
		protected System.Web.UI.WebControls.TextBox txtDni;
		protected System.Web.UI.WebControls.TextBox txtApellidoPaterno;
		protected System.Web.UI.WebControls.TextBox txtApellidoMaterno;
		protected System.Web.UI.WebControls.TextBox txtTelefono;
		protected System.Web.UI.WebControls.TextBox txtCelular;
		protected System.Web.UI.WebControls.TextBox txtFax;
		protected System.Web.UI.WebControls.TextBox txtCorreo;
		protected System.Web.UI.WebControls.TextBox txtOnomastico;
		protected System.Web.UI.WebControls.TextBox txtCargo;
		protected System.Web.UI.WebControls.TextBox txtTituloProfesional;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label lblDatos;
		protected System.Web.UI.WebControls.Label lblCelular;
		protected System.Web.UI.WebControls.Label lblTelefono1;
		protected System.Web.UI.WebControls.Label lblApellidoMaterno;
		protected System.Web.UI.WebControls.Label lblApellidoPaterno;
		protected System.Web.UI.WebControls.Label lblDNI;
		protected System.Web.UI.WebControls.Label lblNombre;
		protected System.Web.UI.WebControls.Label lblFax;
		protected System.Web.UI.WebControls.Label lblCorreo;
		protected System.Web.UI.WebControls.Label lblOnomastico;
		protected System.Web.UI.WebControls.Label lblCargo;
		protected System.Web.UI.WebControls.Label lblTituloProfesional;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.Label lblTituloPrincipal;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.HtmlControls.HtmlTableCell TdCeldaCancelar;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnCancelar;
		#endregion

		#region Constantes

		//Titulos
		const string TITULOMODONUEVOREPRESENTANTE = "NUEVO REPRESENTANTE CLIENTE";
		const string TITULOMODOMODIFICARREPRESENTANTE = "REPRESENATNTE CLIENTE ";
		const string TITULOMODOCONSULTAREPRESENTANTE = "DETALLES DEL REPRESENTANTE CLIENTE";

		const string TITULOMODONUEVOCONTACTO = "NUEVO CONTACTO CLIENTE";
		const string TITULOMODOMODIFICARCONTACTO = "CONTACTO CLIENTE ";
		const string TITULOMODOCONSULTACONTACTO = "DETALLES DEL CONTACTO CLIENTE";

		//Key Session y QueryString
		const string KEYQIDCLIENTE = "IdCliente";
		const string KEYQIDREPRECONT = "IdRepreCont";
		const string FLAGREPRESENTANTE = "FlagRepresentante";
		const string FLAGCONTATO = "FlagContacto";
		const string FLAGREPRECONTAC = "FlagRepreContac";
		const string paginarepresenatante = " Representantes";
		const string paginacontacto = " Contacto";

		const string FLAG = "Flag";
		const string REPRESENTANTECONTACTO = "RepresentanteContacto";

		#endregion

		#region Variables				
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
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se consulto el detalle del Contacto o Representante del Cliente",Enumerados.NivelesErrorLog.I.ToString()));
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
			this.ibtnAceptar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAceptar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add PopupDetalleRepresentanteoContacto.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add PopupDetalleRepresentanteoContacto.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add PopupDetalleRepresentanteoContacto.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add PopupDetalleRepresentanteoContacto.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			CMantenimientos	oCMantenimientos = new CMantenimientos();
			CCargo oCCargo = new CCargo();
			if(Convert.ToInt32(Page.Request.QueryString[FLAGREPRECONTAC]) == Utilitario.Constantes.REPRESENTANTE)
			{
				lblTituloPrincipal.Text = lblTituloPrincipal.Text + representante;
				RepresentanteClienteBE oRepresentanteClienteBE = (RepresentanteClienteBE)oCMantenimientos.ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYQIDREPRECONT]),Enumerados.ClasesNTAD.RepresentanteClienteNTAD.ToString());

				txtNombre.Text = oRepresentanteClienteBE.NOMBRES.ToString().ToUpper();
				txtDni.Text = oRepresentanteClienteBE.DNI.ToString().ToUpper();
				txtApellidoPaterno.Text = oRepresentanteClienteBE.APELLIDOPATERNO.ToString().ToUpper();
				txtApellidoMaterno.Text = oRepresentanteClienteBE.APELLIDOMATERNO.ToString().ToUpper();

				if(!oRepresentanteClienteBE.TELEFONO1.IsNull)
				{
					txtTelefono.Text = oRepresentanteClienteBE.TELEFONO1.ToString().ToUpper();
				}
				if(!oRepresentanteClienteBE.TELEFONO2.IsNull)
				{
					txtCelular.Text = oRepresentanteClienteBE.TELEFONO2.ToString().ToUpper();
				}
				if(!oRepresentanteClienteBE.FAX1.IsNull)
				{
					txtFax.Text = oRepresentanteClienteBE.FAX1.ToString().ToUpper();
				}
				if(!oRepresentanteClienteBE.CORREOELECTRONICO.IsNull)
				{
					txtCorreo.Text = oRepresentanteClienteBE.CORREOELECTRONICO.ToString().ToUpper();
				}
				if(!oRepresentanteClienteBE.ONOMASTICO.IsNull)
				{
					txtOnomastico.Text = oRepresentanteClienteBE.ONOMASTICO.ToString().ToUpper();
				}

				if(!oRepresentanteClienteBE.IDCARGO.IsNull)
				{
					txtCargo.Text =  oCCargo.ObtenerDescripcionCargo(Convert.ToInt32(oRepresentanteClienteBE.IDCARGO)).ToUpper();
				}

			}
			else
			{
				lblTituloPrincipal.Text = lblTituloPrincipal.Text + contacto;
				CONTACTOCLIENTEBE oCONTACTOCLIENTEBE = (CONTACTOCLIENTEBE)oCMantenimientos.ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYQIDREPRECONT]),Enumerados.ClasesNTAD.ContactoClienteNTAD.ToString());
				
				txtNombre.Text = oCONTACTOCLIENTEBE.NOMBRES.ToString().ToUpper();

				if(!oCONTACTOCLIENTEBE.DNI.IsNull)
				{
					txtDni.Text = oCONTACTOCLIENTEBE.DNI.ToString().ToUpper();
				}

				txtApellidoPaterno.Text = oCONTACTOCLIENTEBE.APELLIDOPATERNO.ToString().ToUpper();
				txtApellidoMaterno.Text = oCONTACTOCLIENTEBE.APELLIDOMATERNO.ToString().ToUpper();

				if(!oCONTACTOCLIENTEBE.TELEFONO1.IsNull)
				{
					txtTelefono.Text = oCONTACTOCLIENTEBE.TELEFONO1.ToString().ToUpper();
				}
				if(!oCONTACTOCLIENTEBE.TELEFONO2.IsNull)
				{
					txtCelular.Text = oCONTACTOCLIENTEBE.TELEFONO2.ToString().ToUpper();
				}
				if(!oCONTACTOCLIENTEBE.FAX1.IsNull)
				{
					txtFax.Text = oCONTACTOCLIENTEBE.FAX1.ToString().ToUpper();
				}
				if(!oCONTACTOCLIENTEBE.CORREOELECTRONICO.IsNull)
				{
					txtCorreo.Text = oCONTACTOCLIENTEBE.CORREOELECTRONICO.ToString().ToUpper();
				}
				if(!oCONTACTOCLIENTEBE.ONOMASTICO.IsNull)
				{
					txtOnomastico.Text = oCONTACTOCLIENTEBE.ONOMASTICO.ToString().ToUpper();
				}
				if(!oCONTACTOCLIENTEBE.IDCARGO.IsNull)
				{
					if(oCONTACTOCLIENTEBE.IDCARGO.ToNullableInt64() != Utilitario.Constantes.FLAGDEFAULT)
					{
						txtCargo.Text = oCCargo.ObtenerDescripcionCargo(Convert.ToInt32(oCONTACTOCLIENTEBE.IDCARGO)).ToUpper();
					}
				}

			}
		}


		public void LlenarJScript()
		{
			// TODO:  Add PopupDetalleRepresentanteoContacto.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add PopupDetalleRepresentanteoContacto.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add PopupDetalleRepresentanteoContacto.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add PopupDetalleRepresentanteoContacto.Exportar implementation
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
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			if(Page.Request.QueryString[REPRESENTANTECONTACTO] == representante.ToString())
			{
				RepresentanteClienteBE oRepresentanteClienteBE = new RepresentanteClienteBE();
				
				oRepresentanteClienteBE.NOMBRES = txtNombre.Text;
				oRepresentanteClienteBE.APELLIDOPATERNO = txtApellidoPaterno.Text;
				oRepresentanteClienteBE.APELLIDOMATERNO = txtApellidoMaterno.Text;
				oRepresentanteClienteBE.DNI = Convert.ToInt32(txtDni.Text);

				if(this.txtTelefono.Text.Trim() != String.Empty)
				{
					oRepresentanteClienteBE.TELEFONO1 = this.txtTelefono.Text;
				}
				if(this.txtFax.Text.Trim() != String.Empty)
				{
					oRepresentanteClienteBE.FAX1 = this.txtFax.Text;
				}
				if(this.txtCorreo.Text.Trim() != String.Empty)
				{
					oRepresentanteClienteBE.CORREOELECTRONICO = this.txtCorreo.Text;
				}
				if(!this.CalOnomastico.Nullable)
				{
					oRepresentanteClienteBE.ONOMASTICO = Convert.ToDateTime(this.CalOnomastico.SelectedDate);
				}
				if(this.txtCargo.Text.Trim() != String.Empty)
				{
					oRepresentanteClienteBE.CARGO = this.txtCargo.Text;
				}

				if(this.txtTituloProfesional.Text.Trim() != String.Empty)
				{
					oRepresentanteClienteBE.TITULOPROFESIONAL = this.txtTituloProfesional.Text;
				}

				oRepresentanteClienteBE.IDUSUARIOREGISTRO =  CNetAccessControl.GetIdUser();
				oRepresentanteClienteBE.IDTABLAESTADO = Convert.ToInt32(Enumerados.TablasTabla.EstadoRepresentanteCliente);
				oRepresentanteClienteBE.IDESTADO = Convert.ToInt32(Enumerados.EstadosRepresentantesClientes.Activo); 

				CRepresentanteCliente oCRepresentanteCliente = new CRepresentanteCliente();
				int retorno = oCRepresentanteCliente.InsertarRepresentanteCliente(oRepresentanteClienteBE, Convert.ToInt32(Page.Request.QueryString[KEYQIDCLIENTE]));
				
				if(retorno>0)
				{
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se registró un reprensante cliente. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));
					ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionComercial.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONREGISTROREPRESENTANTECLIENTE));
				}

			}
			else
			{
				CONTACTOCLIENTEBE oCONTACTOCLIENTEBE = new CONTACTOCLIENTEBE();
				
				oCONTACTOCLIENTEBE.NOMBRES = txtNombre.Text;
				oCONTACTOCLIENTEBE.APELLIDOPATERNO = txtApellidoPaterno.Text;
				oCONTACTOCLIENTEBE.APELLIDOMATERNO = txtApellidoMaterno.Text;
				oCONTACTOCLIENTEBE.DNI = Convert.ToInt32(txtDni.Text);

				if(this.txtTelefono.Text.Trim() != String.Empty)
				{
					oCONTACTOCLIENTEBE.TELEFONO1 = this.txtTelefono.Text;
				}
				if(this.txtFax.Text.Trim() != String.Empty)
				{
					oCONTACTOCLIENTEBE.FAX1 = this.txtFax.Text;
				}
				if(this.txtCorreo.Text.Trim() != String.Empty)
				{
					oCONTACTOCLIENTEBE.CORREOELECTRONICO = this.txtCorreo.Text;
				}
				if(!this.CalOnomastico.Nullable)
				{
					oCONTACTOCLIENTEBE.ONOMASTICO = Convert.ToDateTime(this.CalOnomastico.SelectedDate);
				}
				if(this.txtCargo.Text.Trim() != String.Empty)
				{
					oCONTACTOCLIENTEBE.CARGO = this.txtCargo.Text;
				}
				if(this.txtTituloProfesional.Text.Trim() != String.Empty)
				{
					oCONTACTOCLIENTEBE.TITULOPROFESIONAL = this.txtTituloProfesional.Text;
				}

				oCONTACTOCLIENTEBE.IDUSUARIOREGISTRO =  CNetAccessControl.GetIdUser();
				oCONTACTOCLIENTEBE.IDTABLAESTADO = Convert.ToInt32(Enumerados.TablasTabla.EstadoContactoCliente);
				oCONTACTOCLIENTEBE.IDESTADO = Convert.ToInt32(Enumerados.EstadosContactosClientes.Activo); 


				CContactoCliente oCContactoCliente = new CContactoCliente();
				int retorno = oCContactoCliente.InsertarContactoCliente(oCONTACTOCLIENTEBE, Convert.ToInt32(Page.Request.QueryString[KEYQIDCLIENTE]));

				if(retorno>0)
				{
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se registró un contacto cliente. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));
					ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionComercial.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONREGISTROCONATCTOCLIENTE));
				}
			}
		}


		public void Modificar()
		{
			if(Page.Request.QueryString[REPRESENTANTECONTACTO] == representante.ToString())
			{
				RepresentanteClienteBE oRepresentanteClienteBE = new RepresentanteClienteBE();
				
				oRepresentanteClienteBE.IDREPRESENTANTECLIENTE = Convert.ToInt32(Page.Request.QueryString[KEYQIDREPRECONT]);
				oRepresentanteClienteBE.NOMBRES = txtNombre.Text;
				oRepresentanteClienteBE.APELLIDOPATERNO = txtApellidoPaterno.Text;
				oRepresentanteClienteBE.APELLIDOMATERNO = txtApellidoMaterno.Text;
				oRepresentanteClienteBE.DNI = Convert.ToInt32(txtDni.Text);

				if(this.txtTelefono.Text.Trim() != String.Empty)
				{
					oRepresentanteClienteBE.TELEFONO1 = this.txtTelefono.Text;
				}
				if(this.txtFax.Text.Trim() != String.Empty)
				{
					oRepresentanteClienteBE.FAX1 = this.txtFax.Text;
				}
				if(this.txtCorreo.Text.Trim() != String.Empty)
				{
					oRepresentanteClienteBE.CORREOELECTRONICO = this.txtCorreo.Text;
				}
				if(!this.CalOnomastico.Nullable)
				{
					oRepresentanteClienteBE.ONOMASTICO = Convert.ToDateTime(this.CalOnomastico.SelectedDate);
				}
				if(this.txtCargo.Text.Trim() != String.Empty)
				{
					oRepresentanteClienteBE.CARGO = this.txtCargo.Text;
				}

				if(this.txtTituloProfesional.Text.Trim() != String.Empty)
				{
					oRepresentanteClienteBE.TITULOPROFESIONAL = this.txtTituloProfesional.Text;
				}

				oRepresentanteClienteBE.IDUSUARIOACTUALIZACION =  CNetAccessControl.GetIdUser();
				
				CMantenimientos oCMantenimientos = new CMantenimientos();
				int retorno = oCMantenimientos.Modificar(oRepresentanteClienteBE);

				if(retorno>0)
				{
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se modifico un reprensante cliente. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));
					ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionComercial.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONMODIFICOREPRESENTANTECLIENTE));
				}

			}
			else
			{
				CONTACTOCLIENTEBE oCONTACTOCLIENTEBE = new CONTACTOCLIENTEBE();
				
				oCONTACTOCLIENTEBE.IDCONTACTOCLIENTE = Convert.ToInt32(Page.Request.QueryString[KEYQIDREPRECONT]);
				oCONTACTOCLIENTEBE.NOMBRES = txtNombre.Text;
				oCONTACTOCLIENTEBE.APELLIDOPATERNO = txtApellidoPaterno.Text;
				oCONTACTOCLIENTEBE.APELLIDOMATERNO = txtApellidoMaterno.Text;
				oCONTACTOCLIENTEBE.DNI = Convert.ToInt32(txtDni.Text);

				if(this.txtTelefono.Text.Trim() != String.Empty)
				{
					oCONTACTOCLIENTEBE.TELEFONO1 = this.txtTelefono.Text;
				}
				if(this.txtFax.Text.Trim() != String.Empty)
				{
					oCONTACTOCLIENTEBE.FAX1 = this.txtFax.Text;
				}
				if(this.txtCorreo.Text.Trim() != String.Empty)
				{
					oCONTACTOCLIENTEBE.CORREOELECTRONICO = this.txtCorreo.Text;
				}
				if(!this.CalOnomastico.Nullable)
				{
					oCONTACTOCLIENTEBE.ONOMASTICO = Convert.ToDateTime(this.CalOnomastico.SelectedDate);
				}
				if(this.txtCargo.Text.Trim() != String.Empty)
				{
					oCONTACTOCLIENTEBE.CARGO = this.txtCargo.Text;
				}
				if(this.txtTituloProfesional.Text.Trim() != String.Empty)
				{
					oCONTACTOCLIENTEBE.TITULOPROFESIONAL = this.txtTituloProfesional.Text;
				}

				oCONTACTOCLIENTEBE.IDUSUARIOACTUALIZACION =  CNetAccessControl.GetIdUser();
	
				CMantenimientos oCMantenimientos = new CMantenimientos();
				int retorno = oCMantenimientos.Modificar(oCONTACTOCLIENTEBE);

				if(retorno>0)
				{
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se modificó un contacto cliente. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));
					ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionComercial.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONMODIFICOCONTACROCLIENTE));
				}

			}
			
		}


		public void Eliminar()
		{
			// TODO:  Add PopupDetalleRepresentanteoContacto.Eliminar implementation
		}


		public void CargarModoPagina()
		{
			Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.QueryString[Utilitario.Constantes.KEYMODOPAGINA]) ;

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
			if(Page.Request.QueryString[REPRESENTANTECONTACTO] == representante.ToString())
			{
				lblTituloPrincipal.Text = TITULOMODONUEVOREPRESENTANTE;
			}
			else
			{
				lblTituloPrincipal.Text = TITULOMODONUEVOCONTACTO;
			}
			this.TdCeldaCancelar.Visible = false;
			this.txtOnomastico.Visible = false;
		}

		public void CargarModoModificar()
		{
			if(Page.Request.QueryString[REPRESENTANTECONTACTO] == representante.ToString())
			{
				lblTituloPrincipal.Text = TITULOMODOMODIFICARREPRESENTANTE;
				CMantenimientos	oCMantenimientos = new CMantenimientos();
				RepresentanteClienteBE oRepresentanteClienteBE = (RepresentanteClienteBE)oCMantenimientos.ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYQIDREPRECONT]),Enumerados.ClasesNTAD.RepresentanteClienteNTAD.ToString());

				if(oRepresentanteClienteBE != null)
				{
					this.txtNombre.Text = oRepresentanteClienteBE.NOMBRES.ToString().ToUpper();
					this.txtApellidoPaterno.Text = oRepresentanteClienteBE.APELLIDOPATERNO.ToString().ToUpper();
					this.txtApellidoMaterno.Text = oRepresentanteClienteBE.APELLIDOMATERNO.ToString().ToUpper();
					this.txtDni.Text = oRepresentanteClienteBE.DNI.ToString().ToUpper();
					if(!oRepresentanteClienteBE.TELEFONO1.IsNull)
					{
						this.txtTelefono.Text = oRepresentanteClienteBE.TELEFONO1.ToString().ToUpper();
					}
					if(!oRepresentanteClienteBE.TELEFONO2.IsNull)
					{
						this.txtCelular.Text = oRepresentanteClienteBE.TELEFONO2.ToString().ToUpper();
					}
					if(!oRepresentanteClienteBE.FAX1.IsNull)
					{
						this.txtFax.Text = oRepresentanteClienteBE.FAX1.ToString().ToUpper();
					}
					if(!oRepresentanteClienteBE.CORREOELECTRONICO.IsNull)
					{
						this.txtCorreo.Text = oRepresentanteClienteBE.CORREOELECTRONICO.ToString().ToUpper();
					}
					if(!oRepresentanteClienteBE.ONOMASTICO.IsNull)
					{
						this.CalOnomastico.SelectedDate = Convert.ToDateTime(oRepresentanteClienteBE.ONOMASTICO);
					}
					if(!oRepresentanteClienteBE.CARGO.IsNull)
					{
						this.txtCargo.Text = oRepresentanteClienteBE.CARGO.ToString().ToUpper();
					}
					if(!oRepresentanteClienteBE.TITULOPROFESIONAL.IsNull)
					{
						this.txtTituloProfesional.Text = oRepresentanteClienteBE.TITULOPROFESIONAL.ToString().ToUpper();
					}
				}
				
			}
			else
			{
				lblTituloPrincipal.Text = TITULOMODOMODIFICARCONTACTO;
				CMantenimientos	oCMantenimientos = new CMantenimientos();
				CONTACTOCLIENTEBE oCONTACTOCLIENTEBE= (CONTACTOCLIENTEBE)oCMantenimientos.ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYQIDREPRECONT]),Enumerados.ClasesNTAD.ContactoClienteNTAD.ToString());

				if(oCONTACTOCLIENTEBE != null)
				{
					this.txtNombre.Text = oCONTACTOCLIENTEBE.NOMBRES.ToString().ToUpper();
					this.txtApellidoPaterno.Text = oCONTACTOCLIENTEBE.APELLIDOPATERNO.ToString().ToUpper();
					this.txtApellidoMaterno.Text = oCONTACTOCLIENTEBE.APELLIDOMATERNO.ToString().ToUpper();
					this.txtDni.Text = oCONTACTOCLIENTEBE.DNI.ToString().ToUpper();

					if(!oCONTACTOCLIENTEBE.TELEFONO1.IsNull)
					{
						this.txtTelefono.Text = oCONTACTOCLIENTEBE.TELEFONO1.ToString().ToUpper();
					}
					if(!oCONTACTOCLIENTEBE.TELEFONO2.IsNull)
					{
						this.txtCelular.Text = oCONTACTOCLIENTEBE.TELEFONO2.ToString().ToUpper();
					}
					if(!oCONTACTOCLIENTEBE.FAX1.IsNull)
					{
						this.txtFax.Text = oCONTACTOCLIENTEBE.FAX1.ToString().ToUpper();
					}
					if(!oCONTACTOCLIENTEBE.CORREOELECTRONICO.IsNull)
					{
						this.txtCorreo.Text = oCONTACTOCLIENTEBE.CORREOELECTRONICO.ToString().ToUpper();
					}
					if(!oCONTACTOCLIENTEBE.ONOMASTICO.IsNull)
					{
						this.CalOnomastico.SelectedDate = Convert.ToDateTime(oCONTACTOCLIENTEBE.ONOMASTICO);
					}
					if(!oCONTACTOCLIENTEBE.CARGO.IsNull)
					{
						this.txtCargo.Text = oCONTACTOCLIENTEBE.CARGO.ToString().ToUpper();
					}
					if(!oCONTACTOCLIENTEBE.TITULOPROFESIONAL.IsNull)
					{
						this.txtTituloProfesional.Text = oCONTACTOCLIENTEBE.TITULOPROFESIONAL.ToString().ToUpper();
					}
				}
			}
			this.TdCeldaCancelar.Visible = false;
			this.txtOnomastico.Visible = false;
		}

		public void CargarModoConsulta()
		{
			this.txtOnomastico.Visible = true;
			this.CalOnomastico.Visible = false;
			this.TdCeldaCancelar.Visible = true;
			this.ibtnAceptar.Visible = false;
			this.ibtnCancelar.Visible = false;

			if(Page.Request.QueryString[REPRESENTANTECONTACTO] == representante.ToString())
			{
				lblTituloPrincipal.Text = TITULOMODOMODIFICARREPRESENTANTE;
				CMantenimientos	oCMantenimientos = new CMantenimientos();
				RepresentanteClienteBE oRepresentanteClienteBE = (RepresentanteClienteBE)oCMantenimientos.ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYQIDREPRECONT]),Enumerados.ClasesNTAD.RepresentanteClienteNTAD.ToString());

				if(oRepresentanteClienteBE != null)
				{
					this.txtNombre.Text = oRepresentanteClienteBE.NOMBRES.ToString().ToUpper();
					this.txtApellidoPaterno.Text = oRepresentanteClienteBE.APELLIDOPATERNO.ToString().ToUpper();
					this.txtApellidoMaterno.Text = oRepresentanteClienteBE.APELLIDOMATERNO.ToString().ToUpper();
					this.txtDni.Text = oRepresentanteClienteBE.DNI.ToString().ToUpper();

					if(!oRepresentanteClienteBE.TELEFONO1.IsNull)
					{
						this.txtTelefono.Text = oRepresentanteClienteBE.TELEFONO1.ToString().ToUpper();
					}
					if(!oRepresentanteClienteBE.TELEFONO2.IsNull)
					{
						this.txtCelular.Text = oRepresentanteClienteBE.TELEFONO2.ToString().ToUpper();
					}
					if(!oRepresentanteClienteBE.FAX1.IsNull)
					{
						this.txtFax.Text = oRepresentanteClienteBE.FAX1.ToString().ToUpper();
					}
					if(!oRepresentanteClienteBE.CORREOELECTRONICO.IsNull)
					{
						this.txtCorreo.Text = oRepresentanteClienteBE.CORREOELECTRONICO.ToString().ToUpper();
					}
					if(!oRepresentanteClienteBE.ONOMASTICO.IsNull)
					{
						this.CalOnomastico.SelectedDate = Convert.ToDateTime(oRepresentanteClienteBE.ONOMASTICO);
					}
					if(!oRepresentanteClienteBE.CARGO.IsNull)
					{
						this.txtCargo.Text = oRepresentanteClienteBE.CARGO.ToString().ToUpper();
					}
					if(!oRepresentanteClienteBE.TITULOPROFESIONAL.IsNull)
					{
						this.txtTituloProfesional.Text = oRepresentanteClienteBE.TITULOPROFESIONAL.ToString().ToUpper();
					}
				}
				
			}
			else
			{
				lblTituloPrincipal.Text = TITULOMODOMODIFICARCONTACTO;
				CMantenimientos	oCMantenimientos = new CMantenimientos();
				CONTACTOCLIENTEBE oCONTACTOCLIENTEBE= (CONTACTOCLIENTEBE)oCMantenimientos.ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYQIDREPRECONT]),Enumerados.ClasesNTAD.ContactoClienteNTAD.ToString());

				if(oCONTACTOCLIENTEBE != null)
				{
					this.txtNombre.Text = oCONTACTOCLIENTEBE.NOMBRES.ToString().ToUpper();
					this.txtApellidoPaterno.Text = oCONTACTOCLIENTEBE.APELLIDOPATERNO.ToString().ToUpper();
					this.txtApellidoMaterno.Text = oCONTACTOCLIENTEBE.APELLIDOMATERNO.ToString().ToUpper();
					this.txtDni.Text = oCONTACTOCLIENTEBE.DNI.ToString().ToUpper();

					if(!oCONTACTOCLIENTEBE.TELEFONO1.IsNull)
					{
						this.txtTelefono.Text = oCONTACTOCLIENTEBE.TELEFONO1.ToString().ToUpper();
					}
					if(!oCONTACTOCLIENTEBE.TELEFONO2.IsNull)
					{
						this.txtCelular.Text = oCONTACTOCLIENTEBE.TELEFONO2.ToString().ToUpper();
					}
					if(!oCONTACTOCLIENTEBE.FAX1.IsNull)
					{
						this.txtFax.Text = oCONTACTOCLIENTEBE.FAX1.ToString().ToUpper();
					}
					if(!oCONTACTOCLIENTEBE.CORREOELECTRONICO.IsNull)
					{
						this.txtCorreo.Text = oCONTACTOCLIENTEBE.CORREOELECTRONICO.ToString().ToUpper();
					}
					if(!oCONTACTOCLIENTEBE.ONOMASTICO.IsNull)
					{
						this.CalOnomastico.SelectedDate = Convert.ToDateTime(oCONTACTOCLIENTEBE.ONOMASTICO);
					}
					if(!oCONTACTOCLIENTEBE.CARGO.IsNull)
					{
						this.txtCargo.Text = oCONTACTOCLIENTEBE.CARGO.ToString().ToUpper();
					}
					if(!oCONTACTOCLIENTEBE.TITULOPROFESIONAL.IsNull)
					{
						this.txtTituloProfesional.Text = oCONTACTOCLIENTEBE.TITULOPROFESIONAL.ToString().ToUpper();
					}
				}
			}
			Helper.BloquearControles(this);
		}

		public bool ValidarCampos()
		{
			return this.ValidarCamposRequeridos();
		}

		public bool ValidarCamposRequeridos()
		{
			if(txtNombre.Text.Trim() == String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEREPRESENTANTECLIENTECAMPOREQUERIDONOMBRE));
				return false;
			}
			else if(txtApellidoPaterno.Text.Trim() == String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEREPRESENTANTECAMPOREQUERIDOAPELLIDOPATERNO));
				return false;
			}
			else if(txtApellidoMaterno.Text.Trim() == String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEREPRESENTANTECAMPOREQUERIDOAPELLIDOMATERNO));
				return false;
			}
			else if(txtDni.Text.Trim() == String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEREPRESENTANTECAMPOREQUERIDODNI));
				return false;
			}
			else
			{
				return true;
			}
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add PopupDetalleRepresentanteoContacto.ValidarExpresionesRegulares implementation
			return false;
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
						Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.QueryString[Utilitario.Constantes.KEYMODOPAGINA]) ;

						switch (oModoPagina)
						{
							case Enumerados.ModoPagina.N:
								this.Agregar();
								break;
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
				SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Utilitario.Constantes.CODIGOERRORGENERICO,oException.Message);
				Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
			}

		}
	}
}
