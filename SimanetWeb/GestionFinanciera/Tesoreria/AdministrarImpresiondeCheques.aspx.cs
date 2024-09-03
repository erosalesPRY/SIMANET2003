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
using SIMA.Controladoras.GestionFinanciera;
using SIMA.EntidadesNegocio.GestionFinanciera;
using SIMA.Utilitario;
using NetAccessControl;
using SIMA.ManejadorExcepcion;
using SIMA.Log;


namespace SIMA.SimaNetWeb.GestionFinanciera.Tesoreria
{
	/// <summary>
	/// Summary description for AdministrarImpresiondeCheques.
	/// </summary>
	public class AdministrarImpresiondeCheques : System.Web.UI.Page,IPaginaBase
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label LblBanco;
		protected System.Web.UI.WebControls.DataGrid gridChequesGirados;
		protected System.Web.UI.WebControls.DataGrid gridCheques;
		protected System.Web.UI.WebControls.Label lblUsuarioNombre;
		protected System.Web.UI.WebControls.Label lblUsuarioCodigo;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label lblImporteELetras;
		protected System.Web.UI.WebControls.Label lblReferencia;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label lblBeneficiario1;
		protected System.Web.UI.WebControls.Label lblImporte;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label lblNroCheque;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label lblFechaGiro;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Label lblBeneficiario2;
		protected System.Web.UI.WebControls.Label lblImporte1;
		protected System.Web.UI.WebControls.Label lblFecha;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.Label lblNro;
		protected System.Web.UI.WebControls.Label lblBenef;
		protected System.Web.UI.WebControls.Label Label12;
		protected System.Web.UI.WebControls.Label lblEnLetras;
		protected System.Web.UI.WebControls.Label lblMoneda;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarDatos();
					this.LlenarCombos();
					this.LlenarGrilla();
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
			this.gridCheques.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.gridCheques_ItemDataBound);
			this.gridChequesGirados.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.gridChequesGirados_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			DataTable dt = new DataTable();
			dt.Columns.Add("Descripcion",System.Type.GetType("System.String"));
			this.gridCheques.DataSource= dt;
			this.gridCheques.DataBind();

			this.gridChequesGirados.DataSource= dt;
			this.gridChequesGirados.DataBind();

		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarImpresiondeCheques.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add AdministrarImpresiondeCheques.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			/*this.ddlEntidadFinanciera.DataSource = (new CTesoreria()).ListarEntidadesFiancieras();
			this.ddlEntidadFinanciera.DataTextField="nom_bco";
			this.ddlEntidadFinanciera.DataValueField="cod_bco";
			this.ddlEntidadFinanciera.DataBind();*/
		}

		public void LlenarDatos()
		{
			//txtPeriodo.Text = DateTime.Now.Year.ToString();
		}

		public void LlenarJScript()
		{
			// TODO:  Add AdministrarImpresiondeCheques.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarImpresiondeCheques.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministrarImpresiondeCheques.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarImpresiondeCheques.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add AdministrarImpresiondeCheques.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add AdministrarImpresiondeCheques.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void gridCheques_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				e.Item.Attributes[Utilitario.Enumerados.EventosJavaScript.Ondblclick.ToString()]="Cheques.Banco.CuentaCorriente.VistaPrevia('"  + dr["NRO_CHQ"].ToString() +  "');";
			}
			//

		}

		private void gridChequesGirados_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				e.Item.Attributes[Utilitario.Enumerados.EventosJavaScript.Ondblclick.ToString()]="Cheques.Banco.CuentaCorriente.VistaPrevia('"  + dr["NRO_CHQ"].ToString() +  "');";
			}
		}
	}
}
