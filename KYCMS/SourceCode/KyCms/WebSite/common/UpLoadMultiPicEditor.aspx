<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpLoadMultiPicEditor.aspx.cs"
    Inherits="common_UpLoadMultiPicEditor" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>上传多个文件</title>
    <link href="../user/css/default.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="../js/Common.js"></script>
    
    <script type="text/javascript">
    window.onload = function ()
    {
	// First of all, translate the dialog box texts
	oEditor.FCKLanguageManager.TranslatePage(document) ;
    }
    
   function setImg(url)
   {
      //var url=document.form1.FilePicPath.value;
      var oEditor = window.parent.InnerDialogLoaded() ;
      var oImg = oEditor.FCK.CreateElement( 'IMG' ) ; 
      oImg.src = url;
	  oImg.setAttribute( '_fcksavedurl', url) ;
	  //window.parent.Cancel() ;
   }
   </script>
</head>
<body onload="setxx()">
    <form id="form1" runat="server">
        <table width="100%" align="center" cellpadding="2" cellspacing="0" height="100%">
            <tr>
                <td><asp:TextBox ID="File_PicPath" runat="server" style="display:none"></asp:TextBox>
                    <table width="100%" align="center" cellpadding="2" cellspacing="0">
                        <tr>
                            <td align="right" height="25" width="16%">
                                地址一:
                            </td>
                            <td>
                                <input id="File1" type="file" size="40" name="File1" runat="server" class="btn">
                            </td>
                        </tr>
                        <tr>
                            <td align="right" height="25">
                                地址二:
                            </td>
                            <td>
                                <input id="File2" type="file" size="40" name="File1" runat="server" class="btn">
                            </td>
                        </tr>
                        <tr>
                            <td align="right" height="25">
                                地址三:
                            </td>
                            <td>
                                <input id="File3" type="file" size="40" name="File1" runat="server" class="btn">
                            </td>
                        </tr>
                        <tr>
                            <td align="right" height="25">
                                地址四:
                            </td>
                            <td>
                                <input id="File4" type="file" size="40" name="File1" runat="server" class="btn">
                            </td>
                        </tr>
                        <tr>
                            <td align="right" height="25">
                                地址五:
                            </td>
                            <td>
                                <input id="File5" type="file" size="40" name="File1" runat="server" class="btn">
                            </td>
                        </tr>
                        <tr>
                            <td align="right" height="25">
                                地址六:
                            </td>
                            <td>
                                <input id="File6" type="file" size="40" name="File1" runat="server" class="btn">
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:CheckBox ID="WaterMark" runat="server" Text="水印" Checked="True" />
                                &nbsp;<asp:Button ID="Button1" runat="server" Text=" 上 传 " CssClass="btn" OnClick="Button1_Click" />&nbsp; &nbsp;<input id="Reset1" type="reset" value=" 重 来 " class="btn" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form><asp:Literal ID="Literal1" runat="server"></asp:Literal><asp:Literal ID="Literal2" runat="server"></asp:Literal><asp:Literal ID="Literal3" runat="server"></asp:Literal><asp:Literal ID="Literal4" runat="server"></asp:Literal><asp:Literal ID="Literal5" runat="server"></asp:Literal><asp:Literal ID="Literal6" runat="server"></asp:Literal><asp:Literal ID="Literal7" runat="server"></asp:Literal>
</body>
</html>
<script>
function setxx()
{
  $('File_PicPath').value = dialogArguments.Editor.parent.document.form1.FilePicPath.value
}
</script>