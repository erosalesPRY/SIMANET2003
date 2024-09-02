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
using SIMA.EntidadesNegocio.GestionFinanciera;
using SIMA.Utilitario;
using NetAccessControl;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using System.IO;
using System.Reflection;
using eWorld.UI;
using System.Text;
using SIMA.EntidadesNegocio;
using SIMA.EntidadesNegocio.General;
using SIMA.Controladoras;
using SIMA.Controladoras.General;


namespace SIMA.SimaNetWeb.General
{
	/// <summary>
	/// Summary description for ReceptosParametros.
	/// </summary>
	public class ReceptosParametros : System.Web.UI.Page,IPaginaBase
	{
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.HtmlControls.HtmlTable tblContext;
		protected System.Web.UI.WebControls.Button btnVer;
		protected System.Web.UI.WebControls.Label lblReporte;
		protected System.Web.UI.WebControls.Label lblPagina;

		const string KEYQLISTACAMPOS="lstField";
	
		int HtmlrowIni=2;
		int Longitud=0;
		
		private bool callInstance=false;

		public bool CallInstance
		{
			get{return callInstance; }
			set { callInstance=value;}
		}

		private int idReporte;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCrystalReport;
		private string nombreReporte;

		public int IdReporte{
			get{return  ((CallInstance==false) ? Convert.ToInt32(Page.Request.Params["IdRPT"]): idReporte); }
			set {idReporte=value;}
		}

		public string NombreReporte
		{
			get{
				if(CallInstance==false) 
				{
						return  Page.Request.Params["NomRPT"].ToString();
				 }
				else
				{
					return  nombreReporte;
				}
			}
			set{nombreReporte=value;}
		}
		private int crystalReport;
		public int CrystalReport{
			get{return  ((CallInstance==false) ? Convert.ToInt32(this.hCrystalReport.Value):crystalReport ); }
			set {crystalReport=value;}
		}
		//Constructor
		/*public ReceptosParametros(bool Instacia){
				CallInstance=Instacia;
		}*/

