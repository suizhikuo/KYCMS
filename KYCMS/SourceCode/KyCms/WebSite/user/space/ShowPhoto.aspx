<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShowPhoto.aspx.cs" Inherits="user_space_ShowPhoto" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Import Namespace="Ky.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<link href="../Css/default.css" type="text/css" rel="stylesheet" />

<script type="text/javascript" src="../../JS/Common.js"></script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>显示相册照片</title>
</head>

<script>
function ShowCheck(o)
{
    var as=o.form.elements;
   var flag=false; 
    for(var i=0;i<as.length;i++)
    {
        if(as[i].type.toLowerCase()=="checkbox" && as[i]!=o)
        {
            as[i].checked=o.checked;
           flag=true; 
        }
    }
}

function CheckDelete()
{
    var s = $("repTable").getElementsByTagName("INPUT");
    var flag = false;
    for(var i=0;i<s.length;i++)
    {
        if(s[i].type=="checkbox")
        {
            if(s[i].checked)
            {
                flag = true;
            } 
        }
    }
    if(!flag)
   {
        alert("请选择删除项");
        return false; 
   }  
   return confirm("你确定要删除所有选中项吗？");
}

</script>

<body>
    <form id="form1" runat="server">
        <table width="99%" cellspacing="1" cellpadding="0" class="wzdh border" align="center">
            <tr>
                <td width="27">
                   <img src="../images/skin/default/you.gif" width="17" height="16"></td>
                <td>
                    您现在的位置： <a href="../welcome.aspx">用户后台</a> &gt;&gt; <a href="AlbumManage.aspx">相册管理</a>
                    &gt;&gt; 浏览照片
                </td>
            </tr>
        </table>
        <table width="99%" cellspacing="1" cellpadding="0" class="wzdh border" align="center">
            <tr>
                <td style="width: 115px">
                    <span class="impButton">我的相册</span>
                </td>
                <td class="fl">
                    ·<a href="AlbumManage.aspx">相册首页</a> ·<a href="CreateAlbum.aspx">创建相册</a> ·<a href='UploadPic.aspx?AlbumId=<%=AlbumId %>'>上传相片</a>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                </td>
            </tr>
        </table>
        <table width="99%" align="center" style="margin-top:5px" id="repTable">
            <tr>
                <asp:Repeater ID="repPhoto" runat="server" OnItemCommand="repPhoto_ItemCommand" OnItemDataBound="repPhoto_ItemDataBound">
                    <HeaderTemplate>
                        <div style="text-align: center;  background-color: #EBEBEB; padding: 5px;">
                            <asp:Label ID="lbRepTitle" runat="server" Text=''></asp:Label></div>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div style="width: 600px; padding: 2px;">
                            <div style="width: 70px; height: 100px; text-align: center; margin-left: 2px; border: 1px #ccc solid;
                                padding: 2px" class="fl">
                                <a href='ShowPic.aspx?FilePath=<%#Eval("FilePath") %>&PhotoId=<%#Eval("PhotoId") %>' target="_blank">
                                    <asp:Image ID="img" runat="server" ImageUrl='<%#Param.ApplicationRootPath+"/user/upload/"+Eval("FilePath")%>'
                                        Width="76px" Height="96px" /></a></div>
                            <div class="fl" style="line-height: 22px; margin-left: 5px">
                                <strong>相片名称：</strong><br />
                                创建日期：<br />
                                相片地址：<br />
                                相片描述：<br />
                                所属相册:
                            </div>
                            <div class="fl" style="line-height: 22px;">
                                <a href='UpdatePhoto.aspx?PhotoId=<%#Eval("PhotoId") %>&AlbumId=<%#Eval("AlbumId") %>'>
                                    <%#Eval("FileName")%>
                                </a>
                                <br />
                                <%#Eval("PostTime")%>
                                <br />
                                /user/upload/<%#Eval("FilePath") %>
                                <br />
                                <%#Eval("Description")%>
                                <br />
                                <asp:Label ID="lbAlbumName" runat="server" Text='<%#Eval("AlbumName") %>'></asp:Label>
                            </div>
                            <div class="fl">
                                浏览次数：<br />
                                图片大小：<br />
                                <br />
                                <br />
                                <br />
                            </div>
                            <div class="fr" style="width: 100px">
                                <%#Eval("VisitNum") %><br />
                                <%#Eval("FileSize") %><span style="color:red">byte</span><br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <asp:HiddenField ID="hfId" runat="server" Value='<%#Eval("PhotoId") %>' />
                                <a href='UpdatePhoto.aspx?PhotoId=<%#Eval("PhotoId") %>&AlbumId=<%#Eval("AlbumId") %>'>
                                    修改</a>┆<asp:LinkButton ID="lkBtn" runat="server" OnClientClick="return confirm('你确定要删除此照片吗?');">删除</asp:LinkButton>
                                <asp:CheckBox ID="chkBoxDelete" runat="server" /></div>
                        </div>
                        <div class="fl">
                            <hr style="width: 610px; border: #999 3px solid" />
                        </div>
                    </ItemTemplate>
                    <FooterTemplate>
                        <td>
                            <asp:Literal ID="litMsg" runat="server"></asp:Literal></td>
                    </FooterTemplate>
                </asp:Repeater>
            </tr>
        </table>
        <div style=" clear:both">
       <hr /> 
            <table cellpadding="0" cellspacing="0" align="center" width="99%">
                <tr>
                    <td>
                        <webdiyer:AspNetPager ID="AspNetPager" runat="server" AlwaysShow="True" FirstPageText="首页"
                            LastPageText="尾页" NextPageText="下一页" OnPageChanging="AspNetPager_PageChanging"
                            PrevPageText="上一页" ShowCustomInfoSection="Left" ShowInputBox="Never" CustomInfoSectionWidth="10%"
                            ShowNavigationToolTip="True" Width="48%" HorizontalAlign="Right" PageSize="10">
                        </webdiyer:AspNetPager>
                    </td>
                </tr>
            </table>
        </div>
        <div style="margin-left: 330px">
            <input type="checkbox" id="chkAll" onclick="ShowCheck(this)" /><label for="chkAll">选中本页显示的所有照片</label>&nbsp;<asp:Button
                ID="btnDeleteChecked" runat="server" Text="删除选定的图片" CssClass="btn" OnClick="btnDeleteChecked_Click"
                OnClientClick="return CheckDelete()" /></div>
    </form>
</body>
</html>
