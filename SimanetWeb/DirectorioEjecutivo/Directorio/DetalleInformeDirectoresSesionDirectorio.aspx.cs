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
using System.IO;

namespace SIMA.SimaNetWeb.DirectorioEjecutivo.Directorio
{
	/// <summary>
	/// Summary description for RequerimientosAsignados.
	/// </summary>
	public class DetalleInformeDirectoresSesionDirectorio: System.Web.UI.Page,IPaginaBase//,IPaginaMantenimento
	{
		#region Controles

		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvDestino;
		protected eWorld.UI.NumericBox txtPorcentajeAvance2;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary vSum;
		protected System.Web.UI.WebControls.Label lblDetalle;
		protected System.Web.UI.WebControls.TextBox txtDetalle;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvDetalle;
		protected System.Web.UI.WebControls.Label lblNroInforme;
		protected System.Web.UI.WebControls.TextBox txtNumeroInforme;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvNroInforme;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
	
		#endregion Controles

		#region Constantes
		
		//Titulos 
		const string TITULOMODONUEVO = "NUEVO INFORME DE SESION DE DIRECTORIO";
		const string TITULOMODOMODIFICAR = "INFORME DE SESION DE DIRECTORIO";

		//Key Session y QueryString
		const string KEYQID = "Id";		
	
		//Paginas
		const string URLPRINCIPAL = "AdministracionInformeDirectoresSesionDirectorio.aspx";
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox txtReferencia;
		protected System.Web.UI.WebControls.Label lblArchivoAdjunto;
		protected System.Web.UI.HtmlControls.HtmlInputFile filMyFile;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hDocActa;
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

		public void LlenarCombos()
		{
			
			
		}

		public void LlenarDatos()
		{
			

			
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultaDeCartasFianzas.LlenarJScript implementation
			rfvNroInforme.ErrorMessage = Helper.ObtenerMensajesConfirmacionDirectorioUsuario(Mensajes.CODIGOMENSAJEINFORMEDIRECTORIOSESIONDIRECTORIOCAMPOREQUERIDONRO);
			rfvNroInforme.ToolTip = Helper.ObtenerMensajesConfirmacionDirectorioUsuario(Mensajes.CODIGOMENSAJEINFORMEDIRECTORIOSESIONDIRECTORIOCAMPOREQUERIDONRO);//rfvNroInforme.ErrorMessage;
			
			rfvDetalle.ErrorMessage = Helper.ObtenerMensajesConfirmacionDirectorioUsuario(Mensajes.CODIGOMENSAJEINFORMEDIRECTORIOSESIONDIRECTORIOCAMPOREQUERIDODETALLE);
			rfvDetalle.ToolTip = Helper.ObtenerMensajesConfirmacionDirectorioUsuario(Mensajes.CODIGOMENSAJEINFORMEDIRECTORIOSESIONDIRECTORIOCAMPOREQUERIDODETALLE);//rfvDetalle.ErrorMessage;
		
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

			InformeDirectoresSesionDirectorioBE oInformeDirectoresSesionDirectorioBE = new InformeDirectoresSesionDirectorioBE();
			oInformeDirectoresSesionDirectorioBE.NroInformeDirectoresSesionDire = txtNumeroInforme.Text;
			oInformeDirectoresSesionDirectorioBE.IdSesionDirectorio = Convert.ToInt32(Helper.RetornaSessionParaDirectorio());
			oInformeDirectoresSesionDirectorioBE.Detalle = txtDetalle.Text;
			oInformeDirectoresSesionDirectorioBE.ReferenciaInforme = txtReferencia.Text;
			oInformeDirectoresSesionDirectorioBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.SecretariaDirectorioEstadosInformeDirectoresSesionDirectorio);
			oInformeDirectoresSesionDirectorioBE.IdEstado = Convert.ToInt32(Enumerados.EstadosInformeDirectoresSesionDirectorio.Activo);
			oInformeDirectoresSesionDirectorioBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();

			if(filMyFile.PostedFile.FileName!=String.Empty)
			{
				//string pathServer = Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.RUTASERVERDOCUMENTOSDIRECTORIO);
				string strFilename = filMyFile.PostedFile.FileName;
				string[] res = strFilename.Split('\\');
				int i=res.GetUpperBound(0);
				strFilename = res[i];
							
				//oInformeDirectoresSesionDirectorioBE.Documento = pathServer + strFilename;
				oInformeDirectoresSesionDirectorioBE.Documento = strFilename;
			}

			CMantenimientos oCMantenimientos = new CMantenimientos();

			int retorno = oCMantenimientos.Insertar(oInformeDirectoresSesionDirectorioBE);

			if(retorno>0)
			{
				this.GuardarDocumento();
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Secretaria - Directorio",this.ToString(),"Se registró el Informe de Sesión de Directorio Nro. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));

