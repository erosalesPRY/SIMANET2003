<%@ Page language="c#" Codebehind="EntregaProductoConLectoradeBarra.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionSeguridadIndustrial.EntregaProductoConLectoradeBarra" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>EntregaProductoConLectoradeBarra</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" border="0" cellSpacing="1" cellPadding="1" width="300" align="center">
				<TR>
					<TD></TD>
					<TD vAlign="middle" align="center"><STRONG>BUSCAR MATERIAL</STRONG></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD style="PADDING-TOP: 10px" vAlign="middle" align="center"></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD align="center">
						<div class="ContextScan"><IMG id="ImgCodBar" class="imgScan" alt="" src="/SimaNetWeb/imagenes/Navegador/LectorBarra.gif">
							<INPUT onblur="ManagerProcess.SetFocus(this.id);" onkeydown="EntregaProductoConLectoradeBarra.BuscarProducto(this);"
								id="txtFindBar" class="txtCodMat">
						</div>
					</TD>
					<TD></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
