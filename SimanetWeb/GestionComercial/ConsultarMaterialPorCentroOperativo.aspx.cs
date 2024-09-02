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

namespace SIMA.SimaNetWeb.GestionComercial
{
	/// <summary>
	/// Summary description for ConsultarMaterialPorCentroOperativo.
	/// </summary>
	public class ConsultarMaterialPorCentroOperativo : System.Web.UI.Page, IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Label lblRuta_Pagina;
		protected System.Web.UI.WebControls.Label lblPage;
		protected System.Web.UI.WebControls.Label lblNombreCentroOperativo;
		protected System.Web.UI.WebControls.Label lblFechaInicio;
		protected eWorld.UI.CalendarPopup CalFechaInicio;
		protected System.Web.UI.WebControls.Label lblFechaFin;
		protected eWorld.UI.CalendarPopup CalFechaFin;
		protected System.Web.UI.WebControls.ImageButton ibtnConsultar;
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label lblTitulo;
		#endregion
		
		#region Constantes
		//Key Session y QueryString
		const string KEYQID = "IdCliente";
		const string KEYQNOMBRE = "RazonSocial";
		const string KEYQCO = "CentroOperativo";
		const string KEYQLN = "CodLineaNegocio";
		const string KEYQCABLN = "CabLineaNegocio";
		const string KEYFECHAINICIO = "FechaInicio";
		const string KEYFECHAFIN = "FechaFin";

		//Paginas
		

		//Otros
		const int POSICIONINICIALCOMBO = 0;
		const string TablaImpresion0 = "MaterialesPorCentroOperativo";
		const string GRILLAVACIA ="No existe ningún Material en el centro operativo.";
		const string DEFAULTANO = "01/01/";
		const string NombreGlosaTotales = "TOTAL";
		const int PosicionFchEms = 1;
		const int PosicionMat = 2;
		const int PosicionUndMed = 3;
		const int PosicionDcp = 4;
		const int PosicionStkGrv = 5;
		const int PosicionPrcPmdStkGrv = 6;
		const int PosicionStkExo = 7;
		const int PosicionPrcPmdStkExo = 8;
		const int PosicionPrcUltCmpSol = 9;
		const int PosicionFchUltCmp = 10;
		const int PosicionFchUltSda = 11;
		const int PosicionUbc = 12;
		const int PosicionTotal = 13;
		const string TOOLTIPCONSNAV = "Construcciones Navales";
		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					//CalFechaInicio.SelectedDate = Convert.ToDateTime(DEFAULTANO + DateTime.Today.Year.ToString());
					CalFechaInicio.SelectedDate = Convert.ToDateTime(DEFAULTANO + "1997");
					CalFechaFin.SelectedDate = DateTime.Today.Date;

					this.ConfigurarAccesoControles();
					
					Helper.ReiniciarSession();
					this.LlenarGrilla();
					this.LlenarJScript();
					this.EstadoControles();
					this.LlenarDatos();
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionComercial",this.ToString(),"Se consultaron Clientes por Ventas.",Enumerados.NivelesErrorLog.I.ToString()));
					
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			DataTable dtImpresion = new DataTable();

			DataTable dtMaterialesPorCentroOperativo = new DataTable();
			CMaterial oCMaterial = new CMaterial();

			dtMaterialesPorCentroOperativo =  oCMaterial.ConsultarMaterialesPorCentroOperativo();
			//dtMaterialesPorCentroOperativo =  oCMaterial.ListarMontosVentasRealesPorCliente(Convert.ToInt32(Page.Request.QueryString[KEYQID]),Convert.ToDateTime(CalFechaInicio.SelectedDate),Convert.ToDateTime(CalFechaFin.SelectedDate));

