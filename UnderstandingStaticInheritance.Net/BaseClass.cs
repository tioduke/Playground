using System.Collections.Generic;

namespace UnderstandindStaticInheritance.Net
{
    public class BaseClass
    {
        private static List<string> _listNames;

        public static List<string> ListNames
        {
            get { return _listNames ?? (_listNames = new List<string> { "one", "two" }); }
        }
    }
}