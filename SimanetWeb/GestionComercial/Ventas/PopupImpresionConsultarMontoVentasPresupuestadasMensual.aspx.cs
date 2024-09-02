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


namespace SIMA.SimaNetWeb.GestionComercial.Ventas
{
	/// <summary>
	/// Summary description for PopupImpresionConsultarVentasPresupuestadasMensual.
	/// </summary>
	public class PopupImpresionConsultarVentasPresupuestadasMensual : System.Web.UI.Page
	{
		#region Controles
		protected System.Web.UI.WebControls.Label lblCentroOperativo;
		protected System.Web.UI.WebControls.Label lblAno;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.DataGrid dgMontoPresupuestadoMensual;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion

		#region Constantes
		//Otros
		const int MontoCero = 1;
		const int MontoMenorMiles = 3;
		const int CantidadPosicionesBorrar = 3;

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
		const int PosicionItemTotal = 13;

		const string NombreGlosaTotal= "TOTAL";

		const string NombreGlosaTotales = "TOTAL MGP";
		const string NombreGlosaTotales1 = "TOTAL PRIV";
		const string NombreGlosaTotalFinal = "TOTAL FINAL";


		//Key Session y QueryString
		const string GRILLAVACIAVENTAPRESUESTADA ="No existe ninguna Venta Presupuestada.";
		const string GRILLAVACIAVENTAEJECUTADA ="No existe ninguna Venta Ejecutada.";


		#endregion

		#region Variables		
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
			this.dgMontoPresupuestadoMensual.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgMontoPresupuestadoMensual_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			CImpresion oCImpresion =  new CImpresion();
			DataTable dtImpresion =  oCImpresion.ObtenerDataImprimir();
			
			if(dtImpresion.Rows.Count > 0)
			{
				DataView dwImpresion = dtImpresion.DefaultView;
				dgMontoPresupuestadoMensual.DataSource = dwImpresion;
				this.lblCentroOperativo.Text = oCImpresion.ObtenerNombreArchivoExportar();
				this.lblAno.Text = oCImpresion.ObtenerColumnaOrdenamiento();
				this.lblResultado.Visible = false;

			}
			else
			{
				dgMontoPresupuestadoMensual.DataSource = null;
				lblResultado.Visible = true;
				if(oCImpresion.ObtenerIndicePagina() >= DateTime.Today.Year)
				{
					lblResultado.Text = GRILLAVACIAVENTAPRESUESTADA;
				}
				else
				{
					lblResultado.Text = GRILLAVACIAVENTAEJECUTADA;
				}
			}
			try
			{
				dgMontoPresupuestadoMensual.DataBind();
			}
			catch(Exception ex)
			{
				string a = ex.Message;
			}
			
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add PopupImpresionConsultarVentasPresupuestadasMensual.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
		{
			// TODO:  Add PopupImpresionConsultarVentasPresupuestadasMensual.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add PopupImpresionConsultarVentasPresupuestadasMensual.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			lblTitulo.Text = CImpresion.ObtenerTituloReporte();
		}

		public void LlenarJScript()
		{
			// TODO:  Add PopupImpresionConsultarVentasPresupuestadasMensual.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add PopupImpresionConsultarVentasPresupuestadasMensual.RegistrandoJScript implementation
		}

		public void Imprimir()
		{
			ltlMensaje.Text=Helper.Imprimir();
		}

