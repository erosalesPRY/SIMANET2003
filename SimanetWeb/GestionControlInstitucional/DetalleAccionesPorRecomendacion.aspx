<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="DetalleAccionesPorRecomendacion.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionControlInstitucional.DetalleAccionesPorRecomendacion" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>DetalleAccionesPorRecomendacion</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../styles.css">
		<SCRIPT language="javascript" src="../js/@Import.js"></SCRIPT>
		<script type="text/javascript" src="/SimaNetWeb/js/Upload/mint"></script>
		<script type="text/javascript" src="/SimaNetWeb/js/Upload/si.files.js"></script>
		<script type="text/javascript" src="/SimaNetWeb/js/RegEXT.js"></script>
		<script type="text/javascript" src="/SimaNetWeb/js/Busqueda/scripts/AutoBusqueda.js"></script>
		<STYLE title="text/css" type="text/css">.SI-FILES-STYLIZED LABEL.cabinet { WIDTH: 95px; DISPLAY: block; BACKGROUND: url(/SimaNetWeb/imagenes/Navegador/BtnOpciones/AnexarArchivo.bmp) no-repeat 0px 0px; HEIGHT: 25px; OVERFLOW: hidden; CURSOR: hand }
	.SI-FILES-STYLIZED LABEL.cabinet INPUT.file { POSITION: relative; FILTER: progid:DXImageTransform.Microsoft.Alpha(opacity=0); WIDTH: auto; HEIGHT: 100%; opacity: 0; -moz-opacity: 0 }
	</STYLE>
		<script>
			function CrearCtrlAnexo(IdAnexo,NombreFile,Estilo){
				var arrNombre = NombreFile.toString().split('.');
				var Nombre = NombreFile.toString().Replace(arrNombre[arrNombre.length-1].toString(),"");
				var HTMLTable = jNet.get((new SIMA.Utilitario.Helper.General.Html()).CrearTabla(1,3));
				IdObj = "obj" + IdAnexo;
				HTMLTable.align="left";
				HTMLTable.style.cssText="MARGIN-BOTTOM: 5px; MARGIN-LEFT: 5px";
				HTMLTable.attr("id",IdObj);
				HTMLTable.attr("IDANEXO",IdAnexo);
				HTMLTable.attr("NOMBRE",NombreFile);
				HTMLTable.attr("IDACCION",jNet.get('hIdAccion').value);
				HTMLTable.attr("PERIODO",jNet.get('hPeriodo').value);
				//HTMLTable.className="BaseItemInGrid";
				HTMLTable.className=Estilo;				
				HTMLTable.border=0;
				HTMLTable.attr("width","100px");
				
				
				var Extension = arrNombre[arrNombre.length-1].toString().toUpperCase();
				HTMLTable.attr("EXTENSION",Extension.toLowerCase())
				
				
				var oIMG = SIMA.Utilitario.Helper.General.CrearImg('/' + ApplicationPath + '/imagenes/Navegador/' + Extension + '.gif');
				oIMG.onclick=function(){
					var oTBLItem = jNet.get(this.parentNode.parentNode.parentNode.parentNode);
					var Ext = HTMLTable.attr("EXTENSION");
					if((Ext=='jpg')||(Ext=='gif')||(Ext=='bmp')||(Ext=='png')){
						var URL='/' + ApplicationPath +'/GestionIntegrada/VistaPrevia.aspx?' + SIMA.Utilitario.Constantes.KEYQNOMBREIMGPREVIO +  SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + jNet.get('hIdAccion').value + '_' + oTBLItem.attr("NOMBRE");
						(new System.Ext.UI.WebControls.Windows()).Dialogo('VISTA PREVIA',URL,this,window.screen.width-100,window.screen.height-100);
					}
					else{
						(new SIMA.Utilitario.Helper.Window()).AbrirExcel(jNet.get('hRutaHTTP').value + jNet.get('hIdAccion').value + '_' + oTBLItem.attr("NOMBRE"));
					}
				}
				jNet.get(HTMLTable.rows[0].cells[0]).insert(oIMG);
				HTMLTable.rows[0].cells[1].innerText=Nombre;
				HTMLTable.rows[0].cells[1].noWrap=true;
				oIMG = SIMA.Utilitario.Helper.General.CrearImgEliminar(1);
				oIMG.onclick=function(){
					var oTBLItem = jNet.get(this.parentNode.parentNode.parentNode.parentNode);
					if(oTBLItem.attr("IDANEXO")!='0'){
						Ext.MessageBox.confirm('Confirmar', 'Desea ud. eliminar este registro ahora?', function(btn){
											if(btn=="yes"){
												(new Controladora.OCI.CAnexoAccionRecomendacion()).Eliminar(oTBLItem.attr("IDANEXO"),oTBLItem.attr("PERIODO"));
												jNet.get('cellListAnexos').removeChild(oTBLItem);
											}
										});					
					
					}
				}
				jNet.get(HTMLTable.rows[0].cells[2]).insert(oIMG);
				jNet.get('cellListAnexos').insert(HTMLTable);
			}
			
			
		
				function ObtenerAnexos(){
					var strLstAnexo="";
					var ocellListAnexos = jNet.get('cellListAnexos');
					for(var i=0;i<=ocellListAnexos.children.length-1;i++){
						var otblItemAnexo= jNet.get(ocellListAnexos.children[i]);
						strLstAnexo+=  otblItemAnexo.attr('IDANEXO') +';'+ otblItemAnexo.attr('NOMBRE') + '@';
					}
					jNet.get('hLstAnexos').value = strLstAnexo.substring(0,strLstAnexo.length-1);
				}
				
				function ListarCtrlAnexos(){
					var LstAnexo= jNet.get('hLstAnexos').value.toString().split('@');
					if((LstAnexo.length>0)&&(LstAnexo[0].length>0)){
						for(var i=0;i<=LstAnexo.length-1;i++){
							var arrCampos = LstAnexo[i].toString().split(';');	
							CrearCtrlAnexo(arrCampos[0],arrCampos[1],'BaseItemInGrid');
						}
					}
				}
		</script>
