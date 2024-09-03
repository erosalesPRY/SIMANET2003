<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Page language="c#" Codebehind="DialogoEditarMontoAmortizadoeInteres.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.PresupuestoVarios.DialogoEditarMontoAmortizadoeInteres" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DialogoEditarMontoAmortizadoeInteres</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script>
			function EntregarResultado()
			{
				var ArrayMonto = new Array();
				ArrayMonto[0] =document.all["nMontoAmortiza"].value;
				ArrayMonto[1] =document.all["nMontoInteres"].value;
				window.returnValue=ArrayMonto;
				window.close();
			}		
		</script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="WIDTH: 464px; HEIGHT: 147px" cellSpacing="1" cellPadding="1"
				width="464" border="0">
				<TR>
					<TD colSpan="4" bgColor="#000080">
						<asp:label id="lblTitulo" runat="server" Width="392px" Height="16px" DESIGNTIMEDRAGDROP="25"
							CssClass="TituloPrincipalBlanco"> DETALLE DE AMORTIZACION</asp:label></TD>
				</TR>
				<TR class="AlternateItemDetalle">
					<TD class="headerDetalle">
						<asp:label class="" id="Label2" runat="server">ENTIDAD FINANCIERA :</asp:label></TD>
					<TD colSpan="3">
						<asp:label class="" id="lblEntidad" runat="server">NOMBRE ENTIDAD FINANCIERA </asp:label></TD>
				</TR>
				<TR class="ItemDetalle">
					<TD class="headerDetalle">
						<asp:label class="" id="lblInformeEmitido" runat="server">AMORTIZACION :</asp:label></TD>
					<TD style="WIDTH: 114px">
						<ew:numericbox id="nMontoAmortiza" runat="server" Width="138px" CssClass="normaldetalle" PlacesBeforeDecimal="15"
							PositiveNumber="True" AutoFormatCurrency="True" DollarSign=" " DecimalPlaces="3" MaxLength="18">0</ew:numericbox></TD>
					<TD class="headerDetalle">
						<asp:label class="" id="Label1" runat="server">INTERES :</asp:label></TD>
					<TD>
						<ew:numericbox id="nMontoInteres" runat="server" Width="102px" CssClass="normaldetalle" PlacesBeforeDecimal="15"
							PositiveNumber="True" AutoFormatCurrency="True" DollarSign=" " DecimalPlaces="3" MaxLength="18">0</ew:numericbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD style="WIDTH: 114px"></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD style="WIDTH: 114px"></TD>
					<TD colSpan="2">
						<TABLE id="tblToolbar" style="WIDTH: 182px; HEIGHT: 30px" cellSpacing="1" cellPadding="1"
							width="182" align="right" border="0" runat="server">
							<TR>
								<TD width="50%">
									<IMG id="ibtnAceptar" onclick="EntregarResultado();" alt="" src="../../imagenes/bt_aceptar.gif"></TD>
								<TD width="50%"><IMG id="ibtnAtras" onclick="window.close();" alt="" src="../../imagenes/bt_cancelar.gif"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
		<asp:literal id=ltlMensaje runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
