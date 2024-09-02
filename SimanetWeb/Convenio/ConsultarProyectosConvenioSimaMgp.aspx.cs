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
using SIMA.EntidadesNegocio.Convenio;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using NullableTypes;
//using MetaBuilders.WebControls;

namespace SIMA.SimaNetWeb.Convenio
{
	/// <summary>
	/// Summary description for RequerimientosAsignados.
	/// </summary>
	public class ConsultarProyectosConvenioSimaMgp: System.Web.UI.Page	
	{
		#region Controles		
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.HyperLink hlkRecibido;
		protected System.Web.UI.WebControls.Label lblDescripcion;
		protected System.Web.UI.WebControls.Label lblDbRecibido;
		protected System.Web.UI.WebControls.TextBox txtDescripcionProyecto;
		protected System.Web.UI.WebControls.Label lblPorCobrar;
		protected System.Web.UI.WebControls.Label lblDbPorCobrar;
		protected System.Web.UI.WebControls.Label lblObservaciones;
		protected System.Web.UI.WebControls.TextBox txtObservaciones;

		
		#endregion Controles

		const string CONTROLIMGBUTTON = "imgContrato";
		const string IMAGENCONDOCUMENTO ="../imagenes/ley1.gif";
		const string IMAGENSINDOCUMENTO ="../imagenes/ley2.gif";

		#region Constantes

		const string COLORDENAMIENTO="NROPROYECTO";
		const string KEYQTIPOCONVENIO="TipoConvenio";
		const string KEYQIDPROYECTO = "IdProyecto";

		const string URLPRINCIPAL="ConsultarConvenioSimaMgpUnidadesApoyo.aspx";
		const string URLANTERIOR="ConsultarConvenioSimaMgpUnidadesApoyo.aspx?";
		
		const string URLTRABAJOS="ConsultarProgramaActividades.aspx?";
		const string URLFICHATECNICA="../Proyectos/ConsultarFichaTecnica.aspx?";

		private const string KEYCONVENIO= "Convenio";
		private const string KEYACTIVIDAD= "Actividad";

		// CONTROLES
		const string CONTROLINK = "hlkId";
		
		//Key Session y QueryString
		const string KEYIDCONVENIOSIMAMGP="IdConvenioSimaMgp";
		
		const string KEYIDPROYECTOCONVENIO="IdProyectoConvenio";
		const string KEYNROPROYECTO="NroProyecto";
		const string KEYQPROYECTODESCRIPCION="Descripcion";
		const string KEYQTITULOPRINCIPAL="TituloPrincipal";

		//URL
		const string URLVALORIZACIONORDENTRABAJOCONVENIO="ConsultarValorizacionesOrdenesTrabajoConvenioSimaMgp.aspx?";
		const string URLIMPRESION="";
		const string URLCRONOGRAMAPAGOSCONVENIOSIMAMGP="CronogramaPagosConvenioSimaMgp.aspx?";

		//GRILLA
		const string GRILLAVACIA="El Convenio no tiene Proyectos Asociados";

		#endregion Constantes

		#region Variable

		NullableDouble MontoRecibido=0;
		NullableDouble MontoPorCobrar=0;

		double acumMontoAsignado=0;
		double acumMontoAprobado=0;
		double acumMontoPagado =0;
		double acumMontoTerminado=0;
		double acumMontoEnEjecucion=0;
		double acumAvanceFisico=0;
		protected System.Web.UI.WebControls.Label lblTituloSecundatio;
		protected projDataGridWeb.DataGridWeb dgProyectoConvenioSimaMgp;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox txtObservacionesConvenio;
		protected System.Web.UI.WebControls.Label lblEstado;
		protected System.Web.UI.WebControls.TextBox txtEstado;
		protected System.Web.UI.WebControls.Label lblSituacionEconomica;
		protected System.Web.UI.WebControls.TextBox txtSituacionEconomica;
		protected System.Web.UI.WebControls.Label lblFechaVencimiento;
		protected System.Web.UI.WebControls.TextBox txtFechaVencimiento;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.TextBox txtCartaFianza;
		protected System.Web.UI.WebControls.TextBox txtMarco;
		protected System.Web.UI.WebControls.TextBox txtPagado;
		protected System.Web.UI.WebControls.TextBox txtEjecutado;
		static double acumMontoSaldo=0;						

