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
	/// Summary description for AdministrarFormatoAnexoDetalleMovimientoPorPeriodo.
	/// </summary>
	public class AdministrarFormatoAnexoDetalleMovimientoPorPeriodo : System.Web.UI.Page,IPaginaBase
	{
		protected System.Web.UI.WebControls.RadioButton R1;
		protected System.Web.UI.WebControls.RadioButton R2;
		protected System.Web.UI.WebControls.RadioButton R3;
		protected System.Web.UI.WebControls.RadioButton R4;
		protected System.Web.UI.WebControls.RadioButton R5;
		protected System.Web.UI.WebControls.RadioButton R6;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Button btnPrc;
		protected System.Web.UI.WebControls.Button btnExportaXLS;
		protected System.Web.UI.WebControls.Button cmdImportarSaldos1;
		protected System.Web.UI.WebControls.Button btnResumenyDetalleXLS;
		protected System.Web.UI.WebControls.DataGrid gridPost;
		protected System.Web.UI.HtmlControls.HtmlTableCell LstUser;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hOpSelected;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hNombreImgTrim;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdMes;



		#region Constantes
		const string KEYQIDFORMATO="IdFormato";
		const string KEYQIDREPORTE = "IdReporte";
		const string KEYQIDRUBRO ="IdRubro";

		const string KEYQNOMBRERUBRO ="NombreRubro";
		const string URLITEMDETALLE = "AdministrarFormatoItemDetalleMovimientoporPeriodo.aspx?";
		const string KEYQPERIODO = "Periodo";
		const string KEYQIDMES = "IdMes";
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
		public int IdCentroCosto{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDCENTROCOSTO]);}
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
		protected System.Web.UI.WebControls.Button btnMostrarMes;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DropDownList ddlMesSelect;
		protected System.Web.UI.WebControls.Label lblDescripcion;
		HtmlTable otblH;
		protected projDataGridWeb.DataGridWeb grid;


		string AlertaCierre="No es posible iniciar el proceso, el mes seleccionado se encuentra Cerrado..";
	
		private void Page_Load(object sender, System.EventArgs e)
		{
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
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.btnPrc.Click += new System.EventHandler(this.btnPrc_Click);
			this.btnExportaXLS.Click += new System.EventHandler(this.btnExportaXLS_Click);
			this.cmdImportarSaldos1.Click += new System.EventHandler(this.cmdImportarSaldos1_Click);
			this.btnResumenyDetalleXLS.Click += new System.EventHandler(this.btnResumenyDetalleXLS_Click);
			this.btnMostrarMes.Click += new System.EventHandler(this.btnMostrarMes_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

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

		public DataTable ObtenerFormato()
		{
			Idcc= ((this.IdCentroCosto==0)?-1: this.IdCentroCosto);
			return (new  CFormatoEstructuraMovimientoCentroCosto()).ConsultarFormatoAnexoEstructuraMovimientoCentroCosto(this.IdFormato,this.IdReporte,this.IdCentroOperativo,this.Periodo,this.IdMes,this.IdTipoInformacion,Idcc);
		}



		#region IPaginaBase Members

		public void LlenarGrilla()
		{

			this.gridPostMtd();
			dt = ObtenerFormato();
			if(dt!=null)
			{
				grid.DataSource =  Helper.OrdenarFormatoEstructura(dt);
			}
			else
			{
				grid.DataSource = dt;
			}
			grid.DataBind();		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarFormatoAnexoDetalleMovimientoPorPeriodo.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add AdministrarFormatoAnexoDetalleMovimientoPorPeriodo.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			hIdMes.Value = DateTime.Now.Month.ToString();
			ListItem itm =  this.ddlMesSelect.Items.FindByValue(hIdMes.Value);
			if(itm!=null){itm.Selected=true;}

		}

		public void LlenarDatos()
		{
			FormatoBE oFormatoBE = (FormatoBE)(new CFormato()).DetalleFormato(this.IdFormato,this.IdReporte);
			lblDescripcion.Text = oFormatoBE.Descripcion;
		}

		public void LlenarJScript()
		{
			this.ddlMesSelect.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnChange.ToString(),"SetMesID(this.options[this.selectedIndex].value);");
			this.R1.Attributes[Enumerados.EventosJavaScript.OnClick.ToString()]= "OpcionSeleccionada(1);";
			this.R2.Attributes[Enumerados.EventosJavaScript.OnClick.ToString()]= "OpcionSeleccionada(2);";
			this.R3.Attributes[Enumerados.EventosJavaScript.OnClick.ToString()]= "OpcionSeleccionada(3);";
			this.R4.Attributes[Enumerados.EventosJavaScript.OnClick.ToString()]= "OpcionSeleccionada(4);";
			this.R5.Attributes[Enumerados.EventosJavaScript.OnClick.ToString()]= "OpcionSeleccionada(5);";
			this.R6.Attributes[Enumerados.EventosJavaScript.OnClick.ToString()]= "OpcionSeleccionada(6);";
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarFormatoAnexoDetalleMovimientoPorPeriodo.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministrarFormatoAnexoDetalleMovimientoPorPeriodo.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarFormatoAnexoDetalleMovimientoPorPeriodo.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add AdministrarFormatoAnexoDetalleMovimientoPorPeriodo.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add AdministrarFormatoAnexoDetalleMovimientoPorPeriodo.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.Header)
			{
				e.Item.Cells[4].Attributes[Enumerados.EventosJavaScript.Ondblclick.ToString()]= "ProcesarCuentasCtables(" + this.IdMes + ",this)";

				
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

				e.Item.Cells[0].Controls.Add(oTblHtml);
			}

			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
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
						
				


				eWorld.UI.NumericBox nb = (eWorld.UI.NumericBox)e.Item.Cells[1].FindControl("NSaldoIni" );	
				nb.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,"EnfocarSiguienteCelda(this);");
				nb.Attributes.Add("cellIndex","1");
				nb.Attributes.Add("rowIndex",(e.Item.ItemIndex+NFila).ToString());
				nb.Text = Convert.ToDouble(dr["SaldoInicial"]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				//nb.Attributes.Add("tag",Convert.ToDouble(dr[NMes]).ToString());


				nb = (eWorld.UI.NumericBox)e.Item.Cells[2].FindControl("nAumentos" );	
				nb.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,"EnfocarSiguienteCelda(this);");
				nb.Attributes.Add("cellIndex","2");
				nb.Attributes.Add("rowIndex",(e.Item.ItemIndex+NFila).ToString());
				nb.Text = Convert.ToDouble(dr["Aumentos"]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				//nb.Attributes.Add("tag",Convert.ToDouble(dr[NMes]).ToString());


				nb = (eWorld.UI.NumericBox)e.Item.Cells[3].FindControl("nDisminuciones" );	
				nb.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,"EnfocarSiguienteCelda(this);");
				nb.Attributes.Add("cellIndex","3");
				nb.Attributes.Add("rowIndex",(e.Item.ItemIndex+NFila).ToString());
				nb.Text = Convert.ToDouble(dr["Disminuciones"]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

				e.Item.Cells[4].Text = Convert.ToDouble(dr["SaldoFinal"]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				

				if(Convert.ToInt32(dr[Enumerados.ColumnasFormato.NroHijos.ToString()])!=0)
				{
					nb.ReadOnly=true;
					nb.Font.Bold=true;
					nb.Font.Size= FontUnit.Point(8);
				}

				






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

		private void ProcesarFormato()
		{
			if(this.ReqCtaCtable==1)
			{
				(new SIMA.Controladoras.GestionFinanciera.CFormatoDetalleMovimiento()).ProcesarFormatoEstadosFinancierosRubros(this.IdFormato, this.IdReporte, this.IdCentroOperativo, this.Periodo, this.IdMes, 0);
			}
			else if(this.ReqCtaCtable==2)
			{
				(new SIMA.Controladoras.GestionFinanciera.CFormatoDetalleMovimiento()).ProcesarFormatoxNotaContable(this.IdFormato, this.IdReporte, this.IdCentroOperativo, this.Periodo, this.IdMes,this.FormatoAcumulado);
			}
		}



		private void btnMostrarMes_Click(object sender, System.EventArgs e)
		{
			LlenarGrilla();
		}

		private void btnExportaXLS_Click(object sender, System.EventArgs e)
		{
		
		}

		private void cmdImportarSaldos1_Click(object sender, System.EventArgs e)
		{
		
		}

		private void btnResumenyDetalleXLS_Click(object sender, System.EventArgs e)
		{
		
		}
	}
}
