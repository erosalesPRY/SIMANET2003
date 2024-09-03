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

namespace SIMA.SimaNetWeb.GestionFinanciera.InformacionFinanciera
{
	/// <summary>
	/// Summary description for AdminsitraciondeDivisas.
	/// </summary>
	public class AdminsitraciondeDivisas : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		#region Constantes
		const string GRILLAVACIA ="No existe ningún Registro.";  
		const string CONTROLINK="hlkDivisa";
		const string URLDETALLE="DetalledeDivisas.aspx?";
		const string COLORDENAMIENTO = "NombreDivisa";

		const string KEYIDFECHA = "Fecha";
		const string KEYIDSTRFECHA = "strFecha";
		
		const string KEYIDTIPODIVISA ="TIPODIVISA";
		const string KEYIDDIVISANOMBRE ="DivisaNombre";
		const string KEYIDDIVISA ="IDDIVISA";

		const string CAMPO1 ="lblMontoCompra";
		const string CAMPO2 ="lblMontoVenta";
		const string CAMPO3 ="lblVolAcc";

		const string COLUMNASTRFECHA="strFecha";
		const string COLUMNANOMBREDIVISA ="NombreDivisa";
		const string COLUMNAMODO ="Modo";

		#endregion
		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Button btnMostrar;
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label Label1;
		protected eWorld.UI.CalendarPopup CalFecha;
		protected System.Web.UI.HtmlControls.HtmlTable TblTabs;
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
					this.CalFecha.SelectedDate = DateTime.Now.Date;
					Helper.ReestablecerPagina(this);
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionFinanciera",this.ToString(),"Se consultó Carta de Crédito.",Enumerados.NivelesErrorLog.I.ToString()));
					this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO),Utilitario.Constantes.INDICEPAGINADEFAULT);
					Helper.CalendarioControlStyle(this.CalFecha);
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
			this.btnMostrar.Click += new System.EventHandler(this.btnMostrar_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add AdminsitraciondeDivisas.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdminsitraciondeDivisas.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			string strFecha = this.CalFecha.SelectedDate.Year + this.CalFecha.SelectedDate.Month.ToString().PadLeft(2,'0')+ this.CalFecha.SelectedDate.Day.ToString().PadLeft(2,'0');
			CDivisas oCDivisas = new CDivisas();
			DataTable dtDivisa = oCDivisas.AdministrarDivisas(strFecha.ToString(),Utilitario.Constantes.IDDEFAULT,Utilitario.Constantes.IDDEFAULT);

			if(dtDivisa!=null)
			{
				DataView dwDivisa = dtDivisa.DefaultView;
				dwDivisa.Sort = columnaOrdenar ;
				grid.DataSource = dwDivisa;
				CImpresion oCImpresion = new CImpresion();
				oCImpresion.GuardarDataImprimirExportar(dtDivisa,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGOTITULOREPORTEACCIONCONTROLNOPROGRAMADA),columnaOrdenar,indicePagina);
				ibtnImprimir.Visible = true;
				lblResultado.Visible = false;

			}
			else
			{
				grid.DataSource = dtDivisa;
				lblResultado.Visible = true;
				lblResultado.Text = GRILLAVACIA;
				ibtnImprimir.Visible = false;
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
			// TODO:  Add AdminsitraciondeDivisas.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add AdminsitraciondeDivisas.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add AdminsitraciondeDivisas.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add AdminsitraciondeDivisas.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdminsitraciondeDivisas.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdminsitraciondeDivisas.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdminsitraciondeDivisas.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			if(CNetAccessControl.FindPage(Page.Request.Url.AbsolutePath.ToString()))
			{
				CNetAccessControl.LoadControls(this);
			}
			else
			{
				CNetAccessControl.RedirectPageError();
			}
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add AdminsitraciondeDivisas.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			// TODO:  Add AdminsitraciondeDivisas.Agregar implementation
		}

		public void Modificar()
		{
			// TODO:  Add AdminsitraciondeDivisas.Modificar implementation
		}

		public void Eliminar()
		{
			// TODO:  Add AdminsitraciondeDivisas.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			// TODO:  Add AdminsitraciondeDivisas.CargarModoPagina implementation
		}

		public void CargarModoNuevo()
		{
			// TODO:  Add AdminsitraciondeDivisas.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			// TODO:  Add AdminsitraciondeDivisas.CargarModoModificar implementation
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add AdminsitraciondeDivisas.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add AdminsitraciondeDivisas.ValidarCampos implementation
			return false;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add AdminsitraciondeDivisas.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add AdminsitraciondeDivisas.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion

		private void btnMostrar_Click(object sender, System.EventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO),Utilitario.Constantes.INDICEPAGINADEFAULT);
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{			
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				e.Item.Cells[0].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				e.Item.Cells[0].Style.Add(Utilitario.Constantes.CURSOR,Utilitario.Constantes.TIPOCURSORMANO);
				e.Item.Cells[0].ForeColor=Color.Blue;
				e.Item.Cells[0].Font.Underline=true;
				e.Item.Cells[0].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.HistorialIrAdelantePersonalizado("CalFecha") + Utilitario.Constantes.SIGNOPUNTOYCOMA +
					Helper.MostrarVentana(URLDETALLE,
					 KEYIDFECHA + Utilitario.Constantes.SIGNOIGUAL + this.CalFecha.SelectedDate.ToShortDateString()
					+ Utilitario.Constantes.SIGNOAMPERSON 
					+ KEYIDSTRFECHA + Utilitario.Constantes.SIGNOIGUAL + dr[COLUMNASTRFECHA].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON 
					+ KEYIDDIVISANOMBRE + Utilitario.Constantes.SIGNOIGUAL + dr[COLUMNANOMBREDIVISA].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON 
					+ KEYIDTIPODIVISA  +  Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr[Enumerados.FinColumnaDivisas.idtablatipodivisa.ToString()])
					+ Utilitario.Constantes.SIGNOAMPERSON 
					+ KEYIDDIVISA +  Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr[Enumerados.FinColumnaDivisas.iddivisa.ToString()])
					+ Utilitario.Constantes.SIGNOAMPERSON 
					+ Utilitario.Constantes.KEYMODOPAGINA +  Utilitario.Constantes.SIGNOIGUAL + dr[COLUMNAMODO].ToString()));

				((Label)e.Item.Cells[2].FindControl(CAMPO1)).Text = Convert.ToString(dr[Utilitario.Enumerados.FinColumnaDivisas.montocompra.ToString()]);
				((Label)e.Item.Cells[3].FindControl(CAMPO2)).Text = Convert.ToString(dr[Utilitario.Enumerados.FinColumnaDivisas.montoventa.ToString()]);
				((Label)e.Item.Cells[4].FindControl(CAMPO3)).Text = Convert.ToString(dr[Utilitario.Enumerados.FinColumnaDivisas.volacc.ToString()]);
			}					
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			grid.CurrentPageIndex=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(e.SortExpression),Helper.ObtenerIndicePagina());
		}
		
	}
}
