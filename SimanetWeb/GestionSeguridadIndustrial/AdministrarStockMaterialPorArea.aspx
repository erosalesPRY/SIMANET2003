<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="AdministrarStockMaterialPorArea.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionSeguridadIndustrial.AdministrarStockMaterialPorArea" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>AdministrarStockMaterialPorArea</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../styles.css">
		<SCRIPT language="javascript" src="../js/@Import.js"></SCRIPT>
		<script type="text/javascript" src="../js/RegEXT.js"></script>
		<style>.tabs { BACKGROUND-IMAGE: url(http://localhost/SimanetWeb/imagenes/Navegador/drop-under.gif) !important }
	.new-topic { BACKGROUND-IMAGE: url(http://SIMANETCOMPLEMENTOS/ext-3.2.1/examples/forum/message_edit.png) !important }
	.cellClass { BACKGROUND-IMAGE: url(http://simanet/SimanetWeb/imagenes/Navegador/Otros.gif); PADDING-LEFT: 20px; BACKGROUND-REPEAT: no-repeat; BACKGROUND-POSITION: left center }
	.AlertaStock { BACKGROUND-IMAGE: url(http://simanet/SimanetWeb/imagenes/Navegador/Alerta1.gif); PADDING-LEFT: 20px; BACKGROUND-REPEAT: no-repeat; BACKGROUND-POSITION: left center }
	</style>
		<script>
			var KEYCODITEM = "CodItem";
			var KEYQCODMAT="CodMat";
			var KEYIDTAB = "IdTab";
			var KEYQNOMBREAREA = "NomArea";
		
			var ListarValedeSalidaDisponibles = new Object();
				ListarValedeSalidaDisponibles.yo;
				ListarValedeSalidaDisponibles.Aceptar=function(vHandle){
					vHandle.close();
				}
				
			var ListarMaterialPorAlmacenValedeSalida = new Object();
				ListarMaterialPorAlmacenValedeSalida.yo=null;
			
			var AdministrarStockMaterialPorArea = new Object();
				AdministrarStockMaterialPorArea.IdArea="";
				AdministrarStockMaterialPorArea.NombreArea="";
				AdministrarStockMaterialPorArea.IdTabSelected="";
		
			var DetalleStockMaterialPorArea = new Object();
				DetalleStockMaterialPorArea.yo=null;
				DetalleStockMaterialPorArea.rowSelect;
				
				
			var DetalleStockMaterialPorAreaValeSalida = new Object();
				DetalleStockMaterialPorAreaValeSalida.yo=null;

			AdministrarStockMaterialPorArea.EntregarMaterial=function(CodigoArea){
				var URLDETALLE = '/' + ApplicationPath + '/GestionSeguridadIndustrial/AdministrarKardexPorPersona.aspx?'  + KEYQIDAREA + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + CodigoArea
																														  + SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
																														  + KEYQNOMBREAREA + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + AdministrarStockMaterialPorArea.NombreArea;
				var oPagina = (new SIMA.Utilitario.Helper.General.Pagina()).Response.Redirect(URLDETALLE);
			}



			DetalleStockMaterialPorArea.AgregarVSM=function(){
				var URLDETALLE = '/' + ApplicationPath + '/GestionSeguridadIndustrial/ListarValedeSalidaDisponibles.aspx?';
				var Parametros = KEYQIDAREA + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + AdministrarStockMaterialPorArea.IdArea;
				ListarValedeSalidaDisponibles.yo=(new System.Ext.UI.WebControls.Windows()).Detalle("Listado Vale de Salida",URLDETALLE + Parametros,this,795,400,ListarValedeSalidaDisponibles.Aceptar);
				
				window.setTimeout("ActivarBusquedaVSM();",800);
				
				
			}
			function ActivarBusquedaVSM(){
				(new System.Web.UI.WebControls.TextBoxFindInGrid(document.getElementById('txtBuscarVSM'),'grid',2));
			}
			
			ListarMaterialPorAlmacenValedeSalida.Materiales=function(CodigoCentro,CodigoAlmacen,NroValeSalida,Descripcion,Fechavs,impTotalVSM){
				var KEYQNROVALSAL = "NroValSal";
				var KEYQCODALM = "CodAlm";
				var KEYQCODCEO = "CodCeo";
				var KEYQDESVALSAL = "DesValSal";
				var KEYQFECEMS = "FEms";
			
				
				var URLDETALLE = '/' + ApplicationPath + '/GestionSeguridadIndustrial/ListarMaterialPorAlmacenValedeSalida.aspx?';
				var Parametros = KEYQNROVALSAL + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + NroValeSalida
								+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
								+ KEYQCODALM + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + CodigoAlmacen
								+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
								+ KEYQCODCEO + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + CodigoCentro
								+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
								+ KEYQDESVALSAL + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + Descripcion
								+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
								+ KEYQFECEMS + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + Fechavs;
								
				ListarMaterialPorAlmacenValedeSalida.yo = (new System.Ext.UI.WebControls.Windows()).Detalle("Listado Materiales disponibles",URLDETALLE + Parametros,this,795,600,ListarMaterialPorAlmacenValedeSalida.Aceptar);
			}
			
			ListarMaterialPorAlmacenValedeSalida.Aceptar=function(vHandle){
				Ext.MessageBox.confirm('Actualizar Stock', 'Desea agregar y actualiza el Stock con este producto?', function(btn){
										if(btn=="yes"){
											(new Controladora.SeguridadIndustrial.CCCTT_StockMaterial()).InsertarAlls(jNet.get('hCodCentro').value,jNet.get('hNroValSal').value,jNet.get('hCodAlmacen').value);
											AdministrarStockMaterialPorArea.TabBodyLoads();
											ListarValedeSalidaDisponibles.yo.close();
											vHandle.close();
										}
										else{
											AdministrarStockMaterialPorArea.TabBodyLoads();
											vHandle.close();
										}
									});
			}
			
			
			
			ListarMaterialPorAlmacenValedeSalida.DetalleMaterial=function(CodArea,CodigoCentro,CodigoAlmacen,NroValeSalida,CodigoMaterial){
				var KEYQCODCEO = "CodCeo";
				var KEYQCODALM = "CodAlm";
				var KEYQNROVALSAL = "NroValSal";
				
				
				//var URLDETALLE = '/' + ApplicationPath + '/GestionSeguridadIndustrial/DetalleMaterialValedeSalida.aspx?';
				var URLDETALLE = '/' + ApplicationPath + '/GestionSeguridadIndustrial/DetalleMaterialValedeSalidaxTalla.aspx?';
				
				var Parametros = KEYQIDAREA + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + CodArea
								+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
								+ KEYQCODCEO + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + CodigoCentro
								+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
								+ KEYQCODALM + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + CodigoAlmacen
								+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
								+ KEYQNROVALSAL + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + NroValeSalida
								+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
								+ KEYQCODMAT + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual +  CodigoMaterial
								+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
								+ SIMA.Utilitario.Constantes.KEYMODOPAGINA + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + SIMA.Utilitario.Enumerados.ModoPagina.N;
				
				//(new System.Ext.UI.WebControls.Windows()).Detalle("Actualizar Stock",URLDETALLE + Parametros,this,495,205,DetalleStockMaterialPorArea.Aceptar);
				(new System.Ext.UI.WebControls.Windows()).Detalle("Actualizar Stock",URLDETALLE + Parametros,this,630,460,DetalleStockMaterialPorArea.Aceptar);
				
			}
			
			DetalleStockMaterialPorAreaValeSalida.ListarDetalle=function(CodArea,CodMaterial,ImpTotalVSM){
				
				var URLDETALLE = '/' + ApplicationPath + '/GestionSeguridadIndustrial/DetalleStockMaterialPorAreaValeSalida.aspx?';
				var Parametros = KEYQIDAREA + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + CodArea
								+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
								+ KEYQCODMAT  + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + CodMaterial
								+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
								+ KEYIDTAB + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + AdministrarStockMaterialPorArea.IdTabSelected
								+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
								+ KEYQMONTOVSM  + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + ImpTotalVSM;
				
				DetalleStockMaterialPorAreaValeSalida.yo=(new System.Ext.UI.WebControls.Windows()).Detalle("Actualizar Stock",URLDETALLE + Parametros,this,995,350,DetalleStockMaterialPorAreaValeSalida.Aceptar);			
			}
			
			DetalleStockMaterialPorAreaValeSalida.NameCtrlAtendido;
			DetalleStockMaterialPorAreaValeSalida.SetValueControls=function(ControlName,Valor){
				jNet.get(ControlName).value = Valor;
			}
			
			DetalleStockMaterialPorAreaValeSalida.Aceptar=function(wHandle){
				wHandle.close();
			}
			
			
			DetalleStockMaterialPorArea.DetalleMaterialStock=function(CodArea,CodItem){
				var URLDETALLE = '/' + ApplicationPath + '/GestionSeguridadIndustrial/DetalleMaterialValedeSalida.aspx?';
				var Parametros = KEYQIDAREA + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + CodArea
								+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
								+ KEYCODITEM  + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + CodItem
								+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
								+ SIMA.Utilitario.Constantes.KEYMODOPAGINA + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + SIMA.Utilitario.Enumerados.ModoPagina.M;
								
				DetalleStockMaterialPorArea.yo=(new System.Ext.UI.WebControls.Windows()).Detalle("Actualizar Stock",URLDETALLE + Parametros,this,495,205,DetalleStockMaterialPorArea.Aceptar);
			}
			
			
			
			
			DetalleStockMaterialPorArea.Aceptar=function(wHandle){
				//Valida que el registro o modificacion la cantidad no exceda a la del vale de salida
				var CantRegistrada =parseInt(jNet.get('hCantReg').value);
				var CantVSM = parseInt(jNet.get('txtCantEnVSM').value);
				var CantPorReg=0;
				var TotalPorReg=0;
				
				if(jNet.get('hModo').value.toString().Igual('N')){
					ogrid = jNet.get('gridTalla');
					var TotalReg = parseInt(ogrid.rows[ogrid.rows.length-1].cells[3].innerText);
					
					var otxt;
					for(var i=2;i<= ogrid.rows.length-2;i++){
						otxt = ogrid.rows[i].cells[3].children[0];
						CantPorReg=CantPorReg + parseInt(otxt.value);
					}
					//TotalPorReg = (CantPorReg+CantRegistrada);
					
					//if(TotalPorReg<=TotalReg){
					if(TotalReg>=CantPorReg){
					for(var i=2;i<= ogrid.rows.length-2;i++){
						otxt = ogrid.rows[i].cells[3].children[0];
						if(parseInt(otxt.value)>0){
							var oStockMaterialBE = new EntidadesNegocio.Personal.StockMaterialBE();
								oStockMaterialBE.CodItem = jNet.get('hCodItem').value;
								oStockMaterialBE.CodCeo=jNet.get('hCodCeo').value;
								oStockMaterialBE.CodAlm=jNet.get('hNroAlmacen').value;
								oStockMaterialBE.NroVsm=jNet.get('hNroValeSalida').value;
								oStockMaterialBE.CodMat=jNet.get('txtCodMat').value;
								oStockMaterialBE.CodTblTalla=jNet.get('hCodTblTalla').value;
								//Datos Obteneidos de cada fila de la grilla
								oStockMaterialBE.Cantidad=parseInt(otxt.value);
								oStockMaterialBE.IdTalla=ogrid.rows[i].cells[1].getAttribute('IDTALLA');
								(new Controladora.SeguridadIndustrial.CCCTT_StockMaterial()).Insertar(oStockMaterialBE);
						}
					}
					ListarMaterialPorAlmacenValedeSalida.yo.close();
					ListarValedeSalidaDisponibles.yo.close();
					wHandle.close();
					}
					else{
						Ext.MessageBox.alert('STOCK', 'La cantidad ingresada sumada a la ya registrada excede lo establecido en el vale de salida', function(btn){});
					}
				}
				else{
					CantPorReg=parseInt(jNet.get('txtCantReg').value);
					totReg = (CantRegistrada+CantPorReg);
					if(totReg >CantVSM){Ext.MessageBox.alert('STOCK', 'La cantidad ingresada sumada a la ya registrada excede la establecida en el vale de salida', function(btn){});return;}
					DetalleStockMaterialPorArea.Guardar();
					AdministrarStockMaterialPorArea.TabBodyLoads();
					wHandle.close();
				}
			}
			
			
			DetalleStockMaterialPorArea.Guardar=function(Cantidad){
				var oStockMaterialBE = new EntidadesNegocio.Personal.StockMaterialBE();
				oStockMaterialBE.CodItem = jNet.get('hCodItem').value;
				oStockMaterialBE.CodCeo=jNet.get('hCodCeo').value;
				oStockMaterialBE.CodAlm=jNet.get('hNroAlmacen').value;
				oStockMaterialBE.NroVsm=jNet.get('hNroValeSalida').value;
				oStockMaterialBE.CodMat=jNet.get('txtCodMat').value;
				oStockMaterialBE.CodTblTalla=jNet.get('hCodTblTalla').value;

				oStockMaterialBE.Cantidad=jNet.get('txtCantReg').value;
				var oddl = (new System.Web.UI.WebControls.DropDownList('ddlTalla'));
				var lItem = oddl.ListItem();
				oStockMaterialBE.IdTalla=lItem.value;
				
				(new Controladora.SeguridadIndustrial.CCCTT_StockMaterial()).Insertar(oStockMaterialBE); 
				
				/*if(jNet.get('hModo').value=='N'){
					ListarMaterialPorAlmacenValedeSalida.yo.close();
					ListarValedeSalidaDisponibles.yo.close();
				}
				else*/
				{
					DetalleStockMaterialPorAreaValeSalida.yo.close();
				}
			}
			
			
			
			
			DetalleStockMaterialPorArea.Confirmar=function(CodCeo,CodAlm,NroVsm,CodMat,Cantidad){
				Ext.MessageBox.confirm('Actualizar Stock', 'Desea agregar y actualiza el Stock con este producto?', function(btn){
										if(btn=="yes"){
											var oStockMaterialBE = new EntidadesNegocio.Personal.StockMaterialBE();
												oStockMaterialBE.CodItem = "";
												oStockMaterialBE.CodCeo=CodCeo;
												oStockMaterialBE.CodAlm=CodAlm;
												oStockMaterialBE.NroVsm=NroVsm;
												oStockMaterialBE.CodMat=CodMat;
												oStockMaterialBE.Cantidad=Cantidad;
												oStockMaterialBE.CodTblTalla=10;
												oStockMaterialBE.IdTalla=1;
												(new Controladora.SeguridadIndustrial.CCCTT_StockMaterial()).Insertar(oStockMaterialBE);
												
												AdministrarStockMaterialPorArea.TabBodyLoads();
												ListarMaterialPorAlmacenValedeSalida.yo.close();
												ListarValedeSalidaDisponibles.yo.close();
										}
									});
			}
			
			DetalleStockMaterialPorArea.EliminarItemStock=function(){
					if(jNet.get(DetalleStockMaterialPorAreaValeSalida.NameCtrlAtendido).value !='0'){
						Ext.MessageBox.alert('STOCK', 'Item no se puede eliminar<br>Solo es posible la Eliminación de Item(s) que no cuenten con movimiento de atención', function(btn){});	
					}
					else{
						Ext.MessageBox.confirm('Actualizar Stock', 'Desea eliminar este item seleccionado?', function(btn){
										if(btn=="yes"){
											(new Controladora.SeguridadIndustrial.CCCTT_StockMaterial()).Eliminar(jNet.get('hGCodItem_det'+AdministrarStockMaterialPorArea.IdTabSelected).value);
											oGrid = DetalleStockMaterialPorArea.rowSelect.parentNode;
											oGrid.removeChild(DetalleStockMaterialPorArea.rowSelect);
											//Actualiza la eliminacion
											//AdministrarStockMaterialPorArea.TabBodyLoads();
										}
									});
					}
			}
			
		</script>
</HEAD>
	<body onkeypress="if(event.keyCode==13)return false;" onunload="SubirHistorial();" onload="ObtenerHistorial();"
		bottomMargin="0" leftMargin="0" rightMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" border="0" cellSpacing="1" cellPadding="1" width="100%" height="100%">
				<TR>
					<TD><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD height="100%" vAlign="top">
						<TABLE style="WIDTH: 687px" id="Table2" border="0" cellSpacing="1" cellPadding="1" width="687"
							align="center">
							<TR>
								<TD>
									<asp:Label id="Label1" runat="server" Font-Bold="True">ADMINISTRAR STOCK POR AREA</asp:Label></TD>
							</TR>
							<TR>
								<TD></TD>
							</TR>
							<TR>
								<TD id="TabStrip" height="95%" vAlign="top" width="100%"></TD>
							</TR>
							<TR>
								<TD><INPUT style="Z-INDEX: 0; WIDTH: 57px; HEIGHT: 22px" id="hGridPaginaSort" size="4" type="hidden"
										name="hGridPaginaSort" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 50px; HEIGHT: 22px" id="hGridPagina" value="0" size="3"
										type="hidden" name="hGridPagina" runat="server"><INPUT style="WIDTH: 56px; HEIGHT: 22px" id="hLstAreas" size="4" type="hidden" runat="server"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
			<div style="MARGIN-TOP: 0px; DISPLAY: none; OVERFLOW: auto" id="myLoading" class="myloadingjs">
		</form>
		<SCRIPT>
				var KEYQIDAREA="IdArea";
				var KEYQMONTOVSM = "MntVSM";
				var oAreaBE;
				var KEYQFECHACONSULTA="Fconsult";
				var TabID='0';
				
				AdministrarStockMaterialPorArea.TabBodyLoads=function(){
					var ViewReport = jNet.get('myLoading');
					ViewReport.style.display="block";
					var NombreContext = "Context" + AdministrarStockMaterialPorArea.IdTabSelected;
					var urlDetalle =  '/' + ApplicationPath + "/GestionSeguridadIndustrial/DetalleStockMaterialPorArea.aspx?";
					var params = KEYQIDAREA + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + AdministrarStockMaterialPorArea.IdArea
					+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
					+ KEYIDTAB + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + AdministrarStockMaterialPorArea.IdTabSelected;
					
					jNet.get(NombreContext).load(urlDetalle,params,function(Estado){
																		(new System.Web.UI.WebControls.TextBoxFindInGrid(document.getElementById('txt'+ AdministrarStockMaterialPorArea.IdTabSelected),'Grid'+ AdministrarStockMaterialPorArea.IdTabSelected,2));
																	});					
				}
				
				Ext.state.Manager.setProvider(new Ext.state.CookieProvider());
				var wTabPanel = new Ext.TabPanel({
							id:'tabMaster'
							,deferredRender:true
							,enableTabScroll: true
							,renderTo:'TabStrip'
							,width:window.screen.width-20
							,height:window.screen.height-180
							,activeTab:0
							,defaults:{autoScroll: true}
							,listeners: {'tabchange': function(tabPanel, tab){
													sessionStorage.setItem('TabStock', tab.id.replace('Tab',''));//Almacena en el temporal el tab seleccionado
															try{
																oTabAreaBE =  tab.BaseBE;
																AdministrarStockMaterialPorArea.IdTabSelected =tab.id;
																AdministrarStockMaterialPorArea.IdArea = oTabAreaBE.IdArea;
																AdministrarStockMaterialPorArea.NombreArea = oTabAreaBE.NombreArea;
																
																if(oTabAreaBE.Load==false){
																	//Oculta el contenedor con la finalidad de no mostrar los datos ultimos
																	AdministrarStockMaterialPorArea.TabBodyLoads();
																	oTabAreaBE.Load=true;
																}

															} 
															catch(error){
																//Ext.MessageBox.alert('ERROR',  error.description, function(btn){});
															}
													}
										} 
										
						})
				var oTabAreaBE;
				function CargarAreas(){
					//jNet.get('hLstAreas').value = "100;Marina de geuerra@200;sima peru";
					var arrArea = jNet.get('hLstAreas').value.split('@');
					if(arrArea[0].length>0){
						for(var i=0;i<=arrArea.length-1;i++){
							var arrData = arrArea[i].split(';');
							(new System.Ext.UI.WebControls.Tabs('tabMaster')).Agregar('Tab'+i,arrData[1],{IdArea:arrData[0],NombreArea:arrData[1],Load:false},false);
						}
						//Activa el tab por defaul
						var tabs = wTabPanel.find( 'title', arrArea[0].split(';')[1]);
						wTabPanel.setActiveTab(tabs[0]);
					}
				}
				
				CargarAreas();
				
				//Prepara el control para la busqueda en la grilla o tabla
			
			
		</SCRIPT>
</DIV>
	</body>
</HTML>
