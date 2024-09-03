<%@ Page language="c#" Codebehind="DefaultAdministrarEstadosFinancieros.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancieros.DefaultAdministrarEstadosFinancieros" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>DefaultAdministrarEstadosFinancieros</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/@Import.js">  </SCRIPT>
		<SCRIPT language="javascript" src="../../js/JQuery/js/jquery.min.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/JQuery/js/JQueryPlugInSIMA.js"></SCRIPT>
		<SCRIPT>
			var jSIMA = jQuery.noConflict();
		</SCRIPT>
		<script>
			function FormatoBE(INDEX,CODIGO,NOMBRE,PROCESAR,CTRLCIERRE,IDREPORTE,REQCTACTABLE){
				this.Index=INDEX;
				this.Codigo=CODIGO;
				this.IdReporte=IDREPORTE;
				this.Nombre=NOMBRE;
				this.Procesar=PROCESAR;
				this.CtrlCierre=CTRLCIERRE;
				this.ReqCtaCtable=REQCTACTABLE;
			}
			
			
			var PrefCtrl="_ctl4_";
			var oddlbCentroOperativo;
			var oddlbPeriodo;
			var oddlbMes;
			var oddlbTipoInformacion;

				
				
			function CargarTabs(IdGrupo)
			{
				//Limpia el contenedor de tabs
				jSIMA("#divContenedor").empty(); 
				
				LItemCentroOperativo = oddlbCentroOperativo.ListItem();
				LItemPeriodo = oddlbPeriodo.ListItem();
				LItemMes = oddlbMes.ListItem();
				LItemTipoInformacion= oddlbTipoInformacion.ListItem();		
				
				oPagina = new SIMA.Utilitario.Helper.General.Pagina();
				oTabStrip= new SIMA.Utilitario.Helper.General.TabStrip($O("divContenedor"));
				oTabStrip.PathImagen= SIMA.Utilitario.Helper.General.ObtenerPathApp() + "/Imagenes/Tabs/";
				var urlPaginaAdministraEF;
				var Parametros;
				var QIDEMP = "idEmp";
				var KEYQIDGRUPOFORMATO="IdGrupoFormato";
				var KEYQREQCTATABLE="ReqCta";
				
				var pidReporte =1;
					if (parseInt(oPagina.Request.Params["Especificacion"])==0)//MAntenimiento de los estados financieros Montos
					{
						urlPaginaAdministraEF = SIMA.Utilitario.Helper.General.ObtenerPathApp() + "/GestionFinanciera/EstadosFinancieros/ConsultaDeEstadosFinancieros.aspx?";
					}
					else//MAntenimiento de los estados Sima peru financieros Descripciones
					{
						var NombreControlCEOP = "_ctl4_trCentroOperativo";
						objFilaCEOP = $O(NombreControlCEOP);
						objFilaCEOP.style.display = SIMA.Utilitario.Constantes.Html.Atributos.Display.None.toString();
						urlPaginaAdministraEF = SIMA.Utilitario.Helper.General.ObtenerPathApp() + "/GestionFinanciera/EstadosFinancieros/ConsultaDeEstadosFinancierosPERU.aspx?";
					}
				
					
					var Existe=false;
					with(SIMA.Utilitario.Constantes.General.Caracter)
					{
						/*Parametros = "idReporte" + SignoIgual.toString() + pidReporte
									+ signoAmperson.toString()
									+ "idEmp" + SignoIgual.toString() + oPagina.Request.Params[QIDEMP];
						*/
							Parametros = "idEmp" + SignoIgual.toString() + oPagina.Request.Params[QIDEMP];

					
							var oDataTable = new System.Data.DataTable("tblGrupoCC");
							//oDataTable = (new Controladora.General.CFormato()).ListarAccesoSegunPrivilegioUsuarioUsuarioCtrlCierre(LItemCentroOperativo.value,LItemPeriodo.value,LItemMes.value,LItemTipoInformacion.value);
							oDataTable = (new Controladora.General.CFormato()).ListarGruposFormAccesoSegunPrivilegioUsuarioUsuarioCtrlCierre(LItemCentroOperativo.value,LItemPeriodo.value,LItemMes.value,LItemTipoInformacion.value,IdGrupo);
							
							for (f=0;f<=oDataTable.Rows.Items.length-1;f++){
									var oDataRow =oDataTable.Rows.Items[f];
									if(oDataRow.Item("EOF")==false){
										Existe=true;
										var oFormatoBE = new FormatoBE();
										oFormatoBE.Index=f;
										oFormatoBE.Codigo=oDataRow.Item("IdFormato");
										oFormatoBE.Nombre=oDataRow.Item("Nombre");
										oFormatoBE.Procesar=oDataRow.Item("Procesar");
										oFormatoBE.CtrlCierre = oDataRow.Item("Cerrado");
										oFormatoBE.IdReporte= oDataRow.Item("IdReporte");
										oFormatoBE.ReqCtaCtable=oDataRow.Item("ReqCtaCtable");
										
										var ParametrosFormato = signoAmperson.toString()
																+ "IdFormato" + SignoIgual.toString() +  oFormatoBE.Codigo
																+ signoAmperson.toString()
																+ "IdReporte" + SignoIgual.toString() + oFormatoBE.IdReporte
																+ signoAmperson.toString()
																+ "NFormato" + SignoIgual.toString() +  oFormatoBE.Nombre
																+ signoAmperson.toString()
																+ "Acumulado=1"
																+ signoAmperson.toString()
																+ "PrcFMT" + SignoIgual.toString() +  oFormatoBE.Procesar
																+ signoAmperson.toString()
																+ KEYQREQCTATABLE + SignoIgual.toString() +  oFormatoBE.ReqCtaCtable
																+ signoAmperson.toString()
																+ "CtrlCierre" + SignoIgual.toString() +  oFormatoBE.CtrlCierre;
																
										oTab = new SIMA.Utilitario.Helper.General.Tab(oFormatoBE.Nombre,urlPaginaAdministraEF + Parametros +ParametrosFormato ,"Administrar " + oFormatoBE.Nombre);
										oTab.Tag = oFormatoBE;
										oTab.EventHandle = TabSeleccionado;						
										oTabStrip.Tabs.Adicionar(oTab);
									}
							}
							
							if(Existe==true){
								var IdgrpSelecDefault=jSIMA.GetClientData(SIMA.Utilitario.Enumerados.TipoSaveClient.Local,'GrpSelec');
								var GrpSelec = (((IdgrpSelecDefault!=undefined)||(IdgrpSelecDefault!=null))?IdgrpSelecDefault.toString().replace('G',''):1);
								var idxTab = jSIMA.GetClientData(SIMA.Utilitario.Enumerados.TipoSaveClient.Local,('TabSelec'+GrpSelec),('T'+ GrpSelec));
									idxTab = (((idxTab!=undefined)||(idxTab!=null))?idxTab.toString().replace('T',''):0);
									oTabStrip.RepintarTabs();
									window.setTimeout(function(){oTabStrip.Tabs.Tab(idxTab).Click();},200);
							}
					
					}
			}
			
			function TabSeleccionado(){
				var oFormatoBE = new FormatoBE();
				oFormatoBE = this.Tag;
				var IdgrpSelecDefault=jSIMA.GetClientData(SIMA.Utilitario.Enumerados.TipoSaveClient.Local,'GrpSelec');
				var GrpSelec = (((IdgrpSelecDefault!=undefined)||(IdgrpSelecDefault!=null))?IdgrpSelecDefault.toString().replace('G',''):1);
				jSIMA.SaveClientData(SIMA.Utilitario.Enumerados.TipoSaveClient.Local,'TabSelec'+GrpSelec,('T'+ oFormatoBE.Index));
			}
			
		</script>
