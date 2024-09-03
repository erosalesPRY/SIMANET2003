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
	/// <summary>
	/// Summary description for DetallePaqueteLetrasDescuento.
	/// </summary>
	public class DetallePaqueteLetrasDescuento : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		#region Constantes
		const string GRILLAVACIA ="No existe ningún Registro.";  

		const string KEYIDDOCDESCLET ="idDocdescLetra";
		const string KEYIDLETDESCTDET ="idLetraDesctDet";
		const string KEYIDTIPOLETRA = "TipoLetra";
		const string KEYNOMBRETIPOLETRA = "NombreTipoLetra";
		const string KEYIDCENTRO = "idCentro";

		const string URLBUSQUEDALETRAS = "BuscarLetras.aspx?";
		

		#endregion
		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtNroDocumento;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label13;
		protected System.Web.UI.WebControls.Label Label14;
		protected System.Web.UI.WebControls.Label Label19;
		protected System.Web.UI.WebControls.Label Label15;
		protected System.Web.UI.WebControls.TextBox txtDatosProyecto;
		protected System.Web.UI.WebControls.Label Label18;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.TextBox txtObservacion;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary Vresumen;
		protected System.Web.UI.HtmlControls.HtmlInputText hNumero;
		protected System.Web.UI.HtmlControls.HtmlInputText txtEntidad;
		protected System.Web.UI.HtmlControls.HtmlTextArea txtProyecto;
		protected System.Web.UI.HtmlControls.HtmlTable ToolBar;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnCancelar;
		protected System.Web.UI.HtmlControls.HtmlInputText txtCentro;
		protected System.Web.UI.HtmlControls.HtmlInputText txtSituacion;
		protected System.Web.UI.HtmlControls.HtmlInputText txtMoneda;
		protected System.Web.UI.WebControls.Image ibtnBuscarLetra;
		protected System.Web.UI.HtmlControls.HtmlTable tblAtras;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdLetra;
		protected System.Web.UI.HtmlControls.HtmlInputText txtFechaInicio;
		protected System.Web.UI.HtmlControls.HtmlInputText txtFechaVence;
		protected System.Web.UI.HtmlControls.HtmlInputText NDiasPlazo;
		protected System.Web.UI.HtmlControls.HtmlInputText nMonto;
		protected System.Web.UI.HtmlControls.HtmlInputText nDiasVence;
		protected System.Web.UI.HtmlControls.HtmlInputText nTasaInteres;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvNroReferencia;
		protected System.Web.UI.WebControls.Label Label11;
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
			// TODO:  Add DetallePaqueteLetrasDescuento.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetallePaqueteLetrasDescuento.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetallePaqueteLetrasDescuento.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			this.CargarSituacion();
		}

