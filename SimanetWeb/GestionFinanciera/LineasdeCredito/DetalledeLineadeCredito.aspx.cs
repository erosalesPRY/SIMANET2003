using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using SIMA.SimaNetWeb.InterfacesIU;
using SIMA.Controladoras.General;
using SIMA.Controladoras.GestionFinanciera;
using SIMA.EntidadesNegocio.GestionFinanciera;
using SIMA.Utilitario;
using NetAccessControl;
using SIMA.ManejadorExcepcion;
using SIMA.Log;

namespace SIMA.SimaNetWeb.GestionFinanciera.LineasdeCredito
{
	/// <summary>
	/// Summary description for DetalledeLineadeCredito.
	/// </summary>
	public class DetalledeLineadeCredito : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		#region Constantes
		const string  GRILLAVACIA="No existe";
		const string OBJPARAMETROCONTABLE = "ParamCtaBco";
		//Ordenamiento
		const string COLORDENAMIENTO = "id";

		//Nombres de Controles
		const string CONTROLINK = "hlkNroID";
		const string CTRLENTIDADFINACIERA ="ddlbEntidadFinanciera";
		const string CTRLLINEACREDITO ="ddlbLineadeCredito";
		const string CTRLMONEDA ="ddlbMoneda";
		const string CTRLSITUACION ="ddlbSituacion";
		const string CTRLFECHAAPERTURA ="CalFechaApertura";
		const string CTRLFECHAVENCIMIENTO ="CalFechaVencimiento";
		const string CTRLMONTOAUTORIZADO ="nMontoAutorizado";
		const string CTRLTIPOCAMBIO ="nTipoCambio";
		const string CTRLOBSERVACION ="txtObservacion";
		const string CTRLEMPRESA ="ddlbEmpresa";

