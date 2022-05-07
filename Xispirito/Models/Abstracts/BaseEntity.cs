using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Xispirito.Models.Classes
{
    public abstract class BaseEntity
    {
        public bool IsActive { get; protected set; }

        public bool GetIsActive()
        {
            return IsActive;
        }

        public void Deactivate()
        {
            IsActive = true;
        }
    }
}