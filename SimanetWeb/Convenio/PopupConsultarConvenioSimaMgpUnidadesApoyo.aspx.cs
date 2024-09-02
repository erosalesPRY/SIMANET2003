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
using NullableTypes;

namespace SIMA.SimaNetWeb.Convenio
{
	public class PopupConsultarConvenioSimaMgpUnidadesApoyo : System.Web.UI.Page , IPaginaBase
	{
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
			this.grid1.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid1_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion	
		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			CImpresion oCImpresion =  new CImpresion();
			DataSet dsImpresion =  oCImpresion.ObtenerDataSetImprimir();

			if(dsImpresion.Tables[TablaImpresion0] != null)
			{
				DataView dwImpresion0 = dsImpresion.Tables[TablaImpresion0].DefaultView;
				dwImpresion0.Sort = COLORDENAMIENTO;
				grid.DataSource = dwImpresion0;
				lblResultado.Visible = Utilitario.Constantes.VALORUNCHECKEDBOOL;
			}
			else
			{
				grid.DataSource = null;
				lblResultado.Text = GRILLAVACIA;
				lblResultado.Visible = Utilitario.Constantes.VALORCHECKEDBOOL;
			}

			try
			{
				grid.DataBind();
			}
			catch(Exception ex)
			{
				string a = ex.Message;
			}


			//Grilla Apoyo Unidades
			this.ReiniciarVariableAcumuladas();
			this.lblTitulo1.Text = oCImpresion.ObtenerColumnaOrdenamiento();
			if(dsImpresion.Tables[TablaImpresion1] != null)
			{
				DataView dwImpresion1 = dsImpresion.Tables[TablaImpresion1].DefaultView;
				grid1.DataSource = dwImpresion1;
				lblResultado1.Visible = Utilitario.Constantes.VALORUNCHECKEDBOOL;
			}
			else
			{
				grid1.DataSource = null;
				lblResultado1.Text = GRILLAVACIA1;
				lblResultado1.Visible = Utilitario.Constantes.VALORCHECKEDBOOL;
			}

			try
			{
				grid1.DataBind();
			}
			catch(Exception ex)
			{
				string a = ex.Message;
			}


		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add PopupConsultarConvenioSimaMgpUnidadesApoyo.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add PopupConsultarConvenioSimaMgpUnidadesApoyo.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add PopupConsultarConvenioSimaMgpUnidadesApoyo.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			this.lblTitulo.Text = CImpresion.ObtenerTituloReporte();
		}

		public void LlenarJScript()
		{
			// TODO:  Add PopupConsultarConvenioSimaMgpUnidadesApoyo.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add PopupConsultarConvenioSimaMgpUnidadesApoyo.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			this.ltlMensaje.Text = Helper.Imprimir();
		}

		public void Exportar()
		{
			// TODO:  Add PopupConsultarConvenioSimaMgpUnidadesApoyo.Exportar implementation
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
			// TODO:  Add PopupConsultarConvenioSimaMgpUnidadesApoyo.ValidarFiltros implementation
			return Utilitario.Constantes.VALORUNCHECKEDBOOL;
		}

