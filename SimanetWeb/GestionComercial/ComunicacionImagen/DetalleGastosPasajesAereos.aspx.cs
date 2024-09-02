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
using MetaBuilders.WebControls;
using SIMA.Controladoras.General;
using SIMA.Controladoras.Secretaria;
using SIMA.Controladoras.GestionComercial;
using SIMA.EntidadesNegocio.GestionComercial;

namespace SIMA.SimaNetWeb.GestionComercial.ComunicacionImagen
{
	/// <summary>
	/// Summary description for DetalleGastosPasajesAereos.
	/// </summary>
	public class DetalleGastosPasajesAereos: System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		#region Controles
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary vSum;
		protected System.Web.UI.WebControls.TextBox txtOT;
		protected System.Web.UI.WebControls.Label lblOT;
		protected System.Web.UI.WebControls.TextBox txtCentroCosto;
		protected System.Web.UI.WebControls.Label lblCentroCosto;
		protected System.Web.UI.WebControls.RadioButtonList rblTipoGasto;
		protected System.Web.UI.WebControls.TextBox txtMoneda;
		protected System.Web.UI.WebControls.Label lblMoneda;
		protected System.Web.UI.WebControls.Label lblMonto;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvPasajeAereo;
		protected System.Web.UI.WebControls.ImageButton ibtnBuscarPasajeAereo;
		protected System.Web.UI.WebControls.TextBox txtPasajeAereo;
		protected System.Web.UI.WebControls.Label lblPasajeAereo;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvPersonal;
		protected System.Web.UI.WebControls.ImageButton ibtnBuscarPersonal;
		protected System.Web.UI.WebControls.TextBox txtPersonal;
		protected System.Web.UI.WebControls.Label lblNombres;
		protected eWorld.UI.CalendarPopup CalFechaDocumento;
		protected System.Web.UI.WebControls.Label lblFechaDocumento;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvTipoDocumento;
		protected System.Web.UI.WebControls.DropDownList ddlbTipoDocumento;
		protected System.Web.UI.WebControls.Label lblTipoDocumento;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvDocumento;
		protected System.Web.UI.WebControls.TextBox txtDocumento;
		protected System.Web.UI.WebControls.Label lblNroDocumento;
		protected System.Web.UI.WebControls.Label lblMensaje;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdCentroCosto;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdGrupoCentroCosto;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdValorizacionOrdenTrabajo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdPersonal;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdPasajeAereo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdMoneda;
		protected eWorld.UI.NumericBox txtMonto;
		protected System.Web.UI.WebControls.ImageButton ibtnBuscarCentroCosto;
		protected System.Web.UI.WebControls.ImageButton ibtnBuscarOT;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnCancelar;
		#endregion
		
		#region Constantes
		//Paginas
		const string URLBUSQUEDACENTROCOSTO = "../BusquedaCentroCosto.aspx";
		const string URLBUSQUEDAPERSONAL = "../../Legal/BusquedaPersonal.aspx";
		const string URLBUSQUEDAORDENTRABAJO = "../BusquedaOrdenTrabajo.aspx";
		const string URLBUSQUEDAPASAJESAEREOS = "../BusquedaPasajesAereos.aspx";

		//Key Session y QueryString
		const string KEYQID = "Id";

		//Otros
		const string TITULOMODONUEVO = "NUEVO GASTO DE PASAJE AEREO";
		const string TITULOMODOMODIFICAR = "GASTO PASAJE AEREO";
		const int CentroCosto = 0;
		const int OrdenTrabajo = 1;
		const string CadenaVacia = "";

		#endregion

		#region Variables
		ListItem  lItem ;
		#endregion Variables

