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
using MetaBuilders.WebControls;
using SIMA.SimaNetWeb.Legal;

namespace SIMA.SimaNetWeb.GestionFinanciera.DescuentoLetras
{
	public class DetalleDescuento : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		#region Constantes
		const string GRILLAVACIA ="No existe ningún Registro.";  

		const string KEYIDENTIDADFINANCIERA = "idEF";
		const string KEYIDDOCDESCLET ="idDocdescLetra";
		const string KEYIDTIPOLETRA = "TipoLetra";
		const string KEYNOMBRETIPOLETRA = "NombreTipoLetra";
		const string KEYIDCENTRO = "idCentro";

		const string URLBUSQUEDACTABCO = "../CuentasBancarias/BuscarCuentaBancaria.aspx";
			
		#endregion
		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtNroDocumento;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.DropDownList ddlbSituacion;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label13;
		protected System.Web.UI.WebControls.Label Label19;
		protected System.Web.UI.WebControls.Label Label15;
		protected eWorld.UI.NumericBox nTasaInteres;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.TextBox txtObservacion;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary Vresumen;
		protected System.Web.UI.HtmlControls.HtmlTable ToolBar;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnCancelar;
		protected System.Web.UI.WebControls.Label Label11;
		protected eWorld.UI.CalendarPopup CalFechaDesembolso;
		protected System.Web.UI.WebControls.Label Label12;
		protected System.Web.UI.WebControls.TextBox txtCuentaBCO;
		protected eWorld.UI.NumericBox nMontoInteresBCO;
		protected System.Web.UI.WebControls.Label Label14;
		protected eWorld.UI.NumericBox nMontoDesembolso;
		protected System.Web.UI.WebControls.Label Label16;
		protected eWorld.UI.NumericBox nMontoLetras;
		protected System.Web.UI.WebControls.Label Label20;
		protected eWorld.UI.NumericBox nMontoSaldo;
		protected System.Web.UI.WebControls.Label Label21;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvNroDocumento;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvCuentaBCO;
		protected System.Web.UI.WebControls.TextBox txtMoneda;
		protected System.Web.UI.WebControls.TextBox txtCentro;
		protected System.Web.UI.WebControls.TextBox txtEntidadFinanciera;
		protected eWorld.UI.NumericBox nMontoAmortizado;
		protected System.Web.UI.WebControls.Image ibtnBuscarCuentaBCO;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtidCuentaBancoCentro;
		protected System.Web.UI.HtmlControls.HtmlTableRow rowTotalesLetras;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
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
					this.LlenarDatos();
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
			// TODO:  Add DetalleDescuento.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetalleDescuento.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetalleDescuento.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			this.CargarSituacion();
		}
		private void CargarSituacion()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			this.ddlbSituacion.DataSource= oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraEstadoDescuento));
			ddlbSituacion.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbSituacion.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbSituacion.DataBind();			
		}
		public void LlenarDatos()
		{
			this.lblPagina.Text = Page.Request.Params[KEYNOMBRETIPOLETRA].ToString();
		}

		public void LlenarJScript()
		{
			rfvNroDocumento.ErrorMessage = Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesErrorFinanciera.ToString(),Utilitario.Mensajes.CODIGOMENSAJEERRORDCTOLETRANRODOCUMENTO); 
			rfvNroDocumento.ToolTip = Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesErrorFinanciera.ToString(),Utilitario.Mensajes.CODIGOMENSAJEERRORDCTOLETRANRODOCUMENTO); 
			rfvCuentaBCO.ErrorMessage = Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesErrorFinanciera.ToString(),Utilitario.Mensajes.CODIGOMENSAJEERRORDCTOLETRANROCTABANCARIA);
			rfvCuentaBCO.ToolTip = Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesErrorFinanciera.ToString(),Utilitario.Mensajes.CODIGOMENSAJEERRORDCTOLETRANROCTABANCARIA);

			ibtnBuscarCuentaBCO.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.PopupBusqueda(URLBUSQUEDACTABCO,650,400,100,100,false));
			this.Enfocar();
		}
		private void Enfocar()
		{
			txtNroDocumento.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,Helper.SetFocus("ddlbSituacion"));
			ddlbSituacion.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,Helper.SetFocus("CalFechaDesembolso"));
			CalFechaDesembolso.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,Helper.SetFocus("txtCuentaBCO"));
			txtCuentaBCO.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,Helper.SetFocus("txtMoneda"));
			txtMoneda.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,Helper.SetFocus("txtCentro"));
			txtCentro.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,Helper.SetFocus("txtEntidadFinanciera"));
			txtEntidadFinanciera.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,Helper.SetFocus("nMontoLetras"));
			nMontoLetras.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,Helper.SetFocus("nMontoAmortizado"));
			nMontoAmortizado.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,Helper.SetFocus("nMontoSaldo"));
			nMontoSaldo.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,Helper.SetFocus("nTasaInteres"));
			nTasaInteres.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,Helper.SetFocus("nMontoInteresBCO"));
			nMontoInteresBCO.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,Helper.SetFocus("nMontoDesembolso"));
			nMontoDesembolso.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,Helper.SetFocus("txtObservacion"));
			txtObservacion.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,Helper.SetFocus("txtNroDocumento"));
		}
		public void RegistrarJScript()
		{
			// TODO:  Add DetalleDescuento.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetalleDescuento.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetalleDescuento.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			if(CNetAccessControl.FindPage(Page.Request.Url.AbsolutePath.ToString()))
			{CNetAccessControl.LoadControls(this);}
			else
			{CNetAccessControl.RedirectPageError();}
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add DetalleDescuento.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			DescuentoBE oDescuentoBE = new DescuentoBE();
			oDescuentoBE.NroDescuento = this.txtNroDocumento.Text;
			oDescuentoBE.IdCuentaBancariaCentro = Convert.ToInt32(this.txtidCuentaBancoCentro.Value);
			oDescuentoBE.FechaDesembolso = Convert.ToDateTime(this.CalFechaDesembolso.SelectedDate);
			oDescuentoBE.MontoDescuentoBCO = Convert.ToDouble(this.nMontoInteresBCO.Text);
			oDescuentoBE.TasaInteres = Convert.ToDecimal(this.nTasaInteres.Text);
			oDescuentoBE.Observacion = this.txtObservacion.Text;
			oDescuentoBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();
			oDescuentoBE.IdTablaEstado = Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraEstadoDescuento);
			oDescuentoBE.IdEstado = Convert.ToInt32(this.ddlbSituacion.SelectedValue);
			oDescuentoBE.IdTablaTipoLetra = Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraTipodeLetras);
			oDescuentoBE.IdTipoLetra = Convert.ToInt32(Page.Request.Params[KEYIDTIPOLETRA]);

			if(((CDescuento)new CDescuento()).Insertar(oDescuentoBE)>0)
			{
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionFinanciera",this.ToString(),"Se modificó Item de " + oDescuentoBE.ToString(),Enumerados.NivelesErrorLog.I.ToString()));				
				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionFinanciera.ToString(),Utilitario.Mensajes.CODIGOMENSAJEDCTOLETRADCTOREGISTRO));
			}
		}

		public void Modificar()
		{
			DescuentoBE oDescuentoBE = new DescuentoBE();
			oDescuentoBE.IdDescuento = Convert.ToString(Page.Request.Params[KEYIDDOCDESCLET]);
			oDescuentoBE.NroDescuento = this.txtNroDocumento.Text;
			oDescuentoBE.IdCuentaBancariaCentro = Convert.ToInt32(this.txtidCuentaBancoCentro.Value);
			oDescuentoBE.FechaDesembolso = Convert.ToDateTime(this.CalFechaDesembolso.SelectedDate);
			oDescuentoBE.MontoDescuentoBCO = Convert.ToDouble(this.nMontoInteresBCO.Text);
			oDescuentoBE.TasaInteres = Convert.ToDecimal(this.nTasaInteres.Text);
			oDescuentoBE.Observacion = this.txtObservacion.Text;
			oDescuentoBE.IdUsuarioActualizacion = CNetAccessControl.GetIdUser();
			oDescuentoBE.IdTablaEstado = Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraEstadoDescuento);
			oDescuentoBE.IdEstado = Convert.ToInt32(this.ddlbSituacion.SelectedValue);
			oDescuentoBE.IdTablaTipoLetra = Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraTipodeLetras);
			oDescuentoBE.IdTipoLetra = Convert.ToInt32(Page.Request.Params[KEYIDTIPOLETRA]);
			if(((CDescuento)new CDescuento()).Modificar(oDescuentoBE)>0)
			{
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionFinanciera",this.ToString(),"Se modificó Item de " + oDescuentoBE.ToString(),Enumerados.NivelesErrorLog.I.ToString()));				
				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionFinanciera.ToString(),Utilitario.Mensajes.CODIGOMENSAJEDCTOLETRADCTOMODIFICACION));
			}
		}

		public void Eliminar()
		{
			// TODO:  Add DetalleDescuento.Eliminar implementation
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
				case Enumerados.ModoPagina.C:
					this.CargarModoConsulta();
					break;
			}
		}

		public void CargarModoNuevo()
		{
			rowTotalesLetras.Visible = false;
		}

		public void CargarModoModificar()
		{
			DescuentoBE oDescuentoBE = (DescuentoBE) ((CDescuento) new CDescuento()).DetalleDescuento(Page.Request.Params[KEYIDDOCDESCLET],Utilitario.Constantes.IDDEFAULT,Convert.ToInt32(Page.Request.Params[KEYIDENTIDADFINANCIERA]==null? Utilitario.Constantes.IDDEFAULT.ToString():Page.Request.Params[KEYIDENTIDADFINANCIERA]));
			this.txtNroDocumento.Text = oDescuentoBE.NroDescuento.ToString();
			((ListItem) this.ddlbSituacion.Items.FindByValue(oDescuentoBE.IdEstado.ToString())).Selected = true;
			this.CalFechaDesembolso.SelectedDate= Convert.ToDateTime(oDescuentoBE.FechaDesembolso);
			this.txtCuentaBCO.Text= oDescuentoBE.NroCuentaBancaria.ToString();
			this.txtidCuentaBancoCentro.Value = oDescuentoBE.IdCuentaBancariaCentro.ToString();
			this.txtMoneda.Text= oDescuentoBE.Moneda.ToString();
			this.txtCentro.Text= oDescuentoBE.NombreCentroOperativo.ToString();
			this.txtEntidadFinanciera.Text= oDescuentoBE.EntidadFinanciera.ToString();
			this.nTasaInteres.Text= oDescuentoBE.TasaInteres.ToString();
			this.nMontoInteresBCO.Text= oDescuentoBE.MontoDescuentoBCO.ToString();
			this.nMontoDesembolso.Text = oDescuentoBE.MontoDesembolso.ToString();
			this.nMontoLetras.Text= oDescuentoBE.MontodeLetras.ToString();
			this.nMontoAmortizado.Text= oDescuentoBE.MontoAmortiza.ToString();
			this.nMontoSaldo.Text= oDescuentoBE.SaldoLetra.ToString();
			this.txtObservacion.Text= oDescuentoBE.Observacion.ToString();
		}

		public void CargarModoConsulta()
		{
			DescuentoBE oDescuentoBE = (DescuentoBE) ((CDescuento) new CDescuento()).DetalleDescuento(Page.Request.Params[KEYIDDOCDESCLET],Utilitario.Constantes.IDDEFAULT,Convert.ToInt32(Page.Request.Params[KEYIDENTIDADFINANCIERA]==null? Utilitario.Constantes.IDDEFAULT.ToString():Page.Request.Params[KEYIDENTIDADFINANCIERA]));
			this.txtNroDocumento.Text = oDescuentoBE.NroDescuento.ToString();
			((ListItem) this.ddlbSituacion.Items.FindByValue(oDescuentoBE.IdEstado.ToString())).Selected = true;
			this.CalFechaDesembolso.SelectedDate= Convert.ToDateTime(oDescuentoBE.FechaDesembolso);
			this.txtCuentaBCO.Text= oDescuentoBE.NroCuentaBancaria.ToString();
			this.txtidCuentaBancoCentro.Value = oDescuentoBE.IdCuentaBancariaCentro.ToString();
			this.txtMoneda.Text= oDescuentoBE.Moneda.ToString();
			this.txtCentro.Text= oDescuentoBE.NombreCentroOperativo.ToString();
			this.txtEntidadFinanciera.Text= oDescuentoBE.EntidadFinanciera.ToString();
			this.nTasaInteres.Text= oDescuentoBE.TasaInteres.ToString();
			this.nMontoInteresBCO.Text= oDescuentoBE.MontoDescuentoBCO.ToString();
			this.nMontoDesembolso.Text = oDescuentoBE.MontoDesembolso.ToString();
			this.nMontoLetras.Text= oDescuentoBE.MontodeLetras.ToString();
			this.nMontoAmortizado.Text= oDescuentoBE.MontoAmortiza.ToString();
			this.nMontoSaldo.Text= oDescuentoBE.SaldoLetra.ToString();
			this.txtObservacion.Text= oDescuentoBE.Observacion.ToString();

			this.OcultarBotones();
			this.DeshabilitarCampos();
		}

		public bool ValidarCampos()
		{
			// TODO:  Add DetalleDescuento.ValidarCampos implementation
			return true;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add DetalleDescuento.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add DetalleDescuento.ValidarExpresionesRegulares implementation
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
				ltlMensaje.Text = Helper.MsgdbErrMostrarMesaje(true,oSIMAExcepcionDominio.Error.ToString());
			}
			catch(Exception oException)
			{
				string ex = oException.Message.ToString();
				SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
				Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
			}		
		}

		private void OcultarBotones()
		{
			this.ibtnAceptar.Visible =false;
		}

		private void DeshabilitarCampos()
		{
			this.txtNroDocumento.ReadOnly =true;
			this.ddlbSituacion.Enabled =false;
			this.CalFechaDesembolso.Enabled=false;
			this.txtCuentaBCO.ReadOnly =true;
			this.txtMoneda.ReadOnly =true;
			this.txtCentro.ReadOnly =true;
			this.txtEntidadFinanciera.ReadOnly =true;
			this.nTasaInteres.ReadOnly =true;
			this.nMontoInteresBCO.ReadOnly =true;
			this.nMontoDesembolso.ReadOnly =true;
			this.nMontoLetras.ReadOnly =true;
			this.nMontoAmortizado.ReadOnly =true;
			this.nMontoSaldo.ReadOnly =true;
			this.txtObservacion.ReadOnly =true;
		}
	}
}

