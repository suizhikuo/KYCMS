<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SetArticle.aspx.cs" Inherits="User_Info_SetArticle" %>

<%@ Import Namespace="Ky.BLL" %>
<%@ Import Namespace="System.Data" %>
<%@ Register TagPrefix="FCKeditorV2" Namespace="FredCK.FCKeditorV2" Assembly="FredCK.FCKeditorV2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>会员投搞页面</title>
    <link href="../Css/Default.css" rel="stylesheet" type="text/css" />

    <script src="../../JS/Common.js" type="text/javascript"></script>

    <script src="../../JS/XmlHttp.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
        <table width="99%" cellspacing="0" cellpadding="0" class="wzdh" align="center">
            <tr>
                <td width="27">
                    &nbsp;<img src="../images/skin/default/you.gif" width="17" height="16" /></td>
                <td>
                    您现在的位置： <a href="../Welcome.aspx">用户后台</a> &gt;&gt; <a href="InfoList.aspx?ChId=<%=ChId %>">
                        稿件管理</a> &gt;&gt; 添加<%=ChannelModel.TypeName %></td>
                <td width="116" align="center">
                    &nbsp;</td>
            </tr>
        </table>
        <table align="center" cellpadding="0" cellspacing="1" class="border" style="width: 99%">
            <tr>
                <td class="bqleft" style="height: 27px">
                    <%=ChannelModel.TypeName %>标题:</td>
                <td class="bqright" style="height: 27px">
                    <asp:TextBox ID="txtTitle" runat="server" Text='' Width="35%" MaxLength="30"></asp:TextBox>
                    <strong><span style="color: #ff0000">*&nbsp;</span></strong>
                    <input class="btn" onclick="CheckTitle()" type="button" value="<%=ChannelModel.TypeName %>标题重名检测" /></td>
            </tr>
            <tr>
                <td class="bqleft">
                    所属栏目:</td>
                <td class="bqright">
                    <select name="ddlColId">
                        <%
                            DataTable dt = ColumnBll.GetFormatListItemByChannelId(ChId);
                            Response.Write("<option value=\"-1\" selected>请选择栏目</ption>");
                            foreach (DataRow dr in dt.Rows)
                            {
                                string colName = dr["ColName"].ToString();
                                int colId = Convert.ToInt32(dr["ColId"]);
                                bool flag = ColumnBll.ChkHasChildByColId(colId);
                                bool columnFlag = UserGroupBll.Power_ColumnPower(ChId, colId, UserGroupModel.ColumnPower, 3);
                                if ((flag && !ColumnBll.GetColumn(colId).IsAllowAddInfo) || !columnFlag)
                                {
                                    if (colId == ColId)
                                        Response.Write("<option value=\"" + ColId + "\" style=\"background-color:red\" selected>" + colName + "</option>");
                                    else
                                        Response.Write("<option value=\"" + colId + "\" style=\"background-color:red\">" + colName + "</option>");
                                }
                                else
                                {
                                    if (colId == ColId)
                                        Response.Write("<option value=\"" + colId + "\" selected>" + colName + "</option>");
                                    else
                                        Response.Write("<option value=\"" + colId + "\">" + colName + "</option>");
                                };
                            }
                        %>
                    </select>
                </td>
            </tr>
            <tr>
                <td class="bqleft">
                    所属专栏:</td>
                <td class="bqright">
                    <asp:DropDownList ID="ddlUserCate" runat="server">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td class="bqleft">
                    TAG关键字:</td>
                <td class="bqright">
                    <asp:TextBox ID="txtTagNameStr" runat="server" Text='' Width="50%" MaxLength="100"></asp:TextBox><span class="tips">多个关键字用"<a
                        href="javascript:SepTagName()">&nbsp;<span style="color: #00f; font-weight: 600">|</span>&nbsp;</a>"分开(每个关键字长度不能超过20个字)</span>
                </td>
            </tr>
            <tr>
                <td class="bqleft">
                    <%=ChannelModel.TypeName %>来源:</td>
                <td class="bqright">
                    <asp:TextBox ID="txtSource" runat="server" Text='' Width="15%" MaxLength="50"></asp:TextBox>
                    <%=ChannelModel.TypeName %>作者:<asp:TextBox ID="txtAuthor" runat="server" Text='' Width="15%" MaxLength="50"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="bqleft">
                    <%=ChannelModel.TypeName %>导读:</td>
                <td class="bqright">
                    <asp:TextBox ID="txtShortContent" runat="server" Rows="6" TextMode="MultiLine" Width="70%"></asp:TextBox></td>
            </tr>
            <tbody id="ShowCommType">
                <tr id="ZhuangX">
                    <td class="bqleft">
                        <%=ChannelModel.TypeName %>内容:</td>
                    <td class="bqright">
                        <asp:TextBox ID="FilePicPath" runat="server" Text="" Style="display: none"></asp:TextBox>
                        <FCKeditorV2:FCKeditor ID="txtContent" runat="server" Height="300px">
                        </FCKeditorV2:FCKeditor>
                    </td>
                </tr>
                <tr>
                    <td class="bqleft">
                        阅读收取金币数:
                    </td>
                    <td class="bqright">
                        <asp:TextBox ID="txtPoint" runat="server" Width="70px" onkeyup="value=value.replace(/[^\d]/g,'')"
                            MaxLength="10">0</asp:TextBox>
                        <strong><span style="color: #ff0000">* </span></strong><span class="STYLE2">(阅读本文需要消耗多少<%=SiteModel.GUnitName %>金币)<asp:HiddenField
                            ID="hfIsOpened" runat="server" Value="2" />
                        </span></td>
                </tr>
            </tbody>
        </table>
        <div style="height: 30px; width: 99%; margin-top: 10px; text-align: center">
            <asp:Button ID="btnAddCateSave" runat="server" Text="发 布" OnClick="btnAddCateSave_Click"
                CommandArgument="Save" CssClass="btn" OnClientClick="return CheckValidate()" />
            &nbsp;&nbsp;<asp:Button ID="btnSaveCaoGao" runat="server" Text=" 保存草稿" CommandArgument="Save_C"
                OnClick="btnAddCateSave_Click" CssClass="btn" OnClientClick="return CheckValidate()" />&nbsp;
            <asp:Button ID="btnUpdate" runat="server" Text=" 保存修改" CommandArgument="Save_Update"
                OnClick="btnAddCateSave_Click" CssClass="btn" OnClientClick="return CheckValidate()"
                Visible="false" />&nbsp;
            <input type="button" id="btnCanCel" name="btnCanCel" value="取 消" class="btn" onclick="javascript:history.back();" />
            &nbsp;&nbsp;
        </div>
        <asp:Label ID="litMsg" runat="server" Text="">
        </asp:Label>
    </form>
