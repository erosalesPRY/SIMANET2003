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


namespace SIMA.SimaNetWeb.Convenio
{
	/// <summary>
	/// Aqui se permite agregar y modificar una OT de un convenio COMOPERPAC dado en un
	/// periodo, cada vez que se agrega una OT en la base de datos de simanet 
	/// se agrega tambien en el unysis.
	/// Este formulario ya paso por refactoring
	/// </summary>
	public class DetalleOrdenTrabajoComoperpac : System.Web.UI.Page, IPaginaBase, IPaginaMantenimento
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
			this.ibtnCancelar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnCancelar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		#region IPaginaMantenimento Members
		public void Agregar()
		{
			if(Convert.ToInt32(Utilitario.Enumerados.IdCentroOperativo.SimaCallao)==Convert.ToInt32(this.ddlbCentroOperativo.SelectedValue))
			{
				OrdenTrabajoUnidadApoyoBE oOrdenTrabajoUnidadApoyoBE=new OrdenTrabajoUnidadApoyoBE();
				COrdenTrabajoUnidadApoyo oCOrdenTrabajoUnidadApoyo=new COrdenTrabajoUnidadApoyo();

				oOrdenTrabajoUnidadApoyoBE.IdCentroOperativo=Convert.ToInt32(this.ddlbCentroOperativo.SelectedValue);
				oOrdenTrabajoUnidadApoyoBE.NroOrdenTrabajo=this.ddlbDivision.SelectedItem.Text +  Convert.ToInt32(this.nbNumero.Text).ToString(FORMATOCEROS);
				oOrdenTrabajoUnidadApoyoBE.IdPeriodoUnidadesApoyo=Convert.ToInt32(this.Page.Request.Params[KEYIDPERIODOUNIDADESAPOYO]);
				oOrdenTrabajoUnidadApoyoBE.IdTablaEstado=Convert.ToInt32(Utilitario.Enumerados.TablasTabla.ConvenioEstadoValorizacionConvenio);
				oOrdenTrabajoUnidadApoyoBE.IdEstado=Convert.ToInt32(Utilitario.Enumerados.ConvenioEstadoValorizacionConvenio.EnEjecucion);
				oOrdenTrabajoUnidadApoyoBE.IdUsuarioRegistro=CNetAccessControl.GetIdUser();
				int retorno= Utilitario.Constantes.ValorConstanteCero;
				retorno=oCOrdenTrabajoUnidadApoyo.InsertarCallao(oOrdenTrabajoUnidadApoyoBE);
				
				if(retorno==Utilitario.Constantes.VALORCONFIRMACIONREGISTRO)
				{
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Utilitario.Enumerados.NombresdeModulo.ConveniosyProyectos.ToString(),this.ToString(), MENSAJEREGISTRAR,Enumerados.NivelesErrorLog.I.ToString()));

					string strUrlGoBack = URLPRINCIPAL + KEYIDPERIODOUNIDADESAPOYO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYIDPERIODOUNIDADESAPOYO] +
					Utilitario.Constantes.SIGNOAMPERSON + KEYQPERIODO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYQPERIODO] +
					Utilitario.Constantes.SIGNOAMPERSON + KEYIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + this.ddlbCentroOperativo.SelectedValue +
					Utilitario.Constantes.SIGNOAMPERSON + KEYIDESTADO + Utilitario.Constantes.SIGNOIGUAL + this.ddlbEstado.SelectedValue +
					Utilitario.Constantes.SIGNOAMPERSON + KEYQNROORDENTRABAJO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request[KEYQNROORDENTRABAJO];;

					ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionConvenios.ToString(),Mensajes.CONVENIOREGISTROEXITOSO),strUrlGoBack.ToString());
				}
				else
				{
					ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerMensajesErrorConvenioUsuario(retorno.ToString()));
				}
			}
			else
			{
				OrdenTrabajoUnidadApoyoBE oOrdenTrabajoUnidadApoyoBE=new OrdenTrabajoUnidadApoyoBE();
				COrdenTrabajoUnidadApoyo oCOrdenTrabajoUnidadApoyo=new COrdenTrabajoUnidadApoyo();

				oOrdenTrabajoUnidadApoyoBE.IdCentroOperativo=Convert.ToInt32(this.ddlbCentroOperativo.SelectedValue);
				oOrdenTrabajoUnidadApoyoBE.IdPeriodoUnidadesApoyo=Convert.ToInt32(this.Page.Request.Params[KEYIDPERIODOUNIDADESAPOYO]);
				oOrdenTrabajoUnidadApoyoBE.NroOrdenTrabajo=this.ddlbDivision.SelectedItem.Text + Convert.ToInt32(this.nbNumero.Text).ToString(FORMATOCEROS);
				oOrdenTrabajoUnidadApoyoBE.MontoAsignado=NullableDouble.Parse(this.nbMontoAsignado.Text);
				oOrdenTrabajoUnidadApoyoBE.IdTablaMoneda=NullableInt32.Parse(Utilitario.Enumerados.TablasTabla.Moneda);
				oOrdenTrabajoUnidadApoyoBE.IdMoneda=NullableInt32.Parse(this.ddlbMoneda.SelectedValue);
				oOrdenTrabajoUnidadApoyoBE.IdTablaEstado=Convert.ToInt32(Utilitario.Enumerados.TablasTabla.ConvenioEstadoValorizacionConvenio);
				oOrdenTrabajoUnidadApoyoBE.IdEstado=Convert.ToInt32(this.ddlbEstado.SelectedValue);
				oOrdenTrabajoUnidadApoyoBE.FechaEmisionOdenTrabajo=this.CalFechaPresupuesto.SelectedDate;
				oOrdenTrabajoUnidadApoyoBE.Descripcion=NullableString.Parse(this.txtDescripcion.Text);
				oOrdenTrabajoUnidadApoyoBE.Observaciones=NullableString.Parse(this.txtObservaciones.Text);
				oOrdenTrabajoUnidadApoyoBE.IdUsuarioRegistro=CNetAccessControl.GetIdUser();

				int retorno=Utilitario.Constantes.ValorConstanteCero;
				retorno=oCOrdenTrabajoUnidadApoyo.Insetar(oOrdenTrabajoUnidadApoyoBE);
				
				if(retorno==Utilitario.Constantes.VALORCONFIRMACIONREGISTRO)
				{
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Utilitario.Enumerados.NombresdeModulo.ConveniosyProyectos.ToString(),this.ToString(), MENSAJEREGISTRAR,Enumerados.NivelesErrorLog.I.ToString()));

					string strUrlGoBack = URLPRINCIPAL + KEYIDPERIODOUNIDADESAPOYO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYIDPERIODOUNIDADESAPOYO] +
						Utilitario.Constantes.SIGNOAMPERSON + KEYQPERIODO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYQPERIODO] +
						Utilitario.Constantes.SIGNOAMPERSON + KEYIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + this.ddlbCentroOperativo.SelectedValue +
						Utilitario.Constantes.SIGNOAMPERSON + KEYIDESTADO + Utilitario.Constantes.SIGNOIGUAL + this.ddlbEstado.SelectedValue;
					ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionConvenios.ToString(),Mensajes.CONVENIOREGISTROEXITOSO),strUrlGoBack.ToString());
				}
				else
				{
					ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerMensajesErrorConvenioUsuario(retorno.ToString()));
				}

			}
		}

		public void Modificar()
		{
			OrdenTrabajoUnidadApoyoBE oOrdenTrabajoUnidadApoyoBE=new OrdenTrabajoUnidadApoyoBE();
			
			oOrdenTrabajoUnidadApoyoBE.IdOrdenTrabajoUnidadApoyo=Convert.ToInt32(this.Page.Request.Params[KEYIDORDENTRABAJOUNIDADAPOYO]);
			oOrdenTrabajoUnidadApoyoBE.IdPeriodoUnidadesApoyo=Convert.ToInt32(this.Page.Request.Params[KEYIDPERIODOUNIDADESAPOYO]);
			oOrdenTrabajoUnidadApoyoBE.IdCentroOperativo=Convert.ToInt32(this.ddlbCentroOperativo.SelectedValue);
			oOrdenTrabajoUnidadApoyoBE.NroOrdenTrabajo=this.ddlbDivision.SelectedItem.Text + Convert.ToInt32(this.nbNumero.Text).ToString("000000");
			oOrdenTrabajoUnidadApoyoBE.MontoAsignado=NullableDouble.Parse(this.nbMontoAsignado.Text);
			oOrdenTrabajoUnidadApoyoBE.IdTablaMoneda=NullableInt32.Parse(Utilitario.Enumerados.TablasTabla.Moneda);
			oOrdenTrabajoUnidadApoyoBE.IdMoneda=NullableInt32.Parse(this.ddlbMoneda.SelectedValue);
			oOrdenTrabajoUnidadApoyoBE.IdTablaEstado=Convert.ToInt32(Utilitario.Enumerados.TablasTabla.ConvenioEstadoValorizacionConvenio);
			oOrdenTrabajoUnidadApoyoBE.IdEstado=Convert.ToInt32(this.ddlbEstado.SelectedValue);
			oOrdenTrabajoUnidadApoyoBE.FechaEmisionOdenTrabajo=this.CalFechaPresupuesto.SelectedDate;
			oOrdenTrabajoUnidadApoyoBE.Descripcion=this.txtDescripcion.Text;
			oOrdenTrabajoUnidadApoyoBE.Observaciones=this.txtObservaciones.Text;
			oOrdenTrabajoUnidadApoyoBE.IdUsuarioActualizacion=CNetAccessControl.GetIdUser();

			int retorno=Utilitario.Constantes.ValorConstanteCero;
			COrdenTrabajoUnidadApoyo oCOrdenTrabajoUnidadApoyo=new COrdenTrabajoUnidadApoyo();
			retorno=oCOrdenTrabajoUnidadApoyo.Modificar(oOrdenTrabajoUnidadApoyoBE);

			if(retorno>Utilitario.Constantes.ValorConstanteCero)
			{
				LogAplicativo.GrabarLogAplicativoArchivo
					(new LogAplicativo(CNetAccessControl.GetUserName(),Utilitario.Enumerados.NombresdeModulo.ConveniosyProyectos.ToString(),this.ToString(), MENSAJEMODIFICAR  + 
					oOrdenTrabajoUnidadApoyoBE.IdOrdenTrabajoUnidadApoyo.ToString() + Utilitario.Constantes.ValorConstanteCero ,Enumerados.NivelesErrorLog.I.ToString()));

				string strUrlGoBack = URLPRINCIPAL + KEYIDPERIODOUNIDADESAPOYO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYIDPERIODOUNIDADESAPOYO] +
					Utilitario.Constantes.SIGNOAMPERSON + KEYQPERIODO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYQPERIODO] +
					Utilitario.Constantes.SIGNOAMPERSON + KEYIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + this.ddlbCentroOperativo.SelectedValue +
					Utilitario.Constantes.SIGNOAMPERSON + KEYIDESTADO + Utilitario.Constantes.SIGNOIGUAL + this.ddlbEstado.SelectedValue;

				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionConvenios.ToString(),Utilitario.Mensajes.CODIGOMENSAJECONFIRMACIONMODIFICACIONREGISTROSELECCIONADO),strUrlGoBack.ToString());
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
			this.lblTitulo.Text="REGISTRAR ORDEN DE TRABAJO - PERIODO " + this.Page.Request.Params[KEYQPERIODO];
			if(Convert.ToInt32(this.Page.Request.Params[KEYIDCENTROOPERATIVO])==Convert.ToInt32(Utilitario.Enumerados.IdCentroOperativo.SimaCallao ))
			{
				this.lblMontoAsignado.Visible=Utilitario.Constantes.VALORUNCHECKEDBOOL;
				this.lblEstado.Visible=Utilitario.Constantes.VALORUNCHECKEDBOOL;
				this.lblFechaPresupuesto.Visible=Utilitario.Constantes.VALORUNCHECKEDBOOL;
				this.lblDescripcion.Visible=Utilitario.Constantes.VALORUNCHECKEDBOOL;
				this.lblObservaciones.Visible=Utilitario.Constantes.VALORUNCHECKEDBOOL;
				this.nbMontoAsignado.Visible=Utilitario.Constantes.VALORUNCHECKEDBOOL;
				this.ddlbEstado.Visible=Utilitario.Constantes.VALORUNCHECKEDBOOL;
				this.ddlbMoneda.Visible=Utilitario.Constantes.VALORUNCHECKEDBOOL;
				this.CalFechaPresupuesto.Visible=Utilitario.Constantes.VALORUNCHECKEDBOOL;
				this.txtDescripcion.Visible=Utilitario.Constantes.VALORUNCHECKEDBOOL;
				this.txtObservaciones.Visible=Utilitario.Constantes.VALORUNCHECKEDBOOL;
				this.ddlbCentroOperativo.Enabled=Utilitario.Constantes.VALORUNCHECKEDBOOL;
				
				lItem=this.ddlbCentroOperativo.Items.FindByValue(Convert.ToInt32(Utilitario.Enumerados.IdCentroOperativo.SimaCallao).ToString());
				if(lItem!=null)
				{
					lItem.Selected=true;
				}
			}
			else
			{
				lItem=this.ddlbCentroOperativo.Items.FindByValue(Convert.ToInt32(Utilitario.Enumerados.IdCentroOperativo.SimaCallao).ToString());
				this.ddlbCentroOperativo.Items.Remove(lItem);
				lItem=this.ddlbCentroOperativo.Items.FindByValue(this.Page.Request.Params[KEYIDCENTROOPERATIVO]);
				if(lItem!=null)
				{
					lItem.Selected=Utilitario.Constantes.VALORCHECKEDBOOL;
				}
			}
			
		}

		public void CargarModoModificar()
		{
			OrdenTrabajoUnidadApoyoBE oOrdenTrabajoUnidadApoyoBE=new OrdenTrabajoUnidadApoyoBE();
			COrdenTrabajoUnidadApoyo oCOrdenTrabajoUnidadApoyo=new COrdenTrabajoUnidadApoyo();
			oOrdenTrabajoUnidadApoyoBE=(OrdenTrabajoUnidadApoyoBE)oCOrdenTrabajoUnidadApoyo.ConsultarDetalleOrdenTrabajo(Convert.ToInt32(this.Page.Request.Params[KEYIDORDENTRABAJOUNIDADAPOYO]));

			lItem=this.ddlbCentroOperativo.Items.FindByValue(oOrdenTrabajoUnidadApoyoBE.IdCentroOperativo.ToString());
			if(lItem!=null)
			{
				lItem.Selected=Utilitario.Constantes.VALORCHECKEDBOOL;
			}
			string Divicion=oOrdenTrabajoUnidadApoyoBE.NroOrdenTrabajo.Substring(VALORSUBSTRINGINICIO,VALORSUBSTRINGFIN);
			string NumeroOt=oOrdenTrabajoUnidadApoyoBE.NroOrdenTrabajo.Substring(VALORSUBSTRINGFIN);

			this.ddlbDivision.SelectedItem.Text=Divicion;
			this.nbNumero.Text=NumeroOt;

			this.nbMontoAsignado.Text=oOrdenTrabajoUnidadApoyoBE.MontoAsignado.ToString();

			lItem=this.ddlbMoneda.Items.FindByValue(oOrdenTrabajoUnidadApoyoBE.IdMoneda.ToString());
			if(lItem!=null)
			{
				lItem.Selected=Utilitario.Constantes.VALORCHECKEDBOOL;
			}

			lItem=this.ddlbEstado.Items.FindByValue(oOrdenTrabajoUnidadApoyoBE.IdEstado.ToString());
			if(lItem!=null)
			{
				lItem.Selected=Utilitario.Constantes.VALORCHECKEDBOOL;
			}

			this.CalFechaPresupuesto.SelectedDate=Convert.ToDateTime(oOrdenTrabajoUnidadApoyoBE.FechaEmisionOdenTrabajo);
			this.txtObservaciones.Text=oOrdenTrabajoUnidadApoyoBE.Observaciones.ToString();
			this.txtDescripcion.Text=oOrdenTrabajoUnidadApoyoBE.Descripcion.ToString();

			
			this.ddlbCentroOperativo.Enabled= Utilitario.Constantes.VALORUNCHECKEDBOOL;
			this.ddlbDivision.Enabled=Utilitario.Constantes.VALORUNCHECKEDBOOL;
			this.nbNumero.Enabled=Utilitario.Constantes.VALORUNCHECKEDBOOL;
			this.nbMontoAsignado.Enabled=Utilitario.Constantes.VALORUNCHECKEDBOOL;
			this.ddlbMoneda.Enabled=Utilitario.Constantes.VALORUNCHECKEDBOOL;
			this.CalFechaPresupuesto.Enabled=Utilitario.Constantes.VALORUNCHECKEDBOOL;

			if(Convert.ToInt32(Utilitario.Enumerados.IdCentroOperativo.SimaCallao)==Convert.ToInt32(this.Page.Request.Params[KEYIDCENTROOPERATIVO]))
			{
				this.txtDescripcion.ReadOnly=Utilitario.Constantes.VALORCHECKEDBOOL;
			}
		}

		public void CargarModoConsulta()
		{
		}

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
			this.CentroOperativoSima();
			this.Divicion();
			this.LlenarEstado();
			this.Moneda();
		}

		public void LlenarDatos()
		{
			this.pIdCentroOperativo=Convert.ToInt32(this.Page.Request.Params[KEYIDCENTROOPERATIVO]);
			this.pEstadoOrdenTrabajoComoperpac=Convert.ToInt32(this.Page.Request.Params[KEYIDESTADO]);
			this.rqdvNumero.ErrorMessage=Helper.ObtenerMensajesErrorConvenioUsuario(Mensajes.CONVENIOREQUIERENROORDENTRABAJO);
		}

		public void LlenarJScript()
		{}

		public void RegistrarJScript()
		{}

		public void Imprimir()
		{}

		public void Exportar()
		{}

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
		//Keys
		private const string KEYIDPERIODOUNIDADESAPOYO="IdPeriodoUnidadesApoyo";
		private const string KEYQPERIODO="Periodo";
		private const string KEYIDCENTROOPERATIVO="IdCentroOperativo";
		private const string KEYIDESTADO="IdEstado";
		private const string KEYIDORDENTRABAJOUNIDADAPOYO="IdOrdenTrabajoUnidadApoyo";
		private const string KEYQNROORDENTRABAJO="NroOrdenTrabajo";
		
		//URL's
		private const string URLPRINCIPAL="AdministrarOrdenTrabajoComoperpac.aspx?";
		
		//Otros
		private const string FORMATOCEROS="000000";

		//Mensajes
		private const string MENSAJEREGISTRAR="Se registró una Orden de Trabajo";
		private const string MENSAJEMODIFICAR="Se modificó la Orden de Trabajo Nro.";
		private const int VALORSUBSTRINGINICIO=0;
		private const int VALORSUBSTRINGFIN=2;

		#endregion Constantes
		#region Variables
		private int pIdCentroOperativo=0;
		private int pEstadoOrdenTrabajoComoperpac=0;
		private ListItem lItem=new ListItem();
		#endregion
		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.Label lblCentroOperativo;
		protected System.Web.UI.WebControls.Label lblDivicion;
		protected System.Web.UI.WebControls.Label lblMontoAsignado;
		protected System.Web.UI.WebControls.Label lblEstado;
		protected System.Web.UI.WebControls.Label lblDescripcion;
		protected System.Web.UI.WebControls.Label lblObservaciones;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.TextBox txtObservaciones;
		protected System.Web.UI.WebControls.DropDownList ddlbCentroOperativo;
		protected System.Web.UI.WebControls.DropDownList ddlbEstado;
		protected System.Web.UI.WebControls.DropDownList ddlbDivision;
		protected eWorld.UI.NumericBox nbNumero;
		protected System.Web.UI.WebControls.DropDownList ddlbMoneda;
		protected eWorld.UI.NumericBox nbMontoAsignado;
		protected eWorld.UI.CalendarPopup CalFechaPresupuesto;
		protected System.Web.UI.WebControls.Label lblFechaPresupuesto;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rqdvNumero;
		protected System.Web.UI.WebControls.ImageButton ibtnCancelar;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary DomValidationSummary1;
		#endregion	
		#region Eventos
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
				    this.ConfigurarAccesoControles();

					Helper.ReiniciarSession();
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

		private void CentroOperativoSima()
		{
			SIMA.Controladoras.General.CCentroOperativo oCCentroOperativo=new CCentroOperativo();
			DataTable dt=oCCentroOperativo.ListarTodosCombo();
			this.ddlbCentroOperativo.DataSource=dt;
			this.ddlbCentroOperativo.DataValueField=Enumerados.ColumnasCentroOperativo.IdCentroOperativo.ToString();
			this.ddlbCentroOperativo.DataTextField=Enumerados.ColumnasCentroOperativo.Descripcion.ToString();
			this.ddlbCentroOperativo.DataBind();
			lItem=this.ddlbCentroOperativo.Items.FindByValue(Convert.ToInt32(Utilitario.Enumerados.IdCentroOperativo.SimaPeru).ToString());
			this.ddlbCentroOperativo.Items.Remove(lItem);
		}

		private void Divicion()
		{
			CTablaTablas oCTablaTablas=new CTablaTablas();
			DataView dv=oCTablaTablas.ListaSegunCriterioFiltro(Convert.ToInt32(Utilitario.Enumerados.TablasTabla.DivisionesOt),Utilitario.Enumerados.ColumnasTablaTablas.Flg1.ToString() + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.ValorConstanteUno.ToString());
			this.ddlbDivision.DataSource=dv;
			this.ddlbDivision.DataValueField = Utilitario.Enumerados.ColumnasTablaTablas.Codigo.ToString();
			this.ddlbDivision.DataTextField = Utilitario.Enumerados.ColumnasTablaTablas.Var1.ToString();
			this.ddlbDivision.DataBind();
		}

		private void LlenarEstado()
		{
			CTablaTablas oCTablaTablas=new CTablaTablas();
			string CadenaFiltro=Utilitario.Enumerados.ColumnasTablaTablas.Var1.ToString() + Utilitario.Constantes.SIGNOIGUAL  + Utilitario.Constantes.ValorConstanteUno.ToString();
			DataView dv=oCTablaTablas.ListaSegunCriterioFiltro(Convert.ToInt32(Utilitario.Enumerados.TablasTabla.ConvenioEstadoValorizacionConvenio),CadenaFiltro);
			this.ddlbEstado.DataSource=dv;
			this.ddlbEstado.DataValueField=Enumerados.ColumnasTablaTablas.Codigo.ToString();
			this.ddlbEstado.DataTextField=Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			this.ddlbEstado.DataBind();
		}

		private void Moneda()
		{
			CTablaTablas oCTablaTablas=new CTablaTablas();
			string CadenaFiltro=Utilitario.Enumerados.ColumnasTablaTablas.Flg1.ToString() + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.ValorConstanteUno.ToString();
			string CadenaOrdenamiento=Utilitario.Enumerados.ColumnasTablaTablas.Codigo + Utilitario.Constantes.ESPACIO + Utilitario.Constantes.ORDENDESC;
			DataView dv=oCTablaTablas.ListaSegunCriterioFiltro(Convert.ToInt32(Utilitario.Enumerados.TablasTabla.Moneda),CadenaFiltro,CadenaOrdenamiento);
			this.ddlbMoneda.DataSource=dv;
			this.ddlbMoneda.DataValueField=Enumerados.ColumnasTablaTablas.Codigo.ToString();
			this.ddlbMoneda.DataTextField=Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			this.ddlbMoneda.DataBind();

		}

		private void RedireccionarPaginaPrincipal()
		{
			this.Page.Response.Redirect(URLPRINCIPAL + KEYIDPERIODOUNIDADESAPOYO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYIDPERIODOUNIDADESAPOYO] +
			Utilitario.Constantes.SIGNOAMPERSON + KEYQPERIODO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYQPERIODO] +
			Utilitario.Constantes.SIGNOAMPERSON + KEYIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYIDCENTROOPERATIVO] +
			Utilitario.Constantes.SIGNOAMPERSON + KEYIDESTADO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYIDESTADO]);
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

		private void ibtnCancelar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect (URLPRINCIPAL +KEYIDPERIODOUNIDADESAPOYO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYIDPERIODOUNIDADESAPOYO]+
			Utilitario.Constantes.SIGNOAMPERSON + KEYQPERIODO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYQPERIODO] + 
			Utilitario.Constantes.SIGNOAMPERSON + KEYIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + KEYIDCENTROOPERATIVO + 
			Utilitario.Constantes.SIGNOAMPERSON + KEYIDESTADO + Utilitario.Constantes.SIGNOIGUAL + KEYIDESTADO);
		}

		#endregion		
		
	}
}
