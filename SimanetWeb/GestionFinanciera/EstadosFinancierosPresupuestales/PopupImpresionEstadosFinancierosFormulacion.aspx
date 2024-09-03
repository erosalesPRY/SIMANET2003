<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="ParametroContable" Src="../../ControlesUsuario/GestionFinanciera/ParametroContable.ascx" %>
<%@ Page language="c#" Codebehind="PopupImpresionEstadosFinancierosFormulacion.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancierosPresupuestales.PopupImpresionEstadosFinancierosFormulacion" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<LINK href="../../Stylos/Temas.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js">  </SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial2();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD class="TituloPrincipal" style="HEIGHT: 15px" align="center" colSpan="5"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal"></asp:label></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="5">
						<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="300" border="0">
							<TR>
								<TD>
									<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR bgColor="#f0f0f0">
											<TD style="WIDTH: 9px"><IMG height="22" src="../../imagenes/tab_izq.gif" width="4"></TD>
											<TD style="WIDTH: 70px"><asp:label id="Label3" runat="server" CssClass="TituloPrincipalBlanco" ForeColor="Navy" Width="65px"
													Font-Bold="True">PERIODO :</asp:label></TD>
											<TD style="WIDTH: 1px" vAlign="middle"><asp:label id="lblPeriodo" runat="server" CssClass="TituloPrincipalBlanco" ForeColor="Navy"
													Width="32px" Font-Bold="True">2005</asp:label></TD>
											<TD align="center" width="100%"><asp:label id="Label1" runat="server" CssClass="TituloPrincipalBlanco" ForeColor="Navy" Width="363px"
													Font-Bold="True">EN MILES DE NUEVOS SOLES</asp:label></TD>
											<td></td>
											<TD align="right" width="4"><IMG height="22" src="../../imagenes/tab_der.gif" width="4"></TD>
										</TR>
									</TABLE>
									<cc1:datagridweb id="grid" runat="server" Width="750px" DataKeyField="IdRubro" RowHighlightColor="#E0E0E0"
										AutoGenerateColumns="False">
										<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn DataField="Concepto" SortExpression="Concepto" HeaderText="CONCEPTO">
												<HeaderStyle HorizontalAlign="Center" Width="1%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="PEnero" SortExpression="PEnero" HeaderText="ENE">
												<HeaderStyle HorizontalAlign="Center" Width="5.3%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="PFebrero" SortExpression="PFebrero" HeaderText="FEB">
												<HeaderStyle Width="5.3%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="PMarzo" SortExpression="PMarzo" HeaderText="MAR">
												<HeaderStyle Width="5.3%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="PAbril" SortExpression="PAbril" HeaderText="ABR">
												<HeaderStyle Width="5.3%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="PMayo" SortExpression="PMayo" HeaderText="MAY">
												<HeaderStyle Width="5.3%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="PJunio" SortExpression="PJunio" HeaderText="JUN">
												<HeaderStyle Width="5.3%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="PJulio" SortExpression="PJulio" HeaderText="JUL">
												<HeaderStyle Width="5.3%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="PAgosto" SortExpression="PAgosto" HeaderText="AGO">
												<HeaderStyle Width="5.3%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="PSetiembre" SortExpression="PSetiembre" HeaderText="SET">
												<HeaderStyle Width="5.3%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="POctubre" SortExpression="POctubre" HeaderText="OCT">
												<HeaderStyle Width="5.3%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="PNoviembre" SortExpression="PNoviembre" HeaderText="NOV">
												<HeaderStyle Width="5.3%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="PDiciembre" SortExpression="PDiciembre" HeaderText="DIC">
												<HeaderStyle Width="5.3%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="TOTAL">
												<HeaderStyle Width="5.3%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
										</Columns>
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD colSpan="5"><INPUT id="objHistorial" type="hidden" name="objHistorial"></TD>
				</TR>
			</TABLE>
			<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			</SCRIPT>
		</form>
	</body>
</HTML>
