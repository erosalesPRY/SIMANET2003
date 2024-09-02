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
using SIMA.Controladoras.GestionComercial;
using SIMA.Controladoras.General;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;

namespace SIMA.SimaNetWeb.GestionComercial.Cliente
{
	/// <summary>
	/// Summary description for ConsultarDetalleMontoClientePorCO.
	/// </summary>
	public class ConsultarDetalleMontoClientePorCO : System.Web.UI.Page, IPaginaBase
	{
		#region Controles

		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblRuta_Pagina;
		protected System.Web.UI.WebControls.Label lblPage;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblFechaInicio;
		protected System.Web.UI.WebControls.Label lblFechaFin;
		protected System.Web.UI.WebControls.CompareValidator cvFechaTermino;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected eWorld.UI.CalendarPopup CalFechaInicio;
		protected eWorld.UI.CalendarPopup Calendarpopup1;
		protected eWorld.UI.CalendarPopup CalFechaFin;
		protected System.Web.UI.WebControls.Label lblNombreRazonSocial;
		protected System.Web.UI.WebControls.ImageButton ibtnConsultar;
		protected projDataGridWeb.DataGridWeb dgConsulta;
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
		protected System.Web.UI.WebControls.ImageButton ibtnGraficoBarraTipoClientePorCO;
		#endregion

		#region Constantes
		//Key Session y QueryString
		const string KEYQID = "IdCliente";
		const string KEYQNOMBRE = "RazonSocial";
		const string KEYQCO = "CentroOperativo";
		const string KEYQLN = "CodLineaNegocio";
		const string KEYQCABLN = "CabLineaNegocio";

		//Otros
		const int POSICIONINICIALCOMBO = 0;
		const string TablaImpresion0 = "VentaRelaesPorCliente";
		const string DTVENTASPORCLIENTEPORCODINAMICO = "DataTabledtVentasPorClientePorCODinamico";
		const string GRILLAVACIA ="No existe ning�n Cliente por Linea de Newocio.";
		const string DEFAULTANOINICIO = "01/01/";
		const string DEFAULTANOFIN = "31/12/";
		const int ANCHO = 80;
		const int ANCHOORDEN = 15;
		const int MULTIPLO = 15;

		//Paginas
		const string URLIMPRESION = "PopupImpresionConsultarDetalleMontoClientePorCO.aspx?";
		#endregion

