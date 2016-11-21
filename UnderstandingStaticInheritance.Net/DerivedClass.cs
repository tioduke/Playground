using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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
            var field = typeof(BaseClass).GetField("_listNames", BindingFlags.Static|BindingFlags.NonPublic);
            field.SetValue(null, value);
        }
    }
    
}