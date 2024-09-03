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

namespace SIMA.SimaNetWeb.GestionFinanciera.Presupuesto
{
	/// <summary>
	/// Summary description for DetalledeRequerimiento.
	/// </summary>
	public class DetalledeRequerimiento : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		#region Constantes
			const string KEYIDREQUERIMIENTO="idrqr";
			const string KEYIDGRUPOCC="idGrupoCC";
			const string KEYIDCC="idCC";

		#endregion
		#region Controles
			protected System.Web.UI.WebControls.Label Label1;
			protected System.Web.UI.WebControls.Label Label2;
			protected System.Web.UI.WebControls.Label Label3;
			protected eWorld.UI.NumericBox nMonto;
			protected System.Web.UI.WebControls.Label lblTitulo;
			protected System.Web.UI.WebControls.Label Label6;
			protected System.Web.UI.WebControls.Label Label7;
			protected System.Web.UI.WebControls.Label Label4;
		protected eWorld.UI.CalendarPopup CalFecha;
		protected System.Web.UI.WebControls.TextBox txtNroDocumento;
		protected System.Web.UI.WebControls.TextBox txtMotivo;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.DropDownList ddlTipoDocumento;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.Label lblTipoPresupuesto;
		protected System.Web.UI.WebControls.DropDownList ddlTipoPresupuesto;
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
					this.CargarModoPagina();
					Helper.CalendarioControlStyle(this.CalFecha);
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
			// TODO:  Add DetalledeRequerimiento.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetalledeRequerimiento.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetalledeRequerimiento.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			this.ddlTipoDocumento.DataSource= (new CTablaTablas()).ListaTodosCombo(Convert.ToInt32(Utilitario.Enumerados.ParametroTablas.TipodeDocumentosdeSecretaria));
			this.ddlTipoDocumento.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			this.ddlTipoDocumento.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			this.ddlTipoDocumento.DataBind();			
		}

		public void LlenarDatos()
		{
			// TODO:  Add DetalledeRequerimiento.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			this.Enfocar();

		}
		void Enfocar(){
			this.ddlTipoDocumento.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,Helper.SetFocus("txtNroDocumento"));
			this.txtNroDocumento.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,Helper.SetFocus("nMonto"));
			this.nMonto.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,Helper.SetFocus("ddlTipoPresupuesto"));
			this.ddlTipoPresupuesto.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,Helper.SetFocus("txtMotivo"));
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetalledeRequerimiento.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetalledeRequerimiento.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetalledeRequerimiento.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add DetalledeRequerimiento.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add DetalledeRequerimiento.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			PresupuestoRequerimientoBE oPresupuestoRequerimientoBE = new PresupuestoRequerimientoBE();
			oPresupuestoRequerimientoBE.IdTipoDocumento = Convert.ToInt32(this.ddlTipoDocumento.SelectedValue);
			oPresupuestoRequerimientoBE.NroDocumento = this.txtNroDocumento.Text;
			oPresupuestoRequerimientoBE.Fecha = this.CalFecha.SelectedDate;
			oPresupuestoRequerimientoBE.Motivo = this.txtMotivo.Text;
			oPresupuestoRequerimientoBE.Descripcion = this.txtDescripcion.Text;
			oPresupuestoRequerimientoBE.Monto = 0;
			oPresupuestoRequerimientoBE.IdTipoPresupuesto = Convert.ToInt32(this.ddlTipoPresupuesto.SelectedValue);
			if((new CPresupuestoRequerimiento()).Insertar(oPresupuestoRequerimientoBE)>0)
			{					
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionFinanciera",this.ToString(),"Se Inserto Item de " + oPresupuestoRequerimientoBE.ToString(),Enumerados.NivelesErrorLog.I.ToString()));				
				Helper.MensajeRetornoAlert(Page);
			}			
		}

		public void Modificar()
		{
			PresupuestoRequerimientoBE oPresupuestoRequerimientoBE = new PresupuestoRequerimientoBE();
			oPresupuestoRequerimientoBE.IdRequerimiento = Convert.ToInt32(Page.Request.Params[KEYIDREQUERIMIENTO]);
			oPresupuestoRequerimientoBE.IdTipoDocumento = Convert.ToInt32(this.ddlTipoDocumento.SelectedValue);
			oPresupuestoRequerimientoBE.NroDocumento = this.txtNroDocumento.Text;
			oPresupuestoRequerimientoBE.Fecha = this.CalFecha.SelectedDate;
			oPresupuestoRequerimientoBE.Motivo = this.txtMotivo.Text;
			oPresupuestoRequerimientoBE.Descripcion = this.txtDescripcion.Text;
			oPresupuestoRequerimientoBE.Monto = Convert.ToDouble(this.nMonto.Text);
			if((new CPresupuestoRequerimiento()).Modificar(oPresupuestoRequerimientoBE)>0)
			{					
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionFinanciera",this.ToString(),"Se modificó Item de " + oPresupuestoRequerimientoBE.ToString(),Enumerados.NivelesErrorLog.I.ToString()));				
				Helper.MensajeRetornoAlert(Page);
			}			

		}

		public void Eliminar()
		{
			// TODO:  Add DetalledeRequerimiento.Eliminar implementation
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
					this.CargarModoModificar();
					Helper.BloquearControles(this);
					break;
			}						
		}

		public void CargarModoNuevo()
		{
			// TODO:  Add DetalledeRequerimiento.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			PresupuestoRequerimientoBE oPresupuestoRequerimientoBE =(PresupuestoRequerimientoBE) (new CPresupuestoRequerimiento()).DetalleRequerimiento(Convert.ToInt32(Page.Request.Params[KEYIDREQUERIMIENTO]),CNetAccessControl.GetIdUser());
			ListItem item;
			item = this.ddlTipoDocumento.Items.FindByValue(oPresupuestoRequerimientoBE.IdTipoDocumento.ToString());
			if(item!=null)
			{item.Selected = true;}
			this.txtNroDocumento.Text = oPresupuestoRequerimientoBE.NroDocumento.ToString();
			this.CalFecha.SelectedDate = Convert.ToDateTime(oPresupuestoRequerimientoBE.Fecha);
			this.nMonto.Text = Convert.ToDouble(oPresupuestoRequerimientoBE.Monto).ToString(Utilitario.Constantes.FORMATODECIMAL4);
			this.txtMotivo.Text = oPresupuestoRequerimientoBE.Motivo.ToString();
			this.txtDescripcion.Text = oPresupuestoRequerimientoBE.Descripcion.ToString();
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add DetalledeRequerimiento.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add DetalledeRequerimiento.ValidarCampos implementation
			return true;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add DetalledeRequerimiento.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add DetalledeRequerimiento.ValidarExpresionesRegulares implementation
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

	}
}
