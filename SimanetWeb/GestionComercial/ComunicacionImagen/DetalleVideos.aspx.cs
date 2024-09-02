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
using SIMA.Controladoras.GestionComercial;
using SIMA.Controladoras.General;
using SIMA.EntidadesNegocio.GestionComercial;

namespace SIMA.SimaNetWeb.GestionComercial.ComunicacionImagen
{
	/// <summary>
	/// Summary description for DetalleVideos.
	/// </summary>
	public class DetalleVideos: System.Web.UI.Page, IPaginaMantenimento, IPaginaBase
	{
		#region Controles

		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary vSum;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.Label lblDescripcion;
		protected System.Web.UI.WebControls.Label lblObservaciones;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.TextBox txtObservaciones;
		protected System.Web.UI.WebControls.Label lblRutaFisica;
		protected System.Web.UI.WebControls.TextBox txtRutaFisica;
		protected System.Web.UI.WebControls.Label lblFormato;
		protected System.Web.UI.WebControls.DropDownList ddlbFormato;
		protected System.Web.UI.WebControls.Label lblCodigoVideo;
		protected System.Web.UI.WebControls.TextBox txtCodigoVideo;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvCodigoVideo;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvFormato;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvRutaFisica;
		protected System.Web.UI.HtmlControls.HtmlTableCell TdCeldaCancelar;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnCancelar;

		#endregion Controles
		
		#region Constantes
		
		//Titulos 
		const string TITULOMODONUEVO = "NUEVO VIDEO";
		const string TITULOMODOMODIFICAR = "ACTUALIZACION DE VIDEO";
		const string TITULOMODOCONSULTA = "DETALLE DE VIDEO";

		//Key Session y QueryString
		const string KEYQID = "Id";
		const string KEYQDESCRIPCION = "Descripcion";
		const string KEYTIPO = "Tipo";
		const string KEYQIDVIDEO = "IdVideo";
	
		#endregion Constantes				

		#region Variables
		ListItem  lItem ;
		#endregion Variables		
		
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
			VideoBE oVideoBE = new VideoBE();
			oVideoBE.CodigoVideo = this.txtCodigoVideo.Text;
			oVideoBE.RutaFisica = this.txtRutaFisica.Text;
			oVideoBE.IdTablaFormato = Convert.ToInt32(Enumerados.TablasTabla.FormatosVideos);
			oVideoBE.IdFormato = Convert.ToInt32(this.ddlbFormato.SelectedValue);
			if(Page.Request.QueryString[KEYTIPO] == Enumerados.TipoEntidadConFoto.Buque.ToString())
			{
				oVideoBE.IdBuque = Convert.ToInt32(Page.Request.QueryString[KEYQID]);
			}
			else if(Page.Request.QueryString[KEYTIPO] == Enumerados.TipoEntidadConFoto.Visita.ToString())
			{
				oVideoBE.IdVisitas = Convert.ToInt32(Page.Request.QueryString[KEYQID]);
			}
			oVideoBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();
			oVideoBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.EstadosVideo);
			oVideoBE.IdEstado = Convert.ToInt32(Enumerados.EstadosVideo.Activo);
			if(this.txtDescripcion.Text.Trim()!=String.Empty)
			{
				oVideoBE.Descripcion = this.txtDescripcion.Text;
			}
			if(this.txtObservaciones.Text.Trim()!=String.Empty)
			{
				oVideoBE.Observaciones = this.txtObservaciones.Text;
			}

			CMantenimientos oCMantenimientos = new CMantenimientos();
			int retorno = oCMantenimientos.Insertar(oVideoBE);

