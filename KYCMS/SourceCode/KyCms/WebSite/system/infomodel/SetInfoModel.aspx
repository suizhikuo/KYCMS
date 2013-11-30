<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SetInfoModel.aspx.cs" Inherits="system_infomodel_SetInfoModel" %>

<html>
<head runat="server">
    <link href="../css/default.css" type="text/css" rel="stylesheet" />

    <script type="text/javascript" src="../../js/Common.js"></script>

</head>
<body>

        <table width="99%" cellspacing="1" cellpadding="0" class="wzdh" align="center">
    <tr>
        <td height="24" width=20><img src="../images/skin/default/you.gif" align=absmiddle /></td>
        <td align=left style="padding-top:3px;" >您现在的位置：<a href="../SystemInfo.aspx">后台管理</a>  &gt;&gt; <a href="ModelList.aspx">模型管理</a>  &gt;&gt; <asp:Literal ID="Literal1" runat="server">新增</asp:Literal>模型</td>
        <td width="50" align="right"><img src="../images/skin/default/help.gif" align=absmiddle /></td>
    </tr>
</table>


    <form id="SetInfoModelForm" runat="server">
        <table class="border" cellspacing="1" cellpadding="0" width="99%" border="0" align="center">
            <tr class="tdbg">
                <td class="bqleft">
                    模型名称：
                </td>
                <td class="bqright">
                    <asp:TextBox ID="txtModelName" MaxLength="50" runat="server"></asp:TextBox><font
                        color="#ff0066">*</font>
                </td>
            </tr>
            <tr class="tdbg">
                <td class="bqleft">
                    模型描述：
                </td>
                <td class="bqright">
                    <asp:TextBox ID="txtModelDesc" Columns="50" Rows="4" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr class="tdbg">
                <td class="bqleft">
                    表名：
                </td>
                <td class="bqright">
                    <asp:Literal ID="litU" runat="server" Text="Ky_U_"></asp:Literal><asp:TextBox ID="txtTableName" runat="server" MaxLength="20" Columns="15"></asp:TextBox><font
                        color="#ff0066">*</font>
                </td>
            </tr>
            <tr class="tdbg">
                <td class="bqleft">
                    上传文件存放目录：
                </td>
                <td class="bqright">
                    upload/<asp:TextBox ID="txtUploadPath" runat="server" MaxLength="50" Columns="12"></asp:TextBox>
                    <span style="color: #ff0066">*</span> （只能以字母开头，由字母或数字组成，如修改此设置请手动修改对应文件夹名称）</td>
            </tr>
            <tr class="tdbg">
                <td class="bqleft">
                    允许上传的文件大小：
                </td>
                <td class="bqright">
                    只能上传小于或等于<asp:TextBox ID="txtUploadSize" runat="server" MaxLength="15" Text="0" Columns="8"></asp:TextBox>
                    KB的文件 <span style="color: #ff0066">*</span>（0KB表示不限制）</td>
            </tr>            
            <tr class="tdbg">
                <td class="bqleft">
                     开启手动编辑录入界面：
                </td>
                <td class="bqright">
                    <table>
                        <tr>
                            <td><asp:RadioButtonList ID="IsHtml" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Value="True">开启</asp:ListItem>
                                <asp:ListItem Selected="True" Value="False">关闭</asp:ListItem>
                    </asp:RadioButtonList></td>
                            <td>
                                <span style="color: #ff0066">*</span> 选择开启后，新增、编辑、删除任何字段后，都需要手动更改模型录入Html界面.</td>
                        </tr>
                    </table>
                    </td>
            </tr>
            <tr class="tdbg">
                <td class="tdheight" colspan="2" align="center">
                    <asp:Button ID="btnSubmit" runat="server" Text="确  定" OnClientClick="return CheckValidate()"
                        CssClass="btn" OnClick="btnSubmit_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input
                            id="btnNo" type="button" value="取　消" onclick="location.href='ModelList.aspx'"
                            class="btn" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>

<script type="text/javascript">
function CheckValidate()
{
    var txt = null;
    txt =  $("txtModelName").value;
    if(txt.trim().length==0)
    {
        alert('模型名称必须填写'); 
        return false; 
    }

    txt = $('txtTableName').value;
    if(txt.trim().length==0)
    {
        alert('表名称必须填写'); 
        return false; 
    }   
   var patt = /^[a-zA-Z0-9]+$/ 
    if(!patt.test(txt)) 
   {
        alert('表名称必须由字母或数字组成');
        return false; 
   }  
    txt = $('txtUploadPath').value;
    if(txt.trim().length==0)
    {
        alert('上传文件存放目录必须填写'); 
        return false; 
    } 
    var patt = /^[a-zA-Z][a-zA-Z0-9]*$/
    if(!patt.test(txt)) 
   {
        alert('存放目录必须以字母开头，由字母或数字组成');
        return false; 
   }
   txt = $('txtUploadSize').value;
   if(!CheckNumber(txt))
   {
        alert('允许上传的文件大小必须为0或正整数');
        return false; 
   }
   return true;
}
</script>

