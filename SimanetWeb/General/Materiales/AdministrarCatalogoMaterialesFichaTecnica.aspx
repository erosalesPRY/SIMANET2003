<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="AdministrarCatalogoMaterialesFichaTecnica.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.General.Materiales.AdministrarCatalogoMaterialesFichaTecnica" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>AdministrarCatalogoMaterialesFichaTecnica</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../../styles.css">
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>
		<script type="text/javascript" src="/SimaNetWeb/js/Busqueda/scripts/AutoBusqueda.js"></script>
		<script type="text/javascript" src="../../js/Menu/MenuSP.js"></script>
		<script type="text/javascript" src="/SimaNetWeb/js/Upload/mint"></script>
		<script type="text/javascript" src="/SimaNetWeb/js/Upload/si.files.js"></script>
		<script type="text/javascript" src="/SimaNetWeb/js/RegEXT.js"></script>
		<!--
		<STYLE type="text/css">.upload-icon { BACKGROUND: url(../shared/icons/fam/image_add.png) no-repeat 0px 0px }
				#fi-button-msg { BORDER-BOTTOM: #ccc 2px solid; BORDER-LEFT: #ccc 2px solid; PADDING-BOTTOM: 5px; MARGIN: 5px; PADDING-LEFT: 10px; PADDING-RIGHT: 10px; BACKGROUND: #eee; FLOAT: left; FONT-SIZE: 8pt; BORDER-TOP: #ccc 2px solid; BORDER-RIGHT: #ccc 2px solid; PADDING-TOP: 5px }
		</STYLE>
		-->
		<STYLE title="text/css" type="text/css">.SI-FILES-STYLIZED LABEL.cabinet { WIDTH: 79px; DISPLAY: block; BACKGROUND: url(/SimaNetWeb/imagenes/Navegador/BtnOpciones/UpLoad.gif) no-repeat 0px 0px; HEIGHT: 28px; OVERFLOW: hidden; CURSOR: pointer }
	.SI-FILES-STYLIZED LABEL.cabinet INPUT.file { POSITION: relative; FILTER: progid:DXImageTransform.Microsoft.Alpha(opacity=0); WIDTH: auto; HEIGHT: 100%; opacity: 0; -moz-opacity: 0 }
	</STYLE>
		<script>
				//oImgBase.src = '/' + ApplicationPath + '/imagenes/Filtro/Eliminar.png';
				function txtBuscar_ItemDataBound(sender,e,dr){
					
					//Muestra los datos generales del material
					jNet.get("txtCodigo").value=dr["COD_MAT"].toString();
					jNet.get("txtDescripcion").value=dr["DES_DET"].toString();
					
					jNet.get("txtNombreGenerico").value=dr["NOMBREGENERICO"].toString();
					
					//window.alert(dr["NOMBREGENERICO"].toString());
					
					jNet.get("txtNombreEspecifico").value=dr["NOMBREESPECIFICO"].toString();
					jNet.get("txtNombreIngles").value=dr["NOMBREINGLES"].toString();

					jNet.get("txtReferencia").value=dr["DES_DET"].toString();
					jNet.get("txtUso").value=dr["USO"].toString();
					
					MostrarListaImagenes(0);
					CargarListaTecnica(dr["COD_MAT"].toString());
				}
				
				
				function MostrarListaImagenes(IdPag){
					var oImgBase = jNet.get('imgBase');
					oImgBase.src="/SIMANETWEB/imagenes/spacer.gif";
					//Elimina todos los controles 
					var otdContenPag = jNet.get('tdContenPag');
					while (otdContenPag.childNodes[0]){otdContenPag.removeChild(otdContenPag.childNodes[0]);}
					var oDataTable = new System.Data.DataTable("tblGrupoCC");
					oDataTable = (new Controladora.General.CMaterialesFichaTecnica()).ListarImagenesPorMaterial(jNet.get("txtCodigo").value);
					for(var i=0;i<=oDataTable.Rows.Items.length-1;i++){
						var objPag;
						var oDataRow =oDataTable.Rows.Items[i];
						if(oDataRow.Item("EOF")==false){
							var oMaterialesFichaTecnicaBE = new EntidadesNegocio.General.MaterialesFichaTecnicaBE();
							oMaterialesFichaTecnicaBE.CodigoMat=oDataRow.Item("COD_MAT");
							oMaterialesFichaTecnicaBE.IdImg=oDataRow.Item("ID_IMG");
							oMaterialesFichaTecnicaBE.NomgreImg=oDataRow.Item("NOMBRE_IMG");
							oMaterialesFichaTecnicaBE.Referencia=oDataRow.Item("REFERENCIA");
													
							if(i==IdPag){
								jNet.get('TextBox1').value = oDataRow.Item("NOMBRE_IMG");
								
								oImgBase.src = SIMA.SYSTEM.Enumerados.Configuracion.PathWebComplementos + oDataRow.Item("NOMBRE_IMG");
								objPag = document.createElement("SPAN");
								jNet.get('txtReferencia').value = oMaterialesFichaTecnicaBE.Referencia;
								oImgBase.attr("oBaseBE",oMaterialesFichaTecnicaBE);
							}
							else{
								objPag = document.createElement("A");
							}
							objPag.id= oDataRow.Item("ID_IMG");
							objPag = jNet.get(objPag);
							objPag.css("cursor","hand");
							objPag.innerText=i+1;
							objPag.attr("IdPag",i);
							objPag.attr("oBaseBE",oMaterialesFichaTecnicaBE);
							objPag.addEvent("click",function(){
								var oMaterialesFichaTecnicaBE = new EntidadesNegocio.General.MaterialesFichaTecnicaBE();
								oMaterialesFichaTecnicaBE = this.attr("oBaseBE");
								jNet.get('txtReferencia').value = oMaterialesFichaTecnicaBE.Referencia;
								MostrarListaImagenes(parseInt(this.innerText,10)-1);
							});
							otdContenPag.insert(objPag);
						}
					}
				}
				
				
				function CargarListaTecnica(CodigoMaterial){
					var oDataGrid = new DataGrid(jNet.get('grid'));
					oDataGrid.DataSource = (new Controladora.General.CMaterialesFichaTecnica()).ListarDetalleFicha(CodigoMaterial);
					oDataGrid.EventHandleItemDataBound=Grid_ItemDataBound;
					oDataGrid.DataBind();
										
				}
				
				function Grid_ItemDataBound(sender,e){
					var objHtml = new SIMA.Utilitario.Helper.General.Html();
					dr = e.Item.DataItem;
					var strImg= "/SIMANETWEB/imagenes/spacer.gif";
					SIMA.Utilitario.Helper.SeleccionarItemGrillaOnClickMoverRaton(e,function(){});
					if((parseInt(dr.Item("COD_SBC"),10)==0)&& (parseInt(dr.Item("COD_ORD"),10)==0)){
						e.Item.cells(0).innerText=dr.Item("DES_EQU");
					}
					else if((parseInt(dr.Item("COD_SBC"),10)!=0)&& (parseInt(dr.Item("COD_ORD"),10)==0)){
						var htmlTable = objHtml.CrearTabla(1,2);
						htmlTable.border=0;
						var htmImg = objHtml.CrearImagen(strImg);
						htmImg.style.cssText = "WIDTH: 16px; HEIGHT: 10px";
						htmlTable.rows[0].cells[0].appendChild(htmImg);
						htmlTable.rows[0].cells[1].innerText = dr.Item("DES_EQU");
						htmlTable.rows[0].className=e.Item.className;
						e.Item.cells[0].appendChild(htmlTable);
					}
					else{
						var htmlTable = objHtml.CrearTabla(1,3);
						htmlTable.border=0;
						var htmImg = objHtml.CrearImagen(strImg);
						htmImg.style.cssText = "WIDTH: 16px; HEIGHT: 10px";
						htmlTable.rows[0].cells[0].appendChild(htmImg);
						htmImg = objHtml.CrearImagen(strImg);
						htmImg.style.cssText = "WIDTH: 16px; HEIGHT: 10px";
						htmlTable.rows[0].cells[1].appendChild(htmImg);
						htmlTable.rows[0].cells[2].innerText = dr.Item("DES_EQU");
						htmlTable.rows[0].className=e.Item.className;
						e.Item.cells[0].appendChild(htmlTable);
					}
					e.Item.cells(0).align = "left";
				}



