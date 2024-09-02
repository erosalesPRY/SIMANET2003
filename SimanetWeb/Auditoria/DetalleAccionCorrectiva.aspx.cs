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
using SIMA.EntidadesNegocio.Auditoria;
using NetAccessControl;



namespace SIMA.SimaNetWeb.Auditoria
{
	/// <summary>
	/// Summary description for RequerimientosAsignados.
	/// </summary>
	public class DetalleAccionCorrectiva: System.Web.UI.Page,IPaginaBase//,IPaginaMantenimento
	{
		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblTexto;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblDatos;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvDestino;
		protected System.Web.UI.WebControls.Label lblMensaje;
		protected System.Web.UI.WebControls.TextBox txtInformeEmitido;
		protected System.Web.UI.WebControls.Label lblInformeEmitido;
		protected System.Web.UI.WebControls.DropDownList ddlbArea;
		protected System.Web.UI.WebControls.Label lblArea;
		protected System.Web.UI.WebControls.DropDownList ddlbCentroOperativo;
		protected eWorld.UI.NumericBox txtPorcentajeAvance;
		protected System.Web.UI.WebControls.Label lblPorcentajeAvance;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.Label lblDescripcion;
		protected System.Web.UI.WebControls.TextBox txtObservacion;
		protected System.Web.UI.WebControls.Label lblObservacion;
		protected System.Web.UI.WebControls.ImageButton ibtnCancelar;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.Label lblCentroOperativo;
		protected System.Web.UI.WebControls.Label lblFechaFin;
		protected eWorld.UI.CalendarPopup CalFechaFin;
		protected eWorld.UI.CalendarPopup CalFechaInicio;

		#endregion Controles

		#region Constantes
		
		//Titulos 
		const string TITULOMODONUEVO = "NUEVA ACCION CORRECTIVA";
		const string TITULOMODOMODIFICAR = "ACCION CORRECTIVA";

		//Key Session y QueryString
		const string KEYQID = "Id";
		protected eWorld.UI.NumericBox txtPorcentajeAvance2;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary vSum;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvDescripcion;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvArea;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvCentroOperativo;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvInformeEmitido;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvPorcentajeAvance;
		protected System.Web.UI.WebControls.Label lblFechaInicio;
		
	
		//Paginas
		const string URLPRINCIPAL = "AdministracionDeAccionesCorrectivas.aspx";
		
		#endregion Constantes
		
		
		
		
		/// <summary>
		/// Llena el combo de Centros Operativos
		/// </summary>
		private void llenarCentrosOperativo()
		{
			CCentroOperativo oCCentroOperativo =  new CCentroOperativo();
			ddlbCentroOperativo.DataSource = oCCentroOperativo.ListarTodosCombo();
			ddlbCentroOperativo.DataValueField=Enumerados.ColumnasCentroOperativo.IdCentroOperativo.ToString();
			ddlbCentroOperativo.DataTextField=Enumerados.ColumnasCentroOperativo.Sigla2.ToString();
			ddlbCentroOperativo.DataBind();
			ddlbCentroOperativo.Items.Insert(0,lItem);
		}

		
		/// <summary>
		/// Llena el combo de Areas
		/// </summary>
		private void llenarAreas()
		{
			CArea oCArea =  new CArea();
			ddlbArea.DataSource = oCArea.ListarTodosCombo();
			ddlbArea.DataValueField=Enumerados.ColumnasArea.IdArea.ToString();
			ddlbArea.DataTextField=Enumerados.ColumnasArea.Nombre.ToString();
			ddlbArea.DataBind();
			ddlbArea.Items.Insert(0,lItem);
		}

		ListItem lItem;

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
			this.ddlbArea.SelectedIndexChanged += new System.EventHandler(this.ddlbArea_SelectedIndexChanged);
			this.ibtnAceptar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAceptar_Click);
			this.ibtnCancelar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnCancelar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
		{
		}

		public void LlenarCombos()
		{
			lItem = new ListItem(Constantes.TEXTOSSELECCIONAR,Constantes.VALORSELECCIONAR);

			this.llenarCentrosOperativo();
			this.llenarAreas();
			
		}

