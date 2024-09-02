<%@ Register TagPrefix="cc2" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Page language="c#" Codebehind="ConsultarDetalleAdquisicionesTerceros.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.DirectorioEjecutivo.Directorio.ConsultarDetalleAdquisicionesTerceros" %>
<%@ Register TagPrefix="cc1" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>
		<LINK href="SimanetWeb/styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onload="ObtenerHistorial();"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD colSpan="3" vAlign="top">
						<uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD colSpan="3" vAlign="top">
						<uc1:menu id="Menu2" runat="server"></uc1:menu></TD>
				</TR>
				<tr>
					<td vAlign="top" align="center">
						<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<TR>
								<TD class="Commands" style="HEIGHT: 12px" colSpan="3">
									<asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Legal></asp:label>
									<asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Consultar Detalle de Adquisiciones</asp:label></TD>
							</TR>
							<TR>
								<TD align="center" class="normal" vAlign="top">
									<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="776" align="center" border="1"
										borderColor="#ffffff">
										<TR>
											<TD class="normal" bgColor="#000080" width="30"></TD>
											<TD class="normal" bgColor="#000080" colSpan="5"></TD>
										</TR>
										<TR>
											<TD class="normal" bgColor="#335eb4" width="30">
												<asp:Label id="Label2" runat="server" CssClass="TextoBlanco">Fecha :</asp:Label></TD>
											<TD class="normal" bgColor="#dddddd" colSpan="5">
												<asp:TextBox id="txtFecha" runat="server" CssClass="normaldetalle" BorderWidth="0px" BackColor="Transparent"
													ReadOnly="True" Width="100px"></asp:TextBox></TD>
										</TR>
										<TR>
											<TD class="normal" bgColor="#335eb4" width="30">
												<asp:label id="Label6" runat="server" CssClass="TextoBlanco" Width="120px">Concepto:</asp:label></TD>
											<TD class="normal" bgColor="#f0f0f0" colSpan="5">
												<asp:textbox id="txtConcepto" runat="server" CssClass="normaldetalle" ReadOnly="True" Width="100%"
													BackColor="Transparent" BorderWidth="0px" TextMode="MultiLine" Height="48px"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="normal" bgColor="#335eb4" width="30">
												<asp:label id="Label5" runat="server" CssClass="TextoBlanco" Width="120px">Proveedor:</asp:label></TD>
											<TD class="normal" bgColor="#dddddd" colSpan="5">
												<asp:textbox id="txtProveedor" runat="server" CssClass="normaldetalle" ReadOnly="True" Width="100%"
													BackColor="Transparent" BorderWidth="0px"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="normal" width="30" bgColor="#335eb4">
												<asp:label id="Label12" runat="server" CssClass="TextoBlanco" Width="120px">Mercado:</asp:label></TD>
											<TD class="normal" bgColor="#f0f0f0" colSpan="5">
												<asp:textbox id="txtMercado" runat="server" CssClass="normaldetalle" Width="100%" ReadOnly="True"
													BackColor="Transparent" BorderWidth="0px"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="normal" bgColor="#335eb4" width="30">
												<asp:label id="Label8" runat="server" CssClass="TextoBlanco" Width="120px">Moneda:</asp:label></TD>
											<TD class="normal" bgColor="#dddddd" colSpan="5">
												<asp:textbox id="txtMoneda" runat="server" CssClass="normaldetalle" BorderWidth="0px" BackColor="Transparent"
													ReadOnly="True" Width="100%"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="normal" bgColor="#335eb4" width="30">
												<asp:label id="Label9" runat="server" CssClass="TextoBlanco" Width="120px">Monto:</asp:label></TD>
											<TD class="normal" bgColor="#f0f0f0" colSpan="5">
												<asp:textbox id="txtMonto" runat="server" CssClass="normaldetalle" BorderWidth="0px" BackColor="Transparent"
													ReadOnly="True" Width="100%"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="normal" bgColor="#335eb4" width="30">
												<asp:Label id="Label1" runat="server" CssClass="TextoBlanco">C.O. :</asp:Label></TD>
											<TD class="normal" bgColor="#dddddd" colSpan="5">
												<asp:TextBox id="txtCentroOperativo" runat="server" CssClass="normaldetalle" BorderWidth="0px"
													BackColor="Transparent" ReadOnly="True" Width="100px"></asp:TextBox></TD>
										</TR>
										<TR>
											<TD class="normal" bgColor="#335eb4" width="30">
												<asp:Label id="Label3" runat="server" CssClass="TextoBlanco"> Proyecto:</asp:Label></TD>
											<TD class="normal" bgColor="#f0f0f0" colSpan="5">
												<asp:TextBox id="txtProyecto" runat="server" CssClass="normaldetalle" ReadOnly="True" Width="100%"
													BackColor="Transparent" BorderWidth="0px" Height="48px" TextMode="MultiLine"></asp:TextBox></TD>
										</TR>
										<TR>
											<TD class="normal" bgColor="#335eb4" width="30">
												<asp:label id="Label4" runat="server" CssClass="TextoBlanco">Nro. Contrato:</asp:label></TD>
											<TD class="normal" bgColor="#dddddd">
												<asp:textbox id="txtNroContrato" runat="server" CssClass="normaldetalle" BorderWidth="0px" BackColor="Transparent"
													ReadOnly="True"></asp:textbox></TD>
											<TD class="normal" bgColor="#335eb4">
												<asp:label id="Label10" runat="server" CssClass="TextoBlanco" Width="100%">Fecha Contrato:</asp:label></TD>
											<TD class="normal" bgColor="#dddddd">
												<asp:textbox id="txtFechaContrato" runat="server" CssClass="normaldetalle" Width="80px" ReadOnly="True"
													BackColor="Transparent" BorderWidth="0px"></asp:textbox></TD>
											<TD class="normal" style="WIDTH: 93px" bgColor="#335eb4">
												<asp:label id="Label11" runat="server" CssClass="TextoBlanco">Fecha Término:</asp:label></TD>
											<TD class="normal" bgColor="#dddddd">
												<asp:textbox id="txtFechaTermino" runat="server" CssClass="normaldetalle" ReadOnly="True" BackColor="Transparent"
													BorderWidth="0px"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="normal" bgColor="#335eb4" width="30">
												<asp:label id="lblFechaTermino" runat="server" CssClass="TextoBlanco" Width="80px">Nro. Orden:</asp:label></TD>
											<TD class="normal" bgColor="#f0f0f0">
												<asp:textbox id="txtNroOrden" runat="server" CssClass="normaldetalle" ReadOnly="True" BackColor="Transparent"
													BorderWidth="0px"></asp:textbox></TD>
											<TD class="normal" bgColor="#335eb4">
												<asp:label id="lblFechaInicio" runat="server" CssClass="TextoBlanco" Width="100%">Fecha Orden:</asp:label></TD>
											<TD class="normal" bgColor="#f0f0f0" colSpan="1">
												<asp:textbox id="txtFechaOrden" runat="server" CssClass="normaldetalle" BorderWidth="0px" BackColor="Transparent"
													ReadOnly="True" Width="80px"></asp:textbox></TD>
											<TD class="normal" style="WIDTH: 93px" bgColor="#335eb4">
												<asp:label id="Label7" runat="server" CssClass="TextoBlanco">Tipo Orden:</asp:label></TD>
											<TD class="normal" bgColor="#f0f0f0">
												<asp:textbox id="txtTipoOrden" runat="server" CssClass="normaldetalle" BorderWidth="0px" BackColor="Transparent"
													ReadOnly="True"></asp:textbox></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
						<TABLE width="780">
							<TR>
								<TD align="left" width="700"><IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"
										style="CURSOR: hand"></TD>
							</TR>
						</TABLE>
					</td>
				</tr>
			</TABLE>
			</TD></TR></TABLE>
			<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			</SCRIPT>
		</form>
	</body>
</HTML>
