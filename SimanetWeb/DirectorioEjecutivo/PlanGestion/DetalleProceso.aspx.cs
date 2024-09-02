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
using SIMA.Controladoras.GestionEstrategica;
using SIMA.Controladoras.General;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using SIMA.EntidadesNegocio.GestionEstrategica;

namespace SIMA.SimaNetWeb.DirectorioEjecutivo.PlanGestion
{
	/// <summary>
	/// Summary description for DetalleProceso.
	/// </summary>
	public class DetalleProceso : System.Web.UI.Page, IPaginaBase, IPaginaMantenimento
	{
		#region Controles
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblDefinicion;
		protected System.Web.UI.WebControls.TextBox txtDefinicion;
		protected System.Web.UI.WebControls.Label lblAlcance;
		protected System.Web.UI.WebControls.TextBox txtAlcance;
		protected System.Web.UI.WebControls.Label lblResponsable;
		protected System.Web.UI.WebControls.TextBox txtResponsable;
		protected System.Web.UI.WebControls.Label lblLider;
		protected System.Web.UI.WebControls.Label lblParticipantes;
		protected System.Web.UI.WebControls.TextBox txtParticipante;
		protected System.Web.UI.WebControls.Label lblCO;
		protected System.Web.UI.WebControls.DropDownList ddlbCentroOperativo;
		protected System.Web.UI.HtmlControls.HtmlTable Table2;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.ImageButton ibtnCancelar;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.ImageButton ibtnBuscarLider;
		protected System.Web.UI.WebControls.TextBox txtLider;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox txtCodigoProceso;
		protected System.Web.UI.WebControls.TextBox txtNombreProceso;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdAreaLider;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdPersonalLider;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidCargoLider;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvNombreProceso;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hNombreLider;
		protected System.Web.UI.WebControls.Image Image1;
		#endregion
	
		#region Constantes
		
		//Titulos 
		const string TITULOMODONUEVO = "NUEVO PROCESO";
		const string TITULOMODOMODIFICAR = "PROCESO";

		//Key Session y QueryString
		const string KEYQID = "Id";
		const string KEYQIDPRESENTE = "IdPresente";
		const string KEYQCANTIDAD = "Cantidad";
	
		//Paginas
		const string URLPRINCIPAL = "AdministrarProceso.aspx";
		const string URLBUSQUEDALIDER = "BusquedaLider.aspx?";
		
		#endregion Constantes		
		

		#region Variables
		
		#endregion Variables

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
			this.ibtnCancelar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnCancelar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			ProcesoBE oProcesoBE = new ProcesoBE();
			oProcesoBE.CODIGOPROCESO = txtCodigoProceso.Text;
			oProcesoBE.NOMBREPROCESO = txtNombreProceso.Text;
			oProcesoBE.DEFINICION = txtDefinicion.Text;
			oProcesoBE.ALCANCE = txtAlcance.Text;
			oProcesoBE.RESPONSABLE = txtResponsable.Text;
//			oAccionBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();
//			oAccionBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.EstadosPlanDirector);
//			oAccionBE.IdEstado = Convert.ToInt32(Enumerados.EstadoPlanDirector.Activo);

			
			if(this.hidCargoLider.Value!=String.Empty)
			{
				oProcesoBE.IDCARGOLIDER = Convert.ToInt32( this.hidCargoLider.Value);
			}
			if(this.hIdAreaLider.Value!=String.Empty)
			{
				oProcesoBE.IDAREALIDER = Convert.ToInt32(this.hIdAreaLider.Value);
			}
			if(this.hIdPersonalLider.Value!=String.Empty)			
			{
				oProcesoBE.IDPERSONALLIDER = Convert.ToInt32(this.hIdPersonalLider.Value);
			}
			
			oProcesoBE.PARTICIPANTES = txtParticipante.Text;
			oProcesoBE.CO = Convert.ToInt32(ddlbCentroOperativo.SelectedIndex);

