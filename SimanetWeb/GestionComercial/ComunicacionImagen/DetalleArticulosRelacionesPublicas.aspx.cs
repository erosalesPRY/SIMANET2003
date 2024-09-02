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
using SIMA.EntidadesNegocio.GestionComercial;
using NetAccessControl;

namespace SIMA.SimaNetWeb.GestionComercial.ComunicacionImagen
{
	/// <summary>
	/// Summary description for DetalleArticulosRelacionesPublicas.
	/// </summary>
	public class DetalleArticulosRelacionesPublicas: System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		#region Controles

		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary vSum;
		protected eWorld.UI.NumericBox txtCantidadEgreso;
		protected System.Web.UI.WebControls.Label lblCantidadEgreso;
		protected eWorld.UI.NumericBox txtCantidadIngreso;
		protected System.Web.UI.WebControls.Label lblCantidadIngreso;
		protected eWorld.UI.NumericBox txtCantidadMinima;
		protected System.Web.UI.WebControls.Label lblCantidadMinima;
		protected eWorld.UI.NumericBox txtCantidadMaxima;
		protected System.Web.UI.WebControls.Label lblCantidadMaxima;
		protected System.Web.UI.WebControls.DropDownList ddlbMoneda;
		protected System.Web.UI.WebControls.Label lblMoneda;
		protected eWorld.UI.NumericBox txtCosto;
		protected System.Web.UI.WebControls.Label lblCosto;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvDescripcion;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.Label lblDescripcion;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvArticulo;
		protected System.Web.UI.WebControls.TextBox txtArticulo;
		protected System.Web.UI.WebControls.Label lblArticulo;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvCosto;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvMoneda;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvCantidadMaxima;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvCantidadMinima;
		protected System.Web.UI.WebControls.DomValidators.CompareDomValidator cvCantidadMaximaMinima;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvCantidadIngreso;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvCantidadEgreso;
		protected System.Web.UI.WebControls.DomValidators.CompareDomValidator cvCantidadIngresoEgreso;
		#endregion Controles
			
		#region Constantes
		
		//Titulos 
		const string TITULOMODONUEVO = "NUEVO PRESENTE";
		const string TITULOMODOMODIFICAR = "PRESENTE";
		protected System.Web.UI.HtmlControls.HtmlImage ibtnCancelar;

		//Key Session y QueryString
		const string KEYQID = "Id";
	
		//Paginas
		//const string URLPRINCIPAL = "AdministracionArticulosRelacionesPublicas.aspx";
		
		#endregion Constantes
				
