<%@ Control Language="c#" AutoEventWireup="false" Codebehind="ParametroContable.ascx.cs" Inherits="SIMA.SimaNetWeb.ControlesUsuario.GestionFinanciera.ParametroContable" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<TABLE id="TblTabs" cellSpacing="1" cellPadding="1" width="90%" border="0" runat="server">
	<TR id="trCentroOperativo" runat="server">
		<TD width="50%">
			<asp:Label id="lblCentroOPerativo" runat="server" CssClass="TextoNegroNegrita" Width="136px">Centro De Operación:</asp:Label></TD>
		<TD colSpan="2" width="50%">
			<asp:dropdownlist id="ddlbCentroOperativo" runat="server" CssClass="combos" Width="100%"></asp:dropdownlist></TD>
	</TR>
	<TR id="trPeriodo" runat="server">
		<TD width="50%">
			<asp:Label id="lblPeriodo" runat="server" CssClass="TextoNegroNegrita">Periodo:</asp:Label></TD>
		<TD>
			<asp:dropdownlist id="ddlbPeriodo" runat="server" CssClass="combos"></asp:dropdownlist></TD>
		<TD id="trMes" runat="server" width="50%">
			<asp:dropdownlist id="ddlbMes" runat="server" CssClass="combos" Width="100%"></asp:dropdownlist></TD>
	</TR>
	<TR id="trTipoInformacion" runat="server">
		<TD width="50%">
			<asp:Label id="lblTipoInformación" runat="server" CssClass="TextoNegroNegrita">Tipo de Información:</asp:Label></TD>
		<TD colSpan="2" width="50%">
			<asp:dropdownlist id="ddlbTipoInformacion" runat="server" CssClass="combos" Width="100%"></asp:dropdownlist></TD>
	</TR>
	<TR id="trEntidadFinanciera" runat="server">
		<TD width="50%">
			<asp:Label id="lblEntidadFinanciera" runat="server" CssClass="TextoNegroNegrita">Banco:</asp:Label></TD>
		<TD colSpan="2" width="50%">
			<asp:dropdownlist id="ddlbEntidadFinanciera" runat="server" CssClass="combos" Width="100%"></asp:dropdownlist></TD>
	</TR>
</TABLE>