		#region Variables
		double [] montos;
		int [] anchos;
		#endregion
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					CalFechaInicio.SelectedDate = Convert.ToDateTime(DEFAULTANOINICIO + Convert.ToString (DateTime.Today.Year -5));
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarJScript();
					this.LlenarDatos();
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionComercial",this.ToString(),"Se consultaron Clientes por Ventas por Centro Operativo.",Enumerados.NivelesErrorLog.I.ToString()));
					this.LlenarGrilla();
					
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
			this.ibtnConsultar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnConsultar_Click);
			this.ibtnImprimir.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnImprimir_Click);
			this.dgConsulta.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgConsulta_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			DataTable dtImpresion = new DataTable();

			DataTable dtVentasPorClientePorCO = new DataTable();
			CCliente oCCliente = new CCliente();

			dtVentasPorClientePorCO =  oCCliente.ListarMontosVentasRealesPorClientePorCO(Convert.ToInt32(Page.Request.QueryString[KEYQID]),Convert.ToDateTime(CalFechaInicio.SelectedDate),Convert.ToDateTime(CalFechaFin.SelectedDate));

			DataTable dtVentasPorClientePorCODinamico = new DataTable(DTVENTASPORCLIENTEPORCODINAMICO);

			for(int i = 1; i <= dtVentasPorClientePorCO.Columns.Count - 1 ; i++)
			{
				dtVentasPorClientePorCODinamico.Columns.Add(dtVentasPorClientePorCO.Columns[i].ColumnName);
			}
			dtVentasPorClientePorCO.Columns.RemoveAt(0);
			dtVentasPorClientePorCODinamico = dtVentasPorClientePorCO;

			if(dtVentasPorClientePorCODinamico != null)
			{
				dtImpresion = dtVentasPorClientePorCODinamico.Copy();
				dtImpresion.TableName = TablaImpresion0;

				DataView dwVentas =	dtVentasPorClientePorCODinamico.DefaultView;
				
				if(dwVentas.Count > POSICIONINICIALCOMBO)
				{
					dgConsulta.DataSource	= dwVentas;
					montos = new double[dtVentasPorClientePorCODinamico.Columns.Count];
					anchos = this.CalcularAnchos(dtVentasPorClientePorCODinamico);
					dgConsulta.Width = this.CalcularAnchoTotal(anchos);
					lblResultado.Visible = false;
				}
				else
				{
					dgConsulta.DataSource	= null;
					lblResultado.Visible = true;
					lblResultado.Text =	GRILLAVACIA;
				}			
			}
			else
			{
				dgConsulta.DataSource	= dtVentasPorClientePorCODinamico;
				lblResultado.Visible = true;
				lblResultado.Text =	GRILLAVACIA;
			}
			
			try
			{
				dgConsulta.DataBind();
				CImpresion oCImpresion = new CImpresion();
				oCImpresion.GuardarDataImprimirExportar(dtImpresion,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Mensajes.CODIGOTITULOVENTASREALESPORCLIENTEPORCO));
			}
			catch(Exception	ex)
			{
				string a = ex.Message;
				dgConsulta.CurrentPageIndex = 0;
				dgConsulta.DataBind();
			}	
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarDetalleMontoClientePorCO.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add ConsultarDetalleMontoClientePorCO.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add ConsultarDetalleMontoClientePorCO.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			lblNombreRazonSocial.Text = Page.Request.QueryString[KEYQNOMBRE].ToString();
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarDetalleMontoClientePorCO.LlenarJScript implementation		
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarDetalleMontoClientePorCO.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			ltlMensaje.Text = Helper.PopupImpresion(URLIMPRESION + KEYQNOMBRE + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQNOMBRE].ToString(),780,700,false,false,false,true,true);
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarDetalleMontoClientePorCO.Exportar implementation
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
			if(CalFechaInicio.SelectedDate.Year < Utilitario.Constantes.ANOMINIMA)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesErrorComercialUsuario(Mensajes.CODIGOMENSAJEVALIDACIONFECHAINICIO));
				return false;
			}
			else if (CalFechaFin.SelectedDate.Year > DateTime.Today.Year)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesErrorComercialUsuario(Mensajes.CODIGOMENSAJEVALIDACIONFECHATERMINOCONFECHAACTUAL));
				return false;
			}
			if(!Helper.ValidarRangoFechas(CalFechaInicio.SelectedDate,CalFechaFin.SelectedDate))
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesErrorComercialUsuario(Mensajes.CODIGOMENSAJEVALIDACIONFECHATERMINO));
				return false;	
			}
			return true;
		}

		#endregion

		private void ibtnConsultar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if(this.ValidarFiltros())
			{
				this.LlenarGrilla();
			}
		}


		private int[] CalcularAnchos(DataTable dt)
		{
			int [] array = new int[dt.Columns.Count];

			array[Constantes.POSICIONCONTADOR] = ANCHO;

			for(int i=1; i<dt.Columns.Count;i++)
			{
				array[i] = dt.Columns[i].ColumnName.Length;
				for(int j=0;j<dt.Rows.Count;j++)
				{
					if(dt.Rows[j][i].ToString().Length > array[i])
					{
						array[i] = dt.Rows[j][i].ToString().Length;
					}
				}
			}
			for(int k=1;k<array.Length;k++)
			{
				array[k] *= MULTIPLO;
			}
			return array;
		}

		private int CalcularAnchoTotal(int[] ancho)
		{
			int MontoTotal = 0;
			foreach(int i in ancho)
			{
				MontoTotal += i;
			}

			return MontoTotal;
		}

		private void dgConsulta_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				
				e.Item.Cells[Constantes.POSICIONCONTADOR].Width = anchos[Constantes.POSICIONCONTADOR];
				e.Item.Cells[Constantes.POSICIONCONTADOR].HorizontalAlign = HorizontalAlign.Left;
				
				for(int i=1; i<e.Item.Cells.Count; i++)
				{
					montos[i] = montos[i] + Convert.ToDouble(e.Item.Cells[i].Text);
					e.Item.Cells[i].Width = anchos[i];
					e.Item.Cells[i].HorizontalAlign = HorizontalAlign.Right;
					e.Item.Cells[i].Text = Convert.ToDouble(e.Item.Cells[i].Text).ToString(Constantes.FORMATODECIMAL4);
				}
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
			}
		}

		private void ibtnImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Imprimir();
		}
	}
}
