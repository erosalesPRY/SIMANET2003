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
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using SIMA.EntidadesNegocio.GestionComercial;

namespace SIMA.SimaNetWeb.GestionComercial.ComunicacionImagen
{
	/// <summary>
	/// Summary description for DetallePresentesOtorgadosPorTipoPersona.
	/// </summary>
	public class DetallePresentesOtorgadosPorTipoPersona: System.Web.UI.Page, IPaginaMantenimento, IPaginaBase
	{
		#region Controles

		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary vSum;
		protected System.Web.UI.WebControls.TextBox txtObservaciones;
		protected System.Web.UI.WebControls.Label lblObservaciones;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.Label lblDescripcion;
		protected eWorld.UI.NumericBox nbCantidad;
		protected System.Web.UI.WebControls.Label lblCantidad;
		protected System.Web.UI.WebControls.DropDownList ddlbPresente;
		protected System.Web.UI.WebControls.Label lblPresente;
		protected System.Web.UI.WebControls.TextBox txtDirectiva;
		protected System.Web.UI.WebControls.Label lblDirectiva;
		protected System.Web.UI.WebControls.DropDownList ddlbTipoDocumento;
		protected System.Web.UI.WebControls.Label lblTipoDocumento;
		protected System.Web.UI.WebControls.DropDownList ddlbCentroOperativo;
		protected System.Web.UI.WebControls.Label lblCentroOperativo;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvNombres;
		protected System.Web.UI.WebControls.ImageButton ibtnBuscarEntidad;
		protected System.Web.UI.WebControls.TextBox txtEntidad;
		protected System.Web.UI.WebControls.Label lblNombres;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdCodigo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdOrigen;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdTablaOrigen;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvCentroOperativo;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvPresente;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvCantidad;
		protected System.Web.UI.HtmlControls.HtmlTableCell TdCeldaCancelar;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlbCentroOperativo;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlbTipoDocumento;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlbPresente;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnCancelar;

		#endregion Controles
		
		#region Constantes
		
		//Titulos 
		const string TITULOMODONUEVO = "NUEVO PRESENTE OTORGADO A PERSONAS";
		const string TITULOMODOMODIFICAR = "ACTUALIZACION PRESENTE OTORGADO A PERSONAS";
		const string TITULOMODOCONSULTA = "DETALLE PRESENTE OTORGADO A PERSONAS";

		//Key Session y QueryString
		const string KEYQID = "Id";
		const string KEYQIDPRESENTE = "IdPresente";
		const string KEYQCANTIDAD = "Cantidad";
	
		//Paginas
		const string URLBUSQUEDAENTIDAD = "../../Legal/BusquedaEntidad.aspx?";
		
		#endregion Constantes		
		
		#region Variables
		ListItem  lItem ;
		#endregion Variables

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

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			ListaProtocolarBE oListaProtocolarBE = new ListaProtocolarBE();
			oListaProtocolarBE.CantidadAtendida = Convert.ToInt32(this.nbCantidad.Text);
			if(this.txtDirectiva.Text.Trim()!=String.Empty)
			{
				oListaProtocolarBE.Directiva = this.txtDirectiva.Text;
			}
			if(this.ddlbTipoDocumento.SelectedValue != Constantes.VALORSELECCIONAR)
			{
				oListaProtocolarBE.IdTablaDocumento = Convert.ToInt32(Enumerados.TablasTabla.SecretariaTipoDocumento);
				oListaProtocolarBE.IdDocumento = Convert.ToInt32(this.ddlbTipoDocumento.SelectedValue);
			}
			oListaProtocolarBE.IdCodigo = Convert.ToInt32(this.hIdCodigo.Value);
			oListaProtocolarBE.IdOrigen = Convert.ToInt32(this.hIdOrigen.Value);
			oListaProtocolarBE.IdTablaOrigen = Convert.ToInt32(this.hIdTablaOrigen.Value);
			oListaProtocolarBE.IdCentroOperativo = Convert.ToInt32(this.ddlbCentroOperativo.SelectedValue);
			oListaProtocolarBE.IdPresenteRelacionPublica = Convert.ToInt32(this.ddlbPresente.SelectedValue);
			oListaProtocolarBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();
			oListaProtocolarBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.EstadosListaProtocolarPersonas);
			oListaProtocolarBE.IdEstado = Convert.ToInt32(Enumerados.EstadosListaProtocolarPersonas.Activo);
			if(this.txtDescripcion.Text.Trim()!=String.Empty)
			{
				oListaProtocolarBE.Descripcion = this.txtDescripcion.Text;
			}
			if(this.txtObservaciones.Text.Trim()!=String.Empty)
			{
				oListaProtocolarBE.Observaciones = this.txtObservaciones.Text;
			}

