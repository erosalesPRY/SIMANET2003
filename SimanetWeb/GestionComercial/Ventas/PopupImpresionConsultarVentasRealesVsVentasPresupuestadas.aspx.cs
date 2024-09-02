using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
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

namespace SIMA.SimaNetWeb.GestionComercial.Ventas
{
	/// <summary>
	/// Summary description for RequerimientosAsignados.
	/// </summary>
	public class PopupImpresionConsultarVentasRealesVsVentasPresupuestadas : System.Web.UI.Page,IPaginaBase
	{
		#region Controles

		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.DataGrid gridChimbote;
		protected System.Web.UI.WebControls.DataGrid gridIquitos;
		protected System.Web.UI.WebControls.Label lblResultadoChimbote;
		protected System.Web.UI.WebControls.Label lblResultadoIquitos;
		protected System.Web.UI.WebControls.Label lblCallao;
		protected System.Web.UI.WebControls.Label lblChimbote;
		protected System.Web.UI.WebControls.Label lblIquitos;

		#endregion Controles

		#region Constantes
		
		//Key Session y QueryString
		const int CantidadCero = 0;
		const string GRILLAVACIACALLAO ="No existe ninguna Venta Ejecutada en SIMA-CALLAO.";
		const string GRILLAVACIACHIMBOTE ="No existe ninguna Venta Ejecutada en SIMA-CHIMBOTE.";
		const string GRILLAVACIAIQUITOS ="No existe ninguna Venta Ejecutada en SIMA-IQUITOS S.R.LTDA.";
		
		const string TablaImpresion0 = "VentaCallao";
		const string TablaImpresion1 = "VentaChimbote";
		const string TablaImpresion2 = "VentaIquitos";
		const string NombreGlosaLogro = "%";
		const string ColumnoTitulo = "titulo";
		const int MontoCero = 1;
		const int MontoMenorMiles = 3;
		const int CantidadPosicionesBorrar = 4;

		const int PosicionItemEnero = 1;
		const int PosicionItemFebrero = 2;
		const int PosicionItemMarzo = 3;
		const int PosicionItemAbril = 4;
		const int PosicionItemMayo = 5;
		const int PosicionItemJunio = 6;
		const int PosicionItemJulio = 7;
		const int PosicionItemAgosto = 8;
		const int PosicionItemSetiembre = 9;
		const int PosicionItemOctubre = 10;
		const int PosicionItemNoviembre = 11;
		const int PosicionItemDiciembre = 12;
		protected System.Web.UI.WebControls.Label lblResultadoCallao;
		protected System.Web.UI.WebControls.DataGrid gridCallao;
		const int PosicionDatoTotal = 13;

		const string ENMILES = " (En Miles)" ;

