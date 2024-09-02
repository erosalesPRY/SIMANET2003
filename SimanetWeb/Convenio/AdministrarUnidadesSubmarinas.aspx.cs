using NullableTypes;
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
using MetaBuilders.WebControls;
using System.Diagnostics; 
using System.IO;
using SIMA.EntidadesNegocio.Convenio;

namespace SIMA.SimaNetWeb.Convenio
{
	/// <summary>
	/// Aquí se administran los proyectos de las Unidades de Apoyo, ademáas de administrar los fondos para los
	/// los proyectos
	/// Este formulario ya paso Refactory
	/// </summary>
	public class AdministrarUnidadesSubmarinas : System.Web.UI.Page, IPaginaBase, IPaginaMantenimento
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
			this.ibtnAgregar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAgregar_Click);
			this.ibtnEliminar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminar_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.ibtnAgregarFondo.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAgregarFondo_Click);
			this.ibtnEliminarFondo.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminarFondo_Click);
			this.gridAsignado.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.gridAsignado_SortCommand);
			this.gridAsignado.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.gridAsignado_PageIndexChanged);
			this.gridAsignado.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.gridAsignado_ItemDataBound);
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
			if(hCodigo.Value.Length==Utilitario.Constantes.ValorConstanteCero)
			{
				ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionConvenioUsuario(Mensajes.CODIGOMENSAJEPROYECTOELIMINACION));
			}
			else
			{
				CMantenimientos oCMantenimientos = new CMantenimientos();

				if(oCMantenimientos.Eliminar(Convert.ToInt32(hCodigo.Value),CNetAccessControl.GetIdUser(),Enumerados.ClasesTAD.ProyectoSubmarinoTAD.ToString())>Utilitario.Constantes.ValorConstanteCero)
				{
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Utilitario.Enumerados.NombresdeModulo.ConveniosyProyectos.ToString() ,this.ToString(),MENSAJEELIMINAR + hCodigo.Value + Utilitario.Constantes.SIMBOLOPUNTO.ToString() ,Enumerados.NivelesErrorLog.I.ToString()));
					ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionConvenios.ToString(),Mensajes.CODIGOMENSAJEUNIDADAPOYOELIMINAR), URLADMINISTRACION + KEYIDPERIODOAPOYOFASUB + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYIDPERIODOAPOYOFASUB]
					+ Utilitario.Constantes.SIGNOAMPERSON + KEYQPERIODO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQPERIODO] + Utilitario.Constantes.SIGNOAMPERSON  + KEYIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYIDCENTROOPERATIVO] + Utilitario.Constantes.SIGNOAMPERSON 
					+ KEYIDUNIDADAPOYO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYIDUNIDADAPOYO]);
					this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),Helper.ObtenerIndicePagina());
				}
			}
		}
		public void CargarModoPagina()
		{}

		public void CargarModoNuevo()
		{}

		public void CargarModoModificar()
		{}

		public void CargarModoConsulta()
		{}

		public bool ValidarCampos()
		{
			return true;
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
			int IdTipoRegistro = Convert.ToInt32(Utilitario.Enumerados.ApoyoUnidadSubMarinoTipoProyectos.Proyecto);
			CApoyoUnidadSubMarina oCApoyoUnidadSubMarina=new CApoyoUnidadSubMarina();
			DataTable dt = oCApoyoUnidadSubMarina.ConsultarProyectosApoyoUnidadSubmarinoAdmin(IdTipoRegistro,Convert.ToInt32(Page.Request.QueryString[KEYIDPERIODOUNIDADESAPOYOFASUB]),Convert.ToInt32(Page.Request.QueryString[KEYIDUNIDADAPOYO]));
			this.LimpiarControlesWeb();
			if(dt!=null)
			{
				DataView dw = dt.DefaultView;
				dw.Sort = columnaOrdenar ;

				NullableDouble[] Montos;
				string[] Campos=new string[] {
												 Enumerados.ApoyoUnidadSubMarinoColumnas.MontoAsignado.ToString(),
												 Enumerados.ApoyoUnidadSubMarinoColumnas.MontoAprobado.ToString(),
												 Enumerados.ApoyoUnidadSubMarinoColumnas.MontoEjecutado.ToString(),
												 Enumerados.ApoyoUnidadSubMarinoColumnas.MontoEnEjecucion.ToString(),
												 Enumerados.ApoyoUnidadSubMarinoColumnas.MontoComprometido.ToString(),
												 Enumerados.ApoyoUnidadSubMarinoColumnas.MontoSaldo.ToString()
											 };
				CFuncionesEspeciales oCFuncionesEspeciales=new CFuncionesEspeciales();
				Montos=oCFuncionesEspeciales.CalcularMontosTotalesDataFile(dw,Campos);
				
				acumMontoAsignado=NullableIsNull.IsNullDouble(Montos[COLPOSASIGNADO],Utilitario.Constantes.ValorConstanteCero);
				acumMontoAprobado=NullableIsNull.IsNullDouble(Montos[COLPOSAPROBADO],Utilitario.Constantes.ValorConstanteCero);
				acumMontoEjecutado=NullableIsNull.IsNullDouble(Montos[COLPOSEJECUTADO],Utilitario.Constantes.ValorConstanteCero);
				acumMontoEnEjecucion=NullableIsNull.IsNullDouble(Montos[COLPOSENEJECUCION],Utilitario.Constantes.ValorConstanteCero);
				acumMontoComprometido=NullableIsNull.IsNullDouble(Montos[COLPOSCOMPROMETIDO],Utilitario.Constantes.ValorConstanteCero);
				acumMontoSaldo=NullableIsNull.IsNullDouble(Montos[COLPOSALDO],Utilitario.Constantes.ValorConstanteCero);

				acumMontoTotalAprobado=acumMontoAprobado;

				grid.DataSource = dw;
				grid.Columns[2].FooterText = dw.Count.ToString();
				indicePagina=Helper.ValidarIndicePaginacionGrilla(dw.Count,this.grid.PageSize,indicePagina);
				lblResultado.Visible = false;

			}
			else
			{
				grid.DataSource = dt;
				lblResultado.Visible = true;
				lblResultado.Text = GRILLAVACIA;
			}
			try
			{
				this.grid.CurrentPageIndex=indicePagina;
				grid.DataBind();
			}
			catch	
			{
				grid.CurrentPageIndex = Utilitario.Constantes.POSICIONINDEXCERO;
				grid.DataBind();
			}
		}

		public void LlenarCombos()
		{}

		public void LlenarDatos()
		{
			this.lblTitulo.Text = TITULOPERIODO + Utilitario.Constantes.ESPACIO + Page.Request.QueryString[KEYQPERIODO];
 
			if(NullableString.Parse(this.hColumnaOrdenamientoGrid.Value).IsNull)
			{
				this.hColumnaOrdenamientoGrid.Value=COLORDENAMIENTO;
				this.hColumnaOrdenamientoGridAsignado.Value = COLORDENAMIENTO;
			}
			
			if(NullableString.Parse(this.hIndicePaginaGrid.Value).IsNull)
			{
				this.hIndicePaginaGrid.Value=Utilitario.Constantes.POSICIONINDEXCERO.ToString();
				this.hIndicePaginaGridAsignado.Value=Utilitario.Constantes.POSICIONINDEXCERO.ToString();
			}
		}

		public void LlenarJScript()
		{
			ibtnEliminar.Attributes.Add(Utilitario.Constantes.EVENTOCLICK ,JSVERIFICARELIMINAR);
			ibtnEliminarFondo.Attributes.Add(Utilitario.Constantes.EVENTOCLICK ,JSVERIFICARELIMINAR);
			this.ibtnAgregar.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado("hColumnaOrdenamientoGrid","hIndicePaginaGrid"));
			this.ibtnAgregarFondo.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado("hColumnaOrdenamientoGrid","hIndicePaginaGrid"));
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

		//Mensajes
		private const string GRILLAVACIA="NO SE ENCONTRO NINGUN PROYECTO DE APOYO UNIDADES";
		private const string GRILLAVACIAASIGNADO="NO SE ENCONTRO NINGUNA PARATIDA ASIGNADA";
		private const string MENSAJEELIMINAR="Se eliminó el Proyecto Submarino Nro.";
		private const string TITULOPERIODO="PERIODO:";

		//Key y Sesiones
		private const string KEYIDPERIODOUNIDADESAPOYOFASUB ="IdPeriodoApoyoFasub";
		private const string KEYIDUNIDADAPOYO="IdUnidadApoyo";
		private const string KEYQPERIODO = "Periodo";
		private const string KEYIDCENTROOPERATIVO = "IdCentroOperativo";
		private const string KEYIDESTADO = "IdEstado";
		private const string KEYIDPROYECTOSUBMARINO="IdProyectoSubmarino";
		private const string KEYIDTIPOREGISTRO="IdTipoRegistro";
		private const string KEYIDPERIODOAPOYOFASUB="IdPeriodoApoyoFasub";

		//Ordenamiento
		private const string COLORDENAMIENTO="IdProyectoSubmarino Asc";
		private const string ConsthCodigoOrdenamientoGrid="hCodigoOrdenamientoGrid";
		private const string ConsthCodigoIndicePaginaGrid="hCodigoIndicePaginaGrid";
		private const int COLPOSTOTAL=1;
		private const int COLPOSMONTOASIGNADO=3;
		private const int COLPOSMONTOAPROBADO=4;
		private const int COLPOSMONTOEJECUTADO=5;
		private const int COLPOSMONTOENEJECUCION=6;
		private const int COLPOSMONTOCOMPROMETIDO=7;
		private const int COLPOSMONTOSALDO=8;
		private const int COLPOSASIGNADO=0;
		private const int COLPOSAPROBADO=1;
		private const int COLPOSEJECUTADO=2;
		private const int COLPOSENEJECUCION=3;
		private const int COLPOSCOMPROMETIDO=4;
		private const int COLPOSALDO=5;

		//URL's
		private const string URLDETALLEFASUB="DetalleUnidadesSubmarinas.aspx?";
		private const string URLADMINISTRACION="AdministrarUnidadesSubmarinas.aspx?";

		#endregion Contantes
		#region Controles
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblTituloSecundatio;
		protected System.Web.UI.WebControls.ImageButton ibtnAgregar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminar;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.ImageButton ibtnAgregarFondo;
		protected projDataGridWeb.DataGridWeb gridAsignado;
		protected System.Web.UI.WebControls.Label lblResultadoAsignado;
		protected System.Web.UI.WebControls.Label lblFontoPorAsignar;
		protected System.Web.UI.WebControls.Label lblMontoFondoPorAsignar;
		protected System.Web.UI.WebControls.Label lblDescripcion;
		protected System.Web.UI.WebControls.Label lblObservaciones;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.TextBox txtObservaciones;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hColumnaOrdenamientoGrid;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIndicePaginaGrid;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminarFondo;
		protected System.Web.UI.WebControls.Label lblPagina;
		#endregion
		#region Variables
		//JScript
		private string JSVERIFICARELIMINAR = "return verificarEliminarRb('hCodigo','" + Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO)+"','"+Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJEPREGUNTAELIMINACIONREGISTRO)+"');";
		private string JSVERIFICARSELECCIONFILA="return verificarSeleccionRb('hCodigo','"+ Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO) + "');";

		//Otros
		private double acumMontoAsignado=0;
		private double acumMontoAprobado=0;
		private double acumMontoEjecutado=0;
		private double acumMontoEnEjecucion=0;
		private double acumMontoComprometido=0;
		private double acumMontoSaldo=0;
		private double acumMontoTotalAprobado=0;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hColumnaOrdenamientoGridAsignado;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIndicePaginaGridAsignado;
		protected System.Web.UI.WebControls.Label lblTitulo;
		private double acumMontoTotalFondo=0;

		#endregion Variables		
		#region Eventos
		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				e.Item.Cells[Utilitario.Constantes.POSICIONCONTADOR].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
				
				e.Item.Cells[Utilitario.Constantes.POSICIONINDEXCERO].Attributes.Add(Utilitario.Constantes.EVENTOCLICK, Helper.MostrarVentana(URLDETALLEFASUB, Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Enumerados.ModoPagina.M + 
					Utilitario.Constantes.SIGNOAMPERSON + KEYIDPROYECTOSUBMARINO + Utilitario.Constantes.SIGNOIGUAL + dr[Utilitario.Enumerados.ApoyoUnidadSubMarinoColumnas.IdProyectoSubmarino.ToString()].ToString() +
					Utilitario.Constantes.SIGNOAMPERSON + KEYIDTIPOREGISTRO + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt32(Utilitario.Enumerados.ApoyoUnidadSubMarinoTipoProyectos.Proyecto).ToString() +
					Utilitario.Constantes.SIGNOAMPERSON + KEYIDUNIDADAPOYO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYIDUNIDADAPOYO] +
					Utilitario.Constantes.SIGNOAMPERSON + KEYIDPERIODOUNIDADESAPOYOFASUB + Utilitario.Constantes.SIGNOIGUAL  + Page.Request.QueryString[KEYIDPERIODOUNIDADESAPOYOFASUB]));
	
				e.Item.Cells[Utilitario.Constantes.POSICIONCONTADOR].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				e.Item.Cells[Utilitario.Constantes.POSICIONCONTADOR].Font.Underline=true;
				e.Item.Cells[0].ForeColor=Color.Blue;

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,Utilitario.Helper.MostrarDatosEnCajaTexto(hCodigo.ID.ToString(),dr[Utilitario.Enumerados.ApoyoUnidadSubMarinoColumnas.IdProyectoSubmarino.ToString()].ToString())+ Utilitario.Constantes.SIGNOPUNTOYCOMA.ToString() + 
					Utilitario.Helper.MostrarDatosEnCajaTexto(this.txtDescripcion.ID.ToString(),dr[Enumerados.ApoyoUnidadSubMarinoColumnas.Descripcion.ToString()].ToString()) + 
					Utilitario.Constantes.SIGNOPUNTOYCOMA.ToString() +Helper.MostrarDatosEnCajaTexto(this.txtObservaciones.ID.ToString(),dr[Enumerados.ApoyoUnidadSubMarinoColumnas.Observaciones.ToString()].ToString()));
				
				Helper.FiltroporSeleccionConfiguraColumna(e,grid);
			}	
			else if(e.Item.ItemType == ListItemType.Footer)
			{
				e.Item.Cells[COLPOSTOTAL].Text=Utilitario.Constantes.TEXTOTOTAL;
				e.Item.Cells[COLPOSMONTOASIGNADO].Text = acumMontoAsignado.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[COLPOSMONTOAPROBADO].Text = acumMontoAprobado.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[COLPOSMONTOEJECUTADO].Text = acumMontoEjecutado.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[COLPOSMONTOENEJECUCION].Text = acumMontoEnEjecucion.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[COLPOSMONTOCOMPROMETIDO].Text = acumMontoComprometido.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[COLPOSMONTOSALDO].Text = acumMontoSaldo.ToString(Utilitario.Constantes.FORMATODECIMAL4);

				//this.ReiniciarVariablesMontos();
			}
		}

		private void LlenarGrillaOrdenamientoPaginacionAsignado(string columnaOrdenar, int indicePagina)
		{
			int IdTipoRegistro = Convert.ToInt32(Utilitario.Enumerados.ApoyoUnidadSubMarinoTipoProyectos.PartidaAsignada);
			CApoyoUnidadSubMarina oCApoyoUnidadSubMarina=new CApoyoUnidadSubMarina();
			DataTable dt=oCApoyoUnidadSubMarina.ConsultarProyectosApoyoUnidadSubmarinoAdmin(IdTipoRegistro, Convert.ToInt32(Page.Request.QueryString[KEYIDPERIODOUNIDADESAPOYOFASUB]),Convert.ToInt32(Page.Request.QueryString[KEYIDUNIDADAPOYO]));
			this.LimpiarControlesWeb();
			if(dt!=null)
			{
				DataView dw = dt.DefaultView;
				dw.Sort = columnaOrdenar ;

				NullableDouble[] Montos;
				string[] Campos=new string[] {
												 Enumerados.ApoyoUnidadSubMarinoColumnas.MontoAsignado.ToString(),
												 Enumerados.ApoyoUnidadSubMarinoColumnas.MontoAprobado.ToString(),
												 Enumerados.ApoyoUnidadSubMarinoColumnas.MontoEjecutado.ToString(),
												 Enumerados.ApoyoUnidadSubMarinoColumnas.MontoEnEjecucion.ToString(),
												 Enumerados.ApoyoUnidadSubMarinoColumnas.MontoComprometido.ToString(),
												 Enumerados.ApoyoUnidadSubMarinoColumnas.MontoSaldo.ToString()
											 };
				CFuncionesEspeciales oCFuncionesEspeciales=new CFuncionesEspeciales();
				Montos=oCFuncionesEspeciales.CalcularMontosTotalesDataFile(dw,Campos);
				
				acumMontoAsignado=NullableIsNull.IsNullDouble(Montos[COLPOSALDO],Utilitario.Constantes.ValorConstanteCero);
				acumMontoAprobado=NullableIsNull.IsNullDouble(Montos[COLPOSAPROBADO],Utilitario.Constantes.ValorConstanteCero);
				acumMontoEjecutado=NullableIsNull.IsNullDouble(Montos[COLPOSEJECUTADO],Utilitario.Constantes.ValorConstanteCero);
				acumMontoEnEjecucion=NullableIsNull.IsNullDouble(Montos[COLPOSENEJECUCION],Utilitario.Constantes.ValorConstanteCero);
				acumMontoComprometido=NullableIsNull.IsNullDouble(Montos[COLPOSCOMPROMETIDO],Utilitario.Constantes.ValorConstanteCero);
				acumMontoSaldo=NullableIsNull.IsNullDouble(Montos[COLPOSALDO],Utilitario.Constantes.ValorConstanteCero);
				
				acumMontoTotalFondo=acumMontoAsignado;

				gridAsignado.DataSource = dw;
				gridAsignado.Columns[2].FooterText = dw.Count.ToString();

				indicePagina=Helper.ValidarIndicePaginacionGrilla(dw.Count,this.gridAsignado.PageSize,indicePagina);

				lblResultadoAsignado.Visible = false;
			}
			else
			{
				gridAsignado.DataSource = dt;
				lblResultadoAsignado.Visible = true;
				lblResultadoAsignado.Text = GRILLAVACIAASIGNADO;
			}
			try
			{
				gridAsignado.CurrentPageIndex=indicePagina;
				gridAsignado.DataBind();
			}
			catch	
			{
				gridAsignado.CurrentPageIndex = Utilitario.Constantes.POSICIONINDEXCERO;
				gridAsignado.DataBind();
			}
		}

		private void ReiniciarVariablesMontos()
		{
			acumMontoAsignado = Utilitario.Constantes.ValorConstanteCero;
			acumMontoAprobado = Utilitario.Constantes.ValorConstanteCero;
			acumMontoEjecutado = Utilitario.Constantes.ValorConstanteCero;
			acumMontoEnEjecucion = Utilitario.Constantes.ValorConstanteCero;
			acumMontoComprometido = Utilitario.Constantes.ValorConstanteCero;
			acumMontoSaldo = Utilitario.Constantes.ValorConstanteCero;
		}

		private void gridAsignado_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				e.Item.Cells[Utilitario.Constantes.POSICIONCONTADOR].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
				
				e.Item.Cells[Utilitario.Constantes.POSICIONINDEXCERO].Attributes.Add(Utilitario.Constantes.EVENTOCLICK, Helper.MostrarVentana(URLDETALLEFASUB,Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Enumerados.ModoPagina.M + 
					Utilitario.Constantes.SIGNOAMPERSON + KEYIDPROYECTOSUBMARINO  + Utilitario.Constantes.SIGNOIGUAL + dr[Utilitario.Enumerados.ApoyoUnidadSubMarinoColumnas.IdProyectoSubmarino.ToString()].ToString() +
					Utilitario.Constantes.SIGNOAMPERSON + KEYIDTIPOREGISTRO + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt32(Utilitario.Enumerados.ApoyoUnidadSubMarinoTipoProyectos.PartidaAsignada).ToString() +
					Utilitario.Constantes.SIGNOAMPERSON + KEYIDUNIDADAPOYO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYIDUNIDADAPOYO]));
	

				e.Item.Cells[Utilitario.Constantes.POSICIONCONTADOR].Text = Helper.ObtenerIndicedeRegistro(gridAsignado.CurrentPageIndex,gridAsignado.PageSize,e.Item.ItemIndex);
				e.Item.Cells[Utilitario.Constantes.POSICIONCONTADOR].Font.Underline=true;

				
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,Utilitario.Helper.MostrarDatosEnCajaTexto(hCodigo.ID.ToString(),dr[Utilitario.Enumerados.ApoyoUnidadSubMarinoColumnas.IdProyectoSubmarino.ToString()].ToString()) + Utilitario.Constantes.SIGNOPUNTOYCOMA.ToString() + 
					Helper.MostrarDatosEnCajaTexto(this.txtDescripcion.ID.ToString(),dr[Enumerados.ApoyoUnidadSubMarinoColumnas.Descripcion.ToString()].ToString()) + 
					Utilitario.Constantes.SIGNOPUNTOYCOMA.ToString() + Helper.MostrarDatosEnCajaTexto(this.txtObservaciones.ID.ToString(),dr[Enumerados.ApoyoUnidadSubMarinoColumnas.Observaciones.ToString()].ToString()));
			
				Helper.FiltroporSeleccionConfiguraColumna(e,gridAsignado);


			}	
			else if(e.Item.ItemType==ListItemType.Footer)
			{
				e.Item.Cells[COLPOSTOTAL].Text=Utilitario.Constantes.TEXTOTOTAL;
				e.Item.Cells[COLPOSMONTOASIGNADO].Text = acumMontoAsignado.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				this.ReiniciarVariablesMontos();
			}
		}

		private void PintarMontoFondoTotalPorAsiganar()
		{
			double monto=acumMontoTotalFondo-acumMontoTotalAprobado;
			this.lblMontoFondoPorAsignar.Text=monto.ToString(Utilitario.Constantes.FORMATODECIMAL4);
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.hIndicePaginaGrid.Value=e.NewPageIndex.ToString();
			this.LlenarGrillaOrdenamientoPaginacion(this.hColumnaOrdenamientoGrid.Value,e.NewPageIndex);
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.hColumnaOrdenamientoGrid.Value=Helper.GenerarExpresionOrdenamiento(e.SortExpression,false);
			this.LlenarGrillaOrdenamientoPaginacion(this.hColumnaOrdenamientoGrid.Value,Convert.ToInt32(this.hIndicePaginaGrid.Value));
		}

		private void gridAsignado_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.hIndicePaginaGridAsignado.Value = e.NewPageIndex.ToString();
			this.LlenarGrillaOrdenamientoPaginacionAsignado(this.hColumnaOrdenamientoGridAsignado.Value,e.NewPageIndex);
		}

		private void gridAsignado_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.hColumnaOrdenamientoGridAsignado.Value=Helper.GenerarExpresionOrdenamiento(e.SortExpression,false);
			this.LlenarGrillaOrdenamientoPaginacionAsignado(this.hColumnaOrdenamientoGridAsignado.Value,Convert.ToInt32(this.hIndicePaginaGridAsignado.Value));
		}

		private void ibtnAgregar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			string Url = URLDETALLEFASUB + Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Enumerados.ModoPagina.N + Utilitario.Constantes.SIGNOAMPERSON +
				KEYIDTIPOREGISTRO  + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt32(Utilitario.Enumerados.ApoyoUnidadSubMarinoTipoProyectos.Proyecto).ToString()+ Utilitario.Constantes.SIGNOAMPERSON +
				KEYIDPERIODOUNIDADESAPOYOFASUB + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYIDPERIODOUNIDADESAPOYOFASUB] + Utilitario.Constantes.SIGNOAMPERSON + KEYIDUNIDADAPOYO + 
				Utilitario.Constantes.SIGNOIGUAL +	Page.Request.QueryString[KEYIDUNIDADAPOYO];
			this.Page.Response.Redirect(Url);
		}

		private void ibtnAgregarFondo_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			string Url = URLDETALLEFASUB + Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Enumerados.ModoPagina.N + Utilitario.Constantes.SIGNOAMPERSON +
				KEYIDTIPOREGISTRO + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt32(Utilitario.Enumerados.ApoyoUnidadSubMarinoTipoProyectos.PartidaAsignada).ToString() + Utilitario.Constantes.SIGNOAMPERSON +
				KEYIDPERIODOUNIDADESAPOYOFASUB + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYIDPERIODOUNIDADESAPOYOFASUB]+ Utilitario.Constantes.SIGNOAMPERSON + KEYIDUNIDADAPOYO + Utilitario.Constantes.SIGNOIGUAL +
				Page.Request.QueryString[KEYIDUNIDADAPOYO];
			this.Page.Response.Redirect(Url);
		}

		private void ibtnEliminarFondo_Click(object sender, System.Web.UI.ImageClickEventArgs e)
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

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ReiniciarVariablesMontos();
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarJScript();
					Helper.ReestablecerPagina(this);
					this.LlenarDatos();
					this.LlenarGrillaOrdenamientoPaginacion(this.hColumnaOrdenamientoGrid.Value,Convert.ToInt32(this.hIndicePaginaGrid.Value));
					this.LlenarGrillaOrdenamientoPaginacionAsignado(this.hColumnaOrdenamientoGridAsignado.Value,Convert.ToInt32(this.hIndicePaginaGrid.Value));
					this.PintarMontoFondoTotalPorAsiganar();
				}
				catch(SIMAExcepcionLog oSIMAExcepcionLog)
				{
					ltlMensaje.Text = Helper.MensajeAlert(oSIMAExcepcionLog.Mensaje);					
				}
				catch(SIMAExcepcionIU oSIMAExcepcionIU)
				{
					ltlMensaje.Text = Helper.MensajeAlert(oSIMAExcepcionIU.Mensaje);					
				}
				catch(SIMAExcepcion oSIMAExcepcion)
				{
					ltlMensaje.Text = Helper.MensajeAlert(oSIMAExcepcion.Mensaje);					
				}
				catch(Exception oException)
				{
					SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Utilitario.Constantes.CODIGOERRORGENERICO,oException.Message);
					Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
				}
			}
		}

		private void LimpiarControlesWeb()
		{
			this.txtDescripcion.Text="";
			this.txtObservaciones.Text="";
		}

		#endregion

	}
}