			CMantenimientos oCMantenimientos = new CMantenimientos();
			if(oCMantenimientos.Insertar(oProcesoBE)>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Plan de Gestion",this.ToString(),"Se Agregó el Proceso Nro. " + Page.Request.QueryString[Utilitario.Enumerados.ColumnasProceso.CodigoProceso.ToString()] + ".",Enumerados.NivelesErrorLog.I.ToString()));
				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionEstrategica.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONREGISTROPROCESO),URLPRINCIPAL);
			}
		}

		public void Modificar()
		{
			ProcesoBE oProcesoBE = new ProcesoBE();
			oProcesoBE.IDPROCESO = Convert.ToInt32(Page.Request.QueryString[Utilitario.Enumerados.ColumnasProceso.IdProceso.ToString()]);
			oProcesoBE.CODIGOPROCESO = txtCodigoProceso.Text;
			oProcesoBE.NOMBREPROCESO = txtNombreProceso.Text;
			oProcesoBE.DEFINICION = txtDefinicion.Text;
			oProcesoBE.ALCANCE = txtAlcance.Text;
			oProcesoBE.RESPONSABLE = txtResponsable.Text;
//			oBuqueBE.IdUsuarioActualizacion = CNetAccessControl.GetIdUser();
//			oBuqueBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.EstadosBuque);
//			oBuqueBE.IdEstado = Convert.ToInt32(Enumerados.EstadoPlanDirector.Modificado);
			
			if(this.hidCargoLider.Value!=String.Empty)
			{
				oProcesoBE.IDCARGOLIDER = Convert.ToInt32( this.hidCargoLider.Value);
			}
			if(this.hIdAreaLider.Value!=String.Empty)
			{
				oProcesoBE.IDAREALIDER = Convert.ToInt32(this.hIdAreaLider.Value);
			}
			if(this.hIdPersonalLider.Value!=String.Empty)			
			{
				oProcesoBE.IDPERSONALLIDER = Convert.ToInt32(this.hIdPersonalLider.Value);
			}

			oProcesoBE.PARTICIPANTES = txtParticipante.Text;
			oProcesoBE.CO = Convert.ToInt32(ddlbCentroOperativo.SelectedIndex);

			CMantenimientos oCMantenimientos = new CMantenimientos();
			if(oCMantenimientos.Modificar(oProcesoBE)>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Plan de Gestion",this.ToString(),"Se modificó el Proceso Nro. " + Page.Request.QueryString[Utilitario.Enumerados.ColumnasProceso.CodigoProceso.ToString()] + ".",Enumerados.NivelesErrorLog.I.ToString()));
				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionEstrategica.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONMODIFICARPROCESO),URLPRINCIPAL);
			}
		}

		public void Eliminar()
		{
			// TODO:  Add DetallePresentesOtorgadosPorTipoPersona.Eliminar implementation
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
			this.llenarCentrosOperativos();
		}

		public void CargarModoModificar()
		{
			lblTitulo.Text = TITULOMODOMODIFICAR;
			this.llenarCentrosOperativos();
			
			CMantenimientos	oCMantenimientos = new CMantenimientos();
			ProcesoBE oProcesoBE = (ProcesoBE)oCMantenimientos.ListarDetalle(Convert.ToInt32(Page.Request.QueryString[Utilitario.Enumerados.ColumnasProceso.IdProceso.ToString()]),Enumerados.ClasesNTAD.PlanGestionNTAD.ToString());
		
			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"PlanGestion",this.ToString(),"Se consultó el Detalle del Proceso del Plan de Gestión " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

			if(oProcesoBE!=null)
			{
				this.txtCodigoProceso.Text = oProcesoBE.CODIGOPROCESO.ToString().ToUpper();
				this.txtNombreProceso.Text = oProcesoBE.NOMBREPROCESO.ToString().ToUpper();
				this.txtDefinicion.Text = oProcesoBE.DEFINICION.ToString().ToUpper();
				this.txtAlcance.Text = oProcesoBE.ALCANCE.ToString().ToUpper();
				this.txtResponsable.Text = oProcesoBE.RESPONSABLE.ToString().ToUpper();
				this.txtLider.Text = oProcesoBE.LIDER.ToString().ToUpper();
				this.txtParticipante.Text = oProcesoBE.PARTICIPANTES.ToString().ToUpper();
				this.ddlbCentroOperativo.Items.FindByValue(oProcesoBE.CO.ToString()).Selected = true;
				this.hidCargoLider.Value = oProcesoBE.IDCARGOLIDER.ToString();
				this.hIdAreaLider.Value = oProcesoBE.IDAREALIDER.ToString();
				this.hIdPersonalLider.Value = oProcesoBE.IDPERSONALLIDER.ToString();
			}
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add DetallePresentesOtorgadosPorTipoPersona.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			if(this.ValidarCamposRequeridos())
			{
				return this.ValidarExpresionesRegulares();
			}
			else
			{
				return false;
			}
		}

		public bool ValidarCamposRequeridos()
		{
			if(this.txtCodigoProceso.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJELISTAPROTOCOLARCAMPOREQUERIDOCLIENTEPERSONAL));
				return false;
			}

			if(this.txtNombreProceso.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJELISTAPROTOCOLARCAMPOREQUERIDOCLIENTEPERSONAL));
				return false;
			}
			return true;
		}

		public bool ValidarExpresionesRegulares()
		{
//			if(!ExpresionesRegulares.ValidarExpresionRegularEnterosPositivos(Server.HtmlEncode(this.txtAlcance.Text)))
//			{
//				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesErrorComercialUsuario(Mensajes.CODIGOMENSAJELISTAPROTOCOLARDATOSINCORRECTOSCANTIDAD));
//				return false;
//			}
			return true;
		}

		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add DetallePresentesOtorgadosPorTipoPersona.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetallePresentesOtorgadosPorTipoPersona.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetallePresentesOtorgadosPorTipoPersona.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
