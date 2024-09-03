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
using SIMA.EntidadesNegocio.GestionFinanciera;
using SIMA.Utilitario;
using NetAccessControl;
using SIMA.ManejadorExcepcion;
using SIMA.Log;


namespace SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancieros
{
	/// <summary>
	/// Summary description for DetalleReporteFormulaContable.
	/// </summary>
	public class DetalleReporteFormulaContable : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		#region Constante
		const string GRILLAVACIA="No exiets";
		const string KEYQIDFORMATO = "IdFormato";
		const string KEYQIDREPORTE = "IdReporte";
		const string KEYQIDRRUBRO = "IdRubro";
		const string KEYIDEMPRESA = "idEmp";
		const string KEYIDACUMULADO ="Acumulado";
		const string HLKCUENTACONTABLE = "hlkCuentaContable";
		const string URLDETALLE="DetalleReporteFormulaContable.aspx?";
		const string URLPRINCIPAL="ConsultaDeEstadosFinancieros.aspx";
		const string COLORDENAMIENTO = "CuentaContable";
		const string OBJPARAMETROCONTABLE="ParametroContable";
		
		const string KEYDIGCUENTACONTABLE = "Cuenta";
		const string  KEYQNRODIGITOSCABECERA ="NroDigCab";
		const string COLMONTOMES = "lbldelMes";
		const string COLMONTOACUM = "lblalMes";


		const string TABLACABECERA ="<TABLE WIDTH=100%>" +
								"<TR class=HeaderGrilla>" +
									"<TD ColSpan=2 style='BORDER-BOTTOM: #cccccc 1px solid'>" +
										"Titulo" +
									"</TD>" +
								"</TR>" +
								"<TR class=HeaderGrilla>" +
									"<TD WIDTH=50% align=Center>" +
										"DEBE" +
									"</TD>" +
									"<TD WIDTH=50% align=Center style='BORDER-LEFT: #cccccc 1px solid'>" +
										"HABER" +
									"</TD>" +
								"</TR>" +
							"</TABLE>";
		const string TABLADETALLE ="<TABLE border=0 cellSpacing=0 cellPadding=0 WIDTH=100% heigth =100%>" +
										"<TR class=TextoAzul>" +
											"<TD WIDTH=50% align=right valign=Middle style='BORDER-RIGHT: #cccccc 1px solid'>" +
												"DEBE" +
											"</TD>" +
											"<TD WIDTH=50% align=right valign=Middle>" +
												"HABER" +
											"</TD>" +
										"</TR>" +
									"</TABLE>";


		//Controles
		const string CTRLLNKNOMBRECTA ="hlkNombreCuenta";		
		const string CTRLETIQUETAHDELMES ="lblHdelMes";
		const string CTRLETIQUETAHALMES ="lblHalMes";

		#endregion

		#region Variables
			int KEYQNRODIGITOSDETALLE=0;
		#endregion

		#region Controles

