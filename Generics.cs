namespace com.logancolby.CSharp;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

/**
 * https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types/generics
 * You can define [ ] function to access values. Cool: like C++ overriding.
 * Because of nullable issues,  use default keyword to initialize.
*/
public class Generics : IFunctionDriver
{
    public bool driveFunction()
    {
        LoggerBase.INSTANCE.enter(MethodBase.GetCurrentMethod());
        DriveGenerics<string, int> _driveGenerics = new DriveGenerics<string, int>();
        _driveGenerics.addElement("yes", 3);
        _driveGenerics.getElement("yes", false);
        _driveGenerics.getElement("no", false);
        LoggerBase.INSTANCE.exit( MethodBase.GetCurrentMethod());
        return true;
    }

    private class DriveGenerics<TKey, TValue>
    { 
        private Dictionary<TKey, TValue> _dictionary = new Dictionary<TKey, TValue>();
   
        public DriveGenerics()
        {

        }


        public void addElement(TKey name, TValue value) 
        {
            LoggerBase.INSTANCE.enter(name, value);
            this._dictionary[name] = value;
            LoggerBase.INSTANCE.exit();
        }

        public TValue getElement(TKey name, bool errorIfNonexistent)
        {
            LoggerBase.INSTANCE.enter(name);
            TValue rv = default(TValue);
            if (errorIfNonexistent)
            {
                rv = this._dictionary[name];
            }
            else
            {
                if (this._dictionary.ContainsKey(name))
                {
                    rv = this._dictionary[name];
                }
            }

            LoggerBase.INSTANCE.exit(rv);
            return rv;
        }
    }


}





