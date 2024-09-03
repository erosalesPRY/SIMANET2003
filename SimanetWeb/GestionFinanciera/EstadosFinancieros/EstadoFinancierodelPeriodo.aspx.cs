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

using SIMA.Utilitario;
using NetAccessControl;
using SIMA.ManejadorExcepcion;
using SIMA.Log;

namespace SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancieros
{
	/// <summary>
	/// Summary description for EstadoFinancierodelPeriodo.
	/// </summary>
	public class EstadoFinancierodelPeriodo : System.Web.UI.Page,IPaginaBase
	{
		#region Constantes
		//Key Session y QueryString
		const string KEYQIDEMPRESA = "idEmp";
		const string KEYIDCENTRO ="IdCentro";
		const string NOMBRECENTRO ="NombreCentro";
		const string NOMBRETIPOOPCION ="NombreOpcion";
		const string KEYQIDNOMBREFORMATO = "NFormato";
		const string KEYQIDFECHA = "efFecha";


		const string KEYQIDFORMATO = "IdFormato";
		const string KEYQIDREPORTE = "IdReporte";
		const string KEYQIDRUBRO = "IdRubro";
		const string KEYQNRODIGITOS ="NroDig";
		const string KEYQDIGCUENTA = "DigCuenta";
		const string KEYQIDPERIODO = "Periodo";
		const string KEYQIDMES = "Mes";
		const string KEYQIDNOMBREMES = "NombreMes";

		const string CONTROLINK = "hlkConcepto";
		const string CAMPO1 = "LblAlMes";
		const string CAMPO2 = "lblDelMes";
		const string CAMPO3 = "lblPPTO";
		//Campos de Cabecera
		const string CAMPOH1 = "LblAlMesT";
		const string CAMPOH2 = "lblDelMesT";
		const string CAMPOH3 = "lblPPTOalT";
		const int NRODIGINI = 2;
		const int DIGCTA = 0;
		
			

		const string CONTROLIMAGE = "imgVerDetalle";
		const string GRILLAVACIA="No existe";

		//Paginas
		const string URLPRINCIPAL = "../../Default.aspx";
		const string URLANTERIOR = "EstadosFinancierosPorEmpresa.aspx?";
		const string URLDETALLE ="EstadoFinancieroDelPeriodoDetalle.aspx?";
		
		const string KEYQNRODIGITOSCABECERA ="NroDigCab";
		const string KEYDIGCUENTACONTABLE = "Cuenta";
		

		//Otros
		const string TITULOCONCEPTO ="CONCEPTO";
		const string TITULOAJECUCIONAL ="EJECUCION AL ";
		const string TITULOTOTAL ="TOTAL";
		const string TITULODELPERIODO =" Del Periodo";

		//Columnas Grilla y DataTable
		const string COLUMNAIDRUBRO ="idRubro";


