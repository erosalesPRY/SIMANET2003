<%@ Page language="c#" Codebehind="CopiarFormato.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.General.Formato.CopiarFormato" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>CopiarFormato</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../../styles.css">
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" rightMargin="0" topMargin="10">
		<form id="Form1" method="post" runat="server">
			<TABLE style="WIDTH: 432px; HEIGHT: 107px" id="Table1" border="0" cellSpacing="1" cellPadding="1"
				width="432" align="center">
				<TR>
					<TD colSpan="2" align="center" bgColor="#000080" width="100%">
						<asp:Label id="Label1" runat="server" Font-Bold="True" ForeColor="White">COPIAR FORMATO</asp:Label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 26px" class="headerDetalle">
						<asp:Label id="Label2" runat="server">FORMATO:</asp:Label></TD>
					<TD>
						<asp:Label id="lblFormato" runat="server" Font-Bold="True">Label</asp:Label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 26px" class="headerDetalle">
						<asp:Label id="Label4" runat="server" Width="64px">COPIAR A:</asp:Label></TD>
					<TD>
						<asp:DropDownList id="ddlGrupoFormato" runat="server" Width="346px"></asp:DropDownList></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 26px"></TD>
					<TD align="right">
						<asp:imagebutton style="Z-INDEX: 0" id="ibtnGrabar" runat="server" ImageUrl="../../imagenes/bt_aceptar.gif"></asp:imagebutton></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
