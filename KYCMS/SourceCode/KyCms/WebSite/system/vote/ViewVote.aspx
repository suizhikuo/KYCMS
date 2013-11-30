<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewVote.aspx.cs" Inherits="system_news_ViewVote" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>查看投票</title>
    <link href="../css/default.css" rel="Stylesheet" type="text/css" />
    <script src="../../js/Common.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table width="99%" cellspacing="1" cellpadding="0" class="wzdh" align="center">
                <tr>
                    <td height="24" width="20">
                        <img src="../images/skin/default/you.gif" align="absmiddle" /></td>
                    <td align="left" style="padding-top: 3px;">
                        您现在的位置：<a href="../SystemInfo.aspx">后台管理</a> >> <a href="Vote.aspx">投票管理</a> >>
                        查看投票详细信息</td>
                    <td width="50" align="right">
                        <img src="../images/skin/default/help.gif" align="absmiddle" alt="帮助" /></td>
                </tr>
            </table>
        </div>
        <table width="99%" cellspacing="1" cellpadding="0" class="border" align="center">
            <tr class="wzlist">
                <td>
                    <a href="Vote.aspx">所有投票</a> | <a href="SetVote.aspx">新增投票</a> | <a href="VoteCategory.aspx">
                        分类管理</a>
                </td>
            </tr>
        </table>
        <table cellpadding="0" cellspacing="1" class="border" style="width: 99%" align="center">
            <tr>
                <td class="title" colspan="2">
                    <asp:Label ID="lbTitle" runat="server" Font-Bold="True"></asp:Label>(共 <asp:Label ID="lbSum" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label> 票)
                </td>
            </tr>
        </table>
        <table id="Table0" cellpadding="0" cellspacing="1" class="border" style="width: 99%"
            align="center" runat="server">
            <tr>
                <td class="voteleft">
                    <b>投票主题一:</b></td>
                <td class="bqright">
                    <asp:Label ID="lbVoteTitle1" runat="server" Font-Bold="True"></asp:Label>
                    (<asp:Label ID="lbTotal1" runat="server" Font-Bold="True" ForeColor="#C00000"></asp:Label>票)</td>
            </tr>
            <tr id="tr11" runat="server">
                <td class="voteleft">
                    <asp:Label ID="lbItem11" runat="server"></asp:Label></td>
                <td class="bqright">
                    <table width="100%" cellpadding="2" cellspacing="0" border="0">
                        <tr>
                            <td width="400">
                                <table align="left" bgcolor="#767676" border="0" cellpadding="0" cellspacing="1"
                                    width="400px">
                                    <tr>
                                        <td bgcolor="#ffffff" style="height: 7px">
                                            <asp:Image ID="Image11" runat="server" /></td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <asp:Label ID="lbItem11num" runat="server" Font-Bold="True" ForeColor="#0000C0"></asp:Label>票<asp:Label
                                    ID="lbItemBFB11" runat="server"></asp:Label></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr id="tr12" runat="server">
                <td class="voteleft">
                    <asp:Label ID="lbItem12" runat="server"></asp:Label></td>
                <td class="bqright">
                    <table width="100%" cellpadding="2" cellspacing="0" border="0">
                        <tr>
                            <td width="400">
                                <table align="left" bgcolor="#767676" border="0" cellpadding="0" cellspacing="1"
                                    width="400px">
                                    <tr>
                                        <td bgcolor="#ffffff" style="height: 7px">
                                            <asp:Image ID="Image12" runat="server" /></td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <asp:Label ID="lbItem12num" runat="server" Font-Bold="True" ForeColor="#0000C0"></asp:Label>票<asp:Label
                                    ID="lbItemBFB12" runat="server"></asp:Label></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr id="tr13" runat="server">
                <td class="voteleft">
                    <asp:Label ID="lbItem13" runat="server"></asp:Label></td>
                <td class="bqright">
                    <table width="100%" cellpadding="2" cellspacing="0" border="0">
                        <tr>
                            <td width="400">
                                <table align="left" bgcolor="#767676" border="0" cellpadding="0" cellspacing="1"
                                    width="400px">
                                    <tr>
                                        <td bgcolor="#ffffff" style="height: 7px">
                                            <asp:Image ID="Image13" runat="server" /></td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <asp:Label ID="lbItem13num" runat="server" Font-Bold="True" ForeColor="#0000C0"></asp:Label>票<asp:Label
                                    ID="lbItemBFB13" runat="server"></asp:Label></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr id="tr14" runat="server">
                <td class="voteleft">
                    <asp:Label ID="lbItem14" runat="server"></asp:Label></td>
                <td class="bqright">
                    <table width="100%" cellpadding="2" cellspacing="0" border="0">
                        <tr>
                            <td width="400">
                                <table align="left" bgcolor="#767676" border="0" cellpadding="0" cellspacing="1"
                                    width="400px">
                                    <tr>
                                        <td bgcolor="#ffffff" style="height: 7px">
                                            <asp:Image ID="Image14" runat="server" /></td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <asp:Label ID="lbItem14num" runat="server" Font-Bold="True" ForeColor="#0000C0"></asp:Label>票<asp:Label
                                    ID="lbItemBFB14" runat="server"></asp:Label></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr id="tr15" runat="server">
                <td class="voteleft">
                    <asp:Label ID="lbItem15" runat="server"></asp:Label></td>
                <td class="bqright">
                    <table width="100%" cellpadding="2" cellspacing="0" border="0">
                        <tr>
                            <td width="400">
                                <table align="left" bgcolor="#767676" border="0" cellpadding="0" cellspacing="1"
                                    width="400px">
                                    <tr>
                                        <td bgcolor="#ffffff" style="height: 7px">
                                            <asp:Image ID="Image15" runat="server" /></td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <asp:Label ID="lbItem15num" runat="server" Font-Bold="True" ForeColor="#0000C0"></asp:Label>票<asp:Label
                                    ID="lbItemBFB15" runat="server"></asp:Label></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr id="tr16" runat="server">
                <td class="voteleft">
                    <asp:Label ID="lbItem16" runat="server"></asp:Label></td>
                <td class="bqright">
                    <table width="100%" cellpadding="2" cellspacing="0" border="0">
                        <tr>
                            <td width="400px">
                                <table align="left" bgcolor="#767676" border="0" cellpadding="0" cellspacing="1"
                                    width="400px">
                                    <tr>
                                        <td bgcolor="#ffffff" style="height: 7px">
                                            <asp:Image ID="Image16" runat="server" /></td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <asp:Label ID="lbItem16num" runat="server" Font-Bold="True" ForeColor="#0000C0"></asp:Label>票<asp:Label
                                    ID="lbItemBFB16" runat="server"></asp:Label></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <table id="Table1" cellpadding="0" cellspacing="1" class="border" style="width: 99%"
            align="center" runat="server">
            <tr>
                <td class="voteleft">
                    <b>投票主题二:</b></td>
                <td class="bqright">
                    <asp:Label ID="lbVoteTitle2" runat="server" Font-Bold="True"></asp:Label>
                    (<asp:Label ID="lbTotal2" runat="server" Font-Bold="True" ForeColor="#C00000"></asp:Label>票)</td>
            </tr>
            <tr id="tr21" runat="server">
                <td class="voteleft" bgcolor="green">
                    <asp:Label ID="lbItem21" runat="server"></asp:Label></td>
                <td class="bqright" height="24">
                    <table width="100%" cellpadding="2" cellspacing="0" border="0">
                        <tr>
                            <td width="400px">
                                <table align="left" bgcolor="#767676" border="0" cellpadding="0" cellspacing="1"
                                    width="400px">
                                    <tr>
                                        <td bgcolor="#ffffff" style="height: 7px">
                                            <asp:Image ID="Image21" runat="server" /></td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <asp:Label ID="lbItem21num" runat="server" Font-Bold="True" ForeColor="#0000C0"></asp:Label>票<asp:Label
                                    ID="lbItemBFB21" runat="server"></asp:Label></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr id="tr22" runat="server">
                <td class="voteleft">
                    <asp:Label ID="lbItem22" runat="server"></asp:Label></td>
                <td class="bqright">
                    <table width="100%" cellpadding="2" cellspacing="0" border="0">
                        <tr>
                            <td width="400px">
                                <table align="left" bgcolor="#767676" border="0" cellpadding="0" cellspacing="1"
                                    width="400px">
                                    <tr>
                                        <td bgcolor="#ffffff" style="height: 7px">
                                            <asp:Image ID="Image22" runat="server" /></td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <asp:Label ID="lbItem22num" runat="server" Font-Bold="True" ForeColor="#0000C0"></asp:Label>票<asp:Label
                                    ID="lbItemBFB22" runat="server"></asp:Label></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr id="tr23" runat="server">
                <td class="voteleft">
                    <asp:Label ID="lbItem23" runat="server"></asp:Label></td>
                <td class="bqright">
                    <table width="100%" cellpadding="2" cellspacing="0" border="0">
                        <tr>
                            <td width="400">
                                <table align="left" bgcolor="#767676" border="0" cellpadding="0" cellspacing="1"
                                    width="400px">
                                    <tr>
                                        <td bgcolor="#ffffff" style="height: 7px">
                                            <asp:Image ID="Image23" runat="server" /></td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <asp:Label ID="lbItem23num" runat="server" Font-Bold="True" ForeColor="#0000C0"></asp:Label>票<asp:Label
                                    ID="lbItemBFB23" runat="server"></asp:Label></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr id="tr24" runat="server">
                <td class="voteleft">
                    <asp:Label ID="lbItem24" runat="server"></asp:Label></td>
                <td class="bqright">
                    <table width="100%" cellpadding="2" cellspacing="0" border="0">
                        <tr>
                            <td width="400">
                                <table align="left" bgcolor="#767676" border="0" cellpadding="0" cellspacing="1"
                                    width="400px">
                                    <tr>
                                        <td bgcolor="#ffffff" style="height: 7px">
                                            <asp:Image ID="Image24" runat="server" /></td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <asp:Label ID="lbItem24num" runat="server" Font-Bold="True" ForeColor="#0000C0"></asp:Label>票<asp:Label
                                    ID="lbItemBFB24" runat="server"></asp:Label></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr id="tr25" runat="server">
                <td class="voteleft">
                    <asp:Label ID="lbItem25" runat="server"></asp:Label></td>
                <td class="bqright">
                    <table width="100%" cellpadding="2" cellspacing="0" border="0">
                        <tr>
                            <td width="400">
                                <table align="left" bgcolor="#767676" border="0" cellpadding="0" cellspacing="1"
                                    width="400px">
                                    <tr>
                                        <td bgcolor="#ffffff" style="height: 7px">
                                            <asp:Image ID="Image25" runat="server" /></td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <asp:Label ID="lbItem25num" runat="server" Font-Bold="True" ForeColor="#0000C0"></asp:Label>票<asp:Label
                                    ID="lbItemBFB25" runat="server"></asp:Label></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr id="tr26" runat="server">
                <td class="voteleft">
                    <asp:Label ID="lbItem26" runat="server"></asp:Label></td>
                <td class="bqright">
                    <table width="100%" cellpadding="2" cellspacing="0" border="0">
                        <tr>
                            <td width="400">
                                <table align="left" bgcolor="#767676" border="0" cellpadding="0" cellspacing="1"
                                    width="400px">
                                    <tr>
                                        <td bgcolor="#ffffff" style="height: 7px">
                                            <asp:Image ID="Image26" runat="server" /></td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <asp:Label ID="lbItem26num" runat="server" Font-Bold="True" ForeColor="#0000C0"></asp:Label>票<asp:Label
                                    ID="lbItemBFB26" runat="server"></asp:Label></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <table id="Table2" cellpadding="0" cellspacing="1" class="border" style="width: 99%"
            align="center" runat="server">
            <tr>
                <td class="voteleft">
                    <b>投票主题三:</b></td>
                <td class="bqright">
                    <asp:Label ID="lbVoteTitle3" runat="server" Font-Bold="True"></asp:Label>
                    (<asp:Label ID="lbTotal3" runat="server" Font-Bold="True" ForeColor="#C00000"></asp:Label>票)</td>
            </tr>
            <tr id="tr31" runat="server">
                <td class="voteleft">
                    <asp:Label ID="lbItem31" runat="server"></asp:Label></td>
                <td class="bqright">
                    <table width="100%" cellpadding="2" cellspacing="0" border="0">
                        <tr>
                            <td width="400">
                                <table align="left" bgcolor="#767676" border="0" cellpadding="0" cellspacing="1"
                                    width="400px">
                                    <tr>
                                        <td bgcolor="#ffffff" style="height: 7px">
                                            <asp:Image ID="Image31" runat="server" /></td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <asp:Label ID="lbItem31num" runat="server" Font-Bold="True" ForeColor="#0000C0"></asp:Label>票<asp:Label
                                    ID="lbItemBFB31" runat="server"></asp:Label></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr id="tr32" runat="server">
                <td class="voteleft">
                    <asp:Label ID="lbItem32" runat="server"></asp:Label></td>
                <td class="bqright">
                    <table width="100%" cellpadding="2" cellspacing="0" border="0">
                        <tr>
                            <td width="400">
                                <table align="left" bgcolor="#767676" border="0" cellpadding="0" cellspacing="1"
                                    width="400px">
                                    <tr>
                                        <td bgcolor="#ffffff" style="height: 7px">
                                            <asp:Image ID="Image32" runat="server" /></td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <asp:Label ID="lbItem32num" runat="server" Font-Bold="True" ForeColor="#0000C0"></asp:Label>票<asp:Label
                                    ID="lbItemBFB32" runat="server"></asp:Label></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr id="tr33" runat="server">
                <td class="voteleft">
                    <asp:Label ID="lbItem33" runat="server"></asp:Label></td>
                <td class="bqright">
                    <table width="100%" cellpadding="2" cellspacing="0" border="0">
                        <tr>
                            <td width="400">
                                <table align="left" bgcolor="#767676" border="0" cellpadding="0" cellspacing="1"
                                    width="400ox">
                                    <tr>
                                        <td bgcolor="#ffffff" style="height: 7px">
                                            <asp:Image ID="Image33" runat="server" /></td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <asp:Label ID="lbItem33num" runat="server" Font-Bold="True" ForeColor="#0000C0"></asp:Label>票<asp:Label
                                    ID="lbItemBFB33" runat="server"></asp:Label></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr id="tr34" runat="server">
                <td class="voteleft">
                    <asp:Label ID="lbItem34" runat="server"></asp:Label></td>
                <td class="bqright">
                    <table width="100%" cellpadding="2" cellspacing="0" border="0">
                        <tr>
                            <td width="400">
                                <table align="left" bgcolor="#767676" border="0" cellpadding="0" cellspacing="1"
                                    width="400px">
                                    <tr>
                                        <td bgcolor="#ffffff" style="height: 7px">
                                            <asp:Image ID="Image34" runat="server" /></td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <asp:Label ID="lbItem34num" runat="server" Font-Bold="True" ForeColor="#0000C0"></asp:Label>票<asp:Label
                                    ID="lbItemBFB34" runat="server"></asp:Label></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr id="tr35" runat="server">
                <td class="voteleft">
                    <asp:Label ID="lbItem35" runat="server"></asp:Label></td>
                <td class="bqright">
                    <table width="100%" cellpadding="2" cellspacing="0" border="0">
                        <tr>
                            <td width="400">
                                <table align="left" bgcolor="#767676" border="0" cellpadding="0" cellspacing="1"
                                    width="400px">
                                    <tr>
                                        <td bgcolor="#ffffff" style="height: 7px">
                                            <asp:Image ID="Image35" runat="server" /></td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <asp:Label ID="lbItem35num" runat="server" Font-Bold="True" ForeColor="#0000C0"></asp:Label>票<asp:Label
                                    ID="lbItemBFB35" runat="server"></asp:Label></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr id="tr36" runat="server">
                <td class="voteleft">
                    <asp:Label ID="lbItem36" runat="server"></asp:Label></td>
                <td class="bqright">
                    <table width="100%" cellpadding="2" cellspacing="0" border="0">
                        <tr>
                            <td width="400">
                                <table align="left" bgcolor="#767676" border="0" cellpadding="0" cellspacing="1"
                                    width="400px">
                                    <tr>
                                        <td bgcolor="#ffffff" style="height: 7px">
                                            <asp:Image ID="Image36" runat="server" /></td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <asp:Label ID="lbItem36num" runat="server" Font-Bold="True" ForeColor="#0000C0"></asp:Label>票<asp:Label
                                    ID="lbItemBFB36" runat="server"></asp:Label></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
