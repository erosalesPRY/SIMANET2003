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
using SIMA.EntidadesNegocio.Secretaria.Directorio;
using NetAccessControl;



namespace SIMA.SimaNetWeb.DirectorioEjecutivo.Directorio
{
	/// <summary>
	/// Summary description for RequerimientosAsignados.
	/// </summary>
	public class DetallePedidoSesionDirectorio: System.Web.UI.Page,IPaginaBase//,IPaginaMantenimento
	{
		#region Controles
		protected System.Web.UI.WebControls.DropDownList ddlbCentroOperativo;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.DropDownList ddlbSituacion;
		protected System.Web.UI.WebControls.Label lblSituacion;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblNroPedido;
		protected System.Web.UI.WebControls.TextBox txtNumeroPedido;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvNroPedido;
		protected System.Web.UI.WebControls.Label lblFecha;
		protected eWorld.UI.CalendarPopup CalFecha;
		protected System.Web.UI.WebControls.Label lblSolicitante;
		protected System.Web.UI.WebControls.TextBox txtSolicitante;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvSolicitante;
		protected System.Web.UI.WebControls.Label lblDetalle;
		protected System.Web.UI.WebControls.TextBox txtDetalle;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvDetalle;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary vSum;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion Controles

		#region Constantes
		
		//Titulos 
		const string TITULOMODONUEVO = "NUEVO PEDIDO DE SESION DE DIRECTORIO";
		const string TITULOMODOMODIFICAR = "PEDIDO DE SESION DE DIRECTORIO";

		//Key Session y QueryString
		const string KEYQID = "Id";		
		
		
		
	
		//Paginas
		const string URLPRINCIPAL = "AdministracionPedidoSesionDirectorio.aspx";
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox txtNroSesion;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.TextBox txtObservaciones;
		const string URLDIALOGO = "../../GestionComercial/ComunicacionImagen/Dialogo.aspx";

		#endregion Constantes
		
		
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

		private void llenarSituacion()
		{
			//ListItem lItem = new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,Utilitario.Constantes.VALORSELECCIONAR);
			CTablaTablas oCTablaTablas =  new CTablaTablas();
			ddlbSituacion.DataSource = oCTablaTablas.ListarTodosComboDirectorio(Convert.ToInt32(Enumerados.TablasTabla.SecretariaDirectorioTablaSituacionPedidos));
			ddlbSituacion.DataValueField=Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbSituacion.DataTextField=Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbSituacion.DataBind();
			//ddlbSituacion.Items.Insert(0,lItem);
		}

		public void LlenarCombos()
		{
			this.llenarSituacion();
			this.llenarCentroOperativo();
		}

