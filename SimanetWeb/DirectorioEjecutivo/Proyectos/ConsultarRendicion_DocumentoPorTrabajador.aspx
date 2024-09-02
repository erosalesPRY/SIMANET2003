<%@ Page language="c#" Codebehind="ConsultarRendicion_DocumentoPorTrabajador.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.DirectorioEjecutivo.Proyectos.ConsultarRendicion_DocumentoPorTrabajador" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>SIMANET</title>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../../styles.css">
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>
</HEAD>
	<body oncontextmenu="return false" onunload="SubirHistorial();" onload="ObtenerHistorial();"
		bottomMargin="0" leftMargin="0" rightMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<table border="0" cellSpacing="0" cellPadding="0" width="100%" align="center">
				<tr>
					<td width="100%"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr>
					<td bgColor="#eff7fa" vAlign="top" width="100%"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
				<TR>
					<TD class="RutaPaginaActual" vAlign="top" width="100%"><asp:label style="Z-INDEX: 0" id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Proyectos ></asp:label><asp:label style="Z-INDEX: 0" id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Consultar Rendición de Cuentas Pendientes</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%" align="center">
						<TABLE id="Table1" class="normal" border="0" cellSpacing="0" cellPadding="0" width="100%"
							DESIGNTIMEDRAGDROP="26">
							<TR>
								<TD width="100%" colSpan="3" align="center">
									<TABLE border="0" cellSpacing="0" cellPadding="0" width="100%">
										<TR bgColor="#f0f0f0">
											<TD><IMG src="../../imagenes/tab_izq.gif" width="4" height="22">
												<asp:label style="Z-INDEX: 0" id="lblTitulo" runat="server" CssClass="SubTituloNegrita"></asp:label></TD>
											<TD></TD>
											<TD>&nbsp;</TD>
											<TD align="right"></TD>
											<TD width="4" align="right"></TD>
										</TR>
									</TABLE>
									<cc1:datagridweb id="grid" runat="server" PageSize="7" ShowFooter="True" Width="100%" RowHighlightColor="#E0E0E0"
										AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True">
<PagerStyle CssClass="PagerGrilla" Mode="NumericPages">
</PagerStyle>

<AlternatingItemStyle CssClass="Alternateitemgrilla">
</AlternatingItemStyle>

<FooterStyle Font-Size="X-Small" Font-Bold="True" CssClass="FooterGrilla">
</FooterStyle>

<ItemStyle CssClass="ItemGrilla">
</ItemStyle>

<Columns>
<asp:BoundColumn HeaderText="NRO">
<HeaderStyle Width="1%" VerticalAlign="Middle">
</HeaderStyle>

