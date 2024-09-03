<%@ Page language="c#" Codebehind="ConsultarPlanContable.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancieros.ConsultarPlanContable" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ConsultarPlanContable</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/JSFrameworkSima.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/FrameCallBack.js"></SCRIPT>
		<script>
		
			function cambiarTamano()
				{
						
						x = (screen.width - 400) / 2;
						y = (screen.height - 400) / 2;
						moveTo(x, y);
				}
		
		</script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="cambiarTamano();" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD colSpan="3">
						<asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal"> BUSQUEDA DE CUENTAS CONTABLES</asp:label></TD>
				</TR>
				<TR>
					<TD colSpan="3">
						<asp:label id="lblDescripcion" runat="server" CssClass="normal">Cuenta Contable:</asp:label>
						<asp:textbox id="txtDescripcion" runat="server" Width="168px"></asp:textbox>
						<asp:imagebutton id="btnBuscar" runat="server" Width="84px" Height="22px" ImageUrl="../../imagenes/bt_Buscar.GIF"></asp:imagebutton></TD>
				</TR>
				<TR>
					<TD colSpan="3">
						<cc1:datagridweb id="grid" runat="server" ShowFooter="True" AutoGenerateColumns="False" Width="100%"
							AllowSorting="True" AllowPaging="True">
							<PagerStyle Font-Size="XX-Small" HorizontalAlign="Center" ForeColor="White" BackColor="Highlight"
								Mode="NumericPages"></PagerStyle>
							<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
							<FooterStyle Font-Size="XX-Small" Font-Names="Arial" HorizontalAlign="Center" CssClass="FooterGrilla"></FooterStyle>
							<ItemStyle CssClass="ItemGrilla"></ItemStyle>
							<Columns>
								<asp:BoundColumn HeaderText="NRO" FooterText="TOTAL">
									<HeaderStyle Width="5%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CUENTACONTABLE" SortExpression="CUENTACONTABLE" HeaderText="CUENTA CONTABLE">
									<HeaderStyle Width="25%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NOMBRECUENTA" SortExpression="NOMBRECUENTA" HeaderText="NOMBRE">
									<HeaderStyle Width="60%"></HeaderStyle>
								</asp:BoundColumn>
							</Columns>
							<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
						</cc1:datagridweb></TD>
				</TR>
				<TR>
					<TD colSpan="3">
						<P align="center">
							<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD colSpan="3">
						<P align="center">
							<asp:imagebutton id="ibtnAceptar" runat="server" Width="87px" Height="22px" ImageUrl="../../imagenes/bt_aceptar.gif"></asp:imagebutton>&nbsp;
							<asp:image id="imgCancelar" onclick="window.close()" runat="server" Width="87px" Height="22px"
								ImageUrl="../../imagenes/bt_cancelar.gif"></asp:image></P>
					</TD>
				</TR>
				<TR>
					<TD colSpan="3"><INPUT id="hCuentaContable" style="WIDTH: 16px; HEIGHT: 10px" type="hidden" size="1" name="hCuentaContable"
							runat="server"></TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			
		
			function PonerTexto(control)
			{ 			
				
				
				opener.document.getElementById(control).value =document.forms[0].hCuentaContable.value;
				opener.document.getElementById(control).focus();
				window.close();
			
			}	
		
		</SCRIPT>
	</body>
</HTML>