		//Paginas
		const string URLPRINCIPAL = "AdminsitraciondeLineadeCredito.aspx";
		
		
		//Key Session y QueryString
		const string KEYQID = "idLinea";
		const string KEYQPERIODO = "Periodo";
		const string KEYQIDESTADO= "IdEstado";
		#endregion
		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblMensaje;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DropDownList ddlbSituacion;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.DropDownList ddlbEntidadFinanciera;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.Label Label4;
		protected eWorld.UI.CalendarPopup CalFechaVencimiento;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Label Label11;
		protected eWorld.UI.NumericBox nTipoCambio;
		protected System.Web.UI.WebControls.Label lblObservacion;
		protected System.Web.UI.WebControls.TextBox txtObservacion;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.Label lblEmpresa;
		protected System.Web.UI.WebControls.DropDownList ddlbEmpresa;
		protected System.Web.UI.WebControls.Label Label3;
		protected eWorld.UI.NumericBox nMontoAutorizado;
		protected System.Web.UI.WebControls.TextBox txtNroLinea;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.DropDownList ddlbMoneda;
		protected eWorld.UI.CalendarPopup CalFechaApertura;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary Vresumen;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rdvMontoAutorizado;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator TipoCambio;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.DropDownList ddlbLineadeCredito;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdLineaC;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdPeriodo;
		private   ListItem item =  new ListItem();
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
					string debug = oException.Message.ToString();
					SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
					Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
				}
			}
			// Put user code to initialize the page here
		}
		private void CargarSituacion()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			this.ddlbSituacion.DataSource= oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraLineadeCredito));
			ddlbSituacion.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbSituacion.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbSituacion.DataBind();			
		}
		private void CargarLineadeCredito()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			this.ddlbLineadeCredito.DataSource= oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraTipodeLineadeCredito));
			ddlbLineadeCredito.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbLineadeCredito.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbLineadeCredito.DataBind();			
		}

		private void CargarEmpresa()
		{
			CEmpresa oCEmpresa= new CEmpresa();
			//object [] ParametroValor={Utilitario.Constantes.IDESTADODEFAULT};
			ddlbEmpresa.DataSource = oCEmpresa.ListarEmpresa(Utilitario.Constantes.IDESTADODEFAULT /*ParametroValor*/);
			ddlbEmpresa.DataValueField= Enumerados.ColumnaEmpresa.idempresa.ToString();
			ddlbEmpresa.DataTextField=Enumerados.ColumnaEmpresa.razonsocial.ToString();
			ddlbEmpresa.DataBind();
		}
		private void CargarEntidadFinanciera()
		{
			CEntidadFinanciera oCEntidadFinanciera = new CEntidadFinanciera();
			ddlbEntidadFinanciera.DataSource = oCEntidadFinanciera.ListarTodosCombo ();
			ddlbEntidadFinanciera.DataValueField= Enumerados.ColumnasEntidadFinanciera.IdEntidadFinanciera.ToString();
			ddlbEntidadFinanciera.DataTextField=Enumerados.ColumnasEntidadFinanciera.RazonSocial.ToString();
			ddlbEntidadFinanciera.DataBind();
		}
		private void CargarMoneda()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			this.ddlbMoneda.DataSource= oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Utilitario.Enumerados.TablasTabla.Moneda));
			ddlbMoneda.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbMoneda.DataTextField = Enumerados.ColumnasTablaTablas.Var1.ToString();
			ddlbMoneda.DataBind();			
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
			this.ddlbMoneda.SelectedIndexChanged += new System.EventHandler(this.ddlbMoneda_SelectedIndexChanged);
			this.ibtnAceptar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAceptar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add DetalledeLineadeCredito.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetalledeLineadeCredito.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetalledeLineadeCredito.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			this.CargarEntidadFinanciera();
			this.CargarMoneda();
			this.CargarSituacion();
			this.CargarEmpresa();
			this.CargarLineadeCredito();
			// TODO:  Add DetalledeLineadeCredito.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add DetalledeLineadeCredito.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			txtNroLinea.Style.Add(Utilitario.Constantes.DISPLAY,Utilitario.Constantes.NONE);
			rdvMontoAutorizado.ErrorMessage = Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJELINEADECREDDITOCAMPOREQUERIDOMONTOESTABLECIDO);
			rdvMontoAutorizado.ToolTip=rdvMontoAutorizado.ErrorMessage;
			TipoCambio.ErrorMessage = Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJELINEADECREDDITOCAMPOREQUERIDOTIPODECAMBIO);
			TipoCambio.ToolTip=TipoCambio.ErrorMessage;
			ddlbMoneda.Attributes[Enumerados.EventosJavaScript.OnChange.ToString()]="CambioMoneda()";
			this.Enfocar();
		}
		private void Enfocar()
		{
			ddlbEmpresa.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,Helper.SetFocus(CTRLENTIDADFINACIERA));
			ddlbEntidadFinanciera.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,Helper.SetFocus(CTRLLINEACREDITO));
			ddlbLineadeCredito.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,Helper.SetFocus(CTRLMONEDA));
			ddlbMoneda.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,Helper.SetFocus(CTRLSITUACION));
			ddlbSituacion.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,Helper.SetFocus(CTRLFECHAAPERTURA));
			CalFechaApertura.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,Helper.SetFocus(CTRLFECHAVENCIMIENTO));
			CalFechaVencimiento.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,Helper.SetFocus(CTRLMONTOAUTORIZADO));
			nMontoAutorizado.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,Helper.SetFocus(CTRLTIPOCAMBIO));
			nTipoCambio.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,Helper.SetFocus(CTRLOBSERVACION));
			txtObservacion.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,Helper.SetFocus(CTRLEMPRESA));
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetalledeLineadeCredito.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetalledeLineadeCredito.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetalledeLineadeCredito.Exportar implementation
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
			// TODO:  Add DetalledeLineadeCredito.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			LineaCreditoBE oLineaCreditoBE = new LineaCreditoBE();
			oLineaCreditoBE.Periodo = Convert.ToInt32(this.CalFechaApertura.SelectedDate.Year);
			oLineaCreditoBE.IdEntidadFinanciera= Convert.ToInt32(this.ddlbEntidadFinanciera.SelectedValue);
			oLineaCreditoBE.Idtablamoneda= Convert.ToInt32(Utilitario.Enumerados.TablasTabla.Moneda);
			oLineaCreditoBE.Idmoneda= Convert.ToInt32(this.ddlbMoneda.SelectedValue);
			oLineaCreditoBE.Montoautorizado= Convert.ToDouble(this.nMontoAutorizado.Text);
			oLineaCreditoBE.TipoCambio= Convert.ToDecimal(this.nTipoCambio.Text);
			oLineaCreditoBE.Idempresa= Convert.ToInt32(this.ddlbEmpresa.SelectedValue);
			oLineaCreditoBE.FechaApertura= Convert.ToDateTime(this.CalFechaApertura.SelectedDate);
			oLineaCreditoBE.Fechavencimiento= Convert.ToDateTime(this.CalFechaVencimiento.SelectedDate);
			oLineaCreditoBE.Idusuarioregistro = CNetAccessControl.GetIdUser();
			oLineaCreditoBE.Idtablaestado = Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraLineadeCredito);
			oLineaCreditoBE.Idestado= Convert.ToInt32(this.ddlbSituacion.SelectedValue);
			oLineaCreditoBE.Observacion= Convert.ToString(this.txtObservacion.Text);
			oLineaCreditoBE.IdTablaTipoLineaCredito = Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraTipodeLineadeCredito);
			oLineaCreditoBE.IdTipoLineaCredito = Convert.ToInt32(this.ddlbLineadeCredito.SelectedValue);
			
			CLineaCredito oCLineaCredito = new CLineaCredito();
			int retorno = oCLineaCredito.Insertar(oLineaCreditoBE);
			if(retorno > Utilitario.Constantes.ValorConstanteCero)
			{
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName()
															,"GestionFinanciera"
															,this.ToString()
															,"Se Agrego Item de " + oCLineaCredito.ToString()
															,Enumerados.NivelesErrorLog.I.ToString()));
				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONREGISTROLINEADECREDDITO));
			}			
		}

		public void Modificar()
		{
			LineaCreditoBE oLineaCreditoBE = new LineaCreditoBE();
			oLineaCreditoBE.IdLineaCredito = Convert.ToInt32(this.hIdLineaC.Value);
			oLineaCreditoBE.Periodo = Convert.ToInt32(this.hIdPeriodo.Value);
			oLineaCreditoBE.Idempresa= Convert.ToInt32(this.ddlbEmpresa.SelectedValue);
			oLineaCreditoBE.IdEntidadFinanciera= Convert.ToInt32(this.ddlbEntidadFinanciera.SelectedValue);
			oLineaCreditoBE.Idmoneda= Convert.ToInt32(this.ddlbMoneda.SelectedValue);
			oLineaCreditoBE.Idestado= Convert.ToInt32(this.ddlbSituacion.SelectedValue);
			oLineaCreditoBE.FechaApertura= Convert.ToDateTime(this.CalFechaApertura.SelectedDate);
			oLineaCreditoBE.Fechavencimiento= Convert.ToDateTime(this.CalFechaVencimiento.SelectedDate);
			oLineaCreditoBE.Montoautorizado= Convert.ToDouble(this.nMontoAutorizado.Text.ToString().Trim());
			oLineaCreditoBE.TipoCambio= Convert.ToDecimal(this.nTipoCambio.Text.ToString().Trim());
			oLineaCreditoBE.Observacion= Convert.ToString(this.txtObservacion.Text);
			oLineaCreditoBE.Idusuarioactualizacion = CNetAccessControl.GetIdUser();
			oLineaCreditoBE.IdTablaTipoLineaCredito = Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraTipodeLineadeCredito);
			oLineaCreditoBE.IdTipoLineaCredito = Convert.ToInt32(this.ddlbLineadeCredito.SelectedValue);
			
			CLineaCredito oCLineaCredito = new CLineaCredito();
			int retorno = oCLineaCredito.Modificar(oLineaCreditoBE);
			if(retorno > Utilitario.Constantes.ValorConstanteCero)
			{
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName()
														,"GestionFinanciera"
														,this.ToString()
														,"Se modificó Item de " + oCLineaCredito.ToString()
														,Enumerados.NivelesErrorLog.I.ToString()));
				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONMODIFICACIONLINEADECREDDITO));
			}			
		}

		public void Eliminar()
		{
		}

		public void CargarModoPagina()
		{
			Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.Params[Constantes.KEYMODOPAGINA].ToString()) ;
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
		}

		public void CargarModoModificar()
		{
			CLineaCredito oCLineaCredito = new CLineaCredito();

			LineaCreditoBE oLineaCreditoBE = (LineaCreditoBE)
					oCLineaCredito.DetalleLineadeCredito(Convert.ToInt32(Page.Request.Params[KEYQID])
														,Convert.ToInt32(Page.Request.Params[KEYQPERIODO])
														,Convert.ToInt32(Page.Request.Params[KEYQIDESTADO]));

			this.txtNroLinea.Text = oLineaCreditoBE.Periodo.ToString() + Utilitario.Constantes.SIGNOMENOS + oLineaCreditoBE.IdLineaCredito.ToString();
			this.hIdLineaC.Value =oLineaCreditoBE.IdLineaCredito.ToString();
			this.hIdPeriodo.Value=oLineaCreditoBE.Periodo.ToString();
			item = this.ddlbEmpresa.Items.FindByValue(oLineaCreditoBE.Idempresa.ToString());
			if(item!=null)
			{item.Selected = true;}
			item = this.ddlbEntidadFinanciera.Items.FindByValue(oLineaCreditoBE.IdEntidadFinanciera.ToString());
			if(item!=null)
			{item.Selected = true;}
			item = this.ddlbMoneda.Items.FindByValue(oLineaCreditoBE.Idmoneda.ToString());
			if(item!=null)
			{item.Selected = true;}
			item = this.ddlbSituacion.Items.FindByValue(oLineaCreditoBE.Idestado.ToString());
			if(item!=null)
			{item.Selected = true;}
			item = this.ddlbLineadeCredito.Items.FindByValue(oLineaCreditoBE.IdTipoLineaCredito.ToString());
			if(item!=null)
			{item.Selected = true;}
			
			this.CalFechaApertura.SelectedDate = Convert.ToDateTime(oLineaCreditoBE.FechaApertura);
			this.CalFechaVencimiento.SelectedDate = Convert.ToDateTime(oLineaCreditoBE.Fechavencimiento);
			this.nMontoAutorizado.Text = oLineaCreditoBE.Montoautorizado.ToString(Utilitario.Constantes.FORMATODECIMAL4);
			this.nTipoCambio.Text = oLineaCreditoBE.TipoCambio.ToString(Utilitario.Constantes.FORMATODECIMAL8);
			this.txtObservacion.Text = oLineaCreditoBE.Observacion.ToString();
			// TODO:  Add DetalledeLineadeCredito.CargarModoModificar implementation
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add DetalledeLineadeCredito.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add DetalledeLineadeCredito.ValidarCampos implementation
			return true;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add DetalledeLineadeCredito.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add DetalledeLineadeCredito.ValidarExpresionesRegulares implementation
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
						Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.Params[Constantes.KEYMODOPAGINA]) ;
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
				SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
				Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
			}		
		}
		private void ddlbMoneda_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
