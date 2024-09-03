<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="cc2" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="cc1" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="cc3" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Page language="c#" Codebehind="DetallePaqueteLetrasDescuento.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.DescuentoLetras.DetallePaqueteLetrasDescuento" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
		<!--oncontextmenu="return false" -->
  </HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td width="100%" colSpan="1"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr>
					<td vAlign="top" width="100%" bgColor="#eff7fa"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
				<TR>
					<TD class="RutaPaginaActual" vAlign="top" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Administrar Letras de Descuento</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE id="Table3" cellSpacing="1" cellPadding="1" width="775" border="0">
							<TR>
								<TD bgColor="#000080" colSpan="9"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco" Height="16px" Width="304px">DETALLE DE LETRAS A DESCONTAR</asp:label></TD>
							</TR>
							<TR class="ItemDetalle">
								<TD class="HeaderDetalle" style="WIDTH: 133px; HEIGHT: 16px"><asp:label id="Label1" runat="server" Width="100px" ToolTip="Nro del Documento de Referencia">Nro Doc:</asp:label></TD>
								<TD style="WIDTH: 147px; HEIGHT: 16px"><asp:textbox id="txtNroDocumento" runat="server" CssClass="normaldetalle" Width="88px" ReadOnly="True"
										BorderStyle="Groove" MaxLength="15"></asp:textbox><asp:image id="ibtnBuscarLetra" runat="server" ImageUrl="../../imagenes/BtPU_Mas.gif"></asp:image></TD>
								<TD style="WIDTH: 6px; HEIGHT: 16px"><cc1:requireddomvalidator id="rfvNroReferencia" runat="server" Height="2px" Width="8px" ControlToValidate="txtNroDocumento">*</cc1:requireddomvalidator></TD>
								<TD class="HeaderDetalle" style="HEIGHT: 16px"><asp:label id="Label4" runat="server" DESIGNTIMEDRAGDROP="496">Situación :</asp:label></TD>
								<TD style="HEIGHT: 16px"><asp:dropdownlist id="ddlbSituacion" runat="server" CssClass="normaldetalle" Width="100%"></asp:dropdownlist></TD>
								<TD style="WIDTH: 9px; HEIGHT: 16px"></TD>
								<TD class="HeaderDetalle" style="HEIGHT: 16px"></TD>
								<TD style="HEIGHT: 16px"></TD>
								<TD style="HEIGHT: 16px"></TD>
							</TR>
							<TR class="AlternateItemDetalle">
								<TD class="HeaderDetalle" style="WIDTH: 133px"><asp:label id="Label5" runat="server" Width="50px" ToolTip="Centro de Operaciones"> CO:</asp:label></TD>
								<TD style="WIDTH: 147px"><INPUT class="normaldetalle" id="txtCentro" style="WIDTH: 100%; BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; HEIGHT: 22px; BACKGROUND-COLOR: transparent; BORDER-BOTTOM-STYLE: none"
										readOnly type="text" size="54" name="Text1" runat="server"></TD>
								<TD style="WIDTH: 6px"></TD>
								<TD class="HeaderDetalle"><asp:label id="Label11" runat="server">Estado :</asp:label></TD>
								<TD><INPUT class="normaldetalle" id="txtSituacion" style="BORDER-RIGHT: #999999 1px; BORDER-TOP: #999999 1px; BORDER-LEFT: #999999 1px; WIDTH: 100%; BORDER-BOTTOM: #999999 1px; HEIGHT: 22px; BACKGROUND-COLOR: transparent"
										readOnly type="text" size="54" name="Text1" runat="server"></TD>
								<TD style="WIDTH: 9px"></TD>
								<TD class="HeaderDetalle"><asp:label id="Label6" runat="server">Moneda :</asp:label></TD>
								<TD><INPUT class="normaldetalle" id="txtMoneda" style="BORDER-RIGHT: #999999 1px; BORDER-TOP: #999999 1px; BORDER-LEFT: #999999 1px; WIDTH: 125px; BORDER-BOTTOM: #999999 1px; HEIGHT: 22px; BACKGROUND-COLOR: transparent"
										readOnly type="text" size="54" name="Text1" runat="server"></TD>
								<TD></TD>
							</TR>
							<TR class="ItemDetalle">
								<TD class="HeaderDetalle" style="WIDTH: 133px"><asp:label id="Label13" runat="server">Cliente/Proveedor :</asp:label></TD>
								<TD style="WIDTH: 147px"><INPUT class="normaldetalle" id="hNumero" style="BORDER-RIGHT: #999999 1px; BORDER-TOP: #999999 1px; BORDER-LEFT: #999999 1px; WIDTH: 100%; BORDER-BOTTOM: #999999 1px; HEIGHT: 22px; BACKGROUND-COLOR: transparent"
										readOnly type="text" size="6" name="hNumero" runat="server"></TD>
								<TD style="WIDTH: 6px"></TD>
								<TD class="HeaderDetalle"><asp:label id="Label14" runat="server">Razón Social :</asp:label></TD>
								<TD colSpan="4"><INPUT class="normaldetalle" id="txtEntidad" style="BORDER-RIGHT: #999999 1px; BORDER-TOP: #999999 1px; BORDER-LEFT: #999999 1px; WIDTH: 100%; BORDER-BOTTOM: #999999 1px; HEIGHT: 22px; BACKGROUND-COLOR: transparent"
										readOnly type="text" size="54" name="Text1" runat="server"></TD>
								<TD></TD>
							</TR>
							<TR class="AlternateItemDetalle">
								<TD class="HeaderDetalle" style="WIDTH: 133px"><asp:label id="Label19" runat="server" DESIGNTIMEDRAGDROP="65">Proyecto :</asp:label></TD>
								<TD align="left" colSpan="7">&nbsp;<TEXTAREA class="normaldetalle" id="txtProyecto" style="BORDER-RIGHT: #999999 1px; BORDER-TOP: #999999 1px; BORDER-LEFT: #999999 1px; WIDTH: 632px; BORDER-BOTTOM: #999999 1px; HEIGHT: 32px; BACKGROUND-COLOR: transparent"
										name="txtProyecto" rows="2" readOnly cols="75" runat="server"></TEXTAREA>
								</TD>
								<TD></TD>
							</TR>
							<TR class="ItemDetalle">
								<TD class="HeaderDetalle" style="WIDTH: 133px"><asp:label id="Label15" runat="server" Width="100px" ToolTip="Otros datos del Proyecto">Datos del Proy :</asp:label></TD>
								<TD colSpan="7"><asp:textbox id="txtDatosProyecto" runat="server" CssClass="normaldetalle" Width="632px" ReadOnly="True"
										BorderStyle="None" BackColor="Transparent"></asp:textbox></TD>
								<TD></TD>
							</TR>
							<TR class="AlternateItemDetalle">
								<TD class="HeaderDetalle" style="WIDTH: 133px"><asp:label id="Label18" runat="server" DESIGNTIMEDRAGDROP="564">Fecha de Inicio:</asp:label></TD>
								<TD style="WIDTH: 147px"><INPUT class="normaldetalle" id="txtFechaInicio" style="BORDER-RIGHT: #999999 1px; BORDER-TOP: #999999 1px; BORDER-LEFT: #999999 1px; WIDTH: 100%; BORDER-BOTTOM: #999999 1px; HEIGHT: 22px; BACKGROUND-COLOR: transparent"
										readOnly type="text" size="54" name="Text1" runat="server"></TD>
								<TD style="WIDTH: 6px"></TD>
								<TD class="HeaderDetalle"><asp:label id="Label8" runat="server" Width="120px">Fecha Vencimiento :</asp:label></TD>
								<TD><INPUT class="normaldetalle" id="txtFechaVence" style="BORDER-RIGHT: #999999 1px; BORDER-TOP: #999999 1px; BORDER-LEFT: #999999 1px; WIDTH: 100%; BORDER-BOTTOM: #999999 1px; HEIGHT: 22px; BACKGROUND-COLOR: transparent"
										readOnly type="text" size="54" name="Text1" runat="server"></TD>
								<TD style="WIDTH: 9px" colSpan="3"></TD>
								<TD width="50"></TD>
							</TR>
							<TR class="ItemDetalle">
								<TD class="HeaderDetalle" style="WIDTH: 133px"><asp:label id="Label2" runat="server" DESIGNTIMEDRAGDROP="652">DIAS DE PLAZO:</asp:label></TD>
								<TD style="WIDTH: 147px"><INPUT class="normaldetalle" id="NDiasPlazo" style="BORDER-RIGHT: #999999 1px; BORDER-TOP: #999999 1px; BORDER-LEFT: #999999 1px; WIDTH: 100%; BORDER-BOTTOM: #999999 1px; HEIGHT: 22px; BACKGROUND-COLOR: transparent"
										readOnly type="text" size="1081" name="Text1" runat="server"></TD>
								<TD style="WIDTH: 6px"></TD>
								<TD class="HeaderDetalle"><asp:label id="Label7" runat="server">DIAS QUE VENCE:</asp:label></TD>
								<TD><INPUT class="normaldetalle" id="nDiasVence" style="BORDER-RIGHT: #999999 1px; BORDER-TOP: #999999 1px; BORDER-LEFT: #999999 1px; WIDTH: 100%; BORDER-BOTTOM: #999999 1px; HEIGHT: 22px; BACKGROUND-COLOR: transparent"
										readOnly type="text" size="1081" name="Text1" runat="server"></TD>
								<TD style="WIDTH: 9px" colSpan="3"></TD>
								<TD></TD>
							</TR>
							<TR class="AlternateItemDetalle">
								<TD class="HeaderDetalle" style="WIDTH: 133px"><asp:label id="Label9" runat="server" Width="123px">Monto :</asp:label></TD>
								<TD style="WIDTH: 147px"><INPUT class="normaldetalle" id="nMonto" style="BORDER-RIGHT: #999999 1px; BORDER-TOP: #999999 1px; BORDER-LEFT: #999999 1px; WIDTH: 100%; BORDER-BOTTOM: #999999 1px; HEIGHT: 22px; BACKGROUND-COLOR: transparent"
										readOnly type="text" size="1081" name="Text1" runat="server"></TD>
								<TD style="WIDTH: 6px"></TD>
								<TD class="HeaderDetalle"><asp:label id="Label3" runat="server">Tasa de Interés :</asp:label></TD>
								<TD><INPUT class="normaldetalle" id="nTasaInteres" style="BORDER-RIGHT: #999999 1px; BORDER-TOP: #999999 1px; BORDER-LEFT: #999999 1px; WIDTH: 150px; BORDER-BOTTOM: #999999 1px; HEIGHT: 22px; BACKGROUND-COLOR: transparent"
										readOnly type="text" size="19" name="Text1" runat="server"></TD>
								<TD style="WIDTH: 9px"></TD>
								<TD class="HeaderDetalle"></TD>
								<TD></TD>
								<TD></TD>
							</TR>
							<TR class="ItemDetalle">
								<TD class="HeaderDetalle" style="WIDTH: 133px"><asp:label id="Label10" runat="server">Aplicación :</asp:label></TD>
								<TD align="left" colSpan="7"><asp:textbox id="txtObservacion" runat="server" CssClass="normaldetalle" Height="44px" Width="100%"
										ReadOnly="True" BorderStyle="None" BackColor="Transparent" TextMode="MultiLine"></asp:textbox></TD>
								<TD></TD>
							</TR>
							<TR class="AlternateItemDetalle">
								<TD class="HeaderDetalle" style="WIDTH: 133px"><INPUT id="hIdLetra" style="WIDTH: 16px; HEIGHT: 16px" type="hidden" size="1" name="hIdTablaEntidad"
										runat="server"></TD>
								<TD style="HEIGHT: 47px" colSpan="7" rowSpan="2">
									<TABLE id="ToolBar" cellSpacing="1" cellPadding="1" width="112" align="right" border="0"
										runat="server">
										<TR>
											<TD>
												<P align="right"><asp:imagebutton id="ibtnAceptar" runat="server" ImageUrl="../../imagenes/bt_aceptar.gif"></asp:imagebutton></P>
											</TD>
											<TD>
												<P align="right"><IMG id="ibtnCancelar" onclick="HistorialIrAtras();" alt="" src="../../imagenes/bt_cancelar.gif"
														runat="server"></P>
											</TD>
										</TR>
									</TABLE>
								</TD>
								<TD style="HEIGHT: 47px" rowSpan="2"></TD>
							</TR>
						</TABLE>
						<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE id="tblAtras" cellSpacing="1" cellPadding="1" width="796" border="0" runat="server">
							<TR>
								<TD align="left"><IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%"><cc1:domvalidationsummary id="Vresumen" runat="server" Height="24px" Width="160px" DisplayMode="List" EnableClientScript="False"
							ShowMessageBox="True"></cc1:domvalidationsummary></TD>
				</TR>
			</table>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
