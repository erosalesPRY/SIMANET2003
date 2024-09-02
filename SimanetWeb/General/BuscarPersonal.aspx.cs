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
using SIMA.Controladoras.Secretaria ;
using SIMA.Controladoras.General;
using SIMA.Controladoras.GestionComercial;
using SIMA.Controladoras.Proyectos;
using SIMA.Log;
using SIMA.SimaNetWeb.InterfacesIU;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.EntidadesNegocio.Secretaria ;
using NetAccessControl;
using NullableTypes;
using MetaBuilders.WebControls;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.ApplicationBlocks.ConfigurationManagement;
using System.Text;
using System.Reflection;

namespace SIMA.SimaNetWeb.General
{
	/// <summary>
	/// Summary description for BuscarJefeProyecto.
	/// </summary>
	public class BuscarPersonal : System.Web.UI.Page, IPaginaBase,IPaginaMantenimento
	{
		#region controles
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblPalabraBusqueda;
		protected System.Web.UI.WebControls.TextBox txtPalabraClave;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label lblNumeroCoincidencias;
		protected System.Web.UI.WebControls.Label lblDblNumeroCoincidencias;
		protected System.Web.UI.WebControls.Image imgCancelar;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvNombrePersonal;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary vSum;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.ImageButton ibtnBuscar;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hNombrePersonal;
		#endregion

		#region constantes
		//Ordenamiento
		const string COLORDENAMIENTO = "Personal";
		
		//Busqueda

		const int CantidadCero = 0;

		//Cadenas
		const string GRILLAVACIA ="No existen ningún Personal con el la descripcion ingresada.";

		//JScript
		string JSCERRARVENTANA = "return CerrarVentana();";
		#endregion
		
		#region Variables
		
		#endregion Variables
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					//this.ConfigurarAccesoControles();
					this.LlenarJScript();
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
			this.ibtnAceptar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAceptar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add BuscarPersonal.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add BuscarPersonal.LlenarGrillaOrdenamiento implementation
		}


		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			CPersonal oCPersonal = new CPersonal();

			DataTable dtPersonal = oCPersonal.BuscarPersonalSegunPalabraClave(this.txtPalabraClave.Text);

			if(dtPersonal!=null)
			{
				DataView dwPersonal = dtPersonal.DefaultView;
				dwPersonal.Sort = columnaOrdenar ;
				this.grid.DataSource = dwPersonal;
				this.lblDblNumeroCoincidencias.Text = dtPersonal.Rows.Count.ToString(Utilitario.Constantes.FORMATODECIMAL4);
			}
			else
			{
				grid.DataSource = dtPersonal;
				lblResultado.Text = GRILLAVACIA;
				this.lblResultado.Visible = true;
				this.lblDblNumeroCoincidencias.Text="0.00";

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
			// TODO:  Add BuscarPersonal.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add BuscarPersonal.LlenarDatos implementation
		}


		public void LlenarJScript()
		{
			rfvNombrePersonal.ErrorMessage = Helper.ObtenerMensajesConfirmacionProyectosUsuario(Utilitario.Mensajes.CODIGOMENSAJENOMBREPROYECTO);
			rfvNombrePersonal.ToolTip = Helper.ObtenerMensajesConfirmacionProyectosUsuario(Utilitario.Mensajes.CODIGOMENSAJENOMBREPROYECTO);
			
			this.imgCancelar.Attributes.Add("onclick",JSCERRARVENTANA);
		}

		public void RegistrarJScript()
		{
			// TODO:  Add BuscarPersonal.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add BuscarPersonal.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add BuscarPersonal.Exportar implementation
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
			// TODO:  Add BuscarPersonal.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			// TODO:  Add BuscarPersonal.Agregar implementation
		}

		public void Modificar()
		{
			// TODO:  Add BuscarPersonal.Modificar implementation
		}

		public void Eliminar()
		{
			// TODO:  Add BuscarPersonal.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			// TODO:  Add BuscarPersonal.CargarModoPagina implementation
		}

		public void CargarModoNuevo()
		{
			// TODO:  Add BuscarPersonal.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			// TODO:  Add BuscarPersonal.CargarModoModificar implementation
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add BuscarPersonal.CargarModoConsulta implementation
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
		{
			if (this.txtPalabraClave.Text == Utilitario.Constantes.VACIO)
			{
				ltlMensaje.Text = Helper.ObtenerMensajesConfirmacionProyectosUsuario(Utilitario.Mensajes.CODIGOMENSAJENOMBREPROYECTO);
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
			grid.CurrentPageIndex = e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(e.SortExpression),Helper.ObtenerIndicePagina());
		}

		private void ibtnAceptar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			RowSelectorColumn rSel = RowSelectorColumn.FindColumn(grid);
			
			if(rSel.SelectedIndexes.Length==0)
			{
				ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO));
			}
			else
			{
				int indice = rSel.SelectedIndexes[0];

				this.hCodigo.Value = grid.DataKeys[indice].ToString();
				this.hNombrePersonal.Value =  grid.Items[indice].Cells[1].Text;

				ltlMensaje.Text = "PonerTexto()";
			}
		}

		private void ibtnBuscar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				if(Page.IsValid)
				{
					if(this.ValidarCampos())
					{	
						//Graba en el Log la acción ejecutada
						LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Proyectos",this.ToString(),"Busqueda de Personal.",Enumerados.NivelesErrorLog.I.ToString()));
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
	}
}
