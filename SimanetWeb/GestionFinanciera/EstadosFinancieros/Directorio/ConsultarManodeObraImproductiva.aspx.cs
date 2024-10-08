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
using SIMA.Controladoras.GestionFinanciera;
using SIMA.Utilitario;
using NetAccessControl;
using SIMA.ManejadorExcepcion;
using SIMA.Log;

namespace SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancieros.Directorio
{
	/// <summary>
	/// Summary description for ConsultarManodeObraImproductiva.
	/// </summary>
	public class ConsultarManodeObraImproductiva : System.Web.UI.Page,IPaginaBase
	{
		#region Constante
			const string LBLDELMES = "lblDelMes";
			const string VARIABLETOTALIZA ="Totaliza";
			const string URLDETALLEPERSONAL = "/Personal/DetallePersonal.aspx?";
			const string URLDETALLEADMINOBSERVACIONES = "DetalleAdministrarObservacionesEstadosFinancieros.aspx?";
			const string  KEYQLLAMADA = "QuienLLama";
			const string  KEYQID        = "IDCO";
			const string ALERTA = "../../../imagenes/alert.gif";
			const string CONTROLIMGBUTTON = "imgCaducidad";
			
			const string EXTENSIONFOTO = ".JPG";
			#region otras
					
				const string URLPAGINAGASTOSADMINISTRATIVOS = "ConsultarGastosdeAdministracionPorCentroOperativo.aspx?";

				const string KEYQIDEMPRESA = "idEmp";
				const string KEYIDCENTRO ="IdCentroOperativo";
				const string NOMBRECENTRO ="NombreCentro";

				const string NOMBRETIPOOPCION ="NombreOpcion";
				const string KEYQIDNOMBREFORMATO = "NFormato";
				const string KEYQIDFECHA = "efFecha";
				const string KEYQPERIODO="periodo";
				const string KEYQIDNOMBREMES = "NombreMes";

						
				const string COLUMNACONCEPTO = "CONCEPTO";
				const string COLUMNAIDRUBRO ="idRubro";

				const string KEYQNOMBRERUBRO ="NRubro";
				const string KEYQIDFORMATO = "IdFormato";
				const string KEYQIDREPORTE = "IdReporte";
				const string KEYQIDRUBRO = "IdRubro";
				const string KEYQNROPERSONAL = "Nropersonal";
				const string KEYQIDOBSERVACION="IdObservacion";

				const string KEYQNUEVOSSOLES = "MILNS";
			#endregion

			#region Label Item
				const string LBLDELMESREAL = "lblDelMesReal";
				const string LBLDELMESPPTO= "lblDelMesPPTO";
				const string LBLDELMESVAR= "lblDelMesVar";

				const string LBLACUMREAL= "lblAcumReal";
				const string LBLACUMPPTO= "lblAcumPPTO";
				const string LBLACUMVAR= "lblAcumVar";

				const string LBLPROYREAL= "lblProyReal";
				const string LBLPROYPPTO= "lblProyPPTO";
				const string LBLPROYVAR= "lblProyVar";
		#endregion

		#endregion


