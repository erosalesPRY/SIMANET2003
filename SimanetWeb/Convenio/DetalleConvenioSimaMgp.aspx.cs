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
using SIMA.EntidadesNegocio.Convenio;
using SIMA.Controladoras.Convenio;
using SIMA.Controladoras.General;
using SIMA.Controladoras;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using NullableTypes;
using System.IO;

namespace SIMA.SimaNetWeb.Convenio
{
	/// <summary>
	/// Aquí se le presenta el detalle de la administracion de los convenios con la Mgp
	/// Se puede Modificar y Agregar, el nombre del periodo no lo puedes cambiar, sin embargo
	/// se puede eliminar y volver a crear otro.
	/// Este formulario ya paso por REFACTORY
	/// </summary>
	public class AdministracionConvenioSimaMgp : System.Web.UI.Page, IPaginaBase, IPaginaMantenimento
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
			ConvenioSimaMgpBE oConvenioSimaMgpBE=new ConvenioSimaMgpBE();
			oConvenioSimaMgpBE.NroConvenio=this.nbPeriodo.Text + Utilitario.Constantes.SIGNOMENOS + Convert.ToInt32(this.nbNumero.Text).ToString(FORMATO2CEROS);
			oConvenioSimaMgpBE.Periodo=Convert.ToInt32(this.nbPeriodo.Text);
			oConvenioSimaMgpBE.Descripcion=NullableString.Parse(this.txtDescripcion.Text);
			oConvenioSimaMgpBE.IdEstadoConvenio=Convert.ToInt32(this.ddlbEstado.SelectedValue);
			oConvenioSimaMgpBE.IdSituacionPago=Convert.ToInt32(this.ddlbSituacionPago.SelectedValue);
			oConvenioSimaMgpBE.FechaVencimiento=Convert.ToDateTime(this.CalFechaVencimiento.SelectedDate);
			oConvenioSimaMgpBE.Observaciones=NullableString.Parse(this.txtObservaciones.Text);
			oConvenioSimaMgpBE.IdUsuarioActualizacion=CNetAccessControl.GetIdUser();
			oConvenioSimaMgpBE.MontoAutorizado=NullableDouble.Parse(nbMontoAUTORIZADO.Text);

			oConvenioSimaMgpBE.MontoFianza=NullableDouble.Parse(txtCartaFianza.Text);
			oConvenioSimaMgpBE.ObservacionesFianza=NullableString.Parse(this.txtObservacionesFianza.Text);
			
			if(Page.Request.QueryString[KEYIDIDENTIFICADOR] != null)
				oConvenioSimaMgpBE.IdIdentificador = NullableInt32.Parse(Page.Request.QueryString[KEYIDIDENTIFICADOR]);
					
			if(filContrato.PostedFile.FileName!=String.Empty)
			{
				string strFilename = filContrato.PostedFile.FileName;
				string[] res = strFilename.Split('\\');
				int i=res.GetUpperBound(0);
				strFilename = res[i];
				oConvenioSimaMgpBE.Archivo = strFilename;
			}

			CMantenimientos oCMantenimientos = new CMantenimientos();
			int retorno = oCMantenimientos.Insertar(oConvenioSimaMgpBE);

