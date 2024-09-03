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
using SIMA.Controladoras.General;
using SIMA.Controladoras.GestionFinanciera;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;
using System.Drawing.Printing;


namespace SIMA.SimaNetWeb.GestionFinanciera.PresupuestoVarios
{
	/// <summary>
	/// Summary description for ConsultarMovimientodeMateriales.
	/// </summary>
	public class ConsultarMovimientodeMateriales : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{

		#region Constantes
			const string KEYQIDPERIODO = "QIDPERIODO";
			const string KEYQIDMES = "QIDMES";
			const string KEYIDCUENTA = "QIDCUENTA";
			const string KEYIDGRUPOCC="QIDGRPCC";
			const string KEYIDCENTRO ="QIDCC";
			const string KEYQIDDESCNAT = "QIDDESCNAT";
			const string KEYQIDMONTO = "QIDMONTO";
		


			const string GRILLAVACIA ="No existe ningún Registro.";  
			//const string URLPAGINAPRESUPUESTOADM = "../PresupuestoAdministrativo/ConsultarPresupuesto.aspx?";
						
			DataTable dtItem;

		//Otros
		const string SESSIONTBLDETMATERIALES ="tblDetalleMateriales";
		const string VALORAND ="AND";

		//DataGrid and DataTable 
		const string VALORXAREA ="XAREA";
		const string VALORAREA ="AREA :";
		const string VALORXCODIGO ="XCODIGO";
		const string VALORXDESCRIPCION ="XDESCRIPCION";
		const string VALORXTOTAL ="XTOTAL";
		const string VALORXMAXITEM ="XMAXITEM";
		const string VALORXSALIDA ="XSALIDA";
		const string VALORXFECHA= "XFECHA";
		const string VALORXCANTIDAD ="XCANTIDAD";
		const string VALORXMONTO ="XMONTO";
		const string VALORXNRO ="XNRO";
		const string VALORXITEM ="XITEM";

		const string COLUMNAMONTO ="Monto";
		const string COLUMNACANTIDADITEM ="CantidadItem";
		const string COLUMNANROVALESALIDA ="NroValeSalida";
		const string COLUMNAFECHA ="Fecha";
		const string COLUMNACANTMATERIAL ="CantidadMaterial";
		const string COLUMNAUNIDMEDIDAREQ ="UnidadMedidaRequerimiento";

		#endregion

		#region Controles
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.HtmlControls.HtmlGenericControl ItemMaterial;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox txtNaturalezaDescripcion;
		protected System.Web.UI.WebControls.TextBox txtMontoReal;
		protected System.Web.UI.HtmlControls.HtmlGenericControl tblMaster;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion Controles

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarDatos();
					this.LlenarCombos();
					
