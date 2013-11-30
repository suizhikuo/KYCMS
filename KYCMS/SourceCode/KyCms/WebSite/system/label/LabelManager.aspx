<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LabelManager.aspx.cs" Inherits="System_Label_LabelManager" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>标签管理</title>
    <link rel="stylesheet" href="../css/default.css" type="text/css" />
    <script type="text/javascript" src="../../JS/XmlHttp.js"></script>
    <script type="text/javascript" src="../../JS/Common.js"></script>    
    <script language="javascript" type="text/javascript">
       
        var obj;
        function ViewStyle(val)
        {
            var data = "";
             
            data = XmlHttpGetMethodText("getLabelContent.aspx?labelContentId="+val.replace("tb_",""));
            
          
            if(eval(val).style.display=="none")
            {
                $(val).style.display="";
                $(val).cells[0].innerHTML = data;

            }
            else
            {
                $(val).style.display="none";
                $(val).cells[0].innerHTML = "";
            }
            
        }        
        
        function checkedAll()
        {
            var s=document.getElementById("tableCheck").getElementsByTagName("INPUT");
            for(var i=0;i<s.length;i++)
            {
                if(s[i].type=="checkbox")
                {
                    s[i].checked=document.getElementById("chkBoxChooseAll").checked;
                }
            }
        }

		function copy(txt)
		{
			window.clipboardData.clearData(); 
			window.clipboardData.setData("Text", txt);
		}
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <!--top-->  
        <table width="99%" cellspacing="1" cellpadding="0" class="wzdh" align="center">
			<tr>
				<td height="24" width="20"><img src="../images/skin/default/you.gif" align="absmiddle" /></td>
				<td align="left" style="padding-top:3px;" >您现在的位置：<a href="../SystemInfo.aspx">后台管理</a> >> <a href="../template/CreateFolder.aspx">标签&模板管理</a> >> <a href="../Label/LabelManager.aspx">标签管理</a> >>  列表</td>
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
        <div style="margin-top:5px; text-align:center;">
            <table  width="99%" cellspacing="1" cellpadding="0" border="0" class="border">
             <asp:Repeater ID="repStyle" runat="server" OnItemCommand="repStyle_ItemCommand"  OnItemDataBound="repLabelContent_ItemDataBound">
                <HeaderTemplate>
                    <tr class="title" >
                        <td width="20%">类别编号</td><td width="30%">类别名称</td><td width="30%">描述</td><td width="20%">操作</td>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="tdbg" onmouseover="this.className='tdbgmouseover'" onmouseout="this.className='tdbg'">
						<a href="LabelManager.aspx?parentId=<%# Eval("LbCategoryID") %>&lbCategoryId=<%# Eval("LbCategoryID") %>">
							<td class="mouseStyle">
									<asp:Image ID="Image1" runat="server" ImageUrl="~/System/images/filetype/small_directory.gif" />
									<asp:HiddenField ID="hiddenLbCategoryId" runat="server" Value='<%# Eval("LbCategoryID") %>' />
							</td>
							<td class="mouseStyle"><%# Eval("Name") %></td>
							<td class="mouseStyle"><%# Eval("Desc") %></td>
						</a>
						<td>
							<a href="SetLabelCategory.aspx?lbCategoryId=<%# Eval("LbCategoryID") %>&parentId=<%# Eval("ParentID") %>">修改</a> | 
							<asp:LinkButton ID="linkbtnDelete" runat="server" CommandName="Delete" Enabled='<%#Convert.ToInt32(Eval("LbCategoryID"))==1?false:true %>'> 删除</asp:LinkButton>
						</td>
					</tr>
                </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
        
        <div style="margin-top:5px; text-align:center;">
            <table  width="99%" cellspacing="1" cellpadding="0" border="0" class="border" id="tableCheck">
             <asp:Repeater ID="repLabelContent" runat="server" OnItemCommand="repLabelContent_ItemCommand">
                <ItemTemplate>
                    <tr class="tdbg" onmouseover="this.className='tdbgmouseover'" onmouseout="this.className='tdbg'">
                        <a href="javascript:ViewStyle('tb_<%# Eval("LabelCategoryID")%>')">
                            <td class="mouseStyle" width="20%"><asp:Label ID="lblLabelCategoryId" runat="server" Text='<%# Eval("LabelCategoryID") %>'></asp:Label></td>
                            <td class="mouseStyle" width="30%"><%# Eval("Name") %></td>
                        </a>
							<td width="30%" align="left">
								<a id='<%# Eval("Name") %>' href="#" onclick="copy(this.id)">复制</a> 	| 
								<a href='<%#parentId!=1? "SetLabelContent.aspx?labelCategoryId="+ Eval("LabelCategoryID"):"AnomalyContent.aspx?labelCategoryId="+Eval("LabelCategoryID") %>'>修改标签</a> | 
								<asp:Literal ID="literModifyStyle" runat="server" Text='<%# ModifyStyle(Eval("Content")) %>'></asp:Literal>
								<asp:LinkButton ID="linkbtnDelete" runat="server" CommandName="Delete" OnClientClick="return confirm('你确定要删除吗？');"> 删除</asp:LinkButton>
							</td>
                            <td width="20%"><asp:CheckBox ID="CheckBox1" runat="server" /></td>
                    </tr>
                    <tr style="display:none" id='tb_<%# Eval("LabelCategoryID")%>'><td colspan="4" align="left" style="padding:10px;"></td></tr>
                </ItemTemplate>
                
                <FooterTemplate>
                    <tr>
						<td colspan="2" align="left"></td>
						<td align="right" colspan="2">&nbsp;&nbsp;
							<input id="chkBoxChooseAll" type="checkbox" onclick="checkedAll()" />选中所有&nbsp;
							<asp:Button ID="btnDeleteAll" runat="server" Text="删除" CssClass="btn" CommandName="DeleteAll" />&nbsp;
						</td>
					</tr>
                </FooterTemplate>
              </asp:Repeater>
				
              <tr>
				<td colspan="4">
					<webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" FirstPageText="首页"  LastPageText="尾页" NextPageText="下一页"  PageSize="20" HorizontalAlign="Right"  PrevPageText="上一页" ShowInputBox="Never" UrlPageIndexName="" ShowCustomInfoSection="Left" Width="99%" OnPageChanging="AspNetPager1_PageChanging"></webdiyer:AspNetPager>
				</td>
			 </tr>
            </table>

			<table width="99%" cellpadding="0" cellspacing="1" class="border" align="center">
				<tr>
					<td width="80" height="26" align="right" bgcolor="f0f0f0">
						<strong>标签名称：</strong></td>
					<td bgcolor="f0f0f0" align="left">
						<asp:TextBox ID="txtKeyword" runat="server" MaxLength="50"></asp:TextBox>
						<asp:Button runat="server" ID="btnGoSearch" Text="搜 索" CssClass="btn"
							OnClientClick="javascript:if($('txtKeyword').value==''){alert('请输入标签名');$('txtKeyword').focus();return false;}" OnClick="btnGoSearch_Click" /></td>
				</tr>
			</table>         
        </div>
        <!--endbody-->
    </div>
    </form>
</body>
</html>
