using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using SIMA.SimaNetWeb.InterfacesIU;
using SIMA.Controladoras.General;
using SIMA.EntidadesNegocio.General;
using SIMA.Controladoras.GestionFinanciera;
using SIMA.EntidadesNegocio.GestionFinanciera;
using SIMA.Utilitario;
using NetAccessControl;
using SIMA.ManejadorExcepcion;
using SIMA.Log;

namespace SIMA.SimaNetWeb.General.Formato
{
	/// <summary>
	/// Summary description for defaultFormatoMovimiento.
	/// </summary>
	public class defaultFormatoMovimiento : System.Web.UI.Page,IPaginaBase
	{
		const string KEYQIDGRUPOFORMATO="IdGrupoFormato";
		const string KEYIDEMPRESA ="idEmp";

		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hTabSeleccionado;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigoFormato;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.DropDownList ddlPeriodo;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.DropDownList ddlTipoInformacion;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.DropDownList ddlCentroOperativo;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.DropDownList ddlGrupoCentroCosto;
		protected System.Web.UI.WebControls.DropDownList ddlCentroCosto;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGrupoCC;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCentroCosto;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hPeriodo;
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
					this.LlenarCombos();
					this.LlenarDatos();
					this.LlenarGrilla();
					
				}
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
				string debug = oException.Message.ToString();
				SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
				Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
			}
			
		}
		#region Combos
		void LlenarCentroOperativo()
		{
			this.ddlCentroOperativo.DataSource = (new CCentroOperativo()).ListarCentroOperativoAccesoSegunPrivilegioUsuarioFormato(CNetAccessControl.GetIdUser(),Convert.ToInt32(Page.Request.Params[KEYIDEMPRESA]));
			this.ddlCentroOperativo.DataTextField= Enumerados.ColumnasCentroOperativo.Nombre.ToString();
			this.ddlCentroOperativo.DataValueField=Enumerados.ColumnasCentroOperativo.IdCentroOperativo.ToString();
			this.ddlCentroOperativo.DataBind();
		}
		void LlenarTipoInformacion()
		{
			this.ddlTipoInformacion.DataSource=(new CTablaTablas()).AccesoUsuarioTipoInformacion(Convert.ToInt32(this.ddlCentroOperativo.SelectedValue));

			this.ddlTipoInformacion.DataValueField=Enumerados.ColumnasTablaTablas.Codigo.ToString();
			this.ddlTipoInformacion.DataTextField=Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			this.ddlTipoInformacion.DataBind();
		}
		void LlenarPeriodos()
		{
			this.ddlPeriodo.DataSource = (new CPeriodoContable()).ListarPeriodo();
			this.ddlPeriodo.DataValueField="Periodo";
			this.ddlPeriodo.DataTextField="Periodo";
			this.ddlPeriodo.DataBind();
			ListItem item = this.ddlPeriodo.Items.FindByValue(DateTime.Now.Year.ToString());
			if(item!=null)item.Selected = true;
		}
		void LlenarGrupoCentrosdeCosto(){
			this.ddlGrupoCentroCosto.DataSource=(new CGrupoCentroCosto()).ListarGrupoCCPorCentroOperativo(Convert.ToInt32(this.ddlCentroOperativo.SelectedValue));
			this.ddlGrupoCentroCosto.DataTextField = "NRONOMGCC";
			this.ddlGrupoCentroCosto.DataValueField = "idGrupoCC";
			this.ddlGrupoCentroCosto.DataBind();
		}
		void LlenarCentrosdeCosto()
		{
			this.ddlCentroCosto.DataSource=(new CCentroCosto()).ListarCentroCostoPorGrupoCC(Convert.ToInt32(this.ddlGrupoCentroCosto.SelectedValue));
			this.ddlCentroCosto.DataTextField = Enumerados.ColumnasCentroOperativo.Nombre.ToString();
			this.ddlCentroCosto.DataValueField = Enumerados.ColumnasCentroOperativo.IdCentroOperativo.ToString();
			this.ddlCentroCosto.DataBind();
		}

		#endregion

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
			this.ddlCentroOperativo.SelectedIndexChanged += new System.EventHandler(this.ddlCentroOperativo_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add defaultFormatoMovimiento.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add defaultFormatoMovimiento.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add defaultFormatoMovimiento.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			this.LlenarCentroOperativo();
			this.LlenarTipoInformacion();
			this.LlenarPeriodos();
		}

		public void LlenarDatos()
		{
			//TablaTablas oTablaTablas = (TablaTablas)(new  CTablaTablas()).ListarDetalle(Convert.ToInt32(Enumerados.TablasTabla.GrupodeFormatos),Convert.ToInt32(Page.Request.Params[KEYQIDGRUPOFORMATO]));
			//TablaTablas oTablaTablas = (TablaTablas)(new  CTablaTablas()).ListarDetalle(Convert.ToInt32(Enumerados.TablasTabla.GrupodeFormatos),0);
			//this.lblGrupoFormato.Text = oTablaTablas.Descripcion;			
		}

		public void LlenarJScript()
		{
			this.ddlCentroOperativo.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnChange.ToString(),"CentroOperativoSeleccionado();");
			this.ddlGrupoCentroCosto.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnChange.ToString(),"CargarCentrodeCosto();");
		}

		public void RegistrarJScript()
		{
			// TODO:  Add defaultFormatoMovimiento.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add defaultFormatoMovimiento.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add defaultFormatoMovimiento.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add defaultFormatoMovimiento.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add defaultFormatoMovimiento.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void btnConsultar_Click(object sender, System.EventArgs e)
		{
				
		}

		private void ddlCentroOperativo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			LlenarTipoInformacion();
		}
	}
}
