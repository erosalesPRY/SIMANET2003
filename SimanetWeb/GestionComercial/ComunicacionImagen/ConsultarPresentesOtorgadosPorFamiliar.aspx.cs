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
using MetaBuilders.WebControls;


namespace SIMA.SimaNetWeb.GestionComercial.ComunicacionImagen
{
	/// <summary>
	/// Summary description for ConsultarPresentesOtorgadosPorFamiliar.
	/// </summary>
	public class ConsultarPresentesOtorgadosPorFamiliar : System.Web.UI.Page,IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblPosicionRegistro;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblNombrePersona;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminarFiltro;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
		#endregion Controles
		
		#region Constantes
		//Ordenamiento
		const string COLORDENAMIENTO = "IdListaProtocolarFamiliares";

		//Nombres de Controles
		
		//Paginas
		const string URLIMPRESION = "PopupImpresionConsultarPresentesOtorgadosPorFamiliar.aspx?";
		const string URLDETALLE = "DetallePresentesOtorgadosFamiliares.aspx?";
				
		//Key Session y QueryString
		const string KEYQID = "Id";
		const string KEYQNOMBRE = "Nombre";
		const string KEYQIDTABLAORIGEN = "IdTablaOrigen";
		const string KEYQIDORIGEN = "IdOrigen";
		const string KEYQIDCODIGO = "IdCodigo";
		const int PosicionFooterTotal = 2;
		
		//JScript
			
		//Otros
		const string GRILLAVACIA ="El Registro seleccionado no tiene ningún familiar registrado.";
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
					
					this.LlenarDatos();

					Helper.ReiniciarSession();

					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se consultó los Presentes Otorgados a Familiares.",Enumerados.NivelesErrorLog.I.ToString()));

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
			// TODO:  Add ConsultarPresentesOtorgadosPorFamiliar.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarPresentesOtorgadosPorFamiliar.LlenarGrillaOrdenamiento implementation
		}

		public DataTable ObtenerDatos()
		{
			CPresentesOtorgadosPorFamiliar oCPresentesOtorgadosPorFamiliar =  new CPresentesOtorgadosPorFamiliar();
			return oCPresentesOtorgadosPorFamiliar.ConsultarPresentesOtorgadosFamiliaresporPersona(Convert.ToInt32(Page.Request.QueryString[KEYQIDTABLAORIGEN]),Convert.ToInt32(Page.Request.QueryString[KEYQIDORIGEN]),Convert.ToInt32(Page.Request.QueryString[KEYQIDCODIGO]));
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
		{
			DataTable dtPresentesOtorgadosPorFamiliar = this.ObtenerDatos();
			
			if(dtPresentesOtorgadosPorFamiliar!=null)
			{
				DataView dwPresentesOtorgadosPorFamiliar = dtPresentesOtorgadosPorFamiliar.DefaultView;
				dwPresentesOtorgadosPorFamiliar.Sort = columnaOrdenar;
				dwPresentesOtorgadosPorFamiliar.RowFilter = Helper.ObtenerFiltro(this);
				if(dwPresentesOtorgadosPorFamiliar.Count>0)
				{
					grid.DataSource = dwPresentesOtorgadosPorFamiliar;
					grid.Columns[PosicionFooterTotal].FooterText = dwPresentesOtorgadosPorFamiliar.Count.ToString();
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
				grid.DataSource = dtPresentesOtorgadosPorFamiliar;
				lblResultado.Text = GRILLAVACIA;
			}
			
			CImpresion oCImpresion = new CImpresion();
			oCImpresion.GuardarDataImprimirExportar(dtPresentesOtorgadosPorFamiliar,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGOTITULOREPORTEPRESENTESOTORGADOSFAMILIARES),columnaOrdenar,indicePagina);

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
			// TODO:  Add ConsultarPresentesOtorgadosPorFamiliar.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			this.lblNombrePersona.Text = Page.Request.QueryString[KEYQNOMBRE];
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarPresentesOtorgadosPorFamiliar.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarPresentesOtorgadosPorFamiliar.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			ltlMensaje.Text = Helper.PopupImpresion(URLIMPRESION + KEYQNOMBRE + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQNOMBRE] ,750,500,false,false,false,true,true);
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarPresentesOtorgadosPorFamiliar.Exportar implementation
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
			this.Imprimir();
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				e.Item.Cells[Constantes.POSICIONCONTADOR].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);

				e.Item.Cells[Constantes.POSICIONCONTADOR].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.MostrarVentana(URLDETALLE,KEYQID+ Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr[Enumerados.ColumnasPresentesOtorgadosFamiliares.IdListaProtocolarFamiliares.ToString()]) +  Utilitario.Constantes.SIGNOAMPERSON + Utilitario.Constantes.KEYMODOPAGINA +  Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.C.ToString() + Utilitario.Constantes.SIGNOAMPERSON +
					KEYQIDTABLAORIGEN + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt32(Page.Request.QueryString[KEYQIDTABLAORIGEN]).ToString()+  Utilitario.Constantes.SIGNOAMPERSON +
					KEYQIDORIGEN + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt32(Page.Request.QueryString[KEYQIDORIGEN]).ToString()+  Utilitario.Constantes.SIGNOAMPERSON +
					KEYQIDCODIGO + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt32(Page.Request.QueryString[KEYQIDCODIGO]).ToString()));
				e.Item.Cells[Constantes.POSICIONCONTADOR].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				e.Item.Cells[Constantes.POSICIONCONTADOR].Font.Underline=true;
				e.Item.Cells[Constantes.POSICIONCONTADOR].ForeColor = System.Drawing.Color.Blue;

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				Helper.FiltroporSeleccionConfiguraColumna(e,grid);
			}
		}

		private void ibtnFiltrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			ltlMensaje.Text= Utilitario.Helper.ElaborarFiltro(this.ObtenerDatos()
				,Utilitario.Enumerados.ColumnasPresentesOtorgadosFamiliares.ApellidoPaterno.ToString()+";Apellido Paterno"
				,Utilitario.Enumerados.ColumnasPresentesOtorgadosFamiliares.ApellidoMaterno.ToString()+ ";Apellido Materno"
				,Utilitario.Enumerados.ColumnasPresentesOtorgadosFamiliares.Nombres.ToString()+ ";Nombre"
				,Constantes.SIGNOASTERISCO + Utilitario.Enumerados.ColumnasPresentesOtorgadosFamiliares.NombreArticulo.ToString()+ ";Articulo"
				,Utilitario.Enumerados.ColumnasPresentesOtorgadosFamiliares.CantidadAtendida.ToString()+ ";Cantidad Entregada"
				);
		}

		private void ibtnEliminarFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}
	}
}