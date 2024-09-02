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
	/// Summary description for BusquedaAreaAExaminar.
	/// </summary>
	public class BusquedaAreaAExaminar : System.Web.UI.Page,IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblDescripcion;
		protected System.Web.UI.WebControls.TextBox txtDenominacion;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvDenominacion;
		protected System.Web.UI.WebControls.ImageButton btnBuscar;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary vSum;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.Image imgCancelar;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdAreaCritica;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hAreaCritica;
		#endregion Controles

		#region Constantes

		//Ordenamiento
		const string COLORDENAMIENTO = "Denominacion";
		
		//Busqueda

		//Cadenas
		const string GRILLAVACIA ="No existen ninguna Area Crítica con la Denominacion ingresada.";

		//JScript
		string JSCERRARVENTANA = "return CerrarVentana();";
		
		#endregion Constantes
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdGrupoAreaCritica;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hNroGrupoAreaCritica;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hNroAreaCritica;
		
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
			CAreasAExaminar OCAreasAExaminar = new CAreasAExaminar();
			DataTable dtAreasCriticas =  OCAreasAExaminar.BuscarAreaCritica(this.txtDenominacion.Text);
			
			if(dtAreasCriticas != null)
			{
				DataView dwAreasCriticas = dtAreasCriticas.DefaultView;
				dwAreasCriticas.Sort = columnaOrdenar;
				grid.DataSource = dtAreasCriticas; 
				lblResultado.Text = GRILLAVACIA;
				lblResultado.Visible = false;
			}
			else
			{
				grid.DataSource = dtAreasCriticas; 
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
			// TODO:  Add BusquedaPromotores.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			this.rfvDenominacion.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Utilitario.Mensajes.CODIGOMENSAJEACCIONCTRLPOSTERIOREJECCAMPOREQUERIDODENOMINACION);
			this.rfvDenominacion.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Utilitario.Mensajes.CODIGOMENSAJEACCIONCTRLPOSTERIOREJECCAMPOREQUERIDODENOMINACION);
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
				ltlMensaje.Text = Helper.ObtenerMensajesConfirmacionComercialUsuario(Utilitario.Mensajes.CODIGOMENSAJEACCIONCTRLPOSTERIOREJECCAMPOREQUERIDODENOMINACION);
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
						LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion de Ctrl Institucional",this.ToString(),"Busqueda de Areas Criticas.",Enumerados.NivelesErrorLog.I.ToString()));
						
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
			if(hIdAreaCritica.Value.Length==0)
			{
				ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO));
			}
			else
			{
				ltlMensaje.Text =Utilitario.Constantes.PONERTEXTO;
			}
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,
					Utilitario.Helper.MostrarDatosEnCajaTexto("hIdGrupoAreaCritica",dr[Enumerados.ColumnasAreaCritica.IdGrupoAreaCritica.ToString()].ToString()),
					Utilitario.Helper.MostrarDatosEnCajaTexto("hNroGrupoAreaCritica",dr[Enumerados.ColumnasAreaCritica.NroGrupoAreaCritica.ToString()].ToString()),
					Utilitario.Helper.MostrarDatosEnCajaTexto("hNroAreaCritica",dr[Enumerados.ColumnasAreaCritica.NroAreaCritica.ToString()].ToString()),
					Utilitario.Helper.MostrarDatosEnCajaTexto("hIdAreaCritica",dr[Enumerados.ColumnasAreaCritica.IdAreaCritica.ToString()].ToString()),
					Utilitario.Helper.MostrarDatosEnCajaTexto("hAreaCritica",dr[Enumerados.ColumnasAreaCritica.Denominacion.ToString()].ToString())
					);
			}
		}

	}
}
