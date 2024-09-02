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
using SIMA.Controladoras.GestionEstrategica;
using SIMA.Controladoras.General;
using SIMA.EntidadesNegocio.GestionEstrategica;
using System.IO;
using NullableTypes;

namespace SIMA.SimaNetWeb.DirectorioEjecutivo.GestionEstrategica
{
	public class DetalleConsultorPAMC : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		#region Controles
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.TextBox txtObservaciones;
		protected System.Web.UI.WebControls.Label lblObservaciones;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.Label lblDescripcion;
		protected System.Web.UI.WebControls.TextBox txtNombreLargo;
		protected System.Web.UI.WebControls.Label lblNombreLargo;
		protected System.Web.UI.WebControls.TextBox txtNombre;
		protected System.Web.UI.WebControls.Label lblNombre;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvNombre;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary vSum;
		protected System.Web.UI.WebControls.Label lblCurriculum;
		protected System.Web.UI.WebControls.Label lblPaginaActual;
		protected System.Web.UI.HtmlControls.HtmlInputFile filMyFile;
		protected System.Web.UI.WebControls.Label lblRuta;
		#endregion

		#region Constantes
		const string KEYPAMCNIVEL="KEYPAMCNIVEL";
		const string KEYPAMCNOMBRENIVEL="KEYPAMCNOMBRENIVEL";
		const string KEYPAMCAGRUPACION="KEYPAMCAGRUPACION";
		const string KEYPAMCDETALLEAGRUPACION = "KEYPAMCDETALLEAGRUPACION";
		const string KEYPAMCTERMINOREFERENCIA="KEYPAMCTERMINOREFERENCIA";
		const string KEYPAMCCONSULTORES = "KEYPAMCCONSULTORES";

		const string GRILLAVACIA = "No existen Registros";
		const string TEXTOFOOTERTOTAL="TOTAL:";
		const string JRETURN = " return false;";
		const string JRETURNDOS = "; return false;";
		
		string RutaImagenServerProyecto = Helper.ObtenerRutaImagenes(Utilitario.Constantes.ProyectoRutaCarpetaArchivoProyectoAMC);
		string RutaImagenCarpetaProyecto = Helper.ObtenerRutaImagenes(Utilitario.Constantes.ProyectoRutaCarpetaArchivoProyectoAMC);
		
		const string SeparadorExtencion=".";
		const int TAMANOARCHIVO=5000000;
		const string SiglaProyecto="COM";
		const string FORMATOCEROS="000000";

