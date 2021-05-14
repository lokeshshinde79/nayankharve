using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParkingApplication.DTO
{
    public class Space
    {
        public int SpaceId {get;set;}
        public int LevelId { get; set; }
        public int VehId { get; set; }
        public String btnId { get; set; }
        public String UserContId { get; set; }
    }
}