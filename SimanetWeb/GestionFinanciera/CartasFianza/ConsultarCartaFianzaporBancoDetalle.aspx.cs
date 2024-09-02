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
	/// Summary description for ConsultarCartaFianzaporBancoDetalle.
	/// </summary>
	public class ConsultarCartaFianzaporBancoDetalle : System.Web.UI.Page,IPaginaBase
	{
		#region Constantes
		//QueryString Adicional
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
		const string KEYQIDUSUARIO = "IdUsuario";
		#endregion

		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminaFiltro;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnFiltrarSeleccion;
		protected projDataGridWeb.DataGridWeb grid;
		protected projDataGridWeb.DataGridWeb gridResumenMoneda;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPaginaSort;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.Label lblEntidad;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblSituacion;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.HtmlControls.HtmlTable TblTabs;
		protected System.Web.UI.WebControls.DataGrid gridBitacora;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion


		private int [] Aleatorio;
		protected System.Web.UI.WebControls.Button btnMostrarBitacora;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hPeriodo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdCartaFianza;
		protected System.Web.UI.WebControls.TextBox txtDescripcionFZA;
		private int idx=0;

		private void Page_Load(object sender, System.EventArgs e)
		{
			Aleatorio=CalcularNumeros();
			if(!Page.IsPostBack)
			{
				try
				{
					//Registrar Evento
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
			this.ibtnFiltrar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnFiltrar_Click);
			this.ibtnEliminaFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminaFiltro_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.gridResumenMoneda.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.gridResumenMoneda_ItemDataBound);
			this.gridBitacora.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.gridBitacora_ItemDataBound);
			this.btnMostrarBitacora.Click += new System.EventHandler(this.btnMostrarBitacora_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add ConsultarCartaFianzaporBancoDetalle.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarCartaFianzaporBancoDetalle.LlenarGrillaOrdenamiento implementation
		}
		private DataTable ObtenerDatos()
		{
			string idBanco =((Page.Request.Params[KEYIDENTIDADFINANCIERA]==null)? Utilitario.Constantes.IDDEFAULT.ToString(): Page.Request.Params[KEYIDENTIDADFINANCIERA].ToString());
			int idCentro =((Page.Request.Params[KEYIDCENTRO]==null)? Utilitario.Constantes.IDDEFAULT: Convert.ToInt32(Page.Request.Params[KEYIDCENTRO]));
			grid.Columns[2].Visible = (idBanco ==Utilitario.Constantes.IDDEFAULT.ToString());
			grid.Columns[1].Visible = (idCentro ==Utilitario.Constantes.IDDEFAULT);
				
			
			CCartaFianza oCCartaFianza =  new CCartaFianza();			
			if((Page.Request.QueryString[KEYIDBENEFICIARIO]!=null)&&(Page.Request.QueryString[KEYIDBENEFICIARIO].ToString() == Utilitario.Constantes.VALORTODOS))
				return oCCartaFianza.ConsultarCartaFianzaPorBancoDetalle2(idBanco,idCentro,Convert.ToInt32(Page.Request.Params[KEYIDTIPOFZA]), Convert.ToInt32(Page.Request.Params[KEYESTADOFIANZAP]), Convert.ToInt32(Page.Request.Params[KEYSUBESTADOFIANZAP]), Convert.ToInt32(Page.Request.Params[KEYESTADOPROY]));
			else
			{
				return oCCartaFianza.ConsultarCartaFianzaPorBancoDetalle2(Page.Request.Params[KEYIDENTIDADFINANCIERA].ToString(),Convert.ToInt32(Page.Request.Params[KEYIDCENTRO]),Convert.ToInt32(Page.Request.Params[KEYIDTIPOFZA]), Convert.ToInt32(Page.Request.Params[KEYESTADOFIANZAP]) , Convert.ToInt32(Page.Request.Params[KEYSUBESTADOFIANZAP]), Convert.ToInt32(Page.Request.Params[KEYESTADOPROY]),Page.Request.Params[KEYIDBENEFICIARIO]);
			}
			if((Page.Request.QueryString[KEYIDBENEFICIARIO]!=null)&&(Page.Request.QueryString[KEYIDBENEFICIARIO].ToString() == Utilitario.Constantes.VALORTODOS))
				
				return CargarDatosCF(Utilitario.Constantes.VALORTODOS,idBanco,idCentro,Convert.ToInt32(Page.Request.Params[KEYIDTIPOFZA]), Convert.ToInt32(Page.Request.Params[KEYESTADOFIANZAP]), Convert.ToInt32(Page.Request.Params[KEYSUBESTADOFIANZAP]), Convert.ToInt32(Page.Request.Params[KEYESTADOPROY]));
			else
			{
				return CargarDatosCF(Page.Request.QueryString[KEYIDBENEFICIARIO].ToString(),idBanco,idCentro,Convert.ToInt32(Page.Request.Params[KEYIDTIPOFZA]), Convert.ToInt32(Page.Request.Params[KEYESTADOFIANZAP]), Convert.ToInt32(Page.Request.Params[KEYSUBESTADOFIANZAP]), Convert.ToInt32(Page.Request.Params[KEYESTADOPROY]));
			}
			
		}
			
		public DataTable CargarDatosCF(string IdBeneficiario,string idBanco,int idCentro,int IdTipoFZA,int EstadoFianzaP,int SubEstadoFianzaP,int EstadoProy){
			CCartaFianza oCCartaFianza =  new CCartaFianza();
			if(IdBeneficiario == Utilitario.Constantes.VALORTODOS)
				return oCCartaFianza.ConsultarCartaFianzaPorBancoDetalle2(idBanco,idCentro,IdTipoFZA, EstadoFianzaP, SubEstadoFianzaP, EstadoProy);
			else
			{
				return oCCartaFianza.ConsultarCartaFianzaPorBancoDetalle2(idBanco,idCentro,IdTipoFZA, EstadoFianzaP, SubEstadoFianzaP, EstadoProy, IdBeneficiario);
			}
		}
		
		private void CargarBitacoraPorFianza()
		{
			gridBitacora.DataSource= (new CCartaFianzaBitacora()).ConsultarBitacoraPorFianza(Convert.ToInt32(this.hPeriodo.Value),Convert.ToInt32(this.hIdCartaFianza.Value),1);
			gridBitacora.DataBind();
		}
		
		
		private DataTable ObtenerDatos2()
		{
			string idBanco =((Page.Request.Params[KEYIDENTIDADFINANCIERA]==null)? Utilitario.Constantes.IDDEFAULT.ToString(): Page.Request.Params[KEYIDENTIDADFINANCIERA].ToString());
			int idCentro =((Page.Request.Params[KEYIDCENTRO]==null)? Utilitario.Constantes.IDDEFAULT: Convert.ToInt32(Page.Request.Params[KEYIDCENTRO]));
			grid.Columns[2].Visible = (idBanco ==Utilitario.Constantes.IDDEFAULT.ToString());
			grid.Columns[1].Visible = (idCentro ==Utilitario.Constantes.IDDEFAULT);
			
			CCartaFianza oCCartaFianza =  new CCartaFianza();			
			return oCCartaFianza.ConsultarCartaFianzaPorBancoDetalleTodos(idBanco,idCentro,Convert.ToInt32(Page.Request.Params[KEYIDTIPOFZA].ToString()));
		}
		
		private void GenerarResumenMoneda(DataView dv)
		{
			int NroResumen = 16;
			CResumenItem oCResumenItem = new CResumenItem();
			DataTable dtFinal= Helper.Resumen(oCResumenItem.ObtenerConfiDataResumen(NroResumen),dv);
			gridResumenMoneda.DataSource =dtFinal;
			gridResumenMoneda.DataBind();
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
			// TODO:  Add ConsultarCartaFianzaporBancoDetalle.LlenarGrillaOrdenamientoPaginacion implementation
		}
		public void LlenarCombos()
		{
			// TODO:  Add ConsultarCartaFianzaporBancoDetalle.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			this.lblSituacion.Text = Page.Request.Params[TIPOFIANZA].ToString();
			this.lblEntidad.Text = Page.Request.Params[NOMBREENTIDAD].ToString();			
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarCartaFianzaporBancoDetalle.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarCartaFianzaporBancoDetalle.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarCartaFianzaporBancoDetalle.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarCartaFianzaporBancoDetalle.Exportar implementation
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
			// TODO:  Add ConsultarCartaFianzaporBancoDetalle.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{

				if(e.Item.ItemType == ListItemType.Header)
				{
				
					e.Item.Cells[3].Text=((Page.Request.Params[KEYIDTIPOFZA].ToString().Equals("0"))?"BENEFICIARIO":"PROVEEDOR/CONTRATISTA");
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
					e.Item.Cells[11].Text = Convert.ToDouble(e.Item.Cells[11].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);

					#region Helpers
					//Helper.SeleccionarItemGrillaOnClickMoverRaton(e,Helper.MostrarDatosEnCajaTexto("txtDescripcionFZA",dr[COLUMANOBSERVACION].ToString()));
					Helper.FiltroporSeleccionConfiguraColumna(e,grid);
					
					
					string fncJS="CargaBitacora('" +  dr[Enumerados.ColumnaCartaFianza.Periodo.ToString()] + "','" +  dr[Enumerados.ColumnaCartaFianza.idCartaFianza.ToString()] + "')";
					e.Item.Cells[1].Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnClick.ToString(),fncJS);

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
			if(Page.Request[KEYQMOSTRARTODO]== null)
			{
				dtGeneral= this.ObtenerDatos();
			}
			else	//Viene por session de directorio
			{
				//Mostrar Todo
				if(Page.Request[KEYQMOSTRARTODO].ToString() == VALORSI)
				{
					dtGeneral = this.ObtenerDatos2();
				}
				else
				{
					dtGeneral= this.ObtenerDatos();
				}				
			}
		

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

		private void gridResumenMoneda_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				e.Item.Cells[1].Text = Convert.ToDouble(e.Item.Cells[1].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
			}
		}

		private int[] CalcularNumeros()
		{
			int[] numeros = new int[50];
			Random r = new Random();

			int auxiliar = 0;
			int contador = 0;

			for (int i = 0; i < 25; i++)
			{
				auxiliar = r.Next(1, 75);
				bool continuar = false;

				while (!continuar)
				{
					for (int j = 0; j <= contador; j++)
					{
						if (auxiliar == numeros[j])
						{
							continuar = true;
							j = contador;
						}
					}

					if (continuar)
					{
						auxiliar = r.Next(1, 75);
						continuar = false;
					}
					else
					{
						continuar = true;
						numeros[contador] = auxiliar;
						contador++;
					}                    
				}
			}

			return numeros;
		}


		private void gridBitacora_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				TextBox tb = (TextBox) e.Item.Cells[0].FindControl("txtFecha");
				tb.Text = ((dr["Fecha"].ToString().Length==0)?"":Convert.ToDateTime(dr["Fecha"].ToString()).ToShortDateString());
				tb.ID = "txtFecha" + Aleatorio[idx].ToString();
				idx++;
				tb = (TextBox) e.Item.Cells[1].FindControl("txtDescripcion");
				tb.Text =dr["Descripcion"].ToString();
				e.Item.Attributes["NMODO"]=dr["IdReg"].ToString();
				e.Item.Attributes["IDBITACORA"]=dr["IdBitacora"].ToString();
				e.Item.Attributes["FECHA"]=((dr["Fecha"].ToString().Length==0)?"":Convert.ToDateTime(dr["Fecha"].ToString()).ToShortDateString());
				e.Item.Attributes["DESCRIPCION"]=dr["Descripcion"].ToString();
				

				HtmlImage oimgElimina = (HtmlImage)e.Item.Cells[2].FindControl("imgEliminaBitacora");
				oimgElimina.Style["display"]=((dr["Fecha"].ToString().Length==0)?"none":"block");
			}

		}

		private void btnMostrarBitacora_Click(object sender, System.EventArgs e)
		{
			this.CargarBitacoraPorFianza();
		}
	}
}
