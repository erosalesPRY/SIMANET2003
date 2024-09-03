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
using SIMA.Controladoras.GestionFinanciera;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;

namespace SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancieros.Directorio
{
	/// <summary>
	/// Summary description for ConsultarCostosdeProduccionDirectos.
	/// </summary>
	public class ConsultarCostosdeProduccionDirectos : System.Web.UI.Page, IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label lblPeriodo;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label lblMes;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblLN;
		protected projDataGridWeb.DataGridWeb grid;	
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label lblCliente;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label lblServicio;		
		protected System.Web.UI.WebControls.Label lblDesCostoProduccion;
		#endregion

		#region Constantes
		private const string URLDETALLE="ConsultarCostosdeProduccionDirectosDetalle.aspx?";
		const string URLPAGINAADMINISTRACIONORBSERVACION="DetalleAdministrarObservacionesEstadosFinancieros.aspx?";
		private const string GRILLAVACIA="No existen registros";
		private const string MENSAJECONSULTAR="Se consulto el Detalle de Cuentas por Provisionar/Liquidar";
		private const string KEYID="KEYID";
		private const string KEYIDPERIODO="KEYIDPERIODO";
		private const string KEYIDMES="KEYIDMES";
		private const string KEYCONCEPTO="KEYCONCEPTO";
		const string KEYIDCENTROOPERATIVO="IdCentroOperativo";
		const string KEYMATSERMOB ="KEYMATSERMOB";
		const string KEYTIPOCOSTO ="KEYTIPOCOSTO";
		const string KEYIDCENTRO ="IdCentro";
		const string KEYLN ="LN";
		const string KEYCOD_DIV = "KEYCOD_DIV";
		const string KEYNRO_VAL = "NRO_VAL";
		const string KEYNRO_OTS = "NRO_OTS";
		const string KEYCLIENTE = "KEYCLIENTE";
		const string KEYSERVICIO = "KEYSERVICIO";
		const string KEYFECHA = "KEYFECHA";
		const string ALERTA = "../../../imagenes/alert.gif";
		const string CONTROLIMGBUTTON = "imgCaducidad";

		const string KEYQIDOBSERVACION="IdObservacion";
		const string KEYQIDFORMATO = "IdFormato";
		const string KEYQIDRUBRO = "IdRubro";
		const string KEYQIDFECHA = "efFecha";
		const string  KEYQPERIODO = "periodo";
		const string KEYQTIPRCS="tip_rcs";
		const string KEYQNUEVOSSOLES = "MILNS";
		const string KEYQOT ="OT";

		//********
		//Para Proyecto Liquidado
		private const string KEYIDLIQUIDADO="IdProyectoLiquidado";
		//********

		#endregion

