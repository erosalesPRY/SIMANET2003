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
	/// Summary description for DetalleSubProceso.
	/// </summary>
	public class DetalleSubProceso : System.Web.UI.Page, IPaginaBase, IPaginaMantenimento
	{
		#region Controles
		protected System.Web.UI.WebControls.ImageButton ibtnCancelar;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidCargoLider;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdAreaLider;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvCodigoProceso;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvNombreProceso;
		protected System.Web.UI.HtmlControls.HtmlTable Table2;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdPersonalLider;
		protected System.Web.UI.WebControls.TextBox txtCodigoSubProceso;
		protected System.Web.UI.WebControls.TextBox txtNombreSubProceso;
		protected System.Web.UI.WebControls.Label lblAE;
		protected System.Web.UI.WebControls.Label lblAF;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected eWorld.UI.NumericBox txtAvanceEconomica;
		protected System.Web.UI.WebControls.DomValidators.RangeDomValidator RangeDomValidator1;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary vSum;
		protected eWorld.UI.NumericBox txtAvanceFinanciero;
		protected System.Web.UI.WebControls.DomValidators.RangeDomValidator RangeDomValidator2;
		protected System.Web.UI.WebControls.Label lblNombreProceso;
		protected System.Web.UI.WebControls.Label lblProceso;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hNombreLider;
		protected System.Web.UI.WebControls.ImageButton ibtnBuscarLider;
		protected System.Web.UI.WebControls.TextBox txtLider;
		protected System.Web.UI.WebControls.Label lblLider;
		protected System.Web.UI.WebControls.Label lblResponsable;
		protected System.Web.UI.WebControls.TextBox txtResponsable;
		protected System.Web.UI.WebControls.Image Image1;
		#endregion Controles
	
		#region Constantes
		
		//Titulos 
		const string TITULOMODONUEVO = "NUEVO SUBPROCESO";
		const string TITULOMODOMODIFICAR = "MODIFICAR SUBPROCESO";

		//Key Session y QueryString
		const string KEYQID = "Id";
		const string KEYQIDPROCESO = "idProceso";
		const string KEYIDSUBPROCESO = "idSubProceso";
		const string CODIGOPROCESO = "CodigoProceso";
		const string NOMBREPROCESO = "NombreProceso";
	
		//Paginas
		const string URLPRINCIPAL = "AdministrarSubProceso.aspx?";
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
					
					this.LlenarTitulos();

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
			SubProcesoBE oSubProcesoBE = new SubProcesoBE();
			//oSubProcesoBE.IDSUBPROCESO = Convert.ToInt32(Page.Request.QueryString[Utilitario.Enumerados.ColumnasSubProceso.IdSubProceso.ToString()]);
			oSubProcesoBE.IDPROCESO = Convert.ToInt32(Page.Request.QueryString[Utilitario.Enumerados.ColumnasProceso.IdProceso.ToString()]);
			oSubProcesoBE.CODIGOSUBPROCESO = txtCodigoSubProceso.Text;
			oSubProcesoBE.DESCRIPCION = txtNombreSubProceso.Text;
//			oAccionBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();
//			oAccionBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.EstadosPlanDirector);
//			oAccionBE.IdEstado = Convert.ToInt32(Enumerados.EstadoPlanDirector.Activo);
			
			if(this.txtAvanceEconomica.Text!=String.Empty)
			{
				oSubProcesoBE.AVANCEECONOMICO = Convert.ToDouble(txtAvanceEconomica.Text);
			}
			else
			{
				oSubProcesoBE.AVANCEECONOMICO = 0;
			}
			
			if(this.txtAvanceFinanciero.Text!=String.Empty)
			{
				oSubProcesoBE.AVANCEFINANCIERO = Convert.ToDouble(txtAvanceFinanciero.Text);
			}	
			else
			{
				oSubProcesoBE.AVANCEFINANCIERO = 0;
			}
			
			oSubProcesoBE.RESPONSABLE = txtResponsable.Text;
			oSubProcesoBE.LIDER = txtLider.Text;
			
			if(this.hidCargoLider.Value!=String.Empty)
			{
				oSubProcesoBE.IDCARGOLIDER = Convert.ToInt32( this.hidCargoLider.Value);
			}
			if(this.hIdAreaLider.Value!=String.Empty)
			{
				oSubProcesoBE.IDAREALIDER = Convert.ToInt32(this.hIdAreaLider.Value);
			}
			if(this.hIdPersonalLider.Value!=String.Empty)			
			{
				oSubProcesoBE.IDPERSONALLIDER = Convert.ToInt32(this.hIdPersonalLider.Value);
			}

			CMantenimientos oCMantenimientos = new CMantenimientos();
			if(oCMantenimientos.Insertar(oSubProcesoBE)>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Plan de Gestion",this.ToString(),"Se Agregó el Proceso Nro. " + Page.Request.QueryString[Utilitario.Enumerados.ColumnasProceso.CodigoProceso.ToString()] + ".",Enumerados.NivelesErrorLog.I.ToString()));
				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionEstrategica.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONREGISTROSUBPROCESO),URLPRINCIPAL +
					KEYQIDPROCESO +
					Utilitario.Constantes.SIGNOIGUAL +
					Page.Request.QueryString[Utilitario.Enumerados.ColumnasProceso.IdProceso.ToString()] +
					Utilitario.Constantes.SIGNOAMPERSON +
					KEYIDSUBPROCESO +
					Utilitario.Constantes.SIGNOIGUAL +
					Page.Request.QueryString[Utilitario.Enumerados.ColumnasSubProceso.IdSubProceso.ToString()] +
					Utilitario.Constantes.SIGNOAMPERSON +
					CODIGOPROCESO +
					Utilitario.Constantes.SIGNOIGUAL +
					Page.Request.QueryString[Utilitario.Enumerados.ColumnasProceso.CodigoProceso.ToString()] +
					Utilitario.Constantes.SIGNOAMPERSON +
					NOMBREPROCESO +
					Utilitario.Constantes.SIGNOIGUAL +
					Page.Request.QueryString[Utilitario.Enumerados.ColumnasProceso.NombreProceso.ToString()]
					);

			}
		}

		public void Modificar()
		{
			SubProcesoBE oSubProcesoBE = new SubProcesoBE();
			oSubProcesoBE.IDSUBPROCESO = Convert.ToInt32(Page.Request.QueryString[Utilitario.Enumerados.ColumnasSubProceso.IdSubProceso.ToString()]);
			oSubProcesoBE.IDPROCESO = Convert.ToInt32(Page.Request.QueryString[Utilitario.Enumerados.ColumnasProceso.IdProceso.ToString()]);
			oSubProcesoBE.CODIGOSUBPROCESO = txtCodigoSubProceso.Text;
			oSubProcesoBE.DESCRIPCION = txtNombreSubProceso.Text;
//			oSubProcesoBE.IdUsuarioActualizacion = CNetAccessControl.GetIdUser();
//			oSubProcesoBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.EstadosBuque);
//			oSubProcesoBE.IdEstado = Convert.ToInt32(Enumerados.EstadoPlanDirector.Modificado);
			
			if(this.txtAvanceEconomica.Text!=String.Empty)
			{
				oSubProcesoBE.AVANCEECONOMICO = Convert.ToDouble(txtAvanceEconomica.Text);
			}
			else
			{
				oSubProcesoBE.AVANCEECONOMICO = 0;
			}
			
			if(this.txtAvanceFinanciero.Text!=String.Empty)
			{
				oSubProcesoBE.AVANCEFINANCIERO = Convert.ToDouble(txtAvanceFinanciero.Text);
			}	
			else
			{
				oSubProcesoBE.AVANCEFINANCIERO = 0;
			}
			
			oSubProcesoBE.RESPONSABLE = txtResponsable.Text;
			//oSubProcesoBE.LIDER = txtLider.Text;
			
			if(this.hidCargoLider.Value!=String.Empty)
			{
				oSubProcesoBE.IDCARGOLIDER = Convert.ToInt32( this.hidCargoLider.Value);
			}
			if(this.hIdAreaLider.Value!=String.Empty)
			{
				oSubProcesoBE.IDAREALIDER = Convert.ToInt32(this.hIdAreaLider.Value);
			}
			if(this.hIdPersonalLider.Value!=String.Empty)			
			{
				oSubProcesoBE.IDPERSONALLIDER = Convert.ToInt32(this.hIdPersonalLider.Value);
			}

			CMantenimientos oCMantenimientos = new CMantenimientos();
			if(oCMantenimientos.Modificar(oSubProcesoBE)>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Plan de Gestion",this.ToString(),"Se modificó el Proceso Nro. " + Page.Request.QueryString[Utilitario.Enumerados.ColumnasProceso.CodigoProceso.ToString()] + ".",Enumerados.NivelesErrorLog.I.ToString()));
				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionEstrategica.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONMODIFICARSUBPROCESO),URLPRINCIPAL + 
					KEYQIDPROCESO +
					Utilitario.Constantes.SIGNOIGUAL +
					Page.Request.QueryString[Utilitario.Enumerados.ColumnasProceso.IdProceso.ToString()] +
					Utilitario.Constantes.SIGNOAMPERSON +
					KEYIDSUBPROCESO +
					Utilitario.Constantes.SIGNOIGUAL +
					Page.Request.QueryString[Utilitario.Enumerados.ColumnasSubProceso.IdSubProceso.ToString()] +
					Utilitario.Constantes.SIGNOAMPERSON +
					CODIGOPROCESO +
					Utilitario.Constantes.SIGNOIGUAL +
					Page.Request.QueryString[Utilitario.Enumerados.ColumnasProceso.CodigoProceso.ToString()] +
					Utilitario.Constantes.SIGNOAMPERSON +
					NOMBREPROCESO +
					Utilitario.Constantes.SIGNOIGUAL +
					Page.Request.QueryString[Utilitario.Enumerados.ColumnasProceso.NombreProceso.ToString()]
					);
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
		}

		public void CargarModoModificar()
		{
			int idProceso = Convert.ToInt32(Page.Request.QueryString[Utilitario.Enumerados.ColumnasProceso.IdProceso.ToString()]);
			int idSubProceso = Convert.ToInt32(Page.Request.QueryString[Utilitario.Enumerados.ColumnasSubProceso.IdSubProceso.ToString()]);
			lblTitulo.Text = TITULOMODOMODIFICAR;
						
			CMantenimientos	oCMantenimientos = new CMantenimientos();
			SubProcesoBE oSubProcesoBE = (SubProcesoBE)oCMantenimientos.ListarDetalle(idSubProceso,Enumerados.ClasesNTAD.SubProcesoNTAD.ToString());
		
			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"PlanGestion",this.ToString(),"Se consultó el Detalle del SubProceso del Plan de Gestión " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

			if(oSubProcesoBE!=null)
			{
				this.txtCodigoSubProceso.Text = oSubProcesoBE.CODIGOSUBPROCESO.ToString();
				this.txtNombreSubProceso.Text = oSubProcesoBE.DESCRIPCION.ToString();
				this.txtAvanceEconomica.Text = oSubProcesoBE.AVANCEECONOMICO.ToString();
				this.txtAvanceFinanciero.Text = oSubProcesoBE.AVANCEFINANCIERO.ToString();
				this.txtResponsable.Text = oSubProcesoBE.RESPONSABLE.ToString();
				this.txtLider.Text = oSubProcesoBE.LIDER.ToString();
				this.hidCargoLider.Value = oSubProcesoBE.IDCARGOLIDER.ToString();
				this.hIdAreaLider.Value = oSubProcesoBE.IDAREALIDER.ToString();
				this.hIdPersonalLider.Value = oSubProcesoBE.IDPERSONALLIDER.ToString();
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
			if(this.txtCodigoSubProceso.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJELISTAPROTOCOLARCAMPOREQUERIDOCLIENTEPERSONAL));
				return false;
			}

			if(this.txtNombreSubProceso.Text.Trim()==String.Empty)
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

		public void LlenarTitulos()
		{
			this.lblProceso.Text = Convert.ToString(Page.Request.QueryString[Utilitario.Enumerados.ColumnasProceso.CodigoProceso.ToString()]).ToUpper();
			this.lblNombreProceso.Text = Convert.ToString(Page.Request.QueryString[Utilitario.Enumerados.ColumnasProceso.NombreProceso.ToString()]).ToUpper();
		}

		private void ibtnCancelar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.redireccionaPaginaPrincipal();
		}

		private void redireccionaPaginaPrincipal()
		{
			Page.Response.Redirect(URLPRINCIPAL +
									Utilitario.Enumerados.ColumnasProceso.IdProceso.ToString() +
									Utilitario.Constantes.SIGNOIGUAL +
									Page.Request.QueryString[Utilitario.Enumerados.ColumnasProceso.IdProceso.ToString()] +
									Utilitario.Constantes.SIGNOAMPERSON +
									CODIGOPROCESO +
									Utilitario.Constantes.SIGNOIGUAL +
									Page.Request.QueryString[Utilitario.Enumerados.ColumnasProceso.CodigoProceso.ToString()] +
									Utilitario.Constantes.SIGNOAMPERSON +
									NOMBREPROCESO +
									Utilitario.Constantes.SIGNOIGUAL +
									Page.Request.QueryString[Utilitario.Enumerados.ColumnasProceso.NombreProceso.ToString()]
									);
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
