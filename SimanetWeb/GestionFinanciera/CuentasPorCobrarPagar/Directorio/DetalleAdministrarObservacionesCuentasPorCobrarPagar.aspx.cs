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
using SIMA.Controladoras.GestionFinanciera;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using SIMA.EntidadesNegocio.GestionFinanciera;
using NetAccessControl;
using System.IO;
namespace SIMA.SimaNetWeb.GestionFinanciera.CuentasPorCobrarPagar.Directorio
{
	/// <summary>
	/// Summary description for DetalleAdministrarObservacionesCuentasPorCobrarPagar.
	/// </summary>
	public class DetalleAdministrarObservacionesCuentasPorCobrarPagar : System.Web.UI.Page,IPaginaMantenimento,IPaginaBase
	{
		#region controles

		protected System.Web.UI.WebControls.Label lblDenominacion;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.TextBox txtObservacion;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion

		#region constantes
		const string TITULOMODONUEVO="NUEVA OBSERVACION";
		const string KEYQIDENTIDAD="KEYQIDENTIDAD";
		const string KEYQCUENTACONTABLE="KEYQCUENTACONTABLE";
		const string KEYQNROCLIENTE="KEYQNROCLIENTE";
		const string KEYQIDTIPOCUENTA="KEYQIDTIPOCUENTA";
		const string KEYQIDCUENTA="KEYQIDCUENTA";
		const string KEYQIDSUBCUENTA="KEYQIDSUBCUENTA";

		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtConcepto;
		const string TITULOMODOMODIFICAR="MODIFICAR OBSERVACION";
		const string KEYQIDCENTROOPERATIVO="IdCentro";
		const string KEYQNUMDOCANA="NUMDOCANA";
		const string KEYQNRORUC="NRORUC";
		NullableTypes.NullableInt32 idEntidad;
		NullableTypes.NullableInt32 cuentaContable;
		NullableTypes.NullableInt32 nroCliente;
		NullableTypes.NullableInt32 idTipoCuenta;
		NullableTypes.NullableInt32 idCuenta;
		NullableTypes.NullableInt32 idSubCuenta;
		NullableTypes.NullableString nroruc;
		protected System.Web.UI.WebControls.Image imgCancelar;
		protected System.Web.UI.HtmlControls.HtmlImage imgAceptar;
		NullableTypes.NullableString nrodocana;
		#endregion

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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaMantenimento Members

		/*public ObservacionesCuentaAnaliticaBE AsignarValoresEntidad()
		{
			ObservacionesCuentaAnaliticaBE oObservacionesCuentaAnaliticaBE= new ObservacionesCuentaAnaliticaBE();
			oObservacionesCuentaAnaliticaBE.IdCentroOperativo= Convert.ToInt32(Page.Request.QueryString[KEYQIDCENTROOPERATIVO]);
			
			if(Page.Request.QueryString[KEYQNRORUC]!=null)
				oObservacionesCuentaAnaliticaBE.Dist=Page.Request.QueryString[KEYQNRORUC].ToString();

			if(Page.Request.QueryString[KEYQNUMDOCANA]!=null)
				oObservacionesCuentaAnaliticaBE.Num_doc_ana=Page.Request.QueryString[KEYQNUMDOCANA].ToString();

			if( Page.Request.QueryString[KEYQIDENTIDAD]!=null)
				oObservacionesCuentaAnaliticaBE.IdEntidad=NullableTypes.NullableInt32.Parse(Page.Request.QueryString[KEYQIDENTIDAD]);

			if( Page.Request.QueryString[KEYQCUENTACONTABLE]!=null)
				oObservacionesCuentaAnaliticaBE.CuentaContable=NullableTypes.NullableInt32.Parse(Page.Request.QueryString[KEYQCUENTACONTABLE]);

			if( Page.Request.QueryString[KEYQNROCLIENTE]!=null)
				oObservacionesCuentaAnaliticaBE.NroCliente=NullableTypes.NullableInt32.Parse(Page.Request.QueryString[KEYQNROCLIENTE]);

			if( Page.Request.QueryString[KEYQIDTIPOCUENTA]!=null)
				oObservacionesCuentaAnaliticaBE.IdTipoCuenta=NullableTypes.NullableInt32.Parse(Page.Request.QueryString[KEYQIDTIPOCUENTA]);

			if( Page.Request.QueryString[KEYQIDCUENTA]!=null)
				oObservacionesCuentaAnaliticaBE.IdCuenta=NullableTypes.NullableInt32.Parse(Page.Request.QueryString[KEYQIDCUENTA]);

			if( Page.Request.QueryString[KEYQIDSUBCUENTA]!=null)
				oObservacionesCuentaAnaliticaBE.IdSubCuenta=NullableTypes.NullableInt32.Parse(Page.Request.QueryString[KEYQIDSUBCUENTA]);

			oObservacionesCuentaAnaliticaBE.Observaciones=txtObservacion.Text;
			oObservacionesCuentaAnaliticaBE.IdUsuario=CNetAccessControl.GetIdUser();
			oObservacionesCuentaAnaliticaBE.Concepto=txtConcepto.Text;

			return oObservacionesCuentaAnaliticaBE;
		}
		*/

