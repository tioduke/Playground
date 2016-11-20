using System;
using System.Collections.Generic;

public class BaseClass
{
    private static  List<string> _listNames;

    public static List<string> ListNames
    {
        get
        {
            if (BaseClass._listNames == null)
            {
                BaseClass._listNames = new List<string> { "one", "two" };
            }
            return BaseClass._listNames;
        }
    }
    
}