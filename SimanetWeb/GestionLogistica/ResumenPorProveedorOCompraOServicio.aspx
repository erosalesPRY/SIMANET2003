<%@ Page language="c#" Codebehind="ResumenPorProveedorOCompraOServicio.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionLogistica.ResumenPorProveedorOCompraOServicio" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ResumenPorProveedorOCompraOServicio</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../styles.css">
		<SCRIPT language="javascript" src="../js/@Import.js"></SCRIPT>
		<script>
			function ObtenerSeleccionados(){
				HistorialIrAdelantePersonalizado("");
				var oDataGrid = jNet.get('grid');
				var strLstProv="";
				for(var i=1;i<=oDataGrid.rows.length-1;i++){
					var chkCtrl = oDataGrid.rows[i].cells[4].children[0];
					if(chkCtrl.checked){
						strLstProv += oDataGrid.rows[i].cells[0].innerText + ';';
					}
				}
				if(strLstProv.length>0){
					jNet.get('hNroRUC').value = strLstProv.substring(0,strLstProv.length-1);
				}
			}
		</script>
	</HEAD>
	<body onunload="SubirHistorial();" onload="ObtenerHistorial();" bottomMargin="0" leftMargin="0"
		rightMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" border="0" cellSpacing="0" cellPadding="0" width="100%" height="100%">
				<TR>
					<TD><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD height="100%" vAlign="top">
						<TABLE id="Table2" border="0" cellSpacing="1" cellPadding="1" width="799" align="center">
							<TR>
								<TD vAlign="middle" align="center">
									<TABLE id="Table3" border="0" cellSpacing="1" cellPadding="1" width="90%" align="left">
										<TR>
											<TD style="WIDTH: 72px" align="center" class="headerDetalle"><asp:label id="Label1" runat="server" Font-Bold="True" CssClass="normaldetalle" ForeColor="White">DOCUMENTO:</asp:label></TD>
											<TD colSpan="7" align="left" style="WIDTH: 466px"><asp:label id="LblDocumento" runat="server" Font-Bold="True" CssClass="normaldetalle">Label</asp:label></TD>
											<TD style="WIDTH: 72px" align="left"></TD>
											<TD align="left"></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 72px" class="headerDetalle"><asp:label id="Label2" runat="server" Font-Bold="True" CssClass="normaldetalle" ForeColor="White">Moneda:</asp:label></TD>
											<TD style="WIDTH: 101px"><asp:label id="LblMoneda" runat="server" CssClass="normaldetalle">Label</asp:label></TD>
											<TD style="WIDTH: 57px" class="headerDetalle"><asp:label id="Label3" runat="server" Font-Bold="True" CssClass="normaldetalle" ForeColor="White">Estado:</asp:label></TD>
											<TD style="WIDTH: 73px"><asp:label id="LblEstado" runat="server" CssClass="normaldetalle">Label</asp:label></TD>
											<TD style="WIDTH: 28px" class="headerDetalle"><asp:label id="Lbl" runat="server" Font-Bold="True" CssClass="normaldetalle" ForeColor="White">Año:</asp:label></TD>
											<TD style="WIDTH: 61px"><asp:label id="LblAño" runat="server" CssClass="normaldetalle">Label</asp:label></TD>
											<TD style="WIDTH: 33px" class="headerDetalle"><asp:label id="Label5" runat="server" Font-Bold="True" CssClass="normaldetalle" ForeColor="White">Mes:</asp:label></TD>
											<TD style="WIDTH: 74px"><asp:label id="LblMes" runat="server" CssClass="normaldetalle">Label</asp:label></TD>
											<TD style="WIDTH: 72px" class="headerDetalle">
												<asp:label style="Z-INDEX: 0" id="Label6" runat="server" ForeColor="White" CssClass="normaldetalle"
													Font-Bold="True">IMPORTE:</asp:label></TD>
											<TD>
												<asp:label style="Z-INDEX: 0" id="LblImporte" runat="server" CssClass="normaldetalle">Label</asp:label></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD align="right"><INPUT style="WIDTH: 45px; HEIGHT: 22px" id="hNroRUC" size="2" type="hidden" runat="server">
									<asp:label style="Z-INDEX: 0" id="Label4" runat="server" ForeColor="White" CssClass="normaldetalle"
										Font-Bold="True">RESUMEN POR PROVEEDOR</asp:label>
									<asp:ImageButton style="Z-INDEX: 0" id="ImgImprimir" runat="server" ImageUrl="../imagenes/bt_imprimir.gif"></asp:ImageButton></TD>
							</TR>
							<TR>
								<TD><cc1:datagridweb style="Z-INDEX: 0" id="grid" runat="server" AllowSorting="True" AutoGenerateColumns="False"
										RowHighlightColor="#E0E0E0" PageSize="15" Width="100%">
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
										<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<Columns>
											<asp:TemplateColumn HeaderText="NRO RUC">
												<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
												<ItemTemplate>
													<asp:Label id="LblRuc" runat="server">Label</asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn DataField="PROVEEDOR" HeaderText="NOMBRE PROVEEDOR - RAZON SOCIAL">
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="CANT" HeaderText="CANTIDAD">
												<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="IMPORTE">
												<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn>
												<ItemTemplate>
													<asp:CheckBox id="chkSelect" runat="server" Checked="True"></asp:CheckBox>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
									</cc1:datagridweb></TD>
							</TR>
							<TR>
								<TD><IMG style="Z-INDEX: 0; CURSOR: hand" id="ibtnAtras" onclick="HistorialIrAtras();" alt=""
										src="../imagenes/atras.gif"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