		const string COLORDENAMIENTO = "TIPOOBJETIVO";
		protected System.Web.UI.WebControls.CheckBox chkEstado;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hFila;
		protected System.Web.UI.WebControls.Label Label1;
		protected eWorld.UI.NumericBox txtNroExposicion;
		private string JSVERIFICARSELECCIONFILA="return verificarSeleccionRb('hIdObjetivoGeneral','"+ Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO) + "');";
	
		#endregion
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					this.CargarModoPagina();

					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo
						(CNetAccessControl.GetUserName(),
						Utilitario.Enumerados.NombresdeModulo.GestionEstratégica.ToString(),
						this.ToString(),"SE INGRESO DETALLE DE CONSULTORES PAMC",
						Enumerados.NivelesErrorLog.I.ToString()));			
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
			PAMCConsultorBE oPAMCConsultorBE
				= new PAMCConsultorBE();

			if(txtDescripcion.Text !=String.Empty)
				oPAMCConsultorBE.Descripcion = NullableString.Parse(txtDescripcion.Text);
			
			oPAMCConsultorBE.FechaRegistro = DateTime.Now;

			oPAMCConsultorBE.IdTerminoReferenciaPAMC = Convert.ToInt32(Page.Request.QueryString[KEYPAMCTERMINOREFERENCIA]);

			oPAMCConsultorBE.IdEstado = Convert.ToInt32(Enumerados.EstadoGeneral.Activo);
			oPAMCConsultorBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.EstadoGeneral);

			oPAMCConsultorBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();

			oPAMCConsultorBE.Nombre = txtNombre.Text;

			if(txtNombreLargo.Text !=String.Empty)
				oPAMCConsultorBE.Nombrelargo = NullableString.Parse(txtNombreLargo.Text);
			
			if(txtNroExposicion.Text != String.Empty)
				oPAMCConsultorBE.NroExposicion = NullableInt32.Parse(txtNroExposicion.Text);

			if(txtObservaciones.Text !=String.Empty)
				oPAMCConsultorBE.Observaciones = NullableString.Parse(txtObservaciones.Text);

			if(filMyFile.Value!=String.Empty)
			{
				string strFilename = filMyFile.PostedFile.FileName;
				string[] res = strFilename.Split('\\');
				int i=res.GetUpperBound(Utilitario.Constantes.ValorConstanteCero);
				strFilename = res[i];

				oPAMCConsultorBE.RutaCurriculum = strFilename;
			}

			CMantenimientos oCMantenimientos = new CMantenimientos();
			int retorno = oCMantenimientos.Insertar(oPAMCConsultorBE);	

			if(retorno>=Utilitario.Constantes.ValorConstanteCero)
			{
				if(filMyFile.Value !=String.Empty)
					GuardarDocumento();
				
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Enumerados.NombresdeModulo.GestiónComercial.ToString() ,this.ToString(), "Se registro Consultor PAMC" + retorno.ToString() + Utilitario.Constantes.SIMBOLOPUNTO,Enumerados.NivelesErrorLog.I.ToString()));
				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionEstrategica.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONREGISTROPROCESO)) + Utilitario.Constantes.HISTORIALATRAS;
			}

		}

		public void GuardarDocumento() 
		{
			HttpPostedFile myFile = filMyFile.PostedFile;
			int nFileLen = myFile.ContentLength; 

			if( nFileLen > Utilitario.Constantes.ValorConstanteCero )
			{
				if(nFileLen <= TAMANOARCHIVO)
				{	
					byte[] myData = new byte[nFileLen];

					myFile.InputStream.Read(myData,Utilitario.Constantes.ValorConstanteCero, nFileLen);
					string path = RutaImagenCarpetaProyecto;
					
					string strFilename = filMyFile.PostedFile.FileName;
					string[] res = strFilename.Split('\\');
					int i=res.GetUpperBound(Utilitario.Constantes.ValorConstanteCero);
					strFilename = res[i];
							
					WriteToFile(path + strFilename,ref myData);
				}
			}		
		}

		private void WriteToFile(string strPath, ref byte[] Buffer)
		{
			FileStream newFile = new FileStream(strPath,FileMode.Create);	
			newFile.Write(Buffer, Utilitario.Constantes.ValorConstanteCero, Buffer.Length);
			newFile.Close();
		}

		public void Modificar()
		{

			PAMCConsultorBE oPAMCConsultorBE
				= new PAMCConsultorBE();

			if(txtDescripcion.Text !=String.Empty)
				oPAMCConsultorBE.Descripcion = NullableString.Parse(txtDescripcion.Text);
			
			oPAMCConsultorBE.FechaRegistro = DateTime.Now;

			oPAMCConsultorBE.IdTerminoReferenciaPAMC = Convert.ToInt32(Page.Request.QueryString[KEYPAMCTERMINOREFERENCIA]);

			oPAMCConsultorBE.IdEstado = Convert.ToInt32(Enumerados.EstadoGeneral.Activo);
			oPAMCConsultorBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.EstadoGeneral);

			oPAMCConsultorBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();

			oPAMCConsultorBE.Nombre = txtNombre.Text;

			if(txtNroExposicion.Text != String.Empty)
				oPAMCConsultorBE.NroExposicion = NullableInt32.Parse(txtNroExposicion.Text);

			if(txtNombreLargo.Text !=String.Empty)
				oPAMCConsultorBE.Nombrelargo = NullableString.Parse(txtNombreLargo.Text);
			
			if(txtObservaciones.Text !=String.Empty)
				oPAMCConsultorBE.Observaciones = NullableString.Parse(txtObservaciones.Text);

			if(filMyFile.Value!=String.Empty)
			{
				string strFilename = filMyFile.PostedFile.FileName;
				string[] res = strFilename.Split('\\');
				int i=res.GetUpperBound(Utilitario.Constantes.ValorConstanteCero);
				strFilename = res[i];

				oPAMCConsultorBE.RutaCurriculum = strFilename;
			}

			oPAMCConsultorBE.IdConsultorPAMC = Convert.ToInt32(Page.Request.QueryString[KEYPAMCCONSULTORES]);

			CMantenimientos oCMantenimientos = new CMantenimientos();
			int retorno = oCMantenimientos.Modificar(oPAMCConsultorBE);	

			if(retorno>=Utilitario.Constantes.ValorConstanteCero)
			{
				if(filMyFile.Value !=String.Empty)
					GuardarDocumento();
				
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Enumerados.NombresdeModulo.GestiónComercial.ToString() ,this.ToString(), "Se modifico Consultor PAMC" + retorno.ToString() + Utilitario.Constantes.SIMBOLOPUNTO,Enumerados.NivelesErrorLog.I.ToString()));
				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionEstrategica.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONREGISTROPROCESO)) + Utilitario.Constantes.HISTORIALATRAS;
			}
		}

		public void Eliminar()
		{
		}

		public void CargarModoPagina()
		{
			Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.QueryString[Utilitario.Constantes.KEYMODOPAGINA]) ;

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
		}

		public void CargarModoModificar()
		{
			CMantenimientos	oCMantenimientos = new CMantenimientos();
			PAMCConsultorBE oPAMCConsultorBE = (PAMCConsultorBE)oCMantenimientos.ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYPAMCCONSULTORES]),Enumerados.ClasesNTAD.PAMCConsultorNTAD.ToString());

			txtNombre.Text = oPAMCConsultorBE.Nombre.ToString();
			
			txtDescripcion.Text = oPAMCConsultorBE.Descripcion.ToString();

			txtObservaciones.Text = oPAMCConsultorBE.Observaciones.ToString();

			txtNombreLargo.Text = oPAMCConsultorBE.Nombrelargo.ToString();

			txtNroExposicion.Text = oPAMCConsultorBE.NroExposicion.ToString();

			if(!oPAMCConsultorBE.RutaCurriculum.IsNull)
			{
				chkEstado.Checked = true;
				hFila.Value =oPAMCConsultorBE.RutaCurriculum.ToString();
			}

		}

		public void CargarModoConsulta()
		{
		}
		public bool ValidarCampos()
		{
			return Utilitario.Constantes.VALORCHECKEDBOOL;
		}

		public bool ValidarCamposRequeridos()
		{
			return Utilitario.Constantes.VALORCHECKEDBOOL;
		}

		public bool ValidarExpresionesRegulares()
		{
			return true;
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
			this.rfvNombre.ErrorMessage = "Tiene que ingresar un nombre para el documento";
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
			return true;
		}

		#endregion

		private void ibtnAceptar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				if(this.ValidarCampos())
				{
					Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.QueryString[Utilitario.Constantes.KEYMODOPAGINA]) ;
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
