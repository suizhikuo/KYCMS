namespace Ky.DALFactory
{
    using Ky.Model;
    using System;
    using System.Data;

    public interface IStyle
    {
        bool AddSearchStyle(int modeldId, string content);
        void AddStyle(M_Style mstyle);
        void Delete(int styleId);
        string Get_Channel_Name(int ChId);
        DataTable GetAllStyle();
        DataRow GetSearchStyle(int modelId);
        M_Style GetStyle(int styleId);
        DataTable GetStyleByModel(int modelId);
        string GetStyleContent(int styleId);
        DataTable GetStyleList(int styleId);
        DataTable GetStyleNameList(string labelName, int pageIndex, int pageSize, ref int recordCount);
        DataTable StyleCategory_GetList(int parentId);
        int StyleIDGetStylegoryId(int Style);
        bool UpdateSearchStyle(int modeId, string content);
        void UpdateStyle(M_Style mStyle);
    }
}

