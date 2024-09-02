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
using SIMA.Controladoras.General;
using SIMA.Controladoras.GestionControlInstitucional;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using SIMA.EntidadesNegocio.GestionControlInstitucional;
using NetAccessControl;

namespace SIMA.SimaNetWeb.GestionControlInstitucional
{
	/// <summary>
	/// Summary description for DetalleAreaCritica.
	/// </summary>
	public class DetalleAreaCritica : System.Web.UI.Page, IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblMensaje;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.ImageButton ibtnCancelar;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvCodigo;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvDenominacion;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvGrupo;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary vSum;
		protected System.Web.UI.WebControls.Label lblCodigo;
		protected System.Web.UI.WebControls.TextBox txtCodigo;
		protected System.Web.UI.WebControls.Label lblGrupo;
		protected System.Web.UI.WebControls.DropDownList ddlbGrupo;
		protected System.Web.UI.WebControls.Label lblDenominacion;
		protected System.Web.UI.WebControls.TextBox txtDenominacion;
		protected System.Web.UI.HtmlControls.HtmlTableCell TdCeldaAtras;
		private   ListItem item =  new ListItem();
		#endregion Controles

		#region Constantes
		const string URLPRINCIPAL = "AdministracionAreaCritica.aspx";
		const string KEYQID  = "IdGrupo";
		const string KEYQID1 = "Id";
		
