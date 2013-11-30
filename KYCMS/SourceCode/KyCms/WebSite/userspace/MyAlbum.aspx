<%@ Page Language="C#" MasterPageFile="~/userspace/SpaceTemplate.master" AutoEventWireup="true"
    CodeFile="MyAlbum.aspx.cs" Inherits="userspace_MyAlbum" Title="" %>

<%@ Register Src="Album.ascx" TagName="Album" TagPrefix="uc1" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Import Namespace="Ky.Common" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="Content">
        <div class="modelTitle" onclick="ShowHidden('List',this,'right')" title="点击隐藏">
            相册列表,所有相册</div>
    </div>
    <uc1:Album id="Album1" runat="server">
    </uc1:Album>


</asp:Content>
