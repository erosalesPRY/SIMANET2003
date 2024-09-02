<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="cc1" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc2" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Page language="c#" Codebehind="DetalleActividadCtrl.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionControlInstitucional.DetalleActividadCtrl" %>
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
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
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
						<TABLE id="tabla2" cellSpacing="0" cellPadding="0" width="760" border="0">
							<TR>
								<TD class="Commands" align="left" colSpan="6"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio >Gestión de Control Institucional ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Detalle Administracion de Acciones de Control Posterior ></asp:label></TD>
							</TR>
							<TR>
								<TD class="normal" align="center" colSpan="6" height="20"><asp:label id="lblMensaje" runat="server" CssClass="normal"></asp:label>
									<TABLE id="Table4" cellSpacing="1" cellPadding="1" width="760" border="1" borderColor="#ffffff">
										<TR>
											<TD style="WIDTH: 760px" width="760" bgColor="#000080" colSpan="7"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco" Width="406px"></asp:label></TD>
										</TR>
										<TR class="AlternateItemDetalle">
											<TD width="108" bgColor="#335eb4" rowSpan="2"><asp:label id="lblCodigo" runat="server" CssClass="TextoBlanco" Width="80px"> CÓDIGO :</asp:label></TD>
											<TD align="center" width="108"><asp:label id="lblTipoOrgano" runat="server" CssClass="TituloPrincipalBlanco" Width="80px"
													ForeColor="Navy">ORGANO</asp:label></TD>
											<TD align="center" width="108"><asp:label id="lblOrgInfo" runat="server" CssClass="TituloPrincipalBlanco" Width="80px" ForeColor="Navy">INFORMANTE</asp:label></TD>
											<TD align="center" width="108"><asp:label id="lblAno" runat="server" CssClass="TituloPrincipalBlanco" Width="80px" ForeColor="Navy">AÑO</asp:label></TD>
											<TD align="center" width="108"><asp:label id="lblCorrelativo" runat="server" CssClass="TituloPrincipalBlanco" Width="80px"
													ForeColor="Navy">CORRELATIVO</asp:label></TD>
											<TD width="108"></TD>
											<TD style="WIDTH: 13px" width="13"></TD>
										</TR>
										<TR class="AlternateItemDetalle">
											<TD align="center" width="108" id="CellddlbTipOrgano" runat="server"><asp:dropdownlist id="ddlbTipOrgano" runat="server" CssClass="normaldetalle" Width="80px"></asp:dropdownlist></TD>
											<TD align="center" width="108" id="CellddlbOrganoInformante" runat="server"><asp:dropdownlist id="ddlbOrganoInformante" runat="server" CssClass="normaldetalle" Width="80px"></asp:dropdownlist></TD>
											<TD align="center" width="108" id="CellddlbAno" runat="server"><asp:dropdownlist id="ddlbAno" runat="server" CssClass="normaldetalle" Width="80px"></asp:dropdownlist></TD>
											<TD align="center" width="108"><asp:textbox id="txtCorrelativo" runat="server" CssClass="normal" Width="80px" MaxLength="10000"></asp:textbox></TD>
											<TD width="108"></TD>
											<TD style="WIDTH: 13px" width="13">
												<cc1:requireddomvalidator id="rfvCorrelativo" runat="server" ControlToValidate="txtCorrelativo">*</cc1:requireddomvalidator></TD>
										</TR>
										<TR class="ItemDetalle">
											<TD align="left" width="108" bgColor="#335eb4"><asp:label id="lblDenominacion" runat="server" CssClass="TextoBlanco" Width="112px">DENOMINACION :</asp:label></TD>
											<TD align="left" colSpan="5"><asp:textbox id="txtDenominacion" runat="server" CssClass="normal" Width="600px" MaxLength="10000"
													TextMode="MultiLine" Height="32px"></asp:textbox></TD>
											<TD style="WIDTH: 13px" width="13">
												<cc1:RequiredDomValidator id="rfvDenominacion" runat="server" ControlToValidate="txtDenominacion">*</cc1:RequiredDomValidator></TD>
										</TR>
										<TR class="AlternateItemDetalle">
											<TD align="left" width="108" bgColor="#335eb4" style="HEIGHT: 18px"><asp:label id="lblUnidadMedida" runat="server" CssClass="TextoBlanco" Width="112px">UNIDAD MEDIDA :</asp:label></TD>
											<TD align="center" width="108" id="CellddlbUnidadMedida" colSpan="5" runat="server"><asp:dropdownlist id="ddlbUnidadMedida" runat="server" CssClass="normaldetalle" Width="230px"></asp:dropdownlist></TD>
											<TD style="WIDTH: 13px; HEIGHT: 18px" width="13">
												<cc1:requireddomvalidator id="rfvUnidadMedida" runat="server" ControlToValidate="txtDenominacion">*</cc1:requireddomvalidator></TD>
										</TR>
										<TR class="ItemDetalle">
											<TD bgColor="#335eb4"><asp:label id="Label14" runat="server" CssClass="TextoBlanco" Width="112px">NÚMERO DE H/H :</asp:label></TD>
											<TD colSpan="5"><asp:textbox id="txtNroHH" runat="server" CssClass="normal" Width="80px" MaxLength="10000"></asp:textbox></TD>
											<TD>
												<cc1:requireddomvalidator id="rfvNroHH" runat="server" ControlToValidate="txtNroHH">*</cc1:requireddomvalidator></TD>
										</TR>
										<TR class="AlternateItemDetalle">
											<TD bgColor="#335eb4" rowSpan="2"><asp:label id="lblMeta" runat="server" CssClass="TextoBlanco" Width="112px">META :</asp:label></TD>
											<TD align="center"><asp:label id="Label10" runat="server" CssClass="TituloPrincipalBlanco" Width="90px" ForeColor="Navy">1ER TRIMESTRE</asp:label></TD>
											<TD align="center"><asp:label id="Label11" runat="server" CssClass="TituloPrincipalBlanco" Width="95px" ForeColor="Navy">2DO TRIMESTRE</asp:label></TD>
											<TD align="center"><asp:label id="Label12" runat="server" CssClass="TituloPrincipalBlanco" Width="95px" ForeColor="Navy">3ER TRIMESTRE</asp:label></TD>
											<TD align="center"><asp:label id="Label13" runat="server" CssClass="TituloPrincipalBlanco" Width="100px" ForeColor="Navy">4TO TRIMESTRE</asp:label></TD>
											<TD></TD>
											<TD></TD>
										</TR>
										<TR class="AlternateItemDetalle">
											<TD align="center"><asp:textbox id="txtMeta1erTrimestre" runat="server" CssClass="normal" Width="80px" MaxLength="10000"></asp:textbox>
												<cc1:requireddomvalidator id="rfvMeta1erTrim" runat="server" ControlToValidate="txtMeta1erTrimestre">*</cc1:requireddomvalidator></TD>
											<TD align="center"><asp:textbox id="txtMeta2doTrimestre" runat="server" CssClass="normal" Width="80px" MaxLength="10000"></asp:textbox>
												<cc1:requireddomvalidator id="rfvMeta2doTrim" runat="server" ControlToValidate="txtMeta2doTrimestre">*</cc1:requireddomvalidator></TD>
											<TD align="center"><asp:textbox id="txtMeta3erTrimestre" runat="server" CssClass="normal" Width="80px" MaxLength="10000"></asp:textbox>
												<cc1:requireddomvalidator id="rfvMeta3erTrim" runat="server" ControlToValidate="txtMeta3erTrimestre">*</cc1:requireddomvalidator></TD>
											<TD align="center"><asp:textbox id="txtMeta4toTrimestre" runat="server" CssClass="normal" Width="80px" MaxLength="10000"></asp:textbox>
												<cc1:requireddomvalidator id="rfvMeta4toTrim" runat="server" ControlToValidate="txtMeta4toTrimestre">*</cc1:requireddomvalidator></TD>
											<TD></TD>
											<TD></TD>
										</TR>
										<TR class="ItemDetalle">
											<TD align="left" bgColor="#335eb4"><asp:label id="lblCronograma" runat="server" CssClass="TextoBlanco">Cronograma:</asp:label></TD>
											<TD align="left" colSpan="5">
												<TABLE class="normal" id="Table3" cellSpacing="0" cellPadding="0" width="336" border="1"
													borderColor="#ffffff">
													<TR>
														<TD><asp:checkbox id="chkEne" runat="server" Text="Ene"></asp:checkbox></TD>
														<TD><asp:checkbox id="chkFeb" runat="server" Text="Feb"></asp:checkbox></TD>
														<TD><asp:checkbox id="chkMar" runat="server" Text="Mar"></asp:checkbox></TD>
														<TD><asp:checkbox id="chkAbr" runat="server" Text="Abr"></asp:checkbox></TD>
														<TD><asp:checkbox id="chkMay" runat="server" Text="May"></asp:checkbox></TD>
														<TD><asp:checkbox id="chkJun" runat="server" Text="Jun"></asp:checkbox></TD>
													</TR>
													<TR>
														<TD><asp:checkbox id="chkJul" runat="server" Text="Jul"></asp:checkbox></TD>
														<TD><asp:checkbox id="chkAgo" runat="server" Text="Ago"></asp:checkbox></TD>
														<TD><asp:checkbox id="chkSep" runat="server" Text="Sep"></asp:checkbox></TD>
														<TD><asp:checkbox id="chkOct" runat="server" Text="Oct"></asp:checkbox></TD>
														<TD><asp:checkbox id="chkNov" runat="server" Text="Nov"></asp:checkbox></TD>
														<TD><asp:checkbox id="chkDic" runat="server" Text="Dic"></asp:checkbox></TD>
													</TR>
												</TABLE>
											</TD>
											<TD></TD>
										</TR>
										<TR>
											<TD align="right" colSpan="7">
												<TABLE id="Table2" cellSpacing="0" cellPadding="0" border="1" borderColor="#ffffff">
													<TR>
														<TD><asp:imagebutton id="ibtnAceptar" runat="server" Height="22px" ImageUrl="../imagenes/bt_aceptar.gif"></asp:imagebutton></TD>
														<TD><IMG id="ibtnCancelar" onclick="HistorialIrAtras();" alt="" src="../imagenes/bt_cancelar.gif"
																runat="server"></TD>
														<TD id="TdCeldaCancelar" runat="server"><IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../imagenes/atras.gif"></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD align="left" colSpan="7">
									<cc1:domvalidationsummary id="vSum" runat="server" Height="52px" ShowMessageBox="True" DisplayMode="List"
										EnableClientScript="False"></cc1:domvalidationsummary></TD>
							</TR>
						</TABLE>
					</td>
				</tr>
			</table>
			</TD></TR></TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