		private void Page_Load(object sender, System.EventArgs e)
		{
			Page.EnableViewState = true; 
			try
			{
				if(!Page.IsPostBack)
				{
					LlenarJScript();
					LlenarDatos();
				}
				Helper.ReestablecerPagina();
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

		public void CrearControlesParametros(){
			int i=HtmlrowIni;
			string TipoDato="";
			string  ACstrCSript2;
			string ACDefParametros2="";
			string strNombreTbl2;
			string VISIBILIDAD="none";

			DataTable dtCtrlParamField;
			//tblContext.Border=2;
			DataTable dtCtrlParam = (new CrptConsolaParametros()).ListarTodos(this.IdReporte);
			foreach(DataRow dr in dtCtrlParam.Rows){
				Longitud++;
				tblContext.Rows[i].Cells[0].InnerText=dr["LblDescripcion"].ToString();
				tblContext.Rows[i].Cells[0].NoWrap=true;
				tblContext.Rows[i].Cells[0].Attributes.Add("class","HeaderGrilla");
				tblContext.Rows[i].Cells[0].Attributes.Add("align","left");
				TipoDato=dr["IdTipoDato"].ToString();
				string MiID = "CtrlP_" + TipoDato +"_"+dr["IdParametro"].ToString();
				string strNombre="";
				string strNombreV="";
				Enumerados.ControlUIwebSIMA oControlUIwebSIMA =(Enumerados.ControlUIwebSIMA)System.Enum.Parse(typeof(Enumerados.ControlUIwebSIMA),TipoDato) ;
				switch (oControlUIwebSIMA)
				{
					case Enumerados.ControlUIwebSIMA.Numerico:
						eWorld.UI.NumericBox MiNumero = new eWorld.UI.NumericBox();
						//MiNumero.ID = "CtrlP_" + TipoDato +"_"+dr["IdParametro"].ToString();
						MiNumero.ID = MiID;
						MiNumero.TextAlign = eWorld.UI.HorizontalAlignment.Right;
						tblContext.Rows[i].Cells[1].Controls.Add(MiNumero);
						break;
					case Enumerados.ControlUIwebSIMA.TextBox:
						TextBox MiTextBox = new TextBox();
						//MiTextBox.ID = "CtrlP_" + TipoDato +"_"+dr["IdParametro"].ToString();
						MiTextBox.ID = MiID;
						MiTextBox.CssClass="normaldetalle";
						tblContext.Rows[i].Cells[1].Controls.Add(MiTextBox);
						break;
					case Enumerados.ControlUIwebSIMA.Fecha:
						eWorld.UI.CalendarPopup MiCalendario = new eWorld.UI.CalendarPopup();
						//MiCalendario.ID = "CtrlP_" + TipoDato +"_"+dr["IdParametro"].ToString();
						MiCalendario.ID = MiID;
						//MiCalendario.ControlDisplay = eWorld.UI.DisplayType.LabelImage;
						MiCalendario.ControlDisplay = eWorld.UI.DisplayType.TextBoxImage;
						MiCalendario.CalendarLocation = eWorld.UI.DisplayLocation.Left;

						MiCalendario.DisableTextboxEntry=true;
						MiCalendario.ImageUrl= HttpContext.Current.Session[Utilitario.Constantes.SPATHAPPWEB].ToString() +"/Imagenes/EvaluacionPersonal/btnMas.gif";
						MiCalendario.TextboxLabelStyle.CssClass="normaldetalle";	
						MiCalendario.TodayDayStyle.BackColor= System.Drawing.Color.FromName("LightSteelBlue");
						MiCalendario.TextboxLabelStyle.CssClass="NormalDetalle";
						//MiCalendario.TodayDayStyle.ForeColor= System.Drawing.r "#335EB4";
						MiCalendario.TodayDayStyle.Font.Name="Verdana";
						//MiCalendario.TodayDayStyle.Font.Size="XX-Small";
						MiCalendario.SelectedDateStyle.BackColor = System.Drawing.Color.FromName("CornflowerBlue");
						MiCalendario.AllowArbitraryText=false;


						string strAttr = dr["Atributos"].ToString();
						if(strAttr.Length>0)
						{
							strAttr=strAttr.Replace("{","").Replace("}","").Split(':')[1];
						}
						tblContext.Rows[i].Cells[1].Controls.Add(MiCalendario);
						break;
					case Enumerados.ControlUIwebSIMA.Boleano:
						CheckBox chk = new CheckBox();
						//chk.ID= "CtrlP_" + TipoDato +"_"+dr["IdParametro"].ToString();
						chk.ID= MiID;
						tblContext.Rows[i].Cells[1].Controls.Add(chk);
						break;
					case Enumerados.ControlUIwebSIMA.NrodeMes:
						DropDownList MiDropDownList = new DropDownList();
						//MiDropDownList.ID = "CtrlP_" + TipoDato +"_"+dr["IdParametro"].ToString();
						MiDropDownList.ID = MiID;
						string []LMes = {"Enero","Febrero","Marzo","Abril","Mayo","Junio","Julio","Agosto","Setiembre","Octubre","Noviembre","Diciembre"};
						for(int ix=0;ix<=LMes.Length-1;ix++)
						{
							string Nombre = LMes[ix];
							MiDropDownList.Items.Add(new ListItem(Nombre,(ix+1).ToString()));
						}

						tblContext.Rows[i].Cells[1].Controls.Add(MiDropDownList);
						break;
					case Enumerados.ControlUIwebSIMA.UsuarioLogueado:
						TextBox MiTextBoxUserLog = new TextBox();
						//MiTextBoxUserLog.ID = "CtrlP_" + TipoDato +"_"+dr["IdParametro"].ToString();
						MiTextBoxUserLog.ID = MiID;
						MiTextBoxUserLog.Text = CNetAccessControl.GetUserName().ToString();
						MiTextBoxUserLog.CssClass="normaldetalle";
						MiTextBoxUserLog.ReadOnly=true;
						tblContext.Rows[i].Cells[1].Controls.Add(MiTextBoxUserLog);
						break;
					case Enumerados.ControlUIwebSIMA.ParametroUrl:
						TextBox MiTextBoxURL = new TextBox();
						MiTextBoxURL.Style.Add("DISPLAY","NONE");
						//MiTextBoxURL.ID = "CtrlP_" + TipoDato +"_"+dr["IdParametro"].ToString();
						MiTextBoxURL.ID = MiID;
						MiTextBoxURL.Text = ((Page.Request.Params[dr["NameParamURL"].ToString()]==null)?"":Page.Request.Params[dr["NameParamURL"].ToString()]);
						MiTextBoxURL.ReadOnly=true;
						tblContext.Rows[i].Cells[1].Controls.Add(MiTextBoxURL);
						break;
					case Enumerados.ControlUIwebSIMA.Autocomplete:
						//strNombre = "CtrlP_" + TipoDato +"_"+dr["IdParametro"].ToString();
						strNombre = MiID;
						strNombreV = "V"+ strNombre;
						TextBox MiTextBoxFind = new TextBox();
					
						MiTextBoxFind.ID = strNombre;
						MiTextBoxFind.CssClass="normaldetalle";
						MiTextBoxFind.Style.Add("width","100%");
						MiTextBoxFind.Text ="";			
						tblContext.Rows[i].Cells[1].Controls.Add(MiTextBoxFind);
						//Ctrl que permitita recojer el valor seleccionado
						TextBox MiTextBoxFindValue = new TextBox();
						MiTextBoxFindValue.Style.Add("DISPLAY","NONE");
						MiTextBoxFindValue.ID = strNombreV;
						MiTextBoxFindValue.Text ="0";	
						tblContext.Rows[i].Cells[1].Controls.Add(MiTextBoxFindValue);
						/*Obtiene la matriz de campos a utilizar*/
						string []LstCampos = dr["Atributos"].ToString().Replace("{","").Replace("}","").Split(';');

						string DefParametros = "var oParamCollecionBusqueda" + strNombre + " = new ParamCollecionBusqueda();";
						DefParametros += " var oParamBusqueda" + strNombre + " = new ParamBusqueda();";
						DefParametros += "	oParamBusqueda" + strNombre + ".Nombre='" +LstCampos[0].Split(':')[1].ToString() +"';";
						DefParametros += "	oParamBusqueda" + strNombre + ".Texto='CampoA';";
						DefParametros += "	oParamBusqueda" + strNombre + ".LongitudEjecucion=1;";
						DefParametros += "	oParamBusqueda" + strNombre + ".Tipo='C';";
						DefParametros += "	oParamBusqueda" + strNombre + ".CampoAlterno = '" + LstCampos[1].Split(':')[1].ToString() + "';";
						DefParametros += "	oParamBusqueda" + strNombre + ".LongitudEjecucion=3;";
						DefParametros += " oParamCollecionBusqueda" + strNombre + ".Agregar(oParamBusqueda" + strNombre + ");";

						DefParametros += "	oParamBusqueda" + strNombre + " = new ParamBusqueda();";
						DefParametros += "	oParamBusqueda" + strNombre + ".Nombre='idProceso';";
						DefParametros += "	oParamBusqueda" + strNombre + ".Valor=" +  LstCampos[3].Split(':')[1].ToString() +";";
						DefParametros += "	oParamBusqueda" + strNombre + ".Tipo='Q';";
						DefParametros += " oParamCollecionBusqueda" + strNombre + ".Agregar(oParamBusqueda" + strNombre + ");";

						DefParametros += "(new AutoBusqueda('" + strNombre + "')).Crear('/' + ApplicationPath + '/General/ProcesarForReport.aspx?',oParamCollecionBusqueda" + strNombre + ");";
						
						
						string  strCSript = "function " + strNombre + "_ItemDataBound(sender,e,dr){";
						strCSript +=  "jSIMA('" + "#" + strNombreV + "').attr('value',dr['" + LstCampos[2].Split(':')[1].ToString() +"'].toString());";
						strCSript += "  ";
						strCSript += "}";

						Page.RegisterStartupScript("s"+strNombre,"<script>"+strCSript+DefParametros+"</script>");
						break;
					case Enumerados.ControlUIwebSIMA.GridPopup:
						//strNombre = "CtrlP_" + TipoDato +"_"+dr["IdParametro"].ToString();
						strNombre = MiID;
						string strNombreBtn = "B"+ MiID;

						strNombreV = "V"+ MiID;
					
						System.Web.UI.HtmlControls.HtmlTable HtmlTable = Helper.CrearHtmlTabla(1,2);
						//HtmlTable.ID="TCtrlP_" + TipoDato +"_"+dr["IdParametro"].ToString();
						HtmlTable.ID=MiID;
						HtmlTable.Style.Add("width","100%");

						TextBox MiTextBoxDescrip = new TextBox();
						MiTextBoxDescrip.ID=strNombre;
						MiTextBoxDescrip.ReadOnly=true;
						MiTextBoxDescrip.CssClass="normaldetalle";
						MiTextBoxDescrip.Style.Add("width","100%");
						HtmlTable.Rows[0].Cells[0].Controls.Add(MiTextBoxDescrip);
						HtmlTable.Rows[0].Cells[0].Style.Add("width","100%");
					
						TextBox MiTextBoxValor = new TextBox();
						MiTextBoxValor.Style.Add("display","none");
						MiTextBoxValor.CssClass="normaldetalle";
						MiTextBoxValor.ID=strNombreV;
						HtmlTable.Rows[0].Cells[1].Controls.Add(MiTextBoxValor);

						System.Web.UI.HtmlControls.HtmlImage oImg = new System.Web.UI.HtmlControls.HtmlImage();
						oImg.Attributes.Add("src","../imagenes/BtPU_Mas.gif");
						oImg.ID=strNombreBtn;//"PopupBtn";
						HtmlTable.Rows[0].Cells[1].Controls.Add(oImg);

						tblContext.Rows[i].Cells[1].Style.Add("width","100%");
						tblContext.Rows[i].Cells[1].Controls.Add(HtmlTable);
						string URLDETALLE = Page.Request.ApplicationPath + "/General/ControlPopupGrid.aspx" + Utilitario.Constantes.SIGNOINTERROGACION
							+"AsseInf" +Utilitario.Constantes.SIGNOIGUAL+ dr["AssemblyNameSpaceMetodo"].ToString()
							+ Utilitario.Constantes.SIGNOAMPERSON
							+ KEYQLISTACAMPOS +Utilitario.Constantes.SIGNOIGUAL+ dr["Atributos"].ToString() 
							+ Utilitario.Constantes.SIGNOAMPERSON
							+"NomCtrlValue" +Utilitario.Constantes.SIGNOIGUAL+ strNombreV
							+ Utilitario.Constantes.SIGNOAMPERSON
							+"NomCtrlText"+Utilitario.Constantes.SIGNOIGUAL+strNombre;

						string popupWindows = "(new System.Ext.UI.WebControls.Windows()).Dialogo('SELECCIONAR','" + URLDETALLE + "',this,580,405,Cerrar);";
						string ScriptBtn="jSIMA(" + Utilitario.Constantes.SIGNOCOMILLADOBLE+ "#" + strNombreBtn  + Utilitario.Constantes.SIGNOCOMILLADOBLE+ ").on(" + Utilitario.Constantes.SIGNOCOMILLADOBLE + "click" + Utilitario.Constantes.SIGNOCOMILLADOBLE+ ",function(){ " + popupWindows + " ;});";
						Page.RegisterStartupScript("s"+strNombre,"<script>"+ ScriptBtn +"</script>");
						break;

					case Enumerados.ControlUIwebSIMA.ListItemSimple:
						string strNombreTbl = "T"+ MiID;
						System.Web.UI.HtmlControls.HtmlTable LSHtmlTable = Helper.CrearHtmlTabla(2,1);
						LSHtmlTable.ID=strNombreTbl;
						LSHtmlTable.Border=0;
						LSHtmlTable.Style.Add("width","100%");

						TextBox LSMiTextBoxValor = new TextBox();
						LSMiTextBoxValor.ID="Txt" + MiID;
						LSMiTextBoxValor.Style.Add("width","100%");
						//LSMiTextBoxValor.CssClass="normaldetalle";
						LSMiTextBoxValor.CssClass="ListComplete_text";
						
						LSMiTextBoxValor.Attributes.Add(Enumerados.EventosJavaScript.OnKeydown.ToString(),"CrearCtrlListItemSimple('" + strNombreTbl + "','" + MiID + "',this);");
						LSHtmlTable.Rows[0].Cells[0].Style.Add("width","100%");
						LSHtmlTable.Rows[0].Cells[0].Controls.Add(LSMiTextBoxValor);
						//Contiene la lista de items ingresados
						TextBox LSHiddenTextBoxValor = new TextBox();
						LSHiddenTextBoxValor.ID="H" + MiID;
						LSHiddenTextBoxValor.Style.Add("width","100%");
						LSHiddenTextBoxValor.CssClass="normaldetalle";
						LSHiddenTextBoxValor.Style.Add("display",VISIBILIDAD);
						LSHtmlTable.Rows[0].Cells[0].Controls.Add(LSHiddenTextBoxValor);

						LSHiddenTextBoxValor = new TextBox();
						LSHiddenTextBoxValor.ID="X" + MiID;
						LSHiddenTextBoxValor.Style.Add("width","100%");
						LSHiddenTextBoxValor.Attributes.Add("SOURCE",strNombreTbl);
						LSHiddenTextBoxValor.Attributes.Add("TARGET",MiID);
						LSHiddenTextBoxValor.CssClass="X";
						LSHiddenTextBoxValor.Style.Add("display",VISIBILIDAD);
						LSHtmlTable.Rows[0].Cells[0].Controls.Add(LSHiddenTextBoxValor);


						tblContext.Rows[i].Cells[1].Style.Add("width","100%");
						tblContext.Rows[i].Cells[1].Controls.Add(LSHtmlTable);

						break;
					case Enumerados.ControlUIwebSIMA.ListItemAutoComplete:
						strNombre = "AC" + MiID;
						strNombreV = "AV"+ strNombre;

						strNombreTbl2 = "T"+ MiID;
						System.Web.UI.HtmlControls.HtmlTable LACHtmlTable = Helper.CrearHtmlTabla(2,1);
						LACHtmlTable.ID=strNombreTbl2;
						LACHtmlTable.Border=0;
						LACHtmlTable.Style.Add("width","100%");
						LACHtmlTable.Rows[0].Cells[0].Style.Add("width","100%");

						TextBox ACMiTextBoxFind = new TextBox();
						ACMiTextBoxFind.ID = strNombre;
						ACMiTextBoxFind.CssClass="normaldetalle";
						ACMiTextBoxFind.Style.Add("width","100%");
						ACMiTextBoxFind.Text ="";			
						LACHtmlTable.Rows[0].Cells[0].Controls.Add(ACMiTextBoxFind);

						//Ctrl que permitita la lista de valores seleccionados
						TextBox ACMiTextBoxFindValue = new TextBox();
						ACMiTextBoxFindValue.Style.Add("DISPLAY",VISIBILIDAD);
						ACMiTextBoxFindValue.ID = "H"+ MiID;
						ACMiTextBoxFindValue.Text ="0";	
						LACHtmlTable.Rows[0].Cells[0].Controls.Add(ACMiTextBoxFindValue);
					
						//Ctrl que permitita la lista de TEXTO seleccionados
						ACMiTextBoxFindValue = new TextBox();
						ACMiTextBoxFindValue.Style.Add("DISPLAY",VISIBILIDAD);
						ACMiTextBoxFindValue.Attributes.Add("SOURCE",strNombreTbl2);
						ACMiTextBoxFindValue.Attributes.Add("TARGET",MiID);
						ACMiTextBoxFindValue.CssClass="X";
						ACMiTextBoxFindValue.ID = "X"+ MiID;
						LACHtmlTable.Rows[0].Cells[0].Controls.Add(ACMiTextBoxFindValue);

						
						tblContext.Rows[i].Cells[1].Controls.Add(LACHtmlTable);

						
						dtCtrlParamField = (new CrptConsolaParametros()).ListarCampos(this.IdReporte,Convert.ToInt32(dr["IdParametro"].ToString()));
						if(dtCtrlParamField.Rows.Count>0)
						{
							ACDefParametros2= "var oParamCollecionBusqueda" + strNombre + " = new ParamCollecionBusqueda();";
							int idx =0;
							foreach(DataRow drfield in dtCtrlParamField.Rows)
							{
								if(idx==0)
								{
									ACDefParametros2 += " var oParamBusqueda" + strNombre + " = new ParamBusqueda();";
								}
								else
								{
									ACDefParametros2 += " oParamBusqueda" + strNombre + " = new ParamBusqueda();";
								}

								if(drfield["TipoParam"].ToString().Equals("C"))
								{
									ACDefParametros2 += "	oParamBusqueda" + strNombre + ".Nombre='" + drfield["CampoPrincipal"].ToString() +"';" + "\r\n";
									ACDefParametros2 += "	oParamBusqueda" + strNombre + ".Texto='" + drfield["Titulo"].ToString() + "';" + "\r\n";
									ACDefParametros2 += "	oParamBusqueda" + strNombre + ".LongitudEjecucion=" + drfield["LongExec"].ToString()  + ";"+ "\r\n";
									ACDefParametros2 += "	oParamBusqueda" + strNombre + ".CampoAlterno = '" + drfield["CampoAlterno"].ToString() + "';"+ "\r\n";
									ACDefParametros2 += "	oParamBusqueda" + strNombre + ".Tipo='" + drfield["TipoParam"].ToString() + "';"+ "\r\n";
									ACDefParametros2 += " oParamCollecionBusqueda" + strNombre + ".Agregar(oParamBusqueda" + strNombre + ");"+ "\r\n";
								}
								else if(drfield["TipoParam"].ToString().Equals("Q"))
								{
									ACDefParametros2 += "	oParamBusqueda" + strNombre + ".Nombre='" + drfield["CampoPrincipal"].ToString() +"';" + "\r\n";
									ACDefParametros2 += "	oParamBusqueda" + strNombre + ".Valor=" + drfield["Valor"].ToString() + ";"+ "\r\n";
									ACDefParametros2 += "	oParamBusqueda" + strNombre + ".Tipo='" + drfield["TipoParam"].ToString() + "';"+ "\r\n";
									ACDefParametros2 += " oParamCollecionBusqueda" + strNombre + ".Agregar(oParamBusqueda" + strNombre + ");"+ "\r\n";
								}

								idx++;

							}
							ACDefParametros2 += "(new AutoBusqueda('" + strNombre + "')).Crear('/' + ApplicationPath + '/General/ProcesarForReport.aspx?',oParamCollecionBusqueda" + strNombre + ");";

						}

						ACstrCSript2 = " function " + strNombre + "_ItemDataBound(sender,e,dr){" + "\r\n";;
						ACstrCSript2 +=  " CrearCtrlListItemAutoComple('" + strNombreTbl2 + "','" + MiID + "',document.getElementById('" + strNombre + "'),dr['" + dr["Atributos"].ToString() + "'].toString());" + "\r\n";;
						ACstrCSript2 += "  " + "\r\n";;
						ACstrCSript2 += "}" + "\r\n";;

						Page.RegisterStartupScript("s"+strNombre,"<script>" + ACstrCSript2 + ACDefParametros2+"</script>");


						break;

					case Enumerados.ControlUIwebSIMA.ListItemAutoCompleteMultiple:
						strNombre = "AC" + MiID;
						strNombreV = "AV"+ strNombre;

						strNombreTbl2 = "T"+ MiID;
						System.Web.UI.HtmlControls.HtmlTable LACHtmlTable2 = Helper.CrearHtmlTabla(2,1);
						LACHtmlTable2.ID=strNombreTbl2;
						LACHtmlTable2.Border=0;
						LACHtmlTable2.Style.Add("width","100%");
						LACHtmlTable2.Rows[0].Cells[0].Style.Add("width","100%");

						TextBox ACMiTextBoxFind2 = new TextBox();
						ACMiTextBoxFind2.ID = strNombre;
						ACMiTextBoxFind2.CssClass="normaldetalle";
						ACMiTextBoxFind2.Style.Add("width","100%");
						ACMiTextBoxFind2.Text ="";			
						LACHtmlTable2.Rows[0].Cells[0].Controls.Add(ACMiTextBoxFind2);

						//Ctrl que permitita la lista de valores seleccionados
						TextBox ACMiTextBoxFindValue2 = new TextBox();
						ACMiTextBoxFindValue2.Style.Add("DISPLAY",VISIBILIDAD);
						ACMiTextBoxFindValue2.ID = "H"+ MiID;
						ACMiTextBoxFindValue2.Text ="0";	
						LACHtmlTable2.Rows[0].Cells[0].Controls.Add(ACMiTextBoxFindValue2);
					
						//tblContext.Rows[i].Cells[1].Controls.Add(LACHtmlTable2);

						//Ctrl que permitita la lista de texto seleccionados
						ACMiTextBoxFindValue2 = new TextBox();
						ACMiTextBoxFindValue2.Style.Add("DISPLAY",VISIBILIDAD);
						ACMiTextBoxFindValue2.Attributes.Add("SOURCE",strNombreTbl2);
						ACMiTextBoxFindValue2.Attributes.Add("TARGET",MiID);
						ACMiTextBoxFindValue2.CssClass="X";
						ACMiTextBoxFindValue2.ID = "X"+ MiID;
						LACHtmlTable2.Rows[0].Cells[0].Controls.Add(ACMiTextBoxFindValue2);
						
						tblContext.Rows[i].Cells[1].Controls.Add(LACHtmlTable2);

						
						 dtCtrlParamField = (new CrptConsolaParametros()).ListarCampos(this.IdReporte,Convert.ToInt32(dr["IdParametro"].ToString()));
						if(dtCtrlParamField.Rows.Count>0)
						{
							ACDefParametros2= "var oParamCollecionBusqueda" + strNombre + " = new ParamCollecionBusqueda();";
							int idx =0;
							foreach(DataRow drfield in dtCtrlParamField.Rows)
							{
								if(idx==0)
								{
									ACDefParametros2 += " var oParamBusqueda" + strNombre + " = new ParamBusqueda();";
								}
								else
								{
									ACDefParametros2 += " oParamBusqueda" + strNombre + " = new ParamBusqueda();";
								}

								if(drfield["TipoParam"].ToString().Equals("C"))
								{
									ACDefParametros2 += "	oParamBusqueda" + strNombre + ".Nombre='" + drfield["CampoPrincipal"].ToString() +"';" + "\r\n";
									ACDefParametros2 += "	oParamBusqueda" + strNombre + ".Texto='" + drfield["Titulo"].ToString() + "';" + "\r\n";
									ACDefParametros2 += "	oParamBusqueda" + strNombre + ".LongitudEjecucion=" + drfield["LongExec"].ToString()  + ";"+ "\r\n";
									ACDefParametros2 += "	oParamBusqueda" + strNombre + ".CampoAlterno = '" + drfield["CampoAlterno"].ToString() + "';"+ "\r\n";
									ACDefParametros2 += "	oParamBusqueda" + strNombre + ".Tipo='" + drfield["TipoParam"].ToString() + "';"+ "\r\n";
									ACDefParametros2 += " oParamCollecionBusqueda" + strNombre + ".Agregar(oParamBusqueda" + strNombre + ");"+ "\r\n";
								}
								else if(drfield["TipoParam"].ToString().Equals("Q"))
								{
									ACDefParametros2 += "	oParamBusqueda" + strNombre + ".Nombre='" + drfield["CampoPrincipal"].ToString() +"';" + "\r\n";
									ACDefParametros2 += "	oParamBusqueda" + strNombre + ".Valor=" + drfield["Valor"].ToString() + ";"+ "\r\n";
									ACDefParametros2 += "	oParamBusqueda" + strNombre + ".Tipo='" + drfield["TipoParam"].ToString() + "';"+ "\r\n";
									ACDefParametros2 += " oParamCollecionBusqueda" + strNombre + ".Agregar(oParamBusqueda" + strNombre + ");"+ "\r\n";
								}

								idx++;

							}
							ACDefParametros2 += "(new AutoBusqueda('" + strNombre + "')).CrearPopupOpcion('/' + ApplicationPath + '/General/ProcesarForReport.aspx?',oParamCollecionBusqueda" + strNombre + ");";

						}

						ACstrCSript2 = " function " + strNombre + "_ItemDataBound(sender,e,dr){" + "\r\n";;
						ACstrCSript2 +=  " CrearCtrlListItemAutoComple('" + strNombreTbl2 + "','" + MiID + "',document.getElementById('" + strNombre + "'),dr['" + dr["Atributos"].ToString() + "'].toString());" + "\r\n";;
						ACstrCSript2 += "  " + "\r\n";;
						ACstrCSript2 += "}" + "\r\n";;

						Page.RegisterStartupScript("s"+strNombre,"<script>" + ACstrCSript2 + ACDefParametros2+"</script>");

						break;
				}

				i++;
			}
		}


		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			//Controles creados desde la base de datos
			CrearControlesParametros();

			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.btnVer.Click += new System.EventHandler(this.btnVer_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add ReceptosParametros.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ReceptosParametros.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add ReceptosParametros.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add ReceptosParametros.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			/*Obtener Datos del reporte*/
			rptConsolaBE orptConsolaBE = new rptConsolaBE();
			orptConsolaBE =(rptConsolaBE)(new CrptConsola()).Detalle(this.IdReporte);
			if(this.CallInstance==false)
			{			
				this.lblReporte.Text = this.NombreReporte;
				this.hCrystalReport.Value = orptConsolaBE.CristalReport.ToString();
			}
		

		}

		public void LlenarJScript()
		{
			this.btnVer.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado(ObtenerNombresCtrl()));
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ReceptosParametros.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ReceptosParametros.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ReceptosParametros.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add ReceptosParametros.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ReceptosParametros.ValidarFiltros implementation
			return false;
		}

		#endregion

		
		private void btnVer_Click(object sender, System.EventArgs e)
		{
			CallSourceDataToReportFromAssembly();
		}



		public void CallSourceDataToReportFromAssembly()
		{
			CallSourceDataToReportFromAssembly(false,ListadeValores());
		}

		public void CallSourceDataToReportFromAssembly(bool EjecutarPagReport,object[] parametersArray){
			//Obtener datos del reporte segun parametro
			rptConsolaBE orptConsolaBE = (rptConsolaBE)(new CrptConsola()).Detalle(this.IdReporte) ;
			DataSet dsGeneric= new DataSet("sw");
			//string PathAssemblyControler=Page.Request.PhysicalApplicationPath + @"bin\SIMA.Controladoras.dll";
			string PathAssemblyControler=((System.Web.UI.Page) HttpContext.Current.Handler).Request.PhysicalApplicationPath + @"bin\SIMA.Controladoras.dll";
			
			Assembly assembly = Assembly.LoadFile(PathAssemblyControler);
			DataTable dtAssembly =(new CRptConsolaRefAssembly ()).ListarTodosGrilla(this.IdReporte);
			if(dtAssembly!=null)
			{
				foreach(DataRow drAss in dtAssembly.Rows)
				{
					string strNameSpace=drAss["Namespace"].ToString();
					Type type = assembly.GetType(strNameSpace);
					if (type != null)
					{
						MethodInfo methodInfo = type.GetMethod(drAss["Metodo"].ToString());
						if (methodInfo != null)
						{
							DataTable dt1=null;
							ParameterInfo[] parameters = methodInfo.GetParameters();
							object classInstance = Activator.CreateInstance(type, null);
							if (parameters.Length == 0)
							{
								dt1=(DataTable)methodInfo.Invoke(classInstance, null);
							}
							else
							{
								//object[] parametersArray = new object[] {2016,2,15};
								//object[] parametersArray = ListadeValores();
								dt1=(DataTable) methodInfo.Invoke(classInstance, parametersArray);
							}
							if((dt1!=null)&&(dt1.Rows.Count>0))
							{
								DataView dvASC =dt1.DefaultView;
								if(drAss["Sort"].ToString().Length>0)
								{
									dvASC.Sort=drAss["Sort"].ToString();
								}
								DataTable dtx =  Helper.DataViewTODataTable(dvASC);
								dt1.TableName=drAss["SPOrigenDatos"].ToString();// "CCTTuspNTADCOnsultarProgramacionyDetalle;1";
								dsGeneric.Tables.Add(dtx);
							}

						}
					}
				}
				if(dsGeneric.Tables.Count>0)
				{
					/*Formato PDF*/
					//if(this.hCrystalReport.Value=="1")
					if(this.CrystalReport==1)
					{
						Helper.EjecutarReporte(orptConsolaBE.Path,orptConsolaBE.Nombre,dsGeneric,false);
					}
					else{
						/*Formato XLS*/
						if(EjecutarPagReport==true)
						{
							Helper.Archivo.GenerarReporteToXls(this.IdReporte,dsGeneric,false);
						}
					}
				}
				else{
					string SpanOF="<span style='FONT-SIZE: 10pt'>";
					string SpanCF="</span>";
					string MENSAJE2="No Existen Datos que cumplan con los criterios de los parámetros ingresados, intentelo otra vez cambiando los parámetros";					
					string strFoto=Helper.ObtenerFotoPersonal(CNetAccessControl.GetUserNroDocIdent());
					string HEADER = "<table border='0'><tr><td rowspan='2'><img class='imgCircular' width='55' height='70' src='" +strFoto + "'></td><td style='TEXT-TRANSFORM: uppercase; FONT-STYLE: italic; COLOR: #000099; FONT-SIZE: 10pt; FONT-WEIGHT: bold'>" + SpanOF + CNetAccessControl.GetUserApellidosNombres() + SpanCF + "</td></tr><tr><td>" + SpanOF + MENSAJE2  + SpanCF + "</td></tr></table>";

					string Alert="Ext.MessageBox.alert('AVISO'," + Utilitario.Constantes.SIGNOCOMILLADOBLE + HEADER +Utilitario.Constantes.SIGNOCOMILLADOBLE +  ", function(btn){});BuscarControlsX();";

					//Page.RegisterStartupScript("mReportGen","<script>"+ Alert +"</script>");
					((System.Web.UI.Page) HttpContext.Current.Handler).RegisterStartupScript("mReportGen","<script>"+ Alert +"</script>");
				}
			}
		}


		private object[] ListadeValores(){
			int TotFilas = tblContext.Rows.Count;
			object []MiObj = new object[Longitud];
			int NroCtrl=0;
			for(int p=HtmlrowIni;p<=tblContext.Rows.Count-2;p++){
				System.Web.UI.HtmlControls.HtmlTableRow htmlrow =tblContext.Rows[p];
				if(htmlrow.Cells[1].Controls.Count>0)
				{
					Control ctrl = htmlrow.Cells[1].Controls[0];
					if(ctrl!=null)
					{
						string IdTipoDato = ctrl.ID.ToString().Split('_')[1];
						Enumerados.ControlUIwebSIMA oControlUIwebSIMA =(Enumerados.ControlUIwebSIMA)System.Enum.Parse(typeof(Enumerados.ControlUIwebSIMA),IdTipoDato) ;
						switch (oControlUIwebSIMA)
						{
							case Enumerados.ControlUIwebSIMA.Numerico:
								MiObj[NroCtrl]= Convert.ToInt32(((NumericBox)(ctrl)).Text);
								break;
							case Enumerados.ControlUIwebSIMA.TextBox:
								MiObj[NroCtrl]= ((TextBox)(ctrl)).Text;
								break;
							case Enumerados.ControlUIwebSIMA.Fecha:
								DateTime dati = ((CalendarPopup)(ctrl)).SelectedDate;
								MiObj[NroCtrl]= dati.Year.ToString()+ dati.Month.ToString().PadLeft(2,'0')+ dati.Day.ToString().PadLeft(2,'0');
								break;
							case Enumerados.ControlUIwebSIMA.Boleano:
								MiObj[NroCtrl]=  ((((CheckBox)(ctrl)).Checked==true)?1:0);
								break;
							case Enumerados.ControlUIwebSIMA.NrodeMes:
								MiObj[NroCtrl]=Convert.ToInt32(((DropDownList)(ctrl)).SelectedValue);
								break;
							case Enumerados.ControlUIwebSIMA.UsuarioLogueado:
								MiObj[NroCtrl]= ((TextBox)(ctrl)).Text;
								break;
							case Enumerados.ControlUIwebSIMA.ParametroUrl:
								MiObj[NroCtrl]= ((TextBox)(ctrl)).Text;
								break;
							case Enumerados.ControlUIwebSIMA.Autocomplete:
								Control ctrlAlter = htmlrow.Cells[1].Controls[1];
								if(	((TextBox)(ctrl)).Text.Length>0 && (((TextBox)(ctrlAlter)).Text!="0"))
								{
									MiObj[NroCtrl]= ((TextBox)(ctrlAlter)).Text;
								}
								else
								{
									MiObj[NroCtrl]= "0";
								}
								break;
							case Enumerados.ControlUIwebSIMA.GridPopup:
								string NCtrlValor= "V"+ ctrl.ID.ToString().Replace("T","");
								TextBox TxtValue = (TextBox) ((System.Web.UI.HtmlControls.HtmlTable)(ctrl)).Rows[0].Cells[0].Controls[0].FindControl(NCtrlValor);
								MiObj[NroCtrl]=TxtValue.Text;
								break;
							case Enumerados.ControlUIwebSIMA.ListItemSimple:
								string HCtrlValor= "H"+ ctrl.ID.ToString().Replace("T","");
								TextBox HValue = (TextBox) ((System.Web.UI.HtmlControls.HtmlTable)(ctrl)).Rows[0].Cells[0].Controls[0].FindControl(HCtrlValor);
								MiObj[NroCtrl]=HValue.Text;
								break;
							case Enumerados.ControlUIwebSIMA.ListItemAutoComplete:
								string HACCtrlValor= "H"+ ctrl.ID.ToString().Replace("T","");
								TextBox HACValue = (TextBox) ((System.Web.UI.HtmlControls.HtmlTable)(ctrl)).Rows[0].Cells[0].Controls[0].FindControl(HACCtrlValor);
								MiObj[NroCtrl]=HACValue.Text;
								break;
							case Enumerados.ControlUIwebSIMA.ListItemAutoCompleteMultiple:
								string HACMCtrlValor= "H"+ ctrl.ID.ToString().Replace("T","");
								TextBox HACMValue = (TextBox) ((System.Web.UI.HtmlControls.HtmlTable)(ctrl)).Rows[0].Cells[0].Controls[0].FindControl(HACMCtrlValor);
								MiObj[NroCtrl]=HACMValue.Text;

								break;
						}
					NroCtrl++;
					}
				}
			}
			return  MiObj;
			
		}

		private object[] ObtenerNombresCtrl()
		{
			object []MiObj = new object[Longitud];
			int NroCtrl=0;
			for(int p=HtmlrowIni;p<=tblContext.Rows.Count-2;p++)
			{
				System.Web.UI.HtmlControls.HtmlTableRow htmlrow =tblContext.Rows[p];
				if(htmlrow.Cells[1].Controls.Count>0)
				{
					Control ctrl = htmlrow.Cells[1].Controls[0];
					if(ctrl!=null)
					{
						MiObj[NroCtrl] = ctrl.ID.ToString();
						NroCtrl++;
					}
				}
			}
			return  MiObj;
			
		}

	}
}


