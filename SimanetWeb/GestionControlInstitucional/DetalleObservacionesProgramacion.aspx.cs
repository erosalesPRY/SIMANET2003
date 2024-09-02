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
	public class DetalleObservacionesProgramacion : System.Web.UI.Page,IPaginaBase
	{
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.Label lblConcepto;
		protected System.Web.UI.WebControls.Label lblFecha;
		protected System.Web.UI.WebControls.Label lblDatos;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvGestion;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtGestion;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary vSum;
		protected eWorld.UI.CalendarPopup CalFechaGestion;
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
		const string TITULOMODONUEVO = "NUEVA GESTION";
		const string TITULOMODOMODIFICAR = "GESTION";

		//Key Session y QueryString
		const string KEYQID = "Id";
		const string KEYQID2 = "Id2";
		const string KEYQDESCRIPCION = "Descripcion";
	
		//Paginas
		const string URLPRINCIPAL = "AdministracionObservacionesProgramacion.aspx?";
		const string URLDIALOGO = "../GestionComercial/ComunicacionImagen/Dialogo.aspx";

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

		public void LlenarCombos()
		{
			//lItem = new ListItem(Constantes.TEXTOSSELECCIONAR,Constantes.VALORSELECCIONAR);
		}

		public void LlenarDatos()
		{
			// TODO:  Add DetallePoderes.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			rfvGestion.ErrorMessage = Helper.ObtenerMensajesConfirmacionLegalUsuario(Mensajes.CODIGOMENSAJEPROGRAMACIONCAMPOREQUERIDOASUNTO);
			rfvGestion.ToolTip = Helper.ObtenerMensajesConfirmacionLegalUsuario(Mensajes.CODIGOMENSAJEPROGRAMACIONCAMPOREQUERIDOASUNTO);

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
			ObservacionesProgramacionBE oObservacionesProgramacionBE = new ObservacionesProgramacionBE();

			oObservacionesProgramacionBE.IdProgramacion  = Convert.ToInt32(Page.Request.QueryString[KEYQID]);
			oObservacionesProgramacionBE.FechaGestion = Convert.ToDateTime(CalFechaGestion.SelectedDate);
			oObservacionesProgramacionBE.Gestion = Convert.ToString(txtGestion.Text);
			if(txtDescripcion.Text.Trim()!=String.Empty)
			{
				oObservacionesProgramacionBE.DescripcionGestion = txtDescripcion.Text;	
			}
			oObservacionesProgramacionBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();
			oObservacionesProgramacionBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.ObservacionControl);
			oObservacionesProgramacionBE.IdEstado = Convert.ToInt32(Enumerados.EstadosObservacionesControl.Activo);
			
			CMantenimientos oCMantenimientos = new CMantenimientos();

			int retorno = oCMantenimientos.Insertar(oObservacionesProgramacionBE);

			if(retorno>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"OCI",this.ToString(),"Se registró la Gestión Nro. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));
			
				ltlMensaje.Text = Helper.MensajeRetornoAlert(
					Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionLegal.ToString()
					,Mensajes.CODIGOMENSAJECONFIRMACIONREGISTROOBSERVACIONCONTROL));
			}
		}

		public void Modificar()
		{
			ObservacionesProgramacionBE oObservacionesProgramacionBE = new ObservacionesProgramacionBE();

			oObservacionesProgramacionBE.IdProgramacion  = Convert.ToInt32(Page.Request.QueryString[KEYQID]);
			oObservacionesProgramacionBE.IdGestion  = Convert.ToInt32(Page.Request.QueryString[KEYQID2]);
			oObservacionesProgramacionBE.FechaGestion  = Convert.ToDateTime(CalFechaGestion.SelectedDate);
			oObservacionesProgramacionBE.Gestion = Convert.ToString(txtGestion.Text);
			if(txtDescripcion.Text.Trim()!=String.Empty)
			{
				oObservacionesProgramacionBE.DescripcionGestion = txtDescripcion.Text;	
			}
			oObservacionesProgramacionBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();
			oObservacionesProgramacionBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.ObservacionControl);
			oObservacionesProgramacionBE.IdEstado = Convert.ToInt32(Enumerados.EstadosObservacionesControl.Activo);
			
			CMantenimientos oCMantenimientos = new CMantenimientos();
			if(oCMantenimientos.Modificar(oObservacionesProgramacionBE)>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"OCI",this.ToString(),"Se modificó la Gestión Nro. " + Page.Request.QueryString[KEYQID2] + ".",Enumerados.NivelesErrorLog.I.ToString()));

				ltlMensaje.Text = Helper.MensajeRetornoAlert(
					Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionLegal.ToString()
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
			
			CMantenimientos	oCMantenimientos = new CMantenimientos();
			ObservacionesProgramacionBE oObservacionesProgramacionBE = (ObservacionesProgramacionBE)oCMantenimientos.ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYQID2]),Enumerados.ClasesNTAD.ObservacionesProgramacionNTAD.ToString());
			
			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"OCI",this.ToString(),"Se consultó el Detalle de la Gestión Nro. " + Page.Request.QueryString[KEYQID2] + ".",Enumerados.NivelesErrorLog.I.ToString()));

			if(oObservacionesProgramacionBE!=null)
			{
				CalFechaGestion.SelectedDate  = Convert.ToDateTime(oObservacionesProgramacionBE.FechaGestion);
				txtGestion.Text = oObservacionesProgramacionBE.Gestion.ToString();
				if(!oObservacionesProgramacionBE.DescripcionGestion.IsNull)
				{
					txtDescripcion.Text = oObservacionesProgramacionBE.DescripcionGestion.ToString();
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
			if(txtGestion.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionLegalUsuario(Mensajes.CODIGOMENSAJEOBSERVACIONCONTROLCAMPOREQUERIDODESCRIPCION));
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
			Page.Response.Redirect(URLPRINCIPAL + KEYQID + Utilitario.Constantes.SIGNOIGUAL + 
				Page.Request.QueryString[KEYQID] + Utilitario.Constantes.SIGNOAMPERSON + 
				KEYQDESCRIPCION + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQDESCRIPCION]);
		}


		private void ibtnCancelar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.redireccionaPaginaPrincipal();
		}	
	}
}