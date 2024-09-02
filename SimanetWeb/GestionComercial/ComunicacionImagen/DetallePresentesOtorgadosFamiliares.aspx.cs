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
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using SIMA.Controladoras.GestionComercial;
using SIMA.Controladoras.General;
using SIMA.EntidadesNegocio.GestionComercial;

namespace SIMA.SimaNetWeb.GestionComercial.ComunicacionImagen
{
	/// <summary>
	/// Summary description for DetallePresentesOtorgadosFamiliares.
	/// </summary>
	public class DetallePresentesOtorgadosFamiliares: System.Web.UI.Page, IPaginaMantenimento, IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblNombres;
		protected System.Web.UI.WebControls.TextBox txtNombres;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvNombres;
		protected System.Web.UI.WebControls.Label lblApellidoPaterno;
		protected System.Web.UI.WebControls.TextBox txtApellidoPaterno;
		protected System.Web.UI.WebControls.Label lblApellidoMaterno;
		protected System.Web.UI.WebControls.TextBox txtApellidoMaterno;
		protected System.Web.UI.WebControls.Label lblPresente;
		protected System.Web.UI.WebControls.DropDownList ddlbPresente;
		protected System.Web.UI.WebControls.Label lblCantidad;
		protected eWorld.UI.NumericBox nbCantidad;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary vSum;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvApellidoPaterno;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvPresente;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvCantidad;
		protected System.Web.UI.HtmlControls.HtmlTableCell TdCeldaCancelar;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnCancelar;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlbPresente;

		#endregion Controles
		
		#region Constantes
		
		//Titulos 
		const string TITULOMODONUEVO = "NUEVO PRESENTE OTORGADO A FAMILIAR";
		const string TITULOMODOMODIFICAR = "PRESENTE OTORGADO A FAMILIAR";

		//Key Session y QueryString
		const string KEYQID = "Id";
		const string KEYQIDTABLAORIGEN = "IdTablaOrigen";
		const string KEYQIDORIGEN = "IdOrigen";
		const string KEYQIDCODIGO = "IdCodigo";
		const string KEYQIDPRESENTE = "IdPresente";
		const string KEYQCANTIDAD = "Cantidad";

		//Paginas
		
		#endregion Constantes		
		
