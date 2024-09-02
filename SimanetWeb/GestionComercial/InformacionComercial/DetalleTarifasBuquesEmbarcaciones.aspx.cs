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
	/// Summary description for DetalleTarifasBuquesEmbarcaciones.
	/// </summary>
	public class DetalleTarifasBuquesEmbarcaciones: System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		#region Controles

		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvDestino;
		protected System.Web.UI.WebControls.Label lblMensaje;
		protected System.Web.UI.WebControls.Label lblCosto;
		protected System.Web.UI.WebControls.TextBox txtCosto;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvCosto;
		protected System.Web.UI.WebControls.Label lblDescripcion;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvDescripcion;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.DropDownList ddlbMoneda;
		protected System.Web.UI.WebControls.Label lblMoneda;
		protected System.Web.UI.WebControls.Label lblClasificacionEmbarcacion;
		protected System.Web.UI.WebControls.DropDownList ddlbClasificacionEmbarcacion;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvClasificacionEmbarcacion;
		protected System.Web.UI.WebControls.Label lblDetalle;
		protected System.Web.UI.WebControls.TextBox txtDetalle;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary vSum;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvMoneda;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvDetalle;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlbClasificacionEmbarcacion;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlbMoneda;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellibtnAtras;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellibtnCancelar;
		private   ListItem Item =  new ListItem();

		#endregion Controles

		#region Constantes
		
		//Titulos 
		const string TITULOMODONUEVO = "NUEVO TARIFA EMBARCACION";
		const string TITULOMODOMODIFICAR = "TARIFA EMBARCACION";
		const string TITULOMODOCONSULTA = "REGISTRO DE TARIFA EMBARCACION";

		//Key Session y QueryString
		const string KEYQID = "Id";
	
		
		#endregion Constantes
		
		private void LlenarClasificacionEmbarcacion()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			this.ddlbClasificacionEmbarcacion.DataSource= oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Utilitario.Enumerados.TablasTabla.ClasificacionEmbarcaciones));
			ddlbClasificacionEmbarcacion.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbClasificacionEmbarcacion.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbClasificacionEmbarcacion.DataBind();	
			Item = new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,Utilitario.Constantes.VALORSELECCIONAR);
			ddlbClasificacionEmbarcacion.Items.Insert(0,Item);
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
			// TODO:  Add DetalleTarifasBuquesEmbarcaciones.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetalleTarifasBuquesEmbarcaciones.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
		{
			// TODO:  Add DetalleTarifasBuquesEmbarcaciones.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			this.LlenarClasificacionEmbarcacion();
			this.LlenarMoneda();
		}

		public void LlenarDatos()
		{
			// TODO:  Add DetalleTarifasBuquesEmbarcaciones.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			rfvClasificacionEmbarcacion.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONTIPOEMBARCACIONCOSTOEMBARCACION);
			rfvClasificacionEmbarcacion.ToolTip      = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONTIPOEMBARCACIONCOSTOEMBARCACION);

			rfvDescripcion.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONDESCRIPCIONTARIFAEMBARCACION);
			rfvDescripcion.ToolTip      = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONDESCRIPCIONTARIFAEMBARCACION);

			rfvDetalle.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONDETALLETARIFAEMBARCACION);
			rfvDetalle.ToolTip      = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONDETALLETARIFAEMBARCACION);

			rfvCosto.ErrorMessage  = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONCOSTOTARIFAEMBARCACION);
			rfvCosto.ErrorMessage  = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONCOSTOTARIFAEMBARCACION);

			rfvMoneda.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONMONEDATARIFAEMBARCACION);
			rfvMoneda.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONMONEDATARIFAEMBARCACION);

		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetalleTarifasBuquesEmbarcaciones.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetalleTarifasBuquesEmbarcaciones.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetalleTarifasBuquesEmbarcaciones.Exportar implementation
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
			TarifaEmbarcacionBE oTarifaEmbarcacionBE  = new TarifaEmbarcacionBE();
			oTarifaEmbarcacionBE.DescripcionTrabajo   = txtDescripcion.Text;
			oTarifaEmbarcacionBE.CostoTrabajo         = Convert.ToDouble(txtCosto.Text);

			oTarifaEmbarcacionBE.IdClasificacion      = Convert.ToInt32(ddlbClasificacionEmbarcacion.SelectedValue);
			oTarifaEmbarcacionBE.IdTablaClasificacion = Convert.ToInt32(Enumerados.TablasTabla.ClasificacionEmbarcaciones);

			oTarifaEmbarcacionBE.IdTablaMoneda        = Convert.ToInt32(Enumerados.TablasTabla.Moneda);
			oTarifaEmbarcacionBE.IdMoneda             = Convert.ToInt32(ddlbMoneda.SelectedValue);

			oTarifaEmbarcacionBE.Descripcion          = txtDetalle.Text;

			oTarifaEmbarcacionBE.IdTablaEstado        = Convert.ToInt32(Enumerados.TablasTabla.EstadosTarifaEmbarcacion);
			oTarifaEmbarcacionBE.IdEstado             = Convert.ToInt32(Enumerados.EstadoTarifaEmbarcacion.Activo);
			oTarifaEmbarcacionBE.IdUsuarioRegistro    = CNetAccessControl.GetIdUser();
			

			CMantenimientos oCMantenimientos = new CMantenimientos();

			int retorno = oCMantenimientos.Insertar(oTarifaEmbarcacionBE);

			if(retorno>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial:Inf. Comercial",this.ToString(),"Se registró la Tarifa Embarcacion Nro. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));
				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionComercial.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONREGISTROTARIFAEMBARCACION));
			}
		}

		public void Modificar()
		{

			TarifaEmbarcacionBE oTarifaEmbarcacionBE    = new TarifaEmbarcacionBE();
			oTarifaEmbarcacionBE.IdTarifaEmbarcacion    = Convert.ToInt32(Page.Request.QueryString[KEYQID]);
			oTarifaEmbarcacionBE.DescripcionTrabajo     = txtDescripcion.Text;
			oTarifaEmbarcacionBE.CostoTrabajo           = Convert.ToDouble(txtCosto.Text);

			oTarifaEmbarcacionBE.IdClasificacion        = Convert.ToInt32(ddlbClasificacionEmbarcacion.SelectedValue);
			oTarifaEmbarcacionBE.IdTablaClasificacion   = Convert.ToInt32(Enumerados.TablasTabla.ClasificacionEmbarcaciones);

			oTarifaEmbarcacionBE.IdTablaMoneda          = Convert.ToInt32(Enumerados.TablasTabla.Moneda);
			oTarifaEmbarcacionBE.IdMoneda               = Convert.ToInt32(ddlbMoneda.SelectedValue);

			oTarifaEmbarcacionBE.Descripcion            = txtDetalle.Text;

			oTarifaEmbarcacionBE.IdUsuarioActualizacion = CNetAccessControl.GetIdUser();
			oTarifaEmbarcacionBE.IdTablaEstado          = Convert.ToInt32(Enumerados.TablasTabla.EstadosTarifaEmbarcacion);
			oTarifaEmbarcacionBE.IdEstado               = Convert.ToInt32(Enumerados.EstadoTarifaEmbarcacion.Modificado);

			CMantenimientos oCMantenimientos = new CMantenimientos();
			if(oCMantenimientos.Modificar(oTarifaEmbarcacionBE)>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial:Inf. Comercial",this.ToString(),"Se modificó la Tarifa Embarcacion Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));
				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionComercial.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONMODIFICACIONTARIFAEMBARCACION));
			}
		}

		public void Eliminar()
		{
			// TODO:  Add DetalleTarifasBuquesEmbarcaciones.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.QueryString[Constantes.KEYMODOPAGINA]) ;
			this.AlinearCamposDerecha();

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
			CellibtnAtras.Visible = false;
			lblTitulo.Text = TITULOMODONUEVO;
			this.LlenarCombos();
		}

		public void AlinearCamposDerecha()
		{
			this.txtCosto.Style[Constantes.ALINEAMIENTOTEXTO] = TextAlign.Right.ToString();
		}

		public void CargarModoModificar()
		{
			CellibtnAtras.Visible = false;
			lblTitulo.Text = TITULOMODOMODIFICAR;
			this.LlenarCombos();
			
			CMantenimientos	oCMantenimientos = new CMantenimientos();
			TarifaEmbarcacionBE oTarifaEmbarcacionBE = (TarifaEmbarcacionBE) oCMantenimientos.ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYQID]),Enumerados.ClasesNTAD.TarifaEmbarcacionNTAD.ToString());
			
			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial:Inf.Comercial",this.ToString(),"Se consultó el Detalle de la Tarifa Embarcacion " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

			if(oTarifaEmbarcacionBE!=null)
			{
				txtDescripcion.Text = oTarifaEmbarcacionBE.DescripcionTrabajo.ToString();
				ddlbClasificacionEmbarcacion.Items.FindByValue(oTarifaEmbarcacionBE.IdClasificacion.ToString()).Selected = true;
				ddlbMoneda.Items.FindByValue(oTarifaEmbarcacionBE.IdMoneda.ToString()).Selected = true;
				txtCosto.Text       = oTarifaEmbarcacionBE.CostoTrabajo.ToString();
				txtDetalle.Text     = oTarifaEmbarcacionBE.Descripcion.ToString();
			}
		}

		public void CargarModoConsulta()
		{
			CellibtnAtras.Visible = true;
			CellibtnCancelar.Visible = false;
			lblTitulo.Text = TITULOMODOCONSULTA;
			this.LlenarCombos();
			
			CMantenimientos	oCMantenimientos = new CMantenimientos();
			TarifaEmbarcacionBE oTarifaEmbarcacionBE = (TarifaEmbarcacionBE) oCMantenimientos.ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYQID]),Enumerados.ClasesNTAD.TarifaEmbarcacionNTAD.ToString());
			
			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial:Inf.Comercial",this.ToString(),"Se consultó el Detalle de la Tarifa Embarcacion " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

			if(oTarifaEmbarcacionBE!=null)
			{
				txtDescripcion.Text = oTarifaEmbarcacionBE.DescripcionTrabajo.ToString();
				ddlbClasificacionEmbarcacion.Items.FindByValue(oTarifaEmbarcacionBE.IdClasificacion.ToString()).Selected = true;
				ddlbMoneda.Items.FindByValue(oTarifaEmbarcacionBE.IdMoneda.ToString()).Selected = true;
				txtCosto.Text       = oTarifaEmbarcacionBE.CostoTrabajo.ToString();
				txtDetalle.Text     = oTarifaEmbarcacionBE.Descripcion.ToString();
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
			if(ddlbClasificacionEmbarcacion.SelectedItem.Text == Constantes.TEXTOSSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONTIPOEMBARCACIONCOSTOEMBARCACION));
				return false;		
			}

			if(txtDescripcion.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONDESCRIPCIONTARIFAEMBARCACION));
				return false;		
			}

			if(txtDetalle.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONDETALLETARIFAEMBARCACION));
				return false;		
			}

			if(txtCosto.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONCOSTOTARIFAEMBARCACION));
				return false;		
			}

			if(ddlbMoneda.SelectedItem.Text == Constantes.TEXTOSSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONMONEDATARIFAEMBARCACION));
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

