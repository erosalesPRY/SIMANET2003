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
	/// Summary description for AdministrarRegistroProyectoOtros.
	/// </summary>
	public class AdministrarRegistroProyectoOtros : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		#region Controles
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminarFiltro;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIDREGISTROPROYECTOOTROS;
		protected System.Web.UI.WebControls.ImageButton ibtnAgregar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminar;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hProyectosOtros;
		protected System.Web.UI.WebControls.ImageButton ibtnAgregarPuentes;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hOrdenGrilla;
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
			this.ibtnAgregarPuentes.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAgregarPuentes_Click);
			this.ibtnAgregar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAgregar_Click);
			this.ibtnEliminar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminar_Click);
			this.ibtnImprimir.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnImprimir_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region Constantes
		private const string KEYIDCLIENTE ="KEYIDCLIENTE";
		private const string GRILLAVACIA="No existe ningún registro";
		private const string MENSAJECONSULTAR="Se consulto los Registros de Proeyectos Otros";
		private const string URLIMPRESION= "PopupImpresionRegistroProyectosOtros.aspx";
		private const string KEYIDREGISTROPROYECTOOTROS="IDREGISTROPROYECTOOTROS";
		//private const string KEYIDUBIGEO="IDUBIGEO";
		//private const string KEYIDCENTROOPERATIVO="IDCENTROOPERATIVO";
		private const string URLDETALLE="DetalleRegistroProyectosOtros.aspx?";
		private const string URLDETALLEDOS= "DetalleConsultarRegistroProyectoMM.aspx?";
		private const string KEYQID="Id";
		private string JSVERIFICARELIMINAR = "return verificarEliminarRb('hProyectosOtros','" + Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO)+"','"+Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJEPREGUNTAELIMINACIONREGISTRO)+"');";
		private const string URLADMINISTRACION="AdministrarRegistroProyectoOtros.aspx";
		private const string MENSAJEELIMINAR="Se elimino un registro de Proyecto Otros Nro.";
		private const string CAMPOTIPO = "Tipo";
		private const int PROYECTOSOTROS = 0;

		//private const string COLORDENAMIENTO="IDPROYECTO";

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
			return oCMantenimientos.ListarTodosGrilla(Enumerados.ClasesNTAD.RegistroProyectoOtrosNTAD.ToString());
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
		{
			DataTable dtProyectos =  ObtenerDatos();
			
			if(dtProyectos!=null)
			{
				DataView dwProyectos = dtProyectos.DefaultView;
				dwProyectos.Sort = columnaOrdenar ;
				dwProyectos.RowFilter= Utilitario.Helper.ObtenerFiltro(this);
				grid.DataSource = dwProyectos;
				grid.CurrentPageIndex =indicePagina;

				grid.Columns[Utilitario.Constantes.POSICIONFOOTERTOTAL].FooterText = Utilitario.Constantes.TEXTOFOOTERTOTAL;
				grid.Columns[Utilitario.Constantes.POSICIONTOTAL].FooterText = dwProyectos.Count.ToString();
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
			catch (Exception a)
			{
				string b = a.Message.ToString();
				grid.CurrentPageIndex = 0;
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
			this.ibtnAgregar.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			this.ibtnAgregarPuentes.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			ibtnEliminar.Attributes.Add(Utilitario.Constantes.EVENTOCLICK ,JSVERIFICARELIMINAR);
		}
		public void RegistrarJScript()
		{
	

		}

		public void Imprimir()
		{
			ltlMensaje.Text = Helper.PopupImpresion(URLIMPRESION,750,500,false,false,false,true,true);
		}

		public void Exportar()
		{
			
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

		private void ibtnEliminarFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}

		private void ibtnFiltrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			ltlMensaje.Text = Utilitario.Helper.ElaborarFiltro(ObtenerDatos()
				,Enumerados.ColumnasRegistroProyectoOtros.IDPROYECTO.ToString()+ ";ID PROYECTO"
				,Constantes.SIGNOASTERISCO  + "NOMBREBUQUE"   + ";TIPO DE PRODUCTO"
				,Constantes.SIGNOASTERISCO  + "SIGLA1"+ ";Centro Operativo"
				,Enumerados.ColumnasRegistroProyectoOtros.NOMBRE.ToString() + ";NOMBRE"
				,Constantes.SIGNOASTERISCO  + "LINEAPRODUCTO" + ";LINEA DE PRODUCTO"
				,"NOMBRECLIENTE" + ";CLIENTE"
				,Enumerados.ColumnasRegistroProyectoOtros.FECHAACUERDO.ToString()+";FIRMA ACUERDO"
				);
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			grid.CurrentPageIndex=e.NewPageIndex;
			HttpContext.Current.Session[Constantes.KEYSINDICEPAGINA]=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{

				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				e.Item.Cells[Utilitario.Constantes.POSICIONINDEXCERO].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);

				if (Convert.ToInt32(dr[CAMPOTIPO].ToString()) == PROYECTOSOTROS)
				{
					e.Item.Cells[Constantes.POSICIONCONTADOR].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
						Helper.MostrarVentana(URLDETALLE,
						KEYIDREGISTROPROYECTOOTROS + Utilitario.Constantes.SIGNOIGUAL + 
						Convert.ToString(dr[Enumerados.ColumnasRegistroProyectoOtros.IDREGISTROPROYECTOOTROS.ToString()]) +
						Utilitario.Constantes.SIGNOAMPERSON + Utilitario.Constantes.KEYMODOPAGINA +
						Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.M.ToString()+
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYIDCLIENTE + Utilitario.Constantes.SIGNOIGUAL + dr[Enumerados.ColumnasRegistroProyectoCN.IdCliente.ToString()].ToString()	
						));

					Helper.SeleccionarItemGrillaOnClickMoverRaton(e
						,Utilitario.Helper.MostrarDatosEnCajaTexto
						(hIDREGISTROPROYECTOOTROS.ID,
						dr[Enumerados.ColumnasRegistroProyectoOtros.IDREGISTROPROYECTOOTROS.ToString()].ToString()),
						Utilitario.Helper.MostrarDatosEnCajaTexto
						(hProyectosOtros.ID,
						dr[CAMPOTIPO].ToString())
						);
				}
				else
				{
					e.Item.Cells[Constantes.POSICIONCONTADOR].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
						Helper.MostrarVentana(URLDETALLEDOS,
						KEYQID + Utilitario.Constantes.SIGNOIGUAL + 
						Convert.ToString(dr[Enumerados.ColumnasRegistroProyectoOtros.IDREGISTROPROYECTOOTROS.ToString()]) +
						Utilitario.Constantes.SIGNOAMPERSON + Utilitario.Constantes.KEYMODOPAGINA +
						Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.M.ToString() +
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYIDCLIENTE + Utilitario.Constantes.SIGNOIGUAL + dr[Enumerados.ColumnasRegistroProyectoCN.IdCliente.ToString()].ToString()	
						));

					Helper.SeleccionarItemGrillaOnClickMoverRaton(e
						,Utilitario.Helper.MostrarDatosEnCajaTexto
						(hIDREGISTROPROYECTOOTROS.ID,
						dr[Enumerados.ColumnasRegistroProyectoOtros.IDREGISTROPROYECTOOTROS.ToString()].ToString()),
						Utilitario.Helper.MostrarDatosEnCajaTexto
						(hProyectosOtros.ID,
						dr[CAMPOTIPO].ToString())
						);
				}
	
				e.Item.Cells[Constantes.POSICIONCONTADOR].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				e.Item.Cells[Constantes.POSICIONCONTADOR].Font.Underline = true;
				e.Item.Cells[0].ForeColor= System.Drawing.Color.Blue;
				
				Helper.FiltroporSeleccionConfiguraColumna(e,grid);

			}
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(e.SortExpression),Helper.ObtenerIndicePagina());
		}

		private void ibtnAgregar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect(URLDETALLE  + Utilitario.Constantes.KEYMODOPAGINA +
				Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.N.ToString() );
		}

		private void ibtnEliminar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				if(Page.IsValid)
				{
					this.Eliminar();
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


		#region IPaginaMantenimento Members
		public void Agregar()
		{
		
		}

		public void Modificar()
		{
		
		}

		public void Eliminar()
		{
			if(hIDREGISTROPROYECTOOTROS.Value.Length==Utilitario.Constantes.ValorConstanteCero)
			{
				ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJESELECCIONREGISTRO));
			}
			else
			{
				CMantenimientos oCMantenimientos = new CMantenimientos();

				if(hProyectosOtros.Value == PROYECTOSOTROS.ToString())
				{
					if(oCMantenimientos.Eliminar(Convert.ToInt32(hIDREGISTROPROYECTOOTROS.Value),CNetAccessControl.GetIdUser(),Enumerados.ClasesTAD.RegistroProyectoOtrosTAD.ToString())>Utilitario.Constantes.ValorConstanteCero)
					{
						LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Utilitario.Enumerados.NombresdeModulo.GestiónComercial.ToString(),this.ToString(),MENSAJEELIMINAR + hIDREGISTROPROYECTOOTROS.Value + Utilitario.Constantes.SIMBOLOPUNTO,Enumerados.NivelesErrorLog.I.ToString()));
						ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONELIMINACIONREGISTRO), URLADMINISTRACION);
						this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),Helper.ObtenerIndicePagina());
					
					}
				}
				else
				{
					if(oCMantenimientos.Eliminar(Convert.ToInt32(hIDREGISTROPROYECTOOTROS.Value),CNetAccessControl.GetIdUser(),Enumerados.ClasesTAD.ProyectosMMTAD.ToString())>Utilitario.Constantes.ValorConstanteCero)
					{
						LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Utilitario.Enumerados.NombresdeModulo.GestiónComercial.ToString(),this.ToString(),MENSAJEELIMINAR + hIDREGISTROPROYECTOOTROS.Value + Utilitario.Constantes.SIMBOLOPUNTO,Enumerados.NivelesErrorLog.I.ToString()));
						ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONELIMINACIONREGISTRO), URLADMINISTRACION);
						this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),Helper.ObtenerIndicePagina());
					
					}
				}
			}
		}

		public void CargarModoPagina()
		{
	
		}

		public void CargarModoNuevo()
		{
			
		}

		public void CargarModoModificar()
		{
			
		}

		public void CargarModoConsulta()
		{
			
		}

		public bool ValidarCampos()
		{
			return false;
		}

		public bool ValidarCamposRequeridos()
		{
			
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			
			return false;
		}

		#endregion

		
		private void ibtnAgregarPuentes_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect(URLDETALLEDOS+ Utilitario.Constantes.KEYMODOPAGINA +
				Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.N.ToString() );
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}



	}
}
