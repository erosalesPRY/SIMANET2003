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
using System.IO;

namespace SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancieros
{
	public class ConsultaDeEstadosFinancieros : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		#region Variables
			string stridFila ="";
			int idFila=1;
			string RutaArchivosXLS = Helper.ObtenerRutaArchivosExcel(Utilitario.Constantes.EstadosFinancierosRutaCarpetaGuardarArchivoXLS);
		#endregion
		#region Constantes
			//Key Session y QueryString
			const string NODOSELECCIONADO="NodoSeleccionado";
			const string KEYQIDNOMBREFORMATO = "NFormato";
			const string KEYQIDFORMATO = "IdFormato";
			const string KEYQIDREPORTE = "IdReporte";
			const string KEYQIDCENTRO = "IdCentro";
			const string KEYQIDRUBRO = "IdRubro";
			const string KEYQRUBRONOMBRE= "RubroNombre";
			const string KEYQIDTIPOINFO= "idTipoInfo";
			const string KEYQPERIODO = "Periodo";
			const string KEYQMES = "idMes";
		
			const string CONTROLINK = "hlkConcepto";
			const string COLMONTOMES = "lbldelMes";
			const string COLMONTOACUM = "lblalMes";

			const string CONTROLIMAGE = "imgBtnDetalle";
		
			const string GRILLAVACIA="No exiets";
			const string OBJPARAMETROCONTABLE="ParametroContable";			
			
			const string  KEYQNRODIGITOSCABECERA ="NroDigCab";
			const string KEYDIGCUENTACONTABLE = "Cuenta";
			const string KEYIDEMPRESA ="idEmp";
			const string KEYIDACUMULADO ="Acumulado";
			const string KEYPRCFORMATO ="PrcFMT";
			const string KEYCTRLCIERRE ="CtrlCierre";
			const string KEYQREQCTATABLE="ReqCta";

			const string KEYQNROCENTROOPERATIVO = "nroCentroOperativo";
			
			
			const string CTRLMONTO1 = "nMonto";
			
			
			string JSVERIFICARPROCESO = "return verificarEliminarRb('hCodigo','Seleccinar Parametros','Desea procesar este formato ahora');";			

		//Variables de Session
		const string VARIABLESESSIONCIERRE ="Cierre";

		//Paginas		
		const string URLDETALLE = "DetalleReporteFormulaContable.aspx?";
		const string URLDETALLE1 = "AdministrarFormulaFinanciera.aspx?";			
		const string URLBUSCARNOTACONTABLE = "../../General/Formato/AdministrarRelacionFormatoRubroNotaContab.aspx?";
		const string URLDETALLE2 = "AdministarFormatoRubroDetalleMovimientoporMes.aspx?";
		const string URLDETALLENOTARUBRO = "../../Editor/Editor.aspx?";
		const string URLDESCRIPCIONPERU ="ConsultaDeEstadosFinancierosPERU.aspx";
		const string URLGLOSA = "GlosaEstadosFinancieros.aspx?";
		//Otros
		const string ETIQUETAESTADOSFINANCIEROS =" Estados Financieros > ";

		//Columnas Grilla
		const string COLUMNACONCEPTO ="Concepto";
		const string COLUMNAMONTOMES ="montoMes";
		const string COLUMNAOBSERVACION ="Observacion";
		int periodo=0;
		//Controles
		const string CONTROLIMGFORMULA ="imgFormula";
		const string CONTROLIMGBTNDESCRIPCION ="imgBtnDescripcion";


