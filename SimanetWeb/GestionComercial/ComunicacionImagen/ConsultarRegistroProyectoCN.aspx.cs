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
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;

namespace SIMA.SimaNetWeb.GestionComercial.ComunicacionImagen
{
	/// <summary>
	/// Summary description for ConsultarRegistroProyectoCN.
	/// </summary>
	public class ConsultarRegistroProyectoCN : System.Web.UI.Page, IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.ImageButton ibtnPlaca;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminarFiltro;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hOrdenGrilla;
		protected System.Web.UI.HtmlControls.HtmlInputHidden Hidden1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hPagina;
		#endregion

		#region Constantes
		//URL
		private const string KEYIDCLIENTE ="KEYIDCLIENTE";
		private const string URLPLACA="PopupImpresionPlacaRegistroProyeectoCN.aspx?";
		private const string URLIMPRESION="PopupImpresionRegistroProyectoCN.aspx?";
		private const string URLDETALLE="DetalleRegistroProyectos.aspx?";
		private const string URLADMINISTRACION="AdministrarRegistroProyectoCN.aspx?";

		//KEY
		const string KEYIDREGISTROPROYECTOCN= "IdRegistroProyectoCN";

		//Ordenamiento y Paginacion
		private const string COLORDENAMIENTO="IDHISTORICO";

		//Mensaje
		private const string GRILLAVACIA="No existe ningún registro";
		private const string MENSAJECONSULTAR="Se consulto la Administracion de Registro de Proeyecto CN";
		
		//Jscript
		private string JSVERIFICARSELECCIONFILA="return verificarSeleccionRb('hCodigo','"+ Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO) + "');";
		
		#endregion
		
		#region Eventos
		private void Page_Load(object sender, System.EventArgs e)
		{
			 if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					this.LlenarJScript();
					
					this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),Helper.ObtenerIndicePagina());
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Utilitario.Enumerados.NombresdeModulo.GestiónComercial.ToString(),this.ToString(),MENSAJECONSULTAR,Enumerados.NivelesErrorLog.I.ToString()));			
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
	
		private void ibtnImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Imprimir();
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
			this.ibtnFiltrar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnFiltrar_Click);
			this.ibtnEliminarFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminarFiltro_Click);
			this.ibtnPlaca.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnPlaca_Click);
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
			
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			
		}

		public DataTable ObtenerDatos()
		{
			CMantenimientos oCMantenimientos =  new CMantenimientos();
			return oCMantenimientos.ListarTodosGrilla(Enumerados.ClasesNTAD.RegistroProyectoCNNTAD.ToString());
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
		{
			DataTable dtProyectos =  ObtenerDatos();
			
			if(dtProyectos!=null)
			{
				DataView dwProyectos = dtProyectos.DefaultView;
				dwProyectos.Sort = columnaOrdenar ;
				hOrdenGrilla.Value = columnaOrdenar;
				dwProyectos.RowFilter = Helper.ObtenerFiltro(this);
				if(dwProyectos.Count>0)
				{
					grid.CurrentPageIndex = indicePagina;
					grid.DataSource = dwProyectos;
					grid.Columns[2].FooterText = dwProyectos.Count.ToString();
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
				grid.DataSource = dtProyectos;
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
		}

		public void LlenarDatos()
		{
		}

		public void LlenarJScript()
		{
			ibtnPlaca.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,JSVERIFICARSELECCIONFILA);

		}

		public void RegistrarJScript()
		{
	

		}

		public void Imprimir()
		{
			ltlMensaje.Text = Helper.PopupImpresion(URLIMPRESION,780,500,false,false,false,true,true);						
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

		
		private void ibtnEliminarFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}

		private void ibtnFiltrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			ltlMensaje.Text = Utilitario.Helper.ElaborarFiltro(ObtenerDatos()
				,"idhistorico" + ";Id Proyecto"
				,Constantes.SIGNOASTERISCO  + "CO"+ ";Centro Operativo"
				,Enumerados.ColumnasRegistroProyectoCN.Nombre.ToString()+";Nombre"
				,Constantes.SIGNOASTERISCO  + "BUQUE"+";Tipo de Producto"
				,Constantes.SIGNOASTERISCO  + "LINEAPRODUCTO"+";Linea de Producto"
				,"razonsocial"+";Cliente"
				,Enumerados.ColumnasRegistroProyectoCN.FechaFirmaAcuerdo.ToString()+";Fecha Acuerdo"
				);
		}

		private void ibtnPlaca_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.redireccionarPaginaPlaca();
		}

		private void redireccionarPaginaPlaca()
		{
			ltlMensaje.Text = Helper.PopupImpresion(URLPLACA + KEYIDREGISTROPROYECTOCN + Utilitario.Constantes.SIGNOIGUAL+  hCodigo.Value,750,500,false,false,false,true,true);
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				if(dr[Enumerados.ColumnasRegistroProyectoCN.IdCliente.ToString()].ToString() != String.Empty)
					e.Item.Cells[Constantes.POSICIONCONTADOR].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
						Helper.MostrarVentana("PreDetalleRegistroProyectosCN.aspx?",KEYIDREGISTROPROYECTOCN + Utilitario.Constantes.SIGNOIGUAL + 
						Convert.ToString(dr[Enumerados.ColumnasRegistroProyectoCN.IdRegistroProyectoCN.ToString()]) +  
						Utilitario.Constantes.SIGNOAMPERSON + Utilitario.Constantes.KEYMODOPAGINA +
						Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.C.ToString()+
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYIDCLIENTE + Utilitario.Constantes.SIGNOIGUAL + dr[Enumerados.ColumnasRegistroProyectoCN.IdCliente.ToString()].ToString()
					));
				else
					e.Item.Cells[Constantes.POSICIONCONTADOR].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
						Helper.MostrarVentana("PreDetalleRegistroProyectosCN.aspx?",KEYIDREGISTROPROYECTOCN + Utilitario.Constantes.SIGNOIGUAL + 
						Convert.ToString(dr[Enumerados.ColumnasRegistroProyectoCN.IdRegistroProyectoCN.ToString()]) +  
						Utilitario.Constantes.SIGNOAMPERSON + Utilitario.Constantes.KEYMODOPAGINA +
						Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.C.ToString()+
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYIDCLIENTE + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.ValorConstanteCero.ToString()
						));
	
				
				e.Item.Cells[Constantes.POSICIONCONTADOR].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				e.Item.Cells[Constantes.POSICIONCONTADOR].Font.Underline=true;
				e.Item.Cells[Constantes.POSICIONCONTADOR].ForeColor=Color.Blue;
				
				e.Item.Cells[0].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado("hGridPagina","hOrdenGrilla"));
				
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,Utilitario.Helper.MostrarDatosEnCajaTexto("hCodigo",dr[Enumerados.ColumnasRegistroProyectoCN.IdRegistroProyectoCN.ToString()].ToString()));
				Helper.FiltroporSeleccionConfiguraColumna(e,grid);
				
			}
		}
	
		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			grid.CurrentPageIndex=e.NewPageIndex;
			HttpContext.Current.Session[Constantes.KEYSINDICEPAGINA]=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);
		}

	
		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(e.SortExpression),Helper.ObtenerIndicePagina());
		}




		
	}
}
