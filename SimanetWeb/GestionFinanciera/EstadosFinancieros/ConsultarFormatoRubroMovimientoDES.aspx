<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Page language="c#" Codebehind="ConsultarFormatoRubroMovimientoDES.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancieros.ConsultarFormatoRubroMovimientoDES" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DETALLE DE CONCEPTO</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
		<script language="javascript" src="../../Editor/editor.js"></script>
		<script>			
			function MostrarValor(idCentro)
			{				
				var mdiPadre = window.dialogArguments;
				var strValor ="";
				if (parseInt(idCentro) ==2)
				{
					strValor= Reemplazar(mdiPadre.vCallao,'¿','<');
					strValor= Reemplazar(strValor,'?','>');
					strValor= Reemplazar(strValor,'<P>',' ');
					strValor= Reemplazar(strValor,'</P>',' ');					
					strValor= Reemplazar(strValor,'&NBSP;','');
				}
				else if (parseInt(idCentro) ==3)
				{
					strValor= Reemplazar(mdiPadre.vChimbote,'¿','<');
					strValor= Reemplazar(strValor,'?','>');
					strValor= Reemplazar(strValor,'<P>',' ');
					strValor= Reemplazar(strValor,'</P>',' ');					
					strValor= Reemplazar(strValor,'&NBSP;','');
				}
				else if (parseInt(idCentro) ==1)
				{
					strValor= Reemplazar(mdiPadre.vPeru,'¿','<');
					strValor= Reemplazar(strValor,'?','>');					
					strValor= Reemplazar(strValor,'<P>',' ');
					strValor= Reemplazar(strValor,'</P>',' ');					
					strValor= Reemplazar(strValor,'&NBSP;','');
				}
				else
				{
					strValor= Reemplazar(mdiPadre.vIquitos,'¿','<');
					strValor= Reemplazar(strValor,'?','>');					
					strValor= Reemplazar(strValor,'<P>',' ');
					strValor= Reemplazar(strValor,'</P>',' ');					
					strValor= Reemplazar(strValor,'&NBSP;','');					
				}				
				document.all["campo1"].value=strValor;			
			}		
			
			function OcultarFila()
			{
				if (document.all["grid"].rows[1].cells(0).innerText.length == 1)
				{
					document.all["grid"].rows[1].style.display="none";					
				}
			}
			
		</script>
	</HEAD>
	<body oncontextmenu="return false" bottomMargin="0" leftMargin="15" topMargin="0" onload="OcultarFila();ObtenerHistorial();MostrarValor(2);CambiarColorSeleccionGrillaPopup(grid__ctl1_lblHCallao);"
		rightMargin="0" onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE class="normal" id="Table1" style="WIDTH: 100%; HEIGHT: 104px" cellSpacing="0" cellPadding="0"
							border="0">
							<TR>
								<TD style="WIDTH: 100%" align="center" width="764" colSpan="3">
									<TABLE style="HEIGHT: 22px" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD style="WIDTH: 19px" colSpan="7">
												<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="100%" align="left" border="0">
													<TR>
														<TD><asp:label id="Label1" runat="server" CssClass="TituloPrincipal" Height="1px">CONCEPTO   :</asp:label></TD>
														<TD><asp:label id="lblRubro" runat="server" CssClass="TituloPrincipal" Height="8px" Width="430px"></asp:label></TD>
													</TR>
												</TABLE>
												<INPUT id="hObsCallao" style="WIDTH: 16px; HEIGHT: 10px" type="hidden" size="1" name="hObsCallao"
													runat="server"><INPUT id="hObsChimbote" style="WIDTH: 16px; HEIGHT: 10px" type="hidden" size="1" name="hObsChimbote"
													runat="server"><INPUT id="hObsIquitos" style="WIDTH: 16px; HEIGHT: 10px" type="hidden" size="1" name="hObsIquitos"
													runat="server"></TD>
										</TR>
									</TABLE>
									<cc1:datagridweb id="grid" runat="server" Width="100%" RowHighlightColor="#E0E0E0" AutoGenerateColumns="False"
										ShowFooter="True">
										<PagerStyle Visible="False" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
										<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<Columns>
											<asp:BoundColumn DataField="descripcion" SortExpression="descripcion" HeaderText="CONCEPTO">
												<HeaderStyle Width="80%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle HorizontalAlign="Left" VerticalAlign="Middle"></FooterStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="SIMA PERU">
												<HeaderStyle HorizontalAlign="Center" Width="20%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Bottom"></ItemStyle>
												<HeaderTemplate>
													<TABLE id="Table11" cellSpacing="1" cellPadding="1" width="100%" align="center" border="0">
														<TR>
															<TD align="center" colSpan="3">
																<asp:Label id="lblHCallao" runat="server" CssClass="HeaderGrilla" Width="100%" Font-Bold="True"
																	BorderStyle="None">DES</asp:Label></TD>
														</TR>
													</TABLE>
												</HeaderTemplate>
												<ItemTemplate>
													<TABLE id="Table6" cellSpacing="1" cellPadding="1" width="100%" align="left" border="0">
														<TR>
															<TD align="right">
																<asp:Label id="lblCallao" runat="server" Height="12px" CssClass="normaldetalle" Width="100%">Label</asp:Label></TD>
														</TR>
													</TABLE>
												</ItemTemplate>
												<FooterStyle HorizontalAlign="Right" VerticalAlign="Bottom"></FooterStyle>
												<FooterTemplate>
													<DIV align="right">
														<DIV align="right">
															<asp:Label id="lblFooterCallao" runat="server" Height="12px" CssClass="FooterGrilla" Width="100%"
																DESIGNTIMEDRAGDROP="116">Label</asp:Label></DIV>
													</DIV>
												</FooterTemplate>
											</asp:TemplateColumn>
										</Columns>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
									</cc1:datagridweb></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 100%" align="center" width="764" colSpan="3"><TEXTAREA id="campo1" style="FONT-SIZE: 10px; WIDTH: 100%; FONT-FAMILY: Arial; HEIGHT: 80px"
										name="campo1" readOnly runat="server">									
									</TEXTAREA>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label><INPUT id="hObsPeru" style="WIDTH: 16px; HEIGHT: 10px" type="hidden" size="1" name="hObsPeru"
							runat="server"></TD>
				</TR>
			</table>
			&nbsp;
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
