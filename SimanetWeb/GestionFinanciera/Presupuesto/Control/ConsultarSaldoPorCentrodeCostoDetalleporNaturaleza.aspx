<%@ Register TagPrefix="uc1" TagName="Header" Src="../../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Page language="c#" Codebehind="ConsultarSaldoPorCentrodeCostoDetalleporNaturaleza.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.Presupuesto.Control.ConsultarSaldoPorCentrodeCostoDetalleporNaturaleza" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../../js/@Import.js"></SCRIPT>
	</HEAD>
	<body oncontextmenu="return false" onkeydown="if (event.keyCode==13 || event.keyCode==9)return false"
		bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="HEIGHT: 140px" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD vAlign="top" align="left" width="100%" height="100%">
						<cc1:datagridweb id="grid" runat="server" Width="100%" RowHighlightColor="#E0E0E0" AutoGenerateColumns="False"
							PageSize="9">
							<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
							<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
							<FooterStyle CssClass="FooterGrilla"></FooterStyle>
							<ItemStyle CssClass="ItemGrilla"></ItemStyle>
							<Columns>
								<asp:BoundColumn DataField="NroDocumento" HeaderText="NRO DOC">
									<HeaderStyle Wrap="False" Width="1%"></HeaderStyle>
									<ItemStyle Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="FECHA" HeaderText="FECHA">
									<HeaderStyle Wrap="False" HorizontalAlign="Center" Width="2%" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="DESCRIPCION" HeaderText="DESCRIPCION">
									<HeaderStyle Wrap="False" Width="20%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="ImporteSoles" HeaderText="SOLES">
									<HeaderStyle Wrap="False" Width="2%"></HeaderStyle>
									<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="ImporteDolar" HeaderText="DOLARES">
									<HeaderStyle Wrap="False" Width="2%"></HeaderStyle>
									<ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
							<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
						</cc1:datagridweb></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%" height="100%">
						<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label><INPUT id="hidCentroOperativo" style="WIDTH: 99px; HEIGHT: 22px" type="hidden" size="11"></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
