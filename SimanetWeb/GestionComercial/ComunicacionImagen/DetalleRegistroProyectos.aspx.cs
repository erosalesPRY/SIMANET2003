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
using SIMA.Controladoras.GestionComercial;
using SIMA.Controladoras.Proyectos;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using SIMA.EntidadesNegocio.GestionComercial;
using NetAccessControl;
using System.IO;
using NullableTypes;

namespace SIMA.SimaNetWeb.GestionComercial.ComunicacionImagen
{
	/// <summary>
	/// Summary description for DetalleRegistroProyectos.
	/// </summary>
	public class DetalleRegistroProyectos : System.Web.UI.Page, IPaginaBase, IPaginaMantenimento
	{
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
			RegistroProyectoCNBE oRegistroProyectoCNBE = new RegistroProyectoCNBE();
			
			oRegistroProyectoCNBE.Nombre = txtNombre.Text;
			oRegistroProyectoCNBE.IdHistorico = txtIdProyecto.Text;

			if (txtNroProyecto.Text != String.Empty)
				oRegistroProyectoCNBE.NroProyecto = NullableString.Parse(txtNroProyecto.Text);
			else
				oRegistroProyectoCNBE.NroProyecto = NullableString.Null;

		
				oRegistroProyectoCNBE.IdCentroOperativo = NullableInt32.Parse(ddlCentroOperativo.SelectedValue);
			
					
			if (txtMatricula.Text != String.Empty)
				oRegistroProyectoCNBE.Matricula=  txtMatricula.Text;
			else
				oRegistroProyectoCNBE.Matricula= NullableString.Null;
																

			if(hIdCliente.Value != String.Empty)
				oRegistroProyectoCNBE.IdCliente= NullableInt32.Parse(hIdCliente.Value);
			else
				oRegistroProyectoCNBE.IdCliente= NullableInt32.Null;
            	
			
			if(this.ddlTipoProducto.SelectedValue != Utilitario.Constantes.VALORSELECCIONAR)
			{		
				oRegistroProyectoCNBE.IdTipoProducto = NullableInt32.Parse(ddlTipoProducto.SelectedValue);
			}
			oRegistroProyectoCNBE.IdTablaTipoProducto = idTipoProducto;

			if(this.ddlTipoBuque.SelectedValue != Utilitario.Constantes.VALORSELECCIONAR)
			{	
				oRegistroProyectoCNBE.IdBuque  = NullableInt32.Parse(ddlTipoBuque.SelectedValue);
			}
			if (txtSubTipo.Text != String.Empty)
				oRegistroProyectoCNBE.SubTipoBuque = txtSubTipo.Text;
			else
				oRegistroProyectoCNBE.SubTipoBuque = NullableString.Null;
				
			if (txtClasificacion.Text != String.Empty)
				oRegistroProyectoCNBE.Clasificacion = txtClasificacion.Text; 
			else
				oRegistroProyectoCNBE.Clasificacion= NullableString.Null;
				
			if (txtDWT.Text != String.Empty)
				oRegistroProyectoCNBE.DWT = NullableString.Parse(txtDWT.Text);
			else
				oRegistroProyectoCNBE.DWT = NullableString.Null;
				
			if (txtLightship.Text != String.Empty)
				oRegistroProyectoCNBE.LightShip = NullableString.Parse(txtLightship.Text);
			else
				oRegistroProyectoCNBE.LightShip = NullableString.Null;

			if (txtDesplazamiento.Text != String.Empty)
				oRegistroProyectoCNBE.Desplazamiento = NullableString.Parse(txtDesplazamiento.Text);
			else
				oRegistroProyectoCNBE.Desplazamiento = NullableString.Null;

			if (txtCapBod.Text != String.Empty)
				oRegistroProyectoCNBE.CapBod =  txtCapBod.Text;
			else
				oRegistroProyectoCNBE.CapBod = NullableString.Null;

			if (txtEmpuje.Text != String.Empty)
				oRegistroProyectoCNBE.Empuje = txtEmpuje.Text;
			else
				oRegistroProyectoCNBE.Empuje =NullableString.Null;

			if (txtTonProcesadas.Text != String.Empty)
				oRegistroProyectoCNBE.TonProcesadas = txtTonProcesadas.Text;
			else
				oRegistroProyectoCNBE.TonProcesadas = NullableString.Null;

  
			if(this.ddlMaterailCasco.SelectedValue != Utilitario.Constantes.VALORSELECCIONAR)
			{	
				oRegistroProyectoCNBE.IdTipoMaterialCasco = NullableInt32.Parse( ddlMaterailCasco.SelectedValue);
			}
			oRegistroProyectoCNBE.IdTablaTipoMaterialCasco = idTipoMaterial;
				
			if (txtNroBodegas.Text != String.Empty)
				oRegistroProyectoCNBE.NroBodegas = txtNroBodegas.Text;
			else
				oRegistroProyectoCNBE.NroBodegas = NullableString.Null;
				
			if (txtNroTanques.Text != String.Empty)
				oRegistroProyectoCNBE.NroTanques =  txtNroTanques.Text;
			else
				oRegistroProyectoCNBE.NroTanques = NullableString.Null;

			if (txtNroContenedores.Text != String.Empty)
				oRegistroProyectoCNBE.NroContenedores = txtNroContenedores.Text;
			else
				oRegistroProyectoCNBE.NroContenedores = NullableString.Null;

			if(txtMotor.Text != String.Empty)				
				oRegistroProyectoCNBE.Motor = txtMotor.Text;
			else
				oRegistroProyectoCNBE.Motor =  NullableString.Null;

			if (txtModelo.Text !=String.Empty)
				oRegistroProyectoCNBE.Modelo = txtModelo.Text;
			else
				oRegistroProyectoCNBE.Modelo =  NullableString.Null;

			if(txtPotencia.Text != String.Empty)
				oRegistroProyectoCNBE.Potencia = txtPotencia.Text;
			else
				oRegistroProyectoCNBE.Potencia =  NullableString.Null;
			
			if (txtArboladura.Text != String.Empty)
				oRegistroProyectoCNBE.Arboladura = txtArboladura.Text;
			else
				oRegistroProyectoCNBE.Arboladura = NullableString.Null;

			if (txtEslora.Text != String.Empty)
				oRegistroProyectoCNBE.Eslora =   NullableDouble.Parse(txtEslora.Text);
			else
				oRegistroProyectoCNBE.Eslora =   NullableDouble.Null;
				
			if (txtManga.Text != String.Empty)
				oRegistroProyectoCNBE.Manga = NullableDouble.Parse(txtManga.Text);
			else
				oRegistroProyectoCNBE.Manga = NullableDouble.Null;
				
			if (txtPuntal.Text != String.Empty)
				oRegistroProyectoCNBE.Puntal =  NullableDouble.Parse(txtPuntal.Text);
			else
				oRegistroProyectoCNBE.Puntal =  NullableDouble.Null;
            
			if (txtCalado.Text != String.Empty)
				oRegistroProyectoCNBE.Calado = NullableDouble.Parse(txtCalado.Text);
			else
				oRegistroProyectoCNBE.Calado = NullableDouble.Null;

			if (txtVelocidad.Text != String.Empty)
				oRegistroProyectoCNBE.Velocidad = txtVelocidad.Text; 
			else
				oRegistroProyectoCNBE.Velocidad = NullableString.Null;
			
			if(txtTripulacion.Text != String.Empty)
				oRegistroProyectoCNBE.Tripulacion=  txtTripulacion.Text;
			else
				oRegistroProyectoCNBE.Tripulacion=NullableString.Null;
			
			if(txtAutonomia.Text != String.Empty)
				oRegistroProyectoCNBE.Autonomia =  txtAutonomia.Text;
			else
				oRegistroProyectoCNBE.Autonomia = NullableString.Null;
		
			if (txtGenElectrica.Text != String.Empty)
				oRegistroProyectoCNBE.GenElectrica = txtGenElectrica.Text;
			else
				oRegistroProyectoCNBE.GenElectrica =NullableString.Null;

			if(txtCombustible.Text != String.Empty)
				oRegistroProyectoCNBE.Combustible =  txtCombustible.Text;
			else
				oRegistroProyectoCNBE.Combustible = NullableString.Null;
		
			if (txtAgua.Text != String.Empty)
				oRegistroProyectoCNBE.Agua = txtAgua.Text;
			else
				oRegistroProyectoCNBE.Agua = NullableString.Null;

			if (txtAHidraulico.Text != String.Empty) 
				oRegistroProyectoCNBE.AHidraulico = txtAHidraulico.Text;
			else
				oRegistroProyectoCNBE.AHidraulico = NullableString.Null;
				
			if ( txtALubricacion.Text!= String.Empty)
				oRegistroProyectoCNBE.ALubricacion = txtALubricacion.Text;
			else
				oRegistroProyectoCNBE.ALubricacion = NullableString.Null;

			
			if ( calFechaFirmaAcuerdo.SelectedDate.ToString()  != Utilitario.Constantes.FECHAVALORENBLANCO)
				oRegistroProyectoCNBE.FechaFirmaAcuerdo = calFechaFirmaAcuerdo.SelectedDate;
			else
				oRegistroProyectoCNBE.FechaFirmaAcuerdo =  NullableDateTime.Null;

			if ( calPuestaQuilla.SelectedDate.ToString()  != Utilitario.Constantes.FECHAVALORENBLANCO)
				oRegistroProyectoCNBE.FechaPuestaQuilla = calPuestaQuilla.SelectedDate;
			else
				oRegistroProyectoCNBE.FechaPuestaQuilla = NullableDateTime.Null;

			if (calFechaInicioContractual.SelectedDate.ToString()  != Utilitario.Constantes.FECHAVALORENBLANCO)
				oRegistroProyectoCNBE.FechaInicioContractual = calFechaInicioContractual.SelectedDate;
			else
				oRegistroProyectoCNBE.FechaInicioContractual = NullableDateTime.Null;
			
			if (calFechaFinContractual.SelectedDate.ToString()  != Utilitario.Constantes.FECHAVALORENBLANCO)
				oRegistroProyectoCNBE.FechaTerminoContractual = calFechaFinContractual.SelectedDate;
			else
				oRegistroProyectoCNBE.FechaTerminoContractual = NullableDateTime.Null;
			

			if (calFechaEntrega.SelectedDate.ToString()  != Utilitario.Constantes.FECHAVALORENBLANCO)
				oRegistroProyectoCNBE.FechaEntrega = calFechaEntrega.SelectedDate;
			else
				oRegistroProyectoCNBE.FechaEntrega = NullableDateTime.Null;

			if (calFechaLanzamiento.SelectedDate.ToString()  != Utilitario.Constantes.FECHAVALORENBLANCO)
				oRegistroProyectoCNBE.FechaLanzamiento =  calFechaLanzamiento.SelectedDate;
			else
				oRegistroProyectoCNBE.FechaLanzamiento = NullableDateTime.Null;
				
			if (calFechaInicioReal.SelectedDate.ToString()  != Utilitario.Constantes.FECHAVALORENBLANCO)
				oRegistroProyectoCNBE.FechaInicioReal =   calFechaInicioReal.SelectedDate;
			else
				oRegistroProyectoCNBE.FechaInicioReal= NullableDateTime.Null;

			if (calFechaFinReal.SelectedDate.ToString()  != Utilitario.Constantes.FECHAVALORENBLANCO)
				oRegistroProyectoCNBE.FechaTerminoReal =  calFechaFinReal.SelectedDate;
			else
				oRegistroProyectoCNBE.FechaTerminoReal = NullableDateTime.Null;

			if(this.ddlEstadoProyecto.SelectedValue != Utilitario.Constantes.VALORSELECCIONAR)
			{	
				oRegistroProyectoCNBE.IdEstadoProyecto =  NullableInt32.Parse(ddlEstadoProyecto.SelectedValue);
			}
			oRegistroProyectoCNBE.IdTablaEstadoProyecto = idEstadoProyecto;

			if (txtDocPrincipal.Text != String.Empty)
				oRegistroProyectoCNBE.DocPrincipal = txtDocPrincipal.Text;
			else
				oRegistroProyectoCNBE.DocPrincipal = NullableString.Null;
			
			if(this.ddlTipoDocumento.SelectedValue != Utilitario.Constantes.VALORSELECCIONAR)
			{	
				oRegistroProyectoCNBE.IdTipoDocumento = NullableInt32.Parse(ddlTipoDocumento.SelectedValue);
			}
			oRegistroProyectoCNBE.IdTablaTipoDocumento = idTipoDocumento;

			if (txtOtroDoc.Text != String.Empty)
				oRegistroProyectoCNBE.OtroDocumento =  txtOtroDoc.Text;
			else
				oRegistroProyectoCNBE.OtroDocumento = NullableString.Null;
			if(this.ddlOtroTipodocumento.SelectedValue != Utilitario.Constantes.VALORSELECCIONAR)
			{	
				oRegistroProyectoCNBE.IdTipoOtroDocumento = NullableInt32.Parse(ddlOtroTipodocumento.SelectedValue);
			}

