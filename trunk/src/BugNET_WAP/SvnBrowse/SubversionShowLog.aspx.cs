using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace BugNET.SvnBrowse
{
    public partial class SubversionShowLog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable("Log");
            DataColumn column;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Rev";
            column.ReadOnly = true;
            column.Unique = true;
            dt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Log";
            column.ReadOnly = true;
            column.Unique = true;
            dt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Date";
            column.ReadOnly = true;
            column.Unique = true;
            dt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "User";
            column.ReadOnly = true;
            column.Unique = true;
            dt.Columns.Add(column);

            DataSet ds = new DataSet();
            ds.Tables.Add(dt);

            DataRow dr = dt.NewRow();

            dr["rev"] = "T";
            dr["Log"] = "E";
            dr["Date"] = "S";
            dr["User"] = "T";

            dt.Rows.Add(dr);

            SvnLog.DataSource = dt;
            SvnLog.DataBind();
        }
    }
}