<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StyleSearch.aspx.cs" Inherits="system_label_StyleSearch" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>搜索样式</title>
    <link rel="stylesheet" href="../css/default.css" type="text/css" />
    <script type="text/javascript" src="../../JS/XmlHttp.js"></script>
    <script type="text/javascript" src="../../JS/Common.js"></script>    
    <script language="javascript" type="text/javascript">
         var obj;
        function ViewStyle(val)
        {
            var data = "";
             
            data = XmlHttpGetMethodText("getStyleContent.aspx?styleId="+val.replace("tb_",""));
            
          
            if(eval(val).style.display=="none")
            {
                $(val).style.display="";
                $(val).cells[0].innerHTML = data;

            }
            else
            {
                $(val).style.display="none";
                $(val).cells[0].innerHTML = "";
;
            }            
        }

		var menuHit=0;
		function ShowModelList()
		{
			if(menuHit==0)
			{
				modelMenuList.style.display="";
				menuHit=menuHit+1;
			}
			else
			{
				modelMenuList.style.display="none";	
				menuHit=menuHit-1;
			}
		}

		function showMenu()
		{
				modelMenuList.style.display="";
				menuHit=1;
		}
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <!--top-->  
        <table width="99%" cellspacing="1" cellpadding="0" class="wzdh" align="center">
			<tr>
				<td height="24" width="20"><img src="../images/skin/default/you.gif" align="absmiddle" /></td>
				<td align="left" style="padding-top:3px;" >您现在的位置：<a href="../SystemInfo.aspx">后台管理</a> >> <a href="../template/CreateFolder.aspx">标签&模板管理</a> >> <a href="../Label/LabelManager.aspx">标签管理</a> >> 搜索样式</td>
				<td width="50" align="right"><img src="../images/skin/default/help.gif" align="absmiddle" /></td>
			</tr>
		</table>
      
        <table width="99%" cellspacing="1" cellpadding="0"  class="border" align="center">
            <tr class="wzlist">
                <td  height="26" align="left">
					<asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/System/Label/LabelManager.aspx">标签管理首页</asp:HyperLink> | 
					<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/System/Label/SetLabelCategory.aspx">新增标签分类</asp:HyperLink> | 
					<asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/System/Label/setLabelContent.aspx" >创建新标签</asp:HyperLink> | 
					<asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/system/label/AnomalyContent.aspx">创建不规则标签</asp:HyperLink> | 
					<a href="superlabellist.aspx" style="color:red">超级标签</a> | <a href="#" onclick="javascript:window.history.back();">返回</a>
				</td>
                <td align="right">
                    <asp:DropDownList ID="ddlRedirectPage" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlRedirectPage_SelectedIndexChanged">
                        <asp:ListItem>跳转类型至…</asp:ListItem>
                        <asp:ListItem Value="StyleManager.aspx">样式管理</asp:ListItem>
                        <asp:ListItem Value="LabelManager.aspx">标签管理</asp:ListItem>
                        <asp:ListItem Value="../Template/CreateFolder.aspx">模板管理</asp:ListItem>
                    </asp:DropDownList>&nbsp;
                </td>
            </tr>
        </table>
        <!--endtop-->
        
        <!--body-->
        <table  width="99%" cellspacing="1" cellpadding="0" border="0" class="border" align="center">
         <asp:Repeater ID="repLabelContent" runat="server" OnItemCommand="repLabelContent_ItemCommand">
            <ItemTemplate>
                <tr class="tdbg" onmouseover="this.className='tdbgmouseover'" onmouseout="this.className='tdbg'">
					<a href="javascript:ViewStyle('tb_<%# Eval("StyleID")%>')">
						<td  width="10%" class="mouseStyle"><asp:Label ID="lbStyleId" runat="server" Text='<%# Eval("StyleID")%>'></asp:Label></td>
						<td width="30%" class="mouseStyle"><%#Eval("Name") %></td>
						<td width="30%" class="mouseStyle"><%# Get_Model_Name(Eval("Type"))%></td>
						<td width="20%" class="mouseStyle">查看样式效果</td>
				   </a>
						<td  width="10%">
							<a href='SetStyle.aspx?StyleId=<%# Eval("StyleID")%>&modelId=<%# Eval("Type") %>'>修改</a> | 
							<asp:LinkButton ID="linkbtnDelete" runat="server" CommandName="Delete" OnClientClick="return confirm('你确定要删除吗？');"> 删除</asp:LinkButton>
						</td>
				</tr>
                <tr style="display:none" id='tb_<%# Eval("StyleID")%>'><td colspan="5" align="left" style="padding:10px;"></td></tr>
            </ItemTemplate>
            </asp:Repeater>

              <tr>
				<td colspan="4">
					<webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" FirstPageText="首页"  LastPageText="尾页" NextPageText="下一页"  PageSize="20" HorizontalAlign="Right"  PrevPageText="上一页" ShowInputBox="Never" UrlPageIndexName="" ShowCustomInfoSection="Left" Width="99%" OnPageChanging="AspNetPager1_PageChanging"></webdiyer:AspNetPager>
				</td>
			 </tr>	
        </table>
       
        
    </form>
</body>
</html>
