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
using System.IO;

using SIMA.SimaNetWeb.InterfacesIU;
using SIMA.EntidadesNegocio.Proyectos;
using SIMA.Controladoras.Convenio;
using SIMA.Controladoras.General;
using SIMA.Controladoras;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using NullableTypes;

namespace SIMA.SimaNetWeb.Convenio
{
	public class DetalleProgramacionActividades : System.Web.UI.Page,IPaginaMantenimento,IPaginaBase
	{
		#region IPaginaMantenimento Members

		public void Agregar()
		{
			ProgramaActividadBE oProgramaActividadBE=new ProgramaActividadBE();

			oProgramaActividadBE.Idproyectoconvenio = Convert.ToInt32(Page.Request[KEYIDPROYECTOCONVENIO].ToString());

			oProgramaActividadBE.Unidad = txtUnidad.Text;
			oProgramaActividadBE.Nrocasco = txtCasco.Text;
			oProgramaActividadBE.St = txtSt.Text;
			oProgramaActividadBE.Ot = txtOt.Text;
			oProgramaActividadBE.Descripcion = txtDescripcion.Text;
			oProgramaActividadBE.Montoaprobado = (nbMontoAprobado.Text == String.Empty)?0:Convert.ToDouble(this.nbMontoAprobado.Text);
			oProgramaActividadBE.Avancefisico = (nbAvanceFisico.Text == String.Empty)?0:Convert.ToDouble(this.nbAvanceFisico.Text);
			oProgramaActividadBE.Avanceeconomico = (nbAvanceEconomico.Text == String.Empty)?0:Convert.ToDouble(this.nbAvanceEconomico.Text);
			oProgramaActividadBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();
			oProgramaActividadBE.IdTablaEstado = 999;
			oProgramaActividadBE.IdEstado = Convert.ToInt32(Enumerados.TipoEstadoEntidadOtros.Activo);

			CProyectoConvenio oCProyectoConvenio=new CProyectoConvenio();
			
			int retorno=oCProyectoConvenio.InsertarProgramaActividad(oProgramaActividadBE);

			if(retorno==Utilitario.Constantes.VALORCONFIRMACIONREGISTRO)
			{
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Programa de Actividades",this.ToString(),"Se registró Item de Programa - Actividad " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));
				ltlMensaje.Text = Helper.MensajeRetornoAlert("Se registró Programa de Actividad");		
			}
			else
			{
				ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerMensajesErrorConvenioUsuario(retorno.ToString()));
			}
		}

		public void Modificar()
		{
			ProgramaActividadBE oProgramaActividadBE=new ProgramaActividadBE();

			oProgramaActividadBE.Idprograma_proyecto = Convert.ToInt32(Page.Request[KEYIDPROGRAMAPROYECTO].ToString());
			oProgramaActividadBE.Idproyectoconvenio = Convert.ToInt32(hCodigo.Value);
			oProgramaActividadBE.Unidad = txtUnidad.Text;
			oProgramaActividadBE.Nrocasco = txtCasco.Text;
			oProgramaActividadBE.St = txtSt.Text;
			oProgramaActividadBE.Ot = txtOt.Text;
			oProgramaActividadBE.Descripcion = txtDescripcion.Text;
			oProgramaActividadBE.Montoaprobado = (nbMontoAprobado.Text == String.Empty)?0:Convert.ToDouble(this.nbMontoAprobado.Text);
			oProgramaActividadBE.Avancefisico = (nbAvanceFisico.Text == String.Empty)?0:Convert.ToDouble(this.nbAvanceFisico.Text);
			oProgramaActividadBE.Avanceeconomico = (nbAvanceEconomico.Text == String.Empty)?0:Convert.ToDouble(this.nbAvanceEconomico.Text);
			oProgramaActividadBE.IdUsuarioActualizacion = CNetAccessControl.GetIdUser();
			oProgramaActividadBE.IdTablaEstado = 999;
			oProgramaActividadBE.IdEstado = Convert.ToInt32(Enumerados.TipoEstadoEntidadOtros.Activo);

			CProyectoConvenio oCProyectoConvenio=new CProyectoConvenio();

			int retorno=oCProyectoConvenio.ModificarProgramaActividad(oProgramaActividadBE);		

			if(retorno>0)
			{
				LogAplicativo.GrabarLogAplicativoArchivo
					(new LogAplicativo(CNetAccessControl.GetUserName(),"Convenio",this.ToString(),"Se modificó Item de " + 
					oProgramaActividadBE.ToString(),Enumerados.NivelesErrorLog.I.ToString()));
				ltlMensaje.Text = Helper.MensajeRetornoAlert("Se modificó el Programa");
			}
		}

