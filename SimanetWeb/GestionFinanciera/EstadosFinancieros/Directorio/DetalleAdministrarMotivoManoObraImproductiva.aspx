<%@ Page language="c#" Codebehind="DetalleAdministrarMotivoManoObraImproductiva.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancieros.Directorio.DetalleAdministrarMotivoManoObraImproductiva" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Detalle </title>
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
						y = (screen.height - 200) / 2;
						moveTo(x, y);
				}
								
				
				
		</script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="cambiarTamano();" rightMargin="0">
		<DIV align="center">
			<form id="Form1" method="post" runat="server">
				<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="400" border="0">
					<TR>
						<TD colSpan="3"></TD>
					</TR>
					<TR>
						<TD class="TituloPrincipalBlanco" bgColor="#000080" colSpan="3">
							<asp:label id="lblTitulo" runat="server"></asp:label></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 79px" bgColor="#335eb4">
							<asp:label id="lblCorreoElectronico" runat="server" CssClass="TextoBlanco">motivo:</asp:label></TD>
						<TD colSpan="2">
							<asp:textbox id="txtMotivo" runat="server" CssClass="normaldetalle" Width="307px" Height="80px"
								TextMode="MultiLine"></asp:textbox>
							<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="Ingrese la observacion"
								ControlToValidate="txtMotivo">*</asp:RequiredFieldValidator></TD>
					</TR>
					<TR>
						<TD colSpan="3">
							<DIV align="center">
								<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
									<TR>
										<TD>
											<P align="right">
												<asp:imagebutton id="ibtnAceptar" runat="server" Height="22px" Width="87px" ImageUrl="../../../imagenes/bt_aceptar.gif"></asp:imagebutton></P>
										</TD>
										<TD>
											<P align="left">&nbsp;<IMG id="ibtnCancelar" onclick="HistorialIrAtras();" alt="" src="../../../imagenes/bt_cancelar.gif"
													runat="server"></P>
										</TD>
									</TR>
								</TABLE>
							</DIV>
							<asp:ValidationSummary id="ValidationSummary1" runat="server" Height="32px" ShowSummary="False" ShowMessageBox="True"></asp:ValidationSummary>
						</TD>
					</TR>
				</TABLE>
				<BR>
				&nbsp;
			</form>
		</DIV>
		<SCRIPT>
		
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
		<DIV align="center">&nbsp;</DIV>
	</body>
</HTML>