		public void LlenarDatos()
		{
			

			
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultaDeCartasFianzas.LlenarJScript implementation
			rfvInformeEmitido.ErrorMessage = Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONCORRECTIVACAMPOREQUERIDOINFORMEMITIDO);
			rfvInformeEmitido.ToolTip = Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONCORRECTIVACAMPOREQUERIDOINFORMEMITIDO);

			rfvCentroOperativo.ErrorMessage = Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONCORRECTIVACAMPOREQUERIDOCENTROOPERATIVO);
			rfvCentroOperativo.ToolTip = Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONCORRECTIVACAMPOREQUERIDOCENTROOPERATIVO);

			rfvArea.ErrorMessage = Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONCORRECTIVACAMPOREQUERIDOAREA);
			rfvArea.ToolTip = Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONCORRECTIVACAMPOREQUERIDOAREA);

			rfvDescripcion.ErrorMessage = Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONCORRECTIVACAMPOREQUERIDODESCRIPCION);
			rfvDescripcion.ToolTip = Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONCORRECTIVACAMPOREQUERIDODESCRIPCION);
			
			rfvPorcentajeAvance.ErrorMessage = Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONCORRECTIVACAMPOREQUERIDOPORCENTAJEAVANCE);
			rfvPorcentajeAvance.ToolTip = Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONCORRECTIVACAMPOREQUERIDOPORCENTAJEAVANCE);

			


		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultaDeCartasFianzas.RegistrandoJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultaDeCartasFianzas.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultaDeCartasFianzas.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add ConsultaDeCartasFianzas.ConfigurarAccesoControles implementation

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
			return true;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			AccionCorrectivaBE oAccionCorrectivaBE = new AccionCorrectivaBE();
			oAccionCorrectivaBE.Descripcion = txtDescripcion.Text;
			oAccionCorrectivaBE.InformeEmitido = txtInformeEmitido.Text;
			oAccionCorrectivaBE.IdCentroOperativo = Convert.ToInt32(ddlbCentroOperativo.SelectedValue);
			oAccionCorrectivaBE.IdArea = Convert.ToInt32(ddlbArea.SelectedValue);
			
			if(txtObservacion.Text.Trim()!=String.Empty)
			{
				oAccionCorrectivaBE.Observacion = txtObservacion.Text;	
			}

			oAccionCorrectivaBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.AuditoriaEstadoAccionCorrectiva);
			oAccionCorrectivaBE.IdEstado = Convert.ToInt32(Enumerados.EstadosAccionCorrectiva.Pendiente);
			oAccionCorrectivaBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();
			oAccionCorrectivaBE.FechaInicio = CalFechaInicio.SelectedDate;
			oAccionCorrectivaBE.PorcentajeAvance = Convert.ToDouble(txtPorcentajeAvance.Text);
			

			CMantenimientos oCMantenimientos = new CMantenimientos();

			int retorno = oCMantenimientos.Insertar(oAccionCorrectivaBE);

			if(retorno>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Auditoria",this.ToString(),"Se registró la Acción Correctiva Nro. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));

				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONREGISTROACCIONCORRECTIVA),URLPRINCIPAL);
			
			}
		}

		public void Modificar()
		{

			AccionCorrectivaBE oAccionCorrectivaBE = new AccionCorrectivaBE();
			oAccionCorrectivaBE.IdAccionCorrectiva = Convert.ToInt32(Page.Request.QueryString[KEYQID]);
			oAccionCorrectivaBE.Descripcion = txtDescripcion.Text;
			oAccionCorrectivaBE.InformeEmitido = txtInformeEmitido.Text;
			oAccionCorrectivaBE.IdCentroOperativo = Convert.ToInt32(ddlbCentroOperativo.SelectedValue);
			oAccionCorrectivaBE.IdArea = Convert.ToInt32(ddlbArea.SelectedValue);
			
			if(txtObservacion.Text.Trim()!=String.Empty)
			{
				oAccionCorrectivaBE.Observacion = txtObservacion.Text;	
			}
			
			oAccionCorrectivaBE.IdUsuarioActualizacion = CNetAccessControl.GetIdUser();
			oAccionCorrectivaBE.FechaInicio = CalFechaInicio.SelectedDate;
			oAccionCorrectivaBE.PorcentajeAvance = Convert.ToDouble(txtPorcentajeAvance.Text);
			oAccionCorrectivaBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.AuditoriaEstadoAccionCorrectiva);
			
			
			if(oAccionCorrectivaBE.PorcentajeAvance == 100)
			{
				oAccionCorrectivaBE.IdEstado = Convert.ToInt32(Enumerados.EstadosAccionCorrectiva.Ejecutada);
				oAccionCorrectivaBE.FechaFin = CalFechaFin.SelectedDate;
			}
			else if(oAccionCorrectivaBE.PorcentajeAvance == 0)
			{
				oAccionCorrectivaBE.IdEstado = Convert.ToInt32(Enumerados.EstadosAccionCorrectiva.Pendiente);
			}
			else if(oAccionCorrectivaBE.PorcentajeAvance > 0)
			{
				oAccionCorrectivaBE.IdEstado = Convert.ToInt32(Enumerados.EstadosAccionCorrectiva.Proceso);
			}

			CMantenimientos oCMantenimientos = new CMantenimientos();
			if(oCMantenimientos.Modificar(oAccionCorrectivaBE)>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Auditoria",this.ToString(),"Se modificó la Acción Correctiva Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONMODIFICACIONACCIONCORRECTIVA),URLPRINCIPAL);
			
			}
		}

		public void Eliminar()
		{
			// TODO:  Add DetalleCuentasBancaria.Eliminar implementation
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
			txtPorcentajeAvance.Text = "0";
			txtPorcentajeAvance.Enabled = false;
		}

		public void CargarModoModificar()
		{
			lblTitulo.Text = TITULOMODOMODIFICAR;
			this.LlenarCombos();
			
			CMantenimientos	oCMantenimientos = new CMantenimientos();
			AccionCorrectivaBE oAccionCorrectivaBE = (AccionCorrectivaBE)oCMantenimientos.ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYQID]),Enumerados.ClasesNTAD.AccionCorrectivaNTAD.ToString());
			
			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Auditoria",this.ToString(),"Se consultó el Detalle de la Acción Correctiva Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

			if(oAccionCorrectivaBE!=null)
			{
				txtDescripcion.Text = oAccionCorrectivaBE.Descripcion;
				txtInformeEmitido.Text = oAccionCorrectivaBE.InformeEmitido;

				if(!oAccionCorrectivaBE.Observacion.IsNull)
				{
					txtObservacion.Text = oAccionCorrectivaBE.Observacion.Value;
				}
				
				CalFechaInicio.VisibleDate= oAccionCorrectivaBE.FechaInicio;
				CalFechaInicio.SelectedDate= oAccionCorrectivaBE.FechaInicio;

				if(!oAccionCorrectivaBE.FechaFin.IsNull)
				{
					CalFechaFin.SelectedDate = oAccionCorrectivaBE.FechaFin.Value;
					lblFechaFin.Visible = true;
					CalFechaFin.Visible = true;
				}

				txtPorcentajeAvance.Text = oAccionCorrectivaBE.PorcentajeAvance.ToString();
			
				if(oAccionCorrectivaBE.PorcentajeAvance < 100)
				{
					ibtnAceptar.Visible = true;
				}
				else
				{
					ibtnAceptar.Visible = false;
				}

				ddlbArea.Items.FindByValue(oAccionCorrectivaBE.IdArea.ToString()).Selected = true;
				ddlbCentroOperativo.Items.FindByValue(oAccionCorrectivaBE.IdCentroOperativo.ToString()).Selected = true;
			}
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add DetalleCuentasBancaria.CargarModoConsulta implementation
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
			if(txtInformeEmitido.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONCORRECTIVACAMPOREQUERIDOINFORMEMITIDO));
				
				return false;		
			}

			if(ddlbCentroOperativo.SelectedItem.Text == Constantes.TEXTOSSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONCORRECTIVACAMPOREQUERIDOCENTROOPERATIVO));
				return false;		
			}

			if(ddlbArea.SelectedItem.Text == Constantes.TEXTOSSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONCORRECTIVACAMPOREQUERIDOAREA));
				return false;		
			}

			
			if(txtDescripcion.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONCORRECTIVACAMPOREQUERIDODESCRIPCION));
				return false;		
			}
			if(txtPorcentajeAvance.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONCORRECTIVACAMPOREQUERIDOPORCENTAJEAVANCE));
				return false;		
			}
			return true;
		}

		public bool ValidarExpresionesRegulares()
		{
			if(!ExpresionesRegulares.ValidarExpresionRegularNumericosPositivos(Server.HtmlEncode(txtPorcentajeAvance.Text)))
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONCORRECTIVADATOSINCORRECTOSNUMEROSPORCENTAJEAVANCE));
				return false;
			}
			
			
			return true;
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

		/// <summary>
		/// Abre la pagina de Administracion De PlanAnual DeControl
		/// </summary>
		private void redireccionaPaginaPrincipal()
		{
			Page.Response.Redirect(URLPRINCIPAL);
		}


		private void ibtnCancelar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.redireccionaPaginaPrincipal();
		}

		private void ddlbArea_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		
	}
}

