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
	public class DetalleDetalleAgrupacionPAMC : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		#region Controles

		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblRutaPagina;	
		#endregion

		#region Constantes
		const string URLDETALLE = "DetalleDetalleAgrupacionPAMC.aspx?";
		const string URLSIGUIENTENIVEL="AdministrarTerminosReferenciaPAMC.aspx?";
		const string KEYPAMCNIVEL="KEYPAMCNIVEL";
		const string KEYPAMCNOMBRENIVEL="KEYPAMCNOMBRENIVEL";
		const string KEYPAMCAGRUPACION="KEYPAMCAGRUPACION";

		const string GRILLAVACIA = "No existen Registros";
		const string TEXTOFOOTERTOTAL="TOTAL:";
		const string ARCHIVO = "sinfoto.jpg";
		const string JRETURN = " return false;";
		const string JRETURNDOS = "; return false;";
		private string RutaImagenServerProyectoDos = Helper.ObtenerRutaImagenes(Utilitario.Constantes.ProyectoRutaImagenServerProyectoEjecucionTerminado);
		string RutaImagenServerProyecto = Helper.ObtenerRutaImagenes(Utilitario.Constantes.ProyectoRutaServerArchivoProyectoAMC);
		string RutaImagenCarpetaProyecto = Helper.ObtenerRutaImagenes(Utilitario.Constantes.ProyectoRutaCarpetaArchivoProyectoAMC);
		const string SeparadorExtencion=".";
		const int TAMANOARCHIVO=5000000;
		const string SiglaProyecto="COM";
		const string FORMATOCEROS="000000";

		const string COLORDENAMIENTO = "TIPOOBJETIVO";
		private string JSVERIFICARSELECCIONFILA="return verificarSeleccionRb('hIdObjetivoGeneral','"+ Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO) + "');";
		protected System.Web.UI.WebControls.Label lblNombreDocumento;
		protected System.Web.UI.WebControls.TextBox txtNombre;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvNombre;
		protected System.Web.UI.WebControls.Label lblSituacionActual;
		protected System.Web.UI.WebControls.TextBox txtSituacionActual;
		protected System.Web.UI.WebControls.Label lblRuta;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.Label lblObservaciones;
		protected System.Web.UI.WebControls.TextBox txtObservaciones;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary vSum;
		protected System.Web.UI.HtmlControls.HtmlInputFile filMyFile;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdObjetivoGeneral;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdObjetivoEspecifico;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hFoto;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hFila;
		protected System.Web.UI.WebControls.Label lblTitulodos;
		protected System.Web.UI.WebControls.Label Label2;
		protected eWorld.UI.NumericBox txtNroExposicion;
		protected System.Web.UI.WebControls.Label lblCentroOperativo;
		protected System.Web.UI.WebControls.DropDownList ddlCentroOperativo;
		const string KEYPAMCDETALLEAGRUPACION = "KEYPAMCDETALLEAGRUPACION";
		#endregion
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					this.LlenarCombos();
					this.LlenarDatos();
					this.CargarModoPagina();
					this.LlenarJScript();
					this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO),Utilitario.Constantes.INDICEPAGINADEFAULT);

					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo
						(CNetAccessControl.GetUserName(),
						Utilitario.Enumerados.NombresdeModulo.GestionEstratégica.ToString(),
						this.ToString(),"SE INGRESO AL DETALLE DE AGRUPACION PAMC",
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
			PAMCDetalleAgrupacionBE oPAMCDetalleAgrupacionBE 
				= new PAMCDetalleAgrupacionBE();

			if(txtDescripcion.Text !=String.Empty)
				oPAMCDetalleAgrupacionBE.Descripcion = NullableString.Parse(txtDescripcion.Text);
			
			oPAMCDetalleAgrupacionBE.FechaRegistro = DateTime.Now;

			oPAMCDetalleAgrupacionBE.IdAgrupacionPAMC = Convert.ToInt32(Page.Request.QueryString[KEYPAMCAGRUPACION]);

			oPAMCDetalleAgrupacionBE.IdEstado = Convert.ToInt32(Enumerados.EstadoGeneral.Activo);
			oPAMCDetalleAgrupacionBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.EstadoGeneral);

			if(txtNroExposicion.Text != String.Empty)
				oPAMCDetalleAgrupacionBE.NroExposicion = NullableInt32.Parse(txtNroExposicion.Text);

			if(ddlCentroOperativo.SelectedValue != Utilitario.Constantes.VALORSELECCIONAR)
				oPAMCDetalleAgrupacionBE.IdCentroOperativo = Convert.ToInt32(ddlCentroOperativo.SelectedValue);

			oPAMCDetalleAgrupacionBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();

			if(txtSituacionActual.Text !=String.Empty)
				oPAMCDetalleAgrupacionBE.SituacionActual = NullableString.Parse(txtSituacionActual.Text);

			oPAMCDetalleAgrupacionBE.Nombre = txtNombre.Text;
			
			if(txtObservaciones.Text !=String.Empty)
				oPAMCDetalleAgrupacionBE.Observaciones = NullableString.Parse(txtObservaciones.Text);

			string strFilename;
			string[] res;
			int i;

			if(filMyFile.Value!=String.Empty)
			{
				strFilename = filMyFile.PostedFile.FileName;
				res = strFilename.Split('\\');
				i=res.GetUpperBound(Utilitario.Constantes.ValorConstanteCero);
				strFilename = res[i];

				oPAMCDetalleAgrupacionBE.RutaPDF = strFilename;
			}

			CMantenimientos oCMantenimientos = new CMantenimientos();
			int retorno = oCMantenimientos.Insertar(oPAMCDetalleAgrupacionBE);	

			if(retorno>=Utilitario.Constantes.ValorConstanteCero)
			{
				if(filMyFile.Value !=String.Empty)
					GuardarDocumento();
				
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Enumerados.NombresdeModulo.GestiónComercial.ToString() ,this.ToString(), "Se registro un Detalle de Agrupacion" + retorno.ToString() + Utilitario.Constantes.SIMBOLOPUNTO,Enumerados.NivelesErrorLog.I.ToString()));
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

			PAMCDetalleAgrupacionBE oPAMCDetalleAgrupacionBE 
				= new PAMCDetalleAgrupacionBE();


			if(txtDescripcion.Text !=String.Empty)
				oPAMCDetalleAgrupacionBE.Descripcion = NullableString.Parse(txtDescripcion.Text);
			
			oPAMCDetalleAgrupacionBE.FechaRegistro = DateTime.Now;

			oPAMCDetalleAgrupacionBE.IdAgrupacionPAMC = Convert.ToInt32(Page.Request.QueryString[KEYPAMCAGRUPACION]);

			if(txtNroExposicion.Text != String.Empty)
				oPAMCDetalleAgrupacionBE.NroExposicion = NullableInt32.Parse(txtNroExposicion.Text);

			oPAMCDetalleAgrupacionBE.IdEstado = Convert.ToInt32(Enumerados.EstadoGeneral.Activo);
			oPAMCDetalleAgrupacionBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.EstadoGeneral);

			if(ddlCentroOperativo.SelectedValue != Utilitario.Constantes.VALORSELECCIONAR)
				oPAMCDetalleAgrupacionBE.IdCentroOperativo = Convert.ToInt32(ddlCentroOperativo.SelectedValue);

			if(txtSituacionActual.Text !=String.Empty)
				oPAMCDetalleAgrupacionBE.SituacionActual = NullableString.Parse(txtSituacionActual.Text);

			oPAMCDetalleAgrupacionBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();
			
			oPAMCDetalleAgrupacionBE.Nombre = txtNombre.Text;
			
			if(txtObservaciones.Text !=String.Empty)
				oPAMCDetalleAgrupacionBE.Observaciones = NullableString.Parse(txtObservaciones.Text);

			string strFilename;
			string[] res;
			int i;

			if(filMyFile.Value!=String.Empty)
			{
				strFilename = filMyFile.PostedFile.FileName;
				res = strFilename.Split('\\');
				i=res.GetUpperBound(Utilitario.Constantes.ValorConstanteCero);
				strFilename = res[i];

				oPAMCDetalleAgrupacionBE.RutaPDF = strFilename;
			}

			oPAMCDetalleAgrupacionBE.IdDetalleAgrupacionPAMC = Convert.ToInt32(Page.Request.QueryString[KEYPAMCDETALLEAGRUPACION]);

			CMantenimientos oCMantenimientos = new CMantenimientos();
			int retorno = oCMantenimientos.Modificar(oPAMCDetalleAgrupacionBE);	

			if(retorno>=Utilitario.Constantes.ValorConstanteCero)
			{
				if(filMyFile.Value !=String.Empty)
					GuardarDocumento();
				
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Enumerados.NombresdeModulo.GestiónComercial.ToString() ,this.ToString(), "Se modifico un Detalle de Agrupacion" + retorno.ToString() + Utilitario.Constantes.SIMBOLOPUNTO,Enumerados.NivelesErrorLog.I.ToString()));
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
			PAMCDetalleAgrupacionBE oPAMCDetalleAgrupacionBE = (PAMCDetalleAgrupacionBE)oCMantenimientos.ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYPAMCDETALLEAGRUPACION]),Enumerados.ClasesNTAD.PAMCDetalleAgrupacionNTAD.ToString());

			txtNombre.Text = oPAMCDetalleAgrupacionBE.Nombre.ToString();
			
			txtDescripcion.Text = oPAMCDetalleAgrupacionBE.Descripcion.ToString();

			txtObservaciones.Text = oPAMCDetalleAgrupacionBE.Observaciones.ToString();

			txtSituacionActual.Text = oPAMCDetalleAgrupacionBE.SituacionActual.ToString();

			if(!oPAMCDetalleAgrupacionBE.IdCentroOperativo.IsNull)
				ddlCentroOperativo.SelectedValue = oPAMCDetalleAgrupacionBE.IdCentroOperativo.ToString();

			if(!oPAMCDetalleAgrupacionBE.RutaPDF.IsNull)
				hFila.Value =oPAMCDetalleAgrupacionBE.RutaPDF.ToString();

			txtNroExposicion.Text = oPAMCDetalleAgrupacionBE.NroExposicion.ToString();
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
			CCentroOperativo oCCentroOperativo = new CCentroOperativo();
			ddlCentroOperativo.DataSource = oCCentroOperativo.ListarTodosCombo();
			ddlCentroOperativo.DataValueField = "IDCENTROOPERATIVO";
			ddlCentroOperativo.DataTextField = "SIGLA1";
			ddlCentroOperativo.DataBind();
			
			ListItem oListItem=new ListItem(
				Utilitario.Constantes.TEXTOSSELECCIONAR,Utilitario.Constantes.VALORSELECCIONAR);

			ddlCentroOperativo.Items.Insert(0,oListItem);
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