		private void llenarCentroOperativo()
		{
			CCentroOperativo oCCentroOperativo = new CCentroOperativo();
			ddlbCentroOperativo.DataSource = oCCentroOperativo.ListarTodosCombo();
			ddlbCentroOperativo.DataValueField=Enumerados.ColumnasCentroOperativo.IdCentroOperativo.ToString();
			ddlbCentroOperativo.DataTextField=Enumerados.ColumnasCentroOperativo.Sigla1.ToString();
			ddlbCentroOperativo.DataBind();
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

		public void LlenarDatos()
		{
			

			
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultaDeCartasFianzas.LlenarJScript implementation
			rfvNroPedido.ErrorMessage = Helper.ObtenerMensajesConfirmacionDirectorioUsuario(Mensajes.CODIGOMENSAJEPEDIDOSESIONDIRECTORIOCAMPOREQUERIDONRO);
			rfvNroPedido.ToolTip = Helper.ObtenerMensajesConfirmacionDirectorioUsuario(Mensajes.CODIGOMENSAJEPEDIDOSESIONDIRECTORIOCAMPOREQUERIDONRO);//rfvNroPedido.ErrorMessage;
		
			rfvSolicitante.ErrorMessage = Helper.ObtenerMensajesConfirmacionDirectorioUsuario(Mensajes.CODIGOMENSAJEPEDIDOSESIONDIRECTORIOCAMPOREQUERIDOSOLICITANTE);
			rfvSolicitante.ToolTip = Helper.ObtenerMensajesConfirmacionDirectorioUsuario(Mensajes.CODIGOMENSAJEPEDIDOSESIONDIRECTORIOCAMPOREQUERIDOSOLICITANTE);//rfvSolicitante.ErrorMessage;

			rfvDetalle.ErrorMessage = Helper.ObtenerMensajesConfirmacionDirectorioUsuario(Mensajes.CODIGOMENSAJEPEDIDOSESIONDIRECTORIOCAMPOREQUERIDODETALLE);
			rfvDetalle.ToolTip = Helper.ObtenerMensajesConfirmacionDirectorioUsuario(Mensajes.CODIGOMENSAJEPEDIDOSESIONDIRECTORIOCAMPOREQUERIDODETALLE);//rfvDetalle.ErrorMessage;
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

			PedidoSesionDirectorioBE oPedidoSesionDirectorioBE = new PedidoSesionDirectorioBE();
			oPedidoSesionDirectorioBE.NroPedidoSesionDirectorio = txtNumeroPedido.Text;
			oPedidoSesionDirectorioBE.NroSesionDirectorio = txtNroSesion.Text;
			oPedidoSesionDirectorioBE.IdSesionDirectorio = Convert.ToInt32(Helper.RetornaSessionParaDirectorio());
			oPedidoSesionDirectorioBE.Detalle = txtDetalle.Text;
			oPedidoSesionDirectorioBE.Observacion = txtObservaciones.Text;
			oPedidoSesionDirectorioBE.Solicitante = txtSolicitante.Text;
			oPedidoSesionDirectorioBE.Fecha = CalFecha.SelectedDate;
			oPedidoSesionDirectorioBE.IdCentroOperativo = Convert.ToInt32(ddlbCentroOperativo.SelectedValue);
			oPedidoSesionDirectorioBE.IdTablaSituacion = Convert.ToInt32(Enumerados.TablasTabla.SecretariaDirectorioTablaSituacionPedidos);
			oPedidoSesionDirectorioBE.IdSituacion = Convert.ToInt32(ddlbSituacion.SelectedValue);
			oPedidoSesionDirectorioBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.SecretariaDirectorioEstadosPedidoSesionDirectorio);
			oPedidoSesionDirectorioBE.IdEstado = Convert.ToInt32(Enumerados.EstadosPedidoSesionDirectorio.Activo);
			oPedidoSesionDirectorioBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();

			
			CMantenimientos oCMantenimientos = new CMantenimientos();

			int retorno = oCMantenimientos.Insertar(oPedidoSesionDirectorioBE);

			if(retorno>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Secretaria - Directorio",this.ToString(),"Se registró el Pedido de Sesión de Directorio Nro. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));

