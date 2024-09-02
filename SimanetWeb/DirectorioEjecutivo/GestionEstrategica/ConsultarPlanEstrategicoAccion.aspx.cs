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
using SIMA.Interfaces;

namespace SIMA.SimaNetWeb.DirectorioEjecutivo.GestionEstrategica
{
	public class ConsultarPlanEstrategicoAccion : System.Web.UI.Page, IPaginaBase
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		#region IPaginaBase Members
		public void LlenarGrilla()
		{
			// TODO:  Add ConsultarPlanEstrategicoAccion.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarPlanEstrategicoAccion.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
		{
			int idOEspecifico = Convert.ToInt32(Page.Request.QueryString[Utilitario.Enumerados.ColumnasObjetivosEspecificos.IDOESPECIFICOS.ToString()]);

			this.LlenarDatos();
			
			CObjetivoEspecifico oCObjetivoEspecifico =  new CObjetivoEspecifico();

			DataTable dtOGeneral;
			if (Page.Request.QueryString[KEYIDPLANOPERATIVO] != null)
			{
				lblTituloPrincipal.Text = "DESPLIEGUE DEL PLAN ESTRATEGICO";
				dtOGeneral =  oCObjetivoEspecifico.ListarAccionObjetivoEspecifico(idOEspecifico, Convert.ToInt32(Page.Request.QueryString[KEYQFILTRO]),Convert.ToInt32(Utilitario.Helper.FechaSimanet.ObtenerFechaSesion().AddYears(1).Year));
			}
			else
				dtOGeneral =  oCObjetivoEspecifico.ListarAccionObjetivoEspecifico(idOEspecifico, Convert.ToInt32(Page.Request.QueryString[KEYQFILTRO]));

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
					grid.Columns[0].FooterText = TEXTOFOOTERTOTAL;
					grid.PageSize = Helper.ObtenerCantidadRegistrosPorGrilla();
					grid.Columns[POSICIONFOOTERTOTAL].FooterText = dwOGeneral.Count.ToString();
				}
			}
			else
			{
				grid.DataSource = dtOGeneral;
				//lblResultado.Text = GRILLAVACIA;
				//txtObjeto.Text ="";
				//lblResultado.Visible = true;
			}

