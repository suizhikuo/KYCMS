<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChannelList.aspx.cs" Inherits="System_KyChanel" %>

<%@ Import Namespace="Ky.BLL" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>频道管理</title>
    <link href="../css/default.css" type="text/css" rel="stylesheet">
    <script src="../../js/Common.js" ></script>
    <script >
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
		function SetChannelType(val)
		{
		    var c = WinOpen("SetChannelType.aspx?ChId="+val,"setChType",250,50);
		    c.focus(); 
		}
    </script> 
</head>
<body>
    <form id="form1" runat="server">
        <table width="99%" cellspacing="1" cellpadding="0" class="wzdh" align="center">
            <tr>
                <td height="24" width="20">
                    <img src="../images/skin/default/you.gif" align="absmiddle" /></td>
                <td align="left" style="padding-top: 3px;">
                    您现在的位置：<a href="../SystemInfo.aspx">后台管理</a> >> 频道管理</td>
                <td width="50" align="right">
                    <img src="../images/skin/default/help.gif" align="absmiddle" /></td>
            </tr>
        </table>
        <table width="99%" cellspacing="1" cellpadding="0" class="border" align="center">
            <tr class="wzlist">
                <td align="left">
                     <span style="border:solid 1px #CCCCCC; padding:0px 0px 0px 0px ; background-color:#FFFFFF;" runat="server" id="spanAddChannel"><a href="#" onclick="ShowModelList()">&nbsp;添加频道&nbsp;<img id="imgdrp" style="vertical-align:middle;" src="../images/skin/default/sitelist.gif" alt="" border="0" /></a></span>
                     <asp:Literal runat="server" ID="litAddChannel"></asp:Literal>
                     </td>
                <td align="right" width="300">
                    <a href="../create/CreateNews.aspx?modelId=1">生成管理</a> | <a href="SinglePageList.aspx">单页管理</a> | <a href="RecycleChannel.aspx">回收站管理</a>
                    | <a href="MoveExpireArticle.aspx">归档管理</a>&nbsp;</td>
            </tr>
        </table>
        <table width="99%" align="center" class="border" cellspacing="1" cellpadding="0">
            <asp:Repeater ID="repChannel" runat="server" OnItemCommand="repChannel_ItemCommand">
                <HeaderTemplate>
                    <tr class="title">
                        <td align="center" width="5%" height="20">
                            <strong>编号</strong></td>
                        <td align="center" width="14%">
                            <strong>频道名称</strong></td>
                        <td align="center" width="14%">
                            <strong>所属模型</strong></td>
                        <td align="center" width="14%">
                            <strong>站点目录</strong></td>
                        <td align="center" width="8%">
                            <strong>项目名称</strong></td>
                        <td align="center" width="8%">
                            <strong>生成方式</strong></td>
                        <td align="center" width="8%">
                            <strong>站点状态</strong></td>
                         <td align="center" width="8%">
                            <strong>是否认证</strong></td>
                        <td align="center" width="21%">
                            <strong>操作</strong></td>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="tdbg" onmouseover="this.className='tdbgmouseover'" onmouseout="this.className='tdbg'">
                        <td align="center">
                            <asp:Label ID="ChId" runat="server" Text='<%# Eval("ChId") %>'></asp:Label></td>
                        <td align="center">
                            <a href='ColumnList.aspx?ChId=<%#Eval("ChId") %>'>
                                <%#Eval("ChName") %>
                            </a>
                        </td>
                        <td align="center">
                            <%#Eval("ModelName")%></td>
                        <td align="center">
                            <%# Eval("DirName") %>
                        </td>
                        <td align="center">
                            <%# Eval("TypeName") %>
                        </td>
                        <td align="center">
                            <%# GetIsStaticType(Eval("IsStaticType")) %>
                        </td>
                        <td align="center">
                            <%# GetIsDisabled(Eval("IsDisabled"))%>
                        </td>
                        <td align="center">
                            <%# (bool)Eval("IsOpened")?"开放":"认证"%>
                        </td>
                        <td align="center">
                            <a href='../preview/PreChannel.aspx?ChId=<%#Eval("ChId") %>' target="_blank">预览</a> | <a
                                href='SetChannel.aspx?ChId=<%#Eval("ChId") %>&ChType=<%#Eval("ChType") %>'>修改</a> | <a href="javascript:SetChannelType(<%#Eval("ChId") %>)">分类</a> |
                            <asp:LinkButton ID="btnDisabled" runat="server" Text='<%# GetBtnText(Eval("IsDisabled")) %>'
                                CommandName="state" />
                            |
                            <asp:LinkButton ID="btnDelete" runat="server" Text="删除" CommandName="delete" OnClientClick="return confirm('你确认将该频道删除到回收站?\r\n注意：相关栏目和内容也将一起删除到回收站')" />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
       
       
       <div id="modelMenuList" style="display:none;position:absolute;top:0px; margin-top:62px; margin-left:27px; width:100px; padding:0px;" class="wzlist border" onmouseout="ShowModelList()">
		<div style="width:100%; height:100%; padding:0px;">
			<table cellpadding="0" border="0" cellspacing="0" width="100%">
				<asp:Repeater runat="server" ID="repModelList">
					<ItemTemplate>
						<tr>
							<a href="SetChannel.aspx?ChType=<%# Eval("Id") %>">
								<td style="cursor:hand;" onmouseover="showMenu();javascript:this.style.backgroundColor='#CCCCCC'" onmouseout="showMenu();javascript:style.backgroundColor='#eef6fb'">&nbsp;&nbsp;<%# Eval("DicName") %>
								</td>
							</a>
						</tr>
					</ItemTemplate>
				</asp:Repeater>
			</table>
		</div>
	</div> 
    </form>
</body>
</html>
