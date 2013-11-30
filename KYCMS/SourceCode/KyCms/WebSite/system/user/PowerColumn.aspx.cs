using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Ky.BLL;
using Ky.Model;
using Ky.Common;

public partial class system_user_PowerColumn : System.Web.UI.Page
{
    private B_Channel BChannel = new B_Channel();
    private B_Column BColumn = new B_Column();
    private B_PowerGroup Bpowergroup = new B_PowerGroup();
    private M_PowerGroup Mpowergroup = new M_PowerGroup();
    private M_PowerColumn MPC = new M_PowerColumn();
    private B_PowerColumn BPC = new B_PowerColumn();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //权限判断
            Bpowergroup.Power_Judge(15);

            //绑定角色模型下拉框PowerModel_List
            DataTable dt = new DataTable();
            dt = Bpowergroup.PowerModelList();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    PowerModel_List.Items.Add(new ListItem(dt.Rows[i]["PowerName"].ToString(), dt.Rows[i]["PowerId"].ToString()));
                }
            }

            dt.Clear();
            dt.Dispose();

            //绑定内容管理Repeater
            DataRepeater1();
        }
    }

    private void DataRepeater1()
    {
        //新定义DataTable
        DataTable dt = new DataTable();
        dt.Columns.Add(new DataColumn("ChId", typeof(string)));
        dt.Columns.Add(new DataColumn("Name", typeof(string)));
        dt.Columns.Add(new DataColumn("ColId", typeof(string)));
        dt.Columns.Add(new DataColumn("Depth", typeof(string)));
        dt.Columns.Add(new DataColumn("TableNum", typeof(int))); 

        //获取频道
        DataTable dt1 = BChannel.GetList(false).Table;

        string sSelectBoxValue = "";

        for (int i = 0,t=1; i < dt1.Rows.Count;i++,t++ )
        {
            DataRow dr1 = dt.NewRow();
            dr1[0] = dt1.Rows[i]["ChId"].ToString();
            dr1[1] = dt1.Rows[i]["ChName"].ToString();
            dr1[2] = "0";
            dr1[3] = "0";
            dr1[4] = t;
            dt.Rows.Add(dr1);

           DataTable dt2 = new DataTable();
           dt2 = BColumn.GetListItemByChannelId(int.Parse(dt1.Rows[i]["ChId"].ToString()));

           for (int p = 0; p < dt2.Rows.Count; p++)
           {
               t++;
               DataRow dr2 = dt.NewRow();
               dr2[0] = dt1.Rows[i]["ChId"].ToString();
               dr2[1] = dt2.Rows[p]["ColName"].ToString();
               dr2[2] = dt2.Rows[p]["ColId"].ToString();
               dr2[3] = dt2.Rows[p]["Depth"].ToString();
               dr2[4] = t;
               dt.Rows.Add(dr2);
           }
           if (i == dt1.Rows.Count - 1)
           {
               sSelectBoxValue += dt1.Rows[i]["ChId"].ToString();
           }
           else
           {
               sSelectBoxValue += dt1.Rows[i]["ChId"].ToString() + ",";
           }
        }

        Repeater1.DataSource = dt;
        Repeater1.DataBind();

        //取除Repeater1最大行
        TableNum.Text = Repeater1.Items.Count.ToString();
        SelectBoxValue.Text = sSelectBoxValue;
    }

    /// <summary>
    /// 返回图片条件
    /// </summary>
    /// <param name="ChId"></param>
    /// <param name="ColId"></param>
    /// <param name="Depth"></param>
    /// <returns></returns>
    public string GetImgNum(int ChId, int ColId, int Depth)
    {
        if (ColId == 0) //频道
        {
            return GetImgList(1, 0, 0);
        }
        else
        {
            if (BColumn.ChkHasChildByColId(ColId))
            {
                return GetImgList(1, 0, Depth + 1);
            }
            else
            {
                return GetImgList(0, 1, Depth + 1);
            }
        }
    }

    /// <summary>
    /// 返回图片
    /// </summary>
    /// <param name="Add"></param>
    /// <param name="Del"></param>
    /// <param name="Depth"></param>
    /// <returns></returns>
    public string GetImgList(int Add, int Del, int Depth)
    {
        string sGetImgList = "";

        string AddImg = "<img src='../../images/+.gif' border=0 align='absmiddle'>";
        string DelImg = "<img src='../../images/-.gif' border=0 align='absmiddle'>";
        string DepthList = "<img src='../../images/tree_line.gif' border=0 align='absmiddle'>";

        if (Depth == 0)
        {
            sGetImgList=AddImg;
        }
        else
        {
            for (int i = 0; i < Depth; i++)
            {
                sGetImgList += DepthList;
            }

            if (Add != 0)
            {
                sGetImgList += AddImg;
            }
            else 
            {
                sGetImgList += DelImg;
            }
        }

        return sGetImgList;
    }

    public string GetSelectBox(int ChId,int ColId)
    {
        if (ColId == 0)
        {
            return "<select name='Select_" + ChId + "' size='1' onchange='SelectCancelSelect()'><option value='0'>无权限</option><option value='1'>一级审核</option><option value='2'>二级审核</option><option value='3'>三级审核</option></select>";
        }
        else
        {
            return "";
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        #region 获得所有栏目权限dt1

        //获得栏目权限PowerColumn
        string sPowerColumn = "";

        DataTable dt1 = new DataTable();
        dt1 = Bpowergroup.PowerColumnNameList();
        if (dt1.Rows.Count > 0)
        {
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                string MyPcId = "PCId_" + dt1.Rows[i]["PCId"].ToString() + "";
                CheckBox MyPcId1 = (CheckBox)FindControl(MyPcId);

                if (MyPcId1.Checked == true)
                {
                    //去掉最后一个","
                    if (i == dt1.Rows.Count - 1)
                    {
                        sPowerColumn += "" + dt1.Rows[i]["PCId"].ToString() + "=1";
                    }
                    else
                    {
                        sPowerColumn += "" + dt1.Rows[i]["PCId"].ToString() + "=1,";
                    }
                }
                else
                {
                    if (i == dt1.Rows.Count - 1)
                    {
                        sPowerColumn += "" + dt1.Rows[i]["PCId"].ToString() + "=0";
                    }
                    else
                    {
                        sPowerColumn += "" + dt1.Rows[i]["PCId"].ToString() + "=0,";
                    }
                }
            }
        }
        #endregion

        #region 获得频道权限
        string sPowerChannel = "";
        string sPowerAuditing = "";

        for (int r = 0,t=1; r < Repeater1.Items.Count; r++,t++)
        {
            sPowerChannel += "" + ((TextBox)(Repeater1).Items[r].FindControl("ChId")).Text + "@" + ((TextBox)(Repeater1).Items[r].FindControl("ColId")).Text + "=";
            for (int p = 1; p <= 4; p++)
            {
                if (Request.Form["ChIdColumnId_"+t+"_"+p+""] == "1")
                {
                    sPowerChannel += "1|";
                }
                else
                {
                    sPowerChannel += "0|";
                }
            }

            //去掉最后一个","
            if (r != Repeater1.Items.Count - 1)
            {
                sPowerChannel += ",";
            }

            if (((TextBox)(Repeater1).Items[r].FindControl("ColId")).Text == "0")
            {
                sPowerAuditing += ""+((TextBox)(Repeater1).Items[r].FindControl("ChId")).Text+"="+Request.Form["Select_" + ((TextBox)(Repeater1).Items[r].FindControl("ChId")).Text]+",";
            }
        }
        #endregion

        Mpowergroup.PowerContent = Function.SubStr(PowerContent.Text,500);
        Mpowergroup.PowerName = PowerName.Text;
        Mpowergroup.PowerColumn = sPowerColumn;
        Mpowergroup.PowerChannel = sPowerChannel;
        Mpowergroup.PowerAuditing = sPowerAuditing;
        Mpowergroup.PowerModel = "否";
        Mpowergroup.AddDate = DateTime.Now;
        Mpowergroup.TypeId = 5;

        Bpowergroup.Insert(Mpowergroup);

        Function.ShowSysMsg(1, "<li>成功添加管理员模板!</li><li><a href='user/AdminGroupList.aspx'>返回列表</a></li>");
    }

    /// <summary>
    /// 保存角色模型
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button2_Click(object sender, EventArgs e)
    {
        #region 获得所有栏目权限dt1

        //获得栏目权限PowerColumn
        string sPowerColumn = "";

        DataTable dt1 = new DataTable();
        dt1 = Bpowergroup.PowerColumnNameList();
        if (dt1.Rows.Count > 0)
        {
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                string MyPcId = "PCId_" + dt1.Rows[i]["PCId"].ToString() + "";
                CheckBox MyPcId1 = (CheckBox)FindControl(MyPcId);

                if (MyPcId1.Checked == true)
                {
                    //去掉最后一个","
                    if (i == dt1.Rows.Count - 1)
                    {
                        sPowerColumn += "" + dt1.Rows[i]["PCId"].ToString() + "=1";
                    }
                    else
                    {
                        sPowerColumn += "" + dt1.Rows[i]["PCId"].ToString() + "=1,";
                    }
                }
                else
                {
                    if (i == dt1.Rows.Count - 1)
                    {
                        sPowerColumn += "" + dt1.Rows[i]["PCId"].ToString() + "=0";
                    }
                    else
                    {
                        sPowerColumn += "" + dt1.Rows[i]["PCId"].ToString() + "=0,";
                    }
                }
            }
        }
        #endregion

        #region 获得频道权限
        string sPowerChannel = "";
        string sPowerAuditing = "";

        for (int r = 0, t = 1; r < Repeater1.Items.Count; r++, t++)
        {
            sPowerChannel += "" + ((TextBox)(Repeater1).Items[r].FindControl("ChId")).Text + "@" + ((TextBox)(Repeater1).Items[r].FindControl("ColId")).Text + "=";
            for (int p = 1; p <= 4; p++)
            {
                if (Request.Form["ChIdColumnId_" + t + "_" + p + ""] == "1")
                {
                    sPowerChannel += "1|";
                }
                else
                {
                    sPowerChannel += "0|";
                }
            }

            //去掉最后一个","
            if (r != Repeater1.Items.Count - 1)
            {
                sPowerChannel += ",";
            }

            if (((TextBox)(Repeater1).Items[r].FindControl("ColId")).Text == "0")
            {
                sPowerAuditing += "" + ((TextBox)(Repeater1).Items[r].FindControl("ChId")).Text + "=" + Request.Form["Select_" + ((TextBox)(Repeater1).Items[r].FindControl("ChId")).Text] + ",";
            }
        }
        #endregion

        Mpowergroup.PowerContent = Function.SubStr(PowerContent.Text,500);
        Mpowergroup.PowerName = PowerName.Text;
        Mpowergroup.PowerColumn = sPowerColumn;
        Mpowergroup.PowerChannel = sPowerChannel;
        Mpowergroup.PowerAuditing = sPowerAuditing;
        Mpowergroup.PowerModel = "是";
        Mpowergroup.AddDate = DateTime.Now;
        Mpowergroup.TypeId = 5;

        Bpowergroup.Insert(Mpowergroup);
        Function.ShowSysMsg(1, "<li>成功保存为管理员组模板!</li><li><a href='user/AdminGroupList.aspx'>返回列表</a></li>");
    }

    public string GetPowerColumn(int id)
    {
        MPC = BPC.GetModel(id);

        return MPC.PowerColumnName;
    }
}
