<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="HeaderFIN" Src="HeaderFIN.ascx" %>
<%@ Page language="c#" Codebehind="FormatoDetalleMovimiento.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.General.Diapositivas.GestionFinanciera.FormatoDetalleMovimiento" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>EstadoFinancieroPorMes</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
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
	<body bottomMargin="0" leftMargin="0" rightMargin="0" topMargin="0">
		<form style="Z-INDEX: 0" id="Form1" method="post" runat="server">
			<TABLE id="Table1" border="0" cellSpacing="0" cellPadding="0" height="100%" align="center">
				<tr>
					<td id='HeaderRPT"'><asp:panel style="Z-INDEX: 0" id="Panel" runat="server">Panel</asp:panel>
					</td>
				</tr>
				<TR>
					<TD height="100%" vAlign="top" align="center"><cc1:datagridweb id="grid" runat="server" RowHighlightColor="White" AutoGenerateColumns="False" CellPadding="0"
							BorderStyle="Ridge">
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
						</cc1:datagridweb><INPUT style="Z-INDEX: 0; WIDTH: 77px; HEIGHT: 22px" id="hNombreImgTrim" size="7" type="hidden"
							name="hNombreImgTrim" runat="server">
					</TD>
				</TR>
				<tr>
					<td style="HEIGHT: 80px"></td>
				</tr>
			</TABLE>
		</form>
	</body>
</HTML>
