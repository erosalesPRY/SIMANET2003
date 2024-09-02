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
	/// Summary description for DetalleCostoManoObra.
	/// </summary>
	public class DetalleCostoManoObra: System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		#region Controles

		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblDatos;
		protected System.Web.UI.WebControls.Label lblCosto;
		protected System.Web.UI.WebControls.Label lblDescripcion;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblMoneda;
		protected System.Web.UI.WebControls.Label lblManoObra;
		protected System.Web.UI.WebControls.Label lblCO;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvDestino;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvMoneda;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvCosto;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvDescripcion;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvTipoManoObra;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvCentroOperativo;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.DropDownList ddlbMoneda;
		protected System.Web.UI.WebControls.DropDownList ddlbCentroOperativo;
		protected System.Web.UI.WebControls.DropDownList ddlbManoObra;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary vSum;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellibtnAtras;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlbManoObra;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlbCentroOperativo;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlbMoneda;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellibtnCancelar;
		protected eWorld.UI.NumericBox nbCosto;
		private   ListItem Item =  new ListItem();

		#endregion Controles

		#region Constantes
		
		//Titulos 
		const string TITULOMODONUEVO = "NUEVO COSTO DE MANO DE OBRA";
		const string TITULOMODOMODIFICAR = "ACTUALIZACION DE COSTO DE MANO DE OBRA";
		const string TITULOMODOCONSULTA = "CONSULTA DE MANO DE OBRA";

		//Key Session y QueryString
		const string KEYQID  = "IdManoObra";
		const string KEYQID1 = "IdCentroOperativo";
	
		//Otros
		const int EXISTE = 1;
		const int NOEXISTE = 0;
		
		#endregion Constantes
		
		private void llenarManoObra()
		{
			CManoObra oCManoObra = new CManoObra();
			ddlbManoObra.DataSource = oCManoObra.ConsultarManoObra();
			ddlbManoObra.DataValueField = Enumerados.ColumnasManoObra.IdManoObra.ToString();
			ddlbManoObra.DataTextField  = Enumerados.ColumnasManoObra.Descripcion.ToString();
			ddlbManoObra.DataBind();
			Item = new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,Utilitario.Constantes.VALORSELECCIONAR);
			ddlbManoObra.Items.Insert(0,Item);
		}

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

		private void llenarMoneda()
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
			// TODO:  Add DetalleCostoManoObra.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetalleCostoManoObra.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
		{
			// TODO:  Add DetalleCostoManoObra.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			this.llenarManoObra();
			this.llenarCentrosOperativo();
			this.llenarMoneda();
		}

		public void LlenarDatos()
		{
			// TODO:  Add DetalleCostoManoObra.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			rfvTipoManoObra.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONTIPOMANOOBRACOSTOMANOOBRA);
			rfvTipoManoObra.ToolTip      = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONTIPOMANOOBRACOSTOMANOOBRA);
			rfvTipoManoObra.InitialValue = Constantes.VALORSELECCIONAR;

			rfvCentroOperativo.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONCENTROOPERATIVOCOSTOMANOOBRA);
			rfvCentroOperativo.ToolTip      = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONCENTROOPERATIVOCOSTOMANOOBRA);
			rfvCentroOperativo.InitialValue = Constantes.VALORSELECCIONAR;

			rfvCosto.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONCOSTOCOSTOMANOOBRA);
			rfvCosto.ToolTip      = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONCOSTOCOSTOMANOOBRA);

			rfvMoneda.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONMONEDACOSTOMANOOBRA);
			rfvMoneda.ToolTip      = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONMONEDACOSTOMANOOBRA);
			rfvMoneda.InitialValue = Constantes.VALORSELECCIONAR;

			rfvDescripcion.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONDESCRIPCIONCOSTOMANOOBRA);
			rfvDescripcion.ToolTip      = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONDESCRIPCIONCOSTOMANOOBRA);
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetalleCostoManoObra.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetalleCostoManoObra.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetalleCostoManoObra.Exportar implementation
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
			CostoManoObraBE oCostoManoObraBE = new CostoManoObraBE();
			oCostoManoObraBE.IdManoObra        = Convert.ToInt32(ddlbManoObra.SelectedValue);
			oCostoManoObraBE.IdCentroOperativo = Convert.ToInt32(ddlbCentroOperativo.SelectedValue);
			oCostoManoObraBE.Costo             = Convert.ToDouble(nbCosto.Text);
			oCostoManoObraBE.Descripcion       = txtDescripcion.Text;

			oCostoManoObraBE.IdTablaMoneda     = Convert.ToInt32(Enumerados.TablasTabla.Moneda);
			oCostoManoObraBE.IdMoneda          = Convert.ToInt32(ddlbMoneda.SelectedValue);
			oCostoManoObraBE.IdTablaEstado     = Convert.ToInt32(Enumerados.TablasTabla.EstadosCostoManoObra);
			oCostoManoObraBE.IdEstado          = Convert.ToInt32(Enumerados.EstadoCostoManoObra.Activo);
			oCostoManoObraBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();

			// Chequear Existencia de Costo de Mano de Obra
			if (this.ExisteCostoManoObra(oCostoManoObraBE.IdManoObra, oCostoManoObraBE.IdCentroOperativo)==NOEXISTE)
			{
				CMantenimientos oCMantenimientos = new CMantenimientos();
				int retorno = oCMantenimientos.Insertar(oCostoManoObraBE);
				if(retorno>0)
				{
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial : Inf. Comercial",this.ToString(),"Se registró el Costo de Mano de Obra Nro. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));

					ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionComercial.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONREGISTROCOSTOMANOOBRA));
				}
			}
			else
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesErrorComercialUsuario(Mensajes.CODIGOMENSAJEERRORCOSTOMANOOBRA));
			}
		}

		public void Modificar()
		{
			CostoManoObraBE oCostoManoObraBE = new CostoManoObraBE();
			oCostoManoObraBE.IdManoObra             = Convert.ToInt32(ddlbManoObra.SelectedValue);
			oCostoManoObraBE.IdCentroOperativo      = Convert.ToInt32(ddlbCentroOperativo.SelectedValue);
			oCostoManoObraBE.Costo                  = Convert.ToDouble(nbCosto.Text);
			oCostoManoObraBE.Descripcion            = txtDescripcion.Text;

			oCostoManoObraBE.IdTablaMoneda          = Convert.ToInt32(Enumerados.TablasTabla.Moneda);
			oCostoManoObraBE.IdMoneda               = Convert.ToInt32(ddlbMoneda.SelectedValue);

			oCostoManoObraBE.IdUsuarioActualizacion = CNetAccessControl.GetIdUser();
			oCostoManoObraBE.IdTablaEstado          = Convert.ToInt32(Enumerados.TablasTabla.EstadosCostoManoObra);
			oCostoManoObraBE.IdEstado               = Convert.ToInt32(Enumerados.EstadoCostoManoObra.Modificado);

			CMantenimientos oCMantenimientos = new CMantenimientos();
			if(oCMantenimientos.Modificar(oCostoManoObraBE)>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial:Inf. Comercial",this.ToString(),"Se modificó el Costo de Mano de Obra Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));
				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionComercial.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONMODIFICACIONCOSTOMANOOBRA));
			}
		}

		public void Eliminar()
		{
			// TODO:  Add DetalleCostoManoObra.Eliminar implementation
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
			
			ddlbManoObra.Enabled = true;
			ddlbCentroOperativo.Enabled = true;
		}

		public void CargarModoModificar()
		{
			this.CellibtnAtras.Visible = false;
			lblTitulo.Text = TITULOMODOMODIFICAR;
			this.LlenarCombos();

			CCostoManoObra oCCostoManoObra = new CCostoManoObra();
			CostoManoObraBE oCostoManoObraBE = (CostoManoObraBE) oCCostoManoObra.ConsultarDetalleCostoManoObra(Convert.ToInt32(Page.Request.Params[KEYQID]), Convert.ToInt32(Page.Request.Params[KEYQID1]));
			
			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial:Inf.Comercial",this.ToString(),"Se consultó el Detalle del Costo de Mano de Obra " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

			if(oCostoManoObraBE!=null)
			{
				ddlbManoObra.Items.FindByValue(oCostoManoObraBE.IdManoObra.ToString()).Selected = true;
				ddlbCentroOperativo.Items.FindByValue(oCostoManoObraBE.IdCentroOperativo.ToString()).Selected = true;
				ddlbMoneda.Items.FindByValue(oCostoManoObraBE.IdMoneda.ToString()).Selected = true;
				txtDescripcion.Text = oCostoManoObraBE.Descripcion.ToString();
				nbCosto.Text       = oCostoManoObraBE.Costo.ToString();
			}

			ddlbManoObra.Enabled = false;
			ddlbCentroOperativo.Enabled = false;
		}

		public void CargarModoConsulta()
		{
			this.CellibtnCancelar.Visible = false;
			lblTitulo.Text = TITULOMODOCONSULTA;
			this.LlenarCombos();

			CCostoManoObra oCCostoManoObra = new CCostoManoObra();
			CostoManoObraBE oCostoManoObraBE = (CostoManoObraBE) oCCostoManoObra.ConsultarDetalleCostoManoObra(Convert.ToInt32(Page.Request.Params[KEYQID]), Convert.ToInt32(Page.Request.Params[KEYQID1]));
			
			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial:Inf.Comercial",this.ToString(),"Se consultó el Detalle del Costo Mano de Obra " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

			if(oCostoManoObraBE!=null)
			{
				ddlbManoObra.Items.FindByValue(oCostoManoObraBE.IdManoObra.ToString()).Selected = true;
				ddlbCentroOperativo.Items.FindByValue(oCostoManoObraBE.IdCentroOperativo.ToString()).Selected = true;
				ddlbMoneda.Items.FindByValue(oCostoManoObraBE.IdMoneda.ToString()).Selected = true;
				txtDescripcion.Text = oCostoManoObraBE.Descripcion.ToString();
				nbCosto.Text       = oCostoManoObraBE.Costo.ToString();
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
			if(ddlbManoObra.SelectedItem.Text == Constantes.TEXTOSSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONTIPOMANOOBRACOSTOMANOOBRA));
				return false;		
			}

			if(ddlbCentroOperativo.SelectedItem.Text == Constantes.TEXTOSSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONCENTROOPERATIVOCOSTOMANOOBRA));
				return false;		
			}

			if(ddlbMoneda.SelectedItem.Text == Constantes.TEXTOSSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONMONEDACOSTOMANOOBRA));
				return false;		
			}

			if(nbCosto.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONCOSTOCOSTOMANOOBRA));
				return false;		
			}

			if(txtDescripcion.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONDESCRIPCIONCOSTOMANOOBRA));
				return false;		
			}

			return true;
		}

		public bool ValidarExpresionesRegulares()
		{
			if(!ExpresionesRegulares.ValidarExpresionRegularNumericosPositivos(Server.HtmlEncode(nbCosto.Text)))
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesErrorComercialUsuario(Mensajes.CODIGOMENSAJEERRORCOSTOCOSTOMANOOBRA));
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

		private int ExisteCostoManoObra(int idmo, int idco)
		{
			CCostoManoObra oCCostoManoObra = new CCostoManoObra();
			if (oCCostoManoObra.ChequearExistenciaCostoManoObra(idmo, idco)>0)
				return EXISTE;
			else
				return NOEXISTE;
		}
	}
}