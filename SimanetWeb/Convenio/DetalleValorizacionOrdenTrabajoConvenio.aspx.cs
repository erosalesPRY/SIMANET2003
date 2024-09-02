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
using SIMA.EntidadesNegocio.Convenio;
using SIMA.Controladoras.Convenio;
using SIMA.Controladoras.General;
using SIMA.Controladoras;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using NullableTypes;

namespace SIMA.SimaNetWeb.Convenio
{
	/// <summary>
	/// Summary description for DetalleValorizacionOrdenTrabajoConvenio.
	/// </summary>
	public class DetalleValorizacionOrdenTrabajoConvenio : System.Web.UI.Page, IPaginaMantenimento, IPaginaBase
	{
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary DomValidationSummary1;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblProyecto;
		protected System.Web.UI.WebControls.TextBox txtDescripcionProyecto;
		protected System.Web.UI.WebControls.Label lblSubTitulo;
		protected System.Web.UI.WebControls.Label lblDivision;
		protected System.Web.UI.WebControls.DropDownList ddlbDivision;
		protected System.Web.UI.WebControls.Label lblNumero;
		protected eWorld.UI.NumericBox nbNumero;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rqdvNumero;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
	
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();

					Helper.ReiniciarSession();
					this.LlenarDatos();
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
					SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Utilitario.Constantes.CODIGOERRORGENERICO,oException.Message);
					Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
				}
			}
		}

		#region Constantes
		const string KEYIDCONVENIOSIMAMGP="IdConvenioSimaMgp";
		const string KEYIDPROYECTOCONVENIO="IdProyectoConvenio";
		const string KEYQNROCONVENIO="NroConvenio";
		const string KEYDESCRIPCIONPROYECTO="Descripcion";

		const string URLPRINCIPAL="AdministracionValorizacionOrdenTrabajoConvenio.aspx?";

		#endregion Constantes

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			ValorizacionOrdenTrabajoBE oValorizacionOrdenTrabajoBE=new ValorizacionOrdenTrabajoBE();
			oValorizacionOrdenTrabajoBE.NroValorizacion=this.ddlbDivision.SelectedItem.Text + Convert.ToInt32(this.nbNumero.Text).ToString("000000");
			oValorizacionOrdenTrabajoBE.IdProyectoConvenio=NullableInt32.Parse(this.Page.Request.Params[KEYIDPROYECTOCONVENIO]);

			CValorizacionOrdenTrabajoConvenio oCValorizacionOrdenTrabajoConvenio=new CValorizacionOrdenTrabajoConvenio();

			int retorno=oCValorizacionOrdenTrabajoConvenio.Insertar(oValorizacionOrdenTrabajoBE);

			if(retorno==Utilitario.Constantes.VALORCONFIRMACIONREGISTRO)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Convenio Sima Mgp",this.ToString(),"Se registró Item de Proyecto Convenio " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));

				string strUrlGoBack = URLPRINCIPAL + KEYIDPROYECTOCONVENIO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYIDPROYECTOCONVENIO] +
					Utilitario.Constantes.SIGNOAMPERSON + KEYIDCONVENIOSIMAMGP + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYIDCONVENIOSIMAMGP] + 
					Utilitario.Constantes.SIGNOAMPERSON + KEYQNROCONVENIO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYQNROCONVENIO] +
					Utilitario.Constantes.SIGNOAMPERSON + KEYDESCRIPCIONPROYECTO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYDESCRIPCIONPROYECTO];

				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionConvenios.ToString(),Mensajes.CONVENIOREGISTROVALORIZACION),strUrlGoBack.ToString());
			}
			else if(retorno==0)
			{
				ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerMensajesErrorConvenioUsuario(Utilitario.Mensajes.CONVENIOMENSAJEVALORIZACIONOEXISTE));
				//ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerMensajesErrorConvenioUsuario(Mensajes.CONVENIOMENSAJEVALORIZACIONOEXISTE));
			}
			else
			{
				ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerMensajesErrorConvenioUsuario("20001"));
			}
		}

		public void Modificar()
		{
			// TODO:  Add DetalleValorizacionOrdenTrabajoConvenio.Modificar implementation
		}

		public void Eliminar()
		{
			// TODO:  Add DetalleValorizacionOrdenTrabajoConvenio.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.Params[Utilitario.Constantes.KEYMODOPAGINA].ToString()) ;
			switch (oModoPagina)
			{
				case Enumerados.ModoPagina.N:
					this.CargarModoNuevo();
					break;
				case Enumerados.ModoPagina.M:
					this.CargarModoModificar();
					break;
			}			
		}

		public void CargarModoNuevo()
		{
		}

		public void CargarModoModificar()
		{
			// TODO:  Add DetalleValorizacionOrdenTrabajoConvenio.CargarModoModificar implementation
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add DetalleValorizacionOrdenTrabajoConvenio.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add DetalleValorizacionOrdenTrabajoConvenio.ValidarCampos implementation
			return true;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add DetalleValorizacionOrdenTrabajoConvenio.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add DetalleValorizacionOrdenTrabajoConvenio.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add DetalleValorizacionOrdenTrabajoConvenio.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetalleValorizacionOrdenTrabajoConvenio.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetalleValorizacionOrdenTrabajoConvenio.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			CTablaTablas oCTablaTablas=new CTablaTablas();
			DataView dv=oCTablaTablas.ListaSegunCriterioFiltro(Convert.ToInt32(Utilitario.Enumerados.TablasTabla.DivisionesOt),Utilitario.Enumerados.ColumnasTablaTablas.Flg1.ToString() + Utilitario.Constantes.SIGNOIGUAL + "1");
			this.ddlbDivision.DataSource=dv;
			this.ddlbDivision.DataValueField = Utilitario.Enumerados.ColumnasTablaTablas.Codigo.ToString();
			this.ddlbDivision.DataTextField = Utilitario.Enumerados.ColumnasTablaTablas.Var1.ToString();
			this.ddlbDivision.DataBind();
		}

		public void LlenarDatos()
		{
			this.lblTitulo.Text="Registrar Valorización >> CONVENIO SIMA MGP " + this.Page.Request.Params[KEYQNROCONVENIO];
			this.txtDescripcionProyecto.Text=this.Page.Request.Params[KEYDESCRIPCIONPROYECTO];
		}

		public void LlenarJScript()
		{
			this.rqdvNumero.ErrorMessage=Helper.ObtenerMensajesErrorConvenioUsuario(Mensajes.CONVENIOMENSAJEFALTAINGRESARVALORIZACION);
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetalleValorizacionOrdenTrabajoConvenio.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetalleValorizacionOrdenTrabajoConvenio.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetalleValorizacionOrdenTrabajoConvenio.Exportar implementation
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
			// TODO:  Add DetalleValorizacionOrdenTrabajoConvenio.ValidarFiltros implementation
			return false;
		}

		#endregion

//		private void ibtnCancelar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
//		{
//			this.Page.Response.Redirect(URLPRINCIPAL + KEYIDPROYECTOCONVENIO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYIDPROYECTOCONVENIO] +
//				Utilitario.Constantes.SIGNOAMPERSON + KEYIDCONVENIOSIMAMGP + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYIDCONVENIOSIMAMGP] + 
//				Utilitario.Constantes.SIGNOAMPERSON + KEYQNROCONVENIO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYQNROCONVENIO] +
//				Utilitario.Constantes.SIGNOAMPERSON + KEYDESCRIPCIONPROYECTO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYDESCRIPCIONPROYECTO]);
//		}

		private void ibtnAceptar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				if(Page.IsValid)
				{
					if(this.ValidarCampos())
					{
						Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.Params[Utilitario.Constantes.KEYMODOPAGINA]) ;
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
				string ex = oException.Message.ToString();
				SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Utilitario.Constantes.CODIGOERRORGENERICO,oException.Message);
				Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
			}

		}
	}
}
