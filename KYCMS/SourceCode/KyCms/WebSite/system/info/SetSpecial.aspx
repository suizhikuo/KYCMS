<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SetSpecial.aspx.cs" Inherits="System_website_SetSpeacils" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>专题管理</title>
    <link href="../css/default.css" rel="Stylesheet" type="text/css" />

    <script src="../../JS/Common.js" type="text/javascript" language="javascript"></script>

    <script type="text/javascript">
   
   // 在用户从 Speacils.aspx 中查看专题信息时起作用
   function display()
   {
        var ddl=document.getElementById("ddlItemNum");
        if(ddl.value > 0)
        {
            for(var i=0;i<ddl.value;i++)
            {
                var obj=document.getElementById("Table"+i);
                obj.style.display='';
            }
        }
   }
   //在修改专题自设个数时起作用
   function showup(num)
   {
        for(var i=0;i<10;i++)
        {
            var obj=document.getElementById("Table"+i);
            obj.style.display='none';
        }
        for( var m=0;m<num;m++)
        {
            var tgt=document.getElementById("Table"+m);
            tgt.style.display='';
        }
   }
    </script>

</head>
<body onload="display();">
    <form id="form1" runat="server">
        <table align="center" cellpadding="0" cellspacing="1" class="wzdh" width="99%">
            <tr>
                <td width="20">
                    <img align="absMiddle" src="../images/skin/default/you.gif" /></td>
                <td align="left" style="padding-top: 3px">
                    您现在的位置：<a href="../SystemInfo.aspx">后台管理</a> &gt;&gt; 内容管理 &gt;&gt; 专题管理</td>
                <td align="right" width="50">
                    <img align="absMiddle" src="../images/skin/default/help.gif" /></td>
            </tr>
        </table>
        <table width="99%" cellspacing="1" cellpadding="0" class="border" align="center">
            <tr class="wzlist">
                <td align="left">
                    <a href="SpecialList.aspx">专题列表</a></td>
            </tr>
        </table>
        <table cellspacing="0" cellpadding="0" border="0" width="99%" class="cd" align="center">
            <tr align="center">
                <td id="TabTitle0" onclick="ShowTabs(0)" class="title6">
                    基本信息</td>
                <td id="TabTitle1" onclick="ShowTabs(1)" class="title5">
                    自设内容</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        <!-- 菜单结束 -->
        <table width="99%" border="0" cellpadding="2" cellspacing="1" class="editborder"
            align="center">
            <tbody id="Tabs0">
                <tr>
                    <td class="bqleft">
                        父专题：</td>
                    <td class="bqright">
                        <asp:DropDownList ID="ddlSpeacil" runat="server" AutoPostBack="True">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td class="bqleft">
                        频道ID：</td>
                    <td class="bqright">
                        <asp:DropDownList ID="ddlChannel" runat="server">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td class="bqleft">
                        专题中文名称：</td>
                    <td class="bqright">
                        <asp:TextBox ID="txtCName" runat="server" MaxLength="30"></asp:TextBox><span style="color: #ff0000">*</span></td>
                </tr>
                <tr>
                    <td class="bqleft">
                        专题英文名称：</td>
                    <td class="bqright">
                        <asp:TextBox ID="txtEName" runat="server" MaxLength="20"></asp:TextBox><span style="color: Red">*</span></td>
                </tr>
                <tr>
                    <td class="bqleft">
                        专题二级域名：</td>
                    <td class="bqright">
                        <asp:TextBox ID="txtDomain" runat="server" MaxLength="100"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="bqleft">
                        专题导读：</td>
                    <td class="bqright">
                        <asp:TextBox ID="txtRemark" runat="server" Height="104px" TextMode="MultiLine" Width="282px"
                            MaxLength="200"></asp:TextBox><span class="tips">专题导读调用方式:{$ky id="specialremark" /}</span><input id="Text1"
                            type="text" style="display: none" value="special_img" /></td>
                </tr>
                <tr>
                    <td class="bqleft">
                        专题是否锁定：</td>
                    <td class="bqright">
                        <asp:RadioButtonList ID="rblIsLock" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1">是</asp:ListItem>
                            <asp:ListItem Selected="True" Value="0">否</asp:ListItem>
                        </asp:RadioButtonList></td>
                </tr>
                <tr>
                    <td class="bqleft">
                        是否推荐专题：</td>
                    <td class="bqright">
                        <asp:RadioButtonList ID="rblIsRcmd" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1">是</asp:ListItem>
                            <asp:ListItem Selected="True" Value="0">否</asp:ListItem>
                        </asp:RadioButtonList></td>
                </tr>
                <tr>
                    <td class="bqleft">
                        专题扩展名：</td>
                    <td class="bqright">
                        <asp:RadioButtonList ID="rblExtension" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Selected="True" Value="1">.html</asp:ListItem>
                            <asp:ListItem Value="2">.htm</asp:ListItem>
                            <asp:ListItem Value="3">.shtml</asp:ListItem>
                            <asp:ListItem Value="4">.aspx</asp:ListItem>
                        </asp:RadioButtonList></td>
                </tr>
                <tr>
                    <td class="bqleft">
                        专题分类模板：</td>
                    <td class="bqright">
                        <asp:TextBox ID="txtTemplet" runat="server" Width="281px"></asp:TextBox><span style="color: #ff0000">*</span>
                        <input id="btnSelectTemp" class="btn" type="button" value="选择模板" onclick="WinOpenDialog('../Common/SelectTemplate.aspx?ControlId='+escape('txtTemplet')+'&StartPath='+escape('/Template'),650,480)" /></td>
                </tr>
                <tr>
                    <td class="bqleft">
                        专题图片：</td>
                    <td class="bqright">
                        <asp:TextBox ID="txtPic" runat="server" Width="281px"></asp:TextBox>
                        <input id="btnUploadPic" class="btn" type="button" value="选择图片" onclick="WinOpenDialog('../../common/SelectPic.aspx?ControlId=txtPic',500,400)" />
                        <asp:HyperLink ID="hyViewImg" runat="server" Visible="false">查看图片</asp:HyperLink><br />
                        <span class="tips">专题图片调用方式:{$ky id="specialimg" /}</span><input id="FilePicPath"
                            type="text" style="display: none" value="special_img|0" /></td>
                </tr>
                <tr>
                    <td class="bqleft" style="height: 27px">
                        专题分类生成目录结构：</td>
                    <td class="bqright" style="height: 27px">
                        <asp:DropDownList ID="ddlDirType" runat="server">
                            <asp:ListItem Value="1">Special/专题名.htm</asp:ListItem>
                            <asp:ListItem Value="2">Special/专题名/index.htm</asp:ListItem>
                            <asp:ListItem Value="3">Special/年份/专题名.htm</asp:ListItem>
                            <asp:ListItem Value="4">Special/年份/专题名/index.htm</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
            </tbody>
            <tbody id="Tabs1" style="display: none">
                <tr>
                    <td class="bqleft">
                        专题自设内容项目个数：</td>
                    <td class="bqright">
                        <asp:DropDownList ID="ddlItemNum" runat="server" onchange="showup(this.value);">
                            <asp:ListItem>0</asp:ListItem>
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
                        </asp:DropDownList><br />
                        <span class="tips">自设内容调用方式:{$ky id="specialcontent" pos="1" /} 其中,pos="1"表示自设内容一.其余类推.如自设内容四为:pos="4"</span></td>
                </tr>
                <tr id="Table0" style="display: none">
                    <td class="bqleft">
                        专题自设内容一<br />
                        &nbsp;</td>
                    <td class="bqright">
                        <asp:TextBox ID="txtItemContent1" runat="server" Height="104px" TextMode="MultiLine"
                            Width="282px"></asp:TextBox>&nbsp;</td>
                </tr>
                <tr id="Table1" style="display: none">
                    <td class="bqleft">
                        专题自设内容二&nbsp;</td>
                    <td class="bqright">
                        <asp:TextBox ID="txtItemContent2" runat="server" TextMode="MultiLine" Height="104px"
                            Width="282px"></asp:TextBox>
                    </td>
                </tr>
                <tr id="Table2" style="display: none">
                    <td class="bqleft">
                        专题自设内容三&nbsp;</td>
                    <td class="bqright">
                        <asp:TextBox ID="txtItemContent3" runat="server" TextMode="MultiLine" Height="104px"
                            Width="282px"></asp:TextBox>
                    </td>
                </tr>
                <tr id="Table3" style="display: none">
                    <td class="bqleft">
                        专题自设内容四&nbsp;</td>
                    <td class="bqright">
                        <asp:TextBox ID="txtItemContent4" runat="server" TextMode="MultiLine" Height="104px"
                            Width="282px"></asp:TextBox>
                    </td>
                </tr>
                <tr id="Table4" style="display: none">
                    <td class="bqleft">
                        专题自设内容五&nbsp;</td>
                    <td class="bqright">
                        <asp:TextBox ID="txtItemContent5" runat="server" TextMode="MultiLine" Height="104px"
                            Width="282px"></asp:TextBox>
                    </td>
                </tr>
                <tr id="Table5" style="display: none">
                    <td class="bqleft">
                        专题自设内容六&nbsp;</td>
                    <td class="bqright">
                        <asp:TextBox ID="txtItemContent6" runat="server" TextMode="MultiLine" Height="104px"
                            Width="282px"></asp:TextBox>
                    </td>
                </tr>
                <tr id="Table6" style="display: none">
                    <td class="bqleft">
                        专题自设内容七&nbsp;</td>
                    <td class="bqright">
                        <asp:TextBox ID="txtItemContent7" runat="server" TextMode="MultiLine" Height="104px"
                            Width="282px"></asp:TextBox>
                    </td>
                </tr>
                <tr id="Table7" style="display: none">
                    <td class="bqleft">
                        专题自设内容八&nbsp;</td>
                    <td class="bqright">
                        <asp:TextBox ID="txtItemContent8" runat="server" TextMode="MultiLine" Height="104px"
                            Width="282px"></asp:TextBox>
                    </td>
                </tr>
                <tr id="Table8" style="display: none">
                    <td class="bqleft">
                        专题自设内容九&nbsp;</td>
                    <td class="bqright">
                        <asp:TextBox ID="txtItemContent9" runat="server" TextMode="MultiLine" Height="104px"
                            Width="282px"></asp:TextBox>
                    </td>
                </tr>
                <tr id="Table9" style="display: none">
                    <td class="bqleft">
                        专题自设内容十&nbsp;</td>
                    <td class="bqright">
                        <asp:TextBox ID="txtItemContent10" runat="server" TextMode="MultiLine" Height="104px"
                            Width="282px"></asp:TextBox>&nbsp;
                        <asp:TextBox ID="txtAddTime" runat="server"></asp:TextBox>
                        <asp:TextBox ID="txtIsdelete" runat="server"></asp:TextBox></td>
                </tr>
            </tbody>
            <tr>
                <td class="bqleft">
                </td>
                <td class="bqright">
                    <asp:Button ID="btnAdd" runat="server" CssClass="btn" Text=" 添 加 " OnClick="btnAdd_Click" />
                    <input id="Reset1" class="btn" type="reset" value="重置" /></td>
            </tr>
        </table>
    </form>
</body>
</html>
