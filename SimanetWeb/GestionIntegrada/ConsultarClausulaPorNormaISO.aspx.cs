using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using SIMA.SimaNetWeb.InterfacesIU;
using SIMA.Controladoras.GestionIntegrada;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;

namespace SIMA.SimaNetWeb.GestionIntegrada
{
	/// <summary>
	/// Summary description for ConsultarClausulaPorNormaISO.
	/// </summary>
	public class ConsultarClausulaPorNormaISO : System.Web.UI.Page,IPaginaBase
	{
		protected System.Web.UI.WebControls.DataGrid gridClausula;
		protected System.Web.UI.WebControls.DropDownList ddlClausula;
	

		public int RowIdExt{
			get{ return Convert.ToInt32(Page.Request.Params["rowID"]);}
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();	
					this.LlenarJScript();
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(), "Gestión Integrada: Administrar Solicitad de acción de mejora", this.ToString(),"Se consultó El Listado de SAM emitidas por cada usuario responsable.",Enumerados.NivelesErrorLog.I.ToString()));
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
					string msg = oException.Message.ToString();
					SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Utilitario.Constantes.CODIGOERRORGENERICO,oException.Message);
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
			this.gridClausula.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemCreated);
			this.gridClausula.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			DataTable dtIso =(new CSAMiso()).ListarTodosGrilla(Utilitario.Helper.GestionIntegrada.Params.IDSolicitudAccionMejora,Utilitario.Helper.GestionIntegrada.Params.IdNormaISO); 
			if (dtIso!=null)
			{
				DataView dvISO = dtIso.DefaultView;
				dvISO.RowFilter="Estado <>0 and IdVersionNormaISO="+ Utilitario.Helper.GestionIntegrada.Params.IdVersionNormaISO.ToString();
				gridClausula.DataSource = dvISO;
			}
			else
			{
				gridClausula.DataSource = dtIso;
			}
			gridClausula.DataBind();
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarClausulaPorNormaISO.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add ConsultarClausulaPorNormaISO.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add ConsultarClausulaPorNormaISO.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add ConsultarClausulaPorNormaISO.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarClausulaPorNormaISO.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarClausulaPorNormaISO.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarClausulaPorNormaISO.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarClausulaPorNormaISO.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add ConsultarClausulaPorNormaISO.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ConsultarClausulaPorNormaISO.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
		
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				e.Item.Attributes.Add("IDNORMAISO",dr["IdNormaISO"].ToString());
				e.Item.Attributes.Add("NOMBRENORMAISO",dr["NormaISO"].ToString());
				e.Item.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.Ondblclick.ToString(),"grid_ondblClick(this,'" + RowIdExt.ToString() + "');");
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
			}
		}
	}
}
