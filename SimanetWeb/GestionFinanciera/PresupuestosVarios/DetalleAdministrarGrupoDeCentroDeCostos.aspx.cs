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
using SIMA.Controladoras.General;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using SIMA.EntidadesNegocio.GestionFinanciera;
using NetAccessControl;

namespace SIMA.SimaNetWeb.GestionFinanciera
{
	/// <summary>
	/// Summary description for DetalleAdministrarGrupoDeCentroDeCostos.
	/// </summary>
	public class DetalleAdministrarGrupoDeCentroDeCostos : System.Web.UI.Page, IPaginaMantenimento, IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary vSum;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.TextBox txtNroGrupoCC;
		protected System.Web.UI.WebControls.TextBox txtNombreGrupoCC;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.ImageButton ibtnCancelar;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvNroGCC;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvNombreGCC;
		#endregion 
		
		#region Constantes
		const string URLPRINCIPAL = "AdministrarGrupoDeCentroDeCostos.aspx";
		const string TITULOMODONUEVO = "NUEVO GRUPO DE CENTRO DE COSTOS";
		const string TITULOMODOMODIFICAR = "GRUPO DE CENTRO DE COSTOS";
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.DropDownList ddlbTipoPresupuesto;
		
		
		const string KEYQID = "Id";
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvTipoPresupuesto;
		ListItem  lItem ;

