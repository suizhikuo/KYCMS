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
using Ky.BLL.CommonModel;
using Ky.Model;
using Ky.Common;
/// <summary>
/// /5/1/a/s/px/
/// </summary>
public partial class common_Dig : System.Web.UI.Page
{
    B_InfoOper InfoOperBll = new B_InfoOper();
    B_InfoModel InfoModelBll = new B_InfoModel();
    B_Create CreateBll = new B_Create();
    bool IsGetDate;
    bool IsVote;
    int ModelId = 0;
    int InfoId = 0;
    string Css = string.Empty;
    int Count = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        if (!string.IsNullOrEmpty(Request.QueryString["type"]))
        {
            if (Request.QueryString["type"].ToLower() == "set")
            {
                IsGetDate = false;
            }
            else
            {
                IsGetDate = true;
            }
        }
        else
        {
            IsGetDate = true;
        }
        if (!string.IsNullOrEmpty(Request.QueryString["modelid"]))
        {
            try
            {
                ModelId = int.Parse(Request.QueryString["modelid"]);
            }
            catch { }
        }
        if (!string.IsNullOrEmpty(Request.QueryString["id"]))
        {
            try
            {
                InfoId = int.Parse(Request.QueryString["id"]);
            }
            catch { }
        }
         if (!string.IsNullOrEmpty(Request.QueryString["css"]))
        {
                Css = Request.QueryString["css"];
        }
        if (ModelId == 0 || InfoId == 0)
        {
            return;
        }
        string elementId = "dig_" + ModelId + "_" + InfoId;
        if (Request.Cookies[elementId] == null)
            IsVote = false;
        else
            IsVote = true;
        if (IsGetDate)
        {
            Count = CreateBll.GetDigCount(ModelId, InfoId);
            string _class = Css == string.Empty ? " " : " class='" + Css + "' ";
            string _script = string.Empty;
            if (IsVote)
            {
                _script = string.Format("document.write(\"<div><table width ='52px' cellspacing='0' cellpadding='0' border='0'><tr><td align='center'  height='52px' background='" + Param.ApplicationRootPath + "/images/dig.gif'><a{0}id='{1}' style='color:red;font-weight:bold;font-family: Verdana;'>{2}</a></td></tr><tr><td align='center' style='border:solid 1px #eef6fb;height:18px'><a id='click_{1}' style='color:red;font-size:12px'>成&nbsp;&nbsp;功</a></td></tr></table></div>\")", _class, elementId, Count);
            }
            else
                _script = string.Format("document.write(\"<div><table width ='52px' cellspacing='0' cellpadding='0' border='0'><tr><td align='center'  height='52px' background='" + Param.ApplicationRootPath + "/images/dig.gif'><a{0}id='{1}' style='color:red;font-weight:bold;font-family: Verdana;'>{5}</a></td></tr><tr><td align='center' style='border:solid 1px #eef6fb;height:18px'><a id='click_{1}' onclick='SetDig(\\\"{2}\\\",{3},{4})' style='cursor:hand;color:red;font-size:12px'>投一票</a></td></tr></table></div>\")", _class, elementId, Param.ApplicationRootPath, ModelId, InfoId, Count);
            Response.Write(_script);
        }
        else
        {

            if (IsVote)
            {
                Response.Write(-1);
                return;
                
            }
            else
            {
                CreateBll.SetDigCount(ModelId, InfoId);
            }
            Response.Cookies[elementId].Value = "true";
            Response.Cookies[elementId].Expires = DateTime.Now.AddYears(1);
            Count = CreateBll.GetDigCount(ModelId, InfoId);
            Response.Write(Count);
        }

    }


}
