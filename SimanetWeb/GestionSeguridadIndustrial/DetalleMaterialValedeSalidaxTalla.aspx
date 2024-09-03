<%@ Page language="c#" Codebehind="DetalleMaterialValedeSalidaxTalla.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionSeguridadIndustrial.DetalleMaterialValedeSalidaxTalla" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DetalleMaterialValedeSalidaxTalla</title>
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
					<TD colSpan="6" align="center">
						<asp:Label id="Label5" runat="server" Font-Bold="True">REGISTRO DE MATERIAL  A STOCK</asp:Label></TD>
				</TR>
				<TR>
					<TD class="headerGrilla">
						<asp:Label id="Label1" runat="server">CODIGO:</asp:Label></TD>
					<TD>
						<asp:TextBox id="txtCodMat" runat="server" CssClass="normaldetalle" ReadOnly="True" BackColor="#E0E0E0"
							BorderColor="Gray" BorderWidth="1px"></asp:TextBox></TD>
					<TD></TD>
					<TD style="WIDTH: 90px"><INPUT style="WIDTH: 32px; HEIGHT: 22px" id="hCodItem" size="1" type="hidden" runat="server"
							NAME="hCodItem"><INPUT style="Z-INDEX: 0; WIDTH: 32px; HEIGHT: 22px" id="hCodCeo" size="1" type="hidden"
							name="Hidden1" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 32px; HEIGHT: 22px" id="hNroAlmacen" size="1" type="hidden"
							name="Hidden1" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 32px; HEIGHT: 22px" id="hNroValeSalida" size="1" type="hidden"
							name="Hidden1" runat="server"><INPUT style="WIDTH: 24px; HEIGHT: 22px" id="hModo" size="1" type="hidden" runat="server"
							NAME="hModo"><INPUT style="Z-INDEX: 0; WIDTH: 32px; HEIGHT: 22px" id="hCantReg" size="1" type="hidden"
							name="Hidden1" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 32px; HEIGHT: 22px" id="hCodTblTalla" size="1" type="hidden"
							name="Hidden1" runat="server"></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD class="headerGrilla">
						<asp:Label id="Label2" runat="server">NOMBRE</asp:Label></TD>
					<TD colSpan="5">
						<asp:TextBox id="txtDesMat" runat="server" CssClass="normaldetalle" Width="100%" ReadOnly="True"
							BackColor="#E0E0E0" TextMode="MultiLine" Height="64px" BorderColor="Gray" BorderWidth="1px"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD class="headerGrilla" noWrap>
						<asp:Label style="Z-INDEX: 0" id="Label6" runat="server">CANT. EN VSM:</asp:Label></TD>
					<TD>
						<asp:TextBox id="txtCantEnVSM" runat="server" Width="50px" ReadOnly="True" CssClass="normaldetalle"
							BackColor="#E0E0E0" BorderColor="Gray" BorderWidth="1px"></asp:TextBox></TD>
					<TD class="headerGrilla" colSpan="2" align="center">
						<asp:Label style="Z-INDEX: 0" id="Label4" runat="server">TALLA:</asp:Label></TD>
					<TD noWrap></TD>
					<TD width="100%"></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD colSpan="2">
						<cc1:datagridweb style="Z-INDEX: 0" id="gridTalla" runat="server" CssClass="HeaderGrilla" Width="336px"
							PageSize="15" RowPositionEnabled="False" RowHighlightColor="#E0E0E0" AutoGenerateColumns="False"
							ShowFooter="True" BorderStyle="None">
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
								<asp:BoundColumn DataField="NOM_ITEM" HeaderText="DESCRIPCION">
									<HeaderStyle Width="60%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CantReg" HeaderText="REG.">
									<HeaderStyle Width="20%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="POR REG.">
									<HeaderStyle Width="20%"></HeaderStyle>
									<ItemStyle Font-Bold="True" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
									<ItemTemplate>
										<asp:TextBox id="txtCantTalla" runat="server" BorderWidth="1px" BorderColor="Gray" CssClass="normaldetalle"
											Width="66px">0</asp:TextBox>
									</ItemTemplate>
									<FooterStyle HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Center" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
						</cc1:datagridweb></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD colSpan="4" align="center"></TD>
					<TD></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
