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
using SIMA.Controladoras.GestionComercial;
using SIMA.Controladoras;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;



namespace SIMA.SimaNetWeb.GestionComercial.Ventas
{
	/// <summary>
	/// Summary description for ConsultarVentasPresupuestadasMensualPorCentroOperativo.
	/// </summary>
	public class ConsultarVentaMensualUnisys: System.Web.UI.Page, IPaginaBase
	{
		#region Controles

		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
		protected projDataGridWeb.DataGridWeb dgConsulta;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion
		
		#region Constantes

		//Ordenamiento
		//JScript
		//Columnas DataTable
		//Nombres de Controles
		//Paginas
		//private int Mes;
		const string URLDETALLE = "ConsultarVentaMensualUnisys.aspx?";
		const string URLIMPRESION = "PopupImpresionConsultarVentaMensualUnisys.aspx?";

		//Key Session y QueryString
		const string KEYQANO = "Ano";
		const string KEYQIDCENTROOPERATIVO = "CENTROOPERATIVO";
		const string KEYQMES = "Mes";
		const string KEYSINDICEMES = "INDICEMES";
		const string KEYQNOMBREMES = "NOMBREMES";
		const string KEYFLAGPAGINA = "flagpagina";
		const string KEYQIDVERSION = "IDVERSION";

		//Otros
		const string GRILLAVACIA="No existe Datos";
		const string PERIODO = "Ano";
		protected System.Web.UI.WebControls.Label CENTROOPERATIVO;
		const int PosicionItemTipo = 0;
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
        
		const string TIPO = "lblVentaColocadaUnisysTipo"; 
		const string ENERO = "lblVentaColocadaUnisysEnero"; 
		const string FEBRERO = "lblVentaColocadaUnisysFebrero";
		const string MARZO = "lblVentaColocadaUnisysMarzo";
		const string ABRIL = "lblVentaColocadaUnisysAbril";
		const string MAYO = "lblVentaColocadaUnisysMayo";
		const string JUNIO = "lblVentaColocadaUnisysJunio";
		const string JULIO = "lblVentaColocadaUnisysJulio";
		const string AGOSTO = "lblVentaColocadaUnisysAgosto";
		const string SETIEMBRE = "lblVentaColocadaUnisysSetiembre";
		const string OCTUBRE = "lblVentaColocadaUnisysOctubre";
		const string NOVIEMBRE = "lblVentaColocadaUnisysNoviembre";
		const string DICIEMBRE = "lblVentaColocadaUnisysDiciembre";
		const string TOTAL = "lblVentaColocadaUnisysTotal";

		const string NombreGlosaTotal= "TOTAL";

		const string NombreGlosaTotales = "TOTAL MGP";
		const string NombreGlosaTotales1 = "TOTAL PRIV";
		const string NombreGlosaTotalFinal = "TOTAL FINAL";

		const int MontoCero = 1;
		const int MontoMenorMiles = 3;
		const int CantidadPosicionesBorrar = 3;
		const int PORMES = 1;
		protected System.Web.UI.WebControls.Label lblAno;
	//	protected System.Web.UI.WebControls.Label CENTROOPERATIVO;
	

		#endregion


		#region Variables
		Label lbl;
		#endregion

