<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Page language="c#" Codebehind="ConsultarConvenioCOMOPERAMA.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.Convenio.ConsultarConvenioCOMOPERAMA" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/Historial.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/JSFrameworkSima.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<script src="../amcolumn/swfobject.js" type="text/javascript"></script>
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR id="id1">
					<TD width="100%" colSpan="1"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR id="id2">
					<TD><uc1:menu id="Menu2" runat="server"></uc1:menu></TD>
				</TR>
				<TR id="id3">
					<TD class="Commands"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Producción ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Convenio COMOPERAMA</asp:label></TD>
				</TR>
				<TR>
					<TD align="center" width="100%">
						<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD align="center" bgColor="#f5f5f5"><asp:label id="lblTituloConvenio" runat="server" CssClass="TituloSecundario"> CONVENIO COMOPERAMA</asp:label></TD>
							</TR>
							<TR>
								<TD align="right" bgColor="#f5f5f5"><IMG id="ImgImprimir" style="CURSOR: hand" onclick="oPrint = new SIMA.Utilitario.Helper.Dialogos();oPrint.VistaPrevia(this,id1,id2,id3,id4,id5);"
										alt="" src="../imagenes/bt_imprimir.gif"></TD>
							</TR>
							<TR>
								<TD align="center" bgColor="#f5f5f5"><cc1:datagridweb id="dgConsultarConvenioSimaMgp" runat="server" CssClass="HeaderGrilla" Width="100%"
										ShowFooter="True" RowPositionEnabled="False" RowHighlightColor="#E0E0E0" AutoGenerateColumns="False" AllowSorting="True">
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
										<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
										<FooterStyle HorizontalAlign="Right" CssClass="FooterGrilla" VerticalAlign="Bottom"></FooterStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<Columns>
											<asp:BoundColumn Visible="False" DataField="IdConvenioSimaMgp" HeaderText="IdConvenioSimaMgp">
												<HeaderStyle Width="0%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="CONVENIO" FooterText="TOTAL:">
												<HeaderStyle Width="8%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle HorizontalAlign="Center" VerticalAlign="Bottom"></FooterStyle>
											</asp:TemplateColumn>
											<asp:BoundColumn DataField="MontoAsignado" HeaderText="MONTO CONVENIO" DataFormatString="{0:# ### ### ##0.00}">
												<HeaderStyle Width="13%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle Font-Bold="True" VerticalAlign="Bottom"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="MontoAprovado" HeaderText="MONTO APROBADO" DataFormatString="{0:# ### ### ##0.00}">
												<HeaderStyle Width="13%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle Font-Bold="True" VerticalAlign="Bottom"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="avancefisico" HeaderText="AVANCE F&#205;SICO" DataFormatString="{0:# ### ### ##0.00}">
												<HeaderStyle Width="11%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="MontoEjecutado" HeaderText="ACTA DE CONFORMIDAD" DataFormatString="{0:# ### ### ##0.00}">
												<HeaderStyle Width="16%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle Font-Bold="True" VerticalAlign="Bottom"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="PAGADO" DataFormatString="{0:# ### ### ##0.00}">
												<HeaderStyle Width="11%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle VerticalAlign="Bottom"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="PAGO POR CUOTAS" DataFormatString="{0:# ### ### ##0.00}">
												<HeaderStyle Width="13%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
												<FooterStyle HorizontalAlign="Right"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="MontoSaldo" HeaderText="SALDO CONVENIO" DataFormatString="{0:# ### ### ##0.00}">
												<HeaderStyle Width="13%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle Font-Bold="True" VerticalAlign="Bottom"></FooterStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn>
												<ItemTemplate>
													<asp:Image id="ibtnGraficoEstadistico" runat="server" Width="19px" Height="18px" ImageUrl="/SimaNetWeb/imagenes/Otros/ibtnGraficoBarra.gif"></asp:Image>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
										<HeaderStyle Height="10px" CssClass="HeaderGrilla"></HeaderStyle>
									</cc1:datagridweb><BR>
									<asp:label id="lblResultadoConvenio" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
							</TR>
							<TR>
								<TD align="left" bgColor="#f5f5f5"><asp:label id="lblObservaciones" runat="server" CssClass="normal">OBSERVACIONES DEL CONVENIO :</asp:label></TD>
							</TR>
							<TR>
								<TD align="left" bgColor="#f5f5f5"><asp:textbox id="txtObservaciones" runat="server" CssClass="normaldetalle" Width="100%" Height="57px"
										TextMode="MultiLine" ReadOnly="True"></asp:textbox></TD>
							</TR>
							<TR>
								<TD align="left" bgColor="#f5f5f5"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="/SimanetWeb/imagenes/atras.gif"><INPUT id="hGridPagina" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" value="0"
										name="hGridPagina" runat="server"><INPUT id="hOrdenGrilla" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="hOrdenGrilla"
										runat="server"><INPUT id="Hidden1" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="hCodigo"
										runat="server"><INPUT id="hCodigo" type="hidden" size="1" name="hCodigo" runat="server"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
			<div id="ContenedorFlash" style="DISPLAY: none; POSITION: absolute">
				<table style="BORDER-RIGHT: dimgray 1px solid; BORDER-TOP: dimgray 1px solid; FONT-WEIGHT: bold; FONT-SIZE: smaller; BORDER-LEFT: dimgray 1px solid; COLOR: #660000; BORDER-BOTTOM: dimgray 1px solid; FONT-FAMILY: verdana; BACKGROUND-COLOR: #336699">
					<tr>
						<td align="right"><A href="javascript:cerrarGrafico();">Cerrar</A>
						</td>
					</tr>
					<tr>
						<td>
							<div id="flashcontent"></div>
						</td>
					</tr>
				</table>
			</div>
			<script type="text/javascript">
			function cerrarGrafico()
			{
				var msgbox = document.getElementById("ContenedorFlash");
				msgbox.style.display='none';
			}
			function llenarGrafico(datos,titulo)
			{
				var msgbox = document.getElementById("ContenedorFlash");
				var x = (window.screen.width / 2) - 400;
				var y = (window.screen.height / 2) - 300;   
			       
				msgbox.style.top = y;
				msgbox.style.left = x;

				msgbox.style.display='block';
				var so = new SWFObject("../amcolumn/amcolumn.swf", "amcolumn", "800", "600", "8", "#FFFFFF");
				so.addVariable("path", "../amcolumn/");
				so.addVariable("chart_data", datos);
				so.addVariable("chart_settings", "<settings><data_type></data_type><text_size>10</text_size>" +
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
												"	<balloon>"+
												"		<text_color>000000</text_color>"+
												"		<corner_radius>4</corner_radius>"+
												"		<border_width>3</border_width>"+
												"		<border_alpha>50</border_alpha>"+ 
												"		<border_color>#000000</border_color>"+
												"		<alpha>80</alpha>"+
												"</balloon>"+
												"<legend><enabled>false</enabled></legend><labels><label><x>0</x><y>25</y>" +
												"<align>center</align><text_size>18</text_size><text><![CDATA[<b>" + titulo +
												"</b>]]></text></label></labels></settings>")
				
				so.addVariable("preloader_color", "#999999");
				so.write("flashcontent");
			}
			</script>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
