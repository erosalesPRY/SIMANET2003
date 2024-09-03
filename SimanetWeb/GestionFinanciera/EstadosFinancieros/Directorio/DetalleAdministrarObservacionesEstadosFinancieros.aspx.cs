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
using SIMA.Controladoras.GestionFinanciera;
using SIMA.EntidadesNegocio.GestionFinanciera;
using SIMA.Utilitario;
using NetAccessControl;
using SIMA.ManejadorExcepcion;
using SIMA.Log;


namespace SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancieros.Directorio
{
	/// <summary>
	/// Summary description for DetalleAdministrarObservacionesEstadosFinancieros.
	/// </summary>
	public class DetalleAdministrarObservacionesEstadosFinancieros : System.Web.UI.Page,IPaginaMantenimento,IPaginaBase
	{
		
		#region constantes
		const string KEYQIDOBSERVACION="IdObservacion";
		const string KEYQIDEMPRESA = "idEmp";
		const string KEYQESOBSERVACION="Observacion";
		const string  KEYQIDCENTROOPERATIVO="IdCentroOperativo";
		const string  KEYQIDFECHA = "efFecha";
		const string  KEYQDIGRPNG="DigGrupoNG";
		const string  KEYMODOPAGINA = "Modo";
		const string  KEYQCUENTACONTABLE="CuentaContable";
		const string KEYQIDFORMATO = "IdFormato";
		const string KEYQNOMBRECUENTA="NombreCuenta";
		const string  KEYQDIDGRUPOCC="Idgrupocc";
		const string  KEYQIDCENTROCOSTO = "IdCentroCosto";
		const string  KEYQPERIODO = "periodo";
		const string  KEYQIDRUBRO = "IdRubro";
		const string KEYQESFECHACOMPLETA="FechaCompelta";
		const string KEYQNROPERSONAL = "Nropersonal";
		const string KEYLN ="LN";
		const string KEYQOT ="OT";
		const string KEYID="KEYID";
		const string KEYQTIPRCS="tip_rcs";
		const string KEYQCODRCS="cod_rcs";
		const string KEYQTIPOPERIODOPRESUPUESTO="KEYQTIPOPERIODOPRESUPUESTO";
		const string KEYQIDTIPOPROYECTOLIQUIDAR="KEYQIDTIPOPROYECTOLIQUIDAR";

		#endregion

		#region controles
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnCancelar;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.TextBox txtObservacion;
		protected System.Web.UI.WebControls.Label lblCorreoElectronico;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				if(!Page.IsPostBack)
				{
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarJScript();
					this.LlenarDatos();
					CargarModoPagina();
					
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
				ltlMensaje.Text = Helper.MsgdbErrMostrarMesaje(true,oSIMAExcepcionDominio.Error.ToString());					
			}
			catch(Exception oException)
			{
				string debug = oException.Message.ToString();
				SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
				Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
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
			ObservacionesEstadosFinancierosBE oObservacionesEstadosFinancierosBE= new ObservacionesEstadosFinancierosBE();
			if(Page.Request.QueryString[KEYQTIPRCS]!=null)
				oObservacionesEstadosFinancierosBE.Tip_rcs=Page.Request.QueryString[KEYQTIPRCS].ToString();

			if(Page.Request.QueryString[KEYQTIPOPERIODOPRESUPUESTO]!=null)
				oObservacionesEstadosFinancierosBE.IdPeriodoPresupuestado=Convert.ToInt32(Page.Request.QueryString[KEYQTIPOPERIODOPRESUPUESTO]);

			if(Page.Request.QueryString[KEYQCODRCS]!=null)
				oObservacionesEstadosFinancierosBE.Cod_rcs=Page.Request.QueryString[KEYLN].ToString();

			if(Page.Request.QueryString[KEYLN]!=null)
				oObservacionesEstadosFinancierosBE.LN=Page.Request.QueryString[KEYLN].ToString();

			if(Page.Request.QueryString[KEYQOT]!=null)
				oObservacionesEstadosFinancierosBE.OT=NullableTypes.NullableString.Parse(Page.Request.QueryString[KEYQOT]);
			
			if(Page.Request.QueryString[KEYID]!=null)
				oObservacionesEstadosFinancierosBE.IdLineaNegocio=Convert.ToInt32(Page.Request.QueryString[KEYID]);

			if(Page.Request.QueryString[KEYQCUENTACONTABLE]!=null)
				oObservacionesEstadosFinancierosBE.CuentaContable=Page.Request.QueryString[KEYQCUENTACONTABLE].ToString();

			if(Page.Request.QueryString[KEYQNROPERSONAL]!=null)
				oObservacionesEstadosFinancierosBE.NroPersonal=NullableTypes.NullableInt32.Parse(Page.Request.QueryString[KEYQNROPERSONAL]);

			if(Page.Request.QueryString[KEYQIDCENTROCOSTO]!=null)
				oObservacionesEstadosFinancierosBE.IdCentroCosto=Convert.ToInt32(Page.Request.QueryString[KEYQIDCENTROCOSTO]);
			else
				oObservacionesEstadosFinancierosBE.IdCentroCosto=NullableTypes.NullableInt32.Null;

			oObservacionesEstadosFinancierosBE.IdCentroOperativo=Convert.ToInt32(Page.Request.QueryString[KEYQIDCENTROOPERATIVO]);
			oObservacionesEstadosFinancierosBE.IdFormato=Convert.ToInt32(Page.Request.QueryString[KEYQIDFORMATO]);
			if(Page.Request.QueryString[KEYQDIDGRUPOCC]!=null)
				oObservacionesEstadosFinancierosBE.IdGrupocc=Convert.ToInt32(Page.Request.QueryString[KEYQDIDGRUPOCC]);
			else
				oObservacionesEstadosFinancierosBE.IdGrupocc=NullableTypes.NullableInt32.Null;

			if(Page.Request.QueryString[KEYQIDRUBRO]!=null)
				oObservacionesEstadosFinancierosBE.IdRubro=Convert.ToInt32(Page.Request.QueryString[KEYQIDRUBRO]);
			else
				oObservacionesEstadosFinancierosBE.IdRubro=NullableTypes.NullableInt32.Null;
			if(Page.Request.QueryString[KEYQIDEMPRESA]!=null)
				oObservacionesEstadosFinancierosBE.IdEmpresa=Convert.ToInt32(Page.Request.QueryString[KEYQIDEMPRESA]);
			else
				oObservacionesEstadosFinancierosBE.IdEmpresa=NullableTypes.NullableInt32.Null;

			if(Page.Request.QueryString[KEYQESFECHACOMPLETA]!=null)
				oObservacionesEstadosFinancierosBE.IdMes=Convert.ToDateTime(Page.Request.QueryString[KEYQIDFECHA]).Month;
			else
				oObservacionesEstadosFinancierosBE.IdMes=Convert.ToInt32(Page.Request.QueryString[KEYQIDFECHA]);

			oObservacionesEstadosFinancierosBE.IdUsuario=CNetAccessControl.GetIdUser();
			oObservacionesEstadosFinancierosBE.Observacion=txtObservacion.Text;
			if(Page.Request.QueryString[KEYQESFECHACOMPLETA]!=null)
				oObservacionesEstadosFinancierosBE.Periodo=Convert.ToDateTime(Page.Request.QueryString[KEYQIDFECHA]).Year;
			else
				oObservacionesEstadosFinancierosBE.Periodo=Convert.ToInt32(Page.Request.QueryString[KEYQPERIODO]);

			if(Page.Request.QueryString[KEYQIDTIPOPROYECTOLIQUIDAR]!=null)
				oObservacionesEstadosFinancierosBE.TipoProyectoPorLiquidar=NullableTypes.NullableInt32.Parse(Page.Request.QueryString[KEYQIDTIPOPROYECTOLIQUIDAR]);

			CEstadosFinancieros oCEstadosFinancieros = new CEstadosFinancieros();
			int i = oCEstadosFinancieros.Insertar(oObservacionesEstadosFinancierosBE);
			if(i==1)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Financiera",this.ToString(),"Se registró la observacion. " + i.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));
				ltlMensaje.Text = "Cerrar('1')";

			}
			
		}

