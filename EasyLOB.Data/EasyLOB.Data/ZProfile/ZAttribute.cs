using System;

namespace EasyLOB.Data
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ZKeyAttribute : Attribute
    {
        public bool IsIdentity { get; set; }

        public ZKeyAttribute(bool isIdentity = false)
        {
            this.IsIdentity = isIdentity;
        }
    }
}
