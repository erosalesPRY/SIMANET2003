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


namespace SIMA.SimaNetWeb.GestionFinanciera.DescuentoLetras
{
	public class ConsultarLetrasporTipoySituacion : System.Web.UI.Page,IPaginaBase
	{
		#region Constantes
		const string CAMPOFECHA1 = "lblFechaInicio";
		const string CAMPOFECHA2 = "lblFechaVence";

		const string CAMPODIAS1 = "lblDiasPlazo";
		const string CAMPODIAS2 = "lblDiasFaltantes";

		const string GRILLAVACIA ="No existe ningún Registro de Letras.";  
		const string KEYIDTIPOLETRA = "TipoLetra";
		const string KEYNOMBRETIPOLETRA = "NombreTipoLetra";

		const string KEYIDSITUACION ="Situacion";
		const string KEYIDSITUACIONDESCRIPCION ="DescSituacion";

		const string KEYIDDOCLET ="idDocLetra";
		const string URLPAGINADETALLE = "DetalleLetras.aspx?";

		const string KEYIDCENTRO = "idCentro";
		const string NOMBRECENTRO = "NombreCO";

		//Filtro
		const string NRODOCUMENTO ="NroDocumento";
		const string CENTROOPERATIVO ="AbreviaturaCentroOperativo";
		const string NOMBREPROYECTO ="NombreProyecto";
		const string ENTIDAD ="RazonSocial";
		const string MONTOLETRA ="Monto";

		#endregion

		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminaFiltro;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnFiltrarSeleccion;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPaginaSort;
		protected System.Web.UI.WebControls.Label lblSituacion;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label lblCentro;
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
			this.ibtnFiltar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnFiltar_Click);
			this.ibtnEliminaFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminaFiltro_Click);
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
			// TODO:  Add ConsultarLetrasporTipoySituacion.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarLetrasporTipoySituacion.LlenarGrillaOrdenamiento implementation
		}
		private DataTable ObtenerDatos()
		{
			return ((CLetras) new CLetras()).AdministrarDetalleLetras(Convert.ToString(Utilitario.Constantes.IDDEFAULT),
																		Convert.ToInt32(Page.Request.Params[KEYIDTIPOLETRA]),
																		Convert.ToInt32(Page.Request.Params[KEYIDSITUACION]),
																		((Page.Request.Params[KEYIDCENTRO]!=null)?Convert.ToInt32(Page.Request.Params[KEYIDCENTRO]):Utilitario.Constantes.ValorConstanteCero),
																		CNetAccessControl.GetIdUser());
		}
		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			this.grid.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(Utilitario.Helper.FooterSpan);
			DataTable dtLetras=this.ObtenerDatos();
			if(dtLetras!=null)
			{
				DataView dwLetras= dtLetras.DefaultView;
				dwLetras.RowFilter = Helper.ObtenerFiltro();
				grid.Columns[Utilitario.Constantes.POSICIONFOOTERTOTAL].FooterText = Utilitario.Constantes.TEXTOFOOTERTOTAL + Utilitario.Constantes.ESPACIO + dwLetras.Count.ToString();
				dwLetras.Sort = columnaOrdenar ;
				grid.DataSource = dwLetras;
				grid.CurrentPageIndex = indicePagina;
				lblResultado.Visible = false;
			}
			else
			{
				grid.DataSource = dtLetras;
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
		}

		public void LlenarCombos()
		{
			// TODO:  Add ConsultarLetrasporTipoySituacion.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			this.lblPagina.Text = Page.Request.Params[KEYNOMBRETIPOLETRA].ToString();
			this.lblSituacion.Text = Page.Request.Params[KEYIDSITUACIONDESCRIPCION].ToString();
			Label5.Visible = (Page.Request.Params[NOMBRECENTRO] !=null);
			lblCentro.Visible = (Page.Request.Params[NOMBRECENTRO] !=null);
			lblCentro.Text = ((Page.Request.Params[NOMBRECENTRO]!=null)?Page.Request.Params[NOMBRECENTRO].ToString().ToUpper():Utilitario.Constantes.VACIO);
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarLetrasporTipoySituacion.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarLetrasporTipoySituacion.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarLetrasporTipoySituacion.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarLetrasporTipoySituacion.Exportar implementation
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
			// TODO:  Add ConsultarLetrasporTipoySituacion.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				Helper.ConfiguraColumnaHyperLink(Utilitario.Enumerados.EventosJavaScript.OnClick,e.Item.Cells[0],grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex,
						Helper.HistorialIrAdelantePersonalizado(this.hGridPagina.ID.ToString(),this.hGridPaginaSort.ID.ToString()),
						Helper.MostrarVentana(URLPAGINADETALLE,KEYIDDOCLET + Utilitario.Constantes.SIGNOIGUAL + dr[Utilitario.Enumerados.FinColumnaLetras.idLetra.ToString()].ToString()
															+ Utilitario.Constantes.SIGNOAMPERSON
															+ KEYIDTIPOLETRA + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDTIPOLETRA].ToString()
															+ Utilitario.Constantes.SIGNOAMPERSON
															+ KEYNOMBRETIPOLETRA + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYNOMBRETIPOLETRA].ToString()
															+ Utilitario.Constantes.SIGNOAMPERSON
															+ Utilitario.Constantes.KEYMODULOCONSULTA + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[Utilitario.Constantes.KEYMODULOCONSULTA].ToString()
															+ Utilitario.Constantes.SIGNOAMPERSON
															+ Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Enumerados.ModoPagina.C.ToString()));

				((Label) e.Item.Cells[5].FindControl(CAMPOFECHA1)).Text = dr[Utilitario.Enumerados.FinColumnaLetras.FechaInicio.ToString()].ToString();
				((Label) e.Item.Cells[5].FindControl(CAMPOFECHA2)).Text = dr[Utilitario.Enumerados.FinColumnaLetras.FechaVencimiento.ToString()].ToString();
				
				((Label) e.Item.Cells[6].FindControl(CAMPODIAS1)).Text = dr[Utilitario.Enumerados.FinColumnaLetras.NroDiasPlazo.ToString()].ToString();
				((Label) e.Item.Cells[6].FindControl(CAMPODIAS2)).Text = dr[Utilitario.Enumerados.FinColumnaLetras.NroDiasFaltantes.ToString()].ToString();

				e.Item.Cells[8].Text = Convert.ToDouble(e.Item.Cells[8].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);

				string strVerDetalle = Helper.MostrarDatosEnCajaTexto("txtDescripcion",dr[Utilitario.Enumerados.FinColumnaLetras.Observacion.ToString()].ToString());
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,strVerDetalle);
				Helper.FiltroporSeleccionConfiguraColumna(e,grid);

			}
		}

		private void ibtnFiltar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			ltlMensaje.Text = Helper.ElaborarFiltro(this.ObtenerDatos(),
													NRODOCUMENTO + ";Nro de Documento",
													Utilitario.Constantes.SIGNOASTERISCO + CENTROOPERATIVO + ";Centro de Operaciones",
													NOMBREPROYECTO + ";Nombre del Proyecto",
													ENTIDAD + ";Entidad (Cliente/Proveedor)",
													MONTOLETRA + ";Monto de la Letra");
		}

		private void ibtnEliminaFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.hGridPagina.Value=e.NewPageIndex.ToString();
			grid.CurrentPageIndex=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);	

		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			hGridPaginaSort.Value=Helper.GenerarExpresionOrdenamiento(e.SortExpression);
			this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Helper.ObtenerIndicePagina());

		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
