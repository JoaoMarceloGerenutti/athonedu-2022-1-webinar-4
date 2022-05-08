using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Xispirito.Models
{
    public class Area : BaseEntity
    {
        private int AreaId { get; set; }
        private string AreaName { get; set; }

        public Area(int areaId, string areaName, bool isActive)
        {
            AreaId = areaId;
            AreaName = areaName;
            IsActive = isActive;
        }

        public int GetId()
        {
            return AreaId;
        }

        public string GetArea()
        {
            return AreaName;
        }
    }
}