		public void Agregar()
		{
			ObservacionesCuentaAnaliticaBE oObservacionesCuentaAnaliticaBE= new ObservacionesCuentaAnaliticaBE();
			oObservacionesCuentaAnaliticaBE.IdCentroOperativo= Convert.ToInt32(Page.Request.QueryString[KEYQIDCENTROOPERATIVO]);
			
			if(Page.Request.QueryString[KEYQNRORUC]!=null)
				oObservacionesCuentaAnaliticaBE.Dist=Page.Request.QueryString[KEYQNRORUC].ToString();

			if(Page.Request.QueryString[KEYQNUMDOCANA]!=null)
				oObservacionesCuentaAnaliticaBE.Num_doc_ana=Page.Request.QueryString[KEYQNUMDOCANA].ToString();

			if( Page.Request.QueryString[KEYQIDENTIDAD]!=null)
				oObservacionesCuentaAnaliticaBE.IdEntidad=NullableTypes.NullableInt32.Parse(Page.Request.QueryString[KEYQIDENTIDAD]);

			if( Page.Request.QueryString[KEYQCUENTACONTABLE]!=null)
				oObservacionesCuentaAnaliticaBE.CuentaContable=NullableTypes.NullableInt32.Parse(Page.Request.QueryString[KEYQCUENTACONTABLE]);

			if( Page.Request.QueryString[KEYQNROCLIENTE]!=null)
				oObservacionesCuentaAnaliticaBE.NroCliente=NullableTypes.NullableInt32.Parse(Page.Request.QueryString[KEYQNROCLIENTE]);

			if( Page.Request.QueryString[KEYQIDTIPOCUENTA]!=null)
				oObservacionesCuentaAnaliticaBE.IdTipoCuenta=NullableTypes.NullableInt32.Parse(Page.Request.QueryString[KEYQIDTIPOCUENTA]);

			if( Page.Request.QueryString[KEYQIDCUENTA]!=null)
				oObservacionesCuentaAnaliticaBE.IdCuenta=NullableTypes.NullableInt32.Parse(Page.Request.QueryString[KEYQIDCUENTA]);

			if( Page.Request.QueryString[KEYQIDSUBCUENTA]!=null)
				oObservacionesCuentaAnaliticaBE.IdSubCuenta=NullableTypes.NullableInt32.Parse(Page.Request.QueryString[KEYQIDSUBCUENTA]);

			oObservacionesCuentaAnaliticaBE.Observaciones=txtObservacion.Text;
			oObservacionesCuentaAnaliticaBE.IdUsuario=CNetAccessControl.GetIdUser();
			oObservacionesCuentaAnaliticaBE.Concepto=txtConcepto.Text;

			//ltlMensaje.Text="InsertarObservaciones('"+oObservacionesCuentaAnaliticaBE.IdCentroOperativo+"','"+oObservacionesCuentaAnaliticaBE.Dist +"','"+oObservacionesCuentaAnaliticaBE.Num_doc_ana+"','"+oObservacionesCuentaAnaliticaBE.IdEntidad+"','"+oObservacionesCuentaAnaliticaBE.CuentaContable+"','"+oObservacionesCuentaAnaliticaBE.NroCliente+"','"+oObservacionesCuentaAnaliticaBE.IdTipoCuenta+"','"+oObservacionesCuentaAnaliticaBE.IdCuenta+"','"+oObservacionesCuentaAnaliticaBE.IdSubCuenta+"','"+txtObservacion.Text+"','"+txtConcepto.Text+"','"+CNetAccessControl.GetIdUser()+"');";

			/*
			CCuentasPorCobrarPagar oCCuentasPorCobrarPagar = new CCuentasPorCobrarPagar();
			int retorno = oCCuentasPorCobrarPagar.InsertarObservacionesCuentaAnalitica(oObservacionesCuentaAnaliticaBE);

			if(retorno>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"FINANCIERA",this.ToString(),"Se registró la observacion Nro. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));

				ltlMensaje.Text = "Cerrar('1')";
			}
			*/

		}

