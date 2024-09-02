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
using SIMA.EntidadesNegocio.GestionControlInstitucional;
using NetAccessControl;

namespace SIMA.SimaNetWeb.GestionControlInstitucional
{
	/// <summary>
	/// Summary description for DetalleRetenciones.
	/// </summary>
	public class DetalleObservacionesControl : System.Web.UI.Page,IPaginaBase
	{
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary vSum;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblDatos;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvDescripcion;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvObservacion;
		protected System.Web.UI.WebControls.TextBox txtObservacion;
		protected System.Web.UI.WebControls.Label lblConcepto;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.TextBox txtAccion;
		protected System.Web.UI.WebControls.Image ibtnBuscarPersonal;
		protected System.Web.UI.WebControls.TextBox txtPersonal;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvResponsable;
		protected System.Web.UI.WebControls.DropDownList ddlbSituacion;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdPersonal;
		protected System.Web.UI.WebControls.Literal ltlMensaje;

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

		#region Constantes
		
		//Titulos 
		const string TITULOMODONUEVO = "NUEVA OBSERVACION";
		const string TITULOMODOMODIFICAR = "OBSERVACION";

		//Key Session y QueryString
		const string KEYQID = "Id";
		const string KEYIDCO = "CentroOperativo";

		const string URLBUSQUEDAPERSONAL = "../Legal/BusquedaPersonal.aspx";
	
		//Paginas

		//Otros

		#endregion Constantes

		/// <summary>
		/// </summary>
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();

					this.LlenarJScript();
					this.LlenarCombos();

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
			// TODO:  Add DetallePoderes.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetallePoderes.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetallePoderes.LlenarGrillaOrdenamientoPaginacion implementation
		}

		private void llenarTipoSituacion()
		{
			CTablaTablas oCTablasTablas = new CTablaTablas();
			ddlbSituacion.DataSource= oCTablasTablas.ListaTodosCombo(Convert.ToInt32(Enumerados.TablasTabla.TipoSituacion));
			ddlbSituacion.DataTextField= Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbSituacion.DataValueField=Enumerados.ColumnasTablaTablas.Codigo.ToString ();
			ddlbSituacion.DataBind();
		}

		public void LlenarCombos()
		{
			this.llenarTipoSituacion();
		}

		public void LlenarDatos()
		{
			// TODO:  Add DetallePoderes.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			rfvResponsable.ErrorMessage = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEOBSERVACIONCONTROLCAMPOREQUERIDORESPONSABLE);
			rfvResponsable.ToolTip = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEOBSERVACIONCONTROLCAMPOREQUERIDORESPONSABLE);

			/*rfvAccion.ErrorMessage = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEOBSERVACIONCONTROLCAMPOREQUERIDOACCION);
			rfvAccion.ToolTip = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEOBSERVACIONCONTROLCAMPOREQUERIDOACCION);*/

