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
using SIMA.Controladoras.GestionComercial;

namespace SIMA.SimaNetWeb.GestionComercial.Ventas
{
	/// <summary>
	/// Summary description for ConsultarVentasRealesMensualPorCentroOperativo.
	/// </summary>
	public class ConsultarVentasRealesMensualPorCentroOperativo: System.Web.UI.Page,IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblCentroOperativo;
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
		protected projDataGridWeb.DataGridWeb dgConsulta;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label lblTituloLogro;
		protected projDataGridWeb.DataGridWeb dgConsultaLogro;
		protected System.Web.UI.WebControls.Label lblResultadoLogro;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion

		#region Constantes
		
		//Ordenamiento

		//JScript

		//Columnas DataTable

		//Nombres de Controles
		
		//Paginas
		const string URLDETALLE = "ConsultarDetalleVentasReales.aspx?";
		const string URLIMPRESION = "PopupImpresionConsultarVentasRealesMensualPorCentroOperativo.aspx?";
	
		//Key Session y QueryString
		const string KEYQIDCENTROOPERATIVO = "IdCentroOperativo";
		const string KEYQNOMBRE = "Nombre";
		const string KEYQIDMES = "IdMes";
		const string KEYQNOMBREMES = "NombreMes";
		const string KEYQSUBTITULOREPORTE = "Subtitulo";
		
		//Otros
		const string GRILLAVACIA ="No existe ninguna Venta Ejecutada.";
		const string GRILLALOGROVACIA ="No existe ninguna logro de Ventas.";
		const int MontoCero = 1;
		const int MontoMenorMiles = 3;
		const int CantidadPosicionesBorrar = 4;
		const string ColumnaPpto = "ppto";
		const string ColumnaLogro = "porclogro";

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
		const int PosicionItemPpto= 14;
		const int PosicionItemPorcLogro = 15;		
		const int PosicionDatoTotal1 = 13;

		const string VENTASENERO = "lblVentasRealesEnero";
		const string VENTASFEBRERO = "lblVentasRealesFebrero";
		const string VENTASMARZO = "lblVentasRealesMarzo";
		const string VENTASABRIL = "lblVentasRealesAbril";
		const string VENTASMAYO = "lblVentasRealesMayo";
		const string VENTASJUNIO = "lblVentasRealesJunio";
		const string VENTASJULIO = "lblVentasRealesJulio";
		const string VENTASAGOSTO = "lblVentasRealesAgosto";
		const string VENTASSETIEMBRE = "lblVentasRealesSetiembre";
		const string VENTASOCTUBRE = "lblVentasRealesOctubre";
		const string VENTASNOVIEMBRE = "lblVentasRealesNoviembre";
		const string VENTASDICIEMBRE = "lblVentasRealesDiciembre";
		const string PPTO = "lblPpto";
		const string PORCLOGRO = "lblPorcLogro";

		const string TablaImpresion0 = "VentaRealPorCentroOperativo";
		const string TablaImpresion1 = "LogroVentaReal";
		const string NombreGlosaTotales = "TOTAL";
		const string NombreGlosaTotalesMgp = "MGP";
		const string NombreGlosaTotalesPriv = "PRIV";
		const string NombreGlosaLogro = "%";
		const string ColumnoTitulo = "titulo";
		const string VALORTITULOR = "%LOGRO";

		#endregion Constantes
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();

					this.LlenarDatos();
					
					Helper.ReiniciarSession();

					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se consultaron las Ventas Reales Mensuales del CentroOperativo: "+this.lblCentroOperativo.Text,Enumerados.NivelesErrorLog.I.ToString()));

