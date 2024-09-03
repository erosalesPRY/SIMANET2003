<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="DetalleSolicituddeAcciondeMejora.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionIntegrada.DetalleSolicituddeAcciondeMejora" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DetalleSolicituddeAcciondeMejora</title>
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
		
			function MostrarVentana(e){
				var Pos=getPosition(e);
				var otblBuscar = jNet.get('tblBuscar');
				otblBuscar.style.display= ((otblBuscar.style.display=='none')?'block':'none');
				otblBuscar.style.position = "absolute";
				otblBuscar.style.top = (Pos.y+10) +'px';
				otblBuscar.style.left=(Pos.x+10)+'px';
			
			}
			
			function ObtenerClausulas(e){
				jNet.get('hLstClausulas').value = "";
				var strLstISO="";
				var oDataGrid = jNet.get('grid');
				for(var i=1;i<=oDataGrid.rows.length-1;i++){
					var oRow = jNet.get(oDataGrid.rows[i]);
					var IdValueOP = oRow.cells[1].getAttribute("IDCLAUSULA");
					if(IdValueOP!=0){
						strLstISO +=  oRow.attr('IDSAMISO') + '*' +  oRow.attr('IDISO')+ '*' + IdValueOP +'*'+ oRow.attr('NORMAISO')+'*'+ oRow.attr('DESCRIPCION') +'*'+ oRow.attr('IDESTADO')+'@';
						var objtxtArticulo = document.getElementById("txtArticulo");
						var oFilaContext=objtxtArticulo.parentNode.parentNode;
						oFilaContext.style.display="none";
					}
					if(oRow.attr('IDISO')=="4"){try{oFilaContext.style.display= ((IdValueOP=="0")?"none":"block");}catch(error){}}
				}
				jNet.get('hLstClausulas').value = strLstISO.substring(0,strLstISO.length-1);
			}
			
			function ObtenerDestinos(){
				var strLstDestino="";
				var oCellDestino = jNet.get('cellListDestino');
				for(var i=0;i<=oCellDestino.children.length-1;i++){
					var otblItemDestino= jNet.get(oCellDestino.children[i]);
					strLstDestino +=  otblItemDestino.attr('IDDESTINO') +';'+ otblItemDestino.id.toString().Replace('obj','')+  ';' +  otblItemDestino.rows[0].cells[0].innerText + '@';
				}
				jNet.get('hLstDetinatario').value = strLstDestino.substring(0,strLstDestino.length-1);
				/*window.alert(jNet.get('hLstDetinatario').value);*/
			}
			function ObtenerAnexos(){
				var strLstAnexo="";
				var ocellListAnexos = jNet.get('cellListAnexos');
				for(var i=0;i<=ocellListAnexos.children.length-1;i++){
					var otblItemAnexo= jNet.get(ocellListAnexos.children[i]);
					strLstAnexo+=  otblItemAnexo.attr('IDANEXO') +';'+ otblItemAnexo.attr('NOMBRE') + '@';
				}
				jNet.get('hLstAnexo').value = strLstAnexo.substring(0,strLstAnexo.length-1);
				/*window.alert(jNet.get('hLstAnexo').value);*/
			}
			
			function ListarCtrlDestinos(){
				var LstDestinos = jNet.get('hLstDetinatario').value.toString().split('@');
				if((LstDestinos.length>0)&&(LstDestinos[0].length>0)){
					for(var i=0;i<=LstDestinos.length-1;i++){
						var arrCampos = LstDestinos[i].toString().split(';');	
						CrearCtrlDestino(arrCampos[0],arrCampos[1],arrCampos[2]);
					}
				}
			}
			
			function CrearCtrlDestino(IdDestino,IdArea,NombreArea){
				var HTMLTable = jNet.get((new SIMA.Utilitario.Helper.General.Html()).CrearTabla(1,3));
				IdObj = "obj" + IdArea;
				HTMLTable.align="left";
				HTMLTable.style.cssText="MARGIN-BOTTOM: 5px; MARGIN-LEFT: 5px";
				HTMLTable.attr("id",IdObj);
				HTMLTable.attr("IDDESTINO",IdDestino);
				HTMLTable.attr("IDAREA",IdArea);
				HTMLTable.className="BaseItemInGrid";
				HTMLTable.border=0;
				HTMLTable.rows[0].cells[0].innerText=NombreArea;
				HTMLTable.rows[0].cells[0].noWrap=true;
				
				
				
				var oIMGlr =  SIMA.Utilitario.Helper.General.CrearImg('/' + ApplicationPath + '/imagenes/Navegador/SAMResponsable.png' );
				oIMGlr.onclick=function(){
					var oTBLItem = jNet.get(this.parentNode.parentNode.parentNode.parentNode);
					var KEYQIDAREA = "IdArea";
					var URLRESPONSABLE = '/' + ApplicationPath + "/GestionIntegrada/ListarResponsablePorArea.aspx?";
					var URL = URLRESPONSABLE + KEYQIDAREA  + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + HTMLTable.attr("IDAREA");
					(new System.Ext.UI.WebControls.Windows()).Dialogo('Listado de responsable por area',URL,this,800,400,CerrarDialogo);
				}
				
				jNet.get(HTMLTable.rows[0].cells[1]).insert(oIMGlr);
				
				var oIMG = SIMA.Utilitario.Helper.General.CrearImgEliminar(1);
				oIMG.onclick=function(){
					var oTBLItem = jNet.get(this.parentNode.parentNode.parentNode.parentNode);
					if(oPagina.Request.Params[SIMA.Utilitario.Constantes.KEYMODOPAGINA]!=SIMA.Utilitario.Enumerados.ModoPagina.C){
						Ext.MessageBox.confirm('Confirmar', 'Desea ud. eliminar este registro ahora?', function(btn){
										if(btn=="yes"){
											(new Controladora.OGI.CSAMDestino()).Eliminar(HTMLTable.attr("IDDESTINO"));
											jNet.get('cellListDestino').removeChild(oTBLItem);
										}
									});
					}
				}
				jNet.get(HTMLTable.rows[0].cells[2]).insert(oIMG);
				jNet.get('cellListDestino').insert(HTMLTable);
			}
			
			function CerrarDialogo(HandleWind){
				HandleWind.close();
			}

			
			
			function ListarCtrlAnexos(){
				var LstAnexo= jNet.get('hLstAnexo').value.toString().split('@');
				if((LstAnexo.length>0)&&(LstAnexo[0].length>0)){
					for(var i=0;i<=LstAnexo.length-1;i++){
						var arrCampos = LstAnexo[i].toString().split(';');	
						CrearCtrlAnexo(arrCampos[0],arrCampos[1],'BaseItemInGrid');
					}
				}
			}
			
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
				HTMLTable.attr("IDSAM",jNet.get('hIdSAM').value);
				//HTMLTable.className="BaseItemInGrid";
				HTMLTable.className=Estilo;				
				HTMLTable.border=0;
				HTMLTable.attr("width","100px");
				
				
				var Extension = arrNombre[arrNombre.length-1].toString().toUpperCase();
				HTMLTable.attr("EXTENSION",Extension.toLowerCase())
				
				var oIMG = SIMA.Utilitario.Helper.General.CrearImg('/' + ApplicationPath + '/imagenes/Navegador/' + ObtenerExtension(Extension) + '.png');
				oIMG.onclick=function(){
					var oTBLItem = jNet.get(this.parentNode.parentNode.parentNode.parentNode);
					var Ext = HTMLTable.attr("EXTENSION");
					if((Ext=='jpg')||(Ext=='gif')||(Ext=='bmp')||(Ext=='png')){
						var URL='/' + ApplicationPath +'/GestionIntegrada/VistaPrevia.aspx?' + SIMA.Utilitario.Constantes.KEYQNOMBREIMGPREVIO +  SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + jNet.get('hIdSAM').value + '_' + oTBLItem.attr("NOMBRE");
						(new System.Ext.UI.WebControls.Windows()).Dialogo('VISTA PREVIA',URL,this,window.screen.width-100,window.screen.height-100);
					}
					else{
						(new SIMA.Utilitario.Helper.Window()).AbrirExcel(jNet.get('hRutaHTTP').value + jNet.get('hIdSAM').value + '_' + oTBLItem.attr("NOMBRE"));
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
												(new Controladora.OGI.CSAMAnexo()).Eliminar(oTBLItem.attr("IDANEXO"),oTBLItem.attr("IDSAM"),oTBLItem.attr("NOMBRE"));
												jNet.get('cellListAnexos').removeChild(oTBLItem);
											}
										});					
					
					}
				}
				jNet.get(HTMLTable.rows[0].cells[2]).insert(oIMG);
				jNet.get('cellListAnexos').insert(HTMLTable);
			}
					 
			
		</script>
		<script>
			function EliminarClausula(e){
				Ext.MessageBox.confirm('Confirmar', 'Desea ud. eliminar clausula de Norma seleccionada ahora?', function(btn){
											if(btn=="yes"){
												e.setAttribute("IDESTADO","0");
												e.cells[1].innerText='';
												//Actualiza la trama de actualizacion
												ObtenerClausulas(e);
											}
										});				
			
			}			
		</script>
	</HEAD>
	<body onunload="SubirHistorial();" onload="ObtenerHistorial();" bottomMargin="0" leftMargin="0"
		rightMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" border="0" cellSpacing="0" cellPadding="0" width="100%">
				<TR>
					<TD><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD vAlign="top">
						<TABLE style="HEIGHT: 374px" id="Table2" border="0" cellSpacing="0" cellPadding="0" width="100%"
							align="center">
							<TR>
								<TD bgColor="#000080" height="30" align="center"></TD>
								<TD bgColor="#000080" height="30" colSpan="9" align="center"><asp:label style="Z-INDEX: 0" id="Label1" runat="server" CssClass="TituloPrincipalBlanco">SOLICITUD DE ACCION DE MEJORA</asp:label></TD>
							</TR>
							<TR class="ItemDetalle">
								<TD style="WIDTH: 128px" class="headerDetalle"></TD>
								<TD style="WIDTH: 128px" class="headerDetalle"><asp:label style="Z-INDEX: 0" id="Label5" runat="server" CssClass="headerDetalle" BorderStyle="None">Nro Registro:</asp:label></TD>
								<TD vAlign="top" colSpan="2" align="left"><asp:textbox style="Z-INDEX: 0" id="txtNroRegistro" runat="server" CssClass="normaldetalle" BackColor="Transparent"
										ReadOnly="True" Width="90px"></asp:textbox></TD>
								<TD colSpan="5"><cc1:datagridweb style="Z-INDEX: 0" id="grid" runat="server" Width="100%" AllowSorting="True" AutoGenerateColumns="False"
										RowHighlightColor="#E0E0E0" Height="94px">
										<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
										<ItemStyle Height="25px" CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn DataField="NormaISO" SortExpression="NormaISO" HeaderText="NORMA">
												<HeaderStyle HorizontalAlign="Center" Width="35%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="NombreClausula" HeaderText="CLAUSULA">
												<HeaderStyle Width="60%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn>
												<HeaderStyle Width="2%"></HeaderStyle>
												<ItemTemplate>
													<asp:Image id="imgBtn" runat="server" ImageUrl="../imagenes/BtPU_Mas.gif"></asp:Image>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn>
												<HeaderTemplate>
													<asp:Image style="Z-INDEX: 0" id="imgDelHeader" runat="server" ImageUrl="../imagenes/Filtro/Eliminar.gif"></asp:Image>
												</HeaderTemplate>
												<ItemTemplate>
													<asp:Image style="Z-INDEX: 0" id="imgBtnEliminar" runat="server" ImageUrl="../imagenes/Filtro/Eliminar.gif"></asp:Image>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 128px" class="headerDetalle"></TD>
								<TD style="WIDTH: 128px" class="headerDetalle"></TD>
								<TD colSpan="2"></TD>
								<TD style="WIDTH: 42px" class="headerDetalle"><asp:label style="Z-INDEX: 0" id="Label11" runat="server" BorderStyle="None" Width="60px" Height="5px"
										ForeColor="White">Artículo:</asp:label></TD>
								<TD width="100%" colSpan="4"><asp:textbox id="txtArticulo" runat="server" CssClass="normaldetalle2" Width="100%"></asp:textbox></TD>
							</TR>
							<TR class="AlternateItemDetalle">
								<TD style="WIDTH: 128px" class="headerDetalle"></TD>
								<TD style="WIDTH: 128px" class="headerDetalle"><asp:label style="Z-INDEX: 0" id="Label2" runat="server" BorderStyle="None" Width="128px" Height="10px"
										ForeColor="White">Fuente del Reporte</asp:label></TD>
								<TD colSpan="2"><asp:dropdownlist style="Z-INDEX: 0" id="ddlTipoAuditoria" runat="server" CssClass="normaldetalle"
										Width="100%"></asp:dropdownlist></TD>
								<TD style="WIDTH: 42px" class="headerDetalle"><asp:label style="Z-INDEX: 0" id="Label10" runat="server" BorderStyle="None" Width="60px" Height="5px"
										ForeColor="White">Auditoria</asp:label></TD>
								<TD style="WIDTH: 123px" colSpan="2"><asp:dropdownlist style="Z-INDEX: 0" id="ddlAuditoria" runat="server" CssClass="normaldetalle" Width="120px"></asp:dropdownlist><IMG style="Z-INDEX: 0; HEIGHT: 5px" alt="" src="/SIMANETWEB/imagenes/spacer.gif" width="80"
										height="5"></TD>
								<TD><INPUT style="Z-INDEX: 0; WIDTH: 24px; HEIGHT: 23px" id="hLstDetinatario" size="1" type="hidden"
										name="Hidden1" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 24px; HEIGHT: 24px" id="hLstClausulas" size="1" type="hidden"
										runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 31px; HEIGHT: 23px" id="hLstAnexo" size="1" type="hidden"
										name="Hidden1" runat="server"></TD>
								<TD vAlign="bottom" width="100%" align="right"><IMG style="Z-INDEX: 0; HEIGHT: 5px" alt="" src="/SIMANETWEB/imagenes/spacer.gif" width="180"
										height="5"></TD>
							</TR>
							<TR class="ItemDetalle">
								<TD style="WIDTH: 128px" class="headerDetalle"></TD>
								<TD style="WIDTH: 128px" class="headerDetalle"><asp:label style="Z-INDEX: 0" id="Label8" runat="server" CssClass="headerDetalle" BorderStyle="None"
										Width="96px" Height="24px">Detectado en:</asp:label></TD>
								<TD colSpan="5"><asp:dropdownlist style="Z-INDEX: 0" id="ddlDetectadoEn" runat="server" CssClass="normaldetalle" Width="100%"></asp:dropdownlist></TD>
								<TD class="headerDetalle"><asp:label style="Z-INDEX: 0" id="Label9" runat="server" CssClass="headerDetalle" BorderStyle="None"
										Width="120px">Doc. Referencia:</asp:label></TD>
								<TD id="cell" vAlign="bottom" width="100%" align="right">
									<TABLE style="Z-INDEX: 0" id="Table4" border="0" cellSpacing="0" cellPadding="0" width="100%"
										align="left">
										<TR>
											<TD style="BORDER-BOTTOM: gray 1px solid; BORDER-LEFT: gray 1px solid; PADDING-BOTTOM: 5px; PADDING-RIGHT: 5px; BACKGROUND-REPEAT: no-repeat; BACKGROUND-POSITION: right top; BORDER-TOP: gray 1px solid; BORDER-RIGHT: gray 1px solid"
												id="cellListAnexos" bgColor="#ffffff" width="100%" colSpan="6" runat="server"></TD>
											<TD><LABEL class="cabinet"><INPUT style="Z-INDEX: 0" id="FUFile" class="file" size="1" type="file" name="FUFile" runat="server"></LABEL></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR class="AlternateItemDetalle">
								<TD style="WIDTH: 128px" class="headerDetalle"></TD>
								<TD style="WIDTH: 128px" class="headerDetalle"><asp:label style="Z-INDEX: 0" id="Label3" runat="server" CssClass="headerDetalle" BorderStyle="None"
										Width="120px">Descripción del hallazgo</asp:label></TD>
								<TD style="HEIGHT: 68px" colSpan="7"><asp:textbox style="Z-INDEX: 0" id="txtDescripcion" runat="server" CssClass="normaldetalle2"
										Width="100%" Height="100px" TextMode="MultiLine"></asp:textbox></TD>
							</TR>
							<TR class="ItemDetalle">
								<TD style="WIDTH: 128px; HEIGHT: 10px" class="headerDetalle"></TD>
								<TD style="WIDTH: 128px; HEIGHT: 10px" class="headerDetalle"><asp:label style="Z-INDEX: 0" id="Label6" runat="server" CssClass="headerDetalle" BorderStyle="None"
										Width="105px">Fecha de Emisión</asp:label></TD>
								<TD style="WIDTH: 92px; HEIGHT: 10px" colSpan="2"><asp:textbox style="Z-INDEX: 0" id="calFechaEmite" runat="server" CssClass="normaldetalle" Width="60px"
										rel="calendar"></asp:textbox></TD>
								<TD style="WIDTH: 62px; HEIGHT: 10px" class="headerDetalle"><asp:label style="Z-INDEX: 0" id="Label7" runat="server" CssClass="headerDetalle" BorderStyle="None"
										Width="100px">Tipo de Acción:</asp:label></TD>
								<TD style="WIDTH: 123px; HEIGHT: 10px" colSpan="2"><asp:dropdownlist style="Z-INDEX: 0" id="ddlTipoAccion" runat="server" CssClass="normaldetalle" Width="100%"></asp:dropdownlist></TD>
								<TD style="HEIGHT: 10px"></TD>
								<TD style="HEIGHT: 10px"></TD>
							</TR>
							<TR class="ItemDetalle">
								<TD style="WIDTH: 128px; HEIGHT: 28px" class="headerDetalle" rowSpan="2"><IMG style="Z-INDEX: 0" alt="" src="/SIMANETWEB/imagenes/spacer.gif" width="2" height="40"></TD>
								<TD style="WIDTH: 128px; HEIGHT: 28px" class="headerDetalle" rowSpan="2"><asp:label style="Z-INDEX: 0" id="Label4" runat="server" CssClass="headerDetalle" BorderStyle="None">Destinatario:</asp:label></TD>
								<TD colSpan="7"><asp:textbox style="Z-INDEX: 0" id="txtBuscar" runat="server" Width="100%"></asp:textbox></TD>
							</TR>
							<TR class="AlternateItemDetalle">
								<TD style="BORDER-BOTTOM: gray 1px solid; BORDER-LEFT: gray 1px solid; PADDING-BOTTOM: 5px; PADDING-RIGHT: 5px; BORDER-TOP: gray 1px solid; BORDER-RIGHT: gray 1px solid"
									id="cellListDestino" bgColor="#ffffff" height="30" vAlign="top" width="100%" colSpan="7"
									runat="server"></TD>
							</TR>
							<TR class="ItemDetalle">
								<TD style="WIDTH: 128px; HEIGHT: 21px" class="headerDetalle"></TD>
								<TD style="WIDTH: 128px; HEIGHT: 21px" class="headerDetalle"></TD>
								<TD style="HEIGHT: 21px" colSpan="7"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 128px"></TD>
								<TD style="WIDTH: 128px"><INPUT style="Z-INDEX: 0; WIDTH: 65px; HEIGHT: 23px" id="hRutaHTTP" size="5" type="hidden"
										name="Hidden1" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 65px; HEIGHT: 23px" id="hRutaFotos" size="5" type="hidden"
										name="Hidden1" runat="server"></TD>
								<TD style="WIDTH: 92px"><INPUT style="Z-INDEX: 0; WIDTH: 65px; HEIGHT: 23px" id="hIdSAM" size="5" type="hidden"
										name="Hidden1" runat="server"></TD>
								<TD style="WIDTH: 92px"><INPUT style="Z-INDEX: 0; WIDTH: 65px; HEIGHT: 23px" id="hNombreArchivoUP" size="5" type="hidden"
										name="Hidden1" runat="server"></TD>
								<TD style="WIDTH: 92px"><INPUT style="Z-INDEX: 0; WIDTH: 65px; HEIGHT: 23px" id="hIdAuditoria" value="0" size="5"
										type="hidden" name="Hidden1" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 65px; HEIGHT: 23px" id="HEst_Prc" value="0" size="5" type="hidden"
										name="Hidden1" runat="server"></TD>
								<TD style="WIDTH: 123px"><asp:button id="btnSubir" runat="server" Text="Button"></asp:button></TD>
								<TD colSpan="3">
									<TABLE style="Z-INDEX: 0; WIDTH: 182px; HEIGHT: 30px" id="tblBtns" border="0" cellSpacing="1"
										cellPadding="1" width="182" align="right" runat="server">
										<TR>
											<TD width="50%"><asp:imagebutton id="ibtnAceptar" runat="server" ImageUrl="../imagenes/bt_aceptar.gif"></asp:imagebutton></TD>
											<TD width="50%"><IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../imagenes/bt_cancelar.gif"></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD></TD>
				</TR>
			</TABLE>
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
					
			var textBoxes = Ext.DomQuery.select("input[rel=calendar]");   
			Ext.each(textBoxes, function(item, id, all){   
				var cl = new Ext.form.DateField({   
					format: 'd/m/Y',
					allowBlank : false,
					applyTo: item   
				});
			});   
			
			(new System.Ext.UI.WebControls.TooTips()).TipTitle('ddlTipoAuditoria','TIPO DE AUDITORIA','Seleccione aquí el tipo de auditoria que desea aplicar',250);
			
			function ObtenerIDAuditoria(){
				var oddlAuditoria = new System.Web.UI.WebControls.DropDownList('ddlAuditoria');
				var ListItem = oddlAuditoria.ListItem();
				jNet.get('hIdAuditoria').value = ListItem.value;
			}
			
		//Cargar EL combo de Auditoria
			function LlenarAuditoria(){
				//aler();
				var oddlTipoAuditoria = new System.Web.UI.WebControls.DropDownList('ddlTipoAuditoria');
				var ListItem = oddlTipoAuditoria.ListItem();
				if((ListItem.value!='2')&&(ListItem.value!='3')){
					jNet.get('hIdAuditoria').value='0';			
					jNet.get('ddlAuditoria').style.display="none";
					jNet.get('Label10').style.display="none";
				}
				else{
					jNet.get('ddlAuditoria').style.display="block";
					jNet.get('Label10').style.display="block";
				}
				
				var IdAuditoria=jNet.get('hIdAuditoria').value;
				
				var oddlAuditoria = new System.Web.UI.WebControls.DropDownList('ddlAuditoria');
				oddlAuditoria.DataSource=(new Controladora.OGI.CSAMAuditoria()).ListarTodosGrilla(((ListItem.value=='0')?'99':ListItem.value));
				oddlAuditoria.DataTextField = 'NombreAuditoria';
				oddlAuditoria.DataValueField = 'IdAuditoria';
				oddlAuditoria.DataBind();
				
				ListItem = oddlAuditoria.ListItem();
				ListItem = oddlAuditoria.FindByValue(IdAuditoria);
				
			}
			try{
				LlenarAuditoria();
			}
			catch(error){}

			</SCRIPT>
			<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>	
			</SCRIPT>
			<script>
			var oWindModal;
			/*Normas ISO y sus Versiones*/
			function grid_ondblClick(e,rowIDExt){
				var oGridExt = document.getElementById('grid');
				oGridExt.rows[rowIDExt].cells[1].innerText=e.getAttribute("NOMBRENORMAISO");
				oGridExt.rows[rowIDExt].cells[1].setAttribute("IDCLAUSULA",e.getAttribute("IDNORMAISO"));
				oGridExt.rows[rowIDExt].cells[1].setAttribute("IDESTADO","1");
				ObtenerClausulas(null);
				oWindModal.close();
			}
				
			function ListarClausula(rowId,IdNormaISO,NombreISO){
				//Codigo de Tabla general para configurar las versiones 623
				var TabDetalle=new Array();
				var idx=0;
				var oDataTable = (new Controladora.OGI.CSAMiso()).ListarVersiones(IdNormaISO);
					for (f=0;f<=oDataTable.Rows.Items.length-1;f++){
						var oDataRow =oDataTable.Rows.Items[f];
						if(oDataRow.Item("EOF")==false){
							var URLLOCAL = SIMA.Utilitario.Helper.General.ObtenerPathApp() + "/GestionIntegrada/ConsultarClausulaPorNormaISO.aspx?IdNorISO="+ oDataRow.Item("IdNormaISO")+"&IdVer="+oDataRow.Item("IdVersionNormaISO")+"&"+"rowID=" +rowId;
							TabDetalle[idx]={title : oDataRow.Item("NombreVersion"),autoLoad: {url: URLLOCAL, scripts : true},selected:oDataRow.Item("VerDefault")};
							idx++;
						}
					}
				oWindModal = (new System.Ext.UI.WebControls.Windows()).DialogoTabs(NombreISO,TabDetalle,this,400,window.screen.height-150);				
			}
				
			</script>
			<SCRIPT>
				var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
				var IdObj="";
				function txtBuscar_ItemDataBound(sender,e,dr){
					CrearCtrlDestino('0',dr["IdArea"].toString(),dr["NombreArea"].toString());
					jNet.get('txtBuscar').value='';
					ObtenerDestinos();
				}
				
				
				if(oPagina.Request.Params[SIMA.Utilitario.Constantes.KEYMODOPAGINA]!=SIMA.Utilitario.Enumerados.ModoPagina.C){
					var	oParamCollecionBusqueda = new ParamCollecionBusqueda();
					var oParamBusqueda = new ParamBusqueda();
						oParamBusqueda.Nombre="NombreArea";
						oParamBusqueda.Texto="Nombre Area";
						oParamBusqueda.LongitudEjecucion=2;
						oParamBusqueda.Tipo="C";
						oParamBusqueda.CampoAlterno='NombreCentro';
					oParamCollecionBusqueda.Agregar(oParamBusqueda);

						oParamBusqueda = new ParamBusqueda();
						oParamBusqueda.Nombre="idProceso";
						oParamBusqueda.Valor=SIMA.Utilitario.Constantes.General.ProcesoCallBack.BuscarAreaenGeneralPorNombreOGI;
						oParamBusqueda.Tipo="Q";
					oParamCollecionBusqueda.Agregar(oParamBusqueda);
					(new AutoBusqueda('txtBuscar')).Crear('/' + ApplicationPath + '/GestionIntegrada/Procesar.aspx?',oParamCollecionBusqueda);
				}
				
				//Crear los controles 
				ListarCtrlDestinos();
				ListarCtrlAnexos();
				ObtenerClausulas(null);
						
			</SCRIPT>
		</form>
	</body>
</HTML>