		public void Modificar()
		{
			ObservacionesCuentaAnaliticaBE oObservacionesCuentaAnaliticaBE= new ObservacionesCuentaAnaliticaBE();
			oObservacionesCuentaAnaliticaBE.IdCentroOperativo= Convert.ToInt32(Page.Request.QueryString[KEYQIDCENTROOPERATIVO]);
			if(Page.Request.QueryString[KEYQNRORUC]!=null)
				oObservacionesCuentaAnaliticaBE.Dist=Page.Request.QueryString[KEYQNRORUC].ToString();

			if(Page.Request.QueryString[KEYQNUMDOCANA]!=null)
				oObservacionesCuentaAnaliticaBE.Num_doc_ana=Page.Request.QueryString[KEYQNUMDOCANA].ToString();
			
			if( Page.Request.QueryString[KEYQIDENTIDAD]!=null)
				oObservacionesCuentaAnaliticaBE.IdEntidad=NullableTypes.NullableInt32.Parse(Page.Request.QueryString[KEYQIDENTIDAD]);

			if( Page.Request.QueryString[KEYQCUENTACONTABLE]!=null)
				oObservacionesCuentaAnaliticaBE.CuentaContable=NullableTypes.NullableInt32.Parse(Page.Request.QueryString[KEYQCUENTACONTABLE]);

			if( Page.Request.QueryString[KEYQNROCLIENTE]!=null)
				oObservacionesCuentaAnaliticaBE.NroCliente=NullableTypes.NullableInt32.Parse(Page.Request.QueryString[KEYQNROCLIENTE]);

			if( Page.Request.QueryString[KEYQIDTIPOCUENTA]!=null)
				oObservacionesCuentaAnaliticaBE.IdTipoCuenta=NullableTypes.NullableInt32.Parse(Page.Request.QueryString[KEYQIDTIPOCUENTA]);

			if( Page.Request.QueryString[KEYQIDCUENTA]!=null)
				oObservacionesCuentaAnaliticaBE.IdCuenta=NullableTypes.NullableInt32.Parse(Page.Request.QueryString[KEYQIDCUENTA]);

			if( Page.Request.QueryString[KEYQIDSUBCUENTA]!=null)
				oObservacionesCuentaAnaliticaBE.IdSubCuenta=NullableTypes.NullableInt32.Parse(Page.Request.QueryString[KEYQIDSUBCUENTA]);

			oObservacionesCuentaAnaliticaBE.Observaciones=txtObservacion.Text;
			oObservacionesCuentaAnaliticaBE.IdUsuario=CNetAccessControl.GetIdUser();
			oObservacionesCuentaAnaliticaBE.Concepto=txtConcepto.Text;

			CCuentasPorCobrarPagar oCCuentasPorCobrarPagar = new CCuentasPorCobrarPagar();
			int retorno = oCCuentasPorCobrarPagar.ModificarObservacionesCuentaAnalitica(oObservacionesCuentaAnaliticaBE);

			if(retorno>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"FINANCIERA",this.ToString(),"Se modifico la observacion Nro. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));

				ltlMensaje.Text = "Cerrar('2')";
			}

		}

		public void Eliminar()
		{
			// TODO:  Add DetalleAdministrarObservacionesCuentasPorCobrarPagar.Eliminar implementation
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
			CCuentasPorCobrarPagar oCCuentasPorCobrarPagar = new CCuentasPorCobrarPagar();
		
			
			if(Page.Request.QueryString[KEYQNRORUC]!=null)
				nroruc=NullableTypes.NullableString.Parse(Page.Request.QueryString[KEYQNRORUC]);

			if(Page.Request.QueryString[KEYQNUMDOCANA]!=null)
				nrodocana=NullableTypes.NullableString.Parse(Page.Request.QueryString[KEYQNUMDOCANA]);

			if( Page.Request.QueryString[KEYQIDENTIDAD]!=null)
				idEntidad=NullableTypes.NullableInt32.Parse(Page.Request.QueryString[KEYQIDENTIDAD]);

			if( Page.Request.QueryString[KEYQCUENTACONTABLE]!=null)
				cuentaContable=NullableTypes.NullableInt32.Parse(Page.Request.QueryString[KEYQCUENTACONTABLE]);

			if( Page.Request.QueryString[KEYQNROCLIENTE]!=null)
				nroCliente=NullableTypes.NullableInt32.Parse(Page.Request.QueryString[KEYQNROCLIENTE]);

			if( Page.Request.QueryString[KEYQIDTIPOCUENTA]!=null)
				idTipoCuenta=NullableTypes.NullableInt32.Parse(Page.Request.QueryString[KEYQIDTIPOCUENTA]);

			if( Page.Request.QueryString[KEYQIDCUENTA]!=null)
				idCuenta=NullableTypes.NullableInt32.Parse(Page.Request.QueryString[KEYQIDCUENTA]);

			if( Page.Request.QueryString[KEYQIDSUBCUENTA]!=null)
				idSubCuenta=NullableTypes.NullableInt32.Parse(Page.Request.QueryString[KEYQIDSUBCUENTA]);

			DataRow dr = oCCuentasPorCobrarPagar.ConsultarDetalleObservaciones(Convert.ToInt32(Page.Request.QueryString[KEYQIDCENTROOPERATIVO]),
				nroruc,nrodocana,idEntidad,cuentaContable,nroCliente,idTipoCuenta,idCuenta,idSubCuenta);
																				
						
			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"FINANCIERA",this.ToString(),"Se consultó el Detalle de la observacion Nro. " + "" + ".",Enumerados.NivelesErrorLog.I.ToString()));

