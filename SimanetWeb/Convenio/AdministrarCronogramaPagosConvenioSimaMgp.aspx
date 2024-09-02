<%@ Page language="c#" Codebehind="AdministrarCronogramaPagosConvenioSimaMgp.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.Convenio.AdministrarCronogramaPagosConvenioSimaMgp" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="HeaderInicio" Src="../ControlesUsuario/HeaderInicio.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/Historial.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onload="ObtenerHistorial();"
		onunload="SubirHistorial();">
		<FORM id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR width="100%" valign="baseline">
					<TD width="100%" valign="baseline">
						<uc1:Header id="Header1" runat="server"></uc1:Header>
					</TD>
				</TR>
				<TR width="100%" valign="top">
					<TD vAlign="top"><uc1:menu id="Menu2" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="Commands" style="HEIGHT: 20px"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Administración >  Convenios SIMA - MGP ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> ADMINISTRAR CRONOGRAMAS POR CONVENIO</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%" align="center">
						<asp:label id="lblTitulo" runat="server" CssClass="TituloSecundario"></asp:label><BR>
						<TABLE id="Table9" cellSpacing="0" cellPadding="0" width="780" border="0">
							<TR>
								<TD bgColor="#f5f5f5"><asp:label id="lblSubtitulo1" runat="server" CssClass="TituloSecundario">&nbsp;PROGRAMA DE PAGOS</asp:label></TD>
							</TR>
							<TR>
								<TD bgColor="#f5f5f5" align="right"><asp:imagebutton id="ibtnCronogramaPagos" runat="server" ImageUrl="../imagenes/btnCronogramaDePagos.jpg"></asp:imagebutton>
									<asp:imagebutton id="ibtnEliminar" runat="server" ImageUrl="../imagenes/bt_eliminar.gif"></asp:imagebutton></TD>
							</TR>
							<TR>
								<TD vAlign="top" bgColor="#f5f5f5">
									<cc1:datagridweb id="dgPagoProgramado" runat="server" CssClass="HeaderGrilla" PageSize="7" ShowFooter="True"
										AllowSorting="True" AutoGenerateColumns="False" RowHighlightColor="#E0E0E0" RowPositionEnabled="False"
										Width="780px" align="center">
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
										<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO" FooterText="TOTAL:"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="IdCronogramaPagoConvenio"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="Orden" HeaderText="Orden"></asp:BoundColumn>
											<asp:BoundColumn DataField="Periodo" SortExpression="PERIODO" HeaderText="PERIODO"></asp:BoundColumn>
											<asp:BoundColumn DataField="MontoProgramado" SortExpression="MontoProgramado" HeaderText="PROGRAMANDO NS"
												DataFormatString="{0:# ### ### ##0.00}"></asp:BoundColumn>
											<asp:BoundColumn DataField="MontoRecibido" SortExpression="MontoRecibido" HeaderText="RECIBIDO NS"
												DataFormatString="{0:# ### ### ##0.00}"></asp:BoundColumn>
											<asp:BoundColumn DataField="MontoPendiente" SortExpression="MontoPendiente" HeaderText="PENDIENTE NS"
												DataFormatString="{0:# ### ### ##0.00}"></asp:BoundColumn>
											<asp:TemplateColumn HeaderText="OBS">
												<ItemTemplate>
													<asp:ImageButton id="ibtnObservaciones" runat="server" ImageUrl="../imagenes/BtPU_Mas.gif"></asp:ImageButton>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
									</cc1:datagridweb><BR>
								</TD>
							</TR>
							<TR>
								<TD vAlign="top" align="center" bgColor="#f5f5f5"><asp:label id="lblResultado1" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label></TD>
							</TR>
						</TABLE>
						<TABLE id="Table10" cellSpacing="0" cellPadding="0" width="780" border="0">
							<TR>
								<TD bgColor="#f5f5f5"><asp:label id="lblSubtitulo2" runat="server" CssClass="TituloSecundario">&nbsp;PAGOS FUERA DEL PROGRAMA DE PAGOS</asp:label></TD>
							</TR>
							<TR>
								<TD align="right" bgColor="#f5f5f5">
									<asp:imagebutton id="ibtnPagoFueraPrograma" runat="server" ImageUrl="../imagenes/btnPagoFueraCronograma.jpg"></asp:imagebutton>
									<asp:imagebutton id="ibtnEliminarPN" runat="server" ImageUrl="../imagenes/bt_eliminar.gif"></asp:imagebutton></TD>
							</TR>
							<TR>
								<TD bgColor="#f5f5f5">
									<cc1:datagridweb id="dgPagoNoProgramado" runat="server" CssClass="HeaderGrilla" PageSize="7" ShowFooter="True"
										AllowSorting="True" AutoGenerateColumns="False" RowHighlightColor="#E0E0E0" RowPositionEnabled="False"
										Width="780px" align="center">
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
										<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO" FooterText="TOTAL:"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="IdCronogramaPagoConvenio" SortExpression="IdCronogramaPagoConvenio"
												HeaderText="IdCronogramaPagoConvenio"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="Orden" HeaderText="Orden"></asp:BoundColumn>
											<asp:BoundColumn DataField="Periodo" SortExpression="Periodo" HeaderText="PERIODO"></asp:BoundColumn>
											<asp:BoundColumn DataField="MontoRecibido" HeaderText="RECIBIDO NS" DataFormatString="{0:# ### ### ##0.00}"></asp:BoundColumn>
											<asp:TemplateColumn HeaderText="OBS">
												<ItemTemplate>
													<asp:ImageButton id="Imagebutton1" runat="server" ImageUrl="../imagenes/BtPU_Mas.gif"></asp:ImageButton>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
									</cc1:datagridweb><BR>
								</TD>
							</TR>
							<TR>
								<TD vAlign="top" align="center"><asp:label id="lblResultado2" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label></TD>
							</TR>
						</TABLE>
						<TABLE id="Table11" cellSpacing="0" cellPadding="0" width="780" border="0">
							<TR>
								<TD style="WIDTH: 632px; HEIGHT: 13px" align="right"><asp:label id="lblTotalRecibido" runat="server" CssClass="normal" Width="128px">TOTAL RECIBIDO NS:&nbsp;</asp:label></TD>
								<TD style="HEIGHT: 13px" align="right"><asp:label id="lblDbTotalRecibido" runat="server" CssClass="TextoAzul" Width="100%">0.00</asp:label></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 6px" align="right"><asp:label id="lblSaldoConvenio" runat="server" CssClass="normal" Width="152px">SALDO CONVENIO NS</asp:label></TD>
								<TD style="HEIGHT: 6px" align="right"><asp:label id="lblDbSaldoConvenio" runat="server" CssClass="TextoAzul" Width="100%">0.00</asp:label></TD>
							</TR>
						</TABLE>
						<TABLE id="Table12" cellSpacing="0" cellPadding="0" width="780" border="0">
							<TR>
								<TD><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../imagenes/atras.gif"><INPUT id="hOrdenGrilla" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="hOrdenGrilla"
										runat="server"><INPUT id="hOrdenGrilla2" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="hOrdenGrilla"
										runat="server"><INPUT id="hCodigo" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="hCodigo"
										runat="server"><INPUT id="hCodigo2" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="hCodigo2"
										runat="server"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</FORM>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
