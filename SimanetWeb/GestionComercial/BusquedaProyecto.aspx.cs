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
using SIMA.Log;
using SIMA.SimaNetWeb.InterfacesIU;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using NetAccessControl;
using MetaBuilders.WebControls;
using Microsoft.ApplicationBlocks.ConfigurationManagement;

namespace SIMA.SimaNetWeb.GestionComercial
{
	/// <summary>
	/// Summary description for BusquedaProyecto.
	/// </summary>
	public class BusquedaProyecto : System.Web.UI.Page,IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblDescripcion;
		protected System.Web.UI.WebControls.TextBox txtProyecto;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvDescripcionProyecto;
		protected System.Web.UI.WebControls.ImageButton btnBuscar;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary vSum;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.Image imgCancelar;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdProyecto;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hProyecto;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCliente;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hSector;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCentroOperativo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hLineaNegocio;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hMonto;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hMoneda;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hMontoSoles;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion Controles

		#region Constantes

		//Ordenamiento
		const string COLORDENAMIENTO = "RazonSocial";
		
		//Busqueda

		const int CantidadCero = 0;
		const int CantidadCo = 3;

		//Cadenas
		const string GRILLAVACIA ="No existen ningún Proyecto con el la descripcion ingresada.";

		//QueryString
		const string KEYARRAY = "ArrayCo";

		//JScript

		string JSCERRARVENTANA = "return CerrarVentana();";
		

		#endregion Constantes

		#region Variables
		
		#endregion Variables

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
			this.btnBuscar.Click += new System.Web.UI.ImageClickEventHandler(this.btnBuscar_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.ibtnAceptar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAceptar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaMantenimiento Members
		
		public void Agregar()
		{}

		public	void Modificar()
		{}

		public void Eliminar()
		{}

		public void CargarModoPagina()
		{}

		public void CargarModoNuevo()
		{}

		public	void CargarModoModificar()
		{}

		public	void CargarModoConsulta()
		{}
		
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
		{
			if (this.txtProyecto.Text == "")
			{
				ltlMensaje.Text = Helper.ObtenerMensajesConfirmacionComercialUsuario(Utilitario.Mensajes.CODIGOMENSAJESELECCIONPROMOTOR);
				return false;		
			}
			return true;
		}

		public bool ValidarExpresionesRegulares()
		{
			return true;
		}

		#endregion 

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add BusquedaProyecto.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add BusquedaProyecto.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			int [] co = (int[])ViewState[KEYARRAY];
			CProyectos oCProyectos = new CProyectos();
			DataTable dtProyectos =  oCProyectos.ConsultarProyectosPorDescripcion(this.txtProyecto.Text, co);
			
			if(dtProyectos!=null)
			{
				DataView dwProyectos = dtProyectos.DefaultView;
				dwProyectos.Sort = columnaOrdenar;
				grid.DataSource = dtProyectos; 
				lblResultado.Text = GRILLAVACIA;
				lblResultado.Visible = false;
			}
			else
			{
				grid.DataSource = dtProyectos; 
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
			// TODO:  Add BusquedaProyecto.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			CCentroOperativo oCCentroOperativo =  new CCentroOperativo();
			DataTable dt = oCCentroOperativo.ListarCentroOperativoAccesoSegunPrivilegioUsuario(CNetAccessControl.GetIdUser(), Convert.ToInt32(Enumerados.TablasTabla.EstadosVentasReales));
			if(dt != null)
			{
				int[] array =  new int[3];
				int contData = 0;
				for(int i=0; i<dt.Rows.Count; i++)
				{
					if(Convert.ToInt32(dt.Rows[i][Enumerados.ColumnasCentroOperativo.IdCentroOperativo.ToString()]) > 1)
					{
						array[contData] = Convert.ToInt32(dt.Rows[i][Enumerados.ColumnasCentroOperativo.IdCentroOperativo.ToString()]);
						contData++;
					}
				}
				ViewState[KEYARRAY] = array;
			}
		}

		public void LlenarJScript()
		{
			rfvDescripcionProyecto.ErrorMessage = Helper.ObtenerMensajesConfirmacionProyectosUsuario(Utilitario.Mensajes.CODIGOMENSAJEDESCRIPCIONPROYECTO);
			rfvDescripcionProyecto.ToolTip = Helper.ObtenerMensajesConfirmacionProyectosUsuario(Utilitario.Mensajes.CODIGOMENSAJEDESCRIPCIONPROYECTO);
		
			this.imgCancelar.Attributes.Add(Constantes.EVENTOCLICK,JSCERRARVENTANA);
		}

		public void RegistrarJScript()
		{
			// TODO:  Add BusquedaProyecto.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add BusquedaProyecto.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add BusquedaProyecto.Exportar implementation
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

		#region Eventos Controles
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					
					this.LlenarJScript();

					this.LlenarDatos();

					Helper.ReiniciarSession();

					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Comercial",this.ToString(),"Se realizó búsqueda de Centro Costo.",Enumerados.NivelesErrorLog.I.ToString()));
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

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			grid.CurrentPageIndex=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(e.SortExpression),Helper.ObtenerIndicePagina());
		}

		private void btnBuscar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				if(Page.IsValid)
				{
					if(this.ValidarCampos())
					{	
						//Graba en el Log la acción ejecutada
						LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Comercial",this.ToString(),"Busqueda de Proyectos.",Enumerados.NivelesErrorLog.I.ToString()));
						
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
			if(hIdProyecto.Value.Length==0)
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
					Utilitario.Helper.MostrarDatosEnCajaTexto("hIdProyecto",dr[Enumerados.ColumnasBusquedaProyecto.IDPROYECTO.ToString()].ToString()),
					Utilitario.Helper.MostrarDatosEnCajaTexto("hProyecto",dr[Enumerados.ColumnasBusquedaProyecto.DESCRIPCION.ToString()].ToString()),
					Utilitario.Helper.MostrarDatosEnCajaTexto("hCliente",dr[Enumerados.ColumnasBusquedaProyecto.RAZONSOCIAL.ToString()].ToString()),
					Utilitario.Helper.MostrarDatosEnCajaTexto("hSector",dr[Enumerados.ColumnasBusquedaProyecto.SECTOR.ToString()].ToString()),
					Utilitario.Helper.MostrarDatosEnCajaTexto("hCentroOperativo",dr[Enumerados.ColumnasBusquedaProyecto.CENTROOPERATIVO.ToString()].ToString()),
					Utilitario.Helper.MostrarDatosEnCajaTexto("hLineaNegocio",dr[Enumerados.ColumnasBusquedaProyecto.LINEANEGOCIO.ToString()].ToString()),
					Utilitario.Helper.MostrarDatosEnCajaTexto("hMonto",dr[Enumerados.ColumnasBusquedaProyecto.MONTOPRECIOVENTASINIMPUESTO.ToString()].ToString()),
                    Utilitario.Helper.MostrarDatosEnCajaTexto("hMoneda",dr[Enumerados.ColumnasBusquedaProyecto.MONEDA.ToString()].ToString()),
					Utilitario.Helper.MostrarDatosEnCajaTexto("hMontoSoles",dr[Enumerados.ColumnasBusquedaProyecto.MONTOPRECIOVENTASOLES.ToString()].ToString())
					);
			}
		}
		#endregion
	}
}