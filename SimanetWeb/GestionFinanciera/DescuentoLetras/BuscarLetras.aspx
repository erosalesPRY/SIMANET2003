<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Page language="c#" Codebehind="BuscarLetras.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.DescuentoLetras.BuscarLetras" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
	</HEAD>
	<body oncontextmenu="return false" bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();"
		rightMargin="0" onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="right" border="0">
				<TR>
					<TD vAlign="top" width="100%"></TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%">
						<TABLE id="Table3" cellSpacing="1" cellPadding="1" width="759" align="center" border="0">
							<TR>
								<TD style="WIDTH: 55px">
									<asp:label id="Label1" runat="server" CssClass="TextoNegroNegrita" Width="80px" DESIGNTIMEDRAGDROP="37">SITUACION :</asp:label></TD>
								<TD style="WIDTH: 224px"><asp:label id="lblSituacion" runat="server" CssClass="TextoNegroNegrita" Width="584px"></asp:label></TD>
								<TD>
									<P align="justify">&nbsp;</P>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE class="normal" id="Table1" cellSpacing="0" cellPadding="0" width="764" border="0">
							<TR>
								<TD align="center" width="100%" colSpan="3">
									<TABLE style="HEIGHT: 25px" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR bgColor="#f0f0f0">
											<TD style="WIDTH: 12px"><IMG height="22" src="../../imagenes/tab_izq.gif" width="4"></TD>
											<TD style="WIDTH: 78px">
												<asp:label id="Label5" runat="server" CssClass="TextoNegroNegrita" Width="80px">NRO LETRA :</asp:label></TD>
											<TD style="WIDTH: 19px">
												<asp:textbox id="txtLetraNro" runat="server" Width="578px" AutoPostBack="True" CssClass="InputFind"></asp:textbox></TD>
											<TD style="WIDTH: 31px"></TD>
											<TD style="WIDTH: 115px"></TD>
											<TD style="WIDTH: 188px"></TD>
											<TD style="WIDTH: 187px">
												<asp:imagebutton id="btnBuscar" runat="server" Width="87px" ImageUrl="../../imagenes/bt_Buscar.GIF"
													Height="22px"></asp:imagebutton></TD>
											<TD></TD>
											<TD align="right" width="4"><IMG height="22" src="../../imagenes/tab_der.gif" width="4"></TD>
										</TR>
									</TABLE>
									<cc1:datagridweb id="grid" runat="server" Width="765px" ShowFooter="True" RowHighlightColor="#E0E0E0"
										AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True" PageSize="7">
										<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO"></asp:BoundColumn>
											<asp:BoundColumn DataField="NroDocumento" SortExpression="NroDocumento" HeaderText="DOCUMENTO">
												<HeaderStyle VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="AbreviaturaCentroOperativo" SortExpression="AbreviaturaCentroOperativo"
												HeaderText="CO">
												<HeaderStyle VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="NombreProyecto" SortExpression="NombreProyecto" HeaderText="PROYECTO">
												<HeaderStyle VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="RazonSocial" SortExpression="RazonSocial" HeaderText="RAZON SOCIAL">
												<HeaderStyle VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="FECHA">
												<HeaderTemplate>
													<TABLE id="Table5" cellSpacing="1" cellPadding="1" width="100%" align="left" border="0">
														<TR>
															<TD style="BORDER-BOTTOM: #cccccc 1px solid" align="center" colSpan="3">
																<asp:Label id="Label10" runat="server" CssClass="HEADERGRILLA" BorderStyle="None">FECHA</asp:Label></TD>
														</TR>
														<TR>
															<TD align="center" width="33%">
																<asp:Label id="Label9" runat="server" CssClass="HEADERGRILLA" BorderStyle="None">INICIO</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" align="center" width="33%">
																<asp:Label id="Label8" runat="server" CssClass="HEADERGRILLA" DESIGNTIMEDRAGDROP="181" BorderStyle="None">VENCE</asp:Label></TD>
														</TR>
													</TABLE>
												</HeaderTemplate>
												<ItemTemplate>
													<TABLE id="Table7" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
														border="0">
														<TR>
														</TR>
														<TR>
															<TD align="center">
																<asp:Label id="lblFechaInicio" runat="server" CssClass="normaldetalle" Width="54px" DESIGNTIMEDRAGDROP="475"
																	BorderStyle="None">00-00-2005</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" align="center">
																<asp:Label id="lblFechaVence" runat="server" CssClass="normaldetalle" Width="54px" BorderStyle="None">00-00-2005</asp:Label></TD>
														</TR>
													</TABLE>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="DIAS">
												<HeaderTemplate>
													<TABLE id="Table2" height="100%" cellSpacing="1" cellPadding="1" width="100%" align="left"
														border="0">
														<TR>
															<TD style="BORDER-BOTTOM: #cccccc 1px solid" align="center" colSpan="2">
																<asp:Label id="Label2" runat="server" CssClass="HEADERGRILLA" DESIGNTIMEDRAGDROP="327" BorderStyle="None">DIAS</asp:Label></TD>
														</TR>
														<TR>
															<TD align="center">
																<asp:Label id="Label3" runat="server" CssClass="HEADERGRILLA" ToolTip="Nro de Dias de Plazo"
																	DESIGNTIMEDRAGDROP="342" BorderStyle="None">P</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" align="center">
																<asp:Label id="Label4" runat="server" CssClass="HEADERGRILLA" ToolTip="Nro de Dias Restantes para su vencimiento"
																	BorderStyle="None">V</asp:Label></TD>
														</TR>
													</TABLE>
												</HeaderTemplate>
												<ItemTemplate>
													<TABLE id="Table8" height="100%" cellSpacing="1" cellPadding="1" width="100%" align="left"
														border="0">
														<TR>
															<TD align="center">
																<asp:Label id="lblDiasPlazo" runat="server" CssClass="normaldetalle" Width="30px" BorderStyle="None">00</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" align="center">
																<asp:Label id="lblDiasFaltantes" runat="server" CssClass="normaldetalle" Width="30px" DESIGNTIMEDRAGDROP="527"
																	BorderStyle="None">00</asp:Label></TD>
														</TR>
													</TABLE>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn DataField="Moneda" SortExpression="Moneda" HeaderText="M">
												<HeaderStyle VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Monto" SortExpression="Monto" HeaderText="MONTO">
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
										</Columns>
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
							</TR>
							<TR style="DISPLAY: none">
								<TD align="center" width="100%" colSpan="3"><INPUT id="hIdLetra" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hIdTablaEntidad"
										runat="server">
									<asp:textbox id="txtNroDocumento" runat="server" Width="88px" CssClass="normaldetalle" MaxLength="15"></asp:textbox><TEXTAREA class="normaldetalle" id="txtProyecto" style="WIDTH: 632px; HEIGHT: 32px" name="txtProyecto"
										rows="2" readOnly cols="75" runat="server"></TEXTAREA><INPUT class="normaldetalle" id="nTasaInteres" style="WIDTH: 150px; HEIGHT: 22px" readOnly
										type="text" size="19" name="Text1" runat="server">
									<asp:textbox id="txtObservacion" runat="server" Width="100%" CssClass="normaldetalle" Height="44px"
										TextMode="MultiLine"></asp:textbox></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE id="Table6" cellSpacing="1" cellPadding="1" width="768" border="0">
							<TR>
								<TD align="center">
									<asp:imagebutton id="ibtnAceptar" runat="server" ImageUrl="../../imagenes/bt_aceptar.gif"></asp:imagebutton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<IMG id="ibtnCancelar" style="CURSOR: hand" onclick="window.close();" alt="" src="../../imagenes/bt_cancelar.gif"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</table>
			&nbsp;
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			function PonerTexto(){
				if(document.forms[0].hIdLetra.value.length ==0){
					Window.alert("No se ha seleccionado registro");
					
				}
			} 
			
		</SCRIPT>
	</body>
</HTML>
