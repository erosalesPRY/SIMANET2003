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
using NullableTypes;
using MetaBuilders.WebControls;

namespace SIMA.SimaNetWeb.General
{
	/// <summary>
	/// Summary description for BuscarPersonalPorArea.
	/// </summary>
	public class BuscarPersonalPorArea : System.Web.UI.Page, IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblArea;
		protected System.Web.UI.WebControls.Label lblApellidoPaterno;
		protected System.Web.UI.WebControls.Label lblNombre;
		protected System.Web.UI.WebControls.DropDownList ddlbArea;
		protected System.Web.UI.WebControls.TextBox txtApellidoPaterno;
		protected System.Web.UI.WebControls.TextBox txtNombre;
		protected System.Web.UI.WebControls.ImageButton btnBuscar;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.Image imgCancelar;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdPersonal;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hPersonal;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdArea;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hNombreArea;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion Controles

		#region Constantes
		
		//Ordenamiento
		const string COLORDENAMIENTO = "ApellidoPaterno";

		//Nombres de Controles
		const string CONTROLINK = "hlkId";
		const string CONTROCHECKBOX = "cbxEliminar";
		
		//Paginas
		const string URLPRINCIPAL="ConsultarDetalleProyectosInmuebles.aspx";
		const string URLDETALLE = "DetallePoderes.aspx?";
		const string URLIMPRESION = "ConsultarDetalleProyectosInmuebles.aspx";
				
		//Key Session y QueryString
		const string KEYQID = "Id";
		const string KEYIDCO = "CentroOperativo";

