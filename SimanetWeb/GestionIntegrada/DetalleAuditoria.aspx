<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="DetalleAuditoria.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionIntegrada.DetalleAuditoria" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DetalleAuditoria</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../styles.css">
		<SCRIPT language="javascript" src="../js/@Import.js"></SCRIPT>
		<script type="text/javascript" src="/SimaNetWeb/js/Upload/mint"></script>
		<script type="text/javascript" src="/SimaNetWeb/js/RegEXT.js"></script>
	</HEAD>
	<body onunload="SubirHistorial();" onload="ObtenerHistorial();" bottomMargin="0" leftMargin="0"
		rightMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" border="0" cellSpacing="0" cellPadding="0" width="100%">
				<TR>
					<TD align="left"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD align="left"><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center">
						<TABLE id="Table2" border="0" cellSpacing="0" cellPadding="0" width="300">
							<TR>
								<TD style="HEIGHT: 27px" bgColor="#000080" colSpan="8"><asp:label style="Z-INDEX: 0" id="Label1" runat="server" CssClass="TituloPrincipalBlanco"> REGISTO DE AUDITORIA</asp:label></TD>
							</TR>
							<TR class="AlternateItemDetalle">
								<TD class="headerDetalle"><asp:label id="Label2" runat="server" CssClass="headerDetalle" BorderStyle="None">CODIGO:</asp:label></TD>
								<TD><asp:textbox style="Z-INDEX: 0" id="txtCodigo" runat="server" CssClass="normaldetalle" ReadOnly="True"
										Width="128px"></asp:textbox></TD>
								<TD></TD>
								<TD><IMG style="Z-INDEX: 0; HEIGHT: 5px" alt="" src="/SIMANETWEB/imagenes/spacer.gif" width="120"
										height="5"></TD>
								<TD></TD>
								<TD></TD>
								<TD></TD>
								<TD></TD>
							</TR>
							<TR class="ItemDetalle">
								<TD class="headerDetalle" noWrap><asp:label style="Z-INDEX: 0" id="Label3" runat="server" CssClass="headerDetalle" BorderStyle="None">TIPO AUDITORIA:</asp:label></TD>
								<TD><asp:dropdownlist id="ddlTipoAuditoria" runat="server" CssClass="normaldetalle" Width="100%"></asp:dropdownlist></TD>
								<TD class="headerDetalle"><asp:label id="Label4" runat="server" CssClass="headerDetalle" BorderStyle="None">CENTRO:</asp:label></TD>
								<TD><asp:dropdownlist id="ddlCentroOperativo" runat="server" CssClass="normaldetalle" Width="100%"></asp:dropdownlist></TD>
								<TD class="headerDetalle" noWrap><asp:label id="Label5" runat="server" CssClass="headerDetalle" BorderStyle="None">FECHA DESDE:</asp:label></TD>
								<TD><asp:textbox id="CalFechaDesde" runat="server" CssClass="normaldetalle" Width="75px" rel="calendar"></asp:textbox></TD>
								<TD class="headerDetalle" noWrap><asp:label id="Label6" runat="server" CssClass="headerDetalle" BorderStyle="None">FECHA HASTA:</asp:label></TD>
								<TD><asp:textbox id="CalFechaHasta" runat="server" CssClass="normaldetalle" Width="75px" rel="calendar"></asp:textbox></TD>
							</TR>
							<TR class="AlternateItemDetalle">
								<TD class="headerDetalle"><asp:label style="Z-INDEX: 0" id="Label7" runat="server" CssClass="headerDetalle" BorderStyle="None">DESCRIPCION:</asp:label></TD>
								<TD colSpan="7"><asp:textbox id="txtDescripcion" runat="server" CssClass="normaldetalle" Width="100%" MaxLength="4000"
										Height="158px" TextMode="MultiLine"></asp:textbox></TD>
							</TR>
							<TR class="ItemDetalle">
								<TD></TD>
								<TD></TD>
								<TD></TD>
								<TD></TD>
								<TD></TD>
								<TD></TD>
								<TD colSpan="2">
									<TABLE style="Z-INDEX: 0; WIDTH: 182px; HEIGHT: 30px" id="Table3" border="0" cellSpacing="1"
										cellPadding="1" width="182" align="right">
										<TR>
											<TD width="50%"><asp:imagebutton id="ibtnAceptar" runat="server" ImageUrl="../imagenes/bt_aceptar.gif"></asp:imagebutton></TD>
											<TD width="50%"><IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../imagenes/bt_cancelar.gif"></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD></TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>	
			
			var textBoxes = Ext.DomQuery.select("input[rel=calendar]");   
			Ext.each(textBoxes, function(item, id, all){   
				var cl = new Ext.form.DateField({   
					format: 'd/m/Y',
					allowBlank : false,   
					applyTo: item   
				});
			});   

		</SCRIPT>
	</body>
</HTML>
