using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CSV
{
    class Person
    {
        public object this[string propertyName]
        {
            get
            {
                Type myType = typeof(Person);
                PropertyInfo myPropInfo = myType.GetProperty(propertyName);
                return myPropInfo.GetValue(this, null);
            }
        }
        public int Age { get; set; }
        public string EyeColor { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public decimal? Salary { get; set; }

    }
}
