<%@ Page language="c#" Codebehind="DetalleAdministrarObservacionesEstadosFinancieros.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancieros.Directorio.DetalleAdministrarObservacionesEstadosFinancieros" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>SIMANET - OBSERVACION</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../../js/Historial.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../../js/JSFrameworkSima.js"></SCRIPT>
		<script>
				function Cerrar(tipoRegistro)
				{
						if(tipoRegistro==1)
						{
							alert('Se registro con exito');
						}
						else
						{
							alert('Se modifico con exito');
						}
						
						window.close();
				}
				function Cancelar()
				{
						
						window.close();
				}
				function cambiarTamano()
				{
						
						x = (screen.width - 600) / 2;
						y = (screen.height - 400) / 2;
						moveTo(x, y);
				}
								
				
				
		</script>
</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="cambiarTamano();" rightMargin="0">
		<DIV align="center">
			<form id="Form1" method="post" runat="server">
				<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="464" border="0" style="WIDTH: 464px; HEIGHT: 216px">
					<TR>
						<TD colSpan="3"><BR><BR>
						</TD>
					</TR>
					<TR>
						<TD class="TituloPrincipalBlanco" bgColor="#000080" colSpan="3">
							<asp:label id="lblTitulo" runat="server"></asp:label></TD>
					</TR>
					<TR>
						<TD bgColor="#335eb4">
							<asp:label id="lblCorreoElectronico" runat="server" CssClass="TextoBlanco">Observacion:</asp:label></TD>
						<TD colSpan="2" style="HEIGHT: 90px">
							<asp:textbox id="txtObservacion" runat="server" CssClass="normaldetalle" Width="369px" Height="152px"
								TextMode="MultiLine"></asp:textbox>
							<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="Ingrese la observacion"
								ControlToValidate="txtObservacion">*</asp:RequiredFieldValidator></TD>
					</TR>
					<TR>
						<TD colSpan="3">
							<DIV align="center">
								<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
									<TR>
										<TD>
											<P align="right"><BR>
												<asp:imagebutton id="ibtnAceptar" runat="server" Height="22px" Width="87px" ImageUrl="../../../imagenes/bt_aceptar.gif"></asp:imagebutton>&nbsp;</P>
										</TD>
										<TD>
											<P align="left"><BR><IMG id="ibtnCancelar" onclick="HistorialIrAtras();" alt="" src="../../../imagenes/bt_cancelar.gif"
													runat="server"></P>
										</TD>
									</TR>
								</TABLE>
							</DIV>
							<asp:ValidationSummary id="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False"></asp:ValidationSummary>
						</TD>
					</TR>
				</TABLE>
				<P>&nbsp;</P>
				<P>&nbsp;</P>
			</form>
		</DIV>
		<SCRIPT>
		
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
		<DIV align="center">&nbsp;</DIV>
	</body>
</HTML>
