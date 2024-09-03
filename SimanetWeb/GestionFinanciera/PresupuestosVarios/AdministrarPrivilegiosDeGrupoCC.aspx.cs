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
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using SIMA.Controladoras.General;
using SIMA.Controladoras.GestionFinanciera;

namespace SIMA.SimaNetWeb.GestionFinanciera.PresupuestosVarios
{
	/// <summary>
	/// Summary description for AdministrarPrivilegiosDeGrupoCC.
	/// </summary>
	public class AdministrarPrivilegiosDeGrupoCC : System.Web.UI.Page, IPaginaBase
	{
		#region controles
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.DropDownList ddblTipoPresupuesto;
		protected System.Web.UI.WebControls.Label lblLugar;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminarFiltro;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected projDataGridWeb.DataGridWeb dgGrupoCentroCostos;
		#endregion controles
		#region Constantes

		//FOOTER
		const string TEXTOFOOTERTOTAL = "Total : ";
		const int    POSICIONFOOTERTOTAL = 1;
		
		//Ordenamiento
		const string COLORDENAMIENTO = "nombre";

		//Paginas
		const string URLPRINCIPAL= "../Default.aspx";
		const string URLDETALLE = "DetalleAdministrarPrivilegiosDeGrupoCC.aspx?";
		const string URLADMINISTRACION = "AdministrarPrivilegiosDeGrupoCC.aspx";
		
				
		//Key Session y QueryString
		const string KEYQID = "Id";
//		const string KEYQNOMBRE = "Nombre";
		const string KEYQIDGRUPOCC = "IdGrupoCC";
		const string KEYQNROGRUPOCC = "NroGrupoCC";
		const string KEYQTIPOPPTO ="TipoPpto";
	
		
		//JScript
		string JSVERIFICARELIMINAR = "return verificarEliminarRb('hCodigo','" + Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO)+"','"+Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJEPREGUNTAELIMINACIONREGISTRO)+"');";
		string JSVERIFICARSELECCION = "return verificarSeleccionRb('hCodigo','" + Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO) + "');";		
		//Otros
		const string GRILLAVACIA ="No existe ningun Grupo de Centro de Costos";
		ListItem  lItem ;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hNroGrupoCC;
		
		
		const int PosicionFooterTotal = 2;
		
		
		#endregion Constantes
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					this.LlenarJScript();
					this.LlenarCombos();
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Documentaria",this.ToString(),"Se consultó Registro de Grupo de Centro de Costos.",Enumerados.NivelesErrorLog.I.ToString()));
					//this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO),Utilitario.Constantes.INDICEPAGINADEFAULT);
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
			this.ddblTipoPresupuesto.SelectedIndexChanged += new System.EventHandler(this.ddblTipoPresupuesto_SelectedIndexChanged);
			this.ibtnFiltrar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnFiltrar_Click);
			this.ibtnEliminarFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminarFiltro_Click);
			this.dgGrupoCentroCostos.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgGrupoCentroCostos_PageIndexChanged);
			this.dgGrupoCentroCostos.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgGrupoCentroCostos_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add AdministrarPrivilegiosDeGrupoCC.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarPrivilegiosDeGrupoCC.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
						
		}

		private void dgGrupoCentroCostos_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				e.Item.Cells[Constantes.POSICIONCONTADOR].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.MostrarVentana(URLDETALLE,KEYQIDGRUPOCC + Utilitario.Constantes.SIGNOIGUAL + 
					Convert.ToString(dr[Enumerados.ColumnaGrupoCentroCosto.idGrupoCC.ToString()]) + 
					Utilitario.Constantes.SIGNOAMPERSON + KEYQTIPOPPTO + Utilitario.Constantes.SIGNOIGUAL +
					this.ddblTipoPresupuesto.SelectedValue + Utilitario.Constantes.SIGNOAMPERSON + 
					KEYQNROGRUPOCC + Utilitario.Constantes.SIGNOIGUAL + 
					Convert.ToString(dr[Enumerados.ColumnaGrupoCentroCosto.nroGrupoCC.ToString()])+
					Utilitario.Constantes.SIGNOAMPERSON + Utilitario.Constantes.KEYMODOPAGINA +
					Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.M.ToString()));
	
				e.Item.Cells[Constantes.POSICIONCONTADOR].Text = Helper.ObtenerIndicedeRegistro(this.dgGrupoCentroCostos.CurrentPageIndex,this.dgGrupoCentroCostos.PageSize,e.Item.ItemIndex);
				e.Item.Cells[Constantes.POSICIONCONTADOR].Font.Underline=true;

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,Utilitario.Helper.MostrarDatosEnCajaTexto("hCodigo",dr[Enumerados.ColumnaGrupoCentroCosto.idGrupoCC.ToString()].ToString()),
					Utilitario.Helper.MostrarDatosEnCajaTexto("hNroGrupoCC",dr[Enumerados.ColumnaGrupoCentroCosto.nroGrupoCC.ToString()].ToString()));
				
				Helper.FiltroporSeleccionConfiguraColumna(e,this.dgGrupoCentroCostos);
			}
		}

		private void dgGrupoCentroCostos_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			
		}

		private void ibtnEliminarFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}

		private void ibtnFiltrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
