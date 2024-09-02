<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Page language="c#" Codebehind="ConsultarConveniosDirectorio.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.Convenio.ConsultarConveniosDirectorio" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>SIMANET</title>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../styles.css">
		<SCRIPT language="javascript" src="../js/@Import.js"></SCRIPT>
		<style>
		#fa { Z-INDEX: 1000; POSITION: absolute; TEXT-ALIGN: center; FILTER: alpha(opacity=0); MARGIN: 0px auto; DISPLAY: none; FONT-FAMILY: Arial,sans-serif; BACKGROUND: #fff; TOP: 0px; LEFT: 0px; opacity: 0; KHTMLOpacity: 0; -moz-opacity: 0 }
		#fa A { BORDER-BOTTOM: medium none; BORDER-LEFT: medium none; COLOR: #333; FONT-SIZE: 9px; BORDER-TOP: medium none; BORDER-RIGHT: medium none; TEXT-DECORATION: none }
		#fa IMG { BORDER-BOTTOM: medium none; BORDER-LEFT: medium none; BORDER-TOP: medium none; BORDER-RIGHT: medium none }
		#fa .fa_close { POSITION: absolute; TOP: 5px; RIGHT: 5px }
		.show#fa { DISPLAY: block }
		</style>
</HEAD>
	<body onunload="SubirHistorial();" onload="ObtenerHistorial();" bottomMargin="0" leftMargin="0"
		rightMargin="0" topMargin="0">
		<form style="Z-INDEX: 0" id="Form1" method="post" runat="server">
			<script type="text/javascript" src="../amcolumn/swfobject.js"></script>
			<TABLE id="Table1" border="0" cellSpacing="0" cellPadding="0" width="100%" align="center">
				<TR id="id1">
					<TD width="100%"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<tr id="id2">
					<TD><uc1:menu id="Menu2" runat="server"></uc1:menu></TD>
				</tr>
				<TR id="id3">
					<TD class="Commands"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Control de Convenios MGP *** MONTOS EN NS ***</asp:label></TD>
				</TR>
				<TR>
					<TD width="100%" align="center">
						<table id="Table2" border="0" cellSpacing="0" cellPadding="0" width="100%">
							<tr align="center">
								<td>
									<TABLE id="Table3" class="normal" border="0" cellSpacing="0" cellPadding="0" width="100%">
										<TR>
											<TD align="center">
												<TABLE id="Table4" border="0" cellSpacing="0" cellPadding="0" width="100%">
													<TR>
														<TD bgColor="#f5f5f5" align="center"><asp:label id="lblTituloPrincipal" runat="server" CssClass="TituloSecundario">CONVENIOS MGP</asp:label></TD>
													</TR>
													<TR id="id6">
														<TD bgColor="#f5f5f5" align="right"><IMG style="VISIBILITY: hidden; CURSOR: hand" id="ImgImprimir" onclick="oPrint = new SIMA.Utilitario.Helper.Dialogos();oPrint.VistaPrevia(this,id1,id2,id3,id4,id5,id6,id7,id8,id9);"
																alt="" src="../imagenes/bt_imprimir.gif"></TD>
													</TR>
													<TR id="id7">
														<TD bgColor="#f5f5f5" align="left"><asp:label id="lblTituloConvenio" runat="server" CssClass="TituloSecundario"> CONVENIO MGP - SIMA PERU</asp:label></TD>
													</TR>
												</TABLE>
												<cc1:datagridweb id="dgConsultarConvenioSimaMgp" runat="server" CssClass="HeaderGrilla" Width="100%"
													ShowFooter="True" RowPositionEnabled="False" RowHighlightColor="#E0E0E0" AutoGenerateColumns="False"
													AllowSorting="True">
													<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
													<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
													<FooterStyle HorizontalAlign="Right" CssClass="FooterGrilla" VerticalAlign="Bottom"></FooterStyle>
													<ItemStyle CssClass="ItemGrilla"></ItemStyle>
													<Columns>
														<asp:BoundColumn Visible="False" DataField="IdConvenioSimaMgp" HeaderText="IdConvenioSimaMgp"></asp:BoundColumn>
														<asp:TemplateColumn HeaderText="CONVENIO" FooterText="TOTAL:">
															<HeaderStyle Width="8%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															<FooterStyle HorizontalAlign="Center" VerticalAlign="Bottom"></FooterStyle>
														</asp:TemplateColumn>
														<asp:BoundColumn DataField="MontoAsignado" HeaderText="MARCO CONVENIO" DataFormatString="{0:# ### ### ##0.00}">
															<HeaderStyle Width="13%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
															<FooterStyle Font-Bold="True" VerticalAlign="Bottom"></FooterStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="MontoAprobado" HeaderText="MARCO APROBADO" DataFormatString="{0:# ### ### ##0.00}">
															<HeaderStyle HorizontalAlign="Center" Width="13%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
															<FooterStyle Font-Bold="True" VerticalAlign="Bottom"></FooterStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="avancefisico" HeaderText="AVANCE F&#205;SICO" DataFormatString="{0:# ### ### ##0.00}">
															<HeaderStyle HorizontalAlign="Center" Width="11%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="MontoEjecutado" HeaderText="ACTA DE CONFORMIDAD" DataFormatString="{0:# ### ### ##0.00}">
															<HeaderStyle Width="16%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
															<FooterStyle Font-Bold="True" VerticalAlign="Bottom"></FooterStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="MontoPagado" HeaderText="PAGADO" DataFormatString="{0:# ### ### ##0.00}">
															<HeaderStyle Width="11%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
															<FooterStyle VerticalAlign="Bottom"></FooterStyle>
														</asp:BoundColumn>
														<asp:BoundColumn Visible="False" HeaderText="POR CUOTAS">
															<HeaderStyle Width="13%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="MontoSaldo" HeaderText="SALDO CONVENIO" DataFormatString="{0:# ### ### ##0.00}">
															<HeaderStyle Width="13%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
														</asp:BoundColumn>
														<asp:TemplateColumn>
															<HeaderStyle Width="0%"></HeaderStyle>
															<ItemTemplate>
																<asp:Image id="ibtnGraficoEstadistico" runat="server" Width="21px" Height="18px" ImageUrl="../imagenes/Otros/ibtnGraficoBarra.gif"></asp:Image>
															</ItemTemplate>
														</asp:TemplateColumn>
													</Columns>
													<HeaderStyle Height="10px" CssClass="HeaderGrilla"></HeaderStyle>
												</cc1:datagridweb><BR>
												<asp:label id="lblResultadoConvenio" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
										</TR>
										<TR>
											<TD align="center">
												<P align="left"><asp:textbox style="Z-INDEX: 0" id="txtConvMGP" runat="server" Width="100%" Font-Bold="True"
														Height="40px" TextMode="MultiLine" BorderStyle="None"></asp:textbox></P>
											</TD>
										</TR>
										<TR id="id5">
											<TD align="left"><asp:textbox id="txtObservaciones" runat="server" CssClass="normaldetalle" Width="100%" Height="57px"
													TextMode="MultiLine" ReadOnly="True"></asp:textbox></TD>
										</TR>
										<TR>
											<TD align="left"></TD>
										</TR>
										<TR>
											<TD align="left"><asp:label id="lblTituloSecundario" runat="server" CssClass="TituloSecundario"> CONVENIO MGP - SIMA IQUITOS - COMOPERAMA</asp:label></TD>
										</TR>
										<tr>
											<td align="center"><cc1:datagridweb id="gridCOMOPERAMA" runat="server" CssClass="HeaderGrilla" Width="100%" ShowFooter="True"
													RowPositionEnabled="False" RowHighlightColor="#E0E0E0" AutoGenerateColumns="False" AllowSorting="True">
													<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
													<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
													<FooterStyle HorizontalAlign="Right" CssClass="FooterGrilla" VerticalAlign="Bottom"></FooterStyle>
													<ItemStyle CssClass="ItemGrilla"></ItemStyle>
													<Columns>
														<asp:BoundColumn Visible="False" DataField="IdConvenioSimaMgp" HeaderText="IdConvenioSimaMgp"></asp:BoundColumn>
														<asp:TemplateColumn HeaderText="CONVENIO" FooterText="TOTAL:">
															<HeaderStyle Width="8%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															<FooterStyle HorizontalAlign="Center" VerticalAlign="Bottom"></FooterStyle>
														</asp:TemplateColumn>
														<asp:BoundColumn DataField="MontoAsignado" HeaderText="MARCO CONVENIO" DataFormatString="{0:# ### ### ##0.00}">
															<HeaderStyle Width="13%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
															<FooterStyle Font-Bold="True" VerticalAlign="Bottom"></FooterStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="MontoAprobado" HeaderText="MARCO APROBADO" DataFormatString="{0:# ### ### ##0.00}">
															<HeaderStyle HorizontalAlign="Center" Width="13%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
															<FooterStyle Font-Bold="True" VerticalAlign="Bottom"></FooterStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="avancefisico" HeaderText="AVANCE F&#205;SICO" DataFormatString="{0:# ### ### ##0.00}">
															<HeaderStyle HorizontalAlign="Center" Width="11%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="MontoEjecutado" HeaderText="ACTA DE CONFORMIDAD" DataFormatString="{0:# ### ### ##0.00}">
															<HeaderStyle Width="16%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
															<FooterStyle Font-Bold="True" VerticalAlign="Bottom"></FooterStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="MontoPagado" HeaderText="PAGADO" DataFormatString="{0:# ### ### ##0.00}">
															<HeaderStyle Width="11%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
															<FooterStyle VerticalAlign="Bottom"></FooterStyle>
														</asp:BoundColumn>
														<asp:BoundColumn Visible="False" HeaderText="POR CUOTAS">
															<HeaderStyle Width="13%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="MontoSaldo" HeaderText="SALDO CONVENIO" DataFormatString="{0:# ### ### ##0.00}">
															<HeaderStyle Width="13%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
														</asp:BoundColumn>
														<asp:TemplateColumn>
															<HeaderStyle Width="0%"></HeaderStyle>
															<ItemTemplate>
																<asp:Image id="ibtnGraficoEstadisticoCOMOPERAMA" runat="server" Width="21px" Height="18px" 
 ImageUrl="/../imagenes/Otros/ibtnGraficoBarra.gif"></asp:Image>
															</ItemTemplate>
														</asp:TemplateColumn>
													</Columns>
													<HeaderStyle Height="10px" CssClass="HeaderGrilla"></HeaderStyle>
												</cc1:datagridweb><BR>
												<asp:label id="LblResultadoComoperpac" runat="server" CssClass="ResultadoBusqueda"></asp:label></td>
										</tr>
										<TR>
											<TD id="id8" bgColor="#ffffff" align="left"><asp:textbox style="Z-INDEX: 0" id="txtConvComoperama" runat="server" Width="100%" Font-Bold="True"
													Height="40px" TextMode="MultiLine" BorderStyle="None"></asp:textbox></TD>
										</TR>
										<TR id="id9">
											<TD bgColor="#ffffff" align="left"><asp:textbox id="txtObservaciobesCOMOPERAMA" runat="server" CssClass="normaldetalle" Width="100%"
													Height="57px" TextMode="MultiLine" ReadOnly="True"></asp:textbox></TD>
											<div style="Z-INDEX: 0; POSITION: absolute; DISPLAY: none; TOP: 0px; LEFT: 0px" id="ContenedorFlash"></div>
										</TR>
									</TABLE>
									<table style="BORDER-BOTTOM: dimgray 1px solid; POSITION: absolute; BORDER-LEFT: dimgray 1px solid; BACKGROUND-COLOR: #336699; DISPLAY: none; FONT-FAMILY: verdana; COLOR: #660000; FONT-SIZE: smaller; BORDER-TOP: dimgray 1px solid; TOP: 0px; FONT-WEIGHT: bold; BORDER-RIGHT: dimgray 1px solid; LEFT: 0px"
										id="ContenedorFlashTbl" border="3">
										<tr>
											<td align="right"><A href="javascript:cerrarGrafico();">Cerrar</A>
											</td>
										</tr>
										<tr>
											<td>
												<div style="POSITION: absolute" id="flashcontent"></div>
											</td>
										</tr>
									</table>
									<DIV></DIV>
								</td>
							<TR>
								<TD align="center">
									<TABLE id="Table5" border="0" cellSpacing="0" cellPadding="0" width="100%">
										<TR>
											<TD bgColor="#ffffff" align="left"><asp:label style="Z-INDEX: 0" id="Label1" runat="server" CssClass="TituloSecundario">TOTAL DE CONVENIOS</asp:label></TD>
										</TR>
										<TR>
											<TD bgColor="#ffffff" align="left"><cc1:datagridweb style="Z-INDEX: 0" id="gridTotales" runat="server" CssClass="HeaderGrilla" Width="100%"
													RowPositionEnabled="False" RowHighlightColor="#E0E0E0" AutoGenerateColumns="False">
													<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
													<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
													<FooterStyle HorizontalAlign="Right" CssClass="FooterGrilla" VerticalAlign="Bottom"></FooterStyle>
													<ItemStyle CssClass="ItemGrilla"></ItemStyle>
													<Columns>
														<asp:BoundColumn DataField="MontoAsignado" HeaderText="MARCO CONVENIOS" DataFormatString="{0:# ### ### ##0.00}">
															<HeaderStyle Width="13%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
															<FooterStyle Font-Bold="True" VerticalAlign="Bottom"></FooterStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="MontoAprobado" HeaderText="MARCO APROBADOS" DataFormatString="{0:# ### ### ##0.00}">
															<HeaderStyle HorizontalAlign="Center" Width="13%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
															<FooterStyle Font-Bold="True" VerticalAlign="Bottom"></FooterStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="avancefisico" HeaderText="AVANCE F&#205;SICO" DataFormatString="{0:# ### ### ##0.00}">
															<HeaderStyle HorizontalAlign="Center" Width="11%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="MontoEjecutado" HeaderText="ACTA DE CONFORMIDAD" DataFormatString="{0:# ### ### ##0.00}">
															<HeaderStyle Width="16%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
															<FooterStyle Font-Bold="True" VerticalAlign="Bottom"></FooterStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="MontoPagado" HeaderText="PAGADO" DataFormatString="{0:# ### ### ##0.00}">
															<HeaderStyle Width="11%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
															<FooterStyle VerticalAlign="Bottom"></FooterStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="MontoSaldo" HeaderText="SALDO CONVENIOS" DataFormatString="{0:# ### ### ##0.00}">
															<HeaderStyle Width="13%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
														</asp:BoundColumn>
													</Columns>
													<HeaderStyle Height="10px" CssClass="HeaderGrilla"></HeaderStyle>
												</cc1:datagridweb></TD>
										</TR>
										<TR id="id4" align="center" bgColor="#f5f5f5">
											<TD bgColor="#ffffff" align="left"><IMG style="CURSOR: hand" id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../imagenes/atras.gif"><INPUT style="WIDTH: 32px; HEIGHT: 22px" id="hGridPagina" value="0" size="1" type="hidden"
													name="hGridPagina" runat="server"><INPUT style="WIDTH: 32px; HEIGHT: 22px" id="hOrdenGrilla" size="1" type="hidden" name="hOrdenGrilla"
													runat="server"><INPUT style="WIDTH: 32px; HEIGHT: 22px" id="Hidden1" size="1" type="hidden" name="hCodigo"
													runat="server"><INPUT id="hCodigo" size="1" type="hidden" name="hCodigo" runat="server"></TD>
										</TR>
									</TABLE><INPUT style="Z-INDEX: 0" 
            id=hEfecto value=0 type=hidden name=Hidden2 
        runat="server">
								</TD>
							</TR>
						</table>
					</TD>
				</TR>
			</TABLE></TD></TR><TR>
				<TD width="592" vAlign="top"><IMG src="../imagenes/spacer.gif" width="592" height="6"></TD>
			</TR></TABLE>
			<div id="fa">
				<table border="6" bgcolor="#990000" bordercolor="#ffffff" width="100%" height="100%" cellpadding="4"
					cellspacing="0">
					<tr>
						<td align="center" valign="top"><font color="#ffffff" style="FONT-SIZE:26px"><strong>
									<p><font style="FONT-SIZE:45px"><br>
											INFO<INPUT id="Hidden2" value="0" type="hidden" name="Hidden2" runat="server">RMACIÓN 
											CLASIFICADA</font></p>
									<font style="FONT-SIZE:80px">SECRETO</font>
									<p><font style="FONT-SIZE:45px">NO DIVULGE LA INFORMACIÓN<br>
											CONTENIDA EN ESTA PRESENTACIÓN<br>
											<br>
											NO COMETA DELITO DE INFIDENCIA<br>
											<br>
										</font>
									</p>
									<p>LIBRO SEGUNDO - PARTE ESPECIAL - TÍTULO I - CAPÍTULO III ART. 78°, 79° Y 80° DEL
										<br>
										CÓDIGO DE JUSTICIA MILITAR POLICIAL - D.L. N°961 DE FECHA 10 DE MARZO 2006<br>
										<br>
										LEY N°27806 - LEY DE TRANSPARENCIA Y ACCESO A LA INFORMACIÓN PÚBLICA - ART 15°<br>
										INFORMACIÓN SECRETA</p>
								</strong></font>
						</td>
					</tr>
				</table>
			</div>
			<DIV></DIV>
			<script type="text/javascript">		
			function cerrarGrafico()
			{
				var msgbox = document.getElementById("ContenedorFlashTbl");
				msgbox.style.display='none';
			}
			function llenarGrafico(datos,titulo)
			{
				var msgbox = document.getElementById("ContenedorFlashTbl");
				var x = (window.screen.width / 2) - 400;
				var y = (window.screen.height / 2) - 300;   
	       
				msgbox.style.top = y;
				msgbox.style.left = x;

				msgbox.style.display='block';
				var so = new SWFObject("../amcolumn/amcolumn.swf", "amcolumn", "800", "600", "8", "#FFFFFF");
				so.addVariable("path", "../amcolumn/");
				so.addVariable("chart_data", datos);
				/*so.addVariable("chart_settings", "<settings><data_type></data_type><text_size>10</text_size>" +
												"<decimals_separator>.</decimals_separator>" +
												"<thousands_separator> </thousands_separator><redraw>true</redraw>" +
												"<depth>20</depth><angle>20</angle><column><spacing>0</spacing>" +
												"<grow_time>5</grow_time><grow_effect>strong</grow_effect><alpha>40</alpha>" +
												"<border_color>#000000</border_color><border_alpha>80</border_alpha>" +
												"<balloon_text><![CDATA[{series}: {value}]]></balloon_text></column>" +
												"<background><color>#000000</color><border_alpha>15</border_alpha>" +
												"</background><plot_area><margins><left>80</left></margins>" +
												"</plot_area><grid><category><color>#c5c5c5</color><alpha>80</alpha>" +
												"<dashed>true</dashed></category><value><color>#c9c9c9</color><alpha>40</alpha>" +
												"<dashed>true</dashed></value></grid><values><value><min>-0.0001</min>" +
												"</value></values><axes><category><alpha>0</alpha><width>3</width>" +
												"</category><value><alpha>20</alpha><width>3</width></value></axes>" +
												"<legend><enabled>false</enabled></legend><labels><label><x>0</x><y>25</y>" +
												"<align>center</align><text_size>18</text_size><text><![CDATA[<b>" + titulo +
												"</b>]]></text></label></labels></settings>")*/

				so.addVariable("chart_settings", "<settings>"
												+ "<data_type></data_type>"
												+ "<text_size>10</text_size>" 
												+ "<decimals_separator>.</decimals_separator>" 
												+ "<thousands_separator> </thousands_separator>"
												+ "<redraw>true</redraw>" 
												+ "<depth>20</depth>"
												+ "<angle>20</angle>"
												+ "<column>"
												+ "		<spacing>0</spacing>" 
												+ "		<grow_time>5</grow_time>"
												+ "		<grow_effect>strong</grow_effect>"
												+ "		<alpha>40</alpha>" 
												+ "		<border_color>#000000</border_color>"
												+ "		<border_alpha>80</border_alpha>" 
												+ "<balloon_text><![CDATA[{series}: {value}]]></balloon_text>"
												+ "</column>"
												+ "<background>"
												+ "		<color>#000000</color>"
												+ "		<border_alpha>15</border_alpha>" 
												+ "</background>"
												+ "<plot_area>"
												+ "		<margins>"
												+ "			<left>80</left>"
												+ "		</margins>" 
												+ "</plot_area>"
												+ "<grid>"
												+ "		<category>"
												+ "			<color>#c5c5c5</color>"
												+ "			<alpha>80</alpha>"
												+ "			<dashed>true</dashed>"
												+ "		</category>"
												+ "		<value>"
												+ "			<color>#c9c9c9</color>"
												+ "			<alpha>40</alpha>" 
												+ "			<dashed>true</dashed>"
												+ "		</value>"
												+ "</grid>"
												+ "<values>"
												+ "		<value>"
												+ "			<min>-0.0001</min>" 
												+ "		</value>"
												+ "</values>"
												+ "<axes>"
												+ "		<category>"
												+ "			<alpha>0</alpha>"
												+ "			<width>3</width>" 
												+ "		</category>"
												+ "		<value>"
												+ "			<alpha>20</alpha>"
												+ "			<width>3</width>"
												+ "		</value>"
												+ "</axes>"
												//+ "<balloon_text><![CDATA[{series}: {value}]]></balloon_text>"
												+ "<balloon>"
												+ "		<text_color>000000</text_color>"
												+ "		<corner_radius>4</corner_radius>"
												+ "		<border_width>3</border_width>"
												+ "		<border_alpha>50</border_alpha>" 
												+ "		<border_color>#000000</border_color>"
												+ "		<alpha>80</alpha>"
												+ "</balloon>"
												+ "<legend>"
												+ "		<enabled>false</enabled>"
												+ "</legend>"
												+ "<labels>"
												+ "		<label>"
												+ "			<x>0</x>"
												+ "			<y>25</y>" 
												+ "			<align>center</align>"
												+ "			<text_size>18</text_size>"
												+ "			<text><![CDATA[<b>" + titulo + "</b>]]></text>"
												+ "		</label>"
												+ "</labels>"
												+ "</settings>")												
				
				so.addVariable("preloader_color", "#999999");
				so.write("flashcontent");
			}
			</script>
			<script type='text/javascript'>if(jNet.get('hEfecto').value=='1'){ sFa();}</script>
		</form>
		<SCRIPT><asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal></SCRIPT>
	</body>
</HTML>