			//			if(indicePagina==0)
			//			{
			//				REGISTROACTUAL=0;
			//			}
			//			else
			//			{
			//				REGISTROACTUAL=(indicePagina * grid.PageSize);
			//			}

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
			// TODO:  Add ConsultarPlanEstrategicoAccion.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			this.LlenarTitulos();
		}

		private void LlenarTitulos()
		{
			this.lblCodigoObjGeneral.Text = "OG " + Page.Request.QueryString[KEYCODIGOGENERADO].Split('.').GetValue(0);
			this.lblContenidoObjGeneral.Text = Convert.ToString(Page.Request.QueryString[Utilitario.Enumerados.ColumnasObjetivosGenerales.DESCRIPCION.ToString()]);
			this.lblCodigoEspecificos.Text = "OE " + Page.Request.QueryString[KEYCODIGOGENERADO].ToString();
			this.lblContenidoEspecificos.Text = Convert.ToString(Page.Request.QueryString[Utilitario.Enumerados.ColumnasObjetivosEspecificos.NOMBREOESPECIFICOS.ToString()]);
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarPlanEstrategicoAccion.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarPlanEstrategicoAccion.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarPlanEstrategicoAccion.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarPlanEstrategicoAccion.Exportar implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ConsultarPlanEstrategicoAccion.ValidarFiltros implementation
			return false;
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

		#endregion

		#region Constantes
		//indices
		const string KEYCODIGOGENERADO="KEYCODIGOGENERADO";
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
		

		//Ordenamiento
		const string COLORDENAMIENTO = "IDOESPECIFICO";
		const int COLUMNANUMERACION = 0;
		const int COLUMNAINVERSION = 5;
		const int COLUMNANUMERACIONTOMADA = 1;

		const string URLPLANESTRATEGICOACTIVIDAD = "ConsultarPlanEstrategicoAccionesTomadas.aspx?";
		const string URLFILTRO = "../../Filtros.aspx";
		const string KEYTEXTOOGENERAL = "DESCRIPCION";

		//OTROS
		const string TEXTOFOOTERTOTAL = "Total:";
		const string GRILLAVACIA = "No hay Datos";
		const int POSICIONFOOTERTOTAL = 1;
		const string ORGANISMOGENERAL = "OG";
		#endregion
		#region Controles
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblTituloPrincipal;
		protected System.Web.UI.WebControls.Label lblCodigoObjGeneral;
		protected System.Web.UI.WebControls.Label lblContenidoObjGeneral;
		protected System.Web.UI.WebControls.Label lblCodigoEspecificos;
		protected System.Web.UI.WebControls.Label lblContenidoEspecificos;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltro;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminarFiltro;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnAtras;
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
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				e.Item.Cells[COLUMNAINVERSION].Text = Convert.ToDouble(e.Item.Cells[COLUMNAINVERSION].Text).ToString(Constantes.FORMATODECIMAL4);
				e.Item.Cells[COLUMNANUMERACION].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,"HistorialIrAdelante()");
				
				e.Item.Cells[0].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				e.Item.Cells[0].Font.Underline=true;
				e.Item.Cells[0].ForeColor= System.Drawing.Color.Blue;	
				
				e.Item.Cells[1].Text = "AC " + Page.Request.QueryString[KEYCODIGOGENERADO] + Utilitario.Constantes.SIMBOLOPUNTO + e.Item.Cells[0].Text;

				if (Page.Request.QueryString[KEYIDPLANOPERATIVO] != null)
				{
					e.Item.Cells[COLUMNANUMERACION].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
						Helper.MostrarVentana(URLPLANESTRATEGICOACTIVIDAD, 
						KEYIDOGENERAL + Utilitario.Constantes.SIGNOIGUAL + 
						Convert.ToInt32(Page.Request.QueryString[Utilitario.Enumerados.ColumnasObjetivosGenerales.IDOGENERALES.ToString()]) +
						Utilitario.Constantes.SIGNOAMPERSON + 
						NOMBREOGENERAL + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(Page.Request.QueryString[Utilitario.Enumerados.ColumnasObjetivosGenerales.DESCRIPCION.ToString()]) +
						Utilitario.Constantes.SIGNOAMPERSON + 
						KEYIDOESPECIFICO + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(Page.Request.QueryString[Utilitario.Enumerados.ColumnasObjetivosEspecificos.IDOESPECIFICOS.ToString()] +
						Utilitario.Constantes.SIGNOAMPERSON + 	
						CODIGOESPECIFICO + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(Page.Request.QueryString[Utilitario.Enumerados.ColumnasObjetivosEspecificos.CODIGOOESPECIFICOS.ToString()]) +
						Utilitario.Constantes.SIGNOAMPERSON + 	
						NOMBREOESPECIFICO + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(Page.Request.QueryString[Utilitario.Enumerados.ColumnasObjetivosEspecificos.NOMBREOESPECIFICOS.ToString()]) +
						Utilitario.Constantes.SIGNOAMPERSON + 	
						KEYIDACCION + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr[Utilitario.Enumerados.ColumnasAccion.idAccion.ToString()]) +
						Utilitario.Constantes.SIGNOAMPERSON + 	
						CODIGOACCION + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr[Utilitario.Enumerados.ColumnasAccion.CodigoAccion.ToString()]) +
						Utilitario.Constantes.SIGNOAMPERSON + 	
						DESCRIPCIONACCION + Utilitario.Constantes.SIGNOIGUAL + 	Convert.ToString(dr[Utilitario.Enumerados.ColumnasAccion.Descripcion.ToString()])) + 
						Utilitario.Constantes.SIGNOAMPERSON + KEYQFILTRO + Utilitario.Constantes.SIGNOIGUAL+  Page.Request.QueryString[KEYQFILTRO]+
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYIDPLANOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYIDPLANOPERATIVO] +
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYCODIGOGENERADO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYCODIGOGENERADO] + Utilitario.Constantes.SIMBOLOPUNTO + e.Item.Cells[0].Text
						));

				}
				else
				{
					e.Item.Cells[COLUMNANUMERACION].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
						Helper.MostrarVentana(URLPLANESTRATEGICOACTIVIDAD, 
						KEYIDOGENERAL + Utilitario.Constantes.SIGNOIGUAL + 
						Convert.ToInt32(Page.Request.QueryString[Utilitario.Enumerados.ColumnasObjetivosGenerales.IDOGENERALES.ToString()]) +
						Utilitario.Constantes.SIGNOAMPERSON + 
						NOMBREOGENERAL + Utilitario.Constantes.SIGNOIGUAL + 
						Convert.ToString(Page.Request.QueryString[Utilitario.Enumerados.ColumnasObjetivosGenerales.DESCRIPCION.ToString()]) +
						Utilitario.Constantes.SIGNOAMPERSON + 
						KEYIDOESPECIFICO + Utilitario.Constantes.SIGNOIGUAL +
						Convert.ToString(Page.Request.QueryString[Utilitario.Enumerados.ColumnasObjetivosEspecificos.IDOESPECIFICOS.ToString()] +
						Utilitario.Constantes.SIGNOAMPERSON + 	
						CODIGOESPECIFICO + Utilitario.Constantes.SIGNOIGUAL +
						Convert.ToString(Page.Request.QueryString[Utilitario.Enumerados.ColumnasObjetivosEspecificos.CODIGOOESPECIFICOS.ToString()]) +
						Utilitario.Constantes.SIGNOAMPERSON + 	
						NOMBREOESPECIFICO + Utilitario.Constantes.SIGNOIGUAL + 
						Convert.ToString(Page.Request.QueryString[Utilitario.Enumerados.ColumnasObjetivosEspecificos.NOMBREOESPECIFICOS.ToString()]) +
						Utilitario.Constantes.SIGNOAMPERSON + 	
						KEYIDACCION + Utilitario.Constantes.SIGNOIGUAL + 
						Convert.ToString(dr[Utilitario.Enumerados.ColumnasAccion.idAccion.ToString()]) +
						Utilitario.Constantes.SIGNOAMPERSON + 	
						CODIGOACCION + Utilitario.Constantes.SIGNOIGUAL + 
						Convert.ToString(dr[Utilitario.Enumerados.ColumnasAccion.CodigoAccion.ToString()]) +
						Utilitario.Constantes.SIGNOAMPERSON + 	
						DESCRIPCIONACCION + Utilitario.Constantes.SIGNOIGUAL + 
						Convert.ToString(dr[Utilitario.Enumerados.ColumnasAccion.Descripcion.ToString()])) + 
						Utilitario.Constantes.SIGNOAMPERSON + KEYQFILTRO + Utilitario.Constantes.SIGNOIGUAL+
						Page.Request.QueryString[KEYQFILTRO] +
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYCODIGOGENERADO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYCODIGOGENERADO] + Utilitario.Constantes.SIMBOLOPUNTO + e.Item.Cells[0].Text
						));
				}
				
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);	
				Helper.FiltroporSeleccionConfiguraColumna(e,grid);
			}
		}

		private void ibtnEliminarFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}

		private void ibtnFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			int idOEspecifico = Convert.ToInt32(Page.Request.QueryString[Utilitario.Enumerados.ColumnasObjetivosEspecificos.IDOESPECIFICOS.ToString()]);

			CObjetivoEspecifico oCObjetivoEspecifico =  new CObjetivoEspecifico();
			DataTable dtOGeneral =  oCObjetivoEspecifico.ListarAccionObjetivoEspecifico(idOEspecifico,Convert.ToInt32(Page.Request.QueryString[KEYQFILTRO]));

			ltlMensaje.Text= Utilitario.Helper.ElaborarFiltro(this,dtOGeneral,URLFILTRO
				,"*" + Utilitario.Enumerados.ColumnasAccion.CodigoAccion.ToString()+";Codigo Acción"
				,Utilitario.Enumerados.ColumnasAccion.Descripcion.ToString()+ ";Descripción"
				,Utilitario.Enumerados.ColumnasAccion.Lider.ToString()+ ";Responsable");
		}
		
		#endregion
	}
}
