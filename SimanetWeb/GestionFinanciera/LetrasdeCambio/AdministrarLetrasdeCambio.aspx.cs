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
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using NullableTypes;
using MetaBuilders.WebControls;


namespace SIMA.SimaNetWeb.GestionFinanciera.LetrasdeCambio
{
	/// <summary>
	/// Summary description for AdministrarLetrasdeCambio.
	/// </summary>
	public class AdministrarLetrasdeCambio : System.Web.UI.Page,IPaginaBase
	{
		#region Constantes
		const string CAMPOFECHA1 = "lblFechaInicio";
		const string CAMPOFECHA2 = "lblFechaVence";
		const string CAMPODIAS1 = "lblDiasPlazo";
		const string CAMPODIAS2 = "lblDiasFaltantes";
		const string GRILLAVACIA ="No existe ningún Registro de Letras.";  
		const string KEYIDTIPOLETRA = "TipoLetra";
		const string KEYNOMBRETIPOLETRA = "NombreTipoLetra";
		const string KEYIDDOCLET ="idDocLetra";
		const string URLPAGINADETALLE = "DetalleLetradeCambio.aspx?";
		const string KEYIDMODOLETRA ="MODOLETRA";
		const string KEYIDLETRARENOVADA ="idLetraRenovada";

		//Filtro
		const string NRODOCUMENTO ="NroDocumento";
		const string CENTROOPERACIONES ="AbreviaturaCentroOperativo";
		const string NOMBREDELPROYECTO = "NombreProyecto";
		const string ENTIDAD ="RazonSocial";
		const string MONTOLETRA ="Monto";

		//Otros
		const string VARIABLESESSION ="finLETRA";
			
		#endregion

