using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ParkingApplication.Controller;
using System.Data;

namespace ParkingApplication.Screens
{
    public partial class home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
          //  Level_Id LID, Level_Name LNAME,Level_Total TOTAL, Level_Alot ALOT,Level_Free FREE, Level_NoOf2W NOOF2W,Level_NoOfCar NOOFCAR, Level_NoOfBus NOOFBUS
            dt.Columns.Add("LNAME");
            dt.Columns.Add("TOTAL");
            dt.Columns.Add("ALOT");
            dt.Columns.Add("FREE");
            dt.Columns.Add("NOOF2W");
            dt.Columns.Add("NOOFCAR");
            dt.Columns.Add("NOOFBUS");
            dt.AcceptChanges();
            dt = new ParkingController().GetAllLevel();

            dt.AcceptChanges();
            ViewState["DT"] = dt;
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            { 
                DataTable dt = (DataTable)ViewState["DT"];
                LinkButton linkBus = (LinkButton)e.Row.Cells[6].FindControl("LinkBus");
                LinkButton linkCar = (LinkButton)e.Row.Cells[5].FindControl("LinkCar");
                LinkButton linkTwo = (LinkButton)e.Row.Cells[4].FindControl("Link2WVehicle");
                if (e.Row.RowIndex != -1)
                {
                    linkTwo.Text = dt.Rows[e.Row.RowIndex]["NOOF2W"].ToString();
                    linkCar.Text = dt.Rows[e.Row.RowIndex]["NOOFCAR"].ToString();
                    linkBus.Text = dt.Rows[e.Row.RowIndex]["NOOFBUS"].ToString();
                    linkBus.ForeColor= linkCar.ForeColor= linkTwo.ForeColor=  System.Drawing.Color.Red;
                }
                   
            }

        }

        protected void btnRelese_Click(object sender, EventArgs e)
        {

        }

        protected void btnAlot_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Screens/alotoage.aspx");
        }

        protected void Link2WVehicle_Click(object sender, EventArgs e)
        {

        }

        protected void LinkCar_Click(object sender, EventArgs e)
        {

        }

        protected void LinkBus_Click(object sender, EventArgs e)
        {

        }
    }
}