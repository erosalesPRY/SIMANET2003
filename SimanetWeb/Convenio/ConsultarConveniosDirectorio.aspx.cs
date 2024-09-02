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
	public class ConsultarConveniosDirectorio : System.Web.UI.Page
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
			this.gridCOMOPERAMA.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.gridCOMOPERAMA_PageIndexChanged);
			this.gridCOMOPERAMA.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.gridCOMOPERAMA_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		#region Constantes
		private const string GRILLAVACIA= "No existen Registros";

		//URL
		const string KEYQID = "";
		
		const string KEYQTIPOCONVENIO="TipoConvenio";
		const string COMOPERPAC = "COMOPERPAC";
		const string COMOPERAMA = "COMOPERAMA";
		const string DIMATEMAR = "DIMATEMAR";

		const string URLPROYECTOCONVENIO="ConsultarProyectosConvenioSimaMgp.aspx?";
		const string URLIMPRESION = "PopupConsultarConvenioSimaMgpUnidadesApoyo.aspx";
		const string URLCONSULTARPERIODOUNIDADESAPOYO="ConsultarPeriodoUnidadesApoyo.aspx?";
		const string URLDIRECTORIO = "/SimaNetWeb/DirectorioEjecutivo/InformeDirectorio.aspx";
		const string URLPRINCIPAL = "../../Default.aspx";
		const string URLRESUMENCONVENIO = "ConsultarDetalleResumenConvenio.aspx";
		const string URLCONSULTARSUBMARINOSPORPERIODO = "ConsultarSubmarinosPorPeriodo.aspx?";
		const string KEYIDCONVENIOSIMAMGP="IdConvenioSimaMgp";

		#endregion
		#region Controles
		protected System.Web.UI.WebControls.TextBox txtObservaciobesCOMOPERAMA;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTituloConvenio;
		protected projDataGridWeb.DataGridWeb dgConsultarConvenioSimaMgp;
		protected System.Web.UI.WebControls.Label lblResultadoConvenio;
		protected System.Web.UI.WebControls.TextBox txtObservaciones;
		protected System.Web.UI.WebControls.Label lblTituloSecundario;
		protected System.Web.UI.WebControls.Label LblResultadoComoperpac;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hOrdenGrilla;
		protected System.Web.UI.HtmlControls.HtmlInputHidden Hidden1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.WebControls.Label lblTituloPrincipal;
		protected System.Web.UI.WebControls.TextBox txtConvMGP;
		protected System.Web.UI.WebControls.TextBox txtConvComoperama;
		protected projDataGridWeb.DataGridWeb gridTotales;
		protected System.Web.UI.WebControls.Label Label1;

		#endregion
		#region Variables
		private double TotalMontoConvenio=0;
		private double TotalMontoAprobado=0;
		private double TotalAvanceFisico=0;
		private double TotalActaConformidad=0;
		private double TotalPagado=0;
		private double TotalSaldoConvenio=0;

		private double acumMontoAsignado=0;
		private double acumMontoAprobado=0;
		private double acumMontoEjecutado=0;
		private double acumMontoEnEjecucion=0;
		private double acumMontoComprometido=0;
		private double acumMontoPagado=0;
		private double acumAvanceFisico=0;
		private double acumPagoXCuotas = 0;
		protected projDataGridWeb.DataGridWeb gridCOMOPERAMA;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hEfecto;
		protected System.Web.UI.HtmlControls.HtmlInputHidden Hidden2;
		private double acumMontoSaldo=0;
		#endregion
		#region Eventos

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					if (Session["Mensaje"]== null)
					{
						hEfecto.Value="1";
						Session["Mensaje"] = "zzz";
					}

					this.LlenarGrillaOrdenamientoPaginacionMGP("",0);
					ReiniciarVariableAcumuladas();
					this.LlenarGrillaOrdenamientoPaginacionCOMOPERAMA("",0);
					ReiniciarVariableAcumuladas();
					//this.LlenarGrillaOrdenamientoPaginacionDimatemar("",0);

					this.LlenarTotales();

					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),
						Utilitario.Enumerados.NombresdeModulo.ConveniosyProyectos.ToString(),this.ToString(),"Se Consulto los Covenios MGP.",Enumerados.NivelesErrorLog.I.ToString()));
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

		private void LlenarTotales()
		{
			DataTable dt = new DataTable();
			dt.Columns.Add("MontoAsignado");
			dt.Columns.Add("MontoAprobado");
			dt.Columns.Add("avancefisico");
			dt.Columns.Add("MontoEjecutado");
			dt.Columns.Add("MontoPagado");
			dt.Columns.Add("MontoSaldo");

			DataRow dr = dt.NewRow();
			dr["MontoAsignado"] = TotalMontoConvenio.ToString(Utilitario.Constantes.FORMATODECIMAL4);
			dr["MontoAprobado"] = TotalMontoAprobado.ToString(Utilitario.Constantes.FORMATODECIMAL4);
			dr["avancefisico"] = TotalAvanceFisico.ToString(Utilitario.Constantes.FORMATODECIMAL4);
			dr["MontoEjecutado"] = TotalActaConformidad.ToString(Utilitario.Constantes.FORMATODECIMAL4);
			dr["MontoPagado"] = TotalPagado.ToString(Utilitario.Constantes.FORMATODECIMAL4);
			dr["MontoSaldo"] = TotalSaldoConvenio.ToString(Utilitario.Constantes.FORMATODECIMAL4);
			dt.Rows.Add(dr);

			gridTotales.DataSource = dt;
			gridTotales.DataBind();
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
			acumAvanceFisico=Utilitario.Constantes.ValorConstanteCero;
		}
		public void LlenarGrillaOrdenamientoPaginacionMGP(string columnaOrdenar,int indicePagina)
		{
			CConvenioSimaMgp oCConvenioSimaMgp=new CConvenioSimaMgp();
			DataTable dtConvenioSimaMgp=oCConvenioSimaMgp.ConsultarMontosAgrupadosPorConvenioDirectorio(1);

			if(dtConvenioSimaMgp!=null)
			{
				DataView dwAgrupacion = dtConvenioSimaMgp.DefaultView;
				dwAgrupacion.Sort = columnaOrdenar ;
				//dwAgrupacion.RowFilter="nroconvenio <>'2000-00'";
				if(dwAgrupacion.Count>0)
				{
					dgConsultarConvenioSimaMgp.DataSource = dwAgrupacion;
					dgConsultarConvenioSimaMgp.Columns[Utilitario.Constantes.POSICIONINDEXTRES].FooterText = dwAgrupacion.Count.ToString();
					this.lblResultadoConvenio.Visible = false;
				}
				else
				{
					dgConsultarConvenioSimaMgp.DataSource = null;
					lblResultadoConvenio.Visible = true;
					lblResultadoConvenio.Text = GRILLAVACIA;
				}
				
			}
			else
			{
				dgConsultarConvenioSimaMgp.DataSource = dtConvenioSimaMgp;
				lblResultadoConvenio.Text = GRILLAVACIA;
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

		/*		public void LlenarGrillaOrdenamientoPaginacionDimatemar(string columnaOrdenar,int indicePagina)
				{
					CConvenioSimaMgp oCConvenioSimaMgp=new CConvenioSimaMgp();
					DataTable dtConvenioSimaMgp=oCConvenioSimaMgp.ConsultarMontosAgrupadosPorConvenioDirectorio(3);

					if(dtConvenioSimaMgp!=null)
					{
						DataView dwAgrupacion = dtConvenioSimaMgp.DefaultView;
						dwAgrupacion.Sort = columnaOrdenar ;
						if(dwAgrupacion.Count>0)
						{
							gridDimatemar.DataSource = dwAgrupacion;
							gridDimatemar.Columns[Utilitario.Constantes.POSICIONINDEXTRES].FooterText = dwAgrupacion.Count.ToString();
							this.lblResultadoDimatemar.Visible = false;
						}
						else
						{
							gridDimatemar.DataSource = null;
							lblResultadoDimatemar.Visible = true;
							lblResultadoDimatemar.Text = GRILLAVACIA;
						}
				
					}
					else
					{
						gridDimatemar.DataSource = dtConvenioSimaMgp;
						lblResultadoDimatemar.Text = GRILLAVACIA;
					}
			
					try
					{
						gridDimatemar.DataBind();
					}
					catch	
					{
						gridDimatemar.CurrentPageIndex = Utilitario.Constantes.ValorConstanteCero;
						gridDimatemar.DataBind();
					}
				}*/

		public void LlenarGrillaOrdenamientoPaginacionCOMOPERAMA(string columnaOrdenar,int indicePagina)
		{
			CConvenioSimaMgp oCConvenioSimaMgp=new CConvenioSimaMgp();
			DataTable dtConvenioSimaMgp=oCConvenioSimaMgp.ConsultarMontosAgrupadosPorConvenioDirectorio(2);

			if(dtConvenioSimaMgp!=null)
			{
				DataView dwAgrupacion = dtConvenioSimaMgp.DefaultView;
				dwAgrupacion.Sort = columnaOrdenar ;
				if(dwAgrupacion.Count>0)
				{
					gridCOMOPERAMA.DataSource = dwAgrupacion;
					gridCOMOPERAMA.Columns[Utilitario.Constantes.POSICIONINDEXTRES].FooterText = dwAgrupacion.Count.ToString();
					this.LblResultadoComoperpac.Visible = false;
				}
				else
				{
					gridCOMOPERAMA.DataSource = null;
					LblResultadoComoperpac.Visible = true;
					LblResultadoComoperpac.Text = GRILLAVACIA;
				}
				
			}
			else
			{
				gridCOMOPERAMA.DataSource = dtConvenioSimaMgp;
				LblResultadoComoperpac.Text = GRILLAVACIA;
			}
			
			try
			{
				gridCOMOPERAMA.DataBind();
			}
			catch	
			{
				gridCOMOPERAMA.CurrentPageIndex = Utilitario.Constantes.ValorConstanteCero;
				gridCOMOPERAMA.DataBind();
			}
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

				//pagoXCuotas = montoCronogramaPagos(int.Parse(dr[Utilitario.Enumerados.ColumnasConvenioSimaMgp.IdConvenioSimaMgp.ToString()].ToString()));
				pagoXCuotas = NullableIsNull.IsNullDouble(dr[Enumerados.ColumnasConvenioSimaMgp.MontoPagado.ToString()],0);
				acumMontoAsignado = acumMontoAsignado + NullableIsNull.IsNullDouble(dr[Enumerados.ColumnasConvenioSimaMgp.MontoAsignado.ToString()],0);
				acumMontoAprobado = acumMontoAprobado + NullableIsNull.IsNullDouble(dr[Enumerados.ColumnasConvenioSimaMgp.MontoAprobado.ToString()],0);
				acumMontoEjecutado = acumMontoEjecutado + NullableIsNull.IsNullDouble(dr[Enumerados.ColumnasConvenioSimaMgp.MontoEjecutado.ToString()],0);
				acumMontoEnEjecucion = acumMontoEnEjecucion + NullableIsNull.IsNullDouble(dr[Enumerados.ColumnasConvenioSimaMgp.MontoEnEjecucion.ToString()],0);
				acumMontoComprometido = acumMontoComprometido + NullableIsNull.IsNullDouble(dr[Enumerados.ColumnasConvenioSimaMgp.MontoComprometido.ToString()],0);
				acumMontoSaldo = acumMontoSaldo + NullableIsNull.IsNullDouble(dr[Enumerados.ColumnasConvenioSimaMgp.MontoSaldo.ToString()],0);
				acumAvanceFisico = acumAvanceFisico + NullableIsNull.IsNullDouble(dr[Enumerados.ColumnasConvenioSimaMgp.AvanceFisico.ToString()],0);
				acumPagoXCuotas = acumPagoXCuotas + NullableIsNull.IsNullDouble(dr[Enumerados.ColumnasConvenioSimaMgp.MontoPagado.ToString()],0);
				//acumPagoXCuotas = acumPagoXCuotas + pagoXCuotas;
				//Calculando lo pagado
				MontoRecibido=0;
				MontoPorCobrar=0;
				oCConvenioSimaMgp.ConsultarMontoRecibidoMontoPorCobrarDeUnConvenio(Convert.ToInt32(
					e.Item.Cells[Utilitario.Constantes.POSICIONINDEXCERO].Text),ref MontoRecibido,ref MontoPorCobrar);
				//e.Item.Cells[Utilitario.Constantes.POSICIONINDEXSEIS].Text=MontoRecibido.Value.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				//e.Item.Cells[Utilitario.Constantes.POSICIONINDEXSIETE].Text = pagoXCuotas.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				//acumMontoPagado = acumMontoPagado + MontoRecibido.Value;				
				//Continuando el resto

				string sCadena = Utilitario.Enumerados.ColumnasConvenioSimaMgp.IdConvenioSimaMgp.ToString() + Utilitario.Constantes.SIGNOIGUAL + dr[Utilitario.Enumerados.ColumnasConvenioSimaMgp.IdConvenioSimaMgp.ToString()].ToString();
				sCadena = Helper.MostrarDatosEnCajaTexto(this.hCodigo.ID.ToString(),sCadena);
				
				sCadena += Utilitario.Constantes.EspacioEnBlancoVS + Helper.MostrarDatosEnCajaTexto(this.txtObservaciones.ID.ToString(),
					Helper.LimpiarTexto(dr[Utilitario.Enumerados.ColumnasConvenioSimaMgp.Observaciones.ToString()].ToString()));
				sCadena += Utilitario.Constantes.EspacioEnBlancoVS + Helper.MostrarDatosEnCajaTexto(this.txtConvMGP.ID.ToString(),
					Helper.LimpiarTexto(dr[Utilitario.Enumerados.ColumnasConvenioSimaMgp.Descripcion.ToString()].ToString()));

				Utilitario.Helper.SeleccionarItemGrillaOnClickMoverRaton(e,sCadena);

				Helper.FiltroporSeleccionConfiguraColumna(e,this.dgConsultarConvenioSimaMgp);
				//Llenar cuadro
				LlenarCuadroEstadisticoMGP(dr[Enumerados.ColumnasConvenioSimaMgp.MontoAsignado.ToString()].ToString(),
					dr[Enumerados.ColumnasConvenioSimaMgp.MontoAprobado.ToString()].ToString(),
					dr[Enumerados.ColumnasConvenioSimaMgp.AvanceFisico.ToString()].ToString(),
					pagoXCuotas.ToString(), pagoXCuotas.ToString(),img,int.Parse(dr[Utilitario.Enumerados.ColumnasConvenioSimaMgp.IdConvenioSimaMgp.ToString()].ToString()));

				/*LlenarCuadroEstadisticoMGP(dr[Enumerados.ColumnasConvenioSimaMgp.MontoAsignado.ToString()].ToString(),
					dr[Enumerados.ColumnasConvenioSimaMgp.MontoAprobado.ToString()].ToString(),
					dr[Enumerados.ColumnasConvenioSimaMgp.AvanceFisico.ToString()].ToString(),
					MontoRecibido.Value.ToString(), pagoXCuotas.ToString(),img,int.Parse(dr[Utilitario.Enumerados.ColumnasConvenioSimaMgp.IdConvenioSimaMgp.ToString()].ToString()));*/

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
				e.Item.Cells[Utilitario.Constantes.POSICIONINDEXSEIS].Text=acumPagoXCuotas.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				//e.Item.Cells[Utilitario.Constantes.POSICIONINDEXSIETE].Text=acumPagoXCuotas.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[Utilitario.Constantes.POSICIONINDEXOCHO].Text=acumMontoSaldo.ToString(Utilitario.Constantes.FORMATODECIMAL4);

				//Modificacion para Totales
				TotalMontoConvenio +=acumMontoAsignado;
				TotalMontoAprobado +=acumMontoAprobado;
				TotalAvanceFisico +=acumAvanceFisico;
				TotalActaConformidad +=acumMontoEjecutado;
				TotalPagado +=acumPagoXCuotas;
				TotalSaldoConvenio+=acumMontoSaldo;
				//Fin modificación para totales
			}
		}

		private void dgConsultarConvenioSimaMgp_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			dgConsultarConvenioSimaMgp.CurrentPageIndex=e.NewPageIndex;
			HttpContext.Current.Session[Utilitario.Constantes.KEYSINDICEPAGINA]=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacionMGP("",e.NewPageIndex);
		}

		private void gridCOMOPERAMA_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			CConvenioSimaMgp oCConvenioSimaMgp=new CConvenioSimaMgp();
			NullableDouble MontoRecibido=0;
			NullableDouble MontoPorCobrar=0;
			double pagoXCuotas = 0;
			
			if(e.Item.ItemType == ListItemType.Header)
			{acumPagoXCuotas = 0;}

			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				System.Web.UI.WebControls.Image img = (System.Web.UI.WebControls.Image)
					e.Item.FindControl("ibtnGraficoEstadisticoCOMOPERAMA");

				e.Item.Cells[Utilitario.Constantes.POSICIONINDEXUNO].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
				e.Item.Cells[Utilitario.Constantes.POSICIONINDEXUNO].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.MostrarVentana(URLPROYECTOCONVENIO,"keyIdCOMOPERAMA=1&" + KEYIDCONVENIOSIMAMGP + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr[Enumerados.ColumnasConvenioSimaMgp.IdConvenioSimaMgp.ToString()])));
				e.Item.Cells[Utilitario.Constantes.POSICIONINDEXUNO].Text=Convert.ToString(dr[Enumerados.ColumnasConvenioSimaMgp.NroConvenio.ToString()]);
				e.Item.Cells[Utilitario.Constantes.POSICIONINDEXUNO].Font.Underline=true;
				e.Item.Cells[1].ForeColor=Color.Blue;

				//pagoXCuotas = montoCronogramaPagos(int.Parse(dr[Utilitario.Enumerados.ColumnasConvenioSimaMgp.IdConvenioSimaMgp.ToString()].ToString()));
				pagoXCuotas = NullableIsNull.IsNullDouble(dr[Enumerados.ColumnasConvenioSimaMgp.MontoPagado.ToString()],0);
				acumMontoAsignado = acumMontoAsignado + NullableIsNull.IsNullDouble(dr[Enumerados.ColumnasConvenioSimaMgp.MontoAsignado.ToString()],0);
				acumMontoAprobado = acumMontoAprobado + NullableIsNull.IsNullDouble(dr[Enumerados.ColumnasConvenioSimaMgp.MontoAprobado.ToString()],0);
				acumMontoEjecutado = acumMontoEjecutado + NullableIsNull.IsNullDouble(dr[Enumerados.ColumnasConvenioSimaMgp.MontoEjecutado.ToString()],0);
				acumMontoEnEjecucion = acumMontoEnEjecucion + NullableIsNull.IsNullDouble(dr[Enumerados.ColumnasConvenioSimaMgp.MontoEnEjecucion.ToString()],0);
				acumMontoComprometido = acumMontoComprometido + NullableIsNull.IsNullDouble(dr[Enumerados.ColumnasConvenioSimaMgp.MontoComprometido.ToString()],0);
				acumMontoSaldo = acumMontoSaldo + NullableIsNull.IsNullDouble(dr[Enumerados.ColumnasConvenioSimaMgp.MontoSaldo.ToString()],0);
				acumAvanceFisico = acumAvanceFisico + NullableIsNull.IsNullDouble(dr[Enumerados.ColumnasConvenioSimaMgp.AvanceFisico.ToString()],0);
				acumPagoXCuotas = acumPagoXCuotas + NullableIsNull.IsNullDouble(dr[Enumerados.ColumnasConvenioSimaMgp.MontoPagado.ToString()],0);
				//acumPagoXCuotas = acumPagoXCuotas + pagoXCuotas;
				//Calculando lo pagado

				MontoRecibido=0;
				MontoPorCobrar=0;

				oCConvenioSimaMgp.ConsultarMontoRecibidoMontoPorCobrarDeUnConvenio(Convert.ToInt32(
					e.Item.Cells[Utilitario.Constantes.POSICIONINDEXCERO].Text),ref MontoRecibido,ref MontoPorCobrar);

				//e.Item.Cells[Utilitario.Constantes.POSICIONINDEXSEIS].Text=MontoRecibido.Value.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				//e.Item.Cells[Utilitario.Constantes.POSICIONINDEXSIETE].Text = pagoXCuotas.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				//acumMontoPagado = acumMontoPagado + MontoRecibido.Value;			
				//Continuando el resto
				string sCadena = Utilitario.Enumerados.ColumnasConvenioSimaMgp.IdConvenioSimaMgp.ToString() + Utilitario.Constantes.SIGNOIGUAL + dr[Utilitario.Enumerados.ColumnasConvenioSimaMgp.IdConvenioSimaMgp.ToString()].ToString();
				
				sCadena = Helper.MostrarDatosEnCajaTexto(this.hCodigo.ID.ToString(),sCadena);
				sCadena += Utilitario.Constantes.EspacioEnBlancoVS + Helper.MostrarDatosEnCajaTexto(this.txtObservaciobesCOMOPERAMA.ID.ToString(),Helper.LimpiarTexto(dr[Utilitario.Enumerados.ColumnasConvenioSimaMgp.Observaciones.ToString()].ToString()));
				sCadena += Utilitario.Constantes.EspacioEnBlancoVS + Helper.MostrarDatosEnCajaTexto(this.txtConvComoperama.ID.ToString(),
					Helper.LimpiarTexto(dr[Utilitario.Enumerados.ColumnasConvenioSimaMgp.Descripcion.ToString()].ToString()));

				Utilitario.Helper.SeleccionarItemGrillaOnClickMoverRaton(e,sCadena);
				Helper.FiltroporSeleccionConfiguraColumna(e,this.dgConsultarConvenioSimaMgp);
	
				//Llenar cuadro
				LlenarCuadroEstadisticoMGP(dr[Enumerados.ColumnasConvenioSimaMgp.MontoAsignado.ToString()].ToString(),
					dr[Enumerados.ColumnasConvenioSimaMgp.MontoAprobado.ToString()].ToString(),
					dr[Enumerados.ColumnasConvenioSimaMgp.AvanceFisico.ToString()].ToString(),
					pagoXCuotas.ToString(),pagoXCuotas.ToString(),img,int.Parse(dr[Utilitario.Enumerados.ColumnasConvenioSimaMgp.IdConvenioSimaMgp.ToString()].ToString()));
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
				e.Item.Cells[Utilitario.Constantes.POSICIONINDEXSEIS].Text=acumPagoXCuotas.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				//e.Item.Cells[Utilitario.Constantes.POSICIONINDEXSIETE].Text=acumPagoXCuotas.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[Utilitario.Constantes.POSICIONINDEXOCHO].Text=acumMontoSaldo.ToString(Utilitario.Constantes.FORMATODECIMAL4);

				//Modificacion para Totales
				TotalMontoConvenio +=acumMontoAsignado;
				TotalMontoAprobado +=acumMontoAprobado;
				TotalAvanceFisico +=acumAvanceFisico;
				TotalActaConformidad +=acumMontoEjecutado;
				TotalPagado +=acumPagoXCuotas;
				TotalSaldoConvenio+=acumMontoSaldo;
				//Fin modificación para totales
			}
		}

		private void gridCOMOPERAMA_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			gridCOMOPERAMA.CurrentPageIndex=e.NewPageIndex;
			HttpContext.Current.Session[Utilitario.Constantes.KEYSINDICEPAGINA]=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacionCOMOPERAMA("",e.NewPageIndex);
		}

		#endregion
		#region GraficosConvenios
		private void LlenarCuadroEstadisticoMGP(
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
				//"<value xid='3'>MONTO AUTORIZADO</value>" +
				"<value xid='3'>MONTO PAGADO</value>" +
				//"<value xid='5'>PAGO POR CUOTAS</value>" +
				"</series><graphs><graph gid='0'>" +
				"<value xid='0' color='#C80A15'>" + montoConvenio + "</value>" +
				"<value xid='1' color='#2959aa'>" + montoAprobado + "</value>" +
				"<value xid='2' color='#f5e72f'>" + avanceFisico + "</value>" +
				//"<value xid='3' color='#3aecea'>" + NullableIsNull.IsNullDouble(oConvenioSimaMgpBE.MontoAutorizado,0).ToString() + "</value>" +
				"<value xid='3' color='#30c57d'>" + montoPagado + "</value>" +
				//"<value xid='5' color='#e78c49'>" + pagoXCuotas + "</value>" +
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

			mesActual = Helper.FechaSimanet.ObtenerFechaSesion().Month+1;
			periodo = Helper.FechaSimanet.ObtenerFechaSesion().Year;

			if (mesActual==13)
			{mesActual=12;}
			
			/*mesActual = DateTime.Now.Month-1;
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
		#endregion

		/*		private void gridDimatemar_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
				{
					gridDimatemar.CurrentPageIndex=e.NewPageIndex;
					HttpContext.Current.Session[Utilitario.Constantes.KEYSINDICEPAGINA]=e.NewPageIndex;
					this.LlenarGrillaOrdenamientoPaginacionDimatemar("",e.NewPageIndex);		
				}

				private void gridDimatemar_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
				{
					CConvenioSimaMgp oCConvenioSimaMgp=new CConvenioSimaMgp();
					NullableDouble MontoRecibido=0;
					NullableDouble MontoPorCobrar=0;
					double pagoXCuotas = 0;
			
					if(e.Item.ItemType == ListItemType.Header)
					{acumPagoXCuotas = 0;}

					if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
					{
						DataRowView drv = (DataRowView)e.Item.DataItem;
						DataRow dr = drv.Row;
						System.Web.UI.WebControls.Image img = (System.Web.UI.WebControls.Image)
							e.Item.FindControl("ibtnGraficoEstadisticoDimatemar");

						e.Item.Cells[Utilitario.Constantes.POSICIONINDEXUNO].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
						e.Item.Cells[Utilitario.Constantes.POSICIONINDEXUNO].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.MostrarVentana(URLPROYECTOCONVENIO,"keyIdCOMOPERAMA=3&" + KEYIDCONVENIOSIMAMGP + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr[Enumerados.ColumnasConvenioSimaMgp.IdConvenioSimaMgp.ToString()])));
						e.Item.Cells[Utilitario.Constantes.POSICIONINDEXUNO].Text=Convert.ToString(dr[Enumerados.ColumnasConvenioSimaMgp.NroConvenio.ToString()]);
						e.Item.Cells[Utilitario.Constantes.POSICIONINDEXUNO].Font.Underline=true;
						e.Item.Cells[0].ForeColor=Color.Blue;

						//pagoXCuotas = montoCronogramaPagos(int.Parse(dr[Utilitario.Enumerados.ColumnasConvenioSimaMgp.IdConvenioSimaMgp.ToString()].ToString()));

						pagoXCuotas = NullableIsNull.IsNullDouble(dr[Enumerados.ColumnasConvenioSimaMgp.MontoPagado.ToString()],0);
						acumMontoAsignado = acumMontoAsignado + NullableIsNull.IsNullDouble(dr[Enumerados.ColumnasConvenioSimaMgp.MontoAsignado.ToString()],0);
						acumMontoAprobado = acumMontoAprobado + NullableIsNull.IsNullDouble(dr[Enumerados.ColumnasConvenioSimaMgp.MontoAprobado.ToString()],0);
						acumMontoEjecutado = acumMontoEjecutado + NullableIsNull.IsNullDouble(dr[Enumerados.ColumnasConvenioSimaMgp.MontoEjecutado.ToString()],0);
						acumMontoEnEjecucion = acumMontoEnEjecucion + NullableIsNull.IsNullDouble(dr[Enumerados.ColumnasConvenioSimaMgp.MontoEnEjecucion.ToString()],0);
						acumMontoComprometido = acumMontoComprometido + NullableIsNull.IsNullDouble(dr[Enumerados.ColumnasConvenioSimaMgp.MontoComprometido.ToString()],0);
						acumMontoSaldo = acumMontoSaldo + NullableIsNull.IsNullDouble(dr[Enumerados.ColumnasConvenioSimaMgp.MontoSaldo.ToString()],0);
						acumAvanceFisico = acumAvanceFisico + NullableIsNull.IsNullDouble(dr[Enumerados.ColumnasConvenioSimaMgp.AvanceFisico.ToString()],0);
						acumPagoXCuotas = acumPagoXCuotas + NullableIsNull.IsNullDouble(dr[Enumerados.ColumnasConvenioSimaMgp.MontoPagado.ToString()],0);				
						//acumPagoXCuotas = acumPagoXCuotas + pagoXCuotas;
						//Calculando lo pagado
						MontoRecibido=0;
						MontoPorCobrar=0;

						oCConvenioSimaMgp.ConsultarMontoRecibidoMontoPorCobrarDeUnConvenio(Convert.ToInt32(
							e.Item.Cells[Utilitario.Constantes.POSICIONINDEXCERO].Text),ref MontoRecibido,ref MontoPorCobrar);

						//e.Item.Cells[Utilitario.Constantes.POSICIONINDEXSEIS].Text=MontoRecibido.Value.ToString(Utilitario.Constantes.FORMATODECIMAL4);
						//e.Item.Cells[Utilitario.Constantes.POSICIONINDEXSIETE].Text = pagoXCuotas.ToString(Utilitario.Constantes.FORMATODECIMAL4);
						//acumMontoPagado = acumMontoPagado + MontoRecibido.Value;			
						//Continuando el resto
						string sCadena = Utilitario.Enumerados.ColumnasConvenioSimaMgp.IdConvenioSimaMgp.ToString() + Utilitario.Constantes.SIGNOIGUAL + dr[Utilitario.Enumerados.ColumnasConvenioSimaMgp.IdConvenioSimaMgp.ToString()].ToString();
				
						sCadena = Helper.MostrarDatosEnCajaTexto(this.hCodigo.ID.ToString(),sCadena);
						sCadena += Utilitario.Constantes.EspacioEnBlancoVS + Helper.MostrarDatosEnCajaTexto(this.txtObservaciobesDimatemar.ID.ToString(),Helper.LimpiarTexto(dr[Utilitario.Enumerados.ColumnasConvenioSimaMgp.Observaciones.ToString()].ToString()));
						sCadena += Utilitario.Constantes.EspacioEnBlancoVS + Helper.MostrarDatosEnCajaTexto(this.txtConvDimatemar.ID.ToString(),
							Helper.LimpiarTexto(dr[Utilitario.Enumerados.ColumnasConvenioSimaMgp.Descripcion.ToString()].ToString()));

						Utilitario.Helper.SeleccionarItemGrillaOnClickMoverRaton(e,sCadena);
						Helper.FiltroporSeleccionConfiguraColumna(e,this.gridDimatemar);
	
						//Llenar cuadro
						LlenarCuadroEstadisticoMGP(dr[Enumerados.ColumnasConvenioSimaMgp.MontoAsignado.ToString()].ToString(),
							dr[Enumerados.ColumnasConvenioSimaMgp.MontoAprobado.ToString()].ToString(),
							dr[Enumerados.ColumnasConvenioSimaMgp.AvanceFisico.ToString()].ToString(),
							pagoXCuotas.ToString(),pagoXCuotas.ToString(),img,int.Parse(dr[Utilitario.Enumerados.ColumnasConvenioSimaMgp.IdConvenioSimaMgp.ToString()].ToString()));
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
						e.Item.Cells[Utilitario.Constantes.POSICIONINDEXSEIS].Text=acumPagoXCuotas.ToString(Utilitario.Constantes.FORMATODECIMAL4);
						//e.Item.Cells[Utilitario.Constantes.POSICIONINDEXSIETE].Text=acumPagoXCuotas.ToString(Utilitario.Constantes.FORMATODECIMAL4);
						e.Item.Cells[Utilitario.Constantes.POSICIONINDEXOCHO].Text=acumMontoSaldo.ToString(Utilitario.Constantes.FORMATODECIMAL4);

						//Modificacion para Totales
						TotalMontoConvenio +=acumMontoAsignado;
						TotalMontoAprobado +=acumMontoAprobado;
						TotalAvanceFisico +=acumAvanceFisico;
						TotalActaConformidad +=acumMontoEjecutado;
						TotalPagado +=acumPagoXCuotas;
						TotalSaldoConvenio+=acumMontoSaldo;
						//Fin modificación para totales
					}
				}
		*/
	}
}
