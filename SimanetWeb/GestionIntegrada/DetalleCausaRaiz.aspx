<%@ Page language="c#" Codebehind="DetalleCausaRaiz.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionIntegrada.DetalleCausaRaiz" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DetalleCausaRaiz</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../styles.css">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE style="WIDTH: 544px; HEIGHT: 64px" id="Table1" border="0" cellSpacing="1" cellPadding="1"
				width="544">
				<TR class="ItemDetalle">
					<TD style="WIDTH: 120px" class="headerDetalle" vAlign="top" align="left"><asp:label id="Label2" runat="server" CssClass="headerDetalle" BorderStyle="None">DESCRIPCION:</asp:label></TD>
					<TD><asp:textbox id="txtDescripcion" runat="server" CssClass="normaldetalle" Width="100%" Height="112px"
							TextMode="MultiLine"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 120px"></TD>
					<TD><INPUT style="WIDTH: 64px; HEIGHT: 22px" id="HQueryString" size="5" type="hidden"><INPUT style="Z-INDEX: 0; WIDTH: 40px; HEIGHT: 22px" id="hIdDestino" size="1" type="hidden"
							name="Hidden1" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 40px; HEIGHT: 22px" id="hIdCausaRaiz" size="1" type="hidden"
							name="Hidden1" runat="server"></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
