using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ParkingApplication.DTO;
using ParkingApplication.Controller;

namespace ParkingApplication.Screens
{
    public partial class UserControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public Button UserCtr_Btn1
        {
            get
            {
                return this.btn1;
            }
        }
        public Button UserCtr_Btn2
        {
            get
            {
                return this.Btn2;
            }
        }
        public Button UserCtr_Btn3
        {
            get
            {
                return this.btn3;
            }
        }
        public Button UserCtr_Btn4
        {
            get
            {
                return this.btn4;
            }
        }
        public Button UserCtr_Btn5
        {
            get
            {
                return this.btn5;
            }
        }

        protected void btn1_Click(object sender, EventArgs e)
        {
            UserControl user = this;
            String userID = user.ID;
            btn1 = ((Button)sender);
            String parentID = btn1.Parent.ID;


            Button test = (Button)user.FindControl("btn1");
            Button test2 = (Button)user.FindControl("btn2");

            //String index = ((UserControl)(((Button)sender).NamingContainer)).ID;
            //UserControl index1 = ((UserControl) (((Button)sender).NamingContainer).FindControl("UserCtr1"));
            //var d = grid.Rows.OfType<GridViewRow>().ToList().Select(c => c.FindControl("UserCtr10")).FirstOrDefault();
            //         UserControl user10 = (UserControl)d;

            if (userID.Equals(parentID))
            {
                List<Button> listBtn = new List<Button>();
                DropDownList ddListVehType = (DropDownList)Page.FindControl("DDlistVehicleType");
                switch (ddListVehType.SelectedValue.ToString())
                {
                    case "T":
                        if (user.UserCtr_Btn1.BackColor.Equals(System.Drawing.Color.Red))
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('This Space Is Not Free')", true);
                        }
                        else
                        {
                            listBtn.Add(user.UserCtr_Btn1);
                            Insert(listBtn);
                            user.UserCtr_Btn1.BackColor = System.Drawing.Color.Red;
                            listBtn.Clear();
                        }
                        break;

                    case "C":

                        if (user.UserCtr_Btn1.BackColor.Equals(System.Drawing.Color.Red))
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Space Is Not Available For Car')", true);
                        }
                        else
                        {
                            int SpaceReq = 1;
                            SpaceReq = leftPart(user, btn1, ref SpaceReq, "C", ref listBtn);
                            if (SpaceReq > 0)
                            {
                                SpaceReq = RightPart(user, btn1, ref SpaceReq, "C", ref listBtn);
                                if (SpaceReq > 0)
                                {
                                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Space Is Not Available For Car')", true);
                                }
                            }
                            if (SpaceReq == 0)
                            {
                                listBtn.Add(user.UserCtr_Btn1);
                                Insert(listBtn);
                                foreach (Button btn in listBtn)
                                {
                                    btn.BackColor = System.Drawing.Color.Red;
                                }

                                user.UserCtr_Btn1.BackColor = System.Drawing.Color.Red;
                                listBtn.Clear();
                            }

                        }
                        break;
                    case "B":

                        if (user.UserCtr_Btn1.BackColor.Equals(System.Drawing.Color.Red))
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Space Is Not Available For Car')", true);
                        }
                        else
                        {
                            int SpaceReq = 4;
                            SpaceReq = leftPart(user, btn1, ref SpaceReq, "B", ref listBtn);
                            if (SpaceReq > 0)
                            {
                                SpaceReq = RightPart(user, btn1, ref SpaceReq, "B", ref listBtn);
                                if (SpaceReq > 0)
                                {
                                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Space Is Not Available For Bus')", true);
                                }
                            }
                            if (SpaceReq == 0)
                            {
                                listBtn.Add(user.UserCtr_Btn1);
                                Insert(listBtn);
                                foreach (Button btn in listBtn)
                                {
                                    btn.BackColor = System.Drawing.Color.Red;
                                }
                                user.UserCtr_Btn1.BackColor = System.Drawing.Color.Red;
                                listBtn.Clear();
                            }

                        }
                        break;
                    default:
                        break;
                }
            }

        }
        public int leftPart(UserControl user, Button btn, ref int spaceReq, String vehicleType, ref List<Button> listBtn)
        {
            int temp = 0;
            if (spaceReq == 0)
            {
                return spaceReq;
            }
            UserControl previousUserCtr = GetPrviousUserCtr(user);
            if (previousUserCtr != null)
            {
                temp = spaceReq;
                if (temp != CheckSpace(previousUserCtr, btn, ref spaceReq, ref listBtn))
                {
                    leftPart(previousUserCtr, btn, ref spaceReq, vehicleType, ref listBtn);
                }

            }
            return spaceReq;
        }
        public int RightPart(UserControl user, Button btn, ref int spaceReq, String vehicleType, ref List<Button> listBtn)
        {
            int temp = 0;
            if (spaceReq == 0)
            {
                return spaceReq;
            }
            UserControl nextUserCtr = GetNextUserCtr(user);
            if (nextUserCtr != null)
            {
                temp = spaceReq;
                if (temp != CheckSpace(nextUserCtr, btn, ref spaceReq, ref listBtn))
                {
                    //spaceReq = temp;
                    RightPart(nextUserCtr, btn, ref spaceReq, vehicleType, ref listBtn);
                }

            }
            return spaceReq;
        }
        public UserControl GetPrviousUserCtr(UserControl user)
        {
            UserControl PreUserControl = null;
            GridView grid = (GridView)Page.FindControl("gridAlot");
            List<String> UClist = (List<String>)Session["UserCtrIDList"];
            int CurrentUserCtrIndex = UClist.IndexOf(user.ID);
            if (CurrentUserCtrIndex > 0)
            {
                var PreUser = grid.Rows.OfType<GridViewRow>().ToList().Select(c => c.FindControl(UClist[CurrentUserCtrIndex - 1])).FirstOrDefault();
                PreUserControl = (UserControl)PreUser;
            }
            return PreUserControl;
        }
        public UserControl GetNextUserCtr(UserControl user)
        {
            UserControl NextUserControl = null;
            GridView grid = (GridView)Page.FindControl("gridAlot");
            List<String> UClist = (List<String>)Session["UserCtrIDList"];
            int CurrentUserCtrIndex = UClist.IndexOf(user.ID);
            if (CurrentUserCtrIndex < (UClist.Count - 1))
            {
                var NextUser = grid.Rows.OfType<GridViewRow>().ToList().Select(c => c.FindControl(UClist[CurrentUserCtrIndex + 1])).FirstOrDefault();
                NextUserControl = (UserControl)NextUser;

            }
            return NextUserControl;
        }

        public int CheckSpace(UserControl userControl, Button btn, ref int spaceReq, ref List<Button> listBtn)
        {
            if (spaceReq == 0)
            {
                return spaceReq;
            }

            if (userControl.UserCtr_Btn1.ID.Equals(btn.ID))
            {
                if (userControl.UserCtr_Btn1.BackColor.Equals(System.Drawing.Color.Red))
                {
                    return spaceReq;
                }
                else
                {
                    listBtn.Add(userControl.UserCtr_Btn1);
                    // userControl.UserCtr_Btn1.BackColor = System.Drawing.Color.Red;
                    spaceReq--;
                }

            }
            else if (userControl.UserCtr_Btn2.ID.Equals(btn.ID))
            {
                if (userControl.UserCtr_Btn2.BackColor.Equals(System.Drawing.Color.Red))
                {
                    return spaceReq;
                }
                else
                {
                    listBtn.Add(userControl.UserCtr_Btn2);
                    //userControl.UserCtr_Btn2.BackColor = System.Drawing.Color.Red;
                    spaceReq--;
                }
            }
            else if (userControl.UserCtr_Btn3.ID.Equals(btn.ID))
            {
                if (userControl.UserCtr_Btn3.BackColor.Equals(System.Drawing.Color.Red))
                {
                    return spaceReq;
                }
                else
                {
                    listBtn.Add(userControl.UserCtr_Btn3);
                    // userControl.UserCtr_Btn3.BackColor = System.Drawing.Color.Red;
                    spaceReq--;
                }
            }
            else if (userControl.UserCtr_Btn4.ID.Equals(btn.ID))
            {
                if (userControl.UserCtr_Btn4.BackColor.Equals(System.Drawing.Color.Red))
                {
                    return spaceReq;
                }
                else
                {
                    listBtn.Add(userControl.UserCtr_Btn4);
                    // userControl.UserCtr_Btn4.BackColor = System.Drawing.Color.Red;
                    spaceReq--;
                }
            }
            else if (userControl.UserCtr_Btn5.ID.Equals(btn.ID))
            {
                if (userControl.UserCtr_Btn5.BackColor.Equals(System.Drawing.Color.Red))
                {
                    return spaceReq;
                }
                else
                {
                    listBtn.Add(userControl.UserCtr_Btn5);
                    //  userControl.UserCtr_Btn5.BackColor = System.Drawing.Color.Red;
                    spaceReq--;
                }
            }
            return spaceReq;
        }
        public void Insert(List<Button> btnlist)
        {
            DataTable dtLevel = (DataTable)Session["LEVELINFO"];
            dtLevel.Rows[0]["ALOT"] = (Convert.ToInt32(dtLevel.Rows[0]["ALOT"]) + btnlist.Count);
            dtLevel.Rows[0]["FREE"] = Convert.ToInt32(dtLevel.Rows[0]["TOTAL"]) - Convert.ToInt32(dtLevel.Rows[0]["ALOT"]);
            if (btnlist.Count == 1)
            {
                dtLevel.Rows[0]["NOOF2W"] = Convert.ToInt32(dtLevel.Rows[0]["NOOF2W"]) + btnlist.Count;
            }
            else if (btnlist.Count == 2)
            {
                dtLevel.Rows[0]["NOOFCAR"] = Convert.ToInt32(dtLevel.Rows[0]["NOOFCAR"]) + 1;
            }
            else if (btnlist.Count == 5)
            {
                dtLevel.Rows[0]["NOOFBUS"] = Convert.ToInt32(dtLevel.Rows[0]["NOOFBUS"]) + 1;
            }
            dtLevel.AcceptChanges();
            Session["LEVELINFO"] = dtLevel;
            GridView grid = (GridView)Page.FindControl("gridViewLevelInfo");
            grid.DataSource = dtLevel;
            grid.DataBind();

            TextBox txtUserName = (TextBox)Page.FindControl("txtUserName");
            TextBox txtMob = (TextBox)Page.FindControl("txtMobile");
            TextBox txtVehName = (TextBox)Page.FindControl("txtVehicleName");
            TextBox txtVehDesc = (TextBox)Page.FindControl("txtDescr");

            DropDownList ddvehType = (DropDownList)Page.FindControl("DDlistVehicleType");
            User user = new User();
            Vehicle veh = new Vehicle();
            Level level = new Level();
            Space[] space = new Space[btnlist.Count];

            for (int i = 0; i < dtLevel.Rows.Count; i++)
            {
                level.TwoWheelerNo = Convert.ToInt32(dtLevel.Rows[0]["NOOF2W"]);
                level.NoOfBus = Convert.ToInt32(dtLevel.Rows[0]["NOOFBUS"]);
                level.NoOfCars = Convert.ToInt32(dtLevel.Rows[0]["NOOFCAR"]);
                level.AlottedSpace = Convert.ToInt32(dtLevel.Rows[0]["ALOT"]);
                level.FreeSpace = Convert.ToInt32(dtLevel.Rows[0]["FREE"]);
                level.LevelId = Convert.ToInt32(dtLevel.Rows[0]["LID"]);

            }
            user.UserName = txtUserName.Text;
            user.MobileNo = txtMob.Text;

            veh.VehicleDesc = txtVehDesc.Text;
            veh.VehicleName = txtVehName.Text;
            veh.VehicleType = Convert.ToChar(ddvehType.SelectedValue);
            veh.VLevelId = Convert.ToInt32(dtLevel.Rows[0]["LID"]);

            for (int i = 0; i < btnlist.Count; i++)
            {
                space[i] = new Space();
                space[i].LevelId = Convert.ToInt32(dtLevel.Rows[0]["LID"]);
                space[i].btnId = ((Button)btnlist[i]).ID;
                space[i].UserContId = ((Button)btnlist[i]).Parent.ID;
            }

            int Result = new ParkingController().InsertUpdate(user, veh, level, space);
        }

    }
}