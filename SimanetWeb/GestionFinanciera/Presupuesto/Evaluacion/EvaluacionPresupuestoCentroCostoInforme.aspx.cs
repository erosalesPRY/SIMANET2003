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
using SIMA.Controladoras;
using SIMA.Controladoras.General;
using SIMA.Controladoras.GestionFinanciera;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;

namespace SIMA.SimaNetWeb.GestionFinanciera.Presupuesto.Evaluacion
{
	/// <summary>
	/// Summary description for EvaluacionPresupuestoCentroCostoInforme.
	/// </summary>
	public class EvaluacionPresupuestoCentroCostoInforme : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		#region Control
		const string GRILLAVACIA="No existe Datos";
		#endregion

		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.TextBox txtBuscar;
		protected System.Web.UI.WebControls.DropDownList ddlCentroOperativo;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label Label2;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hUser;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidGrupoCentroCosto;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.DropDownList ddlPeriodo;
		protected System.Web.UI.WebControls.DropDownList ddlMes;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.DropDownList ddlCuenta;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdCuenta;
		protected System.Web.UI.WebControls.CheckBox chkDistinct;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
	           
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarJScript();
					this.LlenarDatos();
					this.LlenarCombos();
					Helper.ReestablecerPagina();
					this.LlenarGrillaOrdenamientoPaginacion(String.Empty,Constantes.INDICEPAGINADEFAULT);	
					
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
					string msgb =oException.Message.ToString();
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
			this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add EvaluacionPresupuestoCentroCostoInforme.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add EvaluacionPresupuestoCentroCostoInforme.LlenarGrillaOrdenamiento implementation
		}
		DataTable ObtenerDatos()
		{
			//return (new CPresupuestoControl()).ConsultarPresupuestal();
			DataTable dt = new  DataTable();
			dt.Columns.Add("Col1");
			dt.Columns.Add("Col2");
			dt.Columns.Add("Col3");
			dt.Columns.Add("Col4");
			dt.Columns.Add("Col5");
			dt.Columns.Add("Col6");
			dt.Columns.Add("Col7");
			dt.Columns.Add("Col8");
			dt.Columns.Add("Col9");
			dt.Columns.Add("Col10");
			dt.Columns.Add("Col11");
			dt.Columns.Add("Col12");
			object []Data={"","","","","","","","","","","",""};
			dt.Rows.Add(Data);
			return dt;
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dtGeneral = this.ObtenerDatos();
			if(dtGeneral!=null)
			{
				grid.DataSource = dtGeneral;
				lblResultado.Visible = false;
			}
			else
			{
				grid.DataSource = dtGeneral;
				lblResultado.Text = GRILLAVACIA;
			}
			try
			{
				grid.DataBind();
			}
			catch	
			{
				grid.CurrentPageIndex = 0;
				grid.DataBind();
			}		
		}

		public void LlenarCombos()
		{
			this.LlenarCentroOPerativo();
			this.LlenarPeriodo();
			this.LlenarMes();

		}

		private void LlenarPeriodo()
		{
			ddlPeriodo.DataSource = (new CPeriodoContable()).ListarPeriodo();
			ddlPeriodo.DataValueField="Periodo";
			ddlPeriodo.DataTextField="Periodo";
			ddlPeriodo.DataBind();
			ListItem item = ddlPeriodo.Items.FindByValue(SIMA.Utilitario.Helper.FechaSimanet.ObtenerFechaSesion().Year.ToString());
			if(item!=null)
			{item.Selected = true;}
		}
		private void LlenarMes()
		{
			ddlMes.DataSource = (new CPeriodoContable()).ListarMes();
			ddlMes.DataValueField=Enumerados.Mes.idMes.ToString();
			ddlMes.DataTextField=Enumerados.Mes.NombreMes.ToString();
			ddlMes.DataBind();
			ListItem item = ddlMes.Items.FindByValue(SIMA.Utilitario.Helper.FechaSimanet.ObtenerFechaSesion().Month.ToString());
			if(item!=null)
			{item.Selected = true;}
		}
		void LlenarCentroOPerativo()
		{
			//
			this.ddlCentroOperativo.Attributes.Add("onchange","AgregarOpciones()");
			this.ddlCentroOperativo.DataSource = (new CCentroOperativo()).ListarTodosCombo();
			this.ddlCentroOperativo.DataValueField = "idcentrooperativo";
			this.ddlCentroOperativo.DataTextField = "Nombre";
			this.ddlCentroOperativo.DataBind();
			ListItem item = ddlCentroOperativo.Items.FindByValue(CNetAccessControl.GetUserIdCentroOperativo().ToString());
			if(item!=null)
			{item.Selected = true;
				if(item!=null){
					if(item.Value == "1")
					{
						item = new ListItem("96","96");
						this.ddlCuenta.Items.Add(item);
					}
					else{
						item = new ListItem("91","91");
						this.ddlCuenta.Items.Add(item);
						item = new ListItem("92","92");
						this.ddlCuenta.Items.Add(item);
						item = new ListItem("97","97");
						this.ddlCuenta.Items.Add(item);
					}
				}
			}

		}
		public void LlenarDatos()
		{
			this.hUser.Value = CNetAccessControl.GetIdUser().ToString();
			this.txtBuscar.Text = CNetAccessControl.GetUserNombredeGrupodeCentrodeCosto();
			this.hidGrupoCentroCosto.Value = CNetAccessControl.GetUserIdGrupodeCentrodeCosto().ToString();
		}

		public void LlenarJScript()
		{
			this.ddlCentroOperativo.Attributes.Add(Utilitario.Constantes.EVENTOONCHANGE,"window.alert();ActualizarParametros();");
		}

		public void RegistrarJScript()
		{
			// TODO:  Add EvaluacionPresupuestoCentroCostoInforme.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add EvaluacionPresupuestoCentroCostoInforme.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add EvaluacionPresupuestoCentroCostoInforme.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add EvaluacionPresupuestoCentroCostoInforme.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add EvaluacionPresupuestoCentroCostoInforme.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			// TODO:  Add EvaluacionPresupuestoCentroCostoInforme.Agregar implementation
		}

		public void Modificar()
		{
			// TODO:  Add EvaluacionPresupuestoCentroCostoInforme.Modificar implementation
		}

		public void Eliminar()
		{
			// TODO:  Add EvaluacionPresupuestoCentroCostoInforme.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			// TODO:  Add EvaluacionPresupuestoCentroCostoInforme.CargarModoPagina implementation
		}

		public void CargarModoNuevo()
		{
			// TODO:  Add EvaluacionPresupuestoCentroCostoInforme.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			// TODO:  Add EvaluacionPresupuestoCentroCostoInforme.CargarModoModificar implementation
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add EvaluacionPresupuestoCentroCostoInforme.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add EvaluacionPresupuestoCentroCostoInforme.ValidarCampos implementation
			return false;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add EvaluacionPresupuestoCentroCostoInforme.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add EvaluacionPresupuestoCentroCostoInforme.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				e.Item.Style.Add("display","none");
			}
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			
		}

		private void txtBuscar_TextChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
