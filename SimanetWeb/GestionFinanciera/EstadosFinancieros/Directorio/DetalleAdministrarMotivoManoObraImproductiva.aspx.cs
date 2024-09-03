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
	/// Summary description for DetalleAdministrarMotivoManoObraImproductiva.
	/// </summary>
	public class DetalleAdministrarMotivoManoObraImproductiva : System.Web.UI.Page,IPaginaMantenimento,IPaginaBase
	{

		#region controles

		protected System.Web.UI.WebControls.Label lblCorreoElectronico;
		protected System.Web.UI.WebControls.TextBox txtMotivo;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnCancelar;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion

		#region constantes y variables
		const string KEYQANO = "ano";
		const string KEYQMES="mes";
		const string KEYIDCENTRO ="IdCentro";
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		const string  KEYQID        = "ID";

		protected int nroPersonal
		{
			get
			{
				return Convert.ToInt32(Page.Request.Params[KEYQID]);
			}
		}
		protected int idCentro
		{
			get
			{
				return Convert.ToInt32(Page.Request.Params[KEYIDCENTRO]);
			}
		}
		protected int idMes
		{
			get
			{
				return Convert.ToInt32(Page.Request.Params[KEYQMES]);
			}
		}
		protected int Periodo
		{
			get
			{
				return Convert.ToInt32(Page.Request.Params[KEYQANO]);
			}
		}
		#endregion
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				if(!Page.IsPostBack)
				{
					//this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarJScript();
					//this.LlenarDatos();
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
			MotivoManoObraImproductivaBE oMotivoManoObraImproductivaBE = new MotivoManoObraImproductivaBE();
			oMotivoManoObraImproductivaBE.Motivo=txtMotivo.Text;
			oMotivoManoObraImproductivaBE.NroPersonal=nroPersonal;
			oMotivoManoObraImproductivaBE.IdCentroOperativo=idCentro;
			oMotivoManoObraImproductivaBE.Idmes=idMes;
			oMotivoManoObraImproductivaBE.Periodo=Periodo;
			oMotivoManoObraImproductivaBE.IdUsuario=CNetAccessControl.GetIdUser();

			CEstadosFinancieros oCEstadosFinancieros = new CEstadosFinancieros();
			int i = oCEstadosFinancieros.InsertarMotivo(oMotivoManoObraImproductivaBE);
			if(i==1)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Financiera",this.ToString(),"Se registró la observacion. " + i.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));
				ltlMensaje.Text = "Cerrar('1')";

			}
		}

		public void Modificar()
		{
			MotivoManoObraImproductivaBE oMotivoManoObraImproductivaBE = new MotivoManoObraImproductivaBE();
			oMotivoManoObraImproductivaBE.Motivo=txtMotivo.Text;
			oMotivoManoObraImproductivaBE.NroPersonal=nroPersonal;
			oMotivoManoObraImproductivaBE.IdCentroOperativo=idCentro;
			oMotivoManoObraImproductivaBE.Idmes=idMes;
			oMotivoManoObraImproductivaBE.Periodo=Periodo;
			oMotivoManoObraImproductivaBE.IdUsuario=CNetAccessControl.GetIdUser();

			CEstadosFinancieros oCEstadosFinancieros = new CEstadosFinancieros();
			int i = oCEstadosFinancieros.ActualizarMotivo(oMotivoManoObraImproductivaBE);
			if(i==1)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Financiera",this.ToString(),"Se registró la observacion. " + i.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));
				ltlMensaje.Text = "Cerrar('2')";

			}
		}

		public void Eliminar()
		{
			// TODO:  Add DetalleAdministrarMotivoManoObraImproductiva.Eliminar implementation
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
			// TODO:  Add DetalleAdministrarMotivoManoObraImproductiva.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			CEstadosFinancieros oCEstadosFinancieros = new CEstadosFinancieros();
			DataTable dt = oCEstadosFinancieros.ConsultarDetalleMotivoManoObraImproductiva(nroPersonal,idCentro,idMes,Periodo);
			if(dt!=null)
			{

				txtMotivo.Text=dt.Rows[0]["motivo"].ToString();
			}
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add DetalleAdministrarMotivoManoObraImproductiva.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add DetalleAdministrarMotivoManoObraImproductiva.ValidarCampos implementation
			return true;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add DetalleAdministrarMotivoManoObraImproductiva.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add DetalleAdministrarMotivoManoObraImproductiva.ValidarExpresionesRegulares implementation
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
			// TODO:  Add DetalleAdministrarMotivoManoObraImproductiva.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetalleAdministrarMotivoManoObraImproductiva.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetalleAdministrarMotivoManoObraImproductiva.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add DetalleAdministrarMotivoManoObraImproductiva.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add DetalleAdministrarMotivoManoObraImproductiva.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			ibtnCancelar.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,"Cancelar();");
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetalleAdministrarMotivoManoObraImproductiva.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetalleAdministrarMotivoManoObraImproductiva.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetalleAdministrarMotivoManoObraImproductiva.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add DetalleAdministrarMotivoManoObraImproductiva.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add DetalleAdministrarMotivoManoObraImproductiva.ValidarFiltros implementation
			return false;
		}

		#endregion
	}
}