					this.LlenarGrilla();
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
			this.ibtnImprimir.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnImprimir_Click);
			this.dgConsulta.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgConsulta_ItemDataBound);
			this.dgConsulta.SelectedIndexChanged += new System.EventHandler(this.dgConsulta_SelectedIndexChanged);
			this.dgConsultaLogro.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgConsultaLogro_ItemDataBound);
			this.dgConsultaLogro.SelectedIndexChanged += new System.EventHandler(this.dgConsultaLogro_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			DataSet dsImprimir = new DataSet();

			//Grilla Consulta
			CVentasReales oCVentasReales =  new CVentasReales();
			DataTable dtVentas =  oCVentasReales.ConsultarVentasRealesMensualPorCentroOperativo(Convert.ToInt32(Page.Request.QueryString[KEYQIDCENTROOPERATIVO]), Helper.FechaSimanet.ObtenerFechaSesion());
			
			if(dtVentas!=null)
			{
				DataTable dtImpresion = dtVentas.Copy();
				dtImpresion.TableName = TablaImpresion0;

				DataView dwVentas = dtVentas.DefaultView;
				dgConsulta.DataSource = dwVentas;
				lblResultado.Visible = false;

				dsImprimir.Tables.Add(dtImpresion);
			}
			else
			{
				dgConsulta.DataSource = dtVentas;
				lblResultado.Visible = true;
				lblResultado.Text = GRILLAVACIA;
			}
			
			try
			{
				dgConsulta.DataBind();
			}
			catch(Exception ex)
			{
				string a = ex.Message;
				dgConsulta.DataBind();
			}

			if(dgConsulta.DataSource!=null)
			{
				//Grilla Logro
				DataTable dtLogroVentas =  oCVentasReales.ConsultarLogroVentasRealesMensualPorCentroOperativo(Convert.ToInt32(Page.Request.QueryString[KEYQIDCENTROOPERATIVO]), Helper.FechaSimanet.ObtenerFechaSesion());
			
				if(dtLogroVentas!=null)
				{
					DataTable dtImpresion1 = dtLogroVentas.Copy();
					dtImpresion1.TableName = TablaImpresion1;

					DataView dwLogroVentas = dtLogroVentas.DefaultView;
					dgConsultaLogro.DataSource = dwLogroVentas;
					lblResultado.Visible = false;

					dsImprimir.Tables.Add(dtImpresion1);
				}
				else
				{
					dgConsultaLogro.DataSource = dtLogroVentas;
					lblResultadoLogro.Visible = true;
					lblResultadoLogro.Text = GRILLALOGROVACIA;
				}
			
				try
				{
					dgConsultaLogro.DataBind();
				}
				catch(Exception ex)
				{
					string a = ex.Message;
					dgConsultaLogro.DataBind();
				}
			}
			else
			{
				lblResultadoLogro.Visible = true;
				lblResultadoLogro.Text = GRILLALOGROVACIA;
			}
			CImpresion oCImpresion = new CImpresion();
			oCImpresion.GuardarDataImprimirExportar(dsImprimir,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGOTITULOREPORTEVENTASREALESPORCENTROOPERATIVO));
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarVentasRealesMensualPorCentroOperativo.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add ConsultarVentasRealesMensualPorCentroOperativo.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add ConsultarVentasRealesMensualPorCentroOperativo.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			this.lblCentroOperativo.Text = Constantes.ESPACIO+Constantes.LINEA+Constantes.ESPACIO+Page.Request.QueryString[KEYQNOMBRE];
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarVentasRealesMensualPorCentroOperativo.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarVentasRealesMensualPorCentroOperativo.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			ltlMensaje.Text = Helper.PopupImpresion(URLIMPRESION+KEYQSUBTITULOREPORTE+Constantes.SIGNOIGUAL+Page.Request.QueryString[KEYQNOMBRE],750,500,false,false,false,true,true);
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarVentasRealesMensualPorCentroOperativo.Exportar implementation
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
			return false;
		}

		#endregion

		private void dgConsulta_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				
				
				Label lbl1 = (Label)e.Item.Cells[PosicionItemEnero].FindControl(VENTASENERO);
				int int1 = dr[Enumerados.Meses.Enero.ToString()].ToString().Length;
				if(int1 > MontoMenorMiles)
				{
					lbl1.Text = dr[Enumerados.Meses.Enero.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar).Replace(Constantes.SIGNOCOMA,Constantes.ESPACIO);
				}
				else
				{
					lbl1.Text = Constantes.POSICIONCONTADOR.ToString();
				}

				Label lbl2 = (Label)e.Item.Cells[PosicionItemFebrero].FindControl(VENTASFEBRERO);
				int1 = dr[Enumerados.Meses.Febrero.ToString()].ToString().Length;
				
				if(int1 > MontoMenorMiles)
				{
					lbl2.Text = dr[Enumerados.Meses.Febrero.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar).Replace(Constantes.SIGNOCOMA,Constantes.ESPACIO);
				}
				else
				{
					lbl2.Text = Constantes.POSICIONCONTADOR.ToString();
				}

				Label lbl3 = (Label)e.Item.Cells[PosicionItemMarzo].FindControl(VENTASMARZO);
				int1 = dr[Enumerados.Meses.Marzo.ToString()].ToString().Length;
				
				if(int1 > MontoMenorMiles)
				{
					lbl3.Text = dr[Enumerados.Meses.Marzo.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar).Replace(Constantes.SIGNOCOMA,Constantes.ESPACIO);
				}
				else
				{
					lbl3.Text = Constantes.POSICIONCONTADOR.ToString();
				}

				Label lbl4 = (Label)e.Item.Cells[PosicionItemAbril].FindControl(VENTASABRIL);
				int1 = dr[Enumerados.Meses.Abril.ToString()].ToString().Length;
				
				if(int1 > MontoMenorMiles)
				{
					lbl4.Text = dr[Enumerados.Meses.Abril.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar).Replace(Constantes.SIGNOCOMA,Constantes.ESPACIO);
				}
				else
				{
					lbl4.Text = Constantes.POSICIONCONTADOR.ToString();
				}
				
				Label lbl5 = (Label)e.Item.Cells[PosicionItemMayo].FindControl(VENTASMAYO);
				int1 = dr[Enumerados.Meses.Mayo.ToString()].ToString().Length;
				
				if(int1 > MontoMenorMiles)
				{
					lbl5.Text = dr[Enumerados.Meses.Mayo.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar).Replace(Constantes.SIGNOCOMA,Constantes.ESPACIO);
				}
				else
				{
					lbl5.Text = Constantes.POSICIONCONTADOR.ToString();
				}

				Label lbl6 = (Label)e.Item.Cells[PosicionItemJunio].FindControl(VENTASJUNIO);
				int1 = dr[Enumerados.Meses.Junio.ToString()].ToString().Length;
				
				if(int1 > MontoMenorMiles)
				{
					lbl6.Text = dr[Enumerados.Meses.Junio.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar).Replace(Constantes.SIGNOCOMA,Constantes.ESPACIO);
				}
				else
				{
					lbl6.Text = Constantes.POSICIONCONTADOR.ToString();
				}
				
				Label lbl7 = (Label)e.Item.Cells[PosicionItemJulio].FindControl(VENTASJULIO);
				int1 = dr[Enumerados.Meses.Julio.ToString()].ToString().Length;
				
				if(int1 > MontoMenorMiles)
				{
					lbl7.Text = dr[Enumerados.Meses.Julio.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar).Replace(Constantes.SIGNOCOMA,Constantes.ESPACIO);
				}
				else
				{
					lbl7.Text = Constantes.POSICIONCONTADOR.ToString();
				}
				
				Label lbl8 = (Label)e.Item.Cells[PosicionItemAgosto].FindControl(VENTASAGOSTO);
				int1 = dr[Enumerados.Meses.Agosto.ToString()].ToString().Length;
				
				if(int1 > MontoMenorMiles)
				{
					lbl8.Text = dr[Enumerados.Meses.Agosto.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar).Replace(Constantes.SIGNOCOMA,Constantes.ESPACIO);
				}
				else
				{
					lbl8.Text = Constantes.POSICIONCONTADOR.ToString();
				}
				
				Label lbl9 = (Label)e.Item.Cells[PosicionItemSetiembre].FindControl(VENTASSETIEMBRE);
				int1 = dr[Enumerados.Meses.Setiembre.ToString()].ToString().Length;
				
				if(int1 > MontoMenorMiles)
				{
					lbl9.Text = dr[Enumerados.Meses.Setiembre.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar).Replace(Constantes.SIGNOCOMA,Constantes.ESPACIO);
				}
				else
				{
					lbl9.Text = Constantes.POSICIONCONTADOR.ToString();
				}
				
				Label lbl10 = (Label)e.Item.Cells[PosicionItemOctubre].FindControl(VENTASOCTUBRE);
				int1 = dr[Enumerados.Meses.Octubre.ToString()].ToString().Length;
				
				if(int1 > MontoMenorMiles)
				{
					lbl10.Text = dr[Enumerados.Meses.Octubre.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar).Replace(Constantes.SIGNOCOMA,Constantes.ESPACIO);
				}
				else
				{
					lbl10.Text = Constantes.POSICIONCONTADOR.ToString();
				}
				
				Label lbl11 = (Label)e.Item.Cells[PosicionItemNoviembre].FindControl(VENTASNOVIEMBRE);
				int1 = dr[Enumerados.Meses.Noviembre.ToString()].ToString().Length;
				
				if(int1 > MontoMenorMiles)
				{
					lbl11.Text = dr[Enumerados.Meses.Noviembre.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar).Replace(Constantes.SIGNOCOMA,Constantes.ESPACIO);
				}
				else
				{
					lbl11.Text = Constantes.POSICIONCONTADOR.ToString();
				}
				
				Label lbl12 = (Label)e.Item.Cells[PosicionItemDiciembre].FindControl(VENTASDICIEMBRE);
				int1 = dr[Enumerados.Meses.Diciembre.ToString()].ToString().Length;
				
				if(int1 > MontoMenorMiles)
				{
					lbl12.Text = dr[Enumerados.Meses.Diciembre.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar).Replace(Constantes.SIGNOCOMA,Constantes.ESPACIO);
				}
				else
				{
					lbl12.Text = Constantes.POSICIONCONTADOR.ToString();
				}
				

				int1 = dr[Enumerados.ColumnasVentasReales.total.ToString()].ToString().Length;
				
				if(int1 > MontoMenorMiles)
				{
					e.Item.Cells[PosicionDatoTotal].Text = dr[Enumerados.ColumnasVentasReales.total.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar).Replace(Constantes.SIGNOCOMA,Constantes.ESPACIO);
				}
				else
				{
					e.Item.Cells[PosicionDatoTotal].Text = Constantes.POSICIONCONTADOR.ToString();
				}
			
				/*Nuevo*/
				Label lbl13 = (Label)e.Item.Cells[PosicionItemPpto].FindControl(PPTO);
				int1 = dr[ColumnaPpto].ToString().Length;
				
				if(int1 > MontoMenorMiles)
				{
					lbl13.Text = dr[ColumnaPpto].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar).Replace(Constantes.SIGNOCOMA,Constantes.ESPACIO);
				}
				else
				{
					lbl13.Text = dr[ColumnaPpto].ToString();
				}
				

				Label lbl14 = (Label)e.Item.Cells[PosicionItemPorcLogro].FindControl(PORCLOGRO);
				int1 = dr[ColumnaLogro].ToString().Length;

				if(int1 > MontoMenorMiles)
				{
					lbl14.Text = dr[ColumnaLogro].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar).Replace(Constantes.SIGNOCOMA,Constantes.ESPACIO);
				}
				else
				{
					lbl14.Text = dr[ColumnaLogro].ToString();
				}
			
				if(e.Item.Cells[Constantes.POSICIONCONTADOR].Text.StartsWith(NombreGlosaTotales)||e.Item.Cells[Constantes.POSICIONCONTADOR].Text.StartsWith(NombreGlosaTotalesMgp)||e.Item.Cells[Constantes.POSICIONCONTADOR].Text.StartsWith(NombreGlosaTotalesPriv))
				{
					Helper.ConfigurarColorTotalesGrilla(e);
				}
				else
				{
					Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				}


			}

			if (e.Item.ItemType == ListItemType.Header)
			{
				for(int i=PosicionItemEnero;i<=PosicionItemDiciembre;i++)
				{
					e.Item.Cells[i].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
					e.Item.Cells[i].Font.Underline=true;
					e.Item.Cells[i].Style[Constantes.CURSOR] = Constantes.TIPOCURSORMANO;
				}

				e.Item.Cells[PosicionItemEnero].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.MostrarVentana(URLDETALLE,KEYQIDMES + Constantes.SIGNOIGUAL + Convert.ToInt32(Enumerados.Meses.Enero).ToString() + Constantes.SIGNOAMPERSON + 
					KEYQNOMBREMES + Constantes.SIGNOIGUAL + Enumerados.Meses.Enero.ToString() + Constantes.SIGNOAMPERSON + 
					KEYQIDCENTROOPERATIVO + Constantes.SIGNOIGUAL + Convert.ToInt32(Page.Request.QueryString[KEYQIDCENTROOPERATIVO]).ToString() + Constantes.SIGNOAMPERSON + 
					KEYQNOMBRE + Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQNOMBRE]) + Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.POPUPDEESPERA);

				e.Item.Cells[PosicionItemFebrero].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.MostrarVentana(URLDETALLE,KEYQIDMES + Constantes.SIGNOIGUAL + Convert.ToInt32(Enumerados.Meses.Febrero).ToString() + Constantes.SIGNOAMPERSON + 
					KEYQNOMBREMES + Constantes.SIGNOIGUAL + Enumerados.Meses.Febrero.ToString() + Constantes.SIGNOAMPERSON + 
					KEYQIDCENTROOPERATIVO + Constantes.SIGNOIGUAL + Convert.ToInt32(Page.Request.QueryString[KEYQIDCENTROOPERATIVO]).ToString() + Constantes.SIGNOAMPERSON + 
					KEYQNOMBRE + Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQNOMBRE]) + Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.POPUPDEESPERA);

				e.Item.Cells[PosicionItemMarzo].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.MostrarVentana(URLDETALLE,KEYQIDMES + Constantes.SIGNOIGUAL + Convert.ToInt32(Enumerados.Meses.Marzo).ToString() + Constantes.SIGNOAMPERSON + 
					KEYQNOMBREMES + Constantes.SIGNOIGUAL + Enumerados.Meses.Marzo.ToString() + Constantes.SIGNOAMPERSON + 
					KEYQIDCENTROOPERATIVO + Constantes.SIGNOIGUAL + Convert.ToInt32(Page.Request.QueryString[KEYQIDCENTROOPERATIVO]).ToString() + Constantes.SIGNOAMPERSON + 
					KEYQNOMBRE + Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQNOMBRE]) + Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.POPUPDEESPERA);

				e.Item.Cells[PosicionItemAbril].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.MostrarVentana(URLDETALLE,KEYQIDMES + Constantes.SIGNOIGUAL + Convert.ToInt32(Enumerados.Meses.Abril).ToString() + Constantes.SIGNOAMPERSON + 
					KEYQNOMBREMES + Constantes.SIGNOIGUAL + Enumerados.Meses.Abril.ToString() + Constantes.SIGNOAMPERSON + 
					KEYQIDCENTROOPERATIVO + Constantes.SIGNOIGUAL + Convert.ToInt32(Page.Request.QueryString[KEYQIDCENTROOPERATIVO]).ToString() + Constantes.SIGNOAMPERSON + 
					KEYQNOMBRE + Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQNOMBRE]) + Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.POPUPDEESPERA);

				e.Item.Cells[PosicionItemMayo].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.MostrarVentana(URLDETALLE,KEYQIDMES + Constantes.SIGNOIGUAL + Convert.ToInt32(Enumerados.Meses.Mayo).ToString() + Constantes.SIGNOAMPERSON + 
					KEYQNOMBREMES + Constantes.SIGNOIGUAL + Enumerados.Meses.Mayo.ToString() + Constantes.SIGNOAMPERSON + 
					KEYQIDCENTROOPERATIVO + Constantes.SIGNOIGUAL + Convert.ToInt32(Page.Request.QueryString[KEYQIDCENTROOPERATIVO]).ToString() + Constantes.SIGNOAMPERSON + 
					KEYQNOMBRE + Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQNOMBRE]) + Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.POPUPDEESPERA);

				e.Item.Cells[PosicionItemJunio].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.MostrarVentana(URLDETALLE,KEYQIDMES + Constantes.SIGNOIGUAL + Convert.ToInt32(Enumerados.Meses.Junio).ToString() + Constantes.SIGNOAMPERSON + 
					KEYQNOMBREMES + Constantes.SIGNOIGUAL + Enumerados.Meses.Junio.ToString() + Constantes.SIGNOAMPERSON + 
					KEYQIDCENTROOPERATIVO + Constantes.SIGNOIGUAL + Convert.ToInt32(Page.Request.QueryString[KEYQIDCENTROOPERATIVO]).ToString() + Constantes.SIGNOAMPERSON + 
					KEYQNOMBRE + Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQNOMBRE]) + Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.POPUPDEESPERA);

				e.Item.Cells[PosicionItemJulio].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.MostrarVentana(URLDETALLE,KEYQIDMES + Constantes.SIGNOIGUAL + Convert.ToInt32(Enumerados.Meses.Julio).ToString() + Constantes.SIGNOAMPERSON + 
					KEYQNOMBREMES + Constantes.SIGNOIGUAL + Enumerados.Meses.Julio.ToString() + Constantes.SIGNOAMPERSON + 
					KEYQIDCENTROOPERATIVO + Constantes.SIGNOIGUAL + Convert.ToInt32(Page.Request.QueryString[KEYQIDCENTROOPERATIVO]).ToString() + Constantes.SIGNOAMPERSON + 
					KEYQNOMBRE + Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQNOMBRE]) + Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.POPUPDEESPERA);

				e.Item.Cells[PosicionItemAgosto].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.MostrarVentana(URLDETALLE,KEYQIDMES + Constantes.SIGNOIGUAL + Convert.ToInt32(Enumerados.Meses.Agosto).ToString() + Constantes.SIGNOAMPERSON + 
					KEYQNOMBREMES + Constantes.SIGNOIGUAL + Enumerados.Meses.Agosto.ToString() + Constantes.SIGNOAMPERSON + 
					KEYQIDCENTROOPERATIVO + Constantes.SIGNOIGUAL + Convert.ToInt32(Page.Request.QueryString[KEYQIDCENTROOPERATIVO]).ToString() + Constantes.SIGNOAMPERSON + 
					KEYQNOMBRE + Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQNOMBRE]) + Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.POPUPDEESPERA);

				e.Item.Cells[PosicionItemSetiembre].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.MostrarVentana(URLDETALLE,KEYQIDMES + Constantes.SIGNOIGUAL + Convert.ToInt32(Enumerados.Meses.Setiembre).ToString() + Constantes.SIGNOAMPERSON + 
					KEYQNOMBREMES + Constantes.SIGNOIGUAL + Enumerados.Meses.Setiembre.ToString() + Constantes.SIGNOAMPERSON + 
					KEYQIDCENTROOPERATIVO + Constantes.SIGNOIGUAL + Convert.ToInt32(Page.Request.QueryString[KEYQIDCENTROOPERATIVO]).ToString() + Constantes.SIGNOAMPERSON + 
					KEYQNOMBRE + Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQNOMBRE]) + Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.POPUPDEESPERA);

				e.Item.Cells[PosicionItemOctubre].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.MostrarVentana(URLDETALLE,KEYQIDMES + Constantes.SIGNOIGUAL + Convert.ToInt32(Enumerados.Meses.Octubre).ToString() + Constantes.SIGNOAMPERSON + 
					KEYQNOMBREMES + Constantes.SIGNOIGUAL + Enumerados.Meses.Octubre.ToString() + Constantes.SIGNOAMPERSON + 
					KEYQIDCENTROOPERATIVO + Constantes.SIGNOIGUAL + Convert.ToInt32(Page.Request.QueryString[KEYQIDCENTROOPERATIVO]).ToString() + Constantes.SIGNOAMPERSON + 
					KEYQNOMBRE + Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQNOMBRE]) + Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.POPUPDEESPERA);

				e.Item.Cells[PosicionItemNoviembre].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.MostrarVentana(URLDETALLE,KEYQIDMES + Constantes.SIGNOIGUAL + Convert.ToInt32(Enumerados.Meses.Noviembre).ToString() + Constantes.SIGNOAMPERSON + 
					KEYQNOMBREMES + Constantes.SIGNOIGUAL + Enumerados.Meses.Noviembre.ToString() + Constantes.SIGNOAMPERSON + 
					KEYQIDCENTROOPERATIVO + Constantes.SIGNOIGUAL + Convert.ToInt32(Page.Request.QueryString[KEYQIDCENTROOPERATIVO]).ToString() + Constantes.SIGNOAMPERSON + 
					KEYQNOMBRE + Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQNOMBRE]) + Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.POPUPDEESPERA);

				e.Item.Cells[PosicionItemDiciembre].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.MostrarVentana(URLDETALLE,KEYQIDMES + Constantes.SIGNOIGUAL + Convert.ToInt32(Enumerados.Meses.Diciembre).ToString() + Constantes.SIGNOAMPERSON + 
					KEYQNOMBREMES + Constantes.SIGNOIGUAL + Enumerados.Meses.Diciembre.ToString() + Constantes.SIGNOAMPERSON + 
					KEYQIDCENTROOPERATIVO + Constantes.SIGNOIGUAL + Convert.ToInt32(Page.Request.QueryString[KEYQIDCENTROOPERATIVO]).ToString() + Constantes.SIGNOAMPERSON + 
					KEYQNOMBRE + Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQNOMBRE]) + Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.POPUPDEESPERA);
			}
		}

		private void dgConsultaLogro_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				string valor = dr[ColumnoTitulo].ToString();

				if(dr[ColumnoTitulo].ToString() != VALORTITULOR)
				{
					int int1 = dr[Enumerados.Meses.Enero.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemEnero].Text = dr[Enumerados.Meses.Enero.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar).Replace(Constantes.SIGNOCOMA,Constantes.ESPACIO);
					}
					else
					{
						e.Item.Cells[PosicionItemEnero].Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
					int1 = dr[Enumerados.Meses.Febrero.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemFebrero].Text = dr[Enumerados.Meses.Febrero.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar).Replace(Constantes.SIGNOCOMA,Constantes.ESPACIO);
					}
					else
					{
						e.Item.Cells[PosicionItemFebrero].Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
					int1 = dr[Enumerados.Meses.Marzo.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemMarzo].Text = dr[Enumerados.Meses.Marzo.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar).Replace(Constantes.SIGNOCOMA,Constantes.ESPACIO);
					}
					else
					{
						e.Item.Cells[PosicionItemMarzo].Text = Constantes.POSICIONCONTADOR.ToString();
					}

					int1 = dr[Enumerados.Meses.Abril.ToString()].ToString().Length;

					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemAbril].Text = dr[Enumerados.Meses.Abril.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar).Replace(Constantes.SIGNOCOMA,Constantes.ESPACIO);
					}
					else
					{
						e.Item.Cells[PosicionItemAbril].Text = Constantes.POSICIONCONTADOR.ToString();
					}

					int1 = dr[Enumerados.Meses.Mayo.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemMayo].Text = dr[Enumerados.Meses.Mayo.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar).Replace(Constantes.SIGNOCOMA,Constantes.ESPACIO);
					}
					else
					{
						e.Item.Cells[PosicionItemMayo].Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
					int1 = dr[Enumerados.Meses.Junio.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemJunio].Text = dr[Enumerados.Meses.Junio.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar).Replace(Constantes.SIGNOCOMA,Constantes.ESPACIO);
					}
					else
					{
						e.Item.Cells[PosicionItemJunio].Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
					int1 = dr[Enumerados.Meses.Julio.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemJulio].Text = dr[Enumerados.Meses.Julio.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar).Replace(Constantes.SIGNOCOMA,Constantes.ESPACIO);
					}
					else
					{
						e.Item.Cells[PosicionItemJulio].Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
					int1 = dr[Enumerados.Meses.Agosto.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemAgosto].Text = dr[Enumerados.Meses.Agosto.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar).Replace(Constantes.SIGNOCOMA,Constantes.ESPACIO);
					}
					else
					{
						e.Item.Cells[PosicionItemAgosto].Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
					int1 = dr[Enumerados.Meses.Setiembre.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemSetiembre].Text = dr[Enumerados.Meses.Setiembre.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar).Replace(Constantes.SIGNOCOMA,Constantes.ESPACIO);
					}
					else
					{
						e.Item.Cells[PosicionItemSetiembre].Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
					int1 = dr[Enumerados.Meses.Octubre.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemOctubre].Text = dr[Enumerados.Meses.Octubre.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar).Replace(Constantes.SIGNOCOMA,Constantes.ESPACIO);
					}
					else
					{
						e.Item.Cells[PosicionItemOctubre].Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
					int1 = dr[Enumerados.Meses.Noviembre.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemNoviembre].Text = dr[Enumerados.Meses.Noviembre.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar).Replace(Constantes.SIGNOCOMA,Constantes.ESPACIO);
					}
					else
					{
						e.Item.Cells[PosicionItemNoviembre].Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
					int1 = dr[Enumerados.Meses.Diciembre.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemDiciembre].Text = dr[Enumerados.Meses.Diciembre.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar).Replace(Constantes.SIGNOCOMA,Constantes.ESPACIO);
					}
					else
					{
						e.Item.Cells[PosicionItemDiciembre].Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
					int1 = dr[Enumerados.ColumnasVentasReales.total.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionDatoTotal].Text = dr[Enumerados.ColumnasVentasReales.total.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar).Replace(Constantes.SIGNOCOMA,Constantes.ESPACIO);
					}
					else
					{
						e.Item.Cells[PosicionDatoTotal1].Text = Constantes.POSICIONCONTADOR.ToString();
					}
				}

				if(e.Item.Cells[Constantes.POSICIONCONTADOR].Text.StartsWith(NombreGlosaLogro))
				{
					Helper.ConfigurarColorTotalesGrilla(e);
				}
				else
				{
					Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				}
			}
		}

		private void ibtnImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Imprimir();
		}

		private void dgConsultaLogro_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void dgConsulta_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}