<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Page language="c#" Codebehind="AdministrarInterface.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.General.AdministrarInterface" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AdministrarInterface</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../styles.css">
		<SCRIPT language="javascript" src="../js/@Import.js"></SCRIPT>
		<script type="text/javascript" src="../js/RegEXT.js"></script>
		<SCRIPT type="text/javascript" src="http://simanet/SimanetJS/Ext/Ext.ux.Notify.js"></SCRIPT>
		<script>
			var KEYQNOMBRESP="QNomSP"
			var VentaBusqueda;
			var NombreSPSeleccionado="";
			
			function EjecutarSP(NombreSP){
				var urlPath='/' + ApplicationPath + '/General/InterfaceParametros.aspx?'+ KEYQNOMBRESP + "=" + NombreSP;
				//+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson ;
				VentaBusqueda=(new System.Ext.UI.WebControls.Windows()).Detalle("Ejecucion de interface",urlPath,this,395,400,btnAccion);
			}
			
			var strLstParametrosSP="";
			function btnAccion(btn){
				//Obtiene los valors de los parametros
				var otblParametros = jNet.get('tblParametros');
				for(var i=0;i<=	otblParametros.rows.length-1;i++){
					var objText = otblParametros.rows[i].cells[1].children[0];
					strLstParametrosSP = strLstParametrosSP + objText.value+"@";
				}
				if(strLstParametrosSP.length>0){
					strLstParametrosSP=strLstParametrosSP.substring(1,strLstParametrosSP.length-1);
				}
				var strParam=NombreSPSeleccionado+'*'+strLstParametrosSP;
				
				__doPostBack('btnEjecutar',strParam);
				//btn.close();
			}
		</script>
	</HEAD>
	<body oncontextmenu="return true" onunload="SubirHistorial();" onload="ObtenerHistorial();"
		bottomMargin="0" leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<table border="0" cellSpacing="0" cellPadding="0" width="100%" align="center">
				<tr>
					<td width="100%"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr>
					<td bgColor="#eff7fa" vAlign="top" width="100%"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
				<TR>
					<TD class="RutaPaginaActual" vAlign="top" width="100%" align="left"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio >Parámetros></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Administrar interface</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%" align="center">
						<TABLE id="Table1" class="normal" border="0" cellSpacing="0" cellPadding="0" width="767">
							<TR>
								<TD width="100%" colSpan="3" align="center">
									<TABLE style="HEIGHT: 8px" id="TblTabs" class="tabla" border="0" cellSpacing="0" cellPadding="0"
										width="760" bgColor="#f5f5f5" runat="server">
										<TR>
											<TD style="WIDTH: 37px; HEIGHT: 1px">
												<P align="right"><asp:label id="Label2" runat="server" CssClass="TituloPrincipal">FIANZA  :</asp:label></P>
											</TD>
											<TD style="HEIGHT: 1px"><asp:label id="lblSituacion" runat="server" CssClass="TituloPrincipal"></asp:label></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD width="100%" colSpan="3" align="center">
									<TABLE style="WIDTH: 769px" border="0" cellSpacing="0" cellPadding="0" width="769">
										<TR bgColor="#f0f0f0">
											<TD><IMG src="../../imagenes/tab_izq.gif" width="4" height="22"></TD>
											<TD></TD>
											<TD style="WIDTH: 117px"></TD>
											<TD style="WIDTH: 374px"></TD>
											<TD style="WIDTH: 374px"></TD>
											<TD style="WIDTH: 374px">&nbsp;&nbsp;<IMG src="../imagenes/spacer.gif" width="250" height="8"></TD>
											<TD></TD>
											<TD></TD>
											<TD></TD>
											<TD width="4" align="right"><IMG src="../../imagenes/tab_der.gif" width="4" height="22"></TD>
										</TR>
									</TABLE>
									<cc1:datagridweb id="grid" runat="server" DESIGNTIMEDRAGDROP="262" PageSize="20" AllowSorting="True"
										AutoGenerateColumns="False" RowHighlightColor="#E0E0E0" ShowFooter="True" Width="769px">
										<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO">
												<HeaderStyle Width="1%" VerticalAlign="Middle"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="NombreSP" SortExpression="NombreSP" HeaderText="INTERFACE">
												<HeaderStyle Width="15%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
										</Columns>
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb></TD>
							</TR>
							<TR>
								<TD width="100%" colSpan="3" align="center"><IMG style="WIDTH: 33px; HEIGHT: 12px" src="../../imagenes/spacer.gif" width="33" height="12"></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 11px" width="100%" colSpan="3" align="center"></TD>
							</TR>
							<TR>
								<TD width="100%" colSpan="3" align="left"><INPUT style="WIDTH: 32px; HEIGHT: 22px" id="hGridPagina" value="0" size="1" type="hidden"
										name="hGridPagina" runat="server"><INPUT style="WIDTH: 32px; HEIGHT: 22px" id="hGridPaginaSort" size="1" type="hidden" name="hGridPagina"
										runat="server">
									<asp:button id="btnEjecutar" runat="server" Text="Button"></asp:button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<tr>
					<td vAlign="top" width="592">
						<div style="VISIBILITY: hidden" id="tblModelo2" runat="server"></div>
					</td>
				</tr>
			</table>
			&nbsp;
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
