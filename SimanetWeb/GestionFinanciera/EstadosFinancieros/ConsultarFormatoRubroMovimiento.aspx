<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Page language="c#" Codebehind="ConsultarFormatoRubroMovimiento.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancieros.ConsultarFormatoRubroMovimiento" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>DETALLE DE CONCEPTO</title>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../../styles.css">
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>
		<script language="javascript" src="../../Editor/editor.js"></script>
		<script>			
			function MostrarValor(idCentro){
				var NombreControl="campo" + idCentro;
				var mdiPadre = window.dialogArguments;
				var strValor ="";
				if (parseInt(idCentro) ==2)
				{
					strValor = mdiPadre.vCallao;
				}
				else if (parseInt(idCentro) ==3)
				{
					strValor = mdiPadre.vChimbote;
				}
				else if (parseInt(idCentro) ==1)
				{
					strValor = mdiPadre.vPeru;
				}
				else
				{
					strValor = mdiPadre.vIquitos;
				}				
				strValor = strValor.Replace('[a]','\341')
										.Replace('[e]','\351')
										.Replace('[i]','\355')
										.Replace('[o]','\363')
										.Replace('[u]','\372')
										.Replace('[n]','\361')
										.Replace('[A]','\301')
										.Replace('[E]','\311')
										.Replace('[I]','\315')
										.Replace('[O]','\323')
										.Replace('[U]','\332')
										.Replace('[N]','\321')
										.Replace("¿","<")
										.Replace("?",">")
										.Replace("[men]","<")
										.Replace("[may]",">")
										.Replace("[AMP]","&")
										.Replace("[MEN]","<")
										.Replace("[MAY]",">")
										.Replace("&NBSP;","&nbsp;");
				
				
				var objCampo = document.all[NombreControl];
				objCampo.value=strValor;
				
			}		
			
			function OcultarFila()
			{
				if (document.all["grid"].rows[1].cells(0).innerText.length == 1)
				{
					document.all["grid"].rows[1].style.display="none";					
				}
			}
			
			function OcultarMostrarFila(idCentro){
				var otblContext = $O("tblContext");
				otblContext.rows[1].style.display="none";
				otblContext.rows[2].style.display="none";
				otblContext.rows[3].style.display="none";
				otblContext.rows[4].style.display="none";
				otblContext.rows[idCentro].style.display="block";
			}
			
		</script>
		<SCRIPT language="Javascript1.2">
		<!-- 
		//window.aler();
		// Carga de htmlarea
		_editor_url = "/SimanetWeb/Editor/"; // URL del archivo htmlarea
		var win_ie_ver = parseFloat(navigator.appVersion.split("MSIE")[1]);
		if (navigator.userAgent.indexOf('Mac')        >= 0) { win_ie_ver = 0; }
		if (navigator.userAgent.indexOf('Windows CE') >= 0) { win_ie_ver = 0; }
		if (navigator.userAgent.indexOf('Opera')      >= 0) { win_ie_ver = 0; }
		
		if (win_ie_ver >= 5.5) 
		{
			var strScript = '<scr' + 'ipt src="' +_editor_url+ 'editor.js"'
			document.write(strScript);
			var strScript2 = ' language="Javascript1.2"></scr' + 'ipt>';
			document.write(strScript2);  
		} 
		else 
		{ 
			document.write('<scr'+'ipt>function editor_generate() { return false; }</scr'+'ipt>'); 
		}
		// -->
		
		
		</SCRIPT>
