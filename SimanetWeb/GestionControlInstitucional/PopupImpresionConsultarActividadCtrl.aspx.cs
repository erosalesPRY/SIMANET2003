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

namespace SIMA.SimaNetWeb.GestionControlInstitucional
{
	/// <summary>
	/// Summary description for PopupImpresionConsultarActividadCtrl.
	/// </summary>
	public class PopupImpresionConsultarActividadCtrl : System.Web.UI.Page, IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.DataGrid grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		#endregion Controles

		#region Constantes
		
		//Key Session y QueryString
		const string KEYQID = "Id";	
		const string GRILLAVACIA ="No existe ninguna Actividad de Control.";
		const string MESSELECCIONADO = "X";
		const int PosicionCeldaEnero = 7;
		const int PosicionCeldaFebrero = 8;
		const int PosicionCeldaMarzo = 9;
		const int PosicionCeldaAbril = 10;
		const int PosicionCeldaMayo = 11;
		const int PosicionCeldaJunio = 12;
		const int PosicionCeldaJulio = 13;
		const int PosicionCeldaAgosto = 14;
		const int PosicionCeldaSetiembre = 15;
		const int PosicionCeldaOctubre = 16;
		const int PosicionCeldaNoviembre = 17;
		const int PosicionCeldaDiciembre = 18;

		#endregion Constantes
	
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					this.LlenarDatos();
					this.LlenarGrilla();
					this.Imprimir();
				}
				catch(SIMAExcepcionLog oSIMAExcepcionLog)
				{
					ltlMensaje.Text = Helper.MensajeAlert(oSIMAExcepcionLog.Mensaje);					
				}
				catch(SIMAExcepcionIU oSIMAExcepcionIU)
				{
					ltlMensaje.Text = Helper.MensajeAlert(oSIMAExcepcionIU.Mensaje);					
				}
				catch(SIMAExcepcion oSIMAExcepcion)
				{
					ltlMensaje.Text = Helper.MensajeAlert(oSIMAExcepcion.Mensaje);					
				}
				catch(Exception oException)
				{
					SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
					Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
				}
			}
		}

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			CImpresion oCImpresion =  new CImpresion();
			DataTable dtImpresion =  oCImpresion.ObtenerDataImprimir();
			
			if(dtImpresion!=null)
			{
				DataView dwImpresion = dtImpresion.DefaultView;
				dwImpresion.Sort = oCImpresion.ObtenerColumnaOrdenamiento();
				grid.DataSource = dwImpresion;
				grid.CurrentPageIndex = oCImpresion.ObtenerIndicePagina();
			}
			else
			{
				lblResultado.Text = GRILLAVACIA;

			}
			grid.DataBind();
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
		{
		}

		public void LlenarCombos()
		{
			// TODO:  Add ConsultaDeCartasFianzas.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			lblTitulo.Text = CImpresion.ObtenerTituloReporte();
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultaDeCartasFianzas.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultaDeCartasFianzas.RegistrandoJScript implementation
		}

		public void Imprimir()
		{
			ltlMensaje.Text=Helper.Imprimir();
		}

		public void Exportar()
		{
			// TODO:  Add ConsultaDeCartasFianzas.Exportar implementation
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
			return true;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				if(Convert.ToInt32(dr[Enumerados.ColumnasActividadCtrl.Ene.ToString()]) > Constantes.POSICIONCONTADOR)
				{
					e.Item.Cells[PosicionCeldaEnero].Text = MESSELECCIONADO;
				}
				if(Convert.ToInt32(dr[Enumerados.ColumnasActividadCtrl.Feb.ToString()]) > Constantes.POSICIONCONTADOR)
				{
					e.Item.Cells[PosicionCeldaFebrero].Text = MESSELECCIONADO;
				}
				if(Convert.ToInt32(dr[Enumerados.ColumnasActividadCtrl.Mar.ToString()]) > Constantes.POSICIONCONTADOR)
				{
					e.Item.Cells[PosicionCeldaMarzo].Text = MESSELECCIONADO;
				}
				if(Convert.ToInt32(dr[Enumerados.ColumnasActividadCtrl.Abr.ToString()]) > Constantes.POSICIONCONTADOR)
				{
					e.Item.Cells[PosicionCeldaAbril].Text = MESSELECCIONADO;
				}
				if(Convert.ToInt32(dr[Enumerados.ColumnasActividadCtrl.May.ToString()]) > Constantes.POSICIONCONTADOR)
				{
					e.Item.Cells[PosicionCeldaMayo].Text = MESSELECCIONADO;
				}
				if(Convert.ToInt32(dr[Enumerados.ColumnasActividadCtrl.Jun.ToString()]) > Constantes.POSICIONCONTADOR)
				{
					e.Item.Cells[PosicionCeldaJunio].Text = MESSELECCIONADO;
				}
				if(Convert.ToInt32(dr[Enumerados.ColumnasActividadCtrl.Jul.ToString()]) > Constantes.POSICIONCONTADOR)
				{
					e.Item.Cells[PosicionCeldaJulio].Text = MESSELECCIONADO;
				}
				if(Convert.ToInt32(dr[Enumerados.ColumnasActividadCtrl.Ago.ToString()]) > Constantes.POSICIONCONTADOR)
				{
					e.Item.Cells[PosicionCeldaAgosto].Text = MESSELECCIONADO;
				}
				if(Convert.ToInt32(dr[Enumerados.ColumnasActividadCtrl.Sep.ToString()]) > Constantes.POSICIONCONTADOR)
				{
					e.Item.Cells[PosicionCeldaSetiembre].Text = MESSELECCIONADO;
				}
				if(Convert.ToInt32(dr[Enumerados.ColumnasActividadCtrl.Oct.ToString()]) > Constantes.POSICIONCONTADOR)
				{
					e.Item.Cells[PosicionCeldaOctubre].Text = MESSELECCIONADO;
				}
				if(Convert.ToInt32(dr[Enumerados.ColumnasActividadCtrl.Nov.ToString()]) > Constantes.POSICIONCONTADOR)
				{
					e.Item.Cells[PosicionCeldaNoviembre].Text = MESSELECCIONADO;
				}
				if(Convert.ToInt32(dr[Enumerados.ColumnasActividadCtrl.Dic.ToString()]) > Constantes.POSICIONCONTADOR)
				{
					e.Item.Cells[PosicionCeldaDiciembre].Text = MESSELECCIONADO;
				}
			}

		}

	}
}
