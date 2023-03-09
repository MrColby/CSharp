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

            var lambdas = new Lambdas();
            lambdas.driveFunction();

            var events = new Events();
            events.driveFunction();

            var extensionMethods = new ExtensionMethods();
            extensionMethods.driveFunction();

            logger.exit();
        }
    }
 }