		#endregion Constantes

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
			this.gridCallao.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.gridCallao_ItemDataBound);
			this.gridChimbote.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.gridChimbote_ItemDataBound);
			this.gridIquitos.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.gridIquitos_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			//Grilla Callao
			CImpresion oCImpresion =  new CImpresion();
			DataSet dsImpresion =  oCImpresion.ObtenerDataSetImprimir();
			
			if(dsImpresion.Tables[TablaImpresion0]!=null)
			{
				DataView dwImpresion0 = dsImpresion.Tables[TablaImpresion0].DefaultView;
				gridCallao.DataSource = dwImpresion0;
				lblResultadoCallao.Visible = false;
			}
			else
			{
				gridCallao.DataSource = null;
				lblResultadoCallao.Text = GRILLAVACIACALLAO;
				lblResultadoCallao.Visible = true;
			}
			try
			{
				gridCallao.DataBind();
			}
			catch(Exception ex)
			{
				string a = ex.Message;
			}

			//Grilla Chimbote
			if(dsImpresion.Tables[TablaImpresion1]!=null)
			{
				DataView dwImpresion1 = dsImpresion.Tables[TablaImpresion1].DefaultView;
				gridChimbote.DataSource = dwImpresion1;
				lblResultadoChimbote.Visible = false;
			}
			else
			{
				gridChimbote.DataSource = null;
				lblResultadoChimbote.Text = GRILLAVACIACHIMBOTE;
				lblResultadoChimbote.Visible = true;
			}
			try
			{
				gridChimbote.DataBind();
			}
			catch(Exception ex)
			{
				string a = ex.Message;
			}

			//Grilla Iquitos
			if(dsImpresion.Tables[TablaImpresion2]!=null)
			{
				DataView dwImpresion2 = dsImpresion.Tables[TablaImpresion2].DefaultView;
				gridIquitos.DataSource = dwImpresion2;
				lblResultadoIquitos.Visible = false;
			}
			else
			{
				gridIquitos.DataSource = null;
				lblResultadoIquitos.Text = GRILLAVACIAIQUITOS;
				lblResultadoIquitos.Visible = true;
			}
			try
			{
				gridIquitos.DataBind();
			}
			catch(Exception ex)
			{
				string a = ex.Message;
			}
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add PopupImpresionConsultarVentasRealesVsVentasPresupuestadas.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
		{
			// TODO:  Add PopupImpresionConsultarVentasRealesVsVentasPresupuestadas.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add PopupImpresionConsultarVentasRealesVsVentasPresupuestadas.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			lblTitulo.Text = CImpresion.ObtenerTituloReporte() + ENMILES;
		}

		public void LlenarJScript()
		{
			// TODO:  Add PopupImpresionConsultarVentasRealesVsVentasPresupuestadas.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add PopupImpresionConsultarVentasRealesVsVentasPresupuestadas.RegistrandoJScript implementation
		}

		public void Imprimir()
		{
			ltlMensaje.Text=Helper.Imprimir();
		}

		public void Exportar()
		{
			// TODO:  Add PopupImpresionConsultarVentasRealesVsVentasPresupuestadas.Exportar implementation
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

		private void gridCallao_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				if(!dr[ColumnoTitulo].ToString().StartsWith(NombreGlosaLogro))
				{
					int int1 = dr[Enumerados.Meses.Enero.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemEnero].Text = dr[Enumerados.Meses.Enero.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar);
					}
					else
					{
						e.Item.Cells[PosicionItemEnero].Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
					int1 = dr[Enumerados.Meses.Febrero.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemFebrero].Text = dr[Enumerados.Meses.Febrero.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar);
					}
					else
					{
						e.Item.Cells[PosicionItemFebrero].Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
					int1 = dr[Enumerados.Meses.Marzo.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemMarzo].Text = dr[Enumerados.Meses.Marzo.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar);
					}
					else
					{
						e.Item.Cells[PosicionItemMarzo].Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
					int1 = dr[Enumerados.Meses.Abril.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemAbril].Text = dr[Enumerados.Meses.Abril.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar);
					}
					else
					{
						e.Item.Cells[PosicionItemAbril].Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
					int1 = dr[Enumerados.Meses.Mayo.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemMayo].Text = dr[Enumerados.Meses.Mayo.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar);
					}
					else
					{
						e.Item.Cells[PosicionItemMayo].Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
					int1 = dr[Enumerados.Meses.Junio.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemJunio].Text = dr[Enumerados.Meses.Junio.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar);
					}
					else
					{
						e.Item.Cells[PosicionItemJunio].Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
					int1 = dr[Enumerados.Meses.Julio.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemJulio].Text = dr[Enumerados.Meses.Julio.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar);
					}
					else
					{
						e.Item.Cells[PosicionItemJulio].Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
					int1 = dr[Enumerados.Meses.Agosto.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemAgosto].Text = dr[Enumerados.Meses.Agosto.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar);
					}
					else
					{
						e.Item.Cells[PosicionItemAgosto].Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
					int1 = dr[Enumerados.Meses.Setiembre.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemSetiembre].Text = dr[Enumerados.Meses.Setiembre.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar);
					}
					else
					{
						e.Item.Cells[PosicionItemSetiembre].Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
					int1 = dr[Enumerados.Meses.Octubre.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemOctubre].Text = dr[Enumerados.Meses.Octubre.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar);
					}
					else
					{
						e.Item.Cells[PosicionItemOctubre].Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
					int1 = dr[Enumerados.Meses.Noviembre.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemNoviembre].Text = dr[Enumerados.Meses.Noviembre.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar);
					}
					else
					{
						e.Item.Cells[PosicionItemNoviembre].Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
					int1 = dr[Enumerados.Meses.Diciembre.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemDiciembre].Text = dr[Enumerados.Meses.Diciembre.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar);
					}
					else
					{
						e.Item.Cells[PosicionItemDiciembre].Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
					int1 = dr[Enumerados.ColumnasVentasReales.total.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionDatoTotal].Text = dr[Enumerados.ColumnasVentasReales.total.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar);
					}
					else
					{
						e.Item.Cells[PosicionDatoTotal].Text = Constantes.POSICIONCONTADOR.ToString();
					}
				}
			}
		}

		private void gridChimbote_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				if(!dr[ColumnoTitulo].ToString().StartsWith(NombreGlosaLogro))
				{
					int int1 = dr[Enumerados.Meses.Enero.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemEnero].Text = dr[Enumerados.Meses.Enero.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar);
					}
					else
					{
						e.Item.Cells[PosicionItemEnero].Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
					int1 = dr[Enumerados.Meses.Febrero.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemFebrero].Text = dr[Enumerados.Meses.Febrero.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar);
					}
					else
					{
						e.Item.Cells[PosicionItemFebrero].Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
					int1 = dr[Enumerados.Meses.Marzo.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemMarzo].Text = dr[Enumerados.Meses.Marzo.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar);
					}
					else
					{
						e.Item.Cells[PosicionItemMarzo].Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
					int1 = dr[Enumerados.Meses.Abril.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemAbril].Text = dr[Enumerados.Meses.Abril.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar);
					}
					else
					{
						e.Item.Cells[PosicionItemAbril].Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
					int1 = dr[Enumerados.Meses.Mayo.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemMayo].Text = dr[Enumerados.Meses.Mayo.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar);
					}
					else
					{
						e.Item.Cells[PosicionItemMayo].Text = Constantes.POSICIONCONTADOR.ToString();
					}

					int1 = dr[Enumerados.Meses.Junio.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemJunio].Text = dr[Enumerados.Meses.Junio.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar);
					}
					else
					{
						e.Item.Cells[PosicionItemJunio].Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
					int1 = dr[Enumerados.Meses.Julio.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemJulio].Text = dr[Enumerados.Meses.Julio.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar);
					}
					else
					{
						e.Item.Cells[PosicionItemJulio].Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
					int1 = dr[Enumerados.Meses.Agosto.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemAgosto].Text = dr[Enumerados.Meses.Agosto.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar);
					}
					else
					{
						e.Item.Cells[PosicionItemAgosto].Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
					int1 = dr[Enumerados.Meses.Setiembre.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemSetiembre].Text = dr[Enumerados.Meses.Setiembre.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar);
					}
					else
					{
						e.Item.Cells[PosicionItemSetiembre].Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
					int1 = dr[Enumerados.Meses.Octubre.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemOctubre].Text = dr[Enumerados.Meses.Octubre.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar);
					}
					else
					{
						e.Item.Cells[PosicionItemOctubre].Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
					int1 = dr[Enumerados.Meses.Noviembre.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemNoviembre].Text = dr[Enumerados.Meses.Noviembre.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar);
					}
					else
					{
						e.Item.Cells[PosicionItemNoviembre].Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
					int1 = dr[Enumerados.Meses.Diciembre.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemDiciembre].Text = dr[Enumerados.Meses.Diciembre.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar);
					}
					else
					{
						e.Item.Cells[PosicionItemDiciembre].Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
					int1 = dr[Enumerados.ColumnasVentasReales.total.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionDatoTotal].Text = dr[Enumerados.ColumnasVentasReales.total.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar);
					}
					else
					{
						e.Item.Cells[PosicionDatoTotal].Text = Constantes.POSICIONCONTADOR.ToString();
					}
				}
			}
		}

		private void gridIquitos_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				if(!dr[ColumnoTitulo].ToString().StartsWith(NombreGlosaLogro))
				{
					int int1 = dr[Enumerados.Meses.Enero.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemEnero].Text = dr[Enumerados.Meses.Enero.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar);
					}
					else
					{
						e.Item.Cells[PosicionItemEnero].Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
					int1 = dr[Enumerados.Meses.Febrero.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemFebrero].Text = dr[Enumerados.Meses.Febrero.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar);
					}
					else
					{
						e.Item.Cells[PosicionItemFebrero].Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
					int1 = dr[Enumerados.Meses.Marzo.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemMarzo].Text = dr[Enumerados.Meses.Marzo.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar);
					}
					else
					{
						e.Item.Cells[PosicionItemMarzo].Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
					int1 = dr[Enumerados.Meses.Abril.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemAbril].Text = dr[Enumerados.Meses.Abril.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar);
					}
					else
					{
						e.Item.Cells[PosicionItemAbril].Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
					int1 = dr[Enumerados.Meses.Mayo.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemMayo].Text = dr[Enumerados.Meses.Mayo.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar);
					}
					else
					{
						e.Item.Cells[PosicionItemMayo].Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
					int1 = dr[Enumerados.Meses.Junio.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemJunio].Text = dr[Enumerados.Meses.Junio.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar);
					}
					else
					{
						e.Item.Cells[PosicionItemJunio].Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
					int1 = dr[Enumerados.Meses.Julio.ToString()].ToString().Length;
					if(int1 > MontoCero)
					{
						if(int1 > MontoMenorMiles)
						{
							e.Item.Cells[PosicionItemJulio].Text = dr[Enumerados.Meses.Julio.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar);
						}
						else
						{
							e.Item.Cells[PosicionItemJulio].Text = Constantes.POSICIONCONTADOR.ToString();
						}
					}
					else
					{
						e.Item.Cells[PosicionItemJulio].Text = dr[Enumerados.Meses.Julio.ToString()].ToString();
					}

					int1 = dr[Enumerados.Meses.Agosto.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemAgosto].Text = dr[Enumerados.Meses.Agosto.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar);
					}
					else
					{
						e.Item.Cells[PosicionItemAgosto].Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
					int1 = dr[Enumerados.Meses.Setiembre.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemSetiembre].Text = dr[Enumerados.Meses.Setiembre.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar);
					}
					else
					{
						e.Item.Cells[PosicionItemSetiembre].Text = Constantes.POSICIONCONTADOR.ToString();
					}

					int1 = dr[Enumerados.Meses.Octubre.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemOctubre].Text = dr[Enumerados.Meses.Octubre.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar);
					}
					else
					{
						e.Item.Cells[PosicionItemOctubre].Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
					int1 = dr[Enumerados.Meses.Noviembre.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemNoviembre].Text = dr[Enumerados.Meses.Noviembre.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar);
					}
					else
					{
						e.Item.Cells[PosicionItemNoviembre].Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
					int1 = dr[Enumerados.Meses.Diciembre.ToString()].ToString().Length;
						
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemDiciembre].Text = dr[Enumerados.Meses.Diciembre.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar);
					}
					else
					{
						e.Item.Cells[PosicionItemDiciembre].Text = Constantes.POSICIONCONTADOR.ToString();
					}
						
					int1 = dr[Enumerados.ColumnasVentasReales.total.ToString()].ToString().Length;
						
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionDatoTotal].Text = dr[Enumerados.ColumnasVentasReales.total.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar);
					}
					else
					{
						e.Item.Cells[PosicionDatoTotal].Text = Constantes.POSICIONCONTADOR.ToString();
					}
				}
			}
		}
	}
}