<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="cc2" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Page language="c#" Codebehind="ConsultarDetalleProgramacionActividades.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionControlInstitucional.ConsultarDetalleProgramacionActividades" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/Historial.js"></SCRIPT>
</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD vAlign="top" colSpan="3"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD vAlign="top" colSpan="3"><uc1:menu id="Menu2" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<td vAlign="top">
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<TR>
								<TD style="HEIGHT: 461px"></TD>
								<TD style="HEIGHT: 461px" align="center"></TD>
								<TD vAlign="top" align="center">
									<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
										<TR>
											<TD class="Commands" vAlign="top" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio >  Gestión de Control Institucional ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Registro Programación de Inspecciones</asp:label></TD>
										</TR>
									</TABLE>
									<TABLE id="Table5" borderColor="#ffffff" cellSpacing="0" cellPadding="0" width="752" border="1">
										<TR>
											<TD bgColor="#000080" colSpan="9"><asp:dropdownlist id="ddlbTipoJuicio" runat="server" CssClass="normal" Visible="False" Height="36px"
													Enabled="False" Width="2px"></asp:dropdownlist></TD>
											<TD></TD>
										</TR>
										<TR>
											<TD bgColor="#335eb4">
												<asp:label id="Label1" runat="server" CssClass="TextoBlanco">Nro. Documento:</asp:label></TD>
											<TD bgColor="#dddddd"><asp:textbox id="txtNroDocumento" runat="server" CssClass="normaldetalle" ReadOnly="True" MaxLength="200"
													BorderWidth="0px" BackColor="Transparent"></asp:textbox></TD>
											<TD bgColor="#335eb4">
												<asp:label id="lblFecha" runat="server" CssClass="TextoBlanco">Tipo Documento:</asp:label></TD>
											<TD bgColor="#dddddd"><asp:textbox id="txtTipoDocumento" runat="server" CssClass="normaldetalle" ReadOnly="True" MaxLength="200"
													BorderWidth="0px" BackColor="Transparent"></asp:textbox></TD>
											<TD bgColor="#335eb4">
												<asp:label id="Label4" runat="server" CssClass="TextoBlanco">Fecha Documento:</asp:label></TD>
											<TD bgColor="#dddddd" colSpan="4"><asp:textbox id="txtFechaDocumento" runat="server" CssClass="normaldetalle" ReadOnly="True" MaxLength="200"
													BorderWidth="0px" BackColor="Transparent"></asp:textbox></TD>
										</TR>
										<TR>
											<TD bgColor="#335eb4">
												<asp:label id="Label6" runat="server" CssClass="TextoBlanco">Fecha Inicio:</asp:label></TD>
											<TD bgColor="#f0f0f0"><asp:textbox id="txtFechaInicio" runat="server" CssClass="normaldetalle" ReadOnly="True" BorderWidth="0px"
													BackColor="Transparent"></asp:textbox></TD>
											<TD bgColor="#335eb4">
												<asp:label id="Label7" runat="server" CssClass="TextoBlanco">Fecha Término:</asp:label></TD>
											<TD bgColor="#f0f0f0"><asp:textbox id="txtFechaTermino" runat="server" CssClass="normaldetalle" ReadOnly="True" BorderWidth="0px"
													BackColor="Transparent"></asp:textbox></TD>
											<TD style="HEIGHT: 20px" bgColor="#335eb4">
												<asp:label id="Label2" runat="server" CssClass="TextoBlanco">Area:</asp:label></TD>
											<TD bgColor="#f0f0f0" colSpan="4">
												<asp:textbox id="txtArea" runat="server" CssClass="normaldetalle" BackColor="Transparent" BorderWidth="0px"
													ReadOnly="True"></asp:textbox></TD>
										</TR>
										<TR>
											<TD bgColor="#335eb4">
												<asp:label id="Label9" runat="server" CssClass="TextoBlanco">Situación:</asp:label></TD>
											<TD bgColor="#dddddd" colSpan="8">
												<asp:textbox id="txtSituacion" runat="server" CssClass="normaldetalle" BackColor="Transparent"
													BorderWidth="0px" MaxLength="200" ReadOnly="True"></asp:textbox></TD>
										</TR>
										<TR>
											<TD bgColor="#335eb4" colSpan="1" rowSpan="1">
												<asp:label id="Label8" runat="server" CssClass="TextoBlanco"> Organismo:</asp:label></TD>
											<TD bgColor="#f0f0f0" colSpan="8" rowSpan="1">
												<asp:textbox id="txtOrganismo" runat="server" CssClass="normaldetalle" Width="100%" BackColor="Transparent"
													BorderWidth="0px" ReadOnly="True"></asp:textbox></TD>
										</TR>
										<TR>
											<TD bgColor="#335eb4">
												<asp:label id="Label3" runat="server" CssClass="TextoBlanco">Asunto:</asp:label></TD>
											<TD bgColor="#dddddd" colSpan="8">
												<asp:textbox id="txtAsunto" runat="server" CssClass="normaldetalle" Width="100%" Height="50px"
													BackColor="Transparent" BorderWidth="0px" ReadOnly="True" TextMode="MultiLine"></asp:textbox></TD>
										</TR>
										<TR>
											<TD bgColor="#335eb4">
												<asp:label id="lblConcepto" runat="server" CssClass="TextoBlanco"> Observaciones:</asp:label></TD>
											<TD bgColor="#f0f0f0" colSpan="8">
												<asp:textbox id="txtObservaciones" runat="server" CssClass="normaldetalle" Width="100%" Height="50px"
													BackColor="Transparent" BorderWidth="0px" ReadOnly="True" TextMode="MultiLine"></asp:textbox></TD>
										</TR>
										<TR>
											<TD colSpan="9">
												<cc2:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" Width="776px" AllowSorting="True"
													ShowFooter="True" PageSize="3" RowPositionEnabled="False" RowHighlightColor="#E0E0E0" AllowPaging="True"
													AutoGenerateColumns="False">
<AlternatingItemStyle CssClass="AlternateItemGrilla">
</AlternatingItemStyle>

<ItemStyle CssClass="ItemGrilla">
</ItemStyle>

<HeaderStyle CssClass="HeaderGrilla">
</HeaderStyle>

<FooterStyle CssClass="FooterGrilla">
</FooterStyle>

<Columns>
<asp:BoundColumn HeaderText="NRO">
<HeaderStyle Width="5%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Center">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="FECHAGESTION" SortExpression="FECHAGESTION" HeaderText="FECHA" DataFormatString="{0:dd-MM-yyyy}">
<HeaderStyle Width="10%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Center">
</ItemStyle>

<FooterStyle HorizontalAlign="Left">
</FooterStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="Gestion" SortExpression="Gestion" HeaderText="BITACORA DE GESTION">
<ItemStyle HorizontalAlign="Left">
</ItemStyle>
</asp:BoundColumn>
</Columns>

<PagerStyle CssClass="PagerGrilla" Mode="NumericPages">
</PagerStyle>
												</cc2:datagridweb></TD>
										</TR>
									</TABLE>
									<TABLE id="Table7" width="770" border="0">
										<TR>
											<TD vAlign="top" align="left"><IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../imagenes/atras.gif"
													style="CURSOR: hand">
											</TD>
											<TD></TD>
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
