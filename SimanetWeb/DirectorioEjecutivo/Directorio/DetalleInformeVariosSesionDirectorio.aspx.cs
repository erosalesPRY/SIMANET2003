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
	public class DetalleInformeVariosSesionDirectorio: System.Web.UI.Page,IPaginaBase//,IPaginaMantenimento
	{
		#region Controles

		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvDestino;
		protected eWorld.UI.NumericBox txtPorcentajeAvance2;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary vSum;
		protected System.Web.UI.WebControls.Label lblTema;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvTema;
		protected System.Web.UI.WebControls.TextBox txtTema;
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
		const string URLPRINCIPAL = "AdministracionInformeVariosSesionDirectorio.aspx";
		protected System.Web.UI.WebControls.Label lblArchivoAdjunto;
		protected System.Web.UI.HtmlControls.HtmlInputFile filMyFile;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hDocActa;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.HtmlControls.HtmlInputFile filMyFile2;
		protected System.Web.UI.HtmlControls.HtmlInputFile filMyFile3;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hDocActa2;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hDocActa3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.DropDownList ddlbTipo;
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
			this.llenarTipos();	
		}

		public void LlenarDatos()
		{
			
		}

		private void llenarTipos()
		{
			CTablaTablas oCTablaTablas =  new CTablaTablas();
			ddlbTipo.DataSource = oCTablaTablas.ListarTodosComboDirectorio(Convert.ToInt32(Enumerados.TablasTabla.SecretariaDirectorioTablaTipoInformeVarios));
			ddlbTipo.DataValueField=Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbTipo.DataTextField=Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbTipo.DataBind();
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultaDeCartasFianzas.LlenarJScript implementation
			

			rfvTema.ErrorMessage = Helper.ObtenerMensajesConfirmacionDirectorioUsuario(Mensajes.CODIGOMENSAJEINFORMEVARIOSSESIONDIRECTORIOCAMPOREQUERIDOTEMA);
			rfvTema.ToolTip = Helper.ObtenerMensajesConfirmacionDirectorioUsuario(Mensajes.CODIGOMENSAJEINFORMEVARIOSSESIONDIRECTORIOCAMPOREQUERIDOTEMA);//rfvTema.ErrorMessage;

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

			InformeVariosSesionDirectoBE oInformeVariosSesionDirectoBE= new InformeVariosSesionDirectoBE();
			oInformeVariosSesionDirectoBE.IdSesionDirectorio = Convert.ToInt32(Helper.RetornaSessionParaDirectorio());
			oInformeVariosSesionDirectoBE.Tema = txtTema.Text;
			oInformeVariosSesionDirectoBE.IdTablaTipoInforme = Convert.ToInt32(Enumerados.TablasTabla.SecretariaDirectorioTablaTipoInformeVarios);
			oInformeVariosSesionDirectoBE.IdTipoInforme = Convert.ToInt32(ddlbTipo.SelectedValue);

			//oInformeVariosSesionDirectoBE.Detalle = txtDetalle.Text;
			//oInformeVariosSesionDirectoBE.Fecha = CalFecha.SelectedDate;
			oInformeVariosSesionDirectoBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.SecretariaDirectorioEstadosInformeVariosDirectorio);
			oInformeVariosSesionDirectoBE.IdEstado = Convert.ToInt32(Enumerados.EstadosInformeVariosSesionDirectorio .Activo);
			oInformeVariosSesionDirectoBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();

			if(filMyFile.PostedFile.FileName!=String.Empty)
			{oInformeVariosSesionDirectoBE.Documento = Helper.ObtenerNombreArchivo(filMyFile);}

			if(filMyFile2.PostedFile.FileName!=String.Empty)
			{oInformeVariosSesionDirectoBE.Documento2 = Helper.ObtenerNombreArchivo(filMyFile2);}

			if(filMyFile3.PostedFile.FileName!=String.Empty)
			{oInformeVariosSesionDirectoBE.Documento3 = Helper.ObtenerNombreArchivo(filMyFile3);}

			CMantenimientos oCMantenimientos = new CMantenimientos();

			int retorno = oCMantenimientos.Insertar(oInformeVariosSesionDirectoBE);

			if(retorno>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Secretaria - Directorio",this.ToString(),"Se registró el Informe de Sesión de Directorio Nro. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));

				Helper.GuardarDocumento((HttpPostedFile)filMyFile.PostedFile);
				Helper.GuardarDocumento((HttpPostedFile)filMyFile2.PostedFile);
				Helper.GuardarDocumento((HttpPostedFile)filMyFile3.PostedFile);

				ltlMensaje.Text = Helper.MensajeRetornoAlert(
					Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionDirectorio.ToString()
					,Mensajes.CODIGOMENSAJECONFIRMACIONREGISTROINFORMEVARIOSSESIONDIRECTORIO));
			}
		}

		public void Modificar()
		{
			InformeVariosSesionDirectoBE oInformeVariosSesionDirectoBE = new InformeVariosSesionDirectoBE();
			oInformeVariosSesionDirectoBE.IdInformeVariosSesionDirecto = Convert.ToInt32(Page.Request.QueryString[KEYQID]);
			oInformeVariosSesionDirectoBE.IdSesionDirectorio = Convert.ToInt32(Helper.RetornaSessionParaDirectorio());
			oInformeVariosSesionDirectoBE.Tema = txtTema.Text;
			oInformeVariosSesionDirectoBE.IdTablaTipoInforme = Convert.ToInt32(Enumerados.TablasTabla.SecretariaDirectorioTablaTipoInformeVarios);
			oInformeVariosSesionDirectoBE.IdTipoInforme = Convert.ToInt32(ddlbTipo.SelectedValue);

			/*oInformeVariosSesionDirectoBE.Fecha = CalFecha.SelectedDate;
			oInformeVariosSesionDirectoBE.Detalle = txtDetalle.Text;*/
			oInformeVariosSesionDirectoBE.IdUsuarioActualizacion = CNetAccessControl.GetIdUser();

			if(filMyFile.Value!=String.Empty)
			{oInformeVariosSesionDirectoBE.Documento = Helper.ObtenerNombreArchivo(filMyFile);}
			else
			{
				if(hDocActa.Value!=String.Empty)  
				{oInformeVariosSesionDirectoBE.Documento = hDocActa.Value;}
			}

			if(filMyFile2.Value!=String.Empty)
			{oInformeVariosSesionDirectoBE.Documento2 = Helper.ObtenerNombreArchivo(filMyFile2);}
			else
			{
				if(hDocActa2.Value!=String.Empty)  
				{oInformeVariosSesionDirectoBE.Documento2 = hDocActa2.Value;}
			}

			if(filMyFile3.Value!=String.Empty)
			{oInformeVariosSesionDirectoBE.Documento3 = Helper.ObtenerNombreArchivo(filMyFile3);}
			else
			{
				if(hDocActa3.Value!=String.Empty)  
				{oInformeVariosSesionDirectoBE.Documento3 = hDocActa3.Value;}
			}

			/*if(filMyFile.Value!=String.Empty)
			{
				//string pathServer = Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.RUTASERVERDOCUMENTOSDIRECTORIO);
				string strFilename = filMyFile.PostedFile.FileName;
				string[] res = strFilename.Split('\\');
				int i=res.GetUpperBound(0);
				strFilename = res[i];
							
				//oInformeVariosSesionDirectoBE.Documento = pathServer + strFilename;
				oInformeVariosSesionDirectoBE.Documento = strFilename;
			}
			else
			{
				if(hDocActa.Value!=String.Empty)  
				{
					oInformeVariosSesionDirectoBE.Documento= hDocActa.Value;
				}
			}*/
			
			CMantenimientos oCMantenimientos = new CMantenimientos();

			int retorno = oCMantenimientos.Modificar(oInformeVariosSesionDirectoBE);

			if(retorno>0)
			{
				//this.GuardarDocumento();
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Secretaria - Directorio",this.ToString(),"Se modificó el Informe de Sesión de Directorio Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));
		
				Helper.GuardarDocumento((HttpPostedFile)filMyFile.PostedFile);
				Helper.GuardarDocumento((HttpPostedFile)filMyFile2.PostedFile);
				Helper.GuardarDocumento((HttpPostedFile)filMyFile3.PostedFile);

				ltlMensaje.Text = Helper.MensajeRetornoAlert(
					Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionDirectorio.ToString()
					,Mensajes.CODIGOMENSAJECONFIRMACIONMODIFICACIONINFORMEVARIOSSESIONDIRECTORIO));
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
			InformeVariosSesionDirectoBE oInformeVariosSesionDirectoBE = (InformeVariosSesionDirectoBE)oCMantenimientos.ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYQID]),Enumerados.ClasesNTAD.InformeVariosSesionDirectoNTAD.ToString());
			
			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Secretaria - Directorio",this.ToString(),"Se consultó el Detalle del Informe de Directorio Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

			if(oInformeVariosSesionDirectoBE!=null)
			{
				txtTema.Text = oInformeVariosSesionDirectoBE.Tema;
	
				ListItem lItem = ddlbTipo.Items.FindByValue(oInformeVariosSesionDirectoBE.IdTipoInforme.ToString());
				if(lItem!=null){lItem.Selected = true;}

				/*txtDetalle.Text = oInformeVariosSesionDirectoBE.Detalle.ToString();
				CalFecha.SelectedDate = oInformeVariosSesionDirectoBE.Fecha;
				CalFecha.VisibleDate = oInformeVariosSesionDirectoBE.Fecha;*/

				if(!oInformeVariosSesionDirectoBE.Documento.IsNull)
				{hDocActa.Value = oInformeVariosSesionDirectoBE.Documento.ToString();}

				if(!oInformeVariosSesionDirectoBE.Documento2.IsNull)
				{hDocActa2.Value = oInformeVariosSesionDirectoBE.Documento2.ToString();}

				if(!oInformeVariosSesionDirectoBE.Documento3.IsNull)
				{hDocActa3.Value = oInformeVariosSesionDirectoBE.Documento3.ToString();}
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
			if(txtTema.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionDirectorioUsuario(Mensajes.CODIGOMENSAJEINFORMEVARIOSSESIONDIRECTORIOCAMPOREQUERIDOTEMA));
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

		private void ddlbArea_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		/*public void GuardarDocumento() 
		{
			HttpPostedFile myFile = filMyFile.PostedFile;
			int nFileLen = myFile.ContentLength; 
					
			if( nFileLen > 0 )
			{
			//if(nFileLen <= 50000000)
			//{	
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
				//}
			}		
		}	*/

		/*private void WriteToFile(string strPath, ref byte[] Buffer)
		{
			// Create a file
			FileStream newFile = new FileStream(strPath,FileMode.Create);	

			// Write data to the file
			newFile.Write(Buffer, 0, Buffer.Length);

			// Close file
			newFile.Close();
		}*/

	}
}