		#endregion		
		#region Constantes
		private const string TablaImpresion0 = "ConvenioSimaMgp";
		private const string TablaImpresion1 = "ApoyoUnidades";
		private const string GRILLAVACIA ="No existe ningun Convenio Sima-Mgp.";
		private const string GRILLAVACIA1 ="No existe ningun Apoyo de Unidades";
		private const string COLORDENAMIENTO = "NroConvenio Asc";
		private const string CAMPOID="ID";
		private const int ValorConstanteDos=2;
		private const string CAMPOCOMOPERPAC="COMOPERPAC";
		private const string CAMPOFASUB="FASUB";
		private const string MENSAJECONSULTAR="Se consultó el Popup de Convenios Sima Mgp";
		#endregion		
		#region Controles
		protected System.Web.UI.WebControls.Label lblResultado1;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblTitulo1;
		protected projDataGridWeb.DataGridWeb grid1;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion
		#region Variables
		//Otros
		private double acumMontoAsignado=0;
		private double acumMontoAprovado=0;
		private double acumMontoEjecutado=0;
		private double acumMontoEnEjecucion=0;
		private double acumMontoComprometido=0;
		private double acumMontoPorCobrar=0;
		private double acumMontoSaldo=0;
		#endregion
		#region Eventos
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
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Utilitario.Enumerados.NombresdeModulo.ConveniosyProyectos.ToString(),this.ToString(),MENSAJECONSULTAR,Enumerados.NivelesErrorLog.I.ToString()));
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
					SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Utilitario.Constantes.CODIGOERRORGENERICO,oException.Message);
					Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
				}
			}
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				
				acumMontoAsignado = acumMontoAsignado + NullableIsNull.IsNullDouble(dr[Enumerados.ColumnasConvenioSimaMgp.MontoAsignado.ToString()],Utilitario.Constantes.ValorConstanteCero);
				acumMontoAprovado = acumMontoAprovado + NullableIsNull.IsNullDouble(dr[Enumerados.ColumnasConvenioSimaMgp.MontoAprobado.ToString()],Utilitario.Constantes.ValorConstanteCero);
				acumMontoEjecutado = acumMontoEjecutado + NullableIsNull.IsNullDouble(dr[Enumerados.ColumnasConvenioSimaMgp.MontoEjecutado.ToString()],Utilitario.Constantes.ValorConstanteCero);
				acumMontoEnEjecucion = acumMontoEnEjecucion + NullableIsNull.IsNullDouble(dr[Enumerados.ColumnasConvenioSimaMgp.MontoEnEjecucion.ToString()],Utilitario.Constantes.ValorConstanteCero);
				acumMontoComprometido = acumMontoComprometido + NullableIsNull.IsNullDouble(dr[Enumerados.ColumnasConvenioSimaMgp.MontoComprometido.ToString()],Utilitario.Constantes.ValorConstanteCero);
				acumMontoSaldo = acumMontoSaldo + NullableIsNull.IsNullDouble(dr[Enumerados.ColumnasConvenioSimaMgp.MontoSaldo.ToString()],Utilitario.Constantes.ValorConstanteCero);
				acumMontoPorCobrar = acumMontoPorCobrar + NullableIsNull.IsNullDouble(dr[Enumerados.ColumnasConvenioSimaMgp.MontoPorCobrar.ToString()],Utilitario.Constantes.ValorConstanteCero);
			}	
			else if(e.Item.ItemType == ListItemType.Footer)
			{
				e.Item.Cells[Utilitario.Constantes.POSICIONINDEXCERO].Text =Utilitario.Constantes.TEXTOTOTAL + " " + Utilitario.Enumerados.Moneda.NS;
				e.Item.Cells[Utilitario.Constantes.POSICIONINDEXUNO].Text = acumMontoAsignado.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[Utilitario.Constantes.POSICIONINDEXDOS].Text = acumMontoAprovado.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[Utilitario.Constantes.POSICIONINDEXTRES].Text = acumMontoEjecutado.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[Utilitario.Constantes.POSICIONINDEXCUATRO].Text = acumMontoEnEjecucion.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[Utilitario.Constantes.POSICIONINDEXCINCO].Text = acumMontoComprometido.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[Utilitario.Constantes.POSICIONINDEXSEIS].Text = acumMontoSaldo.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[Utilitario.Constantes.POSICIONINDEXSIETE].Text=acumMontoPorCobrar.ToString(Utilitario.Constantes.FORMATODECIMAL4);
			}
		}

		private void grid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				
		
				if(Convert.ToDouble(dr[CAMPOID])== Utilitario.Constantes.ValorConstanteUno)
				{
					e.Item.Cells[Utilitario.Constantes.POSICIONINDEXCERO].Text=CAMPOCOMOPERPAC;
					e.Item.Cells[Utilitario.Constantes.POSICIONINDEXCERO].ToolTip="Apoyo Unidades COMOPERPAC";
				}
				if(Convert.ToDouble(dr[CAMPOID])==ValorConstanteDos)
				{
					e.Item.Cells[Utilitario.Constantes.POSICIONINDEXCERO].Text=CAMPOFASUB;
					e.Item.Cells[Utilitario.Constantes.POSICIONINDEXCERO].ToolTip="Apoyo Unidades SUBMARINAS";
				}

				this.acumMontoAsignado += NullableIsNull.IsNullDouble(dr[Utilitario.Enumerados.ApoyoUnidadSubMarinoColumnas.MontoAsignado.ToString()], Utilitario.Constantes.ValorConstanteCero);
				this.acumMontoAprovado += NullableIsNull.IsNullDouble(dr[Utilitario.Enumerados.ApoyoUnidadSubMarinoColumnas.MontoAprobado.ToString()], Utilitario.Constantes.ValorConstanteCero);
				this.acumMontoEjecutado += NullableIsNull.IsNullDouble(dr[Utilitario.Enumerados.ApoyoUnidadSubMarinoColumnas.MontoEjecutado.ToString()], Utilitario.Constantes.ValorConstanteCero);
				this.acumMontoEnEjecucion += NullableIsNull.IsNullDouble(dr[Utilitario.Enumerados.ApoyoUnidadSubMarinoColumnas.MontoEnEjecucion.ToString()], Utilitario.Constantes.ValorConstanteCero);
				this.acumMontoComprometido += NullableIsNull.IsNullDouble(dr[Utilitario.Enumerados.ApoyoUnidadSubMarinoColumnas.MontoComprometido.ToString()], Utilitario.Constantes.ValorConstanteCero);
				this.acumMontoSaldo += NullableIsNull.IsNullDouble(dr[Utilitario.Enumerados.ApoyoUnidadSubMarinoColumnas.MontoSaldo.ToString()], Utilitario.Constantes.ValorConstanteCero);

			}
			else if(e.Item.ItemType == ListItemType.Footer)
			{
				e.Item.Cells[Utilitario.Constantes.POSICIONINDEXUNO].Text = acumMontoAsignado.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[Utilitario.Constantes.POSICIONINDEXDOS].Text = acumMontoAprovado.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[Utilitario.Constantes.POSICIONINDEXTRES].Text = acumMontoEjecutado.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[Utilitario.Constantes.POSICIONINDEXCUATRO].Text = acumMontoEnEjecucion.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[Utilitario.Constantes.POSICIONINDEXCINCO].Text = acumMontoComprometido.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[Utilitario.Constantes.POSICIONINDEXSEIS].Text = acumMontoSaldo.ToString(Utilitario.Constantes.FORMATODECIMAL4);
			}
		}

		private void ReiniciarVariableAcumuladas()
		{
			acumMontoAsignado=Utilitario.Constantes.ValorConstanteCero;
			acumMontoAprovado=Utilitario.Constantes.ValorConstanteCero;
			acumMontoEjecutado=Utilitario.Constantes.ValorConstanteCero;
			acumMontoEnEjecucion=Utilitario.Constantes.ValorConstanteCero;
			acumMontoComprometido=Utilitario.Constantes.ValorConstanteCero;
			acumMontoPorCobrar=Utilitario.Constantes.ValorConstanteCero;
			acumMontoSaldo=Utilitario.Constantes.ValorConstanteCero;
		}

		#endregion
	}
}
