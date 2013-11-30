<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Album.ascx.cs" Inherits="userspace_Album" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Import Namespace="Ky.Common" %>
<div id="List">
    <div class="tl" style="padding: 5px 0 0 10px">
        <asp:Label ID="Label1" runat="server" Text="暂无创建相册" Visible="false"></asp:Label>
    </div>
    <div id='ShowAlbum'>
        <table cellspacing="0" cellpadding="0" border="0" align="left" >
            <tr>
                <asp:Repeater runat="server" ID="repAlbumManage" OnItemCreated="repAlbumManage_ItemDataCreate">
                    <ItemTemplate>
                        <td width="136px">
                            <table style="border-collapse: collapse" cellspacing="0" cellpadding="0">
                                <tr align="center">
                                    <td>
                                        <%#Eval("AlbumName") %>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdStyle">
                                        <a href='?AlbumId=<%#Eval("Id") %>&UserName=<%#UserName %>&ColorId=2&UId=<%=UId %>'
                                            title="点击显示本相册下的照片">
                                            <asp:Image ID="Image1" runat="server" ImageUrl='<%#ShowImgPath(Eval("Logo")) %>'
                                                Border="0" Width="120px" Height="90px" /></a>
                                    </td>
                                </tr>
                                <tr align="center">
                                    <td>
                                        共<font color="red"><%#Eval("ImgCount") %></font>张照片 [<font color="red"><%#IsOpened(Eval("IsOpened")) %></font>]
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </ItemTemplate>
                    <FooterTemplate>
                        <td>
                            </td>
                    </FooterTemplate>
                </asp:Repeater>
            </tr>
        </table>
        <div style="clear: both" id="ShowAlbumPage" runat="server">
            <hr />
            <table cellpadding="0" cellspacing="0" align="center" width="99%">
                <tr>
                    <td>
                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" FirstPageText="首页"
                            LastPageText="尾页" NextPageText="下一页" OnPageChanging="AspNetPager1_PageChanging"
                            PrevPageText="上一页" ShowCustomInfoSection="Left" ShowInputBox="Never" CustomInfoSectionWidth="10%"
                            ShowNavigationToolTip="True" Width="99%" HorizontalAlign="Right" PageSize="8">
                        </webdiyer:AspNetPager>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <hr />
    <div class="modelTitle" id="Div1" runat="server" visible="false" onclick="ShowHidden('photoList',this,'right')"
        title="点击隐藏" style="text-align:left">
        我的相册 >>
        <asp:Label ID="lbRepTitle" runat="server" Text=''></asp:Label>
        >> 浏览照片</div>
    <div id='photoList'>
        <div id='divIsHave' runat="server" style="display:none;">该相册下没有照片!</div> 
       <table cellspacing="0" cellpadding="4" border="0" align="left">
            <tr>
                <asp:Repeater runat="server" ID="repPhoto" OnItemCreated="repAlbumManage_ItemDataCreate"
                    OnItemDataBound="repPhoto_ItemDataBound">
                    <ItemTemplate>
                        <td>
                            <table align="left" cellpadding="0" cellspacing="0" style="border-collapse: collapse">
                                <tr>
                                    <td>
                                        <div style="border: 1px #ccc solid; padding: 2px; height: 92px; width: 122px">
                                            <a href='<%#picPath %>ShowPic.aspx?FilePath=<%#Eval("FilePath")%>&PhotoId=<%#Eval("PhotoId") %>'
                                                target="_blank">
                                                <asp:Image ID="Image2" runat="server" ImageUrl='<%#Param.ApplicationRootPath+"/user/upload/"+Eval("FilePath")%>'
                                                    Width="120px" Height="90px" AlternateText="点击在新窗口中打开" /></a></div>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        浏览次数:<font color="blue"><%#Eval("VisitNum") %></font>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <%#Eval("FilePath").ToString().Length >= 15 ? Eval("FilePath").ToString().Substring(15) : Eval("FilePath").ToString()%>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </ItemTemplate>
                    <FooterTemplate>
                        <div id="content">
                            <asp:Literal ID="litFooter" runat="server"></asp:Literal></div>
                    </FooterTemplate>
                </asp:Repeater>
            </tr>
        </table>
        <div class="fl" id="ShowPwd" visible="false" runat="server" style="padding: 5px;
            color: Blue">
            请输入访问密码：<input type="password" name='nmPwd' id='nmPwd' width='20px' onkeydown="if(event.keyCode==13)CheckPwd();">
            <input type="button" value="点击确认" onclick="CheckPwd()" /></div>
        <div class="fl" id="IsFriend" visible="false" runat="server" style="padding: 5px;
            color: Blue">
            对不起，该相册只允许好友访问!</div>
        <%if (AlbumId > 0)
          {%>
        <div style="clear: both" id="divPage" runat="server">
            <hr />
            <table cellpadding="0" cellspacing="0" align="center" width="99%">
                <tr>
                    <td>
                        <webdiyer:AspNetPager ID="AspNetPager2" runat="server" AlwaysShow="True" FirstPageText="首页"
                            LastPageText="尾页" NextPageText="下一页" OnPageChanging="AspNetPager2_PageChanging"
                            PrevPageText="上一页" ShowCustomInfoSection="Left" ShowInputBox="Never" CustomInfoSectionWidth="10%"
                            ShowNavigationToolTip="True" Width="99%" HorizontalAlign="Right" PageSize="16">
                        </webdiyer:AspNetPager>
                    </td>
                </tr>
            </table>
        </div>
        <%}%>
    </div>
</div>

<script language="javascript">
   function CheckPwd()
   {
        if($('nmPwd').value.trim()=="")
       {
            alert("密码必须填写");
            $('nmPwd').focus();
            return false;  
       }
       else
       {
            var pwd=$('nmPwd').value.trim();
           var albumId='<%=AlbumId %> '
          var UId;
          var userName ;
          if('<%=UIdflag %>'=="True") 
         {
             UId='<%=UId %>'
             userspace_Album.btnCheckPwd_UId(pwd,albumId,UId,call_back8);
         }
          else if('<%=UNameflag %>'=="True") 
          { 
                userName ='<%=UserName %>'
                userspace_Album.btnCheckPwd_UName(pwd,albumId,userName,call_back8);
           } 
       } 
   }  
   function call_back8(response)
   {
    if(response.value=="True")
    {
        if('<%=UIdflag %>'=="True")
             window.location.href="CompanyAlbum.aspx?UId=<%=UId %>&AlbumId=<%=AlbumId %>";
       else  
            window.location.href="MyAlbum.aspx?UserName=<%=UserName %>&ColorId=2&AlbumId=<%=AlbumId %>";
    }
    else if(response.value=="False")
    {
        alert('密码错误');
    }
   }
</script>

