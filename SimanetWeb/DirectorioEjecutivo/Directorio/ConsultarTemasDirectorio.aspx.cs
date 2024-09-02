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
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using NullableTypes;
using MetaBuilders.WebControls;
using SIMA.Controladoras.Secretaria.Directorio;

namespace SIMA.SimaNetWeb.DirectorioEjecutivo.Directorio
{
	/// <summary>
	/// Summary description for RequerimientosAsignados.
	/// </summary>
	public class ConsultaTemasDirectorio : System.Web.UI.Page,IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminarFiltro;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnSesiones;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion Controles
		

		#region Constantes
		
		//Ordenamiento
		const string COLORDENAMIENTO = "IdTema";

		//Nombres de Controles
		const string CONTROLINK = "hlkId";
		const string CONTROLOBSERVACIONES = "ibtnDialogo";
		const string CONTROLACUERDO = "lblAcuerdo";
		const string CONTROLFECHA= "lblFecha";
		const string CONTROCHECKBOX = "cbxEliminar";
		
		//Paginas
		const string URLSESIONES = "ConsultaSesionDirectorio.aspx";
				
		//Key Session y QueryString
		
		const string KEYQIDSESIONDIRECTORIO = "IdSesionDirectorio";
		const string KEYQID = "Id";

		//JScript
		string JSVERIFICARELIMINAR = "return verificarEliminarRb('hCodigo','" + Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO)+"','"+Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJEPREGUNTAELIMINACIONREGISTRO)+"');";
	
			
		//Otros
		const string GRILLAVACIA ="No existe ningún Tema de Directorio.";  
		const string CONTROLIMGBUTTON = "imgDoc";

		#endregion Constantes

		#region Variables
		#endregion Variables
		
		
		/// <summary>
		/// Limpia los valores ocultos
		/// </summary>
		private void reiniciarCampos()
		{
			//this.hCodigo.Value = "";

		}

	
		private void Page_Load(object sender, System.EventArgs e)
		{
			

			if(!Page.IsPostBack)
			{
				try
				{
					
					this.ConfigurarAccesoControles();
					
					this.LlenarJScript();
					this.AsignarSession();

					Helper.ReiniciarSession();

					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Secretaria - Directorio",this.ToString(),"Se consultó los Pedidos de Sesión de Directorio.",Enumerados.NivelesErrorLog.I.ToString()));
					

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

			this.reiniciarCampos();
		}

		private void AsignarSession()
		{
			if (Page.Request.QueryString[KEYQIDSESIONDIRECTORIO] != null) 
			{
				if (Page.Request.QueryString[KEYQIDSESIONDIRECTORIO].ToString() != HttpContext.Current.Session[Utilitario.Constantes.KEYSIDSESIONDIRECTORIO].ToString())
				{
					Helper.GeneraSessionParaDirectorio(Page.Request.QueryString[KEYQIDSESIONDIRECTORIO].ToString());
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
			this.ibtnEliminarFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminarFiltro_Click);
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
			
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
		{
			CTemasDirectorio oCTemasDirectorio =  new CTemasDirectorio();
			DataTable dtTemasDirectorio =  oCTemasDirectorio.ConsultarTemasPorSituacion(
				Convert.ToInt32(Helper.RetornaSessionParaDirectorio()),
				Utilitario.Constantes.POSICIONINDEXUNO);

			if(dtTemasDirectorio!=null)
			{
				DataView dwTemasDirectorio = dtTemasDirectorio.DefaultView;
				dwTemasDirectorio.Sort = columnaOrdenar ;
				dwTemasDirectorio.RowFilter= Utilitario.Helper.ObtenerFiltro();
				grid.DataSource = dwTemasDirectorio;

				grid.Columns[0].FooterText = Utilitario.Constantes.TEXTOFOOTERTOTAL;
				grid.Columns[Utilitario.Constantes.POSICIONTOTAL].FooterText = dwTemasDirectorio.Count.ToString();

				//CImpresion oCImpresion = new CImpresion();
				//oCImpresion.GuardarDataImprimirExportar(dtTemasDirectorio,"REPORTE DE PEDIDOS",columnaOrdenar,indicePagina);//Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGOTITULOREPORTEACCIONCORRECTIVA),columnaOrdenar,indicePagina);
				lblResultado.Visible = false;
				
			}
			else
			{
				grid.DataSource = dtTemasDirectorio;
				lblResultado.Visible = true;
				lblResultado.Text = GRILLAVACIA;
			}

			try
			{
				grid.DataBind();
			}
			catch(Exception ex)
			{
				Helper.MensajeAlert(ex.ToString());
				grid.CurrentPageIndex = 0;
				grid.DataBind();
			}
		}

		public void LlenarCombos()
		{
			// TODO:  Add ConsultaDeCartasFianzas.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add ConsultaDeCartasFianzas.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			
			
			// TODO:  Add ConsultaDeCartasFianzas.LlenarJScript implementation
			ibtnSesiones.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN, Utilitario.Constantes.HISTORIALADELANTE);
			ibtnSesiones.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.MostrarVentana(URLSESIONES,""));
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
			// TODO:  Add ConsultaDeCartasFianzas.ConfigurarAccesoControles implementation

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
			if(e.Item.ItemType == ListItemType.Header)
			{
				e.Item.Cells[1].ToolTip = Utilitario.Constantes.CENTROOPERATIVO;
			}

			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,
					Utilitario.Helper.MostrarDatosEnCajaTexto("hCodigo",dr[Enumerados.ColumnasTemasDirectorio.IdTema.ToString()].ToString()));

				e.Item.Cells[0].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				Helper.FiltroporSeleccionConfiguraColumna(e,grid);										

				e.Item.Cells[1].ToolTip = dr[Enumerados.ColumnasTemasDirectorio.CentroOperativo.ToString()].ToString();
				/*Label lbl1=(Label)e.Item.Cells[4].FindControl(CONTROLACUERDO);
				lbl1.Text = dr[Enumerados.ColumnasTemasDirectorio.NroAcuerdo.ToString()].ToString();

				Label lbl2=(Label)e.Item.Cells[4].FindControl(CONTROLFECHA);
				lbl2.Text = Convert.ToDateTime(dr[Enumerados.ColumnasTemasDirectorio.FechaAcuerdo.ToString()].ToString()).ToString(Utilitario.Constantes.FORMATOFECHA4);

				ImageButton img=(ImageButton)e.Item.Cells[5].FindControl(CONTROLOBSERVACIONES);
				img.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.MostrarVentaModalTextoHTML("",
					Convert.ToString(dr[Enumerados.ColumnasTemasDirectorio.Observaciones.ToString()]),500,400,0,400));
				*/

				/*HtmlImage oImage = (HtmlImage) e.Item.Cells[e.Item.Cells.Count-1].FindControl("imgFile");
				oImage.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnClick.ToString(),Helper.AbrirArchivo(PathArchivoReferencia));
				oImage.Alt="Archivo de referencia";
				oImage.Style.Add(Utilitario.Constantes.DISPLAY,((dr["ExtFile"].ToString().Length>0)?Utilitario.Constantes.BLOCK:Utilitario.Constantes.NONE));*/

				Image ibtn=(Image)e.Item.Cells[8].FindControl(CONTROLIMGBUTTON);	
				if (Convert.ToString(dr[Enumerados.ColumnasTemasDirectorio.Documento.ToString() ])!= String.Empty)
				{
					ibtn.ImageUrl = "../../imagenes/ley1.gif";

					ibtn.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnClick.ToString(),
						Helper.AbrirArchivo(Helper.ObtenerRutaImagenes(Utilitario.Constantes.RUTASERVERDOCUMENTOSDIRECTORIO) + 
						dr[Enumerados.ColumnasTemasDirectorio.Documento.ToString()]));
					/*ibtn.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.PopupMostrarArchivos(
						Helper.ObtenerRutaImagenes(Utilitario.Constantes.RUTASERVERDOCUMENTOSDIRECTORIO) + 
						dr[Enumerados.ColumnasTemasDirectorio.Documento.ToString()]));*/
				}
				else
				{
					ibtn.ImageUrl = "../../imagenes/ley2.gif";
				}
			}	
			
		}

		/// <summary>
		/// Abre la Pagina para Agregar un Pedido
		/// </summary>
		private void redireccionaPaginaAgregar()
		{
		}

		private void imgAgregar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.redireccionaPaginaAgregar();
		}

		private void imgImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Imprimir();
		}

		
		private void imgExportarExcel_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Exportar();
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

		private void ibtnEliminarFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();																		
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}	
	}
}

