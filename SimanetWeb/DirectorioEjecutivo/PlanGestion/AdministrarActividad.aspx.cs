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
using SIMA.Controladoras.GestionEstrategica;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;

namespace SIMA.SimaNetWeb.DirectorioEjecutivo.PlanGestion
{
	public class AdministrarActividad : System.Web.UI.Page, IPaginaBase
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
			this.ibtnBitacora.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnBitacora_Click);
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

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			int idAccion = Convert.ToInt32(Page.Request.QueryString[Utilitario.Enumerados.ColumnasAccion.idAccion.ToString()]);

			CObjetivoEspecifico oCObjetivoEspecifico =  new CObjetivoEspecifico();
			DataTable dtOGeneral =  oCObjetivoEspecifico.ListarActividad(idAccion,Convert.ToInt32(Page.Request.QueryString[KEYQFILTRO]));
			
			if(dtOGeneral!=null)
			{
				DataView dwOGeneral = dtOGeneral.DefaultView;
				grid.DataSource = dwOGeneral;
				dwOGeneral.RowFilter = Helper.ObtenerFiltro(this);

				if (dwOGeneral.Count == 0)
				{
					grid.DataSource = null; 
					lblResultado.Text = GRILLAVACIA;
					lblResultado.Visible = true;
				}
				else
				{
					grid.DataSource = dwOGeneral;
					grid.PageSize = Helper.ObtenerCantidadRegistrosPorGrilla();
					grid.Columns[0].FooterText = TEXTOFOOTERTOTAL;
					grid.Columns[POSICIONFOOTERTOTAL].FooterText = dwOGeneral.Count.ToString();
				}
			}
			else
			{
				grid.DataSource = dtOGeneral;
				lblResultado.Text = GRILLAVACIA;
				lblResultado.Visible = true;
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
		}

		public void LlenarDatos()
		{
		}

		public void LlenarJScript()
		{
			ibtnEliminar.Attributes.Add(Utilitario.Constantes.EVENTOCLICK ,JSVERIFICARELIMINAR);
			ibtnBitacora.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,"HistorialIrAdelante()");
			this.ibtnBitacora.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,JSVERIFICARSELECCIONFILA);
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
		}

		public bool ValidarFiltros()
		{
			return false;
		}

		#endregion
		#region Constantes
		//Ordenamiento
		const string KEYCODIGOGENERADO="KEYCODIGOGENERADO";
		const string TITULOBITACORA="BITACORA ACTIVIDADES";
		const string KEYDESCRIPCIONACTIVIDAD="KEYDESCRIPCIONACTIVIDAD";
		const string KEYQFILTRO = "IDVISIBILIDAD";
		const string COLORDENAMIENTO = "IdActividad";
		const int COLUMNANUMERACION = 0;
		const int COLUMNAMODIFICAR = 1;

		const string KEYPROMOTOR = "Promotor";
		const string KEYCODIGOACCION="KEYCODIGOACCION";
		const string KEYOGENERALTEXTO = "DESCRIPCION";
		const string KEYQIDOGENERAL = "IDOGENERALES";
		const string KEYCONTENIDOOG="KEYCONTENIDOOG";
		const string KEYCONTENIDOOE="KEYCONTENIDOOE";
		const string KEYCONTENIDOAN="KEYCONTENIDOAC";
		const string KEYCONTENIDOAT="KEYCONTENIDOAT";
		const string KEYQID = "IdDocumentoSecretaria";
		const string KEYQIDTABLAESTADO ="IdTablaEstado";
		
		const string NOMBREOGENERAL = "Descripcion";
		const string KEYACTIVIDAD = "IdActividad";
		const string KEYIDOGENERAL = "idOGenerales";
		const string KEYIDOESPECIFICO = "idOEspecificos";
		const string KEYIDACCION = "IdAccion";
		const string CODIGOESPECIFICO = "CodigoOEspecificos";
		const string NOMBREOESPECIFICO = "NombreOEspecificos";
		const string CODIGOACCION = "CodigoAccion";
		const string DESCRIPCIONACCION = "DescripcionAccion";
		const string DESCRIPCIONOGENERAL = "DESCRIPCION";
		const string CODIGOOE = "CodigoOEspecificos";
		const string NOMBREOE = "NombreOEspecificos";
		const string PE = "PlanEstrategico";

		//OTROS
		const string URLMODIFICAR = "DetalleActividad.aspx?";
		const string URLBITACORA="../../Secretaria/AdministracionGestionesSecretaria.aspx?";
		const string TEXTOFOOTERTOTAL = "Total:";
		const string GRILLAVACIA = "No hay Datos";
		const int POSICIONFOOTERTOTAL = 1;
		const string OBJETIVOGENERAL = "OG";
		const string TITULOVERACTIVIDAD = "Ver Actividad: ";

		string JSVERIFICARSELECCIONFILA="return verificarSeleccionRb('hCodigo','"+ Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO) + "');";
		const string MENSAJEELIMINAR="Se elimino la actividad Nro. ";
		const string MENSAJESELECCIONAR="Tiene que seleccionar un registro";
		#endregion
		#region Controles
		protected System.Web.UI.HtmlControls.HtmlInputHidden hNro;
		protected System.Web.UI.HtmlControls.HtmlInputHidden Hidden1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigoActividad;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminar;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblContenidoAccion;
		protected System.Web.UI.WebControls.Label lblCodigoAccion;
		protected System.Web.UI.WebControls.Label lblContenidoOE;
		protected System.Web.UI.WebControls.Label lblCodigoOE;
		protected System.Web.UI.WebControls.Label lblContenidoObjGeneral;
		protected System.Web.UI.WebControls.Label lblCodigoObjGeneral;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.ImageButton ibtnBitacora;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hDescripcionActividad;
		protected System.Web.UI.WebControls.ImageButton ibtnAgregar;
		#endregion
		#region Variables
		private string JSVERIFICARELIMINAR = "return verificarEliminarRb('hCodigo','" + Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO)+"','"+Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJEPREGUNTAELIMINACIONREGISTRO)+"');";
		#endregion
		#region Eventos
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack )
			{
				try
				{
					this.ConfigurarAccesoControles();
					this.LlenarJScript();
					Helper.ReiniciarSession();
					this.LlenarTitulos();
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionEstrategica",this.ToString(),"Se consulto el Modulo Gestion Estrategico.",Enumerados.NivelesErrorLog.I.ToString()));
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

		private void LlenarTitulos()
		{
			this.lblCodigoObjGeneral.Text = "OG " + Page.Request.QueryString[KEYCODIGOGENERADO].Split('.').GetValue(0);
			this.lblContenidoObjGeneral.Text = Page.Request.QueryString[KEYOGENERALTEXTO].ToUpper();
			this.lblCodigoOE.Text = "OE " + Page.Request.QueryString[KEYCODIGOGENERADO].Split('.').GetValue(0) + Utilitario.Constantes.SIMBOLOPUNTO + Page.Request.QueryString[KEYCODIGOGENERADO].Split('.').GetValue(1);
			this.lblContenidoOE.Text = Page.Request.QueryString[NOMBREOE].ToUpper();
			this.lblCodigoAccion.Text = "AC " + Page.Request.QueryString[KEYCODIGOGENERADO];
			this.lblContenidoAccion.Text = Convert.ToString(Page.Request.QueryString[Utilitario.Enumerados.ColumnasAccion.DescripcionAccion.ToString()]);			
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				
				e.Item.Cells[0].Text =  Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);

				e.Item.Cells[1].Font.Underline=true;
				e.Item.Cells[1].ForeColor= System.Drawing.Color.Blue;
				e.Item.Cells[1].ToolTip = TITULOVERACTIVIDAD;
				e.Item.Cells[1].Text = "AT " + Page.Request.QueryString[KEYCODIGOGENERADO] + Utilitario.Constantes.SIMBOLOPUNTO + e.Item.Cells[0].Text;


				e.Item.Cells[COLUMNAMODIFICAR].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.HISTORIALADELANTE + ";" +
					Helper.MostrarVentana(URLMODIFICAR,
					KEYQIDOGENERAL +
					Utilitario.Constantes.SIGNOIGUAL + 
					Page.Request.QueryString[KEYQIDOGENERAL] +
					Utilitario.Constantes.SIGNOAMPERSON + 
					KEYOGENERALTEXTO  +
					Utilitario.Constantes.SIGNOIGUAL + 
					Page.Request.QueryString[KEYOGENERALTEXTO] +
					Utilitario.Constantes.SIGNOAMPERSON + 
					KEYIDOESPECIFICO +
					Utilitario.Constantes.SIGNOIGUAL + 
					Page.Request.QueryString[KEYIDOESPECIFICO] +  
					Utilitario.Constantes.SIGNOAMPERSON + 
					NOMBREOE +
					Utilitario.Constantes.SIGNOIGUAL +
					Page.Request.QueryString[NOMBREOE] +
                    KEYIDACCION +
					Utilitario.Constantes.SIGNOIGUAL + 
					Page.Request.QueryString[KEYIDACCION] +
					Utilitario.Constantes.SIGNOAMPERSON + 
					DESCRIPCIONACCION +
					Utilitario.Constantes.SIGNOIGUAL +
					Page.Request.QueryString[DESCRIPCIONACCION] + 
					Utilitario.Constantes.SIGNOAMPERSON +
					KEYACTIVIDAD +
					Utilitario.Constantes.SIGNOIGUAL + 
					Convert.ToInt32(dr[Utilitario.Enumerados.ColumnasActividad.IDACTIVIDAD.ToString()]) +
					Utilitario.Constantes.SIGNOAMPERSON + 
					CODIGOOE +
					Utilitario.Constantes.SIGNOIGUAL +
					Page.Request.QueryString[CODIGOOE] +
					Utilitario.Constantes.SIGNOAMPERSON +
					CODIGOACCION +
					Utilitario.Constantes.SIGNOIGUAL + 
					Page.Request.QueryString[Utilitario.Enumerados.ColumnasAccion.CodigoAccion.ToString()] +
					Utilitario.Constantes.SIGNOAMPERSON +
					Utilitario.Constantes.KEYMODOPAGINA +
					Utilitario.Constantes.SIGNOIGUAL + 
					Enumerados.ModoPagina.M.ToString() + 
					Utilitario.Constantes.SIGNOAMPERSON +
					PE +
					Utilitario.Constantes.SIGNOIGUAL +
					Page.Request.QueryString[PE] +
					Utilitario.Constantes.SIGNOAMPERSON +
					KEYDESCRIPCIONACTIVIDAD + 
					Utilitario.Constantes.SIGNOIGUAL +
					dr[Utilitario.Enumerados.ColumnasActividad.DESCRIPCION.ToString()].ToString() +
					Utilitario.Constantes.SIGNOAMPERSON +
                    KEYCODIGOACCION + 
					Utilitario.Constantes.SIGNOIGUAL +
					dr[Utilitario.Enumerados.ColumnasActividad.CODIGOACTIVIDAD.ToString()]
					));										
					
					
		

				e.Item.Cells[COLUMNANUMERACION].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,
					(Helper.MostrarDatosEnCajaTexto
						(hCodigo.ID,
						dr[Utilitario.Enumerados.ColumnasActividad.IDACTIVIDAD.ToString()].ToString()))
						+ ";" +
					(Helper.MostrarDatosEnCajaTexto
						(hDescripcionActividad.ID,
						dr[Utilitario.Enumerados.ColumnasActividad.DESCRIPCION.ToString()].ToString()))
						+ ";" +
						(Helper.MostrarDatosEnCajaTexto
						(hCodigoActividad.ID,
						dr[Utilitario.Enumerados.ColumnasActividad.CODIGOACTIVIDAD.ToString()].ToString()))
					+ ";" +
					(Helper.MostrarDatosEnCajaTexto
					(hNro.ID,e.Item.Cells[0].Text))
					);
				Helper.FiltroporSeleccionConfiguraColumna(e,grid);
			}
		}

		private void ibtnAgregar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.redireccionaPaginaAgregar();
		}

		private void redireccionaPaginaAgregar()
		{
			Page.Response.Redirect(URLMODIFICAR + 
				Utilitario.Constantes.KEYMODOPAGINA + 
				Utilitario.Constantes.SIGNOIGUAL + 
				Enumerados.ModoPagina.N.ToString() +
				Utilitario.Constantes.SIGNOAMPERSON + 
				KEYIDOGENERAL +
				Utilitario.Constantes.SIGNOIGUAL + 
				Page.Request.Params[Utilitario.Enumerados.ColumnasObjetivosGenerales.IDOGENERALES.ToString()] +
				Utilitario.Constantes.SIGNOAMPERSON + 
				//Descripcion OGenerales
				DESCRIPCIONOGENERAL +
				Utilitario.Constantes.SIGNOIGUAL + 
				Page.Request.Params[Utilitario.Enumerados.ColumnasObjetivosGenerales.DESCRIPCION.ToString()] +
				Utilitario.Constantes.SIGNOAMPERSON + 
				//idOEspecifico
				KEYIDOESPECIFICO +
				Utilitario.Constantes.SIGNOIGUAL + 
				Page.Request.QueryString[Utilitario.Enumerados.ColumnasObjetivosEspecificos.IDOESPECIFICOS.ToString()] +  
				Utilitario.Constantes.SIGNOAMPERSON + 
				//idAccion
				KEYIDACCION +
				Utilitario.Constantes.SIGNOIGUAL + 
				Page.Request.QueryString[Utilitario.Enumerados.ColumnasAccion.idAccion.ToString()] +
				Utilitario.Constantes.SIGNOAMPERSON + 
				//Codigo OE
				CODIGOOE +
				Utilitario.Constantes.SIGNOIGUAL +
				Page.Request.QueryString[Utilitario.Enumerados.ColumnasObjetivosEspecificos.CODIGOOESPECIFICOS.ToString()] +
				Utilitario.Constantes.SIGNOAMPERSON +
				//Nombre OE
				NOMBREOE +
				Utilitario.Constantes.SIGNOIGUAL +
				Page.Request.QueryString[Utilitario.Enumerados.ColumnasObjetivosEspecificos.NOMBREOESPECIFICOS.ToString()] +
				//Plan Estrategico
				Utilitario.Constantes.SIGNOAMPERSON +

				CODIGOACCION + Utilitario.Constantes.SIGNOIGUAL + 
				Page.Request.QueryString[Utilitario.Enumerados.ColumnasAccion.CodigoAccion.ToString()] +
				Utilitario.Constantes.SIGNOAMPERSON + 	
						
				DESCRIPCIONACCION + Utilitario.Constantes.SIGNOIGUAL + 
				Page.Request.QueryString[Utilitario.Enumerados.ColumnasAccion.Descripcion.ToString()] +
						
				PE +
				Utilitario.Constantes.SIGNOIGUAL +
				Page.Request.QueryString[Utilitario.Enumerados.OpcionModuloGestionEstrategica.PlanEstrategico.ToString()]);
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

		private void ibtnBitacora_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect(URLBITACORA + KEYQID  + Utilitario.Constantes.SIGNOIGUAL + hCodigo.Value + 
				Utilitario.Constantes.SIGNOAMPERSON + KEYQIDTABLAESTADO + Utilitario.Constantes.SIGNOIGUAL +
				Convert.ToInt32(Utilitario.Enumerados.TablasTabla.BitacoraEstrategica).ToString() +
				Utilitario.Constantes.SIGNOAMPERSON +
				KEYQIDOGENERAL +
				Utilitario.Constantes.SIGNOIGUAL + 
				Page.Request.QueryString[KEYQIDOGENERAL] +
				Utilitario.Constantes.SIGNOAMPERSON + 
				KEYOGENERALTEXTO  +
				Utilitario.Constantes.SIGNOIGUAL + 
				Page.Request.QueryString[KEYOGENERALTEXTO] +
				Utilitario.Constantes.SIGNOAMPERSON + 
				KEYIDOESPECIFICO +
				Utilitario.Constantes.SIGNOIGUAL + 
				Page.Request.QueryString[KEYIDOESPECIFICO] +  
				Utilitario.Constantes.SIGNOAMPERSON + 
				NOMBREOE +
				Utilitario.Constantes.SIGNOIGUAL +
				Page.Request.QueryString[NOMBREOE] +
				KEYIDACCION +
				Utilitario.Constantes.SIGNOIGUAL + 
				Page.Request.QueryString[KEYIDACCION] +
				Utilitario.Constantes.SIGNOAMPERSON + 
				DESCRIPCIONACCION +
				Utilitario.Constantes.SIGNOIGUAL +
				Page.Request.QueryString[DESCRIPCIONACCION] + 
				Utilitario.Constantes.SIGNOAMPERSON +
				KEYACTIVIDAD +
				Utilitario.Constantes.SIGNOIGUAL + 
				hCodigo.Value +
				Utilitario.Constantes.SIGNOAMPERSON + 
				CODIGOOE +
				Utilitario.Constantes.SIGNOIGUAL +
				Page.Request.QueryString[CODIGOOE] +
				Utilitario.Constantes.SIGNOAMPERSON +
				CODIGOACCION +
				Utilitario.Constantes.SIGNOIGUAL + 
				Page.Request.QueryString[CODIGOACCION] +
				Utilitario.Constantes.SIGNOAMPERSON +
				Utilitario.Constantes.KEYMODOPAGINA +
				Utilitario.Constantes.SIGNOIGUAL + 
				Enumerados.ModoPagina.M.ToString() + 
				Utilitario.Constantes.SIGNOAMPERSON +
				PE +
				Utilitario.Constantes.SIGNOIGUAL +
				Page.Request.QueryString[PE] +
				Utilitario.Constantes.SIGNOAMPERSON +
				KEYDESCRIPCIONACTIVIDAD + 
				Utilitario.Constantes.SIGNOIGUAL +
				hDescripcionActividad.Value +
				Utilitario.Constantes.SIGNOAMPERSON +
				KEYCODIGOACCION + 
				Utilitario.Constantes.SIGNOIGUAL +
				hCodigoActividad.Value +
				Utilitario.Constantes.SIGNOAMPERSON +
				KEYPROMOTOR +
				Utilitario.Constantes.SIGNOIGUAL+
				TITULOBITACORA + 
				Utilitario.Constantes.SIGNOAMPERSON +
				KEYCODIGOGENERADO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYCODIGOGENERADO] + Utilitario.Constantes.SIMBOLOPUNTO + hNro.Value
				);
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

		private void Eliminar()
		{
			if(hCodigo.Value.Length==Utilitario.Constantes.ValorConstanteCero)
			{
				ltlMensaje.Text = Helper.MensajeAlert(MENSAJESELECCIONAR);
			}
			else
			{
				CMantenimientos oCMantenimientos = new CMantenimientos();

				if(oCMantenimientos.Eliminar(Convert.ToInt32(hCodigo.Value),CNetAccessControl.GetIdUser(),Utilitario.Enumerados.ClasesTAD.ActividadTAD.ToString())>Utilitario.Constantes.ValorConstanteCero)
				{
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Utilitario.Enumerados.NombresdeModulo.GestionEstratégica.ToString(),this.ToString(),MENSAJEELIMINAR + hCodigo.Value + Utilitario.Constantes.SIMBOLOPUNTO,Enumerados.NivelesErrorLog.I.ToString()));
					ltlMensaje.Text = Helper.MensajeAlert("Se elimino el registro");
					this.LlenarGrillaOrdenamientoPaginacion("",Helper.ObtenerIndicePagina());
				}
			}
		}
		#endregion
	}
}
