<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreateAlbum.aspx.cs" Inherits="user_space_CreateAlbum" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<link href="../Css/default.css" type="text/css" rel="stylesheet" />

<script type="text/javascript" src="../../JS/Common.js"></script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>创建相册</title>
</head>

<script>
function CheckValidate()
{
    if($('txtAlbumName').value.trim()=="")
    {
        alert("相册名称必须填写");
        $('txtAlbumName').focus();
        return false;
    }
    if($("ddlIsOpened").value=="0" && $('txtAlbumPassword').value=="")
    {
        alert("密码必须填写");
        $('txtAlbumPassword').focus();
        return false;  
    }
}
function IsOpened()
{
    if($("ddlIsOpened").value=="0")
    {
       showPwd.style.display=""; 
    }
    else
    {
        $('txtAlbumPassword').value="";
       showPwd.style.display="none" 
     }
}
 function SetImg()
 {
} 
</script>

<body onload="IsOpened()">
    <form id="form1" runat="server">
        <table width="99%" cellspacing="1" cellpadding="0" class="wzdh" align="center">
            <tr>
                <td width="27">
                   <img src="../images/skin/default/you.gif" width="17" height="16"></td>
                <td>
                    您现在的位置： <a href="../welcome.aspx">用户后台</a> &gt;&gt; <a href="AlbumManage.aspx">相册管理</a>
                    &gt;&gt; 新建相册
                </td>
            </tr>
        </table>
       <table width="99%" cellspacing="1" cellpadding="0" class="border wzdh" align="center">
            <tr>
           <td>
                      &nbsp;<a href="RegSpace.aspx">空间管理</a> | <a href="AlbumManage.aspx">相册管理</a> | <a href="MessageManage.aspx">留言管理</a>
                </td> 
            </tr>
        </table>  
        <table width="99%" cellspacing="1" cellpadding="0" class="wzdh border" align="center" style="padding:2px;">
            <tr>
                <td  style="width: 115px">
                    <span class="impButton">我的相册</span>
                </td>
                <td>
                    ·<a href="AlbumManage.aspx">相册首页</a> ·创建相册 ·<a href="UploadPic.aspx">上传相片</a>
                </td>
            </tr>
           </table> 
            <!--创建相册-->
           <table width="99%" cellspacing="1" cellpadding="0" class="border" align="center" style="padding:2px;"> 
            <tbody id="Tabs0">
                <tr>
                    <td class="bqleft">
                        相册名称：
                    </td>
                    <td class="bqright">
                        <asp:TextBox ID="txtAlbumName" runat="server" Width="30%"></asp:TextBox>
                        *</td>
                </tr>
                <tr>
                    <td class="bqleft">
                        相册类别：
                    </td>
                    <td class="bqright">
                        <asp:DropDownList ID="ddlAlbumCate" runat="server">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td class="bqleft">
                        相册封面：
                    </td>
                    <td class="bqright">
                        <asp:TextBox ID="FilePicPath" runat="server" Text="" Style="display: none"></asp:TextBox>
                        <asp:TextBox ID="txtLogo" runat="server" Width="30%"></asp:TextBox>
                        <input id="btn" type="button" class="btn" value="浏览" onclick="WinOpenDialog('UploadPhoto.aspx?ControlId='+escape('txtLogo'),460,400)" />
                        <input id="Button1" class="btn" type="button" value="清空" onclick="javascript:$('txtLogo').value=''" /></td>
                </tr>
                <tr>
                    <td class="bqleft">
                        相册介绍：
                    </td>
                    <td class="bqright">
                        <asp:TextBox ID="txtAlbumDescription" runat="server" Width="50%" Height="96px" TextMode="MultiLine"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="bqleft">
                        是否公开：
                    </td>
                    <td class="bqright">
                        <asp:DropDownList ID="ddlIsOpened" runat="server" onchange="IsOpened()">
                            <asp:ListItem Value="1">公开相册</asp:ListItem>
                            <asp:ListItem Value="2">仅好友可见</asp:ListItem>
                            <asp:ListItem Value="0">密码访问</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr id="showPwd" style="display:none">
                    <td class="bqleft">
                        访问密码：
                    </td>
                    <td class="bqright">
                        <asp:TextBox ID="txtAlbumPassword" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="bqleft">
                    </td>
                    <td class="bqright">
                        <asp:Button ID="btnSaveAs" runat="server" Text="立即创建" CssClass="btn" OnClientClick="return CheckValidate()"
                            OnClick="btnSaveAs_Click" />
                        <input type="button" onclick="javascript:history.back()" value="取 消" class="btn" /></td>
                </tr>
            </tbody>
        </table>
    </form>
</body>
</html>
