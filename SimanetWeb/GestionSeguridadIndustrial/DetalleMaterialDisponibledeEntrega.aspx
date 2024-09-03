<%@ Page language="c#" Codebehind="DetalleMaterialDisponibledeEntrega.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionSeguridadIndustrial.DetalleMaterialDisponibledeEntrega" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DetalleMaterialDisponibledeEntrega</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body onkeypress="if(event.keyCode==13)return false;" bottomMargin="0" leftMargin="0"
		rightMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" border="0" cellSpacing="1" cellPadding="1" width="100%">
				<TR>
					<TD class="HeaderGrilla"><asp:label id="Label1" runat="server">CODIGO:</asp:label></TD>
					<TD><asp:textbox id="txtCodMatEntrega" runat="server" CssClass="NormalDetalle" BackColor="#E0E0E0"
							ReadOnly="True" BorderWidth="1px" BorderColor="Gray"></asp:textbox></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD class="HeaderGrilla" vAlign="top" align="left"><asp:label id="Label2" runat="server">DESCRIPCION:</asp:label></TD>
					<TD colSpan="5">
						<asp:textbox id="txtDescripcion" runat="server" ReadOnly="True" BackColor="#E0E0E0" CssClass="NormalDetalle"
							Width="100%" Height="88px" TextMode="MultiLine" BorderWidth="1px" BorderColor="Gray"></asp:textbox></TD>
				</TR>
				<TR>
					<TD class="HeaderGrilla"><asp:label id="Label4" runat="server">TALLA:</asp:label></TD>
					<TD><asp:textbox id="txtTalla" runat="server" CssClass="NormalDetalle" BackColor="#E0E0E0" ReadOnly="True"
							Width="112px" BorderWidth="1px" BorderColor="Gray"></asp:textbox><INPUT style="WIDTH: 48px; HEIGHT: 22px" id="hModo" size="2" type="hidden" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 48px; HEIGHT: 22px" id="hCodEntrega" size="2" type="hidden"
							name="Hidden1" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 48px; HEIGHT: 22px" id="hCodItem" size="2" type="hidden"
							name="Hidden1" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 48px; HEIGHT: 22px" id="hCodTrabajador" size="2" type="hidden"
							name="Hidden1" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 48px; HEIGHT: 22px" id="hCantAtendida" size="2" type="hidden"
							name="Hidden1" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 48px; HEIGHT: 22px" id="hCantEnStock" size="2" type="hidden"
							name="Hidden1" runat="server"></TD>
					<TD class="HeaderGrilla">
						<asp:label style="Z-INDEX: 0" id="Label5" runat="server">F.ENTREGA:</asp:label></TD>
					<TD>
						<asp:TextBox id="calFEntrega" runat="server" rel="calendar" Width="100px" CssClass="NormalDetalle"></asp:TextBox></TD>
					<TD class="HeaderGrilla"><asp:label style="Z-INDEX: 0" id="Label3" runat="server">CANTIDAD:</asp:label></TD>
					<TD><asp:textbox style="Z-INDEX: 0" id="txtCantEntrega" runat="server" CssClass="NormalDetalle" rel="number"
							Width="80px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD class="HeaderGrilla">
						<asp:label style="Z-INDEX: 0" id="Label6" runat="server">FECHA ULT. ENTREGA:</asp:label></TD>
					<TD>
						<asp:TextBox style="Z-INDEX: 0" id="txtFechaUltEntrega" runat="server" CssClass="NormalDetalle"
							Width="112px" BorderColor="Gray" BorderWidth="1px" BackColor="#E0E0E0"></asp:TextBox><INPUT style="Z-INDEX: 0; WIDTH: 48px; HEIGHT: 22px" id="hEstadoEntrega" size="2" type="hidden"
							name="Hidden1" runat="server" value="0"></TD>
					<TD class="HeaderGrilla">
						<asp:label style="Z-INDEX: 0" id="Label7" runat="server">Días Transcurridos:</asp:label></TD>
					<TD>
						<asp:textbox style="Z-INDEX: 0" id="txtNroDias" runat="server" CssClass="NormalDetalle" Width="80px"
							rel="number" BorderColor="Gray" BorderWidth="1px" BackColor="#E0E0E0"></asp:textbox></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
