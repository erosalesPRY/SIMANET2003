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
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using NullableTypes;
using MetaBuilders.WebControls;

namespace SIMA.SimaNetWeb.GestionFinanciera.CartasFianza
{
	/// <summary>
	/// Summary description for ConsultarCartaFianzaporBancoCentroMonto.
	/// </summary>
	public class ConsultarCartaFianzaporBancoCentroMonto : System.Web.UI.Page, IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label lblSituacion;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblEntidad;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminaFiltro;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected projDataGridWeb.DataGridWeb gridResumenMoneda;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.HtmlControls.HtmlTable TblTabs;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnFiltrarSeleccion;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPaginaSort;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion Controles

		#region Constantes
const string KEYIDBENEFICIARIO="KEYIDBENEFICIARIO";

		const string GRILLAVACIA ="No existe ningún Registro.";  
		const string CONTROLINK="hlkCentro";
		const string KEYIDENTIDADFINANCIERA = "idEF";
		const string KEYIDCENTRO = "idCentro";		
		const string NOMBREENTIDAD = "Nombre";
		const string TIPOFIANZA = "TFianza";
		const string KEYIDTIPOFZA = "TipoFza";
		/*parametros de detalle*/
		const string KEYIDDETCF = "idDetCF";
		const string KEYIDCARTAFZA = "idCartaFza";
		const string KEYIDPERIODO = "Periodo";
		const string KEYIDESTADO = "IdEstado";	

		/*TipoMoneda*/
		const string KEYQIDTIPOMONEDA = "IdTipoMoneda";
		const string TIPOSOLES = "1";
		const string TIPODOLARES = "2";

		/*Centros*/
		const string NOMBRECENTRO = "NombreCO";

		//Nuevo
		const string KEYESTADOFIANZAP = "EstadoFianzaP";
		const string KEYSUBESTADOFIANZAP = "SubEstadoFianzaP";
		const string KEYESTADOPROY = "EstProy";
		/****************************************************/

		const string URLDETALLE="DetalledeCartaFianza.aspx?";
		const string URLPRINCIPAL="ConsultarCartaFianzaporBanco.aspx";
		const string URLDETALLENOTACARGO="DetalleCargosPorFianza.aspx?";

		const string COLORDENAMIENTO = "NombreCentro";

		const string LBLNRORENOVACION = "lblNroRenov";
		const string LBLFECHAINICIO = "lblFechaIni";
		const string LBLFECHARENOVACION = "lblFechaRenov";
		const string LBLFECHAVENCIMIENTO = "lblFechaVence";		
		string ColorBorde = "";

		//Mensajes ToolTip Grilla
		const string TOOLTIPCENTROOPERACIONES ="Centro de Operaciones";
		const string TOOLTIPNROCARTAFIANZA ="Nro de Carta Fianza";
		const string TOOLTIPDIASFALTANTESVENC ="Nro de días Faltantes para su Vencimiento..";
		const string TOOLTIPMONEDA ="Moneda";

		const string COLUMANOBSERVACION ="observacion";
		const string COLUMNAIDESTADOFZA ="idEstadoFza";
		const string COLUMNAFLG = "FLG";

		//Filtro
		const string CENTROOPERATIVO ="NombreCentro";
		const string TIPOPROCEDENCIA ="TipoProcedencia";
		const string BENEFICIARIO = "Beneficiario";
		const string NOMPROYECTO = "NomProyecto";
		const string NROCARTAFIANZA ="nrocartafianza";
		const string MONEDA ="Moneda";
		const string MONTOCARTAFZA ="MontoFza";
		const string FECHAVENCIMIENTO ="fechavencimiento";
		const string ESTADOCARTAFZA = "EstadoCartaFianza";