		private int Ano
		{
			get{return Convert.ToInt32(Page.Request.QueryString[KEYQANO]);}
		}
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
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se consultaron las Ordenes de Trabajo Generadas en el Sistema Unisys del SIMA-CALLAO",Enumerados.NivelesErrorLog.I.ToString()));;
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members
		public void LlenarGrilla()
		{
			DataTable dtVentas = new DataTable();
			CVentasReales oCVentasReales =  new CVentasReales();
			dtVentas =  oCVentasReales.ConsultarVentaMensualUnisys(Ano);
				
		

			if(dtVentas!=null)
			{
				DataView dwVentas = dtVentas.DefaultView;
				dgConsulta.DataSource = dwVentas;
				lblResultado.Visible = true;

				#region totalizador
//				double[] aArreglo = Helper.TotalizarDataView(dwVentas,Enumerados.Meses.Enero.ToString());
//				dgConsulta.Columns[PosicionItemEnero].FooterText = aArreglo[0].ToString(Utilitario.Constantes.FORMATODECIMAL4);
//
//				double[] bArreglo = Helper.TotalizarDataView(dwVentas,Enumerados.Meses.Febrero.ToString());
//				dgConsulta.Columns[PosicionItemFebrero].FooterText = bArreglo[0].ToString(Utilitario.Constantes.FORMATODECIMAL4);
//
//				double[] cArreglo = Helper.TotalizarDataView(dwVentas,Enumerados.Meses.Marzo.ToString());
//				dgConsulta.Columns[PosicionItemMarzo].FooterText = cArreglo[0].ToString(Utilitario.Constantes.FORMATODECIMAL4);
//
//				double[] dArreglo = Helper.TotalizarDataView(dwVentas,Enumerados.Meses.Abril.ToString());
//				dgConsulta.Columns[PosicionItemAbril].FooterText = dArreglo[0].ToString(Utilitario.Constantes.FORMATODECIMAL4);
//
//				double[] eArreglo = Helper.TotalizarDataView(dwVentas,Enumerados.Meses.Mayo.ToString());
//				dgConsulta.Columns[PosicionItemMayo].FooterText = eArreglo[0].ToString(Utilitario.Constantes.FORMATODECIMAL4);
//
//				double[] fArreglo = Helper.TotalizarDataView(dwVentas,Enumerados.Meses.Junio.ToString());
//				dgConsulta.Columns[PosicionItemJunio].FooterText = fArreglo[0].ToString(Utilitario.Constantes.FORMATODECIMAL4);
//
//				double[] gArreglo = Helper.TotalizarDataView(dwVentas,Enumerados.Meses.Julio.ToString());
//				dgConsulta.Columns[PosicionItemJulio].FooterText = gArreglo[0].ToString(Utilitario.Constantes.FORMATODECIMAL4);
//
//				double[] hArreglo = Helper.TotalizarDataView(dwVentas,Enumerados.Meses.Agosto.ToString());
//				dgConsulta.Columns[PosicionItemAgosto].FooterText = hArreglo[0].ToString(Utilitario.Constantes.FORMATODECIMAL4);
//
//				double[] iArreglo = Helper.TotalizarDataView(dwVentas,Enumerados.Meses.Setiembre.ToString());
//				dgConsulta.Columns[PosicionItemSetiembre].FooterText = iArreglo[0].ToString(Utilitario.Constantes.FORMATODECIMAL4);
//
//				double[] jArreglo = Helper.TotalizarDataView(dwVentas,Enumerados.Meses.Octubre.ToString());
//				dgConsulta.Columns[PosicionItemOctubre].FooterText = jArreglo[0].ToString(Utilitario.Constantes.FORMATODECIMAL4);
//
//				double[] kArreglo = Helper.TotalizarDataView(dwVentas,Enumerados.Meses.Noviembre.ToString());
//				dgConsulta.Columns[PosicionItemNoviembre].FooterText = kArreglo[0].ToString(Utilitario.Constantes.FORMATODECIMAL4);
//
//				double[] lArreglo = Helper.TotalizarDataView(dwVentas,Enumerados.Meses.Diciembre.ToString());
//				dgConsulta.Columns[PosicionItemDiciembre].FooterText = lArreglo[0].ToString(Utilitario.Constantes.FORMATODECIMAL4);
//
//				double[] mArreglo = Helper.TotalizarDataView(dwVentas,Enumerados.ColumnasVentasPresupuestadas.Total.ToString());
//				dgConsulta.Columns[PosicionItemTotal].FooterText = lArreglo[0].ToString(Utilitario.Constantes.FORMATODECIMAL4);
				#endregion

			}
			else
			{
				dgConsulta.DataSource = dtVentas;
				this.lblResultado.Visible = true;
				this.ibtnImprimir.Visible = false;
				if(Convert.ToInt32(Page.Request.QueryString[KEYQANO])>= DateTime.Now.Year)
				{
					lblResultado.Text = GRILLAVACIA;
				}
				else
				{
					lblResultado.Text = GRILLAVACIA;
				}
			}
			
			try
			{
				DataTable dtImpresion = dtVentas.Copy();

				dgConsulta.DataBind();
				CImpresion oCImpresion = new CImpresion(); 
				if(Convert.ToInt32(Page.Request.QueryString[KEYQANO])>= DateTime.Now.Year)
				{
					oCImpresion.GuardarDataImprimirExportar(dtImpresion,
									Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGOTITULOREPORTEVENTASCOLOCADASUNISYS),
									Page.Request.QueryString[KEYQANO] + Utilitario.Constantes.LINEA,Utilitario.Constantes.INDICEPAGINADEFAULT);
				}
				else
				{
					oCImpresion.GuardarDataImprimirExportar(dtImpresion,
									Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGOTITULOREPORTEVENTASEJECUTADASMENSUALES),
						            Page.Request.QueryString[KEYQANO],Utilitario.Constantes.INDICEPAGINADEFAULT);
				}

			}
			catch(Exception ex)
			{
				string a = ex.Message;
				dgConsulta.CurrentPageIndex = 0;
				dgConsulta.DataBind();
			}
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarVentaMensualUnisys.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add ConsultarVentaMensualUnisys.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add ConsultarVentaMensualUnisys.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			
			if(this.Ano>= DateTime.Now.Year)
			   {
				this.lblAno.Text = this.Ano.ToString() + Utilitario.Constantes.ESPACIO + Utilitario.Constantes.LINEA ;
			   }
			else
			{
				this.lblAno.Text = this.Ano.ToString();
			}
			
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarVentaMensualUnisys.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarVentaMensualUnisys.RegistrarJScript implementation
			
		}

		public void Imprimir()
		{
			ltlMensaje.Text = Helper.PopupImpresion(URLIMPRESION,770,500,false,false,false,true,true);
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarVentaMensualUnisys.Exportar implementation
			
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
                {
					lbl = (Label)e.Item.Cells[PosicionItemTipo].FindControl(TIPO);
					
				}
				int tamaño;
              	lbl = (Label)e.Item.Cells[PosicionItemEnero].FindControl(ENERO);
					
				tamaño =  dr[Enumerados.Meses.Enero.ToString()].ToString().Length;
				if(tamaño > MontoCero)
				{
					if(tamaño > MontoMenorMiles)
					{
						lbl.Text = Convert.ToDouble(dr[Enumerados.Meses.Enero.ToString()].ToString().Remove(tamaño-CantidadPosicionesBorrar,CantidadPosicionesBorrar)).ToString(Utilitario.Constantes.FORMATODECIMAL5);
					}
					else
					{
						lbl.Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
				}
				else
				{
					lbl.Text = Constantes.POSICIONCONTADOR.ToString();
				}
				
			
				lbl = (Label)e.Item.Cells[PosicionItemFebrero].FindControl(FEBRERO);
				tamaño =  dr[Enumerados.Meses.Febrero.ToString()].ToString().Length;
				if(tamaño > MontoCero)
				{
					if(tamaño > MontoMenorMiles)
					{
						lbl.Text = Convert.ToDouble(dr[Enumerados.Meses.Febrero.ToString()].ToString().Remove(tamaño-CantidadPosicionesBorrar,CantidadPosicionesBorrar)).ToString(Utilitario.Constantes.FORMATODECIMAL5);
					}
					else
					{
						lbl.Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
				}
				else
				{
					lbl.Text =  Constantes.POSICIONCONTADOR.ToString();
				}
				

				lbl = (Label)e.Item.Cells[PosicionItemMarzo].FindControl(MARZO);
				tamaño =  dr[Enumerados.Meses.Marzo.ToString()].ToString().Length;
				if(tamaño > MontoCero)
				{
					if(tamaño > MontoMenorMiles)
					{
						lbl.Text = Convert.ToDouble(dr[Enumerados.Meses.Marzo.ToString()].ToString().Remove(tamaño-CantidadPosicionesBorrar,CantidadPosicionesBorrar)).ToString(Utilitario.Constantes.FORMATODECIMAL5);
					}
					else
					{
						lbl.Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
				}
				else
				{
					lbl.Text = Constantes.POSICIONCONTADOR.ToString();
				}
				

				lbl = (Label)e.Item.Cells[PosicionItemAbril].FindControl(ABRIL);
				tamaño =  dr[Enumerados.Meses.Abril.ToString()].ToString().Length;
				if(tamaño > MontoCero)
				{
					if(tamaño > MontoMenorMiles)
					{
						lbl.Text = Convert.ToDouble(dr[Enumerados.Meses.Abril.ToString()].ToString().Remove(tamaño-CantidadPosicionesBorrar,CantidadPosicionesBorrar)).ToString(Utilitario.Constantes.FORMATODECIMAL5);
					}
					else
					{
						lbl.Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
				}
				else
				{
					lbl.Text = Constantes.POSICIONCONTADOR.ToString();
				}
				

				lbl = (Label)e.Item.Cells[PosicionItemMayo].FindControl(MAYO);
				tamaño =  dr[Enumerados.Meses.Mayo.ToString()].ToString().Length;
				if(tamaño > MontoCero)
				{
					if(tamaño > MontoMenorMiles)
					{
						lbl.Text = Convert.ToDouble(dr[Enumerados.Meses.Mayo.ToString()].ToString().Remove(tamaño - CantidadPosicionesBorrar,CantidadPosicionesBorrar)).ToString(Utilitario.Constantes.FORMATODECIMAL5);
					}
					else
					{
						lbl.Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
				}
				else
				{
					lbl.Text = Constantes.POSICIONCONTADOR.ToString();
				}
				

				lbl = (Label)e.Item.Cells[PosicionItemJunio].FindControl(JUNIO);
				tamaño =  dr[Enumerados.Meses.Junio.ToString()].ToString().Length;
				if(tamaño > MontoCero)
				{
					if(tamaño > MontoMenorMiles)
					{
						lbl.Text = Convert.ToDouble(dr[Enumerados.Meses.Junio.ToString()].ToString().Remove(tamaño-CantidadPosicionesBorrar,CantidadPosicionesBorrar)).ToString(Utilitario.Constantes.FORMATODECIMAL5);
					}
					else
					{
						lbl.Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
				}
				else
				{
					lbl.Text = Constantes.POSICIONCONTADOR.ToString();
				}
				

				lbl = (Label)e.Item.Cells[PosicionItemJulio].FindControl(JULIO);
				tamaño =  dr[Enumerados.Meses.Julio.ToString()].ToString().Length;
				if(tamaño > MontoCero)
				{
					if(tamaño > MontoMenorMiles)
					{
						lbl.Text = Convert.ToDouble(dr[Enumerados.Meses.Julio.ToString()].ToString().Remove(tamaño-CantidadPosicionesBorrar,CantidadPosicionesBorrar)).ToString(Utilitario.Constantes.FORMATODECIMAL5);
					}
					else
					{
						lbl.Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
				}
				else
				{
					lbl.Text = Constantes.POSICIONCONTADOR.ToString();
				}
				
				lbl = (Label)e.Item.Cells[PosicionItemAgosto].FindControl(AGOSTO);
				tamaño =  dr[Enumerados.Meses.Agosto.ToString()].ToString().Length;
				if(tamaño > MontoCero)
				{
					if(tamaño > MontoMenorMiles)
					{
						lbl.Text = Convert.ToDouble(dr[Enumerados.Meses.Agosto.ToString()].ToString().Remove(tamaño-CantidadPosicionesBorrar,CantidadPosicionesBorrar)).ToString(Utilitario.Constantes.FORMATODECIMAL5);
					}
					else
					{
						lbl.Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
				}
				else
				{
					lbl.Text = Constantes.POSICIONCONTADOR.ToString();
				}
				
				lbl = (Label)e.Item.Cells[PosicionItemSetiembre].FindControl(SETIEMBRE);
				tamaño =  dr[Enumerados.Meses.Setiembre.ToString()].ToString().Length;
				if(tamaño > MontoCero)
				{
					if(tamaño > MontoMenorMiles)
					{
						lbl.Text = Convert.ToDouble(dr[Enumerados.Meses.Setiembre.ToString()].ToString().Remove(tamaño-CantidadPosicionesBorrar,CantidadPosicionesBorrar)).ToString(Utilitario.Constantes.FORMATODECIMAL5);
					}
					else
					{
						lbl.Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
				}
				else
				{
					lbl.Text = Constantes.POSICIONCONTADOR.ToString();
				}
				
				lbl = (Label)e.Item.Cells[PosicionItemOctubre].FindControl(OCTUBRE);
				tamaño =  dr[Enumerados.Meses.Octubre.ToString()].ToString().Length;
				if(tamaño > MontoCero)
				{
					if(tamaño > MontoMenorMiles)
					{
						lbl.Text = Convert.ToDouble(dr[Enumerados.Meses.Octubre.ToString()].ToString().Remove(tamaño-CantidadPosicionesBorrar,CantidadPosicionesBorrar)).ToString(Utilitario.Constantes.FORMATODECIMAL5);
					}
					else
					{
						lbl.Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
				}
				else
				{
					lbl.Text = Constantes.POSICIONCONTADOR.ToString();
				}
			
				lbl = (Label)e.Item.Cells[PosicionItemNoviembre].FindControl(NOVIEMBRE);
				tamaño =  dr[Enumerados.Meses.Noviembre.ToString()].ToString().Length;
				if(tamaño > MontoCero)
				{
					if(tamaño > MontoMenorMiles)
					{
						lbl.Text = Convert.ToDouble(dr[Enumerados.Meses.Noviembre.ToString()].ToString().Remove(tamaño - CantidadPosicionesBorrar,CantidadPosicionesBorrar)).ToString(Utilitario.Constantes.FORMATODECIMAL5);
					}
					else
					{
						lbl.Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
				}
				else
				{
					lbl.Text = Constantes.POSICIONCONTADOR.ToString();
				}
				
				lbl = (Label)e.Item.Cells[PosicionItemDiciembre].FindControl(DICIEMBRE);
				tamaño =  dr[Enumerados.Meses.Diciembre.ToString()].ToString().Length;
				if(tamaño > MontoCero)
				{
					if(tamaño > MontoMenorMiles)
					{
						lbl.Text = Convert.ToDouble(dr[Enumerados.Meses.Diciembre.ToString()].ToString().Remove(tamaño - CantidadPosicionesBorrar,CantidadPosicionesBorrar)).ToString(Utilitario.Constantes.FORMATODECIMAL5);
					}
					else
					{
						lbl.Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
				}
				else
				{
					lbl.Text = Constantes.POSICIONCONTADOR.ToString();
				}
				
				lbl = (Label)e.Item.Cells[PosicionItemTotal].FindControl(TOTAL);
				tamaño =  dr[NombreGlosaTotal].ToString().Length;
				if(tamaño > MontoCero)
				{
					if(tamaño > MontoMenorMiles)
					{
						lbl.Text = Convert.ToDouble(dr[NombreGlosaTotal].ToString().Remove(tamaño - CantidadPosicionesBorrar,CantidadPosicionesBorrar)).ToString(Utilitario.Constantes.FORMATODECIMAL5);
					}
					else
					{
						lbl.Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
				}
				else
				{
					lbl.Text = Constantes.POSICIONCONTADOR.ToString();
				}

				if(e.Item.Cells[Utilitario.Constantes.POSICIONCONTADORVENTAS].Text == NombreGlosaTotales || e.Item.Cells[Utilitario.Constantes.POSICIONCONTADORVENTASPRESUPUESTADAS].Text == NombreGlosaTotales1 || e.Item.Cells[Utilitario.Constantes.POSICIONCONTADORVENTASPRESUPUESTADAS].Text == NombreGlosaTotalFinal || e.Item.Cells[Utilitario.Constantes.POSICIONCONTADORVENTASPRESUPUESTADAS].Text == NombreGlosaTotal )
				{
					lbl = (Label)e.Item.Cells[PosicionItemEnero].FindControl(ENERO);
					lbl.ForeColor = Color.Black;
					lbl.Font.Size = FontUnit.Point(8);
					lbl.Font.Bold = true;

					lbl = (Label)e.Item.Cells[PosicionItemFebrero].FindControl(FEBRERO);
					lbl.ForeColor = Color.Black;
					lbl.Font.Size = FontUnit.Point(8);
					lbl.Font.Bold = true;

					lbl = (Label)e.Item.Cells[PosicionItemMarzo].FindControl(MARZO);
					lbl.ForeColor = Color.Black;
					lbl.Font.Size = FontUnit.Point(8);
					lbl.Font.Bold = true;

					lbl = (Label)e.Item.Cells[PosicionItemAbril].FindControl(ABRIL);
					lbl.ForeColor = Color.Black;
					lbl.Font.Size = FontUnit.Point(8);
					lbl.Font.Bold = true;

					lbl = (Label)e.Item.Cells[PosicionItemMayo].FindControl(MAYO);
					lbl.ForeColor = Color.Black;
					lbl.Font.Size = FontUnit.Point(8);
					lbl.Font.Bold = true;

					lbl = (Label)e.Item.Cells[PosicionItemJunio].FindControl(JUNIO);
					lbl.ForeColor = Color.Black;
					lbl.Font.Size = FontUnit.Point(8);
					lbl.Font.Bold = true;

					lbl = (Label)e.Item.Cells[PosicionItemJulio].FindControl(JULIO);
					lbl.ForeColor = Color.Black;
					lbl.Font.Size = FontUnit.Point(8);
					lbl.Font.Bold = true;

					lbl = (Label)e.Item.Cells[PosicionItemAgosto].FindControl(AGOSTO);
					lbl.ForeColor = Color.Black;
					lbl.Font.Size = FontUnit.Point(8);
					lbl.Font.Bold = true;

					lbl = (Label)e.Item.Cells[PosicionItemSetiembre].FindControl(SETIEMBRE);
					lbl.ForeColor = Color.Black;
					lbl.Font.Size = FontUnit.Point(8);
					lbl.Font.Bold = true;

					lbl = (Label)e.Item.Cells[PosicionItemOctubre].FindControl(OCTUBRE);
					lbl.ForeColor = Color.Black;
					lbl.Font.Size = FontUnit.Point(8);
					lbl.Font.Bold = true;

					lbl = (Label)e.Item.Cells[PosicionItemNoviembre].FindControl(NOVIEMBRE);
					lbl.ForeColor = Color.Black;
					lbl.Font.Size = FontUnit.Point(8);
					lbl.Font.Bold = true;

					lbl = (Label)e.Item.Cells[PosicionItemDiciembre].FindControl(DICIEMBRE);
					lbl.ForeColor = Color.Black;
					lbl.Font.Size = FontUnit.Point(8);
					lbl.Font.Bold = true;

					lbl = (Label)e.Item.Cells[PosicionItemTotal].FindControl(TOTAL);
					lbl.ForeColor = Color.Black;
					lbl.Font.Size = FontUnit.Point(8);
					lbl.Font.Bold = true;

					Helper.ConfigurarColorTotalesGrilla(e);
				}
				else
				{
					Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				}
			}	

			if (e.Item.ItemType == ListItemType.Header)
			{

				for(int i=PosicionItemEnero; i<=PosicionItemDiciembre; i++)
				{
					e.Item.Cells[i].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
					e.Item.Cells[i].Font.Underline=true;
					e.Item.Cells[i].Style[Constantes.CURSOR] = Constantes.TIPOCURSORMANO;
				}

				//e.Item.Cells[PosicionItemEnero].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
				//	Helper.MostrarVentana(URLDETALLE,KEYQIDCENTROOPERATIVO + Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQIDCENTROOPERATIVO] + Constantes.SIGNOAMPERSON + 
				//	CENTROOPERATIVO + Constantes.SIGNOIGUAL + Constantes.SIGNOAMPERSON + 
				//	KEYSINDICEMES + Constantes.SIGNOIGUAL + Convert.ToInt32(Enumerados.Meses.Enero).ToString() + Constantes.SIGNOAMPERSON + 
				//	KEYQNOMBREMES + Constantes.SIGNOIGUAL + Enumerados.Meses.Enero.ToString() + Constantes.SIGNOAMPERSON + 
				//	Utilitario.Constantes.KEYSINDICEPAGINA.ToString()+ Constantes.SIGNOIGUAL + Enumerados.DirectorioInformativo.V.ToString()+ Constantes.SIGNOAMPERSON + 
				//	Page.Request.QueryString[KEYQIDVERSION]+ Constantes.SIGNOAMPERSON +
				//	KEYQANO + Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQANO]));


				//e.Item.Cells[PosicionItemFebrero].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
				//	Helper.MostrarVentana(URLDETALLE,KEYQIDCENTROOPERATIVO + Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQIDCENTROOPERATIVO] + Constantes.SIGNOAMPERSON + 
				//	CENTROOPERATIVO + Constantes.SIGNOIGUAL + Constantes.SIGNOAMPERSON + 
				//	KEYSINDICEMES + Constantes.SIGNOIGUAL + Convert.ToInt32(Enumerados.Meses.Febrero).ToString() + Constantes.SIGNOAMPERSON + 
				//	KEYQNOMBREMES + Constantes.SIGNOIGUAL + Enumerados.Meses.Febrero.ToString() + Constantes.SIGNOAMPERSON + 
				//	Utilitario.Constantes.KEYSINDICEPAGINA.ToString()+ Constantes.SIGNOIGUAL + Enumerados.DirectorioInformativo.V.ToString()+ Constantes.SIGNOAMPERSON + 
				//	Page.Request.QueryString[KEYQIDVERSION]+ Constantes.SIGNOAMPERSON +
				//	KEYQANO + Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQANO]));

				//e.Item.Cells[PosicionItemMarzo].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
				//	Helper.MostrarVentana(URLDETALLE,KEYQIDCENTROOPERATIVO + Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQIDCENTROOPERATIVO] + Constantes.SIGNOAMPERSON + 
			//		CENTROOPERATIVO + Constantes.SIGNOIGUAL +  Constantes.SIGNOAMPERSON + 
		//			KEYSINDICEMES + Constantes.SIGNOIGUAL + Convert.ToInt32(Enumerados.Meses.Marzo).ToString() + Constantes.SIGNOAMPERSON + 
		//			KEYQNOMBREMES + Constantes.SIGNOIGUAL + Enumerados.Meses.Marzo.ToString() + Constantes.SIGNOAMPERSON + 
				//	Utilitario.Constantes.KEYSINDICEPAGINA.ToString()+ Constantes.SIGNOIGUAL + Enumerados.DirectorioInformativo.V.ToString()+ Constantes.SIGNOAMPERSON + 
				//	Page.Request.QueryString[KEYQIDVERSION]+ Constantes.SIGNOAMPERSON +
				//	KEYQANO + Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQANO]));

			//	e.Item.Cells[PosicionItemAbril].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
			//		Helper.MostrarVentana(URLDETALLE,KEYQIDCENTROOPERATIVO + Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQIDCENTROOPERATIVO] + Constantes.SIGNOAMPERSON + 
			//		CENTROOPERATIVO + Constantes.SIGNOIGUAL +  Constantes.SIGNOAMPERSON + 
			//		KEYSINDICEMES + Constantes.SIGNOIGUAL + Convert.ToInt32(Enumerados.Meses.Abril).ToString() + Constantes.SIGNOAMPERSON + 
			//		KEYQNOMBREMES + Constantes.SIGNOIGUAL + Enumerados.Meses.Abril.ToString() + Constantes.SIGNOAMPERSON + 
			//		Utilitario.Constantes.KEYSINDICEPAGINA.ToString()+ Constantes.SIGNOIGUAL + Enumerados.DirectorioInformativo.V.ToString()+ Constantes.SIGNOAMPERSON + 
			//		Page.Request.QueryString[KEYQIDVERSION]+ Constantes.SIGNOAMPERSON +
			//		KEYQANO + Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQANO]));

			//	e.Item.Cells[PosicionItemMayo].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
			//		Helper.MostrarVentana(URLDETALLE,KEYQIDCENTROOPERATIVO + Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQIDCENTROOPERATIVO] + Constantes.SIGNOAMPERSON + 
			//		CENTROOPERATIVO + Constantes.SIGNOIGUAL + Constantes.SIGNOAMPERSON + 
			//		KEYSINDICEMES + Constantes.SIGNOIGUAL + Convert.ToInt32(Enumerados.Meses.Mayo).ToString() + Constantes.SIGNOAMPERSON + 
			//		KEYQNOMBREMES + Constantes.SIGNOIGUAL + Enumerados.Meses.Mayo.ToString() + Constantes.SIGNOAMPERSON + 
			//		Utilitario.Constantes.KEYSINDICEPAGINA.ToString()+ Constantes.SIGNOIGUAL + Enumerados.DirectorioInformativo.V.ToString()+ Constantes.SIGNOAMPERSON +
			//		Page.Request.QueryString[KEYQIDVERSION]+ Constantes.SIGNOAMPERSON +
			//		KEYQANO + Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQANO]));

			//	e.Item.Cells[PosicionItemJunio].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
			//		Helper.MostrarVentana(URLDETALLE,KEYQIDCENTROOPERATIVO + Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQIDCENTROOPERATIVO] + Constantes.SIGNOAMPERSON + 
			//		CENTROOPERATIVO + Constantes.SIGNOIGUAL +  Constantes.SIGNOAMPERSON + 
			//		KEYSINDICEMES + Constantes.SIGNOIGUAL + Convert.ToInt32(Enumerados.Meses.Junio).ToString() + Constantes.SIGNOAMPERSON + 
			//		KEYQNOMBREMES + Constantes.SIGNOIGUAL + Enumerados.Meses.Junio.ToString() + Constantes.SIGNOAMPERSON + 
			//		Utilitario.Constantes.KEYSINDICEPAGINA.ToString()+ Constantes.SIGNOIGUAL + Enumerados.DirectorioInformativo.V.ToString()+ Constantes.SIGNOAMPERSON +
			//		Page.Request.QueryString[KEYQIDVERSION]+ Constantes.SIGNOAMPERSON +
			//		KEYQANO + Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQANO]));

			//	e.Item.Cells[PosicionItemJulio].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
			//		Helper.MostrarVentana(URLDETALLE,KEYQIDCENTROOPERATIVO + Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQIDCENTROOPERATIVO] + Constantes.SIGNOAMPERSON + 
			//		CENTROOPERATIVO + Constantes.SIGNOIGUAL +  Constantes.SIGNOAMPERSON + 
			//		KEYSINDICEMES + Constantes.SIGNOIGUAL + Convert.ToInt32(Enumerados.Meses.Julio).ToString() + Constantes.SIGNOAMPERSON + 
			//		KEYQNOMBREMES + Constantes.SIGNOIGUAL + Enumerados.Meses.Julio.ToString() + Constantes.SIGNOAMPERSON + 
			//		Utilitario.Constantes.KEYSINDICEPAGINA.ToString()+ Constantes.SIGNOIGUAL + Enumerados.DirectorioInformativo.V.ToString()+ Constantes.SIGNOAMPERSON +
			//		Page.Request.QueryString[KEYQIDVERSION]+ Constantes.SIGNOAMPERSON +
			//		KEYQANO + Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQANO]));

			//	e.Item.Cells[PosicionItemAgosto].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
			//		Helper.MostrarVentana(URLDETALLE,KEYQIDCENTROOPERATIVO + Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQIDCENTROOPERATIVO] + Constantes.SIGNOAMPERSON + 
			//		CENTROOPERATIVO + Constantes.SIGNOIGUAL +  Constantes.SIGNOAMPERSON + 
			//		KEYSINDICEMES + Constantes.SIGNOIGUAL + Convert.ToInt32(Enumerados.Meses.Agosto).ToString() + Constantes.SIGNOAMPERSON + 
			//		KEYQNOMBREMES + Constantes.SIGNOIGUAL + Enumerados.Meses.Agosto.ToString() + Constantes.SIGNOAMPERSON + 
			//		Utilitario.Constantes.KEYSINDICEPAGINA.ToString()+ Constantes.SIGNOIGUAL + Enumerados.DirectorioInformativo.V.ToString()+ Constantes.SIGNOAMPERSON +
			//		Page.Request.QueryString[KEYQIDVERSION]+ Constantes.SIGNOAMPERSON +
			//		KEYQANO + Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQANO]));

			//	e.Item.Cells[PosicionItemSetiembre].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
			//		Helper.MostrarVentana(URLDETALLE,KEYQIDCENTROOPERATIVO + Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQIDCENTROOPERATIVO] + Constantes.SIGNOAMPERSON + 
			//		CENTROOPERATIVO + Constantes.SIGNOIGUAL  + Constantes.SIGNOAMPERSON + 
			//		KEYSINDICEMES + Constantes.SIGNOIGUAL + Convert.ToInt32(Enumerados.Meses.Setiembre).ToString() + Constantes.SIGNOAMPERSON + 
			//		KEYQNOMBREMES + Constantes.SIGNOIGUAL + Enumerados.Meses.Setiembre.ToString() + Constantes.SIGNOAMPERSON + 
			//		Utilitario.Constantes.KEYSINDICEPAGINA.ToString()+ Constantes.SIGNOIGUAL + Enumerados.DirectorioInformativo.V.ToString()+ Constantes.SIGNOAMPERSON +
			//		Page.Request.QueryString[KEYQIDVERSION]+ Constantes.SIGNOAMPERSON +
			//		KEYQANO + Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQANO]));

			//	e.Item.Cells[PosicionItemOctubre].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
			//		Helper.MostrarVentana(URLDETALLE,KEYQIDCENTROOPERATIVO + Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQIDCENTROOPERATIVO] + Constantes.SIGNOAMPERSON + 
			//		CENTROOPERATIVO + Constantes.SIGNOIGUAL + Constantes.SIGNOAMPERSON + 
			//		KEYSINDICEMES + Constantes.SIGNOIGUAL + Convert.ToInt32(Enumerados.Meses.Octubre).ToString() + Constantes.SIGNOAMPERSON + 
			//		KEYQNOMBREMES + Constantes.SIGNOIGUAL + Enumerados.Meses.Octubre.ToString() + Constantes.SIGNOAMPERSON + 
			//		Utilitario.Constantes.KEYSINDICEPAGINA.ToString()+ Constantes.SIGNOIGUAL + Enumerados.DirectorioInformativo.V.ToString()+ Constantes.SIGNOAMPERSON +
			//		Page.Request.QueryString[KEYQIDVERSION]+ Constantes.SIGNOAMPERSON +
			//		KEYQANO + Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQANO]));

			//	e.Item.Cells[PosicionItemNoviembre].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
			//		Helper.MostrarVentana(URLDETALLE,KEYQIDCENTROOPERATIVO + Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQIDCENTROOPERATIVO] + Constantes.SIGNOAMPERSON + 
			//		CENTROOPERATIVO + Constantes.SIGNOIGUAL  + Constantes.SIGNOAMPERSON + 
			//		KEYSINDICEMES + Constantes.SIGNOIGUAL + Convert.ToInt32(Enumerados.Meses.Noviembre).ToString() + Constantes.SIGNOAMPERSON + 
			//		KEYQNOMBREMES + Constantes.SIGNOIGUAL + Enumerados.Meses.Noviembre.ToString() + Constantes.SIGNOAMPERSON + 
			//		Utilitario.Constantes.KEYSINDICEPAGINA.ToString()+ Constantes.SIGNOIGUAL + Enumerados.DirectorioInformativo.V.ToString()+ Constantes.SIGNOAMPERSON +
			//		Page.Request.QueryString[KEYQIDVERSION]+ Constantes.SIGNOAMPERSON +
			//		KEYQANO + Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQANO]));

			//	e.Item.Cells[PosicionItemDiciembre].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
			//		Helper.MostrarVentana(URLDETALLE,KEYQIDCENTROOPERATIVO + Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQIDCENTROOPERATIVO] + Constantes.SIGNOAMPERSON + 
			//		CENTROOPERATIVO + Constantes.SIGNOIGUAL  + Constantes.SIGNOAMPERSON + 
			//		KEYSINDICEMES + Constantes.SIGNOIGUAL + Convert.ToInt32(Enumerados.Meses.Diciembre).ToString() + Constantes.SIGNOAMPERSON + 
			//		KEYQNOMBREMES + Constantes.SIGNOIGUAL + Enumerados.Meses.Diciembre.ToString() + Constantes.SIGNOAMPERSON + 
			//		Utilitario.Constantes.KEYSINDICEPAGINA.ToString()+ Constantes.SIGNOIGUAL + Enumerados.DirectorioInformativo.V.ToString()+ Constantes.SIGNOAMPERSON +
			//		Page.Request.QueryString[KEYQIDVERSION]+ Constantes.SIGNOAMPERSON +
			//		KEYQANO + Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQANO]));
			}
		}
		

		private void ibtnImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			 this.Imprimir();
		}

		private void dgConsulta_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}