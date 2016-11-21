using System.Collections.Generic;
using System.Reflection;

namespace UnderstandindStaticInheritance.Net
{
    public class DerivedClass : BaseClass
    {
        public static new List<string> ListNames
        {
            get
            {
                return BaseClass.ListNames;
            }
            set
            {
                var field = typeof(BaseClass).GetField("_listNames", BindingFlags.Static | BindingFlags.NonPublic);
                field.SetValue(null, value);
            }
        }
    }
}