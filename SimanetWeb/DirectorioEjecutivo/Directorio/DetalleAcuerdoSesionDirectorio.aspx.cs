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
	public class DetalleAcuerdoSesionDirectorio: System.Web.UI.Page,IPaginaBase//,IPaginaMantenimento
	{
		#region Controles

		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvDestino;
		protected eWorld.UI.NumericBox txtPorcentajeAvance2;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary vSum;
		protected System.Web.UI.WebControls.Label lblNroAcuerdo;
		protected System.Web.UI.WebControls.TextBox txtNumeroAcuerdo;
		protected System.Web.UI.WebControls.TextBox txtTema;
		protected System.Web.UI.WebControls.Label lblTema;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvNroAcuerdo;
		protected System.Web.UI.WebControls.Label lblSituacion;
		protected System.Web.UI.WebControls.DropDownList ddlbSituacion;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvTema;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvSituacion;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox txtAcuerdo;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvAcuerdo;
		
		#endregion Controles

		#region Constantes
		
		//Titulos 
		const string TITULOMODONUEVO = "NUEVO ACUERDO DE SESION DE DIRECTORIO";
		const string TITULOMODOMODIFICAR = "ACUERDO DE SESION DE DIRECTORIO";

		//Key Session y QueryString
		const string KEYQID = "Id";
		const string KEYQIDSESIONDIRECTORIO = "IdSesionDirectorio";
		const string KEYQIDCENTROOPERATIVO = "IdCentroOperativo";
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.DropDownList ddlbCentroOperativo;

		//Paginas
		const string URLPRINCIPAL = "AdministracionAcuerdoSesionDirectorio.aspx?";
		protected System.Web.UI.WebControls.Label lblFecha;
		protected eWorld.UI.CalendarPopup CalFecha;
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
			this.llenarSituacion();
			this.llenarCentroOperativo();
		}

		private void llenarCentroOperativo()
		{
			CCentroOperativo oCCentroOperativo = new CCentroOperativo();
			ddlbCentroOperativo.DataSource = oCCentroOperativo.ListarTodosCombo();
			ddlbCentroOperativo.DataValueField=Enumerados.ColumnasCentroOperativo.IdCentroOperativo.ToString();
			ddlbCentroOperativo.DataTextField=Enumerados.ColumnasCentroOperativo.Sigla1.ToString();
			ddlbCentroOperativo.DataBind();
		}

		public void LlenarDatos()
		{
			

			
		}

		public void LlenarJScript()
		{
			rfvNroAcuerdo.ErrorMessage = Helper.ObtenerMensajesConfirmacionDirectorioUsuario(Mensajes.CODIGOMENSAJEACUERDOSESIONDIRECTORIOCAMPOREQUERIDONRO);
			rfvNroAcuerdo.ToolTip = rfvNroAcuerdo.ErrorMessage;

			rfvTema.ErrorMessage = Helper.ObtenerMensajesConfirmacionDirectorioUsuario(Mensajes.CODIGOMENSAJEACUERDOSESIONDIRECTORIOCAMPOREQUERIDOTEMA);
			rfvTema.ToolTip = rfvTema.ErrorMessage;

			rfvSituacion.ErrorMessage = Helper.ObtenerMensajesConfirmacionDirectorioUsuario(Mensajes.CODIGOMENSAJEACUERDOSESIONDIRECTORIOCAMPOREQUERIDOSITUACION);
			rfvSituacion.ToolTip = rfvSituacion.ErrorMessage;

			rfvAcuerdo.ErrorMessage = Helper.ObtenerMensajesConfirmacionDirectorioUsuario(Mensajes.CODIGOMENSAJEACUERDOSESIONDIRECTORIOACUERDOREQUERIDO);//"Ingrese Acuerdo";
			rfvAcuerdo.ToolTip = Helper.ObtenerMensajesConfirmacionDirectorioUsuario(Mensajes.CODIGOMENSAJEACUERDOSESIONDIRECTORIOACUERDOREQUERIDO); //"Ingrese Acuerdo";
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

		/// <summary>
		/// Llena el combo de Estados de Proyectos
		/// </summary>
		private void llenarSituacion()
		{
			ListItem lItem = new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,Utilitario.Constantes.VALORSELECCIONAR);
			CTablaTablas oCTablaTablas =  new CTablaTablas();
			ddlbSituacion.DataSource = oCTablaTablas.ListarTodosComboDirectorio(Convert.ToInt32(Enumerados.TablasTabla.SecretariaDirectorioSituacionAcuerdoSesionDirectorio));
			ddlbSituacion.DataValueField=Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbSituacion.DataTextField=Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbSituacion.DataBind();
			ddlbSituacion.Items.Insert(0,lItem);

			
		}

		public void Agregar()
		{

			AcuerdoSesionDirectorioBE oAcuerdoSesionDirectorioBE = new AcuerdoSesionDirectorioBE();
			oAcuerdoSesionDirectorioBE.NroAcuerdoSesionDirectorio = txtNumeroAcuerdo.Text;
			oAcuerdoSesionDirectorioBE.IdSesionDirectorio = Convert.ToInt32(Helper.RetornaSessionParaDirectorio());
			oAcuerdoSesionDirectorioBE.IdCentroOperativo = Convert.ToInt32(ddlbCentroOperativo.SelectedValue);
			oAcuerdoSesionDirectorioBE.Acuerdo = txtAcuerdo.Text;

			if(CalFecha.SelectedDate.ToString() != Constantes.FECHAVALORENBLANCO)
			{ 
				oAcuerdoSesionDirectorioBE.FechaAcuerdo = Convert.ToDateTime(CalFecha.SelectedDate);	
			}

			oAcuerdoSesionDirectorioBE.Tema = txtTema.Text;
			oAcuerdoSesionDirectorioBE.IdTablaSituacion = Convert.ToInt32(Enumerados.TablasTabla.SecretariaDirectorioSituacionAcuerdoSesionDirectorio);
			oAcuerdoSesionDirectorioBE.IdSituacion = Convert.ToInt32(ddlbSituacion.SelectedValue);
			oAcuerdoSesionDirectorioBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.SecretariaDirectorioEstadosAcuerdoSesionDirectorio);
			oAcuerdoSesionDirectorioBE.IdEstado = Convert.ToInt32(Enumerados.EstadosAcuerdoSesionDirectorio.Activo);
			oAcuerdoSesionDirectorioBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();

			if(filMyFile.PostedFile.FileName!=String.Empty)
			{
				//string pathServer = Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.RUTASERVERDOCUMENTOSDIRECTORIO);
				string strFilename = filMyFile.PostedFile.FileName;
				string[] res = strFilename.Split('\\');
				int i=res.GetUpperBound(0);
				strFilename = res[i];
							
				//oAcuerdoSesionDirectorioBE.Documento = pathServer + strFilename;
				oAcuerdoSesionDirectorioBE.Documento = strFilename;
			}

			CMantenimientos oCMantenimientos = new CMantenimientos();

			int retorno = oCMantenimientos.Insertar(oAcuerdoSesionDirectorioBE);

			if(retorno>0)
			{
				this.GuardarDocumento();
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Secretaria - Directorio",this.ToString(),"Se registró el Acuerdo de Directorio Nro. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));

				ltlMensaje.Text = Helper.MensajeRetornoAlert(
					Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionDirectorio.ToString()
					,Mensajes.CODIGOMENSAJECONFIRMACIONREGISTROACUERDOSESIONDIRECTORIO));
			}
		}

		public void Modificar()
		{
			AcuerdoSesionDirectorioBE oAcuerdoSesionDirectorioBE = new AcuerdoSesionDirectorioBE();
			oAcuerdoSesionDirectorioBE.IdAcuerdoSesionDirectorio = Convert.ToInt32(Page.Request.QueryString[KEYQID]);
			oAcuerdoSesionDirectorioBE.IdCentroOperativo = Convert.ToInt32(ddlbCentroOperativo.SelectedValue);
			oAcuerdoSesionDirectorioBE.IdSesionDirectorio = Convert.ToInt32(Helper.RetornaSessionParaDirectorio());
			oAcuerdoSesionDirectorioBE.NroAcuerdoSesionDirectorio = txtNumeroAcuerdo.Text;
			oAcuerdoSesionDirectorioBE.Tema = txtTema.Text;
			oAcuerdoSesionDirectorioBE.Acuerdo = txtAcuerdo.Text;

			if(CalFecha.SelectedDate.ToString() != Constantes.FECHAVALORENBLANCO)
			{
				oAcuerdoSesionDirectorioBE.FechaAcuerdo = Convert.ToDateTime(CalFecha.SelectedDate);	
			}

			if(filMyFile.Value!=String.Empty)
			{
				//string pathServer = Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.RUTASERVERDOCUMENTOSDIRECTORIO);
				string strFilename = filMyFile.PostedFile.FileName;
				string[] res = strFilename.Split('\\');
				int i=res.GetUpperBound(0);
				strFilename = res[i];
							
				//oAcuerdoSesionDirectorioBE.Documento = pathServer + strFilename;
				oAcuerdoSesionDirectorioBE.Documento = strFilename;
			}
			else
			{
				if(hDocActa.Value!=String.Empty)  
				{
					oAcuerdoSesionDirectorioBE.Documento= hDocActa.Value;
				}
			}

			oAcuerdoSesionDirectorioBE.IdSituacion = Convert.ToInt32(ddlbSituacion.SelectedValue);
			oAcuerdoSesionDirectorioBE.IdUsuarioActualizacion = CNetAccessControl.GetIdUser();

			CMantenimientos oCMantenimientos = new CMantenimientos();

			int retorno = oCMantenimientos.Modificar(oAcuerdoSesionDirectorioBE);

			if(retorno>0)
			{
				this.GuardarDocumento();

				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Secretaria - Directorio",this.ToString(),"Se modificó el Acuerdo de Directorio Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

				ltlMensaje.Text = Helper.MensajeRetornoAlert(
					Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionDirectorio.ToString()
					,Mensajes.CODIGOMENSAJECONFIRMACIONMODIFICACIONACTASESIONDIRECTORIO));
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
			lblTitulo.Text = TITULOMODOMODIFICAR;
			this.LlenarCombos();
						
			CMantenimientos	oCMantenimientos = new CMantenimientos();
			AcuerdoSesionDirectorioBE oAcuerdoSesionDirectorioBE = (AcuerdoSesionDirectorioBE)oCMantenimientos.ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYQID]),Enumerados.ClasesNTAD.AcuerdoSesionDirectorioNTAD.ToString());
			
			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Secretaria - Directorio",this.ToString(),"Se consultó el Detalle del Acuerdo de Sesión de Directorio Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

			if(oAcuerdoSesionDirectorioBE!=null)
			{
				txtTema.Text = oAcuerdoSesionDirectorioBE.Tema;
				txtAcuerdo.Text = oAcuerdoSesionDirectorioBE.Acuerdo;
				txtNumeroAcuerdo.Text = oAcuerdoSesionDirectorioBE.NroAcuerdoSesionDirectorio;

				ListItem lItem = ddlbSituacion.Items.FindByValue(oAcuerdoSesionDirectorioBE.IdSituacion.ToString());
				if(lItem!=null){lItem.Selected = true;}

				lItem = ddlbCentroOperativo.Items.FindByValue(oAcuerdoSesionDirectorioBE.IdCentroOperativo.ToString());			
				if(lItem!=null){lItem.Selected = true;}

				if(oAcuerdoSesionDirectorioBE.FechaAcuerdo.ToString() != Constantes.FECHAVALORENBLANCO)
				{
					CalFecha.SelectedDate = Convert.ToDateTime(oAcuerdoSesionDirectorioBE.FechaAcuerdo);
				}

				if(!oAcuerdoSesionDirectorioBE.Documento.IsNull)
				{
					hDocActa.Value = oAcuerdoSesionDirectorioBE.Documento.ToString();
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
			if(txtNumeroAcuerdo.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionDirectorioUsuario(Mensajes.CODIGOMENSAJEACUERDOSESIONDIRECTORIOCAMPOREQUERIDONRO));
				return false;		
			}

			if(ddlbSituacion.SelectedItem.Text == Utilitario.Constantes.TEXTOSSELECCIONAR)
			{
				ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionDirectorioUsuario(Mensajes.CODIGOMENSAJEACUERDOSESIONDIRECTORIOCAMPOREQUERIDOSITUACION));
				return false;		
			}

			if(txtTema.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionDirectorioUsuario(Mensajes.CODIGOMENSAJEACUERDOSESIONDIRECTORIOCAMPOREQUERIDOTEMA));
				return false;		
			}

			if(txtAcuerdo.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionDirectorioUsuario(Mensajes.CODIGOMENSAJEACUERDOSESIONDIRECTORIOACUERDOREQUERIDO));
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
			Page.Response.Redirect(URLPRINCIPAL+ KEYQIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQIDCENTROOPERATIVO]);
		}


		private void ibtnCancelar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.redireccionaPaginaPrincipal();
		}

		private void ddlbArea_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
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

