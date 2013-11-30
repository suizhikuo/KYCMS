<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Main.aspx.cs" Inherits="Users_Main" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>会员后台管理中心</title>
    <style type="text/css"> *{margin:0;padding:0;border:0;}
 #nav { font-family: arial, 宋体, serif; font-size:12px;line-height: 24px; list-style-type: none; background:#06A;width:100%; padding-left:30px}
 #nav a { display: block; width: 80px; text-align:center; }
 #nav a:link,#nav a:visited { color:#FFF; text-decoration:none; }
 #nav a:hover { color:#000;text-decoration:none;font-weight:bold; }
 #nav li { float: left; width: 80px; background:#06A; }
 #nav li a:hover{ background:#BFD9FF; }
 #nav li ul { line-height: 27px; list-style-type: none;text-align:center; left: -999em; width: 80px; position: absolute; border:solid 1px #06A}
 #nav li ul li{ float: left; width: 80px; background: #0084DB;color:#FFF }
 #nav li ul a{ display: block; width: 80px;text-align:center; }
 #nav li ul a:link,#nav li ul a:visited { text-decoration:none; }
 #nav li ul a:hover { color:#000;text-decoration:none;font-weight:normal; background:#FFF; }
 #nav li:hover ul { left: auto;}
 #nav li.mouseover ul { left: auto; }
 </style>

    <script type="text/javascript">
    function nav() {
    var lis = document.getElementById("nav").getElementsByTagName("li");
    for (var i=0; i<lis.length; i++) {
    lis[i].onmouseover=function() {
    this.className+=(this.className.length>0? " ": "") + "mouseover";
    }
    lis[i].onmouseout=function() {
    this.className=this.className.replace(new RegExp("( ?|^)mouseover\\b"),"");
    }
    }
    }
    window.onload=nav;
    </script>

</head>
<body scroll="no">
    <table width="100%" border="0" cellspacing="0" cellpadding="0" height="100%">
        <tr>
            <td>
                <iframe frameborder="0" id="Iframe2" width="100%" height="80" scrolling="no" src="top.aspx"
                    class="main_iframe"></iframe>
            </td>
        </tr>
        <tr>
            <td>
                <ul id="nav">
                    <li><a href="welcome.aspx" target="ContentIframe">后台首页</a></li>
                    <li><a href="#">我的地盘</a>
                        <ul>
                            <li><a href='<%=MyProfile %>' target="ContentIframe">资料维护</a></li>
                            <li><a href="info/UserCateList.aspx" target="ContentIframe">我的专栏</a></li>
                            <li><a href="space/RegSpace.aspx" target="ContentIframe">我的空间</a></li>
                            <li><a href="space/AlbumManage.aspx" target="ContentIframe">我的相册</a></li>
                            <li><a href="space/MessageManage.aspx" target="ContentIframe">我的留言</a></li>
                            <li><a href="Message/MessageList.aspx?TypeId=1" target="ContentIframe">短消息</a></li>
                            <li><a href="UserFavoriteList.aspx" target="ContentIframe">收藏夹</a></li>
                        </ul>
                    </li>
                    <li><a href="#">我要投稿</a>
                        <ul>
                           <asp:Repeater ID="repChannel" runat="server">
                                        <ItemTemplate>
                                           <li>
                                            <a href='info/<%#GetInfoUrl(Eval("ModelType"),Eval("ChId")) %>' target="ContentIframe"><%#Eval("ChName") %></a>
                                           </li>
                                        </ItemTemplate>
                                    </asp:Repeater> 
                                    <li id="OnErr" runat="server" visible="false"><a href="#">无法投稿</a></li>
                        </ul>
                    </li>
                    <li><a href="#">财富空间</a>
                        <ul>
                            <li><a href="Money/Log.aspx" target="ContentIframe">消费明细</a></li>
                            <li><a href="Money/MoneyChange.aspx" target="ContentIframe">财富兑换</a></li>
                            <li><a href="Money/MoneySend.aspx" target="ContentIframe"">财富赠送</a></li>
                            <li><a href="Money/Recharge.aspx" target="ContentIframe">充值卡充值</a></li>
                            <li><a href="Money/RechargeRecord.aspx" target="ContentIframe">充值记录</a></li>
                        </ul>
                    </li>
                    <li><a href="#">我的好友</a>
                        <ul>
                            <li><a href="Friend/SetFriend.aspx" target="ContentIframe">我的好友</a></li>
                            <li><a href="Friend/FriendGroup.aspx" target="ContentIframe">好友分组</a></li>
                            <li><a href="Friend/SetFriend.aspx?gid=2" target="ContentIframe">黑名单</a></li>
                        </ul>
                    </li>
                    <li><a href='<%=GetSpaceUrl() %>' target="_blank">我的主页</a> </li>
                    <li><a href="#">系统相关</a>
                        <ul>
                            <li><a href="Notice/NoticeList.aspx" target="ContentIframe">系统公告</a></li>
                            <li><a href="SetRecommand.aspx" target="ContentIframe">推广奖励</a></li>
                            <li><a href="MyFeedback.aspx" target="ContentIframe">问题反馈</a></li>
                        </ul>
                    </li>
                    <li><a href='<%=SiteIndex %>' target="_blank">站点首页</a> </li>
                    <li><a href="SignOut.aspx" target="_parent">安全退出</a> </li>
                </ul>
            </td>
        </tr>
        <tr>
            <td height="100%">
                <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="218" height="100%" align="center" valign="top" id="frmTitle">
                            <iframe frameborder="0" id="LeftIframe" name="LeftIframe" width="210" height="100%"
                                scrolling="auto" src="left.aspx" class="main_iframe"></iframe>
                        </td>
                        <td rowspan="2" valign="top">
                            <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0" bgcolor="e8f1f8"
                                id="tb1">
                                <tr>
                                    <td>
                                        <iframe frameborder="0" id="ContentIframe" name="ContentIframe" width="100%" height="100%"
                                            scrolling="yes" src="welcome.aspx" class="main_iframe"></iframe>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</body>
</html>
