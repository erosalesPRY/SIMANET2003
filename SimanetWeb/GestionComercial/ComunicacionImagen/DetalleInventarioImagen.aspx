<%@ Page language="c#" Codebehind="DetalleInventarioImagen.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.ComunicacionImagen.DetalleInventarioImagen" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="cc2" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
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
			<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD vAlign="top" colSpan="3"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD vAlign="top" colSpan="3"><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD borderColor="#ffffff" align="center" colSpan="3">
						<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<TR>
								<TD class="Commands" vAlign="top" width="100%" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Comercial > Comunicación e Imagen > </asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> DETALLE ARTICULOS</asp:label></TD>
							</TR>
						</TABLE>
						<asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal"></asp:label>
						<TABLE id="Table11" borderColor="#ffffff" cellSpacing="0" cellPadding="0" width="650" border="1">
							<TR>
								<TD bgColor="#000080"><asp:label id="lblTitulodos" runat="server" CssClass="TituloPrincipalBlanco">DATOS DEL ARTICULO</asp:label></TD>
							</TR>
						</TABLE>
						<TABLE id="Table2" borderColor="#ffffff" cellSpacing="0" cellPadding="0" width="650" border="1">
							<TR>
								<TD style="WIDTH: 35px; HEIGHT: 14px" bgColor="#335eb4"><asp:label id="lblGrupo" runat="server" CssClass="TextoBlanco" Width="100px">Grupo:</asp:label></TD>
								<TD class="normaldetalle" id="CelldllGrupo" style="WIDTH: 65px" bgColor="#dddddd" runat="server"><asp:dropdownlist id="dllGrupo" runat="server" CssClass="normaldetalle" Width="288px" AutoPostBack="True"></asp:dropdownlist></TD>
								<TD style="WIDTH: 1px" align="center" width="1" bgColor="#dddddd"></TD>
								<TD align="center" bgColor="#ffffff" rowSpan="8"><asp:image id="imgProyecto" runat="server" Height="268px" BorderColor="Transparent"></asp:image><BR>
									<INPUT class="normaldetalle" id="filMyFile" type="file" size="24" name="File2" runat="server"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 35px; HEIGHT: 1px" bgColor="#335eb4"><asp:label id="lblSubGrupo" runat="server" CssClass="TextoBlanco" Width="100px">Sub - Grupo:</asp:label></TD>
								<TD class="normaldetalle" id="CelldllSubGrupo" style="WIDTH: 65px; HEIGHT: 1px" bgColor="#f0f0f0"
									runat="server"><asp:dropdownlist id="dllSubGrupo" runat="server" CssClass="normaldetalle" Width="288px"></asp:dropdownlist></TD>
								<TD style="WIDTH: 1px; HEIGHT: 1px" width="1" bgColor="#f0f0f0"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 35px" bgColor="#335eb4"><asp:label id="lblNombre" runat="server" CssClass="TextoBlanco" Width="100px"> TEMA:</asp:label></TD>
								<TD style="WIDTH: 65px" bgColor="#dddddd"><asp:textbox id="txtNombre" runat="server" CssClass="normaldetalle" Width="288px" MaxLength="200"></asp:textbox></TD>
								<TD style="WIDTH: 1px" width="1" bgColor="#dddddd"><cc2:requireddomvalidator id="rfvNombre" runat="server" Width="5px" ControlToValidate="txtNombre">*</cc2:requireddomvalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 35px; HEIGHT: 9px" bgColor="#335eb4"><asp:label id="lblDescripcion" runat="server" CssClass="TextoBlanco" Width="100px">CONTENIDO:</asp:label></TD>
								<TD class="normaldetalle" style="WIDTH: 65px" bgColor="#f0f0f0" runat="server"><asp:textbox id="txtDescripcion" runat="server" CssClass="normaldetalle" Width="288px" Height="42px"
										MaxLength="2000" TextMode="MultiLine"></asp:textbox></TD>
								<TD style="WIDTH: 1px" width="1" bgColor="#f0f0f0"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 35px; HEIGHT: 19px" bgColor="#335eb4"><asp:label id="lblObservaciones" runat="server" CssClass="TextoBlanco" Width="100px">DESCRIPCION:</asp:label></TD>
								<TD class="normaldetalle" style="WIDTH: 65px" bgColor="#dddddd" runat="server"><asp:textbox id="txtObservacion" runat="server" CssClass="normaldetalle" Width="288px" Height="42px"
										MaxLength="2000" TextMode="MultiLine"></asp:textbox></TD>
								<TD style="WIDTH: 1px" width="1" bgColor="#dddddd"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 35px; HEIGHT: 29px" bgColor="#335eb4"><asp:label id="lblIdioma" runat="server" CssClass="TextoBlanco" Width="100px">IDIOMA:</asp:label></TD>
								<TD class="normaldetalle" id="CellddlIdioma" style="WIDTH: 65px" bgColor="#f0f0f0" runat="server"><asp:dropdownlist id="ddlIdioma" runat="server" CssClass="normaldetalle" Width="288px"></asp:dropdownlist></TD>
								<TD style="WIDTH: 1px; HEIGHT: 29px" width="1" bgColor="#f0f0f0"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 35px" bgColor="#335eb4"><asp:label id="lblMinimo" runat="server" CssClass="TextoBlanco" Width="100px">Stock MInimo:</asp:label></TD>
								<TD style="WIDTH: 65px" bgColor="#dddddd"><ew:numericbox id="txtMinimo" runat="server" CssClass="normaldetalle" Width="288px" MaxLength="5"
										PositiveNumber="True"></ew:numericbox></TD>
								<TD style="WIDTH: 1px" width="1" bgColor="#dddddd"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 35px" bgColor="#335eb4"><asp:label id="lblMovimientos" runat="server" CssClass="TextoBlanco" Width="100px">MOVIMIENTOS:</asp:label></TD>
								<TD style="WIDTH: 65px" bgColor="#f0f0f0"><asp:checkbox id="chkTieneMovimientos" runat="server" CssClass="normaldetalle" AutoPostBack="True"
										ForeColor="#335EB4" Text="SI"></asp:checkbox></TD>
								<TD style="WIDTH: 1px" width="1" bgColor="#f0f0f0"></TD>
							</TR>
						</TABLE>
						<TABLE id="tblTituloMovimientos" borderColor="#ffffff" cellSpacing="0" cellPadding="0"
							width="650" border="1" runat="server">
							<TR>
								<TD bgColor="#000080"><asp:label id="lblMovimiento" runat="server" CssClass="TituloPrincipalBlanco">MOVIMIENTOS:</asp:label>&nbsp;
									<asp:checkbox id="chkIngreso" runat="server" CssClass="normaldetalle" AutoPostBack="True" ForeColor="White"
										Text="Ingreso"></asp:checkbox><asp:checkbox id="chkEgreso" runat="server" CssClass="normaldetalle" AutoPostBack="True" ForeColor="White"
										Text="Egreso"></asp:checkbox></TD>
							</TR>
						</TABLE>
						<TABLE id="tblMovimientos" borderColor="#ffffff" cellSpacing="0" cellPadding="0" width="650"
							border="1" runat="server">
							<TR>
								<TD width="95" bgColor="#335eb4"><asp:label id="lblAsunto" runat="server" CssClass="TextoBlanco" Width="100px">MOTIVO:</asp:label></TD>
								<TD width="232" bgColor="#dddddd"><asp:dropdownlist id="ddlMotivo" runat="server" CssClass="normaldetalle" Width="230px"></asp:dropdownlist></TD>
								<TD width="8" bgColor="#dddddd"></TD>
								<TD width="72" bgColor="#335eb4"><asp:label id="lblFechaMovimiento" runat="server" CssClass="TextoBlanco" Width="29px">FECHA:</asp:label></TD>
								<TD bgColor="#dddddd"><ew:calendarpopup id="calFechaMovimiento" runat="server" CssClass="combos" Width="190px" ImageUrl="../../imagenes/BtPU_Mas.gif"
										ShowGoToToday="True" ControlDisplay="TextBoxImage" Culture="Spanish (Chile)" PadSingleDigits="True" AllowArbitraryText="False"
										ClearDateText="Limpiar Fecha" GoToTodayText="Fecha de Hoy" Nullable="True" NullableLabelText=" ">
										<TextboxLabelStyle CssClass="normaldetalle"></TextboxLabelStyle>
										<WeekdayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
											BackColor="White"></WeekdayStyle>
										<MonthHeaderStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
											BackColor="#FF8A00"></MonthHeaderStyle>
										<OffMonthStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Gray"
											BackColor="AntiqueWhite"></OffMonthStyle>
										<GoToTodayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
											BackColor="White"></GoToTodayStyle>
										<TodayDayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
											BackColor="LightGoldenrodYellow"></TodayDayStyle>
										<DayHeaderStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
											BackColor="Gray"></DayHeaderStyle>
										<WeekendStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
											BackColor="LightGray"></WeekendStyle>
										<SelectedDateStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
											BackColor="#FF8A00"></SelectedDateStyle>
										<ClearDateStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
											BackColor="White"></ClearDateStyle>
										<HolidayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
											BackColor="White"></HolidayStyle>
									</ew:calendarpopup></TD>
								<TD width="8" bgColor="#dddddd"></TD>
							</TR>
							<TR>
								<TD width="95" bgColor="#335eb4"><asp:label id="lblObservacionesMovimiento" runat="server" CssClass="TextoBlanco" Width="100px">OBSERVACIONES</asp:label></TD>
								<TD width="232" bgColor="#f0f0f0"><asp:textbox id="txtObservacionesMovimiento" runat="server" CssClass="normaldetalle" Width="230px"
										Height="51px" MaxLength="2000" TextMode="MultiLine"></asp:textbox></TD>
								<TD width="8" bgColor="#f0f0f0"></TD>
								<TD width="72" bgColor="#335eb4"><asp:label id="lblDescripcionObservaciones" runat="server" CssClass="TextoBlanco">DESCRIPCION</asp:label></TD>
								<TD style="HEIGHT: 19px" bgColor="#f0f0f0"><asp:textbox id="txtDescripcionMovimiento" runat="server" CssClass="normaldetalle" Width="210px"
										Height="51px" MaxLength="2000" TextMode="MultiLine"></asp:textbox></TD>
								<TD width="8" bgColor="#f0f0f0"><cc2:requireddomvalidator id="rfvFechaMovimiento" runat="server" ControlToValidate="calFechaMovimiento" Enabled="False">*</cc2:requireddomvalidator></TD>
							</TR>
						</TABLE>
						<TABLE id="tblTituloIngreso" borderColor="#ffffff" cellSpacing="0" cellPadding="0" width="650"
							border="1" runat="server">
							<TR>
								<TD bgColor="#000080"><asp:label id="lblIngresos" runat="server" CssClass="TituloPrincipalBlanco">INGRESOS</asp:label></TD>
							</TR>
						</TABLE>
						<TABLE id="tblIngresos" borderColor="#ffffff" cellSpacing="0" cellPadding="0" width="650"
							border="1" runat="server">
							<TR>
								<TD width="95" bgColor="#335eb4"><asp:label id="lblAlta" runat="server" CssClass="TextoBlanco" Width="100px">CANTIDAD:</asp:label></TD>
								<TD width="232" bgColor="#dddddd"><ew:numericbox id="txtAlta" runat="server" CssClass="normaldetalle" Width="230px" MaxLength="5"
										PositiveNumber="True"></ew:numericbox></TD>
								<TD style="WIDTH: 1px; HEIGHT: 23px" width="1" bgColor="#dddddd"><cc2:requireddomvalidator id="rfvAlta" runat="server" ControlToValidate="txtAlta" Enabled="False">*</cc2:requireddomvalidator></TD>
								<TD width="72" bgColor="#335eb4"><asp:label id="lblProveedor" runat="server" CssClass="TextoBlanco">PROVEEDOR:</asp:label></TD>
								<TD bgColor="#dddddd"><asp:textbox id="txtEntidad" runat="server" CssClass="normaldetalle" Width="190px" MaxLength="200"></asp:textbox><asp:imagebutton id="ibtnBuscarProveedor" runat="server" CssClass="normaldetalle" ImageUrl="../../imagenes/BtPU_Mas.gif"
										CausesValidation="False"></asp:imagebutton></TD>
								<TD style="HEIGHT: 23px" bgColor="#dddddd"></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 16px" width="95" bgColor="#335eb4"><asp:label id="lblPrecioUnitario" runat="server" CssClass="TextoBlanco" Width="100px">Precio UniTARIO:</asp:label></TD>
								<TD style="HEIGHT: 16px" width="232" bgColor="#f0f0f0"><ew:numericbox id="txtPrecioUnitario" runat="server" CssClass="normaldetalle" Width="230px" AutoPostBack="True"
										MaxLength="5" PositiveNumber="True" DecimalPlaces="2"></ew:numericbox></TD>
								<TD style="WIDTH: 1px; HEIGHT: 16px" width="1" bgColor="#f0f0f0"><cc2:requireddomvalidator id="rfvPrecioUnitario" runat="server" ControlToValidate="txtPrecioUnitario" Enabled="False">*</cc2:requireddomvalidator></TD>
								<TD style="HEIGHT: 16px" width="2" bgColor="#335eb4"><asp:label id="lblMoneda" runat="server" CssClass="TextoBlanco">MONEDA:</asp:label></TD>
								<TD style="WIDTH: 181px; HEIGHT: 16px" bgColor="#f0f0f0"><asp:dropdownlist id="ddlMoneda" runat="server" CssClass="normaldetalle" Width="210px"></asp:dropdownlist></TD>
								<TD style="HEIGHT: 16px" bgColor="#f0f0f0"></TD>
							</TR>
							<TR>
								<TD width="95" bgColor="#335eb4"><asp:label id="lblTotal" runat="server" CssClass="TextoBlanco" Width="100px">INVERSION TOTAL:</asp:label></TD>
								<TD width="232" bgColor="#dddddd"><ew:numericbox id="txtTotal" runat="server" CssClass="normaldetalle" Width="230px" MaxLength="5"
										PositiveNumber="True" DecimalPlaces="2" ReadOnly="True"></ew:numericbox></TD>
								<TD style="WIDTH: 1px" width="1" bgColor="#dddddd"></TD>
								<TD width="2"></TD>
								<TD style="WIDTH: 181px"></TD>
								<TD></TD>
							</TR>
						</TABLE>
						<TABLE id="tblTituloEgresos" borderColor="#ffffff" cellSpacing="0" cellPadding="0" width="650"
							border="1" runat="server">
							<TR>
								<TD bgColor="#000080"><asp:label id="lblEgresos" runat="server" CssClass="TituloPrincipalBlanco">EGRESOS</asp:label></TD>
							</TR>
						</TABLE>
						<TABLE id="tblEgresos" borderColor="#ffffff" cellSpacing="0" cellPadding="0" width="650"
							border="1" runat="server">
							<TR>
								<TD style="HEIGHT: 17px" width="95" bgColor="#335eb4"><asp:label id="lblBaja" runat="server" CssClass="TextoBlanco" Width="100px">CANTIDAD:</asp:label></TD>
								<TD style="HEIGHT: 17px" width="232" bgColor="#dddddd"><ew:numericbox id="txtBaja" runat="server" CssClass="normaldetalle" Width="230px" MaxLength="5"
										PositiveNumber="True"></ew:numericbox></TD>
								<TD style="HEIGHT: 17px" width="8" bgColor="#dddddd"><cc2:requireddomvalidator id="rfvBaja" runat="server" ControlToValidate="txtBaja" Enabled="False" EnableClientScript="False">*</cc2:requireddomvalidator></TD>
								<TD style="WIDTH: 72px; HEIGHT: 17px" width="72" bgColor="#335eb4"><asp:label id="lblGrupoCC" runat="server" CssClass="TextoBlanco" Width="64px">GRUPO C.C.:</asp:label></TD>
								<TD class="normaldetalle" id="CelldllGrupoCC" style="WIDTH: 211px; HEIGHT: 17px" bgColor="#dddddd"
									runat="server"><asp:dropdownlist id="dllGrupoCC" runat="server" CssClass="normaldetalle" Width="100%" AutoPostBack="True"></asp:dropdownlist></TD>
								<TD class="normaldetalle" style="HEIGHT: 17px" width="10" bgColor="#dddddd"></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 24px" width="95" bgColor="#335eb4"><asp:label id="Label3" runat="server" CssClass="TextoBlanco" Width="100px">Precio UniTARIO:</asp:label></TD>
								<TD class="normaldetalle" style="HEIGHT: 24px" width="232" bgColor="#f0f0f0"><ew:numericbox id="txtPrecioUnitarioEgresos" runat="server" CssClass="normaldetalle" Width="230px"
										AutoPostBack="True" MaxLength="5" PositiveNumber="True" DecimalPlaces="2"></ew:numericbox></TD>
								<TD style="HEIGHT: 24px" width="8" bgColor="#f0f0f0"></TD>
								<TD style="WIDTH: 72px; HEIGHT: 24px" width="72" bgColor="#335eb4"><asp:label id="lblCentroOperativo" runat="server" CssClass="TextoBlanco">C.O.:</asp:label></TD>
								<TD class="normaldetalle" id="CelldllCentroOperativo" style="WIDTH: 211px; HEIGHT: 24px"
									bgColor="#f0f0f0" runat="server"><asp:dropdownlist id="dllCentroOperativo" runat="server" CssClass="normaldetalle" Width="100%" AutoPostBack="True"></asp:dropdownlist></TD>
								<TD class="normaldetalle" style="HEIGHT: 24px" width="10" bgColor="#f0f0f0"></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 18px" width="95" bgColor="#335eb4"><asp:label id="Label4" runat="server" CssClass="TextoBlanco">MONEDA:</asp:label></TD>
								<TD class="normaldetalle" style="HEIGHT: 18px" width="232" bgColor="#f0f0f0"><asp:dropdownlist id="ddlMonedaEgresos" runat="server" CssClass="normaldetalle" Width="100%"></asp:dropdownlist></TD>
								<TD style="HEIGHT: 18px" width="8" bgColor="#f0f0f0"></TD>
								<TD style="WIDTH: 72px; HEIGHT: 18px" width="72" bgColor="#335eb4"><asp:label id="lblCC" runat="server" CssClass="TextoBlanco">C.C.:</asp:label></TD>
								<TD class="normaldetalle" id="CelldllCC" style="WIDTH: 211px; HEIGHT: 18px" bgColor="#f0f0f0"
									runat="server"><asp:dropdownlist id="dllCC" runat="server" CssClass="normaldetalle" Width="100%"></asp:dropdownlist></TD>
								<TD class="normaldetalle" style="HEIGHT: 18px" width="10" bgColor="#f0f0f0"></TD>
							</TR>
							<TR>
								<TD width="95" bgColor="#335eb4"><asp:label id="Label5" runat="server" CssClass="TextoBlanco" Width="100px">INVERSION TOTAL:</asp:label></TD>
								<TD class="normaldetalle" width="232" bgColor="#f0f0f0"><ew:numericbox id="txtInversionTotal" runat="server" CssClass="normaldetalle" Width="230px" MaxLength="5"
										PositiveNumber="True" DecimalPlaces="2" ReadOnly="True"></ew:numericbox></TD>
								<TD width="8" bgColor="#f0f0f0"></TD>
							</TR>
						</TABLE>
						<TABLE id="Table1" borderColor="#ffffff" cellSpacing="0" cellPadding="0" width="610" border="1">
							<TR>
								<TD align="right"><BR>
									<asp:imagebutton id="ibtnAgregar" runat="server" ImageUrl="../../imagenes/bt_agregar.gif"></asp:imagebutton><asp:imagebutton id="ibtnEliminar" runat="server" ImageUrl="../../imagenes/bt_eliminar.gif" CausesValidation="False"></asp:imagebutton></TD>
							</TR>
							<TR>
								<TD align="center"><cc1:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" Width="780px" RowHighlightColor="#E0E0E0"
										AutoGenerateColumns="False" BorderStyle="None" Visible="False">
										<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn Visible="False" HeaderText="Nro"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="IDMOVIMIENTOINVENTARIOIMAGEN">
												<HeaderStyle Width="5%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="IDINVENTARIOIMAGEN">
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="FECHAMOVIMIENTO" SortExpression="FECHAMOVIMIENTO" HeaderText="Fec. Movimiento"
												DataFormatString="{0:dd-MM-yyyy}"></asp:BoundColumn>
											<asp:BoundColumn DataField="DescripcionTipo" HeaderText="Tipo"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="IdTipoMovimiento" HeaderText="IdTipoMovimiento"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="IdProveedor" HeaderText="IdProveedor"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="IdResponsable" HeaderText="IdResponsable"></asp:BoundColumn>
											<asp:BoundColumn DataField="Cantidad" HeaderText="Cantidad"></asp:BoundColumn>
											<asp:BoundColumn DataField="NombreProveedor" SortExpression="NombreProveedor" HeaderText="Proveedor/Destinatario"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="NombreCentroCosto" SortExpression="NombreCentroCosto"
												HeaderText="Destino"></asp:BoundColumn>
											<asp:BoundColumn DataField="PrecioUnitario" SortExpression="PrecioUnitario" HeaderText="Precio Unitario"
												DataFormatString="{0:###,##0.00}"></asp:BoundColumn>
											<asp:BoundColumn DataField="moneda" SortExpression="moneda" HeaderText="moneda"></asp:BoundColumn>
											<asp:BoundColumn DataField="motivo" SortExpression="motivo" HeaderText="motivo"></asp:BoundColumn>
											<asp:BoundColumn DataField="total" SortExpression="total" HeaderText="total" DataFormatString="{0:###,##0.00}"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="idmotivo" SortExpression="idmotivo" HeaderText="idmotivo"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="idmoneda" SortExpression="idmoneda" HeaderText="idmoneda"></asp:BoundColumn>
										</Columns>
										<PagerStyle HorizontalAlign="Center" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 17px" align="center"><asp:label id="lblCalculado" runat="server" CssClass="ResultadoBusqueda">CANTIDAD ACTUAL:</asp:label><BR>
									<TABLE id="tblTextos" borderColor="#ffffff" cellSpacing="0" cellPadding="0" width="300"
										border="1" runat="server">
										<TR>
											<TD><asp:label id="lblDescripcionClick" runat="server" CssClass="normalDetalle">Descripción:</asp:label></TD>
										</TR>
										<TR>
											<TD><asp:textbox id="txtDescripcionClick" runat="server" CssClass="normaldetalle" Width="610px" Height="51px"
													MaxLength="200" TextMode="MultiLine"></asp:textbox></TD>
										</TR>
										<TR>
											<TD><asp:label id="lblObservacionesClick" runat="server" CssClass="normalDetalle">OBSERVACIONEs:</asp:label></TD>
										</TR>
										<TR>
											<TD><asp:textbox id="txtObservacionesClick" runat="server" CssClass="normaldetalle" Width="610px"
													Height="51px" MaxLength="200" TextMode="MultiLine"></asp:textbox></TD>
										</TR>
									</TABLE>
									<asp:imagebutton id="ibtnAceptar" runat="server" Width="87px" ImageUrl="../../imagenes/bt_aceptar.gif"></asp:imagebutton>&nbsp;<asp:imagebutton id="ibtnCancelar" runat="server" Width="87px" ImageUrl="../../imagenes/bt_cancelar.gif"
										CausesValidation="False"></asp:imagebutton>
								</TD>
							</TR>
							<TR>
								<TD align="center"><INPUT id="hIdTablaEntidad" style="WIDTH: 16px; HEIGHT: 16px" type="hidden" size="1" name="hIdTablaEntidad"
										runat="server"><INPUT id="hIdEntidad" style="WIDTH: 16px; HEIGHT: 16px" type="hidden" size="1" name="hIdEntidad"
										runat="server"><INPUT id="hIdCodigo" style="WIDTH: 16px; HEIGHT: 16px" type="hidden" size="1" name="hIdCodigo"
										runat="server"><INPUT id="hNumero" style="WIDTH: 16px; HEIGHT: 16px" type="hidden" size="1" name="hNumero"
										runat="server"><INPUT id="hCodigo" style="WIDTH: 16px; HEIGHT: 16px" type="hidden" size="1" name="hIdCodigo"
										runat="server"><INPUT id="hIdMovimiento" style="WIDTH: 16px; HEIGHT: 16px" type="hidden" size="1" name="hIdMovimiento"
										runat="server"><INPUT id="hImagen" style="WIDTH: 16px; HEIGHT: 16px" type="hidden" size="1" name="hImagen"
										runat="server"><BR>
									<TABLE id="Table8" width="100%" border="0">
										<TR>
											<TD id="TdCeldaCancelar" runat="server"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
										</TR>
									</TABLE>
									<asp:imagebutton id="ibtnModificar" runat="server" ImageUrl="../../imagenes/bt_modificar.gif" CausesValidation="False"
										Visible="False"></asp:imagebutton><BR>
									<asp:ValidationSummary id="vSum" runat="server"></asp:ValidationSummary></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
			<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			</SCRIPT>
		</form>
	</body>
</HTML>
