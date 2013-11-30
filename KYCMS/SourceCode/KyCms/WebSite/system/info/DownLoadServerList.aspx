<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DownLoadServerList.aspx.cs"
    Inherits="System_down_DownLoadServerList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>下载服务器名称列表管理</title>
    <link href="../Css/default.css" type="text/css" rel="stylesheet" />

    <script type="text/javascript" src="../../JS/Common.js"></script>

    <script type="text/javascript" src="../../js/XmlHttp.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <asp:Literal ID="litMsg" runat="server"></asp:Literal>
        <table width="99%" cellspacing="1" cellpadding="0" class="wzdh" align="center">
            <tr>
                <td width="27" height="24">
                    &nbsp;<img src="../images/skin/default/you.gif" width="17" height="16" /></td>
                <td>
                    您现在的位置：<a href="../SystemInfo.aspx">后台管理</a> >> 镜像服务器列表管理
                </td>
                <td width="116" align="center">
                    &nbsp;</td>
            </tr>
        </table>
        <table width="99%" cellspacing="1" cellpadding="0" class="border" align="center">
            <tr class="wzlist">
                <td align="left">
                    镜像服务器列表管理 | <a href="SetDownLoadServer.aspx">新增镜像服务器</a></td>
            </tr>
        </table>
        <table width="99%" align="center" class="border" cellspacing="1" cellpadding="0">
            <asp:Repeater ID="repServerType" runat="server" OnItemCommand="repServerType_ItemCommand"
                OnItemDataBound="repServerType_ItemDataBound">
                <HeaderTemplate>
                    <tr class="title">
                        <td align="center">
                            服务器名称</td>
                        <td align="center">
                            服务器地址</td>
                        <td align="center">
                            日下载</td>
                        <td align="center">
                            总下载</td>
                        <td align="center">
                            是否开启</td>
                        <td align="center">
                            添加时间</td>
                        <td align="center">
                            常规操作</td>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="tdbg" onmouseover="this.className='tdbgmouseover'" onmouseout="this.className='tdbg'">
                        <asp:Label runat="server" ID="lbID" Text='<%#Eval("TypeId")%>' Font-Bold="true" Visible="false"></asp:Label>
                        <td align="left">
                            <span style="color: Red">-</span>&nbsp; <strong>
                                <%#Eval("TypeName")%>
                            </strong>
                        </td>
                        <td align="center">
                        </td>
                        <td align="center">
                        </td>
                        <td align="center">
                        </td>
                        <td align="center">
                        </td>
                        <td align="center">
                        </td>
                        <td align="right">
                            <a href='SetDownLoadServer.aspx?TypeId=<%#Eval("TypeId") %>&Type=AddType'>添加下载服务器路径</a>
                            | <a href='SetDownLoadServer.aspx?TypeId=<%#Eval("TypeId") %>&Type=EditType'>服务器设置</a>
                            |
                            <asp:LinkButton runat="server" ID="btnDeleteType" CommandName="deleteType" OnClientClick='return confirm("你确定要删除所选择的类别吗？")'>删除</asp:LinkButton></td>
                    </tr>
                    <asp:Repeater runat="server" ID="repServerName" OnItemCommand="repServerName_ItemCommand">
                        <ItemTemplate>
                            <tr class="tdbg" onmouseover="this.className='tdbgmouseover'" onmouseout="this.className='tdbg'">
                                <asp:Label runat="server" ID="lbDownServerId" Text='<%#Eval("DownLoadServerDataId")%>' Visible="false"></asp:Label>
                                <td align="left">
                                    &nbsp;&nbsp;&nbsp;&nbsp;.├┈
                                    <%#Eval("DownLoadServerName")%>
                                </td>
                                <td align="left">
                                    <%#Eval("DownLoadServerDir")%>
                                </td>
                                <td align="center">
                                    <%#Eval("DayDownNum")%>
                                </td>
                                <td align="center">
                                    <%#Eval("AllDownNum")%>
                                </td>
                                <td align="center">
                                    <%#GetIsOpened(Eval("IsOpened"))%>
                                </td>
                                <td align="center">
                                    <%#Eval("AddTime","{0:yyyy-MM-dd}")%>
                                </td>
                                <td align="right">
                                    <asp:LinkButton ID="btnIsOpened" runat="server" Text='<%# GetBtnText(Eval("IsOpened")) %>'
                                        CommandName="state" />
                                    | <a href='SetDownLoadServer.aspx?TypeId=<%#Eval("TypeId") %>&ServerId=<%# Eval("DownLoadServerDataId")%>&Type=EditName'>
                                        服务器设置</a> |
                                    <asp:LinkButton runat="server" ID="btnDeleteData" CommandName="deleteData" OnClientClick="return confirm('你确定要删除此服务器吗？')">删除</asp:LinkButton></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </form>
</body>
</html>