		#region Controles
			protected System.Web.UI.WebControls.Label lblRutaPagina;
			protected System.Web.UI.WebControls.Label lblPagina;
			protected System.Web.UI.WebControls.Label Label1;
			protected System.Web.UI.WebControls.DropDownList ddlbSituacion;
			protected System.Web.UI.WebControls.ImageButton ibtnFiltar;
			protected System.Web.UI.WebControls.ImageButton ibtnEliminaFiltro;
			protected System.Web.UI.WebControls.Label Label5;
			protected System.Web.UI.WebControls.ImageButton ibtnAgregar;
			protected projDataGridWeb.DataGridWeb grid;
			protected System.Web.UI.WebControls.Label lblResultado;
			protected projDataGridWeb.DataGridWeb gridResumen;
			protected System.Web.UI.HtmlControls.HtmlImage ibtnFiltrarSeleccion;
			protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPaginaSort;
			protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
			protected System.Web.UI.HtmlControls.HtmlInputHidden hidLetra;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hMntLetra;
		protected System.Web.UI.HtmlControls.HtmlInputHidden Hidden1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidLetraRenovada;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdMoneda;
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
					this.LlenarDatos();
					this.LlenarCombos();
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionFinanciera",this.ToString(),"Se consultó Carta de Crédito.",Enumerados.NivelesErrorLog.I.ToString()));
					Helper.ReestablecerPagina(this);
					this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value ,Convert.ToInt32(hGridPagina.Value));
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
			this.ddlbSituacion.SelectedIndexChanged += new System.EventHandler(this.ddlbSituacion_SelectedIndexChanged);
			this.ibtnAgregar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAgregar_Click);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add AdministrarLetrasdeCambio.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarLetrasdeCambio.LlenarGrillaOrdenamiento implementation
		}
		private DataTable ObtenerDatos()
		{
			return ((CLetrasdeCambio) new CLetrasdeCambio()).AdministrarLetrasdeCambio(Convert.ToString(Utilitario.Constantes.IDDEFAULT),
																						Convert.ToInt32(Page.Request.Params[KEYIDTIPOLETRA]),
																						Convert.ToInt32(this.ddlbSituacion.SelectedValue),
																						Utilitario.Constantes.IDDEFAULT,
																						CNetAccessControl.GetIdUser());
		}

		private void GenerarResumen(DataView dv)
		{
			if (dv!=null)
			{
				int NroResumen = 31;
				CResumenItem oCResumenItem = new CResumenItem();
				DataTable dtFinal= Helper.Resumen(oCResumenItem.ObtenerConfiDataResumen(NroResumen),dv);
				gridResumen.DataSource =dtFinal;
				
			}
			else
			{
				gridResumen.DataSource =dv;
			}
			gridResumen.DataBind();
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			this.grid.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(Utilitario.Helper.FooterSpan);
			DataTable dt =this.ObtenerDatos();
			if(dt!=null)
			{
				DataView dw= dt.DefaultView;
				dw.RowFilter = Helper.ObtenerFiltro();
				grid.Columns[Utilitario.Constantes.POSICIONFOOTERTOTAL].FooterText = Utilitario.Constantes.TEXTOFOOTERTOTAL + Utilitario.Constantes.ESPACIO + dw.Count.ToString();
				dw.Sort = columnaOrdenar;
				//this.GenerarResumen(dw);
				grid.DataSource = dw;
				grid.CurrentPageIndex = indicePagina;
				lblResultado.Visible = false;
			}
			else
			{
				grid.DataSource = dt;
				lblResultado.Visible = true;
				lblResultado.Text = GRILLAVACIA;
				//ibtnImprimir.Visible = false;
			}
			try
			{
				grid.DataBind();
			}
			catch(Exception ex)
			{
				string msg = ex.Message.ToString();
				grid.CurrentPageIndex = 0;
				grid.DataBind();
			}
		}

		public void LlenarCombos()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			this.ddlbSituacion.DataSource= oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Enumerados.TablasTabla.FinancieraEstadoDescuentodeLetras));
			ddlbSituacion.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbSituacion.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbSituacion.DataBind();
			if (Session[VARIABLESESSION] !=null)
			{
				this.ddlbSituacion.SelectedIndex=Convert.ToInt32(Session[VARIABLESESSION]);
			}
			else
			{
				this.ddlbSituacion.SelectedIndex =2;
			}
		}

		public void LlenarDatos()
		{
			// TODO:  Add AdministrarLetrasdeCambio.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add AdministrarLetrasdeCambio.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarLetrasdeCambio.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministrarLetrasdeCambio.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarLetrasdeCambio.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add AdministrarLetrasdeCambio.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add AdministrarLetrasdeCambio.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRow dr  = ((DataRow)((DataRowView)e.Item.DataItem).Row);
				Helper.ConfiguraColumnaHyperLink(Utilitario.Enumerados.EventosJavaScript.OnClick,e.Item.Cells[0],grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex,
					Helper.HistorialIrAdelantePersonalizado("hGridPaginaSort","hGridPagina"),
					Helper.MostrarVentana(URLPAGINADETALLE,
					KEYIDDOCLET + Utilitario.Constantes.SIGNOIGUAL + dr[Utilitario.Enumerados.FinColumnaLetras.idLetra.ToString()].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYIDLETRARENOVADA + Utilitario.Constantes.SIGNOIGUAL + dr[Utilitario.Enumerados.FinColumnaLetras.idLetraRenovada.ToString()].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYIDTIPOLETRA + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDTIPOLETRA].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYNOMBRETIPOLETRA + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYNOMBRETIPOLETRA].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					//+ Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + ((Convert.ToInt32(this.ddlbSituacion.SelectedValue)==3)?Utilitario.Enumerados.ModoPagina.C.ToString():Utilitario.Enumerados.ModoPagina.M.ToString())
					+ Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Enumerados.ModoPagina.M.ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ Utilitario.Constantes.KEYMODULOCONSULTA + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Enumerados.ModuloConsulta.Si.ToString()
					));
				
				

				((Label) e.Item.Cells[4].FindControl(CAMPOFECHA1)).Text = dr[Utilitario.Enumerados.FinColumnaLetras.FechaInicio.ToString()].ToString();
				((Label) e.Item.Cells[4].FindControl(CAMPOFECHA2)).Text = dr[Utilitario.Enumerados.FinColumnaLetras.FechaVencimiento.ToString()].ToString();
				
				((Label) e.Item.Cells[5].FindControl(CAMPODIAS1)).Text = dr[Utilitario.Enumerados.FinColumnaLetras.NroDiasPlazo.ToString()].ToString();
				((Label) e.Item.Cells[5].FindControl(CAMPODIAS2)).Text = dr[Utilitario.Enumerados.FinColumnaLetras.NroDiasFaltantes.ToString()].ToString();
				if (Convert.ToInt32(dr[Utilitario.Enumerados.FinColumnaLetras.NroDiasFaltantes.ToString()])<=5)
				{
					((Label) e.Item.Cells[5].FindControl(CAMPODIAS2)).ForeColor = Color.Red;
				}
				e.Item.Cells[7].Text = Convert.ToDouble(dr[Utilitario.Enumerados.FinColumnaLetras.Monto.ToString()].ToString()).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[8].Text = Convert.ToDouble(dr[Utilitario.Enumerados.FinColumnaLetras.MontoCancelado.ToString()].ToString()).ToString(Utilitario.Constantes.FORMATODECIMAL4);

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,Helper.MostrarDatosEnCajaTexto("hidLetra",dr[Utilitario.Enumerados.FinColumnaLetras.idLetra.ToString()].ToString())
																,Helper.MostrarDatosEnCajaTexto("hidLetraRenovada",dr[Utilitario.Enumerados.FinColumnaLetras.idLetraRenovada.ToString()].ToString())
																,Helper.MostrarDatosEnCajaTexto("hMntLetra",dr[Utilitario.Enumerados.FinColumnaLetras.Monto.ToString()].ToString())
																,Helper.MostrarDatosEnCajaTexto("hIdMoneda",dr[Utilitario.Enumerados.FinColumnaLetras.idMoneda.ToString()].ToString()));
				
				Helper.FiltroporSeleccionConfiguraColumna(e,grid,true,"txtBuscar");
			}
		
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void ddlbSituacion_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Session[VARIABLESESSION] = this.ddlbSituacion.SelectedIndex;
			this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value ,Convert.ToInt32(hGridPagina.Value));
		}
		private void RedireccionarPagina()
		{
			Page.Response.Redirect(URLPAGINADETALLE + KEYIDTIPOLETRA + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDTIPOLETRA].ToString()
				+ Utilitario.Constantes.SIGNOAMPERSON
				+ KEYNOMBRETIPOLETRA + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYNOMBRETIPOLETRA].ToString()
				+ Utilitario.Constantes.SIGNOAMPERSON
				+ Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Enumerados.ModoPagina.N.ToString());
		}
		private void ibtnAgregar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.RedireccionarPagina();
		}
	}
}