			if (txtMontoContrato.Text != String.Empty)
				oRegistroProyectoCNBE.MontoContrato =  NullableDouble.Parse(txtMontoContrato.Text);
			else
				oRegistroProyectoCNBE.MontoContrato =  NullableDouble.Null;
				
			if(this.ddlMoneda.SelectedValue != Utilitario.Constantes.VALORSELECCIONAR)
			{	
				oRegistroProyectoCNBE.IdMoneda = NullableInt32.Parse(ddlMoneda.SelectedValue);
			}
			oRegistroProyectoCNBE.IdTablaMoneda = idTipoModena;

			if (hIdJefeProyecto.Value != String.Empty)
				oRegistroProyectoCNBE.IdJefeProyecto = NullableInt32.Parse( hIdJefeProyecto.Value);
			else
				oRegistroProyectoCNBE.IdJefeProyecto = NullableInt32.Null;


			if (txtObservacion.Text != String.Empty)
				oRegistroProyectoCNBE.Observaciones = txtObservacion.Text;
			else
				oRegistroProyectoCNBE.Observaciones = NullableString.Null;
				
            
			oRegistroProyectoCNBE.FechaRegistro = DateTime.Now;
			oRegistroProyectoCNBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();

			
			oRegistroProyectoCNBE.IdEstado=  Convert.ToInt32(Enumerados.EstadoGeneral.Activo);
			oRegistroProyectoCNBE.IdTablaEstado= Convert.ToInt32(Enumerados.TablasTabla.EstadoGeneral);
		
			//**********************************************************************************

			if(fContrato.Value!=String.Empty)
			{
				strFilename = fContrato.PostedFile.FileName;
				res = strFilename.Split('\\');
				i=res.GetUpperBound(Utilitario.Constantes.ValorConstanteCero);
				strFilename = res[i];

				oRegistroProyectoCNBE.RutaContrato = strFilename;
				
			}
			else
			{
				oRegistroProyectoCNBE.RutaContrato = NullableString.Null;
			}

			
			if(fEspecificaciones.Value!=String.Empty)
			{
				strFilename = fEspecificaciones.PostedFile.FileName;
				res = strFilename.Split('\\');
				i=res.GetUpperBound(Utilitario.Constantes.ValorConstanteCero);
				strFilename = res[i];

				oRegistroProyectoCNBE.RutaEspecificaciones = strFilename;
				
			}
			else
			{
				oRegistroProyectoCNBE.RutaEspecificaciones = NullableString.Null;
			}

			if(fPresupuesto.Value!=String.Empty)
			{
				strFilename = fPresupuesto.PostedFile.FileName;
				res = strFilename.Split('\\');
				i=res.GetUpperBound(Utilitario.Constantes.ValorConstanteCero);
				strFilename = res[i];
				
				oRegistroProyectoCNBE.RutaPresupuesto = strFilename;
			}
			else
			{
				oRegistroProyectoCNBE.RutaPresupuesto = NullableString.Null;
			}
		
			if(fPlano.Value!=String.Empty)
			{
				strFilename = fPlano.PostedFile.FileName;
				res = strFilename.Split('\\');
				i=res.GetUpperBound(Utilitario.Constantes.ValorConstanteCero);
				strFilename = res[i];

				oRegistroProyectoCNBE.RutaPlano = strFilename;
				
			}
			else
			{
				oRegistroProyectoCNBE.RutaPlano = NullableString.Null;
			}
	
			if(fFoto.Value!=String.Empty)
			{
				strFilename = fFoto.PostedFile.FileName;
				res = strFilename.Split('\\');
				i=res.GetUpperBound(Utilitario.Constantes.ValorConstanteCero);
				strFilename = res[i];

				oRegistroProyectoCNBE.RutaFoto = strFilename;
			
			}
			else
			{
				oRegistroProyectoCNBE.RutaFoto = ARCHIVO;
			}

			//**********************************************************************************

			if (txtFuenteInformacion.Text != String.Empty)
				oRegistroProyectoCNBE.FuenteInformacion = txtFuenteInformacion.Text;
			else
				oRegistroProyectoCNBE.FuenteInformacion =NullableString.Null;

			if (txttCombustible.Text != String.Empty)
				oRegistroProyectoCNBE.TCombustible = txttCombustible.Text;
			else
				oRegistroProyectoCNBE.TCombustible =NullableString.Null;

			CMantenimientos oCMantenimientos = new CMantenimientos();
			int retorno = oCMantenimientos.Insertar(oRegistroProyectoCNBE);

