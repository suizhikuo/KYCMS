<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SetPushInfo.aspx.cs" Inherits="system_other_PushInfo"
    EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>设置广告</title>
    <link href="../css/default.css" rel="Stylesheet" type="text/css" />

    <script type="text/javascript" src="../../js/Common.js"></script>

    <script type="text/javascript" src="../../js/RiQi.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <table width="99%" cellspacing="1" cellpadding="0" class="wzdh" align="center">
            <tr>
                <td height="24" width="20">
                    <img src="../images/skin/default/you.gif" align="absmiddle" /></td>
                <td align="left" style="padding-top: 3px;">
                    您现在的位置：<a href="../SystemInfo.aspx">后台管理</a> >> <a href="PushInfoList.aspx"> 广告管理</a> >> 添加广告</td>
                <td width="50" align="right">
                    <img src="../images/skin/default/help.gif" align="absmiddle" /></td>
            </tr>
        </table>
        <table width="99%" cellspacing="1" cellpadding="0" class="border" align="center">
            <tr class="wzlist">
                <td>
                    <a href="setpushinfo.aspx">添加广告</a> | <a href="setpushcategory.aspx">添加广告位</a> | <a href="pushinfolist.aspx">广告列表</a> | <a href="PushCategoryList.aspx">广告位列表</a></td>
            </tr>
        </table>
        <table style="width: 99%" class="border" cellpadding="0" cellspacing="1" align="center">
            <tr>
                <td class="bqleft">
                    广告名称：</td>
                <td class="bqright">
                    <asp:TextBox ID="txtName" runat="server" MaxLength="50"></asp:TextBox><span style="color: red">*<input
                        id="FilePicPath" type="text" style="display:none" value="Push|0" /></span></td>
            </tr>
            <tr>
                <td class="bqleft">
                    显示类型：</td>
                <td class="bqright">
                    <asp:RadioButton ID="rbPic" runat="server" Checked="True" GroupName="AdType" Text="图片"
                        onclick="SetType(1)" />
                    <asp:RadioButton ID="rbFlash" runat="server" GroupName="AdType" Text="Flash" onclick="SetType(3)" />
                    <asp:RadioButton ID="rbText" runat="server" GroupName="AdType" Text="文字" onclick="SetType(5)" />
                    <asp:RadioButton ID="rbCode" runat="server" GroupName="AdType" Text="代码" onclick="SetType(6)" />
                </td>
            </tr>
            <tr id="Tr1" runat="server" style="display: block">
                <td class="bqleft">
                    上传图片：</td>
                <td class="bqright">
                    <asp:TextBox ID="txtPicTitlePath" runat="server" Width="269px"></asp:TextBox>
                    <input id="btnUploadPic" class="btn" type="button" value="选择图片" onclick="WinOpenDialog('../../common/SelectPic.aspx?ControlId=txtPicTitlePath',500,400)" /><span
                        style="color: #ff0000">*</span><span style="color: #ff0000"></span></td>
            </tr>
            <tr id="Tr2" runat="server" style="display: block">
                <td class="bqleft">
                    设置图片属性：</td>
                <td class="bqright">
                    宽<asp:TextBox ID="txtPicWidth" runat="server" Width="33px" MaxLength="4"></asp:TextBox>px
                    高<asp:TextBox ID="txtPicHeight" runat="server" Width="33px" MaxLength="4"></asp:TextBox>px<br />
                    链接URL：<asp:TextBox ID="txtPicUrl" runat="server" MaxLength="255"></asp:TextBox><br />
                    图片提示：<asp:TextBox ID="txtPicAlt" runat="server" MaxLength="50"></asp:TextBox><br />
                    打开方式：<asp:RadioButton ID="txtPicBlank" runat="server" Checked="True" GroupName="OpenType"
                        Text="新窗口" />
                    <asp:RadioButton ID="txtPicSelf" runat="server" GroupName="OpenType" Text="原窗口" /></td>
            </tr>
            <tr id="Tr3" runat="server" style="display: none">
                <td class="bqleft">
                    上传动画：</td>
                <td class="bqright">
                    <asp:TextBox ID="txtFlashPath" runat="server" Width="269px"></asp:TextBox>
                    <input id="btnUploadFlash" class="btn" type="button" value="选择动画"  onclick="WinOpenDialog('../../common/uploadfile.aspx?ControlId=txtFlashPath',600,170)"/><span style="color: #ff0000">*</span></td>
            </tr>
            <tr id="Tr4" runat="server" style="display: none">
                <td style="height: 48px;" class="bqleft">
                    设置动画属性：</td>
                <td style="height: 48px;" class="bqright">
                    宽<asp:TextBox ID="txtFlashWidth" runat="server" Width="33px" MaxLength="4"></asp:TextBox>px
                    高<asp:TextBox ID="txtFlashHeight" runat="server" Width="33px" MaxLength="4"></asp:TextBox>px<br />
                    背景色：<asp:RadioButtonList ID="rblTransparent" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Selected="True" Value="transparent">透明</asp:ListItem>
                        <asp:ListItem>不透明</asp:ListItem>
                    </asp:RadioButtonList></td>
            </tr>
            <tr id="Tr5" runat="server" style="display: none">
                <td class="bqleft">
                    设置文字属性：</td>
                <td class="bqright">
                    文字标题：<asp:TextBox ID="txtTextTitle" runat="server"></asp:TextBox><span style="color: #ff0000">*</span><br />
                    链接URL：<asp:TextBox ID="txtTextLinkUrl" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr id="Tr6" runat="server" style="display: none">
                <td class="bqleft">
                    输入代码：</td>
                <td class="bqright">
                    <asp:TextBox ID="txtCodeContent" runat="server" Height="84px" TextMode="MultiLine"
                        Width="341px" MaxLength="1000"></asp:TextBox><br />
                    <span class="tips">注意：系统会自动替换代码中的单引号为 \单引号</span></td>
            </tr>
            <tr>
                <td class="bqleft" style="height: 24px">
                    所属广告位：</td>
                <td class="bqright" style="height: 24px">
                    <asp:ListBox ID="lstboxCategory" runat="server" Height="120px" Width="345px"></asp:ListBox>
                    <span class="tips">未显示已禁用广告位</span></td>
            </tr>
            <tr>
                <td class="bqleft">
                    显示权重：</td>
                <td class="bqright">
                    <asp:TextBox ID="txtWeight" runat="server" Width="36px" MaxLength="3">5</asp:TextBox><span
                        class="tips">仅数字(0-100)。值越大显示几率越高</span></td>
            </tr>
            <tr>
                <td class="bqleft">
                    过期日期：</td>
                <td class="bqright">
                    <asp:TextBox ID="txtOverdue" runat="server" onblur="setday(this);" onclick="setday(this);"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="bqleft">
                </td>
                <td class="bqright">
                    <asp:Button ID="btnSet" runat="server" CssClass="btn" Text="添加" OnClick="btnSet_Click" />
                    <input id="btnReset" class="btn" type="reset" value="重置" /></td>
            </tr>
        </table>
    </form>
</body>
</html>

<script type="text/javascript">
   function SetType(flag)
   {
        for(i=1;i<7;i++)
        {
            var obj=$("Tr"+i);
            obj.style.display='none';
        }
        if(flag==1)
        {
            $("Tr1").style.display='';
            $("Tr2").style.display='';
        }
        if(flag==3)
        {
            $("Tr3").style.display='';
            $("Tr4").style.display='';
        }
        else
        {
            $("Tr"+flag).style.display='';
        }
   }
</script>

