<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AlbumManage.aspx.cs" Inherits="user_space_AlbumManage" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Import Namespace="Ky.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<link href="../Css/default.css" type="text/css" rel="stylesheet" />
<link href="../../userspace/skin/Space.css" type="text/css" rel="stylesheet" />
<script type="text/javascript" src="../../JS/Common.js"></script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>相册管理</title>
</head>
<body>
    <form id="form1" runat="server">
        <table width="99%" cellspacing="1" cellpadding="0" class="wzdh" align="center">
            <tr>
                <td width="27" >
                    <img src="../images/skin/default/you.gif" width="17" height="16"></td>
                <td>
                    您现在的位置： <a href="../welcome.aspx">用户后台</a> &gt;&gt; 相册管理
                </td>
            </tr>
        </table>
       <table width="99%" cellspacing="1" cellpadding="0" class="border wzdh" align="center">
            <tr>
           <td>
                      &nbsp;<a href="RegSpace.aspx">空间管理</a> | 相册管理 | <a href="MessageManage.aspx">留言管理</a>
                </td> 
            </tr>
        </table>  
       <table width="99%" cellspacing="1" cellpadding="0" class="border wzdh" align="center" style="padding:2px">
            <tr>
           <td style="width: 115px">
                    <span class="impButton">我的相册</span>
                </td> 
                <td>
              ·相册首页 ·<a href="CreateAlbum.aspx">创建相册</a> ·<a href="UploadPic.aspx">上传相片</a>
              </td>
            </tr>
        </table> 
        <div style="margin-left: 4px;" class="border">
            <div class="title">
                我的相册</div>
            <table cellspacing="0" cellpadding="0" border="0" align="left">
                <tr>
                    <asp:Repeater runat="server" ID="repAlbumManage" OnItemDataBound="repAlbumManage_ItemDataBound"
                        OnItemCommand="repAlbumManage_ItemDelete">
                        <HeaderTemplate>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <td>
                                <table style="border-collapse: collapse" cellspacing="0" cellpadding="0">
                                    <tr align="center">
                                        <td>
                                            <%#Eval("AlbumName") %>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="tdStyle" width="136" height="106">
                                            <a href='ShowPhoto.aspx?AlbumId=<%#Eval("Id") %>'>
                                                <asp:Image ID="Image1" runat="server" ImageUrl='<%#ShowImgPath(Eval("Logo")) %>'
                                                    Border="0" Width="120" Height="90" /></a>
                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <td>
                                            共<font color="red"><%#Eval("ImgCount") %></font>张照片
                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <td>
                                            <a href='CreateAlbum.aspx?Id=<%#Eval("Id") %>'>修改</a>
                                            <asp:HiddenField ID="hfId" runat="server" Value='<%#Eval("Id") %>' />
                                            <asp:LinkButton ID="lkBtnDelete" runat="server" OnClientClick="return confirm('确定删除此相册及里面的所有照片吗?')">删除</asp:LinkButton>[<font
                                                color="red"><%#IsOpened(Eval("IsOpened")) %></font>]</td>
                                    </tr>
                                </table>
                            </td>
                        </ItemTemplate>
                        <FooterTemplate>
                            <td>
                                <asp:Literal ID="litMsg" runat="server"></asp:Literal></td>
                        </FooterTemplate>
                    </asp:Repeater>
                </tr>
            </table>
            <div style="clear: both">
           <hr /> 
                <table cellpadding="0" cellspacing="0" align="center" width="99%">
                    <tr>
                        <td>
                            <webdiyer:AspNetPager ID="AspNetPager" runat="server" AlwaysShow="True" FirstPageText="首页"
                                LastPageText="尾页" NextPageText="下一页" OnPageChanging="AspNetPager_PageChanging"
                                PrevPageText="上一页" ShowCustomInfoSection="Left" ShowInputBox="Never" CustomInfoSectionWidth="10%"
                                ShowNavigationToolTip="True" Width="99%" HorizontalAlign="Right" PageSize="20">
                            </webdiyer:AspNetPager>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
