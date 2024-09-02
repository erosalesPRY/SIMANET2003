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
using SIMA.Controladoras.GestionControlInstitucional;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;


namespace SIMA.SimaNetWeb.GestionControlInstitucional
{
	/// <summary>
	/// Summary description for RequerimientosAsignados.
	/// </summary>
	public class ConsultarActividadControlEjecucion : System.Web.UI.Page,IPaginaBase
	{
		#region Controles

		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblPosicionRegistro;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminarFiltro;
		protected System.Web.UI.WebControls.TextBox txtObservaciones;

		#endregion Controles

		#region Constantes
		
		//Ordenamiento
		const string COLORDENAMIENTO = "IdActividadCtrlEjec";

		//Nombres de Controles
		const string CONTROLINK = "hlkId";
		const string CONTROLCAJATEXTOOBSERVACIONES = "txtObservaciones";
		
		//Paginas
		const string URLDETALLE = "DetalleActividadControlEjecucion.aspx?";
		const string URLIMPRESION = "PopupImpresionConsultarActividadControlEjecucion.aspx";

		//Key Session y QueryString
		const string KEYQID = "Id";
		const string KEYQPRG = "Prg";
		const string KEYQTIT = "Titulo";

		//JScript
			
		//Otros
		const string GRILLAVACIA ="No existe ninguna Ejecucion de Actividad de Control.";
		const string TITULO = "CONSULTA DE LAS EJECUCIONES DE LAS ACTIVIDADES DE CONTROL";
		const int PosicionFooterTotal = 2;
		const string MESSELECCIONADO = "X";
		const int PosicionCeldaEnero = 9;
		const int PosicionCeldaFebrero = 10;
		const int PosicionCeldaMarzo = 11;
		const int PosicionCeldaAbril = 12;
		const int PosicionCeldaMayo = 13;
		const int PosicionCeldaJunio = 14;
		const int PosicionCeldaJulio = 15;
		const int PosicionCeldaAgosto = 16;
		const int PosicionCeldaSetiembre = 17;
		const int PosicionCeldaOctubre = 18;
		const int PosicionCeldaNoviembre = 19;
		const int PosicionCeldaDiciembre = 20;

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

					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se consultaron los Articulos destinados a Relaciones Publicas.",Enumerados.NivelesErrorLog.I.ToString()));

