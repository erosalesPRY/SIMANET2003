<%@ Page language="c#" Codebehind="AdministrarImpresiondeCheques.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.Tesoreria.AdministrarImpresiondeCheques" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AdministrarImpresiondeCheques</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../../styles.css">
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>
		<script type="text/javascript" src="../../js/RegEXT.js"></script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" rightMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<div id="south">
				<TABLE id="Table1" border="0" cellSpacing="0" cellPadding="0" width="100%">
					<TR>
						<TD style="WIDTH: 77px"><asp:label id="Label1" runat="server" Font-Bold="True">BANCO:</asp:label></TD>
						<TD><asp:label id="LblBanco" runat="server" Font-Size="10pt"></asp:label></TD>
						<TD><asp:label id="Label9" runat="server" Font-Bold="True">Información: Último cheque impreso:</asp:label></TD>
						<TD></TD>
						<TD></TD>
						<TD></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 77px" vAlign="top"><asp:label id="Label2" runat="server" Font-Bold="True">MONEDA:</asp:label></TD>
						<TD vAlign="top" align="left"><asp:label id="lblMoneda" runat="server" Font-Size="10pt"></asp:label></TD>
						<TD>
							<TABLE id="Table3" border="0" cellSpacing="1" cellPadding="1" width="100%">
								<TR>
									<TD style="FONT-SIZE: 8pt; FONT-WEIGHT: bold"><asp:label id="Label10" runat="server">NRO CHEQUE:</asp:label></TD>
									<TD style="FONT-SIZE: 8pt"><asp:label id="lblNro" runat="server"></asp:label></TD>
									<TD></TD>
								</TR>
								<TR>
									<TD style="FONT-SIZE: 8pt; FONT-WEIGHT: bold"><asp:label id="Label11" runat="server">BENEFICIARIO:</asp:label></TD>
									<TD style="FONT-SIZE: 8pt" width="100%"><asp:label id="lblBenef" runat="server"></asp:label></TD>
									<TD></TD>
								</TR>
								<TR>
									<TD style="FONT-SIZE: 8pt; FONT-WEIGHT: bold"><asp:label style="Z-INDEX: 0" id="Label12" runat="server">EN LETRAS:</asp:label></TD>
									<TD style="FONT-SIZE: 8pt"><asp:label style="Z-INDEX: 0" id="lblEnLetras" runat="server"></asp:label></TD>
									<TD></TD>
								</TR>
							</TABLE>
						</TD>
						<TD></TD>
						<TD></TD>
						<TD></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 77px"></TD>
						<TD id="CellBase"></TD>
						<TD></TD>
						<TD></TD>
						<TD></TD>
						<TD></TD>
					</TR>
				</TABLE>
			</div>
			<div id="DVListadeCheques"><asp:datagrid id="gridCheques" runat="server" AutoGenerateColumns="False" Width="100%">
					<Columns>
						<asp:TemplateColumn>
							<HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle"></HeaderStyle>
							<HeaderTemplate>
								<IMG style="Z-INDEX: 0;cursor:hand" id="ibtnRefresh1" src="/SimaNetWeb/imagenes/Navegador/BtnOpciones/Refresh.gif"
									onclick="Cheques.Banco.CuentaCorriente.ListarPagos(oCuentaCorrienteActiva,Cheques.Banco.CuentaCorriente.Pagos.PorRealizar);">
							</HeaderTemplate>
						</asp:TemplateColumn>
					</Columns>
				</asp:datagrid></div>
			<div id="DVChequeGrirados"><asp:datagrid id="gridChequesGirados" runat="server" AutoGenerateColumns="False" Width="100%">
					<Columns>
						<asp:TemplateColumn>
							<HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle"></HeaderStyle>
							<HeaderTemplate>
								<IMG style="Z-INDEX: 0;cursor:hand" id="ibtnRefresh2" src="/SimaNetWeb/imagenes/Navegador/BtnOpciones/Refresh.gif"
									onclick="Cheques.Banco.CuentaCorriente.ListarPagos(oCuentaCorrienteActiva,Cheques.Banco.CuentaCorriente.Pagos.Realizados);">
							</HeaderTemplate>
						</asp:TemplateColumn>
					</Columns>
				</asp:datagrid></div>
			<table style="WIDTH: 100%; DISPLAY: none; HEIGHT: 100%" id="TblContenedor">
				<tr>
					<td vAlign="middle">
						<table style="Z-INDEX: 0; BORDER-BOTTOM: dimgray 1px solid; BORDER-LEFT: dimgray 1px solid; BORDER-TOP: dimgray 1px solid; BORDER-RIGHT: dimgray 1px solid"
							border="0" bgColor="whitesmoke">
							<tr>
								<td style="PADDING-BOTTOM: 10px; PADDING-LEFT: 10px; PADDING-RIGHT: 10px; PADDING-TOP: 10px">
									<TABLE style="BORDER-BOTTOM: dimgray 1px dotted; BORDER-LEFT: dimgray 1px dotted; BORDER-TOP: dimgray 1px dotted; BORDER-RIGHT: dimgray 1px dotted"
										id="tblDiseño" onmouseover="this.bgColor = '#f8f8ff';" onmouseout="this.bgColor = '#ffffff';"
										border="0" cellSpacing="4" cellPadding="0" width="1100" bgColor="#ffffff">
										<TR>
											<TD style="WIDTH: 197px; FONT-FAMILY: Arial; FONT-SIZE: 14pt; FONT-WEIGHT: bold"><asp:label id="Label8" runat="server">BENEFICIARIO</asp:label></TD>
											<TD style="WIDTH: 136px"></TD>
											<TD style="WIDTH: 203px"></TD>
											<TD></TD>
											<TD style="BORDER-BOTTOM: black 1px solid; PADDING-BOTTOM: 5px; FONT-WEIGHT: bold" align="center"><asp:label id="lblFecha" runat="server" BorderStyle="None"></asp:label></TD>
											<TD style="BORDER-BOTTOM: black 1px dotted; BORDER-LEFT: black 1px dotted; PADDING-BOTTOM: 5px; PADDING-LEFT: 5px; PADDING-RIGHT: 5px; FONT-FAMILY: Arial; FONT-SIZE: 14pt; BORDER-TOP: black 1px dotted; FONT-WEIGHT: bold; BORDER-RIGHT: black 1px dotted; PADDING-TOP: 5px"
												align="right"><asp:label id="lblImporte1" runat="server"></asp:label></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 336px; FONT-FAMILY: Arial; FONT-SIZE: 10pt" vAlign="top" colSpan="2"><asp:label id="lblBeneficiario2" runat="server"></asp:label></TD>
											<TD style="WIDTH: 203px"></TD>
											<TD></TD>
											<TD></TD>
											<TD></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 197px; FONT-FAMILY: Arial; FONT-SIZE: 14pt; FONT-WEIGHT: bold" noWrap><asp:label id="Label7" runat="server">FECHA DE GIRO:</asp:label></TD>
											<TD style="WIDTH: 136px; FONT-FAMILY: Arial; FONT-SIZE: 10pt" noWrap><asp:label id="lblFechaGiro" runat="server"></asp:label></TD>
											<TD style="FONT-FAMILY: Arial; FONT-SIZE: 14pt; FONT-WEIGHT: bold" align="right"></TD>
											<TD style="BORDER-BOTTOM: black 1px solid; FONT-FAMILY: Arial; FONT-SIZE: 14pt; FONT-WEIGHT: bold"><asp:label style="Z-INDEX: 0" id="Label6" runat="server">Nro:</asp:label><asp:label style="Z-INDEX: 0" id="lblNroCheque" runat="server"></asp:label></TD>
											<TD></TD>
											<TD></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 197px; FONT-FAMILY: Arial; FONT-SIZE: 14pt; FONT-WEIGHT: bold"><asp:label id="Label3" runat="server">IMPORTE:</asp:label></TD>
											<TD style="WIDTH: 136px; FONT-FAMILY: Arial; FONT-SIZE: 10pt" noWrap><asp:label id="lblImporte" runat="server"></asp:label></TD>
											<TD style="WIDTH: 203px"></TD>
											<TD></TD>
											<TD></TD>
											<TD></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 197px"></TD>
											<TD style="WIDTH: 136px"></TD>
											<TD style="BORDER-BOTTOM: black 1px dotted; FONT-FAMILY: Arial; FONT-SIZE: 14pt; FONT-WEIGHT: bold"
												colSpan="4" noWrap><asp:label id="lblBeneficiario1" runat="server"></asp:label></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 197px; FONT-FAMILY: Arial; FONT-SIZE: 14pt; FONT-WEIGHT: bold"><asp:label id="Label4" runat="server">REFERENCIA:</asp:label></TD>
											<TD style="WIDTH: 136px"></TD>
											<TD style="WIDTH: 203px"></TD>
											<TD></TD>
											<TD></TD>
											<TD></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 336px; FONT-FAMILY: Arial; HEIGHT: 105px; FONT-SIZE: 10pt" vAlign="top"
												colSpan="2"><asp:label id="lblReferencia" runat="server"></asp:label></TD>
											<TD style="FONT-FAMILY: Arial; HEIGHT: 105px; FONT-SIZE: 14pt; FONT-WEIGHT: bold" vAlign="top"
												colSpan="4" noWrap>
												<TABLE id="Table2" border="0" cellSpacing="1" cellPadding="1" width="100%">
													<TR>
														<TD style="BORDER-BOTTOM: black 1px dotted; FONT-FAMILY: Arial; FONT-SIZE: 14pt; FONT-WEIGHT: bold"
															noWrap><asp:label style="Z-INDEX: 0" id="lblImporteELetras" runat="server"></asp:label></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD style="WIDTH: 197px"></TD>
											<TD style="WIDTH: 136px"><INPUT style="WIDTH: 104px; HEIGHT: 22px" id="hCuentaCorriente" size="12" type="hidden"></TD>
											<TD style="WIDTH: 203px"></TD>
											<TD></TD>
											<TD></TD>
											<TD></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 197px; FONT-FAMILY: Arial; FONT-SIZE: 14pt; FONT-WEIGHT: bold" noWrap><asp:label id="Label5" runat="server">REGISTRADO POR:</asp:label></TD>
											<TD style="WIDTH: 136px; FONT-FAMILY: Arial; FONT-SIZE: 8pt" noWrap><asp:label id="lblUsuarioCodigo" runat="server"></asp:label></TD>
											<TD style="WIDTH: 203px"></TD>
											<TD></TD>
											<TD></TD>
											<TD></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 336px; FONT-FAMILY: Arial; FONT-SIZE: 8pt" colSpan="2" noWrap><asp:label style="Z-INDEX: 0" id="lblUsuarioNombre" runat="server"></asp:label></TD>
											<TD style="WIDTH: 203px"></TD>
											<TD></TD>
											<TD></TD>
											<TD></TD>
										</TR>
									</TABLE>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
		<script>
			var oTRSelected;
			var AreaSelected =-1;
			function onWin_Btn_Aceptar(WINDOW){
				Cheques.Banco.CuentaCorriente.Remover();
				var oddlEntidadFinanciera = new System.Web.UI.WebControls.DropDownList('ddlEntidadFinanciera');
				var LisItem = oddlEntidadFinanciera.ListItem();
				var oddlEntidadFinancieraConfig = new System.Web.UI.WebControls.DropDownList('ddlEntidadFinancieraConfig');
				var LisItemConfig = oddlEntidadFinancieraConfig.ListItem();
				
				var oBancoBE = new Cheques.Banco.DetalleBE(LisItem.value,LisItem.text,jNet.get('hCodMoneda').value,jNet.get('txtPeriodo').value,LisItemConfig.value.toString().split(';')[1],LisItemConfig.text);
				var oDataTable = (new Controladora.Financiera.CTesoreria()).ListarCtaCtePorEntidadesFinanciera(oBancoBE.Codigo,oBancoBE.Moneda);
				for (f=0;f<=oDataTable.Rows.Items.length-1;f++){
					var oDataRow = oDataTable.Rows.Items[f];
					if(oDataRow.Item("EOF")==false){
						var wTab =(new System.Ext.UI.WebControls.Tabs('center')).Agregar(oDataRow.Item("CTA_CTE_BCO"),oDataRow.Item("CTA_CTE_BCO"),oBancoBE,false);		
					}
				}
				WINDOW.close();
			}
			
			var Cheques={};
			Cheques.Moneda={Soles:'S',Dolares:'D'};
			
			Cheques.Banco={};
			Cheques.Banco.AltoChequeSeleccionado=0;
			Cheques.Banco.PuntosIniSeleccionado=0;
			
			Cheques.Banco.DetalleBE=function(CODIGO,NOMBRE,MONEDA,PERIODO,ALTOCHEQUE,PUNTOINICIAL){
				this.Codigo = CODIGO;
				this.Periodo=PERIODO;
				this.Nombre=NOMBRE;
				this.Moneda=MONEDA;
				this.AltoCheque=ALTOCHEQUE;
				this.PuntosInicio = PUNTOINICIAL;
			}
			Cheques.Banco.Load=function(){
				//Oculta el formato de vista previa del cheque
				PanelVistaPrevia();
				var URL ='/SimanetWeb/GestionFinanciera/Tesoreria/ListadodeBancos.aspx';
				(new System.Ext.UI.WebControls.Windows()).Detalle('ABRIR CHEQUERA',URL,null,320,160,onWin_Btn_Aceptar);
			}
			
			function PanelVistaPrevia(){
				var oTblContenedor= document.getElementById('TblContenedor');
				document.body.appendChild(oTblContenedor);
				oTblContenedor.style.display="none";
			}
			
			
			Cheques.Banco.CuentaCorriente={};
			Cheques.Banco.CuentaCorriente.TabActivo;
			Cheques.Banco.CuentaCorriente.DetalleBE=function(MONEDA,PERIODO,CODIGOBANCO,CUENTACORRIENTE){
				this.CodigoBanco = CODIGOBANCO;
				this.CuentaCorriente=CUENTACORRIENTE;
				this.Periodo=PERIODO;
				this.Moneda=MONEDA;
			}
			
			
			Cheques.Banco.CuentaCorriente.Remover=function(){
				//Remueve los items de la grilla
				var ogridCheques = new DataGrid(jNet.get('gridCheques'));
				ogridCheques.Clear();
				var ogridChequesGirados = new DataGrid(jNet.get('gridChequesGirados'));
				ogridChequesGirados.Clear();
				//Remueve los tabs 
				(new System.Ext.UI.WebControls.Tabs('center')).RemoveAll();
			}
			Cheques.Banco.CuentaCorriente.Pagos={PorRealizar:0,Realizados:1};
			
			Cheques.Banco.CuentaCorriente.LstAImprimir=function(NroImpresones){
				//Obtiene Estructura del Formato
				var oDataTableDisenio = new System.Data.DataTable();
					oDataTableDisenio = (new Controladora.Financiera.CTesoreria()).ListarDisenoCheque(SIMA.Utilitario.Enumerados.Financiera.Cheques.Formato.Version2009);
				//Grilla Listado de cheques
				var oDataGrid = jNet.get('gridCheques');
				var NroReg = oDataGrid.rows.length-1;
				if(NroReg==0){
					Ext.MessageBox.alert('ERROR', 'No existen cheques a ser impresos', function(btn){});
					return;
				}
				
				var Dif = (NroReg-NroImpresones);
				if((Dif<0)&&(NroReg>=1)){NroImpresones =NroReg;}
				
				var CCheques = new ActiveXObject("SIMAUtilitario.Cheques");
				if(CCheques != null){
						CCheques.setAltoPapel(Cheques.Banco.AltoChequeSeleccionado, Cheques.Banco.PuntosIniSeleccionado);
						for(var NroItem=1;NroItem<=NroImpresones;NroItem++){
							oDataGrid.rows[1].onclick();
							var dr = jNet.get('tblDiseño').attr("DataRow");
							Cheques.Banco.CuentaCorriente.ItemsInColaPrint(CCheques,dr,oDataTableDisenio);
							CCheques.PrintSaltoPagina();
							//.................................Actualiza el estado del cheque impreso.......................................
							var yymmdd = dr.Item("ANOGIRO") + dr.Item("MESGIRO") + dr.Item("DIAGIRO");
							var flg =  (new Controladora.Financiera.CTesoreria()).Modificar(dr.Item("COD_BCO"),dr.Item("CTA_CTE_BCO"),dr.Item("NRO_CHQ"),dr.Item("FOLIO"),dr.Item("COD_MON"),yymmdd,1);
							//Para identificar el de donde se esta removimiendo
							AreaSelected=0;
							Cheques.Banco.CuentaCorriente.MoverARepositorio();
							jNet.get('lblNro').innerText = dr.Item("NRO_CHQ");
							jNet.get('lblBenef').innerText = dr.Item("BNF_RQR");
							jNet.get('lblEnLetras').innerText = dr.Item("EN_LETRAS");
							//......................................................................................................................................................
						}
						CCheques.Imprimir();
				}
				else{
					Ext.MessageBox.alert('IMPRESION DE CHEQUES', 'No se llego a imprimir el cheque seleccionado', function(btn){});
				}
			}
			
			Cheques.Banco.CuentaCorriente.ItemsInColaPrint=function(CCheques,dr,oDataTableDisenio){
				var outString="";
				for(var f=0;f<=oDataTableDisenio.Rows.Items.length-1;f++){
					var oDataRow =oDataTableDisenio.Rows.Items[f];
					var DataValue ="";var LenAutocompletar=0;
					DataValue = ((oDataRow.Item("Nombre")=="MONTOIMP")? new SIMA.Numero(parseFloat(dr.Item(oDataRow.Item("Nombre")))).toString(2,true,',')
																	  :dr.Item(oDataRow.Item("Nombre")));
					
					//Determinacion de los caracteras a completar
					if((oDataRow.Item("idCampo")!='8')&&(parseInt(oDataRow.Item("FlgCompletar"),10)==1)&&(DataValue.toString().length<parseInt(oDataRow.Item("MaxLen"),10))){
						LenAutocompletar = parseInt(oDataRow.Item("MaxLen"),10) - DataValue.toString().length;
					}
					outString = oDataRow.Item("PosLef")+ SIMA.Utilitario.Constantes.General.Caracter.PuntoyComa 
								+ oDataRow.Item("PosTop")+ SIMA.Utilitario.Constantes.General.Caracter.PuntoyComa 
								+ oDataRow.Item("IdTipoEstilo")+ SIMA.Utilitario.Constantes.General.Caracter.PuntoyComa 
								+ oDataRow.Item("Multiline")+ SIMA.Utilitario.Constantes.General.Caracter.PuntoyComa 
								+ LenAutocompletar.toString()+ SIMA.Utilitario.Constantes.General.Caracter.PuntoyComa 
								+ ((oDataRow.Item("idCampo")=='8')?oDataRow.Item("Texto"):DataValue);
					//Agrega a la cola de impresion el cheque
					CCheques.PrintWrite(outString);	
				}
			}
			
			Cheques.Banco.CuentaCorriente.MoverARepositorio=function(){
					var fClonada = jNet.get(oTRSelected.cloneNode(true)); 
					var tbl = jNet.get(fClonada.childNodes[0].childNodes[0]);//obtiene la tabla con ifnrmacion de cheque para  asignarle el evento dblclick
					
					var GridSelected = ((AreaSelected==0)?jNet.get('gridCheques'):jNet.get('gridChequesGirados'));
					GridSelected.deleteRow(oTRSelected.rowIndex);
					
					var GridDestino = ((AreaSelected==0)?jNet.get('gridChequesGirados'):jNet.get('gridCheques'));
					var tBody =  GridDestino.getElementsByTagName("TBODY")[0];
					tBody.appendChild(fClonada); 
					
					if(AreaSelected==1){
						//Para la Eliminacion del boton RESTAURAR
						var CellContext = fClonada.cells[0].childNodes[0].rows[5].cells[1];
						CellContext.removeChild(CellContext.lastChild);
						//se Asigna el evento de edicion a la tabla contenida en la fila
						tbl.addEvent("dblclick",function(){onRenombrarDblClick(this);});
						var e=fClonada.attr("ITEM");
						SIMA.Utilitario.Helper.SeleccionarItemGrillaOnClickMoverRaton(e,function(source){	
																									AreaSelected =0;
																									oTRSelected = source;
																									var dr = jNet.get(oTRSelected).attr("DataRow");
																									MostrarDatosCheque(dr);
																								}
																						);
						
						
					}
					else{
						var CellContext = jNet.get(fClonada.cells[0].childNodes[0].rows[5].cells[1]);
						CellContext.align="right";
						CellContext.insert(CrearBotonDeshacer());
						SIMA.Utilitario.Helper.SeleccionarItemGrillaOnClickMoverRaton(fClonada.attr("ITEM"),function(source){	
																									AreaSelected =1;
																									oTRSelected = source;
																									var dr = jNet.get(oTRSelected).attr("DataRow");
																									MostrarDatosCheque(dr);
																								}
																						);
					}
			}
			
			
			
			Cheques.Banco.CuentaCorriente.ListarPagos=function(CuentaCorrienteBE,TipodePagos){
				if(oCuentaCorrienteActiva==undefined){
					Ext.MessageBox.alert('ERROR', 'No se ha seleccionado cuenta corriente', function(btn){});
					return false;
				}
				
				var oDataTable =(new Controladora.Financiera.CTesoreria()).ListadodePagos(CuentaCorrienteBE.Moneda,CuentaCorrienteBE.Periodo,CuentaCorrienteBE.CodigoBanco,CuentaCorrienteBE.CuentaCorriente,TipodePagos);
				if(TipodePagos==Cheques.Banco.CuentaCorriente.Pagos.PorRealizar){
					var ogridCheques = new DataGrid(jNet.get('gridCheques'));
					ogridCheques.DataSource=oDataTable;
					ogridCheques.EventHandleItemDataBound = gridCheques_ItemDataBound;
					ogridCheques.DataBind();
				}
				else{
					var ogridChequesGirados = new DataGrid(jNet.get('gridChequesGirados'));
					ogridChequesGirados.DataSource=oDataTable;
					ogridChequesGirados.EventHandleItemDataBound = gridChequesGirados_ItemDataBound;
					ogridChequesGirados.DataBind();				
				}
			}
			
			function gridCheques_ItemDataBound(sender,e){
				var dr = e.Item.DataItem;
				if(dr.Item("EOF")==false){
					e.Item.cells[0].align = "left";
					var row = jNet.get(e.Item);
					var oCelda = jNet.get(row.cells[0]);
					oCelda.insert(CrearTicket(dr,false));
					oCelda.css("PADDING-LEFT","5px"); 
					oCelda.align="center";
					row.attr("NROCHEQUE",dr.Item("NRO_CHQ"));
					row.attr("DataRow",dr);
					row.attr("ITEM",e);
					SIMA.Utilitario.Helper.SeleccionarItemGrillaOnClickMoverRaton(e,function(source){	
																					AreaSelected =0;
																					oTRSelected = source;
																					var dr = jNet.get(oTRSelected).attr("DataRow");
																					MostrarDatosCheque(dr);
																					
																				}
					);
				}				
			}
			
			function gridChequesGirados_ItemDataBound(sender,e){
				var dr = e.Item.DataItem;
				if(dr.Item("EOF")==false){
					e.Item.cells[0].align = "left";
					var row = jNet.get(e.Item);
					var oCelda = jNet.get(row.cells[0]);
					oCelda.insert(CrearTicket(dr,true));
					oCelda.css("PADDING-LEFT","5px"); 
					oCelda.align="center";
					row.attr("NROCHEQUE",dr.Item("NRO_CHQ"));
					row.attr("DataRow",dr);
					row.attr("ITEM",e);
					SIMA.Utilitario.Helper.SeleccionarItemGrillaOnClickMoverRaton(e,function(source){	
																					AreaSelected =1;
																					oTRSelected = source;
																					var dr = jNet.get(oTRSelected).attr("DataRow");
																					MostrarDatosCheque(dr);
																				}
					);
					
				}				
			}
			
			function MostrarDatosCheque(dr){
				var ViewReport = jNet.get('TblContenedor');
				ViewReport.style.display="block";
				jNet.get('lblBeneficiario1').innerText=dr.Item("BNF_RQR");
				jNet.get('lblBeneficiario2').innerText=dr.Item("BNF_RQR");
				jNet.get('lblFecha').innerText=dr.Item("FECHA_GIRO");
				jNet.get('lblFechaGiro').innerText=dr.Item("FECHA_GIRO");
				jNet.get('lblImporte1').innerText=dr.Item("MONTO");
				jNet.get('lblImporte').innerText=dr.Item("MONTO");
				jNet.get('lblNroCheque').innerText=dr.Item("NRO_CHQ");
				jNet.get('lblImporteELetras').innerText=dr.Item("EN_LETRAS");
				jNet.get('lblUsuarioCodigo').innerText=dr.Item("COD_USR_REG");
				jNet.get('lblUsuarioNombre').innerText=dr.Item("REGISTRADO_POR");
				jNet.get('lblReferencia').innerText=dr.Item("OBSERVACION");
				
				jNet.get('tblDiseño').attr("DataRow",dr);
				
			}
			
			function CrearTicket(dr,Girado){
				var cssTextNegrita="PADDING-LEFT:15px;FONT-SIZE: 8pt; FONT-WEIGHT: bold";
				var cssTextNormal="PADDING-LEFT:15px;FONT-SIZE: 7pt;";				
				var tbl = jNet.get(SIMA.Utilitario.Helper.CrearTabla(8,2));
					//tbl.attr("dr",dr);
					tbl.style.cssText = "BACKGROUND-IMAGE: url(/SimaNetWeb/imagenes/Navegador/BtnOpciones/FormatoContinuo.gif); BACKGROUND-REPEAT: no-repeat";
					tbl.css("width","255px");
					tbl.border=0;
					tbl.rows[0].cells[0].innerText="NRO. CHEQUE:";
					 
					tbl.rows[0].cells[0].style.cssText=cssTextNegrita;
					tbl.rows[0].cells[1].innerText=dr.Item("NRO_CHQ");
					tbl.rows[0].cells[1].style.cssText=cssTextNormal;
					//Beneficiario
					tbl.rows[1].cells[0].innerText="BENEFICIARIO";
					tbl.rows[1].cells[0].style.cssText=cssTextNegrita;
					
					tbl.rows[2].cells[0].innerText=dr.Item("BNF_RQR");
					tbl.rows[2].cells[0].style.cssText=cssTextNormal;
					tbl.rows[2].cells[0].colSpan = 2;
					tbl.rows[2].cells[1].style.display="none";
					
					//Importe
					tbl.rows[3].cells[0].innerText="IMPORTE:";
					tbl.rows[3].cells[0].style.cssText=cssTextNegrita;
					tbl.rows[3].cells[1].innerText=dr.Item("MONTO");
					tbl.rows[3].cells[1].style.cssText=cssTextNormal;

					//Fecha de Giro
					tbl.rows[4].cells[0].innerText="FECHA DE GIRO:";
					tbl.rows[4].cells[0].style.cssText=cssTextNegrita;
					tbl.rows[4].cells[1].innerText=dr.Item("FECHA_GIRO");
					tbl.rows[4].cells[1].style.cssText=cssTextNormal;
					
					//Referencia
					tbl.rows[5].cells[0].innerText="REFERENCIA:";
					tbl.rows[5].cells[0].style.cssText=cssTextNegrita;
					if(Girado==true){
						tbl.rows[5].cells[1].align="right";
						tbl.rows[5].cells[1].appendChild(CrearBotonDeshacer());
					}
					else{
						tbl.addEvent("dblclick",function(){onRenombrarDblClick(this);});
					}
					
					tbl.rows[6].cells[0].innerText=dr.Item("OBSERVACION");
					tbl.rows[6].cells[0].style.cssText=cssTextNormal;
					tbl.rows[6].cells[0].colSpan = 2;
					tbl.rows[6].cells[1].style.display="none";	
							
				return tbl;
			}
			function onRenombrarDblClick(e){
				var otbl=e;
				try{
					var oData = jNet.get(e.parentNode.parentNode).attr("DataRow");
					Ext.MessageBox.show({title: 'MODIFICAR RAZON SOCIAL',
										msg: 'Ingrese Razon social',
										width:500,
										buttons: Ext.MessageBox.OKCANCEL,
										multiline: true,
										modal:true,
										value:oData.Items[4],
										fn: function(btn, text){
												if(btn=='ok'){
													(new Controladora.Financiera.CTesoreria()).ModificarBeneficiario(oData.Item("ANOGIRO"),oData.Item("COD_BCO"),oData.Item("FOLIO"),oData.Item("COD_MON"),oData.Item("CTA_CTE_BCO"),text);
													oData.Items[4]=text;//Actualizado
													otbl.rows[2].cells[0].innerText=text;
													orowContext = otbl.parentNode.parentNode;
													orowContext.onclick();												
												}
											}
										});				
					
				}
				catch(Exception){}
			}
			function CrearBotonDeshacer(){
					var oImg = jNet.get((new SIMA.Utilitario.Helper.General.Html()).CrearImagen("/SimaNetWeb/imagenes/Navegador/BtnOpciones/Deshacer.gif"));
						oImg.addEvent("click",function(){
								oTRSelected = jNet.get(oImg.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode);
								Ext.MessageBox.confirm('DESHACER IMPRESION DE CHEQUE', 'Desea Ud. deshacer y restaurar la impresion de este cheque ahora?', function(btn){
														if(btn=='yes'){
															var dr = oTRSelected.attr("DataRow");
															var yymmdd = dr.Item("ANOGIRO") + dr.Item("MESGIRO") + dr.Item("DIAGIRO");
															var flg =  (new Controladora.Financiera.CTesoreria()).Modificar(dr.Item("COD_BCO"),dr.Item("CTA_CTE_BCO"),dr.Item("NRO_CHQ"),dr.Item("FOLIO"),dr.Item("COD_MON"),yymmdd,0);
															if(flg!=-1){
																AreaSelected=1;
																oTRSelected.addEvent("dblclick",function(){onRenombrarDblClick(this);});
																Cheques.Banco.CuentaCorriente.MoverARepositorio();
															}
														}
													});
								
						});	
				return oImg;	
			}
			
			
			function Btn_Imprimir(btn){
				Cheques.Banco.CuentaCorriente.LstAImprimir(btn.NroAImprimir);	
			}
			
			var toolbarItems;
			var gmapTypeMenu = [{ text: 'del 1 al 2',cls: 'x-btn-text-icon',icon: '/simanetweb/Imagenes/tree/print.gif', checked: false, group: 'print', NroAImprimir:'2', handler: Btn_Imprimir}, 
							{ text: 'del 1 al 3',cls: 'x-btn-text-icon',icon: '/simanetweb/Imagenes/tree/print.gif', checked: false, group: 'print', NroAImprimir:'3', handler: Btn_Imprimir}, 
							{ text: 'del 1 al 4',cls: 'x-btn-text-icon',icon: '/simanetweb/Imagenes/tree/print.gif', checked: false, group: 'print', NroAImprimir:'4', handler: Btn_Imprimir}];	


			toolbarItems = [{xtype: 'tbbutton', text:'Abrir chequera',cls: 'x-btn-text-icon',icon: '/simanetweb/Imagenes/tree/Open.gif', tooltip:'Seleccionar Banco', handler: function(){try{Cheques.Banco.Load();}catch(error){Ext.MessageBox.alert('ERROR',  error.description, function(btn){});}}},
							{xtype: 'tbseparator'},
							{xtype: 'splitbutton',text: 'Imprimir [1]',cls: 'x-btn-text-icon',icon: '/simanetweb/Imagenes/tree/print.gif', menu: gmapTypeMenu,NroAImprimir:'1',handler: Btn_Imprimir},
							{xtype: 'tbfill'}];
			

        Ext.state.Manager.setProvider(new Ext.state.CookieProvider());
        
      var oCuentaCorrienteActiva;
       var viewport = new Ext.Viewport({
            layout:'border',
            enableTabScroll:true, 
			deferredRender:true, 
            items:[ {region: 'north', xtype: 'toolbar', items: toolbarItems}
                 ,{region:'south',contentEl: 'south',split:true,height: 100,minSize: 100,maxSize: 200,collapsible: true,title:'DETALLE',margins:'0 0 0 0'}
                 ,{region:'east',title: 'CHEQUES',collapsible: true,split:true,width: 275,minSize: 175,maxSize: 275,layout:'fit',margins:'0 5 0 0',items:
																new Ext.TabPanel({border:false,activeTab:0,tabPosition:'bottom',items:[{contentEl:'DVChequeGrirados',title: 'Impresos',autoScroll:true}]})
                 },{region:'west',id:'west-panel',title:'CHEQUES',collapsible: true,split:true,width: 275,minSize: 175,maxSize: 275,layout:'fit',margins:'0 0 0 5',layoutConfig:{animate:true}
							,items:new Ext.TabPanel({border:false,activeTab:0,tabPosition:'bottom',items:[{contentEl:'DVListadeCheques',title: 'Por imprimir',autoScroll:true}]})                     
                 }
                 ,
                 new Ext.TabPanel({
                    region:'center',
                    id:'center',
                    deferredRender:true,
                    activeTab:0,
                    listeners: {'tabchange': function(tabPanel, tab){
													try{
														AreaSelected=-1;
														Cheques.Banco.CuentaCorriente.TabActivo=tab;
														var oBancoBE = new Cheques.Banco.DetalleBE();
														oBancoBE = tab.BaseBE;
														//Valores Seleccionados
														jNet.get('LblBanco').innerText= oBancoBE.Nombre;
														jNet.get('lblMoneda').innerText= ((oBancoBE.Moneda=='S')?'SOLES':'DOLARES');
														Cheques.Banco.AltoChequeSeleccionado=oBancoBE.AltoCheque;
														Cheques.Banco.PuntosIniSeleccionado=oBancoBE.PuntosInicio;
														//Listar Cheques a ser impresos
														oCuentaCorrienteActiva = new Cheques.Banco.CuentaCorriente.DetalleBE(oBancoBE.Moneda,oBancoBE.Periodo,oBancoBE.Codigo,tab.id);
														Cheques.Banco.CuentaCorriente.ListarPagos(oCuentaCorrienteActiva,Cheques.Banco.CuentaCorriente.Pagos.PorRealizar);
														Cheques.Banco.CuentaCorriente.ListarPagos(oCuentaCorrienteActiva,Cheques.Banco.CuentaCorriente.Pagos.Realizados);
														//Oculta el contenedor con la finalidad de no mostrar los datos ultimos
														var ViewReport = jNet.get('TblContenedor');
														ViewReport.style.display="none";
														var NombreContext = "Context" + tab.id;
														jNet.get(NombreContext).insert(ViewReport);
													}
													catch(error){
														//Ext.MessageBox.alert('ERROR',  error.description, function(btn){});
													}
												}
								} 
                    /*,
                    items:[{
                        contentEl:'Contenedor',
                        title: 'Diseno',
                        autoScroll:true,
                        closable:false 
                    }]*/
                     
                })
             ]
             
        });  
        

		</script>
	</body>
</HTML>
