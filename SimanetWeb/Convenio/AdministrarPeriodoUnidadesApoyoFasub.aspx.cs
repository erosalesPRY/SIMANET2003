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
using SIMA.Controladoras.Convenio;
using SIMA.Controladoras;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using NullableTypes;
using MetaBuilders.WebControls;


namespace SIMA.SimaNetWeb.Convenio
{
	/// <summary>
	/// Aquí se mantienen los Periodos por cada Unidad de Apoyo Seleccionado en AdministracionUnidadesApoyo.aspx
	/// Este formulario ya paso por Refactory
	/// </summary>
	public class AdministrarPeriodoUnidadesApoyoFasub : System.Web.UI.Page, IPaginaBase, IPaginaMantenimento
	{
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
			this.ibtnProyectos.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnProyectos_Click);
			this.btnAgregarPeriodo.Click += new System.Web.UI.ImageClickEventHandler(this.btnAgregarPeriodo_Click);
			this.btnAnularPeriodo.Click += new System.Web.UI.ImageClickEventHandler(this.btnAnularPeriodo_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		#region IPaginaMantenimento Members
		public void Agregar()
		{}

		public void Modificar()
		{}

		public void Eliminar()
		{
			if(Convert.ToInt32(hIdPeriodoApoyoFasub.Value)==Utilitario.Constantes.ValorConstanteCero)
			{
				ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionConvenioUsuario(Mensajes.CODIGOMENSAJEUNIDADAPOYOELIMINAR));
			}
			else
			{
				CPeriodoApoyoFasub oCPeriodoApoyoFasub = new CPeriodoApoyoFasub();
				
				if(oCPeriodoApoyoFasub.Eliminar(Convert.ToInt32(hIdPeriodoApoyoFasub.Value),Convert.ToInt32(hIdUnidadApoyo.Value),CNetAccessControl.GetIdUser())>0)
				{
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Convenio",this.ToString(),MENSAJEELIMINAR + hCodigo.Value + Utilitario.Constantes.SIMBOLOPUNTO ,Enumerados.NivelesErrorLog.I.ToString()));
					ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionConvenios.ToString(),Mensajes.CODIGOMENSAJEPERIODOAPOYOFASUBELIMINACION), URLADMINISTRARPERIODOUNIDADESAPOYOFASUB + KEYIDUNIDADAPOYO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDUNIDADAPOYO].ToString());
					this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),Helper.ObtenerIndicePagina());
				}
			}
		}

		public void CargarModoPagina()
		{
			
		}

		public void CargarModoNuevo()
		{}

		public void CargarModoModificar()
		{}

		public void CargarModoConsulta()
		{}

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
		#region IPaginaBase Members
		public void LlenarGrilla()
		{}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{

			CPeriodoApoyoFasub oCPeriodoApoyoFasub = new CPeriodoApoyoFasub();
			DataTable dtPeriodo = oCPeriodoApoyoFasub.ListarPeriodosPeriodoApoyoFasubSinMontos(Convert.ToInt32(Page.Request.Params[KEYIDUNIDADAPOYO]));
			
			dtPeriodo=oCPeriodoApoyoFasub.ListarPeriodosPeriodoApoyoFasubSinMontos(Convert.ToInt32(Page.Request.Params[KEYIDUNIDADAPOYO]));

			if(dtPeriodo!=null)
			{
				DataView dwPeriodo = dtPeriodo.DefaultView;
				dwPeriodo.Sort = COLORDENAMIENTO;
				dwPeriodo.RowFilter = Utilitario.Helper.ObtenerFiltro(this);

				if(dwPeriodo.Count == 0)
				{
					grid.DataSource = null;
					lblResultado.Text = GRILLAVACIA;
					lblResultado.Visible=true;
				}
				else
				{
					grid.DataSource = dtPeriodo;
					grid.Columns[2].FooterText = dwPeriodo.Count.ToString();
					grid.CurrentPageIndex = indicePagina;
					lblResultado.Visible=false;

				}
			}
			else
			{
				grid.DataSource = dtPeriodo;
				lblResultado.Text = GRILLAVACIA;
				lblResultado.Visible = true;
			}

			try
			{
				grid.CurrentPageIndex = indicePagina;
				grid.DataBind();
			}
			catch(Exception e)
			{
				string a = e.Message;
				grid.CurrentPageIndex = 0;
				grid.DataBind();
			}
		}

		public void LlenarCombos()
		{}

		public void LlenarDatos()
		{}

		public void LlenarJScript()
		{
			btnAnularPeriodo.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,JSVERIFICARSELECCIONFILA);
			btnAnularPeriodo.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, JSVERIFICARELIMINAR);
			this.ibtnProyectos.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,JSVERIFICARSELECCIONFILA);
			this.ibtnProyectos.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
		}

		public void RegistrarJScript()
		{}

		public void Imprimir()
		{}

		public void Exportar()
		{}

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
			return false;
		}

		#endregion
		#region Constantes
		//Jscrpt
		private string JSVERIFICARELIMINAR = "return verificarEliminarRb('hIdUnidadApoyo','" + Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO)+"','"+Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJEPREGUNTAELIMINACIONREGISTRO)+"');";
		string JSVERIFICARSELECCIONFILA="return verificarSeleccionRb('hIdPeriodoApoyoFasub','"+ Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO) + "');";

		//Indices
		private const string COLORDENAMIENTO = "Periodo";

		//Mensajes
		private const string GRILLAVACIA="NO HAY REGISTROS";
		private const string MENSAJEELIMINAR="Se elimino el periodo Nro. ";

		//URL's
		private const string URLDETALLEPERIODOUNIDADESAPOYOFASUB = "DetallePeriodoApoyoFasub.aspx?";
		private const string URLADMINISTRARPERIODOUNIDADESAPOYOFASUB = "AdministrarPeriodoUnidadesApoyoFasub.aspx?";
		private const string URLPROYECTOSPERIODOUNIDADESAPOYOFASUB = "AdministrarUnidadesSubmarinas.aspx?";

		//Key Session y QueryString
		private const string KEYIDPERIODOUNIDADESAPOYOFASUB ="IdPeriodoApoyoFasub";
		private const string KEYIDUNIDADAPOYO="IdUnidadApoyo";
		private const string KEYQPERIODO = "Periodo";
		private const string KEYIDCENTROOPERATIVO = "IdCentroOperativo";
		private const string KEYIDESTADO = "IdEstado";
		private const string KEYQID="IdUnidadApoyo";

		//Filtros
		private const string FILTROPERIODO=";Periodo";
		private const string FILTRODESCRIPCION=";Descripcion";
		#endregion
		#region Controles
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblSubTitulo;
		protected System.Web.UI.WebControls.ImageButton ibtnProyectos;
		protected System.Web.UI.WebControls.ImageButton btnAgregarPeriodo;
		protected System.Web.UI.WebControls.ImageButton btnAnularPeriodo;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.TextBox txtObservaciones;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdPeriodoApoyoFasub;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hPeriodo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdUnidadApoyo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label lblObservaciones;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hOrdenGrilla;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminarFiltro;
		#endregion
		#region Variables
		private int PIDCENTROOPERATIVO = Convert.ToInt32(Utilitario.Enumerados.IdCentroOperativo.SimaCallao);
		private int NROREGISTROS=0;
		#endregion
		#region Eventos
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarJScript();
					this.ReiniciarControles();
					this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO,false),Utilitario.Constantes.INDICEPAGINADEFAULT);
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

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				
				e.Item.Cells[Utilitario.Constantes.POSICIONCONTADOR].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
		
				e.Item.Cells[Utilitario.Constantes.POSICIONCONTADOR].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
				e.Item.Cells[Utilitario.Constantes.POSICIONCONTADOR].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.MostrarVentana(URLDETALLEPERIODOUNIDADESAPOYOFASUB ,KEYIDPERIODOUNIDADESAPOYOFASUB + Utilitario.Constantes.SIGNOIGUAL + dr[Enumerados.ColumnasPeriodoUnidadesApoyoFasub.IdPeriodoApoyoFasub.ToString()] + Utilitario.Constantes.SIGNOAMPERSON + KEYIDUNIDADAPOYO + Utilitario.Constantes.SIGNOIGUAL + dr[Enumerados.ColumnasPeriodoUnidadesApoyoFasub.IdUnidadApoyo.ToString()] +  Utilitario.Constantes.SIGNOAMPERSON + 
					Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Enumerados.ModoPagina.M));

				e.Item.Cells[Utilitario.Constantes.POSICIONCONTADOR].Font.Underline = true;
				e.Item.Cells[0].ForeColor=Color.Blue;

				string Cadena = "AccionSeleccionFila('hIdPeriodoApoyoFasub','" + Convert.ToString(dr[Utilitario.Enumerados.ColumnasPeriodoUnidadesApoyoFasub.IdPeriodoApoyoFasub.ToString()]) + "'); " +
					"AccionSeleccionFila('hIdUnidadApoyo','" +Convert.ToString(dr[Utilitario.Enumerados.ColumnasPeriodoUnidadesApoyoFasub.IdUnidadApoyo.ToString()]) + "'); " +
					"AccionSeleccionFila('hPeriodo','" + Convert.ToString(dr[Utilitario.Enumerados.ColumnasPeriodoUnidadesApoyoFasub.Periodo.ToString()]) + "'); " +
					" MostrarDatosEnCajaTexto('txtObservaciones','" + Helper.LimpiarTexto(dr[Utilitario.Enumerados.ColumnasPeriodoUnidadesApoyoFasub.Observaciones.ToString()].ToString()) + "');";
			 	
				Utilitario.Helper.SeleccionarItemGrillaOnClickMoverRaton(e,Cadena);
				Helper.FiltroporSeleccionConfiguraColumna(e,grid);
				NROREGISTROS+=1;
			}
		
		}

		private void ibtnProyectos_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if(!NullableString.Parse(this.hIdPeriodoApoyoFasub.Value).IsNull)
			{
				this.Page.Response.Redirect(URLPROYECTOSPERIODOUNIDADESAPOYOFASUB + KEYIDPERIODOUNIDADESAPOYOFASUB + Utilitario.Constantes.SIGNOIGUAL + this.hIdPeriodoApoyoFasub.Value + Utilitario.Constantes.SIGNOAMPERSON + 
					KEYQPERIODO + Utilitario.Constantes.SIGNOIGUAL + this.hPeriodo.Value + Utilitario.Constantes.SIGNOAMPERSON + 
					KEYIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + this.PIDCENTROOPERATIVO.ToString() + Utilitario.Constantes.SIGNOAMPERSON +
					KEYIDUNIDADAPOYO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDUNIDADAPOYO].ToString());
			}
			else
			{
				this.ltlMensaje.Text=Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO));
			}
		}

		private void ReiniciarControles()
		{
			this.hIdPeriodoApoyoFasub.Value = "";
			this.hPeriodo.Value = "";
			this.txtObservaciones.Text = "";
		}

		private void btnConsultar_Click(object sender, System.EventArgs e)
		{
			Helper.ReiniciarSession();
			this.ReiniciarControles();
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO,false),Utilitario.Constantes.INDICEPAGINADEFAULT);
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.grid.CurrentPageIndex=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.hOrdenGrilla.Value = Helper.GenerarExpresionOrdenamiento(e.SortExpression);
			this.LlenarGrillaOrdenamientoPaginacion(this.hOrdenGrilla.Value,Helper.ObtenerIndicePagina());
		}

		private void AgregarPeriodo()
		{
			Response.Redirect(URLDETALLEPERIODOUNIDADESAPOYOFASUB + Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Enumerados.ModoPagina.N + Utilitario.Constantes.SIGNOAMPERSON +  KEYIDUNIDADAPOYO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDUNIDADAPOYO]);
		}

		private void btnAgregarPeriodo_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.AgregarPeriodo();
		}

		private void btnAnularPeriodo_Click(object sender, System.Web.UI.ImageClickEventArgs e)
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

		private void ibtnFiltrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			CPeriodoApoyoFasub oCPeriodoApoyoFasub = new CPeriodoApoyoFasub();
			DataTable dtPeriodoApoyoFasub = oCPeriodoApoyoFasub.ListarPeriodosPeriodoApoyoFasubSinMontos(Convert.ToInt32(Page.Request.Params[KEYIDUNIDADAPOYO]));

			ltlMensaje.Text = Utilitario.Helper.ElaborarFiltro(dtPeriodoApoyoFasub
				,Enumerados.ColumnasPeriodoUnidadesApoyoFasub.Periodo.ToString()+ FILTROPERIODO 
				,Enumerados.ColumnasPeriodoUnidadesApoyoFasub.Descripcion.ToString()+FILTRODESCRIPCION );
		
		}

		private void ibtnEliminarFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}

		#endregion

		#region Comentarios
		/*
		private string SeleccionPeriodoInicial(int pPeriodoInicial)
		{
			int SeleccionPeriodoInicial;
			if((DateTime.Now.Year-4)<=pPeriodoInicial)
			{
				SeleccionPeriodoInicial=pPeriodoInicial;
			}
			else
			{
				SeleccionPeriodoInicial=DateTime.Now.Year-4;
			}

			return SeleccionPeriodoInicial.ToString();
		}
		*/
		#endregion
	}
}