		#region Atributos
		protected DateTime FechaPeriodo
		{
			get
			{
				return Convert.ToDateTime(DateTime.DaysInMonth(Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA]).Year,Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA]).Month) + Utilitario.Constantes.SEPARADORFECHA + Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA]).Month.ToString().PadLeft(2,'0') + Utilitario.Constantes.SEPARADORFECHA + Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA]).Year.ToString());
			}
		}

		protected int idFormato
		{
			get
			{
				return Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO]);
			}
		}
		protected string NombreFormato
		{
			get
			{
				return Page.Request.Params[KEYQIDNOMBREFORMATO].ToString();
			}
		}

		protected int idReporte
		{
			get
			{
				return Convert.ToInt32(Page.Request.Params[KEYQIDREPORTE]);
			}
		}
		protected int idEmpresa
		{
			get
			{
				return Convert.ToInt32(Page.Request.Params[KEYQIDEMPRESA]);
			}
		}

		protected int idCentro
		{
			get
			{
				return Convert.ToInt32(Page.Request.Params[KEYIDCENTRO]);
			}
		}
		protected int idRubro
		{
			get
			{
				return Convert.ToInt32(Page.Request.Params[KEYQIDRUBRO]);
			}
		}
		protected string NombreRubro
		{
			get
			{
				return Page.Request.Params[KEYQNOMBRERUBRO].ToString();
			}
		}



		#endregion

		#region Controles
			protected System.Web.UI.WebControls.Label Label3;
			protected System.Web.UI.WebControls.Label lblPeriodo;
			protected System.Web.UI.WebControls.Label Label2;
			protected System.Web.UI.WebControls.Label lblMes;
			protected System.Web.UI.WebControls.Label Label4;
			protected System.Web.UI.WebControls.Label lblConcepto;
			protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;
			protected System.Web.UI.WebControls.ImageButton ibtnEliminarFiltro;
			protected projDataGridWeb.DataGridWeb grid;
			protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
			protected System.Web.UI.HtmlControls.HtmlInputHidden hOrdenGrilla;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.HtmlControls.HtmlTextArea campo1;
			protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				if(!Page.IsPostBack)
				{
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarJScript();
					this.LlenarCombos();
					this.LlenarDatos();
					this.LlenarGrillaOrdenamientoPaginacion(this.hOrdenGrilla.Value.ToString(),Convert.ToInt32(this.hGridPagina.Value));
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
				ltlMensaje.Text = Helper.MsgdbErrMostrarMesaje(true,oSIMAExcepcionDominio.Error.ToString());					
			}
			catch(Exception oException)
			{
				string debug = oException.Message.ToString();
				SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
				Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
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
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add ConsultarManodeObraImproductiva.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarManodeObraImproductiva.LlenarGrillaOrdenamiento implementation
		}


		private DataTable ObtenerDatos()
		{
			return ((CEstadosFinancieros)new  CEstadosFinancieros()).ConsultarManodeObraImproductiva(this.idEmpresa
																									,this.idCentro
																									,this.FechaPeriodo.Year
																									,this.FechaPeriodo.Month
																									,this.idFormato
																									,this.idRubro
																									);			
		}
		private void GenerarResumen(DataView dv)
		{
			int NroResumen = 33;
			CResumenItem oCResumenItem = new CResumenItem();
			Session[VARIABLETOTALIZA] = ((DataTable)Helper.Resumen(oCResumenItem.ObtenerConfiDataResumen(NroResumen),dv)).Rows[0]["Monto"];
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dt = this.ObtenerDatos();
			
			if(dt!=null)
			{

				DataView dw = dt.DefaultView;
				dw.RowFilter = Helper.ObtenerFiltro();
				this.GenerarResumen(dw);
				dw.Sort = columnaOrdenar;
				if(Convert.ToInt32(Session[Utilitario.Constantes.KEYQOBSERVACION])==1)
					grid.Columns[8].Visible=true;

				grid.DataSource = dw;
				grid.CurrentPageIndex =indicePagina;
				grid.PageSize = Helper.ObtenerCantidadRegistrosPorGrilla(10,35,40);
				grid.Columns[Constantes.POSICIONTOTAL].FooterText = dw.Count.ToString();
			}
			else
			{

				grid.DataSource = dt;
			}
			grid.DataBind();
		}

		public void LlenarCombos()
		{
			// TODO:  Add ConsultarManodeObraImproductiva.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			this.lblConcepto.Text = this.NombreRubro.ToUpper();
			this.lblPeriodo.Text = this.FechaPeriodo.Year.ToString();
			this.lblMes.Text = Helper.ObtenerNombreMes(FechaPeriodo.Month,SIMA.Utilitario.Enumerados.TipoDatoMes.NombreCompleto).ToUpper();
			Helper.ReestablecerPagina(this);
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarManodeObraImproductiva.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarManodeObraImproductiva.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarManodeObraImproductiva.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarManodeObraImproductiva.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add ConsultarManodeObraImproductiva.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ConsultarManodeObraImproductiva.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.Header)
			{
				e.Item.Cells[1].ToolTip ="C�digo de Personal";
				e.Item.Cells[5].ToolTip ="Horas";
			}
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				e.Item.ToolTip = dr["ceo"].ToString();

				if(Convert.ToInt32(Session[Utilitario.Constantes.KEYQOBSERVACION])==1)
				{
					string modoPagina=String.Empty;
					if(dr["observacion"].ToString()==String.Empty)
					{
						modoPagina =Enumerados.ModoPagina.N.ToString();
					}
					else
					{
						modoPagina =Enumerados.ModoPagina.M.ToString();
					}

					Helper.ConfiguraColumnaHyperLink(e.Item.Cells[0],grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex,
						Helper.HistorialIrAdelantePersonalizado(this.hGridPagina.ID.ToString(),this.hOrdenGrilla.ID.ToString()),
						Helper.PopupBusqueda(URLDETALLEADMINOBSERVACIONES + KEYQLLAMADA + Utilitario.Constantes.SIGNOIGUAL + "ESTADOSFINANCIEROS"
						+ Utilitario.Constantes.SIGNOAMPERSON 
						+ KEYQIDEMPRESA + Utilitario.Constantes.SIGNOIGUAL + this.idEmpresa.ToString() 
						+ Utilitario.Constantes.SIGNOAMPERSON 
						+ KEYIDCENTRO + Utilitario.Constantes.SIGNOIGUAL + this.idCentro.ToString() 
						+ Utilitario.Constantes.SIGNOAMPERSON 
						+ KEYQIDFORMATO + Utilitario.Constantes.SIGNOIGUAL + this.idFormato.ToString() 
						+ Utilitario.Constantes.SIGNOAMPERSON 
						+ KEYQIDFECHA + Utilitario.Constantes.SIGNOIGUAL + this.FechaPeriodo.Month.ToString() 
						+ Utilitario.Constantes.SIGNOAMPERSON 
						+ KEYQPERIODO + Utilitario.Constantes.SIGNOIGUAL + this.FechaPeriodo.Year.ToString() 
						+ Utilitario.Constantes.SIGNOAMPERSON 
						+ Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + modoPagina 
						+ Utilitario.Constantes.SIGNOAMPERSON 
						+ KEYQIDRUBRO + Utilitario.Constantes.SIGNOIGUAL + this.idRubro.ToString() 
						+ Utilitario.Constantes.SIGNOAMPERSON 
						+ KEYQNROPERSONAL + Utilitario.Constantes.SIGNOIGUAL + dr["NroPersonal"].ToString() 
						+ Utilitario.Constantes.SIGNOAMPERSON 
						+ KEYQIDOBSERVACION + Utilitario.Constantes.SIGNOIGUAL + dr["idObservacion"].ToString() 
						+ Utilitario.Constantes.SIGNOAMPERSON 
						+ KEYQID + Utilitario.Constantes.SIGNOIGUAL + dr["NroPersonal"].ToString(),600,400));

				}
				else
				{
					Helper.ConfiguraColumnaHyperLink(e.Item.Cells[0],grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex,
						Helper.HistorialIrAdelantePersonalizado(this.hGridPagina.ID.ToString(),this.hOrdenGrilla.ID.ToString()),
						Helper.MostrarVentana(Session[Utilitario.Constantes.SPATHAPPWEB].ToString() + URLDETALLEPERSONAL,KEYQLLAMADA + Utilitario.Constantes.SIGNOIGUAL + "ESTADOSFINANCIEROS"
						+ Utilitario.Constantes.SIGNOAMPERSON 
						+ KEYQID + Utilitario.Constantes.SIGNOIGUAL + dr["NroPersonal"].ToString()));
				}

				e.Item.Cells[Constantes.POSICIONCONTADOR].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				e.Item.Cells[6].ToolTip= Convert.ToDouble(e.Item.Cells[6].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[6].Text = Convert.ToDouble(e.Item.Cells[6].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				if(Convert.ToInt32(Session[Utilitario.Constantes.KEYQOBSERVACION])==1)
				{				
					System.Web.UI.WebControls.Image ibtn1=(System.Web.UI.WebControls.Image)e.Item.Cells[8].FindControl(CONTROLIMGBUTTON);	
					if (Convert.ToString(dr["observacion"])== String.Empty)
					{
						ibtn1.ImageUrl = ALERTA;
					}
					else
					{
						ibtn1.Visible = false;
					}
				}
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,Utilitario.Helper.MostrarDatosEnCajaTexto("campo1",dr["observacion"].ToString()));
				Helper.FiltroporSeleccionConfiguraColumna(e,this.grid);

			}
			if(e.Item.ItemType == ListItemType.Footer)
			{
				e.Item.Cells[6].Text = Convert.ToDouble(Session[VARIABLETOTALIZA]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

			}
		
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.hGridPagina.Value = e.NewPageIndex.ToString();
			this.LlenarGrillaOrdenamientoPaginacion(this.hOrdenGrilla.Value,e.NewPageIndex);		
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.hOrdenGrilla.Value = Helper.GenerarExpresionOrdenamiento(e.SortExpression);
			this.LlenarGrillaOrdenamientoPaginacion(this.hOrdenGrilla.Value,Helper.ObtenerIndicePagina());		
		}

		private void ibtnFiltrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			ltlMensaje.Text = Helper.ElaborarFiltro(this.ObtenerDatos()
													,"NROPERSONAL;CODIGO DE PERSONAL"
													,"NOMBRES;APELLIDOS Y NOMBRES"
													,"*Especialidad;ESPECIALIDAD"
													,"*Area;AREA"
													,"Horas;HORAS");

		}

		private void ibtnEliminarFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}
	}
}
