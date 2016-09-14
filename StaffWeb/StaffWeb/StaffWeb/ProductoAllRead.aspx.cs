using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using DataAccess;
namespace StaffWeb
{
    public partial class ProductoAllRead : _classes.PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet dsCategory = DBConn.RunSelectQuery("select * from [SelectOptions]");

            Response.Clear();
            Response.ContentType = "text/json";

            string strJson = "[";
            string strSpliter = "";

            for (int i = 0; i < DataSetUtil.RowCount(dsCategory); i++)
            {

                string strid = DataSetUtil.RowStringValue(dsCategory, "idOption", i);
                string strCategory = DataSetUtil.RowStringValue(dsCategory, "OptionName", i);
                strJson += strSpliter + string.Format("{{\"id\": \"{0}\", \"category\": \"{1}\"}}", strid, strCategory);
                if (strSpliter == "") strSpliter = ",";

            }
            strJson += "]";
            Response.Write(strJson);
        }
    }
}