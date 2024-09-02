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
using SIMA.EntidadesNegocio.General;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using NullableTypes;
using MetaBuilders.WebControls;

namespace SIMA.SimaNetWeb.General
{
	/// <summary>
	/// Summary description for ImportarBubirArchivos.
	/// </summary>
	public class ImportarBubirArchivos : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		#region Contantes
			const string KEYQIDMODULO="idMod";
			const string KEYQNOMBREMODULO="NMod";
			const string KEYQIDTABLAESTADOORIGEN="idTblOrigen";
			const string GRILLAVACIA="No existen datos";
			
		#endregion

		protected System.Web.UI.WebControls.Label lblFecha;
		protected System.Web.UI.WebControls.Label lblArchivoAdjunto;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hArchivoValido;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		protected System.Web.UI.HtmlControls.HtmlInputFile filMyFile;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label lblModulo;
		protected System.Web.UI.WebControls.Literal ltlMensaje;

		private void Page_Load(object sender, System.EventArgs e)
		{

			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					this.LlenarJScript();
					Helper.ReiniciarSession();
					this.LlenarDatos();
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionFinanciera",this.ToString(),"Se consultó Carta de Crédito.",Enumerados.NivelesErrorLog.I.ToString()));
					this.LlenarGrillaOrdenamientoPaginacion("",Convert.ToInt32(hGridPagina.Value));
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
					ltlMensaje.Text = Helper.MsgdbErrMostrarMesaje(oSIMAExcepcionDominio.Error.ToString());					
				}
				catch(Exception oException)
				{
					SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Utilitario.Constantes.CODIGOERRORGENERICO,oException.Message);
					Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
				}
			}		

			if(hArchivoValido.Value=="1"){
				ImportarDatos();
			}
		}
		void ImportarDatos(){
			if(filMyFile.Value.Length>0)
			{ 
				try
				{
					Helper.SubirArchivo(this.filMyFile,System.Configuration.ConfigurationSettings.AppSettings[Utilitario.Constantes.CONFIGIMPORTACION].ToString());
					ImportacionBE oImportacionBE = new ImportacionBE();
					oImportacionBE.IdModulo = Convert.ToInt32(Page.Request.Params[KEYQIDMODULO]);
					oImportacionBE.IdTablaEstadoOrigen = Convert.ToInt32(Page.Request.Params[KEYQIDTABLAESTADOORIGEN]);
					oImportacionBE.NombreArchivo= filMyFile.Value.ToString();
					oImportacionBE.IdUsuarioRegistro= CNetAccessControl.GetIdUser();
					oImportacionBE.IdEstado= 1;
					(new CImportarArhivos()).Insertar(oImportacionBE);
				}
				catch(Exception ex)
				{
					ImportacionBE oImportacionBE = new ImportacionBE();
					oImportacionBE.IdModulo = Convert.ToInt32(Page.Request.Params[KEYQIDMODULO]);
					oImportacionBE.IdTablaEstadoOrigen = Convert.ToInt32(Page.Request.Params[KEYQIDTABLAESTADOORIGEN]);
					oImportacionBE.NombreArchivo= filMyFile.Value.ToString();
					oImportacionBE.IdUsuarioRegistro= CNetAccessControl.GetIdUser();
					oImportacionBE.IdEstado= 2;
					(new CImportarArhivos()).Insertar(oImportacionBE);
				}
				this.LlenarGrillaOrdenamientoPaginacion("",Convert.ToInt32(hGridPagina.Value));
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
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void ibtnAceptar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
		}
		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add ImportarBubirArchivos.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ImportarBubirArchivos.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dtGeneral = this.ObtenerDatos();
			if(dtGeneral!=null)
			{
				DataView dwGeneral = dtGeneral.DefaultView;
				dwGeneral.RowFilter = Helper.ObtenerFiltro();
				dwGeneral.Sort = columnaOrdenar ;
				grid.Columns[Utilitario.Constantes.POSICIONFOOTERTOTAL].FooterText = Utilitario.Constantes.TEXTOFOOTERTOTAL + Utilitario.Constantes.ESPACIO + dwGeneral.Count.ToString();
				grid.DataSource = dwGeneral;
				lblResultado.Visible = false;
			}
			else
			{
				grid.DataSource = dtGeneral;
				lblResultado.Visible = true;
				lblResultado.Text = GRILLAVACIA;				
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
		private DataTable ObtenerDatos()
		{
			return (new CImportarArhivos()).ConsultarImportaciones(Convert.ToInt32(Page.Request.Params[KEYQIDMODULO]),Convert.ToInt32(Page.Request.Params[KEYQIDTABLAESTADOORIGEN]));
		}


		public void LlenarCombos()
		{
			// TODO:  Add ImportarBubirArchivos.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			lblModulo.Text = Page.Request.Params[KEYQNOMBREMODULO].ToString();
		}

		public void LlenarJScript()
		{
			// TODO:  Add ImportarBubirArchivos.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ImportarBubirArchivos.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ImportarBubirArchivos.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ImportarBubirArchivos.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add ImportarBubirArchivos.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ImportarBubirArchivos.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			// TODO:  Add ImportarBubirArchivos.Agregar implementation
		}

		public void Modificar()
		{
			// TODO:  Add ImportarBubirArchivos.Modificar implementation
		}

		public void Eliminar()
		{
			// TODO:  Add ImportarBubirArchivos.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			// TODO:  Add ImportarBubirArchivos.CargarModoPagina implementation
		}

		public void CargarModoNuevo()
		{
			// TODO:  Add ImportarBubirArchivos.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			// TODO:  Add ImportarBubirArchivos.CargarModoModificar implementation
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add ImportarBubirArchivos.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add ImportarBubirArchivos.ValidarCampos implementation
			return false;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add ImportarBubirArchivos.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add ImportarBubirArchivos.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.hGridPagina.Value = e.NewPageIndex.ToString();
			this.LlenarGrillaOrdenamientoPaginacion("",e.NewPageIndex);
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
						DataRowView drv = (DataRowView)e.Item.DataItem;
						DataRow dr = drv.Row;

				Helper.ConfiguraColumnaHyperLink(e.Item.Cells[0],grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
			}
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
