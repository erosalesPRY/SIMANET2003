using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using SIMA.SimaNetWeb.InterfacesIU;
using SIMA.Controladoras.GestionComercial;
using SIMA.Controladoras.General;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using SIMA.EntidadesNegocio.GestionComercial;
using SIMA.EntidadesNegocio.General;

namespace SIMA.SimaNetWeb.GestionComercial.Ventas
{
	/// <summary>
	/// Summary description for DetalleObservacionesVentas.
	/// </summary>
	public class DetalleObservacionesVentas: System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblCentroOperativo;
		protected System.Web.UI.WebControls.DropDownList ddlbCentroOperativo;
		protected System.Web.UI.WebControls.Label lblFecha;
		protected eWorld.UI.CalendarPopup calFecha;
		protected System.Web.UI.WebControls.Label lblInfo;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary vSum;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.Label lblObservacion;
		protected System.Web.UI.WebControls.TextBox txtObservacion;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvObservacion;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvCentroOperativo;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DropDownList ddlbTipoObservacion;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator Requireddomvalidator1;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvTipoObservacion;
		#endregion
		
		#region Constantes
		
		//Titulos 
		const string TITULOMODONUEVO = "NUEVA OBSERVACION MENSUAL DE VENTA";
		const string TITULOMODOMODIFICAR = "OBSERVACION MENSUAL DE VENTA";

		//Key Session y QueryString
		const string KEYQID = "Id";
		const string KEYTIPOOBSERVACION="TipoObervacion";
	
		//Paginas

		//Otros
		const int DIAPORDEFECTO = 1;
		const string MENSUAL    = "MENSUAL";
		const string ACUMULADA  = "ACUMULADA";
		
		#endregion Constantes


		

		#region Variables
		
		ListItem  lItem ;
		
