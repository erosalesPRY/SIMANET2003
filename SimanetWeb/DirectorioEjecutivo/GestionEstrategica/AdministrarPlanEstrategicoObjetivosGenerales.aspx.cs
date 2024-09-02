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
using SIMA.Controladoras.GestionEstrategica;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using SIMA.Controladoras;
using SIMA.Controladoras.General;

namespace SIMA.SimaNetWeb.DirectorioEjecutivo.GestionEstrategica
{
	public class AdministrarPlanEstrategicoObjetivosGenerales : System.Web.UI.Page, IPaginaBase
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
			this.dllVisibilidad.SelectedIndexChanged += new System.EventHandler(this.dllVisibilidad_SelectedIndexChanged);
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
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
		}

		public DataTable ObtenerDatos()
		{
			CObjetivoGeneral oCObjetivoGeneral =  new CObjetivoGeneral();
			DataTable dtOGeneral;
			
			int idVersion = Convert.ToInt32(Page.Request.QueryString[KEYIDVERSION]);

			if (Page.Request.QueryString[KEYQFILTRO] == null)
				dtOGeneral =  oCObjetivoGeneral.ListarObjetivoGeneralesPlanEstrategico(Convert.ToInt32(dllVisibilidad.SelectedValue.ToString()),idVersion);
			else
			{
				dllVisibilidad.SelectedValue = Page.Request.QueryString[KEYQFILTRO];
				dtOGeneral =  oCObjetivoGeneral.ListarObjetivoGeneralesPlanEstrategico(Convert.ToInt32(Page.Request.QueryString[KEYQFILTRO]),Helper.FechaSimanet.ObtenerFechaSesion().Year ,idVersion);
			}

			return dtOGeneral;
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dtOGeneral = this.ObtenerDatos();
		
			if(dtOGeneral != null)
			{
				DataView dwOGeneral = dtOGeneral.DefaultView;
				dwOGeneral.Sort = columnaOrdenar ;
				dwOGeneral.RowFilter = Utilitario.Helper.ObtenerFiltro(this);

				if(dwOGeneral.Count > Utilitario.Constantes.INDICEPAGINADEFAULT)
				{
					grid.DataSource = dwOGeneral;
					grid.Columns[COLUMNANUMERACION].FooterText = TEXTOFOOTERTOTAL;
					grid.Columns[POSICIONFOOTERTOTAL].FooterText = dwOGeneral.Count.ToString();
					lblResultado.Visible = false;
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
				grid.DataSource = dtOGeneral;
				lblResultado.Visible = true;
				lblResultado.Text = GRILLAVACIA;
			}
			
			try
			{
				grid.DataBind();
			}
			catch(Exception ex)
			{
				string a = ex.Message;
				grid.CurrentPageIndex = 0;
				grid.DataBind();
			}
		}

		public void LlenarCombos()
		{
			CTablaTablas oCTablaTablas =  new CTablaTablas();		
			dllVisibilidad.DataSource = oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Enumerados.TablasTabla.NivelesVisibilidad));
			dllVisibilidad.DataValueField = Enumerados.ColumnasTablasTablas.Codigo.ToString();
			dllVisibilidad.DataTextField = Enumerados.ColumnasTablasTablas.Descripcion.ToString();
			dllVisibilidad.DataBind();
		}

		public void LlenarDatos()
		{
		}

		public void LlenarJScript()
		{
			this.ibtnEliminar.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,JSVERIFICARELIMINAR);
			this.ibtnAgregar.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
		}
		public void RegistrarJScript()
		{
		}

		public void Imprimir()
		{
		}

		public void Exportar()
		{
		}

		public void ConfigurarAccesoControles()
		{
			if(CNetAccessControl.FindPage(Page.Request.Url.AbsolutePath.ToString()))
				CNetAccessControl.LoadControls(this);
			else
				CNetAccessControl.RedirectPageError();
		}

		public bool ValidarFiltros()
		{
			return false;
		}

		#endregion
		#region Constantes
		//QueryString
		const string KEYIDVERSION="KEYIDVERSION";
		const string KEYCODIGOGENERADO="KEYCODIGOGENERADO";
		const string KEYQFILTRO = "IDVISIBILIDAD";
		const string KEYQIDOGENERAL = "IDOGENERALES";
		const string KEYOGENERALTEXTO = "DESCRIPCION";
		const string PE = "PlanEstrategico";

		//Paginas
		const string URLADMINISTRACIONESTRATEGICOOBJETIVOSESPECIFICOS = "../PlanGestion/AdministrarObjetivoEspecifico.aspx?";
		const string URLDETALLE = "DetallePlanEstrategicoObjetivosGenerales.aspx?";
		
		//Ordenamiento
		const string COLORDENAMIENTO = "IDOGENERALES ASC";
		const int COLUMNANUMERACION = 0;
		const int COLUMNADETALLEOGENERALES= 2;
		const int POSICIONFOOTERTOTAL = 1;

		//JScript
		string JSVERIFICARELIMINAR = "return verificarEliminarRb('hcodigo','" + Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO)+"','"+Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJEPREGUNTAELIMINACIONREGISTRO)+"');";
		
		//OTROS
		const string TEXTOFOOTERTOTAL = "Total:";
		const string GRILLAVACIA ="No existe ningun Objetivo General.";
		const string MENSAJEELIMINAR="Se elimino la actividad Nro. ";
		const string MENSAJESELECCIONAR="Tiene que seleccionar un registro";
		#endregion
		#region Controles
		protected System.Web.UI.WebControls.Label lblPeriodo;
		protected System.Web.UI.WebControls.DropDownList dllVisibilidad;
		protected System.Web.UI.WebControls.ImageButton ibtnAgregar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminar;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hcodigo;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion
		#region Variables
		#endregion
		#region Eventos
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.LlenarCombos();
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarJScript();
					this.LlenarGrillaOrdenamientoPaginacion(COLORDENAMIENTO,Utilitario.Constantes.INDICEPAGINADEFAULT);
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Estrategica",this.ToString(),"Se consultaron los Objetivos Especificos del Plan Estrategico.",Enumerados.NivelesErrorLog.I.ToString()));
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

				e.Item.Cells[COLUMNANUMERACION].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Constantes.HISTORIALADELANTE);
				
				e.Item.Cells[COLUMNANUMERACION].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				e.Item.Cells[COLUMNANUMERACION].Font.Underline = true;
				e.Item.Cells[COLUMNANUMERACION].ForeColor= System.Drawing.Color.Blue;
		
				e.Item.Cells[1].Text = "OG" + e.Item.Cells[COLUMNANUMERACION].Text;
				e.Item.Cells[1].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado("dllVisibilidad"));
				e.Item.Cells[1].Font.Underline = true;
				e.Item.Cells[1].ForeColor= System.Drawing.Color.Blue;

				if(Page.Request.QueryString[KEYIDVERSION] == null)
				{
					e.Item.Cells[COLUMNANUMERACION].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
						Helper.MostrarVentana(URLADMINISTRACIONESTRATEGICOOBJETIVOSESPECIFICOS, 
						KEYQFILTRO + Utilitario.Constantes.SIGNOIGUAL + dllVisibilidad.SelectedValue.ToString() +
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYQIDOGENERAL + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr[Utilitario.Enumerados.ColumnasObjetivosGenerales.IDOGENERALES.ToString()]) +
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYOGENERALTEXTO + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr[Utilitario.Enumerados.ColumnasObjetivosGenerales.DESCRIPCION.ToString()]) +
						Utilitario.Constantes.SIGNOAMPERSON +
						PE + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt32(Page.Request.QueryString[Utilitario.Enumerados.OpcionModuloGestionEstrategica.PlanEstrategico.ToString()])+
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYCODIGOGENERADO + Utilitario.Constantes.SIGNOIGUAL + e.Item.Cells[COLUMNANUMERACION].Text 
						));

					e.Item.Cells[1].Attributes.Add(Utilitario.Constantes.EVENTOCLICK, 
						Helper.MostrarVentana(URLDETALLE,
						KEYQFILTRO + Utilitario.Constantes.SIGNOIGUAL + dllVisibilidad.SelectedValue.ToString() +
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYQIDOGENERAL + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr[Utilitario.Enumerados.ColumnasObjetivosGenerales.IDOGENERALES.ToString()]) +
						Utilitario.Constantes.SIGNOAMPERSON +
						Utilitario.Constantes.KEYMODOPAGINA +  Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.M.ToString()));
				}
				else
				{
					e.Item.Cells[COLUMNANUMERACION].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
						Helper.MostrarVentana(URLADMINISTRACIONESTRATEGICOOBJETIVOSESPECIFICOS, 
						KEYQFILTRO + Utilitario.Constantes.SIGNOIGUAL + dllVisibilidad.SelectedValue.ToString() +
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYQIDOGENERAL + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr[Utilitario.Enumerados.ColumnasObjetivosGenerales.IDOGENERALES.ToString()]) +
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYOGENERALTEXTO + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr[Utilitario.Enumerados.ColumnasObjetivosGenerales.DESCRIPCION.ToString()]) +
						Utilitario.Constantes.SIGNOAMPERSON +
						PE + Utilitario.Constantes.SIGNOIGUAL + 2 +
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYIDVERSION + Utilitario.Constantes.SIGNOIGUAL +
						Page.Request.QueryString[KEYIDVERSION]+
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYCODIGOGENERADO + Utilitario.Constantes.SIGNOIGUAL + e.Item.Cells[COLUMNANUMERACION].Text 
						));

					e.Item.Cells[1].Attributes.Add(Utilitario.Constantes.EVENTOCLICK, 
						Helper.MostrarVentana(URLDETALLE,
						KEYQFILTRO + Utilitario.Constantes.SIGNOIGUAL + dllVisibilidad.SelectedValue.ToString() +
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYQIDOGENERAL + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr[Utilitario.Enumerados.ColumnasObjetivosGenerales.IDOGENERALES.ToString()]) +
						Utilitario.Constantes.SIGNOAMPERSON +
						Utilitario.Constantes.KEYMODOPAGINA +  Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.M.ToString() + 
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYIDVERSION + Utilitario.Constantes.SIGNOIGUAL +
						Page.Request.QueryString[KEYIDVERSION]
						));
				}

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,Utilitario.Helper.MostrarDatosEnCajaTexto("hcodigo",dr[Enumerados.ColumnasObjetivosGenerales.IDOGENERALES.ToString()].ToString()));
				Helper.FiltroporSeleccionConfiguraColumna(e,grid);
			}
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

		private void ibtnAgregar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if (Page.Request.QueryString[KEYIDVERSION] != null)
				Page.Response.Redirect(URLDETALLE + Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.N.ToString() + 
					Utilitario.Constantes.SIGNOAMPERSON +
					KEYIDVERSION + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYIDVERSION]);
			else
				Page.Response.Redirect(URLDETALLE + Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.N.ToString());
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

		private void dllVisibilidad_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(COLORDENAMIENTO,Utilitario.Constantes.INDICEPAGINADEFAULT);
		}
		
		private void eliminar()
		{
			if(hcodigo.Value.Length==Utilitario.Constantes.ValorConstanteCero)
			{
				ltlMensaje.Text = Helper.MensajeAlert(MENSAJESELECCIONAR);
			}
			else
			{
				CMantenimientos oCMantenimientos = new CMantenimientos();

				if(oCMantenimientos.Eliminar(Convert.ToInt32(hcodigo.Value),CNetAccessControl.GetIdUser(),Utilitario.Enumerados.ClasesTAD.ObjetivosGeneralesTAD.ToString())>Utilitario.Constantes.ValorConstanteCero)
				{
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Utilitario.Enumerados.NombresdeModulo.GestionEstratégica.ToString(),this.ToString(),MENSAJEELIMINAR + hcodigo.Value + Utilitario.Constantes.SIMBOLOPUNTO,Enumerados.NivelesErrorLog.I.ToString()));
					ltlMensaje.Text = Helper.MensajeAlert("Se elimino el registro");
					this.LlenarGrillaOrdenamientoPaginacion(COLORDENAMIENTO,Utilitario.Constantes.INDICEPAGINADEFAULT);
					hcodigo.Value = String.Empty;
				}
			}
		}

	}
}
