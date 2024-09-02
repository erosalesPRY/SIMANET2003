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
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using NullableTypes;
using MetaBuilders.WebControls;

namespace SIMA.SimaNetWeb.General
{
	/// <summary>
	/// Summary description for BuscarPais.
	/// </summary>
	public class BuscarPais : System.Web.UI.Page,IPaginaBase
	{
		#region Controles
			protected System.Web.UI.WebControls.Label lblTitulo;
			protected System.Web.UI.WebControls.Image imgCancelar;
			protected System.Web.UI.HtmlControls.HtmlInputHidden hNombreCliente;
			protected System.Web.UI.WebControls.Label lblPalabraBusqueda;
			protected System.Web.UI.WebControls.DropDownList ddlbContinente;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hNombrePais;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidPais;
			protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					//this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarJScript();
					this.LlenarCombos();
					this.LlenarDatos();
					this.ListarPaises();	
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
					SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Utilitario.Constantes.CODIGOERRORGENERICO,oException.Message);
					Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
				}
			}
			// Put user code to initialize the page here
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
			this.ddlbContinente.SelectedIndexChanged += new System.EventHandler(this.ddlbContinente_SelectedIndexChanged);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add BuscarPais.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add BuscarPais.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add BuscarPais.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			CContinentePais oCContinentePais = new CContinentePais();
			this.ddlbContinente.DataSource= oCContinentePais.ListarContinentes();
			ddlbContinente.DataValueField = "idUbigeo";
			ddlbContinente.DataTextField = "NombreDepartamento";
			ddlbContinente.DataBind();			
			//ListItem item = new ListItem(Utilitario.Constantes.SELECCIONARITEMLISTA,Utilitario.Constantes.VALORSELECCIONAR);
			ListItem item = new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR.ToString(),"0");
			ddlbContinente.Items.Add(item);
			// TODO:  Add BuscarPais.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add BuscarPais.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add BuscarPais.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add BuscarPais.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add BuscarPais.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add BuscarPais.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add BuscarPais.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add BuscarPais.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void ddlbContinente_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.ListarPaises();	
		}
		private void ListarPaises()
		{
			CContinentePais oCContinentePais = new CContinentePais();
			DataTable dt = oCContinentePais.ListarPaises(this.ddlbContinente.SelectedValue);
			if (dt !=null)
			{
				DataView dtv = dt.DefaultView;
				grid.DataSource = dtv;
			}
			else
			{
				grid.DataSource =dt;
			}
			grid.DataBind();
	}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,Utilitario.Helper.MostrarDatosEnCajaTexto("hidPais",dr["idUbigeo"].ToString())+ ";" + Utilitario.Helper.MostrarDatosEnCajaTexto("hNombrePais",dr["NombreProvincia"].ToString()));
			}
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			grid.CurrentPageIndex=e.NewPageIndex;
			this.ListarPaises();
		}
	}
}
