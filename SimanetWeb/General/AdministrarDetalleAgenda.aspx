<%@ Page language="c#" Codebehind="AdministrarDetalleAgenda.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.General.AdministrarDetalleAgenda" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AdministrarDetalleAgenda</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
		<!--GENuspNTADConsultarAgendaFichadeDatos-->
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="WIDTH: 768px; HEIGHT: 262px" cellSpacing="1" cellPadding="1"
				width="768" border="1">
				<TR>
					<TD style="WIDTH: 197px"></TD>
					<TD>FICHA</TD>
					<TD></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 197px">
						<asp:Image id="Image1" runat="server" Width="208px" Height="208px"></asp:Image></TD>
					<TD>
						<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="528" border="1" style="WIDTH: 528px; HEIGHT: 137px">
							<TR>
								<TD style="WIDTH: 210px">
									<asp:Label id="Label1" runat="server">PORTA RETRATO</asp:Label></TD>
								<TD>
									<asp:TextBox id="txtPortaRetrato" runat="server" Width="88px"></asp:TextBox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 210px">
									<asp:Label id="Label2" runat="server">APELLIDOS Y NOMBRES</asp:Label></TD>
								<TD>
									<asp:TextBox id="txtApellidos" runat="server" Width="304px"></asp:TextBox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 210px">CARGO</TD>
								<TD>
									<asp:TextBox id="txtCargo" runat="server" Width="296px"></asp:TextBox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 210px"></TD>
								<TD></TD>
							</TR>
						</TABLE>
					</TD>
					<TD></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 197px" colSpan="3"></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
