<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UploadPhoto.aspx.cs" Inherits="user_space_UploadPhoto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>上传照片</title>
    <link href="../Css/default.css" type="text/css" rel="stylesheet" />

<script type="text/javascript" src="../../JS/Common.js"></script>

<script src="../../JS/XmlHttp.js" type="text/javascript"></script>
     <base target="_self"/>
    <script type="text/javascript">
   function setImg(val)
   {
        if(val!="")
        { 
            if($('FilePicPath').value.trim().length==0)
           {
                alert("没有选择文件");
                $("FilePicPath").focus();
                return;  
           }   
            window.dialogArguments.$(val).value=$('FilePicPath').value;
            window.dialogArguments.SetImg();
            window.close(); 
        }
        else
       {
            alert("非法操作");
       }   
   }
   
   function isok()
   {        
        if($("File1").value=="")
        {
            alert("请选择图片路径!");
            $("File1").focus();
            return false;
        }
        
        
        if($("NewSize").checked==true && $("SelectNewSize2").checked==true)
        {
            if(Number($("BiLiValue").value)>100 || Number($("BiLiValue").value)<=0)
            {
                alert("图片缩略比例在1到100之间");
                $("BiLiValue").focus();
                return false;
            }
        }
        return true;
   }
   function setxx()
{
  $('File_PicPath').value = dialogArguments.document.all.FilePicPath.value
}
   </script> 

</head>
<body onload="setxx()" style="margin:0px">
    <form id="form1" runat="server">
        <table width="100%" align="center" cellpadding="6">
            <tr>
                <td><asp:TextBox ID="File_PicPath" runat="server" style="display:none"></asp:TextBox>
                    <table width="400" cellpadding="4" cellspacing="0" border="0" align="center">
                        <tr>
                            <td height="200" align="center" colspan="2">
                                <a  target="_blank" id="HrefImg"><img id="imgPre" onload="ImgSize(this)" src="../../images/browse.gif" border="0" alt="查看原始大小" /></a>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                文件路径：<asp:TextBox ID="FilePicPath" runat="server" Columns="34"></asp:TextBox>
                                <input id="Button2" type="button" value="插 入" class="btn" onclick="setImg('<%=ControlId %>')" />
                                <asp:Button ID="Button3" runat="server" Text="Button" Height="0px" Width="0px" /></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                选择文件：<input id="File1" type="file" size="29" name="File1" runat="server" class="btn">
                                <asp:Button ID="Button1" runat="server" Text=" 上传 " Height="22px" OnClick="Button1_Click"
                                    CssClass="btn" OnClientClick="return isok()" />
                            </td>
                        </tr>
                        <tr>
                            <td width="15%">
                                <table width="100%" cellspacing="0" cellpadding="4">
                                    <tr>
                                        <td>
                                            <asp:CheckBox ID="WaterMark" runat="server" Text="水印" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:CheckBox ID="NewSize" runat="server" Text="缩略" /></td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <table width="100%" cellspacing="0" cellpadding="2">
                                    <tr>
                                        <td>
                                            <input id="SelectNewSize1" type="radio" checked="CHECKED" name="NewSizeType" value="0" />按设置缩放：宽<asp:TextBox ID="MaxWidth" runat="server"
                                                Columns="4" onkeyup="value=value.replace(/[^\d]/g,'')">100</asp:TextBox>
                                            高<asp:TextBox ID="MaxHeight" runat="server" Columns="4" onkeyup="value=value.replace(/[^\d]/g,'')">100</asp:TextBox>
                                            单位：px</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <input id="SelectNewSize2" type="radio" name="NewSizeType" value="1" />按比例缩放：<asp:TextBox ID="BiLiValue" runat="server"
                                                Columns="3" MaxLength="3" onkeyup="value=value.replace(/[^\d]/g,'')">50</asp:TextBox>%
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                   </td>
            </tr>
        </table>
    </form><asp:Literal ID="litMsg" runat="server"></asp:Literal>
</body>
</html>
