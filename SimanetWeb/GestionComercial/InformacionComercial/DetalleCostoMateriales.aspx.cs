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
using SIMA.Controladoras.General;
using SIMA.Controladoras.GestionComercial;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using SIMA.EntidadesNegocio.GestionComercial;
using NetAccessControl;

namespace SIMA.SimaNetWeb.GestionComercial.InformacionComercial
{
	/// <summary>
	/// Summary description for DetalleCostoMateriales.
	/// </summary>
	public class DetalleCostoMateriales: System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		#region Controles

		protected System.Web.UI.WebControls.Label lblTipoEmbarcacion;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblMensaje;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblDatos;
		protected System.Web.UI.WebControls.Label lblTipoMaterial;
		protected System.Web.UI.WebControls.DropDownList ddlbTipoMaterial;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvTipoMaterial;
		protected System.Web.UI.WebControls.Label lblCentroOperativo;
		protected System.Web.UI.WebControls.DropDownList ddlbCentroOperativo;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvCentroOperativo;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DropDownList ddlbUbigeo;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvUbigeo;
		protected System.Web.UI.WebControls.Label lblCosto;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvCosto;
		protected System.Web.UI.WebControls.Label lblMoneda;
		protected System.Web.UI.WebControls.DropDownList ddlbMoneda;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvMoneda;
		protected System.Web.UI.WebControls.Label lblDescripcion;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvDescripcion;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary vSum;
		protected eWorld.UI.NumericBox nbCosto;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellibtnAtras;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellibtnCancelar;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlbTipoMaterial;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlbCentroOperativo;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlbUbigeo;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlbMoneda;
		private   ListItem Item =  new ListItem();
		#endregion Controles

		#region Constantes
		//Titulos 
		const string TITULOMODONUEVO = "NUEVO COSTO DE MATERIAL";
		const string TITULOMODOMODIFICAR = "COSTO DE MATERIAL";
		const string TITULOMODOCONSULTA = "REGISTRO DE COSTO DE MATERIAL";

		//Key Session y QueryString
		const string KEYQID = "IdMaterial";
		const string KEYQID1 = "IdCentroOperativo";
		const string KEYQID2 = "IdUbigeo";
	
		//Otros
		const int EXISTE   = 1;
		const int NOEXISTE = 0;

		#endregion Constantes
		
