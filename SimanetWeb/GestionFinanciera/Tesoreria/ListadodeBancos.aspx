<%@ Page language="c#" Codebehind="ListadodeBancos.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.Tesoreria.ListadodeBancos" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ListadodeBancos</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<div id="tabs1" style="WIDTH: 100%; HEIGHT: 100%">
				<div id="tS" class="x-hide-display">
				</div>
				<div id="tD" class="x-hide-display">
				</div>
			</div>
			<INPUT style="WIDTH: 72px; HEIGHT: 22px" id="hCodMoneda" size="6" type="hidden">
			<TABLE id="tblParametros" border="0" cellSpacing="1" cellPadding="1" width="300">
				<TR>
					<TD style="WIDTH: 44px; FONT-SIZE: 10pt; FONT-WEIGHT: bold">
						<asp:Label id="Label1" runat="server">AÑO:</asp:Label></TD>
					<TD>
						<asp:TextBox id="txtPeriodo" runat="server" Width="80px" CssClass="normal"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 44px; FONT-SIZE: 10pt; FONT-WEIGHT: bold">
						<asp:Label style="Z-INDEX: 0" id="Label2" runat="server">BANCO</asp:Label></TD>
					<TD>
						<asp:DropDownList id="ddlEntidadFinanciera" runat="server" Width="100%" style="Z-INDEX: 0" CssClass="normal">
							<asp:ListItem Value="uno">uno</asp:ListItem>
							<asp:ListItem Value="dos">dos</asp:ListItem>
							<asp:ListItem Value="tes&#161;&#161;&#161;&#161;">tes&#161;&#161;&#161;&#161;</asp:ListItem>
							<asp:ListItem></asp:ListItem>
						</asp:DropDownList></TD>
				</TR>
				<TR>
					<TD colSpan="2">
						<asp:DropDownList style="Z-INDEX: 0" id="ddlEntidadFinancieraConfig" runat="server" CssClass="normal"
							Width="100%">
							<asp:ListItem Value="uno">uno</asp:ListItem>
							<asp:ListItem Value="dos">dos</asp:ListItem>
							<asp:ListItem Value="tes&#161;&#161;&#161;&#161;">tes&#161;&#161;&#161;&#161;</asp:ListItem>
							<asp:ListItem></asp:ListItem>
						</asp:DropDownList></TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
			
			var tabs = new Ext.TabPanel({
					renderTo: 'tabs1',
					width:'100%',
					activeTab: 0,
					/*frame:true,*/
					defaults:{autoHeight: false},
					listeners: {'tabchange': function(tabPanel, tab){
													//window.alert(tabPanel.id + " - " + tab.id);
													jNet.get(((tab.id=='tbSoles')?'tS':'tD')).insert(jNet.get('tblParametros'));
													jNet.get('hCodMoneda').value = ((tab.id=='tbSoles')?'S':'D');
													
												}
								}, 					
					items:[
						{contentEl:'tS',id:'tbSoles', title: 'SOLES'},
						{contentEl:'tD',id:'tbDolar', title: 'DOLARES'}
					]
				});		
				
				//Al Cambiar de valor seleccionado del combo box;
				
				function AlCambiarSeleccionEntidadFinanciera(){
					var _oddlEntidadFinanciera = document.getElementById('ddlEntidadFinanciera');
					var _oddlEntidadFinancieraConfig = document.getElementById('ddlEntidadFinancieraConfig');
					_oddlEntidadFinancieraConfig.options[_oddlEntidadFinanciera.selectedIndex].selected=true;
				}
				
				
		</SCRIPT>
	</body>
</HTML>
