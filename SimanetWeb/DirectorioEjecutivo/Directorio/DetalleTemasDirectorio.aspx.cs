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
using SIMA.EntidadesNegocio.Secretaria.Directorio;
using NetAccessControl;



namespace SIMA.SimaNetWeb.DirectorioEjecutivo.Directorio
{
	/// <summary>
	/// Summary description for RequerimientosAsignados.
	/// </summary>
	public class DetalleTemasDirectorio: System.Web.UI.Page,IPaginaBase//,IPaginaMantenimento
	{
		#region Controles
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.DropDownList ddlbCentroOperativo;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox txtFuente;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvFuente;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox txtTema;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvTema;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.TextBox txtReferencia;
		protected System.Web.UI.WebControls.Label lblNroPedido;
		protected System.Web.UI.WebControls.TextBox txtNroAcuerdo;
		protected System.Web.UI.WebControls.Label lblFecha;
		protected eWorld.UI.CalendarPopup CalFechaAcuerdo;
		protected System.Web.UI.WebControls.Label lblSituacion;
		protected System.Web.UI.WebControls.DropDownList ddlbSituacion;
		protected System.Web.UI.WebControls.Label lblDetalle;
		protected System.Web.UI.WebControls.TextBox txtObservaciones;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary vSum;

		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion Controles

		#region Constantes
		
		//Titulos 
		const string TITULOMODONUEVO = "NUEVO TEMA DE DIRECTORIO";
		const string TITULOMODOMODIFICAR = "TEMA DE DIRECTORIO";

		//Key Session y QueryString
		const string KEYQID = "Id";
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.HtmlControls.HtmlInputFile filMyFile;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hDocumento;		
		
		//Paginas
		const string URLPRINCIPAL = "AdministracionTemasDirectorio.aspx";

		#endregion Constantes
		
		
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

		private void llenarSituacion()
		{
			CTablaTablas oCTablaTablas =  new CTablaTablas();
			ddlbSituacion.DataSource = oCTablaTablas.ListarTodosComboDirectorio(Convert.ToInt32(Enumerados.TablasTabla.SecretariaDirectorioTablaSituacionPedidos));
			ddlbSituacion.DataValueField=Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbSituacion.DataTextField=Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbSituacion.DataBind();
		}

		public void LlenarCombos()
		{
			this.llenarSituacion();
			this.llenarCentroOperativo();
		}

		private void llenarCentroOperativo()
		{
			CCentroOperativo oCCentroOperativo = new CCentroOperativo();
			ddlbCentroOperativo.DataSource = oCCentroOperativo.ListarTodosCombo();
			ddlbCentroOperativo.DataValueField=Enumerados.ColumnasCentroOperativo.IdCentroOperativo.ToString();
			ddlbCentroOperativo.DataTextField=Enumerados.ColumnasCentroOperativo.Sigla1.ToString();
			ddlbCentroOperativo.DataBind();
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
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
		{
		}

		public void LlenarDatos()
		{
			

			
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultaDeCartasFianzas.LlenarJScript implementation
			rfvFuente.ErrorMessage = Helper.MensajeAlert("Ingrese Fuente del Tema");
			rfvFuente.ToolTip = Helper.MensajeAlert("Ingrese Fuente del Tema");
		
			rfvTema.ErrorMessage = Helper.MensajeAlert("Ingrese Tema");
			rfvTema.ToolTip = Helper.MensajeAlert("Ingrese Tema");
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

			TemasDirectorioBE oTemasDirectorioBE = new TemasDirectorioBE();
			oTemasDirectorioBE.IdCentroOperativo = Convert.ToInt32(ddlbCentroOperativo.SelectedValue);
			oTemasDirectorioBE.Fuente = txtFuente.Text;
			oTemasDirectorioBE.Tema = txtTema.Text;
			oTemasDirectorioBE.Referencia = txtReferencia.Text;
			oTemasDirectorioBE.NroAcuerdo = txtNroAcuerdo.Text;			
			oTemasDirectorioBE.IdSesionDirectorio = Convert.ToInt32(Helper.RetornaSessionParaDirectorio());
			oTemasDirectorioBE.FechaAcuerdo = CalFechaAcuerdo.SelectedDate;
			oTemasDirectorioBE.IdTablaSituacion = Convert.ToInt32(Enumerados.TablasTabla.SecretariaDirectorioTablaSituacionTemas);
			oTemasDirectorioBE.IdSituacion = Convert.ToInt32(ddlbSituacion.SelectedValue);
			oTemasDirectorioBE.Observaciones = txtObservaciones.Text;			
			oTemasDirectorioBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.SecretariaDirectorioEstadosTemasDirectorio);
			oTemasDirectorioBE.IdEstado = Convert.ToInt32(Enumerados.EstadosTemaDirectorio.Activo);
			oTemasDirectorioBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();

			if(filMyFile.PostedFile.FileName!=String.Empty)
			{
				oTemasDirectorioBE.Documento = Helper.ObtenerNombreArchivo(filMyFile);
			}

			CMantenimientos oCMantenimientos = new CMantenimientos();

			int retorno = oCMantenimientos.Insertar(oTemasDirectorioBE);

			if(retorno>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Secretaria - Directorio",this.ToString(),"Se registró el Tema de Directorio Nro. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));

