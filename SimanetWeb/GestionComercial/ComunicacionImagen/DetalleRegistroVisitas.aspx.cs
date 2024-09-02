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
using SIMA.Controladoras;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using SIMA.Controladoras.GestionComercial;
using SIMA.Controladoras.General;
using SIMA.EntidadesNegocio.GestionComercial;

namespace SIMA.SimaNetWeb.GestionComercial.ComunicacionImagen
{
	/// <summary>
	/// Summary description for DetalleRegistroVisitas.
	/// </summary>
	public class DetalleRegistroVisitas: System.Web.UI.Page, IPaginaMantenimento, IPaginaBase
	{
		#region Controles

		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblNombreEntidad;
		protected System.Web.UI.WebControls.TextBox txtEntidad;
		protected System.Web.UI.WebControls.ImageButton ibtnBuscarEntidad;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvNombreEntidad;
		protected System.Web.UI.WebControls.Label lblFechaVisita;
		protected eWorld.UI.CalendarPopup calFechaVisita;
		protected System.Web.UI.WebControls.Label lblHoraEntrada;
		protected eWorld.UI.TimePicker tpHoraEntrada;
		protected System.Web.UI.WebControls.Label Label1;
		protected eWorld.UI.TimePicker tpHoraSalida;
		protected System.Web.UI.WebControls.Label lblSeEntregoRegalo;
		protected System.Web.UI.WebControls.CheckBox chkSeEntregoRegalo;
		protected System.Web.UI.WebControls.Label lblDescripcion;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.Label lblObservaciones;
		protected System.Web.UI.WebControls.TextBox txtObservaciones;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.CheckBox chkTieneResponsables;
		protected System.Web.UI.WebControls.RadioButtonList rblTipoResponsable;
		protected System.Web.UI.WebControls.Label lblNombreResponsable;
		protected System.Web.UI.WebControls.TextBox txtPersonal;
		protected System.Web.UI.WebControls.ImageButton ibtnBuscarPersonal;
		protected System.Web.UI.WebControls.Label lblCargoResponsable;
		protected System.Web.UI.WebControls.DropDownList ddlbCargoResponsable;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvCargoResponsable;
		protected System.Web.UI.WebControls.Label lblDescripcionResponsable;
		protected System.Web.UI.WebControls.TextBox txtDescripcionResponsable;
		protected System.Web.UI.WebControls.Label lblObservacionesResponsable;
		protected System.Web.UI.WebControls.TextBox txtObservacionesResponsable;
		protected System.Web.UI.WebControls.ImageButton ibtnAgregar;
		protected System.Web.UI.WebControls.ImageButton ibtnModificar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminar;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary vSum;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdCodigo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdOrigen;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdTablaOrigen;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdPersonal;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdResponsableVisita;
		protected System.Web.UI.HtmlControls.HtmlTableCell TdCeldaCancelar;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnCancelar;
		protected System.Web.UI.WebControls.Literal ltlMensaje;

		#endregion Controles
		
		#region Constantes
		
		//Titulos 
		const string TITULOMODONUEVO = "NUEVO REGISTRO DE VISITAS";
		const string TITULOMODOMODIFICAR = "ACTUALIZACION DE REGISTRO DE VISITAS";
		const string TITULOMODOCONSULTA = "DETALLE DE REGISTRO DE VISITAS";

		//Key Session y QueryString
		const string KEYQID = "Id";
		const string KEYQDATATABLE = "DataTable";
		const string KEYQCONTADOR = "Contador";
		const string KEYQCODIGOINICIAL = "CodigoInicial";
		const string KEYQREGISTROSELIMINADOS = "RegistrosEliminados";
		const string KEYQCONTADORREGISTROSELIMINADOS = "ContadorRegistrosEliminados";
	
		//Paginas
		const string URLBUSQUEDAENTIDAD = "../../Legal/BusquedaEntidad.aspx?";
		const string URLBUSQUEDAPERSONAL = "../../Legal/BusquedaPersonal.aspx";

