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
using SIMA.EntidadesNegocio.General;
using eWorld.UI;


namespace SIMA.SimaNetWeb.DirectorioEjecutivo.GestionEstrategica
{
	/// <summary>
	/// Summary description for DetallePlanEstrategicoObjetivosGenerales.
	/// </summary>
	public class DetallePlanEstrategicoObjetivosGenerales : System.Web.UI.Page, IPaginaBase, IPaginaMantenimento
	{
		#region Controles
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvDescripcion;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvTipoObjetivo;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnCancelar;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary vSum;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdCodigo;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblProyecto;
		protected System.Web.UI.WebControls.Label lblTipoObjetivo;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.DropDownList ddlbTipoObjetivo;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.HtmlControls.HtmlTableCell cellddlbTipoObjetivo;
		protected System.Web.UI.HtmlControls.HtmlTableCell TdCeldaCancelar;
		#endregion

		#region Constantes
		//Titulos 

			const string KEYIDVERSION="KEYIDVERSION";


		const string TITULOMODONUEVO = "NUEVO OBJETIVO GENERAL";
		const string TITULOMODOMODIFICAR = "MODIFICAR OBJETIVO GENERAL";
		const string TITULOMODOCONSULTAR = "CONSULTAR OBJETIVO GENERAL";

		//Key Session y QueryString
		const string KEYQIDOGENERAL = "IDOGENERALES";
		const string KEYOGENERALTEXTO = "DESCRIPCION";

		//Paginas
		const string URLPRINCIPAL = "AdministrarPlanEstrategicoObjetivosGenerales.aspx";
		const string JSUBIRHISTORIAL="HistorialIrAtras();";
		#endregion
		
