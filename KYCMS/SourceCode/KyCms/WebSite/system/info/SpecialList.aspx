<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SpecialList.aspx.cs" Inherits="System_website_Speacils" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>专题管理首页</title>
    <link href="../css/default.css" type="text/css" rel="Stylesheet" />

    <script src="../../js/Common.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
        <table width="99%" cellspacing="1" cellpadding="0" class="wzdh" align="center">
            <tr>
                <td height="24" width="20">
                    <img src="../images/skin/default/you.gif" align="absmiddle" /></td>
                <td align="left" style="padding-top: 3px;">
                    您现在的位置：<a href="../SystemInfo.aspx">后台管理</a> >> 专题管理 >> 专题管理</td>
                <td width="50" align="right">
                    <img src="../images/skin/default/help.gif" align="absmiddle" /></td>
            </tr>
        </table>
        <table width="99%" cellspacing="1" cellpadding="0" class="border" align="center">
            <tr class="wzlist">
                <td align="left">
                    <a href="SetSpecial.aspx">添加新专题</a></td>
            </tr>
        </table>
        <table width="99%" align="center" class="border" cellspacing="1" cellpadding="0">
            <asp:Repeater ID="rptSpeacils" runat="server" OnItemDataBound="rptSpeacils_ItemDataBound"
                OnItemCommand="rptSpeacils_ItemCommand">
                <HeaderTemplate>
                    <tr class="title">
                        <td>
                            中文名</td>
                        <td>
                            英文名</td>
                        <td>
                            所属频道</td>
                        <td>
                            二级域名</td>
                        <td>
                            属性</td>
                        <td>
                            添加日期</td>
                        <td>
                            常规操作</td>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="tdbg" style="text-align: center;" onmouseover="this.className='tdbgmouseover'"
                        onmouseout="this.className='tdbg'">
                        <td style="display: none">
                            <asp:Label ID="lbID" Text='<%#Eval("ID") %>' runat="server"></asp:Label>
                        </td>
                        <td style="text-align: left; padding-left: 5px;">
                            <%#IsLink(Eval("ID"),Eval("SpecialCName")) %>
                        </td>
                        <td>
                            <%#Eval("SpecialEName")%>
                        </td>
                        <td>
                            <asp:Literal ID="lbChName" runat="server" Text='<%#Eval("ChName")%>'></asp:Literal>
                        </td>
                        <td>
                            <%#Eval("SpecialDomain")%>
                        </td>
                        <td>
                            <%#Eval("Extension") %>
                            <asp:Literal ID="lbIscmd" runat="server" Text='<%# Eval("IsCommand") %>'></asp:Literal>
                            <asp:Literal ID="lbIslock" runat="server" Text='<%# Eval("IsLock") %>'></asp:Literal>
                        </td>
                        <td>
                            <%# Eval("SpecialAddTime","{0:d}") %>
                        </td>
                        <td>
                            <a href="../preview/PreSpecial.aspx?spid=<%#Eval("ID") %>" target="_blank">预览</a>
                            <a href='<%#ViewSpeacil(Eval("ID"))%>'>修改</a>
                            <asp:LinkButton ID="lnkbtnDelete" runat="server" CausesValidation="False" CommandName="Delete"
                                OnClientClick="return confirm('是否删除此专题及子专题到回收站?')" Text="删除"></asp:LinkButton>
                            <asp:LinkButton ID="lnkbtnCmd" runat="server" CausesValidation="false" CommandName="SetCmd"
                                Text="设为推荐"></asp:LinkButton>
                            <asp:LinkButton ID="lnkbtnDisable" runat="server" CausesValidation="false" CommandName="SetDisable"
                                Text="禁用"></asp:LinkButton>
                        </td>
                    </tr>
                    <asp:Repeater ID="rptChild" runat="server" OnItemCommand="rptChild_ItemCommand" OnItemDataBound="rptChild_ItemDataBound">
                        <ItemTemplate>
                            <tr class="tdbg" style="text-align: center;" onmouseover="this.className='tdbgmouseover'"
                                onmouseout="this.className='tdbg'">
                                <td style="display: none">
                                    <asp:Label ID="lbChildID" Text='<%#Eval("ID") %>' runat="server"></asp:Label>
                                </td>
                                <td style="text-align: left; padding-left: 5px;">
                                    <%# SetChild(Eval("SpecialCName"),Eval("ID"))%>
                                </td>
                                <td>
                                    <%#Eval("SpecialEName")%>
                                </td>
                                <td>
                                    <asp:Literal ID="lbChildChName" runat="server" Text='<%#Eval("ChName")%>'></asp:Literal>
                                </td>
                                <td>
                                    <%#Eval("SpecialDomain")%>
                                </td>
                                <td>
                                    <%#Eval("Extension") %>
                                    <asp:Literal ID="lbChildIscmd" runat="server" Text='<%# Eval("IsCommand") %>'></asp:Literal>
                                    <asp:Literal ID="lbChildIslock" runat="server" Text='<%# Eval("IsLock") %>'></asp:Literal>
                                </td>
                                <td>
                                    <%# Eval("SpecialAddTime","{0:d}") %>
                                </td>
                                <td>
                                    <a href="../preview/PreSpecial.aspx?spid=<%#Eval("ID") %>" target="_blank">预览</a> <a href='<%#ViewSpeacil(Eval("ID"))%>'>
                                        修改</a>
                                    <asp:LinkButton ID="lnkbtnDelete" runat="server" CausesValidation="False" CommandName="Delete"
                                        OnClientClick="return confirm('是否删除此专题到回收站?')" Text="删除"></asp:LinkButton>
                                    <asp:LinkButton ID="lnkbtnChildCmd" runat="server" CausesValidation="false" CommandName="ChildSetCmd"
                                        Text="设为推荐"></asp:LinkButton>
                                    <asp:LinkButton ID="lnkbtnChildDisable" runat="server" CausesValidation="false" CommandName="ChildSetDisable"
                                        Text="禁用"></asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </form>
</body>
</html>
