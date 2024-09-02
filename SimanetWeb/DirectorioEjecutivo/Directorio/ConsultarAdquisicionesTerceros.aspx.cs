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
using SIMA.Controladoras.Secretaria.Directorio;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using NullableTypes;
using MetaBuilders.WebControls;

namespace SIMA.SimaNetWeb.DirectorioEjecutivo.Directorio
{
	/// <summary>
	/// Summary description for AdministracionDeRetenciones.
	/// </summary>
	public class ConsultarAdquisicionesTerceros: System.Web.UI.Page,IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminarFiltro;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label lblObjeto;
		protected System.Web.UI.WebControls.TextBox txtObjeto;
		protected System.Web.UI.WebControls.Label Label11;
		protected projDataGridWeb.DataGridWeb gridResumen;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hOrdenGrilla;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hDescripcion;
		protected System.Web.UI.WebControls.ImageButton ibtnBases;
		#endregion Controles	

		#region Constantes
		
		//Ordenamiento
		const string COLORDENAMIENTO = "FechaOrden";

		//Nombres de Controles
		const string CONTROLINK = "hlkId";
		const string CONTROCHECKBOX = "cbxEliminar";
		
		//Paginas
		const string URLDETALLE = "ConsultarDetalleAdquisicionesTerceros.aspx?";
		//Key Session y QueryString
		const string KEYQDESCRIPCION = "Descripcion";
		const string KEYQID = "Id";

