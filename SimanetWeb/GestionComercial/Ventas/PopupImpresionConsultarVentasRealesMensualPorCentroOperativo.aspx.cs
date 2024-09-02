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
	/// Summary description for PopupImpresionConsultarVentasRealesMensualPorCentroOperativo.
	/// </summary>
	public class PopupImpresionConsultarVentasRealesMensualPorCentroOperativo : System.Web.UI.Page,IPaginaBase
	{
		#region Controles

		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblTituloLogro;
		protected System.Web.UI.WebControls.DataGrid grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.DataGrid gridLogro;

		#endregion Controles

		#region Constantes
		
		//Key Session y QueryString
		const string KEYQSUBTITULOREPORTE = "Subtitulo";

		//Otros
		const int CantidadCero = 0;
		const string GRILLAVACIA ="No existe ninguna Venta Ejecutada.";
		const string TablaImpresion0 = "VentaRealPorCentroOperativo";
		const string TablaImpresion1 = "LogroVentaReal";
		const string ColumnoTitulo = "titulo";
		const string NombreGlosaLogro = "%";
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
		const int PosicionDatoTotal = 13;

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
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.gridLogro.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.gridLogro_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			CImpresion oCImpresion =  new CImpresion();
			DataSet dsImpresion =  oCImpresion.ObtenerDataSetImprimir();
			
			if(dsImpresion.Tables[TablaImpresion0]!=null)
			{
				DataView dwImpresion0 = dsImpresion.Tables[TablaImpresion0].DefaultView;
				grid.DataSource = dwImpresion0;
				lblResultado.Visible = false;
			}
			else
			{
				grid.DataSource = null;
				lblResultado.Text = GRILLAVACIA;
				lblResultado.Visible = true;
				this.lblTituloLogro.Visible = false;
			}
			try
			{
				grid.DataBind();
			}
			catch(Exception ex)
			{
				string a = ex.Message;
			}

			if(this.grid.DataSource != null)
			{
				//Logro
				if(dsImpresion.Tables[TablaImpresion1]!=null)
				{
					DataView dwImpresion1 = dsImpresion.Tables[TablaImpresion1].DefaultView;
					gridLogro.DataSource = dwImpresion1;
					lblResultado.Visible = false;
				}
				else
				{
					gridLogro.DataSource = null;
					this.lblTituloLogro.Visible = false;
				}
				try
				{
					gridLogro.DataBind();
				}
				catch(Exception ex)
				{
					string a = ex.Message;
				}
			}
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add PopupImpresionConsultarVentasRealesMensualPorCentroOperativo.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
		{
			// TODO:  Add PopupImpresionConsultarVentasRealesMensualPorCentroOperativo.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add PopupImpresionConsultarVentasRealesMensualPorCentroOperativo.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			lblTitulo.Text = CImpresion.ObtenerTituloReporte()+Constantes.ESPACIO+Constantes.LINEA+Constantes.ESPACIO+Page.Request.QueryString[KEYQSUBTITULOREPORTE];
		}

		public void LlenarJScript()
		{
			// TODO:  Add PopupImpresionConsultarVentasRealesMensualPorCentroOperativo.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add PopupImpresionConsultarVentasRealesMensualPorCentroOperativo.RegistrandoJScript implementation
		}

		public void Imprimir()
		{
		 	ltlMensaje.Text=Helper.Imprimir();
		}

		public void Exportar()
		{
			// TODO:  Add PopupImpresionConsultarVentasRealesMensualPorCentroOperativo.Exportar implementation
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

		private void gridLogro_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
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

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

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
}