		const string TITULOMODONUEVO     = "NUEVA AREA CRÍTICA";
		const string TITULOMODOMODIFICAR = "MODIFICAR AREA CRÍTICA";
		const string TITULOMODOCONSULTA  = "CONSULTAR AREA CRÍTICA";
		#endregion Constantes
	

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
			this.ibtnCancelar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnCancelar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void CargarGrupoAreaCritica()
		{
			CGrupoAreaCritica oCGrupoAreaCritica = new CGrupoAreaCritica();
			this.ddlbGrupo.DataSource = oCGrupoAreaCritica.ListarGrupoAreaCritica();
			ddlbGrupo.DataValueField  = Enumerados.ColumnasGrupoAreaCritica.IdGrupoAreaCritica.ToString();
			ddlbGrupo.DataTextField   = Enumerados.ColumnasGrupoAreaCritica.Denominacion.ToString();
			ddlbGrupo.DataBind();	
			item = new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,Utilitario.Constantes.VALORSELECCIONAR);
			ddlbGrupo.Items.Insert(0,item);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!Page.IsPostBack)
			{

				try
				{
					this.ConfigurarAccesoControles();
					
					Helper.ReiniciarSession();
					this.LlenarJScript();
					this.LlenarCombos();
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

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
		{
		}

		public void LlenarCombos()
		{
			this.CargarGrupoAreaCritica();
		}

		public void LlenarDatos()
		{
		
		}

		public void LlenarJScript()
		{
			rfvCodigo.ErrorMessage       = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEAREACRITICACAMPOREQUERIDOCODIGO);
			rfvCodigo.ToolTip            = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEAREACRITICACAMPOREQUERIDOCODIGO);

			rfvGrupo.ErrorMessage        = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEAREACRITICACAMPOREQUERIDOGRUPO);
			rfvGrupo.ToolTip             = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEAREACRITICACAMPOREQUERIDOGRUPO);
			rfvGrupo.InitialValue        = Constantes.VALORSELECCIONAR;

			rfvDenominacion.ErrorMessage = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEAREACRITICACAMPOREQUERIDODENOMINACION);
			rfvDenominacion.ToolTip      = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEAREACRITICACAMPOREQUERIDODENOMINACION);

		}

		public void RegistrarJScript()
		{
			// TODO:  Add implementation
		}

		public void Imprimir()
		{
			// TODO:  Add implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultaDeCartasFianzas.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add implementation

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
			AreaCriticaBE oAreaCriticaBE = new AreaCriticaBE();

			oAreaCriticaBE.IdGrupoAreaCritica = Convert.ToInt32(ddlbGrupo.SelectedValue);
			oAreaCriticaBE.NroAreaCritica     = txtCodigo.Text;
			oAreaCriticaBE.Denominacion       = txtDenominacion.Text.ToUpper();

			
			oAreaCriticaBE.IdUsuarioRegistro  = CNetAccessControl.GetIdUser();
			oAreaCriticaBE.IdTablaEstado      = Convert.ToInt32(Enumerados.TablasTabla.AreaCritica);
			oAreaCriticaBE.IdEstado           = Convert.ToInt32(Enumerados.EstadosAreaCritica.Activo);
			
			CMantenimientos oCMantenimientos = new CMantenimientos();

			int retorno = oCMantenimientos.Insertar(oAreaCriticaBE);

			if(retorno>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Detalle Area Critica",this.ToString(),"Se registró el Detalle de Grupo de Área Crítica Nro. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));
				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionOCI.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONREGISTROAREACRITICA),URLPRINCIPAL);
			}
		}

		public void Modificar()
		{
			AreaCriticaBE oAreaCriticaBE = new AreaCriticaBE();

			oAreaCriticaBE.IdAreaCritica          = Convert.ToInt32(Page.Request.QueryString[KEYQID1]);
			oAreaCriticaBE.IdGrupoAreaCritica     = Convert.ToInt32(ddlbGrupo.SelectedValue);
			oAreaCriticaBE.NroAreaCritica         = txtCodigo.Text;
			oAreaCriticaBE.Denominacion           = txtDenominacion.Text;

			oAreaCriticaBE.IdUsuarioActualizacion = CNetAccessControl.GetIdUser();
			oAreaCriticaBE.IdTablaEstado          = Convert.ToInt32(Enumerados.TablasTabla.AreaCritica);
			oAreaCriticaBE.IdEstado               = Convert.ToInt32(Enumerados.EstadosAreaCritica.Modificado);
			
			CMantenimientos oCMantenimientos = new CMantenimientos();
			if(oCMantenimientos.Modificar(oAreaCriticaBE)>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Detalle Area Critica",this.ToString(),"Se modificó el Detalle del Área Crítica Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));
				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionOCI.ToString(),Mensajes.CODIGOMENSAJEMODIFICACIONREGISTROAREACRITICA),URLPRINCIPAL);
			}
		}

		public void Eliminar()
		{
			// TODO:  Add DetalleCuentasBancaria.Eliminar implementation
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
			this.TdCeldaAtras.Visible = false;
			lblTitulo.Text = TITULOMODOMODIFICAR;
			this.LlenarCombos();
			
			CAreaCritica oCAreaCritica = new CAreaCritica();
			AreaCriticaBE oAreaCriticaBE = (AreaCriticaBE) oCAreaCritica.DetalleAreaCritica(Convert.ToInt32(Page.Request.QueryString[KEYQID]), Convert.ToInt32(Page.Request.QueryString[KEYQID1]));

			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Detalle Área Crítica",this.ToString(),"Se consultó el Detalle del Área Crítica Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

			if(oAreaCriticaBE!=null)
			{
				txtCodigo.Text = oAreaCriticaBE.NroAreaCritica.ToString();
				item = this.ddlbGrupo.Items.FindByValue(oAreaCriticaBE.IdGrupoAreaCritica.ToString());
				if(item!=null)
				{item.Selected = true;}
				txtDenominacion.Text  = oAreaCriticaBE.Denominacion.ToString();
			}
		}

		public void CargarModoConsulta()
		{

			this.ibtnCancelar.Visible = false;
			Helper.BloquearControles(this);
			lblTitulo.Text = TITULOMODOCONSULTA;
			this.LlenarCombos();
			
			CAreaCritica oCAreaCritica = new CAreaCritica();
			AreaCriticaBE oAreaCriticaBE = (AreaCriticaBE) oCAreaCritica.DetalleAreaCritica(Convert.ToInt32(Page.Request.QueryString[KEYQID]), Convert.ToInt32(Page.Request.QueryString[KEYQID1]));

			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Detalle Grupo Área Crítica",this.ToString(),"Se consultó el Detalle de Grupo de Área Crítica Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

			if(oAreaCriticaBE!=null)
			{
				txtCodigo.Text = oAreaCriticaBE.NroAreaCritica.ToString();
				item = this.ddlbGrupo.Items.FindByValue(oAreaCriticaBE.IdGrupoAreaCritica.ToString());
				if(item!=null)
				{item.Selected = true;}
				txtDenominacion.Text  = oAreaCriticaBE.Denominacion.ToString();
			}
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
			if(txtCodigo.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEAREACRITICACAMPOREQUERIDOCODIGO));
				return false;		
			}

			if(this.ddlbGrupo.SelectedItem.Text == Constantes.TEXTOSSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEAREACRITICACAMPOREQUERIDOGRUPO));
				return false;
			}

						
			if(txtDenominacion.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJEAREACRITICACAMPOREQUERIDODENOMINACION));
				return false;		
			}
			return true;
		}

		public bool ValidarExpresionesRegulares()
		{
			return true;
		}

		#endregion

		#region Opciones Usuario

		#region Cancelar
		private void ibtnCancelar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.redireccionaPaginaPrincipal();
		}

		private void redireccionaPaginaPrincipal()
		{
			Page.Response.Redirect(URLPRINCIPAL);
		}
		#endregion Cancelar
		#endregion Opciones Usuario

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
