<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="DetallePersona_Contratista_Visita.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionSeguridadIndustrial.DetallePersona_Contratista_Visita" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>DetallePersona_Contratista_Visita</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../styles.css">
		<SCRIPT language="javascript" src="../js/@Import.js"></SCRIPT>
		<script type="text/javascript" src="/SimaNetWeb/js/RegEXT.js"></script>
</HEAD>
	<body onunload="SubirHistorial();" onload="ObtenerHistorial();" bottomMargin="0" leftMargin="0"
		rightMargin="0" scroll="no" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" border="1" cellSpacing="0" cellPadding="0" width="100%" height="100%">
				<TR>
					<TD>
						<uc1:Header id="Header1" runat="server"></uc1:Header></TD>
				</TR>
				<TR>
					<TD>
						<uc1:Menu id="Menu1" runat="server"></uc1:Menu></TD>
				</TR>
				<TR>
					<TD class="commands">
						<asp:label style="Z-INDEX: 0" id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio >Seguridad Industrial ></asp:label>
						<asp:label style="Z-INDEX: 0" id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Detalle Personal (Contratista - Visita)></asp:label>
					</TD>
				</TR>
				<TR>
					<TD height="100%" vAlign="top" align="center">
						<TABLE style="WIDTH: 561px" id="Table2" border="0" cellSpacing="0" cellPadding="0" width="561">
							<TR>
								<TD style="HEIGHT: 35px" bgColor="#000080" colSpan="4" align="center">
									<asp:label style="Z-INDEX: 0" id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco"
										Width="292px" Height="16px">DETALLE DATOS DE TRABAJADOR</asp:label></TD>
							</TR>
							<TR>
								<TD></TD>
								<TD></TD>
								<TD></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD class="HeaderDetalle" noWrap>
									<asp:Label id="Label1" runat="server">NRO DOCUMENTO:</asp:Label></TD>
								<TD width="100%">
									<asp:TextBox id="txtNroDNI" runat="server" CssClass="normaldetalle" Width="136px"></asp:TextBox></TD>
								<TD></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD class="HeaderDetalle">
									<asp:Label id="Label2" runat="server">APELLIDO PATERNO:</asp:Label></TD>
								<TD>
									<asp:TextBox id="txtAPaterno" runat="server" CssClass="normaldetalle" Width="360px"></asp:TextBox></TD>
								<TD></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD class="HeaderDetalle" noWrap>
									<asp:Label style="Z-INDEX: 0" id="Label4" runat="server">APELLIDO MATERNO:</asp:Label></TD>
								<TD>
									<asp:TextBox style="Z-INDEX: 0" id="txtAMaterno" runat="server" CssClass="normaldetalle" Width="360px"></asp:TextBox></TD>
								<TD></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD class="HeaderDetalle">
									<asp:Label style="Z-INDEX: 0" id="Label5" runat="server">NOMBRES:</asp:Label></TD>
								<TD>
									<asp:TextBox style="Z-INDEX: 0" id="txtNombres" runat="server" CssClass="normaldetalle" Width="208px"></asp:TextBox></TD>
								<TD></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD class="HeaderDetalle">
									<asp:Label id="Label3" runat="server">NACIONALIDAD:</asp:Label></TD>
								<TD>
									<asp:DropDownList id="ddlNacionalidad" runat="server" CssClass="normaldetalle" Width="208px"></asp:DropDownList></TD>
								<TD></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD></TD>
								<TD>
									<TABLE style="Z-INDEX: 0; WIDTH: 182px; HEIGHT: 30px" id="Table3" border="0" cellSpacing="1"
										cellPadding="1" width="182">
										<TR>
											<TD>
												<asp:imagebutton style="Z-INDEX: 0" id="ibtnAceptar" runat="server" ImageUrl="../imagenes/bt_aceptar.gif"
													Height="22px"></asp:imagebutton></TD>
											<TD><IMG style="Z-INDEX: 0; CURSOR: hand" id="ibtnAtras" onclick="HistorialIrAtras();" alt=""
													src="../imagenes/bt_cancelar.gif"></TD>
										</TR>
									</TABLE>
								</TD>
								<TD></TD>
								<TD></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
