<%@ Register TagPrefix="uc1" TagName="HeaderFIN" Src="HeaderFIN.ascx" %>
<%@ Page language="c#" Codebehind="FormatoyGrafico.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.General.Diapositivas.GestionFinanciera.FormatoyGrafico" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>FormatoyGrafico</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../../../styles.css">
		<SCRIPT language="javascript" src="../../../js/@Import.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../../js/JQuery/js/jquery.min.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../../js/JQuery/js/JQueryPlugInSIMA.js"></SCRIPT>
		<STYLE>.ItemGrilla { BORDER-BOTTOM: #ffffff 1px solid; TEXT-ALIGN: center; BACKGROUND-COLOR: white; FONT-FAMILY: Arial; HEIGHT: 10px; COLOR: #000080; FONT-SIZE: 10px; VERTICAL-ALIGN: middle }
	.AlternateItemGrilla { TEXT-ALIGN: center; BACKGROUND-COLOR: white; FONT-FAMILY: Arial; HEIGHT: 10px; COLOR: #000080; FONT-SIZE: 10px; VERTICAL-ALIGN: middle }
	IFRAME { BORDER-BOTTOM: 0px; BORDER-LEFT: 0px; BORDER-TOP: 0px; BORDER-RIGHT: 0px }
	</STYLE>
</HEAD>
	<body>
		<form id="Form1" method="post" runat="server" style="Z-INDEX: 0">
			<TABLE id="Table1" border="0" cellSpacing="0" cellPadding="0" height="100%" align="center" >
				<tr>
					<td id='HeaderRPT"'><asp:panel style="Z-INDEX: 0" id="Panel" runat="server">Panel</asp:panel>
					</td>
				</tr>
				<TR>
					<TD height="100%" vAlign="top" align="center">
						<cc1:datagridweb id="grid" runat="server" BorderStyle="Ridge" CellPadding="0" AutoGenerateColumns="False"
							RowHighlightColor="White">
							<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
							<ItemStyle Height="18px" CssClass="ItemGrilla"></ItemStyle>
							<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
							<FooterStyle CssClass="FooterGrilla"></FooterStyle>
							<Columns>
								<asp:BoundColumn DataField="Concepto" HeaderText="CONCEPTO">
									<HeaderStyle Width="5%"></HeaderStyle>
									<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
						</cc1:datagridweb>
						
					</TD>
				</TR>
				<tr>
					<td style="HEIGHT: 10px"></td>
				</tr>
			</TABLE>
			<iframe width="100%" height="400" frameBorder="0" scrolling="no" style="Z-INDEX: 0" id="IframeSeccion"
							runat="server"></iframe><INPUT style="Z-INDEX: 0; WIDTH: 77px; HEIGHT: 22px" id="hNombreImgTrim" size="7" type="hidden"
							name="hNombreImgTrim" runat="server">
		</form>
	</body>
</HTML>