		/// <summary>
		/// Llena el combo de Areas
		/// </summary>
		private void llenarMonedas()
		{
			CTablaTablas oCTablaTablas =  new CTablaTablas();
			ddlbMoneda.DataSource = oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Enumerados.TablasTabla.Moneda));
			ddlbMoneda.DataValueField=Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbMoneda.DataTextField=Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbMoneda.DataBind();
			ddlbMoneda.Items.Insert(0,lItem);
		}

		ListItem lItem;

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
			this.ibtnAceptar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAceptar_Click);
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

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
		{
		}

		public void LlenarCombos()
		{
			lItem = new ListItem(Constantes.TEXTOSSELECCIONAR,Constantes.VALORSELECCIONAR);
			this.llenarMonedas();			
		}

		public void LlenarDatos()
		{
			
		}

		public void LlenarJScript()
		{
			rfvArticulo.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEPRESENTECAMPOREQUERIDOARTICULO);
			rfvArticulo.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEPRESENTECAMPOREQUERIDOARTICULO);

			rfvDescripcion.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEPRESENTECAMPOREQUERIDODESCRIPCION);
			rfvDescripcion.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEPRESENTECAMPOREQUERIDODESCRIPCION);
		
			rfvCosto.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEPRESENTECAMPOREQUERIDOCOSTO);
			rfvCosto.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEPRESENTECAMPOREQUERIDOCOSTO);

			rfvMoneda.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEPRESENTECAMPOREQUERIDOMONEDA);
			rfvMoneda.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEPRESENTECAMPOREQUERIDOMONEDA);
			rfvMoneda.InitialValue = Constantes.VALORSELECCIONAR;

			rfvCantidadMaxima.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEPRESENTECAMPOREQUERIDOCANTIDADMAXIMA);
			rfvCantidadMaxima.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEPRESENTECAMPOREQUERIDOCANTIDADMAXIMA);

			rfvCantidadMinima.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEPRESENTECAMPOREQUERIDOCANTIDADMINIMA);
			rfvCantidadMinima.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEPRESENTECAMPOREQUERIDOCANTIDADMINIMA);

			rfvCantidadIngreso.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEPRESENTECAMPOREQUERIDOCANTIDADINGRESO);
			rfvCantidadIngreso.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEPRESENTECAMPOREQUERIDOCANTIDADINGRESO);

			rfvCantidadEgreso.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEPRESENTECAMPOREQUERIDOCANTIDADEGRESO);
			rfvCantidadEgreso.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEPRESENTECAMPOREQUERIDOCANTIDADEGRESO);

			cvCantidadMaximaMinima.ErrorMessage = Helper.ObtenerMensajesErrorComercialUsuario(Mensajes.CODIGOMENSAJEPRESENTEDATOSINCORRECTOSCANTIDADESMAXIMAMINIMA);
			cvCantidadMaximaMinima.ToolTip = Helper.ObtenerMensajesErrorComercialUsuario(Mensajes.CODIGOMENSAJEPRESENTEDATOSINCORRECTOSCANTIDADESMAXIMAMINIMA);

			cvCantidadIngresoEgreso.ErrorMessage = Helper.ObtenerMensajesErrorComercialUsuario(Mensajes.CODIGOMENSAJEPRESENTEDATOSINCORRECTOSCANTIDADESINGRESOEGRESO);
			cvCantidadIngresoEgreso.ToolTip = Helper.ObtenerMensajesErrorComercialUsuario(Mensajes.CODIGOMENSAJEPRESENTEDATOSINCORRECTOSCANTIDADESINGRESOEGRESO);
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultaDeCartasFianzas.RegistrandoJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultaDeCartasFianzas.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultaDeCartasFianzas.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add ConsultaDeCartasFianzas.ConfigurarAccesoControles implementation

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

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			PresenteRelacionPublicaBE oPresenteRelacionPublicaBE = new PresenteRelacionPublicaBE();
			oPresenteRelacionPublicaBE.CantidadIngreso = Convert.ToInt32(txtCantidadIngreso.Text);
			oPresenteRelacionPublicaBE.CantidadEgreso = Convert.ToInt32(txtCantidadEgreso.Text);
			if(txtCantidadMaxima.Text.Trim()!=String.Empty)
			{
				oPresenteRelacionPublicaBE.CantidadMaxima = Convert.ToInt32(txtCantidadMaxima.Text);
			}
			if(txtCantidadMinima.Text.Trim()!=String.Empty)
			{
				oPresenteRelacionPublicaBE.CantidadMinima = Convert.ToInt32(txtCantidadMinima.Text);
			}
			oPresenteRelacionPublicaBE.Costo = Convert.ToDouble(txtCosto.Text);
			oPresenteRelacionPublicaBE.NombreArticulo = txtArticulo.Text;
			oPresenteRelacionPublicaBE.IdTablaMoneda = Convert.ToInt32(Enumerados.TablasTabla.Moneda);
			oPresenteRelacionPublicaBE.IdMoneda = Convert.ToInt32(ddlbMoneda.SelectedValue);
			oPresenteRelacionPublicaBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();
			oPresenteRelacionPublicaBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.EstadosPresente);
			oPresenteRelacionPublicaBE.IdEstado = Convert.ToInt32(Enumerados.EstadosPresentes.Activo);
			if(txtDescripcion.Text.Trim()!=String.Empty)
			{
				oPresenteRelacionPublicaBE.Descripcion = txtDescripcion.Text;
			}

			CMantenimientos oCMantenimientos = new CMantenimientos();

			int retorno = oCMantenimientos.Insertar(oPresenteRelacionPublicaBE);

			if(retorno>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se registró el Presente Nro. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));
				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionSecretaria.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONREGISTROPRESENTE));
			}
		}

		public void Modificar()
		{
			PresenteRelacionPublicaBE oPresenteRelacionPublicaBE = new PresenteRelacionPublicaBE();
			oPresenteRelacionPublicaBE.IdPresenteRelacionPublica = Convert.ToInt32(Page.Request.QueryString[KEYQID]);
			oPresenteRelacionPublicaBE.CantidadIngreso = Convert.ToInt32(txtCantidadIngreso.Text);
			oPresenteRelacionPublicaBE.CantidadEgreso = Convert.ToInt32(txtCantidadEgreso.Text);
			if(txtCantidadMaxima.Text.Trim()!=String.Empty)
			{
				oPresenteRelacionPublicaBE.CantidadMaxima = Convert.ToInt32(txtCantidadMaxima.Text);
			}
			if(txtCantidadMinima.Text.Trim()!=String.Empty)
			{
				oPresenteRelacionPublicaBE.CantidadMinima = Convert.ToInt32(txtCantidadMinima.Text);
			}
			oPresenteRelacionPublicaBE.Costo = Convert.ToDouble(txtCosto.Text);
			oPresenteRelacionPublicaBE.NombreArticulo = txtArticulo.Text;
			oPresenteRelacionPublicaBE.IdTablaMoneda = Convert.ToInt32(Enumerados.TablasTabla.Moneda);
			oPresenteRelacionPublicaBE.IdMoneda = Convert.ToInt32(ddlbMoneda.SelectedValue);
			oPresenteRelacionPublicaBE.IdUsuarioActualizacion = CNetAccessControl.GetIdUser();
			oPresenteRelacionPublicaBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.EstadosPresente);
			oPresenteRelacionPublicaBE.IdEstado = Convert.ToInt32(Enumerados.EstadosPresentes.Modificado);
			if(txtDescripcion.Text.Trim()!=String.Empty)
			{
				oPresenteRelacionPublicaBE.Descripcion = txtDescripcion.Text;
			}

			CMantenimientos oCMantenimientos = new CMantenimientos();
			if(oCMantenimientos.Modificar(oPresenteRelacionPublicaBE)>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se modificó el Presente Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));
				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionComercial.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONMODIFICACIONPRESENTE));
			}
		}

		public void Eliminar()
		{
			// TODO:  Add DetalleCuentasBancaria.Eliminar implementation
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
			lblTitulo.Text = TITULOMODONUEVO;
			this.LlenarCombos();
		}

		public void CargarModoModificar()
		{			
			lblTitulo.Text = TITULOMODOMODIFICAR;
			this.LlenarCombos();
			
			CMantenimientos	oCMantenimientos = new CMantenimientos();
			PresenteRelacionPublicaBE oPresenteRelacionPublicaBE = (PresenteRelacionPublicaBE)oCMantenimientos.ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYQID]),Enumerados.ClasesNTAD.PresenteRelacionPublicaNTAD.ToString());
			
			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionComercial",this.ToString(),"Se consultó el Detalle del Articulo destinado a Relaciones Publicas Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

			if(oPresenteRelacionPublicaBE!=null)
			{
                txtArticulo.Text = oPresenteRelacionPublicaBE.NombreArticulo;
				if(!oPresenteRelacionPublicaBE.Descripcion.IsNull)
				{
					txtDescripcion.Text = oPresenteRelacionPublicaBE.Descripcion.Value;
				}
				txtCosto.Text = oPresenteRelacionPublicaBE.Costo.ToString();
				ddlbMoneda.Items.FindByValue(oPresenteRelacionPublicaBE.IdMoneda.ToString()).Selected = true;
				if(!oPresenteRelacionPublicaBE.CantidadMaxima.IsNull)
				{
					txtCantidadMaxima.Text = oPresenteRelacionPublicaBE.CantidadMaxima.Value.ToString();
				}
				if(!oPresenteRelacionPublicaBE.CantidadMinima.IsNull)
				{
					txtCantidadMinima.Text = oPresenteRelacionPublicaBE.CantidadMinima.Value.ToString();
				}
				txtCantidadIngreso.Text = oPresenteRelacionPublicaBE.CantidadIngreso.ToString();
				txtCantidadEgreso.Text = oPresenteRelacionPublicaBE.CantidadEgreso.ToString();
			}
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add DetalleCuentasBancaria.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			if(this.ValidarCamposRequeridos())
			{
				if(this.ValidarExpresionesRegulares())
				{
					return this.ValidarCantidadMayorCantidad();
				}
				else
				{
					return false;
				}
			}
			else
			{
				return false;
			}
		}

		public bool ValidarCamposRequeridos()
		{
			if(txtArticulo.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEPRESENTECAMPOREQUERIDOARTICULO));
				return false;
			}
			if(txtDescripcion.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEPRESENTECAMPOREQUERIDODESCRIPCION));
				return false;
			}
			if(txtCosto.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEPRESENTECAMPOREQUERIDOCOSTO));
				return false;
			}
			if(ddlbMoneda.SelectedItem.Text == Constantes.TEXTOSSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEPRESENTECAMPOREQUERIDOMONEDA));
				return false;
			}
			if(txtCantidadMaxima.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEPRESENTECAMPOREQUERIDOCANTIDADMAXIMA));
				return false;		
			}
			if(txtCantidadMinima.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEPRESENTECAMPOREQUERIDOCANTIDADMINIMA));
				return false;		
			}
			if(txtCantidadIngreso.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEPRESENTECAMPOREQUERIDOCANTIDADINGRESO));
				return false;		
			}
			if(txtCantidadEgreso.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEPRESENTECAMPOREQUERIDOCANTIDADEGRESO));
				return false;		
			}
			return true;
		}

		public bool ValidarExpresionesRegulares()
		{
			if(!ExpresionesRegulares.ValidarExpresionRegularNumericosPositivos(Server.HtmlEncode(txtCosto.Text)))
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesErrorComercialUsuario(Mensajes.CODIGOMENSAJEPRESENTEDATOSINCORRECTOSNUMEROSCOSTO));
				return false;
			}
			if(!ExpresionesRegulares.ValidarExpresionRegularEnterosPositivos(Server.HtmlEncode(txtCantidadMaxima.Text)))
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesErrorComercialUsuario(Mensajes.CODIGOMENSAJEPRESENTEDATOSINCORRECTOSNUMEROSCANTIDADMAXIMA));
				return false;
			}
			if(!ExpresionesRegulares.ValidarExpresionRegularEnterosPositivos(Server.HtmlEncode(txtCantidadMinima.Text)))
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesErrorComercialUsuario(Mensajes.CODIGOMENSAJEPRESENTEDATOSINCORRECTOSNUMEROSCANTIDADMINIMA));
				return false;
			}
			if(!ExpresionesRegulares.ValidarExpresionRegularEnterosPositivos(Server.HtmlEncode(txtCantidadIngreso.Text)))
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesErrorComercialUsuario(Mensajes.CODIGOMENSAJEPRESENTEDATOSINCORRECTOSNUMEROSCANTIDADINGRESO));
				return false;
			}
			if(!ExpresionesRegulares.ValidarExpresionRegularEnterosPositivos(Server.HtmlEncode(txtCantidadEgreso.Text)))
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesErrorComercialUsuario(Mensajes.CODIGOMENSAJEPRESENTEDATOSINCORRECTOSNUMEROSCANTIDADEGRESO));
				return false;
			}
			return true;
		}

		public bool ValidarCantidadMayorCantidad()
		{
			if(!Helper.ValidarCantidadMayorCantidad(Convert.ToInt32(txtCantidadMaxima.Text),Convert.ToInt32(txtCantidadMinima.Text)))
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesErrorComercialUsuario(Mensajes.CODIGOMENSAJEPRESENTEDATOSINCORRECTOSCANTIDADESMAXIMAMINIMA));
				return false;
			}
			if(!Helper.ValidarCantidadMayorCantidad(Convert.ToInt32(txtCantidadIngreso.Text),Convert.ToInt32(txtCantidadEgreso.Text)))
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesErrorComercialUsuario(Mensajes.CODIGOMENSAJEPRESENTEDATOSINCORRECTOSCANTIDADESINGRESOEGRESO));
				return false;
			}
			return true;
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