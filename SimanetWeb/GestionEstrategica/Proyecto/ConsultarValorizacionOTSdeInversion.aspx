<%@ Page language="c#" Codebehind="ConsultarValorizacionOTSdeInversion.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionEstrategica.Proyecto.ConsultarValorizacionOTSdeInversion" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ConsultarValorizacionOTSdeInversion</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<style type="text/css">.list { LIST-STYLE-TYPE: square; PADDING-LEFT: 16px; WIDTH: 500px }
	.list LI { PADDING-BOTTOM: 2px; PADDING-LEFT: 2px; PADDING-RIGHT: 2px; FONT-SIZE: 8pt; PADDING-TOP: 2px }
	PRE { FONT-SIZE: 11px }
	.x-tab-panel-body .x-panel-body { PADDING-BOTTOM: 10px; PADDING-LEFT: 10px; PADDING-RIGHT: 10px; PADDING-TOP: 10px }
	.loading-indicator { BACKGROUND-IMAGE: url(ext-3.0.0/resources/images/default/grid/loading.gif); PADDING-LEFT: 20px; BACKGROUND-REPEAT: no-repeat; BACKGROUND-POSITION: left 50%; FONT-SIZE: 8pt }
	.new-tab { BACKGROUND-IMAGE: url(ext-3.0.0/examples/feed-viewer/images/new_tab.gif) !important }
	.tabs { BACKGROUND-IMAGE: url(ext-3.0.0/examples/desktop/images/tabs.gif) !important }
		</style>
		<LINK rel="stylesheet" type="text/css" href="../../styles.css">
	</HEAD>
	<body bottomMargin="0" leftMargin="0" rightMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" border="0" cellSpacing="1" cellPadding="1" width="100%">
				<TR>
					<TD style="PADDING-LEFT: 8px; WIDTH: 535px; HEIGHT: 28px" bgColor="#000080"><asp:label style="Z-INDEX: 0" id="lblTitulo" runat="server" Height="16px" CssClass="TituloPrincipalBlanco"
							Width="304px">DATOS DE VALORIZACION Y OTs.</asp:label></TD>
				</TR>
				<TR>
					<TD>
						<TABLE style="WIDTH: 712px; HEIGHT: 203px" id="Table2" border="0" cellSpacing="1" cellPadding="1"
							width="712" align="left">
							<TR>
								<TD style="WIDTH: 124px" class="headerDetalle"><asp:label style="Z-INDEX: 0" id="Label1" runat="server" CssClass="headerDetalle" BorderStyle="None">NRO VALORIZACION :</asp:label></TD>
								<TD style="WIDTH: 111px"><asp:textbox id="txtNroValorizacion" runat="server" CssClass="normaldetalle" Width="119px" BorderStyle="Dotted"
										BorderWidth="1px" ReadOnly="True"></asp:textbox></TD>
								<TD style="WIDTH: 107px" class="headerDetalle"><asp:label style="Z-INDEX: 0" id="Label2" runat="server" CssClass="headerDetalle" BorderStyle="None">NRO OTS:</asp:label>º</TD>
								<TD style="WIDTH: 102px"><asp:textbox style="Z-INDEX: 0" id="txtNroOTs" runat="server" CssClass="normaldetalle" Width="116px"
										BorderStyle="Dotted" BorderWidth="1px" ReadOnly="True"></asp:textbox></TD>
								<TD style="WIDTH: 104px" class="headerDetalle"><asp:label style="Z-INDEX: 0" id="Label3" runat="server" CssClass="headerDetalle" BorderStyle="None"> FECHA:</asp:label></TD>
								<TD><asp:textbox style="Z-INDEX: 0" id="txtFecha" runat="server" Height="20px" CssClass="normaldetalle"
										Width="102px" BorderStyle="Dotted" BorderWidth="1px" ReadOnly="True"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 124px" class="headerDetalle"><asp:label style="Z-INDEX: 0" id="Label4" runat="server" CssClass="headerDetalle" BorderStyle="None">NRO VALORIZACION :</asp:label></TD>
								<TD colSpan="5"><asp:textbox id="txtDescripcion" runat="server" Height="100px" CssClass="normaldetalle" Width="100%"
										BorderStyle="Dotted" BorderWidth="1px" ReadOnly="True" TextMode="MultiLine"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 354px; HEIGHT: 23px" class="headerDetalle" colSpan="3"><asp:label style="Z-INDEX: 0" id="Label8" runat="server" Width="344px" BorderStyle="None">VALORIZADO:</asp:label></TD>
								<TD style="HEIGHT: 23px" class="headerDetalle" colSpan="3" align="center"><asp:label style="Z-INDEX: 0" id="Label9" runat="server" Width="336px" BorderStyle="None">REAL</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 124px" class="headerDetalle"><asp:label style="Z-INDEX: 0" id="Label5" runat="server" Height="5px" Width="104px" BorderStyle="None">MANO OBRA</asp:label></TD>
								<TD style="WIDTH: 111px" class="headerDetalle" align="right"><asp:label style="Z-INDEX: 0" id="Label7" runat="server" Width="80px" BorderStyle="None">MATERIALES</asp:label></TD>
								<TD style="WIDTH: 107px" class="headerDetalle"><asp:label style="Z-INDEX: 0" id="Label6" runat="server" Width="88px" BorderStyle="None">SERVICIO</asp:label></TD>
								<TD style="WIDTH: 102px" class="headerDetalle" align="right"><asp:label style="Z-INDEX: 0" id="Label10" runat="server" Height="5px" Width="72px" BorderStyle="None">MANO OBRA</asp:label></TD>
								<TD style="WIDTH: 104px" class="headerDetalle"><asp:label style="Z-INDEX: 0" id="Label11" runat="server" Width="96px" BorderStyle="None">MATERIALES</asp:label></TD>
								<TD class="headerDetalle" align="right"><asp:label style="Z-INDEX: 0" id="Label12" runat="server" Width="72px" BorderStyle="None">SERVICIO</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 124px"><asp:textbox style="Z-INDEX: 0" id="txtTotalMOB" runat="server" CssClass="normaldetalle" Width="110px"
										BorderStyle="Dotted" BorderWidth="1px" ReadOnly="True"></asp:textbox></TD>
								<TD style="WIDTH: 111px" align="right"><asp:textbox style="Z-INDEX: 0" id="txtTotalMat" runat="server" CssClass="normaldetalle" Width="110px"
										BorderStyle="Dotted" BorderWidth="1px" ReadOnly="True"></asp:textbox></TD>
								<TD style="WIDTH: 107px"><asp:textbox style="Z-INDEX: 0" id="txtTotalSer" runat="server" CssClass="normaldetalle" Width="110px"
										BorderStyle="Dotted" BorderWidth="1px" ReadOnly="True"></asp:textbox></TD>
								<TD style="WIDTH: 102px" align="right"><asp:textbox style="Z-INDEX: 0" id="txtRTotalMOB" runat="server" CssClass="normaldetalle" Width="110px"
										BorderStyle="Dotted" BorderWidth="1px" ReadOnly="True"></asp:textbox></TD>
								<TD style="WIDTH: 104px"><asp:textbox style="Z-INDEX: 0" id="txtRTotalMat" runat="server" CssClass="normaldetalle" Width="110px"
										BorderStyle="Dotted" BorderWidth="1px" ReadOnly="True"></asp:textbox></TD>
								<TD align="right"><asp:textbox style="Z-INDEX: 0" id="txtRTotalSer" runat="server" CssClass="normaldetalle" Width="110px"
										BorderStyle="Dotted" BorderWidth="1px" ReadOnly="True"></asp:textbox></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD id="ContextTabs"></TD>
				</TR>
				<TR>
					<TD>
						<div id="DivMateriales"><asp:datagrid style="Z-INDEX: 0" id="gridMateriales" runat="server" Width="100%" AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
								<ItemStyle CssClass="ItemGrilla"></ItemStyle>
								<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
								<Columns>
									<asp:BoundColumn DataField="COD_RCS" HeaderText="CODIGO">
										<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="des_det" HeaderText="DESCRIPCION">
										<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="MontoProg" HeaderText="ESTIMACION">
										<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="MontoReal" HeaderText="REAL">
										<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
									</asp:BoundColumn>
								</Columns>
							</asp:datagrid></div>
					</TD>
				</TR>
				<TR>
					<TD>
						<div id="DivServicios"><asp:datagrid style="Z-INDEX: 1" id="gridServicios" runat="server" Width="100%" AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
								<ItemStyle CssClass="ItemGrilla"></ItemStyle>
								<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
								<Columns>
									<asp:BoundColumn DataField="COD_RCS" HeaderText="CODIGO">
										<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="des_det" HeaderText="DESCRIPCION">
										<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="MontoProg" HeaderText="ESTIMACION">
										<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="MontoReal" HeaderText="REAL">
										<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
									</asp:BoundColumn>
								</Columns>
							</asp:datagrid></div>
					</TD>
				</TR>
				<TR>
					<TD>
						<div id="DivManoObra"><asp:datagrid style="Z-INDEX: 2" id="gridManoObra" runat="server" Width="100%" AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
								<ItemStyle CssClass="ItemGrilla"></ItemStyle>
								<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
								<Columns>
									<asp:BoundColumn DataField="COD_RCS" HeaderText="CODIGO">
										<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="des_det" HeaderText="DESCRIPCION">
										<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="MontoProg" HeaderText="ESTIMACION">
										<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="MontoReal" HeaderText="REAL">
										<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
									</asp:BoundColumn>
								</Columns>
							</asp:datagrid></div>
					</TD>
				</TR>
			</TABLE>
		</form>
		<script>
			new Ext.TabPanel({renderTo: jNet.get(ContextTabs),
								activeTab: 0,
								width:710,
								height:240,
								plain:true,
								defaults:{autoScroll: true},
								items:[{title: 'Mano de Obra',contentEl:'DivManoObra'}
										,{title: 'Materiales',contentEl:'DivMateriales'}
										,{title: 'Servicios',contentEl:'DivServicios'}
									  ]
							});

    function handleActivate(tab){
        //alert(tab.title + ' was activated.');
    }

		
		
		
		</script>
	</body>
</HTML>
