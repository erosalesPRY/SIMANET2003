<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Page language="c#" Codebehind="ConsultarGastosCostosPorCO_Ano.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.DirectorioEjecutivo.Proyectos.ConsultarGastosCostosPorCO_Ano" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../../styles.css">
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>
	</HEAD>
	<body onkeydown="if (event.keyCode==13 || event.keyCode==9)return false" onunload="SubirHistorial();"
		onload="ObtenerHistorial();" bottomMargin="0" leftMargin="0" rightMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<table border="0" cellSpacing="0" cellPadding="0" width="100%" align="center">
				<tr>
					<td width="100%"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr>
					<td bgColor="#eff7fa" vAlign="top" width="100%"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
				<TR>
					<TD class="RutaPaginaActual" vAlign="top" width="100%"><asp:label style="Z-INDEX: 0" id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Financiera ></asp:label><asp:label style="Z-INDEX: 0" id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Consultar Gastos y Costos Por Años</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%" align="center">
						<TABLE id="Table1" class="normal" border="0" cellSpacing="0" cellPadding="0" width="100%"
							DESIGNTIMEDRAGDROP="26">
							<TR>
								<TD width="100%" colSpan="3" align="center">
									<TABLE border="0" cellSpacing="0" cellPadding="0" width="100%">
										<TR bgColor="#f0f0f0">
											<TD align="center">
												<asp:label style="Z-INDEX: 0" id="lblPrincipal" runat="server" CssClass="TituloPrincipalAzul">COSTOS DIRECTOS</asp:label></TD>
											<TD></TD>
											<TD>&nbsp;</TD>
											<TD align="right"></TD>
											<TD width="4" align="right"></TD>
										</TR>
										<TR>
											<TD>
												<asp:label style="Z-INDEX: 0" id="lblTitulo" runat="server" CssClass="SubTituloNegrita">COSTOS DIRECTOS</asp:label>
											</TD>
											<TD></TD>
											<TD></TD>
											<TD align="right"></TD>
											<TD width="4" align="right"></TD>
										</TR>
									</TABLE>
									<cc1:datagridweb id="grid" runat="server" PageSize="15" ShowFooter="True" Width="100%" RowHighlightColor="#E0E0E0"
										AutoGenerateColumns="False" AllowSorting="True">
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
										<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
										<FooterStyle Font-Bold="True" CssClass="footerGrilla"></FooterStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<Columns>
											<asp:BoundColumn DataField="descripcion" SortExpression="descripcion">
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="ANO1" SortExpression="ANO1" HeaderText="ANO1" DataFormatString="{0:# ### ### ##0.00}">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
												<FooterStyle HorizontalAlign="Right"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="ANO2" SortExpression="ANO2" HeaderText="ANO2" DataFormatString="{0:# ### ### ##0.00}">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
												<FooterStyle HorizontalAlign="Right"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="ANO3" SortExpression="ANO3" HeaderText="ANO3" DataFormatString="{0:# ### ### ##0.00}">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
												<FooterStyle HorizontalAlign="Right"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="ANO4" SortExpression="ANO4" HeaderText="ANO4" DataFormatString="{0:# ### ### ##0.00}">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
												<FooterStyle HorizontalAlign="Right"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="ANO5" SortExpression="ANO5" HeaderText="ANO5" DataFormatString="{0:# ### ### ##0.00}">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
												<FooterStyle HorizontalAlign="Right"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="ANO6" SortExpression="ANO6" HeaderText="ANO6" DataFormatString="{0:# ### ### ##0.00}">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
												<FooterStyle HorizontalAlign="Right"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="ANO7" SortExpression="ANO7" HeaderText="ANO7" DataFormatString="{0:# ### ### ##0.00}">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
												<FooterStyle HorizontalAlign="Right"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="ANO8" SortExpression="ANO8" HeaderText="ANO8" DataFormatString="{0:# ### ### ##0.00}">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
												<FooterStyle HorizontalAlign="Right"></FooterStyle>
											</asp:BoundColumn>
										</Columns>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
									</cc1:datagridweb><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
							</TR>
							<TR>
								<TD width="100%" colSpan="3" align="left">
									<asp:label style="Z-INDEX: 0" id="Label1" runat="server" CssClass="SubTituloNegrita">COSTOS INDIRECTOS</asp:label></TD>
							</TR>
							<TR>
								<TD width="100%" colSpan="3" align="center">
									<cc1:datagridweb style="Z-INDEX: 0" id="grid1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
										RowHighlightColor="#E0E0E0" Width="100%" ShowFooter="True" PageSize="15">
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
										<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
										<FooterStyle Font-Bold="True" CssClass="footerGrilla"></FooterStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<Columns>
											<asp:BoundColumn DataField="descripcion" SortExpression="descripcion">
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="ANO1" SortExpression="ANO1" HeaderText="ANO1" DataFormatString="{0:# ### ### ##0.00}">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
												<FooterStyle HorizontalAlign="Right"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="ANO2" SortExpression="ANO2" HeaderText="ANO2" DataFormatString="{0:# ### ### ##0.00}">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
												<FooterStyle HorizontalAlign="Right"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="ANO3" SortExpression="ANO3" HeaderText="ANO3" DataFormatString="{0:# ### ### ##0.00}">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
												<FooterStyle HorizontalAlign="Right"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="ANO4" SortExpression="ANO4" HeaderText="ANO4" DataFormatString="{0:# ### ### ##0.00}">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
												<FooterStyle HorizontalAlign="Right"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="ANO5" SortExpression="ANO5" HeaderText="ANO5" DataFormatString="{0:# ### ### ##0.00}">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
												<FooterStyle HorizontalAlign="Right"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="ANO6" SortExpression="ANO6" HeaderText="ANO6" DataFormatString="{0:# ### ### ##0.00}">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
												<FooterStyle HorizontalAlign="Right"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="ANO7" SortExpression="ANO7" HeaderText="ANO7" DataFormatString="{0:# ### ### ##0.00}">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
												<FooterStyle HorizontalAlign="Right"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="ANO8" SortExpression="ANO8" HeaderText="ANO8" DataFormatString="{0:# ### ### ##0.00}">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
												<FooterStyle HorizontalAlign="Right"></FooterStyle>
											</asp:BoundColumn>
										</Columns>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
									</cc1:datagridweb></TD>
							</TR>
							<TR>
								<TD width="100%" colSpan="3" align="center">
									<asp:label style="Z-INDEX: 0" id="lblResultado1" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
							</TR>
							<TR>
								<TD width="100%" colSpan="3" align="left">
									<asp:label style="Z-INDEX: 0" id="Label2" runat="server" CssClass="SubTituloNegrita">GASTOS ADMINISTRATIVOS SIMA PERU</asp:label></TD>
							</TR>
							<TR>
								<TD width="100%" colSpan="3" align="center">
									<cc1:datagridweb style="Z-INDEX: 0" id="grid2" runat="server" AllowSorting="True" AutoGenerateColumns="False"
										RowHighlightColor="#E0E0E0" Width="100%" ShowFooter="True" PageSize="15">
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
										<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
										<FooterStyle Font-Bold="True" CssClass="footerGrilla"></FooterStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<Columns>
											<asp:BoundColumn DataField="descripcion" SortExpression="descripcion">
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="ANO1" SortExpression="ANO1" HeaderText="ANO1" DataFormatString="{0:# ### ### ##0.00}">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
												<FooterStyle HorizontalAlign="Right"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="ANO2" SortExpression="ANO2" HeaderText="ANO2" DataFormatString="{0:# ### ### ##0.00}">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
												<FooterStyle HorizontalAlign="Right"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="ANO3" SortExpression="ANO3" HeaderText="ANO3" DataFormatString="{0:# ### ### ##0.00}">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
												<FooterStyle HorizontalAlign="Right"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="ANO4" SortExpression="ANO4" HeaderText="ANO4" DataFormatString="{0:# ### ### ##0.00}">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
												<FooterStyle HorizontalAlign="Right"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="ANO5" SortExpression="ANO5" HeaderText="ANO5" DataFormatString="{0:# ### ### ##0.00}">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
												<FooterStyle HorizontalAlign="Right"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="ANO6" SortExpression="ANO6" HeaderText="ANO6" DataFormatString="{0:# ### ### ##0.00}">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
												<FooterStyle HorizontalAlign="Right"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="ANO7" SortExpression="ANO7" HeaderText="ANO7" DataFormatString="{0:# ### ### ##0.00}">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
												<FooterStyle HorizontalAlign="Right"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="ANO8" SortExpression="ANO8" HeaderText="ANO8" DataFormatString="{0:# ### ### ##0.00}">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
												<FooterStyle HorizontalAlign="Right"></FooterStyle>
											</asp:BoundColumn>
										</Columns>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
									</cc1:datagridweb></TD>
							</TR>
							<TR>
								<TD width="100%" colSpan="3" align="center">
									<asp:label style="Z-INDEX: 0" id="lblResultado2" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
							</TR>
							<TR>
								<TD width="100%" colSpan="3" align="left">
									<asp:label style="Z-INDEX: 0" id="Label3" runat="server" CssClass="SubTituloNegrita">GASTOS ADMINISTRATIVOS SIMA CALLAO</asp:label></TD>
							</TR>
							<TR>
								<TD width="100%" colSpan="3" align="center">
									<cc1:datagridweb style="Z-INDEX: 0" id="grid3" runat="server" AllowSorting="True" AutoGenerateColumns="False"
										RowHighlightColor="#E0E0E0" Width="100%" ShowFooter="True" PageSize="15">
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
										<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
										<FooterStyle Font-Bold="True" CssClass="footerGrilla"></FooterStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<Columns>
											<asp:BoundColumn DataField="descripcion" SortExpression="descripcion">
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="ANO1" SortExpression="ANO1" HeaderText="ANO1" DataFormatString="{0:# ### ### ##0.00}">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
												<FooterStyle HorizontalAlign="Right"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="ANO2" SortExpression="ANO2" HeaderText="ANO2" DataFormatString="{0:# ### ### ##0.00}">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
												<FooterStyle HorizontalAlign="Right"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="ANO3" SortExpression="ANO3" HeaderText="ANO3" DataFormatString="{0:# ### ### ##0.00}">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
												<FooterStyle HorizontalAlign="Right"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="ANO4" SortExpression="ANO4" HeaderText="ANO4" DataFormatString="{0:# ### ### ##0.00}">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
												<FooterStyle HorizontalAlign="Right"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="ANO5" SortExpression="ANO5" HeaderText="ANO5" DataFormatString="{0:# ### ### ##0.00}">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
												<FooterStyle HorizontalAlign="Right"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="ANO6" SortExpression="ANO6" HeaderText="ANO6" DataFormatString="{0:# ### ### ##0.00}">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
												<FooterStyle HorizontalAlign="Right"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="ANO7" SortExpression="ANO7" HeaderText="ANO7" DataFormatString="{0:# ### ### ##0.00}">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
												<FooterStyle HorizontalAlign="Right"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="ANO8" SortExpression="ANO8" HeaderText="ANO8" DataFormatString="{0:# ### ### ##0.00}">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
												<FooterStyle HorizontalAlign="Right"></FooterStyle>
											</asp:BoundColumn>
										</Columns>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
									</cc1:datagridweb></TD>
							</TR>
							<TR>
								<TD width="100%" colSpan="3" align="center">
									<asp:label style="Z-INDEX: 0" id="lblResultado3" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%" align="center">
						<TABLE id="Table6" border="0" cellSpacing="1" cellPadding="1" width="100%">
							<TR>
								<TD align="left"><IMG style="CURSOR: hand" id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
							</TR>
						</TABLE>
						<INPUT style="Z-INDEX: 0; WIDTH: 15px; HEIGHT: 22px" id="hGridPagina" value="0" size="1"
							type="hidden" name="hGridPagina" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 15px; HEIGHT: 22px" id="hGridPaginaSort" size="1" type="hidden"
							name="hOrdenGrilla" runat="server">
					</TD>
				</TR>
				<tr>
					<td vAlign="top" width="592"></td>
				</tr>
			</table>
			&nbsp;
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
