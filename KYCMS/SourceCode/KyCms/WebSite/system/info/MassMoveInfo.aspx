<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MassMoveInfo.aspx.cs" Inherits="System_news_MassMoveInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>内容批量移动</title>
    <link href="../Css/Default.css" rel="stylesheet" type="text/css" />

    <script src="../../JS/Common.js" type="text/javascript"></script>

    <script src="../../JS/XmlHttp.js" type="text/javascript"></script>

    <script language="javascript">
function btnSetColumn(val)
{
   var lst1=$("lsbColumnLeft");
   var length=lst1.options.length;
   var tt="";
   if(val=="ChooseAll")
   {
       for(var i=0;i<length;i++)
       {
            lst1.options[i].selected = true;
       }
   }
   else 
   {
       for(var i=0;i<length;i++)
       {
            lst1.options[i].selected = false;
       }
   }
}

    </script>

</head>
<body>
    <form id="form1" runat="server">
        <table width='99%' border='0' align='center' cellpadding='0' cellspacing='1' class='wzdh'>
            <tr class="title">
                <td height='22' colspan='3' align='center'>
                    <b>批量移动内容</b></td>
            </tr>
            <tr>
                <td class='bqright' style="height: 25px; width: 306px;">
                    <asp:RadioButton ID="rdBtnByArticleIdStr" GroupName="Left" runat="server" Text="指定内容ID"
                        Checked="true" />：<asp:TextBox ID="txtByArticleIdStr" runat="server" onkeyup="value=value.replace(/[^,\d]/g,'')"
                            Width="203px"></asp:TextBox></td>
                <td class='bqright' rowspan="4" style="width: 75px">
                    &nbsp; 移动到>>&nbsp;
                </td>
                <td rowspan="2">
                    请选择目标栏目：</td>
            </tr>
            <tr>
                <td class='bqright' style="height: 21px; width: 306px;">
                    <asp:RadioButton ID="rdBtnByColumnIdStr" GroupName="Left" runat="server" Text="指定栏目的内容" />：</td>
            </tr>
            <tr>
                <td class='bqright' style="height: 121px; width: 306px;">
                    <asp:ListBox ID="lsbColumnLeft" runat="server" Height="400px" Width="100%" SelectionMode="Single">
                    </asp:ListBox></td>
                <td style="height: 121px">
                    <asp:ListBox ID="lsbColumnRight" runat="server" Height="400px" Width="318px"></asp:ListBox></td>
            </tr>
        </table>
        <div class="tc">
            <asp:Button ID='Set' Text=' 执行批处理' runat="server" Style='cursor: hand;' OnClick="Set_Click"
                CssClass="btn" />&nbsp;
            <input id="Cancel" value="取 消" class="btn" type="button" onclick="javascript:history.back()" />
        </div>
    </form>
    <asp:Literal ID="litMsg" runat="server"></asp:Literal></body>
</html>
