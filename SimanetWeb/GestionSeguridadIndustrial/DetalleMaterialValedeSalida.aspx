<%@ Page language="c#" Codebehind="DetalleMaterialValedeSalida.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionSeguridadIndustrial.DetalleMaterialValedeSalida" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>DetalleMaterialValedeSalida</title>
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
					<TD style="WIDTH: 90px"><INPUT style="WIDTH: 32px; HEIGHT: 22px" id="hCodItem" size="1" type="hidden" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 32px; HEIGHT: 22px" id="hCodCeo" size="1" type="hidden"
							name="Hidden1" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 32px; HEIGHT: 22px" id="hNroAlmacen" size="1" type="hidden"
							name="Hidden1" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 32px; HEIGHT: 22px" id="hNroValeSalida" size="1" type="hidden"
							name="Hidden1" runat="server"><INPUT style="WIDTH: 24px; HEIGHT: 22px" id="hModo" size="1" type="hidden" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 32px; HEIGHT: 22px" id="hCantReg" size="1" type="hidden"
							name="Hidden1" runat="server"><INPUT 
      style="Z-INDEX: 0; WIDTH: 32px; HEIGHT: 22px" id=hCodTblTalla size=1 
      type=hidden name=Hidden1 runat="server"></TD>
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
					<TD class="headerGrilla">
						<asp:Label style="Z-INDEX: 0" id="Label6" runat="server">CANT. EN VSM:</asp:Label></TD>
					<TD>
						<asp:TextBox id="txtCantEnVSM" runat="server" Width="50px" ReadOnly="True" CssClass="normaldetalle"
							BackColor="#E0E0E0" BorderColor="Gray" BorderWidth="1px"></asp:TextBox></TD>
					<TD class="headerGrilla">
						<asp:Label style="Z-INDEX: 0" id="Label4" runat="server">TALLA:</asp:Label></TD>
					<TD style="WIDTH: 90px">
						<asp:DropDownList style="Z-INDEX: 0" id="ddlTalla" runat="server" CssClass="normaldetalle" Width="88px"></asp:DropDownList></TD>
					<TD class="headerGrilla" noWrap>
						<asp:Label id="Label3" runat="server" style="Z-INDEX: 0">CANT. REG:</asp:Label></TD>
					<TD width="100%">
						<asp:TextBox id="txtCantReg" runat="server" CssClass="normaldetalle" Width="50px" style="Z-INDEX: 0"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD style="WIDTH: 90px"></TD>
					<TD></TD>
					<TD></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
