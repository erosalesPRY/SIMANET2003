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
using SIMA.Log;
using NetAccessControl;
using NullableTypes;
using SIMA.EntidadesNegocio.Convenio;
namespace SIMA.SimaNetWeb.Convenio
{
	public class ConsultarConvenioCOMOPERAMA : System.Web.UI.Page, IPaginaBase
	{
		private void Page_Load(object sender, System.EventArgs e)
		{
			
			if (!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarGrillaOrdenamientoPaginacion("",Utilitario.Constantes.INDICEPAGINADEFAULT);
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Utilitario.Enumerados.NombresdeModulo.ConveniosyProyectos.ToString(),this.ToString(), "Se Consultó COnvenio COMOPERAMA",Enumerados.NivelesErrorLog.I.ToString()));
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
			this.dgConsultarConvenioSimaMgp.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgConsultarConvenioSimaMgp_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		#region Eventos de la Grilla
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
				e.Item.Cells[Utilitario.Constantes.POSICIONINDEXUNO].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.MostrarVentana(URLPROYECTOCONVENIO,"keyIdCOMOPERAMA=1&" + KEYIDCONVENIOSIMAMGP + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr[Enumerados.ColumnasConvenioSimaMgp.IdConvenioSimaMgp.ToString()])));
				e.Item.Cells[Utilitario.Constantes.POSICIONINDEXUNO].Text=Convert.ToString(dr[Enumerados.ColumnasConvenioSimaMgp.NroConvenio.ToString()]);
				e.Item.Cells[Utilitario.Constantes.POSICIONINDEXUNO].Font.Underline=true;
				e.Item.Cells[0].ForeColor=Color.Blue;

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
		#endregion
		#region IPaginaBase Members
		public void LlenarGrilla()
		{
			
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
		{
			CConvenioSimaMgp oCConvenioSimaMgp=new CConvenioSimaMgp();
			DataTable dtConvenioSimaMgp=oCConvenioSimaMgp.ConsultarMontosAgrupadosPorConvenio(2);

			if(dtConvenioSimaMgp!=null)
			{
				DataTable dtImpresion0 = dtConvenioSimaMgp.Copy();

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
			catch (Exception ex)
			{
				dgConsultarConvenioSimaMgp.CurrentPageIndex = Utilitario.Constantes.ValorConstanteCero;
				dgConsultarConvenioSimaMgp.DataBind();
			}
		}

		public void LlenarCombos()
		{
		}

		public void LlenarDatos()
		{
		}

		public void LlenarJScript()
		{
		}

		public void RegistrarJScript()
		{
	

		}

		public void Imprimir()
		{

		}

		public void Exportar()
		{
			
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
		#region Constantes
		private double acumMontoAsignado=0;
		private double acumMontoAprobado=0;
		private double acumMontoEjecutado=0;
		private double acumMontoEnEjecucion=0;
		private double acumMontoComprometido=0;
		private double acumMontoPagado=0;
		private double acumMontoSaldo=0;
		private double acumAvanceFisico=0;
		private double acumPagoXCuotas=0;
		DataSet ds = new DataSet();

		// Columnas de Ordenamiento
		private const string COLORDENAMIENTO = "NroConvenio Asc";
		private const int POSICIONCONTADOR=0;
		
		// Otros
		const string GRILLAVACIA1="No existe ningun Convenio Sima-Mgp que se encuentre vigente";

		//URL
		const string KEYQID = "";

		const string URLPROYECTOCONVENIO="ConsultarProyectosConvenioSimaMgp.aspx?";
		const string URLDIRECTORIO = "/SimaNetWebGestion/DirectorioEjecutivo/InformeDirectorio.aspx";
		const string URLPRINCIPAL = "../../Default.aspx";
		const string URLRESUMENCONVENIO = "ConsultarDetalleResumenConvenio.aspx";
		
		const string CONTROLINK="hlkId";

		//KEYID SESION.
		const string KEYIDCONVENIOSIMAMGP="IdConvenioSimaMgp";

		//Otros
		#endregion Constantes
		#region Controles
		protected System.Web.UI.WebControls.TextBox txtObservaciones;
		protected System.Web.UI.WebControls.Label lblObservaciones;
		protected projDataGridWeb.DataGridWeb dgConsultarConvenioSimaMgp;
		protected System.Web.UI.WebControls.Label lblTituloConvenio;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hOrdenGrilla;
		protected System.Web.UI.HtmlControls.HtmlInputHidden Hidden1;
		protected System.Web.UI.WebControls.Label lblResultadoConvenio;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		#endregion
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

			parametros = "<chart><series><value xid='0'>MONTO CONVENIO</value>" +
				"<value xid='1'>MONTO APROBADO</value>" +
				"<value xid='2'>AVANCE FISICO</value>" +
				"<value xid='3'>MONTO AUTORIZADO</value>" +
				"<value xid='4'>MONTO PAGADO</value>" +
				"<value xid='5'>PAGO POR CUOTAS</value>" +
				"</series><graphs><graph gid='0'>" +
				"<value xid='0' color='#C80A15'>" + montoConvenio + "</value>" +
				"<value xid='1' color='#2959aa'>" + montoAprobado + "</value>" +
				"<value xid='2' color='#f5e72f'>" + avanceFisico + "</value>" +
				"<value xid='3' color='#3aecea'>" + NullableIsNull.IsNullDouble(oConvenioSimaMgpBE.MontoAutorizado,0).ToString() + "</value>" +
				"<value xid='4' color='#30c57d'>" + montoPagado + "</value>" +
				"<value xid='5' color='#e78c49'>" + pagoXCuotas + "</value>" +
				"</graph></graphs></chart>";
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
			mesActual = DateTime.Now.Month;
			periodo = DateTime.Now.Year;

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
	}
}
