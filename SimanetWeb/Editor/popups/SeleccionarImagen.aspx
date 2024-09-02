<%@ Page language="c#" Codebehind="SeleccionarImagen.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.Editor.popups.SeleccionarImagen" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>SeleccionarImagen</title>
		<meta name="vs_showGrid" content="True">
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<style> html, body, button, div, input, select, fieldset { font-family: MS Shell Dlg; font-size: 8pt; position: absolute; }
	; 
	</style>
		<SCRIPT defer>

function _CloseOnEsc() {
  if (event.keyCode == 27) { window.close(); return; }
}

function _getTextRange(elm) {
  var r = elm.parentTextEdit.createTextRange();
  r.moveToElementText(elm);
  return r;
}

window.onerror = HandleError

function HandleError(message, url, line) {
  var str = "An error has occurred in this dialog." + "\n\n"
  + "Error: " + line + "\n" + message;
  alert(str);
  window.close();
  return true;
}

var objtxtFileName =document.all["txtFileName"];

function Init() {
  var elmSelectedImage;
  var htmlSelectionControl = "Control";
  var globalDoc = window.dialogArguments;
  var grngMaster = globalDoc.selection.createRange();
  
  // event handlers  
  document.body.onkeypress = _CloseOnEsc;
  //btnOK.onclick = new Function("btnOKClick()");


  objtxtFileName.fImageLoaded = false;
  objtxtFileName.intImageWidth = 0;
  objtxtFileName.intImageHeight = 0;

  if (globalDoc.selection.type == htmlSelectionControl) {
    if (grngMaster.length == 1) {
      elmSelectedImage = grngMaster.item(0);
      if (elmSelectedImage.tagName == "IMG") {
        objtxtFileName.fImageLoaded = true;
        if (elmSelectedImage.src) {
          objtxtFileName.value          = elmSelectedImage.src.replace(/^[^*]*(\*\*\*)/, "$1");  // fix placeholder src values that editor converted to abs paths
          objtxtFileName.intImageHeight = elmSelectedImage.height;
          objtxtFileName.intImageWidth  = elmSelectedImage.width;
          txtVertical.value          = elmSelectedImage.vspace;
          txtHorizontal.value        = elmSelectedImage.hspace;
          txtBorder.value            = elmSelectedImage.border;
          txtAltText.value           = elmSelectedImage.alt;
          selAlignment.value         = elmSelectedImage.align;
        }
      }
    }
  }
  objtxtFileName.value = objtxtFileName.value || "http://";
  objtxtFileName.focus();
}

function _isValidNumber(txtBox) {
  var val = parseInt(txtBox);
  if (isNaN(val) || val < 0 || val > 999) { return false; }
  return true;
}

function btnOKClick() {
  var elmImage;
  var intAlignment;
  var htmlSelectionControl = "Control";
  var globalDoc = window.dialogArguments;
  var grngMaster = globalDoc.selection.createRange();
  
  // error checking

  if (!objtxtFileName.value || objtxtFileName.value == "http://") { 
    alert("Image URL must be specified.");
    objtxtFileName.focus();
    return;
  }
  if (txtHorizontal.value && !_isValidNumber(txtHorizontal.value)) {
    alert("Horizontal spacing must be a number between 0 and 999.");
    txtHorizontal.focus();
    return;
  }
  if (txtBorder.value && !_isValidNumber(txtBorder.value)) {
    alert("Border thickness must be a number between 0 and 999.");
    txtBorder.focus();
    return;
  }
  if (txtVertical.value && !_isValidNumber(txtVertical.value)) {
    alert("Vertical spacing must be a number between 0 and 999.");
    txtVertical.focus();
    return;
  }

  // delete selected content and replace with image
  if (globalDoc.selection.type == htmlSelectionControl && !objtxtFileName.fImageLoaded) {
    grngMaster.execCommand('Delete');
    grngMaster = globalDoc.selection.createRange();
  }
    
  idstr = "\" id=\"556e697175657e537472696e67";     // new image creation ID
  if (!objtxtFileName.fImageLoaded) {
    grngMaster.execCommand("InsertImage", false, idstr);
    elmImage = globalDoc.all['556e697175657e537472696e67'];
    elmImage.removeAttribute("id");
    elmImage.removeAttribute("src");
    grngMaster.moveStart("character", -1);
  } else {
    elmImage = grngMaster.item(0);
    if (elmImage.src != objtxtFileName.value) {
      grngMaster.execCommand('Delete');
      grngMaster = globalDoc.selection.createRange();
      grngMaster.execCommand("InsertImage", false, idstr);
      elmImage = globalDoc.all['556e697175657e537472696e67'];
      elmImage.removeAttribute("id");
      elmImage.removeAttribute("src");
      grngMaster.moveStart("character", -1);
      objtxtFileName.fImageLoaded = false;
    }
    grngMaster = _getTextRange(elmImage);
  }

  if (objtxtFileName.fImageLoaded) {
    elmImage.style.width = objtxtFileName.intImageWidth;
    elmImage.style.height = objtxtFileName.intImageHeight;
  }

  if (objtxtFileName.value.length > 2040) {
    objtxtFileName.value = objtxtFileName.value.substring(0,2040);
  }
  
  elmImage.src = objtxtFileName.value;
  
  if (txtHorizontal.value != "") { elmImage.hspace = parseInt(txtHorizontal.value); }
  else                           { elmImage.hspace = 0; }

  if (txtVertical.value != "") { elmImage.vspace = parseInt(txtVertical.value); }
  else                         { elmImage.vspace = 0; }
  
  elmImage.alt = txtAltText.value;

  if (txtBorder.value != "") { elmImage.border = parseInt(txtBorder.value); }
  else                       { elmImage.border = 0; }

  elmImage.align = selAlignment.value;
  grngMaster.collapse(false);
  grngMaster.select();
  window.close();
}
		</SCRIPT>
