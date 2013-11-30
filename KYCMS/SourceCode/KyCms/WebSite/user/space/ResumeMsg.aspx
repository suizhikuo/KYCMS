<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ResumeMsg.aspx.cs" Inherits="user_space_ResumeMsg" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<link href="../Css/default.css" type="text/css" rel="stylesheet" />

<script type="text/javascript" src="../../JS/Common.js"></script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>留言管理</title>
</head>
<body>
    <form id="form1" runat="server">
        <table width="99%" cellspacing="1" cellpadding="0" class="wzdh" align="center">
            <tr>
                <td width="27">
                    <img src="../images/skin/default/you.gif" width="17" height="16"></td>
                <td>
                    您现在的位置： <a href="../welcome.aspx">用户后台</a> &gt;&gt; <a href="MessageManage.aspx">留言管理</a>
                    &gt;&gt; <asp:Label ID="lbNav" runat="server" Text="查看/回复留言"></asp:Label>
                </td>
            </tr>
        </table>
        <div style="margin-left: 4px; width: 650px;" class="border">
            <div class="title">
                查 看/回 复 留 言</div>
            <table align="center" cellpadding="0" cellspacing="1" class="border" style="width: 100%">
                <tr bgcolor='eef6fb'>
                    <td class="bqleft">
                        留言标题：</td>
                    <td class="bqright">
                        <asp:Label ID="lbTitle" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr bgcolor='eef6fb'>
                    <td class="bqleft">
                        留言内容：</td>
                    <td class="bqright">
                        <asp:TextBox ID="txtContent" runat="server" Height="98px" ReadOnly="True" TextMode="MultiLine" style="word-break:break-all;"
                            Width="100%"></asp:TextBox>
                    </td>
                </tr>
                <tr bgcolor='eef6fb' style="color:#F00">
                    <td class="bqleft">
                        回复内容：</td>
                    <td class="bqright">
                        <asp:TextBox ID="txtResumeContent" runat="server" Height="98px" TextMode="MultiLine" style="word-break:break-all;"
                            Width="100%"></asp:TextBox></td>
                </tr>
               <tr bgcolor='eef6fb'>
                     <td class="bqright">
                        </td>
                    <td class="bqright"><asp:Button ID="btnOK" runat="server" Text="提 交" CssClass="btn" OnClick="btnOK_Click" />
                        <input id="Button1" type="button" value="取 消" onclick ="javascript:history.back()" class="btn">
                     </td>
                </tr> 

            </table>
            
        </div>
        <asp:Literal ID="litMsg" runat="server"></asp:Literal>
    </form>
</body>
</html>
