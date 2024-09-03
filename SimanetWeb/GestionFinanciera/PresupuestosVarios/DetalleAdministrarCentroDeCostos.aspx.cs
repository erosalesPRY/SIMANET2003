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
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using SIMA.EntidadesNegocio.General;
using NetAccessControl;

namespace SIMA.SimaNetWeb.GestionFinanciera
{
	/// <summary>
	/// Summary description for DetalleAdministrarCentroDeCostos.
	/// </summary>
	public class DetalleAdministrarCentroDeCostos : System.Web.UI.Page, IPaginaBase, IPaginaMantenimento
	{
		#region Controles
		protected eWorld.UI.NumericBox txtAnexo;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblNroCC;
		protected System.Web.UI.WebControls.Label lblNROCuenta;
		protected System.Web.UI.WebControls.Label lblNombreCC;
		protected System.Web.UI.WebControls.TextBox txtNROCC;
		protected System.Web.UI.WebControls.TextBox txtNROCuenta;
		protected System.Web.UI.WebControls.TextBox txtNombreCC;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.ImageButton ibtnCancelar;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary vSum;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvNroCC;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvNroCta;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvNombreCC;
		#endregion

		#region Constantes
		const string URLPRINCIPAL = "AdministrarCentroDeCostos.aspx?";
		const string TITULOMODONUEVO = "NUEVO CENTRO DE COSTOS";
		const string TITULOMODOMODIFICAR = "CENTRO DE COSTOS";
		const string KEYQID = "Id";
		const string KEYQNOMBRE = "Nombre";
		const string KEYQIDGRUPOCC = "IdGrupoCC";
		protected System.Web.UI.WebControls.Label lblAnexo;

		
		const string KEYQNROGRUPOCC = "NroGrupoCC";

		#endregion Constantes

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					//this.ConfigurarAccesoControles();

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
			this.ibtnCancelar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnCancelar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add DetalleAdministrarCentroDeCostos.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetalleAdministrarCentroDeCostos.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetalleAdministrarCentroDeCostos.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add DetalleAdministrarCentroDeCostos.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add DetalleAdministrarCentroDeCostos.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			
			this.rfvNroCC.ErrorMessage = Helper.ObtenerMensajesConfirmacionGestionFinancieraUsuario(Mensajes.CODIGOMENSAJECAMPONROCC);
			this.rfvNroCC.ToolTip = Helper.ObtenerMensajesConfirmacionGestionFinancieraUsuario(Mensajes.CODIGOMENSAJECAMPONROCC);

			this.rfvNroCta.ErrorMessage = Helper.ObtenerMensajesConfirmacionGestionFinancieraUsuario(Mensajes.CODIGOMENSAJECAMPONROCTA);
			this.rfvNroCta.ToolTip = Helper.ObtenerMensajesConfirmacionGestionFinancieraUsuario(Mensajes.CODIGOMENSAJECAMPONROCTA);

			this.rfvNombreCC.ErrorMessage = Helper.ObtenerMensajesConfirmacionGestionFinancieraUsuario(Mensajes.CODIGOMENSAJECAMPONOMBRECC);
			this.rfvNombreCC.ToolTip = Helper.ObtenerMensajesConfirmacionGestionFinancieraUsuario(Mensajes.CODIGOMENSAJECAMPONOMBRECC);
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetalleAdministrarCentroDeCostos.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetalleAdministrarCentroDeCostos.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetalleAdministrarCentroDeCostos.Exportar implementation
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
			// TODO:  Add DetalleAdministrarCentroDeCostos.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			CentroCostoBE oCentroCostoBE = new CentroCostoBE();
			//string nombre = Page.Request.QueryString[KEYQNOMBRE].ToString();
			int idGrupoCC = Convert.ToInt32(Page.Request.QueryString[KEYQIDGRUPOCC]);
			int nroGrupoCC = Convert.ToInt32(Page.Request.QueryString[KEYQNROGRUPOCC]);

			oCentroCostoBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();
			oCentroCostoBE.NroCC = this.txtNROCC.Text.ToUpper();
			oCentroCostoBE.Nombre = this.txtNombreCC.Text.ToUpper();
			oCentroCostoBE.NroCTA = Convert.ToInt32(this.txtNROCuenta.Text);
			oCentroCostoBE.IdGrupoCC = idGrupoCC;
			oCentroCostoBE.Nrogrupocc =nroGrupoCC;
			oCentroCostoBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.EstadoCentroCosto);
			oCentroCostoBE.IdEstado = Convert.ToInt32(Enumerados.EstadoCentroCosto.Activo);
			
			if (this.txtAnexo.Text !=  "" )
				oCentroCostoBE.Anexo = Convert.ToInt32(txtAnexo.Text);
			
			CMantenimientos oCMantenimientos = new CMantenimientos();
			int retorno = oCMantenimientos.Insertar(oCentroCostoBE);

