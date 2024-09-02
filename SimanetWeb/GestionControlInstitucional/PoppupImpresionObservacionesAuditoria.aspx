<%@ Page language="c#" Codebehind="PoppupImpresionObservacionesAuditoria.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionControlInstitucional.PoppupImpresionObservacionesAuditoria" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>PoppupImpresionObservacionesAuditoria</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body bottomMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<DIV align="center">
				<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="300" align="center" border="0">
					<TR>
						<TD style="HEIGHT: 42px"></TD>
						<TD style="HEIGHT: 42px">
							<P align="center">
								<asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal"></asp:label></P>
						</TD>
						<TD style="HEIGHT: 42px"></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 22px"></TD>
						<TD style="HEIGHT: 22px"></TD>
						<TD style="HEIGHT: 22px"></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 44px" colSpan="" rowSpan=""></TD>
						<TD style="HEIGHT: 44px">
							<DIV align="center">
								<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
									<TR>
										<TD>
											<asp:label id="Label1" runat="server" Font-Bold="True" Font-Size="XX-Small" Font-Names="Arial"> Organismo:</asp:label></TD>
										<TD>
											<asp:textbox id="txtOrganismo" runat="server" CssClass="normaldetalle" Font-Size="XX-Small" ReadOnly="True"
												MaxLength="200" BorderWidth="0px" BackColor="Transparent" ForeColor="Black"></asp:textbox></TD>
										<TD>
											<asp:label id="Label8" runat="server" Font-Bold="True" Font-Size="XX-Small" Font-Names="Arial"> Acción Control:</asp:label></TD>
										<TD>
											<asp:label id="lblAccionControl" runat="server" Width="103px" Height="32px" Font-Bold="True"
												Font-Size="XX-Small" ForeColor="Navy" Font-Names="Arial"></asp:label></TD>
										<TD>
											<asp:label id="lblFecha" runat="server" Font-Bold="True" Font-Size="XX-Small" Font-Names="Arial">Año:</asp:label></TD>
										<TD>
											<asp:textbox id="txtPeriodo" runat="server" CssClass="normaldetalle" Font-Size="XX-Small" ReadOnly="True"
												MaxLength="200" BorderWidth="0px" BackColor="Transparent"></asp:textbox></TD>
									</TR>
									<TR>
										<TD>
											<asp:label id="Label4" runat="server" Font-Bold="True" Font-Size="XX-Small">Fecha Documento:</asp:label></TD>
										<TD>
											<asp:textbox id="txtFechaDocumento" runat="server" CssClass="normaldetalle" Font-Size="XX-Small"
												ReadOnly="True" MaxLength="200" BorderWidth="0px" BackColor="Transparent"></asp:textbox></TD>
										<TD>
											<asp:label id="Label6" runat="server" Font-Bold="True" Font-Size="XX-Small" Font-Names="Arial">Fecha Inicio:</asp:label></TD>
										<TD>
											<asp:textbox id="txtFechaInicio" runat="server" CssClass="normaldetalle" Font-Size="XX-Small"
												ReadOnly="True" BorderWidth="0px" BackColor="Transparent"></asp:textbox></TD>
										<TD>
											<asp:label id="Label7" runat="server" Font-Bold="True" Font-Size="XX-Small" Font-Names="Arial">Fecha Término:</asp:label></TD>
										<TD>
											<asp:textbox id="txtFechaTermino" runat="server" CssClass="normaldetalle" Font-Size="XX-Small"
												ReadOnly="True" BorderWidth="0px" BackColor="Transparent"></asp:textbox></TD>
									</TR>
									<TR>
										<TD>
											<asp:label id="Label2" runat="server" Font-Bold="True" Font-Size="XX-Small" Font-Names="Arial">C.O.</asp:label></TD>
										<TD>
											<asp:textbox id="txtCentroOperativo" runat="server" CssClass="normaldetalle" Font-Size="XX-Small"
												ReadOnly="True" BorderWidth="0px" BackColor="Transparent"></asp:textbox></TD>
										<TD></TD>
										<TD></TD>
										<TD></TD>
										<TD></TD>
									</TR>
									<TR>
										<TD>
											<asp:label id="Label9" runat="server" Font-Bold="True" Font-Size="XX-Small" Font-Names="Arial">Situación:</asp:label></TD>
										<TD>
											<asp:textbox id="txtSituacion" runat="server" CssClass="normaldetalle" Font-Size="XX-Small" ReadOnly="True"
												MaxLength="200" BorderWidth="0px" BackColor="Transparent"></asp:textbox></TD>
										<TD></TD>
										<TD></TD>
										<TD></TD>
										<TD></TD>
									</TR>
									<TR>
										<TD>
											<asp:label id="lblConcepto" runat="server" Width="137px" Font-Bold="True" Font-Size="XX-Small"
												Font-Names="Arial"> Observaciones:</asp:label></TD>
										<TD></TD>
										<TD></TD>
										<TD></TD>
										<TD></TD>
										<TD></TD>
									</TR>
									<TR>
										<TD colSpan="6">
											<asp:label id="lblContenidoObservaciones" runat="server" CssClass="normaldetalle" Width="100%"
												Height="48px" Font-Bold="True" Font-Size="XX-Small" Font-Names="Arial"></asp:label></TD>
									</TR>
								</TABLE>
							</DIV>
						</TD>
						<TD style="HEIGHT: 44px"></TD>
					</TR>
					<TR>
						<TD></TD>
						<TD>
							<cc1:datagridweb id="grid" runat="server" RowPositionEnabled="False" RowHighlightColor="#E0E0E0"
								AutoGenerateColumns="False" AllowSorting="True" PageSize="7" ShowFooter="True" Width="640px"
								CssClass="HeaderGrilla">
								<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
								<ItemStyle CssClass="ItemGrilla"></ItemStyle>
								<FooterStyle CssClass="FooterGrilla"></FooterStyle>
								<Columns>
									<asp:BoundColumn DataField="Observacion" HeaderText="OBSERVACION">
										<HeaderStyle HorizontalAlign="Center" Width="50%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
										<FooterStyle HorizontalAlign="Left"></FooterStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CentroOperativo" HeaderText="C.O.">
										<HeaderStyle Width="1%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Situacion" HeaderText="SITUACION">
										<HeaderStyle Width="12%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="FechaTermino" HeaderText="FECHA TERM." DataFormatString="{0:dd-MM-yyyy}">
										<HeaderStyle Width="11%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn Visible="False">
										<HeaderStyle Width="0%"></HeaderStyle>
										<ItemTemplate>
											<asp:Image id="imgCaducidad" runat="server" Height="18px"></asp:Image>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
							</cc1:datagridweb></TD>
						<TD></TD>
					</TR>
					<TR>
						<TD></TD>
						<TD>
							<P align="center">
								<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></P>
						</TD>
						<TD></TD>
					</TR>
				</TABLE>
			</DIV>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
