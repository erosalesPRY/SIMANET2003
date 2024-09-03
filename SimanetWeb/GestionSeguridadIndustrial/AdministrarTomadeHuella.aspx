<%@ Page language="c#" Codebehind="AdministrarTomadeHuella.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionSeguridadIndustrial.AdministrarTomadeHuella" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AdministrarTomadeHuella</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" border="0" cellSpacing="1" cellPadding="1" width="300">
				<TR>
					<TD rowspan="5" vAlign="middle" align="left">
						<TABLE id="Table2" border="0" cellSpacing="1" cellPadding="1" width="100">
							<TR>
								<TD style="HEIGHT: 6px"></TD>
							</TR>
							<TR>
								<TD align="center">
									<div class='ContextHuellaScan'>
										<IMG style="WIDTH: 192px" class="FondoHuellaScan" alt="" src="/SimaNetWeb/imagenes/Navegador/Finger/MascaraHuella.gif"
											width="192" height="145">
										<asp:Image style="Z-INDEX: 0" id="Image1" runat="server" Width="192px" ImageUrl="/SimaNetWeb/imagenes/Navegador/HuellaScan2.gif"></asp:Image>
									</div>
								</TD>
							</TR>
							<TR>
								<TD></TD>
							</TR>
							<TR>
								<TD align="center"><IMG alt="" src="/SimaNetWeb/imagenes/Navegador/ManosSelec.gif" id="imgHuellaSelect"
										runat="server"></TD>
							</TR>
						</TABLE>
					</TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD vAlign="bottom"></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD>
						<TABLE style="Z-INDEX: 0; BORDER-BOTTOM: gainsboro 2px solid; BORDER-LEFT: gainsboro 2px solid; BORDER-TOP: gainsboro 2px solid; BORDER-RIGHT: gainsboro 2px solid"
							id="Table4" border="0" cellSpacing="1" cellPadding="1" width="350">
							<TR>
								<TD>
									<asp:Image style="Z-INDEX: 0" id="Img1" runat="server" ImageUrl="/SimaNetWeb/imagenes/Navegador/Finger/1Select.gif"></asp:Image></TD>
								<TD>
									<asp:Image style="Z-INDEX: 0" id="Img2" runat="server" ImageUrl="/SimaNetWeb/imagenes/Navegador/Finger/2.gif"></asp:Image></TD>
								<TD>
									<asp:Image style="Z-INDEX: 0" id="Img3" runat="server" ImageUrl="/SimaNetWeb/imagenes/Navegador/Finger/3.gif"></asp:Image></TD>
								<TD>
									<asp:Image style="Z-INDEX: 0" id="Img4" runat="server" ImageUrl="/SimaNetWeb/imagenes/Navegador/Finger/4.gif"></asp:Image></TD>
								<TD>
									<asp:Image style="Z-INDEX: 0" id="Image2" runat="server" ImageUrl="/SimaNetWeb/imagenes/Navegador/Finger/Indicativo.gif"></asp:Image></TD>
							</TR>
						</TABLE>
					</TD>
					<TD></TD>
				</TR>
				<TR>
					<TD>
					<TD>
						<TABLE id="Table3" border="0" cellSpacing="1" cellPadding="1" width="350" style="BORDER-BOTTOM: gainsboro 2px solid; BORDER-LEFT: gainsboro 2px solid; BORDER-TOP: gainsboro 2px solid; BORDER-RIGHT: gainsboro 2px solid">
							<TR>
								<TD colSpan="4" style="BORDER-BOTTOM: lightgrey 2px solid">
									<asp:Label id="lblMsg" runat="server" ForeColor="#404040" Font-Bold="True" Font-Size="X-Small">SCAA</asp:Label></TD>
							</TR>
							<TR>
								<TD style="BORDER-BOTTOM: lightgrey 2px solid; BORDER-LEFT: lightgrey 2px solid; BORDER-TOP: lightgrey 2px solid; BORDER-RIGHT: lightgrey 2px solid"
									align="center">
									<div class='ContextImgHuella'>
										<IMG style="WIDTH: 74px; HEIGHT: 98px" class="imgCircHuella" alt="" src="/SimaNetWeb/imagenes/Navegador/BordeHuella.gif">
										<IMG style="WIDTH: 74px; HEIGHT: 94px" id="imgHuella1" alt="" src="/SimaNetWeb/imagenes/Navegador/FondoHuella.gif">
									</div>
								</TD>
								<TD style="BORDER-BOTTOM: lightgrey 2px solid; BORDER-LEFT: lightgrey 2px solid; BORDER-TOP: lightgrey 2px solid; BORDER-RIGHT: lightgrey 2px solid"
									align="center">
									<div class='ContextImgHuella'>
										<IMG style="WIDTH: 74px; HEIGHT: 98px" class="imgCircHuella" alt="" src="/SimaNetWeb/imagenes/Navegador/BordeHuella.gif">
										<IMG style="WIDTH: 74px; HEIGHT: 94px" id="imgHuella2" alt="" src="/SimaNetWeb/imagenes/Navegador/FondoHuella.gif">
									</div>
								</TD>
								<TD style="BORDER-BOTTOM: lightgrey 2px solid; BORDER-LEFT: lightgrey 2px solid; BORDER-TOP: lightgrey 2px solid; BORDER-RIGHT: lightgrey 2px solid"
									align="center">
									<div class='ContextImgHuella'>
										<IMG style="WIDTH: 74px; HEIGHT: 98px" class="imgCircHuella" alt="" src="/SimaNetWeb/imagenes/Navegador/BordeHuella.gif">
										<IMG style="WIDTH: 74px; HEIGHT: 94px" id="imgHuella3" alt="" src="/SimaNetWeb/imagenes/Navegador/FondoHuella.gif">
									</div>
								</TD>
								<TD style="BORDER-BOTTOM: lightgrey 2px solid; BORDER-LEFT: lightgrey 2px solid; BORDER-TOP: lightgrey 2px solid; BORDER-RIGHT: lightgrey 2px solid"
									align="center">
									<div class='ContextImgHuella'>
										<IMG style="WIDTH: 74px; HEIGHT: 98px" class="imgCircHuella" alt="" src="/SimaNetWeb/imagenes/Navegador/BordeHuella.gif">
										<IMG style="WIDTH: 74px; HEIGHT: 94px" id="imgHuella4" alt="" src="/SimaNetWeb/imagenes/Navegador/FondoHuella.gif">
									</div>
								</TD>
							</TR>
							<TR>
								<TD style="BORDER-BOTTOM: lightgrey 2px solid; BORDER-LEFT: lightgrey 2px solid; BORDER-TOP: lightgrey 2px solid; BORDER-RIGHT: lightgrey 2px solid"
									align="center">
									<asp:Label id="lbl1" runat="server">%</asp:Label></TD>
								<TD style="BORDER-BOTTOM: lightgrey 2px solid; BORDER-LEFT: lightgrey 2px solid; BORDER-TOP: lightgrey 2px solid; BORDER-RIGHT: lightgrey 2px solid"
									align="center">
									<asp:Label style="Z-INDEX: 0" id="lbl2" runat="server">%</asp:Label></TD>
								<TD style="BORDER-BOTTOM: lightgrey 2px solid; BORDER-LEFT: lightgrey 2px solid; BORDER-TOP: lightgrey 2px solid; BORDER-RIGHT: lightgrey 2px solid"
									align="center">
									<asp:Label style="Z-INDEX: 0" id="lbl3" runat="server">%</asp:Label></TD>
								<TD style="BORDER-BOTTOM: lightgrey 2px solid; BORDER-LEFT: lightgrey 2px solid; BORDER-TOP: lightgrey 2px solid; BORDER-RIGHT: lightgrey 2px solid"
									align="center">
									<asp:Label style="Z-INDEX: 0" id="lbl4" runat="server">%</asp:Label></TD>
							</TR>
						</TABLE>
					</TD>
					<TD></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD>
						<asp:Label id="lblStatusScanHuella" runat="server">Status...</asp:Label></TD>
					<TD></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
