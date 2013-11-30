<%@ Page Language="C#" MasterPageFile="~/userspace/SpaceTemplate.master" AutoEventWireup="true"
    CodeFile="MyMessage.aspx.cs" Inherits="userspace_MyMessage" Title="我的留言" %>

<%@ Register Src="SetMessage.ascx" TagName="SetMessage" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc1:SetMessage ID="SetMessage1" runat="server" />
</asp:Content>
