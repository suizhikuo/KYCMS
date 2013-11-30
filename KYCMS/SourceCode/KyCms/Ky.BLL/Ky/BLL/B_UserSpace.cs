namespace Ky.BLL
{
    using Ky.Common;
    using Ky.DALFactory;
    using Ky.Model;
    using System;

    public class B_UserSpace
    {
        private IUserSpace IUS = DataAccess.CreateUserSpace();

        public int GetSapcePrevPowerByUserId(int userId)
        {
            return this.IUS.GetSapcePrevPowerByUserId(userId);
        }

        public M_UserSpace GetUserSpaceById(int Id)
        {
            return this.IUS.GetUserSpaceById(Id);
        }

        public static void IsActive(int userId, int flag)
        {
            B_UserSpace space = new B_UserSpace();
            if ((space.GetUserSpaceById(userId) == null) && (flag == 1))
            {
                Function.ShowMsg(0, "<li>无法访问,该空间还未激活</li><li><a href='" + Param.ApplicationRootPath + "/user/space/RegSpace.aspx' target='ContentIframe' onclick='javascript:window.close();'>立即激活空间</a></li><li><a href='" + Param.ApplicationRootPath + "/user/welcome.aspx'>返回会员首页</a></li>");
            }
            else if ((space.GetUserSpaceById(userId) == null) && (flag == 2))
            {
                Function.ShowMsg(0, "<li>该空间不存在或尚未激活</li><li><a href='" + Param.ApplicationRootPath + "/user/space/RegSpace.aspx' target='ContentIframe' onclick='javascript:window.close();'>立即激活空间</a></li><li><a href='" + Param.ApplicationRootPath + "/index.aspx'>返回网站首页</a></li><li><a href='javascript:window.close()'>关闭窗口</a></li>");
            }
        }

        public void RegSpace(M_UserSpace model)
        {
            this.IUS.RegSpace(model);
        }

        public void UpdateSpace(M_UserSpace model)
        {
            this.IUS.UpdateSpace(model);
        }
    }
}