		#region Variables
		double TotMonto = 0;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.HtmlControls.HtmlTextArea campo1;
		double TotCantidad = 0;

		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					Helper.ReiniciarSession();
					this.LlenarDatos();
					this.ConfigurarAccesoControles();
					this.LlenarGrilla();
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Utilitario.Enumerados.NombresdeModulo.GestiónComercial.ToString(),this.ToString(),MENSAJECONSULTAR,Enumerados.NivelesErrorLog.I.ToString()));			
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
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public DataTable ObtenerDatos()
		{
			CEstadosFinancieros oCEstadosFinancieros = new CEstadosFinancieros();
			return oCEstadosFinancieros.ConsultarCostoProduccionDirecto(Convert.ToInt32(Page.Request.Params[KEYIDCENTRO]),Page.Request.QueryString[KEYCOD_DIV].ToString(), Page.Request.QueryString[KEYNRO_VAL].ToString(),
																		Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO]),Convert.ToInt32(Page.Request.Params[KEYIDPERIODO]),Convert.ToInt32(Page.Request.Params[KEYIDMES]),Convert.ToInt32(Page.Request.Params[KEYQIDRUBRO]));
		}

		public void Totalizar (DataView dwTotales)
		{
			if (dwTotales != null)
			{
				double [] aArreglo = Helper.TotalizarDataView(dwTotales,"monto");
				TotMonto = aArreglo[0];
				aArreglo = Helper.TotalizarDataView(dwTotales,"cantidad");
				TotCantidad = aArreglo[0];
			}
		}


		public void LlenarGrilla()
		{
			DataTable dt = this.ObtenerDatos();
			
			if(dt!=null)
			{
				DataView dw = dt.DefaultView;
				dw.RowFilter = Helper.ObtenerFiltro(this);
				this.Totalizar(dw);
				if(dw.Count>0)
				{
					grid.PageSize = Helper.ObtenerCantidadRegistrosPorGrilla(7,12,18);
					if(Convert.ToInt32(Session[Utilitario.Constantes.KEYQOBSERVACION])==1)
					{
							grid.Columns[0].Visible=true;
							grid.Columns[4].Visible=true;
					}
					grid.DataSource = dw;
					this.lblResultado.Visible = false;
				}
				else
				{
					grid.DataSource = null;
					lblResultado.Visible = true;
					lblResultado.Text = GRILLAVACIA;
				}
			}
			else
			{
				grid.DataSource = dt;
				lblResultado.Text = GRILLAVACIA;
			}
			
			try
			{
				grid.DataBind();
			}
			catch	
			{
				grid.CurrentPageIndex = Utilitario.Constantes.ValorConstanteCero;
				grid.DataBind();
			}
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarCostosdeProduccionDirectos.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add ConsultarCostosdeProduccionDirectos.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add ConsultarCostosdeProduccionDirectos.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			lblLN.Text = Page.Request.QueryString[KEYCONCEPTO].ToString();
			lblPeriodo.Text = Page.Request.QueryString[KEYIDPERIODO].ToString();
			lblMes.Text = Helper.ObtenerNombreMes(Convert.ToInt32(Page.Request.QueryString[KEYIDMES].ToString()),SIMA.Utilitario.Enumerados.TipoDatoMes.NombreCompleto).ToUpper();
			lblCliente.Text = Page.Request.QueryString[KEYCLIENTE].ToString();
			lblServicio.Text = (Page.Request.QueryString[KEYFECHA].ToString() == ""?"":Page.Request.QueryString[KEYFECHA].ToString().Substring(0,10));
			if (lblServicio.Text !="")
				lblServicio.Text = " DEL " + lblServicio.Text;

			lblServicio.Text = "OTS NRO " + Page.Request.QueryString[KEYNRO_OTS].ToString() +
							   lblServicio.Text + Utilitario.Constantes.SEPARADORLINEA + Page.Request.QueryString[KEYSERVICIO].ToString();

			if(Page.Request.QueryString[KEYIDLIQUIDADO]!=null)
			{
				Label3.Visible=false;
				lblPeriodo.Visible=false;
				Label2.Visible=false;
				lblMes.Visible=false;
			}
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarCostosdeProduccionDirectos.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarCostosdeProduccionDirectos.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarCostosdeProduccionDirectos.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarCostosdeProduccionDirectos.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add ConsultarCostosdeProduccionDirectos.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ConsultarCostosdeProduccionDirectos.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				
		
					e.Item.Cells[2].Font.Underline = true;
					e.Item.Cells[2].ForeColor = System.Drawing.Color.Blue;

					if(Page.Request.QueryString[KEYIDLIQUIDADO]!=null)
					{
						e.Item.Cells[2].Attributes.Add(Constantes.EVENTOCLICK, Constantes.HISTORIALADELANTE + Constantes.POPUPDEESPERA + 
							Helper.MostrarVentana(URLDETALLE, 
							KEYMATSERMOB + Constantes.SIGNOIGUAL + dr["tipo"].ToString() + Constantes.SIGNOAMPERSON +
							KEYTIPOCOSTO + Constantes.SIGNOIGUAL + dr["descripcion"].ToString() + Constantes.SIGNOAMPERSON +
							KEYIDCENTRO + Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDCENTRO] + Constantes.SIGNOAMPERSON +
							KEYLN + Constantes.SIGNOIGUAL + Page.Request.Params[KEYLN] + Constantes.SIGNOAMPERSON +
							KEYCOD_DIV + Constantes.SIGNOIGUAL + Page.Request.Params[KEYCOD_DIV] + Constantes.SIGNOAMPERSON +
							KEYNRO_VAL + Constantes.SIGNOIGUAL + Page.Request.Params[KEYNRO_VAL] + Constantes.SIGNOAMPERSON +
							KEYNRO_OTS + Constantes.SIGNOIGUAL + Page.Request.Params[KEYNRO_OTS] + Constantes.SIGNOAMPERSON +
							KEYFECHA + Constantes.SIGNOIGUAL + Page.Request.Params[KEYFECHA] + Constantes.SIGNOAMPERSON +
							KEYIDLIQUIDADO + Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDLIQUIDADO] + Constantes.SIGNOAMPERSON +
							KEYCONCEPTO + Constantes.SIGNOIGUAL + Page.Request.Params[KEYCONCEPTO] + Constantes.SIGNOAMPERSON +
							KEYIDPERIODO + Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDPERIODO] + Constantes.SIGNOAMPERSON +
							KEYIDMES + Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDMES] + Constantes.SIGNOAMPERSON +
							KEYCLIENTE + Constantes.SIGNOIGUAL + Page.Request.Params[KEYCLIENTE] + Constantes.SIGNOAMPERSON + 
							KEYSERVICIO + Constantes.SIGNOIGUAL + Page.Request.Params[KEYSERVICIO]));
					}
					else
					{
						e.Item.Cells[2].Attributes.Add(Constantes.EVENTOCLICK, Constantes.HISTORIALADELANTE + Constantes.POPUPDEESPERA + 
							Helper.MostrarVentana(URLDETALLE, 
							KEYMATSERMOB + Constantes.SIGNOIGUAL + dr["tipo"].ToString() + Constantes.SIGNOAMPERSON +
							KEYTIPOCOSTO + Constantes.SIGNOIGUAL + dr["descripcion"].ToString() + Constantes.SIGNOAMPERSON +
							KEYIDCENTRO + Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDCENTRO] + Constantes.SIGNOAMPERSON +
							KEYLN + Constantes.SIGNOIGUAL + Page.Request.Params[KEYLN] + Constantes.SIGNOAMPERSON +
							KEYCOD_DIV + Constantes.SIGNOIGUAL + Page.Request.Params[KEYCOD_DIV] + Constantes.SIGNOAMPERSON +
							KEYNRO_VAL + Constantes.SIGNOIGUAL + Page.Request.Params[KEYNRO_VAL] + Constantes.SIGNOAMPERSON +
							KEYNRO_OTS + Constantes.SIGNOIGUAL + Page.Request.Params[KEYNRO_OTS] + Constantes.SIGNOAMPERSON +
							KEYFECHA + Constantes.SIGNOIGUAL + Page.Request.Params[KEYFECHA] + Constantes.SIGNOAMPERSON +
							KEYCONCEPTO + Constantes.SIGNOIGUAL + Page.Request.Params[KEYCONCEPTO] + Constantes.SIGNOAMPERSON +
							KEYIDPERIODO + Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDPERIODO] + Constantes.SIGNOAMPERSON +
							KEYIDMES + Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDMES] + Constantes.SIGNOAMPERSON +
							KEYCLIENTE + Constantes.SIGNOIGUAL + Page.Request.Params[KEYCLIENTE] + Constantes.SIGNOAMPERSON + 
							KEYSERVICIO + Constantes.SIGNOIGUAL + Page.Request.Params[KEYSERVICIO]));
					}
					
					e.Item.Cells[3].Text = (Convert.ToDouble(dr["monto"].ToString())/TotMonto*100).ToString(Constantes.FORMATODECIMAL4);

					

				if(Convert.ToInt32(Session[Utilitario.Constantes.KEYQOBSERVACION])==1)
				{
					e.Item.Cells[Constantes.POSICIONCONTADOR].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
					e.Item.Cells[Constantes.POSICIONCONTADOR].Font.Underline=true;
					e.Item.Cells[Utilitario.Constantes.POSICIONCONTADOR].ForeColor = System.Drawing.Color.Blue;

					string modoPagina="";
					if(dr["observacion"].ToString()==String.Empty)
					{
						modoPagina =Enumerados.ModoPagina.N.ToString();
					}
					else
					{
						modoPagina =Enumerados.ModoPagina.M.ToString();
					}
					string parametros =KEYQIDFORMATO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQIDFORMATO].ToString() +
						Utilitario.Constantes.SIGNOAMPERSON 
						+ KEYIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYIDCENTRO].ToString()
						+ Utilitario.Constantes.SIGNOAMPERSON 	
						+ KEYQIDFECHA + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYIDMES].ToString()
						+ Utilitario.Constantes.SIGNOAMPERSON 	
						+ KEYQPERIODO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYIDPERIODO].ToString()
						+ Utilitario.Constantes.SIGNOAMPERSON 	
						+ KEYQIDRUBRO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQIDRUBRO].ToString()
						+ Utilitario.Constantes.SIGNOAMPERSON 	
						+ KEYLN + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYLN].ToString()
						+ Utilitario.Constantes.SIGNOAMPERSON 	
						+ KEYQOT + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYNRO_VAL].ToString()
						+ Utilitario.Constantes.SIGNOAMPERSON 	
						+ KEYQTIPRCS + Utilitario.Constantes.SIGNOIGUAL + dr["tipo"].ToString()
						+ Utilitario.Constantes.SIGNOAMPERSON 	
						+ Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL 
						+ modoPagina
						+ Utilitario.Constantes.SIGNOAMPERSON 	
						+ KEYQIDOBSERVACION + Utilitario.Constantes.SIGNOIGUAL + dr["idobservacion"].ToString();


					e.Item.Cells[Constantes.POSICIONCONTADOR].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.PopupBusqueda(URLPAGINAADMINISTRACIONORBSERVACION + parametros,600,400));
				
				
					System.Web.UI.WebControls.Image ibtn1=(System.Web.UI.WebControls.Image)e.Item.Cells[4].FindControl(CONTROLIMGBUTTON);	
					if (Convert.ToString(dr["observacion"])== String.Empty)
					{
						ibtn1.ImageUrl = ALERTA;
					}
					else
					{
						ibtn1.Visible = false;
					}
				}
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,Utilitario.Helper.MostrarDatosEnCajaTexto("campo1",dr["observacion"].ToString()));
			}
			if(e.Item.ItemType == ListItemType.Footer)
			{
				e.Item.Cells[2].Text = TotMonto.ToString(Constantes.FORMATODECIMAL4);
			}
		}
	}
}