</body>
</html>

<script language="javascript" type="text/javascript">
//检测文章标题
var typeName='<%=ChannelModel.TypeName %>'
function CheckTitle()
{
    var title = $("txtTitle").value.trim();
    
    if(title.length==0) 
    {
        alert("检测的"+typeName+"标题必须填写") ;
        return;
    } 
    var flag = CheckHas("../../system/common/CheckHas.aspx",title,"Title","KyArticle")
    if(!flag)
    {
        alert("该"+typeName+"标题不存在"); 
    }  
    else
    {
         alert("该"+typeName+"标题已经存在"); 
    }   

}
//分隔关键字
function SepTagName()
{
    $("txtTagNameStr").focus();
   if(document.selection)
   {
     var range=document.selection.createRange();
     range.text="|";
   } 
}

//校验文本框的输入
function CheckValidate()
{
    var title = $("txtTitle").value.trim();
//var patt=/http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?/
   if(title.length==0)
   {
        alert(""+typeName+"标题必须填写");
        return false;
   }
   if($('ddlColId').value=="-1")
   {
        alert("请选择栏目");
        return false;
   }
   if($('ddlColId').options[$('ddlColId').selectedIndex].style.backgroundColor.trim().length!=0)
   {
        alert("所选择的栏目不能添加/修改"+typeName+"");
        return false;
   }
   if($("txtPoint").value.trim().length==0)
   {
         alert("阅读收取金币数必须填写");
        return false;
   }
}
</script>