<ItemStyle VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="DOCUMENTO" SortExpression="DOCUMENTO" HeaderText="DOCUMENTO">
<HeaderStyle Width="5%" VerticalAlign="Middle">
</HeaderStyle>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="FOLIO" SortExpression="FOLIO" HeaderText="FOLIO">
<HeaderStyle Width="5%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Left">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="FECHA" SortExpression="FECHA" HeaderText="FECHA" DataFormatString="{0:dd-MM-yyyy}">
<HeaderStyle Width="5%">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="OBSERVACION" SortExpression="OBSERVACION" HeaderText="OBSERVACION">
<HeaderStyle Width="30%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Left">
</ItemStyle>
</asp:BoundColumn>
<asp:TemplateColumn HeaderText="EJECUTADO">
<HeaderTemplate>
													<TABLE id="Table3" border="0" cellSpacing="0" cellPadding="0" width="100%">
														<TR>
															<TD style="BORDER-BOTTOM: #cccccc 1px solid; BORDER-LEFT-COLOR: #cccccc; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT: #cccccc 1px solid"
																rowSpan="2" width="50%" colSpan="4" align="center">
																<asp:Label style="Z-INDEX: 0" id="Label19" runat="server" CssClass="HeaderGrilla" Width="99%" 
 Height="3px" BorderStyle="None" Font-Bold="True">SOLES</asp:Label></TD>
														</TR>
														<TR>
															<TD style="BORDER-BOTTOM: 1px solid; BORDER-LEFT-WIDTH: 1px" width="50%" colSpan="4"
																align="center">
																<asp:Label style="Z-INDEX: 0" id="Label18" runat="server" CssClass="HeaderGrilla" Width="99%" 
 Height="3px" BorderStyle="None" Font-Bold="True">DOLARES</asp:Label></TD>
														</TR>
														<TR>
															<TD style="BORDER-BOTTOM: #cccccc 1px solid; BORDER-LEFT-COLOR: #cccccc; BORDER-LEFT-WIDTH: 2px; BORDER-RIGHT: #cccccc 1px solid"
																width="12%" align="center">
																<asp:Label style="Z-INDEX: 0" id="Label17" runat="server" CssClass="HeaderGrilla" Width="99%" 
 Height="3px" BorderStyle="None" Font-Bold="True">IMPORTE</asp:Label></TD>
															<TD style="BORDER-BOTTOM: #cccccc 1px solid; BORDER-LEFT-COLOR: #cccccc; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT: #cccccc 1px solid"
																width="12%" align="center">
																<asp:Label style="Z-INDEX: 0" id="Label16" runat="server" CssClass="HeaderGrilla" Width="99%" 
 Height="3px" BorderStyle="None" Font-Bold="True">DEVUELTO</asp:Label></TD>
															<TD style="BORDER-BOTTOM: #cccccc 1px solid; BORDER-LEFT-COLOR: #cccccc; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT: #cccccc 1px solid"
																width="12%" align="center">
																<asp:Label style="Z-INDEX: 0" id="labelll" runat="server" CssClass="HeaderGrilla" Width="99%" 
 Height="3px" BorderStyle="None" Font-Bold="True">RENDIDO</asp:Label></TD>
															<TD style="BORDER-BOTTOM: #cccccc 1px solid; BORDER-LEFT-COLOR: #cccccc; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT: #cccccc 1px solid"
																width="12%" align="center">
																<asp:Label style="Z-INDEX: 0" id="Label1" runat="server" CssClass="HeaderGrilla" Width="99%" 
 Height="3px" BorderStyle="None" Font-Bold="True">PENDIENTE</asp:Label></TD>
															<TD style="BORDER-BOTTOM: #cccccc 1px solid; BORDER-LEFT-COLOR: #cccccc; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT: #cccccc 1px solid"
																width="12%" align="center">
																<asp:Label style="Z-INDEX: 0" id="Label5" runat="server" CssClass="HeaderGrilla" Width="99%" 
 Height="3px" BorderStyle="None" Font-Bold="True">IMPORTE</asp:Label></TD>
															<TD style="BORDER-BOTTOM: #cccccc 1px solid; BORDER-LEFT-COLOR: #cccccc; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT: #cccccc 1px solid"
																width="12%" align="center">
																<asp:Label style="Z-INDEX: 0" id="Label4" runat="server" CssClass="HeaderGrilla" Width="99%" 
 Height="3px" BorderStyle="None" Font-Bold="True">DEVUELTO</asp:Label></TD>
															<TD style="BORDER-BOTTOM: #cccccc 1px solid; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc; BORDER-LEFT-COLOR: #cccccc; BORDER-LEFT-WIDTH: 1px"
																width="12%" align="center">
																<asp:Label style="Z-INDEX: 0" id="Label2" runat="server" CssClass="HeaderGrilla" Width="99%" 
 Height="3px" BorderStyle="None" Font-Bold="True">RENDIDO</asp:Label></TD>
															<TD style="BORDER-BOTTOM: #cccccc 1px solid; BORDER-LEFT: #cccccc 1px solid; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc"
																width="12%" align="center">
																<asp:Label style="Z-INDEX: 0" id="Label3" runat="server" CssClass="HeaderGrilla" Width="99%" 
 Height="3px" BorderStyle="None" Font-Bold="True">PENDIENTE</asp:Label></TD>
														</TR>
													</TABLE>
												
</HeaderTemplate>

<ItemTemplate>
													<TABLE style="Z-INDEX: 0" id="Table7" border="0" cellSpacing="0" cellPadding="0" width="100%">
														<TR>
															<TD width="12%" align="right">
																<asp:Label style="Z-INDEX: 0" id="lblIMP_SOL" runat="server" CssClass="normaldetalle" Width="99%" 
 Height="3px" BorderStyle="None" Font-Bold="True">IMPORTE</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" width="12%" align="right">
																<asp:Label style="Z-INDEX: 0" id="lblDEV_SOL" runat="server" CssClass="normaldetalle" Width="99%" 
 Height="3px" BorderStyle="None" Font-Bold="True">DEVUELTO</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" width="12%" align="right">
																<asp:Label style="Z-INDEX: 0" id="lblREN_SOL" runat="server" CssClass="normaldetalle" Width="99%" 
 Height="3px" BorderStyle="None" Font-Bold="True">RENDIDO</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" width="12%" align="right">
																<asp:Label style="Z-INDEX: 0" id="lblPEN_SOL" runat="server" CssClass="normaldetalle" Width="99%" 
 Height="3px" BorderStyle="None" Font-Bold="True">PENDIENTE</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" width="12%" align="right">
																<asp:Label style="Z-INDEX: 0" id="lblIMP_DOL" runat="server" CssClass="normaldetalle" Width="99%" 
 Height="3px" BorderStyle="None" Font-Bold="True">IMPORTE</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" width="12%" align="right">
																<asp:Label style="Z-INDEX: 0" id="lblDEV_DOL" runat="server" CssClass="normaldetalle" Width="99%" 
 Height="3px" BorderStyle="None" Font-Bold="True">DEVUELTO</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" width="12%" align="right">
																<asp:Label style="Z-INDEX: 0" id="lblREN_DOL" runat="server" CssClass="normaldetalle" Width="99%" 
 Height="3px" BorderStyle="None" Font-Bold="True">RENDIDO</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" width="12%" align="right">
																<asp:Label style="Z-INDEX: 0" id="lblPEN_DOL" runat="server" CssClass="normaldetalle" Width="99%" 
 Height="3px" BorderStyle="None" Font-Bold="True">PENDIENTE</asp:Label></TD>
														</TR>
													</TABLE>
												
