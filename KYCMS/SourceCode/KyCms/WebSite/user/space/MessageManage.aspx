<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MessageManage.aspx.cs" Inherits="user_space_MessageManage" %>

<%@ Import Namespace="Ky.Common" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<link href="../Css/default.css" type="text/css" rel="stylesheet" />

<script type="text/javascript" src="../../JS/XmlHttp.js"></script>

<script type="text/javascript" src="../../JS/Common.js"></script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>留言管理</title>
</head>
<body>
    <form id="form1" runat="server">
        <table width="99%" cellspacing="1" cellpadding="0" class="wzdh" align="center">
            <tr>
                <td width="27" >
                    <img src="../images/skin/default/you.gif" width="17" height="16"></td>
                <td>
                    您现在的位置： <a href="../welcome.aspx">用户后台</a> &gt;&gt; 留言管理
                </td>
            </tr>
        </table>
        <table width="99%" cellspacing="1" cellpadding="0" class="border wzdh" align="center">
            <tr>
                <td>
                    &nbsp;<a href="RegSpace.aspx">空间管理</a> | <a href="AlbumManage.aspx">相册管理</a> | 留言管理
                </td>
            </tr>
        </table>
        <div style="margin-left: 4px;" class="border">
            <div class="title">
                留言管理</div>
                <asp:Label ID="lbMsg" runat="server" Text=""></asp:Label>
            <asp:GridView ID="gvMsg" runat="server" AutoGenerateColumns="False" Width="100%"
                DataKeyNames="Id" CellSpacing="1" GridLines="None" OnRowDataBound="gvMsg_RowDataBound"
                OnRowDeleting="gvMsg_RowDeleting">
                <Columns>
                    <asp:TemplateField HeaderText="选中">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkBoxSel" runat="server" />
                            <%--<td id="td_<%#Eval("Id") %>" style="display:none; background-color:#FFF" colspan="">fdfdsf<br />sdfdssdfsdfd<br /><br />sdfds<br />
                            </td>--%>
                        </ItemTemplate>
                        <ItemStyle Width="5%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="发表人">
                        <ItemTemplate>
                                <a href="ResumeMsg.aspx?Id=<%#Eval("Id") %>&option=look" title='点击查看留言内容'>
                                    <%# Function.HtmlEncode(Eval("AnounName")).Replace("\r\n", "<br />").Replace(" ", "&nbsp;&nbsp;")%>
                                </a>
                        </ItemTemplate>
                        <ItemStyle Width="15%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="留言标题">
                        <ItemTemplate>
                           <a href="ResumeMsg.aspx?Id=<%#Eval("Id") %>&option=look" title='点击查看留言内容'>
                                <%#Function.HtmlEncode(Eval("Title")).Replace("\r\n","<br />").Replace(" ","&nbsp;&nbsp;")%>
                            </a>
                            <%#IsResume(Eval("IsResume")) %>
                        </ItemTemplate>
                        <ItemStyle Width="20%" HorizontalAlign="Left" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="发表时间">
                        <ItemTemplate>
                            <%#Eval("PostTime") %>
                        </ItemTemplate>
                        <ItemStyle Width="20%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="主页">
                        <ItemTemplate>
                            <a href='<%#Eval("HomePage") %>'>访问</a>
                        </ItemTemplate>
                        <ItemStyle Width="10%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="管理操作">
                        <ItemTemplate>
                        <a href='ResumeMsg.aspx?Id=<%#Eval("Id") %>&option=look'>查看</a>
                            <a href='ResumeMsg.aspx?Id=<%#Eval("Id") %>&option=resume'>回复</a>
                            <asp:LinkButton ID="lkBtnDel" runat="server" OnClientClick="return confirm('你确定要删除此留言吗')"
                                CommandName="Delete">删除</asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle Width="15%" />
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle CssClass="title" />
                <RowStyle CssClass="tdbg" />
            </asp:GridView>
            <div class="fl">
                &nbsp;&nbsp;<input type='checkbox' onclick="SetCheckBox(this)" id="chkBoxChooseAll" /><label
                    for="chkBoxChooseAll">全选</label></div>
            <asp:Button ID="btnDeleteAll" runat="server" Text="删除选定的留言" OnClientClick="return CheckDelete(this)"
                CssClass="btn" UseSubmitBehavior="true" OnClick="btnDeleteAll_Click" /><table cellpadding="0"
                    cellspacing="0" align="center" width="99%">
                    <tr>
                        <td>
                            <webdiyer:AspNetPager ID="AspNetPager" runat="server" AlwaysShow="True" FirstPageText="首页"
                                LastPageText="尾页" NextPageText="下一页" OnPageChanging="AspNetPager_PageChanging"
                                PrevPageText="上一页" ShowCustomInfoSection="Left" ShowInputBox="Never" CustomInfoSectionWidth="10%"
                                ShowNavigationToolTip="True" Width="99%" HorizontalAlign="Right" PageSize="20">
                            </webdiyer:AspNetPager>
                        </td>
                    </tr>
                </table>
        </div>
        <asp:Literal ID="litMsg" runat="server"></asp:Literal>
    </form>
</body>
</html>

<script language="javascript">
function SetCheckBox(o)
{
    var as = o.form.elements ;
    for (i = 0; i < as.length ; i ++) 
    {
	    if (as[i].type.toLowerCase() == "checkbox" && as[i] != o) as[i].checked = o.checked;
    }
}
function CheckDelete(o)
{
   var sel=o.form.elements;
   var flag=false;
   for(i=0;i<sel.length;i++)
   {
       if(sel[i].type=="checkbox")
       {
           if(sel[i].checked)
           {
            flag=true;
           }
       }
   }
   if(!flag)
   {
    alert("请选择删除项");
        return false; 
   }
   return confirm("你确定要删除所有选定的留言吗");
}
function ShowMsgContent(val)
{
    var data = "";
   
   data = XmlHttpGetMethodText("GetMsgContent.aspx?MsgId="+val.replace("td_","")) ;
   
   if(eval(val).style.display=="none")
   {
        $(val).style.display="";
        
   }
   else
   {
        $(val).style.display="none";
   }
}
</script>

