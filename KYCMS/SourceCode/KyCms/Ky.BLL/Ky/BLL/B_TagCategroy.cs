namespace Ky.BLL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;

    public class B_TagCategroy
    {
        private ITagCategory dal = DataAccess.CreateTagCategory();

        public void Add(M_TagCategory model)
        {
            this.dal.Add(model);
        }

        public void Delete(int tagCategoryId)
        {
            this.dal.Delete(tagCategoryId);
        }

        public DataTable GetList()
        {
            return this.dal.GetList();
        }

        public void Update(M_TagCategory model)
        {
            if (model.TagCategoryId > 0)
            {
                this.dal.Update(model);
            }
        }
    }
}

