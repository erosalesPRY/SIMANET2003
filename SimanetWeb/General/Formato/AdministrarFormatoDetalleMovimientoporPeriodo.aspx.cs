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
using SIMA.EntidadesNegocio.General;
using SIMA.Utilitario;
using NetAccessControl;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using System.IO;
using Microsoft.Office.Core;
using Excel= Microsoft.Office.Interop.Excel;

namespace SIMA.SimaNetWeb.General.Formato
{
	/// <summary>
	/// Summary description for AdministrarFormatoDetalleMovimientoporPeriodo.
	/// </summary>
	public class AdministrarFormatoDetalleMovimientoporPeriodo : System.Web.UI.Page,IPaginaBase
	{
		#region Constantes
			const string KEYQIDFORMATO="IdFormato";
			const string KEYQIDREPORTE = "IdReporte";
			const string KEYQIDRUBRO ="IdRubro";

			const string KEYQNOMBRERUBRO ="NombreRubro";
			const string URLITEMDETALLE = "AdministrarFormatoItemDetalleMovimientoporPeriodo.aspx?";
			const string KEYQPERIODO = "Periodo";
			const string KEYQIDGRUPOFORMATO="IdGrupoFormato";
			const string IDCENTROOPERATIVO="idcop";
			//const string  KEYQIDGRUPOCC = "idGrpCC";
			const string KEYQIDCENTROCOSTO ="idCC";
			const string KEYQIDTIPOINFO ="idTipoInfo";
			const string KEYQNROFILAINI="NroFilaIni";
			const string KEYQREQCC ="ReqCC";
			const string KEYQREQCTACTABLE="ReqCtaCtable";
			const string KEYQACUMULADO="Acum";
			const string  KEYQCERRADO="Close";

			const string  URLPAGINADETALLE ="AdministrarFormatoDetalleMovimientoporPeriodoItem.aspx?";

		#endregion

