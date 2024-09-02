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
using System.IO;

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
	public class DetalleProyectoConvenio : System.Web.UI.Page,IPaginaMantenimento,IPaginaBase
	{
		#region IPaginaMantenimento Members

		public void Agregar()
		{
			ProyectoConvenioBE oProyectoConvenioBE=new ProyectoConvenioBE();

			oProyectoConvenioBE.NroProyecto=Convert.ToInt32(this.nbNroProyecto.Text);
			oProyectoConvenioBE.MontoAsignado=NullableDouble.Parse(this.nbMontoAsignado.Text);
			oProyectoConvenioBE.MontoComprometido=NullableDouble.Parse(this.nbMontoComprometido.Text);
			oProyectoConvenioBE.MontoEnEjecucion=NullableDouble.Parse(this.nbMontoEnEjecucion.Text);
			oProyectoConvenioBE.MontoEjecutado=NullableDouble.Parse(this.nbMontoEjecutado.Text);
			oProyectoConvenioBE.MontoPagado=NullableDouble.Parse(this.txtMontoPagado.Text);
			oProyectoConvenioBE.IdConvenioSimaMgp=Convert.ToInt32(this.Page.Request.Params[KEYIDCONVENIOSIMAMGP]);
			oProyectoConvenioBE.IdUsuarioRegistro=CNetAccessControl.GetIdUser();
			oProyectoConvenioBE.IdTablaEstado=Convert.ToInt32(Utilitario.Enumerados.TablasTabla.EstadoProyectoConvenio);
			oProyectoConvenioBE.IdEstado=Convert.ToInt32(this.ddlbEstado.SelectedValue);
			oProyectoConvenioBE.Descripcion=this.txtDescripcion.Text;
			oProyectoConvenioBE.Observaciones=this.txtObservaciones.Text;
			oProyectoConvenioBE.AvanceFisico=NullableDouble.Parse(this.txtAvanceFisico.Text);

			if (hIdProyecto.Value!=string.Empty)
			{
				oProyectoConvenioBE.IdProyecto=Convert.ToInt32(hIdProyecto.Value);
			}

			if(filContrato.PostedFile.FileName!=String.Empty)
			{
				string strFilename = filContrato.PostedFile.FileName;
				string[] res = strFilename.Split('\\');
				int i=res.GetUpperBound(0);
				strFilename = res[i];
				oProyectoConvenioBE.Archivo = strFilename;			
			}
			

			CProyectoConvenio oCProyectoConvenio=new CProyectoConvenio();
			
			int retorno=oCProyectoConvenio.Insertar(oProyectoConvenioBE);

			if(retorno==Utilitario.Constantes.VALORCONFIRMACIONREGISTRO)
			{
				//Graba en el Log la acción ejecutada
				this.GuardarContrato();

				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Convenio Sima Mgp",this.ToString(),"Se registró Item de Proyecto Convenio " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));

				string strUrlGoBack = URLPRINCIPAL + KEYIDCONVENIOSIMAMGP + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYIDCONVENIOSIMAMGP] +
					Utilitario.Constantes.SIGNOAMPERSON + KEYQNROCONVENIO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYQNROCONVENIO] +
					Utilitario.Constantes.SIGNOAMPERSON + KEYIDIDENTIFICADOR + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYIDIDENTIFICADOR];
				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionConvenios.ToString(),Mensajes.CONVENIOREGISTROPROYECTOCONVENIO),strUrlGoBack.ToString());
			
			}
			else
			{
				ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerMensajesErrorConvenioUsuario(retorno.ToString()));
			}
		}

		public void Modificar()
		{
			ProyectoConvenioBE oProyectoConvenioBE=new ProyectoConvenioBE();
			oProyectoConvenioBE.IdProyectoConvenio=Convert.ToInt32(Page.Request.Params[KEYIDPROYECTOCONVENIO]);
			oProyectoConvenioBE.NroProyecto=Convert.ToInt32(this.nbNroProyecto.Text);
			oProyectoConvenioBE.Descripcion=this.txtDescripcion.Text;
			oProyectoConvenioBE.Observaciones=this.txtObservaciones.Text;
			oProyectoConvenioBE.MontoAsignado=NullableDouble.Parse(this.nbMontoAsignado.Text);
			oProyectoConvenioBE.MontoComprometido=NullableDouble.Parse(this.nbMontoComprometido.Text);
			oProyectoConvenioBE.MontoEnEjecucion=NullableDouble.Parse(this.nbMontoEnEjecucion.Text);
			oProyectoConvenioBE.MontoPagado=NullableDouble.Parse(this.txtMontoPagado.Text);
			oProyectoConvenioBE.MontoEjecutado=NullableDouble.Parse(this.nbMontoEjecutado.Text);
			oProyectoConvenioBE.IdEstado=Convert.ToInt32(this.ddlbEstado.SelectedValue);
			oProyectoConvenioBE.IdUsuarioActualizacion=CNetAccessControl.GetIdUser();
			oProyectoConvenioBE.IdTablaEstado=Convert.ToInt32(Utilitario.Enumerados.TablasTabla.EstadoProyectoConvenio);
			oProyectoConvenioBE.AvanceFisico=NullableDouble.Parse(this.txtAvanceFisico.Text);

			if (hIdProyecto.Value!=string.Empty)
			{
				oProyectoConvenioBE.IdProyecto=Convert.ToInt32(hIdProyecto.Value);
			}


			CProyectoConvenio oCProyectoConvenio=new CProyectoConvenio();

			if(filContrato.Value!=String.Empty)
			{
				string strFilename = filContrato.PostedFile.FileName;
				string[] res = strFilename.Split('\\');
				int i=res.GetUpperBound(0);
				strFilename = res[i];
							
				oProyectoConvenioBE.Archivo = strFilename;
			}
			else
			{
				if(hContrato.Value!=String.Empty)  
				{
					oProyectoConvenioBE.Archivo = hContrato.Value;	
				}
			}

			int retorno=oCProyectoConvenio.Modificar(oProyectoConvenioBE);		

			if(retorno>0)
			{
				this.GuardarContrato();
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo
					(new LogAplicativo(CNetAccessControl.GetUserName(),"Convenio",this.ToString(),"Se modificó Item de " + 
					oCProyectoConvenio.ToString(),Enumerados.NivelesErrorLog.I.ToString()));
				//Elabora el Query string para luego redireccionar a la pagina que invoco esta accion
				string strUrlGoBack = URLPRINCIPAL + KEYIDCONVENIOSIMAMGP + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYIDCONVENIOSIMAMGP] +
					Utilitario.Constantes.SIGNOAMPERSON + KEYQNROCONVENIO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYQNROCONVENIO] +
					Utilitario.Constantes.SIGNOAMPERSON + KEYIDIDENTIFICADOR + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYIDIDENTIFICADOR];
				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionConvenios.ToString(),Utilitario.Mensajes.CODIGOMENSAJECONFIRMACIONMODIFICACIONPROYECTOCONVENIO),strUrlGoBack.ToString());

			}
		}

		public void Eliminar()
		{
			// TODO:  Add DetalleProyectoConvenio.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			// TODO:  Add DetalleProyectoConvenio.CargarModoPagina implementation
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
			this.lblTitulo.Text="REGISTRAR PROYECTO >> Convenio SIMA MGP " + this.Page.Request.Params[KEYQNROCONVENIO];
		}

		public void CargarModoModificar()
		{
			this.nbNroProyecto.Enabled=false;
			this.lblTitulo.Text="CONVENIO SIMA MGP " + this.Page.Request.Params[KEYQNROCONVENIO];
			CProyectoConvenio oCProyectoConvenio=new CProyectoConvenio();
			ProyectoConvenioBE oProyectoConvenioBE=(ProyectoConvenioBE)oCProyectoConvenio.DetalleProyectoConvenio(Convert.ToInt32(this.Page.Request.Params[KEYIDPROYECTOCONVENIO]));
			if(oProyectoConvenioBE!=null)
			{
				this.nbNroProyecto.Text=oProyectoConvenioBE.NroProyecto.ToString();
				this.txtDescripcion.Text=oProyectoConvenioBE.Descripcion.ToString();
				if(!oProyectoConvenioBE.MontoAsignado.IsNull)
				{
					this.nbMontoAsignado.Text=NullableString.Parse(oProyectoConvenioBE.MontoAsignado).ToString();
				}
				if(!oProyectoConvenioBE.MontoComprometido.IsNull)
				{
					this.nbMontoComprometido.Text=NullableString.Parse(oProyectoConvenioBE.MontoComprometido).ToString();
				}
				if(!oProyectoConvenioBE.MontoEnEjecucion.IsNull)
				{
					this.nbMontoEnEjecucion.Text=NullableString.Parse(oProyectoConvenioBE.MontoEnEjecucion).ToString();
				}
				if(!oProyectoConvenioBE.MontoEjecutado.IsNull)
				{
					this.nbMontoEjecutado.Text=NullableString.Parse(oProyectoConvenioBE.MontoEjecutado).ToString();
				}

				if(!oProyectoConvenioBE.MontoPagado.IsNull)
				{
					this.txtMontoPagado.Text=NullableString.Parse(oProyectoConvenioBE.MontoPagado).ToString();
				}

				if(!oProyectoConvenioBE.AvanceFisico.IsNull)
				{
					this.txtAvanceFisico.Text=NullableString.Parse(oProyectoConvenioBE.AvanceFisico).ToString();
				}
				item=this.ddlbEstado.Items.FindByValue(oProyectoConvenioBE.IdEstado.ToString());
				if(item!=null)
				{item.Selected=true;}
				
				if(!oProyectoConvenioBE.Observaciones.IsNull)
				{
					this.txtObservaciones.Text=oProyectoConvenioBE.Observaciones.ToString();
				}

				if(!oProyectoConvenioBE.Archivo.IsNull)
				{
					hContrato.Value = oProyectoConvenioBE.Archivo.Value;
				}

				if(!oProyectoConvenioBE.IdProyecto.IsNull)
				{
					this.hIdProyecto.Value=oProyectoConvenioBE.IdProyecto.ToString();
					this.txtConcepto.Text=oProyectoConvenioBE.Proyectoejecucion.ToString();
				}

			}
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add DetalleProyectoConvenio.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			if(NullableInt32.Parse(nbNroProyecto.Text).IsNull)
			{
				this.ltlMensaje.Text=Helper.MensajeAlert(Helper.ObtenerMensajesErrorConvenioUsuario(Mensajes.CONVENIOMENSAJEASIGANARNUMEROPROYECTO));
				return false;
			}
			if(NullableString.Parse(this.txtDescripcion.Text).IsNull)
			{
				this.ltlMensaje.Text=Helper.MensajeAlert(Helper.ObtenerMensajesErrorConvenioUsuario(Mensajes.CONVENIOMENSAJEDESCRIPCIONPROYECTOVACIO));
				return false;
			}
			return true;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add DetalleProyectoConvenio.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add DetalleProyectoConvenio.ValidarExpresionesRegulares implementation
			return false;
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
			this.EstadoProyectoConvenioSimaMgp();
		}
		
		public void LlenarDatos()
		{
			if(Convert.ToInt32(Page.Request.QueryString[KEYIDIDENTIFICADOR]) == 1)
				lblRutaPagina.Text = lblRutaPagina.Text + " COMOPERA>";
			else
				lblRutaPagina.Text = lblRutaPagina.Text + " SIMA - MGP>";
		}

		public void LlenarJScript()
		{
			this.rqdvProyecto.ErrorMessage=Helper.ObtenerMensajesErrorConvenioUsuario(Mensajes.CONVENIOMENSAJEASIGANARNUMEROPROYECTO);
			this.rqdvDescripcion.ErrorMessage=Helper.ObtenerMensajesErrorConvenioUsuario(Mensajes.CONVENIOMENSAJEDESCRIPCIONPROYECTOVACIO);
			
			ibtnBuscarProyecto.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.PopupBusqueda(URLBUSQUEDAPROYECTO,730,500,true));
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
			return false;
		}

		#endregion
		#region Constantes
		const string URLPRINCIPAL="AdministracionProyectoConvenio.aspx?";

		const string KEYIDCONVENIOSIMAMGP="IdConvenioSimaMgp";
		const string KEYIDPROYECTOCONVENIO="IdProyectoConvenio";
		const string KEYQNROCONVENIO="NroConvenio";
		const string KEYIDIDENTIFICADOR= "IdIdentificador";

		const string URLBUSQUEDAPROYECTO = "../Legal/BusquedaProyectosObras.aspx?";
		#endregion Constantes
		#region Controles

		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected eWorld.UI.NumericBox nbNroProyecto;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rqdvProyecto;
		protected System.Web.UI.WebControls.Label lblNroProyecto;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rqdvDescripcion;
		protected System.Web.UI.WebControls.Label lblDescripcion;
		protected eWorld.UI.NumericBox nbMontoAsignado;
		protected System.Web.UI.WebControls.Label lblMonto;
		protected eWorld.UI.NumericBox nbMontoComprometido;
		protected System.Web.UI.WebControls.Label Label3;
		protected eWorld.UI.NumericBox nbMontoEnEjecucion;
		protected System.Web.UI.WebControls.Label Label2;
		protected eWorld.UI.NumericBox nbMontoEjecutado;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DropDownList ddlbEstado;
		protected System.Web.UI.WebControls.Label lblEstado;
		protected System.Web.UI.WebControls.TextBox txtObservaciones;
		protected System.Web.UI.WebControls.Label lblObservaciones;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary DomValidationSummary1;
		protected eWorld.UI.NumericBox txtAvanceFisico;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.HtmlControls.HtmlInputFile filContrato;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hContrato;
		protected System.Web.UI.WebControls.Label Label5;
		protected eWorld.UI.NumericBox txtMontoPagado;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.TextBox txtConcepto;
		protected System.Web.UI.WebControls.Image ibtnBuscarProyecto;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdProyecto;
		#region Variables
		ListItem item=new ListItem();
		#endregion

	
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
					this.LlenarDatos();
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


		

	
		private void RedireccionarPaginaPrincipal()
		{
			this.Page.Response.Redirect(URLPRINCIPAL + KEYIDCONVENIOSIMAMGP + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYIDCONVENIOSIMAMGP] +
				Utilitario.Constantes.SIGNOAMPERSON + KEYQNROCONVENIO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYQNROCONVENIO]);
		}

		private void EstadoProyectoConvenioSimaMgp()
		{
			CTablaTablas oCTablaTablas=new CTablaTablas();
			DataView dw=oCTablaTablas.ListaSegunCriterioFiltro(Convert.ToInt32(Utilitario.Enumerados.TablasTabla.EstadoProyectoConvenio),Utilitario.Enumerados.ColumnasTablaTablas.Codigo.ToString() + "<>" + Convert.ToInt32(Utilitario.Enumerados.EstadoProyectoConvenio.ELIMINADO).ToString(),Utilitario.Enumerados.ColumnasTablaTablas.Codigo.ToString() + " ASC");
			this.ddlbEstado.DataSource=dw;
			this.ddlbEstado.DataValueField=Enumerados.ColumnasTablaTablas.Codigo.ToString();
			this.ddlbEstado.DataTextField=Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			this.ddlbEstado.DataBind();
		}


		

		


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

		private void WriteToFile(string strPath, ref byte[] Buffer)
		{
			FileStream newFile = new FileStream(strPath,FileMode.Create);	
			newFile.Write(Buffer, 0, Buffer.Length);
			newFile.Close();
		}

		public void GuardarContrato() 
		{
			HttpPostedFile myFile = filContrato.PostedFile;
			int nFileLen = myFile.ContentLength; 
					
			if( nFileLen > 0 )
			{
				if(nFileLen <= 5000000)
				{	
					byte[] myData = new byte[nFileLen];

					myFile.InputStream.Read(myData, 0, nFileLen);

					string path = Helper.ObtenerRutaImagenes(Utilitario.Constantes.RUTAIMAGENES);
					string strFilename = myFile.FileName;

					string[] res = strFilename.Split('\\');
					int i=res.GetUpperBound(0);
					strFilename = res[i];
							
					WriteToFile(path + strFilename,ref myData);	
				}
			}		
		}
	}
}