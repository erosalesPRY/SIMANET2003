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
	/// <summary>
	/// Summary description for ConsultarSaldodeCuentaBancariaporCentro.
	/// </summary>
	public class ConsultarSaldodeCuentaBancariaporCentro : System.Web.UI.Page,IPaginaBase
	{
		#region Constantes
		//const int IDTABLAESTADOCARTAFIANZA=5;
		const string GRILLAVACIA ="No existe ningún Registro.";  
		const string CONTROLINK="hlkCentro";
		const string KEYIDCENTRO = "idCentro";
		const string KEYIDFECHA= "Fecha";

		const string NOMBRECENTRO = "Nombre";

		const string URLDETALLE1="ConsultarSaldodeCuentaBancariaporCentroDetalle.aspx?";
		const string URLDETALLE2="ConsultarSaldodeCtaySubCtaBancariaporCentroDetalle.aspx?";
		const string URLPRINCIPAL ="../../Default.aspx";  

		const string COLORDENAMIENTO = "NombreCentro";
		const int PRODEDURENRO = 1;

		//Columnas DataTable
		const string CANTIDAD = "CANTIDAD";
		const string SOLES = "SOLES";
		const string DOLARES ="DOLARES";
		const string EUROS ="EUROS";

		//Columnas GRILLA
		const string FECHA ="Fecha";
		const string IDCENTROOPERATIVO ="idcentrooperativo";		

		//Otros
		const string TITULOTOTALGENERAL="TOTAL GENERAL";
		#endregion

		#region Variables
		int Cantidad;
		Decimal Soles;
		Decimal Dolares;
		Decimal Euros;	
		int valorDefault =0;
		#endregion Variables

		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminaFiltro;
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnFiltrarSeleccion;
		protected System.Web.UI.WebControls.Label Label1;
		protected eWorld.UI.CalendarPopup CalFechaSaldo;
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
					this.LlenarCombos();
					Helper.CalendarioControlStyle(this.CalFechaSaldo);
					Helper.ReestablecerPagina(this);
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Auditoria",this.ToString(),"Se consultó las Acciones Correctivas.",Enumerados.NivelesErrorLog.I.ToString()));
					this.LlenarGrillaOrdenamientoPaginacion(Utilitario.Constantes.VACIO,Utilitario.Constantes.INDICEPAGINADEFAULT);
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
			this.CalFechaSaldo.DateChanged += new eWorld.UI.DateChangedEventHandler(this.CalFechaSaldo_DateChanged);
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
			// TODO:  Add ConsultarSaldodeCuentaBancariaporCentro.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarSaldodeCuentaBancariaporCentro.LlenarGrillaOrdenamiento implementation
		}
		private DataTable ObtenerDatos()
		{
			//return ((CCuentaBancariaSaldo)new CCuentaBancariaSaldo()).ConsultarSaldosdeCuentasBancariasporCentro(this.CalFechaSaldo.SelectedDate.ToShortDateString(),valorDefault);
			return ((CCuentaBancariaSaldo)new CCuentaBancariaSaldo()).ConsultarSaldosdeCuentasBancariasporCentro(this.CalFechaSaldo.SelectedDate,valorDefault);
		}
		private void Totalizar(DataView dv)
		{
			ArrayList arrTotal = new ArrayList();
			arrTotal.Add((double) Helper.TotalizarDataView(dv,CANTIDAD)[0]);
			arrTotal.Add((double) Helper.TotalizarDataView(dv,SOLES)[0]);
			arrTotal.Add((double) Helper.TotalizarDataView(dv,DOLARES)[0]);
			arrTotal.Add((double) Helper.TotalizarDataView(dv,EUROS)[0]);
			Session[Utilitario.Constantes.STOTALIZAR] = arrTotal;
		}
		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dtGeneral = this.ObtenerDatos();
			if(dtGeneral!=null)
			{
				DataView dwGeneral = dtGeneral.DefaultView;
				dwGeneral.Sort = columnaOrdenar ;
				this.Totalizar(dwGeneral);
				grid.DataSource = dwGeneral;
				grid.Columns[Utilitario.Constantes.POSICIONFOOTERTOTAL].FooterText = Utilitario.Constantes.TEXTOFOOTERTOTAL + Utilitario.Constantes.ESPACIO + dwGeneral.Count.ToString();
				
				CImpresion oCImpresion = new CImpresion();
				oCImpresion.GuardarDataImprimirExportar(dtGeneral,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGOTITULOREPORTEACCIONCONTROLNOPROGRAMADA),columnaOrdenar,indicePagina);
				ibtnImprimir.Visible = true;
				lblResultado.Visible = false;

			}
			else
			{
				grid.DataSource = dtGeneral;
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
			// TODO:  Add ConsultarSaldodeCuentaBancariaporCentro.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
		}

		public void LlenarDatos()
		{
				this.CalFechaSaldo.SelectedDate = (DateTime.Now.AddDays(-1));
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarSaldodeCuentaBancariaporCentro.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarSaldodeCuentaBancariaporCentro.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarSaldodeCuentaBancariaporCentro.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarSaldodeCuentaBancariaporCentro.Exportar implementation
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
			// TODO:  Add ConsultarSaldodeCuentaBancariaporCentro.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{				
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				string pfecha = dr[FECHA].ToString();
				string ppfecha = pfecha.Substring(pfecha.Length-2,2) 
								+ Utilitario.Constantes.SEPARADORFECHA 
								+ pfecha.Substring(pfecha.Length-4,2) 
								+ Utilitario.Constantes.SEPARADORFECHA  
								+ pfecha.Substring(0,4);

				this.CalFechaSaldo.SelectedDate = Convert.ToDateTime(ppfecha);


				string urlPagina =((Convert.ToInt32(dr[IDCENTROOPERATIVO])==2)?URLDETALLE2:URLDETALLE1);
				Helper.ConfiguraColumnaHyperLink(Utilitario.Enumerados.EventosJavaScript.OnClick,e.Item.Cells[0],grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex,
												Helper.HistorialIrAdelantePersonalizado(this.CalFechaSaldo.ID.ToString())
												,Helper.MostrarVentana(urlPagina,KEYIDCENTRO + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr[IDCENTROOPERATIVO])
																					+ Utilitario.Constantes.SIGNOAMPERSON
																					+ KEYIDFECHA + Utilitario.Constantes.SIGNOIGUAL + ppfecha.ToString()
																					+ Utilitario.Constantes.SIGNOAMPERSON
																					+ NOMBRECENTRO + Utilitario.Constantes.SIGNOIGUAL + e.Item.Cells[1].Text)
												);
				
				
				Cantidad = Cantidad + Convert.ToInt32(e.Item.Cells[2].Text );
				Soles = Soles + Convert.ToDecimal(e.Item.Cells[3].Text);
				Dolares = Dolares + Convert.ToDecimal(e.Item.Cells[4].Text);
				Euros = Euros + Convert.ToDecimal(e.Item.Cells[5].Text);

				e.Item.Cells[3].Text= Convert.ToDouble(e.Item.Cells[3].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4.ToString());
				e.Item.Cells[4].Text= Convert.ToDouble(e.Item.Cells[4].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4.ToString());
				e.Item.Cells[5].Text= Convert.ToDouble(e.Item.Cells[5].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4.ToString());

				
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				Helper.FiltroporSeleccionConfiguraColumna(e,grid);
			}
			if(e.Item.ItemType == ListItemType.Footer)
			{
				e.Item.Cells[0].ColumnSpan=2;e.Item.Cells[1].Visible=false;
				ArrayList arrTotal = (ArrayList) Session[Utilitario.Constantes.STOTALIZAR];
				e.Item.Cells[2].Text= Convert.ToDouble(arrTotal[0]).ToString();
				e.Item.Cells[3].Text= Convert.ToDouble(arrTotal[1]).ToString(Utilitario.Constantes.FORMATODECIMAL4.ToString());
				e.Item.Cells[4].Text= Convert.ToDouble(arrTotal[2]).ToString(Utilitario.Constantes.FORMATODECIMAL4.ToString());
				e.Item.Cells[5].Text= Convert.ToDouble(arrTotal[3]).ToString(Utilitario.Constantes.FORMATODECIMAL4.ToString());

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

		private void grid_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType== ListItemType.Footer) 
			{ 
				e.Item.Font.Bold = true;
				e.Item.Cells[0].Text = TITULOTOTALGENERAL;
				e.Item.Cells[1].Text = Cantidad.ToString();
				e.Item.Cells[2].Text = Soles.ToString(Utilitario.Constantes.FORMATODECIMAL4.ToString());
				e.Item.Cells[3].Text = Dolares.ToString(Utilitario.Constantes.FORMATODECIMAL4.ToString());
				e.Item.Cells[4].Text = Euros.ToString(Utilitario.Constantes.FORMATODECIMAL4.ToString());
				e.Item.Height=30;
			} 	
			if (e.Item.ItemType == ListItemType.Header)
			{e.Item.Height=30;}

		}

		private void ibtnEliminaFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}

		private void CalFechaSaldo_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
		{
		}

		private void CalFechaSaldo_DateChanged(object sender, System.EventArgs e)
		{
			valorDefault=2;
			this.LlenarGrillaOrdenamientoPaginacion(Utilitario.Constantes.VACIO,Utilitario.Constantes.INDICEPAGINADEFAULT);
		}
	}
}