		//Variables QueryString
		const string KEYQMOSTRARTODO = "MostrarTodo";
		const string VALORSI = "SI";
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Label lblCO;
		const string KEYQIDUSUARIO = "IdUsuario";
		#endregion	

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
			this.ibtnFiltrar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnFiltrar_Click);
			this.ibtnEliminaFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminaFiltro_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.gridResumenMoneda.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.gridResumenMoneda_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{					
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarJScript();
					this.LlenarDatos();
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Auditoria",this.ToString(),"Se consultó las Acciones Correctivas.",Enumerados.NivelesErrorLog.I.ToString()));
					Helper.SeleccionarItemCombos(this);
					//this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Convert.ToInt32(this.hGridPagina.Value));
					this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLUMNAFLG),Convert.ToInt32(this.hGridPagina.Value));
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
		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add ConsultarCartaFianzaporBancoCentroMonto.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarCartaFianzaporBancoCentroMonto.LlenarGrillaOrdenamiento implementation
		}

		private DataTable ObtenerDatos()
		{			
			string idBanco =((Page.Request.Params[KEYIDENTIDADFINANCIERA]==null)? Utilitario.Constantes.IDDEFAULT.ToString(): Page.Request.Params[KEYIDENTIDADFINANCIERA].ToString());
			int idCentro =((Page.Request.Params[KEYIDCENTRO]==null)? Utilitario.Constantes.IDDEFAULT: Convert.ToInt32(Page.Request.Params[KEYIDCENTRO]));
			int idMoneda =((Page.Request.Params[KEYQIDTIPOMONEDA]==null) ? Utilitario.Constantes.ValorConstanteUno: Convert.ToInt32(Page.Request.Params[KEYQIDTIPOMONEDA]));
			grid.Columns[2].Visible = (idBanco ==Utilitario.Constantes.IDDEFAULT.ToString());
			grid.Columns[1].Visible = (idCentro ==Utilitario.Constantes.IDDEFAULT);

			CCartaFianza oCCartaFianza =  new CCartaFianza();	


			if(Page.Request.QueryString[KEYIDBENEFICIARIO].ToString() == Utilitario.Constantes.VALORTODOS)
				return oCCartaFianza.ConsultarCartaFianzaPorBancoCentroMonto(idBanco,idCentro,idMoneda,Convert.ToInt32(Page.Request.Params[KEYIDTIPOFZA]),Convert.ToInt32(Page.Request.Params[KEYESTADOFIANZAP]),Convert.ToInt32(Page.Request.Params[KEYSUBESTADOFIANZAP]),Convert.ToInt32(Page.Request.Params[KEYESTADOPROY]));			
			else
			{
				int IdCodigo=0,IdOrigen =0,IdTablaOrigen=0;
			
				string delimStr = ",";
				char[] delimiter = delimStr.ToCharArray();
				string words = Page.Request.QueryString[KEYIDBENEFICIARIO].ToString();

				IdCodigo = Convert.ToInt32(words.Split(delimiter).GetValue(0).ToString());
				IdOrigen = Convert.ToInt32(words.Split(delimiter).GetValue(1).ToString());
				IdTablaOrigen = Convert.ToInt32(words.Split(delimiter).GetValue(2).ToString());

				return oCCartaFianza.ConsultarCartaFianzaPorBancoCentroMonto(idBanco,idCentro,idMoneda,Convert.ToInt32(Page.Request.Params[KEYIDTIPOFZA]),Convert.ToInt32(Page.Request.Params[KEYESTADOFIANZAP]),Convert.ToInt32( Page.Request.Params[KEYSUBESTADOFIANZAP]),Convert.ToInt32( Page.Request.Params[KEYESTADOPROY]) ,Page.Request.Params[KEYIDBENEFICIARIO].ToString());	
			}

								
					
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			this.grid.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(Utilitario.Helper.FooterSpan);
			DataTable dtGeneral;
			dtGeneral= this.ObtenerDatos();

			if(dtGeneral!=null)
			{
				DataView dwGeneral = dtGeneral.DefaultView;
				dwGeneral.Sort = columnaOrdenar;
				dwGeneral.RowFilter = Helper.ObtenerFiltro();
				this.GenerarResumenMoneda(dwGeneral);
				grid.Columns[Utilitario.Constantes.POSICIONFOOTERTOTAL].FooterText = Utilitario.Constantes.TEXTOFOOTERTOTAL + dwGeneral.Count.ToString();
				grid.DataSource = dwGeneral;
				grid.CurrentPageIndex = indicePagina;
				CImpresion oCImpresion = new CImpresion();
				oCImpresion.GuardarDataImprimirExportar(dtGeneral,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGOTITULOREPORTEACCIONCONTROLNOPROGRAMADA),columnaOrdenar,indicePagina);
				lblResultado.Visible = false;
			}
			else
			{
				grid.DataSource = dtGeneral;
				lblResultado.Visible = true;
				lblResultado.Text = GRILLAVACIA;
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
		}

		public void LlenarCombos()
		{
			// TODO:  Add ConsultarCartaFianzaporBancoCentroMonto.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			this.lblSituacion.Text = Page.Request.Params[TIPOFIANZA].ToString();
			this.lblEntidad.Text = Page.Request.Params[NOMBREENTIDAD].ToString();
			this.lblCO.Text = Page.Request.Params[NOMBRECENTRO].ToString();
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarCartaFianzaporBancoCentroMonto.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarCartaFianzaporBancoCentroMonto.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarCartaFianzaporBancoCentroMonto.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarCartaFianzaporBancoCentroMonto.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			if(CNetAccessControl.FindPage(Page.Request.Url.AbsolutePath.ToString()))
			{CNetAccessControl.LoadControls(this);}
			else
			{CNetAccessControl.RedirectPageError();}
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ConsultarCartaFianzaporBancoCentroMonto.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.Header)
			{
				e.Item.Cells[1].ToolTip=TOOLTIPCENTROOPERACIONES;
				e.Item.Cells[4].ToolTip=TOOLTIPNROCARTAFIANZA;
				e.Item.Cells[6].ToolTip=TOOLTIPDIASFALTANTESVENC;
				e.Item.Cells[7].ToolTip=TOOLTIPMONEDA;
				//Evaluo si Oculto Cabecera de Dias
				if(Page.Request.Params[KEYQMOSTRARTODO] == null)
				{
					e.Item.Cells[6].Visible =true;
				}
				else
				{
					if(Page.Request.Params[KEYQMOSTRARTODO] == VALORSI)
					{
						e.Item.Cells[6].Visible =false;
					}
					else
					{
						e.Item.Cells[6].Visible =true;
					}
				}	
			}

			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				Helper.ConfiguraColumnaHyperLink(e.Item.Cells[0],grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex,
					Helper.HistorialIrAdelantePersonalizado(this.hGridPagina.ID.ToString(),"hGridPaginaSort"),
					Helper.MostrarVentana(URLDETALLE,KEYIDCARTAFZA.ToString() + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr[Enumerados.ColumnaCartaFianza.idCartaFianza.ToString()]) 
					+ Utilitario.Constantes.SIGNOAMPERSON  
					+ KEYIDPERIODO  +  Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr[Enumerados.ColumnaCartaFianza.Periodo.ToString()])
					+ Utilitario.Constantes.SIGNOAMPERSON  
					+ KEYIDDETCF + Utilitario.Constantes.SIGNOIGUAL + Convert.ToString(dr[Enumerados.ColumnaCartaFianza.idDetCF.ToString()])
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.C.ToString()));
				
				Label lbl;
				lbl = (Label)e.Item.Cells[5].FindControl(LBLNRORENOVACION);
				lbl.Text = dr[Enumerados.FinColumnaCartaFianzaporBanco.NroRenovacion.ToString()].ToString();
				lbl = (Label)e.Item.Cells[5].FindControl(LBLFECHAINICIO);
				lbl.Text = dr[Enumerados.FinColumnaCartaFianzaporBanco.FechaInicio.ToString()].ToString();
				lbl = (Label)e.Item.Cells[5].FindControl(LBLFECHARENOVACION);
				lbl.Text = dr[Enumerados.FinColumnaCartaFianzaporBanco.fechaRenovacion.ToString()].ToString();
				lbl = (Label)e.Item.Cells[5].FindControl(LBLFECHAVENCIMIENTO);
				lbl.Text = dr[Enumerados.FinColumnaCartaFianzaporBanco.fechavencimiento.ToString()].ToString();

				if (Convert.ToInt32(e.Item.Cells[6].Text) <= 5)
				{
					ColorBorde=Utilitario.Constantes.INDICADORAMBAR;
					e.Item.Cells[6].ForeColor = Color.Red;
				}
				e.Item.Cells[6].Font.Underline = true;
				e.Item.Cells[6].Style.Add(Utilitario.Constantes.CURSOR,Utilitario.Constantes.TIPOCURSORMANO);

				if(Convert.ToInt32(dr[COLUMNAIDESTADOFZA].ToString()) == 8)
				{
					e.Item.Cells[9].ForeColor = Color.Red;
				}

				//Evaluo si Oculto fila Dias
				if(Page.Request.Params[KEYQMOSTRARTODO] == null)
				{
					e.Item.Cells[6].Visible =true;
				}
				else
				{
					if(Page.Request.Params[KEYQMOSTRARTODO] == VALORSI)
					{
						e.Item.Cells[6].Visible =false;
					}
					else
					{
						e.Item.Cells[6].Visible =true;
					}
				}				

				string strPopup= Helper.MostrarVentanaDialogo(URLDETALLENOTACARGO+KEYIDPERIODO + Utilitario.Constantes.SIGNOIGUAL + dr[Enumerados.ColumnaCartaFianza.Periodo.ToString()].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYIDCARTAFZA + Utilitario.Constantes.SIGNOIGUAL + dr[Enumerados.ColumnaCartaFianza.idCartaFianza.ToString()].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYIDDETCF + Utilitario.Constantes.SIGNOIGUAL + dr[Enumerados.ColumnaCartaFianza.idDetCF.ToString()].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ Utilitario.Constantes.KEYMODOPAGINA +  Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.C.ToString(),550,425);


				//e.Item.Cells[6].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,strPopup);
				Helper.ConfiguraColumnaHyperLink(Utilitario.Enumerados.EventosJavaScript.OnClick,e.Item.Cells[6],strPopup);


				//e.Item.Cells[6].Text = Utilitario.Constantes.TABLASTYLE.Replace("NOTAVALOR",e.Item.Cells[6].Text).Replace("MIBORDE",Utilitario.Constantes.BORDESTYLE).Replace("[ANCHO]",AnchoBorde.ToString()).Replace("[COLORBORDE]",ColorBorde).Replace("[EVENTO]",strPopup);

	


				e.Item.Cells[8].Text = Convert.ToDouble(e.Item.Cells[8].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);

				#region Helpers
				//Helper.SeleccionarItemGrillaOnClickMoverRaton(e,Helper.MostrarDatosEnCajaTexto("txtDescripcion",dr[COLUMANOBSERVACION].ToString()));
				Helper.FiltroporSeleccionConfiguraColumna(e,grid);
				#endregion
			}			
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.hGridPagina.Value=e.NewPageIndex.ToString();
			grid.CurrentPageIndex=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);	
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			hGridPaginaSort.Value=Helper.GenerarExpresionOrdenamiento(e.SortExpression);
			this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Helper.ObtenerIndicePagina());
		}

		private void ibtnFiltrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			DataTable dtGeneral;
			dtGeneral= this.ObtenerDatos();
			ltlMensaje.Text= Utilitario.Helper.ElaborarFiltro(dtGeneral
				,Utilitario.Constantes.SIGNOASTERISCO + CENTROOPERATIVO + ";Centro Operativo"
				,BENEFICIARIO
				,NROCARTAFIANZA + ";Nro de Carta Fianza"
				,Utilitario.Constantes.SIGNOASTERISCO + MONEDA + ";Moneda"
				,MONTOCARTAFZA + ";Monto de la Carta Fianza"
				,FECHAVENCIMIENTO + ";Fecha de Vencimiento"
				,Utilitario.Constantes.SIGNOASTERISCO + ESTADOCARTAFZA + ";Estado Carta Fianza");
		}

		private void ibtnEliminaFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}

		private void GenerarResumenMoneda(DataView dv)
		{
			int NroResumen = 16;
			CResumenItem oCResumenItem = new CResumenItem();
			DataTable dtFinal= Helper.Resumen(oCResumenItem.ObtenerConfiDataResumen(NroResumen),dv);
			gridResumenMoneda.DataSource =dtFinal;
			gridResumenMoneda.DataBind();
		}

		private void gridResumenMoneda_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				e.Item.Cells[1].Text = Convert.ToDouble(e.Item.Cells[1].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
			}
		}
	}
}
