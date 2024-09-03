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

namespace SIMA.SimaNetWeb.GestionFinanciera.Procesos
{
	/// <summary>
	/// Summary description for DefaultProcesos.
	/// </summary>
	public class DefaultProcesos : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{

		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Panel Panel;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hTabSeleccionado;
		protected System.Web.UI.HtmlControls.HtmlTable TblTabs;
	

		#region Constantes
		const string GRILLAVACIA="No exiets";
		const string OBJPARAMETROCONTABLE="ParametroContable";			
		const string KEYIDEMPRESA ="idEmp";
		protected System.Web.UI.HtmlControls.HtmlInputHidden hListaProcesos;
		const string URLCONTROLUSUARIOPARAMETROCONTABLE = "../../ControlesUsuario/GestionFinanciera/ParametroContable.ascx";
		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			this.CargarControl();
			this.LlenarDatos();

		}
		
		
		private void CargarControl()
		{			

			if (Session[OBJPARAMETROCONTABLE]==null)
			{
				ControlesUsuario.GestionFinanciera.ParametroContable usc_ParametroContable = (ControlesUsuario.GestionFinanciera.ParametroContable)LoadControl(URLCONTROLUSUARIOPARAMETROCONTABLE);
				//usc_ParametroContable.IdEmpresa = Convert.ToInt32(Page.Request.Params[KEYIDEMPRESA]);
				//usc_ParametroContable.VerCentroOperativo = true;
				usc_ParametroContable.VerCentroOperativoTODOS = true;
				usc_ParametroContable.VerPeriodo = true;
				usc_ParametroContable.VerMes = true;
				usc_ParametroContable.VerTipoInformacion = false;
				usc_ParametroContable.VerEntidadFinanciera=false;
				Panel.Controls.Clear();
				Panel.Controls.Add(usc_ParametroContable);
				Session[OBJPARAMETROCONTABLE] = usc_ParametroContable;
			}
			else	//Aca entra en caso de Estado de Ganacias y Perdidas
			{
				ControlesUsuario.GestionFinanciera.ParametroContable usc_ParametroContable = (ControlesUsuario.GestionFinanciera.ParametroContable)Session[OBJPARAMETROCONTABLE];
				usc_ParametroContable.EnabledCentroOperativo=true;
				usc_ParametroContable.EnabledPeriodo=true;
				usc_ParametroContable.EnabledMes =true;				
				usc_ParametroContable.EnabledTipoInformacion=true;
				Panel.Controls.Clear();
				Panel.Controls.Add(usc_ParametroContable);
				Session[OBJPARAMETROCONTABLE] = usc_ParametroContable;
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

		private DataTable ObtenerDatos()
		{
			const int IDMODULO=5;
			return ((CTablasParametros) new CTablasParametros()).ListarGrupodeProcesos(IDMODULO);
		}

		public void LlenarGrilla()
		{
			// TODO:  Add DefaultProcesos.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DefaultProcesos.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DefaultProcesos.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add DefaultProcesos.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			hListaProcesos.Value="";
			const string Delimitador ="[@]";
			DataTable dt = this.ObtenerDatos();
			foreach(DataRow dr in dt.Rows)
			{
				hListaProcesos.Value += dr["idGrupodeProceso"].ToString() + ";" + dr["DescripciondelGrupodeProceso"].ToString() + Delimitador;
			}
			hListaProcesos.Value = hListaProcesos.Value.ToString().Substring(0,hListaProcesos.Value.ToString().Length- (Delimitador.Length+1));
		}
		

		public void LlenarJScript()
		{
			// TODO:  Add DefaultProcesos.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DefaultProcesos.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DefaultProcesos.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DefaultProcesos.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add DefaultProcesos.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add DefaultProcesos.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			// TODO:  Add DefaultProcesos.Agregar implementation
		}

		public void Modificar()
		{
			// TODO:  Add DefaultProcesos.Modificar implementation
		}

		public void Eliminar()
		{
			// TODO:  Add DefaultProcesos.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			// TODO:  Add DefaultProcesos.CargarModoPagina implementation
		}

		public void CargarModoNuevo()
		{
			// TODO:  Add DefaultProcesos.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			// TODO:  Add DefaultProcesos.CargarModoModificar implementation
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add DefaultProcesos.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add DefaultProcesos.ValidarCampos implementation
			return false;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add DefaultProcesos.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add DefaultProcesos.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion
	}
}
