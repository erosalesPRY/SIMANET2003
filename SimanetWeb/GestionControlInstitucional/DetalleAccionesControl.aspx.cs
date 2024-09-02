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
using System.IO;

namespace SIMA.SimaNetWeb.GestionControlInstitucional
{
	/// <summary>
	/// Summary description for DetalleRetenciones.
	/// </summary>
	public class DetalleAccionesControl : System.Web.UI.Page,IPaginaBase
	{
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblDatos;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvDescripcion;
		protected System.Web.UI.WebControls.Label lblConcepto;
		protected System.Web.UI.WebControls.TextBox txtObservacion;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvObservacion;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary vSum;
		protected System.Web.UI.WebControls.Label Label2;
		protected eWorld.UI.CalendarPopup CalFechaAccion;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.TextBox txtDocumento;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvDocumento;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.HtmlControls.HtmlInputFile filMyFile;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox txtOpinion;
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
			this.txtOpinion.TextChanged += new System.EventHandler(this.txtOpinion_TextChanged);
			this.ibtnAceptar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAceptar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region Constantes
		
		//Titulos 
		const string TITULOMODONUEVO = "NUEVA ACCION";
		const string TITULOMODOMODIFICAR = "ACCION";

		//Key Session y QueryString
		const string KEYQID = "Id";
		const string KEYQIDOBSERVACION = "IdObservacion";
		const string KEYQIDDOCUMENTOAUDITORIA = "IdDocumentoAuditoria";
	
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
			rfvDocumento.ErrorMessage = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACCIONCONTROLCAMPOREQUERIDODOCUMENTO);
			rfvDocumento.ToolTip = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACCIONCONTROLCAMPOREQUERIDODOCUMENTO);

			rfvDescripcion.ErrorMessage = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACCIONCONTROLCAMPOREQUERIDODESCRIPCION);
			rfvDescripcion.ToolTip = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACCIONCONTROLCAMPOREQUERIDODESCRIPCION);

			rfvObservacion.ErrorMessage = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACCIONCONTROLCAMPOREQUERIDOOBSERVACION);
			rfvObservacion.ToolTip = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACCIONCONTROLCAMPOREQUERIDOOBSERVACION);

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
			AccionesTomadasBE oAccionesTomadasBE = new AccionesTomadasBE();

			oAccionesTomadasBE.IdObservacionAuditoria  = Convert.ToInt32(Page.Request.QueryString[KEYQIDOBSERVACION]);
			oAccionesTomadasBE.Documento = txtDocumento.Text;
			oAccionesTomadasBE.FechaAccion = Convert.ToDateTime(CalFechaAccion.SelectedDate);
			oAccionesTomadasBE.DescripcionAccion = txtDescripcion.Text;
			oAccionesTomadasBE.ObservacionAccion = txtObservacion.Text;
			oAccionesTomadasBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.AccionTomada);
			oAccionesTomadasBE.IdEstado = Convert.ToInt32(Enumerados.EstadosAccionesTomadas.Activo);
			oAccionesTomadasBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();
			if(txtOpinion.Text!=String.Empty)
			{
				oAccionesTomadasBE.Opinion=txtOpinion.Text;
			}

			if( filMyFile.PostedFile != null )
			{
				HttpPostedFile myFile = filMyFile.PostedFile;

				int nFileLen = myFile.ContentLength; 
				
				// make sure the size of the file is > 0
				if( nFileLen > 0 )
				{
					if(nFileLen <= 5000000)
					{	
						byte[] myData = new byte[nFileLen];

						myFile.InputStream.Read(myData, 0, nFileLen);
						
						
						string path = Helper.ObtenerRutaPDFs(Utilitario.Constantes.RUTAUPLOAD);//Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.RUTAUPLOAD);
						//--string path = "C:/codigogenerado2/";
							//-Helper.ObtenerRutaPDFs(Utilitario.Constantes.RUTAUPLOAD);

						string pathServer = Helper.ObtenerRutaPDFs(Utilitario.Constantes.RUTAUPLOADSERVER);//Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.RUTAUPLOADSERVER);
						//string pathServer = "C:/codigogenerado2/";
							//-Helper.ObtenerRutaPDFs(Utilitario.Constantes.RUTAUPLOADSERVER);

						string strFilename = myFile.FileName;

						string[] res = strFilename.Split('\\');
						int i=res.GetUpperBound(0);
						strFilename = res[i];
							
						// Write data into a file
						WriteToFile(path + strFilename,ref myData);	
						oAccionesTomadasBE.RutaArchivo=strFilename;

					}
				}
			}
		
			CMantenimientos oCMantenimientos = new CMantenimientos();

			int retorno = oCMantenimientos.Insertar(oAccionesTomadasBE);

			if(retorno>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"OCI",this.ToString(),"Se registró la Acción Nro. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));

				ltlMensaje.Text = Helper.MensajeRetornoAlert(
					Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionOCI.ToString()
					,Mensajes.CODIGOMENSAJECONFIRMACIONREGISTROACCIONOCI));
			}
		}

		public void Modificar()
		{
			AccionesTomadasBE oAccionesTomadasBE = new AccionesTomadasBE();

			oAccionesTomadasBE.IdAccionTomada  = Convert.ToInt32(Page.Request.QueryString[KEYQID]);
			oAccionesTomadasBE.Documento = txtDocumento.Text;
			oAccionesTomadasBE.FechaAccion = Convert.ToDateTime(CalFechaAccion.SelectedDate);
			oAccionesTomadasBE.DescripcionAccion = txtDescripcion.Text;
			oAccionesTomadasBE.ObservacionAccion = txtObservacion.Text;
			oAccionesTomadasBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.AccionTomada);
			oAccionesTomadasBE.IdEstado = Convert.ToInt32(Enumerados.EstadosAccionesTomadas.Activo);
			oAccionesTomadasBE.IdUsuarioActualizacion = CNetAccessControl.GetIdUser();
			if(txtOpinion.Text!=String.Empty)
			{
				oAccionesTomadasBE.Opinion=txtOpinion.Text;
			}

			if( filMyFile.PostedFile != null )
			{
				HttpPostedFile myFile = filMyFile.PostedFile;

				int nFileLen = myFile.ContentLength; 
				
				// make sure the size of the file is > 0
				if( nFileLen > 0 )
				{
					if(nFileLen <= 5000000)
					{	
						byte[] myData = new byte[nFileLen];

						myFile.InputStream.Read(myData, 0, nFileLen);
						
						
						string path = Helper.ObtenerRutaPDFs(Utilitario.Constantes.RUTAUPLOAD);//Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.RUTAUPLOAD);
						//--string path = "C:/codigogenerado2/";
						//-Helper.ObtenerRutaPDFs(Utilitario.Constantes.RUTAUPLOAD);

						string pathServer = Helper.ObtenerRutaPDFs(Utilitario.Constantes.RUTAUPLOADSERVER);//Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.RUTAUPLOADSERVER);
						//string pathServer = "C:/codigogenerado2/";
						//-Helper.ObtenerRutaPDFs(Utilitario.Constantes.RUTAUPLOADSERVER);

						string strFilename = myFile.FileName;

						string[] res = strFilename.Split('\\');
						int i=res.GetUpperBound(0);
						strFilename = res[i];
							
						// Write data into a file
						WriteToFile(path + strFilename,ref myData);	
						oAccionesTomadasBE.RutaArchivo=strFilename;

					}
				}
			}
			CMantenimientos oCMantenimientos = new CMantenimientos();
			if(oCMantenimientos.Modificar(oAccionesTomadasBE)>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"OCI",this.ToString(),"Se modificó la Acción Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

				ltlMensaje.Text = Helper.MensajeRetornoAlert(
					Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionOCI.ToString()
					,Mensajes.CODIGOMENSAJECONFIRMACIONMODIFICACIONACCIONOCI));
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
			AccionesTomadasBE oAccionesTomadasBE = (AccionesTomadasBE)oCMantenimientos.ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYQID]),Enumerados.ClasesNTAD.AccionesTomadasNTAD.ToString());
			
			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"OCI",this.ToString(),"Se consultó el Detalle de la Acción Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

			if(oAccionesTomadasBE!=null)
			{
				txtDocumento.Text = oAccionesTomadasBE.Documento.ToString();
				CalFechaAccion.SelectedDate = Convert.ToDateTime(oAccionesTomadasBE.FechaAccion.ToString());
				txtDescripcion.Text = oAccionesTomadasBE.DescripcionAccion.ToString();
				txtObservacion.Text = oAccionesTomadasBE.ObservacionAccion.ToString();
				if(!oAccionesTomadasBE.Opinion.IsNull)
				{
					txtOpinion.Text= Convert.ToString(oAccionesTomadasBE.Opinion);
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
			if(txtDocumento.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACCIONCONTROLCAMPOREQUERIDODOCUMENTO));
				return false;		
			}

			if(txtDescripcion.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACCIONCONTROLCAMPOREQUERIDODESCRIPCION));
				return false;		
			}

			if(txtObservacion.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEACCIONCONTROLCAMPOREQUERIDOOBSERVACION));
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
		private void WriteToFile(string strPath, ref byte[] Buffer)
		{
			// Create a file
			FileStream newFile = new FileStream(strPath,FileMode.Create);	
			

			// Write data to the file
			newFile.Write(Buffer, 0, Buffer.Length);

			// Close file
			newFile.Close();
		}

		private void txtOpinion_TextChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}