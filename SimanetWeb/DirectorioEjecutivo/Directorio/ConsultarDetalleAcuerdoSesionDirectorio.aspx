<%@ Register TagPrefix="cc2" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Page language="c#" Codebehind="ConsultarDetalleAcuerdoSesionDirectorio.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.DirectorioEjecutivo.Directorio.ConsultarDetalleAcuerdoSesionDirectorio" %>
<%@ Register TagPrefix="cc1" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
	
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onload="ObtenerHistorial();"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD colSpan="3" vAlign="top"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD colSpan="3" vAlign="top">
						<uc1:menu id="Menu2" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<td vAlign="top">
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<TR>
								<TD style="HEIGHT: 461px"></TD>
								<TD style="HEIGHT: 461px" align="center"></TD>
								<TD align="center" vAlign="top">
									<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
										<TR>
											<TD class="Commands" colSpan="3" vAlign="top">
												<asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Legal></asp:label>
												<asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Detalle de Acuerdos</asp:label></TD>
										</TR>
									</TABLE>
									<TABLE id="Table5" borderColor="#ffffff" cellSpacing="0" cellPadding="0" border="1" width="752">
										<TR>
											<TD bgColor="#000080" colSpan="9" height="20">
												<asp:dropdownlist id="ddlbTipoJuicio" runat="server" CssClass="normal" Width="2px" Enabled="False"
													Height="36px" Visible="False"></asp:dropdownlist></TD>
											<TD align="center" height="20"></TD>
										</TR>
										<TR>
											<TD bgColor="#335eb4">
												<asp:label id="lblNroAcuerdo" runat="server" CssClass="TextoBlanco">Nro. de Acuerdo:</asp:label></TD>
											<TD bgColor="#dddddd" colSpan="8" width="780">
												<asp:textbox id="txtNroAcuerdo" runat="server" CssClass="normaldetalle" Width="150px" BackColor="Transparent"
													BorderWidth="0px" MaxLength="1500" ReadOnly="True"></asp:textbox></TD>
										</TR>
										<TR>
											<TD bgColor="#335eb4">
												<asp:label id="Label1" runat="server" CssClass="TextoBlanco">Fecha:</asp:label></TD>
											<TD width="780" bgColor="#f0f0f0" colSpan="8">
												<asp:textbox id="txtFechaAcuerdo" runat="server" CssClass="normaldetalle" Width="150px" ReadOnly="True"
													MaxLength="1500" BorderWidth="0px" BackColor="Transparent"></asp:textbox></TD>
										</TR>
										<TR>
											<TD bgColor="#335eb4">
												<asp:label id="lblTema" runat="server" CssClass="TextoBlanco">Asunto:</asp:label></TD>
											<TD bgColor="#dddddd" colSpan="8">
												<asp:textbox id="txtTema" runat="server" CssClass="normaldetalle" Height="50px" Width="100%"
													BackColor="Transparent" BorderWidth="0px" MaxLength="1500" ReadOnly="True" TextMode="MultiLine"></asp:textbox></TD>
										</TR>
										<TR>
											<TD bgColor="#335eb4">
												<asp:label id="Label2" runat="server" CssClass="TextoBlanco">Acuerdo:</asp:label></TD>
											<TD bgColor="#dddddd" colSpan="8">
												<asp:textbox id="txtAcuerdo" runat="server" CssClass="normaldetalle" Height="220px" Width="100%"
													ReadOnly="True" MaxLength="1500" BorderWidth="0px" BackColor="Transparent" TextMode="MultiLine"></asp:textbox><IMG id="ibtnVer" title="Visualizar Anexo" style="CURSOR: hand" alt="" src="../../imagenes/nota.gif"
													runat="server"></TD>
										</TR>
										<TR>
											<TD bgColor="#335eb4">
												<asp:label id="lblSituacion" runat="server" CssClass="TextoBlanco" Width="110px"> Situación:</asp:label></TD>
											<TD bgColor="#f0f0f0" colSpan="8">
												<asp:textbox id="txtSituacion" runat="server" CssClass="normaldetalle" Width="352px" BackColor="Transparent"
													BorderWidth="0px" MaxLength="200" ReadOnly="True"></asp:textbox></TD>
										</TR>
										<TR>
											<TD colSpan="9" align="center">
												<cc2:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" Width="100%" AllowSorting="True"
													ShowFooter="True" PageSize="5" RowPositionEnabled="False" RowHighlightColor="#E0E0E0" AllowPaging="True"
													AutoGenerateColumns="False">
													<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
													<ItemStyle CssClass="ItemGrilla"></ItemStyle>
													<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
													<FooterStyle CssClass="FooterGrilla"></FooterStyle>
													<Columns>
														<asp:BoundColumn HeaderText="NRO">
															<HeaderStyle Width="5%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="FECHAGESTION" SortExpression="FECHAGESTION" HeaderText="FECHA" DataFormatString="{0:dd-MM-yyyy}">
															<HeaderStyle Width="10%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
															<FooterStyle HorizontalAlign="Left"></FooterStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Gestion" SortExpression="Gestion" HeaderText="BITACORA DE GESTION">
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
													</Columns>
													<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
												</cc2:datagridweb></TD>
										</TR>
										<tr>
											<td colspan="9"><IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"
													style="CURSOR: hand"></td>
										</tr>
									</TABLE>
									<TABLE id="Table7" align="left" border="0">
										<TR>
											<TD vAlign="top" align="left">&nbsp;</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</td>
				</TR>
			</TABLE>
			<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			</SCRIPT>
		</form>
	</body>
</HTML>
