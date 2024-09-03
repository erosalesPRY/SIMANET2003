<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Page language="c#" Codebehind="ListarMaterialPorAlmacenValedeSalida.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionSeguridadIndustrial.ListarMaterialPorAlmacenValedeSalida" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ListarValedeSalidaDisponibles</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body onkeypress="if(event.keyCode==13)return false;" bottomMargin="0" leftMargin="0"
		rightMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" border="0" cellSpacing="1" cellPadding="1" width="100%">
				<TR>
					<TD>
						<TABLE style="HEIGHT: 94px" id="Table2" border="0" cellSpacing="1" cellPadding="1" width="100%">
							<TR>
								<TD class="HeaderGrilla" colSpan="4" align="center">
									<asp:Label id="lblTitulo" runat="server" Font-Bold="True">VALE DE SALIDA</asp:Label></TD>
							</TR>
							<TR>
								<TD class="HeaderGrilla" noWrap>
									<asp:Label id="Label1" runat="server"> Nro Vale:</asp:Label></TD>
								<TD>
									<asp:TextBox id="txtNroVale" runat="server" CssClass="normaldetalle" Width="153px" ReadOnly="True"
										BackColor="#E0E0E0" BorderWidth="1px" BorderColor="Gray"></asp:TextBox></TD>
								<TD class="HeaderGrilla" noWrap>
									<asp:Label style="Z-INDEX: 0" id="Label3" runat="server">Fecha Emisión:</asp:Label></TD>
								<TD width="100%">
									<asp:TextBox style="Z-INDEX: 0" id="txtFechaEmision" runat="server" CssClass="normaldetalle"
										Width="153px" ReadOnly="True" BackColor="#E0E0E0" BorderWidth="1px" BorderColor="Gray"></asp:TextBox><INPUT style="WIDTH: 40px; HEIGHT: 22px" id="hCodCentro" size="1" type="hidden" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 40px; HEIGHT: 22px" id="hNroValSal" size="1" type="hidden"
										name="Hidden1" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 40px; HEIGHT: 22px" id="hCodAlmacen" size="1" type="hidden"
										name="Hidden1" runat="server"></TD>
							</TR>
							<TR>
								<TD class="HeaderGrilla" noWrap>
									<asp:Label style="Z-INDEX: 0" id="Label2" runat="server">Descripción:</asp:Label></TD>
								<TD colSpan="3">
									<asp:TextBox id="txtObservacion" runat="server" CssClass="normaldetalle" Width="100%" Height="56px"
										TextMode="MultiLine" ReadOnly="True" BackColor="#E0E0E0" style="Z-INDEX: 0" BorderWidth="1px"
										BorderColor="Gray"></asp:TextBox></TD>
							</TR>
							<TR>
								<TD></TD>
								<TD></TD>
								<TD></TD>
								<TD></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>
						<div style="HEIGHT:420px; OVERFLOW:scroll">
							<cc1:datagridweb style="Z-INDEX: 0" id="gridMat" runat="server" Width="100%" AutoGenerateColumns="False"
								RowHighlightColor="#E0E0E0" RowPositionEnabled="False" PageSize="15" CssClass="HeaderGrilla">
								<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
								<ItemStyle Height="25px" CssClass="ItemGrilla"></ItemStyle>
								<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
								<FooterStyle CssClass="FooterGrilla"></FooterStyle>
								<Columns>
									<asp:BoundColumn HeaderText="NRO">
										<HeaderStyle Width="1%"></HeaderStyle>
										<ItemStyle Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
										<FooterStyle HorizontalAlign="Left"></FooterStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="COD_MAT" HeaderText="CODIGO">
										<HeaderStyle Width="5%"></HeaderStyle>
										<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="des_det" HeaderText="DESCRIPCION">
										<HeaderStyle Width="50%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="und_med" HeaderText="UND&lt;BR&gt;MED">
										<HeaderStyle Width="5%"></HeaderStyle>
										<ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CantEnVSM" HeaderText="EN&lt;BR&gt;VSM">
										<HeaderStyle HorizontalAlign="Center" Width="2%"></HeaderStyle>
										<ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
										<FooterStyle HorizontalAlign="Left"></FooterStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CantReg" HeaderText="REG.">
										<HeaderStyle HorizontalAlign="Center" Width="2%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CantPorReg" HeaderText="POR&lt;BR&gt;REG.">
										<HeaderStyle HorizontalAlign="Center" Width="2%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="prc_pmd" HeaderText="PREC.&lt;BR&gt;PROM.">
										<HeaderStyle HorizontalAlign="Center" Width="2%"></HeaderStyle>
										<ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
								</Columns>
								<PagerStyle HorizontalAlign="Center" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
							</cc1:datagridweb>
						</div>
					</TD>
				</TR>
				<TR>
					<TD></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
