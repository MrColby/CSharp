namespace com.logancolby.CSharp;

using System;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text.RegularExpressions;




/**
 * https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods
 * Delegates are function pointers! 
*/
public class ExtensionMethods : IFunctionDriver {
    public bool driveFunction()
    {
        LoggerBase.INSTANCE.enter();
        var longString = "As he crossed toward the pharmacy at the corner he involuntarily turned his head because of a burst of light that had ricocheted from his temple, and saw, with that quick smile with which we greet a rainbow or a rose, a blindingly white parallelogram of sky being unloaded from the van—a dresser with mirrors across which, as across a cinema screen, passed a flawlessly clear reflection of boughs sliding and swaying not arboreally, but with a human vacillation, produced by the nature of those who were carrying this sky, these boughs, this gliding façade.";
        var shortened = longString.Abbreviate(7) + " . . .";
        LoggerBase.INSTANCE.msg("Shortened: " + shortened);
        LoggerBase.INSTANCE.exit();
        return true;
    }
}
public static class StringExtensions
{
    // it is the 'this' keyword that attaches this method to the string class.
    public static string Abbreviate(this  string str, int numWords)
    {
        if (numWords < 0) throw new ArgumentOutOfRangeException("Negative value makes no sense.");
        if (numWords == 0) return "";
        var split = str.Split(' ');
        if (numWords >= split.Length)
        {
            return str;
        }
        return string.Join(' ', split.Take(numWords));
    }
}

