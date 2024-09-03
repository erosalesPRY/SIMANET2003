<%@ Page language="c#" Codebehind="SplahLecturaHuella.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionSeguridadIndustrial.SplahLecturaHuella" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SplahLecturaHuella</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE style="Z-INDEX: 0" id="Table1" border="0" cellSpacing="1" cellPadding="1" width="100%">
				<TR>
					<TD>
						<table id="tblBaseHuella">
							<tr>
								<td>
									<IMG id="imgPatron" class="map" src="/SimaNetWeb/imagenes/Navegador/Finger/ManosBase.gif"
										useMap="#image-map">
									<asp:placeholder id="LtlMapContext" runat="server"></asp:placeholder>
								</td>
							</tr>
						</table>
					</TD>
					<TD>
						<TABLE id="tblHuellaContext" border="0" cellSpacing="1" cellPadding="1" width="100%" style="Z-INDEX: 0">
							<TR>
								<TD style="PADDING-BOTTOM: 10px; PADDING-LEFT: 10px; PADDING-RIGHT: 10px; PADDING-TOP: 10px"
									vAlign="middle" colSpan="3" align="center"></TD>
							</TR>
							<TR>
								<TD noWrap>
									<asp:label id="Label1" runat="server" Font-Bold="True" Font-Size="X-Small">Nro Items por confirmar:</asp:label></TD>
								<TD width="40%">
									<asp:label id="lblNroItems" runat="server">10</asp:label></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD vAlign="middle" colSpan="3" align="center">
									<TABLE id="tblHuella" border="0" cellSpacing="1" cellPadding="1" width="20">
										<TR>
											<TD style="PADDING-BOTTOM: 10px; PADDING-LEFT: 10px; PADDING-RIGHT: 10px; PADDING-TOP: 10px"
												align="center">
												<DIV class="ContextHuellaScan"><IMG style="WIDTH: 192px" class="FondoHuellaScan" alt="" src="/SimaNetWeb/imagenes/Navegador/Finger/MascaraHuella.gif"
														width="192" height="145">
													<asp:Image style="Z-INDEX: 0" id="imgHuellaScan" runat="server" ImageUrl="/SimaNetWeb/imagenes/Navegador/HuellaScan2.gif"
														Width="192px"></asp:Image></DIV>
											</TD>
										</TR>
										<TR>
											<TD style="PADDING-BOTTOM: 10px; PADDING-LEFT: 10px; PADDING-RIGHT: 10px; DISPLAY: none; PADDING-TOP: 10px"
												align="center">
												<DIV class="ContextImgHuella"><IMG style="HEIGHT: 160px" class="imgCircHuella" alt="" src="/SimaNetWeb/imagenes/Navegador/BordeHuella.gif"
														width="130">
													<asp:image id="imgHuella" runat="server" ImageUrl="/SimaNetWeb/imagenes/Navegador/FondoHuella.gif"
														Width="120px" Height="150px"></asp:image></DIV>
											</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD colSpan="3" align="center"></TD>
							</TR>
							<TR>
								<TD colSpan="3" align="center"><INPUT style="WIDTH: 32px; HEIGHT: 24px" id="hNroHuellas" size="1" type="hidden" runat="server"></TD>
							</TR>
							<TR>
								<TD align="center"></TD>
								<TD></TD>
								<TD></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD colSpan="2" align="center">
						<asp:Label style="Z-INDEX: 0" id="lblStatusScanHuella" runat="server" Font-Bold="True">Status:..</asp:Label></TD>
				</TR>
				<TR>
					<TD colSpan="2">
						<asp:Label id="lblAviso" runat="server" Font-Size="11pt">Para confirmar la recepción, deslice Ud. en el dispositivo lector cualquiera de las huellas de los dedos sombreados en la imagen de referencia.</asp:Label></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
