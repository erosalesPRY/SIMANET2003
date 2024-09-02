<%@ Page language="c#" Codebehind="HeaderInformes.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.General.Diapositivas.HeaderInformes" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>HeaderInformes</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="/SimaNetWeb/styles.css">
	</HEAD>
	<body bottomMargin="0" leftMargin="0" rightMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" border="0" cellSpacing="1" cellPadding="1" width="100%">
				<TR>
					<TD rowspan="2">
						<asp:Image id="Image1" runat="server" ImageUrl="/simanetweb/imagenes/LOGOSIMA_azul.png" Width="216px"
							Height="88px"></asp:Image></TD>
					<TD width="100%"></TD>
					<TD></TD>
					<TD>
						<TABLE id="Table2" border="1" cellSpacing="1" cellPadding="1" width="300" align="right">
							<TR>
								<TD></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD style="FONT-SIZE: 12pt; FONT-WEIGHT: bold" align="right">
									<asp:Label id="Label1" runat="server" CssClass="FechUsuArea">FECHA:</asp:Label></TD>
								<TD style="FONT-SIZE: 9pt">
									<asp:Label id="lblFecha" runat="server">Label</asp:Label></TD>
							</TR>
							<TR>
								<TD align="right">
									<asp:Label id="Label2" runat="server" CssClass="FechUsuArea">USUARIO:</asp:Label></TD>
								<TD style="FONT-SIZE: 9pt">
									<asp:Label id="lblUsuario" runat="server">Label</asp:Label></TD>
							</TR>
							<TR>
								<TD align="right">
									<asp:Label id="Label3" runat="server" CssClass="FechUsuArea">AREA:</asp:Label></TD>
								<TD style="FONT-SIZE: 9pt">
									<asp:Label id="lblArea" runat="server">Label</asp:Label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD width="100%" align="center">
						<asp:Label id="lblTitulo" runat="server" CssClass="TituloRpt">Label</asp:Label></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD style="FONT-SIZE: 9pt" align="center">
						<asp:Label style="Z-INDEX: 0" id="lblSubTitulo" runat="server">Label</asp:Label></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
				</TR>
			</TABLE>
			&nbsp;
		</form>
	</body>
</HTML>
