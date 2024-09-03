<%@ Page language="c#" Codebehind="ConsultarMovimientodeMateriales.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.PresupuestoVarios.ConsultarMovimientodeMateriales" %>
<%@ Register TagPrefix="cc2" Namespace="ControlesWeb" Assembly="ControlesWeb" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta name="vs_showGrid" content="False">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<style type="text/css">DIV.scroll { BORDER-RIGHT: #666 1px solid; BORDER-TOP: #666 1px solid; OVERFLOW: auto; BORDER-LEFT: #666 1px solid; WIDTH: 300px; BORDER-BOTTOM: #666 1px solid; HEIGHT: 100px }
		</style>
		<!--; BACKGROUND-COLOR: #ccc  scroll="no" -->
	</HEAD>
	<body scroll="no" bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="765" align="center" border="0">
				<TR>
					<TD>
						<table cellSpacing="0" cellPadding="0" width="100%" align="left" border="1">
							<tr class="HeaderGrilla">
								<td vAlign="middle" align="left"><asp:label id="Label1" runat="server">Naturaleza de Gasto :</asp:label></td>
								<td style="WIDTH: 466px" vAlign="middle" align="left"><asp:textbox id="txtNaturalezaDescripcion" runat="server" ReadOnly="True" Width="455px" CssClass="normaldetalle"></asp:textbox></td>
								<td vAlign="middle" align="left"><asp:label id="Label2" runat="server">Monto Real :</asp:label></td>
								<td vAlign="middle" align="left"><asp:textbox id="txtMontoReal" runat="server" ReadOnly="True" Width="92px" CssClass="normaldetalle"></asp:textbox></td>
							</tr>
							<TR>
								<TD vAlign="middle" align="left" colSpan="4">
									<div class="scroll" style="WIDTH: 100%; HEIGHT: 275px" align="left"><cc1:datagridweb id="grid" runat="server" Width="740px" ShowHeader="False" RowHighlightColor="#E0E0E0"
											AutoGenerateColumns="False" AllowSorting="True" PageSize="7">
											<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
											<ItemStyle CssClass="ItemGrilla"></ItemStyle>
											<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
											<FooterStyle CssClass="FooterGrilla"></FooterStyle>
											<Columns>
												<asp:BoundColumn DataField="Nombre" HeaderText="NOMBRE">
													<HeaderStyle Width="40%" VerticalAlign="Middle"></HeaderStyle>
													<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
												</asp:BoundColumn>
											</Columns>
											<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
										</cc1:datagridweb></div>
								</TD>
							</TR>
						</table>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%"><IMG style="WIDTH: 160px; HEIGHT: 8px" height="8" src="../../imagenes/spacer.gif" width="160"></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px" vAlign="top" align="center" width="100%"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px" vAlign="top" align="center" width="100%">
					</TD>
				</TR>
			</table>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
		<DIV id="tblMaster" style="VISIBILITY: hidden" runat="server">
			<table style="BORDER-RIGHT: #0000ff 1px solid; BORDER-TOP: #0000ff 1px solid; BORDER-LEFT: #0000ff 1px solid; WIDTH: 743px; BORDER-BOTTOM: #0000ff 1px solid; HEIGHT: 64px">
				<tr>
					<td style="BORDER-RIGHT: #999999 1px outset; BORDER-TOP: #999999 1px outset; DISPLAY: none; BORDER-LEFT: #999999 1px outset; BORDER-BOTTOM: #999999 1px outset">
						<IMG alt="" src="file:///C:\Inetpub\wwwroot\SimaNetWeb\Materiales\M1615100325.jpeg" width="85"
							align="absMiddle">
					</td>
					<td width="100%">
						<TABLE id="Table3" cellSpacing="1" cellPadding="1" width="100%" border="1" style="BORDER-RIGHT: #999999 1px solid; BORDER-TOP: #999999 1px solid; BORDER-LEFT: #999999 1px solid; BORDER-BOTTOM: #999999 1px solid; HEIGHT: 124px"
							align="left">
							<TR>
								<TD class="headerDetalle">Código:</TD>
								<TD class="AlternateItemDetalle"><INPUT class="normaldetalle" style="WIDTH: 70px; BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; HEIGHT: 15px; BACKGROUND-COLOR: transparent; BORDER-BOTTOM-STYLE: none"
										type="text" size="9" value="XCODIGO" readOnly></TD>
								<TD class="HeaderDetalle" style="WIDTH: 58px; HEIGHT: 27px">Descripción</TD>
								<TD class="ItemDetalle"><INPUT class="normaldetalle" style="WIDTH: 250px; BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; HEIGHT: 15px; BACKGROUND-COLOR: transparent; BORDER-BOTTOM-STYLE: none"
										type="text" size="44" value="XDESCRIPCION"></TD>
								<TD class="HeaderDetalle" style="WIDTH: 253px; HEIGHT: 27px">Monto Total</TD>
								<TD class="AlternateItemDetalle"><INPUT class="normaldetalle" style="WIDTH: 72px; BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; HEIGHT: 15px; BACKGROUND-COLOR: transparent; TEXT-ALIGN: right; BORDER-BOTTOM-STYLE: none"
										type="text" size="10" value="XTOTAL" readOnly></TD>
								<TD class="HeaderDetalle" style="WIDTH: 28px; HEIGHT: 27px">Items</TD>
								<TD class="ItemDetalle"><INPUT class="normaldetalle" style="WIDTH: 37px; BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; HEIGHT: 15px; BACKGROUND-COLOR: transparent; TEXT-ALIGN: right; BORDER-BOTTOM-STYLE: none"
										type="text" size="9" value="XMAXITEM" readOnly></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 9px" colSpan="8">
									<TABLE id="Table4" style="WIDTH: 100%; HEIGHT: 26px" cellSpacing="1" cellPadding="1" width="664"
										align="left" border="1">
										<TR>
											<TD class="HeaderListview" style="COLOR: #ffffff" width="25">Nro</TD>
											<TD class="HeaderListview" style="COLOR: #ffffff" width="77">Fecha</TD>
											<TD class="HeaderListview" style="WIDTH: 334px; COLOR: #ffffff" width="334">Documento 
												de Salida</TD>
											<TD class="HeaderListview" style="COLOR: #ffffff" width="120">Cantidad</TD>
											<TD class="HeaderListview" style="COLOR: #ffffff" width="71">Monto</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD colSpan="8" height="60">
									<DIV class="scroll" style="WIDTH: 100%; BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; HEIGHT: 100%; BACKGROUND-COLOR: transparent; BORDER-BOTTOM-STYLE: none"
										align="left">[XITEM]</DIV>
								</TD>
							</TR>
						</TABLE>
					</td>
				</tr>
			</table>
		</DIV>
		<DIV id="ItemMaterial" style="VISIBILITY: hidden" runat="server">
			<TABLE id="Table4" style="HEIGHT: 23px" cellSpacing="0" cellPadding="0" width="100%" border="1">
				<TR onclick="CambiarColorSeleccion(this);" onmouseout="CambiarColorPasarMouse(this, false);"
					onmouseover="CambiarColorPasarMouse(this, true);">
					<TD><INPUT class="normaldetalle" style="WIDTH: 30px; BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; HEIGHT: 22px; BACKGROUND-COLOR: transparent; TEXT-ALIGN: center; BORDER-BOTTOM-STYLE: none"
							type="text" size="9" value="XNRO" readOnly></TD>
					<TD style="WIDTH: 82px"><INPUT class="normaldetalle" style="WIDTH: 88px; BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; HEIGHT: 22px; BACKGROUND-COLOR: transparent; TEXT-ALIGN: center; BORDER-BOTTOM-STYLE: none"
							type="text" size="9" value="XFECHA" readOnly></TD>
					<TD style="WIDTH: 350px"><INPUT class="normaldetalle" style="WIDTH: 355px; BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; HEIGHT: 22px; BACKGROUND-COLOR: transparent; BORDER-BOTTOM-STYLE: none"
							type="text" size="53" value="XSALIDA" readOnly maxLength="0"></TD>
					<TD><INPUT class="normaldetalle" style="WIDTH: 123px; BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; HEIGHT: 22px; BACKGROUND-COLOR: transparent; BORDER-BOTTOM-STYLE: none"
							type="text" size="9" value="XCANTIDAD" readOnly></TD>
					<TD><INPUT class="normaldetalle" style="WIDTH: 61px; BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; HEIGHT: 22px; BACKGROUND-COLOR: transparent; TEXT-ALIGN: right; BORDER-BOTTOM-STYLE: none"
							type="text" size="9" value="XMONTO" readOnly></TD>
				</TR>
			</TABLE>
		</DIV>
	</body>
</HTML>
