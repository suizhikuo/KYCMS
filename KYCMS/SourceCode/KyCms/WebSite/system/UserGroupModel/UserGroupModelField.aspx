<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserGroupModelField.aspx.cs"
    Inherits="system_UserGroupModel_UserGroupModelField" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="../css/default.css" type="text/css" rel="stylesheet" />

    <script type="text/javascript" src="../../js/Common.js"></script>

    <script type="text/javascript" src="../../js/ModelField.js"></script>

</head>
<body onload="SelectModelType()">
    <form id="form1" runat="server">
        <table width="99%" cellspacing="1" cellpadding="0" class="wzdh" align="center">
            <tr>
                <td height="24" width="20">
                    <img src="../images/skin/default/you.gif" align="absmiddle" /></td>
                <td align="left" style="padding-top: 3px;">
                    您现在的位置：<a href="../SystemInfo.aspx">后台管理</a> >> <a href="UserGroupModelList.aspx">用户注册模型列表</a>
                    >> <a href="UserGroupModelFieldList.aspx?ModelId=<%=Request.QueryString["ModelId"] %>">字段列表</a>
                    >> 添加[<asp:Label ID="ModelName" runat="server" Text="Label"></asp:Label>模型]字段</td>
                <td width="50" align="right">
                    <img src="../images/skin/default/help.gif" align="absmiddle" /></td>
            </tr>
        </table>
        <table class="border" cellspacing="1" cellpadding="0" width="99%" border="0" align="center">
            <tr class="tdbg">
                <td class="bqleft">
                    字段别名：
                </td>
                <td class="bqright">
                    <asp:TextBox ID="Alias" runat="server" MaxLength="20"></asp:TextBox><font color="#ff0066">*</font>如：文章标题</td>
            </tr>
            <tr class="tdbg">
                <td class="bqleft">
                    字段名称：
                </td>
                <td class="bqright">
                    <asp:TextBox ID="Name" MaxLength="50" runat="server"></asp:TextBox><font color="#ff0066">*</font>注：字段名由字母、数字、下划线组成 如：Title
                </td>
            </tr>
            <tr class="tdbg">
                <td class="bqleft">
                    字段描述：
                </td>
                <td class="bqright">
                    <asp:TextBox ID="Description" runat="server" Columns="40" Rows="6" TextMode="MultiLine"></asp:TextBox></td>
            </tr>
            <tr class="tdbg">
                <td class="bqleft">
                    是否必填：
                </td>
                <td class="bqright">
                    <asp:RadioButtonList ID="IsNotNull" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Value="True">是</asp:ListItem>
                        <asp:ListItem Selected="True" Value="False">否</asp:ListItem>
                    </asp:RadioButtonList></td>
            </tr>
            <tr class="tdbg">
                <td class="bqleft">
                    字段类型：
                </td>
                <td class="bqright">
                    <asp:RadioButtonList ID="Type" runat="server" RepeatColumns="5" RepeatDirection="Horizontal"
                        onclick="SelectModelType()">
                        <asp:ListItem Value="TextType" Selected="True">单行文本</asp:ListItem>
                        <asp:ListItem Value="MultipleTextType">多行文本(不支持Html)</asp:ListItem>
                        <asp:ListItem Value="MultipleHtmlType">多行文本(支持Html)</asp:ListItem>
                        <asp:ListItem Value="RadioType">单选项</asp:ListItem>
                        <asp:ListItem Value="ListBoxType">多选项</asp:ListItem>
                        <asp:ListItem Value="DateType">日期时间</asp:ListItem>
                        <asp:ListItem Value="PicType">单图片</asp:ListItem>
                        <asp:ListItem Value="FileType">附件</asp:ListItem>
                        <asp:ListItem Value="NumberType">数字</asp:ListItem>
                        <asp:ListItem Value="RadomType">随机数</asp:ListItem>
                        <asp:ListItem Value="ErLinkageType">二级联动</asp:ListItem>
                    </asp:RadioButtonList></td>
            </tr>
            <tbody id="DivTextType">
                <tr>
                    <td class="bqleft">
                        文本框长度：</td>
                    <td class="bqright">
                        <asp:TextBox ID="TitleSize" runat="server" Columns="10" MaxLength="4">35</asp:TextBox></td>
                </tr>
                <tr>
                    <td class="bqleft">
                        是否为密码：</td>
                    <td class="bqright">
                        <asp:RadioButtonList ID="IsPassword" runat="server" RepeatDirection="Horizontal"
                            CssClass="input1">
                            <asp:ListItem Value="password">是</asp:ListItem>
                            <asp:ListItem Selected="True" Value="text">否</asp:ListItem>
                        </asp:RadioButtonList></td>
                </tr>
                <tr>
                    <td class="bqleft">
                        默认值：</td>
                    <td class="bqright">
                        <asp:TextBox ID="TextType_DefaultValue" runat="server" Columns="10"></asp:TextBox></td>
                </tr>
            </tbody>
            <tbody id="DivMultipleTextType" style="display: none">
                <tr>
                    <td class="bqleft">
                        显示的宽度：</td>
                    <td class="bqright">
                        <asp:TextBox ID="MultipleTextType_Width" runat="server" Columns="10" MaxLength="4">500</asp:TextBox>px</td>
                </tr>
                <tr>
                    <td class="bqleft">
                        显示的高度：</td>
                    <td class="bqright">
                        <asp:TextBox ID="MultipleTextType_Height" runat="server" Columns="10" MaxLength="4">200</asp:TextBox>px</td>
                </tr>
            </tbody>
            <tbody id="DivMultipleHtmlType" style="display: none">
                <tr>
                    <td class="bqleft">
                        编辑器类型：</td>
                    <td class="bqright">
                        <asp:DropDownList ID="IsEditor" runat="server">
                            <asp:ListItem Value="1">简洁型编辑器</asp:ListItem>
                            <asp:ListItem Value="2">标准型编辑器</asp:ListItem>
                            <asp:ListItem Value="3">增强型编辑器</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td class="bqleft">
                        显示的宽度：</td>
                    <td class="bqright">
                        <asp:TextBox ID="MultipleHtmlType_Width" runat="server" Columns="10" MaxLength="4">715</asp:TextBox>px</td>
                </tr>
                <tr>
                    <td class="bqleft">
                        显示的高度：</td>
                    <td class="bqright">
                        <asp:TextBox ID="MultipleHtmlType_Height" runat="server" Columns="10" MaxLength="4">400</asp:TextBox>px</td>
                </tr>
            </tbody>
            <tbody id="DivRadioType" style="display: none">
                <tr>
                    <td class="bqleft">
                        分行键入每个选项：</td>
                    <td class="bqright"><input id="Button3" type="button" value="从数据字典中选择选项" class="btn" onclick="SelectDictionary('RadioType_Content')" /><br />
                        <asp:TextBox ID="RadioType_Content" runat="server" TextMode="MultiLine" Columns="40"
                            Rows="6"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="bqleft">
                        默认值：</td>
                    <td class="bqright">
                        <asp:TextBox ID="RadioType_Default" runat="server"></asp:TextBox>
                        注：没有数据录入的默认值，与前台显示无关.</td>
                </tr>
                <tr>
                    <td class="bqleft">
                        显示选项：</td>
                    <td class="bqright">
                        <asp:RadioButtonList ID="RadioType_Type" runat="server">
                            <asp:ListItem Selected="True" Value="1">单选下拉列表框</asp:ListItem>
                            <asp:ListItem Value="2">单选按钮</asp:ListItem>
                        </asp:RadioButtonList></td>
                </tr><!--
                <tr>
                    <td class="bqleft">
                        是否设置属性值：</td>
                    <td class="bqright">
                        <asp:RadioButtonList ID="RadioType_Property" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="True">是</asp:ListItem>
                            <asp:ListItem Value="False" Selected="True">否</asp:ListItem>
                        </asp:RadioButtonList></td>
                </tr>-->
            </tbody>
            <tbody id="DivListBoxType" style="display: none">
                <tr>
                    <td class="bqleft">
                        分行键入每个选项：</td>
                    <td class="bqright"><input id="Button4" type="button" value="从数据字典中选择选项" class="btn" onclick="SelectDictionary('ListBoxType_Content')" /><br />
                        <asp:TextBox ID="ListBoxType_Content" runat="server" TextMode="MultiLine" Columns="40"
                            Rows="6"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="bqleft">
                        显示选项：</td>
                    <td class="bqright">
                        <asp:RadioButtonList ID="ListBoxType_Type" runat="server">
                            <asp:ListItem Selected="True" Value="1">复选框</asp:ListItem>
                            <asp:ListItem Value="2">多选列表框</asp:ListItem>
                        </asp:RadioButtonList></td>
                </tr>
            </tbody>
            <tbody id="DivDateType" style="display: none">
            </tbody>
            <tbody id="DivPicType" style="display:none">
            </tbody>
            <tbody id="DivRadomType" style="display: none">
            </tbody>
            <tbody id="DivFileType" style="display: none">
            </tbody>
            <tbody id="DivNumberType" style="display: none">
                <tr>
                    <td class="bqleft">
                        文本框长度：</td>
                    <td class="bqright">
                        <asp:TextBox ID="NumberType_TitleSize" runat="server" Columns="10" MaxLength="4">35</asp:TextBox></td>
                </tr>
                <tr>
                    <td class="bqleft">
                        默认值：</td>
                    <td class="bqright">
                        <asp:TextBox ID="NumberType_DefaultValue" runat="server" Columns="10"></asp:TextBox></td>
                </tr>
            </tbody>
            <tbody id="DivErLinkageType" style="display:none">
                <tr>
                    <td class="bqleft">指定一级分类：</td>
                    <td class="bqright"><asp:TextBox ID="ErLinkage_Value" runat="server" style="display:none"></asp:TextBox><asp:TextBox ID="ErLinkage_Value_Show" runat="server" Columns="10"></asp:TextBox><input id="Button5" type="button" value="从数据字典中选择分类" class="btn" onclick="SelectDictionary('ErLinkage_Value','2')" /> <font color=red>注：请确认数据字典中具有二级分类</font></td>
                </tr>
                <tr>
                    <td class="bqleft">二级分类别名：</td>
                    <td class="bqright"><asp:TextBox ID="ErLinkage_Er_Alias" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="bqleft">二级分类字段名：</td>
                    <td class="bqright"><asp:TextBox ID="ErLinkage_Er_Name" runat="server"></asp:TextBox> <font color="red">*</font>字段名由字母、数字、下划线组成</td>
                </tr>
            </tbody>
            <!--
            <tr>
                <td class="bqleft">
                    是否在列表页中显示：</td>
                <td class="bqright">
                    <table>
                        <tr>
                            <td>
                                <asp:RadioButtonList ID="IsList" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="True">是</asp:ListItem>
                                    <asp:ListItem Selected="True" Value="False">否</asp:ListItem>
                                </asp:RadioButtonList></td>
                            <td>
                                (在信息列表中，以列表的形式显示出来。)</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr class="tdbg">
                <td class="bqleft">
                    是否在列表页中搜索：
                </td>
                <td class="bqright">
                    <table>
                        <tr>
                            <td>
                                <asp:RadioButtonList ID="IsSearchForm" runat="server" RepeatDirection="Horizontal"
                                    CssClass="input1">
                                    <asp:ListItem Value="True">是</asp:ListItem>
                                    <asp:ListItem Selected="True" Value="False">否</asp:ListItem>
                                </asp:RadioButtonList></td>
                            <td>
                                (在列表页中显示出搜索项)</td>
                        </tr>
                    </table>
                </td>
            </tr>-->
            <tr>
                <td class="bqleft">
                    是否允许用户录入数据：</td>
                <td class="bqright">
                    <table>
                        <tr>
                            <td>
                                <asp:RadioButtonList ID="IsUserInsert" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Selected="True" Value="True">是</asp:ListItem>
                                    <asp:ListItem Value="False">否</asp:ListItem>
                                </asp:RadioButtonList></td>
                            <td>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="bqleft">
                </td>
                <td class="bqright" height="50">
                    <asp:Button ID="Button1" runat="server" Text=" 添加字段 " CssClass="btn" OnClientClick="return isok()"
                        OnClick="Button1_Click" />
                    &nbsp;&nbsp;
                    <input id="Button2" type="button" value=" 返回字段列表 " class="btn" onclick="javascript:window.location.href='UserGroupModelFieldList.aspx?ModelId=<%=Request.QueryString["ModelId"] %>'" /></td>
            </tr>
        </table>
    </form>
</body>
</html>
