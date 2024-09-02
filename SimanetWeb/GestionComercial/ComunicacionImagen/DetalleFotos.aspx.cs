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
	/// Summary description for DetalleFotos.
	/// </summary>
	public class DetalleFotos: System.Web.UI.Page, IPaginaMantenimento, IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblCodigoCaja;
		protected System.Web.UI.WebControls.TextBox txtCodigoCaja;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvCodigoCaja;
		protected System.Web.UI.WebControls.Label lblRutaFisica;
		protected System.Web.UI.WebControls.TextBox txtRutaFisica;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvRutaFisica;
		protected System.Web.UI.WebControls.Label lblFormato;
		protected System.Web.UI.WebControls.DropDownList ddlbFormato;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvFormato;
		protected System.Web.UI.WebControls.Label lblCantidadDeFotos;
		protected eWorld.UI.NumericBox nbCantidadFotos;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvCantidadFotos;
		protected System.Web.UI.WebControls.Label lblDigitalizado;
		protected System.Web.UI.WebControls.CheckBox chkDigitalizado;
		protected System.Web.UI.WebControls.Label lblAvance;
		protected eWorld.UI.NumericBox nbAvance;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvAvance;
		protected System.Web.UI.WebControls.DomValidators.RangeDomValidator rvAvance;
		protected System.Web.UI.WebControls.Label lblDescripcion;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.Label lblObservaciones;
		protected System.Web.UI.WebControls.TextBox txtObservaciones;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary vSum;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlbFormato;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnCancelar;
		protected System.Web.UI.HtmlControls.HtmlTableCell TdCeldaCancelar;
		#endregion Controles
		
		#region Constantes
		
		//Titulos 
		const string TITULOMODONUEVO = "NUEVA FOTO";
		const string TITULOMODOMODIFICAR = "ACTUALIZACION DE FOTO";
		const string TITULOMODOCONSULTA = "DETALLE DE FOTO";

		//Key Session y QueryString
		const string KEYQID = "Id";
		const string KEYQDESCRIPCION = "Descripcion";
		const string KEYTIPO = "Tipo";
		const string KEYQIDFOTO = "IdFoto";
	
		//Paginas
		
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
			FotoBE oFotoBE = new FotoBE();
			oFotoBE.CodigoCaja = this.txtCodigoCaja.Text;
			oFotoBE.RutaFisica = this.txtRutaFisica.Text;
			oFotoBE.IdTablaFormato = Convert.ToInt32(Enumerados.TablasTabla.FormatosFotos);
			oFotoBE.IdFormato = Convert.ToInt32(this.ddlbFormato.SelectedValue);
			oFotoBE.CantidadFotos = Convert.ToInt32(this.nbCantidadFotos.Text);
			oFotoBE.FlgDigitalizado = Convert.ToInt32(this.chkDigitalizado.Checked);
			oFotoBE.PorcentajeAvance = Convert.ToInt32(this.nbAvance.Text);
			if(Page.Request.QueryString[KEYTIPO] == Enumerados.TipoEntidadConFoto.Buque.ToString())
			{
				oFotoBE.IdBuque = Convert.ToInt32(Page.Request.QueryString[KEYQID]);
			}
			else if(Page.Request.QueryString[KEYTIPO] == Enumerados.TipoEntidadConFoto.Visita.ToString())
			{
				oFotoBE.IdVisitas = Convert.ToInt32(Page.Request.QueryString[KEYQID]);
			}
			oFotoBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();
			oFotoBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.EstadosFoto);
			oFotoBE.IdEstado = Convert.ToInt32(Enumerados.EstadosFoto.Activo);
			if(this.txtDescripcion.Text.Trim()!=String.Empty)
			{
				oFotoBE.Descripcion = this.txtDescripcion.Text;
			}
			if(this.txtObservaciones.Text.Trim()!=String.Empty)
			{
				oFotoBE.Observaciones = this.txtObservaciones.Text;
			}

			CMantenimientos oCMantenimientos = new CMantenimientos();
			int retorno = oCMantenimientos.Insertar(oFotoBE);

			if(retorno>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se registró La Foto Nro. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));
				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionComercial.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONREGISTROFOTO));
			}
		}

		public void Modificar()
		{
			FotoBE oFotoBE = new FotoBE();
			oFotoBE.IdCodigoFoto = Convert.ToInt32(Page.Request.QueryString[KEYQIDFOTO]);
			oFotoBE.CodigoCaja = this.txtCodigoCaja.Text;
			oFotoBE.RutaFisica = this.txtRutaFisica.Text;
			oFotoBE.IdTablaFormato = Convert.ToInt32(Enumerados.TablasTabla.FormatosFotos);
			oFotoBE.IdFormato = Convert.ToInt32(this.ddlbFormato.SelectedValue);
			oFotoBE.CantidadFotos = Convert.ToInt32(this.nbCantidadFotos.Text);
			oFotoBE.FlgDigitalizado = Convert.ToInt32(this.chkDigitalizado.Checked);
			oFotoBE.PorcentajeAvance = Convert.ToInt32(this.nbAvance.Text);
			if(Page.Request.QueryString[KEYTIPO] == Enumerados.TipoEntidadConFoto.Buque.ToString())
			{
				oFotoBE.IdBuque = Convert.ToInt32(Page.Request.QueryString[KEYQID]);
			}
			else if(Page.Request.QueryString[KEYTIPO] == Enumerados.TipoEntidadConFoto.Visita.ToString())
			{
				oFotoBE.IdVisitas = Convert.ToInt32(Page.Request.QueryString[KEYQID]);
			}
			oFotoBE.IdUsuarioActualizacion = CNetAccessControl.GetIdUser();
			oFotoBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.EstadosFoto);
			oFotoBE.IdEstado = Convert.ToInt32(Enumerados.EstadosFoto.Modificado);
			if(this.txtDescripcion.Text.Trim()!=String.Empty)
			{
				oFotoBE.Descripcion = this.txtDescripcion.Text;
			}
			if(this.txtObservaciones.Text.Trim()!=String.Empty)
			{
				oFotoBE.Observaciones = this.txtObservaciones.Text;
			}

			CMantenimientos oCMantenimientos = new CMantenimientos();
			int retorno = oCMantenimientos.Modificar(oFotoBE);

			if(retorno>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se modificó la Foto Nro. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));
				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionComercial.ToString(),Mensajes.CODIGOMENSAJEMODIFICACIONREGISTROFOTO));
			}
		}

		public void Eliminar()
		{
			// TODO:  Add DetalleFotos.Eliminar implementation
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
			FotoBE oFotoBE = (FotoBE)oCMantenimientos.ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYQIDFOTO]),Enumerados.ClasesNTAD.FotoNTAD.ToString());
			
			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionComercial",this.ToString(),"Se consultó el Detalle de la Foto Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

			if(oFotoBE!=null)
			{
				this.txtCodigoCaja.Text = oFotoBE.CodigoCaja;
				this.txtRutaFisica.Text = oFotoBE.RutaFisica;
				this.ddlbFormato.Items.FindByValue(oFotoBE.IdFormato.ToString()).Selected = true;
				this.nbCantidadFotos.Text = oFotoBE.CantidadFotos.ToString();
				this.chkDigitalizado.Checked = Convert.ToBoolean(oFotoBE.FlgDigitalizado);
				this.nbAvance.Text = oFotoBE.PorcentajeAvance.ToString();
				if(!oFotoBE.Descripcion.IsNull)
				{
					this.txtDescripcion.Text = oFotoBE.Descripcion.ToString();
				}
				if(!oFotoBE.Observaciones.IsNull)
				{
					this.txtObservaciones.Text = oFotoBE.Observaciones.ToString();
				}
			}
		}

		public void CargarModoConsulta()
		{
			this.ibtnCancelar.Visible = false;
			lblTitulo.Text = TITULOMODOCONSULTA;
			this.LlenarCombos();
			
			CMantenimientos	oCMantenimientos = new CMantenimientos();
			FotoBE oFotoBE = (FotoBE)oCMantenimientos.ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYQIDFOTO]),Enumerados.ClasesNTAD.FotoNTAD.ToString());
			
			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionComercial",this.ToString(),"Se consultó el Detalle de la Foto Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

			if(oFotoBE!=null)
			{
				this.txtCodigoCaja.Text = oFotoBE.CodigoCaja;
				this.txtRutaFisica.Text = oFotoBE.RutaFisica;
				this.ddlbFormato.Items.FindByValue(oFotoBE.IdFormato.ToString()).Selected = true;
				this.nbCantidadFotos.Text = oFotoBE.CantidadFotos.ToString();
				this.nbCantidadFotos.ReadOnly = true;
				this.chkDigitalizado.Checked = Convert.ToBoolean(oFotoBE.FlgDigitalizado);
				this.nbAvance.Text = oFotoBE.PorcentajeAvance.ToString();
				this.nbAvance.Enabled = false;
				if(!oFotoBE.Descripcion.IsNull)
				{
					this.txtDescripcion.Text = oFotoBE.Descripcion.ToString();
				}
				if(!oFotoBE.Observaciones.IsNull)
				{
					this.txtObservaciones.Text = oFotoBE.Observaciones.ToString();
				}
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
			if(this.txtCodigoCaja.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEFOTOCAMPOREQUERIDOCODIGOCAJA));
				return false;
			}
			if(this.txtRutaFisica.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEFOTOCAMPOREQUERIDORUTAFISICA));
				return false;
			}
			if(this.ddlbFormato.SelectedItem.Text == Constantes.TEXTOSSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEFOTOCAMPOREQUERIDOFORMATO));
				return false;
			}
			if(this.nbCantidadFotos.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEFOTOCAMPOREQUERIDOCANTIDADFOTOS));
				return false;
			}
			if(this.nbAvance.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEFOTOCAMPOREQUERIDOAVANCE));
				return false;
			}
			return true;
		}

		public bool ValidarExpresionesRegulares()
		{
			if(!ExpresionesRegulares.ValidarExpresionRegularEnterosPositivos(Server.HtmlEncode(this.nbCantidadFotos.Text)))
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesErrorComercialUsuario(Mensajes.CODIGOMENSAJEFOTODATOSINCORRECTOSCANTIDADFOTOS));
				return false;
			}
			if(!ExpresionesRegulares.ValidarExpresionRegularEnterosPositivos(Server.HtmlEncode(this.nbAvance.Text)))
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesErrorComercialUsuario(Mensajes.CODIGOMENSAJEFOTODATOSINCORRECTOSAVANCE));
				return false;
			}
			if(Convert.ToInt32(this.nbAvance.Text) > 100)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesErrorComercialUsuario(Mensajes.CODIGOMENSAJEFOTODATOSINCORRECTOSRANGOAVANCE));
				return false;
			}
			return true;
		}

		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add DetalleFotos.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetalleFotos.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetalleFotos.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			lItem = new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,Utilitario.Constantes.VALORSELECCIONAR);
			this.llenarFormatos();
			this.ddlbFormato.Items.Insert(0,lItem);
		}

		public void LlenarDatos()
		{
			// TODO:  Add DetalleFotos.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			this.rfvCodigoCaja.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEFOTOCAMPOREQUERIDOCODIGOCAJA);
			this.rfvCodigoCaja.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEFOTOCAMPOREQUERIDOCODIGOCAJA);

			this.rfvRutaFisica.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEFOTOCAMPOREQUERIDORUTAFISICA);
			this.rfvRutaFisica.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEFOTOCAMPOREQUERIDORUTAFISICA);

			this.rfvFormato.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEFOTOCAMPOREQUERIDOFORMATO);
			this.rfvFormato.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEFOTOCAMPOREQUERIDOFORMATO);
			this.rfvFormato.InitialValue = Constantes.VALORSELECCIONAR;

			this.rfvCantidadFotos.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEFOTOCAMPOREQUERIDOCANTIDADFOTOS);
			this.rfvCantidadFotos.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEFOTOCAMPOREQUERIDOCANTIDADFOTOS);

			this.rfvAvance.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEFOTOCAMPOREQUERIDOAVANCE);
			this.rfvAvance.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEFOTOCAMPOREQUERIDOAVANCE);

			this.rvAvance.ErrorMessage = Helper.ObtenerMensajesErrorComercialUsuario(Mensajes.CODIGOMENSAJEFOTODATOSINCORRECTOSRANGOAVANCE);
			this.rvAvance.ToolTip = Helper.ObtenerMensajesErrorComercialUsuario(Mensajes.CODIGOMENSAJEFOTODATOSINCORRECTOSRANGOAVANCE);
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetalleFotos.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetalleFotos.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetalleFotos.Exportar implementation
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

		private void llenarFormatos()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			ddlbFormato.DataSource = oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Enumerados.TablasTabla.FormatosFotos));
			ddlbFormato.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbFormato.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbFormato.DataBind();
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