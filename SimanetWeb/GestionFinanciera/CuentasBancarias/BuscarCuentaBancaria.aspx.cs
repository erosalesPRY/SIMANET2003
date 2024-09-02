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


namespace SIMA.SimaNetWeb.GestionFinanciera.CuentasBancarias
{
	public class BuscarCuentaBancaria : System.Web.UI.Page,IPaginaBase
	{
		#region Constantes
		const string GRILLAVACIA ="No existe ninguna Cuenta Bancaria.";
		
		//Columnas Grilla
		const string IDCTABANCARIACENTRO ="idCuentaBancariaCentro";
		const string NROCTABANCARIA ="NroCuentaBancaria";
		const string MONEDA = "Moneda";
		const string CENTRO = "Centro";
		const string RAZONSOCIAL = "RazonSocial";


		#endregion

		#region Controles
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblApellidoPaterno;
		protected System.Web.UI.WebControls.ImageButton btnBuscar;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.TextBox txtCuentaBCOB;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtCuentaBCO;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtMoneda;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtCentro;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtEntidadFinanciera;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtidCuentaBancoCentro;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtTipoCtaBCO;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hOrdenGrilla;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion 
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					this.LlenarJScript();
					Helper.ReiniciarSession();
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Auditoria",this.ToString(),"Se consultó las Acciones Correctivas.",Enumerados.NivelesErrorLog.I.ToString()));
					
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
			this.btnBuscar.Click += new System.Web.UI.ImageClickEventHandler(this.btnBuscar_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			DataTable dt  = ((CCuentaBancaria)new CCuentaBancaria()).BuscarCuentasBancarias(this.txtCuentaBCOB.Text);
			if(dt !=null)
			{
				this.grid.DataSource = dt;
				lblResultado.Visible = false;
			}
			else
			{
				this.grid.DataSource = dt;
				lblResultado.Text = GRILLAVACIA;
				lblResultado.Visible = true;
			}
			this.grid.DataBind();
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dt  = ((CCuentaBancaria)new CCuentaBancaria()).BuscarCuentasBancarias(this.txtCuentaBCOB.Text);
			if(dt != null)
			{
				DataView dw = dt.DefaultView;
				dw.Sort = columnaOrdenar;
				dw.RowFilter = Utilitario.Helper.ObtenerFiltro();
				if(dw.Count==0)
				{
					grid.DataSource = null;
					lblResultado.Text = GRILLAVACIA;
					lblResultado.Visible =true;
				}
				else
				{
					grid.DataSource = dt;
					grid.CurrentPageIndex = indicePagina;
					lblResultado.Visible =false;
				}
			}
			else
			{
				grid.DataSource = dt;
				lblResultado.Text = GRILLAVACIA;
				lblResultado.Visible = true;
			}

			try
			{
				grid.CurrentPageIndex = indicePagina;				
				grid.DataBind();
			}
			catch(Exception e)
			{
				string a = e.Message;
				grid.CurrentPageIndex = Utilitario.Constantes.INDICEPAGINADEFAULT ;
				grid.DataBind();
			}
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add BuscarCuentaBancaria.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add BuscarCuentaBancaria.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add BuscarCuentaBancaria.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add BuscarCuentaBancaria.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add BuscarCuentaBancaria.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add BuscarCuentaBancaria.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add BuscarCuentaBancaria.Exportar implementation
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
			// TODO:  Add BuscarCuentaBancaria.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void btnBuscar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			//this.LlenarGrilla();
            this.LlenarGrillaOrdenamientoPaginacion(this.hOrdenGrilla.Value, Convert.ToInt32(this.hGridPagina.Value));
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,
					Helper.MostrarDatosEnCajaTexto("txtidCuentaBancoCentro",dr[IDCTABANCARIACENTRO].ToString()),
					Helper.MostrarDatosEnCajaTexto("txtCuentaBCO",dr[NROCTABANCARIA].ToString()),
					Helper.MostrarDatosEnCajaTexto("txtMoneda",dr[MONEDA].ToString()),
					Helper.MostrarDatosEnCajaTexto("txtCentro",dr[CENTRO].ToString()),
					Helper.MostrarDatosEnCajaTexto("txtEntidadFinanciera",dr[RAZONSOCIAL].ToString()));
			}
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.hGridPagina.Value = e.NewPageIndex.ToString();
			this.LlenarGrillaOrdenamientoPaginacion(this.hOrdenGrilla.Value,e.NewPageIndex);
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.hOrdenGrilla.Value = Helper.GenerarExpresionOrdenamiento(e.SortExpression);
			this.LlenarGrillaOrdenamientoPaginacion(this.hOrdenGrilla.Value,Helper.ObtenerIndicePagina());
		}
	}
}
