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

public partial class sys_template_AddReview : System.Web.UI.Page
{
    protected int modelId = 1;                                                                           //模型Id号
    protected int id = 1;                                                                                    //内容所对应的记录Id
    protected bool isColCheckComment = true;                                                //栏目设置是否需要审核
    protected bool isLogin = false;                                                                    //是否登录
    protected bool IsAddCommentEditor = true;                                               //是否使用编辑器
    protected bool IsCommentValidate = true;                                                  //评论时是否使用验证吗
    protected bool validate = false;                                                                   //验证码
    protected bool IsAllowCommentNoName = true;                                        //是否允许匿名用户评论


    B_InfoModel InfoModelBll = new B_InfoModel();
    B_InfoOper InfoOperBll = new B_InfoOper();
    B_Column ColBll = new B_Column();
    B_SiteInfo SiteBll = new B_SiteInfo();
    B_User UserBll = new B_User();
    protected void Page_Load(object sender, EventArgs e)
    {
        //检测是否得到内容所在的模块号与文章自己的ID号,否则则不执行后面的所代码
        if (!(Request.Form["ModelType"] != null && Request.Form["ModelType"].Length != 0 && Request.Form["Id"] != null && Request.Form["Id"].Length != 0))
            Response.End();
        modelId = int.Parse(Request.Form["ModelType"]);
        id = int.Parse(Request.Form["id"]);

        //取得相应模型下的栏目设置是否允许评论
        M_InfoModel infoModel = InfoModelBll.GetModel(modelId);
        if (infoModel == null)
            Response.End();
        DataRow dr = InfoOperBll.GetInfo(infoModel.TableName, id);
        if (dr == null)
            Response.End();
        M_Column colModel = ColBll.GetColumn((int)(dr["colId"]));
        if (!colModel.IsAllowComment)
            Response.End();

        //栏目设置是否需要审核
        isColCheckComment = colModel.IsCheckComment;

        //取得相应模型 、栏目下的内容设置是否允许评论
        if (!(bool)dr["IsAllowComment"])
            Response.End();

        M_Site siteModel = SiteBll.GetSiteModel();                                      //取得关于评论的参数设置
        IsAddCommentEditor = siteModel.IsAddCommentEditor;                //是否使用编辑器
        IsCommentValidate = siteModel.IsCommentValidate;                     //是否使用验证码
        IsAllowCommentNoName = siteModel.IsAllowCommentNoName;    //是否允许匿名用户评论

        //用户是否登录
        isLogin = UserBll.IsLogin();
        if (isLogin)
            IsAllowCommentNoName = true;
    }
}
