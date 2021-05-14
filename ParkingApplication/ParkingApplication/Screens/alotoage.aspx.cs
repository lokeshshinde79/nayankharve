using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ParkingApplication.Controller;
namespace ParkingApplication.Screens
{
    public partial class alotoage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (DDlistLevel.SelectedIndex == 0)
            {
                divButtonPart.Visible = false;
                divUserInfo.Visible = false;
                gridViewLevelInfo.DataSource = null;
                gridViewLevelInfo.DataBind();

                Session["UserCtrIDList"] = new List<String>()
                {
                    "UserCtr1","UserCtr2","UserCtr3","UserCtr4","UserCtr5","UserCtr6","UserCtr7","UserCtr8","UserCtr9","UserCtr10"
                };
            }
        }

        protected void DDlistVehicleType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DDlistLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDlistLevel.SelectedIndex == 0)
            {
                gridViewLevelInfo.DataSource = null;
                gridViewLevelInfo.DataBind();
                divButtonPart.Visible = false;
                divUserInfo.Visible = false;
            }
            else if (DDlistLevel.SelectedIndex > 0)
            {
                DataTable dt = new DataTable();
                int levelid = Convert.ToInt32(DDlistLevel.SelectedValue);
                dt = new ParkingController().GetLevelById(levelid);

                DataTable dtSpaceInfo = new ParkingController().GetSpaceByLevel(levelid);
                gridViewLevelInfo.DataSource = dt;
                gridViewLevelInfo.DataBind();
                divButtonPart.Visible = true;
                divUserInfo.Visible = true;
                Session["LEVELINFO"] = dt;              

                DataTable dtAlot = new DataTable();
                dtAlot.Columns.Add("btn1");

                dtAlot.AcceptChanges();
                dtAlot.Rows.Add("1");
                //dtAlot.Rows.Add("1");
                //dtAlot.Rows.Add("1");
                //dtAlot.Rows.Add("1");
                //dtAlot.Rows.Add("1");

                dtAlot.AcceptChanges();
                gridAlot.DataSource = dtAlot;
                gridAlot.DataBind();

                //set Space 
                UserControl userCtr = null;
                for (int i = 0; i < dtSpaceInfo.Rows.Count; i++)
                {
                    var PreUser = gridAlot.Rows.OfType<GridViewRow>().ToList().Select(c => c.FindControl(dtSpaceInfo.Rows[i]["UCID"].ToString())).FirstOrDefault();
                    userCtr = (UserControl)PreUser;

                    Button btn = (Button)userCtr.FindControl(dtSpaceInfo.Rows[i]["BTNID"].ToString());
                    btn.BackColor = System.Drawing.Color.Red;
                }

                //

            }
        }

    

        protected void gridAlot_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                UserControl user1 = (UserControl)e.Row.Cells[1].FindControl("UserCtr1");
                UserControl user2 = (UserControl)e.Row.Cells[2].FindControl("UserCtr2");
                UserControl user3 = (UserControl)e.Row.Cells[2].FindControl("UserCtr3");
                UserControl user4 = (UserControl)e.Row.Cells[2].FindControl("UserCtr4");
                UserControl user5 = (UserControl)e.Row.Cells[2].FindControl("UserCtr5");
                UserControl user6 = (UserControl)e.Row.Cells[2].FindControl("UserCtr6");
                UserControl user7 = (UserControl)e.Row.Cells[2].FindControl("UserCtr7");
                UserControl user8 = (UserControl)e.Row.Cells[2].FindControl("UserCtr8");
                UserControl user9 = (UserControl)e.Row.Cells[2].FindControl("UserCtr9");
                UserControl user10 = (UserControl)e.Row.Cells[2].FindControl("UserCtr10");
                //LinkButton linkCar = (LinkButton)e.Row.Cells[5].FindControl("LinkCar");
                //LinkButton linkTwo = (LinkButton)e.Row.Cells[4].FindControl("Link2WVehicle");
                if (e.Row.RowIndex != -1)
                {
                    //linkTwo.Text = dt.Rows[e.Row.RowIndex]["NOOF2W"].ToString();
                    //linkCar.Text = dt.Rows[e.Row.RowIndex]["NOOFCAR"].ToString();
                    //linkBus.Text = dt.Rows[e.Row.RowIndex]["NOOFBUS"].ToString();

                    ((Button)user1.FindControl("btn1")).Text = "1";
                    ((Button)user2.FindControl("btn1")).Text = "2";
                    ((Button)user3.FindControl("btn1")).Text = "3";
                    ((Button)user4.FindControl("btn1")).Text = "4";
                    ((Button)user5.FindControl("btn1")).Text = "5";
                    ((Button)user6.FindControl("btn1")).Text = "6";
                    ((Button)user7.FindControl("btn1")).Text = "7";
                    ((Button)user8.FindControl("btn1")).Text = "8";
                    ((Button)user9.FindControl("btn1")).Text = "9";
                    ((Button)user10.FindControl("btn1")).Text = "10";

                    ((Button)user1.FindControl("btn2")).Text = "11";
                    ((Button)user2.FindControl("btn2")).Text = "12";
                    ((Button)user3.FindControl("btn2")).Text = "13";
                    ((Button)user4.FindControl("btn2")).Text = "14";
                    ((Button)user5.FindControl("btn2")).Text = "15";
                    ((Button)user6.FindControl("btn2")).Text = "16";
                    ((Button)user7.FindControl("btn2")).Text = "17";
                    ((Button)user8.FindControl("btn2")).Text = "18";
                    ((Button)user9.FindControl("btn2")).Text = "19";
                    ((Button)user10.FindControl("btn2")).Text = "20";

                    ((Button)user1.FindControl("btn3")).Text = "21";
                    ((Button)user2.FindControl("btn3")).Text = "22";
                    ((Button)user3.FindControl("btn3")).Text = "23";
                    ((Button)user4.FindControl("btn3")).Text = "24";
                    ((Button)user5.FindControl("btn3")).Text = "25";
                    ((Button)user6.FindControl("btn3")).Text = "26";
                    ((Button)user7.FindControl("btn3")).Text = "27";
                    ((Button)user8.FindControl("btn3")).Text = "28";
                    ((Button)user9.FindControl("btn3")).Text = "29";
                    ((Button)user10.FindControl("btn3")).Text = "30";

                    ((Button)user1.FindControl("btn4")).Text = "31";
                    ((Button)user2.FindControl("btn4")).Text = "32";
                    ((Button)user3.FindControl("btn4")).Text = "33";
                    ((Button)user4.FindControl("btn4")).Text = "34";
                    ((Button)user5.FindControl("btn4")).Text = "35";
                    ((Button)user6.FindControl("btn4")).Text = "36";
                    ((Button)user7.FindControl("btn4")).Text = "37";
                    ((Button)user8.FindControl("btn4")).Text = "38";
                    ((Button)user9.FindControl("btn4")).Text = "39";
                    ((Button)user10.FindControl("btn4")).Text = "40";

                    ((Button)user1.FindControl("btn5")).Text = "41";
                    ((Button)user2.FindControl("btn5")).Text = "42";
                    ((Button)user3.FindControl("btn5")).Text = "43";
                    ((Button)user4.FindControl("btn5")).Text = "44";
                    ((Button)user5.FindControl("btn5")).Text = "45";
                    ((Button)user6.FindControl("btn5")).Text = "46";
                    ((Button)user7.FindControl("btn5")).Text = "47";
                    ((Button)user8.FindControl("btn5")).Text = "48";
                    ((Button)user9.FindControl("btn5")).Text = "49";
                    ((Button)user10.FindControl("btn5")).Text = "50";
                    
                }

            }
        }

    }
}