</HEAD>
	<body onunload="SubirHistorial();" onload="ObtenerHistorial();" bottomMargin="0" leftMargin="0"
		rightMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" border="0" cellSpacing="0" cellPadding="0" width="100%" align="center">
				<TR>
					<TD colSpan="3"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<tr>
					<TD vAlign="top"><uc1:menu id="Menu2" runat="server"></uc1:menu></TD>
				</tr>
				<TR>
					<TD>
						<TABLE id="Table4" border="0" cellSpacing="0" cellPadding="0" width="100%" align="center">
							<TR>
								<TD class="Commands" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión de Control Institucional ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Administración Acciones de Observación</asp:label></TD>
							</TR>
							<TR>
								<TD align="center"></TD>
								<TD align="center"><SPAN class="normal"></SPAN>
									<TABLE id="Table3" class="normal" border="0" cellSpacing="1" cellPadding="0" width="741"
										align="center" style="WIDTH: 741px; HEIGHT: 502px">
										<TR>
											<TD class="TituloPrincipalBlanco" bgColor="#000080" vAlign="top" colSpan="8" align="left"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco"></asp:label><asp:label id="lblDatos" runat="server"></asp:label></TD>
											<TD class="TituloPrincipalBlanco" vAlign="top" align="left"></TD>
										</TR>
										<TR>
											<TD class="TituloPrincipalBlanco" vAlign="top" colSpan="8" align="left"><TABLE id="Table6" border="0" cellSpacing="2" cellPadding="1" width="100%" align="left"
													style="Z-INDEX: 0">
													<TR>
														<TD bgColor="#dddddd" vAlign="top" align="left">
															<asp:label style="Z-INDEX: 0" id="Label4" runat="server" CssClass="TituloPrincipalBlanco" BackColor="Transparent"
																ForeColor="Navy">OBSERVACION:</asp:label></TD>
														<TD vAlign="middle" width="100%">
															<asp:label style="Z-INDEX: 0" id="LblObservacion" runat="server" CssClass="Normal" ForeColor="Black">OBSERVACION:</asp:label></TD>
													</TR>
													<TR>
														<TD vAlign="top" align="left"></TD>
														<TD vAlign="middle" width="100%"><IMG style="Z-INDEX: 0; WIDTH: 142px; HEIGHT: 2px" src="../imagenes/spacer.gif" width="142"
																height="8"></TD>
													</TR>
													<TR>
														<TD bgColor="#dddddd" vAlign="top" align="left">
															<asp:label style="Z-INDEX: 0" id="Label6" runat="server" CssClass="TituloPrincipalBlanco" BackColor="Transparent"
																ForeColor="Navy">RECOMENDACIÓN:</asp:label></TD>
														<TD vAlign="middle" width="100%">
															<asp:label style="Z-INDEX: 0" id="LblRecomendacion" runat="server" CssClass="Normal" ForeColor="Black">RECOMENDACION</asp:label></TD>
													</TR>
												</TABLE>
											</TD>
											<TD class="TituloPrincipalBlanco" vAlign="top" align="left"></TD>
										</TR>
										<TR>
											<TD class="normal" bgColor="#335eb4"><asp:label id="Label3" runat="server" CssClass="TextoBlanco">Documento:</asp:label></TD>
											<TD class="normal" bgColor="#f0f0f0" colSpan="7" width="100%"><asp:textbox id="txtDocumento" runat="server" CssClass="normaldetalle" MaxLength="500" Width="100%"></asp:textbox></TD>
											<TD class="normal"></TD>
										</TR>
										<TR>
											<TD class="normal" bgColor="#335eb4"><asp:label id="Label2" runat="server" CssClass="TextoBlanco">Fecha:</asp:label></TD>
											<TD class="normal" bgColor="#dddddd" colSpan="7" width="100%"><asp:textbox id="txtFecha" rel="calendar" runat="server" Width="88px" CssClass="normaldetalle"></asp:textbox>
												<INPUT style="Z-INDEX: 0; WIDTH: 65px; HEIGHT: 23px" id="hNombreArchivoUP" size="5" type="hidden"
													name="hNombreArchivoUP" runat="server"> <input type="hidden" name="__EVENTTARGET" style="Z-INDEX: 0; WIDTH: 72px; HEIGHT: 22px"
													size="6"> <input type="hidden" name="__EVENTARGUMENT" style="Z-INDEX: 0; WIDTH: 71px; HEIGHT: 22px"
													size="6"> <INPUT style="Z-INDEX: 0; WIDTH: 65px; HEIGHT: 23px" id="hRutaHTTP" size="5" type="hidden"
													name="hRutaHTTP" runat="server"> <INPUT id="hLstAnexos" size="4" type="hidden" name="hLstAnexos" runat="server">
												<INPUT style="Z-INDEX: 0" id="hIdAccion" size="4" type="hidden" name="hIdAccion" runat="server">
												<INPUT style="Z-INDEX: 0" id="hPeriodo" size="4" type="hidden" name="hPeriodo" runat="server">
											</TD>
											<TD class="normal"></TD>
										</TR>
										<TR>
											<TD class="normal" bgColor="#335eb4"><asp:label style="Z-INDEX: 0" id="Label9" runat="server" CssClass="headerDetalle" Width="120px"
													BorderStyle="None">Archivos Adjuntos:</asp:label>
											</TD>
											<TD class="normal" bgColor="#dddddd" colSpan="7"><TABLE style="Z-INDEX: 0" id="Table2" border="0" cellSpacing="0" cellPadding="0" width="100%"
													align="left">
													<TR>
														<TD style="BORDER-BOTTOM: gray 1px solid; BORDER-LEFT: gray 1px solid; PADDING-BOTTOM: 5px; PADDING-RIGHT: 5px; BACKGROUND-REPEAT: no-repeat; BACKGROUND-POSITION: right top; BORDER-TOP: gray 1px solid; BORDER-RIGHT: gray 1px solid"
															id="cellListAnexos" bgColor="#ffffff" width="100%" colSpan="7" runat="server"></TD>
														<TD><LABEL class="cabinet"><INPUT style="Z-INDEX: 0" id="FUFile" class="file" size="1" type="file" name="FUFile" runat="server"></LABEL></TD>
													</TR>
												</TABLE>
											</TD>
											<TD class="normal"></TD>
										</TR>
										<TR>
											<TD class="normal" bgColor="#335eb4">
												<asp:label style="Z-INDEX: 0" id="Label1" runat="server" CssClass="TextoBlanco">Descripción:</asp:label></TD>
											<TD class="normal" bgColor="#f0f0f0" colSpan="7"><IMG style="Z-INDEX: 0; WIDTH: 470px; HEIGHT: 9px" src="../imagenes/spacer.gif" width="470"
													height="9"></TD>
											<TD class="normal"></TD>
										</TR>
										<TR>
											<TD class="normal" bgColor="#f0f0f0" colSpan="8" vAlign=top align=left><asp:textbox id="txtDescripcion" runat="server" CssClass="normaldetalle" MaxLength="500" Width="100%"
													TextMode="MultiLine" Height="272px" style="Z-INDEX: 0"></asp:textbox></TD>
											<TD class="normal"></TD>
										</TR>
									</TABLE>
									<TABLE id="Table7" border="0" width="590" align="center">
										<TR>
											<TD align="center">&nbsp;
												<asp:imagebutton id="ibtnAceptar" runat="server" ImageUrl="../imagenes/bt_aceptar.gif"></asp:imagebutton>&nbsp;&nbsp;&nbsp;&nbsp;
												<IMG style="CURSOR: hand" id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../imagenes/bt_cancelar.gif">
											</TD>
										</TR>
										<TR>
											<TD style="DISPLAY: none" align="center">
												<asp:button style="Z-INDEX: 0" id="btnSubir" runat="server" Text="Button"></asp:button></TD>
										</TR>
									</TABLE>
									<SPAN class="normal"></SPAN>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT language="javascript" type="text/javascript"> 
		<!--
			function __doPostBack(eventTarget, eventArgument) {
				var theform;
				if (window.navigator.appName.toLowerCase().indexOf("microsoft") > -1) {
					theform = document.Form1;
				}
				else {
					theform = document.forms["Form1"];
				}
				theform.__EVENTTARGET.value = eventTarget.split("$").join(":");
				theform.__EVENTARGUMENT.value = eventArgument;
				theform.submit();
			}
		// -->
		</SCRIPT>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			
			var textBoxes = Ext.DomQuery.select("input[rel=calendar]");   
						Ext.each(textBoxes, function(item, id, all){   
							var cl = new Ext.form.DateField({   
								format: 'd/m/Y',
								allowBlank : false,   
								applyTo: item   
							});
						});   

			
		</SCRIPT>
		<SCRIPT language="javascript" type="text/javascript">
			// <![CDATA[
					SI.Files.stylizeAll();
			// ]]>
			
				var oFUFile = jNet.get('FUFile');
					oFUFile.addEvent("change",function(){
							var PathNombre=jNet.get('FUFile').value;
							var arrPath =PathNombre.split(String.fromCharCode(92));
							var NombreFile = arrPath[arrPath.length-1];
							jNet.get('hNombreArchivoUP').value = NombreFile;
							CrearCtrlAnexo('0',NombreFile,'BaseItemInGridRed');
							ObtenerAnexos();
							__doPostBack('btnSubir','');
					});
					
					ListarCtrlAnexos();
		</SCRIPT>
	</body>
</HTML>
