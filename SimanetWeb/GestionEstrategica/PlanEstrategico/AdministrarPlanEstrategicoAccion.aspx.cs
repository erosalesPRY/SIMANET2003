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
using SIMA.Controladoras.GestionEstrategica.PlanEstrategico;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;

namespace SIMA.SimaNetWeb.GestionEstrategica.PlanEstrategico
{
	/// <summary>
	/// Summary description for AdministrarPlanEstrategicoAccion.
	/// </summary>
	public class AdministrarPlanEstrategicoAccion : System.Web.UI.Page, IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.ImageButton ibtnAgregar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminar;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.WebControls.Label lblNombrePlanBase;
		protected System.Web.UI.WebControls.Label lblObjGral;
		protected System.Web.UI.WebControls.Label lblNombreObjGral;
		protected System.Web.UI.WebControls.Label lblObjEsp;
		protected System.Web.UI.WebControls.Label lblNombreObjEsp;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label lblPlanBase;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminaFiltro;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label5;
		#endregion

		#region Constantes
		
		//Ordenamiento
		const string COLORDENAMIENTO = "IdOEspecificos";
		const string CONTROLGRILLAINDICADORES ="gridIndicadores";
		
		//Paginas
		const string URLIMPRESION = "PopupImpresionAdministracionArticulosRelacionesPublicas.aspx";
		const string URLMODIFICAR = "DetallePlanEstrategicoAccion.aspx?";
		const string URLACTIVIDAD = "AdministrarPlanEstrategicoActividad.aspx?";
		
		const int COLUMNANUMERACION = 0;
		const int COLUMNAMODIFICAR = 1;
				
		//Key Session y QueryString
		
		const string NOMBREPLANBASE = "PLEstrNombre";
		const string NOMBREOBJGRAL  = "ObjGenNombre";
		const string NOMBREOBJESP   = "idObjEspNombre";
		const string NOMBREACCION   = "ACCION";

		const string KEYIDOBJGRAL   = "idObjGen";
		const string KEYIDOBJESP    = "idObjEsp";
		const string KEYIDACCION    = "IdAccion";
		const string KEYIDGRUPOCC   = "IdGrupoCC";

		const string KEYCODOBJGRAL  = "CodObjGen";
		const string KEYCODOBJESP   = "CodObjEsp";
		const string KEYCODACCION   = "CodAccion";

		const string KEYIDCO    = "idCentro";

		const string SESSIONPERIODO = "speriodo";
		const string SESSIONTIPO = "stipo";
		const string SESSIONNIVEL = "snivel";
		const string SESSIONTI = "sti";

