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
using SIMA.Controladoras.Secretaria.Directorio;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using SIMA.EntidadesNegocio.Secretaria.Directorio;
using NetAccessControl;
using System.IO;

namespace SIMA.SimaNetWeb.DirectorioEjecutivo.Directorio
{
	/// <summary>
	/// Summary description for DetallePoderes.
	/// </summary>
	public class ConsultarDetalleAdquisicionesTerceros: System.Web.UI.Page, IPaginaBase
	{

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

		#region Constantes
		
		//Titulos 
		const string TEXTOFOOTERTOTAL = "Total:";
		const int POSICIONFOOTERTOTAL = 1;

		//Key Session y QueryString
		const string KEYQID = "Id";
		//Paginas
		
		#endregion Constantes

		#region Controles
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox txtFecha;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.TextBox txtConcepto;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox txtProveedor;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.TextBox txtMoneda;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.TextBox txtMonto;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtCentroOperativo;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.TextBox txtProyecto;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.TextBox txtNroContrato;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.TextBox txtFechaContrato;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.TextBox txtFechaTermino;
		protected System.Web.UI.WebControls.Label lblFechaTermino;
		protected System.Web.UI.WebControls.TextBox txtNroOrden;
		protected System.Web.UI.WebControls.Label lblFechaInicio;
		protected System.Web.UI.WebControls.TextBox txtFechaOrden;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.TextBox txtTipoOrden;
		protected System.Web.UI.WebControls.Label Label12;
		protected System.Web.UI.WebControls.TextBox txtMercado;

		#endregion Controles
	
		/// <summary>
		/// Llena el combo de Tipo Accion
		/// </summary>		

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

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add DetallePoderes.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetallePoderes.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
		}

		public void LlenarCombos()
		{
			//lItem = new ListItem(Constantes.TEXTOSSELECCIONAR,Constantes.VALORSELECCIONAR);
		}

		public void LlenarDatos()
		{
			// TODO:  Add DetallePoderes.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetallePoderes.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetallePoderes.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetallePoderes.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add DetallePoderes.ConfigurarAccesoControles implementation
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
			// TODO:  Add DetallePoderes.ValidarFiltros implementation
			return true;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
		}

		public void Modificar()
		{
		}

		public void Eliminar()
		{
			// TODO:  Add DetallePoderes.Eliminar implementation
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
		}

		public void CargarModoModificar()
		{
		}

		public void CargarModoConsulta()
		{
			CMantenimientos	oCMantenimientos = new CMantenimientos();
			AdquisicionesBE oAdquisicionesBE = (AdquisicionesBE )oCMantenimientos.ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYQID]),Enumerados.ClasesNTAD.AdquisicionesNTAD.ToString());
			
			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Disposiciones",this.ToString(),"Se consultó el Detalle de la Disposición Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

			if(oAdquisicionesBE !=null)
			{
				txtFecha.Text = oAdquisicionesBE.FechaAdquisicion.ToString(Constantes.FORMATOFECHA4);
				txtConcepto.Text = oAdquisicionesBE.ObjetoAdquisicion.ToString();
				txtProveedor.Text = oAdquisicionesBE.Proveedor.ToString();
				txtMercado.Text = oAdquisicionesBE.TipoMercado.ToString();
				txtMoneda.Text = oAdquisicionesBE.Moneda.ToString();
				txtMonto.Text = oAdquisicionesBE.MontoAdquisicion.ToString(Constantes.FORMATODECIMAL4);
				txtCentroOperativo.Text = oAdquisicionesBE.CentroOperativo.ToString();
				txtProyecto.Text = oAdquisicionesBE.Proyecto.ToString();
				txtNroContrato.Text = oAdquisicionesBE.NroContrato.ToString();
				txtFechaContrato.Text = oAdquisicionesBE.FechaContrato.ToString(Constantes.FORMATOFECHA4);

				if(!oAdquisicionesBE.FechaTerminoContrato.IsNull)
				{
					txtFechaTermino.Text = Convert.ToDateTime(oAdquisicionesBE.FechaTerminoContrato.ToString()).ToString(Constantes.FORMATOFECHA4);
				}
				txtNroOrden.Text = oAdquisicionesBE.NroCompra.ToString();
				txtFechaOrden.Text = oAdquisicionesBE.FechaOrden.ToString(Constantes.FORMATOFECHA4);
				txtTipoOrden.Text = oAdquisicionesBE.TipoAdquisicion.ToString();
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

			return true;		
		}

		public bool ValidarExpresionesRegulares()
		{
			return true;
		}

		#endregion

		private void ibtnAceptar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
		}

		private void redireccionaPaginaPrincipal()
		{
		}

	}
}