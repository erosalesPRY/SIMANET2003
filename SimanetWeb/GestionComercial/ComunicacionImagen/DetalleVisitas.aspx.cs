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
	/// Summary description for DetalleVisitas.
	/// </summary>
	public class DetalleVisitas: System.Web.UI.Page, IPaginaMantenimento, IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary vSum;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.Label lblDescripcion;
		protected System.Web.UI.WebControls.Label lblObservaciones;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.TextBox txtObservaciones;
		protected System.Web.UI.WebControls.Label lblNombres;
		protected System.Web.UI.WebControls.TextBox txtNombres;
		protected System.Web.UI.WebControls.Label lblTipoVisita;
		protected System.Web.UI.WebControls.DropDownList ddlbTipoVisita;
		protected System.Web.UI.WebControls.Label lblCargo;
		protected System.Web.UI.WebControls.TextBox txtCargo;
		protected System.Web.UI.WebControls.Label lblOnomastico;
		protected eWorld.UI.CalendarPopup calFechaDocumento;
		protected System.Web.UI.WebControls.Label lblNacionalidad;
		protected System.Web.UI.WebControls.DropDownList ddlbNacionalidad;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvNombres;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvNacionalidad;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvTipoVisita;
		protected System.Web.UI.WebControls.CheckBox chkOnomastico;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion Controles
		
		#region Constantes
		
		//Titulos 
		const string TITULOMODONUEVO = "NUEVA VISITA";
		const string TITULOMODOMODIFICAR = "ACTUALIZACION DE VISITA";

		//Key Session y QueryString
		const string KEYQID = "Id";
	
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
			this.chkOnomastico.CheckedChanged += new System.EventHandler(this.chkOnomastico_CheckedChanged);
			this.ibtnAceptar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAceptar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			VisitaBE oVisitaBE = new VisitaBE();
			oVisitaBE.Nombres = this.txtNombres.Text;
			oVisitaBE.IdTablaTipoVisita = Convert.ToInt32(Enumerados.TablasTabla.TipoVisita);
			oVisitaBE.IdTipoVisita = Convert.ToInt32(this.ddlbTipoVisita.SelectedValue);
			if(this.txtCargo.Text.Trim()!=String.Empty)
			{
				oVisitaBE.Cargo = this.txtCargo.Text;
			}
			if(this.chkOnomastico.Checked == true)
			{
				oVisitaBE.Onomastico = this.calFechaDocumento.SelectedDate;
			}
			oVisitaBE.IdUbigeo = Convert.ToInt32(this.ddlbNacionalidad.SelectedValue);
			oVisitaBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();
			oVisitaBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.EstadosVisita);
			oVisitaBE.IdEstado = Convert.ToInt32(Enumerados.EstadosVisita.Activo);
			if(this.txtDescripcion.Text.Trim()!=String.Empty)
			{
				oVisitaBE.Descripcion = this.txtDescripcion.Text;
			}
			if(this.txtObservaciones.Text.Trim()!=String.Empty)
			{
				oVisitaBE.Observaciones = this.txtObservaciones.Text;
			}

			CMantenimientos oCMantenimientos = new CMantenimientos();
			int retorno = oCMantenimientos.Insertar(oVisitaBE);

			if(retorno>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se registró la Visita Nro. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));

				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionComercial.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONREGISTROVISITA));
			}
		}

		public void Modificar()
		{
			VisitaBE oVisitaBE = new VisitaBE();
			oVisitaBE.IdVisita = Convert.ToInt32(Page.Request.QueryString[KEYQID]);
			oVisitaBE.Nombres = this.txtNombres.Text;
			oVisitaBE.IdTablaTipoVisita = Convert.ToInt32(Enumerados.TablasTabla.TipoVisita);
			oVisitaBE.IdTipoVisita = Convert.ToInt32(this.ddlbTipoVisita.SelectedValue);
			if(this.txtCargo.Text.Trim()!=String.Empty)
			{
				oVisitaBE.Cargo = this.txtCargo.Text;
			}
			if(this.chkOnomastico.Checked == true)
			{
				oVisitaBE.Onomastico = this.calFechaDocumento.SelectedDate;
			}
			oVisitaBE.IdUbigeo = Convert.ToInt32(this.ddlbNacionalidad.SelectedValue);
			oVisitaBE.IdUsuarioActualizacion = CNetAccessControl.GetIdUser();
			oVisitaBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.EstadosVisita);
			oVisitaBE.IdEstado = Convert.ToInt32(Enumerados.EstadosVisita.Modificado);
			if(this.txtDescripcion.Text.Trim()!=String.Empty)
			{
				oVisitaBE.Descripcion = this.txtDescripcion.Text;
			}
			if(this.txtObservaciones.Text.Trim()!=String.Empty)
			{
				oVisitaBE.Observaciones = this.txtObservaciones.Text;
			}
			
			CMantenimientos oCMantenimientos = new CMantenimientos();
			int retorno = oCMantenimientos.Modificar(oVisitaBE);

			if(retorno>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se modificó la Visita Nro. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));

				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionComercial.ToString(),Mensajes.CODIGOMENSAJEMODIFICACIONREGISTROVISITA));
			}
		}

		public void Eliminar()
		{
			// TODO:  Add DetalleVisitas.Eliminar implementation
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
			VisitaBE oVisitaBE = (VisitaBE)oCMantenimientos.ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYQID]),Enumerados.ClasesNTAD.VisitaNTAD.ToString());
			
			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionComercial",this.ToString(),"Se consultó el Detalle de la Visita Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

			if(oVisitaBE!=null)
			{
				this.txtNombres.Text = oVisitaBE.Nombres;
				this.ddlbTipoVisita.Items.FindByValue(oVisitaBE.IdTipoVisita.ToString()).Selected = true;
				if(!oVisitaBE.Cargo.IsNull)
				{
					this.txtCargo.Text = oVisitaBE.Cargo.ToString();
				}
				if(!oVisitaBE.Onomastico.IsNull)
				{
					this.calFechaDocumento.SelectedDate = Convert.ToDateTime(oVisitaBE.Onomastico);
				}
				else
				{
					this.chkOnomastico.Checked = false;
				}
				this.ddlbNacionalidad.Items.FindByValue(oVisitaBE.IdUbigeo.ToString()).Selected = true;
				if(!oVisitaBE.Descripcion.IsNull)
				{
					this.txtDescripcion.Text = oVisitaBE.Descripcion.ToString();
				}
				if(!oVisitaBE.Observaciones.IsNull)
				{
					this.txtObservaciones.Text = oVisitaBE.Observaciones.ToString();
				}
			}
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add DetalleVisitas.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			return this.ValidarCamposRequeridos();
		}

		public bool ValidarCamposRequeridos()
		{
			if(this.txtNombres.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEVISITACAMPOREQUERIDONOMBRE));
				return false;
			}
			if(this.ddlbTipoVisita.SelectedItem.Text == Constantes.TEXTOSSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEVISITACAMPOREQUERIDOTIPOVISITA));
				return false;
			}
			if(this.ddlbNacionalidad.SelectedItem.Text == Constantes.TEXTOSSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEVISITACAMPOREQUERIDONACIONALIDAD));
				return false;
			}
			return true;
		}

		public bool ValidarExpresionesRegulares()
		{
			return false;
		}

		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add DetalleVisitas.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetalleVisitas.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetalleVisitas.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			lItem = new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,Utilitario.Constantes.VALORSELECCIONAR);
			this.llenarNacionalidades();
			this.llenarTiposVisita();
			this.ddlbNacionalidad.Items.Insert(Constantes.POSICIONCONTADOR,lItem);
			this.ddlbTipoVisita.Items.Insert(Constantes.POSICIONCONTADOR,lItem);

		}

		public void LlenarDatos()
		{
			// TODO:  Add DetalleVisitas.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			this.rfvNombres.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEVISITACAMPOREQUERIDONOMBRE);
			this.rfvNombres.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEVISITACAMPOREQUERIDONOMBRE);

			this.rfvTipoVisita.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEVISITACAMPOREQUERIDOTIPOVISITA);
			this.rfvTipoVisita.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEVISITACAMPOREQUERIDOTIPOVISITA);
			this.rfvTipoVisita.InitialValue = Constantes.VALORSELECCIONAR;

			this.rfvNacionalidad.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEVISITACAMPOREQUERIDONACIONALIDAD);
			this.rfvNacionalidad.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEVISITACAMPOREQUERIDONACIONALIDAD);
			this.rfvNacionalidad.InitialValue = Constantes.VALORSELECCIONAR;
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetalleVisitas.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetalleVisitas.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetalleVisitas.Exportar implementation
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

		private void llenarTiposVisita()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			ddlbTipoVisita.DataSource = oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Enumerados.TablasTabla.TipoVisita));
			ddlbTipoVisita.DataValueField =Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbTipoVisita.DataTextField =Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbTipoVisita.DataBind();
		}

		private void llenarNacionalidades()
		{
			CMantenimientos oCMantenimientos = new CMantenimientos();
			ddlbNacionalidad.DataSource = oCMantenimientos.ListarTodosCombo(Enumerados.ClasesNTAD.UbigeoNTAD.ToString());
			ddlbNacionalidad.DataValueField=Enumerados.ColumnasUbigeo.IdUbigeo.ToString();
			ddlbNacionalidad.DataTextField=Enumerados.ColumnasUbigeo.NombreProvincia.ToString();
			ddlbNacionalidad.DataBind();
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

		private void chkOnomastico_CheckedChanged(object sender, System.EventArgs e)
		{
			if(this.chkOnomastico.Checked == true)
			{
				this.calFechaDocumento.Enabled = true;
			}
			else
			{
				this.calFechaDocumento.Enabled = false;
			}
		}
	}
}