		private void llenarTipoMaterial()
		{
			CMaterial oCMaterial = new CMaterial();
			ddlbTipoMaterial.DataSource     = oCMaterial.BusquedaMaterial();
			ddlbTipoMaterial.DataValueField = Enumerados.ColumnasMaterial.IdMaterial.ToString();
			ddlbTipoMaterial.DataTextField  = Enumerados.ColumnasMaterial.Descripcion.ToString();
			ddlbTipoMaterial.DataBind();
			Item = new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,Utilitario.Constantes.VALORSELECCIONAR);
			ddlbTipoMaterial.Items.Insert(0,Item);
		}

		private void llenarCentrosOperativo()
		{
			CCentroOperativo oCCentroOperativo = new CCentroOperativo();
			ddlbCentroOperativo.DataSource     = oCCentroOperativo.ListarTodosCombo();
			ddlbCentroOperativo.DataValueField = Enumerados.ColumnasCentroOperativo.IdCentroOperativo.ToString();
			ddlbCentroOperativo.DataTextField  = Enumerados.ColumnasCentroOperativo.Sigla2.ToString();
			ddlbCentroOperativo.DataBind();
			Item = new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,Utilitario.Constantes.VALORSELECCIONAR);
			ddlbCentroOperativo.Items.Insert(0,Item);
		}

		private void LlenarMoneda()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			this.ddlbMoneda.DataSource = oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Utilitario.Enumerados.TablasTabla.Moneda));
			ddlbMoneda.DataValueField  = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbMoneda.DataTextField   = Enumerados.ColumnasTablaTablas.Var1.ToString();
			ddlbMoneda.DataBind();	
			Item = new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,Utilitario.Constantes.VALORSELECCIONAR);
			ddlbMoneda.Items.Insert(0,Item);
		}

		private void llenarUbigeo()
		{
			CUbigeo oCUbigeo          = new CUbigeo();
			ddlbUbigeo.DataSource     = oCUbigeo.ListaTodosCombo();
			ddlbUbigeo.DataValueField = Enumerados.ColumnasUbigeo.IdUbigeo.ToString();
			ddlbUbigeo.DataTextField  = Enumerados.ColumnasUbigeo.NombreProvincia.ToString();
			ddlbUbigeo.DataBind();
			Item = new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,Utilitario.Constantes.VALORSELECCIONAR);
			ddlbUbigeo.Items.Insert(0,Item);
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
			// TODO:  Add DetalleCostoMateriales.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetalleCostoMateriales.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
		{
			// TODO:  Add DetalleCostoMateriales.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			this.llenarTipoMaterial();
			this.llenarCentrosOperativo();
			this.LlenarMoneda();
			this.llenarUbigeo();
		}

		public void LlenarDatos()
		{
			// TODO:  Add DetalleCostoMateriales.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			rfvTipoMaterial.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONTIPOMATERIALCOSTOMATERIAL);
			rfvTipoMaterial.ToolTip      = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONTIPOMATERIALCOSTOMATERIAL);
			rfvTipoMaterial.InitialValue = Constantes.VALORSELECCIONAR;

			rfvCentroOperativo.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONCENTROOPERATIVOCOSTOMATERIAL);
			rfvCentroOperativo.ToolTip      = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONCENTROOPERATIVOCOSTOMATERIAL);
			rfvCentroOperativo.InitialValue = Constantes.VALORSELECCIONAR;

			rfvUbigeo.ErrorMessage = Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONUBIGEOCOSTOMATERIAL));
			rfvUbigeo.ToolTip      = Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONUBIGEOCOSTOMATERIAL));
			rfvUbigeo.InitialValue = Constantes.VALORSELECCIONAR;

			rfvMoneda.ErrorMessage = Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONMONEDACOSTOMATERIAL));
			rfvMoneda.ToolTip      = Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONMONEDACOSTOMATERIAL));
			rfvMoneda.InitialValue = Constantes.VALORSELECCIONAR;
			
			rfvDescripcion.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONDESCRIPCIONCOSTOMATERIAL);
			rfvDescripcion.ToolTip      = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONDESCRIPCIONCOSTOMATERIAL);

			rfvCosto.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONCOSTOCOSTOMATERIAL);
			rfvCosto.ToolTip      = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONCOSTOCOSTOMATERIAL);
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetalleCostoMateriales.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetalleCostoMateriales.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetalleCostoMateriales.Exportar implementation
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
			CostoMaterialesBE oCostoMaterialesBE = new CostoMaterialesBE();
			oCostoMaterialesBE.IdMaterial        = Convert.ToInt32(ddlbTipoMaterial.SelectedValue);
			oCostoMaterialesBE.IdCentroOperativo = Convert.ToInt32(ddlbCentroOperativo.SelectedValue);
			oCostoMaterialesBE.IdUbigeo          = Convert.ToInt32(ddlbUbigeo.SelectedValue);
			oCostoMaterialesBE.Costo             = Convert.ToDouble(nbCosto.Text);
			oCostoMaterialesBE.Descripcion       = txtDescripcion.Text;

			oCostoMaterialesBE.IdTablaMoneda     = Convert.ToInt32(Enumerados.TablasTabla.Moneda);
			oCostoMaterialesBE.IdMoneda          = Convert.ToInt32(ddlbMoneda.SelectedValue);

			oCostoMaterialesBE.IdTablaEstado     = Convert.ToInt32(Enumerados.TablasTabla.EstadosCostoMateriales);
			oCostoMaterialesBE.IdEstado          = Convert.ToInt32(Enumerados.EstadoCostoMaterial.Activo);
			oCostoMaterialesBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();

			// Chequear Existencia de Costo de Material
			if (ExisteCostoMateriales(oCostoMaterialesBE.IdMaterial, oCostoMaterialesBE.IdCentroOperativo, oCostoMaterialesBE.IdUbigeo)==0)
			{
				CMantenimientos oCMantenimientos = new CMantenimientos();
				int retorno = oCMantenimientos.Insertar(oCostoMaterialesBE);

				if(retorno>0)
				{
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial : Inf. Comercial",this.ToString(),"Se registró el Costo de Material Nro. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));

					ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionComercial.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONREGISTROCOSTOMATERIAL));
				}
			}
			else
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesErrorComercialUsuario(Mensajes.CODIGOMENSAJEERRORCOSTOMATERIAL));
			}
		}

		public void Modificar()
		{
			CostoMaterialesBE oCostoMaterialesBE = new CostoMaterialesBE();
			oCostoMaterialesBE.IdMaterial         = Convert.ToInt32(ddlbTipoMaterial.SelectedValue);
			oCostoMaterialesBE.IdCentroOperativo  = Convert.ToInt32(ddlbCentroOperativo.SelectedValue);
			oCostoMaterialesBE.IdUbigeo           = Convert.ToInt32(ddlbUbigeo.SelectedValue);
			oCostoMaterialesBE.Costo              = Convert.ToDouble(nbCosto.Text);
			oCostoMaterialesBE.Descripcion        = txtDescripcion.Text;

			oCostoMaterialesBE.IdTablaMoneda      = Convert.ToInt32(Enumerados.TablasTabla.Moneda);
			oCostoMaterialesBE.IdMoneda           = Convert.ToInt32(ddlbMoneda.SelectedValue);

			oCostoMaterialesBE.IdTablaEstado      = Convert.ToInt32(Enumerados.TablasTabla.EstadosCostoMateriales);
			oCostoMaterialesBE.IdEstado           = Convert.ToInt32(Enumerados.EstadoCostoMaterial.Activo);
			oCostoMaterialesBE.IdUsuarioRegistro  = CNetAccessControl.GetIdUser();

			CMantenimientos oCMantenimientos = new CMantenimientos();
			if(oCMantenimientos.Modificar(oCostoMaterialesBE)>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial:Inf. Comercial",this.ToString(),"Se modificó el Costo de Material Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));
				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionComercial.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONMODIFICACIONCOSTOMATERIAL));
			}
		}

		public void Eliminar()
		{
			// TODO:  Add DetalleCostoMateriales.Eliminar implementation
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
			this.CellibtnAtras.Visible = false;
			lblTitulo.Text = TITULOMODONUEVO;
			this.LlenarCombos();

			ddlbTipoMaterial.Enabled = true;
			ddlbCentroOperativo.Enabled = true;
			ddlbUbigeo.Enabled = true;
		}

		public void CargarModoModificar()
		{
			this.CellibtnAtras.Visible = false;
			lblTitulo.Text = TITULOMODOMODIFICAR;
			this.LlenarCombos();
			
			CCostoMateriales oCCostoMateriales = new CCostoMateriales();
			CostoMaterialesBE oCostoMaterialesBE = (CostoMaterialesBE) oCCostoMateriales.ConsultarDetalleCostoMateriales(Convert.ToInt32(Page.Request.Params[KEYQID]), Convert.ToInt32(Page.Request.Params[KEYQID1]), Convert.ToInt32(Page.Request.Params[KEYQID2]));
			
			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial:Inf.Comercial",this.ToString(),"Se consultó el Detalle del Costo Embarcacion " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

			if(oCostoMaterialesBE!=null)
			{
				ddlbTipoMaterial.Items.FindByValue(oCostoMaterialesBE.IdMaterial.ToString()).Selected = true;
				ddlbCentroOperativo.Items.FindByValue(oCostoMaterialesBE.IdCentroOperativo.ToString()).Selected = true;
				ddlbUbigeo.Items.FindByValue(oCostoMaterialesBE.IdUbigeo.ToString()).Selected = true;
				ddlbMoneda.Items.FindByValue(oCostoMaterialesBE.IdMoneda.ToString()).Selected = true;
				txtDescripcion.Text = oCostoMaterialesBE.Descripcion.ToString();
				nbCosto.Text       = oCostoMaterialesBE.Costo.ToString();
			}
			ddlbTipoMaterial.Enabled = false;
			ddlbCentroOperativo.Enabled = false;
			ddlbUbigeo.Enabled = false;
		}

		public void CargarModoConsulta()
		{
			this.CellibtnCancelar.Visible = false;
			lblTitulo.Text = TITULOMODOCONSULTA;
			this.LlenarCombos();
			
			CCostoMateriales oCCostoMateriales = new CCostoMateriales();
			CostoMaterialesBE oCostoMaterialesBE = (CostoMaterialesBE) oCCostoMateriales.ConsultarDetalleCostoMateriales(Convert.ToInt32(Page.Request.Params[KEYQID]), Convert.ToInt32(Page.Request.Params[KEYQID1]), Convert.ToInt32(Page.Request.Params[KEYQID2]));
			
			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial:Inf.Comercial",this.ToString(),"Se consultó el Detalle del Costo Embarcacion " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

			if(oCostoMaterialesBE!=null)
			{
				ddlbTipoMaterial.Items.FindByValue(oCostoMaterialesBE.IdMaterial.ToString()).Selected = true;
				ddlbCentroOperativo.Items.FindByValue(oCostoMaterialesBE.IdCentroOperativo.ToString()).Selected = true;
				ddlbUbigeo.Items.FindByValue(oCostoMaterialesBE.IdUbigeo.ToString()).Selected = true;
				ddlbMoneda.Items.FindByValue(oCostoMaterialesBE.IdMoneda.ToString()).Selected = true;
				txtDescripcion.Text = oCostoMaterialesBE.Descripcion.ToString();
				nbCosto.Text       = oCostoMaterialesBE.Costo.ToString();
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
			if(ddlbTipoMaterial.SelectedItem.Text == Constantes.TEXTOSSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONTIPOMATERIALCOSTOMATERIAL));
				return false;		
			}

			if(ddlbCentroOperativo.SelectedItem.Text == Constantes.TEXTOSSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONCENTROOPERATIVOCOSTOMATERIAL));
				return false;		
			}

			if(ddlbUbigeo.SelectedItem.Text == Constantes.TEXTOSSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONUBIGEOCOSTOMATERIAL));
				return false;		
			}

			if(ddlbMoneda.SelectedItem.Text == Constantes.TEXTOSSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONMONEDACOSTOMATERIAL));
				return false;		
			}

			if(txtDescripcion.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONDESCRIPCIONCOSTOMATERIAL));
				return false;		
			}

			if(nbCosto.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONCOSTOCOSTOMATERIAL));
				return false;		
			}
			return true;
		}

		public bool ValidarExpresionesRegulares()
		{
			if(!ExpresionesRegulares.ValidarExpresionRegularNumericosPositivos(Server.HtmlEncode(nbCosto.Text)))
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesErrorComercialUsuario(Mensajes.CODIGOMENSAJEERRORCOSTOCOSTOMATERIAL));
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

		private int ExisteCostoMateriales(int idmo, int idco, int idubi)
		{
			CCostoMateriales oCCostoMateriales = new CCostoMateriales();
			if (oCCostoMateriales.ChequearExistenciaCostoMaterial(idmo, idco, idubi)>0)
				return EXISTE;
			else
				return NOEXISTE;
		}
	}
}