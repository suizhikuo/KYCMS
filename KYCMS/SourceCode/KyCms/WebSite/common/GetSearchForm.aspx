<%@ Page Language="C#" %>
<%@ Import Namespace="Ky.BLL"%>
<%@ Import Namespace="Ky.BLL.CommonModel"%>
<%@ Import Namespace="Ky.Model"%>
<%@ Import Namespace="Ky.Common"%>
<%@ Import Namespace="System.Data"%>
<%

B_Channel ChannelBll = new B_Channel();
B_ModelField ModelFieldBll = new B_ModelField();
bool IsGetUI = true;
int Flag = 1;
int Id = 0;

        Response.Cache.SetNoStore();
        if (!string.IsNullOrEmpty(Request.QueryString["id"]))
        {
            Id = int.Parse(Request.QueryString["id"]);
        }
        if (Request.QueryString["flag"] != null)
        {
            Flag = int.Parse(Request.QueryString["flag"]);
            IsGetUI = false;
        }
        if (IsGetUI)
        {
            DataView dv1 = ChannelBll.GetList(false);
            DataTable dt = dv1.ToTable();
            DataView dv = new DataView(dt);
            dv.RowFilter = "[isdisabled]=0";
            Response.Write("document.write('<script language=\"javascript\" id=\"src_field_list\"></script>');");
            Response.Write("document.write('<select id=\"search_channel_list\" style=\"width:110px\" onchange=\\' SetSearchField(\"" + Param.ApplicationRootPath + "\",this)\\'>');");
            Response.Write("document.write('<option value=\"0\">请选择频道</option>');");
            for (int i = 0; i < dv.Count; i++)
            {
                Response.Write("document.write('<option value=\"" + dv[i]["chid"] + "\">" + dv[i]["chname"] + "</option>');");
            }
            Response.Write("document.write('</select>');");
            dv.Dispose();
            Response.Write("document.write('<select id=\"search_field_list\" style=\"width:110px\"><option value=\"0\">选择搜索字段</option></select>');");
            Response.Write("document.write('<input type=\"text\" maxlength=\"50\" id=\"search_txt_keyword\" />');");
            Response.Write("document.write('<input type=\"button\" value=\"搜索\" onclick=\\'GoSearch(\"" + Param.ApplicationRootPath + "\")\\'/>');");
        }
        else
        {
            Response.Write("document.getElementById(\"search_field_list\").options.length=0;");
            if (Flag == 1)
            {
                Response.Write("document.getElementById(\"search_field_list\").options.add(new Option(\"标题\",\"title\"));");
                Response.Write("document.getElementById(\"search_field_list\").options.add(new Option(\"关键字\",\"tagnamestr\"));");
                M_Channel channelModel = ChannelBll.GetChannel(Id);
                if (channelModel == null)
                    return;
                DataTable dt = ModelFieldBll.GetSearchField(channelModel.ModelType);
                foreach (DataRow dr in dt.Rows)
                {
                    Response.Write("document.getElementById(\"search_field_list\").options.add(new Option(\"" + Function.HtmlEncode(dr["alias"]) + "\",\"" + Function.UrlEncode(dr["name"].ToString()) + "\"));");
                }
                dt.Dispose();
            }
            else
            {
                Response.Write("document.getElementById(\"search_field_list\").options.add(new Option(\"选择搜索字段\",\"0\"));");
            }


    }

















 %>
