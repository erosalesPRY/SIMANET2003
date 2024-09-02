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

namespace SIMA.SimaNetWeb.GestionFinanciera.CuentasPorCobrarPagar.CuentasPorCobrarPagarDirectorio
{
	public class ConsultarOtrasCuentasPorPagar : System.Web.UI.Page, IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		#endregion
		#region Constantes
		//Url
		private const string URLDETALLE="ConsultarDetalleCuentasPorPagarOtros.aspx?";

		//Query String
		private const string KEYIDSUBCUENTA = "IdCuenta";
		private const string KEYIDCUENTA = "KEYIDCUENTA"; 
		private const string KEYIDCENTROOPERATIVO ="KEYIDCENTROOPERATIVO";
		private const string KEYQFLAGDIRECTORIO= "FlagDirectorio";

		const string PERIODO="Periodo";
		const string MES="Mes";
		
		//Mensajes
		private const string GRILLAVACIA="No existen registros";
		private const string MENSAJECONSULTAR="Se Consulto Cuentas Por Pagar Otros";

		#endregion
		#region Variables
		private double Callao=0;
		private double Chimbote=0;
		private double Peru=0;
		private double Iquitos=0;
		protected projDataGridWeb.DataGridWeb grid;
		private double Total=0;
		#endregion
	
		private void Page_Load(object sender, System.EventArgs e)
		{
				if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					this.LlenarJScript();
					this.LlenarGrillaOrdenamientoPaginacion("",0);
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
		public void LlenarGrilla()
		{
			
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			
		}

		public DataTable ObtenerDatos()
		{
			CCuentasPorCobrarPagar oCCuentasPorCobrarPagar =  new CCuentasPorCobrarPagar();
			if (Convert.ToInt32(Page.Request.QueryString[KEYQFLAGDIRECTORIO].ToString()) == Constantes.POSICIONINDEXUNO)
			{
			return oCCuentasPorCobrarPagar.ConsultarSubCuentasPorCobrarPagarPorCuentaAlCierre(Convert.ToInt32(Page.Request.QueryString[KEYIDSUBCUENTA]));
			}
			else
			{
				return oCCuentasPorCobrarPagar.ConsultarSubCuentasPorCobrarPagarPorCuenta(Convert.ToInt32(Page.Request.QueryString[KEYIDSUBCUENTA]));
			}
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
		{
			DataTable dtProyectos =  ObtenerDatos();
			
			if(dtProyectos!=null)
			{
				DataView dwProyectos = dtProyectos.DefaultView;
				dwProyectos.Sort = columnaOrdenar ;
				dwProyectos.RowFilter = Helper.ObtenerFiltro(this);
				if(dwProyectos.Count>0)
				{
					grid.CurrentPageIndex = indicePagina;
					grid.DataSource = dwProyectos;
					grid.Columns[2].FooterText = dwProyectos.Count.ToString();
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
				grid.DataSource = dtProyectos;
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

		public void LlenarCombos()
		{
		}

		public void LlenarDatos()
		{
		}

		public void LlenarJScript()
		{
		}

		public void RegistrarJScript()
		{
	

		}

		public void Imprimir()
		{
		}

		public void Exportar()
		{
			
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
			return true;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				Callao+=Convert.ToDouble(dr["MSimaCallao"]);
				Chimbote+=Convert.ToDouble(dr["MSimaChimbote"]);
				Peru+=Convert.ToDouble(dr["MSimaPeru"]);
				Iquitos+=Convert.ToDouble(dr["MSimaIquitos"]);
				Total+=Convert.ToDouble(dr["MTotal"]);

				e.Item.Cells[Utilitario.Constantes.POSICIONINDEXUNO].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE );
				e.Item.Cells[Utilitario.Constantes.POSICIONINDEXDOS].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE );
				e.Item.Cells[Utilitario.Constantes.POSICIONINDEXTRES].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE );
				e.Item.Cells[Utilitario.Constantes.POSICIONINDEXCUATRO].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE );
				e.Item.Cells[Utilitario.Constantes.POSICIONINDEXCINCO].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE );

				e.Item.Cells[1].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.MostrarVentana(URLDETALLE,
					KEYIDCUENTA + Utilitario.Constantes.SIGNOIGUAL + dr["id1"] 
					+ Utilitario.Constantes.SIGNOAMPERSON + KEYQFLAGDIRECTORIO  
					+ Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQFLAGDIRECTORIO]   
					+ Utilitario.Constantes.SIGNOAMPERSON +
					KEYIDSUBCUENTA + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYIDSUBCUENTA] + 
					Utilitario.Constantes.SIGNOAMPERSON +
					KEYIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.SIMACALLAO 
					)+
					Utilitario.Constantes.POPUPDEESPERA);

				e.Item.Cells[2].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.MostrarVentana(URLDETALLE,KEYIDCUENTA + Utilitario.Constantes.SIGNOIGUAL + dr["id1"]
					+ Utilitario.Constantes.SIGNOAMPERSON +
					KEYIDSUBCUENTA + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYIDSUBCUENTA]  
					+ Utilitario.Constantes.SIGNOAMPERSON + KEYQFLAGDIRECTORIO  
					+ Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQFLAGDIRECTORIO] +  
					Utilitario.Constantes.SIGNOAMPERSON +
					KEYIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.SIMACHIMBOTE
					) + 
					Utilitario.Constantes.POPUPDEESPERA);
