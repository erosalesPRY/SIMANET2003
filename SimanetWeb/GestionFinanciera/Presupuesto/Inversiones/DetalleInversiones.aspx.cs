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
using System.IO;


namespace SIMA.SimaNetWeb.GestionFinanciera.Presupuesto.Inversiones
{
	/// <summary>
	/// Summary description for DetalleInversiones.
	/// </summary>
	public class DetalleInversiones : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		#region Constantes
			const string GRILLAVACIA="No existe";
			const string KEYQIDCENTROCOSTO ="idCC";
			const string KEYQPERIODO="Periodo";
			const string KEYQIDTIPOINFORMACION="idTipoInfo";
			const string KEYQIDIDRUBRO="idRubro";

		#endregion

		#region Conttroles
			protected projDataGridWeb.DataGridWeb grid;
			protected System.Web.UI.WebControls.Label lblResultado;
			protected System.Web.UI.WebControls.Label Label1;
			protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
			protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				if(!Page.IsPostBack)
				{
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarJScript();
					this.LlenarDatos();
					this.LlenarGrilla();
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
				string debug = oException.Message.ToString();
				SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
				Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
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

		#region Complementar DataTable
			DataTable Crear(DataTable dt)
			{
				if(dt==null)
				{
					dt= new DataTable();
					dt.Columns.Add("idDetDesFMTCC", typeof(int));
					dt.Columns.Add("Descripcion", typeof(string));
					dt.Columns.Add("Enero", typeof(decimal));
					dt.Columns.Add("Febrero", typeof(decimal));
					dt.Columns.Add("Marzo", typeof(decimal));
					dt.Columns.Add("Abril", typeof(decimal));
					dt.Columns.Add("Mayo", typeof(decimal));
					dt.Columns.Add("Junio", typeof(decimal));
					dt.Columns.Add("Julio", typeof(decimal));
					dt.Columns.Add("Agosto", typeof(decimal));
					dt.Columns.Add("Setiembre", typeof(decimal));
					dt.Columns.Add("Octubre", typeof(decimal));
					dt.Columns.Add("Noviembre", typeof(decimal));
					dt.Columns.Add("Diciembre", typeof(decimal));
				}
				DataRow dr;
				for(int i=0;i<=15;i++){
					dr = dt.NewRow();
					dr["idDetDesFMTCC"] = 0;
					dr["Descripcion"] = "";
					dr["Enero"] = 0;
					dr["Febrero"] = 0;
					dr["Marzo"] = 0;
					dr["Abril"] = 0;
					dr["Mayo"] = 0;
					dr["Junio"] = 0;
					dr["Julio"] = 0;
					dr["Agosto"] = 0;
					dr["Setiembre"] = 0;
					dr["Octubre"] = 0;
					dr["Noviembre"] = 0;
					dr["Diciembre"] = 0;
					dt.Rows.Add(dr);
				}
				return dt;
			}
		#endregion

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			DataTable dt = this.Crear((new CPresupuestoInversiones()).AdministrarPresupuestoInversionesporCentroCostoItemDetalle(24,Convert.ToInt32(Page.Request.Params[KEYQIDIDRUBRO]),Convert.ToInt32(Page.Request.Params[KEYQIDCENTROCOSTO]),Convert.ToInt32(Page.Request.Params[KEYQPERIODO]),Convert.ToInt32(Page.Request.Params[KEYQIDTIPOINFORMACION])));
			if(dt!=null)
			{
				grid.DataSource = dt;
			}
			else
			{
				grid.DataSource = dt;
				lblResultado.Text = GRILLAVACIA;
			}
			grid.DataBind();
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetalleInversiones.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetalleInversiones.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add DetalleInversiones.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add DetalleInversiones.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add DetalleInversiones.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetalleInversiones.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetalleInversiones.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetalleInversiones.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add DetalleInversiones.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add DetalleInversiones.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			// TODO:  Add DetalleInversiones.Agregar implementation
		}

		public void Modificar()
		{
			// TODO:  Add DetalleInversiones.Modificar implementation
		}

		public void Eliminar()
		{
			// TODO:  Add DetalleInversiones.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			// TODO:  Add DetalleInversiones.CargarModoPagina implementation
		}

		public void CargarModoNuevo()
		{
			// TODO:  Add DetalleInversiones.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			// TODO:  Add DetalleInversiones.CargarModoModificar implementation
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add DetalleInversiones.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add DetalleInversiones.ValidarCampos implementation
			return false;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add DetalleInversiones.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add DetalleInversiones.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;			
				e.Item.Attributes.Add("IdDetalleMovCC",dr["idDetDesFMTCC"].ToString());

				TextBox txt = (TextBox)e.Item.Cells[0].FindControl("txtCol0");
				txt.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnKeydown.ToString(),"txtCol_onKeyDown()");
				txt.Text = dr["Descripcion"].ToString();
				
				for(int i=1;i<=12;i++){
					txt = (TextBox)e.Item.Cells[i].FindControl("txtCol" + i.ToString());
					txt.Text = Convert.ToDouble(dr[Utilitario.Helper.ObtenerNombreMes(i,Utilitario.Enumerados.TipoDatoMes.NombreCompleto)]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
					txt.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnKeydown.ToString(),"txtCol_onKeyDown()");
				}
				Utilitario.Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
			}	
		}
	}
}
