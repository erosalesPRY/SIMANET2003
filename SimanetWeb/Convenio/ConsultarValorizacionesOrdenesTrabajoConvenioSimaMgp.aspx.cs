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
namespace SIMA.SimaNetWeb.Convenio
{
	/// <summary>
	/// Summary description for RequerimientosAsignados.
	/// </summary>
	public class ConsultarValorizacionesOrdenesTrabajoConvenioSimaMgp: System.Web.UI.Page,IPaginaBase	
	{
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.HtmlControls.HtmlForm Form2;
		protected System.Web.UI.WebControls.Label lblDescripcion;
		protected System.Web.UI.WebControls.Label lblUnidadNaval;
		protected System.Web.UI.WebControls.Label lblPresupuesto;
		protected projDataGridWeb.DataGridWeb dgOrdenTrabajo;
		protected System.Web.UI.WebControls.TextBox txtUnidadNaval;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.Label lblProyectoDescripcion;
		protected System.Web.UI.WebControls.TextBox txtProyectoDescripcion;
		protected System.Web.UI.WebControls.Label lblTituloSecundario;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.DropDownList ddlbCentroOperativo;
		protected System.Web.UI.WebControls.Label lblEstado;
		protected System.Web.UI.WebControls.DropDownList ddlbEstado;
		protected System.Web.UI.WebControls.Button btnConsultar;
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		
					
				
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					this.LlenarJScript();
					Helper.ReiniciarSession();
					this.LlenarCombos();
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
			this.dgOrdenTrabajo.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.dgOrdenTrabajo_SortCommand);
			this.dgOrdenTrabajo.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgOrdenTrabajo_PageIndexChanged);
			this.dgOrdenTrabajo.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgOrdenTrabajo_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region Constante
		const string GRILLAVACIA="No hay ordenes de trabajo según el criterio especificado";
		const int IDESTADOVALORIZACIONORDENTRABAJOCONVENIO=94;
		const string COLORDENAMIENTO="NROVALORIZACION";
		const int CONSULTARTODO = 0;

		//KEY
		const string KEYIDPROYECTOCONVENIO="IdProyectoConvenio";
		const string KEYQTITULOPRINCIPAL="TituloPrincipal";
		const string KEYQPROYECTODESCRIPCION="Descripcion";
		const string URLIMPRESION="";
		const string KEYIDCONVENIOSIMAMGP="IdConvenioSimaMgp";

		const string URLPRINCIPAL="ConsultarProyectosConvenioSimaMgp.aspx?";
		const int POSICIONINICIALCOMBO=0;

		#endregion Constante

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add ConsultarValorizacionesOrdenesTrabajoConvenioSimaMgp.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			CConvenioSimaMgp oConvenioSimaMgp=new CConvenioSimaMgp();
			DataTable dtOrdenTrabajo=oConvenioSimaMgp.ConsultarOrdenesDeTrabajoDeUnProyectoDeConvenio(Convert.ToInt32(Page.Request.Params[KEYIDPROYECTOCONVENIO]),this.ddlbEstado.SelectedValue,CONSULTARTODO,Convert.ToInt32(this.ddlbCentroOperativo.SelectedValue));
			this.LimpiarControlesDetalle();
			
			if(dtOrdenTrabajo!=null)
			{
				DataView dwOrdenTrabajo = dtOrdenTrabajo.DefaultView;
				dwOrdenTrabajo.Sort = columnaOrdenar;
				dgOrdenTrabajo.DataSource = dwOrdenTrabajo;

				dgOrdenTrabajo.Columns[1].FooterText = dwOrdenTrabajo.Count.ToString();

				CImpresion oCImpresion = new CImpresion();
				oCImpresion.GuardarDataImprimirExportar(dtOrdenTrabajo,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGOTITULOREPORTEACCIONCONTROLNOPROGRAMADA),columnaOrdenar,indicePagina);
				ibtnImprimir.Visible = true;
				lblResultado.Visible = false;

			}
			else
			{
				dgOrdenTrabajo.DataSource = dtOrdenTrabajo;
				lblResultado.Visible = true;
				lblResultado.Text = GRILLAVACIA;
				ibtnImprimir.Visible = false;
			}
			try
			{
				dgOrdenTrabajo.DataBind();
			}
			catch	
			{
				dgOrdenTrabajo.CurrentPageIndex = 0;
				dgOrdenTrabajo.DataBind();
			}
		}

	
		public void LlenarCombos()
		{
			// TODO:  Add ConsultarValorizacionesOrdenesTrabajoConvenioSimaMgp.LlenarCombos implementation
			this.LlenarEstado();
			this.CentroOperativoSima();
		}
	
		public void LlenarDatos()
		{
			this.lblTitulo.Text = Convert.ToString(Page.Request.Params[KEYQTITULOPRINCIPAL]);
			this.txtProyectoDescripcion.Text = Convert.ToString(Page.Request.Params[KEYQPROYECTODESCRIPCION]);
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarValorizacionesOrdenesTrabajoConvenioSimaMgp.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarValorizacionesOrdenesTrabajoConvenioSimaMgp.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			//ltlMensaje.Text = Helper.PopupImpresion(URLIMPRESION,650,700,false,false,false,true,true);

		}

		public void Exportar()
		{
			// TODO:  Add ConsultarValorizacionesOrdenesTrabajoConvenioSimaMgp.Exportar implementation
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
			// TODO:  Add ConsultarValorizacionesOrdenesTrabajoConvenioSimaMgp.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void LimpiarControlesDetalle()
		{
			this.txtUnidadNaval.Text="";
			this.txtDescripcion.Text="";
		}

		private void ibtnImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Imprimir();
		}

		private void dgOrdenTrabajo_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType==ListItemType.Header)
			{
				e.Item.Cells[1].ToolTip=Utilitario.Constantes.ProyectoToolTipValorizacion;
				e.Item.Cells[2].ToolTip=Utilitario.Constantes.ProyectoToolTipOrdenTrabajo;
				e.Item.Cells[3].ToolTip=Utilitario.Constantes.ProyectoToolTipAlias;
				e.Item.Cells[4].ToolTip=Utilitario.Constantes.ProyectoToolTipMontoPresupuesto;
				e.Item.Cells[5].ToolTip=Utilitario.Constantes.ProyectoToolTipEstado;
				e.Item.Cells[6].ToolTip=Utilitario.Constantes.ProyectoToolTipAvancaFisicoActual;
			}
			else if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				
				string Cadena="";

						
				Cadena= "MostrarDatosEnCajaTexto('txtUnidadNaval','" + Convert.ToString(dr[Enumerados.ColumnasValorizacionOrdenTrabajo.UnidadNaval.ToString()]) + " '); " +
						"MostrarDatosEnCajaTexto('txtDescripcion','" + Helper.LimpiarTexto(Convert.ToString(dr[Enumerados.ColumnasValorizacionOrdenTrabajo.Descripcion.ToString()])) +" '); " + 
						"LlenarCeldaTabla('" + Convert.ToDouble(dr[Enumerados.ColumnasValorizacionOrdenTrabajo.MontoPrecioVentaSoles.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4) + "');";

				
						Utilitario.Helper.SeleccionarItemGrillaOnClickMoverRaton(e,Cadena);
				
				e.Item.Cells[0].Text = Helper.ObtenerIndicedeRegistro(dgOrdenTrabajo.CurrentPageIndex,dgOrdenTrabajo.PageSize,e.Item.ItemIndex);
						
			}
		}

		private void RedireccionarPaginaPrevia()
		{
			this.Page.Response.Redirect(URLPRINCIPAL + KEYIDCONVENIOSIMAMGP + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYIDCONVENIOSIMAMGP]);
		}


		private void CentroOperativoSima()
		{
			ListItem lItem = new ListItem();
			SIMA.Controladoras.General.CCentroOperativo oCCentroOperativo=new CCentroOperativo();
			DataTable dt=oCCentroOperativo.ListarTodosCombo();
			this.ddlbCentroOperativo.DataSource=dt;
			this.ddlbCentroOperativo.DataValueField=Enumerados.ColumnasCentroOperativo.IdCentroOperativo.ToString();
			this.ddlbCentroOperativo.DataTextField=Enumerados.ColumnasCentroOperativo.Descripcion.ToString();
			this.ddlbCentroOperativo.DataBind();
			lItem=this.ddlbCentroOperativo.Items.FindByValue(Convert.ToInt32(Utilitario.Enumerados.IdCentroOperativo.SimaPeru).ToString());
			this.ddlbCentroOperativo.Items.Remove(lItem);
			lItem=this.ddlbCentroOperativo.Items.FindByValue(Convert.ToInt32(Utilitario.Enumerados.IdCentroOperativo.SimaCallao).ToString());
			if(lItem!=null)
			{
				lItem.Selected=true;
			}
		}

		private void LlenarEstado()
		{
			//Utilitario.Constantes.TEXTOSSELECCIONAR,Utilitario.Constantes.VALORSELECCIONAR
			ListItem lItem = new ListItem();
			lItem.Text=Utilitario.Constantes.TEXTOTODOS;
			lItem.Value=Utilitario.Constantes.VALORTODOS;
			
			CTablaTablas oCTablaTablas=new CTablaTablas();
			DataTable dt=oCTablaTablas.ListaTodosCombo(IDESTADOVALORIZACIONORDENTRABAJOCONVENIO);
			this.ddlbEstado.DataSource=dt;
			this.ddlbEstado.DataValueField=Enumerados.ColumnasTablaTablas.Codigo.ToString();
			this.ddlbEstado.DataTextField=Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			this.ddlbEstado.DataBind();
			this.ddlbEstado.Items.Insert(POSICIONINICIALCOMBO,lItem);

			//lItem.Text=Utilitario.Constantes.TEXTOSSELECCIONAR;
			//lItem.Value=Utilitario.Constantes.VALORSELECCIONAR;
			//this.ddlbEstado.Items.Add(lItem);

		}

		private void btnConsultar_Click(object sender, System.EventArgs e)
		{
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Convenio Sima - MGP",this.ToString(),"Se consultó las Ordenes de Trabajo.",Enumerados.NivelesErrorLog.I.ToString()));

			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO),Utilitario.Constantes.INDICEPAGINADEFAULT);
		}

		private void dgOrdenTrabajo_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(e.SortExpression),Helper.ObtenerIndicePagina());
		}

		private void dgOrdenTrabajo_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			dgOrdenTrabajo.CurrentPageIndex=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);
		}

	}
}

