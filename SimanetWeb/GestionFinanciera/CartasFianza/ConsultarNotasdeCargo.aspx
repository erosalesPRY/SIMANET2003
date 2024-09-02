<%@ Page language="c#" Codebehind="ConsultarNotasdeCargo.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.CartasFianza.ConsultarNotasdeCargo" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
</HEAD>
	<body oncontextmenu="return false" bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0"
		onload="ObtenerHistorial();" onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td colSpan="1" width="100%"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr>
					<td vAlign="top" width="100%" bgColor="#eff7fa"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
				<TR>
					<TD class="RutaPaginaActual" vAlign="top" align="left" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestion Financiera></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Consultar Nota de Cargo</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="570" align="center" border="0">
							<TR>
								<TD>
									<TABLE id="Table3" style="WIDTH: 741px; HEIGHT: 80px" cellSpacing="0" cellPadding="0" width="741"
										align="left" border="0">
										<TR>
											<TD style="WIDTH: 554px; HEIGHT: 20px" bgColor="#000080" colSpan="5">
												<asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco">DETALLE CARTA FIANZA</asp:label></TD>
											<TD style="WIDTH: 95px; HEIGHT: 20px" bgColor="#000080"></TD>
											<TD style="WIDTH: 95px; HEIGHT: 20px" bgColor="#000080"></TD>
										</TR>
										<TR class="ItemDetalle">
											<TD class="headerDetalle">
												<asp:label id="Label2" runat="server" Width="78px">Nro Fianza:</asp:label></TD>
											<TD width="50" align="left">
												<asp:textbox id="txtNroFza" runat="server" CssClass="normaldetalle" BorderStyle="Groove" ReadOnly="True"></asp:textbox></TD>
											<TD></TD>
											<TD class="headerDetalle">
												<asp:label id="Label6" runat="server">Situación :</asp:label></TD>
											<TD>
												<asp:textbox id="txtSituacion" runat="server" ReadOnly="True" BorderStyle="Groove" Width="164px"
													CssClass="normaldetalle"></asp:textbox></TD>
											<TD class="headerDetalle">
												<asp:label id="Label3" runat="server">Moneda:</asp:label></TD>
											<TD>
												<asp:textbox id="txtNombreMoneda" runat="server" CssClass="normaldetalle" Width="108px" BorderStyle="Groove"
													ReadOnly="True"></asp:textbox></TD>
										</TR>
										<TR class="AlternateItemDetalle">
											<TD class="headerDetalle"><asp:label id="Label1" runat="server" Width="104px">Fecha Apertura:</asp:label></TD>
											<TD width="50" align="left"><asp:textbox id="txtFechaApertura" runat="server" CssClass="normaldetalle" BorderStyle="Groove"
													ReadOnly="True"></asp:textbox></TD>
											<TD></TD>
											<TD class="headerDetalle"><asp:label id="Label4" runat="server" Width="137px">Fecha Vencimiento:</asp:label></TD>
											<TD align="left"><asp:textbox id="txtFechaVencimiento" runat="server" CssClass="normaldetalle" Width="162px" BorderStyle="Groove"
													ReadOnly="True"></asp:textbox></TD>
											<TD class="headerDetalle"><asp:label id="Label5" runat="server">Monto:</asp:label></TD>
											<TD align="left"><asp:textbox id="txtMontoFza" runat="server" CssClass="normaldetalle" Width="108px" BorderStyle="Groove"
													ReadOnly="True"></asp:textbox></TD>
										</TR>
										<TR class="ItemDetalle">
											<TD class="headerDetalle"><asp:label id="Label7" runat="server" Width="117px">Centro Operativo :</asp:label></TD>
											<TD width="50"><asp:textbox id="txtCentro" runat="server" CssClass="normaldetalle" Width="150px" BorderStyle="Groove"
													ReadOnly="True"></asp:textbox></TD>
											<TD></TD>
											<TD class="headerDetalle"><asp:label id="Label8" runat="server">Banco:</asp:label></TD>
											<TD colSpan="3"><asp:textbox id="txtBanco" runat="server" CssClass="normaldetalle" Width="100%" BorderStyle="Groove"
													ReadOnly="True"></asp:textbox></TD>
										</TR>
										<TR>
											<TD bgColor="#000080" colSpan="7">
												<asp:label id="Label9" runat="server" CssClass="TituloPrincipalBlanco">NOTAS DE CARGO</asp:label></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD>
									<TABLE style="HEIGHT: 22px" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR bgColor="#f0f0f0">
											<TD><IMG height="22" src="../../imagenes/tab_izq.gif" width="4"></TD>
											<TD style="WIDTH: 109px"><IMG style="WIDTH: 400px; HEIGHT: 8px" height="8" src="../imagenes/spacer.gif" width="598"></TD>
											<TD style="WIDTH: 34px"></TD>
											<TD style="WIDTH: 501px"></TD>
											<TD></TD>
											<TD>
												<asp:imagebutton id="imgbtnImportar" runat="server" ImageUrl="../../imagenes/btnImportaciones/btnImportarCartaFianzaNotadeCargo.gif"></asp:imagebutton></TD>
											<TD align="right" width="4"><IMG height="22" src="../../imagenes/tab_der.gif" width="4"></TD>
										</TR>
									</TABLE>
									<cc1:datagridweb id="grid" runat="server" Width="100%" ShowFooter="True" AllowPaging="True" AllowSorting="True"
										AutoGenerateColumns="False" RowHighlightColor="#E0E0E0" PageSize="7">
										<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn DataField="Fecha" SortExpression="Fecha" HeaderText="FECHA">
												<HeaderStyle HorizontalAlign="Center" Width="12%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Motivo" SortExpression="Motivo" HeaderText="CONCEPTO">
												<HeaderStyle Width="40%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Moneda" SortExpression="Moneda" HeaderText="M">
												<HeaderStyle Width="5%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="MontoNota" SortExpression="MontoNota" HeaderText="MONTO">
												<HeaderStyle Width="15%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle HorizontalAlign="Right"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="TipoCambio" SortExpression="TipoCambio" HeaderText="CAMBIO">
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="EnDolares" SortExpression="EnDolares" HeaderText="MONTO DOLARIZADO">
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
										</Columns>
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb></TD>
							</TR>
							<TR>
								<TD><IMG id=ibtnAtras style="CURSOR: hand" 
            onclick=HistorialIrAtras(); alt="" 
            src="../../imagenes/atras.gif"><INPUT id="hGridPagina" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" value="0"
										name="hGridPagina" runat="server"><INPUT id="hGridPaginaSort" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="hGridPagina"
										runat="server"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%"><IMG style="WIDTH: 160px; HEIGHT: 8px" height="8" src="../../imagenes/spacer.gif" width="160"></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
				</TR>
			</table>
			&nbsp;
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
