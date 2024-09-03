<%@ Page language="c#" Codebehind="Calculadora.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancieros.Calculadora" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>Calculadora</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<SCRIPT language="javascript" src="../../js/JSFrameworkSima.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/FrameCallBack.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
		
		<script>
			function addChar(input, character)
			{
				if(input.value == null || input.value == "0")
					input.value = character
				else
					input.value += character
			}

			function deleteChar(input)
			{
				input.value = input.value.substring(0, input.value.length - 1)
			}

			function changeSign(input)
			{
				// could use input.value = 0 - input.value, but let's show off substring
				if(input.value.substring(0, 1) == "-")
					input.value = input.value.substring(1, input.value.length)
				else
					input.value = "-" + input.value
			}

			function compute(form) 
			{
					form.display.value = eval(form.display.value)
			}
			function checkNum(str) 
			{
					for (var i = 0; i < str.length; i++) {
							var ch = str.substring(i, i+1)
							if (ch < "0" || ch > "9") {
									if (ch != "/" && ch != "*" && ch != "+" && ch != "-" && ch != "."
											&& ch != "(" && ch!= ")") {
											alert("Valor no valido!")
											return false
									}
							}
					}
					return true
			}
			function KeyPress(objthis)
			{
				if (event.keyCode ==13)	{if (checkNum(objthis.value)){ objthis.value = eval(objthis.value);EntregarResultado();}}
			}
			function EntregarResultado()
			{
				Datos=document.all["display"].value;
				window.returnValue=Datos;
				window.close();
			}
		</script>
</HEAD>
	<body bgColor="buttonface" onkeydown="if (event.keyCode==13 || event.keyCode==9)return false" leftMargin=0 rightMargin=0>
		<form id="Form1" method="post" runat="server">
			<table border="0" >
				<tr>
					<td align="right" colSpan="5"><input style="BORDER-RIGHT: #999999 1px groove; BORDER-TOP: #999999 1px groove; BORDER-LEFT: #999999 1px groove; WIDTH: 242px; BORDER-BOTTOM: #999999 1px groove; HEIGHT: 23px"
							size="35" value="0" name="display" id="display" onkeydown="KeyPress(this);">
					</td>
				</tr>
				<tr>
					<td align="center" colSpan="5"><IMG style="WIDTH: 132px; HEIGHT: 8px" height="8" src="../imagenes/spacer.gif" width="132"></td>
				</tr>
				<TR>
					<TD align="right" colSpan="5">
						<TABLE id="Table1" cellSpacing="1" cellPadding="2" width="242" align="right" border="0">
							<TR>
								<TD><input onclick="addChar(this.form.display, '7')" type="button" value="  7  "></TD>
								<TD><input onclick="addChar(this.form.display, '8')" type="button" value="  8  "></TD>
								<TD><input onclick="addChar(this.form.display, '9')" type="button" value="  9  "></TD>
								<TD><input onclick="addChar(this.form.display, '/')" type="button" value="  /  "></TD>
								<TD><input style="FONT-WEIGHT: bold" onclick="if (checkNum(this.form.display.value))    { compute(this.form);EntregarResultado();}"
										type="button" value="Aceptar" name="enter"></TD>
							</TR>
							<TR>
								<TD><input onclick="addChar(this.form.display, '4')" type="button" value="  4  "></TD>
								<TD><input onclick="addChar(this.form.display, '5')" type="button" value="  5  "></TD>
								<TD><input onclick="addChar(this.form.display, '6')" type="button" value="  6  "></TD>
								<TD><input onclick="addChar(this.form.display, '*')" type="button" value="  *  "></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD><input onclick="addChar(this.form.display, '1')" type="button" value="  1  "></TD>
								<TD><input onclick="addChar(this.form.display, '2')" type="button" value="  2  "></TD>
								<TD><input onclick="addChar(this.form.display, '3')" type="button" value="  3  "></TD>
								<TD><input onclick="addChar(this.form.display, '-')" type="button" value="  -  "></TD>
								<TD><input style="WIDTH: 100%" onclick="this.form.display.value = 0 "
										type="button" value="C/CE "></TD>
							</TR>
							<TR>
								<TD><input onclick="addChar(this.form.display, '0')" type="button" value="  0  "></TD>
								<TD><input onclick="addChar(this.form.display, '.')" type="button" value="   .  "></TD>
								<TD><input onclick="changeSign(this.form.display)" type="button" value=" +/- "></TD>
								<TD><input onclick="addChar(this.form.display, '+')" type="button" value=" +  "></TD>
								<TD><INPUT style="WIDTH: 100%" onclick="deleteChar(this.form.display, '(')"
										type="button" value="   <--   "></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</table>
		</form>
		<SCRIPT>
			SIMA.Utilitario.Error.TiempoEsperadePagina();
		</SCRIPT>
	</body>
</HTML>
