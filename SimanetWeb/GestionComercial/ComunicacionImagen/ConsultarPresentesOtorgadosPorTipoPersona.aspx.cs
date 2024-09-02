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
using SIMA.Controladoras.GestionComercial;
using SIMA.Controladoras.General;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;
using System.Text;

namespace SIMA.SimaNetWeb.GestionComercial.ComunicacionImagen
{
	/// <summary>
	/// Summary description for ConsultarPresentesOtorgadosPorTipoPersona.
	/// </summary>
	public class ConsultarPresentesOtorgadosPorTipoPersona : System.Web.UI.Page,IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
		protected System.Web.UI.WebControls.DropDownList ddlbTipoPersona;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.ImageButton ibtnPresentesFamiliares;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;
		protected System.Web.UI.WebControls.Label lblTipoPersona;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminarFiltro;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hNombreClientePersonal;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdTablaOrigen;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdOrigen;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdCodigo;
		#endregion Controles

		#region Constantes
		//Ordenamiento
		const string COLORDENAMIENTO = "NombreClientePersonal";
		const int POSICIONINICIALCOMBO = 0;
		const int CantidadCero = 0;
		const int PosicionFooterTotalPersonal = 2;
		const int PosicionFooterTotalCliente = 5;

		//Columnas DataTable

		//Nombres de Controles		
		
		//Paginas
		const string URLIMPRESION = "PopupImpresionConsultarPresentesOtorgadosPorTipoPersona.aspx?";
		const string URLDETALLE = "ConsultarPresentesOtorgadosPorFamiliar.aspx?";
		const string URLDETALLEINDIVIDUAL = "DetallePresentesOtorgadosPorTipoPersona.aspx?";
	
		//Key Session y QueryString
		const string KEYQID = "Id";
		const string KEYQNOMBRE = "Nombre";
		const string KEYQIDTABLAORIGEN = "IdTablaOrigen";
		const string KEYQIDORIGEN = "IdOrigen";
		const string KEYQIDCODIGO = "IdCodigo";
		const string KEYQPOSICIONCOMBO = "KEYPOSICIONCOMBO";

		//Otros
		const string GRILLAVACIA ="No existe ningun Presente Otorgado con los filtros seleccionados.";
		const int ColumnaCentroOperativo = 2;
		const int ColumnaCargo = 3;
		const int ColumnaGrado = 4;
		const int ColumnaTelefono = 6;
		#endregion Constantes

		#region Variables
		#endregion Variables

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();

					Helper.ReiniciarSession();

					this.LlenarJScript();

