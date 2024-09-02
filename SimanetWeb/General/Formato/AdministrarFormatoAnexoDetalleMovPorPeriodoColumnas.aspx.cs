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
	/// Summary description for AdministrarFormatoAnexoDetalleMovPorPeriodoColumnas.
	/// </summary>
	public class AdministrarFormatoAnexoDetalleMovPorPeriodoColumnas : System.Web.UI.Page,IPaginaBase
	{
		protected System.Web.UI.WebControls.Label lblDescripcion;
		protected System.Web.UI.WebControls.RadioButton R3;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Button btnPrc;
		protected System.Web.UI.WebControls.Button btnExportaXLS;
		protected System.Web.UI.WebControls.Button cmdImportarSaldos1;
		protected System.Web.UI.WebControls.Button btnResumenyDetalleXLS;
		protected System.Web.UI.WebControls.Button btnMostrarMes;
		protected System.Web.UI.HtmlControls.HtmlTableCell LstUser;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hNombreImgTrim;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdMes;
		
		protected projDataGridWeb.DataGridWeb  ItemsGrid;

		
		
		#region Constantes
		const string KEYQIDFORMATO="IdFormato";
		const string KEYQIDREPORTE = "IdReporte";
		const string KEYQIDRUBRO ="IdRubro";

		const string KEYQNOMBRERUBRO ="NombreRubro";
		const string URLITEMDETALLE = "AdministrarFormatoItemDetalleMovimientoporPeriodo.aspx?";
		const string KEYQPERIODO = "Periodo";
		const string KEYQIDMES = "IdMes";
		const string KEYQIDCOLUMNA="IdCol";

		const string KEYQIDGRUPOFORMATO="IdGrupoFormato";
		const string IDCENTROOPERATIVO="idcop";
		//const string  KEYQIDGRUPOCC = "idGrpCC";
		const string KEYQIDCENTROCOSTO ="idCC";
		const string KEYQIDTIPOINFO ="idTipoInfo";

		const string KEYQIDTIPOFORMATO ="IdTipForm";

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
		public int IdCentroCosto
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDCENTROCOSTO]);}
		}
		public int Periodo
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQPERIODO]);}
		}
		public int IdMes
		{
			get{if(this.hIdMes.Value=="0"){this.hIdMes.Value="1";}
				return Convert.ToInt32(this.hIdMes.Value);}
		}

		public int IdFormato
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO]);}
		}
		public int IdReporte
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDREPORTE]);}
		}

		public int ReqCtaCtable
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQREQCTACTABLE]);}
		}
		public int FormatoAcumulado
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQACUMULADO]);}
		}

		public int IdTipoInformacion
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDTIPOINFO]);}
		}

		public int IdTipoFormato
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDTIPOFORMATO]);}
		}

		public int Cerrado
		{
			get
			{
				DataTable DTC =  ((CControlCierreEstadoFinanciero) new  CControlCierreEstadoFinanciero()).AdministrarDetalleControlCierreEstadoFinanciero(this.IdCentroOperativo,this.IdTipoInformacion,this.Periodo,this.IdMes);
				return Convert.ToInt32(DTC.Rows[0]["IdEstado"]);
			}
		}


		
		#endregion

		int NroFilaIni = 2;
		DataTable dt;
		int Idcc=0;

		string stridFila ="";
		string lstPrioridad="";

		string ParamArgument="";
		private int NFila = 1;
		HtmlTable otblH;


		string AlertaCierre="No es posible iniciar el proceso, el mes seleccionado se encuentra Cerrado..";
		protected System.Web.UI.WebControls.PlaceHolder PlaceHGrid;
		protected System.Web.UI.WebControls.Image ImgProcesar;
	
	

		const string DATACOLUMN = "dtc";
		int NroCeldas=0;
		DataTable dtc;
		protected System.Web.UI.WebControls.DropDownList ddlMesSelect;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Button btnRefresh;
		protected System.Web.UI.WebControls.RadioButton R1;
		protected System.Web.UI.WebControls.RadioButton R2;
		protected System.Web.UI.WebControls.RadioButton R4;
		protected System.Web.UI.WebControls.RadioButton R5;
		protected System.Web.UI.WebControls.RadioButton R6;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hOpSelected;
		int NivelMax =0;

		private void Page_Load(object sender, System.EventArgs e)
		{
			 Page.GetPostBackEventReference(this, "MyEventArgumentName");

			try
			{
				ParamArgument=Page.Request.Params["__EVENTARGUMENT"];
				if((ParamArgument!=null)&&(ParamArgument.Length>0))
				{
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

		HtmlTable TblHeader(string Titulo)
		{
			return TblHeader(Titulo,0);
		}

		HtmlTable TblHeader(string Titulo,int IdColumna)
		{
			HtmlTable oTblHtml = Utilitario.Helper.CrearHtmlTabla(2,1);
			oTblHtml.Style.Add("height","100%");
			oTblHtml.Style.Add("width","100%");
			oTblHtml.Rows[0].Cells[0].InnerHtml=Titulo;
			oTblHtml.Rows[0].Cells[0].Attributes.Add("class","headergrilla");
			oTblHtml.Border=0;
			oTblHtml.Rows[0].Style.Add("height","100%");

			HtmlTable oTblop = Utilitario.Helper.CrearHtmlTabla(1,3);
			System.Web.UI.WebControls.Image oImg = new System.Web.UI.WebControls.Image();
			oImg.ImageUrl = Page.Request.ApplicationPath + "/imagenes/Navegador/txt.png";
			oImg.Attributes.Add(Utilitario.Constantes.EVENTOCLICK.ToString(),"FormulaContable(this," + IdColumna.ToString() +");");
			oTblop.Rows[0].Cells[0].Controls.Add(oImg);
							
			oTblHtml.Rows[1].Cells[0].Controls.Add(oTblop);
			oTblHtml.Rows[1].Cells[0].Align="right";

			return oTblHtml;
		}
		
		
		private void CrearGrilla()
		{
			/*Estilos a la grilla*/
			ItemsGrid = new  projDataGridWeb.DataGridWeb();
			this.ItemsGrid.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dGeneral_ItemCreated);
			this.ItemsGrid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dGeneral_ItemDataBound);
			
			ItemsGrid.HeaderStyle.CssClass="HeaderGrilla";
			ItemsGrid.ItemStyle.CssClass="ItemGrilla";
			ItemsGrid.AlternatingItemStyle.CssClass="Alternateitemgrilla";

			/*Enalza eventos*/
			ItemsGrid.ID = "grid";
			ItemsGrid.CellPadding = 3;
			ItemsGrid.AutoGenerateColumns = false;
			ItemsGrid.Columns.Clear();

			dtc = (new CFormatoReporteColumna()).Listar(this.IdFormato,this.IdReporte);

			System.Web.UI.WebControls.BoundColumn Bcolumn = new System.Web.UI.WebControls.BoundColumn();
			Bcolumn.DataField = "Concepto";
			Bcolumn.HeaderText = "CONCEPTO";
			Bcolumn.ItemStyle.Wrap=true;
			Bcolumn.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
			
			ItemsGrid.Columns.Add(Bcolumn);

			if(dtc!=null)
			{
				NivelMax = Convert.ToInt32(dtc.Rows[0]["NivelMax"].ToString());
				foreach(DataRow dr in dtc.Rows)
				{
					if(dr["NroHijos"].ToString().Equals("0"))
					{
						System.Web.UI.WebControls.TemplateColumn Tcolumn = new System.Web.UI.WebControls.TemplateColumn();
						Tcolumn.HeaderText= dr["TituloCampo"].ToString().ToUpper();
						ItemsGrid.Columns.Add(Tcolumn);
						NroCeldas++;
					}
				}
				ItemsGrid.Attributes.Add("NROMAXCOLUMN",(NroCeldas+1).ToString());
			}
			try
			{
				PlaceHGrid.Controls.Add(ItemsGrid);
			}
			catch(Exception ex){}
		}


		void ConfigGridColumn(){

		}

		int NroCell=1;
		int NroFilaH=1;
		int IdxCell=1;
		private void dGeneral_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType==ListItemType.Header)
			{
				if(NivelMax==0)
				{
					e.Item.Cells[0].Controls.Add(TblHeader("CONCEPTO"));
					if(dtc!=null)
					{
						IdxCell=1;
						foreach(DataRow drc in dtc.Rows)
						{
							int NroHijos = Convert.ToInt32(drc["NroHijos"].ToString());
							string TituloCol = drc["TituloCampo"].ToString();
							if(NroHijos.ToString().Equals("0"))
							{
								if(drc["IdTipoPRCColumn"].ToString().Equals("5"))//Columna para configurar cuenta contable
								{
									e.Item.Cells[IdxCell].Controls.Add(TblHeader(TituloCol,Convert.ToInt32(drc["IdColumna"].ToString())));
								}
								//original e.Item.Cells[IdxCell].Attributes.Add(Utilitario.Constantes.EVENTODBLCLICK.ToString(),"DetalleColumna('" + drc["IdColumna"].ToString() + "');");

								e.Item.Cells[IdxCell].Attributes.Add(Utilitario.Constantes.EVENTODBLCLICK.ToString(),"ProcesarCuentasCtables();");
								IdxCell++;
							}
						}
					}

				}
				else
				{
					for(int f=1;f<=NivelMax;f++)
					{
						DataGridItem di = new DataGridItem(e.Item.ItemIndex-1,0,ListItemType.Header);
						TableCell tc = new TableCell();
						//tc.Text="CONCEPTO";
						tc.Controls.Add(TblHeader("CONCEPTO"));
						di.Cells.Add(tc);
						tc.RowSpan=(NivelMax+1);

						DataGrid dg = (DataGrid)sender;
						Table t = (Table)dg.Controls[0];
						t.Rows.Add(di);

						if(dtc!=null)
						{
							foreach(DataRow drc in dtc.Rows)
							{
								int NroHijos = Convert.ToInt32(drc["NroHijos"].ToString());
								string TituloCol = drc["TituloCampo"].ToString();
								if(NroHijos.ToString().Equals("0"))
								{
									if(drc["IdColumnaPadre"].ToString().Equals("0"))
									{
										/*Columnas Normales*/
										tc = new TableCell();
									
										if(drc["IdTipoPRCColumn"].ToString().Equals("5"))//Columna para configurar cuenta contable
										{
											tc.Controls.Add(TblHeader(TituloCol,Convert.ToInt32(drc["IdColumna"].ToString())));
										}
										else
										{
											tc.Text=TituloCol;
										}
										//original tc.Attributes.Add(Utilitario.Constantes.EVENTODBLCLICK.ToString(),"DetalleColumna('" + drc["IdColumna"].ToString() + "');");
										tc.Attributes.Add(Utilitario.Constantes.EVENTODBLCLICK.ToString(),"ProcesarCuentasCtables();");
										di.Cells.Add(tc);
									
										tc.RowSpan=(NivelMax+1);
									}
								}
								else
								{
									/*Columna de tipo Agrupacion*/
									tc = new TableCell();
									tc.Text=TituloCol;
									di.Cells.Add(tc);
									tc.ColumnSpan= NroHijos;
								}
								//Adiciona la columna  creada
								t.Rows.Add(di);
							}
						}
					}
				}
			}
			else if(e.Item.ItemType==ListItemType.Item || e.Item.ItemType==ListItemType.AlternatingItem)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;			

				NroCell=1;
				if(dtc!=null)
				{
					foreach(DataRow drc in dtc.Rows)
					{
						if(drc["NroHijos"].ToString().Equals("0"))
						{
							eWorld.UI.NumericBox nb = new eWorld.UI.NumericBox();
							nb.ID = "nBox_" + NroFilaH.ToString() +"_" + drc["IdColumna"].ToString();
							nb.Width=60;
							nb.AutoFormatCurrency= true;
							nb.BackColor= System.Drawing.Color.Transparent;
							nb.BorderColor= System.Drawing.Color.Transparent;
							nb.DecimalSign=".";
							nb.DecimalPlaces=3;
							nb.DollarSign=" ";
							nb.CssClass="NumericBox";
							nb.MaxLength=18;
							nb.PlacesBeforeDecimal=15;
							//nb.TextAlign= eWorld.UI.HorizontalAlignment.Right;
							//nb.BorderStyle=BorderStyle.None;
							nb.RealNumber=true;
						
							string NCol = "COL" + drc["IdColumna"].ToString();
							nb.Text = dr[NCol].ToString();
							nb.Attributes.Add("tag",nb.Text);
							nb.Attributes.Add("idCol",drc["IdColumna"].ToString());
							nb.Attributes.Add("idTipCol",drc["IdTipoPRCColumn"].ToString());
						
							e.Item.Cells[NroCell].Controls.Add(nb);
							e.Item.Cells[NroCell].Attributes.Add("NomCol","COL"+drc["IdColumna"].ToString());
							NroCell++;
						}
					}
					NroFilaH++;
				}
				

			}
		}	
		int NCol=1;
		private void dGeneral_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.Header)
			{
				if(dtc!=null)
				{
					if(NivelMax>0)
					{
						e.Item.Cells[0].Style.Add("display","none");
						DataRow [] drcol = dtc.Select("NroHijos=0");
						foreach(DataRow drc in drcol)
						{
							if(drc["IdColumnaPadre"].ToString().Equals("0"))
							{
								//Oculta la final 2 de la cabecera
								e.Item.Cells[NCol].Style.Add("display","none");
							}
							if(drc["IdTipoPRCColumn"].ToString().Equals("5"))//Columnas con formula Contable
							{
								e.Item.Cells[NCol].Controls.Add(TblHeader(drc["TituloCampo"].ToString(),Convert.ToInt32( drc["IdColumna"].ToString())));
							}
							//e.Item.Cells[NCol].Attributes.Add(Utilitario.Constantes.EVENTODBLCLICK.ToString(),"DetalleColumna('" + drc["IdColumna"].ToString() + "');");
							
							e.Item.Cells[NCol].Attributes[Enumerados.EventosJavaScript.Ondblclick.ToString()]= "ProcesarCuentasCtables()";
							//ConfigColGridCierre(1,e.Item.Cells[1]);BORRAR

							NCol++;
						}
					}
				}

				
			}
			else if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;			

			
				e.Item.Attributes.Add("IDRUBRO",dr[Enumerados.ColumnasFormato.IdRubro.ToString()].ToString());
				e.Item.Attributes.Add("IDTIPOLINEA",dr[Enumerados.ColumnasFormato.IdTipoLinea.ToString()].ToString());
				e.Item.Attributes.Add("VERMONTO",dr[Enumerados.ColumnasFormato.FlgVerMonto.ToString()].ToString());
				e.Item.Attributes.Add("NIVEL",((Convert.ToInt32(dr["DetalleNota"].ToString())>0)?"2":dr[Enumerados.ColumnasFormato.idNivel.ToString()].ToString()));

				if (dr[Enumerados.ColumnasFormato.FormulaFormato.ToString()].ToString().Length>0)
				{
					stridFila += (e.Item.ItemIndex+NroFilaIni).ToString() + Utilitario.Constantes.SIGNOPUNTOYCOMA;
					lstPrioridad +=dr[Enumerados.ColumnasFormato.idPrioridad.ToString()].ToString()+ Utilitario.Constantes.SIGNOPUNTOYCOMA;
					//e.Item.Attributes.Add("CONFORMULA","SI");
					e.Item.Attributes.Add("PRIORIDAD",dr[Enumerados.ColumnasFormato.idPrioridad.ToString()].ToString());
				}

				ItemsGrid.Attributes.Add("FILAFORMULA",stridFila);
				ItemsGrid.Attributes.Add("LSTPRIORIDAD",lstPrioridad);
				
	
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
					+ KEYQIDCENTROCOSTO + Constantes.SIGNOIGUAL + Idcc.ToString()
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

				
				Utilitario.Helper.SeleccionarItemGrillaOnClickMoverRaton(e,"ObtenerIdRubro('" +dr["idRubro"].ToString() + "','" + dr["FormEntreRubro"].ToString() + "');MostrarDatosEnCajaTexto('hidFilaSeleccionada',ObtenerRowId(this));" + Helper.MostrarDatosEnCajaTexto("hNroNivel",dr[Enumerados.ColumnasFormato.NroNivel.ToString()].ToString()));
				Utilitario.Helper.ConfiguraNodosTreeview(e,1,0,dr,"DetalleContablePorItem(this.parentNode.parentNode.parentNode.parentNode.parentNode);");
				
	
				//e.Item.Cells[c].Attributes.Add(Enumerados.EventosJavaScript.Ondblclick.ToString(),"EscribirDescripcionEnFila('" + idMes.ToString() + "',this);");		

				/*
					if(Convert.ToInt32(dr[Enumerados.ColumnasFormato.NroHijos.ToString()])!=0)
					{
						nb.ReadOnly=true;
						nb.Font.Bold=true;
						nb.Font.Size= FontUnit.Point(8);
					}
					
				*/

			}


		}

		public DataTable ObtenerFormato()
		{
			Idcc= ((this.IdCentroCosto==0)?-1: this.IdCentroCosto);
			return (new  CFormatoEstructuraMovimientoCentroCosto()).ConsultarFormatoAnexoEstructuraMovimientoCentroCosto(this.IdFormato,this.IdReporte,this.IdCentroOperativo,this.Periodo,this.IdMes,this.IdTipoInformacion,Idcc);
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
			this.btnPrc.Click += new System.EventHandler(this.btnPrc_Click);
			this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
			this.btnExportaXLS.Click += new System.EventHandler(this.btnExportaXLS_Click);
			this.cmdImportarSaldos1.Click += new System.EventHandler(this.cmdImportarSaldos1_Click);
			this.btnMostrarMes.Click += new System.EventHandler(this.btnMostrarMes_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members



		public void LlenarGrilla()
		{
			this.CrearGrilla();
			ItemsGrid.DataSource = (new CFormatoReporteColumnaMovimiento()).Listar(this.IdFormato,this.IdReporte,this.IdCentroOperativo,this.Periodo,this.IdMes);
			ItemsGrid.DataBind();
			//gridPostMtd();
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarFormatoAnexoDetalleMovPorPeriodoColumnas.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add AdministrarFormatoAnexoDetalleMovPorPeriodoColumnas.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			ListItem itm = this.ddlMesSelect.Items.FindByValue(DateTime.Now.Month.ToString());
			if(itm!=null){itm.Selected=true;hIdMes.Value= itm.Value.ToString();}
			
		}

		public void LlenarDatos()
		{
			FormatoBE oFormatoBE = (FormatoBE)(new CFormato()).DetalleFormato(this.IdFormato,this.IdReporte);
			this.lblDescripcion.Text=oFormatoBE.Descripcion;	
		}

		public void LlenarJScript()
		{
			this.ImgProcesar.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnClick.ToString(),"ProcesarCuentasCtables();");

			this.ddlMesSelect.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnChange.ToString(),"SetMesID(this.options[this.selectedIndex].value);");
			//this.R1.Attributes[Enumerados.EventosJavaScript.OnClick.ToString()]= "OpcionSeleccionada(1);";
			this.R2.Attributes[Enumerados.EventosJavaScript.OnClick.ToString()]= "OpcionSeleccionada(2);";
			this.R3.Attributes[Enumerados.EventosJavaScript.OnClick.ToString()]= "OpcionSeleccionada(3);";
			//this.R4.Attributes[Enumerados.EventosJavaScript.OnClick.ToString()]= "OpcionSeleccionada(4);";
			//this.R5.Attributes[Enumerados.EventosJavaScript.OnClick.ToString()]= "OpcionSeleccionada(5);";
			//this.R6.Attributes[Enumerados.EventosJavaScript.OnClick.ToString()]= "OpcionSeleccionada(6);";
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarFormatoAnexoDetalleMovPorPeriodoColumnas.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministrarFormatoAnexoDetalleMovPorPeriodoColumnas.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarFormatoAnexoDetalleMovPorPeriodoColumnas.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add AdministrarFormatoAnexoDetalleMovPorPeriodoColumnas.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add AdministrarFormatoAnexoDetalleMovPorPeriodoColumnas.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void ProcesarFormato()
		{
			if(this.ReqCtaCtable==1)
			{
				if(this.IdTipoFormato==2)
				{
					//(new SIMA.Controladoras.GestionFinanciera.CFormatoDetalleMovimiento()).ProcesarFormatoEstadosFinancierosRubros(this.IdFormato, this.IdReporte, this.IdCentroOperativo, this.Periodo, this.IdMes, 0);
					(new SIMA.Controladoras.GestionFinanciera.CFormatoDetalleMovimiento()).ProcesarFormatoReporteColumna(this.IdFormato, this.IdReporte, this.IdCentroOperativo, this.Periodo, this.IdMes,this.FormatoAcumulado);
				}
			}
			else if(this.ReqCtaCtable==2)
			{
				(new SIMA.Controladoras.GestionFinanciera.CFormatoDetalleMovimiento()).ProcesarFormatoxNotaContable(this.IdFormato, this.IdReporte, this.IdCentroOperativo, this.Periodo, this.IdMes,this.FormatoAcumulado);
			}
		}

		private void btnPrc_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (Page.IsValid)
				{
					if(this.Cerrado==0)
					{
						this.ProcesarFormato();
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

		private void btnMostrarMes_Click(object sender, System.EventArgs e)
		{
			LlenarGrilla();
		}

		private void btnRefresh_Click(object sender, System.EventArgs e)
		{
			LlenarGrilla();
		}

		private void btnExportaXLS_Click(object sender, System.EventArgs e)
		{
		
		}

		private void cmdImportarSaldos1_Click(object sender, System.EventArgs e)
		{
		
		}
	}
}
