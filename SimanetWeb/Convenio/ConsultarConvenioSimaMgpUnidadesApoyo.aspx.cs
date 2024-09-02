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
using SIMA.Controladoras.Convenio;
using SIMA.Controladoras;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.EntidadesNegocio.Convenio;
using SIMA.Log;
using NetAccessControl;
using NullableTypes;

namespace SIMA.SimaNetWeb.Convenio
{
	public class ConsultarConvenioSimaMgpUnidadesApoyo: System.Web.UI.Page	
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
			this.dgConsultarConvenioSimaMgp.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgConsultarConvenioSimaMgp_ItemDataBound);
			this.dgConsultarConvenioSimaMgp.SelectedIndexChanged += new System.EventHandler(this.dgConsultarConvenioSimaMgp_SelectedIndexChanged);
			this.dgUnidadApoyo.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.dgUnidadApoyo_SortCommand);
			this.dgUnidadApoyo.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgUnidadApoyo_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		
		
		#region Controles
		protected System.Web.UI.WebControls.Label LblResultadoComoperpac;
		protected projDataGridWeb.DataGridWeb dgUnidadApoyo;
		protected System.Web.UI.WebControls.Label lblTituloSecundario;
		protected System.Web.UI.WebControls.Label lblResultadoConvenio;
		protected projDataGridWeb.DataGridWeb dgConsultarConvenioSimaMgp;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.WebControls.Label lblObservaciones;
		protected System.Web.UI.WebControls.TextBox txtObservaciones;
		protected System.Web.UI.WebControls.Label lblTituloConvenio;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion Controles;			
		#region Constantes
		//QueryString
		const string KEYQIDPERIODOAPOYOFASUB = "IdPeriodoApoyoFasub";
		// Columnas de Ordenamiento
		const string COLORDENAMIENTO = "NroConvenio Asc";
		const int POSICIONCONTADOR=0;
		
		// Otros
		const string GRILLAVACIA1="No existe ningun Convenio Sima-Mgp que se encuentre vigente";
		const string GRILLAVACIA2="No hay información de Apoyo Unidades COMOPERPAC";
		const string GRILLAVACIA3="No hay informacion de Apoyo Unidades SUBMARINAS";
		const string KEYSIGLAS="Siglas";

		//URL
		const string KEYQID = "";

		const string URLPROYECTOCONVENIO="ConsultarProyectosConvenioSimaMgp.aspx?";
		const string URLIMPRESION = "PopupConsultarConvenioSimaMgpUnidadesApoyo.aspx";
		const string URLCONSULTARPERIODOUNIDADESAPOYO="ConsultarPeriodoUnidadesApoyo.aspx?";
		const string URLDIRECTORIO = "/SimaNetWebGestion/DirectorioEjecutivo/InformeDirectorio.aspx";
		const string URLPRINCIPAL = "../../Default.aspx";
		const string URLRESUMENCONVENIO = "ConsultarDetalleResumenConvenio.aspx";
		const string URLCONSULTARSUBMARINOSPORPERIODO = "ConsultarSubmarinosPorPeriodo.aspx?";
		//CONTROLES
		const string CONTROLINK="hlkId";

		//KEYID SESION.
		const string KEYIDCONVENIOSIMAMGP="IdConvenioSimaMgp";

		//Otros
		const string TablaImpresion0 = "ConvenioSimaMgp";
		const string TablaImpresion1 = "ApoyoUnidades";
		const int FASUB2005 = 1;
		const int FASUB2006 = 2;
		#endregion Constantes
		#region Variables
		DataSet ds = new DataSet();
		private double acumMontoAsignado=0;
		private double acumMontoAprobado=0;
		private double acumMontoEjecutado=0;
		private double acumMontoEnEjecucion=0;
		private double acumMontoComprometido=0;
		private double acumMontoPagado=0;
		private double acumAvanceFisico=0;
		private double acumPagoXCuotas=0;

		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hOrdenGrilla;
		protected System.Web.UI.HtmlControls.HtmlInputHidden Hidden1;
		double acumMontoSaldo=0;
		
		#endregion Variables
		

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					this.ReiniciarVariableAcumuladas();

					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Convenio Sima-Mgp Unidades de Apoyo",this.ToString(),"Se consulto los montos totales por Convenio.",Enumerados.NivelesErrorLog.I.ToString()));
					this.LlenarGrillaOrdenamiento(COLORDENAMIENTO);
					
					

					if(Convert.ToInt32(Page.Request.QueryString["Directorio"]) != 1)
					{
						LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Convenio Sima-Mgp Unidades de Apoyo",this.ToString(),"Se consulto los montos totales de Unidades de Apoyo.",Enumerados.NivelesErrorLog.I.ToString()));
						this.LlenarGrigaMontoUnidadApoyo();
					}
					else
						lblTituloSecundario.Visible = false;
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
		private void LlenarCuadroEstadistico(
			string montoConvenio, string montoAprobado, string avanceFisico,
			string montoPagado, string pagoXCuotas,System.Web.UI.WebControls.Image img, int idConvenio)
		{
			CConvenioSimaMgp oCConvenioSimaMgp = new CConvenioSimaMgp();
			CFuncionesEspeciales oCFuncionesEspeciales=new CFuncionesEspeciales();
			ConvenioSimaMgpBE oConvenioSimaMgpBE=(ConvenioSimaMgpBE)
				oCConvenioSimaMgp.DetalleDeUnConvenioSimaMgp(idConvenio);
			
			string parametros = String.Empty;
			//			string separador = "\\n";
			string titulo = "CONVENIO " + oConvenioSimaMgpBE.NroConvenio;

			parametros = "<chart>" +
				"	<series>" +
				"		<value xid='0'>MONTO CONVENIO</value>" +
				"		<value xid='1'>MONTO APROBADO</value>" +
				"		<value xid='2'>AVANCE FISICO</value>" +
				"		<value xid='3'>MONTO AUTORIZADO</value>" +
				"		<value xid='4'>MONTO PAGADO</value>" +
				"		<value xid='5'>PAGO CONTRA AVANCE FISICO</value>" +
				"	</series>"+
				"	<graphs>" +
				"		<graph gid='0'>" +
				"			<value xid='0' color='#C80A15'>" + montoConvenio + "</value>" +
				"			<value xid='1' color='#2959aa'>" + montoAprobado + "</value>" +
				"			<value xid='2' color='#f5e72f'>" + avanceFisico + "</value>" +
				"			<value xid='3' color='#3aecea'>" + NullableIsNull.IsNullDouble(oConvenioSimaMgpBE.MontoAutorizado,0).ToString() + "</value>" +
				"			<value xid='4' color='#30c57d'>" + montoPagado + "</value>" +
				"			<value xid='5' color='#e78c49'>" + pagoXCuotas + "</value>" +
				"		</graph>"+
				"	</graphs>"+
				"</chart>";
			//			parametros ="MONTO CONVENIO" + Utilitario.Constantes.SIGNOPUNTOYCOMA + montoConvenio + separador +
			//				"MONTO APROBADO" + Utilitario.Constantes.SIGNOPUNTOYCOMA + montoAprobado + separador +
			//				"AVANCE FISICO" + Utilitario.Constantes.SIGNOPUNTOYCOMA + avanceFisico + separador +
			//				"MONTO AUTORIZADO" + Utilitario.Constantes.SIGNOPUNTOYCOMA + NullableIsNull.IsNullDouble(oConvenioSimaMgpBE.MontoAutorizado,0).ToString() + separador + 
			//				"MONTO PAGADO" + Utilitario.Constantes.SIGNOPUNTOYCOMA + montoPagado + separador +
			//				"PAGO POR CUOTAS" + Utilitario.Constantes.SIGNOPUNTOYCOMA + pagoXCuotas;

			img.Attributes.Add(Utilitario.Constantes.EVENTOONMOUSEOVER,"javascript:this.style.cursor='hand';");
			img.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,"llenarGrafico('" +
				Utilitario.Helper.EncodeText(parametros) + "','" + titulo + "');");
		}
		private double montoCronogramaPagos(int idConvenio)
		{
			double pagoXCuotas = 0;
			int mesActual = 0;
			int periodo = 0;
			
			CConvenioSimaMgp oCConvenioSimaMgp = new CConvenioSimaMgp();
			CFuncionesEspeciales oCFuncionesEspeciales=new CFuncionesEspeciales();

			NullableDouble[] Montos;

			mesActual = Helper.FechaSimanet.ObtenerFechaSesion().Month+1;
			periodo = Helper.FechaSimanet.ObtenerFechaSesion().Year;

			if (mesActual==13)
			{mesActual=12;}
			/*mesActual = DateTime.Now.Month;
			periodo = DateTime.Now.Year;*/

			string[] Columnas=new string[] {
											   Enumerados.ColumnasProgramaPagosConvenio.MontoProgramado.ToString(),
											   Enumerados.ColumnasProgramaPagosConvenio.MontoRecibido.ToString(),
											   Enumerados.ColumnasProgramaPagosConvenio.MontoPendiente.ToString()
										   };
			DataTable dtPagoProgramado = oCConvenioSimaMgp.ConsultarPagosYCronogramaDePagosDeUnConvenio(idConvenio);
			
			if(dtPagoProgramado != null)
			{
				DataView dwPagoProgramado = dtPagoProgramado.DefaultView;

				dwPagoProgramado = FiltrarMeses(dwPagoProgramado,mesActual,periodo);
				
				Montos=oCFuncionesEspeciales.CalcularMontosTotalesDataFile(dwPagoProgramado,Columnas);
				pagoXCuotas = NullableIsNull.IsNullDouble(Montos[0],0);
			}
			else
			{
				pagoXCuotas = 0;
			}
			return pagoXCuotas;
		}
		private DataView FiltrarMeses(DataView dwParam, int hastaMes, int periodo)
		{
			string mesNombre = String.Empty;
			
			for(int i = hastaMes + 1; i<=12; i++)
			{
				foreach(DataRowView dr in dwParam)
				{
					Utilitario.Enumerados.Meses enumMes = (Utilitario.Enumerados.Meses)
						Enum.ToObject(typeof(Utilitario.Enumerados.Meses), i);
					mesNombre = enumMes.ToString();

					if(dr[2].ToString().Trim().StartsWith(periodo.ToString()) &&
						dr[2].ToString().Trim().EndsWith(mesNombre))
					{
						dr.Delete();
						return FiltrarMeses(dwParam, hastaMes,periodo);
					}
				}		
			}
			return dwParam;
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
	
		public void Imprimir()
		{
			ltlMensaje.Text = Helper.PopupImpresion(URLIMPRESION,800,450,false,false,false,true,true);
		}

		private void dgConsultarConvenioSimaMgp_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			CConvenioSimaMgp oCConvenioSimaMgp=new CConvenioSimaMgp();
			NullableDouble MontoRecibido=0;
			NullableDouble MontoPorCobrar=0;
			double pagoXCuotas = 0;
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				System.Web.UI.WebControls.Image img = (System.Web.UI.WebControls.Image)
					e.Item.FindControl("ibtnGraficoEstadistico");
				
				e.Item.Cells[Utilitario.Constantes.POSICIONINDEXUNO].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
				e.Item.Cells[Utilitario.Constantes.POSICIONINDEXUNO].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.MostrarVentana(URLPROYECTOCONVENIO,KEYIDCONVENIOSIMAMGP + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr[Enumerados.ColumnasConvenioSimaMgp.IdConvenioSimaMgp.ToString()])));
				e.Item.Cells[Utilitario.Constantes.POSICIONINDEXUNO].Text=Convert.ToString(dr[Enumerados.ColumnasConvenioSimaMgp.NroConvenio.ToString()]);
				e.Item.Cells[Utilitario.Constantes.POSICIONINDEXUNO].Font.Underline=true;
				e.Item.Cells[1].ForeColor=Color.Blue;

				pagoXCuotas = montoCronogramaPagos(int.Parse(dr[Utilitario.Enumerados.ColumnasConvenioSimaMgp.IdConvenioSimaMgp.ToString()].ToString()));
				
				acumMontoAsignado = acumMontoAsignado + NullableIsNull.IsNullDouble(dr[Enumerados.ColumnasConvenioSimaMgp.MontoAsignado.ToString()],0);
				acumMontoAprobado = acumMontoAprobado + NullableIsNull.IsNullDouble(dr[Enumerados.ColumnasConvenioSimaMgp.MontoAprobado.ToString()],0);
				acumMontoEjecutado = acumMontoEjecutado + NullableIsNull.IsNullDouble(dr[Enumerados.ColumnasConvenioSimaMgp.MontoEjecutado.ToString()],0);
				acumMontoEnEjecucion = acumMontoEnEjecucion + NullableIsNull.IsNullDouble(dr[Enumerados.ColumnasConvenioSimaMgp.MontoEnEjecucion.ToString()],0);
				acumMontoComprometido = acumMontoComprometido + NullableIsNull.IsNullDouble(dr[Enumerados.ColumnasConvenioSimaMgp.MontoComprometido.ToString()],0);
				acumMontoSaldo = acumMontoSaldo + NullableIsNull.IsNullDouble(dr[Enumerados.ColumnasConvenioSimaMgp.MontoSaldo.ToString()],0);
				acumAvanceFisico = acumAvanceFisico + NullableIsNull.IsNullDouble(dr[Enumerados.ColumnasConvenioSimaMgp.AvanceFisico.ToString()],0);
				acumPagoXCuotas = acumPagoXCuotas + pagoXCuotas;
				//Calculando lo pagado
				MontoRecibido=0;
				MontoPorCobrar=0;
				oCConvenioSimaMgp.ConsultarMontoRecibidoMontoPorCobrarDeUnConvenio(Convert.ToInt32(
					e.Item.Cells[Utilitario.Constantes.POSICIONINDEXCERO].Text),ref MontoRecibido,ref MontoPorCobrar);
				e.Item.Cells[Utilitario.Constantes.POSICIONINDEXSEIS].Text=MontoRecibido.Value.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[Utilitario.Constantes.POSICIONINDEXSIETE].Text = pagoXCuotas.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				acumMontoPagado = acumMontoPagado + MontoRecibido.Value;				
				//Continuando el resto

				string sCadena = Utilitario.Enumerados.ColumnasConvenioSimaMgp.IdConvenioSimaMgp.ToString() + Utilitario.Constantes.SIGNOIGUAL + dr[Utilitario.Enumerados.ColumnasConvenioSimaMgp.IdConvenioSimaMgp.ToString()].ToString();
				
				sCadena = Helper.MostrarDatosEnCajaTexto(this.hCodigo.ID.ToString(),sCadena);
				sCadena += Utilitario.Constantes.EspacioEnBlancoVS + Helper.MostrarDatosEnCajaTexto(this.txtObservaciones.ID.ToString(),Helper.LimpiarTexto(dr[Utilitario.Enumerados.ColumnasConvenioSimaMgp.Observaciones.ToString()].ToString()));
				Utilitario.Helper.SeleccionarItemGrillaOnClickMoverRaton(e,sCadena);
				Helper.FiltroporSeleccionConfiguraColumna(e,this.dgConsultarConvenioSimaMgp);
				//Llenar cuadro
				LlenarCuadroEstadistico(dr[Enumerados.ColumnasConvenioSimaMgp.MontoAsignado.ToString()].ToString(),
					dr[Enumerados.ColumnasConvenioSimaMgp.MontoAprobado.ToString()].ToString(),
					dr[Enumerados.ColumnasConvenioSimaMgp.AvanceFisico.ToString()].ToString(),
					MontoRecibido.Value.ToString(),pagoXCuotas.ToString(),img,int.Parse(dr[Utilitario.Enumerados.ColumnasConvenioSimaMgp.IdConvenioSimaMgp.ToString()].ToString()));
			}	
			else if(e.Item.ItemType == ListItemType.Footer)
			{
				e.Item.Cells[Utilitario.Constantes.POSICIONINDEXUNO].Text = Utilitario.Constantes.TEXTOTOTAL + " " + Utilitario.Enumerados.Moneda.NS;
				e.Item.Cells[Utilitario.Constantes.POSICIONINDEXDOS].Text = acumMontoAsignado.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[Utilitario.Constantes.POSICIONINDEXTRES].Text = acumMontoAprobado.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[Utilitario.Constantes.POSICIONINDEXCUATRO].Text = acumAvanceFisico.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[Utilitario.Constantes.POSICIONINDEXCINCO].Text = acumMontoEjecutado.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				//				e.Item.Cells[Utilitario.Constantes.POSICIONINDEXSEIS].Text = acumMontoEnEjecucion.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				//				e.Item.Cells[Utilitario.Constantes.POSICIONINDEXSIETE].Text = acumMontoComprometido.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[Utilitario.Constantes.POSICIONINDEXSEIS].Text=acumMontoPagado.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[Utilitario.Constantes.POSICIONINDEXSIETE].Text=acumPagoXCuotas.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[Utilitario.Constantes.POSICIONINDEXOCHO].Text=acumMontoSaldo.ToString(Utilitario.Constantes.FORMATODECIMAL4);
			}
		}

		private void ibtnImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Imprimir();

		}

		private void ReiniciarVariableAcumuladas()
		{
			acumMontoAsignado=Utilitario.Constantes.ValorConstanteCero;
			acumMontoAprobado=Utilitario.Constantes.ValorConstanteCero;
			acumMontoEjecutado=Utilitario.Constantes.ValorConstanteCero;
			acumMontoEnEjecucion=Utilitario.Constantes.ValorConstanteCero;
			acumMontoComprometido=Utilitario.Constantes.ValorConstanteCero;
			acumMontoPagado=Utilitario.Constantes.ValorConstanteCero;
			acumMontoSaldo=Utilitario.Constantes.ValorConstanteCero;
			acumPagoXCuotas=Utilitario.Constantes.ValorConstanteCero;
		}

		private void ibtnAtras_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if(Page.Request.QueryString[Utilitario.Constantes.KEYSINDICEPAGINA] != null)
			{
				if(Page.Request.QueryString[Utilitario.Constantes.KEYSINDICEPAGINA].ToString() == Enumerados.DirectorioInformativo.ID.ToString())
				{
					Page.Response.Redirect(URLDIRECTORIO);
				}
			}
			else
			{
				Page.Response.Redirect(URLPRINCIPAL);
			}
		}

		private void dgConsultarConvenioSimaMgp_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		const string URLCOMOPERPAC="ConsultarPeriodoUnidadesApoyo.aspx?";
		const string URLFASUB="ConsultarPeriodoFasub.aspx?";
		const string KEYIDIDUNIDADAPOYO="IdUnidadApoyo";
		private DataTable UnidadApoyoUsa()
		{
			CPeriodoUnidadesApoyo oPeriodoUnidadesApoyo=new CPeriodoUnidadesApoyo();
			DataTable dtU=oPeriodoUnidadesApoyo.ConsultarMontoUnidadesDeApoyo();

			return dtU;

		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			CConvenioSimaMgp oCConvenioSimaMgp=new CConvenioSimaMgp();
			DataTable dtConvenioSimaMgp=oCConvenioSimaMgp.ConsultarMontosAgrupadosPorConvenio(1);

			if(dtConvenioSimaMgp!=null)
			{
				DataTable dtImpresion0 = dtConvenioSimaMgp.Copy();
				dtImpresion0.TableName = TablaImpresion0;

				DataView dvConvenioSimaMgp = dtConvenioSimaMgp.DefaultView;
				dvConvenioSimaMgp.Sort = columnaOrdenar;
				dgConsultarConvenioSimaMgp.DataSource = dvConvenioSimaMgp;
			
				lblResultadoConvenio.Visible=false;

				ds.Tables.Add(dtImpresion0);
				dgConsultarConvenioSimaMgp.Columns[3].FooterText = dvConvenioSimaMgp.Count.ToString();
			}
			else
			{
				dgConsultarConvenioSimaMgp.DataSource = dtConvenioSimaMgp;
				lblResultadoConvenio.Text = GRILLAVACIA1;
				lblResultadoConvenio.Visible=true;
			}
			try
			{
				dgConsultarConvenioSimaMgp.DataBind();
			}
			catch	
			{
				dgConsultarConvenioSimaMgp.CurrentPageIndex = Utilitario.Constantes.ValorConstanteCero;
				dgConsultarConvenioSimaMgp.DataBind();
			}
		}

		private void LlenarGrigaMontoUnidadApoyo()
		{
			CPeriodoUnidadesApoyo oPeriodoUnidadesApoyo=new CPeriodoUnidadesApoyo();
			this.ReiniciarVariableAcumuladas();
			DataTable dtUnidadApoyoComoperpac = this.UnidadApoyoUsa();
			
			if(dtUnidadApoyoComoperpac!=null)
			{
				DataTable dtImpresion1 = dtUnidadApoyoComoperpac.Copy();
				dtImpresion1.TableName = TablaImpresion1;

				dgUnidadApoyo.DataSource = dtUnidadApoyoComoperpac;
				
				dgUnidadApoyo.Columns[2].FooterText = dtUnidadApoyoComoperpac.Rows.Count.ToString();

				ds.Tables.Add(dtImpresion1);
			}
			else
			{

				dgUnidadApoyo.DataSource = dtUnidadApoyoComoperpac;
				LblResultadoComoperpac.Text = GRILLAVACIA2;

			} 
			try
			{
				dgUnidadApoyo.DataBind();
				CImpresion oCImpresion = new CImpresion();
				oCImpresion.GuardarDataImprimirExportar(ds,this.lblTituloConvenio.Text,this.lblTituloSecundario.Text,0);
			}
			catch	
			{
				dgUnidadApoyo.CurrentPageIndex = Utilitario.Constantes.ValorConstanteCero;
				dgUnidadApoyo.DataBind();
			}
		}
		
		private void dgUnidadApoyo_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				
				e.Item.Cells[Utilitario.Constantes.POSICIONINDEXCERO].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);

				if (dr["SIGLAS"].ToString() == "COMOPERPAC")
				{
					e.Item.Cells[POSICIONCONTADOR].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
						Helper.MostrarVentana(URLCONSULTARPERIODOUNIDADESAPOYO,Utilitario.Constantes.KeyQPaginaValorInicial + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.KeyQPaginaValor) + Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.POPUPDEESPERA);
				}
				else
				{

					e.Item.Cells[POSICIONCONTADOR].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
						Helper.MostrarVentana(URLFASUB + KEYIDIDUNIDADAPOYO + Utilitario.Constantes.SIGNOIGUAL + dr[Utilitario.Enumerados.ColumnasUnidadApoyo.IdUnidadApoyo.ToString()].ToString()
						+ Utilitario.Constantes.SIGNOAMPERSON + KEYSIGLAS + Utilitario.Constantes.SIGNOIGUAL + dr[Enumerados.ColumnasUnidadApoyo.Siglas.ToString()].ToString())  + Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.POPUPDEESPERA);
				}

				e.Item.Cells[POSICIONCONTADOR].Text = Helper.ObtenerIndicedeRegistro(this.dgUnidadApoyo.CurrentPageIndex,this.dgUnidadApoyo.PageSize,e.Item.ItemIndex);
				e.Item.Cells[POSICIONCONTADOR].Font.Underline=true;
				e.Item.Cells[0].ForeColor=Color.Blue;

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,Utilitario.Helper.MostrarDatosEnCajaTexto("hCodigo",dr["SIGLAS"].ToString()));
				Helper.FiltroporSeleccionConfiguraColumna(e,this.dgUnidadApoyo);

				this.acumMontoAsignado += NullableIsNull.IsNullDouble(dr[Utilitario.Enumerados.ApoyoUnidadSubMarinoColumnas.MontoAsignado.ToString()],0);
				this.acumMontoAprobado += NullableIsNull.IsNullDouble(dr[Utilitario.Enumerados.ApoyoUnidadSubMarinoColumnas.MontoAprobado.ToString()],0);
				this.acumMontoEjecutado += NullableIsNull.IsNullDouble(dr[Utilitario.Enumerados.ApoyoUnidadSubMarinoColumnas.MontoEjecutado.ToString()],0);
				this.acumMontoEnEjecucion += NullableIsNull.IsNullDouble(dr[Utilitario.Enumerados.ApoyoUnidadSubMarinoColumnas.MontoEnEjecucion.ToString()],0);
				this.acumMontoComprometido += NullableIsNull.IsNullDouble(dr[Utilitario.Enumerados.ApoyoUnidadSubMarinoColumnas.MontoComprometido.ToString()],0);
				this.acumMontoSaldo += NullableIsNull.IsNullDouble(dr[Utilitario.Enumerados.ApoyoUnidadSubMarinoColumnas.MontoSaldo.ToString()],0);
			}
			else if(e.Item.ItemType == ListItemType.Footer)
			{   
				e.Item.Cells[Utilitario.Constantes.POSICIONINDEXUNO].Text = Utilitario.Constantes.TEXTOTOTAL + " " + Utilitario.Enumerados.Moneda.NS;
				e.Item.Cells[Utilitario.Constantes.POSICIONINDEXDOS].Text = acumMontoAsignado.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[Utilitario.Constantes.POSICIONINDEXTRES].Text = acumMontoAprobado.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[Utilitario.Constantes.POSICIONINDEXCUATRO].Text = acumMontoEjecutado.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[Utilitario.Constantes.POSICIONINDEXCINCO].Text = acumMontoEnEjecucion.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[Utilitario.Constantes.POSICIONINDEXSEIS].Text = acumMontoComprometido.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[Utilitario.Constantes.POSICIONINDEXSIETE].Text = acumMontoSaldo.ToString(Utilitario.Constantes.FORMATODECIMAL4);
			}
		}

		private void dgUnidadApoyo_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.hOrdenGrilla.Value = Helper.GenerarExpresionOrdenamiento(e.SortExpression);
			this.LlenarGrillaOrdenamientoPaginacion(this.hOrdenGrilla.Value,Helper.ObtenerIndicePagina());
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			CPeriodoUnidadesApoyo oPeriodoUnidadesApoyo=new CPeriodoUnidadesApoyo();
			//DataTable dtUnidadApoyoComoperpac=oPeriodoUnidadesApoyo.ConsultarMontoUnidadesDeApoyo();

			this.ReiniciarVariableAcumuladas();
			DataTable dtUnidadApoyoComoperpac = this.UnidadApoyoUsa();
			
			if(dtUnidadApoyoComoperpac!=null)
			{
				DataTable dtImpresion1 = dtUnidadApoyoComoperpac.Copy();
				dtImpresion1.TableName = TablaImpresion1;

				dgUnidadApoyo.DataSource = dtUnidadApoyoComoperpac;

				ds.Tables.Add(dtImpresion1);
			}
			else
			{

				dgUnidadApoyo.DataSource = dtUnidadApoyoComoperpac;
				LblResultadoComoperpac.Text = GRILLAVACIA2;

			} 
			try
			{
				dgUnidadApoyo.DataBind();
				CImpresion oCImpresion = new CImpresion();
				oCImpresion.GuardarDataImprimirExportar(ds,this.lblTituloConvenio.Text,this.lblTituloSecundario.Text,0);
			}
			catch	
			{
				dgUnidadApoyo.CurrentPageIndex = 0;
				dgUnidadApoyo.DataBind();
			}
		}
	}
}

