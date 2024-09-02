<%@ Page language="c#" Codebehind="defaultFormatoMovimiento.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.General.Formato.defaultFormatoMovimiento" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>Administrar movimiento de formatos</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../../styles.css">
		<SCRIPT language="javascript" src="../../js/@Import.js">  </SCRIPT>
		<SCRIPT language="javascript" src="../../js/JQuery/js/jquery.min.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/JQuery/js/JQueryPlugInSIMA.js"></SCRIPT>
		<SCRIPT>
			var jSIMA = jQuery.noConflict();
		</SCRIPT>
		<script>
			var KEYIDEMPRESA ="idEmp";
			var KEYQPERIODO = "Periodo";
			var KEYQIDGRUPOFORMATO="IdGrupoFormato";
			var IDCENTROOPERATIVO="idcop";
			var KEYQIDGRUPOCC = "idGrpCC";
			var KEYQIDCENTROCOSTO ="idCC";
			var KEYQIDTIPOINFO ="idTipoInfo";
			var KEYQREQCC ="ReqCC";
			var KEYQIDFORMATO ="IdFormato";
			var KEYQIDREPORTE = "IdReporte";
			
			var KEYQREQCTACTABLE="ReqCtaCtable"
			var KEYQACUMULADO="Acum";
			var KEYQCERRADO="Close";
			var KEYQIDTIPOFORMATO ="IdTipForm";
			
			function FormatoBE(INDEX,IDREPORTE,CODIGO,NOMBRE,REQCENTROCOSTO,REQCTACTABLE){
				this.Index=INDEX;
				this.IdReporte=IDREPORTE;
				this.Codigo=CODIGO;
				this.Nombre=NOMBRE;
				this.ReqCentroCosto = REQCENTROCOSTO;
				this.ReqCtaCtable = REQCTACTABLE;
			}
			
			//var PrefCtrl="_ctl4_";
			var oddlbCentroOperativo;
			var oddlbPeriodo;
			var oddlbTipoInformacion;

			
			
			function Formato(){
				var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
				var URLFORMATO = SIMA.Utilitario.Helper.General.ObtenerPathApp() + "/General/Formato/AdministrarFormatoDetalleMovimientoporPeriodo.aspx?";
				//var URLFORMATOANEXO = SIMA.Utilitario.Helper.General.ObtenerPathApp() + "/General/Formato/AdministrarFormatoAnexoDetalleMovimientoPorPeriodo.aspx?";
				var URLFORMATOANEXO = SIMA.Utilitario.Helper.General.ObtenerPathApp() + "/General/Formato/AdministrarFormatoAnexoDetalleMovPorPeriodoColumnas.aspx?";
				
						
				var Existe=false;
				/*--------------------------------------------------------------------------------------------------*/
				var oddlCentroCosto;
				this.Load=function(IdGrupo){
					//var oddlGrupoCC = $O('ddlGrupoCentroCosto');
					var IdCentroCosto=$O('hCentroCosto').value;
				
					
					var oTabStrip= new SIMA.Utilitario.Helper.General.TabStrip($O("divContenedor"));
					oTabStrip.PathImagen= SIMA.Utilitario.Helper.General.ObtenerPathApp() + "/Imagenes/Tabs/";

					with(SIMA.Utilitario.Constantes.General.Caracter){
							var oDataTable = new System.Data.DataTable("tblFormato");
							//oDataTable = (new Controladora.General.CFormato()).ListarAccesoSegunPrivilegioUsuarioTabla(oPagina.Request.Params[KEYQIDGRUPOFORMATO],oddlTipoInformacion.options[oddlTipoInformacion.selectedIndex].value,oPagina.Request.Params[SIMA.Utilitario.Constantes.KEYMODOPAGINA]);
							oDataTable = (new Controladora.General.CFormato()).ListarGruposFormAccesoSegunPrivilegioUsuarioUsuarioCtrlCierre(LItemCentroOperativo.value,LItemPeriodo.value,1,LItemTipoInformacion.value,IdGrupo);
							
							for (f=0;f<=oDataTable.Rows.Items.length-1;f++){
									var oDataRow =oDataTable.Rows.Items[f];
									if(oDataRow.Item("EOF")==false){
										Existe=true;
										var oFormatoBE = new FormatoBE();
										oFormatoBE.Index=f;
										oFormatoBE.IdReporte=oDataRow.Item("IdReporte");
										oFormatoBE.Codigo=oDataRow.Item("IdFormato");
										oFormatoBE.Nombre=oDataRow.Item("Nombre");
										oFormatoBE.ReqCentroCosto=oDataRow.Item("ReqCentroCosto");
										oFormatoBE.ReqCtaCtable= oDataRow.Item("ReqCtaCtable");
										
										var ParametrosFormato =  "IdFormato" + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual.toString() +  oFormatoBE.Codigo
																+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson.toString()
																+ KEYQIDREPORTE + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual.toString() +  oFormatoBE.IdReporte
																+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson.toString()
																+ "NFormato" + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual.toString() +  oFormatoBE.Nombre
																+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson.toString()
																+ KEYQPERIODO + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual.toString() +  LItemPeriodo.value
																+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson.toString()
																+ IDCENTROOPERATIVO + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual.toString() + LItemCentroOperativo.value
																+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson.toString()
																+ KEYQIDCENTROCOSTO + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual.toString() + IdCentroCosto
																+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson.toString()
																+ KEYQIDTIPOINFO  + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual.toString() + LItemTipoInformacion.value
																+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson.toString()
																+ KEYQREQCC + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual.toString() + oFormatoBE.ReqCentroCosto
																+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson.toString()
																+ KEYQREQCTACTABLE + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual.toString() + oFormatoBE.ReqCtaCtable
																+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson.toString()
																+ KEYQACUMULADO + SignoIgual.toString() +  oDataRow.Item("Acumulado")
																+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson.toString()
																+ KEYQCERRADO+ SignoIgual.toString() +  oDataRow.Item("Cerrado")
																+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson.toString()
																+ KEYQIDTIPOFORMATO + SignoIgual.toString() +  oDataRow.Item("IdTipoFormato");
																
																//alert(oDataRow.Item("IdTipoFormato"));
																
										oTab = new SIMA.Utilitario.Helper.General.Tab(oFormatoBE.Nombre,((oDataRow.Item("IdTipoFormato")==1)?URLFORMATO:URLFORMATOANEXO) + ParametrosFormato ,"Administrar " + oFormatoBE.Nombre);
										//oTab = new SIMA.Utilitario.Helper.General.Tab(oFormatoBE.Nombre,URLFORMATO+ ParametrosFormato ,"Administrar " + oFormatoBE.Nombre);
										oTab.Tag = oFormatoBE;
										oTab.Editable=true;
										oTab.EventHandle = TabSeleccionado;		
										//Crea la Imagen
										/*var oIconoBE = new SIMA.Utilitario.Helper.General.IconBE();
										oIconoBE.Icono = "Config.png";
										
										oIconoBE.EventHandle=function(){
											alert('Prueba');
										}
										oTab.IconBE = oIconoBE;*/
										oTabStrip.Tabs.Adicionar(oTab);
									}
							}
							if(Existe==true){
								IdgrpSelecDefault=jSIMA.GetClientData(SIMA.Utilitario.Enumerados.TipoSaveClient.Local,'GrpSelecMov');
								var GrpSelec = (((IdgrpSelecDefault!=undefined)||(IdgrpSelecDefault!=null))?IdgrpSelecDefault.toString().replace('G',''):1);
								var idxTab = jSIMA.GetClientData(SIMA.Utilitario.Enumerados.TipoSaveClient.Local,('TabSelec'+GrpSelec),('T'+ GrpSelec));
									idxTab = (((idxTab!=undefined)||(idxTab!=null))?idxTab.toString().replace('T',''):0);
									oTabStrip.RepintarTabs();
									window.setTimeout(function(){oTabStrip.Tabs.Tab(idxTab).Click();},200);
							}
							else{
								//$O("tblOpciones").style.display="none";
							}
					}
				}
				/*--------------------------------------------------------------------------------------------------*/

			}
			var oFormato = new Formato();
			
			function TabSeleccionado(){
				var oFormatoBE = new FormatoBE();
				oFormatoBE = this.Tag;
				
				//jSIMA('#idFilaGrupoyCentroCosto').css("display",((oFormatoBE.ReqCentroCosto==0)?"none":"block"));
				var IdgrpSelecDefault=jSIMA.GetClientData(SIMA.Utilitario.Enumerados.TipoSaveClient.Local,'GrpSelecMov');
				var GrpSelec = (((IdgrpSelecDefault!=undefined)||(IdgrpSelecDefault!=null))?IdgrpSelecDefault.toString().replace('G',''):1);
				jSIMA.SaveClientData(SIMA.Utilitario.Enumerados.TipoSaveClient.Local,('TabSelec'+GrpSelec),('T'+ oFormatoBE.Index));				
			}
			
			function Tab_Editable(){
				var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
				var oFormatoBE = new FormatoBE();
					oFormatoBE = this.Tag;
					
					if(this.Modo=="M"){
						var IdgrpSelec =   jSIMA.GetClientData(SIMA.Utilitario.Enumerados.TipoSaveClient.Local,'GrpSelecMov');
							IdgrpSelec = ((IdgrpSelec!=undefined)||(IdgrpSelec!=null))?IdgrpSelec.toString().replace('G',''):0;
					
						var URLDETALLE = SIMA.Utilitario.Helper.General.ObtenerPathApp() + "/General/Formato/ConsultarFormatoReporteDesAcoplado.aspx?" 
										+ KEYQIDFORMATO + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + oFormatoBE.Codigo
										+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
										+ KEYQIDREPORTE + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + oFormatoBE.IdReporte
										+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
										+ KEYQIDGRUPOFORMATO + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + IdgrpSelec
										+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
										+ IDCENTROOPERATIVO + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + LItemCentroOperativo.value
										+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
										+ KEYQPERIODO + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + LItemPeriodo.value
										+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
										+ KEYQIDTIPOINFO + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + LItemTipoInformacion.value;
										
						oPagina.Response.ShowDialogoNoModal(URLDETALLE,800,610);
						
					}
					
			}
			
		</script>
		<script>
			function CentroOperativoSeleccionado(){
				var oddlCentroOperativo = $O('ddlCentroOperativo');
				CargarGrupodeCentrodeCosto(oddlCentroOperativo.options[oddlCentroOperativo.selectedIndex].value);
			}

			function CargarGrupodeCentrodeCosto(idCentroOperativo){
				var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
				var oddlGrupoCC = new System.Web.UI.WebControls.DropDownList('ddlGrupoCentroCosto');
				oddlGrupoCC.DataSource = (new Controladora.General.GrupoCentrocosto()).ListarGrupoCentrodeCostoXCentroOperativo(idCentroOperativo);
				oddlGrupoCC.DataTextField = "NRONOMGCC";
				oddlGrupoCC.DataValueField = "IDGRUPOCC";
				oddlGrupoCC.SelectedIndexChanged = CargarCentrodeCosto;
				oddlGrupoCC.DataBind();
				try{
					ListItem = oddlGrupoCC.FindByValue($O('hGrupoCC').value);
				}catch(error){}
				
				CargarCentrodeCosto($O('ddlGrupoCentroCosto'));
			}
			
			function CargarCentrodeCosto(e){
				var idGrupoCentroCosto;
				try{
					idGrupoCentroCosto =e.options[e.selectedIndex].value;
				}
				catch(error){
					var oddlGrupoCentroCosto= $O('ddlGrupoCentroCosto');
					idGrupoCentroCosto = oddlGrupoCentroCosto.options[oddlGrupoCentroCosto.selectedIndex].value;
				}
				$O('hGrupoCC').value = idGrupoCentroCosto;
				
				var oddlCentroCosto = new System.Web.UI.WebControls.DropDownList('ddlCentroCosto');
				oddlCentroCosto.DataSource = (new Controladora.General.CentroCosto()).ListarCentroCostoPorGrupoCC(idGrupoCentroCosto);
				oddlCentroCosto.DataTextField = "NRONOMCC";
				oddlCentroCosto.DataValueField = "IDCENTROCOSTO";
				oddlCentroCosto.SelectedIndexChanged = CargarDatos;
				oddlCentroCosto.DataBind();
				try{
					ListItem = oddlCentroCosto.FindByValue($O('hCentroCosto').value);
				}catch(error){}
			}
			function CargarDatos(){
				var oddlCentroCosto= $O('ddlCentroCosto');
				$O('hCentroCosto').value = oddlCentroCosto.options[oddlCentroCosto.selectedIndex].value;
				
			}
			
			/*
			function LoadPrueba(){
				var url =  "/SimanetWeb/General/Formato/AdministrarFormatoDetalleMovimientoporPeriodo.aspx?IdFormato=31&IdReporte=1&NFormato=BALANCE&Periodo=2017&idcop=2&idCC=0&idTipoInfo=0&ReqCC=0&ReqCtaCtable=2&Acum=1&Close=0&IdTipForm=1";
				
				  jSIMA('#container').load(url, function(responseText, statusText, xhr)
       											{
               											if(statusText == "success")
                       											alert("Successfully loaded the content!");
               											if(statusText == "error")
                       											alert("An error occurred: " + xhr.status + " - " + xhr.statusText);
       											});

			}
			*/
		</script>
