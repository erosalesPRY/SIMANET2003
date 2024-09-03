<%@ Register TagPrefix="cc1" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="cc2" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Page language="c#" Codebehind="AdministrarPaquetedeLetras.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.DescuentoLetras.AdministrarPaquetedeLetras" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>
		<script>
			var keyEnter = 13;
			var keyTab= 9;
			var keyUp= 38;
			var keyDown= 40;
			var KEYIDDOCDESCLET ="idDocdescLetra";
			var KEYIDLETDESCTDET ="idLetraDesctDet";

			function CalculoDesembolso(e){
				var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
				if (event.keyCode==keyEnter || event.keyCode==keyDown || event.keyCode==keyTab){
						Desembolso(e);
						var OBJ = ObjetodeDatos(e);
						
						var oLetrasDescuentoBE= new EntidadesNegocio.OperacionesFinancieras.LetrasDescuentoBE();
						oLetrasDescuentoBE.idLetrasDescuento = OBJ.COLECCION.getAttribute("_IdLetrasDescuento");
						oLetrasDescuentoBE.idDescuento = oPagina.Request.Params[KEYIDDOCDESCLET];
						oLetrasDescuentoBE.importeInteres = OBJ.COLECCION.getAttribute("_ImporteInteres");
						oLetrasDescuentoBE.importeGasto = OBJ.COLECCION.getAttribute("_ImporteGasto");
						var Data = (new Controladora.OperacionesFinancieras.LetrasDescuento()).Modificar(oLetrasDescuentoBE).toString().split(';');
						
						$O('nMontoAmortizado').value = Data[0];
						$O('nMontoSaldo').value = Data[1];
						$O('nMontoInteresBCO').value = Data[2];
						$O('nMontoDesembolso').value = Data[3];
				}
			}
			function Desembolso(e){
				var	OBJ = ObjetodeDatos(e);
				if(e.id.toString().indexOf("nImporteInteres") == -1){
					OBJ.COLECCION.setAttribute("_ImporteGasto",e.value);
				}
				else{
					OBJ.COLECCION.setAttribute("_ImporteInteres",e.value);
				}
				var IL = OBJ.COLECCION.getAttribute("_ImporteLetra");
				var II = OBJ.COLECCION.getAttribute("_ImporteInteres");
				var IG = OBJ.COLECCION.getAttribute("_ImporteGasto");
				var ImporteDesembolso = ((parseFloat(IL)-parseFloat(II))-parseFloat(IG));
				//OBJ Desembolso
				var NBoxDesem = OBJ.CONTENEDOR.cells[3].children[0];
				NBoxDesem.innerText=ImporteDesembolso;
			}
			
			function ObjetodeDatos(e){
				var TblRow = e.parentElement.parentElement;
				var Tbl = TblRow.parentElement.parentElement;
				var fAtrib = Tbl.parentElement.parentElement;
				return {FILA:TblRow,CONTENEDOR:Tbl,COLECCION:fAtrib};
			}

			var EstadodeValorActual = false;
			function NewonBlur(){
				NumericBox_IE_ParseAdd(this, ' ', ',', '.');
				if (EstadodeValorActual == true){//Si se ha cambiado algun valor para que vuelva a recalcular
					Desembolso(this);
					EstadodeValorActual = false;
				}
			}
			
			function CuandoCambiaValor(){EstadodeValorActual = true;}
			
			function Handle_OnBlur(){
				var objgrid = document.all["grid"];
				if(objgrid!=undefined){
					for(var i=1;i<= objgrid.rows.length-3;i++){
						var tbl = objgrid.rows[i].cells[4].children[0];
						var objNBox = tbl.rows[0].cells[1].children[0];
						if (objNBox!= undefined){
							objNBox.onblur =NewonBlur;
							objNBox.onchange = CuandoCambiaValor;
						}
						objNBox= undefined;
						objNBox = tbl.rows[0].cells[2].children[0];
						if (objNBox!= undefined){
							objNBox.onblur =NewonBlur;
							objNBox.onchange = CuandoCambiaValor;
						}
					}
				}
			}
		</script>
	</HEAD>
	<body onkeydown="if(event.keyCode==13){return false;}" bottomMargin="0" leftMargin="0"
		topMargin="0" onload="ObtenerHistorial();Handle_OnBlur();" rightMargin="0" onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td width="100%" colSpan="1"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr>
					<td vAlign="top" width="100%" bgColor="#eff7fa"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
				<TR>
					<TD class="RutaPaginaActual" vAlign="top" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Administrar Paquete de Letras en Descuento</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE id="Table3" cellSpacing="1" cellPadding="1" width="708" border="0">
							<TR>
								<TD bgColor="#000080" colSpan="9"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco" Height="16px" Width="304px">DETALLE DE DESCUENTO DE LETRAS</asp:label></TD>
							</TR>
							<TR class="ItemDetalle">
								<TD class="HeaderDetalle" style="WIDTH: 81px"><asp:label id="Label1" runat="server" Width="100px" ToolTip="Nro del Documento de Referencia">Nro Doc:</asp:label></TD>
								<TD><asp:textbox id="txtNroDocumento" runat="server" CssClass="normaldetalle" Width="124px" ReadOnly="True"
										BorderStyle="Groove" MaxLength="15"></asp:textbox></TD>
								<TD style="WIDTH: 11px"></TD>
								<TD class="HeaderDetalle"><asp:label id="Label4" runat="server">Situación :</asp:label></TD>
								<TD><asp:dropdownlist id="ddlbSituacion" runat="server" CssClass="normaldetalle" Width="100%" BorderStyle="None"></asp:dropdownlist></TD>
								<TD style="WIDTH: 50px" colSpan="3"><INPUT id="txtidCuentaBancoCentro" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1"
										name="txtidCuentaBancoCentro" runat="server"></TD>
								<TD></TD>
							</TR>
							<TR class="AlternateItemDetalle">
								<TD class="HeaderDetalle" style="WIDTH: 81px"><asp:label id="Label12" runat="server" Width="48px" ToolTip="Fecha de Desembolso"> FD.</asp:label></TD>
								<TD><ew:calendarpopup id="CalFechaDesembolso" runat="server" CssClass="normaldetalle" Width="72px" BorderStyle="None"
										Enabled="False" ShowGoToToday="True" ControlDisplay="TextBoxImage" Culture="Spanish (Chile)" PadSingleDigits="True"
										NullableLabelText="Seleccione una fecha:" MonthYearPopupCancelText="Cancelar" MonthYearPopupApplyText="Aceptar"
										GoToTodayText="Hoy :" AllowArbitraryText="False" CalendarLocation="Bottom" ImageUrl="../../imagenes/BtPU_Mas.gif">
										<TextboxLabelStyle CssClass="NormalDetalle"></TextboxLabelStyle>
										<WeekdayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
											BackColor="White"></WeekdayStyle>
										<MonthHeaderStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="White"
											BackColor="Navy"></MonthHeaderStyle>
										<OffMonthStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="White"
											BackColor="White"></OffMonthStyle>
										<GoToTodayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Navy"
											BackColor="#F0F0F0"></GoToTodayStyle>
										<TodayDayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Bold="True"
											ForeColor="#335EB4" BackColor="LightSteelBlue"></TodayDayStyle>
										<DayHeaderStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="White"
											BackColor="#335EB4"></DayHeaderStyle>
										<WeekendStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Bold="True"
											ForeColor="IndianRed" BackColor="White"></WeekendStyle>
										<SelectedDateStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="White"
											BackColor="CornflowerBlue"></SelectedDateStyle>
										<ClearDateStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
											BackColor="White"></ClearDateStyle>
										<HolidayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
											BackColor="White"></HolidayStyle>
									</ew:calendarpopup></TD>
								<TD style="WIDTH: 11px"></TD>
								<TD class="HeaderDetalle"><asp:label id="Label11" runat="server">CUENTA BCO :</asp:label></TD>
								<TD><asp:textbox id="txtCuentaBCO" runat="server" CssClass="normaldetalle" Width="151px" ReadOnly="True"
										BorderStyle="Groove"></asp:textbox></TD>
								<TD style="WIDTH: 9px"></TD>
								<TD class="HeaderDetalle"><asp:label id="Label6" runat="server">Moneda :</asp:label></TD>
								<TD><asp:textbox id="txtMoneda" runat="server" CssClass="normaldetalle" Width="100%" BorderStyle="Groove"
										BackColor="AliceBlue"></asp:textbox></TD>
								<TD></TD>
							</TR>
							<TR class="ItemDetalle">
								<TD class="HeaderDetalle" style="WIDTH: 81px"><asp:label id="Label5" runat="server" Width="80px" ToolTip="Centro de Operaciones"> CO:</asp:label></TD>
								<TD><asp:textbox id="txtCentro" runat="server" CssClass="normaldetalle" Width="100%" ReadOnly="True"
										BorderStyle="Groove" BackColor="AliceBlue"></asp:textbox></TD>
								<TD style="WIDTH: 11px"></TD>
								<TD class="HeaderDetalle"><asp:label id="Label13" runat="server" Width="80px" ToolTip="ENTIDAD FINANCIERA ">EF :</asp:label></TD>
								<TD colSpan="4"><asp:textbox id="txtEntidadFinanciera" runat="server" CssClass="normaldetalle" Width="100%" ReadOnly="True"
										BorderStyle="Groove" BackColor="AliceBlue"></asp:textbox></TD>
								<TD></TD>
							</TR>
							<TR class="AlternateItemDetalle">
								<TD class="HeaderDetalle" style="WIDTH: 81px"><asp:label id="Label14" runat="server">tasa de interes %</asp:label></TD>
								<TD><ew:numericbox id="nTasaInteres" runat="server" CssClass="normaldetalle" Width="100%" ReadOnly="True"
										BorderStyle="Groove" MaxLength="8" TextAlign="Right" AutoFormatCurrency="True" DollarSign=" "
										PositiveNumber="True" PlacesBeforeDecimal="3" DecimalPlaces="2">0</ew:numericbox></TD>
								<TD style="WIDTH: 11px"></TD>
								<TD class="HeaderDetalle"><asp:label id="Label19" runat="server">monto interes/Gastos</asp:label></TD>
								<TD><ew:numericbox id="nMontoInteresBCO" runat="server" CssClass="normaldetalle" Width="150px" ReadOnly="True"
										BorderStyle="Groove" MaxLength="15" TextAlign="Right" AutoFormatCurrency="True" DollarSign=" "
										PositiveNumber="True" PlacesBeforeDecimal="8" DecimalPlaces="2">0</ew:numericbox></TD>
								<TD style="WIDTH: 9px"></TD>
								<TD class="HeaderDetalle"><asp:label id="Label15" runat="server" Width="80px" ToolTip="Monto de desembolso :">Monto Desembolso :</asp:label></TD>
								<TD><ew:numericbox id="nMontoDesembolso" runat="server" CssClass="normaldetalle" Width="118px" ReadOnly="True"
										BorderStyle="Groove" MaxLength="15" BackColor="AliceBlue" TextAlign="Right" AutoFormatCurrency="True"
										DollarSign=" " PositiveNumber="True" PlacesBeforeDecimal="8" DecimalPlaces="2">0</ew:numericbox></TD>
								<TD></TD>
							</TR>
							<TR class="ItemDetalle">
								<TD class="HeaderDetalle" style="WIDTH: 81px; HEIGHT: 11px"><asp:label id="Label16" runat="server" Width="112px">monto de letras :</asp:label></TD>
								<TD style="HEIGHT: 11px"><ew:numericbox id="nMontoLetras" runat="server" CssClass="normaldetalle" Width="100%" ReadOnly="True"
										BorderStyle="Groove" MaxLength="15" BackColor="AliceBlue" TextAlign="Right" AutoFormatCurrency="True" DollarSign=" "
										PositiveNumber="True" PlacesBeforeDecimal="8" DecimalPlaces="2">0</ew:numericbox></TD>
								<TD style="WIDTH: 11px; HEIGHT: 11px"></TD>
								<TD class="HeaderDetalle" style="HEIGHT: 11px"><asp:label id="Label20" runat="server" Width="110px">amortizado</asp:label></TD>
								<TD style="HEIGHT: 11px"><ew:numericbox id="nMontoAmortizado" runat="server" CssClass="normaldetalle" Width="150px" ReadOnly="True"
										BorderStyle="Groove" MaxLength="15" BackColor="AliceBlue" TextAlign="Right" AutoFormatCurrency="True" DollarSign=" "
										PositiveNumber="True" PlacesBeforeDecimal="8" DecimalPlaces="2">0</ew:numericbox></TD>
								<TD style="WIDTH: 9px; HEIGHT: 11px"></TD>
								<TD class="HeaderDetalle" style="HEIGHT: 11px"><asp:label id="Label21" runat="server" Width="110px">saldo :</asp:label></TD>
								<TD style="HEIGHT: 11px"><ew:numericbox id="nMontoSaldo" runat="server" CssClass="normaldetalle" Width="118px" ReadOnly="True"
										BorderStyle="Groove" MaxLength="15" BackColor="AliceBlue" TextAlign="Right" AutoFormatCurrency="True" DollarSign=" "
										PositiveNumber="True" PlacesBeforeDecimal="8" DecimalPlaces="2">0</ew:numericbox></TD>
								<TD style="HEIGHT: 11px"></TD>
							</TR>
							<TR class="AlternateItemDetalle">
								<TD class="HeaderDetalle" style="WIDTH: 81px"><asp:label id="Label10" runat="server">Aplicación :</asp:label></TD>
								<TD align="left" colSpan="7"><asp:textbox id="txtObservacion" runat="server" CssClass="normaldetalle" Height="44px" Width="100%"
										ReadOnly="True" BorderStyle="Groove" TextMode="MultiLine"></asp:textbox></TD>
								<TD></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE class="normal" id="Table1" cellSpacing="0" cellPadding="0" width="764" border="0">
							<TR>
								<TD align="center" width="100%" colSpan="3">
									<TABLE style="HEIGHT: 25px" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR bgColor="#f0f0f0">
											<TD style="WIDTH: 12px"><IMG height="22" src="../../imagenes/tab_izq.gif" width="4"></TD>
											<TD style="WIDTH: 78px"></TD>
											<TD style="WIDTH: 19px"></TD>
											<TD style="WIDTH: 31px"></TD>
											<TD style="WIDTH: 115px"><IMG style="WIDTH: 572px; HEIGHT: 8px" height="8" src="../imagenes/spacer.gif" width="572"></TD>
											<TD style="WIDTH: 188px"><asp:imagebutton id="ibtnAgregar" runat="server" ImageUrl="../../imagenes/bt_agregar.gif"></asp:imagebutton></TD>
											<TD style="WIDTH: 187px">
												<asp:ImageButton id="ibtnEliminar" runat="server" ImageUrl="../../imagenes/bt_eliminar.gif"></asp:ImageButton></TD>
											<TD></TD>
											<TD align="right" width="4"><IMG height="22" src="../../imagenes/tab_der.gif" width="4"></TD>
										</TR>
									</TABLE>
									<cc2:datagridweb id="grid" runat="server" Width="765px" ShowFooter="True" RowHighlightColor="#E0E0E0"
										AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True" PageSize="7">
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
										<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO">
												<HeaderStyle Width="1%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="NroDocumento" SortExpression="NroDocumento" HeaderText="DOCUMENTO">
												<HeaderStyle Width="5%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="FechaVencimiento" HeaderText="VENCE">
												<HeaderStyle Width="5%"></HeaderStyle>
												<ItemStyle Wrap="False"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="RAZON SOCIAL">
												<HeaderStyle Width="40%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="IMPORTE">
												<HeaderStyle Width="40%"></HeaderStyle>
												<HeaderTemplate>
													<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" align="left" border="0">
														<TR>
															<TD style="BORDER-BOTTOM: #cccccc 1px solid" align="center" colSpan="4">
																<asp:Label id="Label18" runat="server" CssClass="Headergrilla" BorderStyle="None">IMPORTE</asp:Label></TD>
														</TR>
														<TR>
															<TD align="center" width="25%">
																<asp:Label id="Label22" runat="server" CssClass="Headergrilla" BorderStyle="None">LETRA</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" align="center" width="25%">
																<asp:Label id="Label23" runat="server" CssClass="Headergrilla" BorderStyle="None">INTERES</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" align="center" width="25%">
																<asp:Label id="Label2" runat="server" CssClass="Headergrilla" BorderStyle="None">GASTO</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" align="center" width="25%">
																<asp:Label id="Label24" runat="server" CssClass="Headergrilla" BorderStyle="None">ABONO</asp:Label></TD>
														</TR>
													</TABLE>
												</HeaderTemplate>
												<ItemTemplate>
													<TABLE id="Table9" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
														border="0">
														<TR>
															<TD align="right" width="25%">
																<asp:Label id="lblImporteLetra" runat="server" CssClass="normaldetalle">0.00</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" align="right" width="25%">
																<ew:numericbox id="nImporteInteres" runat="server" CssClass="normaldetalle" Width="100%" MaxLength="18"
																	BackColor="Transparent" DecimalPlaces="3" PlacesBeforeDecimal="15" DollarSign=" " AutoFormatCurrency="True"
																	TextAlign="Right" BorderColor="Transparent"></ew:numericbox></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" align="right" width="25%">
																<ew:numericbox id="nImporteGasto" runat="server" CssClass="normaldetalle" Width="100%" MaxLength="18"
																	BackColor="Transparent" DecimalPlaces="3" PlacesBeforeDecimal="15" DollarSign=" " AutoFormatCurrency="True"
																	TextAlign="Right" BorderColor="Transparent"></ew:numericbox></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" align="right" width="25%">
																<asp:Label id="lblImporteAbonado" runat="server" CssClass="normaldetalle">0.00</asp:Label></TD>
														</TR>
													</TABLE>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn DataField="Situacion" HeaderText="SITUACION">
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
										</Columns>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
									</cc2:datagridweb></TD>
							</TR>
							<TR>
								<TD align="center" width="100%" colSpan="3"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
							</TR>
							<TR>
								<TD align="left" width="100%" colSpan="3"><IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
							</TR>
						</TABLE>
						<INPUT id="hidLetraDescuento" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1"
							name="hGridPaginaSort" runat="server"><INPUT id="hGridPaginaSort" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="hGridPaginaSort"
							runat="server" DESIGNTIMEDRAGDROP="133"><INPUT id="hGridPagina" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" value="0"
							name="hGridPagina" runat="server" DESIGNTIMEDRAGDROP="56">
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%"></TD>
				</TR>
			</table>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
