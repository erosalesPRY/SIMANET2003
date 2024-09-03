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
using SIMA.EntidadesNegocio.GestionFinanciera;

using SIMA.Utilitario;
using NetAccessControl;
using SIMA.ManejadorExcepcion;
using SIMA.Log;

namespace SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancieros
{
	public class AdministarFormatoRubroDetalleMovimientoporMes : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		#region Constantes
		//Key Session y QueryString
		const string KEYQIDNOMBREFORMATO = "NFormato";
		const string KEYQIDFORMATO = "IdFormato";
		const string KEYQIDRUBRO= "IdRubro";
		const string KEYQRUBRONOMBRE= "RubroNombre";
		const string KEYQIDCENTRO = "IdCentro";
		const string KEYQIDTIPOINFO= "idTipoInfo";
		const string KEYQPERIODO= "Periodo";
		const string KEYQMES= "IdMes";
		const string KEYIDRUBRODETALLE= "idrDetalle";

		const string KEYQCUENTACONTABLE = "CtaCtble";
		const string CONTROLIMAGE = "imgVerDetalle";
		const string GRILLAVACIA="No exiets";

		const string CONTROLDDL1="ddblOperador";
		const string CONTROLDDL2="ddblCondicion";
		const string CONTROLTXT="txtCuenta";
		const string CONTROLCHK="chkActivo";

		const string URLDETALLE="DetalledeMovimientoporConcepto.aspx?";
		

		//Otros
		const string TITULOFORMATO ="FORMATO :";
		const string TITULOCONCEPTO ="CONCEPTO :";
		const string CTRLNMONTO ="nMonto";
		const string CTRLBUSCAR ="txtBuscar";
		const string TITULOTOOLTIP ="Doble click o Presionar la Tecla Ctrl para mostrar la Calculadora";

		//DataGrid and DataTable
		const string COLUMNAMODO ="Modo";
		const string COLUMNAIDRUBRODETALLE ="IdRubroDetalle";
		const string COLUMNAIDRUBRODETALLEMOV="idRubroDetalleMovimiento";
		const string COLUMNAMONTO ="Monto";
		#endregion

