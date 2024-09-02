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
using SIMA.Log;
using SIMA.SimaNetWeb.InterfacesIU;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.EntidadesNegocio.Secretaria ;
using NetAccessControl;
using MetaBuilders.WebControls;


namespace SIMA.SimaNetWeb.GestionComercial
{
	/// <summary>
	/// Summary description for BusquedaOrdenTrabajo.
	/// </summary>
	public class BusquedaOrdenTrabajo : System.Web.UI.Page,IPaginaBase	
	{
		#region controles

		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblCentroOperativo;
		protected System.Web.UI.WebControls.Label lblDivision;
		protected System.Web.UI.WebControls.Label lblnRoOt;
		protected System.Web.UI.WebControls.DropDownList ddlbCentroOperativo;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvCentroOperativo;
		protected System.Web.UI.WebControls.DropDownList ddlbDivision;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvDivision;
		protected eWorld.UI.NumericBox nbOt;
		protected System.Web.UI.WebControls.ImageButton btnBuscar;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary vSum;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdValorizacionOrdenTrabajo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hNroOt;
		protected System.Web.UI.WebControls.ImageButton ibtnCancelar;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		static string OtConcatenada;

		#endregion controles
	
		#region constantes

		//Ordenamiento
		const string COLORDENAMIENTO = "IdValorizacionOrdenTrabajo";
		const string FORMATOOT = "000000";

		//Cadenas
		const string LISTAVACIA ="No existen Divisiones para ";
		const string GRILLAVACIA ="No existen ninguna Orden de Trabajo con los filtros seleccionados.";  
		
		//JScript

		string JSCERRARVENTANA = "return CerrarVentana();";

		#endregion constantes
		
		#region Variables

		ListItem  lItem ;

		#endregion Variables

		private void llenarCentroOperativo()
		{
			CCentroOperativo oCCentroOperativo =  new CCentroOperativo();
			ddlbCentroOperativo.DataSource = oCCentroOperativo.ListarTodosCombo();
			ddlbCentroOperativo.DataValueField=Enumerados.ColumnasCentroOperativo.IdCentroOperativo.ToString();
			ddlbCentroOperativo.DataTextField=Enumerados.ColumnasCentroOperativo.Nombre.ToString();
			ddlbCentroOperativo.DataBind();
			ddlbCentroOperativo.Items.RemoveAt(0);
		}

		private void llenarTipoArea()
		{
			CArea oCArea = new CArea();
			ddlbDivision.DataSource= oCArea.ListarAreaPorTipo(Convert.ToInt32(ddlbCentroOperativo.SelectedValue),Convert.ToInt32(Utilitario.Enumerados.TiposAreas.Division));
			ddlbDivision.DataValueField=Utilitario.Enumerados.ColumnasArea.IdDivision.ToString();
			ddlbDivision.DataTextField =Utilitario.Enumerados.ColumnasArea.Nombre.ToString();
			ddlbDivision.DataBind();
			
			if (ddlbDivision.Items.Count == 0)
			{
				this.ltlMensaje.Text= Helper.MensajeAlert(LISTAVACIA + ddlbCentroOperativo.SelectedItem.Text);
			}
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					
					this.LlenarJScript();

					Helper.ReiniciarSession();

					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Comercial",this.ToString(),"Se realizó búsqueda de Centro Costo.",Enumerados.NivelesErrorLog.I.ToString()));

					this.LlenarCombos();
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
			this.ddlbCentroOperativo.SelectedIndexChanged += new System.EventHandler(this.SelectedIndex_CentroOperativo);
			this.ddlbDivision.SelectedIndexChanged += new System.EventHandler(this.SelectedIndex_Division);
			this.btnBuscar.Click += new System.Web.UI.ImageClickEventHandler(this.btnBuscar_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.ibtnAceptar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAceptar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void SelectedIndex_CentroOperativo(object sender, System.EventArgs e)
		{
			this.ddlbDivision.Items.Clear();
			lItem = new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR ,Utilitario.Constantes.VALORSELECCIONAR);
			this.llenarTipoArea();
			this.ddlbDivision.Items.Insert(0,lItem);
		}
		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add BusquedaOrdenTrabajo.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add BusquedaOrdenTrabajo.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			try
			{
				if(this.nbOt.Text != "")
				{
					OtConcatenada += Convert.ToInt32(this.nbOt.Text).ToString(FORMATOOT);
				}
				COrdenTrabajo oCOrdenTrabajo =  new COrdenTrabajo();
				DataTable dtOrdenTrabajo =  oCOrdenTrabajo.ConsultarCentroCostos(Convert.ToInt32(this.ddlbCentroOperativo.SelectedValue),OtConcatenada);
				
				if(dtOrdenTrabajo!=null)
				{
					DataView dwOrdenTrabajo = dtOrdenTrabajo.DefaultView;
					dwOrdenTrabajo.Sort = columnaOrdenar;
					grid.DataSource = dwOrdenTrabajo;
					lblResultado.Visible = false;
				}
				else
				{
					grid.DataSource = dtOrdenTrabajo;
					lblResultado.Text = GRILLAVACIA;
					lblResultado.Visible = true;
				}
				
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
			lItem = new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,Utilitario.Constantes.VALORSELECCIONAR);
			this.llenarCentroOperativo();
			this.ddlbCentroOperativo.Items.Insert(0,lItem);
		}

