<%@ Page language="c#" Codebehind="InsertarTabla.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.Editor.popups.InsertarTabla" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>InsertarTabla</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		
			<STYLE>HTML {FONT-SIZE: 8pt; FONT-FAMILY: MS Shell Dlg}
				BODY {FONT-SIZE: 8pt; FONT-FAMILY: MS Shell Dlg}
				BUTTON {FONT-SIZE: 8pt; FONT-FAMILY: MS Shell Dlg}
				DIV {FONT-SIZE: 8pt; FONT-FAMILY: MS Shell Dlg}
				INPUT {FONT-SIZE: 8pt; FONT-FAMILY: MS Shell Dlg}
				SELECT {FONT-SIZE: 8pt; FONT-FAMILY: MS Shell Dlg}
				TD {FONT-SIZE: 8pt; FONT-FAMILY: MS Shell Dlg}
				FIELDSET {FONT-SIZE: 8pt; FONT-FAMILY: MS Shell Dlg}
			</STYLE>

		<SCRIPT>

		// if we pass the "window" object as a argument and then set opener to
		// equal that we can refer to dialogWindows and popupWindows the same way
		opener = window.dialogArguments;

		var _editor_url = opener._editor_url;
		var objname     = location.search.substring(1,location.search.length);
		var config      = opener.document.all[objname].config;
		var editor_obj  = opener.document.all["_" +objname+  "_editor"];
		var editdoc     = editor_obj.contentWindow.document;

		function _CloseOnEsc() {
		if (event.keyCode == 27) { window.close(); return; }
		}

		window.onerror = HandleError

		function HandleError(message, url, line) {
		var str = "An error has occurred in this dialog." + "\n\n"
		+ "Error: " + line + "\n" + message;
		alert(str);
		//  window.close();
		return true;
		}

		function Init() {
		document.body.onkeypress = _CloseOnEsc;
		}

		function _isValidNumber(txtBox) {
		var val = parseInt(txtBox);
		if (isNaN(val) || val < 0 || val > 9999) { return false; }
		return true;
		}

		function btnOKClick() {
		var curRange = editdoc.selection.createRange();

		// error checking
		var checkList = ['rows','cols','border','cellspacing','cellpadding'];
		for (var idx in checkList) {
			var fieldname = checkList[idx];
			if (document.all[fieldname].value == "") {
			alert("You must specify a value for the '" +fieldname+ "' field!");
			document.all[fieldname].focus();
			return;
			}
			else if (!_isValidNumber(document.all[fieldname].value)) {
			alert("You must specify a number between 0 and 9999 for '" +fieldname+ "'!");
			document.all[fieldname].focus();
			return;
			}
		}

		// delete selected content (if applicable)
		if (editdoc.selection.type == "Control" || curRange.htmlText) {

			if (!confirm("Overwrite selected content?")) { return; }

			curRange.execCommand('Delete');
			curRange = editdoc.selection.createRange();
		}


		// create table
		var table = '<table border="' +document.all.border.value+ '"'
					+ ' cellspacing="' +document.all.cellspacing.value+ '"'
					+ ' cellpadding="' +document.all.cellpadding.value+ '"'
					+ ' width="' +document.all.width.value + document.all.widthExt.value+ '"'
					+ ' align="' +document.all.alignment.value+ '">\n';

		for (var x=0; x<document.all.rows.value; x++) {
			table += " <tr>\n";
			for (var y=0; y<document.all.cols.value; y++) {
			table += "  <td></td>\n";
			}
			table += " </tr>\n";
		}
		table += "</table>\n";

		// insert table
		opener.editor_insertHTML(objname, table);


		// close popup window
		window.close();
		}
		</SCRIPT>
	</HEAD>
		
<BODY id=bdy style="BACKGROUND: buttonface; MARGIN: 10px; COLOR: windowtext; BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none" scroll=no onload=Init()>
<form id="Form1" method="post" runat="server">
	<TABLE style="MARGIN: 0px 0px 8px" cellSpacing=0 cellPadding=0 border=0>
		<TR>
			<TD>Rows: &nbsp;</TD>
			<TD><INPUT style="WIDTH: 50px" maxLength=4 value=4 name=rows></TD>
		</TR>
		<TR>
			<TD>Cols:</TD>
			<TD><INPUT style="WIDTH: 50px" maxLength=4 value=3 name=cols></TD>
			<TD width=10>&nbsp;</TD>
			<TD>Width: &nbsp;</TD>
			<TD><INPUT style="WIDTH: 50px" maxLength=4 value=100 name=width> <SELECT name=widthExt> <OPTION value="">Pixels</OPTION> <OPTION value=% selected>Percent</OPTION></SELECT> </TD></TR>
    </TABLE>
	<FIELDSET style="WIDTH: 1%; TEXT-ALIGN: center"><LEGEND>Layout</LEGEND>
		<TABLE cellSpacing=6 cellPadding=0 border=0>
			<TR>
				<TD height=21>Alignment:</TD>
				<TD><SELECT size=1 name=alignment> <OPTION value="" selected>Not set</OPTION> <OPTION value=left>Left</OPTION> 
					<OPTION value=right>Right</OPTION> <OPTION value=textTop>Texttop</OPTION> 
					<OPTION value=absMiddle>Absmiddle</OPTION> 
					<OPTION value=baseline>Baseline</OPTION> 
					<OPTION value=absBottom>Absbottom</OPTION> 
					<OPTION value=bottom>Bottom</OPTION> 
					<OPTION value=middle>Middle</OPTION> 
					<OPTION value=top>Top</OPTION>
					</SELECT> 
				</TD>
			</TR>
			<TR>
				<TD><NOBR>Border Thickness:</NOBR></TD>
				<TD><INPUT style="WIDTH: 100%" size=4 value=1 name=border></TD></TR>
		</TABLE>
	</FIELDSET> 
	<FIELDSET style="WIDTH: 1%; TEXT-ALIGN: center"><LEGEND>Spacing</LEGEND>
		<TABLE cellSpacing=6 cellPadding=0 border=0>
			<TR>
				<TD><NOBR>Cell Spacing:</NOBR></TD>
				<TD><INPUT style="WIDTH: 50px" maxLength=4 value=1 name=cellspacing></TD>
			</TR>
			<TR>
				<TD><NOBR>Cell Padding:</NOBR></TD>
				<TD><INPUT style="WIDTH: 50px" maxLength=4 value=2 name=cellpadding></TD>
			</TR>
		</TABLE>
	</FIELDSET> 
	<DIV style="LEFT: 340px; POSITION: absolute; TOP: 16px">
		<BUTTON style="MARGIN: 0px 0px 3px; WIDTH: 7em; HEIGHT: 2.2em" onclick="btnOKClick()">Aceptar</BUTTON><BR><BUTTON style="WIDTH: 7em; HEIGHT: 2.2em"onclick="window.close();">Cancelar</BUTTON> 
	</DIV>
</form>
</BODY>
</HTML>