		//JScript
		string JSVERIFICARELIMINAR = "return verificarEliminarRb('hCodigo','" + Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO)+"','"+Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJEPREGUNTAELIMINACIONREGISTRO)+"');";
				
		//Otros
		const string GRILLAVACIA ="No existe ninguna Adquisición.";
		const string TITULOIMPRESION = "REPORTE DE ADQUISICIONES";

		//Bases para Adquisiciones
		const string ARCHIVO = "Adquisiciones Terceros.pdf";

		

		//Numero de Registro
		const string TEXTOFOOTERTOTAL = "Total:";
		protected projDataGridWeb.DataGridWeb gridPeriodo;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;

		const int ULTIMASADQUISICIONES=1;
		#endregion Constantes

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
			this.ibtnBases.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnBases_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.gridResumen.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.gridResumen_PageIndexChanged);
			this.gridResumen.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.gridResumen_ItemDataBound);
			this.gridPeriodo.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.gridPeriodo_PageIndexChanged);
			this.gridPeriodo.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.gridPeriodo_ItemDataBound);
			this.ibtnFiltrar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnFiltrar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// Elimina los Poderes Asignados
		/// </summary>
		private void eliminar()
		{
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			

			if(!Page.IsPostBack)
			{
				try
				{
					
					this.ConfigurarAccesoControles();
					
					this.LlenarJScript();
					//this.VerificarSesionDefault();
					Helper.ReiniciarSession();

					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Adquisiciones",this.ToString(),"Se consultó las Adquisiciones.",Enumerados.NivelesErrorLog.I.ToString()));

					Helper.SeleccionarItemCombos(this);				
					this.LlenarGrillaOrdenamientoPaginacion(this.hOrdenGrilla.Value,Convert.ToInt32(this.hGridPagina.Value));
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
					ltlMensaje.Text =Helper.MensajeAlert(oSIMAExcepcionDominio.Mensaje);
				}
				catch(Exception oException)
				{
					SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Utilitario.Constantes.CODIGOERRORGENERICO,oException.Message);
					Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
				}
			}
			this.reiniciarCampos();	
		}

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add AdministracionDePoderes.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministracionDePoderes.LlenarGrillaOrdenamiento implementation
		}

		public static DateTime ObtenerFechaLogistica(DateTime FechaEvaluar)
		{
			DateTime dFecha= new DateTime(FechaEvaluar.Year, FechaEvaluar.Month, 1);
			return dFecha;
		}

		DataTable ObtenerDatos(){
			DateTime Fecha  = Helper.FechaSimanet.ObtenerFechaSesion();
			if(Page.Request.QueryString["TIPOCONSULTA"]!=null)
			{
				// dtAdquisiciones =  oCAdquisiciones.ConsultaAdquisiciones(0,ObtenerFechaLogistica(Fecha));
				return  (new CAdquisiciones()).ConsultaAdquisiciones(0,Helper.FechaSimanet.ObtenerFechaSesion());
			    
			}
			else
			{
				//dtAdquisiciones =  oCAdquisiciones.ConsultaAdquisiciones(ULTIMASADQUISICIONES,ObtenerFechaLogistica(Fecha));
				return (new CAdquisiciones()).ConsultaAdquisiciones(ULTIMASADQUISICIONES,Helper.FechaSimanet.ObtenerFechaSesion());
			}
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dtAdquisiciones = ObtenerDatos();

			if(dtAdquisiciones!=null)
			{
				DataView dwAdquisiciones = dtAdquisiciones.DefaultView;
				dwAdquisiciones.Sort = columnaOrdenar ;
				dwAdquisiciones.RowFilter = Utilitario.Helper.ObtenerFiltro();
				grid.DataSource = dwAdquisiciones;
				grid.CurrentPageIndex =indicePagina;

				grid.Columns[Utilitario.Constantes.POSICIONFOOTERTOTAL].FooterText = TEXTOFOOTERTOTAL;
				grid.Columns[Utilitario.Constantes.POSICIONTOTAL].FooterText = dwAdquisiciones.Count.ToString();

				
				DataView mDTRes= GenerarResumenPeriodo(dwAdquisiciones);
				this.GenerarResumen(mDTRes);

				//this.GenerarResumenXPeriodo(Helper.ObtenerColumnaOrdenamiento(),Helper.ObtenerIndicePagina());

				CImpresion oCImpresion = new CImpresion();
				oCImpresion.GuardarDataImprimirExportar(dtAdquisiciones,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGOTITULOREPORTEADQUISICIONESTERCEROS),columnaOrdenar,indicePagina);
			}
			else
			{
				grid.DataSource = dtAdquisiciones;
				lblResultado.Text = GRILLAVACIA;

			}
			
			try
			{
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
			// TODO:  Add AdministracionDePoderes.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add AdministracionDePoderes.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			ibtnBases.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnClick.ToString(),
				Helper.AbrirArchivo(Helper.ObtenerRutaImagenes(Utilitario.Constantes.RUTASERVERDOCUMENTOSDIRECTORIO) + 
				ARCHIVO));

			/*ibtnBases.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
				Helper.PopupMostrarArchivos(Helper.ObtenerRutaPDFs(Utilitario.Constantes.RUTADOCUMENTOSDIRECTORIO2) + ARCHIVO));*/
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministracionDePoderes.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			//ltlMensaje.Text = Helper.PopupImpresion(URLIMPRESION,650,700,false,false,false,true,true);
		}

		public void Exportar()
		{
			// TODO:  Add AdministracionDePoderes.Exportar implementation
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

		private void redireccionaPaginaAgregar()
		{
		}

		private void imgImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
		}
		
		private void imgExportarExcel_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Exportar();
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.hOrdenGrilla.Value = Helper.GenerarExpresionOrdenamiento(e.SortExpression);
			this.LlenarGrillaOrdenamientoPaginacion(this.hOrdenGrilla.Value,Helper.ObtenerIndicePagina());
		}


		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.hGridPagina.Value = e.NewPageIndex.ToString();
			this.LlenarGrillaOrdenamientoPaginacion(this.hOrdenGrilla.Value,e.NewPageIndex);		
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,
					Utilitario.Helper.MostrarDatosEnCajaTexto("hCodigo",dr[Enumerados.ColumnasAdquisiciones.IdAdquisicion.ToString()].ToString()),
					Utilitario.Helper.MostrarDatosEnCajaTexto("txtObjeto",dr[Enumerados.ColumnasAdquisiciones.Proyecto.ToString()].ToString()));

				e.Item.Cells[0].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.MostrarVentana(URLDETALLE,Utilitario.Constantes.KEYMODOPAGINA +  
					Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.C.ToString() + 
					Utilitario.Constantes.SIGNOAMPERSON + KEYQID + Utilitario.Constantes.SIGNOIGUAL + 
					Convert.ToString(dr[Enumerados.ColumnasAdquisiciones.IdAdquisicion.ToString()])));

				e.Item.Cells[0].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				e.Item.Cells[0].Font.Underline=true;	
				e.Item.Cells[0].ForeColor= System.Drawing.Color.Blue;
				e.Item.Cells[0].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado("hGridPagina","hOrdenGrilla"));

				e.Item.Cells[6].Text = Convert.ToDouble(dr[Enumerados.ColumnasAdquisiciones.MontoAdquisicion.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4) ;

				Helper.FiltroporSeleccionConfiguraColumna(e,grid);
			}	
		}

		private void reiniciarCampos()
		{
		}

		private void ibtnEliminarFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}

		private void GenerarResumen(DataView dt)
		{
			if (dt!=null)
			{
				int NroResumen1	 = 24;
				CResumenItem oCResumenItem1 = new CResumenItem();
				DataTable dtFinal1= Helper.Resumen(oCResumenItem1.ObtenerConfiDataResumen(NroResumen1),dt);
				gridResumen.DataSource =dtFinal1;
			}
			else
			{
				gridResumen.DataSource =dt;
			}
			gridResumen.DataBind();
		}
		private DataView GenerarResumenPeriodo(DataView dt)
		{
			DataView dtRes;
			if (dt!=null)
			{
				int NroResumen1	 = 35;
				CResumenItem oCResumenItem1 = new CResumenItem();
				dtRes= Helper.Resumen(oCResumenItem1.ObtenerConfiDataResumen(NroResumen1),dt).DefaultView;
				gridPeriodo.DataSource =dtRes;
			}
			else
			{
				gridPeriodo.DataSource =dt;
				dtRes=dt;
			}
			gridPeriodo.DataBind();
			return dtRes;
		}

		private void gridResumen_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				e.Item.Cells[2].Text=Convert.ToDouble(e.Item.Cells[2].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4.ToString());
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);		
				Helper.FiltroporSeleccionConfiguraColumna(e,gridResumen);		
			}
		}

		private void gridResumen_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			gridResumen.CurrentPageIndex=e.NewPageIndex;
			//this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);		
		}
		private void GenerarResumenXPeriodo(string columnaOrdenar, int indicePagina)
		{
			CAdquisiciones oCAdquisiciones= new CAdquisiciones();
			DataTable dt;
			if(Page.Request.QueryString["TIPOCONSULTA"]!=null)
			{
				 dt =  oCAdquisiciones.ResumenXPeriodoMontoAdquisiciones(0,Helper.FechaSimanet.ObtenerFechaSesion());
			}
			else
			{
				dt =  oCAdquisiciones.ResumenXPeriodoMontoAdquisiciones(1,Helper.FechaSimanet.ObtenerFechaSesion());
			}
			if(dt!=null)
			{
				DataView dw = dt.DefaultView;
				dw.Sort = "PERIODO" ;
								
				gridPeriodo.DataSource=dw;
			
				gridPeriodo.CurrentPageIndex =indicePagina;
				gridPeriodo.DataBind();
			}
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void ibtnBases_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
		
		}

		private void gridPeriodo_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			gridPeriodo.CurrentPageIndex=e.NewPageIndex;
			//this.GenerarResumenXPeriodo(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);
		}

		private void gridPeriodo_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				e.Item.Cells[3].Text=Convert.ToDouble(e.Item.Cells[3].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4.ToString());
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);		
				Helper.FiltroporSeleccionConfiguraColumna(e,gridResumen);		
			}
		}

		private void ibtnFiltrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			DataTable dt = this.ObtenerDatos();

			ltlMensaje.Text = Utilitario.Helper.ElaborarFiltro(dt
				,"OBJETOADQUISICION;Objeto de la adquisición"
				,Utilitario.Constantes.SIGNOASTERISCO + "TIPOADQUISICION;Tipo de adquisición"
				,"PROVEEDOR;Proveedor"
				,Utilitario.Constantes.SIGNOASTERISCO + "MONEDA;Moneda"
				,"MONTOADQUISICION;Monto de Adquisición"
				,"PROYECTO;Proyecto"
				,"NROCOMPRA;Nro de Compra"
				,Utilitario.Constantes.SIGNOASTERISCO +"CENTROOPERATIVO;Centro Operativo"
				,Utilitario.Constantes.SIGNOASTERISCO +"TIPOMERCADO;Tipo Mercado"
				);
		}

	}
}
