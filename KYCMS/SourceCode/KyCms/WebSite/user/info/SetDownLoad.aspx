<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SetDownLoad.aspx.cs" Inherits="user_info_SetDownLoad" %>
<%@ Import Namespace="Ky.BLL" %>
<%@ Import Namespace="System.Data" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>下载添加页面</title>
    <link href="../Css/default.css" rel="stylesheet" type="text/css" />

    <script src="../../JS/Common.js" type="text/javascript"></script>

    <script src="../../JS/XmlHttp.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
        <table width="99%" border="0" cellpadding="0" cellspacing="0" class="wzdh" align="center">
            <tr>
                <td width="27">
                    &nbsp;<img src="../images/skin/default/you.gif" width="17" height="16" /></td>
                <td>
                    您现在的位置： <a href="../Welcome.aspx">用户后台</a> &gt;&gt; <a href="InfoList.aspx?ChId=<%=ChId %>">
                        稿件管理</a> &gt;&gt; 添加<%=ChannelModel.TypeName %></td>
                <td width="116" align="center" style="height: 26px">
                    &nbsp;</td>
            </tr>
        </table>
        <table cellpadding="0" cellspacing="1" class="border" align="center">
            <tr>
                <td class="bqleft">
                    所属栏目：</td>
                <td class="bqright">
                    <select id="ddlColId" name="ddlColId">
                        <%
                            DataTable dt = ColumnBll.GetFormatListItemByChannelId(ChId);
                            foreach (DataRow dr in dt.Rows)
                            {
                                string colName = dr["ColName"].ToString();
                                int colId = Convert.ToInt32(dr["ColId"]);
                                bool flag = ColumnBll.ChkHasChildByColId(colId);
                                if (flag && !ColumnBll.GetColumn(colId).IsAllowAddInfo)
                                {
                                    if (ColId == colId)
                                    {

                                        Response.Write("<option value=\"" + colId + "\" style=\"background-color:red\" selected>" + colName + "</option>");
                                    }
                                    else
                                        Response.Write("<option value=\"" + colId + "\" style=\"background-color:red\">" + colName + "</option>");
                                }
                                else
                                {
                                    if (ColId == colId)
                                        Response.Write("<option value=\"" + colId + "\" selected>" + colName + "</option>");
                                    else
                                        Response.Write("<option value=\"" + colId + "\">" + colName + "</option>");
                                }
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
                    <%=ChannelModel.TypeName %>名称：</td>
                <td class="bqright">
                    <asp:TextBox ID="txtSoftName" runat="server" Width="30%" MaxLength="30"></asp:TextBox> <input type="button" class="btn" value="<%=ChannelModel.TypeName %>名称重名检测" onclick="CheckTitle()" />
                    <%=ChannelModel.TypeName %>版本号：<asp:TextBox ID="txtSoftEdition" runat="server" Width="15%"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                <td class="bqleft">
                    <%=ChannelModel.TypeName %>性质：</td>
                <td class="bqright">
                    <%=ChannelModel.TypeName %>类别<asp:DropDownList ID="ddlSoftType" runat="server">
                    </asp:DropDownList>
                    <%=ChannelModel.TypeName %>
                    语言<asp:DropDownList ID="ddlSoftLanguage" runat="server">
                    </asp:DropDownList>
                    授权方式<asp:DropDownList ID="ddlSoftWarrantType" runat="server">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td class="bqleft">
                    TAG关键字：</td>
                <td class="bqright">
                    <asp:TextBox ID="txtTagName" runat="server" Width="50%" MaxLength="100"></asp:TextBox>&nbsp;<span class="tips">多个关键字用"<a href="javascript:SepTagName()">&nbsp;<span style="color: #00f; font-weight: 600">|</span>&nbsp;</a>"分开(每个关键字长度不能超过20个字)</span></td>
            </tr>
            <tr>
                <td class="bqleft">
                    运行环境：</td>
                <td class="bqright">
                    <asp:TextBox ID="txtSoftOS" runat="server" Width="70%"></asp:TextBox><br />
                    <span style="color: #808080" class="fl">平台选择:</span> <span class="fl">
                        <asp:Panel ID="plSoftOs" runat="server">
                        </asp:Panel>
                    </span>
                </td>
                
            </tr>
            <tr>
                <td class="bqleft">
                    下载地址:
                </td>
                <td class="bqright">
                    <asp:TextBox ID="FilePicPath" runat="server" style="display:none" Width="15%"></asp:TextBox>
                    <asp:HiddenField ID="hfAddressId" runat="server" Value="0" />
                    <asp:TextBox id='txtSoftAddressPath' runat="server" Width="30%"/>
                    <input type='button' value='添加地址' class='btn' id='btnAddAddress' onclick='WinOpenDialog("../../common/UpLoadSoft.aspx?ControlId=txtSoftAddressPath",400,180)' />
                </td>
            </tr>
            <tr>
                <td class="bqleft" style="height: 28px">
                    <%=ChannelModel.TypeName %>大小：</td>
                <td class="bqright" style="height: 28px">
                    <asp:TextBox ID="txtSoftSize" runat="server" Width="10%" Text="0"></asp:TextBox>
                    MB</td>
            </tr>
            <tr>
                <td class="bqleft" style="height: 42px">
                    <%=ChannelModel.TypeName %>简介：</td>
                <td class="bqright" style="height: 42px">
                    <asp:TextBox ID="txtSoftRemark" runat="server" Height="100px" TextMode="MultiLine"
                        Width="70%"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="bqleft">
                    演示地址：</td>
                <td class="bqright">
                    <asp:TextBox ID="txtSoftPlayAddress" runat="server" Width="35%"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="bqleft">
                    注册地址：</td>
                <td class="bqright">
                    <asp:TextBox ID="txtSoftRegAddress" runat="server" Width="35%"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="bqleft">
                    解压密码：</td>
                <td class="bqright">
                    <asp:TextBox ID="txtSoftDisplePwd" runat="server" Width="35%"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="bqleft">
                    下载收取金币数：</td>
                <td class="bqright">
                    <asp:TextBox ID="txtSoftPoint" runat="server" Width="10%" Text="0" MaxLength="10"
                        onkeyup="value=value.replace(/[^\d]/g,'')"></asp:TextBox>(下载此<%=ChannelModel.TypeName %>需要消耗多少<%=SiteModel.GUnitName%>金币)<asp:HiddenField
                            ID="hfIsOpened" runat="server" Value="2" />
                </td>
            </tr>
            <tr>
                <td colspan="2" class="tdheight" align="center">
                    <asp:Button runat="server" Text="保 存" OnClientClick="return CheckValidate()" ID="btnSoftSaveAs"
                        CssClass="btn" OnClick="btnSoftSaveAs_Click" />
                    &nbsp;&nbsp;
                    <input type="button" id="btnCancel" value="取 消" class="btn" onclick='javascript:history.back();' /><asp:Literal
                        ID="litMsg" runat="server"></asp:Literal></td>
            </tr>
        </table>
    </form>
</body>
</html>

<script type="text/javascript" language="javascript">
    var typeName='<%=ChannelModel.TypeName %>'
 //重名检测
function CheckTitle()
{
    var title=$('txtSoftName').value.trim();
   if(title.length==0)
   {
        alert("检测的"+typeName+"名称必须填写");
         $("txtSoftName").focus();
        return;
   } 
   var flag=CheckHas("../../system/common/CheckHas.aspx",title,"Title","KyDownLoadData");
    if(flag)
        alert("该"+typeName+"名称已经存在"); 
     else
        alert("该"+typeName+"名称不存在");
} 
   //平台选择
   function SetDownOS(OS)
   {
        var OSName=$("txtSoftOS");
        var OSStr = OSName.value.trim();
        var OSArray = null; 
        if(OSStr!="")
        {
             OSArray = OSStr.split('|');
             for(var i=0;i<OSArray.length;i++)
               {
                    if(OSArray[i]==OS)
                     {
                        return;
                     }
               }
               OSName.value+="|"+OS;
        } 
       else
       {
            OSName.value=OS;
       }
   }

//分隔关键字
function SepTagName()
{
    $("txtTagName").focus();
   if(document.selection)
   {
     var range=document.selection.createRange();
     range.text="|";
   } 
}
//校验文本框的输入
   function CheckValidate()
   {

    var title=$('txtSoftName').value.trim();

        if(title.length==0)
        {   
             alert(""+typeName+"名称必须填写");
            $("txtSoftName").focus();  
             return false; 
        }
      if($('ddlColId').options[$('ddlColId').selectedIndex].style.backgroundColor.trim().length!=0)
       {
            alert("所选择的栏目不能添加"+typeName+"");
            return false;
       }
       if($("txtSoftPoint").value.trim().length==0)
       {
             alert("下载收取金币数必须填写");
            $("txtSoftPoint").focus();  
             return false;
       }
       if($('txtSoftAddressPath').value.trim().length==0)
       {
            alert("下载地址路径必须填写");
            $('txtSoftAddressPath').focus();
            return false;
       }
       if($('txtSoftRemark').value.trim().length==0)
      {
          alert(""+typeName+"简介必须填写");
         $('txtSoftRemark').focus(); 
         return false; 
      } 
   }
</script>

