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
using SIMA.EntidadesNegocio.GestionSeguridadIndustrial;
using SIMA.Controladoras.General;
using SIMA.Controladoras.GestionSeguridadIndustrial;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;



namespace SIMA.SimaNetWeb.GestionSeguridadIndustrial
{
	/// <summary>
	/// Summary description for RegistroIngNoProgramado.
	/// </summary>
	public class RegistroIngNoProgramado : System.Web.UI.Page,IPaginaBase
	{
		protected System.Web.UI.WebControls.TextBox txtTrabajador;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hFechaIniProg;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hFechaTermProg;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox txtMotivo;
		protected System.Web.UI.WebControls.TextBox txtAutorizadoPor;
		protected System.Web.UI.HtmlControls.HtmlImage btnAceptar;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnCancelar;
		protected System.Web.UI.WebControls.TextBox txtNroDNI;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnAgregarTrab3;
		protected System.Web.UI.WebControls.Label Label18;
		protected System.Web.UI.WebControls.TextBox txtNroDNIReg;
		protected System.Web.UI.WebControls.Label Label19;
		protected System.Web.UI.WebControls.TextBox txtApellidoP;
		protected System.Web.UI.WebControls.Label Label20;
		protected System.Web.UI.WebControls.TextBox txtApellidoM;
		protected System.Web.UI.WebControls.Label Label21;
		protected System.Web.UI.WebControls.TextBox txtNombres;
		protected System.Web.UI.WebControls.Label Label22;
		protected System.Web.UI.WebControls.DropDownList ddlNacionalidad;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.TextBox txtBuscarEntidad;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidEntidad;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdPersonalAutoriza;
		protected System.Web.UI.WebControls.TextBox txtTipoVisita;
		protected System.Web.UI.WebControls.Label Label14;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.TextBox txtRucNew1;
		protected System.Web.UI.WebControls.TextBox txtRSocialNew1;
		protected System.Web.UI.WebControls.Label Label4;

		public int IdTipoEntidad{
			get{return Convert.ToInt32(Page.Request.Params["idTipoEntidad"].ToString());}
		}
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					this.LlenarJScript();
					this.LlenarCombos();
					this.LlenarDatos();	
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(), "Gestión de Personal: Registro de programación - CONTRATISTA", this.ToString(),"Se ingreso a la funcionalidad de  registro de Programación(Ingreso y Modificación)",Enumerados.NivelesErrorLog.I.ToString()));
				}
				catch(SIMAExcepcionLog oSIMAExcepcionLog)
				{
					Helper.MsgBox(oSIMAExcepcionLog.Mensaje);					
				}
				catch(SIMAExcepcionIU oSIMAExcepcionIU)
				{
					Helper.MsgBox(oSIMAExcepcionIU.Mensaje);					
				}
				catch(SIMAExcepcionDominio oSIMAExcepcionDominio)
				{
					Helper.MsgBox(oSIMAExcepcionDominio.Mensaje);					
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

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add RegistroIngNoProgramado.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add RegistroIngNoProgramado.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add RegistroIngNoProgramado.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			const int IDTABLANACIONALIDAD = 458;
			this.ddlNacionalidad.DataSource = (new CTablaTablas()).ListaTodosCombo(IDTABLANACIONALIDAD);
			this.ddlNacionalidad.DataTextField = Enumerados.ColumnasTablasTablas.Var1.ToString();
			this.ddlNacionalidad.DataValueField = Enumerados.ColumnasTablasTablas.Codigo.ToString();
			this.ddlNacionalidad.DataBind();
		}

		public void LlenarDatos()
		{
			this.hFechaIniProg.Value= DateTime.Now.Year.ToString()+DateTime.Now.Month.ToString().PadLeft(2,'0')+DateTime.Now.Day.ToString().PadLeft(2,'0');
			this.hFechaTermProg.Value= this.hFechaIniProg.Value;
		}

		public void LlenarJScript()
		{
			//ddlTipoEntidad.Attributes.Add(Utilitario.Constantes.EVENTOONCHANGE,"ConfiguraBusquedaEntidad();");

			txtBuscarEntidad.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,"BusquedaEnDialogo();");
			string script = "<script>var IdTipoEnt='" + Page.Request.Params["idTipoEntidad"] + "';</script>";
			Page.Controls.Add(new LiteralControl(script));
		}

		public void RegistrarJScript()
		{
			// TODO:  Add RegistroIngNoProgramado.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add RegistroIngNoProgramado.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add RegistroIngNoProgramado.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add RegistroIngNoProgramado.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add RegistroIngNoProgramado.ValidarFiltros implementation
			return false;
		}

		#endregion
	}
}
