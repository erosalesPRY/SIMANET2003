<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="AdministrarProyectoInversion.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionEstrategica.Proyecto.AdministrarProyectoInversion" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AdministrarProyectoInversion</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../../styles.css">
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>
		<script type="text/javascript" src="/SimaNetWeb/js/Upload/mint"></script>
		<script type="text/javascript" src="/SimaNetWeb/js/Upload/si.files.js"></script>
		<script type="text/javascript" src="/SimaNetWeb/js/RegEXT.js"></script>
		<STYLE title="text/css" type="text/css">.SI-FILES-STYLIZED LABEL.cabinet {
	WIDTH: 95px; DISPLAY: block; BACKGROUND: url(/SimaNetWeb/imagenes/Navegador/BtnOpciones/AnexarArchivo.bmp) no-repeat 0px 0px; HEIGHT: 25px; OVERFLOW: hidden; CURSOR: hand
}
.SI-FILES-STYLIZED LABEL.cabinet INPUT.file {
	POSITION: relative; FILTER: progid:DXImageTransform.Microsoft.Alpha(opacity=0); WIDTH: auto; HEIGHT: 100%; opacity: 0; -moz-opacity: 0
}
		</STYLE>
	</HEAD>
	<body onunload="SubirHistorial();" onload="ObtenerHistorial();" bottomMargin="0" leftMargin="0"
		rightMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table2" border="0" cellSpacing="0" cellPadding="0" width="100%" align="center">
				<TR>
					<TD vAlign="top" width="100%"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<tr>
					<TD vAlign="top" width="100%"><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</tr>
				<TR>
					<TD style="HEIGHT: 12px" class="Commands"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio>Estrategica  ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> PROYECTOS DE INVERSION PUBLICA</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top">
						<TABLE id="Table3" border="0" cellSpacing="0" cellPadding="0" width="100%" align="center">
							<TR width="100%">
								<td>
									<TABLE id="Table4" border="0" cellSpacing="1" cellPadding="1" width="100%" align="left">
										<TR>
											<TD width="50%"><asp:imagebutton style="Z-INDEX: 0" id="ibtnFiltro" runat="server" ImageUrl="../../imagenes/filtrar.gif"></asp:imagebutton><IMG style="Z-INDEX: 0" id="ibtnFiltrarSeleccion" onclick="FiltroporSeleccion(1);" alt="Aplicar Filtro por Selección"
													src="/SimanetWeb/imagenes/filtroporseleccion.jpg">
												<asp:imagebutton style="Z-INDEX: 0" id="ibtnEliminaFiltro" runat="server" ImageUrl="/SimanetWeb/imagenes/filtroEliminar.GIF"
													ToolTip="Eliminar Filtro.."></asp:imagebutton></TD>
											<TD width="100" align="right">
												<table border="0" cellSpacing="0" cellPadding="0" align="left">
													<tr>
														<td><LABEL class="cabinet"><INPUT style="Z-INDEX: 0" id="FUFile" class="file" size="1" type="file" name="FUFile" runat="server"></LABEL>
														</td>
														<td><IMG style="Z-INDEX: 0; WIDTH: 16px; HEIGHT: 6px" alt="" src="/SIMANETWEB/imagenes/spacer.gif"
																width="16" height="6"></td>
														<td><IMG style="Z-INDEX: 0; CURSOR: hand" id="imgResumen" onclick="ResumePIP();" src="../../imagenes/Navegador/ResumenPIP.gif"
																height="19">
														</td>
													</tr>
												</table>
											</TD>
											<TD width="100%" align="center"><IMG style="Z-INDEX: 0; HEIGHT: 24px; CURSOR: hand" id="ibtnAyuda" onclick="LlamarAyuda();"
													src="../../imagenes/Navegador/ibtnSNIPHelp2.gif" width="195" height="0"></TD>
											<TD width="50%">
												<TABLE style="WIDTH: 423px; HEIGHT: 24px" id="Table5" border="0" cellSpacing="1" cellPadding="1"
													width="423" align="right">
													<TR>
														<TD align="right"><asp:imagebutton style="Z-INDEX: 0" id="ibtnAgregar" runat="server" ImageUrl="../../imagenes/bt_agregar.gif"
																CausesValidation="False"></asp:imagebutton></TD>
														<TD><asp:imagebutton style="Z-INDEX: 0" id="ibtnInsertar" runat="server" ImageUrl="../../imagenes/bt_insertar.gif"
																CausesValidation="False"></asp:imagebutton></TD>
														<TD><IMG style="Z-INDEX: 0" id="ibtnEliminarRegProy" onclick="EliminarProyecto();" alt=""
																src="../../imagenes/bt_eliminar.gif" runat="server"></TD>
														<TD width="100%" align="right"></TD>
														<TD align="right"><IMG style="Z-INDEX: 0" id="imgBitacora" onclick="Bitacora();" alt="" src="../../imagenes/btnBitacora.jpg"></TD>
														<TD></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</TABLE>
								</td>
							<TR>
								<TD align="center">
									<TABLE id="Table1" class="normal" border="0" cellSpacing="0" cellPadding="0" width="100%">
										<TR>
											<TD width="100%" align="center"><cc1:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" Width="100%" RowPositionEnabled="False"
													RowHighlightColor="#E0E0E0" AllowPaging="True" AutoGenerateColumns="False" AllowSorting="True" ShowFooter="True">
													<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
													<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
													<FooterStyle CssClass="FooterGrilla"></FooterStyle>
													<ItemStyle CssClass="ItemGrilla"></ItemStyle>
													<Columns>
														<asp:TemplateColumn HeaderText="NRO" FooterText="TOTAL:">
															<HeaderStyle Width="1%"></HeaderStyle>
															<ItemStyle Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
														</asp:TemplateColumn>
														<asp:BoundColumn DataField="CodigoPIP" SortExpression="CodigoPIP" HeaderText="CODIGO">
															<HeaderStyle Width="5%"></HeaderStyle>
															<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="NombreCentroOperativo" SortExpression="NombreCentroOperativo" HeaderText="CO">
															<HeaderStyle Width="5%"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="CodigoSNIP" SortExpression="CodigoSNIP" HeaderText="COD. SNIP">
															<HeaderStyle Width="8%"></HeaderStyle>
															<ItemStyle Wrap="False"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="NombreProyecto" SortExpression="NombreProyecto" HeaderText="PROYECTO">
															<HeaderStyle Width="25%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
															<FooterStyle HorizontalAlign="Right" VerticalAlign="Bottom"></FooterStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Descripcion" HeaderText="DESCRIPCION">
															<HeaderStyle Width="25%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="NombreEtapa" SortExpression="NombreEtapa" HeaderText="ETAPA">
															<HeaderStyle Width="5%"></HeaderStyle>
															<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
															<FooterStyle HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Componentes" HeaderText="COMPONENTES">
															<HeaderStyle Width="5%"></HeaderStyle>
															<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="AvanceFisico" SortExpression="AvanceFisico" HeaderText="AF">
															<HeaderStyle Width="5%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="AvanceEconomico" SortExpression="AvanceEconomico" HeaderText="AE">
															<HeaderStyle Width="5%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
														</asp:BoundColumn>
													</Columns>
													<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
												</cc1:datagridweb></TD>
										</TR>
										<TR>
											<TD width="100%" align="center"><asp:label style="Z-INDEX: 0" id="lblResultado" runat="server" CssClass="ResultadoBusqueda"
													Visible="False"></asp:label></TD>
										</TR>
									</TABLE>
									<INPUT style="WIDTH: 48px; HEIGHT: 24px" id="hPathArchivo" size="2" type="hidden" runat="server">
									<INPUT style="Z-INDEX: 0; WIDTH: 48px; HEIGHT: 24px" id="hCodigoPIP" value="0" size="2"
										type="hidden" name="Hidden2" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 48px; HEIGHT: 24px" id="hIdProyPerfil" value="0" size="2"
										type="hidden" name="Hidden2" runat="server"> <INPUT style="Z-INDEX: 0; WIDTH: 48px; HEIGHT: 24px" id="hIdTipoProy" value="1" size="2"
										type="hidden" name="Hidden2" runat="server">
								</TD>
							</TR>
							<TR>
								<TD align="left"><IMG style="Z-INDEX: 0; CURSOR: hand" id="ibtnAtras" onclick="HistorialIrAtras();" alt=""
										src="/SimanetWeb/imagenes/atras.gif"><INPUT style="Z-INDEX: 0; WIDTH: 16px; HEIGHT: 16px" id="hIdPIP" size="1" type="hidden"
										name="hEtapa" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 16px; HEIGHT: 16px" id="hIdNivel" size="1" type="hidden"
										name="hEtapa" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 16px; HEIGHT: 16px" id="hEtapa" size="1" type="hidden"
										name="hEtapa" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 16px; HEIGHT: 16px" id="hIndicePagina" value="0" size="1"
										type="hidden" name="hIndicePagina" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 16px; HEIGHT: 16px" id="hColumnaOrdenamiento" size="1"
										type="hidden" name="hColumnaOrdenamiento" runat="server">
									<asp:button style="Z-INDEX: 0" id="btnSubir" runat="server" Text="Subir"></asp:button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT language="javascript" type="text/javascript">
			// <![CDATA[
					SI.Files.stylizeAll();
			// ]]>
			
				var oFUFile = jNet.get('FUFile');
					oFUFile.addEvent("change",function(){
							var arrNombre = jNet.get('FUFile').value.split('.');
							if(arrNombre[arrNombre.length-1]!='xls'){
								Ext.MessageBox.alert('RESUMEN PIP', 'Extension de archivo no valida, se esperaba un .htm', function(btn){});
							}
							else{
								__doPostBack('btnSubir','');
							}
					});
					
		</SCRIPT>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>	
		</SCRIPT>
		<script>
			
				function EliminarProyecto(){
					if(jNet.get("hIdPIP").value==0){
						Ext.MessageBox.alert('PROYECTO DE INVERSION', 'No se ha seleccionado registro a eliminar', function(btn){});
					}
					else{
							Ext.MessageBox.confirm('Confirmar', 'Desea ud. eliminar este registro ahora?', function(btn){
								if(btn=="yes"){
									if(jNet.get('hIdTipoProy').value=='1'){
										(new Controladora.Estrategica.CProyectoGeneral()).Eliminar(jNet.get("hIdPIP").value);
									}
									else{
										(new Controladora.Estrategica.CProyectoPerfil()).Eliminar(jNet.get("hIdProyPerfil").value);
									}
									document.location.reload();
								}
							});					
					}
				}
				var URLPAGINABITACORA = "/" + ApplicationPath + "/GestionEstrategica/Proyecto/AdministrarProyectoInversionBitacora.aspx?";
				function Bitacora(){
					if(jNet.get("hIdPIP").value==0){
					
						Ext.MessageBox.alert('PROYECTO DE INVERSION', 'No se ha seleccionado un registro', function(btn){});
					}
					else{
						(new System.Ext.UI.WebControls.Windows()).Dialogo('BITACORA',URLPAGINABITACORA + SIMA.Utilitario.Constantes.Estrategica.KEYQIDPROYECTOPERFIL + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + jNet.get("hIdPIP").value,jNet.get('imgBitacora'),600,520);
					}
				}
				var URLPAGINACOMPONENTE= "/" + ApplicationPath + "/GestionEstrategica/Proyecto/AdministrarComponentes.aspx?";
				function Componente(){
					if(jNet.get("hIdPIP").value==0){
						Ext.MessageBox.alert('PROYECTO DE INVERSION', 'No se ha seleccionado un registro', function(btn){});
					}
					else{
						(new System.Ext.UI.WebControls.Windows()).Dialogo('COMPONENTES',URLPAGINACOMPONENTE + SIMA.Utilitario.Constantes.Estrategica.KEYQIDPROYECTOPERFIL + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + jNet.get("hIdPIP").value,jNet.get('imgBitacora'),600,520);
					}
				}
				
				function receiveContent(options, success, response){ 
					window.alert();
				}
 
				function LlamarAyuda(){
					var KEYQIDAYUDA= "IDHELP";
					var KEYQIDITEM= "IDITEM";
					var TabDetalle=new Array();
					var IdTablaAyudaPIP = 512;
					var idx=0;
					var oDataTable = new System.Data.DataTable("tblGrupoCC");
						oDataTable = (new Controladora.General.CTablaTablas()).ListarTodosCombo(IdTablaAyudaPIP);
						for (f=0;f<=oDataTable.Rows.Items.length-1;f++){
							var oDataRow =oDataTable.Rows.Items[f];
							if(oDataRow.Item("EOF")==false){
								var URLLOCAL = "/SimaNetWeb/General/AyudaContenido.aspx?" + KEYQIDAYUDA + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + IdTablaAyudaPIP
																						+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
																						+ KEYQIDITEM +SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + oDataRow.Item("codigo");
								//URLLOCAL= oDataRow.Item("Descripcion");																				
								TabDetalle[idx]={title : oDataRow.Item("var1"),autoLoad: {url: URLLOCAL, scripts : true}};
								idx++;
							}
						}
						
						(new System.Ext.UI.WebControls.Windows()).DialogoTabs('AYUDA P.I.P',TabDetalle,this,window.screen.width-550,window.screen.height-150);
				}

				(function(){
					var oDataGrid = jNet.get("grid");
					for(var i=1;i<=oDataGrid.rows.length-3;i++){
						var row=oDataGrid.rows[i];
						var olobj = row.cells[7].children[0];
						if(olobj.tagName=='OL'){
							var lists = olobj.getElementsByTagName("LI");
							for (var p=0;p<lists.length; p++){
								lists[p].innerText = "  " + (p+1) + ".    " + lists[p].innerText;
							}
						}
					}
				})();


				function ResumePIP(){
					(new SIMA.Utilitario.Helper.Window()).AbrirExcel(jNet.get('hPathArchivo').value +'Ayuda/ResumenPIP.xls');
				}


		</script>
		<style> LI { LIST-STYLE-TYPE: decimal }
		</style>
	</body>
</HTML>
