<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Page language="c#" Codebehind="ConsultarFormatoRubroMovimientoVCV2.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancieros.Directorio.ConsultarFormatoRubroMovimientoVCV2" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>DETALLE DE CONCEPTO</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../../js/Historial.js"></SCRIPT>
		<script language="javascript" src="../../../Editor/editor.js"></script>
		<script>
			function MostrarValor(idCentro)
			{				
				var mdiPadre = window.dialogArguments;
				var strValor ="";
				if (parseInt(idCentro) ==2)
				{
					strValor= Reemplazar(mdiPadre,'�','<');
					strValor= Reemplazar(strValor,'?','>');
					strValor= Reemplazar(strValor,'<P>',' ');
					strValor= Reemplazar(strValor,'</P>',' ');					
					strValor= Reemplazar(strValor,'&NBSP;','');
				}
				else if (parseInt(idCentro) ==3)
				{
					strValor= Reemplazar(mdiPadre,'�','<');
					strValor= Reemplazar(strValor,'?','>');
					strValor= Reemplazar(strValor,'<P>',' ');
					strValor= Reemplazar(strValor,'</P>',' ');					
					strValor= Reemplazar(strValor,'&NBSP;','');
				}
				else if (parseInt(idCentro) ==1)
				{
					strValor= Reemplazar(mdiPadre,'�','<');
					strValor= Reemplazar(strValor,'?','>');					
					strValor= Reemplazar(strValor,'<P>',' ');
					strValor= Reemplazar(strValor,'</P>',' ');					
					strValor= Reemplazar(strValor,'&NBSP;','');
				}
				else
				{
					strValor= Reemplazar(mdiPadre,'�','<');
					strValor= Reemplazar(strValor,'?','>');					
					strValor= Reemplazar(strValor,'<P>',' ');
					strValor= Reemplazar(strValor,'</P>',' ');					
					strValor= Reemplazar(strValor,'&NBSP;','');
				}				
				document.all["campo1"].value=strValor;
			}
			function OcultarFila()
			{
				/*if (document.all["grid"].rows[1].cells(0).innerText.length == 1)
				{
					document.all["grid"].rows[1].style.display="none";
				}*/
			}
			
		</script>
</HEAD>
	<body oncontextmenu="return false" bottomMargin="0" leftMargin="15" topMargin="0" onload="OcultarFila();ObtenerHistorial();MostrarValor(1)"
		rightMargin="0" onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			&nbsp;
			<TABLE cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE class="normal" id="Table1" style="WIDTH: 100%; HEIGHT: 155px" cellSpacing="0" cellPadding="0"
							border="0">
						</TABLE>
      <P align=left>
<asp:label id=Label1 runat="server" CssClass="TituloPrincipal" Height="1px">CONCEPTO   :</asp:label>
<asp:label id=lblRubro runat="server" CssClass="TituloPrincipal" Height="8px" Width="430px"></asp:label></P>
					</TD>
				</TR>
  <TR>
    <TD vAlign=top align=center width="100%">
      <P align=left>
<asp:label id=Label2 runat="server" Height="1px" Font-Size="XX-Small">OBSERVACIONES:</asp:label></P></TD></TR>
  <TR>
    <TD vAlign=top align=center width="100%"><TEXTAREA id="campo1" style="FONT-SIZE: 10px; WIDTH: 100%; FONT-FAMILY: Arial; HEIGHT: 152px"
										name="campo1" rows="9" readOnly cols="149" runat="server"></TEXTAREA></TD></TR>
				<TR>
					<TD vAlign="top" align="center" width="100%"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label><INPUT id="hObsCallao" style="WIDTH: 16px; HEIGHT: 10px" type="hidden" size="1" name="hObsCallao"
							runat="server"><INPUT id="hObsChimbote" style="WIDTH: 16px; HEIGHT: 10px" type="hidden" size="1" name="hObsChimbote"
							runat="server"><INPUT id="hObsIquitos" style="WIDTH: 16px; HEIGHT: 10px" type="hidden" size="1" name="hObsIquitos"
							runat="server"><INPUT id="hObsPeru" style="WIDTH: 16px; HEIGHT: 10px" type="hidden" size="1" name="hObsPeru"
							runat="server"></TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