		#region Controles

		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.HtmlControls.HtmlTable TblTabs;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminaFiltro;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.ImageButton ibtnAgregar;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hTrama;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPaginaSort;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				if(!Page.IsPostBack)
				{
					this.ConfigurarAccesoControles();
					this.LlenarJScript();
					Helper.ReiniciarSession();
					this.LlenarDatos();
					this.LlenarGrillaOrdenamientoPaginacion("",0);
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
			this.ibtnEliminaFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminaFiltro_Click);
			this.ibtnAgregar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAgregar_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		private DataTable ObtenerDatos()
		{
			return ((CFormatoRubroDetalleMovimiento)  new CFormatoRubroDetalleMovimiento()).ConsultarFormatoRubroDetalleMovimiento(
				Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO])
				,Convert.ToInt32(Page.Request.Params[KEYQIDRUBRO])
				,Convert.ToInt32(Page.Request.Params[KEYQPERIODO])
				,Convert.ToInt32(Page.Request.Params[KEYQMES])
				,Convert.ToInt32(Page.Request.Params[KEYQIDCENTRO])
				,Convert.ToInt32(Page.Request.Params[KEYQIDTIPOINFO])
				,Utilitario.Constantes.IDDEFAULT)
				;
			
		}
		public void LlenarGrilla()
		{
			
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministarFormatoRubroDetalleMovimientoporMes.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dt= this.ObtenerDatos();
			if(dt!=null)
			{
				DataView dtv= dt.DefaultView;
				dtv.RowFilter = Helper.ObtenerFiltro();
				dtv.Sort = columnaOrdenar ;
				grid.DataSource = dtv;
				grid.CurrentPageIndex =indicePagina;
			}
			else
			{
				grid.DataSource = dt;
				lblResultado.Text = GRILLAVACIA;
			}
			grid.DataBind();
		}

		public void LlenarCombos()
		{
			// TODO:  Add AdministarFormatoRubroDetalleMovimientoporMes.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			this.Label1.Text = TITULOCONCEPTO + Page.Request.Params[KEYQRUBRONOMBRE].ToString().ToUpper();
		}

		public void LlenarJScript()
		{
			this.ibtnAgregar.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnMouseDown.ToString(),Utilitario.Constantes.POPUPDEESPERA + Helper.HistorialIrAdelantePersonalizado("hGridPaginaSort"));
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministarFormatoRubroDetalleMovimientoporMes.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministarFormatoRubroDetalleMovimientoporMes.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministarFormatoRubroDetalleMovimientoporMes.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			if(CNetAccessControl.FindPage(Page.Request.Url.AbsolutePath.ToString()))
			{CNetAccessControl.LoadControls(this);}
			else
			{CNetAccessControl.RedirectPageError();}
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add AdministarFormatoRubroDetalleMovimientoporMes.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;


				e.Item.Cells[0].Attributes.Add("Modo",dr[COLUMNAMODO].ToString());
				e.Item.Cells[0].Attributes.Add("idRubroDetalle",dr[COLUMNAIDRUBRODETALLE].ToString());
				e.Item.Cells[0].Attributes.Add("idRubroMovimiento",dr[COLUMNAIDRUBRODETALLEMOV].ToString());
				e.Item.Cells[0].Attributes.Add("MONTO",dr[COLUMNAMONTO].ToString());
				string ss = Convert.ToDouble(dr["Monto"]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				((eWorld.UI.NumericBox) e.Item.Cells[2].FindControl(CTRLNMONTO)).Text = Convert.ToDouble(dr[COLUMNAMONTO]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				((eWorld.UI.NumericBox) e.Item.Cells[2].FindControl(CTRLNMONTO)).Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnKeydown.ToString(),"EnfocarSiguienteCelda(this)");
				((eWorld.UI.NumericBox) e.Item.Cells[2].FindControl(CTRLNMONTO)).Attributes.Add(Utilitario.Enumerados.EventosJavaScript.Ondblclick.ToString(),"RedireccionarCalculadora(this)");
				((eWorld.UI.NumericBox) e.Item.Cells[2].FindControl(CTRLNMONTO)).ToolTip=TITULOTOOLTIP;

				Helper.ConfiguraColumnaHyperLink(e.Item.Cells[0],grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex,
					Helper.HistorialIrAdelantePersonalizado("hGridPaginaSort"),
					Helper.MostrarVentana(URLDETALLE,KEYQIDFORMATO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYQIDFORMATO].ToString()
													+ Utilitario.Constantes.SIGNOAMPERSON
													+ KEYQIDRUBRO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYQIDRUBRO].ToString()
													+ Utilitario.Constantes.SIGNOAMPERSON
													+ KEYQIDCENTRO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYQIDCENTRO].ToString()
													+ Utilitario.Constantes.SIGNOAMPERSON
													+ KEYQIDTIPOINFO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYQIDTIPOINFO].ToString()
													+ Utilitario.Constantes.SIGNOAMPERSON
													+ KEYQPERIODO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYQPERIODO].ToString()
													+ Utilitario.Constantes.SIGNOAMPERSON
													+ KEYQMES + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYQMES].ToString()
													+ Utilitario.Constantes.SIGNOAMPERSON 
													+ KEYIDRUBRODETALLE + Utilitario.Constantes.SIGNOIGUAL + dr[COLUMNAIDRUBRODETALLE].ToString()
													+ Utilitario.Constantes.SIGNOAMPERSON 
													+ KEYQRUBRONOMBRE + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYQRUBRONOMBRE].ToString()
													+ Utilitario.Constantes.SIGNOAMPERSON 
													+ Utilitario.Constantes.KEYMODOPAGINA +  Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.M.ToString()
													+ Utilitario.Constantes.SIGNOAMPERSON
													+ KEYQIDNOMBREFORMATO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYQIDNOMBREFORMATO].ToString()));

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				Helper.FiltroporSeleccionConfiguraColumna(e,grid,true,CTRLBUSCAR);
			}		
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void ibtnAgregar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Page.Response.Redirect(URLDETALLE + KEYQIDFORMATO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYQIDFORMATO].ToString()
													+ Utilitario.Constantes.SIGNOAMPERSON
													+ KEYQIDRUBRO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYQIDRUBRO].ToString()
													+ Utilitario.Constantes.SIGNOAMPERSON
													+ KEYQIDCENTRO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYQIDCENTRO].ToString()
													+ Utilitario.Constantes.SIGNOAMPERSON
													+ KEYQIDTIPOINFO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYQIDTIPOINFO].ToString()
													+ Utilitario.Constantes.SIGNOAMPERSON
													+ KEYQPERIODO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYQPERIODO].ToString()
													+ Utilitario.Constantes.SIGNOAMPERSON
													+ KEYQMES + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYQMES].ToString()
													+ Utilitario.Constantes.SIGNOAMPERSON 
													+ KEYQRUBRONOMBRE + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYQRUBRONOMBRE].ToString()
													+ Utilitario.Constantes.SIGNOAMPERSON 
													+ Utilitario.Constantes.KEYMODOPAGINA +  Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.N.ToString()
													+ Utilitario.Constantes.SIGNOAMPERSON 
													+ KEYQIDNOMBREFORMATO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYQIDNOMBREFORMATO].ToString()
													);
		}

		#region IPaginaMantenimento Members
		public void Agregar()
		{
		}
		public void Modificar()
		{
		}


		public void Eliminar()
		{
			// TODO:  Add AdministarFormatoRubroDetalleMovimientoporMes.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			// TODO:  Add AdministarFormatoRubroDetalleMovimientoporMes.CargarModoPagina implementation
		}

		public void CargarModoNuevo()
		{
			// TODO:  Add AdministarFormatoRubroDetalleMovimientoporMes.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			// TODO:  Add AdministarFormatoRubroDetalleMovimientoporMes.CargarModoModificar implementation
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add AdministarFormatoRubroDetalleMovimientoporMes.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add AdministarFormatoRubroDetalleMovimientoporMes.ValidarCampos implementation
			return false;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add AdministarFormatoRubroDetalleMovimientoporMes.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add AdministarFormatoRubroDetalleMovimientoporMes.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion

		private void ibtnEliminaFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.hGridPagina.Value = e.NewPageIndex.ToString();
			this.LlenarGrillaOrdenamientoPaginacion(this.hGridPaginaSort.Value,e.NewPageIndex);		
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			hGridPaginaSort.Value = Helper.GenerarExpresionOrdenamiento(e.SortExpression);
			this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Helper.ObtenerIndicePagina());		
		}
	}
}