			if(retorno>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Financiera",this.ToString(),"Se registró la el Grupo de Centro de Costo Nro. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));

				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionFinanciera.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONREGISTROCC),URLPRINCIPAL + 
					KEYQIDGRUPOCC + Constantes.SIGNOIGUAL + idGrupoCC
					+ Constantes.SIGNOAMPERSON +//+ KEYQNOMBRE + Constantes.SIGNOIGUAL + nombre +
					KEYQNROGRUPOCC + Constantes.SIGNOIGUAL + nroGrupoCC );
			}
			else if(retorno == -1)
			{
				ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesErrorFinanciera.ToString(),Mensajes.CODIGOMENSAJENROCENTROCOSTOEXISTENTE));
			
			
			}

	}

		public void Modificar()
		{
			CentroCostoBE oCentroCostoBE = new CentroCostoBE();

			//string nombre = Page.Request.QueryString[KEYQIDGRUPOCC].ToString();
			int idGrupoCC = Convert.ToInt32(Page.Request.QueryString[KEYQIDGRUPOCC]);
			int nroGrupoCC = Convert.ToInt32(Page.Request.QueryString[KEYQNROGRUPOCC]);

			oCentroCostoBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();
			oCentroCostoBE.NroCC = this.txtNROCC.Text.ToUpper();
			oCentroCostoBE.Nombre = this.txtNombreCC.Text.ToUpper();
			oCentroCostoBE.NroCTA = Convert.ToInt32(this.txtNROCuenta.Text);
			oCentroCostoBE.IdCentroCosto = Convert.ToInt32(Page.Request.QueryString[KEYQID]);
			oCentroCostoBE.IdGrupoCC = Convert.ToInt32(Page.Request.QueryString[KEYQIDGRUPOCC]);
//			oCentroCostoBE.Nrogrupocc =nroGrupoCC;
			oCentroCostoBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.EstadoCentroCosto);
			oCentroCostoBE.IdEstado = Convert.ToInt32(Enumerados.EstadoCentroCosto.Activo);
			
			if (txtAnexo.Text != "" )
				oCentroCostoBE.Anexo = Convert.ToInt32(txtAnexo.Text);
			else
				oCentroCostoBE.Anexo = null;

			CMantenimientos oCMantenimientos = new CMantenimientos();
			int retorno = oCMantenimientos.Modificar(oCentroCostoBE);

			if(retorno>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Financiera",this.ToString(),"Se modifico el Centro de Costo Nro. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));

				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionFinanciera.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONMOFICACIONOCC),URLPRINCIPAL +
					KEYQID + Constantes.SIGNOIGUAL + idGrupoCC +  Constantes.SIGNOAMPERSON + 
					//KEYQNOMBRE + Constantes.SIGNOIGUAL + nombre +  Constantes.SIGNOAMPERSON +
					KEYQIDGRUPOCC + Constantes.SIGNOIGUAL + idGrupoCC + Constantes.SIGNOAMPERSON +
					KEYQNROGRUPOCC + Constantes.SIGNOIGUAL + nroGrupoCC );
			}
			else if(retorno == 0)
			{
			ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesErrorFinanciera.ToString(),Mensajes.CODIGOMENSAJENROCENTROCOSTOEXISTENTE));
			
			}
		}

		public void Eliminar()
		{
			// TODO:  Add DetalleAdministrarCentroDeCostos.Eliminar implementation
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
		}

		public void CargarModoModificar()
		{
			lblTitulo.Text = TITULOMODOMODIFICAR;
						
			CMantenimientos	oCMantenimientos = new CMantenimientos();
			CentroCostoBE oCentroCostoBE = (CentroCostoBE)oCMantenimientos.ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYQID]),Enumerados.ClasesNTAD.CentroCostoNTAD.ToString());
			
			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Financiero",this.ToString(),"Se consultó el Detalle del Centro de Costo Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

			if(oCentroCostoBE!=null)
			{
				this.txtNombreCC.Text = oCentroCostoBE.Nombre.ToString();
				this.txtNROCC.Text = oCentroCostoBE.NroCC.ToString();
				this.txtNROCuenta.Text = oCentroCostoBE.NroCTA.ToString();
				this.txtAnexo.Text = oCentroCostoBE.Anexo.ToString();
				
			}
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add DetalleAdministrarCentroDeCostos.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			return this.ValidarCamposRequeridos();
		}

		public bool ValidarCamposRequeridos()
		{
			if(this.txtNROCC.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionGestionFinancieraUsuario(Mensajes.CODIGOMENSAJECAMPONROCC));
				return false;
			}
			if(this.txtNROCuenta.Text.Trim() == String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionGestionFinancieraUsuario(Mensajes.CODIGOMENSAJECAMPONROCTA));
				return false;
			}
			if(this.txtNombreCC.Text.Trim() == String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionGestionFinancieraUsuario(Mensajes.CODIGOMENSAJECAMPONOMBRECC));
				return false;
			}
		
			return true;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add DetalleAdministrarCentroDeCostos.ValidarExpresionesRegulares implementation
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

		private void ibtnCancelar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.redireccionaPaginaPrincipal();
		}
		private void redireccionaPaginaPrincipal()
		{
			//string nombre = Page.Request.QueryString[KEYQNOMBRE].ToString();
			int nroGrupoCC = Convert.ToInt32(Page.Request.QueryString[KEYQNROGRUPOCC]);
			int idGrupoCC = Convert.ToInt32(Page.Request.QueryString[KEYQIDGRUPOCC]);
			Page.Response.Redirect(URLPRINCIPAL + KEYQIDGRUPOCC + Constantes.SIGNOIGUAL + idGrupoCC 
				+ Constantes.SIGNOAMPERSON + KEYQNROGRUPOCC + Constantes.SIGNOIGUAL + nroGrupoCC );
		
		}
		
	}
}
