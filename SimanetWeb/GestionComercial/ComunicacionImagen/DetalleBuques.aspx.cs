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
	/// Summary description for DetalleBuques.
	/// </summary>
	public class DetalleBuques: System.Web.UI.Page, IPaginaMantenimento, IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary vSum;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.Label lblNombre;
		protected System.Web.UI.WebControls.TextBox txtNombre;
		protected System.Web.UI.WebControls.CheckBox chkEnTrabajos;
		protected System.Web.UI.WebControls.Label lblPosicionBuque;
		protected System.Web.UI.WebControls.TextBox txtPosicionBuque;
		protected System.Web.UI.WebControls.Label lblTrabajoActual;
		protected System.Web.UI.WebControls.DropDownList ddlbTrabajoActual;
		protected System.Web.UI.WebControls.Label lblOficialAlMando;
		protected System.Web.UI.WebControls.TextBox txtOficialAlMando;
		protected System.Web.UI.WebControls.Label lblGradoOficial;
		protected System.Web.UI.WebControls.TextBox txtGradoOficial;
		protected System.Web.UI.WebControls.ImageButton ibtnBuscarGrado;
		protected System.Web.UI.WebControls.Label lblLineaNegocio;
		protected System.Web.UI.WebControls.DropDownList ddlbLineaNegocio;
		protected System.Web.UI.WebControls.Label lblDescripcion;
		protected System.Web.UI.WebControls.Label lblObservaciones;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.TextBox txtObservaciones;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvNombre;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvLineaNegocio;
		protected System.Web.UI.WebControls.Label lblEnTrabajos;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdGrado;
		protected System.Web.UI.HtmlControls.HtmlTableCell TdCeldaCancelar;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlbTrabajoActual;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlbLineaNegocio;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnCancelar;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion Controles
		
		#region Constantes
		//Titulos 
		const string TITULOMODONUEVO = "NUEVO BUQUE";
		const string TITULOMODOMODIFICAR = "ACTUALIZACION DE BUQUE";
		const string TITULOMODOCONSULTA = "DETALLE BUQUE";

		//Key Session y QueryString
		const string KEYQID = "Id";
		const string KEYQIDTABLAORIGEN = "IdTablaOrigen";
		const string KEYQIDORIGEN = "IdOrigen";
		const string KEYQIDCODIGO = "IdCodigo";
		const string KEYQIDPRESENTE = "IdPresente";
		const string KEYQCANTIDAD = "Cantidad";
	
		//Paginas
		const string URLBUSQUEDAGRADOS = "../BusquedaGrado.aspx";
		#endregion Constantes		
		
		#region Variables
		ListItem  lItem ;
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaMantenimento Members
		public void Agregar()
		{
			BuqueBE oBuqueBE = new BuqueBE();
			oBuqueBE.NombreBuque = this.txtNombre.Text;
			oBuqueBE.FlgEnTrabajos = Convert.ToInt32(this.chkEnTrabajos.Checked);
			if(this.txtPosicionBuque.Text.Trim()!=String.Empty)
			{
				oBuqueBE.PosicionBuque = this.txtPosicionBuque.Text;
			}
			if(this.ddlbTrabajoActual.SelectedValue != Constantes.VALORSELECCIONAR)
			{
				oBuqueBE.IdTablaTrabajoActual = Convert.ToInt32(Enumerados.TablasTabla.TrabajoActual);
				oBuqueBE.IdTrabajoActual = Convert.ToInt32(this.ddlbTrabajoActual.SelectedValue);
			}
			if(this.txtOficialAlMando.Text.Trim()!=String.Empty)
			{
				oBuqueBE.NombreOficialMando = this.txtOficialAlMando.Text;
			}
			if(this.hIdGrado.Value!=String.Empty)
			{
				oBuqueBE.IdGrado = Convert.ToInt32(this.hIdGrado.Value);
			}
			oBuqueBE.IdTablaLineaNegocio = Convert.ToInt32(Enumerados.TablasTabla.LineasNegocio);
			oBuqueBE.IdLineaNegocio = Convert.ToInt32(this.ddlbLineaNegocio.SelectedValue);
			oBuqueBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();
			oBuqueBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.EstadosBuque);
			oBuqueBE.IdEstado = Convert.ToInt32(Enumerados.EstadosBuque.Activo);
			if(this.txtDescripcion.Text.Trim()!=String.Empty)
			{
				oBuqueBE.Descripcion = this.txtDescripcion.Text;
			}
			if(this.txtObservaciones.Text.Trim()!=String.Empty)
			{
				oBuqueBE.Observaciones = this.txtObservaciones.Text;
			}

			CMantenimientos oCMantenimientos = new CMantenimientos();
			int retorno = oCMantenimientos.Insertar(oBuqueBE);

			if(retorno>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se registró el Buque Nro. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));
				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionComercial.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONREGISTROBUQUE));
			}
		}

		public void Modificar()
		{
			BuqueBE oBuqueBE = new BuqueBE();
			oBuqueBE.IdBuque = Convert.ToInt32(Page.Request.QueryString[KEYQID]);
			oBuqueBE.NombreBuque = this.txtNombre.Text;
			oBuqueBE.FlgEnTrabajos = Convert.ToInt32(this.chkEnTrabajos.Checked);
			if(this.txtPosicionBuque.Text.Trim()!=String.Empty)
			{
				oBuqueBE.PosicionBuque = this.txtPosicionBuque.Text;
			}
			if(this.ddlbTrabajoActual.SelectedValue != Constantes.VALORSELECCIONAR)
			{
				oBuqueBE.IdTablaTrabajoActual = Convert.ToInt32(Enumerados.TablasTabla.TrabajoActual);
				oBuqueBE.IdTrabajoActual = Convert.ToInt32(this.ddlbTrabajoActual.SelectedValue);
			}
			if(this.txtOficialAlMando.Text.Trim()!=String.Empty)
			{
				oBuqueBE.NombreOficialMando = this.txtOficialAlMando.Text;
			}
			if(this.hIdGrado.Value!=String.Empty)
			{
				oBuqueBE.IdGrado = Convert.ToInt32(this.hIdGrado.Value);
			}
			oBuqueBE.IdTablaLineaNegocio = Convert.ToInt32(Enumerados.TablasTabla.LineasNegocio);
			oBuqueBE.IdLineaNegocio = Convert.ToInt32(this.ddlbLineaNegocio.SelectedValue);
			oBuqueBE.IdUsuarioActualizacion = CNetAccessControl.GetIdUser();
			oBuqueBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.EstadosBuque);
			oBuqueBE.IdEstado = Convert.ToInt32(Enumerados.EstadosBuque.Modificado);
			if(this.txtDescripcion.Text.Trim()!=String.Empty)
			{
				oBuqueBE.Descripcion = this.txtDescripcion.Text;
			}
			if(this.txtObservaciones.Text.Trim()!=String.Empty)
			{
				oBuqueBE.Observaciones = this.txtObservaciones.Text;
			}

			CMantenimientos oCMantenimientos = new CMantenimientos();
			int retorno = oCMantenimientos.Modificar(oBuqueBE);

			if(retorno>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se modificó el Buque Nro. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));
				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionComercial.ToString(),Mensajes.CODIGOMENSAJEMODIFICACIONREGISTROBUQUE));
			}
		}

		public void Eliminar()
		{
			// TODO:  Add DetalleBuques.Eliminar implementation
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
			this.LlenarCombos();
		}

		public void CargarModoModificar()
		{
			this.TdCeldaCancelar.Visible = false;
			lblTitulo.Text = TITULOMODOMODIFICAR;
			this.LlenarCombos();
			
			CMantenimientos	oCMantenimientos = new CMantenimientos();
			BuqueBE oBuqueBE = (BuqueBE)oCMantenimientos.ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYQID]),Enumerados.ClasesNTAD.BuqueNTAD.ToString());
			
			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionComercial",this.ToString(),"Se consultó el Detalle del Buque Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

			if(oBuqueBE!=null)
			{
				this.txtNombre.Text = oBuqueBE.NombreBuque;
				this.chkEnTrabajos.Checked = Convert.ToBoolean(oBuqueBE.FlgEnTrabajos);
				if(!oBuqueBE.PosicionBuque.IsNull)
				{
					this.txtPosicionBuque.Text = oBuqueBE.PosicionBuque.ToString();
				}
				if(!oBuqueBE.IdTrabajoActual.IsNull)
				{
					this.ddlbTrabajoActual.Items.FindByValue(oBuqueBE.IdTrabajoActual.ToString()).Selected = true;
				}
				if(!oBuqueBE.NombreOficialMando.IsNull)
				{
					this.txtOficialAlMando.Text = oBuqueBE.NombreOficialMando.ToString();
				}
				if(!oBuqueBE.IdGrado.IsNull)
				{
					this.hIdGrado.Value = oBuqueBE.IdGrado.ToString();
					CGrados oCGrados = new CGrados();
					this.txtGradoOficial.Text = oCGrados.ObtenerDescripcionGrado(Convert.ToInt32(this.hIdGrado.Value));
				}
				this.ddlbLineaNegocio.Items.FindByValue(oBuqueBE.IdLineaNegocio.ToString()).Selected = true;
				if(!oBuqueBE.Descripcion.IsNull)
				{
					this.txtDescripcion.Text = oBuqueBE.Descripcion.ToString();
				}
				if(!oBuqueBE.Observaciones.IsNull)
				{
					this.txtObservaciones.Text = oBuqueBE.Observaciones.ToString();
				}
			}
		}

		public void CargarModoConsulta()
		{
			this.ibtnCancelar.Visible = false;
			lblTitulo.Text = TITULOMODOCONSULTA;
			this.LlenarCombos();
			
			CMantenimientos	oCMantenimientos = new CMantenimientos();
			BuqueBE oBuqueBE = (BuqueBE)oCMantenimientos.ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYQID]),Enumerados.ClasesNTAD.BuqueNTAD.ToString());
			
			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionComercial",this.ToString(),"Se consultó el Detalle del Buque Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

			if(oBuqueBE!=null)
			{
				this.txtNombre.Text = oBuqueBE.NombreBuque;
				this.chkEnTrabajos.Checked = Convert.ToBoolean(oBuqueBE.FlgEnTrabajos);
				if(!oBuqueBE.PosicionBuque.IsNull)
				{
					this.txtPosicionBuque.Text = oBuqueBE.PosicionBuque.ToString();
				}
				if(!oBuqueBE.IdTrabajoActual.IsNull)
				{
					this.ddlbTrabajoActual.Items.FindByValue(oBuqueBE.IdTrabajoActual.ToString()).Selected = true;
				}
				if(!oBuqueBE.NombreOficialMando.IsNull)
				{
					this.txtOficialAlMando.Text = oBuqueBE.NombreOficialMando.ToString();
				}
				if(!oBuqueBE.IdGrado.IsNull)
				{
					this.hIdGrado.Value = oBuqueBE.IdGrado.ToString();
					CGrados oCGrados = new CGrados();
					this.txtGradoOficial.Text = oCGrados.ObtenerDescripcionGrado(Convert.ToInt32(this.hIdGrado.Value));
				}
				this.ddlbLineaNegocio.Items.FindByValue(oBuqueBE.IdLineaNegocio.ToString()).Selected = true;
				if(!oBuqueBE.Descripcion.IsNull)
				{
					this.txtDescripcion.Text = oBuqueBE.Descripcion.ToString();
				}
				if(!oBuqueBE.Observaciones.IsNull)
				{
					this.txtObservaciones.Text = oBuqueBE.Observaciones.ToString();
				}
			}
			Helper.BloquearControles(this);
		}

		public bool ValidarCampos()
		{
			return this.ValidarCamposRequeridos();
		}

		public bool ValidarCamposRequeridos()
		{
			if(this.txtNombre.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEBUQUECAMPOREQUERIDONOMBRE));
				return false;
			}
			if(this.ddlbLineaNegocio.SelectedItem.Text == Constantes.TEXTOSSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEBUQUECAMPOREQUERIDOLINEANEGOCIO));
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
			// TODO:  Add DetalleBuques.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetalleBuques.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetalleBuques.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			lItem = new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,Utilitario.Constantes.VALORSELECCIONAR);
			this.llenarLineasNegocio();
			this.llenarTrabajoActual();
			ListItem elemento = new ListItem();
			int [] remover = {5,3,1};

			foreach(int a in remover)
			{
				elemento = this.ddlbLineaNegocio.Items.FindByValue(a.ToString());
				if(elemento != null)
				{
					this.ddlbLineaNegocio.Items.Remove(elemento);
				}
			}
			this.ddlbLineaNegocio.Items.Insert(0,lItem);
			this.ddlbTrabajoActual.Items.Insert(0,lItem);
		}

		public void LlenarDatos()
		{
			// TODO:  Add DetallePresentesOtorgadosFamiliares.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			this.ibtnBuscarGrado.Attributes.Add(Constantes.EVENTOCLICK,Helper.PopupBusqueda(URLBUSQUEDAGRADOS,750,500,true));

			this.rfvNombre.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEBUQUECAMPOREQUERIDONOMBRE);
			this.rfvNombre.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEBUQUECAMPOREQUERIDONOMBRE);

			this.rfvLineaNegocio.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEBUQUECAMPOREQUERIDOLINEANEGOCIO);
			this.rfvLineaNegocio.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEBUQUECAMPOREQUERIDOLINEANEGOCIO);
			this.rfvLineaNegocio.InitialValue = Constantes.VALORSELECCIONAR;
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetalleBuques.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetalleBuques.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetalleBuques.Exportar implementation
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

		private void llenarLineasNegocio()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			ddlbLineaNegocio.DataSource = oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Enumerados.TablasTabla.LineasNegocio));
			ddlbLineaNegocio.DataValueField =Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbLineaNegocio.DataTextField =Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbLineaNegocio.DataBind();
		}

		private void llenarTrabajoActual()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			ddlbTrabajoActual.DataSource = oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Enumerados.TablasTabla.TrabajoActual));
			ddlbTrabajoActual.DataValueField =Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbTrabajoActual.DataTextField =Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbTrabajoActual.DataBind();
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