					this.LlenarGrillaOrdenamientoPaginacion("",Constantes.INDICEPAGINADEFAULT);
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
					ltlMensaje.Text = Helper.MsgdbErrMostrarMesaje(true,oSIMAExcepcionDominio.Error.ToString());					
				}
				catch(Exception oException)
				{
					string msgb =oException.Message.ToString();
					SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
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

		public void LlenarGrilla()
		{
			// TODO:  Add ConsultarMovimientodeMateriales.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarMovimientodeMateriales.LlenarGrillaOrdenamiento implementation
		}
		private DataTable ObtenerDatos()
		{
			CPresupuesto oCPresupuesto = new  CPresupuesto();
			DataTable tblResultado =oCPresupuesto.ConsultarMovimientodeMateriales
					(Convert.ToInt32(Page.Request.Params[KEYQIDPERIODO])
					,Convert.ToInt32(Page.Request.Params[KEYQIDMES])
					//,Convert.ToInt32(Page.Request.Params[KEYIDGRUPOCC])
					,Convert.ToInt32(Page.Request.Params[KEYIDCENTRO])
					,Convert.ToInt32(Page.Request.Params[KEYIDCUENTA])
					);
			return tblResultado;
		}
		private DataTable GenerarResumen(DataTable dt)
		{
			if (dt!=null)
			{
				int NroResumen = 20;
				CResumenItem oCResumenItem = new CResumenItem();
				DataTable dtFinal= Helper.Resumen(oCResumenItem.ObtenerConfiDataResumen(NroResumen),dt);
				return dtFinal;
				
			}
			else
			{
				return dt;
			}
		}


		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			Session[SESSIONTBLDETMATERIALES] = this.ObtenerDatos();
			DataTable dtGeneral = this.GenerarResumen((DataTable) Session[SESSIONTBLDETMATERIALES]); //this.ObtenerDatos();
			if(dtGeneral!=null)
			{
				grid.DataSource = dtGeneral;
				lblResultado.Visible = false;
			}
			else
			{
				grid.DataSource = dtGeneral;
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
			// TODO:  Add ConsultarMovimientodeMateriales.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			txtNaturalezaDescripcion.Text = Page.Request.Params[KEYQIDDESCNAT].ToString();
			txtMontoReal.Text = Page.Request.Params[KEYQIDMONTO].ToString();
				
			// TODO:  Add ConsultarMovimientodeMateriales.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarMovimientodeMateriales.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarMovimientodeMateriales.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarMovimientodeMateriales.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarMovimientodeMateriales.Exportar implementation
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
			// TODO:  Add ConsultarMovimientodeMateriales.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			// TODO:  Add ConsultarMovimientodeMateriales.Agregar implementation
		}

		public void Modificar()
		{
			// TODO:  Add ConsultarMovimientodeMateriales.Modificar implementation
		}

		public void Eliminar()
		{
			// TODO:  Add ConsultarMovimientodeMateriales.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			// TODO:  Add ConsultarMovimientodeMateriales.CargarModoPagina implementation
		}

		public void CargarModoNuevo()
		{
			// TODO:  Add ConsultarMovimientodeMateriales.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			// TODO:  Add ConsultarMovimientodeMateriales.CargarModoModificar implementation
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add ConsultarMovimientodeMateriales.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add ConsultarMovimientodeMateriales.ValidarCampos implementation
			return false;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add ConsultarMovimientodeMateriales.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add ConsultarMovimientodeMateriales.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				string strTabla = this.tblMaster.InnerHtml.ToString();
				string strItem = this.ItemMaterial.InnerHtml.ToString();
				string TablayData = strTabla.Replace(Utilitario.Constantes.SIGNOABRECORCHETES + VALORXAREA + Utilitario.Constantes.SIGNOCIERRACORCHETES,VALORAREA + dr[Utilitario.Enumerados.ColumnasArea.Nombre.ToString()].ToString())
											.Replace(VALORXCODIGO,dr[Utilitario.Enumerados.ColumnasMaterial.NroMaterial.ToString()].ToString())
											.Replace(VALORXDESCRIPCION,dr[Utilitario.Enumerados.ColumnasMaterial.Descripcion.ToString()].ToString())
											.Replace(VALORXTOTAL,Convert.ToDouble(dr[COLUMNAMONTO]).ToString(Utilitario.Constantes.FORMATODECIMAL4))
											.Replace(VALORXMAXITEM,dr[COLUMNACANTIDADITEM].ToString());
				string ItemyData=String.Empty;

				dtItem = (DataTable) Session[SESSIONTBLDETMATERIALES];

				int Nro=Utilitario.Constantes.ValorConstanteCero;
				foreach( DataRow drItemList in  dtItem.Select(Utilitario.Enumerados.ColumnasArea.Nombre.ToString()
															+ Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.SIGNOCOMILLASIMPLE
															+ dr[Utilitario.Enumerados.ColumnasArea.Nombre.ToString()].ToString()
															+ Utilitario.Constantes.SIGNOCOMILLASIMPLE
															+ Utilitario.Constantes.ESPACIO + VALORAND + Utilitario.Constantes.ESPACIO
															+ Utilitario.Enumerados.ColumnasMaterial.IdMaterial.ToString()
															+ Utilitario.Constantes.SIGNOIGUAL  + Utilitario.Constantes.SIGNOCOMILLASIMPLE
															+ dr[Utilitario.Enumerados.ColumnasMaterial.IdMaterial.ToString()].ToString()
															+ Utilitario.Constantes.SIGNOCOMILLASIMPLE))
				{
					Nro ++;
					ItemyData += strItem.Replace(VALORXSALIDA,drItemList[COLUMNANROVALESALIDA].ToString())
										.Replace(VALORXFECHA,drItemList[COLUMNAFECHA].ToString())
										.Replace(VALORXCANTIDAD,drItemList[COLUMNACANTMATERIAL].ToString() + Utilitario.Constantes.ESPACIO + drItemList[COLUMNAUNIDMEDIDAREQ].ToString())
										.Replace(VALORXMONTO,Convert.ToDouble(drItemList[COLUMNAMONTO].ToString()).ToString(Utilitario.Constantes.FORMATODECIMAL4))
										.Replace(VALORXNRO,Nro.ToString());	
				}
				e.Item.Cells[0].Text = TablayData.Replace(Utilitario.Constantes.SIGNOABRECORCHETES + VALORXITEM + Utilitario.Constantes.SIGNOCIERRACORCHETES,ItemyData.ToString());
			}
			if(e.Item.ItemType == ListItemType.Footer)
			{Session[SESSIONTBLDETMATERIALES]=null;}
		}
	}
}
