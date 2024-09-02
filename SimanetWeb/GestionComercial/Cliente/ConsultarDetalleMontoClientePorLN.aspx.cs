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
	/// Summary description for ConsultarDetalleMontoClientePorLN.
	/// </summary>
	public class ConsultarDetalleMontoClientePorLN : System.Web.UI.Page, IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblRuta_Pagina;
		protected System.Web.UI.WebControls.Label lblPage;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblFechaInicio;
		protected System.Web.UI.WebControls.Label lblFechaFin;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.CompareValidator cvFechaTermino;
		protected eWorld.UI.CalendarPopup CalFechaInicio;
		protected eWorld.UI.CalendarPopup CalFechaFin;
		protected System.Web.UI.WebControls.Label lblNombreRazonSocial;
		protected System.Web.UI.WebControls.ImageButton ibtnConsultar;
		protected projDataGridWeb.DataGridWeb dgConsulta;
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
		#endregion

		#region Constantes
		//Key Session y QueryString
		const string KEYQID = "IdCliente";
		const string KEYQNOMBRE = "RazonSocial";
		const string KEYQCO = "CentroOperativo";
		const string KEYQLN = "CodLineaNegocio";
		const string KEYQCABLN = "CabLineaNegocio";
		const string FECHAINICIAL = "FechaInicial";
		const string FECHAFINAL = "FechaFinal";

		//Paginas
		const string URLIMPRESION = "PopupImpresionConsultarDetalleMontoClientePorLN.aspx?";

		//Otros
		const int POSICIONINICIALCOMBO = 0;
		const string TablaImpresion0 = "VentaRelaesPorCliente";
		const string GRILLAVACIA ="No existe ningún Cliente por Linea de Newocio.";
		const string DEFAULTANOINICIO = "01/01/";
		const string DEFAULTANOFIN = "31/12/";
		const string DTDVENTASPORCLIENTEPORLNDINAMICO = "DataTableVentasPorClientePorLNDinamico";
		const string URLREPORTEDETALLEVENTASCLIENTELINEANEGOCIO = "../Reportes/GraficoDetalleVentasClientePorLN.aspx?";
		const int ANCHO = 90;
		const int MULTIPLO = 15;
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
					CalFechaInicio.SelectedDate = Convert.ToDateTime(DEFAULTANOINICIO + Convert.ToString (DateTime.Today.Year -4));

					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarJScript();
					this.LlenarDatos();
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionComercial",this.ToString(),"Se consultaron Clientes por Ventas por Linea de Negocio.",Enumerados.NivelesErrorLog.I.ToString()));
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

			DataTable dtVentasPorClientePorLN = new DataTable();
			CCliente oCCliente = new CCliente();

			dtVentasPorClientePorLN =  oCCliente.ListarMontosVentasRealesPorClientePorLN(Convert.ToInt32(Page.Request.QueryString[KEYQID]),Convert.ToDateTime(CalFechaInicio.SelectedDate),Convert.ToDateTime(CalFechaFin.SelectedDate));
						
			DataTable dtVentasPorClientePorLNDinamico = new DataTable(DTDVENTASPORCLIENTEPORLNDINAMICO);
			for(int i = 1; i <= dtVentasPorClientePorLN.Columns.Count - 1 ; i++)
			{
				dtVentasPorClientePorLNDinamico.Columns.Add(dtVentasPorClientePorLN.Columns[i].ColumnName);
			}
			dtVentasPorClientePorLN.Columns.RemoveAt(0);
			dtVentasPorClientePorLNDinamico = dtVentasPorClientePorLN; 

			if(dtVentasPorClientePorLNDinamico != null)
			{
				dtImpresion = dtVentasPorClientePorLNDinamico.Copy();
				dtImpresion.TableName = TablaImpresion0;

				DataView dwVentas =	dtVentasPorClientePorLNDinamico.DefaultView;
				
				if(dwVentas.Count > POSICIONINICIALCOMBO)
				{
					dgConsulta.DataSource	= dwVentas;
					montos = new double[dtVentasPorClientePorLNDinamico.Columns.Count];
					anchos = this.CalcularAnchos(dtVentasPorClientePorLNDinamico);
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
				dgConsulta.DataSource	= dtVentasPorClientePorLNDinamico;
				lblResultado.Visible = true;
				lblResultado.Text =	GRILLAVACIA;
			}
			
			try
			{
				dgConsulta.DataBind();
				CImpresion oCImpresion = new CImpresion();
				oCImpresion.GuardarDataImprimirExportar(dtImpresion,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Mensajes.CODIGOTITULOVENTASREALESPORCLIENTEPORLN));		
				
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
			// TODO:  Add ConsultarDetalleMontoClientePorLN.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add ConsultarDetalleMontoClientePorLN.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add ConsultarDetalleMontoClientePorLN.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			lblNombreRazonSocial.Text = Page.Request.QueryString[KEYQNOMBRE].ToString();
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarDetalleMontoClientePorLN.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarDetalleMontoClientePorLN.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			ltlMensaje.Text = Helper.PopupImpresion(URLIMPRESION + KEYQNOMBRE + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQNOMBRE].ToString(),780,700,false,false,false,true,true);
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarDetalleMontoClientePorLN.Exportar implementation
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
			else if(!Helper.ValidarRangoFechas(CalFechaInicio.SelectedDate,CalFechaFin.SelectedDate))
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

			for(int i=1; i<dt.Columns.Count; i++)
			{
				array[i] = dt.Columns[i].ColumnName.Length;
				for(int j=0; j<dt.Rows.Count;j++)
				{
					if(dt.Rows[j][i].ToString().Length > array[i])
					{
						array[i] = dt.Rows[j][i].ToString().Length;
					}
				}
			}
			for(int k=1; k<array.Length; k++)
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
