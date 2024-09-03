<%@ Page language="c#" Codebehind="ListarValedeSalidaDisponibles.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionSeguridadIndustrial.ListarValedeSalidaDisponibles" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
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
			<table border="0" width="100%">
				<tr>
					<td vAlign="top" align="left">
						<TABLE style="HEIGHT: 32px" id="Table1" border="0" cellSpacing="1" cellPadding="1"
							width="100%" align="left">
							<TR>
								<TD class="HeaderGrilla">
									<asp:Label id="Label1" runat="server">BUSCAR:</asp:Label></TD>
								<TD width="100%">
									<asp:TextBox id="txtBuscarVSM" runat="server" Width="100%" CssClass="NormalDetalle" BorderColor="Gray" BorderWidth="1px"></asp:TextBox></TD>
							</TR>
						</TABLE>
					</td>
				</tr>
				<tr>
					<td>
						<div style="HEIGHT:315px; OVERFLOW:scroll">
							<cc1:datagridweb style="Z-INDEX: 0" id="grid" runat="server" Width="100%" AllowSorting="True" AutoGenerateColumns="False"
								RowHighlightColor="#E0E0E0" RowPositionEnabled="False" PageSize="15" CssClass="HeaderGrilla">
<AlternatingItemStyle CssClass="AlternateItemGrilla">
</AlternatingItemStyle>

<ItemStyle Height="25px" CssClass="ItemGrilla">
</ItemStyle>

<HeaderStyle CssClass="HeaderGrilla">
</HeaderStyle>

<FooterStyle CssClass="FooterGrilla">
</FooterStyle>

<Columns>
<asp:BoundColumn HeaderText="NRO">
<HeaderStyle Width="1%">
</HeaderStyle>

<ItemStyle Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle">
</ItemStyle>

<FooterStyle HorizontalAlign="Left">
</FooterStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="NombreAlmacen" HeaderText="ALMACEN">
<HeaderStyle Width="10%">
</HeaderStyle>

<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="nro_vsm" HeaderText="NUMERO">
<HeaderStyle Width="6%">
</HeaderStyle>

<ItemStyle Wrap="False" HorizontalAlign="Left">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="des_vsm" HeaderText="DESCRIPCION">
<HeaderStyle Width="15%">
</HeaderStyle>

<ItemStyle Wrap="False" HorizontalAlign="Left">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="fec_ems" HeaderText="F. EMISION">
<HeaderStyle HorizontalAlign="Center" Width="5%">
</HeaderStyle>

<ItemStyle Wrap="False" HorizontalAlign="Center">
</ItemStyle>

<FooterStyle HorizontalAlign="Left">
</FooterStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="Cantidad" HeaderText="RECEPCIONADO">
<HeaderStyle HorizontalAlign="Center" Width="2%">
</HeaderStyle>

<ItemStyle Wrap="False" HorizontalAlign="Right">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="CantReg" HeaderText="REGISTRADO">
<HeaderStyle HorizontalAlign="Center" Width="2%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Justify">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="CantPorReg" HeaderText="DISPONIBLE.">
<HeaderStyle HorizontalAlign="Center" Width="2%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Right">
</ItemStyle>
</asp:BoundColumn>
</Columns>

<PagerStyle HorizontalAlign="Center" CssClass="PagerGrilla" Mode="NumericPages">
</PagerStyle>
							</cc1:datagridweb>
						</div>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
