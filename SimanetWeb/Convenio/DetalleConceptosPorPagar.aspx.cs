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
using SIMA.EntidadesNegocio.Convenio;
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
	/// <summary>
	/// Summary description for DestalleConceptosPorPagar.
	/// </summary>
	public class DetalleConceptosPorPagar : System.Web.UI.Page, IPaginaMantenimento, IPaginaBase
	{
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.Label lblPeriodo;
		protected System.Web.UI.WebControls.Label lblConceptoDescripcion;
		protected System.Web.UI.WebControls.Label lblMontoPorPagar;
		protected System.Web.UI.WebControls.TextBox txtConceptoPorPagar;
		protected eWorld.UI.NumericBox nbMontoPorPagar;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected eWorld.UI.NumericBox nbPeriodo;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rqdvPeriodo;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary DomValidationSummary1;
		protected System.Web.UI.WebControls.RangeValidator ragvPeriodo;
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
					SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Utilitario.Constantes.CODIGOERRORGENERICO,oException.Message);
					Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
				}
			}
		}
		
		#region Constantes

		const string KEYIDCONCEPTOPORPAGAR="IdConceptoPorPagar";

		//url

		const string URLPRINCIPAL="AdministrarConceptosPorPagar.aspx";

		#endregion Constantes

		private void RedireccionarPrincipal()
		{
			this.Page.Response.Redirect(URLPRINCIPAL);
		}

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			ConceptosPorPagarBE oConceptosPorPagarBE=new ConceptosPorPagarBE();

			oConceptosPorPagarBE.Periodo=Convert.ToInt32(this.nbPeriodo.Text);
			oConceptosPorPagarBE.ConceptoDescripcion=this.txtConceptoPorPagar.Text;
			oConceptosPorPagarBE.MontoPorPagar=NullableDouble.Parse(nbMontoPorPagar.Text);
			oConceptosPorPagarBE.IdTablaEstado=Convert.ToInt32(Utilitario.Enumerados.TablasTabla.ConvenioEstadoConceptoPorPagar);
			oConceptosPorPagarBE.IdEstado=Convert.ToInt32(Utilitario.Enumerados.ConvenioEstadoConceptoPorPagar.Activo);
			oConceptosPorPagarBE.IdUsuarioRegistro=CNetAccessControl.GetIdUser();

			CConceptosPorPagar oCConceptosPorPagar=new CConceptosPorPagar();

			int retorno=0;

			retorno=oCConceptosPorPagar.Insertar(oConceptosPorPagarBE);

			if(retorno>0)
			{
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Concepto Por Pagar",this.ToString(),"Se registró Concepto Por Pagar " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));

				string strUrlGoBack = URLPRINCIPAL;
				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionConvenios.ToString(),Mensajes.CONVENIOREGISTROEXITOSO),strUrlGoBack.ToString());
			}
	    }

		public void Modificar()
		{
			ConceptosPorPagarBE oConceptosPorPagarBE=new ConceptosPorPagarBE();
			oConceptosPorPagarBE.IdConceptoPorPagar=Convert.ToInt32(this.Page.Request.Params[KEYIDCONCEPTOPORPAGAR]);
			oConceptosPorPagarBE.Periodo=Convert.ToInt32(this.nbPeriodo.Text);
			oConceptosPorPagarBE.ConceptoDescripcion=this.txtConceptoPorPagar.Text;
			oConceptosPorPagarBE.MontoPorPagar=NullableDouble.Parse(nbMontoPorPagar.Text);
			oConceptosPorPagarBE.IdUsuarioActualizacion=CNetAccessControl.GetIdUser();

			CConceptosPorPagar oCConceptosPorPagar=new CConceptosPorPagar();

			int retorno=0;

			retorno=oCConceptosPorPagar.Modificar(oConceptosPorPagarBE);
			if(retorno>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo
					(new LogAplicativo(CNetAccessControl.GetUserName(),"Concepto Por Pagar",this.ToString(),"Se modificó Item de " + 
					oCConceptosPorPagar.ToString(),Enumerados.NivelesErrorLog.I.ToString()));
				//Elabora el Query string para luego redireccionar a la pagina que invoco esta accion
				string strUrlGoBack = URLPRINCIPAL;
				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionConvenios.ToString(),Utilitario.Mensajes.CODIGOMENSAJECONFIRMACIONMODIFICACIONREGISTROSELECCIONADO),strUrlGoBack.ToString());
			}
		}

		public void Eliminar()
		{
			// TODO:  Add DetalleConceptosPorPagar.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.Params[Utilitario.Constantes.KEYMODOPAGINA].ToString()) ;
			switch (oModoPagina)
			{
				case Enumerados.ModoPagina.N:
					this.CargarModoNuevo();
					break;
				case Enumerados.ModoPagina.M:
					this.CargarModoModificar();
					break;
			}
		}

		public void CargarModoNuevo()
		{
			this.lblTitulo.Text="REGISTRAR CONCEPTO POR PAGAR";
		}

		public void CargarModoModificar()
		{
			this.lblTitulo.Text="MANTENIMIENTO DE CONCEPTOS POR PAGAR";
			this.nbPeriodo.Enabled=false;
			CConceptosPorPagar oCConceptosPorPagar=new CConceptosPorPagar();
			ConceptosPorPagarBE oConceptosPorPagarBE=(ConceptosPorPagarBE)oCConceptosPorPagar.DetalleConceptoPorPagar(Convert.ToInt32(this.Page.Request.Params[KEYIDCONCEPTOPORPAGAR]));

			if(oConceptosPorPagarBE!=null)
			{
				this.nbPeriodo.Text=oConceptosPorPagarBE.Periodo.ToString();
				this.txtConceptoPorPagar.Text=oConceptosPorPagarBE.ConceptoDescripcion.ToString();
				this.nbMontoPorPagar.Text=NullableString.Parse(oConceptosPorPagarBE.MontoPorPagar).ToString();
			}
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add DetalleConceptosPorPagar.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add DetalleConceptosPorPagar.ValidarCampos implementation
			return true;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add DetalleConceptosPorPagar.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add DetalleConceptosPorPagar.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add DetalleConceptosPorPagar.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetalleConceptosPorPagar.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetalleConceptosPorPagar.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add DetalleConceptosPorPagar.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add DetalleConceptosPorPagar.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			this.rqdvPeriodo.ErrorMessage=Helper.ObtenerMensajesErrorConvenioUsuario(Mensajes.CONVENIOREQUIEREPERIODO);
			this.ragvPeriodo.MaximumValue=Convert.ToString(DateTime.Now.Year);
			this.ragvPeriodo.MinimumValue="1995";
			this.ragvPeriodo.ErrorMessage="No puede registrar conceptos de los Periodos menores al año 1995 o mayores al " + Convert.ToString(DateTime.Now.Year);
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetalleConceptosPorPagar.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetalleConceptosPorPagar.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetalleConceptosPorPagar.Exportar implementation
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
			// TODO:  Add DetalleConceptosPorPagar.ValidarFiltros implementation
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

	}
}
