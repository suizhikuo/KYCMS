namespace Ky.DALFactory
{
    using Ky.Model;
    using System;

    public interface IArticle
    {
        int Add(M_Article model);
        M_Article GetArticle(int Id);
        int GetExpireArticleCount(int chId, int colId);
        void MoveExprieArticle(int chId, int colId);
        void SetViewState(int id, string viewerName);
        int Update(M_Article model);
    }
}

