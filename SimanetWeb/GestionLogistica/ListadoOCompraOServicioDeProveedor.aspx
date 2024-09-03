<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="ListadoOCompraOServicioDeProveedor.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionLogistica.ListadoOCompraOServicioDeProveedor" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ListadoOCompraOServicioDeProveedor</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../styles.css">
		<SCRIPT language="javascript" src="../js/@Import.js"></SCRIPT>
	</HEAD>
	<body onunload="SubirHistorial();" onload="ObtenerHistorial();" bottomMargin="0" leftMargin="0"
		rightMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" border="0" cellSpacing="0" cellPadding="0" width="100%" height="100%">
				<TR>
					<TD><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD height="100%" vAlign="top">
						<TABLE id="Table2" border="0" cellSpacing="1" cellPadding="1" width="772" align="center">
							<TR>
								<TD vAlign="top" align="left">
									<TABLE style="Z-INDEX: 0; HEIGHT: 90px" id="Table3" border="0" cellSpacing="1" cellPadding="1"
										width="100%" align="left">
										<TR>
											<TD class="headerDetalle" align="center"><asp:label id="Label1" runat="server" ForeColor="White" Font-Bold="True" CssClass="normaldetalle">DOCUMENTO:</asp:label></TD>
											<TD colSpan="13" align="left" width="100%">
												<asp:label id="LblDocumento" runat="server" CssClass="normaldetalle" Font-Bold="True">Label</asp:label></TD>
										</TR>
										<TR>
											<TD class="headerDetalle"><asp:label id="Label2" runat="server" ForeColor="White" Font-Bold="True" CssClass="normaldetalle">Moneda:</asp:label></TD>
											<TD width="232" style="WIDTH: 232px"><asp:label id="LblMoneda" runat="server" CssClass="normaldetalle">Label</asp:label></TD>
											<TD style="WIDTH: 52px" class="headerDetalle"><asp:label id="Label3" runat="server" ForeColor="White" Font-Bold="True" CssClass="normaldetalle">Estado:</asp:label></TD>
											<TD style="WIDTH: 435px" width="435"><asp:label id="LblEstado" runat="server" CssClass="normaldetalle">Label</asp:label></TD>
											<TD style="WIDTH: 28px" class="headerDetalle"><asp:label id="Lbl" runat="server" ForeColor="White" Font-Bold="True" CssClass="normaldetalle">Año:</asp:label></TD>
											<TD style="WIDTH: 382px" width="382"><asp:label id="LblAño" runat="server" CssClass="normaldetalle">Label</asp:label></TD>
											<TD style="WIDTH: 43px" class="headerDetalle"><asp:label id="Label5" runat="server" ForeColor="White" Font-Bold="True" CssClass="normaldetalle">Mes:</asp:label></TD>
											<TD style="WIDTH: 132px" width="132" noWrap>
												<asp:label id="LblMes" runat="server" CssClass="normaldetalle" style="Z-INDEX: 0">Label</asp:label></TD>
											<TD style="WIDTH: 132px" class="headerDetalle" width="132">
												<asp:label style="Z-INDEX: 0" id="Label8" runat="server" CssClass="normaldetalle" Font-Bold="True"
													ForeColor="White">TOTAL:</asp:label></TD>
											<TD width="132" colSpan="5" style="WIDTH: 132px" noWrap>
												<asp:label style="Z-INDEX: 0" id="LblTotal" runat="server" CssClass="normaldetalle" Font-Bold="True">Label</asp:label></TD>
										</TR>
										<TR>
											<TD class="headerDetalle"><asp:label style="Z-INDEX: 0" id="Label4" runat="server" ForeColor="White" Font-Bold="True"
													CssClass="normaldetalle">PROVEEDOR:</asp:label></TD>
											<TD width="55%" colSpan="7"><asp:label style="Z-INDEX: 0" id="LblProveedor" runat="server" Font-Bold="True" CssClass="normaldetalle">Label</asp:label></TD>
											<TD class="headerDetalle" width="10%" noWrap><asp:label style="Z-INDEX: 0" id="Label7" runat="server" ForeColor="White" Font-Bold="True"
													CssClass="normaldetalle">IMPORTE PROVEEDOR:</asp:label></TD>
											<TD width="15%" noWrap><asp:label style="Z-INDEX: 0" id="LblImporte" runat="server" Font-Bold="True" CssClass="normaldetalle">Label</asp:label></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD vAlign="top">
									<P><cc1:datagridweb style="Z-INDEX: 0" id="grid" runat="server" AllowSorting="True" AutoGenerateColumns="False"
											RowHighlightColor="#E0E0E0" PageSize="15" ShowFooter="True" Width="942px">
											<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
											<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
											<FooterStyle CssClass="FooterGrilla"></FooterStyle>
											<ItemStyle CssClass="ItemGrilla"></ItemStyle>
											<Columns>
												<asp:BoundColumn DataField="Nro" HeaderText="NRO">
													<ItemStyle Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="FechaRecepcion" HeaderText="FECHA RECEPCION">
													<ItemStyle Wrap="False"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="PLAZO_PAGO" HeaderText="PLAZO DE PAGO"></asp:BoundColumn>
												<asp:BoundColumn DataField="FECHA_PROGRAMADA" HeaderText="FECHA PROGRAMADA"></asp:BoundColumn>
												<asp:BoundColumn DataField="F_CANCELACION" HeaderText="FECHA CANCELACION"></asp:BoundColumn>
												<asp:BoundColumn DataField="Moneda" HeaderText="MONEDA">
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="CONCEPTO" HeaderText="CONCEPTO">
													<HeaderStyle HorizontalAlign="Center" Width="50%" VerticalAlign="Middle"></HeaderStyle>
													<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="DOC_PAGO" HeaderText="DOC PAGO">
													<HeaderStyle HorizontalAlign="Center" Width="10%" VerticalAlign="Middle"></HeaderStyle>
													<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="TIPO" HeaderText="TIPO">
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Importe" HeaderText="IMPORTE">
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
													<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
												</asp:BoundColumn>
											</Columns>
											<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										</cc1:datagridweb></P>
								</TD>
							</TR>
							<TR>
								<TD vAlign="top"><IMG style="Z-INDEX: 0; CURSOR: hand" id="ibtnAtras" onclick="HistorialIrAtras();" alt=""
										src="../imagenes/atras.gif"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
