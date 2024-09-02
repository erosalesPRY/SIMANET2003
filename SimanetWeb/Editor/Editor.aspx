<%@ Page language="c#" Codebehind="Editor.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.Editor.Editor" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Editor</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<SCRIPT language="javascript" src="../js/@Import.js"></SCRIPT>
		<SCRIPT language="Javascript1.2">
		<!-- 
		//window.aler();
		// Carga de htmlarea
		_editor_url = ""; // URL del archivo htmlarea
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
					//objCampo.style.cssText="BACKGROUND-IMAGE:url(/SimaNetWeb/imagenes/Navegador/BtnOpciones/PostNota.gif); BACKGROUND-REPEAT: no-repeat;"; 
					var Argumento = "";
					Argumento = dialogArguments;
					var strTrama = Argumento.toString().Replace('[a]','\341')
														.Replace('[e]','\351')
														.Replace('[i]','\355')
														.Replace('[o]','\363')
														.Replace('[u]','\372')
														.Replace('[n]','\361')
														.Replace('[amp]','&')
														.Replace("¿","<")
														.Replace("?",">")
														.Replace("[men]","<")
														.Replace("[may]",">");
					objCampo.value=strTrama;
				}
			}
			
			function EntregarDescripcion()
			{
				var Datos=new Array();
				Datos[0]=document.all["campo1"].value;
				Datos[0] = Datos[0].toString().Replace('\341','[a]')
											.Replace('\351','[e]')
											.Replace('\355','[i]')
											.Replace('\363','[o]')
											.Replace('\372','[u]')
											.Replace('\361','[n]')
											.Replace('&','[amp]')
											.Replace("<","[men]")
											.Replace(">","[may]");
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
			<TEXTAREA style="BACKGROUND-IMAGE: url(/SimaNetWeb/imagenes/Navegador/BtnOpciones/PostNota.gif); WIDTH: 100%; BACKGROUND-REPEAT: no-repeat; HEIGHT: 75%"
				name="campo1" id="campo1" runat="server">
			</TEXTAREA>
			<SCRIPT language="JavaScript1.2" defer>
				var NombreCampoTxt = "campo1"
				editor_generate(NombreCampoTxt);
			</SCRIPT>
			<table width="100%">
				<tr>
					<td align="right">
						<table>
							<tr>
								<td>
									<IMG alt="" src="../imagenes/bt_aceptar.gif" id="ibtnGrabar" onclick="EntregarDescripcion();">
								</td>
								<td>
									<IMG alt="" src="../imagenes/bt_cancelar.gif" id="ibtnCancelar" onclick="window.close();">
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
