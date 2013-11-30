<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SetDownLoadServer.aspx.cs"
    Inherits="System_down_DownLoadServer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>下载服务器管理</title>
    <link href="../css/default.css" type="text/css" rel="stylesheet" />

    <script src="../../JS/Common.js" type="text/javascript"></script>

    <script src="../../JS/XmlHttp.js" type="text/javascript"></script>

    <script type="text/javascript">
    function ChangType()
   {
        var temp=$('ddlDownServerType').value;
        if(temp>0)
        {
            ShowAddName.style.display="";
        }
        else
        {
            ShowAddName.style.display="none";
            IsUnion.style.display="none";
            $('txtUnionId').value="";
        }
   } 
   function ShowIsOuter(obj)
   {
        obj>0?IsUnion.style.display="":IsUnion.style.display="none";
   }
//校验文本框的输入
    function CheckValidate()
    {
        var type=$('ddlDownServerType').value;
        if(type<0)
        {
            if($('txtDownServerName').value.trim().length==0)
            {
                alert("服务器类别名称必须填写");
               $('txtDownServerName').focus(); 
               return false; 
            }
        }
        if(type>0)
        {
            if($('txtDownServerName').value.trim().length==0)
            {
                alert("服务器名称必须填写");
               $('txtDownServerName').focus(); 
               return false; 
            }
            if($('txtDownServerDir').value.trim().length==0)
            {
                alert("服务器路径必须填写");
               $('txtDownServerDir').focus(); 
               return false; 
            }
        }
    }
    </script>

</head>
<body onload="ChangType()">
    <form id="form1" runat="server">
        <table width="99%" cellspacing="1" cellpadding="0" class="wzdh" align="center">
            <tr>
                <td width="27" height="24">
                    &nbsp;<img src="../images/skin/default/you.gif" width="17" height="16" /></td>
                <td>
                    您现在的位置：<a href="../SystemInfo.aspx">后台管理</a> &gt;&gt; <a href="DownLoadServerList.aspx">
                        镜像服务器管理</a> &gt;&gt; 设置服务器
                </td>
                <td width="116" align="center">
                    &nbsp;</td>
            </tr>
        </table>
        <table width="99%" cellspacing="1" cellpadding="0" class="border" align="center">
            <tr class="wzlist">
                <td align="left">
                    <a href="DownLoadServerList.aspx">镜像服务器列表管理</a> | 设置镜像服务器</td>
            </tr>
        </table>
        <table width="99%" border="0" cellpadding="0" cellspacing="1" class="border" align="center">
            <tbody>
                <tr>
                    <td class="bqleft">
                        所属类别：</td>
                    <td class="bqright">
                        <asp:DropDownList ID="ddlDownServerType" runat="server" onchange="ChangType()">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td class="bqleft">
                        服务器名称：</td>
                    <td class="bqright">
                        <asp:TextBox ID="txtDownServerName" MaxLength="200" runat="server"></asp:TextBox></td>
                </tr>
            </tbody>
            <tbody id="ShowAddName" style="display: none">
                <tr>
                    <td class="bqleft">
                        服务器路径：</td>
                    <td class="bqright">
                        <asp:TextBox ID="txtDownServerDir" MaxLength="200" runat="server">http://</asp:TextBox></td>
                </tr>
                <tr>
                    <td class="bqleft">
                        服务器状态：</td>
                    <td class="bqright">
                        <asp:RadioButton ID="rdBtnIsOpened1" runat="server" Text="开启" GroupName="IsOpened"
                            Checked="true" />
                        <asp:RadioButton ID="rdBtnIsOpened0" runat="server" Text="禁用" GroupName="IsOpened" />
                    </td>
                </tr>
              </tbody>
              <tbody  style="display:none">
                <tr>
                    <td class="bqleft">
                        是否外部链接地址：</td>
                    <td class="bqright">
                        <asp:RadioButton ID="rdBtnIsOuter0" runat="server" Checked="true" GroupName="IsOuter"
                            Text="否" onclick="ShowIsOuter(0)" />
                        <asp:RadioButton ID="rdBtnIsOuter1" runat="server" GroupName="IsOuter" Text="WEB迅雷专用下载地址"
                            onclick="ShowIsOuter(1)" />
                        <asp:RadioButton ID="rdBtnIsOuter2" runat="server" GroupName="IsOuter" Text="FLASHGET(快车)专用下载地址"
                            onclick="ShowIsOuter(2)" />
                    </td>
                </tr>
                <tr style="display: none" id="IsUnion" runat="server">
                    <td class="bqleft">
                        联盟ID：</td>
                    <td class="bqright">
                        <asp:TextBox ID="txtUnionId" MaxLength="200" runat="server" Width="231px"></asp:TextBox>
                    </td>
                </tr>
            </tbody>
            <tr>
                <td class="bqleft">
                </td>
                <td class="bqright">
                    <asp:Button runat="server" CssClass="btn" Text='确定添加' ID="SaveAs" OnClick="SaveAs_Click"
                        OnClientClick="return CheckValidate()" />
                    &nbsp; &nbsp;<input type="button" id="CanCel" class="btn" value='取消返回' onclick='javascript:history.back();' />
                    <asp:Literal ID="LitMsg" runat="server"></asp:Literal></td>
            </tr>
        </table>
    </form>
</body>
</html>