		#endregion Variable
	
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


		private void LlenarControles()
		{
			CConvenioSimaMgp oCConvenioSimaMgp=new CConvenioSimaMgp();

			DataTable dtDatosConvenioSimaMgp=oCConvenioSimaMgp.ConsultarDatosDeUnConvenio(Convert.ToInt32(Page.Request.Params[KEYIDCONVENIOSIMAMGP]));

			oCConvenioSimaMgp.ConsultarMontoRecibidoMontoPorCobrarDeUnConvenio(Convert.ToInt32(Page.Request.Params[KEYIDCONVENIOSIMAMGP]),ref MontoRecibido,ref MontoPorCobrar);

			//lblTitulo.Text="CONVENIO " + Page.Request.QueryString[KEYQTIPOCONVENIO].ToString() + " " + dtDatosConvenioSimaMgp.Rows[0][Enumerados.ColumnasConvenioSimaMgp.NroConvenio.ToString()].ToString();			
			//lblTitulo.Text="CONVENIO COMOPERPAC " + dtDatosConvenioSimaMgp.Rows[0][Enumerados.ColumnasConvenioSimaMgp.NroConvenio.ToString()].ToString();
			lblTitulo.Text = dtDatosConvenioSimaMgp.Rows[0][Enumerados.ColumnasConvenioSimaMgp.NroConvenio.ToString()].ToString();

			if(!NullableString.Parse(dtDatosConvenioSimaMgp.Rows[0][Enumerados.ColumnasConvenioSimaMgp.Descripcion.ToString()].ToString()).IsNull)
			{ 
				txtDescripcion.Text=dtDatosConvenioSimaMgp.Rows[0][Enumerados.ColumnasConvenioSimaMgp.Descripcion.ToString()].ToString();
			}
			else
			{
				txtDescripcion.Text="";
			}

			
			if(!NullableString.Parse(dtDatosConvenioSimaMgp.Rows[0][Enumerados.ColumnasConvenioSimaMgp.Observaciones.ToString()].ToString()).IsNull)
			{ 
				txtObservacionesConvenio.Text = dtDatosConvenioSimaMgp.Rows[0][Enumerados.ColumnasConvenioSimaMgp.Observaciones.ToString()].ToString();
			}
			else
			{
				txtObservacionesConvenio.Text = "";
			}

			this.txtFechaVencimiento.Text=((DateTime)dtDatosConvenioSimaMgp.Rows[0][Enumerados.ColumnasConvenioSimaMgp.FechaVencimiento.ToString()]).ToString(Utilitario.Constantes.FORMATOFECHA4);

			this.txtEstado.Text=dtDatosConvenioSimaMgp.Rows[0][Utilitario.Enumerados.ColumnasConvenioSimaMgp.DescEstadoConvenio.ToString()].ToString();
			this.txtSituacionEconomica.Text=dtDatosConvenioSimaMgp.Rows[0][Utilitario.Enumerados.ColumnasConvenioSimaMgp.DescSituacionPagoConvenio.ToString()].ToString();
			
			this.txtCartaFianza.Text=Convert.ToDouble(dtDatosConvenioSimaMgp.Rows[0][Utilitario.Enumerados.ColumnasConvenioSimaMgp.MontoFianza.ToString()].ToString()).ToString(Utilitario.Constantes.FORMATODECIMAL4);

			if(MontoRecibido.IsNull)
			{
				lblDbRecibido.Text = "0.00";
			}
			else
			{
				lblDbRecibido.Text=MontoRecibido.Value.ToString(Utilitario.Constantes.FORMATODECIMAL4);
			}

			if(MontoPorCobrar.IsNull)
			{
				lblDbPorCobrar.Text="0.00";
			}
			else
			{
				lblDbPorCobrar.Text=MontoPorCobrar.Value.ToString(Utilitario.Constantes.FORMATODECIMAL4);
			}

			this.hlkRecibido.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE + Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.POPUPDEESPERA);
			this.hlkRecibido.NavigateUrl=URLCRONOGRAMAPAGOSCONVENIOSIMAMGP + KEYIDCONVENIOSIMAMGP + 
				Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt32(Page.Request.Params[KEYIDCONVENIOSIMAMGP]) + 
				Utilitario.Constantes.SIGNOAMPERSON + KEYQTITULOPRINCIPAL + Utilitario.Constantes.SIGNOIGUAL +
				this.lblTitulo.Text;

		}
		//		private void LlenarCuadroEstadistico()
		//		{
		//			CConvenioSimaMgp oCConvenioSimaMgp = new CConvenioSimaMgp();
		//			CFuncionesEspeciales oCFuncionesEspeciales=new CFuncionesEspeciales();
		//			ConvenioSimaMgpBE oConvenioSimaMgpBE=(ConvenioSimaMgpBE)
		//				oCConvenioSimaMgp.DetalleDeUnConvenioSimaMgp(Convert.ToInt32(Page.Request.Params[KEYIDCONVENIOSIMAMGP]));
		//			
		//			string parametros = String.Empty;
		//			string separador = "\\n";
		//			double montoConvenio = 0;
		//			double montoAprobado = 0;
		//			double avanceFisico = 0;
		//			double montoAutorizado = 0;
		//			double pagoXCuotas = 0;
		//			int mesActual = 0;
		//			int periodo = 0;
		//
		//			NullableDouble[] Montos;
		//			mesActual = DateTime.Now.Month;
		//			periodo = DateTime.Now.Year;
		//			string[] Columnas=new string[] {
		//											   Enumerados.ColumnasProgramaPagosConvenio.MontoProgramado.ToString(),
		//											   Enumerados.ColumnasProgramaPagosConvenio.MontoRecibido.ToString(),
		//											   Enumerados.ColumnasProgramaPagosConvenio.MontoPendiente.ToString()
		//										   };
		//			
		//			string titulo = "CONVENIO " + lblTitulo.Text;
		//			DataTable dtMontoConvenio = oCConvenioSimaMgp.ConsultarMontosXIdConvenio(Convert.ToInt32(Page.Request.Params[KEYIDCONVENIOSIMAMGP]));
		//			DataTable dtPagoProgramado = oCConvenioSimaMgp.ConsultarPagosYCronogramaDePagosDeUnConvenio(Convert.ToInt32(Page.Request.Params[KEYIDCONVENIOSIMAMGP]));
		//
		//			if(dtMontoConvenio != null)
		//			{
		//				montoConvenio = NullableIsNull.IsNullDouble(dtMontoConvenio.Rows[Utilitario.Constantes.ValorConstanteCero]
		//					[Enumerados.ColumnasConvenioSimaMgp.MontoAsignado.ToString()],0);
		//				montoAprobado =  NullableIsNull.IsNullDouble(dtMontoConvenio.Rows[Utilitario.Constantes.ValorConstanteCero]
		//					[Enumerados.ColumnasConvenioSimaMgp.MontoAprovado.ToString()],0);
		//				avanceFisico = NullableIsNull.IsNullDouble(dtMontoConvenio.Rows[Utilitario.Constantes.ValorConstanteCero]
		//					[Enumerados.ColumnasConvenioSimaMgp.AvanceFisico.ToString()],0);
		//				montoAutorizado = NullableIsNull.IsNullDouble(oConvenioSimaMgpBE.MontoAutorizado,0);
		//			}
		//			
		//			if(dtPagoProgramado != null)
		//			{
		//				DataView dwPagoProgramado = dtPagoProgramado.DefaultView;
		//
		//				dwPagoProgramado = FiltrarMeses(dwPagoProgramado,mesActual,periodo);
		//				
		//				Montos=oCFuncionesEspeciales.CalcularMontosTotalesDataFile(dwPagoProgramado,Columnas);
		//				pagoXCuotas = NullableIsNull.IsNullDouble(Montos[0],0);
		//			}
		//			parametros ="MONTO CONVENIO" + Utilitario.Constantes.SIGNOPUNTOYCOMA + montoConvenio.ToString(Utilitario.Constantes.FORMATODECIMAL4)+ separador +
		//				"MONTO APROBADO" + Utilitario.Constantes.SIGNOPUNTOYCOMA + montoAprobado.ToString(Utilitario.Constantes.FORMATODECIMAL4) + separador +
		//				"AVANCE FISICO" + Utilitario.Constantes.SIGNOPUNTOYCOMA + avanceFisico.ToString(Utilitario.Constantes.FORMATODECIMAL4) + separador +
		//				"MONTO AUTORIZADO" + Utilitario.Constantes.SIGNOPUNTOYCOMA + montoAutorizado.ToString(Utilitario.Constantes.FORMATODECIMAL4) + separador + 
		//				"MONTO PAGADO" + Utilitario.Constantes.SIGNOPUNTOYCOMA + MontoRecibido.Value.ToString(Utilitario.Constantes.FORMATODECIMAL4) + separador +
		//				"PAGO POR CUOTAS" + Utilitario.Constantes.SIGNOPUNTOYCOMA + pagoXCuotas.ToString(Utilitario.Constantes.FORMATODECIMAL4);
		//
		//			ibtnGraficoEstadistico.Attributes.Add(Utilitario.Constantes.EVENTOONMOUSEOVER,"javascript:this.style.cursor='hand';");
		//			ibtnGraficoEstadistico.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,"llenarGrafico('" +
		//			parametros + "','" + titulo + "');");
		//		}
		//		private DataView FiltrarMeses(DataView dwParam, int hastaMes, int periodo)
		//		{
		//			string mesNombre = String.Empty;
		//			
		//			for(int i = hastaMes + 1; i<=12; i++)
		//			{
		//				foreach(DataRowView dr in dwParam)
		//				{
		//					Utilitario.Enumerados.Meses enumMes = (Utilitario.Enumerados.Meses)
		//						Enum.ToObject(typeof(Utilitario.Enumerados.Meses), i);
		//					mesNombre = enumMes.ToString();
		//
		//					if(dr[2].ToString().Trim().StartsWith(periodo.ToString()) &&
		//						dr[2].ToString().Trim().EndsWith(mesNombre))
		//					{
		//						dr.Delete();
		//						return FiltrarMeses(dwParam, hastaMes,periodo);
		//					}
		//				}		
		//			}
		//			return dwParam;
		//		}
		#region IPagenaBase

