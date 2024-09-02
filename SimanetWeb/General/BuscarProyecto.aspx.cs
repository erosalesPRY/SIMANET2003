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
using SIMA.Controladoras.General;
using SIMA.Controladoras.Proyectos;
using SIMA.SimaNetWeb.InterfacesIU;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using NullableTypes;
using MetaBuilders.WebControls;

namespace SIMA.SimaNetWeb.General
{
	public class BuscarProyecto : System.Web.UI.Page
	{
		#region Controles
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.DropDownList ddlTipoProyecto;
		protected System.Web.UI.WebControls.Label lblTipoProyecto;
		protected System.Web.UI.WebControls.Label lblTitulo;
		#endregion

		#region Constantes
		private int idTablaTipoProyecto=35;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdProyecto;
		protected System.Web.UI.WebControls.Image imgCancelar;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hNombre;

		protected System.Web.UI.WebControls.ImageButton imgAceptar;

		protected System.Web.UI.HtmlControls.HtmlImage ibtnCancelar;
		protected System.Web.UI.WebControls.Label lblApellidoPaterno;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.ImageButton btnBuscar;
		private const string GRILLAVACIA ="No existen registros";
		#endregion
	
		#region Eventos
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.LlenarJScript();
					this.LlenarCombos();
					Helper.ReiniciarSession();
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

		private void btnBuscar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			LlenarGrillaOrdenamientoPaginacion("",0);
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,
					Utilitario.Helper.MostrarDatosEnCajaTexto(hIdProyecto.ID,dr["IdProyecto"].ToString()) + 
					Utilitario.Constantes.SIGNOPUNTOYCOMA + 
					Utilitario.Helper.MostrarDatosEnCajaTexto(hNombre.ID,dr["descripcion"].ToString())
					);			
			}
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			grid.CurrentPageIndex = e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion("",e.NewPageIndex);
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(e.SortExpression),Helper.ObtenerIndicePagina());
		}
		#endregion

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
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.imgAceptar.Click += new System.Web.UI.ImageClickEventHandler(this.imgAceptar_Click);
			this.btnBuscar.Click += new System.Web.UI.ImageClickEventHandler(this.btnBuscar_Click);
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
			CProyectos oCProyectos = new CProyectos();
			//DataTable dtPersonal =  oCProyectos.ConsultarProyectosPorEstadoyDescripcion(Convert.ToInt32(ddlTipoProyecto.SelectedValue),txtDescripcion.Text);
			DataTable dtPersonal =  oCProyectos.ConsultarProyectosPorEstadoyDescripcion(99,txtDescripcion.Text);

			if(dtPersonal!=null)
			{
				DataView dwPersonal = dtPersonal.DefaultView;
				grid.Columns[1].FooterText = dtPersonal.Rows.Count.ToString();
				dwPersonal.Sort = columnaOrdenar ;			
				grid.DataSource = dwPersonal;
				lblResultado.Text = Utilitario.Constantes.VACIO;
			}
			else
			{
				grid.DataSource = dtPersonal;
				lblResultado.Text = GRILLAVACIA;
			}
			try
			{
				grid.DataBind();
			}

			catch (Exception e)
			{
				string a = e.Message;
				grid.CurrentPageIndex = 0;
				grid.DataBind();
			}
		}

		public void LlenarCombos()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			ddlTipoProyecto.DataSource = oCTablaTablas.ListaTodosCombo(idTablaTipoProyecto);
			ddlTipoProyecto.DataTextField = "Descripcion";
			ddlTipoProyecto.DataValueField = "Codigo";
			ddlTipoProyecto.DataBind();
		}

		public void LlenarJScript()
		{
			//this.imgAceptar.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,"PonerTexto();");
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

		private void imgAceptar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			ltlMensaje.Text = "PonerTexto()";
		}

		



	}
}
