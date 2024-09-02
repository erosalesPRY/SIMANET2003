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
using SIMA.EntidadesNegocio.General;
using SIMA.Utilitario;
using NetAccessControl;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
namespace SIMA.SimaNetWeb.GestionFinanciera.InformacionFinanciera
{
	/// <summary>
	/// Summary description for ConsultarTipodeCambio.
	/// </summary>
	public class ConsultarTipodeCambio : System.Web.UI.Page,IPaginaBase
	{
		#region Constantes
		public int id=0;
		public int ini =0;
		const string GRILLAVACIA ="No existe tipo de Cambio";
		const string CONSTACTAUALIZACIONEXITO="La Actualización de efectuo con exito";
		
		#endregion
		#region Controles
			protected System.Web.UI.WebControls.Label lblRutaPagina;
			protected System.Web.UI.WebControls.Label lblPagina;
			protected System.Web.UI.WebControls.Label lblResultado;
			protected System.Web.UI.WebControls.DomValidators.DomValidationSummary Vresumen;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Calendar CalFecha;
		protected System.Web.UI.WebControls.Label lblTituloTC;
		protected System.Web.UI.WebControls.Button btnImportarTipoCambio;
		protected System.Web.UI.WebControls.HyperLink HyperLink1;
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
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionFinanciera",this.ToString(),"Se consultó Carta de Crédito.",Enumerados.NivelesErrorLog.I.ToString()));
					CalFecha.SelectedDate = DateTime.Now.Date;
					ini=1;
					this.LlenarGrillaOrdenamientoPaginacion("",Utilitario.Constantes.INDICEPAGINADEFAULT);
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
					ltlMensaje.Text = Helper.MsgdbErrMostrarMesaje (true,oSIMAExcepcionDominio.Error.ToString());					
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
			this.btnImportarTipoCambio.Click += new System.EventHandler(this.btnImportarTipoCambio_Click);
			this.CalFecha.DayRender += new System.Web.UI.WebControls.DayRenderEventHandler(this.CalFecha_DayRender);
			this.CalFecha.SelectionChanged += new System.EventHandler(this.CalFecha_SelectionChanged);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

			#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add ConsultarTipodeCambio.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarTipodeCambio.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			Controladoras.General.CTipoCambio  oCTipoCambio =  new SIMA.Controladoras.General.CTipoCambio();

			DataTable dtGeneral = 
				oCTipoCambio.ConsultarTipodeCambio(CalFecha.SelectedDate.ToShortDateString(),ini);
			
			if(dtGeneral!=null)
			{
				DataView dwGeneral = dtGeneral.DefaultView;
				dwGeneral.Sort = columnaOrdenar ;
				//this.LlenarDatos(dwGeneral);
				//dwGeneral.RowFilter = Helper.ObtenerFiltro(this);
				grid.DataSource = dwGeneral;
				lblResultado.Visible = false;

			}
			else
			{
				grid.DataSource = dtGeneral;
				lblResultado.Visible = true;
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
			// TODO:  Add ConsultarTipodeCambio.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add ConsultarTipodeCambio.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add ConsultarTipodeCambio.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarTipodeCambio.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarTipodeCambio.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarTipodeCambio.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarTipodeCambio.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add ConsultarTipodeCambio.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ConsultarTipodeCambio.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void CalFecha_SelectionChanged(object sender, System.EventArgs e)
		{
			lblTituloTC.Text="Tipo de Cambio a la Fecha : " + CalFecha.SelectedDate.ToShortDateString().Replace(Utilitario.Constantes.SEPARADORFECHA,Utilitario.Constantes.LINEA);
			ini=0;
			this.LlenarGrillaOrdenamientoPaginacion("",Utilitario.Constantes.INDICEPAGINADEFAULT);
		}

		private void CalFecha_DayRender(object sender, System.Web.UI.WebControls.DayRenderEventArgs e)
		{
				if (!e.Day.IsOtherMonth)
				{
					if (id==0){e.Cell.BackColor = Color.NavajoWhite;}//e.Day.IsSelectable = false;
					else{e.Cell.Attributes.Add("ondblclick","MostrarToolTips()");}
				}
				else
				{
					e.Cell.ForeColor = Color.WhiteSmoke;
					e.Cell.BackColor = Color.Silver;//e.Day.IsSelectable = false; 
				}

				id++;
				if (id==7){id=0;}
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				e.Item.Cells[0].ToolTip = e.Item.Cells[4].Text;
				e.Item.Cells[1].Text = Convert.ToDecimal(e.Item.Cells[1].Text).ToString(Utilitario.Constantes.FORMATODECIMAL3);
				e.Item.Cells[2].Text = Convert.ToDecimal(e.Item.Cells[2].Text).ToString(Utilitario.Constantes.FORMATODECIMAL3);
				e.Item.Cells[3].Text = Convert.ToDecimal(e.Item.Cells[3].Text).ToString(Utilitario.Constantes.FORMATODECIMAL3);

				CalFecha.SelectedDate = Convert.ToDateTime(dr["Fecha"]);
				lblTituloTC.Text="Tipo de Cambio a la Fecha : " + CalFecha.SelectedDate.ToShortDateString().Replace(Utilitario.Constantes.SEPARADORFECHA,Utilitario.Constantes.LINEA);
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
			}
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(e.SortExpression),Helper.ObtenerIndicePagina());
		}

		private void btnImportarTipoCambio_Click(object sender, System.EventArgs e)
		{
			Controladoras.General.CTipoCambio oTipoCambio=new SIMA.Controladoras.General.CTipoCambio();
			int retorno;
			retorno=oTipoCambio.ImportarTipoCambioUnisysUltimosDias();
			if(retorno>=1)
			{
				ltlMensaje.Text=Helper.MensajeAlert(CONSTACTAUALIZACIONEXITO);
			}
			this.LlenarGrillaOrdenamientoPaginacion(Utilitario.Constantes.VACIO,Utilitario.Constantes.INDICEPAGINADEFAULT);
		}
	}
}