		//Otros
		const string MENSAJEELIMINAR="Se elimino la accion Nro. ";
		const string MENSAJESELECCIONAR="Tiene que seleccionar un registro";
		const string GRILLAVACIA ="No existe ninguna Acción asignada.";
		const int PosicionFooterTotal = 1;
		//JScript
		string JSVERIFICARELIMINAR = "return verificarEliminarRb('hCodigo','" + Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO)+"','"+Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJEPREGUNTAELIMINACIONREGISTRO)+"');";

		#endregion Constantes

		#region Variables
		int periodo = 0;
		int idtipinf = 0;
		int idniv = 0;
		int idimportancia = 0;
		int prioridad = 0;
		string cadenaTipoinversion = "0";
		#endregion Variables

		private void Eliminar()
		{
			if(hCodigo.Value.Length==Utilitario.Constantes.ValorConstanteCero)
			{
				ltlMensaje.Text = Helper.MensajeAlert(MENSAJESELECCIONAR);
			}
			else
			{
				CMantenimientos oCMantenimientos = new CMantenimientos();

				if(oCMantenimientos.Eliminar(Convert.ToInt32(hCodigo.Value),CNetAccessControl.GetIdUser(),Utilitario.Enumerados.ClasesTAD.PEAccionTAD.ToString())>Utilitario.Constantes.ValorConstanteCero)
				{
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Utilitario.Enumerados.NombresdeModulo.GestionEstratégica.ToString(),this.ToString(),MENSAJEELIMINAR + hCodigo.Value + Utilitario.Constantes.SIMBOLOPUNTO,Enumerados.NivelesErrorLog.I.ToString()));
					ltlMensaje.Text = Helper.MensajeAlert("Se elimino el registro");
					this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO),Utilitario.Constantes.INDICEPAGINADEFAULT);
				}
			}
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.LlenarJScript();
					//this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarTitulos();
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se consultaron los Articulos destinados a Relaciones Publicas.",Enumerados.NivelesErrorLog.I.ToString()));
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
//					SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Utilitario.Constantes.CODIGOERRORGENERICO,oException.Message);
//					Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
					ltlMensaje.Text = Helper.MensajeAlert(oException.Message);	
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
			this.ibtnEliminaFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminaFiltro_Click);
			this.ibtnAgregar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAgregar_Click);
			this.ibtnEliminar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminar_Click);
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
			// TODO:  Add AdministrarPlanEstrategicoAccion.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarPlanEstrategicoAccion.LlenarGrillaOrdenamiento implementation
		}

		public DataTable ObtenerDatos(int per, int tipo, string cadenati, int nivel, int idimportancia, int prioridad)
		{
			int id = Convert.ToInt32(Page.Request.QueryString[KEYIDOBJESP]);

			CPEAccion oCPEAccion = new CPEAccion();
			return oCPEAccion.ListarPEACCION(id, per, tipo, cadenati, nivel, idimportancia, prioridad);
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dtAccion =  this.ObtenerDatos(periodo, idtipinf, cadenaTipoinversion, idniv, idimportancia, prioridad);
			
			if(dtAccion!=null)
			{
				DataView dwAccion = dtAccion.DefaultView;
				dwAccion.RowFilter = Helper.ObtenerFiltro();

				if(dwAccion.Count>0)
				{
					grid.DataSource = dwAccion;
					grid.PageSize = Helper.ObtenerCantidadRegistrosPorGrilla(7,14,21);
					grid.Columns[PosicionFooterTotal].FooterText = dwAccion.Count.ToString();
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
				grid.DataSource = dtAccion;
				this.lblResultado.Visible = true;
				lblResultado.Text = GRILLAVACIA;
			}
			
			try
			{
				grid.DataBind();
			}
			catch(Exception oException)
			{
				grid.CurrentPageIndex = 0;
				grid.DataBind();
			}
		}

		public void LlenarCombos()
		{
			// TODO:  Add AdministrarPlanEstrategicoAccion.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add AdministrarPlanEstrategicoAccion.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			this.ibtnAgregar.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			this.ibtnEliminar.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,JSVERIFICARELIMINAR);
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarPlanEstrategicoAccion.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministrarPlanEstrategicoAccion.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarPlanEstrategicoAccion.Exportar implementation
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
			// TODO:  Add AdministrarPlanEstrategicoAccion.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void ibtnAgregar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.redireccionaPaginaAgregar();
		}

	

		private void ibtnEliminarFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}


		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
					DataRowView drv = (DataRowView)e.Item.DataItem;
					DataRow dr = drv.Row;
					
					e.Item.Cells[0].Font.Underline=true;
					e.Item.Cells[0].ToolTip = "Modificar Accion:";
					e.Item.Cells[0].ForeColor= System.Drawing.Color.Blue;
					e.Item.Cells[0].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
						
					e.Item.Cells[1].Font.Underline=true;
					e.Item.Cells[1].ForeColor = Color.Blue;
					e.Item.Cells[1].ToolTip = "Mostrar Actividades:";
					//e.Item.Cells[1].Text = "AC " + Page.Request.QueryString[KEYCODIGOGENERADO] + Utilitario.Constantes.SIMBOLOPUNTO + e.Item.Cells[0].Text;

					e.Item.Cells[COLUMNANUMERACION].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.HISTORIALADELANTE + ";" +
						Helper.MostrarVentana(URLMODIFICAR,
						NOMBREPLANBASE + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[NOMBREPLANBASE] + Utilitario.Constantes.SIGNOAMPERSON
						+ NOMBREOBJGRAL + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[NOMBREOBJGRAL] + Utilitario.Constantes.SIGNOAMPERSON
						+ NOMBREOBJESP + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[NOMBREOBJESP] + Utilitario.Constantes.SIGNOAMPERSON 
						+ NOMBREACCION + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr["DESCRIPCION"]) + Utilitario.Constantes.SIGNOAMPERSON 
						+ KEYCODOBJGRAL + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYCODOBJGRAL] + Utilitario.Constantes.SIGNOAMPERSON 
						+ KEYCODOBJESP + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYCODOBJESP] + Utilitario.Constantes.SIGNOAMPERSON
						+ KEYCODACCION + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr["CODIGO"]) + Utilitario.Constantes.SIGNOAMPERSON
						+ KEYIDOBJGRAL + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYIDOBJGRAL] + Utilitario.Constantes.SIGNOAMPERSON
						+ KEYIDOBJESP + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYIDOBJESP] + Utilitario.Constantes.SIGNOAMPERSON
						+ KEYIDACCION + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr["IDACCION"]) + Utilitario.Constantes.SIGNOAMPERSON
						+ KEYIDGRUPOCC + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr["IDGRUPOCC"]) + Utilitario.Constantes.SIGNOAMPERSON
						+ KEYIDCO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYIDCO] + Utilitario.Constantes.SIGNOAMPERSON 
						+ Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.M.ToString()));
			
					e.Item.Cells[COLUMNAMODIFICAR].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.HISTORIALADELANTE + ";" +
						Helper.MostrarVentana(URLACTIVIDAD,
						NOMBREPLANBASE + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[NOMBREPLANBASE] + Utilitario.Constantes.SIGNOAMPERSON
						+ NOMBREOBJGRAL + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[NOMBREOBJGRAL] + Utilitario.Constantes.SIGNOAMPERSON
						+ NOMBREOBJESP + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[NOMBREOBJESP] + Utilitario.Constantes.SIGNOAMPERSON
						+ NOMBREACCION + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr["DESCRIPCION"]) + Utilitario.Constantes.SIGNOAMPERSON 
						+ KEYCODOBJGRAL + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYCODOBJGRAL] + Utilitario.Constantes.SIGNOAMPERSON 
						+ KEYCODOBJESP + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYCODOBJESP] + Utilitario.Constantes.SIGNOAMPERSON
						+ KEYCODACCION + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr["CODIGO"]) + Utilitario.Constantes.SIGNOAMPERSON
						+ KEYIDOBJGRAL + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYIDOBJGRAL] + Utilitario.Constantes.SIGNOAMPERSON
						+ KEYIDOBJESP + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYIDOBJESP] + Utilitario.Constantes.SIGNOAMPERSON
						+ KEYIDACCION + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr["IDACCION"]) + Utilitario.Constantes.SIGNOAMPERSON
						+ KEYIDGRUPOCC + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr["IDGRUPOCC"]) 
						));	

						projDataGridWeb.DataGridWeb gridInd =(projDataGridWeb.DataGridWeb)e.Item.Cells[4].FindControl(CONTROLGRILLAINDICADORES);	
						DataTable dt = (new CPEIndicador()).ConsultarIndicadoresPorAccion(					
							Convert.ToInt32(Page.Request.QueryString[KEYIDOBJESP]),
							Convert.ToInt32(dr[Enumerados.PlanEstrategicoColumnas.IdAccion.ToString()].ToString()));

						gridInd.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.gridIndicadores_ItemDataBound);
						gridInd.Columns[0].ItemStyle.Width = 400;
						gridInd.Columns[1].ItemStyle.Width = 150;
						gridInd.DataSource = dt;
						gridInd.DataBind();

					Helper.SeleccionarItemGrillaOnClickMoverRaton(e
						,Utilitario.Helper.MostrarDatosEnCajaTexto("hCodigo",dr["IDACCION"].ToString()));
	
					Helper.FiltroporSeleccionConfiguraColumna(e,grid,true,"txtBuscar");
			}
		}

		private void gridIndicadores_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				double Monto=0;

				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				Monto = Convert.ToDouble(dr[Enumerados.PlanEstrategicoColumnas.Total.ToString()]);

				/*if (Enumerados.TipoDatosColumnas.DOUBLE.ToString() == dr[Enumerados.PlanEstrategicoColumnas.Var2.ToString()].ToString())
				{e.Item.Cells[1].Text = Monto.ToString(Utilitario.Constantes.FORMATODECIMAL4);}
				else
				{*/e.Item.Cells[1].Text = Monto.ToString(Utilitario.Constantes.FORMATODECIMAL0);//}
			}								
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

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			grid.CurrentPageIndex=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(e.SortExpression),Helper.ObtenerIndicePagina());
		}

		private void redireccionaPaginaAgregar()
		{
				Page.Response.Redirect(URLMODIFICAR  
					+ NOMBREPLANBASE + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[NOMBREPLANBASE] + Utilitario.Constantes.SIGNOAMPERSON
					+ NOMBREOBJGRAL + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[NOMBREOBJGRAL] + Utilitario.Constantes.SIGNOAMPERSON
					+ NOMBREOBJESP + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[NOMBREOBJESP] + Utilitario.Constantes.SIGNOAMPERSON
					+ KEYIDOBJGRAL + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYIDOBJGRAL]+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYIDOBJESP + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYIDOBJESP] +  Utilitario.Constantes.SIGNOAMPERSON
					+ KEYIDCO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYIDCO] + Utilitario.Constantes.SIGNOAMPERSON
					+ KEYCODOBJGRAL + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYCODOBJGRAL] + Utilitario.Constantes.SIGNOAMPERSON
					+ KEYCODOBJESP + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYCODOBJESP] + Utilitario.Constantes.SIGNOAMPERSON
					+ Utilitario.Constantes.KEYMODOPAGINA +  Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.N.ToString()
					);
			
		}

		private void LlenarTitulos()
		{

			this.lblObjGral.Text  = Page.Request.QueryString[KEYCODOBJGRAL];
			this.lblObjEsp.Text   = Page.Request.QueryString[KEYCODOBJESP];

			this.lblNombrePlanBase.Text = Page.Request.QueryString[NOMBREPLANBASE];
			this.lblNombreObjGral.Text  = Page.Request.QueryString[NOMBREOBJGRAL];
			this.lblNombreObjEsp.Text   = Page.Request.QueryString[NOMBREOBJESP];
		}

		private void ibtnFiltrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			ltlMensaje.Text = Helper.ElaborarFiltro(this.ObtenerDatos(periodo, idtipinf, cadenaTipoinversion, idniv, idimportancia, prioridad)
				,"Codigo;Codigo Accion"
				,"Descripcion;Nombre Accion"
				//,"GCC;Area"
				);
		}

		private void ibtnEliminaFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