		public void Eliminar()
		{
			// TODO:  Add DetalleProyectoConvenio.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.Params[Utilitario.Constantes.KEYMODOPAGINA].ToString()) ;
			switch (oModoPagina)
			{
				case Enumerados.ModoPagina.N:
					lblTitulo.Text = Page.Request[KEYCONVENIO].ToString() + Utilitario.Constantes.SEPARADORLINEA + Page.Request[KEYACTIVIDAD].ToString();
					this.CargarModoNuevo();
					break;
				case Enumerados.ModoPagina.M:
					lblTitulo.Text = Page.Request[KEYPROGRAMAPROYECTO].ToString();
					this.CargarModoModificar();
					break;
			}			
		}

		public void CargarModoNuevo()
		{
		}

		public void CargarModoModificar()
		{
			CProyectoConvenio oCProyectoConvenio=new CProyectoConvenio();
			ProgramaActividadBE oProgramaActividadBE=(ProgramaActividadBE)oCProyectoConvenio.ListarDetalleProgramaActividad(Convert.ToInt32(Page.Request[KEYIDPROGRAMAPROYECTO].ToString()));
			if(oProgramaActividadBE!=null)
			{
				hCodigo.Value = oProgramaActividadBE.Idproyectoconvenio.ToString();
				txtUnidad.Text = oProgramaActividadBE.Unidad.ToString();
				txtCasco.Text = oProgramaActividadBE.Nrocasco.ToString();
				txtSt.Text = oProgramaActividadBE.St.ToString();
				txtOt.Text = oProgramaActividadBE.Ot.ToString();
				txtDescripcion.Text = oProgramaActividadBE.Descripcion.ToString();
				nbMontoAprobado.Text = oProgramaActividadBE.Montoaprobado.ToString();
				nbAvanceFisico.Text = oProgramaActividadBE.Avancefisico.ToString();
				nbAvanceEconomico.Text = oProgramaActividadBE.Avanceeconomico.ToString();
			}
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add DetalleProyectoConvenio.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			return true;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add DetalleProyectoConvenio.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add DetalleProyectoConvenio.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion
		#region IPaginaBase Members
		public void LlenarGrilla()
		{
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
		}

		public void LlenarCombos()
		{
		}
		
		public void LlenarDatos()
		{
		}

		public void LlenarJScript()
		{
			this.rqdvActividad.ErrorMessage="Ingrese Unidad";
			this.rfvCasco.ErrorMessage="Ingrese Casco";
			this.rfvSt.ErrorMessage="Ingrese Solicitud de Trabajo";
			this.rfvOt.ErrorMessage="Ingrese Orden de Trabajo";
			this.rfvDescripcion.ErrorMessage="Ingrese Descripción del Trabajo";
		}

		public void RegistrarJScript()
		{
		}

		public void Imprimir()
		{
		}

		public void Exportar()
		{
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
		#region Constantes

		private const string KEYIDPROGRAMAPROYECTO="IdProgramaProyecto";
		private const string KEYPROGRAMAPROYECTO="ProgramaProyecto";
		private const string KEYIDPROYECTOCONVENIO="IdProyectoConvenio";
		private const string KEYCONVENIO= "Convenio";
		private const string KEYACTIVIDAD= "Actividad";

		#endregion Constantes

		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblNroProyecto;
		protected System.Web.UI.WebControls.TextBox txtUnidad;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rqdvActividad;
		protected System.Web.UI.WebControls.Label lblDescripcion;
		protected System.Web.UI.WebControls.TextBox txtCasco;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvCasco;
		protected System.Web.UI.WebControls.Label lblMonto;
		protected System.Web.UI.WebControls.TextBox txtSt;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvSt;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.TextBox txtOt;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvOt;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvDescripcion;
		protected System.Web.UI.WebControls.Label Label1;
		protected eWorld.UI.NumericBox nbMontoAprobado;
		protected System.Web.UI.WebControls.Label Label5;
		protected eWorld.UI.NumericBox nbAvanceFisico;
		protected System.Web.UI.WebControls.Label lblEstado;
		protected eWorld.UI.NumericBox nbAvanceEconomico;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary DomValidationSummary1;
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


		private void RedireccionarPaginaPrincipal()
		{
		}

		private void ibtnAceptar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				if(Page.IsValid)
				{
					if(this.ValidarCampos())
					{
						Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.Params[Utilitario.Constantes.KEYMODOPAGINA]) ;
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
				string ex = oException.Message.ToString();
				SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Utilitario.Constantes.CODIGOERRORGENERICO,oException.Message);
				Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
			}		
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					//this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
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
	}
}