</HEAD>
	<body oncontextmenu="return false" onload="OcultarFila();MostrarValor(1);MostrarValor(2);MostrarValor(3);MostrarValor(4);OcultarMostrarFila(1);CambiarColorSeleccionGrillaPopup(grid__ctl1_lblHPeru);"
		bottomMargin="0" leftMargin="15" rightMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<table id="tblContext" border="0" cellSpacing="0" cellPadding="0" width="100%" align="center">
				<TR>
					<TD vAlign="top" width="100%" align="center">
						<TABLE style="WIDTH: 100%; HEIGHT: 104px" id="Table1" class="normal" border="0" cellSpacing="0"
							cellPadding="0">
							<TR>
								<TD style="WIDTH: 100%" width="764" colSpan="3" align="center">
									<TABLE style="HEIGHT: 22px" border="0" cellSpacing="0" cellPadding="0" width="100%">
										<TR>
											<TD style="WIDTH: 19px" colSpan="7">
												<TABLE id="Table2" border="0" cellSpacing="1" cellPadding="1" width="100%" align="left">
													<TR>
														<TD><asp:label id="Label1" runat="server" Height="1px" CssClass="TituloPrincipal">CONCEPTO   :</asp:label></TD>
														<TD><asp:label id="lblRubro" runat="server" Height="8px" CssClass="TituloPrincipal" Width="430px"></asp:label></TD>
													</TR>
												</TABLE>
												<INPUT style="WIDTH: 16px; HEIGHT: 10px" id="hObsCallao" size="1" type="hidden" name="hObsCallao"
													runat="server"><INPUT style="WIDTH: 16px; HEIGHT: 10px" id="hObsChimbote" size="1" type="hidden" name="hObsChimbote"
													runat="server"><INPUT style="WIDTH: 16px; HEIGHT: 10px" id="hObsIquitos" size="1" type="hidden" name="hObsIquitos"
													runat="server"></TD>
										</TR>
									</TABLE>
									<cc1:datagridweb id="grid" runat="server" Width="100%" ShowFooter="True" AutoGenerateColumns="False"
										RowHighlightColor="#E0E0E0">
										<PagerStyle Visible="False" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
										<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<Columns>
											<asp:BoundColumn DataField="descripcion" SortExpression="descripcion" HeaderText="CONCEPTO">
												<HeaderStyle Width="50%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle HorizontalAlign="Left" VerticalAlign="Middle"></FooterStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="SIMA PERU">
												<HeaderStyle HorizontalAlign="Center" Width="40%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Bottom"></ItemStyle>
												<HeaderTemplate>
													<DIV align="left">
														<TABLE id="Table11" cellSpacing="1" cellPadding="1" width="100%" align="left" border="0"
															DESIGNTIMEDRAGDROP="48">
															<TR>
																<TD style="BORDER-BOTTOM: #cccccc 1px solid" align="center" colSpan="3">
																	<asp:Label id="lblHPeru" runat="server" Height="3px" CssClass="HeaderGrilla" Width="100%" BorderStyle="None" 
 Font-Bold="True">SIMA-PERU S.A</asp:Label></TD>
															</TR>
															<TR>
																<TD align="center">
																	<asp:Label id="lblHCallao" runat="server" CssClass="HeaderGrilla" Width="70px" BorderStyle="None" 
 Font-Bold="True">SIMA-CALLAO</asp:Label></TD>
																<TD style="BORDER-LEFT: #cccccc 1px solid" align="center">
																	<asp:Label id="lblHChimbote" runat="server" CssClass="HeaderGrilla" Width="85px" BorderStyle="None" 
 Font-Bold="True">SIMA-CHIMBOTE</asp:Label></TD>
																<TD style="BORDER-LEFT: #cccccc 1px solid" align="center">
																	<asp:Label id="Label2" runat="server" CssClass="HeaderGrilla" Width="70px" BorderStyle="None" 
 Font-Bold="True">SC + SCH</asp:Label></TD>
															</TR>
														</TABLE>
													</DIV>
												</HeaderTemplate>
												<ItemTemplate>
													<DIV align="left">
														<TABLE id="Table8" cellSpacing="1" cellPadding="1" width="100%" align="left" border="0">
															<TR>
																<TD align="right">
																	<asp:Label id="lblCallao" runat="server" Height="12px" CssClass="normaldetalle" Width="70px">Label</asp:Label></TD>
																<TD align="right">
																	<asp:Label id="lblChimbote" runat="server" Height="12px" CssClass="normaldetalle" Width="85px">Label</asp:Label></TD>
																<TD align="right">
																	<asp:Label id="lblTotalSP" runat="server" Height="12px" CssClass="normaldetalle" Width="70px">Label</asp:Label></TD>
															</TR>
														</TABLE>
													</DIV>
												</ItemTemplate>
												<FooterStyle HorizontalAlign="Right" VerticalAlign="Bottom"></FooterStyle>
												<FooterTemplate>
													<DIV align="left">
														<TABLE id="Table7" cellSpacing="1" cellPadding="1" width="100%" align="left" border="0"
															DESIGNTIMEDRAGDROP="366">
															<TR>
																<TD align="right">
																	<asp:Label id="lblFooterCallao" runat="server" Height="12px" CssClass="FooterGrilla" Width="70px">Label</asp:Label></TD>
																<TD align="right">
																	<asp:Label id="lblFooterChimbote" runat="server" Height="12px" CssClass="FooterGrilla" Width="85px">Label</asp:Label></TD>
																<TD align="right">
																	<asp:Label id="lblFooterTotalSP" runat="server" Height="12px" CssClass="FooterGrilla" Width="70px">Label</asp:Label></TD>
															</TR>
														</TABLE>
													</DIV>
												</FooterTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn DataField="SimaIquitos" HeaderText="SIMA-IQUITOS &lt;BR&gt; S.R.Ltda.">
												<HeaderStyle HorizontalAlign="Center" Width="10%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
											</asp:BoundColumn>
										</Columns>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
									</cc1:datagridweb></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="BORDER-BOTTOM: gray 1px solid; BORDER-LEFT: gray 1px solid; HEIGHT: 450px; BORDER-TOP: gray 1px solid; BORDER-RIGHT: gray 1px solid" vAlign="top" width="100%" align="center"><TEXTAREA style="Z-INDEX: 0; WIDTH: 100%; BACKGROUND-REPEAT: no-repeat; HEIGHT: 100%" id="campo1"
							rows="20132" cols="66" name="campo1" runat="server"></TEXTAREA>
					</TD>
				</TR>
				<tr>
					<TD style="BORDER-BOTTOM: gray 1px solid; BORDER-LEFT: gray 1px solid; HEIGHT: 450px; BORDER-TOP: gray 1px solid; BORDER-RIGHT: gray 1px solid" vAlign="top" width="100%" align="center"><TEXTAREA style="Z-INDEX: 0; WIDTH: 100%; BACKGROUND-REPEAT: no-repeat; HEIGHT: 100%" id="campo2"
							rows="20132" cols="66" name="campo2" runat="server"> </TEXTAREA>
					</TD>
				</tr>
				<tr>
					<TD style="BORDER-BOTTOM: gray 1px solid; BORDER-LEFT: gray 1px solid; HEIGHT: 450px; BORDER-TOP: gray 1px solid; BORDER-RIGHT: gray 1px solid" vAlign="top" width="100%" align="center"><TEXTAREA style="Z-INDEX: 0; WIDTH: 100%; BACKGROUND-REPEAT: no-repeat; HEIGHT: 100%" id="campo3"
							rows="20132" cols="66" name="campo3" runat="server"> </TEXTAREA>
					</TD>
				</tr>
				<tr>
					<TD style="BORDER-BOTTOM: gray 1px solid; BORDER-LEFT: gray 1px solid; HEIGHT: 450px; BORDER-TOP: gray 1px solid; BORDER-RIGHT: gray 1px solid" vAlign="top" width="100%" align="center"><TEXTAREA style="Z-INDEX: 0; WIDTH: 100%; BACKGROUND-REPEAT: no-repeat; HEIGHT: 100%" id="campo4"
							rows="20132" cols="66" name="campo4" runat="server"> </TEXTAREA>
					</TD>
				</tr>
				<TR>
					<TD vAlign="top" width="100%" align="center"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label><INPUT style="WIDTH: 16px; HEIGHT: 10px" id="hObsPeru" size="1" type="hidden" name="hObsPeru"
							runat="server"></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<DIV align="left">
							<DIV align="left">&nbsp;</DIV>
						</DIV>
					</TD>
				</TR>
			</table>
			&nbsp;
		</form>
		<SCRIPT language="JavaScript1.2" defer>
			editor_generate("campo1");
			editor_generate("campo2");
			editor_generate("campo3");
			editor_generate("campo4");
		</SCRIPT>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
