using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParkingApplication.DTO
{
    public class User
    {
        private int Id;
        private String Name;
        private String Mobno;

        public int UserId
        {
            get { return Id; }
            set { Id = value; }
        }
        public String UserName
        {
            get { return Name; }
            set { Name = value; }
        }
        public String MobileNo
        {
            get { return Mobno; }
            set { Mobno = value; }
        }
    }
}