			CPresentes oCPresentes = new CPresentes();

			int existencia = oCPresentes.ObtenerExistenciaPresente(oListaProtocolarBE.IdPresenteRelacionPublica);

			if(existencia >= oListaProtocolarBE.CantidadAtendida)
			{
				CPresentesOtorgadosPorTipoPersona oCPresentesOtorgadosPorTipoPersona = new CPresentesOtorgadosPorTipoPersona();
				int retorno = oCPresentesOtorgadosPorTipoPersona.RegistrarPresentesOtorgadosPersona(oListaProtocolarBE,oListaProtocolarBE.IdPresenteRelacionPublica,oListaProtocolarBE.CantidadAtendida);
				if(retorno>0)
				{
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se registró el Presente Otorgado Nro. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));

					ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionComercial.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONREGISTROLISTAPROTOCOLAR));
				}
			}
			else
			{
				ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesErrorComercial.ToString(),Mensajes.CODIGOMENSAJELISTAPROTOCOLARDATOSINCORRECTOSEXISTENCIA)+existencia.ToString());
			}
		}

		public void Modificar()
		{
			int Cantidad = 0;
			ListaProtocolarBE oListaProtocolarBE = new ListaProtocolarBE();
			oListaProtocolarBE.IdListaProtocolar = Convert.ToInt32(Page.Request.QueryString[KEYQID]);
			oListaProtocolarBE.IdPresenteRelacionPublica = Convert.ToInt32(this.ddlbPresente.SelectedValue);

			oListaProtocolarBE.CantidadAtendida = Convert.ToInt32(this.nbCantidad.Text);
			if(oListaProtocolarBE.IdPresenteRelacionPublica == Convert.ToInt32(ViewState[KEYQIDPRESENTE]))
			{
				Cantidad = Convert.ToInt32(this.nbCantidad.Text)-Convert.ToInt32(ViewState[KEYQCANTIDAD]);
			}
			else
			{
				Cantidad = Convert.ToInt32(this.nbCantidad.Text);
			}

			if(this.txtDirectiva.Text.Trim()!=String.Empty)
			{
				oListaProtocolarBE.Directiva = this.txtDirectiva.Text;
			}
			if(this.ddlbTipoDocumento.SelectedValue != Constantes.VALORSELECCIONAR)
			{
				oListaProtocolarBE.IdTablaDocumento = Convert.ToInt32(Enumerados.TablasTabla.SecretariaTipoDocumento);
				oListaProtocolarBE.IdDocumento = Convert.ToInt32(this.ddlbTipoDocumento.SelectedValue);
			}
			oListaProtocolarBE.IdCodigo = Convert.ToInt32(this.hIdCodigo.Value);
			oListaProtocolarBE.IdOrigen = Convert.ToInt32(this.hIdOrigen.Value);
			oListaProtocolarBE.IdTablaOrigen = Convert.ToInt32(this.hIdTablaOrigen.Value);
			oListaProtocolarBE.IdCentroOperativo = Convert.ToInt32(this.ddlbCentroOperativo.SelectedValue);
			oListaProtocolarBE.IdUsuarioActualizacion = CNetAccessControl.GetIdUser();
			oListaProtocolarBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.EstadosListaProtocolarPersonas);
			oListaProtocolarBE.IdEstado = Convert.ToInt32(Enumerados.EstadosListaProtocolarPersonas.Modificado);
			if(this.txtDescripcion.Text.Trim()!=String.Empty)
			{
				oListaProtocolarBE.Descripcion = this.txtDescripcion.Text;
			}
			if(this.txtObservaciones.Text.Trim()!=String.Empty)
			{
				oListaProtocolarBE.Observaciones = this.txtObservaciones.Text;
			}

			CPresentes oCPresentes = new CPresentes();

			int existencia = oCPresentes.ObtenerExistenciaPresente(oListaProtocolarBE.IdPresenteRelacionPublica);

			if(existencia >= Cantidad)
			{
				CPresentesOtorgadosPorTipoPersona oCPresentesOtorgadosPorTipoPersona = new CPresentesOtorgadosPorTipoPersona();
				int retorno = oCPresentesOtorgadosPorTipoPersona.ModificarPresentesOtorgadosPersona(oListaProtocolarBE,oListaProtocolarBE.IdPresenteRelacionPublica,Cantidad);
				if(retorno>0)
				{
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se modificó el Presente Otorgado Nro. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));

					ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionComercial.ToString(),Mensajes.CODIGOMENSAJEMODIFICACIONREGISTROLISTAPROTOCOLAR));
				}
			}
			else
			{
				ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesErrorComercial.ToString(),Mensajes.CODIGOMENSAJELISTAPROTOCOLARDATOSINCORRECTOSEXISTENCIA)+existencia.ToString());
			}
		}

		public void Eliminar()
		{
			// TODO:  Add DetallePresentesOtorgadosPorTipoPersona.Eliminar implementation
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
			this.TdCeldaCancelar.Visible = false;
			lblTitulo.Text = TITULOMODONUEVO;
			this.LlenarCombos();
		}

		public void CargarModoModificar()
		{
			this.TdCeldaCancelar.Visible = false;
			lblTitulo.Text = TITULOMODOMODIFICAR;
			this.LlenarCombos();
			
			CMantenimientos	oCMantenimientos = new CMantenimientos();
			ListaProtocolarBE oListaProtocolarBE = (ListaProtocolarBE)oCMantenimientos.ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYQID]),Enumerados.ClasesNTAD.PresentesOtorgadosTipoPersonaNTAD.ToString());
			
			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionComercial",this.ToString(),"Se consultó el Detalle del Presente Otorgado a Personas Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

			if(oListaProtocolarBE!=null)
			{
				this.hIdCodigo.Value = oListaProtocolarBE.IdCodigo.ToString();
				this.hIdOrigen.Value = oListaProtocolarBE.IdOrigen.ToString();
				this.hIdTablaOrigen.Value = oListaProtocolarBE.IdTablaOrigen.ToString();

				CEntidades oCEntidades = new CEntidades();
				string NombreEntidad = oCEntidades.ObtenerNombreEntidad(Convert.ToInt32(this.hIdCodigo.Value),Convert.ToInt32(this.hIdOrigen.Value),Convert.ToInt32(this.hIdTablaOrigen.Value)).Replace(Constantes.SIGNOMENOR,Constantes.SIGNOABREPARANTESIS).Replace(Constantes.SIGNOMAYOR,Constantes.SIGNOCIERRAPARANTESIS);
				this.txtEntidad.Text = NombreEntidad;

				this.ddlbCentroOperativo.Items.FindByValue(oListaProtocolarBE.IdCentroOperativo.ToString()).Selected = true;
				if(!oListaProtocolarBE.IdDocumento.IsNull)
				{
					this.ddlbTipoDocumento.Items.FindByValue(oListaProtocolarBE.IdDocumento.ToString()).Selected = true;
					this.txtDirectiva.Text = oListaProtocolarBE.Directiva.ToString();
				}
				this.ddlbPresente.Items.FindByValue(oListaProtocolarBE.IdPresenteRelacionPublica.ToString()).Selected = true;
				this.nbCantidad.Text = oListaProtocolarBE.CantidadAtendida.ToString();
				
				if(!oListaProtocolarBE.Descripcion.IsNull)
				{
					this.txtDescripcion.Text = oListaProtocolarBE.Descripcion.ToString();
				}
				if(!oListaProtocolarBE.Observaciones.IsNull)
				{
					this.txtObservaciones.Text = oListaProtocolarBE.Observaciones.ToString();
				}
				ViewState[KEYQIDPRESENTE] = oListaProtocolarBE.IdPresenteRelacionPublica;
				ViewState[KEYQCANTIDAD] = oListaProtocolarBE.CantidadAtendida;
			}
		}

		public void CargarModoConsulta()
		{
			this.ibtnCancelar.Visible = false;
			lblTitulo.Text = TITULOMODOCONSULTA;
			this.LlenarCombos();
			
			CMantenimientos	oCMantenimientos = new CMantenimientos();
			ListaProtocolarBE oListaProtocolarBE = (ListaProtocolarBE)oCMantenimientos.ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYQID]),Enumerados.ClasesNTAD.PresentesOtorgadosTipoPersonaNTAD.ToString());
			
			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionComercial",this.ToString(),"Se consultó el Detalle del Presente Otorgado a Personas Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

			if(oListaProtocolarBE!=null)
			{
				this.hIdCodigo.Value = oListaProtocolarBE.IdCodigo.ToString();
				this.hIdOrigen.Value = oListaProtocolarBE.IdOrigen.ToString();
				this.hIdTablaOrigen.Value = oListaProtocolarBE.IdTablaOrigen.ToString();

				CEntidades oCEntidades = new CEntidades();
				string NombreEntidad = oCEntidades.ObtenerNombreEntidad(Convert.ToInt32(this.hIdCodigo.Value),Convert.ToInt32(this.hIdOrigen.Value),Convert.ToInt32(this.hIdTablaOrigen.Value)).Replace(Constantes.SIGNOMENOR,Constantes.SIGNOABREPARANTESIS).Replace(Constantes.SIGNOMAYOR,Constantes.SIGNOCIERRAPARANTESIS);
				this.txtEntidad.Text = NombreEntidad;

				this.ddlbCentroOperativo.Items.FindByValue(oListaProtocolarBE.IdCentroOperativo.ToString()).Selected = true;
				if(!oListaProtocolarBE.IdDocumento.IsNull)
				{
					this.ddlbTipoDocumento.Items.FindByValue(oListaProtocolarBE.IdDocumento.ToString()).Selected = true;
					this.txtDirectiva.Text = oListaProtocolarBE.Directiva.ToString();
				}
				this.ddlbPresente.Items.FindByValue(oListaProtocolarBE.IdPresenteRelacionPublica.ToString()).Selected = true;
				this.nbCantidad.Text = oListaProtocolarBE.CantidadAtendida.ToString();
				this.nbCantidad.Enabled = false;
				
				if(!oListaProtocolarBE.Descripcion.IsNull)
				{
					this.txtDescripcion.Text = oListaProtocolarBE.Descripcion.ToString();
				}
				if(!oListaProtocolarBE.Observaciones.IsNull)
				{
					this.txtObservaciones.Text = oListaProtocolarBE.Observaciones.ToString();
				}
				ViewState[KEYQIDPRESENTE] = oListaProtocolarBE.IdPresenteRelacionPublica;
				ViewState[KEYQCANTIDAD] = oListaProtocolarBE.CantidadAtendida;
			}
			Helper.BloquearControles(this);
		}

		public bool ValidarCampos()
		{
			if(this.ValidarCamposRequeridos())
			{
				return this.ValidarExpresionesRegulares();
			}
			else
			{
				return false;
			}
		}

		public bool ValidarCamposRequeridos()
		{
			if(this.txtEntidad.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJELISTAPROTOCOLARCAMPOREQUERIDOCLIENTEPERSONAL));
				return false;
			}
			if(this.ddlbCentroOperativo.SelectedItem.Text == Constantes.TEXTOSSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJELISTAPROTOCOLARCAMPOREQUERIDOCENTROOPERATIVO));
				return false;
			}
			if(this.ddlbPresente.SelectedItem.Text == Constantes.TEXTOSSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJELISTAPROTOCOLARCAMPOREQUERIDOPRESENTE));
				return false;
			}
			if(this.nbCantidad.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJELISTAPROTOCOLARCAMPOREQUERIDOCANTIDAD));
				return false;
			}
			return true;
		}

		public bool ValidarExpresionesRegulares()
		{
			if(!ExpresionesRegulares.ValidarExpresionRegularEnterosPositivos(Server.HtmlEncode(this.nbCantidad.Text)))
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesErrorComercialUsuario(Mensajes.CODIGOMENSAJELISTAPROTOCOLARDATOSINCORRECTOSCANTIDAD));
				return false;
			}
			return true;
		}

		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add DetallePresentesOtorgadosPorTipoPersona.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetallePresentesOtorgadosPorTipoPersona.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetallePresentesOtorgadosPorTipoPersona.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			lItem = new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,Utilitario.Constantes.VALORSELECCIONAR);
			this.llenarPresente();
			this.llenarCentrosOperativos();
			this.llenarTipoDocumento();
			this.ddlbPresente.Items.Insert(0,lItem);
			this.ddlbCentroOperativo.Items.Insert(0,lItem);
			this.ddlbTipoDocumento.Items.Insert(0,lItem);
		}

		public void LlenarDatos()
		{
			// TODO:  Add DetallePresentesOtorgadosPorTipoPersona.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			this.ibtnBuscarEntidad.Attributes.Add(Constantes.EVENTOCLICK,Helper.PopupBusqueda(URLBUSQUEDAENTIDAD + Utilitario.Constantes.KEYMODOPAGINA +  Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.C.ToString(),750,500,true));

			this.rfvNombres.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJELISTAPROTOCOLARCAMPOREQUERIDOCLIENTEPERSONAL);
			this.rfvNombres.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJELISTAPROTOCOLARCAMPOREQUERIDOCLIENTEPERSONAL);

			this.rfvCentroOperativo.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJELISTAPROTOCOLARCAMPOREQUERIDOCENTROOPERATIVO);
			this.rfvCentroOperativo.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJELISTAPROTOCOLARCAMPOREQUERIDOCENTROOPERATIVO);
			this.rfvCentroOperativo.InitialValue = Constantes.VALORSELECCIONAR;

			this.rfvPresente.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJELISTAPROTOCOLARCAMPOREQUERIDOPRESENTE);
			this.rfvPresente.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJELISTAPROTOCOLARCAMPOREQUERIDOPRESENTE);
			this.rfvPresente.InitialValue = Constantes.VALORSELECCIONAR;

			this.rfvCantidad.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJELISTAPROTOCOLARCAMPOREQUERIDOCANTIDAD);
			this.rfvCantidad.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJELISTAPROTOCOLARCAMPOREQUERIDOCANTIDAD);
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetallePresentesOtorgadosPorTipoPersona.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetallePresentesOtorgadosPorTipoPersona.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetallePresentesOtorgadosPorTipoPersona.Exportar implementation
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
			// TODO:  Add DetallePresentesOtorgadosPorTipoPersona.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					
					this.LlenarJScript();

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

		private void llenarPresente()
		{
			CPresentes oCPresente = new CPresentes();
			ddlbPresente.DataSource = oCPresente.ListarTodosCombo();
			ddlbPresente.DataValueField=Enumerados.ColumnasPresentes.IdPresenteRelacionPublica.ToString();
			ddlbPresente.DataTextField=Enumerados.ColumnasPresentes.NombreArticulo.ToString();
			ddlbPresente.DataBind();
		}

		private void llenarCentrosOperativos()
		{
			CCentroOperativo oCCentroOperativo =  new CCentroOperativo();
			ddlbCentroOperativo.DataSource = oCCentroOperativo.ListarTodosCombo();
			ddlbCentroOperativo.DataValueField=Enumerados.ColumnasCentroOperativo.IdCentroOperativo.ToString();
			ddlbCentroOperativo.DataTextField=Enumerados.ColumnasCentroOperativo.Nombre.ToString();
			ddlbCentroOperativo.DataBind();
			//ddlbCentroOperativo.Items.RemoveAt(0);
		}

		private void llenarTipoDocumento()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			ddlbTipoDocumento.DataSource = oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Enumerados.TablasTabla.SecretariaTipoDocumento));
			ddlbTipoDocumento.DataValueField =Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbTipoDocumento.DataTextField =Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbTipoDocumento.DataBind();
		}

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
				SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
				Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
			}
		}
	}
}