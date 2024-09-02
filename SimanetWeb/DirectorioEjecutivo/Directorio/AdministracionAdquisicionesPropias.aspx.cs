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
	/// Summary description for ConsultarAdquisicionesPropias.
	/// </summary>
	public class AdministracionAdquisicionesPropias : System.Web.UI.Page, IPaginaBase
	{
		#region Constantes
		
		//Ordenamiento
		const string COLORDENAMIENTO = "FechaAdquisicionPropia";

		//Nombres de Controles
		const string CONTROLINK = "hlkId";
		const string CONTROCHECKBOX = "cbxEliminar";
		
		//Paginas
		const string URLDETALLE = "DetalleAdquisicionesPropias.aspx?";
		//Key Session y QueryString
		const string KEYQDESCRIPCION = "Descripcion";
		const string KEYQID = "Id";

		//JScript
		string JSVERIFICARELIMINAR = "return verificarEliminarRb('hCodigo','" + Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO)+"','"+Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJEPREGUNTAELIMINACIONREGISTRO)+"');";
				
		//Otros
		const string GRILLAVACIA = "No hay Datos";

		//Numero de Registro
		const string TEXTOFOOTERTOTAL = "Total:";

		const int TODOS = 0;
		#endregion Constantes

		#region Controles
		protected System.Web.UI.WebControls.TextBox txtObjeto;
		protected System.Web.UI.WebControls.Label lblObjeto;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hOrdenGrilla;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hDescripcion;
		protected System.Web.UI.WebControls.ImageButton ibtnAgregar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminar;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminarFiltro;
		protected System.Web.UI.WebControls.Literal ltlMensaje;

		#endregion Controles
	
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
			this.ibtnAgregar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAgregar_Click);
			this.ibtnEliminar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminar_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add ConsultarAdquisicionesPropias.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarAdquisicionesPropias.LlenarGrillaOrdenamiento implementation
		}

		public static DateTime ObtenerFechaLogistica(DateTime FechaEvaluar)
		{
			DateTime dFecha= new DateTime(FechaEvaluar.Year, FechaEvaluar.Month, 1);
			return dFecha;
		}

		public DataTable ObtenerDatos(){
			CAdquisiciones oCAdquisiciones= new CAdquisiciones();

			DateTime Fecha  = Helper.FechaSimanet.ObtenerFechaSesion();

			DataTable dtAdquisiciones =  oCAdquisiciones.ConsultaAdquisicionesPropias(TODOS,ObtenerFechaLogistica(Fecha));
			return dtAdquisiciones;
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			/*CAdquisiciones oCAdquisiciones= new CAdquisiciones();

			DateTime Fecha  = Helper.FechaSimanet.ObtenerFechaSesion();

			DataTable dtAdquisiciones =  oCAdquisiciones.ConsultaAdquisicionesPropias(TODOS,ObtenerFechaLogistica(Fecha));
			*/

			DataTable dtAdquisiciones= this.ObtenerDatos();

			if(dtAdquisiciones!=null)
			{
				DataView dwAdquisiciones = dtAdquisiciones.DefaultView;
				dwAdquisiciones.RowFilter = Utilitario.Helper.ObtenerFiltro();
				dwAdquisiciones.Sort = columnaOrdenar ;
				grid.DataSource = dwAdquisiciones;
				grid.CurrentPageIndex =indicePagina;

				grid.Columns[Utilitario.Constantes.POSICIONFOOTERTOTAL].FooterText = TEXTOFOOTERTOTAL;
				grid.Columns[Utilitario.Constantes.POSICIONTOTAL].FooterText = dwAdquisiciones.Count.ToString();

				CImpresion oCImpresion = new CImpresion();
				oCImpresion.GuardarDataImprimirExportar(dtAdquisiciones,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGOTITULOREPORTEADQUISICIONES),columnaOrdenar,indicePagina);
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
			// TODO:  Add ConsultarAdquisicionesPropias.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add ConsultarAdquisicionesPropias.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			ibtnEliminar.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,JSVERIFICARELIMINAR);
			ibtnAgregar.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado("hGridPagina","hOrdenGrilla"));			
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarAdquisicionesPropias.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarAdquisicionesPropias.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarAdquisicionesPropias.Exportar implementation
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
			// TODO:  Add ConsultarAdquisicionesPropias.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void ibtnEliminar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				if(Page.IsValid)
				{
					this.eliminar();
				}
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
					Utilitario.Helper.MostrarDatosEnCajaTexto("hCodigo",dr[Enumerados.ColumnasAdquisicionesPropias.IdAdquisicionPropia.ToString()].ToString()),
					Utilitario.Helper.MostrarDatosEnCajaTexto("txtObjeto",dr[Enumerados.ColumnasAdquisicionesPropias.ProyectoAdquisicionPropia.ToString()].ToString()));
				
				e.Item.Cells[0].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.MostrarVentana(URLDETALLE,Utilitario.Constantes.KEYMODOPAGINA +  
					Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.M.ToString() + 
					Utilitario.Constantes.SIGNOAMPERSON + KEYQID + Utilitario.Constantes.SIGNOIGUAL + 
					Convert.ToString(dr[Enumerados.ColumnasAdquisicionesPropias.IdAdquisicionPropia.ToString()])));
				
				e.Item.Cells[0].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				e.Item.Cells[0].Font.Underline=true;	
				e.Item.Cells[0].ForeColor= System.Drawing.Color.Blue;
				e.Item.Cells[0].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado("hGridPagina","hOrdenGrilla"));

				e.Item.Cells[7].Text = Convert.ToDouble(dr[Enumerados.ColumnasAdquisicionesPropias.MontoAdquisicionPropia.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4) ;

				DataTable dtprv = (new CAdquisicionesProveedor()).ListarAdquisicionProveedores(Convert.ToInt32(dr[Enumerados.ColumnasAdquisicionesPropias.IdAdquisicionPropia.ToString()]));
				foreach(DataRow dr2 in dtprv.Rows)
				{
					HtmlTable HTMLTable = Helper.CrearHtmlTabla(1,2,true);
					string IdObj = "obj" + dr2["IdProveedor"].ToString();
					HTMLTable.Attributes.Add("align","left");
					HTMLTable.Attributes.Add("style","MARGIN-BOTTOM: 5px; MARGIN-LEFT: 5px");
					HTMLTable.Attributes.Add("id",IdObj);
					HTMLTable.Attributes.Add("class","BaseItemInGrid");
					HTMLTable.Border=0;
					HTMLTable.Rows[0].Cells[0].InnerText=dr2["RazonSOcial"].ToString();
					HTMLTable.Rows[0].Cells[0].Attributes.Add("noWrap","noWrap");
					HtmlImage oIMGlr =  new HtmlImage();
					oIMGlr.Src= Page.Request.ApplicationPath + "/imagenes/Navegador/SAMResponsable.png" ;
					HTMLTable.Rows[0].Cells[1].Controls.Add(oIMGlr);
					e.Item.Cells[6].Controls.Add(HTMLTable);
				}



			}	
		}

		private void reiniciarCampos()
		{
		}

		private void ibtnEliminarFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}

		private void ibtnAgregar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.redireccionaPaginaAgregar();			
		}

		private void redireccionaPaginaAgregar()
		{
			Page.Response.Redirect(URLDETALLE + Utilitario.Constantes.KEYMODOPAGINA +  
				Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.N.ToString());
		}

		private void eliminar()
		{
			if(hCodigo.Value.Length==0)
			{
				ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO));
			}
			else
			{
				CAdquisiciones oCAdquisiciones = new CAdquisiciones();
				if(oCAdquisiciones.Eliminar(
					Convert.ToInt32(hCodigo.Value),
					Convert.ToInt32(Enumerados.TablasTabla.LogisticaEstadoAdquisicion),
					Convert.ToInt32(Enumerados.EstadosAdquisiciones.Anulado),
					CNetAccessControl.GetIdUser())>0)
				{
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Adquisiciones",this.ToString(),"Se eliminó la Adquisición Nro. " + hCodigo.Value +"." ,Enumerados.NivelesErrorLog.I.ToString()));

					this.LlenarGrillaOrdenamientoPaginacion(this.hOrdenGrilla.Value,Convert.ToInt32(this.hGridPagina.Value));
						
					ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONELIMINACIONREGISTRO));
				}
			}
		}

		private void ibtnFiltrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			DataTable dt = this.ObtenerDatos();

			ltlMensaje.Text = Utilitario.Helper.ElaborarFiltro(dt
				,Utilitario.Constantes.SIGNOASTERISCO +"PERIODO;Periodo"
				,"ObjetoAdquisicion;Objeto de la adquisición"
				,"RAZONSOCIAL;Proveedor"
				,"MontoAdquisicionPropia;Monto de Adquisición"
				,"ProyectoAdquisicionPropia;Proyecto"
				,Utilitario.Constantes.SIGNOASTERISCO +"CentroOperativo;Centro Operativo"
				,Utilitario.Constantes.SIGNOASTERISCO +"TipoMoneda;Moneda"
				);
		}
	}
}
