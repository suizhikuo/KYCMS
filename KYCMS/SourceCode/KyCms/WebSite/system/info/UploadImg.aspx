<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UploadImg.aspx.cs" Inherits="system_info_UploadImg" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>上传图片</title>
    <link href="../Css/default.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <table cellpadding="0" cellspacing="1" style="width: 100%" class="bqright" id="uploadTable"
            runat="server">
            <tr>
                <td>
                    &nbsp;
                    <input id="File1" runat="server" type="file" />
                    <input id="File2" runat="server" type="file" /></td>
                <td>
                    <b>设置属性:</b>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                    <input id="File3" runat="server" type="file" />
                    <input id="File4" runat="server" type="file" /></td>
                <td>
                    <asp:CheckBox ID="IsWatermark" runat="server" Text="开启水印" Checked="True" /></td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                    <input id="File5" runat="server" type="file" />
                    <input id="File6" runat="server" type="file" /></td>
                <td>
                    <asp:CheckBox ID="IsNewSize" runat="server" Text="自定大小" />
                    宽:<asp:TextBox ID="txtMaxWidth" runat="server" Width="28px">0</asp:TextBox>px,高<asp:TextBox
                        ID="txtMaxHeight" runat="server" Width="28px">0</asp:TextBox>px</td>
            </tr>
            <tr>
                <td style="height: 22px">
                    &nbsp;
                    <input id="File7" runat="server" type="file" />
                    <input id="File8" runat="server" type="file" /></td>
                <td style="height: 22px">
                    <asp:CheckBox ID="IsBiLi" runat="server" Text="按比例缩放" />
                    比例值:<asp:TextBox ID="txtBili" runat="server" Width="28px">0</asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                    <input id="File9" runat="server" type="file" />
                    <input id="File10" runat="server" type="file" /></td>
                <td>
                    <asp:TextBox ID="imgNames" runat="server" Height="0" Width="0"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                    <input id="File11" runat="server" type="file" />
                    <input id="File12" runat="server" type="file" /></td>
                <td>
                </td>
            </tr>
            <tr>
                <td colspan="2" class="bqleft">
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Button ID="btnUpload" runat="server" Text="开始上传" CssClass="btn" OnClick="btnUpload_Click"
                        OnClientClick="this.value='上传中,请稍候...'" />
                    <asp:Button ID="btnReturnValue" CssClass="btn" runat="server" Text="上传完成,返回参数" OnClientClick="setParent();"
                        Visible="false" /><input id="returnImgType" type="hidden" runat="server" /></td>
                <td>
                </td>
            </tr>
        </table>
        <table id="imgTable" runat="server" visible="false">
            <tr>
                <td>
                    <asp:Image ID="ViewImg" runat="server" />
                </td>
            </tr>
        </table>
    </form>
    <asp:Literal ID="LitMsg" runat="server"></asp:Literal>
</body>
</html>

<script type="text/javascript">
  function setParent()
   {
   var imgNames=document.getElementById("imgNames").value;
    var obj=imgNames.split(',');
   
   //如果是批量上传
   try//IE
   {
        var openerObj=window.opener.form1.imgs;
        var I=openerObj.length;
        for(var i=0;i<obj.length;i++)
        {
            if(obj[i] != "")
            {
                openerObj.length++;
                openerObj.options[I].text=obj[i];
                openerObj.options[I].value=obj[i];
                I++;
            }
        }
        window.opener.document.getElementById("countImg").innerText=I;
     }
     catch(e)//Firefox
     {
        var openerObj=opener.document.getElementById('imgs');
        for(var i=0;i<obj.length;i++)
        {
            if(obj[i]!="")
            {
                openerObj.options.add(new Option(obj[i],obj[i]));
            }
        }
        window.opener.document.getElementById("countImg").innerHTML=openerObj.length;
     }      
      window.opener.document.getElementById('btnShowWindow').value='继续上传';
      window.close();
   } 
</script>

