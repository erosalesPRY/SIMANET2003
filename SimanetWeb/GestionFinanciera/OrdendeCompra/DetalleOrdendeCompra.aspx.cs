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

namespace SIMA.SimaNetWeb.GestionFinanciera.OrdendeCompra
{
	public class DetalleOrdendeCompra : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		#region Constante
			const string  KEYIDNROORDENCOMPRA="NroOC";
			const string  KEYIDPERIODO="Periodo";
	
			const string URLBUSQUEDAENTIDAD="../../Legal/BusquedaEntidad.aspx?";
			const string KEYTIPOBUSQUEDAENTIDAD = "TipoBusqueda";
		#endregion

		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.DropDownList ddlbCentroOperativo;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.DropDownList ddlbMoneda;
		protected System.Web.UI.WebControls.Label Label13;
		protected System.Web.UI.WebControls.Image ibtnBuscarEntidad;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvProvCli;
		protected System.Web.UI.WebControls.Label Label14;
		protected System.Web.UI.WebControls.Label Label18;
		protected System.Web.UI.WebControls.Label Label9;
		protected eWorld.UI.NumericBox nMonto;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.TextBox txtObservacion;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary Vresumen;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlbCentroOperativo;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlbSituacion;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlbMoneda;
		protected System.Web.UI.HtmlControls.HtmlInputText hNumero;
		protected System.Web.UI.HtmlControls.HtmlInputText txtEntidad;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdEntidad;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlbTipoTrabajo;
		protected System.Web.UI.HtmlControls.HtmlTable ToolBar;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnCancelar;
		protected System.Web.UI.WebControls.Label Label1;
		protected eWorld.UI.NumericBox nMontoGasto;
		protected System.Web.UI.HtmlControls.HtmlTable tblAtras;
		protected eWorld.UI.CalendarPopup CalFecha;
		protected System.Web.UI.WebControls.TextBox txtNroOC;
		protected System.Web.UI.WebControls.Label Label2;
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
					this.LlenarCombos();
					LlenarDatos();
					this.CargarModoPagina();
					
