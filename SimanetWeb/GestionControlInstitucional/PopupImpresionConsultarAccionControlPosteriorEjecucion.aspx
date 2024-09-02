<%@ Page language="c#" Codebehind="PopupImpresionConsultarAccionControlPosteriorEjecucion.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionControlInstitucional.PopupImpresionConsultarAccionControlPosteriorEjecucion" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
  </HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="730" align="center" border="0">
				<TR>
					<TD class="TituloPrincipal" align="center" colSpan="3"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal"></asp:label></TD>
				</TR>
				<TR>
					<TD align="right"></TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE class="normal" id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
							<TR>
								<TD align="center" width="100%" colSpan="6" rowSpan="3"><asp:datagrid id="grid" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="7"
										Width="720px" CssClass="HeaderGrilla">
<AlternatingItemStyle CssClass="AlternateItemGrilla">
</AlternatingItemStyle>

<ItemStyle CssClass="ItemGrilla">
</ItemStyle>

<HeaderStyle CssClass="HeaderGrilla">
</HeaderStyle>

<FooterStyle CssClass="FooterGrilla">
</FooterStyle>

<Columns>
<asp:BoundColumn DataField="Codigo" HeaderText="CODIGO">
<ItemStyle HorizontalAlign="Left">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="Denominacion" HeaderText="ACCION DE CONTROL">
<ItemStyle HorizontalAlign="Left">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="MetaProgramada" HeaderText="META" DataFormatString="{0:# ### ### ##0.00}"></asp:BoundColumn>
<asp:BoundColumn DataField="Estado" HeaderText="ESTADO"></asp:BoundColumn>
<asp:BoundColumn DataField="Etapa" HeaderText="ETAPA"></asp:BoundColumn>
<asp:BoundColumn DataField="PorcentajeAvanceTotal" HeaderText="%" DataFormatString="{0:# ### ### ##0.00}"></asp:BoundColumn>
<asp:BoundColumn DataField="FechaInicio" HeaderText="FECHA INICIO" DataFormatString="{0:dd-MM-yyyy}"></asp:BoundColumn>
<asp:BoundColumn DataField="FechaTermino" HeaderText="FECHA TERMINO" DataFormatString="{0:dd-MM-yyyy}"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="NroRealIntegrantesOCI" HeaderText="INTEGRANTES OCI"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="NroRealIntegrantesEspecialistas" HeaderText="INTEGRANTES ESPECIALISTAS"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="CostoRealOCI" HeaderText="COSTO OCI" DataFormatString="{0:# ### ### ##0.00}"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="CostoRealEspecialistas" HeaderText="COSTO ESPECIALISTAS" DataFormatString="{0:# ### ### ##0.00}"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="NumeroRealHH" HeaderText="NUMERO HH" DataFormatString="{0:# ### ### ##0.00}"></asp:BoundColumn>
<asp:BoundColumn DataField="MontoExaminado" HeaderText="MONTO EXAMINADO" DataFormatString="{0:# ### ### ##0.00}"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="Observaciones" HeaderText="OBSERVACIONES"></asp:BoundColumn>
</Columns>

<PagerStyle Visible="False" CssClass="PagerGrilla" Mode="NumericPages">
</PagerStyle>
									</asp:datagrid><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
