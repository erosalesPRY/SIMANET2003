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
using NullableTypes;
using MetaBuilders.WebControls;

namespace SIMA.SimaNetWeb.Convenio
{
	/// <summary>
	/// Summary description for AdministrarConceptosPorPagar.
	/// </summary>
	public class AdministrarConceptosPorPagar : System.Web.UI.Page, IPaginaBase
	{
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminar;
		protected System.Web.UI.WebControls.ImageButton ibtnAgregar;
		protected System.Web.UI.WebControls.Label lblPeriodoInicial;
		protected System.Web.UI.WebControls.DropDownList ddlbPeriodoInicial;
		protected System.Web.UI.WebControls.Label lblPeriodoFinal;
		protected System.Web.UI.WebControls.DropDownList ddlbPeriodoFinal;
		protected System.Web.UI.WebControls.Button btnConsultar;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.DomValidators.CompareDomValidator cbvPeriodos;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary DomValidationSummary1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.WebControls.Label lblPagina;

		
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
			this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
			this.ibtnAgregar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAgregar_Click);
			this.ibtnEliminar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminar_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarJScript();
					this.ReiniciarCampos();
					this.LlenarCombos();
					this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO,false),Utilitario.Constantes.INDICEPAGINADEFAULT);

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

		#region Constantes
		const string COLORDENAMIENTO="Periodo";
		const string URLIMPRESION="";
		//OTROS
		const string GRILLAVACIA="NO HAY REGISTROS";

		string JSVERIFICARELIMINAR = "return verificarEliminarRb('hCodigo','" + Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO)+"','"+Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJEPREGUNTAELIMINACIONREGISTRO)+"');";

		//Controles
		const string CONTROLINK="hlkId";

		//URL
		const string URLDETALLECONCEPTOSPORPAGAR="DetalleConceptosPorPagar.aspx";
		const string KEYIDCONCEPTOPORPAGAR="IdConceptoPorPagar";

		#endregion Constantes

		private string SeleccionPeriodoInicial(int pPeriodoInicial)
		{
			int SeleccionPeriodoInicial;
			if((DateTime.Now.Year-4)<=pPeriodoInicial)
			{
				SeleccionPeriodoInicial=pPeriodoInicial;
			}
			else
			{
				SeleccionPeriodoInicial=DateTime.Now.Year-4;
			}

			return SeleccionPeriodoInicial.ToString();
		}

		private void LlenarPeriodos()
		{
			ddlbPeriodoInicial.DataSource = Helper.ObtenerPeriodos(2001,DateTime.Now.Year);
			ddlbPeriodoInicial.DataBind();

			ddlbPeriodoFinal.DataSource=Helper.ObtenerPeriodos(2001,DateTime.Now.Year);
			ddlbPeriodoFinal.DataBind();
		}

		private void Eliminar()
		{
			if(!NullableString.Parse(this.hCodigo.Value).IsNull)
			{
				int IdConcepto = Convert.ToInt32(this.hCodigo.Value);
				this.ReiniciarCampos();
				CConceptosPorPagar oCConceptosPorPagar=new CConceptosPorPagar();

				int retorno=oCConceptosPorPagar.Eliminar(IdConcepto,CNetAccessControl.GetIdUser());

				if(retorno>0)
				{
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Convenio",this.ToString(),"Se eliminó el Proyecto ID = " + IdConcepto.ToString() +"." ,Enumerados.NivelesErrorLog.I.ToString()));
				
					this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),Helper.ObtenerIndicePagina());
						
					ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONELIMINACIONREGISTRO));
				}
			}
			else
			{
				ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO));
			}

		}

		private void RedireccionarPaginaAgregar()
		{
			this.Page.Response.Redirect(URLDETALLECONCEPTOSPORPAGAR + "?" + Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Enumerados.ModoPagina.N);
		}

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add AdministrarConceptosPorPagar.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarConceptosPorPagar.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			CConceptosPorPagar oCConceptosPorPagar=new CConceptosPorPagar();

			int PeriodoInicial=Convert.ToInt32(ddlbPeriodoInicial.SelectedItem.Text);
			int PeriodoFinal=Convert.ToInt32(ddlbPeriodoFinal.SelectedItem.Text);

			DataTable dtConceptoPagar = oCConceptosPorPagar.ListarConceptosPorPagarSegunPeriodo(PeriodoInicial,PeriodoFinal);

			this.ReiniciarCampos();

			if(dtConceptoPagar!=null)
			{
				DataView dwConceptoPagar = dtConceptoPagar.DefaultView;
				dwConceptoPagar.Sort = columnaOrdenar;
				grid.DataSource = dwConceptoPagar;

				grid.Columns[1].FooterText = dwConceptoPagar.Count.ToString();

				CImpresion oCImpresion = new CImpresion();
				oCImpresion.GuardarDataImprimirExportar(dtConceptoPagar,"REPORTE DE " + lblTitulo.Text,columnaOrdenar,indicePagina);
				lblResultado.Visible = false;
				ibtnImprimir.Visible = true;
			}
			else
			{
				grid.DataSource = dtConceptoPagar;
				lblResultado.Visible = true;
				lblResultado.Text = GRILLAVACIA;
				ibtnImprimir.Visible = false;
			
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
			this.LlenarPeriodos();
			Utilitario.Helper.SeleccionarItemCombos(this);
		}

		public void LlenarDatos()
		{
			
		}

		public void LlenarJScript()
		{
			cbvPeriodos.ErrorMessage=Helper.ObtenerMensajesConfirmacionConvenioUsuario(Mensajes.CODIGOMENSAJEUNIDADAPOYOCOMOPERPACPERIODO);
			ibtnEliminar.Attributes.Add("onclick",JSVERIFICARELIMINAR);
			ibtnAgregar.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarConceptosPorPagar.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministrarConceptosPorPagar.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarConceptosPorPagar.Exportar implementation
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
			// TODO:  Add AdministrarConceptosPorPagar.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void btnConsultar_Click(object sender, System.EventArgs e)
		{
			Helper.ReiniciarSession();
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO,false),Utilitario.Constantes.INDICEPAGINADEFAULT);
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				
				HyperLink hlk = (HyperLink)e.Item.Cells[1].FindControl(CONTROLINK);
				hlk.Text = Convert.ToString(dr[Enumerados.ColumnasConceptosPorPagar.Periodo.ToString()]);

				hlk.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
				hlk.NavigateUrl = URLDETALLECONCEPTOSPORPAGAR + "?" + Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Enumerados.ModoPagina.M + Utilitario.Constantes.SIGNOAMPERSON + KEYIDCONCEPTOPORPAGAR + Utilitario.Constantes.SIGNOIGUAL + dr[Utilitario.Enumerados.ColumnasConceptosPorPagar.IdConceptoPorPagar.ToString()].ToString();

				string Cadena="AccionSeleccionFila('hCodigo',"+Convert.ToString(dr[Utilitario.Enumerados.ColumnasConceptosPorPagar.IdConceptoPorPagar.ToString()])+");";

				Utilitario.Helper.SeleccionarItemGrillaOnClickMoverRaton(e,Cadena);
				e.Item.Cells[0].ForeColor=Color.Blue;
				e.Item.Cells[0].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);

			}
		}

		private void ibtnEliminar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Eliminar();
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(e.SortExpression),Helper.ObtenerIndicePagina());
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.grid.CurrentPageIndex=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);
		}

		private void ibtnAgregar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.RedireccionarPaginaAgregar();
		}

		private void ReiniciarCampos()
		{
			this.hCodigo.Value="";
		}
	}
}