//			CGrupoCentroCosto oCGrupoCentroCosto = new CGrupoCentroCosto();
//			DataTable dtGrupoCentroCosto = oCGrupoCentroCosto.ListarTodosGrilla(NetAccessControl.CNetAccessControl.GetIdUser());
//
//			ltlMensaje.Text= Utilitario.Helper.ElaborarFiltro(dtGrupoCentroCosto
//				,Utilitario.Enumerados.ColumnaGrupoCentroCosto.nroGrupoCC.ToString()+";NroGrupoCC"
//				,Utilitario.Enumerados.ColumnaGrupoCentroCosto.nombre.ToString()+ ";Nombre");
		}

		public void LlenarCombos()
		{
			lItem = new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,Utilitario.Constantes.VALORSELECCIONAR);
			this.llenarTipoPresupuestos();
			this.ddblTipoPresupuesto.Items.Insert(Utilitario.Constantes.ValorConstanteCero,lItem);

		}

		public void LlenarDatos()
		{
			// TODO:  Add AdministrarPrivilegiosDeGrupoCC.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add AdministrarPrivilegiosDeGrupoCC.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarPrivilegiosDeGrupoCC.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministrarPrivilegiosDeGrupoCC.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarPrivilegiosDeGrupoCC.Exportar implementation
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
			// TODO:  Add AdministrarPrivilegiosDeGrupoCC.ValidarFiltros implementation
			return false;
		}

		#endregion
		
		public void llenarTipoPresupuestos()
		{
			CGrupoCentroCosto oCGrupoCentroCosto = new CGrupoCentroCosto();
			this.ddblTipoPresupuesto.DataSource = oCGrupoCentroCosto.ListarTodosComboPresupuesto();
			ddblTipoPresupuesto.DataValueField =Enumerados.ColumnaTipoPresupuesto.idTipoPresupuesto.ToString();
			ddblTipoPresupuesto.DataTextField =Enumerados.ColumnaTipoPresupuesto.nombre.ToString();
			ddblTipoPresupuesto.DataBind();
			
		
		}

		private void ddblTipoPresupuesto_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO),Utilitario.Constantes.INDICEPAGINADEFAULT, Convert.ToInt32(this.ddblTipoPresupuesto.SelectedValue));
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina, int idPresupuesto)
		{
			CPrivilegiosGrupoCentroCosto oCPrivilegiosGrupoCentroCosto = new CPrivilegiosGrupoCentroCosto();
			DataTable dtGrupoCentroCosto = oCPrivilegiosGrupoCentroCosto.ListarTodosGrilla(NetAccessControl.CNetAccessControl.GetIdUser(),idPresupuesto);
			
			if(dtGrupoCentroCosto!=null)
			{
				DataView dwGrupoCentroCosto = dtGrupoCentroCosto.DefaultView;
				dwGrupoCentroCosto.Sort = columnaOrdenar ;
				dwGrupoCentroCosto.RowFilter = Helper.ObtenerFiltro(this);

				if(dwGrupoCentroCosto.Count> Utilitario.Constantes.ValorConstanteCero)
				{
					this.dgGrupoCentroCostos.DataSource = dwGrupoCentroCosto;
					this.dgGrupoCentroCostos.Columns[PosicionFooterTotal].FooterText = dwGrupoCentroCosto.Count.ToString();
					this.lblResultado.Visible = false;
				}
				else
				{
					this.dgGrupoCentroCostos.DataSource = null;
					lblResultado.Visible = true;
					lblResultado.Text = GRILLAVACIA;
				}
				//				CImpresion oCImpresion = new CImpresion();
				//				oCImpresion.GuardarDataImprimirExportar(dwDependenciaNavales.Table,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGOTITULOREPORTEDEPENDENCIANAVALES),columnaOrdenar,indicePagina);
			}
			else
			{
				this.dgGrupoCentroCostos.DataSource = dtGrupoCentroCosto;
				this.lblResultado.Visible = true;
				lblResultado.Text = GRILLAVACIA;
			}
			
			try
			{
				this.dgGrupoCentroCostos.DataBind();
			}
			catch	
			{
				this.dgGrupoCentroCostos.CurrentPageIndex = 0;
				this.dgGrupoCentroCostos.DataBind();
			}

		}

	}
}
