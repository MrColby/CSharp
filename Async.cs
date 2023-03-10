namespace com.logancolby.CSharp;

using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;




/**
 * https://learn.microsoft.com/en-us/dotnet/csharp/asynchronous-programming/

 */
public class Async : IFunctionDriver {

    public  bool driveFunction()
    {
        LoggerBase.INSTANCE.enter();


        doDrive();
        for (var i=0; i < 5000; i++)
        {
            Console.WriteLine(i);
        }


        LoggerBase.INSTANCE.exit();
        return true;



    }

    public async void doDrive()
    {
        var response = await sleepMyBabyAsync();
    }

    public async Task<bool> sleepMyBabyAsync()
    {
       await Task.Delay(1000);
        Console.WriteLine("*********************************************");
        return true;
    }

    

}