/*
				e.Item.Cells[3].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.MostrarVentana(URLDETALLE,KEYIDCUENTA + Utilitario.Constantes.SIGNOIGUAL + dr["id1"]
					+ Utilitario.Constantes.SIGNOAMPERSON +
					KEYIDSUBCUENTA + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYIDSUBCUENTA]  
					+ Utilitario.Constantes.SIGNOAMPERSON + KEYQFLAGDIRECTORIO  
					+ Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQFLAGDIRECTORIO]  + 
					Utilitario.Constantes.SIGNOAMPERSON +
					KEYIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.SIMAPERU
					)+
					Utilitario.Constantes.POPUPDEESPERA);*/

				e.Item.Cells[4].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.MostrarVentana(URLDETALLE,KEYIDCUENTA + Utilitario.Constantes.SIGNOIGUAL + dr["id1"]
					+ Utilitario.Constantes.SIGNOAMPERSON +
					KEYIDSUBCUENTA + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYIDSUBCUENTA]  
					+ Utilitario.Constantes.SIGNOAMPERSON + KEYQFLAGDIRECTORIO  
					+ Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQFLAGDIRECTORIO] +
					Utilitario.Constantes.SIGNOAMPERSON +
					KEYIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.SIMAIQUITOS
					)+
					Utilitario.Constantes.POPUPDEESPERA);

				e.Item.Cells[1].Font.Underline = true;
				e.Item.Cells[1].ForeColor= System.Drawing.Color.Blue;
				e.Item.Cells[1].Style.Add("cursor","hand");
				e.Item.Cells[2].Font.Underline = true;
				e.Item.Cells[2].ForeColor= System.Drawing.Color.Blue;
				e.Item.Cells[2].Style.Add("cursor","hand");
				/*e.Item.Cells[3].Font.Underline = true;
				e.Item.Cells[3].ForeColor= System.Drawing.Color.Blue;
				e.Item.Cells[3].Style.Add("cursor","hand");*/
				e.Item.Cells[4].Font.Underline = true;
				e.Item.Cells[4].ForeColor= System.Drawing.Color.Blue;
				e.Item.Cells[4].Style.Add("cursor","hand");


				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
			}
			else if(e.Item.ItemType == ListItemType.Footer)
			{
				e.Item.Cells[1].Text = Callao.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[2].Text = Chimbote.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[3].Text = Peru.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[4].Text = Iquitos.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[5].Text = Total.ToString(Utilitario.Constantes.FORMATODECIMAL4);
			}
		}

	
	}
}
