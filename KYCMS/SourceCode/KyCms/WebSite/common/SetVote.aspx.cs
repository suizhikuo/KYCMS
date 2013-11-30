using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Ky.BLL;
using Ky.Model;

public partial class common_SetVote : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Form["subjectflagl"] != null)
        {
            string subjectId = Request.Form["subjectflagl"].ToString();
            if (Request.Cookies[subjectId] != null)
            {
                Response.Write("<script>alert('你已经投过票了');window.history.back();</script>");
            }
            else
            {
                int ItemNum1 = 0;
                int ItemNum2 = 0;
                int ItemNum3 = 0;
                int ItemNum4 = 0;
                int ItemNum5 = 0;
                int ItemNum6 = 0;
                string[] voteIdArr = Request.Form["hidvoteIdAll"].ToString().Substring(0, Request.Form["hidvoteIdAll"].ToString().Length - 1).Split(',');
                foreach (string voteId in voteIdArr)
                {
                    B_Vote bllVote = new B_Vote();
                    B_User userBll = new B_User();
                    M_Vote mUpdateVote = new M_Vote();
                    M_Vote mVote = bllVote.GetVoteIdbyInfo(int.Parse(voteId.ToString()));

                    DataTable dt = bllVote.GetSubject((int)mVote.SubjectId);
                    if (dt != null && dt.Rows.Count != 0)
                    {
                        if ((DateTime)dt.Rows[0]["EndDate"] < DateTime.Now.Date)
                        {
                            Response.Write("<script>alert('此投票主题已过期');window.history.back();</script>");
                            return;
                        }
                        if (dt.Rows[0]["RequireLogin"].ToString() == "True" && !userBll.IsLogin())
                        {
                            Response.Write("<script>alert('请登录后再投票');window.history.back();</script>");
                            return;                        
                        }                    
                    }
                    HttpCookie ipCookie = new HttpCookie(subjectId);
                    ipCookie.Value = Request.UserHostAddress;
                    ipCookie.Expires = DateTime.Now.AddHours(2);
                    Response.Cookies.Add(ipCookie);

                    ItemNum1 = mVote.ItemNum1;
                    ItemNum2 = mVote.ItemNum2;
                    ItemNum3 = mVote.ItemNum3;
                    ItemNum4 = mVote.ItemNum4;
                    ItemNum5 = mVote.ItemNum5;
                    ItemNum6 = mVote.ItemNum6;
                    string[] voteItem = null;
                    if (Request.Form[voteId + "vote"] != null)
                    {
                        voteItem = Request.Form[voteId + "vote"].ToString().Split(',');
                        foreach (string ItemValue in voteItem)
                        {
                            if (ItemValue == "ItemNum1")
                                ItemNum1 = ItemNum1 + 1;
                            if (ItemValue == "ItemNum2")
                                ItemNum2 = ItemNum2 + 1;
                            if (ItemValue == "ItemNum3")
                                ItemNum3 = ItemNum3 + 1;
                            if (ItemValue == "ItemNum4")
                                ItemNum4 = ItemNum4 + 1;
                            if (ItemValue == "ItemNum5")
                                ItemNum5 = ItemNum5 + 1;
                            if (ItemValue == "ItemNum6")
                                ItemNum6 = ItemNum6 + 1;

                            mUpdateVote.ItemNum1 = ItemNum1;
                            mUpdateVote.ItemNum2 = ItemNum2;
                            mUpdateVote.ItemNum3 = ItemNum3;
                            mUpdateVote.ItemNum4 = ItemNum4;
                            mUpdateVote.ItemNum5 = ItemNum5;
                            mUpdateVote.ItemNum6 = ItemNum6;
                            mUpdateVote.VoteId = int.Parse(voteId.ToString());
                            mUpdateVote.VoteTitle = mVote.VoteTitle;
                            mUpdateVote.IsMore = mVote.IsMore;
                            mUpdateVote.ItemTitle1 = mVote.ItemTitle1;
                            mUpdateVote.ItemTitle2 = mVote.ItemTitle2;
                            mUpdateVote.ItemTitle3 = mVote.ItemTitle3;
                            mUpdateVote.ItemTitle4 = mVote.ItemTitle4;
                            mUpdateVote.ItemTitle5 = mVote.ItemTitle5;
                            mUpdateVote.ItemTitle6 = mVote.ItemTitle6;
                            bllVote.UpdateVote(mUpdateVote);
                        }
                    }
                }
                Response.Write("<script>alert('投票成功');window.history.back();</script>");
            }
        }
    }
}
