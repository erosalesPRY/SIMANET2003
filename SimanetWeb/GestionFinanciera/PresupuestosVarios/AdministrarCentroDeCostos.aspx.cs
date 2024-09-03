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

namespace SIMA.SimaNetWeb.GestionFinanciera
{
	/// <summary>
	/// Summary description for AdministrarCentroDeCostos.
	/// </summary>
	public class AdministrarCentroDeCostos : System.Web.UI.Page, IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.WebControls.Label lblNombreGrupoCC;
		protected projDataGridWeb.DataGridWeb dgCentroCostos;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.ImageButton ibtnCentroCosto;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion

		#region Constantes

		//FOOTER
		const string TEXTOFOOTERTOTAL = "Total : ";
		const int    POSICIONFOOTERTOTAL = 1;
		
		//Ordenamiento
		const string COLORDENAMIENTO = "nombre";
		

		//Paginas
		const string URLADMINISTRACION= "AdministrarCentroDeCostos.aspx?";
		const string URLDETALLE = "DetalleAdministrarCentroDeCostos.aspx?";
		
				
		//Key Session y QueryString
		const string KEYQID = "Id";
		const string KEYQNOMBRE = "Nombre";

		const string KEYQIDGRUPOCC = "IdGrupoCC";
		const string KEYQNROGRUPOCC = "NroGrupoCC";
		



