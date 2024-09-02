<%@ Page language="c#" Codebehind="AdministrarAsociacionOrganismoAccionSubAccion.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionControlInstitucional.AdministrarAsociacionOrganismoAccionSubAccion" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AdministrarAsociacionOrganismoAccionSubAccion</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/Historial.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD colSpan="3"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD colSpan="3"><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="Commands" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio >  Gestión de Control Institucional ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Asociacion de Accion SubAccion</asp:label></TD>
				</TR>
				<TR>
					<TD colSpan="3">
						<DIV align="center">
							<TABLE id="Table4" borderColor="#ffffff" cellSpacing="0" cellPadding="0" width="780" align="center"
								border="1">
								<TR>
									<TD class="TituloPrincipalBlanco" style="HEIGHT: 13px" bgColor="#000080"><asp:label id="Label6" runat="server" CssClass="TituloPrincipalBlanco" Height="14px">ORGANISMO</asp:label></TD>
									<TD style="WIDTH: 278px; HEIGHT: 13px" bgColor="#f0f0f0" colSpan="2"><asp:dropdownlist id="ddblOrganismo" runat="server" CssClass="normaldetalle" Height="70px" AutoPostBack="True"
											Width="318px"></asp:dropdownlist></TD>
									<TD style="HEIGHT: 13px" bgColor="#000080"><asp:label id="Label7" runat="server" CssClass="TituloPrincipalBlanco" Height="14px" Width="122px"> SUB ORGANISMO</asp:label></TD>
									<TD style="HEIGHT: 13px" bgColor="#f0f0f0"><asp:dropdownlist id="ddblSubOrganismo2" runat="server" CssClass="normaldetalle" Height="70px" AutoPostBack="True"
											Width="258px"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 519px" colSpan="3"><cc1:datagridweb id="gridSubOrganismo" runat="server" CssClass="HeaderGrilla" Width="400px" RowPositionEnabled="False"
											RowHighlightColor="#E0E0E0" AllowPaging="True" AutoGenerateColumns="False" AllowSorting="True" PageSize="7" ShowFooter="True">
											<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
											<ItemStyle CssClass="ItemGrilla"></ItemStyle>
											<FooterStyle CssClass="FooterGrilla"></FooterStyle>
											<Columns>
												<asp:TemplateColumn HeaderText="NRO">
													<HeaderStyle Width="10%"></HeaderStyle>
													<ItemTemplate>
														<asp:Button id="Button1" runat="server" CssClass="normalDetalle" Width="10px" Text="Button"
															BorderColor="Transparent" BackColor="Transparent" BorderStyle="None"></asp:Button>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:BoundColumn DataField="descripcion" SortExpression="descripcion" HeaderText="Sub Organismo">
													<HeaderStyle Width="90%"></HeaderStyle>
												</asp:BoundColumn>
											</Columns>
											<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
										</cc1:datagridweb></TD>
									<TD colSpan="2"><cc1:datagridweb id="gridAccionControl" runat="server" CssClass="HeaderGrilla" Width="388px" RowPositionEnabled="False"
											RowHighlightColor="#E0E0E0" AllowPaging="True" AutoGenerateColumns="False" AllowSorting="True" PageSize="7"
											ShowFooter="True">
											<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
											<ItemStyle CssClass="ItemGrilla"></ItemStyle>
											<FooterStyle CssClass="FooterGrilla"></FooterStyle>
											<Columns>
												<asp:TemplateColumn HeaderText="NRO">
													<HeaderStyle Width="10%"></HeaderStyle>
													<ItemTemplate>
														<asp:Button id="Button2" runat="server" CssClass="normalDetalle" Width="10px" Text="Button"
															BorderColor="Transparent" BackColor="Transparent" BorderStyle="None"></asp:Button>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:BoundColumn DataField="descripcion" SortExpression="descripcion" HeaderText="ACCION DE CONTROL">
													<HeaderStyle Width="90%"></HeaderStyle>
												</asp:BoundColumn>
											</Columns>
											<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
										</cc1:datagridweb></TD>
								</TR>
								<TR>
									<TD colSpan="3">
										<P align="center"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label></P>
									</TD>
									<TD style="HEIGHT: 6px" colSpan="2">
										<P align="center"><asp:label id="lblResultado2" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label></P>
									</TD>
								</TR>
								<TR>
									<TD colSpan="3">
										<TABLE class="normal" id="Table5" borderColor="#ffffff" cellSpacing="0" cellPadding="0"
											width="100%" align="center" border="1">
											<TR>
												<TD class="TituloPrincipalBlanco" style="HEIGHT: 18px" align="left" width="475" bgColor="#000080"
													colSpan="5"><asp:label id="Label13" runat="server" CssClass="TituloPrincipalBlanco" Height="14px"> ORGANISMO - SUB ORGANISMO</asp:label></TD>
											</TR>
											<TR>
												<TD class="normal" style="WIDTH: 2px" bgColor="#335eb4"><asp:label id="Label12" runat="server" CssClass="TextoBlanco"> ORGANISMO:</asp:label></TD>
												<TD class="normalDetalle" id="CellOrganismo" style="HEIGHT: 15px" bgColor="#f0f0f0"
													colSpan="4" runat="server"><asp:dropdownlist id="ddblOrganismo2" runat="server" CssClass="normaldetalle" Height="70px" Width="268px"
														Enabled="False"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="normal" style="WIDTH: 2px" bgColor="#335eb4"><asp:label id="Label11" runat="server" CssClass="TextoBlanco" Width="120px"> SUB ORGANISMO:</asp:label></TD>
												<TD class="normalDetalle" style="HEIGHT: 15px" bgColor="#f0f0f0" colSpan="4"><asp:dropdownlist id="ddblSubOrganismo" runat="server" CssClass="normaldetalle" Height="70px" AutoPostBack="True"
														Width="267px" Enabled="False"></asp:dropdownlist></TD>
											</TR>
										</TABLE>
									</TD>
									<TD colSpan="2">
										<TABLE class="normal" id="Table3" borderColor="#ffffff" cellSpacing="0" cellPadding="0"
											width="100%" align="center" border="1">
											<TR>
												<TD class="TituloPrincipalBlanco" style="HEIGHT: 18px" align="left" width="475" bgColor="#000080"
													colSpan="5"><asp:label id="Label3" runat="server" CssClass="TituloPrincipalBlanco" Height="14px">SUB ORGANISMO - ACCION DE CONTROL</asp:label></TD>
											</TR>
											<TR>
												<TD class="normal" style="WIDTH: 2px" bgColor="#335eb4"><asp:label id="Label2" runat="server" CssClass="TextoBlanco" Width="125px"> SUB - ORGANISMO:</asp:label></TD>
												<TD class="normal" id="CellSubOrganismo" style="HEIGHT: 15px" bgColor="#f0f0f0" colSpan="4"
													runat="server"><asp:dropdownlist id="ddblSubOrganismo3" runat="server" CssClass="normaldetalle" Height="70px" Width="237px"
														Enabled="False"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="normal" style="WIDTH: 2px" bgColor="#335eb4"><asp:label id="Label1" runat="server" CssClass="TextoBlanco" Width="120px">ACCION DE CONTROL:</asp:label></TD>
												<TD class="normalDetalle" style="HEIGHT: 15px" bgColor="#f0f0f0" colSpan="4"><asp:dropdownlist id="ddblAccionControl" runat="server" CssClass="normaldetalle" Height="70px" Width="237px"
														Enabled="False"></asp:dropdownlist></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
						</DIV>
						<DIV align="center"></DIV>
						<DIV align="center">
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="385" align="center" border="0">
								<TR>
									<TD>
										<P align="right"><asp:imagebutton id="ibtnAceptar" runat="server" Height="22px" ImageUrl="../imagenes/bt_aceptar.gif"></asp:imagebutton></P>
									</TD>
									<TD><IMG id="ibtnCancelar" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../imagenes/bt_cancelar.gif"
											runat="server"></TD>
								</TR>
							</TABLE>
						</DIV>
						<INPUT id="hOrdenGrilla" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="hOrdenGrilla"
							runat="server"><INPUT id="hGridPagina" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" value="0"
							name="hGridPagina" runat="server"> <INPUT id="hCodigo" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="hCodigo"
							runat="server"><INPUT id="hIdCabeceraTablaTablas" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1"
							name="hIdCabeceraTablaTablas" runat="server"><INPUT id="hCodigo2" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="hCodigo2"
							runat="server"><INPUT id="hIdCabeceraTablaTablas2" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1"
							name="hIdCabeceraTablaTablas2" runat="server">
					</TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
