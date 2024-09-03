<%@ Page language="c#" Codebehind="GlosaEstadosFinancieros.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancieros.GlosaEstadosFinancieros" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>Detalle de Concepto</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<!--<SCRIPT language="javascript" src=../../Editor/editor.js>  </SCRIPT>-->
		<SCRIPT language="Javascript1.2">
		<!-- 
		// Carga de htmlarea
		_editor_url = "../../Editor/"; // URL del archivo htmlarea
		var win_ie_ver = parseFloat(navigator.appVersion.split("MSIE")[1]);
		if (navigator.userAgent.indexOf('Mac')        >= 0) { win_ie_ver = 0; }
		if (navigator.userAgent.indexOf('Windows CE') >= 0) { win_ie_ver = 0; }
		if (navigator.userAgent.indexOf('Opera')      >= 0) { win_ie_ver = 0; }
		
		if (win_ie_ver >= 5.5) 
		{
			var strScript = '<scr' + 'ipt src="' +_editor_url+ 'editor.js"'
			//document.write('<scr' + 'ipt src="' +_editor_url+ 'editor.js"');
			document.write(strScript);
			var strScript2 = ' language="Javascript1.2"></scr' + 'ipt>';
			//document.write(' language="Javascript1.2"></scr' + 'ipt>');  
			document.write(strScript2);  
		} 
		else 
		{ 
			document.write('<scr'+'ipt>function editor_generate() { return false; }</scr'+'ipt>'); 
		}
		
		
		// -->
		</SCRIPT>
		<script>
			function MostrarValor()
			{
				if (dialogArguments.length >0)
				{
					var objCampo = document.all["campo1"];
					var Argumento = "";
					Argumento = dialogArguments;
					var strTrama = ReemplazaSigno(Argumento,"¿","<");
					objCampo.value=ReemplazaSigno(strTrama,"?",">");
				}
			}
			
			function EntregarDescripcion()
			{
				var Datos=new Array();
				Datos[0]=document.all["campo1"].value;
				window.returnValue=Datos;
				window.close();
			}

			function ReemplazaSigno(strCadena,valReemplazar,valReemplazo)
			{
				var NewCadena="";
				var arrCadena = strCadena.split(valReemplazar);
				var strRemplaza=strCadena;
				for (var i=0;i <= arrCadena.length-1;i++)
				{
					strRemplaza = strRemplaza.replace(valReemplazar,valReemplazo);
				}
				NewCadena=strRemplaza;
				return NewCadena;
			}
			
		</script>
</HEAD>
	<body bottomMargin="0" bgColor="buttonface" leftMargin="5" topMargin="0" rightMargin="5"
		onload="MostrarValor();">
		<form id="Form1" method="post" runat="server">
			<table>
				<TR>
					<TD></TD>
					<TD></TD>
				</TR>
				<tr>
					<td>
						<asp:Label id="Label1" runat="server" CssClass="TituloPrincipalBlanco" ForeColor="Navy" Font-Bold="True">CONCEPTO :</asp:Label>
					</td>
					<TD>
						<asp:Label id="lblConcepto" runat="server" CssClass="TituloPrincipalBlanco" ForeColor="Navy"
							Font-Bold="True">Label</asp:Label></TD>
				</tr>
			</table>
			<TEXTAREA style="WIDTH: 100%; HEIGHT: 82%" name="campo1" id="campo1" runat="server" >
			</TEXTAREA>
			<SCRIPT language="JavaScript1.2" defer>
				var NombreCampoTxt = "campo1"
				editor_generate(NombreCampoTxt);
				/*var config     = document.all[NombreCampoTxt].config;
				  for (var btnName in config.btnList) 
				  { 
					try
					{
						document.all['_' + NombreCampoTxt + '_' + config.btnList[btnName][0]].style.display = "none";
					}
					catch(error){//Control de errores}
				} 
				document.all['_' + NombreCampoTxt + '_FontName'].style.display = "none";
				document.all['_' + NombreCampoTxt + '_FontSize'].style.display = "none";
				*/
				document.all['_editor_toolbar'].style.display = "none";
				
			</SCRIPT>
			<table width="100%">
				<tr>
					<td align="right">
						<IMG id=ibtnCancelar onclick=window.close(); alt="" src="../../imagenes/bt_cancelar.gif">
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
