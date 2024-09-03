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
using SIMA.Utilitario;
using NetAccessControl;
using SIMA.ManejadorExcepcion;
using SIMA.Log;

namespace SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancieros.Directorio
{
	/// <summary>
	/// Summary description for ConsultarMargenBrutoporLNRealPresupuestado.
	/// </summary>
	public class ConsultarMargenBrutoporLNRealPresupuestado : System.Web.UI.Page, IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label lblPeriodo;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label lblMes;
		protected System.Web.UI.WebControls.Label Label1;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion
        	
		#region Constante
		//url
		const string URLDETALLE = "ConsultarVentasLiquidadas.aspx?";
		const string URLPAGINAADMINISTRACIONORBSERVACION="DetalleAdministrarObservacionesEstadosFinancieros.aspx?";

		private const string KEYID="KEYID";
		private const string KEYIDPERIODO="KEYIDPERIODO";
		private const string KEYIDMES="KEYIDMES";
		private const string KEYCONCEPTO="KEYCONCEPTO";
		const string ALERTA = "../../../imagenes/alert.gif";
		const string CONTROLIMGBUTTON = "imgCaducidad";
		const string  KEYQPERIODO = "periodo";
		
		const string KEYQIDOBSERVACION="IdObservacion";


		const string LBLDELMES = "lblDelMesSeleccionado";
		const string LBLPRESUP = "lblPresupuestado";
		#region otras
		const string KEYQIDEMPRESA = "idEmp";
		const string KEYIDCENTRO ="IdCentro";
		const string NOMBRECENTRO ="NombreCentro";

		const string NOMBRETIPOOPCION ="NombreOpcion";
		const string KEYQIDNOMBREFORMATO = "NFormato";
		const string KEYQIDFECHA = "efFecha";
		const string KEYQIDCENTROOPERATIVO="IdCentroOperativo";
		const string KEYQIDNOMBREMES = "NombreMes";


		const string COLUMNAIDRUBRO ="idRubro";
		const string URLFORMATORUBROMOVIMIENTOVCV ="ConsultarFormatoRubroMovimientoVCV.aspx?";
		const string URLFORMATORUBROMOVIMIENTODES ="ConsultarFormatoRubroMovimientoDES.aspx?";
		const string URLFORMATORUBROMOVIMIENTO ="ConsultarFormatoRubroMovimiento.aspx?";


		const string KEYQIDINTERFAZ = "interfaz";
		const string KEYQIDIDTIPOINFORMACION ="idTipoInfo";
		const string KEYQVERIQUITOS ="Ver";
		const string KEYQNOMBRERUBRO ="NRubro";
		const string KEYQIDFORMATO = "IdFormato";
		const string KEYQIDREPORTE = "IdReporte";
		const string KEYQIDRUBRO = "IdRubro";
		const string KEYQIDACUMULADO = "Acumulado";
		const string KEYQIDNIVELEXPANDE = "NivelExp";
		const string KEYQIDCLASIFICACIONRUBRO = "RubroClasf";
		const string KEYQTIPOPERIODOPRESUPUESTO="KEYQTIPOPERIODOPRESUPUESTO";

		const string KEYQNRODIGITOS ="NroDig";
		const string KEYQDIGCUENTA = "DigCuenta";
		const string KEYQNUEVOSSOLES = "MILNS";
		//Nuevos Key Session y QueryString
		const string KEYQOBSCALLAO = "ObsCallao";
		const string KEYQOBSCHIMBOTE = "ObsChimbote";
		const string KEYQOBSIQUITOS = "ObsIquitos";
		const string KEYQOBSPERU = "ObsPeru";
	
		
		#endregion

		#region Label Item
		const string LBLREALVENTAS     = "lblRealVenta";
		const string LBLREALCOSTOS     = "lblRealCosto";
		const string LBLREALUTILIDAD   = "lblRealUtilidades";
		const string LBLREALPORCENTAJE = "lblRealPorcentajes";

		const string LBLPRESUPVENTAS     = "lblPresupVenta";
		const string LBLPRESUPCOSTOS     = "lblPresupCosto";
		const string LBLPRESUPUTILIDAD   = "lblPresupUtilidades";
		const string LBLPRESUPPORCENTAJE = "lblPresupPorcentajes";

