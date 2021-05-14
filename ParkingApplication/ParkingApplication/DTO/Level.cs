using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParkingApplication.DTO
{
    public class Level
    {
        private int Id;
        private String Name;
        private int Total;
        private int Alot;
        private int Free;
        private int CarNo;
        private int BusNo;
        private int TwoWheel;       

      
        public int LevelId
        {
            get { return Id; }
            set { Id = value; }
        }
        public int TotalSpace
        {
            get { return Total; }
            set { Total = value; }
        }
        public int AlottedSpace
        {
            get { return Alot; }
            set { Alot = value; }
        }
        public int FreeSpace
        {
            get { return Free; }
            set { Free = value; }
        }
        public int NoOfCars
        {
            get { return CarNo; }
            set { CarNo = value; }
        }
        public int NoOfBus
        {
            get { return BusNo; }
            set { BusNo = value; }
        }
        public int TwoWheelerNo
        {
            get { return TwoWheel; }
            set { TwoWheel = value; }
        }
        public String LevelName
        {
            get { return Name; }
            set { Name = value; }
        }

    }
}