//		private void CargarSituacion()
//		{
//			CTablaTablas oCTablaTablas = new CTablaTablas();
//			this.ddlbSituacion.DataSource= oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraEstadoLetrasDescuento));
//			ddlbSituacion.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
//			ddlbSituacion.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
//			ddlbSituacion.DataBind();			
//		}

		private void CargarSituacion()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			this.ddlbSituacion.DataSource= oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraSituacionLetras));
			ddlbSituacion.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbSituacion.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbSituacion.DataBind();			
		}

		public void LlenarDatos()
		{
			// TODO:  Add DetallePaqueteLetrasDescuento.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			rfvNroReferencia.ErrorMessage = Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesErrorFinanciera.ToString(),Utilitario.Mensajes.CODIGOMENSAJEERRORDCTOLETRATASNROLETRADESCUENTO);
			rfvNroReferencia.ToolTip = Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesErrorFinanciera.ToString(),Utilitario.Mensajes.CODIGOMENSAJEERRORDCTOLETRATASNROLETRADESCUENTO);

			this.ibtnBuscarLetra.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.PopupBusqueda(URLBUSQUEDALETRAS+ KEYIDTIPOLETRA + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDTIPOLETRA].ToString()
				+ Utilitario.Constantes.SIGNOAMPERSON
				+ KEYNOMBRETIPOLETRA + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYNOMBRETIPOLETRA].ToString()
				,770,400,100,100,false));
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetallePaqueteLetrasDescuento.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetallePaqueteLetrasDescuento.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetallePaqueteLetrasDescuento.Exportar implementation
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
			// TODO:  Add DetallePaqueteLetrasDescuento.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			LetrasDescuentoBE oLetrasDescuentoBE = new LetrasDescuentoBE();
			oLetrasDescuentoBE.IdDescuento = Page.Request.Params[KEYIDDOCDESCLET].ToString();
			oLetrasDescuentoBE.IdLetra = hIdLetra.Value.ToString();
			oLetrasDescuentoBE.IdUsuarioRegistro= CNetAccessControl.GetIdUser();
			//oLetrasDescuentoBE.IdTablaEstado= Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraEstadoLetrasDescuento);
			oLetrasDescuentoBE.IdTablaEstado= Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraSituacionLetras);
			oLetrasDescuentoBE.IdEstado= Convert.ToInt32(this.ddlbSituacion.SelectedValue);
			if(((CLetrasDescuento)new CLetrasDescuento()).Insertar(oLetrasDescuentoBE)>0)
			{
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionFinanciera",this.ToString(),"Se modificó Item de " + oLetrasDescuentoBE.ToString(),Enumerados.NivelesErrorLog.I.ToString()));
				//ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONREGISTRODESCUENTOLETRAS));
				ltlMensaje.Text = Helper.MensajeRetornoAlert();
			}
			
		}

		public void Modificar()
		{
			LetrasDescuentoBE oLetrasDescuentoBE = new LetrasDescuentoBE();
			oLetrasDescuentoBE.IdLetrasDescuento = Page.Request.Params[KEYIDLETDESCTDET].ToString();
			oLetrasDescuentoBE.IdDescuento = Page.Request.Params[KEYIDDOCDESCLET].ToString();
			oLetrasDescuentoBE.IdLetra = hIdLetra.Value.ToString();
			oLetrasDescuentoBE.IdUsuarioActualizacion= CNetAccessControl.GetIdUser();
			//oLetrasDescuentoBE.IdTablaEstado= Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraEstadoLetrasDescuento);
			oLetrasDescuentoBE.IdTablaEstado= Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraSituacionLetras);
			oLetrasDescuentoBE.IdEstado= Convert.ToInt32(this.ddlbSituacion.SelectedValue);
			if(((CLetrasDescuento)new CLetrasDescuento()).Modificar(oLetrasDescuentoBE)>0)
			{
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionFinanciera",this.ToString(),"Se modificó Item de " + oLetrasDescuentoBE.ToString(),Enumerados.NivelesErrorLog.I.ToString()));
				//ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONREGISTRODESCUENTOLETRAS));
				ltlMensaje.Text = Helper.MensajeRetornoAlert();
			}
		}

		public void Eliminar()
		{
			// TODO:  Add DetallePaqueteLetrasDescuento.Eliminar implementation
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
			// TODO:  Add DetallePaqueteLetrasDescuento.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			LetrasDescuentoBE oLetrasDescuentoBE  = (LetrasDescuentoBE)((CLetrasDescuento) new CLetrasDescuento()).DetalleLetrasDescuento(Page.Request.Params[KEYIDDOCDESCLET],Page.Request.Params[KEYIDLETDESCTDET]);
			this.txtNroDocumento.Text =	oLetrasDescuentoBE.NroDocumento.ToString();
			this.hIdLetra.Value = oLetrasDescuentoBE.IdLetra.ToString();
			this.txtCentro.Value= oLetrasDescuentoBE.AbreviaturaCentroOperativo.ToString();
			((ListItem) this.ddlbSituacion.Items.FindByValue(oLetrasDescuentoBE.IdEstado.ToString())).Selected = true;
			this.txtSituacion.Value = oLetrasDescuentoBE.Situacion;
			this.txtProyecto.Value =  oLetrasDescuentoBE.NombreProyecto.ToString();
			this.txtDatosProyecto.Text=  oLetrasDescuentoBE.DescripcionProyecto.ToString();
			this.txtFechaInicio.Value= oLetrasDescuentoBE.FechaInicio.ToShortDateString();
			this.txtFechaVence.Value =  oLetrasDescuentoBE.FechaVencimiento.ToString().Substring(0,10);
			this.NDiasPlazo.Value = oLetrasDescuentoBE.NroDiasPlazo.ToString();
			this.nDiasVence.Value =  oLetrasDescuentoBE.NroDiasFaltantes.ToString();
			this.txtMoneda.Value= oLetrasDescuentoBE.Moneda.ToString();
			this.hNumero.Value =  oLetrasDescuentoBE.NroEntidad.ToString();
			this.txtEntidad.Value= oLetrasDescuentoBE.RazonSocial.ToString();
			this.nMonto.Value = oLetrasDescuentoBE.Monto.ToString();
			this.nTasaInteres.Value =  oLetrasDescuentoBE.TasaInteres.ToString();
			this.txtObservacion.Text =  oLetrasDescuentoBE.Observacion.ToString();
			
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add DetallePaqueteLetrasDescuento.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add DetallePaqueteLetrasDescuento.ValidarCampos implementation
			return true;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add DetallePaqueteLetrasDescuento.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add DetallePaqueteLetrasDescuento.ValidarExpresionesRegulares implementation
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