			if (retorno == Utilitario.Constantes.VALORCONFIRMACIONREGISTRO)
			{
				if (fFoto.Value != String.Empty)
					this.GuardarImagen();
				
				if (fContrato.Value != String.Empty)
					this.GuardarDocumentoContrato(Convert.ToInt32(Page.Request.QueryString[KEYIDREGISTROPROYECTOCN]));

				if (fEspecificaciones.Value != String.Empty)
					this.GuardarDocumentoEspecificaciones(Convert.ToInt32(Page.Request.QueryString[KEYIDREGISTROPROYECTOCN]));
				
				if (fPlano.Value != String.Empty)
					this.GuardarDocumentoPlano(Convert.ToInt32(Page.Request.QueryString[KEYIDREGISTROPROYECTOCN]));

				if (fPresupuesto.Value != String.Empty)
					this.GuardarDocumentoPresupuesto(Convert.ToInt32(Page.Request.QueryString[KEYIDREGISTROPROYECTOCN]));
				
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Utilitario.Enumerados.NombresdeModulo.GestiónComercial.ToString(),this.ToString(),MENSAJEREGISTRO + retorno.ToString() + Utilitario.Constantes.SIMBOLOPUNTO,Enumerados.NivelesErrorLog.I.ToString()));
				
				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionComercial.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONREGISTROREGISTROPROYECTO))+ Utilitario.Constantes.HISTORIALATRAS ;
			}
			
		}
	
		public void GuardarImagen() 
		{
			HttpPostedFile myFile = fFoto.PostedFile;
			int nFileLen = myFile.ContentLength; 
					
			if( nFileLen > Utilitario.Constantes.ValorConstanteCero)
			{
				if(nFileLen <= TAMANOARCHIVO)
				{	
					byte[] myData = new byte[nFileLen];

					myFile.InputStream.Read(myData, Utilitario.Constantes.ValorConstanteCero, nFileLen);
					string path = RutaImagenCarpetaProyecto;
					string strFilename = myFile.FileName;

					string[] res = strFilename.Split('\\');
					int i=res.GetUpperBound(Utilitario.Constantes.ValorConstanteCero);
					strFilename = res[i];
							
					Helper.GuardarImagenServidor(myData,path + strFilename);
				}
			}		
		}

		public void GuardarDocumentoContrato(int IdProyecto) 
		{
			HttpPostedFile myFile = fContrato.PostedFile;
			int nFileLen = myFile.ContentLength; 

			if( nFileLen > Utilitario.Constantes.ValorConstanteCero )
			{
				if(nFileLen <= TAMANOARCHIVO)
				{	
					byte[] myData = new byte[nFileLen];

					myFile.InputStream.Read(myData,Utilitario.Constantes.ValorConstanteCero, nFileLen);
					string path = RutaImagenCarpetaProyecto;
					string strFilename = myFile.FileName;

					string[] res = strFilename.Split('\\');
					int i=res.GetUpperBound(Utilitario.Constantes.ValorConstanteCero);
					strFilename = res[i];

					string[] ExtencionArchivo=strFilename.Split('.');
							
					WriteToFile(path + strFilename,ref myData);
				}
			}		
		}

		public void GuardarDocumentoEspecificaciones(int IdProyecto) 
		{
			HttpPostedFile myFile = fEspecificaciones.PostedFile;
			int nFileLen = myFile.ContentLength; 

			if( nFileLen > Utilitario.Constantes.ValorConstanteCero )
			{
				if(nFileLen <= TAMANOARCHIVO)
				{	
					byte[] myData = new byte[nFileLen];

					myFile.InputStream.Read(myData,Utilitario.Constantes.ValorConstanteCero, nFileLen);
					string path = RutaImagenCarpetaProyecto;
					string strFilename = myFile.FileName;

					string[] res = strFilename.Split('\\');
					int i=res.GetUpperBound(Utilitario.Constantes.ValorConstanteCero);
					strFilename = res[i];
					
					WriteToFile(path + strFilename,ref myData);
				}
			}		
		}

		public void GuardarDocumentoPlano(int IdProyecto) 
		{
			HttpPostedFile myFile = fPlano.PostedFile;
			int nFileLen = myFile.ContentLength; 

			if( nFileLen > Utilitario.Constantes.ValorConstanteCero )
			{
				if(nFileLen <= TAMANOARCHIVO)
				{	
					byte[] myData = new byte[nFileLen];

					myFile.InputStream.Read(myData,Utilitario.Constantes.ValorConstanteCero, nFileLen);
					string path = RutaImagenCarpetaProyecto;
					string strFilename = myFile.FileName;

					string[] res = strFilename.Split('\\');
					int i=res.GetUpperBound(Utilitario.Constantes.ValorConstanteCero);
					strFilename = res[i];
		
					WriteToFile(path + strFilename,ref myData);
				}
			}		
		}
		
		public void GuardarDocumentoPresupuesto(int IdProyecto) 
		{
			HttpPostedFile myFile = fPresupuesto.PostedFile;
			int nFileLen = myFile.ContentLength; 

			if( nFileLen > Utilitario.Constantes.ValorConstanteCero )
			{
				if(nFileLen <= TAMANOARCHIVO)
				{	
					byte[] myData = new byte[nFileLen];

					myFile.InputStream.Read(myData,Utilitario.Constantes.ValorConstanteCero, nFileLen);
					string path = RutaImagenCarpetaProyecto;
					string strFilename = myFile.FileName;

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
			RegistroProyectoCNBE oRegistroProyectoCNBE = new RegistroProyectoCNBE();
			
			oRegistroProyectoCNBE.IdRegistroProyectoCN = Convert.ToInt32(Page.Request.QueryString[KEYIDREGISTROPROYECTOCN]);
			oRegistroProyectoCNBE.Nombre = txtNombre.Text;
			oRegistroProyectoCNBE.IdHistorico = txtIdProyecto.Text;

			if (txtNroProyecto.Text != String.Empty)
				oRegistroProyectoCNBE.NroProyecto = NullableString.Parse(txtNroProyecto.Text);
			else
				oRegistroProyectoCNBE.NroProyecto = NullableString.Null;
				
			oRegistroProyectoCNBE.IdCentroOperativo = NullableInt32.Parse(ddlCentroOperativo.SelectedValue);
					
			if (txtMatricula.Text != String.Empty)
				oRegistroProyectoCNBE.Matricula=  txtMatricula.Text;
			else
				oRegistroProyectoCNBE.Matricula= NullableString.Null;
																
			if(hIdCliente.Value != String.Empty)
				oRegistroProyectoCNBE.IdCliente= NullableInt32.Parse(hIdCliente.Value);
			else
				oRegistroProyectoCNBE.IdCliente= NullableInt32.Null;
			if(this.ddlTipoProducto.SelectedValue != Utilitario.Constantes.VALORSELECCIONAR)
			{
				oRegistroProyectoCNBE.IdTipoProducto = NullableInt32.Parse(ddlTipoProducto.SelectedValue);
			}
			oRegistroProyectoCNBE.IdTablaTipoProducto = idTipoProducto;
			if(this.ddlTipoBuque.SelectedValue != Utilitario.Constantes.VALORSELECCIONAR)
			{
				oRegistroProyectoCNBE.IdBuque  = NullableInt32.Parse(ddlTipoBuque.SelectedValue);
			}
			if (txtSubTipo.Text != String.Empty)
				oRegistroProyectoCNBE.SubTipoBuque = txtSubTipo.Text;
			else
				oRegistroProyectoCNBE.SubTipoBuque = NullableString.Null;
				
			if (txtClasificacion.Text != String.Empty)
				oRegistroProyectoCNBE.Clasificacion = txtClasificacion.Text; 
			else
				oRegistroProyectoCNBE.Clasificacion= NullableString.Null;
				
			if (txtDWT.Text != String.Empty)
				oRegistroProyectoCNBE.DWT = NullableString.Parse(txtDWT.Text);
			else
				oRegistroProyectoCNBE.DWT = NullableString.Null;
				
			if (txtLightship.Text != String.Empty)
				oRegistroProyectoCNBE.LightShip = NullableString.Parse(txtLightship.Text);
			else
				oRegistroProyectoCNBE.LightShip = NullableString.Null;

			if (txtDesplazamiento.Text != String.Empty)
				oRegistroProyectoCNBE.Desplazamiento = NullableString.Parse(txtDesplazamiento.Text);
			else
				oRegistroProyectoCNBE.Desplazamiento = NullableString.Null;

			if (txtCapBod.Text != String.Empty)
				oRegistroProyectoCNBE.CapBod =  txtCapBod.Text;
			else
				oRegistroProyectoCNBE.CapBod = NullableString.Null;

			if (txtEmpuje.Text != String.Empty)
				oRegistroProyectoCNBE.Empuje = txtEmpuje.Text;
			else
				oRegistroProyectoCNBE.Empuje =NullableString.Null;

			if (txtTonProcesadas.Text != String.Empty)
				oRegistroProyectoCNBE.TonProcesadas = txtTonProcesadas.Text;
			else
				oRegistroProyectoCNBE.TonProcesadas = NullableString.Null;
			if(this.ddlMaterailCasco.SelectedValue != Utilitario.Constantes.VALORSELECCIONAR)
			{
				oRegistroProyectoCNBE.IdTipoMaterialCasco = NullableInt32.Parse( ddlMaterailCasco.SelectedValue);
			}
			oRegistroProyectoCNBE.IdTablaTipoMaterialCasco = idTipoMaterial;
				
			if (txtNroBodegas.Text != String.Empty)
				oRegistroProyectoCNBE.NroBodegas = txtNroBodegas.Text;
			else
				oRegistroProyectoCNBE.NroBodegas = NullableString.Null;
				
			if (txtNroTanques.Text != String.Empty)
				oRegistroProyectoCNBE.NroTanques =  txtNroTanques.Text;
			else
				oRegistroProyectoCNBE.NroTanques = NullableString.Null;

			if (txtNroContenedores.Text != String.Empty)
				oRegistroProyectoCNBE.NroContenedores = txtNroContenedores.Text;
			else
				oRegistroProyectoCNBE.NroContenedores = NullableString.Null;

			if(txtMotor.Text != String.Empty)				
				oRegistroProyectoCNBE.Motor = txtMotor.Text;
			else
				oRegistroProyectoCNBE.Motor =  NullableString.Null;

			if (txtModelo.Text !=String.Empty)
				oRegistroProyectoCNBE.Modelo = txtModelo.Text;
			else
				oRegistroProyectoCNBE.Modelo =  NullableString.Null;

			if(txtPotencia.Text != String.Empty)
				oRegistroProyectoCNBE.Potencia = txtPotencia.Text;
			else
				oRegistroProyectoCNBE.Potencia =  NullableString.Null;
			
			if (txtArboladura.Text != String.Empty)
				oRegistroProyectoCNBE.Arboladura = txtArboladura.Text;
			else
				oRegistroProyectoCNBE.Arboladura = NullableString.Null;

			if (txtEslora.Text != String.Empty)
				oRegistroProyectoCNBE.Eslora =   NullableDouble.Parse(txtEslora.Text);
			else
				oRegistroProyectoCNBE.Eslora =   NullableDouble.Null;
				
			if (txtManga.Text != String.Empty)
				oRegistroProyectoCNBE.Manga = NullableDouble.Parse(txtManga.Text);
			else
				oRegistroProyectoCNBE.Manga = NullableDouble.Null;
				
			if (txtPuntal.Text != String.Empty)
				oRegistroProyectoCNBE.Puntal =  NullableDouble.Parse(txtPuntal.Text);
			else
				oRegistroProyectoCNBE.Puntal =  NullableDouble.Null;
            
			if (txtCalado.Text != String.Empty)
				oRegistroProyectoCNBE.Calado = NullableDouble.Parse(txtCalado.Text);
			else
				oRegistroProyectoCNBE.Calado = NullableDouble.Null;

			if (txtVelocidad.Text != String.Empty)
				oRegistroProyectoCNBE.Velocidad = txtVelocidad.Text; 
			else
				oRegistroProyectoCNBE.Velocidad = NullableString.Null;
			
			if(txtTripulacion.Text != String.Empty)
				oRegistroProyectoCNBE.Tripulacion=  txtTripulacion.Text;
			else
				oRegistroProyectoCNBE.Tripulacion=NullableString.Null;
			
			if(txtAutonomia.Text != String.Empty)
				oRegistroProyectoCNBE.Autonomia =  txtAutonomia.Text;
			else
				oRegistroProyectoCNBE.Autonomia = NullableString.Null;
		
			if (txtGenElectrica.Text != String.Empty)
				oRegistroProyectoCNBE.GenElectrica = txtGenElectrica.Text;
			else
				oRegistroProyectoCNBE.GenElectrica =NullableString.Null;

			if(txtCombustible.Text != String.Empty)
				oRegistroProyectoCNBE.Combustible =  txtCombustible.Text;
			else
				oRegistroProyectoCNBE.Combustible = NullableString.Null;
		
			if (txtAgua.Text != String.Empty)
				oRegistroProyectoCNBE.Agua = txtAgua.Text;
			else
				oRegistroProyectoCNBE.Agua = NullableString.Null;

			if (txtAHidraulico.Text != String.Empty) 
				oRegistroProyectoCNBE.AHidraulico = txtAHidraulico.Text;
			else
				oRegistroProyectoCNBE.AHidraulico = NullableString.Null;
				
			if ( txtALubricacion.Text!= String.Empty)
				oRegistroProyectoCNBE.ALubricacion = txtALubricacion.Text;
			else
				oRegistroProyectoCNBE.ALubricacion = NullableString.Null;

			if ( calFechaFirmaAcuerdo.SelectedDate.ToString()  != Utilitario.Constantes.FECHAVALORENBLANCO)
				oRegistroProyectoCNBE.FechaFirmaAcuerdo = calFechaFirmaAcuerdo.SelectedDate;
			else
				oRegistroProyectoCNBE.FechaFirmaAcuerdo =  NullableDateTime.Null;

			if ( calPuestaQuilla.SelectedDate.ToString()  != Utilitario.Constantes.FECHAVALORENBLANCO)
				oRegistroProyectoCNBE.FechaPuestaQuilla = calPuestaQuilla.SelectedDate;
			else
				oRegistroProyectoCNBE.FechaPuestaQuilla = NullableDateTime.Null;

			if (calFechaInicioContractual.SelectedDate.ToString()  != Utilitario.Constantes.FECHAVALORENBLANCO)
				oRegistroProyectoCNBE.FechaInicioContractual = calFechaInicioContractual.SelectedDate;
			else
				oRegistroProyectoCNBE.FechaInicioContractual = NullableDateTime.Null;
			
			if (calFechaFinContractual.SelectedDate.ToString()  != Utilitario.Constantes.FECHAVALORENBLANCO)
				oRegistroProyectoCNBE.FechaTerminoContractual = calFechaFinContractual.SelectedDate;
			else
				oRegistroProyectoCNBE.FechaTerminoContractual = NullableDateTime.Null;
			
			if (calFechaEntrega.SelectedDate.ToString()  != Utilitario.Constantes.FECHAVALORENBLANCO)
				oRegistroProyectoCNBE.FechaEntrega = calFechaEntrega.SelectedDate;
			else
				oRegistroProyectoCNBE.FechaEntrega = NullableDateTime.Null;

			if (calFechaLanzamiento.SelectedDate.ToString()  != Utilitario.Constantes.FECHAVALORENBLANCO)
				oRegistroProyectoCNBE.FechaLanzamiento =  calFechaLanzamiento.SelectedDate;
			else
				oRegistroProyectoCNBE.FechaLanzamiento = NullableDateTime.Null;
				
			if (calFechaInicioReal.SelectedDate.ToString()  != Utilitario.Constantes.FECHAVALORENBLANCO)
				oRegistroProyectoCNBE.FechaInicioReal =   calFechaInicioReal.SelectedDate;
			else
				oRegistroProyectoCNBE.FechaInicioReal= NullableDateTime.Null;

			if (calFechaFinReal.SelectedDate.ToString()  != Utilitario.Constantes.FECHAVALORENBLANCO)
				oRegistroProyectoCNBE.FechaTerminoReal =  calFechaFinReal.SelectedDate;
			else
				oRegistroProyectoCNBE.FechaTerminoReal = NullableDateTime.Null;
				
			if(this.ddlEstadoProyecto.SelectedValue != Utilitario.Constantes.VALORSELECCIONAR)
			{
				oRegistroProyectoCNBE.IdEstadoProyecto =  NullableInt32.Parse(ddlEstadoProyecto.SelectedValue);
			}
			oRegistroProyectoCNBE.IdTablaEstadoProyecto = idEstadoProyecto;

			if (txtDocPrincipal.Text != String.Empty)
				oRegistroProyectoCNBE.DocPrincipal = txtDocPrincipal.Text;
			else
				oRegistroProyectoCNBE.DocPrincipal = NullableString.Null;
			
			if(this.ddlTipoDocumento.SelectedValue != Utilitario.Constantes.VALORSELECCIONAR)
			{
				oRegistroProyectoCNBE.IdTipoDocumento = NullableInt32.Parse(ddlTipoDocumento.SelectedValue);
			}
			oRegistroProyectoCNBE.IdTablaTipoDocumento = idTipoDocumento;

			if (txtOtroDoc.Text != String.Empty)
				oRegistroProyectoCNBE.OtroDocumento =  txtOtroDoc.Text;
			else
				oRegistroProyectoCNBE.OtroDocumento = NullableString.Null;
			if(this.ddlOtroTipodocumento.SelectedValue != Utilitario.Constantes.VALORSELECCIONAR)
			{
				oRegistroProyectoCNBE.IdTipoOtroDocumento = NullableInt32.Parse(ddlOtroTipodocumento.SelectedValue);
			}

			if (txtMontoContrato.Text != String.Empty)
				oRegistroProyectoCNBE.MontoContrato =  NullableDouble.Parse(txtMontoContrato.Text);
			else
				oRegistroProyectoCNBE.MontoContrato =  NullableDouble.Null;
				
			if(this.ddlMoneda.SelectedValue != Utilitario.Constantes.VALORSELECCIONAR)
			{
				oRegistroProyectoCNBE.IdMoneda = NullableInt32.Parse(ddlMoneda.SelectedValue);
			}
			oRegistroProyectoCNBE.IdTablaMoneda = idTipoModena;

			if (hIdJefeProyecto.Value != String.Empty)
				oRegistroProyectoCNBE.IdJefeProyecto = NullableInt32.Parse( hIdJefeProyecto.Value);
			else
				oRegistroProyectoCNBE.IdJefeProyecto = NullableInt32.Null;


			if (txtObservacion.Text != String.Empty)
				oRegistroProyectoCNBE.Observaciones = txtObservacion.Text;
			else
				oRegistroProyectoCNBE.Observaciones = NullableString.Null;
			

			oRegistroProyectoCNBE.IdEstado=  Convert.ToInt32(Enumerados.EstadoGeneral.Activo);
			oRegistroProyectoCNBE.IdTablaEstado= Convert.ToInt32(Enumerados.TablasTabla.EstadoGeneral);

			oRegistroProyectoCNBE.IdUsuarioActualizacion = CNetAccessControl.GetIdUser();
			oRegistroProyectoCNBE.FechaActualizacion = DateTime.Now;

			if(!ckEliminarContrato.Checked)
			{
				if(fContrato.Value!=String.Empty )
				{
					strFilename = fContrato.PostedFile.FileName;
					res = strFilename.Split('\\');
					i=res.GetUpperBound(Utilitario.Constantes.ValorConstanteCero);
					strFilename = res[i];

					oRegistroProyectoCNBE.RutaContrato = strFilename;
				}
				else
					oRegistroProyectoCNBE.RutaContrato = hContrato.Value;
			}
			else
			{
				oRegistroProyectoCNBE.RutaContrato = String.Empty;
			}

			if(!ckEliminarEspTecnica.Checked)
			{
				if(fEspecificaciones.Value!=String.Empty)
				{
					strFilename = fEspecificaciones.PostedFile.FileName;
					res = strFilename.Split('\\');
					i=res.GetUpperBound(Utilitario.Constantes.ValorConstanteCero);
					strFilename = res[i];

					oRegistroProyectoCNBE.RutaEspecificaciones = strFilename;
				}
				else
					oRegistroProyectoCNBE.RutaEspecificaciones = hEspecificaciones.Value;
			}
			else
			{
				oRegistroProyectoCNBE.RutaEspecificaciones = String.Empty;
			}
			if(!ckEliminarPresupuesto.Checked)
			{
				if(fPresupuesto.Value!=String.Empty)
				{
					strFilename = fPresupuesto.PostedFile.FileName;
					res = strFilename.Split('\\');
					i=res.GetUpperBound(Utilitario.Constantes.ValorConstanteCero);
					strFilename = res[i];
				
					oRegistroProyectoCNBE.RutaPresupuesto = strFilename;
				}
				else
					oRegistroProyectoCNBE.RutaPresupuesto = hPresupuesto.Value;
			}
			else
			{
				oRegistroProyectoCNBE.RutaPresupuesto = String.Empty;
			}

			if(!ckEliminarPlano.Checked)
			{
				if(fPlano.Value!=String.Empty)
				{
					strFilename = fPlano.PostedFile.FileName;
					res = strFilename.Split('\\');
					i=res.GetUpperBound(Utilitario.Constantes.ValorConstanteCero);
					strFilename = res[i];

					oRegistroProyectoCNBE.RutaPlano = strFilename;
				
				}
				else
				{
					oRegistroProyectoCNBE.RutaPlano = hPlano.Value;
				}
			}
			else
			{
				oRegistroProyectoCNBE.RutaPlano = String.Empty;
			}
	
			if(!ckEliminarFoto.Checked)
			{
				if(fFoto.Value!=String.Empty)
				{
					strFilename = fFoto.PostedFile.FileName;
					res = strFilename.Split('\\');
					i=res.GetUpperBound(Utilitario.Constantes.ValorConstanteCero);
					strFilename = res[i];

					oRegistroProyectoCNBE.RutaFoto = strFilename;
				}
				else
				{
					strFilename = imgProyecto.ImageUrl;
					res = strFilename.Split('/');
					i=res.GetUpperBound(Utilitario.Constantes.ValorConstanteCero);
					strFilename = res[i];

					oRegistroProyectoCNBE.RutaFoto = strFilename;	
				}
			}
			else
			{
				oRegistroProyectoCNBE.RutaFoto = ARCHIVO;
			}

			

			if (txtFuenteInformacion.Text != String.Empty)
				oRegistroProyectoCNBE.FuenteInformacion = txtFuenteInformacion.Text;
			else
				oRegistroProyectoCNBE.FuenteInformacion =NullableString.Null;

			if (txttCombustible.Text != String.Empty)
				oRegistroProyectoCNBE.TCombustible = txttCombustible.Text;
			else
				oRegistroProyectoCNBE.TCombustible =NullableString.Null;

			CMantenimientos oCMantenimientos = new CMantenimientos();
			
			int retorno = oCMantenimientos.Modificar(oRegistroProyectoCNBE);

			if(retorno>=Utilitario.Constantes.VALORCONFIRMACIONREGISTRO)
			{
				if (!ckEliminarFoto.Checked && fFoto.Value!=String.Empty)
					this.GuardarImagen();
				
				if (!ckEliminarContrato.Checked && fContrato.Value!=String.Empty)
					this.GuardarDocumentoContrato(Convert.ToInt32(Page.Request.QueryString[KEYIDREGISTROPROYECTOCN]));

				if (!ckEliminarEspTecnica.Checked && fEspecificaciones.Value != String.Empty)
					this.GuardarDocumentoEspecificaciones(Convert.ToInt32(Page.Request.QueryString[KEYIDREGISTROPROYECTOCN]));
				
				if (!ckEliminarPlano.Checked && fPlano.Value != String.Empty)
					this.GuardarDocumentoPlano(Convert.ToInt32(Page.Request.QueryString[KEYIDREGISTROPROYECTOCN]));

				if (!ckEliminarPresupuesto.Checked && fPresupuesto.Value != String.Empty)
					this.GuardarDocumentoPresupuesto(Convert.ToInt32(Page.Request.QueryString[KEYIDREGISTROPROYECTOCN]));
				
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Utilitario.Enumerados.NombresdeModulo.GestiónComercial.ToString(),this.ToString(),MENSAJEMODIFICO + retorno.ToString() + Utilitario.Constantes.SIMBOLOPUNTO,Enumerados.NivelesErrorLog.I.ToString()));
				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionComercial.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONMODIFICACIONREGISTROPROYECTO));
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
			ckEliminarFoto.Visible = false;
			ckEliminarEspTecnica.Visible = false;
			ckEliminarContrato.Visible = false;
			ckEliminarPresupuesto.Visible = false;
			ckEliminarPlano.Visible = false;
			tblAtras.Visible = Utilitario.Constantes.VALORUNCHECKEDBOOL;
		}

		public void CargarModoModificar()
		{
			if (Convert.ToInt32(Page.Request.QueryString[KEYIDCLIENTE]) == Utilitario.Constantes.IDCLIENTEMARINA)
				lblTermino.Text = Utilitario.Constantes.TEXTOSETIQUETAMARINA;

			tblAtras.Visible = Utilitario.Constantes.VALORUNCHECKEDBOOL;

			CMantenimientos	oCMantenimientos = new CMantenimientos();
			RegistroProyectoCNBE oRegistroProyectoCNBE = (RegistroProyectoCNBE)oCMantenimientos.ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYIDREGISTROPROYECTOCN]),Enumerados.ClasesNTAD.RegistroProyectoCNNTAD.ToString());

			
			txtNombre.Text =	oRegistroProyectoCNBE.Nombre;
			txtIdProyecto.Text = oRegistroProyectoCNBE.IdHistorico;


			Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.QueryString[Utilitario.Constantes.KEYMODOPAGINA]) ;

			switch (oModoPagina)
			{
				case Enumerados.ModoPagina.M:
				{
					ckEliminarFoto.Visible = true;
					ckEliminarEspTecnica.Visible = true;
					ckEliminarContrato.Visible = true;
					ckEliminarPresupuesto.Visible = true;
					ckEliminarPlano.Visible = true;

					if (!oRegistroProyectoCNBE.NroProyecto.IsNull )
						txtNroProyecto.Text = Convert.ToString(oRegistroProyectoCNBE.NroProyecto);
			
					if (!oRegistroProyectoCNBE.Matricula.IsNull )
						txtMatricula.Text = Convert.ToString(oRegistroProyectoCNBE.Matricula);

					if (!oRegistroProyectoCNBE.SubTipoBuque.IsNull)
						txtSubTipo.Text  = Convert.ToString(oRegistroProyectoCNBE.SubTipoBuque);
			
					if (!oRegistroProyectoCNBE.Clasificacion.IsNull )
						txtClasificacion.Text = Convert.ToString(oRegistroProyectoCNBE.Clasificacion);
			
					if (!oRegistroProyectoCNBE.DWT.IsNull )
						txtDWT.Text = Convert.ToString(oRegistroProyectoCNBE.DWT);
			
					if (!oRegistroProyectoCNBE.LightShip.IsNull)
						txtLightship.Text = Convert.ToString(oRegistroProyectoCNBE.LightShip);
			
					if (!oRegistroProyectoCNBE.Desplazamiento.IsNull)
						txtDesplazamiento.Text = Convert.ToString(oRegistroProyectoCNBE.Desplazamiento);
			
					if (!oRegistroProyectoCNBE.CapBod.IsNull )
						txtCapBod.Text = Convert.ToString(oRegistroProyectoCNBE.CapBod);
			
					if (!oRegistroProyectoCNBE.Empuje.IsNull )
						txtEmpuje.Text = Convert.ToString(oRegistroProyectoCNBE.Empuje);
			
					if (!oRegistroProyectoCNBE.TonProcesadas.IsNull )
						txtTonProcesadas.Text = Convert.ToString(oRegistroProyectoCNBE.TonProcesadas);

					if (!oRegistroProyectoCNBE.NroBodegas.IsNull )
						txtNroBodegas.Text = Convert.ToString(oRegistroProyectoCNBE.NroBodegas);

					if (!oRegistroProyectoCNBE.NroTanques.IsNull)
						txtNroTanques.Text = Convert.ToString(oRegistroProyectoCNBE.NroTanques);
			
					if (!oRegistroProyectoCNBE.NroContenedores.IsNull )
						txtNroContenedores.Text = Convert.ToString(oRegistroProyectoCNBE.NroContenedores);
			
					if (!oRegistroProyectoCNBE.Motor.IsNull)
						txtMotor.Text= Convert.ToString(oRegistroProyectoCNBE.Motor);
			
					if (!oRegistroProyectoCNBE.Modelo.IsNull )
						txtModelo.Text= Convert.ToString(oRegistroProyectoCNBE.Modelo);
			
					if (!oRegistroProyectoCNBE.Potencia.IsNull)
						txtPotencia.Text =	Convert.ToString(oRegistroProyectoCNBE.Potencia);
			
					if (!oRegistroProyectoCNBE.Arboladura.IsNull )
						txtArboladura.Text= Convert.ToString(oRegistroProyectoCNBE.Arboladura);

					if (!oRegistroProyectoCNBE.Velocidad.IsNull)
						txtVelocidad.Text=	Convert.ToString(oRegistroProyectoCNBE.Velocidad);
			
					if (!oRegistroProyectoCNBE.Tripulacion.IsNull )
						txtTripulacion.Text= Convert.ToString(oRegistroProyectoCNBE.Tripulacion);
			
					if (!oRegistroProyectoCNBE.Autonomia.IsNull )
						txtAutonomia.Text= Convert.ToString(oRegistroProyectoCNBE.Autonomia);
			
					if (!oRegistroProyectoCNBE.GenElectrica.IsNull )
						txtGenElectrica.Text=Convert.ToString(oRegistroProyectoCNBE.GenElectrica);
			
					if (!oRegistroProyectoCNBE.Combustible.IsNull)
						txtCombustible.Text= Convert.ToString(oRegistroProyectoCNBE.Combustible);

					if (!oRegistroProyectoCNBE.TCombustible.IsNull)
						txttCombustible.Text= Convert.ToString(oRegistroProyectoCNBE.TCombustible);

					if (!oRegistroProyectoCNBE.Agua.IsNull)
						txtAgua.Text = Convert.ToString(oRegistroProyectoCNBE.Agua);

					if (!oRegistroProyectoCNBE.AHidraulico.IsNull )
						txtAHidraulico.Text=Convert.ToString(oRegistroProyectoCNBE.AHidraulico);
			
					if (!oRegistroProyectoCNBE.ALubricacion.IsNull )
						txtALubricacion.Text=Convert.ToString(oRegistroProyectoCNBE.ALubricacion);

					if (!oRegistroProyectoCNBE.IdCliente.IsNull )
					{
						hIdCliente.Value = oRegistroProyectoCNBE.IdCliente.ToString();
						CCliente oCCliente = new CCliente();
						txtRazonSocial.Text=  oCCliente.ObtenerNombreCliente(Convert.ToInt32(hIdCliente.Value));
					}

					if (!oRegistroProyectoCNBE.FechaFirmaAcuerdo.IsNull )
						calFechaFirmaAcuerdo.SelectedDate = Convert.ToDateTime(oRegistroProyectoCNBE.FechaFirmaAcuerdo.ToString());
			
					if ( !oRegistroProyectoCNBE.FechaPuestaQuilla.IsNull )
						calPuestaQuilla.SelectedDate = Convert.ToDateTime(oRegistroProyectoCNBE.FechaPuestaQuilla.ToString());
			
					if (!oRegistroProyectoCNBE.FechaInicioContractual.IsNull )
						calFechaInicioContractual.SelectedDate = Convert.ToDateTime(oRegistroProyectoCNBE.FechaInicioContractual.ToString());
			
					if (!oRegistroProyectoCNBE.FechaTerminoContractual.IsNull )
						calFechaFinContractual.SelectedDate = Convert.ToDateTime(oRegistroProyectoCNBE.FechaTerminoContractual.ToString());
			
					if(!oRegistroProyectoCNBE.FechaEntrega.IsNull )
						calFechaEntrega.SelectedDate = Convert.ToDateTime(oRegistroProyectoCNBE.FechaEntrega.ToString());
			
					if(!oRegistroProyectoCNBE.FechaLanzamiento.IsNull )
						calFechaLanzamiento.SelectedDate = Convert.ToDateTime(oRegistroProyectoCNBE.FechaLanzamiento.ToString());
			
					if(!oRegistroProyectoCNBE.FechaInicioReal.IsNull )
						calFechaInicioReal.SelectedDate = Convert.ToDateTime(oRegistroProyectoCNBE.FechaInicioReal.ToString());
			
					if(!oRegistroProyectoCNBE.FechaTerminoReal.IsNull  )
						calFechaFinReal.SelectedDate = Convert.ToDateTime(oRegistroProyectoCNBE.FechaTerminoReal.ToString());

					if (!oRegistroProyectoCNBE.Eslora.IsNull )
						txtEslora.Text= Convert.ToString(oRegistroProyectoCNBE.Eslora);
			
					if (!oRegistroProyectoCNBE.Manga.IsNull)
						txtManga.Text=Convert.ToString(oRegistroProyectoCNBE.Manga);
			
					if (!oRegistroProyectoCNBE.Puntal.IsNull )
						txtPuntal.Text= Convert.ToString(oRegistroProyectoCNBE.Puntal);

					if (!oRegistroProyectoCNBE.Calado.IsNull )
						txtCalado.Text= Convert.ToString(oRegistroProyectoCNBE.Calado);

					if (!oRegistroProyectoCNBE.IdCentroOperativo.IsNull)
						ddlCentroOperativo.Items.FindByValue(oRegistroProyectoCNBE.IdCentroOperativo.ToString()).Selected = true;
					
					if (!oRegistroProyectoCNBE.IdTipoProducto.IsNull)
						ddlTipoProducto.Items.FindByValue(oRegistroProyectoCNBE.IdTipoProducto.ToString()).Selected = true;

					if (!oRegistroProyectoCNBE.IdBuque.IsNull)
						ddlTipoBuque.Items.FindByValue(oRegistroProyectoCNBE.IdBuque.ToString()).Selected = true;

					if (!oRegistroProyectoCNBE.IdTipoMaterialCasco.IsNull)
						ddlMaterailCasco.Items.FindByValue(oRegistroProyectoCNBE.IdTipoMaterialCasco.ToString()).Selected = true;

					if (!oRegistroProyectoCNBE.IdEstadoProyecto.IsNull)
						ddlEstadoProyecto.Items.FindByValue(oRegistroProyectoCNBE.IdEstadoProyecto.ToString()).Selected = true;

					if (!oRegistroProyectoCNBE.IdTipoDocumento.IsNull)
						ddlTipoDocumento.Items.FindByValue(oRegistroProyectoCNBE.IdTipoDocumento.ToString()).Selected = true;

					if (!oRegistroProyectoCNBE.IdTipoOtroDocumento.IsNull)
						ddlOtroTipodocumento.Items.FindByValue(oRegistroProyectoCNBE.IdTipoOtroDocumento.ToString()).Selected = true;

					if (!oRegistroProyectoCNBE.IdMoneda.IsNull)
						ddlMoneda.Items.FindByValue(oRegistroProyectoCNBE.IdMoneda.ToString()).Selected = true;

					if (!oRegistroProyectoCNBE.IdJefeProyecto.IsNull)
					{
						hIdJefeProyecto.Value= oRegistroProyectoCNBE.IdJefeProyecto.ToString();
						CPersonal oCPersonal = new CPersonal();
						txtJefeProyectos.Text = oCPersonal.ObtenerNombrePersonal(Convert.ToInt32(oRegistroProyectoCNBE.IdJefeProyecto));
					}
					
					if (!oRegistroProyectoCNBE.MontoContrato.IsNull )
						this.txtMontoContrato.Text = oRegistroProyectoCNBE.MontoContrato.Value.ToString();
				
					if (!oRegistroProyectoCNBE.FuenteInformacion.IsNull )
						txtFuenteInformacion.Text = oRegistroProyectoCNBE.FuenteInformacion.ToString();

					if (!oRegistroProyectoCNBE.TCombustible.IsNull )
						txttCombustible.Text = oRegistroProyectoCNBE.TCombustible.ToString();

					if (!oRegistroProyectoCNBE.DocPrincipal.IsNull)
						txtDocPrincipal.Text= Convert.ToString(oRegistroProyectoCNBE.DocPrincipal);
	
					if (!oRegistroProyectoCNBE.OtroDocumento.IsNull )
						txtOtroDoc.Text= Convert.ToString(oRegistroProyectoCNBE.OtroDocumento);

					if (!oRegistroProyectoCNBE.Observaciones.IsNull)
						txtObservacion.Text= Convert.ToString(oRegistroProyectoCNBE.Observaciones);

			
					if (!oRegistroProyectoCNBE.RutaPresupuesto.IsNull )
					{
						rutaArchivoPresupuesto = RutaImagenCarpetaProyecto +  "\\" +  oRegistroProyectoCNBE.RutaPresupuesto.ToString();
						hPresupuesto.Value = Convert.ToString(oRegistroProyectoCNBE.RutaPresupuesto);
						hlkPresupuesto.Text = TEXTOVER;
						hlkPresupuesto.NavigateUrl = rutaArchivoPresupuesto;
						hlkPresupuesto.Visible = true;
					}
					else
					{
						hlkPresupuesto.Visible = false;
						ckEliminarPresupuesto.Enabled = false;
					}
						
					
					if (!oRegistroProyectoCNBE.RutaContrato.IsNull)
					{
						rutaArchivoContrato = RutaImagenCarpetaProyecto +  "\\" +  oRegistroProyectoCNBE.RutaContrato.ToString();
						hlkContrato.Text = TEXTOVER;
						hlkContrato.NavigateUrl = rutaArchivoContrato;
						hContrato.Value = oRegistroProyectoCNBE.RutaContrato.ToString();
						hlkContrato.Visible = true;
					}
					else
					{
						hlkContrato.Visible = false;
						ckEliminarContrato.Enabled = false;
					}

			
					if (!oRegistroProyectoCNBE.RutaEspecificaciones.IsNull )
					{
						rutaArchivoEspecificaciones = RutaImagenCarpetaProyecto +  "\\" +  oRegistroProyectoCNBE.RutaEspecificaciones.ToString();
						hlkEspecificacionTecnica.NavigateUrl = rutaArchivoEspecificaciones;
						hEspecificaciones.Value = oRegistroProyectoCNBE.RutaEspecificaciones.ToString();
						hlkEspecificacionTecnica.Text = TEXTOVER;
						hlkEspecificacionTecnica.Visible = true;
					}
					else
					{
						hlkEspecificacionTecnica.Visible = false;
						ckEliminarEspTecnica.Enabled = false;
					}

					if (!oRegistroProyectoCNBE.RutaPlano.IsNull )
					{
						rutaArchivoPlano = RutaImagenCarpetaProyecto +  "\\" +  oRegistroProyectoCNBE.RutaPlano.ToString();
						hlkPlano.Text = TEXTOVER;
						hlkPlano.NavigateUrl = rutaArchivoPlano;
						hPlano.Value = oRegistroProyectoCNBE.RutaPlano.ToString();
						hlkPlano.Visible = true;
					}
					else
					{
						hlkPlano.Visible = false;	
						ckEliminarPlano.Enabled = false;
					}

					if (!oRegistroProyectoCNBE.FechaInicioReal.IsNull
						&& !oRegistroProyectoCNBE.FechaTerminoReal.IsNull)
					{
						TimeSpan numero =  (DateTime)oRegistroProyectoCNBE.FechaTerminoReal - (DateTime)oRegistroProyectoCNBE.FechaInicioReal;
						txtTEjecucion.Text = numero.Days.ToString();
					}


				}break;
				case Enumerados.ModoPagina.C:
				{
					ckEliminarFoto.Visible = false;
					ckEliminarEspTecnica.Visible = false;
					ckEliminarContrato.Visible = false;
					ckEliminarPresupuesto.Visible = false;
					ckEliminarPlano.Visible = false;

					if (!oRegistroProyectoCNBE.NroProyecto.IsNull )
						txtNroProyecto.Text = Convert.ToString(oRegistroProyectoCNBE.NroProyecto);
					else 
						txtNroProyecto.Text = Utilitario.Constantes.TEXTOSINDATA;

					if (!oRegistroProyectoCNBE.Matricula.IsNull )
						txtMatricula.Text = Convert.ToString(oRegistroProyectoCNBE.Matricula);
					else 
						txtMatricula.Text = Utilitario.Constantes.TEXTOSINDATA;

					if (!oRegistroProyectoCNBE.SubTipoBuque.IsNull)
						txtSubTipo.Text  = Convert.ToString(oRegistroProyectoCNBE.SubTipoBuque);
					else 
						txtSubTipo.Text = Utilitario.Constantes.TEXTOSINDATA;
			
					if (!oRegistroProyectoCNBE.Clasificacion.IsNull )
						txtClasificacion.Text = Convert.ToString(oRegistroProyectoCNBE.Clasificacion);
					else 
						txtClasificacion.Text = Utilitario.Constantes.TEXTOSINDATA;
			
					if (!oRegistroProyectoCNBE.DWT.IsNull )
						txtDWT.Text = Convert.ToString(oRegistroProyectoCNBE.DWT);
					else 
						txtDWT.Text = Utilitario.Constantes.TEXTOSINDATA;
			
					if (!oRegistroProyectoCNBE.LightShip.IsNull)
						txtLightship.Text = Convert.ToString(oRegistroProyectoCNBE.LightShip);
					else 
						txtLightship.Text = Utilitario.Constantes.TEXTOSINDATA;
			
					if (!oRegistroProyectoCNBE.Desplazamiento.IsNull)
						txtDesplazamiento.Text = Convert.ToString(oRegistroProyectoCNBE.Desplazamiento);
					else 
						txtDesplazamiento.Text = Utilitario.Constantes.TEXTOSINDATA;
			
					if (!oRegistroProyectoCNBE.CapBod.IsNull )
						txtCapBod.Text = Convert.ToString(oRegistroProyectoCNBE.CapBod);
					else 
						txtCapBod.Text = Utilitario.Constantes.TEXTOSINDATA;
			
					if (!oRegistroProyectoCNBE.Empuje.IsNull )
						txtEmpuje.Text = Convert.ToString(oRegistroProyectoCNBE.Empuje);
					else 
						txtEmpuje.Text = Utilitario.Constantes.TEXTOSINDATA;
			
					if (!oRegistroProyectoCNBE.TonProcesadas.IsNull )
						txtTonProcesadas.Text = Convert.ToString(oRegistroProyectoCNBE.TonProcesadas);
					else 
						txtTonProcesadas.Text = Utilitario.Constantes.TEXTOSINDATA;

					if (!oRegistroProyectoCNBE.NroBodegas.IsNull )
						txtNroBodegas.Text = Convert.ToString(oRegistroProyectoCNBE.NroBodegas);
					else 
						txtNroBodegas.Text = Utilitario.Constantes.TEXTOSINDATA;

					if (!oRegistroProyectoCNBE.NroTanques.IsNull)
						txtNroTanques.Text = Convert.ToString(oRegistroProyectoCNBE.NroTanques);
					else 
						txtNroTanques.Text = Utilitario.Constantes.TEXTOSINDATA;
			
					if (!oRegistroProyectoCNBE.NroContenedores.IsNull )
						txtNroContenedores.Text = Convert.ToString(oRegistroProyectoCNBE.NroContenedores);
					else 
						txtNroContenedores.Text = Utilitario.Constantes.TEXTOSINDATA;
			
					if (!oRegistroProyectoCNBE.Motor.IsNull)
						txtMotor.Text= Convert.ToString(oRegistroProyectoCNBE.Motor);
					else 
						txtMotor.Text = Utilitario.Constantes.TEXTOSINDATA;
			
					if (!oRegistroProyectoCNBE.Modelo.IsNull )
						txtModelo.Text= Convert.ToString(oRegistroProyectoCNBE.Modelo);
					else 
						txtModelo.Text = Utilitario.Constantes.TEXTOSINDATA;
			
					if (!oRegistroProyectoCNBE.Potencia.IsNull)
						txtPotencia.Text =	Convert.ToString(oRegistroProyectoCNBE.Potencia);
					else 
						txtPotencia.Text = Utilitario.Constantes.TEXTOSINDATA;
			
					if (!oRegistroProyectoCNBE.Arboladura.IsNull )
						txtArboladura.Text= Convert.ToString(oRegistroProyectoCNBE.Arboladura);
					else 
						txtArboladura.Text = Utilitario.Constantes.TEXTOSINDATA;

					if (!oRegistroProyectoCNBE.Velocidad.IsNull)
						txtVelocidad.Text=	Convert.ToString(oRegistroProyectoCNBE.Velocidad);
					else 
						txtVelocidad.Text = Utilitario.Constantes.TEXTOSINDATA;
			
					if (!oRegistroProyectoCNBE.Tripulacion.IsNull )
						txtTripulacion.Text= Convert.ToString(oRegistroProyectoCNBE.Tripulacion);
					else 
						txtTripulacion.Text = Utilitario.Constantes.TEXTOSINDATA;
			
					if (!oRegistroProyectoCNBE.Autonomia.IsNull )
						txtAutonomia.Text= Convert.ToString(oRegistroProyectoCNBE.Autonomia);
					else 
						txtAutonomia.Text = Utilitario.Constantes.TEXTOSINDATA;
			
					if (!oRegistroProyectoCNBE.GenElectrica.IsNull )
						txtGenElectrica.Text=Convert.ToString(oRegistroProyectoCNBE.GenElectrica);
					else 
						txtGenElectrica.Text = Utilitario.Constantes.TEXTOSINDATA;
			
					if (!oRegistroProyectoCNBE.Combustible.IsNull)
						txtCombustible.Text= Convert.ToString(oRegistroProyectoCNBE.Combustible);
					else 
						txtCombustible.Text = Utilitario.Constantes.TEXTOSINDATA;

					if (!oRegistroProyectoCNBE.TCombustible.IsNull)
						txttCombustible.Text= Convert.ToString(oRegistroProyectoCNBE.TCombustible);
					else 
						txttCombustible.Text = Utilitario.Constantes.TEXTOSINDATA;

					if (!oRegistroProyectoCNBE.Agua.IsNull)
						txtAgua.Text = Convert.ToString(oRegistroProyectoCNBE.Agua);
					else 
						txtAgua.Text = Utilitario.Constantes.TEXTOSINDATA;

					if (!oRegistroProyectoCNBE.AHidraulico.IsNull )
						txtAHidraulico.Text=Convert.ToString(oRegistroProyectoCNBE.AHidraulico);
					else 
						txtAHidraulico.Text = Utilitario.Constantes.TEXTOSINDATA;
			
					if (!oRegistroProyectoCNBE.ALubricacion.IsNull )
						txtALubricacion.Text=Convert.ToString(oRegistroProyectoCNBE.ALubricacion);
					else 
						txtALubricacion.Text = Utilitario.Constantes.TEXTOSINDATA;

					if (!oRegistroProyectoCNBE.IdCliente.IsNull )
					{
						hIdCliente.Value = oRegistroProyectoCNBE.IdCliente.ToString();
						CCliente oCCliente = new CCliente();
						txtRazonSocial.Text=  oCCliente.ObtenerNombreCliente(Convert.ToInt32(hIdCliente.Value));

					}
					else
						CelltxtRazonSocial.InnerText = Utilitario.Constantes.TEXTOSINDATA;

					if (!oRegistroProyectoCNBE.FechaFirmaAcuerdo.IsNull )
						CellcalFechaFirmaAcuerdo.InnerText = oRegistroProyectoCNBE.FechaFirmaAcuerdo.Value.ToShortDateString();
					else
					{
						CellcalFechaFirmaAcuerdo.InnerText = Utilitario.Constantes.TEXTOSINDATA;
						calFechaFirmaAcuerdo.Visible = false;
					}
					
					if (!oRegistroProyectoCNBE.FechaPuestaQuilla.IsNull )
						CellcalPuestaQuilla.InnerText = oRegistroProyectoCNBE.FechaPuestaQuilla.Value.ToShortDateString();
					else
					{
						CellcalPuestaQuilla.InnerText = Utilitario.Constantes.TEXTOSINDATA;
						calPuestaQuilla.Visible = false;
					}

					if (!oRegistroProyectoCNBE.FechaInicioContractual.IsNull )
						CellcalFechaInicioContractual.InnerText = oRegistroProyectoCNBE.FechaInicioContractual.Value.ToShortDateString();
					else
					{
						CellcalFechaInicioContractual.InnerText = Utilitario.Constantes.TEXTOSINDATA;
						calFechaInicioContractual.Visible = false;
					}

					if (!oRegistroProyectoCNBE.FechaTerminoContractual.IsNull )
						CellcalFechaFinContractual.InnerText = oRegistroProyectoCNBE.FechaTerminoContractual.Value.ToShortDateString();
					else
					{
						CellcalFechaFinContractual.InnerText = Utilitario.Constantes.TEXTOSINDATA;
						calFechaFinContractual.Visible = false;
					}

					if (!oRegistroProyectoCNBE.FechaEntrega.IsNull )
						CellcalFechaEntrega.InnerText = oRegistroProyectoCNBE.FechaEntrega.Value.ToShortDateString();
					else
					{
						CellcalFechaEntrega.InnerText = Utilitario.Constantes.TEXTOSINDATA;
						calFechaEntrega.Visible = false;
					}

					if (!oRegistroProyectoCNBE.FechaLanzamiento.IsNull )
						CellcalFechaLanzamiento.InnerText = oRegistroProyectoCNBE.FechaLanzamiento.Value.ToShortDateString();
					else
					{
						CellcalFechaLanzamiento.InnerText = Utilitario.Constantes.TEXTOSINDATA;
						calFechaLanzamiento.Visible = false;
					}

					if (!oRegistroProyectoCNBE.FechaInicioReal.IsNull )
						CellcalFechaInicioReal.InnerText = oRegistroProyectoCNBE.FechaInicioReal.Value.ToShortDateString();
					else
					{
						CellcalFechaInicioReal.InnerText = Utilitario.Constantes.TEXTOSINDATA;
						calFechaInicioReal.Visible = false;
					}

					if (!oRegistroProyectoCNBE.FechaTerminoReal.IsNull )
						CellcalFechaFinReal.InnerText = oRegistroProyectoCNBE.FechaTerminoReal.Value.ToShortDateString();
					else
					{
						CellcalFechaFinReal.InnerText = Utilitario.Constantes.TEXTOSINDATA;
						calFechaFinReal.Visible = false;
					}

					if (!oRegistroProyectoCNBE.Eslora.IsNull )
						txtEslora.Text= Convert.ToString(oRegistroProyectoCNBE.Eslora);
					else
					{
						CellTxtEslora.InnerText =  Utilitario.Constantes.TEXTOSINDATA;
						txtEslora.Visible = false;
					}
			
					if (!oRegistroProyectoCNBE.Manga.IsNull)
						txtManga.Text=Convert.ToString(oRegistroProyectoCNBE.Manga);
					else
					{
						CelltxtManga.InnerText = Utilitario.Constantes.TEXTOSINDATA;
						txtManga.Visible = false;
					}

					if (!oRegistroProyectoCNBE.Puntal.IsNull )
						txtPuntal.Text= Convert.ToString(oRegistroProyectoCNBE.Puntal);
					else
					{
						CelltxtPuntal.InnerText=Utilitario.Constantes.TEXTOSINDATA;
						txtPuntal.Visible = false;
					}

					if (!oRegistroProyectoCNBE.Calado.IsNull )
						txtCalado.Text= Convert.ToString(oRegistroProyectoCNBE.Calado);
					else
					{
						CelltxtCalado.InnerText= Utilitario.Constantes.TEXTOSINDATA;
						txtCalado.Visible = false;
					}

					if (!oRegistroProyectoCNBE.IdCentroOperativo.IsNull)
						ddlCentroOperativo.Items.FindByValue(oRegistroProyectoCNBE.IdCentroOperativo.ToString()).Selected = true;
					else
						CellddlCentroOperativo.InnerText= Utilitario.Constantes.TEXTOSINDATA;

					if (!oRegistroProyectoCNBE.IdTipoProducto.IsNull)
						ddlTipoProducto.Items.FindByValue(oRegistroProyectoCNBE.IdTipoProducto.ToString()).Selected = true;
					else
						CellddlTipoProducto.InnerText= Utilitario.Constantes.TEXTOSINDATA;
	
					if (!oRegistroProyectoCNBE.IdBuque.IsNull)
						ddlTipoBuque.Items.FindByValue(oRegistroProyectoCNBE.IdBuque.ToString()).Selected = true;
					else
						CellddlTipoBuque.InnerText=Utilitario.Constantes.TEXTOSINDATA;

					if (!oRegistroProyectoCNBE.IdTipoMaterialCasco.IsNull)
						ddlMaterailCasco.Items.FindByValue(oRegistroProyectoCNBE.IdTipoMaterialCasco.ToString()).Selected = true;
					else
						CellddlMaterailCasco.InnerText=Utilitario.Constantes.TEXTOSINDATA;

					if (!oRegistroProyectoCNBE.IdEstadoProyecto.IsNull)
						ddlEstadoProyecto.Items.FindByValue(oRegistroProyectoCNBE.IdEstadoProyecto.ToString()).Selected = true;
					else
						CellddlEstadoProyecto.InnerText=Utilitario.Constantes.TEXTOSINDATA;

					if (!oRegistroProyectoCNBE.IdTipoDocumento.IsNull)
						ddlTipoDocumento.Items.FindByValue(oRegistroProyectoCNBE.IdTipoDocumento.ToString()).Selected = true;
					else
						CellddlTipoDocumento.InnerText=Utilitario.Constantes.TEXTOSINDATA;

					if (!oRegistroProyectoCNBE.IdTipoOtroDocumento.IsNull)
						ddlOtroTipodocumento.Items.FindByValue(oRegistroProyectoCNBE.IdTipoOtroDocumento.ToString()).Selected = true;
					else
						CellddlOtroTipodocumento.InnerText=Utilitario.Constantes.TEXTOSINDATA;

					if (!oRegistroProyectoCNBE.IdMoneda.IsNull)
						ddlMoneda.Items.FindByValue(oRegistroProyectoCNBE.IdMoneda.ToString()).Selected = true;
					else
						CellddlMoneda.InnerText=Utilitario.Constantes.TEXTOSINDATA;

					if (!oRegistroProyectoCNBE.IdJefeProyecto.IsNull)
					{
						hIdJefeProyecto.Value= oRegistroProyectoCNBE.IdJefeProyecto.ToString();
						CPersonal oCPersonal = new CPersonal();
						txtJefeProyectos.Text = oCPersonal.ObtenerNombrePersonal(Convert.ToInt32(oRegistroProyectoCNBE.IdJefeProyecto));
					}
					else
						CelltxtJefeProyectos.InnerText = Utilitario.Constantes.TEXTOSINDATA;

					
					if (!oRegistroProyectoCNBE.MontoContrato.IsNull )
						this.txtMontoContrato.Text = oRegistroProyectoCNBE.MontoContrato.Value.ToString(Utilitario.Constantes.FORMATODECIMAL4);
					else
					{
						txtMontoContrato.Text = String.Empty;
						CelltxtMontoContrato.InnerText =Utilitario.Constantes.TEXTOSINDATA;
					}

					if (!oRegistroProyectoCNBE.FuenteInformacion.IsNull )
						txtFuenteInformacion.Text = oRegistroProyectoCNBE.FuenteInformacion.ToString();
					else
						txtFuenteInformacion.Text = Utilitario.Constantes.TEXTOSINDATA;

					if (!oRegistroProyectoCNBE.TCombustible.IsNull )
						txttCombustible.Text = oRegistroProyectoCNBE.TCombustible.ToString();
					else
						txttCombustible.Text = Utilitario.Constantes.TEXTOSINDATA;

					if (!oRegistroProyectoCNBE.DocPrincipal.IsNull)
						txtDocPrincipal.Text= Convert.ToString(oRegistroProyectoCNBE.DocPrincipal);
					else
						txtDocPrincipal.Text = Utilitario.Constantes.TEXTOSINDATA;
	
					if (!oRegistroProyectoCNBE.OtroDocumento.IsNull )
						txtOtroDoc.Text= Convert.ToString(oRegistroProyectoCNBE.OtroDocumento);
					else
						txtOtroDoc.Text = Utilitario.Constantes.TEXTOSINDATA;

					if (!oRegistroProyectoCNBE.Observaciones.IsNull)
						txtObservacion.Text= Convert.ToString(oRegistroProyectoCNBE.Observaciones);
					else
						txtObservacion.Text = Utilitario.Constantes.TEXTOSINDATA;

			
					if (!oRegistroProyectoCNBE.RutaPresupuesto.IsNull )
					{
						rutaArchivoPresupuesto = RutaImagenServerProyecto +  "\\" +  oRegistroProyectoCNBE.RutaPresupuesto.ToString();
						hlkPresupuesto.Text = oRegistroProyectoCNBE.RutaPresupuesto.ToString();
						hlkPresupuesto.NavigateUrl = rutaArchivoPresupuesto ;
						hlkPresupuesto.Visible = true;
					}
					else
						CellfPresupuesto.InnerText = Utilitario.Constantes.TEXTOSINDATA;

					if (!oRegistroProyectoCNBE.RutaContrato.IsNull)
					{
						rutaArchivoContrato = RutaImagenServerProyecto +  "\\" +  oRegistroProyectoCNBE.RutaContrato.ToString();
						hlkContrato.Text = oRegistroProyectoCNBE.RutaContrato.ToString();
						hlkContrato.NavigateUrl = rutaArchivoContrato;
						hlkContrato.Visible = true; 
					}
					else
						CellfContrato.InnerText = Utilitario.Constantes.TEXTOSINDATA;

			
					if (!oRegistroProyectoCNBE.RutaEspecificaciones.IsNull )
					{
						rutaArchivoEspecificaciones = RutaImagenServerProyecto +  "\\" +  oRegistroProyectoCNBE.RutaEspecificaciones.ToString();
						hlkEspecificacionTecnica.Text = oRegistroProyectoCNBE.RutaEspecificaciones.ToString();
						hlkEspecificacionTecnica.NavigateUrl = rutaArchivoEspecificaciones;
						hlkEspecificacionTecnica.Visible = true; 
					}
					else
						CellfEspecificaciones.InnerText = Utilitario.Constantes.TEXTOSINDATA;

					if (!oRegistroProyectoCNBE.RutaPlano.IsNull )
					{
						rutaArchivoPlano = RutaImagenServerProyecto +  "\\" +  oRegistroProyectoCNBE.RutaPlano.ToString();
						hlkPlano.Text = oRegistroProyectoCNBE.RutaPlano.ToString();
						hlkPlano.NavigateUrl = rutaArchivoPlano;
						hlkPlano.Visible = true; 
					}
					else
						CellfPlano.InnerText = Utilitario.Constantes.TEXTOSINDATA;

					if (!oRegistroProyectoCNBE.FechaInicioReal.IsNull
						&& !oRegistroProyectoCNBE.FechaTerminoReal.IsNull)
					{
						TimeSpan numero =  (DateTime)oRegistroProyectoCNBE.FechaTerminoReal - (DateTime)oRegistroProyectoCNBE.FechaInicioReal;
						CelltxtTEjecucion.InnerText = numero.Days.ToString();
					}
					else
						txtTEjecucion.Text = Utilitario.Constantes.TEXTOSINDATA;

				}break;
				
			}

			if (!oRegistroProyectoCNBE.RutaFoto.IsNull )
			{
				hFoto.Value =Convert.ToString( oRegistroProyectoCNBE.RutaFoto);
				string RutaImagen=RutaImagenServerProyecto + oRegistroProyectoCNBE.RutaFoto.Value;
				imgProyecto.ImageUrl = RutaImagen;
				hFoto.Value = oRegistroProyectoCNBE.RutaFoto.Value;
			}
			else
			{
				ckEliminarFoto.Enabled = false;
			}
		}

		public void CargarModoConsulta()
		{
			CargarModoModificar();
			
			Helper.BloquearControles(this);
			
			this.tblAtras.Visible = true;
			this.ibtnCancelar.Visible = false;
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

			if (calFechaInicioContractual.SelectedDate.ToString() != Utilitario.Constantes.FECHAVALORENBLANCO && calFechaFinContractual.SelectedDate.ToString() != Utilitario.Constantes.FECHAVALORENBLANCO)
			{
				if (calFechaInicioContractual.SelectedDate >= calFechaFinContractual.SelectedDate)
				{
					this.ltlMensaje.Text=Helper.MensajeAlert(Helper.ObtenerMensajesErrorComercialUsuario(Mensajes.CODIGOMENSAJEFECHASCONTRACTUALESINCORRECTAS));
					return Utilitario.Constantes.VALORUNCHECKEDBOOL;
				}
				
			}
			
			if(txtIdProyecto.Text == String.Empty)
			{
				this.ltlMensaje.Text = Helper.MensajeAlert("Debe llenar el campo Id Proyecto");
				return false;
			}
				
			if(txtNombre.Text == String.Empty)
			{
				this.ltlMensaje.Text = Helper.MensajeAlert("Debe llenar el campo Nombre del Proyecto");
				return false;
			}

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
			ListItem item;
			item = new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,Utilitario.Constantes.VALORSELECCIONAR);

			this.ddlCentroOperativo.DataSource = this.llenarCentroOperativo();
			ddlCentroOperativo.DataValueField = Enumerados.ColumnasCentroOperativo.IdCentroOperativo.ToString();
			ddlCentroOperativo.DataTextField = Enumerados.ColumnasCentroOperativo.Sigla2.ToString();
			ddlCentroOperativo.DataBind();
			

			this.ddlTipoBuque.DataSource = this.llenarTipoBuque();
			ddlTipoBuque.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlTipoBuque.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlTipoBuque.DataBind();
			ddlTipoBuque.Items.Insert(0,item);

			this.ddlTipoProducto.DataSource = this.llenarTipoProducto();
			ddlTipoProducto.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlTipoProducto.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlTipoProducto.DataBind();
			ddlTipoProducto.Items.Insert(0,item);

			this.ddlMaterailCasco.DataSource = this.llenarMaterialCasco();
			ddlMaterailCasco.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlMaterailCasco.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlMaterailCasco.DataBind();
			ddlMaterailCasco.Items.Insert(0,item);
			
			this.ddlTipoDocumento.DataSource = this.llenarTipoDocumento();
			ddlTipoDocumento.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlTipoDocumento.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlTipoDocumento.DataBind();
			ddlTipoDocumento.Items.Insert(0,item);

			this.ddlOtroTipodocumento.DataSource = this.llenarTipoDocumento();
			ddlOtroTipodocumento.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlOtroTipodocumento.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlOtroTipodocumento.DataBind();
			ddlOtroTipodocumento.Items.Insert(0,item);

			this.ddlMoneda.DataSource = this.llenarTipoMonedas();
			ddlMoneda.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlMoneda.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlMoneda.DataBind();
			ddlMoneda.Items.Insert(0,item);

			
			this.ddlEstadoProyecto.DataSource = this.llenarEstadosProyecto();
			ddlEstadoProyecto.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlEstadoProyecto.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlEstadoProyecto.DataBind();
			ddlEstadoProyecto.Items.Insert(0,item);
		}

		public void LlenarDatos()
		{
			Helper.CalendarioControlStyle(this.calFechaFirmaAcuerdo);
			Helper.CalendarioControlStyle(this.calPuestaQuilla);
			Helper.CalendarioControlStyle(this.calFechaInicioContractual);
			Helper.CalendarioControlStyle(this.calFechaLanzamiento);
			Helper.CalendarioControlStyle(this.calFechaFinContractual);
			Helper.CalendarioControlStyle(this.calFechaEntrega);
			Helper.CalendarioControlStyle(this.calFechaInicioReal);
			Helper.CalendarioControlStyle(this.calFechaFinReal);
		}

		public void LlenarJScript()
		{

			this.fFoto.Attributes.Add( Utilitario.Constantes.EVENTOONBLUR, JMOSTRARIMAGEN);
			this.ckEliminarFoto.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,JDISABLECONTROL + "(this,'" + fFoto.ClientID.ToString() + "');" );
			this.ckEliminarEspTecnica.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,JDISABLECONTROL + "(this,'" + fEspecificaciones.ClientID.ToString() + "');" );
			this.ckEliminarContrato.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,JDISABLECONTROL + "(this,'" + fContrato.ClientID.ToString() + "');" );
			this.ckEliminarPresupuesto.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,JDISABLECONTROL + "(this,'" + fPresupuesto.ClientID.ToString() + "');" );
			this.ckEliminarPlano.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,JDISABLECONTROL + "(this,'" + fPlano.ClientID.ToString() + "');" );

			this.rfvIdProyecto.ErrorMessage = "Tiene que llenar el campo IdProyecto";
			this.rfvNombre.ErrorMessage = "Tiene que llenar el campo nombre Proyecto";

			this.ibtnBuscarDependencia.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Helper.PopupBusqueda(URLIMPRESIONDOS,600,450,70,100,Utilitario.Constantes.VALORUNCHECKEDBOOL)+ JRETURNDOS);
			this.ibtBuscaJefeProyectos.Attributes.Add(Utilitario.Constantes.EVENTOCLICK ,Helper.PopupBusqueda(URLBUSQUEDAENTIDAD + Utilitario.Constantes.KEYTIPOBUSQUEDAENTIDAD +  Utilitario.Constantes.SIGNOIGUAL + Enumerados.TipoBusquedaEntidad.PE,700,700,true) +  JRETURN);
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

		#region Constantes
		//Otros
		private const string KEYIDCLIENTE ="KEYIDCLIENTE";
		const string SeparadorExtencion=".";
		const int TAMANOARCHIVO=5000000;
		const string SiglaProyecto="COM";
		const string FORMATOCEROS="000000";
		
		private string RutaImagenServerProyecto =  Helper.ObtenerRutaImagenes(Utilitario.Constantes.ProyectoRutaImagenServerProyectoEjecucionTerminado);
		private string RutaImagenCarpetaProyecto = Helper.ObtenerRutaImagenes(Utilitario.Constantes.ProyectoRutaImagenCarpetaProyectoEjecucionTerminado);

		//Mensajes
		const string MENSAJECONSULTAR= "Se ingreso a Detalle de registros Proyectos CN";
		const string MENSAJEREGISTRO = "Se registro un proyecto CN";
		const string MENSAJEMODIFICO = "Se modifico el registro proyecto CN Nro.";

		private string JMOSTRARIMAGEN = "MuestraImagen('imgProyecto',document.forms[0].fFoto,1)";

		//Graficos
		const string ARCHIVO = "sinfoto.jpg";

		//Ordenamiento
		const string COLORDENAMIENTO = "NombreDetalle";
		
		//Titulos 
		const string TITULOMODONUEVO = "NUEVO PROYECTO";
		const string TITULOMODOMODIFICAR = "ACTUALIZACION DE PROYECTOS";
		const string TITULOMODOCONSULTA = "CONSULTA DE PROYECTOS";

		//Key Session y QueryString
		const string KEYIDREGISTROPROYECTOCN = "IdRegistroProyectoCN";
		int idTablabuque = Convert.ToInt32(Utilitario.Enumerados.TablasTabla.TablaBuques);
		const int idTipoProducto = 223;
		const int idTipoMaterial = 171;
		int idTipoDocumento = Convert.ToInt32(Utilitario.Enumerados.TablasTabla.TablaTipoDocumentos);
		const int idEstadoProyecto = 35;
		const int idTipoModena=1;

		//Paginas
		const string URLIMPRESIONDOS="../../General/BuscarCliente.aspx";
		const string URLBUSQUEDAENTIDAD = "../../Legal/BusquedaEntidad.aspx?";
		

		//Jscript
		const string JRETURN = " return false;";
		const string JRETURNDOS = "; return false;";
		const string JDISABLECONTROL = "controlEnable";
		const string TEXTOVER = "Ver";

		#endregion Constantes

		#region Variables
		string strFilename;
		string[] res;
		int i;

		string rutaArchivoPlano,rutaArchivoPresupuesto,rutaArchivoContrato,rutaArchivoEspecificaciones;
		
		#endregion

		#region Controles
		protected System.Web.UI.WebControls.TextBox txtNroProyecto;
		protected System.Web.UI.HtmlControls.HtmlInputFile File1;
		protected System.Web.UI.WebControls.Image ibtnArmador;
		protected System.Web.UI.WebControls.Image ibtnProyecto;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblClasificacion;
		protected System.Web.UI.WebControls.DropDownList Dropdownlist1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.DropDownList Dropdownlist2;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.DropDownList Dropdownlist3;
		protected System.Web.UI.WebControls.TextBox Textbox4;
		protected System.Web.UI.WebControls.TextBox Textbox6;
		protected System.Web.UI.WebControls.TextBox Textbox7;
		protected System.Web.UI.WebControls.TextBox Textbox8;
		protected System.Web.UI.WebControls.TextBox Textbox9;
		protected System.Web.UI.WebControls.TextBox Textbox10;
		protected System.Web.UI.WebControls.TextBox Textbox11;
		protected System.Web.UI.WebControls.TextBox Textbox12;
		protected System.Web.UI.WebControls.TextBox Textbox13;
		protected System.Web.UI.WebControls.TextBox Textbox14;
		protected System.Web.UI.WebControls.TextBox Textbox19;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.HtmlControls.HtmlInputFile filMyFile;
		protected System.Web.UI.WebControls.DropDownList ddlbUnidadPeso;
		protected System.Web.UI.WebControls.DropDownList ddlbUnidadPotencia;
		protected System.Web.UI.WebControls.DropDownList ddlbUnidadVelocidad;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdJefeProyecto;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdUnidadDependenciaCliente;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hNombreCliente;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdCliente;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hPresupuesto;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hContrato;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hEspecificaciones;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hPlano;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hFoto;
		protected System.Web.UI.WebControls.Label lblEmpuje;
		protected System.Web.UI.WebControls.TextBox txtEmpuje;
		protected System.Web.UI.WebControls.Label lblDWT;
		protected System.Web.UI.WebControls.Label lblCapBod;
		protected System.Web.UI.WebControls.TextBox txtCapBod;
		protected System.Web.UI.WebControls.Label lblEslora;
		protected eWorld.UI.NumericBox txtEslora;
		protected System.Web.UI.WebControls.Label lblTonProcesadas;
		protected System.Web.UI.WebControls.TextBox txtTonProcesadas;
		protected System.Web.UI.WebControls.Label lblPuntual;
		protected eWorld.UI.NumericBox txtPuntal;
		protected System.Web.UI.WebControls.Label lblTripulacion;
		protected System.Web.UI.WebControls.TextBox txtTripulacion;
		protected System.Web.UI.WebControls.Label lblManga;
		protected eWorld.UI.NumericBox txtManga;
		protected System.Web.UI.WebControls.Label lblVelocidad;
		protected System.Web.UI.WebControls.TextBox txtVelocidad;
		protected System.Web.UI.WebControls.Label lblLightShip;
		protected System.Web.UI.WebControls.Label lblAutonomia;
		protected System.Web.UI.WebControls.TextBox txtAutonomia;
		protected System.Web.UI.WebControls.Label lblDesplazamiento;
		protected eWorld.UI.NumericBox txtCalado;
		protected System.Web.UI.WebControls.Label lblModelo;
		protected System.Web.UI.WebControls.TextBox txtModelo;
		protected System.Web.UI.WebControls.Label lblCalado;
		protected System.Web.UI.WebControls.Label lblNroTanques;
		protected System.Web.UI.WebControls.TextBox txtNroTanques;
		protected System.Web.UI.WebControls.Label lblMaterialCasco;
		protected System.Web.UI.WebControls.DropDownList ddlMaterailCasco;
		protected System.Web.UI.WebControls.Label lblGenElectrica;
		protected System.Web.UI.WebControls.TextBox txtGenElectrica;
		protected System.Web.UI.WebControls.Label lblNroBodegas;
		protected System.Web.UI.WebControls.TextBox txtNroBodegas;
		protected System.Web.UI.WebControls.Label lblArboladura;
		protected System.Web.UI.WebControls.TextBox txtArboladura;
		protected System.Web.UI.WebControls.Label lblTCombustible;
		protected System.Web.UI.WebControls.TextBox txttCombustible;
		protected System.Web.UI.WebControls.Label lblPotencia;
		protected System.Web.UI.WebControls.TextBox txtPotencia;
		protected System.Web.UI.WebControls.Label lblMotor;
		protected System.Web.UI.WebControls.TextBox txtMotor;
		protected System.Web.UI.WebControls.Label lblNroVontenedores;
		protected System.Web.UI.WebControls.TextBox txtNroContenedores;
		protected System.Web.UI.WebControls.Label lblCombustible;
		protected System.Web.UI.WebControls.TextBox txtCombustible;
		protected System.Web.UI.WebControls.Label lblHidraulico;
		protected System.Web.UI.WebControls.TextBox txtAHidraulico;
		protected System.Web.UI.WebControls.Label lblLubricacion;
		protected System.Web.UI.WebControls.TextBox txtALubricacion;
		protected System.Web.UI.WebControls.Label lblAgua;
		protected System.Web.UI.WebControls.TextBox txtAgua;
		protected System.Web.UI.WebControls.Label lblAspectoAdministrativo;
		protected System.Web.UI.WebControls.Label lblEstado;
		protected System.Web.UI.WebControls.DropDownList ddlEstadoProyecto;
		protected System.Web.UI.WebControls.Label lblLanzamiento;
		protected eWorld.UI.CalendarPopup calFechaLanzamiento;
		protected System.Web.UI.WebControls.Label lblMontoContrato;
		protected eWorld.UI.NumericBox txtMontoContrato;
		protected System.Web.UI.WebControls.Label lblFirmaAcuerdo;
		protected System.Web.UI.WebControls.Label lblMoneda;
		protected System.Web.UI.WebControls.DropDownList ddlMoneda;
		protected System.Web.UI.WebControls.Label lblInicioreal;
		protected eWorld.UI.CalendarPopup calFechaInicioReal;
		protected System.Web.UI.WebControls.Label lblDocPrincipal;
		protected System.Web.UI.WebControls.TextBox txtDocPrincipal;
		protected System.Web.UI.WebControls.Label lblInicioContractual;
		protected eWorld.UI.CalendarPopup calFechaInicioContractual;
		protected System.Web.UI.WebControls.Label lblTipoDocumento;
		protected System.Web.UI.WebControls.DropDownList ddlTipoDocumento;
		protected System.Web.UI.WebControls.Label lblPuestaQuilla;
		protected eWorld.UI.CalendarPopup calPuestaQuilla;
		protected System.Web.UI.WebControls.Label lblOtroDocumento;
		protected System.Web.UI.WebControls.TextBox txtOtroDoc;
		protected System.Web.UI.WebControls.Label lblFinContractual;
		protected eWorld.UI.CalendarPopup calFechaFinContractual;
		protected System.Web.UI.WebControls.Label lblOtroTipoDocumento;
		protected System.Web.UI.WebControls.DropDownList ddlOtroTipodocumento;
		protected System.Web.UI.WebControls.Label lblFinReal;
		protected eWorld.UI.CalendarPopup calFechaFinReal;
		protected System.Web.UI.WebControls.Label lblEjecucion;
		protected System.Web.UI.WebControls.TextBox txtTEjecucion;
		protected System.Web.UI.WebControls.Label lblTermino;
		protected eWorld.UI.CalendarPopup calFechaEntrega;
		protected System.Web.UI.WebControls.Label lblJefeProyectos;
		protected System.Web.UI.WebControls.TextBox txtJefeProyectos;
		protected System.Web.UI.WebControls.Label lblFuenteObservacion;
		protected System.Web.UI.WebControls.TextBox txtFuenteInformacion;
		protected System.Web.UI.WebControls.Label lblObservacion;
		protected System.Web.UI.WebControls.TextBox txtObservacion;
		protected System.Web.UI.WebControls.Label lblSeguridad;
		protected System.Web.UI.WebControls.Label lblPresupuesto;
		protected System.Web.UI.WebControls.HyperLink hlkPresupuesto;
		protected System.Web.UI.WebControls.Label lblContrato;
		protected System.Web.UI.WebControls.HyperLink hlkContrato;
		protected System.Web.UI.WebControls.Label lblPlano;
		protected System.Web.UI.WebControls.HyperLink hlkPlano;
		protected System.Web.UI.WebControls.Label lblEspTecnica;
		protected System.Web.UI.WebControls.HyperLink hlkEspecificacionTecnica;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.HtmlControls.HtmlInputFile fPresupuesto;
		protected System.Web.UI.HtmlControls.HtmlInputFile fContrato;
		protected System.Web.UI.HtmlControls.HtmlInputFile fPlano;
		protected System.Web.UI.HtmlControls.HtmlInputFile fEspecificaciones;
		protected System.Web.UI.HtmlControls.HtmlTableCell Cell;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.ImageButton ibtBuscaJefeProyectos;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlEstadoProyecto;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlTipoDocumento;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlOtroTipodocumento;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlMoneda;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnAtras;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlMaterailCasco;
		protected System.Web.UI.HtmlControls.HtmlTable tblAtras;
		protected System.Web.UI.HtmlControls.HtmlTableCell TD1;
		protected System.Web.UI.HtmlControls.HtmlTableCell TD2;
		protected System.Web.UI.HtmlControls.HtmlTableCell TD3;
		protected System.Web.UI.HtmlControls.HtmlTableCell TD4;
		protected System.Web.UI.HtmlControls.HtmlTableCell TD5;
		protected System.Web.UI.HtmlControls.HtmlTableCell TD6;
		protected System.Web.UI.HtmlControls.HtmlTableCell TD7;
		protected System.Web.UI.HtmlControls.HtmlTableCell TD8;
		protected System.Web.UI.HtmlControls.HtmlTableCell TD9;
		protected System.Web.UI.WebControls.Label lblNombre;
		protected System.Web.UI.WebControls.TextBox txtNombre;
		protected System.Web.UI.WebControls.Image imgProyecto;
		protected System.Web.UI.WebControls.Label lblIdProyecto;
		protected System.Web.UI.WebControls.Label lbbNroProyecto;
		protected System.Web.UI.WebControls.Label lnlCO;
		protected System.Web.UI.WebControls.DropDownList ddlCentroOperativo;
		protected System.Web.UI.WebControls.Label lblMatricula;
		protected System.Web.UI.WebControls.TextBox txtMatricula;
		protected System.Web.UI.WebControls.Label lblCliente;
		protected System.Web.UI.WebControls.TextBox txtRazonSocial;
		protected System.Web.UI.WebControls.Label lblTipoProducto;
		protected System.Web.UI.WebControls.DropDownList ddlTipoProducto;
		protected System.Web.UI.WebControls.Label lblTipoBuque;
		protected System.Web.UI.WebControls.DropDownList ddlTipoBuque;
		protected System.Web.UI.WebControls.Label lblSubTipo;
		protected System.Web.UI.WebControls.TextBox txtSubTipo;
		protected System.Web.UI.WebControls.Label lblClasficacion;
		protected System.Web.UI.WebControls.TextBox txtClasificacion;
		protected System.Web.UI.HtmlControls.HtmlInputFile fFoto;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlCentroOperativo;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlTipoProducto;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlTipoBuque;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellcalFechaFirmaAcuerdo;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellcalFechaInicioContractual;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellcalFechaFinContractual;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellcalFechaInicioReal;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellcalPuestaQuilla;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellcalFechaLanzamiento;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellcalFechaFinReal;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellcalFechaEntrega;
		protected System.Web.UI.WebControls.TextBox txtDWT;
		protected System.Web.UI.WebControls.TextBox txtLightship;
		protected System.Web.UI.WebControls.TextBox txtDesplazamiento;
		protected System.Web.UI.WebControls.Label lblDatosGenerales;
		protected System.Web.UI.WebControls.ImageButton ibtnBuscarDependencia;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellTxtEslora;
		protected System.Web.UI.HtmlControls.HtmlTableCell CelltxtManga;
		protected System.Web.UI.HtmlControls.HtmlTableCell CelltxtPuntal;
		protected System.Web.UI.HtmlControls.HtmlTableCell CelltxtCalado;
		protected System.Web.UI.HtmlControls.HtmlTableCell CelltxtTEjecucion;
		protected System.Web.UI.HtmlControls.HtmlTableCell CelltxtJefeProyectos;
		protected System.Web.UI.HtmlControls.HtmlTableCell CelltxtMontoContrato;
		protected System.Web.UI.HtmlControls.HtmlTableCell CelltxtRazonSocial;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellfPresupuesto;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellfPlano;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellfEspecificaciones;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvIdProyecto;
		protected System.Web.UI.WebControls.TextBox txtIdProyecto;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvNombre;
		protected System.Web.UI.WebControls.ValidationSummary vSum;
		protected System.Web.UI.WebControls.TextBox Textbox1;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnCancelar;
		protected eWorld.UI.CalendarPopup calFechaFirmaAcuerdo;
		protected System.Web.UI.WebControls.CheckBox ckEliminarFoto;
		protected System.Web.UI.WebControls.CheckBox ckEliminarEspTecnica;
		protected System.Web.UI.WebControls.CheckBox ckEliminarContrato;
		protected System.Web.UI.WebControls.CheckBox ckEliminarPresupuesto;
		protected System.Web.UI.WebControls.CheckBox ckEliminarPlano;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellfContrato;

		#endregion
						
		#region Eventos
		

		
		private DataTable llenarCentroOperativo()
		{
			CCentroOperativo oCCentroOperativo = new CCentroOperativo();
			return oCCentroOperativo.ListarTodosCombo();
		}
		private DataTable llenarTipoBuque()
		{
			CTablaTablas oCTablaTablas =  new CTablaTablas();		
			return oCTablaTablas.ListaTodosCombo(idTablabuque);
		}
		private DataTable llenarTipoProducto()
		{
			CTablaTablas oCTablaTablas =  new CTablaTablas();		
			return oCTablaTablas.ListaTodosCombo(idTipoProducto);
		}
		private DataTable llenarMaterialCasco()
		{
			CTablaTablas oCTablaTablas =  new CTablaTablas();		
			return oCTablaTablas.ListaTodosCombo(idTipoMaterial);
		}
		private DataTable llenarTipoDocumento()
		{
			CTablaTablas oCTablaTablas =  new CTablaTablas();		
			return oCTablaTablas.ListaTodosCombo(idTipoDocumento);
		}
		private DataTable llenarTipoMonedas()
		{
			CTablaTablas oCTablaTablas =  new CTablaTablas();		
			return oCTablaTablas.ListaTodosCombo(idTipoModena);
		}

		private DataTable llenarEstadosProyecto()
		{
			CTablaTablas oCTablaTablas =  new CTablaTablas();		
			return oCTablaTablas.ListaTodosCombo(idEstadoProyecto);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					this.LlenarDatos();
					this.LlenarCombos();
					this.LlenarJScript();
					this.CargarModoPagina();
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Utilitario.Enumerados.NombresdeModulo.GestiónComercial.ToString(),this.ToString(),MENSAJECONSULTAR,Enumerados.NivelesErrorLog.I.ToString()));			
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

		private void ibtnAceptar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				if(Page.IsValid)
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

		private void calFechaFinReal_DateChanged(object sender, System.EventArgs e)
		{
			this.calcularEjecucion();
		
		}

		private void calcularEjecucion()
		{
			if (calFechaInicioReal.SelectedDate.ToString() != Utilitario.Constantes.FECHAVALORENBLANCO
				&& calFechaFinReal.SelectedDate.ToString() != Utilitario.Constantes.FECHAVALORENBLANCO)
			{
			
				TimeSpan numero =  calFechaFinReal.SelectedDate - calFechaInicioReal.SelectedDate;
				txtTEjecucion.Text = numero.Days.ToString();
			
			}
		}

		#endregion

	
	}
}