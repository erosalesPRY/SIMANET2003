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
using SIMA.Controladoras.GestionComercial;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;


namespace SIMA.SimaNetWeb.GestionComercial.ComunicacionImagen
{
	/// <summary>
	/// Summary description for ConsultarVideos.
	/// </summary>
	public class ConsultarVideos : System.Web.UI.Page,IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblPosicionRegistro;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminarFiltro;  
		#endregion Controles

		#region Constantes
		//Ordenamiento
		const string COLORDENAMIENTO = "IdCodigoVideo";

		//Nombres de Controles
		
		
		//Paginas
		const string URLDETALLE = "DetalleVideos.aspx?";
		const string URLIMPRESION = "PopupImpresionAdministracionArticulosRelacionesPublicas.aspx";
				
		//Key Session y QueryString
		const string KEYQID = "Id";
		const string KEYQDESCRIPCION = "Descripcion";
		const string KEYTIPO = "Tipo";
		const string KEYQIDVIDEO = "IdVideo";

		//JScript
		
		//Otros
		const string GRILLAVACIA ="No existe ningun Video.";
		const string TituloConstante ="CONSULTA DE VIDEOS";
		const int PosicionFooterTotal = 2;

		#endregion Constantes

		#region Variables
		#endregion Variables
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					
					Helper.ReiniciarSession();

					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se consultaron los Videos del Buque o Visita "+Page.Request.QueryString[KEYQID],Enumerados.NivelesErrorLog.I.ToString()));

					this.LlenarDatos();

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
			this.ibtnFiltrar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnFiltrar_Click);
			this.ibtnEliminarFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminarFiltro_Click);
			this.ibtnImprimir.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnImprimir_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add ConsultarVideos.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarVideos.LlenarGrillaOrdenamiento implementation
		}

		public DataTable ObtenerDatos()
		{
			if(Page.Request.QueryString[KEYTIPO] == Enumerados.TipoEntidadConFoto.Buque.ToString())
			{
				CVideo oCVideo = new CVideo();
				return oCVideo.ConsultarVideosPorBuque(Convert.ToInt32(Page.Request.QueryString[KEYQID]));
			}
			else if(Page.Request.QueryString[KEYTIPO] == Enumerados.TipoEntidadConFoto.Visita.ToString())
			{
				CVideo oCVideo = new CVideo();
				return oCVideo.ConsultarVideosPorVisitas(Convert.ToInt32(Page.Request.QueryString[KEYQID]));
			}
			return null;
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
		{
			DataTable dtVideos = this.ObtenerDatos();

			if(dtVideos!=null)
			{
				DataView dwVideos = dtVideos.DefaultView;
				dwVideos.Sort = columnaOrdenar ;
				dwVideos.RowFilter = Helper.ObtenerFiltro(this);

				if(dwVideos.Count>0)
				{
					grid.DataSource = dwVideos;
					grid.Columns[PosicionFooterTotal].FooterText = dwVideos.Count.ToString();
					this.lblResultado.Visible = false;
				}
				else
				{
					grid.DataSource = null;
					lblResultado.Visible = true;
					lblResultado.Text = GRILLAVACIA;
				}
				CImpresion oCImpresion = new CImpresion();
				oCImpresion.GuardarDataImprimirExportar(dwVideos.Table,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGOTITULOREPORTEPRESENTES),columnaOrdenar,indicePagina);
			}
			else
			{
				grid.DataSource = dtVideos;
				this.lblResultado.Visible = true;
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
			// TODO:  Add ConsultarVideos.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			if(Page.Request.QueryString[KEYTIPO] == Enumerados.TipoEntidadConFoto.Buque.ToString())
			{
				this.lblTitulo.Text = TituloConstante+Constantes.ESPACIO+Constantes.LINEA+Constantes.ESPACIO+Enumerados.TipoEntidadConFoto.Buque.ToString().ToUpper()+Constantes.ESPACIO+Constantes.LINEA+Constantes.ESPACIO+Page.Request.QueryString[KEYQDESCRIPCION];
			}
			else if(Page.Request.QueryString[KEYTIPO] == Enumerados.TipoEntidadConFoto.Visita.ToString())
			{
				this.lblTitulo.Text = TituloConstante+Constantes.ESPACIO+Constantes.LINEA+Constantes.ESPACIO+Enumerados.TipoEntidadConFoto.Visita.ToString().ToUpper()+Constantes.ESPACIO+Constantes.LINEA+Constantes.ESPACIO+Page.Request.QueryString[KEYQDESCRIPCION];
			}
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarVideos.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarVideos.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			ltlMensaje.Text = Helper.PopupImpresion(URLIMPRESION,750,500,false,false,false,true,true);
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarVideos.Exportar implementation
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

				e.Item.Cells[Constantes.POSICIONCONTADOR].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);

				e.Item.Cells[Constantes.POSICIONCONTADOR].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.MostrarVentana(URLDETALLE,
					KEYQID + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQID] +  Utilitario.Constantes.SIGNOAMPERSON +
					Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.C.ToString() +  Utilitario.Constantes.SIGNOAMPERSON +
					KEYQDESCRIPCION + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQDESCRIPCION] +  Utilitario.Constantes.SIGNOAMPERSON +
					KEYTIPO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYTIPO] +  Utilitario.Constantes.SIGNOAMPERSON +
					KEYQIDVIDEO + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr[Enumerados.ColumnasVideo.IdCodigoVideo.ToString()])
					));
	
				e.Item.Cells[Constantes.POSICIONCONTADOR].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				e.Item.Cells[Constantes.POSICIONCONTADOR].Font.Underline=true;
				e.Item.Cells[Constantes.POSICIONCONTADOR].ForeColor = System.Drawing.Color.Blue;

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,Utilitario.Helper.MostrarDatosEnCajaTexto("hCodigo",dr[Enumerados.ColumnasVideo.IdCodigoVideo.ToString()].ToString()));
				Helper.FiltroporSeleccionConfiguraColumna(e,grid);
			}
		}

		private void imgExportarExcel_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			//this.Exportar();
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

		private void ibtnImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			//this.Imprimir();
		}

		private void ibtnFiltrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			ltlMensaje.Text= Utilitario.Helper.ElaborarFiltro(this.ObtenerDatos()
				,Utilitario.Enumerados.ColumnasVideo.CodigoVideo.ToString()+";Codigo de Video"
				,Utilitario.Enumerados.ColumnasVideo.RutaFisica.ToString()+ ";Ruta Fisica"
				,Constantes.SIGNOASTERISCO + Utilitario.Enumerados.ColumnasVideo.IdFormato.ToString()+ ";Formato"
				);
		}

		private void ibtnEliminarFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}
	}
}