Ext.onReady(function(){

    Ext.QuickTips.init();
  /*  var fbutton = new Ext.ux.form.FileUploadField({
        renderTo: 'fi-button',
        buttonOnly: true,
        listeners: {
            'fileselected': function(fb, v){
            var oImg = jNet.get('imgBase');
            oImg.src = v;
            var MaxLength = Math.round((oImg.fileSize / 1024)*Math.pow(10,2)) / Math.pow(10,2);
            window.alert(oImg.fileSize);
               var foldobj=new ActiveXObject("Scripting.FileSystemObject"); 
               
               window.alert(foldobj);
               
              //if (fileFormat == "gif" || fileFormat == "jpeg" || fileFormat == "jpg" || fileFormat == "bmp")
            
            return;
            
                var el = Ext.fly('fi-button-msg');
                //R13(X.charCodeAt(j))
                var arrNOMBREIMG = v.toString().split(String.fromCharCode(92));
                var NOMBREIMG = arrNOMBREIMG[arrNOMBREIMG.length-1];
                el.update('<b>Seleccionado EDDY:</b> '+ v +'<b>IMAGEN:</b>');
                jNet.get('FUFile').value = v;
                if(!el.isVisible()){
                    el.slideIn('t', {
                        duration: .2,
                        easing: 'easeIn',
                        callback: function(){
							ProgresoUpLoad(v,NOMBREIMG);
                            el.highlight();
                        }
                    });
                }else{
					ProgresoUpLoad(v,NOMBREIMG);
                    el.highlight();
                    
                }
                //Almacena en la abse de datos
                
            }
        }
    });*/
    //---------------------------------------------------------------------
    
    //----------------------------------------------------------------------
    
});				
				
		function ProgresoUpLoad(){
			Ext.MessageBox.show({title: 'Un momento por favor',msg: 'Guardando imagen seleccionada',progressText: 'Inciando...',width:300,progress:true,closable:false});
			var f = function(v){
				return function(){
					if(v == 12){
						Ext.MessageBox.hide();
						jNet.get('fi-button-msg').css("display","none");
						MostrarListaImagenes(0);
					}else{
						var i = v/11;
						Ext.MessageBox.updateProgress(i, Math.round(100*i)+'% completed');
					}
				};
			};
			for(var i = 1; i < 13; i++){setTimeout(f(i), i*500);}
		
		 
		
    }		
				
		</script>