			if(retorno>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se registró el Video Nro. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));

				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionComercial.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONREGISTROVIDEO));
			}
		}

		public void Modificar()
		{
			VideoBE oVideoBE = new VideoBE();
			oVideoBE.IdCodigoVideo = Convert.ToInt32(Page.Request.QueryString[KEYQIDVIDEO]);
			oVideoBE.CodigoVideo = this.txtCodigoVideo.Text;
			oVideoBE.RutaFisica = this.txtRutaFisica.Text;
			oVideoBE.IdTablaFormato = Convert.ToInt32(Enumerados.TablasTabla.FormatosVideos);
			oVideoBE.IdFormato = Convert.ToInt32(this.ddlbFormato.SelectedValue);
			if(Page.Request.QueryString[KEYTIPO] == Enumerados.TipoEntidadConFoto.Buque.ToString())
			{
				oVideoBE.IdBuque = Convert.ToInt32(Page.Request.QueryString[KEYQID]);
			}
			else if(Page.Request.QueryString[KEYTIPO] == Enumerados.TipoEntidadConFoto.Visita.ToString())
			{
				oVideoBE.IdVisitas = Convert.ToInt32(Page.Request.QueryString[KEYQID]);
			}
			oVideoBE.IdUsuarioActualizacion = CNetAccessControl.GetIdUser();
			oVideoBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.EstadosVideo);
			oVideoBE.IdEstado = Convert.ToInt32(Enumerados.EstadosVideo.Modificado);
			if(this.txtDescripcion.Text.Trim()!=String.Empty)
			{
				oVideoBE.Descripcion = this.txtDescripcion.Text;
			}
			if(this.txtObservaciones.Text.Trim()!=String.Empty)
			{
				oVideoBE.Observaciones = this.txtObservaciones.Text;
			}

			CMantenimientos oCMantenimientos = new CMantenimientos();
			int retorno = oCMantenimientos.Modificar(oVideoBE);

			if(retorno>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se modificó el Video Nro. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));

				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionComercial.ToString(),Mensajes.CODIGOMENSAJEMODIFICACIONREGISTROVIDEO));
			}
		}

		public void Eliminar()
		{
			// TODO:  Add DetalleVideos.Eliminar implementation
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
			this.TdCeldaCancelar.Visible = false;
			lblTitulo.Text = TITULOMODONUEVO;
			this.LlenarCombos();
		}

		public void CargarModoModificar()
		{
			this.TdCeldaCancelar.Visible = false;
			lblTitulo.Text = TITULOMODOMODIFICAR;
			this.LlenarCombos();
			
			CMantenimientos	oCMantenimientos = new CMantenimientos();
			VideoBE oVideoBE = (VideoBE)oCMantenimientos.ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYQIDVIDEO]),Enumerados.ClasesNTAD.VideoNTAD.ToString());
			
			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionComercial",this.ToString(),"Se consultó el Detalle del Video Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

			if(oVideoBE!=null)
			{
				this.txtCodigoVideo.Text = oVideoBE.CodigoVideo;
				this.txtRutaFisica.Text = oVideoBE.RutaFisica;
				this.ddlbFormato.Items.FindByValue(oVideoBE.IdFormato.ToString()).Selected = true;
				if(!oVideoBE.Descripcion.IsNull)
				{
					this.txtDescripcion.Text = oVideoBE.Descripcion.ToString();
				}
				if(!oVideoBE.Observaciones.IsNull)
				{
					this.txtObservaciones.Text = oVideoBE.Observaciones.ToString();
				}
			}
		}

		public void CargarModoConsulta()
		{
			this.ibtnCancelar.Visible = false;
			lblTitulo.Text = TITULOMODOCONSULTA;
			this.LlenarCombos();
			
			CMantenimientos	oCMantenimientos = new CMantenimientos();
			VideoBE oVideoBE = (VideoBE)oCMantenimientos.ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYQIDVIDEO]),Enumerados.ClasesNTAD.VideoNTAD.ToString());
			
			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionComercial",this.ToString(),"Se consultó el Detalle del Video Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

			if(oVideoBE!=null)
			{
				this.txtCodigoVideo.Text = oVideoBE.CodigoVideo;
				this.txtRutaFisica.Text = oVideoBE.RutaFisica;
				this.ddlbFormato.Items.FindByValue(oVideoBE.IdFormato.ToString()).Selected = true;
				if(!oVideoBE.Descripcion.IsNull)
				{
					this.txtDescripcion.Text = oVideoBE.Descripcion.ToString();
				}
				if(!oVideoBE.Observaciones.IsNull)
				{
					this.txtObservaciones.Text = oVideoBE.Observaciones.ToString();
				}
			}
			Helper.BloquearControles(this);
		}

		public bool ValidarCampos()
		{
			return this.ValidarCamposRequeridos();
		}

		public bool ValidarCamposRequeridos()
		{
			if(this.txtCodigoVideo.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEVIDEOCAMPOREQUERIDOCODIGO));
				return false;
			}
			if(this.txtRutaFisica.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEVIDEOCAMPOREQUERIDORUTAFISICA));
				return false;
			}
			if(this.ddlbFormato.SelectedItem.Text == Constantes.TEXTOSSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEVIDEOCAMPOREQUERIDOFORMATO));
				return false;
			}
			return true;
		}

		public bool ValidarExpresionesRegulares()
		{
			return false;
		}

		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add DetalleVideos.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetalleVideos.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetalleVideos.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			lItem = new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,Utilitario.Constantes.VALORSELECCIONAR);
			this.llenarFormatos();
			this.ddlbFormato.Items.Insert(0,lItem);
		}

		public void LlenarDatos()
		{
			// TODO:  Add DetalleVideos.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			this.rfvCodigoVideo.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEVIDEOCAMPOREQUERIDOCODIGO);
			this.rfvCodigoVideo.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEVIDEOCAMPOREQUERIDOCODIGO);

			this.rfvRutaFisica.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEVIDEOCAMPOREQUERIDORUTAFISICA);
			this.rfvRutaFisica.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEVIDEOCAMPOREQUERIDORUTAFISICA);

			this.rfvFormato.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEVIDEOCAMPOREQUERIDOFORMATO);
			this.rfvFormato.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEVIDEOCAMPOREQUERIDOFORMATO);
			this.rfvFormato.InitialValue = Constantes.VALORSELECCIONAR;
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetalleVideos.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetalleVideos.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetalleVideos.Exportar implementation
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

		private void llenarFormatos()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			ddlbFormato.DataSource = oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Enumerados.TablasTabla.FormatosVideos));
			ddlbFormato.DataValueField =Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbFormato.DataTextField =Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbFormato.DataBind();
		}

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
	}
}