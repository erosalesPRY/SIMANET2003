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
	public class ConsultarPlanEstrategicoObjetivoEspecifico : System.Web.UI.Page
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
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.ibtnAtrasPersonalizado.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAtrasPersonalizado_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		#region IPaginaBase Members
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
			this.lblCodigoObjGeneral.Text = "OG " + Page.Request.QueryString[KEYCODIGOGENERADO];
			this.lblContenidoObjGeneral.Text = Convert.ToString(Page.Request.QueryString[Utilitario.Enumerados.ColumnasObjetivosGenerales.DESCRIPCION.ToString()]);
		}
		
		public DataTable ObtenerDatos()
		{
			CObjetivoEspecifico oCObjetivoEspecifico =  new CObjetivoEspecifico();
			DataTable dtOGeneral;

			int idOGeneral = Convert.ToInt32(Page.Request.QueryString[Utilitario.Enumerados.ColumnasObjetivosGenerales.IDOGENERALES.ToString()]);
			string OGeneralTexto = Convert.ToString(Page.Request.QueryString[Utilitario.Enumerados.ColumnasObjetivosGenerales.DESCRIPCION.ToString()]);

			if (Page.Request.QueryString[KEYIDPLANOPERATIVO] != null)
			{
				lblTituloPrincipal.Text = "DESPLIEGUE DEL PLAN OPERATIVO";
				dtOGeneral = oCObjetivoEspecifico.ListarObjetivoEspecifico(idOGeneral,Convert.ToInt32(Page.Request.QueryString[KEYQFILTRO]),Convert.ToInt32(Utilitario.Helper.FechaSimanet.ObtenerFechaSesion().AddYears(1).Year));
			}
			else
				dtOGeneral = oCObjetivoEspecifico.ListarObjetivoEspecifico(idOGeneral,Convert.ToInt32(Page.Request.QueryString[KEYQFILTRO]));
			
			return dtOGeneral;
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
		{
			this.ibtnAtras.Visible = false;
			this.ibtnAtrasPersonalizado.Visible = true;

			DataTable dtOGeneral = this.ObtenerDatos();
			
			if(dtOGeneral!=null)
			{
				DataView dwOGeneral = dtOGeneral.DefaultView;
				grid.DataSource = dwOGeneral;
				dwOGeneral.RowFilter = Helper.ObtenerFiltro(this);

				if (dwOGeneral.Count == 0)
					grid.DataSource = null; 
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

		//URLS
		const string URLCONSULTA="ConsultarPlanEstrategicoObjetivosGenerales.aspx?";
		const string URLPLANESTRATEGICOACCIONOBJETIVOSESPECIFICOS = "ConsultarPlanEstrategicoAccion.aspx?";

		const string KEYIDPLANOPERATIVO= "KEYIDPLANOPERATIVO";
		const string KEYIDVERSION="KEYIDVERSION";
		const string KEYQFILTRO = "IDVISIBILIDAD";
		const string KEYIDOGENERAL = "idOGenerales";
		const string NOMBREOGENERAL = "Descripcion";
		const string KEYIDOESPECIFICO = "idOEspecificos";
		const string CODIGOESPECIFICO = "CodigoOEspecificos";
		const string NOMBREOESPECIFICO = "NombreOEspecificos";
		const string KEYCODIGOGENERADO="KEYCODIGOGENERADO";

		//OTROS
		const string TEXTOFOOTERTOTAL = "Total:";
		const string GRILLAVACIA = "No hay Objetivos Especificos asignados";
		const int POSICIONFOOTERTOTAL = 1;
		#endregion
		#region Controles
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblContenidoObjGeneral;
		protected System.Web.UI.WebControls.Label lblCodigoObjGeneral;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminarFiltro;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltro;
		protected System.Web.UI.WebControls.ImageButton ibtnAtrasPersonalizado;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnAtras;	
		protected System.Web.UI.WebControls.Label lblTituloPrincipal;
		#endregion Controles
		

		#region Eventos
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
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

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(e.SortExpression),Helper.ObtenerIndicePagina());
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			grid.CurrentPageIndex=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				string OGeneralTexto = Convert.ToString(Page.Request.QueryString[Utilitario.Enumerados.ColumnasObjetivosGenerales.DESCRIPCION.ToString()]);
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				e.Item.Cells[COLUMNANUMERACION].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,"HistorialIrAdelante()");

				e.Item.Cells[0].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				e.Item.Cells[0].Font.Underline=true;
				e.Item.Cells[0].ForeColor= System.Drawing.Color.Blue;
		
				e.Item.Cells[1].Text = "OE " + Page.Request.QueryString[KEYCODIGOGENERADO].ToString() + Utilitario.Constantes.SIMBOLOPUNTO + e.Item.Cells[0].Text;
				
				if (Page.Request.QueryString[KEYIDPLANOPERATIVO] != null)
				{
					#region Plan Director
					e.Item.Cells[COLUMNANUMERACION].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
						Helper.MostrarVentana(URLPLANESTRATEGICOACCIONOBJETIVOSESPECIFICOS, 
						KEYIDOGENERAL + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[Utilitario.Enumerados.ColumnasObjetivosGenerales.IDOGENERALES.ToString()] +
						Utilitario.Constantes.SIGNOAMPERSON + 
						NOMBREOGENERAL + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[Utilitario.Enumerados.ColumnasObjetivosGenerales.DESCRIPCION.ToString()]+
						Utilitario.Constantes.SIGNOAMPERSON + 
						KEYIDOESPECIFICO + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr[Utilitario.Enumerados.ColumnasObjetivosEspecificos.IDOESPECIFICOS.ToString()]) +
						Utilitario.Constantes.SIGNOAMPERSON + 	
						CODIGOESPECIFICO + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr[Utilitario.Enumerados.ColumnasObjetivosEspecificos.OE.ToString()]) +
						Utilitario.Constantes.SIGNOAMPERSON + 	
						NOMBREOESPECIFICO + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr[Utilitario.Enumerados.ColumnasObjetivosEspecificos.NOMBREOESPECIFICOS.ToString()]) + 
						Utilitario.Constantes.SIGNOAMPERSON + 
						KEYQFILTRO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQFILTRO] + 
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYIDPLANOPERATIVO + Utilitario.Constantes.SIGNOIGUAL +	Page.Request.QueryString[KEYIDPLANOPERATIVO] +
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYCODIGOGENERADO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYCODIGOGENERADO] + Utilitario.Constantes.SIMBOLOPUNTO + e.Item.Cells[0].Text 
						));
					#endregion
				}
				else
				{
					#region Plan Operativo
					e.Item.Cells[COLUMNANUMERACION].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
						Helper.MostrarVentana(URLPLANESTRATEGICOACCIONOBJETIVOSESPECIFICOS, 
						KEYIDOGENERAL + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[Utilitario.Enumerados.ColumnasObjetivosGenerales.IDOGENERALES.ToString()] +
						Utilitario.Constantes.SIGNOAMPERSON + 
						NOMBREOGENERAL + Utilitario.Constantes.SIGNOIGUAL +	Page.Request.QueryString[Utilitario.Enumerados.ColumnasObjetivosGenerales.DESCRIPCION.ToString()]+
						Utilitario.Constantes.SIGNOAMPERSON + 
						KEYIDOESPECIFICO + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr[Utilitario.Enumerados.ColumnasObjetivosEspecificos.IDOESPECIFICOS.ToString()]) +
						Utilitario.Constantes.SIGNOAMPERSON + 	
						CODIGOESPECIFICO + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr[Utilitario.Enumerados.ColumnasObjetivosEspecificos.OE.ToString()]) +
						Utilitario.Constantes.SIGNOAMPERSON + 	
						NOMBREOESPECIFICO + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr[Utilitario.Enumerados.ColumnasObjetivosEspecificos.NOMBREOESPECIFICOS.ToString()]) + 
						Utilitario.Constantes.SIGNOAMPERSON + 
						KEYQFILTRO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQFILTRO] +
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYCODIGOGENERADO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYCODIGOGENERADO]  + Utilitario.Constantes.SIMBOLOPUNTO + e.Item.Cells[0].Text 
						));
					#endregion
				}

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);	
				Helper.FiltroporSeleccionConfiguraColumna(e,grid);
			}
		}

		#endregion

		
		
		private void ibtnFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			ltlMensaje.Text= Utilitario.Helper.ElaborarFiltro(this.ObtenerDatos()
				,"*" + Utilitario.Enumerados.ColumnasObjetivosEspecificos.CODIGOOESPECIFICOS.ToString()+";Codigo Objetivo Especifico"
				,Utilitario.Enumerados.ColumnasObjetivosEspecificos.NOMBREOESPECIFICOS.ToString()+ ";Descripción"
				,Utilitario.Enumerados.ColumnasObjetivosEspecificos.Lider.ToString()+ ";Responsable"
				,"*" + Utilitario.Enumerados.ColumnasObjetivosEspecificos.CO.ToString()+ ";Centro Operativo");
		}

		private void ibtnEliminarFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}

		private void ibtnAtrasPersonalizado_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if(Page.Request.QueryString[KEYIDVERSION] == null)
			{
				if (Page.Request.QueryString[KEYIDPLANOPERATIVO] != null)
					Response.Redirect(
						URLCONSULTA + 
						KEYQFILTRO +
						Utilitario.Constantes.SIGNOIGUAL +
						Page.Request.QueryString[KEYQFILTRO] +
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYIDPLANOPERATIVO +
						Utilitario.Constantes.SIGNOIGUAL +
						Page.Request.QueryString[KEYIDPLANOPERATIVO] 
						);
				else
					Response.Redirect(
						URLCONSULTA + 
						KEYQFILTRO +
						Utilitario.Constantes.SIGNOIGUAL +
						Page.Request.QueryString[KEYQFILTRO]);
			}
			else
				Response.Redirect(URLCONSULTA + KEYQFILTRO +
					Utilitario.Constantes.SIGNOIGUAL +
					Page.Request.QueryString[KEYQFILTRO] + Utilitario.Constantes.SIGNOAMPERSON +
					KEYIDVERSION + Utilitario.Constantes.SIGNOIGUAL + 
					Page.Request.QueryString[KEYIDVERSION]);
		}
	}
}

