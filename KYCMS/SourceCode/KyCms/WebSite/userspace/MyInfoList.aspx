<%@ Page Language="C#" MasterPageFile="~/userspace/SpaceTemplate.master" AutoEventWireup="true"
    CodeFile="MyInfoList.aspx.cs" Inherits="userspace_MyInfoList" Title="" %>

<%@ Import Namespace="Ky.Common" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="Content">
        <table cellspacing="1" cellpadding="0" width="100%">
            <tr>
                <div>
                    <asp:Label ID="lbMsg" runat="server" Text=""></asp:Label>
                </div>
                <asp:Repeater ID="repModel" runat="server" OnItemDataBound="repItemDataBound">
                    <ItemTemplate>
                        <%if (ModelId <= 0)
                          { %>
                        <div class="modelTitle" onclick="ShowHidden('List_<%#Eval("ModelId") %>',this,'right')" title="点击隐藏">
                            <%#Eval("ModelName") %>
                            - 最新列表111</a>
                            <%}
                              else
                              { %>
                            <div onclick="ShowHidden('List_I_<%#Eval("ModelId") %>',this,'right')" title="点击隐藏" class="modelTitle">
                                <%#Eval("ModelName") %>
                                - 最新列表222</div>
                            <%  } %>
                        </div>
                        <div class='marTop3' id="List_<%#Eval("ModelId") %>">
                            <asp:Repeater ID="repContent" runat="server">
                                <ItemTemplate>
                                    <div class="widInfo">
                                        <span class="fl">
                                            <li id="li"><a href="<%#GetUrl(Eval("Id"),Eval("ModelType")) %>" target="_blank">
                                                <%#Function.HtmlEncode(Eval("Title")) %>
                                            </a></li>
                                        </span><span class="fr">
                                            <%#Eval("AddTime") %>
                                        </span>
                                    </div>
                                    <hr />
                                </ItemTemplate>
                            </asp:Repeater>
                            <div class="padding5 tr" id="divShowMore" runat="server">
                                <a href='?ModelId=<%#Eval("ModelId")%>&UserName=<%=UserName %>'>
                                    <img src="skin/images/more.gif" border="0" alt="查看更多" />
                                </a>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </tr>
        </table>
        <div id="List_I_<%=ModelId %>">
            <table cellspacing="1" cellpadding="0" width="100%">
                <tr>
                    <asp:Repeater ID="repContentList" runat="server">
                        <ItemTemplate>
                            <div class="widInfo">
                                <span class="fl">
                                    <li id='li'><a href="<%#GetUrl(Eval("Id"),Eval("ModelType")) %>" target="_blank">
                                        <%#Function.HtmlEncode(Eval("Title")) %>
                                    </a></li>
                                </span><span class="fr">
                                    <%#Eval("AddTime") %>
                                </span>
                            </div>
                            <hr />
                        </ItemTemplate>
                    </asp:Repeater>
                </tr>
            </table>
        <table cellpadding="0" cellspacing="0" width="98%" class="tc">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                    <webdiyer:AspNetPager ID="AspNetPager" runat="server" AlwaysShow="True" FirstPageText="首页"
                        LastPageText="尾页" NextPageText="下一页" OnPageChanging="AspNetPager_PageChanging"
                        PrevPageText="上一页" ShowCustomInfoSection="Left" ShowInputBox="Never" CustomInfoSectionWidth="10%"
                        ShowNavigationToolTip="True" Width="98%" HorizontalAlign="Right" Visible="false"
                        PageSize="20">
                    </webdiyer:AspNetPager>
                </td>
            </tr>
        </table>
        </div>
    </div>
</asp:Content>
