<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SetVote.aspx.cs" Inherits="system_news_SetVote"
    EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>投票管理</title>
    <link href="../css/default.css" rel="Stylesheet" type="text/css" />
    <script src="../../js/RiQi.js" type="text/javascript"></script>
    <script src="../../js/common.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        function CheckInput()
        {
            if($("txtStartTime").value=="" || $("txtEndTime").value=="")
            {
                alert("请输入起始日期");
               return false; 
            }
            if($("txtDescription").value=="")
            {
                alert("投票说明不能为空");
               return false; 
            }
        } 
        
    //在修改投票个数时起作用
   function showup(num)
   {
        for(var i=0;i<3;i++)
        {
            var obj=$("Table"+i);
            obj.style.display='none';
        }
        for( var m=0;m<num;m++)
        {
            var tgt=$("Table"+m);
            tgt.style.display='';
        }
   }
   //在查看投票信息时起作用
   function display()
   {
        var ddl=$("ddlVoteNum");
        if(ddl.value > 0)
        {
            for(var i=0;i<ddl.value;i++)
            {
                var obj=$("Table"+i);
                obj.style.display='';
            }
        }
   }
    </script>

</head>
<body onload="display();">
    <form id="form1" runat="server">
        <table border="0" cellpadding="0" cellspacing="0" class="wzdh" align="center" width="99%">
            <tr>
                <td height="20" width="27">
                    &nbsp;<img alt="" height="16" src="../images/skin/default/you.gif" width="17" /></td>
                <td height="32">
                    您现在的位置： <a href="../SystemInfo.aspx">后台管理</a> >> <a href="Vote.aspx">投票系统</a> >> 设置投票</td>
            </tr>
        </table>
        <table width="99%" cellspacing="1" cellpadding="0" class="border" align="center">
            <tr class="wzlist">
                <td  align="left">
                    <a href="Vote.aspx">所有投票</a> | <a href="VoteCategory.aspx">新建分类</a> | <a href="voteCategory.aspx">分类列表</a></td>
            </tr>
        </table>
        <table class="border" width="99%" align="center">
            <tr>
                <td>
                    <table style="width: 100%;" cellpadding="0" cellspacing="1">
                        <tr>
                            <td class="bqleft" style="height: 22px">
                                投票主题：</td>
                            <td class="bqright" style="height: 22px">
                                <asp:TextBox ID="txtDescription" runat="server" Width="288px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="bqleft">
                                所属分类：</td>
                            <td class="bqright">
                                <asp:DropDownList ID="ddlCategory" runat="server">
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td class="bqleft">
                                开始日期：</td>
                            <td class="bqright">
                                <asp:TextBox ID="txtStartTime" runat="server" onblur="setday(this);" onclick="setday(this);"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="bqleft" style="height: 24px">
                                结束日期：</td>
                            <td class="bqright" style="height: 24px">
                                <asp:TextBox ID="txtEndTime" runat="server" onblur="setday(this);" onclick="setday(this);"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="bqleft">
                                需要登录后投票：</td>
                            <td class="bqright">
                                <asp:CheckBox ID="chkIsLogin" runat="server" Text="是" /></td>
                        </tr>
                        <tr>
                            <td class="bqleft">
                                投票项数：</td>
                            <td class="bqright">
                                <asp:DropDownList ID="ddlVoteNum" runat="server" onchange="showup(this.options[this.selectedIndex].value);">
                                    <asp:ListItem>1</asp:ListItem>
                                    <asp:ListItem>2</asp:ListItem>
                                    <asp:ListItem>3</asp:ListItem>
                                </asp:DropDownList>
                                <span class="tips" id="lbInfo" runat="server">请慎重选择,一旦选择将不可修改!</span>
                                </td>
                        </tr>
                    </table>
                    <table style="width: 100%;" cellpadding="0" cellspacing="1" id="Table0">
                        <tr>
                            <td class="bqleft">
                                <asp:Literal ID="LitVoteId1" runat="server" Visible="False"></asp:Literal>投票项一：</td>
                            <td class="bqright">
                                <asp:TextBox ID="txtTitle1" runat="server" Width="288px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="bqleft">
                                选择类型：</td>
                            <td class="bqright">
                                <asp:RadioButtonList ID="rblType1" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Selected="True" Value="0">单选</asp:ListItem>
                                    <asp:ListItem Value="1">多选</asp:ListItem>
                                </asp:RadioButtonList></td>
                        </tr>
                        <tr>
                            <td class="bqleft">
                                选项一：</td>
                            <td class="bqright">
                                <asp:TextBox ID="txtItem11" runat="server" Width="203px"></asp:TextBox>票数:<asp:TextBox
                                    ID="txtItemNum11" runat="server">0</asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="bqleft">
                                选项二：</td>
                            <td class="bqright">
                                <asp:TextBox ID="txtItem12" runat="server" Width="203px"></asp:TextBox>票数:<asp:TextBox
                                    ID="txtItemNum12" runat="server">0</asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="bqleft">
                                选项三：</td>
                            <td class="bqright">
                                <asp:TextBox ID="txtItem13" runat="server" Width="203px"></asp:TextBox>票数:<asp:TextBox
                                    ID="txtItemNum13" runat="server">0</asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="bqleft" style="height: 24px">
                                选项四：</td>
                            <td class="bqright" style="height: 24px">
                                <asp:TextBox ID="txtItem14" runat="server" Width="203px"></asp:TextBox>票数:<asp:TextBox
                                    ID="txtItemNum14" runat="server">0</asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="bqleft">
                                选项五：</td>
                            <td class="bqright">
                                <asp:TextBox ID="txtItem15" runat="server" Width="203px"></asp:TextBox>票数:<asp:TextBox
                                    ID="txtItemNum15" runat="server">0</asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="bqleft">
                                选项六：</td>
                            <td class="bqright">
                                <asp:TextBox ID="txtItem16" runat="server" Width="203px"></asp:TextBox>票数:<asp:TextBox
                                    ID="txtItemNum16" runat="server">0</asp:TextBox></td>
                        </tr>
                    </table>
                    <table style="width: 100%; display: none;" cellpadding="0" cellspacing="1" id="Table1">
                        <tr>
                            <td class="bqleft">
                                <asp:Literal ID="LitVoteId2" runat="server" Visible="False"></asp:Literal>投票项二：</td>
                            <td class="bqright">
                                <asp:TextBox ID="txtTitle2" runat="server" Width="288px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="bqleft">
                                选择类型：</td>
                            <td class="bqright">
                                <asp:RadioButtonList ID="rblType2" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Selected="True" Value="0">单选</asp:ListItem>
                                    <asp:ListItem Value="1">多选</asp:ListItem>
                                </asp:RadioButtonList></td>
                        </tr>
                        <tr>
                            <td class="bqleft">
                                选项一：</td>
                            <td class="bqright">
                                <asp:TextBox ID="txtItem21" runat="server" Width="203px"></asp:TextBox>票数:<asp:TextBox
                                    ID="txtItemNum21" runat="server">0</asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="bqleft">
                                选项二：</td>
                            <td class="bqright">
                                <asp:TextBox ID="txtItem22" runat="server" Width="203px"></asp:TextBox>票数:<asp:TextBox
                                    ID="txtItemNum22" runat="server">0</asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="bqleft" style="height: 26px">
                                选项三：</td>
                            <td class="bqright" style="height: 26px">
                                <asp:TextBox ID="txtItem23" runat="server" Width="203px"></asp:TextBox>票数:<asp:TextBox
                                    ID="txtItemNum23" runat="server">0</asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="bqleft">
                                选项四：</td>
                            <td class="bqright">
                                <asp:TextBox ID="txtItem24" runat="server" Width="203px"></asp:TextBox>票数:<asp:TextBox
                                    ID="txtItemNum24" runat="server">0</asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="bqleft">
                                选项五：</td>
                            <td class="bqright">
                                <asp:TextBox ID="txtItem25" runat="server" Width="203px"></asp:TextBox>票数:<asp:TextBox
                                    ID="txtItemNum25" runat="server">0</asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="bqleft">
                                选项六：</td>
                            <td class="bqright">
                                <asp:TextBox ID="txtItem26" runat="server" Width="203px"></asp:TextBox>票数:<asp:TextBox
                                    ID="txtItemNum26" runat="server">0</asp:TextBox></td>
                        </tr>
                    </table>
                    <table style="width: 100%; display: none;" cellpadding="0" cellspacing="1" id="Table2">
                        <tr>
                            <td class="bqleft" style="height: 24px">
                                <asp:Literal ID="LitVoteId3" runat="server" Visible="False"></asp:Literal>投票项三：</td>
                            <td class="bqright" style="height: 24px">
                                <asp:TextBox ID="txtTitle3" runat="server" Width="288px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="bqleft">
                                选择类型：</td>
                            <td class="bqright">
                                <asp:RadioButtonList ID="rblType3" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Selected="True" Value="0">单选</asp:ListItem>
                                    <asp:ListItem Value="1">多选</asp:ListItem>
                                </asp:RadioButtonList></td>
                        </tr>
                        <tr>
                            <td class="bqleft">
                                选项一：</td>
                            <td class="bqright">
                                <asp:TextBox ID="txtItem31" runat="server" Width="203px"></asp:TextBox>票数:<asp:TextBox
                                    ID="txtItemNum31" runat="server">0</asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="bqleft">
                                选项二：</td>
                            <td class="bqright">
                                <asp:TextBox ID="txtItem32" runat="server" Width="203px"></asp:TextBox>票数:<asp:TextBox
                                    ID="txtItemNum32" runat="server">0</asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="bqleft">
                                选项三：</td>
                            <td class="bqright">
                                <asp:TextBox ID="txtItem33" runat="server" Width="203px"></asp:TextBox>票数:<asp:TextBox
                                    ID="txtItemNum33" runat="server">0</asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="bqleft">
                                选项四：</td>
                            <td class="bqright">
                                <asp:TextBox ID="txtItem34" runat="server" Width="203px"></asp:TextBox>票数:<asp:TextBox
                                    ID="txtItemNum34" runat="server">0</asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="bqleft">
                                选项五：</td>
                            <td class="bqright">
                                <asp:TextBox ID="txtItem35" runat="server" Width="203px"></asp:TextBox>票数:<asp:TextBox
                                    ID="txtItemNum35" runat="server">0</asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="bqleft">
                                选项六：</td>
                            <td class="bqright">
                                <asp:TextBox ID="txtItem36" runat="server" Width="203px"></asp:TextBox>票数:<asp:TextBox
                                    ID="txtItemNum36" runat="server">0</asp:TextBox></td>
                        </tr>
                    </table>
                    <table style="width: 100%">
                        <tr>
                            <td class="bqleft">
                                <asp:Button ID="btnAdd" runat="server" CssClass="btn" Text="添加" OnClientClick="return CheckInput();"
                                    OnClick="btnAdd_Click" /></td>
                            <td class="bqright">
                                <input id="Reset1" class="btn" type="reset" value="重置" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
    <asp:Literal ID="LitAction" runat="server" Visible="False"></asp:Literal>
</body>
</html>