		private bool FormatoProcesar
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYPRCFORMATO])==1;}
		}
		private bool CtrlCierre
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYCTRLCIERRE])==1;}
		}

		private int RequiereCtaContable
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQREQCTATABLE]);}
			
		}
		#endregion
		#region Constroles Web

			protected projDataGridWeb.DataGridWeb grid;
			protected System.Web.UI.WebControls.Literal ltlMensaje;
			protected System.Web.UI.WebControls.Label lblResultado;
			protected System.Web.UI.WebControls.ImageButton imgbtnGrabar;
			protected System.Web.UI.HtmlControls.HtmlInputHidden hTramaData;
			protected System.Web.UI.WebControls.ImageButton imgProcesar;
			protected System.Web.UI.HtmlControls.HtmlInputHidden hModo;
			protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
			protected System.Web.UI.HtmlControls.HtmlInputHidden hvalida;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hTiempoHabilitado;
		protected System.Web.UI.HtmlControls.HtmlInputFile filMyFileDocumento;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.HtmlControls.HtmlTableCell LstUser;
			protected System.Web.UI.HtmlControls.HtmlInputHidden hIdRubro;
		#endregion
		private void Page_Load(object sender, System.EventArgs e)
		{
		//		this.CargarControl();
				try
				{
					if(!Page.IsPostBack)
					{
						this.ConfigurarAccesoControles();
						Helper.ReiniciarSession();
						this.LlenarJScript();
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
					ltlMensaje.Text = Helper.MensajeAlert(oSIMAExcepcionDominio.Mensaje);					
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
			this.imgProcesar.Click += new System.Web.UI.ImageClickEventHandler(this.imgProcesar_Click);
			this.imgbtnGrabar.Click += new System.Web.UI.ImageClickEventHandler(this.imgbtnGrabar_Click);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			ControlesUsuario.GestionFinanciera.ParametroContable usc_ParametroContable =(ControlesUsuario.GestionFinanciera.ParametroContable)Session[OBJPARAMETROCONTABLE + Page.Request.Params[KEYIDEMPRESA].ToString()];
			
			if (usc_ParametroContable.CantidadPeriodo>0)
			{periodo = Convert.ToInt32(usc_ParametroContable.Periodo);}
			else
			{periodo = DateTime.Now.Year;}

			/*Ocul el Boton de Proceso para los tipos de informacion Proyectada y Presupuestada*/
			//this.imgProcesar.Visible = (Convert.ToInt32(usc_ParametroContable.IdTipoInformacion) !=0)? false:true;

			CEstadosFinancieros oCEstadosFinancieros = new  CEstadosFinancieros();
			DataTable dtEstadoFinanciero = oCEstadosFinancieros.ConsultarEstadosFinancierosPorCentro(Convert.ToInt32(Page.Request.QueryString[KEYQIDFORMATO]),
																										Convert.ToInt32(Page.Request.QueryString[KEYQIDREPORTE]),
																										Convert.ToInt32(usc_ParametroContable.IdCentroOperativo),
																										periodo,
																										Convert.ToInt32(usc_ParametroContable.Mes),
																										Convert.ToInt32(usc_ParametroContable.IdTipoInformacion));
			
			//Session[VARIABLESESSIONCIERRE]=((ControlCierreEstadoFinancieroBE) ((CControlCierreEstadoFinanciero) new CControlCierreEstadoFinanciero()).DetalleControlCierreEstadoFinanciero(usc_ParametroContable.IdCentroOperativo,usc_ParametroContable.IdTipoInformacion,usc_ParametroContable.Periodo,usc_ParametroContable.Mes)).IdEstado;
			Session[VARIABLESESSIONCIERRE]=((ControlCierreEstadoFinancieroBE) ((CControlCierreEstadoFinanciero) new CControlCierreEstadoFinanciero()).DetalleControlCierreEstadoFinanciero(Convert.ToInt32(usc_ParametroContable.IdCentroOperativo),
																																															Convert.ToInt32(usc_ParametroContable.IdTipoInformacion),
																																															Convert.ToInt32(usc_ParametroContable.Periodo),
																																															Convert.ToInt32(usc_ParametroContable.Mes))).IdEstado;
			if (Convert.ToInt32(Session[VARIABLESESSIONCIERRE])==1)
			{
				//imgProcesar.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,"window.alert('No es posible procesar este mes por que se encuentra cerrado..');");
				imgProcesar.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Helper.MensajeAlert(Utilitario.Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesErrorFinanciera.ToString(), Mensajes.CODIGOMENSAJEERRORESTADOFINANCEROPROCESARMES)));
			}
			if(dtEstadoFinanciero!=null)
			{
//				if(Convert.ToInt32(Page.Request.QueryString[KEYQIDFORMATO])==22)
//				{
//					
//					grid.Columns[3].Visible=false;
//					grid.Columns[4].Visible=false;
//				}
				grid.DataSource = dtEstadoFinanciero;
//				CImpresion oCImpresion = new CImpresion();
//				oCImpresion.GuardarDataImprimirExportar(dtAccionCorrectiva,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGOTITULOREPORTEACCIONCORRECTIVA),columnaOrdenar,indicePagina);
			}
			else
			{
				grid.DataSource = dtEstadoFinanciero;
				lblResultado.Text = GRILLAVACIA;

			}
			grid.DataBind();
		}
		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultaDeEstadosFinancieros.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add ConsultaDeEstadosFinancieros.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
		}

		public void LlenarDatos()
		{
			this.LstUser.Controls.Add(ListaUsuarioPrivilegio(Convert.ToInt32( Page.Request.Params[KEYQIDFORMATO])));
		}
		public HtmlTable ListaUsuarioPrivilegio(int IdFormato){
			DataTable dtuser = (new CFormatoPrivilegio()).ListarUsuarioPriviFormato(IdFormato);
			if(dtuser!=null && dtuser.Rows.Count>0)
			{
				HtmlTable ohtmlTable = Helper.CrearHtmlTabla(2,dtuser.Rows.Count);
				int idx=0;
				foreach(DataRow dr in dtuser.Rows)
				{
					string ImgCirc="<img id='" + dr["IdUsuario"].ToString() +"' style='WIDTH: 48px; HEIGHT: 48px' class='imgCirc' src='/SimaNetWeb/imagenes/Navegador/EfectCircular.gif' title='" + dr["ApellidosyNombres"].ToString() + "' onclick='CargarPrivilegios(this);'>";
					string ImgCircAct="<img id='" + dr["IdUsuario"].ToString() +"' style='WIDTH: 48px; HEIGHT: 48px' class='imgCirc' src='/SimaNetWeb/imagenes/Navegador/UserActivo.gif' title='" + dr["ApellidosyNombres"].ToString() + "' onclick='CargarPrivilegios(this);'>";
					int IdUsuLog=CNetAccessControl.GetIdUser();
					int IdUsuReg  =Convert.ToInt32(dr["IdUsuario"].ToString());
					string HtmlImg = "<div class='ContextImg'> " + ((IdUsuLog==IdUsuReg)?ImgCircAct:ImgCirc) + "<img  src='" + Helper.ObtenerFotoPersonal(dr["NroPersonal"].ToString()) +"'  style='WIDTH: 45px; HEIGHT: 45px'  onerror=ErrorLoadImg(this,'"  + Helper.ObtenerFotoPersonal(dr["NroDocDNI"].ToString()) + "'); /></div>";
					ohtmlTable.Rows[0].Cells[idx].Controls.Add((new LiteralControl(HtmlImg)));
					ohtmlTable.Rows[1].Cells[idx].InnerText=dr["login"].ToString();
					ohtmlTable.Rows[1].Cells[idx].Style.Add("FONT-SIZE","8pt");
					ohtmlTable.Rows[1].Cells[idx].Style.Add("COLOR","darkgray");
					 
					idx++;
				}
				return ohtmlTable;
			}
			return null;
		}

		public void LlenarJScript()
		{
			imgProcesar.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,JSVERIFICARPROCESO);
			//imgbtnGrabar.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,JSVERIFICARGUARDAR);
			imgbtnGrabar.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.POPUPDEESPERA + "return ObtenerDataModificada()");
			//string strScript = "Javascript:function(){var Datos=new Array();" +
			//Helper.MostraEditordeTextoHtml("Sistema",530,280) + "if(Datos!=null){ alert(Datos[0]);}else{alert('No se ha registrado');}}";
			//ibtnGlosaEF.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,"EscribirDescripcionEnFila();");
			this.imgProcesar.Style["Display"]=((this.FormatoProcesar&&!this.CtrlCierre)?"block":"none");
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultaDeEstadosFinancieros.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultaDeEstadosFinancieros.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultaDeEstadosFinancieros.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			if(CNetAccessControl.FindPage(Page.Request.Url.AbsolutePath.ToString()))
			{CNetAccessControl.LoadControls(this);}
			else
			{CNetAccessControl.RedirectPageError();}						
			// TODO:  Add ConsultaDeEstadosFinancieros.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ConsultaDeEstadosFinancieros.ValidarFiltros implementation
			return false;
		}

		#endregion


		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			//if ( Convert.ToInt32(Page.Request.QueryString[KEYQIDFORMATO])!=21 ) // Formato 21 de Estado de GGyPP
			{
				e.Item.Cells[1].Style.Add("display","none");
			}

			ControlesUsuario.GestionFinanciera.ParametroContable usc_ParametroContable =(ControlesUsuario.GestionFinanciera.ParametroContable)Session[OBJPARAMETROCONTABLE + Page.Request.Params[KEYIDEMPRESA].ToString() ];
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;			

				e.Item.Attributes.Add("PRIORIDAD",dr[Enumerados.ColumnasFormato.idPrioridad.ToString()].ToString());

				string strFormula = dr[Enumerados.ColumnasFormato.FormulaFormato.ToString()].ToString();
				for(int i=0;i<= strFormula.Length-1;i++)
				{
					if (strFormula.Substring(i,1)==Utilitario.Constantes.SIGNOMAS || strFormula.Substring(i,1)==Utilitario.Constantes.SIGNOMENOS)
					{
						strFormula =strFormula.Substring((i+1),strFormula.Length-(i+1));
						break;
					}
				}
				
				e.Item.Attributes.Add("FORMULA",strFormula + Utilitario.Constantes.SIGNOARROBA);
				e.Item.Attributes.Add("MODO",dr[Enumerados.ColumnasFormato.Modo.ToString()].ToString());
				e.Item.Attributes.Add("IDRUBRO",dr[Enumerados.ColumnasFormato.IdRubro.ToString()].ToString());
				

				if (dr[Enumerados.ColumnasFormato.FormulaFormato.ToString()].ToString().Length>0)
				{stridFila += idFila.ToString() + Utilitario.Constantes.SIGNOPUNTOYCOMA;}
				grid.Attributes.Add("FILAFORMULA",stridFila);
				#region Query string
				System.Text.StringBuilder QryStringBase =   new System.Text.StringBuilder(Utilitario.Constantes.VACIO);
				QryStringBase.Append(KEYIDEMPRESA + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDEMPRESA].ToString());
				QryStringBase.Append(Utilitario.Constantes.SIGNOAMPERSON);	
				QryStringBase.Append(KEYQIDFORMATO);
				QryStringBase.Append(Utilitario.Constantes.SIGNOIGUAL);	
				QryStringBase.Append(Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO]));
				QryStringBase.Append(Utilitario.Constantes.SIGNOAMPERSON);	
				QryStringBase.Append(KEYQIDREPORTE + Utilitario.Constantes.SIGNOIGUAL);
				QryStringBase.Append(Convert.ToInt32(Page.Request.Params[KEYQIDREPORTE]));
				QryStringBase.Append(Utilitario.Constantes.SIGNOAMPERSON);	
				QryStringBase.Append(KEYQIDRUBRO + Utilitario.Constantes.SIGNOIGUAL);
				QryStringBase.Append(dr[Enumerados.ColumnasFormato.IdRubro.ToString()].ToString());
				QryStringBase.Append(Utilitario.Constantes.SIGNOAMPERSON);	
				QryStringBase.Append(KEYIDACUMULADO + Utilitario.Constantes.SIGNOIGUAL);
				QryStringBase.Append(Page.Request.Params[KEYIDACUMULADO]);
				QryStringBase.Append(Utilitario.Constantes.SIGNOAMPERSON);	
				QryStringBase.Append(NODOSELECCIONADO + Utilitario.Constantes.SIGNOIGUAL);
				QryStringBase.Append(dr[Enumerados.ColumnasFormato.NroNivel.ToString()].ToString());
				QryStringBase.Append(Utilitario.Constantes.SIGNOAMPERSON);	
				QryStringBase.Append(KEYQPERIODO + Utilitario.Constantes.SIGNOIGUAL);
				QryStringBase.Append(periodo);
										
						

				//QueryString para el Mantenimiento del los Rubros del Formato
				System.Text.StringBuilder QryStringDetalle =  new System.Text.StringBuilder(Utilitario.Constantes.VACIO);
				QryStringDetalle.Append(Utilitario.Constantes.SIGNOAMPERSON);	
				QryStringDetalle.Append(Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL);
				QryStringDetalle.Append(dr[Enumerados.ColumnasFormato.Modo.ToString()].ToString());
				//QueryString para la Consulta de la Cuenta Por Niveles
				System.Text.StringBuilder QryStringConsulta = new System.Text.StringBuilder(Utilitario.Constantes.VACIO);
				QryStringConsulta.Append(Utilitario.Constantes.SIGNOAMPERSON);	
				QryStringConsulta.Append(KEYQNRODIGITOSCABECERA + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.ValorConstanteCero.ToString());
				QryStringConsulta.Append(Utilitario.Constantes.SIGNOAMPERSON);	
				QryStringConsulta.Append(KEYDIGCUENTACONTABLE + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.ValorConstanteCero.ToString());
				#endregion

				Utilitario.Helper.ConfiguraNodosTreeview(e,1,0,dr,"MostrarDetalleFormula('"+ Convert.ToInt32(usc_ParametroContable.IdCentroOperativo).ToString() + "','" + periodo.ToString() + "','" + Convert.ToInt32(usc_ParametroContable.Mes).ToString() + "','" + dr[Enumerados.ColumnasFormato.IdRubro.ToString()].ToString() + "','"+ Convert.ToInt32(usc_ParametroContable.IdTipoInformacion).ToString() + "');");
				
				Utilitario.Helper.SeleccionarItemGrillaOnClickMoverRaton(e);

				if (Convert.ToInt32(dr[Enumerados.ColumnasFormato.IdTipoLinea.ToString()]) != 0 )
				{}
				else
				{
					int IdFormato = Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO]);
					System.Web.UI.WebControls.Image  img ;
					img = (System.Web.UI.WebControls.Image)e.Item.Cells[2].FindControl(CONTROLIMGFORMULA);
					if(( Convert.ToInt32(dr[Enumerados.ColumnasFormato.IdRubro.ToString()])==1 
						|| Convert.ToInt32(dr[Enumerados.ColumnasFormato.IdRubro.ToString()])==2
						|| Convert.ToInt32(dr[Enumerados.ColumnasFormato.IdRubro.ToString()])==6
						|| Convert.ToInt32(dr[Enumerados.ColumnasFormato.IdRubro.ToString()])==16
						|| Convert.ToInt32(dr[Enumerados.ColumnasFormato.IdRubro.ToString()])==17
						|| Convert.ToInt32(dr[Enumerados.ColumnasFormato.IdRubro.ToString()])==21)
						&& IdFormato ==22)
					{
						img.Visible=false;
					}
					else
					{
						img.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.POPUPDEESPERA + Utilitario.Constantes.HISTORIALADELANTE);
						//img.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Helper.MostrarVentana(URLDETALLE1,QryStringBase.ToString()).ToString());
						if(this.RequiereCtaContable==1)//Cuenta Contable
						{
							img.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Helper.MostrarVentana(URLDETALLE1,QryStringBase.ToString()).ToString());
						}
						else if(this.RequiereCtaContable==2)//NotaContable
						{
							if(dr["FORMENTRERUBRO"].ToString().Equals("0"))//Formula contable
							{
								img.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,"(new SIMA.Utilitario.Helper.Response()).ShowDialogoOnTop('" + URLBUSCARNOTACONTABLE+QryStringBase.ToString() + "',700,400);");
							}
							else{
								//Levantar la venta de formula entre rubro
							}
							img.Visible = true;
						}
						
					}
					
				}

				idFila ++;
				string FormulaF = dr[Enumerados.ColumnasFormato.FormulaFormato.ToString()].ToString();
				if(FormulaF.Trim().Length == 0 && Convert.ToInt32(dr[Enumerados.ColumnasFormato.NroHijos.ToString()])==0 ) 
				{
					string Pagina = Utilitario.Constantes.POPUPDEESPERA + Helper.HistorialIrAdelantePersonalizado(Utilitario.Constantes.VACIO) 
						+ Utilitario.Constantes.SIGNOPUNTOYCOMA 
						+ Helper.MostrarVentana(URLDETALLE2,KEYQIDFORMATO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYQIDFORMATO].ToString()
						+ Utilitario.Constantes.SIGNOAMPERSON
						+ KEYQIDRUBRO + Utilitario.Constantes.SIGNOIGUAL + dr[Enumerados.ColumnasFormato.IdRubro.ToString()].ToString()
						+ Utilitario.Constantes.SIGNOAMPERSON
						+ KEYQIDCENTRO + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt32(usc_ParametroContable.IdCentroOperativo).ToString()
						+ Utilitario.Constantes.SIGNOAMPERSON
						+ KEYQIDTIPOINFO + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt32(usc_ParametroContable.IdTipoInformacion).ToString()
						+ Utilitario.Constantes.SIGNOAMPERSON
						+ KEYQPERIODO + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt32(usc_ParametroContable.Periodo).ToString()
						+ Utilitario.Constantes.SIGNOAMPERSON
						+ KEYQRUBRONOMBRE + Utilitario.Constantes.SIGNOIGUAL +  dr[COLUMNACONCEPTO].ToString()
						+ Utilitario.Constantes.SIGNOAMPERSON
						+ KEYQMES + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt32(usc_ParametroContable.Mes).ToString()
						+ Utilitario.Constantes.SIGNOAMPERSON
						+ KEYQIDNOMBREFORMATO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYQIDNOMBREFORMATO].ToString()
						+ Utilitario.Constantes.SIGNOAMPERSON
						+ NODOSELECCIONADO + Utilitario.Constantes.SIGNOIGUAL + dr[Enumerados.ColumnasFormato.NroNivel.ToString()].ToString());
					((System.Web.UI.WebControls.Image) e.Item.Cells[3].FindControl(CONTROLIMAGE)).Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Pagina);
				}
				else
				{
					((System.Web.UI.WebControls.Image) e.Item.Cells[3].FindControl(CONTROLIMAGE)).Visible=false;
				}

				#region Editor de Celdas
					int VerImporte = Convert.ToInt32(dr[Enumerados.ColumnasFormato.FlgVerMonto.ToString()]);
					if( VerImporte!= 0 ) 
					{
						eWorld.UI.NumericBox ControlNumerico;
						ControlNumerico = (eWorld.UI.NumericBox) e.Item.Cells[1].FindControl(CTRLMONTO1);
						ControlNumerico.Text=Convert.ToDouble(dr[COLUMNAMONTOMES]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
						/*if(this.FormatoProcesar)
						{
							ControlNumerico.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,"");
							ControlNumerico.ReadOnly=true;
						}
						else{
							ControlNumerico.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,"EnfocarSiguienteCelda(this);");
						}*/

						#region Resalta los rubro que poseen formulas
							if (FormulaF.Trim().Length>0)
							{
								ControlNumerico.Font.Size=8;
								ControlNumerico.ReadOnly=true;
								ControlNumerico.Font.Bold=true;
								e.Item.Cells[1].Font.Size=8;
								e.Item.Cells[1].Font.Bold=true;
							}
						#endregion


						const string COLUMNAMODIFICABLE = "Modificable";
						int VALORCOLUMNAMODIFCABLE = Convert.ToInt32(dr[COLUMNAMODIFICABLE]);

						int VALORIDCENTRO = Convert.ToInt32(usc_ParametroContable.IdCentroOperativo);
						ControlNumerico.Attributes.Add("EDITABLE",VALORCOLUMNAMODIFCABLE.ToString());

						if ((VALORCOLUMNAMODIFCABLE == 0)
							||(VALORCOLUMNAMODIFCABLE==VALORIDCENTRO)
							||((VALORCOLUMNAMODIFCABLE==5)&&(VALORIDCENTRO== Utilitario.Constantes.KEYIDCENTROCALLAO || VALORIDCENTRO== Utilitario.Constantes.KEYIDCENTROCHIMBOTE))
							||((VALORCOLUMNAMODIFCABLE==6)&&(VALORIDCENTRO== Utilitario.Constantes.KEYIDCENTROCALLAO || VALORIDCENTRO== Utilitario.Constantes.KEYIDCENTROIQUITOS))
							||((VALORCOLUMNAMODIFCABLE==6)&&(VALORIDCENTRO== Utilitario.Constantes.KEYIDCENTROCHIMBOTE || VALORIDCENTRO== Utilitario.Constantes.KEYIDCENTROIQUITOS))
							)
						{//Deshabilita la edicion segun lo definido para este rubro
							ControlNumerico.Visible=false;
							ControlNumerico.ReadOnly=false;
							e.Item.Cells[2].Text= Convert.ToDouble(dr[COLUMNAMONTOMES]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
						}

					}
					else
					{
						((eWorld.UI.NumericBox) e.Item.Cells[1].FindControl(CTRLMONTO1)).Visible=false;
					}
					e.Item.Attributes.Add("MONTORUBRO",dr[COLUMNAMONTOMES].ToString().Trim().Replace(",",""));
				#endregion

				//Descipciones
				e.Item.Attributes.Add("OBSERVACIONES",dr[COLUMNAOBSERVACION].ToString());
				((System.Web.UI.WebControls.Image) e.Item.Cells[4].FindControl(CONTROLIMGBTNDESCRIPCION)).Attributes.Add(Utilitario.Constantes.EVENTOCLICK,"EscribirDescripcionEnFila('" + dr[Enumerados.ColumnasFormato.IdRubro.ToString()].ToString() + "');");
			}	
		}
		

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void btnProcesar_Click(object sender, System.EventArgs e)
		{
		}

		private void btnConsultar_Click(object sender, System.EventArgs e)
		{
			this.LlenarGrilla();
		}

		private void imgbtnGrabar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			 if (hTramaData.Value.ToString().Length==0) {return;}
			string []sdata = hTramaData.Value.ToString().Split('@');
			for (int i=0;i<=sdata.Length-1;i++)
			{
				string []Data = sdata[i].Split('*');
				switch (Data[0].ToString())
				{
					case "N":
						this.Agregar(Data);
						break;
					case "M":
						this.Modificar(Data);
						break;
				}
			}
			Helper.SubirArchivo(filMyFileDocumento,RutaArchivosXLS,Utilitario.Constantes.NombreArchivoIndicadorFinanciero);
			this.LlenarGrilla();
		}


		#region IPaginaMantenimento Members

		public void Agregar(string []Data)
		{
			//Referencia la Control de Parametros
			string idEmpresa = Page.Request.Params[KEYIDEMPRESA].ToString();
			ControlesUsuario.GestionFinanciera.ParametroContable usc_ParametroContable = (ControlesUsuario.GestionFinanciera.ParametroContable)Session[OBJPARAMETROCONTABLE + idEmpresa];
			//Referencia a la Entidad de Negocio
			FormatoDetalleMovimientoBE oFormatoDetalleMovimientoBE = new FormatoDetalleMovimientoBE();

			oFormatoDetalleMovimientoBE.IdCentroOperativo = Convert.ToInt32(usc_ParametroContable.IdCentroOperativo); 
			oFormatoDetalleMovimientoBE.IdFormato = Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO]); 
			oFormatoDetalleMovimientoBE.IdReporte = Convert.ToInt32(Page.Request.Params[KEYQIDREPORTE]); 
			oFormatoDetalleMovimientoBE.IdRubro = Convert.ToInt32(Data[1]);
			oFormatoDetalleMovimientoBE.Periodo = Convert.ToInt32(usc_ParametroContable.Periodo); 
			oFormatoDetalleMovimientoBE.Mes = Convert.ToInt32(usc_ParametroContable.Mes); 
			oFormatoDetalleMovimientoBE.IdTipoInformacion = Convert.ToInt32(usc_ParametroContable.IdTipoInformacion); 
			oFormatoDetalleMovimientoBE.IdUsuarioRegistro =  CNetAccessControl.GetIdUser();
			oFormatoDetalleMovimientoBE.MontoAcumulado = 0;
			if (Data[2].Trim().Length>0)
			{
				oFormatoDetalleMovimientoBE.MontoMes = Convert.ToDouble(Data[2]);
			}
			oFormatoDetalleMovimientoBE.Observacion = Data[3].ToString();
			//oFormatoDetalleMovimientoBE.Observacion = this.txtObservacion.Text;

			CEstadosFinancieros  oCEstadosFinancieros = new CEstadosFinancieros();
			int retorno = oCEstadosFinancieros.Insertar(oFormatoDetalleMovimientoBE);
		}

		public void Modificar(string []Data)
		{
			//Referencia la Control de Parametros
			string idEmpresa = Page.Request.Params[KEYIDEMPRESA].ToString();
			ControlesUsuario.GestionFinanciera.ParametroContable usc_ParametroContable = (ControlesUsuario.GestionFinanciera.ParametroContable)Session[OBJPARAMETROCONTABLE + idEmpresa ];
			//Referencia a la Entidad de Negocio
			FormatoDetalleMovimientoBE oFormatoDetalleMovimientoBE = new FormatoDetalleMovimientoBE();

			oFormatoDetalleMovimientoBE.IdCentroOperativo = Convert.ToInt32(usc_ParametroContable.IdCentroOperativo);
			oFormatoDetalleMovimientoBE.IdFormato = Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO]); 
			oFormatoDetalleMovimientoBE.IdReporte = Convert.ToInt32(Page.Request.Params[KEYQIDREPORTE]); 
			oFormatoDetalleMovimientoBE.IdRubro = Convert.ToInt32(Data[1]);
			oFormatoDetalleMovimientoBE.Periodo = Convert.ToInt32(usc_ParametroContable.Periodo); 
			oFormatoDetalleMovimientoBE.Mes = Convert.ToInt32(usc_ParametroContable.Mes);
			oFormatoDetalleMovimientoBE.IdTipoInformacion = Convert.ToInt32(usc_ParametroContable.IdTipoInformacion); 
			oFormatoDetalleMovimientoBE.IdUsuarioActualizacion =  CNetAccessControl.GetIdUser();
			oFormatoDetalleMovimientoBE.MontoAcumulado = 0;
			
			//string a = Data[2].ToString().Trim();
			string strMonto = ((Data[2].ToString().Trim().Length>0)? Data[2].ToString().Trim().Replace(" ",""):"0");

			oFormatoDetalleMovimientoBE.MontoMes = Convert.ToDouble(strMonto);
			oFormatoDetalleMovimientoBE.Observacion = Data[3].ToString();
			//oFormatoDetalleMovimientoBE.Observacion = this.txtObservacion.Text.ToString();

			CEstadosFinancieros  oCEstadosFinancieros = new CEstadosFinancieros();
			int retorno = oCEstadosFinancieros.Modificar(oFormatoDetalleMovimientoBE);
		}



		public void Agregar()
		{
			// TODO:  Add ConsultaDeEstadosFinancieros.Agregar implementation
		}

		public void Modificar()
		{
			// TODO:  Add ConsultaDeEstadosFinancieros.Modificar implementation
		}

		public void Eliminar()
		{
			// TODO:  Add ConsultaDeEstadosFinancieros.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			// TODO:  Add ConsultaDeEstadosFinancieros.CargarModoPagina implementation
		}

		public void CargarModoNuevo()
		{
			// TODO:  Add ConsultaDeEstadosFinancieros.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			// TODO:  Add ConsultaDeEstadosFinancieros.CargarModoModificar implementation
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add ConsultaDeEstadosFinancieros.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add ConsultaDeEstadosFinancieros.ValidarCampos implementation
			return false;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add ConsultaDeEstadosFinancieros.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add ConsultaDeEstadosFinancieros.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion

		private void ProcesarFormato()
		{
			SIMA.Controladoras.GestionFinanciera.CFormatoDetalleMovimiento oCFormatoDetalleMovimiento = new SIMA.Controladoras.GestionFinanciera.CFormatoDetalleMovimiento();
			ControlesUsuario.GestionFinanciera.ParametroContable usc_ParametroContable =(ControlesUsuario.GestionFinanciera.ParametroContable)Session[OBJPARAMETROCONTABLE + Page.Request.Params[KEYIDEMPRESA].ToString()];


			if(this.FormatoProcesar)
			{
				if(this.RequiereCtaContable==1)
				{
			
					oCFormatoDetalleMovimiento.ProcesarFormatoEstadosFinancierosRubros(
						Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO])
						,Convert.ToInt32(Page.Request.Params[KEYQIDREPORTE])
						,Convert.ToInt32(usc_ParametroContable.IdCentroOperativo)
						,Convert.ToInt32(usc_ParametroContable.Periodo)
						,Convert.ToInt32(usc_ParametroContable.Mes)
						,Convert.ToInt32(Page.Request.Params[KEYIDACUMULADO]));
				}
				else{
					//Calcular por nota Contable

				}
			}

		}
		private void imgProcesar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{

			try
			{
				if(Page.IsValid)
				{
					this.ProcesarFormato();
					this.LlenarGrilla();
					//ASPNetUtilitario.MessageBox.Show("Se proceso formato correctamente..");
					ASPNetUtilitario.MessageBox.Show(Utilitario.Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionFinanciera.ToString(), Mensajes.CODIGOMENSAJECONFIRMACIONESTADOFINANCEROPROCESARFORMATO));
					
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
				string ex = oException.Message.ToString();
				SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
				Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
			}
		
		}

		private void imgGlosa_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Page.Response.Redirect(URLGLOSA + KEYQIDFORMATO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYQIDFORMATO].ToString()
											+ Utilitario.Constantes.SIGNOAMPERSON
											+ KEYIDEMPRESA + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDEMPRESA].ToString()
											+ Utilitario.Constantes.SIGNOAMPERSON
											+ Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Enumerados.ModoPagina.N.ToString());
		}

		
	}
}
 