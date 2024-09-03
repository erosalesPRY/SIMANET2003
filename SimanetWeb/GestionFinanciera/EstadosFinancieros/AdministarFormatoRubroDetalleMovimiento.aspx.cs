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

namespace SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancieros
{
	/// <summary>
	/// Summary description for AdministarFormatoRubroDetalleMovimiento.
	/// </summary>
	public class AdministarFormatoRubroDetalleMovimiento : System.Web.UI.Page,IPaginaBase
	{

		#region Constantes
		//Key Session y QueryString
		const string KEYQIDFORMATO = "IdFormato";
		const string KEYQIDRUBRO= "IdRubro";
		const string KEYQIDCENTRO = "IdCentro";
		const string KEYQIDTIPOINFO= "idTipoInfo";
		const string KEYQPERIODO= "Periodo";
		const string KEYQMES= "IdMes";

		const string KEYQCUENTACONTABLE = "CtaCtble";
		const string CONTROLIMAGE = "imgVerDetalle";
		const string GRILLAVACIA="No exiets";

		const string CONTROLDDL1="ddblOperador";
		const string CONTROLDDL2="ddblCondicion";
		const string CONTROLTXT="txtCuenta";
		const string CONTROLCHK="chkActivo";				

		//Columnas GRILLA
		const string MODO = "Modo";
		const string IDRUBRODETALLE ="IdRubroDetalle";
		const string IDRUBRODETALLEMOVIMIENTO ="idRubroDetalleMovimiento";

		//Variable Session
		const string VARIABLESESSIONCIERRE ="Cierre";
		#endregion
		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				if(!Page.IsPostBack)
				{
					this.ConfigurarAccesoControles();
					this.LlenarJScript();
					Helper.ReiniciarSession();
					this.LlenarGrilla();
				}				
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
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		private DataTable ObtenerDatos()
		{
			return ((CFormatoRubroDetalleMovimiento)  new CFormatoRubroDetalleMovimiento()).ConsultarFormatoRubroDetalleMovimiento(
				Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO])
				,Convert.ToInt32(Page.Request.Params[KEYQIDRUBRO])
				,Convert.ToInt32(Page.Request.Params[KEYQPERIODO])
				,Convert.ToInt32(Page.Request.Params[KEYQMES])
				,Convert.ToInt32(Page.Request.Params[KEYQIDCENTRO])
				,Convert.ToInt32(Page.Request.Params[KEYQIDTIPOINFO]),
				0)
				;
			
		}

		public void LlenarGrilla()
		{
			DataTable dt= this.ObtenerDatos();
			if(dt!=null)
			{
				grid.DataSource = dt;
			}
			else
			{
				grid.DataSource = dt;
				lblResultado.Text = GRILLAVACIA;
			}
			grid.DataBind();
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministarFormatoRubroDetalleMovimiento.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add AdministarFormatoRubroDetalleMovimiento.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add AdministarFormatoRubroDetalleMovimiento.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add AdministarFormatoRubroDetalleMovimiento.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministarFormatoRubroDetalleMovimiento.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministarFormatoRubroDetalleMovimiento.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministarFormatoRubroDetalleMovimiento.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			if(CNetAccessControl.FindPage(Page.Request.Url.AbsolutePath.ToString()))
			{CNetAccessControl.LoadControls(this);}
			else
			{CNetAccessControl.RedirectPageError();}
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add AdministarFormatoRubroDetalleMovimiento.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				string ss=dr["Modo"].ToString();
				e.Item.Cells[0].Attributes.Add("Modo",dr[MODO].ToString());
				e.Item.Cells[0].Attributes.Add("Centro",Page.Request.Params[KEYQIDCENTRO].ToString());
				e.Item.Cells[0].Attributes.Add("Formato",Page.Request.Params[KEYQIDFORMATO].ToString());
				e.Item.Cells[0].Attributes.Add("idRubro",Page.Request.Params[KEYQIDRUBRO].ToString());
				e.Item.Cells[0].Attributes.Add("idRubroDetalle",dr[IDRUBRODETALLE].ToString());
				e.Item.Cells[0].Attributes.Add("idRubroMovimiento",dr[IDRUBRODETALLEMOVIMIENTO].ToString());
				e.Item.Cells[0].Attributes.Add("Periodo",Page.Request.Params[KEYQPERIODO].ToString());
				e.Item.Cells[0].Attributes.Add("idMes",Page.Request.Params[KEYQMES].ToString());
				e.Item.Cells[0].Attributes.Add("TipoInfo",Page.Request.Params[KEYQIDTIPOINFO].ToString());
				if (Convert.ToInt32(Session[VARIABLESESSIONCIERRE])==0)
				{
					e.Item.Cells[1].Attributes.Add(Utilitario.Constantes.EVENTODBLCLICK,"AbrirEditordeCelda(this);");
				}
				e.Item.Cells[1].Text = Convert.ToDouble(e.Item.Cells[1].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
			}
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