<cc1:datagridweb id=grid runat="server" Width="100%" ShowFooter="True" AutoGenerateColumns="False" Visible="False">
										<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn DataField="descripcion" SortExpression="descripcion" HeaderText="CONCEPTO">
												<HeaderStyle Width="40%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle HorizontalAlign="Left" VerticalAlign="Middle"></FooterStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn Visible="False" HeaderText="FECHAS">
												<HeaderStyle HorizontalAlign="Center" Width="30%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Bottom"></ItemStyle>
												<HeaderTemplate>
													<TABLE id="Table15" cellSpacing="1" cellPadding="1" width="100%" align="left" border="0">
														<TR>
															<TD style="BORDER-BOTTOM: #cccccc 1px solid" align="center" width="100%" colSpan="6">
																<asp:Label id="lblHSP" runat="server" Height="3px" CssClass="HeaderGrilla" BorderStyle="None" 
 Font-Bold="True">SIMA-PERU S.A</asp:Label></TD>
														</TR>
														<TR>
															<TD style="BORDER-BOTTOM: #cccccc 1px solid" align="center" width="100%" colSpan="2"></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; BORDER-BOTTOM: #cccccc 1px solid" align="center"
																width="100%" colSpan="2">
																<asp:Label id="lblHSCH" runat="server" CssClass="HeaderGrilla" Width="82px" BorderStyle="None" 
 Font-Bold="True">SIMA-CHIMBOTE</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" width="100%" rowSpan="2">
																<asp:Label id="lblHTSPV" runat="server" CssClass="HeaderGrilla" Width="41px" BorderStyle="None" 
 Font-Bold="True">VENTAS</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" width="100%" rowSpan="2">
																<asp:Label id="lblHTSPC" runat="server" CssClass="HeaderGrilla" Width="41px" BorderStyle="None" 
 Font-Bold="True">COSTOS</asp:Label></TD>
														</TR>
														<TR>
															<TD width="100%">
																<asp:Label id="Label5" runat="server" CssClass="HeaderGrilla" Width="41px" BorderStyle="None" 
 Font-Bold="True">VENTAS</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" width="100%">
																<asp:Label id="Label6" runat="server" CssClass="HeaderGrilla" Width="41px" BorderStyle="None" 
 Font-Bold="True">COSTOS</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" width="100%">
																<asp:Label id="Label7" runat="server" CssClass="HeaderGrilla" Width="41px" BorderStyle="None" 
 Font-Bold="True">VENTAS</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" width="100%">
																<asp:Label id="Label9" runat="server" CssClass="HeaderGrilla" Width="41px" BorderStyle="None" 
 Font-Bold="True">COSTOS</asp:Label></TD>
														</TR>
													</TABLE>
												</HeaderTemplate>
												<ItemTemplate>
													<TABLE id="Table11" cellSpacing="1" cellPadding="1" width="100%" align="left" border="0">
														<TR>
															<TD align="right" width="100%">
																<asp:Label id="lblCallaoV" runat="server" Height="12px" CssClass="normaldetalle" Width="40px">Label</asp:Label></TD>
															<TD align="right" width="100%">
																<asp:Label id="lblCallaoC" runat="server" Height="12px" CssClass="normaldetalle" Width="41px">Label</asp:Label></TD>
															<TD align="right" width="100%">
																<asp:Label id="lblChimboteV" runat="server" Height="12px" CssClass="normaldetalle" Width="41px">Label</asp:Label></TD>
															<TD align="right" width="100%">
																<asp:Label id="lblChimboteC" runat="server" Height="12px" CssClass="normaldetalle" Width="41px">Label</asp:Label></TD>
															<TD align="right" width="100%">
																<asp:Label id="lblTotalPV" runat="server" Height="12px" CssClass="normaldetalle" Width="41px">Label</asp:Label></TD>
															<TD align="right" width="100%">
																<asp:Label id="lblTotalPC" runat="server" Height="12px" CssClass="normaldetalle" Width="41px">Label</asp:Label></TD>
														</TR>
													</TABLE>
												</ItemTemplate>
												<FooterStyle HorizontalAlign="Right" VerticalAlign="Bottom"></FooterStyle>
												<FooterTemplate>
													<TABLE id="Table16" cellSpacing="1" cellPadding="1" width="100%" align="left" border="0">
														<TR>
															<TD align="right" width="100%">
																<asp:Label id="lblFooterTotalSCV" runat="server" Height="12px" CssClass="FooterGrilla" Width="40px">Label</asp:Label></TD>
															<TD align="right" width="100%">
																<asp:Label id="lblFooterTotalSCC" runat="server" Height="12px" CssClass="FooterGrilla" Width="41px">Label</asp:Label></TD>
															<TD align="right" width="100%">
																<asp:Label id="lblFooterTotalSCHV" runat="server" Height="12px" CssClass="FooterGrilla" Width="41px">Label</asp:Label></TD>
															<TD align="right" width="100%">
																<asp:Label id="lblFooterTotalSCHC" runat="server" Height="12px" CssClass="FooterGrilla" Width="41px">Label</asp:Label></TD>
															<TD align="right" width="100%">
																<asp:Label id="lblFooterTotalSPV" runat="server" Height="12px" CssClass="FooterGrilla" Width="41px">Label</asp:Label></TD>
															<TD align="right" width="100%">
																<asp:Label id="lblFooterTotalSPC" runat="server" Height="12px" CssClass="FooterGrilla" Width="41px">Label</asp:Label></TD>
														</TR>
													</TABLE>
												</FooterTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn>
												<HeaderStyle HorizontalAlign="Center" Width="10%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Bottom"></ItemStyle>
												<HeaderTemplate>
													<TABLE id="Table4" height="100%" cellSpacing="1" cellPadding="1" width="100%" align="left"
														border="0">
														<TR>
															<TD style="BORDER-BOTTOM: #cccccc 1px solid" align="center" width="100%" colSpan="4">
																<asp:Label id="lblHSI" runat="server" Height="3px" CssClass="HeaderGrilla" BorderStyle="None" 
 Font-Bold="True">SIMA-IQUITOS SR.L.tda.</asp:Label></TD>
														</TR>
														<TR>
															<TD align="center" width="100%" height="40">
																<asp:Label id="Label11" runat="server" CssClass="HeaderGrilla" Width="41px" BorderStyle="None" 
 Font-Bold="True">VENTAS</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" align="center" width="100%" height="40">
																<asp:Label id="Label10" runat="server" CssClass="HeaderGrilla" Width="41px" BorderStyle="None" 
 Font-Bold="True">COSTOS</asp:Label></TD>
														</TR>
													</TABLE>
												</HeaderTemplate>
												<ItemTemplate>
													<TABLE id="Table5" cellSpacing="1" cellPadding="1" width="100%" align="left" border="0">
														<TR>
															<TD align="right" width="100%">
																<asp:Label id="lblIquitosV" runat="server" Height="12px" CssClass="normaldetalle" Width="40px">Label</asp:Label></TD>
															<TD align="right" width="100%">
																<asp:Label id="lblIquitosC" runat="server" Height="12px" CssClass="normaldetalle" Width="41px">Label</asp:Label></TD>
														</TR>
													</TABLE>
												</ItemTemplate>
												<FooterStyle HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
												<FooterTemplate>
													<TABLE id="Table14" cellSpacing="0" cellPadding="0" width="100%" align="left" border="0">
														<TR>
															<TD align="right" width="100%">
																<asp:Label id="lblFooterTotalSIV" runat="server" Height="12px" CssClass="FooterGrilla" Width="40px">Label</asp:Label></TD>
															<TD align="right" width="100%">
																<asp:Label id="lblFooterTotalSIC" runat="server" Height="12px" CssClass="FooterGrilla" Width="41px">Label</asp:Label></TD>
														</TR>
													</TABLE>
												</FooterTemplate>
											</asp:TemplateColumn>
										</Columns>
										<PagerStyle Visible="False" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb>
	</body>
</HTML>
