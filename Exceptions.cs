namespace com.logancolby.CSharp;

using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;




/**
 * https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/exceptions/
 * 
 * use 'using' : using (var streamReader = new StreamReader(@"C:\file.zip")
 * and the IDisposable will automatically be released.
 */
public class Exceptions : IFunctionDriver {

    public class LoganException : Exception
    {
        public LoganException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }

    public bool driveFunction()
    {
        LoggerBase.INSTANCE.enter();

        try
        {
            double num = 5.0;
            double den = 0.0;
            double dec = num / den;
            Console.WriteLine("? : " + dec); // doubles/floats go to infinity! Bizarre.
            int a = 5; int b = 0; int c = a / b;
        }
        // because Exception would catch everything, it has to go at the end . . . : )
        catch (DivideByZeroException ex)
        {
            LoggerBase.INSTANCE.msg("Divide by 0");
            //throw new LoganException("Ha ha", ex);
        }
        catch (ArithmeticException ex)
        {
            LoggerBase.INSTANCE.msg("AE");
        }
        catch (Exception ex)
        {
            LoggerBase.INSTANCE.msg("EX");
        }
        finally
        {
            // to dispose of IDisposable resources, etc. 
            // This will always be invoked even in the case of exceptions.
            Console.WriteLine("Finally.");
        }

        // or alternatively, use the using keyword (see main)



        LoggerBase.INSTANCE.exit();
        return true;



    }

}







