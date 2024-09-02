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
using SIMA.Controladoras.Parametros;
using SIMA.Controladoras.General;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using NullableTypes;
using MetaBuilders.WebControls;
using SIMA.EntidadesNegocio.Parametros;


namespace SIMA.SimaNetWeb.GestionControlInstitucional
{
	/// <summary>
	/// Summary description for DetalleAdministrarOrganismoAccionSubAccion.
	/// </summary>
	public class DetalleAdministrarOrganismoAccionSubAccion : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		#region controles
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Literal ltlMensaje; 
		#endregion controles

		#region Constantes
		
		//Titulos 
		const string TITULOMODONUEVO = "NUEVA OBSERVACION";
		const string TITULOMODOMODIFICAR = "OBSERVACION";

		//Key Session y QueryString
		const string KEYQID = "Id";
		const string KEYQIDCODIGO = "Codigo";
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.TextBox txtOrganismo;
	
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;

		//Paginas
	

		#endregion Constantes
	
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
			this.txtOrganismo.TextChanged += new System.EventHandler(this.txtOrganismo_TextChanged);
			this.ibtnAceptar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAceptar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add DetalleAdministrarOrganismoAccionSubAccion.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetalleAdministrarOrganismoAccionSubAccion.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetalleAdministrarOrganismoAccionSubAccion.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add DetalleAdministrarOrganismoAccionSubAccion.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add DetalleAdministrarOrganismoAccionSubAccion.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add DetalleAdministrarOrganismoAccionSubAccion.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetalleAdministrarOrganismoAccionSubAccion.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetalleAdministrarOrganismoAccionSubAccion.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetalleAdministrarOrganismoAccionSubAccion.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add DetalleAdministrarOrganismoAccionSubAccion.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add DetalleAdministrarOrganismoAccionSubAccion.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			ParametrosBE  oParametrosBE = new ParametrosBE();
			CParametros oCParametros = new CParametros();

			oParametrosBE.IdCabeceraTablaTablas  = Convert.ToInt32(Page.Request.QueryString[KEYQID]);
		
			oParametrosBE.Estado = "1";
			oParametrosBE.Descripcion = txtOrganismo.Text;
			oParametrosBE.Flg=NullableString.Null;
			oParametrosBE.Flg1=NullableString.Null;
			oParametrosBE.Flg2=NullableString.Null;
			oParametrosBE.Var1=NullableString.Null;
			oParametrosBE.Var2=NullableString.Null;
			oParametrosBE.Var3=NullableString.Null;
			int nuevoCodigo=(int)oCParametros.ObtenerCodigo(Convert.ToInt32(Page.Request.QueryString[KEYQID]))["codigo"] + 1;
			oParametrosBE.Codigo = nuevoCodigo;
			
			int retorno=0;
			CMantenimientosParametros oCMantenimientosParametros = new CMantenimientosParametros();
			retorno = oCMantenimientosParametros.Insertar(oParametrosBE);
		
			if(retorno>0)
			{
				//Graba en el Log la acción ejecutada				
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),
					"Parametros",this.ToString(),"Se registró el Parametro Nro. " + retorno.ToString() + ".",
					Enumerados.NivelesErrorLog.I.ToString()));

				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString
					(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),
					Mensajes.CODIGOMENSAJECONFIRMACIONREGISTROPARAMETROS));
			}
		}

		public void Modificar()
		{
			ParametrosBE  oParametrosBE = new ParametrosBE();
			CParametros oCParametros = new CParametros();

			oParametrosBE.IdCabeceraTablaTablas  = Convert.ToInt32(Page.Request.QueryString[KEYQID]);
		
			oParametrosBE.Estado = "1";
			oParametrosBE.Descripcion = txtOrganismo.Text;
			oParametrosBE.Flg=NullableString.Null;
			oParametrosBE.Flg1=NullableString.Null;
			oParametrosBE.Flg2=NullableString.Null;
			oParametrosBE.Var1=NullableString.Null;
			oParametrosBE.Var2=NullableString.Null;
			oParametrosBE.Var3=NullableString.Null;
			oParametrosBE.Codigo = Convert.ToInt32(Page.Request.QueryString[KEYQIDCODIGO]);
			
			int retorno=0;
			CMantenimientosParametros oCMantenimientosParametros = new CMantenimientosParametros();
			retorno=oCParametros.Modificar(oParametrosBE);
			if(retorno>0)
			{
				//Graba en el Log la acción ejecutada				
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),
					"Parametros",this.ToString(),"Se modifico el Parametro Nro. " + retorno.ToString() + ".",
					Enumerados.NivelesErrorLog.I.ToString()));
				this.ltlMensaje.Text=Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionConvenios.ToString(),Utilitario.Mensajes.CODIGOMENSAJECONFIRMACIONMODIFICACIONREGISTROSELECCIONADO));
			}
		
			
		}

		public void Eliminar()
		{
			// TODO:  Add DetalleAdministrarOrganismoAccionSubAccion.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.QueryString[Utilitario.Constantes.KEYMODOPAGINA]) ;

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
			// TODO:  Add DetalleAdministrarOrganismoAccionSubAccion.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			CMantenimientosParametros  oCMantenimientosParametros = new CMantenimientosParametros();
						
			int IdCabeceraTablaTablas; 
			int Codigo;
			IdCabeceraTablaTablas = Convert.ToInt32(Page.Request.QueryString[KEYQID]);
			Codigo = Convert.ToInt32(this.Page.Request.Params[KEYQIDCODIGO]);
			ParametrosBE oParametrosBE=(ParametrosBE)oCMantenimientosParametros.ListarDetalleParametro(IdCabeceraTablaTablas,Codigo);
		
			if(oParametrosBE!=null)
			{
				
				txtOrganismo.Text = oParametrosBE.Descripcion.ToString();
			
	
			
			}
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add DetalleAdministrarOrganismoAccionSubAccion.CargarModoConsulta implementation
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
			if(txtOrganismo.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert("Ingrese el nombre del Organismo");
				return false;	
			}
			return true;

		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add DetalleAdministrarOrganismoAccionSubAccion.ValidarExpresionesRegulares implementation
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
						Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.QueryString[Utilitario.Constantes.KEYMODOPAGINA]) ;

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
				SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Utilitario.Constantes.CODIGOERRORGENERICO,oException.Message);
				Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
			}
		}

		private void txtOrganismo_TextChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
