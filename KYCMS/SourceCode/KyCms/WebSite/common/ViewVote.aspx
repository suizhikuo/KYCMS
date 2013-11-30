<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewVote.aspx.cs" Inherits="common_ViewVote" EnableViewState="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>查看投票结果</title>
    <link href="../System/css/default.css" rel="Stylesheet" type="text/css" />

    <script src="../JS/Common.js " type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div style="text-align: center">
                <table style="width: 100%">
                    <tr>
                        <td style="text-align: left;">
                            <img src="../images/logo.gif" width="206" />&nbsp;</td>
                        <td>
                            </td>
                    </tr>
                </table>
                <table style="width: 100%">
                    <tr>
                        <td style="background-image: url(../images/vote_bg.gif); background-repeat: repeat-x">
                            <asp:Label ID="lbTitle" runat="server" Font-Bold="True"></asp:Label>
                            (共
                            <asp:Label ID="lbSum" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                            票)
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <br />
        <table id="Table0" cellpadding="0" cellspacing="0" class="border" style="width: 99%"
            align="center" runat="server">
            <tr>
                <td>
                    <table style="width: 100%">
                        <tr>
                            <td>
                                <img src="../images/vote_icon.gif" />
                                <asp:Label ID="lbVoteTitle1" runat="server" Font-Bold="True"></asp:Label>(<asp:Label
                                    ID="lbTotal1" runat="server" Font-Bold="True" ForeColor="#C00000"></asp:Label>票)</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table style="width: 100%" cellpadding="0" cellspacing="0">
                        <tr>
                            <td style="background-image: url(../images/vote_ft.gif); background-repeat: repeat-x">
                                <img src="../images/vote_f1.gif" /></td>
                            <td style="background-image: url(../images/vote_ft.gif); background-repeat: repeat-x">
                            </td>
                            <td style="background-image: url(../images/vote_ft.gif); background-repeat: repeat-x">
                            </td>
                            <td style="background-image: url(../images/vote_ft.gif); background-repeat: repeat-x">
                            </td>
                            <td style="background-image: url(../images/vote_ft.gif); background-repeat: repeat-x">
                            </td>
                            <td style="background-image: url(../images/vote_ft.gif); background-repeat: repeat-x">
                                <img src="../images/vote_f2.gif" /></td>
                        </tr>
                        <tr>
                            <td style="background-position-x: left; background-image: url(../images/vote_fl.gif);
                                width: 10px; background-repeat: repeat-y">
                            </td>
                            <td style="width: 50%; background-color: #cccccc;">
                                选项名称</td>
                            <td style="width: 15%; background-color: #cccccc;">
                                投票数</td>
                            <td style="width: 15%; background-color: #cccccc;">
                                百分比</td>
                            <td style="width: 20%; background-color: #cccccc;">
                            </td>
                            <td style="background-position-x: right; background-image: url(../images/vote_fr.gif);
                                background-repeat: repeat-y">
                            </td>
                        </tr>
                        <tr id="tr11" runat="server">
                            <td style="background-position-x: left; background-image: url(../images/vote_fl.gif);
                                width: 10px; background-repeat: repeat-y">
                            </td>
                            <td style="width: 50%">
                                <asp:Label ID="lbItem11" runat="server"></asp:Label></td>
                            <td style="width: 15%">
                                <asp:Label ID="lbItem11num" runat="server" Font-Bold="True" ForeColor="#0000C0"></asp:Label></td>
                            <td style="width: 15%">
                                <asp:Label ID="lbItemBFB11" runat="server"></asp:Label></td>
                            <td style="width: 20%">
                                <table align="left" bgcolor="#767676" border="0" cellpadding="0" cellspacing="1"
                                    width="100%">
                                    <tr>
                                        <td bgcolor="#ffffff" style="height: 7px">
                                            <asp:Image ID="Image11" runat="server" /></td>
                                    </tr>
                                </table>
                            </td>
                            <td style="background-position-x: right; background-image: url(../images/vote_fr.gif);
                                background-repeat: repeat-y">
                            </td>
                        </tr>
                        <tr id="tr12" runat="server">
                            <td style="background-position-x: left; background-image: url(../images/vote_fl.gif);
                                width: 10px; background-repeat: repeat-y">
                            </td>
                            <td style="width: 50%">
                                <asp:Label ID="lbItem12" runat="server"></asp:Label></td>
                            <td style="width: 15%">
                                <asp:Label ID="lbItem12num" runat="server" Font-Bold="True" ForeColor="#0000C0"></asp:Label></td>
                            <td style="width: 15%">
                                <asp:Label ID="lbItemBFB12" runat="server"></asp:Label></td>
                            <td style="width: 20%">
                                <table align="left" bgcolor="#767676" border="0" cellpadding="0" cellspacing="1"
                                    width="100%">
                                    <tr>
                                        <td bgcolor="#ffffff" style="height: 7px">
                                            <asp:Image ID="Image12" runat="server" /></td>
                                    </tr>
                                </table>
                            </td>
                            <td style="background-position-x: right; background-image: url(../images/vote_fr.gif);
                                background-repeat: repeat-y">
                            </td>
                        </tr>
                        <tr id="tr13" runat="server">
                            <td style="background-position-x: left; background-image: url(../images/vote_fl.gif);
                                width: 10px; background-repeat: repeat-y">
                            </td>
                            <td style="width: 50%">
                                <asp:Label ID="lbItem13" runat="server"></asp:Label></td>
                            <td style="width: 15%">
                                <asp:Label ID="lbItem13num" runat="server" Font-Bold="True" ForeColor="#0000C0"></asp:Label></td>
                            <td style="width: 15%">
                                <asp:Label ID="lbItemBFB13" runat="server"></asp:Label></td>
                            <td style="width: 20%">
                                <table align="left" bgcolor="#767676" border="0" cellpadding="0" cellspacing="1"
                                    width="100%">
                                    <tr>
                                        <td bgcolor="#ffffff" style="height: 7px">
                                            <asp:Image ID="Image13" runat="server" /></td>
                                    </tr>
                                </table>
                            </td>
                            <td style="background-position-x: right; background-image: url(../images/vote_fr.gif);
                                background-repeat: repeat-y">
                            </td>
                        </tr>
                        <tr id="tr14" runat="server">
                            <td style="background-position-x: left; background-image: url(../images/vote_fl.gif);
                                width: 10px; background-repeat: repeat-y">
                            </td>
                            <td style="width: 50%">
                                <asp:Label ID="lbItem14" runat="server"></asp:Label></td>
                            <td style="width: 15%">
                                <asp:Label ID="lbItem14num" runat="server" Font-Bold="True" ForeColor="#0000C0"></asp:Label></td>
                            <td style="width: 15%">
                                <asp:Label ID="lbItemBFB14" runat="server"></asp:Label></td>
                            <td style="width: 20%">
                                <table align="left" bgcolor="#767676" border="0" cellpadding="0" cellspacing="1"
                                    width="100%">
                                    <tr>
                                        <td bgcolor="#ffffff" style="height: 7px">
                                            <asp:Image ID="Image14" runat="server" /></td>
                                    </tr>
                                </table>
                            </td>
                            <td style="background-position-x: right; background-image: url(../images/vote_fr.gif);
                                background-repeat: repeat-y">
                            </td>
                        </tr>
                        <tr id="tr15" runat="server">
                            <td style="background-position-x: left; background-image: url(../images/vote_fl.gif);
                                width: 10px; background-repeat: repeat-y">
                            </td>
                            <td style="width: 50%">
                                <asp:Label ID="lbItem15" runat="server"></asp:Label></td>
                            <td style="width: 15%">
                                <asp:Label ID="lbItem15num" runat="server" Font-Bold="True" ForeColor="#0000C0"></asp:Label></td>
                            <td style="width: 15%">
                                <asp:Label ID="lbItemBFB15" runat="server"></asp:Label></td>
                            <td style="width: 20%">
                                <table align="left" bgcolor="#767676" border="0" cellpadding="0" cellspacing="1"
                                    width="100%">
                                    <tr>
                                        <td bgcolor="#ffffff" style="height: 7px">
                                            <asp:Image ID="Image15" runat="server" /></td>
                                    </tr>
                                </table>
                            </td>
                            <td style="background-position-x: right; background-image: url(../images/vote_fr.gif);
                                background-repeat: repeat-y">
                            </td>
                        </tr>
                        <tr id="tr16" runat="server">
                            <td style="background-position-x: left; background-image: url(../images/vote_fl.gif);
                                width: 10px; background-repeat: repeat-y">
                            </td>
                            <td style="width: 50%">
                                <asp:Label ID="lbItem16" runat="server"></asp:Label></td>
                            <td style="width: 15%">
                                <asp:Label ID="lbItem16num" runat="server" Font-Bold="True" ForeColor="#0000C0"></asp:Label></td>
                            <td style="width: 15%">
                                <asp:Label ID="lbItemBFB16" runat="server"></asp:Label></td>
                            <td style="width: 20%">
                                <table align="left" bgcolor="#767676" border="0" cellpadding="0" cellspacing="1"
                                    width="100%">
                                    <tr>
                                        <td bgcolor="#ffffff" style="height: 7px">
                                            <asp:Image ID="Image16" runat="server" /></td>
                                    </tr>
                                </table>
                            </td>
                            <td style="background-position-x: right; background-image: url(../images/vote_fr.gif);
                                background-repeat: repeat-y">
                            </td>
                        </tr>
                        <tr id="Tr1" runat="server">
                            <td style="background-image: url(../images/vote_fb.gif); background-repeat: repeat-x">
                                <img src="../images/vote_f4.gif" /></td>
                            <td style="background-image: url(../images/vote_fb.gif); background-repeat: repeat-x">
                            </td>
                            <td style="background-image: url(../images/vote_fb.gif); background-repeat: repeat-x">
                            </td>
                            <td style="background-image: url(../images/vote_fb.gif); background-repeat: repeat-x">
                            </td>
                            <td style="background-image: url(../images/vote_fb.gif); background-repeat: repeat-x">
                            </td>
                            <td style="background-image: url(../images/vote_fb.gif); background-repeat: repeat-x">
                                <img src="../images/vote_f3.gif" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <br />
        <table id="Table1" cellpadding="0" cellspacing="0" class="border" style="width: 99%"
            align="center" runat="server">
            <tr>
                <td>
                    <table style="width: 100%">
                        <tr>
                            <td>
                                <img src="../images/vote_icon.gif" />
                                <asp:Label ID="lbVoteTitle2" runat="server" Font-Bold="True"></asp:Label>(<asp:Label
                                    ID="lbTotal2" runat="server" Font-Bold="True" ForeColor="#C00000"></asp:Label>票)</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table style="width: 100%" cellpadding="0" cellspacing="0">
                        <tr>
                            <td style="background-image: url(../images/vote_ft.gif); background-repeat: repeat-x">
                                <img src="../images/vote_f1.gif" /></td>
                            <td style="background-image: url(../images/vote_ft.gif); background-repeat: repeat-x">
                            </td>
                            <td style="background-image: url(../images/vote_ft.gif); background-repeat: repeat-x">
                            </td>
                            <td style="background-image: url(../images/vote_ft.gif); background-repeat: repeat-x">
                            </td>
                            <td style="background-image: url(../images/vote_ft.gif); background-repeat: repeat-x">
                            </td>
                            <td>
                                <img src="../images/vote_f2.gif" /></td>
                        </tr>
                        <tr>
                            <td style="background-position-x: left; background-image: url(../images/vote_fl.gif);
                                background-repeat: repeat-y">
                            </td>
                            <td style="width: 50%; background-color: #cccccc">
                                选项名称</td>
                            <td style="width: 15%; background-color: #cccccc;">
                                投票数</td>
                            <td style="width: 15%; background-color: #cccccc;">
                                百分比</td>
                            <td style="width: 100px; background-color: #cccccc;">
                            </td>
                            <td style="background-position-x: right; background-image: url(../images/vote_fr.gif);
                                width: 13px; background-repeat: repeat-y">
                            </td>
                        </tr>
                        <tr id="tr21" runat="server">
                            <td style="background-position-x: left; background-image: url(../images/vote_fl.gif);
                                background-repeat: repeat-y">
                            </td>
                            <td style="width: 50%">
                                <asp:Label ID="lbItem21" runat="server"></asp:Label></td>
                            <td style="width: 15%">
                                <asp:Label ID="lbItem21num" runat="server" Font-Bold="True" ForeColor="#0000C0"></asp:Label></td>
                            <td style="width: 15%">
                                <asp:Label ID="lbItemBFB21" runat="server"></asp:Label></td>
                            <td style="width: 20%">
                                <table align="left" bgcolor="#767676" border="0" cellpadding="0" cellspacing="1"
                                    width="100%">
                                    <tr>
                                        <td bgcolor="#ffffff" style="height: 7px">
                                            <asp:Image ID="Image21" runat="server" /></td>
                                    </tr>
                                </table>
                            </td>
                            <td style="background-position-x: right; background-image: url(../images/vote_fr.gif);
                                width: 13px; background-repeat: repeat-y">
                            </td>
                        </tr>
                        <tr id="tr22" runat="server">
                            <td style="background-position-x: left; background-image: url(../images/vote_fl.gif);
                                background-repeat: repeat-y">
                            </td>
                            <td style="width: 50%">
                                <asp:Label ID="lbItem22" runat="server"></asp:Label></td>
                            <td style="width: 15%">
                                <asp:Label ID="lbItem22num" runat="server" Font-Bold="True" ForeColor="#0000C0"></asp:Label></td>
                            <td style="width: 15%">
                                <asp:Label ID="lbItemBFB22" runat="server"></asp:Label></td>
                            <td style="width: 20%">
                                <table align="left" bgcolor="#767676" border="0" cellpadding="0" cellspacing="1"
                                    width="100%">
                                    <tr>
                                        <td bgcolor="#ffffff" style="height: 7px">
                                            <asp:Image ID="Image22" runat="server" /></td>
                                    </tr>
                                </table>
                            </td>
                            <td style="background-position-x: right; background-image: url(../images/vote_fr.gif);
                                width: 13px; background-repeat: repeat-y">
                            </td>
                        </tr>
                        <tr id="tr23" runat="server">
                            <td style="background-position-x: left; background-image: url(../images/vote_fl.gif);
                                background-repeat: repeat-y">
                            </td>
                            <td style="width: 50%">
                                <asp:Label ID="lbItem23" runat="server"></asp:Label></td>
                            <td style="width: 15%">
                                <asp:Label ID="lbItem23num" runat="server" Font-Bold="True" ForeColor="#0000C0"></asp:Label></td>
                            <td style="width: 15%">
                                <asp:Label ID="lbItemBFB23" runat="server"></asp:Label></td>
                            <td style="width: 20%">
                                <table align="left" bgcolor="#767676" border="0" cellpadding="0" cellspacing="1"
                                    width="100%">
                                    <tr>
                                        <td bgcolor="#ffffff" style="height: 7px">
                                            <asp:Image ID="Image23" runat="server" /></td>
                                    </tr>
                                </table>
                            </td>
                            <td style="background-position-x: right; background-image: url(../images/vote_fr.gif);
                                width: 13px; background-repeat: repeat-y">
                            </td>
                        </tr>
                        <tr id="tr24" runat="server">
                            <td style="background-position-x: left; background-image: url(../images/vote_fl.gif);
                                background-repeat: repeat-y">
                            </td>
                            <td style="width: 50%">
                                <asp:Label ID="lbItem24" runat="server"></asp:Label></td>
                            <td style="width: 15%">
                                <asp:Label ID="lbItem24num" runat="server" Font-Bold="True" ForeColor="#0000C0"></asp:Label></td>
                            <td style="width: 15%">
                                <asp:Label ID="lbItemBFB24" runat="server"></asp:Label></td>
                            <td style="width: 20%">
                                <table align="left" bgcolor="#767676" border="0" cellpadding="0" cellspacing="1"
                                    width="100%">
                                    <tr>
                                        <td bgcolor="#ffffff" style="height: 7px">
                                            <asp:Image ID="Image24" runat="server" /></td>
                                    </tr>
                                </table>
                            </td>
                            <td style="background-position-x: right; background-image: url(../images/vote_fr.gif);
                                width: 13px; background-repeat: repeat-y">
                            </td>
                        </tr>
                        <tr id="tr25" runat="server">
                            <td style="background-position-x: left; background-image: url(../images/vote_fl.gif);
                                background-repeat: repeat-y">
                            </td>
                            <td style="width: 50%">
                                <asp:Label ID="lbItem25" runat="server"></asp:Label></td>
                            <td style="width: 15%">
                                <asp:Label ID="lbItem25num" runat="server" Font-Bold="True" ForeColor="#0000C0"></asp:Label></td>
                            <td style="width: 15%">
                                <asp:Label ID="lbItemBFB25" runat="server"></asp:Label></td>
                            <td style="width: 20%">
                                <table align="left" bgcolor="#767676" border="0" cellpadding="0" cellspacing="1"
                                    width="100%">
                                    <tr>
                                        <td bgcolor="#ffffff" style="height: 7px">
                                            <asp:Image ID="Image25" runat="server" /></td>
                                    </tr>
                                </table>
                            </td>
                            <td style="background-position-x: right; background-image: url(../images/vote_fr.gif);
                                width: 13px; background-repeat: repeat-y">
                            </td>
                        </tr>
                        <tr id="tr26" runat="server">
                            <td style="background-position-x: left; background-image: url(../images/vote_fl.gif);
                                background-repeat: repeat-y">
                            </td>
                            <td style="width: 50%">
                                <asp:Label ID="lbItem26" runat="server"></asp:Label></td>
                            <td style="width: 15%">
                                <asp:Label ID="lbItem26num" runat="server" Font-Bold="True" ForeColor="#0000C0"></asp:Label></td>
                            <td style="width: 15%">
                                <asp:Label ID="lbItemBFB26" runat="server"></asp:Label></td>
                            <td style="width: 20%">
                                <table align="left" bgcolor="#767676" border="0" cellpadding="0" cellspacing="1"
                                    width="100%">
                                    <tr>
                                        <td bgcolor="#ffffff" style="height: 7px">
                                            <asp:Image ID="Image26" runat="server" /></td>
                                    </tr>
                                </table>
                            </td>
                            <td style="background-position-x: right; background-image: url(../images/vote_fr.gif);
                                width: 13px; background-repeat: repeat-y">
                            </td>
                        </tr>
                        <tr runat="server" id="Tr2">
                            <td colspan="1" style="background-image: url(../images/vote_fb.gif); background-repeat: repeat-x">
                                <img src="../images/vote_f4.gif" /></td>
                            <td colspan="1" style="background-image: url(../images/vote_fb.gif); background-repeat: repeat-x">
                            </td>
                            <td colspan="1" style="background-image: url(../images/vote_fb.gif); background-repeat: repeat-x">
                                </td>
                            <td style="width: 100px; background-image: url(../images/vote_fb.gif); background-repeat: repeat-x;">
                            </td>
                            <td style="width: 100px; background-image: url(../images/vote_fb.gif); background-repeat: repeat-x;">
                            </td>
                            <td style="background-image: url(../images/vote_fb.gif); width: 100px; background-repeat: repeat-x">
                                <img src="../images/vote_f3.gif" /></td>
                            <td align="right" style="background-image: url(../images/vote_fb.gif); background-repeat: repeat-x">
                                </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <br />
        <table id="Table2" cellpadding="0" cellspacing="0" class="border" style="width: 99%"
            align="center" runat="server">
            <tr>
                <td>
                    <table style="width: 100%">
                        <tr>
                            <td>
                                <img src="../images/vote_icon.gif" />
                                <asp:Label ID="lbVoteTitle3" runat="server" Font-Bold="True"></asp:Label>(<asp:Label
                                    ID="lbTotal3" runat="server" Font-Bold="True" ForeColor="#C00000"></asp:Label>票)</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table style="width: 100%" cellpadding="0" cellspacing="0">
                        <tr>
                            <td style="background-image: url(../images/vote_ft.gif); background-repeat: repeat-x">
                                <img src="../images/vote_f1.gif" /></td>
                            <td style="background-image: url(../images/vote_ft.gif); background-repeat: repeat-x">
                            </td>
                            <td style="background-image: url(../images/vote_ft.gif); background-repeat: repeat-x">
                            </td>
                            <td style="background-image: url(../images/vote_ft.gif); background-repeat: repeat-x">
                            </td>
                            <td style="background-image: url(../images/vote_ft.gif); background-repeat: repeat-x">
                            </td>
                            <td style="background-image: url(../images/vote_ft.gif); background-repeat: repeat-x">
                                <img src="../images/vote_f2.gif" /></td>
                        </tr>
                        <tr>
                            <td style="width: 10px; background-position-x: left; background-image: url(../images/vote_fl.gif); background-repeat: repeat-y;">
                            </td>
                            <td style="width: 50%; background-color: #cccccc;">
                                选项名称</td>
                            <td style="width: 15%; background-color: #cccccc;">
                                投票数</td>
                            <td style="width: 15%; background-color: #cccccc;">
                                百分比</td>
                            <td style="width: 100px; background-color: #cccccc;">
                            </td>
                            <td style="background-position-x: right; background-image: url(../images/vote_fr.gif);
                                background-repeat: repeat-y">
                            </td>
                        </tr>
                        <tr id="tr31" runat="server">
                            <td style="background-position-x: left; background-image: url(../images/vote_fl.gif);
                                width: 10px; background-repeat: repeat-y">
                            </td>
                            <td style="width: 50%">
                                <asp:Label ID="lbItem31" runat="server"></asp:Label></td>
                            <td style="width: 15%">
                                <asp:Label ID="lbItem31num" runat="server" Font-Bold="True" ForeColor="#0000C0"></asp:Label></td>
                            <td style="width: 15%">
                                <asp:Label ID="lbItemBFB31" runat="server"></asp:Label></td>
                            <td style="width: 20%">
                                <table align="left" bgcolor="#767676" border="0" cellpadding="0" cellspacing="1"
                                    width="100%">
                                    <tr>
                                        <td bgcolor="#ffffff" style="height: 7px">
                                            <asp:Image ID="Image31" runat="server" /></td>
                                    </tr>
                                </table>
                            </td>
                            <td style="background-position-x: right; background-image: url(../images/vote_fr.gif);
                                background-repeat: repeat-y">
                            </td>
                        </tr>
                        <tr id="tr32" runat="server">
                            <td style="background-position-x: left; background-image: url(../images/vote_fl.gif);
                                width: 10px; background-repeat: repeat-y">
                            </td>
                            <td style="width: 50%">
                                <asp:Label ID="lbItem32" runat="server"></asp:Label></td>
                            <td style="width: 15%">
                                <asp:Label ID="lbItem32num" runat="server" Font-Bold="True" ForeColor="#0000C0"></asp:Label></td>
                            <td style="width: 15%">
                                <asp:Label ID="lbItemBFB32" runat="server"></asp:Label></td>
                            <td style="width: 20%">
                                <table align="left" bgcolor="#767676" border="0" cellpadding="0" cellspacing="1"
                                    width="100%">
                                    <tr>
                                        <td bgcolor="#ffffff" style="height: 7px">
                                            <asp:Image ID="Image32" runat="server" /></td>
                                    </tr>
                                </table>
                            </td>
                            <td style="background-position-x: right; background-image: url(../images/vote_fr.gif);
                                background-repeat: repeat-y">
                            </td>
                        </tr>
                        <tr id="tr33" runat="server">
                            <td style="background-position-x: left; background-image: url(../images/vote_fl.gif);
                                width: 10px; background-repeat: repeat-y">
                            </td>
                            <td style="width: 50%">
                                <asp:Label ID="lbItem33" runat="server"></asp:Label></td>
                            <td style="width: 15%">
                                <asp:Label ID="lbItem33num" runat="server" Font-Bold="True" ForeColor="#0000C0"></asp:Label></td>
                            <td style="width: 15%">
                                <asp:Label ID="lbItemBFB33" runat="server"></asp:Label></td>
                            <td style="width: 20%">
                                <table align="left" bgcolor="#767676" border="0" cellpadding="0" cellspacing="1"
                                    width="100%">
                                    <tr>
                                        <td bgcolor="#ffffff" style="height: 7px">
                                            <asp:Image ID="Image33" runat="server" /></td>
                                    </tr>
                                </table>
                            </td>
                            <td style="background-position-x: right; background-image: url(../images/vote_fr.gif);
                                background-repeat: repeat-y">
                            </td>
                        </tr>
                        <tr id="tr34" runat="server">
                            <td style="background-position-x: left; background-image: url(../images/vote_fl.gif);
                                width: 10px; background-repeat: repeat-y">
                            </td>
                            <td style="width: 50%">
                                <asp:Label ID="lbItem34" runat="server"></asp:Label></td>
                            <td style="width: 15%">
                                <asp:Label ID="lbItem34num" runat="server" Font-Bold="True" ForeColor="#0000C0"></asp:Label></td>
                            <td style="width: 15%">
                                <asp:Label ID="lbItemBFB34" runat="server"></asp:Label></td>
                            <td style="width: 20%">
                                <table align="left" bgcolor="#767676" border="0" cellpadding="0" cellspacing="1"
                                    width="100%">
                                    <tr>
                                        <td bgcolor="#ffffff" style="height: 7px">
                                            <asp:Image ID="Image34" runat="server" /></td>
                                    </tr>
                                </table>
                            </td>
                            <td style="background-position-x: right; background-image: url(../images/vote_fr.gif);
                                background-repeat: repeat-y">
                            </td>
                        </tr>
                        <tr id="tr35" runat="server">
                            <td style="background-position-x: left; background-image: url(../images/vote_fl.gif);
                                width: 10px; background-repeat: repeat-y">
                            </td>
                            <td style="width: 50%">
                                <asp:Label ID="lbItem35" runat="server"></asp:Label></td>
                            <td style="width: 15%">
                                <asp:Label ID="lbItem35num" runat="server" Font-Bold="True" ForeColor="#0000C0"></asp:Label></td>
                            <td style="width: 15%">
                                <asp:Label ID="lbItemBFB35" runat="server"></asp:Label></td>
                            <td style="width: 20%">
                                <table align="left" bgcolor="#767676" border="0" cellpadding="0" cellspacing="1"
                                    width="100%">
                                    <tr>
                                        <td bgcolor="#ffffff" style="height: 7px">
                                            <asp:Image ID="Image35" runat="server" /></td>
                                    </tr>
                                </table>
                            </td>
                            <td style="background-position-x: right; background-image: url(../images/vote_fr.gif);
                                background-repeat: repeat-y">
                            </td>
                        </tr>
                        <tr id="tr36" runat="server">
                            <td style="background-position-x: left; background-image: url(../images/vote_fl.gif);
                                width: 10px; background-repeat: repeat-y">
                            </td>
                            <td style="width: 50%">
                                <asp:Label ID="lbItem36" runat="server"></asp:Label></td>
                            <td style="width: 15%">
                                <asp:Label ID="lbItem36num" runat="server" Font-Bold="True" ForeColor="#0000C0"></asp:Label></td>
                            <td style="width: 15%">
                                <asp:Label ID="lbItemBFB36" runat="server"></asp:Label></td>
                            <td style="width: 20%">
                                <table align="left" bgcolor="#767676" border="0" cellpadding="0" cellspacing="1"
                                    width="100%">
                                    <tr>
                                        <td bgcolor="#ffffff" style="height: 7px">
                                            <asp:Image ID="Image36" runat="server" /></td>
                                    </tr>
                                </table>
                            </td>
                            <td style="background-position-x: right; background-image: url(../images/vote_fr.gif);
                                background-repeat: repeat-y">
                            </td>
                        </tr>
                        <tr id="Tr3" runat="server">
                            <td style="background-image: url(../images/vote_fb.gif); background-repeat: repeat-x">
                                <img src="../images/vote_f4.gif" /></td>
                            <td style="background-image: url(../images/vote_fb.gif); background-repeat: repeat-x">
                            </td>
                            <td style="background-image: url(../images/vote_fb.gif); background-repeat: repeat-x">
                            </td>
                            <td style="background-image: url(../images/vote_fb.gif); background-repeat: repeat-x">
                            </td>
                            <td style="background-image: url(../images/vote_fb.gif); background-repeat: repeat-x">
                            </td>
                            <td style="background-image: url(../images/vote_fb.gif); background-repeat: repeat-x">
                                <img src="../images/vote_f3.gif" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
    <asp:Literal ID="LitMsg" runat="server"></asp:Literal>
</body>
</html>
