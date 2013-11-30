namespace Ky.DALFactory
{
    using Ky.Model;
    using System;
    using System.Data;

    public interface IColumn
    {
        int Add(M_Column c);
        void CompleteDelete(int colId);
        void Delete(int chId, string colIdStr);
        DataTable GetAll();
        void Move(int colId, int targetId, bool isChannel, string childIdStr);
        int Update(M_Column c);
        void UpdateActionTableTemplate(int ColId, string ActionTable, string InfoTemplatePath);
        void UpdateTemplate(M_Column model);
    }
}

