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
	/// Summary description for AgregarRequerimientoNaturalezadeGasto.
	/// </summary>
	public class AgregarRequerimientoNaturalezadeGasto : System.Web.UI.Page,IPaginaBase
	{
		const string GRILLAVACIA="No existe Datos";
		const string CTRLCHEKNATURALEZA="chkNaturaleza";
		const string KEYQIDTRANSFERENCIA="idTransf";	
		

		private int idTransferencia
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDTRANSFERENCIA]);}
		}

		protected System.Web.UI.WebControls.Label Label3;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Image imgCancelar;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.CheckBox CheckBox1;
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
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members
		DataTable ObtenerDatos()
		{
			return (new CPresupuestoRequerimiento()).RequerimientoNaturalezadeGastoCta3Dig(this.idTransferencia);
		}
		public void LlenarGrilla()
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

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AgregarRequerimientoNaturalezadeGasto.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add AgregarRequerimientoNaturalezadeGasto.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add AgregarRequerimientoNaturalezadeGasto.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add AgregarRequerimientoNaturalezadeGasto.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add AgregarRequerimientoNaturalezadeGasto.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AgregarRequerimientoNaturalezadeGasto.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AgregarRequerimientoNaturalezadeGasto.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AgregarRequerimientoNaturalezadeGasto.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add AgregarRequerimientoNaturalezadeGasto.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add AgregarRequerimientoNaturalezadeGasto.ValidarFiltros implementation
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
				chk.Checked = ((Convert.ToInt32(dr["idEstado"])==0)?false:true);
				chk.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnClick.ToString(),"Aceptar(this);");
				e.Item.Attributes.Add("chkValue",((chk.Checked==true)?"1":"0"));
				e.Item.Attributes.Add("idCuentaContableGrupo",dr["idCuentaContableGrupo"].ToString());
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
			}				
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