</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table border="0" cellSpacing="0" cellPadding="0" width="100%" align="center">
				<tr>
					<td width="100%"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr>
					<td vAlign="top" width="100%" bgColor="#eff7fa"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
				<TR>
					<TD class="RutaPaginaActual" vAlign="top" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Administrar Estados Financieros</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE id="Table1" border="0" style="WIDTH: 643px; HEIGHT: 73px" cellSpacing="1" cellPadding="1"
							width="643">
							<TR>
								<TD align="left" width="100%">
									<DIV align="left">
										<TABLE class="tabla" id="TblTabs" style="HEIGHT: 36px" cellSpacing="0" cellPadding="0"
											width="100%" align="left" bgColor="#f5f5f5" border="0" runat="server">
											<TR>
												<TD></TD>
												<TD style="WIDTH: 371px"><asp:panel id="Panel" runat="server" Width="368px">Panel</asp:panel></TD>
												<TD vAlign="bottom" align="left"><asp:button id="btnConsultar" style="BACKGROUND-COLOR: #306898; FONT-FAMILY: Arial Narrow; COLOR: #ffffcc; FONT-SIZE: 8pt"
														runat="server" Text="Consultar"></asp:button><IMG id="IbtnImprimir" style="DISPLAY: none" onclick="oPrint = new SIMA.Utilitario.Helper.Dialogos();oPrint.VistaPrevia(this);"
														alt="" src="../../imagenes/bt_imprimir.gif"></TD>
											</TR>
										</TABLE>
									</DIV>
								</TD>
								<TD width="100%" align="left"></TD>
							</TR>
							<TR>
								<TD style="BORDER-BOTTOM: #808080 1px dotted; PADDING-BOTTOM: 5px; HEIGHT: 14px" class="TextoNegroNegrita"
									width="100%" align="left">
									<P style="MARGIN-LEFT: 5px">GRUPO DE FORMATOS:</P>
								</TD>
								<TD class="TextoNegroNegrita" width="100%" align="left"></TD>
							</TR>
							<TR>
								<TD id="LstBtnGrupos" class="TextoNegroNegrita" width="100%" align="left" runat="server"  style="BORDER-BOTTOM: #808080 1px dotted; PADDING-BOTTOM: 5px" noWrap></TD>
								<TD class="TextoNegroNegrita" width="100%" align="left"></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 20px" class="TextoNegroNegrita" width="100%" align="left"></TD>
								<TD style="HEIGHT: 20px" class="TextoNegroNegrita" width="100%" align="left"></TD>
							</TR>
							<TR>
								<TD id="divContenedor" style="HEIGHT: 20px" align="left" width="100%" class="TextoNegroNegrita"></TD>
								<TD style="HEIGHT: 20px" class="TextoNegroNegrita" width="100%" align="left"></TD>
							</TR>
							<TR>
								<TD><IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"><INPUT id="hTabSeleccionado" style="WIDTH: 24px; HEIGHT: 22px" type="hidden" size="1" runat="server"><INPUT id="hCodigoFormato" style="WIDTH: 24px; HEIGHT: 22px" type="hidden" size="1" name="Hidden1"
										runat="server"></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD><INPUT style="Z-INDEX: 0; WIDTH: 24px; HEIGHT: 22px" id="hIdGrupo" size="1" type="hidden"
										name="Hidden1" runat="server"></TD>
								<TD></TD>
							</TR>
						</TABLE>
						<INPUT id="hGridPaginaSort" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" value="0"
							name="hGridPaginaSort" runat="server">
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px" vAlign="top" align="center" width="100%"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
				</TR>
			</table>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			
				oddlbTipoInformacion = new System.Web.UI.WebControls.DropDownList(PrefCtrl+'ddlbTipoInformacion');
				oddlbCentroOperativo = new System.Web.UI.WebControls.DropDownList(PrefCtrl+'ddlbCentroOperativo');
				oddlbPeriodo = new System.Web.UI.WebControls.DropDownList(PrefCtrl+'ddlbPeriodo');
				oddlbMes = new System.Web.UI.WebControls.DropDownList(PrefCtrl+'ddlbMes');
				
				var LItemCentroOperativo = oddlbCentroOperativo.ListItem();
				var LItemPeriodo = oddlbPeriodo.ListItem();
				var LItemMes = oddlbMes.ListItem();
				var LItemTipoInformacion= oddlbTipoInformacion.ListItem();			
			
			var Count=1;
			var IntDefaultGrp;
			function CargarGrupos(){
				DivContext = document.createElement('div');
				DivContext.id="dvGrpContext";
				DivContext.style.cssText = "width:100%;height:50px;overflow-x:auto";
				jSIMA('#LstBtnGrupos').append(DivContext);
			
			
				var oDataTable = new System.Data.DataTable("tblGrupoCC");
				oDataTable = (new Controladora.General.CFormato()).ObtenerGruposFormato(LItemCentroOperativo.value,LItemPeriodo.value,LItemMes.value,LItemTipoInformacion.value);
					for (f=0;f<=oDataTable.Rows.Items.length-1;f++){
						var oDataRow =oDataTable.Rows.Items[f];
						if(oDataRow.Item("EOF")==false){
							var tbl=SIMA.Utilitario.Helper.CrearTabla(1,1);
							tbl.rows[0].cells[0].innerText=oDataRow.Item("NombreGrupo");
							tbl.rows[0].cells[0].setAttribute("noWrap","noWrap");
							tbl.style.cssText="MARGIN-BOTTOM:5px;MARGIN-LEFT:10px";
							IntDefaultGrp=oDataRow.Item("IdGrupo"); 
							var HtmlTBL = jSIMA(tbl);
							var NomTbl ="tbl"+IntDefaultGrp; 
							HtmlTBL.attr("id",NomTbl);
							HtmlTBL.attr("IdGrupo",IntDefaultGrp);
							HtmlTBL.attr("align","left");
							HtmlTBL.attr("class","BaseItemInGrid");
							

							jSIMA(HtmlTBL).click(function(){
													var IdGrp =jSIMA(this).attr("IdGrupo");
													var IdgrpSelec =   jSIMA.GetClientData(SIMA.Utilitario.Enumerados.TipoSaveClient.Local,'GrpSelec');
													IdgrpSelec = ((IdgrpSelec!=undefined)||(IdgrpSelec!=null))?IdgrpSelec.toString().replace('G',''):0;
													if(IdGrp != IdgrpSelec){
														jSIMA('#tbl'+ IdgrpSelec).attr("class","BaseItemInGrid");
													}
													 
													jSIMA.SaveClientData(SIMA.Utilitario.Enumerados.TipoSaveClient.Local,'GrpSelec',('G'+IdGrp.toString()));
													
													jSIMA(this).attr("class","BaseItemInGridMsg");
													CargarTabs(IdGrp );
												});
							jSIMA('#dvGrpContext').append(HtmlTBL);
							//jSIMA('#LstBtnGrupos').append(HtmlTBL);
						}
					}
					//Esatblece por default el control ultimo seleccionado.
						var IdgrpSelecDefault =   jSIMA.GetClientData(SIMA.Utilitario.Enumerados.TipoSaveClient.Local,'GrpSelec');
						var GrpSelec = (((IdgrpSelecDefault!=undefined)||(IdgrpSelecDefault!=null))?IdgrpSelecDefault.toString().replace('G',''):IntDefaultGrp);
						var CtrlGroup = jSIMA("#tbl"+GrpSelec);
						jSIMA(CtrlGroup).click();
			}
			
			CargarGrupos();
			
		</SCRIPT>
	</body>
</HTML>
