using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using SIMA.SimaNetWeb.InterfacesIU;
using SIMA.Controladoras.GestionComercial;
using SIMA.Controladoras.General;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using SIMA.EntidadesNegocio.GestionComercial;

namespace SIMA.SimaNetWeb.GestionComercial.InformacionComercial
{
	/// <summary>
	/// Summary description for DetalleCostoEmbarcacion.
	/// </summary>
	public class DetalleCostoEmbarcacion: System.Web.UI.Page,IPaginaBase//,IPaginaMantenimento
	{
		#region Controles
		protected System.Web.UI.WebControls.Label lblMensaje;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvDestino;
		protected eWorld.UI.NumericBox txtPorcentajeAvance2;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvMoned;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblDatos;
		protected System.Web.UI.WebControls.Label lblDescripcion;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvDescripcion;
		protected System.Web.UI.WebControls.Label lblTipoEmbarcacion;
		protected System.Web.UI.WebControls.DropDownList ddlbTipoEmbarcacion;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvTipoEmbarcacion;
		protected System.Web.UI.WebControls.Label lblCO;
		protected System.Web.UI.WebControls.DropDownList ddlbCentroOperativo;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvCentroOperativo;
		protected System.Web.UI.WebControls.Label lblCosto;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvCosto;
		protected System.Web.UI.WebControls.Label lblMoneda;
		protected System.Web.UI.WebControls.DropDownList ddlbMoneda;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvMoneda;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary vSum;
		protected eWorld.UI.NumericBox nbCosto;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlbTipoEmbarcacion;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlbCentroOperativo;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlbMoneda;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellibtnCancelar;
		protected System.Web.UI.HtmlControls.HtmlTableCell TdCeldaCancelar;
		private   ListItem Item =  new ListItem();
		#endregion Controles

		#region Constantes
		
		//Titulos 
		const string TITULOMODONUEVO     = "NUEVO COSTO DE EMBARCACION";
		const string TITULOMODOMODIFICAR = "ACTUALIZACION DE COSTO DE EMBARCACION";
		const string TITULOMODOCONSULTA  = "CONSULTA DE COSTO EMBARCACION";

		//Key Session y QueryString
		const string KEYQID  = "IdProductoEmbarcacion";
		const string KEYQID1 = "IdCentroOperativo";
	
		//Otros
		const int EXISTE = 1;
		const int NOEXISTE = 0;
		
		#endregion Constantes
		
		/// <summary>
		/// Llena el combo de Centros Operativos
		/// </summary>
		/// 
		private void llenarCentrosOperativo()
		{
			CCentroOperativo oCCentroOperativo = new CCentroOperativo();
			ddlbCentroOperativo.DataSource = oCCentroOperativo.ListarTodosCombo();
			ddlbCentroOperativo.DataValueField=Enumerados.ColumnasCentroOperativo.IdCentroOperativo.ToString();
			ddlbCentroOperativo.DataTextField=Enumerados.ColumnasCentroOperativo.Sigla2.ToString();
			ddlbCentroOperativo.DataBind();
			Item = new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,Utilitario.Constantes.VALORSELECCIONAR);
			ddlbCentroOperativo.Items.Insert(0,Item);
		}

