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
	/// Summary description for ConsultarInversionesPorCentrodeCosto.
	/// </summary>
	public class ConsultarInversionesPorCentrodeCosto : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		const string GRILLAVACIA="No existe";
		const string KEYQIDCENTROCOSTO ="idCC";
		const string KEYQPERIODO="Periodo";


		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.WebControls.Literal ltlMensaje;

	
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

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			int NroMes = DateTime.Now.Month;
			if(e.Item.ItemType == ListItemType.Header)
			{
				e.Item.Cells[NroMes+2].Text="AVAN.";
				for(int i=NroMes+3;i<=e.Item.Cells.Count-1;i++){
					e.Item.Cells[i].Text= Helper.ObtenerNombreMes(i-2,Utilitario.Enumerados.TipoDatoMes.Abreviatura).ToString().ToUpper();
				}
			}

			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;			

				e.Item.Attributes.Add("IDRUBRO",dr[Enumerados.ColumnasFormato.IdRubro.ToString()].ToString());
				
				Utilitario.Helper.ConfiguraNodosTreeview(e,1,0,dr,
					Utilitario.Constantes.POPUPDEESPERA,
					Helper.HistorialIrAdelantePersonalizado(Utilitario.Constantes.VACIO),
					"MostrarDetalle();"
					);

				double Acumulado=0;
				for(int i=2;i<=NroMes+1;i++){
					double MontoMes = Convert.ToDouble(dr[Helper.ObtenerNombreMes(i-1,Utilitario.Enumerados.TipoDatoMes.NombreCompleto).ToString()].ToString());
					e.Item.Cells[i].Text = MontoMes.ToString(Utilitario.Constantes.FORMATODECIMAL4);
					Acumulado = Acumulado + MontoMes;
				}
				if(Convert.ToDouble(e.Item.Cells[1].Text)==0)
				{
					e.Item.Cells[NroMes+2].Text= "0";
				}
				else
				{
					e.Item.Cells[NroMes+2].Text=  Convert.ToDouble(((Acumulado *100)/ Convert.ToDouble(e.Item.Cells[1].Text))).ToString(Utilitario.Constantes.FORMATODECIMAL0) + "%";
				}
				//Los meses  restantes
				for(int i=NroMes+3;i<=e.Item.Cells.Count-1;i++)
				{
					e.Item.Cells[i].Text= Convert.ToDouble(dr[Helper.ObtenerNombreMes(i-2,Utilitario.Enumerados.TipoDatoMes.NombreCompleto).ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				}

				e.Item.Cells[NroMes+2].BackColor = Color.FromArgb(205,220,224);
				e.Item.Cells[1].Text=  Convert.ToDouble(e.Item.Cells[1].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);

				Utilitario.Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
			}	
		
		}
		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			DataTable dt= (new CPresupuestoInversiones()).ConsultarPresupuestoInversionesporCentroCosto(Convert.ToInt32(Page.Request.Params[KEYQPERIODO]),Convert.ToInt32(Page.Request.Params[KEYQIDCENTROCOSTO]));
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
			// TODO:  Add ConsultarInversionesPorCentrodeCosto.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add ConsultarInversionesPorCentrodeCosto.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add ConsultarInversionesPorCentrodeCosto.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add ConsultarInversionesPorCentrodeCosto.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarInversionesPorCentrodeCosto.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarInversionesPorCentrodeCosto.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarInversionesPorCentrodeCosto.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarInversionesPorCentrodeCosto.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add ConsultarInversionesPorCentrodeCosto.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ConsultarInversionesPorCentrodeCosto.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			// TODO:  Add ConsultarInversionesPorCentrodeCosto.Agregar implementation
		}

		public void Modificar()
		{
			// TODO:  Add ConsultarInversionesPorCentrodeCosto.Modificar implementation
		}

		public void Eliminar()
		{
			// TODO:  Add ConsultarInversionesPorCentrodeCosto.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			// TODO:  Add ConsultarInversionesPorCentrodeCosto.CargarModoPagina implementation
		}

		public void CargarModoNuevo()
		{
			// TODO:  Add ConsultarInversionesPorCentrodeCosto.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			// TODO:  Add ConsultarInversionesPorCentrodeCosto.CargarModoModificar implementation
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add ConsultarInversionesPorCentrodeCosto.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add ConsultarInversionesPorCentrodeCosto.ValidarCampos implementation
			return false;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add ConsultarInversionesPorCentrodeCosto.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add ConsultarInversionesPorCentrodeCosto.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
