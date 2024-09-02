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
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using SIMA.EntidadesNegocio.GestionComercial;
using NetAccessControl;


namespace SIMA.SimaNetWeb.GestionComercial.InformacionComercial
{
	/// <summary>
	/// Summary description for DetalleProductoEmbarcacion.
	/// </summary>
	public class DetalleProductoEmbarcacion : System.Web.UI.Page,IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblDatos;
		protected System.Web.UI.WebControls.Literal ltlMensaje;

		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.Label lblMensaje;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvPesoEslora;
		protected System.Web.UI.WebControls.TextBox txtPesoEslora;
		protected System.Web.UI.WebControls.Label lblPesoEslora;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvTipoEmbarcacion;
		protected System.Web.UI.WebControls.DropDownList ddlbTipoEmbarcacion;
		protected System.Web.UI.WebControls.Label lblTipoEmbarcacion;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvPesoPuntal;
		protected System.Web.UI.WebControls.TextBox txtPesoPuntal;
		protected System.Web.UI.WebControls.Label lblPesoPuntal;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvPesoManga;
		protected System.Web.UI.WebControls.TextBox txtPesoManga;
		protected System.Web.UI.WebControls.Label lblPesoManga;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvCoeficiente;
		protected System.Web.UI.WebControls.TextBox txtCoeficiente;
		protected System.Web.UI.WebControls.Label lblCoeficiente;
		protected System.Web.UI.WebControls.Label lblDescripcion;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvDescripcion;
		protected System.Web.UI.WebControls.Label lblUnidaddeMedida;
		protected System.Web.UI.WebControls.DropDownList ddlbUnidadMedida;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvUnidadMedida;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary vSum;
		private   ListItem item =  new ListItem();
		#endregion Controles

		#region Constantes
		
		//Titulos 
		const string TITULOMODONUEVO = "NUEVO PRODUCTO EMBARCACION";
		const string TITULOMODOMODIFICAR = "PRODUCTO EMBARCACION";

		//Key Session y QueryString
		const string KEYQID = "Id";

		#endregion Constantes

