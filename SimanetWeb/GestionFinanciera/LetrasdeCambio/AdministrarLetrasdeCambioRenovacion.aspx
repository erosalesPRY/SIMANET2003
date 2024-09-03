<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Page language="c#" Codebehind="AdministrarLetrasdeCambioRenovacion.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.LetrasdeCambio.AdministrarLetrasdeCambioRenovacion" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>
		<script src="/SimaNetWeb/js/date.js" type="text/javascript"></script>
		<script>
			var keyEnter = 13;
			function CalcularVencimiento(Fecha,id){
				var PartNombre = id.toString().replace('cFechaRenovacion','');
					var oNDiasPlazo = $O(PartNombre + 'NDiasPlazo');
					var arrFecha = Fecha.toString().split('/');
					var d1 = new Date(parseInt(arrFecha[2],10), parseInt(arrFecha[0]-1,10),parseInt(arrFecha[1],10)); 
					var d2 = d1;
					var olblFechaVencimiento = $O(PartNombre +'lblFechaVencimiento');
					olblFechaVencimiento.innerText =d2.add(parseInt(oNDiasPlazo.value,10)).days().toString('dd-MM-yyyy'); 
			}
			
			function AsignarEvento(){
				var oDataGrid = $O('grid');
				for(var i=1;i<=oDataGrid.rows.length-1;i++){
					var e= oDataGrid.rows[i].cells[2].children[0];
					e.onblur=function(){
						NumericBox_IE_ParseAdd(this, ' ', ',', '.');
						event.keyCode = keyEnter;
						this.onkeydown();
					}
					
					e.onkeydown = function(){
						if(event.keyCode==keyEnter){
							var PartNombre = this.id.toString().replace('NDiasPlazo','');
							var oCalFechaVencimiento = $O(PartNombre + 'lblFechaVencimiento');
							var oCalFechaInicio = $O(PartNombre + 'cFechaRenovacion');
							var arrFecha = oCalFechaInicio.value.toString().split('-');
							var d1 = new Date(parseInt(arrFecha[2],10),  parseInt((arrFecha[1]-1),10),parseInt(arrFecha[0],10)); 
							var d2 = d1;
							oCalFechaVencimiento.innerText =d2.add(parseInt(this.value,10)).days().toString('dd-MM-yyyy'); 
							var onTasaInteres = $O(PartNombre + 'nTasaInteres');
							onTasaInteres.focus();
						}
					}
					//Tasa de Interes
					var e2= oDataGrid.rows[i].cells[4].children[0];
					e2.onkeydown = function(){
						if(event.keyCode==keyEnter){
							var PartNombre = this.id.toString().replace('nTasaInteres','');
							var onMonto = $O(PartNombre + 'nMonto');
							onMonto.focus();
						}
					}
				}
				var onMontoCancelado = $O("nMontoCancelado");
				onMontoCancelado.onblur=function(){
					NumericBox_IE_ParseAdd(this, ' ', ',', '.');
					event.keyCode = keyEnter;
					this.onkeydown();
				}
				onMontoCancelado.onkeydown = function(){
					if(event.keyCode==keyEnter){
						var olblMontoLetra = $O("lblMontoLetra");
						var olblSado = $O("lblSado");
						var MntLetra = olblMontoLetra.innerText.toString().replace(" ","")
																		  .replace(" ","");
						olblSado.innerText = new SIMA.Numero(parseFloat(MntLetra)- parseFloat(this.value)).toString(2,true,' ');
					}
				}
			}
			/*-------------------------------------------------------------------*/
			function AlmacenarRenovacion(){
				var KEYIDDOCLET ="idDocLetra";
				var KEYIDLETRENOVADA ="idLetraRenovada";
				var oPagina = new SIMA.Utilitario.Helper.General.Pagina()
				var oDataGrid = $O('grid');
				var strTrama ="";
				for(var i=1;i<=oDataGrid.rows.length-1;i++){
					var objFecha = oDataGrid.rows[i].cells[1].children[0].children[0];
					var objNroDias= oDataGrid.rows[i].cells[2].children[0];
					var objTasaInteres= oDataGrid.rows[i].cells[4].children[0];
					var objMntLetra= oDataGrid.rows[i].cells[5].children[0];
					if((parseFloat(objTasaInteres.value)>0)&&(parseFloat(objMntLetra.value)>0)){
						with(SIMA.Utilitario.Constantes.General.Caracter){
							strTrama += objFecha.value
										+ PuntoyComa
										+ objNroDias.value 
										+ PuntoyComa
										+ objTasaInteres.value 
										+ PuntoyComa
										+ objMntLetra.value + SignoNumeral;
						}
					}
				}
				$O("hRegRenovaciones").value = ((strTrama.length>0)?strTrama.substring(0,strTrama.length-1):"");
			}
		</script>
	</HEAD>
	<body oncontextmenu="return false" onkeydown="if (event.keyCode==13 || event.keyCode==9)return false"
		bottomMargin="0" topMargin="10" onload="AsignarEvento();">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="right" border="0">
				<TR>
					<TD class="RutaPaginaActual" vAlign="top" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera> Letras de Cambio></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Administrar Renovación</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%"></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE id="Table1" style="WIDTH: 560px; HEIGHT: 29px" cellSpacing="1" cellPadding="1" width="560"
							align="left" border="0">
							<TR>
								<TD class="HeaderDetalle" style="WIDTH: 123px"><asp:label id="Label1" runat="server">Importe de la Letra:</asp:label></TD>
								<TD style="WIDTH: 72px"><asp:label id="lblMontoLetra" runat="server" CssClass="normaldetalle" Width="100%">0.00</asp:label></TD>
								<TD class="HeaderDetalle" style="WIDTH: 125px"><asp:label id="Label2" runat="server">Importe a Cancelar:</asp:label></TD>
								<TD style="WIDTH: 82px"><ew:numericbox id="nMontoCancelado" runat="server" CssClass="normaldetalle" Width="100%" MaxLength="15"
										TextAlign="Right" AutoFormatCurrency="True" DollarSign=" " PositiveNumber="True" PlacesBeforeDecimal="8" DecimalPlaces="2">0</ew:numericbox></TD>
								<TD class="HeaderDetalle" style="WIDTH: 40px"><asp:label id="Label3" runat="server">Saldo:</asp:label></TD>
								<TD><asp:label id="lblSado" runat="server" CssClass="normaldetalle" Width="100%">0.00</asp:label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD id="TD1" vAlign="top" align="center" width="100%"><cc1:datagridweb id="grid" runat="server" Width="100%" PageSize="7" AutoGenerateColumns="False" RowHighlightColor="#E0E0E0">
							<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
							<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
							<FooterStyle CssClass="FooterGrilla"></FooterStyle>
							<ItemStyle CssClass="ItemGrilla"></ItemStyle>
							<Columns>
								<asp:BoundColumn DataField="Nro" HeaderText="NRO">
									<HeaderStyle Width="1%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="FECHA">
									<HeaderStyle Width="10%"></HeaderStyle>
									<ItemTemplate>
										<ew:calendarpopup id="cFechaRenovacion" runat="server" CssClass="normaldetalle" Width="72px" ImageUrl="../../imagenes/BtPU_Mas.gif"
											CalendarLocation="Bottom" AllowArbitraryText="False" GoToTodayText="Hoy :" MonthYearPopupApplyText="Aceptar"
											MonthYearPopupCancelText="Cancelar" NullableLabelText="Seleccione una fecha:" Culture="Spanish (Chile)"
											ControlDisplay="TextBoxImage" ShowGoToToday="True" JavascriptOnChangeFunction="CalcularVencimiento">
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
												ForeColor="#335EB4" BackColor="#C0C0FF"></TodayDayStyle>
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
										</ew:calendarpopup>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="NRO DIAS">
									<HeaderStyle Width="2%"></HeaderStyle>
									<ItemTemplate>
										<ew:numericbox id="NDiasPlazo" runat="server" CssClass="normaldetalle" Width="32px" MaxLength="8"
											TextAlign="Right" AutoFormatCurrency="True" DollarSign=" " PositiveNumber="True" PlacesBeforeDecimal="3"
											DecimalPlaces="2" BackColor="White">0</ew:numericbox>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="VENCE">
									<HeaderStyle Width="10%"></HeaderStyle>
									<ItemTemplate>
										<asp:Label id="lblFechaVencimiento" runat="server" CssClass="normaldetalle">00-00-2008</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="INTERES">
									<HeaderStyle Width="10%"></HeaderStyle>
									<ItemTemplate>
										<ew:numericbox id="nTasaInteres" runat="server" CssClass="normaldetalle" Width="83px" MaxLength="8"
											TextAlign="Right" AutoFormatCurrency="True" DollarSign=" " PositiveNumber="True" PlacesBeforeDecimal="2"
											DecimalPlaces="2">0</ew:numericbox>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="MONTO">
									<HeaderStyle Width="10%"></HeaderStyle>
									<ItemTemplate>
										<ew:numericbox id="nMonto" runat="server" CssClass="normaldetalle" Width="100%" DecimalPlaces="2"
											PlacesBeforeDecimal="8" PositiveNumber="True" DollarSign=" " AutoFormatCurrency="True" TextAlign="Right"
											MaxLength="15">0</ew:numericbox>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
							<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
						</cc1:datagridweb><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="right" width="100%"><INPUT id="hRegRenovaciones" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="hidLetra"
							runat="server"><INPUT id="hidLetra" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="hidLetra"
							runat="server">
						<asp:imagebutton id="ibtnAceptar" runat="server" ImageUrl="../../imagenes/bt_aceptar.gif"></asp:imagebutton></TD>
				</TR>
			</table>
			&nbsp;
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
