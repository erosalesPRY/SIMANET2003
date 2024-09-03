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
	public class DetalleAmortizacion : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		#region Constantes
		const string GRILLAVACIA ="No existe ningún Registro.";  

		const string KEYIDDOCDESCLET ="idDocdescLetra";
		const string KEYIDLETDESCTDET ="idLetraDesctDet";
		const string KEYIDLETDESCTAMORTIZA ="idLetraDesctAmortiza";

		const string KEYIDTIPOLETRA = "TipoLetra";
		const string KEYNOMBRETIPOLETRA = "NombreTipoLetra";
		const string KEYIDCENTRO = "idCentro";

		const string URLBUSQUEDALETRAS = "BuscarLetras.aspx?";
		#endregion

		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label Label18;
		protected System.Web.UI.WebControls.Label Label9;
		protected eWorld.UI.NumericBox nMonto;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.TextBox txtObservacion;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary Vresumen;
		protected System.Web.UI.HtmlControls.HtmlTable ToolBar;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnCancelar;
		protected System.Web.UI.HtmlControls.HtmlTable tblAtras;
		protected eWorld.UI.CalendarPopup CalFecha;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvMonto;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvMontoInteres;
		protected eWorld.UI.NumericBox nMontoInteres;
		protected System.Web.UI.WebControls.DropDownList ddlbSituacion;
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
					this.LlenarGrillaOrdenamientoPaginacion("",0);
					
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
			// TODO:  Add DetalleAmortizacion.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetalleAmortizacion.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetalleAmortizacion.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			this.CargarSituacion();
		}
		private void CargarSituacion()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			this.ddlbSituacion.DataSource= oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraEstadoLetrasDescuentoAmortiza));
			ddlbSituacion.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbSituacion.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbSituacion.DataBind();			
		}


		public void LlenarDatos()
		{
			// TODO:  Add DetalleAmortizacion.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			rfvMonto.ErrorMessage = Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesErrorFinanciera.ToString(),Utilitario.Mensajes.CODIGOMENSAJEERRORDCTOLETRAMONTOAMORTIZACION);
			//rfvMonto.ErrorMessage = "No se ha Ingresado Monto de Amortización";
			rfvMonto.ToolTip = Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesErrorFinanciera.ToString(),Utilitario.Mensajes.CODIGOMENSAJEERRORDCTOLETRAMONTOAMORTIZACION);

			rfvMontoInteres.ErrorMessage = Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesErrorFinanciera.ToString(),Utilitario.Mensajes.CODIGOMENSAJEERRORDCTOLETRAMONTOINTERESAMORTIZACION);
			//rfvMontoInteres.ErrorMessage = "No se ha Ingresado Monto de interes de la Amortización";
			rfvMontoInteres.ToolTip = Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesErrorFinanciera.ToString(),Utilitario.Mensajes.CODIGOMENSAJEERRORDCTOLETRAMONTOINTERESAMORTIZACION);
			this.Enfocar();
		}
		private void Enfocar()
		{
			CalFecha.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,Helper.SetFocus("ddlbSituacion"));			
			ddlbSituacion.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,Helper.SetFocus("nMonto"));
			nMonto.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,Helper.SetFocus("nMontoInteres"));
			nMontoInteres.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,Helper.SetFocus("txtObservacion"));
			txtObservacion.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,Helper.SetFocus("CalFecha"));
		}
		public void RegistrarJScript()
		{
			// TODO:  Add DetalleAmortizacion.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetalleAmortizacion.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetalleAmortizacion.Exportar implementation
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
			// TODO:  Add DetalleAmortizacion.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			LetrasDescuentoAmortizaBE oLetrasDescuentoAmortizaBE =new LetrasDescuentoAmortizaBE();
			oLetrasDescuentoAmortizaBE.FechaAmortiza = Convert.ToDateTime( this.CalFecha.SelectedDate);
			oLetrasDescuentoAmortizaBE.Monto = Convert.ToDouble(this.nMonto.Text.Trim());
			oLetrasDescuentoAmortizaBE.MontoInteres = Convert.ToDecimal(this.nMontoInteres.Text.Trim());
			oLetrasDescuentoAmortizaBE.IdLetrasDescuento = Page.Request.Params[KEYIDLETDESCTDET].ToString();
			oLetrasDescuentoAmortizaBE.Observacion = this.txtObservacion.Text.ToString();
			oLetrasDescuentoAmortizaBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();
			oLetrasDescuentoAmortizaBE.IdTablaEstado = Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraEstadoLetrasDescuentoAmortiza);
			oLetrasDescuentoAmortizaBE.IdEstado= Convert.ToInt32(this.ddlbSituacion.SelectedValue);
			if(((CLetrasDescuentoAmortiza)new CLetrasDescuentoAmortiza()).Insertar(oLetrasDescuentoAmortizaBE)>0)
			{
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionFinanciera",this.ToString(),"Se registró Item " + oLetrasDescuentoAmortizaBE.ToString(),Enumerados.NivelesErrorLog.I.ToString()));
				//ltlMensaje.Text = Helper.MensajeRetornoAlert();
				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionFinanciera.ToString(),Utilitario.Mensajes.CODIGOMENSAJEDCTOLETRAREGISTRO));
			}
		}

		public void Modificar()
		{
			LetrasDescuentoAmortizaBE oLetrasDescuentoAmortizaBE =new LetrasDescuentoAmortizaBE();
			oLetrasDescuentoAmortizaBE.IdLetraDescuentoAmortiza = Page.Request.Params[KEYIDLETDESCTAMORTIZA].ToString();
			oLetrasDescuentoAmortizaBE.FechaAmortiza = Convert.ToDateTime( this.CalFecha.SelectedDate);
			oLetrasDescuentoAmortizaBE.Monto = Convert.ToDouble(this.nMonto.Text.Trim());
			oLetrasDescuentoAmortizaBE.MontoInteres = Convert.ToDecimal(this.nMontoInteres.Text.Trim());
			oLetrasDescuentoAmortizaBE.IdLetrasDescuento = Page.Request.Params[KEYIDLETDESCTDET].ToString();
			oLetrasDescuentoAmortizaBE.Observacion = this.txtObservacion.Text.ToString();
			oLetrasDescuentoAmortizaBE.IdUsuarioActualizacion = CNetAccessControl.GetIdUser();
			oLetrasDescuentoAmortizaBE.IdTablaEstado = Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraEstadoLetrasDescuentoAmortiza);
			oLetrasDescuentoAmortizaBE.IdEstado= Convert.ToInt32(this.ddlbSituacion.SelectedValue);
			if(((CLetrasDescuentoAmortiza)new CLetrasDescuentoAmortiza()).Modificar(oLetrasDescuentoAmortizaBE)>0)
			{
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionFinanciera",this.ToString(),"Se modificó Item de " + oLetrasDescuentoAmortizaBE.ToString(),Enumerados.NivelesErrorLog.I.ToString()));
				//ltlMensaje.Text = Helper.MensajeRetornoAlert();
				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionFinanciera.ToString(),Utilitario.Mensajes.CODIGOMENSAJEDCTOLETRAMODIFICACION));
			}
		}

		public void Eliminar()
		{
			// TODO:  Add DetalleAmortizacion.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.Params[Constantes.KEYMODOPAGINA].ToString()) ;
			switch (oModoPagina)
			{
				case Enumerados.ModoPagina.N:
					this.CargarModoNuevo();
					this.tblAtras.Visible= false;
					break;
				case Enumerados.ModoPagina.M:
					this.CargarModoModificar();
					this.tblAtras.Visible= false;
					break;
				case Enumerados.ModoPagina.C:
					this.CargarModoModificar();
					if (Page.Request.Params[Utilitario.Constantes.KEYMODULOCONSULTA].ToString()== Utilitario.Enumerados.ModuloConsulta.Si.ToString())
					{
						Helper.BloquearControles(this);
						this.ibtnCancelar.Visible=false;
						this.ToolBar.Style.Add(Utilitario.Constantes.DISPLAY,Utilitario.Constantes.NONE);
						this.tblAtras.Visible= true;
					}
					break;			
			}
		}

		public void CargarModoNuevo()
		{
			// TODO:  Add DetalleAmortizacion.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			LetrasDescuentoAmortizaBE oLetrasDescuentoAmortizaBE = (LetrasDescuentoAmortizaBE) ((CLetrasDescuentoAmortiza) new CLetrasDescuentoAmortiza()).DetalleLetrasDescuentoAmortiza(Convert.ToString(Page.Request.Params[KEYIDLETDESCTDET]),
																																															Convert.ToString(Page.Request.Params[KEYIDLETDESCTAMORTIZA]));
			CalFecha.SelectedDate = Convert.ToDateTime(oLetrasDescuentoAmortizaBE.FechaAmortiza);
			nMonto.Text = Convert.ToDouble(oLetrasDescuentoAmortizaBE.Monto).ToString(Utilitario.Constantes.FORMATODECIMAL4);
			nMontoInteres.Text = oLetrasDescuentoAmortizaBE.MontoInteres.ToString(Utilitario.Constantes.FORMATODECIMAL4);
			txtObservacion.Text = oLetrasDescuentoAmortizaBE.Observacion.ToString();
			((ListItem) this.ddlbSituacion.Items.FindByValue(oLetrasDescuentoAmortizaBE.IdEstado.ToString())).Selected=true;
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add DetalleAmortizacion.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add DetalleAmortizacion.ValidarCampos implementation
			return true;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add DetalleAmortizacion.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add DetalleAmortizacion.ValidarExpresionesRegulares implementation
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
	}
}
