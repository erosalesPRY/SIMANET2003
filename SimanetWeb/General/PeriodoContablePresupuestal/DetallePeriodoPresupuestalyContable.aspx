<%@ Page language="c#" Codebehind="DetallePeriodoPresupuestalyContable.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.General.PeriodoContablePresupuestal.DetallePeriodoPresupuestalyContable" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DetallePeriodoPresupuestalyContable</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>
		<script>
			function ConfirmarCreacion(){ 
				var Confirmado=false;
					Confirmado = confirm("Desea Crear un nuevo periodo ahora?");
					if(Confirmado==true){PopupDeEspera();}
					return Confirmado;
			}
		</script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" rightMargin="0" topMargin="0" onload="ObtenerHistorial();"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE style="Z-INDEX: 0" id="Table1" border="1" cellSpacing="0" cellPadding="0" width="100%"
				height="100%">
				<TR>
					<TD>
						<uc1:Header id="Header1" runat="server"></uc1:Header></TD>
				</TR>
				<TR>
					<TD>
						<uc1:Menu id="Menu1" runat="server"></uc1:Menu></TD>
				</TR>
				<TR>
					<TD height="100%" vAlign="top" align="center">
						<TABLE style="WIDTH: 504px; HEIGHT: 120px" id="Table2" border="0" cellSpacing="1" cellPadding="1"
							width="504">
							<TR>
								<TD colSpan="4" align="center" bgColor="#000080">
									<asp:Label id="Label1" runat="server" Font-Bold="True" ForeColor="White">CREAR PERIODO PRESUPUESTAL</asp:Label></TD>
							</TR>
							<TR>
								<TD class="headerDetalle">
									<asp:Label id="Label2" runat="server">PERIODO:</asp:Label></TD>
								<TD>
									<ew:NumericBox id="nPeriodo" runat="server" PositiveNumber="True" RealNumber="False" MaxLength="4"></ew:NumericBox></TD>
								<TD></TD>
								<TD>
									<asp:CheckBox id="chkActivo" runat="server" Text="Activo" Checked="True"></asp:CheckBox></TD>
							</TR>
							<TR>
								<TD colSpan="4" align="center" bgColor="#000080">
									<asp:Label style="Z-INDEX: 0" id="Label3" runat="server" Font-Bold="True" ForeColor="White"> REFERENCIA</asp:Label></TD>
							</TR>
							<TR>
								<TD class="headerDetalle">
									<asp:Label style="Z-INDEX: 0" id="Label4" runat="server">PERIODO:</asp:Label></TD>
								<TD>
									<asp:DropDownList id="ddlPeriodoRef" runat="server" Width="168px" style="Z-INDEX: 0"></asp:DropDownList></TD>
								<TD class="headerDetalle">
									<asp:Label style="Z-INDEX: 0" id="Label5" runat="server">INFORMACION:</asp:Label></TD>
								<TD>
									<asp:DropDownList style="Z-INDEX: 0" id="ddlTipoInfoRef" runat="server" Width="168px"></asp:DropDownList></TD>
							</TR>
							<TR>
								<TD></TD>
								<TD><INPUT style="WIDTH: 48px; HEIGHT: 23px" id="hPeriodo" value="0" size="2" type="hidden"
										runat="server"><INPUT style="WIDTH: 49px; HEIGHT: 22px" id="hTipoInfo" value="99" size="2" type="hidden"
										runat="server"></TD>
								<TD align="right"></TD>
								<TD align="right">
									<TABLE id="Table3" border="0" cellSpacing="1" cellPadding="1" width="50">
										<TR>
											<TD>
												<asp:ImageButton style="Z-INDEX: 0" id="imgAceptar" runat="server" ImageUrl="../../imagenes/bt_aceptar.gif"></asp:ImageButton></TD>
											<TD><IMG style="Z-INDEX: 0" id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../../imagenes/bt_cancelar.gif"></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD></TD>
				</TR>
			</TABLE>
			<div id="container"></div>
			<SCRIPT><asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal></SCRIPT>
		</form>
	</body>
</HTML>
