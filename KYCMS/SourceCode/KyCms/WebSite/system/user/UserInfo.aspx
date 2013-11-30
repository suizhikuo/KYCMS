<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserInfo.aspx.cs" Inherits="system_user_UserInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>用户信息</title>
    <link href="../Css/Default.css" type="text/css" rel="Stylesheet" />

    <script src="../../js/Common.js" type="text/javascript"></script>

    <%Response.Write(JScript); %>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table align="center" cellpadding="0" cellspacing="1" class="wzdh" width="99%">
                <tr>
                    <td height="24" width="20">
                        <img align="absMiddle" alt="arrow" src="../images/skin/default/you.gif" /></td>
                    <td align="left" style="padding-top: 3px">
                        您现在的位置：<a href="../SystemInfo.aspx">后台管理</a> &gt;&gt; 用户管理 &gt;&gt; 查看用户信息</td>
                    <td align="right" width="50">
                        <img align="absMiddle" alt="arrow" src="../images/skin/default/help.gif" /></td>
                </tr>
            </table>
            <table align="center" cellpadding="0" cellspacing="1" class="border" width="99%">
                <tr class="wzlist">
                    <td align="left">
                        <a href="UserList.aspx?type=1">个人用户列表</a> | <a href="UserList.aspx?type=2">企业用户列表</a>
                        | <a href="SetCommonUser.aspx">新增个人用户</a> | <a href="SetCorpUser.aspx">新增企业用户</a>
                        &nbsp;</td>
                </tr>
            </table>
            <table id="Tbody0" runat="server" align="center" border="0" cellpadding="0" cellspacing="0"
                class="cd" width="99%">
                <tbody>
                    <tr align="center">
                        <td id="Tab1" class="title6" onclick="ShowTabs(1)">
                            基本信息</td>
                        <td id="Tab2" class="title5" onclick="ShowTabs(2)">
                            其他信息</td>
                        <td id="Tab3" class="title5" onclick="ShowTabs(3)">
                            企业信息</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </tbody>
            </table>
        </div>
        <table id="Tbody1" runat="server" align="center" cellpadding="0" cellspacing="1"
            class="editborder" width="99%">
            <tr id="Tr1" runat="server">
                <td rowspan="17" valign="top" class="bqleft">
                    <asp:Image ID="imgHead" runat="server" ImageUrl="~/user/upload/UserFace/null.jpg"
                        Height="120px" Width="120px" BorderStyle="Solid" BorderColor="ActiveBorder" BorderWidth="1px" /></td>
                <td class="bqleft">
                    名称:</td>
                <td class="bqright">
                    <asp:Label ID="lbLogName" runat="server"></asp:Label></td>
            </tr>
            <tr id="Tr2" runat="server">
                <td class="bqleft">
                    昵称:</td>
                <td class="bqright">
                    <asp:Label ID="lbNickName" runat="server"></asp:Label></td>
            </tr>
            <tr id="Tr3" runat="server">
                <td class="bqleft">
                    Email:</td>
                <td class="bqright">
                    <asp:Label ID="lbEmail" runat="server"></asp:Label></td>
            </tr>
            <tr id="Tr4" runat="server">
                <td class="bqleft">
                    真实姓名:</td>
                <td class="bqright">
                    <asp:Label ID="lbRealName" runat="server"></asp:Label></td>
            </tr>
            <tr id="Tr5" runat="server">
                <td class="bqleft">
                    性别:</td>
                <td class="bqright">
                    <asp:Label ID="lbSex" runat="server"></asp:Label></td>
            </tr>
            <tr id="Tr6" runat="server">
                <td class="bqleft">
                    生日:</td>
                <td class="bqright">
                    <asp:Label ID="lbBirthday" runat="server"></asp:Label></td>
            </tr>
            <tr id="Tr7" runat="server">
                <td class="bqleft">
                    民族:</td>
                <td class="bqright">
                    <asp:Label ID="lbNation" runat="server"></asp:Label></td>
            </tr>
            <tr id="Tr8" runat="server">
                <td class="bqleft">
                    籍贯:</td>
                <td class="bqright">
                    <asp:Label ID="lbNative" runat="server"></asp:Label></td>
            </tr>
            <tr id="Tr9" runat="server">
                <td class="bqleft">
                    省市:</td>
                <td class="bqright">
                    <asp:Label ID="lbCity" runat="server"></asp:Label></td>
            </tr>
            <tr id="Tr10" runat="server">
                <td class="bqleft">
                    地址:</td>
                <td class="bqright">
                    <asp:Label ID="lbAddress" runat="server"></asp:Label></td>
            </tr>
            <tr id="Tr11" runat="server">
                <td class="bqleft">
                    邮编:</td>
                <td class="bqright">
                    <asp:Label ID="lbPostCode" runat="server"></asp:Label></td>
            </tr>
            <tr id="Tr12" runat="server">
                <td class="bqleft">
                    性格:</td>
                <td class="bqright">
                    <asp:Label ID="lbNature" runat="server"></asp:Label></td>
            </tr>
            <tr id="Tr13" runat="server">
                <td class="bqleft">
                    身高:</td>
                <td class="bqright">
                    <asp:Label ID="lbStature" runat="server"></asp:Label></td>
            </tr>
            <tr id="Tr14" runat="server">
                <td class="bqleft">
                    爱好:</td>
                <td class="bqright">
                    <asp:Label ID="lbLike" runat="server"></asp:Label></td>
            </tr>
            <tr id="Tr15" runat="server">
                <td class="bqleft">
                    签名:</td>
                <td class="bqright">
                    <asp:Label ID="lbAutoGraph" runat="server"></asp:Label></td>
            </tr>
        </table>
        <table id="Tbody2" runat="server" align="center" cellpadding="0" cellspacing="1"
            class="editborder" style="display: none" width="99%">
            <tr id="Tr17" runat="server">
                <td class="bqleft">
                    政治面貌:</td>
                <td class="bqright">
                    <asp:Label ID="lbOrgenazation" runat="server"></asp:Label></td>
            </tr>
            <tr id="Tr18" runat="server">
                <td class="bqleft">
                    职业:</td>
                <td class="bqright">
                    <asp:Label ID="lbWork" runat="server"></asp:Label></td>
            </tr>
            <tr id="Tr19" runat="server">
                <td class="bqleft">
                    学历:</td>
                <td class="bqright">
                    <asp:Label ID="lbSchoolRecord" runat="server"></asp:Label></td>
            </tr>
            <tr id="Tr20" runat="server">
                <td class="bqleft">
                    家庭电话:</td>
                <td class="bqright">
                    <asp:Label ID="lbPhone" runat="server"></asp:Label></td>
            </tr>
            <tr id="Tr21" runat="server">
                <td class="bqleft">
                    手机:</td>
                <td class="bqright">
                    <asp:Label ID="lbMobile" runat="server"></asp:Label></td>
            </tr>
            <tr id="Tr22" runat="server">
                <td class="bqleft">
                    婚否:</td>
                <td class="bqright">
                    <asp:Label ID="lbMarry" runat="server"></asp:Label></td>
            </tr>
            <tr id="Tr23" runat="server">
                <td class="bqleft">
                    QQ:</td>
                <td class="bqright">
                    <asp:Label ID="lbQQ" runat="server"></asp:Label></td>
            </tr>
            <tr id="Tr24" runat="server">
                <td class="bqleft">
                    MSN:</td>
                <td class="bqright">
                    <asp:Label ID="lbMSN" runat="server"></asp:Label></td>
            </tr>
            <tr id="Tr25" runat="server">
                <td class="bqleft">
                    金币:</td>
                <td class="bqright">
                    <asp:Label ID="lbYellowboy" runat="server"></asp:Label></td>
            </tr>
            <tr id="Tr26" runat="server">
                <td class="bqleft">
                    魅力:</td>
                <td class="bqright">
                    <asp:Label ID="lbCharm" runat="server"></asp:Label></td>
            </tr>
            <tr id="Tr27" runat="server">
                <td class="bqleft">
                    人气:</td>
                <td class="bqright">
                    <asp:Label ID="lbPopulation" runat="server"></asp:Label></td>
            </tr>
            <tr id="Tr28" runat="server">
                <td class="bqleft">
                    活跃值:</td>
                <td class="bqright">
                    <asp:Label ID="lbActive" runat="server"></asp:Label></td>
            </tr>
            <tr id="Tr29" runat="server">
                <td class="bqleft">
                    是否锁定:</td>
                <td class="bqright">
                    <asp:Label ID="lbLock" runat="server"></asp:Label></td>
            </tr>
            <tr id="Tr30" runat="server">
                <td class="bqleft">
                    注册时间:</td>
                <td class="bqright">
                    <asp:Label ID="lbRegTime" runat="server"></asp:Label></td>
            </tr>
            <tr id="Tr31" runat="server">
                <td class="bqleft">
                    在线时长:</td>
                <td class="bqright">
                    <asp:Label ID="lbOnlineTime" runat="server"></asp:Label></td>
            </tr>
            <tr id="Tr32" runat="server">
                <td class="bqleft">
                    是否在线:</td>
                <td class="bqright">
                    <asp:Label ID="lbIsOnline" runat="server"></asp:Label></td>
            </tr>
            <tr id="Tr33" runat="server">
                <td class="bqleft">
                    登录次数:</td>
                <td class="bqright">
                    <asp:Label ID="lbLoginNum" runat="server"></asp:Label></td>
            </tr>
            <tr id="Tr34" runat="server">
                <td class="bqleft">
                    上次登录时间:</td>
                <td class="bqright">
                    <asp:Label ID="lbLastLogTime" runat="server"></asp:Label></td>
            </tr>
        </table>
        <table id="Tbody3" runat="server" align="center" cellpadding="0" cellspacing="1"
            class="editborder" style="display: none" width="99%">
            <tr id="Tr35" runat="server">
                <td class="bqleft">
                    企业名称:</td>
                <td class="bqright">
                    <asp:Label ID="lbCPName" runat="server"></asp:Label></td>
            </tr>
            <tr id="Tr36" runat="server">
                <td class="bqleft">
                    企业LOGO:</td>
                <td class="bqright">
                    <asp:Label ID="lbCPLogo" runat="server"></asp:Label></td>
            </tr>
            <tr id="Tr37" runat="server">
                <td class="bqleft">
                    企业类型:</td>
                <td class="bqright">
                    <asp:Label ID="lbCPType" runat="server"></asp:Label></td>
            </tr>
            <tr id="Tr38" runat="server">
                <td class="bqleft">
                    所属行业:</td>
                <td class="bqright">
                    <asp:Label ID="lbCPTrade" runat="server"></asp:Label></td>
            </tr>
            <tr id="Tr39" runat="server">
                <td class="bqleft">
                    联系人:</td>
                <td class="bqright">
                    <asp:Label ID="lbContact" runat="server"></asp:Label></td>
            </tr>
            <tr id="Tr40" runat="server">
                <td class="bqleft">
                    公司Email:</td>
                <td class="bqright">
                    <asp:Label ID="lbCNEmail" runat="server"></asp:Label></td>
            </tr>
            <tr id="Tr41" runat="server">
                <td class="bqleft">
                    传真:</td>
                <td class="bqright">
                    <asp:Label ID="lbFax" runat="server"></asp:Label></td>
            </tr>
            <tr id="Tr42" runat="server">
                <td class="bqleft">
                    公司地址:</td>
                <td class="bqright">
                    <asp:Label ID="lbCPAddress" runat="server"></asp:Label></td>
            </tr>
            <tr id="Tr43" runat="server">
                <td class="bqleft">
                    公司站点:</td>
                <td class="bqright">
                    <asp:Label ID="lbCPSite" runat="server"></asp:Label></td>
            </tr>
            <tr id="Tr44" runat="server">
                <td class="bqleft">
                    企业描述:</td>
                <td class="bqright">
                    <asp:Label ID="lbCPDescription" runat="server"></asp:Label></td>
            </tr>
            <tr id="Tr45" runat="server">
                <td class="bqleft">
                    公司规模:</td>
                <td class="bqright">
                    <asp:Label ID="lbCPSize" runat="server"></asp:Label></td>
            </tr>
            <tr id="Tr46" runat="server">
                <td class="bqleft">
                    企业法人:</td>
                <td class="bqright">
                    <asp:Label ID="lbCPPerson" runat="server"></asp:Label></td>
            </tr>
            <tr id="Tr47" runat="server">
                <td class="bqleft">
                    营业执照:</td>
                <td class="bqright">
                    <asp:Label ID="lbCPLicense" runat="server"></asp:Label></td>
            </tr>
        </table>
    </form>
    <asp:Literal ID="JS" runat="server"></asp:Literal>
</body>
</html>