				ltlMensaje.Text = Helper.MensajeRetornoAlert(
					Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionDirectorio.ToString()
					,Mensajes.CODIGOMENSAJECONFIRMACIONREGISTROPEDIDOSESIONDIRECTORIO));
			}
		}

		public void Modificar()
		{
			PedidoSesionDirectorioBE oPedidoSesionDirectorioBE = new PedidoSesionDirectorioBE();
			oPedidoSesionDirectorioBE.IdPedidoSesionDirectorio = Convert.ToInt32(Page.Request.QueryString[KEYQID]);
			oPedidoSesionDirectorioBE.IdSesionDirectorio = Convert.ToInt32(Helper.RetornaSessionParaDirectorio());
			oPedidoSesionDirectorioBE.NroPedidoSesionDirectorio = txtNumeroPedido.Text;
			oPedidoSesionDirectorioBE.NroSesionDirectorio = txtNroSesion.Text;
			oPedidoSesionDirectorioBE.Solicitante = txtSolicitante.Text;
			oPedidoSesionDirectorioBE.Fecha = CalFecha.SelectedDate;
			oPedidoSesionDirectorioBE.Detalle = txtDetalle.Text;
			oPedidoSesionDirectorioBE.Observacion = txtObservaciones.Text;
			oPedidoSesionDirectorioBE.IdCentroOperativo = Convert.ToInt32(ddlbCentroOperativo.SelectedValue);
			oPedidoSesionDirectorioBE.IdTablaSituacion = Convert.ToInt32(Enumerados.TablasTabla.SecretariaDirectorioTablaSituacionPedidos);
			oPedidoSesionDirectorioBE.IdSituacion = Convert.ToInt32(ddlbSituacion.SelectedValue);
			oPedidoSesionDirectorioBE.IdUsuarioActualizacion = CNetAccessControl.GetIdUser();

			
			CMantenimientos oCMantenimientos = new CMantenimientos();

			int retorno = oCMantenimientos.Modificar(oPedidoSesionDirectorioBE);

			if(retorno>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Secretaria - Directorio",this.ToString(),"Se modificó el Pedido de Sesión de Directorio Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

				ltlMensaje.Text = Helper.MensajeRetornoAlert(
					Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionDirectorio.ToString()
					,Mensajes.CODIGOMENSAJECONFIRMACIONMODIFICACIONPEDIDOSESIONDIRECTORIO));
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
			PedidoSesionDirectorioBE oPedidoSesionDirectorioBE = (PedidoSesionDirectorioBE)oCMantenimientos.ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYQID]),Enumerados.ClasesNTAD.PedidoSesionDirectorioNTAD.ToString());
			
			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Secretaria - Directorio",this.ToString(),"Se consultó el Detalle del Pedido de Directorio Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

			if(oPedidoSesionDirectorioBE!=null)
			{
				txtNumeroPedido.Text = oPedidoSesionDirectorioBE.NroPedidoSesionDirectorio;
				txtNroSesion.Text = oPedidoSesionDirectorioBE.NroSesionDirectorio;
				CalFecha.SelectedDate = oPedidoSesionDirectorioBE.Fecha;
				txtSolicitante.Text = oPedidoSesionDirectorioBE.Solicitante;
				txtDetalle.Text = oPedidoSesionDirectorioBE.Detalle;
				txtObservaciones.Text = oPedidoSesionDirectorioBE.Observacion;

				ListItem lItem = ddlbSituacion.Items.FindByValue(oPedidoSesionDirectorioBE.IdSituacion.ToString());
				if(lItem!=null){lItem.Selected = true;}

				lItem = ddlbCentroOperativo.Items.FindByValue(oPedidoSesionDirectorioBE.IdCentroOperativo.ToString());			
				if(lItem!=null){lItem.Selected = true;}				
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
				return this.ValidarExpresionesRegulares();
			}
			else
			{
				return false;
			}
		}

		

		public bool ValidarCamposRequeridos()
		{
			if(txtNumeroPedido.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionDirectorioUsuario(Mensajes.CODIGOMENSAJEPEDIDOSESIONDIRECTORIOCAMPOREQUERIDONRO));
				return false;		
			}

			if(txtNroSesion.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text = Utilitario.Helper.MensajeAlert("Ingrese Nro. de Sesión");
				return false;
			}
			
			if(txtSolicitante.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionDirectorioUsuario(Mensajes.CODIGOMENSAJEPEDIDOSESIONDIRECTORIOCAMPOREQUERIDOSOLICITANTE));
				return false;		
			}

			if(txtDetalle.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionDirectorioUsuario(Mensajes.CODIGOMENSAJEPEDIDOSESIONDIRECTORIOCAMPOREQUERIDODETALLE));
				return false;		
			}
			return true;
		}

		public bool ValidarExpresionesRegulares()
		{			
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

		/// <summary>
		/// Abre la pagina de Administracion De PlanAnual DeControl
		/// </summary>
		private void redireccionaPaginaPrincipal()
		{
			Page.Response.Redirect(URLPRINCIPAL);
		}

		private void ibtnCancelar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.redireccionaPaginaPrincipal();
		}
	}
}

