<%@ Register TagPrefix="uc1" TagName="HeaderFIN" Src="HeaderFIN.ascx" %>
<%@ Page language="c#" Codebehind="EstadoFinancieroPorMes.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.General.Diapositivas.GestionFinanciera.EstadoFinancieroPorMes" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
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
		<SCRIPT>
			//var jSIMA = jQuery.noConflict();
		</SCRIPT>
		<STYLE>.ItemGrilla { BORDER-BOTTOM: #ffffff 1px solid; TEXT-ALIGN: center; BACKGROUND-COLOR: white; FONT-FAMILY: Arial; HEIGHT: 10px; COLOR: #000080; FONT-SIZE: 10px; VERTICAL-ALIGN: middle }
	.AlternateItemGrilla { TEXT-ALIGN: center; BACKGROUND-COLOR: white; FONT-FAMILY: Arial; HEIGHT: 10px; COLOR: #000080; FONT-SIZE: 10px; VERTICAL-ALIGN: middle }
		</STYLE>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" rightMargin="0" topMargin="0">
		<form style="Z-INDEX: 0" id="Form1" method="post" runat="server">
			<TABLE id="Table1" border="0" cellSpacing="0" cellPadding="0" width="100%" height="100%">
				<tr>
					<td id='HeaderRPT"'><asp:panel style="Z-INDEX: 0" id="Panel" runat="server" >Panel</asp:panel>
					</td>
				</tr>
				<TR>
					<TD height="100%" vAlign="top" align="center"><cc1:datagridweb id="grid" runat="server" AutoGenerateColumns="False" RowHighlightColor="#E0E0E0">
							<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
							<ItemStyle CssClass="ItemGrilla"></ItemStyle>
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
			<script>
				/*
				var KEYTITULO="TitRep";
				var KEYSUBTITULO="SubTitRep";
				var URLHEADER = SIMA.Utilitario.Helper.General.ObtenerPathApp()+ "/General/Diapositivas/HeaderInformes.aspx?" 
								+ KEYTITULO + "=" + Page.Request.Params[KEYTITULO] 
								+"&"
								+ KEYSUBTITULO + "=" + Page.Request.Params[KEYSUBTITULO];
								
				$( "#HeaderRPT").load(URLHEADER, function(){alert( "Load was performed." );});
				*/
			</script>
		</form>
	</body>
</HTML>