				Helper.GuardarDocumento((HttpPostedFile)filMyFile.PostedFile);

				ltlMensaje.Text = Helper.MensajeRetornoAlert("Tema de Directorio fue Registrado");
			}
		}

		public void Modificar()
		{
			TemasDirectorioBE oTemasDirectorioBE = new TemasDirectorioBE();
			oTemasDirectorioBE.IdTema = Convert.ToInt32(Page.Request.QueryString[KEYQID]);
			oTemasDirectorioBE.IdCentroOperativo = Convert.ToInt32(ddlbCentroOperativo.SelectedValue);
			oTemasDirectorioBE.Fuente = txtFuente.Text;
			oTemasDirectorioBE.Tema = txtTema.Text;
			oTemasDirectorioBE.Referencia = txtReferencia.Text;
			oTemasDirectorioBE.NroAcuerdo = txtNroAcuerdo.Text;			
			oTemasDirectorioBE.IdSesionDirectorio = Convert.ToInt32(Helper.RetornaSessionParaDirectorio());
			oTemasDirectorioBE.FechaAcuerdo = CalFechaAcuerdo.SelectedDate;
			oTemasDirectorioBE.Observaciones = txtObservaciones.Text;			
			oTemasDirectorioBE.IdTablaSituacion = Convert.ToInt32(Enumerados.TablasTabla.SecretariaDirectorioTablaSituacionTemas);
			oTemasDirectorioBE.IdSituacion = Convert.ToInt32(ddlbSituacion.SelectedValue);
			oTemasDirectorioBE.IdUsuarioActualizacion = CNetAccessControl.GetIdUser();
			
			if(filMyFile.Value!=String.Empty)
			{
				oTemasDirectorioBE.Documento = Helper.ObtenerNombreArchivo(filMyFile);
			}
			else
			{
				if(hDocumento.Value!=String.Empty)  
				{
					oTemasDirectorioBE.Documento = hDocumento.Value;
				}
			}

			CMantenimientos oCMantenimientos = new CMantenimientos();

			int retorno = oCMantenimientos.Modificar(oTemasDirectorioBE);

			if(retorno>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Secretaria - Directorio",this.ToString(),"Se modificó el Tema de Directorio Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

				Helper.GuardarDocumento((HttpPostedFile)filMyFile.PostedFile);

				ltlMensaje.Text = Helper.MensajeRetornoAlert("Se modificó Tema del Directorio");
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
		}

		public void CargarModoModificar()
		{
			lblTitulo.Text = TITULOMODOMODIFICAR;
			this.LlenarCombos();
						
			CMantenimientos	oCMantenimientos = new CMantenimientos();
			TemasDirectorioBE oTemasDirectorioBE = (TemasDirectorioBE)oCMantenimientos.ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYQID]),Enumerados.ClasesNTAD.TemasDirectorioNTAD.ToString());
			
			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Secretaria - Directorio",this.ToString(),"Se consultó el Detalle del Tema de Directorio Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

			if(oTemasDirectorioBE!=null)
			{
				ListItem lItem = ddlbSituacion.Items.FindByValue(oTemasDirectorioBE.IdSituacion.ToString());
				if(lItem!=null){lItem.Selected = true;}

				lItem = ddlbCentroOperativo.Items.FindByValue(oTemasDirectorioBE.IdCentroOperativo.ToString());			
				if(lItem!=null){lItem.Selected = true;}				

				txtFuente.Text = oTemasDirectorioBE.Fuente;
				txtTema.Text = oTemasDirectorioBE.Tema;
				txtReferencia.Text = oTemasDirectorioBE.Referencia;
				txtNroAcuerdo.Text = oTemasDirectorioBE.NroAcuerdo;
				CalFechaAcuerdo.SelectedDate = oTemasDirectorioBE.FechaAcuerdo;
				txtObservaciones.Text = oTemasDirectorioBE.Observaciones;

				if(!oTemasDirectorioBE.Documento.IsNull)
				{
					hDocumento.Value = oTemasDirectorioBE.Documento.ToString();
				}

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
			if(txtFuente.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text = Helper.MensajeAlert("Ingrese Fuente del Tema");
				return false;		
			}

			/*if(txtTema.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text = Helper.MensajeAlert("Ingrese Tema de Directorio");
				return false;
			}
			
			if(txtReferencia.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text = Helper.MensajeAlert("Ingrese Referencia del Tema");
				return false;		
			}*/

			if(txtNroAcuerdo.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text = Helper.MensajeAlert("Ingrese Nro de Acuerdo");
				return false;		
			}

			return true;
		}

		public bool ValidarExpresionesRegulares()
		{			
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
	}
}

