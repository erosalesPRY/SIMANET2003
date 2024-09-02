<%@ Page language="c#" Codebehind="DetalleColumna.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.General.Formato.DetalleColumna" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DetalleColumna</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../../styles.css">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE style="WIDTH: 528px; HEIGHT: 86px" id="Table1" border="1" cellSpacing="1" cellPadding="1"
				width="528">
				<TR>
					<TD></TD>
					<TD width="100%"><asp:label style="Z-INDEX: 0" id="Label4" runat="server">COLUMNA</asp:label></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD class="headerDetalle"><asp:label id="Label1" runat="server">Titulo:</asp:label></TD>
					<TD width="100%"><asp:textbox id="txtTitulo" runat="server" Width="100%"></asp:textbox></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD class="headerDetalle"><asp:label id="Label2" runat="server">Tipo</asp:label></TD>
					<TD><asp:dropdownlist id="ddlTipoColumna" runat="server" Width="100%"></asp:dropdownlist></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD class="headerDetalle">
						<asp:Label id="Label3" runat="server">Campo</asp:Label></TD>
					<TD>
						<asp:DropDownList id="ddlCampoBD" runat="server">
							<asp:ListItem Value="MONTOACUMULADO">Importe Acumulado</asp:ListItem>
							<asp:ListItem Value="MONTOMES">Importe del mes</asp:ListItem>
							<asp:ListItem Value="DEBEMES">Debe del mes</asp:ListItem>
							<asp:ListItem Value="HABERMES">Haber del mes</asp:ListItem>
							<asp:ListItem Value="0">[Seleccionar..]</asp:ListItem>
						</asp:DropDownList></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD align="right">
						<TABLE id="Table2" border="1" cellSpacing="1" cellPadding="1" width="300" align="right">
							<TR>
								<TD></TD>
								<TD></TD>
								<TD></TD>
							</TR>
						</TABLE>
					</TD>
					<TD></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
