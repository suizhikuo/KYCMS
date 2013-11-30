namespace Ky.BLL.CommonModel
{
    using Ky.BLL;
    using Ky.Common;
    using System;
    using System.Data;

    public class B_ShowFieldStyle
    {
        public string GetDateType(string Name, string IsNotNull, string Description, DataRow dr)
        {
            string str2 = "";
            if (IsNotNull == "True")
            {
                str2 = "<font color=\"red\">*</font>";
            }
            if (dr == null)
            {
                return ("<input type=\"text\" name=\"txt_" + Name + "\" size=\"18\" onclick=\"setday(this);\" readonly=\"true\" value=\"\"> " + str2 + " " + Description + "");
            }
            return ("<input type=\"text\" name=\"txt_" + Name + "\" size=\"18\"  onclick=\"setday(this);\" readonly=\"true\" value=\"" + dr["" + Name + ""].ToString() + "\"> " + str2 + " " + Description + "");
        }

        public string GetErLinkageType(string Name, string IsNotNull, string Content, string Description, DataRow dr)
        {
            string str4;
            string str = "";
            string str2 = "";
            string[] strArray = Content.Split(new char[] { ',' });
            string[] strArray2 = strArray[0].Split(new char[] { '=' });
            string[] strArray3 = strArray[2].Split(new char[] { '=' });
            DataTable dictionary = new B_Dictionary().GetDictionary(int.Parse(strArray2[1]));
            if (IsNotNull == "True")
            {
                str2 = "<font color=\"red\">*</font>";
            }
            if (dr != null)
            {
                return str;
            }
            str = ("<select name=\"select_" + Name + "\" onchange=\"GetLinkage('select_" + Name + "','select_" + strArray3[1] + "',0)\">") + "<option value=\"0\">请选择</option>";
            for (int i = 0; i < dictionary.Rows.Count; i++)
            {
                str4 = str;
                str = str4 + "<option value=\"" + dictionary.Rows[i]["Id"].ToString() + "\">" + dictionary.Rows[i]["DicName"].ToString() + "</option>";
            }
            str4 = str;
            str4 = str4 + "</select><input type=\"txt\" name=\"txt_" + Name + "\" value=\"0\" style=\"display:none\"><input type=\"txt\" name=\"txt_" + Name + "_Id\" value=\"0\" style=\"display:none\">";
            return (str4 + " <select name=\"select_" + strArray3[1] + "\" onchange=\"GetSmallLinkage('select_" + strArray3[1] + "')\"><option value=\"0\">请选择</option></select><input type=\"txt\" name=\"txt_" + strArray3[1] + "\" value=\"0\" style=\"display:none\"><input type=\"txt\" name=\"txt_" + strArray3[1] + "_Id\" value=\"0\" style=\"display:none\">" + str2 + " " + Description + "");
        }

        public string GetFileType(string Name, string IsNotNull, string Content, string Description, DataRow dr)
        {
            string str2 = "";
            if (IsNotNull == "True")
            {
                str2 = "<font color=\"red\">*</font>";
            }
            if (dr == null)
            {
                return ("<input type=\"text\" name=\"txt_" + Name + "\" size=\"35\"> <input type=\"button\" class=\"btn\" onclick=\"WinOpenDialog('" + Param.ApplicationRootPath + "/common/UpLoadFile.aspx?ControlId=txt_" + Name + "','450','100')\" value=\" 选择文件 \"> " + str2 + " " + Description + "");
            }
            return ("<input type=\"text\" name=\"txt_" + Name + "\" size=\"35\" value=\"" + dr["" + Name + ""].ToString() + "\"> <input type=\"button\" class=\"btn\" onclick=\"WinOpenDialog('" + Param.ApplicationRootPath + "/common/UpLoadFile.aspx?ControlId=txt_" + Name + "','450','100')\" value=\" 选择文件 \"> " + str2 + " " + Description + "");
        }

        public string GetListBoxType(string Name, string IsNotNull, string Content, string Description, DataRow dr)
        {
            string[] strArray4;
            int num;
            bool flag;
            int num2;
            string str5;
            string str = "";
            string[] strArray2 = Content.Split(new char[] { ',' })[0].Split(new char[] { '=' });
            string[] strArray3 = strArray2[1].Split(new char[] { '|' });
            string str2 = "";
            if (IsNotNull == "True")
            {
                str2 = "<font color=\"red\">*</font>";
            }
            switch (strArray2[0])
            {
                case "1":
                    str = "";
                    for (num = 0; num < strArray3.Length; num++)
                    {
                        object obj2;
                        flag = false;
                        if (dr == null)
                        {
                            obj2 = str;
                            str = string.Concat(new object[] { obj2, "<input id=\"txt_", Name, "_", num, "\" type=\"checkbox\" name=\"txt_", Name, "\" value=\"", strArray3[num], "\" />", strArray3[num], "" });
                        }
                        else
                        {
                            strArray4 = dr["" + Name + ""].ToString().Split(new char[] { ',' });
                            for (num2 = 0; num2 < strArray4.Length; num2++)
                            {
                                if (strArray3[num].Trim() == strArray4[num2])
                                {
                                    obj2 = str;
                                    str = string.Concat(new object[] { obj2, "<input id=\"txt_", Name, "_", num, "\" type=\"checkbox\" name=\"txt_", Name, "\" value=\"", strArray3[num], "\" checked />", strArray3[num], "" });
                                    flag = true;
                                }
                            }
                            if (!flag)
                            {
                                obj2 = str;
                                str = string.Concat(new object[] { obj2, "<input id=\"txt_", Name, "_", num, "\" type=\"checkbox\" name=\"txt_", Name, "\" value=\"", strArray3[num], "\" />", strArray3[num], "" });
                            }
                        }
                    }
                    str5 = str;
                    return (str5 + "" + str2 + " " + Description + "");

                case "2":
                    str = "<select size=\"4\" name=\"txt_" + Name + "\"  style=\"width:300px;height:126px\" multiple>";
                    for (num = 0; num < strArray3.Length; num++)
                    {
                        flag = false;
                        if (dr == null)
                        {
                            str5 = str;
                            str = str5 + "<option value=\"" + strArray3[num] + "\">" + strArray3[num] + "</option>";
                        }
                        else
                        {
                            strArray4 = dr["" + Name + ""].ToString().Split(new char[] { ',' });
                            for (num2 = 0; num2 < strArray4.Length; num2++)
                            {
                                if (strArray3[num].Trim() == strArray4[num2])
                                {
                                    str5 = str;
                                    str = str5 + "<option value=\"" + strArray3[num] + " \" selected>" + strArray3[num] + "</option>";
                                    flag = true;
                                }
                            }
                            if (!flag)
                            {
                                str5 = str;
                                str = str5 + "<option value=\"" + strArray3[num] + "\">" + strArray3[num] + "</option>";
                            }
                        }
                    }
                    str5 = str;
                    return (str5 + "</select> " + str2 + " " + Description + "");
            }
            return "";
        }

        public string GetMultipleHtmlType(string Name, string IsNotNull, string Content, string Description, DataRow dr)
        {
            string str = "";
            string[] strArray = Content.Split(new char[] { ',' });
            string[] strArray2 = strArray[0].Split(new char[] { '=' });
            string[] strArray3 = strArray[1].Split(new char[] { '=' });
            string[] strArray4 = strArray[2].Split(new char[] { '=' });
            string str2 = "";
            if (IsNotNull == "True")
            {
                str2 = "<font color=\"red\">*</font>";
            }
            string str4 = strArray4[1];
            if (str4 == null)
            {
                return str;
            }
            if (!(str4 == "1"))
            {
                if (str4 != "2")
                {
                    if (str4 != "3")
                    {
                        return str;
                    }
                    if (dr == null)
                    {
                        return ("<input type=\"hidden\" id=\"txt_" + Name + "\" name=\"txt_" + Name + "\" value=\"\"><input type=\"hidden\" id=\"txt_" + Name + "___Config\" value=\"\"><iframe id=\"txt_" + Name + "___Frame\" src=\"" + Param.ApplicationRootPath + "/editor/fckeditor_3.html?InstanceName=txt_" + Name + "&Toolbar=Default\" width=\"" + strArray2[1] + "px\" height=\"" + strArray3[1] + "px\" frameborder=\"no\" scrolling=\"no\"></iframe> " + str2 + " " + Description + "");
                    }
                    return ("<input type=\"hidden\" id=\"txt_" + Name + "\" name=\"txt_" + Name + "\" value=\"" + Ky.Common.Function.HtmlEncode(dr["" + Name + ""].ToString()) + "\"><input type=\"hidden\" id=\"txt_" + Name + "___Config\" value=\"\"><iframe id=\"txt_" + Name + "___Frame\" src=\"" + Param.ApplicationRootPath + "/editor/fckeditor_3.html?InstanceName=txt_" + Name + "&Toolbar=Default\" width=\"" + strArray2[1] + "px\" height=\"" + strArray3[1] + "px\" frameborder=\"no\" scrolling=\"no\"></iframe> " + str2 + " " + Description + "");
                }
            }
            else
            {
                if (dr == null)
                {
                    return ("<input type=\"hidden\" id=\"txt_" + Name + "\" name=\"txt_" + Name + "\" value=\"\"><input type=\"hidden\" id=\"txt_" + Name + "___Config\" value=\"\"><iframe id=\"txt_" + Name + "___Frame\" src=\"" + Param.ApplicationRootPath + "/editor/fckeditor_1.html?InstanceName=txt_" + Name + "&Toolbar=Default\" width=\"" + strArray2[1] + "px\" height=\"" + strArray3[1] + "px\" frameborder=\"no\" scrolling=\"no\"></iframe> " + str2 + " " + Description + "");
                }
                return ("<input type=\"hidden\" id=\"txt_" + Name + "\" name=\"txt_" + Name + "\" value=\"" + Ky.Common.Function.HtmlEncode(dr["" + Name + ""].ToString()) + "\"><input type=\"hidden\" id=\"txt_" + Name + "___Config\" value=\"\"><iframe id=\"txt_" + Name + "___Frame\" src=\"" + Param.ApplicationRootPath + "/editor/fckeditor_1.html?InstanceName=txt_" + Name + "&Toolbar=Default\" width=\"" + strArray2[1] + "px\" height=\"" + strArray3[1] + "px\" frameborder=\"no\" scrolling=\"no\"></iframe> " + str2 + " " + Description + "");
            }
            if (dr == null)
            {
                return ("<input type=\"hidden\" id=\"txt_" + Name + "\" name=\"txt_" + Name + "\" value=\"\"><input type=\"hidden\" id=\"txt_" + Name + "___Config\" value=\"\"><iframe id=\"txt_" + Name + "___Frame\" src=\"" + Param.ApplicationRootPath + "/editor/fckeditor_2.html?InstanceName=txt_" + Name + "&Toolbar=Default\" width=\"" + strArray2[1] + "px\" height=\"" + strArray3[1] + "px\" frameborder=\"no\" scrolling=\"no\"></iframe> " + str2 + " " + Description + "");
            }
            return ("<input type=\"hidden\" id=\"txt_" + Name + "\" name=\"txt_" + Name + "\" value=\"" + Ky.Common.Function.HtmlEncode(dr["" + Name + ""].ToString()) + "\"><input type=\"hidden\" id=\"txt_" + Name + "___Config\" value=\"\"><iframe id=\"txt_" + Name + "___Frame\" src=\"" + Param.ApplicationRootPath + "/editor/fckeditor_2.html?InstanceName=txt_" + Name + "&Toolbar=Default\" width=\"" + strArray2[1] + "px\" height=\"" + strArray3[1] + "px\" frameborder=\"no\" scrolling=\"no\"></iframe> " + str2 + " " + Description + "");
        }

        public string GetMultipleTextType(string Name, string IsNotNull, string Content, string Description, DataRow dr)
        {
            string[] strArray = Content.Split(new char[] { ',' });
            string[] strArray2 = strArray[0].Split(new char[] { '=' });
            string[] strArray3 = strArray[1].Split(new char[] { '=' });
            string str2 = "";
            if (IsNotNull == "True")
            {
                str2 = "<font color=\"red\">*</font>";
            }
            if (dr == null)
            {
                return ("<textarea name=\"txt_" + Name + "\" style=\"height:" + strArray3[1] + "px;width:" + strArray2[1] + "px;\"></textarea> " + str2 + " " + Description + "");
            }
            return ("<textarea name=\"txt_" + Name + "\" style=\"height:" + strArray3[1] + "px;width:" + strArray2[1] + "px;\">" + Ky.Common.Function.Decode(dr["" + Name + ""].ToString()) + "</textarea> " + str2 + " " + Description + "");
        }

        public string GetNumberType(string Name, string IsNotNull, string Content, string Description, DataRow dr)
        {
            string[] strArray = Content.Split(new char[] { ',' });
            string[] strArray2 = strArray[0].Split(new char[] { '=' });
            string[] strArray3 = strArray[1].Split(new char[] { '=' });
            string str2 = "";
            if (IsNotNull == "True")
            {
                str2 = "<font color=\"red\">*</font>";
            }
            if (dr == null)
            {
                return ("<input type=\"text\" name=\"txt_" + Name + "\" size=\"" + strArray2[1] + "\" value=\"" + strArray3[1] + "\"  onpropertychange=\"if(/\\D/g.test(value))value=value.replace(/\\D/g,'')\" style=\"ime-mode:disabled\" ondragenter=\"return false\" maxlength=\"9\"> " + str2 + " " + Description + "");
            }
            return ("<input type=\"txt\" name=\"txt_" + Name + "\" size=\"" + strArray2[1] + "\" value=\"" + Ky.Common.Function.HtmlEncode(dr["" + Name + ""].ToString()) + "\" onpropertychange=\"if(/\\D/g.test(value))value=value.replace(/\\D/g,'')\" style=\"ime-mode:disabled\" ondragenter=\"return false\" maxlength=\"9\"> " + str2 + " " + Description + "");
        }

        public string GetPicType(string Name, string IsNotNull, string Content, string Description, DataRow dr)
        {
            string str2 = "";
            if (IsNotNull == "True")
            {
                str2 = "<font color=\"red\">*</font>";
            }
            if (dr == null)
            {
                return ("<input type=\"text\" name=\"txt_" + Name + "\" size=\"35\"> <input type=\"button\" class=\"btn\" onclick=\"WinOpenDialog('" + Param.ApplicationRootPath + "/common/SelectPic.aspx?ControlId=txt_" + Name + "','500','400')\" value=\" 选择图片 \"> " + str2 + " " + Description + "");
            }
            return ("<input type=\"text\" name=\"txt_" + Name + "\" size=\"35\" value=\"" + dr["" + Name + ""].ToString() + "\"> <input type=\"button\" class=\"btn\" onclick=\"WinOpenDialog('" + Param.ApplicationRootPath + "/common/SelectPic.aspx?ControlId=txt_" + Name + "','500','400')\" value=\" 选择图片 \"> " + str2 + " " + Description + "");
        }

        public string GetRadioType(string Name, string IsNotNull, string Content, string Description, DataRow dr)
        {
            int num;
            string str5;
            string str = "";
            string[] strArray2 = Content.Split(new char[] { ',' })[0].Split(new char[] { '=' });
            string[] strArray3 = strArray2[1].Split(new char[] { '|' });
            string str2 = "";
            if (IsNotNull == "True")
            {
                str2 = "<font color=\"red\">*</font>";
            }
            switch (strArray2[0])
            {
                case "1":
                    str = "<select name=\"txt_" + Name + "\">";
                    for (num = 0; num < strArray3.Length; num++)
                    {
                        if (dr == null)
                        {
                            str5 = str;
                            str = str5 + "<option value=\"" + strArray3[num] + "\">" + strArray3[num] + "</option>";
                        }
                        else if (strArray3[num] == dr["" + Name + ""].ToString())
                        {
                            str5 = str;
                            str = str5 + "<option value=\"" + strArray3[num] + "\" selected>" + strArray3[num] + "</option>";
                        }
                        else
                        {
                            str5 = str;
                            str = str5 + "<option value=\"" + strArray3[num] + "\">" + strArray3[num] + "</option>";
                        }
                    }
                    str5 = str;
                    return (str5 + "</select> " + str2 + " " + Description + "");

                case "2":
                    str = "";
                    for (num = 0; num < strArray3.Length; num++)
                    {
                        object obj2;
                        if (dr == null)
                        {
                            if (num == 0)
                            {
                                obj2 = str;
                                str = string.Concat(new object[] { obj2, "<input id=\"txt_", Name, "_", num, "\" type=\"radio\" name=\"txt_", Name, "\" value=\"", strArray3[num], "\" checked />", strArray3[num], "" });
                            }
                            else
                            {
                                obj2 = str;
                                str = string.Concat(new object[] { obj2, "<input id=\"txt_", Name, "_", num, "\" type=\"radio\" name=\"txt_", Name, "\" value=\"", strArray3[num], "\" />", strArray3[num], "" });
                            }
                        }
                        else if (strArray3[num] == dr["" + Name + ""].ToString())
                        {
                            obj2 = str;
                            str = string.Concat(new object[] { obj2, "<input id=\"txt_", Name, "_", num, "\" type=\"radio\" name=\"txt_", Name, "\" value=\"", strArray3[num], "\" checked />", strArray3[num], "" });
                        }
                        else
                        {
                            obj2 = str;
                            str = string.Concat(new object[] { obj2, "<input id=\"txt_", Name, "_", num, "\" type=\"radio\" name=\"txt_", Name, "\" value=\"", strArray3[num], "\" />", strArray3[num], "" });
                        }
                    }
                    str5 = str;
                    return (str5 + "" + str2 + " " + Description + "");
            }
            return "";
        }

        public string GetRadomType(string Name, string IsNotNull, string Content, string Description, DataRow dr)
        {
            string str2 = "";
            if (IsNotNull == "True")
            {
                str2 = "<font color=\"red\">*</font>";
            }
            if (dr == null)
            {
                return ("<input type=\"text\" name=\"txt_" + Name + "\" size=\"25\" readonly=\"true\" value=\"" + Ky.Common.Function.GetFileName() + "\"> " + str2 + " " + Description + "");
            }
            return ("<input type=\"text\" name=\"txt_" + Name + "\" size=\"25\" readonly=\"true\" value=\"" + dr["" + Name + ""].ToString() + "\"> " + str2 + " " + Description + "");
        }

        public string GetTextType(string Name, string IsNotNull, string Content, string Description, DataRow dr)
        {
            string[] strArray = Content.Split(new char[] { ',' });
            string[] strArray2 = strArray[0].Split(new char[] { '=' });
            string[] strArray3 = strArray[1].Split(new char[] { '=' });
            string[] strArray4 = strArray[2].Split(new char[] { '=' });
            string str2 = "";
            if (IsNotNull == "True")
            {
                str2 = "<font color=\"red\">*</font>";
            }
            if (dr == null)
            {
                return ("<input type=\"" + strArray3[1] + "\" name=\"txt_" + Name + "\" size=\"" + strArray2[1] + "\" value=\"" + strArray4[1] + "\"> " + str2 + " " + Description + "");
            }
            return ("<input type=\"" + strArray3[1] + "\" name=\"txt_" + Name + "\" size=\"" + strArray2[1] + "\" value=\"" + Ky.Common.Function.HtmlEncode(dr["" + Name + ""].ToString()) + "\"> " + str2 + " " + Description + "");
        }

        public string ShowStyleField(string Name, string IsNotNull, string Type, string Content, string Description, DataRow dr)
        {
            switch (Type)
            {
                case "TextType":
                    return this.GetTextType(Name, IsNotNull, Content, Description, dr);

                case "ListBoxType":
                    return this.GetListBoxType(Name, IsNotNull, Content, Description, dr);

                case "DateType":
                    return this.GetDateType(Name, IsNotNull, Description, dr);

                case "MultipleTextType":
                    return this.GetMultipleTextType(Name, IsNotNull, Content, Description, dr);

                case "MultipleHtmlType":
                    return this.GetMultipleHtmlType(Name, IsNotNull, Content, Description, dr);

                case "PicType":
                    return this.GetPicType(Name, IsNotNull, Content, Description, dr);

                case "RadioType":
                    return this.GetRadioType(Name, IsNotNull, Content, Description, dr);

                case "FileType":
                    return this.GetFileType(Name, IsNotNull, Content, Description, dr);

                case "RadomType":
                    return this.GetRadomType(Name, IsNotNull, Content, Description, dr);

                case "NumberType":
                    return this.GetNumberType(Name, IsNotNull, Content, Description, dr);

                case "ErLinkageType":
                    return this.GetErLinkageType(Name, IsNotNull, Content, Description, dr);
            }
            return "";
        }
    }
}

