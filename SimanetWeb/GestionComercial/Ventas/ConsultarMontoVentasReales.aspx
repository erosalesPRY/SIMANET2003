<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Page language="c#" Codebehind="ConsultarMontoVentasReales.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.Ventas.ConsultarMontoVentasReales" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/JSFrameworkSima.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR id="Cabecera">
					<TD colSpan="3"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR id="Menu">
					<TD colSpan="3"><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD vAlign="middle" align="center">
						<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<TBODY>
								<TR id="Navegacion">
									<TD class="Commands" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Comercial > Ventas ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual" style="Z-INDEX: 0"> Consulta de Ventas Colocadas Totales</asp:label></TD>
								</TR>
								<TR>
									<TD class="TituloPrincipal" align="center" colSpan="3"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal"> CONSULTA DE VENTAS COLOCADAS TOTALES CORRESPONDIENTE AL MES DE</asp:label></TD>
								</TR>
								<TR>
									<TD align="center" vAlign="top">&nbsp;
										<TABLE class="normal" id="Table4" cellSpacing="0" cellPadding="0" width="780" border="0">
											<TR>
												<TD align="center" width="100%" colSpan="3">
													<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="780" border="0">
														<TR>
															<TD></TD>
															<TD colSpan="4"><asp:imagebutton id="ibtnGraficoBarraLineaNegocio" runat="server" ImageUrl="/SimaNetWeb/imagenes/Otros/ibtnGraficoBarra.gif"
																	ToolTip="Venta Real Por Linea de Negocio Mensual"></asp:imagebutton><IMG height="8" src="../../imagenes/spacer.gif" width="3">
																<asp:imagebutton id="ibtnGraficoBarraPeriodo" runat="server" ToolTip="Venta Real Acumulada" ImageUrl="/SimaNetWeb/imagenes/Otros/ibtnGraficoBarra.gif"></asp:imagebutton><IMG height="8" src="../../imagenes/spacer.gif" width="3"><asp:imagebutton id="ibtnGraficoVentaRealTorta" runat="server" ImageUrl="/SimaNetWeb/imagenes/Otros/ibtnGraficoPie.gif"
																	ToolTip="Venta Real por Centro Acumulado"></asp:imagebutton><IMG height="8" src="../../imagenes/spacer.gif" width="3">
																<asp:imagebutton id="ibtnGraficoVentaRealAcumuladaTorta" runat="server" ToolTip="Venta Real por Centro Acumulado"
																	ImageUrl="/SimaNetWeb/imagenes/Otros/ibtnGraficoPie.gif"></asp:imagebutton></TD>
															<TD></TD>
															<TD></TD>
															<TD></TD>
															<TD></TD>
															<TD align="right" width="4"></TD>
														</TR>
														<TR>
															<TD bgColor="#f0f0f0"><IMG height="22" src="../../imagenes/tab_izq.gif" width="4"></TD>
															<TD bgColor="#f0f0f0"><IMG height="8" src="../../imagenes/spacer.gif" width="130"></TD>
															<TD bgColor="#f0f0f0"></TD>
															<TD bgColor="#f0f0f0"></TD>
															<TD bgColor="#f0f0f0"></TD>
															<TD bgColor="#f0f0f0"><asp:imagebutton id="ibtnPorcentajePromotor" runat="server" ImageUrl="../../imagenes/btnComparativoLogrosCentro.jpg"></asp:imagebutton></TD>
															<TD bgColor="#f0f0f0"><asp:imagebutton id="ibtnComparativoVentaReal" runat="server" ImageUrl="../../imagenes/btnPeriodoVSAñoAnterior.jpg"></asp:imagebutton></TD>
															<TD bgColor="#f0f0f0"><asp:imagebutton id="ibtnCompararVentasPresupuestadas" runat="server" ImageUrl="../../imagenes/comp_ventas_pres.gif"></asp:imagebutton></TD>
															<TD bgColor="#f0f0f0"><IMG id="ImgImprimir" onclick="oPrint = new SIMA.Utilitario.Helper.Dialogos();oPrint.VistaPrevia(this,Cabecera,Menu,Table5,botonAtras,Navegacion);"
																	alt="" src="../../imagenes/bt_imprimir.gif"></TD>
															<TD align="right" width="4"><IMG height="22" src="../../imagenes/tab_der.gif" width="4"></TD>
														</TR>
													</TABLE>
													<cc1:datagridweb id="dgConsultaMensual" runat="server" CssClass="HeaderGrilla" RowPositionEnabled="False"
														AutoGenerateColumns="False" RowHighlightColor="#E0E0E0" Width="780px">
														<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
														<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
														<FooterStyle CssClass="FooterGrilla"></FooterStyle>
														<ItemStyle CssClass="ItemGrilla"></ItemStyle>
														<Columns>
															<asp:BoundColumn DataField="titulo" HeaderText="AVANCE DEL MES">
																<HeaderStyle Width="30%"></HeaderStyle>
																<ItemStyle HorizontalAlign="Left"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="totalcallao" HeaderText="SIMA-CALLAO">
																<HeaderStyle Width="18%"></HeaderStyle>
																<ItemStyle HorizontalAlign="Right"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="totalchimbote" HeaderText="SIMA-CHIMBOTE">
																<HeaderStyle Width="18%"></HeaderStyle>
																<ItemStyle HorizontalAlign="Right"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="totaliquitos" HeaderText="SIMA-IQUITOS S.R.LTDA.">
																<HeaderStyle Width="18%"></HeaderStyle>
																<ItemStyle HorizontalAlign="Right"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="total" HeaderText="TOTAL">
																<HeaderStyle Width="18%"></HeaderStyle>
																<ItemStyle HorizontalAlign="Right"></ItemStyle>
															</asp:BoundColumn>
														</Columns>
														<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
													</cc1:datagridweb></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
				</TR>
				<TR>
					<TD vAlign="top" align="center"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False" style="Z-INDEX: 0"></asp:label></TD>
				</TR>
				<TR>
					<TD align="center">
						<cc1:datagridweb style="Z-INDEX: 0" id="dgAvanceAcumulado" runat="server" CssClass="HeaderGrilla"
							Width="780px" RowHighlightColor="#E0E0E0" AutoGenerateColumns="False" RowPositionEnabled="False">
							<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
							<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
							<FooterStyle CssClass="FooterGrilla"></FooterStyle>
							<ItemStyle HorizontalAlign="Right" CssClass="ItemGrilla"></ItemStyle>
							<Columns>
								<asp:BoundColumn DataField="titulo" HeaderText="AVANCE ACUMULADO">
									<HeaderStyle Width="30%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="totalcallao" HeaderText="SIMA-CALLAO">
									<HeaderStyle Width="18%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="totalchimbote" HeaderText="SIMA-CHIMBOTE">
									<HeaderStyle Width="18%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="totaliquitos" HeaderText="SIMA-IQUITOS S.R.LTDA.">
									<HeaderStyle Width="18%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="total" HeaderText="TOTAL">
									<HeaderStyle Width="18%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
							<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
						</cc1:datagridweb></TD>
				</TR>
				<TR>
					<TD align="center">
						<asp:label style="Z-INDEX: 0" id="lblAvanceAcumulado" runat="server" CssClass="ResultadoBusqueda"
							Visible="False"></asp:label></TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="780" border="0">
							<TR>
								<TD><cc1:datagridweb id="dgConsulta" runat="server" CssClass="HeaderGrilla" RowPositionEnabled="False"
										AutoGenerateColumns="False" RowHighlightColor="#E0E0E0" Width="780px">
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
										<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<Columns>
											<asp:BoundColumn DataField="lineanegocio" HeaderText="AVANCE ACUMULADO POR LN">
												<HeaderStyle Width="30%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="totalcallao" HeaderText="SIMA-CALLAO">
												<HeaderStyle Width="18%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="totalchimbote" HeaderText="SIMA-CHIMBOTE">
												<HeaderStyle Width="18%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="totaliquitos" HeaderText="SIMA-IQUITOS S.R.LTDA.">
												<HeaderStyle Width="18%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="total" HeaderText="TOTAL">
												<HeaderStyle Width="18%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
										</Columns>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
									</cc1:datagridweb></TD>
							</TR>
							<TR>
								<TD align="center"><asp:label id="lblResultadoMensual" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center">
						<TABLE class="normal" id="Table8" cellSpacing="0" cellPadding="0" width="780" border="0">
							<TR>
								<TD align="center" width="100%" colSpan="3"><cc1:datagridweb id="dgConsultaAnual" runat="server" CssClass="HeaderGrilla" RowPositionEnabled="False"
										AutoGenerateColumns="False" RowHighlightColor="#E0E0E0" Width="780px">
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
										<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<ItemStyle HorizontalAlign="Right" CssClass="ItemGrilla"></ItemStyle>
										<Columns>
											<asp:BoundColumn DataField="titulo" HeaderText="AVANCE ANUAL">
												<HeaderStyle Width="30%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="totalcallao" HeaderText="SIMA-CALLAO">
												<HeaderStyle Width="18%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="totalchimbote" HeaderText="SIMA-CHIMBOTE">
												<HeaderStyle Width="18%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="totaliquitos" HeaderText="SIMA-IQUITOS S.R.LTDA.">
												<HeaderStyle Width="18%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="total" HeaderText="TOTAL">
												<HeaderStyle Width="18%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
										</Columns>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
									</cc1:datagridweb><asp:label id="lblResultadoAnual" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				</TD></TR></TABLE>
			<TABLE style="Z-INDEX: 0" id="Table6" class="normal" border="0" cellSpacing="0" cellPadding="0"
				width="780">
				<TR>
					<TD width="100%" colSpan="3" align="center">
						<cc1:datagridweb id="dgAvanceProyectadoAnual" runat="server" CssClass="HeaderGrilla" Width="780px"
							RowHighlightColor="#E0E0E0" AutoGenerateColumns="False" RowPositionEnabled="False">
							<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
							<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
							<FooterStyle CssClass="FooterGrilla"></FooterStyle>
							<ItemStyle HorizontalAlign="Right" CssClass="ItemGrilla"></ItemStyle>
							<Columns>
								<asp:BoundColumn DataField="titulo" HeaderText="AVANCE PROYECTADO ANUAL">
									<HeaderStyle Width="30%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="totalcallao" HeaderText="SIMA-CALLAO">
									<HeaderStyle Width="18%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="totalchimbote" HeaderText="SIMA-CHIMBOTE">
									<HeaderStyle Width="18%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="totaliquitos" HeaderText="SIMA-IQUITOS S.R.LTDA.">
									<HeaderStyle Width="18%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="total" HeaderText="TOTAL">
									<HeaderStyle Width="18%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
							<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
						</cc1:datagridweb>
						<asp:label id="lblAvanceProyectadoAnual" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label></TD>
				</TR>
				<TR>
					<TD id="Td1" vAlign="top" colSpan="3" align="left"><IMG id="ibtnAtras" style="Z-INDEX: 0; CURSOR: hand" onclick="HistorialIrAtras();" alt=""
							src="../../imagenes/atras.gif"></TD>
				</TR>
			</TABLE>
			</TD></TR></TBODY></TABLE></form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
		</TD></TR>
	</body>
</HTML>
