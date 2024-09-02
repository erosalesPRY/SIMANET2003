<%@ Control Language="c#" AutoEventWireup="false" Codebehind="HeaderFIN.ascx.cs" Inherits="SIMA.SimaNetWeb.General.Diapositivas.GestionFinanciera.HeaderFIN" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<TABLE style="Z-INDEX: 0" id="Table1" border="0" cellSpacing="1" cellPadding="1" width="100%">
	<TR>
		<TD rowSpan="2">
			<asp:Image id="Image1" ImageUrl="/simanetweb/imagenes/LOGOSIMA_azul.png" Width="160px" Height="67px"
				runat="server"></asp:Image></TD>
		<TD width="100%"></TD>
		<TD></TD>
		<TD>
			<TABLE id="Table2" border="0" cellSpacing="0" cellPadding="0" align="right">
				<TR>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD style="FONT-SIZE: 12pt; FONT-WEIGHT: bold" align="right" vAlign="top">
						<asp:Label id="Label1" runat="server" CssClass="FechUsuArea">FECHA:</asp:Label></TD>
					<TD style="FONT-SIZE: 8pt" align="left" vAlign="bottom">
						<asp:Label id="lblFecha" runat="server">Label</asp:Label></TD>
				</TR>
				<TR>
					<TD align="right" vAlign="top">
						<asp:Label id="Label2" runat="server" CssClass="FechUsuArea">USUARIO:</asp:Label></TD>
					<TD style="FONT-SIZE: 8pt" align="left" vAlign="bottom">
						<asp:Label id="lblUsuario" runat="server">Label</asp:Label></TD>
				</TR>
				<TR>
					<TD align="right" vAlign="top">
						<asp:Label id="Label3" runat="server" CssClass="FechUsuArea">AREA:</asp:Label></TD>
					<TD style="FONT-SIZE: 8pt" align="left" vAlign="bottom" noWrap>
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
		<TD style="FONT-SIZE: 9pt" align="center" colSpan="3"></TD>
	</TR>
	<TR>
		<TD></TD>
		<TD align="center">
			<asp:Label style="Z-INDEX: 0" id="lblSubTitulo" runat="server">Label</asp:Label></TD>
		<TD></TD>
		<TD></TD>
	</TR>
	<TR>
		<TD></TD>
		<TD align="center">
			<asp:Label style="Z-INDEX: 0" id="LblSubTitulo3" runat="server"></asp:Label></TD>
		<TD></TD>
		<TD></TD>
	</TR>
</TABLE>
