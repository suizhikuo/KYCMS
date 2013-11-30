<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdatePhoto.aspx.cs" Inherits="user_space_UpdatePhoto" %>

<%@ Import Namespace="Ky.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<link href="../Css/default.css" type="text/css" rel="stylesheet" />

<script type="text/javascript" src="../../JS/Common.js"></script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>修改照片</title>
</head>

<script>
function CheckValidate()
{
    if($('txtPhotoName').value.trim()=="")
    {
        alert("照片名称必须填写");
        $('txtPhotoName').focus();
        return false;
    }
    if($("ddlAlbum").value=="-1")
    {
        alert("请选择相册");
        $("ddlAlbum").focus();
        return false;
    }
}
function SetImg()
{}
</script>

<body>
    <form id="form1" runat="server">
        <asp:TextBox ID="FilePicPath" runat="server" Text="" Style="display: none"></asp:TextBox>
        <table width="99%" cellspacing="1" cellpadding="0" class="wzdh" align="center">
            <tr>
                <td width="27">
                    <img src="../images/skin/default/you.gif" width="17" height="16"></td>
                <td>
                    您现在的位置： <a href="../welcome.aspx">用户后台</a> &gt;&gt; <a href="AlbumManage.aspx">相册管理</a>
                    &gt;&gt; 上传照片
                </td>
            </tr>
        </table>
        <table width="99%" cellspacing="1" cellpadding="0" class="wzdh" align="center">
            <tr>
                <td>
                    <span class="impButton">我的相册</span>
                </td>
                <td>
                    ·<a href="AlbumManage.aspx">相册首页</a> ·<a href="CreateAlbum.aspx">创建相册</a> ·上传相片
                </td>
            </tr>
            <!--上传相片-->
            <tr>
                <td class="bqleft" style="height: 26px">
                    照片名称：
                </td>
                <td class="bqright" style="height: 26px">
                    <asp:TextBox ID="txtPhotoName" runat="server" Width="30%"></asp:TextBox>
                    *</td>
            </tr>
            <tr>
                <td class="bqleft">
                    选择相册：
                </td>
                <td class="bqright">
                    <asp:DropDownList ID="ddlAlbum" runat="server">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td class="bqleft">
                    照片预览：
                </td>
                <td class="bqright">
                    <div style="border: 1px #ccc solid; padding: 2px; width: 80px; height: 100px">
                        <asp:Image ID="imgView" runat="server" ImageUrl="~/user/images/view.gif" Width="76px"
                            Height="96px" /></div>
                    <asp:TextBox ID="txtPhoto" name="txtPhoto" runat="server" Width="30%" Style="display: none"
                        Text=''></asp:TextBox>
                    <asp:Button ID="btnUpload" runat="server" CssClass="btn" Text="更改照片地址.." OnClientClick="WinOpenDialog('UploadPhoto.aspx?ControlId='+escape('txtPhoto'),460,400)" /></td>
            </tr>
            <tr>
                <td class="bqleft">
                    照片介绍：
                </td>
                <td class="bqright">
                    <asp:TextBox ID="txtDescription" runat="server" Width="50%" TextMode="MultiLine"
                        Height="96px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="height: 24px">
                </td>
                <td style="height: 24px">
                    <asp:Button ID="btnPublish" runat="server" Text="保存修改" CssClass="btn" OnClientClick="return CheckValidate()"
                        OnClick="btnPublish_Click" />
                    <input type="button" onclick="javascript:history.back()" value="取 消" class="btn" /></td>
            </tr>
        </table>
    </form>
</body>
</html>
