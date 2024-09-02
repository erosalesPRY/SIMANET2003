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
using SIMA.Controladoras;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using SIMA.Controladoras.GestionComercial;
using MetaBuilders.WebControls;

namespace SIMA.SimaNetWeb.GestionComercial
{
	/// <summary>
	/// Summary description for BusquedaPasajesAereos.
	/// </summary>
	public class BusquedaPasajesAereos: System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		#region controles 

		protected System.Web.UI.WebControls.Label lblResultado;
		protected eWorld.UI.CalendarPopup CalFechaInicio;
		protected eWorld.UI.CalendarPopup CalFechaFin;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.ImageButton ibtnCancelar;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.DomValidators.CompareDomValidator cvFechas;
		protected System.Web.UI.WebControls.Label lblAerolinea;
		protected System.Web.UI.WebControls.DropDownList ddlbAerolinea;
		protected System.Web.UI.WebControls.Label lblFechaVuelo;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdPasajeAereo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hRuta;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvAerolinea;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdMoneda;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hMoneda;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hMonto;
		protected System.Web.UI.WebControls.ImageButton ibtnBuscar;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary vSum;

		#endregion controles
	
		#region constantes

		//Ordenamiento
		const string COLORDENAMIENTO = "IdPasajeAereo";

		//Cadenas
		const string GRILLAVACIA ="No existen ningun Pasaje Aereo con los filtros seleccionados.";  
		
		//JScript

		string JSCERRARVENTANA = "return CerrarVentana();";

		#endregion constantes
		
		#region Variables
		
		ListItem  lItem ;
		
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
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Comercial",this.ToString(),"Se realizó búsqueda de Pasajes Aereos.",Enumerados.NivelesErrorLog.I.ToString()));

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
			this.ibtnBuscar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnBuscar_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.ibtnAceptar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAceptar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		
		private void llenarAerolinea()
		{
			CAerolinea oCAerolinea = new CAerolinea();
			ddlbAerolinea.DataSource = oCAerolinea.ListarTodosCombo();                    
			ddlbAerolinea.DataValueField=Enumerados.ColumnasAerolineas.IdAerolinea.ToString();
			ddlbAerolinea.DataTextField=Enumerados.ColumnasAerolineas.Nombre.ToString();  
			ddlbAerolinea.DataBind();
		}
		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add BusquedaPasajesAereos.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add BusquedaPasajesAereos.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			CPasajeAereo oCPasajeAereo =  new CPasajeAereo();
			DataTable dtPasajeAereo =  oCPasajeAereo.ConsultarPasajesAereosPorFechayAerolinea(this.CalFechaInicio.SelectedDate,this.CalFechaFin.SelectedDate,Convert.ToInt32(this.ddlbAerolinea.SelectedValue));

			
			if(dtPasajeAereo!=null)
			{
				DataView dwPasajeAereo = dtPasajeAereo.DefaultView;
				dwPasajeAereo.Sort = columnaOrdenar;
				grid.DataSource = dwPasajeAereo;
				lblResultado.Visible = false;
			}
			else
			{
				grid.DataSource = dtPasajeAereo;
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
			CalFechaInicio.SelectedDate = Helper.ObtenerFechaInicioBusqueda();
			lItem = new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR ,Utilitario.Constantes.VALORSELECCIONAR  );
			this.llenarAerolinea();
			this.ddlbAerolinea.Items.Insert(0,lItem);
		}

		public void LlenarDatos()
		{
			// TODO:  Add BusquedaPasajesAereos.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			this.ibtnCancelar.Attributes.Add( Constantes.EVENTOCLICK, JSCERRARVENTANA);

			this.cvFechas.ErrorMessage = Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJERANGOFECHAS);
			this.cvFechas.ToolTip = Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJERANGOFECHAS);
			
			this.rfvAerolinea.ErrorMessage = Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJESELECCIONAEROLINEA);
			this.rfvAerolinea.ToolTip = Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJESELECCIONAEROLINEA);
			this.rfvAerolinea.InitialValue = Constantes.VALORSELECCIONAR;
		}

		public void RegistrarJScript()
		{
			// TODO:  Add BusquedaPasajesAereos.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add BusquedaPasajesAereos.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add BusquedaPasajesAereos.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add BusquedaPasajesAereos.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			if(!Helper.ValidarRangoFechas(CalFechaInicio.SelectedDate,CalFechaFin.SelectedDate))
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJERANGOFECHAS));
				return false;
			}
			else
			{
				return true;
			}
		}

		#endregion

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(e.SortExpression),Helper.ObtenerIndicePagina());
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			grid.CurrentPageIndex=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);
		}

		private void ibtnAceptar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if(hIdPasajeAereo.Value.Length==0)
			{
				ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO));
			}
			else
			{
				ltlMensaje.Text = Constantes.PONERTEXTO;
			}
		}

		public bool ValidarCampos()
		{
			if(this.ValidarCamposRequeridos())
			{
				return ValidarFiltros();
			}
			else
			{
				return false;
			}
		}
		#region IPaginaMantenimento Members

		public void Agregar()
		{
			// TODO:  Add BusquedaPasajesAereos.Agregar implementation
		}

		public void Modificar()
		{
			// TODO:  Add BusquedaPasajesAereos.Modificar implementation
		}

		public void Eliminar()
		{
			// TODO:  Add BusquedaPasajesAereos.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			// TODO:  Add BusquedaPasajesAereos.CargarModoPagina implementation
		}

		public void CargarModoNuevo()
		{
			// TODO:  Add BusquedaPasajesAereos.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			// TODO:  Add BusquedaPasajesAereos.CargarModoModificar implementation
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add BusquedaPasajesAereos.CargarModoConsulta implementation
		}

		public bool ValidarCamposRequeridos()
		{
			if (this.ddlbAerolinea.SelectedItem.Text == Utilitario.Constantes.TEXTOSSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.ObtenerMensajesConfirmacionUsuario(Utilitario.Mensajes.CODIGOMENSAJESELECCIONAEROLINEA);
				return false;
			}
			return true;
		}

		public bool ValidarExpresionesRegulares()
		{
			return false;
		}

		#endregion

		private void ibtnBuscar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				if(Page.IsValid)
				{
					if(this.ValidarCampos())
					{	
						//Graba en el Log la acción ejecutada
						LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Comercial",this.ToString(),"Busqueda de Pasaje Aereo.",Enumerados.NivelesErrorLog.I.ToString()));
						
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

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,
					Utilitario.Helper.MostrarDatosEnCajaTexto("hIdPasajeAereo",dr[Enumerados.ColumnasBusquedaPasajesAereos.IdPasajeAereo.ToString()].ToString()),
					Utilitario.Helper.MostrarDatosEnCajaTexto("hRuta",dr[Enumerados.ColumnasBusquedaPasajesAereos.Ruta.ToString()].ToString()),
					Utilitario.Helper.MostrarDatosEnCajaTexto("hIdMoneda",dr[Enumerados.ColumnasBusquedaPasajesAereos.IdMoneda.ToString()].ToString()),
					Utilitario.Helper.MostrarDatosEnCajaTexto("hMoneda",dr[Enumerados.ColumnasBusquedaPasajesAereos.Moneda.ToString()].ToString()),
					Utilitario.Helper.MostrarDatosEnCajaTexto("hMonto",dr[Enumerados.ColumnasBusquedaPasajesAereos.Monto.ToString()].ToString())
					);
			}
		}
	}
}