		//JScript
		string JSVERIFICARELIMINAR = "return verificarEliminarRb('hCodigo','" + Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO)+"','"+Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJEPREGUNTAELIMINACIONREGISTRO)+"');";
			
		//Otros
		const string GRILLAVACIA ="No existe ningun Centro de Costos";
	
		const int PosicionFooterTotal = 2;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminaFiltro;
		protected System.Web.UI.WebControls.ImageButton ibtnAgregar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminar;
		const string DELGRUPOCC =" DEL GRUPO DE CENTRO DE COSTOS - ";
		#endregion Constantes
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					//this.ConfigurarAccesoControles();
					this.LlenarJScript();
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Financiera",this.ToString(),"Se consultó Registro de  Centro de Costos.",Enumerados.NivelesErrorLog.I.ToString()));
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
			this.ibtnEliminaFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminaFiltro_Click);
			this.ibtnAgregar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAgregar_Click);
			this.ibtnEliminar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminar_Click);
			this.dgCentroCostos.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.dgCentroCostos_SortCommand);
			this.dgCentroCostos.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgCentroCostos_PageIndexChanged);
			this.dgCentroCostos.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgCentroCostos_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add AdministrarCentroDeCostos.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarCentroDeCostos.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			
			//this.lblNombreGrupoCC.Text = DELGRUPOCC + " " + Convert.ToString(Page.Request.QueryString[KEYQNOMBRE]);
			CCentroCosto oCCentroCosto = new CCentroCosto();
			DataTable dtCentroCosto = oCCentroCosto.ListarTodosGrilla(Convert.ToInt32(Page.Request.QueryString[KEYQIDGRUPOCC]));
			
			if(dtCentroCosto!=null)
			{
				DataView dwCentroCosto = dtCentroCosto.DefaultView;
				dwCentroCosto.Sort = columnaOrdenar;
				dwCentroCosto.RowFilter = Helper.ObtenerFiltro(this);

				if(dwCentroCosto.Count>0)
				{
					this.dgCentroCostos.DataSource = dwCentroCosto;
					this.dgCentroCostos.Columns[PosicionFooterTotal].FooterText = dwCentroCosto.Count.ToString();
					this.lblResultado.Visible = false;
				}
				else
				{
					this.dgCentroCostos.DataSource = null;
					lblResultado.Visible = true;
					lblResultado.Text = GRILLAVACIA;
				}
				
			}
			else
			{
				this.dgCentroCostos.DataSource = dtCentroCosto;
				this.lblResultado.Visible = true;
				lblResultado.Text = GRILLAVACIA;
			}
			
			try
			{
				this.dgCentroCostos.DataBind();
			}
			catch(Exception ex)
			{
				string a = ex.Message;
				this.dgCentroCostos.CurrentPageIndex = 0;
				this.dgCentroCostos.DataBind();
			}

		}

		public void LlenarCombos()
		{
			// TODO:  Add AdministrarCentroDeCostos.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add AdministrarCentroDeCostos.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			ibtnEliminar.Attributes.Add(Constantes.EVENTOCLICK,JSVERIFICARELIMINAR);
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarCentroDeCostos.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministrarCentroDeCostos.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarCentroDeCostos.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			if(CNetAccessControl.FindPage(Page.Request.Url.AbsolutePath.ToString()))
			{CNetAccessControl.LoadControls(this);}
			else
			{CNetAccessControl.RedirectPageError();}				
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add AdministrarCentroDeCostos.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void dgCentroCostos_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			try
			{	
				if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
				{
					DataRowView drv = (DataRowView)e.Item.DataItem;
					DataRow dr = drv.Row;

					e.Item.Cells[Constantes.POSICIONCONTADOR].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
						Helper.MostrarVentana(URLDETALLE,KEYQID + Utilitario.Constantes.SIGNOIGUAL + 
						Convert.ToString(dr[Enumerados.ColumnaCentroCosto.IdCentroCosto.ToString()]) +  
						Utilitario.Constantes.SIGNOAMPERSON + Utilitario.Constantes.KEYMODOPAGINA +
						Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.M.ToString() +
						Constantes.SIGNOAMPERSON + KEYQIDGRUPOCC + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQIDGRUPOCC].ToString() + 
						Constantes.SIGNOAMPERSON + KEYQNROGRUPOCC + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQNROGRUPOCC].ToString()  
						//Constantes.SIGNOAMPERSON + KEYQNOMBRE + Utilitario.Constantes.SIGNOIGUAL + 
						//Convert.ToString(dr[Enumerados.ColumnaCentroCosto.Nombre.ToString()])
						));
	
					e.Item.Cells[Constantes.POSICIONCONTADOR].Text = Helper.ObtenerIndicedeRegistro(this.dgCentroCostos.CurrentPageIndex,this.dgCentroCostos.PageSize,e.Item.ItemIndex);
					e.Item.Cells[Constantes.POSICIONCONTADOR].Font.Underline=true;

					Helper.SeleccionarItemGrillaOnClickMoverRaton(e,Utilitario.Helper.MostrarDatosEnCajaTexto("hCodigo",dr[Enumerados.ColumnaCentroCosto.IdCentroCosto.ToString()].ToString()));
					Helper.FiltroporSeleccionConfiguraColumna(e,this.dgCentroCostos);
				}
			}
			catch(Exception ex)
			{
				string a = ex.Message;
			}
		}

		private void dgCentroCostos_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.dgCentroCostos.CurrentPageIndex=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);
		}

		private void ibtnFiltrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			CCentroCosto oCCentroCosto = new CCentroCosto();
			DataTable dtCentroCosto = oCCentroCosto.ListarTodosGrilla(Convert.ToInt32(Page.Request.QueryString[KEYQIDGRUPOCC]));
			

			ltlMensaje.Text= Utilitario.Helper.ElaborarFiltro(dtCentroCosto
				,Utilitario.Enumerados.ColumnaCentroCosto.NroCC.ToString()+";NroCC"
				,Utilitario.Enumerados.ColumnaCentroCosto.Nombre.ToString()+ ";Nombre");
		}

		private void ibtnEliminaFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}

		private void ibtnAgregar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.redireccionaPaginaAgregar();
		}
		private void redireccionaPaginaAgregar()
		{
			int idGrupoCC = Convert.ToInt32(Page.Request.QueryString[KEYQIDGRUPOCC]);
			int nroGrupoCC = Convert.ToInt32(Page.Request.QueryString[KEYQNROGRUPOCC]);
			string nombre = Convert.ToString(Page.Request.QueryString[KEYQNOMBRE]);
			
			Page.Response.Redirect(URLDETALLE + Utilitario.Constantes.KEYMODOPAGINA + 
				Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.N.ToString()+ 
				Constantes.SIGNOAMPERSON + KEYQIDGRUPOCC + Constantes.SIGNOIGUAL + idGrupoCC +
				Constantes.SIGNOAMPERSON + KEYQNROGRUPOCC + Constantes.SIGNOIGUAL + nroGrupoCC 
				//Constantes.SIGNOAMPERSON + KEYQNOMBRE + Constantes.SIGNOIGUAL + nombre
				);
			}

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

		private void eliminar()
		{			
			if(hCodigo.Value.Length==0 )
			{
				ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO));
			}
			else
			{
				CMantenimientos oCMantenimientos = new CMantenimientos();

				if(oCMantenimientos.Eliminar(Convert.ToInt32(hCodigo.Value),CNetAccessControl.GetIdUser(),Enumerados.ClasesTAD.CentroCostoTAD.ToString())>0)
				{
					//Graba en el Log la acción ejecutada
					string idGrupoCC = Page.Request.QueryString[KEYQIDGRUPOCC].ToString();
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Financiera",this.ToString(),"Se eliminó el Centro de Costo Nro. " + hCodigo.Value +"." ,Enumerados.NivelesErrorLog.I.ToString()));
					this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),Helper.ObtenerIndicePagina());
					//ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJEELIMINACIONMOFICACIONOCC), URLADMINISTRACION + KEYQNOMBRE + Constantes.SIGNOIGUAL + idGrupoCC);
					
					
					
				}
			}
		}

		private void dgCentroCostos_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
		this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(e.SortExpression),Helper.ObtenerIndicePagina());
		}
	}
}
