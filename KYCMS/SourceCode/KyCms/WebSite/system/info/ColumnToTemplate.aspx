<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ColumnToTemplate.aspx.cs"
    Inherits="system_info_ColumnToTemplate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>模板批量捆绑</title>
    <link href="../Css/default.css" type="text/css" rel="stylesheet" />

    <script src="../../JS/Common.js" type="text/javascript"></script>

    <script src="../../js/XmlHttp.js" type="text/javascript"></script>
    <script>
    function TargetUrl()
    {
        var id=$("ddlChannel").value;
        window.location.href="ColumnToTemplate.aspx?ChId="+id;
    }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <table width="99%" cellspacing="1" cellpadding="0" class="wzdh" align="center">
            <tr>
                <td width="20" height="24">
                    <img src="../images/skin/default/you.gif" width="17" height="16" /></td>
                <td align="left" style="padding-top: 3px;">
                    <a href="../SystemInfo.aspx">后台管理</a> &gt;&gt; <a href='ChannelList.aspx'>频道管理</a> &gt;&gt; [<asp:Literal ID="litNav"
                        runat="server"></asp:Literal>] 模板批量捆绑</td>
                <td width="50" align="right">
                    <img src="../images/skin/default/help.gif" align="absmiddle" /></td>
            </tr>
        </table>
        <br />
        <table width="99%" align="center" cellspacing="1" cellpadding="3" bgcolor="Gainsboro">
            <tr>
                <td colspan="3" align="left" bgcolor="#f5f5f5">快速选择频道：
                    <asp:DropDownList ID="ddlChannel" runat="server" onchange="TargetUrl()">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td bgcolor="white" width="40%">
                    <asp:ListBox ID="lsBoxColumn" runat="server" Width="100%" SelectionMode="Multiple" Height="280"
                        Rows="15"></asp:ListBox>
                </td>
                <td bgcolor="white" width="10%" align="center">
                    <strong>批<br />
                        量<br />
                        捆<br />
                        绑</strong></td>
                <td bgcolor="white" width="50%">
                    <table width="100%" cellpadding="2" cellspacing="0" border="0">
                        <tr>
                            <td width="20%">
                                栏目页模板：
                            </td>
                            <td width="80%">
                                <asp:TextBox ID="txtColumnTemplatePath" runat="server" Width="60%"></asp:TextBox>
                                <input type="button" value="选择模板" onclick="WinOpenDialog('../Common/SelectTemplate.aspx?ControlId='+escape('txtColumnTemplatePath')+'&StartPath='+escape('/Template'),650,480)"
                                    class="btn" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                内容页模板：
                            </td>
                            <td>
                                <asp:TextBox ID="txtInfoTemplatePath" runat="server" Width="60%"></asp:TextBox>
                                <input type="button" value="选择模板" onclick="WinOpenDialog('../Common/SelectTemplate.aspx?ControlId='+escape('txtInfoTemplatePath')+'&StartPath='+escape('/Template'),650,480)"
                                    class="btn" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                评论页模板：
                            </td>
                            <td>
                                <asp:TextBox ID="txtCommentTemplatePath" runat="server" Width="60%"></asp:TextBox>
                                <input type="button" value="选择模板" onclick="WinOpenDialog('../Common/SelectTemplate.aspx?ControlId='+escape('txtCommentTemplatePath')+'&StartPath='+escape('/Template'),650,480)"
                                    class="btn" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="3" bgcolor="white" height="25">
                    <b>注意：</b>按住"CTRL"键或者"shift"键可以对栏目进行批量选择。</td>
            </tr>
            <tr>
                <td colspan="3" bgcolor="white" height="30" align="center">
                    <asp:Button ID="btnSubmit" runat="server" Text=" 确定开始捆绑 " CssClass="btn" OnClick="btnSubmit_Click" />
                    &nbsp;&nbsp;
                    <input type="reset" name="Submit7" class="btn" value=" 重新设定 "></td>
            </tr>
        </table>
    </form>
</body>
</html>