		public void Modificar()
		{
			ObservacionesEstadosFinancierosBE oObservacionesEstadosFinancierosBE= new ObservacionesEstadosFinancierosBE();
			
			oObservacionesEstadosFinancierosBE.IdObservacion=Convert.ToInt32(Page.Request.QueryString[KEYQIDOBSERVACION]);
			oObservacionesEstadosFinancierosBE.IdUsuario=CNetAccessControl.GetIdUser();
			oObservacionesEstadosFinancierosBE.Observacion=txtObservacion.Text;
			

			CEstadosFinancieros oCEstadosFinancieros = new CEstadosFinancieros();
			int i = oCEstadosFinancieros.Modificar(oObservacionesEstadosFinancierosBE);
			if(i==1)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Financiera",this.ToString(),"Se registró la observacion. " + i.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));
				ltlMensaje.Text = "Cerrar('2')";

			}
		}

		public void Eliminar()
		{
			// TODO:  Add DetalleAdministrarObservacionesEstadosFinancieros.Eliminar implementation
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
			// TODO:  Add DetalleAdministrarObservacionesEstadosFinancieros.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			CEstadosFinancieros oCEstadosFinancieros = new CEstadosFinancieros();
			DataRow dr = oCEstadosFinancieros.ConsultarDetalleObservacion(Convert.ToInt32(Page.Request.QueryString[KEYQIDOBSERVACION])).Rows[0];
			if(dr!=null)
			{

				txtObservacion.Text=dr["observacion"].ToString();
			}
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add DetalleAdministrarObservacionesEstadosFinancieros.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add DetalleAdministrarObservacionesEstadosFinancieros.ValidarCampos implementation
			return true;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add DetalleAdministrarObservacionesEstadosFinancieros.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add DetalleAdministrarObservacionesEstadosFinancieros.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add DetalleAdministrarObservacionesEstadosFinancieros.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetalleAdministrarObservacionesEstadosFinancieros.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetalleAdministrarObservacionesEstadosFinancieros.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add DetalleAdministrarObservacionesEstadosFinancieros.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add DetalleAdministrarObservacionesEstadosFinancieros.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			ibtnCancelar.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,"Cancelar();");
			
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetalleAdministrarObservacionesEstadosFinancieros.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetalleAdministrarObservacionesEstadosFinancieros.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetalleAdministrarObservacionesEstadosFinancieros.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add DetalleAdministrarObservacionesEstadosFinancieros.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add DetalleAdministrarObservacionesEstadosFinancieros.ValidarFiltros implementation
			return false;
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