		#region Variables
		ListItem  lItem ;
		#endregion Variables		
		
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
			ListaProtocolarFamiliaresBE oListaProtocolarFamiliaresBE = new ListaProtocolarFamiliaresBE();
			oListaProtocolarFamiliaresBE.CantidadAtendida = Convert.ToInt32(this.nbCantidad.Text);
			if(this.txtApellidoMaterno.Text.Trim()!=String.Empty)
			{
				oListaProtocolarFamiliaresBE.ApellidoMaterno = this.txtApellidoMaterno.Text;
			}
			oListaProtocolarFamiliaresBE.ApellidoPaterno = this.txtApellidoPaterno.Text;
			oListaProtocolarFamiliaresBE.IdCodigo = Convert.ToInt32(Page.Request.QueryString[KEYQIDCODIGO]);
			oListaProtocolarFamiliaresBE.IdOrigen = Convert.ToInt32(Page.Request.QueryString[KEYQIDORIGEN]);
			oListaProtocolarFamiliaresBE.IdTablaOrigen = Convert.ToInt32(Page.Request.QueryString[KEYQIDTABLAORIGEN]);
			oListaProtocolarFamiliaresBE.Nombres = this.txtNombres.Text;
			oListaProtocolarFamiliaresBE.IdPresenteRelacionPublica = Convert.ToInt32(this.ddlbPresente.SelectedValue);
			oListaProtocolarFamiliaresBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();
			oListaProtocolarFamiliaresBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.EstadosListaProtocolarFamiliares);
			oListaProtocolarFamiliaresBE.IdEstado = Convert.ToInt32(Enumerados.EstadosListaProtocolarFamiliares.Activo);

			CPresentes oCPresentes = new CPresentes();
			int existencia = oCPresentes.ObtenerExistenciaPresente(oListaProtocolarFamiliaresBE.IdPresenteRelacionPublica);
			if(existencia >= oListaProtocolarFamiliaresBE.CantidadAtendida)
			{
				CPresentesOtorgadosPorFamiliar oCPresentesOtorgadosPorFamiliar = new CPresentesOtorgadosPorFamiliar();
				int retorno = oCPresentesOtorgadosPorFamiliar.RegistrarPresentesOtorgadosFamiliar(oListaProtocolarFamiliaresBE,oListaProtocolarFamiliaresBE.IdPresenteRelacionPublica,oListaProtocolarFamiliaresBE.CantidadAtendida);
				if(retorno>0)
				{
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se registró el Presente Otorgado a Familiares Nro. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));

					ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionComercial.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONREGISTROLISTAPROTOCOLARFAMILIARES));
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
			ListaProtocolarFamiliaresBE oListaProtocolarFamiliaresBE = new ListaProtocolarFamiliaresBE();
			oListaProtocolarFamiliaresBE.IdListaProtocolarFamiliares = Convert.ToInt32(Page.Request.QueryString[KEYQID]);
			if(this.txtApellidoMaterno.Text.Trim()!=String.Empty)
			{
				oListaProtocolarFamiliaresBE.ApellidoMaterno = this.txtApellidoMaterno.Text;
			}
			oListaProtocolarFamiliaresBE.ApellidoPaterno = this.txtApellidoPaterno.Text;
			oListaProtocolarFamiliaresBE.Nombres = this.txtNombres.Text;
			oListaProtocolarFamiliaresBE.IdPresenteRelacionPublica = Convert.ToInt32(this.ddlbPresente.SelectedValue);
			oListaProtocolarFamiliaresBE.CantidadAtendida = Convert.ToInt32(this.nbCantidad.Text);
			if(oListaProtocolarFamiliaresBE.IdPresenteRelacionPublica == Convert.ToInt32(ViewState[KEYQIDPRESENTE]))
			{
				Cantidad = Convert.ToInt32(this.nbCantidad.Text)-Convert.ToInt32(ViewState[KEYQCANTIDAD]);
			}
			else
			{
				Cantidad = Convert.ToInt32(this.nbCantidad.Text);
			}
			oListaProtocolarFamiliaresBE.IdUsuarioActualizacion = CNetAccessControl.GetIdUser();
			oListaProtocolarFamiliaresBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.EstadosListaProtocolarFamiliares);
			oListaProtocolarFamiliaresBE.IdEstado = Convert.ToInt32(Enumerados.EstadosListaProtocolarFamiliares.Modificado);

			ViewState[KEYQIDCODIGO] = Convert.ToInt32(Page.Request.QueryString[KEYQIDCODIGO]);
			ViewState[KEYQIDORIGEN] = Convert.ToInt32(Page.Request.QueryString[KEYQIDORIGEN]);
			ViewState[KEYQIDTABLAORIGEN] = Convert.ToInt32(Page.Request.QueryString[KEYQIDTABLAORIGEN]);

			CPresentes oCPresentes = new CPresentes();

			int existencia = oCPresentes.ObtenerExistenciaPresente(oListaProtocolarFamiliaresBE.IdPresenteRelacionPublica);

			if(existencia >= oListaProtocolarFamiliaresBE.CantidadAtendida)
			{
				CPresentesOtorgadosPorFamiliar oCPresentesOtorgadosPorFamiliar = new CPresentesOtorgadosPorFamiliar();
				int retorno = oCPresentesOtorgadosPorFamiliar.ModificarPresentesOtorgadosFamiliar(oListaProtocolarFamiliaresBE,oListaProtocolarFamiliaresBE.IdPresenteRelacionPublica,Cantidad);
				if(retorno>0)
				{
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se modificó el Presente Otorgado a Familiares Nro. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));

					ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionComercial.ToString(),Mensajes.CODIGOMENSAJEMODIFICACIONREGISTROLISTAPROTOCOLARFAMILIARES));
				}
			}
			else
			{
				ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesErrorComercial.ToString(),Mensajes.CODIGOMENSAJELISTAPROTOCOLARDATOSINCORRECTOSEXISTENCIA)+existencia.ToString());
			}
		}

		public void Eliminar()
		{
			// TODO:  Add DetallePresentesOtorgadosFamiliares.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			ViewState[KEYQIDCODIGO] = Convert.ToInt32(Page.Request.QueryString[KEYQIDCODIGO]);
			ViewState[KEYQIDORIGEN] = Convert.ToInt32(Page.Request.QueryString[KEYQIDORIGEN]);
			ViewState[KEYQIDTABLAORIGEN] = Convert.ToInt32(Page.Request.QueryString[KEYQIDTABLAORIGEN]);

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
			ListaProtocolarFamiliaresBE oListaProtocolarFamiliaresBE = (ListaProtocolarFamiliaresBE)oCMantenimientos.ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYQID]),Enumerados.ClasesNTAD.PresentesOtorgadosPorFamiliarNTAD.ToString());
			
			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionComercial",this.ToString(),"Se consultó el Detalle del Presente Otorgado a Familiares Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

			if(oListaProtocolarFamiliaresBE!=null)
			{
				this.txtNombres.Text = oListaProtocolarFamiliaresBE.Nombres;
				this.txtApellidoPaterno.Text = oListaProtocolarFamiliaresBE.ApellidoPaterno;
				if(!oListaProtocolarFamiliaresBE.ApellidoMaterno.IsNull)
				{
					this.txtApellidoMaterno.Text = oListaProtocolarFamiliaresBE.ApellidoMaterno.ToString();
				}
				this.ddlbPresente.Items.FindByValue(oListaProtocolarFamiliaresBE.IdPresenteRelacionPublica.ToString()).Selected = true;
				this.nbCantidad.Text = oListaProtocolarFamiliaresBE.CantidadAtendida.ToString();

				ViewState[KEYQIDPRESENTE] = oListaProtocolarFamiliaresBE.IdPresenteRelacionPublica;
				ViewState[KEYQCANTIDAD] = oListaProtocolarFamiliaresBE.CantidadAtendida;
			}
		}

		public void CargarModoConsulta()
		{
			this.ibtnCancelar.Visible = false;
			lblTitulo.Text = TITULOMODOMODIFICAR;
			this.LlenarCombos();
			
			CMantenimientos	oCMantenimientos = new CMantenimientos();
			ListaProtocolarFamiliaresBE oListaProtocolarFamiliaresBE = (ListaProtocolarFamiliaresBE)oCMantenimientos.ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYQID]),Enumerados.ClasesNTAD.PresentesOtorgadosPorFamiliarNTAD.ToString());
			
			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionComercial",this.ToString(),"Se consultó el Detalle del Presente Otorgado a Familiares Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

			if(oListaProtocolarFamiliaresBE!=null)
			{
				this.txtNombres.Text = oListaProtocolarFamiliaresBE.Nombres;
				this.txtApellidoPaterno.Text = oListaProtocolarFamiliaresBE.ApellidoPaterno;
				if(!oListaProtocolarFamiliaresBE.ApellidoMaterno.IsNull)
				{
					this.txtApellidoMaterno.Text = oListaProtocolarFamiliaresBE.ApellidoMaterno.ToString();
				}
				this.ddlbPresente.Items.FindByValue(oListaProtocolarFamiliaresBE.IdPresenteRelacionPublica.ToString()).Selected = true;
				this.nbCantidad.Text = oListaProtocolarFamiliaresBE.CantidadAtendida.ToString();
				this.nbCantidad.Enabled = false;

				ViewState[KEYQIDPRESENTE] = oListaProtocolarFamiliaresBE.IdPresenteRelacionPublica;
				ViewState[KEYQCANTIDAD] = oListaProtocolarFamiliaresBE.CantidadAtendida;
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
			if(this.txtNombres.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJELISTAPROTOCOLARFAMILIARESCAMPOREQUERIDONOMBRES));
				return false;
			}
			if(this.txtApellidoPaterno.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJELISTAPROTOCOLARFAMILIARESCAMPOREQUERIDOAPELLIDOPATERNO));
				return false;
			}
			if(this.ddlbPresente.SelectedItem.Text == Constantes.TEXTOSSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJELISTAPROTOCOLARFAMILIARESCAMPOREQUERIDOPRESENTE));
				return false;
			}
			if(this.nbCantidad.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJELISTAPROTOCOLARFAMILIARESCAMPOREQUERIDOCANTIDAD));
				return false;
			}
			return true;
		}

		public bool ValidarExpresionesRegulares()
		{
			if(!ExpresionesRegulares.ValidarExpresionRegularEnterosPositivos(Server.HtmlEncode(this.nbCantidad.Text)))
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesErrorComercialUsuario(Mensajes.CODIGOMENSAJELISTAPROTOCOLARFAMILIARESDATOSINCORRECTOSCANTIDAD));
				return false;
			}
			return true;
		}

		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add DetallePresentesOtorgadosFamiliares.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetallePresentesOtorgadosFamiliares.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetallePresentesOtorgadosFamiliares.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			lItem = new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,Utilitario.Constantes.VALORSELECCIONAR);
			this.llenarPresente();
			this.ddlbPresente.Items.Insert(0,lItem);
		}

		public void LlenarDatos()
		{
			// TODO:  Add DetallePresentesOtorgadosFamiliares.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			this.rfvNombres.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJELISTAPROTOCOLARFAMILIARESCAMPOREQUERIDONOMBRES);
			this.rfvNombres.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJELISTAPROTOCOLARFAMILIARESCAMPOREQUERIDONOMBRES);

			this.rfvApellidoPaterno.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJELISTAPROTOCOLARFAMILIARESCAMPOREQUERIDOAPELLIDOPATERNO);
			this.rfvApellidoPaterno.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJELISTAPROTOCOLARFAMILIARESCAMPOREQUERIDOAPELLIDOPATERNO);

			this.rfvPresente.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJELISTAPROTOCOLARFAMILIARESCAMPOREQUERIDOPRESENTE);
			this.rfvPresente.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJELISTAPROTOCOLARFAMILIARESCAMPOREQUERIDOPRESENTE);
			this.rfvPresente.InitialValue = Constantes.VALORSELECCIONAR;

			this.rfvCantidad.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJELISTAPROTOCOLARFAMILIARESCAMPOREQUERIDOCANTIDAD);
			this.rfvCantidad.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJELISTAPROTOCOLARFAMILIARESCAMPOREQUERIDOCANTIDAD);
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetallePresentesOtorgadosFamiliares.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetallePresentesOtorgadosFamiliares.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetallePresentesOtorgadosFamiliares.Exportar implementation
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
			return true;
		}

		#endregion

		private void llenarPresente()
		{
			CPresentes oCPresente = new CPresentes();
			ddlbPresente.DataSource = oCPresente.ListarTodosCombo();
			ddlbPresente.DataValueField=Enumerados.ColumnasPresentes.IdPresenteRelacionPublica.ToString();
			ddlbPresente.DataTextField=Enumerados.ColumnasPresentes.NombreArticulo.ToString();
			ddlbPresente.DataBind();
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