		#region Atributos
		public int IdCentroOperativo
		{
			get{return Convert.ToInt32(Page.Request.Params[IDCENTROOPERATIVO]);}
		}
		public int Periodo
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQPERIODO]);}
		}
		public int IdMes
		{
			get{return Convert.ToInt32(this.hIdMes.Value);}
		}

		public int IdFormato
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO]);}
		}
		public int IdReporte{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDREPORTE]);}
		}

		public int ReqCtaCtable{
			get{return Convert.ToInt32(Page.Request.Params[KEYQREQCTACTABLE]);}
		}
		public int FormatoAcumulado
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQACUMULADO]);}
		}

		public int IdTipoInformacion{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDTIPOINFO]);}
		}

		public int Cerrado
		{
			get{
				DataTable DTC =  ((CControlCierreEstadoFinanciero) new  CControlCierreEstadoFinanciero()).AdministrarDetalleControlCierreEstadoFinanciero(this.IdCentroOperativo,this.IdTipoInformacion,this.Periodo,this.IdMes);
				return Convert.ToInt32(DTC.Rows[0]["IdEstado"]);
				}
		}


		
		#endregion

		int NroFilaIni = 2;
		DataTable dt;
		int idCentroCosto=0;

		string stridFila ="";
		string lstPrioridad="";
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hNombreImgTrim;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.HtmlControls.HtmlInputFile FDoc;
		protected System.Web.UI.WebControls.RadioButton R1;
		protected System.Web.UI.WebControls.RadioButton R2;
		protected System.Web.UI.WebControls.RadioButton R3;
		protected System.Web.UI.WebControls.RadioButton R4;
		protected System.Web.UI.WebControls.Button btnPrc;
		protected System.Web.UI.WebControls.DataGrid gridPost;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hOpSelected;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdMes;
		protected System.Web.UI.WebControls.Label lblResultado;
	
		private string PjsIdMes = "";
		private string PjsIdxCell= "";
		string ParamArgument="";

		protected System.Web.UI.WebControls.Button cmdImportarSaldos1;
		protected System.Web.UI.WebControls.Button btnExportaXLS;
		protected System.Web.UI.WebControls.RadioButton R5;
		protected System.Web.UI.WebControls.Button btnResumenyDetalleXLS;
		protected System.Web.UI.WebControls.RadioButton R6;
		protected System.Web.UI.HtmlControls.HtmlTableCell LstUser;
		private int NFila = 2;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hRunReportCenter;

		HtmlTable otblH;

		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				ParamArgument=Page.Request.Params["__EVENTARGUMENT"];
				if((ParamArgument!=null)&&(ParamArgument.Length>0))
				{
					this.PjsIdMes = ParamArgument.Split(';')[0].ToString();
					this.PjsIdxCell = ParamArgument.Split(';')[1].ToString();
				}
				if(!Page.IsPostBack)
				{
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarJScript();
					this.LlenarCombos();
					this.LlenarDatos();
					this.LlenarGrilla();
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(), "Gestión Financiera: Administrar Formatos Financieros mensualizados", this.ToString(),"Se consultó Listado de formtatos financieros",Enumerados.NivelesErrorLog.I.ToString()));
					
				}
			}
			catch(SIMAExcepcionLog oSIMAExcepcionLog)
			{
				Helper.MsgBox(oSIMAExcepcionLog.Mensaje);					
			}
			catch(SIMAExcepcionIU oSIMAExcepcionIU)
			{
				Helper.MsgBox(oSIMAExcepcionIU.Mensaje);					
			}
			catch(SIMAExcepcionDominio oSIMAExcepcionDominio)
			{
				Helper.MsgBox(oSIMAExcepcionDominio.Mensaje);					
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
			this.grid.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemCreated);
			this.grid.PreRender += new System.EventHandler(this.grid_PreRender);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.btnPrc.Click += new System.EventHandler(this.btnPrc_Click);
			this.btnExportaXLS.Click += new System.EventHandler(this.btnExportaXLS_Click);
			this.cmdImportarSaldos1.Click += new System.EventHandler(this.cmdImportarSaldos1_Click);
			this.btnResumenyDetalleXLS.Click += new System.EventHandler(this.btnResumenyDetalleXLS_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members
		
		private void gridPostMtd()
		{
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add("Codigo");
			dataTable.Columns.Add("Descripcion");
			object[] array = new object[]
			{
				"",
				""
			};
			dataTable.Rows.Add(array);
			this.gridPost.DataSource=dataTable;
			this.gridPost.DataBind();
		}

		public DataTable ObtenerFormato(){
			idCentroCosto = ((Convert.ToInt32(Page.Request.Params[KEYQREQCC])==0)?-1: Convert.ToInt32(Page.Request.Params[KEYQIDCENTROCOSTO]));
			return (new  CFormatoEstructuraMovimientoCentroCosto()).ConsultarFormatoEstructuraMovimientoCentroCosto(Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO]),Convert.ToInt32(Page.Request.Params[KEYQIDREPORTE]),Convert.ToInt32(Page.Request.Params[IDCENTROOPERATIVO]),Convert.ToInt32(Page.Request.Params[KEYQPERIODO]),Convert.ToInt32(Page.Request.Params[KEYQIDTIPOINFO]),idCentroCosto);
		}

		public void LlenarGrilla()
		{
			this.gridPostMtd();
			idCentroCosto = ((Convert.ToInt32(Page.Request.Params[KEYQREQCC])==0)?-1: Convert.ToInt32(Page.Request.Params[KEYQIDCENTROCOSTO]));
			dt = (new  CFormatoEstructuraMovimientoCentroCosto()).ConsultarFormatoEstructuraMovimientoCentroCosto(Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO]),Convert.ToInt32(Page.Request.Params[KEYQIDREPORTE]),Convert.ToInt32(Page.Request.Params[IDCENTROOPERATIVO]),Convert.ToInt32(Page.Request.Params[KEYQPERIODO]),Convert.ToInt32(Page.Request.Params[KEYQIDTIPOINFO]),idCentroCosto);
			
			dt = ObtenerFormato();
			if(dt!=null)
			{
				
				grid.DataSource =  Helper.OrdenarFormatoEstructura(dt);
			}
			else
			{
				grid.DataSource = dt;
			}
			grid.DataBind();
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarFormatoDetalleMovimientoporPeriodo.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add AdministrarFormatoDetalleMovimientoporPeriodo.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
		}

		public void LlenarDatos()
		{
			this.hNombreImgTrim.Value = Helper.ObtenerNombreTrimestre(DateTime.Now.Month,Enumerados.TipoDatoTrimestre.SinEspacio).ToString().ToUpper();
			this.LstUser.Controls.Add((new SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancieros.ConsultaDeEstadosFinancieros()).ListaUsuarioPrivilegio(this.IdFormato));

			
		}

		
		public void LlenarJScript()
		{
			this.R1.Attributes[Enumerados.EventosJavaScript.OnClick.ToString()]= "OpcionSeleccionada(1);";
			this.R2.Attributes[Enumerados.EventosJavaScript.OnClick.ToString()]= "OpcionSeleccionada(2);";
			this.R3.Attributes[Enumerados.EventosJavaScript.OnClick.ToString()]= "OpcionSeleccionada(3);";
			this.R4.Attributes[Enumerados.EventosJavaScript.OnClick.ToString()]= "OpcionSeleccionada(4);";
			this.R5.Attributes[Enumerados.EventosJavaScript.OnClick.ToString()]= "OpcionSeleccionada(5);";
			this.R6.Attributes[Enumerados.EventosJavaScript.OnClick.ToString()]= "OpcionSeleccionada(6);";
			
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarFormatoDetalleMovimientoporPeriodo.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministrarFormatoDetalleMovimientoporPeriodo.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarFormatoDetalleMovimientoporPeriodo.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add AdministrarFormatoDetalleMovimientoporPeriodo.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add AdministrarFormatoDetalleMovimientoporPeriodo.ValidarFiltros implementation
			return false;
		}

		#endregion
		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			int idMes = 1;
			try
			{
				for(int c=1;c<=16;c++)
				{
					if((c>=1 && c<=3)||(c>=5 && c<=7)||(c>=9 && c<=11)||(c>=13 && c<=15))
					{
						e.Item.Cells[c].Style.Add("display","none");
						if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
						{
							DataRowView drv = (DataRowView)e.Item.DataItem;
							DataRow dr = drv.Row;			
							e.Item.Cells[c].Attributes.Add(Enumerados.EventosJavaScript.Ondblclick.ToString(),"EscribirDescripcionEnFila('" + idMes.ToString() + "',this);");
							string NMes = Helper.ObtenerNombreMes(idMes,Enumerados.TipoDatoMes.NombreCompleto);
						
							eWorld.UI.NumericBox nb = (eWorld.UI.NumericBox)e.Item.Cells[c].FindControl("n" + NMes);	
							nb.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,"EnfocarSiguienteCelda(this);");
							nb.Attributes.Add("cellIndex",c.ToString());
							nb.Attributes.Add("rowIndex",(e.Item.ItemIndex+NFila).ToString());


							nb.Text = Convert.ToDouble(dr[NMes]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
							nb.Attributes.Add("tag",Convert.ToDouble(dr[NMes]).ToString());
							nb.Attributes.Add("idMes",idMes.ToString());
							if(Convert.ToInt32(dr[Enumerados.ColumnasFormato.NroHijos.ToString()])!=0)
							{
								nb.ReadOnly=true;
								nb.Font.Bold=true;
								nb.Font.Size= FontUnit.Point(8);
							}

							if(idMes==DateTime.Now.Month)
							{
								e.Item.Cells[c].Style.Add("BACKGROUND-COLOR","lightgoldenrodyellow");
							}
							//Establece las notas uobservaciones
							if(Convert.ToDouble(dr["o" + NMes]) !=0)
							{
								e.Item.Cells[c].Style.Add("BACKGROUND-IMAGE","url(/SimaNetWeb/imagenes/tree/Nota.gif)");
								e.Item.Cells[c].Style.Add("BACKGROUND-REPEAT","no-repeat"); 
								e.Item.Cells[c].Style.Add("BACKGROUND-POSITION","left top");
							}

							idMes++;
						}
					}
					else
					{
						if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
						{
							DataRowView drv = (DataRowView)e.Item.DataItem;
							DataRow dr = drv.Row;
							e.Item.Cells[c].Text = Convert.ToDouble(dr[Helper.ObtenerNombreTrimestre((idMes-1),SIMA.Utilitario.Enumerados.TipoDatoTrimestre.SinEspacio).ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
							e.Item.Cells[c].Font.Bold=true;
							e.Item.Cells[c].Font.Size = FontUnit.Point(8);
							e.Item.Cells[c].Style.Add("BACKGROUND-COLOR","gainsboro");
						}
					}
				}

				if(e.Item.ItemType == ListItemType.Header)
				{
					e.Item.Cells[1].Attributes[Enumerados.EventosJavaScript.Ondblclick.ToString()]= "ProcesarCuentasCtables(1,this)";
					ConfigColGridCierre(1,e.Item.Cells[1]);
					e.Item.Cells[2].Attributes[Enumerados.EventosJavaScript.Ondblclick.ToString()]=  "ProcesarCuentasCtables(2,this)";
					ConfigColGridCierre(2,e.Item.Cells[2]);
					e.Item.Cells[3].Attributes[Enumerados.EventosJavaScript.Ondblclick.ToString()]=  "ProcesarCuentasCtables(3,this)";
					ConfigColGridCierre(3,e.Item.Cells[3]);
					e.Item.Cells[5].Attributes[Enumerados.EventosJavaScript.Ondblclick.ToString()]=  "ProcesarCuentasCtables(4,this)";
					ConfigColGridCierre(4,e.Item.Cells[5]);
					e.Item.Cells[6].Attributes[Enumerados.EventosJavaScript.Ondblclick.ToString()]=  "ProcesarCuentasCtables(5,this)";
					ConfigColGridCierre(5,e.Item.Cells[6]);
					e.Item.Cells[7].Attributes[Enumerados.EventosJavaScript.Ondblclick.ToString()]=  "ProcesarCuentasCtables(6,this)";
					ConfigColGridCierre(6,e.Item.Cells[7]);
					e.Item.Cells[9].Attributes[Enumerados.EventosJavaScript.Ondblclick.ToString()]=  "ProcesarCuentasCtables(7,this)";
					ConfigColGridCierre(7,e.Item.Cells[9]);
					e.Item.Cells[10].Attributes[Enumerados.EventosJavaScript.Ondblclick.ToString()]=  "ProcesarCuentasCtables(8,this)";
					ConfigColGridCierre(8,e.Item.Cells[10]);
					e.Item.Cells[11].Attributes[Enumerados.EventosJavaScript.Ondblclick.ToString()]=  "ProcesarCuentasCtables(9,this)";
					ConfigColGridCierre(9,e.Item.Cells[11]);
					e.Item.Cells[13].Attributes[Enumerados.EventosJavaScript.Ondblclick.ToString()]=  "ProcesarCuentasCtables(10,this)";
					ConfigColGridCierre(10,e.Item.Cells[13]);
					e.Item.Cells[14].Attributes[Enumerados.EventosJavaScript.Ondblclick.ToString()]=  "ProcesarCuentasCtables(11,this)";
					ConfigColGridCierre(11,e.Item.Cells[14]);
					e.Item.Cells[15].Attributes[Enumerados.EventosJavaScript.Ondblclick.ToString()]= "ProcesarCuentasCtables(12,this)";
					ConfigColGridCierre(12,e.Item.Cells[15]);

					e.Item.Cells[0].Visible=false;//para conbinar la columna 1

				}
				else if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
				{
					DataRowView drv = (DataRowView)e.Item.DataItem;
					DataRow dr = drv.Row;			

			
					e.Item.Attributes.Add("IDRUBRO",dr[Enumerados.ColumnasFormato.IdRubro.ToString()].ToString());
					e.Item.Attributes.Add("IDTIPOLINEA",dr[Enumerados.ColumnasFormato.IdTipoLinea.ToString()].ToString());
					e.Item.Attributes.Add("VERMONTO",dr[Enumerados.ColumnasFormato.FlgVerMonto.ToString()].ToString());
					e.Item.Attributes.Add("NIVEL",((Convert.ToInt32(dr["DetalleNota"].ToString())>0)?"2":dr[Enumerados.ColumnasFormato.idNivel.ToString()].ToString()));

					//e.Item.Attributes.Add("OBSERVACIONES",dr[Enumerados.ColumnasFormato.Observacion.ToString()].ToString());

					if (dr[Enumerados.ColumnasFormato.FormulaFormato.ToString()].ToString().Length>0)
					{
						stridFila += (e.Item.ItemIndex+NroFilaIni).ToString() + Utilitario.Constantes.SIGNOPUNTOYCOMA;
						lstPrioridad +=dr[Enumerados.ColumnasFormato.idPrioridad.ToString()].ToString()+ Utilitario.Constantes.SIGNOPUNTOYCOMA;
						//e.Item.Attributes.Add("CONFORMULA","SI");
						e.Item.Attributes.Add("PRIORIDAD",dr[Enumerados.ColumnasFormato.idPrioridad.ToString()].ToString());
					}

					grid.Attributes.Add("FILAFORMULA",stridFila);
					grid.Attributes.Add("LSTPRIORIDAD",lstPrioridad);
				


	
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



					if(Convert.ToInt32(dr[Enumerados.ColumnasFormato.NroHijos.ToString()])==0)
					{
					
					}
					else
					{

					}	
					dr["verDetalle"] = (((dr["FormulaFormato"].ToString().Length>0)||(Convert.ToInt32(dr["FlgVerMonto"])==0))?0:1);
					dr.AcceptChanges();

					string Parametros =KEYQIDFORMATO + Constantes.SIGNOIGUAL + Page.Request.Params[KEYQIDFORMATO]
						+ Constantes.SIGNOAMPERSON
						+ KEYQIDREPORTE + Constantes.SIGNOIGUAL + Page.Request.Params[KEYQIDREPORTE]
						+ Constantes.SIGNOAMPERSON
						+ KEYQIDRUBRO + Constantes.SIGNOIGUAL + dr["idRubro"].ToString()
						+ Constantes.SIGNOAMPERSON
						+ IDCENTROOPERATIVO + Constantes.SIGNOIGUAL + Page.Request.Params[IDCENTROOPERATIVO]
						+ Constantes.SIGNOAMPERSON
						+ KEYQIDCENTROCOSTO + Constantes.SIGNOIGUAL + idCentroCosto.ToString()
						+ Constantes.SIGNOAMPERSON
						+ KEYQPERIODO + Constantes.SIGNOIGUAL + Page.Request.Params[KEYQPERIODO]
						+ Constantes.SIGNOAMPERSON
						+ KEYQIDTIPOINFO + Constantes.SIGNOIGUAL + Page.Request.Params[KEYQIDTIPOINFO]
						+ Constantes.SIGNOAMPERSON
						+ KEYQNOMBRERUBRO  + Constantes.SIGNOIGUAL + dr["Concepto"].ToString()
						+ Constantes.SIGNOAMPERSON
						+ KEYQNROFILAINI + Constantes.SIGNOIGUAL + (e.Item.ItemIndex+NroFilaIni+1).ToString()
						+ Constantes.SIGNOAMPERSON
						+ KEYQREQCC  + Constantes.SIGNOIGUAL + Page.Request.Params[KEYQREQCC];
					//Se suma ma 1 por la columna nro cero la cabecera tiene una combinacion de 2 filas que hacen una.

					/*Utilitario.Helper.ConfiguraNodosTreeview(e,2,0,dr,Utilitario.Constantes.POPUPDEESPERA
																	,Helper.HistorialIrAdelantePersonalizado(Utilitario.Constantes.VACIO)
																	,"(new SIMA.Utilitario.Helper.General.Pagina()).Response.ShowDialogoNoModal('" + URLPAGINADETALLE + Parametros + "',screen.width,screen.height-300);"
																	);*/
					string IdGrupoInterconexion ="0";
					string IdFormatoConectado ="0";
					string IdReporteConectado ="0";

					DataTable dt = (new CFormatoReporteInterconexion()).Listar(this.IdFormato,this.IdReporte,Convert.ToInt32(dr[Enumerados.ColumnasFormato.IdRubro.ToString()].ToString()));
					if(dt!=null&&dt.Rows.Count>0)
					{
						foreach(DataRow drN in dt.Rows)
						{
							IdGrupoInterconexion= drN["IdGrupoInterConex"].ToString();
							IdFormatoConectado = drN["IdFormatoInterConex"].ToString();
							IdReporteConectado = drN["IdReporteInterConex"].ToString();
						}
					}

					Utilitario.Helper.ConfiguraNodosTreeview(e,2,0,dr,"DetalleContablePorItem(this.parentNode.parentNode.parentNode.parentNode.parentNode);");

					Utilitario.Helper.SeleccionarItemGrillaOnClickMoverRaton(e,"ObtenerIdRubro('" +dr["idRubro"].ToString() + "','" + dr["FormEntreRubro"].ToString() + "','" + IdGrupoInterconexion + "','" + IdFormatoConectado + "','" + IdReporteConectado + "');MostrarDatosEnCajaTexto('hidFilaSeleccionada',ObtenerRowId(this));" + Helper.MostrarDatosEnCajaTexto("hNroNivel",dr[Enumerados.ColumnasFormato.NroNivel.ToString()].ToString()));
				}	
			}
			catch(Exception ex){
				string mMs = ex.Message;
				string h = mMs;
				int err=1;
				err++;
			}
		}
		
		void ConfigColGridCierre(int Mes,System.Web.UI.WebControls.TableCell tCell){
			this.hIdMes.Value=Mes.ToString();
			if(this.Cerrado==1)
			{
				otblH =  Helper.CrearHtmlTabla(1,3);
				otblH.Rows[0].Cells[0].InnerText=Helper.ObtenerNombreMes(Mes,SIMA.Utilitario.Enumerados.TipoDatoMes.NombreCompleto);
				otblH.Rows[0].Cells[0].Attributes.Add("class","headergrilla");

				System.Web.UI.WebControls.Image oimgC = new System.Web.UI.WebControls.Image();
				oimgC.ImageUrl= Page.Request.ApplicationPath +"/imagenes/EvaluacionPersonal/Cerrado.png";
				otblH.Rows[0].Cells[1].Controls.Add(oimgC);
				otblH.Rows[0].Cells[1].Style.Add("PADDING-LEFT","10px");
				tCell.Attributes.Add("CERRADO","1");
				tCell.Controls.Add(otblH);
			}
			else{
				tCell.Attributes.Add("CERRADO","0");
			}
		}
		
		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void grid_PreRender(object sender, System.EventArgs e)
		{
		}

		private void grid_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType==ListItemType.Header)
			{
				
				DataGridItem di = new DataGridItem(e.Item.ItemIndex-1,0,ListItemType.Header);
				for(int i=0;i<=grid.Columns.Count-1;i++)
				{
					TableCell tc = new TableCell();
					if(i==0){
						tc.RowSpan=2;
						tc.Style.Add("width","25%");
						//tc.Controls.Add(new LiteralControl("CONCEPTO"));

						HtmlTable oTblHtml = Utilitario.Helper.CrearHtmlTabla(2,1);
						oTblHtml.Style.Add("height","100%");
						oTblHtml.Style.Add("width","100%");
						oTblHtml.Rows[0].Cells[0].InnerText="CONCEPTO";
						oTblHtml.Rows[0].Cells[0].Attributes.Add("class","headergrilla");
						oTblHtml.Border=0;
						oTblHtml.Rows[0].Style.Add("height","100%");

						HtmlTable oTblop = Utilitario.Helper.CrearHtmlTabla(1,3);
						System.Web.UI.WebControls.Image oImg = new System.Web.UI.WebControls.Image();
						oImg.ImageUrl = Page.Request.ApplicationPath + "/imagenes/Navegador/txt.png";
						oImg.Attributes.Add(Utilitario.Constantes.EVENTOCLICK.ToString(),"FormulaContable(this);");
						oTblop.Rows[0].Cells[0].Controls.Add(oImg);
						
						oTblHtml.Rows[1].Cells[0].Controls.Add(oTblop);
						oTblHtml.Rows[1].Cells[0].Align="right";

						tc.Controls.Add(oTblHtml);

					}
					else if((i==1)||(i==5)||(i==9)||(i==13))
					{
						string TITULO="TRIM ";
						tc.ColumnSpan=1;

						switch(i){
							case 1:
								TITULO =TITULO +"I";
								break;
							case 5:
								TITULO =TITULO +"II";
								break;
							case 9:
								TITULO =TITULO +"III";
								break;
							case 13:
								TITULO =TITULO +"IV";
								break;
						}
						tc.ID = TITULO.Replace(" ","");

						HtmlTable oHtmlTable = Helper.CrearTabla(1,2);
						oHtmlTable.Rows[0].Attributes.Add("class","HeaderGrilla");
						oHtmlTable.Rows[0].Cells[0].Controls.Add(new LiteralControl("<IMG id='" + TITULO.Replace(" ","") + "' ColIni=" + i.ToString() + " src='../../imagenes/tree/plusCol.gif' onclick='CollapseCol(this)'>"));
						oHtmlTable.Rows[0].Cells[1].InnerText=TITULO;
						tc.Controls.Add(oHtmlTable);
					}
					else if((i>1 && i<=4)||(i>5 && i<=8)||(i>9 && i<=12)||(i>13 && i<=16))
					{
						tc.Visible=false;
					}
					di.Cells.Add(tc);
				}
				DataGrid dg = (DataGrid)sender;
				Table t = (Table)dg.Controls[0];
				t.Rows.Add(di);
			}
		
		}
		private void ProcesarFormato()
		{
			if(this.ReqCtaCtable==1)
			{
				(new SIMA.Controladoras.GestionFinanciera.CFormatoDetalleMovimiento()).ProcesarFormatoEstadosFinancierosRubros(this.IdFormato, this.IdReporte, this.IdCentroOperativo, this.Periodo, this.IdMes,this.FormatoAcumulado);
			}
			else if(this.ReqCtaCtable==2)
			{
				(new SIMA.Controladoras.GestionFinanciera.CFormatoDetalleMovimiento()).ProcesarFormatoxNotaContable(this.IdFormato, this.IdReporte, this.IdCentroOperativo, this.Periodo, this.IdMes,this.FormatoAcumulado);
			}
			else if(this.ReqCtaCtable==3)
			{
				(new SIMA.Controladoras.GestionFinanciera.CFormatoDetalleMovimiento()).ProcesarFormatoInterconexion(this.IdFormato, this.IdReporte, this.IdCentroOperativo, this.Periodo, this.IdMes,this.FormatoAcumulado);
			}
		}

		string AlertaCierre="No es posible iniciar el proceso, el mes seleccionado se encuentra Cerrado..";
		private void ImportarSaldos()
		{
			if(this.Cerrado==0)
			{
				(new SIMA.Controladoras.GestionFinanciera.CFormatoDetalleMovimiento()).ImportarUnisysSaldosContables(this.IdCentroOperativo,this.Periodo, this.IdMes);
				if(this.ReqCtaCtable==1)
				{
					(new SIMA.Controladoras.GestionFinanciera.CFormatoDetalleMovimiento()).ProcesarFormatoEstadosFinancierosRubros(this.IdFormato, this.IdReporte, this.IdCentroOperativo, this.Periodo, this.IdMes, 0);
				}
				else if(this.ReqCtaCtable==2)
				{
					(new SIMA.Controladoras.GestionFinanciera.CFormatoDetalleMovimiento()).ProcesarFormatoxNotaContable(this.IdFormato, this.IdReporte, this.IdCentroOperativo, this.Periodo, this.IdMes,this.FormatoAcumulado);
				}

			}
			else{
				Utilitario.Helper.MsgBox("Control de Cierre",AlertaCierre,Utilitario.Enumerados.Ext.MessageBox.Button.OK,Utilitario.Enumerados.Ext.MessageBox.Icon.INFO);
			}
			this.ProcesarFormato();
		}

		private void btnPrc_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (Page.IsValid)
				{
					if(this.Cerrado==0)
					{
						LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(), "Gestión Financiera:ESATDOS FINANCIEROS"  , this.ToString(),"Inicio Proceso formato " + this.IdFormato.ToString(),Enumerados.NivelesErrorLog.I.ToString()));
						this.hIdMes.Value=this.PjsIdMes;
						this.ProcesarFormato();
						LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(), "Gestión Financiera:ESATDOS FINANCIEROS"  , this.ToString(),"Termino con exito Proceso formato " + this.IdFormato.ToString(),Enumerados.NivelesErrorLog.I.ToString()));

						this.LlenarGrilla();

					}
					else
					{
						Utilitario.Helper.MsgBox("Control de Cierre",AlertaCierre,Utilitario.Enumerados.Ext.MessageBox.Button.OK,Utilitario.Enumerados.Ext.MessageBox.Icon.INFO);
					}
				}
			}
			catch (SIMAExcepcionLog sIMAExcepcionLog)
			{
				Helper.MsgBox(sIMAExcepcionLog.Mensaje);
			}
			catch (SIMAExcepcionIU sIMAExcepcionIU)
			{
				Helper.MsgBox(sIMAExcepcionIU.Mensaje);
			}
			catch (SIMAExcepcionDominio sIMAExcepcionDominio)
			{
				Helper.MsgBox(sIMAExcepcionDominio.Error.ToString());
			}
			catch (Exception ex)
			{
				//ex.get_Message().ToString();
				SIMAExcepcionIU sIMAExcepcionIU2 = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(), this.GetType().Name, Enumerados.OrigenError.Presentacion.ToString(), Constantes.CODIGOERRORGENERICO, ex.Message);
				Helper.ControlarErrorIU(this, sIMAExcepcionIU2.Mensaje);
			}
		}

		

		private void cmdImportarSaldos1_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (Page.IsValid)
				{
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(), "Gestión Financiera:ESATDOS FINANCIEROS"  , this.ToString(),"Inicio importación de Saldos Contables " ,Enumerados.NivelesErrorLog.I.ToString()));
					this.hIdMes.Value=this.PjsIdMes;
					this.ImportarSaldos();
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(), "Gestión Financiera:ESATDOS FINANCIEROS"  , this.ToString(),"Termino con exito importación de Saldos Contables " ,Enumerados.NivelesErrorLog.I.ToString()));
					//this.ProcesarFormato();
					this.LlenarGrilla();
					//Page.RegisterStartupScript("Cal","<script>var DataGrid=$O('grid'); Inicializar(DataGrid);ProcesarCalculodeFormato('" + PjsIdxCell + "');ModificarItems(DataGrid,'" + PjsIdxCell + "');</script>");
				}
			}
			catch (SIMAExcepcionLog sIMAExcepcionLog)
			{
				Helper.MsgBox(sIMAExcepcionLog.Mensaje);
			}
			catch (SIMAExcepcionIU sIMAExcepcionIU)
			{
				Helper.MsgBox(sIMAExcepcionIU.Mensaje);
			}
			catch (SIMAExcepcionDominio sIMAExcepcionDominio)
			{
				Helper.MsgBox(sIMAExcepcionDominio.Error.ToString());
			}
			catch (Exception ex)
			{
				//ex.get_Message().ToString();
				SIMAExcepcionIU sIMAExcepcionIU2 = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(), this.GetType().Name, Enumerados.OrigenError.Presentacion.ToString(), Constantes.CODIGOERRORGENERICO, ex.Message);
				Helper.ControlarErrorIU(this, sIMAExcepcionIU2.Mensaje);
			}		
		}

		private void btnExportaXLS_Click(object sender, System.EventArgs e)
		{
			DataTable dt=(new CFormatoRubroDetalleMovimiento()).ConsultarFormatoRubroDetalleMovimientoCta(Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO]), Convert.ToInt32(Page.Request.Params[KEYQIDREPORTE]), Convert.ToInt32(Page.Request.Params[KEYQPERIODO]), Convert.ToInt32(Page.Request.Params["idcop"]), Convert.ToInt32(Page.Request.Params[KEYQIDTIPOINFO]),0);
			GenerarReporte(dt,false);
		}

		string []NColumna = {"ENERO","FEBRERO","MARZO","TOTAL","ABRIL","MAYO","JUNIO","TOTAL","JULIO","AGOSTO","SETIEMBRE","TOTAL","OCTUBRE","NOVIEMBRE","DICIEMBRE","TOTAL"};
		string []HColumna = {"B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q"};
		
		public void GenerarReporte(DataTable dtformato,bool Detallado)
		{
			object misValue = System.Reflection.Missing.Value;
			Excel.Application xlApp = new Excel.Application();
			Excel.Workbook wb = xlApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
			xlApp.Visible = true;
			Excel.Worksheet ws = (Excel.Worksheet)wb.Worksheets[1];
			ws.Name=CNetAccessControl.GetUserApellidosNombres().Substring(0,25);

			Excel.Range  aRangeImg = ws.get_Range( "A1", "A1");

			float fLeft =float.Parse(aRangeImg.Left.ToString());
			float fTop =float.Parse(aRangeImg.Top.ToString());
					
			float fAncho =float.Parse("140");
			float fAlto=float.Parse("60");

			ws.Shapes.AddPicture(@"C:\SimanetReportes\LOGOSIMA_azul.png", 
				Microsoft.Office.Core.MsoTriState.msoFalse,
				Microsoft.Office.Core.MsoTriState.msoCTrue,
				fLeft, fTop,
				fAncho, fAlto);			

			Excel.Range  aRangeTit = ws.get_Range( "E3", "E3");
			aRangeTit.Value2=Page.Request.Params["NFormato"];
			aRangeTit.Font.Size=14;
			aRangeTit.Font.Bold=true;

			//xlApp.SheetBeforeDoubleClick += new Excel.AppEvents_SheetBeforeDoubleClickEventHandler(myExcelApp_SheetBeforeDoubleClick); 
			/****************************************************************************************************************/
			ConfiguraCabecera(ws);
			/****************************************************************************************************************/
			int FilaIniDet=9;
			//Dtella de formato
			if(dtformato!=null){
				foreach(DataRow dr in dtformato.Rows){
					Excel.Range  aRange = ws.get_Range( "A"+FilaIniDet.ToString(), "A"+FilaIniDet.ToString());
					aRange.Value2 = dr["Concepto"].ToString();
					if (dr["IdTipoLinea"].ToString()=="3"){
						aRange = ws.get_Range( "A"+FilaIniDet.ToString(), HColumna[HColumna.Length-1]+FilaIniDet.ToString());
						ConfiguraBordeCeldaTit(aRange,"Yellow");
					}
					if ((dr["IdTipoLinea"].ToString()=="1")||(dr["IdTipoLinea"].ToString()=="2"))
					{
						aRange = ws.get_Range( "A"+FilaIniDet.ToString(), HColumna[HColumna.Length-1]+FilaIniDet.ToString());
						ConfiguraBordeCelda(aRange);
					}

					if (dr["FlgVerMonto"].ToString()=="1")
					{
						for(int x=0;x<=HColumna.Length-1;x++)
						{
							string ColXls=HColumna[x]+FilaIniDet.ToString();
							aRange = ws.get_Range( ColXls, ColXls);
							string NombreCampo=NombreColumna(x, NColumna[x]);
							
							aRange.HorizontalAlignment =  (Microsoft.Office.Interop.Excel.XlHAlign)System.Enum.Parse(typeof(Microsoft.Office.Interop.Excel.XlHAlign),"xlHAlignRight");
							aRange .Font.Size=9;
							aRange.Font.Name = "Arial";
							aRange.NumberFormat="#,###,###.00";
							string SValor=dr[NombreCampo].ToString();
							aRange.Value2 = Convert.ToDouble(SValor);
							aRange.Locked=true;
						}
					}

					FilaIniDet++;
				}
			}

			string NombreArchivo =Session.SessionID.ToString()+ DateTime.Now.ToShortDateString().Replace("/","") + (DateTime.Now.ToShortTimeString().Replace(":","").Replace(".","")).ToString().Trim().Replace(" ","")  + DateTime.Now.Second.ToString() + ".xls";
			string RutaFisica= System.Configuration.ConfigurationSettings.AppSettings[Utilitario.Constantes.RUTALOCALRPTTMP].ToString();
			wb.SaveAs(RutaFisica+NombreArchivo, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
			wb.Close(true, misValue, misValue);
			xlApp.Quit();
			wb=null;
			xlApp=null;
			

			string FilePath = System.Configuration.ConfigurationSettings.AppSettings[Utilitario.Constantes.RUTASERVERRPTTMP].ToString() + NombreArchivo;

			string script = "window.open('" + FilePath + "','_blank');";
			Helper.JavaScript.RegistrarScript("Reg",script);
		}

		string NombreColumna(int idx,string Valor)
		{
			string Nombre ="";
			switch(idx){
				case 3:
					Nombre="TrimI";
					break;
				case 7:
					Nombre="TrimII";
					break;
				case 11:
					Nombre="TrimIII";
					break;
				case 15:
					Nombre="TrimIV";
					break;
				default:
					Nombre=Valor;
					break;
			}
			return Nombre;
		}

		void ConfiguraCabecera(Excel.Worksheet ws){
			Excel.Range  aRange = ws.get_Range("A6", "A6");
			aRange.Value2 = "CONCEPTO";
			aRange = ws.get_Range("A6", "A7");
			aRange.Merge(Type.Missing);
			aRange.ColumnWidth=50;
			aRange.HorizontalAlignment =  (Microsoft.Office.Interop.Excel.XlHAlign)System.Enum.Parse(typeof(Microsoft.Office.Interop.Excel.XlHAlign),"xlHAlignCenter");
			aRange.VerticalAlignment =  (Microsoft.Office.Interop.Excel.XlVAlign)System.Enum.Parse(typeof(Microsoft.Office.Interop.Excel.XlVAlign),"xlVAlignCenter");
			ConfiguraBordeCelda(aRange);

			for(int x=0;x<=NColumna .Length-1;x++)
			{
				if(x==0)
				{
					aRange = ws.get_Range("B6", "B6");
					aRange.Value2 = "TRIM I";
					aRange = ws.get_Range("B6", "E6");
					aRange.Merge(Type.Missing);
					ConfiguraBordeCelda(aRange);
				}
				else if(x==4)
				{
					aRange = ws.get_Range("F6", "F6");
					aRange.Value2 = "TRIM II";
					aRange = ws.get_Range("F6", "I6");
					aRange.Merge(Type.Missing);
					ConfiguraBordeCelda(aRange);
				}
				else if(x==8)
				{
					aRange = ws.get_Range("J6", "J6");
					aRange.Value2 = "TRIM III";
					aRange = ws.get_Range("J6", "M6");
					aRange.Merge(Type.Missing);
					ConfiguraBordeCelda(aRange);
				}
				else if(x==12)
				{
					aRange = ws.get_Range("N6", "N6");
					aRange.Value2 = "TRIM IV";
					aRange = ws.get_Range("N6", "Q6");
					aRange.Merge(Type.Missing);
					ConfiguraBordeCelda(aRange);
				}
				string rColum = HColumna[x];
				string tColum = NColumna[x];
				aRange = ws.get_Range(rColum+"7", rColum+"7");
				aRange.Value2 = tColum;

				ConfiguraBordeCelda(aRange);
			}

			aRange = ws.get_Range("A6", "Q7");
			aRange.HorizontalAlignment =  (Microsoft.Office.Interop.Excel.XlHAlign)System.Enum.Parse(typeof(Microsoft.Office.Interop.Excel.XlHAlign),"xlHAlignCenter");
			aRange.VerticalAlignment =  (Microsoft.Office.Interop.Excel.XlVAlign)System.Enum.Parse(typeof(Microsoft.Office.Interop.Excel.XlVAlign),"xlVAlignCenter");
			aRange .Font.Size=10;
			aRange.Font.Bold=true;
			aRange.Font.Name = "Arial";
			aRange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml("Black"));
			aRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml("Yellow"));
			
		}

		void ConfiguraBordeCelda(Excel.Range  MiRange){
			MiRange.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop].LineStyle =  (Microsoft.Office.Interop.Excel.XlLineStyle) System.Enum.Parse(typeof(Microsoft.Office.Interop.Excel.XlLineStyle),"xlContinuous");
			MiRange.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].LineStyle =  (Microsoft.Office.Interop.Excel.XlLineStyle) System.Enum.Parse(typeof(Microsoft.Office.Interop.Excel.XlLineStyle),"xlContinuous");
			MiRange.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft].LineStyle =  (Microsoft.Office.Interop.Excel.XlLineStyle) System.Enum.Parse(typeof(Microsoft.Office.Interop.Excel.XlLineStyle),"xlContinuous"); 
			MiRange.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight].LineStyle =(Microsoft.Office.Interop.Excel.XlLineStyle) System.Enum.Parse(typeof(Microsoft.Office.Interop.Excel.XlLineStyle),"xlContinuous");  
		}
		void ConfiguraBordeCeldaTit(Excel.Range  MiRange,string MiColor)
		{
			MiRange.Font.Size=10;
			MiRange.Font.Bold=true;
			MiRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml(MiColor));
			MiRange.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop].LineStyle =  (Microsoft.Office.Interop.Excel.XlLineStyle) System.Enum.Parse(typeof(Microsoft.Office.Interop.Excel.XlLineStyle),"xlContinuous");
			MiRange.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].LineStyle =  (Microsoft.Office.Interop.Excel.XlLineStyle) System.Enum.Parse(typeof(Microsoft.Office.Interop.Excel.XlLineStyle),"xlContinuous");
		}

		private void btnResumenyDetalleXLS_Click(object sender, System.EventArgs e)
		{
			FormatoBE oFormatoBE = (FormatoBE)(new CFormato()).DetalleFormato(this.IdFormato,this.IdReporte);
			if(oFormatoBE.RunReportCenter==1){
				DataSet dsGeneric= new DataSet("sw");
				DataTable dt= (new SIMA.Controladoras.GestionFinanciera.CFormatoReporteDetalleAnual()).Listar(this.IdFormato,this.IdReporte,this.IdCentroOperativo.ToString(),this.Periodo,0);
				DataTable dtx =  Helper.DataViewTODataTable(dt.DefaultView);
				dsGeneric.Tables.Add(dtx);

				//ReportesXLS oReportesXLS=new ReportesXLS(520,1);
				ReportesXLS oReportesXLS=new ReportesXLS();
				oReportesXLS.IdReporte=520;
				oReportesXLS.AutoAjuste=1;
				oReportesXLS.CrearDataTableDependencias();
				oReportesXLS.dsData = dsGeneric;
				oReportesXLS.GenerarReporte(false);


			}
			else
			{
				DataTable dt=(new CFormatoRubroDetalleMovimiento()).ConsultarFormatoRubroDetalleMovimientoCta(Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO]), Convert.ToInt32(Page.Request.Params[KEYQIDREPORTE]), Convert.ToInt32(Page.Request.Params[KEYQPERIODO]), Convert.ToInt32(Page.Request.Params["idcop"]), Convert.ToInt32(Page.Request.Params[KEYQIDTIPOINFO]),1);
				GenerarReporte(dt,true);
			}
		}

	}
	
}
