<%@ Page Language="C#" MasterPageFile="~/userspace/enterprisespace/MasterPage.master" AutoEventWireup="true" CodeFile="CompanyAlbum.aspx.cs" Inherits="userspace_enterprisespace_CompanyAlbum" Title="Untitled Page" %>

<%@ Register Src="../Album.ascx" TagName="Album" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="685px" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td width="5">
                &nbsp;</td>
            <td height="400" valign="top">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td colspan="3" align="left">
                            您现在的位置：公司相册</td>
                    </tr>
                    <tr>
                        <td width="5" height="30" class="rg01">
                        </td>
                        <td width="674" align="left" class="rg02">
                            <span class="savIcon"></span>公司相册</td>
                        <td width="5" height="30" class="rg03">
                        
                        </td>
                    </tr>
                    <tr>
                    </tr>
                </table>
                <uc1:Album ID="Album1" runat="server" />
            </td>
        </tr>
    </table>

</asp:Content>

