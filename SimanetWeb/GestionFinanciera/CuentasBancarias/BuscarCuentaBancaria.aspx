<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="cc2" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Page language="c#" Codebehind="BuscarCuentaBancaria.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.CuentasBancarias.BuscarCuentaBancaria" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="650" align="center" border="0">
				<TR>
					<TD class="TituloPrincipal" vAlign="top" colSpan="3"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal"> BUSQUEDA DE CUENTAS BANCARIAS</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center">
						<TABLE class="tabla" id="Table6" cellSpacing="0" cellPadding="0" width="645" bgColor="#f5f5f5"
							border="0" style="WIDTH: 645px; HEIGHT: 60px">
							<TR bgColor="#ffffff">
								<TD class="TitFiltros"></TD>
								<TD class="combos"></TD>
								<TD class="combos"></TD>
								<TD class="combos"></TD>
							</TR>
							<TR>
								<TD class="TitFiltros" align="center" style="HEIGHT: 18px"></TD>
								<TD class="combos" align="left" style="HEIGHT: 18px"><asp:label id="lblApellidoPaterno" runat="server" CssClass="normal">Cuenta Bancaria</asp:label></TD>
								<TD class="combos" align="center" style="HEIGHT: 18px"></TD>
								<TD class="combos" style="HEIGHT: 18px"></TD>
							</TR>
							<TR>
								<TD class="TitFiltros"></TD>
								<TD class="combos"><asp:textbox id="txtCuentaBCOB" runat="server" Width="551px" MaxLength="15" CssClass="InputFind"></asp:textbox></TD>
								<TD class="combos"></TD>
								<TD class="combos"><asp:imagebutton id="btnBuscar" runat="server" Width="87px" ImageUrl="../../imagenes/bt_Buscar.GIF"
										Height="22px"></asp:imagebutton></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<tr>
					<td vAlign="top">
						<TABLE class="normal" id="Table1" cellSpacing="0" cellPadding="0" width="650" align="center"
							border="0">
							<TR>
								<TD vAlign="top" align="center" colSpan="3"><cc1:datagridweb id="grid" runat="server" Width="650px" PageSize="7" RowPositionEnabled="False" RowHighlightColor="#E0E0E0"
										AllowPaging="True" AutoGenerateColumns="False" AllowSorting="True">
										<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn DataField="NroCuentaBancaria" SortExpression="NroCuentaBancaria" HeaderText="CUENTA BANCARIA">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Centro" SortExpression="Centro" HeaderText="CO">
												<HeaderStyle Width="2%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Moneda" SortExpression="Moneda" HeaderText="MONEDA">
												<HeaderStyle Width="2%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="TipoCtaBco" SortExpression="TipoCtaBco" HeaderText="TIPO CTA">
												<HeaderStyle Width="2%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="RazonSocial" SortExpression="RazonSocial" HeaderText="ENTIDAD FINANCIERA">
												<HeaderStyle Width="20%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
										</Columns>
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" DESIGNTIMEDRAGDROP="56"></asp:label></TD>
							</TR>
						</TABLE>
						<INPUT id="txtidCuentaBancoCentro" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1"
							runat="server" DESIGNTIMEDRAGDROP="298"><INPUT id="txtCuentaBCO" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="txtCuentaBCO"
							runat="server" DESIGNTIMEDRAGDROP="299"><INPUT id="txtMoneda" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="txtMoneda"
							runat="server" DESIGNTIMEDRAGDROP="300"><INPUT id="txtCentro" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="txtCentro"
							runat="server" DESIGNTIMEDRAGDROP="301"><INPUT id="txtEntidadFinanciera" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1"
							name="txtEntidadFinanciera" runat="server"> <INPUT id="txtTipoCtaBCO" style="WIDTH: 40px; HEIGHT: 22px" type="hidden" size="1" name="txtCentro"
							runat="server"> <INPUT id="hGridPagina" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" value="0"
							name="hGridPagina" runat="server"><INPUT id="hOrdenGrilla" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="hOrdenGrilla"
							runat="server">
					</td>
				</tr>
				<tr>
					<td vAlign="top">
						<TABLE id="Table8" width="650" align="center" border="0">
							<TR>
								<TD align="center">
									<IMG id="ibtnAceptar" style="CURSOR: hand" onclick="PonerTexto();" alt="" src="../../imagenes/bt_aceptar.gif">&nbsp;&nbsp;&nbsp;
									<IMG id="ibtnCancelar" style="CURSOR: hand" onclick="window.close();" alt="" src="../../imagenes/bt_cancelar.gif">
									<SPAN class="normal"></SPAN>
								</TD>
							</TR>
						</TABLE>
						&nbsp;
					</td>
				</tr>
			</TABLE>
			<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			
			function PonerTexto()
			{
				if(document.forms[0].txtidCuentaBancoCentro.value.length >0)
				{
					opener.document.forms[0].txtidCuentaBancoCentro.value =document.forms[0].txtidCuentaBancoCentro.value;
					opener.document.forms[0].txtCuentaBCO.value =document.forms[0].txtCuentaBCO.value;
					opener.document.forms[0].txtMoneda.value =document.forms[0].txtMoneda.value;
					opener.document.forms[0].txtCentro.value =document.forms[0].txtCentro.value;
					opener.document.forms[0].txtEntidadFinanciera.value =document.forms[0].txtEntidadFinanciera.value;
					window.close();
				}
				else
				{
					Window.alert("No se ha seleccionado registro");
				}
			} 
			</SCRIPT>
		</form>
	</body>
</HTML>