					//Helper.CalendarioControlStyle(this.CalFecha);
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
			this.ddlbCentroOperativo.SelectedIndexChanged += new System.EventHandler(this.ddlbCentroOperativo_SelectedIndexChanged);
			this.ibtnAceptar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAceptar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add DetalleOrdendeCompra.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetalleOrdendeCompra.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetalleOrdendeCompra.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			this.CargarMoneda();
			this.CargarSituacion();		
			this.CargarCentroOperativo();
		}
		private void CargarCentroOperativo()
		{
			CCentroOperativo oCCentroOperativo =   new  CCentroOperativo();
			ddlbCentroOperativo.DataSource = oCCentroOperativo.ListarCentroOperativoAccesoSegunPrivilegioUsuario(CNetAccessControl.GetIdUser(),Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraEstadodeOrdendeCompra));
			ddlbCentroOperativo.DataValueField=Enumerados.ColumnasCentroOperativo.IdCentroOperativo.ToString();
			ddlbCentroOperativo.DataTextField=Enumerados.ColumnasCentroOperativo.Nombre.ToString();
			ddlbCentroOperativo.DataBind();
			//Helper.SeleccionarItemCombos(this);
		}

		private void CargarMoneda()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			this.ddlbMoneda.DataSource= oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Utilitario.Enumerados.TablasTabla.Moneda));
			ddlbMoneda.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbMoneda.DataTextField = Enumerados.ColumnasTablaTablas.Var1.ToString();
			ddlbMoneda.DataBind();			
		}

		private void CargarSituacion()
		{
			/*CTablaTablas oCTablaTablas = new CTablaTablas();
			this.ddlbSituacion.DataSource= oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraEstadodeOrdendeCompra));
			ddlbSituacion.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbSituacion.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbSituacion.DataBind();	*/		
		}
		public void LlenarDatos()
		{
			
		}

		public void LlenarJScript()
		{
			this.ibtnBuscarEntidad.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.PopupBusqueda(URLBUSQUEDAENTIDAD + KEYTIPOBUSQUEDAENTIDAD + Utilitario.Constantes.SIGNOIGUAL + Enumerados.TipoBusquedaEntidad.PRODB.ToString(),700,800,true));
			this.ddlbCentroOperativo.Attributes[Enumerados.EventosJavaScript.OnChange.ToString()]= "ddlbCentroOperativo_SelectedIndexChanged(this)";
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetalleOrdendeCompra.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetalleOrdendeCompra.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetalleOrdendeCompra.Exportar implementation
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
			// TODO:  Add DetalleOrdendeCompra.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			OrdenCompraBE oOrdenCompraBE =new OrdenCompraBE();
			oOrdenCompraBE.MontoOC = Convert.ToDouble(this.nMonto.Text);
			oOrdenCompraBE.MontoGastoOC = Convert.ToDouble(this.nMontoGasto.Text);
			oOrdenCompraBE.IdMoneda = Convert.ToInt32(this.ddlbMoneda.SelectedValue);
			oOrdenCompraBE.IdProveedor = Convert.ToInt32(this.hIdEntidad.Value);
			oOrdenCompraBE.Fecha = Convert.ToDateTime(this.CalFecha.SelectedDate);
			oOrdenCompraBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();
			oOrdenCompraBE.IdTablaEstado = Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraEstadodeOrdendeCompra);
			oOrdenCompraBE.IdEstado = 1;//Convert.ToInt32(this.ddlbSituacion.SelectedValue);
			oOrdenCompraBE.Descripcion = this.txtObservacion.Text;
			oOrdenCompraBE.IdCentroOperativo = Convert.ToInt32(this.ddlbCentroOperativo.SelectedValue);
			if(Convert.ToInt32(this.ddlbCentroOperativo.SelectedValue)==3)
			{
				oOrdenCompraBE.NroOrdenCompra = this.txtNroOC.Text;
			}

			if(Convert.ToInt32(((COrdendeCompra) new COrdendeCompra()).Insertar(oOrdenCompraBE)) > Utilitario.Constantes.ValorConstanteCero)
			{
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Orden de Compra",this.ToString(),"Se registró Item de Orden de Compra" + ".",Enumerados.NivelesErrorLog.I.ToString()));
				ltlMensaje.Text = Helper.MensajeRetornoAlert(Utilitario.Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionFinanciera.ToString(), 
					Utilitario.Mensajes.CODIGOMENSAJESECONFIRMACIONCARTACREDITOREGISTRO));
			}					

		}

		public void Modificar()
		{
			OrdenCompraBE oOrdenCompraBE =new OrdenCompraBE();
			oOrdenCompraBE.Periodo = Convert.ToInt32(Page.Request.Params[KEYIDPERIODO]);
			oOrdenCompraBE.NroOrdenCompra = Page.Request.Params[KEYIDNROORDENCOMPRA].ToString();
			oOrdenCompraBE.IdCentroOperativo = Convert.ToInt32(this.ddlbCentroOperativo.SelectedValue);
			oOrdenCompraBE.MontoOC = Convert.ToDouble(this.nMonto.Text);
			oOrdenCompraBE.MontoGastoOC = Convert.ToDouble(this.nMontoGasto.Text);
			oOrdenCompraBE.IdMoneda = Convert.ToInt32(this.ddlbMoneda.SelectedValue);
			oOrdenCompraBE.IdProveedor = Convert.ToInt32(this.hIdEntidad.Value);
			oOrdenCompraBE.Fecha = Convert.ToDateTime(this.CalFecha.SelectedDate);
			oOrdenCompraBE.IdUsuarioActualizacion = CNetAccessControl.GetIdUser();
			oOrdenCompraBE.IdTablaEstado = Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraEstadodeOrdendeCompra);
			oOrdenCompraBE.IdEstado = 1;//Convert.ToInt32(this.ddlbSituacion.SelectedValue);
			oOrdenCompraBE.Descripcion = this.txtObservacion.Text;
			
			if(Convert.ToInt32(((COrdendeCompra) new COrdendeCompra()).Modificar(oOrdenCompraBE)) > Utilitario.Constantes.ValorConstanteCero)
			{
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Orden de Compra",this.ToString(),"Se Modifico Item de Orden de Compra" + ".",Enumerados.NivelesErrorLog.I.ToString()));
				ltlMensaje.Text = Helper.MensajeRetornoAlert(Utilitario.Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionFinanciera.ToString(), 
					Utilitario.Mensajes.CODIGOMENSAJECONFIRMACIONORDENDECOMPRAMODIFICACION));
			}					
		}

		public void Eliminar()
		{
			// TODO:  Add DetalleOrdendeCompra.Eliminar implementation
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
//						Helper.BloquearControles(this);
//						this.ibtnCancelar.Visible=false;
//						this.ToolBar.Style.Add("display","none");
//						this.tblAtras.Visible= true;
					}
					break;			
			}		
		}

		public void CargarModoNuevo()
		{
			// TODO:  Add DetalleOrdendeCompra.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			OrdenCompraBE oOrdenCompraBE = (OrdenCompraBE)((COrdendeCompra) new COrdendeCompra()).DetalledeOrdendeCompra(Convert.ToInt32(Page.Request.Params[KEYIDPERIODO])
																															,Page.Request.Params[KEYIDNROORDENCOMPRA].ToString()
																															,CNetAccessControl.GetIdUser());

			((ListItem) this.ddlbCentroOperativo.Items.FindByValue(oOrdenCompraBE.IdCentroOperativo.ToString())).Selected = true;
			//((ListItem) this.ddlbSituacion.Items.FindByValue(oOrdenCompraBE.IdEstado.ToString())).Selected = true;
			((ListItem) this.ddlbMoneda.Items.FindByValue(oOrdenCompraBE.IdMoneda.ToString())).Selected = true;
			this.hIdEntidad.Value = oOrdenCompraBE.IdProveedor.ToString();
			this.txtNroOC.Text = oOrdenCompraBE.OrdenCompra.ToString();
			this.txtNroOC.Enabled =false;
			this.txtNroOC.CssClass = "disabled";
			this.hNumero.Value = oOrdenCompraBE.IdProveedor.ToString();//oOrdenCompraBE.OrdenCompra.ToString();
			//this.hNumero.Visible = false;
			this.txtEntidad.Value = oOrdenCompraBE.NProveedor.ToString();
			this.CalFecha.SelectedDate = Convert.ToDateTime(oOrdenCompraBE.Fecha);
			this.nMonto.Text = oOrdenCompraBE.MontoOC.ToString();
			this.nMontoGasto.Text = oOrdenCompraBE.MontoGastoOC.ToString();
			this.txtObservacion.Text = oOrdenCompraBE.Descripcion.ToString();
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add DetalleOrdendeCompra.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			if(Convert.ToInt32(this.ddlbCentroOperativo.SelectedItem.Value)==3)
			{
				if(txtNroOC.Text == String.Empty)
				{
					Helper.MsgBox("Ingrese Nro de Orden De Compra");
					return false;
				}
			}
			return true;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add DetalleOrdendeCompra.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add DetalleOrdendeCompra.ValidarExpresionesRegulares implementation
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
				ASPNetUtilitario.MessageBox.Show(oException.Message.ToString());
				string ex = oException.Message.ToString();
				SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
				Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
			}
		
		}

		private void ddlbCentroOperativo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//Helper.ReiniciarSession();
		}
	}
}

