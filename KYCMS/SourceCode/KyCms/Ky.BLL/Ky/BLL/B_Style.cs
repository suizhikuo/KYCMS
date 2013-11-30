namespace Ky.BLL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;

    public class B_Style
    {
        private IStyle iStyle = DataAccess.CreateStyle();

        public bool AddSearchStyle(int modelId, string content)
        {
            return this.iStyle.AddSearchStyle(modelId, content);
        }

        public void AddStyle(M_Style mStyle)
        {
            this.iStyle.AddStyle(mStyle);
        }

        public void Delete(int styleId)
        {
            this.iStyle.Delete(styleId);
        }

        public string Get_Channecl_Name(int ChId)
        {
            return this.iStyle.Get_Channel_Name(ChId);
        }

        public DataTable GetAllStyle()
        {
            return this.iStyle.GetAllStyle();
        }

        public DataRow GetSearchStyle(int modelId)
        {
            return this.iStyle.GetSearchStyle(modelId);
        }

        public M_Style GetStyle(int styleId)
        {
            return this.iStyle.GetStyle(styleId);
        }

        public DataTable GetStyleByModel(int modelId)
        {
            return this.iStyle.GetStyleByModel(modelId);
        }

        public string GetStyleContent(int styleId)
        {
            return this.iStyle.GetStyleContent(styleId);
        }

        public DataTable GetStyleList(int styleId)
        {
            return this.iStyle.GetStyleList(styleId);
        }

        public DataTable GetStyleNameList(string labelName, int pageIndex, int pageSize, ref int recordCount)
        {
            return this.iStyle.GetStyleNameList(labelName, pageIndex, pageSize, ref recordCount);
        }

        public DataTable StyleCategory_GetList(int parentId)
        {
            return this.iStyle.StyleCategory_GetList(parentId);
        }

        public int StyleIDGetStylegoryId(int styleId)
        {
            return this.iStyle.StyleIDGetStylegoryId(styleId);
        }

        public void UpadteStyle(M_Style mStyle)
        {
            this.iStyle.UpdateStyle(mStyle);
        }

        public bool UpdateSearchStyle(int modelid, string content)
        {
            return this.iStyle.UpdateSearchStyle(modelid, content);
        }
    }
}

