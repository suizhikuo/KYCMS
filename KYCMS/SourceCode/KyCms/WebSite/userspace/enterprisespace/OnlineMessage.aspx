<%@ Page Language="C#" MasterPageFile="~/userspace/enterprisespace/MasterPage.master" AutoEventWireup="true"%>
<%@ Register Src="../SetMessage.ascx" TagName="SetMessage" TagPrefix="uc1" %>
<%@ Import Namespace="Ky.Common" %>
<%@ Import Namespace="Ky.BLL" %>
<%@ Import Namespace="Ky.Model" %> 
<%@ Import Namespace="System.Data" %> 
<script runat="server" language="c#">
    B_User userBll = new B_User();
    DataRow userDr = null;
    int userId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["uid"]))
        {
            userId = Convert.ToInt32(Request.QueryString["uid"]);
        }
        Page.Title = "在线留言";
        userDr = userBll.GetUserAllInfo(userId);
    }
    string UserInfo(DataRow dr, string fieldName)
    {
        if (dr != null)
        {
            if (dr.Table.Columns.Contains(fieldName))
            {
                return dr[fieldName].ToString();
            }
            else
            {
                return string.Empty;
            }
        }
        else
        {
            return string.Empty;
        }
    } 
</script>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

 <table width="685px" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td width="5">
                &nbsp;</td>
            <td height="400" valign="top">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td colspan="3" align="left">
                            您现在的位置： 在线留言</td>
                    </tr>
                    <tr>
                        <td width="5" height="30" class="rg01">
                        </td>
                        <td width="674" align="left" class="rg02">
                            <span class="savIcon"></span>在线留言</td>
                        <td width="5" height="30" class="rg03"> 
                        </td>
                    </tr>
                    <tr>
                        <td height="412" colspan="3" valign="top">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="leftbk">
                                <tr>
                                    <td height="410" valign="top" align="left" style="padding:10px;">
                                        <uc1:SetMessage id="SetMessage1" runat="server">
    </uc1:SetMessage>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>

   
</asp:Content>