		//JScript
		string JSVERIFICARELIMINAR = "return verificarEliminarRb('hCodigo','" + Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO)+"','"+Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJEPREGUNTAELIMINACIONREGISTRO)+"');";
				
		//Otros
		const string GRILLAVACIA ="No existe ningún Personal.";  

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
			this.btnBuscar.Click += new System.Web.UI.ImageClickEventHandler(this.btnBuscar_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.ibtnAceptar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAceptar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		ListItem lItem;

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					//this.ConfigurarAccesoControles();
					
					this.LlenarJScript();

					this.LlenarCombos();

					Helper.ReiniciarSession();
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

		private void llenarAreas()
		{
			CArea oCArea =  new   CArea();
			ddlbArea.DataSource = oCArea.ListarTodosCombo();
			ddlbArea.DataValueField=Enumerados.ColumnasArea.IdArea.ToString();
			ddlbArea.DataTextField=Enumerados.ColumnasArea.Nombre.ToString();
			ddlbArea.DataBind();
			//lItem = new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR ,Utilitario.Constantes.VALORSELECCIONAR);
			lItem = new ListItem(Utilitario.Constantes.TEXTOTODOS,Utilitario.Constantes.ValorConstanteCero.ToString());
			ddlbArea.Items.Insert(Utilitario.Constantes.IDDEFAULT, lItem);

		}	
		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add BuscarPersonalPorArea.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add BuscarPersonalPorArea.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			CPersonal oCPersonal =  new  CPersonal();
			
			DataTable dtPersonal =  oCPersonal.BuscarPersonalPorArea(Convert.ToInt32(ddlbArea.SelectedValue));

			if(dtPersonal!=null)
			{
				string CadenaBusqueda;

				DataView dwPersonal = dtPersonal.DefaultView;
				dwPersonal.Sort = columnaOrdenar ;			

				CadenaBusqueda = " 1 = 1 ";
				if(txtApellidoPaterno.Text!=Utilitario.Constantes.VACIO)
				{
					CadenaBusqueda = CadenaBusqueda + "and " + Utilitario.Enumerados.ColumnasPersonal.ApellidoPaterno + " like'" + "%" + txtApellidoPaterno.Text + "%" + "' ";				
				}

				if(txtNombre.Text!=Utilitario.Constantes.VACIO)
				{
					CadenaBusqueda = CadenaBusqueda + "and " + Utilitario.Enumerados.ColumnasPersonal.Nombres + " like'" + "%" + txtNombre.Text + "%" + "' ";				
				}

				dwPersonal.RowFilter = CadenaBusqueda;
				grid.DataSource = dwPersonal;
				lblResultado.Text = Utilitario.Constantes.VACIO;

			}
			else
			{
				grid.DataSource = dtPersonal;
				lblResultado.Text = GRILLAVACIA;

			}
			
			try
			{
				grid.DataBind();
			}

			catch (Exception e)
			{
				string a = e.Message;
				grid.CurrentPageIndex = 0;
				grid.DataBind();
			}
		}

		public void LlenarCombos()
		{
			this.llenarAreas();
		}

		public void LlenarDatos()
		{
			// TODO:  Add BuscarPersonalPorArea.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add BuscarPersonalPorArea.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add BuscarPersonalPorArea.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add BuscarPersonalPorArea.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add BuscarPersonalPorArea.Exportar implementation
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
			// TODO:  Add BuscarPersonalPorArea.ValidarFiltros implementation
			return false;
		}

		#endregion


		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			
			grid.CurrentPageIndex=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(e.SortExpression),Helper.ObtenerIndicePagina());
		}

		private void ibtnAceptar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if(hIdPersonal.Value.Length==0)
			{
				ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO));
			}
			else if(Page.Request.QueryString[Utilitario.Constantes.KEYTIPOBUSQUEDAENTIDAD] != null)
			{
//				if(Page.Request.QueryString[Utilitario.Constantes.KEYTIPOBUSQUEDAENTIDAD].ToString() == Enumerados.TipoBusquedaEntidad.P.ToString())
//				{
//					ltlMensaje.Text = "PonerTextoPromotor()";
//				}
				if(Page.Request.QueryString[Utilitario.Constantes.KEYTIPOBUSQUEDAENTIDAD].ToString() == Enumerados.TipoBusquedaEntidad.PE.ToString())
				{
					ltlMensaje.Text = "PonerTextoPersonal()";
				}
			}
			else
			{
				ltlMensaje.Text = "PonerTexto()";
			}
		}

		private void btnBuscar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				if(Convert.ToInt32(this.ddlbArea.SelectedIndex) != Utilitario.Constantes.ValorConstanteCero)
				{
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Personal",this.ToString(),"Se consultó Personal.",Enumerados.NivelesErrorLog.I.ToString()));
					
					this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO),Utilitario.Constantes.INDICEPAGINADEFAULT);
				}
				else //Buscar en todas las Areas
				{					
					//this.ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Utilitario.Enumerados.SeccionesArchivoConfiguracion.MensajesError.ToString(), Mensajes.CODIGOMENSAJEERRORSELECCIONAREA));
					this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO),Utilitario.Constantes.INDICEPAGINADEFAULT);
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

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,
					Utilitario.Helper.MostrarDatosEnCajaTexto("hIdPersonal",dr[Enumerados.ColumnasPersonal.IdPersonal.ToString()].ToString()),
					Utilitario.Helper.MostrarDatosEnCajaTexto("hPersonal",
					dr[Enumerados.ColumnasPersonal.ApellidoPaterno.ToString()].ToString() + ' ' +
					dr[Enumerados.ColumnasPersonal.ApellidoMaterno.ToString()].ToString()	+ ' ' +
					dr[Enumerados.ColumnasPersonal.Nombres.ToString()].ToString()),
					Utilitario.Helper.MostrarDatosEnCajaTexto("hIdArea", dr["IdArea"].ToString()),
					Utilitario.Helper.MostrarDatosEnCajaTexto("hNombreArea", dr["Area"].ToString()
					/*Utilitario.Helper.MostrarDatosEnCajaTexto("hIdArea", this.ddlbArea.SelectedValue.ToString()),
					Utilitario.Helper.MostrarDatosEnCajaTexto("hNombreArea", this.ddlbArea.SelectedItem.ToString()*/)
					);			
			}
		}
	}
}
