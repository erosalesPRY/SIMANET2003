using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using SIMA.SimaNetWeb.InterfacesIU;
using SIMA.Controladoras.General;
using SIMA.Controladoras.GestionEstrategica;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using NullableTypes;
using MetaBuilders.WebControls;

namespace SIMA.SimaNetWeb.DirectorioEjecutivo.Gestion_Estrategica
{
	/// <summary>
	/// Summary description for ConsultaDiagnosticoSituacional.
	/// </summary>
	public class ConsultaDiagnosticoSituacional : System.Web.UI.Page, IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminarFiltro;	
		protected System.Web.UI.WebControls.Image Image1;
		protected System.Web.UI.WebControls.Image Image2;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		#endregion Controles

		#region Constantes
		const string RUTAPROCESOESTRATEGICO="01PROCESOESTRATEGICO/02DIAGNOSTICO/";
		//Ordenamiento
		const string COLORDENAMIENTO = "IDDIAGNOSTICOSITUACIONAL";
		const int COLUMNANUMERACION = 0;
		const string CONTROLIMGBUTTON = "imgAnexo";

		//URLS
		const string URLACERCAOBJETIVOGENERAL = "ConsultaAcercaObjetivoGeneral.aspx?";

		//INDICES
		const string KEYQIDDIAGNOSTICO = "IDDIAGNOSTICOSITUACIONAL";


		//OTROS
		const string TEXTOFOOTERTOTAL = "Total:";
		const int POSICIONFOOTERTOTAL = 1;
		
		//IMPRESION
		const string URLIMPRESION = "PopupImpresionDiagnosticoSituacional.aspx";


		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();

					Helper.ReiniciarSession();

					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionEstrategica",this.ToString(),"Se consulto el Modulo Gestion Estrategico.",Enumerados.NivelesErrorLog.I.ToString()));

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


		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(e.SortExpression),Helper.ObtenerIndicePagina());
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			grid.CurrentPageIndex=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				Image img=(Image) e.Item.Cells[3].FindControl(CONTROLIMGBUTTON);	
				if (Convert.ToString(dr[Utilitario.Enumerados.ColumnasDiagnosticoSituacional.ANEXO.ToString() ])!= String.Empty)
				{
					img.ImageUrl = "../../imagenes/ley1.gif";
					img.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.PopupMostrarArchivos(Helper.ObtenerRutaPDFs(Utilitario.Constantes.RUTAPDFS) + RUTAPROCESOESTRATEGICO +Convert.ToString(dr[Enumerados.ColumnasDiagnosticoSituacional.ANEXO.ToString()])));
				}
				else
				{
					img.ImageUrl = "../../imagenes/ley2.gif";
				}

				e.Item.Cells[0].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				Helper.FiltroporSeleccionConfiguraColumna(e,grid);
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

		private void ibtnFiltrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			ltlMensaje.Text= Utilitario.Helper.ElaborarFiltro(this.ObtenerDatos()
				,"*" + Utilitario.Enumerados.ColumnasDiagnosticoSituacional.PARAMETRO.ToString()+ ";Parametro"
				,"*" + Utilitario.Enumerados.ColumnasDiagnosticoSituacional.ANALISIS.ToString()+ ";Analisis");
		}

		private void ibtnImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Imprimir();
		}

		private void ibtnEliminarFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}


		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add ConsultaDiagnosticoSituacional.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultaDiagnosticoSituacional.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add ConsultaDiagnosticoSituacional.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add ConsultaDiagnosticoSituacional.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultaDiagnosticoSituacional.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultaDiagnosticoSituacional.RegistrarJScript implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultaDiagnosticoSituacional.Exportar implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ConsultaDiagnosticoSituacional.ValidarFiltros implementation
			return false;
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

		public void Imprimir()
		{			
			ltlMensaje.Text = Helper.PopupImpresion(URLIMPRESION,650,780,false,false,false,true,true);
		}

		public DataTable ObtenerDatos()
		{
			CDiagnosticoSituacional oCDiagnosticoSituacional =  new CDiagnosticoSituacional();
			return oCDiagnosticoSituacional.ListarDiagnosticoSituacional();
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
		{
			DataTable dtDiagnostico =  this.ObtenerDatos();
			
			if(dtDiagnostico!=null)
			{
				DataView dwDiagnostico = dtDiagnostico.DefaultView;
				grid.DataSource = dwDiagnostico;
				dwDiagnostico.RowFilter = Helper.ObtenerFiltro(this);

				if (dwDiagnostico.Count == 0)
				{
					grid.DataSource = null; 
				}
				else
				{
					grid.DataSource = dwDiagnostico;
					grid.Columns[0].FooterText = TEXTOFOOTERTOTAL;
					grid.Columns[POSICIONFOOTERTOTAL].FooterText = dwDiagnostico.Count.ToString();
				}
				CImpresion oCImpresion = new CImpresion();
				oCImpresion.GuardarDataImprimirExportar(dwDiagnostico.Table,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGOTITULOREPORTEDIAGNOSTICOSITUACIONAL),columnaOrdenar,indicePagina);
			}
			else
			{
				grid.DataSource = dtDiagnostico;
			}

			try
			{
				grid.DataBind();
			}
			catch(Exception ex)
			{
				string a = ex.Message;
				grid.CurrentPageIndex = 0;
				grid.DataBind();
			}
			
		}

		#endregion
	}
}