			if(dtVentasPorCliente!=null)
			{
				dtImpresion = dtVentasPorCliente.Copy();
				dtImpresion.TableName = TablaImpresion0;

				DataView dwVentas =	dtVentasPorCliente.DefaultView;
				
				if(dwVentas.Count > POSICIONINICIALCOMBO)
				{
					grid.DataSource	= dwVentas;
					lblResultado.Visible = false;
				}
				else
				{
					grid.DataSource	= null;
					lblResultado.Visible = true;
					lblResultado.Text =	GRILLAVACIA;
				}			
			}
			else
			{
				grid.DataSource	= dtVentasPorCliente;
				lblResultado.Visible = true;
				lblResultado.Text =	GRILLAVACIA;
			}
			
			try
			{
				grid.DataBind();
				CImpresion oCImpresion = new CImpresion();
				oCImpresion.GuardarDataImprimirExportar(dtImpresion,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Mensajes.CODIGOTITULOVENTASREALESPORCLIENTE));
			}
			catch(Exception	ex)
			{
				string a = ex.Message;
				grid.CurrentPageIndex = 0;
				grid.DataBind();
			}	
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarDetalleMontoCliente.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add ConsultarDetalleMontoCliente.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add ConsultarDetalleMontoCliente.LlenarCombos implementation
		}

		public void EstadoControles()
		{
			Helper.SeleccionarItemCombos(this);
		}
		public void LlenarDatos()
		{
			lblNombreRazonSocial.Text = Convert.ToString(Page.Request.QueryString[KEYQNOMBRE]);
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarDetalleMontoCliente.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarDetalleMontoCliente.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			ltlMensaje.Text = Helper.PopupImpresion(URLIMPRESION + KEYQNOMBRE + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQNOMBRE].ToString(),780,700,false,false,false,true,true);
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarDetalleMontoCliente.Exportar implementation
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
			else if (CalFechaFin.SelectedDate.Year >  DateTime.Today.Year)
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

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				
				if(e.Item.Cells[Utilitario.Constantes.POSICIONDEFAULT].Text == NombreGlosaTotales)
				{
					Helper.ConfigurarColorTotalesGrilla(e);
					e.Item.Cells[PosicionCN].Text = Convert.ToDouble(e.Item.Cells[PosicionCN].Text).ToString(Constantes.FORMATODECIMAL4);
					e.Item.Cells[PosicionRN].Text = Convert.ToDouble(e.Item.Cells[PosicionRN].Text).ToString(Constantes.FORMATODECIMAL4);
					e.Item.Cells[PosicionAE].Text = Convert.ToDouble(e.Item.Cells[PosicionAE].Text).ToString(Constantes.FORMATODECIMAL4);
					e.Item.Cells[PosicionMM].Text = Convert.ToDouble(e.Item.Cells[PosicionMM].Text).ToString(Constantes.FORMATODECIMAL4);
					e.Item.Cells[PosicionSV].Text = Convert.ToDouble(e.Item.Cells[PosicionSV].Text).ToString(Constantes.FORMATODECIMAL4);
					e.Item.Cells[PosicionTotal].Text = Convert.ToDouble(e.Item.Cells[PosicionTotal].Text).ToString(Constantes.FORMATODECIMAL4);
					
				}
				else
				{
					e.Item.Cells[PosicionCN].Attributes.Add(Utilitario.Constantes.EVENTOCLICK, Utilitario.Constantes.HISTORIALADELANTE +
						Helper.MostrarVentana(URLMONTOClIENTEPORCOYLN ,KEYQID + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt32(Page.Request.QueryString[KEYQID]).ToString()+ Utilitario.Constantes.SIGNOAMPERSON +
						KEYQCO + Utilitario.Constantes.SIGNOIGUAL + e.Item.Cells[0].Text + Utilitario.Constantes.SIGNOAMPERSON + 
						KEYQLN + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt32(Utilitario.Enumerados.LineaNegocio.ConstruccionesNavales).ToString() + Utilitario.Constantes.SIGNOAMPERSON + 
						KEYQCABLN + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt32(Utilitario.Enumerados.TablasTabla.ProyectosLineasNegocio).ToString()	+ Utilitario.Constantes.SIGNOAMPERSON + 
						KEYQNOMBRE + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQNOMBRE].ToString() + Utilitario.Constantes.SIGNOAMPERSON +
						KEYFECHAINICIO + Utilitario.Constantes.SIGNOIGUAL + CalFechaInicio.SelectedDate.ToString() + Utilitario.Constantes.SIGNOAMPERSON +
						KEYFECHAFIN + Utilitario.Constantes.SIGNOIGUAL + CalFechaFin.SelectedDate.ToString()));
					e.Item.Cells[PosicionCN].Font.Underline = true;
					e.Item.Cells[PosicionCN].ForeColor = System.Drawing.Color.Blue;
					e.Item.Cells[PosicionCN].Text = Convert.ToDouble(e.Item.Cells[PosicionCN].Text).ToString(Constantes.FORMATODECIMAL4);
				
					
					e.Item.Cells[PosicionRN].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.HISTORIALADELANTE +
						Helper.MostrarVentana(URLMONTOClIENTEPORCOYLN,KEYQID + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt32(Page.Request.QueryString[KEYQID]).ToString() + Utilitario.Constantes.SIGNOAMPERSON +
						KEYQCO + Utilitario.Constantes.SIGNOIGUAL + e.Item.Cells[0].Text + Utilitario.Constantes.SIGNOAMPERSON + 
						KEYQLN + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt32(Utilitario.Enumerados.LineaNegocio.ReparacionesNavales).ToString() + Utilitario.Constantes.SIGNOAMPERSON + 
						KEYQCABLN + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt32(Utilitario.Enumerados.TablasTabla.ProyectosLineasNegocio).ToString()	+ Utilitario.Constantes.SIGNOAMPERSON + 
						KEYQNOMBRE + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQNOMBRE].ToString()+ Utilitario.Constantes.SIGNOAMPERSON +
						KEYFECHAINICIO + Utilitario.Constantes.SIGNOIGUAL + CalFechaInicio.SelectedDate.ToString() + Utilitario.Constantes.SIGNOAMPERSON +
						KEYFECHAFIN + Utilitario.Constantes.SIGNOIGUAL + CalFechaFin.SelectedDate.ToString()));
					e.Item.Cells[PosicionRN].Font.Underline = true;
					e.Item.Cells[PosicionRN].ForeColor = System.Drawing.Color.Blue;
					e.Item.Cells[PosicionRN].Text = Convert.ToDouble(e.Item.Cells[PosicionRN].Text).ToString(Constantes.FORMATODECIMAL4);


					
					e.Item.Cells[PosicionAE].Attributes.Add(Utilitario.Constantes.EVENTOCLICK, Utilitario.Constantes.HISTORIALADELANTE +
						Helper.MostrarVentana(URLMONTOClIENTEPORCOYLN,KEYQID + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt32(Page.Request.QueryString[KEYQID]).ToString() + Utilitario.Constantes.SIGNOAMPERSON +
						KEYQCO + Utilitario.Constantes.SIGNOIGUAL + e.Item.Cells[0].Text + Utilitario.Constantes.SIGNOAMPERSON + 
						KEYQLN + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt32(Utilitario.Enumerados.LineaNegocio.ArmasElectronica).ToString()	+ Utilitario.Constantes.SIGNOAMPERSON + 
						KEYQCABLN + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt32(Utilitario.Enumerados.TablasTabla.ProyectosLineasNegocio).ToString()+ Utilitario.Constantes.SIGNOAMPERSON + 
						KEYQNOMBRE + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQNOMBRE].ToString()+ Utilitario.Constantes.SIGNOAMPERSON +
						KEYFECHAINICIO + Utilitario.Constantes.SIGNOIGUAL + CalFechaInicio.SelectedDate.ToString() + Utilitario.Constantes.SIGNOAMPERSON +
						KEYFECHAFIN + Utilitario.Constantes.SIGNOIGUAL + CalFechaFin.SelectedDate.ToString()));
					e.Item.Cells[PosicionAE].Font.Underline = true;
					e.Item.Cells[PosicionAE].ForeColor = System.Drawing.Color.Blue;
					e.Item.Cells[PosicionAE].Text = Convert.ToDouble(e.Item.Cells[PosicionAE].Text).ToString(Constantes.FORMATODECIMAL4);


					
					e.Item.Cells[PosicionMM].Attributes.Add(Utilitario.Constantes.EVENTOCLICK, Utilitario.Constantes.HISTORIALADELANTE +
						Helper.MostrarVentana(URLMONTOClIENTEPORCOYLN,KEYQID + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt32(Page.Request.QueryString[KEYQID]).ToString() + Utilitario.Constantes.SIGNOAMPERSON +
						KEYQCO + Utilitario.Constantes.SIGNOIGUAL + e.Item.Cells[0].Text + Utilitario.Constantes.SIGNOAMPERSON + 
						KEYQLN + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt32(Utilitario.Enumerados.LineaNegocio.MetalMecanico).ToString()+ Utilitario.Constantes.SIGNOAMPERSON +
						KEYQCABLN + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt32(Utilitario.Enumerados.TablasTabla.ProyectosLineasNegocio).ToString()+ Utilitario.Constantes.SIGNOAMPERSON +
						KEYQNOMBRE + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQNOMBRE].ToString()+ Utilitario.Constantes.SIGNOAMPERSON +
						KEYFECHAINICIO + Utilitario.Constantes.SIGNOIGUAL + CalFechaInicio.SelectedDate.ToString() + Utilitario.Constantes.SIGNOAMPERSON +
						KEYFECHAFIN + Utilitario.Constantes.SIGNOIGUAL + CalFechaFin.SelectedDate.ToString()));
					e.Item.Cells[PosicionMM].Font.Underline = true;
					e.Item.Cells[PosicionMM].ForeColor = System.Drawing.Color.Blue;
					e.Item.Cells[PosicionMM].Text = Convert.ToDouble(e.Item.Cells[PosicionMM].Text).ToString(Constantes.FORMATODECIMAL4);


					
					e.Item.Cells[PosicionSV].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.HISTORIALADELANTE +
						Helper.MostrarVentana(URLMONTOClIENTEPORCOYLN, KEYQID + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt32(Page.Request.QueryString[KEYQID]).ToString() + Utilitario.Constantes.SIGNOAMPERSON +
						KEYQCO + Utilitario.Constantes.SIGNOIGUAL + e.Item.Cells[0].Text + Utilitario.Constantes.SIGNOAMPERSON + 
						KEYQLN + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt32(Utilitario.Enumerados.LineaNegocio.Servicios).ToString()+ Utilitario.Constantes.SIGNOAMPERSON + 
						KEYQCABLN + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt32(Utilitario.Enumerados.TablasTabla.ProyectosLineasNegocio).ToString()+ Utilitario.Constantes.SIGNOAMPERSON + 
						KEYQNOMBRE + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQNOMBRE].ToString()+ Utilitario.Constantes.SIGNOAMPERSON +
						KEYFECHAINICIO + Utilitario.Constantes.SIGNOIGUAL + CalFechaInicio.SelectedDate.ToString() + Utilitario.Constantes.SIGNOAMPERSON +
						KEYFECHAFIN + Utilitario.Constantes.SIGNOIGUAL + CalFechaFin.SelectedDate.ToString()));
					e.Item.Cells[PosicionSV].Font.Underline = true;
					e.Item.Cells[PosicionSV].ForeColor = System.Drawing.Color.Blue;
					e.Item.Cells[PosicionSV].Text = Convert.ToDouble(e.Item.Cells[PosicionSV].Text).ToString(Constantes.FORMATODECIMAL4);

					e.Item.Cells[PosicionTotal].Text = Convert.ToDouble(e.Item.Cells[PosicionTotal].Text).ToString(Constantes.FORMATODECIMAL4);
				
					Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				}
				Helper.FiltroporSeleccionConfiguraColumna(e,grid);
			}
			else
			{
				e.Item.Cells[PosicionCN].ToolTip = TOOLTIPCONSNAV;
			}
		}
	}
}