		private void llenarProductoEmbarcacion()
		{
			CProductoEmbarcacion oCProductoEmbarcacion  = new CProductoEmbarcacion();
			ddlbTipoEmbarcacion.DataSource = oCProductoEmbarcacion.ConsultarProductoEmbarcacion();
			ddlbTipoEmbarcacion.DataValueField=Enumerados.ColumnasProductoEmbarcacion.IdProductoEmbarcacion.ToString();
			ddlbTipoEmbarcacion.DataTextField=Enumerados.ColumnasProductoEmbarcacion.Descripcion.ToString();
			ddlbTipoEmbarcacion.DataBind();
			Item = new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,Utilitario.Constantes.VALORSELECCIONAR);
			ddlbTipoEmbarcacion.Items.Insert(0,Item);
		}

		private void LlenarMoneda()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			this.ddlbMoneda.DataSource= oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Utilitario.Enumerados.TablasTabla.Moneda));
			ddlbMoneda.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbMoneda.DataTextField = Enumerados.ColumnasTablaTablas.Var1.ToString();
			ddlbMoneda.DataBind();	
			Item = new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,Utilitario.Constantes.VALORSELECCIONAR);
			ddlbMoneda.Items.Insert(0,Item);
		}

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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add DetalleCostoEmbarcacion.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetalleCostoEmbarcacion.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
		{
			// TODO:  Add DetalleCostoEmbarcacion.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			this.llenarCentrosOperativo();
			this.llenarProductoEmbarcacion();
			this.LlenarMoneda();
		}

		public void LlenarDatos()
		{
			// TODO:  Add DetalleCostoEmbarcacion.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			rfvDescripcion.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONDESCRIPCIONCOSTOEMBARCACION);
			rfvDescripcion.ToolTip      = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONDESCRIPCIONCOSTOEMBARCACION);

			rfvTipoEmbarcacion.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONTIPOEMBARCACIONCOSTOEMBARCACION);
			rfvTipoEmbarcacion.ToolTip      = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONTIPOEMBARCACIONCOSTOEMBARCACION);
			rfvTipoEmbarcacion.InitialValue = Constantes.VALORSELECCIONAR;

			rfvCentroOperativo.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONCENTROOPERATIVOCOSTOEMBARCACION);
			rfvCentroOperativo.ToolTip      = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONCENTROOPERATIVOCOSTOEMBARCACION);
			rfvCentroOperativo.InitialValue = Constantes.VALORSELECCIONAR;

			rfvCosto.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONCOSTOKGCOSTOEMBARCACION);
			rfvCosto.ToolTip      = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONCOSTOKGCOSTOEMBARCACION);

			rfvMoneda.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONMONEDACOSTOEMBARCACION);
			rfvMoneda.ToolTip      = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONMONEDACOSTOEMBARCACION);
			rfvMoneda.InitialValue = Constantes.VALORSELECCIONAR;
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetalleCostoEmbarcacion.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetalleCostoEmbarcacion.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetalleCostoEmbarcacion.Exportar implementation
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
			CostoEmbarcacionBE oCostoEmbarcacionBE    = new CostoEmbarcacionBE();
			oCostoEmbarcacionBE.IdProductoEmbarcacion = Convert.ToInt32(ddlbTipoEmbarcacion.SelectedValue);
			oCostoEmbarcacionBE.IdCentroOperativo     = Convert.ToInt32(ddlbCentroOperativo.SelectedValue);
			oCostoEmbarcacionBE.Descripcion           = txtDescripcion.Text;
			oCostoEmbarcacionBE.CostoAproximado       = Convert.ToDouble(nbCosto.Text);

			oCostoEmbarcacionBE.IdTablaMoneda         = Convert.ToInt32(Enumerados.TablasTabla.Moneda);
			oCostoEmbarcacionBE.IdMoneda              = Convert.ToInt32(ddlbMoneda.SelectedValue);

			oCostoEmbarcacionBE.IdTablaEstado         = Convert.ToInt32(Enumerados.TablasTabla.EstadosCostoEmbarcacion);
			oCostoEmbarcacionBE.IdEstado              = Convert.ToInt32(Enumerados.EstadoCostoEmbarcacion.Activo);
			oCostoEmbarcacionBE.IdUsuarioRegistro     = CNetAccessControl.GetIdUser();
			
			CMantenimientos oCMantenimientos = new CMantenimientos();
			
			// Chequear Existencia Embarcacion
			if (ExisteCostoEmbarcacion(oCostoEmbarcacionBE.IdProductoEmbarcacion, oCostoEmbarcacionBE.IdCentroOperativo)==0)
			{
				int retorno = oCMantenimientos.Insertar(oCostoEmbarcacionBE);

				if(retorno>0)
				{
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestión Comercial:Inf. Comercial",this.ToString(),"Se registró el Costo Embarcacion Nro. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));
					ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionComercial.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONREGISTROCOSTOEMBARCACION));
				}
			}
			else
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesErrorComercialUsuario(Mensajes.CODIGOMENSAJEERRORCOSTOEMBARCACION));
			}
		}

		public void Modificar()
		{
			CostoEmbarcacionBE oCostoEmbarcacionBE    = new CostoEmbarcacionBE();
			oCostoEmbarcacionBE.IdProductoEmbarcacion = Convert.ToInt32(ddlbTipoEmbarcacion.SelectedValue);
			oCostoEmbarcacionBE.IdCentroOperativo     = Convert.ToInt32(ddlbCentroOperativo.SelectedValue);

			oCostoEmbarcacionBE.Descripcion           = txtDescripcion.Text;
			oCostoEmbarcacionBE.CostoAproximado       = Convert.ToDouble(nbCosto.Text);

			oCostoEmbarcacionBE.IdTablaMoneda         = Convert.ToInt32(Enumerados.TablasTabla.Moneda);
			oCostoEmbarcacionBE.IdMoneda              = Convert.ToInt32(ddlbMoneda.SelectedValue);

			oCostoEmbarcacionBE.IdTablaEstado         = Convert.ToInt32(Enumerados.TablasTabla.EstadosCostoEmbarcacion);
			oCostoEmbarcacionBE.IdEstado              = Convert.ToInt32(Enumerados.EstadoCostoEmbarcacion.Activo);
			oCostoEmbarcacionBE.IdUsuarioRegistro     = CNetAccessControl.GetIdUser();

			CMantenimientos oCMantenimientos = new CMantenimientos();
			if(oCMantenimientos.Modificar(oCostoEmbarcacionBE)>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestión Comercial:Inf. Comercial",this.ToString(),"Se modificó El Costo Embarcacion Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));
				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionComercial.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONMODIFICACIONCOSTOEMBARCACION));
			}
		}

		public void Eliminar()
		{
			// TODO:  Add DetalleCostoEmbarcacion.Eliminar implementation
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

			ddlbTipoEmbarcacion.Enabled = true;
			ddlbCentroOperativo.Enabled = true;
		}

		public void CargarModoModificar()
		{
			this.TdCeldaCancelar.Visible = false;
			lblTitulo.Text = TITULOMODOMODIFICAR;
			this.LlenarCombos();
			
			CCostoEmbarcacion oCCostoEmbarcacion = new CCostoEmbarcacion();
			CostoEmbarcacionBE oCostoEmbarcacionBE = (CostoEmbarcacionBE) oCCostoEmbarcacion.ConsultarDetalleCostoEmbarcacion(Convert.ToInt32(Page.Request.Params[KEYQID]),Convert.ToInt32(Page.Request.Params[KEYQID1]));

			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial:Inf.Comercial",this.ToString(),"Se consultó el Detalle del Costo Embarcacion " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

			if(oCostoEmbarcacionBE!=null)
			{
				txtDescripcion.Text = oCostoEmbarcacionBE.Descripcion.ToString();
				ddlbTipoEmbarcacion.Items.FindByValue(oCostoEmbarcacionBE.IdProductoEmbarcacion.ToString()).Selected = true;
				ddlbCentroOperativo.Items.FindByValue(oCostoEmbarcacionBE.IdCentroOperativo.ToString()).Selected = true;
				ddlbMoneda.Items.FindByValue(oCostoEmbarcacionBE.IdMoneda.ToString()).Selected = true;
				nbCosto.Text       = oCostoEmbarcacionBE.CostoAproximado.ToString();
			}

			ddlbTipoEmbarcacion.Enabled = false;
			ddlbCentroOperativo.Enabled = false;
		}

		public void CargarModoConsulta()
		{
			CellibtnCancelar.Visible = false;

			lblTitulo.Text = TITULOMODOCONSULTA;
			this.LlenarCombos();
			
			CCostoEmbarcacion oCCostoEmbarcacion = new CCostoEmbarcacion();
			CostoEmbarcacionBE oCostoEmbarcacionBE = (CostoEmbarcacionBE) oCCostoEmbarcacion.ConsultarDetalleCostoEmbarcacion(Convert.ToInt32(Page.Request.Params[KEYQID]),Convert.ToInt32(Page.Request.Params[KEYQID1]));

			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial:Inf.Comercial",this.ToString(),"Se consultó el Detalle del Costo Embarcacion " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

			if(oCostoEmbarcacionBE!=null)
			{
				txtDescripcion.Text = oCostoEmbarcacionBE.Descripcion.ToString();
				ddlbTipoEmbarcacion.Items.FindByValue(oCostoEmbarcacionBE.IdProductoEmbarcacion.ToString()).Selected = true;
				ddlbCentroOperativo.Items.FindByValue(oCostoEmbarcacionBE.IdCentroOperativo.ToString()).Selected = true;
				ddlbMoneda.Items.FindByValue(oCostoEmbarcacionBE.IdMoneda.ToString()).Selected = true;
				nbCosto.Text       = oCostoEmbarcacionBE.CostoAproximado.ToString();
			}
			Helper.BloquearControles(this);
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
			if(txtDescripcion.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONDESCRIPCIONCOSTOEMBARCACION));
				return false;		
			}

			if(ddlbTipoEmbarcacion.SelectedItem.Text == Constantes.TEXTOSSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONTIPOEMBARCACIONCOSTOEMBARCACION));
				return false;		
			}

			if(ddlbCentroOperativo.SelectedItem.Text == Constantes.TEXTOSSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONCENTROOPERATIVOCOSTOEMBARCACION));
				return false;		
			}

			if(nbCosto.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONCOSTOKGCOSTOEMBARCACION));
				return false;		
			}

			if(ddlbMoneda.SelectedItem.Text == Constantes.TEXTOSSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONMONEDACOSTOEMBARCACION));
				return false;		
			}

			return true;
		}

		public bool ValidarExpresionesRegulares()
		{
			if(!ExpresionesRegulares.ValidarExpresionRegularNumericosPositivos(Server.HtmlEncode(nbCosto.Text)))
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesErrorComercialUsuario(Mensajes.CODIGOMENSAJEERRORCOSTOCOSTOEMBARCACION));
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

		private int ExisteCostoEmbarcacion(int idprod, int idco)
		{
			CCostoEmbarcacion oCCostoEmbarcacion = new CCostoEmbarcacion();
			if (oCCostoEmbarcacion.ChequearExistenciaCostoEmbarcacion(idprod, idco)>0)
				return EXISTE;
			else
				return NOEXISTE;
		}
	}
}