		public void LlenarDatos()
		{
			// TODO:  Add BusquedaOrdenTrabajo.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			this.ibtnCancelar.Attributes.Add(Constantes.EVENTOCLICK,JSCERRARVENTANA);

			this.rfvCentroOperativo.ErrorMessage = Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJESELECCIONCENTROOPERATIVO);
			this.rfvCentroOperativo.ToolTip = Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJESELECCIONCENTROOPERATIVO);
			this.rfvCentroOperativo.InitialValue = Constantes.VALORSELECCIONAR;

			this.rfvDivision.ErrorMessage = Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJESELECCIONDIVISION);
			this.rfvDivision.ToolTip = Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJESELECCIONDIVISION);
			this.rfvDivision.InitialValue = Constantes.VALORSELECCIONAR;
		}

		public void RegistrarJScript()
		{
			// TODO:  Add BusquedaOrdenTrabajo.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add BusquedaOrdenTrabajo.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add BusquedaOrdenTrabajo.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add BusquedaOrdenTrabajo.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			return false;
		}

		#endregion

		private void btnBuscar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				if(Page.IsValid)
				{
					if(this.ValidarCampos())
					{	
						//Graba en el Log la acción ejecutada
						LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Comercial",this.ToString(),"Busqueda de Ordenes de Trabajo.",Enumerados.NivelesErrorLog.I.ToString()));
						
						this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO),Utilitario.Constantes.INDICEPAGINADEFAULT);	
					}
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

		public bool ValidarCampos()
		{
			if(this.ValidarCamposRequeridos())
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public bool ValidarCamposRequeridos()
		{
			if (this.ddlbCentroOperativo.SelectedItem.Text == Utilitario.Constantes.TEXTOSSELECCIONAR)	
			{
				ltlMensaje.Text =  Helper.ObtenerMensajesConfirmacionUsuario(Utilitario.Mensajes.CODIGOMENSAJESELECCIONCENTROOPERATIVO);
				return false;
			}
			if (this.ddlbDivision.SelectedItem.Text == Utilitario.Constantes.TEXTOSSELECCIONAR)	
			{
				ltlMensaje.Text =  Helper.ObtenerMensajesConfirmacionUsuario(Utilitario.Mensajes.CODIGOMENSAJESELECCIONDIVISION);
				return false;
			}
			return true;
		}

		private void SelectedIndex_Division(object sender, System.EventArgs e)
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			DataView dv = oCTablaTablas.ListaSegunCriterioFiltro(Convert.ToInt32(Enumerados.TablasTabla.DivisionesOt),Enumerados.ColumnasTablaTablas.Codigo.ToString()+Constantes.SIGNOIGUAL+this.ddlbDivision.SelectedValue.ToString());
			OtConcatenada = dv[0].Row[Enumerados.ColumnasTablaTablas.Var1.ToString()].ToString();
		}

		private void ibtnAceptar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if(hIdValorizacionOrdenTrabajo.Value.Length==0)
			{
				ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO));
			}
			else
			{
				ltlMensaje.Text = Constantes.PONERTEXTO;
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

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,
					Utilitario.Helper.MostrarDatosEnCajaTexto("hIdValorizacionOrdenTrabajo",dr[Enumerados.ColumnasBusquedaOrdenTrabajo.IdValorizacionOrdenTrabajo.ToString()].ToString()),
					Utilitario.Helper.MostrarDatosEnCajaTexto("hNroOt",dr[Enumerados.ColumnasBusquedaOrdenTrabajo.NroOrdenTrabajo.ToString()].ToString())
					);
			}
		}
	}
}