		const string LBLVARIACIONSOLES      = "lblVariacionenSoles";
		const string LBLVARIACIONPORCENTAJE = "lblVariacionenPorcentajes";


		const string LBLSUMREALVENTAS   = "lblSumRealVentas";
		const string LBLSUMREALCOSTO    = "lblSumRealCosto";
		const string LBLSUMREALUTILIDAD = "lblSumRealUtil";
		const string LBLSUMREALUTILPORC = "lblSumRealUtilPorc";


		const string LBLSUMPRESUPVENTAS     = "lblSumPresupVenta";
		const string LBLSUMPRESUPCOSTOS     = "lblSumPresupCosto";
		const string LBLSUMPRESUPUTILIDAD   = "lblSumPresupUtilidades";
		const string LBLSUMPRESUPPORCENTAJE = "lblSumPresupPorcentajes";

		const string LBLSUMVARIACIONSOLES      = "lblSumVariacionenSoles";
		const string LBLSUMVARIACIONPORCENTAJE = "lblSumVariacionenPorcentajes";
		#endregion

		#endregion

		#region Atributos
		protected DateTime FechaPeriodo
		{
			get
			{
				return Convert.ToDateTime(DateTime.DaysInMonth(Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA]).Year,Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA]).Month) + Utilitario.Constantes.SEPARADORFECHA + Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA]).Month.ToString().PadLeft(2,'0') + Utilitario.Constantes.SEPARADORFECHA + Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA]).Year.ToString());
			}
		}

		protected int idFormato
		{
			get
			{
				return Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO]);
			}
		}
		protected string NombreFormato
		{
			get
			{
				return Page.Request.Params[KEYQIDNOMBREFORMATO].ToString();
			}
		}

		protected int idReporte
		{
			get
			{
				return Convert.ToInt32(Page.Request.Params[KEYQIDREPORTE]);
			}
		}
		protected int idCentro
		{
			get
			{
				return Convert.ToInt32(Page.Request.Params[KEYIDCENTRO]);
			}
		}
		protected int NivelExpande
		{
			get
			{
				return Convert.ToInt32(Page.Request.Params[KEYQIDNIVELEXPANDE]);
			}
		}
		protected int idClasificacionRubro
		{
			get
			{
				return Convert.ToInt32(Page.Request.Params[KEYQIDCLASIFICACIONRUBRO]);
			}
		}


		#endregion

		#region Variables
		double TotRealVentas;
		double TotRealCostos;
		double TotRealUtilidad;
		//double TotRealPorcentaje;

		double TotPresupVentas;
		double TotPresupCostos;
		double TotPresupUtilidad;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.HtmlControls.HtmlTextArea campo1;
		//double TotPresupPorcentaje;

		double TotVariacion;
		//double TotVariacionPorcentaje;
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
					this.LlenarCombos();
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
				ltlMensaje.Text = Helper.MsgdbErrMostrarMesaje(true,oSIMAExcepcionDominio.Error.ToString());					
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		private void Totalizar(DataView dwTotales)
		{
			if (dwTotales !=null)
			{
				double[] aArreglo = Helper.TotalizarDataView(dwTotales,"VentaEjecucionRealDelmesActual");
				TotRealVentas = aArreglo[0];

				aArreglo = Helper.TotalizarDataView(dwTotales,"CostoEjecucionRealDelmesActual");
				TotRealCostos = aArreglo[0];

				aArreglo = Helper.TotalizarDataView(dwTotales,"UtilidadBrutaReal");
				TotRealUtilidad = aArreglo[0];

//				aArreglo = Helper.TotalizarDataView(dwTotales,"UtilidadBrutaRealPorcentaje");
//				TotRealPorcentaje = aArreglo[0];

				aArreglo = Helper.TotalizarDataView(dwTotales,"VentaPresupuestoDelMesActual");
				TotPresupVentas = aArreglo[0];

				aArreglo = Helper.TotalizarDataView(dwTotales,"CostoPresupuestoDelMesActual");
				TotPresupCostos = aArreglo[0];

				aArreglo = Helper.TotalizarDataView(dwTotales,"UtilidadBrutaPresupuesto");
				TotPresupUtilidad = aArreglo[0];

//				aArreglo = Helper.TotalizarDataView(dwTotales,"UtilidadBrutaPresupuestoPorcentaje");
//				TotPresupPorcentaje = aArreglo[0];

				aArreglo = Helper.TotalizarDataView(dwTotales,"Variacion");
				TotVariacion = aArreglo[0];

//				aArreglo = Helper.TotalizarDataView(dwTotales,"VariacionPorcentaje");
//				TotVariacionPorcentaje = aArreglo[0];

			}
		}

		public void LlenarGrilla()
		{
			CEstadosFinancieros oCEstadosFinancieros = new  CEstadosFinancieros();
			DataTable dtEstadoFinanciero = oCEstadosFinancieros.ConsultarMargenBrutoporLNRealPresupuestado(this.FechaPeriodo
				,this.idFormato
				,this.idReporte
				,Utilitario.Constantes.IDDEFAULT
				,this.idCentro
				,this.NivelExpande
				,this.idClasificacionRubro
				);			
			
			if(dtEstadoFinanciero!=null)
			{
				DataView dw = dtEstadoFinanciero.DefaultView;
				if(Convert.ToInt32(Session[Utilitario.Constantes.KEYQOBSERVACION])==1)
				{
					grid.Columns[0].Visible=true;
					grid.Columns[5].Visible=true;
				}
				grid.DataSource = dtEstadoFinanciero;
				grid.Columns[Constantes.POSICIONFOOTERTOTAL].FooterText = Constantes.TEXTOFOOTERTOTAL;
				this.Totalizar(dw);
			}
			else
			{
				grid.DataSource = dtEstadoFinanciero;
			}
			grid.DataBind();
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarMargenBrutoporLNRealPresupuestado.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add ConsultarMargenBrutoporLNRealPresupuestado.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add ConsultarMargenBrutoporLNRealPresupuestado.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			this.lblPeriodo.Text = this.FechaPeriodo.Year.ToString();
			this.lblMes.Text = Helper.ObtenerNombreMes(FechaPeriodo.Month,SIMA.Utilitario.Enumerados.TipoDatoMes.NombreCompleto).ToUpper();
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarMargenBrutoporLNRealPresupuestado.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarMargenBrutoporLNRealPresupuestado.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarMargenBrutoporLNRealPresupuestado.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarMargenBrutoporLNRealPresupuestado.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add ConsultarMargenBrutoporLNRealPresupuestado.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ConsultarMargenBrutoporLNRealPresupuestado.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.Header)
			{
				#region observaciones
				Label lblVentas = (Label)e.Item.Cells[2].FindControl("Label5");
				Label lblCostos = (Label)e.Item.Cells[2].FindControl("Label6");
			

				string cadena="", cadena2="";
				
				if( Session["ObVentas"].ToString()!=String.Empty)
				{
					string [] cadenaVen =  Session["ObVentas"].ToString().Split('?');
					if(cadenaVen.Length>1)
						cadena= cadenaVen[1].ToString();
					else
						cadena= cadenaVen[0].ToString();
					cadena =  cadena.Replace("¿","");
					cadena =  cadena.Replace("?","");
					cadena =  cadena.Replace("</P","");
					cadena =  cadena.Replace("\\","");
					cadena =  cadena.Replace("\r","");
					cadena =  cadena.Replace("\n","");
				}
				if( Session["ObCostos"].ToString()!=String.Empty)
				{
					string [] cadena2Cos =  Session["ObCostos"].ToString().Split('?');
					if(cadena2Cos.Length>1)
						cadena2= cadena2Cos[1].ToString();
					else
						cadena2= cadena2Cos[0].ToString();
					//cadena2= cadena2Cos[1].ToString();
					cadena2 =  cadena2.Replace("¿","");
					cadena2 =  cadena2.Replace("?","");
					cadena2 =  cadena2.Replace("</P","");
					cadena2 =  cadena2.Replace("\r","");
					cadena2 =  cadena2.Replace("\n","");
				}

			

				lblVentas.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,"MostrarValor('"+cadena+"'),"+ Utilitario.Constantes.CAMBIARCOLORSELECCIONGRILLAPOPUP );
				lblVentas.Style.Add(Utilitario.Constantes.CURSOR,Utilitario.Constantes.TIPOCURSORMANO);	

				lblCostos.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,"MostrarValor('"+cadena2+"'),"+ Utilitario.Constantes.CAMBIARCOLORSELECCIONGRILLAPOPUP );
				lblCostos.Style.Add(Utilitario.Constantes.CURSOR,Utilitario.Constantes.TIPOCURSORMANO);	

				#endregion
				//Real
				#region Real
				Label lbl;
				lbl = (Label) e.Item.Cells[0].FindControl(LBLDELMES);
				lbl.Text = Helper.ObtenerNombreMes(FechaPeriodo.Month,Utilitario.Enumerados.TipoDatoMes.NombreCompleto).ToUpper();

				lbl.Font.Size = 10;
