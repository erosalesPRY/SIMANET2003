using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
//using System.Drawing;
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
	/// Summary description for ConsultaPoliticasGenerales.
	/// </summary>
	public class ConsultaPoliticasGenerales : System.Web.UI.Page, IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminarFiltro;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Image Image2;
		protected System.Web.UI.WebControls.Image Image1;
		protected System.Web.UI.WebControls.Label Label1;
		#endregion Controles

		#region Constantes
		
		//Ordenamiento
		const string COLORDENAMIENTO = "POLITICAGESTION";

		//Nombres de Controles
		const string CONTROLINK = "hlkTitulo";
		const string CONTROCHECKBOX = "cbxEliminar";
		const string CONTROLIMGBUTTON = "ibtnLey";

		
		//Paginas
				
		//Key Session y QueryString
		const string KEYQID = "Id";
		const string KEYQIDAREA = "IdArea";

		//JScript
		string JSVERIFICARELIMINAR = "return verificarEliminarRb('hCodigo','" + Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO)+"','"+Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJEPREGUNTAELIMINACIONREGISTRO)+"');";

				
		//Otros                                     
		const string RUTACARPETAPOLITACASGENERALES= "01PROCESOESTRATEGICO/06POLITICAS/";
		const string GRILLAVACIA ="No existe ninguna Directiva.";  
		const int INDICECOLCORRELATIVO=1;
		const string IMGLEY1 = "../../imagenes/ley1.gif";
		const string IMGLEY2 = "../../imagenes/ley2.gif";

		//Numero de Registro
		const string TEXTOFOOTERTOTAL = "Total:";
		const int POSICIONFOOTERTOTAL = 1;
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
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add ConsultaPoliticasGenerales.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultaPoliticasGenerales.LlenarGrillaOrdenamiento implementation
		}

		public DataTable ObtenerDatos()
		{
			CPlanGestion oCPlanGestion =  new CPlanGestion();
			return oCPlanGestion.ListarPoliticasGenerales();
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dtPoliticasGenerales =  this.ObtenerDatos();
			
			if(dtPoliticasGenerales!=null)
			{
				DataView dwPoliticasGenerales = dtPoliticasGenerales.DefaultView;
				dwPoliticasGenerales.Sort = columnaOrdenar ;
				dwPoliticasGenerales.RowFilter = Utilitario.Helper.ObtenerFiltro();

				grid.DataSource = dwPoliticasGenerales;
				grid.Columns[0].FooterText = TEXTOFOOTERTOTAL;
				grid.Columns[POSICIONFOOTERTOTAL].FooterText = dwPoliticasGenerales.Count.ToString();

				CImpresion oCImpresion = new CImpresion();
				oCImpresion.GuardarDataImprimirExportar(dtPoliticasGenerales,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGOTITULOREPORTEDECRETOS),columnaOrdenar,indicePagina);
			}
			else
			{
				grid.DataSource = dtPoliticasGenerales;
				lblResultado.Text = GRILLAVACIA;

			}
			
			try
			{
				if(indicePagina==0)
				{
					REGISTROACTUAL=0;
				}
				else
				{
					REGISTROACTUAL=(indicePagina * grid.PageSize);
				}

				grid.DataBind();
			}

			catch (Exception a)
			{
				string b = a.Message.ToString();
				grid.CurrentPageIndex = 0;
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


		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				e.Item.Cells[0].Text = Convert.ToString(REGISTROACTUAL+=1);
				
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				
				Image ibtn=(Image) e.Item.Cells[4].FindControl(CONTROLIMGBUTTON);	
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

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			grid.CurrentPageIndex=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(e.SortExpression),Helper.ObtenerIndicePagina());
		}

		private void ibtnFiltrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			ltlMensaje.Text =Utilitario.Helper.ElaborarFiltro(this.ObtenerDatos()
				,"*" + Utilitario.Enumerados.ColumnasPoliticasGenerales.PromotorPoliticas.ToString()+ ";Promotor"
				,Utilitario.Enumerados.ColumnasPoliticasGenerales.PoliticaGestion.ToString()+ ";Politica Gestion"
				,Utilitario.Enumerados.ColumnasPoliticasGenerales.FechaPoliticaGeneral.ToString()+";Fecha");
		}

		private void ibtnEliminarFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}
	}
}
