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
using SIMA.Controladoras.GestionControlInstitucional;
using SIMA.Log;
using SIMA.SimaNetWeb.InterfacesIU;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using NetAccessControl;
using MetaBuilders.WebControls;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.ApplicationBlocks.ConfigurationManagement;
using System.Text;
using System.Reflection;

namespace SIMA.SimaNetWeb.GestionControlInstitucional
{
	/// <summary>
	/// Summary description for BusquedaPromotores.
	/// </summary>
	public class BusquedaActividadControl : System.Web.UI.Page,IPaginaBase
	{
		#region controles

		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblDescripcion;
		protected System.Web.UI.WebControls.ImageButton btnBuscar;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary vSum;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.Image imgCancelar;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdActividadCtrl;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hActividadCtrl;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvActividadCtrl;
		protected System.Web.UI.WebControls.TextBox txtDenominacion;
		protected System.Web.UI.WebControls.Literal ltlMensaje;

		#endregion controles

		#region constantes

		//Ordenamiento
		const string COLORDENAMIENTO = "Denominacion";
		
		//Busqueda
		const string KEYQPRG = "Prg";
		const string KEYQTIT = "Titulo";

		//Cadenas
		const string GRILLAVACIA ="No existen ninguna Actividad de Control con la Denominacion ingresada.";

		//JScript

		string JSCERRARVENTANA = "return CerrarVentana();";
		const string TITULO = "BUSQUEDA DE ACTIVIDADES DE CONTROL";
		
		#endregion constantes
		
		#region Variables
		
		#endregion Variables
	
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

					this.LlenarDatos();
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
			this.btnBuscar.Click += new System.Web.UI.ImageClickEventHandler(this.btnBuscar_Click);
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
			// TODO:  Add BusquedaPromotores.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add BusquedaPromotores.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			CActividadCtrl oCActividadCtrl = new CActividadCtrl();
			DataTable dtActividadCtrl =  oCActividadCtrl.BuscarActividadControl(this.txtDenominacion.Text, Convert.ToInt32(Page.Request.QueryString[KEYQPRG]));
			
			if(dtActividadCtrl != null)
			{
				DataView dwActividadCtrl = dtActividadCtrl.DefaultView;
				dwActividadCtrl.Sort = columnaOrdenar;
				grid.DataSource = dtActividadCtrl; 
				lblResultado.Text = GRILLAVACIA;
				lblResultado.Visible = false;
			}
			else
			{
				grid.DataSource = dtActividadCtrl; 
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
			
		}

		public void LlenarDatos()
		{
			this.lblTitulo.Text = TITULO + Utilitario.Constantes.ESPACIO + Page.Request.QueryString[KEYQTIT].ToString().ToUpper();
		}

		public void LlenarJScript()
		{
			this.rfvActividadCtrl.ErrorMessage = Helper.ObtenerMensajesConfirmacionOCIUsuario(Utilitario.Mensajes.CODIGOMENSAJEACCIONCTRLPOSTERIOREJECCAMPOREQUERIDODENOMINACION);
			this.rfvActividadCtrl.ToolTip = Helper.ObtenerMensajesConfirmacionOCIUsuario(Utilitario.Mensajes.CODIGOMENSAJEACCIONCTRLPOSTERIOREJECCAMPOREQUERIDODENOMINACION);
			this.imgCancelar.Attributes.Add(Constantes.EVENTOCLICK,JSCERRARVENTANA);
		}

		public void RegistrarJScript()
		{
			// TODO:  Add BusquedaPromotores.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add BusquedaPromotores.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add BusquedaPromotores.Exportar implementation
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
			// TODO:  Add BusquedaPromotores.ValidarFiltros implementation
			return false;
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
			return this.ValidarCamposRequeridos();
		}

		public bool ValidarCamposRequeridos()
		{
			if (this.txtDenominacion.Text == "")
			{
				ltlMensaje.Text = Helper.ObtenerMensajesConfirmacionProyectosUsuario(Mensajes.CODIGOMENSAJEACCIONCTRLPOSTERIOREJECCAMPOREQUERIDODENOMINACION);
				return false;		
			}
			return true;
		}

		public bool ValidarExpresionesRegulares()
		{
			return true;
		}

		#endregion 

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
			if(hIdActividadCtrl.Value.Length==0)
			{
				ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO));
			}
			else
			{
				ltlMensaje.Text = "PonerTexto()";
			}
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,
					Utilitario.Helper.MostrarDatosEnCajaTexto("hIdActividadCtrl",dr[Enumerados.ColumnasActividadCtrl.IdActividadCtrl.ToString()].ToString()),
					Utilitario.Helper.MostrarDatosEnCajaTexto("hActividadCtrl",dr[Enumerados.ColumnasActividadCtrl.Denominacion.ToString()].ToString())
					);
			}
		}
	}
}