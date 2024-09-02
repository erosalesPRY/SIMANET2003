<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="DetalleRecomendacion.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionControlInstitucional.DetalleRecomendacion" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DetalleRecomendacion</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../styles.css">
		<SCRIPT language="javascript" src="../js/@Import.js"></SCRIPT>
		<script type="text/javascript" src="/SimaNetWeb/js/RegEXT.js"></script>
	</HEAD>
	<body onunload="SubirHistorial();" onload="ObtenerHistorial();" bottomMargin="0" leftMargin="0"
		rightMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" border="0" cellSpacing="0" cellPadding="0" width="100%" align="center">
				<TR>
					<TD colSpan="3"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<tr>
					<TD vAlign="top"><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</tr>
				<TR>
					<TD>
						<TABLE id="Table4" border="0" cellSpacing="0" cellPadding="0" width="100%" align="center">
							<TR>
								<TD class="Commands" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio >  Gestión de Control Institucional ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Administración Observaciones de Control</asp:label></TD>
							</TR>
							<TR>
								<TD align="center"></TD>
								<TD align="center"><SPAN class="normal"></SPAN>
									<TABLE style="WIDTH: 590px; HEIGHT: 288px" id="Table3" class="normal" border="0" cellSpacing="0"
										cellPadding="0" width="590" align="center">
										<TR>
											<TD class="TituloPrincipalBlanco" bgColor="#000080" vAlign="top" colSpan="8" align="left"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco"></asp:label><asp:label id="lblDatos" runat="server"></asp:label></TD>
											<TD style="HEIGHT: 14px" class="TituloPrincipalBlanco" vAlign="top" align="left"></TD>
										</TR>
										<TR>
											<TD class="normal" bgColor="#335eb4">
												<asp:label style="Z-INDEX: 0" id="Label1" runat="server" CssClass="TextoBlanco">Fecha:</asp:label></TD>
											<TD class="normal" bgColor="#f0f0f0" colSpan="4">
												<asp:TextBox id="txtFecha" runat="server" Width="80px" rel="calendar" CssClass="normaldetalle"></asp:TextBox></TD>
											<TD class="normal"></TD>
											<TD class="normal" bgColor="#f0f0f0"></TD>
										</TR>
										<TR>
											<TD class="normal" bgColor="#335eb4"><asp:label id="Label3" runat="server" CssClass="TextoBlanco" style="Z-INDEX: 0">% Avance:</asp:label></TD>
											<TD class="normal" bgColor="#f0f0f0" colSpan="4"><asp:textbox id="txtPorcAvance" runat="server" Width="40px" style="Z-INDEX: 0" CssClass="normaldetalle">0</asp:textbox></TD>
											<TD class="normal"></TD>
											<TD class="normal" bgColor="#f0f0f0"></TD>
										</TR>
										<TR>
											<TD class="normal" bgColor="#335eb4">
												<asp:label style="Z-INDEX: 0" id="Label2" runat="server" CssClass="TextoBlanco">Situación:</asp:label></TD>
											<TD class="normal" bgColor="#f0f0f0" colSpan="4">
												<asp:DropDownList id="ddlSItuacion" runat="server" CssClass="normaldetalle" Width="312px"></asp:DropDownList></TD>
											<TD class="normal"></TD>
											<TD class="normal" bgColor="#f0f0f0"></TD>
										</TR>
										<TR>
											<TD class="normal" bgColor="#335eb4"><asp:label id="lblConcepto" runat="server" CssClass="TextoBlanco" Width="83px">RECOMENDACIONES:</asp:label></TD>
											<TD class="normal" bgColor="#f0f0f0" vAlign="top" colSpan="4" align="left"><asp:textbox id="txtObservacion" runat="server" CssClass="normaldetalle" Width="481px" MaxLength="8000"
													Height="257px" TextMode="MultiLine"></asp:textbox></TD>
											<TD class="normal"></CC1:REQUIREDDOMVALIDATOR></CC1:REQUIREDDOMVALIDATOR></CC1:REQUIREDDOMVALIDATOR></CC1:REQUIREDDOMVALIDATOR></TD>
											<TD class="normal" bgColor="#f0f0f0"></TD>
										</TR>
									</TABLE>
									<TABLE id="Table7" border="0" width="598" align="center" style="WIDTH: 598px; HEIGHT: 33px">
										<TR>
											<TD align="center"><INPUT style="WIDTH: 9px; HEIGHT: 22px" id="hIdPersonal" size="1" type="hidden" name="hIdPersonal"
													runat="server">&nbsp;
												<asp:imagebutton id="ibtnAceptar" runat="server" ImageUrl="../imagenes/bt_aceptar.gif"></asp:imagebutton>&nbsp;&nbsp;&nbsp;&nbsp;
												<IMG style="CURSOR: hand" id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../imagenes/bt_cancelar.gif">
												<SPAN class="normal"></SPAN>
											</TD>
										</TR>
									</TABLE>
									<SPAN class="normal"></SPAN>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			
			var textBoxes = Ext.DomQuery.select("input[rel=calendar]");   
						Ext.each(textBoxes, function(item, id, all){   
							var cl = new Ext.form.DateField({   
								format: 'd/m/Y',
								allowBlank : false,   
								applyTo: item   
							});
						});   
		</SCRIPT>
	</body>
</HTML>