		public void LlenarGrilla()
		{

		}
		

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
		{
			CConvenioSimaMgp oConvenioSimaMgp=new CConvenioSimaMgp();
			DataTable dtProyectoConvenio=oConvenioSimaMgp.ConsultarLosProyectosDeUnConvenio(Convert.ToInt32(Page.Request.Params[KEYIDCONVENIOSIMAMGP]));
			this.LimpiarControlesWeb();
			if(dtProyectoConvenio!=null)
			{
				DataView dwProyectoConvenio = dtProyectoConvenio.DefaultView;
				//dwProyectoConvenio.RowFilter=Helper.ObtenerFiltro();
				
				dwProyectoConvenio.Sort = columnaOrdenar ;
				dgProyectoConvenioSimaMgp.DataSource = dwProyectoConvenio;
				

				CImpresion oCImpresion = new CImpresion();
				oCImpresion.GuardarDataImprimirExportar(dtProyectoConvenio,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGOTITULOREPORTEACCIONCONTROLNOPROGRAMADA),columnaOrdenar,indicePagina);
				indicePagina=Helper.ValidarIndicePaginacionGrilla(dwProyectoConvenio.Count,this.dgProyectoConvenioSimaMgp.PageSize,indicePagina);
				lblResultado.Visible = false;
				dgProyectoConvenioSimaMgp.Columns[2].FooterText = dwProyectoConvenio.Count.ToString();
				

			}
			else
			{
				dgProyectoConvenioSimaMgp.DataSource = dtProyectoConvenio;
				lblResultado.Visible = true;
				lblResultado.Text = GRILLAVACIA;
			}
			try
			{
				dgProyectoConvenioSimaMgp.CurrentPageIndex=indicePagina;
				dgProyectoConvenioSimaMgp.DataBind();
			}
			catch	
			{
				dgProyectoConvenioSimaMgp.CurrentPageIndex = 0;
				dgProyectoConvenioSimaMgp.DataBind();
			}
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
		}		
		
		public void LlenarDatos()
		{
			//this.LlenarControles();

			//Region para COMOPERAMA
			/*if(Convert.ToInt32(Page.Request.QueryString["keyIdCOMOPERAMA"]) == 1)
			{
				lblTitulo.Text = "CONVENIO COMOPERAMA";
				lblRutaPagina.Text = "Inicio > Producción > Convenio COMOPERAMA >";
				lblPagina.Text = "PROYECTOS";
			}*/
		}

		public void Imprimir()
		{
			//ltlMensaje.Text = Helper.PopupImpresion(URLIMPRESION,650,700,false,false,false,true,true);
		}
				
		#endregion IPagenaBase
	
		private void Page_Load(object sender, System.EventArgs e)		
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();

					Helper.ReiniciarSession();
					this.LlenarControles();
					this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO,true),Utilitario.Constantes.INDICEPAGINADEFAULT);
					//					this.LlenarCuadroEstadistico();
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
			this.dgProyectoConvenioSimaMgp.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.dgProyectoConvenioSimaMgp_SortCommand);
			this.dgProyectoConvenioSimaMgp.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgProyectoConvenioSimaMgp_PageIndexChanged);
			this.dgProyectoConvenioSimaMgp.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgProyectoConvenioSimaMgp_ItemDataBound);
			this.dgProyectoConvenioSimaMgp.SelectedIndexChanged += new System.EventHandler(this.dgProyectoConvenioSimaMgp_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		

		private void ibtnImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Imprimir();
		}


		private void dgProyectoConvenioSimaMgp_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(e.SortExpression),Helper.ObtenerIndicePagina());
		}

		private void RedireccionarPaginaPrevia()
		{
			this.Page.Response.Redirect(URLPRINCIPAL);
		}

		private void dgProyectoConvenioSimaMgp_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			dgProyectoConvenioSimaMgp.CurrentPageIndex=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);
		}

		private void LimpiarControlesWeb()
		{
			this.txtDescripcionProyecto.Text="";
			this.txtObservaciones.Text="";
		}

		private void ibtnEliminaFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}

		private void ibtnFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			
			/*object[] campos={"MontoAsignado;ASIGNADO","MontoAprovado;APROBADO",
					"MontoEjecutado;EJECUTADO","MontoEnEjecucion;EN EJECUCION","MontoComprometido;COMPROMETIDO","MontoSaldo;SALDO","Descripcion;DESCRIPCION"};
			string CamposFiltro=Utilitario.Helper.ElaborarFiltro(campos);

			this.ltlMensaje.Text=CamposFiltro;*/
		}

		private void dgProyectoConvenioSimaMgp_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.Header)
			{
				acumMontoAsignado=0;
				acumMontoAprobado=0;
				acumMontoPagado =0;
				acumMontoTerminado=0;
				acumMontoEnEjecucion=0;
				acumAvanceFisico=0;
			}

			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				
				if(dr["IdProyectoConvenio"].ToString() == "145"  || dr["IdProyectoConvenio"].ToString() == "146")
				{
					e.Item.Cells[1].Text = "CF-" + Convert.ToString(dr[Enumerados.ColumnasProyectoConvenio.NroProyecto.ToString()]);
					
					if(dr["IdProyectoConvenio"].ToString() == "145")
					{
						e.Item.Cells[1].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.PopupMostrarArchivos(Helper.ObtenerRutaImagenes(Utilitario.Constantes.ProyectoRutaImagenServerProyectoEjecucionTerminado) + "CYP00018735.XLS"));
						e.Item.Cells[1].Font.Underline = true;
						e.Item.Cells[1].ForeColor = Color.Blue;
					}

				}
				else
					e.Item.Cells[1].Text = "A-" + Convert.ToString(dr[Enumerados.ColumnasProyectoConvenio.NroProyecto.ToString()]);
				

				//string Cadena="";
					
				//Cadena="MostrarDescripcionObservaciones('txtDescripcionProyecto','txtObservaciones','" + Helper.LimpiarTextoMantenerFormatoOriginal(Convert.ToString(dr[Enumerados.ColumnasProyectoConvenio.Descripcion.ToString()])) + "','" + Helper.LimpiarTextoMantenerFormatoOriginal(Convert.ToString(dr[Enumerados.ColumnasProyectoConvenio.Observaciones.ToString()])) +"');" ;
						
				Utilitario.Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				//Helper.FiltroporSeleccionConfiguraColumna(e,this.dgProyectoConvenioSimaMgp);

				System.Web.UI.WebControls.Image ibtn=(System.Web.UI.WebControls.Image)e.Item.Cells[10].FindControl(CONTROLIMGBUTTON);	
				if (Convert.ToString(dr[Enumerados.ColumnasProyectoConvenio.Archivo.ToString() ])!= String.Empty)
				{
					ibtn.ImageUrl = IMAGENCONDOCUMENTO;
					ibtn.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnClick.ToString(),
						Helper.AbrirArchivo(Helper.ObtenerRutaImagenes(Utilitario.Constantes.RUTASERVERIMAGENES) + 
						dr[Enumerados.ColumnasProyectoConvenio.Archivo.ToString()]));
				}
				else
				{
					ibtn.ImageUrl = IMAGENSINDOCUMENTO;
				}
				
				System.Web.UI.WebControls.Image ibtn1=(System.Web.UI.WebControls.Image)e.Item.Cells[11].FindControl("imgAct");	

				ibtn1.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
				ibtn1.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnClick.ToString(),
					Helper.MostrarVentana(URLTRABAJOS,Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Enumerados.ModoPagina.M.ToString() + Utilitario.Constantes.SIGNOAMPERSON + 
					KEYIDPROYECTOCONVENIO + Utilitario.Constantes.SIGNOIGUAL + dr[Utilitario.Enumerados.ColumnasProyectoConvenio.IdProyectoConvenio.ToString()].ToString() + Utilitario.Constantes.SIGNOAMPERSON +
					KEYCONVENIO + Utilitario.Constantes.SIGNOIGUAL + txtDescripcion.Text + Utilitario.Constantes.SIGNOAMPERSON +
					KEYACTIVIDAD + Utilitario.Constantes.SIGNOIGUAL + dr[Utilitario.Enumerados.ColumnasProyectoConvenio.Descripcion.ToString()].ToString()));		
				
				acumMontoAsignado += Convert.ToDouble(dr[Enumerados.ColumnasProyectoConvenio.MontoAsignado.ToString()]);
				acumMontoAprobado += Convert.ToDouble(dr[Enumerados.ColumnasProyectoConvenio.MontoAprobado.ToString()]);
				acumMontoPagado += Convert.ToDouble(dr[Enumerados.ColumnasProyectoConvenio.MontoPagado.ToString()]);
				acumMontoTerminado += Convert.ToDouble(dr[Enumerados.ColumnasProyectoConvenio.MontoEjecutado.ToString()]);
				acumMontoEnEjecucion += Convert.ToDouble(dr[Enumerados.ColumnasProyectoConvenio.MontoEnEjecucion.ToString()]);
				acumAvanceFisico += Convert.ToDouble(dr[Enumerados.ColumnasProyectoConvenio.AvanceFisico.ToString()]);

				if (dr[Utilitario.Enumerados.ColumnasProyectoConvenio.IdProyecto.ToString()].ToString() != System.DBNull.Value.ToString())
				{
					System.Web.UI.WebControls.Image ibtn2=(System.Web.UI.WebControls.Image)e.Item.Cells[12].FindControl("imgFicha");	
					ibtn2.Visible = true;
					ibtn2.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
					ibtn2.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnClick.ToString(),
						Helper.MostrarVentana(URLFICHATECNICA,Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Enumerados.ModoPagina.C.ToString() + Utilitario.Constantes.SIGNOAMPERSON + 
						KEYQIDPROYECTO + Utilitario.Constantes.SIGNOIGUAL + dr[Utilitario.Enumerados.ColumnasProyectoConvenio.IdProyecto.ToString()].ToString()));		
				}

			}	
			else if(e.Item.ItemType == ListItemType.Footer)
			{
				e.Item.Cells[3].Text = acumMontoAsignado.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[4].Text = acumMontoAprobado.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[5].Text = acumMontoPagado.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[6].Text = acumMontoTerminado.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[7].Text = acumMontoEnEjecucion.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[8].Text = acumAvanceFisico.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[9].Text = Convert.ToDouble(acumMontoAsignado - acumMontoAprobado).ToString(Utilitario.Constantes.FORMATODECIMAL4);

				txtMarco.Text = acumMontoAsignado.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				txtPagado.Text = acumMontoPagado.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				txtEjecutado.Text = acumAvanceFisico.ToString(Utilitario.Constantes.FORMATODECIMAL4);
			}
		}

		private void dgProyectoConvenioSimaMgp_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}

