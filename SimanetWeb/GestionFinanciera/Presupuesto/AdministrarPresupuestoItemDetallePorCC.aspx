<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Page language="c#" Codebehind="AdministrarPresupuestoItemDetallePorCC.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.Presupuesto.AdministrarPresupuestoItemDetallePorCC" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AdministrarPresupuestoItemDetallePorCC</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../../styles.css">
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>
		<script>
			function MostrarDetalleRqr(e){
				var oRow = jNet.get(e.parentNode);
				var URLPagina = "AdministrarListadoActivoPorServicio.aspx" + SIMA.Utilitario.Constantes.General.Caracter.signoInterrogacion
								+ SIMA.Utilitario.Constantes.GestionFinanciera.PaginaQueryParam.KEYQNROCEOPE + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + oRow.attr("CODCEO")
								+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
								+ SIMA.Utilitario.Constantes.GestionFinanciera.PaginaQueryParam.KEYQNRORQR + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + oRow.attr("NROREQ");
				
				var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
				oPagina.Response.ShowDialogoModal(URLPagina,600,250);
			}
		</script>
	</HEAD>
	<body onkeydown="if(event.keyCode==13){return false;}" bottomMargin="0" leftMargin="0"
		rightMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" border="0" cellSpacing="1" cellPadding="1" width="100%" height="100%">
				<TR>
					<TD align="right">
						<TABLE id="Table2" border="0" cellSpacing="1" cellPadding="1" width="100%" align="left"
							bgColor="whitesmoke">
							<TR>
								<TD>
									<asp:Label id="Label1" runat="server" Font-Bold="True" Font-Size="Medium">PARTIDA:</asp:Label></TD>
								<TD width="100%">
									<asp:Label id="LblPartida" runat="server" Font-Bold="True" Font-Size="Medium">..</asp:Label></TD>
								<TD><INPUT id="btnEliminar" value="Eliminar" type="button" onclick="Eliminar();" style="Z-INDEX: 0"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD height="100%" vAlign="top" align="left"><cc1:datagridweb id="grid" runat="server" Width="100%" AutoGenerateColumns="False" RowHighlightColor="#E0E0E0">
							<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
							<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
							<FooterStyle CssClass="FooterGrilla"></FooterStyle>
							<ItemStyle CssClass="ItemGrilla"></ItemStyle>
							<Columns>
								<asp:BoundColumn DataField="COD_RCS" HeaderText="CODIGO">
									<HeaderStyle Width="3%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="DES_DET" HeaderText="CONCEPTO">
									<HeaderStyle Width="50%"></HeaderStyle>
									<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="DESC_TIPO_MANT" HeaderText="TIPO MATENIMIENTO">
									<HeaderStyle Width="6%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="U.M">
									<HeaderStyle Width="200px"></HeaderStyle>
									<ItemTemplate>
										<asp:DropDownList id="ddlUnidadMedida" runat="server" Width="150px" CssClass="normaldetalle"></asp:DropDownList>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="DM.A">
									<ItemTemplate>
										<asp:TextBox id="txtDMA" runat="server" Width="36px" CssClass="normaldetalle" Height="24px"></asp:TextBox>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="DM.L">
									<ItemTemplate>
										<asp:TextBox style="Z-INDEX: 0" id="txtDML" runat="server" Width="36px" CssClass="normaldetalle"
											Height="24px"></asp:TextBox>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="CANT">
									<HeaderStyle Width="4.3%"></HeaderStyle>
									<ItemTemplate>
										<asp:TextBox id="txtCantidad" runat="server" Width="36px" CssClass="normaldetalle" Height="24px"></asp:TextBox>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="P.U">
									<HeaderStyle Width="4.3%"></HeaderStyle>
									<ItemTemplate>
										<asp:TextBox id="txtPU" runat="server" Width="36px" CssClass="normaldetalle" Height="24px"></asp:TextBox>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="TOTAL">
									<HeaderStyle Width="4.3%"></HeaderStyle>
									<ItemStyle Wrap="False"></ItemStyle>
								</asp:TemplateColumn>
								<asp:BoundColumn HeaderText="CNT EQU">
									<HeaderStyle Width="2%"></HeaderStyle>
									<ItemStyle Wrap="False"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn HeaderText="EST">
									<HeaderStyle Width="1%"></HeaderStyle>
								</asp:BoundColumn>
							</Columns>
							<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
						</cc1:datagridweb></TD>
				</TR>
				<TR>
					<TD ><INPUT id="hIdRow" type="hidden"></TD>
				</TR>
			</TABLE>
		</form>
		<script>
			var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
		try{
				var oGrid = jNet.get("grid");
				for(var f=1;f<=oGrid.rows.length-1;f++){
					var oddlUM = jNet.get(oGrid.rows[f].cells[3].children[0]);
					oddlUM.addEvent("blur",function(){LastFocus(this);});
					for(var c=4;c<=7;c++){
						if(oPagina.Request.Params[SIMA.Utilitario.Constantes.GestionFinanciera.PaginaQueryParam.KEYQCUENTACONTABLE].toString().substr(2,1).Equal('5')&&(c<6)){
							jNet.get(oGrid.rows[0].cells[c]).css("display","none");
							jNet.get(oGrid.rows[f].cells[c]).css("display","none");
							
							jNet.get(oGrid.rows[0].cells[3]).css("display","none");
							jNet.get(oGrid.rows[f].cells[3]).css("display","none");
							
							jNet.get(oGrid.rows[0].cells[9]).css("display","none");
							jNet.get(oGrid.rows[f].cells[9]).css("display","none");
						}
						else{
							jNet.get(oGrid.rows[0].cells[2]).css("display","none");
							jNet.get(oGrid.rows[f].cells[2]).css("display","none");							
						}
						
						var oTxt = jNet.get(oGrid.rows[f].cells[c].children[0]);
						oTxt.addEvent("keydown",function(){TeclaPresionada(this);});
						oTxt.addEvent("blur",function(){LastFocus(this);});
					}
				}
	
		}
		catch(Error){
			window.alert(Error.descripcion);
		}
		
		
		function TeclaPresionada(e){
			if((event.keyCode == SIMA.Utilitario.Constantes.General.KeyCode.KeyReturn)||(event.keyCode == SIMA.Utilitario.Constantes.General.KeyCode.keyDown)||(event.keyCode == SIMA.Utilitario.Constantes.General.KeyCode.keyUp)){
				var inGrid = jNet.get(e.parentNode.parentNode.parentNode.parentNode);
				inGrid.attr("RowIndexSelect",e.parentNode.parentNode.rowIndex);
				inGrid.attr("CellIndexSelect",e.parentNode.cellIndex);
				//Enfoca el siguiente object
				if((inGrid.attr("RowIndexSelect")<inGrid.rows.length-1)&&(event.keyCode != SIMA.Utilitario.Constantes.General.KeyCode.keyUp)){
					inGrid.rows[inGrid.attr("RowIndexSelect")+1].cells[inGrid.attr("CellIndexSelect")].childNodes[0].focus();
				}
				else if (inGrid.attr("RowIndexSelect")!=1){
					inGrid.rows[inGrid.attr("RowIndexSelect")-1].cells[inGrid.attr("CellIndexSelect")].childNodes[0].focus();
				}
			}
		}
		

		
		
		
		function LastFocus(e){
			if(e.attr("OldValue")!= e.value){
				var oRow = jNet.get(e.parentNode.parentNode);
				//Seccion de validacion
				if(oRow.cells[4].childNodes[0].value.toString().IsNumeric()==false){
					window.alert("Numero de ancho no valido");
					oRow.cells[4].childNodes[0].focus();
					return;
				}
				if(oRow.cells[5].childNodes[0].value.toString().IsNumeric()==false){
					window.alert("Numero de largo no valido");
					oRow.cells[5].childNodes[0].focus();
					return;
				}
				if(oRow.cells[6].childNodes[0].value.toString().IsNumeric()==false){
					window.alert("Cantidad ingresada no valida");
					oRow.cells[6].childNodes[0].focus();
					return;
				}
				if(oRow.cells[7].childNodes[0].value.toString().IsNumeric()==false){
					window.alert("Precio unitario no valida");
					oRow.cells[7].childNodes[0].focus();
					return;
				}
					
				e.attr("OldValue",e.value);
				var oPagina = new SIMA.Utilitario.Helper.General.Pagina();	
				var oPDReqAusPptBE = new EntidadesNegocio.Presupuesto.PDReqAusPptBE();
				oPDReqAusPptBE.CodCeo =1;
				oPDReqAusPptBE.NroReq = oRow.attr("NROREQ");	
				oPDReqAusPptBE.CodRcs = oRow.attr("CODRCS");	
				oPDReqAusPptBE.CntDmaAju = oRow.cells[4].childNodes[0].value;
				oPDReqAusPptBE.CntDmlAju = oRow.cells[5].childNodes[0].value;
				oPDReqAusPptBE.CntReqAju = oRow.cells[6].childNodes[0].value;
				oPDReqAusPptBE.PrcUntAju = oRow.cells[7].childNodes[0].value;
				oPDReqAusPptBE.TipoRCS = ((oPagina.Request.Params[SIMA.Utilitario.Constantes.GestionFinanciera.PaginaQueryParam.KEYQCUENTACONTABLE].toString().substr(2,1).Equal('5'))?0:1);
				var ddlUnidadMedida = oRow.cells[3].childNodes[0];
				oPDReqAusPptBE.UndMedAju = ddlUnidadMedida.options[ddlUnidadMedida.selectedIndex].value;
				
				var oCPresupuestoItemDetalleRequerimientos = new Controladora.Presupuesto.CPresupuestoItemDetalleRequerimientos();
				
				var strResult = oCPresupuestoItemDetalleRequerimientos.Modificar(oPDReqAusPptBE);
				var arrResult = strResult.toString().split(';');
				oRow.cells[8].innerText = arrResult[0];
				oRow.cells[9].innerText = arrResult[1];
				//Actualiza los totales por Centro de costo y cuenta seleccionada
				var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
				var oDataTable = new System.Data.DataTable("tblItm");
				with(SIMA.Utilitario.Constantes.GestionFinanciera.PaginaQueryParam){
					oDataTable = oCPresupuestoItemDetalleRequerimientos.ConsultarTotalporItemCentroCostoCuenta(oPagina.Request.Params[KEYQPERIODO],oPagina.Request.Params[KEYQNROCC],oPagina.Request.Params[KEYQCUENTACONTABLE]);
					for (var i=0; i <= oDataTable.Rows.Items.length-1; i++){
						dr = oDataTable.Rows.Items[i];
						if(dr.Item("EOF")==false){
								var oSaldoContableBE = new EntidadesNegocio.Presupuesto.SaldoContableBE(); 
								oSaldoContableBE.Periodo = oPagina.Request.Params[KEYQPERIODO];
								oSaldoContableBE.idMes = dr.Item("IDMES");
								oSaldoContableBE.CuentaContable =  oPagina.Request.Params[KEYQCUENTACONTABLE];
								
								oSaldoContableBE.idCentroOperativo = oPagina.Request.Params[KEYQIDCEOPE];
								oSaldoContableBE.NroCentroOperativo = oPagina.Request.Params[KEYQNROCEOPE];
								
								oSaldoContableBE.idGrupoCentroCosto = oPagina.Request.Params[KEYQIDGRPCC];
								oSaldoContableBE.NroGrupoCentroCosto = oPagina.Request.Params[KEYQNROGRPCC];
								
								oSaldoContableBE.idCentroCosto = oPagina.Request.Params[KEYQIDCC];
								oSaldoContableBE.NroCentroCosto = oPagina.Request.Params[KEYQNROCC];
								
								oSaldoContableBE.MontoPresupuesto = dr.Item("TOT_AJU");
								var str = (new Controladora.Presupuesto.CSaldoContable()).InsertarModificar(oSaldoContableBE)						
						}
					}
				}				
				
			}
		}
		
		function Eliminar(){
			var oGrid = jNet.get("grid");
			var oRow = jNet.get(oGrid.rows[jNet.get("hIdRow").value]);
			var oPDReqAusPptBE = new EntidadesNegocio.Presupuesto.PDReqAusPptBE();
				oPDReqAusPptBE.CodCeo =1;
				oPDReqAusPptBE.NroReq = oRow.attr("NROREQ");	
				oPDReqAusPptBE.CodRcs = oRow.attr("CODRCS");	
				oPDReqAusPptBE.IdEstadoUnisys = "ANU";
				if(window.confirm("Desea Ud. anular este registro ahora?")==true){
					(new Controladora.Presupuesto.CPresupuestoItemDetalleRequerimientos()).Eliminar(oPDReqAusPptBE);
					
				}
		}
		
		function ObtenerIdRow(e){
			jNet.get("hIdRow").value = e.rowIndex;
		}
		
		</script>
	</body>
</HTML>
