namespace com.logancolby.CSharp;

using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;




/**
  * https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/nullable-value-types * Lambda expressions and anonymous functions
  * https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/null-coalescing-operator
 */
public class Nullables : IFunctionDriver {

    public bool driveFunction()
    {
        LoggerBase.INSTANCE.enter();

        //DateTime birthday = null; Datetime is a valuetype; can't be null.
        Nullable<DateTime> birthday = null; // wrap it in nullable
        DateTime? secondBirthday = null; // or the question mark shortcut.

        if (secondBirthday.HasValue)
        {
            Console.WriteLine("sb has value");
        }
        else
        {
            Console.WriteLine("sb has no value");
        }

        // crazy, eh? We can call a method on a null; dereference and go. Because it's wrapped.
        // don't need for reference types, becuase there we can just do ==.
        // but how about generics, that might contain either? Hmm.

        // if birthday is null, use the other value
        var birthday3 = birthday ?? DateTime.Today;

        // equivalent
        var birthday4 = birthday.HasValue ? birthday : DateTime.Today;

 

        LoggerBase.INSTANCE.exit();
        return true;

       

    }

}







