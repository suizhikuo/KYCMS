<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditPowerColumn.aspx.cs"
    Inherits="system_user_EditPowerColumn" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>管理员权限组</title>
    <link href="../css/default.css" type="text/css" rel="stylesheet" />

    <script language="javascript" src="../../js/SystemUserPowerSelect.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <table width="99%" cellspacing="1" cellpadding="0" class="wzdh" align="center">
            <tr>
                <td height="20" width="27">
                    &nbsp;<img src="../images/skin/default/you.gif" width="17" height="16" /></td>
                <td>
                    您现在的位置：<a href="../SystemInfo.aspx">后台管理</a> >> <a href='AdminGroupList.aspx'>管理员组管理</a>
                    >> 修改管理员组</td>
                <td align="right">
                </td>
            </tr>
        </table>
        <table width="99%" cellspacing="1" cellpadding="0" class="border" align="center">
            <tr class="wzlist">
                <td align="left">
                    <a href="AdminGroupList.aspx">管理员组列表</a> | <a href="PowerColumn.aspx">新增管理员组</a>
                    | <a href="AdminList.aspx">管理员列表</a> | <a href="SetAdmin.aspx">新增管理员</a></td>
                <td align="right" width="300">
                    &nbsp;</td>
            </tr>
        </table>
        <!-- 头部结束 -->
        <table width="100%" border="0" cellpadding="2" cellspacing="1" class="border" align="center">
            <tbody>
                <tr>
                    <td height="26" class="bqleft">
                        <strong>管理员组名称：</strong></td>
                    <td class="bqright">
                        <asp:TextBox ID="PowerName" runat="server" Columns="35" MaxLength="40"></asp:TextBox>*</td>
                </tr>
                <tr>
                    <td class="bqleft">
                        <strong>请选择管理员组模型：</strong></td>
                    <td class="bqright">
                        <asp:DropDownList ID="PowerModel_List" runat="server" onchange="ModelPowerColumn(this.value)">
                            <asp:ListItem Value="0">不选择</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td height="80" class="bqleft">
                        <strong>管理员组说明：</strong></td>
                    <td class="bqright">
                        <asp:TextBox ID="PowerContent" runat="server" Columns="50" Rows="6" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
            </tbody>
            <!--模块权限 -->
            <tr>
                <td class="bqleft">
                    <strong>权限设置：</strong></td>
                <td class="qxright">
                    <table width="99%" border="0" cellpadding="0" cellspacing="1" class="qxborder" align="center">
                        <tbody>
                            <tr class="qxright">
                                <td colspan="4" align="left">
                                    <strong>模块权限</strong><input type="checkbox" name="CheckTemp" value="checkbox" onclick="CheckBox('CheckTemp','1,2,3,4,5,6,7,8,9,10,11,12,36,38,35,33,48,49')"><span
                                        id="ShowCheckTemp">选择全部</span></td>
                            </tr>
                            <tr class="tdbg" onmouseover="this.className='tdbgmouseover'" onmouseout="this.className='tdbg'">
                                <td align="left">
                                    <asp:CheckBox ID="PCId_1" runat="server" onclick="CheckTable(1)" /><%=GetPowerColumn(1)%></td>
                                <td align="left">
                                    <asp:CheckBox ID="PCId_36" runat="server" /><%=GetPowerColumn(36)%></td>
                                <td align="left">
                                    <asp:CheckBox ID="PCId_2" runat="server" /><%=GetPowerColumn(2)%></td>
                                <td align="left">
                                    <asp:CheckBox ID="PCId_3" runat="server" /><%=GetPowerColumn(3)%></td>
                            </tr>
                            <tr class="tdbg" onmouseover="this.className='tdbgmouseover'" onmouseout="this.className='tdbg'">
                                <td align="left">
                                    <asp:CheckBox ID="PCId_5" runat="server" /><%=GetPowerColumn(5)%></td>
                                <td align="left">
                                    <asp:CheckBox ID="PCId_6" runat="server" /><%=GetPowerColumn(6)%></td>
                                <td align="left">
                                    <asp:CheckBox ID="PCId_7" runat="server" /><%=GetPowerColumn(7)%></td>
                                <td align="left">
                                    <asp:CheckBox ID="PCId_8" runat="server" /><%=GetPowerColumn(8)%></td>
                            </tr>
                            <tr class="tdbg" onmouseover="this.className='tdbgmouseover'" onmouseout="this.className='tdbg'">
                                <td align="left">
                                    <asp:CheckBox ID="PCId_9" runat="server" /><%=GetPowerColumn(9)%></td>
                                <td align="left">
                                    <asp:CheckBox ID="PCId_10" runat="server" /><%=GetPowerColumn(10)%></td>
                                <td align="left">
                                    <asp:CheckBox ID="PCId_11" runat="server" /><%=GetPowerColumn(11)%></td>
                                <td align="left">
                                    <asp:CheckBox ID="PCId_12" runat="server" /><%=GetPowerColumn(12)%></td>
                            </tr>
                            <tr class="tdbg" onmouseover="this.className='tdbgmouseover'" onmouseout="this.className='tdbg'">
                                <td align="left">
                                    <asp:CheckBox ID="PCId_4" runat="server" /><%=GetPowerColumn(4)%></td>
                                <td align="left">
                                    <asp:CheckBox ID="PCId_38" runat="server" /><%=GetPowerColumn(38)%></td>
                                <td align="left">
                                    <asp:CheckBox ID="PCId_35" runat="server" /><%=GetPowerColumn(35)%></td>
                                <td align="left">
                                    <asp:CheckBox ID="PCId_33" runat="server" /><%=GetPowerColumn(33)%></td>
                            </tr>
                            <tr class="tdbg" onmouseover="this.className='tdbgmouseover'" onmouseout="this.className='tdbg'">
                                <td align="left">
                                    <asp:CheckBox ID="PCId_48" runat="server" /><%=GetPowerColumn(48)%></td>
                                <td align="left">
                                    <asp:CheckBox ID="PCId_49" runat="server" /><%=GetPowerColumn(49)%></td>
                                <td align="left"></td>
                                <td align="left"></td>
                            </tr>
                            <tr class="qxright">
                                <td colspan="4" align="left">
                                    <strong>用户权限</strong><input type="checkbox" name="CheckUser" value="checkbox" onclick="CheckBox('CheckUser','13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,37,46,47')"><span
                                        id="ShowCheckUser">选择全部</span></td>
                            </tr>
                            <tr class="tdbg" onmouseover="this.className='tdbgmouseover'" onmouseout="this.className='tdbg'">
                                <td align="left">
                                    <asp:CheckBox ID="PCId_13" runat="server" /><%=GetPowerColumn(13)%></td>
                                <td align="left">
                                    <asp:CheckBox ID="PCId_14" runat="server" /><%=GetPowerColumn(14)%></td>
                                <td align="left">
                                    <asp:CheckBox ID="PCId_15" runat="server" /><%=GetPowerColumn(15)%></td>
                                <td align="left">
                                    <asp:CheckBox ID="PCId_37" runat="server" /><%=GetPowerColumn(37)%></td>
                            </tr>
                            <tr class="tdbg" onmouseover="this.className='tdbgmouseover'" onmouseout="this.className='tdbg'">
                                <td align="left">
                                    <asp:CheckBox ID="PCId_16" runat="server" /><%=GetPowerColumn(16)%></td>
                                <td align="left">
                                    <asp:CheckBox ID="PCId_17" runat="server" /><%=GetPowerColumn(17)%></td>
                                <td align="left">
                                    <asp:CheckBox ID="PCId_18" runat="server" /><%=GetPowerColumn(18)%></td>
                                <td align="left">
                                    <asp:CheckBox ID="PCId_19" runat="server" /><%=GetPowerColumn(19)%></td>
                            </tr>
                            <tr class="tdbg" onmouseover="this.className='tdbgmouseover'" onmouseout="this.className='tdbg'">
                                <td align="left">
                                    <asp:CheckBox ID="PCId_20" runat="server" /><%=GetPowerColumn(20)%></td>
                                <td align="left">
                                    <asp:CheckBox ID="PCId_21" runat="server" /><%=GetPowerColumn(21)%></td>
                                <td align="left">
                                    <asp:CheckBox ID="PCId_22" runat="server" /><%=GetPowerColumn(22)%></td>
                                <td align="left">
                                    <asp:CheckBox ID="PCId_23" runat="server" /><%=GetPowerColumn(23)%></td>
                            </tr>
                            <tr class="tdbg" onmouseover="this.className='tdbgmouseover'" onmouseout="this.className='tdbg'">
                                <td align="left">
                                    <asp:CheckBox ID="PCId_24" runat="server" /><%=GetPowerColumn(24)%></td>
                                <td align="left">
                                    <asp:CheckBox ID="PCId_25" runat="server" /><%=GetPowerColumn(25)%></td>
                                <td align="left">
                                    <asp:CheckBox ID="PCId_26" runat="server" /><%=GetPowerColumn(26)%></td>
                                <td align="left">
                                    <asp:CheckBox ID="PCId_27" runat="server" /><%=GetPowerColumn(27)%></td>
                            </tr>
                            <tr class="tdbg" onmouseover="this.className='tdbgmouseover'" onmouseout="this.className='tdbg'">
                                <td align="left">
                                    <asp:CheckBox ID="PCId_46" runat="server" /><%=GetPowerColumn(46)%></td>
                                <td align="left">
                                    <asp:CheckBox ID="PCId_47" runat="server" /><%=GetPowerColumn(47)%></td>
                                <td align="left">
                                </td>
                                <td align="left">
                                </td>
                            </tr>
                            <tr class="qxright">
                                <td colspan="4" align="left">
                                    <strong>批量设置权限</strong><input type="checkbox" name="CheckBatch" value="checkbox"
                                        onclick="CheckBox('CheckBatch','40,41,42,43,44,45')"><span id="ShowCheckBatch">选择全部</span></td>
                            </tr>
                            <tr class="tdbg" onmouseover="this.className='tdbgmouseover'" onmouseout="this.className='tdbg'">
                                <td align="left">
                                    <asp:CheckBox ID="PCId_40" runat="server" /><%=GetPowerColumn(40)%></td>
                                <td align="left">
                                    <asp:CheckBox ID="PCId_41" runat="server" /><%=GetPowerColumn(41)%></td>
                                <td align="left">
                                    <asp:CheckBox ID="PCId_42" runat="server" /><%=GetPowerColumn(42)%></td>
                                <td align="left">
                                    <asp:CheckBox ID="PCId_43" runat="server" /><%=GetPowerColumn(43)%></td>
                            </tr>
                            <tr class="tdbg" onmouseover="this.className='tdbgmouseover'" onmouseout="this.className='tdbg'">
                                <td align="left">
                                    <asp:CheckBox ID="PCId_44" runat="server" /><%=GetPowerColumn(44)%></td>
                                <td align="left">
                                    <asp:CheckBox ID="PCId_45" runat="server" /><%=GetPowerColumn(45)%></td>
                                <td align="left">
                                </td>
                                <td align="left">
                                </td>
                            </tr>
                            <tr class="qxright">
                                <td colspan="4" align="left">
                                    <strong>其他权限</strong><input type="checkbox" name="CheckOther" value="checkbox" onclick="CheckBox('CheckOther','28,29,30,31,32,39,34')"><span
                                        id="ShowCheckOther">选择全部</span></td>
                            </tr>
                            <tr class="tdbg" onmouseover="this.className='tdbgmouseover'" onmouseout="this.className='tdbg'">
                                <td align="left">
                                    <asp:CheckBox ID="PCId_28" runat="server" /><%=GetPowerColumn(28)%></td>
                                <td align="left">
                                    <asp:CheckBox ID="PCId_29" runat="server" /><%=GetPowerColumn(29)%></td>
                                <td align="left">
                                    <asp:CheckBox ID="PCId_30" runat="server" /><%=GetPowerColumn(30)%></td>
                                <td align="left">
                                    <asp:CheckBox ID="PCId_31" runat="server" /><%=GetPowerColumn(31)%></td>
                            </tr>
                            <tr class="tdbg" onmouseover="this.className='tdbgmouseover'" onmouseout="this.className='tdbg'">
                                <td align="left">
                                    <asp:CheckBox ID="PCId_32" runat="server" /><%=GetPowerColumn(32)%></td>
                                <td align="left">
                                    <asp:CheckBox ID="PCId_39" runat="server" /><%=GetPowerColumn(39)%></td>
                                <td align="left">
                                    <asp:CheckBox ID="PCId_34" runat="server" /><%=GetPowerColumn(34)%></td>
                                <td align="left">
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
            <tr id="CheckTable_1">
                <td class="bqleft">
                    内容管理</td>
                <td class="qxright">
                    <table width="99%" border="0" cellpadding="0" cellspacing="1" class="qxborder" align="center">
                        <tr class="title">
                            <td>
                                全选<asp:TextBox ID="TableNum" runat="server" Style="display: none" Height="1px" Width="0px"></asp:TextBox></td>
                            <td align="left">
                                中文名称</td>
                            <td>
                                查看</td>
                            <td>
                                录入</td>
                            <td>
                                修改</td>
                            <td>
                                删除</td>
                            <td>
                                审核管理<asp:TextBox ID="SelectBoxValue" runat="server" Style="display: none" Height="1px"
                                    Width="1px"></asp:TextBox></td>
                        </tr>
                        <asp:Repeater ID="Repeater1" runat="server">
                            <HeaderTemplate>
                                <tr class="tdbg" onmouseover="this.className='tdbgmouseover'" onmouseout="this.className='tdbg'">
                                    <td width="50">
                                        <input type="checkbox" name="AllChColColRows" onclick="SelectAllChColColRows()" value="1"></td>
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
                                    <td>
                                        <input type="checkbox" name="SelectAllChColColSpan4" onclick="SelectAllChColColSpan(4)"
                                            value="1"></td>
                                    <td>
                                        <select name="Select_Option" size="1" onchange="SelectOption()">
                                            <option value="0">无权限</option>
                                            <option value="1">一级审核</option>
                                            <option value="2">二级审核</option>
                                            <option value="3">三级审核</option>
                                        </select>
                                    </td>
                                </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr class="tdbg" onmouseover="this.className='tdbgmouseover'" onmouseout="this.className='tdbg'">
                                    <td width="50">
                                        <input type="checkbox" name="SelectAllChColRowsSpan<%# Eval("TableNum") %>" onclick="SelectAllChColRowsSpan(<%# Eval("TableNum") %>)"
                                            value="1"></td>
                                    <td align="left">
                                        <%# GetImgNum(int.Parse(DataBinder.Eval(Container, "DataItem.ChId", "{0}")), int.Parse(DataBinder.Eval(Container, "DataItem.ColId", "{0}")), int.Parse(DataBinder.Eval(Container, "DataItem.Depth", "{0}")))%>
                                        <%# Eval("Name") %>
                                    </td>
                                    <td>
                                        <asp:TextBox Text='<%# DataBinder.Eval(Container, "DataItem.ChId","{0}")%>' ID="ChId"
                                            runat="server" Style="display: none"></asp:TextBox><asp:TextBox ID="ColId" runat="server"
                                                Text='<%# DataBinder.Eval(Container, "DataItem.ColId","{0}")%>' Style="display: none"></asp:TextBox>
                                        <%# GetTextBoxHtml(int.Parse(DataBinder.Eval(Container, "DataItem.ChId", "{0}")), int.Parse(DataBinder.Eval(Container, "DataItem.ColId", "{0}")),int.Parse(DataBinder.Eval(Container, "DataItem.TableNum", "{0}")),1)%>
                                    </td>
                                    <td>
                                        <%# GetTextBoxHtml(int.Parse(DataBinder.Eval(Container, "DataItem.ChId", "{0}")), int.Parse(DataBinder.Eval(Container, "DataItem.ColId", "{0}")),int.Parse(DataBinder.Eval(Container, "DataItem.TableNum", "{0}")),2)%>
                                    </td>
                                    <td>
                                        <%# GetTextBoxHtml(int.Parse(DataBinder.Eval(Container, "DataItem.ChId", "{0}")), int.Parse(DataBinder.Eval(Container, "DataItem.ColId", "{0}")),int.Parse(DataBinder.Eval(Container, "DataItem.TableNum", "{0}")),3)%>
                                    </td>
                                    <td>
                                        <%# GetTextBoxHtml(int.Parse(DataBinder.Eval(Container, "DataItem.ChId", "{0}")), int.Parse(DataBinder.Eval(Container, "DataItem.ColId", "{0}")),int.Parse(DataBinder.Eval(Container, "DataItem.TableNum", "{0}")),4)%>
                                    </td>
                                    <td>
                                        <%# GetSelectBoxHtml(int.Parse(DataBinder.Eval(Container, "DataItem.ChId", "{0}")),int.Parse(DataBinder.Eval(Container, "DataItem.ColId", "{0}")))%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </td>
            </tr>
            <tr>
                <td height="29" colspan="2" align="center">
                    <span class="STYLE1">
                        <asp:Button ID="Button1" runat="server" CssClass="btn" Text=" 保存设置 " OnClick="Button1_Click" />&nbsp;
                        <asp:Button ID="Button2" runat="server" CssClass="btn" Text="保存为管理员组模型" OnClick="Button2_Click" /></span></td>
            </tr>
        </table>
    </form>
</body>
</html>
