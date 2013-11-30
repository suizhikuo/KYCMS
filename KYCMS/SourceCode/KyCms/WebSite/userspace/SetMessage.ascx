<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SetMessage.ascx.cs" Inherits="userspace_SetMessage" %>
<script type="text/javascript" src="../../js/Common.js"></script>
<%@ Import Namespace="Ky.Common" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

    <div id="Content">
        <div class='msgBoder'>
            <div class="modelTitle" onclick="ShowHidden('list',this,'right')" title='点击隐藏'>
                <strong>我的留言本</strong></div>
            <div id="list">
                <div class="fl" style="padding: 10px">
                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                </div>
                <table cellspacing="0" cellpadding="0" class='rightWid tc'>
                    <tr>
                        <asp:Repeater runat="server" ID="repMsg">
                            <ItemTemplate>
                                <div id='msgTitle'>
                                    <div class="fl" style="width: 300px">
                                        留言人：<%#Function.HtmlEncode(Eval("AnounName").ToString())%></div>
                                    <div>
                                        留言标题：<%#Eval("Title").ToString().Length >= 15 ?Function.HtmlEncode(Eval("Title").ToString().Substring(0, 15)+"...") :Function.HtmlEncode(Eval("Title").ToString())%></div>
                                </div>
                                <div class="padding5" style="word-break: break-all;">
                                    <%#GetContent(Eval("Content"))%>
                                </div>
                                <%#ResmueContent(Eval("IsResume"), Eval("ResumeContent"), Eval("ResumeTime"))%>
                                <div id='msgTime'>
                                    <span>留言时间：<%#Eval("PostTime") %></span> <span style="margin-left: 10px"><a href="javascript:window.scrollTo(0,0)">
                                        Top</a></span></div>
                                <hr />
                            </ItemTemplate>
                        </asp:Repeater>
                    </tr>
                </table>
                <table cellpadding="0" cellspacing="0" width="99%" class="tc">
                    <tr>
                        <td>
                            <webdiyer:AspNetPager ID="AspNetPager" runat="server" AlwaysShow="True" FirstPageText="首页"
                                LastPageText="尾页" NextPageText="下一页" OnPageChanging="AspNetPager_PageChanging"
                                PrevPageText="上一页" ShowCustomInfoSection="Left" ShowInputBox="Never" CustomInfoSectionWidth="10%"
                                ShowNavigationToolTip="True" Width="99%" HorizontalAlign="Right">
                            </webdiyer:AspNetPager>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="tc" id='Msg'>
       <fieldset style="padding:10px;"><legend style="margin-left:20px;">给我留言</legend>
       <table cellspacing="0" cellpadding="0" width="100%">
    <tr>
        <td width="50px" align="right">
            昵称：</td>
        <td style="width: 400px">
            <input id="txtAnounName" width="40%" MaxLength="15" runat="server" />
            <font  color=red>*</font></td>
    </tr>
    <tr>
        <td width="50px" align="right">
            主页：</td>
        <td style="width: 400px">
            <input id="txtHomePage" Width="50%" value="http:///"/></td>
    </tr>
    <tr>
        <td width="50px" align="right">
            标题：</td>
        <td style="width: 400px">
            <input id="txtTitle" Width="50%" MaxLength="20" /></td>
    </tr>
    <tr>
        <td colspan="2">
            留言内容：<br />
            &nbsp;<textarea id="txtContent" style="width: 400px; height: 108px"></textarea><br />
              <input type="button" class="btn" value="提交留言" onclick="AddMsg()" />
                </td>
    </tr>
</table>
</fieldset> 
     </div>
    </div>


<asp:Label ID="litMsg" runat="server" Text=""></asp:Label>

<script type="text/javascript">
function CheckValidate()
{
    if($('ctl00$ContentPlaceHolder1$SetMessage1$txtAnounName').value.trim()=="")
    {
        alert('昵称必须填写');
        $('ctl00$ContentPlaceHolder1$SetMessage1$txtAnounName').focus();
        return false;
    }
     if($('txtTitle').value.trim()=="")
    {
        alert('标题必须填写');
        $('txtTitle').focus();
        return false;
    }
     if($('txtContent').value.trim()=="")
    {
        alert('留言内容必须填写');
        $('txtContent').focus();
        return false;
    }
   return true; 
}

function AddMsg()
{
    if(CheckValidate())
   {
        var title=$("txtTitle").value;
       var homePage=$("txtHomePage").value;
       var anounName=$("ctl00$ContentPlaceHolder1$SetMessage1$txtAnounName").value;
       var content=$("txtContent").value;
       var uId='<%=UId %>';
       var uName='<%=UserName %>';
       userspace_SetMessage.SetMessage(title,homePage,anounName,content,uId,uName,call_back_Msg)
   } 
}
function call_back_Msg(res)
{
    alert(res.value);
    location.reload();
}
</script>

