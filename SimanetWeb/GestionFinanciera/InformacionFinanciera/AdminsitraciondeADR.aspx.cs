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
	/// Summary description for AdminsitraciondeADR.
	/// </summary>
	public class AdminsitraciondeADR : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		#region Constantes
		const string GRILLAVACIA ="No existe ning�n Registro.";  
		const string CONTROLINK="hlkEntidad";
		const string URLDETALLE="DetalledeADR.aspx?";
		const string COLORDENAMIENTO = "NombreEntidad";

		const string KEYIDFECHA = "Fecha";
		const string KEYIDSTRFECHA = "strFecha";
		const string KEYIDENTIDAD ="IdEntidad";
		const string KEYENTIDADOTROSNOMBRE ="EntidadNombre";

		const string CAMPO1 ="LblPorcCierre";
		const string CAMPO2 ="LblPorcVar";
		const string CAMPO3 ="lblPorcVolAcc";

		//Otros
		const string COLUMNASTRFECHA ="strFecha";
		const string COLUMNAMODO ="Modo";


		#endregion
		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label Label1;
		protected eWorld.UI.CalendarPopup CalFecha;
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
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
					Helper.CalendarioControlStyle(this.CalFecha);
					this.CalFecha.SelectedDate = DateTime.Now.Date;
					Helper.ReestablecerPagina(this);
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionFinanciera",this.ToString(),"Se consult� Carta de Cr�dito.",Enumerados.NivelesErrorLog.I.ToString()));
					this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO),Utilitario.Constantes.INDICEPAGINADEFAULT);
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
			this.CalFecha.DateChanged += new eWorld.UI.DateChangedEventHandler(this.CalFecha_DateChanged);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add AdminsitraciondeADR.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdminsitraciondeADR.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			string Fecha =this.CalFecha.SelectedDate.Year.ToString() + this.CalFecha.SelectedDate.Month.ToString().PadLeft(2,'0')+ this.CalFecha.SelectedDate.Day.ToString().PadLeft(2,'0');
			CAdrs oCAdrs = new CAdrs();
			DataTable dtADR = oCAdrs.AdministrarADRS(Fecha,Utilitario.Constantes.IDDEFAULT,Utilitario.Constantes.IDDEFAULT);

			if(dtADR!=null)
			{
				DataView dwADR = dtADR.DefaultView;
				dwADR.Sort = columnaOrdenar ;
				grid.DataSource = dwADR;
				CImpresion oCImpresion = new CImpresion();
				oCImpresion.GuardarDataImprimirExportar(dtADR,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGOTITULOREPORTEACCIONCONTROLNOPROGRAMADA),columnaOrdenar,indicePagina);
				ibtnImprimir.Visible = true;
				lblResultado.Visible = false;

			}
			else
			{
				grid.DataSource = dtADR;
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
			// TODO:  Add AdminsitraciondeADR.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add AdminsitraciondeADR.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add AdminsitraciondeADR.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add AdminsitraciondeADR.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdminsitraciondeADR.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdminsitraciondeADR.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdminsitraciondeADR.Exportar implementation
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
			// TODO:  Add AdminsitraciondeADR.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			// TODO:  Add AdminsitraciondeADR.Agregar implementation
		}

		public void Modificar()
		{
			// TODO:  Add AdminsitraciondeADR.Modificar implementation
		}

		public void Eliminar()
		{
			// TODO:  Add AdminsitraciondeADR.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			// TODO:  Add AdminsitraciondeADR.CargarModoPagina implementation
		}

		public void CargarModoNuevo()
		{
			// TODO:  Add AdminsitraciondeADR.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			// TODO:  Add AdminsitraciondeADR.CargarModoModificar implementation
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add AdminsitraciondeADR.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add AdminsitraciondeADR.ValidarCampos implementation
			return false;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add AdminsitraciondeADR.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add AdminsitraciondeADR.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion


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
					Helper.MostrarVentana(URLDETALLE,KEYIDFECHA + Utilitario.Constantes.SIGNOIGUAL + this.CalFecha.SelectedDate.ToShortDateString()
						+ Utilitario.Constantes.SIGNOAMPERSON 
						+ KEYIDSTRFECHA + Utilitario.Constantes.SIGNOIGUAL + dr[COLUMNASTRFECHA].ToString()
						+ Utilitario.Constantes.SIGNOAMPERSON 
						+ KEYIDENTIDAD +  Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr[Enumerados.FinColumnaADR.identidadotros.ToString()])
						+ Utilitario.Constantes.SIGNOAMPERSON 
						+ Utilitario.Constantes.KEYMODOPAGINA +  Utilitario.Constantes.SIGNOIGUAL + dr[COLUMNAMODO].ToString()
						+ Utilitario.Constantes.SIGNOAMPERSON 
						+ KEYENTIDADOTROSNOMBRE +  Utilitario.Constantes.SIGNOIGUAL + dr[Utilitario.Enumerados.FinColumnaADR.NombreEntidad.ToString()].ToString()));

				
				((Label)e.Item.Cells[2].FindControl(CAMPO1)).Text = Convert.ToString(dr[Utilitario.Enumerados.FinColumnaADR.porccierre.ToString()]);

				((Label)e.Item.Cells[3].FindControl(CAMPO2)).Text = Convert.ToString(dr[Utilitario.Enumerados.FinColumnaADR.porcvariacion.ToString()]);

				((Label)e.Item.Cells[4].FindControl(CAMPO3)).Text = Convert.ToString(dr[Utilitario.Enumerados.FinColumnaADR.porcvolacc.ToString()]);

				e.Item.Height=10;
			}							
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(e.SortExpression),Helper.ObtenerIndicePagina());
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			grid.CurrentPageIndex=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void CalFecha_DateChanged(object sender, System.EventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO),Utilitario.Constantes.INDICEPAGINADEFAULT);
		}
	}
}
