<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SuperLabel.aspx.cs" Inherits="system_label_SuperLabel" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/default.css" type="text/css" rel="stylesheet" />

    <script type="text/javascript" src="../../js/Common.js"></script>

    <script type="text/javascript" src="../../js/SuperLabel.js"></script>

    <script type="text/javascript" src="../../js/Dragdrop.js"></script>

</head>
<body onmousemove="dragmove();" onmouseup="dragclear()" onload="SelectIsHtml()">
    <table width="99%" cellspacing="1" cellpadding="0" class="wzdh" align="center">
        <tr>
            <td height="24" width="20">
                <img src="../images/skin/default/you.gif" align="absmiddle" /></td>
            <td align="left" style="padding-top: 3px;">
                您现在的位置：<a href="../SystemInfo.aspx">后台管理</a> &gt;&gt; <a href="SuperLabelList.aspx">
                    超级标签管理</a> &gt;&gt; 超级标签设置</td>
            <td width="50" align="right">
                <img src="../images/skin/default/help.gif" align="absmiddle" /></td>
        </tr>
    </table>
    <form id="form1" runat="server">
        <asp:TextBox ID="TableValue" runat="server" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="TxtSqlStr" runat="server" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="TxtIsUnlockPage" runat="server" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="TxtHostTable" runat="server" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="TxtGuestTable" runat="server" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="TxtPageSize" runat="server" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="TxtNumColumns" runat="server" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="TxtIsHtml" runat="server" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="TxtDataBaseConn" runat="server" Style="display: none"></asp:TextBox>
        <table class="border" cellspacing="1" cellpadding="0" width="99%" border="0" align="center"
            runat="server" id="Table1">
            <tr class="tdbg">
                <td class="bqleft">
                    标签名称：
                </td>
                <td class="bqright">
                    <font color="red">{Ky_S_<asp:TextBox ID="txtName" runat="server"></asp:TextBox>} *</font></td>
            </tr>
            <!--
            <tr class="tdbg" style="display:none">
                <td class="bqleft">
                    标签分类：
                </td>
                <td class="bqright">
                    <asp:TextBox ID="txtLbCategoryName" MaxLength="50" runat="server"></asp:TextBox><asp:TextBox
                        ID="txtLbCategoryId" runat="server" Columns="5" Style="display: none">0</asp:TextBox>
                    <asp:DropDownList ID="dllLbCategory" runat="server" onchange="SelectCateGory(this.options[this.selectedIndex].value,this.options[this.selectedIndex].text)">
                    </asp:DropDownList>
                </td>
            </tr>-->
            <tr class="tdbg">
                <td class="bqleft">
                    数据设置：
                </td>
                <td class="bqright">
                    <font color="#ff0066">
                        <asp:DropDownList ID="DataBaseType" runat="server" onchange="SelectDataBaseType()">
                            <asp:ListItem Value="1">KYCMS主数据库</asp:ListItem>
                            <asp:ListItem Value="2">外部数据源</asp:ListItem>
                            <asp:ListItem Value="3">外部Ms Sql数据库</asp:ListItem>
                        </asp:DropDownList></font></td>
            </tr>
            <tr class="tdbg" style="display: none" id="DataBaseType_2_1">
                <td class="bqleft">
                    是否生成静态：
                </td>
                <td class="bqright">
                    <asp:RadioButtonList ID="IsHtml2" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Value="True">是</asp:ListItem>
                        <asp:ListItem Selected="True" Value="False">否</asp:ListItem>
                    </asp:RadioButtonList></td>
            </tr>
            <tr class="tdbg" style="display: none" id="DataBaseType_2_2">
                <td class="bqleft">
                    连接地址：
                </td>
                <td class="bqright">
                    <asp:TextBox ID="TxtStrSql1" runat="server" Columns="40">http://</asp:TextBox></td>
            </tr>
            <tr class="tdbg" style="display: none" id="DataBaseType_3">
                <td class="bqleft">
                    数据库连接：
                </td>
                <td class="bqright">
                    <table width="100%" align="center" cellpadding="2" cellspacing="0" border="0">
                        <tr>
                            <td align="right" nowrap>
                                服务器名或IP地址：</td>
                            <td width="100%">
                                <asp:TextBox ID="SqlIp" runat="server">127.0.0.1</asp:TextBox><input id="Button15" type="button" value=" 检测数据库连接 " onclick="CheckSqlConn()" /></td>
                        </tr>
                        <tr>
                            <td align="right">
                                数据库名称：</td>
                            <td>
                                <asp:TextBox ID="SqlName" runat="server">KyCms</asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="right">
                                数据库用户名称：</td>
                            <td>
                                <asp:TextBox ID="SqlUserName" runat="server">sa</asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="right">
                                数据库用户口令：</td>
                            <td>
                                <asp:TextBox ID="SqlPassWord" runat="server"></asp:TextBox></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr class="tdbg">
                <td class="bqleft">
                    标签说明：
                </td>
                <td class="bqright">
                    <asp:TextBox ID="txtSuperDes" runat="server" MaxLength="50" Columns="40" Rows="6"
                        TextMode="MultiLine"></asp:TextBox></td>
            </tr>
            <tr class="tdbg" id="DataBaseType_1">
                <td class="tdheight" colspan="2" align="center">
                    <asp:Button ID="Button1" runat="server" Text=" 下一步 " CssClass="btn" OnClick="btnSubmit_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input
                        id="Button2" type="button" value=" 取　消 " onclick="location.href='SuperLabelList.aspx'"
                        class="btn" />
                </td>
            </tr>
            <tr class="tdbg" id="DataBaseType_2" style="display: none">
                <td class="tdheight" colspan="2" align="center">
                    <asp:Button ID="Button13" runat="server" CssClass="btn" Text=" 保 存 " OnClick="Button13_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input
                        id="Button14" type="button" value=" 取　消 " onclick="location.href='SuperLabelList.aspx'"
                        class="btn" /><script>SelectDataBaseType()</script></td>
            </tr>
        </table>
        <table class="border" cellspacing="1" cellpadding="0" width="99%" border="0" align="center"
            runat="server" id="Table2">
            <tr class="tdbg">
                <td class="bqleft">
                    输出数量：
                </td>
                <td class="bqright">
                    <asp:TextBox ID="TopNum" runat="server" Columns="5">0</asp:TextBox><font color="red">注：</font>0表示输出所有数据</td>
            </tr>
            <tr class="tdbg">
                <td class="bqleft">
                    选择数据：
                </td>
                <td class="bqright">
                    <table cellpadding="4" cellspacing="0" border="0">
                        <tr>
                            <td align="right">
                                主表：</td>
                            <td>
                                <asp:DropDownList ID="DataTable1" runat="server" onchange="DbFieldList_1(this.options[this.selectedIndex].value)"
                                    Width="200">
                                    <asp:ListItem Value="0">请选择一个表</asp:ListItem>
                                </asp:DropDownList></td>
                            <td align="right">
                                从表：</td>
                            <td>
                                <asp:DropDownList ID="DataTable2" runat="server" onchange="DbFieldList_2(this.options[this.selectedIndex].value)"
                                    Width="200">
                                    <asp:ListItem Value="0">请选择一个表</asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td align="right">
                                输出字段：</td>
                            <td>
                                <asp:ListBox ID="DbFieldList1" runat="server" Width="200" SelectionMode="Multiple"
                                    Height="216" Rows="15"></asp:ListBox></td>
                            <td align="right">
                                输出字段：</td>
                            <td>
                                <asp:ListBox ID="DbFieldList2" runat="server" Height="216" Rows="15" SelectionMode="Multiple"
                                    Width="200"></asp:ListBox></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr class="tdbg">
                <td class="bqleft">
                    约束字段：
                </td>
                <td class="bqright">
                    <asp:DropDownList ID="Join" runat="server">
                        <asp:ListItem Value="INNER JOIN">InnerJoin</asp:ListItem>
                        <asp:ListItem Value="LEFT JOIN">LeftJoin</asp:ListItem>
                        <asp:ListItem Value="OUTER JOIN">OuterJoin</asp:ListItem>
                        <asp:ListItem Value="RIGHT JOIN">RightJoin</asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="DbFieldList3" runat="server">
                        <asp:ListItem Value="选择主表字段">选择主表字段</asp:ListItem>
                    </asp:DropDownList>=<asp:DropDownList ID="DbFieldList4" runat="server">
                        <asp:ListItem Value="选择从表字段">选择从表字段</asp:ListItem>
                    </asp:DropDownList>
                    只有在主表和从表同时选择的情况下才生效.
                </td>
            </tr>
            <tr class="tdbg">
                <td class="bqleft">
                    &nbsp;生成查询条件：
                </td>
                <td class="bqright">
                    <table cellpadding="2" cellspacing="0">
                        <tr>
                            <td>
                                <asp:TextBox ID="SuperSearchTermText" runat="server" Rows="4" TextMode="MultiLine"
                                    Columns="65"></asp:TextBox></td>
                            <td>
                                <input id="Button6" type="button" value=" 生成查询条件 " class="btn" onclick="SuperSearchTerm()" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr class="tdbg">
                <td class="bqleft">
                    生成排序规则：
                </td>
                <td class="bqright">
                    <table cellpadding="2" cellspacing="0">
                        <tr>
                            <td>
                                <asp:TextBox ID="SuperLabelOrderText" runat="server" Rows="4" TextMode="MultiLine"
                                    Columns="65"></asp:TextBox></td>
                            <td>
                                <input id="Button7" type="button" value=" 生成排序规则 " class="btn" onclick="SuperLabelOrder()" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr class="tdbg">
                <td class="bqleft">
                    生成Sql语句：
                </td>
                <td class="bqright">
                    <table cellpadding="2" cellspacing="0">
                        <tr>
                            <td style="height: 138px">
                                <asp:TextBox ID="SuperLabelSqlText" runat="server" Rows="8" TextMode="MultiLine"
                                    Columns="65"></asp:TextBox></td>
                            <td style="height: 138px">
                                <input id="Button8" type="button" value=" 生成Sql语句 " class="btn" onclick="SuperLabelSql()" /><p>
                                    <input id="Button9" type="button" value=" 检测Sql语句 " class="btn" onclick="CheckSql()" /></p>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="bqleft">
                    是否生成静态：</td>
                <td class="bqright">
                    <asp:RadioButtonList ID="IsHtml" runat="server" RepeatDirection="Horizontal" onclick="SelectIsHtml()">
                        <asp:ListItem Value="True">是</asp:ListItem>
                        <asp:ListItem Selected="True" Value="False">否</asp:ListItem>
                    </asp:RadioButtonList></td>
            </tr>
            <tr id="DivIsHtml">
                <td class="bqleft">
                    是否开启分页：</td>
                <td class="bqright">
                    <asp:RadioButtonList ID="IsUnlockPage" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Value="True">是</asp:ListItem>
                        <asp:ListItem Selected="True" Value="False">否</asp:ListItem>
                    </asp:RadioButtonList></td>
            </tr>
            <tr id="DivIsHtml_1">
                <td class="bqleft">
                    每页显示条数：</td>
                <td class="bqright">
                    <asp:TextBox ID="PageSize" runat="server" Columns="10">10</asp:TextBox></td>
            </tr>
            <tr>
                <td class="bqleft">
                    显示列数：</td>
                <td class="bqright">
                    <asp:DropDownList ID="NumColumns" runat="server">
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                        <asp:ListItem>8</asp:ListItem>
                        <asp:ListItem>9</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                        <asp:ListItem>13</asp:ListItem>
                        <asp:ListItem>14</asp:ListItem>
                        <asp:ListItem>15</asp:ListItem>
                        <asp:ListItem>16</asp:ListItem>
                        <asp:ListItem>17</asp:ListItem>
                        <asp:ListItem>18</asp:ListItem>
                        <asp:ListItem>19</asp:ListItem>
                        <asp:ListItem>20</asp:ListItem>
                    </asp:DropDownList>
                    列</td>
            </tr>
            <tr class="tdbg">
                <td class="tdheight" colspan="2" align="center">
                    <input id="Button5" type="button" value=" 上一步 " class="btn" onclick="window.history.back(-1)" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button
                        ID="Button3" runat="server" Text=" 下一步 " CssClass="btn" OnClick="Button3_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input
                            id="Button4" type="button" value=" 取　消 " onclick="location.href='SuperLabelList.aspx'"
                            class="btn" />
                </td>
            </tr>
        </table>
        <table class="border" cellspacing="1" cellpadding="0" width="99%" border="0" align="center"
            runat="server" id="Table3">
            <tr class="tdbg">
                <td class="bqleft">
                    样式内容编辑：
                </td>
                <td class="bqright">
                    <table width="100%" cellpadding="2" cellspacing="0" border="0">
                        <tr>
                            <td>
                                <asp:DataList ID="DataList1" runat="server" RepeatColumns="5" Width="580px" RepeatDirection="Horizontal"
                                    ShowFooter="False" ShowHeader="False">
                                    <ItemTemplate>
                                        <div id='{Ky_<%# Eval("FieldName") %>}' onmousedown='DragStart()' onclick='SetValue()'
                                            style='cursor: hand; border: solid 1px #9c9c9c; text-align: center; width: 100%'>
                                            <%# Eval("FieldName") %>
                                        </div>
                                    </ItemTemplate>
                                </asp:DataList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="test" runat="server" Rows="12" TextMode="MultiLine" onmouseup="dragend()"
                                    onmousemove="movePoint()" Width="95%"></asp:TextBox></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr class="tdbg">
                <td class="tdheight" colspan="2" align="center">
                    <input id="Button10" type="button" value=" 上一步 " class="btn" onclick="window.history.back(-1)" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button
                        ID="Button11" runat="server" Text=" 保 存 " CssClass="btn" OnClick="Button11_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input
                            id="Button12" type="button" value=" 取　消 " onclick="location.href='SuperLabelList.aspx'"
                            class="btn" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
