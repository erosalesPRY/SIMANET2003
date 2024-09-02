<%@ Page language="c#" Codebehind="ExportarDetalleExcelCtasPagarOtros.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.CuentasPorCobrarPagar.Directorio.ExportarDetalleExcelCtasPagarOtros" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../../ControlesUsuario/Header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ConsultarDetalleCuentasPorPagarOtros</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../../js/Historial.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../../js/JSFrameworkSima.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<DIV align="center">
			<form id="Form1" method="post" runat="server">
				<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="780" border="0">
					<TR id="id1">
						<TD colSpan="2"></TD>
					</TR>
					<TR id="id4">
						<TD style="HEIGHT: 21px" align="left" bgColor="#f0f0f0">&nbsp;
							<asp:imagebutton id="ibtnAbrir" runat="server" ImageUrl="..\..\..\imagenes\bt_exportar.gif"></asp:imagebutton></TD>
						<TD style="HEIGHT: 21px" align="right" bgColor="#f0f0f0"></TD>
					</TR>
					<TR>
						<TD align="center" colSpan="2"><cc1:datagridweb id="grid" runat="server" PageSize="7" AllowSorting="True" AutoGenerateColumns="False"
								RowHighlightColor="#E0E0E0" ShowFooter="True" Width="100%">
								<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
								<ItemStyle CssClass="ItemGrilla"></ItemStyle>
								<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
								<FooterStyle CssClass="FooterGrillaEF"></FooterStyle>
								<Columns>
									<asp:BoundColumn HeaderText="Nro" FooterText="TOTAL:">
										<HeaderStyle Width="3%"></HeaderStyle>
										<FooterStyle Font-Size="XX-Small" Font-Names="Verdana" Font-Bold="True"></FooterStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="RazonSocial" SortExpression="RazonSocial" HeaderText="ACREEDOR">
										<HeaderStyle Width="30%"></HeaderStyle>
										<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
										<FooterStyle Font-Size="XX-Small" Font-Names="Arial" Font-Bold="True" HorizontalAlign="Left"
											VerticalAlign="Middle"></FooterStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="TotalEnSoles" SortExpression="TotalEnSoles" HeaderText="IMPORTE">
										<HeaderStyle Width="17%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
										<FooterStyle HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="fechaEmision" SortExpression="fechaEmision" HeaderText="FECHA" DataFormatString="{0:dd-MM-yyyy}">
										<HeaderStyle Width="20%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Descripcion" SortExpression="Descripcion" HeaderText="REFERENCIA">
										<HeaderStyle Width="30%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
								</Columns>
								<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
							</cc1:datagridweb><BR>
							<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
					</TR>
					<TR id="id5">
						<TD align="left" colSpan="2"></TD>
					</TR>
				</TABLE>
			</form>
		</DIV>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