			if(retorno>=Utilitario.Constantes.VALORCONFIRMACIONREGISTRO)
			{
				this.GuardarContrato();

				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Utilitario.Enumerados.NombresdeModulo.ConveniosyProyectos.ToString(),this.ToString(),MENSAJEREGISTRO + retorno.ToString() + Utilitario.Constantes.SIMBOLOPUNTO,Enumerados.NivelesErrorLog.I.ToString()));
				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionConvenios.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONMODIFICACIONNUEVOCONVENIOSIMAMGP)) ;
			}
			else
			{
				ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerMensajesErrorConvenioUsuario(retorno.ToString()));
			}

		}

		public void Modificar()
		{
			ConvenioSimaMgpBE oConvenioSimaMgpBE=new ConvenioSimaMgpBE();
			oConvenioSimaMgpBE.IdConvenioSimaMgp=Convert.ToInt32(this.Page.Request.Params[KEYIDCONVENIOSIMAMGP]);
			oConvenioSimaMgpBE.Descripcion=NullableString.Parse(this.txtDescripcion.Text);
			oConvenioSimaMgpBE.IdEstadoConvenio=Convert.ToInt32(this.ddlbEstado.SelectedValue);
			oConvenioSimaMgpBE.IdSituacionPago=Convert.ToInt32(this.ddlbSituacionPago.SelectedValue);
			oConvenioSimaMgpBE.FechaVencimiento=Convert.ToDateTime(this.CalFechaVencimiento.SelectedDate);
			oConvenioSimaMgpBE.Observaciones=NullableString.Parse(this.txtObservaciones.Text);
			oConvenioSimaMgpBE.IdUsuarioActualizacion=CNetAccessControl.GetIdUser();
			oConvenioSimaMgpBE.MontoAutorizado=NullableDouble.Parse(this.nbMontoAUTORIZADO.Text);

			oConvenioSimaMgpBE.MontoFianza=NullableDouble.Parse(txtCartaFianza.Text);
			oConvenioSimaMgpBE.ObservacionesFianza=NullableString.Parse(this.txtObservacionesFianza.Text);


			if(filContrato.Value!=String.Empty)
			{
				string strFilename = filContrato.PostedFile.FileName;
				string[] res = strFilename.Split('\\');
				int i=res.GetUpperBound(0);
				strFilename = res[i];
							
				oConvenioSimaMgpBE.Archivo = strFilename;
			}
			else
			{
				if(hContrato.Value!=String.Empty)  
				{
					oConvenioSimaMgpBE.Archivo = hContrato.Value;	
				}
			}

			CMantenimientos oCMantenimientos = new CMantenimientos();
			int retorno = oCMantenimientos.Modificar(oConvenioSimaMgpBE);

			if(retorno > Utilitario.Constantes.ValorConstanteCero)
			{
				this.GuardarContrato();

				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Utilitario.Enumerados.NombresdeModulo.ConveniosyProyectos.ToString(),this.ToString(),MENSAJEREGISTRO + retorno.ToString() + Utilitario.Constantes.SIMBOLOPUNTO,Enumerados.NivelesErrorLog.I.ToString()));
				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionConvenios.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONMODIFICACIONNUEVOCONVENIOSIMAMGP)) ;
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

		public void Eliminar()
		{}

		public void CargarModoPagina()
		{
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
			this.CalFechaVencimiento.Text=DateTime.Now.Day.ToString().PadLeft(2,'0') + "/" + DateTime.Now.Month.ToString().PadLeft(2,'0') + "/" + DateTime.Now.Year.ToString();
		}

		public void CargarModoModificar()
		{
			this.lblPeriodo.Visible=false;
			this.lblNumero.Visible=false;
			this.nbPeriodo.Visible=false;
			this.nbNumero.Visible=false;
			this.rdvPeriodo.Enabled=false;
			this.rqdvNumero.Enabled=false;
			this.rqdvPeriodo.Enabled=false;
			
			CConvenioSimaMgp oCConvenioSimaMgp=new CConvenioSimaMgp();
			ConvenioSimaMgpBE oConvenioSimaMgpBE=(ConvenioSimaMgpBE)oCConvenioSimaMgp.DetalleDeUnConvenioSimaMgp(Convert.ToInt32(Page.Request.Params[KEYIDCONVENIOSIMAMGP]));
			
			this.txtNroConvenio.Text=oConvenioSimaMgpBE.NroConvenio.ToString();
			if(!oConvenioSimaMgpBE.Descripcion.IsNull)
			{
				this.txtDescripcion.Text=oConvenioSimaMgpBE.Descripcion.ToString();
			}
			if(!oConvenioSimaMgpBE.MontoAutorizado.IsNull)
			{
				this.nbMontoAUTORIZADO.Text = oConvenioSimaMgpBE.MontoAutorizado.Value.ToString();
			}
			item = this.ddlbEstado.Items.FindByValue(oConvenioSimaMgpBE.IdEstadoConvenio.ToString());
			if(item!=null)
			{item.Selected = true;}
			item = this.ddlbSituacionPago.Items.FindByValue(oConvenioSimaMgpBE.IdSituacionPago.ToString());
			if(item!=null)
			{item.Selected=true;}
			this.CalFechaVencimiento.SelectedDate=Convert.ToDateTime(oConvenioSimaMgpBE.FechaVencimiento);
			if(!oConvenioSimaMgpBE.Observaciones.IsNull)
			{
				this.txtObservaciones.Text=oConvenioSimaMgpBE.Observaciones.ToString();
			}

			if(!oConvenioSimaMgpBE.MontoFianza.IsNull)
			{
				this.txtCartaFianza.Text = oConvenioSimaMgpBE.MontoFianza.Value.ToString();
			}

			if(!oConvenioSimaMgpBE.ObservacionesFianza.IsNull)
			{
				this.txtObservacionesFianza.Text=oConvenioSimaMgpBE.ObservacionesFianza.ToString();
			}

			if(!oConvenioSimaMgpBE.Archivo.IsNull)
			{
				hContrato.Value = oConvenioSimaMgpBE.Archivo.Value;
			}

		}

		public void CargarModoConsulta()
		{}

		public bool ValidarCampos()
		{
			return true;
		}

		public bool ValidarCamposRequeridos()
		{
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			return false;
		}

		#endregion
		#region IPaginaBase Members
		public void LlenarGrilla()
		{}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{}

		public void LlenarCombos()
		{
			this.EstadoDeConvenioSimaMgp();
			this.SituacionDePagoConvenioSimaMgp();
		}

		public void LlenarDatos()
		{}

		public void LlenarJScript()
		{
			this.rdvPeriodo.ErrorMessage=Helper.ObtenerMensajesErrorConvenioUsuario(Mensajes.CODIGOMENSAJECONVENIOERRORRANGOPERIODO);
			this.rqdvPeriodo.ErrorMessage=Helper.ObtenerMensajesErrorConvenioUsuario(Mensajes.CODIGOMENSAJECONVENIOERRORCAMPOPERIODOVACIO);
			this.rqdvNumero.ErrorMessage=Helper.ObtenerMensajesErrorConvenioUsuario(Mensajes.CODIGOMENSAJECONVENIOERRORCAMPONUMEROVACIO);
		}

		public void RegistrarJScript()
		{}

		public void Imprimir()
		{}

		public void Exportar()
		{}

		public void ConfigurarAccesoControles()
		{}

		public bool ValidarFiltros()
		{
			return false;
		}

		#endregion
		#region Constantes

		//KEYs
		private const string KEYIDIDENTIFICADOR= "IdIdentificador";
		private const string KEYIDCONVENIOSIMAMGP = "IdConvenioSimaMgp";
		private const string URLPRINCIPAL = "AdministracionConsultarConvenioSimaMgp.aspx?";

		//Mensaje
		private const string MENSAJEREGISTRO="Se registro el Convenio";
		private const string MENSAJEMODIFICO="Se modificó Item de ";

		#endregion
		#region Controles
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPeriodo;
		protected eWorld.UI.NumericBox nbPeriodo;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rqdvPeriodo;
		protected System.Web.UI.WebControls.DomValidators.RangeDomValidator rdvPeriodo;
		protected System.Web.UI.WebControls.Label lblNumero;
		protected eWorld.UI.NumericBox nbNumero;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rqdvNumero;
		protected System.Web.UI.WebControls.Label lblNroConvenio;
		protected System.Web.UI.WebControls.TextBox txtNroConvenio;
		protected System.Web.UI.WebControls.Label lblDescripcion;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.Label lblEstado;
		protected System.Web.UI.WebControls.DropDownList ddlbEstado;
		protected System.Web.UI.WebControls.Label lblSitucionPago;
		protected System.Web.UI.WebControls.DropDownList ddlbSituacionPago;
		protected System.Web.UI.WebControls.Label lblFechaVencimiento;
		protected eWorld.UI.CalendarPopup CalFechaVencimiento;
		protected System.Web.UI.WebControls.Label lblObservaciones;
		protected System.Web.UI.WebControls.TextBox txtObservaciones;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary DomValidationSummary1;
		protected System.Web.UI.WebControls.Label Label1;
		#endregion
		#region Variables
		private ListItem item =  new ListItem();
		protected System.Web.UI.WebControls.Label Label2;
		protected eWorld.UI.NumericBox nbMontoAUTORIZADO;
		protected System.Web.UI.WebControls.Label Label3;
		protected eWorld.UI.NumericBox txtCartaFianza;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.TextBox txtObservacionesFianza;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.HtmlControls.HtmlInputFile filContrato;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hContrato;
		private string FORMATO2CEROS="00";
		#endregion
		#region Eventos
		
		private void ibtnCancelar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect(URLPRINCIPAL);
		}
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
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
					SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Utilitario.Constantes.CODIGOERRORGENERICO,oException.Message);
					Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
				}
			}
		}

		
		
		private void EstadoDeConvenioSimaMgp()
		{
			CTablaTablas oCTablaTablas=new CTablaTablas();
			string CadenaFiltro=Utilitario.Enumerados.ColumnasTablaTablas.Codigo.ToString() + Utilitario.Constantes.SIGNODIFERENTEQUE + Convert.ToInt32(Utilitario.Enumerados.TablaEstadoConvenioSimaMgp.ELIMINADO).ToString();
			DataView dv=oCTablaTablas.ListaSegunCriterioFiltro(Convert.ToInt32(Utilitario.Enumerados.TablasTabla.TablaEstadoConvenioSimaMgp),CadenaFiltro);
			this.ddlbEstado.DataSource=dv;
			this.ddlbEstado.DataValueField=Enumerados.ColumnasTablaTablas.Codigo.ToString();
			this.ddlbEstado.DataTextField=Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			this.ddlbEstado.DataBind();
		}

		private void SituacionDePagoConvenioSimaMgp()
		{
			CTablaTablas oCTablaTablas=new CTablaTablas();
			DataTable dt=oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Utilitario.Enumerados.TablasTabla.ConvenioSituacionPagoConvenioSimaMgp));
			this.ddlbSituacionPago.DataSource=dt;
			this.ddlbSituacionPago.DataValueField=Enumerados.ColumnasTablaTablas.Codigo.ToString();
			this.ddlbSituacionPago.DataTextField=Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			this.ddlbSituacionPago.DataBind();
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
		#endregion

	}
}
