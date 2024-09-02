<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Page language="c#" Codebehind="EstadoFinancieroCorporativo.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.General.Diapositivas.GestionFinanciera.EstadoFinancieroCorporativo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>Estados Financieros</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../../../styles.css">
		<SCRIPT language="javascript" src="../../../js/@Import.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../../js/JQuery/js/jquery.min.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../../js/JQuery/js/JQueryPlugInSIMA.js"></SCRIPT>

		<STYLE>
			.ItemGrilla { BORDER-BOTTOM: #ffffff 1px solid; TEXT-ALIGN: center; BACKGROUND-COLOR: white; FONT-FAMILY: Arial; HEIGHT: 10px; COLOR: #000080; FONT-SIZE: 10px; VERTICAL-ALIGN: middle }
			.AlternateItemGrilla { TEXT-ALIGN: center; BACKGROUND-COLOR: white; FONT-FAMILY: Arial; HEIGHT: 10px; COLOR: #000080; FONT-SIZE: 10px; VERTICAL-ALIGN: middle }
		</STYLE>		
		<SCRIPT>
			var jSIMA = jQuery.noConflict();
		</SCRIPT>
</HEAD>
	<body onkeypress="if((event.keyCode==SIMA.Utilitario.Constantes.General.KeyCode.KeyReturn)||(event.keyCode==SIMA.Utilitario.Constantes.General.KeyCode.keyTab)){return false;}"
		bottomMargin="0" leftMargin="0" rightMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" border="0" cellSpacing="0" cellPadding="0" width="100%" height="100%">
				<TR>
					<TD height="100%" vAlign="top" align="left"><cc1:datagridweb id="grid" runat="server" RowHighlightColor="#E0E0E0" AutoGenerateColumns="False"
							Width="100%">
<AlternatingItemStyle CssClass="AlternateItemGrilla">
</AlternatingItemStyle>

<ItemStyle CssClass="ItemGrilla">
</ItemStyle>

<HeaderStyle CssClass="HeaderGrilla">
</HeaderStyle>

<FooterStyle CssClass="FooterGrilla">
</FooterStyle>

<Columns>
<asp:BoundColumn DataField="Concepto" HeaderText="CONCEPTO">
<HeaderStyle Width="5%">
</HeaderStyle>

<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Top">
</ItemStyle>
</asp:BoundColumn>
<asp:TemplateColumn HeaderText="ENERO">
<HeaderStyle Width="4.3%">
</HeaderStyle>

<ItemStyle Wrap="False">
</ItemStyle>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="FEBRERO">
<HeaderStyle Width="4.3%">
</HeaderStyle>

<ItemStyle Wrap="False">
</ItemStyle>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="MARZO">
<HeaderStyle Width="4.3%">
</HeaderStyle>

<ItemStyle Wrap="False">
</ItemStyle>
</asp:TemplateColumn>
<asp:BoundColumn HeaderText="TOTAL">
<HeaderStyle Width="4.3%">
</HeaderStyle>

<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
<asp:TemplateColumn HeaderText="ABRIL">
<HeaderStyle Width="4.3%">
</HeaderStyle>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="MAYO">
<HeaderStyle Width="4.3%">
</HeaderStyle>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="JUNIO">
<HeaderStyle Width="4.3%">
</HeaderStyle>
</asp:TemplateColumn>
<asp:BoundColumn HeaderText="TOTAL">
<HeaderStyle Width="4.3%">
</HeaderStyle>

<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
<asp:TemplateColumn HeaderText="JULIO">
<HeaderStyle Width="4.3%">
</HeaderStyle>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="AGOSTO">
<HeaderStyle Width="4.3%">
</HeaderStyle>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="SETIEMBRE">
<HeaderStyle Width="4.3%">
</HeaderStyle>
</asp:TemplateColumn>
<asp:BoundColumn HeaderText="TOTAL">
<HeaderStyle Width="4.3%">
</HeaderStyle>

<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
<asp:TemplateColumn HeaderText="OCTUBRE">
<HeaderStyle Width="4.3%">
</HeaderStyle>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="NOVIEMBRE">
<HeaderStyle Width="4.3%">
</HeaderStyle>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="DICIEMBRE">
<HeaderStyle Width="4.3%">
</HeaderStyle>
</asp:TemplateColumn>
<asp:BoundColumn HeaderText="TOTAL">
<HeaderStyle Width="4.3%">
</HeaderStyle>

<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
</Columns>

<PagerStyle CssClass="PagerGrilla" Mode="NumericPages">
</PagerStyle>
						</cc1:datagridweb><INPUT style="Z-INDEX: 0; WIDTH: 77px; HEIGHT: 22px" id="hNombreImgTrim" size="7" type="hidden"
							runat="server">
					</TD>
				</TR>
				<tr>
					<td style="HEIGHT: 80px">
					</td>
				</tr>
			</TABLE>
			
		</form>
	</body>
</HTML>
