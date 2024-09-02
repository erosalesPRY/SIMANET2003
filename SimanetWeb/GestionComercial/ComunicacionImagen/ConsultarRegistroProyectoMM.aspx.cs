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
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;

namespace SIMA.SimaNetWeb.GestionComercial.ComunicacionImagen
{
	/// <summary>
	/// Summary description for ConsultarRegistroProyectoMM.
	/// </summary>
	public class ConsultarRegistroProyectoMM : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		#region Controles

		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion controles

		#region constantes
		const string GRILLAVACIA="No existen registros de proyectos";
		const string URLDETALLE="DetalleConsultarRegistroProyectoMM.aspx?";
		const string URLIMPRESION="PopupImprimirRegistroProyectosMM.aspx";
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminarFiltro;
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hOrdenGrilla;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		const string KEYQID="Id";
		#endregion constantes
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					this.LlenarJScript();
					this.LlenarGrillaOrdenamientoPaginacion(this.hOrdenGrilla.Value,Convert.ToInt32(this.hGridPagina.Value));
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Utilitario.Enumerados.NombresdeModulo.GestiónComercial.ToString(),this.ToString(),"",Enumerados.NivelesErrorLog.I.ToString()));			
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
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add ConsultarRegistroProyectoMM.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarRegistroProyectoMM.LlenarGrillaOrdenamiento implementation
		}

		public DataTable ObtenerDatos()
		{
			CMantenimientos oCMantenimientos = new CMantenimientos();
			return oCMantenimientos.ListarTodosGrilla(Utilitario.Enumerados.ClasesNTAD.ProyectosMMNTAD.ToString());
		}


		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dt =  ObtenerDatos();
			
			if(dt!=null)
			{
				DataView dw= dt.DefaultView;
				dw.Sort = columnaOrdenar ;
				dw.RowFilter = Utilitario.Helper.ObtenerFiltro();

				if (dw.Count == Utilitario.Constantes.ValorConstanteCero)
				{
					grid.DataSource = null; 
					lblResultado.Text = GRILLAVACIA;
					lblResultado.Visible = true;
				}
				else
				{
					grid.DataSource = dw;
					grid.Columns[2].FooterText=dw.Count.ToString();
						
						grid.CurrentPageIndex=indicePagina;
					
					lblResultado.Visible = false;
				}
			}
			else
			{
				grid.DataSource = dt;
				lblResultado.Text = GRILLAVACIA;
			}
			
			try
			{
			
				
				grid.CurrentPageIndex=indicePagina;
				grid.DataBind();
			}
			catch (Exception a)
			{
				string b = a.Message.ToString();
				grid.CurrentPageIndex = Utilitario.Constantes.ValorConstanteCero;
				grid.DataBind();
			}

		}

		public void LlenarCombos()
		{
			// TODO:  Add ConsultarRegistroProyectoMM.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add ConsultarRegistroProyectoMM.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarRegistroProyectoMM.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarRegistroProyectoMM.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			ltlMensaje.Text = Helper.PopupImpresion(URLIMPRESION,750,500,false,false,false,true,true);

		}

		public void Exportar()
		{
			// TODO:  Add ConsultarRegistroProyectoMM.Exportar implementation
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
			// TODO:  Add ConsultarRegistroProyectoMM.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			// TODO:  Add ConsultarRegistroProyectoMM.Agregar implementation
		}

		public void Modificar()
		{
			// TODO:  Add ConsultarRegistroProyectoMM.Modificar implementation
		}

		public void Eliminar()
		{
			// TODO:  Add ConsultarRegistroProyectoMM.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			// TODO:  Add ConsultarRegistroProyectoMM.CargarModoPagina implementation
		}

		public void CargarModoNuevo()
		{
			// TODO:  Add ConsultarRegistroProyectoMM.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			// TODO:  Add ConsultarRegistroProyectoMM.CargarModoModificar implementation
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add ConsultarRegistroProyectoMM.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add ConsultarRegistroProyectoMM.ValidarCampos implementation
			return false;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add ConsultarRegistroProyectoMM.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add ConsultarRegistroProyectoMM.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.Header)
			{
			}
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
			
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,
					Utilitario.Helper.MostrarDatosEnCajaTexto("hCodigo",dr["IDPROYECTOMM"].ToString())
					);
				
				e.Item.Cells[0].Attributes.Add(Utilitario.Constantes.EVENTOCLICK, Utilitario.Constantes.POPUPDEESPERA +
						Helper.HistorialIrAdelantePersonalizado(hGridPagina.ID.ToString(),hOrdenGrilla.ID.ToString()) + Utilitario.Constantes.SIGNOPUNTOYCOMA +
					Helper.MostrarVentana(URLDETALLE,KEYQID + Utilitario.Constantes.SIGNOIGUAL + 
					dr["IDPROYECTOMM"] +
					Utilitario.Constantes.SIGNOAMPERSON +  Utilitario.Constantes.KEYMODOPAGINA +  
					Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.C.ToString()));
				e.Item.Cells[0].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				e.Item.Cells[0].Font.Underline=true;
				e.Item.Cells[0].ForeColor= System.Drawing.Color.Blue;
				Helper.FiltroporSeleccionConfiguraColumna(e,grid);	
				
			}
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.hGridPagina.Value = e.NewPageIndex.ToString();
			
			this.LlenarGrillaOrdenamientoPaginacion(this.hOrdenGrilla.Value,e.NewPageIndex);
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.hOrdenGrilla.Value = Helper.GenerarExpresionOrdenamiento(e.SortExpression);
			this.LlenarGrillaOrdenamientoPaginacion(this.hOrdenGrilla.Value,Helper.ObtenerIndicePagina());
		}

		private void ibtnFiltrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			ltlMensaje.Text= Utilitario.Helper.ElaborarFiltro(ObtenerDatos()
				,"NOMBREPROYECTO"+";Nombre Proyecto"
				,"*" + "TipoProducto"+ ";Tipo Producto"
				,"cliente" + ";Cliente");
			
		}

		private void ibtnEliminarFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();	
		}

		private void ibtnImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Imprimir();
		}
	}
}
