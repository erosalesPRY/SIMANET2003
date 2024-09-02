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
using SIMA.Controladoras.GestionEstrategica.Proyecto;
using SIMA.Controladoras.General;
using SIMA.Controladoras;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using NullableTypes;
using MetaBuilders.WebControls;
using System.Configuration;

namespace SIMA.SimaNetWeb.GestionEstrategica.Proyecto
{
	/// <summary>
	/// Summary description for AdministrarProyectoInversion.
	/// </summary>
	public class AdministrarProyectoInversion : System.Web.UI.Page,IPaginaBase
	{

		private string LocalPathFilePIP
		{
			get{return ConfigurationSettings.AppSettings["RutaLocalProyectoInversion"].ToString();}
		}

		private string HTTPPathFilePIP
		{
			get{return ConfigurationSettings.AppSettings["RutaHTTPProyectoInversion"].ToString();}
		}

		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltro;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminaFiltro;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hEtapa;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIndicePagina;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hColumnaOrdenamiento;
		protected System.Web.UI.WebControls.Literal ltlMensaje;

	
		const string KEYQIDPROYECTOG="IdProyG";
		const string KEYQIDPROYECTOPERFIL="IdProyPerf";
		const string KEYQDESCRIPTIPPROY="DescripTipProy";
		const string KEYQIDTIPOPROYECTO="IdTipProy";
		const string KEYQCODIGOPIP="CodPIP";
		int IdTipoProy;

		const string GRILLAVACIA="No se encontro registro de Proyectos";
		
		const string NOMBREIMGTIPO="imgFileTipo";


		protected System.Web.UI.WebControls.ImageButton ibtnAgregar;
		protected System.Web.UI.HtmlControls.HtmlInputHidden Hidden1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdPIP;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdNivel;

		const string URLDETALLEESTUDIO="/GestionEstrategica/Proyecto/DetalleEstudiodePreInversion.aspx?";
		protected System.Web.UI.HtmlControls.HtmlImage ibtnPasarAProyInv;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnEliminarRegProy;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hPathArchivo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigoPIP;
		protected System.Web.UI.WebControls.ImageButton ibtnInsertar;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdProyPerfil;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdTipoProy;
		protected System.Web.UI.HtmlControls.HtmlInputFile FUFile;
		protected System.Web.UI.WebControls.Button btnSubir;
		const string URLDETALLEPROYECTO="/GestionEstrategica/Proyecto/DetalleProyectodeInversion.aspx?";
		

