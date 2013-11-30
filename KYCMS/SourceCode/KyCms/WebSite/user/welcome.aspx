<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Welcome.aspx.cs" Inherits="User_Welcome" %>

<%@ Import Namespace="Ky.Common" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>欢迎</title>
    <link href="Css/Default.css" type="text/css" rel="Stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <table class="maintable" cellpadding="0" cellspacing="4">
            <tr>
                <td colspan="2" valign="top">
                    <table id="shortcut" cellpadding="0" cellspacing="1">
                        <tr>
                            <td colspan="3" class="bar">
                                快捷入口</td>
                        </tr>
                        <tr>
                            <td>
                                <a href='<%=MyProfile %>'>
                                    <img src="../user/images/wh.jpg" />
                                    资料维护</a>
                            </td>
                            <td>
                                <a href="#" onmouseover="SetDiv(2);" onmouseout="SetDiv(1);">
                                    <img src="../user/images/xzl.jpg" />
                                    我的稿件</a>
                                <table id="tg" style="display: none; position: absolute;" onmouseover="SetDiv(2);"
                                    onmouseout="SetDiv(3);" cellpadding="0" cellspacing="0">
                                    <asp:Repeater ID="repChannel" runat="server">
                                        <ItemTemplate>
                                           <tr>
                                            <td><a href="info/infoList.aspx?ChId=<%#Eval("ChId") %>" target="ContentIframe"><%#Eval("ChName") %></a></td>
                                            <td><a href='info/<%#GetInfoUrl(Eval("ModelType"),Eval("ChId")) %>' target="ContentIframe">[投稿]</a></td>
                                           </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                    <tr id="TrOnErr" runat="server" visible="false">
                                        <td>您目前无法投稿</td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <a href="UserFavoriteList.aspx">
                                    <img src="../user/images/sc.jpg" />
                                    我的收藏夹</a></td>
                        </tr>
                        <tr>
                            <td>
                                <a href="MyFeedback.aspx">
                                    <img src="../user/images/fk.gif" />
                                    我的问答</a></td>
                            <td>
                                <a href="info/UserCateList.aspx">
                                    <img src="../user/images/gzl.jpg" />
                                    管理专栏</a></td>
                            <td>
                                <a href="Money/Recharge.aspx">
                                    <img src="../user/images/cz.jpg" />
                                    充值</a></td>
                        </tr>
                        <tr>
                            <td>
                                <a href="space/AlbumManage.aspx">
                                    <img src="../user/images/gsc.jpg" />
                                    管理相册</a></td>
                            <td>
                                <a href="space/uploadPic.aspx">
                                    <img src="../user/images/xsc.jpg" />
                                    上传照片</a></td>
                            <td>
                                <a href="Message/Message.aspx">
                                    <img src="../user/images/dxx.jpg" />
                                    发送短消息</a></td>
                        </tr>
                    </table>
                </td>
                <td rowspan="3" valign="top" style="width: 25%">
                    <table cellpadding="0" cellspacing="1" class="rightTable">
                        <tr>
                            <td class="bar">
                                其他功能</td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <asp:Repeater ID="Rep_CustomForm" runat="server">
                                    <ItemTemplate>
                                        <li>
                                            <a href='info/InfoCustomForm.aspx?CustomFormId=<%#Eval("CustomFormId") %>'
                                            target="ContentIframe">
                                            <%#Eval("FormName") %></a>
                                            &nbsp;&nbsp;<a href='info/CustomFormInfoList.aspx?CustomFormId=<%#Eval("CustomFormId") %>'
                                                target="ContentIframe">[管理]</a></li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td valign="top" style="width: 39%">
                    <table cellpadding="0" cellspacing="1" class="innertable">
                        <tr>
                            <td class="bar">
                                <img src="../user/images/gg.jpg" />
                                系统公告</td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <asp:Repeater ID="rptNotice" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td valign="top">
                                                <li><a href='Notice/ShowNotice.aspx?NoticeId=<%# Eval("NoticeId")%>'>
                                                    <%# Eval("Title")%></li>
                                                </a>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </td>
                        </tr>
                    </table>
                </td>
                <td valign="top" style="width: 39%">
                    <table cellpadding="0" cellspacing="1" class="innertable">
                        <tr>
                            <td class="bar">
                                <img src="../user/images/gj.jpg" />
                                我的稿件</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Repeater ID="Repeater2" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td valign="top">
                                                <li>
                                                    <%# Function.HtmlEncode(Eval("Title")) %>
                                                </li>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <table cellpadding="0" cellspacing="1" class="innertable">
                        <tr>
                            <td class="bar">
                                <img src="../user/images/hy.jpg" />
                                我的好友</td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <asp:Repeater ID="Repeater4" runat="server">
                                    <ItemTemplate>
                                        <li><a href="Friend/ViewFriend.aspx?fid=<%# Eval("FriendId") %>">
                                            <%# Eval("LogName") %>
                                            &nbsp;&nbsp;&nbsp;<a href='Message/Message.aspx?ReceiverName=<%# Function.UrlEncode(Eval("LogName").ToString()) %>'
                                                target="ContentIframe">[发送短消息]</a> </a></li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </td>
                        </tr>
                    </table>
                </td>
                <td valign="top">
                    <table cellpadding="0" cellspacing="1" class="innerTable">
                        <tr>
                            <td class="bar">
                                <img src="../user/images/tg.jpg" />
                                我的留言</td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <asp:Repeater ID="rptMsg" runat="server">
                                    <ItemTemplate>
                                        <li><a href="space/ResumeMsg.aspx?Id=<%#Eval("Id") %>&option=look" title='点击查看留言内容'>
                                            <%#Function.HtmlEncode(Eval("Title")).Replace("\r\n","<br />").Replace(" ","&nbsp;&nbsp;")%>
                                        </a></li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>

<script type="text/javascript">
   var timer=null;
   var o = document.getElementById("tg");
    function SetDiv(t)
    {                
        if(t == 1)
        {
            o.style.display="";
            timer=window.setTimeout("SetDiv(3)",1000);
        }
        if(t == 2)
        {
            window.clearTimeout(timer);
            o.style.display="";
        }
        if(t == 3)
        {
             o.style.display="none";
        }
    }
</script>