				ltlMensaje.Text = Helper.MensajeRetornoAlert(
					Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionDirectorio.ToString()
					,Mensajes.CODIGOMENSAJECONFIRMACIONREGISTROINFORMEDIRECTORIOSESIONDIRECTORIO));
			}
		}

		public void Modificar()
		{
			InformeDirectoresSesionDirectorioBE oInformeDirectoresSesionDirectorioBE = new InformeDirectoresSesionDirectorioBE();
			oInformeDirectoresSesionDirectorioBE.IdInformeDirectoresSesionDirec = Convert.ToInt32(Page.Request.QueryString[KEYQID]);
			oInformeDirectoresSesionDirectorioBE.IdSesionDirectorio = Convert.ToInt32(Helper.RetornaSessionParaDirectorio());
			oInformeDirectoresSesionDirectorioBE.NroInformeDirectoresSesionDire = txtNumeroInforme.Text;
			oInformeDirectoresSesionDirectorioBE.Detalle = txtDetalle.Text;
			oInformeDirectoresSesionDirectorioBE.ReferenciaInforme = txtReferencia.Text;
			oInformeDirectoresSesionDirectorioBE.IdUsuarioActualizacion = CNetAccessControl.GetIdUser();

			if(filMyFile.Value!=String.Empty)
			{
				//string pathServer = Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.RUTASERVERDOCUMENTOSDIRECTORIO);
				string strFilename = filMyFile.PostedFile.FileName;
				string[] res = strFilename.Split('\\');
				int i=res.GetUpperBound(0);
				strFilename = res[i];
							
				//oInformeDirectoresSesionDirectorioBE.Documento = pathServer + strFilename;
				oInformeDirectoresSesionDirectorioBE.Documento = strFilename;
			}
			else
			{
				if(hDocActa.Value!=String.Empty)  
				{
					oInformeDirectoresSesionDirectorioBE.Documento= hDocActa.Value;
				}
			}

			CMantenimientos oCMantenimientos = new CMantenimientos();

			int retorno = oCMantenimientos.Modificar(oInformeDirectoresSesionDirectorioBE);

			if(retorno>0)
			{
				this.GuardarDocumento();
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Secretaria - Directorio",this.ToString(),"Se modificó la Sesión de Directorio Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

				ltlMensaje.Text = Helper.MensajeRetornoAlert(
					Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionDirectorio.ToString()
					,Mensajes.CODIGOMENSAJECONFIRMACIONMODIFICACIONINFORMEDIRECTORIOSESIONDIRECTORIO));
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
			
		}

		public void CargarModoModificar()
		{
			lblTitulo.Text = TITULOMODOMODIFICAR;
						
			CMantenimientos	oCMantenimientos = new CMantenimientos();
			InformeDirectoresSesionDirectorioBE oInformeDirectoresSesionDirectorioBE = (InformeDirectoresSesionDirectorioBE)oCMantenimientos.ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYQID]),Enumerados.ClasesNTAD.InformeDirectoresSesionDirectorioNTAD.ToString());
			
			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Secretaria - Directorio",this.ToString(),"Se consultó el Detalle de la Sesión de Directorio Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

			if(oInformeDirectoresSesionDirectorioBE!=null)
			{
				
				txtDetalle.Text = oInformeDirectoresSesionDirectorioBE.Detalle;
				txtNumeroInforme.Text = oInformeDirectoresSesionDirectorioBE.NroInformeDirectoresSesionDire;

				if(!oInformeDirectoresSesionDirectorioBE.ReferenciaInforme.IsNull)
				{
					txtReferencia.Text = oInformeDirectoresSesionDirectorioBE.ReferenciaInforme.ToString();
				}

				if(!oInformeDirectoresSesionDirectorioBE.Documento.IsNull)
				{
					hDocActa.Value = oInformeDirectoresSesionDirectorioBE.Documento.ToString();
				}

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
			if(txtNumeroInforme.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionDirectorioUsuario(Mensajes.CODIGOMENSAJEINFORMEDIRECTORIOSESIONDIRECTORIOCAMPOREQUERIDONRO));
				return false;		
			}

			
			if(txtDetalle.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionDirectorioUsuario(Mensajes.CODIGOMENSAJEINFORMEDIRECTORIOSESIONDIRECTORIOCAMPOREQUERIDODETALLE));
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

		public void GuardarDocumento() 
		{
			HttpPostedFile myFile = filMyFile.PostedFile;
			int nFileLen = myFile.ContentLength; 
					
			if( nFileLen > 0 )
			{
				if(nFileLen <= 5000000)
				{	
					byte[] myData = new byte[nFileLen];

					myFile.InputStream.Read(myData, 0, nFileLen);
					//string path = Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.RUTADOCUMENTOSDIRECTORIO);
					string path = Helper.ObtenerRutaImagenes(Constantes.RUTADOCUMENTOSDIRECTORIO);															
					string strFilename = myFile.FileName;

					string[] res = strFilename.Split('\\');
					int i=res.GetUpperBound(0);
					strFilename = res[i];
							
					// Write data into a file
					WriteToFile(path + strFilename,ref myData);					
				}
			}		
		}	

		private void WriteToFile(string strPath, ref byte[] Buffer)
		{
			// Create a file
			FileStream newFile = new FileStream(strPath,FileMode.Create);	

			// Write data to the file
			newFile.Write(Buffer, 0, Buffer.Length);

			// Close file
			newFile.Close();
		}
	}
}

