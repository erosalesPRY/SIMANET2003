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


namespace SIMA.SimaNetWeb.General.Formato
{
	public class ConsultarGrupoFormatos : System.Web.UI.Page,IPaginaBase ,IPaginaMantenimento
	{
		const string KEYQIDGRUPOFORMATO="IdGrupoFormato";
		const string KEYIDEMPRESA ="idEmp";
		const string URLPAGINAFORMATO="/General/Formato/defaultFormatoMovimiento.aspx?";
		protected System.Web.UI.HtmlControls.HtmlInputHidden hNroPag;
		protected System.Web.UI.WebControls.Label Label1;

		protected projDataGridWeb.DataGridWeb grid;
	
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
					Helper.ReestablecerPagina();
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
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.PreRender += new System.EventHandler(this.grid_PreRender);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			// TODO:  Add ConsultarGrupoFormatos.Agregar implementation
		}

		public void Modificar()
		{
			// TODO:  Add ConsultarGrupoFormatos.Modificar implementation
		}

		public void Eliminar()
		{
			// TODO:  Add ConsultarGrupoFormatos.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			// TODO:  Add ConsultarGrupoFormatos.CargarModoPagina implementation
		}

		public void CargarModoNuevo()
		{
			// TODO:  Add ConsultarGrupoFormatos.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			// TODO:  Add ConsultarGrupoFormatos.CargarModoModificar implementation
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add ConsultarGrupoFormatos.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add ConsultarGrupoFormatos.ValidarCampos implementation
			return false;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add ConsultarGrupoFormatos.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add ConsultarGrupoFormatos.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			DataTable dt = (new  CTablaTablas()).ListaTodosCombo(Convert.ToInt32(Enumerados.TablasTabla.GrupodeFormatos));
			if(dt!=null)
			{
				grid.DataSource = dt;
				grid.CurrentPageIndex = Convert.ToInt32(this.hNroPag.Value);
			}
			else
			{
				grid.DataSource = dt;
			//	lblResultado.Text = GRILLAVACIA;

			}
			grid.DataBind();
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarGrupoFormatos.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add ConsultarGrupoFormatos.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add ConsultarGrupoFormatos.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			Helper.ReestablecerPagina();
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarGrupoFormatos.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarGrupoFormatos.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarGrupoFormatos.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarGrupoFormatos.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add ConsultarGrupoFormatos.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ConsultarGrupoFormatos.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				string Parametros=KEYQIDGRUPOFORMATO + Utilitario.Constantes.SIGNOIGUAL + dr[Enumerados.ColumnasTablasTablas.Codigo.ToString()].ToString() 
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYIDEMPRESA  + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDEMPRESA].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Enumerados.ModoPagina.C.ToString();
				Helper.ConfiguraColumnaHyperLink(e.Item.Cells[0],grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex,
						Helper.HistorialIrAdelantePersonalizado("hNroPag"),
						Helper.MostrarVentana(Page.Request.ApplicationPath + URLPAGINAFORMATO + Parametros));
				Utilitario.Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
			}
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void grid_PreRender(object sender, System.EventArgs e)
		{
		
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			hNroPag.Value = e.NewPageIndex.ToString();
			this.LlenarGrilla();
		}
	}
}
