namespace Ky.BLL
{
    using Ky.Common;
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;
    using System.IO;
    using System.Text;
    using System.Web;

    public class B_Ad
    {
        private IAd dal = DataAccess.CreateAd();

        public void Add(M_Ad model)
        {
            this.dal.Add(model);
        }

        public void Delete(int AdId)
        {
            this.dal.Delete(AdId);
            B_Log.Add(LogType.Delete, "删除广告成功.编号:" + AdId);
        }

        public DataSet GetList(int pageSize, int pageIndex, string strWhere)
        {
            return this.dal.GetList(pageSize, pageIndex, strWhere);
        }

        public M_Ad GetModel(int AdId)
        {
            return this.dal.GetModel(AdId);
        }

        public void RefreshAd(string categoryId)
        {
            int num3;
            M_AdCategory model = new B_AdCategory().GetModel(int.Parse(categoryId));
            string[] strArray = model.WidthHeigth.Split(new char[] { '|' });
            string str = Param.SiteRootPath + @"\Push\";
            string path = str + "templet.js";
            string str3 = str + categoryId + ".js";
            DataTable table = this.GetList(1000000, 1, "CategoryId=" + categoryId + " and EndTime>=getDate()").Tables[0];
            if (!File.Exists(path))
            {
                throw new Exception("广告模板文件(templet.js)丢失,请检查.");
            }
            int num = 0;
            string newValue = model.DisplayType.ToString();
            string str5 = strArray[0];
            string str6 = strArray[1];
            int num2 = Ky.Common.Function.CheckNumber(strArray[2]) ? int.Parse(strArray[2]) : 1;
            string str7 = Param.ApplicationRootPath + "/system/images/ico/close.gif";
            StringBuilder builder = new StringBuilder();
            for (num3 = 0; num3 < table.Rows.Count; num3++)
            {
                builder.Append("data[");
                builder.Append(num3);
                builder.Append("]='");
                builder.Append(HttpContext.Current.Server.HtmlDecode(table.Rows[num3]["Content"].ToString().Replace("$", "").Replace("UpdatePushInfo.aspx?", "UpdatePushInfo.aspx?adid=" + table.Rows[num3]["AdId"].ToString() + "&")));
                builder.Append("';");
                num += Convert.ToInt32(table.Rows[num3]["Weight"]);
            }
            StringBuilder builder2 = new StringBuilder();
            for (num3 = 0; num3 < table.Rows.Count; num3++)
            {
                builder2.Append("weight[");
                builder2.Append(num3);
                builder2.Append("]=");
                builder2.Append(table.Rows[num3]["Weight"].ToString());
                builder2.Append(";");
            }
            try
            {
                StreamReader reader = new StreamReader(path);
                string str8 = reader.ReadToEnd();
                StreamWriter writer = new StreamWriter(str3, false, Encoding.UTF8);
                int num4 = num2 - 1;
                writer.Write(str8.Replace("[$InitDataArray$]", builder.ToString()).Replace("[$CountSum$]", num.ToString()).Replace("[$InitWeightArray$]", builder2.ToString()).Replace("[$LayerId$]", categoryId).Replace("[$SelectType$]", newValue).Replace("[$LayerWidth$]", str5).Replace("[$LayerHeight$]", str6).Replace("[$CloseImgPath$]", str7).Replace("[$Per$]", num4.ToString()).Replace("\r\n", ""));
                writer.Flush();
                writer.Dispose();
                str8 = "";
                reader.Dispose();
                builder = null;
                builder2 = null;
            }
            catch (IOException exception)
            {
                throw new Exception("写广告JS失败:" + exception.Message);
            }
        }

        public void Update(M_Ad model)
        {
            this.dal.Update(model);
        }
    }
}