		#endregion
		
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

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add DetalleObservacionesVentas.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetalleObservacionesVentas.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetalleObservacionesVentas.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			lItem = new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,Utilitario.Constantes.VALORSELECCIONAR);
			this.llenarCentrosOperativos();
			this.llenarTipoObservaciones();
			this.ddlbCentroOperativo.Items.Insert(Constantes.POSICIONCONTADOR,lItem);
		}

		public void LlenarDatos()
		{
			// TODO:  Add DetalleObservacionesVentas.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			this.rfvCentroOperativo.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEOBSERVACIONMENSUALVENTASCAMPOREQUERIDOCENTROOPERATIVO);
			this.rfvCentroOperativo.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEOBSERVACIONMENSUALVENTASCAMPOREQUERIDOCENTROOPERATIVO);
			this.rfvCentroOperativo.InitialValue = Constantes.VALORSELECCIONAR;


			this.rfvTipoObservacion.ErrorMessage ="Seleccione un Tipo de Observacion";
			this.rfvTipoObservacion.ToolTip = "Seleccione un Tipo de Observacion";
			this.rfvTipoObservacion.InitialValue = Constantes.VALORSELECCIONAR;

			this.rfvObservacion.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEOBSERVACIONMENSUALVENTASCAMPOREQUERIDOOBSERVACION);
			this.rfvObservacion.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEOBSERVACIONMENSUALVENTASCAMPOREQUERIDOOBSERVACION);
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetalleObservacionesVentas.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetalleObservacionesVentas.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetalleObservacionesVentas.Exportar implementation
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
			// TODO:  Add DetalleObservacionesVentas.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			ObservacionesVentasBE oObservacionesVentasBE = new ObservacionesVentasBE();
			oObservacionesVentasBE.Periodo = this.calFecha.SelectedDate.Year;
			oObservacionesVentasBE.Mes = this.calFecha.SelectedDate.Month;
			if(this.txtObservacion.Text.Length > this.txtObservacion.MaxLength)
			{
					oObservacionesVentasBE.Observacion = this.txtObservacion.Text.Substring(Constantes.POSICIONCONTADOR,this.txtObservacion.MaxLength);
					oObservacionesVentasBE.TipoObservacion=Convert.ToInt32(ddlbTipoObservacion.SelectedIndex);
			}
			else
			{
				oObservacionesVentasBE.Observacion = this.txtObservacion.Text;
				oObservacionesVentasBE.TipoObservacion=Convert.ToInt32(ddlbTipoObservacion.SelectedIndex);
			}

			oObservacionesVentasBE.IdCentroOperativo = Convert.ToInt32(this.ddlbCentroOperativo.SelectedValue);
			oObservacionesVentasBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();
			oObservacionesVentasBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.EstadoObservacionesVentas);
			oObservacionesVentasBE.IdEstado = Convert.ToInt32(Enumerados.EstadoObservacionesVentas.Activo);

			CVentasReales oCVentasReales = new CVentasReales();

			int retorno = oCVentasReales.AgregarObservacionesDelMes(oObservacionesVentasBE);

			if(retorno>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se registró la Observacion Mensual de Venta. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));

				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionComercial.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONREGISTROOBSERVACIONMENSUALVENTAS));
			}
		}

		public void Modificar()
		{
			ObservacionesVentasBE oObservacionesVentasBE = new ObservacionesVentasBE();
			oObservacionesVentasBE.IdObservaciones = Convert.ToInt32(Page.Request.QueryString[KEYQID]);
			oObservacionesVentasBE.Periodo = this.calFecha.SelectedDate.Year;
			oObservacionesVentasBE.Mes = this.calFecha.SelectedDate.Month;
			if(this.txtObservacion.Text.Length > this.txtObservacion.MaxLength)
			{
				oObservacionesVentasBE.Observacion = this.txtObservacion.Text.Substring(Constantes.POSICIONCONTADOR,this.txtObservacion.MaxLength);
				oObservacionesVentasBE.TipoObservacion=Convert.ToInt32(ddlbTipoObservacion.SelectedIndex);
			}
			else
			{
				oObservacionesVentasBE.Observacion = this.txtObservacion.Text;
				oObservacionesVentasBE.TipoObservacion=Convert.ToInt32(ddlbTipoObservacion.SelectedIndex);
			}

			oObservacionesVentasBE.IdCentroOperativo = Convert.ToInt32(this.ddlbCentroOperativo.SelectedValue);
			oObservacionesVentasBE.IdUsuarioActualizacion = CNetAccessControl.GetIdUser();
			oObservacionesVentasBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.EstadoObservacionesVentas);
			oObservacionesVentasBE.IdEstado = Convert.ToInt32(Enumerados.EstadoObservacionesVentas.Modificado);

			CVentasReales oCVentasReales = new CVentasReales();

			int retorno = oCVentasReales.ModificarObservacionesDelMes(oObservacionesVentasBE);

			if(retorno>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se modificó la Observacion Mensual de Venta Nro. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));

				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionComercial.ToString(),Mensajes.CODIGOMENSAJEMODIFICACIONREGISTROOBSERVACIONMENSUALVENTAS));
			}
		}

		public void Eliminar()
		{
			// TODO:  Add DetalleObservacionesVentas.Eliminar implementation
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
			
			CVentasReales	oCVentasReales = new CVentasReales();
			ObservacionesVentasBE oObservacionesVentasBE = (ObservacionesVentasBE)oCVentasReales.ListarDetalleObservacionMensualVenta(Convert.ToInt32(Page.Request.QueryString[KEYQID]));
			
			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionComercial",this.ToString(),"Se consultó el Detalle de la Observaciones Mensual de Venta Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

			if(oObservacionesVentasBE!=null)
			{
				if(Convert.ToInt32(oObservacionesVentasBE.TipoObservacion)==1)
				{
					
					ddlbTipoObservacion.Items.FindByValue("MENSUAL").Selected=true;
					this.txtObservacion.Text = oObservacionesVentasBE.Observacion;
				}
				else
				{
					ddlbTipoObservacion.Items.FindByValue("ACUMULADA").Selected=true;
					this.txtObservacion.Text = oObservacionesVentasBE.Observacion;
					
				}
				this.calFecha.SelectedDate = new DateTime(oObservacionesVentasBE.Periodo,oObservacionesVentasBE.Mes,DIAPORDEFECTO);
				this.ddlbCentroOperativo.Items.FindByValue(oObservacionesVentasBE.IdCentroOperativo.ToString()).Selected = true;
			}
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add DetalleObservacionesVentas.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			return this.ValidarCamposRequeridos();
		}

		public bool ValidarCamposRequeridos()
		{
			if(this.ddlbCentroOperativo.SelectedItem.Text==Constantes.TEXTOSSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEOBSERVACIONMENSUALVENTASCAMPOREQUERIDOCENTROOPERATIVO));
				return false;
			}
			if(this.ddlbTipoObservacion.SelectedItem.Text==Constantes.TEXTOSSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.MensajeAlert("Seleccione un Tipo de Observacion");
				return false;
			}
			if(this.txtObservacion.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEOBSERVACIONMENSUALVENTASCAMPOREQUERIDOOBSERVACION));
				return false;
			}
			return true;
		}

		public bool ValidarExpresionesRegulares()
		{
			return false;
		}

		#endregion

		private void llenarCentrosOperativos()
		{
			CCentroOperativo oCCentroOperativo =  new CCentroOperativo();
			ddlbCentroOperativo.DataSource = oCCentroOperativo.ListarCentroOperativoAccesoSegunPrivilegioUsuario(CNetAccessControl.GetIdUser(), Convert.ToInt32(Enumerados.TablasTabla.EstadoObservacionesVentas));
			ddlbCentroOperativo.DataValueField=Enumerados.ColumnasCentroOperativo.IdCentroOperativo.ToString();
			ddlbCentroOperativo.DataTextField=Enumerados.ColumnasCentroOperativo.Nombre.ToString();
			ddlbCentroOperativo.DataBind();
			this.ddlbCentroOperativo.Items.RemoveAt(Constantes.POSICIONCONTADOR);
		}
		private void llenarTipoObservaciones()
		{
			lItem = new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,Utilitario.Constantes.VALORSELECCIONAR);
		
			this.ddlbTipoObservacion.Items.Insert(Constantes.POSICIONCONTADOR,lItem);
			ddlbTipoObservacion.Items.Insert(1, MENSUAL);
			ddlbTipoObservacion.Items.Insert(2, ACUMULADA);
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