		private Enumerados.ModoPagina ModoDePagina
		{
			get
			{
				try
				{
					   return (Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.Params[Utilitario.Constantes.KEYMODOPAGINA].ToString()) ;
				}
				catch(Exception ex)
				{
					return Enumerados.ModoPagina.P;
				}
			}
		}
		private void Page_Load(object sender, System.EventArgs e)
		{
			IdTipoProy = Convert .ToInt32(Page.Request.Params[KEYQIDTIPOPROYECTO]);
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					this.LlenarJScript();
					this.LlenarDatos();

					Helper.ReiniciarSession();
					this.LlenarCombos();
					Helper.ReestablecerPagina(this);
					this.LlenarGrillaOrdenamientoPaginacion(this.hColumnaOrdenamiento.Value,Convert.ToInt32(this.hIndicePagina.Value));
				}
				catch(SIMAExcepcionLog oSIMAExcepcionLog)
				{
					Helper.MsgBox(oSIMAExcepcionLog.Mensaje);
				}
				catch(SIMAExcepcionIU oSIMAExcepcionIU)
				{
					Helper.MsgBox(oSIMAExcepcionIU.Mensaje);					
				}
				catch(SIMAExcepcionDominio oSIMAExcepcionDominio)
				{
					Helper.MsgBox(oSIMAExcepcionDominio.Mensaje);					
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
			this.ibtnFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnFiltro_Click);
			this.ibtnEliminaFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminaFiltro_Click);
			this.ibtnAgregar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAgregar_Click);
			this.ibtnInsertar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnInsertar_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.btnSubir.Click += new System.EventHandler(this.btnSubir_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add AdministrarProyectoInversion.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarProyectoInversion.LlenarGrillaOrdenamiento implementation
		}
		private DataTable ObtenerDatos(){
			return (new CProyectoGeneral()).ListarTodosGrilla(Convert.ToInt32(Page.Request.Params[KEYQIDTIPOPROYECTO]));
		}
		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dt=this.ObtenerDatos();

			if(dt!=null)
			{
				DataView dw = dt.DefaultView;
				dw.RowFilter=Utilitario.Helper.ObtenerFiltro();
				dw.Sort = columnaOrdenar;
				grid.DataSource = dw;
				indicePagina=Helper.ValidarIndicePaginacionGrilla(dw.Count,grid.PageSize,indicePagina);
				
			}
			else
			{
				grid.DataSource = dt;
				lblResultado.Visible = true;
				lblResultado.Text = GRILLAVACIA;
			}
			try
			{
				grid.CurrentPageIndex=indicePagina;
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
			// TODO:  Add AdministrarProyectoInversion.LlenarCombos implementation
		}

		public void LlenarDatos()
		{

			//this.hPathArchivo.Value = this.HTTPPathFilePIP;
			this.lblPagina.Text = Page.Request.Params[KEYQDESCRIPTIPPROY].ToString();
			this.hIdTipoProy.Value = Page.Request.Params[KEYQIDTIPOPROYECTO].ToString();
		}

		public void LlenarJScript()
		{
			this.btnSubir.Style["display"]="none";
			if(this.IdTipoProy==Convert.ToInt32(Enumerados.ItemTablaGeneral.Estrategica.TipodeProyecto.ProyectodeInversion))
			{
				this.ibtnAgregar.Style["display"]="none";
				this.ibtnInsertar.Style["display"]="none";
				FUFile.Style["display"]="none";
			}
			ibtnAgregar.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.POPUPDEESPERA + Helper.HistorialIrAdelantePersonalizado("hEtapa","hColumnaOrdenamiento","hIndicePagina"));
			ibtnInsertar.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.POPUPDEESPERA + Helper.HistorialIrAdelantePersonalizado("hEtapa","hColumnaOrdenamiento","hIndicePagina"));

			if(this.ModoDePagina==Enumerados.ModoPagina.C){
				this.ibtnAgregar.Style["display"]="none";
				ibtnEliminarRegProy.Style["display"]="none";
			}

		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarProyectoInversion.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministrarProyectoInversion.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarProyectoInversion.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add AdministrarProyectoInversion.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add AdministrarProyectoInversion.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				Helper.UIControls.DataGrid.CHiperLink((DataGrid)sender, e.Item.Cells[0],"HistorialIrAdelantePersonalizado('hIndicePagina;hColumnaOrdenamiento;hEtapa')"
					,Helper.Response.Redirec( Page.Request.ApplicationPath + ((IdTipoProy==1)?URLDETALLEESTUDIO :URLDETALLEPROYECTO)+ KEYQIDPROYECTOG + Utilitario.Constantes.SIGNOIGUAL + dr["IdProyectoG"].ToString() 
											+ Utilitario.Constantes.SIGNOAMPERSON 
											+ KEYQIDPROYECTOPERFIL + Utilitario.Constantes.SIGNOIGUAL + dr["IdProyectoPerfil"].ToString() 
											+ Utilitario.Constantes.SIGNOAMPERSON 
											+ KEYQIDTIPOPROYECTO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYQIDTIPOPROYECTO].ToString()
											+ Utilitario.Constantes.SIGNOAMPERSON 
											+ KEYQDESCRIPTIPPROY + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYQDESCRIPTIPPROY].ToString()
											+ Utilitario.Constantes.SIGNOAMPERSON 
					+ Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL +  ((this.ModoDePagina==Enumerados.ModoPagina.C)?Enumerados.ModoPagina.C.ToString(): Utilitario.Enumerados.ModoPagina.M.ToString()),false));

				Helper.UIControls.DataGrid.ItemGrilla_OnEvent(e,Helper.MostrarDatosEnCajaTexto("hIdPIP",dr["IdProyectoG"].ToString()),Helper.MostrarDatosEnCajaTexto("hIdProyPerfil",dr["IdProyectoPerfil"].ToString()),Helper.MostrarDatosEnCajaTexto("hIdNivel",dr["IdNivelAprobacion"].ToString()),Helper.MostrarDatosEnCajaTexto("hCodigoPIP",dr["CodigoPIP"].ToString()));
				
				string HTMLText = dr["Componentes"].ToString();
				e.Item.Cells[7].Text = HTMLText;


				if(Helper.IsNumeric(dr[Utilitario.Enumerados.ProyectosColumnasProyectosInversionPublicaQuery.CodigoSnip.ToString()].ToString()))
				{
					e.Item.Cells[3].Attributes[Enumerados.EventosJavaScript.OnClick.ToString()] = "SIMA.Utilitario.Helper.Estrategica.VentanaMINDEF(this,'" + dr[Utilitario.Enumerados.ProyectosColumnasProyectosInversionPublicaQuery.CodigoSnip.ToString()].ToString() + "');";
					e.Item.Cells[3].Style.Add("cursor","hand");
					e.Item.Cells[3].ForeColor=Color.Blue;
					e.Item.Cells[3].Font.Underline=true;

				}
				//string valor = e.Item.Cells[7].Text.


				//