		#endregion Constantes
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					//this.ConfigurarAccesoControles();

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
			this.txtNroGrupoCC.TextChanged += new System.EventHandler(this.txtNroGrupoCC_TextChanged);
			this.ibtnAceptar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAceptar_Click);
			this.ibtnCancelar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnCancelar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			GrupoCentroCostoBE oGrupoCentroCostoBE = new GrupoCentroCostoBE();
			
			oGrupoCentroCostoBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();
			oGrupoCentroCostoBE.NroGrupoCC = this.txtNroGrupoCC.Text.ToUpper();
			oGrupoCentroCostoBE.Nombre = this.txtNombreGrupoCC.Text.ToUpper();
			oGrupoCentroCostoBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.EstadoGrupoCentroCosto);
			oGrupoCentroCostoBE.IdEstado = Convert.ToInt32(Enumerados.EstadoGrupoCentroCosto.Activo);
			oGrupoCentroCostoBE.IdTipoPresupuestoCuenta = Convert.ToInt32(this.ddlbTipoPresupuesto.SelectedValue);
			
			CMantenimientos oCMantenimientos = new CMantenimientos();
			int retorno = oCMantenimientos.Insertar(oGrupoCentroCostoBE);

			if(retorno>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Financiera",this.ToString(),"Se registró la el Grupo de Centro de Costo Nro. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));

				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionFinanciera.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONREGISTROGRUPOCC),URLPRINCIPAL);
			}
			else if (retorno == -1)
			{
			
			  ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesErrorFinanciera.ToString(),Mensajes.CODIGOMENSAJENROGRUPOEXISTENTE));
			
			}
			
		}

		public void Modificar()
		{
			GrupoCentroCostoBE oGrupoCentroCostoBE = new GrupoCentroCostoBE();
			
			oGrupoCentroCostoBE.IdGrupoCC = Convert.ToInt32(Page.Request.QueryString[KEYQID]);
			oGrupoCentroCostoBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();
			oGrupoCentroCostoBE.NroGrupoCC = this.txtNroGrupoCC.Text.ToUpper();
			oGrupoCentroCostoBE.Nombre = this.txtNombreGrupoCC.Text.ToUpper();
			oGrupoCentroCostoBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.EstadoGrupoCentroCosto);
			oGrupoCentroCostoBE.IdEstado = Convert.ToInt32(Enumerados.EstadoGrupoCentroCosto.Activo);
			oGrupoCentroCostoBE.IdTipoPresupuestoCuenta = Convert.ToInt32(this.ddlbTipoPresupuesto.SelectedValue);
			
			CMantenimientos oCMantenimientos = new CMantenimientos();
			int retorno = oCMantenimientos.Modificar(oGrupoCentroCostoBE);

			if(retorno>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Documentaria",this.ToString(),"Se registró la Dependencia Naval Nro. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));

				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionFinanciera.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONMODIFICACIONESGRUPOCC),URLPRINCIPAL);
			}
			else if (retorno == 0)
			{
			
				ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesErrorFinanciera.ToString(),Mensajes.CODIGOMENSAJENROGRUPOEXISTENTE));
			
			}
			
		}

		public void Eliminar()
		{
			// TODO:  Add DetalleAdministrarGrupoDeCentroDeCostos.Eliminar implementation
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
			GrupoCentroCostoBE oGrupoCentroCostoBE = (GrupoCentroCostoBE)oCMantenimientos.ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYQID]),Enumerados.ClasesNTAD.GrupoCentroCostoNTAD.ToString());
			
			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Documentaria",this.ToString(),"Se consultó el Detalle del Grupo de Centro de Costo Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

			if(oGrupoCentroCostoBE!=null)
			{
			
				this.txtNroGrupoCC.Text = oGrupoCentroCostoBE.NroGrupoCC.ToString();
				this.txtNombreGrupoCC.Text = oGrupoCentroCostoBE.Nombre.ToString();
				this.ddlbTipoPresupuesto.Items.FindByValue(oGrupoCentroCostoBE.IdTipoPresupuestoCuenta.ToString()).Selected = true;
				
			}
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add DetalleAdministrarGrupoDeCentroDeCostos.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			return this.ValidarCamposRequeridos();
		}

		public bool ValidarCamposRequeridos()
		{
			if(this.txtNroGrupoCC.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionGestionFinancieraUsuario(Mensajes.CODIGOMENSAJECAMPONROGCC));
				return false;
			}
			if(this.txtNombreGrupoCC.Text.Trim() == String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionGestionFinancieraUsuario(Mensajes.CODIGOMENSAJECAMPONOMBREGCC));
				return false;
			}
			if(this.ddlbTipoPresupuesto.SelectedItem.Text == Constantes.TEXTOSSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionGestionFinancieraUsuario(Mensajes.CODIGOMENSAJECAMPOTIPOPRESUPUESTOGCC));
				return false;
			}
			
			return true;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add DetalleAdministrarGrupoDeCentroDeCostos.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion

		private void txtNroGrupoCC_TextChanged(object sender, System.EventArgs e)
		{
		
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
		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add DetalleAdministrarGrupoDeCentroDeCostos.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetalleAdministrarGrupoDeCentroDeCostos.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetalleAdministrarGrupoDeCentroDeCostos.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			lItem = new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,Utilitario.Constantes.VALORSELECCIONAR);
			this.llenarTipoPresupuestos();
			this.ddlbTipoPresupuesto.Items.Insert(0,lItem);
		}
		
		public void LlenarDatos()
		{
			// TODO:  Add DetalleAdministrarGrupoDeCentroDeCostos.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			
			this.rfvNroGCC.ErrorMessage = Helper.ObtenerMensajesConfirmacionGestionFinancieraUsuario(Mensajes.CODIGOMENSAJECAMPONROGCC);
			this.rfvNroGCC.ToolTip = Helper.ObtenerMensajesConfirmacionGestionFinancieraUsuario(Mensajes.CODIGOMENSAJECAMPONROGCC);

			this.rfvNombreGCC.ErrorMessage = Helper.ObtenerMensajesConfirmacionGestionFinancieraUsuario(Mensajes.CODIGOMENSAJECAMPONOMBREGCC);
			this.rfvNombreGCC.ToolTip = Helper.ObtenerMensajesConfirmacionGestionFinancieraUsuario(Mensajes.CODIGOMENSAJECAMPONOMBREGCC);

		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetalleAdministrarGrupoDeCentroDeCostos.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetalleAdministrarGrupoDeCentroDeCostos.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetalleAdministrarGrupoDeCentroDeCostos.Exportar implementation
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
			// TODO:  Add DetalleAdministrarGrupoDeCentroDeCostos.ValidarFiltros implementation
			return false;
		}

		#endregion

		public void llenarTipoPresupuestos()
		{
		
			CGrupoCentroCosto oCGrupoCentroCosto = new CGrupoCentroCosto();
			ddlbTipoPresupuesto.DataSource = oCGrupoCentroCosto.ListarTodosComboPresupuesto();
			ddlbTipoPresupuesto.DataValueField =Enumerados.ColumnaTipoPresupuesto.idTipoPresupuesto.ToString();
			ddlbTipoPresupuesto.DataTextField =Enumerados.ColumnaTipoPresupuesto.nombre.ToString();
			ddlbTipoPresupuesto.DataBind();
			
		
		}
		private void ibtnCancelar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.redireccionaPaginaPrincipal();
		}
		private void redireccionaPaginaPrincipal()
		{
			Page.Response.Redirect(URLPRINCIPAL);
		}
	}
}
