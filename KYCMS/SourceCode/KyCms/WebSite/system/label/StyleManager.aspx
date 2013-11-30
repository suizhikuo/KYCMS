<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StyleManager.aspx.cs" Inherits="System_Label_StyleManager" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>样式管理</title>
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
    <div>
		<table width="99%" cellspacing="1" cellpadding="0" class="wzdh" align="center">
			<tr>
				<td height="24" width="20"><img src="../images/skin/default/you.gif" align="absmiddle" /></td>
				<td align="left" style="padding-top: 3px;">
						您现在的位置：<a href="../SystemInfo.aspx">后台管理</a> 
						>><a href="../template/CreateFolder.aspx">	标签&模板管理</a> 
						>><a href="../Label/StyleManager.aspx">样式管理</a> 
						>> 列表
				</td>
				<td width="50" align="right">
					<img src="../images/skin/default/help.gif" align="absmiddle" />
				</td>
			</tr>
		</table>
      
        <table width="99%" cellspacing="1" cellpadding="0"  class="border" align="center">
            <tr class="wzlist">
                <td  height="26" align="left">&nbsp;
					<asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/System/Label/StyleManager.aspx">样式管理首页</asp:HyperLink> | 
					<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/System/Label/AddStyleType.aspx">新增样式分类</asp:HyperLink> | 
					<span style="border:solid 1px #CCCCCC; padding:0px 0px 0px 0px ; background-color:#FFFFFF;"><a href="#" onclick="ShowModelList()">&nbsp;创建新样式 &nbsp;<img id="imgdrp" style="vertical-align:middle;" src="../images/skin/default/sitelist.gif" alt="" border="0" /></a></span> | 
					<a href="#" onclick="javascript:window.history.back();">返回</a>
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
        <div style="margin-top:5px; text-align:center;">
            <table width="99%" cellspacing="1" cellpadding="0" border="0" class="border">
                <asp:Repeater ID="repStyleCategory" runat="server" OnItemCommand="repStyleCategory_ItemCommand">
                    <HeaderTemplate>
                        <tr class="title">
                            <td width="10%">样式编号</td>
							<td width="30%">样式名称</td>
							<td width="30%">所属模块</td>
							<td width="20%">查看样式效果</td>
							<td width="10%">操作</td>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr class="tdbg" onmouseover="this.className='tdbgmouseover'" onmouseout="this.className='tdbg'" style="cursor:hand;">
                                <a href="StyleManager.aspx?parentId=<%#Eval("StyleCategoryId") %>">
									<td width="10%">
										<asp:Image ID="Image1" runat="server" ImageUrl="~/System/images/filetype/small_directory.gif" />
											<asp:HiddenField ID="StyleCategoryId" runat="server" Value=<%#Eval("StyleCategoryId") %> />
									</td>
									<td width="30%"><%# Eval("Name") %></td>
									<td><%#Eval("Desc") %></td>
									<td></td>
								</a>
									<td>
										<a href="AddStyleType.aspx?styleCategoryId=<%#Eval("StyleCategoryId") %>">修改</a> | 
										<asp:LinkButton ID="linkbtnDelete" runat="server" CommandName="Delete" OnClientClick="return confirm('你确定要删除吗？');"> 删除</asp:LinkButton>									</td>
						 </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
	
        <div style="margin-top:-4px; text-align:center;">
        <table  width="99%" cellspacing="1" cellpadding="0" border="0" class="border">
         <asp:Repeater ID="repStyle" runat="server" OnItemCommand="repStyle_ItemCommand">
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
        </table>

		<table width="99%" cellpadding="0" cellspacing="1" class="border" align="center">
			<tr>
				<td width="80" height="26" align="right" bgcolor="f0f0f0">
					<strong>样式名称：</strong></td>
				<td bgcolor="f0f0f0" align="left">
					<asp:TextBox ID="txtKeyword" runat="server" MaxLength="50"></asp:TextBox>
					<asp:Button runat="server" ID="btnGoSearch" Text="搜 索" CssClass="btn"
						OnClientClick="javascript:if($('txtKeyword').value==''){alert('请输入标签名');$('txtKeyword').focus();return false;}" OnClick="btnGoSearch_Click" /></td>
			</tr>
		</table>
        </div>
    </div>

<div id="modelMenuList" style="display:none;position:absolute;top:0px; margin-top:70px; margin-left:210px; width:100px; padding:0px;" class="wzlist border" onmouseout="ShowModelList()">
		<div style="width:100%; height:100%; padding:0px;">
			<table cellpadding="0" border="0" cellspacing="0" width="100%">
				<asp:Repeater runat="server" ID="repModelList">
					<ItemTemplate>
						<tr>
							<a href="SetStyle.aspx?modelId=<%# Eval("ModelId") %>">
								<td style="cursor:hand;" onmouseover="showMenu();javascript:this.style.backgroundColor='#CCCCCC'" onmouseout="showMenu();javascript:style.backgroundColor='#eef6fb'">&nbsp;&nbsp;<%# Eval("ModelName") %>
								</td>
							</a>
						</tr>
					</ItemTemplate>
					<FooterTemplate>
						<tr>
							<a href="SetStyle.aspx?modelId=0">
								<td style="cursor:hand;" onmouseover="showMenu();javascript:this.style.backgroundColor='#CCCCCC'" onmouseout="showMenu();javascript:style.backgroundColor='#eef6fb'">&nbsp;&nbsp;通用样式
								</td>
							</a>
						</tr>
					</FooterTemplate>
				</asp:Repeater>
			</table>
		</div>
	</div>	
    </form>
</body>
</html>