		protected System.Web.UI.WebControls.Panel Panel;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.HtmlControls.HtmlTableCell lblConcepto;
		protected System.Web.UI.HtmlControls.HtmlTableCell lblMontoMes;
		protected System.Web.UI.HtmlControls.HtmlTableCell lblCuenta2Dig;
		protected System.Web.UI.HtmlControls.HtmlTableCell lblConcepto2Dig;
		protected System.Web.UI.HtmlControls.HtmlTableCell lblMontoMes2Dig;
		protected System.Web.UI.HtmlControls.HtmlTableCell lblMontoAcumulado2Dig;
		protected System.Web.UI.HtmlControls.HtmlTableCell lblCuenta3Dig;
		protected System.Web.UI.HtmlControls.HtmlTableCell lblConcepto3Dig;
		protected System.Web.UI.HtmlControls.HtmlTableCell lblMontoMes3Dig;
		protected System.Web.UI.HtmlControls.HtmlTableCell lblMontoAcumulado3Dig;
		protected System.Web.UI.HtmlControls.HtmlTableCell lblCuenta5Dig;
		protected System.Web.UI.HtmlControls.HtmlTableCell lblConcepto5Dig;
		protected System.Web.UI.HtmlControls.HtmlTableCell lblMontoMes5Dig;
		protected System.Web.UI.HtmlControls.HtmlTableCell lblMontoAcumulado5Dig;
		protected System.Web.UI.HtmlControls.HtmlTableRow row2Dig;
		protected System.Web.UI.HtmlControls.HtmlTableRow row3Dig;
		protected System.Web.UI.HtmlControls.HtmlTableRow row5Dig;
		protected System.Web.UI.HtmlControls.HtmlTable tblCabecera;
		protected System.Web.UI.HtmlControls.HtmlTableCell lblMontoAcumulado;
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarGrillaOrdenamientoPaginacion(Utilitario.Constantes.VACIO,Utilitario.Constantes.INDICEPAGINADEFAULT);
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
					string mensaje = oException.Message.ToString();
					SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
					Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
				}
			}
			// Put user code to initialize the page here
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
			this.grid.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemCreated);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add DetalleReporteFormulaContable.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetalleReporteFormulaContable.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			this.CargarModoConsulta();
			string DigCuenta = Page.Request.Params[KEYDIGCUENTACONTABLE].ToString();
			CEstadosFinancieros oCEstadosFinancieros = new  CEstadosFinancieros();
			ControlesUsuario.GestionFinanciera.ParametroContable usc_ParametroContable = (ControlesUsuario.GestionFinanciera.ParametroContable)Session[OBJPARAMETROCONTABLE + Page.Request.Params[KEYIDEMPRESA].ToString()];

			DataTable dtMovimientoEstadoFinanciero = new DataTable();
			if (Convert.ToInt32(Page.Request.Params[KEYQNRODIGITOSCABECERA]) == 5 )
			{
				dtMovimientoEstadoFinanciero = oCEstadosFinancieros.ConsultarMovimientoItemEstadosFinancieros(
																											Convert.ToInt32(usc_ParametroContable.IdCentroOperativo ),
																											Convert.ToInt32(usc_ParametroContable.Periodo),
																											Convert.ToInt32(usc_ParametroContable.Mes),
																											DigCuenta);

			}
			else
			{
					dtMovimientoEstadoFinanciero = oCEstadosFinancieros.ConsultarMovimientoEstadosFinancierosPorCentro
																													(Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO]),
																													Convert.ToInt32(Page.Request.Params[KEYQIDREPORTE]),
																													Convert.ToInt32(Page.Request.Params[KEYQIDRRUBRO]),
																													Convert.ToInt32(usc_ParametroContable.IdCentroOperativo),
																													Convert.ToInt32(usc_ParametroContable.Periodo),
																													Convert.ToInt32(usc_ParametroContable.Mes),
																													Convert.ToInt32(usc_ParametroContable.IdTipoInformacion),
																													KEYQNRODIGITOSDETALLE,
																													DigCuenta,
																													Convert.ToInt32(Page.Request.Params[KEYIDACUMULADO])
																													);
			}
			if(dtMovimientoEstadoFinanciero!=null)
			{
				DataView dwMovimientoEstadoFinanciero = dtMovimientoEstadoFinanciero.DefaultView;
				dwMovimientoEstadoFinanciero.Sort = columnaOrdenar ;
				grid.DataSource = dwMovimientoEstadoFinanciero;
				CImpresion oCImpresion = new CImpresion();
				oCImpresion.GuardarDataImprimirExportar(dtMovimientoEstadoFinanciero,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGOTITULOREPORTEACCIONCONTROLNOPROGRAMADA),columnaOrdenar,indicePagina);
				//ibtnImprimir.Visible = true;
				lblResultado.Visible = false;

			}
			else
			{
				grid.DataSource = dtMovimientoEstadoFinanciero;
				lblResultado.Visible = true;
				lblResultado.Text = GRILLAVACIA;
				//ibtnImprimir.Visible = false;
			}
			try
			{
				grid.DataBind();
			}
			catch	
			{
				grid.CurrentPageIndex = 0;
				grid.DataBind();
			}			
			// TODO:  Add DetalleReporteFormulaContable.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add DetalleReporteFormulaContable.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add DetalleReporteFormulaContable.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add DetalleReporteFormulaContable.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetalleReporteFormulaContable.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetalleReporteFormulaContable.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetalleReporteFormulaContable.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			if(CNetAccessControl.FindPage(Page.Request.Url.AbsolutePath.ToString()))
			{CNetAccessControl.LoadControls(this);}
			else
			{CNetAccessControl.RedirectPageError();}						
			// TODO:  Add DetalleReporteFormulaContable.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add DetalleReporteFormulaContable.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			// TODO:  Add DetalleReporteFormulaContable.Agregar implementation
		}

		public void Modificar()
		{
			// TODO:  Add DetalleReporteFormulaContable.Modificar implementation
		}

		public void Eliminar()
		{
			// TODO:  Add DetalleReporteFormulaContable.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			// TODO:  Add DetalleReporteFormulaContable.CargarModoPagina implementation
		}

		public void CargarModoNuevo()
		{
			// TODO:  Add DetalleReporteFormulaContable.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			// TODO:  Add DetalleReporteFormulaContable.CargarModoModificar implementation
		}

		public void CargarModoConsulta()
		{
			switch (Convert.ToInt32(Page.Request.Params[KEYQNRODIGITOSCABECERA]))
			{
				case 0:
					this.DetalledeRubro();
					KEYQNRODIGITOSDETALLE = 2;
					break;
				case 2:
					this.DetalledeRubro();
					this.DetalledeCuentaNDig(2);
					KEYQNRODIGITOSDETALLE = 3;
					break;
				case 3:
					this.DetalledeRubro();
					this.DetalledeCuentaNDig(2);
					this.DetalledeCuentaNDig(3);
					KEYQNRODIGITOSDETALLE = 5;
					break;
				case 5:
					this.DetalledeRubro();
					this.DetalledeCuentaNDig(2);
					this.DetalledeCuentaNDig(3);
					this.DetalledeCuentaNDig(5);
					//KEYQNRODIGITOSDETALLE = 5;
					break;
			}

			// TODO:  Add DetalleReporteFormulaContable.CargarModoConsulta implementation
		}
		private void DetalledeRubro()
		{
			CEstadosFinancieros oCEstadosFinancieros = new CEstadosFinancieros();
			ControlesUsuario.GestionFinanciera.ParametroContable usc_ParametroContable = (ControlesUsuario.GestionFinanciera.ParametroContable)Session[OBJPARAMETROCONTABLE + Page.Request.Params[KEYIDEMPRESA].ToString()];
			FormatoDetalleParametroBE oFormatoDetalleParametroBE  = (FormatoDetalleParametroBE)
				oCEstadosFinancieros.ListarDetalledeParametros( 
																Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO.ToString()]),
																Convert.ToInt32(Page.Request.Params[KEYQIDREPORTE.ToString()]),
																Convert.ToInt32(Page.Request.Params[KEYQIDRRUBRO.ToString()]),
																Convert.ToInt32(usc_ParametroContable.IdCentroOperativo),
																Convert.ToInt32(usc_ParametroContable.Periodo),
																Convert.ToInt32(usc_ParametroContable.Mes),
																Convert.ToInt32(usc_ParametroContable.IdTipoInformacion)
																);
			this.lblConcepto.InnerText= oFormatoDetalleParametroBE.NombreRubro.ToString();
			//this.lblNombreFormato.Text = "Consultar Detalle de " + oFormatoDetalleParametroBE.NombreReporte.ToString();

			this.lblMontoMes.InnerText= oFormatoDetalleParametroBE.MontoMes.ToString(Utilitario.Constantes.FORMATODECIMAL4);
			this.lblMontoAcumulado.InnerText= oFormatoDetalleParametroBE.MontoAcumulado.ToString(Utilitario.Constantes.FORMATODECIMAL4);

			this.OcultaFilaCabecera();
		}

		private void DetalledeCuentaNDig(int NroDigitos)
		{
			string DigCuentaCab = Page.Request.Params[KEYDIGCUENTACONTABLE].ToString().Substring(0,NroDigitos);
			CEstadosFinancieros oCEstadosFinancieros = new CEstadosFinancieros();
			ControlesUsuario.GestionFinanciera.ParametroContable usc_ParametroContable = (ControlesUsuario.GestionFinanciera.ParametroContable)Session[OBJPARAMETROCONTABLE + Page.Request.Params[KEYIDEMPRESA].ToString()];
			CuentaContableSaldoBE oCuentaContableSaldoBE  = (CuentaContableSaldoBE)
				oCEstadosFinancieros.DetalledeCuentaContable(
				Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO.ToString()]),
				Convert.ToInt32(Page.Request.Params[KEYQIDREPORTE.ToString()]),
				Convert.ToInt32(Page.Request.Params[KEYQIDRRUBRO.ToString()]),
				Convert.ToInt32(usc_ParametroContable.IdCentroOperativo),
				Convert.ToInt32(usc_ParametroContable.Periodo),
				Convert.ToInt32(usc_ParametroContable.Mes),
				Convert.ToInt32(usc_ParametroContable.IdTipoInformacion),
				NroDigitos,
				DigCuentaCab,
				Convert.ToInt32(Page.Request.Params[KEYIDACUMULADO])
				);
			switch (NroDigitos)
			{
				case 2:
					this.row2Dig.Visible = true;
					this.lblCuenta2Dig.InnerText = oCuentaContableSaldoBE.CuentaContable.ToString();
					this.lblConcepto2Dig.InnerText = oCuentaContableSaldoBE.NombreCuenta.ToString();
					this.lblMontoMes2Dig.InnerText  = oCuentaContableSaldoBE.MontoMes.ToString(Utilitario.Constantes.FORMATODECIMAL4);
					this.lblMontoAcumulado2Dig.InnerText  = oCuentaContableSaldoBE.MontoAcumulado.ToString(Utilitario.Constantes.FORMATODECIMAL4);
					break;
				case 3:
					this.row2Dig.Visible = true;
					this.row3Dig.Visible = true;
					this.lblCuenta3Dig.InnerText = oCuentaContableSaldoBE.CuentaContable.ToString();
					this.lblConcepto3Dig.InnerText = oCuentaContableSaldoBE.NombreCuenta.ToString();
					this.lblMontoMes3Dig.InnerText  = oCuentaContableSaldoBE.MontoMes.ToString(Utilitario.Constantes.FORMATODECIMAL4);
					this.lblMontoAcumulado3Dig.InnerText  = oCuentaContableSaldoBE.MontoAcumulado.ToString(Utilitario.Constantes.FORMATODECIMAL4);
					break;
				case 5:
					this.row2Dig.Visible = true;
					this.row3Dig.Visible = true;
					this.row5Dig.Visible = true;
					this.lblCuenta5Dig.InnerText = oCuentaContableSaldoBE.CuentaContable.ToString();
					this.lblConcepto5Dig.InnerText = oCuentaContableSaldoBE.NombreCuenta.ToString();
					this.lblMontoMes5Dig.InnerText  = oCuentaContableSaldoBE.MontoMes.ToString(Utilitario.Constantes.FORMATODECIMAL4);
					this.lblMontoAcumulado5Dig.InnerText  = oCuentaContableSaldoBE.MontoAcumulado.ToString(Utilitario.Constantes.FORMATODECIMAL4);
					break;

			}
		}
		private void OcultaFilaCabecera()
		{
			this.row2Dig.Visible = false;
			this.row3Dig.Visible = false;
			this.row5Dig.Visible = false;
		}


		public bool ValidarCampos()
		{
			// TODO:  Add DetalleReporteFormulaContable.ValidarCampos implementation
			return false;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add DetalleReporteFormulaContable.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add DetalleReporteFormulaContable.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{				
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				
				HyperLink hlkCuentaContable = (HyperLink)e.Item.Cells[0].FindControl(HLKCUENTACONTABLE);
				hlkCuentaContable.Text = Convert.ToString(dr[Enumerados.ColumnaMovimientoContableEF.Cuentacontable.ToString()]);

				HyperLink hlkNombre = (HyperLink)e.Item.Cells[1].FindControl(CTRLLNKNOMBRECTA);
				hlkNombre.Text = Convert.ToString(dr[Enumerados.ColumnaMovimientoContableEF.NombreCuenta.ToString()]);


				if (Convert.ToInt32(Page.Request.Params[KEYQNRODIGITOSCABECERA]) == 5 )
				{
					/*lblMonto= (Label)e.Item.Cells[2].FindControl(COLMONTOMES);
					lblMonto.Text = TABLADETALLE.ToString().Replace("DEBE",Convert.ToDouble(dr[Enumerados.FINColumnaCuentaContableSaldo.MontoMesDebe.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4))
														   .Replace("HABER",Convert.ToDouble(dr[Enumerados.FINColumnaCuentaContableSaldo.MontoMesHaber.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4));
					
					lblMonto= (Label)e.Item.Cells[2].FindControl(COLMONTOACUM);
					lblMonto.Text = TABLADETALLE.ToString().Replace("DEBE",Convert.ToDouble(dr[Enumerados.FINColumnaCuentaContableSaldo.MontoDebe.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4))
						.Replace("HABER",Convert.ToDouble(dr[Enumerados.FINColumnaCuentaContableSaldo.MontoHaber.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4));
						*/
				}
				else
				{
					System.Text.StringBuilder sbQDetalle = new System.Text.StringBuilder();
					sbQDetalle.Append(Page.Request.QueryString.ToString().Replace(KEYQNRODIGITOSCABECERA + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYQNRODIGITOSCABECERA],KEYQNRODIGITOSCABECERA + Utilitario.Constantes.SIGNOIGUAL + hlkCuentaContable.Text.ToString().Length)
						.Replace(KEYDIGCUENTACONTABLE + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYDIGCUENTACONTABLE],KEYDIGCUENTACONTABLE + Utilitario.Constantes.SIGNOIGUAL + hlkCuentaContable.Text));
					string PathUrl="window.location.href=" + Utilitario.Constantes.SIGNOCOMILLASIMPLE + URLDETALLE + sbQDetalle.ToString()+ Utilitario.Constantes.SIGNOCOMILLASIMPLE + Utilitario.Constantes.SIGNOPUNTOYCOMA;
					
					hlkCuentaContable.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
					hlkCuentaContable.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,PathUrl);
					hlkCuentaContable.Font.Underline = true;
					hlkCuentaContable.ForeColor = Color.Blue;
					
					e.Item.Cells[2].Text = Convert.ToDouble(e.Item.Cells[2].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);

					//hlkCuentaContable.NavigateUrl=URLDETALLE + sbQDetalle.ToString();
					

					/*lblMonto= (Label)e.Item.Cells[2].FindControl(COLMONTOMES);
					lblMonto.Text = Convert.ToDouble(dr[Enumerados.ColumnaMovimientoContableEF.MontoMes.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

					lblMonto= (Label)e.Item.Cells[2].FindControl(COLMONTOACUM);
					lblMonto.Text = Convert.ToDouble(dr[Enumerados.ColumnaMovimientoContableEF.MontoAcumulado.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
					*/
				}
			}
		
		}

		private void grid_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{

			if (Convert.ToInt32(Page.Request.Params[KEYQNRODIGITOSCABECERA]) == 5 )
			{
				if (e.Item.ItemType == ListItemType.Header)
				{
					Label lblCabecera = new Label();
					lblCabecera= (Label)e.Item.Cells[2].FindControl(CTRLETIQUETAHDELMES);
					lblCabecera.Text = TABLACABECERA.ToString().Replace("Titulo","DEL MES");
					
					lblCabecera= (Label)e.Item.Cells[2].FindControl(CTRLETIQUETAHALMES);
					lblCabecera.Text = TABLACABECERA.ToString().Replace("Titulo","AL MES");
				}
			}

		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			grid.CurrentPageIndex=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(e.SortExpression),Helper.ObtenerIndicePagina());
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
