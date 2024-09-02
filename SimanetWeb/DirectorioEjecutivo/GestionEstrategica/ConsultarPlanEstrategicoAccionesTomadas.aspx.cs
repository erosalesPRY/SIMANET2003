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

namespace SIMA.SimaNetWeb.DirectorioEjecutivo.GestionEstrategica
{
	public class ConsultarPlanEstrategicoAccionesTomadas : System.Web.UI.Page
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
			this.ibtnFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnFiltro_Click);
			this.ibtnEliminarFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminarFiltro_Click);
			this.ibtnBitacora.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnBitacora_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		#region IPaginaBase Members
		public void LlenaJScript()
		{
			ibtnBitacora.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,"HistorialIrAdelante()");
			this.ibtnBitacora.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,JSVERIFICARSELECCIONFILA);
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

		private void LlenarTitulos()
		{
			lblCodigoObjGeneral.Text = "OG " + Page.Request.QueryString[KEYCODIGOGENERADO].Split('.').GetValue(0);
			lblContenidoObjGeneral.Text = Convert.ToString(Page.Request.QueryString[Utilitario.Enumerados.ColumnasObjetivosGenerales.DESCRIPCION.ToString()]);
			lblCodigoOE.Text = "OE " + Page.Request.QueryString[KEYCODIGOGENERADO].Split('.').GetValue(0)+ Utilitario.Constantes.SIMBOLOPUNTO + Page.Request.QueryString[KEYCODIGOGENERADO].Split('.').GetValue(1);
			lblContenidoOE.Text = Convert.ToString(Page.Request.QueryString[Utilitario.Enumerados.ColumnasObjetivosEspecificos.NOMBREOESPECIFICOS.ToString()]);
			lblCodigoAccion.Text = "AC " + Page.Request.QueryString[KEYCODIGOGENERADO];
			lblContenidoAccion.Text = Convert.ToString(Page.Request.QueryString[Utilitario.Enumerados.ColumnasAccion.DescripcionAccion.ToString()]);
		}

		public DataTable ObtenerDatos()
		{
			int idAccion = Convert.ToInt32(Page.Request.QueryString[Utilitario.Enumerados.ColumnasAccion.idAccion.ToString()]);

			CObjetivoEspecifico oCObjetivoEspecifico =  new CObjetivoEspecifico();

			DataTable dtOGeneral;

			if (Page.Request.QueryString[KEYIDPLANOPERATIVO] != null)
			{
				lblTituloPrincipal.Text = "DESPLIEGUE DEL PLAN OPERATIVO";
				dtOGeneral =  oCObjetivoEspecifico.ListarActividad(idAccion,Convert.ToInt32(Page.Request.QueryString[KEYQFILTRO]),Convert.ToInt32(Utilitario.Helper.FechaSimanet.ObtenerFechaSesion().AddYears(1).Year));
			}
			else
			{
				dtOGeneral =  oCObjetivoEspecifico.ListarActividad(idAccion,Convert.ToInt32(Page.Request.QueryString[KEYQFILTRO]));
			}
			return dtOGeneral;
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
		{
			DataTable dtOGeneral = this.ObtenerDatos();
			
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

		#endregion
		#region Constantes
		//Ordenamiento
		const string COLORDENAMIENTO = "IDOESPECIFICO";
		const int COLUMNANUMERACION = 0;

		//Varables
		string JSVERIFICARSELECCIONFILA="return verificarSeleccionRb('hCodigo','"+ Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO) + "');";
		
		//Indices
		const string KEIDDESCRIPCIONACTIVIDAD="KEIDDESCRIPCIONACTIVIDAD";
		const string KEYCODIGOACTIVIDAD="KEYCODIGOACTIVIDAD";
		const string KEYQID = "IdDocumentoSecretaria";
		const string KEYQIDTABLAESTADO ="IdTablaEstado";
		const string KEYIDPLANOPERATIVO= "KEYIDPLANOPERATIVO";
		const string KEYQFILTRO = "IDVISIBILIDAD";
		const string KEYIDOGENERAL = "idOGenerales";
		const string NOMBREOGENERAL = "Descripcion";
		const string KEYIDOESPECIFICO = "idOEspecificos";
		const string CODIGOESPECIFICO = "CodigoOEspecificos";
		const string NOMBREOESPECIFICO = "NombreOEspecificos";
		const string KEYIDACCION = "IdAccion";
		const string CODIGOACCION = "CodigoAccion";
		const string DESCRIPCIONACCION = "DescripcionAccion";
		const string KEYCODIGOGENERADO="KEYCODIGOGENERADO";

		//OTROS
		const string TEXTOFOOTERTOTAL = "Total:";
		const string GRILLAVACIA = "No hay Datos";
		const int POSICIONFOOTERTOTAL = 1;
		#endregion
		#region Controles
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminarFiltro;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltro;
		protected System.Web.UI.WebControls.Label lblTituloPrincipal;
		protected System.Web.UI.WebControls.ImageButton ibtnBitacora;
		protected System.Web.UI.WebControls.Label lblCodigoObjGeneral;
		protected System.Web.UI.WebControls.Label lblContenidoObjGeneral;
		protected System.Web.UI.WebControls.Label lblCodigoOE;
		protected System.Web.UI.WebControls.Label lblContenidoOE;
		protected System.Web.UI.WebControls.Label lblCodigoAccion;
		protected System.Web.UI.WebControls.Label lblContenidoAccion;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hDescripcionActividad;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hNro;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigoActividad;
		#endregion
		
		#region Eventos
		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				e.Item.Cells[0].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				e.Item.Cells[1].Text = "AT " + Page.Request.QueryString[KEYCODIGOGENERADO] + Utilitario.Constantes.SIMBOLOPUNTO + e.Item.Cells[0].Text; 
				
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
					(hNro.ID,
					 e.Item.Cells[0].Text))
					);
				
				Helper.FiltroporSeleccionConfiguraColumna(e,grid);
			}
		}
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack )
			{
				try
				{
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarTitulos();
					this.LlenaJScript();
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

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(e.SortExpression),Helper.ObtenerIndicePagina());
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			grid.CurrentPageIndex=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);
		}

		private void ibtnFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			ltlMensaje.Text= Utilitario.Helper.ElaborarFiltro(this.ObtenerDatos()
				,"*" + Utilitario.Enumerados.ColumnasActividad.CODIGOACTIVIDAD.ToString()+";Codigo Actividad"
				,Utilitario.Enumerados.ColumnasActividad.DESCRIPCION.ToString()+ ";Descripción"
				,Utilitario.Enumerados.ColumnasActividad.LIDER.ToString()+ ";Responsable"
				,"*" + Utilitario.Enumerados.ColumnasActividad.AÑO.ToString()+ ";Año");
		}
		
		private void ibtnEliminarFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}

		private void ibtnBitacora_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			const string URLDETALLE="../../Secretaria/DetalleConsultaAdministracionRepresentacionOficiales.aspx?";
			int idOGeneral = Convert.ToInt32(Page.Request.QueryString[Utilitario.Enumerados.ColumnasObjetivosGenerales.IDOGENERALES.ToString()]);
			string OGeneralTexto = Convert.ToString(Page.Request.QueryString[Utilitario.Enumerados.ColumnasObjetivosGenerales.DESCRIPCION.ToString()]);
			string CodigoOEspecifico = Convert.ToString(Page.Request.QueryString[Utilitario.Enumerados.ColumnasObjetivosEspecificos.CODIGOOESPECIFICOS.ToString()]);
			string OEspecificoTexto = Convert.ToString(Page.Request.QueryString[Utilitario.Enumerados.ColumnasObjetivosEspecificos.NOMBREOESPECIFICOS.ToString()]);
			string CodigoAccion= Convert.ToString(Page.Request.QueryString[Utilitario.Enumerados.ColumnasAccion.CodigoAccion.ToString()]);
			string DescripcionAccion = Convert.ToString(Page.Request.QueryString[Utilitario.Enumerados.ColumnasAccion.DescripcionAccion.ToString()]);

			Response.Redirect(URLDETALLE + 
				Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.C.ToString()+
				Utilitario.Constantes.SIGNOAMPERSON+
				KEYQIDTABLAESTADO + Utilitario.Constantes.SIGNOIGUAL+ Convert.ToInt32(Enumerados.TablasTabla.BitacoraEstrategica).ToString() +
				Utilitario.Constantes.SIGNOAMPERSON+
				KEYQID+ Utilitario.Constantes.SIGNOIGUAL +	hCodigo.Value+
				Utilitario.Constantes.SIGNOAMPERSON +
				KEYIDOGENERAL +	Utilitario.Constantes.SIGNOIGUAL +	Page.Request.QueryString[KEYIDOGENERAL]+
				Utilitario.Constantes.SIGNOAMPERSON+ 
				Utilitario.Enumerados.ColumnasObjetivosGenerales.DESCRIPCION.ToString() + Utilitario.Constantes.SIGNOIGUAL + OGeneralTexto +
				Utilitario.Constantes.SIGNOAMPERSON+
				Utilitario.Enumerados.ColumnasObjetivosEspecificos.CODIGOOESPECIFICOS.ToString()+Utilitario.Constantes.SIGNOIGUAL + CodigoOEspecifico+
				Utilitario.Constantes.SIGNOAMPERSON+
				Utilitario.Enumerados.ColumnasObjetivosEspecificos.NOMBREOESPECIFICOS.ToString()+	Utilitario.Constantes.SIGNOIGUAL +	OEspecificoTexto+
				Utilitario.Constantes.SIGNOAMPERSON+
				Utilitario.Enumerados.ColumnasAccion.CodigoAccion.ToString()+	Utilitario.Constantes.SIGNOIGUAL +	CodigoAccion+
				Utilitario.Constantes.SIGNOAMPERSON+
				Utilitario.Enumerados.ColumnasAccion.DescripcionAccion.ToString()+ Utilitario.Constantes.SIGNOIGUAL + DescripcionAccion +
				Utilitario.Constantes.SIGNOAMPERSON+
				KEYCODIGOACTIVIDAD + Utilitario.Constantes.SIGNOIGUAL + 	hCodigoActividad.Value	+
				Utilitario.Constantes.SIGNOAMPERSON+ KEIDDESCRIPCIONACTIVIDAD + Utilitario.Constantes.SIGNOIGUAL+ hDescripcionActividad.Value +
				Utilitario.Constantes.SIGNOAMPERSON + 
				KEYCODIGOGENERADO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYCODIGOGENERADO] + Utilitario.Constantes.SIMBOLOPUNTO + hNro.Value
				);
		}

		#endregion
		
		
	}
}