			if(dr!=null)
			{
				txtObservacion.Text=dr["observacion"].ToString();
				txtConcepto.Text=dr["concepto"].ToString();
			}
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add DetalleAdministrarObservacionesCuentasPorCobrarPagar.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add DetalleAdministrarObservacionesCuentasPorCobrarPagar.ValidarCampos implementation
			return true;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add DetalleAdministrarObservacionesCuentasPorCobrarPagar.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add DetalleAdministrarObservacionesCuentasPorCobrarPagar.ValidarExpresionesRegulares implementation
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
		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add DetalleAdministrarObservacionesCuentasPorCobrarPagar.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetalleAdministrarObservacionesCuentasPorCobrarPagar.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetalleAdministrarObservacionesCuentasPorCobrarPagar.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add DetalleAdministrarObservacionesCuentasPorCobrarPagar.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add DetalleAdministrarObservacionesCuentasPorCobrarPagar.LlenarDatos implementation
		}

		public void LlenarJScript()
        {			
			imgCancelar.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,"window.close();");
			
			ObservacionesCuentaAnaliticaBE oObservacionesCuentaAnaliticaBE = new ObservacionesCuentaAnaliticaBE();
			//oObservacionesCuentaAnaliticaBE= AsignarValoresEntidad();
			string idco=oObservacionesCuentaAnaliticaBE.IdCentroOperativo.ToString();
			string dist=oObservacionesCuentaAnaliticaBE.Dist.ToString();
			string numdoc=oObservacionesCuentaAnaliticaBE.Num_doc_ana.ToString();
			string identidad=oObservacionesCuentaAnaliticaBE.IdEntidad.ToString();
			string cuenta =oObservacionesCuentaAnaliticaBE.CuentaContable.ToString();
			string nrocliente =oObservacionesCuentaAnaliticaBE.NroCliente.ToString();
			string tipocuenta =oObservacionesCuentaAnaliticaBE.IdTipoCuenta.ToString();
			string idcuenta =oObservacionesCuentaAnaliticaBE.IdCuenta.ToString();
			string idsubcuenta =oObservacionesCuentaAnaliticaBE.IdSubCuenta.ToString();


			Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.QueryString[Constantes.KEYMODOPAGINA]) ;

			switch (oModoPagina)
			{
				case Enumerados.ModoPagina.N:
					imgAceptar.Attributes.Add("onclick","InsertarObservaciones('"+idco+"','"+ dist+"','"+numdoc+"','"+identidad+"','"+cuenta+"','"+nrocliente+"','"+tipocuenta+"','"+idcuenta+"','"+idsubcuenta+"','"+CNetAccessControl.GetIdUser()+"');");
					break;
				case Enumerados.ModoPagina.M:
					imgAceptar.Attributes.Add("onclick","ModificarObservaciones('"+idco+"','"+ dist+"','"+numdoc+"','"+identidad+"','"+cuenta+"','"+nrocliente+"','"+tipocuenta+"','"+idcuenta+"','"+idsubcuenta+"','"+CNetAccessControl.GetIdUser()+"');");
					break;
			}
			
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetalleAdministrarObservacionesCuentasPorCobrarPagar.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetalleAdministrarObservacionesCuentasPorCobrarPagar.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetalleAdministrarObservacionesCuentasPorCobrarPagar.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add DetalleAdministrarObservacionesCuentasPorCobrarPagar.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add DetalleAdministrarObservacionesCuentasPorCobrarPagar.ValidarFiltros implementation
			return false;
		}

		#endregion
	}
}
