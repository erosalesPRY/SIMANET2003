<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="cc2" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Page language="c#" Codebehind="DetalleActividadControlEjecucion.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.GestionControlInstitucional.DetalleActividadControlEjecucion" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
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
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="Commands"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión de Control Institucional > </asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual">Detalle de la Ejecucion de las Actividades de Control</asp:label></TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE class="normal" id="Table2" cellSpacing="0" cellPadding="0" width="600" border="1" borderColor=#ffffff>
							<TR>
          <TD bgColor=#000080 colSpan=2>
<asp:label id=lblTitulo runat="server" CssClass="TituloPrincipalBlanco"></asp:label></TD>
								<TD ></TD>
							</TR>
							<TR>
								<TD bgColor="#335eb4"><asp:label id="lblActividadCtrl" runat="server" CssClass="TextoBlanco">Actividad de Control:</asp:label></TD>
								<TD bgColor=#dddddd><asp:textbox id="txtActividadCtrl" runat="server" CssClass="normaldetalle" MaxLength="80" Width="336px"
										ReadOnly="True"></asp:textbox><asp:imagebutton id="ibtnBuscarActividadCtrl" runat="server" CssClass="normaldetalle" ImageUrl="../imagenes/BtPU_Mas.gif"
										CausesValidation="False"></asp:imagebutton></TD>
								<TD>
									<cc2:RequiredDomValidator id="rfvActividadCtrl" runat="server" ControlToValidate="txtActividadCtrl">*</cc2:RequiredDomValidator></TD>
							</TR>
							<TR>
								<TD bgColor="#335eb4"><asp:label id="lblRutaFisica" runat="server" CssClass="TextoBlanco">Nro Meta Programada:</asp:label></TD>
								<TD bgColor=#f0f0f0>
									<ew:numericbox id="nbMetaProgramada" runat="server" CssClass="normaldetalle" MaxLength="6" Width="136px"
										PositiveNumber="True" PlacesBeforeDecimal="4"></ew:numericbox></TD>
								<TD>
									<cc2:RequiredDomValidator id="rfvMetaProgramada" runat="server" ControlToValidate="nbMetaProgramada">*</cc2:RequiredDomValidator></TD>
							</TR>
							<TR>
								<TD bgColor="#335eb4">
									<asp:label id="lblPorcentajeAvanceProgramado" runat="server" CssClass="TextoBlanco">Porcentaje Avance Programado:</asp:label>
								</TD>
								<TD bgColor=#dddddd>
									<ew:numericbox id="nbPorcentajeAvanceProgramado" runat="server" CssClass="normaldetalle" MaxLength="5"
										Width="136px" PositiveNumber="True" PlacesBeforeDecimal="3" DecimalPlaces="2"></ew:numericbox></TD>
								<TD>
									<cc2:RequiredDomValidator id="rfvPorcentajeAvanceProgramado" runat="server" ControlToValidate="nbPorcentajeAvanceProgramado">*</cc2:RequiredDomValidator></TD>
							</TR>
							<TR>
								<TD bgColor="#335eb4"><asp:label id="lblNroUnidadesEjecutadas" runat="server" CssClass="TextoBlanco">Nro Unidades Ejecutadas:</asp:label></TD>
								<TD bgColor=#f0f0f0>
									<ew:numericbox id="nbNroUnidadesEjecutadas" runat="server" CssClass="normaldetalle" MaxLength="4"
										Width="136px" PositiveNumber="True" PlacesBeforeDecimal="4" DecimalPlaces="2" RealNumber="False"></ew:numericbox></TD>
								<TD>
									<cc2:RequiredDomValidator id="rfvNroUnidadesEjecutadas" runat="server" ControlToValidate="nbNroUnidadesEjecutadas">*</cc2:RequiredDomValidator></TD>
							</TR>
							<TR>
								<TD bgColor="#335eb4"><asp:label id="lblPorcentajeAvanceEjecutado" runat="server" CssClass="TextoBlanco">Porcentaje Avance Ejecutado:</asp:label></TD>
								<TD bgColor=#dddddd>
									<ew:numericbox id="nbPorcentajeAvanceEjecutado" runat="server" CssClass="normaldetalle" MaxLength="5"
										Width="136px" PositiveNumber="True" PlacesBeforeDecimal="3" DecimalPlaces="2"></ew:numericbox></TD>
								<TD>
									<cc2:RequiredDomValidator id="rfvPorcentajeAvanceEjecutado" runat="server" ControlToValidate="nbPorcentajeAvanceEjecutado">*</cc2:RequiredDomValidator></TD>
							</TR>
							<TR>
								<TD bgColor="#335eb4" style="HEIGHT: 14px"><asp:label id="lblEstadoCtrl" runat="server" CssClass="TextoBlanco">Estado:</asp:label></TD>
								<TD bgColor=#f0f0f0 id=CellddlbEstadoCtrl style="HEIGHT: 14px" runat="server" class=normaldetalle>
									<asp:DropDownList id="ddlbEstadoCtrl" runat="server" CssClass="normaldetalle" Width="336px"></asp:DropDownList></TD>
								<TD style="HEIGHT: 14px">
									<cc2:RequiredDomValidator id="rfvEstadoCtrl" runat="server" ControlToValidate="ddlbEstadoCtrl">*</cc2:RequiredDomValidator></TD>
							</TR>
							<TR>
								<TD bgColor="#335eb4"><asp:label id="lblCronograma" runat="server" CssClass="TextoBlanco">Cronograma:</asp:label></TD>
								<TD bgColor=#dddddd vAlign=middle align=center>
									<TABLE class="normal" id="Table3" cellSpacing="0" cellPadding="0" width="336" border="1" borderColor=#ffffff bgColor=#ffffff>
										<TR>
											<TD>
												<asp:CheckBox id="chkEne" runat="server" Text="Ene"></asp:CheckBox></TD>
											<TD>
												<asp:CheckBox id="chkFeb" runat="server" Text="Feb"></asp:CheckBox></TD>
											<TD>
												<asp:CheckBox id="chkMar" runat="server" Text="Mar"></asp:CheckBox></TD>
											<TD>
												<asp:CheckBox id="chkAbr" runat="server" Text="Abr"></asp:CheckBox></TD>
											<TD>
												<asp:CheckBox id="chkMay" runat="server" Text="May"></asp:CheckBox></TD>
											<TD>
												<asp:CheckBox id="chkJun" runat="server" Text="Jun"></asp:CheckBox></TD>
										</TR>
										<TR>
											<TD>
												<asp:CheckBox id="chkJul" runat="server" Text="Jul"></asp:CheckBox></TD>
											<TD>
												<asp:CheckBox id="chkAgo" runat="server" Text="Ago"></asp:CheckBox></TD>
											<TD>
												<asp:CheckBox id="chkSep" runat="server" Text="Sep"></asp:CheckBox></TD>
											<TD>
												<asp:CheckBox id="chkOct" runat="server" Text="Oct"></asp:CheckBox></TD>
											<TD>
												<asp:CheckBox id="chkNov" runat="server" Text="Nov"></asp:CheckBox></TD>
											<TD>
												<asp:CheckBox id="chkDic" runat="server" Text="Dic"></asp:CheckBox></TD>
										</TR>
									</TABLE>
								</TD>
								<TD></TD>
							</TR>
							<TR>
								<TD bgColor="#335eb4">
									<asp:label id="lblObservaciones" runat="server" CssClass="TextoBlanco">Observaciones:</asp:label></TD>
								<TD bgColor=#f0f0f0>
									<asp:textbox id="txtObservaciones" runat="server" CssClass="normaldetalle" Width="336px" MaxLength="4000"
										Height="54px" TextMode="MultiLine"></asp:textbox></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD id="TdCeldaCancelar" colSpan="3" runat="server"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../imagenes/atras.gif"></TD>
							</TR>
							<TR>
								<TD align="center" colSpan="3"><INPUT id="hIdActividadCtrl" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hIdActividadCtrl"
										runat="server">
									<cc2:domvalidationsummary id="vSum" runat="server" EnableClientScript="False" DisplayMode="List" ShowMessageBox="True"></cc2:domvalidationsummary></TD>
							</TR>
							<TR>
								<TD align="center" colSpan="3">
									<asp:imagebutton id="ibtnAceptar" runat="server" Width="87px" ImageUrl="../imagenes/bt_aceptar.gif"
										Height="22px"></asp:imagebutton>
									<asp:imagebutton id="ibtnCancelar" runat="server" Width="87px" CausesValidation="False" ImageUrl="../imagenes/bt_cancelar.gif"
										Height="22px"></asp:imagebutton></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
</TD></TR>
	</body>
</HTML>
