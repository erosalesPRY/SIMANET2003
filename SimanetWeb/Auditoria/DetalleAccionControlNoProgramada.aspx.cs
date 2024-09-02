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
using SIMA.Controladoras.Auditoria;
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
	public class DetalleAccionControlNoProgramada: System.Web.UI.Page,IPaginaBase//,IPaginaMantenimento
	{
		#region Controles

		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvDestino;
		protected eWorld.UI.NumericBox txtPorcentajeAvance2;
		
		#endregion Controles

		#region Constantes
		
		//Titulos 
		const string TITULOMODONUEVO = "NUEVO ACCION DE CONTROL NO PROGRAMADA";
		const string TITULOMODOMODIFICAR = "ACCION DE CONTROL NO PROGRAMADA";

		//Key Session y QueryString
		const string KEYQID = "Id";
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary DomValidationSummary1;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblMensaje;
		protected System.Web.UI.WebControls.Label lblCodigo;
		protected System.Web.UI.WebControls.TextBox txtCodigo;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvCodigo;
		protected System.Web.UI.WebControls.Label lblInformeEmitido;
		protected System.Web.UI.WebControls.TextBox txtSolicitante;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvSolicitante;
		protected System.Web.UI.WebControls.Label lblCentroOperativo;
		protected System.Web.UI.WebControls.DropDownList ddlbCentroOperativo;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvCentroOperativo;
		protected System.Web.UI.WebControls.Label lblArea;
		protected System.Web.UI.WebControls.TextBox txtArea;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvArea;
		protected System.Web.UI.WebControls.Label lblDescripcion;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvDescripcion;
		protected System.Web.UI.WebControls.Label lblObservacion;
		protected System.Web.UI.WebControls.TextBox txtObservacion;
		protected System.Web.UI.WebControls.Label lblPorcentajeAvance;
		protected eWorld.UI.NumericBox txtPorcentajeAvance;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvPorcentajeAvance;
		protected System.Web.UI.WebControls.Label lblFechaInicio;
		protected eWorld.UI.CalendarPopup CalFechaInicio;
		protected System.Web.UI.WebControls.Label lblFechaFin;
		protected eWorld.UI.CalendarPopup CalFechaFin;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.ImageButton ibtnCancelar;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary vSum;
		protected System.Web.UI.WebControls.Label lblDatos;
		
		
	
		//Paginas
		const string URLPRINCIPAL = "AdministracionDeAccionesDeControlNoProgramadas.aspx";
		
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
		
			
		}

		public void LlenarDatos()
		{
			

			
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultaDeCartasFianzas.LlenarJScript implementation

			rfvCodigo.ErrorMessage = Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONCONTROLNOPROGCAMPOREQUERIDOCODIGO);
			rfvCodigo.ToolTip = Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONCONTROLNOPROGCAMPOREQUERIDOCODIGO);
			
			rfvSolicitante.ErrorMessage = Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONCONTROLNOPROGCAMPOREQUERIDOSOLICITANTE);
			rfvSolicitante.ToolTip = Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONCONTROLNOPROGCAMPOREQUERIDOSOLICITANTE);

			rfvCentroOperativo.ErrorMessage = Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONCONTROLNOPROGCAMPOREQUERIDOCENTROOPERATIVO);
			rfvCentroOperativo.ToolTip = Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONCONTROLNOPROGCAMPOREQUERIDOCENTROOPERATIVO);

			rfvArea.ErrorMessage = Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONCONTROLNOPROGCAMPOREQUERIDOAREA);
			rfvArea.ToolTip = Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONCONTROLNOPROGCAMPOREQUERIDOAREA);

			rfvDescripcion.ErrorMessage =   Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONCONTROLNOPROGCAMPOREQUERIDOACCIONCORRECTIVA);
			rfvDescripcion.ToolTip =   Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONCONTROLNOPROGCAMPOREQUERIDOACCIONCORRECTIVA);

			rfvPorcentajeAvance.ErrorMessage =   Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONCONTROLNOPROGCAMPOREQUERIDOPORCENTAJEAVANCE);
			rfvPorcentajeAvance.ToolTip =  Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONCONTROLNOPROGCAMPOREQUERIDOPORCENTAJEAVANCE);
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
			AccionControlNoProgramadaBE oAccionControlNoProgramadaBE = new AccionControlNoProgramadaBE();
			oAccionControlNoProgramadaBE.Codigo = txtCodigo.Text;
			oAccionControlNoProgramadaBE.Descripcion = txtDescripcion.Text;
			oAccionControlNoProgramadaBE.Solicitante = txtSolicitante.Text;
			oAccionControlNoProgramadaBE.IdCentroOperativo = Convert.ToInt32(ddlbCentroOperativo.SelectedValue);
			oAccionControlNoProgramadaBE.Area = txtArea.Text;
			
			if(txtObservacion.Text.Trim()!=String.Empty)
			{
				oAccionControlNoProgramadaBE.Observacion = txtObservacion.Text;	
			}

			oAccionControlNoProgramadaBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.AuditoriaEstadoAccionControlNoProgramada);
			oAccionControlNoProgramadaBE.IdEstado = Convert.ToInt32(Enumerados.EstadosAccionControlNoProgramada.Pendiente);
			oAccionControlNoProgramadaBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();
			oAccionControlNoProgramadaBE.FechaInicio = CalFechaInicio.SelectedDate;
			oAccionControlNoProgramadaBE.PorcentajeAvance = Convert.ToDouble(txtPorcentajeAvance.Text);
			

			CMantenimientos oCMantenimientos = new CMantenimientos();

			int retorno = oCMantenimientos.Insertar(oAccionControlNoProgramadaBE);

			if(retorno>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Auditoria",this.ToString(),"Se registró la Acción de Control No Programada Nro. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));

				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONREGISTROACCIONCONTROLNOPROG),URLPRINCIPAL);
			
			}
		}

		public void Modificar()
		{

			AccionControlNoProgramadaBE oAccionControlNoProgramadaBE = new AccionControlNoProgramadaBE();
			oAccionControlNoProgramadaBE.IdAccionControlNoProgramada = Convert.ToInt32(Page.Request.QueryString[KEYQID]);
			oAccionControlNoProgramadaBE.Codigo = txtCodigo.Text;
			oAccionControlNoProgramadaBE.Descripcion = txtDescripcion.Text;
			oAccionControlNoProgramadaBE.Solicitante = txtSolicitante.Text;
			oAccionControlNoProgramadaBE.IdCentroOperativo = Convert.ToInt32(ddlbCentroOperativo.SelectedValue);
			oAccionControlNoProgramadaBE.Area = txtArea.Text;
			
			if(txtObservacion.Text.Trim()!=String.Empty)
			{
				oAccionControlNoProgramadaBE.Observacion = txtObservacion.Text;	
			}
			
			oAccionControlNoProgramadaBE.IdUsuarioActualizacion = CNetAccessControl.GetIdUser();
			oAccionControlNoProgramadaBE.FechaInicio = CalFechaInicio.SelectedDate;
			oAccionControlNoProgramadaBE.PorcentajeAvance = Convert.ToDouble(txtPorcentajeAvance.Text);
			oAccionControlNoProgramadaBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.AuditoriaEstadoAccionControlNoProgramada);
			
			
			if(oAccionControlNoProgramadaBE.PorcentajeAvance == 100)
			{
				oAccionControlNoProgramadaBE.IdEstado = Convert.ToInt32(Enumerados.EstadosAccionControlNoProgramada.Ejecutada);
				oAccionControlNoProgramadaBE.FechaFin = CalFechaFin.SelectedDate;
			}
			else if(oAccionControlNoProgramadaBE.PorcentajeAvance == 0)
			{
				oAccionControlNoProgramadaBE.IdEstado = Convert.ToInt32(Enumerados.EstadosAccionControlNoProgramada.Pendiente);
			}
			else if(oAccionControlNoProgramadaBE.PorcentajeAvance > 0)
			{
				oAccionControlNoProgramadaBE.IdEstado = Convert.ToInt32(Enumerados.EstadosAccionControlNoProgramada.Proceso);
			}

			CMantenimientos oCMantenimientos = new CMantenimientos();
			if(oCMantenimientos.Modificar(oAccionControlNoProgramadaBE)>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Auditoria",this.ToString(),"Se modificó la Acción de Control No Programada Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));
				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONMODIFICACIONACCIONCONTROLNOPROG),URLPRINCIPAL);
			
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
			AccionControlNoProgramadaBE oAccionControlNoProgramadaBE = (AccionControlNoProgramadaBE)oCMantenimientos.ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYQID]),Enumerados.ClasesNTAD.AccionControlNoProgramadaNTAD.ToString());
			
			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Auditoria",this.ToString(),"Se consultó el Detalle de la Acción de Control No Programada Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

			if(oAccionControlNoProgramadaBE!=null)
			{
				txtCodigo.Text = oAccionControlNoProgramadaBE.Codigo;
				txtDescripcion.Text = oAccionControlNoProgramadaBE.Descripcion;
				txtSolicitante.Text = oAccionControlNoProgramadaBE.Solicitante;

				if(!oAccionControlNoProgramadaBE.Observacion.IsNull)
				{
					txtObservacion.Text = oAccionControlNoProgramadaBE.Observacion.Value;
				}
				
				CalFechaInicio.VisibleDate= oAccionControlNoProgramadaBE.FechaInicio;
				CalFechaInicio.SelectedDate= oAccionControlNoProgramadaBE.FechaInicio;

				if(!oAccionControlNoProgramadaBE.FechaFin.IsNull)
				{
					CalFechaFin.SelectedDate = oAccionControlNoProgramadaBE.FechaFin.Value;
					lblFechaFin.Visible = true;
					CalFechaFin.Visible = true;
				}

				if(!oAccionControlNoProgramadaBE.PorcentajeAvance.IsNull)
				{
					txtPorcentajeAvance.Text = oAccionControlNoProgramadaBE.PorcentajeAvance.ToString();
				}
				if(oAccionControlNoProgramadaBE.PorcentajeAvance < 100)
				{
					ibtnAceptar.Visible = true;
				}
				else
				{
					ibtnAceptar.Visible = false;
				}

				txtArea.Text = oAccionControlNoProgramadaBE.Area;
				ddlbCentroOperativo.Items.FindByValue(oAccionControlNoProgramadaBE.IdCentroOperativo.ToString()).Selected = true;
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
			if(txtCodigo.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONCONTROLNOPROGCAMPOREQUERIDOCODIGO));
				return false;		
			}
			
			if(txtSolicitante.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONCONTROLNOPROGCAMPOREQUERIDOSOLICITANTE));
				return false;		
			}

			if(ddlbCentroOperativo.SelectedItem.Text == Constantes.TEXTOSSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONCONTROLNOPROGCAMPOREQUERIDOCENTROOPERATIVO));
				
				return false;		
			}

			if(txtArea.Text == String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONCONTROLNOPROGCAMPOREQUERIDOAREA));
				return false;		
			}

			
			if(txtDescripcion.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONCONTROLNOPROGCAMPOREQUERIDOACCIONCORRECTIVA));
				
				return false;		
			}
			if(txtPorcentajeAvance.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONCONTROLNOPROGCAMPOREQUERIDOPORCENTAJEAVANCE));
				return false;		
			}
			return true;
		}

		public bool ValidarExpresionesRegulares()
		{
			if(!ExpresionesRegulares.ValidarExpresionRegularNumericosPositivos(Server.HtmlEncode(txtPorcentajeAvance.Text)))
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJEACCIONCONTROLNOPROGDATOSINCORRECTOSNUMEROSPORCENTAJEAVANCE));
				return false;
			}
			
			
			return true;
		}

		#endregion

	

		/// <summary>
		/// Abre la pagina de Administracion De PlanAnual DeControl
		/// </summary>
		private void redireccionaPaginaPrincipal()
		{
			Page.Response.Redirect(URLPRINCIPAL);
		}

		private void ddlbArea_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void ibtnCancelar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.redireccionaPaginaPrincipal();
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