		#region Variables
		ListItem  lItem ;
		#endregion
	
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add DetallePlanEstrategicoObjetivosGenerales.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetallePlanEstrategicoObjetivosGenerales.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetallePlanEstrategicoObjetivosGenerales.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			lItem = new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,Utilitario.Constantes.VALORSELECCIONAR);
			this.llenarTipoObjetivosGenerales();
			this.ddlbTipoObjetivo.Items.Insert(0,lItem);
		}

		public void LlenarDatos()
		{
			// TODO:  Add DetallePlanEstrategicoObjetivosGenerales.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			this.ibtnCancelar.Attributes.Add(Utilitario.Constantes.EVENTOONMOUSEOVER,"CambiarColorPasarMouse(this, true);");			
			this.rfvDescripcion.ErrorMessage = Helper.ObtenerMensajesConfirmacionEstrategico(Mensajes.CODIGOMENSAJEOBJETIVOGENERALCAMPOREQUERIDODESCRIPCION);
			this.rfvDescripcion.ToolTip = Helper.ObtenerMensajesConfirmacionEstrategico(Mensajes.CODIGOMENSAJEOBJETIVOGENERALCAMPOREQUERIDODESCRIPCION);

			this.rfvTipoObjetivo.ErrorMessage = Helper.ObtenerMensajesConfirmacionEstrategico(Mensajes.CODIGOMENSAJEOBJETIVOGENERALCAMPOREQUERIDOTPOOBJETIVO);
			this.rfvTipoObjetivo.ToolTip = Helper.ObtenerMensajesConfirmacionEstrategico(Mensajes.CODIGOMENSAJEOBJETIVOGENERALCAMPOREQUERIDOTPOOBJETIVO);
			this.rfvTipoObjetivo.InitialValue = Utilitario.Constantes.VALORSELECCIONAR;
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetallePlanEstrategicoObjetivosGenerales.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetallePlanEstrategicoObjetivosGenerales.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetallePlanEstrategicoObjetivosGenerales.Exportar implementation
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
			// TODO:  Add DetallePlanEstrategicoObjetivosGenerales.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			ObjetivosGeneralesBE oObjetivosGeneralesBE = new ObjetivosGeneralesBE();

			oObjetivosGeneralesBE.Descripcion = this.txtDescripcion.Text.ToUpper();
			oObjetivosGeneralesBE.IdTablaTipoObjetivoGeneral = Convert.ToInt32(Enumerados.TablasTabla.TablaTipoObjetivoGeneral);
			oObjetivosGeneralesBE.IdTipoObjetivoGeneral = Convert.ToInt32(this.ddlbTipoObjetivo.SelectedValue);
			oObjetivosGeneralesBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.EstadosObjetivoGeneral);
			oObjetivosGeneralesBE.IdEstado = Convert.ToInt32(Enumerados.EstadosObjetivoGeneral.Activo);
			oObjetivosGeneralesBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();
			

			oObjetivosGeneralesBE.IdVersion = Convert.ToInt32(Page.Request.QueryString[KEYIDVERSION]);

			
			CMantenimientos oCMantenimientos = new CMantenimientos();

			int retorno = oCMantenimientos.Insertar(oObjetivosGeneralesBE);

			if(retorno>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Estrategica",this.ToString(),"Se registró el Objetivo General. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));
				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionEstrategica.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONREGISTROOBJETIVOGENERAL)) + JSUBIRHISTORIAL;
			}
		}

		public void Modificar()
		{
			ObjetivosGeneralesBE oObjetivosGeneralesBE = new ObjetivosGeneralesBE();
			oObjetivosGeneralesBE.IdOGenerales = Convert.ToInt32(Page.Request.QueryString[KEYQIDOGENERAL]);
			oObjetivosGeneralesBE.Descripcion = this.txtDescripcion.Text.ToUpper();
			oObjetivosGeneralesBE.IdTipoObjetivoGeneral = Convert.ToInt32(this.ddlbTipoObjetivo.SelectedValue);
			oObjetivosGeneralesBE.IdUsuarioActualizacion = CNetAccessControl.GetIdUser();

			oObjetivosGeneralesBE.IdVersion = Convert.ToInt32(Page.Request.QueryString[KEYIDVERSION]);

			CMantenimientos oCMantenimientos = new CMantenimientos();

			int retorno = oCMantenimientos.Modificar(oObjetivosGeneralesBE);

			if(retorno>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Estrategica",this.ToString(),"Se modifico el Objetivo General. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));
				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionEstrategica.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONMODIFICOOBJETIVOGENERAL)) + JSUBIRHISTORIAL;
			}
		}

		public void Eliminar()
		{
			
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
			this.TdCeldaCancelar.Visible = false;
			this.lblTitulo.Text = TITULOMODONUEVO;
			this.LlenarCombos();
		}

		public void CargarModoModificar()
		{
			this.TdCeldaCancelar.Visible = false;
			lblTitulo.Text = TITULOMODOMODIFICAR;
			this.LlenarCombos();

			CMantenimientos	oCMantenimientos = new CMantenimientos();
			ObjetivosGeneralesBE oObjetivosGeneralesBE = (ObjetivosGeneralesBE)oCMantenimientos.ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYQIDOGENERAL]),Enumerados.ClasesNTAD.ObjetivoGeneralNTAD.ToString());

			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Estrategica",this.ToString(),"Se consultó el Detalle del Objetivo General Nro. " + Page.Request.QueryString[KEYQIDOGENERAL] + ".",Enumerados.NivelesErrorLog.I.ToString()));

			if(oObjetivosGeneralesBE != null)
			{
				this.hIdCodigo.Value = oObjetivosGeneralesBE.IdOGenerales.ToString();
				this.txtDescripcion.Text = oObjetivosGeneralesBE.Descripcion.ToString();
				this.ddlbTipoObjetivo.Items.FindByValue(oObjetivosGeneralesBE.IdTipoObjetivoGeneral.ToString()).Selected = true;
			}
	
		}

		public void CargarModoConsulta()
		{
			this.ibtnCancelar.Visible = false;
			lblTitulo.Text = TITULOMODOCONSULTAR;
			this.LlenarCombos();

			CMantenimientos	oCMantenimientos = new CMantenimientos();
			ObjetivosGeneralesBE oObjetivosGeneralesBE = (ObjetivosGeneralesBE)oCMantenimientos.ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYQIDOGENERAL]),Enumerados.ClasesNTAD.ObjetivoGeneralNTAD.ToString());

			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Estartegia",this.ToString(),"Se consultó el Detalle del Objetivo General Nro. " + Page.Request.QueryString[KEYQIDOGENERAL] + ".",Enumerados.NivelesErrorLog.I.ToString()));

			if(oObjetivosGeneralesBE != null)
			{
				this.txtDescripcion.Text = oObjetivosGeneralesBE.Descripcion.ToString();
				this.ddlbTipoObjetivo.Items.FindByValue(oObjetivosGeneralesBE.IdTipoObjetivoGeneral.ToString()).Selected = true;
			}
			Helper.BloquearControles(this);
		}

		public bool ValidarCampos()
		{
			if(this.ValidarCamposRequeridos())
			{
				if(this.ValidarExpresionesRegulares())
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			else
			{
				return false;
			}
		}

		public bool ValidarCamposRequeridos()
		{
			if(this.txtDescripcion.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionEstrategico(Mensajes.CODIGOMENSAJEOBJETIVOGENERALCAMPOREQUERIDODESCRIPCION));
				return false;
			}
			if(this.ddlbTipoObjetivo.SelectedItem.Text == Utilitario.Constantes.TEXTOSSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionEstrategico(Mensajes.CODIGOMENSAJEOBJETIVOGENERALCAMPOREQUERIDOTPOOBJETIVO));
				return false;
			}
			return true;
		}

		public bool ValidarExpresionesRegulares()
		{
			return true;
		}

		#endregion


		private void llenarTipoObjetivosGenerales()
		{
			CTablaTablas oCTablaTablas =  new CTablaTablas();
			ddlbTipoObjetivo.DataSource = oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Enumerados.TablasTabla.TablaTipoObjetivoGeneral));
			ddlbTipoObjetivo.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbTipoObjetivo.DataTextField = Enumerados.ColumnasTablaTablas.Var1.ToString();
			ddlbTipoObjetivo.DataBind();
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
	}
}
