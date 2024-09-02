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

namespace SIMA.SimaNetWeb.DirectorioEjecutivo.GestionEstrategica
{
	public class ConsultaLineamientoGeneral : System.Web.UI.Page, IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminarFiltro;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;
		protected System.Web.UI.WebControls.Image Image1;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Image Image2;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		#endregion

		#region Constantes
		
		//Ordenamiento
		const string COLORDENAMIENTO = "NOMBRE";

		//Nombres de Controles
		const string CONTROLINK = "hlkTitulo";
		const string CONTROCHECKBOX = "cbxEliminar";
		const string CONTROLIMGBUTTON = "ibtnLey";

		
		//Paginas
		const string URLPRINCIPAL = "..\\Default.aspx";
				
		//Key Session y QueryString
		const string KEYQID = "Id";
		const string KEYQIDAREA = "IdArea";

		//JScript
		string JSVERIFICARELIMINAR = "return verificarEliminarRb('hCodigo','" + Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO)+"','"+Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJEPREGUNTAELIMINACIONREGISTRO)+"');";

				
		//Otros
		const string RUTACARPETAPOLITACASGENERALES= "01PROCESOESTRATEGICO/07ALINEAMIENTO/";
		const string GRILLAVACIA ="No existe ninguna Directiva.";  
		const int INDICECOLCORRELATIVO=1;
		const string IMGLEY1 = "../../imagenes/ley1.gif";
		const string IMGLEY2 = "../../imagenes/ley2.gif";

		//Numero de Registro
		const string TEXTOFOOTERTOTAL = "Total:";
		const int POSICIONFOOTERTOTAL = 1;
		protected projDataGridWeb.DataGridWeb grid;
		const int POSICIONINICIALCOMBO = 0;

		#endregion Constantes

		#region Variables
		int REGISTROACTUAL;
		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Legal",this.ToString(),"Se consultó las Directivas y Normas.",Enumerados.NivelesErrorLog.I.ToString()));
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


		#region IPaginaBase Members

		public void LlenarGrilla()
		{
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
		}

		public DataTable ObtenerDatos()
		{
			CLineamientoGeneral oCLineamientoGeneral = new CLineamientoGeneral(); 
			return oCLineamientoGeneral.ListarTodosLineamiento();
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dtInvetario =  this.ObtenerDatos();
			
			if(dtInvetario!=null)
			{
				DataView dwInventarios = dtInvetario.DefaultView;
				dwInventarios.Sort = columnaOrdenar ;
				dwInventarios.RowFilter = Helper.ObtenerFiltro(this);
				if(dwInventarios.Count>0)
				{
					grid.DataSource = dwInventarios;
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
				grid.DataSource = dtInvetario;
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
			// TODO:  Add ConsultaPoliticasGenerales.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add ConsultaPoliticasGenerales.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultaPoliticasGenerales.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultaPoliticasGenerales.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultaPoliticasGenerales.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultaPoliticasGenerales.Exportar implementation
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
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			grid.CurrentPageIndex=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				e.Item.Cells[0].Text = Convert.ToString(REGISTROACTUAL+=1);
				
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				
				Image ibtn=(Image) e.Item.Cells[3].FindControl(CONTROLIMGBUTTON);	
				if ( Convert.ToString(dr[Utilitario.Enumerados.ColumnasPoliticasGenerales.Archivo.ToString() ])!= String.Empty)
				{
					ibtn.ImageUrl = IMGLEY1;
					ibtn.Attributes.Add(Utilitario.Constantes.EVENTOCLICK.ToString(),Helper.PopupMostrarArchivos(Helper.ObtenerRutaPDFs(Utilitario.Constantes.RUTAPDFS) + RUTACARPETAPOLITACASGENERALES + Convert.ToString(dr[Enumerados.ColumnasPoliticasGenerales.Archivo.ToString()])));
				}
				else
				{
					ibtn.ImageUrl = IMGLEY2;
				}
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				Helper.FiltroporSeleccionConfiguraColumna(e,grid);
			}	
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
		
		}
	}
}