		private void llenarTipoDocumento()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			ddlbTipoDocumento.DataSource = oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Enumerados.TablasTabla.SecretariaTipoDocumento));
			ddlbTipoDocumento.DataValueField =Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbTipoDocumento.DataTextField =Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbTipoDocumento.DataBind();
		}

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
			this.rblTipoGasto.SelectedIndexChanged += new System.EventHandler(this.rblTipoGasto_SelectedIndexChanged);
			this.ibtnAceptar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAceptar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add DetalleGastosPasajesAereos.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetalleGastosPasajesAereos.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetalleGastosPasajesAereos.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			lItem = new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,Utilitario.Constantes.VALORSELECCIONAR);
			this.llenarTipoDocumento();
			this.ddlbTipoDocumento.Items.Insert(0,lItem);
		}

		public void LlenarDatos()
		{
			// TODO:  Add DetalleGastosPasajesAereos.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			this.ibtnBuscarCentroCosto.Attributes.Add(Constantes.EVENTOCLICK,Helper.PopupBusqueda(URLBUSQUEDACENTROCOSTO,750,500,true));
			this.ibtnBuscarOT.Attributes.Add(Constantes.EVENTOCLICK,Helper.PopupBusqueda(URLBUSQUEDAORDENTRABAJO,750,500,true));
			this.ibtnBuscarPersonal.Attributes.Add(Constantes.EVENTOCLICK,Helper.PopupBusqueda(URLBUSQUEDAPERSONAL,750,500,true));
			this.ibtnBuscarPasajeAereo.Attributes.Add(Constantes.EVENTOCLICK,Helper.PopupBusqueda(URLBUSQUEDAPASAJESAEREOS,750,500,true));

			this.rfvDocumento.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEGASTOPASAJEAEREOCAMPOREQUERIDODOCUMENTO);
			this.rfvDocumento.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEGASTOPASAJEAEREOCAMPOREQUERIDODOCUMENTO);

			this.rfvTipoDocumento.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEGASTOPASAJEAEREOCAMPOREQUERIDOTIPODOCUMENTO);
			this.rfvTipoDocumento.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEGASTOPASAJEAEREOCAMPOREQUERIDOTIPODOCUMENTO);
			this.rfvTipoDocumento.InitialValue = Constantes.VALORSELECCIONAR;

			this.rfvPersonal.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEGASTOPASAJEAEREOCAMPOREQUERIDOPERSONAL);
			this.rfvPersonal.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEGASTOPASAJEAEREOCAMPOREQUERIDOPERSONAL);

			this.rfvPasajeAereo.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEGASTOPASAJEAEREOCAMPOREQUERIDOPASAJEAEREO);
			this.rfvPasajeAereo.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEGASTOPASAJEAEREOCAMPOREQUERIDOPASAJEAEREO);
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetalleGastosPasajesAereos.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetalleGastosPasajesAereos.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetalleGastosPasajesAereos.Exportar implementation
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
			// TODO:  Add DetalleGastosPasajesAereos.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void rblTipoGasto_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(this.rblTipoGasto.SelectedIndex == OrdenTrabajo)
			{
				this.txtCentroCosto.Text = CadenaVacia;
				this.ModificarCentroCosto(false);
				this.ModificarOrdenTrabajo(true);
			}

			else
			{
				this.txtOT.Text = CadenaVacia;
				this.ModificarOrdenTrabajo(false);
				this.ModificarCentroCosto(true);
			}
		}

		private void ModificarCentroCosto(bool valor)
		{
			this.lblCentroCosto.Visible = valor;
			this.txtCentroCosto.Visible = valor;
			this.ibtnBuscarCentroCosto.Visible = valor;
		}

		private void ModificarOrdenTrabajo(bool valor)
		{
			this.lblOT.Visible = valor;
			this.txtOT.Visible = valor;
			this.ibtnBuscarOT.Visible = valor;
		}

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			GastoPasajeAereoBE oGastoPasajeAereoBE = new GastoPasajeAereoBE();
			oGastoPasajeAereoBE.FechaDocumento = this.CalFechaDocumento.SelectedDate;
			oGastoPasajeAereoBE.Monto = Convert.ToDouble(this.txtMonto.Text);
			oGastoPasajeAereoBE.IdTablaDocumento = Convert.ToInt32(Enumerados.TablasTabla.SecretariaTipoDocumento);
			oGastoPasajeAereoBE.IdDocumento = Convert.ToInt32(this.ddlbTipoDocumento.SelectedValue);
			oGastoPasajeAereoBE.IdTablaMoneda = Convert.ToInt32(Enumerados.TablasTabla.Moneda);
			oGastoPasajeAereoBE.IdMoneda = Convert.ToInt32(this.hIdMoneda.Value);
			oGastoPasajeAereoBE.NroDocumento = this.txtDocumento.Text;
	
			if(this.rblTipoGasto.SelectedIndex == CentroCosto)
			{
				if(this.hIdGrupoCentroCosto.Value != "")
				{
					oGastoPasajeAereoBE.IdGrupoCc = Convert.ToInt32(this.hIdGrupoCentroCosto.Value);
				}
				if(this.hIdCentroCosto.Value != "")
				{
					oGastoPasajeAereoBE.IdCentroCosto = Convert.ToInt32(this.hIdCentroCosto.Value);
				}
			}
			else if(this.rblTipoGasto.SelectedIndex == OrdenTrabajo)
			{
				if(this.hIdValorizacionOrdenTrabajo.Value != "")
				{
					oGastoPasajeAereoBE.IdValorizacionOrdenTrabajo = Convert.ToInt32(this.hIdValorizacionOrdenTrabajo.Value);
				}
			}
			oGastoPasajeAereoBE.IdPasajeAereo = Convert.ToInt32(this.hIdPasajeAereo.Value);
			oGastoPasajeAereoBE.IdPersonal = Convert.ToInt32(this.hIdPersonal.Value);

			oGastoPasajeAereoBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();
			oGastoPasajeAereoBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.EstadosGastoPasajeAereo);
			oGastoPasajeAereoBE.IdEstado = Convert.ToInt32(Enumerados.EstadosGastoPasajeAereo.Activo);

			CMantenimientos oCMantenimientos = new CMantenimientos();

			int retorno = oCMantenimientos.Insertar(oGastoPasajeAereoBE);

			if(retorno>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se registró el Gasto de Pasajes Aereos Nro. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));

				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionComercial.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONREGISTROGASTOPASAJEAEREO));
			}
		}

		public void Modificar()
		{
			GastoPasajeAereoBE oGastoPasajeAereoBE = new GastoPasajeAereoBE();
			oGastoPasajeAereoBE.IdGastoPasajeAereo = Convert.ToInt32(Page.Request.QueryString[KEYQID]);
			oGastoPasajeAereoBE.FechaDocumento = this.CalFechaDocumento.SelectedDate;
			oGastoPasajeAereoBE.Monto = Convert.ToDouble(this.txtMonto.Text);
			oGastoPasajeAereoBE.IdTablaDocumento = Convert.ToInt32(Enumerados.TablasTabla.SecretariaTipoDocumento);
			oGastoPasajeAereoBE.IdDocumento = Convert.ToInt32(this.ddlbTipoDocumento.SelectedValue);
			oGastoPasajeAereoBE.IdTablaMoneda = Convert.ToInt32(Enumerados.TablasTabla.Moneda);
			oGastoPasajeAereoBE.IdMoneda = Convert.ToInt32(this.hIdMoneda.Value);
			oGastoPasajeAereoBE.NroDocumento = this.txtDocumento.Text;

			if(this.rblTipoGasto.SelectedIndex == CentroCosto)
			{
				if(this.hIdGrupoCentroCosto.Value != "")
				{
					oGastoPasajeAereoBE.IdGrupoCc = Convert.ToInt32(this.hIdGrupoCentroCosto.Value);
				}
				if(this.hIdCentroCosto.Value != "")
				{
					oGastoPasajeAereoBE.IdCentroCosto = Convert.ToInt32(this.hIdCentroCosto.Value);
				}
			}
			else if(this.rblTipoGasto.SelectedIndex == OrdenTrabajo)
			{
				if(this.hIdValorizacionOrdenTrabajo.Value != "")
				{
					oGastoPasajeAereoBE.IdValorizacionOrdenTrabajo = Convert.ToInt32(this.hIdValorizacionOrdenTrabajo.Value);
				}
			}
			oGastoPasajeAereoBE.IdPasajeAereo = Convert.ToInt32(this.hIdPasajeAereo.Value);
			oGastoPasajeAereoBE.IdPersonal = Convert.ToInt32(this.hIdPersonal.Value);

			oGastoPasajeAereoBE.IdUsuarioActualizacion = CNetAccessControl.GetIdUser();
			oGastoPasajeAereoBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.EstadosGastoPasajeAereo);
			oGastoPasajeAereoBE.IdEstado = Convert.ToInt32(Enumerados.EstadosGastoPasajeAereo.Modificado);

			CMantenimientos oCMantenimientos = new CMantenimientos();
			if(oCMantenimientos.Modificar(oGastoPasajeAereoBE)>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se modificó el Gasto de Pasaje Aereo Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));
				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionComercial.ToString(),Mensajes.CODIGOMENSAJEMODIFICACIONREGISTROGASTOPASAJEAEREO));
			}
		}

		public void Eliminar()
		{
			// TODO:  Add DetalleGastosPasajesAereos.Eliminar implementation
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
			GastoPasajeAereoBE oGastoPasajeAereoBE = (GastoPasajeAereoBE)oCMantenimientos.ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYQID]),Enumerados.ClasesNTAD.GastoPasajeAereoNTAD.ToString());
			
			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionComercial",this.ToString(),"Se consultó el Detalle del Gasto de Pasaje Aereo Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

			if(oGastoPasajeAereoBE!=null)
			{
				this.txtDocumento.Text = oGastoPasajeAereoBE.NroDocumento;
				this.ddlbTipoDocumento.Items.FindByValue(oGastoPasajeAereoBE.IdDocumento.ToString()).Selected = true;
				this.CalFechaDocumento.SelectedDate = oGastoPasajeAereoBE.FechaDocumento;

				this.hIdPersonal.Value = oGastoPasajeAereoBE.IdPersonal.ToString();
				CPersonal oCPersonal = new CPersonal();
				string NombrePersonal = oCPersonal.ObtenerNombrePersonal(Convert.ToInt32(this.hIdPersonal.Value));
				this.txtPersonal.Text = NombrePersonal;

				this.hIdPasajeAereo.Value = oGastoPasajeAereoBE.IdPasajeAereo.ToString();
				CPasajeAereo oCPasajeAereo = new CPasajeAereo();
				string NombrePasajeAereo = oCPasajeAereo.ObtenerRutaPasajeAereo(Convert.ToInt32(this.hIdPasajeAereo.Value));
				this.txtPasajeAereo.Text = NombrePasajeAereo;

				this.txtMonto.Text = oGastoPasajeAereoBE.Monto.ToString();

				this.hIdMoneda.Value = oGastoPasajeAereoBE.IdMoneda.ToString();
				CTablaTablas oCTablaTablas = new CTablaTablas();
				DataView dv = oCTablaTablas.ListaSegunCriterioFiltro(Convert.ToInt32(Enumerados.TablasTabla.Moneda),Enumerados.ColumnasTablaTablas.Codigo.ToString()+Constantes.SIGNOIGUAL+this.hIdMoneda.Value);
				this.txtMoneda.Text = dv[0].Row[Enumerados.ColumnasTablaTablas.Descripcion.ToString()].ToString();

				if(!oGastoPasajeAereoBE.IdValorizacionOrdenTrabajo.IsNull)
				{
					this.hIdGrupoCentroCosto.Value = CadenaVacia;
					this.hIdCentroCosto.Value = CadenaVacia;
					this.txtCentroCosto.Text = CadenaVacia;

					this.rblTipoGasto.SelectedIndex = OrdenTrabajo;
					this.ModificarCentroCosto(false);
					this.ModificarOrdenTrabajo(true);
					this.hIdValorizacionOrdenTrabajo.Value = oGastoPasajeAereoBE.IdValorizacionOrdenTrabajo.ToString();

					COrdenTrabajo oCOrdenTrabajo = new COrdenTrabajo();
					string NombreOrdenTrabajo = oCOrdenTrabajo.ObtenerNombreOt(Convert.ToInt32(this.hIdValorizacionOrdenTrabajo.Value));
					this.txtOT.Text = NombreOrdenTrabajo;
				}

				if(!oGastoPasajeAereoBE.IdCentroCosto.IsNull && !oGastoPasajeAereoBE.IdGrupoCc.IsNull)
				{
					this.hIdValorizacionOrdenTrabajo.Value = CadenaVacia;
					this.txtOT.Text = CadenaVacia;

					this.rblTipoGasto.SelectedIndex = CentroCosto;
					this.ModificarOrdenTrabajo(false);
					this.ModificarCentroCosto(true);
					this.hIdGrupoCentroCosto.Value = oGastoPasajeAereoBE.IdGrupoCc.ToString();
					this.hIdCentroCosto.Value = oGastoPasajeAereoBE.IdCentroCosto.ToString();

					CCentroCosto oCCentroCosto = new CCentroCosto();
					string NombreCentroCosto = oCCentroCosto.ObtenerNombreCentroCosto(Convert.ToInt32(this.hIdGrupoCentroCosto.Value),Convert.ToInt32(this.hIdCentroCosto.Value));
					this.txtCentroCosto.Text = NombreCentroCosto;
				}
			}
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add DetalleGastosPasajesAereos.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			if(this.ValidarCamposRequeridos())
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public bool ValidarCamposRequeridos()
		{
			if(this.txtDocumento.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEGASTOPASAJEAEREOCAMPOREQUERIDODOCUMENTO));
				return false;
			}
			if(this.ddlbTipoDocumento.SelectedItem.Text == Constantes.TEXTOSSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEGASTOPASAJEAEREOCAMPOREQUERIDOTIPODOCUMENTO));
				return false;
			}
			if(this.txtPersonal.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEGASTOPASAJEAEREOCAMPOREQUERIDOPERSONAL));
				return false;
			}
			if(this.txtPasajeAereo.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEGASTOPASAJEAEREOCAMPOREQUERIDOPASAJEAEREO));
				return false;
			}
			return true;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add DetalleGastosPasajesAereos.ValidarExpresionesRegulares implementation
			return false;
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
	}
}