		public void Exportar()
		{
			// TODO:  Add PopupImpresionConsultarVentasPresupuestadasMensual.Exportar implementation
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

		private void dgMontoPresupuestadoMensual_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				int tamaño;

				tamaño =  dr[Enumerados.Meses.Enero.ToString()].ToString().Length;
				if(tamaño > MontoCero)
				{
					if(tamaño > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemEnero].Text = Convert.ToDouble(dr[Enumerados.Meses.Enero.ToString()].ToString().Remove(tamaño-CantidadPosicionesBorrar,CantidadPosicionesBorrar)).ToString(Utilitario.Constantes.FORMATODECIMAL5);
					}
					else
					{
						e.Item.Cells[PosicionItemEnero].Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
				}
				else
				{
					e.Item.Cells[PosicionItemEnero].Text = Constantes.POSICIONCONTADOR.ToString();
				}
				
			
				
				tamaño =  dr[Enumerados.Meses.Febrero.ToString()].ToString().Length;
				if(tamaño > MontoCero)
				{
					if(tamaño > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemFebrero].Text  = Convert.ToDouble(dr[Enumerados.Meses.Febrero.ToString()].ToString().Remove(tamaño-CantidadPosicionesBorrar,CantidadPosicionesBorrar)).ToString(Utilitario.Constantes.FORMATODECIMAL5);
					}
					else
					{
						e.Item.Cells[PosicionItemFebrero].Text  = Constantes.POSICIONCONTADOR.ToString();
					}
					
				}
				else
				{
					e.Item.Cells[PosicionItemFebrero].Text  = Constantes.POSICIONCONTADOR.ToString();
				}
				

			
				tamaño =  dr[Enumerados.Meses.Marzo.ToString()].ToString().Length;
				if(tamaño > MontoCero)
				{
					if(tamaño > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemMarzo].Text  = Convert.ToDouble(dr[Enumerados.Meses.Marzo.ToString()].ToString().Remove(tamaño-CantidadPosicionesBorrar,CantidadPosicionesBorrar)).ToString(Utilitario.Constantes.FORMATODECIMAL5);
					}
					else
					{
						e.Item.Cells[PosicionItemMarzo].Text  = Constantes.POSICIONCONTADOR.ToString();
					}
					
				}
				else
				{
					e.Item.Cells[PosicionItemMarzo].Text  = Constantes.POSICIONCONTADOR.ToString();
				}
				

