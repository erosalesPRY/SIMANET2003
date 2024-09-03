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
using SIMA.Controladoras.GestionFinanciera;
using SIMA.EntidadesNegocio.GestionFinanciera;

using SIMA.Utilitario;
using NetAccessControl;
using SIMA.ManejadorExcepcion;
using SIMA.Log;


namespace SIMA.SimaNetWeb.GestionFinanciera.Procesos
{

	/// <summary>
	/// Summary description for ProcesosEstadosFinancieros.
	/// </summary>
	public class ProcesosEstadosFinancieros : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		const string  KEYQIDGRUPOPROCESO = "idGrpProceso";
		const string  KEYQIDMODULO = "idModulo";
		const string GRILLAVACIA ="No existe ningún Registro de Procesos.";  

		const string LBLUSUARIO ="lblUsuario";  
		const string LBLFECHA ="lblFecha";  
		const string IMGFOTO ="imgFotoUsuario";  
		const string EXTENSIONFOTO = ".JPG";
		const string ARCHIVO = "sinfoto.jpg";
		protected System.Web.UI.WebControls.Label lblResultado;
		protected projDataGridWeb.DataGridWeb grid;
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
					this.LlenarCombos();
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionFinanciera",this.ToString(),"Se consultó Carta de Crédito.",Enumerados.NivelesErrorLog.I.ToString()));
					this.LlenarGrillaOrdenamientoPaginacion("",0);
					//FINuspTADEjecutarProcesos
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
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		private DataTable ObtenerDatos()
		{
			return ((CTablasParametros) new CTablasParametros()).ListarProcesos(Convert.ToInt32(Page.Request.Params[KEYQIDMODULO]),Convert.ToInt32(Page.Request.Params[KEYQIDGRUPOPROCESO]));
		}

		public void LlenarGrilla()
		{
			// TODO:  Add ProcesosEstadosFinancieros.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ProcesosEstadosFinancieros.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			this.grid.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(Utilitario.Helper.FooterSpan);
			DataTable dt=this.ObtenerDatos();
			if(dt!=null)
			{
				DataView dw= dt.DefaultView;
				dw.RowFilter = Helper.ObtenerFiltro();
				grid.Columns[Utilitario.Constantes.POSICIONFOOTERTOTAL].FooterText = Utilitario.Constantes.TEXTOFOOTERTOTAL + Utilitario.Constantes.ESPACIO + dw.Count.ToString();
				dw.Sort = columnaOrdenar ;
				grid.DataSource = dw;
				grid.CurrentPageIndex = indicePagina;
				lblResultado.Visible = false;
			}
			else
			{
				grid.DataSource = dt;
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

		public void LlenarCombos()
		{
			// TODO:  Add ProcesosEstadosFinancieros.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add ProcesosEstadosFinancieros.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add ProcesosEstadosFinancieros.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ProcesosEstadosFinancieros.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ProcesosEstadosFinancieros.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ProcesosEstadosFinancieros.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add ProcesosEstadosFinancieros.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ProcesosEstadosFinancieros.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			// TODO:  Add ProcesosEstadosFinancieros.Agregar implementation
		}

		public void Modificar()
		{
			// TODO:  Add ProcesosEstadosFinancieros.Modificar implementation
		}

		public void Eliminar()
		{
			// TODO:  Add ProcesosEstadosFinancieros.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			// TODO:  Add ProcesosEstadosFinancieros.CargarModoPagina implementation
		}

		public void CargarModoNuevo()
		{
			// TODO:  Add ProcesosEstadosFinancieros.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			// TODO:  Add ProcesosEstadosFinancieros.CargarModoModificar implementation
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add ProcesosEstadosFinancieros.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add ProcesosEstadosFinancieros.ValidarCampos implementation
			return false;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add ProcesosEstadosFinancieros.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add ProcesosEstadosFinancieros.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				Helper.ConfiguraColumnaHyperLink(Utilitario.Enumerados.EventosJavaScript.OnClick,e.Item.Cells[0],grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				e.Item.Attributes.Add("CODIGO",dr["CodigoOpcion"].ToString());
				Label lbl;
				lbl = (Label)e.Item.Cells[0].FindControl(LBLUSUARIO);
				lbl.Text = dr["Login"].ToString();
				
				lbl = (Label)e.Item.Cells[0].FindControl(LBLFECHA);
				lbl.Text = dr["UltimaFechaHora"].ToString();
				
				string PortaRetrato = dr["PortaRetrato"].ToString();

				HtmlImage img;
				img = (HtmlImage)e.Item.Cells[0].FindControl(IMGFOTO);
				img.Src = Helper.ObtenerRutaImagenes(Utilitario.Constantes.RUTAFOTOS) + ((PortaRetrato.Length>0)?PortaRetrato +  EXTENSIONFOTO:ARCHIVO);
				img.Attributes.Add("title",dr["NombreUsuario"].ToString());
				

			}
		
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
