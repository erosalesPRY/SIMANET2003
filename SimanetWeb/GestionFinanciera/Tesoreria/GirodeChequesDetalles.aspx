<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Page CodeBehind="GirodeChequesDetalles.aspx.cs" Language="c#" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.Tesoreria.GirodeChequesDetalles" %>
<%@ Register TagPrefix="cr" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../styles.css">
		<SCRIPT language="javascript" src="../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/general.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/Historial.js"></SCRIPT>
	</HEAD>
	<body onunload="SubirHistorial();" onload="ObtenerHistorial();" bottomMargin="0" leftMargin="0"
		rightMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<P><uc1:header id="Header1" runat="server"></uc1:header><uc1:menu style="Z-INDEX: 0" id="Menu1" runat="server"></uc1:menu></P>
			<P>
				<TABLE id="Table1" border="0" cellSpacing="0" cellPadding="0" width="100%" align="center">
					<TR>
						<TD style="HEIGHT: 12px" class="Commands" bgColor="lightgrey"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Producción > Administración > Proyectos ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Giro de Cheques Detalle</asp:label></TD>
					</TR>
					<tr>
						<td style="Z-INDEX: 0" id="TD1" vAlign="top" width="100%" align="center" runat="server">
							<P align="left"></P>
							<P style="Z-INDEX: 0" align="left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							</P>
							<P style="Z-INDEX: 0" align="left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
								<asp:label id="Label3" runat="server">Centro Operativo:</asp:label>&nbsp;
								<asp:label style="Z-INDEX: 0" id="Label4" runat="server">SIMA CALLAO</asp:label></P>
							<P style="Z-INDEX: 0" align="left">
								&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
								<asp:label style="Z-INDEX: 0" id="lblruc" runat="server">Ruc:</asp:label>&nbsp;&nbsp;
								<asp:dropdownlist id="DropDownList3" runat="server" CssClass="combos" Width="144px"></asp:dropdownlist><asp:label style="Z-INDEX: 0" id="Label1" runat="server">Año Giro:</asp:label>&nbsp;
								<asp:dropdownlist id="DropDownList1" runat="server" CssClass="combos" Width="144px"></asp:dropdownlist>&nbsp;&nbsp;
								<asp:label style="Z-INDEX: 0" id="Label2" runat="server">Mes Giro:</asp:label>&nbsp;&nbsp;&nbsp;
								<asp:dropdownlist id="DropDownList2" runat="server" CssClass="combos" Width="120px"></asp:dropdownlist>&nbsp;&nbsp;&nbsp;&nbsp;
							</P>
							<P align="left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
								<asp:imagebutton style="Z-INDEX: 0" id="ImageButton1" runat="server" Width="16px" Height="14px" ImageUrl="/SimaNetWeb/imagenes/Navegador/xls.gif"></asp:imagebutton></P>
							<P style="Z-INDEX: 0" align="left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
								<cc1:datagridweb style="Z-INDEX: 0" id="grid" runat="server" Width="912px" Height="222px" Font-Size="X-Small"
									Font-Names="Arial" PageSize="7" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
									RowHighlightColor="#E0E0E0" ShowFooter="True">
									<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
									<ItemStyle CssClass="ItemGrilla"></ItemStyle>
									<HeaderStyle Font-Size="X-Small" Font-Names="Arial" ForeColor="Blue" CssClass="HeaderGrilla"></HeaderStyle>
									<FooterStyle CssClass="FooterGrilla" BackColor="Blue"></FooterStyle>
									<Columns>
										<asp:BoundColumn HeaderText="NRO">
											<HeaderStyle HorizontalAlign="Center" Width="2%" VerticalAlign="Middle"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn HeaderText="CENTRO OPERATIVO">
											<HeaderStyle HorizontalAlign="Center" Width="3%" VerticalAlign="Middle"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn HeaderText="RELACION">
											<HeaderStyle Width="5%" VerticalAlign="Middle"></HeaderStyle>
											<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn HeaderText="FECHA DE GIRO">
											<HeaderStyle HorizontalAlign="Center" Width="30%" VerticalAlign="Middle"></HeaderStyle>
											<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn HeaderText="FOLIO CHEQUE">
											<HeaderStyle HorizontalAlign="Center" Width="10%" VerticalAlign="Middle"></HeaderStyle>
											<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn HeaderText="NRO CHEQUE">
											<HeaderStyle HorizontalAlign="Center" Width="5%" VerticalAlign="Middle"></HeaderStyle>
											<ItemStyle Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn HeaderText="CUENTA">
											<HeaderStyle HorizontalAlign="Center" Width="5%" VerticalAlign="Middle"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn HeaderText="DOCUMENTO">
											<HeaderStyle HorizontalAlign="Center" Width="10%" VerticalAlign="Middle"></HeaderStyle>
											<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn HeaderText="EMISION">
											<HeaderStyle Width="10%"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn HeaderText="DESCRIPCION">
											<HeaderStyle Width="30%"></HeaderStyle>
											<ItemStyle HorizontalAlign="Left"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn HeaderText="RUC">
											<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn HeaderText="A&#209;O DE GIRO"></asp:BoundColumn>
										<asp:BoundColumn DataField="MES DE GIRO" SortExpression="MES DE GIRO" HeaderText="MES DE GIRO"></asp:BoundColumn>
									</Columns>
									<PagerStyle ForeColor="Blue" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
								</cc1:datagridweb></P>
							<TABLE style="WIDTH: 616px; HEIGHT: 38px" id="Table7" border="0" cellSpacing="0" cellPadding="0"
								width="616">
								<TR>
									<TD bgColor="#f0f0f0" align="center"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									</TD>
								</TR>
							</TABLE>
							<TABLE id="Table5" border="0" cellSpacing="0" cellPadding="0" width="720">
								<TR>
									<TD vAlign="top" align="left"><IMG style="CURSOR: hand" id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="/SimanetWeb/imagenes/atras.gif"><INPUT style="WIDTH: 16px; HEIGHT: 16px" id="hCodigo" size="1" type="hidden" name="hCodigo"
											runat="server"></TD>
									<TD></TD>
								</TR>
							</TABLE>
						</td>
					</tr>
				</TABLE>
			</P>
		</form>
	</body>
</HTML>
