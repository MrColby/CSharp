namespace com.logancolby.CSharp;

using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;




/**
 * https://learn.microsoft.com/en-us/dotnet/csharp/advanced-topics/interop/using-type-dynamic

    dynamics behave like variables in javascript. They're figured out at runtime, not compile.
    They can change type.

 */
public class Dynamics : IFunctionDriver {

    

    public bool driveFunction()
    {
        LoggerBase.INSTANCE.enter();

        dynamic d = "Logan";
        d = 10;
        d++;



        LoggerBase.INSTANCE.exit();
        return true;



    }

}