		//Otros
		const string NombreDataTable = "TablaResponsables";
		string JSVERIFICARELIMINAR = "return verificarEliminarRb('hCodigo','" + Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO)+"','"+Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJEPREGUNTAELIMINACIONREGISTRO)+"');";
		
		#endregion Constantes				
		
		#region Variables
		ListItem  lItem;
		#endregion Variables
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();

					this.CrearDataTable();
					
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
			this.chkTieneResponsables.CheckedChanged += new System.EventHandler(this.chkTieneResponsables_CheckedChanged);
			this.rblTipoResponsable.SelectedIndexChanged += new System.EventHandler(this.rblTipoResponsable_SelectedIndexChanged);
			this.ibtnAgregar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAgregar_Click);
			this.ibtnModificar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnModificar_Click);
			this.ibtnEliminar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminar_Click);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.ibtnAceptar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAceptar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			RegistroVisitasBE oRegistroVisitasBE = new RegistroVisitasBE();
			oRegistroVisitasBE.IdTablaOrigen = Convert.ToInt32(this.hIdTablaOrigen.Value);
			oRegistroVisitasBE.IdOrigen = Convert.ToInt32(this.hIdOrigen.Value);
			oRegistroVisitasBE.IdCodigo = Convert.ToInt32(this.hIdCodigo.Value);
			oRegistroVisitasBE.FechaVisita = this.calFechaVisita.SelectedDate;
			oRegistroVisitasBE.HoraEntrada = this.tpHoraEntrada.SelectedTime;
			oRegistroVisitasBE.HoraSalida = this.tpHoraSalida.SelectedTime;
			oRegistroVisitasBE.FlgEntregaRegalo = Convert.ToInt32(this.chkSeEntregoRegalo.Checked);
			oRegistroVisitasBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();
			oRegistroVisitasBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.EstadosRegistroVisita);
			oRegistroVisitasBE.IdEstado = Convert.ToInt32(Enumerados.EstadosRegistroVisita.Activo);
			if(this.txtDescripcion.Text.Trim()!=String.Empty)
			{
				oRegistroVisitasBE.Descripcion = this.txtDescripcion.Text;
			}
			if(this.txtObservaciones.Text.Trim()!=String.Empty)
			{
				oRegistroVisitasBE.Observaciones = this.txtObservaciones.Text;
			}

			CRegistroVisitas oCRegistroVisitas = new CRegistroVisitas();
			int retorno;
			if(this.chkTieneResponsables.Checked == true)
			{
				retorno = oCRegistroVisitas.RegistrarRegistroVisitas(oRegistroVisitasBE,(DataTable)ViewState[KEYQDATATABLE]);
			}
			else
			{
				retorno = oCRegistroVisitas.RegistrarRegistroVisitas(oRegistroVisitasBE,null);
			}

			if(retorno>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se registró el Registro de Visita Nro. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));

				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionComercial.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONREGISTROREGISTROVISITA));
			}
		}

		public void Modificar()
		{
			RegistroVisitasBE oRegistroVisitasBE = new RegistroVisitasBE();
			oRegistroVisitasBE.IdVisitas = Convert.ToInt32(Page.Request.QueryString[KEYQID]);
			oRegistroVisitasBE.IdTablaOrigen = Convert.ToInt32(this.hIdTablaOrigen.Value);
			oRegistroVisitasBE.IdOrigen = Convert.ToInt32(this.hIdOrigen.Value);
			oRegistroVisitasBE.IdCodigo = Convert.ToInt32(this.hIdCodigo.Value);
			oRegistroVisitasBE.FechaVisita = this.calFechaVisita.SelectedDate;
			oRegistroVisitasBE.HoraEntrada = this.tpHoraEntrada.SelectedTime;
			oRegistroVisitasBE.HoraSalida = this.tpHoraSalida.SelectedTime;
			oRegistroVisitasBE.FlgEntregaRegalo = Convert.ToInt32(this.chkSeEntregoRegalo.Checked);
			oRegistroVisitasBE.IdUsuarioActualizacion = CNetAccessControl.GetIdUser();
			oRegistroVisitasBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.EstadosRegistroVisita);
			oRegistroVisitasBE.IdEstado = Convert.ToInt32(Enumerados.EstadosRegistroVisita.Modificado);
			if(this.txtDescripcion.Text.Trim()!=String.Empty)
			{
				oRegistroVisitasBE.Descripcion = this.txtDescripcion.Text;
			}
			if(this.txtObservaciones.Text.Trim()!=String.Empty)
			{
				oRegistroVisitasBE.Observaciones = this.txtObservaciones.Text;
			}

			CRegistroVisitas oCRegistroVisitas = new CRegistroVisitas();
			int retorno;
			if(this.chkTieneResponsables.Checked == true)
			{
				retorno = oCRegistroVisitas.ModificarRegistroVisitas(oRegistroVisitasBE,(DataTable)ViewState[KEYQDATATABLE],((int[])ViewState[KEYQREGISTROSELIMINADOS]),Convert.ToInt32(ViewState[KEYQCODIGOINICIAL]));
			}
			else
			{
				retorno = oCRegistroVisitas.ModificarRegistroVisitas(oRegistroVisitasBE,null,((int[])ViewState[KEYQREGISTROSELIMINADOS]),0);
			}

			if(retorno>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se modificó el Registro de Visita Nro. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));

				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionComercial.ToString(),Mensajes.CODIGOMENSAJEMODIFICACIONREGISTROREGISTROVISITA));
			}
		}

		public void Eliminar()
		{
			// TODO:  Add DetallePresentesOtorgadosFamiliares.Eliminar implementation
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
			lblTitulo.Text = TITULOMODONUEVO;
			this.HabilitaResponsables(false);
			this.LlenarCombos();
		}

		public void CargarModoModificar()
		{
			this.TdCeldaCancelar.Visible = false;
			lblTitulo.Text = TITULOMODOMODIFICAR;
			this.LlenarCombos();
			
			CMantenimientos	oCMantenimientos = new CMantenimientos();
			RegistroVisitasBE oRegistroVisitasBE = (RegistroVisitasBE)oCMantenimientos.ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYQID]),Enumerados.ClasesNTAD.RegistroVisitasNTAD.ToString());
			
			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionComercial",this.ToString(),"Se consultó el Detalle del Registro de Visitas Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

			if(oRegistroVisitasBE!=null)
			{
				this.hIdTablaOrigen.Value = oRegistroVisitasBE.IdTablaOrigen.ToString();
				this.hIdOrigen.Value = oRegistroVisitasBE.IdOrigen.ToString();
				this.hIdCodigo.Value = oRegistroVisitasBE.IdCodigo.ToString();
				this.calFechaVisita.SelectedDate = oRegistroVisitasBE.FechaVisita;
				this.tpHoraEntrada.SelectedTime = oRegistroVisitasBE.HoraEntrada;
				this.tpHoraSalida.SelectedTime = oRegistroVisitasBE.HoraSalida;
				this.chkSeEntregoRegalo.Checked = Convert.ToBoolean(oRegistroVisitasBE.FlgEntregaRegalo);
				if(!oRegistroVisitasBE.Descripcion.IsNull)
				{
					this.txtDescripcion.Text = oRegistroVisitasBE.Descripcion.ToString();
				}
				if(!oRegistroVisitasBE.Observaciones.IsNull)
				{
					this.txtObservaciones.Text = oRegistroVisitasBE.Observaciones.ToString();
				}
				CEntidades oCEntidades = new CEntidades();
				string NombreEntidad = oCEntidades.ObtenerNombreEntidad(Convert.ToInt32(this.hIdCodigo.Value),Convert.ToInt32(this.hIdOrigen.Value),Convert.ToInt32(this.hIdTablaOrigen.Value)).Replace(Constantes.SIGNOMENOR,Constantes.SIGNOABREPARANTESIS).Replace(Constantes.SIGNOMAYOR,Constantes.SIGNOCIERRAPARANTESIS);
				this.txtEntidad.Text = NombreEntidad;

				CResponsableVisitas oCResponsableVisitas = new CResponsableVisitas();
				DataTable dt = oCResponsableVisitas.ConsultarResponsablesVisitaPorRegistroDeVisitas(oRegistroVisitasBE.IdVisitas);
				if(dt != null)
				{
					dt.PrimaryKey = new DataColumn[1]{dt.Columns[Enumerados.ColumnasResponsablesVisita.IdResponsableVisita.ToString()]};
					this.chkTieneResponsables.Checked = true;
					this.HabilitaResponsables(true);
					this.ActualizarGrilla(dt);
				}
				else
				{
					this.chkTieneResponsables.Checked = false;
					this.HabilitaResponsables(false);
					this.CrearDataTable();
				}
				ViewState[KEYQCODIGOINICIAL] = oCResponsableVisitas.ObtenerMaximoDetallePorRegistroDeVisitas(oRegistroVisitasBE.IdVisitas);
				ViewState[KEYQCONTADOR] = ViewState[KEYQCODIGOINICIAL];
				ViewState[KEYQREGISTROSELIMINADOS] = new int [Convert.ToInt32(ViewState[KEYQCONTADOR])-1];
				ViewState[KEYQCONTADORREGISTROSELIMINADOS] = 0;
			}
		}

		public void CargarModoConsulta()
		{
			Helper.BloquearControles(this);
			this.ibtnCancelar.Visible = false;
			this.OcultarCamposResponsables();
			lblTitulo.Text = TITULOMODOCONSULTA;
			this.LlenarCombos();
			
			CMantenimientos	oCMantenimientos = new CMantenimientos();
			RegistroVisitasBE oRegistroVisitasBE = (RegistroVisitasBE)oCMantenimientos.ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYQID]),Enumerados.ClasesNTAD.RegistroVisitasNTAD.ToString());
			
			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionComercial",this.ToString(),"Se consultó el Detalle del Registro de Visitas Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

			if(oRegistroVisitasBE!=null)
			{
				this.hIdTablaOrigen.Value = oRegistroVisitasBE.IdTablaOrigen.ToString();
				this.hIdOrigen.Value = oRegistroVisitasBE.IdOrigen.ToString();
				this.hIdCodigo.Value = oRegistroVisitasBE.IdCodigo.ToString();
				this.calFechaVisita.SelectedDate = oRegistroVisitasBE.FechaVisita;
				this.tpHoraEntrada.SelectedTime = oRegistroVisitasBE.HoraEntrada;
				this.tpHoraSalida.SelectedTime = oRegistroVisitasBE.HoraSalida;
				this.chkSeEntregoRegalo.Checked = Convert.ToBoolean(oRegistroVisitasBE.FlgEntregaRegalo);
				if(!oRegistroVisitasBE.Descripcion.IsNull)
				{
					this.txtDescripcion.Text = oRegistroVisitasBE.Descripcion.ToString();
				}
				if(!oRegistroVisitasBE.Observaciones.IsNull)
				{
					this.txtObservaciones.Text = oRegistroVisitasBE.Observaciones.ToString();
				}
				CEntidades oCEntidades = new CEntidades();
				string NombreEntidad = oCEntidades.ObtenerNombreEntidad(Convert.ToInt32(this.hIdCodigo.Value),Convert.ToInt32(this.hIdOrigen.Value),Convert.ToInt32(this.hIdTablaOrigen.Value)).Replace(Constantes.SIGNOMENOR,Constantes.SIGNOABREPARANTESIS).Replace(Constantes.SIGNOMAYOR,Constantes.SIGNOCIERRAPARANTESIS);
				this.txtEntidad.Text = NombreEntidad;

				CResponsableVisitas oCResponsableVisitas = new CResponsableVisitas();
				DataTable dt = oCResponsableVisitas.ConsultarResponsablesVisitaPorRegistroDeVisitas(oRegistroVisitasBE.IdVisitas);
				if(dt != null)
				{
					dt.PrimaryKey = new DataColumn[1]{dt.Columns[Enumerados.ColumnasResponsablesVisita.IdResponsableVisita.ToString()]};
					this.chkTieneResponsables.Checked = true;
					this.HabilitaResponsables(false);
					this.ActualizarGrilla(dt);
				}
				else
				{
					this.chkTieneResponsables.Checked = false;
					this.HabilitaResponsables(false);
					this.CrearDataTable();
				}
				ViewState[KEYQCODIGOINICIAL] = oCResponsableVisitas.ObtenerMaximoDetallePorRegistroDeVisitas(oRegistroVisitasBE.IdVisitas);
				ViewState[KEYQCONTADOR] = ViewState[KEYQCODIGOINICIAL];
				ViewState[KEYQREGISTROSELIMINADOS] = new int [Convert.ToInt32(ViewState[KEYQCONTADOR])-1];
				ViewState[KEYQCONTADORREGISTROSELIMINADOS] = 0;
			}
			this.grid.Enabled = true;
		}

		public bool ValidarCampos()
		{
			return this.ValidarCamposRequeridos();
		}

		public bool ValidarCamposRequeridos()
		{
			if(this.txtEntidad.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEREGISTROVISITACAMPOREQUERIDONOMBREENTIDAD));
				return false;
			}
			return true;
		}

		public bool ValidarExpresionesRegulares()
		{
			return true;
		}

		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add DetalleRegistroVisitas.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetalleRegistroVisitas.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetalleRegistroVisitas.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			lItem = new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,Utilitario.Constantes.VALORSELECCIONAR);
			this.llenarCargos();
			this.ddlbCargoResponsable.Items.Insert(Constantes.POSICIONCONTADOR,lItem);
		}

		public void LlenarDatos()
		{
			// TODO:  Add DetalleRegistroVisitas.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			this.ibtnEliminar.Attributes.Add(Constantes.EVENTOCLICK,JSVERIFICARELIMINAR);

			this.ibtnBuscarEntidad.Attributes.Add(Constantes.EVENTOCLICK,Helper.PopupBusqueda(URLBUSQUEDAENTIDAD + Utilitario.Constantes.KEYMODOPAGINA +  Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.C.ToString(),750,500,true));
			this.ibtnBuscarPersonal.Attributes.Add(Constantes.EVENTOCLICK,Helper.PopupBusqueda(URLBUSQUEDAPERSONAL,750,500,true));

			this.rfvNombreEntidad.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEREGISTROVISITACAMPOREQUERIDONOMBREENTIDAD);
			this.rfvNombreEntidad.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEREGISTROVISITACAMPOREQUERIDONOMBREENTIDAD);
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetalleRegistroVisitas.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetalleRegistroVisitas.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetalleRegistroVisitas.Exportar implementation
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

		private void llenarCargos()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			ddlbCargoResponsable.DataSource = oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Enumerados.TablasTabla.CargoResponsablesVisitas));
			ddlbCargoResponsable.DataValueField =Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbCargoResponsable.DataTextField =Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbCargoResponsable.DataBind();
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

		private void chkTieneResponsables_CheckedChanged(object sender, System.EventArgs e)
		{
			if(this.chkTieneResponsables.Checked == true)
			{
				this.HabilitaResponsables(true);
			}
			else
			{
				this.HabilitaResponsables(false);
			}
		}

		private void CrearDataTable()
		{
			DataTable dt = new DataTable("DataTableResponsableVisitas");
			dt.Columns.Add(Enumerados.ColumnasResponsablesVisita.IdResponsableVisita.ToString());
			dt.Columns.Add(Enumerados.ColumnasResponsablesVisita.NombreResponsable.ToString());
			dt.Columns.Add(Enumerados.ColumnasResponsablesVisita.IdPersonal.ToString());
			dt.Columns.Add(Enumerados.ColumnasResponsablesVisita.Nombre.ToString());
			dt.Columns.Add(Enumerados.ColumnasResponsablesVisita.IdTablaCargoResponsable.ToString());
			dt.Columns.Add(Enumerados.ColumnasResponsablesVisita.IdCargoResponsable.ToString());
			dt.Columns.Add(Enumerados.ColumnasResponsablesVisita.Cargo.ToString());
			dt.Columns.Add(Enumerados.ColumnasResponsablesVisita.Descripcion.ToString());
			dt.Columns.Add(Enumerados.ColumnasResponsablesVisita.Observaciones.ToString());
			dt.Columns.Add(Enumerados.ColumnasResponsablesVisita.Tipo.ToString());
			ViewState[KEYQDATATABLE] = dt;
			ViewState[KEYQCONTADOR] = 1;
			dt.PrimaryKey = new DataColumn[1]{dt.Columns[Enumerados.ColumnasResponsablesVisita.IdResponsableVisita.ToString()]};
		}

		private void rblTipoResponsable_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(this.rblTipoResponsable.SelectedIndex == 0)
			{
				this.txtPersonal.ReadOnly = true;
				this.ibtnBuscarPersonal.Visible = true;
				this.LimpiarCamposResponsables();
			}
			else
			{
				this.txtPersonal.ReadOnly = false;
				this.ibtnBuscarPersonal.Visible = false;
				this.LimpiarCamposResponsables();
			}
		}

		private void HabilitaResponsables(bool valor)
		{
			this.rblTipoResponsable.Enabled = valor;
			this.txtPersonal.Enabled = valor;
			this.ibtnBuscarPersonal.Enabled = valor;
			this.ddlbCargoResponsable.Enabled = valor;
			this.txtDescripcionResponsable.Enabled = valor;
			this.txtObservacionesResponsable.Enabled = valor;
			this.grid.Enabled = valor;
			this.ibtnAgregar.Visible = valor;
			this.ibtnModificar.Visible = valor;
			this.ibtnEliminar.Visible = valor;
		}

		private void ibtnAgregar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if(this.ValidarCamposResponsables())
			{
				if(this.rblTipoResponsable.SelectedIndex == 0)
				{
					DataTable dt = ((DataTable)ViewState[KEYQDATATABLE]).Copy();
					int contador = Convert.ToInt32(ViewState[KEYQCONTADOR]);
					DataRow dr = dt.NewRow();

					Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.QueryString[Constantes.KEYMODOPAGINA]) ;

					switch (oModoPagina)
					{
						case Enumerados.ModoPagina.N:
						{
							dr.ItemArray = new object [9] {
															  contador,
															  null,
															  Convert.ToInt32(this.hIdPersonal.Value),
															  this.txtPersonal.Text,
															  Convert.ToInt32(Enumerados.TablasTabla.CargoResponsablesVisitas),
															  Convert.ToInt32(this.ddlbCargoResponsable.SelectedValue),
															  this.ddlbCargoResponsable.SelectedItem.Text,
															  this.txtDescripcionResponsable.Text,
															  this.txtObservacionesResponsable.Text};
							break;
						}
						case Enumerados.ModoPagina.M:
						{
							dr.ItemArray = new object [10] {
															  contador,
															  null,
															  Convert.ToInt32(this.hIdPersonal.Value),
															  this.txtPersonal.Text,
															  Convert.ToInt32(Enumerados.TablasTabla.CargoResponsablesVisitas),
															  Convert.ToInt32(this.ddlbCargoResponsable.SelectedValue),
															  this.ddlbCargoResponsable.SelectedItem.Text,
															  this.txtDescripcionResponsable.Text,
															  this.txtObservacionesResponsable.Text,
															  Convert.ToInt32(Enumerados.TipoLogicaCabeceraDetalle.Agregar)};
							break;
						}
					}
					
					dt.Rows.Add(dr);
					ViewState[KEYQCONTADOR] = ++contador;
					this.ActualizarGrilla(dt);
					this.LimpiarCamposResponsables();
				}
				else
				{
					DataTable dt = ((DataTable)ViewState[KEYQDATATABLE]).Copy();
					int contador = Convert.ToInt32(ViewState[KEYQCONTADOR]);
					DataRow dr = dt.NewRow();

					Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.QueryString[Constantes.KEYMODOPAGINA]) ;

					switch (oModoPagina)
					{
						case Enumerados.ModoPagina.N:
						{
							dr.ItemArray = new object [9] {
															  contador,
															  this.txtPersonal.Text,
															  null,
															  this.txtPersonal.Text,
															  Convert.ToInt32(Enumerados.TablasTabla.CargoResponsablesVisitas),
															  Convert.ToInt32(this.ddlbCargoResponsable.SelectedValue),
															  this.ddlbCargoResponsable.SelectedItem.Text,
															  this.txtDescripcionResponsable.Text,
															  this.txtObservacionesResponsable.Text};
							break;
						}
						case Enumerados.ModoPagina.M:
						{
							dr.ItemArray = new object [10] {
															  contador,
															  this.txtPersonal.Text,
															  null,
															  this.txtPersonal.Text,
															  Convert.ToInt32(Enumerados.TablasTabla.CargoResponsablesVisitas),
															  Convert.ToInt32(this.ddlbCargoResponsable.SelectedValue),
															  this.ddlbCargoResponsable.SelectedItem.Text,
															  this.txtDescripcionResponsable.Text,
															  this.txtObservacionesResponsable.Text,
															  Convert.ToInt32(Enumerados.TipoLogicaCabeceraDetalle.Agregar)};
							break;
						}
					}
					
					dt.Rows.Add(dr);
					ViewState[KEYQCONTADOR] = ++contador;
					this.ActualizarGrilla(dt);
					this.LimpiarCamposResponsables();
				}
			}
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,
					Utilitario.Helper.MostrarDatosEnCajaTextoManteniendoMayusculaMinuscula("hIdResponsableVisita",dr[Enumerados.ColumnasResponsablesVisita.IdResponsableVisita.ToString()].ToString()),
					Utilitario.Helper.MostrarDatosEnCajaTextoManteniendoMayusculaMinuscula("txtPersonal",dr[Enumerados.ColumnasResponsablesVisita.Nombre.ToString()].ToString()),
					Utilitario.Helper.MostrarDatosEnCajaTextoManteniendoMayusculaMinuscula("hIdPersonal",dr[Enumerados.ColumnasResponsablesVisita.IdPersonal.ToString()].ToString()),
					Utilitario.Helper.MostrarDatosEnCajaTextoManteniendoMayusculaMinuscula("txtDescripcionResponsable",dr[Enumerados.ColumnasResponsablesVisita.Descripcion.ToString()].ToString()),
					Utilitario.Helper.MostrarDatosEnCajaTextoManteniendoMayusculaMinuscula("txtObservacionesResponsable",dr[Enumerados.ColumnasResponsablesVisita.Observaciones.ToString()].ToString())
					);
			}
		}

		private void ibtnModificar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				if(this.hIdResponsableVisita.Value.Length==0)
				{
					ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO));
				}
				else
				{
					if(this.ValidarCamposResponsables())
					{
						DataTable dt = ((DataTable)ViewState[KEYQDATATABLE]).Copy();
						if(this.rblTipoResponsable.SelectedIndex == 0)
						{
							Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.QueryString[Constantes.KEYMODOPAGINA]) ;

							switch (oModoPagina)
							{
								case Enumerados.ModoPagina.N:
								{
									dt.Rows.Find(this.hIdResponsableVisita.Value).ItemArray = new object [9] {
																												 Convert.ToInt32(this.hIdResponsableVisita.Value),
																												 Constantes.VACIO,
																												 Convert.ToInt32(this.hIdPersonal.Value),
																												 this.txtPersonal.Text,
																												 Convert.ToInt32(Enumerados.TablasTabla.CargoResponsablesVisitas),
																												 Convert.ToInt32(this.ddlbCargoResponsable.SelectedValue),
																												 this.ddlbCargoResponsable.SelectedItem.Text,
																												 this.txtDescripcionResponsable.Text,
																												 this.txtObservacionesResponsable.Text};
									break;
								}
								case Enumerados.ModoPagina.M:
								{
									dt.Rows.Find(this.hIdResponsableVisita.Value).ItemArray = new object [10] {
																												 Convert.ToInt32(this.hIdResponsableVisita.Value),
																												 Constantes.VACIO,
																												 Convert.ToInt32(this.hIdPersonal.Value),
																												 this.txtPersonal.Text,
																												 Convert.ToInt32(Enumerados.TablasTabla.CargoResponsablesVisitas),
																												 Convert.ToInt32(this.ddlbCargoResponsable.SelectedValue),
																												 this.ddlbCargoResponsable.SelectedItem.Text,
																												 this.txtDescripcionResponsable.Text,
																												 this.txtObservacionesResponsable.Text,
																												 Convert.ToInt32(ViewState[KEYQCODIGOINICIAL])>Convert.ToInt32(this.hIdResponsableVisita.Value)?Convert.ToInt32(Enumerados.TipoLogicaCabeceraDetalle.Modificar):Convert.ToInt32(Enumerados.TipoLogicaCabeceraDetalle.Agregar)};
									break;
								}
							}
							
							this.ActualizarGrilla(dt);
							this.LimpiarCamposResponsables();
						}
						else
						{
							Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.QueryString[Constantes.KEYMODOPAGINA]) ;

							switch (oModoPagina)
							{
								case Enumerados.ModoPagina.N:
								{
									dt.Rows.Find(this.hIdResponsableVisita.Value).ItemArray = new object [9] {
																												 Convert.ToInt32(this.hIdResponsableVisita.Value),
																												 this.txtPersonal.Text,
																												 0,
																												 this.txtPersonal.Text,
																												 Convert.ToInt32(Enumerados.TablasTabla.CargoResponsablesVisitas),
																												 Convert.ToInt32(this.ddlbCargoResponsable.SelectedValue),
																												 this.ddlbCargoResponsable.SelectedItem.Text,
																												 this.txtDescripcionResponsable.Text,
																												 this.txtObservacionesResponsable.Text};
									break;
								}
								case Enumerados.ModoPagina.M:
								{
									dt.Rows.Find(this.hIdResponsableVisita.Value).ItemArray = new object [10] {
																												 Convert.ToInt32(this.hIdResponsableVisita.Value),
																												 this.txtPersonal.Text,
																												 0,
																												 this.txtPersonal.Text,
																												 Convert.ToInt32(Enumerados.TablasTabla.CargoResponsablesVisitas),
																												 Convert.ToInt32(this.ddlbCargoResponsable.SelectedValue),
																												 this.ddlbCargoResponsable.SelectedItem.Text,
																												 this.txtDescripcionResponsable.Text,
																												 this.txtObservacionesResponsable.Text,
																												 Convert.ToInt32(ViewState[KEYQCODIGOINICIAL])>Convert.ToInt32(this.hIdResponsableVisita.Value)?Convert.ToInt32(Enumerados.TipoLogicaCabeceraDetalle.Modificar):Convert.ToInt32(Enumerados.TipoLogicaCabeceraDetalle.Agregar)};
									break;
								}
							}
							
							this.ActualizarGrilla(dt);
							this.LimpiarCamposResponsables();
						}
					}
				}
			}
			catch(Exception ex)
			{
				string a = ex.Message;
				this.LimpiarCamposResponsables();
			}
		}

		private void ibtnEliminar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				if(this.hIdResponsableVisita.Value.Length==0)
				{
					ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO));
				}
				else
				{
					DataTable dt = ((DataTable)ViewState[KEYQDATATABLE]).Copy();
					dt.Rows.Find(this.hIdResponsableVisita.Value).Delete();
					dt.AcceptChanges();
					if(Page.Request.QueryString[Constantes.KEYMODOPAGINA].ToString() == Enumerados.ModoPagina.M.ToString())
					{
						if(Convert.ToInt32(this.hIdResponsableVisita.Value) < Convert.ToInt32(ViewState[KEYQCODIGOINICIAL]))
						{
							int contador = Convert.ToInt32(ViewState[KEYQCONTADORREGISTROSELIMINADOS]);
							((int[])ViewState[KEYQREGISTROSELIMINADOS])[contador] = Convert.ToInt32(this.hIdResponsableVisita.Value);
							ViewState[KEYQCONTADORREGISTROSELIMINADOS] = ++contador;
						}
					}
					this.ActualizarGrilla(dt);
					this.LimpiarCamposResponsables();
				}
			}
			catch(Exception ex)
			{
				string a = ex.Message;
				this.LimpiarCamposResponsables();
			}
		}

		private void LimpiarCamposResponsables()
		{
			this.txtPersonal.Text = Constantes.VACIO;
			this.hIdPersonal.Value = Constantes.VACIO;
			this.hIdResponsableVisita.Value = Constantes.VACIO;
			this.txtDescripcionResponsable.Text = Constantes.VACIO;
			this.txtObservacionesResponsable.Text = Constantes.VACIO;
		}

		private bool ValidarCamposResponsables()
		{
			if(this.txtPersonal.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEREGISTROVISITACAMPOREQUERIDONOMBRERESPONSABLE));
				return false;
			}
			if(this.ddlbCargoResponsable.SelectedItem.Text == Constantes.TEXTOSSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEREGISTROVISITACAMPOREQUERIDOCARGORESPONSABLE));
				return false;
			}
			return true;
		}

		private void ActualizarGrilla(DataTable dt)
		{
			ViewState[KEYQDATATABLE] = dt;

			if(ViewState[KEYQDATATABLE] != null)
			{
				this.grid.DataSource = dt;
				this.grid.Visible = true;
			}
			else
			{
				this.grid.DataSource = null;
				this.grid.Visible = false;
			}
			this.grid.DataBind();
		}

		private void OcultarCamposResponsables()
		{
			this.chkTieneResponsables.Visible = false;
			this.rblTipoResponsable.Visible = false;
			this.lblNombreResponsable.Visible = false;
			this.txtPersonal.Visible = false;
			this.ibtnBuscarPersonal.Visible = false;
			this.lblCargoResponsable.Visible = false;
			this.ddlbCargoResponsable.Visible = false;
			this.rfvCargoResponsable.Visible = false;
			this.lblDescripcionResponsable.Visible = false;
			this.txtDescripcionResponsable.Visible = false;
			this.lblObservacionesResponsable.Visible = false;
			this.txtObservacionesResponsable.Visible = false;
		}
	}
}