</HEAD>
	<body onunload="SubirHistorial();" onload="ObtenerHistorial();" bottomMargin="0" leftMargin="0"
		rightMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" border="0" cellSpacing="0" cellPadding="0" width="100%" height="100%">
				<TR>
					<TD><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD height="100%" vAlign="top" align="center">
						<TABLE style="WIDTH: 771px" id="Table2" border="0" cellSpacing="1" cellPadding="1" width="771">
							<TR>
								<TD align="center">
									<TABLE id="Table8" border="0" cellSpacing="1" cellPadding="1" width="100%" align="left">
										<TR>
											<TD width="100%" align="center"><asp:label style="Z-INDEX: 0" id="Label1" runat="server" Font-Bold="True">FICHA TECNICA DE MATERIAL</asp:label></TD>
											<TD align="right"><asp:imagebutton style="Z-INDEX: 0" id="ImgImprimir" runat="server" ImageUrl="../../imagenes/bt_imprimir.gif"></asp:imagebutton></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD><asp:textbox id="txtBuscar" runat="server" Width="100%"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>
									<TABLE style="Z-INDEX: 0" id="Table6" border="0" cellSpacing="1" cellPadding="1" width="300">
										<TR>
											<TD style="WIDTH: 274px" vAlign="top">
												<TABLE id="Table7" border="0" cellSpacing="1" cellPadding="1" align="left">
													<TR>
														<TD style="BORDER-BOTTOM: gray 1px solid; BORDER-LEFT: gray 1px solid; PADDING-BOTTOM: 5px; PADDING-LEFT: 5px; PADDING-RIGHT: 5px; BORDER-TOP: gray 1px solid; BORDER-RIGHT: gray 1px solid; PADDING-TOP: 5px"><IMG style="Z-INDEX: 0; WIDTH: 208px; HEIGHT: 209px" id="imgBase" alt="" align="middle"
																src="/SIMANETWEB/imagenes/spacer.gif" width="208" height="209"></TD>
													</TR>
													<TR>
														<TD>
															<TABLE style="Z-INDEX: 0; BORDER-BOTTOM: darkgray 1px solid; BORDER-LEFT: darkgray 1px solid; HEIGHT: 8px; BORDER-TOP: darkgray 1px solid; BORDER-RIGHT: darkgray 1px solid"
																id="Table5" border="0" cellSpacing="1" cellPadding="1" width="100%" align="left">
																<TR>
																	<TD style="WIDTH: 158px" id="tdContenPag" class="PagerGrilla"></TD>
																	<TD style="BORDER-LEFT: darkgray 1px solid"><LABEL class="cabinet"><INPUT id="FUFile" class="file" size="1" type="file" name="FUFile" runat="server"></LABEL>
																	</TD>
																</TR>
																<TR>
																	<TD style="WIDTH: 158px" class="PagerGrilla"></TD>
																	<TD></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
												</TABLE>
												<IMG style="Z-INDEX: 0; POSITION: absolute; TOP: 0px; LEFT: 0px" id="ImgEliminar" alt=""
													src="/SIMANETWEB/imagenes/Filtro/Eliminar.png"></TD>
											<TD vAlign="top">
												<TABLE style="Z-INDEX: 0; WIDTH: 541px" id="Table4" border="0" cellSpacing="2" cellPadding="0"
													width="541" align="left">
													<TR class="AlternateItemDetalle">
														<TD style="WIDTH: 132px" class="HeaderDetalle"><asp:label id="Label2" runat="server" CssClass="HeaderDetalle">CODIGO:</asp:label></TD>
														<TD><asp:textbox id="txtCodigo" runat="server" CssClass="normaldetalle" BackColor="Transparent" ReadOnly="True"
																rel="calendar" BorderStyle="None"></asp:textbox></TD>
													</TR>
													<TR class="ItemDetalle">
														<TD style="WIDTH: 132px" class="HeaderDetalle"><asp:label style="Z-INDEX: 0" id="Label8" runat="server" CssClass="HeaderDetalle">NOMBRE GENERICO:</asp:label></TD>
														<TD><asp:textbox style="Z-INDEX: 0" id="txtNombreGenerico" runat="server" Width="100%" CssClass="normaldetalle"
																BackColor="Transparent" ReadOnly="True" rel="calendar" BorderStyle="None"></asp:textbox></TD>
													</TR>
													<TR class="AlternateItemDetalle">
														<TD style="WIDTH: 132px" class="HeaderDetalle"><asp:label style="Z-INDEX: 0" id="Label4" runat="server" CssClass="HeaderDetalle">NOMBRE ESPECIFICO:</asp:label></TD>
														<TD><asp:textbox style="Z-INDEX: 0" id="txtNombreEspecifico" runat="server" Width="100%" CssClass="normaldetalle"
																BackColor="Transparent" ReadOnly="True" rel="calendar" BorderStyle="None"></asp:textbox></TD>
													</TR>
													<TR class="ItemDetalle">
														<TD style="WIDTH: 132px" class="HeaderDetalle"><asp:label style="Z-INDEX: 0" id="Label9" runat="server" CssClass="HeaderDetalle">NOMBRE EN INGLES:</asp:label></TD>
														<TD><asp:textbox style="Z-INDEX: 0" id="txtNombreIngles" runat="server" Width="100%" CssClass="normaldetalle"
																BackColor="Transparent" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
													</TR>
													<TR class="AlternateItemDetalle">
														<TD style="WIDTH: 132px" class="HeaderDetalle"><asp:label style="Z-INDEX: 0" id="Label5" runat="server" CssClass="HeaderDetalle" BorderStyle="None">DESCRIPCION:</asp:label></TD>
														<TD><asp:textbox style="Z-INDEX: 0" id="txtDescripcion" runat="server" Width="403px" CssClass="normaldetalle"
																BackColor="Transparent" ReadOnly="True" BorderStyle="None" Height="80px" TextMode="MultiLine"></asp:textbox></TD>
													</TR>
													<TR class="ItemDetalle">
														<TD style="WIDTH: 132px" class="HeaderDetalle"><asp:label style="Z-INDEX: 0" id="Label6" runat="server" CssClass="HeaderDetalle" BorderStyle="None">REFERENCIA:</asp:label></TD>
														<TD><asp:textbox style="Z-INDEX: 0" id="txtReferencia" runat="server" Width="100%" CssClass="normaldetalle"
																Height="56px" TextMode="MultiLine"></asp:textbox></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD>
									<TABLE id="Table3" border="1" cellSpacing="1" cellPadding="1" width="100%" align="left">
										<TR class="AlternateItemDetalle">
											<TD class="HeaderDetalle" width="10%"><asp:label style="Z-INDEX: 0" id="Label7" runat="server" Width="112px" CssClass="HeaderDetalle"
													BorderStyle="None" Height="8px">USO Y APLICACION:</asp:label></TD>
											<TD><asp:textbox style="Z-INDEX: 0" id="txtUso" runat="server" Width="100%" CssClass="normaldetalle"
													BackColor="Transparent" ReadOnly="True" BorderStyle="None" Height="80px" TextMode="MultiLine"></asp:textbox></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD vAlign="top" align="left"><cc1:datagridweb style="Z-INDEX: 0" id="grid" runat="server" Width="100%" ShowFooter="True" RowHighlightColor="#E0E0E0"
										AutoGenerateColumns="False" AllowSorting="True" PageSize="7">
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
										<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<Columns>
											<asp:BoundColumn DataField="DES_EQU" HeaderText="ESTRUCTURA">
												<HeaderStyle Width="5%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
										</Columns>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
									</cc1:datagridweb></TD>
							</TR>
							<TR>
								<TD style="TEXT-TRANSFORM: capitalize"><INPUT style="WIDTH: 32px; HEIGHT: 22px" id="hCargar" value="0" size="1" type="hidden"
										runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 32px; HEIGHT: 22px" id="HNombreImagen" size="1" type="hidden"
										name="Hidden1" runat="server"><IMG style="WIDTH: 16px; HEIGHT: 10px" alt="" src="/SIMANETWEB/imagenes/spacer.gif" width="16"
										height="10">
									<asp:textbox style="Z-INDEX: 0" id="TextBox1" runat="server" Width="80px" Height="25px"></asp:textbox></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD></TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
				<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
						var oParamCollecionBusqueda = new ParamCollecionBusqueda();//El parametro de ingreso es el Nro de Caracter que desencadenara la busqueda
							var oParamBusqueda = new ParamBusqueda();
							oParamBusqueda.Nombre="cod_mat";
							oParamBusqueda.Texto="Codigo de Material";
							oParamBusqueda.CampoAlterno="des_det";
							oParamBusqueda.LongitudEjecucion=5;
							oParamBusqueda.Tipo="C";
						oParamCollecionBusqueda.Agregar(oParamBusqueda);
						
							oParamBusqueda = new ParamBusqueda();
							oParamBusqueda.Nombre="des_det";
							oParamBusqueda.Texto="Descripcion de Material";
							oParamBusqueda.LongitudEjecucion=6;
							oParamBusqueda.Tipo="C";
							oParamBusqueda.Ancho=300;
							oParamBusqueda.CampoAlterno="cod_mat";
						oParamCollecionBusqueda.Agregar(oParamBusqueda);						

							oParamBusqueda = new ParamBusqueda();
							oParamBusqueda.Nombre="idProceso";
							oParamBusqueda.Valor=SIMA.Utilitario.Constantes.General.ProcesoCallBack.BuscarMaterial;
							oParamBusqueda.ParaBusqueda=false;
							oParamBusqueda.Tipo="Q";
						oParamCollecionBusqueda.Agregar(oParamBusqueda);
						(new AutoBusqueda('txtBuscar')).CrearPopupOpcion('/' + ApplicationPath + '/General/Procesar.aspx?',oParamCollecionBusqueda);
						

					var oFUFile = jNet.get('FUFile');
					oFUFile.addEvent("change",function(){
						if(jNet.get("txtCodigo").value.toString().length>0){
							var arrNOMBREIMG = this.value.toString().split(String.fromCharCode(92));
							jNet.get('HNombreImagen').value = arrNOMBREIMG[arrNOMBREIMG.length-1];
							jNet.get('hCargar').value="1";
							document.Form1.submit();
						}
						else{
							 Ext.MessageBox.alert('Estado', 'No es posible almacenar esta imagen, se debera localizar un material primero', function(btn){});
						}
					});
					
					jNet.get('txtReferencia').addEvent("blur",function(){
					
						var oMaterialesFichaTecnicaBE = new EntidadesNegocio.General.MaterialesFichaTecnicaBE();
						oMaterialesFichaTecnicaBE = jNet.get('ImgBase').attr("oBaseBE");
						if(oMaterialesFichaTecnicaBE!=null){
							oMaterialesFichaTecnicaBE.Referencia=jNet.get('txtReferencia').value;
							oMaterialesFichaTecnicaBE.IdEstado="ACT";
							(new Controladora.General.CMaterialesFichaTecnica()).Modificar(oMaterialesFichaTecnicaBE);
						}
						else{
							Ext.MessageBox.alert('Estado', 'Para registrar la referencia debera de seleccionar una imagen', function(btn){});
						}
					});
					
					var oImgEliminar = jNet.get('ImgEliminar')
					oImgEliminar.css("cursor","hand");
					oImgEliminar.addEvent("click",function(){
						var oMaterialesFichaTecnicaBE = new EntidadesNegocio.General.MaterialesFichaTecnicaBE();
						oMaterialesFichaTecnicaBE = jNet.get('ImgBase').attr("oBaseBE");
						if(oMaterialesFichaTecnicaBE!=null){
							Ext.MessageBox.confirm('Confirmar', 'Desea ud. eliminar esta imagen ahora?', function(btn){
								if(btn=="yes"){
									oMaterialesFichaTecnicaBE.IdEstado="ANU";
									(new Controladora.General.CMaterialesFichaTecnica()).Eliminar(oMaterialesFichaTecnicaBE);
									MostrarListaImagenes(0);
								}
							});
						}
					});
					
					var PosLT = getPosition(jNet.get('ImgBase'));
					oImgEliminar.css("left",PosLT.x+195);
					oImgEliminar.css("top",PosLT.y-3);
					
						
		</SCRIPT>
		<SCRIPT language="javascript" type="text/javascript">
		// <![CDATA[
				SI.Files.stylizeAll();
		// ]]>
			var otxtCodigo = jNet.get("txtCodigo");
			if(otxtCodigo.value.length>0){
				MostrarListaImagenes(0);
				CargarListaTecnica(otxtCodigo.value);
			}
		</SCRIPT>
	</body>
</HTML>
