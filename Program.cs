using System.Text;

namespace com.logancolby.CSharp;

/*
 * This class drives the suite. 
 */
public class Program
{
    public static void Main(string[] args)
    {


        Console.WriteLine("CSharp!");

        // using so that the file stream (if using) has a chance to flush and close.
        using (var logger = LoggerBase.setInstance(new LoggerConsole()))
        {

            var generics = new Generics();
            generics.driveFunction();

            var delegates = new Delegates();
            delegates.driveFunction();

            logger.exit();
        }
    }
 }