			rfvDescripcion.ErrorMessage = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEOBSERVACIONCONTROLCAMPOREQUERIDODESCRIPCION);
			rfvDescripcion.ToolTip = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEOBSERVACIONCONTROLCAMPOREQUERIDODESCRIPCION);

			rfvObservacion.ErrorMessage = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEOBSERVACIONCONTROLCAMPOREQUERIDOOBSERVACION);
			rfvObservacion.ToolTip = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEOBSERVACIONCONTROLCAMPOREQUERIDOOBSERVACION);

			ibtnAceptar.Attributes.Add(Constantes.EVENTOCLICK,Constantes.EVENTOVALIDATORONSUBMIT);			

			ibtnBuscarPersonal.Attributes.Add(Constantes.EVENTOCLICK,Helper.PopupBusqueda(URLBUSQUEDAPERSONAL,700,500,true));
			ibtnAceptar.Attributes.Add(Constantes.EVENTOCLICK,Constantes.EVENTOVALIDATORONSUBMIT);	
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetallePoderes.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetallePoderes.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetallePoderes.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add DetallePoderes.ConfigurarAccesoControles implementation
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
			// TODO:  Add DetallePoderes.ValidarFiltros implementation
			return true;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			ObservacionesControlBE oObservacionesControlBE = new ObservacionesControlBE();

			oObservacionesControlBE.IdDocumentoControl  = Convert.ToInt32(Page.Request.QueryString[KEYQID]);
			oObservacionesControlBE.IdPersonal = Convert.ToInt32(hIdPersonal.Value);
			oObservacionesControlBE.IdTablaSituacion = Convert.ToInt32(Enumerados.TablasTabla.TipoSituacion);
			oObservacionesControlBE.IdSituacion = Convert.ToInt32(ddlbSituacion.SelectedValue);
			oObservacionesControlBE.DescripcionObservacion = txtDescripcion.Text;
			oObservacionesControlBE.ObservacionControl = txtObservacion.Text;
			oObservacionesControlBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.ObservacionControl);
			oObservacionesControlBE.IdEstado = Convert.ToInt32(Enumerados.EstadosObservacionesControl.Activo);
			oObservacionesControlBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();

			if(txtAccion.Text.Trim()!=String.Empty)
			{
				oObservacionesControlBE.Accion = txtAccion.Text;	
			}

			CMantenimientos oCMantenimientos = new CMantenimientos();

			int retorno = oCMantenimientos.Insertar(oObservacionesControlBE);

			if(retorno>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"OCI",this.ToString(),"Se registró la Observacion Nro. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));

				ltlMensaje.Text = Helper.MensajeRetornoAlert(
					Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionOCI.ToString()
					,Mensajes.CODIGOMENSAJECONFIRMACIONREGISTROOBSERVACIONCONTROL));
			}
		}

		public void Modificar()
		{
			ObservacionesControlBE oObservacionesControlBE = new ObservacionesControlBE();

			oObservacionesControlBE.IdObservacion  = Convert.ToInt32(Page.Request.QueryString[KEYQID]);
			oObservacionesControlBE.IdPersonal = Convert.ToInt32(hIdPersonal.Value);
			oObservacionesControlBE.IdTablaSituacion = Convert.ToInt32(Enumerados.TablasTabla.TipoSituacion);
			oObservacionesControlBE.IdSituacion = Convert.ToInt32(ddlbSituacion.SelectedValue);
			oObservacionesControlBE.DescripcionObservacion = txtDescripcion.Text;
			oObservacionesControlBE.ObservacionControl = txtObservacion.Text;
			oObservacionesControlBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.ObservacionControl);
			oObservacionesControlBE.IdEstado = Convert.ToInt32(Enumerados.EstadosObservacionesControl.Activo);
			oObservacionesControlBE.IdUsuarioActualizacion = CNetAccessControl.GetIdUser();

			if(txtAccion.Text.Trim()!=String.Empty)
			{
				oObservacionesControlBE.Accion = txtAccion.Text;	
			}

			CMantenimientos oCMantenimientos = new CMantenimientos();
			if(oCMantenimientos.Modificar(oObservacionesControlBE)>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"OCI",this.ToString(),"Se modificó la Observación Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

				ltlMensaje.Text = Helper.MensajeRetornoAlert(
					Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionOCI.ToString()
					,Mensajes.CODIGOMENSAJECONFIRMACIONMODIFICACIONOBSERVACIONCONTROL));
			}
		}

		public void Eliminar()
		{
			// TODO:  Add DetallePoderes.Eliminar implementation
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
		}

		public void CargarModoModificar()
		{
			lblTitulo.Text = TITULOMODOMODIFICAR;
			this.LlenarCombos();

			CMantenimientos	oCMantenimientos = new CMantenimientos();
			ObservacionesControlBE oObservacionesControlBE = (ObservacionesControlBE)oCMantenimientos.ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYQID]),Enumerados.ClasesNTAD.ObservacionesControlNTAD.ToString());
			
			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"OCI",this.ToString(),"Se consultó el Detalle de la Observación Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

			if(oObservacionesControlBE!=null)
			{
				hIdPersonal.Value = oObservacionesControlBE.IdPersonal.ToString();
				txtPersonal.Text = oObservacionesControlBE.Personal.ToString();
				ddlbSituacion.Items.FindByValue(oObservacionesControlBE.IdSituacion.ToString()).Selected = true;				
				txtDescripcion.Text = oObservacionesControlBE.DescripcionObservacion.ToString();
				txtObservacion.Text = oObservacionesControlBE.ObservacionControl.ToString();

				if(!oObservacionesControlBE.Accion.IsNull)
				{
					txtAccion.Text  = oObservacionesControlBE.Accion.Value.ToString();
				}

			}
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add DetallePoderes.CargarModoConsulta implementation
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
			if(txtPersonal.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEOBSERVACIONCONTROLCAMPOREQUERIDORESPONSABLE));
				return false;		
			}

			if(txtDescripcion.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEOBSERVACIONCONTROLCAMPOREQUERIDODESCRIPCION));
				return false;		
			}

			if(txtObservacion.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEOBSERVACIONCONTROLCAMPOREQUERIDOOBSERVACION));
				return false;		
			}

			return true;		
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add DetallePoderes.ValidarExpresionesRegulares implementation
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

		private void redireccionaPaginaPrincipal()
		{
		}

		private void ibtnCancelar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.redireccionaPaginaPrincipal();
		}
	}
}