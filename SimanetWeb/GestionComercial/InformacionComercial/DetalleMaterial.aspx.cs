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
	/// Summary description for DetalleMaterial.
	/// </summary>
	public class DetalleMaterial : System.Web.UI.Page, IPaginaBase 
	{
		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblDatos;
		protected System.Web.UI.WebControls.Label lblMensaje;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblDescripcion;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvDescripcion;
		protected System.Web.UI.WebControls.Label lblUnidaddeMedida;
		protected System.Web.UI.WebControls.DropDownList ddlbUnidadMedida;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvUnidadMedida;
		protected System.Web.UI.WebControls.Label lblTipoMaterial;
		protected System.Web.UI.WebControls.DropDownList ddlbTipoMaterial;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvTipoMaterial;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary vSum;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		private   ListItem item =  new ListItem();
		#endregion Controles

		#region Constantes
		
		//Titulos 
		const string TITULOMODONUEVO = "NUEVO MATERIAL";
		const string TITULOMODOMODIFICAR = "MATERIAL";

		//Key Session y QueryString
		const string KEYQID = "Id";

		#endregion Constantes

		private void llenarTiposMaterial()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			this.ddlbTipoMaterial.DataSource= oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Utilitario.Enumerados.TablasTabla.TiposMaterial));
			ddlbTipoMaterial.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbTipoMaterial.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbTipoMaterial.DataBind();	
			item = new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,Utilitario.Constantes.VALORSELECCIONAR);
			ddlbTipoMaterial.Items.Insert(0,item);
		}

		private void llenarUnidadesMedida()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			this.ddlbUnidadMedida.DataSource= oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Utilitario.Enumerados.TablasTabla.TiposUnidadesMedida));
			ddlbUnidadMedida.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbUnidadMedida.DataTextField = Enumerados.ColumnasTablaTablas.Var2.ToString();
			ddlbUnidadMedida.DataBind();	
			item = new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,Utilitario.Constantes.VALORSELECCIONAR);
			ddlbTipoMaterial.Items.Insert(0,item);
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
			// TODO:  Add DetalleMaterial.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetalleMaterial.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
		{
			// TODO:  Add DetalleMaterial.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			this.llenarTiposMaterial();
			this.llenarUnidadesMedida();
		}

		public void LlenarDatos()
		{
			// TODO:  Add DetalleMaterial.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			rfvDescripcion.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONDESCRIPCIONMATERIAL);
			rfvDescripcion.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONDESCRIPCIONMATERIAL);
			
			rfvTipoMaterial.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONTIPOMATERIALAMATERIAL);
			rfvTipoMaterial.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONTIPOMATERIALAMATERIAL);
			
			rfvUnidadMedida.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONUNIDADMEDIDAAMATERIAL);
			rfvUnidadMedida.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONUNIDADMEDIDAAMATERIAL);
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetalleMaterial.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetalleMaterial.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetalleMaterial.Exportar implementation
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
			MaterialBE oMaterialBE = new MaterialBE();
			oMaterialBE.Descripcion     = txtDescripcion.Text;
			oMaterialBE.IdTipo          = Convert.ToInt32(ddlbTipoMaterial.SelectedValue);
			oMaterialBE.IdTablaTipo         = Convert.ToInt32(Enumerados.TablasTabla.TiposMaterial);

			oMaterialBE.IdUnidadMedida  = Convert.ToInt32(ddlbUnidadMedida.SelectedValue);
			oMaterialBE.IdTablaUnidadMedida = Convert.ToInt32(Enumerados.TablasTabla.TiposUnidadesMedida);

			oMaterialBE.IdTablaEstado       = Convert.ToInt32(Enumerados.TablasTabla.EstadosMaterial);
			oMaterialBE.IdEstado            = Convert.ToInt32(Enumerados.EstadoMaterial.Activo);
			oMaterialBE.IdUsuarioRegistro   = CNetAccessControl.GetIdUser();

			CMantenimientos oCMantenimientos = new CMantenimientos();

			int retorno = oCMantenimientos.Insertar(oMaterialBE);

			if(retorno>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestión Comercial:Inf. Comercial",this.ToString(),"Se registró el Material Nro. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));

				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionComercial.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONREGISTROMATERIAL));
			}
		}

		public void Modificar()
		{

			MaterialBE oMaterialBE = new MaterialBE();
			oMaterialBE.IdMaterial             = Convert.ToInt32(Page.Request.QueryString[KEYQID]);
			oMaterialBE.Descripcion            = txtDescripcion.Text;
			oMaterialBE.IdTipo                 = Convert.ToInt32(ddlbTipoMaterial.SelectedValue);
			oMaterialBE.IdTablaTipo            = Convert.ToInt32(Enumerados.TablasTabla.TiposMaterial);

			oMaterialBE.IdUnidadMedida         = Convert.ToInt32(ddlbUnidadMedida.SelectedValue);
			oMaterialBE.IdTablaUnidadMedida    = Convert.ToInt32(Enumerados.TablasTabla.TiposUnidadesMedida);

			oMaterialBE.IdUsuarioActualizacion = CNetAccessControl.GetIdUser();
			oMaterialBE.IdTablaEstado          = Convert.ToInt32(Enumerados.TablasTabla.EstadosMaterial);
			oMaterialBE.IdEstado               = Convert.ToInt32(Enumerados.EstadoMaterial.Modificado);

			CMantenimientos oCMantenimientos = new CMantenimientos();
			if(oCMantenimientos.Modificar(oMaterialBE)>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial:Inf Comercial",this.ToString(),"Se modificó el Material Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionComercial.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONMODIFICACIONMATERIAL));
			}
		}

		public void Eliminar()
		{
			// TODO:  Add DetalleMaterial.Eliminar implementation
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
			MaterialBE oMaterialBE = (MaterialBE) oCMantenimientos.ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYQID]),Enumerados.ClasesNTAD.MaterialNTAD.ToString());
			
			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial:Inf.Comercial",this.ToString(),"Se consultó el Detalle del Producto Informacion " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

			if(oMaterialBE!=null)
			{
				txtDescripcion.Text = oMaterialBE.Descripcion.ToString();
				ddlbTipoMaterial.Items.FindByValue(oMaterialBE.IdTipo.ToString()).Selected = true;
				ddlbUnidadMedida.Items.FindByValue(oMaterialBE.IdUnidadMedida.ToString()).Selected = true;
			}
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add DetalleMaterial.CargarModoConsulta implementation
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
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONDESCRIPCIONMATERIAL));
				return false;		
			}
			if(ddlbTipoMaterial.SelectedItem.Text == Constantes.TEXTOSSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONTIPOMATERIALAMATERIAL));
				return false;		
			}

			if(ddlbUnidadMedida.SelectedItem.Text == Constantes.TEXTOSSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONUNIDADMEDIDAAMATERIAL));
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