</ItemTemplate>

<FooterTemplate>
													<TABLE style="Z-INDEX: 0" id="Table8" border="0" cellSpacing="0" cellPadding="0" width="100%">
														<TR>
															<TD style="BORDER-BOTTOM-COLOR: #cccccc; BORDER-RIGHT-WIDTH: 1px; BORDER-BOTTOM-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc; BORDER-LEFT-COLOR: #cccccc; BORDER-LEFT-WIDTH: 2px"
																width="12%" align="right">
																<asp:Label style="Z-INDEX: 0" id="lblTIMP_SOL" runat="server" CssClass="footerGrilla" Width="99%" 
 Height="3px" BorderStyle="None" Font-Bold="True">0.00</asp:Label></TD>
															<TD style="BORDER-BOTTOM-COLOR: #cccccc; BORDER-LEFT: #cccccc 1px solid; BORDER-RIGHT-WIDTH: 1px; BORDER-BOTTOM-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc"
																width="12%" align="right">
																<asp:Label style="Z-INDEX: 0" id="lblTDEV_SOL" runat="server" CssClass="footerGrilla" Width="99%" 
 Height="3px" BorderStyle="None" Font-Bold="True">0.00</asp:Label></TD>
															<TD style="BORDER-BOTTOM-COLOR: #cccccc; BORDER-LEFT: #cccccc 1px solid; BORDER-RIGHT-WIDTH: 1px; BORDER-BOTTOM-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc"
																width="12%" align="right">
																<asp:Label style="Z-INDEX: 0" id="lblTREN_SOL" runat="server" CssClass="footerGrilla" Width="99%" 
 Height="3px" BorderStyle="None" Font-Bold="True">0.00</asp:Label></TD>
															<TD style="BORDER-BOTTOM-COLOR: #cccccc; BORDER-LEFT: #cccccc 1px solid; BORDER-RIGHT-WIDTH: 1px; BORDER-BOTTOM-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc"
																width="12%" align="right">
																<asp:Label style="Z-INDEX: 0" id="lblTPEN_SOL" runat="server" CssClass="footerGrilla" Width="99%" 
 Height="3px" BorderStyle="None" Font-Bold="True">0.00</asp:Label></TD>
															<TD style="BORDER-BOTTOM-COLOR: #cccccc; BORDER-LEFT: #cccccc 1px solid; BORDER-BOTTOM-WIDTH: 1px; BORDER-RIGHT: #cccccc 1px solid"
																width="12%" align="right">
																<asp:Label style="Z-INDEX: 0" id="lblTIMP_DOL" runat="server" CssClass="footerGrilla" Width="99%" 
 Height="3px" BorderStyle="None" Font-Bold="True">0.00</asp:Label></TD>
															<TD style="BORDER-LEFT: 1px solid" width="12%" align="right">
																<asp:Label style="Z-INDEX: 0" id="lblTDEV_DOL" runat="server" CssClass="footerGrilla" Width="99%" 
 Height="3px" BorderStyle="None" Font-Bold="True">0.00</asp:Label></TD>
															<TD style="BORDER-BOTTOM-COLOR: #cccccc; BORDER-LEFT: #cccccc 1px solid; BORDER-RIGHT-WIDTH: 1px; BORDER-BOTTOM-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc"
																width="12%" align="right">
																<asp:Label style="Z-INDEX: 0" id="lblTREN_DOL" runat="server" CssClass="footerGrilla" Width="99%" 
 Height="3px" BorderStyle="None" Font-Bold="True">0.00</asp:Label></TD>
															<TD style="BORDER-BOTTOM-COLOR: #cccccc; BORDER-LEFT: #cccccc 1px solid; BORDER-RIGHT-WIDTH: 1px; BORDER-BOTTOM-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc"
																width="12%" align="right">
																<asp:Label style="Z-INDEX: 0" id="lblTPEN_DOL" runat="server" CssClass="footerGrilla" Width="99%" 
 Height="3px" BorderStyle="None" Font-Bold="True">0.00</asp:Label></TD>
														</TR>
													</TABLE>
												
</FooterTemplate>
</asp:TemplateColumn>
</Columns>

<HeaderStyle CssClass="HeaderGrilla">
</HeaderStyle>
									</cc1:datagridweb><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
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
