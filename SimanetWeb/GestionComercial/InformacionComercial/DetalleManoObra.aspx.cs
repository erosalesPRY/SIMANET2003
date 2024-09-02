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
	/// Summary description for DetalleManoObra.
	/// </summary>
	public class DetalleManoObra : System.Web.UI.Page, IPaginaBase 
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
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.DropDownList ddlbTipoManoObra;
		protected System.Web.UI.WebControls.Label lblTipoManoObra;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvTipoManoObra;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary vSum;
		private   ListItem item =  new ListItem();
		#endregion Controles
	
		#region Constantes
		
		//Titulos 
		const string TITULOMODONUEVO = "NUEVA MANO DE OBRA";
		const string TITULOMODOMODIFICAR = "MANO DE OBRA";

		//Key Session y QueryString
		const string KEYQID = "Id";

		#endregion Constantes

		private void llenarTiposManoObra()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			this.ddlbTipoManoObra.DataSource= oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Utilitario.Enumerados.TablasTabla.TiposManoObra));
			ddlbTipoManoObra.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbTipoManoObra.DataTextField = Enumerados.ColumnasTablaTablas.Var2.ToString();
			ddlbTipoManoObra.DataBind();	
			item = new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,Utilitario.Constantes.VALORSELECCIONAR);
			ddlbTipoManoObra.Items.Insert(0,item);
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
			// TODO:  Add DetalleManoObra.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetalleManoObra.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
		{
			// TODO:  Add DetalleManoObra.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			this.llenarTiposManoObra();
		}

		public void LlenarDatos()
		{
			// TODO:  Add DetalleManoObra.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			rfvDescripcion.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONDESCRIPCIONMANOOBRA);
			rfvDescripcion.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONDESCRIPCIONMANOOBRA);

			rfvTipoManoObra.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONTIPOMANOOBRAMANOOBRA);
			rfvTipoManoObra.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONTIPOMANOOBRAMANOOBRA);
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetalleManoObra.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetalleManoObra.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetalleManoObra.Exportar implementation
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
			ManoObraBE oManoObraBE = new ManoObraBE();
			oManoObraBE.Descripcion       = txtDescripcion.Text;
			oManoObraBE.IdTipo            = Convert.ToInt32(ddlbTipoManoObra.SelectedValue);
			oManoObraBE.IdTablaTipo       = Convert.ToInt32(Enumerados.TablasTabla.TiposManoObra);

			oManoObraBE.IdTablaEstado     = Convert.ToInt32(Enumerados.TablasTabla.EstadosManoObra);
			oManoObraBE.IdEstado          = Convert.ToInt32(Enumerados.EstadoManoObra.Activo);
			oManoObraBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();

			CMantenimientos oCMantenimientos = new CMantenimientos();

			int retorno = oCMantenimientos.Insertar(oManoObraBE);

			if(retorno>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial:Inf. Comercial",this.ToString(),"Se registró el ManoObra Nro. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));
				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionComercial.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONREGISTROMANOOBRA));
			}
		}

		public void Modificar()
		{

			ManoObraBE oManoObraBE = new ManoObraBE();
			oManoObraBE.IdManoObra             = Convert.ToInt32(Page.Request.QueryString[KEYQID]);
			oManoObraBE.Descripcion            = txtDescripcion.Text;
			oManoObraBE.IdTipo                 = Convert.ToInt32(ddlbTipoManoObra.SelectedValue);
			oManoObraBE.IdTablaTipo            = Convert.ToInt32(Enumerados.TablasTabla.TiposManoObra);

			oManoObraBE.IdUsuarioActualizacion = CNetAccessControl.GetIdUser();
			oManoObraBE.IdTablaEstado          = Convert.ToInt32(Enumerados.TablasTabla.EstadosManoObra);
			oManoObraBE.IdEstado               = Convert.ToInt32(Enumerados.EstadoManoObra.Modificado);

			CMantenimientos oCMantenimientos = new CMantenimientos();
			if(oCMantenimientos.Modificar(oManoObraBE)>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial:Inf. Comercial",this.ToString(),"Se modificó el ManoObra Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionComercial.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONMODIFICACIONMANOOBRA));
			}
		}

		public void Eliminar()
		{
			// TODO:  Add DetalleManoObra.Eliminar implementation
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
			ManoObraBE oManoObraBE = (ManoObraBE) oCMantenimientos.ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYQID]),Enumerados.ClasesNTAD.ManoObraNTAD.ToString());
			
			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial:Inf.Comercial",this.ToString(),"Se consultó el Detalle del Producto Informacion " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

			if(oManoObraBE!=null)
			{
				txtDescripcion.Text = oManoObraBE.Descripcion.ToString();
				ddlbTipoManoObra.Items.FindByValue(oManoObraBE.IdTipo.ToString()).Selected = true;
			}
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add DetalleManoObra.CargarModoConsulta implementation
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
			if(ddlbTipoManoObra.SelectedItem.Text == Constantes.TEXTOSSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONTIPOMANOOBRAMANOOBRA));
				return false;		
			}

			if(txtDescripcion.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJECONFIRMACIONDESCRIPCIONMANOOBRA));
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
