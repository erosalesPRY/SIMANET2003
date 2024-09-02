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
using SIMA.Controladoras.GestionControlInstitucional;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using SIMA.EntidadesNegocio.GestionControlInstitucional;
using NetAccessControl;

namespace SIMA.SimaNetWeb.GestionControlInstitucional
{
	/// <summary>
	/// Summary description for DetalleGrupoAreaCritica.
	/// </summary>
	public class DetalleGrupoAreaCritica : System.Web.UI.Page, IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblMensaje;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.ImageButton ibtnCancelar;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary vSum;
		protected System.Web.UI.WebControls.Label lblCodigo;
		protected System.Web.UI.WebControls.Label lblDenominacion;
		protected System.Web.UI.WebControls.TextBox txtCodigo;
		protected System.Web.UI.WebControls.TextBox txtDenominacion;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvCodigo;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvDenominacion;
		protected System.Web.UI.HtmlControls.HtmlTableCell TdCeldaAtras;
		protected System.Web.UI.WebControls.Label lblTitulo;
		#endregion Controles

		#region Constantes
		//Titulos 
		const string TITULOMODONUEVO     = "NUEVA GRUPO DE AREA CRÍTICA";
		const string TITULOMODOMODIFICAR = "MODIFICAR GRUPO DE AREA CRÍTICA";
		const string TITULOMODOCONSULTA  = "CONSULTAR GRUPO DE AREA CRÍTICA";

		//Key Session y QueryString
		const string KEYQID = "Id";

		//Paginas
		const string URLPRINCIPAL = "AdministracionGrupoAreaCritica.aspx";

		#endregion Constantes

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
			this.ibtnCancelar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnCancelar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!Page.IsPostBack)
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
					SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
					Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
				}

			}
		}

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
		}

		public void LlenarDatos()
		{
		
		}

		public void LlenarJScript()
		{
			this.rfvCodigo.ErrorMessage       = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEGRUPOAREACRITICACAMPOREQUERIDOCODIGO);
			this.rfvCodigo.ToolTip            = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEGRUPOAREACRITICACAMPOREQUERIDOCODIGO);

			this.rfvDenominacion.ErrorMessage = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEGRUPOAREACRITICACAMPOREQUERIDODENOMINACION);
			this.rfvDenominacion.ToolTip      = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEGRUPOAREACRITICACAMPOREQUERIDODENOMINACION);
		}

		public void RegistrarJScript()
		{
			// TODO:  Add implementation
		}

		public void Imprimir()
		{
			// TODO:  Add implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultaDeCartasFianzas.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add implementation

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
			GrupoAreaCriticaBE oGrupoAreaCriticaBE  = new GrupoAreaCriticaBE();

			oGrupoAreaCriticaBE.NroGrupoAreaCritica = txtCodigo.Text;
			oGrupoAreaCriticaBE.Denominacion        = txtDenominacion.Text.ToUpper();

			
			oGrupoAreaCriticaBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();
			oGrupoAreaCriticaBE.IdTablaEstado     = Convert.ToInt32(Enumerados.TablasTabla.GrupoAreaCritica);
			oGrupoAreaCriticaBE.IdEstado          = Convert.ToInt32(Enumerados.EstadosGrupoAreaCritica.Activo);
			
			CMantenimientos oCMantenimientos = new CMantenimientos();

			int retorno = oCMantenimientos.Insertar(oGrupoAreaCriticaBE);

			if(retorno>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Detalle Grupo de Area Critica",this.ToString(),"Se registró el Detalle de Grupo de Área Crítica Nro. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));
				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionOCI.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONREGISTROGRUPOAREACRITICA),URLPRINCIPAL);
			}
		}

		public void Modificar()
		{
			GrupoAreaCriticaBE oGrupoAreaCriticaBE = new GrupoAreaCriticaBE();

			oGrupoAreaCriticaBE.IdGrupoAreaCritica     = Convert.ToInt32(Page.Request.QueryString[KEYQID]);
			oGrupoAreaCriticaBE.NroGrupoAreaCritica    = txtCodigo.Text;
			oGrupoAreaCriticaBE.Denominacion           = txtDenominacion.Text;

			oGrupoAreaCriticaBE.IdUsuarioActualizacion = CNetAccessControl.GetIdUser();
			oGrupoAreaCriticaBE.IdTablaEstado          = Convert.ToInt32(Enumerados.TablasTabla.GrupoAreaCritica);
			oGrupoAreaCriticaBE.IdEstado               = Convert.ToInt32(Enumerados.EstadosGrupoAreaCritica.Modificado);
			
			CMantenimientos oCMantenimientos = new CMantenimientos();
			if(oCMantenimientos.Modificar(oGrupoAreaCriticaBE)>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Detalle Grupo de Area Critica",this.ToString(),"Se modificó el Detalle de Grupo de Área Crítica Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));
				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionOCI.ToString(),Mensajes.CODIGOMENSAJEMODIFICACIONREGISTROGRUPOAREACRITICA),URLPRINCIPAL);
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
			this.TdCeldaAtras.Visible = false;
			lblTitulo.Text = TITULOMODOMODIFICAR;
			this.LlenarCombos();
			
			CGrupoAreaCritica oCGrupoAreaCritica   = new CGrupoAreaCritica();
			GrupoAreaCriticaBE oGrupoAreaCriticaBE = (GrupoAreaCriticaBE) oCGrupoAreaCritica.DetalleGrupoAreaCritica(Convert.ToInt32(Page.Request.QueryString[KEYQID]));

			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Detalle Grupo Área Crítica",this.ToString(),"Se consultó el Detalle de Grupo de Área Crítica Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

			if(oGrupoAreaCriticaBE!=null)
			{
				txtCodigo.Text        = oGrupoAreaCriticaBE.NroGrupoAreaCritica.ToString();
				txtDenominacion.Text  = oGrupoAreaCriticaBE.Denominacion.ToString();
			}
		}

		public void CargarModoConsulta()
		{

			this.ibtnCancelar.Visible = false;
			Helper.BloquearControles(this);
			lblTitulo.Text = TITULOMODOCONSULTA;
			this.LlenarCombos();
			
			CGrupoAreaCritica oCGrupoAreaCritica   = new CGrupoAreaCritica();
			GrupoAreaCriticaBE oGrupoAreaCriticaBE = (GrupoAreaCriticaBE) oCGrupoAreaCritica.DetalleGrupoAreaCritica(Convert.ToInt32(Page.Request.QueryString[KEYQID]));

			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Detalle Grupo Área Crítica",this.ToString(),"Se consultó el Detalle de Grupo de Área Crítica Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

			if(oGrupoAreaCriticaBE!=null)
			{
				txtCodigo.Text        = oGrupoAreaCriticaBE.NroGrupoAreaCritica.ToString();
				txtDenominacion.Text  = oGrupoAreaCriticaBE.Denominacion.ToString();
			}
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
			if(txtCodigo.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEGRUPOAREACRITICACAMPOREQUERIDOCODIGO));
				return false;		
			}
						
			if(txtDenominacion.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEGRUPOAREACRITICACAMPOREQUERIDOCODIGO));
				return false;		
			}
			return true;
		}

		public bool ValidarExpresionesRegulares()
		{
			return true;
		}

		#endregion

		#region Opciones Usuario

		#region Cancelar
		private void ibtnCancelar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.redireccionaPaginaPrincipal();
		}

		private void redireccionaPaginaPrincipal()
		{
			Page.Response.Redirect(URLPRINCIPAL);
		}
		#endregion Cancelar
		#endregion Opciones Usuario

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