		private ASPNetDatagridDecorator m_add = new ASPNetDatagridDecorator();
		#endregion
		#region Controles
			protected System.Web.UI.WebControls.Label lblRutaPagina;
			protected System.Web.UI.WebControls.Label lblPagina;
			protected System.Web.UI.WebControls.ImageButton ibtnAtras;
			protected projDataGridWeb.DataGridWeb grid;
			protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				if(!Page.IsPostBack)
				{
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarDatos();
					this.ColspanRowspanHeader();
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
				ltlMensaje.Text = Helper.MsgdbErrMostrarMesaje(true,oSIMAExcepcionDominio.Error.ToString());					
			}
			catch(Exception oException)
			{
				string debug = oException.Message.ToString();
				SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
				Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
			}
			// Put user code to initialize the page here
		}
		private void ColspanRowspanHeader()
		{
			DateTime Fecha  = Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA]);
			int ColDes= 2;
			int i =0;
			for (i=Fecha.Month + ColDes;i<= 13;i++)
			{
				grid.Columns[i].Visible =false;
			}
			
			decimal NewPorcAncho = (80 /(Fecha.Month+1));

			TableCell cell = null;
			m_add.DatagridToDecorate = grid;
			ArrayList header = new ArrayList();


			cell = new TableCell();
			cell.Text = TITULOCONCEPTO;
			cell.RowSpan = 2;
			cell.VerticalAlign = VerticalAlign.Middle;
			header.Add(cell);

			cell = new TableCell();
			cell.Text = TITULOAJECUCIONAL + DateTime.DaysInMonth(Fecha.Year,Fecha.Month) + Utilitario.Constantes.SEPARADORFECHA + Fecha.Month.ToString().PadLeft(2,'0') + Utilitario.Constantes.SEPARADORFECHA + Fecha.Year.ToString() ;
			cell.ColumnSpan = Fecha.Month;
			cell.HorizontalAlign = HorizontalAlign.Center;
			header.Add(cell);

			cell = new TableCell();
			cell.Text = TITULOTOTAL;
			cell.RowSpan = 2;
			cell.VerticalAlign = VerticalAlign.Middle;
			header.Add(cell);

			m_add.AddMergeHeader(header);
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

		public void LlenarGrilla()
		{
			CEstadosFinancieros oCEstadosFinancieros = new  CEstadosFinancieros();
			DataTable dtEstadoFinanciero = oCEstadosFinancieros.ConsultarEstadosFinancierosPorEmpresaCentroyMes(
				Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA].ToString())
				,Convert.ToInt32(Page.Request.Params[KEYQIDEMPRESA])
				,Convert.ToInt32(Page.Request.Params[KEYIDCENTRO])
				,Convert.ToInt32(Page.Request.QueryString[KEYQIDFORMATO])
				,Convert.ToInt32(Page.Request.QueryString[KEYQIDREPORTE])
				);
			
			if(dtEstadoFinanciero!=null)
			{
				grid.DataSource = dtEstadoFinanciero;
			}
			else
			{
				grid.DataSource = dtEstadoFinanciero;
			}
			grid.DataBind();
			// TODO:  Add EstadoFinancierodelPeriodo.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add EstadoFinancierodelPeriodo.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add EstadoFinancierodelPeriodo.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add EstadoFinancierodelPeriodo.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			lblPagina.Text = Page.Request.Params[NOMBRETIPOOPCION].ToString()
				+ Utilitario.Constantes.ESPACIO 
				+ Utilitario.Constantes.SIGNOMAYOR 
				+ Utilitario.Constantes.ESPACIO 
				+ Page.Request.Params[NOMBRECENTRO].ToString() 
				+ Utilitario.Constantes.ESPACIO 
				+ Utilitario.Constantes.SIGNOMAYOR 
				+ Utilitario.Constantes.ESPACIO 
				+ Page.Request.Params[KEYQIDNOMBREFORMATO].ToString() 
				+ Utilitario.Constantes.ESPACIO 
				+ Utilitario.Constantes.SIGNOMAYOR 
				+ Utilitario.Constantes.ESPACIO 
				+ TITULODELPERIODO;
			// TODO:  Add EstadoFinancierodelPeriodo.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add EstadoFinancierodelPeriodo.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add EstadoFinancierodelPeriodo.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add EstadoFinancierodelPeriodo.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add EstadoFinancierodelPeriodo.Exportar implementation
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
			// TODO:  Add EstadoFinancierodelPeriodo.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{			
			DateTime Fecha = Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA].ToString());
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				HyperLink hlk = (HyperLink)e.Item.Cells[0].FindControl(CONTROLINK);
				hlk.Text = Convert.ToString(dr[Enumerados.ColumnasFormato.Nombre.ToString()]);

				if (Convert.ToInt32(dr[Enumerados.ColumnasFormato.IdTipoLinea.ToString()]) != 0 )
				{
					e.Item.BackColor = Color.LightYellow;
					e.Item.Font.Bold = true;
				}
				else
				{
					hlk.Attributes.Add(Utilitario.Constantes.EVENTOONMOUSEOVER,"subrayar('"+ hlk.ClientID.ToString() +"');");
					hlk.Attributes.Add(Utilitario.Constantes.EVENTOONMOUSEOUT,"subrayar('"+ hlk.ClientID.ToString() +"');");
					hlk.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
						string rpath = "window.location.href=" + Utilitario.Constantes.SIGNOCOMILLASIMPLE 
							+ URLDETALLE 
							+ KEYQIDEMPRESA + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYQIDEMPRESA].ToString()
							+ Utilitario.Constantes.SIGNOAMPERSON
							+ KEYIDCENTRO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDCENTRO].ToString()
							+ Utilitario.Constantes.SIGNOAMPERSON
							+ NOMBRECENTRO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[NOMBRECENTRO].ToString()
							+ Utilitario.Constantes.SIGNOAMPERSON
							+ NOMBRETIPOOPCION  + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[NOMBRETIPOOPCION].ToString()
							+ Utilitario.Constantes.SIGNOAMPERSON
							+ KEYQIDNOMBREFORMATO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYQIDNOMBREFORMATO].ToString()
							+ Utilitario.Constantes.SIGNOAMPERSON
							+ KEYQIDFECHA + Utilitario.Constantes.SIGNOIGUAL + Fecha.ToString()
							+ Utilitario.Constantes.SIGNOAMPERSON
							+ KEYQIDFORMATO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYQIDFORMATO].ToString()
							+ Utilitario.Constantes.SIGNOAMPERSON
							+ KEYQIDREPORTE + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYQIDREPORTE].ToString()
							+ Utilitario.Constantes.SIGNOAMPERSON
							+ KEYQIDRUBRO + Utilitario.Constantes.SIGNOIGUAL + dr[COLUMNAIDRUBRO].ToString()
							+ Utilitario.Constantes.SIGNOAMPERSON
							+ KEYQNRODIGITOS + Utilitario.Constantes.SIGNOIGUAL + NRODIGINI.ToString()
							+ Utilitario.Constantes.SIGNOAMPERSON
							+ KEYQDIGCUENTA + Utilitario.Constantes.SIGNOIGUAL + DIGCTA.ToString()
							+ Utilitario.Constantes.SIGNOCOMILLASIMPLE  
							+ Utilitario.Constantes.SIGNOPUNTOYCOMA
							;
						hlk.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,rpath );
				}
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
			}			
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

	}
}