//				HtmlImage oImg = (HtmlImage)e.Item.Cells[10].FindControl(NOMBREIMGTIPO);
//				string NombreFileOtros = dr["RutaArchivoOtros"].ToString();
//				if(NombreFileOtros.Length>0)
//				{
//					string []arrext = NombreFileOtros.Split('.');
//					string ext = arrext[arrext.Length-1].ToLower();
//					if((ext=="doc")||(ext=="xls")||(ext=="pdf")||(ext=="ppt"))
//					{
//						oImg.Src =  Page.Request.ApplicationPath + "/imagenes/Navegador/" + ext + ".gif";
//						oImg.Attributes[Enumerados.EventosJavaScript.OnClick.ToString().ToLower()]="(new SIMA.Utilitario.Helper.Window()).AbrirAchivo(jNet.get('hPathArchivo').value +'" + NombreFileOtros + "');";
//					}
//					else
//					{
//						oImg.Src = "/" + Page.Request.ApplicationPath + "/magenes/Navegador/Otros.gif";
//					}
//				}
//				else{
//					oImg.Style["display"]="none";
//				}
				Helper.FiltroporSeleccionConfiguraColumna(e,grid,true,"txtBuscar");

			}
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void ibtnAgregar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Page.Response.Redirect( Page.Request.ApplicationPath + ((IdTipoProy==1)?URLDETALLEESTUDIO :URLDETALLEPROYECTO) + Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL +  Utilitario.Enumerados.ModoPagina.N.ToString()
											+ Utilitario.Constantes.SIGNOAMPERSON 
											+ KEYQDESCRIPTIPPROY + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYQDESCRIPTIPPROY].ToString()
											+ Utilitario.Constantes.SIGNOAMPERSON 
											+ KEYQIDTIPOPROYECTO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYQIDTIPOPROYECTO].ToString()
									);
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.hIndicePagina.Value=e.NewPageIndex.ToString();
			grid.CurrentPageIndex=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);	

		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			hColumnaOrdenamiento.Value=Helper.GenerarExpresionOrdenamiento(e.SortExpression);
			this.LlenarGrillaOrdenamientoPaginacion(hColumnaOrdenamiento.Value,Helper.ObtenerIndicePagina());
		}

		private void ibtnFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			
			ltlMensaje.Text = Helper.ElaborarFiltro(this.ObtenerDatos(),"NombreProyecto;Nombre de proyecto"
				,"CodigoPIP;Codigo de PIP"
				,"NombreoEspecificos;Objetivo especifico"
				,Utilitario.Constantes.SIGNOASTERISCO + "NombreCentroOperativo;Centro Operativo"
				,"CodigoProyecto;Codigo PC"
				,Utilitario.Constantes.SIGNOASTERISCO + "NombreEtapa;Etapa"
				,Utilitario.Constantes.SIGNOASTERISCO + "NombreNivelAprobacion;Nivel de aprobacion"
				);
		}

		private void ibtnEliminaFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}

		private void ibtnInsertar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if(this.hCodigoPIP.Value!="0")
			{
				Page.Response.Redirect( Page.Request.ApplicationPath + ((IdTipoProy==1)?URLDETALLEESTUDIO :URLDETALLEPROYECTO) + Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL +  Utilitario.Enumerados.ModoPagina.N.ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON 
					+ KEYQDESCRIPTIPPROY + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYQDESCRIPTIPPROY].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON 
					+ KEYQIDTIPOPROYECTO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYQIDTIPOPROYECTO].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON 
					+ KEYQCODIGOPIP + Utilitario.Constantes.SIGNOIGUAL + this.hCodigoPIP.Value
					);
			}
			else{
				Helper.MsgBox("Seleccionar un registro de referencia para la inserción de uno nuevo");
			}
		}

		private void btnSubir_Click(object sender, System.EventArgs e)
		{
			string NombreFile = "ResumenPIP";
			Helper.SubirArchivo(this.FUFile,this.LocalPathFilePIP+@"Ayuda\",NombreFile);
		}

	
	}
}
