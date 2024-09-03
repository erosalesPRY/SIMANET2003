<%@ Page language="c#" Codebehind="AdministrarHistorialInduccionSI.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionSeguridadIndustrial.AdministrarHistorialInduccionSI" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Administrar Programación Trabajadores Contratista</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../styles.css">
		<SCRIPT language="javascript" src="/SimaNetWeb/js/@Import.js"></SCRIPT>
		<script type="text/javascript" src="/SimaNetWeb/js/Busqueda/scripts/AutoBusqueda.js"></script>
		<script type="text/javascript" src="/SimaNetWeb/js/RegEXT.js"></script>
	</HEAD>
	<body onkeypress="if(event.keyCode==13)return false;" onunload="SubirHistorial();" onload="ObtenerHistorial();"
		bottomMargin="0" leftMargin="0" rightMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" border="0" cellSpacing="0" cellPadding="0" width="100%">
				<TR>
					<TD><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 26px"><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="commands"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio >Gestión de seguridad></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> > Administración examen medico historia></asp:label></TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE id="Table2" border="0" cellSpacing="0" cellPadding="0" width="704" style="WIDTH: 404px">
							<TR>
								<TD style="HEIGHT: 28px" bgColor="#000080" vAlign="middle" align="center">
									<asp:label style="Z-INDEX: 0" id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco"
										Height="11px" Width="330px">LISTADO EVALUACION DE INDUCCION A PERSONAL</asp:label></TD>
							</TR>
							<TR>
								<TD vAlign="top" align="left">
									<TABLE id="Table5" border="0" cellSpacing="1" cellPadding="1" width="100%" align="left">
										<TR>
											<TD class="HeaderGrilla" noWrap>
												<asp:Label style="Z-INDEX: 0" id="Label1" runat="server" CssClass="HeaderGrilla" Height="8px">Apellidos y Nombres :</asp:Label></TD>
											<TD width="100%">
												<asp:Label style="Z-INDEX: 0" id="lblTrabajador" runat="server" Height="8px" CssClass="normaldetalle"></asp:Label></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD style="BORDER-TOP: gray 1px solid" vAlign="top" align="right">
									<TABLE id="Table4" border="0" cellSpacing="1" cellPadding="1" width="300" align="right">
										<TR>
											<TD></TD>
											<TD align="right"><asp:imagebutton style="Z-INDEX: 0" id="ibtnAgregar" runat="server" ImageUrl="../imagenes/bt_agregar.gif"></asp:imagebutton></TD>
											<TD align="right"><asp:imagebutton style="Z-INDEX: 0" id="ibtnEliminar" runat="server" ImageUrl="../imagenes/bt_eliminar.gif"></asp:imagebutton></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD vAlign="top" width="1%" align="left"><cc1:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" AllowPaging="True" PageSize="50"
										ShowFooter="True" RowPositionEnabled="False" RowHighlightColor="#E0E0E0" AutoGenerateColumns="False" AllowSorting="True" Height="1px"
										Width="100%">
										<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO">
												<HeaderStyle Width="1%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle HorizontalAlign="Left"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Nota" HeaderText="NOTA">
												<HeaderStyle Width="2%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="APROBADO">
												<HeaderStyle Width="1%"></HeaderStyle>
												<ItemTemplate>
													<asp:CheckBox id="ChkAprobado" runat="server" Text=" "></asp:CheckBox>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn>
												<HeaderStyle Width="3%"></HeaderStyle>
												<HeaderTemplate>
													<TABLE id="Table3" border="0" cellSpacing="0" cellPadding="0" width="100%" align="left"
														height="100%">
														<TR>
															<TD style="BORDER-BOTTOM: gainsboro 1px solid" colSpan="2" align="center">
																<asp:Label id="LBLFECHA" runat="server" CssClass="HeaderGrilla" Height="14px" BorderStyle="None">FECHA</asp:Label></TD>
														</TR>
														<TR>
															<TD width="50%" noWrap align="center">
																<asp:Label id="Label12" runat="server" CssClass="HeaderGrilla" Height="14px" BorderStyle="None">INICIO</asp:Label></TD>
															<TD style="BORDER-LEFT: gainsboro 1px solid" width="50%" noWrap align="center">
																<asp:Label id="Label22" runat="server" CssClass="HeaderGrilla" Height="9px" BorderStyle="None">VENCIMIENTO</asp:Label></TD>
														</TR>
													</TABLE>
												</HeaderTemplate>
												<ItemTemplate>
													<TABLE id="Table7" border="0" cellSpacing="0" cellPadding="0" width="100%" align="left">
														<TR>
															<TD noWrap align="center">
																<asp:Label id="lblFechaInicio" runat="server" CssClass="normaldetalle">Label</asp:Label></TD>
															<TD style="BORDER-LEFT: gainsboro 1px solid" noWrap align="center">
																<asp:Label id="lblFechaVence" runat="server" CssClass="normaldetalle">Label</asp:Label></TD>
														</TR>
													</TABLE>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn DataField="Disponible" HeaderText="DISPONIBLE">
												<HeaderStyle Width="1%"></HeaderStyle>
											</asp:BoundColumn>
										</Columns>
										<PagerStyle HorizontalAlign="Center" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb></TD>
							</TR>
							<TR>
								<TD bgColor="#f0f0f0" align="center"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" DESIGNTIMEDRAGDROP="55"
										Visible="False"></asp:label></TD>
							</TR>
							<TR>
								<TD colSpan="4" align="left"><IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../imagenes/atras.gif"><INPUT style="Z-INDEX: 0; WIDTH: 16px; HEIGHT: 16px" id="hPeriodo" size="1" type="hidden"
										name="hGridPagina" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 16px; HEIGHT: 16px" id="hIdevaluacion" value="0" size="1"
										type="hidden" name="hGridPagina" runat="server"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="DISPLAY: block" align="center"></TD>
				</TR>
			</TABLE>
			<SCRIPT>
				<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
				
			</SCRIPT>
		</form>
	</body>
</HTML>
