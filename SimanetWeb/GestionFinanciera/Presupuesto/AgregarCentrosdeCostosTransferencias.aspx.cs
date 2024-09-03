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
using SIMA.Controladoras.Personal;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;

namespace SIMA.SimaNetWeb.GestionFinanciera.Presupuesto
{
	/// <summary>
	/// Summary description for AgregarCentrosdeCostosTransferencias.
	/// </summary>
	public class AgregarCentrosdeCostosTransferencias : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		const string GRILLAVACIA="No existe Datos";
		const string CTRLCHEKNATURALEZA="chkNaturaleza";
		const string KEYIDREQUERIMIENTO="idrqr";
		private int idRequerimiento
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYIDREQUERIMIENTO]);}
		}
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Image imgCancelar;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.DropDownList ddlGrupoCC;
		protected System.Web.UI.WebControls.DropDownList ddlCentroCosto;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.DropDownList ddlMes;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				this.ConfigurarAccesoControles();
				Helper.ReiniciarSession();
				Helper.ReestablecerPagina(this);
				this.LlenarJScript();
				//this.LlenarDatos();
				//this.LlenarCombos();
				this.LlenarGrilla();
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
				ltlMensaje.Text = Helper.MensajeAlert(oSIMAExcepcionDominio.Error);					
			}
			catch(Exception oException)
			{
				string msgb =oException.Message.ToString();
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		DataTable ObtenerDatos()
		{
			return (new CPresupuestoRequerimiento()).RequerimientoNaturalezadeGastoCta3Dig(this.idRequerimiento);
		}
		public void LlenarGrilla()
		{
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AgregarCentrosdeCostosTransferencias.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add AgregarCentrosdeCostosTransferencias.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add AgregarCentrosdeCostosTransferencias.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add AgregarCentrosdeCostosTransferencias.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add AgregarCentrosdeCostosTransferencias.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AgregarCentrosdeCostosTransferencias.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AgregarCentrosdeCostosTransferencias.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AgregarCentrosdeCostosTransferencias.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add AgregarCentrosdeCostosTransferencias.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add AgregarCentrosdeCostosTransferencias.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			// TODO:  Add AgregarCentrosdeCostosTransferencias.Agregar implementation
		}

		public void Modificar()
		{
			// TODO:  Add AgregarCentrosdeCostosTransferencias.Modificar implementation
		}

		public void Eliminar()
		{
			// TODO:  Add AgregarCentrosdeCostosTransferencias.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			// TODO:  Add AgregarCentrosdeCostosTransferencias.CargarModoPagina implementation
		}

		public void CargarModoNuevo()
		{
			// TODO:  Add AgregarCentrosdeCostosTransferencias.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			// TODO:  Add AgregarCentrosdeCostosTransferencias.CargarModoModificar implementation
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add AgregarCentrosdeCostosTransferencias.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add AgregarCentrosdeCostosTransferencias.ValidarCampos implementation
			return false;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add AgregarCentrosdeCostosTransferencias.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add AgregarCentrosdeCostosTransferencias.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				CheckBox chk = (CheckBox)e.Item.Cells[0].FindControl(CTRLCHEKNATURALEZA);
				chk.Checked = ((Convert.ToInt32(dr["idTransferencia"])==0)?false:true);
				chk.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnClick.ToString(),"Aceptar();");
			}		
		}
	}
}
