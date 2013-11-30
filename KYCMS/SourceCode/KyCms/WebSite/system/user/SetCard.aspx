<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SetCard.aspx.cs" Inherits="System_user_AddCard" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>添加用户卡</title>
    <link href="../css/default.css" type="text/css" rel="Stylesheet" />

    <script type="text/javascript" src="../../js/Common.js"></script>

    <script type="text/javascript" src="../../js/RiQi.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <table align="center" cellpadding="0" cellspacing="1" class="wzdh" width="99%">
            <tr>
                <td height="24" width="20">
                    <img align="absMiddle" src="../images/skin/default/you.gif" /></td>
                <td align="left" style="padding-top: 3px">
                    您现在的位置：<a href="../SystemInfo.aspx">后台管理</a> &gt;&gt; <a href="../other/NoticeList.aspx">用户管理</a> &gt;&gt; <a href="card.aspx">充值卡管理</a> &gt;&gt;
                    添加新卡</td>
                <td align="right" width="50">
                    <img align="absMiddle" src="../images/skin/default/help.gif" /></td>
            </tr>
        </table>
        <table cellpadding="0" cellspacing="0" class="border" style="width: 99%" align="center">
            <tr>
                <td class="wzlist">
                    <a href="Card.aspx">查看卡列表</a> |
                    <asp:LinkButton ID="lnkbtnAdd" runat="server" OnClick="btnAddm_Click" CausesValidation="False">添加新卡</asp:LinkButton>
                    |
                    <asp:LinkButton ID="lnkbtnMore" runat="server" CausesValidation="False" OnClick="lnkbtnMore_Click">批量添加</asp:LinkButton></td>
            </tr>
        </table>
        <asp:MultiView ID="mvAddCard" runat="server">
            <asp:View ID="vSet" runat="server">
                <table cellpadding="0" cellspacing="1" class="border" style="width: 99%" align="center">
                    <tr>
                        <td class="title" colspan="2">
                            添加新卡</td>
                    </tr>
                    <tr>
                        <td class="bqleft">
                            卡类型：</td>
                        <td class="bqright">
                            <asp:DropDownList ID="ddlCardType" runat="server" onchange="SetCard(1);">
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td class="bqleft">
                            帐号前缀：</td>
                        <td class="bqright">
                            <asp:TextBox ID="txtCardPrifix" runat="server" MaxLength="10">KYCMS#$@</asp:TextBox>
                            <span class="tips">一个@代表一个字母,一个#代表一个数字,一个$代表一个字数或字母.其余符号将被视为本意.</span></td>
                    </tr>
                    <tr>
                        <td class="bqleft">
                            密码：</td>
                        <td class="bqright">
                            <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPassword"
                                ErrorMessage="*请输入密码"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr id="Trpoint">
                        <td class="bqleft">
                            点数：</td>
                        <td class="bqright">
                            <asp:TextBox ID="txtPoint" runat="server">30</asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*点数不正确"
                                ControlToValidate="txtPoint" Display="Dynamic" ValidationExpression="^\d+$"></asp:RegularExpressionValidator><asp:RequiredFieldValidator
                                    ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPoint" Display="Dynamic"
                                    ErrorMessage="*请输入点数"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr id="Trday" style="display:none">
                        <td class="bqleft">
                            天数：</td>
                        <td class="bqright">
                            <asp:TextBox ID="txtDay" runat="server">30</asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="*天数不正确"
                                ControlToValidate="txtDay" Display="Dynamic" ValidationExpression="^\d+$"></asp:RegularExpressionValidator><asp:RequiredFieldValidator
                                    ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDay" Display="Dynamic"
                                    ErrorMessage="*请输入天数"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td class="bqleft">
                            过期日期：</td>
                        <td class="bqright">
                            <asp:TextBox ID="txtOverdueDate" runat="server" onblur="setday(this);" onclick="setday(this);"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="bqleft">
                        </td>
                        <td class="bqright">
                            <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="添加" CssClass="btn" />&nbsp;
                            <input id="Reset1" type="reset"  value="取消" onclick="javascript:history.back();"  class="btn" />
                        </td>
                    </tr>
                </table>
            </asp:View>
            <asp:View ID="vResult" runat="server">
                <table cellpadding="0" cellspacing="1" class="border" style="width: 99%" align="center">
                    <tr>
                        <td class="title" colspan="2">
                            添加成功</td>
                    </tr>
                    <tr>
                        <td class="bqleft">
                            类型：</td>
                        <td class="bqright">
                            <asp:Label ID="lbType" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="bqleft">
                            卡号：</td>
                        <td class="bqright">
                            <asp:Label ID="lbAccount" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="bqleft">
                            密码：</td>
                        <td class="bqright">
                            <asp:Label ID="lbPwd" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="bqleft">
                        </td>
                        <td class="bqright">
                            <asp:Button ID="btnAddm" runat="server" CausesValidation="False" CssClass="btn" Text="继续添加" OnClick="btnAddm_Click" />
                            <asp:Button ID="btnViewList" runat="server" CausesValidation="False" CssClass="btn" Text="查看列表" OnClick="btnViewList_Click" /></td>
                    </tr>
                </table>
            </asp:View>
            <asp:View ID="vViewCard" runat="server">
                <table cellpadding="0" cellspacing="1" class="border" style="width: 99%" align="center">
                    <tr>
                        <td class="title" colspan="2">
                            <asp:Label ID="lbViewTitle" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="bqleft">
                            类型：</td>
                        <td class="bqright">
                            <asp:Label ID="lbviewType" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="bqleft">
                            卡号：</td>
                        <td class="bqright">
                            <asp:Label ID="lbviewAccount" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="bqleft">
                            密码：</td>
                        <td class="bqright">
                            <asp:Label ID="lbviewPwd" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="bqleft">
                            是否已消费：</td>
                        <td class="bqright">
                            <asp:Label ID="lbviewIsused" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="bqleft">
                            点数：</td>
                        <td class="bqright">
                            <asp:Label ID="lbviewPoint" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="bqleft">
                            天数：</td>
                        <td class="bqright">
                            <asp:Label ID="lbviewDay" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="bqleft" style="height: 23px">
                            添加管理员ID：</td>
                        <td class="bqright" style="height: 23px">
                            <asp:Label ID="lbviewAdminID" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="bqleft">
                            添加管理员名称：</td>
                        <td class="bqright">
                            <asp:Label ID="lbviewAdminN" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="bqleft">
                            消费用户ID：</td>
                        <td class="bqright">
                            <asp:Label ID="lbviewUID" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="bqleft">
                            消费用户名称：</td>
                        <td class="bqright">
                            <asp:Label ID="lbviewUN" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="bqleft">
                            过期日期：</td>
                        <td class="bqright">
                            <asp:Label ID="lbviewOverdue" runat="server"></asp:Label></td>
                    </tr>
                </table>
            </asp:View>
            <asp:View ID="vMore" runat="server">
                <table cellpadding="0" cellspacing="1" class="border" style="width: 99%" align="center">
                    <tr>
                        <td class="title" colspan="2">
                            批量添加</td>
                    </tr>
                    <tr>
                        <td class="bqleft">
                            卡类型：</td>
                        <td class="bqright">
                            <asp:DropDownList ID="ddlMoreType" runat="server" onchange="SetCard(2);">
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td class="bqleft">
                            张数：</td>
                        <td class="bqright">
                            <asp:TextBox ID="txtMoreNum" runat="server" MaxLength="3"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtMoreNum"
                                Display="Dynamic" ErrorMessage="*张数不正确" ValidationExpression="^\d+$"></asp:RegularExpressionValidator><asp:RequiredFieldValidator
                                    ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtMoreNum" Display="Dynamic"
                                    ErrorMessage="*请输入张数"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td class="bqleft">
                            帐号前缀：</td>
                        <td class="bqright">
                            <asp:TextBox ID="txtMorePrifix" runat="server" MaxLength="10">KYCMS@#$</asp:TextBox>
                            <span class="tips">一个@代表一个字母,一个#代表一个数字,一个$代表一个字数或字母.其余符号将被视为本意.</span></td>
                    </tr>
                    <tr>
                        <td class="bqleft">
                            密码：</td>
                        <td class="bqright">
                            <asp:TextBox ID="txtMorePwd" runat="server">KYCMS$$#$@$@#$$</asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtMorePwd"
                                ErrorMessage="*"></asp:RequiredFieldValidator><br />
                            <span class="tips">一个@代表一个字母,一个#代表一个数字,一个$代表一个字数或字母.其余符号将被视为本意.</span>
                        </td>
                    </tr>
                    <tr id="TrMpoint">
                        <td class="bqleft">
                            点数：</td>
                        <td class="bqright">
                            <asp:TextBox ID="txtMorePoint" runat="server">30</asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtMorePoint"
                                Display="Dynamic" ErrorMessage="*点数不正确" ValidationExpression="^\d+$"></asp:RegularExpressionValidator><asp:RequiredFieldValidator
                                    ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtMorePoint"
                                    Display="Dynamic" ErrorMessage="*请输入点数"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr id="TrMday" style="display:none">
                        <td class="bqleft">
                            天数：</td>
                        <td class="bqright">
                            <asp:TextBox ID="txtMoreDay" runat="server">30</asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtMoreDay"
                                Display="Dynamic" ErrorMessage="*天数不正确" ValidationExpression="^\d+$"></asp:RegularExpressionValidator><asp:RequiredFieldValidator
                                    ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtMoreDay" Display="Dynamic"
                                    ErrorMessage="*请输入天数" ValidationGroup="moreCards"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td class="bqleft">
                            过期日期：</td>
                        <td class="bqright">
                            <asp:TextBox ID="txtMoreOverdue" runat="server" onblur="setday(this);" onclick="setday(this);"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="bqleft">
                        </td>
                        <td class="bqright">
                            <asp:Button ID="btnAddMore" runat="server" Text="生成" OnClick="btnAddMore_Click" CssClass="btn" />
                            <input id="Reset2" type="reset"  value="取消" onclick="javascript:history.back();"  class="btn" />
                        </td>
                    </tr>
                </table>
            </asp:View>
            <asp:View ID="vMoreList" runat="server">
                <table cellpadding="0" cellspacing="1" style="width: 99%" align="center">
                    <tr>
                        <td class="title" style="height: 20px">
                            操作成功</td>
                    </tr>
                    <tr>
                        <td class="tdbg">
                            共生成
                            <asp:Label ID="lbMoreCount" runat="server"></asp:Label>
                            张卡。分别是：<asp:GridView ID="gvListMore" runat="server" CellSpacing="1" CssClass="border" GridLines="None"
                    OnRowDataBound="gvListMore_RowDataBound" Width="99%">
                    <RowStyle CssClass="tdbg" />
                    <HeaderStyle CssClass="title" />
                </asp:GridView>
            </td>
                    </tr>
                </table>
            </asp:View>
        </asp:MultiView>
    </form>
    <asp:Literal ID="LitMsg" runat="server"></asp:Literal>
</body>
</html>
<script type="text/javascript">
    function SetCard(type)
    {
        if(type==1)
        {$('Trday').style.display=$("ddlCardType").selectedIndex==1?'':'none';$('Trpoint').style.display=$("ddlCardType").selectedIndex==0?'':'none' }
        if(type==2)
        {$('TrMday').style.display=$("ddlMoreType").selectedIndex==1?'':'none';$('TrMpoint').style.display=$("ddlMoreType").selectedIndex==0?'':'none'}
    }
</script>
