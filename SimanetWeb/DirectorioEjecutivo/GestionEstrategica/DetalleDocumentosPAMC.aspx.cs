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

	public class DetalleDocumentosPAMC : System.Web.UI.Page , IPaginaBase, IPaginaMantenimento
	{
		#region Controles
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.DropDownList ddlTipoDocumento;
		protected System.Web.UI.WebControls.TextBox txtNombreDocumento;
		protected System.Web.UI.WebControls.Label lblNombreDocumento;
		protected System.Web.UI.WebControls.Label lblTituloDocumentos;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvNombre;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary vSum;
		protected System.Web.UI.WebControls.Label lblRuta;
		protected System.Web.UI.WebControls.Label lblTipoDocumento;
		protected System.Web.UI.HtmlControls.HtmlInputFile filMyFile;
		protected System.Web.UI.WebControls.Label lblDescripcion;
		protected System.Web.UI.WebControls.Label lblObservaciones;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.TextBox txtObservaciones;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hFoto;
		#endregion

		#region Constantes
		const string MENSAJECONSULTAR = "SE INGRESO A DETALLE DOCUMENTOS";
		const int IDTABLATIPODOCUMENTO = 404;

		const string KEYPAMCNIVEL="KEYPAMCNIVEL";
		const string KEYPAMCNOMBRENIVEL="KEYPAMCNOMBRENIVEL";
		const string KEYPAMCDOCUMENTONIVEL = "KEYPAMCDOCUMENTONIVEL";
		const string KEYPAMCNOMBREDOCUMENTONIVEL= "KEYPAMCNOMBREDOCUMENTONIVEL";

		
		const int TAMANOARCHIVO=5000000;
		const string SiglaProyecto="EST";
		const string FORMATOCEROS="000000";
		const string SeparadorExtencion = ".";
		#endregion

		#region Variables
		private string RutaImagenCarpetaProyecto = Helper.ObtenerRutaPDFs(Utilitario.Constantes.ProyectoRutaCarpetaArchivoProyectoAMC);
		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					this.LlenarCombos();
					this.CargarModoPagina();
					this.LlenarJScript();

					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo
						(CNetAccessControl.GetUserName(),
						Utilitario.Enumerados.NombresdeModulo.GestionEstratégica.ToString(),
						this.ToString(),MENSAJECONSULTAR,
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
			CPAMCDocumentosNivel oCPAMCDocumentosNivel = new CPAMCDocumentosNivel();
			PAMCDocumentosNivelBE oPAMCDocumentosNivelBE = new PAMCDocumentosNivelBE();

			if(txtDescripcion.Text != String.Empty)
                oPAMCDocumentosNivelBE.Descripcion = txtDescripcion.Text;

			if(txtObservaciones.Text!=String.Empty)
				oPAMCDocumentosNivelBE.Observaciones = txtObservaciones.Text;

			oPAMCDocumentosNivelBE.FechaRegistro = DateTime.Now;
			
			oPAMCDocumentosNivelBE.IdEstado = Convert.ToInt32(Enumerados.EstadoGeneral.Activo);
			oPAMCDocumentosNivelBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.EstadoGeneral);

			oPAMCDocumentosNivelBE.IdNivelPAMC = Convert.ToInt32
				(Page.Request.QueryString[KEYPAMCNIVEL].ToString());

			oPAMCDocumentosNivelBE.IdTablaTipoDocumento = IDTABLATIPODOCUMENTO;

			oPAMCDocumentosNivelBE.IdTipoDocumento = Convert.ToInt32(ddlTipoDocumento.SelectedValue);

			oPAMCDocumentosNivelBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();

			oPAMCDocumentosNivelBE.Nombre = txtNombreDocumento.Text;

			if(filMyFile.Value!=String.Empty)
			{
				string strFilename = filMyFile.PostedFile.FileName;
				string[] res = strFilename.Split('\\');
				int i=res.GetUpperBound(Utilitario.Constantes.ValorConstanteCero);
				strFilename = res[i];

				oPAMCDocumentosNivelBE.Ruta = strFilename;
			}

			CMantenimientos oCMantenimientos = new CMantenimientos();
			int retorno = oCMantenimientos.Insertar(oPAMCDocumentosNivelBE);	

			if(retorno>=Utilitario.Constantes.ValorConstanteCero)
			{
				GuardarDocumento();

				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Enumerados.NombresdeModulo.GestiónComercial.ToString() ,this.ToString(), "Se registro un Documento" + retorno.ToString() + Utilitario.Constantes.SIMBOLOPUNTO,Enumerados.NivelesErrorLog.I.ToString()));
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
			CPAMCDocumentosNivel oCPAMCDocumentosNivel = new CPAMCDocumentosNivel();
			PAMCDocumentosNivelBE oPAMCDocumentosNivelBE = new PAMCDocumentosNivelBE();

			if(txtDescripcion.Text != String.Empty)
				oPAMCDocumentosNivelBE.Descripcion = txtDescripcion.Text;

			if(txtObservaciones.Text!=String.Empty)
				oPAMCDocumentosNivelBE.Observaciones = txtObservaciones.Text;

			oPAMCDocumentosNivelBE.FechaActualizacion = DateTime.Now;

			oPAMCDocumentosNivelBE.IdEstado = Convert.ToInt32(Enumerados.EstadoGeneral.Activo);
			oPAMCDocumentosNivelBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.EstadoGeneral);

			oPAMCDocumentosNivelBE.IdNivelPAMC = Convert.ToInt32
				(Page.Request.QueryString[KEYPAMCNIVEL].ToString());

			oPAMCDocumentosNivelBE.IdDocumentosNivelPAMC = Convert.ToInt32
				(Page.Request.QueryString[KEYPAMCDOCUMENTONIVEL].ToString());

			oPAMCDocumentosNivelBE.IdTablaTipoDocumento = IDTABLATIPODOCUMENTO;

			oPAMCDocumentosNivelBE.IdTipoDocumento = Convert.ToInt32(ddlTipoDocumento.SelectedValue);

			oPAMCDocumentosNivelBE.IdUsuarioActualizacion = CNetAccessControl.GetIdUser();

			oPAMCDocumentosNivelBE.Nombre = txtNombreDocumento.Text;

			if(txtObservaciones.Text != String.Empty)
				oPAMCDocumentosNivelBE.Observaciones = txtObservaciones.Text;

			oPAMCDocumentosNivelBE.Ruta = filMyFile.Value;

			if(filMyFile.Value!=String.Empty)
			{
				string strFilename = filMyFile.PostedFile.FileName;
				string[] res = strFilename.Split('\\');
				int i=res.GetUpperBound(Utilitario.Constantes.ValorConstanteCero);
				strFilename = res[i];

				oPAMCDocumentosNivelBE.Ruta = strFilename;
			}
			else
				oPAMCDocumentosNivelBE.Ruta = hFoto.Value;

	
			CMantenimientos oCMantenimientos = new CMantenimientos();
			int retorno = oCMantenimientos.Modificar(oPAMCDocumentosNivelBE);	

			if(retorno>=Utilitario.Constantes.ValorConstanteCero)
			{
				if(filMyFile.Value!=String.Empty)
					GuardarDocumento();
				
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Enumerados.NombresdeModulo.GestiónComercial.ToString() ,this.ToString(), "Se registro un Nivel" + retorno.ToString() + Utilitario.Constantes.SIMBOLOPUNTO,Enumerados.NivelesErrorLog.I.ToString()));
				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionEstrategica.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONMODIFICARPROCESO)) + Utilitario.Constantes.HISTORIALATRAS;
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
			PAMCDocumentosNivelBE oPAMCDocumentosNivelBE = (PAMCDocumentosNivelBE)oCMantenimientos.ListarDetalle(
				Convert.ToInt32(Page.Request.QueryString[KEYPAMCDOCUMENTONIVEL]),Enumerados.ClasesNTAD.PAMCDocumentosNivelNTAD.ToString());

			if(oPAMCDocumentosNivelBE!=null)
			{
				txtNombreDocumento.Text = oPAMCDocumentosNivelBE.Nombre.ToString();
				txtDescripcion.Text = oPAMCDocumentosNivelBE.Descripcion.ToString();
				txtObservaciones.Text = oPAMCDocumentosNivelBE.Observaciones.ToString();
				ddlTipoDocumento.SelectedValue = oPAMCDocumentosNivelBE.IdTipoDocumento.ToString();
				hFoto.Value = oPAMCDocumentosNivelBE.Ruta.ToString();
			}
		}

		public void CargarModoConsulta()
		{
		}
		public bool ValidarCampos()
		{
			if(filMyFile.Value == String.Empty)
			{
				ltlMensaje.Text = Helper.MensajeAlert("Tiene que elegir un Archivo a Subir");
				return Utilitario.Constantes.VALORUNCHECKEDBOOL;
			}

			
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
			CTablaTablas oCTablaTablas = new CTablaTablas();
			ddlTipoDocumento.DataSource =  oCTablaTablas.ListaTodosCombo(404);
			ddlTipoDocumento.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlTipoDocumento.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlTipoDocumento.DataBind();
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
