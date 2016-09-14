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
    public partial class postnewtask : _classes.PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string userid = Request["userid"];
            string date = Request["date"];
            string tasktype = Request["tasktype"];
            string RutaAbastecimiento = Request["RutaAbastecimiento"];
            string TaskBusinessKey = Request["TaskBusinessKey"];
            string Customer = Request["Customer"];
            string Adress = Request["Adress"];
            string LocationDesc = Request["LocationDesc"];
            string Model = Request["Model"];
            string latitude = Request["latitude"];
            string longitude = Request["longitude"];
            string epv = Request["epv"];
            string MachineType = Request["MachineType"];
            string Aux_valor1 = Request["Aux_valor1"];
            string Aux_valor2 = Request["Aux_valor2"];
            string Aux_valor3 = Request["Aux_valor3"];
            string Aux_valor4 = Request["Aux_valor4"];
            string Aux_valor5 = Request["Aux_valor5"];
            string Aux_valor6 = Request["Aux_valor6"];

            string strJson = string.Format("{{\"result\": \"{0}\"}}", "failed");
            long lNewTaskID = DBConn.RunInsertQuery("insert into pendingTask(userid, date, TaskType, RutaAbastecimiento, TaskBusinessKey, Customer, Adress, LocationDesc, Model, Latitude, Longitude, EPV, MachineType, Aux_valor1, Aux_valor2, Aux_valor3, Aux_valor4, Aux_valor5, Aux_valor6) values ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18})",
                            new string[] {
                                "@userid",
                                "@date",
                                "@tasktype", 
                                "@RutaAbastecimiento", 
                                "@TaskBusinessKey",
                                "@Customer",
                                "@Adress",
                                "@LocationDesc", 
                                "@Model", 
                                "@Latitude", 
                                "@Longitude", 
                                "@epv", 
                                "@MachineType",
                                "@Aux_valor1", 
                                "@Aux_valor2", 
                                "@Aux_valor3", 
                                "@Aux_valor4", 
                                "@Aux_valor5", 
                                "@Aux_valor6"
                            },
                            new object[] {
                                userid,
                                date,
                                tasktype,
                                RutaAbastecimiento,
                                TaskBusinessKey,
                                Customer, 
                                Adress, 
                                LocationDesc, 
                                Model, 
                                latitude, 
                                longitude, 
                                epv, 
                                MachineType,
                                Aux_valor1, 
                                Aux_valor2, 
                                Aux_valor3, 
                                Aux_valor4, 
                                Aux_valor5, 
                                Aux_valor6
                            }, true);

            if (lNewTaskID > 0)
            {
                strJson = string.Format("{{\"result\": \"{0}\", \"taskid\": {1}}}", "success", lNewTaskID);
            }

            Response.Write(strJson);
        }
    }
}