</HEAD>
	<BODY id="bdy" onload="Init()" style="BACKGROUND: buttonface; COLOR: windowtext" scroll="no">
		<form id="Form1" method="post" runat="server">
			<DIV id="divFileName" style="LEFT: 0.98em; WIDTH: 7em; TOP: 1.21em; HEIGHT: 1.21em">Image 
				URL:</DIV>
			<INPUT ID="txtFileName" type="text" style="LEFT: 8.54em; WIDTH: 21.5em; TOP: 1.06em; HEIGHT: 2.12em"
				tabIndex="10" onfocus="select()" name=txtFileName>
			<DIV id="divAltText" style="LEFT: 0.98em; WIDTH: 6.58em; TOP: 4.1em; HEIGHT: 1.21em">Alternate 
				Text:</DIV>
			<INPUT type="text" ID="txtAltText" tabIndex="15" style="LEFT: 8.54em; WIDTH: 21.5em; TOP: 3.8em; HEIGHT: 2.12em"
				onfocus="select()">
			<FIELDSET id="fldLayout" style="LEFT: 0.9em; WIDTH: 17.08em; TOP: 7.1em; HEIGHT: 7.6em">
				<LEGEND id="lgdLayout">
					Layout</LEGEND>
			</FIELDSET>
			<FIELDSET id="fldSpacing" style="LEFT: 18.9em; WIDTH: 11em; TOP: 7.1em; HEIGHT: 7.6em">
				<LEGEND id="lgdSpacing">
					Spacing</LEGEND>
			</FIELDSET>
			<DIV id="divAlign" style="LEFT: 1.82em; WIDTH: 4.76em; TOP: 9.12em; HEIGHT: 1.21em">Alignment:</DIV>
			<SELECT size="1" ID="selAlignment" tabIndex="20" style="LEFT: 10.36em; WIDTH: 6.72em; TOP: 8.82em; HEIGHT: 1.21em">
				<OPTION id="optNotSet" value="">
					Not set
				</OPTION>
				<OPTION id="optLeft" value="left">
					Left
				</OPTION>
				<OPTION id="optRight" value="right">
					Right
				</OPTION>
				<OPTION id="optTexttop" value="textTop">
					Texttop
				</OPTION>
				<OPTION id="optAbsMiddle" value="absMiddle">
					Absmiddle
				</OPTION>
				<OPTION id="optBaseline" value="baseline" SELECTED>
					Baseline
				</OPTION>
				<OPTION id="optAbsBottom" value="absBottom">
					Absbottom
				</OPTION>
				<OPTION id="optBottom" value="bottom">
					Bottom
				</OPTION>
				<OPTION id="optMiddle" value="middle">
					Middle
				</OPTION>
				<OPTION id="optTop" value="top">
					Top
				</OPTION>
			</SELECT>
			<DIV id="divHoriz" style="LEFT: 19.88em; WIDTH: 4.76em; TOP: 9.12em; HEIGHT: 1.21em">Horizontal:</DIV>
			<INPUT ID="txtHorizontal" style="LEFT: 24.92em; IME-MODE: disabled; WIDTH: 4.2em; TOP: 8.82em; HEIGHT: 2.12em"
				type="text" size="3" maxlength="3" tabIndex="25" onfocus="select()">
			<DIV id="divBorder" style="LEFT: 1.82em; WIDTH: 8.12em; TOP: 12.01em; HEIGHT: 1.21em">Border 
				Thickness:</DIV>
			<INPUT ID="txtBorder" style="LEFT: 10.36em; IME-MODE: disabled; WIDTH: 6.72em; TOP: 11.55em; HEIGHT: 2.12em"
				type="text" size="3" maxlength="3" tabIndex="21" onfocus="select()">
			<DIV id="divVert" style="LEFT: 19.88em; WIDTH: 3.64em; TOP: 12.01em; HEIGHT: 1.21em">Vertical:</DIV>
			<INPUT ID="txtVertical" style="LEFT: 24.92em; IME-MODE: disabled; WIDTH: 4.2em; TOP: 11.55em; HEIGHT: 2.12em"
				type="text" size="3" maxlength="3" tabIndex="30" onfocus="select()">
			<BUTTON ID="btnOK" style="LEFT: 31.36em; WIDTH: 7em; TOP: 1.06em; HEIGHT: 2.2em" tabIndex="40" onclick="btnOKClick();" type=button>
				Aceptar</BUTTON> <BUTTON ID="btnCancel" style="LEFT: 31.36em; WIDTH: 7em; TOP: 3.65em; HEIGHT: 2.2em"
				tabIndex="45" onClick="window.close();" type=button>Cancelar</BUTTON>
		</form>
	</BODY>
</HTML>
