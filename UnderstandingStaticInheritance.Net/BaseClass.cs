using System;
using System.Collections.Generic;

public class BaseClass
{
    private static  List<string> _listNames;

    public static List<string> ListNames
    {
        get
        {
            if (this._listNames == null)
            {
                this._listNames = new List<string> { "one", "two" };
            }
            return this._listNames;
        }
    }
    
}