					this.LlenarDatos();

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
			this.ibtnEliminarFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminarFiltro_Click);
			this.ibtnImprimir.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnImprimir_Click);
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

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
		{
			CActividadCtrlEjec oCActividadCtrlEjec =  new CActividadCtrlEjec();
			DataTable dtOCI =  oCActividadCtrlEjec.ListarActividadCtrlEjecPorProgramacion(Convert.ToInt32(Page.Request.QueryString[KEYQPRG]));
			
			if(dtOCI!=null)
			{
				DataView dwOCI = dtOCI.DefaultView;
				dwOCI.Sort = columnaOrdenar ;
				dwOCI.RowFilter = Helper.ObtenerFiltro(this);

				if(dwOCI.Count>0)
				{
					grid.DataSource = dwOCI;
					grid.Columns[PosicionFooterTotal].FooterText = dwOCI.Count.ToString();
					this.lblResultado.Visible = false;
				}
				else
				{
					grid.DataSource = null;
					lblResultado.Visible = true;
					lblResultado.Text = GRILLAVACIA;
				}
				CImpresion oCImpresion = new CImpresion();
				oCImpresion.GuardarDataImprimirExportar(dwOCI.Table,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGOTITULOREPORTEACTIVIDADCTRLEJEC) + Utilitario.Constantes.ESPACIO + Page.Request.QueryString[KEYQTIT].ToString().ToUpper(),columnaOrdenar,indicePagina);
			}
			else
			{
				grid.DataSource = dtOCI;
				this.lblResultado.Visible = true;
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
			// TODO:  Add ConsultaDeCartasFianzas.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			this.lblTitulo.Text = TITULO + Utilitario.Constantes.ESPACIO + Page.Request.QueryString[KEYQTIT].ToString().ToUpper();
		}

		public void LlenarJScript()
		{
			
		}

		public void RegistrarJScript()
		{

		}

		public void Imprimir()
		{
			ltlMensaje.Text = Helper.PopupImpresion(URLIMPRESION,750,500,false,false,false,true,true);
		}

		public void Exportar()
		{
			
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
			return true;
		}

		#endregion


		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				e.Item.Cells[Constantes.POSICIONCONTADOR].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);

				e.Item.Cells[Constantes.POSICIONCONTADOR].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.MostrarVentana(URLDETALLE,KEYQID + Utilitario.Constantes.SIGNOIGUAL + 
					Convert.ToString(dr[Enumerados.ColumnasActividadCtrlEjec.IdActividadCtrlEjec.ToString()]) +  
					Utilitario.Constantes.SIGNOAMPERSON + Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.C.ToString() + 
					Utilitario.Constantes.SIGNOAMPERSON + KEYQPRG + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQPRG].ToString() +
					Utilitario.Constantes.SIGNOAMPERSON + KEYQTIT + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQTIT].ToString()
					));

				if(Convert.ToInt32(dr[Enumerados.ColumnasActividadCtrlEjec.FlgEne.ToString()]) > Constantes.POSICIONCONTADOR)
				{
					e.Item.Cells[PosicionCeldaEnero].Text = MESSELECCIONADO;
				}
				if(Convert.ToInt32(dr[Enumerados.ColumnasActividadCtrlEjec.FlgFeb.ToString()]) > Constantes.POSICIONCONTADOR)
				{
					e.Item.Cells[PosicionCeldaFebrero].Text = MESSELECCIONADO;
				}
				if(Convert.ToInt32(dr[Enumerados.ColumnasActividadCtrlEjec.FlgMar.ToString()]) > Constantes.POSICIONCONTADOR)
				{
					e.Item.Cells[PosicionCeldaMarzo].Text = MESSELECCIONADO;
				}
				if(Convert.ToInt32(dr[Enumerados.ColumnasActividadCtrlEjec.FlgAbr.ToString()]) > Constantes.POSICIONCONTADOR)
				{
					e.Item.Cells[PosicionCeldaAbril].Text = MESSELECCIONADO;
				}
				if(Convert.ToInt32(dr[Enumerados.ColumnasActividadCtrlEjec.FlgMay.ToString()]) > Constantes.POSICIONCONTADOR)
				{
					e.Item.Cells[PosicionCeldaMayo].Text = MESSELECCIONADO;
				}
				if(Convert.ToInt32(dr[Enumerados.ColumnasActividadCtrlEjec.FlgJun.ToString()]) > Constantes.POSICIONCONTADOR)
				{
					e.Item.Cells[PosicionCeldaJunio].Text = MESSELECCIONADO;
				}
				if(Convert.ToInt32(dr[Enumerados.ColumnasActividadCtrlEjec.FlgJul.ToString()]) > Constantes.POSICIONCONTADOR)
				{
					e.Item.Cells[PosicionCeldaJulio].Text = MESSELECCIONADO;
				}
				if(Convert.ToInt32(dr[Enumerados.ColumnasActividadCtrlEjec.FlgAgo.ToString()]) > Constantes.POSICIONCONTADOR)
				{
					e.Item.Cells[PosicionCeldaAgosto].Text = MESSELECCIONADO;
				}
				if(Convert.ToInt32(dr[Enumerados.ColumnasActividadCtrlEjec.FlgSep.ToString()]) > Constantes.POSICIONCONTADOR)
				{
					e.Item.Cells[PosicionCeldaSetiembre].Text = MESSELECCIONADO;
				}
				if(Convert.ToInt32(dr[Enumerados.ColumnasActividadCtrlEjec.FlgOct.ToString()]) > Constantes.POSICIONCONTADOR)
				{
					e.Item.Cells[PosicionCeldaOctubre].Text = MESSELECCIONADO;
				}
				if(Convert.ToInt32(dr[Enumerados.ColumnasActividadCtrlEjec.FlgNov.ToString()]) > Constantes.POSICIONCONTADOR)
				{
					e.Item.Cells[PosicionCeldaNoviembre].Text = MESSELECCIONADO;
				}
				if(Convert.ToInt32(dr[Enumerados.ColumnasActividadCtrlEjec.FlgDic.ToString()]) > Constantes.POSICIONCONTADOR)
				{
					e.Item.Cells[PosicionCeldaDiciembre].Text = MESSELECCIONADO;
				}
	
				e.Item.Cells[Constantes.POSICIONCONTADOR].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				e.Item.Cells[Constantes.POSICIONCONTADOR].Font.Underline=true;

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,Utilitario.Helper.MostrarDatosEnCajaTexto(CONTROLCAJATEXTOOBSERVACIONES,dr[Enumerados.ColumnasActividadCtrlEjec.Observaciones.ToString()].ToString()));
				Helper.FiltroporSeleccionConfiguraColumna(e,grid);
			}
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

		private void ibtnImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Imprimir();
		}

		private void ibtnFiltrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			CActividadCtrlEjec oCActividadCtrlEjec =  new CActividadCtrlEjec();
			DataTable dtOCI =  oCActividadCtrlEjec.ListarActividadCtrlEjecPorProgramacion(Convert.ToInt32(Page.Request.QueryString[KEYQPRG]));

			ltlMensaje.Text= Utilitario.Helper.ElaborarFiltro(dtOCI
					,Utilitario.Enumerados.ColumnasActividadCtrlEjec.Codigo.ToString()+";Codigo"
					,Utilitario.Enumerados.ColumnasActividadCtrlEjec.Denominacion.ToString()+ ";Denominacion"
					,Utilitario.Enumerados.ColumnasActividadCtrlEjec.NroMetaProgramada.ToString()+ ";Meta Programada"
					,Utilitario.Enumerados.ColumnasActividadCtrlEjec.PorcentajeAvanceProgramado.ToString()+ ";% Avance Programado"
					,Utilitario.Enumerados.ColumnasActividadCtrlEjec.NroUnidadesEjecutadas.ToString()+ ";Unidades Ejecutadas"
					,Utilitario.Enumerados.ColumnasActividadCtrlEjec.PorcentajeAvanceEjecutado.ToString()+ ";% Avance Ejecutado"
					,"*" + Utilitario.Enumerados.ColumnasActividadCtrlEjec.Estado.ToString()+ ";Estado");
		}

		private void ibtnEliminarFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}
	}
}