					this.LlenarCombos();

					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se consultaron los Presentes Otorgados por Tipo de Persona del Tipo de Persona " + this.ddlbTipoPersona.SelectedItem.Text+ ".",Enumerados.NivelesErrorLog.I.ToString()));

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
					SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
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
			this.ddlbTipoPersona.SelectedIndexChanged += new System.EventHandler(this.ddlbTipoPersona_SelectedIndexChanged);
			this.ibtnFiltrar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnFiltrar_Click);
			this.ibtnEliminarFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminarFiltro_Click);
			this.ibtnImprimir.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnImprimir_Click);
			this.ibtnPresentesFamiliares.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnPresentesFamiliares_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add ConsultarPresentesOtorgadosPorTipoPersona.LlenarGrilla implementation
		}

		
		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarPresentesOtorgadosPorTipoPersona.LlenarGrillaOrdenamiento implementation
		}

		public DataTable ObtenerDatos()
		{
			CPresentesOtorgadosPorTipoPersona oCPresentesOtorgadosPorTipoPersona =  new CPresentesOtorgadosPorTipoPersona();
			return oCPresentesOtorgadosPorTipoPersona.ConsultarPresentesOtorgadosPorTipoDePersona(Convert.ToInt32(this.ddlbTipoPersona.SelectedItem.Value));
		}
        
		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
		{
			DataTable dtPresentesOtorgados = this.ObtenerDatos();
			
			if(dtPresentesOtorgados!=null)
			{
				//string CadenaBusqueda;
				DataView dwPresentesOtorgados = dtPresentesOtorgados.DefaultView;
				dwPresentesOtorgados.Sort = columnaOrdenar ;
				dwPresentesOtorgados.RowFilter = Utilitario.Helper.ObtenerFiltro(this);

				if(dwPresentesOtorgados.Count > CantidadCero)
				{
					grid.DataSource = dwPresentesOtorgados;
					lblResultado.Visible = false;
					
					this.VisualizarColumnas();
					
					if(this.ddlbTipoPersona.SelectedValue == Convert.ToInt32(Enumerados.TiposOrigenVistaEntidad.Cliente).ToString())
					{
						this.OcultarColumnasCliente();
						grid.Columns[PosicionFooterTotalCliente].FooterText = dwPresentesOtorgados.Count.ToString();
						grid.Columns[PosicionFooterTotalPersonal].FooterText = Constantes.VACIO;
					}
					else if(this.ddlbTipoPersona.SelectedValue == Convert.ToInt32(Enumerados.TiposOrigenVistaEntidad.Personal).ToString())
					{
						this.OcultarColumnasPersonal();
						grid.Columns[PosicionFooterTotalPersonal].FooterText = dwPresentesOtorgados.Count.ToString();
						grid.Columns[PosicionFooterTotalCliente].FooterText = Constantes.VACIO;
					}
					else if(this.ddlbTipoPersona.SelectedValue == Convert.ToInt32(Enumerados.TiposOrigenVistaEntidad.Visita).ToString())
					{
						this.OcultarColumnasPersonal();
						grid.Columns[PosicionFooterTotalPersonal].FooterText = dwPresentesOtorgados.Count.ToString();
						grid.Columns[PosicionFooterTotalCliente].FooterText = Constantes.VACIO;
					}
				}
				else
				{
					grid.DataSource = null;
					lblResultado.Visible = true;
					lblResultado.Text = GRILLAVACIA;
				}
				CImpresion oCImpresion = new CImpresion();
				oCImpresion.GuardarDataImprimirExportar(dwPresentesOtorgados.Table,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGOTITULOREPORTEPRESENTESOTORGADOSTIPOPERSONA),columnaOrdenar,indicePagina);
			}
			else
			{
				grid.DataSource = dtPresentesOtorgados;
				lblResultado.Visible = true;
				lblResultado.Text = GRILLAVACIA;
			}
			try
			{
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
			this.llenarTiposPersona();
		}

		public void LlenarDatos()
		{
			// TODO:  Add ConsultarPresentesOtorgadosPorTipoPersona.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			this.ibtnPresentesFamiliares.Attributes.Add(Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);

			ibtnPresentesFamiliares.Attributes.Add(Constantes.EVENTOMOUSEDOWN, Helper.HistorialIrAdelantePersonalizado(Utilitario.Constantes.VACIO));
			ibtnPresentesFamiliares.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, Utilitario.Constantes.POPUPDEESPERA);
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarPresentesOtorgadosPorTipoPersona.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			ltlMensaje.Text = Helper.PopupImpresion(URLIMPRESION + KEYQPOSICIONCOMBO + Constantes.SIGNOIGUAL + this.ddlbTipoPersona.SelectedValue,750,500,false,false,false,true,true);
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarPresentesOtorgadosPorTipoPersona.Exportar implementation
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
			if(this.ddlbTipoPersona.SelectedItem.Text == Utilitario.Constantes.TEXTOSSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEPRESENTESOTORGADOSTIPOPERSONACAMPOREQUERIDOTIPOPERSONA));
				return false;
			}
			else
			{
				return true;
			}
		}

		#endregion

		/// <summary>
		/// Llena el combo de Tipos de Persona
		/// </summary>
		private void llenarTiposPersona()
		{
			ListItem lItem1 = new ListItem(Enumerados.TiposOrigenVistaEntidad.Cliente.ToString(),Convert.ToInt32(Enumerados.TiposOrigenVistaEntidad.Cliente).ToString());
			ListItem lItem2 = new ListItem(Enumerados.TiposOrigenVistaEntidad.Personal.ToString(),Convert.ToInt32(Enumerados.TiposOrigenVistaEntidad.Personal).ToString());
			ListItem lItem3 = new ListItem(Enumerados.TiposOrigenVistaEntidad.Visita.ToString(),Convert.ToInt32(Enumerados.TiposOrigenVistaEntidad.Visita).ToString());
			ddlbTipoPersona.Items.Insert(POSICIONINICIALCOMBO,lItem1);
			ddlbTipoPersona.Items.Insert(POSICIONINICIALCOMBO+1,lItem2);
			ddlbTipoPersona.Items.Insert(POSICIONINICIALCOMBO+2,lItem3);
			ddlbTipoPersona.DataBind();
			if(HttpContext.Current.Session[KEYQPOSICIONCOMBO] != null)
			{
				this.ddlbTipoPersona.Items.FindByValue(HttpContext.Current.Session[KEYQPOSICIONCOMBO].ToString()).Selected = true;
			}
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(e.SortExpression),Helper.ObtenerIndicePagina());
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			grid.CurrentPageIndex=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);
		}

		private void ibtnImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Imprimir();
		}

		private void ibtnPresentesFamiliares_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if(hCodigo.Value.Length==0)
			{
				ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO));
			}
			else
			{
				Page.Response.Redirect(URLDETALLE +
					KEYQNOMBRE + Utilitario.Constantes.SIGNOIGUAL + this.hNombreClientePersonal.Value + Utilitario.Constantes.SIGNOAMPERSON +
					KEYQIDTABLAORIGEN + Utilitario.Constantes.SIGNOIGUAL + this.hIdTablaOrigen.Value + Utilitario.Constantes.SIGNOAMPERSON +
					KEYQIDORIGEN + Utilitario.Constantes.SIGNOIGUAL + this.hIdOrigen.Value + Utilitario.Constantes.SIGNOAMPERSON +
					KEYQIDCODIGO + Utilitario.Constantes.SIGNOIGUAL + this.hIdCodigo.Value
					);
			}
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				e.Item.Cells[Constantes.POSICIONCONTADOR].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);

				e.Item.Cells[Constantes.POSICIONCONTADOR].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.MostrarVentana(URLDETALLEINDIVIDUAL,KEYQID+ Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr[Enumerados.ColumnasPresentesOtorgadosPorTipoPersona.IdListaProtocolar.ToString()]) +  Utilitario.Constantes.SIGNOAMPERSON + 
					Utilitario.Constantes.KEYMODOPAGINA +  Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.C.ToString()));
	
				e.Item.Cells[Constantes.POSICIONCONTADOR].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				e.Item.Cells[Constantes.POSICIONCONTADOR].Font.Underline=true;
				e.Item.Cells[Constantes.POSICIONCONTADOR].ForeColor = System.Drawing.Color.Blue;

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,
					Utilitario.Helper.MostrarDatosEnCajaTexto("hCodigo",dr[Enumerados.ColumnasPresentesOtorgadosPorTipoPersona.IdListaProtocolar.ToString()].ToString()),
					Utilitario.Helper.MostrarDatosEnCajaTexto("hNombreClientePersonal",dr[Enumerados.ColumnasPresentesOtorgadosPorTipoPersona.NombreClientePersonal.ToString()].ToString().Replace(Constantes.SIGNOMENOR,Constantes.SIGNOABREPARANTESIS).Replace(Constantes.SIGNOMAYOR,Constantes.SIGNOCIERRAPARANTESIS)),
					Utilitario.Helper.MostrarDatosEnCajaTexto("hIdTablaOrigen",dr[Enumerados.ColumnasPresentesOtorgadosPorTipoPersona.IdTablaOrigen.ToString()].ToString()),
					Utilitario.Helper.MostrarDatosEnCajaTexto("hIdOrigen",dr[Enumerados.ColumnasPresentesOtorgadosPorTipoPersona.IdOrigen.ToString()].ToString()),
					Utilitario.Helper.MostrarDatosEnCajaTexto("hIdCodigo",dr[Enumerados.ColumnasPresentesOtorgadosPorTipoPersona.IdCodigo.ToString()].ToString())
					);
				Helper.FiltroporSeleccionConfiguraColumna(e,grid);
			}
		}

		private void ibtnFiltrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if(this.ValidarFiltros())
			{
				if(this.ddlbTipoPersona.SelectedItem.Value == Convert.ToInt32(Enumerados.TiposOrigenVistaEntidad.Cliente).ToString())
				{
					ltlMensaje.Text= Utilitario.Helper.ElaborarFiltro(this.ObtenerDatos()
						,Constantes.SIGNOASTERISCO + Utilitario.Enumerados.ColumnasPresentesOtorgadosPorTipoPersona.NombreCentroOperativo.ToString()+";Centro Operativo"
						,Utilitario.Enumerados.ColumnasPresentesOtorgadosPorTipoPersona.Cargo.ToString()+ ";Cargo"
						,Utilitario.Enumerados.ColumnasPresentesOtorgadosPorTipoPersona.Grado.ToString()+ ";Grado"
						,Utilitario.Enumerados.ColumnasPresentesOtorgadosPorTipoPersona.NombreClientePersonal.ToString()+ ";Nombre Cliente"
						,Utilitario.Enumerados.ColumnasPresentesOtorgadosPorTipoPersona.Telefono.ToString()+ ";Telefono"
						,Constantes.SIGNOASTERISCO + Utilitario.Enumerados.ColumnasPresentesOtorgadosPorTipoPersona.NombreArticulo.ToString()+ ";Articulo"
						,Utilitario.Enumerados.ColumnasPresentesOtorgadosPorTipoPersona.CantidadAtendida.ToString()+ ";Cantidad"
						);
				}
				else
				{
					ltlMensaje.Text= Utilitario.Helper.ElaborarFiltro(this.ObtenerDatos()
						,Constantes.SIGNOASTERISCO + Utilitario.Enumerados.ColumnasPresentesOtorgadosPorTipoPersona.NombreCentroOperativo.ToString()+";Centro Operativo"
						,Constantes.SIGNOASTERISCO + Utilitario.Enumerados.ColumnasPresentesOtorgadosPorTipoPersona.Cargo.ToString()+ ";Cargo"
						,Constantes.SIGNOASTERISCO + Utilitario.Enumerados.ColumnasPresentesOtorgadosPorTipoPersona.Grado.ToString()+ ";Grado"
						,Utilitario.Enumerados.ColumnasPresentesOtorgadosPorTipoPersona.NombreClientePersonal.ToString()+ ";Nombre Personal"
						,Utilitario.Enumerados.ColumnasPresentesOtorgadosPorTipoPersona.Telefono.ToString()+ ";Telefono"
						,Constantes.SIGNOASTERISCO + Utilitario.Enumerados.ColumnasPresentesOtorgadosPorTipoPersona.NombreArticulo.ToString()+ ";Articulo"
						,Utilitario.Enumerados.ColumnasPresentesOtorgadosPorTipoPersona.CantidadAtendida.ToString()+ ";Cantidad"
						);
				}
			}
		}

		private void ibtnEliminarFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}

		private void ddlbTipoPersona_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Session[KEYQPOSICIONCOMBO] = this.ddlbTipoPersona.SelectedValue;

			Helper.EliminarFiltro();

			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se consultaron los Presentes Otorgados por Tipo de Persona del Tipo de Persona " + this.ddlbTipoPersona.SelectedItem.Text+ ".",Enumerados.NivelesErrorLog.I.ToString()));

			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO),Utilitario.Constantes.INDICEPAGINADEFAULT);
		}

		private void VisualizarColumnas()
		{
			grid.Columns[ColumnaCentroOperativo].Visible = true;
			grid.Columns[ColumnaCargo].Visible = true;
			grid.Columns[ColumnaGrado].Visible = true;
			grid.Columns[ColumnaTelefono].Visible = true;
		}

		private void OcultarColumnasCliente()
		{
			grid.Columns[ColumnaCentroOperativo].Visible = false;
			grid.Columns[ColumnaCargo].Visible = false;
			grid.Columns[ColumnaGrado].Visible = false;
		}

		private void OcultarColumnasPersonal()
		{
			grid.Columns[ColumnaTelefono].Visible = false;
		}
	}
}