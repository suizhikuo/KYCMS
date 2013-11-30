namespace Ky.DALFactory
{
    using Ky.Model;
    using System;
    using System.Data;

    public interface IInfoModel
    {
        int Add(M_InfoModel model);
        int AddInfoModel(DataTable dt, string TableName);
        void AddTable(string tableName);
        bool CheckExistsChannel(int modelId);
        bool CheckTableValidate(string tableName);
        bool CheckUploadPathValidate(string uploadPath);
        void Delete(int modelId);
        DataTable GetList();
        M_InfoModel GetModel(int modelId);
        int GetModelInfoCount(string tableName, string whereStr);
        DataTable GetTextType(int ModelId);
        DataSet ModelOut(string InModelId);
        int Update(M_InfoModel model);
        void UpdateInfoModel(DataTable dt, string TableName);
        void UpdateModelHtml(M_InfoModel model);
    }
}