//			lItem = new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,Utilitario.Constantes.VALORSELECCIONAR);
//			this.llenarPresente();
//			this.llenarCentrosOperativos();
//			this.llenarTipoDocumento();
//			this.ddlbPresente.Items.Insert(0,lItem);
//			this.ddlbCentroOperativo.Items.Insert(0,lItem);
//			this.ddlbTipoDocumento.Items.Insert(0,lItem);
		}

		public void LlenarDatos()
		{
			// TODO:  Add DetallePresentesOtorgadosPorTipoPersona.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			this.ibtnBuscarLider.Attributes.Add(Constantes.EVENTOCLICK,Helper.PopupBusqueda(URLBUSQUEDALIDER + Utilitario.Constantes.KEYMODOPAGINA +  Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.C.ToString(),750,500,true));
//
//			this.rfvNombres.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJELISTAPROTOCOLARCAMPOREQUERIDOCLIENTEPERSONAL);
//			this.rfvNombres.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJELISTAPROTOCOLARCAMPOREQUERIDOCLIENTEPERSONAL);
//
//			this.rfvCentroOperativo.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJELISTAPROTOCOLARCAMPOREQUERIDOCENTROOPERATIVO);
//			this.rfvCentroOperativo.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJELISTAPROTOCOLARCAMPOREQUERIDOCENTROOPERATIVO);
//			this.rfvCentroOperativo.InitialValue = Constantes.VALORSELECCIONAR;
//
//			this.rfvPresente.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJELISTAPROTOCOLARCAMPOREQUERIDOPRESENTE);
//			this.rfvPresente.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJELISTAPROTOCOLARCAMPOREQUERIDOPRESENTE);
//			this.rfvPresente.InitialValue = Constantes.VALORSELECCIONAR;
//
//			this.rfvCantidad.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJELISTAPROTOCOLARCAMPOREQUERIDOCANTIDAD);
//			this.rfvCantidad.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJELISTAPROTOCOLARCAMPOREQUERIDOCANTIDAD);
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetallePresentesOtorgadosPorTipoPersona.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetallePresentesOtorgadosPorTipoPersona.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetallePresentesOtorgadosPorTipoPersona.Exportar implementation
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
			// TODO:  Add DetallePresentesOtorgadosPorTipoPersona.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void llenarCentrosOperativos()
		{
			ListItem lItem = new ListItem(Constantes.TEXTOSSELECCIONAR,Constantes.VALORSELECCIONAR);
			CCentroOperativo oCCentroOperativo =  new CCentroOperativo();
			ddlbCentroOperativo.DataSource = oCCentroOperativo.ListarTodosComboCombinaciones();
			ddlbCentroOperativo.DataValueField=Enumerados.ColumnasTablasTablas.Codigo.ToString();
			ddlbCentroOperativo.DataTextField=Enumerados.ColumnasTablasTablas.Var1.ToString();
			ddlbCentroOperativo.DataBind();
			ddlbCentroOperativo.Items.Insert(0,lItem);
		}

		private void ibtnCancelar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.redireccionaPaginaPrincipal();
		}

		private void redireccionaPaginaPrincipal()
		{
			Page.Response.Redirect(URLPRINCIPAL);
		}

		private void ibtnAceptar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				if(Page.IsValid)
				{
//					if(this.ValidarCampos())
//					{
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
//					}
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
