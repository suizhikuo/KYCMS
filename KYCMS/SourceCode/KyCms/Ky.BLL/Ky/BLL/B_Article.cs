namespace Ky.BLL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;

    public class B_Article
    {
        private const string cancelMsg = "你不具备退稿的权限，只有该频道的最高审核人员才能退稿";
        private IArticle dal = DataAccess.CreateArticle();

        public int Add(M_Article model)
        {
            return this.dal.Add(model);
        }

        public M_Article GetArticle(int Id)
        {
            return this.dal.GetArticle(Id);
        }

        public int GetExpireArticleCount(int chId, int colId)
        {
            return this.dal.GetExpireArticleCount(chId, colId);
        }

        public void MoveExprieArticle(int chId, int colId)
        {
            this.dal.MoveExprieArticle(chId, colId);
        }

        public void SetViewState(int articleId, string viewerName)
        {
            this.dal.SetViewState(articleId, viewerName);
        }

        public int Update(M_Article model)
        {
            return this.dal.Update(model);
        }
    }
}

