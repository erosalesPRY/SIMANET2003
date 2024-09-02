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
using NetAccessControl;
using MetaBuilders.WebControls;

namespace SIMA.SimaNetWeb.GestionComercial
{
	/// <summary>
	/// Summary description for BusquedaCentroCosto.
	/// </summary>
	public class BusquedaCentroCosto : System.Web.UI.Page,IPaginaBase
	{
		#region controles 
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.DropDownList ddlbGrupoCentroCosto;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblGrupoCC;
		protected System.Web.UI.WebControls.Label lblCentroOperativo;
		protected System.Web.UI.WebControls.DropDownList ddlbCentroOperativo;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvCentroOperativo;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary vSum;
		protected System.Web.UI.WebControls.ImageButton btnBuscar;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdCentroCosto;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCentroCosto;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdGrupoCentroCosto;
		protected System.Web.UI.WebControls.ImageButton ibtnCancelar;
		
		#endregion controles
		
		#region constantes

		//Ordenamiento
		const string COLORDENAMIENTO = "Nombre";

		//Cadenas
		const string LISTAVACIA ="No existen Grupos de Centro Costo para ";  
		const string GRILLAVACIA ="No existen ningún Centro de Costo.";  
		
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

		private void llenarGrupoCentroCosto()
		{
			CGrupoCentroCosto oCGrupoCentroCosto = new CGrupoCentroCosto();
			ddlbGrupoCentroCosto.DataSource= oCGrupoCentroCosto.ListarGrupoCCPorCentroOperativo(Convert.ToInt32(ddlbCentroOperativo.SelectedValue));
			ddlbGrupoCentroCosto.DataValueField=Utilitario.Enumerados.ColumnasGrupoCentroCosto.IdGrupoCC.ToString();
			ddlbGrupoCentroCosto.DataTextField =Utilitario.Enumerados.ColumnasGrupoCentroCosto.Nombre.ToString();
			ddlbGrupoCentroCosto.DataBind();

			if (ddlbGrupoCentroCosto.Items.Count == 0)
			{
				this.ltlMensaje.Text= Helper.MensajeAlert(LISTAVACIA + ddlbCentroOperativo.SelectedItem.Text);
			}
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
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
			this.ddlbCentroOperativo.SelectedIndexChanged += new System.EventHandler(this.Seleccionar_GrupoCCPorCO);
			this.btnBuscar.Click += new System.Web.UI.ImageClickEventHandler(this.btnBuscar_click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.ibtnAceptar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAceptar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add BusquedaCentroCosto.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add BusquedaCentroCosto.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			CCentroCosto oCCentroCosto =  new CCentroCosto();
			DataTable dtCentroCosto =  oCCentroCosto.ListarCentroCostoPorGrupoCC(Convert.ToInt32(ddlbGrupoCentroCosto.SelectedValue));

			if(dtCentroCosto!=null)
			{
				DataView dwCentroCosto = dtCentroCosto.DefaultView;
				dwCentroCosto.Sort = columnaOrdenar;
				grid.DataSource = dwCentroCosto;
				lblResultado.Visible = false;
			}
			else
			{
				grid.DataSource = dtCentroCosto;
				lblResultado.Text = GRILLAVACIA;
				lblResultado.Visible = true;
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
			lItem = new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR ,Utilitario.Constantes.VALORSELECCIONAR  );
			this.llenarCentroOperativo();
			this.ddlbCentroOperativo.Items.Insert(0,lItem);
		}

		public void LlenarDatos()
		{
			// TODO:  Add BusquedaCentroCosto.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			rfvCentroOperativo.ErrorMessage = Helper.ObtenerMensajesConfirmacionUsuario(Utilitario.Mensajes.CODIGOMENSAJESELECCIONCENTROOPERATIVO);
			rfvCentroOperativo.ToolTip = Helper.ObtenerMensajesConfirmacionUsuario(Utilitario.Mensajes.CODIGOMENSAJESELECCIONCENTROOPERATIVO); 
			rfvCentroOperativo.InitialValue = Utilitario.Constantes.VALORSELECCIONAR;
			this.ibtnCancelar.Attributes.Add(Constantes.EVENTOCLICK,JSCERRARVENTANA);
		}

		public void RegistrarJScript()
		{
			// TODO:  Add BusquedaCentroCosto.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add BusquedaCentroCosto.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add BusquedaCentroCosto.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add BusquedaCentroCosto.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add BusquedaCentroCosto.ValidarFiltros implementation
			return false;
		}

		#endregion

     	#region IPaginaMantenimiento Members

		public void Agregar()
		{}

		public void Modificar()
		{
		}

		public void Eliminar()
		{
		}

		public	void CargarModoPagina()
		{
		}

		public void CargarModoNuevo()
		{
		}

		public	void CargarModoModificar()
		{
		}

		public void CargarModoConsulta()
		{
		}
		
		public bool ValidarCampos()
		{
			if(this.ValidarCamposRequeridos())
			{
				return this.ValidarExpresionesRegulares();
			}
			else
			{
				return false;
			}
		}

		public bool ValidarCamposRequeridos()
				
		{	if (ddlbCentroOperativo.SelectedItem.Text == Utilitario.Constantes.TEXTOSSELECCIONAR)
				
			{
				ltlMensaje.Text =  Helper.ObtenerMensajesConfirmacionUsuario(Utilitario.Mensajes.CODIGOMENSAJESELECCIONCENTROOPERATIVO);
				return false;		
			}
		
			return true;
		}

		public bool ValidarExpresionesRegulares()
		{
			return true;
		}



#endregion IPaginaMantenimiento Members

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			grid.CurrentPageIndex=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(e.SortExpression),Helper.ObtenerIndicePagina());
		}

		private void Seleccionar_GrupoCCPorCO(object sender, System.EventArgs e)
		{
			try
			{
				this.ddlbGrupoCentroCosto.Items.Clear();
				this.llenarGrupoCentroCosto();
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
		
		private void btnBuscar_click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				if(Page.IsValid)
				{
					if(this.ValidarCampos())
					{	
						//Graba en el Log la acción ejecutada
						LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Comercial",this.ToString(),"Busqueda de Centro Costo.",Enumerados.NivelesErrorLog.I.ToString()));
						
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

		private void ibtnAceptar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if(hIdGrupoCentroCosto.Value.Length==0)
			{
				ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO));
			}
			else
			{
				ltlMensaje.Text = Constantes.PONERTEXTO;
			}
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,
					Utilitario.Helper.MostrarDatosEnCajaTexto("hIdGrupoCentroCosto",dr[Enumerados.ColumnasBusquedaCentroCosto.IdGrupoCc.ToString()].ToString()),
					Utilitario.Helper.MostrarDatosEnCajaTexto("hIdCentroCosto",dr[Enumerados.ColumnasBusquedaCentroCosto.IdCentroCosto.ToString()].ToString()),
					Utilitario.Helper.MostrarDatosEnCajaTexto("hCentroCosto",dr[Enumerados.ColumnasBusquedaCentroCosto.Nombre.ToString()].ToString())
					);
			}
		}	
	}
}