				tamaño =  dr[Enumerados.Meses.Abril.ToString()].ToString().Length;
				if(tamaño > MontoCero)
				{
					if(tamaño > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemAbril].Text  = Convert.ToDouble(dr[Enumerados.Meses.Abril.ToString()].ToString().Remove(tamaño-CantidadPosicionesBorrar,CantidadPosicionesBorrar)).ToString(Utilitario.Constantes.FORMATODECIMAL5);
					}
					else
					{
						e.Item.Cells[PosicionItemAbril].Text  = Constantes.POSICIONCONTADOR.ToString();
					}
					
				}
				else
				{
					e.Item.Cells[PosicionItemAbril].Text  = Constantes.POSICIONCONTADOR.ToString();
				}
				

				
				tamaño =  dr[Enumerados.Meses.Mayo.ToString()].ToString().Length;
				if(tamaño > MontoCero)
				{
					if(tamaño > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemMayo].Text  = Convert.ToDouble(dr[Enumerados.Meses.Mayo.ToString()].ToString().Remove(tamaño - CantidadPosicionesBorrar,CantidadPosicionesBorrar)).ToString(Utilitario.Constantes.FORMATODECIMAL5);
					}
					else
					{
						e.Item.Cells[PosicionItemMayo].Text  = Constantes.POSICIONCONTADOR.ToString();
					}
					
				}
				else
				{
					e.Item.Cells[PosicionItemMayo].Text  = Constantes.POSICIONCONTADOR.ToString();
				}
				

				
				tamaño =  dr[Enumerados.Meses.Junio.ToString()].ToString().Length;
				if(tamaño > MontoCero)
				{
					if(tamaño > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemJunio].Text  = Convert.ToDouble(dr[Enumerados.Meses.Junio.ToString()].ToString().Remove(tamaño-CantidadPosicionesBorrar,CantidadPosicionesBorrar)).ToString(Utilitario.Constantes.FORMATODECIMAL5);
					}
					else
					{
						e.Item.Cells[PosicionItemJunio].Text  = Constantes.POSICIONCONTADOR.ToString();
					}
					
				}
				else
				{
					e.Item.Cells[PosicionItemJunio].Text  = Constantes.POSICIONCONTADOR.ToString();
				}
				

				
				tamaño =  dr[Enumerados.Meses.Julio.ToString()].ToString().Length;
				if(tamaño > MontoCero)
				{
					if(tamaño > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemJulio].Text  = Convert.ToDouble(dr[Enumerados.Meses.Julio.ToString()].ToString().Remove(tamaño-CantidadPosicionesBorrar,CantidadPosicionesBorrar)).ToString(Utilitario.Constantes.FORMATODECIMAL5);
					}
					else
					{
						e.Item.Cells[PosicionItemJulio].Text  = Constantes.POSICIONCONTADOR.ToString();
					}
					
				}
				else
				{
					e.Item.Cells[PosicionItemJulio].Text  = Constantes.POSICIONCONTADOR.ToString();
				}
				


				tamaño =  dr[Enumerados.Meses.Agosto.ToString()].ToString().Length;
				if(tamaño > MontoCero)
				{
					if(tamaño > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemAgosto].Text  = Convert.ToDouble(dr[Enumerados.Meses.Agosto.ToString()].ToString().Remove(tamaño-CantidadPosicionesBorrar,CantidadPosicionesBorrar)).ToString(Utilitario.Constantes.FORMATODECIMAL5);
					}
					else
					{
						e.Item.Cells[PosicionItemAgosto].Text  = Constantes.POSICIONCONTADOR.ToString();
					}
					
				}
				else
				{
					e.Item.Cells[PosicionItemAgosto].Text  = Constantes.POSICIONCONTADOR.ToString();
				}
				

				tamaño =  dr[Enumerados.Meses.Setiembre.ToString()].ToString().Length;
				if(tamaño > MontoCero)
				{
					if(tamaño > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemSetiembre].Text  = Convert.ToDouble(dr[Enumerados.Meses.Setiembre.ToString()].ToString().Remove(tamaño-CantidadPosicionesBorrar,CantidadPosicionesBorrar)).ToString(Utilitario.Constantes.FORMATODECIMAL5);
					}
					else
					{
						e.Item.Cells[PosicionItemSetiembre].Text  = Constantes.POSICIONCONTADOR.ToString();
					}
					
				}
				else
				{
					e.Item.Cells[PosicionItemSetiembre].Text  = Constantes.POSICIONCONTADOR.ToString();
				}
				


				tamaño =  dr[Enumerados.Meses.Octubre.ToString()].ToString().Length;
				if(tamaño > MontoCero)
				{
					if(tamaño > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemOctubre].Text  = Convert.ToDouble(dr[Enumerados.Meses.Octubre.ToString()].ToString().Remove(tamaño-CantidadPosicionesBorrar,CantidadPosicionesBorrar)).ToString(Utilitario.Constantes.FORMATODECIMAL5);
					}
					else
					{
						e.Item.Cells[PosicionItemOctubre].Text  = Constantes.POSICIONCONTADOR.ToString();
					}
					
				}
				else
				{
					e.Item.Cells[PosicionItemOctubre].Text  = Constantes.POSICIONCONTADOR.ToString();
				}
			

				tamaño =  dr[Enumerados.Meses.Noviembre.ToString()].ToString().Length;
				if(tamaño > MontoCero)
				{
					if(tamaño > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemNoviembre].Text  = Convert.ToDouble(dr[Enumerados.Meses.Noviembre.ToString()].ToString().Remove(tamaño - CantidadPosicionesBorrar,CantidadPosicionesBorrar)).ToString(Utilitario.Constantes.FORMATODECIMAL5);
					}
					else
					{
						e.Item.Cells[PosicionItemNoviembre].Text  = Constantes.POSICIONCONTADOR.ToString();
					}
					
				}
				else
				{
					e.Item.Cells[PosicionItemNoviembre].Text  = Constantes.POSICIONCONTADOR.ToString();
				}
				

				tamaño =  dr[Enumerados.Meses.Diciembre.ToString()].ToString().Length;
				if(tamaño > MontoCero)
				{
					if(tamaño > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemDiciembre].Text  = Convert.ToDouble(dr[Enumerados.Meses.Diciembre.ToString()].ToString().Remove(tamaño - CantidadPosicionesBorrar,CantidadPosicionesBorrar)).ToString(Utilitario.Constantes.FORMATODECIMAL5);
					}
					else
					{
						e.Item.Cells[PosicionItemDiciembre].Text  = Constantes.POSICIONCONTADOR.ToString();
					}
					
				}
				else
				{
					e.Item.Cells[PosicionItemDiciembre].Text  = Constantes.POSICIONCONTADOR.ToString();
				}
				

				tamaño =  dr[NombreGlosaTotal].ToString().Length;
				if(tamaño > MontoCero)
				{
					if(tamaño > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemTotal].Text  = Convert.ToDouble(dr[NombreGlosaTotal].ToString().Remove(tamaño - CantidadPosicionesBorrar,CantidadPosicionesBorrar)).ToString(Utilitario.Constantes.FORMATODECIMAL5);
					}
					else
					{
						e.Item.Cells[PosicionItemTotal].Text  = Constantes.POSICIONCONTADOR.ToString();
					}
					
				}
				else
				{
					e.Item.Cells[PosicionItemTotal].Text  = Constantes.POSICIONCONTADOR.ToString();
				}


				if(e.Item.Cells[Utilitario.Constantes.POSICIONCONTADORVENTASPRESUPUESTADAS].Text == NombreGlosaTotales || e.Item.Cells[Utilitario.Constantes.POSICIONCONTADORVENTASPRESUPUESTADAS].Text == NombreGlosaTotales1 || e.Item.Cells[Utilitario.Constantes.POSICIONCONTADORVENTASPRESUPUESTADAS].Text == NombreGlosaTotalFinal || e.Item.Cells[Utilitario.Constantes.POSICIONCONTADORVENTASPRESUPUESTADAS].Text == NombreGlosaTotal )
				{
					e.Item.Cells[PosicionItemEnero].Font.Bold = true;
					e.Item.Cells[PosicionItemEnero].Font.Size = FontUnit.Point(8);
					e.Item.Cells[PosicionItemEnero].ForeColor = Color.Black;

					e.Item.Cells[PosicionItemFebrero].Font.Bold = true;
					e.Item.Cells[PosicionItemFebrero].Font.Size = FontUnit.Point(8);
					e.Item.Cells[PosicionItemFebrero].ForeColor = Color.Black;
					
					e.Item.Cells[PosicionItemMarzo].Font.Bold = true;
					e.Item.Cells[PosicionItemMarzo].Font.Size = FontUnit.Point(8);
					e.Item.Cells[PosicionItemMarzo].ForeColor = Color.Black;
					
					e.Item.Cells[PosicionItemAbril].Font.Bold = true;
					e.Item.Cells[PosicionItemAbril].Font.Size = FontUnit.Point(8);
					e.Item.Cells[PosicionItemAbril].ForeColor = Color.Black;
					
					e.Item.Cells[PosicionItemMayo].Font.Bold = true;
					e.Item.Cells[PosicionItemMayo].Font.Size = FontUnit.Point(8);
					e.Item.Cells[PosicionItemMayo].ForeColor = Color.Black;
					
					e.Item.Cells[PosicionItemJunio].Font.Bold = true;
					e.Item.Cells[PosicionItemJunio].Font.Size = FontUnit.Point(8);
					e.Item.Cells[PosicionItemJunio].ForeColor = Color.Black;

					e.Item.Cells[PosicionItemJulio].Font.Bold = true;
					e.Item.Cells[PosicionItemJulio].Font.Size = FontUnit.Point(8);
					e.Item.Cells[PosicionItemJulio].ForeColor = Color.Black;
					
					e.Item.Cells[PosicionItemAgosto].Font.Bold = true;
					e.Item.Cells[PosicionItemAgosto].Font.Size = FontUnit.Point(8);
					e.Item.Cells[PosicionItemAgosto].ForeColor = Color.Black;
					
					e.Item.Cells[PosicionItemSetiembre].Font.Bold = true;
					e.Item.Cells[PosicionItemSetiembre].Font.Size = FontUnit.Point(8);
					e.Item.Cells[PosicionItemSetiembre].ForeColor = Color.Black;
					
					e.Item.Cells[PosicionItemOctubre].Font.Bold = true;
					e.Item.Cells[PosicionItemOctubre].Font.Size = FontUnit.Point(8);
					e.Item.Cells[PosicionItemOctubre].ForeColor = Color.Black;
					
					e.Item.Cells[PosicionItemNoviembre].Font.Bold = true;
					e.Item.Cells[PosicionItemNoviembre].Font.Size = FontUnit.Point(8);
					e.Item.Cells[PosicionItemNoviembre].ForeColor = Color.Black;
					
					e.Item.Cells[PosicionItemDiciembre].Font.Bold = true;
					e.Item.Cells[PosicionItemDiciembre].Font.Size = FontUnit.Point(8);
					e.Item.Cells[PosicionItemDiciembre].ForeColor = Color.Black;
					
					e.Item.Cells[PosicionItemTotal].Font.Bold = true;
					e.Item.Cells[PosicionItemTotal].Font.Size = FontUnit.Point(8);
					e.Item.Cells[PosicionItemTotal].ForeColor = Color.Black;

					Helper.ConfigurarColorTotalesGrilla(e);
				}
				else
				{
					Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				}
			}	
		}
	}
}
