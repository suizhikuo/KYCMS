<%@ Page Language="C#" MasterPageFile="~/userspace/SpaceTemplate.master" AutoEventWireup="true"
    CodeFile="MyFriend.aspx.cs" Inherits="userspace_MyFriend" Title="" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="Content">
        <div class="modelTitle" onclick="ShowHidden('friendList',this,'right')"  title='点击隐藏'>
            我的好友列表</div>
        <div id="friendList">
            <div>
                <asp:Label ID="Label2" runat="server" Text=""></asp:Label></div>
            <table cellspacing="0" cellpadding="0" border="0" align="left" width="99%" class="marTop10">
                <asp:Repeater runat="server" ID="repFriend">
                    <ItemTemplate>
                        <div style="padding-left: 10px">
                            <span class="iconBg" style="width: 65%">
                                <asp:Label ID="lbFriendName" runat="server" Text='<%#Eval("LogName") %>'></asp:Label>
                            </span><span>
                                <asp:Button ID="btnSetFriend" runat="server" Text="加为好友" CssClass="btn" OnClick="btnSetFriend_Click"
                                    OnClientClick="return confirm('你确定添加此用户为好友吗?')" />
                                -
                                <%if (UserBll.IsLogin())
                                  { %>
                                <input value='发短消息' class='btn' type="button" onclick="showtips('SetMessage.aspx?UserName=<%#Eval("LogName") %>','300px','260px')" />
                                <%}
                                  else
                                  { 
                                %>
                                <input value='发短消息' class='btn' type="button" onclick="javascript:alert('你还未登录，请先登录')" />
                                <% }%>
                            </span>
                            <hr />
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
    </div>
</asp:Content>
