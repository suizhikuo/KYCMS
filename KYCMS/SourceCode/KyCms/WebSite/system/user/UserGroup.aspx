<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserGroup.aspx.cs" Inherits="system_user_UserGroup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="../css/default.css" type="text/css" rel="stylesheet">

    <script language="javascript" src="../../js/SystemUserPowerSelect.js"></script>

    <script language="javascript" src="../../js/Common.js"></script>

    <script language="JavaScript">
    function ShowTabs(id)
    {
        for(var i=0;i<3;i++)
        {
            var Div=eval("Tabs"+i);
            var Div_Tab=eval("Td"+i);
            if(id==i)
            {
                Div_Tab.className='title6';
                Div.style.display='';
            }
            else
            {
                Div.style.display='none';
                Div_Tab.className='title5';
            }
        }
    }
    
    function isok()
    {
        if($("UserGroupName").value=="")
        {
            alert("用户组名称不能够为空！")
            $("UserGroupName").focus();
            return false;
        }
        
        if(!AllUserGroup("Contribute_0"))
        {
            return false;
        }
        
        if(!AllUserGroup("Collection"))
        {
            return false;
        }
        
        
        if(!AllUserGroup("Invite"))
        {
            return false;
        }
        
        if(!AllUserGroup("IssueManuscript"))
        {
            return false;
        }
        
        if(!AllUserGroup("SmashMoney"))
        {
            return false;
        }
        
        return true;
    }  
    
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <table width="99%" cellspacing="1" cellpadding="0" class="wzdh" align="center">
            <tr>
                <td height="24" width="20">
                    <img src="../images/skin/default/you.gif" align="absmiddle" /></td>
                <td align="left" style="padding-top: 3px;">
                    您现在的位置：<a href="../SystemInfo.aspx">后台管理</a> >> 用户管理 >> 用户组管理</td>
                <td width="50" align="right">
                    <img src="../images/skin/default/help.gif" align="absmiddle" /></td>
            </tr>
        </table>
        <table width="99%" cellspacing="1" cellpadding="0" class="border" align="center">
            <tr class="wzlist">
                <td align="left">
                    <table cellpadding="2" cellspacing="0" border="0">
                        <tr>
                            <td>
                                <a href="GroupList.aspx">用户组管理首页</a></td>
                            <asp:Repeater ID="RepUserGroupModel" runat="server">
                                <ItemTemplate>
                                    <td>
                                        | <a href='UserGroup.aspx?TypeId=<%# Eval("Id") %>'>新增<%# Eval("Name") %></a></td>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <table cellspacing="0" cellpadding="0" width="99%" align="center" border="0" class="cd">
            <tr align="center">
                <td class="title6" id="Td0" onclick="ShowTabs(0)">
                    基本权限</td>
                <td class="title5" id="Td1" onclick="ShowTabs(1)">
                    财富空间</td>
                <td class="title5" id="Td2" onclick="ShowTabs(2)">
                    栏目权限</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        <!-- 菜单结束 -->
        <table width="99%" border="0" cellpadding="2" cellspacing="1" class="editborder"
            align="center">
            <!-- 基本权限 -->
            <tbody id="Tabs0">
                <tr>
                    <td class="bqleft">
                        <strong>用户组名称：</strong></td>
                    <td class="bqright">
                        <asp:TextBox ID="UserGroupName" runat="server"></asp:TextBox>
                        *</td>
                </tr>
                <tr>
                    <td class="bqleft">
                        <strong>用户组说明：</strong></td>
                    <td class="bqright">
                        <asp:TextBox ID="UserGroupContent" runat="server" Columns="40" Rows="6" TextMode="MultiLine"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="bqleft">
                        <strong>投稿权限：</strong></td>
                    <td class="bqright">
                        投稿时获取积分为栏目设置的<asp:TextBox ID="Contribute_0" runat="server" Columns="4" MaxLength="4"
                            onkeyup="value=value.replace(/[^\d]/g,'')">2</asp:TextBox>倍</td>
                </tr>
                <tr>
                    <td class="bqleft">
                        <strong>注册认证：</strong></td>
                    <td class="bqright">
                        <asp:RadioButtonList ID="Status" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Selected="True" Value="1">开放</asp:ListItem>
                            <asp:ListItem Value="0">认证</asp:ListItem>
                        </asp:RadioButtonList></td>
                </tr>
                <tr>
                    <td class="bqleft">
                        <strong>收藏夹权限：</strong></td>
                    <td class="bqright">
                        用户最多可收藏<asp:TextBox ID="Collection" runat="server" Columns="4" MaxLength="4" onkeyup="value=value.replace(/[^\d]/g,'')">0</asp:TextBox>条信息（如果为0，则没有收藏权限）</td>
                </tr>
            </tbody>
            <!-- 财富空间权限 -->
            <tbody id="Tabs1" style="display: none">
                <tr>
                    <td class="bqleft">
                        <strong>有效邀请：</strong></td>
                    <td class="bqright">
                        启用邀请机制后，一个有效邀请获取<asp:TextBox ID="Invite" runat="server" Columns="4" MaxLength="4"
                            onkeyup="value=value.replace(/[^\d]/g,'')">5</asp:TextBox>个积分</td>
                </tr>
                <tr>
                    <td class="bqleft">
                        <strong>发布稿件：</strong></td>
                    <td class="bqright">
                        启用用户投稿后，采纳一篇稿件获取<asp:TextBox ID="IssueManuscript" runat="server" Columns="4" MaxLength="4"
                            onkeyup="value=value.replace(/[^\d]/g,'')">5</asp:TextBox>个积分</td>
                </tr>
                <tr>
                    <td class="bqleft">
                        <strong>计费方式：</strong></td>
                    <td class="bqright">
                        <asp:RadioButtonList ID="ChargingType" runat="server">
                            <asp:ListItem Value="0" Selected="True">只判断金币</asp:ListItem>
                            <asp:ListItem Value="1">只判断有效期</asp:ListItem>
                            <asp:ListItem Value="2">条件判断金币和有效期</asp:ListItem>
                            <asp:ListItem Value="3">同时判断金币和有效期</asp:ListItem>
                        </asp:RadioButtonList></td>
                </tr>
                <tr>
                    <td class="bqleft">
                        <strong>扣金币方式：</strong></td>
                    <td class="bqright">
                        有效期内,每天最多可以看<asp:TextBox ID="SmashMoney" runat="server" Columns="4" MaxLength="4"
                            onkeyup="value=value.replace(/[^\d]/g,'')">0</asp:TextBox>条收费信息（如果为0，则不限制）
                    </td>
                </tr>
            </tbody>
            <!-- 频道权限 -->
            <tbody id="Tabs2" style="display: none">
                <tr>
                    <td class="bqleft">
                        <strong>频道管理：</strong></td>
                    <td class="qxright">
                        <table width="99%" border="0" cellpadding="0" cellspacing="1" class="qxborder" align="center">
                            <tr class="title">
                                <td align="left">
                                    中文名称<asp:TextBox ID="TableNum" runat="server" Style="display: none" Height="1px"
                                        Width="0px"></asp:TextBox></td>
                                <td>
                                    浏览</td>
                                <td>
                                    查看</td>
                                <td>
                                    录入</td>
                            </tr>
                            <asp:Repeater ID="Repeater1" runat="server">
                                <HeaderTemplate>
                                    <tr class="tdbg" onmouseover="this.className='tdbgmouseover'" onmouseout="this.className='tdbg'">
                                        <td align="left">
                                            <img src="../../images/+.gif" align="absmiddle" /><font color="red">所有频道</font></td>
                                        <td>
                                            <input type="checkbox" name="SelectAllChColColSpan1" onclick="SelectAllChColColSpan(1)"
                                                value="1"></td>
                                        <td>
                                            <input type="checkbox" name="SelectAllChColColSpan2" onclick="SelectAllChColColSpan(2)"
                                                value="1"></td>
                                        <td>
                                            <input type="checkbox" name="SelectAllChColColSpan3" onclick="SelectAllChColColSpan(3)"
                                                value="1"></td>
                                    </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr class="tdbg" onmouseover="this.className='tdbgmouseover'" onmouseout="this.className='tdbg'">
                                        <td align="left">
                                            <%# GetImgNum(int.Parse(DataBinder.Eval(Container, "DataItem.ChId", "{0}")), int.Parse(DataBinder.Eval(Container, "DataItem.ColId", "{0}")), int.Parse(DataBinder.Eval(Container, "DataItem.Depth", "{0}")))%>
                                            <%# Eval("Name") %>
                                        </td>
                                        <td>
                                            <asp:TextBox Text='<%# DataBinder.Eval(Container, "DataItem.ChId","{0}")%>' ID="ChId"
                                                runat="server" Columns="2" Style="display: none"></asp:TextBox><asp:TextBox ID="ColId"
                                                    runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ColId","{0}")%>'
                                                    Columns="2" Style="display: none"></asp:TextBox>
                                            <input id="ChIdColumnId_<%# Eval("TableNum") %>_1" name="ChIdColumnId_<%# Eval("TableNum") %>_1"
                                                onclick="SelectCancelUser('1','<%# Eval("TableNum") %>')" type="checkbox" value="1"></td>
                                        <td>
                                            <input type="checkbox" name='ChIdColumnId_<%# Eval("TableNum") %>_2' value="1" onclick="SelectCancelUser('2','<%# Eval("TableNum") %>')"></td>
                                        <td>
                                            <input type="checkbox" name="ChIdColumnId_<%# Eval("TableNum") %>_3" value="1" onclick="SelectCancelUser('3','<%# Eval("TableNum") %>')"></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                    </td>
                </tr>
            </tbody>
            <tr>
                <td height="29" colspan="2" align="center">
                    <span class="STYLE1">&nbsp;<asp:Button ID="Button1" runat="server" CssClass="btn"
                        Text=" 保存设置 " OnClick="Button1_Click" OnClientClick="return isok();" /></span></td>
            </tr>
        </table>
    </form>
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
</body>
</html>