//				lbl.Font.Underline=true;
				lbl.Font.Bold=true;
//				lbl.Style.Add(Utilitario.Constantes.CURSOR,Utilitario.Constantes.TIPOCURSORMANO);
//				lbl.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado(Utilitario.Constantes.VACIO));
				#endregion

				//Presupuestado
				#region Presupuestado
				lbl = (Label) e.Item.Cells[0].FindControl(LBLPRESUP);
				lbl.Text = "PRESUPUESTADO " + Helper.ObtenerNombreMes(FechaPeriodo.Month,Utilitario.Enumerados.TipoDatoMes.NombreCompleto).ToUpper();

				lbl.Font.Size = 10;
//				lbl.Font.Underline=true;
				lbl.Font.Bold=true;
//				lbl.Style.Add(Utilitario.Constantes.CURSOR,Utilitario.Constantes.TIPOCURSORMANO);
//				lbl.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado(Utilitario.Constantes.VACIO));
				#endregion

			}
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				if(Convert.ToInt32(Session[Utilitario.Constantes.KEYQOBSERVACION])==1)
				{
					e.Item.Cells[Constantes.POSICIONCONTADOR].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
					e.Item.Cells[Constantes.POSICIONCONTADOR].Font.Underline=true;
					e.Item.Cells[Utilitario.Constantes.POSICIONCONTADOR].ForeColor = System.Drawing.Color.Blue;

					string modoPagina="";
					if(dr["observacion"].ToString()==String.Empty)
					{
						modoPagina =Enumerados.ModoPagina.N.ToString();
					}
					else
					{
						modoPagina =Enumerados.ModoPagina.M.ToString();
					}
					string parametros =KEYQIDFORMATO + Utilitario.Constantes.SIGNOIGUAL + this.idFormato.ToString() +
						Utilitario.Constantes.SIGNOAMPERSON 
						+ KEYQIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + this.idCentro.ToString()
						+ Utilitario.Constantes.SIGNOAMPERSON 	
						+ KEYQPERIODO + Utilitario.Constantes.SIGNOIGUAL + this.FechaPeriodo.Year.ToString()
						+ Utilitario.Constantes.SIGNOAMPERSON 	
						+ KEYQIDFECHA + Utilitario.Constantes.SIGNOIGUAL + this.FechaPeriodo.Month.ToString()
						+ Utilitario.Constantes.SIGNOAMPERSON 	
						+ KEYQIDRUBRO + Utilitario.Constantes.SIGNOIGUAL + this.idClasificacionRubro.ToString()
						+ Utilitario.Constantes.SIGNOAMPERSON 	
						+ KEYID + Utilitario.Constantes.SIGNOIGUAL + dr["id"].ToString()
						+ Utilitario.Constantes.SIGNOAMPERSON 	
						+ KEYQTIPOPERIODOPRESUPUESTO + Utilitario.Constantes.SIGNOIGUAL + "0"
						+ Utilitario.Constantes.SIGNOAMPERSON 	
						+ Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL 
						+ modoPagina
						+ Utilitario.Constantes.SIGNOAMPERSON 	
						+ KEYQIDOBSERVACION + Utilitario.Constantes.SIGNOIGUAL + dr["idobservacion"].ToString();


					e.Item.Cells[Constantes.POSICIONCONTADOR].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.PopupBusqueda(URLPAGINAADMINISTRACIONORBSERVACION + parametros,500,400));
					System.Web.UI.WebControls.Image ibtn1=(System.Web.UI.WebControls.Image)e.Item.Cells[5].FindControl(CONTROLIMGBUTTON);	
					if (Convert.ToString(dr["observacion"])== String.Empty)
					{
						ibtn1.ImageUrl = ALERTA;
					}
					else
					{
						ibtn1.Visible = false;
					}
				}

				e.Item.Cells[1].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.MostrarVentana(URLDETALLE,
					KEYIDCENTRO + Utilitario.Constantes.SIGNOIGUAL + this.idCentro + Utilitario.Constantes.SIGNOAMPERSON +
					KEYID + Utilitario.Constantes.SIGNOIGUAL + dr["id"].ToString() + Utilitario.Constantes.SIGNOAMPERSON +
					KEYIDPERIODO + Utilitario.Constantes.SIGNOIGUAL + FechaPeriodo.Year.ToString() + Utilitario.Constantes.SIGNOAMPERSON +
					KEYQIDFORMATO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQIDFORMATO].ToString() + Utilitario.Constantes.SIGNOAMPERSON +
					KEYQIDRUBRO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQIDRUBRO].ToString() + Utilitario.Constantes.SIGNOAMPERSON +
					KEYIDMES + Utilitario.Constantes.SIGNOIGUAL + FechaPeriodo.Month.ToString()	+ Utilitario.Constantes.SIGNOAMPERSON +
					KEYCONCEPTO + Utilitario.Constantes.SIGNOIGUAL + dr["Concepto"].ToString()
					)+ Utilitario.Constantes.POPUPDEESPERA + Utilitario.Constantes.HISTORIALADELANTE);

				e.Item.Cells[1].Style.Add("cursor","hand");
				e.Item.Cells[1].Font.Underline=true;
				e.Item.Cells[1].ForeColor = Color.Blue;


				this.ColocarValor(e,dr,LBLREALVENTAS,"VentaEjecucionRealDelmesActual");
				this.ColocarValor(e,dr,LBLREALCOSTOS,"CostoEjecucionRealDelmesActual");
				this.ColocarValor(e,dr,LBLREALUTILIDAD,"UtilidadBrutaReal");
				this.ColocarValorPorcentaje(e,dr,LBLREALPORCENTAJE,"UtilidadBrutaReal","VentaEjecucionRealDelmesActual");

				this.ColocarValor(e,dr,LBLPRESUPVENTAS,"VentaPresupuestoDelMesActual");
				this.ColocarValor(e,dr,LBLPRESUPCOSTOS,"CostoPresupuestoDelMesActual");
				this.ColocarValor(e,dr,LBLPRESUPUTILIDAD,"UtilidadBrutaPresupuesto");
				this.ColocarValorPorcentaje(e,dr,LBLPRESUPPORCENTAJE,"UtilidadBrutaPresupuesto","VentaPresupuestoDelMesActual");

				this.ColocarValor(e,dr,LBLVARIACIONSOLES,"Variacion");
				this.ColocarVariacionPorcentaje(e,dr,LBLVARIACIONPORCENTAJE,"VariacionPorcentaje");

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,Utilitario.Helper.MostrarDatosEnCajaTexto("campo1",dr["observacion"].ToString()));
			}
	
			if(e.Item.ItemType == ListItemType.Footer)
			{
				this.EtiquetaTotales(e, LBLSUMREALVENTAS, TotRealVentas);
				this.EtiquetaTotales(e, LBLSUMREALCOSTO, TotRealCostos);
				this.EtiquetaTotales(e, LBLSUMREALUTILIDAD, TotRealUtilidad);
				this.EtiquetaTotalesPorcentaje(e, LBLSUMREALUTILPORC, TotRealUtilidad/TotRealVentas*100);

				this.EtiquetaTotales(e, LBLSUMPRESUPVENTAS, TotPresupVentas);
				this.EtiquetaTotales(e, LBLSUMPRESUPCOSTOS, TotPresupCostos);
				this.EtiquetaTotales(e, LBLSUMPRESUPUTILIDAD, TotPresupUtilidad);
				this.EtiquetaTotalesPorcentaje(e, LBLSUMPRESUPPORCENTAJE, TotPresupUtilidad/TotPresupVentas*100);

				this.EtiquetaTotales(e, LBLSUMVARIACIONSOLES, TotVariacion);
				this.EtiquetaTotalesPorcentaje(e, LBLSUMVARIACIONPORCENTAJE, TotVariacion/TotPresupUtilidad*100);

			}
	
		}

		private void ColocarValor(System.Web.UI.WebControls.DataGridItemEventArgs e, DataRow dr, string nombrecontrol, string Campo)
		{
			Label lbl;
			lbl = (Label) e.Item.Cells[0].FindControl(nombrecontrol);
			lbl.Text = (Session[KEYQNUEVOSSOLES] ==null 
				|| Session[KEYQNUEVOSSOLES].ToString() == Utilitario.Constantes.SIVERMILES)
				? (Convert.ToDouble(dr[Campo])/Utilitario.Constantes.MILES).ToString(Utilitario.Constantes.FORMATODECIMAL5)
				:Convert.ToDouble(dr[Campo]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
		}

		private void ColocarValorPorcentaje(System.Web.UI.WebControls.DataGridItemEventArgs e, DataRow dr, 
			string nombrecontrol, string Campo1, string Campo2)
		{
			Label lbl;
			lbl = (Label) e.Item.Cells[0].FindControl(nombrecontrol);
			if (Convert.ToDouble(dr[Campo1].ToString())==0 || Convert.ToDouble(dr[Campo2].ToString())==0)
				lbl.Text = "SD";
			else
			{
				double valor = (Session[KEYQNUEVOSSOLES] ==null 
					|| Session[KEYQNUEVOSSOLES].ToString() == Utilitario.Constantes.SIVERMILES)
					? ((Math.Round(Convert.ToDouble(dr[Campo1])/Utilitario.Constantes.MILES)/
					Math.Round(Convert.ToDouble(dr[Campo2])/Utilitario.Constantes.MILES)))*100
					:((Convert.ToDouble(dr[Campo1])/Convert.ToDouble(dr[Campo2])))*100;
				if (valor < 0)
				{
					lbl.Text=(valor*-1).ToString(Utilitario.Constantes.FORMATODECIMAL5);
					lbl.ForeColor=System.Drawing.Color.Red;
				}
				else
					lbl.Text = valor.ToString(Utilitario.Constantes.FORMATODECIMAL5);
			}
		}

		private void ColocarVariacionPorcentaje(System.Web.UI.WebControls.DataGridItemEventArgs e, DataRow dr, 
			string nombrecontrol, string Campo)
		{
			Label lbl;
			lbl = (Label) e.Item.Cells[0].FindControl(nombrecontrol);
			if (dr[Campo].ToString()=="SD")
				lbl.Text = "SD";
			else
			{
				double valor = (Session[KEYQNUEVOSSOLES] ==null 
					|| Session[KEYQNUEVOSSOLES].ToString() == Utilitario.Constantes.SIVERMILES)
					? Convert.ToDouble(dr[Campo])
					:Convert.ToDouble(dr[Campo]);
				if (valor < 0)
				{
					lbl.Text=(valor*-1).ToString(Utilitario.Constantes.FORMATODECIMAL5);
					lbl.ForeColor=System.Drawing.Color.Red;
				}
				else
					lbl.Text = valor.ToString(Utilitario.Constantes.FORMATODECIMAL5);
			}
		}


		private void EtiquetaTotales(System.Web.UI.WebControls.DataGridItemEventArgs e, string nombrecontrol, double Total)
		{
			Label lbl;
			lbl = (Label) e.Item.Cells[0].FindControl(nombrecontrol);
			lbl.Font.Size = 8;
			lbl.Font.Bold = true;
			lbl.Text = (Session[KEYQNUEVOSSOLES] ==null 
				|| Session[KEYQNUEVOSSOLES].ToString() == Utilitario.Constantes.SIVERMILES)
				? (Total/Utilitario.Constantes.MILES).ToString(Utilitario.Constantes.FORMATODECIMAL5)
				:Total.ToString(Utilitario.Constantes.FORMATODECIMAL4);

		}

		private void EtiquetaTotalesPorcentaje(System.Web.UI.WebControls.DataGridItemEventArgs e, string nombrecontrol, double Total)
		{
			Label lbl;
			lbl = (Label) e.Item.Cells[0].FindControl(nombrecontrol);
			lbl.Font.Size = 8;
			lbl.Font.Bold = true;
			if (!Double.IsNaN(Total))
			{
				if (Total < 0)
				{
					lbl.Text=(Total*-1).ToString(Utilitario.Constantes.FORMATODECIMAL5);
					lbl.ForeColor=System.Drawing.Color.Red;
				}
				else
					lbl.Text = Total.ToString(Utilitario.Constantes.FORMATODECIMAL5);
			}
			else
				lbl.Text = "SD";
		}
	}
}