		private void llenarTiposEmbarcacion()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			this.ddlbTipoEmbarcacion.DataSource= oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Utilitario.Enumerados.TablasTabla.TipoEmbarcacion));
			ddlbTipoEmbarcacion.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbTipoEmbarcacion.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbTipoEmbarcacion.DataBind();	
			item = new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,Utilitario.Constantes.VALORSELECCIONAR);
			ddlbTipoEmbarcacion.Items.Insert(0,item);
		}

		private void llenarUnidadesMedida()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			this.ddlbUnidadMedida.DataSource= oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Utilitario.Enumerados.TablasTabla.TiposUnidadesMedida));
			ddlbUnidadMedida.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbUnidadMedida.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbUnidadMedida.DataBind();	
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
			// TODO:  Add DetalleProductoEmbarcacion.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetalleProductoEmbarcacion.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
		{
			// TODO:  Add DetalleProductoEmbarcacion.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			this.llenarTiposEmbarcacion();
			this.llenarUnidadesMedida();
		}

		public void LlenarDatos()
		{
			// TODO:  Add DetalleProductoEmbarcacion.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			rfvDescripcion.ErrorMessage  = Helper.ObtenerMensajesConfirmacionComercialUsuario(Utilitario.Mensajes.CODIGOMENSAJECONFIRMACIONDESCRIPCIONPRODUCTOEMBARCACION);
			rfvDescripcion.ToolTip       = rfvDescripcion.ErrorMessage;

			rfvTipoEmbarcacion.ErrorMessage  = Helper.ObtenerMensajesConfirmacionComercialUsuario(Utilitario.Mensajes.CODIGOMENSAJECONFIRMACIONTIPOEMBARCACIONPRODUCTOEMBARCACION);
			rfvTipoEmbarcacion.ToolTip       = rfvCoeficiente.ErrorMessage;

			rfvPesoEslora.ErrorMessage   = Helper.ObtenerMensajesConfirmacionComercialUsuario(Utilitario.Mensajes.CODIGOMENSAJECONFIRMACIONESLORAPRODUCTOEMBARCACION);
			rfvPesoEslora.ToolTip        = rfvPesoEslora.ErrorMessage;

			rfvPesoManga.ErrorMessage    = Helper.ObtenerMensajesConfirmacionComercialUsuario(Utilitario.Mensajes.CODIGOMENSAJECONFIRMACIONMANGAPRODUCTOEMBARCACION);
			rfvPesoManga.ToolTip         = rfvPesoManga.ErrorMessage;
			
			rfvPesoPuntal.ErrorMessage   = Helper.ObtenerMensajesConfirmacionComercialUsuario(Utilitario.Mensajes.CODIGOMENSAJECONFIRMACIONPUNTALPRODUCTOEMBARCACION);
			rfvPesoPuntal.ToolTip        = rfvPesoPuntal.ErrorMessage;

			rfvCoeficiente.ErrorMessage  = Helper.ObtenerMensajesConfirmacionComercialUsuario(Utilitario.Mensajes.CODIGOMENSAJECONFIRMACIONCOEFICIENTEPRODUCTOEMBARCACION);
			rfvCoeficiente.ToolTip       = rfvCoeficiente.ErrorMessage;

			rfvUnidadMedida.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Utilitario.Mensajes.CODIGOMENSAJECONFIRMACIONUNIDADMEDIDAAMATERIAL);
			rfvUnidadMedida.ToolTip      = rfvUnidadMedida.ErrorMessage;
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetalleProductoEmbarcacion.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetalleProductoEmbarcacion.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetalleProductoEmbarcacion.Exportar implementation
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
			ProductoEmbarcacionBE oProductoEmbarcacionBE = new ProductoEmbarcacionBE();
			oProductoEmbarcacionBE.Descripcion     = txtDescripcion.Text;
			oProductoEmbarcacionBE.IdTipo          = Convert.ToInt32(ddlbTipoEmbarcacion.SelectedValue);
			oProductoEmbarcacionBE.IdUnidadMedida  = Convert.ToInt32(ddlbUnidadMedida.SelectedValue);
			oProductoEmbarcacionBE.Coeficiente     = Convert.ToDouble(txtCoeficiente.Text);
			oProductoEmbarcacionBE.PesoEslora      = Convert.ToDouble(txtPesoEslora.Text);
			oProductoEmbarcacionBE.PesoManga       = Convert.ToDouble(txtPesoManga.Text);
			oProductoEmbarcacionBE.PesoPuntal      = Convert.ToDouble(txtPesoPuntal.Text);
			oProductoEmbarcacionBE.PesoEmbarcacion = oProductoEmbarcacionBE.PesoEslora*oProductoEmbarcacionBE.PesoManga*oProductoEmbarcacionBE.PesoPuntal*oProductoEmbarcacionBE.Coeficiente;


			oProductoEmbarcacionBE.IdTablaTipo         = Convert.ToInt32(Enumerados.TablasTabla.TipoEmbarcacion);
			oProductoEmbarcacionBE.IdTablaUnidadMedida = Convert.ToInt32(Enumerados.TablasTabla.TiposUnidadesMedida);

			oProductoEmbarcacionBE.IdTablaEstado       = Convert.ToInt32(Enumerados.TablasTabla.EstadosProductoEmbarcacion);
			oProductoEmbarcacionBE.IdEstado            = Convert.ToInt32(Enumerados.EstadoProductoEmbarcacion.Activo);
			oProductoEmbarcacionBE.IdUsuarioRegistro   = CNetAccessControl.GetIdUser();
			
			CMantenimientos oCMantenimientos = new CMantenimientos();

			int retorno = oCMantenimientos.Insertar(oProductoEmbarcacionBE);

			if(retorno>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial : Inf. Comercial",this.ToString(),"Se registró el Producto Embarcacion Nro. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));

				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionComercial.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONREGISTROPRODUCTOEMBARCACION));
			}
		}

		public void Modificar()
		{
			ProductoEmbarcacionBE oProductoEmbarcacionBE = new ProductoEmbarcacionBE();
			oProductoEmbarcacionBE.IdProductoEmbarcacion = Convert.ToInt32(Page.Request.QueryString[KEYQID]);
			oProductoEmbarcacionBE.Descripcion     = txtDescripcion.Text;
			oProductoEmbarcacionBE.IdTipo          = Convert.ToInt32(ddlbTipoEmbarcacion.SelectedValue);
			oProductoEmbarcacionBE.IdUnidadMedida  = Convert.ToInt32(ddlbUnidadMedida.SelectedValue);
			oProductoEmbarcacionBE.Coeficiente     = Convert.ToDouble(txtCoeficiente.Text);
			oProductoEmbarcacionBE.PesoEslora      = Convert.ToDouble(txtPesoEslora.Text);
			oProductoEmbarcacionBE.PesoManga       = Convert.ToDouble(txtPesoManga.Text);
			oProductoEmbarcacionBE.PesoPuntal      = Convert.ToDouble(txtPesoPuntal.Text);
			oProductoEmbarcacionBE.PesoEmbarcacion = oProductoEmbarcacionBE.PesoEslora*oProductoEmbarcacionBE.PesoManga*oProductoEmbarcacionBE.PesoPuntal*oProductoEmbarcacionBE.Coeficiente;

			oProductoEmbarcacionBE.IdTablaTipo         = Convert.ToInt32(Enumerados.TablasTabla.TipoEmbarcacion);
			oProductoEmbarcacionBE.IdTablaUnidadMedida = Convert.ToInt32(Enumerados.TablasTabla.TiposUnidadesMedida);

			oProductoEmbarcacionBE.IdUsuarioActualizacion = CNetAccessControl.GetIdUser();
			oProductoEmbarcacionBE.IdTablaEstado          = Convert.ToInt32(Enumerados.TablasTabla.EstadosProductoEmbarcacion);
			oProductoEmbarcacionBE.IdEstado               = Convert.ToInt32(Enumerados.EstadoProductoEmbarcacion.Modificado);

			CMantenimientos oCMantenimientos = new CMantenimientos();
			if(oCMantenimientos.Modificar(oProductoEmbarcacionBE)>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial:Inf. Comercial",this.ToString(),"Se modificó el Producto Embarcacion Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionComercial.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONMODIFICACIONPRODUCTOEMBARCACION));
			
			}
		}

		public void Eliminar()
		{
			// TODO:  Add DetalleProductoEmbarcacion.Eliminar implementation
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
			ProductoEmbarcacionBE oProductoEmbarcacionBE = (ProductoEmbarcacionBE) oCMantenimientos.ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYQID]),Enumerados.ClasesNTAD.ProductoEmbarcacionNTAD.ToString());
			
			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial:Inf.Comercial",this.ToString(),"Se consultó el Detalle del Producto Informacion " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

			if(oProductoEmbarcacionBE!=null)
			{
				txtDescripcion.Text = oProductoEmbarcacionBE.Descripcion.ToString();
				ddlbTipoEmbarcacion.Items.FindByValue(oProductoEmbarcacionBE.IdTipo.ToString()).Selected = true;
				ddlbUnidadMedida.Items.FindByValue(oProductoEmbarcacionBE.IdUnidadMedida.ToString()).Selected = true;
				txtCoeficiente.Text = oProductoEmbarcacionBE.Coeficiente.ToString(Constantes.FORMATODECIMAL4);
				txtPesoEslora.Text  = oProductoEmbarcacionBE.PesoEslora.ToString(Constantes.FORMATODECIMAL4);
				txtPesoManga.Text   = oProductoEmbarcacionBE.PesoManga.ToString(Constantes.FORMATODECIMAL4);
				txtPesoPuntal.Text  = oProductoEmbarcacionBE.PesoPuntal.ToString(Constantes.FORMATODECIMAL4);

			}
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add DetalleProductoEmbarcacion.CargarModoConsulta implementation
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
			if(ddlbTipoEmbarcacion.SelectedItem.Text == Constantes.TEXTOSSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONTIPOEMBARCACIONPRODUCTOEMBARCACION));
				return false;		
			}

			if(ddlbUnidadMedida.SelectedItem.Text == Constantes.TEXTOSSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Utilitario.Mensajes.CODIGOMENSAJECONFIRMACIONUNIDADMEDIDAAMATERIAL));
				return false;		
			}

			
			if(txtDescripcion.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Utilitario.Mensajes.CODIGOMENSAJECONFIRMACIONDESCRIPCIONPRODUCTOEMBARCACION));
				return false;		
			}

			if(txtCoeficiente.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Utilitario.Mensajes.CODIGOMENSAJECONFIRMACIONCOEFICIENTEPRODUCTOEMBARCACION));
				return false;		
			}


			if(txtPesoEslora.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Utilitario.Mensajes.CODIGOMENSAJECONFIRMACIONESLORAPRODUCTOEMBARCACION));
				return false;		
			}

			if(txtPesoManga.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Utilitario.Mensajes.CODIGOMENSAJECONFIRMACIONMANGAPRODUCTOEMBARCACION));
				return false;		
			}

			if(txtPesoPuntal.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Utilitario.Mensajes.CODIGOMENSAJECONFIRMACIONPUNTALPRODUCTOEMBARCACION));
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
	}
}
