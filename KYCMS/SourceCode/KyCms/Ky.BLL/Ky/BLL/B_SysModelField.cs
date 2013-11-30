namespace Ky.BLL
{
    using System;
    using System.Data;

    public class B_SysModelField
    {
        public DataTable CollArticleDt()
        {
            DataTable table = this.CreateSysCollDataTableField();
            DataRow row = table.NewRow();
            row["Alias"] = "标题名";
            row["Name"] = "Title";
            table.Rows.Add(row);
            DataRow row2 = table.NewRow();
            row2["Alias"] = "副标题";
            row2["Name"] = "LongTitle";
            table.Rows.Add(row2);
            DataRow row3 = table.NewRow();
            row3["Alias"] = "导读";
            row3["Name"] = "ShortContent";
            table.Rows.Add(row3);
            DataRow row4 = table.NewRow();
            row4["Alias"] = "详细内容";
            row4["Name"] = "Content";
            table.Rows.Add(row4);
            DataRow row5 = table.NewRow();
            row5["Alias"] = "作者";
            row5["Name"] = "Author";
            table.Rows.Add(row5);
            DataRow row6 = table.NewRow();
            row6["Alias"] = "来源";
            row6["Name"] = "Source";
            table.Rows.Add(row6);
            DataRow row7 = table.NewRow();
            row7["Alias"] = "录入者";
            row7["Name"] = "UName";
            table.Rows.Add(row7);
            DataRow row8 = table.NewRow();
            row8["Alias"] = "责任编辑";
            row8["Name"] = "AdminUName";
            table.Rows.Add(row8);
            DataRow row9 = table.NewRow();
            row9["Alias"] = "添加日期";
            row9["Name"] = "AddTime";
            table.Rows.Add(row9);
            return table;
        }

        public DataTable CollDownLoadDt()
        {
            DataTable table = this.CreateSysCollDataTableField();
            DataRow row = table.NewRow();
            row["Alias"] = "标题名";
            row["Name"] = "Title";
            table.Rows.Add(row);
            DataRow row2 = table.NewRow();
            row2["Alias"] = "下载简介";
            row2["Name"] = "Content";
            table.Rows.Add(row2);
            DataRow row3 = table.NewRow();
            row3["Alias"] = "版本号";
            row3["Name"] = "Edition";
            table.Rows.Add(row3);
            DataRow row4 = table.NewRow();
            row4["Alias"] = "演示地址";
            row4["Name"] = "PlayAddress";
            table.Rows.Add(row4);
            DataRow row5 = table.NewRow();
            row5["Alias"] = "运行环境";
            row5["Name"] = "DownLoadOS";
            table.Rows.Add(row5);
            DataRow row6 = table.NewRow();
            row6["Alias"] = "文件大小";
            row6["Name"] = "DownLoadSize";
            table.Rows.Add(row6);
            DataRow row7 = table.NewRow();
            row7["Alias"] = "下载等级 ★";
            row7["Name"] = "DownLoadStarLevel";
            table.Rows.Add(row7);
            DataRow row8 = table.NewRow();
            row8["Alias"] = "解压密码";
            row8["Name"] = "DownLoadDisplePwd";
            table.Rows.Add(row8);
            DataRow row9 = table.NewRow();
            row9["Alias"] = "下载类别";
            row9["Name"] = "DownLoadType";
            table.Rows.Add(row9);
            DataRow row10 = table.NewRow();
            row10["Alias"] = "软件语言";
            row10["Name"] = "Language";
            table.Rows.Add(row10);
            DataRow row11 = table.NewRow();
            row11["Alias"] = "授权方式";
            row11["Name"] = "WarrantType";
            table.Rows.Add(row11);
            DataRow row12 = table.NewRow();
            row12["Alias"] = "插件认证";
            row12["Name"] = "Plugin";
            table.Rows.Add(row12);
            DataRow row13 = table.NewRow();
            row13["Alias"] = "下载地址";
            row13["Name"] = "AddressPath";
            table.Rows.Add(row13);
            DataRow row14 = table.NewRow();
            row14["Alias"] = "注册地址";
            row14["Name"] = "RegAddress";
            table.Rows.Add(row14);
            DataRow row15 = table.NewRow();
            row15["Alias"] = "录入者";
            row15["Name"] = "UName";
            table.Rows.Add(row15);
            DataRow row16 = table.NewRow();
            row16["Alias"] = "责任编辑";
            row16["Name"] = "AdminUName";
            table.Rows.Add(row16);
            DataRow row17 = table.NewRow();
            row17["Alias"] = "添加日期";
            row17["Name"] = "AddTime";
            table.Rows.Add(row17);
            return table;
        }

        public DataTable CollImageDt()
        {
            DataTable table = this.CreateSysCollDataTableField();
            DataRow row = table.NewRow();
            row["Alias"] = "标题名";
            row["Name"] = "Title";
            table.Rows.Add(row);
            DataRow row2 = table.NewRow();
            row2["Alias"] = "简介";
            row2["Name"] = "Content";
            table.Rows.Add(row2);
            DataRow row3 = table.NewRow();
            row3["Alias"] = "录入者";
            row3["Name"] = "UName";
            table.Rows.Add(row3);
            DataRow row4 = table.NewRow();
            row4["Alias"] = "责任编辑";
            row4["Name"] = "AdminUName";
            table.Rows.Add(row4);
            DataRow row5 = table.NewRow();
            row5["Alias"] = "添加日期";
            row5["Name"] = "AddTime";
            table.Rows.Add(row5);
            return table;
        }

        private DataTable CreateSysCollDataTableField()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Alias", typeof(string));
            table.Columns.Add("Name", typeof(string));
            return table;
        }

        private DataTable CreateSysDataTableField()
        {
            DataTable table = new DataTable();
            table.Columns.Add("FieldName", typeof(string));
            table.Columns.Add("FieldValue", typeof(string));
            return table;
        }

        public DataTable GetArticleListDt()
        {
            DataTable table = this.CreateSysDataTableField();
            DataRow row = table.NewRow();
            row["FieldName"] = "副标题";
            row["FieldValue"] = "{KY_LongTitle}";
            table.Rows.Add(row);
            DataRow row2 = table.NewRow();
            row2["FieldName"] = "导读";
            row2["FieldValue"] = "{KY_ShortContent}";
            table.Rows.Add(row2);
            DataRow row3 = table.NewRow();
            row3["FieldName"] = "详细内容";
            row3["FieldValue"] = "{KY_Content}";
            table.Rows.Add(row3);
            DataRow row4 = table.NewRow();
            row4["FieldName"] = "评分等级";
            row4["FieldValue"] = "{KY_StarLevel}";
            table.Rows.Add(row4);
            DataRow row5 = table.NewRow();
            row5["FieldName"] = "作者";
            row5["FieldValue"] = "{KY_Author}";
            table.Rows.Add(row5);
            DataRow row6 = table.NewRow();
            row6["FieldName"] = "来源";
            row6["FieldValue"] = "{KY_Source}";
            table.Rows.Add(row6);
            DataRow row7 = table.NewRow();
            row7["FieldName"] = "搜索链接";
            row7["FieldValue"] = "$search$";
            table.Rows.Add(row7);
            return table;
        }

        public DataTable GetDownLoadListDt()
        {
            DataTable table = this.CreateSysDataTableField();
            DataRow row = table.NewRow();
            row["FieldName"] = "下载简介";
            row["FieldValue"] = "{KY_Content}";
            table.Rows.Add(row);
            DataRow row2 = table.NewRow();
            row2["FieldName"] = "版本号";
            row2["FieldValue"] = "{KY_Edition}";
            table.Rows.Add(row2);
            DataRow row3 = table.NewRow();
            row3["FieldName"] = "演示地址";
            row3["FieldValue"] = "{KY_PlayAddress}";
            table.Rows.Add(row3);
            DataRow row4 = table.NewRow();
            row4["FieldName"] = "下载统计";
            row4["FieldValue"] = "{KY_DownLoadDownNum}";
            table.Rows.Add(row4);
            DataRow row5 = table.NewRow();
            row5["FieldName"] = "运行环境";
            row5["FieldValue"] = "{KY_DownLoadOS}";
            table.Rows.Add(row5);
            DataRow row6 = table.NewRow();
            row6["FieldName"] = "文件大小";
            row6["FieldValue"] = "{KY_DownLoadSize}";
            table.Rows.Add(row6);
            DataRow row7 = table.NewRow();
            row7["FieldName"] = "下载等级 ★";
            row7["FieldValue"] = "{KY_DownLoadStarLevel}";
            table.Rows.Add(row7);
            DataRow row8 = table.NewRow();
            row8["FieldName"] = "解压密码";
            row8["FieldValue"] = "{KY_DownLoadDisplePwd}";
            table.Rows.Add(row8);
            DataRow row9 = table.NewRow();
            row9["FieldName"] = "下载类别";
            row9["FieldValue"] = "{KY_DownLoadType}";
            table.Rows.Add(row9);
            DataRow row10 = table.NewRow();
            row10["FieldName"] = "软件语言";
            row10["FieldValue"] = "{KY_Language}";
            table.Rows.Add(row10);
            DataRow row11 = table.NewRow();
            row11["FieldName"] = "授权方式";
            row11["FieldValue"] = "{KY_WarrantType}";
            table.Rows.Add(row11);
            DataRow row12 = table.NewRow();
            row12["FieldName"] = "插件认证";
            row12["FieldValue"] = "{KY_Plugin}";
            table.Rows.Add(row12);
            DataRow row13 = table.NewRow();
            row13["FieldName"] = "下载地址";
            row13["FieldValue"] = "{KY_AddressPath}";
            table.Rows.Add(row13);
            DataRow row14 = table.NewRow();
            row14["FieldName"] = "注册地址";
            row14["FieldValue"] = "{KY_RegAddress}";
            table.Rows.Add(row14);
            DataRow row15 = table.NewRow();
            row15["FieldName"] = "今日下载次数";
            row15["FieldValue"] = "{KY_DownLoadDownDayNum}";
            table.Rows.Add(row15);
            DataRow row16 = table.NewRow();
            row16["FieldName"] = "本周下载次数";
            row16["FieldValue"] = "{KY_DownLoadDownWeekNum}";
            table.Rows.Add(row16);
            DataRow row17 = table.NewRow();
            row17["FieldName"] = "本月下载次数";
            row17["FieldValue"] = "{KY_DownLoadDownMonthNum}";
            table.Rows.Add(row17);
            DataRow row18 = table.NewRow();
            row18["FieldName"] = "搜索链接";
            row18["FieldValue"] = "$search$";
            table.Rows.Add(row18);
            return table;
        }

        public DataTable GetImageListDt()
        {
            DataTable table = this.CreateSysDataTableField();
            DataRow row = table.NewRow();
            row["FieldName"] = "简介";
            row["FieldValue"] = "{KY_Content}";
            table.Rows.Add(row);
            DataRow row2 = table.NewRow();
            row2["FieldName"] = "显示图片页";
            row2["FieldValue"] = "{KY_ImgPath}";
            table.Rows.Add(row2);
            DataRow row3 = table.NewRow();
            row3["FieldName"] = "搜索链接";
            row3["FieldValue"] = "$search$";
            table.Rows.Add(row3);
            return table;
        }

        public DataTable GetSysFieldListDt()//返回系统标签
        {
            DataTable table = this.CreateSysDataTableField();
            DataRow row = table.NewRow();
            row["FieldName"] = "栏目名";
            row["FieldValue"] = "{KY_ColName}";
            table.Rows.Add(row);
            DataRow row2 = table.NewRow();
            row2["FieldName"] = "栏目URL";
            row2["FieldValue"] = "{KY_ColumnUrl}";
            table.Rows.Add(row2);
            DataRow row3 = table.NewRow();
            row3["FieldName"] = "标题名";
            row3["FieldValue"] = "{KY_Title}";
            table.Rows.Add(row3);
            DataRow row4 = table.NewRow();
            row4["FieldName"] = "标题URL";
            row4["FieldValue"] = "{KY_InfoUrl}";
            table.Rows.Add(row4);
            DataRow row5 = table.NewRow();
            row5["FieldName"] = "缩略图";
            row5["FieldValue"] = "{KY_TitleImgPath}";
            table.Rows.Add(row5);
            DataRow row6 = table.NewRow();
            row6["FieldName"] = "内容编号";
            row6["FieldValue"] = "{KY_Id}";
            table.Rows.Add(row6);
            DataRow row7 = table.NewRow();
            row7["FieldName"] = "索引行号";
            row7["FieldValue"] = "{KY_RowIndex}";
            table.Rows.Add(row7);
            DataRow row8 = table.NewRow();
            row8["FieldName"] = "关键字";
            row8["FieldValue"] = "{KY_TagNameStr}";
            table.Rows.Add(row8);
            DataRow row9 = table.NewRow();
            row9["FieldName"] = "上一篇";
            row9["FieldValue"] = "{KY_Pre}";
            table.Rows.Add(row9);
            DataRow row10 = table.NewRow();
            row10["FieldName"] = "下一篇";
            row10["FieldValue"] = "{KY_Next}";
            table.Rows.Add(row10);
            DataRow row11 = table.NewRow();
            row11["FieldName"] = "上一篇URL";
            row11["FieldValue"] = "{KY_PreUrl}";
            table.Rows.Add(row11);
            DataRow row12 = table.NewRow();
            row12["FieldName"] = "下一篇URL";
            row12["FieldValue"] = "{KY_NextUrl}";
            table.Rows.Add(row12);
            DataRow row13 = table.NewRow();
            row13["FieldName"] = "点击数";
            row13["FieldValue"] = "{KY_HitCount}";
            table.Rows.Add(row13);
            DataRow row14 = table.NewRow();
            row14["FieldName"] = "录入者";
            row14["FieldValue"] = "{KY_UName}";
            table.Rows.Add(row14);
            DataRow row15 = table.NewRow();
            row15["FieldName"] = "责任编辑";
            row15["FieldValue"] = "{KY_AdminUName}";
            table.Rows.Add(row15);
            DataRow row16 = table.NewRow();
            row16["FieldName"] = "添加日期";
            row16["FieldValue"] = "{KY_AddTime}";
            table.Rows.Add(row16);
            DataRow row17 = table.NewRow();
            row17["FieldName"] = "收费点数";
            row17["FieldValue"] = "{KY_PointCount}";
            table.Rows.Add(row17);
            DataRow row18 = table.NewRow();
            row18["FieldName"] = "Dig";
            row18["FieldValue"] = "{KY_Dig}";
            table.Rows.Add(row18);
            DataRow row19 = table.NewRow();
            row19["FieldName"] = "数组循环";
            row19["FieldValue"] = "{KY_Rep#rep(2)}";
            table.Rows.Add(row19);
            DataRow row20 = table.NewRow();
            row20["FieldName"] = "栏目ID";
            row20["FieldValue"] = "{KY_ColID}";
            table.Rows.Add(row20);
            DataRow row21 = table.NewRow();
            row21["FieldName"] = "频道ID";
            row21["FieldValue"] = "{KY_ChID}";
            table.Rows.Add(row21);
            return table;
        }

        public DataTable UserSysField()
        {
            DataTable table = this.CreateSysDataTableField();
            DataRow row = table.NewRow();
            row["FieldName"] = "用户Id";
            row["FieldValue"] = "{KY_User_UserID}";
            table.Rows.Add(row);
            DataRow row2 = table.NewRow();
            row2["FieldName"] = "登录名";
            row2["FieldValue"] = "{KY_User_LogName}";
            table.Rows.Add(row2);
            DataRow row3 = table.NewRow();
            row3["FieldName"] = "积分";
            row3["FieldValue"] = "{KY_User_Integral}";
            table.Rows.Add(row3);
            DataRow row4 = table.NewRow();
            row4["FieldName"] = "金币";
            row4["FieldValue"] = "{KY_User_YellowBoy}";
            table.Rows.Add(row4);
            DataRow row5 = table.NewRow();
            row5["FieldName"] = "登录次数";
            row5["FieldValue"] = "{KY_User_LoginNum}";
            table.Rows.Add(row5);
            DataRow row6 = table.NewRow();
            row6["FieldName"] = "注册时间";
            row6["FieldValue"] = "{KY_User_RegTime}";
            table.Rows.Add(row6);
            return table;
        }
    }
}