</HEAD>
	<body onunload="SubirHistorial();" onload="CentroOperativoSeleccionado();ObtenerHistorial();"
		bottomMargin="0" leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<table border="0" cellSpacing="0" cellPadding="0" width="100%" align="center">
				<tr>
					<td width="100%"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr>
					<td bgColor="#eff7fa" vAlign="top" width="100%"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
				<TR>
					<TD class="RutaPaginaActual" vAlign="top" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Administrar Estados Financieros</asp:label></TD>
				</TR>
				<TR>
					<TD bgColor="whitesmoke" vAlign="top" width="100%" align="center"></TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%" align="center">
						<TABLE style="HEIGHT: 73px" id="Table1" border="0" cellSpacing="1" cellPadding="1" width="100%">
							<TR>
								<TD style="BORDER-BOTTOM: #808080 1px dotted; PADDING-BOTTOM: 5px; HEIGHT: 20px" width="100%"
									align="left">
									<DIV align="left">
										<DIV align="center">
											<TABLE style="Z-INDEX: 0; WIDTH: 846px; HEIGHT: 16px" id="tblOpciones" border="0" cellSpacing="0"
												cellPadding="0" width="846">
												<TR>
													<TD style="HEIGHT: 8px; COLOR: black; FONT-WEIGHT: bold" class="normaldetalle" width="100%"
														colSpan="7" align="center"></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 147px; COLOR: black; FONT-WEIGHT: bold" class="normaldetalle"><asp:label id="Label1" runat="server" Width="121px">Centro Operativo</asp:label></TD>
													<TD style="WIDTH: 158px"><asp:dropdownlist id="ddlCentroOperativo" runat="server" CssClass="normaldetalle" Width="152px" AutoPostBack="True"></asp:dropdownlist></TD>
													<TD style="WIDTH: 62px"></TD>
													<TD style="WIDTH: 94px"></TD>
													<TD style="WIDTH: 90px"></TD>
													<TD style="WIDTH: 307px"></TD>
													<TD></TD>
												</TR>
												<TR style="DISPLAY: none" id="idFilaGrupoyCentroCosto">
													<TD style="WIDTH: 147px; COLOR: black; FONT-WEIGHT: bold" class="normaldetalle"><asp:label style="Z-INDEX: 0" id="Label4" runat="server"> Grupo</asp:label></TD>
													<TD width="50%" colSpan="3"><asp:dropdownlist style="Z-INDEX: 0" id="ddlGrupoCentroCosto" runat="server" CssClass="normaldetalle"
															Width="100%"></asp:dropdownlist></TD>
													<TD style="WIDTH: 90px; COLOR: black; FONT-WEIGHT: bold" class="normaldetalle"><asp:label style="Z-INDEX: 0" id="Label5" runat="server" Width="120px">Centro de costo:</asp:label></TD>
													<TD width="50%"><asp:dropdownlist style="Z-INDEX: 0" id="ddlCentroCosto" runat="server" CssClass="normaldetalle" Width="100%"></asp:dropdownlist></TD>
													<TD></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 147px; COLOR: black; FONT-WEIGHT: bold" class="normaldetalle"><asp:label id="Label2" runat="server" Width="143px">Tipo de infomación</asp:label></TD>
													<TD style="WIDTH: 158px"><asp:dropdownlist id="ddlTipoInformacion" runat="server" CssClass="normaldetalle" Width="155px" AutoPostBack="True"></asp:dropdownlist></TD>
													<TD style="WIDTH: 62px; COLOR: black; FONT-WEIGHT: bold"><asp:label id="Label3" runat="server" CssClass="normaldetalle">Periodo:</asp:label></TD>
													<TD style="WIDTH: 94px"><asp:dropdownlist id="ddlPeriodo" runat="server" CssClass="normaldetalle" AutoPostBack="True"></asp:dropdownlist></TD>
													<TD></TD>
													<TD></TD>
													<TD></TD>
												</TR>
											</TABLE>
										</DIV>
									</DIV>
								</TD>
							</TR>
							<TR>
								<TD style="BORDER-BOTTOM: #808080 1px dotted; PADDING-BOTTOM: 5px; HEIGHT: 20px" id="LstBtnGrupos"
									class="TextoNegroNegrita" width="100%" align="left"></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 20px; PADDING-TOP: 8px" id="divContenedor" class="TextoNegroNegrita"
									width="100%" align="left">Ud. No tiene Acceso a los formato con este tipo de 
									información</TD>
							</TR>
							<TR>
								<TD><IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"><INPUT style="WIDTH: 24px; HEIGHT: 22px" id="hTabSeleccionado" size="1" type="hidden" name="hTabSeleccionado"
										runat="server"><INPUT style="WIDTH: 24px; HEIGHT: 22px" id="hCodigoFormato" size="1" type="hidden" name="Hidden1"
										runat="server"></TD>
							</TR>
							<TR>
								<TD></TD>
							</TR>
						</TABLE>
						<INPUT style="WIDTH: 32px; HEIGHT: 22px" id="hGrupoCC" value="0" size="1" type="hidden"
							runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 32px; HEIGHT: 22px" id="hCentroCosto" value="0" size="1"
							type="hidden" name="Hidden1" runat="server"> <INPUT style="Z-INDEX: 0; WIDTH: 32px; HEIGHT: 22px" id="hPeriodo" value="0" size="1" type="hidden"
							name="hPeriodo" runat="server">
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px" vAlign="top" width="100%" align="center"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
				</TR>
			</table>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			
				oddlbTipoInformacion = new System.Web.UI.WebControls.DropDownList('ddlTipoInformacion');
				oddlbCentroOperativo = new System.Web.UI.WebControls.DropDownList('ddlCentroOperativo');
				oddlbPeriodo = new System.Web.UI.WebControls.DropDownList('ddlPeriodo');
				
				var LItemCentroOperativo = oddlbCentroOperativo.ListItem();
				var LItemPeriodo = oddlbPeriodo.ListItem();
				var LItemTipoInformacion= oddlbTipoInformacion.ListItem();			
			
			var IntDefaultGrp;
			function CargarGrupos(){
				var oDataTable = new System.Data.DataTable("tblGrupoCC");
				oDataTable = (new Controladora.General.CFormato()).ObtenerGruposFormato(LItemCentroOperativo.value,LItemPeriodo.value,1,LItemTipoInformacion.value);
					for (f=0;f<=oDataTable.Rows.Items.length-1;f++){
						var oDataRow = oDataTable.Rows.Items[f];
						if(oDataRow.Item("EOF")==false){
							var tbl=SIMA.Utilitario.Helper.CrearTabla(1,1);
							tbl.rows[0].cells[0].innerText=oDataRow.Item("NombreGrupo");
							tbl.style.cssText="MARGIN-BOTTOM:5px;MARGIN-LEFT:10px";
							
							var HtmlTBL = jSIMA(tbl);
							IntDefaultGrp = oDataRow.Item("IdGrupo");
							var NomTbl ="tbl"+IntDefaultGrp; 
							HtmlTBL.attr("id",NomTbl);
							HtmlTBL.attr("IdGrupo",IntDefaultGrp);
							HtmlTBL.attr("align","left");
							HtmlTBL.attr("class","BaseItemInGrid");

							jSIMA(HtmlTBL).click(function(){
													var IdGrp =jSIMA(this).attr("IdGrupo");													
													var IdgrpSelec =   jSIMA.GetClientData(SIMA.Utilitario.Enumerados.TipoSaveClient.Local,'GrpSelecMov');
													IdgrpSelec = ((IdgrpSelec!=undefined)||(IdgrpSelec!=null))?IdgrpSelec.toString().replace('G',''):0;
													if(IdGrp != IdgrpSelec){
														jSIMA('#tbl'+ IdgrpSelec).attr("class","BaseItemInGrid");
													}
													 
													jSIMA.SaveClientData(SIMA.Utilitario.Enumerados.TipoSaveClient.Local,'GrpSelecMov',('G'+IdGrp) );
													
													jSIMA(this).attr("class","BaseItemInGridMsg");
													//CargarTabs(IdGrp );
													oFormato.Load(IdGrp);
												});
												
							jSIMA('#LstBtnGrupos').append(HtmlTBL);
						}
					}
					//Esatblece por default el control ultimo seleccionado.
						var IdgrpSelecDefault =   jSIMA.GetClientData(SIMA.Utilitario.Enumerados.TipoSaveClient.Local,'GrpSelecMov');
						var GrpSelec = (((IdgrpSelecDefault!=undefined)||(IdgrpSelecDefault!=null))?IdgrpSelecDefault.toString().replace('G',''):IntDefaultGrp);
						var CtrlGroup = jSIMA("#tbl"+GrpSelec);
						jSIMA(CtrlGroup).click();
			}
			
			CargarGrupos();			
		</SCRIPT>
	</body>
</HTML>
