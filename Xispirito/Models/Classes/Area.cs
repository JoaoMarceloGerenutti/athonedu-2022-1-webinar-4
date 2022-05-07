using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Xispirito.Models.Classes
{
    public class Area : BaseEntity
    {
        private int AreaId { get; set; }
        private string AreaName { get; set; }

        public Area(int areaId, string areaName)
        {
            AreaId = areaId;
            AreaName = areaName;
        }

        public int GetAreaId()
        {
            return AreaId;
        }

        public string GetAreaName()
        {
            return AreaName;
        }
    }
}