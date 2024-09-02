<%@ Register TagPrefix="cc2" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Page language="c#" Codebehind="DetalleAreaCritica.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionControlInstitucional.DetalleAreaCritica" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="cc1" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<meta http-equiv="Page-Enter" content="blendTrans(Duration=1.0)">
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/Historial.js"></SCRIPT>
</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onload="ObtenerHistorial();"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table id="tabla1" cellSpacing="0" cellPadding="0" width="100%">
				<TR>
					<TD colSpan="6"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD colSpan="6"><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<tr>
					<td align="center" colSpan="6">
						<TABLE id="tabla2" cellSpacing="0" cellPadding="0" width="780" border="0">
							<TR>
								<TD class="Commands" align="left" colSpan="6"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio >Gestión de Control Institucional ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Detalle Administracion de Áreas Críticas ></asp:label></TD>
							</TR>
							<TR>
								<TD class="normal" align="center" colSpan="6" height="20">
									<asp:label id="lblMensaje" runat="server" CssClass="normal"></asp:label>
									<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="780" border="1" borderColor="#ffffff">
										<TBODY>
											<TR>
												<TD width="762" bgColor="#000080" colSpan="6" height="25" style="WIDTH: 762px"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco" Width="406px"></asp:label></TD>
											</TR>
											<TR>
												<TD width="130" height="25" bgColor="#335eb4"><asp:label id="lblCodigo" runat="server" CssClass="TextoBlanco" Width="112px"> CÓDIGO :</asp:label></TD>
												<TD width="636" colSpan="5" height="25" bgColor="#dddddd" style="WIDTH: 636px"><asp:textbox id="txtCodigo" runat="server" CssClass="normal" Width="104px" MaxLength="10000"></asp:textbox></TD>
												<TD width="20"><cc1:requireddomvalidator id="rfvCodigo" runat="server" ControlToValidate="txtCodigo">*</cc1:requireddomvalidator></TD>
											</TR>
											<TR>
												<TD width="130" bgColor="#335eb4" height="25">
													<asp:label id="lblGrupo" runat="server" CssClass="TextoBlanco" Width="112px"> GRUPO :</asp:label></TD>
												<TD style="WIDTH: 636px" width="636" bgColor="#f0f0f0" colSpan="5" height="25">
													<asp:dropdownlist id="ddlbGrupo" runat="server" CssClass="normaldetalle" Width="320px"></asp:dropdownlist></TD>
												<TD width="20"><cc1:RequiredDomValidator id="rfvGrupo" runat="server" ControlToValidate="ddlbGrupo">*</cc1:RequiredDomValidator></TD>
								</TD>
							</TR>
							<TR>
								<TD width="130" height="25" bgColor="#335eb4"><asp:label id="lblDenominacion" runat="server" CssClass="TextoBlanco" Width="112px"> DENOMINACIÓN :</asp:label></TD>
								<TD width="636" colSpan="5" height="25" bgColor="#f0f0f0" style="WIDTH: 636px"><asp:textbox id="txtDenominacion" runat="server" CssClass="normaldetalle" Width="620px"></asp:textbox></TD>
								<TD width="20">
									<cc1:requireddomvalidator id="rfvDenominacion" runat="server" ControlToValidate="txtDenominacion">*</cc1:requireddomvalidator></TD>
							</TR>
							<TR>
								<TD width="780" align="right" colSpan="6">
									<TABLE id="Table2" cellSpacing="0" cellPadding="0" border="1" borderColor="#ffffff">
										<TR>
											<TD><asp:imagebutton id="ibtnAceptar" runat="server" Height="22px" ImageUrl="../imagenes/bt_aceptar.gif"></asp:imagebutton></TD>
											<TD><asp:imagebutton id="ibtnCancelar" runat="server" Height="22px" ImageUrl="../imagenes/bt_cancelar.gif"
													CausesValidation="False"></asp:imagebutton></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD align="left" width="780" colSpan="6">
									<TABLE id="Table3" cellSpacing="0" cellPadding="0" border="1" borderColor="#ffffff">
										<TR>
											<TD id="TdCeldaAtras" runat="server"><IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../imagenes/atras.gif"></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD>
								<TD width="130"></TD>
								<TD width="130"></TD>
								<TD width="130"></TD>
								<TD align="center" width="130"></TD>
								<TD align="center" width="121" style="WIDTH: 121px"></TD>
								<TD width="20"></TD>
							</TR>
						</TABLE>
						<cc1:domvalidationsummary id="vSum" runat="server" Height="52px" ShowMessageBox="True" DisplayMode="List"
							EnableClientScript="False"></cc1:domvalidationsummary>
					</td>
				</tr>
			</table></TD></TR></TBODY></TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
